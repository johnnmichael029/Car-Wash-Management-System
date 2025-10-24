Imports Microsoft.Data.SqlClient

Public Class CarwashDatabaseHelper
    Private Shared constr
    Public Property CurrentDayEarnings As Decimal
    Public Property PreviousDayEarnings As Decimal
    Public Property PercentageChangeEarnings As Decimal
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    ''' <summary>
    ''' Gets the total sales for today from the SalesHistoryTable.
    ''' </summary>
    Public Function GetTodayTotalSales() As Decimal
        Dim totalSales As Decimal = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT SUM(TotalPrice) FROM SalesHistoryTable WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
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

    Public Shared Function GetEarningsData() As CarwashDatabaseHelper
        ' NOTE: Assuming CarwashDatabaseHelper now has CurrentDayEarnings, PreviousDayEarnings, 
        ' and PercentageChangeEarnings properties of type Decimal.
        Dim data As New CarwashDatabaseHelper(constr) With {.CurrentDayEarnings = 0D, .PreviousDayEarnings = 0D, .PercentageChangeEarnings = 0D}

        Using con As New SqlConnection(constr)
            Dim query As String = "
            SELECT
                -- 1. Total Earnings for the Current Day
                SUM(CASE 
                    WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE) THEN TotalPrice
                    ELSE 0
                END) AS CurrentDayEarnings,

                -- 2. Total Earnings for the Previous Day
                SUM(CASE 
                    WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() - 1 AS DATE) THEN TotalPrice
                    ELSE 0
                END) AS PreviousDayEarnings,

                -- 3. Calculate the Percentage Change (Day-over-Day Logic)
                CAST(
                    CASE
                        -- Define Previous Day Sales for calculation:
                        WHEN SUM(CASE WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() - 1 AS DATE) THEN TotalPrice ELSE 0 END) > 0
                        THEN (
                            (
                                SUM(CASE WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE) THEN TotalPrice ELSE 0 END)    -- Current Day Total
                                - 
                                SUM(CASE WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() - 1 AS DATE) THEN TotalPrice ELSE 0 END)  -- Previous Day Total
                            )
                            * 100.0 
                            / SUM(CASE WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() - 1 AS DATE) THEN TotalPrice ELSE 0 END) -- Previous Day Total
                        )
                        
                        -- Case B: Previous Day Sales = 0, Current Day Sales > 0 (Growth from zero base)
                        WHEN SUM(CASE WHEN CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE) THEN TotalPrice ELSE 0 END) > 0
                        THEN 100.0
                        
                        -- Case C: Both are 0 or no change
                        ELSE 0.0
                    END
                AS DECIMAL(10, 2)) AS PercentageChangeEarnings
            FROM
                SalesHistoryTable;" ' **Check your table name here**

            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Fetch all three calculated values
                            data.CurrentDayEarnings = Convert.ToDecimal(reader("CurrentDayEarnings"))
                            data.PreviousDayEarnings = Convert.ToDecimal(reader("PreviousDayEarnings"))
                            data.PercentageChangeEarnings = Convert.ToDecimal(reader("PercentageChangeEarnings"))
                        End If
                    End Using
                Catch ex As Exception
                    Console.WriteLine("Error in GetEarningsData: " & ex.Message)
                End Try
            End Using
        End Using

        Return data
    End Function

    ''' <summary>
    ''' Gets the total number of new customers registered today from the CustomersTable.
    ''' </summary>
    Public Function GetTotalNewCustomers() As Integer
        Dim totalNewCustomers As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM CustomersTable WHERE CAST(RegistrationDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalNewCustomers = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalNewCustomers: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalNewCustomers
    End Function
    ''' <summary>
    ''' Gets the total number of confirmed appointments scheduled for today from the AppointmentsTable.
    ''' </summary>
    Public Function GetTotalAppointments() As Integer
        Dim totalAppointments As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT
                    Count(*) FROM AppointmentsTable a
                    INNER JOIN AppointmentServiceTable ast On a.AppointmentID = ast.AppointmentID
                    WHERE CAST(AppointmentDateTime As Date) = CAST(GETDATE() As Date)  
                    And ast.AppointmentStatus = 'Confirmed'"

            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalAppointments = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalAppointments: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalAppointments
    End Function
    ''' <summary>
    ''' Gets the total number of new contracts created today from the ContractsTable.
    ''' </summary>
    Public Function GetTotalContracts() As Integer
        Dim totalContracts As Integer = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM ContractsTable WHERE CAST(StartDate AS DATE) = CAST(GETDATE() AS DATE)"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    totalContracts = Convert.ToInt32(cmd.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error in GetTotalContracts: " & ex.Message)
                End Try
            End Using
        End Using
        Return totalContracts
    End Function
    ''' <summary>
    ''' Gets the list of sales records matching the search string from the SalesHistoryTable along with Customer and Service details.
    ''' </summary>
End Class