Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class AppointmentManagementDatabaseHelper
    Private ReadOnly constr As String

    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub

    Public Sub AddAppointment(customerID As Integer, allSaleItems As List(Of AppointmentService), appointmentDateTime As DateTime, paymentMethod As String, referenceID As String, price As Decimal, appointmentStatus As String, notes As String)
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
                    cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID)) ' Handle null/empty referenceID
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

                For Each item As AppointmentService In allSaleItems
                    ' Assuming these helper functions are available in SalesDatabaseHelper
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)

                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction) ' <-- FIX 2: Added transaction to cmdService
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
                "c.Name AS CustomerName, " &
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

    Public Sub UpdateAppointment(appointmentID As Integer, customerID As Integer, serviceID As Integer, addonServiceID As Integer?, appointmentDateTime As Date, paymentMethod As String, price As Decimal, appointmentStatus As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to update a contract.
            Dim updateQuery As String = "UPDATE AppointmentsTable SET CustomerID = @CustomerID, ServiceID = @ServiceID, AddonServiceID = @AddonServiceID, AppointmentDateTime = @AppointmentDateTime, PaymentMethod = @PaymentMethod, Price = @Price, AppointmentStatus = @AppointmentStatus, Notes = @Notes WHERE AppointmentID = @AppointmentID"
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
                cmd.Parameters.AddWithValue("@ContractID", appointmentID)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)

                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@AppointmentDateTime", appointmentDateTime)
                cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@AppointmentStatus", appointmentStatus)
                cmd.Parameters.AddWithValue("@Notes", notes)
                cmd.ExecuteNonQuery()
            End Using
            'If appointmentStatus.ToLower() = "completed" Then
            '    Dim insertSaleQuery As String = "INSERT INTO SalesHistoryTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPRice)"
            '    Using cmd2 As New SqlCommand(insertSaleQuery, con)
            '        cmd2.Parameters.AddWithValue("@CustomerID", customerID)
            '        cmd2.Parameters.AddWithValue("@ServiceID", serviceID)
            '        If addonServiceID.HasValue Then
            '            cmd2.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
            '        Else
            '            cmd2.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
            '        End If
            '        cmd2.Parameters.AddWithValue("SaleDate", appointmentDateTime)
            '        cmd2.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
            '        cmd2.Parameters.AddWithValue("@TotalPrice", price)
            '        cmd2.ExecuteNonQuery()
            '    End Using
            'End If
        End Using
    End Sub


    'Public Sub DeleteAppointment(appointmentID As String)
    '    If String.IsNullOrEmpty(appointmentID) Then
    '        MessageBox.Show("Please select appointment from the table to delete", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return
    '    End If
    '    Dim DialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
    '    If DialogResult = DialogResult.Yes Then

    '        Using con As New SqlConnection(constr)
    '            Try
    '                con.Open()
    '                ' SQL query to delete a contract.
    '                Dim deleteQuery As String = "DELETE FROM AppointmentsTable WHERE AppointmentID = @AppointmentID"
    '                Using cmd As New SqlCommand(deleteQuery, con)
    '                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID)
    '                    cmd.ExecuteNonQuery()
    '                    MessageBox.Show("Contract deleted successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                End Using
    '            Catch ex As Exception
    '                MessageBox.Show("An error occurred while deleting contract" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            Finally
    '                con.Close()
    '            End Try
    '        End Using
    '    End If
    'End Sub

    ''' <summary>
    ''' Gets all customer names from the database.
    ''' </summary>
    Public Function GetAllCustomerNames() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable ORDER BY Name"
            Using cmd As New SqlCommand(sql, con)
                con.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)

                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Gets a customer ID by name.
    ''' </summary>
    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            con.Open()
            Dim selectQuery As String = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", customerName)
                Dim result = cmd.ExecuteScalar()
                If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                    customerID = CType(result, Integer)
                End If
            End Using
            Return customerID
        End Using
    End Function

    ''' <summary>
    ''' Gets service details (ID and Price) by service name.
    ''' </summary>
    Public Function GetServiceDetails(serviceName As String) As AppointmentService
        Using con As New SqlConnection(constr)
            Dim details As New AppointmentService()
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, Price FROM ServicesTable WHERE ServiceName = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", serviceName)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        details.ServiceID = reader.GetInt32(0)
                        details.Price = reader.GetDecimal(1)
                    End If
                End Using
            End Using
            Return details
        End Using
    End Function

    ''' <summary>
    ''' Gets all non-addon services.
    ''' </summary>
    Public Function GetBaseServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

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
    Public Function GetSalesServiceList(appointmentID As Integer) As List(Of AppointmentService)
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
    ''' <summary>
    ''' Gets all addon services.
    ''' </summary>
    Public Function GetAddonServices() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Show Print Preview
    ''' </summary>
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub

End Class

