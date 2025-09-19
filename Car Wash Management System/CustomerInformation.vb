Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
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
        DataGridViewCustomerInformation.DataSource = customerInformationManagement.ViewCustomer()
        DataGridViewCustomerInformationFontStyle()
    End Sub
    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerInformation.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)

    End Sub

    Private Sub DataGridViewCustomerInformation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerInformation.CellContentClick
        TextBoxName.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Name").Value.ToString()
        TextBoxNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PhoneNumber").Value.ToString()
        TextBoxEmail.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Email").Value.ToString()
        TextBoxAddress.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Address").Value.ToString()
        TextBoxPlateNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PlateNumber").Value.ToString()
        customerIDLabel.Text = DataGridViewCustomerInformation.CurrentRow.Cells("CustomerID").Value.ToString()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddCustomerInformation()
        NewCustomerActivityLog()
        ClearFields()
    End Sub
    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        DashboardManagement.AddNewCustomer(customerName)
    End Sub
    Public Sub AddCustomerInformation()
        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Or String.IsNullOrEmpty(TextBoxAddress.Text) Or String.IsNullOrEmpty(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        customerInformationManagement.AddCustomer(TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPlateNumber.Text)
        DataGridViewCustomerInformation.DataSource = customerInformationManagement.ViewCustomer()
    End Sub
    Private Sub ViewBtn_Click(sender As Object, e As EventArgs) Handles ViewBtn.Click
        ViewCustomerInformation()
    End Sub
    Private Sub ViewCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationManagement.ViewCustomer()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateCustomerInformation()
        ClearFields()
    End Sub
    Private Sub UpdateCustomerInformation()
        customerInformationManagement.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPlateNumber.Text)
        DataGridViewCustomerInformation.DataSource = customerInformationManagement.ViewCustomer()
    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        DeleteCustomerInformation()
        ClearFields()
    End Sub
    Private Sub DeleteCustomerInformation()
        customerInformationManagement.DeleteCustomer(DataGridViewCustomerInformation)
        DataGridViewCustomerInformation.DataSource = customerInformationManagement.ViewCustomer()
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
    Public Sub AddCustomer(name As String, number As String, email As String, address As String, plateNumber As String)

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
                Carwash.NotificationLabel.Text = "New Customer Information"
                Carwash.ShowNotification()
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
                        Carwash.NotificationLabel.Text = "Customer Information Updated"
                        Carwash.ShowNotification()
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