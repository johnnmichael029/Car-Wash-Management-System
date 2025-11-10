Public Class ViewCustomerInfo
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Public VehicleList As New List(Of VehicleService)
    Private ReadOnly _parentCustomerForm As Object
    Public Sub New(parentForm As Object)

        ' This call is required by the designer.
        InitializeComponent()

        _parentCustomerForm = parentForm

        ' Add any initialization after the InitializeComponent() call.
        customerInformationDatabaseHelper = New CustomerInformationDatabaseHelper(constr)
    End Sub
    Private Sub ViewCustomerInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        SetupListView()
        DataGridViewCustomerInformationFontStyle()
    End Sub

    Private Sub SetupListView()
        ListViewVehicles.View = View.Details
        ListViewVehicles.HeaderStyle = ColumnHeaderStyle.Nonclickable
        ListViewVehicles.Columns.Clear()
        ListViewVehicles.Columns.Add("Plate Number", 390, HorizontalAlignment.Left)
        ListViewVehicles.Columns.Add("Vehicle Type", 390, HorizontalAlignment.Left)
        ListViewVehicles.GridLines = True
        ListViewVehicles.FullRowSelect = True
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub UpdateCustomerInformation()
        If EditProfileService.ValidateFieldsInEditProfile(customerIDLabel.Text) = True Then
            Return
        End If
        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxLastName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxBarangay.Text, VehicleList)
        CType(_parentCustomerForm, CustomerInformation).ViewCustomerInformation()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateCustomerInformation()
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


    Private Sub RemoveSelectedVehicle()
        If ListViewVehicles.SelectedItems.Count = 0 Then
            MessageBox.Show("Please select a vehicle from the list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected ListViewItem
        Dim selectedItem As ListViewItem = ListViewVehicles.SelectedItems(0)

        ' Get the Plate Number, which is used as the unique key to match the object in VehicleList
        Dim plateNumberToRemove As String = Trim(selectedItem.Text)

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
        Dim lvi As New ListViewItem(newVehicle.PlateNumber)
        lvi.SubItems.Add(newVehicle.VehicleType)
        ListViewVehicles.Items.Add(lvi)

        TextBoxVehicle.Clear()
        TextBoxPlateNumber.Clear()
        TextBoxVehicle.Focus()
    End Sub

    Private Sub RemoveVehicleBtn_Click(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        RemoveSelectedVehicle()
    End Sub
    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerHistory.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerHistory.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub



End Class