Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    Public VehicleList As New List(Of VehicleService)
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Dim activityLogInDashboardService As New ActivityLogInDashboardService(constr)
    Private viewCustomerInfo As New ViewCustomerInfo(Me)
    Public customerIDValue As String
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
        SetupListView(ListViewVehicles, 150, 100)
    End Sub
    Private Sub LoadAllQuery()

    End Sub
    Private Sub ChangeHeaderOfDataGridViewCustomerInformation()
        DataGridViewCustomerInformation.Columns("CustomerID").HeaderText = "Customer ID"
        DataGridViewCustomerInformation.Columns(1).HeaderText = "First Name"
        DataGridViewCustomerInformation.Columns(2).HeaderText = "Last Name"
        DataGridViewCustomerInformation.Columns(3).HeaderText = "Phone Number"
        DataGridViewCustomerInformation.Columns(4).HeaderText = "Email"
        DataGridViewCustomerInformation.Columns(5).HeaderText = "City"
        DataGridViewCustomerInformation.Columns(6).HeaderText = "Barangay"
        DataGridViewCustomerInformation.Columns(7).HeaderText = "Registration Date"
        DataGridViewCustomerInformation.Columns(8).HeaderText = "Plate Number"
        DataGridViewCustomerInformation.Columns(9).HeaderText = "Vehicle Type"
    End Sub

    Private Sub LoadListOfCustomerInformation()
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub

    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerInformation.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerInformation.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewCustomerInformation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerInformation.CellContentClick
        If e.ColumnIndex = DataGridViewCustomerInformation.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
            ViewCustomerInfo.Show()
        End If
        If e.RowIndex >= 0 Then
            DataGridViewCustomerInformation.Rows(e.RowIndex).Selected = True
        End If

        ViewCustomerInfo.TextBoxName.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Name").Value.ToString()
        ViewCustomerInfo.TextBoxLastName.Text = DataGridViewCustomerInformation.CurrentRow.Cells("LastName").Value.ToString()
        ViewCustomerInfo.TextBoxNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PhoneNumber").Value.ToString()
        ViewCustomerInfo.TextBoxEmail.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Email").Value.ToString()
        ViewCustomerInfo.TextBoxAddress.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Address").Value.ToString()
        ViewCustomerInfo.TextBoxBarangay.Text = DataGridViewCustomerInformation.CurrentRow.Cells("Barangay").Value.ToString()

        customerIDValue = DataGridViewCustomerInformation.CurrentRow.Cells("CustomerID").Value.ToString()
        viewCustomerInfo.customerIDLabel.Text = customerIDValue

        viewCustomerInfo.DataGridViewCustomerHistory.DataSource = customerInformationDatabaseHelper.GetCustomerTransactionHistory(customerIDValue)
        viewCustomerInfo.LabelContractStatus.Text = customerInformationDatabaseHelper.GetCustomerContractStatus(customerIDValue)
        viewCustomerInfo.LabelTotalSaleMade.Text = customerInformationDatabaseHelper.GetCustomerSalesCount(customerIDValue)
        viewCustomerInfo.LabelRevenue.Text = "₱" & customerInformationDatabaseHelper.GetTotalSalesAmountByCustomer(customerIDValue).ToString("N2")
        Try
            If e.ColumnIndex = DataGridViewCustomerInformation.Columns("actionsColumn").Index Then
                If String.IsNullOrEmpty(ViewCustomerInfo.customerIDLabel.Text) Then
                    MessageBox.Show("Please select a valid customer to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                LoadVehiclesIntoListView(CInt(customerIDValue))
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred during data selection: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub LoadVehiclesIntoListView(customerID As Integer)
        viewCustomerInfo.ListViewVehicles.Items.Clear()
        viewCustomerInfo.VehicleList.Clear()
        Dim vehicles As List(Of VehicleService) = customerInformationDatabaseHelper.GetCustomerVehicles(customerID)

        For Each vehicle As VehicleService In vehicles
            ' 3. Add to the local tracking list (VehicleList)
            viewCustomerInfo.VehicleList.Add(vehicle)

            ' 4. Add to the ListView (Visual Component)
            Dim item As New ListViewItem(vehicle.PlateNumber)
            item.SubItems.Add(vehicle.VehicleType)
            viewCustomerInfo.ListViewVehicles.Items.Add(item)
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

        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Or String.IsNullOrEmpty(TextBoxLastName.Text) Then
            MessageBox.Show("Please fill in all required customer fields (First Name,Last Name, Phone, Email).", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If VehicleList.Count = 0 Then
            MessageBox.Show("Please add at least one vehicle before saving the customer.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            customerInformationDatabaseHelper.AddCustomer(
            TextBoxName.Text.Trim(),
            TextBoxLastName.Text.Trim(),
            TextBoxNumber.Text,
            TextBoxEmail.Text.Trim(),
            TextBoxAddress.Text.Trim(),
            TextBoxBarangay.Text.Trim(),
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
        ViewCustomerInformation()
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
        VehicleList.Clear()
        ListViewVehicles.Items.Clear()
    End Sub

    Public Sub AddButtonAction()
        Dim updateButtonColumn As New DataGridViewButtonColumn With {
            .HeaderText = "Action",
            .Text = "View Info",
            .UseColumnTextForButtonValue = True,
            .Name = "actionsColumn"
        }
        DataGridViewCustomerInformation.Columns.Add(updateButtonColumn)
    End Sub


    Private Sub AddVehicleFunction(listView As ListView)
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
        listView.Items.Add(lvi)
        'ViewVehiclesDetailsInFullScreen.ListViewVehicles.Items.Add(lvi.Clone())

        TextBoxVehicle.Clear()
        TextBoxPlateNumber.Clear()
        TextBoxVehicle.Focus()
    End Sub
    Public Sub SetupListView(listVIew As ListView, widthPlateNumber As Integer, widthVehicleType As Integer)
        listVIew.View = View.Details
        listVIew.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listVIew.Columns.Clear()
        listVIew.Columns.Add("Plate Number", widthPlateNumber, HorizontalAlignment.Left)
        listVIew.Columns.Add("Vehicle Type", widthVehicleType, HorizontalAlignment.Left)
        listVIew.GridLines = True
        listVIew.FullRowSelect = True
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

    Private Sub RemoveVehicleBtn_Click_1(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        RemoveSelectedVehicle()
    End Sub

    Private Sub AddVehicleBtn_Click_1(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        AddVehicleFunction(ListViewVehicles)
    End Sub

    Private Sub FullScreenBtn_Click(sender As Object, e As EventArgs) Handles FullScreenBtn.Click
        ShowPanelDocked.ShowVehiclePanelDocked(PanelVehicleInfo, ListViewVehicles)
    End Sub
   
End Class