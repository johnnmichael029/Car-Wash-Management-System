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
            ' Declare variables for transaction and AppointmentID
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

                    ' ExecuteScalar retrieves a single value (the AppointmentID)
                    Dim result As Object = cmdGetID.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        parentAppointmentID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Could not find parent AppointmentID for OTD ID: " & otdID)
                    End If
                End Using

                ' 3. Update the status of the parent AppointmentsTable using the retrieved ID
                Dim UpdateAppointmentStatusQuery As String = "UPDATE AppointmentsTable " &
                                                         "SET AppointmentStatus = @NewStatus " &
                                                         "WHERE AppointmentID = @AppointmentID"

                Using cmdParent As New SqlCommand(UpdateAppointmentStatusQuery, con, tran)
                    cmdParent.Parameters.AddWithValue("@NewStatus", newStatus)
                    cmdParent.Parameters.AddWithValue("@AppointmentID", parentAppointmentID)
                    cmdParent.ExecuteNonQuery()
                End Using

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

            Finally
                If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try
        End Using
    End Sub

    'Public Sub AddSalesInSalesHistoryTableWhenCompleted(salesID As Integer, status As String)
    '    If status <> "Completed" Then
    '        ' Only proceed if the status is "Completed"
    '        Return
    '    End If
    '    Using con As New SqlConnection(constr)
    '        Try
    '            con.Open()
    '            ' Insert into SalesHistoryTable
    '            Dim insertSalesHistoryQuery As String = "INSERT INTO SalesHistoryTable (
    '                    CustomerID,
    '                    ServiceID,
    '                    AddonServiceID,
    '                    SaleDate,
    '                    PaymentMethod,
    '                    TotalPrice
    '                )
    '                SELECT
    '                    a.CustomerID, -- Assumes you want to record the CustomerID
    '                    d.ServiceID, -- Assumes you want to record the ServiceID
    '                    a.AddonServiceID, -- Assumes you want to record the AddonServiceID
    '                    GETDATE(), -- Set the sale date to the current date and time
    '                    a.PaymentMethod, -- A clear payment method for automated sales
    '              a.Price
    '                FROM
    '                    AppointmentsTable AS a
    '                INNER JOIN
    '                    AppointmentServiceTable AS d ON a.AppointmentID = d.AppointmentID
    '                LEFT JOIN
    '                    AppointmentServiceTable As ad_sv ON a.AppointmentID = ad_sv.AppointmentID
    '                WHERE
    '                    a.AppointmentStatus = 'Completed'
    '                    AND d.AppointmentStatus <> 'Completed'"




    '            Using cmd As New SqlCommand(insertSalesHistoryQuery, con)
    '                cmd.Parameters.AddWithValue("@SaleID", salesID)
    '                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now) ' Assuming current date as sale date
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        Catch ex As Exception
    '            Console.WriteLine("Error adding to sales history: " & ex.Message)
    '        Finally
    '            con.Close()
    '        End Try
    '    End Using

    'End Sub
    Public Sub UpdateStatusInAppointment(AppointmentID As Integer, newStatus As String)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim UpdateAppointmentStatusQuery As String = "UPDATE AppointmentsTable " &
                                             "SET AppointmentStatus = @NewStatus " &
                                             "WHERE AppointmentID = @AppointmentID"
                Using cnd As New SqlCommand(UpdateAppointmentStatusQuery, con)
                    cnd.Parameters.AddWithValue("@NewStatus", newStatus)
                    cnd.Parameters.AddWithValue("@AppointmentID", AppointmentID)
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
