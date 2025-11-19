<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Appointment
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appointment))
        Panel1 = New Panel()
        Panel14 = New Panel()
        TextBoxSearchBar = New TextBox()
        DataGridViewAppointment = New DataGridView()
        Panel3 = New Panel()
        ComboBoxDetailer = New ComboBox()
        Label16 = New Label()
        ComboBoxDiscount = New ComboBox()
        Label14 = New Label()
        Label13 = New Label()
        TextBoxCheque = New TextBox()
        PanelServiceInfo = New Panel()
        ListViewServices = New ListView()
        FullScreenServiceBtn = New Button()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        Label12 = New Label()
        TextBoxTotalPrice = New TextBox()
        TextBoxReferenceID = New TextBox()
        Label7 = New Label()
        PrintBillBtn = New Button()
        LabelAppointmentID = New Label()
        TextBoxNotes = New TextBox()
        Label3 = New Label()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddons = New ComboBox()
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
        Panel14.SuspendLayout()
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        PanelServiceInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel14)
        Panel1.Controls.Add(DataGridViewAppointment)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 3
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.White
        Panel14.Controls.Add(TextBoxSearchBar)
        Panel14.Dock = DockStyle.Top
        Panel14.Location = New Point(0, 0)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(606, 32)
        Panel14.TabIndex = 3
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(463, 6)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(140, 23)
        TextBoxSearchBar.TabIndex = 6
        TextBoxSearchBar.Text = "Search"
        ' 
        ' DataGridViewAppointment
        ' 
        DataGridViewAppointment.AllowUserToAddRows = False
        DataGridViewAppointment.AllowUserToResizeColumns = False
        DataGridViewAppointment.AllowUserToResizeRows = False
        DataGridViewAppointment.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewAppointment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewAppointment.BackgroundColor = Color.White
        DataGridViewAppointment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewAppointment.Location = New Point(-3, 32)
        DataGridViewAppointment.Name = "DataGridViewAppointment"
        DataGridViewAppointment.ReadOnly = True
        DataGridViewAppointment.Size = New Size(606, 726)
        DataGridViewAppointment.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(ComboBoxDetailer)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(ComboBoxDiscount)
        Panel3.Controls.Add(Label14)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(TextBoxCheque)
        Panel3.Controls.Add(PanelServiceInfo)
        Panel3.Controls.Add(FullScreenServiceBtn)
        Panel3.Controls.Add(RemoveServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(TextBoxTotalPrice)
        Panel3.Controls.Add(TextBoxReferenceID)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(PrintBillBtn)
        Panel3.Controls.Add(LabelAppointmentID)
        Panel3.Controls.Add(TextBoxNotes)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddons)
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
        ' ComboBoxDetailer
        ' 
        ComboBoxDetailer.AutoCompleteCustomSource.AddRange(New String() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDetailer.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDetailer.FormattingEnabled = True
        ComboBoxDetailer.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.Location = New Point(148, 470)
        ComboBoxDetailer.Name = "ComboBoxDetailer"
        ComboBoxDetailer.Size = New Size(129, 23)
        ComboBoxDetailer.TabIndex = 146
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 9F)
        Label16.Location = New Point(146, 450)
        Label16.Name = "Label16"
        Label16.Size = New Size(56, 17)
        Label16.TabIndex = 145
        Label16.Text = "Detailer"
        ' 
        ' ComboBoxDiscount
        ' 
        ComboBoxDiscount.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDiscount.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDiscount.Font = New Font("Century Gothic", 9F)
        ComboBoxDiscount.FormattingEnabled = True
        ComboBoxDiscount.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.Location = New Point(148, 339)
        ComboBoxDiscount.Name = "ComboBoxDiscount"
        ComboBoxDiscount.Size = New Size(130, 25)
        ComboBoxDiscount.TabIndex = 142
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.Location = New Point(148, 321)
        Label14.Name = "Label14"
        Label14.Size = New Size(72, 17)
        Label14.TabIndex = 141
        Label14.Text = "Discount %"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(146, 365)
        Label13.Name = "Label13"
        Label13.Size = New Size(78, 17)
        Label13.TabIndex = 136
        Label13.Text = "Cheque No."
        ' 
        ' TextBoxCheque
        ' 
        TextBoxCheque.Font = New Font("Century Gothic", 9F)
        TextBoxCheque.Location = New Point(148, 383)
        TextBoxCheque.Name = "TextBoxCheque"
        TextBoxCheque.ReadOnly = True
        TextBoxCheque.Size = New Size(129, 22)
        TextBoxCheque.TabIndex = 135
        ' 
        ' PanelServiceInfo
        ' 
        PanelServiceInfo.Controls.Add(ListViewServices)
        PanelServiceInfo.Location = New Point(16, 173)
        PanelServiceInfo.Name = "PanelServiceInfo"
        PanelServiceInfo.Size = New Size(260, 102)
        PanelServiceInfo.TabIndex = 134
        ' 
        ' ListViewServices
        ' 
        ListViewServices.Dock = DockStyle.Fill
        ListViewServices.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewServices.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewServices.FullRowSelect = True
        ListViewServices.GridLines = True
        ListViewServices.Location = New Point(0, 0)
        ListViewServices.Name = "ListViewServices"
        ListViewServices.Size = New Size(260, 102)
        ListViewServices.TabIndex = 100
        ListViewServices.UseCompatibleStateImageBehavior = False
        ' 
        ' FullScreenServiceBtn
        ' 
        FullScreenServiceBtn.FlatAppearance.BorderSize = 0
        FullScreenServiceBtn.FlatStyle = FlatStyle.Flat
        FullScreenServiceBtn.Image = My.Resources.Resources.expand1
        FullScreenServiceBtn.Location = New Point(128, 139)
        FullScreenServiceBtn.Name = "FullScreenServiceBtn"
        FullScreenServiceBtn.Size = New Size(37, 33)
        FullScreenServiceBtn.TabIndex = 133
        FullScreenServiceBtn.UseVisualStyleBackColor = True
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
        TextBoxReferenceID.Size = New Size(129, 22)
        TextBoxReferenceID.TabIndex = 37
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(16, 365)
        Label7.Name = "Label7"
        Label7.Size = New Size(71, 17)
        Label7.TabIndex = 36
        Label7.Text = "Gcash Ref."
        ' 
        ' PrintBillBtn
        ' 
        PrintBillBtn.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        PrintBillBtn.FlatAppearance.BorderSize = 0
        PrintBillBtn.FlatStyle = FlatStyle.Flat
        PrintBillBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.ForeColor = Color.White
        PrintBillBtn.Image = CType(resources.GetObject("PrintBillBtn.Image"), Image)
        PrintBillBtn.Location = New Point(189, 543)
        PrintBillBtn.Name = "PrintBillBtn"
        PrintBillBtn.Size = New Size(87, 30)
        PrintBillBtn.TabIndex = 35
        PrintBillBtn.Text = "Print Bill"
        PrintBillBtn.TextAlign = ContentAlignment.MiddleRight
        PrintBillBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        PrintBillBtn.UseVisualStyleBackColor = False
        ' 
        ' LabelAppointmentID
        ' 
        LabelAppointmentID.AutoSize = True
        LabelAppointmentID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelAppointmentID.ForeColor = Color.Red
        LabelAppointmentID.Location = New Point(112, 558)
        LabelAppointmentID.Name = "LabelAppointmentID"
        LabelAppointmentID.Size = New Size(0, 15)
        LabelAppointmentID.TabIndex = 31
        ' 
        ' TextBoxNotes
        ' 
        TextBoxNotes.Location = New Point(16, 514)
        TextBoxNotes.Multiline = True
        TextBoxNotes.Name = "TextBoxNotes"
        TextBoxNotes.Size = New Size(261, 23)
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
        ComboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 339)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(129, 23)
        ComboBoxPaymentMethod.TabIndex = 27
        ' 
        ' ComboBoxAddons
        ' 
        ComboBoxAddons.FormattingEnabled = True
        ComboBoxAddons.Location = New Point(148, 115)
        ComboBoxAddons.Name = "ComboBoxAddons"
        ComboBoxAddons.Size = New Size(129, 23)
        ComboBoxAddons.TabIndex = 26
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
        Label9.Location = New Point(16, 558)
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
        ComboBoxAppointmentStatus.AutoCompleteCustomSource.AddRange(New String() {"Confirmed", "Cancelled", "No-Show"})
        ComboBoxAppointmentStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxAppointmentStatus.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxAppointmentStatus.FormattingEnabled = True
        ComboBoxAppointmentStatus.Items.AddRange(New Object() {"Confirmed", "Cancelled", "No-Show"})
        ComboBoxAppointmentStatus.Location = New Point(16, 470)
        ComboBoxAppointmentStatus.Name = "ComboBoxAppointmentStatus"
        ComboBoxAppointmentStatus.Size = New Size(129, 23)
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
        Label6.Size = New Size(147, 17)
        Label6.TabIndex = 14
        Label6.Text = "Appointment DateTime"
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
        UpdateAppointmentBtn.Location = New Point(146, 628)
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
        ClearFieldsBtn.Location = New Point(16, 628)
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
        AddAppointmentBtn.Location = New Point(16, 576)
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
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        CType(DataGridViewAppointment, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        PanelServiceInfo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewAppointment As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddons As ComboBox
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
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents FullScreenServiceBtn As Button
    Friend WithEvents PanelServiceInfo As Panel
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxCheque As TextBox
    Friend WithEvents ComboBoxDiscount As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBoxDetailer As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBoxSearchBar As TextBox
End Class
