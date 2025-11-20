Imports System.Data.Common
Imports Microsoft.Data.SqlClient

Public Class SalesHistory
    Inherits BaseForm

    Public Sub New()
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub SalesHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ViewSalesHistory()
        ChangeHeaderOfDataGridViewSales()
        DataGridViewSalesFontStyle()
    End Sub
    Private Sub DataGridViewSalesHIstory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesHIstory.CellContentClick


    End Sub

    Private Sub DataGridViewSalesHIstory_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSalesHIstory.CellFormatting

        DataGridFormattingService.DataGridCellFormattingPaymentMethod(e, "PaymentMethod", DataGridViewSalesHIstory)

        DataGridFormattingService.DataGridCellFormattingFrom(e, "Form", DataGridViewSalesHIstory)
    End Sub

    Private Sub DataGridViewSalesFontStyle()
        DataGridFontStyleService.DataGridFontStyle(DataGridViewSalesHIstory)
    End Sub

    Private Sub ChangeHeaderOfDataGridViewSales()
        DataGridViewSalesHIstory.Columns(0).HeaderText = "Sales ID"
        DataGridViewSalesHIstory.Columns(1).HeaderText = "Customer Name"
        DataGridViewSalesHIstory.Columns(2).HeaderText = "Base Service"
        DataGridViewSalesHIstory.Columns(3).HeaderText = "Addon Service"
        DataGridViewSalesHIstory.Columns(4).HeaderText = "Sale Date"
        DataGridViewSalesHIstory.Columns(5).HeaderText = "Payment Method"
        DataGridViewSalesHIstory.Columns(6).HeaderText = "Reference ID"
        DataGridViewSalesHIstory.Columns(8).HeaderText = "Total Price"
        DataGridViewSalesHIstory.Columns(9).HeaderText = "Sale"
    End Sub
    Private Sub ViewSalesHistory()
        DataGridViewSalesHIstory.DataSource = HistoryDatabaseHelper.ViewHistorySales()
    End Sub
End Class