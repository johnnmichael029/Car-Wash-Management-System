Imports Microsoft.Data.SqlClient

Public Class ListofActivityLogInDashboardDatabaseHelper
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Sub LogActivity(action As String, description As String)
        Try
            Using conn As New SqlConnection(constr)
                conn.Open()
                Dim insertActivityLogQuery As String = "INSERT INTO ActivityLogTable (ActionType, Description, Timestamp) VALUES (@action, @description, @timestamp)"
                Using cmd As New SqlCommand(insertActivityLogQuery, conn)
                    cmd.Parameters.AddWithValue("@action", action)
                    cmd.Parameters.AddWithValue("@description", description)
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception

            MessageBox.Show("Error logging activity: " & ex.Message)
        End Try
    End Sub
End Class
