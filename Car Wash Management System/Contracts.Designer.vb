﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contracts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contracts))
        Panel3 = New Panel()
        TextBoxReferenceID = New TextBox()
        Label13 = New Label()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        ListViewServices = New ListView()
        PrintBillBtn = New Button()
        Label12 = New Label()
        TextBoxTotalPrice = New TextBox()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddon = New ComboBox()
        Label10 = New Label()
        ComboBoxServices = New ComboBox()
        LabelContractID = New Label()
        Label9 = New Label()
        Label8 = New Label()
        ComboBoxContractStatus = New ComboBox()
        TextBoxPrice = New TextBox()
        ComboBoxBillingFrequency = New ComboBox()
        DateTimePickerEndDate = New DateTimePicker()
        Label7 = New Label()
        DateTimePickerStartDate = New DateTimePicker()
        Label6 = New Label()
        Label5 = New Label()
        LabelServiceID = New Label()
        Label4 = New Label()
        UpdateContractBtn = New Button()
        ClearFieldsBtn = New Button()
        AddContractBtn = New Button()
        Label3 = New Label()
        TextBoxCustomerID = New TextBox()
        Label2 = New Label()
        TextBoxCustomerName = New TextBox()
        Label1 = New Label()
        Panel1 = New Panel()
        DataGridViewContract = New DataGridView()
        PrintDocumentBill = New Printing.PrintDocument()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        CType(DataGridViewContract, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(TextBoxReferenceID)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(RemoveServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(ListViewServices)
        Panel3.Controls.Add(PrintBillBtn)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(TextBoxTotalPrice)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddon)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(ComboBoxServices)
        Panel3.Controls.Add(LabelContractID)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(ComboBoxContractStatus)
        Panel3.Controls.Add(TextBoxPrice)
        Panel3.Controls.Add(ComboBoxBillingFrequency)
        Panel3.Controls.Add(DateTimePickerEndDate)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(DateTimePickerStartDate)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(UpdateContractBtn)
        Panel3.Controls.Add(ClearFieldsBtn)
        Panel3.Controls.Add(AddContractBtn)
        Panel3.Controls.Add(Label3)
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
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 428)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(261, 22)
        TextBoxReferenceID.TabIndex = 97
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(16, 410)
        Label13.Name = "Label13"
        Label13.Size = New Size(85, 17)
        Label13.TabIndex = 96
        Label13.Text = "Reference ID"
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
        RemoveServiceBtn.TabIndex = 95
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
        AddServiceBtn.TabIndex = 94
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
        ListViewServices.TabIndex = 93
        ListViewServices.UseCompatibleStateImageBehavior = False
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
        PrintBillBtn.TabIndex = 92
        PrintBillBtn.Text = "Print Bill"
        PrintBillBtn.TextAlign = ContentAlignment.MiddleRight
        PrintBillBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        PrintBillBtn.UseVisualStyleBackColor = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.Location = New Point(146, 453)
        Label12.Name = "Label12"
        Label12.Size = New Size(70, 17)
        Label12.TabIndex = 91
        Label12.Text = "Total Price"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Font = New Font("Century Gothic", 9F)
        TextBoxTotalPrice.Location = New Point(146, 471)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.Size = New Size(129, 22)
        TextBoxTotalPrice.TabIndex = 90
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(16, 366)
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
        ComboBoxPaymentMethod.Location = New Point(17, 384)
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
        ' LabelContractID
        ' 
        LabelContractID.AutoSize = True
        LabelContractID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelContractID.ForeColor = Color.Red
        LabelContractID.Location = New Point(82, 579)
        LabelContractID.Name = "LabelContractID"
        LabelContractID.Size = New Size(0, 15)
        LabelContractID.TabIndex = 23
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(16, 579)
        Label9.Name = "Label9"
        Label9.Size = New Size(77, 17)
        Label9.TabIndex = 22
        Label9.Text = "Contract ID"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(16, 497)
        Label8.Name = "Label8"
        Label8.Size = New Size(102, 17)
        Label8.TabIndex = 21
        Label8.Text = "Contract Status"
        ' 
        ' ComboBoxContractStatus
        ' 
        ComboBoxContractStatus.AutoCompleteCustomSource.AddRange(New String() {"Active", "Expired", "Cancelled"})
        ComboBoxContractStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxContractStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxContractStatus.FormattingEnabled = True
        ComboBoxContractStatus.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxContractStatus.Location = New Point(16, 515)
        ComboBoxContractStatus.Name = "ComboBoxContractStatus"
        ComboBoxContractStatus.Size = New Size(261, 23)
        ComboBoxContractStatus.TabIndex = 20
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 471)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(129, 23)
        TextBoxPrice.TabIndex = 19
        ' 
        ' ComboBoxBillingFrequency
        ' 
        ComboBoxBillingFrequency.AutoCompleteCustomSource.AddRange(New String() {"Monthly", "Quarterly ", "Yearly"})
        ComboBoxBillingFrequency.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxBillingFrequency.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxBillingFrequency.FormattingEnabled = True
        ComboBoxBillingFrequency.Items.AddRange(New Object() {"Monthly", "Quarterly", "Yearly"})
        ComboBoxBillingFrequency.Location = New Point(16, 340)
        ComboBoxBillingFrequency.Name = "ComboBoxBillingFrequency"
        ComboBoxBillingFrequency.Size = New Size(261, 23)
        ComboBoxBillingFrequency.TabIndex = 18
        ' 
        ' DateTimePickerEndDate
        ' 
        DateTimePickerEndDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerEndDate.Format = DateTimePickerFormat.Custom
        DateTimePickerEndDate.Location = New Point(147, 296)
        DateTimePickerEndDate.Name = "DateTimePickerEndDate"
        DateTimePickerEndDate.Size = New Size(129, 23)
        DateTimePickerEndDate.TabIndex = 17
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(147, 278)
        Label7.Name = "Label7"
        Label7.Size = New Size(62, 17)
        Label7.TabIndex = 16
        Label7.Text = "End Date"
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        DateTimePickerStartDate.Location = New Point(16, 296)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(129, 23)
        DateTimePickerStartDate.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 9F)
        Label6.Location = New Point(16, 278)
        Label6.Name = "Label6"
        Label6.Size = New Size(70, 17)
        Label6.TabIndex = 14
        Label6.Text = "Start Date"
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
        LabelServiceID.Location = New Point(72, 490)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.Location = New Point(16, 453)
        Label4.Name = "Label4"
        Label4.Size = New Size(59, 17)
        Label4.TabIndex = 10
        Label4.Text = "Subtotal"
        ' 
        ' UpdateContractBtn
        ' 
        UpdateContractBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateContractBtn.FlatAppearance.BorderSize = 0
        UpdateContractBtn.FlatStyle = FlatStyle.Flat
        UpdateContractBtn.Font = New Font("Century Gothic", 9F)
        UpdateContractBtn.ForeColor = Color.White
        UpdateContractBtn.Location = New Point(146, 651)
        UpdateContractBtn.Name = "UpdateContractBtn"
        UpdateContractBtn.Size = New Size(129, 30)
        UpdateContractBtn.TabIndex = 8
        UpdateContractBtn.Text = "Update Contract"
        UpdateContractBtn.UseVisualStyleBackColor = False
        ' 
        ' ClearFieldsBtn
        ' 
        ClearFieldsBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ClearFieldsBtn.FlatAppearance.BorderSize = 0
        ClearFieldsBtn.FlatStyle = FlatStyle.Flat
        ClearFieldsBtn.Font = New Font("Century Gothic", 9F)
        ClearFieldsBtn.ForeColor = Color.White
        ClearFieldsBtn.Image = My.Resources.Resources.clean1
        ClearFieldsBtn.Location = New Point(16, 651)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(129, 30)
        ClearFieldsBtn.TabIndex = 7
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = False
        ' 
        ' AddContractBtn
        ' 
        AddContractBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddContractBtn.FlatAppearance.BorderSize = 0
        AddContractBtn.FlatStyle = FlatStyle.Flat
        AddContractBtn.Font = New Font("Century Gothic", 11.25F)
        AddContractBtn.ForeColor = Color.White
        AddContractBtn.Location = New Point(16, 599)
        AddContractBtn.Name = "AddContractBtn"
        AddContractBtn.Size = New Size(260, 46)
        AddContractBtn.TabIndex = 6
        AddContractBtn.Text = "Add Contract"
        AddContractBtn.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(16, 322)
        Label3.Name = "Label3"
        Label3.Size = New Size(107, 17)
        Label3.TabIndex = 4
        Label3.Text = "Billing Frequency"
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
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridViewContract)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 2
        ' 
        ' DataGridViewContract
        ' 
        DataGridViewContract.AllowUserToAddRows = False
        DataGridViewContract.AllowUserToResizeColumns = False
        DataGridViewContract.AllowUserToResizeRows = False
        DataGridViewContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewContract.BackgroundColor = Color.White
        DataGridViewContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewContract.Dock = DockStyle.Fill
        DataGridViewContract.Location = New Point(0, 0)
        DataGridViewContract.Name = "DataGridViewContract"
        DataGridViewContract.ReadOnly = True
        DataGridViewContract.Size = New Size(606, 758)
        DataGridViewContract.TabIndex = 0
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' Contracts
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 758)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Contracts"
        Text = "BillingContracts"
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(DataGridViewContract, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents UpdateContractBtn As Button
    Friend WithEvents ClearFieldsBtn As Button
    Friend WithEvents AddContractBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewContract As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePickerEndDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxContractStatus As ComboBox
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents ComboBoxBillingFrequency As ComboBox
    Friend WithEvents LabelContractID As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBoxAddon As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label13 As Label
End Class
