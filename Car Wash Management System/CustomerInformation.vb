Imports System.Net
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Microsoft.Data.SqlClient
Public Class CustomerInformation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
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
    End Sub
    Private Sub ChangeHeaderOfDataGridViewCustomerInformation()
        DataGridViewCustomerInformation.Columns(0).HeaderText = "Customer ID"
        DataGridViewCustomerInformation.Columns(1).HeaderText = "Name"
        DataGridViewCustomerInformation.Columns(2).HeaderText = "Phone Number"
        DataGridViewCustomerInformation.Columns(3).HeaderText = "Email"
        DataGridViewCustomerInformation.Columns(4).HeaderText = "Address"
        DataGridViewCustomerInformation.Columns(5).HeaderText = "Plate Number"
        DataGridViewCustomerInformation.Columns(6).HeaderText = "Registration Date"
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
        TextBoxPlateNumber.Text = DataGridViewCustomerInformation.CurrentRow.Cells("PlateNumber").Value.ToString()
        customerIDLabel.Text = DataGridViewCustomerInformation.CurrentRow.Cells("CustomerID").Value.ToString()
    End Sub
    Private Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        AddCustomerInformation()
    End Sub
    Private Sub NewCustomerActivityLog()
        Dim customerName As String = TextBoxName.Text
        activityLogInDashboardService.AddNewCustomer(customerName)
    End Sub
    Public Sub AddCustomerInformation()
        If String.IsNullOrEmpty(TextBoxName.Text) Or String.IsNullOrEmpty(TextBoxNumber.Text) Or String.IsNullOrEmpty(TextBoxEmail.Text) Or String.IsNullOrEmpty(TextBoxPlateNumber.Text) Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        customerInformationDatabaseHelper.AddCustomer(TextBoxName.Text.Trim(), TextBoxNumber.Text, TextBoxEmail.Text.Trim(), TextBoxAddress.Text.Trim(), TextBoxPlateNumber.Text.Trim())
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
        ClearFields()
    End Sub
    Private Sub UpdateCustomerInformation()
        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxPlateNumber.Text)
        DataGridViewCustomerInformation.DataSource = customerInformationDatabaseHelper.ViewCustomer()
    End Sub
    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        DeleteCustomerInformation()
        ClearFields()
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
        TextBoxPlateNumber.Clear()
        customerIDLabel.Text = ""
    End Sub
    Public Sub AddButtonAction()
        Dim updateButtonColumn As New DataGridViewButtonColumn With {
            .HeaderText = "Action",
            .Text = "View Details",
            .UseColumnTextForButtonValue = True,
            .Name = "actionsColumn"
        }
        DataGridViewCustomerInformation.Columns.Add(updateButtonColumn)

    End Sub

End Class
