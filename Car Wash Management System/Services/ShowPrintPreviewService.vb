Imports System.Drawing.Printing
Public Class ShowPrintPreviewService
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
    Public Shared Sub PrintBillInSales(e As PrintPageEventArgs, printData As PrintDataInSales)
        If printData Is Nothing Then
            ' Handle case where no data is set
            Return
        End If

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        'Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12


        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' Add bill details from the class-level printData object

        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & printData.SalesID, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.BaseService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString(printData.BaseServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        If Not String.IsNullOrWhiteSpace(printData.AddonService) Then
            yPos += offset
            e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
            e.Graphics.DrawString("Add-on: " & printData.AddonService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
            e.Graphics.DrawString(printData.AddonServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
            yPos += offset
        End If
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Total:", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        yPos += offset

        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString("Payment", f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset

        e.Graphics.DrawString(printData.PaymentMethod, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
End Class
