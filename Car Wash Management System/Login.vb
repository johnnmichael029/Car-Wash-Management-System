Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient
Public Class Login

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private ReadOnly loginService As LoginService
    Private ReadOnly loginDatabaseHelper As LoginDatabaseHelper

    ' --- Animation State Variables ---
    Private Const START_Y As Integer = 20  ' Y position of the label when inside the textbox
    Private Const END_Y As Integer = 2    ' Y position of the label when floating above
    Private Const ANIMATION_STEP As Integer = 3 ' How many pixels to move per timer tick

    ' Flags to determine the direction of the animation
    Private IsAnimatingUp As Boolean = False
    Private IsAnimatingDown As Boolean = False

    Private IsAnimatingUpForPassword As Boolean = False
    Private IsAnimatingDownForPassword As Boolean = False
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        loginDatabaseHelper = New LoginDatabaseHelper(constr)
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Settings.CheckBoxEnableDiscount.Checked = My.Settings.DiscountEnabled
        Settings.CheckBoxFixDiscount.Checked = My.Settings.FixDiscount
        Settings.NumericUpDownDiscount.Value = My.Settings.DiscountValue


        CenterToScreen()
        LoginService.DoesHaveAnyAccount("admin", "admin123", True)
    End Sub
    Private Sub TimerAnimator_Tick(sender As Object, e As EventArgs) Handles TimerAnimator.Tick
        LoginAnimationService.TimerAnimation(LabelHolderUsername)
    End Sub

    Private Sub TextBoxUsername_Enter(sender As Object, e As EventArgs) Handles TextBoxUsername.Enter
        ' Only animate up if the label is currently down
        LoginAnimationService.TextBoxEnter(TextBoxUsername, LabelHolderUsername)
    End Sub

    Private Sub TextBoxUsername_Leave(sender As Object, e As EventArgs) Handles TextBoxUsername.Leave
        ' Only animate down if the textbox is empty
        LoginAnimationService.TextBoxLeave(TextBoxUsername, LabelHolderUsername)
    End Sub

    Private Sub TextBoxUsername_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUsername.TextChanged
        ' Hide the label if the user starts typing, even if the animation hasn't finished
        LoginAnimationService.TextBoxChanged(TextBoxUsername, LabelHolderUsername)
    End Sub
    Private Sub TimerAnimator1_Tick(sender As Object, e As EventArgs) Handles TimerAnimator1.Tick
        LoginAnimationServiceForPassword.TimerAnimation(LabelHolderPassword)
    End Sub
    Private Sub TextBoxPassword_Enter(sender As Object, e As EventArgs) Handles TextBoxPassword.Enter
        ' Only animate up if the label is currently down
        LoginAnimationServiceForPassword.TextBoxEnter(TextBoxPassword, LabelHolderPassword)
    End Sub
    Private Sub TextBoxPassword_Leave(sender As Object, e As EventArgs) Handles TextBoxPassword.Leave
        ' Only animate down if the textbox is empty
        LoginAnimationServiceForPassword.TextBoxLeave(TextBoxPassword, LabelHolderPassword)
    End Sub
    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged
        ' Hide the label if the user starts typing, even if the animation hasn't finished
        LoginAnimationServiceForPassword.TextBoxChanged(TextBoxPassword, LabelHolderPassword)
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

    Private Sub PictureBoxShow_Click(sender As Object, e As EventArgs) Handles PictureBoxShow.Click
        If TextBoxPassword.UseSystemPasswordChar = True Then
            TextBoxPassword.UseSystemPasswordChar = False
            PictureBoxHidden.Visible = True
            PictureBoxShow.Visible = False
        Else
            TextBoxPassword.UseSystemPasswordChar = True
            PictureBoxHidden.Visible = False
            PictureBoxShow.Visible = True
        End If
    End Sub

    Private Sub LabelHolderUsername_Click(sender As Object, e As EventArgs) Handles LabelHolderUsername.Click
        TextBoxUsername.Focus()
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub PictureBoxHidden_Click(sender As Object, e As EventArgs) Handles PictureBoxHidden.Click
        If TextBoxPassword.UseSystemPasswordChar = True Then
            TextBoxPassword.UseSystemPasswordChar = False
            PictureBoxHidden.Visible = True
            PictureBoxShow.Visible = False
        Else
            TextBoxPassword.UseSystemPasswordChar = True
            PictureBoxHidden.Visible = False
            PictureBoxShow.Visible = True
        End If
    End Sub
End Class


