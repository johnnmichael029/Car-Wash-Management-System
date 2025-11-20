Imports System.Diagnostics.Contracts
Imports System.Security.Cryptography.Xml
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports Microsoft.Data.SqlClient
Public Class PickupManagementDatabaseHelper
    Private Shared constr As String

    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub

    Public Function ViewPickupData() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            Try
                ' Then we aggregate the resulting names into comma-separated strings.
                Dim aggregateServiceNamesQuery =
            "SELECT " &
                "pst.PickupID, " &
                "STRING_AGG(sv_base.ServiceName, ', ') AS AllServices, " &
                "STRING_AGG(sv_addon.ServiceName, ', ') AS AllAddonServices " &
            "FROM PickupServiceTable pst " &
            "INNER JOIN ServicesTable sv_base ON pst.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON pst.AddonServiceID = sv_addon.ServiceID " &
            "GROUP BY pst.PickupID"

                ' Step 2: Final query joins SalesHistoryTable to the aggregated names
                Dim selectQuery =
            "SELECT " &
                "p.PickupID, " &
                "c.Name + ' ' + c.LastName AS CustomerName, " &
                "agg.AllServices AS BaseServiceName, " &
                "agg.AllAddonServices AS AddonServiceName, " &
                "p.PickupDateTime, " &
                "p.PickupAddress, " &
                "p.PaymentMethod, " &
                "p.ReferenceID, " &
                "p.Price, " &
                "p.PickupStatus, " &
                "p.Detailer, " &
                "p.Notes " &
            "FROM PickupTable p " &
            "INNER JOIN CustomersTable c ON p.CustomerID = c.CustomerID " &
            "LEFT JOIN (" & aggregateServiceNamesQuery & ") agg ON p.PickupID = agg.PickupID " &
            "ORDER BY p.PickupID DESC"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred while retrieving pickup data: " & ex.Message)
            Finally
                con.Close()
            End Try
        End Using
        Return dt
    End Function

    Public Sub AddPickup(customerID As Integer, allSaleItems As List(Of PickupService), pickupDateTime As DateTime, pickupAddress As String, paymentMethod As String, referenceID As String, cheque As String, totalPrice As Decimal, pickupStatus As String, detailer As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                Dim newSalesID As Integer
                Dim insertHistoryQuery = "INSERT INTO PickupTable (CustomerID, PickupDateTime, PickupAddress, PaymentMethod, ReferenceID, Price, PickupStatus, Detailer, Notes ) VALUES (@CustomerID, @PickupDateTime, @PickupAddress, @PaymentMethod, @ReferenceID, @Price, @PickupStatus, @Detailer, @Notes); SELECT SCOPE_IDENTITY();"
                Using cmd As New SqlCommand(insertHistoryQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@PickupDateTime", pickupDateTime)
                    cmd.Parameters.AddWithValue("@PickupAddress", pickupAddress)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", totalPrice)
                    cmd.Parameters.AddWithValue("@PickupStatus", pickupStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)
                    cmd.Parameters.AddWithValue("@Notes", notes)
                    newSalesID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
                Dim insertServiceQuery = "INSERT INTO PickupServiceTable (PickupID, ServiceID, AddonServiceID, Subtotal) VALUES (@PickupID, @ServiceID, @AddonServiceID, @Subtotal)"

                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@PickupID", newSalesID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)

                        cmdService.ExecuteNonQuery()
                    End Using
                Next

                transaction.Commit()
                Carwash.NotificationLabel.Text = "Pickup Added"
                Carwash.ShowNotification()

            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Sub UpdatePickup(pickupID As Integer, customerID As Integer, allSaleItems As List(Of PickupService), pickupDateTime As DateTime, pickupAddress As String, paymentMethod As String, referenceID As String, cheque As String, price As Decimal, pickupStatus As String, detailer As String, notes As String)
        Using con As New SqlConnection(constr)
            con.Open()
            Dim transaction As SqlTransaction = con.BeginTransaction()
            Try
                ' SQL query to update a contract.
                Dim updateQuery As String = "UPDATE PickupTable SET CustomerID = @CustomerID, PickupDateTime = @PickupDateTime, PickupAddress = @PickupAddress, PaymentMethod = @PaymentMethod, ReferenceID = @ReferenceID, Price = @Price, PickupStatus = @PickupStatus, Detailer = @Detailer, Notes = @Notes WHERE PickupID = @PickupID"
                Using cmd As New SqlCommand(updateQuery, con, transaction)
                    cmd.Parameters.AddWithValue("@PickupID", pickupID)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@PickupDateTime", pickupDateTime)
                    cmd.Parameters.AddWithValue("@PickupAddress", pickupAddress)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    If paymentMethod = "Cheque" Then
                        cmd.Parameters.AddWithValue("@ReferenceID", cheque)
                    Else
                        cmd.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                    End If
                    cmd.Parameters.AddWithValue("@Price", price)
                    cmd.Parameters.AddWithValue("@PickupStatus", pickupStatus)
                    cmd.Parameters.AddWithValue("@Detailer", detailer)
                    cmd.Parameters.AddWithValue("@Notes", notes)
                    cmd.ExecuteNonQuery()
                End Using
                Dim deleteServicesQuery = "DELETE FROM PickupServiceTable WHERE PickupID = @PickupID"
                Using cmdDelete As New SqlCommand(deleteServicesQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@PickupID", pickupID)
                    cmdDelete.ExecuteNonQuery()
                End Using
                Dim deleteSalesServicesFromHistoryQuery = "DELETE FROM SalesHistoryTable WHERE PickupID = @PickupID"
                Using cmdDelete As New SqlCommand(deleteSalesServicesFromHistoryQuery, con, transaction)
                    cmdDelete.Parameters.AddWithValue("@PickupID", pickupID)
                    cmdDelete.ExecuteNonQuery()
                End Using

                Dim insertSalesHistoryQuery = "INSERT INTO SalesHistoryTable (CustomerID, SaleDate, PaymentMethod, ReferenceID, PickupID, ServiceID, AddonServiceID, TotalPrice, Detailer, Form) VALUES (@CustomerID, @SaleDate, @PaymentMethod, @ReferenceID, @PickupID, @ServiceID, @AddonServiceID, @TotalPrice, @Detailer, @Form)"
                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdHistory As New SqlCommand(insertSalesHistoryQuery, con, transaction)
                        cmdHistory.Parameters.AddWithValue("@CustomerID", customerID)
                        cmdHistory.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                        cmdHistory.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                        If paymentMethod = "Cheque" Then
                            cmdHistory.Parameters.AddWithValue("@ReferenceID", cheque)
                        Else
                            cmdHistory.Parameters.AddWithValue("@ReferenceID", If(String.IsNullOrEmpty(referenceID), CType(DBNull.Value, Object), referenceID))
                        End If
                        cmdHistory.Parameters.AddWithValue("@PickupID", pickupID)
                        cmdHistory.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdHistory.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdHistory.Parameters.AddWithValue("@TotalPrice", item.ServicePrice)
                        cmdHistory.Parameters.AddWithValue("@Detailer", detailer)
                        cmdHistory.Parameters.AddWithValue("@Form", "Pickup-Sale")
                        cmdHistory.ExecuteNonQuery()
                    End Using
                Next

                Dim insertServiceQuery = "INSERT INTO PickupServiceTable (PickupID, ServiceID, AddonServiceID, Subtotal) VALUES (@PickupID, @ServiceID, @AddonServiceID, @Subtotal)"
                For Each item As PickupService In allSaleItems
                    Dim baseServiceID As Integer = SalesDatabaseHelper.GetServiceIdByName(item.Service)
                    Dim addonID As Integer? = SalesDatabaseHelper.GetAddonIdByName(item.Addon)
                    Using cmdService As New SqlCommand(insertServiceQuery, con, transaction)
                        cmdService.Parameters.AddWithValue("@PickupID", pickupID)
                        cmdService.Parameters.AddWithValue("@ServiceID", baseServiceID)
                        If addonID.HasValue Then
                            cmdService.Parameters.AddWithValue("@AddonServiceID", addonID.Value)
                        Else
                            cmdService.Parameters.AddWithValue("@AddonServiceID", DBNull.Value)
                        End If
                        cmdService.Parameters.AddWithValue("@Subtotal", item.ServicePrice)
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

    ' Get list of services for a specific pickup
    Public Shared Function GetSalesServiceList(pickupID As Integer) As List(Of PickupService)
        Dim serviceList As New List(Of PickupService)
        Dim selectQuery As String = "SELECT " &
                                "PST.PickupServiceID, " &
                                "S_Base.ServiceName AS Service, " &
                                "ISNULL(S_Addon.ServiceName, 'None') AS Addon, " &
                                "PST.Subtotal AS ServicePrice, " &
                                "PST.ServiceID, " &
                                "PST.AddonServiceID " &
                                "FROM PickupServiceTable PST " &
                                "INNER JOIN ServicesTable S_Base ON PST.ServiceID = S_Base.ServiceID " &
                                "LEFT JOIN ServicesTable S_Addon ON PST.AddonServiceID = S_Addon.ServiceID " &
                                "WHERE PST.PickupID = @PickupID"

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@PickupID", pickupID)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim item As New PickupService() With {
                            .Service = reader.GetString(reader.GetOrdinal("Service")),
                            .Addon = reader.GetString(reader.GetOrdinal("Addon")),
                            .ServicePrice = reader.GetDecimal(reader.GetOrdinal("ServicePrice"))
                        }
                            serviceList.Add(item)
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Database Error when loading pikcup services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
        Return serviceList
    End Function
End Class
