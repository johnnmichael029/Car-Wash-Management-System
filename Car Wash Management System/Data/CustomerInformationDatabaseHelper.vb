Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class CustomerInformationDatabaseHelper
    Shared constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    'Public Sub DeleteCustomer(dataGridView As DataGridView)
    '    If dataGridView.SelectedRows.Count = 0 Then
    '        MessageBox.Show("Please select a customer in table row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If
    '    Dim customerID As Integer = Convert.ToInt32(dataGridView.CurrentRow.Cells("CustomerID").Value)

    '    Dim DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
    '    If DialogResult = DialogResult.Yes Then
    '        Using con As New SqlConnection(constr)
    '            con.Open()
    '            Dim transaction As SqlTransaction = con.BeginTransaction()
    '            Try
    '                Dim deleteVehiclesQuery = "DELETE FROM CustomerVehicleTable WHERE CustomerID = @CustomerID"
    '                Using cmd As New SqlCommand(deleteVehiclesQuery, con, transaction)
    '                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
    '                    cmd.ExecuteNonQuery()
    '                End Using

    '                Dim deleteCustomerQuery = "DELETE FROM CustomersTable WHERE CustomerID = @CustomerID"
    '                Using cmd As New SqlCommand(deleteCustomerQuery, con, transaction)
    '                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
    '                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

    '                    If rowsAffected > 0 Then
    '                        transaction.Commit()
    '                        Carwash.NotificationLabel.Text = "Customer Information Deleted!"
    '                        Carwash.ShowNotification()
    '                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                        ViewCustomer()
    '                    Else
    '                        transaction.Rollback()
    '                        MessageBox.Show("Customer record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    End If
    '                End Using
    '            Catch ex As Exception
    '                transaction.Rollback()
    '                MessageBox.Show("Error deleting customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End Try
    '        End Using
    '    End If
    'End Sub

    Public Sub AddCustomer(firstName As String, lastName As String, number As String, email As String, address As String, barangay As String, VehicleList As List(Of VehicleService))
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Dim newCustomerID As Integer = 0

            Try
                Dim insertCustomerQuery As String = "INSERT INTO CustomersTable (Name, LastName, PhoneNumber, Email, Address, Barangay, RegistrationDate) VALUES (@Name, @LastName, @PhoneNumber, @Email, @Address, @Barangay, @RegistrationDate); SELECT SCOPE_IDENTITY();"

                Using cmd As New SqlCommand(insertCustomerQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@Name", firstName)
                    cmd.Parameters.AddWithValue("@LastName", lastName)
                    cmd.Parameters.AddWithValue("@PhoneNumber", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    If String.IsNullOrEmpty(address) Then
                        cmd.Parameters.AddWithValue("@Address", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@Address", address)
                    End If
                    If String.IsNullOrEmpty(barangay) Then
                        cmd.Parameters.AddWithValue("@Barangay", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@Barangay", barangay)
                    End If

                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        newCustomerID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Failed to retrieve the new CustomerID after insertion.")
                    End If
                End Using
                If VehicleList IsNot Nothing AndAlso VehicleList.Count > 0 Then

                    Dim insertVehicleQuery As String = "INSERT INTO CustomerVehicleTable (CustomerID, PlateNumber, VehicleType) VALUES (@CustomerID, @PlateNumber, @VehicleType)"

                    For Each vehicle In VehicleList
                        Using vehicleCmd As New SqlCommand(insertVehicleQuery, con, transaction)
                            vehicleCmd.Parameters.AddWithValue("@CustomerID", newCustomerID)
                            vehicleCmd.Parameters.AddWithValue("@PlateNumber", vehicle.PlateNumber)
                            vehicleCmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType)
                            vehicleCmd.ExecuteNonQuery()
                        End Using
                    Next
                End If
                transaction.Commit()

                Carwash.NotificationLabel.Text = "New Customer and all " & VehicleList.Count.ToString() & " Vehicles Added Successfully (ID: " & newCustomerID.ToString() & ")"
                Carwash.ShowNotification()
                VehicleList.Clear()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error adding customer and vehicles. Database changes were canceled: " & ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Using
    End Sub

    Public Sub UpdateCustomer(customerID As String, name As String, lastName As String, number As String, email As String, address As String, barangay As String, vehicleList As List(Of VehicleService))
        Dim iCustomerID As Integer = CInt(customerID)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' 1. Update Customer's main information
                Dim updateCustomerQuery = "UPDATE CustomersTable SET Name = @Name, LastName= @LastName, PhoneNumber = @Phone, Email = @Email, Address = @Address, Barangay = @Barangay WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(updateCustomerQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@LastName", lastName)
                    cmd.Parameters.AddWithValue("@Phone", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@Barangay", barangay)
                    cmd.Parameters.AddWithValue("@CustomerID", iCustomerID)
                    cmd.ExecuteNonQuery()
                End Using

                ' 2. Handle Vehicle List: Delete all old vehicles first
                Dim deleteVehiclesQuery = "DELETE FROM CustomerVehicleTable WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(deleteVehiclesQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@CustomerID", iCustomerID)
                    cmd.ExecuteNonQuery()
                End Using

                ' 3. Insert all vehicles from the current VehicleList (the updated list)
                If vehicleList IsNot Nothing AndAlso vehicleList.Count > 0 Then
                    Dim insertVehicleQuery As String = "INSERT INTO CustomerVehicleTable (CustomerID, PlateNumber, VehicleType) VALUES (@CustomerID, @PlateNumber, @VehicleType)"

                    For Each vehicle In vehicleList
                        Using vehicleCmd As New SqlCommand(insertVehicleQuery, con, transaction)
                            vehicleCmd.Parameters.AddWithValue("@CustomerID", iCustomerID)
                            vehicleCmd.Parameters.AddWithValue("@PlateNumber", vehicle.PlateNumber)
                            vehicleCmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType)
                            vehicleCmd.ExecuteNonQuery()
                        End Using
                    Next
                Else
                    MessageBox.Show($"No vehicles to update for this customer. Customer ID is: {iCustomerID} Vehicle count is: {vehicleList.Count}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                transaction.Commit()
                Carwash.NotificationLabel.Text = "Customer Information and Vehicles Updated"
                Carwash.ShowNotification()
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error updating customer: " & ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Shared Function ViewCustomer() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()

                ' Subquery to aggregate all Plate Numbers and Vehicle Types for each customer
                Dim aggregateVehiclesQuery =
                "SELECT " &
                    "CustomerID, " &
                    "STRING_AGG(PlateNumber, ', ') AS AllPlateNumbers, " &
                    "STRING_AGG(VehicleType, ', ') AS AllVehicleTypes " &
                "FROM CustomerVehicleTable " &
                "GROUP BY CustomerID"

                ' Final query joins the main customer table with the aggregated vehicle data
                Dim selectQuery =
                "SELECT " &
                    "c.CustomerID, c.Name, c.LastName, c.PhoneNumber, c.Email, c.Address, c.Barangay, c.RegistrationDate AS RegisteredDate, " &
                    "v.AllPlateNumbers AS VehiclePlateNumber, " &
                    "v.AllVehicleTypes AS RegisteredVehicleType " &
                "FROM CustomersTable c " &
                "LEFT JOIN (" & aggregateVehiclesQuery & ") v ON c.CustomerID = v.CustomerID " &
                "ORDER BY CustomerID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

    Public Function GetCustomerTransactionHistory(customerID As String) As DataTable

        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery =
                 "SELECT " &
                "s.SalesID, " &
                "sv_base.ServiceName AS Service, " &
                "sv_addon.ServiceName AS AddonService, " &
                "s.SaleDate, " &
                "s.PaymentMethod, " &
                "s.ReferenceID, " &
                "s.TotalPrice " &
            "FROM SalesHistoryTable s " &
            "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
            "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID " &
            "WHERE s.CustomerID = @CustomerID " &
            "ORDER BY s.SalesID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing customer transaction history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

    Public Shared Function GetCustomerVehicles(customerID As Integer) As List(Of VehicleService)
        Dim vehicles As New List(Of VehicleService)
        Dim selectQuery As String = "SELECT PlateNumber, VehicleType FROM CustomerVehicleTable WHERE CustomerID = @CustomerID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Create a new VehicleService object for each row found
                            Dim vehicle As New VehicleService() With {
                                .PlateNumber = reader("PlateNumber").ToString(),
                                .VehicleType = reader("VehicleType").ToString()
                            }
                            vehicles.Add(vehicle)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error when loading vehicles: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return vehicles
    End Function

    Public Function GetCustomerSalesCount(customerID As String) As Integer
        Dim salesCount As Integer = 0

        ' Assuming constr is defined globally or passed in
        Using con As New SqlConnection(constr)
            Try
                con.Open()

                Dim selectQuery =
            "SELECT COUNT(s.SalesID) AS TotalSalesCount " &
            "FROM SalesHistoryTable s " &
            "WHERE s.CustomerID = @CustomerID"

                Using cmd As New SqlCommand(selectQuery, con)
                    ' 1. FIX: Add the required parameter binding
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)

                    ' Use ExecuteScalar to retrieve a single value (the count)
                    Dim result = cmd.ExecuteScalar()

                    ' 2. FIX: Convert the result to an Integer (CInt) since COUNT returns an integer.
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        salesCount = CInt(result)
                    End If

                End Using
            Catch ex As Exception
                MessageBox.Show("Error getting customer sales count: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using

        Return salesCount
    End Function

    Public Function GetTotalSalesAmountByCustomer(customerID As String) As Decimal
        Dim totalAmount As Decimal = 0D.ToString("N2")
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery =
            "SELECT SUM(s.TotalPrice) AS TotalSalesAmount " &
            "FROM SalesHistoryTable s " &
            "WHERE s.CustomerID = @CustomerID"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        totalAmount = Convert.ToDecimal(result)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error getting total sales amount by customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return totalAmount
    End Function

    Public Function GetCustomerContractStatus(customerID As Integer) As String
        Dim contractStatus As String = "None"
        Dim query As String = "SELECT TOP 1 ContractStatus FROM ContractsTable WHERE CustomerID = @CustomerID AND ContractStatus = 'Active'"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not Convert.IsDBNull(result) Then
                        contractStatus = Convert.ToString(result)
                    End If

                Catch ex As Exception
                    ' Log the error or show a message box in a real application
                    Console.WriteLine("Error checking contract status: " & ex.Message)
                End Try
            End Using
        End Using

        Return contractStatus
    End Function

    Public Shared Function GetSearchCustomerResults(searchTerm As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim aggregateVehiclesQuery =
                "SELECT " &
                    "CustomerID, " &
                    "STRING_AGG(PlateNumber, ', ') AS AllPlateNumbers, " &
                    "STRING_AGG(VehicleType, ', ') AS AllVehicleTypes " &
                "FROM CustomerVehicleTable " &
                "GROUP BY CustomerID"
                Dim selectQuery =
                "SELECT " &
                    "c.CustomerID, c.Name, c.LastName, c.PhoneNumber, c.Email, c.Address, c.Barangay, c.RegistrationDate AS RegisteredDate, " &
                    "v.AllPlateNumbers AS VehiclePlateNumber, " &
                    "v.AllVehicleTypes AS RegisteredVehicleType " &
                "FROM CustomersTable c " &
                "LEFT JOIN (" & aggregateVehiclesQuery & ") v ON c.CustomerID = v.CustomerID " &
                "WHERE c.Name LIKE @SearchTerm 
                OR c.LastName LIKE @SearchTerm 
                OR c.customerID LIKE @SearchTerm
                ORDER BY c.CustomerID DESC"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & searchTerm & "%")
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error searching customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function
End Class