Imports Microsoft.Data.SqlClient
Public Class ActivityLog
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly activityLogManagement As ActivityLogManagement
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        activityLogManagement = New ActivityLogManagement(constr)
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
        DataGridViewActivityLog.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewActivityLog.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Public Sub LoadActivityLog()
        DataGridViewActivityLog.DataSource = activityLogManagement.ViewActivityLog()
        DataGridViewActivityLog.Columns("ActionType").HeaderText = "Action Type"
        DataGridViewActivityLog.Columns("Timestamp").HeaderText = "Timestamp"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
Public Class ActivityLogManagement
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Function ViewActivityLog() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewActivityLogQuery As String = "SELECT * FROM ActivityLogTable ORDER BY LogID DESC"
            Using cmd As New SqlCommand(viewActivityLogQuery, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function
End Class