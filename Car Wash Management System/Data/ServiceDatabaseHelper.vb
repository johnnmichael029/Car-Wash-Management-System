Imports Microsoft.Data.SqlClient
Public Class ServiceDatabaseHelper
    Private Shared constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Shared Function CheckIfAdmin(username As String) As Boolean
        Dim isAdmin As Boolean = False
        Using con As New SqlConnection(constr)
            Dim selectQuery = "SELECT CASE WHEN is_admin IS NULL THEN 0 ELSE is_admin END AS is_admin FROM userTable WHERE username = @username"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@username", username)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        isAdmin = Convert.ToBoolean(result)
                    Else
                        isAdmin = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    isAdmin = False
                Finally
                    con.Close()
                End Try
            End Using
        End Using

        Return isAdmin
    End Function
    Public Sub AddService(serviceName As String, description As String, price As String, serviceID As String, Addon As String)

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
                Carwash.NotificationLabel.Text = "New Service Added"
                Carwash.ShowNotification()

            Catch ex As Exception
                MessageBox.Show("Error adding service: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()

            End Try
        End Using
    End Sub
    Public Sub UpdateService(serviceName As String, description As String, price As String, serviceID As String, Addon As String)
        If String.IsNullOrEmpty(serviceName) Or String.IsNullOrEmpty(price) Then
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
                        Carwash.NotificationLabel.Text = "Service updated"
                        Carwash.ShowNotification()
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
                            Carwash.NotificationLabel.Text = "Service deleted"
                            Carwash.ShowNotification()
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
                MessageBox.Show("Error viewing services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

End Class