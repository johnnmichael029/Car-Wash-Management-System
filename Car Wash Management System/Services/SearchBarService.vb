Public Class SearchBarService
    Public Shared currentSearchTerm As String = String.Empty

    Public Shared Sub SearchBarFunction(textBoxSearchBar As TextBox, dataGridViewCustomerInformation As DataGridView)
        currentSearchTerm = Trim(textBoxSearchBar.Text)

        ' --- NEW: Get the selected filter column ---

        Dim salesData As New DataTable()

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            ' Load all data if search box is empty
            salesData = CustomerInformationDatabaseHelper.ViewCustomer()
        Else
            ' Load filtered data, passing both the search term and the filter column
            salesData = CustomerInformationDatabaseHelper.GetSearchCustomerResults(currentSearchTerm)
        End If

        dataGridViewCustomerInformation.DataSource = salesData

        ' Force the DataGridView to redraw all cells after search (for highlighting)
        dataGridViewCustomerInformation.Invalidate()
    End Sub


End Class
