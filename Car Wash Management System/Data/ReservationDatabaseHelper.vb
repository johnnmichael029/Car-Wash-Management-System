Imports Microsoft.Data.SqlClient

Public Class ReservationDatabaseHelper

    Private Shared constr
    Public Sub New(connectionString As String)
        constr = connectionString

    End Sub
    Public Function ViewListOfReserved() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewListQuery As String =
            "SELECT " &
                "AST.AppointmentID As ReservationID, " &
                "c.Name + ' ' + c.LastName As CustomerName, " &
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

    Public Function UpdateStatusOfAppointment()
        Dim rowsAffected As Integer = 0
        Dim query As String = "UPDATE AppointmentsTable " &
                              "SET AppointmentStatus = 'Completed' " &
                              "WHERE AppointmentDateTime < CONVERT(DATE, GETDATE()) " & ' <-- 12:00 AM of current day
                              "AND AppointmentStatus IN ('Confirmed' , 'In-Progress')"
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error updating expired contracts: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowsAffected = -1
                End Try
            End Using
        End Using
        Return rowsAffected
    End Function
    Public Function UpdateStatusOfAppointmentServiceTable() As Integer
        Dim rowsAffected As Integer = 0

        ' Correct SQL Server UPDATE...FROM syntax:
        Dim query As String = "UPDATE  ast  " &
                              "SET ast.AppointmentStatus = 'Completed' " &
                              "FROM AppointmentServiceTable ast " & ' Alias 'ast' for the table being updated
                              "INNER JOIN AppointmentsTable a ON ast.AppointmentID = a.AppointmentID " &
                              "WHERE a.AppointmentDateTime < CONVERT(DATE, GETDATE()) " &
                              "AND ast.AppointmentStatus = 'Confirmed'"

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    ' Log the error and notify the user
                    MessageBox.Show("Error updating expired contracts: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    rowsAffected = -1
                End Try
            End Using
        End Using
        Return rowsAffected
    End Function

End Class
