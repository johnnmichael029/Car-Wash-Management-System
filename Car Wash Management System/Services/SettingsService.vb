Imports System.Reflection

Public Class SettingsService

    Public Shared Property DiscountEnabled As Boolean
    Public Shared Property DiscountValue As Decimal

    Public Shared Function ApplyDiscountState(checkBoxDiscount As CheckBox, numericUpDownDiscount As NumericUpDown, fixDiscount As CheckBox) As Boolean
        ' Logic to enable or disable discount in the system
        If checkBoxDiscount.Checked Then
            numericUpDownDiscount.Enabled = True
            fixDiscount.Enabled = True
            DiscountEnabled = True
            Return True
        Else
            numericUpDownDiscount.Enabled = False
            DiscountEnabled = False
            fixDiscount.Enabled = False
            Return False
        End If

    End Function

    'Public Shared Function FixDiscountState(checkBoxFixDiscount As CheckBox, numericUpDownDiscount As NumericUpDown, comboBoxDiscount As ComboBox) As Boolean
    '    Dim numericValue As Integer = CInt(numericUpDownDiscount.Value)

    '    ' Always clear the items before rebuilding the list
    '    comboBoxDiscount.Items.Clear()

    '    If checkBoxFixDiscount.Checked Then
    '        ' SCENARIO 1: Fixed Discount is CHECKED (Image 2)

    '        ' The ComboBox should only contain 0 and the NumericValue (e.g., 0 and 10)
    '        comboBoxDiscount.Items.Add(0)

    '        If numericValue > 0 Then
    '            ' Only add the value if it's not already 0
    '            comboBoxDiscount.Items.Add(numericValue)
    '        End If

    '        ' Try to select the main numeric value, default to 0 if not found
    '        Dim itemIndex As Integer = comboBoxDiscount.FindStringExact(numericValue.ToString())
    '        If itemIndex <> -1 Then
    '            comboBoxDiscount.SelectedIndex = itemIndex
    '        Else
    '            comboBoxDiscount.SelectedIndex = 0
    '        End If

    '        Return True
    '    Else

    '        ' The ComboBox should contain sequential items from 0 up to NumericValue (e.g., 0, 1, 2, ... 10)
    '        For i As Integer = 0 To numericValue
    '            comboBoxDiscount.Items.Add(i)
    '        Next

    '        ' Try to select the last index (the NumericValue)
    '        If comboBoxDiscount.Items.Count > 0 Then
    '            comboBoxDiscount.SelectedIndex = comboBoxDiscount.Items.Count - 1
    '        End If

    '        Return False
    '    End If
    'End Function

    Public Shared Sub CheckIfNumericChanged(numericUpDownDiscount As NumericUpDown, saveBtn As Button)
        Dim isChanged As Boolean = numericUpDownDiscount.Value <> My.Settings.DiscountValue

        saveBtn.Enabled = isChanged

        If isChanged Then
            saveBtn.Enabled = True
            saveBtn.Text = "Save"
            saveBtn.BackColor = Color.Green
            saveBtn.ForeColor = Color.White
        Else
            saveBtn.Enabled = False
            saveBtn.Text = "Saved"
            saveBtn.BackColor = Color.LightGreen
            saveBtn.ForeColor = Color.White
        End If
    End Sub

    Public Shared Sub DiscountButtonForm(checkBoxEnableDiscount As CheckBox)
        ' Get the desired state from the current checkbox (which reflects the user's intended setting)
        Dim isDiscountEnabled As Boolean = checkBoxEnableDiscount.Checked

        ' Iterate over all currently open forms
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is PickUp Then
                Dim pickupForm As PickUp = DirectCast(frm, PickUp)
                ' Check if the control exists on that form before trying to access it
                If Not IsNothing(pickupForm.ComboBoxDiscount) Then
                    pickupForm.ComboBoxDiscount.Enabled = isDiscountEnabled
                    pickupForm.ComboBoxDiscount.SelectedIndex = -1
                End If
            ElseIf TypeOf frm Is SalesForm Then
                Dim salesForm As SalesForm = DirectCast(frm, SalesForm)
                If Not IsNothing(salesForm.ComboBoxDiscount) Then
                    salesForm.ComboBoxDiscount.Enabled = isDiscountEnabled
                    salesForm.ComboBoxDiscount.SelectedIndex = -1
                End If
            ElseIf TypeOf frm Is Dashboard Then
                Dim dashboardForm As Dashboard = DirectCast(frm, Dashboard)
                If Not IsNothing(dashboardForm.ComboBoxDiscount) Then
                    dashboardForm.ComboBoxDiscount.Enabled = isDiscountEnabled
                    dashboardForm.ComboBoxDiscount.SelectedIndex = -1
                End If
            ElseIf TypeOf frm Is Contracts Then
                Dim contractsForm As Contracts = DirectCast(frm, Contracts)
                If Not IsNothing(contractsForm.ComboBoxDiscount) Then
                    contractsForm.ComboBoxDiscount.Enabled = isDiscountEnabled
                    contractsForm.ComboBoxDiscount.SelectedIndex = -1
                End If
            ElseIf TypeOf frm Is Appointment Then
                Dim appointmentForm As Appointment = DirectCast(frm, Appointment)
                If Not IsNothing(appointmentForm.ComboBoxDiscount) Then
                    appointmentForm.ComboBoxDiscount.Enabled = isDiscountEnabled
                    appointmentForm.ComboBoxDiscount.SelectedIndex = -1
                End If
            End If

        Next
    End Sub

    Public Shared Sub RefreshAllDiscountControls()

        ' Forms that contain ComboBoxDiscount (replace with your actual form names)
        Dim formTypes As Type() = {
            GetType(PickUp), GetType(SalesForm), GetType(Dashboard),
            GetType(Contracts), GetType(Appointment)
        }

        ' Loop through every form currently open in the application
        For Each frm As Form In Application.OpenForms

            ' Check if the current form is one of the types we need to update
            If Array.IndexOf(formTypes, frm.GetType()) <> -1 Then

                Try
                    ' Use Reflection to safely get the ComboBoxDiscount property/field
                    ' Assuming the ComboBox is public or internal/friend and named 'ComboBoxDiscount'
                    Dim comboBoxProp As PropertyInfo = frm.GetType().GetProperty("ComboBoxDiscount")
                    Dim comboBoxField As FieldInfo = frm.GetType().GetField("ComboBoxDiscount", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)

                    Dim targetComboBox As ComboBox = Nothing

                    If comboBoxProp IsNot Nothing Then
                        targetComboBox = DirectCast(comboBoxProp.GetValue(frm), ComboBox)
                    ElseIf comboBoxField IsNot Nothing Then
                        targetComboBox = DirectCast(comboBoxField.GetValue(frm), ComboBox)
                    End If

                    If targetComboBox IsNot Nothing Then
                        ' Call the single update logic on this form's ComboBox
                        UpdateSingleDiscountComboBox(targetComboBox)
                    End If

                Catch ex As Exception
                    ' Log error if a form exists but the ComboBox is missing or inaccessible
                    MessageBox.Show($"Error updating discount ComboBox on form '{frm.Name}': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            End If

        Next

    End Sub

    Public Shared Sub UpdateSingleDiscountComboBox(comboBoxDiscount As ComboBox)

        ' Read the state and value directly from Application Settings
        Dim isFixedDiscount As Boolean = My.Settings.FixDiscount
        Dim discountValue As Integer = My.Settings.DiscountValue
        Dim isEnabled As Boolean = My.Settings.DiscountEnabled

        ' Always clear the items before rebuilding the list
        comboBoxDiscount.Items.Clear()

        If isFixedDiscount Then
            ' SCENARIO: FIXED DISCOUNT (FixDiscount is CHECKED)
            ' Only 0 and the maximum configured value are available.

            comboBoxDiscount.Items.Add(0)

            If discountValue > 0 Then
                comboBoxDiscount.Items.Add(discountValue)
            End If

            ' Select the fixed DiscountValue by default
            'Dim itemIndex As Integer = comboBoxDiscount.FindStringExact(discountValue.ToString())
            'If itemIndex <> -1 Then
            '    comboBoxDiscount.SelectedIndex = itemIndex
            'ElseIf comboBoxDiscount.Items.Count > 0 Then
            '    comboBoxDiscount.SelectedIndex = 0 ' Fallback to 0
            'End If

        Else

            ' This loop creates the 0 to 10 range (11 items) as requested.
            For i As Integer = 0 To discountValue
                comboBoxDiscount.Items.Add(i)
            Next

            ' Select the maximum value (DiscountValue) by default, 
            ' as this represents the maximum available discount.
            If comboBoxDiscount.Items.Count > 0 Then
                ' Select the last item, which is the DiscountValue (e.g., 10)
                comboBoxDiscount.SelectedIndex = comboBoxDiscount.Items.Count - 1
            End If

        End If

        ' Set the enabled state based on the setting
        comboBoxDiscount.Enabled = isEnabled

    End Sub

    Public Shared Sub CheckIfAdmin(checkBoxDiscount As CheckBox, CheckBoxFixDiscount As CheckBox, numericUpDownDiscount As NumericUpDown)
        Dim username As String = Login.LabelWelcomeUsers(Carwash.Label3.Text)
        If Not ServiceDatabaseHelper.CheckIfAdmin(username) Then
            Settings.LabelIsAdmin.Text = "Only Admin can update Discount."
            checkBoxDiscount.Enabled = False
            CheckBoxFixDiscount.Enabled = False
            numericUpDownDiscount.Enabled = False

        Else
            Settings.LabelIsAdmin.Text = ""
            checkBoxDiscount.Enabled = True
            CheckBoxFixDiscount.Enabled = True
            numericUpDownDiscount.Enabled = True

        End If
    End Sub

    Public Shared Sub TextBoxTotalPriceFieldEnabled(CheckBoxTotalPrice As CheckBox, comboBoxSelectedForm As ComboBox)
        Dim isPriceFieldEnabled As Boolean = CheckBoxTotalPrice.Checked
        Dim selectedFormName As String = If(Not IsNothing(comboBoxSelectedForm.SelectedItem), comboBoxSelectedForm.SelectedItem.ToString(), String.Empty)
        ApplyTotalPriceSettings(isPriceFieldEnabled, selectedFormName)
    End Sub

    Public Shared Sub ApplyTotalPriceSettings(isPriceFieldEnabled As Boolean, selectedFormName As String)
        For Each frm As Form In Application.OpenForms

            ' 1. Regular Form (SalesForm)
            If selectedFormName.Equals("Regular", StringComparison.OrdinalIgnoreCase) OrElse selectedFormName.Equals("Select-All", StringComparison.OrdinalIgnoreCase) Then
                If TypeOf frm Is SalesForm Then
                    Dim salesForm As SalesForm = DirectCast(frm, SalesForm)
                    If Not IsNothing(salesForm.TextBoxPrice) Then
                        salesForm.TextBoxPrice.ReadOnly = Not isPriceFieldEnabled
                    End If
                End If
            End If

            ' 2. Dashboard Form
            If selectedFormName.Equals("Dashboard", StringComparison.OrdinalIgnoreCase) OrElse selectedFormName.Equals("Select-All", StringComparison.OrdinalIgnoreCase) Then
                If TypeOf frm Is Dashboard Then
                    Dim dashboardForm As Dashboard = DirectCast(frm, Dashboard)
                    If Not IsNothing(dashboardForm.TextBoxPrice) Then
                        dashboardForm.TextBoxPrice.ReadOnly = Not isPriceFieldEnabled
                    End If
                End If
            End If

            ' 3. Pickup Form
            If selectedFormName.Equals("Pickup", StringComparison.OrdinalIgnoreCase) OrElse selectedFormName.Equals("Select-All", StringComparison.OrdinalIgnoreCase) Then
                If TypeOf frm Is PickUp Then
                    Dim pickupForm As PickUp = DirectCast(frm, PickUp)
                    If Not IsNothing(pickupForm.TextBoxPrice) Then
                        ' Note: Pickup uses .Enabled. Ensure behavior is consistent with ReadOnly.
                        pickupForm.TextBoxPrice.ReadOnly = Not isPriceFieldEnabled
                    End If
                End If
            End If

            ' 4. Contract Form
            If selectedFormName.Equals("Contract", StringComparison.OrdinalIgnoreCase) OrElse selectedFormName.Equals("Select-All", StringComparison.OrdinalIgnoreCase) Then
                If TypeOf frm Is Contracts Then
                    Dim contractsForm As Contracts = DirectCast(frm, Contracts)
                    If Not IsNothing(contractsForm.TextBoxPrice) Then
                        contractsForm.TextBoxPrice.ReadOnly = Not isPriceFieldEnabled
                    End If
                End If
            End If

            ' 5. Appointment Form
            If selectedFormName.Equals("Appointment", StringComparison.OrdinalIgnoreCase) OrElse selectedFormName.Equals("Select-All", StringComparison.OrdinalIgnoreCase) Then
                If TypeOf frm Is Appointment Then
                    Dim appointmentForm As Appointment = DirectCast(frm, Appointment)
                    If Not IsNothing(appointmentForm.TextBoxPrice) Then
                        appointmentForm.TextBoxPrice.ReadOnly = Not isPriceFieldEnabled
                    End If
                End If
            End If

            ' (Optional: For any forms that are open but not the selected one, you might need 
            ' a default rule if you want them to be disabled when another single form is selected.
            ' But based on your current logic, if a form isn't the selected one, its state 
            ' remains whatever it was before, unless "Select-All" is used.)

        Next
    End Sub

    Public Shared Sub ApplyTotalPriceSettingsOnLoad()
        ' Read the saved Boolean setting for the CheckBox state
        Dim isPriceFieldEnabled As Boolean = My.Settings.PriceFieldEnabled

        ' Read the saved String setting for the ComboBox selected item
        Dim selectedFormName As String = My.Settings.SelectedFormItem

        ' Apply the settings using the saved values
        ApplyTotalPriceSettings(isPriceFieldEnabled, selectedFormName)
    End Sub

    Public Shared Sub EnabledTotalPriceFieldState(checkBoxTotalPrice As CheckBox, ComboBoxSelectForm As ComboBox)

        If checkBoxTotalPrice.Checked Then
            ComboBoxSelectForm.Enabled = True
        Else
            ComboBoxSelectForm.Enabled = False
        End If

    End Sub

End Class
