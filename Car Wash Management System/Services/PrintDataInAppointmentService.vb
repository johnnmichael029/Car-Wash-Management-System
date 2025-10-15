Public Class PrintDataInAppointmentService
    Public Property ContractID As Integer
    Public Property CustomerName As String
    Public Property CustomerID As Integer
    Public Property ServiceLineItems As New List(Of ServiceLineItem)()


    Public Property BaseService As String
    Public Property AddonService As String
    Public ReadOnly Property TotalPrice As Decimal
        Get
            Return ServiceLineItems.Sum(Function(item) item.Price)
        End Get
    End Property




    Public Property PaymentMethod As String
    Public Property SaleDate As DateTime



    Public Property BaseServicePrice As Decimal
    Public Property AddonServicePrice As Decimal


    Public Property StartDate As DateTime
    Public Property AppointmentStatus As String
End Class