
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient


Public Class Dashboard
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly dashboardManagement As New DashboardManagement(constr, TextBoxCustomerName)
    Private ReadOnly listOfActivityLog As ListOfActivityLog
    Private ReadOnly salesForm As New SalesForm()
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.\
        dashboardManagement = New DashboardManagement(constr, TextBoxCustomerName)
        listOfActivityLog = New ListOfActivityLog(constr)
    End Sub
    Public Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSalesChart()
        LoadLatestTransaction()
        DataGridViewLatestTransactionFontStyle()
        ChangeHeaderOfDataGridViewLatestTransaction()
        LoadAllPopulateUI()
        ClearFieldsOfSales()
    End Sub

    Private Sub LoadAllPopulateUI()
        dashboardManagement.PopulateCustomerNames()
        dashboardManagement.PopulateBaseServicesForUI(ComboBoxServices)
        dashboardManagement.PopulateAddonServicesForUI(ComboBoxAddons)

    End Sub
    Private Sub LoadSalesChart()
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String

        If isYearlyView Then
            chartData = dashboardManagement.GetYearlySales()
            chartTitle = "Yearly Sales"
            xAxisTitle = "Year"
        ElseIf isMonthlyView Then
            chartData = dashboardManagement.GetMonthlySales()
            chartTitle = "Monthly Sales"
            xAxisTitle = "Month"
        Else
            chartData = dashboardManagement.GetWeeklySales()
            chartTitle = "Weekly Sales"
            xAxisTitle = "Day"
        End If
        Dim salesChartForm As New SalesChartForm(chartData, chartTitle, xAxisTitle) With {
            .TopLevel = False,
            .FormBorderStyle = FormBorderStyle.None
        }

        PanelMontlySales.Controls.Clear()
        PanelMontlySales.Controls.Add(salesChartForm)
        salesChartForm.Dock = DockStyle.Fill
        salesChartForm.Show()
    End Sub

    Private Sub ButtonToggleChart_Click(sender As Object, e As EventArgs) Handles ButtonToggleChart.Click
        'Toggle On and Off
        isMonthlyView = Not isMonthlyView And Not isYearlyView
        isYearlyView = Not isYearlyView And Not isMonthlyView
        If isYearlyView Then
            ButtonToggleChart.Text = "Weekly Sales"
        ElseIf isMonthlyView Then
            ButtonToggleChart.Text = "Yearly Sales"
        Else
            ButtonToggleChart.Text = "Monthly Sales"
        End If
        LoadSalesChart()
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        TextBoxSearchBar.Text = ""
    End Sub
    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarFunction()
    End Sub
    Private Sub SearchBarFunction()
        If String.IsNullOrWhiteSpace(TextBoxSearchBar.Text) Then
            Dim salesData As DataTable = dashboardManagement.ViewSalesData()
            DataGridViewLatestTransaction.DataSource = salesData
        Else
            Dim salesData As DataTable = dashboardManagement.GetListInSearchBar(Trim(TextBoxSearchBar.Text))
            DataGridViewLatestTransaction.DataSource = salesData
        End If
    End Sub
    Private Sub ChangeHeaderOfDataGridViewLatestTransaction()
        DataGridViewLatestTransaction.Columns("SalesID").HeaderText = "Sales ID"
        DataGridViewLatestTransaction.Columns("CustomerName").HeaderText = "Customer Name"
        DataGridViewLatestTransaction.Columns("BaseServiceName").HeaderText = "Base Service"
        DataGridViewLatestTransaction.Columns("AddonServiceName").HeaderText = "Addon Service"
        DataGridViewLatestTransaction.Columns("SaleDate").HeaderText = "Sale Date"
        DataGridViewLatestTransaction.Columns("PaymentMethod").HeaderText = "Payment Method"
        DataGridViewLatestTransaction.Columns("TotalPrice").HeaderText = "Total Price (₱)"
    End Sub
    Private Sub DataGridViewLatestTransactionFontStyle()
        DataGridViewLatestTransaction.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewLatestTransaction.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub LoadLatestTransaction()
        Dim salesData As DataTable = dashboardManagement.ViewSalesData()
        DataGridViewLatestTransaction.DataSource = salesData
    End Sub

    Private Sub AddCustomerBtn_Click(sender As Object, e As EventArgs) Handles AddCustomerBtn.Click
        AddCustomer()
    End Sub
    Private Sub AddCustomer()
        If String.IsNullOrWhiteSpace(TextBoxName.Text) Or String.IsNullOrWhiteSpace(TextBoxNumber.Text) Or String.IsNullOrWhiteSpace(TextBoxEmail.Text) Or String.IsNullOrWhiteSpace(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        dashboardManagement.AddCustomer(TextBoxName.Text.Trim(), TextBoxNumber.Text, TextBoxEmail.Text.Trim(), TextBoxAddress.Text.Trim(), TextBoxPlateNumber.Text.Trim())
        Carwash.PopulateAllTotal()
        NewCustomerActivityLog()
        ClearFieldsOfCustomer()
    End Sub
    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        listOfActivityLog.AddNewCustomer(customerName)
    End Sub
    Private Sub ClearFieldsOfCustomer()
        TextBoxName.Clear()
        TextBoxNumber.Clear()
        TextBoxEmail.Clear()
        TextBoxAddress.Clear()
        TextBoxPlateNumber.Clear()
    End Sub

    Private Sub AddSalesBtn_Click(sender As Object, e As EventArgs) Handles AddSalesBtn.Click
        AddBtnFunction()
    End Sub
    Private Sub AddBtnFunction()
        Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
        Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)
        Dim totalPrice As Decimal = TextBoxPrice.Text
        Try
            'The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate that a base service is selected.
            If String.IsNullOrWhiteSpace(baseServiceName) Then
                MessageBox.Show("Please select a base service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate that a payment method is selected.
            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As SalesServiceDetailsInDashboard = dashboardManagement.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesServiceDetailsInDashboard = dashboardManagement.GetServiceID(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If


            dashboardManagement.AddSale(
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                ComboBoxPaymentMethod.SelectedItem.ToString(),
                totalPrice
                )
            Carwash.PopulateAllTotal()
            LoadLatestTransaction()
            MessageBox.Show("Sale added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddSalesActivityLog()
            ShowPrintPreview()
            ClearFieldsOfSales()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ClearFieldsOfSales()
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        TextBoxPrice.Text = 0.00D.ToString("N2")
        ComboBoxPaymentMethod.SelectedIndex = -1
    End Sub
    Public Sub ShowPrintPreview()
        DashboardManagement.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        DashboardManagement.PrintBillInDashboard(e, New PrintDataInDashboard With {
             .SalesID = If(DataGridViewLatestTransaction.Rows.Count > 0, Convert.ToInt32(DataGridViewLatestTransaction.Rows(0).Cells("SalesID").Value), 0),
             .CustomerName = TextBoxCustomerName.Text,
             .BaseService = ComboBoxServices.Text,
             .BaseServicePrice = If(ComboBoxServices.SelectedIndex <> -1, dashboardManagement.GetServiceID(ComboBoxServices.Text).Price, 0D),
             .AddonService = ComboBoxAddons.Text,
             .AddonServicePrice = If(ComboBoxAddons.SelectedIndex <> -1, dashboardManagement.GetServiceID(ComboBoxAddons.Text).Price, 0D),
             .TotalPrice = Decimal.Parse(TextBoxPrice.Text),
             .PaymentMethod = ComboBoxPaymentMethod.Text,
             .SaleDate = DateTime.Now
         })
    End Sub

    Private Sub AddSalesActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim amount As Decimal = Decimal.Parse(TextBoxPrice.Text)
        listOfActivityLog.RecordSale(customerName, amount)
    End Sub
    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        CalculateTotalPrice()
    End Sub

    Private Sub ComboBoxAddons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        CalculateTotalPrice()
    End Sub
    Private Sub CalculateTotalPrice()
        Dim totalPrice As Decimal = 0.0D

        If ComboBoxServices.SelectedIndex <> -1 Then
            Dim baseServiceDetails As SalesServiceDetailsInDashboard = dashboardManagement.GetServiceID(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesServiceDetailsInDashboard = dashboardManagement.GetServiceID(ComboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    'Get CustomerID when typing in the CustomerName textbox
    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Dim customerID As Integer = dashboardManagement.GetCustomerID(TextBoxCustomerName.Text)
        If customerID > 0 Then
            TextBoxCustomerID.Text = customerID.ToString()
        Else
            TextBoxCustomerID.Text = String.Empty
        End If
    End Sub

End Class

Public Class SalesChartForm
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
            .MarkerColor = Color.Black
        }
        chart1.Series.Add(series1)

        ' Set the title of the chart.
        Dim title1 As New Title With {
            .Text = chartTitle,
            .Font = New Font("Century Gothic", 15, FontStyle.Bold)
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

Public Class DashboardManagement
    Private ReadOnly constr As String

    Private ReadOnly textBoxCustomerName As TextBox
    Public Sub New(connectionString As String, customerNameTextBox As TextBox)
        constr = connectionString
        Me.textBoxCustomerName = customerNameTextBox

    End Sub

    ''' <summary>
    ''' View Sales Data from the SalesHistoryTable along with Customer and Service details.
    ''' </summary>
    Public Function ViewSalesData() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(constr)
            conn.Open()
            Dim ViewQuery As String = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s
                                     INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
                                     INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
                                     LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SalesID DESC"
            Using cmd As New SqlCommand(ViewQuery, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales grouped by year from the SalesHistoryTable.
    ''' </summary>
    Public Function GetYearlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate) ORDER BY SalesYear"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetYearlySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales grouped by month and year from the SalesHistoryTable.
    ''' </summary>
    Public Function GetMonthlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, MONTH(SaleDate) AS SalesMonth, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate), MONTH(SaleDate) ORDER BY SalesYear, SalesMonth"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetMonthlySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales for the past 7 days from the SalesHistoryTable.
    ''' </summary>
    Public Function GetWeeklySales() As DataTable
        Dim query As String = "SELECT CAST(SaleDate AS DATE) AS SaleDate, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable WHERE SaleDate >= DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) GROUP BY CAST(SaleDate AS DATE) ORDER BY SaleDate ASC"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
        End Try
        Return dt
    End Function
    Public Function GetListInSearchBar(searchInBar As String) As DataTable
        Dim dt As New DataTable()

        Dim query As String = "
            SELECT
                s.SalesID,
                c.Name AS CustomerName,
                sv.ServiceName AS BaseServiceName,
                sv_addon.ServiceName AS AddonServiceName,
                s.SaleDate,
                s.PaymentMethod,
                s.TotalPrice
            FROM SalesHistoryTable s
            INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
            INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
            LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID
            WHERE c.Name LIKE @searchString
            OR sv.ServiceName LIKE @searchString
            OR sv_addon.ServiceName LIKE @searchString
            OR s.SalesID LIKE @searchString
            OR s.PaymentMethod LIKE @searchString
            "
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@searchString", "%" & searchInBar & "%")
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                Catch ex As Exception
                    Console.WriteLine("Error in GetListInSearchBar: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Gets the activity log from the ActivityLogTable.
    ''' </summary>



    Public Sub AddSale(customerID As Integer, baseServiceID As Integer, addonServiceID As Integer?, paymentMethod As String, totalPrice As Decimal)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery = "INSERT INTO SalesHistoryTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPrice)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@ServiceID", baseServiceID)
                    ' Handle the nullable addonServiceID parameter
                    If addonServiceID.HasValue Then
                        cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                    Else
                        cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                    End If
                    cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                    cmd.ExecuteNonQuery()
                    Carwash.NotificationLabel.Text = "New Sale Added"
                    Carwash.ShowNotification()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Sub AddCustomer(name As String, number As String, email As String, address As String, plateNumber As String)
        Dim customerInformationManagement As New CustomerInformationManagement(constr)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, PlateNumber, RegistrationDate) VALUES (@Name, @PhoneNumber, @Email, @Address, @PlateNUmber, @RegistrationDate)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@PhoneNumber", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    If String.IsNullOrEmpty(address) Then
                        cmd.Parameters.AddWithValue("@Address", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@Address", address)
                    End If
                    cmd.Parameters.AddWithValue("@PlateNUmber", plateNumber)
                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                Carwash.NotificationLabel.Text = "New Customer Information"
                Carwash.ShowNotification()
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
    Public Shared Sub PrintBillInDashboard(e As PrintPageEventArgs, printData As PrintDataInDashboard)
        If printData Is Nothing Then
            ' Handle case where no data is set
            Return
        End If

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        'Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12


        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' Add bill details from the class-level printData object

        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & printData.SalesID, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.BaseService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString(printData.BaseServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        If Not String.IsNullOrWhiteSpace(printData.AddonService) Then
            yPos += offset
            e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
            e.Graphics.DrawString("Add-on: " & printData.AddonService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
            e.Graphics.DrawString(printData.AddonServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
            yPos += offset
        End If
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Total:", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        yPos += offset

        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString("Payment", f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset

        e.Graphics.DrawString(printData.PaymentMethod, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
    Public Sub PopulateBaseServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving base services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateAddonServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Filter by both the Addon flag and the specific service names
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving addon services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateCustomerNames()
        Dim customerNames As New AutoCompleteStringCollection()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            customerNames.Add(reader.GetString(0))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Me.textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.textBoxCustomerName.AutoCompleteCustomSource = customerNames
    End Sub
    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            Try
                con.Open()
                Dim selectQuery = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        customerID = CType(result, Integer)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return customerID
        End Using
    End Function

    Public Function GetServiceID(serviceName As String) As SalesServiceDetailsInDashboard
        Using con As New SqlConnection(constr)
            Dim details As New SalesServiceDetailsInDashboard()
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, Price FROM ServicesTable WHERE ServiceName = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", serviceName)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        details.ServiceID = reader.GetInt32(0)
                        details.Price = reader.GetDecimal(1)
                    End If
                End Using
            End Using
            Return details
        End Using
    End Function

End Class
Public Class ListOfActivityLog
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Sub LogActivity(action As String, description As String)
        Try
            Using conn As New SqlConnection(constr)
                conn.Open()
                Dim insertActivityLogQuery As String = "INSERT INTO ActivityLogTable (ActionType, Description, Timestamp) VALUES (@action, @description, @timestamp)"
                Using cmd As New SqlCommand(insertActivityLogQuery, conn)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

            MessageBox.Show("Error logging activity: " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Gets the activity log from the ActivityLogTable.
    ''' </summary>

    Public Sub AddNewCustomer(customerName As String)
        LogActivity("New Customer Added", $"A new customer '{customerName}' was added to the system.")
    End Sub
    Public Sub AddNewService(serviceName As String)
        LogActivity("New Service Added", $"A new service '{serviceName}' was added to the system.")
    End Sub
    Public Sub RecordSale(customerName As String, amount As Decimal)
        LogActivity("New Sale", $"A new sale was recorded for customer: '{customerName}'. Amount: ₱{amount:N2}")
    End Sub
    Public Sub ScheduleAppointment(customerName As String, appointmentDate As DateTime, appointmentStatus As String)
        LogActivity("New Appointment Scheduled", $"An appointment was scheduled for customer: '{customerName}' on {appointmentDate}. status '{appointmentStatus}'")
    End Sub
    Public Sub UpdateAppointmentStatus(customerName As String, newStatus As String)
        LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub RecordActivity(customerName As String, newStatus As String)
        LogActivity("Appointment Status Update", $"An appointment was scheduled for '{customerName}' was changed to new status '{newStatus}'")
    End Sub
    Public Sub AddNewContract(customerName As String)
        LogActivity("New Contract Added", $"A new contract was created for: '{customerName}'.")
    End Sub
    Public Sub UpdateContractStatus(customerName As String, newStatus As String)
        LogActivity("Contract Status Update", $"Contract for '{customerName}' was changed to new status '{newStatus}'.")
    End Sub
    Public Sub UserLogout(username As String)
        LogActivity("User Logout", $"User '{username}' logged out of the system.")
    End Sub
    Public Sub UserLogin(username As String)
        LogActivity("User Login", $"User '{username}' logged into the system.")
    End Sub
End Class

Public Class SalesServiceDetailsInDashboard
    Public Property ServiceID As Integer
    Public Property Price As Decimal
End Class
Public Class PrintDataInDashboard
    Public Property SalesID As Integer
    Public Property CustomerName As String
    Public Property BaseService As String
    Public Property AddonService As String
    Public Property TotalPrice As Decimal
    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
    Public Property BaseServicePrice As Decimal
    Public Property AddonServicePrice As Decimal
End Class
