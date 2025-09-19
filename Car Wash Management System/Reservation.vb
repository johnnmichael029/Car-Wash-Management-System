Imports Microsoft.Data.SqlClient
Public Class Reservation
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly reservationManagement As ReservationManagement
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        reservationManagement = New ReservationManagement(constr)
    End Sub
    Private Sub Appointment_Load(Sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewListOfReserved.DataSource = reservationManagement.ViewListOfReserved()
        DataGridViewListOfReservedFontStyle()
    End Sub
    Private Sub DataGridViewListOfReservedFontStyle()
        DataGridViewListOfReserved.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewListOfReserved.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub DataGridViewListOfReserved_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewListOfReserved.CellFormatting
        ' Check if this is the column we care about ("AppointmentStatus") and
        ' if the row is not new.
        If e.ColumnIndex = Me.DataGridViewListOfReserved.Columns("AppointmentStatus").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString()
            If status = "Confirmed" Then
                e.CellStyle.BackColor = Color.LightSkyBlue
                e.CellStyle.ForeColor = Color.Black
            End If
        End If
    End Sub

End Class
Public Class ReservationManagement
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