Imports Microsoft.Data.SqlClient

Public Class AddCustomer
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPlateNumber.TextChanged

    End Sub

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        AddCustomer()
        CustomerManagement.ViewCustomer()
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

    Private Sub AddCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class