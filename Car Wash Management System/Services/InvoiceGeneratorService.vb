Public Class InvoiceGeneratorService
    Public Shared Function CreateInvoiceNumber(salesId As Integer) As String
        Dim now As DateTime = DateTime.Now
        Dim dateTimePart As String = now.ToString("MMddyyyyHHmm")
        Dim finalInvoiceNumber As String = $"{dateTimePart} - {salesId}"
        Return finalInvoiceNumber
    End Function
End Class
