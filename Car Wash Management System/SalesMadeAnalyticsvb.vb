Public Class SalesMadeAnalyticsvb
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private Sub SalesMadeAnalyticsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DefaultViewInChart()
        SalesAnalytics.LoadSalesChart(PanelSales)
    End Sub
    Private Sub DefaultViewInChart()
        SalesAnalytics.isYearlyView = False
        SalesAnalytics.isMonthlyView = False
        ButtonToggleChart.Text = "Daily"
    End Sub
    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        If SalesAnalytics.isYearlyView Then
            ' Currently Daily view
            SalesAnalytics.isYearlyView = False
            SalesAnalytics.isMonthlyView = False
            ' Day is the implicit default (Else)
            ButtonToggleChart.Text = "Daily"
        ElseIf SalesAnalytics.isMonthlyView Then
            ' Currently Yearly view
            SalesAnalytics.isMonthlyView = False
            SalesAnalytics.isYearlyView = True
            ButtonToggleChart.Text = "Yearly"
        Else
            ' Currently Monthly view
            SalesAnalytics.isMonthlyView = True
            SalesAnalytics.isYearlyView = False
            ButtonToggleChart.Text = "Monthly"
        End If

        SalesAnalytics.LoadSalesChart(PanelSales)
    End Sub
End Class