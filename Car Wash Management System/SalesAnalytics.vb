Public Class SalesAnalytics

    Private Sub SalesAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateAllTotal()
    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub
    Public Sub PopulateAllTotal()
        Dim orders As Decimal = SalesAnalyticsDatabaseHelper.GetOrders()
        LabelOrders.Text = orders.ToString("N2")

        Dim customers As Integer = SalesAnalyticsDatabaseHelper.GetCustomers()
        LabelCustomers.Text = customers.ToString("N2")

        Dim earnings As Integer = SalesAnalyticsDatabaseHelper.GetEarnings()
        LabelEarnings.Text = earnings.ToString("N2")
    End Sub
End Class