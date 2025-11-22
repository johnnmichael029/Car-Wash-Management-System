Public Class PickUp
    Inherits BaseForm
    Private ReadOnly viewPickupInfo As ViewPickupInfo
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        viewPickupInfo = New ViewPickupInfo(Me)
    End Sub

    Private Sub PickUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadAllPopulateUI()
        AddButtonAction()
        ClearFields()
        ChangeHeaderOfDataGridViewSales()
        DataGridViewSalesFontStyle()


        SettingsService.UpdateSingleDiscountComboBox(Me.ComboBoxDiscount)
        SettingsService.DiscountButtonForm(Settings.CheckBoxEnableDiscount)
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)
        SettingsService.ApplyTotalPriceSettingsOnLoad()

    End Sub
    Private Sub AddAppointmentBtn_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub DataGridViewPickup_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewPickup.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub DataGridViewAppointment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPickup.CellContentClick
        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewPickup)

        If e.ColumnIndex = DataGridViewPickup.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
            viewPickupInfo.Show()
            viewPickupInfo.LabelPickupID.Text = DataGridViewPickup.CurrentRow.Cells("PickupID").Value.ToString()
            viewPickupInfo.TextBoxPickupAddress.Text = DataGridViewPickup.CurrentRow.Cells("PickupAddress").Value.ToString()
        End If

        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        DataGridCellContentClick.GetSelectedRowData(
            DataGridViewPickup,
            TextBoxCustomerName,
            DateTimePickerStartDate,
            TextBoxPickupAddress,
            ComboBoxPaymentMethod,
            TextBoxReferenceID,
            TextBoxCheque,
            TextBoxTotalPrice,
            ComboBoxPickupStatus,
            ComboBoxDetailer,
            TextBoxNotes,
            LabelPickupID,
            ListViewServices,
            errorHandler
        )
    End Sub

    Private Sub DataGridViewPickup_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPickup.CellFormatting
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewPickup)
        DataGridFormattingService.DataGridCellFormattingStatus(e, "PickupStatus", DataGridViewPickup)
    End Sub

    Private Sub LoadAllPopulateUI()
        Try
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulatePaymentMethod(ComboBoxPaymentMethod)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
            salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
            employeeMangamentDatabaseHelper.PopulateDetailerForUI(ComboBoxDetailer)

            DataGridViewPickup.DataSource = PickupManagementDatabaseHelper.ViewPickupData()

            ' *** FIX 1: Set the display index after data binding for initial load ***

            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub ClearFields()

        DateTimePickerStartDate.Value = DateTime.Now

        ComboBoxPaymentMethod.SelectedIndex = -1
        ComboBoxDiscount.SelectedIndex = -1
        ComboBoxPickupStatus.SelectedIndex = -1
        ComboBoxDetailer.SelectedIndex = -1
        ListViewServices.Items.Clear()

        TextBoxCustomerName.Clear()
        TextBoxPickupAddress.Clear()
        TextBoxReferenceID.Clear()
        TextBoxCheque.Clear()
        TextBoxPrice.Text = "0.00"
        TextBoxTotalPrice.Text = "0.00"

        TextBoxNotes.Text = ""
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        TextBoxNotes.Clear()

        AddSaleToListView.PickupServiceList.Clear()
        AddSaleToListView.nextServiceID = 1

    End Sub

    Private Sub DataGridViewSalesFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewPickup)
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleServiceInPickupForm(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedServiceInPickupForm(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        CustomerNameTextChangedService.CustomerNameTextChanged(TextBoxCustomerID, TextBoxCustomerName)
    End Sub

    Private Sub ChangeHeaderOfDataGridViewSales()
        DataGridViewPickup.Columns(0).HeaderText = "ID"
        DataGridViewPickup.Columns(1).HeaderText = "Name"
        DataGridViewPickup.Columns(2).HeaderText = "Service"
        DataGridViewPickup.Columns(3).HeaderText = "Addone"
        DataGridViewPickup.Columns(4).HeaderText = "Date"
        DataGridViewPickup.Columns(5).HeaderText = "Address"
        DataGridViewPickup.Columns(6).HeaderText = "Payment"
        DataGridViewPickup.Columns(7).HeaderText = "Reference"
        DataGridViewPickup.Columns(8).HeaderText = "Price"
        DataGridViewPickup.Columns(9).HeaderText = "Status"
        DataGridViewPickup.Columns(10).HeaderText = "Detailer"
        DataGridViewPickup.Columns(11).HeaderText = "Notes"
    End Sub

    Public Sub AddButtonAction()
        If Not DataGridViewPickup.Columns.Contains("actionsColumn") Then
            Dim updateButtonColumn As New DataGridViewButtonColumn With {
                .HeaderText = "Action",
                .Text = "View Info",
                .UseColumnTextForButtonValue = True,
                .Name = "actionsColumn" ' Use this name for easy retrieval
            }
            DataGridViewPickup.Columns.Add(updateButtonColumn)
        End If

    End Sub

    Private Sub AddBtnFunction()

        Dim errorHandler As Action(Of String) = Sub(message)

                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        Dim success As Boolean = AddButtonFunction.AddDataToPickupTable(
           TextBoxCustomerID,
           TextBoxPickupAddress,
           DateTimePickerStartDate,
           ComboBoxPaymentMethod,
           TextBoxReferenceID,
           TextBoxCheque,
           ComboBoxDetailer,
           TextBoxTotalPrice,
           ComboBoxPickupStatus,
           TextBoxNotes,
           errorHandler,
           pickupManagementDatabaseHelper
        )
        If success Then
            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "New Pickup Added"

            AddNewPickupToActivityLog()
            ViewPickupData()
            PrintBillInPickup.ShowPrint(PrintDocumentBill)
            ClearFields()
        End If

    End Sub

    Public Sub ViewPickupData()
        DataGridViewPickup.DataSource = pickupManagementDatabaseHelper.ViewPickupData()
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddBtnFunction()
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        PaymentMethodSelectedService.PaymentMethodChange(ComboBoxPaymentMethod, TextBoxReferenceID, TextBoxCheque)
    End Sub

    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub ComboBoxAddons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub

    Private Sub UpdatePickupBtn_Click(sender As Object, e As EventArgs) Handles UpdatePickupBtn.Click
        UpdatePickup()
    End Sub

    Private Sub ShowPrintBillWhenCompleted()
        If ComboBoxPickupStatus.SelectedItem = "Completed" Then
            PrintBillInPickup.ShowPrint(PrintDocumentBill)
        End If
    End Sub
    Private Sub UpdatePickup()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub


        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
            LabelPickupID,
            TextBoxCustomerID,
            TextBoxPickupAddress,
            DateTimePickerStartDate,
            ComboBoxPaymentMethod,
            TextBoxReferenceID,
            TextBoxCheque,
            ComboBoxDetailer,
            TextBoxTotalPrice,
            ComboBoxPickupStatus,
            TextBoxNotes,
            localErrorHandler,
            pickupManagementDatabaseHelper
        )

        If success Then
            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "Pickup Updated Successfully"

            UpdatePickuptatusActivityLog()
            ShowPrintBillWhenCompleted()
            ViewPickupData()
            ClearFields()
        End If
    End Sub

    Public Sub UpdatePickuptatusActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newtStatus As String = ComboBoxPickupStatus.Text
        activityLogInDashboardService.UpdatePickupStatus(customerName, newtStatus)
    End Sub

    Public Sub AddNewPickupToActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim pickupDate As String = DateTimePickerStartDate.Value.ToString("g")
        activityLogInDashboardService.AddNewPickup(customerName, pickupDate)
    End Sub

    Private Sub ClearFieldsBtn_Click(sender As Object, e As EventArgs) Handles ClearFieldsBtn.Click
        ClearFields()
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentSaleID As Integer = Convert.ToInt32(DataGridViewPickup.CurrentRow.Cells("PickupID").Value)
        Dim saleDate As DateTime = Convert.ToDateTime(DataGridViewPickup.CurrentRow.Cells("PickupDateTime").Value)

        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentSaleID > 0 AndAlso pickupManagementDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = PickupManagementDatabaseHelper.GetSaleLineItems(currentSaleID, Me.constr)
        End If

        ' 3. Populate PrintDataInPickup using the comprehensive list.
        PrintBillInPickup.PrintBillInPickup(e, New PrintDataInPickup With {
        .PickupID = currentSaleID,
        .CustomerName = TextBoxCustomerName.Text,
        .ServiceLineItems = serviceLineItems,
        .PaymentMethod = ComboBoxPaymentMethod.Text,
        .SaleDate = saleDate,
        .Discount = If(ComboBoxDiscount.SelectedItem IsNot Nothing, Convert.ToDecimal(ComboBoxDiscount.SelectedItem), 0D),
        .PickupDate = DateTimePickerStartDate.Value,
        .Detailer = ComboBoxDetailer.Text
})
    End Sub

    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub

    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelPickupID.Text) Then
            MessageBox.Show("Please select pickup from the table or add new pickup to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PrintBillInPickup.ShowPrint(PrintDocumentBill)
        End If
    End Sub

    Private Sub SetActionButtonIndex()
        If DataGridViewPickup.Columns.Contains("actionsColumn") Then
            ' Setting DisplayIndex to the total count minus 1 makes it the last column
            DataGridViewPickup.Columns("actionsColumn").DisplayIndex = DataGridViewPickup.Columns.Count - 1
        End If
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForPickup(TextBoxSearchBar, DataGridViewPickup)
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub
End Class