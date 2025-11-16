Imports Microsoft.Data.SqlClient

Public Class Admin
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub AddUserBtn_Click(sender As Object, e As EventArgs) Handles AddUserBtn.Click
        AddUsersFunction()
        ViewUsersFromDataGridView()
    End Sub
    Public Sub AddUsersFunction()
        AdminDatabaseHelper.AddUsers(TextBoxUsername.Text, TextBoxNewPassword.Text, CheckBoxIsAdmin.Checked)
        MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearFields()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub
    Private Sub ViewUsersFromDataGridView()
        DataGridViewUsers.DataSource = AdminDatabaseHelper.ViewUsers()
    End Sub
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
        ViewUsersFromDataGridView()
    End Sub

    Private Sub ChangePasswordBtn_Click(sender As Object, e As EventArgs) Handles ChangePasswordBtn.Click
        AdminDatabaseHelper.AdminResetPassword(TextBoxUsername.Text, TextBoxNewPassword.Text)
        ClearFields()
    End Sub
    Public Sub ClearFields()
        TextBoxUsername.Clear()
        TextBoxNewPassword.Clear()
    End Sub

    Private Sub DeleteUserBtn_Click(sender As Object, e As EventArgs) Handles DeleteUserBtn.Click
        DeleteUserFunction()
    End Sub
    Private Sub DeleteUserFunction()
        AdminDatabaseHelper.DeleteUsers(TextBoxUsername.Text)
        DataGridViewUsers.DataSource = AdminDatabaseHelper.ViewUsers()
    End Sub
    Private Sub DataGridViewUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewUsers.CellContentClick
        TextBoxUsername.Text = DataGridViewUsers.CurrentRow.Cells(0).Value.ToString()
    End Sub
End Class
