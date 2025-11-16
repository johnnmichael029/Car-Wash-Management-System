Imports Microsoft.Data.SqlClient

Public Class Reservation
    Inherits BaseForm

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListOfReserved()
        DataGridViewListOfReservedFontStyle()
        ChangeHeaderOfDataGridViewListOfReserved()
        ReservationDatabaseHelper.UpdateStatusOfAppointment()
        ReservationDatabaseHelper.UpdateStatusOfAppointmentServiceTable()
    End Sub
    Private Sub DataGridViewListOfReservedFontStyle()
        DataGridViewListOfReservation.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewListOfReservation.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
    Private Sub LoadListOfReserved()
        DataGridViewListOfReservation.DataSource = ReservationDatabaseHelper.ViewListOfReserved()
    End Sub
    Private Sub DataGridViewListOfReserved_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewListOfReservation.CellFormatting
        ' Check if this is the column we care about ("AppointmentStatus") and
        ' if the row is not new.
        If e.ColumnIndex = Me.DataGridViewListOfReservation.Columns(5).Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim()
            If status = "Confirmed" Then
                e.CellStyle.BackColor = Color.LightSkyBlue
                e.CellStyle.ForeColor = Color.Black
            End If
        End If
    End Sub
    Private Sub ChangeHeaderOfDataGridViewListOfReserved()
        DataGridViewListOfReservation.Columns(0).HeaderText = "Reservation ID"
        DataGridViewListOfReservation.Columns(1).HeaderText = "Customer Name"
        DataGridViewListOfReservation.Columns(2).HeaderText = "Base Service"
        DataGridViewListOfReservation.Columns(3).HeaderText = "Addon Service"
        DataGridViewListOfReservation.Columns(4).HeaderText = "Date & Time"
        DataGridViewListOfReservation.Columns(5).HeaderText = "Appointment Status"
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub DataGridViewListOfReservation_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewListOfReservation.CellContentClick

    End Sub
End Class