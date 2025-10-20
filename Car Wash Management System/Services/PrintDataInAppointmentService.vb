﻿Public Class PrintDataInAppointmentService
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


    Public Property StartDate As DateTime
    Public Property AppointmentStatus As String
End Class