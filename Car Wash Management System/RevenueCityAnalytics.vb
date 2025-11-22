Public Class RevenueCityAnalytics
    Private Sub PanelChartRevenueCity_Paint(sender As Object, e As PaintEventArgs) Handles PanelChartRevenueCity.Paint

    End Sub

    Private Sub RevenueCityAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SalesAnalytics.LoadGraph(PanelChartRevenueCity)
    End Sub
End Class