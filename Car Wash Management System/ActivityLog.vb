Imports Microsoft.Data.SqlClient
Public Class ActivityLog
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub ActivityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataActivtyLog()
        ChangeHeaderOfActivityLog()
        DataGridViewActivityLogFontStyle()
        LoadActivityLog()
    End Sub
    Private Sub LoadDataActivtyLog()
        DataGridViewActivityLog.DataSource = activityLogManagement.ViewActivityLog()
    End Sub
    Private Sub ChangeHeaderOfActivityLog()
        DataGridViewActivityLog.Columns(0).HeaderText = "Log ID"
        DataGridViewActivityLog.Columns(1).HeaderText = "Timestamp"
        DataGridViewActivityLog.Columns(2).HeaderText = "Action Type"
        DataGridViewActivityLog.Columns(3).HeaderText = "Description"
    End Sub

    Private Sub DataGridViewActivityLog_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewActivityLog.CellContentClick

    End Sub
    Private Sub DataGridViewActivityLogFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewActivityLog)
    End Sub
    Public Sub LoadActivityLog()
        DataGridViewActivityLog.DataSource = activityLogManagement.ViewActivityLog()
        DataGridViewActivityLog.Columns("ActionType").HeaderText = "Action Type"
        DataGridViewActivityLog.Columns("Timestamp").HeaderText = "Timestamp"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
