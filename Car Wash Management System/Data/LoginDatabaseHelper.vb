Imports Microsoft.Data.SqlClient

Public Class LoginDatabaseHelper
    Private Shared constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Sub LoginValidation(username As String, password As String)
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT 
                                        password, 
                                        salt, 
                                        CASE 
                                            WHEN is_admin IS NULL THEN 0 
                                            ELSE is_admin 
                                        END AS is_admin 
                                    FROM 
                                        userTable 
                                    WHERE 
                                        username = @username"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@username", username)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim storedHash As String = reader("password").ToString()
                            Dim storedSalt As String = reader("salt").ToString()
                            Dim isAdmin As Boolean = reader("is_admin")
                            If LoginService.VerifyPassword(password, storedSalt, storedHash) Then
                                Carwash.Show()
                                Login.Hide()
                            Else
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                        Login.ClearFields()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Shared Function DoesAnyAccountExist() As Boolean
        Dim count As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM UserTable"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        count = Convert.ToInt32(result)
                        Console.WriteLine()
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using

        Return count >= 1
    End Function

End Class
