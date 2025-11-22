Public Class RevenueServiceAnalytics
    Private Sub RevenueServiceAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SalesAnalytics.LoadCustomersChart(PanelChartAverage)
    End Sub

    Private Sub PanelChartAverage_Paint(sender As Object, e As PaintEventArgs) Handles PanelChartAverage.Paint

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub
End Class