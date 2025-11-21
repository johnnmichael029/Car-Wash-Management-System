
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient


Public Class Dashboard
    Inherits BaseForm

    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private currentSearchTerm As String = String.Empty

    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.



    End Sub
    Public Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingsService.UpdateSingleDiscountComboBox(Me.ComboBoxDiscount)
        SettingsService.DiscountButtonForm(Settings.CheckBoxEnableDiscount)
        SettingsService.ApplyTotalPriceSettingsOnLoad()
        LoadSalesChart()
        LoadLatestTransaction()
        DataGridViewLatestTransactionFontStyle()
        ChangeHeaderOfDataGridViewLatestTransaction()
        LoadAllPopulateUI()
        ClearFieldsOfSales()
        PopulateAllListInComboBoxFilter()
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)
        SetupListViewService.SetupListViewForVehicles(ListViewVehicles, 30, 135, 85)
        DisplayNextSalesID()
    End Sub

    Private Sub LoadAllPopulateUI()
        SalesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
        SalesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
        salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
        employeeMangamentDatabaseHelper.PopulateDetailerForUI(ComboBoxDetailer)




    End Sub
    Private Sub LoadSalesChart()
        Dim chartData As DataTable
        Dim chartTitle As String
        Dim xAxisTitle As String

        If isYearlyView Then
            chartData = DashboardDatabaseHelper.GetYearlySales()
            chartTitle = "Yearly Sales"
            xAxisTitle = "Year"
        ElseIf isMonthlyView Then
            chartData = DashboardDatabaseHelper.GetMonthlySales()
            chartTitle = "Monthly Sales"
            xAxisTitle = "Month"
        Else
            chartData = DashboardDatabaseHelper.GetDailySales()
            chartTitle = "Daily Sales"
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
        If isYearlyView Then
            ' Currently Daily view
            isYearlyView = False
            isMonthlyView = False
            ' Day is the implicit default (Else)
            ButtonToggleChart.Text = "Daily Sales"

        ElseIf isMonthlyView Then
            ' Currently Yearly view
            isMonthlyView = False
            isYearlyView = True
            ButtonToggleChart.Text = "Yearly Sales"
        Else
            ' Currently Monthly view
            isMonthlyView = True
            isYearlyView = False
            ButtonToggleChart.Text = "Monthly Sales"
        End If

        LoadSalesChart()
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub
    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarFunction()
    End Sub
    Private Sub SearchBarFunction()
        SearchBarService.SearchBarFunction(TextBoxSearchBar, DataGridViewLatestTransaction, ComboBoxFilter)
    End Sub
    Private Sub ChangeHeaderOfDataGridViewLatestTransaction()
        DataGridViewLatestTransaction.Columns("SalesID").HeaderText = "Sales ID"
        DataGridViewLatestTransaction.Columns("CustomerName").HeaderText = "Customer Name"
        DataGridViewLatestTransaction.Columns(2).HeaderText = "Base Service"
        DataGridViewLatestTransaction.Columns(3).HeaderText = "Addon Service"
        DataGridViewLatestTransaction.Columns(4).HeaderText = "Sale Date"
        DataGridViewLatestTransaction.Columns(5).HeaderText = "Payment Method"
        DataGridViewLatestTransaction.Columns(6).HeaderText = "Payment Reference"
        DataGridViewLatestTransaction.Columns(7).HeaderText = "Total Price (₱)"
    End Sub

    Private Sub DataGridViewLatestTransaction_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewLatestTransaction.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub DataGridViewLatestTransaction_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewLatestTransaction.CellFormatting
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewLatestTransaction)

    End Sub

    Private Sub DataGridViewLatestTransactionFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewLatestTransaction)
    End Sub

    Private Sub LoadLatestTransaction()
        Dim salesData As DataTable = dashboardDatabaseHelper.ViewSalesData()
        DataGridViewLatestTransaction.DataSource = salesData
    End Sub

    Private Sub AddCustomerBtn_Click(sender As Object, e As EventArgs) Handles AddCustomerBtn.Click
        AddCustomerInformation()
    End Sub
    Public Sub AddCustomerInformation()

        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                     End Sub

        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
        TextBoxName,
        TextBoxLastName,
        TextBoxNumber,
        TextBoxEmail,
        TextBoxAddress,
        TextBoxBarangay,
        customerInformationDatabaseHelper,
        localErrorHandler
    )

        If success Then
            Carwash.PopulateAllTotal()

            NewCustomerActivityLog()
            ClearFieldsOfCustomer()
        End If

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
        ListViewVehicles.Items.Clear()
        AddVehicleToListView.VehicleList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub

    Private Sub AddSalesBtn_Click(sender As Object, e As EventArgs) Handles AddSalesBtn.Click
        AddBtnFunction()
    End Sub
    Private Sub AddBtnFunction()
        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
            TextBoxCustomerID,
            ComboBoxPaymentMethod,
            TextBoxReferenceID,
            TextBoxCheque,
            ComboBoxDetailer,
            TextBoxTotalPrice,
            errorHandler
        )
        If success Then
            Carwash.PopulateAllTotal()
            LoadLatestTransaction()

            AddSalesActivityLog()
            ShowPrintPreview()
            DisplayNextSalesID()
            ClearFieldsOfSales()
        End If


    End Sub
    Private Sub ClearFieldsOfSales()
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        TextBoxPrice.Text = 0.00D.ToString("N2")
        ComboBoxPaymentMethod.SelectedIndex = -1
        TextBoxReferenceID.Clear()
        TextBoxCheque.Clear()
        ComboBoxDetailer.SelectedIndex = -1
        ListViewServices.Items.Clear()
        TextBoxTotalPrice.Text = "0.00"
        AddSaleToListView.SaleServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub
    Public Sub ShowPrintPreview()
        PrintBillInSales.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentSaleID = Convert.ToInt32(LabelSalesID.Text)
        Dim saleDate = Convert.ToDateTime(DataGridViewLatestTransaction.CurrentRow.Cells(4).Value)
        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentSaleID > 0 AndAlso SalesDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = SalesDatabaseHelper.GetSaleLineItems(currentSaleID, Me.constr)
        End If

        ' *** PASSING ReferenceID and TotalPrice to PrintBillInSales ***
        Dim totalPriceDecimal As Decimal = 0
        If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPriceDecimal) Then
            ' Should not happen if AddBtnFunction validates input, but provides a fallback
            totalPriceDecimal = 0D
        End If

        PrintBillInSales.PrintBillInSales(e, New PrintDataInSales With {
        .SalesID = currentSaleID,
        .CustomerName = TextBoxCustomerName.Text,
        .ServiceLineItems = serviceLineItems,
        .PaymentMethod = ComboBoxPaymentMethod.Text,
        .SaleDate = saleDate,
        .Discount = If(ComboBoxDiscount.SelectedItem IsNot Nothing, Convert.ToDecimal(ComboBoxDiscount.SelectedItem), 0D),
        .Detailer = ComboBoxDetailer.Text
        })
    End Sub
    Private Sub AddSalesActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim amount As Decimal = Decimal.Parse(TextBoxPrice.Text)
        activityLogService.RecordSale(customerName, amount)
    End Sub
    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub ComboBoxAddons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub
    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        CustomerNameTextChangedService.CustomerNameTextChanged(TextBoxCustomerID, TextBoxCustomerName)
    End Sub
    Private Sub ClearFieldsBtn_Click(sender As Object, e As EventArgs) Handles ClearFieldsBtn.Click
        ClearFieldsOfCustomer()
    End Sub

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs) Handles ClearBtn.Click
        ClearFieldsOfSales()
    End Sub

    Private Sub PopulateAllListInComboBoxFilter()
        ComboBoxFilter.Items.Clear()
        ComboBoxFilter.Items.Add("Filter")
        ComboBoxFilter.Items.Add("Base Service")
        ComboBoxFilter.Items.Add("Addon Service")
        ComboBoxFilter.Items.Add("All Columns")
        ComboBoxFilter.SelectedIndex = 0
    End Sub

    Private Sub AddVehicleBtn_Click(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        AddVehicleToListView.AddVehicleFunction(ListViewVehicles, TextBoxPlateNumber, TextBoxVehicle)
    End Sub

    Private Sub RemoveVehicleBtn_Click(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        AddVehicleToListView.RemoveSelectedVehicle(ListViewVehicles)
    End Sub

    Private Sub RemoveSelectedVehicle()
        If ListViewVehicles.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a vehicle from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected ListViewItem
        Dim selectedItem As ListViewItem = ListViewVehicles.SelectedItems(0)

        ' Get the Plate Number, which is used as the unique key to match the object in VehicleList
        Dim plateNumberToRemove As String = selectedItem.Text

        ' 1. Remove the vehicle from the local tracking list (VehicleList)
        Dim vehiclesRemovedCount As Integer = AddVehicleToListView.VehicleList.RemoveAll(Function(v)
                                                                                             Return v.PlateNumber.Equals(plateNumberToRemove, StringComparison.OrdinalIgnoreCase)
                                                                                         End Function)

        If vehiclesRemovedCount > 0 Then
            ' 2. Remove the item from the visual ListView control
            ListViewVehicles.Items.Remove(selectedItem)
            MessageBox.Show($"Vehicle with Plate {plateNumberToRemove} removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected vehicle in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedService(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleService(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        PaymentMethodSelectedService.PaymentMethodChange(ComboBoxPaymentMethod, TextBoxReferenceID, TextBoxCheque)
    End Sub

    Private Sub ViewLatestSales()
        DataGridViewLatestTransaction.DataSource = SalesDatabaseHelper.ViewSales()
    End Sub

    Private Sub DisplayNextSalesID()
        ' 1. Get the next available ID from the database
        Dim nextId As Integer = DashboardDatabaseHelper.GetNextSalesID()

        If nextId > 0 Then
            LabelSalesID.Text = nextId.ToString()
        Else
            LabelSalesID.Text = "Sales ID: ERROR"
        End If
    End Sub

    Private Sub FullScreenVehicleBtn_Click(sender As Object, e As EventArgs) Handles FullScreenVehicleBtn.Click
        ShowPanelDocked.ShowVehiclePanelDocked(PanelVehicleInfo, ListViewVehicles)
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub PanelMontlySales_Paint(sender As Object, e As PaintEventArgs) Handles PanelMontlySales.Paint

    End Sub

    Private Sub ComboBoxDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiscount.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub DataGridViewLatestTransaction_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewLatestTransaction.CellContentClick

    End Sub
End Class


