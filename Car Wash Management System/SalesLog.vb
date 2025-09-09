
Imports Microsoft.Data.SqlClient
Imports System.Data

Public Class SalesLog
    ' This class contains the logic for the main sales form.

    Dim sql As String
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim adapter As New SqlDataAdapter
    Dim salesID As String = ""

    Private ReadOnly newSalesLogic As CarWashSales

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Instantiate the new sales logic class and pass the required UI controls.
        ' The newSalesLogic instance will handle price updates, adding, and updating sales.
        Me.newSalesLogic = New CarWashSales(ComboBoxVehicle, ComboBoxService, TextBoxPrice, TextBoxSales, constr)
    End Sub

    ' This method generates a new sales ID, either by incrementing the last ID or starting a new year.

    Private Sub SalesLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CenterToParent()
        Me.newSalesLogic.GenerateSalesID()
        DisplayTable()
    End Sub

    ' This handles the create button click event. It now uses the new AddSaleToDatabase method from the CarWashSales class.
    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        Me.newSalesLogic.AddSaleToDatabase()
        ClearFields()
        DisplayTable()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    ' Displays the sales table in the DataGridView.
    Public Function DisplayTable() As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT id, sales_id, vehicle, service, price, date FROM salesTable"
                Using cmd As New SqlCommand(selectQuery, con)
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                        DataGridView1.DataSource = dt
                        DataGridView1.Refresh()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error viewing customers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        Return dt
    End Function



    ' This handles the delete button click event.
    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        DeleteSaleInDatabase()
        ClearFields()
        DisplayTable()
    End Sub

    ' This handles the DataGridView cell click event to populate text boxes with selected row data.
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxSales.Text = DataGridView1.CurrentRow.Cells("sales_id").Value
        ComboBoxVehicle.Text = DataGridView1.CurrentRow.Cells("vehicle").Value
        ComboBoxService.Text = DataGridView1.CurrentRow.Cells("service").Value
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells("Price").Value
    End Sub

    ' This handles the update button click event. It now uses the new UpdateSaleInDatabase method from the CarWashSales class.
    Private Sub updateBtn_Click(sender As Object, e As EventArgs) Handles updateBtn.Click
        Me.newSalesLogic.UpdateSaleInDatabase()
        ClearFields()
        DisplayTable()
    End Sub

    ' This handles the read button click event.
    Private Sub readBtn_Click(sender As Object, e As EventArgs) Handles readBtn.Click
        DisplayTable()
        ClearFields()
    End Sub

    ' Displays a generic error message. The new class provides more specific messages.
    Sub errorMessageBox()
        MessageBox.Show("Please fill In all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ' Clears the form fields.
    Sub ClearFields()
        ComboBoxVehicle.Text = ""
        TextBoxPrice.Text = ""
        ComboBoxService.Text = ""
        Me.newSalesLogic.GenerateSalesID()
    End Sub

    ' The following methods are now handled by the new CarWashSales class.
    Private Sub AddSaleToDatabase()
        Dim price As Integer
        Dim service As String = ComboBoxService.Text
        Dim vehicle As String = ComboBoxVehicle.Text
        service = 150
        vehicle = 100
        price = service + vehicle
        If ComboBoxVehicle.Text = "" Or ComboBoxService.Text = "" Then
            errorMessageBox()
            Return

        ElseIf TextBoxPrice.Text <= 0 Then
            MessageBox.Show("Price cannot be negative or 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not Integer.TryParse(TextBoxPrice.Text, price) Then
            MessageBox.Show("Please enter a whole number for the price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf ComboBoxVehicle.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vehicle type from the list.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf ComboBoxService.SelectedIndex = -1 Then
            MessageBox.Show("Please select a vehicle type from the list.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' NOTE: Using a parameterized query to check for existing sales ID is crucial for security.
                Dim checkSql As String = "SELECT COUNT(*) FROM salesTable WHERE sales_id = @SalesID"
                Using checkCmd As New SqlCommand(checkSql, con)
                    checkCmd.Parameters.AddWithValue("@SalesID", TextBoxSales.Text)
                    Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Record with this ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' --- Insert the new record ---
                ' This is the safe, parameterized INSERT statement.
                Dim insertSql As String = "INSERT INTO salesTable (sales_id, vehicle, service, price, date) VALUES (@Sales, @Vehicle, @Service, @Price, @Date)"
                Using insertCmd As New SqlCommand(insertSql, con)
                    insertCmd.Parameters.AddWithValue("@Sales", TextBoxSales.Text)
                    insertCmd.Parameters.AddWithValue("@Vehicle", ComboBoxVehicle.Text)
                    insertCmd.Parameters.AddWithValue("@Service", ComboBoxService.Text)
                    insertCmd.Parameters.AddWithValue("@Price", price)
                    insertCmd.Parameters.AddWithValue("@Date", Now.ToString())
                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ClearFields()
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub UpdateSaleInDatabase()
        Dim price As Integer
        If TextBoxSales.Text = "" Or ComboBoxVehicle.Text = "" Or TextBoxPrice.Text = "" Then
            errorMessageBox()
            Return

        ElseIf Not IsNumeric(TextBoxPrice.Text) Then
            MessageBox.Show("Please enter a valid number for price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        ElseIf TextBoxPrice.Text <= 0 Then
            MessageBox.Show("Price cannot be negative or 0.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        ElseIf Not Integer.TryParse(TextBoxPrice.Text, price) Then
            MessageBox.Show("Please enter a whole number for the price.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim updateSql As String = "UPDATE salesTable SET vehicle = @Vehicle, service = @Service, price = @Price WHERE sales_id = @SalesID"

                Using updateCmd As New SqlCommand(updateSql, con)
                    updateCmd.Parameters.AddWithValue("@Vehicle", ComboBoxVehicle.Text)
                    updateCmd.Parameters.AddWithValue("@Service", ComboBoxService.Text)
                    updateCmd.Parameters.AddWithValue("@Price", price)
                    updateCmd.Parameters.AddWithValue("@SalesID", TextBoxSales.Text)
                    Dim rowsAffected As Integer = updateCmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No record found with that Sales ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Private Sub DeleteSaleInDatabase()
        Using con As New SqlConnection(constr)
            Try
                Dim confirmResult As DialogResult =
            MessageBox.Show("Are you sure?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If confirmResult = DialogResult.Yes Then
                    con.Open()
                    Dim deleteSql = "DELETE FROM salesTable WHERE sales_id = @SalesID"

                    Dim deleteCmd = New SqlCommand(deleteSql, con)
                    deleteCmd.Parameters.AddWithValue("@SalesId", TextBoxSales.Text)
                    Dim rowsAffected = deleteCmd.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        con.Close()
                    Else
                        MessageBox.Show("No record found with that Sales ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Deletion cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub
End Class

' This is the new, self-contained CarWashSales class.
' It contains the updated pricing logic, as well as new AddSaleToDatabase and UpdateSaleInDatabase methods.
Public Class CarWashSales
    ' Store the prices in a Dictionary for easy lookup.
    Private ReadOnly vehiclePrices As New Dictionary(Of String, Integer) From {
        {"HatchBack", 140},
        {"Sedan", 150},
        {"Compact", 180},
        {"Montero", 250},
        {"Fortuner", 250},
        {"Innova", 250},
        {"Adventure", 250},
        {"Crosswind", 250},
        {"Everest", 250},
        {"Ertiga", 250},
        {"Veloz", 250},
        {"Changan", 180},
        {"Pick Up", 280},
        {"Van", 280},
        {"L300", 280},
        {"Travis", 280},
        {"Jeep", 300},
        {"Big Bike", 160},
        {"150CC", 140},
        {"120CC", 130},
        {"100CC", 120},
        {"Tricycle", 150}
    }

    Private ReadOnly waxPrices As New Dictionary(Of String, Integer) From {
        {"HatchBack", 400},
        {"Sedan", 450},
        {"Compact", 500},
        {"Montero", 550},
        {"Fortuner", 550},
        {"Innova", 550},
        {"Adventure", 550},
        {"Crosswind", 550},
        {"Everest", 550},
        {"Ertiga", 550},
        {"Veloz", 500},
        {"Changan", 450},
        {"Pick Up", 600},
        {"Van", 700},
        {"L300", 750},
        {"Travis", 750},
        {"Big Bike", 250},
        {"150CC", 200},
        {"120CC", 150},
        {"100CC", 100}
    }

    Private ReadOnly engineWashPrices As New Dictionary(Of String, Integer) From {
        {"HatchBack", 450},
        {"Sedan", 500},
        {"Compact", 550},
        {"Montero", 600},
        {"Fortuner", 600},
        {"Innova", 600},
        {"Adventure", 600},
        {"Crosswind", 600},
        {"Everest", 600},
        {"Ertiga", 600},
        {"Veloz", 500},
        {"Changan", 450},
        {"Pick Up", 650},
        {"Van", 750},
        {"L300", 800},
        {"Travis", 800},
        {"Jeep", 800}
    }

    Private Const armorAddOnPrice As Integer = 100

    ' Public properties for the UI controls (assuming they are named this way)
    Public Property ComboBoxVehicle As ComboBox
    Public Property ComboBoxService As ComboBox
    Public Property TextBoxPrice As TextBox
    Public Property TextBoxSales As TextBox
    Public Property constr As String

    Public Sub New(vehicleComboBox As ComboBox, serviceComboBox As ComboBox, priceTextBox As TextBox, salesTextBox As TextBox, connectionString As String)
        Me.ComboBoxVehicle = vehicleComboBox
        Me.ComboBoxService = serviceComboBox
        Me.TextBoxPrice = priceTextBox
        Me.TextBoxSales = salesTextBox
        Me.constr = connectionString

        ' Attach the event handlers to the ComboBoxes
        AddHandler Me.ComboBoxVehicle.SelectedIndexChanged, AddressOf UpdatePrice
        AddHandler Me.ComboBoxService.SelectedIndexChanged, AddressOf UpdatePrice
    End Sub

    Private Sub UpdatePrice(sender As Object, e As EventArgs)
        Dim totalPrice As Integer = 0
        Dim vehicleType As String = ""
        Dim serviceType As String = ""

        ' Get the selected vehicle and service types
        If ComboBoxVehicle.SelectedIndex <> -1 AndAlso vehiclePrices.ContainsKey(ComboBoxVehicle.Text) Then
            vehicleType = ComboBoxVehicle.Text
        End If
        If ComboBoxService.SelectedIndex <> -1 AndAlso ComboBoxService.Text.Contains("Wash") OrElse ComboBoxService.Text.Contains("Wax") OrElse ComboBoxService.Text.Contains("Armor") Then
            serviceType = ComboBoxService.Text
        End If

        ' Calculate the total price based on the selected service and vehicle
        If Not String.IsNullOrEmpty(vehicleType) Then
            Select Case serviceType
                Case "Armor"
                    totalPrice = vehiclePrices(vehicleType) + armorAddOnPrice
                Case "Wax"
                    If waxPrices.ContainsKey(vehicleType) Then
                        totalPrice = waxPrices(vehicleType) + vehiclePrices(vehicleType)
                    End If
                Case "Engine Wash"
                    If engineWashPrices.ContainsKey(vehicleType) Then
                        totalPrice = engineWashPrices(vehicleType) + vehiclePrices(vehicleType)
                    End If
                Case Else
                    totalPrice = vehiclePrices(vehicleType)
            End Select
            TextBoxPrice.Text = totalPrice.ToString()
        End If
    End Sub

    Public Sub AddSaleToDatabase()

        ' --- Consolidated Input Validation ---
        If String.IsNullOrWhiteSpace(ComboBoxVehicle.Text) Then
            MessageBox.Show("Please fill out all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' --- Check for existing record BEFORE insert ---
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' NOTE: Using a parameterized query to check for existing sales ID is crucial for security.
                Dim checkSql As String = "SELECT COUNT(*) FROM salesTable WHERE sales_id = @SalesID"
                Using checkCmd As New SqlCommand(checkSql, con)
                    checkCmd.Parameters.AddWithValue("@SalesID", TextBoxSales.Text)
                    Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Record with this ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' --- Insert the new record ---
                ' This is the safe, parameterized INSERT statement.
                Dim insertSql As String = "INSERT INTO salesTable (sales_id, vehicle, service, price, date) VALUES (@Sales, @Vehicle, @Service, @Price, @Date)"
                Using insertCmd As New SqlCommand(insertSql, con)
                    insertCmd.Parameters.AddWithValue("@Sales", TextBoxSales.Text)
                    insertCmd.Parameters.AddWithValue("@Vehicle", ComboBoxVehicle.Text)
                    insertCmd.Parameters.AddWithValue("@Service", ComboBoxService.Text)
                    insertCmd.Parameters.AddWithValue("@Price", TextBoxPrice.Text)
                    insertCmd.Parameters.AddWithValue("@Date", Now.ToString())
                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Record added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using



    End Sub

    Public Sub UpdateSaleInDatabase()

        'If String.IsNullOrWhiteSpace(TextBoxSales.Text) Then
        'MessageBox.Show("Please enter a Sales ID to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return
        ' ElseIf Not Integer.TryParse(TextBoxPrice.Text, price) Then
        'MessageBox.Show("Please enter a valid whole number for Price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return
        '  ElseIf price <= 0 Then
        ' MessageBox.Show("Price cannot be negative or 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return
        ' ElseIf ComboBoxVehicle.SelectedIndex = -1 Then
        ' MessageBox.Show("Please select a valid vehicle type from the list.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return
        'End If

        ' --- Consolidated Input Validation ---
        If String.IsNullOrWhiteSpace(ComboBoxVehicle.Text) Then
            MessageBox.Show("Please fill out all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim updateSql As String = "UPDATE salesTable SET vehicle = @Vehicle, service = @Service, price = @Price WHERE sales_id = @SalesID"

                Using updateCmd As New SqlCommand(updateSql, con)
                    updateCmd.Parameters.AddWithValue("@Vehicle", ComboBoxVehicle.Text)
                    updateCmd.Parameters.AddWithValue("@Service", ComboBoxService.Text)
                    updateCmd.Parameters.AddWithValue("@Price", TextBoxPrice.Text)
                    updateCmd.Parameters.AddWithValue("@SalesID", TextBoxSales.Text)

                    Dim rowsAffected As Integer = updateCmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Record updated successfully.", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No record found with that Sales ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub

    Public Sub GenerateSalesID()
        Dim lastSaleID As String = ""
        Dim newSaleID As String = ""

        Try
            Using con As New SqlConnection(constr)
                con.Open()
                Dim sql As String = "SELECT TOP 1 sales_id FROM salesTable ORDER BY id DESC"
                Using cmd As New SqlCommand(sql, con)
                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    adapter.Fill(ds)

                    If ds.Tables(0).Rows.Count > 0 Then
                        lastSaleID = ds.Tables(0).Rows(0)("sales_id").ToString()
                    End If
                End Using
            End Using

            If String.IsNullOrEmpty(lastSaleID) Then
                ' No records exist, start with 000001
                newSaleID = Now.Year.ToString() & "-000001"
            Else
                Dim lastYear As String = lastSaleID.Substring(0, 4)
                Dim lastNumber As Integer
                Dim lastNumberString As String = lastSaleID.Substring(5, 6)

                If Now.Year.ToString() = lastYear Then
                    ' Same year, increment the number
                    If Integer.TryParse(lastNumberString, lastNumber) Then
                        lastNumber += 1
                        newSaleID = Now.Year.ToString() & "-" & lastNumber.ToString("000000")
                    Else
                        ' Handle case where substring is not a valid number
                        newSaleID = Now.Year.ToString() & "-000001"
                    End If
                Else
                    ' New year, reset the number to 000001
                    newSaleID = Now.Year.ToString() & "-000001"
                End If
            End If

            Me.TextBoxSales.Text = newSaleID

        Catch ex As Exception
            MessageBox.Show("An error occurred while generating Sales ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
