Imports System.Data.Common
Imports Microsoft.Data.SqlClient

Public Class SalesHistory
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    Private Sub SalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewSalesHistory()
        ChangeHeaderOfDataGridViewSales()
        DataGridViewSalesFontStyle()
    End Sub
    Private Sub DataGridViewSalesHIstory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesHIstory.CellContentClick


    End Sub

    Private Sub DataGridViewSalesHIstory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSalesHIstory.CellFormatting
        If e.ColumnIndex = Me.DataGridViewSalesHIstory.Columns("PaymentMethod").Index AndAlso e.RowIndex >= 0 Then

            ' Get the value from the current cell.
            Dim status As String = e.Value?.ToString().Trim()

            ' Check the status and apply the correct formatting to the entire row.
            Select Case status
                Case "Gcash"
                    ' Blue for confirmed appointments.
                    e.CellStyle.BackColor = Color.LightSkyBlue
                    e.CellStyle.ForeColor = Color.Black
                Case "Cheque"
                    ' Gold for appointments that are pending.
                    e.CellStyle.BackColor = Color.Gold
                    e.CellStyle.ForeColor = Color.Black
                Case "Billing Contract"
                    ' Gray for appointments that were a no-show.
                    e.CellStyle.BackColor = Color.LightGray
                    e.CellStyle.ForeColor = Color.Black
                Case "Cash"
                    ' Green for completed appointments.
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
            End Select
        End If

    End Sub

    Private Sub DataGridViewSalesFontStyle()
        DataGridViewSalesHIstory.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridViewSalesHIstory.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub

    Private Sub ChangeHeaderOfDataGridViewSales()
        DataGridViewSalesHIstory.Columns(0).HeaderText = "Sales ID"
        DataGridViewSalesHIstory.Columns(1).HeaderText = "Customer Name"
        DataGridViewSalesHIstory.Columns(2).HeaderText = "Base Service"
        DataGridViewSalesHIstory.Columns(3).HeaderText = "Addon Service"
        DataGridViewSalesHIstory.Columns(4).HeaderText = "Sale Date"
        DataGridViewSalesHIstory.Columns(5).HeaderText = "Payment Method"
        DataGridViewSalesHIstory.Columns(6).HeaderText = "Reference ID"
        DataGridViewSalesHIstory.Columns(7).HeaderText = "Total Price"
    End Sub
    Private Sub ViewSalesHistory()
        DataGridViewSalesHIstory.DataSource = ViewHistorySales()
    End Sub

    Private Function ViewHistorySales() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery =
            "SELECT " &
                "s.SalesID, " &
                "c.Name + ' ' + c.LastName AS CustomerName, " &
                "sv_base.ServiceName, " &
                "sv_addon.ServiceName," &
                "s.SaleDate, " &
                "s.PaymentMethod, " &
                "s.ReferenceID, " &
                "s.TotalPrice " &
            "FROM SalesHistoryTable s " &
            "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
            "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID " &
            "ORDER BY s.SalesID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt

    End Function
End Class