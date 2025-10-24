﻿Imports Microsoft.Data.SqlClient



Public Class SalesAnalyticsDatabaseHelper
    Private Shared constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Public Property CurrentMonthEarnings As Decimal
    Public Property PreviousMonthEarnings As Decimal
    Public Property PercentageChangeEarnings As Decimal
    Public Property CurrentMonthCustomers As Decimal
    Public Property PercentageChangeCustomers As Decimal
    Public Property PreviousMonthCustomers As Decimal
    Public Property CurrentMonthService As Decimal
    Public Property PreviousMonthService As Decimal
    Public Property PercentageChangeService As Decimal
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Shared Function GetDynamicService(timePeriod As String) As Decimal
        Dim totalSales As Decimal = 0
        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime

        Select Case timePeriod.ToUpper()
            Case "DAY"
                currentStart = today
                currentEnd = today.AddDays(1)
            Case "WEEK"
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)
            Case "MONTH"
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)
            Case "YEAR"
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)
            Case Else
                Throw New ArgumentException("Invalid time period specified for GetEarnings: " & timePeriod)
        End Select

        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT 
                                        SUM(CASE 
                                        WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN 1 
                                        ELSE 0
                                    END)              
                                    FROM SalesHistoryTable"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CurrentStart", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalSales = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in GetTodayTotalSales: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalSales
    End Function
    Public Shared Function GetDynamicCustomers(timePeriod As String) As Decimal
        Dim totalSales As Decimal = 0
        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime

        Select Case timePeriod.ToUpper()
            Case "DAY"
                currentStart = today
                currentEnd = today.AddDays(1)
            Case "WEEK"
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)
            Case "MONTH"
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)
            Case "YEAR"
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)
            Case Else
                Throw New ArgumentException("Invalid time period specified for GetEarnings: " & timePeriod)
        End Select


        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT 
                                        SUM(CASE 
                                        WHEN RegistrationDate >= @CurrentDate AND RegistrationDate < @CurrentEnd THEN 1 
                                        ELSE 0
                                    END)            
                                    FROM CustomersTable"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CurrentDate", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalSales = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in GetTodayTotalSales: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalSales
    End Function
    Public Shared Function GetDynamicEarnings(timePeriod As String) As Decimal
        Dim totalSales As Decimal = 0
        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime


        Select Case timePeriod.ToUpper()
            Case "DAY"
                currentStart = today
                currentEnd = today.AddDays(1)
            Case "WEEK"
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)
            Case "MONTH"
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)
            Case "YEAR"
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)
            Case Else
                Throw New ArgumentException("Invalid time period specified for GetEarnings: " & timePeriod)
        End Select

        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT
                                    SUM(CASE 
                                        WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN TotalPrice
                                        ELSE 0 
                                    END) AS SinceLastMonthSales
                                   FROM 
                                   SalesHistoryTable;"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@CurrentStart", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        totalSales = Convert.ToDecimal(result)
                    End If
                Catch ex As Exception
                    Console.WriteLine("Error in GetTodayTotalSales: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalSales
    End Function
    Public Shared Function GetDynamicEarningsData(timePeriod As String) As SalesAnalyticsDatabaseHelper
        Dim data As New SalesAnalyticsDatabaseHelper(constr) With {
            .CurrentMonthEarnings = 0D,
            .PreviousMonthEarnings = 0D,
            .PercentageChangeEarnings = 0D
        }

        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime
        Dim previousStart As DateTime
        Dim previousEnd As DateTime

        ' --- 1. Dynamic Date Range Calculation (Based on input string) ---
        Select Case timePeriod.ToUpper()
            Case "DAY"
                ' Current Period: Today
                currentStart = today
                currentEnd = today.AddDays(1) ' Up to, but not including, tomorrow
                ' Previous Period: Yesterday
                previousStart = today.AddDays(-1)
                previousEnd = today

            Case "WEEK"
                ' Find the start of the current week (Sunday)
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)

                ' Current Period: Start of week to end of today
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)

                ' Previous Period: The 7 days before the current week started
                previousStart = startOfWeek.AddDays(-7)
                previousEnd = startOfWeek

            Case "MONTH"
                ' Current Month
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)

                ' Previous Month
                previousStart = currentStart.AddMonths(-1)
                previousEnd = currentStart

            Case "YEAR"
                ' Current Year
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)

                ' Previous Year
                previousStart = currentStart.AddYears(-1)
                previousEnd = currentStart

            Case Else
                ' Fallback or error handling for invalid input
                Throw New ArgumentException("Invalid time period specified for GetEarningsData: " & timePeriod)
        End Select


        Using con As New SqlConnection(constr)
            ' --- 2. Dynamic SQL Query (Uses date parameters) ---
            Dim query As String = "
            SELECT
                -- 1. Total Earnings for the Current Period
                SUM(CASE 
                    WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN TotalPrice 
                    ELSE 0 
                END) AS CurrentPeriodEarnings,

                -- 2. Total Earnings for the Previous Period
                SUM(CASE 
                    WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN TotalPrice 
                    ELSE 0 
                END) AS PreviousPeriodEarnings,

                -- 3. Calculate the Percentage Change
                CAST(
                    CASE
                        -- Calculate previous earnings sum only once for comparison
                        WHEN SUM(CASE 
                            WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN TotalPrice 
                            ELSE 0 
                        END) > 0
                        THEN (
                            (SUM(CASE WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN TotalPrice ELSE 0 END) 
                            - SUM(CASE WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN TotalPrice ELSE 0 END)) 
                            * 100.0 
                            / SUM(CASE WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN TotalPrice ELSE 0 END)
                        )
                        
                        -- Case B: Previous Sales = 0, Current Sales > 0 
                        WHEN SUM(CASE WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN TotalPrice ELSE 0 END) > 0
                        THEN 100.0
                        
                        -- Case C: Both are 0 or no sales 
                        ELSE 0.0
                    END
                AS DECIMAL(10, 2)) AS PercentageChange
            FROM
                SalesHistoryTable;
            "

            Using cmd As New SqlCommand(query, con)
                ' Add the dynamically calculated dates as parameters
                cmd.Parameters.AddWithValue("@CurrentStart", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                cmd.Parameters.AddWithValue("@PreviousStart", previousStart)
                cmd.Parameters.AddWithValue("@PreviousEnd", previousEnd)

                Try
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Assign results to the data object
                            data.CurrentMonthEarnings = Convert.ToDecimal(reader("CurrentPeriodEarnings"))
                            data.PreviousMonthEarnings = Convert.ToDecimal(reader("PreviousPeriodEarnings"))
                            data.PercentageChangeEarnings = Convert.ToDecimal(reader("PercentageChange"))
                        End If
                    End Using
                Catch ex As Exception
                    Console.WriteLine("Error in GetEarningsData: " & ex.Message)
                End Try
            End Using
        End Using

        Return data
    End Function
    Public Shared Function GetDynamicServiceData(timePeriod As String) As SalesAnalyticsDatabaseHelper
        Dim data As New SalesAnalyticsDatabaseHelper(constr) With {
            .CurrentMonthService = 0D,
            .PreviousMonthService = 0D,
            .PercentageChangeService = 0D
        }

        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime
        Dim previousStart As DateTime
        Dim previousEnd As DateTime

        ' --- 1. Dynamic Date Range Calculation (Based on input string) ---
        Select Case timePeriod.ToUpper()
            Case "DAY"
                ' Current Period: Today
                currentStart = today
                currentEnd = today.AddDays(1) ' Up to, but not including, tomorrow
                ' Previous Period: Yesterday
                previousStart = today.AddDays(-1)
                previousEnd = today

            Case "WEEK"
                ' Find the start of the current week (Sunday)
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)

                ' Current Period: Start of week to end of today
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)

                ' Previous Period: The 7 days before the current week started
                previousStart = startOfWeek.AddDays(-7)
                previousEnd = startOfWeek

            Case "MONTH"
                ' Current Month
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)

                ' Previous Month
                previousStart = currentStart.AddMonths(-1)
                previousEnd = currentStart

            Case "YEAR"
                ' Current Year
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)

                ' Previous Year
                previousStart = currentStart.AddYears(-1)
                previousEnd = currentStart

            Case Else
                ' Fallback or error handling for invalid input
                Throw New ArgumentException("Invalid time period specified for GetServiceData: " & timePeriod)
        End Select


        Using con As New SqlConnection(constr)
            ' --- 2. Dynamic SQL Query (Uses date parameters and counts services) ---
            Dim query As String = "
            SELECT
                -- 1. Total Service COUNT for the Current Period
                SUM(CASE
                    WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN 1
                    ELSE 0
                END) AS CurrentMonthService,

                -- 2. Total Service COUNT for the Previous Period
                SUM(CASE
                    WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN 1
                    ELSE 0
                END) AS PreviousMonthService,

                -- 3. Calculate the Percentage Change (based on counts)
                CAST(
                    CASE
                        -- Calculate previous Service COUNT sum only once for comparison
                        WHEN SUM(CASE
                            WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN 1
                            ELSE 0
                        END) > 0
                        THEN (
                            (SUM(CASE WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN 1 ELSE 0 END)
                            - SUM(CASE WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN 1 ELSE 0 END))
                            * 100.0
                            / SUM(CASE WHEN SaleDate >= @PreviousStart AND SaleDate < @PreviousEnd THEN 1 ELSE 0 END)
                        )

                        -- Case B: Previous Service Count = 0, Current Service Count > 0
                        WHEN SUM(CASE WHEN SaleDate >= @CurrentStart AND SaleDate < @CurrentEnd THEN 1 ELSE 0 END) > 0
                        THEN 100.0

                        -- Case C: Both are 0 or no services
                        ELSE 0.0
                    END
                AS DECIMAL(10, 2)) AS PercentageChangeService
            FROM
                SalesHistoryTable;
            "

            Using cmd As New SqlCommand(query, con)
                ' Add the dynamically calculated dates as parameters
                cmd.Parameters.AddWithValue("@CurrentStart", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                cmd.Parameters.AddWithValue("@PreviousStart", previousStart)
                cmd.Parameters.AddWithValue("@PreviousEnd", previousEnd)

                Try
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Assign results to the data object (using the user's preferred property names)
                            data.CurrentMonthService = Convert.ToDecimal(reader("CurrentMonthService"))
                            data.PreviousMonthService = Convert.ToDecimal(reader("PreviousMonthService"))
                            data.PercentageChangeService = Convert.ToDecimal(reader("PercentageChangeService"))
                        End If
                    End Using
                Catch ex As Exception
                    Console.WriteLine("Error in GetServiceData: " & ex.Message)
                End Try
            End Using
        End Using

        Return data
    End Function
    Public Shared Function GetDynamicCustomerData(timePeriod As String) As SalesAnalyticsDatabaseHelper
        ' NOTE: Changed the initialized properties to match the customer data
        Dim data As New SalesAnalyticsDatabaseHelper(constr) With {
            .CurrentMonthCustomers = 0D,
            .PreviousMonthCustomers = 0D,
            .PercentageChangeCustomers = 0D
        }

        Dim today As DateTime = DateTime.Today
        Dim currentStart As DateTime
        Dim currentEnd As DateTime
        Dim previousStart As DateTime
        Dim previousEnd As DateTime

        ' --- 1. Dynamic Date Range Calculation (Based on input string) ---
        Select Case timePeriod.ToUpper()
            Case "DAY"
                ' Current Period: Today
                currentStart = today
                currentEnd = today.AddDays(1) ' Up to, but not including, tomorrow
                ' Previous Period: Yesterday
                previousStart = today.AddDays(-1)
                previousEnd = today

            Case "WEEK"
                ' Find the start of the current week (Sunday)
                Dim startOfWeek As DateTime = today.AddDays(DayOfWeek.Sunday - today.DayOfWeek)

                ' Current Period: Start of week to end of today
                currentStart = startOfWeek
                currentEnd = today.AddDays(1)

                ' Previous Period: The 7 days before the current week started
                previousStart = startOfWeek.AddDays(-7)
                previousEnd = startOfWeek

            Case "MONTH"
                ' Current Month
                currentStart = New DateTime(today.Year, today.Month, 1)
                currentEnd = today.AddDays(1)

                ' Previous Month
                previousStart = currentStart.AddMonths(-1)
                previousEnd = currentStart

            Case "YEAR"
                ' Current Year
                currentStart = New DateTime(today.Year, 1, 1)
                currentEnd = today.AddDays(1)

                ' Previous Year
                previousStart = currentStart.AddYears(-1)
                previousEnd = currentStart

            Case Else
                ' Fallback or error handling for invalid input
                Throw New ArgumentException("Invalid time period specified for GetCustomerData: " & timePeriod)
        End Select


        Using con As New SqlConnection(constr)
            ' The SQL query is updated to use the dynamic date parameters instead of static GETDATE() logic.
            Dim query As String = "
            SELECT
                -- 1. Total Customers for the Current Period
                SUM(CASE
                    WHEN RegistrationDate >= @CurrentStart AND RegistrationDate < @CurrentEnd THEN 1
                    ELSE 0
                END) AS CurrentMonthCustomers,

                -- 2. Total Customers for the Previous Period
                SUM(CASE
                    WHEN RegistrationDate >= @PreviousStart AND RegistrationDate < @PreviousEnd THEN 1
                    ELSE 0
                END) AS PreviousMonthCustomers,

                -- 3. Calculate the Percentage Change
                CAST(
                    CASE
                        -- Case A: Previous Period Customers > 0 (Standard formula)
                        WHEN SUM(CASE WHEN RegistrationDate >= @PreviousStart AND RegistrationDate < @PreviousEnd THEN 1 ELSE 0 END) > 0
                        THEN (
                            (
                                SUM(CASE WHEN RegistrationDate >= @CurrentStart AND RegistrationDate < @CurrentEnd THEN 1 ELSE 0 END) -- Current Count
                                -
                                SUM(CASE WHEN RegistrationDate >= @PreviousStart AND RegistrationDate < @PreviousEnd THEN 1 ELSE 0 END) -- Previous Count
                            )
                            * 100.0 / SUM(CASE WHEN RegistrationDate >= @PreviousStart AND RegistrationDate < @PreviousEnd THEN 1 ELSE 0 END)
                        )

                        -- Case B: Previous Period Customers = 0, Current Period Customers > 0 (100% growth)
                        WHEN SUM(CASE WHEN RegistrationDate >= @CurrentStart AND RegistrationDate < @CurrentEnd THEN 1 ELSE 0 END) > 0
                        THEN 100.0

                        -- Case C: Both are 0 or no change
                        ELSE 0.0
                    END
                AS DECIMAL(10, 2)) AS PercentageChangeCustomers
            FROM
                CustomersTable;" ' **Ensure this table name is correct**

            Using cmd As New SqlCommand(query, con)
                ' Add the dynamically calculated dates as parameters
                cmd.Parameters.AddWithValue("@CurrentStart", currentStart)
                cmd.Parameters.AddWithValue("@CurrentEnd", currentEnd)
                cmd.Parameters.AddWithValue("@PreviousStart", previousStart)
                cmd.Parameters.AddWithValue("@PreviousEnd", previousEnd)

                Try
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Get the current period's count
                            data.CurrentMonthCustomers = Convert.ToDecimal(reader("CurrentMonthCustomers"))
                            ' Get the previous period's count
                            data.PreviousMonthCustomers = Convert.ToDecimal(reader("PreviousMonthCustomers"))
                            ' Get the calculated percentage change
                            data.PercentageChangeCustomers = Convert.ToDecimal(reader("PercentageChangeCustomers"))
                        End If
                    End Using
                Catch ex As Exception
                    ' Updated the error message for clarity
                    Console.WriteLine("Error in GetCustomerData: " & ex.Message)
                End Try
            End Using
        End Using

        Return data
    End Function
    Public Shared Function GetDynamicSalesQuery() As String
        Return "
            -- Combine all Service and Addon revenues into one list
            WITH CombinedSales AS (
                -- Main Services sold (using ServiceID)
                SELECT ServiceID AS ItemID, TotalPrice
                FROM SalesHistoryTable
                WHERE ServiceID IS NOT NULL

                UNION ALL

                -- Add-on Services sold (using AddonID)
                SELECT AddonServiceID AS ItemID, TotalPrice
                FROM SalesHistoryTable
                WHERE AddonServiceID IS NOT NULL
            )
            -- Join the combined list back to the ServicesTable to get the ServiceName
            SELECT
                S.ServiceName,
                SUM(CS.TotalPrice) AS TotalRevenue
            FROM CombinedSales CS
            INNER JOIN ServicesTable S ON CS.ItemID = S.ServiceID
            -- Filter only the services you are interested in for the pie chart
            WHERE S.ServiceName LIKE '%Wash'    -- Matches 'Basic Wash' and 'Engine Wash'
               OR S.ServiceName LIKE '%Wax'     -- Matches 'Wax Treatment'
               OR S.ServiceName LIKE '%Armor'   -- Matches 'Paint Armor/Sealant'
            GROUP BY S.ServiceName
            ORDER BY TotalRevenue DESC;
        "
    End Function
    Public Shared Function GetDynamicCustomersQuery() As String
        Return "
            -- Calculates total revenue generated by each customer
            SELECT
                CT.Name,
                SUM(SHT.TotalPrice) AS TotalRevenue
            FROM SalesHistoryTable SHT
            -- Join to CustomersTable to get the customer's name
            INNER JOIN CustomersTable CT ON SHT.CustomerID = CT.CustomerID
            -- Only include sales that have an associated customer
            WHERE SHT.CustomerID IS NOT NULL
            GROUP BY CT.Name
            ORDER BY TotalRevenue DESC;
        "
    End Function

    Public Shared Function GetDynamicAverageSalesQuery(timePeriod As String) As String
        ' This function generates the SQL to calculate the average sales price based on a time period

        Dim dateGroupingColumn As String

        Select Case timePeriod.ToUpper()
            Case "DAY"
                ' Groups by the date (e.g., '2023-10-24')
                dateGroupingColumn = "FORMAT(SaleDate, 'yyyy-MM-dd')"
            Case "MONTH"
                ' Groups by the year and month (e.g., '2023-10')
                dateGroupingColumn = "FORMAT(SaleDate, 'yyyy-MM')"
            Case "YEAR"
                ' Groups by the year (e.g., '2023')
                dateGroupingColumn = "FORMAT(SaleDate, 'yyyy')"
            Case Else
                Throw New ArgumentException("Invalid time period specified for SQL query in GetDynamicAverageSalesQuery.")
        End Select

        Return String.Format("
            -- Calculates average sales per {0}
            SELECT
                {1} AS PeriodLabel,
                AVG(TotalPrice) AS AverageSales
            FROM SalesHistoryTable
            -- Exclude transactions without a valid date
            WHERE SaleDate IS NOT NULL
            GROUP BY {1}
            ORDER BY {1};
        ", timePeriod.ToUpper(), dateGroupingColumn)
    End Function
End Class
