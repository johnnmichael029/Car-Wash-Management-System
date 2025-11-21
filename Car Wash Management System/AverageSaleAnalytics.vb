Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class AverageSaleAnalytics
    Inherits BaseForm

    ' The currentPeriod variable is no longer needed here, as we use the shared one.

    Private Sub AverageSaleAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize shared period state
        SalesAnalyticsService.currentPeriod = "Day"
        DefaultViewService.DefaultViewInChart(ButtonToggleChart)
        LoadBarGraphAverage()
    End Sub

    ' Updated to use the shared currentPeriod from the service
    Private Sub LoadBarGraphAverage()
        ' Fetch the currently selected period from the service
        Dim currentPeriod = SalesAnalyticsService.currentPeriod
        ChartDatabaseHelper.SetupBarChartControl(PanelBarGraphAverage)
        ChartDatabaseHelper.InitializeBarGraphStructure()
        ' Load data using the current shared period
        ChartDatabaseHelper.LoadAverageData(currentPeriod)
    End Sub

    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        ' 1. Toggle the period state and update the button text in the shared service
        Dim nextPeriod As String = SalesAnalyticsService.TogglePeriodView(ButtonToggleChart)

        ' 2. Call the main refresh function using the new period
        SalesAnalytics.ChangePeriodView(nextPeriod)
    End Sub

    Private Sub PanelBarGraphAverage_Paint(sender As Object, e As PaintEventArgs) Handles PanelBarGraphAverage.Paint

    End Sub
End Class
