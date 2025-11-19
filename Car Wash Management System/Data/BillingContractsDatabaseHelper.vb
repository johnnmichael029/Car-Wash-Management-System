Imports System.Security.Cryptography.Xml
Imports System.Transactions
Imports Microsoft.Data.SqlClient

Public Class ContractsDatabaseHelper
    Private Shared constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Sub AddContract(customerID As Integer, allSaleItems As List(Of ContractsService), endDate As Date, billingFrequency As String, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, contractStatus As String, detailer As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' 1. Fix SQL Syntax and retrieve the new ID using SCOPE_IDENTITY()
                ' NOTE: Missing comma between @ReferenceID and @Price in the original SQL
                Dim insertContractQuery As String = "INSERT INTO ContractsTable (CustomerID, StartDate, EndDate, BillingFrequency, PaymentMethod, ReferenceID, Price, ContractStatus, Detailer) " &
                                            "VALUES (@CustomerID, @StartDate, @EndDate, @BillingFrequency, @PaymentMethod, @ReferenceID, @Price, @ContractStatus, @Detailer);" &
                                            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                Dim newContractID As Integer = 0
                Using cmd As New SqlCommand(insertContractQuery, con, transaction) ' <-- FIX 1: Added transaction to cmd
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@EndDate", endDate)
                    ' Handle the nullable EndDate parameter
                    cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)

                    ' ExecuteScalar returns the ID of the newly inserted row (SCOPE_IDENTITY())
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        newContractID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Failed To retrieve the New Contract ID.")
                    End If
                End Using

                ' Ensure the ID was retrieved before proceeding to insert services
                If newContractID = 0 Then
                    Throw New Exception("Contract was inserted, but the New ID could Not be retrieved.")
                End If

                Dim insertServiceQuery = "INSERT INTO ContractServiceTable (ContractID, ServiceID, AddonServiceID, Subtotal) VALUES (@ContractID, @ServiceID, @AddonServiceID, @Subtotal)"

                For Each item As ContractsService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)

                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@ContractID", newContractID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)

                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", CType(DBNull.Value, Object))
                        End If

                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)
                        cmdService.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit() ' Commit the entire operation if successful

            Catch ex As Exception
                ' Only rollback if the transaction object exists and is still active
                transaction?.Rollback()
                MessageBox.Show("Error adding appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    ''' <summary>
    ''' Retrieves all billing contracts from the database and returns them as a DataTable.
    ''' </summary>
    Public Shared Function ViewContracts() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to select all contracts.
            Dim aggregateServiceNamesQuery =
            "SELECT " &
                "cst.ContractID, " &
                "STRING_AGG(sv_base.ServiceName, ', ') AS AllServices, " &
                "STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "FROM ContractServiceTable cst " &
            "INNER JOIN ServicesTable sv_base ON cst.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON cst.AddonServiceID = sv_addon.ServiceID " &
            "GROUP BY cst.ContractID"

            Dim selectQuery As String = "SELECT " &
                "b.ContractID, " &
                "c.Name + ' ' + c.LastName AS CustomerName, " &
                "agg.Allservices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "b.StartDate, " &
                "b.EndDate, " &
                "b.BillingFrequency," &
                "b.PaymentMethod, " &
                "b.ReferenceID, " &
                "b.Price, " &
                "b.ContractStatus, " &
                "b.Detailer " &
            "FROM ContractsTable b " &
            "INNER JOIN CustomersTable c ON b.CustomerID = c.CustomerID " &
            "LEFT JOIN (" & aggregateServiceNamesQuery & ") agg ON b.ContractID = agg.ContractID " &
            "ORDER BY b.ContractID DESC"





            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Updates an existing billing contract in the database.
    ''' </summary>
    Public Sub UpdateContract(contractID As Integer, customerID As Integer, allSaleItems As List(Of ContractsService), startDate As Date, endDate As Date?, billingFrequency As String, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, contractStatus As String, detailer As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' SQL query to update a contract.
                Dim updateQuery As String = "UPDATE ContractsTable SET CustomerID = @CustomerID, StartDate = @StartDate, EndDate = @EndDate, BillingFrequency = @BillingFrequency, PaymentMethod = @PaymentMethod, ReferenceID = @ReferenceID, Price = @Price, ContractStatus = @ContractStatus, Detailer = @Detailer WHERE ContractID = @ContractID"
                Using cmd As New SqlCommand(updateQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@ContractID", contractID)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@StartDate", startDate)

                    ' Handle the nullable EndDate parameter
                    If endDate.HasValue Then
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                    Else
                        cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)
                    cmd.ExecuteNonQuery()
                End Using
                Dim deleteServicesQuery = "DELETE FROM ContractServiceTable WHERE ContractID = @ContractID"
                Using cmdDelete As New SqlCommand(deleteServicesQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@ContractID", contractID)
                    cmdDelete.ExecuteNonQuery()
                End Using
                Dim deleteSalesServicesFromHistoryQuery = "DELETE FROM SalesHistoryTable WHERE ContractID = @ContractID"
                Using cmdDelete As New SqlCommand(deleteSalesServicesFromHistoryQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@ContractID", contractID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                Dim insertSalesHistoryQuery = "INSERT INTO SalesHistoryTable (CustomerID, SaleDate, PaymentMethod, ContractID, ServiceID, AddonServiceID, TotalPrice) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @ContractID, @ServiceID, @AddonServiceID, @TotalPrice)"
                For Each item As ContractsService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdHistory As New SqlCommand(insertSalesHistoryQuery, con, transaction)
                        cmdHistory.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdHistory.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                        cmdHistory.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                        cmdHistory.Parameters.AddWithValue("@ContractID", contractID)
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

                Dim insertServiceQuery = "INSERT INTO ContractServiceTable (ContractID, ServiceID, AddonServiceID, Subtotal) VALUES (@ContractID, @ServiceID, @AddonServiceID, @Subtotal)"
                For Each item As ContractsService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@ContractID", contractID)
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

    Public Shared Function GetSaleLineItems(appointmentID As Integer, constr As String) As List(Of ServiceLineItem)
        Dim items As New List(Of ServiceLineItem)()

        ' This query retrieves the subtotal, base service name, and addon service name 
        ' for a given SaleID by joining SalesServiceTable with ServicesTable twice.
        Dim sql As String = "
        SELECT 
            CST.Subtotal,
            ST_BASE.ServiceName AS BaseServiceName,
            ST_ADDON.ServiceName AS AddonServiceName
        FROM 
            ContractServiceTable AS CST
        LEFT JOIN 
            ServicesTable AS ST_BASE ON CST.ServiceID = ST_BASE.ServiceID
        LEFT JOIN 
            ServicesTable AS ST_ADDON ON CST.AddonServiceID = ST_ADDON.ServiceID
        WHERE 
            CST.ContractID = @ContractID
        ORDER BY 
            CST.ContractServiceID ASC;
    "

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@ContractID", appointmentID)

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

    Public Shared Function GetSalesServiceList(contractID As Integer) As List(Of ContractsService)
        Dim serviceList As New List(Of ContractsService)
        Dim selectQuery As String = "SELECT " &
                                "CST.ContractServiceID, " &
                                "S_Base.ServiceName AS Service, " &
                                "ISNULL(S_Addon.ServiceName, 'None') AS Addon, " &
                                "CST.Subtotal AS ServicePrice, " &
                                "CST.ServiceID, " &
                                "CST.AddonServiceID " &
                                "FROM ContractServiceTable CST " &
                                "INNER JOIN ServicesTable S_Base ON CST.ServiceID = S_Base.ServiceID " &
                                "LEFT JOIN ServicesTable S_Addon ON CST.AddonServiceID = S_Addon.ServiceID " &
                                "WHERE CST.ContractID = @ContractID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@ContractID", contractID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim item As New ContractsService() With {
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

    Public Function UpdateTheStatusOfContractWhenExpired() As Integer
        Dim rowsAffected As Integer = 0
        Dim query As String = "UPDATE ContractsTable SET ContractStatus = 'Expired' WHERE EndDate <= GETDATE() AND ContractStatus = 'Active'"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error updating expired contracts: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowsAffected = -1
                End Try
            End Using
        End Using
        Return rowsAffected
    End Function

    Public Shared Function SearchInContract(searchTerm As String) As DataTable
        Dim dt As New DataTable()
        ' Ensure constr is defined and accessible here
        Using con As New SqlConnection(constr)
            Try
                con.Open()

                ' --- 1. CTE: AGGREGATE SERVICES ---
                ' We join SalesServiceTable to ServicesTable twice to look up the names.
                ' Then we use STRING_AGG to combine all services (Base and Addon) linked to a single SalesID.
                Dim aggregateServicesQuery =
            "WITH AggregatedServices AS ( " &
            "   SELECT " &
            "       cst.ContractID, " &
            "       STRING_AGG(sv_base.ServiceName, ', ') AS AllBaseServices, " &
            "       STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "   FROM " &
            "       ContractServiceTable cst " &
            "       INNER JOIN ServicesTable sv_base ON cst.ServiceID = sv_base.ServiceID " &
            "       LEFT JOIN ServicesTable sv_addon ON cst.AddonServiceID = sv_addon.ServiceID " &
            "   GROUP BY cst.ContractID " &
            ") "

                ' --- 2. MAIN QUERY: SELECT AND JOIN ---
                ' Now we join RegularSaleTable to the aggregated data and the CustomersTable.
                Dim selectQuery =
            aggregateServicesQuery &
            "SELECT " &
                "ct.ContractID, " &
                "ISNULL(c.Name, '') + ' ' + ISNULL(c.LastName, '') AS CustomerName, " &
                "aggs.AllBaseServices AS BaseService, " &
                "aggs.AllAddonServices AS AddonService, " &
                "ct.StartDate, " &
                "ct.EndDate, " &
                "ct.BillingFrequency, " &
                "ct.PaymentMethod, " &
                "ct.ReferenceID, " &
                "ct.Price, " &
                "ct.ContractStatus, " &
                "ct.Detailer " &
            "FROM " &
                "ContractsTable ct " &
                "INNER JOIN CustomersTable c ON ct.CustomerID = c.CustomerID " &
                "INNER JOIN AggregatedServices aggs ON ct.ContractID = aggs.ContractID " &
            "WHERE " &
                "ct.ContractID LIKE @SearchTerm OR " &
                "c.Name LIKE @SearchTerm OR " &
                "c.LastName LIKE @SearchTerm OR " &
                "c.Name + ' ' + c.LastName LIKE @SearchTerm OR " &
                "aggs.AllBaseServices LIKE @SearchTerm OR " &
                "aggs.AllAddonServices LIKE @SearchTerm OR " &
                "ct.PaymentMethod LIKE @SearchTerm OR " &
                "ct.Detailer LIKE @SearchTerm " &
            "ORDER BY ct.ContractID DESC"

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
