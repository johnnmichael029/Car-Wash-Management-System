Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class AverageSaleAnalytics
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private currentPeriod As String = "Day" ' Default view
    Private barGraph As Chart
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private Sub AverageSaleAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBarGraphAverage()
    End Sub
    Private Sub LoadBarGraphAverage()
        SalesAnalytics.SetupBarChartControl(PanelBarGraphAverage)
        SalesAnalytics.InitializeBarGraphStructure()
        SalesAnalytics.LoadAverageData(currentPeriod)
    End Sub
    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        If isYearlyView Then
            ' Currently Daily view
            isYearlyView = False
            isMonthlyView = False
            ' Day is the implicit default (Else)
            ButtonToggleChart.Text = "Daily"
            SalesAnalytics.ChangePeriodView("Day")
        ElseIf isMonthlyView Then
            ' Currently Yearly view
            isMonthlyView = False
            isYearlyView = True
            ButtonToggleChart.Text = "Yearly"
            SalesAnalytics.ChangePeriodView("Year")
        Else
            ' Currently Monthly view
            isMonthlyView = True
            isYearlyView = False
            ButtonToggleChart.Text = "Monthly"
            SalesAnalytics.ChangePeriodView("Month")
        End If
    End Sub
End Class