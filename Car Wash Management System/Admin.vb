Imports Microsoft.Data.SqlClient

Public Class Admin
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AdminResetPassword(TextBoxUsername.Text, TextBoxNewPassword.Text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    Public Sub AdminResetPassword(usernameToReset As String, newPassword As String)
        ' Check if the username is empty
        If String.IsNullOrWhiteSpace(usernameToReset) Then
            MessageBox.Show("Please enter a username to reset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Hash the new password using the existing function
        Dim passwordTuple = Login.HashPassword(newPassword)
        Dim newSalt As String = passwordTuple.Item1
        Dim newHash As String = passwordTuple.Item2

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' First, check if the user exists
                Dim checkUserQuery = "SELECT COUNT(*) FROM userTable WHERE username = @username"
                Using cmdCheck As New SqlCommand(checkUserQuery, con)
                    cmdCheck.Parameters.AddWithValue("@username", usernameToReset)
                    Dim userCount As Integer = CInt(cmdCheck.ExecuteScalar())

                    If userCount = 0 Then
                        MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' Update the user's password and salt in the database
                Dim updateQuery = "UPDATE userTable SET password = @password, salt = @salt WHERE username = @username"
                Using cmdUpdate As New SqlCommand(updateQuery, con)
                    cmdUpdate.Parameters.AddWithValue("@username", usernameToReset)
                    cmdUpdate.Parameters.AddWithValue("@password", newHash)
                    cmdUpdate.Parameters.AddWithValue("@salt", newSalt)
                    cmdUpdate.ExecuteNonQuery()
                End Using

                MessageBox.Show("Password for '" & usernameToReset & "' has been reset.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("An error occurred during password reset: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                TextBoxUsername.Clear()
                TextBoxNewPassword.Clear()
                con.Close()
            End Try
        End Using
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
    End Sub
End Class