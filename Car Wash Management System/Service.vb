Imports System.Drawing.Text
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Service
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)
    Private ReadOnly serviceManagement As ServiceManagement
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        serviceManagement = New ServiceManagement(constr)
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxServiceName.Text = DataGridView1.CurrentRow.Cells("ServiceName").Value.ToString()
        TextBoxDescription.Text = DataGridView1.CurrentRow.Cells("Description").Value.ToString()
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells("Price").Value.ToString()
        LabelServiceID.Text = DataGridView1.CurrentRow.Cells("ServiceID").Value.ToString()
    End Sub


    Public Sub ClearFields()
        TextBoxServiceName.Clear()
        TextBoxDescription.Clear()
        TextBoxPrice.Clear()
        LabelServiceID.Text = ""
        CheckBoxAddon.Checked = False
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        serviceManagement.AddService(TextBoxServiceName.Text, TextBoxDescription.Text, TextBoxPrice.Text, LabelServiceID.Text, CheckBoxAddon.Checked)
        DataGridView1.DataSource = serviceManagement.ViewService()
        dashboardManagement.AddNewService(TextBoxServiceName.Text)


    End Sub
    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = serviceManagement.ViewService()
    End Sub

    Private Sub ViewServiceBtn_Click(sender As Object, e As EventArgs) Handles ViewServiceBtn.Click
        DataGridView1.DataSource = serviceManagement.ViewService()
    End Sub

    Private Sub UpdateServiceBtn_Click(sender As Object, e As EventArgs) Handles UpdateServiceBtn.Click
        serviceManagement.UpdateService(TextBoxServiceName.Text, TextBoxDescription.Text, TextBoxPrice.Text, LabelServiceID.Text, CheckBoxAddon.Checked)
        DataGridView1.DataSource = serviceManagement.ViewService()
        ClearFields()
    End Sub

    Private Sub DeleteServiceBtn_Click(sender As Object, e As EventArgs) Handles DeleteServiceBtn.Click
        serviceManagement.DeleteService(LabelServiceID.Text)
        DataGridView1.DataSource = serviceManagement.ViewService()
        ClearFields()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class
Public Class ServiceManagement
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Sub AddService(serviceName As String, description As String, price As String, serviceID As String, Addon As String)
        If String.IsNullOrEmpty(serviceName) Or String.IsNullOrEmpty(description) Or String.IsNullOrEmpty(price) Then
            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim AddCustomerQuery = "INSERT INTO ServicesTable (ServiceName, Description, Price, Addon) VALUES (@ServiceName, @Description, @Price, @Addon)"
                Using cmd As New SqlCommand(AddCustomerQuery, con)
                    cmd.Parameters.AddWithValue("@ServiceName", serviceName)
                    cmd.Parameters.AddWithValue("Description", description)
                    cmd.Parameters.AddWithValue("Price", Convert.ToDecimal(price))
                    cmd.Parameters.AddWithValue("ServiceID", serviceID)
                    cmd.Parameters.AddWithValue("Addon", If(Addon, 1, 0))
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Service.ClearFields()
            Catch ex As Exception
                MessageBox.Show("Error adding service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()

            End Try
        End Using
    End Sub
    Public Sub UpdateService(serviceName As String, description As String, price As String, serviceID As String, Addon As String)
        If String.IsNullOrEmpty(serviceName) Or String.IsNullOrEmpty(description) Or String.IsNullOrEmpty(price) Then
            MessageBox.Show("Please select service from the table to update", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim UpdateServiceQuery = "UPDATE ServicesTable SET ServiceName = @ServiceName, Description = @Description, Price = @Price, Addon = @Addon WHERE ServiceID = @ServiceID"
                Using cmd As New SqlCommand(UpdateServiceQuery, con)
                    cmd.Parameters.AddWithValue("@ServiceName", serviceName)
                    cmd.Parameters.AddWithValue("Description", description)
                    cmd.Parameters.AddWithValue("Price", Convert.ToDecimal(price))
                    cmd.Parameters.AddWithValue("ServiceID", serviceID)
                    cmd.Parameters.AddWithValue("Addon", If(Addon, 1, 0))
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()

            End Try
        End Using
    End Sub
    Public Sub DeleteService(serviceID As String)
        If String.IsNullOrEmpty(serviceID) Then
            MessageBox.Show("Please select service from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If DialogResult = DialogResult.Yes Then
            Using con As New SqlConnection(constr)
                Try
                    con.Open()
                    Dim DeleteServiceQuery = "DELETE FROM ServicesTable WHERE ServiceID = @ServiceID"
                    Using cmd As New SqlCommand(DeleteServiceQuery, con)
                        cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error deleting service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Sub
    Public Function ViewService() As DataTable
        Dim dt As New DataTable
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim ViewServiceQuery = "SELECT * FROM ServicesTable"
                Using cmd As New SqlCommand(ViewServiceQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
            Finally

            End Try
        End Using
        Return dt
    End Function

End Class