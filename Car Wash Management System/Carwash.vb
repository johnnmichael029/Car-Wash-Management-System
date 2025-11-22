Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Data.SqlClient

Public Class Carwash
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private PrivateFonts As New PrivateFontCollection()
    Private Sub Carwash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DashboardFormLoad()
        NotificationLoad()
        PopulateAllTotal()
        HideButtons()



    End Sub

    Private Sub HideButtons()
        revenueCustomerBtn.Visible = False
        salesBtn.Visible = False
        averageSaleBtn.Visible = False
        salesSummaryBtn.Visible = False
        revenueServiceBtn.Visible = False
        RevenueCityAnalyticsBtn.Visible = False
    End Sub
    Private Sub ShowButtons()
        revenueCustomerBtn.Visible = True
        salesBtn.Visible = True
        averageSaleBtn.Visible = True
        salesSummaryBtn.Visible = True
        revenueServiceBtn.Visible = True
        RevenueCityAnalyticsBtn.Visible = True
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
        HideButtons()
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
        HideButtons()
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
        HideButtons()
    End Sub

    Private Sub AppointmentScheduleToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AppointmentScheduleToolStripMenuItem1.Click
        ShowNewAppointmentsTodayFormFunction()
        HideButtons()
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
        HideButtons()
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
        HideButtons()
    End Sub

    Private Sub DashboardBtn_Click(sender As Object, e As EventArgs) Handles DashboardBtn.Click
        DashboardFormShow()
        HideButtons()
    End Sub
    Private Sub DashboardFormShow()
        Panel4.Controls.Clear()
        Dim dashboard As New Dashboard With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(dashboard)
        dashboard.Dock = DockStyle.Fill
        dashboard.Show()
        DashboardBtn.BackColor = Color.FromArgb(239, 238, 238)
        ActivityLogBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White
    End Sub
    Private Sub ActivityLogBtn_Click(sender As Object, e As EventArgs) Handles ActivityLogBtn.Click
        ActivityLogFormShow()
        HideButtons()
    End Sub

    Private Sub ActivityLogFormShow()
        Panel4.Controls.Clear()
        Dim activityLog As New ActivityLog With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(activityLog)
        activityLog.Dock = DockStyle.Fill
        activityLog.Show()
        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesHistoryBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White
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
        HideButtons()
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
        UpdateEarningsDisplay()
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
        HideButtons()
        HideButtons()
    End Sub
    Private Sub ContractsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContractsToolStripMenuItem.Click
        ShowNewContractsTodayFormFunction()
    End Sub
    Private Sub PictureBoxCustomer_Click(sender As Object, e As EventArgs) Handles PictureBoxCustomer.Click
        ShowNewCustomersFormFunction()
        HideButtons()
    End Sub
    Private Sub PictureBoxContracts_Click(sender As Object, e As EventArgs) Handles PictureBoxContracts.Click
        ShowNewContractsTodayFormFunction()
        HideButtons()
    End Sub
    Private Sub PictureBoxSchedule_Click(sender As Object, e As EventArgs) Handles PictureBoxSchedule.Click
        ShowNewAppointmentsTodayFormFunction()
        HideButtons()
    End Sub
    Private Sub PickUpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PickUpToolStripMenuItem.Click
        PickUp()
        HideButtons()
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

        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White

        revenueCustomerBtn.Visible = False
        revenueServiceBtn.Visible = False
        salesSummaryBtn.Visible = False
        salesBtn.Visible = False
        averageSaleBtn.Visible = False
    End Sub
    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click

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
        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub salesHistoryBtn_Click(sender As Object, e As EventArgs) Handles salesHistoryBtn.Click
        SalesHistoryForm()
        HideButtons()

    End Sub

    Private Sub AnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim slesAnalytics As New SalesAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(slesAnalytics)
        slesAnalytics.Dock = DockStyle.Fill
        slesAnalytics.Show()
        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.White


        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
        RevenueCityAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub
    Private Sub SaleAnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim salesMadeAnalyticsvb As New SalesMadeAnalyticsvb With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(salesMadeAnalyticsvb)
        salesMadeAnalyticsvb.Dock = DockStyle.Fill
        salesMadeAnalyticsvb.Show()
        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.White
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles SalesAnalyticsBtn.Click
        AnalyticsShowForm()
        ShowButtons()
    End Sub
    Private Sub UpdateEarningsDisplay()
        Dim earningsData As CarwashDatabaseHelper = CarwashDatabaseHelper.GetEarningsData()

        ' 1. Update the Main Earnings Value (e.g., 13213)
        Dim earningsValue As Decimal = earningsData.CurrentDayEarnings - earningsData.PreviousDayEarnings
        LabelEarningsValue.Text = "₱" & earningsValue.ToString("N2")
        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color

        If earningsData.PercentageChangeEarnings > 0 Then
            ' UP/GREEN
            PictureBoxUpEarnings.Visible = True
            PictureBoxDownEarnings.Visible = False
            colorToUse = Color.Green
            LabelEarningsValue.ForeColor = Color.Green
        ElseIf earningsData.PercentageChangeEarnings < 0 Then
            ' DOWN/RED
            PictureBoxUpEarnings.Visible = False
            PictureBoxDownEarnings.Visible = True
            colorToUse = Color.Red
            LabelEarningsValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            colorToUse = Color.Gray
            LabelEarningsValue.ForeColor = Color.Gray
            PictureBoxUpEarnings.Visible = False
            PictureBoxDownEarnings.Visible = False

        End If
        Dim displayPercentage As Decimal = Math.Abs(earningsData.PercentageChangeEarnings)
        LabelPercentageEarnings.Text = displayPercentage.ToString("N0") & "%"
        LabelPercentageEarnings.ForeColor = colorToUse
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
        HideButtons()
    End Sub

    Private Sub salesBtn_Click(sender As Object, e As EventArgs) Handles salesBtn.Click
        SaleAnalyticsShowForm()
    End Sub

    Private Sub averageSaleBtn_Click(sender As Object, e As EventArgs) Handles averageSaleBtn.Click
        AverageSaleAnalyticsShowForm()
    End Sub
    Private Sub AverageSaleAnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim averageSaleAnalytics As New AverageSaleAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(averageSaleAnalytics)
        averageSaleAnalytics.Dock = DockStyle.Fill
        averageSaleAnalytics.Show()

        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
        RevenueCityAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub

    Private Sub salesSummaryBtn_Click(sender As Object, e As EventArgs) Handles salesSummaryBtn.Click
        SaleSummaryAnalyticsShowForm()
    End Sub
    Private Sub SaleSummaryAnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim saleSummaryAnalytics As New SaleSummaryAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(saleSummaryAnalytics)
        saleSummaryAnalytics.Dock = DockStyle.Fill
        saleSummaryAnalytics.Show()

        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.White
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
        RevenueCityAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub

    Private Sub revenueCustomerBtn_Click(sender As Object, e As EventArgs) Handles revenueCustomerBtn.Click
        RevenueCustomerAnalyticsShowForm()
    End Sub
    Private Sub RevenueServiceAnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim RevenueServiceAnalytics As New RevenueServiceAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(RevenueServiceAnalytics)
        RevenueServiceAnalytics.Dock = DockStyle.Fill
        RevenueServiceAnalytics.Show()

        revenueServiceBtn.BackColor = Color.White
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
        RevenueCityAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub
    Private Sub RevenueCustomerAnalyticsShowForm()
        Panel4.Controls.Clear()
        Dim revenueCustomerAnalytics As New RevenueCustomerAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(revenueCustomerAnalytics)
        revenueCustomerAnalytics.Dock = DockStyle.Fill
        revenueCustomerAnalytics.Show()

        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.White
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
        RevenueCityAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub

    Private Sub revenueServiceBtn_Click(sender As Object, e As EventArgs) Handles revenueServiceBtn.Click
        RevenueServiceAnalyticsShowForm()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub AddUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddUserToolStripMenuItem.Click
        AdminShowForm()
        HideButtons()
    End Sub

    Private Sub EmployeeInformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeInformationToolStripMenuItem.Click
        EmployeeInformationShowForm()
    End Sub
    Private Sub EmployeeInformationShowForm()
        Panel4.Controls.Clear()
        Dim EmployeeInformation As New EmployeeInformation With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(EmployeeInformation)
        EmployeeInformation.Dock = DockStyle.Fill
        EmployeeInformation.Show()
        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White

        revenueCustomerBtn.Visible = False
        revenueServiceBtn.Visible = False
        salesSummaryBtn.Visible = False
        salesBtn.Visible = False
        averageSaleBtn.Visible = False
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        EmployeeInformationSettingsForm()
    End Sub

    Private Sub EmployeeInformationSettingsForm()

        Settings.ShowDialog()
        DashboardBtn.BackColor = Color.White
        ActivityLogBtn.BackColor = Color.White
        salesHistoryBtn.BackColor = Color.White
        SalesAnalyticsBtn.BackColor = Color.White

        revenueCustomerBtn.Visible = False
        revenueServiceBtn.Visible = False
        salesSummaryBtn.Visible = False
        salesBtn.Visible = False
        averageSaleBtn.Visible = False
    End Sub

    Private Sub RevenueCityBtn_Click(sender As Object, e As EventArgs) Handles RevenueCityAnalyticsBtn.Click
        RevenueCityShowForm()
    End Sub

    Private Sub RevenueCityShowForm()
        Panel4.Controls.Clear()
        Dim RevenueCityAnalytics As New RevenueCityAnalytics With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }
        Panel4.Controls.Add(RevenueCityAnalytics)
        RevenueCityAnalytics.Dock = DockStyle.Fill
        RevenueCityAnalytics.Show()


        RevenueCityAnalyticsBtn.BackColor = Color.White
        revenueServiceBtn.BackColor = Color.FromArgb(239, 238, 238)
        revenueCustomerBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesSummaryBtn.BackColor = Color.FromArgb(239, 238, 238)
        salesBtn.BackColor = Color.FromArgb(239, 238, 238)
        averageSaleBtn.BackColor = Color.FromArgb(239, 238, 238)
        SalesAnalyticsBtn.BackColor = Color.FromArgb(239, 238, 238)
    End Sub
End Class
