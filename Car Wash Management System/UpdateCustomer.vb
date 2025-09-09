Imports Microsoft.Data.SqlClient

Public Class UpdateCustomer

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        Dim customerManagement As New CustomerManagement()
        UpdateCustomer()
        customerManagement.ViewCustomer()
    End Sub
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Public Sub UpdateCustomer()
        If String.IsNullOrEmpty(customerIDLabel.Text) Then
            MessageBox.Show("Please select a customer in table to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)

            Try
                con.Open()
                Dim updateQuery = "UPDATE CustomersTable SET Name = @Name, PhoneNumber = @Phone, Email = @Email, Address = @Address, PlateNumber = @PlateNumber WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(updateQuery, con)
                    cmd.Parameters.AddWithValue("@Name", TextBoxName.Text)
                    cmd.Parameters.AddWithValue("@Phone", TextBoxNumber.Text)
                    cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text)
                    cmd.Parameters.AddWithValue("@Address", TextBoxAddress.Text)
                    cmd.Parameters.AddWithValue("@PlateNumber", TextBoxPlateNumber.Text)
                    cmd.Parameters.AddWithValue("@CustomerID", customerIDLabel.Text)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        CustomerManagement.ViewCustomer()
                    End If

                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                customerIDLabel.Text = ""
                TextBoxName.Clear()
                TextBoxNumber.Clear()
                TextBoxEmail.Clear()
                TextBoxAddress.Clear()
                TextBoxPlateNumber.Clear()

            End Try
        End Using
    End Sub

End Class