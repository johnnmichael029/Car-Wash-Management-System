Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class SalesAnalytics
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private currentPeriod As String = "Day" ' Default view
    Private pieChart As Chart
    Private barGraph As Chart
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private currentSearchTerm As String = String.Empty

    Private Sub SalesAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateAllTotal(currentPeriod)
        UpdateEarningsDisplay(currentPeriod)
        UpdateCustomersDisplay(currentPeriod)
        UpdateServiceDisplay(currentPeriod)
        LoadServicesChart()
        LoadCustomersChart()
        LoadBarGraphAverage()
        LoadSalesChart()
        ViewSalesSummary()
        ChangeHeadrOfDataGridViewSalesSummary()
        DataGridSalesSummaryFontStyle()

    End Sub
    Private Sub LoadServicesChart()
        SetupPieChartControlInCustomers()
        InitializeChartStructureInCustomers()
        LoadCustomersData()
    End Sub
    Private Sub LoadCustomersChart()
        SetupPieChartControl()
        InitializeChartStructure()
        LoadServiceData()
    End Sub

    Private Sub LoadBarGraphAverage()
        SetupBarChartControl()
        InitializeBarGraphStructure()
        LoadAverageData(currentPeriod)
    End Sub
    Public Sub PopulateAllTotal(period As String)

        Select Case period.ToLower()
            Case "day"
                Dim earnings As Integer = SalesAnalyticsDatabaseHelper.GetDynamicEarnings("DAY")
                LabelOrders.Text = SalesAnalyticsDatabaseHelper.GetDynamicService("DAY")
                LabelCustomers.Text = SalesAnalyticsDatabaseHelper.GetDynamicCustomers("DAY")
                LabelEarnings.Text = earnings.ToString("N2")
                LabelEarningsPeriod.Text = "This Day"
                LabelServicePeriod.Text = "This Day"
                LabelCustomersPeriod.Text = "This Day"
            Case "month"
                Dim earnings As Integer = SalesAnalyticsDatabaseHelper.GetDynamicEarnings("MONTH")
                LabelOrders.Text = SalesAnalyticsDatabaseHelper.GetDynamicService("MONTH")
                LabelCustomers.Text = SalesAnalyticsDatabaseHelper.GetDynamicCustomers("MONTH")
                LabelEarnings.Text = earnings.ToString("N2")
                LabelEarningsPeriod.Text = "This Month"
                LabelServicePeriod.Text = "This Month"
                LabelCustomersPeriod.Text = "This Month"
            Case "year"
                Dim earnings As Integer = SalesAnalyticsDatabaseHelper.GetDynamicEarnings("YEAR")
                LabelOrders.Text = SalesAnalyticsDatabaseHelper.GetDynamicService("YEAR")
                LabelCustomers.Text = SalesAnalyticsDatabaseHelper.GetDynamicCustomers("YEAR")
                LabelEarnings.Text = earnings.ToString("N2")
                LabelEarningsPeriod.Text = "This Year"
                LabelServicePeriod.Text = "This Year"
                LabelCustomersPeriod.Text = "This Year"
            Case Else
                ' Default to month if invalid input
                MessageBox.Show("Invalid period specified for earnings data. Defaulting to Monthly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select
    End Sub

    '--- UPDATE EARNINGS, CUSTOMERS, SERVICE DISPLAY ---'
    Private Sub UpdateEarningsDisplay(period As String)
        Dim earningsData As SalesAnalyticsDatabaseHelper

        Select Case period.ToLower()
            Case "day"
                earningsData = SalesAnalyticsDatabaseHelper.GetDynamicEarningsData("DAY")
            Case "month"
                earningsData = SalesAnalyticsDatabaseHelper.GetDynamicEarningsData("MONTH")
            Case "year"
                earningsData = SalesAnalyticsDatabaseHelper.GetDynamicEarningsData("YEAR")
            Case Else
                ' Default to month if invalid input
                MessageBox.Show("Invalid period specified for earnings data. Defaulting to Monthly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select


        ' 1. Update the Main Earnings Value (e.g., 13213)
        Dim earningsValue As Decimal = earningsData.CurrentMonthEarnings - earningsData.PreviousMonthEarnings
        LabelEarningsValue.Text = "₱" & earningsValue.ToString("N2")
        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color

        If earningsData.PercentageChangeEarnings > 0 Then
            ' UP/GREEN
            PictureBoxUpArrow.Visible = True
            PictureBoxDownArrow.Visible = False
            colorToUse = Color.Green
            LabelEarningsValue.ForeColor = Color.Green
        ElseIf earningsData.PercentageChangeEarnings < 0 Then
            ' DOWN/RED
            PictureBoxUpArrow.Visible = False
            PictureBoxDownArrow.Visible = True
            colorToUse = Color.Red
            LabelEarningsValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            colorToUse = Color.Gray
            LabelEarningsValue.ForeColor = Color.Gray
            PictureBoxUpArrow.Visible = False
            PictureBoxDownArrow.Visible = False
        End If
        Dim displayPercentage As Decimal = Math.Abs(earningsData.PercentageChangeEarnings)
        LabelPercentage.Text = displayPercentage.ToString("N0") & "%"
        LabelPercentage.ForeColor = colorToUse
    End Sub
    Private Sub UpdateCustomersDisplay(period As String)
        Dim customersData As SalesAnalyticsDatabaseHelper

        Select Case period.ToLower()
            Case "day"
                customersData = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData("DAY")
            Case "month"
                customersData = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData("MONTH")
            Case "year"
                customersData = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData("YEAR")
            Case Else
                ' Default to month if invalid input
                MessageBox.Show("Invalid period specified for service data. Defaulting to Monthly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select


        ' 1. Update the Main Earnings Value (e.g., 13213)
        LabelCustomersValue.Text = customersData.CurrentMonthCustomers.ToString("N0") - customersData.PreviousMonthCustomers.ToString("N0")  ' Formats as a number with no decimals

        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color

        If customersData.PercentageChangeCustomers > 0 Then
            ' UP/GREEN
            PictureBoxUpCustomers.Visible = True
            PictureBoxDownCustomers.Visible = False
            colorToUse = Color.Green
            LabelCustomersValue.ForeColor = Color.Green
        ElseIf customersData.PercentageChangeCustomers < 0 Then
            ' DOWN/RED
            PictureBoxUpCustomers.Visible = False
            PictureBoxDownCustomers.Visible = True
            colorToUse = Color.Red
            LabelCustomersValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            PictureBoxUpCustomers.Visible = False
            PictureBoxDownCustomers.Visible = False
            LabelCustomersValue.ForeColor = Color.Gray
            colorToUse = Color.Gray
        End If
        Dim displayPercentage As Decimal = Math.Abs(customersData.PercentageChangeCustomers)
        LabelPercentageCustomers.Text = displayPercentage.ToString("N0") & "%"
        LabelPercentageCustomers.ForeColor = colorToUse
    End Sub
    Private Sub UpdateServiceDisplay(period As String)
        Dim serviceData As SalesAnalyticsDatabaseHelper

        Select Case period.ToLower()
            Case "day"
                serviceData = SalesAnalyticsDatabaseHelper.GetDynamicServiceData("DAY")
            Case "month"
                serviceData = SalesAnalyticsDatabaseHelper.GetDynamicServiceData("MONTH")
            Case "year"
                serviceData = SalesAnalyticsDatabaseHelper.GetDynamicServiceData("YEAR")
            Case Else
                ' Default to month if invalid input
                MessageBox.Show("Invalid period specified for service data. Defaulting to Monthly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select


        ' 1. Update the Main Earnings Value (e.g., 13213)
        LabelServiceValue.Text = serviceData.CurrentMonthService.ToString("N0") - serviceData.PreviousMonthService.ToString("N0") ' Formats as a number with no decimals

        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color

        If serviceData.PercentageChangeService > 0 Then
            ' UP/GREEN
            PictureBoxUpService.Visible = True
            PictureBoxDownService.Visible = False
            colorToUse = Color.Green
            LabelServiceValue.ForeColor = Color.Green
        ElseIf serviceData.PercentageChangeService < 0 Then
            ' DOWN/RED
            PictureBoxUpService.Visible = False
            PictureBoxDownService.Visible = True
            colorToUse = Color.Red
            LabelServiceValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            LabelServiceValue.ForeColor = Color.Gray
            PictureBoxUpService.Visible = False
            PictureBoxDownService.Visible = False
            colorToUse = Color.Gray
        End If
        Dim displayPercentage As Decimal = Math.Abs(serviceData.PercentageChangeService)
        LabelPercentageService.Text = displayPercentage.ToString("N0") & "%"
        LabelPercentageService.ForeColor = colorToUse
    End Sub

    '--- PIE CHART FOR SERVICES REVENUE DISTRIBUTION ---'
    Private Sub SetupPieChartControl()
        If Me.Controls.Find("PanelChartAverage", True).Length = 0 Then
            MessageBox.Show("The PanelChartAverage control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        pieChart = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = PanelChartAverage.BackColor
        }
        PanelChartAverage.Controls.Add(pieChart)
    End Sub
    Private Sub InitializeChartStructure()
        Dim chartData As Chart = pieChart ' Use the dynamically created chart

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Revenue Distribution by Core Service (Live Data)")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        ' Create Chart Area and apply 3D styling
        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Inclination = 30
        chartArea.Area3DStyle.Rotation = 10

        ' Create the Series (the Pie itself)
        ' ----------------------------------------------------
        ' 1. Hide the percentage/value labels on the slices
        ' 2. Hide the service name label on the slices (no text inside the pie)
        ' ----------------------------------------------------
        Dim series1 As New Series With {
            .Name = "CoreServicesRevenue",
            .ChartType = SeriesChartType.Pie,
            .IsValueShownAsLabel = False,
            .LabelFormat = "P1", ' Format is still defined, but not shown
            .LegendText = "#VALX (#PERCENT)", ' Show service name and percentage in legend
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .XValueType = ChartValueType.String
        }

        ' --- CRITICAL ADDITION: DISABLE ALL PIE SLICE LABELS (Failsafe 3) ---
        series1.CustomProperties = "PieLabelStyle=Disabled"
        chartData.Series.Add(series1)

        ' Add a Legend
        Dim legend1 As New Legend With {
            .Docking = Docking.Bottom,
            .Alignment = StringAlignment.Center
        }
        chartData.Legends.Add(legend1)
    End Sub
    Private Sub LoadServiceData()
        If pieChart Is Nothing Then
            Console.WriteLine("Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = pieChart
        Dim series1 As Series = chartData.Series("CoreServicesRevenue")
        series1.Points.Clear() ' Clear any existing points

        Dim revenueData As New Dictionary(Of String, Double)

        Dim sql As String = SalesAnalyticsDatabaseHelper.GetDynamicSalesQuery()

        ' NOTE: Using ConnectionString property defined at class level
        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim serviceName As String = reader("ServiceName").ToString()
                        Dim totalRevenue As Double = Convert.ToDouble(reader("TotalRevenue"))

                        revenueData.Add(serviceName, totalRevenue)
                    End While

                    ' Calculate the total revenue for accurate percentage calculation in tooltip
                    Dim totalRevenueSum As Double = revenueData.Values.Sum()

                    ' 1. Populate the Chart with the data
                    For Each kvp In revenueData
                        Dim dataPoint As New DataPoint()
                        dataPoint.SetValueXY(kvp.Key, kvp.Value)

                        ' Set ToolTip for hover effect 
                        If totalRevenueSum > 0 Then
                            Dim percentage As Double = kvp.Value / totalRevenueSum
                            ' *** FIX HERE: Assign the tooltip to the specific dataPoint, not the entire series. ***
                            dataPoint.ToolTip = String.Format("{0}: {1:P1}", kvp.Key, percentage)
                        Else
                            ' Fallback if total is zero
                            dataPoint.ToolTip = kvp.Key
                        End If

                        series1.Points.Add(dataPoint)
                    Next

                    ' Failsafe 2: Ensure all individual point labels are empty (to remove 0%)
                    For Each point As DataPoint In series1.Points
                        point.Label = String.Empty
                    Next

                    ' 2. Custom Coloring (Optional)
                    ' Assign colors based on index, assuming consistent order
                    Dim colors As Color() = {Color.SteelBlue, Color.Gold, Color.DarkGreen, Color.DarkRed}
                    For i As Integer = 0 To series1.Points.Count - 1
                        If i < colors.Length Then
                            series1.Points(i).Color = colors(i)
                        End If
                    Next

                    ' 3. Find and Explode the largest revenue slice
                    If revenueData.Count > 0 Then
                        Dim maxRevenue As Double = revenueData.Values.Max()
                        ' Find the data point that corresponds to the max revenue
                        Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
                        If maxPoint IsNot Nothing AndAlso maxRevenue > 0 Then ' Only explode if max is greater than 0
                            maxPoint.CustomProperties = "Exploded=true"
                        End If
                    End If

                Catch ex As Exception
                    ' Display the specific database error to the user
                    MessageBox.Show("DATABASE ERROR: " & ex.Message & Environment.NewLine &
                                    "Please check your ConnectionString and ensure the SQL Server is running.",
                                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    '--- PIE CHART FOR CUSTOMERS REVENUE DISTRIBUTION ---'
    Private Sub SetupPieChartControlInCustomers()
        ' This function creates the Chart control and docks it to the specified panel.

        ' Find the panel control
        Dim chartPanel As Panel = TryCast(Me.Controls.Find("PanelChartCustomers", True).FirstOrDefault(), Panel)

        If chartPanel Is Nothing Then
            ' Corrected the error message reference
            MessageBox.Show("The PanelChartCustomers control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Clear any existing chart controls from the panel
        For Each ctrl As Control In chartPanel.Controls
            If TypeOf ctrl Is Chart Then
                chartPanel.Controls.Remove(ctrl)
                ctrl.Dispose()
                Exit For
            End If
        Next

        ' Create the new Chart instance
        pieChart = New Chart()

        ' Configure the Chart to fill the panel
        pieChart.Dock = DockStyle.Fill
        pieChart.BackColor = chartPanel.BackColor ' Match the background for seamless look

        ' Add the Chart to the Panel's controls collection
        chartPanel.Controls.Add(pieChart)
    End Sub
    Private Sub InitializeChartStructureInCustomers()
        Dim chartData As Chart = pieChart ' Use the dynamically created chart

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Revenue Distribution by Customers (Live Data)")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        ' Create Chart Area and apply 3D styling
        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Inclination = 30
        chartArea.Area3DStyle.Rotation = 10

        ' Create the Series (the Pie itself)
        ' ----------------------------------------------------
        ' 1. Hide the percentage/value labels on the slices
        ' 2. Hide the service name label on the slices (no text inside the pie)
        ' ----------------------------------------------------
        Dim series1 As New Series With {
            .Name = "CustomersRevenue",
            .ChartType = SeriesChartType.Pie,
            .IsValueShownAsLabel = False,
            .LabelFormat = "P1", ' Format is still defined, but not shown
            .LegendText = "#VALX (#PERCENT)", ' Show customer name and percentage in legend
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .XValueType = ChartValueType.String
        }

        ' --- CRITICAL ADDITION: DISABLE ALL PIE SLICE LABELS (Failsafe 3) ---
        series1.CustomProperties = "PieLabelStyle=Disabled"
        chartData.Series.Add(series1)

        ' Add a Legend
        Dim legend1 As New Legend With {
            .Docking = Docking.Bottom,
            .Alignment = StringAlignment.Center
        }
        chartData.Legends.Add(legend1)
    End Sub
    Private Sub LoadCustomersData()
        If pieChart Is Nothing Then
            Console.WriteLine("Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = pieChart
        ' Ensure the series exists before accessing it
        If chartData.Series.Count = 0 OrElse chartData.Series("CustomersRevenue") Is Nothing Then
            Console.WriteLine("Chart series 'CustomersRevenue' is not initialized.")
            Exit Sub
        End If

        Dim series1 As Series = chartData.Series("CustomersRevenue")
        series1.Points.Clear() ' Clear any existing points

        Dim revenueData As New Dictionary(Of String, Double)

        ' Call the function defined in this class
        Dim sql As String = SalesAnalyticsDatabaseHelper.GetDynamicCustomersQuery()

        ' NOTE: Using ConnectionString property defined at class level (replacing 'constr')
        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim customerName As String = reader("Name").ToString()
                        Dim totalRevenue As Double = Convert.ToDouble(reader("TotalRevenue"))

                        revenueData.Add(customerName, totalRevenue)
                    End While

                    reader.Close() ' Close the reader after use

                    ' Calculate the total revenue for accurate percentage calculation in tooltip
                    Dim totalRevenueSum As Double = revenueData.Values.Sum()

                    ' 1. Populate the Chart with the data
                    For Each kvp In revenueData
                        Dim dataPoint As New DataPoint()
                        dataPoint.SetValueXY(kvp.Key, kvp.Value)

                        ' Set ToolTip for hover effect - NOW INCLUDES CURRENCY VALUE
                        If totalRevenueSum > 0 Then
                            Dim percentage As Double = kvp.Value / totalRevenueSum
                            ' Tooltip shows Name, Currency Value in pesoz (₱), and Percentage (P1)
                            dataPoint.ToolTip = String.Format("{0}: ₱{1:N2} ({2:P1})", kvp.Key, kvp.Value, percentage)
                        Else
                            ' Fallback if total is zero
                            dataPoint.ToolTip = kvp.Key
                        End If

                        series1.Points.Add(dataPoint)
                    Next

                    ' Failsafe 2: Ensure all individual point labels are empty (to remove 0%)
                    For Each point As DataPoint In series1.Points
                        point.Label = String.Empty
                    Next

                    ' 2. Custom Coloring (Optional)
                    ' Assign colors based on index, assuming consistent order
                    Dim colors As Color() = {Color.SteelBlue, Color.Gold, Color.DarkGreen, Color.DarkRed, Color.BlueViolet, Color.Tomato}
                    For i As Integer = 0 To series1.Points.Count - 1
                        ' Use the modulo operator (%) to cycle through colors if there are more points than colors
                        series1.Points(i).Color = colors(i Mod colors.Length)
                    Next

                    ' 3. Find and Explode the largest revenue slice
                    If revenueData.Count > 0 Then
                        Dim maxRevenue As Double = revenueData.Values.Max()
                        ' Find the data point that corresponds to the max revenue
                        Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
                        If maxPoint IsNot Nothing AndAlso maxRevenue > 0 Then ' Only explode if max is greater than 0
                            maxPoint.CustomProperties = "Exploded=true"
                        End If
                    End If

                Catch ex As Exception
                    ' Display the specific database error to the user
                    MessageBox.Show("DATABASE ERROR: " & ex.Message & Environment.NewLine &
                                    "Please check your ConnectionString and ensure the SQL Server is running.",
                                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    '--- BAR CHART FOR AVERAGE SALES PER PERIOD ---'    
    Private Sub SetupBarChartControl()
        If Me.Controls.Find("PanelBarGraphAverage", True).Length = 0 Then
            MessageBox.Show("The PanelBarGraphAverage control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        barGraph = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = PanelBarGraphAverage.BackColor
        }

        ' *** CRITICAL FIX: Add the chart control to the panel so it displays ***
        PanelBarGraphAverage.Controls.Add(barGraph)
    End Sub
    Private Sub InitializeBarGraphStructure()
        Dim chartData As Chart = barGraph ' Use barGraph

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Average sales per period")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.AxisX.Title = "Time Period"
        chartArea.AxisY.Title = "Average Revenue (₱)"
        chartArea.AxisY.LabelStyle.Format = "₱{0:N0}" ' Format Y-Axis as Peso Currency

        ' Create the Series (the vertical bars)
        Dim series1 As New Series With {
            .Name = "AverageRevenue",
            .ChartType = SeriesChartType.Column,
            .IsValueShownAsLabel = False,
            .LabelFormat = "₱{0:N2}",
            .Color = Color.FromArgb(84, 98, 161)
        }

        chartData.Series.Add(series1)
    End Sub
    Private Sub LoadAverageData(period As String)
        If barGraph Is Nothing Then ' Use barGraph
            Console.WriteLine("Bar Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = barGraph ' Use barGraph
        Dim series1 As Series = chartData.Series("AverageRevenue")
        series1.Points.Clear() ' Clear existing points

        Dim sql As String = ""
        Dim titleSuffix As String = ""

        ' Determine which SQL query to run based on the period parameter
        Select Case period.ToLower()
            Case "day"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("DAY")
                titleSuffix = " (Per Day)"
            Case "month"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("MONTH")
                titleSuffix = " (Per Month)"
            Case "year"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("YEAR")
                titleSuffix = " (Per Year)"
            Case Else
                MessageBox.Show("Invalid period specified for average sales data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Update the chart title dynamically
        chartData.Titles(0).Text = "Average Sales per Period" & titleSuffix

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim periodLabel As String = reader("PeriodLabel").ToString()
                        ' Use TryParse to safely convert the average, which might be Null or DBNull
                        Dim averageSales As Double = 0.0
                        Double.TryParse(reader("AverageSales").ToString(), averageSales)

                        If averageSales > 0 Then
                            Dim dataPoint As New DataPoint()
                            dataPoint.SetValueXY(periodLabel, averageSales)

                            ' Tooltip shows the label and the Peso value with 2 decimals
                            dataPoint.ToolTip = String.Format("{0}: ₱{1:N2}", periodLabel, averageSales)

                            series1.Points.Add(dataPoint)
                        End If
                    End While

                Catch ex As Exception
                    MessageBox.Show("DATABASE ERRORasdasdasd: " & ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        ' Sort the data points in memory to ensure proper chronological order
        Dim sortedPoints = series1.Points.OrderBy(Function(p) p.AxisLabel).ToList()
        series1.Points.Clear()
        For Each point In sortedPoints
            series1.Points.Add(point)
        Next

        ' Highlight the largest bar (Optional: for quick visual insight)
        If series1.Points.Count > 0 Then
            Dim maxRevenue = series1.Points.Max(Function(p) p.YValues(0))
            Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
            If maxPoint IsNot Nothing Then
                maxPoint.Color = Color.FromArgb(92, 81, 224) ' Highlight the highest average in red
            End If
        End If

        barGraph.Refresh() ' Use barGraph
    End Sub
    Public Sub ChangePeriodView(newPeriod As String)
        currentPeriod = newPeriod
        LoadAverageData(currentPeriod)
        UpdateEarningsDisplay(currentPeriod)
        PopulateAllTotal(currentPeriod)
        UpdateServiceDisplay(currentPeriod)
        UpdateCustomersDisplay(currentPeriod)
    End Sub
    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click

        If isYearlyView Then
            ' Currently Daily view
            isYearlyView = False
            isMonthlyView = False
            ' Day is the implicit default (Else)
            ButtonToggleChart.Text = "Daily"
            ChangePeriodView("Day")
        ElseIf isMonthlyView Then
            ' Currently Yearly view
            isMonthlyView = False
            isYearlyView = True
            ButtonToggleChart.Text = "Yearly"
            ChangePeriodView("Year")
        Else
            ' Currently Monthly view
            isMonthlyView = True
            isYearlyView = False
            ButtonToggleChart.Text = "Monthly"
            ChangePeriodView("Month")
        End If

        LoadSalesChart()
    End Sub
    Private Sub LoadSalesChart()
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String


        If isYearlyView Then
            chartData = DashboardDatabaseHelper.GetYearlySales()
            chartTitle = "Yearly Sales (Per Year)"
            xAxisTitle = "Year"
        ElseIf isMonthlyView Then
            chartData = DashboardDatabaseHelper.GetMonthlySales()
            chartTitle = "Monthly Sales (Per Month)"
            xAxisTitle = "Month"
        Else
            chartData = DashboardDatabaseHelper.GetDailySales()
            chartTitle = "Daily Sales (Per Day)"
            xAxisTitle = "Day"
        End If
        Dim salesChartForm As New SalesChartService(chartData, chartTitle, xAxisTitle) With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }

        PanelSales.Controls.Clear()
        PanelSales.Controls.Add(salesChartForm)
        salesChartForm.Dock = DockStyle.Fill
        salesChartForm.Show()

    End Sub

    Private Sub ViewSalesSummary()
        DataGridViewSalesSummary.DataSource = SalesAnalyticsDatabaseHelper.GetSalesSummaryData()
    End Sub

    Private Sub DataGridSalesSummaryFontStyle()
        DataGridViewSalesSummary.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewSalesSummary.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub ChangeHeadrOfDataGridViewSalesSummary()
        DataGridViewSalesSummary.Columns(0).HeaderText = "Sales Day"
        DataGridViewSalesSummary.Columns(1).HeaderText = "Total Sales (₱)"
    End Sub
    Private Sub SearchBarFunction()
        currentSearchTerm = Trim(TextBoxSearchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = SalesAnalyticsDatabaseHelper.GetSalesSummaryData()
        Else
            salesData = SalesAnalyticsDatabaseHelper.SearchInSalesSummary(currentSearchTerm)
        End If

        DataGridViewSalesSummary.DataSource = salesData
        DataGridViewSalesSummary.Refresh()
    End Sub

    Private Sub DataGridVIewSalesSummary_Formatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSalesSummary.CellFormatting
        ' Format the "Total Sales" column as Peso currency
        If DataGridViewSalesSummary.Columns(e.ColumnIndex).HeaderText = "Total Sales (₱)" AndAlso e.Value IsNot Nothing Then
            If Decimal.TryParse(e.Value.ToString(), Nothing) Then
                e.Value = Convert.ToDecimal(e.Value).ToString("N2")
                e.FormattingApplied = True
            End If
        End If

    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarFunction()
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        TextBoxSearchBar.Text = ""
    End Sub
    Private Sub DataGridViewSalesSummary_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewSalesSummary.CellPainting
        ' Only proceed if we are in a data row, not the header, and we have a search term
        If e.RowIndex < 0 OrElse String.IsNullOrWhiteSpace(currentSearchTerm) Then
            Exit Sub
        End If

        ' Get the cell value (which should be searchable text)
        Dim cellValue As String = e.FormattedValue?.ToString()

        If String.IsNullOrWhiteSpace(cellValue) Then
            Exit Sub
        End If

        ' 1. Check if the cell text contains the search term (case-insensitive)
        Dim searchIndex As Integer = cellValue.IndexOf(currentSearchTerm, StringComparison.OrdinalIgnoreCase)

        If searchIndex >= 0 Then
            ' A match was found!

            ' A. Do the default painting (draw background, borders, etc.)
            e.PaintBackground(e.ClipBounds, True)

            ' B. Set up colors and fonts
            Dim baseFont As Font = e.CellStyle.Font
            Dim highlightColor As Color = Color.Yellow ' Use a bright color for highlighting
            Dim highlightTextBrush As Brush = New SolidBrush(e.CellStyle.ForeColor)

            ' C. Calculate positions and sizes

            ' Calculate the size of the entire string using the cell's font
            Dim textSize As SizeF = e.Graphics.MeasureString(cellValue, baseFont)

            ' Get the original bounds (where the text starts)
            Dim textX As Integer = e.CellBounds.X + 3 ' Small padding from the left edge
            Dim textY As Integer = e.CellBounds.Y + (e.CellBounds.Height - CInt(textSize.Height)) \ 2 ' Center vertically

            ' 1. Text before the match
            Dim textBefore As String = cellValue.Substring(0, searchIndex)
            Dim sizeBefore As SizeF = e.Graphics.MeasureString(textBefore, baseFont)

            ' 2. The matching search term
            Dim textMatch As String = cellValue.Substring(searchIndex, currentSearchTerm.Length)
            Dim sizeMatch As SizeF = e.Graphics.MeasureString(textMatch, baseFont)

            ' --- Draw the three parts of the text ---

            ' Part 1: Text before the match (using default cell color)
            e.Graphics.DrawString(textBefore, baseFont, New SolidBrush(e.CellStyle.ForeColor), textX, textY)

            ' Part 2: The highlighted match
            ' Draw the yellow background rectangle
            Dim highlightRect As New Rectangle(
                CInt(textX + sizeBefore.Width),
                e.CellBounds.Y,
                CInt(sizeMatch.Width),
                e.CellBounds.Height
            )
            e.Graphics.FillRectangle(New SolidBrush(highlightColor), highlightRect)

            ' Draw the matched text (over the yellow background)
            e.Graphics.DrawString(textMatch, baseFont, highlightTextBrush, CInt(textX + sizeBefore.Width), textY)

            ' Part 3: Text after the match
            Dim textAfter As String = cellValue.Substring(searchIndex + currentSearchTerm.Length)
            e.Graphics.DrawString(textAfter, baseFont, New SolidBrush(e.CellStyle.ForeColor), CInt(textX + sizeBefore.Width + sizeMatch.Width), textY)

            ' Indicate that we have manually drawn the cell contents
            e.Handled = True
        Else
            ' If no match, let the default rendering happen
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Handled = True
        End If
    End Sub

End Class




