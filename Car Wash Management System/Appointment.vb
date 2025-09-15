Imports Microsoft.Data.SqlClient

Public Class Appointment
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly appointmentManagement As AppointmentManagement
    Dim dashboardManagement As New DashboardManagement(constr)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        appointmentManagement = New AppointmentManagement(constr)

    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        If e.ColumnIndex = Me.DataGridView1.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

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
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        LabelAppointmentID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString()
        TextBoxCustomerName.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString()
        ComboBoxServices.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString()
        If Not IsDBNull(DataGridView1.CurrentRow.Cells(3).Value) Then
            ComboBoxAddon.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString()
        Else
            ComboBoxAddon.SelectedIndex = -1 ' Handle cases where the addon is null
        End If

        DateTimePickerStartDate.Value = Convert.ToDateTime(DataGridView1.CurrentRow.Cells(4).Value)
        ComboBoxPaymentMethod.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString()
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString()
        ComboBoxAppointmentStatus.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString()
        TextBoxNotes.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString()

        ' Update the customer ID based on the selected customer name.
        TextBoxCustomerName_TextChanged(TextBoxCustomerName, New EventArgs())

    End Sub

    Private Sub AddAppointmentBtn_Click(sender As Object, e As EventArgs) Handles AddAppointmentBtn.Click
        AddAppointmentBtnFunction()
        AppointmentActivityLog()
        ClearFields()
    End Sub
    Public Sub AddAppointmentBtnFunction()
        Try
            ' The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.

            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Determine the service name and ID based on both combo boxes.
            Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
            Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)

            If String.IsNullOrWhiteSpace(baseServiceName) Then
                MessageBox.Show("Please select a base service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                Dim addonServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(addonServiceName)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If

            appointmentManagement.AddAppointment(
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                totalPrice,
                ComboBoxAppointmentStatus.Text,
                TextBoxNotes.Text
            )
            MessageBox.Show("Appointment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = appointmentManagement.ViewAppointment()

        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub AppointmentActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim appointmentDate As Date = DateTimePickerStartDate.Value
        Dim appointmentStatus As String = ComboBoxAppointmentStatus.Text
        dashboardManagement.ScheduleAppointment(customerName, appointmentDate, appointmentStatus)
    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim customerNames As DataTable = appointmentManagement.GetAllCustomerNames()
            Dim customerNamesCollection As New AutoCompleteStringCollection()
            For Each row As DataRow In customerNames.Rows
                customerNamesCollection.Add(row("Name").ToString())
            Next
            TextBoxCustomerName.AutoCompleteCustomSource = customerNamesCollection
            TextBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim baseServices As DataTable = appointmentManagement.GetBaseServices()
            ComboBoxServices.DataSource = baseServices
            ComboBoxServices.DisplayMember = "ServiceName"
            ComboBoxServices.ValueMember = "ServiceID"
            ComboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList

            Dim addonServices As DataTable = appointmentManagement.GetAddonServices()
            ComboBoxAddon.DataSource = addonServices
            ComboBoxAddon.DisplayMember = "ServiceName"
            ComboBoxAddon.ValueMember = "ServiceID"
            ComboBoxAddon.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxAddon.SelectedIndex = -1 ' Set to no selection by default

            DataGridView1.DataSource = appointmentManagement.ViewAppointment()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub ClearFields()
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        TextBoxPrice.Clear()
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddon.SelectedIndex = -1
        ComboBoxPaymentMethod.SelectedIndex = 0
        ComboBoxAppointmentStatus.SelectedIndex = 0
        TextBoxNotes.Clear()
        DateTimePickerStartDate.Value = DateTime.Now
        LabelAppointmentID.Text = String.Empty
        LabelSales.Text = String.Empty
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
            Dim baseServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(ComboBoxServices.Text)
            totalPrice += baseServiceDetails.Price
        End If

        If ComboBoxAddon.SelectedIndex <> -1 Then
            Dim addonServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(ComboBoxAddon.Text)
            totalPrice += addonServiceDetails.Price
        End If

        TextBoxPrice.Text = totalPrice.ToString("N2") ' Format to 2 decimal places
    End Sub
    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Try
            Dim customerID As Integer = appointmentManagement.GetCustomerID(TextBoxCustomerName.Text)
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

    Private Sub ViewServiceBtn_Click(sender As Object, e As EventArgs) Handles ViewServiceBtn.Click
        DataGridView1.DataSource = appointmentManagement.ViewAppointment()
    End Sub

    Private Sub UpdateAppointmentBtn_Click(sender As Object, e As EventArgs) Handles UpdateAppointmentBtn.Click
        UpdateAppointmentStatusdFunction()
        UpdateAppointmentActivityLog()
        ClearFields()
    End Sub
    Public Sub UpdateAppointmentStatusdFunction()
        Try
            Dim appointmentID As Integer
            Dim customerID As Integer
            Dim price As Decimal
            Dim appointmentStatus As String = ComboBoxAppointmentStatus.Text
            Dim salesLabel As String = "Sales Added!"

            If Not Integer.TryParse(LabelAppointmentID.Text, appointmentID) Or Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Or Not Decimal.TryParse(TextBoxPrice.Text, price) Then
                MessageBox.Show("Please select customer from appointment Table to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim baseServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(ComboBoxServices.Text)
            Dim addonServiceID As Integer? = Nothing
            If ComboBoxAddon.SelectedIndex <> -1 Then
                Dim addonServiceDetails As AppointmentServiceDetails = appointmentManagement.GetServiceDetails(ComboBoxAddon.Text)
                If addonServiceDetails IsNot Nothing Then
                    addonServiceID = addonServiceDetails.ServiceID
                End If
            End If
            If appointmentStatus = "completed" Then
                LabelSales.Text = salesLabel
            End If
            appointmentManagement.UpdateAppointment(
                appointmentID,
                customerID,
                baseServiceDetails.ServiceID,
                addonServiceID,
                DateTimePickerStartDate.Value,
                ComboBoxPaymentMethod.Text,
                price,
                ComboBoxAppointmentStatus.Text,
                TextBoxNotes.Text
                )
            MessageBox.Show("Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = appointmentManagement.ViewAppointment()
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub UpdateAppointmentActivityLog()
        Dim customerName As String = TextBoxCustomerName.Text
        Dim newtStatus As String = ComboBoxAppointmentStatus.Text
        dashboardManagement.UpdateAppointmentStatus(customerName, newtStatus)
    End Sub
    Private Sub DeleteServiceBtn_Click(sender As Object, e As EventArgs) Handles DeleteServiceBtn.Click
        appointmentManagement.DeleteAppointment(LabelAppointmentID.Text)
        DataGridView1.DataSource = appointmentManagement.ViewAppointment()
        ClearFields()
    End Sub
End Class
Public Class AppointmentManagement
    Private ReadOnly constr As String

    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub

    Public Sub AddAppointment(customerID As Integer, serviceID As Integer, addonServiceID As Integer?, appointmentDateTime As DateTime, paymentMethod As String, price As Decimal, appointmentStatus As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to insert a new contract. Using parameters to prevent SQL injection.
            Dim insertQuery As String = "INSERT INTO AppointmentsTable (CustomerID, ServiceID, AddonServiceID, AppointmentDateTime, PaymentMethod, Price, AppointmentStatus, Notes) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @AppointmentDateTime, @PaymentMethod, @Price, @AppointmentStatus, @Notes)"
            Using cmd As New SqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)

                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                cmd.Parameters.AddWithValue("@Notes", notes)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    Public Function ViewAppointment() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to select all contracts.
            Dim selectQuery As String = "SELECT a.AppointmentID, c.Name AS CustomerName, s.ServiceName AS BaseService, sa.ServiceName AS AddonService, a.AppointmentDateTime, a.PaymentMethod, a.Price, a.AppointmentStatus, a.Notes
                                         FROM AppointmentsTable a
                                         INNER JOIN CustomersTable c ON a.CustomerID = c.CustomerID
                                         INNER JOIN ServicesTable s ON a.ServiceID = s.ServiceID
                                         LEFT JOIN ServicesTable sa ON a.AddonServiceID = sa.ServiceID ORDER BY a.AppointmentID DESC"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Sub UpdateAppointment(appointmentID As Integer, customerID As Integer, serviceID As Integer, addonServiceID As Integer?, appointmentDateTime As Date, paymentMethod As String, price As Decimal, appointmentStatus As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to update a contract.
            Dim updateQuery As String = "UPDATE AppointmentsTable SET CustomerID = @CustomerID, ServiceID = @ServiceID, AddonServiceID = @AddonServiceID, AppointmentDateTime = @AppointmentDateTime, PaymentMethod = @PaymentMethod, Price = @Price, AppointmentStatus = @AppointmentStatus, Notes = @Notes WHERE AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.Parameters.AddWithValue("@ContractID", appointmentID)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)

                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                cmd.Parameters.AddWithValue("@Notes", notes)
                cmd.ExecuteNonQuery()
            End Using
            'If appointmentStatus.ToLower() = "completed" Then
            '    Dim insertSaleQuery As String = "INSERT INTO SalesHistoryTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPRice)"
            '    Using cmd2 As New SqlCommand(insertSaleQuery, con)
            '        cmd2.Parameters.AddWithValue("@CustomerID", customerID)
            '        cmd2.Parameters.AddWithValue("@ServiceID", serviceID)
            '        If addonServiceID.HasValue Then
            '            cmd2.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
            '        Else
            '            cmd2.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
            '        End If
            '        cmd2.Parameters.AddWithValue("SaleDate", appointmentDateTime)
            '        cmd2.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            '        cmd2.Parameters.AddWithValue("@TotalPrice", price)
            '        cmd2.ExecuteNonQuery()
            '    End Using
            'End If
        End Using
    End Sub


    Public Sub DeleteAppointment(appointmentID As String)
        If String.IsNullOrEmpty(appointmentID) Then
            MessageBox.Show("Please select appointment from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Dim DialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If DialogResult = DialogResult.Yes Then

            Using con As New SqlConnection(constr)
                Try
                    con.Open()
                    ' SQL query to delete a contract.
                    Dim deleteQuery As String = "DELETE FROM AppointmentsTable WHERE AppointmentID = @AppointmentID"
                    Using cmd As New SqlCommand(deleteQuery, con)
                        cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Contract deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("An error occurred while deleting contract" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Sub

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
    Public Function GetServiceDetails(serviceName As String) As AppointmentServiceDetails
        Using con As New SqlConnection(constr)
            Dim details As New AppointmentServiceDetails()
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
End Class
Public Class AppointmentServiceDetails
    Public Property ServiceID As Integer
    Public Property Price As Decimal
End Class
