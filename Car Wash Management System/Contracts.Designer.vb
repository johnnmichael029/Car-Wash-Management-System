<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Contracts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Contracts))
        Panel3 = New Panel()
        ComboBoxDetailer = New ComboBox()
        Label16 = New Label()
        ComboBoxDiscount = New ComboBox()
        Label15 = New Label()
        Label14 = New Label()
        TextBoxCheque = New TextBox()
        PanelServiceInfo = New Panel()
        ListViewServices = New ListView()
        FullScreenServiceBtn = New Button()
        TextBoxReferenceID = New TextBox()
        Label13 = New Label()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        PrintBillBtn = New Button()
        Label12 = New Label()
        TextBoxTotalPrice = New TextBox()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddons = New ComboBox()
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
        Panel14 = New Panel()
        TextBoxSearchBar = New TextBox()
        DataGridViewContract = New DataGridView()
        PrintDocumentBill = New Printing.PrintDocument()
        Panel3.SuspendLayout()
        PanelServiceInfo.SuspendLayout()
        Panel1.SuspendLayout()
        Panel14.SuspendLayout()
        CType(DataGridViewContract, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(ComboBoxDetailer)
        Panel3.Controls.Add(Label16)
        Panel3.Controls.Add(ComboBoxDiscount)
        Panel3.Controls.Add(Label15)
        Panel3.Controls.Add(Label14)
        Panel3.Controls.Add(TextBoxCheque)
        Panel3.Controls.Add(PanelServiceInfo)
        Panel3.Controls.Add(FullScreenServiceBtn)
        Panel3.Controls.Add(TextBoxReferenceID)
        Panel3.Controls.Add(Label13)
        Panel3.Controls.Add(RemoveServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(PrintBillBtn)
        Panel3.Controls.Add(Label12)
        Panel3.Controls.Add(TextBoxTotalPrice)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddons)
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
        ' ComboBoxDetailer
        ' 
        ComboBoxDetailer.AutoCompleteCustomSource.AddRange(New String() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDetailer.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDetailer.FormattingEnabled = True
        ComboBoxDetailer.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.Location = New Point(148, 515)
        ComboBoxDetailer.Name = "ComboBoxDetailer"
        ComboBoxDetailer.Size = New Size(129, 23)
        ComboBoxDetailer.TabIndex = 144
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 9F)
        Label16.Location = New Point(146, 495)
        Label16.Name = "Label16"
        Label16.Size = New Size(56, 17)
        Label16.TabIndex = 143
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
        ComboBoxDiscount.Location = New Point(148, 384)
        ComboBoxDiscount.Name = "ComboBoxDiscount"
        ComboBoxDiscount.Size = New Size(130, 25)
        ComboBoxDiscount.TabIndex = 142
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.Location = New Point(148, 366)
        Label15.Name = "Label15"
        Label15.Size = New Size(72, 17)
        Label15.TabIndex = 141
        Label15.Text = "Discount %"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.Location = New Point(146, 410)
        Label14.Name = "Label14"
        Label14.Size = New Size(78, 17)
        Label14.TabIndex = 138
        Label14.Text = "Cheque No."
        ' 
        ' TextBoxCheque
        ' 
        TextBoxCheque.Font = New Font("Century Gothic", 9F)
        TextBoxCheque.Location = New Point(148, 428)
        TextBoxCheque.Name = "TextBoxCheque"
        TextBoxCheque.ReadOnly = True
        TextBoxCheque.Size = New Size(129, 22)
        TextBoxCheque.TabIndex = 137
        ' 
        ' PanelServiceInfo
        ' 
        PanelServiceInfo.Controls.Add(ListViewServices)
        PanelServiceInfo.Location = New Point(16, 173)
        PanelServiceInfo.Name = "PanelServiceInfo"
        PanelServiceInfo.Size = New Size(260, 102)
        PanelServiceInfo.TabIndex = 133
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
        FullScreenServiceBtn.Location = New Point(127, 139)
        FullScreenServiceBtn.Name = "FullScreenServiceBtn"
        FullScreenServiceBtn.Size = New Size(37, 33)
        FullScreenServiceBtn.TabIndex = 132
        FullScreenServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 428)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(129, 22)
        TextBoxReferenceID.TabIndex = 97
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(16, 410)
        Label13.Name = "Label13"
        Label13.Size = New Size(71, 17)
        Label13.TabIndex = 96
        Label13.Text = "Gcash Ref."
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
        ' PrintBillBtn
        ' 
        PrintBillBtn.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        PrintBillBtn.FlatAppearance.BorderSize = 0
        PrintBillBtn.FlatStyle = FlatStyle.Flat
        PrintBillBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.ForeColor = Color.White
        PrintBillBtn.Image = CType(resources.GetObject("PrintBillBtn.Image"), Image)
        PrintBillBtn.Location = New Point(189, 542)
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
        TextBoxTotalPrice.Location = New Point(147, 472)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.ReadOnly = True
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
        ComboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Location = New Point(17, 384)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(128, 23)
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
        ' LabelContractID
        ' 
        LabelContractID.AutoSize = True
        LabelContractID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelContractID.ForeColor = Color.Red
        LabelContractID.Location = New Point(87, 555)
        LabelContractID.Name = "LabelContractID"
        LabelContractID.Size = New Size(0, 15)
        LabelContractID.TabIndex = 23
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(16, 555)
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
        ComboBoxContractStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxContractStatus.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxContractStatus.FormattingEnabled = True
        ComboBoxContractStatus.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxContractStatus.Location = New Point(16, 515)
        ComboBoxContractStatus.Name = "ComboBoxContractStatus"
        ComboBoxContractStatus.Size = New Size(129, 23)
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
        ComboBoxBillingFrequency.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxBillingFrequency.DropDownStyle = ComboBoxStyle.DropDownList
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
        UpdateContractBtn.Location = New Point(146, 627)
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
        ClearFieldsBtn.Location = New Point(16, 627)
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
        AddContractBtn.Location = New Point(16, 575)
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
        Panel1.Controls.Add(Panel14)
        Panel1.Controls.Add(DataGridViewContract)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 2
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
        ' DataGridViewContract
        ' 
        DataGridViewContract.AllowUserToAddRows = False
        DataGridViewContract.AllowUserToResizeColumns = False
        DataGridViewContract.AllowUserToResizeRows = False
        DataGridViewContract.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewContract.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewContract.BackgroundColor = Color.White
        DataGridViewContract.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewContract.Location = New Point(0, 32)
        DataGridViewContract.Name = "DataGridViewContract"
        DataGridViewContract.ReadOnly = True
        DataGridViewContract.Size = New Size(606, 726)
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
        PanelServiceInfo.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
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
    Friend WithEvents ComboBoxAddons As ComboBox
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
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents FullScreenServiceBtn As Button
    Friend WithEvents PanelServiceInfo As Panel
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxCheque As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboBoxDetailer As ComboBox
    Friend WithEvents ComboBoxDiscount As ComboBox
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBoxSearchBar As TextBox
End Class
