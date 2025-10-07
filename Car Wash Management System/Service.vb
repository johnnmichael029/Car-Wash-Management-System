Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Service
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Dim activityLogInDashboardService As ActivityLogInDashboardService
    Private ReadOnly serviceDatabaseHelper As ServiceDatabaseHelper
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        serviceDatabaseHelper = New ServiceDatabaseHelper(constr)
        activityLogInDashboardService = New ActivityLogInDashboardService(constr)
    End Sub
    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfService()
        DataGridViewServiceFontStyle()
        ChangeHeaderOfDataGridViewService()
        CheckIfAdmin()
    End Sub

    Private Sub ChangeHeaderOfDataGridViewService()
        DataGridViewService.Columns(0).HeaderText = "Service ID"
        DataGridViewService.Columns(1).HeaderText = "Service Name"
        DataGridViewService.Columns(2).HeaderText = "Addon"
        DataGridViewService.Columns(3).HeaderText = "Description"
        DataGridViewService.Columns(4).HeaderText = "Price"
    End Sub
    Private Sub LoadListOfService()
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
    End Sub
    Private Sub DataGridViewService_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewService.CellContentClick
        TextBoxServiceName.Text = DataGridViewService.CurrentRow.Cells("ServiceName").Value.ToString()
        TextBoxDescription.Text = DataGridViewService.CurrentRow.Cells("Description").Value.ToString()
        TextBoxPrice.Text = DataGridViewService.CurrentRow.Cells("Price").Value.ToString()
        LabelServiceID.Text = DataGridViewService.CurrentRow.Cells("ServiceID").Value.ToString()
    End Sub

    Private Sub DataGridViewServiceFontStyle()
        DataGridViewService.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewService.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Public Sub ClearFields()
        TextBoxServiceName.Clear()
        TextBoxDescription.Clear()
        TextBoxPrice.Clear()
        LabelServiceID.Text = ""
        CheckBoxAddon.Checked = False
    End Sub

    Private Sub AddServiceBtn_Click(sender As Object, e As EventArgs) Handles AddServiceBtn.Click
        AddService()
        LoadListOfServiceFromDataGridViewService()
    End Sub
    Private Sub AddService()
        If String.IsNullOrEmpty(TextBoxServiceName.Text) Or String.IsNullOrEmpty(TextBoxPrice.Text) Then
            MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        serviceDatabaseHelper.AddService(TextBoxServiceName.Text, TextBoxDescription.Text, TextBoxPrice.Text, LabelServiceID.Text, CheckBoxAddon.Checked)
        MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        AddNewServiceFromActivityLog()
        ClearFields()
    End Sub
    Private Sub LoadListOfServiceFromDataGridViewService()
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
    End Sub
    Public Sub AddNewServiceFromActivityLog()
        activityLogInDashboardService.AddNewService(TextBoxServiceName.Text)
    End Sub
    Private Sub UpdateServiceBtn_Click(sender As Object, e As EventArgs) Handles UpdateServiceBtn.Click
        serviceDatabaseHelper.UpdateService(TextBoxServiceName.Text, TextBoxDescription.Text, TextBoxPrice.Text, LabelServiceID.Text, CheckBoxAddon.Checked)
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
        ClearFields()
    End Sub

    Private Sub DeleteServiceBtn_Click(sender As Object, e As EventArgs) Handles DeleteServiceBtn.Click
        serviceDatabaseHelper.DeleteService(LabelServiceID.Text)
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
        ClearFields()

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
    Private Sub CheckIfAdmin()
        Dim username As String = Login.LabelWelcomeUsers(Carwash.Label3.Text)
        If Not serviceDatabaseHelper.CheckIfAdmin(username) Then
            LabelIsAdmin.Text = "Only Admin can add, update, and delete services."
            AddServiceBtn.Enabled = False
            UpdateServiceBtn.Enabled = False
            DeleteServiceBtn.Enabled = False
        Else
            LabelIsAdmin.Text = ""
            AddServiceBtn.Enabled = True
            UpdateServiceBtn.Enabled = True
            DeleteServiceBtn.Enabled = True
        End If
    End Sub
End Class
