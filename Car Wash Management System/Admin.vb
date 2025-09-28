Imports Microsoft.Data.SqlClient

Public Class Admin
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly adminManagement As AdminManagement
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        adminManagement = New AdminManagement(constr)
    End Sub
    Private Sub AddUserBtn_Click(sender As Object, e As EventArgs) Handles AddUserBtn.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Application.Exit
    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
    End Sub

    Private Sub ChangePasswordBtn_Click(sender As Object, e As EventArgs) Handles ChangePasswordBtn.Click
        adminManagement.AdminResetPassword(TextBoxUsername.Text, TextBoxNewPassword.Text)
    End Sub
End Class
Public Class AdminManagement
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Sub AdminResetPassword(usernameToReset As String, newPassword As String)
        ' Check if the username is empty
        If String.IsNullOrWhiteSpace(usernameToReset) Then
            MessageBox.Show("Please enter a username to reset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Hash the new password using the existing function
        Dim passwordTuple = LoginManagement.HashPassword(newPassword)
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
                Login.Show()
                Admin.Hide()

            Catch ex As Exception
                MessageBox.Show("An error occurred during password reset: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

End Class