Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    Private VehicleList As New List(Of VehicleService)
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Dim activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call
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
        DataGridViewCustomerInformation.Columns(6).HeaderText = "Plate Number"
        DataGridViewCustomerInformation.Columns(7).HeaderText = "Vehicle Type"
    End Sub

    Private Sub LoadListOfCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerInformation.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewCustomerInformation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerInformation.CellContentClick
        If e.RowIndex >= 0 Then
            DataGridViewCustomerInformation.Rows(e.RowIndex).Selected = True
        End If

        TextBoxName.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Name").Value.ToString()
        TextBoxNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PhoneNumber").Value.ToString()
        TextBoxEmail.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Email").Value.ToString()
        TextBoxAddress.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Address").Value.ToString()

        Dim customerIDValue As String = DataGridViewCustomerInformation.CurrentRow.Cells("CustomerID").Value.ToString()
        customerIDLabel.Text = customerIDValue

        Try
            If e.ColumnIndex = DataGridViewCustomerInformation.Columns("actionsColumn").Index Then
                If String.IsNullOrEmpty(customerIDLabel.Text) Then
                    MessageBox.Show("Please select a valid customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                LoadVehiclesIntoListView(CInt(customerIDValue))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during data selection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub LoadVehiclesIntoListView(customerID As Integer)
        ListViewVehicles.Items.Clear()
        Me.VehicleList.Clear()
        Dim vehicles As List(Of VehicleService) = customerInformationDatabaseHelper.GetCustomerVehicles(customerID)

        For Each vehicle As VehicleService In vehicles
            ' 3. Add to the local tracking list (VehicleList)
            Me.VehicleList.Add(vehicle)

            ' 4. Add to the ListView (Visual Component)
            Dim item As New ListViewItem(vehicle.PlateNumber)
            item.SubItems.Add(vehicle.VehicleType)
            ListViewVehicles.Items.Add(item)
        Next
    End Sub


    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddCustomerInformation()
    End Sub

    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        activityLogInDashboardService.AddNewCustomer(customerName)
    End Sub

    Public Sub AddCustomerInformation()

        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Then
            MessageBox.Show("Please fill in all required customer fields (Name, Phone, Email).", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If EditProfileService.ValidateFieldsInEditProfile(customerIDLabel.Text) = True Then
            Return
        End If
        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, VehicleList)
        ViewCustomerInformation()
        ClearFields()
    End Sub

    'Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
    '    DeleteCustomerInformation()
    '    ClearFields()
    'End Sub

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
        VehicleList.Clear()
        ListViewVehicles.Items.Clear()
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

    Private Sub AddVehicleBtn_Click(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        AddVehicleFunction()
    End Sub

    Private Sub AddVehicleFunction()
        If String.IsNullOrWhiteSpace(TextBoxVehicle.Text) OrElse String.IsNullOrWhiteSpace(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please enter both the Vehicle Type and the Plate Number.", "Missing Vehicle Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim vehicleType As String = TextBoxVehicle.Text.Trim()
        Dim plateNumber As String = TextBoxPlateNumber.Text.Trim().ToUpper()
        Dim newVehicle As New VehicleService(vehicleType, plateNumber)

        Me.VehicleList.Add(newVehicle)
        Dim lvi As New ListViewItem(newVehicle.VehicleType)
        lvi.SubItems.Add(newVehicle.PlateNumber)
        ListViewVehicles.Items.Add(lvi)

        TextBoxVehicle.Clear()
        TextBoxPlateNumber.Clear()
        TextBoxVehicle.Focus()
    End Sub
    Private Sub SetupListView()
        ListViewVehicles.View = View.Details
        ListViewVehicles.HeaderStyle = ColumnHeaderStyle.Nonclickable
        ListViewVehicles.Columns.Clear()
        ListViewVehicles.Columns.Add("Plate Number", 150, HorizontalAlignment.Left)
        ListViewVehicles.Columns.Add("Vehicle Type", 100, HorizontalAlignment.Left)
        ListViewVehicles.GridLines = True
        ListViewVehicles.FullRowSelect = True
    End Sub


    Private Sub RemoveVehicleBtn_Click(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        RemoveSelectedVehicle()
    End Sub

    ' --- NEW: Logic to remove the selected vehicle ---
    Private Sub RemoveSelectedVehicle()
        If ListViewVehicles.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a vehicle from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected ListViewItem
        Dim selectedItem As ListViewItem = ListViewVehicles.SelectedItems(0)

        ' Get the Plate Number, which is used as the unique key to match the object in VehicleList
        Dim plateNumberToRemove As String = selectedItem.Text

        ' 1. Remove the vehicle from the local tracking list (VehicleList)
        Dim vehiclesRemovedCount As Integer = Me.VehicleList.RemoveAll(Function(v)
                                                                           Return v.PlateNumber.Equals(plateNumberToRemove, StringComparison.OrdinalIgnoreCase)
                                                                       End Function)

        If vehiclesRemovedCount > 0 Then
            ' 2. Remove the item from the visual ListView control
            ListViewVehicles.Items.Remove(selectedItem)
            MessageBox.Show($"Vehicle with Plate {plateNumberToRemove} removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Could not find the selected vehicle in the internal list. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class
