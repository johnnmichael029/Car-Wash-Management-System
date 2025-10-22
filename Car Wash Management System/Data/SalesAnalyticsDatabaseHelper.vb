Imports Microsoft.Data.SqlClient



Public Class SalesAnalyticsDatabaseHelper
    Private Shared constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Shared Function GetOrders() As Decimal
        Dim totalSales As Decimal = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT 
                                        COUNT(CASE 
                                        WHEN SaleDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0) THEN SalesID 
                                        ELSE 0
                                    END) AS SinceLastMonthSales             
                                    FROM SalesHistoryTable"

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
    Public Shared Function GetCustomers() As Decimal
        Dim totalSales As Decimal = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT 
                                        COUNT(CASE 
                                        WHEN RegistrationDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0) THEN CustomerID 
                                        ELSE 0
                                    END) AS SinceLastMonthSales             
                                    FROM CustomersTable"
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
    Public Shared Function GetEarnings() As Decimal
        Dim totalSales As Decimal = 0
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT
                                    SUM(CASE 
                                        WHEN SaleDate >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0) THEN TotalPrice
                                        ELSE 0 
                                    END) AS SinceLastMonthSales
                                   FROM 
                                   SalesHistoryTable;"
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
End Class
