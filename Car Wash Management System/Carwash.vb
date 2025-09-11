Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class Carwash

    Private Sub Dashboard1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
    End Sub

    'Private Sub CustomerListToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Dim customerManagement As New CustomerManagement
    '    customerManagement.StartPosition = FormStartPosition.Manual
    '    customerManagement.Location = New Point(400, 200)
    '    For Each child In MdiChildren
    '        child.Close()
    '    Next
    '    customerManagement.MdiParent = Me
    '    UpdateCustomer.Hide()
    '    AddCustomer.Hide()
    '    customerManagement.Show()
    'End Sub

    'Private Sub DashboardToolStripMenuItem_Click(sender As Object, e As EventArgs)
    'Dim dashboard As New Dashboard
    '    For Each child In MdiChildren
    '        child.Close()
    '    Next
    '    ' Open the new child form
    '    dashboard.MdiParent = Me
    '    UpdateCustomer.Hide()
    '    AddCustomer.Hide()
    '    dashboard.Show()
    'End Sub

    Private PrivateFonts As New PrivateFontCollection()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim pfc As PrivateFontCollection = New PrivateFontCollection()
        pfc.AddFontFile("Poppins\Poppins-Regular.ttf")
        dashboardBtn.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        Btn2.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        Btn3.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        LabelCarwash.Font = New Font(pfc.Families(0), 25, FontStyle.Bold)
        LabelWelcome.Font = New Font(pfc.Families(0), 25, FontStyle.Regular)
        logoutBtn.Font = New Font(pfc.Families(0), 12, FontStyle.Regular)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    Sub SwitchPanel(ByVal panel As Form)
        Panel4.Controls.Clear()
        panel.TopLevel = False
        Panel4.Controls.Add(panel)
        panel.Show()
    End Sub

    Private Sub saleBtn_Click(sender As Object, e As EventArgs) Handles Btn2.Click

    End Sub

    Private Sub customerBtn_Click(sender As Object, e As EventArgs) Handles Btn3.Click
    End Sub

    Private Sub dashboardBtn_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click
        SwitchPanel(Dashboard)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub logoutBtn_Click(sender As Object, e As EventArgs) Handles logoutBtn.Click
        DialogResult = MessageBox.Show("Are you sure you want to logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If DialogResult = DialogResult.Yes Then
            Me.Hide()
            Login.Show()
        End If
    End Sub

    Private Sub ServiceTrackingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceTrackingToolStripMenuItem.Click

    End Sub

    Private Sub CustomerInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerInformationToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim customerInformation As New CustomerInformation()
        customerInformation.TopLevel = False
        customerInformation.FormBorderStyle = FormBorderStyle.None
        Panel4.Controls.Add(customerInformation)
        customerInformation.Dock = DockStyle.Fill
        customerInformation.Show()
    End Sub

    Private Sub ServiceCatalogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceCatalogToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim service As New Service()
        service.TopLevel = False
        service.FormBorderStyle = FormBorderStyle.None
        Panel4.Controls.Add(service)
        service.Dock = DockStyle.Fill
        service.Show()
    End Sub

    Private Sub SaleHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleHistoryToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim salesHistory As New SalesForm()
        salesHistory.TopLevel = False
        salesHistory.FormBorderStyle = FormBorderStyle.None
        Panel4.Controls.Add(salesHistory)
        salesHistory.Dock = DockStyle.Fill
        salesHistory.Show()
    End Sub

    Private Sub BillingAndToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingAndToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim billingContracts As New BillingContracts()
        billingContracts.TopLevel = False
        billingContracts.FormBorderStyle = FormBorderStyle.None
        Panel4.Controls.Add(billingContracts)
        billingContracts.Dock = DockStyle.Fill
        billingContracts.Show()
    End Sub
End Class