Public Class DefaultViewService
    Public Shared isMonthlyView As Boolean = False
    Public Shared isYearlyView As Boolean = False

    Public Shared Sub DefaultViewInChart(buttonToggleChart As Button)
        isYearlyView = False
        isMonthlyView = False
        buttonToggleChart.Text = "Daily"
        SalesAnalyticsService.currentPeriod = "Day"
    End Sub
End Class
