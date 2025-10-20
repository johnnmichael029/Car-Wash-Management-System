Imports System.Security.Cryptography.Xml
Imports Microsoft.Data.SqlClient

Public Class ContractsDatabaseHelper
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Sub AddContract(customerID As Integer, allSaleItems As List(Of ContractsService), endDate As Date?, billingFrequency As String, paymentMethod As String, referenceID As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' 1. Fix SQL Syntax and retrieve the new ID using SCOPE_IDENTITY()
                ' NOTE: Missing comma between @ReferenceID and @Price in the original SQL
                Dim insertContractQuery As String = "INSERT INTO ContractsTable (CustomerID, StartDate, EndDate, BillingFrequency, PaymentMethod, ReferenceID, Price, ContractStatus) " &
                                            "VALUES (@CustomerID, @StartDate, @EndDate, @BillingFrequency, @PaymentMethod, @ReferenceID, @Price, @ContractStatus);" &
                                            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                Dim newContractID As Integer = 0
                Using cmd As New SqlCommand(insertContractQuery, con, transaction) ' <-- FIX 1: Added transaction to cmd
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Now)

                    ' Handle the nullable EndDate parameter
                    If endDate.HasValue Then
                        cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                    Else
                        cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                    End If
                    cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    cmd.Parameters.AddWithValue("@ReferenceID", referenceID) ' Assuming ReferenceID is nullable
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)

                    ' ExecuteScalar returns the ID of the newly inserted row (SCOPE_IDENTITY())
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        newContractID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Failed to retrieve the new Contract ID.")
                    End If
                End Using

                ' Ensure the ID was retrieved before proceeding to insert services
                If newContractID = 0 Then
                    Throw New Exception("Contract was inserted, but the new ID could not be retrieved.")
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
    Public Function ViewContracts() As DataTable
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
                "c.Name AS CustomerName, " &
                "agg.Allservices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "b.StartDate, " &
                "b.EndDate, " &
                "b.BillingFrequency," &
                "b.PaymentMethod, " &
                "b.ReferenceID, " &
                "b.Price, " &
                "b.ContractStatus " &
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
    Public Sub UpdateContract(contractID As Integer, customerID As Integer, serviceID As Integer, addonServiceID As Integer?, startDate As Date, endDate As Date?, billingFrequency As String, paymentMethod As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to update a contract.
            Dim updateQuery As String = "UPDATE ContractsTable SET CustomerID = @CustomerID, ServiceID = @ServiceID, AddonServiceID = @AddonServiceID, StartDate = @StartDate, EndDate = @EndDate, BillingFrequency = @BillingFrequency, PaymentMethod = @PaymentMethod, Price = @Price, ContractStatus = @ContractStatus WHERE ContractID = @ContractID"
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddWithValue("@ContractID", contractID)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                cmd.Parameters.AddWithValue("@StartDate", startDate)

                ' Handle the nullable EndDate parameter
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                Else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                End If
                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Deletes an existing billing contract from the database.
    ''' </summary>
    'Public Sub DeleteContract(contractID As String)
    '    If String.IsNullOrEmpty(contractID) Then
    '        MessageBox.Show("Please select contract from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If
    '    Dim DialogResult = MessageBox.Show("Are you sure you want to delete this contract?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '    If DialogResult = DialogResult.Yes Then

    '        Using con As New SqlConnection(constr)
    '            Try
    '                con.Open()
    '                ' SQL query to delete a contract.
    '                Dim deleteQuery As String = "DELETE FROM ContractsTable WHERE ContractID = @ContractID"
    '                Using cmd As New SqlCommand(deleteQuery, con)
    '                    cmd.Parameters.AddWithValue("@ContractID", contractID)
    '                    cmd.ExecuteNonQuery()
    '                    MessageBox.Show("Contract deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End Using
    '            Catch ex As Exception
    '                MessageBox.Show("An error occurred while deleting contract" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Finally
    '                con.Close()
    '            End Try
    '        End Using
    '    End If
    'End Sub

    ''' <summary>
    ''' Gets all customer names from the database.
    ''' </summary>
    Public Function GetAllCustomerNames() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable ORDER BY Name"
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Gets a customer ID by name.
    ''' </summary>
    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            con.Open()
            Dim selectQuery As String = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", customerName)
                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                    customerID = CType(result, Integer)
                End If
            End Using
            Return customerID
        End Using
    End Function

    ''' <summary>
    ''' Gets service details (ID and Price) by service name.
    ''' </summary>
    Public Function GetServiceDetails(serviceName As String) As ContractsService
        Using con As New SqlConnection(constr)
            Dim details As New ContractsService()
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

    ''' <summary>
    ''' Gets all non-addon services.
    ''' </summary>
    Public Function GetBaseServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Gets all addon services.
    ''' </summary>
    Public Function GetAddonServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

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

End Class
