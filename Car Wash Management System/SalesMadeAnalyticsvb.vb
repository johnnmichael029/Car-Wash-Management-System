Public Class SalesMadeAnalyticsvb
    Inherits BaseForm

    Private Sub SalesMadeAnalyticsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize shared period state
        SalesAnalyticsService.currentPeriod = "Day"
        DefaultViewService.DefaultViewInChart(ButtonToggleChart)
        SalesAnalyticsService.LoadSalesChart(PanelSales)
    End Sub

    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        ' 1. Toggle the period state and update the button text in the shared service
        SalesAnalyticsService.TogglePeriodView(ButtonToggleChart)

        ' 2. Refresh the sales chart using the newly set shared period
        ' NOTE: SalesAnalyticsService.LoadSalesChart must use SalesAnalyticsService.currentPeriod internally.
        SalesAnalyticsService.LoadSalesChart(PanelSales)
    End Sub
End Class