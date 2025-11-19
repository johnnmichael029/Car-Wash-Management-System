Public Class EmployeeInformation
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub EmployeeInformation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGridEmployeeInformation()
        ChangeHeaderOfDataGridViewEmployee()
        DataGridViewEmployeeFontStyle()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddEmployeeData()
    End Sub

    Private Sub LoadDataGridEmployeeInformation()
        DataGridViewEmployee.DataSource = EmployeeMangamentDatabaseHelper.ViewEmployeeData()
    End Sub

    Private Sub AddEmployeeData()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                     End Sub


        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
            TextBoxName,
            TextBoxLastName,
            TextBoxPhoneNumber,
            TextBoxAge,
            TextBoxEmail,
            TextBoxAddress,
            TextBoxBarangay,
            ComboBoxGender,
            ComboBoxPosition,
            employeeMangamentDatabaseHelper,
            localErrorHandler
    )
        If success Then

            LoadDataGridEmployeeInformation()
            ClearFields()
        End If
    End Sub

    Private Sub DataGridViewEmployeeFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewEmployee)
    End Sub

    Private Sub ChangeHeaderOfDataGridViewEmployee()
        DataGridViewEmployee.Columns(0).HeaderText = "Employee ID"
        DataGridViewEmployee.Columns(1).HeaderText = "First Name"
        DataGridViewEmployee.Columns(2).HeaderText = "Last Name"
        DataGridViewEmployee.Columns(3).HeaderText = "Phone Number"
        DataGridViewEmployee.Columns(4).HeaderText = "Age"
        DataGridViewEmployee.Columns(5).HeaderText = "Email"
        DataGridViewEmployee.Columns(6).HeaderText = "City"
        DataGridViewEmployee.Columns(7).HeaderText = "Barangay"
        DataGridViewEmployee.Columns(8).HeaderText = "Registration Date"
        DataGridViewEmployee.Columns(9).HeaderText = "Gender"
        DataGridViewEmployee.Columns(10).HeaderText = "Position"
    End Sub

    Private Sub ClearFields()
        TextBoxName.Clear()
        TextBoxLastName.Clear()
        TextBoxPhoneNumber.Clear()
        TextBoxAge.Clear()
        TextBoxEmail.Clear()
        TextBoxAddress.Clear()
        TextBoxBarangay.Clear()
        ComboBoxGender.SelectedIndex = -1
        ComboBoxPosition.SelectedIndex = -1
    End Sub

    Private Sub ViewBtn_Click(sender As Object, e As EventArgs) Handles ViewBtn.Click
        ClearFields()
    End Sub

    Private Sub UpdateBtn_Click(sender As Object, e As EventArgs) Handles UpdateBtn.Click
        UpdateEmployeeData()
    End Sub

    Private Sub UpdateEmployeeData()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
            LabelEmployeeID,
            TextBoxName,
            TextBoxLastName,
            TextBoxPhoneNumber,
            TextBoxAge,
            TextBoxEmail,
            TextBoxAddress,
            TextBoxBarangay,
            ComboBoxGender,
            ComboBoxPosition,
            employeeMangamentDatabaseHelper,
            localErrorHandler
        )
        If success Then
            LoadDataGridEmployeeInformation()
            ClearFields()
        End If
    End Sub

    Private Sub DataGridViewEmployee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployee.CellContentClick
        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewEmployee)


        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Appointment Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        DataGridCellContentClick.GetSelectedRowData(
            DataGridViewEmployee,
            TextBoxName,
            TextBoxLastName,
            TextBoxPhoneNumber,
            TextBoxAge,
            TextBoxEmail,
            TextBoxAddress,
            TextBoxBarangay,
            ComboBoxGender,
            ComboBoxPosition,
            LabelEmployeeID,
            errorHandler
        )
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class