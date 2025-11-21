Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class Service
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfServiceFromDataGridViewService()
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

    Private Sub DataGridViewService_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewService.CellContentClick
        DataGridCellContentClick.HighlightSelectedRow(e, DataGridViewService)
        DataGridCellContentClick.GetSelectedRowData(
            TextBoxServiceName,
            CheckBoxAddon,
            TextBoxDescription,
            TextBoxPrice,
            LabelServiceID,
            DataGridViewService)
    End Sub

    Private Sub DataGridViewServiceFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewService)
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
        Dim errorHandler As Action(Of String) = Sub(message)
                                                    ' This is the custom error logic: display the message in a modal.
                                                    MessageBox.Show(message, "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                End Sub
        Dim success As Boolean = AddButtonFunction.AddDataToDatabase(
                TextBoxServiceName,
                TextBoxDescription,
                TextBoxPrice,
                LabelServiceID,
                CheckBoxAddon,
                serviceDatabaseHelper,
                errorHandler
            )
        If success Then
            MessageBox.Show("Service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            AddNewServiceFromActivityLog()
            ClearFields()
        End If

    End Sub

    Private Sub LoadListOfServiceFromDataGridViewService()
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
    End Sub

    Public Sub AddNewServiceFromActivityLog()
        activityLogInDashboardService.AddNewService(TextBoxServiceName.Text)
    End Sub

    Private Sub UpdateServiceBtn_Click(sender As Object, e As EventArgs) Handles UpdateServiceBtn.Click
        UpdateService()
    End Sub

    Private Sub UpdateService()
        Dim localErrorHandler As Action(Of String) = Sub(message)
                                                         MessageBox.Show(message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                                     End Sub

        Dim success As Boolean = UpdateButtonFunctiion.UpdateDataToDatabase(
            TextBoxServiceName,
            TextBoxDescription,
            TextBoxPrice,
            LabelServiceID,
            CheckBoxAddon,
            serviceDatabaseHelper,
            localErrorHandler
        )

        If success Then
            LoadListOfServiceFromDataGridViewService()
            ClearFields() ' Assuming this is a local function to clear form controls
        End If
    End Sub

    Private Sub DeleteServiceBtn_Click(sender As Object, e As EventArgs) Handles DeleteServiceBtn.Click
        serviceDatabaseHelper.DeleteService(LabelServiceID.Text)
        DataGridViewService.DataSource = serviceDatabaseHelper.ViewService()
        ClearFields()

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

    Private Sub LabelIsAdmin_Click(sender As Object, e As EventArgs) Handles LabelIsAdmin.Click

    End Sub
End Class
