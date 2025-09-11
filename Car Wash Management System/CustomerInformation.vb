Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        AddCustomer()
        ViewCustomer()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxName.Text = DataGridView1.CurrentRow.Cells("Name").Value.ToString()
        TextBoxNumber.Text = DataGridView1.CurrentRow.Cells("PhoneNumber").Value.ToString()
        TextBoxEmail.Text = DataGridView1.CurrentRow.Cells("Email").Value.ToString()
        TextBoxAddress.Text = DataGridView1.CurrentRow.Cells("Address").Value.ToString()
        TextBoxPlateNumber.Text = DataGridView1.CurrentRow.Cells("PlateNumber").Value.ToString()
        customerIDLabel.Text = DataGridView1.CurrentRow.Cells("CustomerID").Value.ToString()
    End Sub
    Public Sub DeleteCustomer()
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a customer in table row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim customerID As Integer = Convert.ToInt32(DataGridView1.CurrentRow.Cells("CustomerID").Value)

        DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If DialogResult = DialogResult.Yes Then
            Using con As New SqlConnection(constr)
                Try
                    con.Open()
                    Dim deleteQuery = "DELETE FROM CustomersTable WHERE CustomerID = @CustomerID"
                    Using cmd As New SqlCommand(deleteQuery, con)
                        cmd.Parameters.AddWithValue("@CustomerID", customerID)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
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
    Public Sub AddCustomer()
        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Or String.IsNullOrEmpty(TextBoxAddress.Text) Or String.IsNullOrEmpty(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, PlateNumber) VALUES (@Name, @PhoneNumber, @Email, @Address, @PlateNUmber)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@Name", TextBoxName.Text)
                    cmd.Parameters.AddWithValue("@PhoneNumber", TextBoxNumber.Text)
                    cmd.Parameters.AddWithValue("@Email", TextBoxEmail.Text)
                    cmd.Parameters.AddWithValue("@Address", TextBoxAddress.Text)
                    cmd.Parameters.AddWithValue("@PlateNUmber", TextBoxPlateNumber.Text)
                    cmd.ExecuteNonQuery()

                End Using

            Catch ex As Exception
                MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub
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
                        ViewCustomer()
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
    Public Sub ViewCustomer()
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT CustomerID, Name, PhoneNumber, Email, Address, PlateNumber FROM CustomersTable"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

    End Sub

    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        ViewCustomer()
    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        UpdateCustomer()
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        DeleteCustomer()
    End Sub
    Private Sub CustomerInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewCustomer()
    End Sub
End Class