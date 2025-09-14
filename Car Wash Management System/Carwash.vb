Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class Carwash
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)
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
        'Dim pfc As New PrivateFontCollection()
        'pfc.AddFontFile("Poppins\Poppins-Regular.ttf")
        'DashboardBtn.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        'Btn2.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        'Btn3.Font = New Font(pfc.Families(0), 15, FontStyle.Regular)
        'LabelCarwash.Font = New Font(pfc.Families(0), 20, FontStyle.Bold)
        'LogoutBtn.Font = New Font(pfc.Families(0), 12, FontStyle.Regular)

        Panel4.Controls.Clear()
        Dim dashboard As New Dashboard With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(dashboard)
        dashboard.Dock = DockStyle.Fill
        dashboard.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub

    'Sub SwitchPanel(ByVal panel As Form)
    '    Panel4.Controls.Clear()
    '    panel.TopLevel = False
    '    Panel4.Controls.Add(panel)
    '    panel.Show()
    'End Sub
    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        DialogResult = MessageBox.Show("Are you sure you want to logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If DialogResult = DialogResult.Yes Then
            Me.Hide()
            Login.Show()
        End If

        Dim username As String = Login.TextBoxUsername.Text
        dashboardManagement.UserLogout(username)
    End Sub

    Private Sub CustomerInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerInformationToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim customerInformation As New CustomerInformation With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(customerInformation)
        customerInformation.Dock = DockStyle.Fill
        customerInformation.Show()
    End Sub

    Private Sub ServiceCatalogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ServiceCatalogToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim service As New Service With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(service)
        service.Dock = DockStyle.Fill
        service.Show()
    End Sub

    Private Sub SaleHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleHistoryToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim salesHistory As New SalesForm With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(salesHistory)
        salesHistory.Dock = DockStyle.Fill
        salesHistory.Show()
    End Sub

    Private Sub BillingAndToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillingAndToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim billingContracts As New BillingContracts With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(billingContracts)
        billingContracts.Dock = DockStyle.Fill
        billingContracts.Show()
    End Sub

    Private Sub AppointmentScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListOfReservedToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AppointmentScheduleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AppointmentScheduleToolStripMenuItem1.Click
        Panel4.Controls.Clear()
        Dim appointment As New Appointment With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(appointment)
        appointment.Dock = DockStyle.Fill
        appointment.Show()
    End Sub

    Private Sub ListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim reservation As New Reservation With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(reservation)
        reservation.Dock = DockStyle.Fill
        reservation.Show()
    End Sub

    Private Sub OnTheDayScheduleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnTheDayScheduleToolStripMenuItem.Click
        Panel4.Controls.Clear()
        Dim onTheDay As New OnTheDay With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(onTheDay)
        onTheDay.Dock = DockStyle.Fill
        onTheDay.Show()
    End Sub

    Private Sub DashboardBtn_Click(sender As Object, e As EventArgs) Handles DashboardBtn.Click
        Panel4.Controls.Clear()
        Dim dashboard As New Dashboard With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(dashboard)
        dashboard.Dock = DockStyle.Fill
        dashboard.Show()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs)

    End Sub
End Class