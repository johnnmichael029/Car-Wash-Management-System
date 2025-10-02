<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickUp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        PrintDocumentBill = New Printing.PrintDocument()
        Label7 = New Label()
        PrintBillBtn = New Button()
        LabelSales = New Label()
        LabelAppointmentID = New Label()
        TextBoxNotes = New TextBox()
        Label3 = New Label()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddon = New ComboBox()
        Label10 = New Label()
        ComboBoxServices = New ComboBox()
        Label9 = New Label()
        Label8 = New Label()
        ComboBoxAppointmentStatus = New ComboBox()
        DataGridViewAppointment = New DataGridView()
        TextBoxPrice = New TextBox()
        DateTimePickerStartDate = New DateTimePicker()
        Label6 = New Label()
        Label5 = New Label()
        LabelServiceID = New Label()
        Label4 = New Label()
        UpdateAppointmentBtn = New Button()
        ClearFieldsBtn = New Button()
        AddAppointmentBtn = New Button()
        TextBoxCustomerID = New TextBox()
        Label2 = New Label()
        TextBoxCustomerName = New TextBox()
        Label1 = New Label()
        Panel3 = New Panel()
        Panel1 = New Panel()
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(0, 1)
        Label7.Name = "Label7"
        Label7.Size = New Size(333, 39)
        Label7.TabIndex = 6
        Label7.Text = "List of Appointment"
        ' 
        ' PrintBillBtn
        ' 
        PrintBillBtn.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.Location = New Point(15, 577)
        PrintBillBtn.Name = "PrintBillBtn"
        PrintBillBtn.Size = New Size(75, 23)
        PrintBillBtn.TabIndex = 35
        PrintBillBtn.Text = "Prin Bill"
        PrintBillBtn.UseVisualStyleBackColor = True
        ' 
        ' LabelSales
        ' 
        LabelSales.AutoSize = True
        LabelSales.ForeColor = Color.Red
        LabelSales.Location = New Point(204, 457)
        LabelSales.Name = "LabelSales"
        LabelSales.Size = New Size(0, 15)
        LabelSales.TabIndex = 32
        ' 
        ' LabelAppointmentID
        ' 
        LabelAppointmentID.AutoSize = True
        LabelAppointmentID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelAppointmentID.ForeColor = Color.Red
        LabelAppointmentID.Location = New Point(104, 457)
        LabelAppointmentID.Name = "LabelAppointmentID"
        LabelAppointmentID.Size = New Size(0, 15)
        LabelAppointmentID.TabIndex = 31
        ' 
        ' TextBoxNotes
        ' 
        TextBoxNotes.Location = New Point(16, 382)
        TextBoxNotes.Multiline = True
        TextBoxNotes.Name = "TextBoxNotes"
        TextBoxNotes.Size = New Size(260, 72)
        TextBoxNotes.TabIndex = 30
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 9F)
        Label3.Location = New Point(15, 364)
        Label3.Name = "Label3"
        Label3.Size = New Size(39, 15)
        Label3.TabIndex = 29
        Label3.Text = "Notes"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Microsoft Sans Serif", 9F)
        Label11.Location = New Point(15, 232)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 15)
        Label11.TabIndex = 28
        Label11.Text = "Payment Method"
        ' 
        ' ComboBoxPaymentMethod
        ' 
        ComboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(New String() {"Gcash", "Cheque", "Cash"})
        ComboBoxPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 250)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(262, 23)
        ComboBoxPaymentMethod.TabIndex = 27
        ' 
        ' ComboBoxAddon
        ' 
        ComboBoxAddon.FormattingEnabled = True
        ComboBoxAddon.Location = New Point(16, 159)
        ComboBoxAddon.Name = "ComboBoxAddon"
        ComboBoxAddon.Size = New Size(261, 23)
        ComboBoxAddon.TabIndex = 26
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Microsoft Sans Serif", 9F)
        Label10.Location = New Point(15, 141)
        Label10.Name = "Label10"
        Label10.Size = New Size(42, 15)
        Label10.TabIndex = 25
        Label10.Text = "Addon"
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 115)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(261, 23)
        ComboBoxServices.TabIndex = 24
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Microsoft Sans Serif", 9F)
        Label9.Location = New Point(15, 457)
        Label9.Name = "Label9"
        Label9.Size = New Size(91, 15)
        Label9.TabIndex = 22
        Label9.Text = "Appointment ID"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Microsoft Sans Serif", 9F)
        Label8.Location = New Point(16, 320)
        Label8.Name = "Label8"
        Label8.Size = New Size(113, 15)
        Label8.TabIndex = 21
        Label8.Text = "Appointment Status"
        ' 
        ' ComboBoxAppointmentStatus
        ' 
        ComboBoxAppointmentStatus.AutoCompleteCustomSource.AddRange(New String() {"Pending", "Confirmed", "Cancelled", "No-Show", "Completed"})
        ComboBoxAppointmentStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxAppointmentStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxAppointmentStatus.FormattingEnabled = True
        ComboBoxAppointmentStatus.Items.AddRange(New Object() {"Pending", "Confirmed", "Cancelled", "No-Show", "Completed"})
        ComboBoxAppointmentStatus.Location = New Point(16, 338)
        ComboBoxAppointmentStatus.Name = "ComboBoxAppointmentStatus"
        ComboBoxAppointmentStatus.Size = New Size(261, 23)
        ComboBoxAppointmentStatus.TabIndex = 20
        ' 
        ' DataGridViewAppointment
        ' 
        DataGridViewAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewAppointment.BackgroundColor = SystemColors.ControlLight
        DataGridViewAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewAppointment.Dock = DockStyle.Fill
        DataGridViewAppointment.Location = New Point(0, 0)
        DataGridViewAppointment.Name = "DataGridViewAppointment"
        DataGridViewAppointment.ReadOnly = True
        DataGridViewAppointment.Size = New Size(606, 635)
        DataGridViewAppointment.TabIndex = 0
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 294)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 19
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        DateTimePickerStartDate.ImeMode = ImeMode.NoControl
        DateTimePickerStartDate.Location = New Point(16, 206)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(261, 23)
        DateTimePickerStartDate.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 9F)
        Label6.Location = New Point(16, 188)
        Label6.Name = "Label6"
        Label6.Size = New Size(105, 15)
        Label6.TabIndex = 14
        Label6.Text = "Appointment Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft Sans Serif", 9F)
        Label5.Location = New Point(16, 97)
        Label5.Name = "Label5"
        Label5.Size = New Size(53, 15)
        Label5.TabIndex = 12
        Label5.Text = "Services"
        ' 
        ' LabelServiceID
        ' 
        LabelServiceID.AutoSize = True
        LabelServiceID.Location = New Point(72, 313)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 9F)
        Label4.Location = New Point(16, 276)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 15)
        Label4.TabIndex = 10
        Label4.Text = "Price"
        ' 
        ' UpdateAppointmentBtn
        ' 
        UpdateAppointmentBtn.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        UpdateAppointmentBtn.Location = New Point(16, 541)
        UpdateAppointmentBtn.Name = "UpdateAppointmentBtn"
        UpdateAppointmentBtn.Size = New Size(260, 30)
        UpdateAppointmentBtn.TabIndex = 8
        UpdateAppointmentBtn.Text = "Update Service"
        UpdateAppointmentBtn.UseVisualStyleBackColor = True
        ' 
        ' ClearFieldsBtn
        ' 
        ClearFieldsBtn.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        ClearFieldsBtn.Image = My.Resources.Resources.clean
        ClearFieldsBtn.Location = New Point(16, 508)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(260, 30)
        ClearFieldsBtn.TabIndex = 7
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = True
        ' 
        ' AddAppointmentBtn
        ' 
        AddAppointmentBtn.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold)
        AddAppointmentBtn.Location = New Point(16, 475)
        AddAppointmentBtn.Name = "AddAppointmentBtn"
        AddAppointmentBtn.Size = New Size(260, 30)
        AddAppointmentBtn.TabIndex = 6
        AddAppointmentBtn.Text = "Add Appointment"
        AddAppointmentBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBoxCustomerID
        ' 
        TextBoxCustomerID.Location = New Point(16, 71)
        TextBoxCustomerID.Name = "TextBoxCustomerID"
        TextBoxCustomerID.ReadOnly = True
        TextBoxCustomerID.Size = New Size(261, 23)
        TextBoxCustomerID.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 9F)
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 15)
        Label2.TabIndex = 2
        Label2.Text = "Customer ID"
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Location = New Point(16, 27)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(261, 23)
        TextBoxCustomerName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 9F)
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 15)
        Label1.TabIndex = 0
        Label1.Text = "Customer Name"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(PrintBillBtn)
        Panel3.Controls.Add(LabelSales)
        Panel3.Controls.Add(LabelAppointmentID)
        Panel3.Controls.Add(TextBoxNotes)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddon)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(ComboBoxServices)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(ComboBoxAppointmentStatus)
        Panel3.Controls.Add(TextBoxPrice)
        Panel3.Controls.Add(DateTimePickerStartDate)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(UpdateAppointmentBtn)
        Panel3.Controls.Add(ClearFieldsBtn)
        Panel3.Controls.Add(AddAppointmentBtn)
        Panel3.Controls.Add(TextBoxCustomerID)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(TextBoxCustomerName)
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(606, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(305, 635)
        Panel3.TabIndex = 2
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(DataGridViewAppointment)
        Panel1.Controls.Add(Panel3)
        Panel1.Location = New Point(0, 51)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 635)
        Panel1.TabIndex = 5
        ' 
        ' PickUp
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 687)
        Controls.Add(Label7)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "PickUp"
        Text = "PickUp"
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents Label7 As Label
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents LabelSales As Label
    Friend WithEvents LabelAppointmentID As Label
    Friend WithEvents TextBoxNotes As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddon As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxAppointmentStatus As ComboBox
    Friend WithEvents DataGridViewAppointment As DataGridView
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents UpdateAppointmentBtn As Button
    Friend WithEvents ClearFieldsBtn As Button
    Friend WithEvents AddAppointmentBtn As Button
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
End Class
