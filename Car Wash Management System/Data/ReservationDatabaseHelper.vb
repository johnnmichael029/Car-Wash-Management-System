Imports Microsoft.Data.SqlClient

Public Class ReservationDatabaseHelper
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString

    End Sub
    Public Function ViewListOfReserved() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewListQuery As String =
            "SELECT " &
                "AST.AppointmentID As ReservationID, " &
                "c.Name As CustomerName, " &
                "sv_base.ServiceName As BaseService, " &
                "sv_addon.ServiceName As AddonService, " &
                "a.AppointmentDateTime As DateTime, " &
                "AST.AppointmentStatus As AppointmentStatus " &
            "FROM AppointmentServiceTable AST " &
            "INNER JOIN CustomersTable c ON AST.CustomerID = c.CustomerID " &
            "INNER JOIN AppointmentsTable a ON AST.AppointmentID = a.AppointmentID " &
            "INNER JOIN ServicesTable sv_base ON AST.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON AST.AddonServiceID = sv_addon.ServiceID " &
            "WHERE AST.AppointmentStatus = 'Confirmed' " &
            "ORDER BY a.AppointmentID DESC"

            Using cmd As New SqlCommand(viewListQuery, con)
                Using adapater As New SqlDataAdapter(cmd)
                    adapater.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

End Class
