Public Class PrintSaleInDashboard
    Public Property SalesID As Integer
    Public Property CustomerName As String
    Public Property ServiceLineItemInDashboard As New List(Of ServiceLineItemInDashboard)()

    Public ReadOnly Property TotalPrice As Decimal
        Get
            Return ServiceLineItemInDashboard.Sum(Function(item) item.Price)
        End Get
    End Property

    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
End Class
