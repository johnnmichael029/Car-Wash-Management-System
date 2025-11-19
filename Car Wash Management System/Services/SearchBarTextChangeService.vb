Public Class SearchBarTextChangeService
    Public Shared Sub TextBoxSearchBar(TextBoxSearchBar As TextBox, e As EventArgs)
        TextBoxSearchBar.Text = ""
        TextBoxSearchBar.ForeColor = Color.Black
    End Sub
End Class
