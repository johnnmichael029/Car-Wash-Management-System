
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting
Imports Microsoft.Data.SqlClient


Public Class Dashboard
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly dashboardDatabaseHelper As New DashboardDatabaseHelper(constr, TextBoxCustomerName)
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Private ReadOnly listofActivityLogInDashboardDatabaseHelper As ListofActivityLogInDashboardDatabaseHelper
    Private ReadOnly salesDatabaseHelper As SalesDatabaseHelper
    Private ReadOnly salesForm As New SalesForm
    Private ReadOnly activityLogService As ActivityLogInDashboardService
    Private isMonthlyView As Boolean = False
    Private isYearlyView As Boolean = False
    Private currentSearchTerm As String = String.Empty
    Private VehicleList As New List(Of VehicleService)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.\
        dashboardDatabaseHelper = New DashboardDatabaseHelper(constr, TextBoxCustomerName)
        listofActivityLogInDashboardDatabaseHelper = New ListofActivityLogInDashboardDatabaseHelper(constr)
        salesDatabaseHelper = New SalesDatabaseHelper(constr)
        customerInformationDatabaseHelper = New CustomerInformationDatabaseHelper(constr)
        activityLogService = New ActivityLogInDashboardService(constr)
    End Sub
    Public Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
        salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
        salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)

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
            chartData = dashboardDatabaseHelper.GetDailySales()
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
        TextBoxSearchBar.Text = ""
    End Sub
    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarFunction()
    End Sub
    Private Sub SearchBarFunction()
        currentSearchTerm = Trim(TextBoxSearchBar.Text)

        ' --- NEW: Get the selected filter column ---
        Dim filterColumn As String = ComboBoxFilter.SelectedItem?.ToString()
        If String.IsNullOrWhiteSpace(filterColumn) Then
            ' Default to searching all columns if nothing is selected
            filterColumn = "Filter"
        End If

        Dim salesData As New DataTable()

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            ' Load all data if search box is empty
            salesData = dashboardDatabaseHelper.ViewSalesData()
        Else
            ' Load filtered data, passing both the search term and the filter column
            salesData = dashboardDatabaseHelper.GetFilteredList(currentSearchTerm, filterColumn)
        End If

        DataGridViewLatestTransaction.DataSource = salesData

        ' Force the DataGridView to redraw all cells after search (for highlighting)
        DataGridViewLatestTransaction.Invalidate()
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
        ' Only proceed if we are in a data row, not the header, and we have a search term
        If e.RowIndex < 0 OrElse String.IsNullOrWhiteSpace(currentSearchTerm) Then
            Exit Sub
        End If

        ' Get the cell value (which should be searchable text)
        Dim cellValue As String = e.FormattedValue?.ToString()

        If String.IsNullOrWhiteSpace(cellValue) Then
            Exit Sub
        End If

        ' 1. Check if the cell text contains the search term (case-insensitive)
        Dim searchIndex As Integer = cellValue.IndexOf(currentSearchTerm, StringComparison.OrdinalIgnoreCase)

        If searchIndex >= 0 Then
            ' A match was found!

            ' A. Do the default painting (draw background, borders, etc.)
            e.PaintBackground(e.ClipBounds, True)

            ' B. Set up colors and fonts
            Dim baseFont As Font = e.CellStyle.Font
            Dim highlightColor As Color = Color.Yellow ' Use a bright color for highlighting
            Dim highlightTextBrush As Brush = New SolidBrush(e.CellStyle.ForeColor)

            ' C. Calculate positions and sizes

            ' Calculate the size of the entire string using the cell's font
            Dim textSize As SizeF = e.Graphics.MeasureString(cellValue, baseFont)

            ' Get the original bounds (where the text starts)
            Dim textX As Integer = e.CellBounds.X + 3 ' Small padding from the left edge
            Dim textY As Integer = e.CellBounds.Y + (e.CellBounds.Height - CInt(textSize.Height)) \ 2 ' Center vertically

            ' 1. Text before the match
            Dim textBefore As String = cellValue.Substring(0, searchIndex)
            Dim sizeBefore As SizeF = e.Graphics.MeasureString(textBefore, baseFont)

            ' 2. The matching search term
            Dim textMatch As String = cellValue.Substring(searchIndex, currentSearchTerm.Length)
            Dim sizeMatch As SizeF = e.Graphics.MeasureString(textMatch, baseFont)

            ' --- Draw the three parts of the text ---

            ' Part 1: Text before the match (using default cell color)
            e.Graphics.DrawString(textBefore, baseFont, New SolidBrush(e.CellStyle.ForeColor), textX, textY)

            ' Part 2: The highlighted match
            ' Draw the yellow background rectangle
            Dim highlightRect As New Rectangle(
                CInt(textX + sizeBefore.Width),
                e.CellBounds.Y,
                CInt(sizeMatch.Width),
                e.CellBounds.Height
            )
            e.Graphics.FillRectangle(New SolidBrush(highlightColor), highlightRect)

            ' Draw the matched text (over the yellow background)
            e.Graphics.DrawString(textMatch, baseFont, highlightTextBrush, CInt(textX + sizeBefore.Width), textY)

            ' Part 3: Text after the match
            Dim textAfter As String = cellValue.Substring(searchIndex + currentSearchTerm.Length)
            e.Graphics.DrawString(textAfter, baseFont, New SolidBrush(e.CellStyle.ForeColor), CInt(textX + sizeBefore.Width + sizeMatch.Width), textY)

            ' Indicate that we have manually drawn the cell contents
            e.Handled = True
        Else
            ' If no match, let the default rendering happen
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridViewLatestTransaction_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewLatestTransaction.CellFormatting
        If e.ColumnIndex = Me.DataGridViewLatestTransaction.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim()

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
    Private Sub DataGridViewLatestTransactionFontStyle()
        DataGridViewLatestTransaction.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewLatestTransaction.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub LoadLatestTransaction()
        Dim salesData As DataTable = dashboardDatabaseHelper.ViewSalesData()
        DataGridViewLatestTransaction.DataSource = salesData
    End Sub

    Private Sub AddCustomerBtn_Click(sender As Object, e As EventArgs) Handles AddCustomerBtn.Click
        AddCustomerInformation()
    End Sub
    Public Sub AddCustomerInformation()

        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Then
            MessageBox.Show("Please fill in all required customer fields (Name, Phone, Email, Plate Number and Vehicle Type).", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If AddVehicleToListView.VehicleList.Count = 0 Then
            MessageBox.Show("Please add at least one vehicle before saving the customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            customerInformationDatabaseHelper.AddCustomer(
            TextBoxName.Text.Trim(),
            TextBoxLastName.Text.Trim(),
            TextBoxNumber.Text,
            TextBoxEmail.Text.Trim(),
            TextBoxAddress.Text.Trim(),
            TextBoxBarangay.Text.Trim(),
            AddVehicleToListView.VehicleList
            )

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Carwash.PopulateAllTotal()
        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        VehicleList.Clear()
        ListViewVehicles.Items.Clear()
        AddSaleToListView.SaleServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
    End Sub

    Private Sub AddSalesBtn_Click(sender As Object, e As EventArgs) Handles AddSalesBtn.Click
        AddBtnFunction()
    End Sub
    Private Sub AddBtnFunction()
        Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
        Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)
        Dim totalPrice As Decimal = TextBoxTotalPrice.Text
        Try
            'The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.
            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As SalesService = SalesDatabaseHelper.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesService = SalesDatabaseHelper.GetServiceID(addonServiceName)
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
            If AddSaleToListView.SaleServiceList.Count = 0 Then
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
                AddSaleToListView.SaleServiceList,
                ComboBoxPaymentMethod.SelectedItem.ToString(),
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice
                )
            Carwash.PopulateAllTotal()
            LoadLatestTransaction()
            MessageBox.Show("Sale added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddSalesActivityLog()
            ShowPrintPreview()
            DisplayNextSalesID()
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
        TextBoxReferenceID.Clear()
        TextBoxCheque.Clear()
        AddSaleToListView.SaleServiceList.Clear()
        ListViewServices.Items.Clear()
        TextBoxTotalPrice.Text = "0.00"
        AddSaleToListView.nextServiceID = 1
    End Sub
    Public Sub ShowPrintPreview()
        ShowPrintPreviewService.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentSaleID = Convert.ToInt32(LabelSalesID.Text)
        Dim saleDate = Convert.ToDateTime(DataGridViewLatestTransaction.CurrentRow.Cells(4).Value)
        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentSaleID > 0 AndAlso salesDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = SalesDatabaseHelper.GetSaleLineItems(currentSaleID, Me.constr)
        End If

        ' *** PASSING ReferenceID and TotalPrice to PrintBillInSales ***
        Dim totalPriceDecimal As Decimal = 0
        If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPriceDecimal) Then
            ' Should not happen if AddBtnFunction validates input, but provides a fallback
            totalPriceDecimal = 0D
        End If

        ShowPrintPreviewService.PrintBillInSales(e, New PrintDataInSales With {
        .SalesID = currentSaleID,
        .CustomerName = TextBoxCustomerName.Text,
        .ServiceLineItems = serviceLineItems,
        .PaymentMethod = ComboBoxPaymentMethod.Text,
        .SaleDate = saleDate
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
        Dim vehiclesRemovedCount As Integer = Me.VehicleList.RemoveAll(Function(v)
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
    Private Sub ViewLatestSales()
        DataGridViewLatestTransaction.DataSource = salesDatabaseHelper.ViewSales()
    End Sub
    Public Function GetNextSalesID() As Integer
        Dim nextId As Integer = 1
        Dim sql As String = "SELECT ISNULL(MAX(SalesID), 0) FROM RegularSaleTable"
        Try
            Using conn As New SqlConnection(constr)
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        ' Convert the result (which is the MAX SalesID, or 0) to an integer
                        Dim maxId As Integer = CInt(result)

                        ' The next SalesID is the Max ID plus 1
                        nextId = maxId + 1
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error generating Sales ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Return nextId
    End Function
    Private Sub DisplayNextSalesID()
        ' 1. Get the next available ID from the database
        Dim nextId As Integer = GetNextSalesID()

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
End Class


