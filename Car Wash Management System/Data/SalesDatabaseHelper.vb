Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class SalesDatabaseHelper
    Private ReadOnly constr As String
    Private ReadOnly comboBoxPaymentMethod As ComboBox
    Private ReadOnly textBoxCustomerName As TextBox
    Private ReadOnly textBoxCustomerID As TextBox

    Private ReadOnly printData As PrintDataInSales
    Public Sub New(connectionString As String, paymentMethodComboBox As ComboBox, customerNameTextBox As TextBox, customerIDTextBox As TextBox)
        Me.constr = connectionString
        Me.comboBoxPaymentMethod = paymentMethodComboBox
        Me.textBoxCustomerName = customerNameTextBox
        Me.textBoxCustomerID = customerIDTextBox
    End Sub

    Public Sub AddSale(customerID As Integer, baseServiceID As Integer, addonServiceID As Integer?, paymentMethod As String, totalPrice As Decimal)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery = "INSERT INTO SalesHistoryTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPrice)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@CustomerID", customerID)
                    cmd.Parameters.AddWithValue("@ServiceID", baseServiceID)
                    ' Handle the nullable addonServiceID parameter
                    If addonServiceID.HasValue Then
                        cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                    Else
                        cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                    End If
                    cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now)
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod)
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice)
                    cmd.ExecuteNonQuery()
                    Carwash.NotificationLabel.Text = "New Sale Added"
                    Carwash.ShowNotification()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error adding sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Function ViewSales() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Join to the ServicesTable for the addon as well to show the full service name.
                Dim selectQuery = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s 
                                  INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID 
                                  INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID 
                                  LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SalesID DESC"
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

    Public Function GetCustomerID(customerName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim customerID As Integer = 0
            Try
                con.Open()
                Dim selectQuery = "SELECT CustomerID FROM CustomersTable WHERE Name = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", customerName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        customerID = CType(result, Integer)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return customerID
        End Using
    End Function

    Public Function GetServiceID(serviceName As String) As SalesService
        Using con As New SqlConnection(constr)
            Dim details As New SalesService()
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
    Public Sub PopulateBaseServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 0 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving base services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateAddonServicesForUI(targetComboBox As ComboBox)
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Filter by both the Addon flag and the specific service names
                Dim selectQuery = "SELECT ServiceID, ServiceName FROM ServicesTable WHERE Addon = 1 ORDER BY ServiceName"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        targetComboBox.DataSource = dt
                        targetComboBox.DisplayMember = "ServiceName"
                        targetComboBox.ValueMember = "ServiceID"
                        targetComboBox.DropDownStyle = ComboBoxStyle.DropDownList
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving addon services: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Public Sub PopulateCustomerNames()
        Dim customerNames As New AutoCompleteStringCollection()
        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM CustomersTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            customerNames.Add(reader.GetString(0))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Me.textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.textBoxCustomerName.AutoCompleteCustomSource = customerNames
    End Sub
    Public Sub PopulateCustomerServices()
        Dim customerServices As New AutoCompleteStringCollection()

        Using con As New SqlConnection(constr)
            Dim sql As String = "SELECT Name FROM ServiceTable"
            Using cmd As New SqlCommand(sql, con)
                Try
                    con.Open()
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) Then
                            customerServices.Add(reader.GetString(0))
                        End If
                    End While
                Catch ex As Exception
                    MessageBox.Show("Error fetching customer names for autocomplete: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Me.textBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.textBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.textBoxCustomerName.AutoCompleteCustomSource = customerServices
    End Sub
    Public Sub PopulatePaymentMethod()
        Me.comboBoxPaymentMethod.Items.Add("Cash")
        Me.comboBoxPaymentMethod.Items.Add("Gcash")
        Me.comboBoxPaymentMethod.Items.Add("Cheque")
        Me.comboBoxPaymentMethod.SelectedIndex = 0
    End Sub

End Class
