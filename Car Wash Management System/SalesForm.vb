Imports Microsoft.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms

Public Class SalesForm
    ' The connection string to your database.
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"

    ' Pass the UI controls to the management class.
    Private ReadOnly salesHistoryManagement As SalesHistoryManagement

    Public Sub New()
        InitializeComponent()

        ' Pass the UI controls to the management class, including the new TextBoxCustomerID.
        salesHistoryManagement = New SalesHistoryManagement(constr, ComboBoxPaymentMethod, TextBoxCustomerName, TextBoxCustomerID)
    End Sub

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        salesHistoryManagement.PopulateCustomerNames()
        salesHistoryManagement.PopulatePaymentMethod()
        salesHistoryManagement.PopulateBaseServicesForUI(ComboBoxServices)
        salesHistoryManagement.PopulateAddonServicesForUI(ComboBoxAddons)
        DataGridView1.DataSource = salesHistoryManagement.ViewSales()
        ClearFields()
    End Sub

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        Try
            ' The CustomerID is now retrieved directly from the textbox, which is updated via the TextChanged event.
            Dim customerID As Integer
            If Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Then
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim totalPrice As Decimal
            If Not Decimal.TryParse(TextBoxPrice.Text, totalPrice) Then
                MessageBox.Show("Please enter a valid price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Determine the service name and ID based on both combo boxes.
            Dim baseServiceName As String = If(ComboBoxServices.SelectedIndex <> -1, ComboBoxServices.Text, String.Empty)
            Dim addonServiceName As String = If(ComboBoxAddons.SelectedIndex <> -1, ComboBoxAddons.Text, String.Empty)
            Dim fullServiceName As String = baseServiceName
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                fullServiceName = fullServiceName & " + " & addonServiceName
            End If

            If String.IsNullOrWhiteSpace(baseServiceName) Then
                MessageBox.Show("Please select a base service.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            If ComboBoxPaymentMethod.SelectedIndex = -1 Then
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            ' Get the separate Service IDs for the base service and the addon.
            Dim baseServiceID As Integer = salesHistoryManagement.GetServiceID(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                addonServiceID = salesHistoryManagement.GetServiceID(addonServiceName)
            End If

            salesHistoryManagement.AddSale(customerID, baseServiceID, addonServiceID, ComboBoxPaymentMethod.SelectedItem.ToString(), totalPrice)

            DataGridView1.DataSource = salesHistoryManagement.ViewSales()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ClearFields()
    End Sub

    Private Sub ComboBoxServices_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxServices.SelectedIndexChanged
        If ComboBoxServices.SelectedIndex <> -1 Then
            Dim serviceName As String = ComboBoxServices.Text
            Dim price As Decimal = salesHistoryManagement.GetServicePrice(serviceName)
            TextBoxPrice.Text = price.ToString("N2") ' Format to 2 decimal places.
        Else
            TextBoxPrice.Text = "0.00"
        End If
    End Sub

    Private Sub ComboBoxAddons_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAddons.SelectedIndexChanged
        If ComboBoxAddons.SelectedIndex <> -1 AndAlso ComboBoxServices.SelectedIndex <> -1 Then
            Dim addonName As String = ComboBoxAddons.Text
            Dim addonPrice As Decimal = salesHistoryManagement.GetServicePrice(addonName)

            Dim currentPrice As Decimal
            If Decimal.TryParse(TextBoxPrice.Text, currentPrice) Then
                TextBoxPrice.Text = (currentPrice + addonPrice).ToString("N2")
            End If
        End If
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Dim customerID As Integer = salesHistoryManagement.GetCustomerID(TextBoxCustomerName.Text)
        If customerID > 0 Then
            TextBoxCustomerID.Text = customerID.ToString()
        Else
            TextBoxCustomerID.Text = String.Empty ' Clear the ID if no match is found.
        End If
    End Sub

    Private Sub clearBtn_Click(sender As Object, e As EventArgs) Handles clearBtn.Click
        ClearFields()

    End Sub
    Public Sub ClearFields()
        TextBoxCustomerName.Clear()
        TextBoxCustomerID.Clear()
        TextBoxPrice.Text = "0.00"
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddons.SelectedIndex = -1
        ComboBoxPaymentMethod.SelectedIndex = -1
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class

Public Class SalesHistoryManagement
    Private ReadOnly constr As String
    Private ReadOnly comboBoxPaymentMethod As ComboBox
    Private ReadOnly textBoxCustomerName As TextBox
    Private ReadOnly textBoxCustomerID As TextBox

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
                ' We now need to insert both ServiceIDs into the sales history.
                ' This will require adding a new column to SalesHistoryTable.
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
                    MessageBox.Show("Sale added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                Dim selectQuery = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SaleDate DESC"
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

    Public Function GetServiceID(serviceName As String) As Integer
        Using con As New SqlConnection(constr)
            Dim serviceID As Integer = 0
            Try
                con.Open()
                Dim selectQuery = "SELECT ServiceID FROM ServicesTable WHERE ServiceName = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", serviceName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        serviceID = CType(result, Integer)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving service ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return serviceID
        End Using
    End Function

    Public Function GetServicePrice(serviceName As String) As Decimal
        Using con As New SqlConnection(constr)
            Dim price As Decimal = 0.0D
            Try
                con.Open()
                Dim selectQuery = "SELECT Price FROM ServicesTable WHERE ServiceName = @Name"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@Name", serviceName)
                    Dim result = cmd.ExecuteScalar()
                    If Not IsDBNull(result) AndAlso result IsNot Nothing Then
                        price = CType(result, Decimal)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error retrieving service price: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return price
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
