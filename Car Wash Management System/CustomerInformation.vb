Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    ' <<<< FIX 1: VehicleList moved to the class level >>>>
    ' This list now persists and is accessible by both AddVehicleBtn_Click and AddCustomerInformation.
    Private VehicleList As New List(Of VehicleService)

    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Dim activityLogInDashboardService As New ActivityLogInDashboardService(constr)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        customerInformationDatabaseHelper = New CustomerInformationDatabaseHelper(constr)
    End Sub

    Private Sub CustomerInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfCustomerInformation()
        ChangeHeaderOfDataGridViewCustomerInformation()
        DataGridViewCustomerInformationFontStyle()
        AddButtonAction()
        SetupListView()
    End Sub

    Private Sub ChangeHeaderOfDataGridViewCustomerInformation()
        DataGridViewCustomerInformation.Columns(0).HeaderText = "Customer ID"
        DataGridViewCustomerInformation.Columns(1).HeaderText = "Name"
        DataGridViewCustomerInformation.Columns(2).HeaderText = "Phone Number"
        DataGridViewCustomerInformation.Columns(3).HeaderText = "Email"
        DataGridViewCustomerInformation.Columns(4).HeaderText = "Address"
        DataGridViewCustomerInformation.Columns(5).HeaderText = "Registration Date"
    End Sub

    Private Sub LoadListOfCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerInformation.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewCustomerInformation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerInformation.CellContentClick
        TextBoxName.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Name").Value.ToString()
        TextBoxNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PhoneNumber").Value.ToString()
        TextBoxEmail.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Email").Value.ToString()
        TextBoxAddress.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Address").Value.ToString()
        TextBoxVehicle.Text = DataGridViewCustomerInformation.CurrentRow.Cells("VehicleType").Value.ToString()
        TextBoxPlateNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PlateNumber").Value.ToString()
        customerIDLabel.Text = DataGridViewCustomerInformation.CurrentRow.Cells("CustomerID").Value.ToString()

        Try
            If e.ColumnIndex = DataGridViewCustomerInformation.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
                If String.IsNullOrEmpty(customerIDLabel.Text) Then
                    MessageBox.Show("Please select a valid customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: Cannot update the status without data. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddCustomerInformation()
    End Sub

    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        activityLogInDashboardService.AddNewCustomer(customerName)
    End Sub

    Public Sub AddCustomerInformation()
        ' <<<< FIX 1: The local declaration has been removed. >>>>
        ' The class-level VehicleList is used automatically here.

        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Then
            MessageBox.Show("Please fill in all required customer fields (Name, Phone, Email).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If VehicleList.Count = 0 Then
            MessageBox.Show("Please add at least one vehicle before saving the customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            customerInformationDatabaseHelper.AddCustomer(
            TextBoxName.Text.Trim(),
            TextBoxNumber.Text,
            TextBoxEmail.Text.Trim(),
            TextBoxAddress.Text.Trim(),
            VehicleList
            )

            ' Clear the class-level list after successful save
            VehicleList.Clear()
            ListViewVehicles.Items.Clear()

        Catch ex As Exception
            MessageBox.Show("Error saving data: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Carwash.PopulateAllTotal()
        LoadDataGridViewCustomerInformation()
        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        NewCustomerActivityLog()
        ClearFields()
    End Sub

    Public Sub LoadDataGridViewCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Private Sub ViewBtn_Click(sender As Object, e As EventArgs) Handles ViewBtn.Click
        ClearFields()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateCustomerInformation()
    End Sub

    Private Sub UpdateCustomerInformation()
        If EditProfileService.ValidateFieldsInEditProfile(TextBoxName.Text, TextBoxVehicle.Text, TextBoxPlateNumber.Text) = True Then
            Return
        End If
        ' NOTE: If you are using a separate CustomerVehicleTable, your UpdateCustomer
        ' method in the helper may need to be revised to handle updating/inserting/deleting
        ' vehicles, not just updating the single-vehicle fields on the CustomersTable.
        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxVehicle.Text, TextBoxPlateNumber.Text)
        ViewCustomerInformation()
        ClearFields()
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        DeleteCustomerInformation()
        ClearFields()
    End Sub

    Public Sub ViewCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Private Sub DeleteCustomerInformation()
        customerInformationDatabaseHelper.DeleteCustomer(DataGridViewCustomerInformation)
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Public Sub ClearFields()
        TextBoxName.Clear()
        TextBoxNumber.Clear()
        TextBoxEmail.Clear()
        TextBoxAddress.Clear()
        TextBoxVehicle.Clear()
        customerIDLabel.Text = ""
        TextBoxPlateNumber.Clear()
        ListViewVehicles.Clear()

        ' Clear the class-level VehicleList when clearing the form
        VehicleList.Clear()
    End Sub

    Public Sub AddButtonAction()
        Dim updateButtonColumn As New DataGridViewButtonColumn With {
            .HeaderText = "Action",
            .Text = "Edit Info",
            .UseColumnTextForButtonValue = True,
            .Name = "actionsColumn"
        }
        DataGridViewCustomerInformation.Columns.Add(updateButtonColumn)
    End Sub

    Private Sub TextBoxPlateNumber_TextChanged(sender As Object, e As EventArgs) Handles TextBoxVehicle.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub AddVehicleBtn_Click(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        ' --- 1. Input Validation ---
        If String.IsNullOrWhiteSpace(TextBoxVehicle.Text) OrElse String.IsNullOrWhiteSpace(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please enter both the Vehicle Type and the Plate Number.", "Missing Vehicle Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' --- 2. Create the New Vehicle Object ---
        Dim vehicleType As String = TextBoxVehicle.Text.Trim()
        Dim plateNumber As String = TextBoxPlateNumber.Text.Trim().ToUpper()

        ' The corrected VehicleService class ensures these values are assigned correctly.
        Dim newVehicle As New VehicleService(vehicleType, plateNumber)

        ' --- 3. Add to the Global List (Now correctly declared at class level) ---
        Me.VehicleList.Add(newVehicle)

        ' --- 4. Update the ListView (To display the new vehicle to the user) ---
        Dim lvi As New ListViewItem(newVehicle.VehicleType)
        lvi.SubItems.Add(newVehicle.PlateNumber)
        ListViewVehicles.Items.Add(lvi)

        ' --- 5. Clear Input Fields for Next Entry ---
        TextBoxVehicle.Clear()
        TextBoxPlateNumber.Clear()
        TextBoxVehicle.Focus()
    End Sub
    Private Sub SetupListView()
        ListViewVehicles.View = View.Details

        ' Show the column headers
        ListViewVehicles.HeaderStyle = ColumnHeaderStyle.Nonclickable

        ' Clear existing columns (good practice)
        ListViewVehicles.Columns.Clear()

        ' Column 1 Header: Plate Number (The main item)
        ' Width is set to 150 pixels
        ListViewVehicles.Columns.Add("Plate Number", 150, HorizontalAlignment.Left)

        ' Column 2 Header: Vehicle Type (A sub-item)
        ' Width is set to 100 pixels
        ListViewVehicles.Columns.Add("Vehicle Type", 100, HorizontalAlignment.Left)

        ' Set aesthetics for a table look
        ListViewVehicles.GridLines = True
        ListViewVehicles.FullRowSelect = True
    End Sub

End Class
