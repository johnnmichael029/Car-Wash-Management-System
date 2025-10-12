Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class CustomerInformationDatabaseHelper
    ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Sub DeleteCustomer(dataGridView As DataGridView)
        If dataGridView.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer in table row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim customerID As Integer = Convert.ToInt32(dataGridView.CurrentRow.Cells("CustomerID").Value)

        Dim DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If DialogResult = DialogResult.Yes Then
            Using con As New SqlConnection(constr)
                Try
                    con.Open()
                    Dim deleteQuery = "DELETE FROM CustomersTable WHERE CustomerID = @CustomerID"
                    Using cmd As New SqlCommand(deleteQuery, con)
                        cmd.Parameters.AddWithValue("@CustomerID", customerID)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            Carwash.NotificationLabel.Text = "Customer Information Deleted!"
                            Carwash.ShowNotification()
                            MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ViewCustomer()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error deleting customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using

        End If
    End Sub
    Public Sub AddCustomer(name As String, number As String, email As String, address As String, VehicleList As List(Of VehicleService))
        Using con As New SqlConnection(constr)
            con.Open()

            ' Declare the Transaction object
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Dim newCustomerID As Integer = 0

            Try
                ' --- 1. INSERT CUSTOMER AND GET NEW ID ---
                ' We use the transaction object in the SqlCommand constructor
                Dim insertCustomerQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, RegistrationDate) VALUES (@Name, @PhoneNumber, @Email, @Address, @RegistrationDate); SELECT SCOPE_IDENTITY();"

                Using cmd As New SqlCommand(insertCustomerQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@PhoneNumber", number)
                    cmd.Parameters.AddWithValue("@Email", email)

                    ' Handle the optional Address field
                    If String.IsNullOrEmpty(address) Then
                        cmd.Parameters.AddWithValue("@Address", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@Address", address)
                    End If

                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)

                    ' ExecuteScalar retrieves the single value (the new CustomerID)
                    Dim result = cmd.ExecuteScalar()

                    If result IsNot Nothing AndAlso IsNumeric(result) Then
                        newCustomerID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Failed to retrieve the new CustomerID after insertion.")
                    End If
                End Using

                ' --- 2. LOOP AND INSERT ALL VEHICLES ---
                If VehicleList IsNot Nothing AndAlso VehicleList.Count > 0 Then

                    Dim insertVehicleQuery As String = "INSERT INTO CustomerVehicleTable (CustomerID, PlateNumber, VehicleType) VALUES (@CustomerID, @PlateNumber, @VehicleType)"

                    For Each vehicle In VehicleList
                        Using vehicleCmd As New SqlCommand(insertVehicleQuery, con, transaction)
                            ' Use the ID retrieved from the customer insert
                            vehicleCmd.Parameters.AddWithValue("@CustomerID", newCustomerID)
                            vehicleCmd.Parameters.AddWithValue("@PlateNumber", vehicle.PlateNumber)
                            vehicleCmd.Parameters.AddWithValue("@VehicleType", vehicle.VehicleType)
                            vehicleCmd.ExecuteNonQuery()
                        End Using
                    Next
                End If

                ' --- 3. COMMIT THE TRANSACTION ---
                ' If we reach here, both the customer and ALL vehicles were saved successfully.
                transaction.Commit()

                Carwash.NotificationLabel.Text = "New Customer and all " & VehicleList.Count.ToString() & " Vehicles Added Successfully (ID: " & newCustomerID.ToString() & ")"
                Carwash.ShowNotification()

                ' Optional: Clear the VehicleList after a successful save
                VehicleList.Clear()

            Catch ex As Exception
                ' --- 4. ROLLBACK ON ERROR ---
                ' If an error occurred at any point (customer failed, or a vehicle failed), undo everything.
                transaction.Rollback()
                MessageBox.Show("Error adding customer and vehicles. Database changes were canceled: " & ex.Message, "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Using
    End Sub

    Public Sub UpdateCustomer(customerID As String, name As String, number As String, email As String, address As String, vehicleType As String, plateNumber As String)
        If String.IsNullOrEmpty(customerID) Then
            MessageBox.Show("Please select a customer in table to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)

            Try
                con.Open()
                Dim updateQuery = "UPDATE CustomersTable SET Name = @Name, PhoneNumber = @Phone, Email = @Email, Address = @Address, VehicleType = @VehicleType, PlateNumber = @PlateNumber WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(updateQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@Phone", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@VehicleType", vehicleType)
                    cmd.Parameters.AddWithValue("@PlateNumber", plateNumber)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Carwash.NotificationLabel.Text = "Customer Information Updated"
                        Carwash.ShowNotification()
                        EditProfile.Hide()
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Function ViewCustomer() As DataTable
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
                    "c.CustomerID, c.Name, c.PhoneNumber, c.Email, c.Address, c.RegistrationDate AS RegisteredDate, " &
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
End Class