Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly customerInformationManagement As CustomerInformationManagement
    Dim DashboardManagement As New DashboardManagement(constr)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        customerInformationManagement = New CustomerInformationManagement(constr)
    End Sub
    Private Sub CustomerInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = customerInformationManagement.ViewCustomer()
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxName.Text = DataGridView1.CurrentRow.Cells("Name").Value.ToString()
        TextBoxNumber.Text = DataGridView1.CurrentRow.Cells("PhoneNumber").Value.ToString()
        TextBoxEmail.Text = DataGridView1.CurrentRow.Cells("Email").Value.ToString()
        TextBoxAddress.Text = DataGridView1.CurrentRow.Cells("Address").Value.ToString()
        TextBoxPlateNumber.Text = DataGridView1.CurrentRow.Cells("PlateNumber").Value.ToString()
        customerIDLabel.Text = DataGridView1.CurrentRow.Cells("CustomerID").Value.ToString()
    End Sub
    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        customerInformationManagement.AddCustomer(TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPlateNumber.Text)
        DataGridView1.DataSource = customerInformationManagement.ViewCustomer()

        Dim customerName As String = TextBoxName.Text
        DashboardManagement.AddNewCustomer(customerName)
        ClearFields()
    End Sub
    Private Sub viewBtn_Click(sender As Object, e As EventArgs) Handles viewBtn.Click
        DataGridView1.DataSource = customerInformationManagement.ViewCustomer()
    End Sub

    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        customerInformationManagement.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPlateNumber.Text)
        DataGridView1.DataSource = customerInformationManagement.ViewCustomer()
        ClearFields()
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        customerInformationManagement.DeleteCustomer(DataGridView1)
        ClearFields()
    End Sub
    Public Sub ClearFields()
        TextBoxName.Clear()
        TextBoxNumber.Clear()
        TextBoxEmail.Clear()
        TextBoxAddress.Clear()
        TextBoxPlateNumber.Clear()
        customerIDLabel.Text = ""
    End Sub


End Class
Public Class CustomerInformationManagement
    Dim constr As String
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
    Public Sub AddCustomer(name As String, number As String, email As String, address As String, plateNumber As String)
        If String.IsNullOrEmpty(name) Or String.IsNullOrEmpty(number) Or String.IsNullOrEmpty(email) Or String.IsNullOrEmpty(address) Or String.IsNullOrEmpty(plateNumber) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, PlateNumber, RegistrationDate) VALUES (@Name, @PhoneNumber, @Email, @Address, @PlateNUmber, @RegistrationDate)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@PhoneNumber", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@PlateNUmber", plateNumber)
                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try

        End Using

    End Sub
    Public Sub UpdateCustomer(customerID As String, name As String, number As String, email As String, address As String, plateNumber As String)
        If String.IsNullOrEmpty(customerID) Then
            MessageBox.Show("Please select a customer in table to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)

            Try
                con.Open()
                Dim updateQuery = "UPDATE CustomersTable SET Name = @Name, PhoneNumber = @Phone, Email = @Email, Address = @Address, PlateNumber = @PlateNumber WHERE CustomerID = @CustomerID"
                Using cmd As New SqlCommand(updateQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@Phone", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Address", address)
                    cmd.Parameters.AddWithValue("@PlateNumber", plateNumber)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
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
                Dim selectQuery = "SELECT * FROM CustomersTable ORDER BY CustomerID DESC"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt
    End Function

End Class