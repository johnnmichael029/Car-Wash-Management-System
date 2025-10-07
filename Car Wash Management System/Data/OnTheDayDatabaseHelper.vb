Imports Microsoft.Data.SqlClient
Public Class OnTheDayDatabaseHelper
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString

    End Sub
    Public Function ViewListOfReserved() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewListQuery As String = "SELECT a.AppointmentID As OnTheDayID, c.Name AS CustomerName, s.ServiceName AS BaseService, sa.ServiceName AS AddonService, a.AppointmentDateTime, a.AppointmentStatus
                                         FROM AppointmentsTable a 
                                         INNER JOIN CustomersTable c ON a.CustomerID = c.CustomerID
                                         INNER JOIN ServicesTable s ON a.ServiceID = s.ServiceID
                                         LEFT JOIN ServicesTable sa ON a.AddonServiceID = sa.ServiceID 
                                         WHERE a.AppointmentStatus IN ('Confirmed', 'Queued', 'In-progress')
                                         ORDER BY a.AppointmentID DESC"
            Using cmd As New SqlCommand(viewListQuery, con)
                Using adapater As New SqlDataAdapter(cmd)
                    adapater.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Sub UpdateStatus(appointmentID As Integer, newStatus As String)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim UpdateStatusQuery As String = "UPDATE AppointmentsTable SET AppointmentStatus = @NewStatus WHERE AppointmentID = @AppointmentID"
                Using cnd As New SqlCommand(UpdateStatusQuery, con)
                    cnd.Parameters.AddWithValue("@NewStatus", newStatus)
                    cnd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cnd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Console.WriteLine("Error updating status: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
End Class
