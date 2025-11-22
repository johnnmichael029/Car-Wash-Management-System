Imports Microsoft.Data.SqlClient
Imports System.Drawing.Printing


Public Class Contracts
    Inherits BaseForm

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the data access layer
    End Sub
    Private Sub Contracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SettingsService.UpdateSingleDiscountComboBox(Me.ComboBoxDiscount)
        SettingsService.DiscountButtonForm(Settings.CheckBoxEnableDiscount)
        SettingsService.ApplyTotalPriceSettingsOnLoad()
        PopulateUIForContract()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewContracts()
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)
        contractsDatabaseHelper.UpdateTheStatusOfContractWhenExpired()
    End Sub

    Private Sub AddContractBtn_Click(sender As Object, e As EventArgs) Handles AddContractBtn.Click
        AddBillingContracts()
    End Sub

    Private Sub ChangeHeaderOfDataGridViewContracts()
        DataGridViewContract.Columns(0).HeaderText = "ID"
        DataGridViewContract.Columns(1).HeaderText = "Name"
        DataGridViewContract.Columns(2).HeaderText = "Base"
        DataGridViewContract.Columns(3).HeaderText = "Addon"
        DataGridViewContract.Columns(4).HeaderText = "Start"
        DataGridViewContract.Columns(5).HeaderText = "End"
        DataGridViewContract.Columns(6).HeaderText = "Billing"
        DataGridViewContract.Columns(7).HeaderText = "Payment"
        DataGridViewContract.Columns(8).HeaderText = "Reference"
        DataGridViewContract.Columns(9).HeaderText = "Price"
        DataGridViewContract.Columns(10).HeaderText = "Contract Status"
    End Sub

    Private Sub AddContractActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        activityLogInDashboardService.AddNewContract(customerName)
    End Sub

    Private Sub AddBillingContracts()

        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                     End Sub

        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
        TextBoxCustomerID,
        DateTimePickerStartDate,
        DateTimePickerEndDate,
        ComboBoxBillingFrequency,
        ComboBoxPaymentMethod,
        TextBoxReferenceID,
        TextBoxCheque,
        TextBoxTotalPrice,
        ComboBoxContractStatus,
        ComboBoxDetailer,
        contractsDatabaseHelper, ' Your ContractsDatabaseHelper instance
        localErrorHandler
    )

        If success Then
            Carwash.PopulateAllTotal()
            Carwash.NotificationLabel.Text = "New Contract Added"
            Carwash.ShowNotification()
            DataGridViewContract.DataSource = contractsDatabaseHelper.ViewContracts()

            AddContractActivityLog()
            ClearFields()
        End If
    End Sub

    Private Sub DataGridViewFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewContract)
    End Sub

    Private Sub PopulateUIForContract()
        Try
            ' Populate UI components using the data returned from the management class
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulatePaymentMethod(ComboBoxPaymentMethod)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
            employeeMangamentDatabaseHelper.PopulateDetailerForUI(ComboBoxDetailer)
            salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
            DataGridViewContract.DataSource = contractsDatabaseHelper.ViewContracts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub ComboBoxAddon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        CustomerNameTextChangedService.CustomerNameTextChanged(TextBoxCustomerID, TextBoxCustomerName)
    End Sub

    Private Sub UpdateContractBtn_Click(sender As Object, e As EventArgs) Handles UpdateContractBtn.Click

        ContractUpdated()

    End Sub

    Private Sub ContractUpdated()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                     End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
        LabelContractID,
        TextBoxCustomerID,
        DateTimePickerStartDate,
        DateTimePickerEndDate,
        ComboBoxBillingFrequency,
        ComboBoxPaymentMethod,
        TextBoxReferenceID,
        TextBoxCheque,
        ComboBoxContractStatus,
        ComboBoxDetailer,
        TextBoxTotalPrice,
        contractsDatabaseHelper,
        localErrorHandler
    )

        If success Then
            Carwash.PopulateAllTotal()
            Carwash.NotificationLabel.Text = "Contract Updated"
            Carwash.ShowNotification()

            DataGridViewContract.DataSource = ContractsDatabaseHelper.ViewContracts()
            UpdateContractActivityLog()
            ClearFields()
        End If
    End Sub

    Private Sub UpdateContractActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newStatus As String = ComboBoxContractStatus.Text
        activityLogInDashboardService.UpdateContractStatus(customerName, newStatus)
    End Sub

    Public Sub ClearFields()
        ' Clear all input fields
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        DateTimePickerStartDate.Value = DateTime.Now
        DateTimePickerEndDate.Value = DateTime.Now
        DateTimePickerEndDate.Checked = False
        ComboBoxBillingFrequency.SelectedIndex = -1

        TextBoxPrice.Clear()
        ComboBoxContractStatus.SelectedIndex = -1
        LabelContractID.Text = String.Empty
        TextBoxReferenceID.Clear()
        TextBoxCheque.Clear()
        TextBoxTotalPrice.Text = "0.00"
        ComboBoxDetailer.SelectedIndex = -1

        ListViewServices.Items.Clear()
        AddSaleToListView.ContractServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub

    Private Sub DataGridViewContract_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewContract.CellContentClick
        ' but sometimes helps ensure a selection is made on cell click.
        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewContract)


        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        DataGridCellContentClick.GetSelectedRowData(
           DataGridViewContract,
           TextBoxCustomerName,
           DateTimePickerStartDate,
           DateTimePickerEndDate,
           ComboBoxBillingFrequency,
           ComboBoxPaymentMethod,
           TextBoxReferenceID,
           TextBoxCheque,
           TextBoxTotalPrice,
           ComboBoxContractStatus,
           ComboBoxDetailer,
           LabelContractID,
           ListViewServices,
           errorHandler
        )
    End Sub

    Private Sub DataGridViewContract_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewContract.CellFormatting
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewContract)
        DataGridFormattingService.DataGridCellFormattingStatus(e, "ContractStatus", DataGridViewContract)

    End Sub

    Private Sub DataGridViewContract_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewContract.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub ClearFieldsBtn_Click(sender As Object, e As EventArgs) Handles ClearFieldsBtn.Click
        ClearFields()
    End Sub

    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub

    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelContractID.Text) Then
            MessageBox.Show("Please select contract from the table or add a new contract to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PrintBillInContractsService.ShowPrint(PrintDocumentBill)
        End If
    End Sub

    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentContractID As Integer = Convert.ToInt32(DataGridViewContract.CurrentRow.Cells(0).Value)
        Dim startDate As DateTime = Convert.ToDateTime(DataGridViewContract.CurrentRow.Cells(4).Value)

        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentContractID > 0 AndAlso contractsDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = ContractsDatabaseHelper.GetSaleLineItems(currentContractID, Me.constr)
        End If

        PrintBillInContractsService.PrintBillInContractsService(e, New PrintDataInContractsService With {
           .ContractID = currentContractID,
           .CustomerName = TextBoxCustomerName.Text,
           .ServiceLineItems = serviceLineItems,
           .BillingFrequency = ComboBoxBillingFrequency.Text,
           .PaymentMethod = ComboBoxPaymentMethod.Text,
           .SaleDate = DataGridViewContract.CurrentRow.Cells(4).Value,
           .StartDate = DateTimePickerStartDate.Value,
           .EndDate = DateTimePickerEndDate.Value,
           .ContractStatus = ComboBoxContractStatus.Text,
           .Discount = If(ComboBoxDiscount.SelectedItem IsNot Nothing, Convert.ToDecimal(ComboBoxDiscount.SelectedItem), 0D),
           .Detailer = ComboBoxDetailer.Text
       })
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleServiceInContractForm(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedServiceInContractForm(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        PaymentMethodSelectedService.PaymentMethodChange(ComboBoxPaymentMethod, TextBoxReferenceID, TextBoxCheque)
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub ComboBoxDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiscount.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForContract(TextBoxSearchBar, DataGridViewContract)
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub
End Class

