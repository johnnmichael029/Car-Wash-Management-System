Imports Microsoft.Data.SqlClient
Imports System.Drawing.Printing


Public Class Contracts


    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly contractsDatabaseHelper As ContractsDatabaseHelper
    Dim activityLogInDashboardService As ActivityLogInDashboardService
    Private contractServiceList As List(Of ContractsService)
    Private ReadOnly salesDatabaseHelper As SalesDatabaseHelper

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the data access layer
        contractsDatabaseHelper = New ContractsDatabaseHelper(constr)
        salesDatabaseHelper = New SalesDatabaseHelper(constr)
        contractServiceList = New List(Of ContractsService)()
        activityLogInDashboardService = New ActivityLogInDashboardService(constr)
    End Sub
    Private Sub Contracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
        Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)

        Try
            ' The CustomerID is now retrieved directly from the textbox
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If AddSaleToListView.SaleServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate if the end date greather than or equal to monthly, quarterly or yearly
            If DateTimePickerEndDate.Checked Then
                Dim minEndDate As DateTime
                Select Case ComboBoxBillingFrequency.Text
                    Case "Monthly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(1)
                    Case "Quarterly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(4)
                    Case "Yearly"
                        minEndDate = DateTimePickerStartDate.Value.AddYears(1)
                    Case Else
                        MessageBox.Show("Please select a valid billing frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                End Select
                If DateTimePickerEndDate.Value.Date < minEndDate.Date Then
                    MessageBox.Show($"End date must be at least {ComboBoxBillingFrequency.Text.ToLower()} from the start date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            ' Validate if the end date is not equal to today
            If Me.DateTimePickerEndDate.Value.Date = DateTime.Now.Date Then
                MessageBox.Show("Date end must not equal to DateTime today", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Validate if the start date is greater than the end date
            If DateTimePickerEndDate.Checked AndAlso DateTimePickerStartDate.Value.Date > DateTimePickerEndDate.Value.Date Then
                MessageBox.Show("Start date cannot be later than end date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Validate if billing frequency is selected
            If String.IsNullOrWhiteSpace(ComboBoxBillingFrequency.Text) Then
                MessageBox.Show("Please select a billing frequency.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate if payment method is selected
            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate that a Reference ID is provided for certain payment methods.
            If ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque" AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                MessageBox.Show("Please enter a Cheque Number for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate if contract status is selected
            If String.IsNullOrWhiteSpace(ComboBoxContractStatus.Text) Then
                MessageBox.Show("Please select a contract status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate if the price is decimal
            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            contractsDatabaseHelper.AddContract(
                customerID,
                AddSaleToListView.SaleServiceList,
                DateTimePickerEndDate.Text,
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxContractStatus.Text
            )
            Carwash.PopulateAllTotal()
            Carwash.NotificationLabel.Text = "New Contract Added"
            Carwash.ShowNotification()
            DataGridViewContract.DataSource = contractsDatabaseHelper.ViewContracts()
            MessageBox.Show("Contract added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddContractActivityLog()
            ShowPrintPreview()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridViewFontStyle()
        DataGridViewContract.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewContract.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub PopulateUIForContract()
        Try
            ' Populate UI components using the data returned from the management class
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulatePaymentMethod(ComboBoxPaymentMethod)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
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
        UpdateContractActivityLog()
        ContractUpdated()

    End Sub
    Private Sub ContractUpdated()
        Try
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If contractServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate if the end date greather than or equal to monthly, quarterly or yearly
            If DateTimePickerEndDate.Checked Then
                Dim minEndDate As DateTime
                Select Case ComboBoxBillingFrequency.Text
                    Case "Monthly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(1)
                    Case "Quarterly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(4)
                    Case "Yearly"
                        minEndDate = DateTimePickerStartDate.Value.AddYears(1)
                    Case Else
                        MessageBox.Show("Please select a valid billing frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                End Select
                If DateTimePickerEndDate.Value.Date < minEndDate.Date Then
                    MessageBox.Show($"End date must be at least {ComboBoxBillingFrequency.Text.ToLower()} from the start date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If

            ' Validate if the end date is not equal to today
            If Me.DateTimePickerEndDate.Value.Date = DateTime.Now.Date Then
                MessageBox.Show("Date end must not equal to DateTime today", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Validate if the start date is greater than the end date
            If DateTimePickerEndDate.Checked AndAlso DateTimePickerStartDate.Value.Date > DateTimePickerEndDate.Value.Date Then
                MessageBox.Show("Start date cannot be later than end date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Validate if billing frequency is selected
            If String.IsNullOrWhiteSpace(ComboBoxBillingFrequency.Text) Then
                MessageBox.Show("Please select a billing frequency.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate if payment method is selected
            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate that a Reference ID is provided for certain payment methods.
            If ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque" AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                MessageBox.Show("Please enter a Cheque Number for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate if contract status is selected
            If String.IsNullOrWhiteSpace(ComboBoxContractStatus.Text) Then
                MessageBox.Show("Please select a contract status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate if the price is decimal
            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            contractsDatabaseHelper.UpdateContract(
                LabelContractID.Text,
                customerID,
                contractServiceList,
                DateTimePickerStartDate.Value,
                DateTimePickerEndDate.Value,
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxContractStatus.Text
            )
            Carwash.PopulateAllTotal
            Carwash.NotificationLabel.Text = "Contract Updated"
            Carwash.ShowNotification()
            MessageBox.Show("Contract updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridViewContract.DataSource = contractsDatabaseHelper.ViewContracts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the contract: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

        ListViewServices.Items.Clear()
        AddSaleToListView.SaleServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub

    Private Sub DataGridViewContract_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewContract.CellContentClick
        ' but sometimes helps ensure a selection is made on cell click.
        If e.RowIndex >= 0 Then
            DataGridViewContract.Rows(e.RowIndex).Selected = True
        End If

        If DataGridViewContract.CurrentRow Is Nothing Then Return

        Dim currentRow As DataGridViewRow = DataGridViewContract.CurrentRow

        ' 1. Populate TextBoxes/ComboBoxes
        Try
            TextBoxCustomerName.Text = currentRow.Cells(1).Value?.ToString()
            DateTimePickerStartDate.Text = currentRow.Cells(4).Value?.ToString()
            DateTimePickerEndDate.Text = currentRow.Cells(5).Value?.ToString()
            ComboBoxBillingFrequency.Text = currentRow.Cells(6).Value?.ToString()
            ComboBoxPaymentMethod.Text = currentRow.Cells(7).Value?.ToString()
            If ComboBoxPaymentMethod.SelectedItem = "Gcash" Then
                TextBoxReferenceID.Text = currentRow.Cells(8).Value?.ToString()
                TextBoxCheque.Clear()
            ElseIf ComboBoxPaymentMethod.SelectedItem = "Cheque" Then
                TextBoxCheque.Text = currentRow.Cells(8).Value?.ToString()
                TextBoxReferenceID.Clear()
            End If
            TextBoxTotalPrice.Text = currentRow.Cells(9).Value?.ToString()

            ComboBoxContractStatus.Text = currentRow.Cells(10).Value?.ToString()

            ' Set the ID for persistence
            Dim contractIDValue As String = currentRow.Cells(0).Value?.ToString()
            LabelContractID.Text = contractIDValue

            If String.IsNullOrEmpty(contractIDValue) Then Return

            ' 2. Load Services into ListView
            Dim contractID As Integer
            If Integer.TryParse(contractIDValue, contractID) Then
                LoadService.LoadServicesIntoListViewContractForm(contractID, ListViewServices)

            Else
                MessageBox.Show("Invalid Sales ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ' Log or handle error during population
            MessageBox.Show("Error loading sale details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxTotalPrice.Text = "0.00"
        End Try
    End Sub

    Private Sub DataGridViewContract_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewContract.CellFormatting
        If e.ColumnIndex = Me.DataGridViewContract.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then
            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Gcash"
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cheque"
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Cash"
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
        If e.ColumnIndex = Me.DataGridViewContract.Columns("ContractStatus").Index AndAlso e.RowIndex >= 0 Then
            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Active"
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cancelled"
                    e.CellStyle.BackColor = Color.Salmon
                    e.CellStyle.ForeColor = Color.Black
                Case "Expired"
                    e.CellStyle.BackColor = Color.YellowGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If

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
            ShowPrintPreview()
        End If
    End Sub
    Public Sub ShowPrintPreview()
        PrintBillInContractsService.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentContractID As Integer = Convert.ToInt32(DataGridViewContract.CurrentRow.Cells(0).Value)
        Dim startDate As DateTime = Convert.ToDateTime(DataGridViewContract.CurrentRow.Cells(4).Value)

        ' 2. Retrieve the list of all services (Base and Add-ons) associated with this sale ID.
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
           .ContractStatus = ComboBoxContractStatus.Text
       })
    End Sub
    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleService(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedService(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub
    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        If ComboBoxPaymentMethod.SelectedItem = "Gcash" Then
            TextBoxReferenceID.ReadOnly = False
            TextBoxCheque.ReadOnly = True
            TextBoxCheque.Clear()
        ElseIf ComboBoxPaymentMethod.SelectedItem = "Cheque" Then
            TextBoxCheque.ReadOnly = False
            TextBoxReferenceID.ReadOnly = True
            TextBoxReferenceID.Clear()
        Else
            TextBoxReferenceID.ReadOnly = True
            TextBoxCheque.ReadOnly = True
            TextBoxReferenceID.Clear()
            TextBoxCheque.Clear()
        End If
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub ComboBoxDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiscount.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub
End Class

