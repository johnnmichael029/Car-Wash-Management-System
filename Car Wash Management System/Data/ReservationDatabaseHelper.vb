Imports Microsoft.Data.SqlClient

Public Class ReservationDatabaseHelper
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString

    End Sub
    Public Function ViewListOfReserved() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewListQuery As String = "SELECT a.AppointmentID As ReservationID, c.Name AS CustomerName, s.ServiceName AS BaseService, sa.ServiceName AS AddonService, a.AppointmentDateTime, a.AppointmentStatus
                                         FROM AppointmentsTable a 
                                         INNER JOIN CustomersTable c ON a.CustomerID = c.CustomerID
                                         INNER JOIN ServicesTable s ON a.ServiceID = s.ServiceID
                                         LEFT JOIN ServicesTable sa ON a.AddonServiceID = sa.ServiceID 
                                         WHERE a.AppointmentStatus = 'Confirmed'
                                         ORDER BY a.AppointmentID DESC"
            Using cmd As New SqlCommand(viewListQuery, con)
                Using adapater As New SqlDataAdapter(cmd)
                    adapater.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

End Class
