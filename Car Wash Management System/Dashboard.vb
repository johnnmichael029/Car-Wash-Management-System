
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient


Public Class Dashboard
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesData()
        LoadSalesChart()
        LoadActivityLog()

    End Sub
    Private Sub LoadActivityLog()
        dashboardManagement.LoadActivityLog(DataGridViewActivityLog)
    End Sub

    Private Sub LoadSalesData()
        Dim salesData As DataTable = dashboardManagement.ViewSalesData()
        DataGridView1.DataSource = salesData

        Dim totalSales As Decimal = dashboardManagement.GetTodayTotalSales()
        LabelTotalSalesToday.Text = "₱" & totalSales.ToString("N2")

        Dim totalNewCustomers As Integer = dashboardManagement.GetTotalNewCustomers()
        LabelTotalCustomerToday.Text = totalNewCustomers.ToString()

        Dim totalAppointments As Integer = dashboardManagement.GetTotalAppointments()
        LabelTotalNewScheduleToday.Text = totalAppointments.ToString()

        Dim totalContracts As Integer = dashboardManagement.GetTotalContracts()
        LabelTotalNewContractToday.Text = totalContracts.ToString()
    End Sub

    Private Sub LoadSalesChart()
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String

        If isYearlyView Then
            chartData = dashboardManagement.GetYearlySales()
            chartTitle = "Yearly Sales"
            xAxisTitle = "Year"
        ElseIf isMonthlyView Then
        chartData = dashboardManagement.GetMonthlySales()
            chartTitle = "Monthly Sales"
            xAxisTitle = "Month"
        Else
            chartData = dashboardManagement.GetWeeklySales()
            chartTitle = "Weekly Sales"
            xAxisTitle = "Day"
        End If
        Dim salesChartForm As New SalesChartForm(chartData, chartTitle, xAxisTitle) With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }

        PanelMontlySales.Controls.Clear()
        PanelMontlySales.Controls.Add(salesChartForm)
        salesChartForm.Dock = DockStyle.Fill
        salesChartForm.Show()
    End Sub

    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        'Toggle On and Off
        isMonthlyView = Not isMonthlyView And Not isYearlyView
        isYearlyView = Not isYearlyView And Not isMonthlyView
        If isYearlyView Then
            ButtonToggleChart.Text = "Weekly Sales"
        ElseIf isMonthlyView Then
            ButtonToggleChart.Text = "Yearly Sales"
        Else
            ButtonToggleChart.Text = "Monthly Sales"
        End If
        LoadSalesChart()
    End Sub

    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        TextBoxSearchBar.Text = ""
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        If String.IsNullOrWhiteSpace(TextBoxSearchBar.Text) Then
            Dim salesData As DataTable = dashboardManagement.ViewSalesData()
            DataGridView1.DataSource = salesData
        Else
            Dim salesData As DataTable = dashboardManagement.GetListInSearchBar(Trim(TextBoxSearchBar.Text))
            DataGridView1.DataSource = salesData
        End If
    End Sub
End Class

Public Class SalesChartForm
    Inherits Form
    Private ReadOnly chart1 As Chart

    Public Sub New(salesData As DataTable, chartTitle As String, xAxisTitle As String)
        Me.Text = chartTitle
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        chart1 = New Chart()
        Me.Controls.Add(chart1)
        chart1.Size = New Size(750, 500)
        chart1.Location = New Point(10, 10)
        chart1.Dock = DockStyle.Fill


        Dim chartArea1 As New ChartArea With {
            .Name = "ChartArea1"
        }
        chart1.ChartAreas.Add(chartArea1)

        Dim series1 As New Series With {
            .Name = "Sales",
            .LabelForeColor = Color.Black,
            .ChartType = SeriesChartType.Line,
            .BorderWidth = 3,
            .Color = Color.Black,
            .MarkerStyle = MarkerStyle.Circle,
            .MarkerSize = 10,
            .MarkerColor = Color.Black
        }
        chart1.Series.Add(series1)

        ' Set the title of the chart.
        Dim title1 As New Title With {
            .Text = chartTitle,
            .Font = New Font("Century Gothic", 15, FontStyle.Bold)
        }
        chart1.Titles.Add(title1)

        ' Customize the axes dynamically based on the input.
        chart1.ChartAreas("ChartArea1").AxisX.Title = xAxisTitle
        chart1.ChartAreas("ChartArea1").AxisY.Title = "Total Sales (₱)"
        chart1.ChartAreas("ChartArea1").AxisX.Interval = 1

        ' Load data into the chart.
        LoadChartData(salesData, xAxisTitle)
    End Sub

    Private Sub LoadChartData(salesData As DataTable, xAxisTitle As String)
        chart1.Series("Sales").Points.Clear()

        For Each row As DataRow In salesData.Rows
            If xAxisTitle = "Year" Then
                Dim salesYear As Integer = row("SalesYear")
                Dim salesTotal As Decimal = row("TotalSales")
                chart1.Series("Sales").Points.AddXY(salesYear, salesTotal)
            ElseIf xAxisTitle = "Month" Then
                Dim salesYear As Integer = row("SalesYear")
                Dim salesMonth As Integer = row("SalesMonth")
                Dim salesTotal As Decimal = row("TotalSales")
                Dim monthName As String = New Date(salesYear, salesMonth, 1).ToString("MMM yyy")
                chart1.Series("Sales").Points.AddXY(monthName, salesTotal)
            ElseIf xAxisTitle = "Day" Then
                Dim salesDate As Date = row("SaleDate")
                Dim salesTotal As Decimal = row("TotalSales")
                chart1.Series("Sales").Points.AddXY(salesDate.ToString("M/d"), salesTotal)
            End If
        Next
    End Sub
End Class

Public Class DashboardManagement
    Private ReadOnly constr As String

    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Function ViewSalesData() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(constr)
            conn.Open()
            Dim ViewQuery As String = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s
                                     INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
                                     INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
                                     LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SalesID DESC"
            Using cmd As New SqlCommand(ViewQuery, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Function GetYearlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate) ORDER BY SalesYear"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetYearlySales: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetMonthlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, MONTH(SaleDate) AS SalesMonth, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate), MONTH(SaleDate) ORDER BY SalesYear, SalesMonth"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetMonthlySales: " & ex.Message)
        End Try
        Return dt
    End Function

    Public Function GetWeeklySales() As DataTable
        Dim query As String = "SELECT CAST(SaleDate AS DATE) AS SaleDate, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable WHERE SaleDate >= DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) GROUP BY CAST(SaleDate AS DATE) ORDER BY SaleDate ASC"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
        End Try
        Return dt
    End Function

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

    Public Function GetTotalContracts() As Integer
        Dim totalContracts As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM BillingContracts WHERE CAST(StartDate AS DATE) = CAST(GETDATE() AS DATE)"
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

    Public Function GetListInSearchBar(searchInBar As String) As DataTable
        Dim dt As New DataTable()

        Dim query As String = "
            SELECT
                s.SalesID,
                c.Name AS CustomerName,
                sv.ServiceName AS BaseServiceName,
                sv_addon.ServiceName AS AddonServiceName,
                s.SaleDate,
                s.PaymentMethod,
                s.TotalPrice
            FROM SalesHistoryTable s
            INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
            INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
            LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID
            WHERE c.Name LIKE @searchString
            OR sv.ServiceName LIKE @searchString
            OR sv_addon.ServiceName LIKE @searchString
            OR s.SalesID LIKE @searchString
            OR s.PaymentMethod LIKE @searchString
            "
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@searchString", "%" & searchInBar & "%")
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                Catch ex As Exception
                    Console.WriteLine("Error in GetListInSearchBar: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
        Return dt
    End Function

    Public Sub LogActivity(action As String, description As String)
        Try
            Using conn As New SqlConnection(constr)
                conn.Open()
                Dim insertActivityLogQuery As String = "INSERT INTO ActivityLogTable (ActionType, Description, Timestamp) VALUES (@action, @description, @timestamp)"
                Using cmd As New SqlCommand(insertActivityLogQuery, conn)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

            MessageBox.Show("Error logging activity: " & ex.Message)
        End Try
    End Sub
    Public Sub AddNewCustomer(customerName As String)
        LogActivity("New Customer Added", $"A new customer '{customerName}' was added to the system.")
    End Sub
    Public Sub AddNewService(serviceName As String)
        LogActivity("New Service Added", $"A new service '{serviceName}' was added to the system.")
    End Sub
    Public Sub RecordSale(customerName As String, amount As Decimal)
        LogActivity("New Sale", $"A new sale was recorded for customer: '{customerName}'. Amount: ₱{amount:N2}")
    End Sub
    Public Sub ScheduleAppointment(customerName As String, appointmentDate As DateTime, appointmentStatus As String)
        LogActivity("New Appointment Scheduled", $"An appointment was scheduled for customer: '{customerName}' on {appointmentDate}. status '{appointmentStatus}'")
    End Sub
    Public Sub UpdateAppointmentStatus(customerName As String, newStatus As String)
        LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub RecordActivity(customerName As String, newStatus As String)
        LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub AddNewContract(customerName As String)
        LogActivity("New Contract Added", $"A new contract was created for: '{customerName}'.")
    End Sub
    Public Sub UpdateContractStatus(customerName As String, newStatus As String)
        LogActivity("Contract Status Update", $"Contract for '{customerName}' was changed to new status '{newStatus}'.")
    End Sub
    Public Sub UserLogout(username As String)
        LogActivity("User Logout", $"User '{username}' logged out of the system.")
    End Sub

    Public Sub UserLogin(username As String)
        LogActivity("User Login", $"User '{username}' logged into the system.")
    End Sub
    Public Sub LoadActivityLog(ByVal dataGrid As DataGridView)
        Try
            Using conn As New SqlConnection(constr)
                conn.Open()
                Dim selectActivityLogQuery As String = "SELECT ActionType, Description, Timestamp FROM ActivityLogTable ORDER BY LogID DESC"
                Using cmd As New SqlCommand(selectActivityLogQuery, conn)
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dataTable As New DataTable()
                        adapter.Fill(dataTable)
                        dataGrid.DataSource = dataTable
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading activity log: " & ex.Message)
        End Try
    End Sub

End Class