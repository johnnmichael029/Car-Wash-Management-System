Public Class SaleSummaryAnalytics
    Private Sub SaleSummaryAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SalesAnalytics.ViewSalesSummary(DataGridViewSalesSummary)
        SalesAnalytics.DataGridSalesSummaryFontStyle(DataGridViewSalesSummary)
        SalesAnalytics.ChangeHeadrOfDataGridViewSalesSummary(DataGridViewSalesSummary)
    End Sub

    Private Sub TextBoxSearchBar_TextChanged(sender As Object, e As EventArgs) Handles TextBoxSearchBar.TextChanged
        SearchBarService.SearchBarFunctionForAnalytics(TextBoxSearchBar, DataGridViewSalesSummary)
    End Sub

    Private Sub TextBoxSearchBar_Click(sender As Object, e As EventArgs) Handles TextBoxSearchBar.Click
        SearchBarTextChangeService.TextBoxSearchBar(TextBoxSearchBar, e)
    End Sub

    Private Sub DataGridViewSalesSummary_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles DataGridViewSalesSummary.CellPainting
        DataGridTextHighlightService.DataGridViewTextHighlight(e)
    End Sub

    Private Sub DataGridViewSalesSummary_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesSummary.CellContentClick

    End Sub
End Class