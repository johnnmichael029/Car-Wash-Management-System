Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class DashboardDatabaseHelper
    Private ReadOnly constr As String
    Private ReadOnly textBoxCustomerName As TextBox

    Public Sub New(connectionString As String, customerNameTextBox As TextBox)
        constr = connectionString
        Me.textBoxCustomerName = customerNameTextBox


    End Sub
    ''' <summary>
    ''' View Sales Data from the SalesHistoryTable along with Customer and Service details.
    ''' </summary>
    Public Function ViewSalesData() As DataTable
        Dim dt As New DataTable()
        Using conn As New SqlConnection(constr)
            conn.Open()
            Dim ViewQuery As String = "SELECT s.SalesID, c.Name AS CustomerName, sv.ServiceName AS BaseServiceName, sv_addon.ServiceName AS AddonServiceName, s.SaleDate, s.PaymentMethod, s.TotalPrice FROM SalesHistoryTable s
                                     INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
                                     INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
                                     LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID ORDER BY s.SalesID DESC"
            Using cmd As New SqlCommand(ViewQuery, conn)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dt.Load(reader)
                End Using
            End Using
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales grouped by year from the SalesHistoryTable.
    ''' </summary>
    Public Function GetYearlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate) ORDER BY SalesYear"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetYearlySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales grouped by month and year from the SalesHistoryTable.
    ''' </summary>
    Public Function GetMonthlySales() As DataTable
        Dim query As String = "SELECT YEAR(SaleDate) AS SalesYear, MONTH(SaleDate) AS SalesMonth, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable GROUP BY YEAR(SaleDate), MONTH(SaleDate) ORDER BY SalesYear, SalesMonth"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetMonthlySales: " & ex.Message)
        End Try
        Return dt
    End Function
    ''' <summary>
    ''' Gets the total sales for the past 7 days from the SalesHistoryTable.
    ''' </summary>
    Public Function GetWeeklySales() As DataTable
        Dim query As String = "SELECT CAST(SaleDate AS DATE) AS SaleDate, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable WHERE SaleDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE)) GROUP BY CAST(SaleDate AS DATE) ORDER BY SaleDate ASC"
        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
        End Try
        Return dt
    End Function
    Public Function GetListInSearchBar(searchInBar As String) As DataTable
        Dim dt As New DataTable()

        Dim query As String = "
            SELECT
                s.SalesID,
                c.Name AS CustomerName,
                sv.ServiceName AS BaseServiceName,
                sv_addon.ServiceName AS AddonServiceName,
                s.SaleDate,
                s.PaymentMethod,
                s.TotalPrice
            FROM SalesHistoryTable s
            INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID
            INNER JOIN ServicesTable sv ON s.ServiceID = sv.ServiceID
            LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID
            WHERE c.Name LIKE @searchString
            OR s.SalesID LIKE @searchString
            OR s.PaymentMethod LIKE @searchString
            "
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@searchString", "%" & searchInBar & "%")
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                Catch ex As Exception
                    Console.WriteLine("Error in GetListInSearchBar: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End Using
        End Using
        Return dt
    End Function
    ''' <summary>
    ''' Gets the activity log from the ActivityLogTable.
    ''' </summary>



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
    Public Sub AddCustomer(name As String, number As String, email As String, address As String, plateNumber As String)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, PlateNumber, RegistrationDate) VALUES (@Name, @PhoneNumber, @Email, @Address, @PlateNUmber, @RegistrationDate)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@PhoneNumber", number)
                    cmd.Parameters.AddWithValue("@Email", email)
                    If String.IsNullOrEmpty(address) Then
                        cmd.Parameters.AddWithValue("@Address", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@Address", address)
                    End If
                    cmd.Parameters.AddWithValue("@PlateNUmber", plateNumber)
                    cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
                    cmd.ExecuteNonQuery()
                End Using
                Carwash.NotificationLabel.Text = "New Customer Information"
                Carwash.ShowNotification()
                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub
    Public Shared Sub PrintBillInDashboard(e As PrintPageEventArgs, printData As PrintDataInDashboardService)
        If printData Is Nothing Then
            ' Handle case where no data is set
            Return
        End If

        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        'Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12


        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' Add bill details from the class-level printData object

        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & InvoiceGeneratorService.CreateInvoiceNumber(printData.SalesID), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.BaseService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString(printData.BaseServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        If Not String.IsNullOrWhiteSpace(printData.AddonService) Then
            yPos += offset
            e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)
            e.Graphics.DrawString("Add-on: " & printData.AddonService, f10, Brushes.Black, centerMargin, yPos, centerAlign)
            e.Graphics.DrawString(printData.AddonServicePrice, f10, Brushes.Black, rightMargin, yPos, rightAlign)
            yPos += offset
        End If
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Total:", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        yPos += offset

        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString("Payment", f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, 160, yPos)
        yPos += offset
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += offset

        e.Graphics.DrawString(printData.PaymentMethod, f10, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(printData.TotalPrice.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
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

    Public Function GetServiceID(serviceName As String) As SalesInDashboardService
        Using con As New SqlConnection(constr)
            Dim details As New SalesInDashboardService()
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

End Class
