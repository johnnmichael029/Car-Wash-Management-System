Public Class DataGridTextHighlightService
    Public Shared Sub DataGridViewTextHighlight(e As DataGridViewCellPaintingEventArgs)
        ' Only proceed if we are in a data row, not the header, and we have a search term
        If e.RowIndex < 0 OrElse String.IsNullOrWhiteSpace(SearchBarService.currentSearchTerm) Then
            Exit Sub
        End If

        ' Get the cell value (which should be searchable text)
        Dim cellValue As String = e.FormattedValue?.ToString()

        If String.IsNullOrWhiteSpace(cellValue) Then
            Exit Sub
        End If

        ' 1. Check if the cell text contains the search term (case-insensitive)
        Dim searchIndex As Integer = cellValue.IndexOf(SearchBarService.currentSearchTerm, StringComparison.OrdinalIgnoreCase)

        If searchIndex >= 0 Then
            ' A match was found!

            ' A. Do the default painting (draw background, borders, etc.)
            e.PaintBackground(e.ClipBounds, True)

            ' B. Set up colors and fonts
            Dim baseFont As Font = e.CellStyle.Font
            Dim highlightColor As Color = Color.Yellow ' Use a bright color for highlighting
            Dim highlightTextBrush As Brush = New SolidBrush(e.CellStyle.ForeColor)

            ' C. Calculate positions and sizes

            ' Calculate the size of the entire string using the cell's font
            Dim textSize As SizeF = e.Graphics.MeasureString(cellValue, baseFont)

            ' Get the original bounds (where the text starts)
            Dim textX As Integer = e.CellBounds.X + 3 ' Small padding from the left edge
            Dim textY As Integer = e.CellBounds.Y + (e.CellBounds.Height - CInt(textSize.Height)) \ 2 ' Center vertically

            ' 1. Text before the match
            Dim textBefore As String = cellValue.Substring(0, searchIndex)
            Dim sizeBefore As SizeF = e.Graphics.MeasureString(textBefore, baseFont)

            ' 2. The matching search term
            Dim textMatch As String = cellValue.Substring(searchIndex, SearchBarService.currentSearchTerm.Length)
            Dim sizeMatch As SizeF = e.Graphics.MeasureString(textMatch, baseFont)

            ' --- Draw the three parts of the text ---

            ' Part 1: Text before the match (using default cell color)
            e.Graphics.DrawString(textBefore, baseFont, New SolidBrush(e.CellStyle.ForeColor), textX, textY)

            ' Part 2: The highlighted match
            ' Draw the yellow background rectangle
            Dim highlightRect As New Rectangle(
                CInt(textX + sizeBefore.Width),
                e.CellBounds.Y,
                CInt(sizeMatch.Width),
                e.CellBounds.Height
            )
            e.Graphics.FillRectangle(New SolidBrush(highlightColor), highlightRect)

            ' Draw the matched text (over the yellow background)
            e.Graphics.DrawString(textMatch, baseFont, highlightTextBrush, CInt(textX + sizeBefore.Width), textY)

            ' Part 3: Text after the match
            Dim textAfter As String = cellValue.Substring(searchIndex + SearchBarService.currentSearchTerm.Length)
            e.Graphics.DrawString(textAfter, baseFont, New SolidBrush(e.CellStyle.ForeColor), CInt(textX + sizeBefore.Width + sizeMatch.Width), textY)

            ' Indicate that we have manually drawn the cell contents
            e.Handled = True
        Else
            ' If no match, let the default rendering happen
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Handled = True
        End If
    End Sub
End Class
