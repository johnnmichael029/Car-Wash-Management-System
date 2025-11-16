Public Class RevenueCustomerAnalytics
    Private Sub RevenueCustomerAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SalesAnalytics.LoadServicesChart(PanelChartAverage)
    End Sub

    Private Sub PanelChartAverage_Paint(sender As Object, e As PaintEventArgs) Handles PanelChartAverage.Paint

    End Sub
End Class