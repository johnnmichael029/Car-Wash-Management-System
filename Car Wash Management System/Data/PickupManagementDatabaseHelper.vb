Imports System.Diagnostics.Contracts
Imports System.Security.Cryptography.Xml
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Microsoft.Data.SqlClient
Public Class PickupManagementDatabaseHelper
    Private Shared constr As String

    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Shared Function ViewPickupData() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                ' Then we aggregate the resulting names into comma-separated strings.
                Dim aggregateServiceNamesQuery =
            "SELECT " &
                "pst.PickupID, " &
                "STRING_AGG(sv_base.ServiceName, ', ') AS AllServices, " &
                "STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "FROM PickupServiceTable pst " &
            "INNER JOIN ServicesTable sv_base ON pst.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON pst.AddonServiceID = sv_addon.ServiceID " &
            "GROUP BY pst.PickupID"

                ' Step 2: Final query joins SalesHistoryTable to the aggregated names
                Dim selectQuery =
            "SELECT " &
                "p.PickupID, " &
                "c.Name + ' ' + c.LastName AS CustomerName, " &
                "agg.AllServices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "p.PickupDateTime, " &
                "p.PickupAddress, " &
                "p.PaymentMethod, " &
                "p.ReferenceID, " &
                "p.Price, " &
                "p.PickupStatus, " &
                "p.Detailer, " &
                "p.Notes " &
            "FROM PickupTable p " &
            "INNER JOIN CustomersTable c ON p.CustomerID = c.CustomerID " &
            "LEFT JOIN (" & aggregateServiceNamesQuery & ") agg ON p.PickupID = agg.PickupID " &
            "ORDER BY p.PickupID DESC"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred while retrieving pickup data: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

    Public Sub AddPickup(customerID As Integer, allSaleItems As List(Of PickupService), pickupDateTime As DateTime, pickupAddress As String, paymentMethod As String, referenceID As String, cheque As String, totalPrice As Decimal, pickupStatus As String, detailer As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                Dim newSalesID As Integer
                Dim insertHistoryQuery = "INSERT INTO PickupTable (CustomerID, PickupDateTime, PickupAddress, PaymentMethod, ReferenceID, Price, PickupStatus, Detailer, Notes ) VALUES (@CustomerID, @PickupDateTime, @PickupAddress, @PaymentMethod, @ReferenceID, @Price, @PickupStatus, @Detailer, @Notes); SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(insertHistoryQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@PickupDateTime", pickupDateTime)
                    cmd.Parameters.AddWithValue("@PickupAddress", pickupAddress)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", totalPrice)
                    cmd.Parameters.AddWithValue("@PickupStatus", pickupStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)
                    cmd.Parameters.AddWithValue("@Notes", notes)
                    newSalesID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                Dim insertServiceQuery = "INSERT INTO PickupServiceTable (PickupID, ServiceID, AddonServiceID, Subtotal) VALUES (@PickupID, @ServiceID, @AddonServiceID, @Subtotal)"

                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@PickupID", newSalesID)
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
                Carwash.NotificationLabel.Text = "Pickup Added"
                Carwash.ShowNotification()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Overloads Sub UpdatePickup(pickupID As Integer, customerID As Integer, allSaleItems As List(Of PickupService), pickupDateTime As DateTime, pickupAddress As String, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, pickupStatus As String, detailer As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' SQL query to update a contract.
                Dim updateQuery As String = "UPDATE PickupTable SET CustomerID = @CustomerID, PickupDateTime = @PickupDateTime, PickupAddress = @PickupAddress, PaymentMethod = @PaymentMethod, ReferenceID = @ReferenceID, Price = @Price, PickupStatus = @PickupStatus, Detailer = @Detailer, Notes = @Notes WHERE PickupID = @PickupID"
                Using cmd As New SqlCommand(updateQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@PickupID", pickupID)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@PickupDateTime", pickupDateTime)
                    cmd.Parameters.AddWithValue("@PickupAddress", pickupAddress)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@PickupStatus", pickupStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)
                    cmd.Parameters.AddWithValue("@Notes", notes)
                    cmd.ExecuteNonQuery()
                End Using
                Dim deleteServicesQuery = "DELETE FROM PickupServiceTable WHERE PickupID = @PickupID"
                Using cmdDelete As New SqlCommand(deleteServicesQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@PickupID", pickupID)
                    cmdDelete.ExecuteNonQuery()
                End Using
                Dim deleteSalesServicesFromHistoryQuery = "DELETE FROM SalesHistoryTable WHERE PickupID = @PickupID"
                Using cmdDelete As New SqlCommand(deleteSalesServicesFromHistoryQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@PickupID", pickupID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                Dim insertSalesHistoryQuery = "INSERT INTO SalesHistoryTable (CustomerID, SaleDate, PaymentMethod, ReferenceID, PickupID, ServiceID, AddonServiceID, TotalPrice, Detailer, Form) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @ReferenceID, @PickupID, @ServiceID, @AddonServiceID, @TotalPrice, @Detailer, @Form)"
                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdHistory As New SqlCommand(insertSalesHistoryQuery, con, transaction)
                        cmdHistory.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdHistory.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                        cmdHistory.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                        If paymentMethod = "Cheque" Then
                            cmdHistory.Parameters.AddWithValue("@ReferenceID", cheque)
                        Else
                            cmdHistory.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                        End If
                        cmdHistory.Parameters.AddWithValue("@PickupID", pickupID)
                        cmdHistory.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdHistory.Parameters.AddWithValue("@TotalPrice", item.ServicePrice)
                        cmdHistory.Parameters.AddWithValue("@Detailer", detailer)
                        cmdHistory.Parameters.AddWithValue("@Form", "Pickup-Sale")
                        cmdHistory.ExecuteNonQuery()
                    End Using
                Next

                Dim insertServiceQuery = "INSERT INTO PickupServiceTable (PickupID, ServiceID, AddonServiceID, Subtotal) VALUES (@PickupID, @ServiceID, @AddonServiceID, @Subtotal)"
                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@PickupID", pickupID)
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

    Public Overloads Sub UpdatePickup(pickupID As Integer, pickupAddress As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                ' SQL query to update a contract.
                Dim updateQuery As String = "UPDATE PickupTable SET PickupAddress = @PickupAddress WHERE PickupID = @PickupID"
                Using cmd As New SqlCommand(updateQuery, con)
                    cmd.Parameters.AddWithValue("@PickupID", pickupID)
                    cmd.Parameters.AddWithValue("@PickupAddress", pickupAddress)
                    cmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating pickup status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    ' Get list of services for a specific pickup
    Public Shared Function GetSalesServiceList(pickupID As Integer) As List(Of PickupService)
        Dim serviceList As New List(Of PickupService)
        Dim selectQuery As String = "SELECT " &
                                "PST.PickupServiceID, " &
                                "S_Base.ServiceName AS Service, " &
                                "ISNULL(S_Addon.ServiceName, 'None') AS Addon, " &
                                "PST.Subtotal AS ServicePrice, " &
                                "PST.ServiceID, " &
                                "PST.AddonServiceID " &
                                "FROM PickupServiceTable PST " &
                                "INNER JOIN ServicesTable S_Base ON PST.ServiceID = S_Base.ServiceID " &
                                "LEFT JOIN ServicesTable S_Addon ON PST.AddonServiceID = S_Addon.ServiceID " &
                                "WHERE PST.PickupID = @PickupID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@PickupID", pickupID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim item As New PickupService() With {
                            .Service = reader.GetString(reader.GetOrdinal("Service")),
                            .Addon = reader.GetString(reader.GetOrdinal("Addon")),
                            .ServicePrice = reader.GetDecimal(reader.GetOrdinal("ServicePrice"))
                        }
                            serviceList.Add(item)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error when loading pikcup services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return serviceList
    End Function

    Public Shared Function GetSaleLineItems(pickupID As Integer, constr As String) As List(Of ServiceLineItem)
        Dim items As New List(Of ServiceLineItem)()

        ' This query retrieves the subtotal, base service name, and addon service name 
        ' for a given SaleID by joining SalesServiceTable with ServicesTable twice.
        Dim sql As String = "
        SELECT 
            PST.Subtotal,
            ST_BASE.ServiceName AS BaseServiceName,
            ST_ADDON.ServiceName AS AddonServiceName
        FROM 
            PickupServiceTable AS PST
        LEFT JOIN 
            ServicesTable AS ST_BASE ON PST.ServiceID = ST_BASE.ServiceID
        LEFT JOIN 
            ServicesTable AS ST_ADDON ON PST.AddonServiceID = ST_ADDON.ServiceID
        WHERE 
            PST.PickupID = @PickupID
        ORDER BY 
            PST.PickupServiceID ASC;
    "

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@PickupID", pickupID)

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

    Public Shared Function SearchInPuckup(searchTerm As String) As DataTable
        Dim dt As New DataTable()
        ' Ensure constr is defined and accessible here
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim aggregateServicesQuery =
            "WITH AggregatedServices AS ( " &
            "   SELECT " &
            "       pst.PickupID, " &
            "       STRING_AGG(sv_base.ServiceName, ', ') AS AllBaseServices, " &
            "       STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "   FROM " &
            "       PickupServiceTable pst " &
            "       INNER JOIN ServicesTable sv_base ON pst.ServiceID = sv_base.ServiceID " &
            "       LEFT JOIN ServicesTable sv_addon ON pst.AddonServiceID = sv_addon.ServiceID " &
            "   GROUP BY pst.PickupID " &
            ") "

                Dim selectQuery =
            aggregateServicesQuery &
            "SELECT " &
                "pt.PickupID, " &
                "ISNULL(c.Name, '') + ' ' + ISNULL(c.LastName, '') AS CustomerName, " &
                "aggs.AllBaseServices AS BaseService, " &
                "aggs.AllAddonServices AS AddonService, " &
                "pt.PickupDateTime, " &
                "pt.PickupAddress, " &
                "pt.PaymentMethod, " &
                "pt.ReferenceID, " &
                "pt.Price, " &
                "pt.PickupStatus, " &
                "pt.Detailer, " &
                "pt.Notes " &
            "FROM " &
                "PickupTable pt " &
                "INNER JOIN CustomersTable c ON pt.CustomerID = c.CustomerID " &
                "INNER JOIN AggregatedServices aggs ON pt.PickupID = aggs.PickupID " &
            "WHERE " &
                "pt.PickupID LIKE @SearchTerm OR " &
                "c.Name LIKE @SearchTerm OR " &
                "c.LastName LIKE @SearchTerm OR " &
                "c.Name + ' ' + c.LastName LIKE @SearchTerm OR " &
                "aggs.AllBaseServices LIKE @SearchTerm OR " &
                "aggs.AllAddonServices LIKE @SearchTerm OR " &
                "pt.PaymentMethod LIKE @SearchTerm OR " &
                "pt.Detailer LIKE @SearchTerm " &
            "ORDER BY pt.PickupID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & searchTerm & "%")
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error searching regular sales: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function
End Class
