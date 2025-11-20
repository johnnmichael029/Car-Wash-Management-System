Public Class PrintDataInContractsService
    Public Property ContractID As Integer
    Public Property CustomerName As String
    Public Property CustomerID As Integer

    Public Property ServiceLineItems As New List(Of ServiceLineItem)()

    Public ReadOnly Property TotalPrice As Decimal
        Get
            Return ServiceLineItems.Sum(Function(item) item.Price)
        End Get
    End Property


    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime
    Public Property BillingFrequency As String
    Public Property StartDate As DateTime
    Public Property EndDate As DateTime
    Public Property ContractStatus As String
    Public Property Discount As Decimal
    Public Property Detailer As String
End Class
