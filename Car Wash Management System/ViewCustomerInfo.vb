Public Class ViewCustomerInfo
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
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
        SetupListViewService.SetupListViewForVehicles(ListViewVehicles, 60, 360, 360)
        DataGridViewCustomerInformationFontStyle()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        CType(_parentCustomerForm, CustomerInformation).ClearFields()
    End Sub

    Private Sub UpdateCustomerInformation()
        If EditProfileService.ValidateFieldsInEditProfile(customerIDLabel.Text) = True Then
            Return
        End If

        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxLastName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxBarangay.Text, AddVehicleToListView.VehicleList)
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
        CustomerInformation.VehicleList.Clear()
        ListViewVehicles.Items.Clear()
    End Sub

    Private Sub AddVehicleBtn_Click(sender As Object, e As EventArgs) Handles AddVehicleBtn.Click
        AddVehicleToListView.AddVehicleFunction(ListViewVehicles, TextBoxPlateNumber, TextBoxVehicle)
    End Sub
    Private Sub RemoveVehicleBtn_Click(sender As Object, e As EventArgs) Handles RemoveVehicleBtn.Click
        AddVehicleToListView.RemoveSelectedVehicle(ListViewVehicles)
    End Sub
    Private Sub DataGridViewCustomerInformationFontStyle()
        DataGridViewCustomerHistory.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewCustomerHistory.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

End Class