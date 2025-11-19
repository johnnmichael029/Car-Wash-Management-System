Public Class DataGridCellContentClick
    Public Shared Sub HighlightSelectedRow(e As DataGridViewCellEventArgs, dataGridView As DataGridView)
        If e.RowIndex >= 0 Then
            ' Clear previous selection
            dataGridView.ClearSelection()
            ' Highlight the selected row
            dataGridView.Rows(e.RowIndex).Selected = True
        End If
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
         textBoxCustomerName As TextBox,
         dataGridViewAppointment As DataGridView,
         DateTimePickerStartDate As DateTimePicker,
         comboBoxPaymentMethod As ComboBox,
         TextBoxReferenceID As TextBox,
         TextBoxCheque As TextBox,
         TextBoxTotalPrice As TextBox,
         ComboBoxAppointmentStatus As ComboBox,
         ComboBoxDetailer As ComboBox,
         TextBoxNotes As TextBox,
         LabelAppointmentID As Label,
         ListViewServices As ListView,
         errorHandler As Action(Of String) ' The error handling delegate
    )

        Dim currentRow As DataGridViewRow

        Try
            If dataGridViewAppointment.CurrentRow Is Nothing Then
                errorHandler.Invoke("No row is currently selected.")
                Return
            End If

            currentRow = dataGridViewAppointment.CurrentRow
            textBoxCustomerName.Text = currentRow.Cells("CustomerName").Value.ToString()
            DateTimePickerStartDate.Value = Convert.ToDateTime(currentRow.Cells(4).Value)
            comboBoxPaymentMethod.Text = currentRow.Cells(5).Value?.ToString()
            Dim paymentMethod As String = comboBoxPaymentMethod.Text
            Dim referenceValue As String = currentRow.Cells(6).Value?.ToString()

            If paymentMethod.Equals("Gcash", StringComparison.OrdinalIgnoreCase) Then
                TextBoxReferenceID.Text = referenceValue
                TextBoxCheque.Clear()
            ElseIf paymentMethod.Equals("Cheque", StringComparison.OrdinalIgnoreCase) Then
                TextBoxCheque.Text = referenceValue
                TextBoxReferenceID.Clear()
            Else
                TextBoxCheque.Clear()
                TextBoxReferenceID.Clear()
            End If
            TextBoxTotalPrice.Text = currentRow.Cells(7).Value.ToString()
            ComboBoxAppointmentStatus.Text = currentRow.Cells(8).Value.ToString()
            ComboBoxDetailer.Text = currentRow.Cells(9).Value.ToString()
            TextBoxNotes.Text = currentRow.Cells(10).Value.ToString()
            Dim appointmentIDValue As String = currentRow.Cells("AppointmentID").Value.ToString()
            LabelAppointmentID.Text = appointmentIDValue

            If String.IsNullOrEmpty(appointmentIDValue) Then Return
            Dim appointmentID As Integer
            If Integer.TryParse(appointmentIDValue, appointmentID) Then
                LoadService.LoadServicesIntoListViewAppointmentForm(appointmentIDValue, ListViewServices)
            Else
                errorHandler.Invoke("Invalid Appointment ID format.")
            End If

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while selecting the appointment: " & ex.Message)
            If TextBoxTotalPrice IsNot Nothing Then
                TextBoxTotalPrice.Text = "0.00"
            End If
        End Try
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
    TextBoxServiceName As TextBox,
    CheckBoxAddon As CheckBox,
    TextBoxDescription As TextBox,
    TextBoxPrice As TextBox,
    LabelServiceID As Label,
    DataGridViewService As DataGridView
)

        Try
            Dim currentRow As DataGridViewRow = DataGridViewService.CurrentRow

            If currentRow Is Nothing Then Return

            TextBoxServiceName.Text = currentRow.Cells("ServiceName").Value.ToString()
            CheckBoxAddon.Checked = Convert.ToBoolean(currentRow.Cells("Addon").Value)
            TextBoxDescription.Text = currentRow.Cells("Description").Value.ToString()
            TextBoxPrice.Text = currentRow.Cells("Price").Value.ToString()
            LabelServiceID.Text = currentRow.Cells("ServiceID").Value.ToString()
        Catch ex As Exception
            TextBoxServiceName.Clear()
            TextBoxDescription.Clear()
            TextBoxPrice.Clear()
            LabelServiceID.Text = String.Empty
        End Try
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
       TextBoxCustomerName As TextBox,
       DataGridViewSales As DataGridView,
       ComboBoxPaymentMethod As ComboBox,
       TextBoxReferenceID As TextBox,
       TextBoxCheque As TextBox,
       TextBoxTotalPrice As TextBox,
       ComboBoxDetailer As ComboBox,
       LabelSalesID As Label,
       ListViewServices As ListView,
       errorHandler As Action(Of String)
   )
        Try
            If DataGridViewSales.CurrentRow Is Nothing Then Return

            Dim currentRow As DataGridViewRow = DataGridViewSales.CurrentRow

            TextBoxCustomerName.Text = currentRow.Cells("CustomerName").Value?.ToString()

            ' Column 5 is PaymentMethod
            ComboBoxPaymentMethod.SelectedItem = currentRow.Cells(5).Value?.ToString()

            Dim paymentMethod As String = ComboBoxPaymentMethod.SelectedItem?.ToString()

            If paymentMethod.Equals("Gcash", StringComparison.OrdinalIgnoreCase) Then
                ' Column 6 is ReferenceID
                TextBoxReferenceID.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxCheque.Clear()
            ElseIf paymentMethod.Equals("Cheque", StringComparison.OrdinalIgnoreCase) Then
                ' Column 6 is ReferenceID / Cheque Number
                TextBoxCheque.Text = currentRow.Cells(6).Value?.ToString()
                TextBoxReferenceID.Clear()
            Else
                TextBoxCheque.Clear()
                TextBoxReferenceID.Clear()
            End If

            TextBoxTotalPrice.Text = currentRow.Cells("TotalPrice").Value?.ToString()
            ComboBoxDetailer.Text = currentRow.Cells("Detailer").Value?.ToString()

            Dim saleIDValue As String = currentRow.Cells("SalesID").Value?.ToString()
            LabelSalesID.Text = saleIDValue

            If String.IsNullOrEmpty(saleIDValue) Then Return

            Dim saleID As Integer
            If Integer.TryParse(saleIDValue, saleID) Then
                LoadService.LoadServicesIntoListViewSalesForm(saleID, ListViewServices)
            Else
                errorHandler.Invoke("Invalid Sales ID format.")
            End If

        Catch ex As Exception
            errorHandler.Invoke("Error loading sale details: " & ex.Message)
            TextBoxTotalPrice.Text = "0.00"
        End Try
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
        DataGridViewCustomerInformation As DataGridView,
        TextBoxName As TextBox,
        TextBoxLastName As TextBox,
        TextBoxNumber As TextBox,
        TextBoxEmail As TextBox,
        TextBoxAddress As TextBox,
        TextBoxBarangay As TextBox,
        customerIDLabel As Label,
        ListViewVehicles As ListView,
        DataGridViewCustomerHistory As DataGridView,
        LabelContractStatus As Label,
        LabelTotalSaleMade As Label,
        LabelRevenue As Label,
        customerInformationDatabaseHelper As CustomerInformationDatabaseHelper,
        errorHandler As Action(Of String)
    )
        Try
            Dim currentRow As DataGridViewRow = DataGridViewCustomerInformation.CurrentRow

            If currentRow Is Nothing Then
                errorHandler.Invoke("No customer row is currently selected.")
                Return
            End If

            ' 1. Retrieve Customer ID
            Dim customerIDValue As String = currentRow.Cells("CustomerID").Value.ToString()

            If String.IsNullOrEmpty(customerIDValue) Then
                errorHandler.Invoke("Selected customer has no ID.")
                Return
            End If

            ' 2. Populate basic fields
            TextBoxName.Text = currentRow.Cells("Name").Value.ToString()
            TextBoxLastName.Text = currentRow.Cells("LastName").Value.ToString()
            TextBoxNumber.Text = currentRow.Cells("PhoneNumber").Value.ToString()
            TextBoxEmail.Text = currentRow.Cells("Email").Value.ToString()
            TextBoxAddress.Text = currentRow.Cells("Address").Value.ToString()
            TextBoxBarangay.Text = currentRow.Cells("Barangay").Value.ToString()
            customerIDLabel.Text = customerIDValue

            ' 3. Load history/derived data from Database Helper
            DataGridViewCustomerHistory.DataSource = customerInformationDatabaseHelper.GetCustomerTransactionHistory(customerIDValue)
            LabelContractStatus.Text = customerInformationDatabaseHelper.GetCustomerContractStatus(customerIDValue)
            LabelTotalSaleMade.Text = customerInformationDatabaseHelper.GetCustomerSalesCount(customerIDValue)

            ' Format Revenue as Currency
            Dim totalRevenue As Decimal = customerInformationDatabaseHelper.GetTotalSalesAmountByCustomer(customerIDValue)
            LabelRevenue.Text = "₱" & totalRevenue.ToString("N2")

            ' 4. Load vehicles into ListView
            LoadService.LoadVehiclesIntoListViewCustomerFOrm(customerIDValue, ListViewVehicles)

        Catch ex As Exception
            errorHandler.Invoke("An error occurred during customer data retrieval: " & ex.Message)
        End Try
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
       DataGridViewContract As DataGridView,
       TextBoxCustomerName As TextBox,
       DateTimePickerStartDate As DateTimePicker,
       DateTimePickerEndDate As DateTimePicker,
       ComboBoxBillingFrequency As ComboBox,
       ComboBoxPaymentMethod As ComboBox,
       TextBoxReferenceID As TextBox,
       TextBoxCheque As TextBox,
       TextBoxTotalPrice As TextBox,
       ComboBoxContractStatus As ComboBox,
       ComboBoxDetailer As ComboBox,
       LabelContractID As Label,
       ListViewServices As ListView,
       errorHandler As Action(Of String)
   )
        Try
            If DataGridViewContract.CurrentRow Is Nothing Then Return

            Dim currentRow As DataGridViewRow = DataGridViewContract.CurrentRow

            ' 1. Populate TextBoxes/ComboBoxes
            TextBoxCustomerName.Text = currentRow.Cells(1).Value?.ToString()
            DateTimePickerStartDate.Text = currentRow.Cells(4).Value?.ToString()
            DateTimePickerEndDate.Text = currentRow.Cells(5).Value?.ToString()
            ComboBoxBillingFrequency.Text = currentRow.Cells(6).Value?.ToString()
            ComboBoxPaymentMethod.Text = currentRow.Cells(7).Value?.ToString()

            Dim paymentMethod As String = ComboBoxPaymentMethod.Text
            Dim referenceValue As String = currentRow.Cells(8).Value?.ToString()

            If paymentMethod.Equals("Gcash", StringComparison.OrdinalIgnoreCase) Then
                TextBoxReferenceID.Text = referenceValue
                TextBoxCheque.Clear()
            ElseIf paymentMethod.Equals("Cheque", StringComparison.OrdinalIgnoreCase) Then
                TextBoxCheque.Text = referenceValue
                TextBoxReferenceID.Clear()
            Else
                TextBoxCheque.Clear()
                TextBoxReferenceID.Clear()
            End If

            TextBoxTotalPrice.Text = currentRow.Cells(9).Value?.ToString()
            ComboBoxContractStatus.Text = currentRow.Cells(10).Value?.ToString()
            ComboBoxDetailer.Text = currentRow.Cells(11).Value?.ToString()

            ' Set the ID for persistence
            Dim contractIDValue As String = currentRow.Cells(0).Value?.ToString()
            LabelContractID.Text = contractIDValue

            If String.IsNullOrEmpty(contractIDValue) Then Return

            ' 2. Load Services into ListView
            Dim contractID As Integer
            If Integer.TryParse(contractIDValue, contractID) Then
                LoadService.LoadServicesIntoListViewContractForm(contractID, ListViewServices)
            Else
                errorHandler.Invoke("Invalid Contract ID format.")
            End If

        Catch ex As Exception
            errorHandler.Invoke("Error loading contract details: " & ex.Message)
            TextBoxTotalPrice.Text = "0.00"
        End Try
    End Sub

    Public Overloads Shared Sub GetSelectedRowData(
       DataGridViewEmployee As DataGridView,
       TextBoxName As TextBox,
       TextBoxLastName As TextBox,
       TextBoxPhoneNumber As TextBox,
       TextBoxAge As TextBox,
       TextBoxEmail As TextBox,
       TextBoxAddress As TextBox,
       TextBoxBarangay As TextBox,
       ComboBoxGender As ComboBox,
       ComboBoxPosition As ComboBox,
       LabelEmployeeID As Label,
       errorHandler As Action(Of String)
       )
        Try
            Dim currentRow As DataGridViewRow = DataGridViewEmployee.CurrentRow

            If currentRow Is Nothing Then
                errorHandler.Invoke("No employee row is currently selected.")
                Return
            End If

            TextBoxName.Text = currentRow.Cells("Name").Value.ToString()
            TextBoxLastName.Text = currentRow.Cells("LastName").Value.ToString()
            TextBoxPhoneNumber.Text = currentRow.Cells("PhoneNumber").Value.ToString()
            TextBoxAge.Text = currentRow.Cells("Age").Value.ToString()
            TextBoxEmail.Text = currentRow.Cells("Email").Value.ToString()
            TextBoxAddress.Text = currentRow.Cells("Address").Value.ToString()
            TextBoxBarangay.Text = currentRow.Cells("Barangay").Value.ToString()
            ComboBoxGender.Text = currentRow.Cells("Gender").Value.ToString()
            ComboBoxPosition.Text = currentRow.Cells(10).Value.ToString()
            LabelEmployeeID.Text = currentRow.Cells("EmployeeID").Value.ToString()
        Catch ex As Exception
            errorHandler.Invoke("An error occurred during employee data retrieval: " & ex.Message)
        End Try
    End Sub


End Class
