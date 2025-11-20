Public Class PrintDataInPickup
    Public Property PickupID As Integer
    Public Property CustomerName As String
    Public Property ServiceLineItems As New List(Of ServiceLineItem)()

    Public ReadOnly Property TotalPrice As Decimal
        Get
            Return ServiceLineItems.Sum(Function(item) item.Price)
        End Get
    End Property

    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
    Public Property Discount As Decimal
    Public Property PickupDate As DateTime
    Public Property Detailer As String
End Class
