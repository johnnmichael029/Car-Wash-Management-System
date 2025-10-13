
Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient
Public Class SalesForm
    ' The connection string to your database.
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    ' Pass the UI controls to the management class.
    Private ReadOnly salesDatabaseHelper As SalesDatabaseHelper
    Private ReadOnly activityLogInDashboardService As New ActivityLogInDashboardService(constr)

    Public Sub New()
        InitializeComponent()

        ' Pass the UI controls to the management class, including the new TextBoxCustomerID.
        salesDatabaseHelper = New SalesDatabaseHelper(constr, ComboBoxPaymentMethod, TextBoxCustomerName, TextBoxCustomerID)
    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAllPopulateUI()
        ClearFields()
        DataGridViewSalesFontStyle()
        ChangeHeaderOfDataGridViewSales()
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
        salesDatabaseHelper.PopulateCustomerNames()
        salesDatabaseHelper.PopulatePaymentMethod()
        salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
        salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
        DataGridViewSales.DataSource = salesDatabaseHelper.ViewSales()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
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
            Dim baseServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If


            salesDatabaseHelper.AddSale(
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                ComboBoxPaymentMethod.SelectedItem.ToString(),
                TextBoxReferenceID.Text,
                totalPrice
                )
            Carwash.PopulateAllTotal()
            DataGridViewSales.DataSource = salesDatabaseHelper.ViewSales()
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
        Dim amount As Decimal = Decimal.Parse(TextBoxPrice.Text)
        activityLogInDashboardService.RecordSale(customerName, amount)
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
            Dim baseServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesService = salesDatabaseHelper.GetServiceID(ComboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Dim customerID As Integer = salesDatabaseHelper.GetCustomerID(TextBoxCustomerName.Text)
        If customerID > 0 Then
            TextBoxCustomerID.Text = customerID.ToString()
        Else
            TextBoxCustomerID.Text = String.Empty
        End If
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
    End Sub
    Private Sub DataGridViewSalesFontStyle()
        DataGridViewSales.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewSales.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewSales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSales.CellContentClick
        LabelSalesID.Text = DataGridViewSales.CurrentRow.Cells(0).Value.ToString()
        TextBoxCustomerName.Text = DataGridViewSales.CurrentRow.Cells(1).Value.ToString()
        ComboBoxServices.Text = DataGridViewSales.CurrentRow.Cells(2).Value.ToString()
        ComboBoxAddons.Text = DataGridViewSales.CurrentRow.Cells(3).Value.ToString()
        ComboBoxPaymentMethod.Text = DataGridViewSales.CurrentRow.Cells(5).Value.ToString()
        TextBoxReferenceID.Text = DataGridViewSales.CurrentRow.Cells(6).Value.ToString()
        TextBoxPrice.Text = DataGridViewSales.CurrentRow.Cells(7).Value.ToString()

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
        ShowPrintPreviewService.PrintBillInSales(e, New PrintDataInSales With {
             .SalesID = If(DataGridViewSales.CurrentRow IsNot Nothing, Convert.ToInt32(DataGridViewSales.CurrentRow.Cells(0).Value), 0),
             .CustomerName = TextBoxCustomerName.Text,
             .BaseService = ComboBoxServices.Text,
             .BaseServicePrice = If(ComboBoxServices.SelectedIndex <> -1, salesDatabaseHelper.GetServiceID(ComboBoxServices.Text).Price, 0D),
             .AddonService = ComboBoxAddons.Text,
             .AddonServicePrice = If(ComboBoxAddons.SelectedIndex <> -1, salesDatabaseHelper.GetServiceID(ComboBoxAddons.Text).Price, 0D),
             .TotalPrice = Decimal.Parse(TextBoxPrice.Text),
             .PaymentMethod = ComboBoxPaymentMethod.Text,
             .SaleDate = DataGridViewSales.CurrentRow.Cells(4).Value
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
        If ComboBoxPaymentMethod.SelectedItem = "Gcash" Or ComboBoxPaymentMethod.SelectedItem = "Cheque" Then
            TextBoxReferenceID.ReadOnly = False
        Else
            TextBoxReferenceID.ReadOnly = True
            TextBoxReferenceID.Clear()
        End If
    End Sub
End Class


