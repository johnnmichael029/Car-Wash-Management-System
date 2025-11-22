Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class SalesAnalytics
    Inherits BaseForm

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub SalesAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Set the initial period to "Day"
        SalesAnalyticsService.currentPeriod = "Day"
        DefaultViewService.DefaultViewInChart(ButtonToggleChart) ' Ensure charts default to daily

        ' 2. Load and Populate ALL data using the default "Day" period in one sequence
        ChangePeriodView(SalesAnalyticsService.currentPeriod) ' Calls LoadPeriodData, then all population functions

        ' Other loads that don't depend on the current period
        LoadServicesChart(PanelChartCustomers)
        LoadCustomersChart(PanelChartAverage)
        LoadBarGraphAverage()
        SalesAnalyticsService.LoadSalesChart(PanelSales)
        ViewSalesSummary(DataGridViewSalesSummary)
        ChangeHeadrOfDataGridViewSalesSummary(DataGridViewSalesSummary)
        DataGridSalesSummaryFontStyle(DataGridViewSalesSummary)
    End Sub

    Public Sub LoadServicesChart(panelChartAverage As Panel)
        chartDatabaseHelper.SetupPieChartControlInCustomers(panelChartAverage)
        chartDatabaseHelper.InitializeChartStructureInCustomers()

        chartDatabaseHelper.LoadCustomersData()
    End Sub

    Public Sub LoadCustomersChart(panelChartAverage As Panel)
        chartDatabaseHelper.SetupPieChartControl(panelChartAverage)
        chartDatabaseHelper.InitializeChartStructure()
        chartDatabaseHelper.LoadServiceData()
    End Sub

    Public Sub LoadGraph(PanelChartRevenueCity As Panel)
        chartDatabaseHelper.SetupPieChartControlInRevenueCity(PanelChartRevenueCity)
        chartDatabaseHelper.InitializeChartStructureForCity()
        chartDatabaseHelper.LoadRevenueByLocation()
    End Sub

    Private Sub LoadBarGraphAverage()
        chartDatabaseHelper.SetupBarChartControl(PanelBarGraphAverage)
        chartDatabaseHelper.InitializeBarGraphStructure()
        ChartDatabaseHelper.LoadAverageData(SalesAnalyticsService.currentPeriod)
    End Sub

    Public Sub ChangePeriodView(newPeriod As String)
        SalesAnalyticsService.currentPeriod = newPeriod ' Store the new period globally

        ' 1. Fetch ALL data for the period (this is where the data logic is centralized)
        Dim analyticsData As SalesAnalyticsDatabaseHelper = SalesAnalyticsService.LoadPeriodData(newPeriod)

        ' 2. Update the overall Totals (Earnings, Orders, Customers) - Image 2
        SalesAnalyticsService.PopulateAllTotal(analyticsData, LabelOrders, LabelCustomers, LabelEarnings, LabelEarningsPeriod, LabelServicePeriod, LabelCustomersPeriod)

        ' 3. Update the detailed displays (Earnings, Customers, Service comparisons)
        SalesAnalyticsService.UpdateEarningsDisplay(analyticsData, LabelEarningsValue, PictureBoxUpArrow, PictureBoxDownArrow, LabelPercentage)
        SalesAnalyticsService.UpdateCustomersDisplay(analyticsData, LabelCustomersValue, PictureBoxUpCustomers, PictureBoxDownCustomers, LabelPercentageCustomers)
        SalesAnalyticsService.UpdateServiceDisplay(analyticsData, LabelServiceValue, PictureBoxUpService, PictureBoxDownService, LabelPercentageService)

        ' 4. Update the Bar Graph and Sales Chart
        ChartDatabaseHelper.LoadAverageData(newPeriod)
        SalesAnalyticsService.LoadSalesChart(PanelSales)
    End Sub

    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        ' 1. Toggle the period state and update the button text in the shared service
        Dim nextPeriod As String = SalesAnalyticsService.TogglePeriodView(ButtonToggleChart)

        ' 2. Call the main refresh function using the new period
        ChangePeriodView(nextPeriod)
    End Sub


    Public Sub ViewSalesSummary(gridView As DataGridView)
        gridView.DataSource = SalesAnalyticsDatabaseHelper.GetSalesSummaryData()
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

    Public Sub DataGridSalesSummaryFontStyle(gridView As DataGridView)
        gridView.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        gridView.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Public Sub ChangeHeadrOfDataGridViewSalesSummary(gridView As DataGridView)
        gridView.Columns(0).HeaderText = "Sales Day"
        gridView.Columns(1).HeaderText = "Total Sales (₱)"
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForAnalytics(TextBoxSearchBar, DataGridViewSalesSummary)
    End Sub

    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub

    Private Sub DataGridViewSalesSummary_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewSalesSummary.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub DataGridViewSalesSummary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesSummary.CellContentClick

    End Sub
End Class




