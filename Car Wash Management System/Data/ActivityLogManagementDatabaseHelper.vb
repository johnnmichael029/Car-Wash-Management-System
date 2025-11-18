Imports Microsoft.Data.SqlClient

Public Class ActivityLogManagementDatabaseHelper
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