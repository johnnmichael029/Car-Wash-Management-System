
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient


Public Class Dashboard
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly dashboardDatabaseHelper As New DashboardDatabaseHelper(constr, TextBoxCustomerName)
    Private ReadOnly listofActivityLogInDashboardDatabaseHelper As ListofActivityLogInDashboardDatabaseHelper
    Private ReadOnly salesForm As New SalesForm
    Private ReadOnly activityLogService As ActivityLogInDashboardService
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.\
        dashboardDatabaseHelper = New DashboardDatabaseHelper(constr, TextBoxCustomerName)
        listofActivityLogInDashboardDatabaseHelper = New ListofActivityLogInDashboardDatabaseHelper(constr)
        activityLogService = New ActivityLogInDashboardService(constr)
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
        dashboardDatabaseHelper.PopulateCustomerNames()
        dashboardDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
        dashboardDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)

    End Sub
    Private Sub LoadSalesChart()
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String

        If isYearlyView Then
            chartData = dashboardDatabaseHelper.GetYearlySales()
            chartTitle = "Yearly Sales"
            xAxisTitle = "Year"
        ElseIf isMonthlyView Then
            chartData = dashboardDatabaseHelper.GetMonthlySales()
            chartTitle = "Monthly Sales"
            xAxisTitle = "Month"
        Else
            chartData = dashboardDatabaseHelper.GetWeeklySales()
            chartTitle = "Weekly Sales"
            xAxisTitle = "Day"
        End If
        Dim salesChartForm As New SalesChartService(chartData, chartTitle, xAxisTitle) With {
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
            Dim salesData As DataTable = dashboardDatabaseHelper.ViewSalesData()
            DataGridViewLatestTransaction.DataSource = salesData
        Else
            Dim salesData As DataTable = dashboardDatabaseHelper.GetListInSearchBar(Trim(TextBoxSearchBar.Text))
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
        Dim salesData As DataTable = dashboardDatabaseHelper.ViewSalesData()
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
        dashboardDatabaseHelper.AddCustomer(TextBoxName.Text.Trim(), TextBoxNumber.Text, TextBoxEmail.Text.Trim(), TextBoxAddress.Text.Trim(), TextBoxPlateNumber.Text.Trim())
        Carwash.PopulateAllTotal()
        NewCustomerActivityLog()
        ClearFieldsOfCustomer()
    End Sub
    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        activityLogService.AddNewCustomer(customerName)
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
            Dim baseServiceDetails As SalesInDashboardService = dashboardDatabaseHelper.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesInDashboardService = dashboardDatabaseHelper.GetServiceID(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If
            dashboardDatabaseHelper.AddSale(
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
        DashboardDatabaseHelper.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        DashboardDatabaseHelper.PrintBillInDashboard(e, New PrintDataInDashboardService With {
             .SalesID = If(DataGridViewLatestTransaction.Rows.Count > 0, Convert.ToInt32(DataGridViewLatestTransaction.Rows(0).Cells("SalesID").Value), 0),
             .CustomerName = TextBoxCustomerName.Text,
             .BaseService = ComboBoxServices.Text,
             .BaseServicePrice = If(ComboBoxServices.SelectedIndex <> -1, dashboardDatabaseHelper.GetServiceID(ComboBoxServices.Text).Price, 0D),
             .AddonService = ComboBoxAddons.Text,
             .AddonServicePrice = If(ComboBoxAddons.SelectedIndex <> -1, dashboardDatabaseHelper.GetServiceID(ComboBoxAddons.Text).Price, 0D),
             .TotalPrice = Decimal.Parse(TextBoxPrice.Text),
             .PaymentMethod = ComboBoxPaymentMethod.Text,
             .SaleDate = DateTime.Now
         })
    End Sub

    Private Sub AddSalesActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim amount As Decimal = Decimal.Parse(TextBoxPrice.Text)
        activityLogService.RecordSale(customerName, amount)
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
            Dim baseServiceDetails As SalesInDashboardService = dashboardDatabaseHelper.GetServiceID(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesInDashboardService = dashboardDatabaseHelper.GetServiceID(ComboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    'Get CustomerID when typing in the CustomerName textbox
    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Dim customerID As Integer = dashboardDatabaseHelper.GetCustomerID(TextBoxCustomerName.Text)
        If customerID > 0 Then
            TextBoxCustomerID.Text = customerID.ToString()
        Else
            TextBoxCustomerID.Text = String.Empty
        End If
    End Sub
    Private Sub ClearFieldsBtn_Click(sender As Object, e As EventArgs) Handles ClearFieldsBtn.Click
        ClearFieldsOfCustomer()
    End Sub

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs) Handles ClearBtn.Click
        ClearFieldsOfSales()
    End Sub
End Class


