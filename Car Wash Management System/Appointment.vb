Imports System.Diagnostics.Contracts
Imports System.Drawing.Printing
Imports System.Security.Cryptography.Xml
Imports System.Transactions
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Appointment
    Inherits BaseForm

    Public Sub New()
        MyBase.New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        SettingsService.UpdateSingleDiscountComboBox(Me.ComboBoxDiscount)
        SettingsService.DiscountButtonForm(Settings.CheckBoxEnableDiscount)
        SettingsService.ApplyTotalPriceSettingsOnLoad()

        PopulateUIForAppointment()
        DataGridViewFontStyle()
        ChangeHeaderOfDataGridViewAppointment()
        SetupListViewService.SetupListViewForServices(ListViewServices, 30, 85, 85, 50)

    End Sub

    Private Sub DataGridViewAppointment_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewAppointment.CellFormatting
        DataGridFormattingService.DataGridCellFormattingStatus(e, "AppointmentStatus", DataGridViewAppointment)
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewAppointment)
    End Sub

    Private Sub DataGridViewAppointment_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewAppointment.CellContentClick

        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewAppointment)


        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        DataGridCellContentClick.GetSelectedRowData(TextBoxCustomerName,
         DataGridViewAppointment,
         DateTimePickerStartDate,
         ComboBoxPaymentMethod,
         TextBoxReferenceID,
         TextBoxCheque,
         TextBoxTotalPrice,
         ComboBoxAppointmentStatus,
         ComboBoxDetailer,
         TextBoxNotes,
         LabelAppointmentID,
         ListViewServices,
         errorHandler)
    End Sub

    Private Sub DDataGridViewAppointment_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewAppointment.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub AddAppointmentBtn_Click(sender As Object, e As EventArgs) Handles AddAppointmentBtn.Click
        AddAppointmentBtnFunction()
    End Sub

    Public Sub AddAppointmentBtnFunction()
        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
        TextBoxCustomerID,
        TextBoxTotalPrice,
        DateTimePickerStartDate,
        ComboBoxPaymentMethod,
        TextBoxReferenceID,
        TextBoxCheque,
        ComboBoxAppointmentStatus,
        ComboBoxDetailer,
        TextBoxNotes,
        errorHandler,
        appointmentManagementDatabaseHelper
        )

        If success Then

            Carwash.PopulateAllTotal()
            Carwash.NotificationLabel.Text = "Appointment Added"
            Carwash.ShowNotification()

            AddAppointmentActivityLog()
            ViewAppointments()
            PrintBillInAppointmentService.ShowDocumentBill(PrintDocumentBill)
            ClearFields()
        End If

    End Sub

    Public Sub ViewAppointments()
        DataGridViewAppointment.DataSource = appointmentManagementDatabaseHelper.ViewAppointment()
    End Sub

    Public Sub AddAppointmentActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim appointmentDate As Date = DateTimePickerStartDate.Value
        Dim appointmentStatus As String = ComboBoxAppointmentStatus.Text
        ActivityLogInDashboardService.ScheduleAppointment(customerName, appointmentDate, appointmentStatus)
    End Sub

    Public Sub PopulateUIForAppointment()
        Try
            salesDatabaseHelper.PopulateCustomerNames(TextBoxCustomerName)
            salesDatabaseHelper.PopulateBaseServicesForUI(ComboBoxServices)
            salesDatabaseHelper.PopulateAddonServicesForUI(ComboBoxAddons)
            employeeMangamentDatabaseHelper.PopulateDetailerForUI(ComboBoxDetailer)
            DataGridViewAppointment.DataSource = appointmentManagementDatabaseHelper.ViewAppointment()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub DataGridViewFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewAppointment)
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
        TextBoxReferenceID.Clear()
        TextBoxTotalPrice.Text = "0.00"
        ComboBoxDetailer.SelectedIndex = -1

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
    End Sub

    Public Sub UpdateAppointmentStatusFunction()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
        TextBoxCustomerID,
        LabelAppointmentID,
        TextBoxTotalPrice,
        DateTimePickerStartDate,
        ComboBoxPaymentMethod,
        TextBoxReferenceID,
        TextBoxCheque,
        ComboBoxAppointmentStatus,
        ComboBoxDetailer,
        TextBoxNotes,
        appointmentManagementDatabaseHelper,
        localErrorHandler
    )

        If success Then

            Carwash.PopulateAllTotal()
            Carwash.ShowNotification()
            Carwash.NotificationLabel.Text = "Appointment Updated"
            UpdateAppointmentStatusActivityLog()
            ViewAppointments()
            ClearFields()
        End If

    End Sub

    Public Sub UpdateAppointmentStatusActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newtStatus As String = ComboBoxAppointmentStatus.Text
        ActivityLogInDashboardService.UpdateAppointmentStatus(customerName, newtStatus)
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
        DataGridViewAppointment.Columns(10).HeaderText = "Notes"
    End Sub

    Private Sub PrintBillBtn_Click(sender As Object, e As EventArgs) Handles PrintBillBtn.Click
        ValidatePrint()
    End Sub

    Private Sub ValidatePrint()
        If String.IsNullOrEmpty(LabelAppointmentID.Text) Then
            MessageBox.Show("Please select contract from the table or add new appointment to print", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            PrintBillInAppointmentService.ShowDocumentBill(PrintDocumentBill)
        End If
    End Sub

    Private Sub PrintDocumentBill_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumentBill.PrintPage
        Dim currentAppointmentID As Integer = Convert.ToInt32(DataGridViewAppointment.CurrentRow.Cells(0).Value)
        Dim saleDate As DateTime = Convert.ToDateTime(DataGridViewAppointment.CurrentRow.Cells(4).Value)


        Dim serviceLineItems As New List(Of ServiceLineItem)()
        If currentAppointmentID > 0 AndAlso AppointmentManagementDatabaseHelper IsNot Nothing Then
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
           .AppointmentStatus = ComboBoxAppointmentStatus.Text,
           .Discount = If(ComboBoxDiscount.SelectedItem IsNot Nothing, Convert.ToDecimal(ComboBoxDiscount.SelectedItem), 0D),
           .Detailer = ComboBoxDetailer.Text
       })
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddSaleToListView.AddSaleServiceInAppointmentForm(ComboBoxServices, ComboBoxAddons, TextBoxPrice, ListViewServices)
        UpdateTotalPriceService.CalculateTotalPriceInService(ListViewServices, TextBoxTotalPrice)
    End Sub

    Private Sub ComboBoxPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPaymentMethod.SelectedIndexChanged
        PaymentMethodSelectedService.PaymentMethodChange(ComboBoxPaymentMethod, TextBoxReferenceID, TextBoxCheque)
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

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForAppointment(TextBoxSearchBar, DataGridViewAppointment)
    End Sub

    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub
End Class

