Imports Microsoft.Data.SqlClient
Imports System.Drawing.Printing


Public Class Contracts


    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly contractsDatabaseHelper As ContractsDatabaseHelper
    Dim activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private contractServiceList As New List(Of ContractsService)()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the data access layer
        contractsDatabaseHelper = New ContractsDatabaseHelper(constr)
    End Sub
    Private Sub Contracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateUIForContract()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewContracts()
        SetupListView()
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
        Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)

        Try
            ' The CustomerID is now retrieved directly from the textbox
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
            If (ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" Or ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque") AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As ContractsService = contractsDatabaseHelper.GetServiceDetails(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As ContractsService = contractsDatabaseHelper.GetServiceDetails(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If

            contractsDatabaseHelper.AddContract(
                customerID,
                contractServiceList,
                If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing),
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
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
            Dim customerNames As DataTable = contractsDatabaseHelper.GetAllCustomerNames()
            Dim customerNamesCollection As New AutoCompleteStringCollection()
            For Each row As DataRow In customerNames.Rows
                customerNamesCollection.Add(row("Name").ToString())
            Next
            TextBoxCustomerName.AutoCompleteCustomSource = customerNamesCollection
            TextBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim baseServices As DataTable = contractsDatabaseHelper.GetBaseServices()
            ComboBoxServices.DataSource = baseServices
            ComboBoxServices.DisplayMember = "ServiceName"
            ComboBoxServices.ValueMember = "ServiceID"
            ComboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList

            Dim addonServices As DataTable = contractsDatabaseHelper.GetAddonServices()
            ComboBoxAddon.DataSource = addonServices
            ComboBoxAddon.DisplayMember = "ServiceName"
            ComboBoxAddon.ValueMember = "ServiceID"
            ComboBoxAddon.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxAddon.Text = ""

            ' This part is not in the management class anymore, as it's static UI logic
            ComboBoxPaymentMethod.Items.AddRange({"Cash", "Gcash", "Cheque"})
            ComboBoxPaymentMethod.SelectedIndex = 0

            ' Load existing contracts into the DataGridView when the form loads.
            DataGridViewContract.DataSource = contractsDatabaseHelper.ViewContracts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        CalculateTotalPrice()
    End Sub

    Private Sub ComboBoxAddon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddon.SelectedIndexChanged
        CalculateTotalPrice()
    End Sub

    Private Sub CalculateTotalPrice()
        Dim totalPrice As Decimal = 0.0D

        If ComboBoxServices.SelectedIndex <> -1 Then
            Dim baseServiceDetails As ContractsService = contractsDatabaseHelper.GetServiceDetails(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddon.SelectedIndex <> -1 Then
            Dim addonServiceDetails As ContractsService = contractsDatabaseHelper.GetServiceDetails(ComboBoxAddon.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Try
            Dim customerID As Integer = contractsDatabaseHelper.GetCustomerID(TextBoxCustomerName.Text)
            If customerID > 0 Then
                TextBoxCustomerID.Text = customerID.ToString()
            Else
                TextBoxCustomerID.Text = String.Empty ' Clear the ID if no match is found.
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxCustomerID.Text = String.Empty
        End Try
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
            If (ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" Or ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque") AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                totalPrice,
                ComboBoxContractStatus.Text
            )
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
        ComboBoxAddon.SelectedIndex = -1
        DateTimePickerStartDate.Value = DateTime.Now
        DateTimePickerEndDate.Value = DateTime.Now
        DateTimePickerEndDate.Checked = False
        ComboBoxBillingFrequency.SelectedIndex = -1

        TextBoxPrice.Clear()
        ComboBoxContractStatus.SelectedIndex = -1
        LabelContractID.Text = String.Empty
        TextBoxReferenceID.Clear()
        contractServiceList.Clear()
        ListViewServices.Items.Clear()
        TextBoxTotalPrice.Text = "0.00"
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
            TextBoxReferenceID.Text = currentRow.Cells(8).Value?.ToString()
            TextBoxTotalPrice.Text = currentRow.Cells(9).Value?.ToString()

            ComboBoxContractStatus.Text = currentRow.Cells(10).Value?.ToString()

            ' Set the ID for persistence
            Dim contractIDValue As String = currentRow.Cells(0).Value?.ToString()
            LabelContractID.Text = contractIDValue

            If String.IsNullOrEmpty(contractIDValue) Then Return

            ' 2. Load Services into ListView
            Dim contractID As Integer
            If Integer.TryParse(contractIDValue, contractID) Then
                LoadServicesIntoListView(contractID)
            Else
                MessageBox.Show("Invalid Sales ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ' Log or handle error during population
            MessageBox.Show("Error loading sale details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxTotalPrice.Text = "0.00"
        End Try
    End Sub
    Private Sub LoadServicesIntoListView(salesID As Integer)
        ListViewServices.Items.Clear()
        Me.contractServiceList.Clear()
        Dim serviceList As List(Of ContractsService) = contractsDatabaseHelper.GetSalesServiceList(salesID)

        For Each service As ContractsService In serviceList
            ' 3. Add to the local tracking list (VehicleList)
            Me.contractServiceList.Add(service)
            ' 4. Add to the ListView for display
            Dim lvi As New ListViewItem(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
            ListViewServices.Items.Add(lvi)

        Next
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
           .EndDate = If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing),
           .ContractStatus = ComboBoxContractStatus.Text
       })
    End Sub

    Private Sub PrintBillBtn_Click_1(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleService()
        CalculateTotalPriceInService()
    End Sub
    Private Sub CalculateTotalPriceInService()
        Dim totalPrice As Decimal = 0D
        If ListViewServices Is Nothing OrElse ListViewServices.Items.Count = 0 Then
            TextBoxTotalPrice.Text = "0.00"
            Return
        End If

        For Each item As ListViewItem In ListViewServices.Items
            If item.SubItems.Count > 2 Then
                Dim priceText As String = item.SubItems(2).Text

                Dim itemPrice As Decimal
                If Decimal.TryParse(priceText, itemPrice) Then
                    totalPrice += itemPrice
                Else
                    MessageBox.Show($"Invalid price format: {priceText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Next
        TextBoxTotalPrice.Text = totalPrice.ToString("N2")
    End Sub
    Private Sub AddSaleService()
        If String.IsNullOrWhiteSpace(ComboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim services As String = ComboBoxServices.Text.Trim()
        Dim addons As String = ComboBoxAddon.Text.Trim()
        Dim price As Decimal = Decimal.Parse(TextBoxPrice.Text)
        Dim newService As New ContractsService(services, addons, price)

        Me.contractServiceList.Add(newService)
        Dim lvi As New ListViewItem(newService.Service)
        lvi.SubItems.Add(newService.Addon)
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2"))
        ListViewServices.Items.Add(lvi)

        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddon.SelectedIndex = -1
        TextBoxPrice.Text = "0.00"
    End Sub

    Private Sub SetupListView()
        ListViewServices.View = View.Details
        ListViewServices.HeaderStyle = ColumnHeaderStyle.Nonclickable
        ListViewServices.Columns.Clear()
        ListViewServices.Columns.Add("Service", 100, HorizontalAlignment.Left)
        ListViewServices.Columns.Add("Addon", 100, HorizontalAlignment.Left)
        ListViewServices.Columns.Add("Price", 50, HorizontalAlignment.Left)
        ListViewServices.GridLines = True
        ListViewServices.FullRowSelect = True
    End Sub

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        RemoveSelectedService()
        CalculateTotalPriceInService()
    End Sub
    Private Sub RemoveSelectedService()
        If ListViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a services from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim selectedItem As ListViewItem = ListViewServices.SelectedItems(0)
        Dim serviceToRemove As String = selectedItem.Text
        Dim addonServiceToRemove As String = selectedItem.Text
        Dim subtotalRemovedCount As Integer = Me.contractServiceList.RemoveAll(Function(v)
                                                                                   Return v.Service.Equals(serviceToRemove, StringComparison.OrdinalIgnoreCase)
                                                                               End Function)

        If subtotalRemovedCount > 0 Then
            ListViewServices.Items.Remove(selectedItem)
            MessageBox.Show($"Service was removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected vehicle in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        If ComboBoxPaymentMethod.SelectedItem = "Gcash" Or ComboBoxPaymentMethod.SelectedItem = "Cheque" Then
            TextBoxReferenceID.ReadOnly = False
        Else
            TextBoxReferenceID.ReadOnly = True
            TextBoxReferenceID.Clear()
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs)

    End Sub
End Class

