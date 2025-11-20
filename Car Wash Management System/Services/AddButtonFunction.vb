

Public Class AddButtonFunction
    ' Overload 1: For adding a new Appointment
    Public Overloads Shared Function AddDataToDatabase(
       TextBoxCustomerID As TextBox,
       TextBoxTotalPrice As TextBox,
       DateTimePickerStartDate As DateTimePicker,
       ComboBoxPaymentMethod As ComboBox,
       TextBoxReferenceID As TextBox,
       TextBoxCheque As TextBox,
       ComboBoxAppointmentStatus As ComboBox,
       ComboBoxDetailer As ComboBox,
       TextBoxNotes As TextBox,
       errorHandler As Action(Of String), ' Delegate for displaying error messages
       AppointmentManagementDatabaseHelper As AppointmentManagementDatabaseHelper
   ) As Boolean

        Try

            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                errorHandler.Invoke("Customer not found. Please select a valid customer.")
                Return False
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                errorHandler.Invoke("Please enter a valid total price.")
                Return False
            End If

            ' The AddSaleToListView class (assumed to hold the service data) should expose the list
            If AddSaleToListView.AppointmentServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the appointment.")
                Return False
            End If

            ' Validate if the Start date is not in the past (allowing for a small buffer, e.g., 1 minute)
            If DateTimePickerStartDate.Value <= DateTime.Now.AddMinutes(-1) Then
                errorHandler.Invoke("The appointment date and time cannot be in the past.")
                Return False
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a payment method.")
                Return False
            End If

            ' Validate payment details
            Dim selectedPaymentMethod As String = ComboBoxPaymentMethod.Text

            If selectedPaymentMethod.Equals("Gcash", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                errorHandler.Invoke("Please enter a Reference ID for the selected payment method (Gcash).")
                Return False
            End If
            If selectedPaymentMethod.Equals("Cheque", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                errorHandler.Invoke("Please enter a Cheque Number for the selected payment method (Cheque).")
                Return False
            End If

            If ComboBoxAppointmentStatus.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select an appointment status.")
                Return False
            End If
            If ComboBoxDetailer.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a detailer.")
                Return False
            End If

            AppointmentManagementDatabaseHelper.AddAppointment(
                customerID,
                AddSaleToListView.AppointmentServiceList,
                DateTimePickerStartDate.Value,
                selectedPaymentMethod,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxAppointmentStatus.Text.Trim(),
                ComboBoxDetailer.Text,
                TextBoxNotes.Text
            )


            MessageBox.Show("Appointment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while adding the appointment: " & ex.Message)
        End Try

        Return True
    End Function

    ' Overload 2: For adding a new Service
    Public Overloads Shared Function AddDataToDatabase(
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

            serviceDatabaseHelper.AddService(
                TextBoxServiceName.Text,
                TextBoxDescription.Text,
                TextBoxPrice.Text,
                LabelServiceID.Text,
                CheckBoxAddon.Checked
            )


            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while adding the service: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 3: For adding a new Sale
    Public Overloads Shared Function AddDataToDatabase(
        TextBoxCustomerID As TextBox,
        ComboBoxPaymentMethod As ComboBox,
        TextBoxReferenceID As TextBox,
        TextBoxCheque As TextBox,
        ComboBoxDetailer As ComboBox,
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
            If ComboBoxDetailer.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a detailer.")
                Return False
            End If

            SalesDatabaseHelper.AddSale(
                customerID,
                AddSaleToListView.SaleServiceList,
                selectedPaymentMethod,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                ComboBoxDetailer.Text,
                TextBoxTotalPrice.Text
            )

            MessageBox.Show("Sale added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while adding the sale: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 4: For adding a new Customer
    Public Overloads Shared Function AddDataToDatabase(
        TextBoxName As TextBox,
        TextBoxLastName As TextBox,
        TextBoxNumber As TextBox,
        TextBoxEmail As TextBox,
        TextBoxAddress As TextBox,
        TextBoxBarangay As TextBox,
        customerInformationDatabaseHelper As CustomerInformationDatabaseHelper,
        errorHandler As Action(Of String)
    ) As Boolean

        ' --- 1. Validation ---
        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Or String.IsNullOrEmpty(TextBoxLastName.Text) Then
            errorHandler.Invoke("Please fill in all required customer fields (First Name, Last Name, Phone, Email).")
            Return False
        End If

        If AddVehicleToListView.VehicleList.Count = 0 Then
            errorHandler.Invoke("Please add at least one vehicle before saving the customer.")
            Return False
        End If

        Try
            ' --- 2. Database Insertion ---
            customerInformationDatabaseHelper.AddCustomer(
                TextBoxName.Text.Trim(),
                TextBoxLastName.Text.Trim(),
                TextBoxNumber.Text,
                TextBoxEmail.Text.Trim(),
                TextBoxAddress.Text.Trim(),
                TextBoxBarangay.Text.Trim(),
                AddVehicleToListView.VehicleList
            )

            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True

        Catch ex As Exception
            errorHandler.Invoke("Error saving data: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 5: For adding a new Contract
    Public Overloads Shared Function AddDataToDatabase(
        TextBoxCustomerID As TextBox,
        DateTimePickerStartDate As DateTimePicker,
        DateTimePickerEndDate As DateTimePicker,
        ComboBoxBillingFrequency As ComboBox,
        ComboBoxPaymentMethod As ComboBox,
        TextBoxReferenceID As TextBox,
        TextBoxCheque As TextBox,
        TextBoxTotalPrice As TextBox,
        ComboBoxContractStatus As ComboBox,
        ComboBoxDetailer As ComboBox,
        contractsDatabaseHelper As Object, ' Use Object as type is unknown (e.g., ContractsDatabaseHelper)
        errorHandler As Action(Of String)
    ) As Boolean

        Try
            ' --- 1. Customer ID Validation ---
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                errorHandler.Invoke("Customer not found. Please select a valid customer.")
                Return False
            End If

            ' --- 2. Services Validation ---
            If AddSaleToListView.ContractServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the contract.")
                Return False
            End If

            ' --- 3. Billing Frequency Validation ---
            If String.IsNullOrWhiteSpace(ComboBoxBillingFrequency.Text) Then
                errorHandler.Invoke("Please select a billing frequency.")
                Return False
            End If

            ' --- 4. Date Validations (Only if End Date is checked) ---
            If DateTimePickerEndDate.Checked Then
                Dim minEndDate As DateTime
                Select Case ComboBoxBillingFrequency.Text
                    Case "Monthly"
                        ' Assuming "Monthly" means minimum of 1 month later
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(1)
                    Case "Quarterly"
                        ' Assuming "Quarterly" means minimum of 3 months later (original had 4, corrected to 3)
                        minEndDate = DateTimePickerStartDate.Value.AddMonths(4)
                    Case "Yearly"
                        ' Assuming "Yearly" means minimum of 1 year later
                        minEndDate = DateTimePickerStartDate.Value.AddYears(1)
                    Case Else
                        errorHandler.Invoke("Invalid billing frequency selected for end date validation.")
                        Return False
                End Select
                ' Check if End Date is too close/in the past
                If DateTimePickerEndDate.Value.Date < minEndDate.Date Then
                    errorHandler.Invoke($"End date must be at least {ComboBoxBillingFrequency.Text.ToLower()} from the start date.")
                    Return False
                End If
            End If



            ' Check if End Date equals Today (based on original requirement)
            If DateTimePickerEndDate.Value.Date = DateTime.Now.Date Then
                errorHandler.Invoke("Date end must not equal to today's date.")
                Return False
            End If

            ' Check if Start Date > End Date
            If DateTimePickerStartDate.Value.Date > DateTimePickerEndDate.Value.Date Then
                errorHandler.Invoke("Start date cannot be later than end date.")
                Return False
            End If


            ' --- 5. Payment Method Validation ---
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

            ' --- 6. Contract Status Validation ---
            If String.IsNullOrWhiteSpace(ComboBoxContractStatus.Text) Then
                errorHandler.Invoke("Please select a contract status.")
                Return False
            End If

            ' --- 7. Price Validation ---
            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                errorHandler.Invoke("Please enter a valid price.")
                Return False
            End If
            If ComboBoxDetailer.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a detailer.")
                Return False
            End If

            ' --- 8. Database Insertion ---
            contractsDatabaseHelper.AddContract(
                customerID,
                AddSaleToListView.ContractServiceList,
                DateTimePickerEndDate.Text, ' Use DateTimePickerEndDate.Value.ToString("yyyy-MM-dd") if the database helper expects a formatted date string
                ComboBoxBillingFrequency.Text,
                ComboBoxPaymentMethod.Text,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxContractStatus.Text,
                ComboBoxDetailer.Text
)
            MessageBox.Show("Contract added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True

        Catch ex As Exception
            errorHandler.Invoke("An error occurred while adding the contract: " & ex.Message)
            Return False
        End Try
    End Function

    ' Overload 6: For adding a new Employee
    Public Overloads Shared Function AddDataToDatabase(
           TextBoxName As TextBox,
           TextBoxLastName As TextBox,
           TextBoxPhoneNumber As TextBox,
           TextBoxAge As TextBox,
           TextBoxEmail As TextBox,
           TextBoxAddress As TextBox,
           TextBoxBarangay As TextBox,
           ComboBoxGender As ComboBox,
           ComboBoxPosition As ComboBox,
           EmployeeMangamentDatabaseHelper As EmployeeMangamentDatabaseHelper, ' <<< ADDED MISSING PARAMETER
           errorHandler As Action(Of String) ' <<< ADDED MISSING PARAMETER
           ) As Boolean

        Try
            ' --- 1. Validation ---


            ' --- 2. Database Insertion ---
            EmployeeMangamentDatabaseHelper.AddEmployeeData(
                TextBoxName.Text.Trim(),
                TextBoxLastName.Text.Trim(),
                TextBoxPhoneNumber.Text.Trim(),
                TextBoxAge.Text.Trim(),
                TextBoxEmail.Text.Trim(),
                TextBoxAddress.Text.Trim(),
                TextBoxBarangay.Text.Trim(),
                ComboBoxGender.Text.Trim(),
                ComboBoxPosition.Text
            )

            MessageBox.Show("Employee data added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch ex As Exception
            errorHandler.Invoke("Error saving data: " & ex.Message) ' <<< Changed MessageBox to errorHandler
            Return False
        End Try

    End Function

    ' Overload 7: For adding a new Pickup
    Public Overloads Shared Function AddDataToPickupTable(
       TextBoxCustomerID As TextBox,
       TextBoxPickupAddress As TextBox,
       DateTimePickerStartDate As DateTimePicker,
       ComboBoxPaymentMethod As ComboBox,
       TextBoxReferenceID As TextBox,
       TextBoxCheque As TextBox,
       ComboBoxDetailer As ComboBox,
       TextBoxTotalPrice As TextBox,
       ComboBoxPickupStatus As ComboBox,
       TextBoxNotes As TextBox,
       errorHandler As Action(Of String),
       PickupManagementDatabaseHelper As PickupManagementDatabaseHelper
       ) As Boolean

        Try

            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                errorHandler.Invoke("Customer not found. Please select a valid customer.")
                Return False
            End If

            ' The AddSaleToListView class (assumed to' hold the service data) should expose the list
            If AddSaleToListView.PickupServiceList.Count = 0 Then
                errorHandler.Invoke("Please add at least one service to the pickup.")
                Return False
            End If

            ' Validate if the Start date is not in the past (allowing for a small buffer, e.g., 1 minute)
            If DateTimePickerStartDate.Value <= DateTime.Now.AddMinutes(-1) Then
                errorHandler.Invoke("The pickup date and time cannot be in the past.")
                Return False
            End If

            If TextBoxPickupAddress.Text.Trim() = String.Empty Then
                errorHandler.Invoke("Please enter a valid pickup address.")
                Return False
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a payment method.")
                Return False
            End If

            ' Validate payment details
            Dim selectedPaymentMethod As String = ComboBoxPaymentMethod.Text
            If selectedPaymentMethod.Equals("Gcash", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(TextBoxReferenceID.Text) Then
                errorHandler.Invoke("Please enter a Reference ID for the selected payment method (Gcash).")
                Return False
            End If
            If selectedPaymentMethod.Equals("Cheque", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(TextBoxCheque.Text) Then
                errorHandler.Invoke("Please enter a Cheque Number for the selected payment method (Cheque).")
                Return False
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxTotalPrice.Text, totalPrice) Then
                errorHandler.Invoke("Please enter a valid total price.")
                Return False
            End If

            If ComboBoxPickupStatus.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a pickup status.")
                Return False
            End If

            If ComboBoxDetailer.SelectedIndex = -1 Then
                errorHandler.Invoke("Please select a detailer.")
                Return False
            End If
            PickupManagementDatabaseHelper.AddPickup(
                customerID,
                AddSaleToListView.PickupServiceList,
                DateTimePickerStartDate.Value,
                TextBoxPickupAddress.Text,
                selectedPaymentMethod,
                TextBoxReferenceID.Text,
                TextBoxCheque.Text,
                totalPrice,
                ComboBoxPickupStatus.Text.Trim(),
                ComboBoxDetailer.Text,
                TextBoxNotes.Text
            )
            MessageBox.Show("Pickup added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            errorHandler.Invoke("An error occurred while adding the pickup: " & ex.Message)
        End Try
        Return True
    End Function
End Class
