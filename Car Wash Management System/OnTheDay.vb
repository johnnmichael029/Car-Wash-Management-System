Imports Microsoft.Data.SqlClient

Public Class OnTheDay
    Inherits BaseForm
    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub
    Private Sub OnTheDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfOnTheDay()
        AddButtonAction()
        DataGridViewOnTheDayFontStyle()
        ChangeHeaderOFDataGridVewOnTheDay()
    End Sub
    Private Sub DataGridViewOnTheDay_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewOnTheDay.CellFormatting
        ' Check if this is the column we care about ("AppointmentStatus") and
        ' if the row is not new.
        If e.ColumnIndex = Me.DataGridViewOnTheDay.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Confirmed".Trim
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Queued"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "In-Progress"
                    ' Light blue for in-progress appointments. (Using Cornflower Blue for better visibility)
                    e.CellStyle.BackColor = Color.CornflowerBlue ' Used a distinct color to confirm it's working
                    e.CellStyle.ForeColor = Color.White ' Changed to White for better contrast
                Case "Completed"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
    End Sub
    Private Sub DataGridViewOnTheDay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewOnTheDay.CellContentClick
        Try
            If e.ColumnIndex = DataGridViewOnTheDay.Columns("actionsColumn").Index AndAlso e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = DataGridViewOnTheDay.Rows(e.RowIndex)
                Dim appointmentID As Integer = Convert.ToInt32(row.Cells("OnTheDayID").Value)
                Dim currentStatus As String = row.Cells("AppointmentStatus").Value.ToString().Trim()
                Dim customerName As String = row.Cells("CustomerName").Value.ToString()

                Dim nextStatus As String = String.Empty ' Initialize nextStatus

                If currentStatus = "Completed" Then
                    Exit Sub ' Do nothing if already completed
                End If

                Select Case currentStatus
                    Case "Confirmed"
                        ' Confirmed is the start point, moves to Queued if not already there
                        nextStatus = "Queued"
                    Case "Queued"
                        nextStatus = "In-Progress"
                    Case "In-Progress"
                        nextStatus = "Completed"
                    Case Else
                        ' Handle unknown or initial states by defaulting to Queued
                        nextStatus = "Queued"
                End Select


                If nextStatus <> String.Empty Then
                    ' 1. Update the database
                    onTheDayDatabaseHelper.UpdateStatusInOTD(appointmentID, nextStatus)

                    ' 2. Update the DataGridView cell value directly 
                    row.Cells("AppointmentStatus").Value = nextStatus

                    ' 3. Force the DataGridView to redraw the cell (which triggers CellFormatting)
                    DataGridViewOnTheDay.InvalidateRow(e.RowIndex)

                    ' 4. Handle additional actions (notifications, logging)
                    activityLogInDashboardService.RecordActivity(customerName, nextStatus)

                    Select Case nextStatus
                        Case "In-progress"
                            Carwash.NotificationLabel.Text = "Appointment In-progress"
                        Case "Completed"
                            Carwash.NotificationLabel.Text = "Appointment Completed"
                            Carwash.PopulateAllTotal()
                        Case "Queued"
                            Carwash.NotificationLabel.Text = "Appointment Queued"
                    End Select

                    Carwash.ShowNotification()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        End Try
    End Sub
    Private Sub ChangeHeaderOFDataGridVewOnTheDay()
        DataGridViewOnTheDay.Columns(0).HeaderText = "OTD ID"
        DataGridViewOnTheDay.Columns(1).HeaderText = "Customer Name"
        DataGridViewOnTheDay.Columns(2).HeaderText = "Base Service"
        DataGridViewOnTheDay.Columns(3).HeaderText = "Addon Service"
        DataGridViewOnTheDay.Columns(4).HeaderText = "Date & Time"
        DataGridViewOnTheDay.Columns(5).HeaderText = "Appointment Status"
    End Sub

    Private Sub LoadListOfOnTheDay()
        DataGridViewOnTheDay.DataSource = onTheDayDatabaseHelper.ViewListOfReserved()
    End Sub
    Private Sub DataGridViewOnTheDayFontStyle()
        DataGridViewOnTheDay.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewOnTheDay.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Public Sub AddButtonAction()
        Dim updateButtonColumn As New DataGridViewButtonColumn With {
            .HeaderText = "Action",
            .Text = "Update Status",
            .UseColumnTextForButtonValue = True,
            .Name = "actionsColumn"
        }
        DataGridViewOnTheDay.Columns.Add(updateButtonColumn)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
