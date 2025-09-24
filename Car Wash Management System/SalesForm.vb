
Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class SalesForm
    ' The connection string to your database.
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"

    ' Pass the UI controls to the management class.
    Private ReadOnly salesHistoryManagement As SalesHistoryManagement
    Private ReadOnly dashboardManagement As New DashboardManagement(constr)

    Public Sub New()
        InitializeComponent()

        ' Pass the UI controls to the management class, including the new TextBoxCustomerID.
        salesHistoryManagement = New SalesHistoryManagement(constr, ComboBoxPaymentMethod, TextBoxCustomerName, TextBoxCustomerID)
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
        DataGridViewSales.Columns(6).HeaderText = "Total Price"
    End Sub
    Private Sub LoadAllPopulateUI()
        salesHistoryManagement.PopulateCustomerNames()
        salesHistoryManagement.PopulatePaymentMethod()
        salesHistoryManagement.PopulateBaseServicesForUI(ComboBoxServices)
        salesHistoryManagement.PopulateAddonServicesForUI(ComboBoxAddons)
        DataGridViewSales.DataSource = salesHistoryManagement.ViewSales()
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
            Dim baseServiceDetails As SalesServiceDetails = salesHistoryManagement.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As SalesServiceDetails = salesHistoryManagement.GetServiceID(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If


            salesHistoryManagement.AddSale(
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                ComboBoxPaymentMethod.SelectedItem.ToString(),
                totalPrice
                )
            Carwash.PopulateAllTotal()
            DataGridViewSales.DataSource = salesHistoryManagement.ViewSales()
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
        dashboardManagement.RecordSale(customerName, amount)

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
            Dim baseServiceDetails As SalesServiceDetails = salesHistoryManagement.GetServiceID(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesServiceDetails = salesHistoryManagement.GetServiceID(ComboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Dim customerID As Integer = salesHistoryManagement.GetCustomerID(TextBoxCustomerName.Text)
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
        TextBoxPrice.Text = DataGridViewSales.CurrentRow.Cells(6).Value.ToString()
        ComboBoxPaymentMethod.Text = DataGridViewSales.CurrentRow.Cells(5).Value.ToString()

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
        salesHistoryManagement.PrintBillInSales(e, New PrintData With {
             .SalesID = If(DataGridViewSales.CurrentRow IsNot Nothing, Convert.ToInt32(DataGridViewSales.CurrentRow.Cells(0).Value), 0),
             .CustomerName = TextBoxCustomerName.Text,
             .BaseService = ComboBoxServices.Text,
             .baseServicePrice = If(ComboBoxServices.SelectedIndex <> -1, salesHistoryManagement.GetServiceID(ComboBoxServices.Text).Price, 0D),
             .AddonService = ComboBoxAddons.Text,
             .addonServicePrice = If(ComboBoxAddons.SelectedIndex <> -1, salesHistoryManagement.GetServiceID(ComboBoxAddons.Text).Price, 0D),
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
        salesHistoryManagement.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
End Class

Public Class SalesHistoryManagement
    Private ReadOnly constr As String
    Private ReadOnly comboBoxPaymentMethod As ComboBox
    Private ReadOnly textBoxCustomerName As TextBox
    Private ReadOnly textBoxCustomerID As TextBox

    Private ReadOnly printData As PrintData
    Public Sub New(connectionString As String, paymentMethodComboBox As ComboBox, customerNameTextBox As TextBox, customerIDTextBox As TextBox)
        Me.constr = connectionString
        Me.comboBoxPaymentMethod = paymentMethodComboBox
        Me.textBoxCustomerName = customerNameTextBox
        Me.textBoxCustomerID = customerIDTextBox
    End Sub

    Public Sub AddSale(customerID As Integer, baseServiceID As Integer, addonServiceID As Integer?, paymentMethod As String, totalPrice As Decimal)


        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery = "INSERT INTO SalesHistoryTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPrice)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@ServiceID", baseServiceID)
                    ' Handle the nullable addonServiceID parameter
                    If addonServiceID.HasValue Then
                        cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                    Else
                        cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                    End If
                    cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                    cmd.ExecuteNonQuery()
                    Carwash.NotificationLabel.Text = "New Sale Added"
                    Carwash.ShowNotification()

                End Using
            Catch ex As Exception
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Function ViewSales() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Join to the ServicesTable for the addon as well to show the full service name.
                Dim selectQuery = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s 
                                  INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID 
                                  INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID 
                                  LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SalesID DESC"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt
    End Function

    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            Try
                con.Open()
                Dim selectQuery = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        customerID = CType(result, Integer)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return customerID
        End Using
    End Function

    Public Function GetServiceID(serviceName As String) As SalesServiceDetails
        Using con As New SqlConnection(constr)
            Dim details As New SalesServiceDetails()
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, Price FROM ServicesTable WHERE ServiceName = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", serviceName)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        details.ServiceID = reader.GetInt32(0)
                        details.Price = reader.GetDecimal(1)
                    End If
                End Using
            End Using
            Return details
        End Using
    End Function

    'Public Function GetServicePrice(serviceName As String) As Decimal
    '    Using con As New SqlConnection(constr)
    '        Dim price As Decimal = 0.0D
    '        Try
    '            con.Open()
    '            Dim selectQuery = "SELECT Price FROM ServicesTable WHERE ServiceName = @Name"
    '            Using cmd As New SqlCommand(selectQuery, con)
    '                cmd.Parameters.AddWithValue("@Name", serviceName)
    '                Dim result = cmd.ExecuteScalar()
    '                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
    '                    price = CType(result, Decimal)
    '                End If
    '            End Using
    '        Catch ex As Exception
    '            MessageBox.Show("Error retrieving service price: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End Try
    '        Return price
    '    End Using
    'End Function

    Public Sub PopulateBaseServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving base services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateAddonServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Filter by both the Addon flag and the specific service names
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving addon services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateCustomerNames()
        Dim customerNames As New AutoCompleteStringCollection()

        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            customerNames.Add(reader.GetString(0))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Me.textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.textBoxCustomerName.AutoCompleteCustomSource = customerNames
    End Sub
    Public Sub PopulateCustomerServices()
        Dim customerServices As New AutoCompleteStringCollection()

        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM ServiceTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            customerServices.Add(reader.GetString(0))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Me.textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.textBoxCustomerName.AutoCompleteCustomSource = customerServices
    End Sub

    Public Sub PopulatePaymentMethod()
        Me.comboBoxPaymentMethod.Items.Add("Cash")
        Me.comboBoxPaymentMethod.Items.Add("Gcash")
        Me.comboBoxPaymentMethod.Items.Add("Cheque")
        Me.comboBoxPaymentMethod.SelectedIndex = 0
    End Sub

    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
    Public Shared Sub PrintBillInSales(e As PrintPageEventArgs, printData As PrintData)
        If printData Is Nothing Then
            ' Handle case where no data is set
            Return
        End If

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        'Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12


        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' Add bill details from the class-level printData object

        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & printData.SalesID, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.BaseService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString(printData.BaseServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        If Not String.IsNullOrWhiteSpace(printData.AddonService) Then
            yPos += offset
            e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
            e.Graphics.DrawString("Add-on: " & printData.AddonService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
            e.Graphics.DrawString(printData.AddonServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
            yPos += offset
        End If
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Total:", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        yPos += offset

        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString("Payment", f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset

        e.Graphics.DrawString(printData.PaymentMethod, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
End Class
Public Class SalesServiceDetails
    Public Property ServiceID As Integer
    Public Property Price As Decimal
End Class
Public Class PrintData
    Public Property SalesID As Integer
    Public Property CustomerName As String
    Public Property BaseService As String
    Public Property AddonService As String
    Public Property TotalPrice As Decimal
    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
    Public Property BaseServicePrice As Decimal
    Public Property AddonServicePrice As Decimal
End Class


