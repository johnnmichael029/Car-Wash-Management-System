Imports System.Drawing.Printing
Imports System.Security.Cryptography.Xml
Imports System.Transactions
Imports Microsoft.Data.SqlClient

Public Class AppointmentManagementDatabaseHelper
    Private Shared constr As String

    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Sub AddAppointment(customerID As Integer, allSaleItems As List(Of SalesService), appointmentDateTime As DateTime, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, appointmentStatus As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' 1. Fix SQL Syntax and retrieve the new ID using SCOPE_IDENTITY()
                ' NOTE: Missing comma between @ReferenceID and @Price in the original SQL
                Dim insertQuery As String = "INSERT INTO AppointmentsTable (CustomerID, AppointmentDateTime, PaymentMethod, ReferenceID, Price, AppointmentStatus, Notes) " &
                                            "VALUES (@CustomerID, @AppointmentDateTime, @PaymentMethod, @ReferenceID, @Price, @AppointmentStatus, @Notes);" &
                                            "SELECT CAST(SCOPE_IDENTITY() AS INT);"

                Dim newAppointmentID As Integer = 0

                Using cmd As New SqlCommand(insertQuery, con, transaction) ' <-- FIX 1: Added transaction to cmd
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                    cmd.Parameters.AddWithValue("@Notes", notes)

                    ' ExecuteScalar returns the ID of the newly inserted row (SCOPE_IDENTITY())
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        newAppointmentID = Convert.ToInt32(result)
                    Else
                        Throw New Exception("Failed to retrieve the new Appointment ID.")
                    End If
                End Using

                ' Ensure the ID was retrieved before proceeding to insert services
                If newAppointmentID = 0 Then
                    Throw New Exception("Appointment was inserted, but the new ID could not be retrieved.")
                End If

                ' Assuming SalesServiceTable is now AppointmentServiceTable or related
                Dim insertServiceQuery = "INSERT INTO AppointmentServiceTable (AppointmentID, CustomerID, ServiceID, AddonServiceID, Subtotal, AppointmentStatus) VALUES (@AppointmentID, @CustomerID, @ServiceID, @AddonServiceID, @Subtotal, @AppointmentStatus)"

                For Each item As SalesService In allSaleItems
                    ' Assuming these helper functions are available in SalesDatabaseHelper
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)

                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdService.Parameters.AddWithValue("@AppointmentID", newAppointmentID) ' Use the new ID
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)

                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", CType(DBNull.Value, Object))
                        End If

                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)
                        cmdService.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)

                        cmdService.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit() ' Commit the entire operation if successful

            Catch ex As Exception
                ' Only rollback if the transaction object exists and is still active
                If transaction IsNot Nothing Then
                    transaction.Rollback()
                End If
                ' IMPORTANT: Using Throw here so the calling code can handle the error, 
                ' or keep the MessageBox if you prefer to handle it fully here.
                MessageBox.Show("Error adding appointment: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
    Public Function ViewAppointment() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to select all contracts.

            Dim aggregateServiceNamesQuery =
            "SELECT " &
                "ast.AppointmentID, " &
                "STRING_AGG(sv_base.ServiceName, ', ') AS AllServices, " &
                "STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "FROM AppointmentServiceTable ast " &
            "INNER JOIN ServicesTable sv_base ON ast.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON ast.AddonServiceID = sv_addon.ServiceID " &
            "GROUP BY ast.AppointmentID"

            Dim selectQuery As String = "SELECT " &
                "a.AppointmentID, " &
                "c.Name + ' ' + LastName AS CustomerName, " &
                "agg.Allservices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "a.AppointmentDateTime, " &
                "a.PaymentMethod, " &
                "a.ReferenceID, " &
                "a.Price, " &
                "a.AppointmentStatus, " &
                "a.Notes " &
            "FROM AppointmentsTable a " &
            "INNER JOIN CustomersTable c ON a.CustomerID = c.CustomerID " &
            "LEFT JOIN (" & aggregateServiceNamesQuery & ") agg ON a.AppointmentID = agg.AppointmentID " &
            "ORDER BY a.AppointmentID DESC"

            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function
    Public Sub UpdateAppointment(appointmentID As Integer, customerID As Integer, allSaleItems As List(Of AppointmentService), appointmentDateTime As Date, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, appointmentStatus As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' SQL query to update a Appointment.
                Dim updateAppointmentQuery As String = "UPDATE AppointmentsTable SET CustomerID = @CustomerID, AppointmentDateTime = @AppointmentDateTime, PaymentMethod = @PaymentMethod, ReferenceID = @ReferenceID, Price = @Price, AppointmentStatus = @AppointmentStatus, Notes = @Notes WHERE AppointmentID = @AppointmentID"
                Using cmd As New SqlCommand(updateAppointmentQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                    cmd.Parameters.AddWithValue("@Notes", notes)
                    cmd.ExecuteNonQuery()
                End Using
                ' Step 2: Delete existing entries in AppointmentServiceTable and SalesHistoryTable for this SalesID
                Dim deleteServicesQuery = "DELETE FROM AppointmentServiceTable WHERE AppointmentID = @AppointmentID"
                Using cmdDelete As New SqlCommand(deleteServicesQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                Dim deleteSalesServicesFromHistoryQuery = "DELETE FROM SalesHistoryTable WHERE AppointmentID = @AppointmentID"
                Using cmdDelete As New SqlCommand(deleteSalesServicesFromHistoryQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@AppointmentID", appointmentID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                ' Add the new sales services to SalesHistoryTable if needed
                Dim insertSalesHistoryQuery = "INSERT INTO SalesHistoryTable (CustomerID, SaleDate, PaymentMethod, AppointmentID, ServiceID, AddonServiceID, TotalPrice) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @AppointmentID, @ServiceID, @AddonServiceID, @TotalPrice)"
                For Each item As AppointmentService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdHistory As New SqlCommand(insertSalesHistoryQuery, con, transaction)
                        cmdHistory.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdHistory.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                        cmdHistory.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                        cmdHistory.Parameters.AddWithValue("@AppointmentID", appointmentID)
                        cmdHistory.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdHistory.Parameters.AddWithValue("@TotalPrice", item.ServicePrice)
                        cmdHistory.ExecuteNonQuery()
                    End Using
                Next
                ' Step 3: Insert new entries into AppointmentServiceTable
                Dim insertAppointmentServiceQuery = "INSERT INTO AppointmentServiceTable (AppointmentID, CustomerID, ServiceID, AddonServiceID, Subtotal, AppointmentStatus) VALUES (@AppointmentID, @CustomerID, @ServiceID, @AddonServiceID, @Subtotal, @AppointmentStatus)"
                For Each item As AppointmentService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertAppointmentServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@AppointmentID", appointmentID)
                        cmdService.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)
                        cmdService.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                        cmdService.ExecuteNonQuery()
                    End Using
                Next
                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error updating sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    ''' <summary>
    ''' Gets all Sale line items.
    ''' </summary>
    Public Shared Function GetSaleLineItems(appointmentID As Integer, constr As String) As List(Of ServiceLineItem)
        Dim items As New List(Of ServiceLineItem)()

        ' This query retrieves the subtotal, base service name, and addon service name 
        ' for a given SaleID by joining SalesServiceTable with ServicesTable twice.
        Dim sql As String = "
        SELECT 
            AST.Subtotal,
            ST_BASE.ServiceName AS BaseServiceName,
            ST_ADDON.ServiceName AS AddonServiceName
        FROM 
            AppointmentServiceTable AS AST
        LEFT JOIN 
            ServicesTable AS ST_BASE ON AST.ServiceID = ST_BASE.ServiceID
        LEFT JOIN 
            ServicesTable AS ST_ADDON ON AST.AddonServiceID = ST_ADDON.ServiceID
        WHERE 
            AST.AppointmentID = @AppointmentID
        ORDER BY 
            AST.AppointmentServiceID ASC;
    "

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)

                Try
                    conn.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim subtotal As Decimal = Convert.ToDecimal(reader("Subtotal"))
                        Dim baseServiceName As String = reader("BaseServiceName").ToString()

                        ' Safely retrieve AddonServiceName, converting DBNull to an empty string.
                        Dim addonServiceName As String = If(reader("AddonServiceName") Is DBNull.Value, "", reader("AddonServiceName").ToString())

                        Dim lineItemName As String = ""

                        ' Check if a base service exists for this line item.
                        If Not String.IsNullOrEmpty(baseServiceName) Then
                            ' Start with the Base Service Name
                            lineItemName = baseServiceName

                            ' Append the Add-on Service Name if it exists
                            If Not String.IsNullOrEmpty(addonServiceName) Then
                                lineItemName &= " + " & addonServiceName
                            End If
                            items.Add(New ServiceLineItem With {
                            .Name = lineItemName,
                            .Price = subtotal
                        })
                        End If
                    End While
                    reader.Close()

                Catch ex As Exception
                    MessageBox.Show("Error retrieving sale line items: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return items
    End Function
    ''' <summary>
    ''' Gets all Service List from AppointmentServiceTable
    ''' </summary>
    Public Shared Function GetSalesServiceList(appointmentID As Integer) As List(Of AppointmentService)
        Dim serviceList As New List(Of AppointmentService)
        Dim selectQuery As String = "SELECT " &
                                "ast.AppointmentServiceID, " &
                                "S_Base.ServiceName AS Service, " &
                                "ISNULL(S_Addon.ServiceName, 'None') AS Addon, " &
                                "ast.Subtotal AS ServicePrice, " &
                                "ast.ServiceID, " &
                                "ast.AddonServiceID " &
                                "FROM AppointmentServiceTable ast " &
                                "INNER JOIN ServicesTable S_Base ON ast.ServiceID = S_Base.ServiceID " &
                                "LEFT JOIN ServicesTable S_Addon ON ast.AddonServiceID = S_Addon.ServiceID " &
                                "WHERE ast.AppointmentID = @AppointmentID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim item As New AppointmentService() With {
                            .Service = reader.GetString(reader.GetOrdinal("Service")),
                            .Addon = reader.GetString(reader.GetOrdinal("Addon")),
                            .ServicePrice = reader.GetDecimal(reader.GetOrdinal("ServicePrice"))
                        }
                            serviceList.Add(item)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error when loading sale services list: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using


        Return serviceList
    End Function
End Class

