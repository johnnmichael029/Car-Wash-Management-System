Public Class DataGridFormattingService
    Public Shared Sub DataGridCellFormattingStatus(e As DataGridViewCellFormattingEventArgs, appointmentStatus As String, dataGridView As DataGridView)
        If e.ColumnIndex = dataGridView.Columns(appointmentStatus).Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Confirmed"
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Pending"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Cancelled"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.Salmon
                    e.CellStyle.ForeColor = Color.Black
                Case "No-Show"
                    ' Gray for appointments that were a no-show.
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.Black
                Case "Completed"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
                Case "Queued"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "In-Progress"
                    ' Red for cancelled appointments.
                    e.CellStyle.BackColor = Color.CornflowerBlue ' Used a distinct color to confirm it's working
                    e.CellStyle.ForeColor = Color.White ' Changed to White for better contrast
                Case "Active"
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cancelled"
                    e.CellStyle.BackColor = Color.Salmon
                    e.CellStyle.ForeColor = Color.Black
                Case "Expired"
                    e.CellStyle.BackColor = Color.YellowGreen
                    e.CellStyle.ForeColor = Color.Black
                Case "On-The-Way"
                    e.CellStyle.BackColor = Color.CornflowerBlue
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If

    End Sub

    Public Shared Sub DataGridCellFormattingPaymentMethod(e As DataGridViewCellFormattingEventArgs, paymentMethod As String, dataGridView As DataGridView)
        If e.ColumnIndex = dataGridView.Columns(paymentMethod).Index AndAlso e.RowIndex >= 0 Then
            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Gcash"
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cheque"
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Cash"
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
    End Sub

    Public Shared Sub DataGridCellFormattingFrom(e As DataGridViewCellFormattingEventArgs, paymentMethod As String, dataGridView As DataGridView)
        If e.ColumnIndex = dataGridView.Columns(paymentMethod).Index AndAlso e.RowIndex >= 0 Then
            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Pickup-Sale"
                    e.CellStyle.BackColor = Color.DarkKhaki
                    e.CellStyle.ForeColor = Color.Black
                Case "Contract-Sale"
                    e.CellStyle.BackColor = Color.Chocolate
                    e.CellStyle.ForeColor = Color.Black
                Case "Regular-Sale"
                    e.CellStyle.BackColor = Color.RosyBrown
                    e.CellStyle.ForeColor = Color.Black
                Case "Appointment-Sale"
                    e.CellStyle.BackColor = Color.CornflowerBlue
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If
    End Sub
End Class
