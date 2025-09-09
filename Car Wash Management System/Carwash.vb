Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class Carwash

    Private Sub SalesLogToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim salesLog As New SalesLog
        salesLog.StartPosition = FormStartPosition.Manual
        salesLog.Location = New Point(400, 200)
        For Each child In MdiChildren
            child.Close()

        Next
        ' Open the new child form
        salesLog.MdiParent = Me
        UpdateCustomer.Hide()
        AddCustomer.Hide()
        salesLog.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub Dashboard1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        CenterToParent()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs)

        DialogResult = MessageBox.Show("Logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If DialogResult = DialogResult.Yes Then
            Hide()
            Login.Show()
        End If
    End Sub

    Private Sub CustomerListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim customerManagement As New CustomerManagement
        customerManagement.StartPosition = FormStartPosition.Manual
        customerManagement.Location = New Point(400, 200)
        For Each child In MdiChildren
            child.Close()
        Next
        customerManagement.MdiParent = Me
        UpdateCustomer.Hide()
        AddCustomer.Hide()
        customerManagement.Show()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim dashboard As New Dashboard
        For Each child In MdiChildren
            child.Close()
        Next
        ' Open the new child form
        dashboard.MdiParent = Me
        UpdateCustomer.Hide()
        AddCustomer.Hide()
        dashboard.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub
    Private Sub OpenNewChildForm(newChildForm As Form)
        ' Close all existing MDI child forms

    End Sub
    Private PrivateFonts As New PrivateFontCollection()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pfc As PrivateFontCollection = New PrivateFontCollection()
        pfc.AddFontFile("Poppins\Poppins-Regular.ttf")
        dashboardBtn.Font = New Font(pfc.Families(0), 17, FontStyle.Regular)
        saleBtn.Font = New Font(pfc.Families(0), 17, FontStyle.Regular)
        customerBtn.Font = New Font(pfc.Families(0), 17, FontStyle.Regular)
        LabelCarwash.Font = New Font(pfc.Families(0), 64, FontStyle.Bold)
        LabelWelcome.Font = New Font(pfc.Families(0), 30, FontStyle.Regular)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    Private Sub LabelWelcome_Click(sender As Object, e As EventArgs) Handles LabelWelcome.Click

    End Sub
    Sub SwitchPanel(ByVal panel As Form)
        Panel4.Controls.Clear()
        panel.TopLevel = False
        Panel4.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub dashboardBtn_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click
        SwitchPanel(Dashboard)
    End Sub

    Private Sub saleBtn_Click(sender As Object, e As EventArgs) Handles saleBtn.Click
        SwitchPanel(SalesLog)
    End Sub

    Private Sub customerBtn_Click(sender As Object, e As EventArgs) Handles customerBtn.Click
        SwitchPanel(CustomerManagement)
    End Sub
End Class