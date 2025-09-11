Imports Microsoft.Data.SqlClient



Public Class BillingContracts

    ' NOTE: This is an example, assuming this code is part of a form.
    ' You will need to add the actual UI components like TextBoxCustomerName,
    ' ComboBoxServices, etc. to your form designer.

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly billingContractsManagement As BillingContractsManagement

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the data access layer
        billingContractsManagement = New BillingContractsManagement(constr)
    End Sub

    Private Sub addServiceBtn_Click(sender As Object, e As EventArgs) Handles addServiceBtn.Click
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
            Dim addonServiceName As String = If(ComboBoxAddon.SelectedIndex <> -1, ComboBoxAddon.Text, String.Empty)
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
            Dim baseServiceDetails = billingContractsManagement.GetServiceDetails(baseServiceName)
            Dim addonServiceID As Integer? = Nothing ' Use a nullable integer for the addon service ID
            If Not String.IsNullOrWhiteSpace(addonServiceName) Then
                addonServiceID = billingContractsManagement.GetServiceDetails(addonServiceName)
            End If

            billingContractsManagement.AddContract(
                customerID,
                baseServiceDetails,
                addonServiceID,
                DateTimePickerStartDate.Value,
                If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing),
                ComboBoxBillingFrequency.Text,
                totalPrice,
                ComboBoxContractStatus.Text
            )

            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
        Catch ex As Exception
            MessageBox.Show("An error occurred while adding the sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        ClearFields()
    End Sub

    Private Sub BillingContracts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Populate UI components using the data returned from the management class
            Dim customerNames As DataTable = billingContractsManagement.GetAllCustomerNames()
            Dim customerNamesCollection As New AutoCompleteStringCollection()
            For Each row As DataRow In customerNames.Rows
                customerNamesCollection.Add(row("Name").ToString())
            Next
            TextBoxCustomerName.AutoCompleteCustomSource = customerNamesCollection
            TextBoxCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim baseServices As DataTable = billingContractsManagement.GetBaseServices()
            ComboBoxServices.DataSource = baseServices
            ComboBoxServices.DisplayMember = "ServiceName"
            ComboBoxServices.ValueMember = "ServiceID"
            ComboBoxServices.DropDownStyle = ComboBoxStyle.DropDownList

            Dim addonServices As DataTable = billingContractsManagement.GetAddonServices()
            ComboBoxAddon.DataSource = addonServices
            ComboBoxAddon.DisplayMember = "ServiceName"
            ComboBoxAddon.ValueMember = "ServiceID"
            ComboBoxAddon.DropDownStyle = ComboBoxStyle.DropDownList
            ComboBoxAddon.SelectedIndex = -1 ' Set to no selection by default

            ' This part is not in the management class anymore, as it's static UI logic
            ComboBoxPaymentMethod.Items.AddRange({"Cash", "Gcash", "Cheque"})
            ComboBoxPaymentMethod.SelectedIndex = 0

            ' Load existing contracts into the DataGridView when the form loads.
            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
            ClearFields()
        Catch ex As Exception
            MessageBox.Show("An error occurred during form loading: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBoxCustomerName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerName.TextChanged
        Try
            Dim customerID As Integer = billingContractsManagement.GetCustomerID(TextBoxCustomerName.Text)
            If customerID > 0 Then
                TextBoxCustomerID.Text = customerID.ToString()
            Else
                TextBoxCustomerID.Text = String.Empty ' Clear the ID if no match is found.
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBoxCustomerID.Text = String.Empty
        End Try
    End Sub

    Private Sub updateServiceBtn_Click(sender As Object, e As EventArgs) Handles updateServiceBtn.Click
        Try
            Dim contractID As Integer
            Dim customerID As Integer
            Dim price As Decimal

            If Not Integer.TryParse(ContractID, contractID) Or Not Integer.TryParse(TextBoxCustomerID.Text, customerID) Or Not Decimal.TryParse(TextBoxPrice.Text, price) Then
                MessageBox.Show("Please enter valid numeric values for Contract ID, Customer ID, and Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim baseServiceDetails = billingContractsManagement.GetServiceDetails(ComboBoxServices.Text)
            Dim serviceID As Integer = baseServiceDetails
            Dim endDate As Date? = If(DateTimePickerEndDate.Checked, CType(DateTimePickerEndDate.Value, Date?), Nothing)

            billingContractsManagement.UpdateContract(
                contractID,
                customerID,
                serviceID,
                DateTimePickerStartDate.Value,
                endDate,
                ComboBoxBillingFrequency.Text,
                price,
                ComboBoxContractStatus.Text
            )
            DataGridView1.DataSource = billingContractsManagement.ViewContracts()
            ClearFields()
            MessageBox.Show("Contract updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating the contract: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ClearFields()
        ' Clear all input fields
        TextBoxCustomerID.Clear()
        TextBoxCustomerName.Clear()
        ComboBoxServices.SelectedIndex = -1
        ComboBoxAddon.SelectedIndex = -1
        DateTimePickerStartDate.Value = DateTime.Now
        DateTimePickerEndDate.Value = DateTime.Now
        DateTimePickerEndDate.Checked = False
        ComboBoxBillingFrequency.SelectedIndex = -1
        TextBoxPrice.Clear()
        ComboBoxContractStatus.SelectedIndex = -1
        ContractID.Text = String.Empty
    End Sub

    Private Sub deleteServiceBtn_Click(sender As Object, e As EventArgs) Handles deleteServiceBtn.Click

    End Sub
End Class

Public Class BillingContractsManagement
    Private ReadOnly constr As String

    Public Sub New(connectionString As String)
        Me.constr = connectionString
    End Sub

    Public Sub AddContract(customerID As Integer, serviceID As Integer, addonServiceID As Integer?, startDate As Date, endDate As Date?, billingFrequency As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to insert a new contract. Using parameters to prevent SQL injection.
            Dim insertQuery As String = "INSERT INTO BillingContracts (CustomerID, ServiceID, AddonServiceID, StartDate, EndDate, BillingFrequency, Price, ContractStatus) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @StartDate, @EndDate, @BillingFrequency, @Price, @ContractStatus)"
            Using cmd As New SqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                cmd.Parameters.AddWithValue("@StartDate", startDate)

                ' Handle the nullable EndDate parameter
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                Else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                End If
                If addonServiceID.HasValue Then
                    cmd.Parameters.AddWithValue("@AddonServiceID", addonServiceID.Value)
                Else
                    cmd.Parameters.AddWithValue("@AddonServiceID", DBNull.Value) ' Insert NULL if no addon is selected
                End If
                cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Retrieves all billing contracts from the database and returns them as a DataTable.
    ''' </summary>
    Public Function ViewContracts() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to select all contracts.
            Dim selectQuery As String = "SELECT ContractID, CustomerID, ServiceID, StartDate, EndDate, BillingFrequency, Price, ContractStatus FROM BillingContracts"
            Using cmd As New SqlCommand(selectQuery, con)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    ''' <summary>
    ''' Updates an existing billing contract in the database.
    ''' </summary>
    Public Sub UpdateContract(contractID As Integer, customerID As Integer, serviceID As Integer, startDate As Date, endDate As Date?, billingFrequency As String, price As Decimal, contractStatus As String)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to update a contract.
            Dim updateQuery As String = "UPDATE BillingContracts SET CustomerID = @CustomerID, ServiceID = @ServiceID, StartDate = @StartDate, EndDate = @EndDate, BillingFrequency = @BillingFrequency, Price = @Price, ContractStatus = @ContractStatus WHERE ContractID = @ContractID"
            Using cmd As New SqlCommand(updateQuery, con)
                cmd.Parameters.AddWithValue("@ContractID", contractID)
                cmd.Parameters.AddWithValue("@CustomerID", customerID)
                cmd.Parameters.AddWithValue("@ServiceID", serviceID)
                cmd.Parameters.AddWithValue("@StartDate", startDate)

                ' Handle the nullable EndDate parameter
                If endDate.HasValue Then
                    cmd.Parameters.AddWithValue("@EndDate", endDate.Value)
                Else
                    cmd.Parameters.AddWithValue("@EndDate", DBNull.Value)
                End If

                cmd.Parameters.AddWithValue("@BillingFrequency", billingFrequency)
                cmd.Parameters.AddWithValue("@Price", price)
                cmd.Parameters.AddWithValue("@ContractStatus", contractStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Deletes an existing billing contract from the database.
    ''' </summary>
    Public Sub DeleteContract(contractID As Integer)
        Using con As New SqlConnection(constr)
            con.Open()
            ' SQL query to delete a contract.
            Dim deleteQuery As String = "DELETE FROM BillingContracts WHERE ContractID = @ContractID"
            Using cmd As New SqlCommand(deleteQuery, con)
                cmd.Parameters.AddWithValue("@ContractID", contractID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

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
    Public Function GetServiceDetails(serviceName As String) As Decimal
        Using con As New SqlConnection(constr)
            Dim serviceID As Integer = 0
            Dim price As Decimal = 0.0D
            con.Open()
            Dim selectQuery As String = "SELECT ServiceID, Price FROM ServicesTable WHERE ServiceName = @Name"
            Using cmd As New SqlCommand(selectQuery, con)
                cmd.Parameters.AddWithValue("@Name", serviceName)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        serviceID = reader.GetInt32(0)
                        price = reader.GetDecimal(1)
                    End If
                End Using
            End Using
            Return price
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
End Class
