Imports System.Drawing.Printing

Public Class PrintBillInPickup

    Public Shared Sub ShowPrint(PrintDocumentBill As PrintDocument)
        ShowPrintPreview(PrintDocumentBill)
        Dim printPreviewDialog As New PrintPreviewDialog With {
            .Document = PrintDocumentBill
        }
        printPreviewDialog.ShowDialog()
    End Sub
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub

    Public Shared Sub PrintBillInPickup(e As PrintPageEventArgs, printData As PrintDataInPickup)
        If printData Is Nothing Then
            Return
        End If

        ' --- Font Definitions ---
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        ' --- Layout Calculations ---
        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        ' Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12

        ' --- Header ---
        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' --- Sale Info ---
        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & InvoiceGeneratorService.CreateInvoiceNumber(printData.PickupID), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset

        ' --- Table Header ---
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset

        ' --- Table Body (Looping through items) ---
        If printData.ServiceLineItems IsNot Nothing AndAlso printData.ServiceLineItems.Count > 0 Then
            For Each item As ServiceLineItem In printData.ServiceLineItems
                ' Print Qty
                e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)

                ' Print Description
                e.Graphics.DrawString(item.Name, f10, Brushes.Black, centerMargin, yPos, centerAlign)

                e.Graphics.DrawString(item.Price.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)

                yPos += offset
            Next
        Else
            e.Graphics.DrawString("No services recorded.", f10, Brushes.Black, centerMargin, yPos, centerAlign)
            yPos += offset
        End If

        Dim finalTotal As Decimal = printData.TotalPrice


        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset

        ' --- Additional Info ---
        e.Graphics.DrawString("Pickup Date:", f10, Brushes.Black, leftMargin, yPos) ' Use bold for total
        e.Graphics.DrawString(printData.PickupDate, f10, Brushes.Black, rightMargin, yPos, rightAlign) ' Use bold for total amount
        yPos += offset

        e.Graphics.DrawString("Detailer:", f10, Brushes.Black, leftMargin, yPos) ' Use bold for total
        e.Graphics.DrawString(printData.Detailer, f10, Brushes.Black, rightMargin, yPos, rightAlign) ' Use bold for total amount
        yPos += offset

        ' --- Subtotal/Total Line ---
        yPos += offset
        e.Graphics.DrawString("Discount:", f10b, Brushes.Black, leftMargin, yPos) ' Use bold for total
        e.Graphics.DrawString(printData.Discount & "%", f10b, Brushes.Black, rightMargin, yPos, rightAlign) ' Use bold for total amount
        yPos += offset

        e.Graphics.DrawString("Subtotal:", f10b, Brushes.Black, leftMargin, yPos) ' Use bold for total
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10b, Brushes.Black, rightMargin, yPos, rightAlign) ' Use bold for total amount
        yPos += offset
        yPos += offset

        ' --- Payment Section ---
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
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
End Class
