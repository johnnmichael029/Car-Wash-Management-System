Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class SalesDatabaseHelper
    Private Shared constr As String
    Private ReadOnly printData As PrintDataInSales
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Shared Sub AddSale(saleID As String, allSaleItems As List(Of SalesService), paymentMethod As String, referenceID As String, cheque As String, totalPrice As Decimal)
        Dim iSaleID As Integer = CInt(saleID)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                Dim newSalesID As Integer
                Dim insertHistoryQuery = "INSERT INTO RegularSaleTable (CustomerID, SaleDate, PaymentMethod, ReferenceID, TotalPrice) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @ReferenceID, @TotalPrice); SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(insertHistoryQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@CustomerID", iSaleID)
                    cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                    newSalesID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                Dim insertServiceQuery = "INSERT INTO SalesServiceTable (SalesID, ServiceID, AddonServiceID, Subtotal) VALUES (@SalesID, @ServiceID, @AddonServiceID, @Subtotal)"

                For Each item As SalesService In allSaleItems
                    Dim baseServiceID As Integer = GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = GetAddonIdByName(item.Addon)

                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@SalesID", newSalesID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)

                        cmdService.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit()
                Carwash.NotificationLabel.Text = "New Sale Added"
                Carwash.ShowNotification()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Shared Sub UpdateSale(customerID As Integer, saleID As String, allSaleItems As List(Of SalesService), paymentMethod As String, referenceID As String, cheque As String, totalPrice As Decimal)
        Dim iSaleID As Integer = CInt(saleID)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' Step 1: Update SalesHistoryTable
                Dim updateHistoryQuery = "UPDATE RegularSaleTable SET CustomerID = @CustomerID, PaymentMethod = @PaymentMethod, ReferenceID = @ReferenceID, TotalPrice = @TotalPrice WHERE SalesID = @SalesID"
                Using cmd As New SqlCommand(updateHistoryQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                    cmd.Parameters.AddWithValue("@SalesID", iSaleID)
                    cmd.ExecuteNonQuery()
                End Using
                ' Step 2: Delete existing entries in SalesServiceTable and SalesHistoryTable for this SalesID
                Dim deleteServicesQuery = "DELETE FROM SalesServiceTable WHERE SalesID = @SalesID"
                Using cmdDelete As New SqlCommand(deleteServicesQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@SalesID", saleID)
                    cmdDelete.ExecuteNonQuery()
                End Using
                Dim deleteSalesServicesFromHistoryQuery = "DELETE FROM SalesHistoryTable WHERE RegularSaleID = @SalesID"
                Using cmdDelete As New SqlCommand(deleteSalesServicesFromHistoryQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@SalesID", saleID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                ' Add the new sales services to SalesHistoryTable if needed
                Dim insertSalesHistoryQuery = "INSERT INTO SalesHistoryTable (CustomerID, SaleDate, PaymentMethod, RegularSaleID, ServiceID, AddonServiceID, TotalPrice) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @RegularSaleID, @ServiceID, @AddonServiceID, @TotalPrice)"
                For Each item As SalesService In allSaleItems
                    Dim baseServiceID As Integer = GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = GetAddonIdByName(item.Addon)
                    Using cmdHistory As New SqlCommand(insertSalesHistoryQuery, con, transaction)
                        cmdHistory.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdHistory.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                        cmdHistory.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                        cmdHistory.Parameters.AddWithValue("@RegularSaleID", iSaleID)
                        cmdHistory.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdHistory.Parameters.AddWithValue("@TotalPrice", item.ServicePrice)
                        cmdHistory.ExecuteNonQuery()
                    End Using
                Next
                ' Step 3: Insert new entries into SalesServiceTable
                Dim insertServiceQuery = "INSERT INTO SalesServiceTable (SalesID, ServiceID, AddonServiceID, Subtotal) VALUES (@SalesID, @ServiceID, @AddonServiceID, @Subtotal)"
                For Each item As SalesService In allSaleItems
                    Dim baseServiceID As Integer = GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@SalesID", iSaleID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)
                        cmdService.ExecuteNonQuery()
                    End Using
                Next
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error updating sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    ' --- BASE SERVICE ID LOOKUP ---
    Public Shared Function GetServiceIdByName(serviceName As String) As Integer
        If String.IsNullOrWhiteSpace(serviceName) Then
            Throw New ArgumentException("Service name cannot be empty.")
        End If

        Dim serviceID As Integer = -1
        Dim selectQuery As String = "SELECT ServiceID FROM ServicesTable WHERE ServiceName = @ServiceName"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@ServiceName", serviceName)

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        serviceID = Convert.ToInt32(result)
                    End If
                End Using
            Catch ex As Exception
                Throw New Exception("Error retrieving Base Service ID for: " & serviceName & vbCrLf & "Details: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using

        If serviceID = -1 Then
            Throw New Exception("Base Service '" & serviceName & "' ID could not be found. Check ServicesTable data.")
        End If

        Return serviceID
    End Function
    ' --- ADDON SERVICE ID LOOKUP ---
    Public Shared Function GetAddonIdByName(addonName As String) As Integer?
        If String.IsNullOrWhiteSpace(addonName) OrElse addonName.Equals("None", StringComparison.OrdinalIgnoreCase) Then
            Return Nothing
        End If
        Dim addonID As Integer? = Nothing
        Dim selectQuery As String = "SELECT ServiceID FROM ServicesTable WHERE ServiceName = @AddonName"
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@AddonName", addonName)

                    Dim result = cmd.ExecuteScalar()

                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        addonID = Convert.ToInt32(result)
                    End If
                End Using
            Catch ex As Exception
                Throw New Exception("Error retrieving Addon Service ID for: " & addonName & vbCrLf & "Details: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
        Return addonID
    End Function
    Public Shared Function ViewSales() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()

                ' Step 1: Subquery to aggregate Service NAMES for each SalesID
                ' We join SalesServiceTable to ServicesTable TWICE (once for the base service, once for the addon)
                ' Then we aggregate the resulting names into comma-separated strings.
                Dim aggregateServiceNamesQuery =
            "SELECT " &
                "sst.SalesID, " &
                "STRING_AGG(sv_base.ServiceName, ', ') AS AllServices, " &
                "STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "FROM SalesServiceTable sst " &
            "INNER JOIN ServicesTable sv_base ON sst.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON sst.AddonServiceID = sv_addon.ServiceID " &
            "GROUP BY sst.SalesID"

                ' Step 2: Final query joins SalesHistoryTable to the aggregated names
                Dim selectQuery =
            "SELECT " &
                "s.SalesID, " &
                "c.Name + ' ' + c.LastName AS CustomerName, " &
                "agg.AllServices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "s.SaleDate, " &
                "s.PaymentMethod, " &
                "s.ReferenceID, " &
                "s.TotalPrice " &
            "FROM RegularSaleTable s " &
            "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
            "LEFT JOIN (" & aggregateServiceNamesQuery & ") agg ON s.SalesID = agg.SalesID " &
            "ORDER BY s.SalesID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            Try
                con.Open()
                Dim selectQuery = "SELECT CustomerID FROM CustomersTable WHERE Name + ' ' + LastName = @Name"
                Dim reversedQuery = "SELECT CustomerID FROM CustomersTable WHERE LastName + ', ' + Name = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        customerID = CType(result, Integer)
                    End If
                End Using
                If customerID = 0 Then
                    Using cmd As New SqlCommand(reversedQuery, con)
                        cmd.Parameters.AddWithValue("@Name", customerName)
                        Dim result = cmd.ExecuteScalar()
                        If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                            customerID = CType(result, Integer)
                        End If
                    End Using
                End If

            Catch ex As Exception
                MessageBox.Show("Error retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Return customerID
        End Using
    End Function

    Public Function GetServiceID(serviceName As String) As SalesService
        Using con As New SqlConnection(constr)
            Dim details As New SalesService()
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, Price FROM ServicesTable WHERE ServiceName = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", serviceName)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        details.ServiceID = reader.GetInt32(0)
                        details.Price = reader.GetDecimal(1)
                    End If
                End Using
            End Using
            Return details
        End Using
    End Function
    Public Shared Function GetSaleLineItems(saleId As Integer, constr As String) As List(Of ServiceLineItem)
        Dim items As New List(Of ServiceLineItem)()

        ' This query retrieves the subtotal, base service name, and addon service name 
        ' for a given SaleID by joining SalesServiceTable with ServicesTable twice.
        Dim sql As String = "
        SELECT 
            SST.Subtotal,
            ST_BASE.ServiceName AS BaseServiceName,
            ST_ADDON.ServiceName AS AddonServiceName
        FROM 
            SalesServiceTable AS SST
        LEFT JOIN 
            ServicesTable AS ST_BASE ON SST.ServiceID = ST_BASE.ServiceID
        LEFT JOIN 
            ServicesTable AS ST_ADDON ON SST.AddonServiceID = ST_ADDON.ServiceID
        WHERE 
            SST.SalesID = @SaleID
        ORDER BY 
            SST.SalesServiceID ASC;
    "

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@SaleID", saleId)

                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim subtotal As Decimal = Convert.ToDecimal(reader("Subtotal"))
                        Dim baseServiceName As String = reader("BaseServiceName").ToString()

                        ' Safely retrieve AddonServiceName, converting DBNull to an empty string.
                        Dim addonServiceName As String = If(reader("AddonServiceName") Is DBNull.Value, "", reader("AddonServiceName").ToString())

                        Dim lineItemName As String = ""

                        ' Check if a base service exists for this line item.
                        If Not String.IsNullOrEmpty(baseServiceName) Then
                            ' Start with the Base Service Name
                            lineItemName = baseServiceName

                            ' Append the Add-on Service Name if it exists
                            If Not String.IsNullOrEmpty(addonServiceName) Then
                                lineItemName &= " + " & addonServiceName
                            End If
                            items.Add(New ServiceLineItem With {
                            .Name = lineItemName,
                            .Price = subtotal
                        })
                        End If
                    End While
                    reader.Close()

                Catch ex As Exception
                    MessageBox.Show("Error retrieving sale line items: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return items
    End Function
    Public Shared Function GetSalesServiceList(salesID As Integer) As List(Of SalesService)
        Dim serviceList As New List(Of SalesService)
        Dim selectQuery As String = "SELECT " &
                                "SST.SalesServiceID, " &
                                "S_Base.ServiceName AS Service, " &
                                "ISNULL(S_Addon.ServiceName, 'None') AS Addon, " &
                                "SST.Subtotal AS ServicePrice, " &
                                "SST.ServiceID, " &
                                "SST.AddonServiceID " &
                                "FROM SalesServiceTable SST " &
                                "INNER JOIN ServicesTable S_Base ON SST.ServiceID = S_Base.ServiceID " &
                                "LEFT JOIN ServicesTable S_Addon ON SST.AddonServiceID = S_Addon.ServiceID " &
                                "WHERE SST.SalesID = @SalesID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@SalesID", salesID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim item As New SalesService() With {
                            .Service = reader.GetString(reader.GetOrdinal("Service")),
                            .Addon = reader.GetString(reader.GetOrdinal("Addon")),
                            .ServicePrice = reader.GetDecimal(reader.GetOrdinal("ServicePrice"))
                        }
                            serviceList.Add(item)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error when loading sale services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using


        Return serviceList
    End Function
    Public Sub PopulateBaseServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving base services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Public Sub PopulateAddonServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving addon services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Public Sub PopulateCustomerNames(textBoxCustomerName As TextBox)
        Dim customerNames As New AutoCompleteStringCollection()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name, LastName FROM CustomersTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) AndAlso Not reader.IsDBNull(1) Then
                            Dim firstName As String = reader.GetString(0).Trim()
                            Dim lastName As String = reader.GetString(1).Trim()

                            ' 1. Add the standard "First Last" format (e.g., "JM De Torres")
                            customerNames.Add(firstName & " " & lastName)

                            ' 2. Add the reverse "Last, First" format (e.g., "De Torres, JM") - THE KEY FIX
                            ' When the user types "De Torres," this guarantees a prefix match.
                            customerNames.Add(lastName & ", " & firstName)

                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        textBoxCustomerName.AutoCompleteCustomSource = customerNames
    End Sub
    Public Sub PopulatePaymentMethod(comboBoxPaymentMethod As ComboBox)
        comboBoxPaymentMethod.Items.Add("Cash")
        comboBoxPaymentMethod.Items.Add("Gcash")
        comboBoxPaymentMethod.Items.Add("Cheque")
        comboBoxPaymentMethod.SelectedIndex = 0
    End Sub

End Class
