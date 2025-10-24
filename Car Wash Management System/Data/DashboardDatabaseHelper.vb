Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient

Public Class DashboardDatabaseHelper
    Private Shared constr As String
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
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery =
            "SELECT " &
                "s.SalesID, " &
                "c.Name AS CustomerName, " &
                "sv_base.ServiceName, " &
                "sv_addon.ServiceName," &
                "s.SaleDate, " &
                "s.PaymentMethod, " &
                "s.ReferenceID, " &
                "s.TotalPrice " &
            "FROM SalesHistoryTable s " &
            "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
            "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
            "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID " &
            "ORDER BY s.SalesID DESC"

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
    ''' <summary>
    ''' Gets the total sales grouped by year from the SalesHistoryTable.
    ''' </summary>
    Public Shared Function GetYearlySales() As DataTable
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
    Public Shared Function GetMonthlySales() As DataTable
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
    Public Shared Function GetDailySales() As DataTable
        Dim query As String = "SELECT CAST(SaleDate AS DATE) AS SaleDate, SUM(TotalPrice) AS TotalSales FROM SalesHistoryTable WHERE SaleDate >= DATEADD(DAY, -7, CAST(GETDATE() AS DATE)) GROUP BY CAST(SaleDate AS DATE) ORDER BY SaleDate ASC"
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
    ''' <summary>
    ''' Gets the filtered sales data based on the search string and filter column.
    ''' </summary>
    Public Function GetWeeklySales() As DataTable
        ' The query calculates the starting date of the 7-day period (WeekStartDate) for grouping.
        Dim query As String = "
    WITH MinSaleDate (StartDate) AS (
        -- 1. Find the absolute minimum/first sales date
        SELECT MIN(CAST(SaleDate AS DATE)) FROM SalesHistoryTable
    )
    SELECT
        -- Returns the first day of the calculated week for the purpose of grouping
        CAST(DATEADD(wk, DATEDIFF(wk, (SELECT StartDate FROM MinSaleDate), CAST(SaleDate AS DATE)), (SELECT StartDate FROM MinSaleDate)) AS DATE) AS WeekStartDate,
        SUM(TotalPrice) AS TotalSales
    FROM SalesHistoryTable T
    GROUP BY 
        CAST(DATEADD(wk, DATEDIFF(wk, (SELECT StartDate FROM MinSaleDate), CAST(SaleDate AS DATE)), (SELECT StartDate FROM MinSaleDate)) AS DATE)
    ORDER BY 
        WeekStartDate ASC"

        Dim dt As New DataTable()
        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand(query, con)
                    con.Open()
                    Dim adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using

            ' --- POST-PROCESSING IN VB.NET TO GET 'Week 1', 'Week 2', etc. ---

            If dt.Rows.Count > 0 Then
                ' Add a new column to the DataTable for the Week Label
                dt.Columns.Add("SalesWeek", GetType(String))

                ' Determine the true starting date of the sales data for calculation
                Dim firstWeekStartDate As Date = CDate(dt.Rows(0)("WeekStartDate"))

                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim currentWeekStartDate As Date = CDate(dt.Rows(i)("WeekStartDate"))

                    ' Calculate the difference in days from the first week's start date
                    Dim timeSpan As TimeSpan = currentWeekStartDate.Subtract(firstWeekStartDate)

                    ' Calculate the week index (0, 1, 2...)
                    Dim weekIndex As Integer = CInt(Math.Floor(timeSpan.TotalDays / 7))

                    ' Set the 'SalesWeek' label (Week 1, Week 2, etc.)
                    dt.Rows(i)("SalesWeek") = "Week " & (weekIndex + 1).ToString()
                Next

                ' Clean up the DataTable to remove the intermediate date column
                dt.Columns.Remove("WeekStartDate")
                dt.Columns("SalesWeek").SetOrdinal(0) ' Make it the first column
            End If

        Catch ex As Exception
            ' Log or display the error if something goes wrong with the database
            Console.WriteLine("Error in GetWeeklySales: " & ex.Message)
        End Try

        Return dt
    End Function

    ''' <summary>
    ''' Gets the filtered sales data based on the search string and filter column.
    ''' </summary>
    Public Function GetFilteredList(searchInBar As String, filterColumn As String) As DataTable
        Dim dt As New DataTable()
        Using con As New SqlConnection(constr)
            Dim selectQuery As String
            con.Open()
            Try
                ' --- SQL SELECT Statement (Common to all cases) ---
                Dim baseSelect As String =
                    "SELECT " &
                    "s.SalesID, " &
                    "c.Name AS CustomerName, " &
                    "sv_base.ServiceName AS BaseService, " & ' Added alias for clarity
                    "sv_addon.ServiceName AS AddonService, " & ' Added alias for clarity
                    "s.SaleDate, " &
                    "s.PaymentMethod, " &
                    "s.ReferenceID, " &
                    "s.TotalPrice " &
                    "FROM SalesHistoryTable s " &
                    "INNER JOIN CustomersTable c ON s.CustomerID = c.CustomerID " &
                    "INNER JOIN ServicesTable sv_base ON s.ServiceID = sv_base.ServiceID " &
                    "LEFT JOIN ServicesTable sv_addon ON s.AddonServiceID = sv_addon.ServiceID "

                ' --- Determine the WHERE Clause based on filterColumn ---
                If filterColumn = "Addon Service" Then
                    ' FIX 1: Use LIKE and target the Addon service column
                    selectQuery = baseSelect & "WHERE sv_addon.ServiceName LIKE @searchString"

                ElseIf filterColumn = "Base Service" Then
                    ' FIX 2: Use LIKE and target the Base service column
                    selectQuery = baseSelect & "WHERE sv_base.ServiceName LIKE @searchString"

                ElseIf filterColumn = "All Columns" Then
                    ' Ensure your ComboBox has an "All Columns" option, otherwise this case handles the default catch-all.
                    selectQuery = baseSelect &
                            "WHERE c.Name LIKE @searchString " &
                            "OR s.SalesID LIKE @searchString " &
                            "OR s.PaymentMethod LIKE @searchString " &
                            "OR sv_base.ServiceName LIKE @searchString " &
                            "OR sv_addon.ServiceName LIKE @searchString"
                Else
                    selectQuery = baseSelect & "WHERE c.Name LIKE @searchString OR s.SalesID LIKE @SearchString"
                End If

                ' --- Execute the Query ---
                Using cmd As New SqlCommand(selectQuery, con)
                    ' Parameterization is correct: the wildcard '%' characters are added here
                    cmd.Parameters.AddWithValue("@searchString", "%" & searchInBar & "%")
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
    ''' <summary>
    ''' Gets the activity log from the ActivityLogTable.
    ''' </summary>
    Public Sub AddSale(customerID As Integer, baseServiceID As Integer, addonServiceID As Integer?, paymentMethod As String, totalPrice As Decimal)
        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim insertQuery = "INSERT INTO RegularSaleTable (CustomerID, ServiceID, AddonServiceID, SaleDate, PaymentMethod, TotalPrice) VALUES (@CustomerID, @ServiceID, @AddonServiceID, @SaleDate, @PaymentMethod, @TotalPrice)"
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
    'Public Sub AddCustomer(name As String, number As String, email As String, address As String, plateNumber As String)
    '    Using con As New SqlConnection(constr)
    '        Try
    '            con.Open()
    '            Dim insertQuery As String = "INSERT INTO CustomersTable (Name, PhoneNumber, Email, Address, PlateNumber, RegistrationDate) VALUES (@Name, @PhoneNumber, @Email, @Address, @PlateNUmber, @RegistrationDate)"
    '            Using cmd As New SqlCommand(insertQuery, con)
    '                cmd.Parameters.AddWithValue("@Name", name)
    '                cmd.Parameters.AddWithValue("@PhoneNumber", number)
    '                cmd.Parameters.AddWithValue("@Email", email)
    '                If String.IsNullOrEmpty(address) Then
    '                    cmd.Parameters.AddWithValue("@Address", DBNull.Value)
    '                Else
    '                    cmd.Parameters.AddWithValue("@Address", address)
    '                End If
    '                cmd.Parameters.AddWithValue("@PlateNUmber", plateNumber)
    '                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now)
    '                cmd.ExecuteNonQuery()
    '            End Using
    '            Carwash.NotificationLabel.Text = "New Customer Information"
    '            Carwash.ShowNotification()
    '            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Catch ex As Exception
    '            MessageBox.Show("Error adding customer: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            con.Close()
    '        End Try
    '    End Using
    'End Sub
    Public Shared Sub ShowPrintPreview(doc As PrintDocument)
        doc.PrinterSettings = New PrinterSettings()
        doc.DefaultPageSettings.Margins = New Printing.Margins(10, 10, 0, 0)
        doc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 300, 500)
    End Sub

    Public Shared Sub PrintBillInDashboard(e As PrintPageEventArgs, printData As PrintSaleInDashboard)
        If printData Is Nothing Then
            Return
        End If

        ' --- Font Definitions ---
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14b As New Font("Calibri", 14, FontStyle.Bold)

        ' --- Layout Calculations ---
        Dim leftMargin As Integer = e.PageSettings.Margins.Left
        Dim centerMargin As Integer = e.PageSettings.PaperSize.Width / 2
        Dim rightMargin As Integer = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right

        ' Font alignment
        Dim rightAlign As New StringFormat()
        Dim centerAlign As New StringFormat()
        rightAlign.Alignment = StringAlignment.Far
        centerAlign.Alignment = StringAlignment.Center

        Dim line As String = "------------------------------------------------------------------"
        Dim centerLine As String = "------------"
        Dim yPos As Integer = 20
        Dim offset As Integer = 12

        ' --- Header ---
        e.Graphics.DrawString("Sandigan Carwash", f14b, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 20
        e.Graphics.DrawString("Calzada Tipas, Taguig City", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += 10
        e.Graphics.DrawString("Contact No: 09553516404", f8, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset

        ' --- Sale Info ---
        yPos += offset
        e.Graphics.DrawString(printData.SaleDate.ToString("MM/dd/yyy HH:mm tt, ddd"), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        e.Graphics.DrawString("InvoiceID: " & InvoiceGeneratorService.CreateInvoiceNumber(printData.SalesID), f10, Brushes.Black, centerMargin, yPos, centerAlign)
        yPos += offset
        yPos += offset
        e.Graphics.DrawString("Customer Name: " & printData.CustomerName, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset

        ' --- Table Header ---
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Qty", f10, Brushes.Black, leftMargin, yPos)
        e.Graphics.DrawString("Description", f10, Brushes.Black, centerMargin, yPos, centerAlign)
        e.Graphics.DrawString("Amount", f10, Brushes.Black, rightMargin, yPos, rightAlign)
        yPos += offset
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset

        ' --- Table Body (Looping through items) ---
        If printData.ServiceLineItemInDashboard IsNot Nothing AndAlso printData.ServiceLineItemInDashboard.Count > 0 Then
            For Each item As ServiceLineItemInDashboard In printData.ServiceLineItemInDashboard
                ' Print Qty
                e.Graphics.DrawString("1", f10, Brushes.Black, leftMargin, yPos)

                ' Print Description
                e.Graphics.DrawString(item.Name, f10, Brushes.Black, centerMargin, yPos, centerAlign)

                e.Graphics.DrawString(item.Price.ToString("N2"), f10, Brushes.Black, rightMargin, yPos, rightAlign)

                yPos += offset
            Next
        Else
            e.Graphics.DrawString("No services recorded.", f10, Brushes.Black, centerMargin, yPos, centerAlign)
            yPos += offset
        End If

        Dim finalTotal As Decimal = printData.TotalPrice

        ' --- Subtotal/Total Line ---
        e.Graphics.DrawString(line, f10, Brushes.Black, leftMargin, yPos)
        yPos += offset
        e.Graphics.DrawString("Subtotal:", f10b, Brushes.Black, leftMargin, yPos) ' Use bold for total
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10b, Brushes.Black, rightMargin, yPos, rightAlign) ' Use bold for total amount
        yPos += offset
        yPos += offset

        ' --- Payment Section ---
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
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString(centerLine, f10, Brushes.Black, 160, yPos)
        yPos += 10
        e.Graphics.DrawString("Total:", f10b, Brushes.Black, 90, yPos)
        e.Graphics.DrawString(finalTotal.ToString("N2"), f10b, Brushes.Black, 160, yPos)
        yPos += 50

        e.Graphics.DrawString("Thank You!!", f10b, Brushes.Black, centerMargin, yPos, centerAlign)
    End Sub
    Public Shared Function GetSaleLineItems(saleId As Integer, constr As String) As List(Of ServiceLineItemInDashboard)
        Dim items As New List(Of ServiceLineItemInDashboard)()

        ' This query retrieves the subtotal, base service name, and addon service name 
        ' for a given SaleID by joining SalesServiceTable with ServicesTable twice.
        Dim sql As String = "
        SELECT 
            SST.Subtotal,
            ST_BASE.ServiceName AS BaseServiceName,
            ST_ADDON.ServiceName AS AddonServiceName
        FROM 
            SalesServiceTable AS SST
        LEFT JOIN 
            ServicesTable AS ST_BASE ON SST.ServiceID = ST_BASE.ServiceID
        LEFT JOIN 
            ServicesTable AS ST_ADDON ON SST.AddonServiceID = ST_ADDON.ServiceID
        WHERE 
            SST.SalesID = @SaleID
        ORDER BY 
            SST.SalesServiceID ASC;
    "

        Using conn As New SqlConnection(constr)
            Using cmd As New SqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@SaleID", saleId)

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
                            items.Add(New ServiceLineItemInDashboard With {
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
