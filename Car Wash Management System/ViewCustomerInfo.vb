Public Class ViewCustomerInfo
    Inherits BaseForm
    Private ReadOnly _parentCustomerForm As Object

    Public Sub New(parentForm As Object)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        _parentCustomerForm = parentForm

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

        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub
        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
        customerIDLabel,
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
            CType(_parentCustomerForm, CustomerInformation).ViewCustomerInformation()
        End If

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
        AddVehicleToListView.VehicleList.Clear()
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

    Private Sub DataGridViewCustomerHistory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCustomerHistory.CellContentClick

    End Sub
    Private Sub DataGridViewCustomerHistory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewCustomerHistory.CellFormatting
        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewCustomerHistory)
    End Sub
End Class