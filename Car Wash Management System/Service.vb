Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Service
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxServiceName.Text = DataGridView1.CurrentRow.Cells("ServiceName").Value.ToString()
        TextBoxDescription.Text = DataGridView1.CurrentRow.Cells("Description").Value.ToString()
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells("Price").Value.ToString()
        LabelServiceID.Text = DataGridView1.CurrentRow.Cells("ServiceID").Value.ToString()
    End Sub

    Private Sub AddService()
        If String.IsNullOrEmpty(TextBoxServiceName.Text) Or String.IsNullOrEmpty(TextBoxDescription.Text) Or String.IsNullOrEmpty(TextBoxPrice.Text) Then
            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim AddCustomerQuery = "INSERT INTO ServicesTable (ServiceName, Description, Price, Addon) VALUES (@ServiceName, @Description, @Price, @Addon)"
                Using cmd As New SqlCommand(AddCustomerQuery, con)
                    cmd.Parameters.AddWithValue("@ServiceName", TextBoxServiceName.Text)
                    cmd.Parameters.AddWithValue("Description", TextBoxDescription.Text)
                    cmd.Parameters.AddWithValue("Price", Convert.ToDecimal(TextBoxPrice.Text))
                    cmd.Parameters.AddWithValue("ServiceID", LabelServiceID.Text)
                    cmd.Parameters.AddWithValue("Addon", If(CheckBoxAddon.Checked, 1, 0))
                    cmd.ExecuteNonQuery()
                End Using
                MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error adding service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                ClearFields()
            End Try
        End Using
    End Sub
    Private Sub ClearFields()
        TextBoxServiceName.Clear()
        TextBoxDescription.Clear()
        TextBoxPrice.Clear()
        LabelServiceID.Text = ""
        CheckBoxAddon.Checked = False
    End Sub
    Private Sub ViewService()
        Dim dt As New DataTable
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim ViewServiceQuery = "SELECT * FROM ServicesTable"
                Using cmd As New SqlCommand(ViewServiceQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            Catch ex As Exception
            Finally

            End Try
        End Using
    End Sub

    Private Sub addServiceBtn_Click(sender As Object, e As EventArgs) Handles addServiceBtn.Click
        AddService()
        ViewService()
    End Sub
    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewService()
    End Sub

    Private Sub viewServiceBtn_Click(sender As Object, e As EventArgs) Handles viewServiceBtn.Click
        ViewService()
    End Sub

    Private Sub updateServiceBtn_Click(sender As Object, e As EventArgs) Handles updateServiceBtn.Click
        UpdateService()
    End Sub
    Private Sub UpdateService()
        If String.IsNullOrEmpty(TextBoxServiceName.Text) Or String.IsNullOrEmpty(TextBoxDescription.Text) Or String.IsNullOrEmpty(TextBoxPrice.Text) Then
            MessageBox.Show("Please select service from the table to update", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim UpdateServiceQuery = "UPDATE ServicesTable SET ServiceName = @ServiceName, Description = @Description, Price = @Price, Addon = @Addon WHERE ServiceID = @ServiceID"
                Using cmd As New SqlCommand(UpdateServiceQuery, con)
                    cmd.Parameters.AddWithValue("@ServiceName", TextBoxServiceName.Text)
                    cmd.Parameters.AddWithValue("Description", TextBoxDescription.Text)
                    cmd.Parameters.AddWithValue("Price", Convert.ToDecimal(TextBoxPrice.Text))
                    cmd.Parameters.AddWithValue("ServiceID", LabelServiceID.Text)
                    cmd.Parameters.AddWithValue("Addon", If(CheckBoxAddon.Checked, 1, 0))
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Service updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ViewService()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
                ClearFields()
            End Try
        End Using
    End Sub
    Private Sub DeleteService()
        If String.IsNullOrEmpty(LabelServiceID.Text) Then
            MessageBox.Show("Please select service from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If DialogResult = DialogResult.Yes Then
            Using con As New SqlConnection(constr)
                Try
                    con.Open()
                    Dim DeleteServiceQuery = "DELETE FROM ServicesTable WHERE ServiceID = @ServiceID"
                    Using cmd As New SqlCommand(DeleteServiceQuery, con)
                        cmd.Parameters.AddWithValue("@ServiceID", LabelServiceID.Text)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("Service deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ViewService()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error deleting service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                    ClearFields()
                End Try
            End Using
        End If
    End Sub

    Private Sub deleteServiceBtn_Click(sender As Object, e As EventArgs) Handles deleteServiceBtn.Click
        DeleteService()
    End Sub

    Private Sub CheckBoxAddon_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAddon.CheckedChanged

    End Sub
End Class