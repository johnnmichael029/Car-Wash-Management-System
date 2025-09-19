Imports System.Drawing.Text
Imports System.Runtime.InteropServices

Public Class Carwash
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)
    Private Sub Dashboard1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
    End Sub

    Private PrivateFonts As New PrivateFontCollection()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DashboardFormLoad()
        NotificationLoad()
    End Sub
    Private Sub NotificationLoad()
        NotificationTimer.Interval = 3000
        NotificationTimer.Enabled = False
    End Sub
    Private Sub DashboardFormLoad()
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

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        DialogResult = MessageBox.Show("Are you sure you want to logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If DialogResult = DialogResult.Yes Then
            Me.Hide()
            Login.Show()
            Dim username As String = Login.TextBoxUsername.Text
            dashboardManagement.UserLogout(username)
        End If


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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If PanelMenuBar.Width > 55 Then
            PanelMenuBar.Width -= 25
        Else
            Timer1.Enabled = False
        End If

    End Sub

    Private Sub MenuBtn_Click(sender As Object, e As EventArgs) Handles MenuBtn.Click
        If PanelMenuBar.Width = 177 Then
            Timer1.Enabled = True

        Else
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If PanelMenuBar.Width < 177 Then
            PanelMenuBar.Width += 25
        Else
            Timer2.Enabled = False
        End If
    End Sub


    Private Sub NotificationBtn_Click(sender As Object, e As EventArgs) Handles NotificationBtn.Click
        Dim notification As New Notification()

        ' Get the screen coordinates of the top-left corner of the button.
        ' This converts the button's location on Form1 to its location on the user's screen.
        Dim btnScreenLocation As Point = NotificationBtn.PointToScreen(New Point(149, 0))

        ' Set the new form's position.
        ' We want the notification form to appear just below the button.
        ' So, we set its Left position to the button's Left screen coordinate,
        ' and its Top position to the button's Top screen coordinate plus the button's height.
        notification.Top = btnScreenLocation.Y + NotificationBtn.Height
        notification.Left = btnScreenLocation.X

        ' Show the notification form.
        notification.Show()

    End Sub

    Private Sub NotificationTimer_Tick(sender As Object, e As EventArgs) Handles NotificationTimer.Tick
        NotificationTimer.Stop()

        ' Then, hide the label.
        NotificationLabel.Visible = False
    End Sub
    Public Sub ShowNotification()
        NotificationTimer.Enabled = False
        NotificationTimer.Enabled = True
        NotificationLabel.Visible = True
    End Sub
End Class