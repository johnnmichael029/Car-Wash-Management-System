Imports System.Drawing.Printing
Imports System.Security.Cryptography.Xml
Imports System.Transactions
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Appointment
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly appointmentManagementDatabaseHelper As AppointmentManagementDatabaseHelper
    Private ReadOnly activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private appointmentServiceList As New List(Of AppointmentService)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AppointmentManagementDatabaseHelper = New AppointmentManagementDatabaseHelper(constr)
    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateUIForAppointment()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewAppointment()
        SetupListView()
    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewAppointment.CellFormatting

        If e.ColumnIndex = Me.DataGridViewAppointment.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

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
                Case "In-progress"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.LightBlue
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
            ComboBoxPaymentMethod.Text = DataGridViewAppointment.CurrentRow.Cells(5).Value.ToString()
            TextBoxReferenceID.Text = DataGridViewAppointment.CurrentRow.Cells(6).Value.ToString()
            TextBoxTotalPrice.Text = DataGridViewAppointment.CurrentRow.Cells(7).Value.ToString()
            ComboBoxAppointmentStatus.Text = DataGridViewAppointment.CurrentRow.Cells(8).Value.ToString()
            TextBoxNotes.Text = DataGridViewAppointment.CurrentRow.Cells(9).Value.ToString()

            Dim appointmentIDValue As String = currentRow.Cells("AppointmentID").Value.ToString()
            LabelAppointmentID.Text = appointmentIDValue

            If String.IsNullOrEmpty(appointmentIDValue) Then Return

            Dim appointmentID As Integer
            If Integer.TryParse(appointmentIDValue, appointmentID) Then
                LoadServicesIntoListView(appointmentID)
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
            Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)

            If AppointmentServiceList.Count = 0 Then
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
            If (ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" Or ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque") AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                MessageBox.Show("Please select an appointment status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As AppointmentService = appointmentManagementDatabaseHelper.GetServiceDetails(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As AppointmentService = appointmentManagementDatabaseHelper.GetServiceDetails(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If

            appointmentManagementDatabaseHelper.AddAppointment(
                customerID,
                appointmentServiceList,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                totalPrice,
                ComboBoxAppointmentStatus.Text,
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
            Dim customerNames As DataTable = appointmentManagementDatabaseHelper.GetAllCustomerNames()
            Dim customerNamesCollection As New AutoCompleteStringCollection()
            For Each row As DataRow In customerNames.Rows
                customerNamesCollection.Add(row("Name").ToString())
            Next
            TextBoxCustomerName.AutoCompleteCustomSource = customerNamesCollection
            TextBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim baseServices As DataTable = appointmentManagementDatabaseHelper.GetBaseServices()
            ComboBoxServices.DataSource = baseServices
            ComboBoxServices.DisplayMember = "ServiceName"
            ComboBoxServices.ValueMember = "ServiceID"
            ComboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList

            Dim addonServices As DataTable = appointmentManagementDatabaseHelper.GetAddonServices()
            ComboBoxAddon.DataSource = addonServices
            ComboBoxAddon.DisplayMember = "ServiceName"
            ComboBoxAddon.ValueMember = "ServiceID"
            ComboBoxAddon.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxAddon.SelectedIndex = -1 ' Set to no selection by default

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
        ComboBoxAddon.SelectedIndex = -1
        ComboBoxPaymentMethod.SelectedIndex = 0
        ComboBoxAppointmentStatus.SelectedIndex = -1
        TextBoxNotes.Clear()
        DateTimePickerStartDate.Value = DateTime.Now
        LabelAppointmentID.Text = String.Empty
        LabelSales.Text = String.Empty
        TextBoxReferenceID.Clear()
        TextBoxTotalPrice.Text = "0.00"
        appointmentServiceList.Clear()
        ListViewServices.Items.Clear()
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
            Dim baseServiceDetails As AppointmentService = appointmentManagementDatabaseHelper.GetServiceDetails(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddon.SelectedIndex <> -1 Then
            Dim addonServiceDetails As AppointmentService = appointmentManagementDatabaseHelper.GetServiceDetails(ComboBoxAddon.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub
    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Try
            Dim customerID As Integer = appointmentManagementDatabaseHelper.GetCustomerID(TextBoxCustomerName.Text)
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
            Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)

            If appointmentServiceList.Count = 0 Then
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
            If (ComboBoxPaymentMethod.SelectedItem.ToString() = "Gcash" Or ComboBoxPaymentMethod.SelectedItem.ToString() = "Cheque") AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                MessageBox.Show("Please enter a Reference ID for the selected payment method.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                MessageBox.Show("Please select an appointment status.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            appointmentManagementDatabaseHelper.UpdateAppointment(
                appointmentID,
                customerID,
                appointmentServiceList,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
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
        Dim newService As New AppointmentService(services, addons, price)

        Me.appointmentServiceList.Add(newService)
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

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        If ComboBoxPaymentMethod.SelectedItem = "Gcash" Or ComboBoxPaymentMethod.SelectedItem = "Cheque" Then
            TextBoxReferenceID.ReadOnly = False
        Else
            TextBoxReferenceID.ReadOnly = True
            TextBoxReferenceID.Clear()
        End If
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
        Dim subtotalRemovedCount As Integer = Me.appointmentServiceList.RemoveAll(Function(v)
                                                                                      Return v.Service.Equals(serviceToRemove, StringComparison.OrdinalIgnoreCase)
                                                                                  End Function)

        If subtotalRemovedCount > 0 Then
            ListViewServices.Items.Remove(selectedItem)
            MessageBox.Show($"Service was removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected vehicle in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LoadServicesIntoListView(AppointmentID As Integer)
        ListViewServices.Items.Clear()
        Me.appointmentServiceList.Clear()
        Dim serviceList As List(Of AppointmentService) = appointmentManagementDatabaseHelper.GetSalesServiceList(AppointmentID)

        For Each service As AppointmentService In serviceList
            ' 3. Add to the local tracking list (VehicleList)
            Me.appointmentServiceList.Add(service)
            ' 4. Add to the ListView for display
            Dim lvi As New ListViewItem(service.Service)
            lvi.SubItems.Add(service.Addon)
            lvi.SubItems.Add(service.ServicePrice.ToString("N2"))
            ListViewServices.Items.Add(lvi)
        Next
    End Sub

End Class

