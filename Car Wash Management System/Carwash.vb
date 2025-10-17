Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Data.SqlClient

Public Class Carwash

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Dim activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private ReadOnly carwashDatabaseHelper As CarwashDatabaseHelper
    'Private isFullScreen As Boolean = False
    'Private originalIcon As Icon
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        carwashDatabaseHelper = New CarwashDatabaseHelper(constr)
    End Sub

    Private PrivateFonts As New PrivateFontCollection()
    Private Sub Carwash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DashboardFormLoad()
        NotificationLoad()
        PopulateAllTotal()
    End Sub

    Private Sub NotificationLoad()
        NotificationTimer.Interval = 3000
        NotificationTimer.Enabled = False
    End Sub
    Public Sub DashboardFormLoad()
        Panel4.Controls.Clear()
        Dim dashboard As New Dashboard With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(dashboard)
        dashboard.Dock = DockStyle.Fill
        dashboard.Show()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub LogoutBtn_Click(sender As Object, e As EventArgs) Handles LogoutBtn.Click
        DialogResult = MessageBox.Show("Are you sure you want to logout?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
        If DialogResult = DialogResult.Yes Then
            Me.Hide()
            Login.Show()
            Dim username As String = Login.TextBoxUsername.Text
            activityLogInDashboardService.UserLogout(username)
        End If
    End Sub

    Private Sub CustomerInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerInformationToolStripMenuItem.Click
        ShowNewCustomersFormFunction()
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
    Private Sub ShowSalesFormFunction()
        Panel4.Controls.Clear()
        Dim salesHistory As New SalesForm With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(salesHistory)
        salesHistory.Dock = DockStyle.Fill
        salesHistory.Show()
    End Sub
    Private Sub ShowNewContractsTodayFormFunction()
        Panel4.Controls.Clear()
        Dim billingContracts As New Contracts With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(billingContracts)
        billingContracts.Dock = DockStyle.Fill
        billingContracts.Show()
    End Sub
    Public Sub ShowNewCustomersFormFunction()
        Panel4.Controls.Clear()
        Dim customerInformation As New CustomerInformation With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(customerInformation)
        customerInformation.Dock = DockStyle.Fill
        customerInformation.Show()

    End Sub
    Private Sub ShowNewAppointmentsTodayFormFunction()
        Panel4.Controls.Clear()
        Dim appointment As New Appointment With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(appointment)
        appointment.Dock = DockStyle.Fill
        appointment.Show()
    End Sub
    Private Sub ShowActivityLogFormFunction()
        Panel4.Controls.Clear()
        Dim activityLog As New ActivityLog With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(activityLog)
        activityLog.Dock = DockStyle.Fill
        activityLog.Show()
    End Sub
    Private Sub SaleHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleHistoryToolStripMenuItem.Click
        ShowSalesFormFunction()
    End Sub

    Private Sub AppointmentScheduleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AppointmentScheduleToolStripMenuItem1.Click
        ShowNewAppointmentsTodayFormFunction()
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
    Private Sub ActivityLogBtn_Click(sender As Object, e As EventArgs) Handles ActivityLogBtn.Click
        Panel4.Controls.Clear()
        Dim activityLog As New ActivityLog With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(activityLog)
        activityLog.Dock = DockStyle.Fill
        activityLog.Show()
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
        ShowActivityLogFormFunction()
    End Sub

    Private Sub NotificationTimer_Tick(sender As Object, e As EventArgs) Handles NotificationTimer.Tick
        NotificationTimer.Stop()
        NotificationLabel.Visible = False
    End Sub
    Public Sub ShowNotification()
        NotificationTimer.Enabled = False
        NotificationTimer.Enabled = True
        NotificationLabel.Visible = True
    End Sub

    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.Exit()
    End Sub
    Public Sub PopulateAllTotal()
        Dim totalSales As Decimal = carwashDatabaseHelper.GetTodayTotalSales()
        LabelTotalSalesToday.Text = "₱" & totalSales.ToString("N2")

        Dim totalNewCustomers As Integer = carwashDatabaseHelper.GetTotalNewCustomers()
        LabelNewCustomer.Text = totalNewCustomers.ToString()

        Dim totalAppointments As Integer = carwashDatabaseHelper.GetTotalAppointments()
        LabelTotalNewScheduleToday.Text = totalAppointments.ToString()

        Dim totalContracts As Integer = carwashDatabaseHelper.GetTotalContracts()
        LabelTotalNewContractToday.Text = totalContracts.ToString()
    End Sub
    Private Sub PictureBoxSales_Click(sender As Object, e As EventArgs) Handles PictureBoxSales.Click
        ShowSalesFormFunction()
    End Sub
    Private Sub ContractsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContractsToolStripMenuItem.Click
        ShowNewContractsTodayFormFunction()
    End Sub
    Private Sub PictureBoxCustomer_Click(sender As Object, e As EventArgs) Handles PictureBoxCustomer.Click
        ShowNewCustomersFormFunction()
    End Sub
    Private Sub PictureBoxContracts_Click(sender As Object, e As EventArgs) Handles PictureBoxContracts.Click
        ShowNewContractsTodayFormFunction()
    End Sub
    Private Sub PictureBoxSchedule_Click(sender As Object, e As EventArgs) Handles PictureBoxSchedule.Click
        ShowNewAppointmentsTodayFormFunction()
    End Sub
    Private Sub PickUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickUpToolStripMenuItem.Click
        PickUp()
    End Sub
    Private Sub PickUp()
        Panel4.Controls.Clear()
        Dim pickUp As New PickUp With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(pickUp)
        pickUp.Dock = DockStyle.Fill
        pickUp.Show()
    End Sub
    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        AdminShowForm()
    End Sub
    Private Sub AdminShowForm()
        Panel4.Controls.Clear()
        Dim admmin As New Admin With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(admmin)
        admmin.Dock = DockStyle.Fill
        admmin.Show()
    End Sub
    Private Sub SalesHistoryForm()
        Panel4.Controls.Clear()
        Dim salesHistory As New SalesHistory With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(salesHistory)
        salesHistory.Dock = DockStyle.Fill
        salesHistory.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub salesHistoryBtn_Click(sender As Object, e As EventArgs) Handles salesHistoryBtn.Click
        SalesHistoryForm()
    End Sub
End Class
