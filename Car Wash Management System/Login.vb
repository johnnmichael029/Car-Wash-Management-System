Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient
Public Class Login

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private ReadOnly loginService As LoginService
    Private ReadOnly loginDatabaseHelper As LoginDatabaseHelper
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        loginDatabaseHelper = New LoginDatabaseHelper(constr)
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        DoesHaveAnyAccount()

    End Sub
    Private Sub DoesHaveAnyAccount()
        If Not loginDatabaseHelper.DoesAnyAccountExist() Then
            Dim setupForm As New Admin()
            setupForm.ShowDialog()
        End If
    End Sub
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        LoginValidation()
        LoginActivityLog()
        LabelWelcomeUsers(TextBoxUsername.Text)
    End Sub

    Public Function LabelWelcomeUsers(welcomeUsers As String)
        welcomeUsers = TextBoxUsername.Text
        Carwash.LabelWelcome.Text = welcomeUsers
        CheckIfUserHaveRights(welcomeUsers)
        Return welcomeUsers
    End Function
    Private Sub CheckIfUserHaveRights(welcomeUsers As String)
        If welcomeUsers <> "admin" Then
            Carwash.AdminToolStripMenuItem.Enabled = False
        Else
            Carwash.AdminToolStripMenuItem.Enabled = True
        End If
    End Sub
    Public Sub LoginValidation()
        loginDatabaseHelper.LoginValidation(TextBoxUsername.Text, TextBoxPassword.Text)
    End Sub
    Public Sub ClearFields()
        TextBoxPassword.Clear()
    End Sub
    Public Sub LoginActivityLog()
        Dim username As String = TextBoxUsername.Text
        activityLogInDashboardService.UserLogin(username)
    End Sub
End Class

