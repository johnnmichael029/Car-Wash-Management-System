Imports Microsoft.Data.SqlClient

Public Class Admin
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly aminDatabaseHelper As AdminDatabaseHelper
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        aminDatabaseHelper = New AdminDatabaseHelper(constr)
    End Sub
    Private Sub AddUserBtn_Click(sender As Object, e As EventArgs) Handles AddUserBtn.Click
        AddUsersFunction()
        ViewUsersFromDataGridView()
    End Sub
    Private Sub AddUsersFunction()
        aminDatabaseHelper.AddUsers(TextBoxUsername.Text, TextBoxNewPassword.Text, CheckBoxIsAdmin.Checked)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Application.Exit
    End Sub
    Private Sub ViewUsersFromDataGridView()
        DataGridViewUsers.DataSource = aminDatabaseHelper.ViewUsers()
    End Sub
    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
        ViewUsersFromDataGridView()
    End Sub

    Private Sub ChangePasswordBtn_Click(sender As Object, e As EventArgs) Handles ChangePasswordBtn.Click
        aminDatabaseHelper.AdminResetPassword(TextBoxUsername.Text, TextBoxNewPassword.Text)
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
        aminDatabaseHelper.DeleteUsers(TextBoxUsername.Text)
        DataGridViewUsers.DataSource = aminDatabaseHelper.ViewUsers()
    End Sub
    Private Sub DataGridViewUsers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewUsers.CellContentClick
        TextBoxUsername.Text = DataGridViewUsers.CurrentRow.Cells(0).Value.ToString()
    End Sub
End Class
