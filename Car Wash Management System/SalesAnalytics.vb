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
        SalesAnalyticsService.SearchBarFunction(TextBoxSearchBar, DataGridViewSalesSummary)
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        TextBoxSearchBar.Text = ""
    End Sub
    Private Sub DataGridViewSalesSummary_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewSalesSummary.CellPainting
        ' Only proceed if we are in a data row, not the header, and we have a search term
        If e.RowIndex < 0 OrElse String.IsNullOrWhiteSpace(SalesAnalyticsService.currentSearchTerm) Then
            Exit Sub
        End If

        ' Get the cell value (which should be searchable text)
        Dim cellValue As String = e.FormattedValue?.ToString()

        If String.IsNullOrWhiteSpace(cellValue) Then
            Exit Sub
        End If

        ' 1. Check if the cell text contains the search term (case-insensitive)
        Dim searchIndex As Integer = cellValue.IndexOf(SalesAnalyticsService.currentSearchTerm, StringComparison.OrdinalIgnoreCase)

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
            Dim textMatch As String = cellValue.Substring(searchIndex, SalesAnalyticsService.currentSearchTerm.Length)
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
            Dim textAfter As String = cellValue.Substring(searchIndex + SalesAnalyticsService.currentSearchTerm.Length)
            e.Graphics.DrawString(textAfter, baseFont, New SolidBrush(e.CellStyle.ForeColor), CInt(textX + sizeBefore.Width + sizeMatch.Width), textY)

            ' Indicate that we have manually drawn the cell contents
            e.Handled = True
        Else
            ' If no match, let the default rendering happen
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridViewSalesSummary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesSummary.CellContentClick

    End Sub
End Class




