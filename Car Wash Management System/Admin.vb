Imports Microsoft.Data.SqlClient

Public Class Admin
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly adminManagement As AdminManagement
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        adminManagement = New AdminManagement(constr)
    End Sub
    Private Sub AddUserBtn_Click(sender As Object, e As EventArgs) Handles AddUserBtn.Click
        AddUsersFunction()
        ViewUsersFromDataGridView()
    End Sub
    Private Sub AddUsersFunction()
        adminManagement.AddUsers(TextBoxUsername.Text, TextBoxNewPassword.Text, CheckBoxIsAdmin.Checked)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Application.Exit
    End Sub
    Private Sub ViewUsersFromDataGridView()
        DataGridViewUsers.DataSource = adminManagement.ViewUsers()
    End Sub
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
        ViewUsersFromDataGridView()
    End Sub

    Private Sub ChangePasswordBtn_Click(sender As Object, e As EventArgs) Handles ChangePasswordBtn.Click
        adminManagement.AdminResetPassword(TextBoxUsername.Text, TextBoxNewPassword.Text)
        ClearFields
    End Sub
    Public Sub ClearFields()
        TextBoxUsername.Clear()
        TextBoxNewPassword.Clear()
    End Sub

    Private Sub DeleteUserBtn_Click(sender As Object, e As EventArgs) Handles DeleteUserBtn.Click
        DeleteUserFunction()
    End Sub
    Private Sub DeleteUserFunction()
        adminManagement.DeleteUsers(TextBoxUsername.Text)
        DataGridViewUsers.DataSource = adminManagement.ViewUsers()
    End Sub
    Private Sub DataGridViewUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewUsers.CellContentClick
        TextBoxUsername.Text = DataGridViewUsers.CurrentRow.Cells(0).Value.ToString()
    End Sub
End Class
Public Class AdminManagement
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Function DeleteUsers(username As String) As Boolean
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Please enter a username to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' First, check if the user exists
                Dim checkUserQuery = "SELECT COUNT(*) FROM userTable WHERE username = @username"
                Using cmdCheck As New SqlCommand(checkUserQuery, con)
                    cmdCheck.Parameters.AddWithValue("@username", username)
                    Dim userCount As Integer = CInt(cmdCheck.ExecuteScalar())
                    If userCount = 0 Then
                        MessageBox.Show("Username not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
                Dim dialogResult = MessageBox.Show("Are you sure you want to delete user '" & username & "'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If dialogResult = DialogResult.Yes Then
                    Dim deleteQuery = "DELETE FROM userTable WHERE username = @username"
                    Using cmdDelete As New SqlCommand(deleteQuery, con)
                        cmdDelete.Parameters.AddWithValue("@username", username)
                        Dim rowsAffected As Integer = cmdDelete.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("User '" & username & "' has been deleted.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Return True
                        End If
                    End Using
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred while deleting the user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function
    Public Function ViewUsers() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim query = "SELECT username, is_admin FROM userTable"
                Using cmd As New SqlCommand(query, con)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred while retrieving users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Function AddUsers(username As String, password As String, is_admin As Boolean) As Boolean
        ' Check for empty fields first to prevent unnecessary database calls
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim passwordTuple = LoginManagement.HashPassword(password)
        Dim salt As String = passwordTuple.Item1
        Dim hashedPassword As String = passwordTuple.Item2
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery = "INSERT INTO userTable (username, password, salt, is_admin) VALUES (@username, @password, @salt, @is_admin)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", hashedPassword)
                    cmd.Parameters.AddWithValue("@salt", salt)
                    cmd.Parameters.AddWithValue("@is_admin", is_admin)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Admin.ClearFields()
                        Return True
                    Else
                        MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Finally
                con.Close()
            End Try
        End Using
    End Function

    Public Sub AdminResetPassword(usernameToReset As String, newPassword As String)
        ' Check if the username is empty
        If String.IsNullOrWhiteSpace(usernameToReset) Or String.IsNullOrWhiteSpace(newPassword) Then
            MessageBox.Show("Please enter both username and passoword to reset.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    MessageBox.Show("Password for '" & usernameToReset & "' has been reset.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred during password reset: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

End Class