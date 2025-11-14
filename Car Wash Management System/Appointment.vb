Imports System.Diagnostics.Contracts
Imports System.Drawing.Printing
Imports System.Security.Cryptography.Xml
Imports System.Transactions
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Appointment
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly appointmentManagementDatabaseHelper As AppointmentManagementDatabaseHelper
    Private ReadOnly activityLogInDashboardService As ActivityLogInDashboardService
    Private ReadOnly salesDatabaseHelper As SalesDatabaseHelper
    Private appointmentServiceList As List(Of AppointmentService)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        appointmentManagementDatabaseHelper = New AppointmentManagementDatabaseHelper(constr)
        salesDatabaseHelper = New SalesDatabaseHelper(constr)
        appointmentServiceList = New List(Of AppointmentService)()
        activityLogInDashboardService = New ActivityLogInDashboardService(constr)
    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateUIForAppointment()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewAppointment()
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)

    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewAppointment.CellFormatting
        'DataGridViewAppointment.Columns("AppointmentStatus").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If e.ColumnIndex = Me.DataGridViewAppointment.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Confirmed"
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Pending"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Cancelled"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.Salmon
                    e.CellStyle.ForeColor = Color.Black
                Case "No-Show"
                    ' Gray for appointments that were a no-show.
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.Black
                Case "Completed"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
                Case "Queued"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "In-Progress"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.CornflowerBlue ' Used a distinct color to confirm it's working
                    e.CellStyle.ForeColor = Color.White ' Changed to White for better contrast
            End Select
        End If
        If e.ColumnIndex = Me.DataGridViewAppointment.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then
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
    End Sub
    Private Sub DataGridViewAppointment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAppointment.CellContentClick

        If e.RowIndex >= 0 Then
            DataGridViewAppointment.Rows(e.RowIndex).Selected = True
        End If

        If DataGridViewAppointment.CurrentRow Is Nothing Then Return

        Dim currentRow As DataGridViewRow = DataGridViewAppointment.CurrentRow
        Try
            TextBoxCustomerName.Text = DataGridViewAppointment.CurrentRow.Cells("CustomerName").Value.ToString()
            DateTimePickerStartDate.Value = Convert.ToDateTime(DataGridViewAppointment.CurrentRow.Cells(4).Value)
            ComboBoxPaymentMethod.Text = currentRow.Cells(5).Value?.ToString()
            If ComboBoxPaymentMethod.SelectedItem = "Gcash" Then
                TextBoxReferenceID.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxCheque.Clear()
            ElseIf ComboBoxPaymentMethod.SelectedItem = "Cheque".Trim Then
                TextBoxCheque.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxReferenceID.Clear()
            End If
            TextBoxTotalPrice.Text = DataGridViewAppointment.CurrentRow.Cells(7).Value.ToString()
            ComboBoxAppointmentStatus.Text = DataGridViewAppointment.CurrentRow.Cells(8).Value.ToString()
            TextBoxNotes.Text = DataGridViewAppointment.CurrentRow.Cells(9).Value.ToString()

            Dim appointmentIDValue As String = currentRow.Cells("AppointmentID").Value.ToString()
            LabelAppointmentID.Text = appointmentIDValue

            If String.IsNullOrEmpty(appointmentIDValue) Then Return

            Dim appointmentID As Integer
            If Integer.TryParse(appointmentIDValue, appointmentID) Then
                LoadService.LoadServicesIntoListViewAppointmentForm(appointmentIDValue, ListViewServices)
            Else
                MessageBox.Show("Invalid Appointment ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("An error occurred while selecting the appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxTotalPrice.Text = "0.00"
        End Try
    End Sub

    Private Sub AddAppointmentBtn_Click(sender As Object, e As EventArgs) Handles AddAppointmentBtn.Click
        AddAppointmentBtnFunction()

    End Sub
    Public Sub AddAppointmentBtnFunction()
        Try
            ' The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Determine the service name and ID based on both combo boxes.
            Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
            Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)

            If AddSaleToListView.AppointmentServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            'Validate if the Start date is not in the past
            If DateTimePickerStartDate.Value < DateTime.Now Then
                MessageBox.Show("The appointment date and time cannot be in the past.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

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
            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                MessageBox.Show("Please select an appointment status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                MessageBox.Show("Please select an appointment status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            appointmentManagementDatabaseHelper.AddAppointment(
                customerID,
                AddSaleToListView.AppointmentServiceList,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxAppointmentStatus.Text.Trim,
                TextBoxNotes.Text
            )
            Carwash.PopulateAllTotal()
            Carwash.NotificationLabel.Text = "Appointment Added"
            Carwash.ShowNotification()
            ViewAppointments()
            MessageBox.Show("Appointment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddAppointmentActivityLog()
            ShowPrintPreview()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ViewAppointments()
        DataGridViewAppointment.DataSource = appointmentManagementDatabaseHelper.ViewAppointment()
    End Sub
    Public Sub AddAppointmentActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim appointmentDate As Date = DateTimePickerStartDate.Value
        Dim appointmentStatus As String = ComboBoxAppointmentStatus.Text
        activityLogInDashboardService.ScheduleAppointment(customerName, appointmentDate, appointmentStatus)
    End Sub

    Public Sub PopulateUIForAppointment()
        Try
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
            salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
            DataGridViewAppointment.DataSource = appointmentManagementDatabaseHelper.ViewAppointment()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DataGridViewFontStyle()
        DataGridViewAppointment.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewAppointment.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Public Sub ClearFields()
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        TextBoxPrice.Text = "0.00"
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        ComboBoxPaymentMethod.SelectedIndex = 0
        ComboBoxAppointmentStatus.SelectedIndex = -1
        TextBoxNotes.Clear()
        DateTimePickerStartDate.Value = DateTime.Now
        LabelAppointmentID.Text = String.Empty
        LabelSales.Text = String.Empty
        TextBoxReferenceID.Clear()
        TextBoxTotalPrice.Text = "0.00"

        ListViewServices.Items.Clear()
        AddSaleToListView.AppointmentServiceList.Clear()
        AddSaleToListView.nextServiceID = 1
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

    Private Sub ClearFieldsBtn_Click(sender As Object, e As EventArgs) Handles ClearFieldsBtn.Click
        ClearFields()
    End Sub

    Private Sub UpdateAppointmentBtn_Click(sender As Object, e As EventArgs) Handles UpdateAppointmentBtn.Click
        UpdateAppointmentStatusFunction()
        UpdateAppointmentStatusActivityLog()
        ClearFields()
    End Sub
    Public Sub UpdateAppointmentStatusFunction()
        Try
            Dim appointmentID As Integer
            Dim customerID As Integer
            Dim price As Decimal
            Dim appointmentStatus As String = ComboBoxAppointmentStatus.Text
            Dim salesLabel As String = "Sales Added!"

            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Or Not Integer.TryParse(LabelAppointmentID.Text, appointmentID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Determine the service name and ID based on both combo boxes.
            Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
            Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)

            If AddSaleToListView.AppointmentServiceList.Count = 0 Then
                MessageBox.Show("Please add at least one service to the sale.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            'Validate if the Start date is not in the past
            If DateTimePickerStartDate.Value < DateTime.Now Then
                MessageBox.Show("The appointment date and time cannot be in the past.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

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
            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                MessageBox.Show("Please select an appointment status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            appointmentManagementDatabaseHelper.UpdateAppointment(
                appointmentID,
                customerID,
                AddSaleToListView.AppointmentServiceList,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                price,
                ComboBoxAppointmentStatus.Text,
                TextBoxNotes.Text
                )

            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "Appointment Updated"
            ViewAppointments()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub UpdateAppointmentStatusActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newtStatus As String = ComboBoxAppointmentStatus.Text
        activityLogInDashboardService.UpdateAppointmentStatus(customerName, newtStatus)
    End Sub
    Private Sub ChangeHeaderOfDataGridViewAppointment()
        DataGridViewAppointment.Columns(0).HeaderText = "Appointment ID"
        DataGridViewAppointment.Columns(1).HeaderText = "Customer Name"
        DataGridViewAppointment.Columns(2).HeaderText = "Base Service"
        DataGridViewAppointment.Columns(3).HeaderText = "Addon Service"
        DataGridViewAppointment.Columns(4).HeaderText = "Date & Time"
        DataGridViewAppointment.Columns(5).HeaderText = "Payment Method"
        DataGridViewAppointment.Columns(6).HeaderText = "Reference ID"
        DataGridViewAppointment.Columns(7).HeaderText = "Total Price"
        DataGridViewAppointment.Columns(8).HeaderText = "Appointment Status"
        DataGridViewAppointment.Columns(9).HeaderText = "Notes"
    End Sub
    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub
    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelAppointmentID.Text) Then
            MessageBox.Show("Please select contract from the table or add new appointment to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            ShowPrintPreview()
        End If
    End Sub
    Public Sub ShowPrintPreview()
        PrintBillInAppointmentService.ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentAppointmentID As Integer = 0
        Dim saleDate As DateTime = DateTime.Now

        If DataGridViewAppointment.CurrentRow IsNot Nothing Then
            ' Ensure the row is valid and the cell value is not null before converting
            If DataGridViewAppointment.CurrentRow.Cells(0).Value IsNot DBNull.Value Then
                currentAppointmentID = Convert.ToInt32(DataGridViewAppointment.CurrentRow.Cells(0).Value)
            End If
            If DataGridViewAppointment.CurrentRow.Cells(4).Value IsNot DBNull.Value Then
                saleDate = Convert.ToDateTime(DataGridViewAppointment.CurrentRow.Cells(4).Value)
            End If
        End If

        ' 2. Retrieve the list of all services (Base and Add-ons) associated with this sale ID.
        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentAppointmentID > 0 AndAlso appointmentManagementDatabaseHelper IsNot Nothing Then
            ' *** FIX: Now passing the connection string (Me.constr) to the Shared function ***
            serviceLineItems = AppointmentManagementDatabaseHelper.GetSaleLineItems(currentAppointmentID, Me.constr)
        End If


        PrintBillInAppointmentService.PrintBillInAppointment(e, New PrintDataInAppointmentService With {
           .ContractID = currentAppointmentID,
           .CustomerName = TextBoxCustomerName.Text,
           .ServiceLineItems = serviceLineItems,
           .PaymentMethod = ComboBoxPaymentMethod.Text,
           .SaleDate = DateTime.Now,
           .StartDate = saleDate,
           .AppointmentStatus = ComboBoxAppointmentStatus.Text
       })
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleServiceInAppointmentForm(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
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

    Private Sub RemoveServiceBtn_Click(sender As Object, e As EventArgs) Handles RemoveServiceBtn.Click
        AddSaleToListView.RemoveSelectedServiceInAppointmentForm(ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub
    Private Sub FullScreenServiceBtn_Click(sender As Object, e As EventArgs) Handles FullScreenServiceBtn.Click
        ShowPanelDocked.ShowServicesPanelDocked(PanelServiceInfo, ListViewServices)
    End Sub

    Private Sub ComboBoxDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDiscount.SelectedIndexChanged
        CalculatePriceService.CalculateTotalPrice(ComboBoxServices, ComboBoxAddons, ComboBoxDiscount, TextBoxPrice)
    End Sub
End Class

