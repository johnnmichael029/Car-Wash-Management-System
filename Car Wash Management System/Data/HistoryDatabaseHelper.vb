Imports Microsoft.Data.SqlClient

Public Class HistoryDatabaseHelper
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub
    Public Function ViewHistorySales() As DataTable
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
                "s.Detailer, " &
                "s.TotalPrice, " &
                "s.Form " &
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
