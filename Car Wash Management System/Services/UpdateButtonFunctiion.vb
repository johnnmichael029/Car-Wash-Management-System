Public Class UpdateButtonFunctiion
    ' Overload 1: For adding a new Appointment
    Public Overloads Shared Function UpdateDataToDatabase(
     TextBoxCustomerID As TextBox,
     LabelAppointmentID As Label,
     TextBoxTotalPrice As TextBox,
     DateTimePickerStartDate As DateTimePicker,
     ComboBoxPaymentMethod As ComboBox,
     TextBoxReferenceID As TextBox,
     TextBoxCheque As TextBox,
     ComboBoxAppointmentStatus As ComboBox,
     TextBoxNotes As TextBox,
     AppointmentManagementDatabaseHelper As AppointmentManagementDatabaseHelper,
     errorHandler As Action(Of String)
 ) As Boolean

        Try
            Dim appointmentID As Integer
            Dim customerID As Integer
            Dim price As Decimal ' Using price variable as it was in the original logic, even though it wasn't assigned to TextBoxTotalPrice

            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Or Not Integer.TryParse(LabelAppointmentID.Text, appointmentID) Then
                errorHandler.Invoke("Customer or Appointment not found. Please select a valid record.")
                Return False
            End If

            Dim totalPriceValue As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPriceValue) Then
                errorHandler.Invoke("Please enter a valid price.")
                Return False
            End If

            ' Note: The original code used a 'price' variable which was never assigned. 
            ' For the database call, I will use the validated 'totalPriceValue' from TextBoxTotalPrice, 
            ' but I must keep the original 'price' variable name if the database helper expects it in the argument list.
            ' Assuming 'price' in the original database call was intended to be the validated total price.
            price = totalPriceValue

            If AddSaleToListView.AppointmentServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the appointment.")
                Return False
            End If

            If DateTimePickerStartDate.Value < DateTime.Now.AddMinutes(-1) Then
                errorHandler.Invoke("The appointment date and time cannot be in the past.")
                Return False
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a payment method.")
                Return False
            End If

            Dim selectedPaymentMethod As String = ComboBoxPaymentMethod.SelectedItem.ToString()

            If selectedPaymentMethod = "Gcash" AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                errorHandler.Invoke("Please enter a Reference ID for the selected payment method (Gcash).")
                Return False
            End If
            If selectedPaymentMethod = "Cheque" AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                errorHandler.Invoke("Please enter a Cheque Number for the selected payment method (Cheque).")
                Return False
            End If

            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select an appointment status.")
                Return False
            End If

            AppointmentManagementDatabaseHelper.UpdateAppointment(
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
            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while updating the appointment: " & ex.Message)
            Return False
        End Try

    End Function

    ' Overload 2: For adding a new Service
    Public Overloads Shared Function UpdateDataToDatabase(
        TextBoxServiceName As TextBox,
        TextBoxDescription As TextBox,
        TextBoxPrice As TextBox,
        LabelServiceID As Label,
        CheckBoxAddon As CheckBox,
        serviceDatabaseHelper As ServiceDatabaseHelper,
        errorHandler As Action(Of String)
    ) As Boolean

        Try
            If String.IsNullOrEmpty(TextBoxServiceName.Text) Or String.IsNullOrEmpty(TextBoxPrice.Text) Then
                errorHandler.Invoke("Please fill in the Service Name and Price fields.")
                Return False
            End If

            Dim priceValue As Decimal
            If Not Decimal.TryParse(TextBoxPrice.Text, priceValue) Then
                errorHandler.Invoke("Please enter a valid numeric price.")
                Return False
            End If

            serviceDatabaseHelper.UpdateService(
                TextBoxServiceName.Text,
                TextBoxDescription.Text,
                TextBoxPrice.Text,
                LabelServiceID.Text,
                CheckBoxAddon.Checked
            )

            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while updating the service: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 3: Update Sale
    Public Overloads Shared Function UpdateDataToDatabase(
        TextBoxCustomerID As TextBox,
        LabelSalesID As Label,
        ComboBoxPaymentMethod As ComboBox,
        TextBoxReferenceID As TextBox,
        TextBoxCheque As TextBox,
        TextBoxTotalPrice As TextBox,
        errorHandler As Action(Of String)
    ) As Boolean

        Try
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) OrElse customerID <= 0 Then
                errorHandler.Invoke("Please select a valid customer from the list.")
                Return False
            End If

            If AddSaleToListView.SaleServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the sale.")
                Return False
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a payment method.")
                Return False
            End If

            Dim selectedPaymentMethod As String = ComboBoxPaymentMethod.SelectedItem.ToString()

            If selectedPaymentMethod = "Gcash" AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                errorHandler.Invoke("Please enter a Reference ID for the selected payment method (Gcash).")
                Return False
            End If
            If selectedPaymentMethod = "Cheque" AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                errorHandler.Invoke("Please enter a Cheque Number for the selected payment method (Cheque).")
                Return False
            End If

            SalesDatabaseHelper.UpdateSale(
                customerID,
                LabelSalesID.Text,
                AddSaleToListView.SaleServiceList,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                TextBoxTotalPrice.Text
            )

            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while updating the sale: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 4: Update Customer
    Public Overloads Shared Function UpdateDataToDatabase(
        customerIDLabel As Label,
        TextBoxName As TextBox,
        TextBoxLastName As TextBox,
        TextBoxNumber As TextBox,
        TextBoxEmail As TextBox,
        TextBoxAddress As TextBox,
        TextBoxBarangay As TextBox,
        customerInformationDatabaseHelper As CustomerInformationDatabaseHelper,
        errorHandler As Action(Of String)
    ) As Boolean

        Try
            ' Validation 1: Check for required fields
            If String.IsNullOrEmpty(TextBoxName.Text) Or
               String.IsNullOrEmpty(TextBoxNumber.Text) Or
               String.IsNullOrEmpty(TextBoxEmail.Text) Or
               String.IsNullOrEmpty(TextBoxLastName.Text) Then
                errorHandler.Invoke("Please fill in all required customer fields (First Name, Last Name, Phone, Email).")
                Return False
            End If

            ' Validation 2: Ensure at least one vehicle is added
            If AddVehicleToListView.VehicleList.Count = 0 Then
                errorHandler.Invoke("Please add at least one vehicle before updating the customer.")
                Return False
            End If

            ' If all validation passes, call the database helper
            customerInformationDatabaseHelper.UpdateCustomer(
                customerIDLabel.Text,
                TextBoxName.Text,
                TextBoxLastName.Text,
                TextBoxNumber.Text,
                TextBoxEmail.Text,
                TextBoxAddress.Text,
                TextBoxBarangay.Text,
                AddVehicleToListView.VehicleList
            )

            Return True ' Success

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while updating the customer: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 5: Update Contract
    Public Overloads Shared Function UpdateDataToDatabase(
        LabelContractID As Label,
        TextBoxCustomerID As TextBox,
        DateTimePickerStartDate As DateTimePicker,
        DateTimePickerEndDate As DateTimePicker,
        ComboBoxBillingFrequency As ComboBox,
        ComboBoxPaymentMethod As ComboBox,
        TextBoxReferenceID As TextBox,
        TextBoxCheque As TextBox,
        ComboBoxContractStatus As ComboBox,
        TextBoxTotalPrice As TextBox,
        contractsDatabaseHelper As ContractsDatabaseHelper,
        errorHandler As Action(Of String)
    ) As Boolean

        Try
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                errorHandler.Invoke("Customer not found. Please select a valid customer.")
                Return False
            End If

            If AddSaleToListView.ContractServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the contract.")
                Return False
            End If

            ' Validate if billing frequency is selected
            If String.IsNullOrWhiteSpace(ComboBoxBillingFrequency.Text) Then
                errorHandler.Invoke("Please select a billing frequency.")
                Return False
            End If

            ' Validate if the price is decimal
            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                errorHandler.Invoke("Please enter a valid price.")
                Return False
            End If

            ' Validate end date constraints only if the end date is checked (used)
            If DateTimePickerEndDate.Checked Then

                ' Validate if end date is not equal to today
                If DateTimePickerEndDate.Value.Date = DateTime.Now.Date Then
                    errorHandler.Invoke("Date end must not equal to DateTime today.")
                    Return False
                End If

                ' Validate if the start date is greater than the end date
                If DateTimePickerStartDate.Value.Date > DateTimePickerEndDate.Value.Date Then
                    errorHandler.Invoke("Start date cannot be later than end date.")
                    Return False
                End If

                ' Validate if the end date is greater than or equal to the billing frequency duration
                Dim minEndDate As DateTime
                Select Case ComboBoxBillingFrequency.Text
                    Case "Monthly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(1)
                    Case "Quarterly"
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(4) ' Kept the user's logic of 4 months
                    Case "Yearly"
                        minEndDate = DateTimePickerStartDate.Value.AddYears(1)
                    Case Else
                        ' This should not be hit if the prior billing frequency check passed, but included for safety
                        errorHandler.Invoke("Invalid billing frequency selected for date validation.")
                        Return False
                End Select

                If DateTimePickerEndDate.Value.Date < minEndDate.Date Then
                    errorHandler.Invoke($"End date must be at least {ComboBoxBillingFrequency.Text.ToLower()} from the start date.")
                    Return False
                End If
            End If

            ' Validate if payment method is selected
            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a payment method.")
                Return False
            End If

            ' Validate payment method specific fields
            Dim selectedPaymentMethod As String = ComboBoxPaymentMethod.SelectedItem.ToString()

            If selectedPaymentMethod = "Gcash" AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                errorHandler.Invoke("Please enter a Reference ID for the selected payment method.")
                Return False
            End If
            If selectedPaymentMethod = "Cheque" AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                errorHandler.Invoke("Please enter a Cheque Number for the selected payment method.")
                Return False
            End If

            ' Validate if contract status is selected
            If String.IsNullOrWhiteSpace(ComboBoxContractStatus.Text) Then
                errorHandler.Invoke("Please select a contract status.")
                Return False
            End If


            ' If all validation passes, call the database helper
            contractsDatabaseHelper.UpdateContract(
                LabelContractID.Text,
                customerID,
                AddSaleToListView.ContractServiceList,
                DateTimePickerStartDate.Value,
                DateTimePickerEndDate.Value,
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxContractStatus.Text
            )
            MessageBox.Show("Contract updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True ' Success

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while updating the contract: " & ex.Message)
            Return False
        End Try
    End Function

End Class
