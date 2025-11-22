Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class ChartDatabaseHelper
    Private Shared constr As String
    Private pieChart As Chart
    Private Shared barGraph As Chart
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    '--- PIE CHART FOR CUSTOMERS REVENUE DISTRIBUTION ---'
    Public Sub SetupPieChartControlInCustomers(PanelChartCustomers As Panel)
        If SalesAnalytics.Controls.Find("PanelChartCustomers", True).Length = 0 Then
            MessageBox.Show("The PanelChartCustomers control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        pieChart = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = PanelChartCustomers.BackColor
        }
        PanelChartCustomers.Controls.Add(pieChart)
    End Sub

    Public Sub InitializeChartStructureInCustomers()
        Dim chartData As Chart = pieChart ' Use the dynamically created chart

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Revenue Distribution by Customers (Live Data)")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        ' Create Chart Area and apply 3D styling
        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Inclination = 30
        chartArea.Area3DStyle.Rotation = 10

        ' Create the Series (the Pie itself)
        ' ----------------------------------------------------
        ' 1. Hide the percentage/value labels on the slices
        ' 2. Hide the service name label on the slices (no text inside the pie)
        ' ----------------------------------------------------
        Dim series1 As New Series With {
            .Name = "CustomersRevenue",
            .ChartType = SeriesChartType.Pie,
            .IsValueShownAsLabel = False,
            .LabelFormat = "P1", ' Format is still defined, but not shown
            .LegendText = "#VALX (#PERCENT)", ' Show customer name and percentage in legend
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .XValueType = ChartValueType.String
        }

        ' --- CRITICAL ADDITION: DISABLE ALL PIE SLICE LABELS (Failsafe 3) ---
        series1.CustomProperties = "PieLabelStyle=Disabled"
        chartData.Series.Add(series1)

        ' Add a Legend
        Dim legend1 As New Legend With {
            .Docking = Docking.Bottom,
            .Alignment = StringAlignment.Center
        }
        chartData.Legends.Add(legend1)
    End Sub

    Public Sub LoadCustomersData()
        If pieChart Is Nothing Then
            Console.WriteLine("Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = pieChart
        ' Ensure the series exists before accessing it
        If chartData.Series.Count = 0 OrElse chartData.Series("CustomersRevenue") Is Nothing Then
            Console.WriteLine("Chart series 'CustomersRevenue' is not initialized.")
            Exit Sub
        End If

        Dim series1 As Series = chartData.Series("CustomersRevenue")
        series1.Points.Clear() ' Clear any existing points

        Dim revenueData As New Dictionary(Of String, Double)

        ' Call the function defined in this class
        Dim sql As String = SalesAnalyticsDatabaseHelper.GetDynamicCustomersQuery()

        ' NOTE: Using ConnectionString property defined at class level (replacing 'constr')
        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim customerName As String = reader("Name").ToString()
                        Dim totalRevenue As Double = Convert.ToDouble(reader("TotalRevenue"))

                        revenueData.Add(customerName, totalRevenue)
                    End While

                    reader.Close() ' Close the reader after use

                    ' Calculate the total revenue for accurate percentage calculation in tooltip
                    Dim totalRevenueSum As Double = revenueData.Values.Sum()

                    ' 1. Populate the Chart with the data
                    For Each kvp In revenueData
                        Dim dataPoint As New DataPoint()
                        dataPoint.SetValueXY(kvp.Key, kvp.Value)

                        ' Set ToolTip for hover effect - NOW INCLUDES CURRENCY VALUE
                        If totalRevenueSum > 0 Then
                            Dim percentage As Double = kvp.Value / totalRevenueSum
                            ' Tooltip shows Name, Currency Value in pesoz (₱), and Percentage (P1)
                            dataPoint.ToolTip = String.Format("{0}: ₱{1:N2} ({2:P1})", kvp.Key, kvp.Value, percentage)
                        Else
                            ' Fallback if total is zero
                            dataPoint.ToolTip = kvp.Key
                        End If

                        series1.Points.Add(dataPoint)
                    Next

                    ' Failsafe 2: Ensure all individual point labels are empty (to remove 0%)
                    For Each point As DataPoint In series1.Points
                        point.Label = String.Empty
                    Next

                    ' 2. Custom Coloring (Optional)
                    ' Assign colors based on index, assuming consistent order
                    Dim colors As Color() = {Color.SteelBlue, Color.Gold, Color.DarkGreen, Color.DarkRed, Color.BlueViolet, Color.Tomato}
                    For i As Integer = 0 To series1.Points.Count - 1
                        ' Use the modulo operator (%) to cycle through colors if there are more points than colors
                        series1.Points(i).Color = colors(i Mod colors.Length)
                    Next

                    ' 3. Find and Explode the largest revenue slice
                    If revenueData.Count > 0 Then
                        Dim maxRevenue As Double = revenueData.Values.Max()
                        ' Find the data point that corresponds to the max revenue
                        Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
                        If maxPoint IsNot Nothing AndAlso maxRevenue > 0 Then ' Only explode if max is greater than 0
                            maxPoint.CustomProperties = "Exploded=true"
                        End If
                    End If

                Catch ex As Exception
                    ' Display the specific database error to the user
                    MessageBox.Show("DATABASE ERROR: " & ex.Message & Environment.NewLine &
                                    "Please check your ConnectionString and ensure the SQL Server is running.",
                                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    '--- PIE CHART FOR SERVICES REVENUE DISTRIBUTION ---'
    Public Sub SetupPieChartControl(panelChartAverage As Panel)
        If SalesAnalytics.Controls.Find("PanelChartAverage", True).Length = 0 Then
            MessageBox.Show("The PanelChartAverage control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        pieChart = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = panelChartAverage.BackColor
        }
        panelChartAverage.Controls.Add(pieChart)
    End Sub

    Public Sub InitializeChartStructure()
        Dim chartData As Chart = pieChart ' Use the dynamically created chart

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Revenue Distribution by Core Service (Live Data)")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        ' Create Chart Area and apply 3D styling
        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Inclination = 30
        chartArea.Area3DStyle.Rotation = 10

        ' Create the Series (the Pie itself)
        ' ----------------------------------------------------
        ' 1. Hide the percentage/value labels on the slices
        ' 2. Hide the service name label on the slices (no text inside the pie)
        ' ----------------------------------------------------
        Dim series1 As New Series With {
            .Name = "CoreServicesRevenue",
            .ChartType = SeriesChartType.Pie,
            .IsValueShownAsLabel = False,
            .LabelFormat = "P1", ' Format is still defined, but not shown
            .LegendText = "#VALX (#PERCENT)", ' Show service name and percentage in legend
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .XValueType = ChartValueType.String
        }

        ' --- CRITICAL ADDITION: DISABLE ALL PIE SLICE LABELS (Failsafe 3) ---
        series1.CustomProperties = "PieLabelStyle=Disabled"
        chartData.Series.Add(series1)

        ' Add a Legend
        Dim legend1 As New Legend With {
            .Docking = Docking.Bottom,
            .Alignment = StringAlignment.Center
        }
        chartData.Legends.Add(legend1)
    End Sub

    Public Sub LoadServiceData()
        If pieChart Is Nothing Then
            Console.WriteLine("Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = pieChart
        Dim series1 As Series = chartData.Series("CoreServicesRevenue")
        series1.Points.Clear() ' Clear any existing points

        Dim revenueData As New Dictionary(Of String, Double)

        Dim sql As String = SalesAnalyticsDatabaseHelper.GetDynamicSalesQuery()

        ' NOTE: Using ConnectionString property defined at class level
        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim serviceName As String = reader("ServiceName").ToString()
                        Dim totalRevenue As Double = Convert.ToDouble(reader("TotalRevenue"))

                        revenueData.Add(serviceName, totalRevenue)
                    End While

                    ' Calculate the total revenue for accurate percentage calculation in tooltip
                    Dim totalRevenueSum As Double = revenueData.Values.Sum()

                    ' 1. Populate the Chart with the data
                    For Each kvp In revenueData
                        Dim dataPoint As New DataPoint()
                        dataPoint.SetValueXY(kvp.Key, kvp.Value)

                        ' Set ToolTip for hover effect 
                        If totalRevenueSum > 0 Then
                            Dim percentage As Double = kvp.Value / totalRevenueSum
                            ' *** FIX HERE: Assign the tooltip to the specific dataPoint, not the entire series. ***
                            dataPoint.ToolTip = String.Format("{0}: {1:P1}", kvp.Key, percentage)
                        Else
                            ' Fallback if total is zero
                            dataPoint.ToolTip = kvp.Key
                        End If

                        series1.Points.Add(dataPoint)
                    Next

                    ' Failsafe 2: Ensure all individual point labels are empty (to remove 0%)
                    For Each point As DataPoint In series1.Points
                        point.Label = String.Empty
                    Next

                    ' 2. Custom Coloring (Optional)
                    ' Assign colors based on index, assuming consistent order
                    Dim colors As Color() = {Color.SteelBlue, Color.Gold, Color.DarkGreen, Color.DarkRed}
                    For i As Integer = 0 To series1.Points.Count - 1
                        If i < colors.Length Then
                            series1.Points(i).Color = colors(i)
                        End If
                    Next

                    ' 3. Find and Explode the largest revenue slice
                    If revenueData.Count > 0 Then
                        Dim maxRevenue As Double = revenueData.Values.Max()
                        ' Find the data point that corresponds to the max revenue
                        Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
                        If maxPoint IsNot Nothing AndAlso maxRevenue > 0 Then ' Only explode if max is greater than 0
                            maxPoint.CustomProperties = "Exploded=true"
                        End If
                    End If

                Catch ex As Exception
                    ' Display the specific database error to the user
                    MessageBox.Show("DATABASE ERROR: " & ex.Message & Environment.NewLine &
                                    "Please check your ConnectionString and ensure the SQL Server is running.",
                                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    '--- PIE CHART FOR CITY REVENUE DISTRIBUTION ---'
    Public Sub SetupPieChartControlInRevenueCity(PanelChartRevenueCity As Panel)
        If RevenueCityAnalytics.Controls.Find("PanelChartRevenueCity", True).Length = 0 Then
            MessageBox.Show("The PanelChartRevenueCity control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        pieChart = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = PanelChartRevenueCity.BackColor
        }
        PanelChartRevenueCity.Controls.Add(pieChart)
    End Sub

    Public Sub InitializeChartStructureForCity()
        Dim chartData As Chart = pieChart ' Use the dynamically created chart

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Revenue Distribution by Core City (Live Data)")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        ' Create Chart Area and apply 3D styling
        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.Area3DStyle.Enable3D = True
        chartArea.Area3DStyle.Inclination = 30
        chartArea.Area3DStyle.Rotation = 10

        ' Create the Series (the Pie itself)
        ' ----------------------------------------------------
        ' 1. Hide the percentage/value labels on the slices
        ' 2. Hide the service name label on the slices (no text inside the pie)
        ' ----------------------------------------------------
        Dim series1 As New Series With {
            .Name = "CoreCityRevenue",
            .ChartType = SeriesChartType.Pie,
            .IsValueShownAsLabel = False,
            .LabelFormat = "P1", ' Format is still defined, but not shown
            .LegendText = "#VALX (#PERCENT)", ' Show service name and percentage in legend
            .Font = New Font("Century Gothic", 10, FontStyle.Bold),
            .XValueType = ChartValueType.String
        }

        ' --- CRITICAL ADDITION: DISABLE ALL PIE SLICE LABELS (Failsafe 3) ---
        series1.CustomProperties = "PieLabelStyle=Disabled"
        chartData.Series.Add(series1)

        ' Add a Legend
        Dim legend1 As New Legend With {
            .Docking = Docking.Bottom,
            .Alignment = StringAlignment.Center
        }
        chartData.Legends.Add(legend1)
    End Sub

    Public Sub LoadRevenueByLocation()
        If pieChart Is Nothing Then
            Console.WriteLine("Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = pieChart
        ' It's good practice to rename the series to reflect the new data purpose
        Dim series1 As Series = chartData.Series("CoreCityRevenue")
        series1.Points.Clear() ' Clear any existing points

        ' Store data as Location (String) and Revenue (Double)
        Dim revenueData As New Dictionary(Of String, Double)

        ' Assuming this function now returns the SQL for grouping by Address/Location
        Dim sql As String = SalesAnalyticsDatabaseHelper.GetDynamicSalesQueryForCity()

        ' NOTE: Using ConnectionString property defined at class level (constr)
        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        ' *** IMPORTANT CHANGE: Read "Location" instead of "ServiceName" ***
                        Dim locationName As String = reader("Location").ToString()
                        Dim totalRevenue As Double = Convert.ToDouble(reader("TotalRevenue"))

                        revenueData.Add(locationName, totalRevenue)
                    End While

                    ' Calculate the total revenue for accurate percentage calculation in tooltip
                    Dim totalRevenueSum As Double = revenueData.Values.Sum()

                    ' 1. Populate the Chart with the data
                    For Each kvp In revenueData
                        Dim dataPoint As New DataPoint()
                        ' Set the X-Value (Label) to the Location name and Y-Value to the Revenue
                        dataPoint.SetValueXY(kvp.Key, kvp.Value)

                        ' Set ToolTip for hover effect 
                        If totalRevenueSum > 0 Then
                            Dim percentage As Double = kvp.Value / totalRevenueSum
                            ' *** UPDATE TOOLTIP TEXT to show Location ***
                            dataPoint.ToolTip = String.Format("{0}: {1:P1}", kvp.Key, percentage)
                        Else
                            ' Fallback if total is zero
                            dataPoint.ToolTip = kvp.Key
                        End If

                        series1.Points.Add(dataPoint)
                    Next

                    ' Failsafe 2: Ensure all individual point labels are empty (to remove 0%)
                    For Each point As DataPoint In series1.Points
                        point.Label = String.Empty
                    Next

                    ' 2. Custom Coloring (Optional)
                    ' Assign colors based on index, assuming consistent order
                    Dim colors As Color() = {Color.SteelBlue, Color.Gold, Color.DarkGreen, Color.DarkRed, Color.Indigo, Color.Tomato}
                    For i As Integer = 0 To series1.Points.Count - 1
                        If i < colors.Length Then
                            series1.Points(i).Color = colors(i)
                        Else
                            ' Use a default color or cycle back if more than 6 locations
                            series1.Points(i).Color = Color.Gray
                        End If
                    Next

                    ' 3. Find and Explode the largest revenue slice
                    If revenueData.Count > 0 Then
                        Dim maxRevenue As Double = revenueData.Values.Max()
                        ' Find the data point that corresponds to the max revenue
                        Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
                        If maxPoint IsNot Nothing AndAlso maxRevenue > 0 Then ' Only explode if max is greater than 0
                            maxPoint.CustomProperties = "Exploded=true"
                        End If
                    End If

                Catch ex As Exception
                    ' Display the specific database error to the user
                    MessageBox.Show("DATABASE ERROR: " & ex.Message & Environment.NewLine &
                                "Please check your ConnectionString and ensure the SQL Server is running.",
                                "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    '--- BAR CHART FOR AVERAGE SALES PER PERIOD ---'    
    Public Shared Sub SetupBarChartControl(panelBarGraphAverage As Panel)
        If SalesAnalytics.Controls.Find("PanelBarGraphAverage", True).Length = 0 Then
            MessageBox.Show("The PanelBarGraphAverage control was not found on the form.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        barGraph = New Chart With {
            .Dock = DockStyle.Fill,
            .BackColor = panelBarGraphAverage.BackColor
        }

        ' *** CRITICAL FIX: Add the chart control to the panel so it displays ***
        panelBarGraphAverage.Controls.Add(barGraph)
    End Sub
    Public Shared Sub InitializeBarGraphStructure()
        Dim chartData As Chart = barGraph ' Use barGraph

        ' Clear previous state if this were run multiple times
        chartData.Titles.Clear()
        chartData.Series.Clear()
        chartData.ChartAreas.Clear()

        chartData.Titles.Add("Average sales per period")
        chartData.Titles(0).Font = New Font("Century Gothic", 12, FontStyle.Bold)

        Dim chartArea As New ChartArea()
        chartData.ChartAreas.Add(chartArea)
        chartArea.AxisX.Title = "Time Period"
        chartArea.AxisY.Title = "Average Revenue (₱)"
        chartArea.AxisY.LabelStyle.Format = "₱{0:N0}" ' Format Y-Axis as Peso Currency

        ' Create the Series (the vertical bars)
        Dim series1 As New Series With {
            .Name = "AverageRevenue",
            .ChartType = SeriesChartType.Column,
            .IsValueShownAsLabel = False,
            .LabelFormat = "₱{0:N2}",
            .Color = Color.FromArgb(84, 98, 161)
        }

        chartData.Series.Add(series1)
    End Sub
    Public Shared Sub LoadAverageData(period As String)
        If barGraph Is Nothing Then ' Use barGraph
            Console.WriteLine("Bar Chart object is not initialized.")
            Exit Sub
        End If

        Dim chartData As Chart = barGraph ' Use barGraph
        Dim series1 As Series = chartData.Series("AverageRevenue")
        series1.Points.Clear() ' Clear existing points

        Dim sql As String = ""
        Dim titleSuffix As String = ""

        ' Determine which SQL query to run based on the period parameter
        Select Case period.ToLower()
            Case "day"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("DAY")
                titleSuffix = " (Per Day)"
            Case "month"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("MONTH")
                titleSuffix = " (Per Month)"
            Case "year"
                sql = SalesAnalyticsDatabaseHelper.GetDynamicAverageSalesQuery("YEAR")
                titleSuffix = " (Per Year)"
            Case Else
                MessageBox.Show("Invalid period specified for average sales data.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Update the chart title dynamically
        chartData.Titles(0).Text = "Average Sales per Period" & titleSuffix

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim periodLabel As String = reader("PeriodLabel").ToString()
                        ' Use TryParse to safely convert the average, which might be Null or DBNull
                        Dim averageSales As Double = 0.0
                        Double.TryParse(reader("AverageSales").ToString(), averageSales)

                        If averageSales > 0 Then
                            Dim dataPoint As New DataPoint()
                            dataPoint.SetValueXY(periodLabel, averageSales)

                            ' Tooltip shows the label and the Peso value with 2 decimals
                            dataPoint.ToolTip = String.Format("{0}: ₱{1:N2}", periodLabel, averageSales)

                            series1.Points.Add(dataPoint)
                        End If
                    End While

                Catch ex As Exception
                    MessageBox.Show("DATABASE ERRORasdasdasd: " & ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        ' Sort the data points in memory to ensure proper chronological order
        Dim sortedPoints = series1.Points.OrderBy(Function(p) p.AxisLabel).ToList()
        series1.Points.Clear()
        For Each point In sortedPoints
            series1.Points.Add(point)
        Next

        ' Highlight the largest bar (Optional: for quick visual insight)
        If series1.Points.Count > 0 Then
            Dim maxRevenue = series1.Points.Max(Function(p) p.YValues(0))
            Dim maxPoint As DataPoint = series1.Points.FirstOrDefault(Function(p) p.YValues(0) = maxRevenue)
            If maxPoint IsNot Nothing Then
                maxPoint.Color = Color.FromArgb(92, 81, 224) ' Highlight the highest average in red
            End If
        End If

        barGraph.Refresh() ' Use barGraph
    End Sub

End Class
