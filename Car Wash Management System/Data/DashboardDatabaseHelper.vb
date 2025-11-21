Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class DashboardDatabaseHelper
    Private Shared constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    ''' <summary>
    ''' View Sales Data from the SalesHistoryTable along with Customer and Service details.
    ''' </summary>
    Public Shared Function ViewSalesData() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery =
            "SELECT " &
                "s.SalesID, " &
                 "ISNULL(c.Name, '') + ' ' + ISNULL(c.LastName, '') AS CustomerName, " &
                "sv_base.ServiceName, " &
                "sv_addon.ServiceName," &
                "s.SaleDate, " &
                "s.PaymentMethod, " &
                "s.ReferenceID, " &
                "s.TotalPrice " &
            "FROM SalesHistoryTable s " &
            "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
            "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID " &
            "ORDER BY s.SalesID DESC"

                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales grouped by year from the SalesHistoryTable.
    ''' </summary>
    Public Shared Function GetYearlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate) ORDER BY SalesYear"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetYearlySales: " & ex.Message)
        End Try
        Return dt
    End Function

    ''' <summary>
    ''' Gets the total sales grouped by month and year from the SalesHistoryTable.
    ''' </summary>
    ''' 
    Public Shared Function GetMonthlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, MONTH(SaleDate) AS SalesMonth, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate), MONTH(SaleDate) ORDER BY SalesYear, SalesMonth"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetMonthlySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales for the past 7 days from the SalesHistoryTable.
    ''' </summary>
    Public Shared Function GetDailySales() As DataTable
        Dim query As String = "SELECT CAST(SaleDate AS DATE) AS SaleDate, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable WHERE SaleDate >= DATEADD(DAY, -30, CAST(GETDATE() AS DATE)) GROUP BY CAST(SaleDate AS DATE) ORDER BY SaleDate ASC"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the filtered sales data based on the search string and filter column.
    ''' </summary>
    'Public Function GetWeeklySales() As DataTable
    '    ' The query calculates the starting date of the 7-day period (WeekStartDate) for grouping.
    '    Dim query As String = "
    'WITH MinSaleDate (StartDate) AS (
    '    -- 1. Find the absolute minimum/first sales date
    '    SELECT MIN(CAST(SaleDate AS DATE)) FROM SalesHistoryTable
    ')
    'SELECT
    '    -- Returns the first day of the calculated week for the purpose of grouping
    '    CAST(DATEADD(wk, DATEDIFF(wk, (SELECT StartDate FROM MinSaleDate), CAST(SaleDate AS DATE)), (SELECT StartDate FROM MinSaleDate)) AS DATE) AS WeekStartDate,
    '    SUM(TotalPrice) AS TotalSales
    'FROM SalesHistoryTable T
    'GROUP BY 
    '    CAST(DATEADD(wk, DATEDIFF(wk, (SELECT StartDate FROM MinSaleDate), CAST(SaleDate AS DATE)), (SELECT StartDate FROM MinSaleDate)) AS DATE)
    'ORDER BY 
    '    WeekStartDate ASC"

    '    Dim dt As New DataTable()
    '    Try
    '        Using con As New SqlConnection(constr)
    '            Using cmd As New SqlCommand(query, con)
    '                con.Open()
    '                Dim adapter As New SqlDataAdapter(cmd)
    '                adapter.Fill(dt)
    '            End Using
    '        End Using

    '        ' --- POST-PROCESSING IN VB.NET TO GET 'Week 1', 'Week 2', etc. ---

    '        If dt.Rows.Count > 0 Then
    '            ' Add a new column to the DataTable for the Week Label
    '            dt.Columns.Add("SalesWeek", GetType(String))

    '            ' Determine the true starting date of the sales data for calculation
    '            Dim firstWeekStartDate As Date = CDate(dt.Rows(0)("WeekStartDate"))

    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                Dim currentWeekStartDate As Date = CDate(dt.Rows(i)("WeekStartDate"))

    '                ' Calculate the difference in days from the first week's start date
    '                Dim timeSpan As TimeSpan = currentWeekStartDate.Subtract(firstWeekStartDate)

    '                ' Calculate the week index (0, 1, 2...)
    '                Dim weekIndex As Integer = CInt(Math.Floor(timeSpan.TotalDays / 7))

    '                ' Set the 'SalesWeek' label (Week 1, Week 2, etc.)
    '                dt.Rows(i)("SalesWeek") = "Week " & (weekIndex + 1).ToString()
    '            Next

    '            ' Clean up the DataTable to remove the intermediate date column
    '            dt.Columns.Remove("WeekStartDate")
    '            dt.Columns("SalesWeek").SetOrdinal(0) ' Make it the first column
    '        End If

    '    Catch ex As Exception
    '        ' Log or display the error if something goes wrong with the database
    '        Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
    '    End Try

    '    Return dt
    'End Function

    ''' <summary>
    ''' Gets the filtered sales data based on the search string and filter column.
    ''' </summary>
    Public Shared Function GetFilteredList(searchInBar As String, filterColumn As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim selectQuery As String
            con.Open()
            Try
                ' --- SQL SELECT Statement (Common to all cases) ---
                Dim baseSelect As String =
                    "SELECT " &
                    "s.SalesID, " &
                    "ISNULL(c.Name, '') + ' ' + ISNULL(c.LastName, '') AS CustomerName, " &
                    "sv_base.ServiceName AS BaseService, " & ' Added alias for clarity
                    "sv_addon.ServiceName AS AddonService, " & ' Added alias for clarity
                    "s.SaleDate, " &
                    "s.PaymentMethod, " &
                    "s.ReferenceID, " &
                    "s.TotalPrice " &
                    "FROM SalesHistoryTable s " &
                    "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
                    "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
                    "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID "

                ' --- Determine the WHERE Clause based on filterColumn ---
                If filterColumn = "Addon Service" Then
                    ' FIX 1: Use LIKE and target the Addon service column
                    selectQuery = baseSelect & "WHERE sv_addon.ServiceName LIKE @searchString"

                ElseIf filterColumn = "Base Service" Then
                    ' FIX 2: Use LIKE and target the Base service column
                    selectQuery = baseSelect & "WHERE sv_base.ServiceName LIKE @searchString"

                ElseIf filterColumn = "All Columns" Then
                    ' Ensure your ComboBox has an "All Columns" option, otherwise this case handles the default catch-all.
                    selectQuery = baseSelect &
                            "WHERE c.Name LIKE @searchString " &
                            "OR c.LastName LIKE @searchString " &
                            "OR s.SalesID LIKE @searchString " &
                            "OR s.PaymentMethod LIKE @searchString " &
                            "OR sv_base.ServiceName LIKE @searchString " &
                            "OR sv_addon.ServiceName LIKE @searchString " &
                            "OR c.Name + ' ' + c.LastName LIKE @searchString"
                Else
                    selectQuery = baseSelect & "WHERE c.Name LIKE @searchString
                                                OR c.LastName LIKE @searchString 
                                                OR s.SalesID LIKE @SearchString
                                                OR c.Name + ' ' + c.LastName LIKE @searchString"
                End If

                selectQuery = selectQuery & " ORDER BY s.SalesID DESC"

                ' --- Execute the Query ---
                Using cmd As New SqlCommand(selectQuery, con)
                    ' Parameterization is correct: the wildcard '%' characters are added here
                    cmd.Parameters.AddWithValue("@searchString", "%" & searchInBar & "%")
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error viewing sales history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Gets the activity log from the ActivityLogTable.
    ''' </summary>
    ''' 
    Public Shared Function GetNextSalesID() As Integer
        Dim nextId As Integer = 1
        Dim sql As String = "SELECT ISNULL(MAX(SalesID), 0) FROM RegularSaleTable"
        Try
            Using conn As New SqlConnection(constr)
                Using cmd As New SqlCommand(sql, conn)
                    conn.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                        ' Convert the result (which is the MAX SalesID, or 0) to an integer
                        Dim maxId As Integer = CInt(result)

                        ' The next SalesID is the Max ID plus 1
                        nextId = maxId + 1
                    End If

                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database Error generating Sales ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try

        Return nextId
    End Function
End Class
