Imports System.Windows.Forms.DataVisualization.Charting

Public Class SearchBarService
    Public Shared currentSearchTerm As String = String.Empty

    Public Overloads Shared Sub SearchBarFunction(textBoxSearchBar As TextBox, dataGridViewCustomerInformation As DataGridView)
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

    Public Overloads Shared Sub SearchBarFunction(textBoxSearchBar As TextBox,
                                                   DataGridViewLatestTransaction As DataGridView,
                                                   ComboBoxFilter As ComboBox)
        currentSearchTerm = Trim(textBoxSearchBar.Text)

        ' --- NEW: Get the selected filter column ---
        Dim filterColumn As String = ComboBoxFilter.SelectedItem?.ToString()
        If String.IsNullOrWhiteSpace(filterColumn) Then
            ' Default to searching all columns if nothing is selected
            filterColumn = "Filter"
        End If

        Dim salesData As New DataTable()

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            ' Load all data if search box is empty
            salesData = DashboardDatabaseHelper.ViewSalesData()
        Else
            ' Load filtered data, passing both the search term and the filter column
            salesData = DashboardDatabaseHelper.GetFilteredList(currentSearchTerm, filterColumn)
        End If

        DataGridViewLatestTransaction.DataSource = salesData

        ' Force the DataGridView to redraw all cells after search (for highlighting)
        DataGridViewLatestTransaction.Invalidate()
    End Sub

    Public Shared Sub SearchBarFunctionForAnalytics(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = SalesAnalyticsDatabaseHelper.GetSalesSummaryData()
        Else
            salesData = SalesAnalyticsDatabaseHelper.SearchInSalesSummary(currentSearchTerm)
        End If

        gridView.DataSource = salesData
        gridView.Refresh()
    End Sub

    Public Shared Sub SearchBarFunctionForRegularSale(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = SalesDatabaseHelper.ViewSales()
        Else
            salesData = SalesDatabaseHelper.SearchInRegularSale(currentSearchTerm)
        End If

        gridView.DataSource = salesData
        gridView.Refresh()
    End Sub

    Public Shared Sub SearchBarFunctionForContract(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = ContractsDatabaseHelper.ViewContracts()
        Else
            salesData = ContractsDatabaseHelper.SearchInContract(currentSearchTerm)
        End If

        gridView.DataSource = salesData
        gridView.Refresh()
    End Sub

    Public Shared Sub SearchBarFunctionForAppointment(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = AppointmentManagementDatabaseHelper.ViewAppointment()
        Else
            salesData = AppointmentManagementDatabaseHelper.SearchInAppointment(currentSearchTerm)
        End If

        gridView.DataSource = salesData


        gridView.Refresh()
    End Sub

    Public Shared Sub SearchBarFunctionForPickup(searchBar As TextBox, gridView As DataGridView)
        currentSearchTerm = Trim(searchBar.Text)
        Dim salesData As DataTable

        If String.IsNullOrWhiteSpace(currentSearchTerm) Then
            salesData = PickupManagementDatabaseHelper.ViewPickupData()
        Else
            salesData = PickupManagementDatabaseHelper.SearchInPuckup(currentSearchTerm)
        End If

        gridView.DataSource = salesData
        ' --- 2. FIX: Explicitly set the DisplayIndex of the Action button immediately after binding ---
        If gridView.Columns.Contains("actionsColumn") Then
            ' Setting DisplayIndex to the total number of columns minus 1 makes it the last column.
            gridView.Columns("actionsColumn").DisplayIndex = gridView.Columns.Count - 1
        End If

        gridView.Refresh()
    End Sub
End Class
