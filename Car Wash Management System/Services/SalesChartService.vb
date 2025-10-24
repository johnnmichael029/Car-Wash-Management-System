Imports System.Windows.Forms.DataVisualization.Charting

Public Class SalesChartService
    Inherits Form
    Private ReadOnly chart1 As Chart
    Public Sub New(salesData As DataTable, chartTitle As String, xAxisTitle As String)
        Me.Text = chartTitle
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        chart1 = New Chart()
        Me.Controls.Add(chart1)
        chart1.Size = New Size(750, 500)
        chart1.Location = New Point(10, 10)
        chart1.Dock = DockStyle.Fill
        Dim chartArea1 As New ChartArea With {
            .Name = "ChartArea1"
        }
        chart1.ChartAreas.Add(chartArea1)

        Dim series1 As New Series With {
            .Name = "Sales",
            .LabelForeColor = Color.Black,
            .ChartType = SeriesChartType.Line,
            .BorderWidth = 3,
            .Color = Color.Black,
            .MarkerStyle = MarkerStyle.Circle,
            .MarkerSize = 10,
            .MarkerColor = Color.Black,
            .ToolTip = "₱#VALY{N2}"
        }
        chart1.Series.Add(series1)

        ' Set the title of the chart.
        Dim title1 As New Title With {
            .Text = chartTitle,
            .Font = New Font("Century Gothic", 12, FontStyle.Bold)
        }
        chart1.Titles.Add(title1)

        ' Customize the axes dynamically based on the input.
        chart1.ChartAreas("ChartArea1").AxisX.Title = xAxisTitle
        chart1.ChartAreas("ChartArea1").AxisY.Title = "Total Sales (₱)"
        chart1.ChartAreas("ChartArea1").AxisX.Interval = 1

        ' Load data into the chart.
        LoadChartData(salesData, xAxisTitle)
    End Sub

    Private Sub LoadChartData(salesData As DataTable, xAxisTitle As String)
        chart1.Series("Sales").Points.Clear()

        For Each row As DataRow In salesData.Rows
            If xAxisTitle = "Year" Then
                Dim salesYear As Integer = row("SalesYear")
                Dim salesTotal As Decimal = row("TotalSales")
                chart1.Series("Sales").Points.AddXY(salesYear, salesTotal)
            ElseIf xAxisTitle = "Month" Then
                Dim salesYear As Integer = row("SalesYear")
                Dim salesMonth As Integer = row("SalesMonth")
                Dim salesTotal As Decimal = row("TotalSales")
                Dim monthName As String = New Date(salesYear, salesMonth, 1).ToString("MMM yyy")
                chart1.Series("Sales").Points.AddXY(monthName, salesTotal)
            ElseIf xAxisTitle = "Day" Then
                Dim salesDate As Date = row("SaleDate")
                Dim salesTotal As Decimal = row("TotalSales")
                chart1.Series("Sales").Points.AddXY(salesDate.ToString("M/d"), salesTotal)
            End If
        Next
    End Sub
End Class
