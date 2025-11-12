
Imports System.Drawing.Printing
Imports System.Linq.Expressions
Imports Microsoft.Data.SqlClient
Public Class SalesForm
    ' The connection string to your database.
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    ' Pass the UI controls to the management class.
    Private ReadOnly salesDatabaseHelper As SalesDatabaseHelper
    Private ReadOnly activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private SaleServiceList As New List(Of SalesService)
    Private nextServiceID As Integer = 1
    Public Sub New()
        InitializeComponent()

        ' Pass the UI controls to the management class, including the new TextBoxCustomerID.
        salesDatabaseHelper = New SalesDatabaseHelper(constr)
    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllPopulateUI()
        ClearFields()
        DataGridViewSalesFontStyle()
        ChangeHeaderOfDataGridViewSales()
        SetupListView()
        ClearFields()
    End Sub
    Private Sub ChangeHeaderOfDataGridViewSales()
        DataGridViewSales.Columns(0).HeaderText = "Sales ID"
        DataGridViewSales.Columns(1).HeaderText = "Customer Name"
        DataGridViewSales.Columns(2).HeaderText = "Base Service"
        DataGridViewSales.Columns(3).HeaderText = "Addon Service"
        DataGridViewSales.Columns(4).HeaderText = "Sale Date"
        DataGridViewSales.Columns(5).HeaderText = "Payment Method"
        DataGridViewSales.Columns(6).HeaderText = "Reference ID"
        DataGridViewSales.Columns(7).HeaderText = "Total Price"
    End Sub
    Private Sub LoadAllPopulateUI()
        Try
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulatePaymentMethod(ComboBoxPaymentMethod)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
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
        Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
        Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)
        Dim totalPrice As Decimal = TextBoxTotalPrice.Text
        Try
            'The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.
            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) OrElse customerID <= 0 Then
                MessageBox.Show("Please select a valid customer from the list.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            ' Guard clause: Ensure there are items to sell
            If SaleServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate that a payment method is selected.
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

            SalesDatabaseHelper.AddSale(
                customerID,
                SaleServiceList,
                ComboBoxPaymentMethod.SelectedItem.ToString(),
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice
                )
            Carwash.PopulateAllTotal()
            ViewSales()
            MessageBox.Show("Sale added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddSalesActivityLog()
            ShowPrintPreview()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
        CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, TextBoxPrice)
    End Sub

    Private Sub ComboBoxAddons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, TextBoxPrice)
    End Sub
    Public Sub CalculateTotalPrice(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, textBoxPrice As TextBox)
        Dim totalPrice As Decimal = 0.0D

        If comboBoxServices.SelectedIndex <> -1 Then
            Dim baseServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(comboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If comboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(comboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price
        End If

        textBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
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
        TextBoxReferenceID.Clear()
        SaleServiceList.Clear()
        ListViewServices.Items.Clear()
        TextBoxTotalPrice.Text = "0.00"
        nextServiceID = 1
    End Sub
    Private Sub DataGridViewSalesFontStyle()
        DataGridViewSales.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewSales.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewSales_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridViewSales.SelectionChanged


    End Sub
    Private Sub DataGridViewSales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSales.CellContentClick
        ' This event is not strictly needed since SelectionChanged handles data loading
        ' but sometimes helps ensure a selection is made on cell click.
        If e.RowIndex >= 0 Then
            DataGridViewSales.Rows(e.RowIndex).Selected = True
        End If

        If DataGridViewSales.CurrentRow Is Nothing Then Return

        Dim currentRow As DataGridViewRow = DataGridViewSales.CurrentRow

        ' 1. Populate TextBoxes/ComboBoxes
        Try
            TextBoxCustomerName.Text = currentRow.Cells("CustomerName").Value?.ToString()
            ComboBoxPaymentMethod.SelectedItem = currentRow.Cells(5).Value?.ToString()
            If ComboBoxPaymentMethod.SelectedItem = "Gcash" Then
                TextBoxReferenceID.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxCheque.Clear()
            ElseIf ComboBoxPaymentMethod.SelectedItem = "Cheque".Trim Then
                TextBoxCheque.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxReferenceID.Clear()
            End If
            TextBoxTotalPrice.Text = currentRow.Cells("TotalPrice").Value?.ToString()

            ' Set the ID for persistence
            Dim saleIDValue As String = currentRow.Cells("SalesID").Value?.ToString()
            LabelSalesID.Text = saleIDValue

            If String.IsNullOrEmpty(saleIDValue) Then Return

            ' 2. Load Services into ListView
            Dim saleID As Integer
            If Integer.TryParse(saleIDValue, saleID) Then
                LoadServicesIntoListView(saleID)
            Else
                MessageBox.Show("Invalid Sales ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ' Log or handle error during population
            MessageBox.Show("Error loading sale details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxTotalPrice.Text = "0.00"
        End Try

    End Sub
    Private Sub DataGridViewSales_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSales.CellFormatting
        If e.ColumnIndex = Me.DataGridViewSales.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Gcash"
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cheque"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Billing Contract"
                    ' Gray for appointments that were a no-show.
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.Black
                Case "Cash"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If

    End Sub

    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage

        ' 1. Get the Sales ID of the selected row
        Dim currentSaleID As Integer = 0
        Dim saleDate As DateTime = DateTime.Now

        If DataGridViewSales.CurrentRow IsNot Nothing Then
            ' Ensure the row is valid and the cell value is not null before converting
            If DataGridViewSales.CurrentRow.Cells(0).Value IsNot DBNull.Value Then
                currentSaleID = Convert.ToInt32(DataGridViewSales.CurrentRow.Cells(0).Value)
            End If
            If DataGridViewSales.CurrentRow.Cells(4).Value IsNot DBNull.Value Then
                saleDate = Convert.ToDateTime(DataGridViewSales.CurrentRow.Cells(4).Value)
            End If
        End If

        ' 2. Retrieve the list of all services (Base and Add-ons) associated with this sale ID.
        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentSaleID > 0 AndAlso salesDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = SalesDatabaseHelper.GetSaleLineItems(currentSaleID, Me.constr)
        End If

        ' 3. Populate PrintDataInSales using the comprehensive list.
        ShowPrintPreviewService.PrintBillInSales(e, New PrintDataInSales With {
        .SalesID = currentSaleID,
        .CustomerName = TextBoxCustomerName.Text,
        .ServiceLineItems = serviceLineItems,
        .PaymentMethod = ComboBoxPaymentMethod.Text,
        .SaleDate = saleDate
})
    End Sub

    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelSalesID.Text) Then
            MessageBox.Show("Please select sales from the table or add new sales to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ShowPrintPreview()
        End If
    End Sub
    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub
    Public Sub ShowPrintPreview()
        ShowPrintPreviewService.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
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

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleService()
        CalculateTotalPriceInService()
    End Sub


    Private Sub AddSaleService()
        If String.IsNullOrWhiteSpace(ComboBoxServices.Text) Then
            MessageBox.Show("Please enter service.", "Missing Service Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 1. Get the current ID and prepare the next one
        Dim currentID As Integer = nextServiceID
        nextServiceID += 1 ' Increment the counter for the next line item

        Dim services As String = ComboBoxServices.Text.Trim()
        Dim addons As String = ComboBoxAddons.Text.Trim()

        ' Use TryParse for safer decimal conversion
        Dim price As Decimal
        If Not Decimal.TryParse(TextBoxPrice.Text, price) Then
            MessageBox.Show("Invalid price value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 2. Create the new service, passing the current ID
        Dim newService As New SalesService(currentID, services, addons, price)

        Me.SaleServiceList.Add(newService)

        ' 3. Add the ID as the FIRST column in the ListView
        Dim lvi As New ListViewItem(newService.ID.ToString()) ' ID is the main item text

        ' Add the rest of the columns as sub-items
        lvi.SubItems.Add(newService.Service)        ' Service
        lvi.SubItems.Add(newService.Addon)          ' Addon
        lvi.SubItems.Add(newService.ServicePrice.ToString("N2")) ' Price
        ListViewServices.Items.Add(lvi)

        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        TextBoxPrice.Text = "0.00"
    End Sub

    Private Sub SetupListView()
        ListViewServices.View = View.Details
        ListViewServices.HeaderStyle = ColumnHeaderStyle.Nonclickable
        ListViewServices.Columns.Clear()
        ListViewServices.Columns.Add("ID", 30, HorizontalAlignment.Left)
        ListViewServices.Columns.Add("Service", 85, HorizontalAlignment.Left)
        ListViewServices.Columns.Add("Addon", 85, HorizontalAlignment.Left)
        ListViewServices.Columns.Add("Price", 50, HorizontalAlignment.Left)
        ListViewServices.GridLines = True
        ListViewServices.FullRowSelect = True
    End Sub
    Private Sub CalculateTotalPriceInService()
        Dim totalPrice As Decimal = 0D
        If ListViewServices Is Nothing OrElse ListViewServices.Items.Count = 0 Then
            TextBoxTotalPrice.Text = "0.00"
            Return
        End If

        For Each item As ListViewItem In ListViewServices.Items
            If item.SubItems.Count > 2 Then
                Dim priceText As String = item.SubItems(3).Text

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
    Private Sub LoadServicesIntoListView(salesID As Integer)
        ListViewServices.Items.Clear()
        Me.SaleServiceList.Clear()
        Dim serviceList As List(Of SalesService) = SalesDatabaseHelper.GetSalesServiceList(salesID)
        Dim listItemIDCounter As Integer = 1

        For Each service As SalesService In serviceList

            Me.SaleServiceList.Add(service)
            Dim lvi As New ListViewItem(listItemIDCounter.ToString())

            lvi.SubItems.Add(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))

            ListViewServices.Items.Add(lvi)
            listItemIDCounter += 1

        Next
        Me.nextServiceID = listItemIDCounter
    End Sub


    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        RemoveSelectedService()
        CalculateTotalPriceInService()
    End Sub
    Private Sub RemoveSelectedService()
        If ListViewServices.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a service from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedItem As ListViewItem = ListViewServices.SelectedItems(0)

        ' Get the 0-based index of the selected item in the ListView
        Dim selectedIndex As Integer = selectedItem.Index

        ' 1. Check if the index is valid for our tracking list
        If selectedIndex >= 0 AndAlso selectedIndex < Me.SaleServiceList.Count Then

            ' 2. Remove the service object from the internal list based on index
            Me.SaleServiceList.RemoveAt(selectedIndex)

            ' 3. Remove the item from the visual ListView control
            ' (This step is technically optional since we clear and re-add below, but good practice)
            ListViewServices.Items.Remove(selectedItem)

            ' 4. After removing, we must re-load and re-number the entire list
            ' This ensures the IDs (1, 2, 3...) remain sequential without gaps.

            ' Get the current list of remaining services
            ' Using ToList() creates a copy, so we can manipulate the original SaleServiceList safely below.
            Dim remainingServices As List(Of SalesService) = Me.SaleServiceList.ToList()

            ' Clear the UI and internal list (before re-adding)
            ListViewServices.Items.Clear()
            Me.SaleServiceList.Clear() ' Clear the internal list so we can rebuild it with the same items

            ' Now, iterate through the remaining items and re-add them with new sequential IDs
            Dim listItemIDCounter As Integer = 1
            For Each service As SalesService In remainingServices
                Me.SaleServiceList.Add(service) ' Re-add to the internal list

                ' Create the ListView item with the new sequential ID
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(service.Service)
                lvi.SubItems.Add(service.Addon)
                lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
                ListViewServices.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            ' 5. Update the global counter for new additions
            Me.nextServiceID = listItemIDCounter

            MessageBox.Show($"Service (ID: {selectedItem.Text}) was removed successfully and the list was renumbered.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected service in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateSales()
    End Sub
    Private Sub UpdateSales()

        Try
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) OrElse customerID <= 0 Then
                MessageBox.Show("Please select a valid customer from the list.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If


            ' Guard clause: Ensure there are items to sell
            If SaleServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            'Validate that a payment method is selected.
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
            SalesDatabaseHelper.UpdateSale(
                customerID,
                LabelSalesID.Text,
                SaleServiceList,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                TextBoxTotalPrice.Text
                )
            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "Sale Updated"
            UpdateSalesActivityLog()
            MessageBox.Show("Sale updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ViewSales()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ViewSales()
        DataGridViewSales.DataSource = salesDatabaseHelper.ViewSales()
    End Sub

    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

End Class


