Imports System.Drawing.Text
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Data.SqlClient

Public Class Carwash

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Dim listOfActivityLog As New ListOfActivityLog(constr)
    Private ReadOnly carwashManagement As CarwashManagement
    'Private isFullScreen As Boolean = False
    'Private originalIcon As Icon
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        carwashManagement = New CarwashManagement(constr)
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
            listOfActivityLog.UserLogout(username)
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
    Private Sub ShowNewCustomersFormFunction()
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
        Dim notification As New Notification()
        Dim btnScreenLocation As Point = NotificationBtn.PointToScreen(New Point(149, 0))
        notification.Top = btnScreenLocation.Y + NotificationBtn.Height
        notification.Left = btnScreenLocation.X
        notification.Show()
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
        Dim totalSales As Decimal = carwashManagement.GetTodayTotalSales()
        LabelTotalSalesToday.Text = "₱" & totalSales.ToString("N2")

        Dim totalNewCustomers As Integer = carwashManagement.GetTotalNewCustomers()
        LabelNewCustomer.Text = totalNewCustomers.ToString()

        Dim totalAppointments As Integer = carwashManagement.GetTotalAppointments()
        LabelTotalNewScheduleToday.Text = totalAppointments.ToString()

        Dim totalContracts As Integer = carwashManagement.GetTotalContracts()
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


End Class
Public Class CarwashManagement
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    ''' <summary>
    ''' Gets the total sales for today from the SalesHistoryTable.
    ''' </summary>
    Public Function GetTodayTotalSales() As Decimal
        Dim totalSales As Decimal = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT SUM(TotalPrice) FROM SalesHistoryTable WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalSales = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in GetTodayTotalSales: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalSales
    End Function
    ''' <summary>
    ''' Gets the total number of new customers registered today from the CustomersTable.
    ''' </summary>
    Public Function GetTotalNewCustomers() As Integer
        Dim totalNewCustomers As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM CustomersTable WHERE CAST(RegistrationDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalNewCustomers = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalNewCustomers: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalNewCustomers
    End Function
    ''' <summary>
    ''' Gets the total number of confirmed appointments scheduled for today from the AppointmentsTable.
    ''' </summary>
    Public Function GetTotalAppointments() As Integer
        Dim totalAppointments As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM AppointmentsTable
                                 WHERE CAST(AppointmentDateTime AS DATE) = CAST(GETDATE() AS DATE)
                                 AND AppointmentStatus = 'Confirmed'"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalAppointments = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalAppointments: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalAppointments
    End Function
    ''' <summary>
    ''' Gets the total number of new contracts created today from the ContractsTable.
    ''' </summary>
    Public Function GetTotalContracts() As Integer
        Dim totalContracts As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM ContractsTable WHERE CAST(StartDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalContracts = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalContracts: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalContracts
    End Function
    ''' <summary>
    ''' Gets the list of sales records matching the search string from the SalesHistoryTable along with Customer and Service details.
    ''' </summary>
End Class