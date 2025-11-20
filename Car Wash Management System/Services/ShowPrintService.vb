Imports System.Drawing.Printing

Public Class ShowPrintService
    Public Shared Sub ShowPrintPreviewService(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
End Class
