Imports Microsoft.Data.SqlClient

Public Class CarwashDatabaseHelper
    Private ReadOnly constr
    Public Sub New(connectionString As String)
        Me.constr = connectionString
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
            Dim query As String = "SELECT COUNT(*) FROM AppointmentsTable
                                 WHERE CAST(AppointmentDateTime AS DATE) = CAST(GETDATE() AS DATE)
                                 AND AppointmentStatus = 'Confirmed'"
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