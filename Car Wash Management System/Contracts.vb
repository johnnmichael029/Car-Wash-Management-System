Imports Microsoft.Data.SqlClient
Imports System.Drawing.Printing


Public Class Contracts


    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly billingContractsManagement As BillingContractsManagement
    Dim listOfActivityLog As New ListOfActivityLog(constr)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the data access layer
        billingContractsManagement = New BillingContractsManagement(constr)
    End Sub
    Private Sub Contracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateUIForContract()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewContracts()
    End Sub
    Private Sub AddContractBtn_Click(sender As Object, e As EventArgs) Handles AddContractBtn.Click

        AddBillingContracts()
    End Sub
    Private Sub ChangeHeaderOfDataGridViewContracts()
        DataGridView1.Columns(0).HeaderText = "Contract ID"
        DataGridView1.Columns(1).HeaderText = "Customer Name"
        DataGridView1.Columns(2).HeaderText = "Base Service"
        DataGridView1.Columns(3).HeaderText = "Addon Service"
        DataGridView1.Columns(4).HeaderText = "Start Date"
        DataGridView1.Columns(5).HeaderText = "End Date"
        DataGridView1.Columns(6).HeaderText = "Billing Frequency"
        DataGridView1.Columns(7).HeaderText = "Payment Method"
        DataGridView1.Columns(8).HeaderText = "Price"
        DataGridView1.Columns(9).HeaderText = "Contract Status"
    End Sub
    Private Sub AddContractActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        listOfActivityLog.AddNewContract(customerName)
    End Sub
    Private Sub AddBillingContracts()
        Dim salesAdded As String = "Sales Added"
        Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
        Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)

        Try
            ' The CustomerID is now retrieved directly from the textbox
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate if the base service is selected
            If String.IsNullOrWhiteSpace(baseServiceName) Then
                MessageBox.Show("Please select a base service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate if the end date is not equal to today
            If Me.DateTimePickerEndDate.Value.Date = DateTime.Now.Date Then
                MessageBox.Show("Date end must not equal to DateTime today", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate if billing frequency is selected
            If String.IsNullOrWhiteSpace(ComboBoxBillingFrequency.Text) Then
                MessageBox.Show("Please select a billing frequency.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate if payment method is selected
            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Validate if contract status is selected
            If String.IsNullOrWhiteSpace(ComboBoxContractStatus.Text) Then
                MessageBox.Show("Please select a contract status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            'Validate if the price is decimal
            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If

            billingContractsManagement.AddContract(
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing),
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                totalPrice,
                ComboBoxContractStatus.Text
            )
            Carwash.PopulateAllTotal()
            LabelSales.Text = salesAdded
            Carwash.NotificationLabel.Text = "New Contract Added"
            Carwash.ShowNotification()
            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
            MessageBox.Show("Contract added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddContractActivityLog()
            ShowPrintPreview()
            ClearFields()
        Catch ex As Exception
        MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridViewFontStyle()
        DataGridView1.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub PopulateUIForContract()
        Try
            ' Populate UI components using the data returned from the management class
            Dim customerNames As DataTable = billingContractsManagement.GetAllCustomerNames()
            Dim customerNamesCollection As New AutoCompleteStringCollection()
            For Each row As DataRow In customerNames.Rows
                customerNamesCollection.Add(row("Name").ToString())
            Next
            TextBoxCustomerName.AutoCompleteCustomSource = customerNamesCollection
            TextBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim baseServices As DataTable = billingContractsManagement.GetBaseServices()
            ComboBoxServices.DataSource = baseServices
            ComboBoxServices.DisplayMember = "ServiceName"
            ComboBoxServices.ValueMember = "ServiceID"
            ComboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList

            Dim addonServices As DataTable = billingContractsManagement.GetAddonServices()
            ComboBoxAddon.DataSource = addonServices
            ComboBoxAddon.DisplayMember = "ServiceName"
            ComboBoxAddon.ValueMember = "ServiceID"
            ComboBoxAddon.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxAddon.Text = ""

            ' This part is not in the management class anymore, as it's static UI logic
            ComboBoxPaymentMethod.Items.AddRange({"Cash", "Gcash", "Cheque"})
            ComboBoxPaymentMethod.SelectedIndex = 0

            ' Load existing contracts into the DataGridView when the form loads.
            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
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
            Dim baseServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddon.SelectedIndex <> -1 Then
            Dim addonServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(ComboBoxAddon.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Try
            Dim customerID As Integer = billingContractsManagement.GetCustomerID(TextBoxCustomerName.Text)
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
        ClearFields()
    End Sub
    Private Sub ContractUpdated()
        Try
            Dim contractID As Integer
            Dim customerID As Integer
            Dim price As Decimal

            If Not Integer.TryParse(LabelContractID.Text, contractID) Or Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Or Not Decimal.TryParse(TextBoxPrice.Text, price) Then
                MessageBox.Show("Please select customer from contract Table to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim baseServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(ComboBoxServices.Text)
            Dim addonServiceID As Integer? = Nothing
            If ComboBoxAddon.SelectedIndex <> -1 Then
                Dim addonServiceDetails As ServiceDetails = billingContractsManagement.GetServiceDetails(ComboBoxAddon.Text)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If

            Dim endDate As Date? = If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing)

            billingContractsManagement.UpdateContract(
                contractID,
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                DateTimePickerStartDate.Value,
                endDate,
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                price,
                ComboBoxContractStatus.Text
            )
            Carwash.NotificationLabel.Text = "Contract Updated"
            Carwash.ShowNotification()
            MessageBox.Show("Contract updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the contract: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateContractActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newStatus As String = ComboBoxContractStatus.Text
        listOfActivityLog.UpdateContractStatus(customerName, newStatus)
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
        LabelSales.Text = String.Empty
    End Sub

    'Private Sub DeleteContractBtn_Click(sender As Object, e As EventArgs) Handles DeleteContractBtn.Click
    '    billingContractsManagement.DeleteContract(LabelContractID.Text)
    '    DataGridView1.DataSource = billingContractsManagement.ViewContracts()
    '    ClearFields()
    'End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        LabelContractID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBoxCustomerName.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        ComboBoxServices.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        If Not IsDBNull(DataGridView1.CurrentRow.Cells(3).Value) Then
            ComboBoxAddon.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        Else
            ComboBoxAddon.SelectedIndex = -1 ' Handle cases where the addon is null
        End If

        DateTimePickerStartDate.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells(4).Value)
        If Not IsDBNull(DataGridView1.CurrentRow.Cells(5).Value) Then
            DateTimePickerEndDate.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells(5).Value)
            DateTimePickerEndDate.Checked = True
        Else
            DateTimePickerEndDate.Checked = False
        End If
        ComboBoxBillingFrequency.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        ComboBoxPaymentMethod.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString()
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString()
        ComboBoxContractStatus.Text = DataGridView1.CurrentRow.Cells(9).Value.ToString()

        ' Update the customer ID based on the selected customer name.
        TextBoxCustomerName_TextChanged(TextBoxCustomerName, New EventArgs())
    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = Me.DataGridView1.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then
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
        If e.ColumnIndex = Me.DataGridView1.Columns("ContractStatus").Index AndAlso e.RowIndex >= 0 Then
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

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

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
        BillingContractsManagement.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        billingContractsManagement.PrintBillInContracts(e, New PrintDataInContracts With {
           .ContractID = If(DataGridView1.CurrentRow IsNot Nothing, Convert.ToInt32(DataGridView1.CurrentRow.Cells(0).Value), 0),
           .CustomerName = TextBoxCustomerName.Text,
           .BaseService = ComboBoxServices.Text,
           .baseServicePrice = If(ComboBoxServices.SelectedIndex <> -1, billingContractsManagement.GetServiceDetails(ComboBoxServices.Text).Price, 0D),
           .AddonService = ComboBoxAddon.Text,
           .addonServicePrice = If(ComboBoxAddon.SelectedIndex <> -1, billingContractsManagement.GetServiceDetails(ComboBoxAddon.Text).Price, 0D),
           .BillingFrequency = ComboBoxBillingFrequency.Text,
           .TotalPrice = Decimal.Parse(TextBoxPrice.Text),
           .PaymentMethod = ComboBoxPaymentMethod.Text,
           .SaleDate = DataGridView1.CurrentRow.Cells(4).Value,
           .StartDate = DateTimePickerStartDate.Value,
           .EndDate = If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing),
           .ContractStatus = ComboBoxContractStatus.Text
       })
    End Sub
End Class

Public Class BillingContractsManagement
    Private ReadOnly constr As String
    Private ReadOnly printData As PrintDataInContracts
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub

    Public Sub AddContract(customerID As Integer, serviceID As Integer, addonServiceID As Integer?, endDate As Date?, billingFrequency As String, paymentMethod As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to insert a new contract. Using parameters to prevent SQL injection.
            Dim insertQuery As String = "INSERT INTO ContractsTable (CustomerID, ServiceID, AddonServiceID, StartDate, EndDate, BillingFrequency, PaymentMethod, Price, ContractStatus) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @StartDate, @EndDate, @BillingFrequency, @PaymentMethod, @Price, @ContractStatus)"
            Using cmd As New SqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                cmd.Parameters.AddWithValue("@StartDate", DateTime.Now)

                ' Handle the nullable EndDate parameter
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                Else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                End If
                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Retrieves all billing contracts from the database and returns them as a DataTable.
    ''' </summary>
    Public Function ViewContracts() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to select all contracts.
            Dim selectQuery As String = "SELECT b.ContractID, c.Name AS CustomerName, s.ServiceName AS BaseService, sa.ServiceName AS AddonService, b.StartDate, b.EndDate, b.BillingFrequency, b.PaymentMethod, b.Price, b.ContractStatus
                                         FROM ContractsTable b
                                         INNER JOIN CustomersTable c ON b.CustomerID = c.CustomerID
                                         INNER JOIN ServicesTable s ON b.ServiceID = s.ServiceID
                                         LEFT JOIN ServicesTable sa ON b.AddonServiceID = sa.ServiceID ORDER BY b.ContractID DESC"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Updates an existing billing contract in the database.
    ''' </summary>
    Public Sub UpdateContract(contractID As Integer, customerID As Integer, serviceID As Integer, addonServiceID As Integer?, startDate As Date, endDate As Date?, billingFrequency As String, paymentMethod As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to update a contract.
            Dim updateQuery As String = "UPDATE ContractsTable SET CustomerID = @CustomerID, ServiceID = @ServiceID, AddonServiceID = @AddonServiceID, StartDate = @StartDate, EndDate = @EndDate, BillingFrequency = @BillingFrequency, PaymentMethod = @PaymentMethod, Price = @Price, ContractStatus = @ContractStatus WHERE ContractID = @ContractID"
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddWithValue("@ContractID", contractID)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                cmd.Parameters.AddWithValue("@StartDate", startDate)

                ' Handle the nullable EndDate parameter
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                Else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                End If
                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Deletes an existing billing contract from the database.
    ''' </summary>
    'Public Sub DeleteContract(contractID As String)
    '    If String.IsNullOrEmpty(contractID) Then
    '        MessageBox.Show("Please select contract from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If
    '    Dim DialogResult = MessageBox.Show("Are you sure you want to delete this contract?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '    If DialogResult = DialogResult.Yes Then

    '        Using con As New SqlConnection(constr)
    '            Try
    '                con.Open()
    '                ' SQL query to delete a contract.
    '                Dim deleteQuery As String = "DELETE FROM ContractsTable WHERE ContractID = @ContractID"
    '                Using cmd As New SqlCommand(deleteQuery, con)
    '                    cmd.Parameters.AddWithValue("@ContractID", contractID)
    '                    cmd.ExecuteNonQuery()
    '                    MessageBox.Show("Contract deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End Using
    '            Catch ex As Exception
    '                MessageBox.Show("An error occurred while deleting contract" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Finally
    '                con.Close()
    '            End Try
    '        End Using
    '    End If
    'End Sub

    ''' <summary>
    ''' Gets all customer names from the database.
    ''' </summary>
    Public Function GetAllCustomerNames() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable ORDER BY Name"
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Gets a customer ID by name.
    ''' </summary>
    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            con.Open()
            Dim selectQuery As String = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", customerName)
                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                    customerID = CType(result, Integer)
                End If
            End Using
            Return customerID
        End Using
    End Function

    ''' <summary>
    ''' Gets service details (ID and Price) by service name.
    ''' </summary>
    Public Function GetServiceDetails(serviceName As String) As ServiceDetails
        Using con As New SqlConnection(constr)
            Dim details As New ServiceDetails()
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

    ''' <summary>
    ''' Gets all non-addon services.
    ''' </summary>
    Public Function GetBaseServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Gets all addon services.
    ''' </summary>
    Public Function GetAddonServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Show Print Preview
    ''' </summary>
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
    ''' <summary>
    ''' Print Bill
    ''' </summary>
    Public Shared Sub PrintBillInContracts(e As PrintPageEventArgs, printData As PrintDataInContracts)
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
        e.Graphics.DrawString("InvoiceID: " & printData.ContractID, f10, Brushes.Black, centerMargin, yPos, centerAlign)
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
        ' Additional contract details
        e.Graphics.DrawString("Start Date: ", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.StartDate, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString("End Date: ", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.EndDate, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString("Billing Frequency: ", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.BillingFrequency, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString("Contract Status: ", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.ContractStatus, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        yPos += offset

        ' Payment Details
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
Public Class ServiceDetails
    Public Property ServiceID As Integer
    Public Property Price As Decimal
End Class
Public Class PrintDataInContracts
    Public Property ContractID As Integer
    Public Property CustomerName As String
    Public Property CustomerID As Integer
    Public Property BaseService As String
    Public Property AddonService As String
    Public Property TotalPrice As Decimal
    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
    Public Property BaseServicePrice As Decimal
    Public Property AddonServicePrice As Decimal
    Public Property BillingFrequency As String
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime?
    Public Property ContractStatus As String
End Class
