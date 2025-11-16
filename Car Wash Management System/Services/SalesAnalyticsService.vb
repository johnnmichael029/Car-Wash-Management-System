Public Class SalesAnalyticsService
    Public Shared currentSearchTerm As String = String.Empty
    Public Shared currentPeriod As String = "Day" ' Default view
    Public Shared Function LoadPeriodData(period As String) As SalesAnalyticsDatabaseHelper
        ' NOTE: Assuming SalesAnalyticsDatabaseHelper now has a single function
        ' that returns a fully populated object for the given period.
        ' Example: You need to implement this function:
        ' Public Shared Function LoadAllPeriodData(period As String) As SalesAnalyticsDatabaseHelper

        ' Since we don't have LoadAllPeriodData, we'll mimic the current behavior but centralize
        Dim earningsData As SalesAnalyticsDatabaseHelper = SalesAnalyticsDatabaseHelper.GetDynamicEarningsData(period)
        earningsData.CurrentMonthCustomers = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData(period).CurrentMonthCustomers ' Merging data
        earningsData.PreviousMonthCustomers = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData(period).PreviousMonthCustomers
        earningsData.PercentageChangeCustomers = SalesAnalyticsDatabaseHelper.GetDynamicCustomerData(period).PercentageChangeCustomers
        earningsData.CurrentMonthService = SalesAnalyticsDatabaseHelper.GetDynamicServiceData(period).CurrentMonthService
        earningsData.PreviousMonthService = SalesAnalyticsDatabaseHelper.GetDynamicServiceData(period).PreviousMonthService
        earningsData.PercentageChangeService = SalesAnalyticsDatabaseHelper.GetDynamicServiceData(period).PercentageChangeService

        Return earningsData
    End Function

    ' MODIFIED: Now takes the pre-loaded data object as input
    Public Shared Sub UpdateEarningsDisplay(earningsData As SalesAnalyticsDatabaseHelper, labelEarningsValue As Label, pictureBoxUpArrow As PictureBox, pictureBoxDownArrow As PictureBox, labelPercentage As Label)

        ' 1. Update the Main Earnings Value (e.g., 13213)
        ' Use Math.Round for cleaner comparison
        Dim earningsChange As Decimal = Math.Round(earningsData.CurrentMonthEarnings - earningsData.PreviousMonthEarnings, 2)
        labelEarningsValue.Text = "₱" & earningsChange.ToString("N2")

        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color
        Dim percentageChange As Decimal = earningsData.PercentageChangeEarnings

        If percentageChange > 0 Then
            ' UP/GREEN
            pictureBoxUpArrow.Visible = True
            pictureBoxDownArrow.Visible = False
            colorToUse = Color.Green
            labelEarningsValue.ForeColor = Color.Green
        ElseIf percentageChange < 0 Then
            ' DOWN/RED
            pictureBoxUpArrow.Visible = False
            pictureBoxDownArrow.Visible = True
            colorToUse = Color.Red
            labelEarningsValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            colorToUse = Color.Gray
            labelEarningsValue.ForeColor = Color.Gray
            pictureBoxUpArrow.Visible = False
            pictureBoxDownArrow.Visible = False
        End If

        Dim displayPercentage As Decimal = Math.Abs(percentageChange)
        labelPercentage.Text = displayPercentage.ToString("N0") & "%"
        labelPercentage.ForeColor = colorToUse
    End Sub

    ' MODIFIED: Now takes the pre-loaded data object as input
    Public Shared Sub UpdateCustomersDisplay(customersData As SalesAnalyticsDatabaseHelper, labelCustomersValue As Label, pictureBoxUpCustomers As PictureBox, pictureBoxDownCustomers As PictureBox, labelPercentageCustomers As Label)

        ' 1. Update the Main Customers Value (e.g., 13213)
        Dim customerChange As Decimal = customersData.CurrentMonthCustomers - customersData.PreviousMonthCustomers
        labelCustomersValue.Text = customerChange.ToString("N0")

        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color
        Dim percentageChange As Decimal = customersData.PercentageChangeCustomers

        If percentageChange > 0 Then
            ' UP/GREEN
            pictureBoxUpCustomers.Visible = True
            pictureBoxDownCustomers.Visible = False
            colorToUse = Color.Green
            labelCustomersValue.ForeColor = Color.Green
        ElseIf percentageChange < 0 Then
            ' DOWN/RED
            pictureBoxUpCustomers.Visible = False
            pictureBoxDownCustomers.Visible = True
            colorToUse = Color.Red
            labelCustomersValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            pictureBoxUpCustomers.Visible = False
            pictureBoxDownCustomers.Visible = False
            labelCustomersValue.ForeColor = Color.Gray
            colorToUse = Color.Gray
        End If

        Dim displayPercentage As Decimal = Math.Abs(percentageChange)
        labelPercentageCustomers.Text = displayPercentage.ToString("N0") & "%"
        labelPercentageCustomers.ForeColor = colorToUse
    End Sub

    ' MODIFIED: Now takes the pre-loaded data object as input
    Public Shared Sub UpdateServiceDisplay(serviceData As SalesAnalyticsDatabaseHelper, labelServiceValue As Label, pictureBoxUpService As PictureBox, pictureBoxDownService As PictureBox, labelPercentageService As Label)

        ' 1. Update the Main Service Value (e.g., 13213)
        Dim serviceChange As Decimal = serviceData.CurrentMonthService - serviceData.PreviousMonthService
        labelServiceValue.Text = serviceChange.ToString("N0")

        ' 2. Determine the color and arrow symbol
        Dim colorToUse As Color
        Dim percentageChange As Decimal = serviceData.PercentageChangeService

        If percentageChange > 0 Then
            ' UP/GREEN
            pictureBoxUpService.Visible = True
            pictureBoxDownService.Visible = False
            colorToUse = Color.Green
            labelServiceValue.ForeColor = Color.Green
        ElseIf percentageChange < 0 Then
            ' DOWN/RED
            pictureBoxUpService.Visible = False
            pictureBoxDownService.Visible = True
            colorToUse = Color.Red
            labelServiceValue.ForeColor = Color.Red
        Else
            ' NO CHANGE
            labelServiceValue.ForeColor = Color.Gray
            pictureBoxUpService.Visible = False
            pictureBoxDownService.Visible = False
            colorToUse = Color.Gray
        End If

        Dim displayPercentage As Decimal = Math.Abs(percentageChange)
        labelPercentageService.Text = displayPercentage.ToString("N0") & "%"
        labelPercentageService.ForeColor = colorToUse
    End Sub


    Public Shared Function TogglePeriodView(buttonToggleChart As Button) As String

        DefaultViewService.isMonthlyView = False
        DefaultViewService.isYearlyView = False

        Dim nextPeriod As String

        ' Determine the NEXT state based on the current state (Day is the default/Else state)
        Select Case buttonToggleChart.Text
            Case "Daily"
                ' Current is Daily, Next should be Monthly
                DefaultViewService.isMonthlyView = True
                nextPeriod = "Month"
                buttonToggleChart.Text = "Monthly"
            Case "Monthly"
                ' Current is Monthly, Next should be Yearly
                DefaultViewService.isYearlyView = True
                nextPeriod = "Year"
                buttonToggleChart.Text = "Yearly"
            Case "Yearly"
                ' Current is Yearly, Next should be Daily (default)
                nextPeriod = "Day"
                buttonToggleChart.Text = "Daily"
                SalesAnalytics.ChangePeriodView(nextPeriod)
            Case Else
                ' Fallback to Daily
                nextPeriod = "Day"
                buttonToggleChart.Text = "Daily"
        End Select

        ' Update the shared currentPeriod state
        currentPeriod = nextPeriod
        Return nextPeriod
    End Function
    Public Shared Sub LoadSalesChart(panelSales As Panel)
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String

        If DefaultViewService.isYearlyView Then
            chartData = DashboardDatabaseHelper.GetYearlySales()
            chartTitle = "Yearly Sales (Per Year)"
            xAxisTitle = "Year"
        ElseIf DefaultViewService.isMonthlyView Then
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

        panelSales.Controls.Clear()
        panelSales.Controls.Add(salesChartForm)
        salesChartForm.Dock = DockStyle.Fill
        salesChartForm.Show()

    End Sub
    Public Shared Sub SearchBarFunction(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = SalesAnalyticsDatabaseHelper.GetSalesSummaryData()
        Else
            salesData = SalesAnalyticsDatabaseHelper.SearchInSalesSummary(currentSearchTerm)
        End If

        gridView.DataSource = salesData
        gridView.Refresh()
    End Sub
    Public Shared Sub PopulateAllTotal(analyticsData As SalesAnalyticsDatabaseHelper, labelOrders As Label, labelCustomers As Label, labelEarnings As Label, labelEarningsPeriod As Label, labelServicePeriod As Label, labelCustomersPeriod As Label)

        Dim periodText As String

        Select Case currentPeriod.ToLower()
            Case "day"
                periodText = "This Day"
            Case "month"
                periodText = "This Month"
            Case "year"
                periodText = "This Year"
            Case Else
                periodText = "Invalid Period"
                MessageBox.Show("Invalid period specified for totals. Defaulting to Daily.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Exit the function
        End Select

        ' Update the labels using the data from the single fetched object
        labelOrders.Text = analyticsData.CurrentMonthService.ToString("N0")
        labelCustomers.Text = analyticsData.CurrentMonthCustomers.ToString("N0")
        labelEarnings.Text = "₱" & analyticsData.CurrentMonthEarnings.ToString("N2")

        labelEarningsPeriod.Text = periodText
        labelServicePeriod.Text = periodText
        labelCustomersPeriod.Text = periodText
    End Sub

End Class
