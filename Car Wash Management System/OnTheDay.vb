Imports Microsoft.Data.SqlClient

Public Class OnTheDay
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)
    Private ReadOnly onTheDayManagement As OnTheDayManagement
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        onTheDayManagement = New OnTheDayManagement(constr)

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        ' Check if this is the column we care about ("AppointmentStatus") and
        ' if the row is not new.
        If e.ColumnIndex = Me.DataGridView1.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Confirmed"
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Queued"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "In-progress"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.LightBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Completed"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try


            If e.ColumnIndex = DataGridView1.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                Dim appointmentID As Integer = Convert.ToInt32(row.Cells("OnTheDayID").Value)
                Dim currentStatus As String = row.Cells("AppointmentStatus").Value.ToString()

                Dim customerName As String = row.Cells("CustomerName").Value.ToString()
                Dim customerNewStatus As String = row.Cells("AppointmentStatus").Value.ToString()
                Dim nextStatus As String = ""
                If currentStatus = "Completed" Then
                    Exit Sub
                End If
                Select Case currentStatus

                    Case "Queued"
                        nextStatus = "In-progress"
                        onTheDayManagement.UpdateStatus(appointmentID, nextStatus)

                    Case "In-progress"
                        nextStatus = "Completed"
                        onTheDayManagement.UpdateStatus(appointmentID, nextStatus)

                    Case "Completed"
                        onTheDayManagement.ViewListOfReserved()
                        onTheDayManagement.UpdateStatus(appointmentID, nextStatus)

                        ' If the status is already completed, you might not do anything.
                        Exit Sub
                    Case Else

                        nextStatus = "Queued" ' Default status if not set
                        onTheDayManagement.UpdateStatus(appointmentID, nextStatus)

                End Select

                ' Update the AppointmentStatus cell value directly in the DataGridView
                row.Cells("AppointmentStatus").Value = nextStatus
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred: Cannot update the status without data. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub OnTheDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = onTheDayManagement.ViewListOfReserved()
        AddButtonAction()
    End Sub
    Public Sub AddButtonAction()
        Dim updateButtonColumn As New DataGridViewButtonColumn With {
            .HeaderText = "Action",
            .Text = "Update Status",
            .UseColumnTextForButtonValue = True,
            .Name = "actionsColumn"
        }
        DataGridView1.Columns.Add(updateButtonColumn)
        dashboardManagement.UpdateAppointmentStatus(customerName, customerNewStatus)
    End Sub
    Private Sub actionsColumn_Click(sender As Object, e As EventArgs) Handles actionsColumn.Click
        DataGridView1.DataSource = onTheDayManagement.ViewListOfReserved()
    End Sub
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
Public Class OnTheDayManagement
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
                                         ORDER BY a.AppointmentStatus DESC"
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