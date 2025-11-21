Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Inherits BaseForm
    Private ReadOnly viewCustomerInfo As ViewCustomerInfo
    Public customerIDValue As String
    Public nextServiceID As Integer = 1

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        viewCustomerInfo = New ViewCustomerInfo(Me)

        ' Add any initialization after the InitializeComponent() call
    End Sub
    Private Sub CustomerInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfCustomerInformation()
        ChangeHeaderOfDataGridViewCustomerInformation()
        DataGridViewCustomerInformationFontStyle()
        AddButtonAction()
        SetupListViewService.SetupListViewForVehicles(ListViewVehicles, 30, 135, 85)
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
        DataGridFontStyleService.DataGridFontStyle(DataGridViewCustomerInformation)
    End Sub

    Private sub DataGridViewCustomerInformation_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewCustomerInformation.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub
    Private Sub DataGridViewCustomerInformation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerInformation.CellContentClick

        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewCustomerInformation)

        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub

        If e.ColumnIndex = DataGridViewCustomerInformation.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
            viewCustomerInfo.Show()
            viewCustomerInfo.TextBoxPlateNumber.Clear()
            viewCustomerInfo.TextBoxVehicle.Clear()
        End If
        DataGridCellContentClick.GetSelectedRowData(
                DataGridViewCustomerInformation,
                viewCustomerInfo.TextBoxName,
                viewCustomerInfo.TextBoxLastName,
                viewCustomerInfo.TextBoxNumber,
                viewCustomerInfo.TextBoxEmail,
                viewCustomerInfo.TextBoxAddress,
                viewCustomerInfo.TextBoxBarangay,
                viewCustomerInfo.customerIDLabel,
                viewCustomerInfo.ListViewVehicles,
                viewCustomerInfo.DataGridViewCustomerHistory,
                viewCustomerInfo.LabelContractStatus,
                viewCustomerInfo.LabelTotalSaleMade,
                viewCustomerInfo.LabelRevenue,
                customerInformationDatabaseHelper,
                errorHandler)

    End Sub

    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddCustomerInformation()
    End Sub

    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        activityLogInDashboardService.AddNewCustomer(customerName)
    End Sub

    Public Sub AddCustomerInformation()

        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                     End Sub

        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
        TextBoxName,
        TextBoxLastName,
        TextBoxNumber,
        TextBoxEmail,
        TextBoxAddress,
        TextBoxBarangay,
        customerInformationDatabaseHelper,
        localErrorHandler
    )

        If success Then
            Carwash.PopulateAllTotal()
            LoadDataGridViewCustomerInformation()

            NewCustomerActivityLog()
            ClearFields()
        End If
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

    'Private Sub DeleteCustomerInformation()
    '    customerInformationDatabaseHelper.DeleteCustomer(DataGridViewCustomerInformation)
    '    DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    'End Sub

    Public Sub ClearFields()
        TextBoxName.Clear()
        TextBoxLastName.Clear()
        TextBoxNumber.Clear()
        TextBoxEmail.Clear()
        TextBoxAddress.Clear()
        TextBoxVehicle.Clear()
        customerIDLabel.Text = ""
        TextBoxPlateNumber.Clear()
        ListViewVehicles.Items.Clear()
        AddVehicleToListView.nextServiceID = 1
        AddVehicleToListView.VehicleList.Clear()
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


    Public Sub AddVehicleFunction(listView As ListView, textBoxVehicle As TextBox, textBoxPlateNumber As TextBox)
        If String.IsNullOrWhiteSpace(textBoxVehicle.Text) OrElse String.IsNullOrWhiteSpace(textBoxPlateNumber.Text) Then
            MessageBox.Show("Please enter both the Vehicle Type and the Plate Number.", "Missing Vehicle Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' check if the current ListView does have any data if not then ID will be 1 else increment by 1
        ' 1. Get the current ID and increment the counter
        If listView.Items.Count = 0 Then
            nextServiceID = 1
        ElseIf listView.Items.Count > 0 Then
            nextServiceID = listView.Items.Count + 1

        End If
        Dim currentID As Integer = nextServiceID
        nextServiceID += 1 ' Increment the counter for the next line item

        Dim plateNumber As String = textBoxPlateNumber.Text.Trim()
        Dim vehicleType As String = textBoxVehicle.Text.Trim()

        ' 2. Create the new service, passing the current ID
        Dim newVehicle As New VehicleService(currentID, plateNumber, vehicleType)

        AddVehicleToListView.VehicleList.Add(newVehicle)

        ' 3. Add the ID as the FIRST column in the ListView
        Dim lvi As New ListViewItem(newVehicle.ID.ToString())
        lvi.SubItems.Add(newVehicle.VehicleType)
        lvi.SubItems.Add(newVehicle.PlateNumber)
        listView.Items.Add(lvi)

        textBoxVehicle.Clear()
        textBoxPlateNumber.Clear()
        textBoxVehicle.Focus()
    End Sub

    ' --- NEW: Logic to remove the selected vehicle ---
    Public Sub RemoveSelectedVehicle(listView As ListView)
        If listView.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a vehicle from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected ListViewItem
        Dim selectedItem As ListViewItem = listView.SelectedItems(0)

        ' Get the Plate Number, which is used as the unique key to match the object in VehicleList
        Dim selectedIndex As Integer = selectedItem.Index

        If selectedIndex >= 0 AndAlso selectedIndex < AddVehicleToListView.VehicleList.Count Then

            ' 2. Remove the service object from the internal list based on index
            AddVehicleToListView.VehicleList.RemoveAt(selectedIndex)

            ' 3. Remove the item from the visual ListView control
            ' (This step is technically optional since we clear and re-add below, but good practice)
            listView.Items.Remove(selectedItem)

            ' 4. After removing, we must re-load and re-number the entire list
            ' This ensures the IDs (1, 2, 3...) remain sequential without gaps.

            ' Get the current list of remaining services
            ' Using ToList() creates a copy, so we can manipulate the original SaleServiceList safely below.
            Dim remainingServices As List(Of VehicleService) = AddVehicleToListView.VehicleList.ToList()

            ' Clear the UI and internal list (before re-adding)
            listView.Items.Clear()
            AddVehicleToListView.VehicleList.Clear() ' Clear the internal list so we can rebuild it with the same items

            ' Now, iterate through the remaining items and re-add them with new sequential IDs
            Dim listItemIDCounter As Integer = 1
            For Each vehicle As VehicleService In remainingServices
                AddVehicleToListView.VehicleList.Add(vehicle) ' Re-add to the internal list

                ' Create the ListView item with the new sequential ID
                Dim lvi As New ListViewItem(listItemIDCounter.ToString())
                lvi.SubItems.Add(vehicle.VehicleType)
                lvi.SubItems.Add(vehicle.PlateNumber)
                listView.Items.Add(lvi)

                listItemIDCounter += 1
            Next

            ' 5. Update the global counter for new additions
            Me.nextServiceID = listItemIDCounter
            MessageBox.Show($"Vehicle with Plate {selectedItem} removed successfully from the list.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"Could not find the selected vehicle in the internal list. Please try again. your want to remove from the ID is{selectedItem}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If
    End Sub

    Private Sub RemoveVehicleBtn_Click_1(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        AddVehicleToListView.RemoveSelectedVehicle(ListViewVehicles)
    End Sub

    Private Sub AddVehicleBtn_Click_1(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        AddVehicleToListView.AddVehicleFunction(ListViewVehicles, TextBoxPlateNumber, TextBoxVehicle)
    End Sub

    Private Sub FullScreenBtn_Click(sender As Object, e As EventArgs) Handles FullScreenBtn.Click
        ShowPanelDocked.ShowVehiclePanelDocked(PanelVehicleInfo, ListViewVehicles)
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunction(TextBoxSearchBar, DataGridViewCustomerInformation)
    End Sub
    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub

End Class