Imports Microsoft.Data.SqlClient
Public Class OnTheDayDatabaseHelper
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString

    End Sub
    Public Function ViewListOfReserved() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim viewListQuery As String = "SELECT " &
                "AST.AppointmentServiceID As OnTheDayID, " &
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
            "WHERE AST.AppointmentStatus IN ('Confirmed', 'Queued', 'In-progress')" &
            "AND CAST(AppointmentDateTime AS DATE) = CAST(GETDATE() AS DATE) " &
            "ORDER BY AST.AppointmentServiceID DESC"

            Using cmd As New SqlCommand(viewListQuery, con)
                Using adapater As New SqlDataAdapter(cmd)
                    adapater.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Sub UpdateStatusInOTD(otdID As Integer, newStatus As String)
        Using con As New SqlConnection(constr)
            Dim tran As SqlTransaction = Nothing
            Dim parentAppointmentID As Integer = 0

            Try
                con.Open()
                tran = con.BeginTransaction() ' Start the transaction

                ' 1. Update the status of the specific service line item (OTD ID)
                Dim UpdateOTDStatusQuery As String = "UPDATE AppointmentServiceTable " &
                                                     "SET AppointmentStatus = @NewStatus " &
                                                     "WHERE AppointmentServiceID = @OnTheDayID"

                Using cmdOTD As New SqlCommand(UpdateOTDStatusQuery, con, tran)
                    cmdOTD.Parameters.AddWithValue("@NewStatus", newStatus)
                    cmdOTD.Parameters.AddWithValue("@OnTheDayID", otdID)
                    cmdOTD.ExecuteNonQuery()
                End Using

                ' 2. Retrieve the parent AppointmentID from the service line
                Dim GetParentIDQuery As String = "SELECT AppointmentID FROM AppointmentServiceTable WHERE AppointmentServiceID = @OnTheDayID"
                Using cmdGetID As New SqlCommand(GetParentIDQuery, con, tran)
                    cmdGetID.Parameters.AddWithValue("@OnTheDayID", otdID)

                    Dim result As Object = cmdGetID.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        parentAppointmentID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Could not find parent AppointmentID for OTD ID: " & otdID)
                    End If
                End Using

                ' 3. Conditional Parent Appointment Status Update (THE FIX)
                If parentAppointmentID > 0 Then
                    ' Check if ANY service item for this parent appointment is NOT "Completed"
                    Dim CheckPendingServicesQuery As String =
                        "SELECT COUNT(*) FROM AppointmentServiceTable " &
                        "WHERE AppointmentID = @AppointmentID AND AppointmentStatus <> 'Completed'"

                    Using cmdCheckPending As New SqlCommand(CheckPendingServicesQuery, con, tran)
                        cmdCheckPending.Parameters.AddWithValue("@AppointmentID", parentAppointmentID)
                        Dim pendingCount As Integer = Convert.ToInt32(cmdCheckPending.ExecuteScalar())

                        If pendingCount = 0 Then
                            ' Only update the parent AppointmentStatus to the newStatus if ALL services are completed (count is 0)
                            ' We assume the only time we want to update the parent status is to mark it as Completed.
                            Dim UpdateAppointmentStatusQuery As String = "UPDATE AppointmentsTable " &
                                                                         "SET AppointmentStatus = @NewStatus " &
                                                                         "WHERE AppointmentID = @AppointmentID"

                            Using cmdParent As New SqlCommand(UpdateAppointmentStatusQuery, con, tran)
                                cmdParent.Parameters.AddWithValue("@NewStatus", newStatus)
                                cmdParent.Parameters.AddWithValue("@AppointmentID", parentAppointmentID)
                                cmdParent.ExecuteNonQuery()
                            End Using
                        Else
                            ' IMPORTANT: If newStatus is 'Completed' and there are still pending items, 
                            ' we must prevent the main AppointmentStatus from being set to 'Completed'.
                            ' We will set the parent status to something like 'In Progress' or 'Partially Completed' 
                            ' if the newStatus is "Completed" but others are still pending/confirmed.
                            If newStatus = "Completed" Then
                                Dim UpdateAppointmentStatusToInProgress As String = "UPDATE AppointmentsTable " &
                                                                                    "SET AppointmentStatus = 'In-Progress' " &
                                                                                    "WHERE AppointmentID = @AppointmentID AND AppointmentStatus <> 'In Progress'"
                                Using cmdParentInProgress As New SqlCommand(UpdateAppointmentStatusToInProgress, con, tran)
                                    cmdParentInProgress.Parameters.AddWithValue("@AppointmentID", parentAppointmentID)
                                    cmdParentInProgress.ExecuteNonQuery()
                                End Using
                            End If
                        End If
                    End Using
                End If

                ' Commit the transaction if all steps succeeded
                tran.Commit()

            Catch ex As Exception
                ' Rollback the transaction if any step failed
                If tran IsNot Nothing Then
                    Try
                        tran.Rollback()
                    Catch rbEx As Exception
                        Console.WriteLine("Rollback failed: " & rbEx.Message)
                    End Try
                End If
                Console.WriteLine("Error updating status: " & ex.Message)
                ' Display error to the user (assuming this is part of your application's flow)
                MessageBox.Show("Error updating status: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Sub
End Class
