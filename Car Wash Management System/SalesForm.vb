
Imports System.Drawing.Printing
Imports System.Linq.Expressions
Imports Microsoft.Data.SqlClient
Public Class SalesForm
    Inherits BaseForm
    Public Sub New()

        MyBase.New()

        InitializeComponent()

    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        SettingsService.UpdateSingleDiscountComboBox(ComboBoxDiscount)
        SettingsService.ApplyTotalPriceSettingsOnLoad()
        SettingsService.DiscountButtonForm(Settings.CheckBoxEnableDiscount)

        LoadAllPopulateUI()
        ClearFields()
        DataGridViewSalesFontStyle()
        ChangeHeaderOfDataGridViewSales()
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)

    End Sub



    Private Sub ChangeHeaderOfDataGridViewSales()
        DataGridViewSales.Columns(0).HeaderText = "Sales ID"
        DataGridViewSales.Columns(1).HeaderText = "Customer Name"
        DataGridViewSales.Columns(2).HeaderText = "Base Service"
        DataGridViewSales.Columns(3).HeaderText = "Addon Service"
        DataGridViewSales.Columns(4).HeaderText = "Sale Date"
        DataGridViewSales.Columns(5).HeaderText = "Payment Method"
        DataGridViewSales.Columns(6).HeaderText = "Reference ID"
        DataGridViewSales.Columns(7).HeaderText = "Detailer"
        DataGridViewSales.Columns(8).HeaderText = "Total Price"
    End Sub

    Private Sub LoadAllPopulateUI()
        Try
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulatePaymentMethod(ComboBoxPaymentMethod)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
            employeeMangamentDatabaseHelper.PopulateDetailerForUI(ComboBoxDetailer)
            salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
            DataGridViewSales.DataSource = SalesDatabaseHelper.ViewSales()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
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
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "New Sale Added"

            AddSalesActivityLog()
            ViewSales()
            PrintBillInSales.ShowPrint(PrintDocumentBill)
            ClearFields()
        End If

    End Sub

    Private Sub AddSalesActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim amount As Decimal = Decimal.Parse(TextBoxTotalPrice.Text)
        activityLogInDashboardService.RecordSale(customerName, amount)
    End Sub

    Private Sub UpdateSalesActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        activityLogInDashboardService.UpdateSale(customerName)
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

    Private Sub ClearBtn_Click(sender As Object, e As EventArgs) Handles ClearBtn.Click
        ClearFields()
    End Sub

    Public Sub ClearFields()
        TextBoxCustomerName.Clear()
        TextBoxCustomerID.Clear()
        TextBoxPrice.Text = "0.00"
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        ComboBoxPaymentMethod.SelectedIndex = -1
        ComboBoxDetailer.SelectedIndex = -1
        TextBoxReferenceID.Clear()
        ListViewServices.Items.Clear()
        TextBoxTotalPrice.Text = "0.00"
        AddSaleToListView.SaleServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub

    Private Sub DataGridViewSalesFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewSales)
    End Sub

    Private Sub DataGridViewSales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSales.CellContentClick
        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewSales)

        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        DataGridCellContentClick.GetSelectedRowData(
           TextBoxCustomerName,
           DataGridViewSales,
           ComboBoxPaymentMethod,
           TextBoxReferenceID,
           TextBoxCheque,
           TextBoxTotalPrice,
           ComboBoxDetailer,
           LabelSalesID,
           ListViewServices,
           errorHandler)

    End Sub

    Private Sub DataGridViewSales_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSales.CellFormatting
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewSales)
    End Sub

    Private Sub DataGridViewSales_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewSales.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage

        Dim currentSaleID As Integer = Convert.ToInt32(DataGridViewSales.CurrentRow.Cells(0).Value)
        Dim saleDate As DateTime = Convert.ToDateTime(DataGridViewSales.CurrentRow.Cells(4).Value)

        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentSaleID > 0 AndAlso salesDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = SalesDatabaseHelper.GetSaleLineItems(currentSaleID, Me.constr)
        End If

        ' 3. Populate PrintDataInSales using the comprehensive list.
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

    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelSalesID.Text) Then
            MessageBox.Show("Please select sales from the table or add new sales to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PrintBillInSales.ShowPrint(PrintDocumentBill)
        End If
    End Sub

    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        PaymentMethodSelectedService.PaymentMethodChange(ComboBoxPaymentMethod, TextBoxReferenceID, TextBoxCheque)
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleService(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedService(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateSales()
    End Sub

    Private Sub UpdateSales()

        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
        TextBoxCustomerID,
        LabelSalesID,
        ComboBoxPaymentMethod,
        TextBoxReferenceID,
        TextBoxCheque,
        ComboBoxDetailer,
        TextBoxTotalPrice,
        localErrorHandler
    )

        If success Then
            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "Sale Updated"

            UpdateSalesActivityLog()
            MessageBox.Show("Sale updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ViewSales()
            ClearFields()
        End If

    End Sub

    Private Sub ViewSales()
        DataGridViewSales.DataSource = salesDatabaseHelper.ViewSales()
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub ComboBoxDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiscount.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForRegularSale(TextBoxSearchBar, DataGridViewSales)
    End Sub

    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub

End Class


