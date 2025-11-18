Public Class DataGridFontStyleService
    Public Shared Sub DataGridFontStyle(DataGridView As DataGridView)
        DataGridView.DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        DataGridView.ColumnHeadersDefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Bold)
    End Sub
End Class
