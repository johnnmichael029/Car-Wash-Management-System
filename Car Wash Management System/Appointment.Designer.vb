﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appointment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appointment))
        Panel1 = New Panel()
        DataGridViewAppointment = New DataGridView()
        Panel3 = New Panel()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        ListViewServices = New ListView()
        Label12 = New Label()
        TextBoxTotalPrice = New TextBox()
        TextBoxReferenceID = New TextBox()
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
        PrintDocumentBill = New Printing.PrintDocument()
        Panel1.SuspendLayout()
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridViewAppointment)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 3
        ' 
        ' DataGridViewAppointment
        ' 
        DataGridViewAppointment.AllowUserToAddRows = False
        DataGridViewAppointment.AllowUserToResizeColumns = False
        DataGridViewAppointment.AllowUserToResizeRows = False
        DataGridViewAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewAppointment.BackgroundColor = SystemColors.ControlLight
        DataGridViewAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewAppointment.Dock = DockStyle.Fill
        DataGridViewAppointment.Location = New Point(0, 0)
        DataGridViewAppointment.Name = "DataGridViewAppointment"
        DataGridViewAppointment.ReadOnly = True
        DataGridViewAppointment.Size = New Size(606, 758)
        DataGridViewAppointment.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(RemoveServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(ListViewServices)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(TextBoxTotalPrice)
        Panel3.Controls.Add(TextBoxReferenceID)
        Panel3.Controls.Add(Label7)
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
        Panel3.Size = New Size(305, 758)
        Panel3.TabIndex = 2
        ' 
        ' RemoveServiceBtn
        ' 
        RemoveServiceBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveServiceBtn.FlatAppearance.BorderSize = 0
        RemoveServiceBtn.FlatStyle = FlatStyle.Flat
        RemoveServiceBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveServiceBtn.ForeColor = Color.White
        RemoveServiceBtn.Location = New Point(202, 144)
        RemoveServiceBtn.Name = "RemoveServiceBtn"
        RemoveServiceBtn.Size = New Size(75, 23)
        RemoveServiceBtn.TabIndex = 92
        RemoveServiceBtn.Text = "Remove"
        RemoveServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' AddServiceBtn
        ' 
        AddServiceBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddServiceBtn.FlatAppearance.BorderSize = 0
        AddServiceBtn.FlatStyle = FlatStyle.Flat
        AddServiceBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AddServiceBtn.ForeColor = Color.White
        AddServiceBtn.Location = New Point(16, 144)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(75, 23)
        AddServiceBtn.TabIndex = 91
        AddServiceBtn.Text = "Add"
        AddServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' ListViewServices
        ' 
        ListViewServices.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewServices.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewServices.FullRowSelect = True
        ListViewServices.GridLines = True
        ListViewServices.Location = New Point(16, 173)
        ListViewServices.Name = "ListViewServices"
        ListViewServices.Size = New Size(260, 102)
        ListViewServices.TabIndex = 90
        ListViewServices.UseCompatibleStateImageBehavior = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.Location = New Point(148, 408)
        Label12.Name = "Label12"
        Label12.Size = New Size(70, 17)
        Label12.TabIndex = 89
        Label12.Text = "Total Price"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Font = New Font("Century Gothic", 9F)
        TextBoxTotalPrice.Location = New Point(148, 426)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.ReadOnly = True
        TextBoxTotalPrice.Size = New Size(129, 22)
        TextBoxTotalPrice.TabIndex = 88
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 383)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(261, 22)
        TextBoxReferenceID.TabIndex = 37
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(16, 365)
        Label7.Name = "Label7"
        Label7.Size = New Size(85, 17)
        Label7.TabIndex = 36
        Label7.Text = "Reference ID"
        ' 
        ' PrintBillBtn
        ' 
        PrintBillBtn.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        PrintBillBtn.FlatAppearance.BorderSize = 0
        PrintBillBtn.FlatStyle = FlatStyle.Flat
        PrintBillBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.ForeColor = Color.White
        PrintBillBtn.Image = CType(resources.GetObject("PrintBillBtn.Image"), Image)
        PrintBillBtn.Location = New Point(189, 566)
        PrintBillBtn.Name = "PrintBillBtn"
        PrintBillBtn.Size = New Size(87, 30)
        PrintBillBtn.TabIndex = 35
        PrintBillBtn.Text = "Print Bill"
        PrintBillBtn.TextAlign = ContentAlignment.MiddleRight
        PrintBillBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        PrintBillBtn.UseVisualStyleBackColor = False
        ' 
        ' LabelSales
        ' 
        LabelSales.AutoSize = True
        LabelSales.ForeColor = Color.Red
        LabelSales.Location = New Point(204, 556)
        LabelSales.Name = "LabelSales"
        LabelSales.Size = New Size(0, 15)
        LabelSales.TabIndex = 32
        ' 
        ' LabelAppointmentID
        ' 
        LabelAppointmentID.AutoSize = True
        LabelAppointmentID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelAppointmentID.ForeColor = Color.Red
        LabelAppointmentID.Location = New Point(104, 581)
        LabelAppointmentID.Name = "LabelAppointmentID"
        LabelAppointmentID.Size = New Size(0, 15)
        LabelAppointmentID.TabIndex = 31
        ' 
        ' TextBoxNotes
        ' 
        TextBoxNotes.Location = New Point(16, 514)
        TextBoxNotes.Multiline = True
        TextBoxNotes.Name = "TextBoxNotes"
        TextBoxNotes.Size = New Size(260, 49)
        TextBoxNotes.TabIndex = 30
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(15, 496)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 17)
        Label3.TabIndex = 29
        Label3.Text = "Notes"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(15, 321)
        Label11.Name = "Label11"
        Label11.Size = New Size(110, 17)
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
        ComboBoxPaymentMethod.Location = New Point(16, 339)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(262, 23)
        ComboBoxPaymentMethod.TabIndex = 27
        ' 
        ' ComboBoxAddon
        ' 
        ComboBoxAddon.FormattingEnabled = True
        ComboBoxAddon.Location = New Point(148, 115)
        ComboBoxAddon.Name = "ComboBoxAddon"
        ComboBoxAddon.Size = New Size(129, 23)
        ComboBoxAddon.TabIndex = 26
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 9F)
        Label10.Location = New Point(148, 97)
        Label10.Name = "Label10"
        Label10.Size = New Size(48, 17)
        Label10.TabIndex = 25
        Label10.Text = "Addon"
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 115)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(129, 23)
        ComboBoxServices.TabIndex = 24
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(15, 581)
        Label9.Name = "Label9"
        Label9.Size = New Size(102, 17)
        Label9.TabIndex = 22
        Label9.Text = "Appointment ID"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(16, 452)
        Label8.Name = "Label8"
        Label8.Size = New Size(127, 17)
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
        ComboBoxAppointmentStatus.Location = New Point(16, 470)
        ComboBoxAppointmentStatus.Name = "ComboBoxAppointmentStatus"
        ComboBoxAppointmentStatus.Size = New Size(261, 23)
        ComboBoxAppointmentStatus.TabIndex = 20
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 426)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(129, 23)
        TextBoxPrice.TabIndex = 19
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        DateTimePickerStartDate.ImeMode = ImeMode.NoControl
        DateTimePickerStartDate.Location = New Point(16, 295)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(261, 23)
        DateTimePickerStartDate.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 9F)
        Label6.Location = New Point(16, 277)
        Label6.Name = "Label6"
        Label6.Size = New Size(120, 17)
        Label6.TabIndex = 14
        Label6.Text = "Appointment Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 9F)
        Label5.Location = New Point(16, 97)
        Label5.Name = "Label5"
        Label5.Size = New Size(59, 17)
        Label5.TabIndex = 12
        Label5.Text = "Services"
        ' 
        ' LabelServiceID
        ' 
        LabelServiceID.AutoSize = True
        LabelServiceID.Location = New Point(72, 445)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.Location = New Point(16, 408)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 17)
        Label4.TabIndex = 10
        Label4.Text = "Subtotal"
        ' 
        ' UpdateAppointmentBtn
        ' 
        UpdateAppointmentBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateAppointmentBtn.FlatAppearance.BorderSize = 0
        UpdateAppointmentBtn.FlatStyle = FlatStyle.Flat
        UpdateAppointmentBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        UpdateAppointmentBtn.ForeColor = Color.White
        UpdateAppointmentBtn.Location = New Point(146, 651)
        UpdateAppointmentBtn.Name = "UpdateAppointmentBtn"
        UpdateAppointmentBtn.Size = New Size(129, 30)
        UpdateAppointmentBtn.TabIndex = 8
        UpdateAppointmentBtn.Text = "Update Service"
        UpdateAppointmentBtn.UseVisualStyleBackColor = False
        ' 
        ' ClearFieldsBtn
        ' 
        ClearFieldsBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ClearFieldsBtn.FlatAppearance.BorderSize = 0
        ClearFieldsBtn.FlatStyle = FlatStyle.Flat
        ClearFieldsBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ClearFieldsBtn.ForeColor = Color.White
        ClearFieldsBtn.Image = CType(resources.GetObject("ClearFieldsBtn.Image"), Image)
        ClearFieldsBtn.Location = New Point(16, 651)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(129, 30)
        ClearFieldsBtn.TabIndex = 7
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = False
        ' 
        ' AddAppointmentBtn
        ' 
        AddAppointmentBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddAppointmentBtn.FlatAppearance.BorderSize = 0
        AddAppointmentBtn.FlatStyle = FlatStyle.Flat
        AddAppointmentBtn.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AddAppointmentBtn.ForeColor = Color.White
        AddAppointmentBtn.Location = New Point(16, 599)
        AddAppointmentBtn.Name = "AddAppointmentBtn"
        AddAppointmentBtn.Size = New Size(260, 46)
        AddAppointmentBtn.TabIndex = 6
        AddAppointmentBtn.Text = "Add Appointment"
        AddAppointmentBtn.UseVisualStyleBackColor = False
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
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 17)
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
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 17)
        Label1.TabIndex = 0
        Label1.Text = "Customer Name"
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' Appointment
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(911, 758)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Appointment"
        Text = "Appointment"
        Panel1.ResumeLayout(False)
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewAppointment As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddon As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxAppointmentStatus As ComboBox
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
    Friend WithEvents TextBoxNotes As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelAppointmentID As Label
    Friend WithEvents LabelSales As Label
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents ListViewServices As ListView
End Class
