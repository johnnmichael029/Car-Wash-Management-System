<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PickUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickUp))
        PrintDocumentBill = New Printing.PrintDocument()
        DataGridViewPickup = New DataGridView()
        Panel1 = New Panel()
        Panel14 = New Panel()
        TextBoxSearchBar = New TextBox()
        Panel2 = New Panel()
        TextBoxPickupAddress = New TextBox()
        Label15 = New Label()
        UpdatePickupBtn = New Button()
        ClearFieldsBtn = New Button()
        TextBoxNotes = New TextBox()
        Label14 = New Label()
        ComboBoxDetailer = New ComboBox()
        DateTimePickerStartDate = New DateTimePicker()
        Label16 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        ComboBoxPickupStatus = New ComboBox()
        ComboBoxDiscount = New ComboBox()
        Label10 = New Label()
        Label13 = New Label()
        TextBoxCheque = New TextBox()
        PanelServiceInfo = New Panel()
        ListViewServices = New ListView()
        FullScreenServiceBtn = New Button()
        Label8 = New Label()
        TextBoxTotalPrice = New TextBox()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxReferenceID = New TextBox()
        Label7 = New Label()
        LabelPickupID = New Label()
        PrintBillBtn = New Button()
        Label9 = New Label()
        AddBtn = New Button()
        TextBoxPrice = New TextBox()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddons = New ComboBox()
        ComboBoxServices = New ComboBox()
        TextBoxCustomerID = New TextBox()
        TextBoxCustomerName = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label1 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(DataGridViewPickup, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel14.SuspendLayout()
        Panel2.SuspendLayout()
        PanelServiceInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' DataGridViewPickup
        ' 
        DataGridViewPickup.AllowUserToAddRows = False
        DataGridViewPickup.AllowUserToResizeColumns = False
        DataGridViewPickup.AllowUserToResizeRows = False
        DataGridViewPickup.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewPickup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewPickup.BackgroundColor = Color.White
        DataGridViewPickup.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewPickup.Location = New Point(0, 32)
        DataGridViewPickup.Name = "DataGridViewPickup"
        DataGridViewPickup.ReadOnly = True
        DataGridViewPickup.Size = New Size(606, 726)
        DataGridViewPickup.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel14)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(DataGridViewPickup)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 5
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.White
        Panel14.Controls.Add(TextBoxSearchBar)
        Panel14.Dock = DockStyle.Top
        Panel14.Location = New Point(0, 0)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(606, 32)
        Panel14.TabIndex = 20
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(460, 6)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(140, 23)
        TextBoxSearchBar.TabIndex = 6
        TextBoxSearchBar.Text = "Search"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(TextBoxPickupAddress)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(UpdatePickupBtn)
        Panel2.Controls.Add(ClearFieldsBtn)
        Panel2.Controls.Add(TextBoxNotes)
        Panel2.Controls.Add(Label14)
        Panel2.Controls.Add(ComboBoxDetailer)
        Panel2.Controls.Add(DateTimePickerStartDate)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(ComboBoxPickupStatus)
        Panel2.Controls.Add(ComboBoxDiscount)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(TextBoxCheque)
        Panel2.Controls.Add(PanelServiceInfo)
        Panel2.Controls.Add(FullScreenServiceBtn)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(TextBoxTotalPrice)
        Panel2.Controls.Add(RemoveServiceBtn)
        Panel2.Controls.Add(AddServiceBtn)
        Panel2.Controls.Add(TextBoxReferenceID)
        Panel2.Controls.Add(Label7)
        Panel2.Controls.Add(LabelPickupID)
        Panel2.Controls.Add(PrintBillBtn)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(AddBtn)
        Panel2.Controls.Add(TextBoxPrice)
        Panel2.Controls.Add(ComboBoxPaymentMethod)
        Panel2.Controls.Add(ComboBoxAddons)
        Panel2.Controls.Add(ComboBoxServices)
        Panel2.Controls.Add(TextBoxCustomerID)
        Panel2.Controls.Add(TextBoxCustomerName)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label3)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(606, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(305, 758)
        Panel2.TabIndex = 19
        ' 
        ' TextBoxPickupAddress
        ' 
        TextBoxPickupAddress.Location = New Point(16, 297)
        TextBoxPickupAddress.Multiline = True
        TextBoxPickupAddress.Name = "TextBoxPickupAddress"
        TextBoxPickupAddress.Size = New Size(261, 22)
        TextBoxPickupAddress.TabIndex = 156
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.Location = New Point(16, 279)
        Label15.Name = "Label15"
        Label15.Size = New Size(97, 17)
        Label15.TabIndex = 155
        Label15.Text = "Pickup Address"
        ' 
        ' UpdatePickupBtn
        ' 
        UpdatePickupBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdatePickupBtn.FlatAppearance.BorderSize = 0
        UpdatePickupBtn.FlatStyle = FlatStyle.Flat
        UpdatePickupBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        UpdatePickupBtn.ForeColor = Color.White
        UpdatePickupBtn.Location = New Point(147, 629)
        UpdatePickupBtn.Name = "UpdatePickupBtn"
        UpdatePickupBtn.Size = New Size(129, 30)
        UpdatePickupBtn.TabIndex = 154
        UpdatePickupBtn.Text = "Update Pickup"
        UpdatePickupBtn.UseVisualStyleBackColor = False
        ' 
        ' ClearFieldsBtn
        ' 
        ClearFieldsBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ClearFieldsBtn.FlatAppearance.BorderSize = 0
        ClearFieldsBtn.FlatStyle = FlatStyle.Flat
        ClearFieldsBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ClearFieldsBtn.ForeColor = Color.White
        ClearFieldsBtn.Image = CType(resources.GetObject("ClearFieldsBtn.Image"), Image)
        ClearFieldsBtn.Location = New Point(17, 629)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(129, 30)
        ClearFieldsBtn.TabIndex = 153
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxNotes
        ' 
        TextBoxNotes.Location = New Point(16, 516)
        TextBoxNotes.Multiline = True
        TextBoxNotes.Name = "TextBoxNotes"
        TextBoxNotes.Size = New Size(261, 22)
        TextBoxNotes.TabIndex = 152
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.Location = New Point(16, 498)
        Label14.Name = "Label14"
        Label14.Size = New Size(43, 17)
        Label14.TabIndex = 151
        Label14.Text = "Notes"
        ' 
        ' ComboBoxDetailer
        ' 
        ComboBoxDetailer.AutoCompleteCustomSource.AddRange(New String() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDetailer.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDetailer.FormattingEnabled = True
        ComboBoxDetailer.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxDetailer.Location = New Point(149, 472)
        ComboBoxDetailer.Name = "ComboBoxDetailer"
        ComboBoxDetailer.Size = New Size(128, 23)
        ComboBoxDetailer.TabIndex = 150
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        DateTimePickerStartDate.ImeMode = ImeMode.NoControl
        DateTimePickerStartDate.Location = New Point(16, 253)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(260, 23)
        DateTimePickerStartDate.TabIndex = 144
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 9F)
        Label16.Location = New Point(147, 452)
        Label16.Name = "Label16"
        Label16.Size = New Size(56, 17)
        Label16.TabIndex = 149
        Label16.Text = "Detailer"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.Location = New Point(16, 235)
        Label12.Name = "Label12"
        Label12.Size = New Size(107, 17)
        Label12.TabIndex = 143
        Label12.Text = "Pickup DateTime"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(14, 454)
        Label11.Name = "Label11"
        Label11.Size = New Size(87, 17)
        Label11.TabIndex = 148
        Label11.Text = "Pickup Status"
        ' 
        ' ComboBoxPickupStatus
        ' 
        ComboBoxPickupStatus.AutoCompleteCustomSource.AddRange(New String() {"Confirmed", "On-The-Way", "Completed", "Cancelled"})
        ComboBoxPickupStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxPickupStatus.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPickupStatus.FormattingEnabled = True
        ComboBoxPickupStatus.Items.AddRange(New Object() {"Confirmed", "On-The-Way", "Completed", "Cancelled"})
        ComboBoxPickupStatus.Location = New Point(16, 472)
        ComboBoxPickupStatus.Name = "ComboBoxPickupStatus"
        ComboBoxPickupStatus.Size = New Size(129, 23)
        ComboBoxPickupStatus.TabIndex = 147
        ' 
        ' ComboBoxDiscount
        ' 
        ComboBoxDiscount.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDiscount.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDiscount.Font = New Font("Century Gothic", 9F)
        ComboBoxDiscount.FormattingEnabled = True
        ComboBoxDiscount.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.Location = New Point(149, 340)
        ComboBoxDiscount.Name = "ComboBoxDiscount"
        ComboBoxDiscount.Size = New Size(128, 25)
        ComboBoxDiscount.TabIndex = 140
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 9F)
        Label10.Location = New Point(149, 322)
        Label10.Name = "Label10"
        Label10.Size = New Size(72, 17)
        Label10.TabIndex = 139
        Label10.Text = "Discount %"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(147, 368)
        Label13.Name = "Label13"
        Label13.Size = New Size(78, 17)
        Label13.TabIndex = 138
        Label13.Text = "Cheque No."
        ' 
        ' TextBoxCheque
        ' 
        TextBoxCheque.Font = New Font("Century Gothic", 9F)
        TextBoxCheque.Location = New Point(149, 386)
        TextBoxCheque.Name = "TextBoxCheque"
        TextBoxCheque.ReadOnly = True
        TextBoxCheque.Size = New Size(128, 22)
        TextBoxCheque.TabIndex = 137
        ' 
        ' PanelServiceInfo
        ' 
        PanelServiceInfo.Controls.Add(ListViewServices)
        PanelServiceInfo.Location = New Point(16, 130)
        PanelServiceInfo.Name = "PanelServiceInfo"
        PanelServiceInfo.Size = New Size(260, 102)
        PanelServiceInfo.TabIndex = 132
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
        FullScreenServiceBtn.Location = New Point(128, 97)
        FullScreenServiceBtn.Name = "FullScreenServiceBtn"
        FullScreenServiceBtn.Size = New Size(37, 33)
        FullScreenServiceBtn.TabIndex = 131
        FullScreenServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(147, 411)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 17)
        Label8.TabIndex = 87
        Label8.Text = "Total Price"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Font = New Font("Century Gothic", 9F)
        TextBoxTotalPrice.Location = New Point(147, 429)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.ReadOnly = True
        TextBoxTotalPrice.Size = New Size(130, 22)
        TextBoxTotalPrice.TabIndex = 86
        ' 
        ' RemoveServiceBtn
        ' 
        RemoveServiceBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveServiceBtn.FlatAppearance.BorderSize = 0
        RemoveServiceBtn.FlatStyle = FlatStyle.Flat
        RemoveServiceBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveServiceBtn.ForeColor = Color.White
        RemoveServiceBtn.Location = New Point(202, 101)
        RemoveServiceBtn.Name = "RemoveServiceBtn"
        RemoveServiceBtn.Size = New Size(75, 23)
        RemoveServiceBtn.TabIndex = 85
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
        AddServiceBtn.Location = New Point(16, 101)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(75, 23)
        AddServiceBtn.TabIndex = 84
        AddServiceBtn.Text = "Add"
        AddServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(15, 386)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(130, 22)
        TextBoxReferenceID.TabIndex = 35
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(15, 368)
        Label7.Name = "Label7"
        Label7.Size = New Size(71, 17)
        Label7.TabIndex = 34
        Label7.Text = "Gcash Ref."
        ' 
        ' LabelPickupID
        ' 
        LabelPickupID.AutoSize = True
        LabelPickupID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelPickupID.ForeColor = Color.Red
        LabelPickupID.Location = New Point(70, 557)
        LabelPickupID.Name = "LabelPickupID"
        LabelPickupID.Size = New Size(0, 15)
        LabelPickupID.TabIndex = 33
        ' 
        ' PrintBillBtn
        ' 
        PrintBillBtn.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        PrintBillBtn.FlatAppearance.BorderSize = 0
        PrintBillBtn.FlatStyle = FlatStyle.Flat
        PrintBillBtn.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.ForeColor = Color.White
        PrintBillBtn.Image = CType(resources.GetObject("PrintBillBtn.Image"), Image)
        PrintBillBtn.Location = New Point(190, 544)
        PrintBillBtn.Name = "PrintBillBtn"
        PrintBillBtn.Size = New Size(87, 30)
        PrintBillBtn.TabIndex = 33
        PrintBillBtn.Text = "Print Bill"
        PrintBillBtn.TextAlign = ContentAlignment.MiddleRight
        PrintBillBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        PrintBillBtn.UseVisualStyleBackColor = False
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(17, 557)
        Label9.Name = "Label9"
        Label9.Size = New Size(62, 17)
        Label9.TabIndex = 32
        Label9.Text = "Pickup ID"
        ' 
        ' AddBtn
        ' 
        AddBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddBtn.FlatAppearance.BorderSize = 0
        AddBtn.FlatStyle = FlatStyle.Flat
        AddBtn.Font = New Font("Century Gothic", 11.25F)
        AddBtn.ForeColor = Color.White
        AddBtn.Location = New Point(17, 577)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(260, 46)
        AddBtn.TabIndex = 32
        AddBtn.Text = "Add Pickup"
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Font = New Font("Century Gothic", 9F)
        TextBoxPrice.Location = New Point(16, 429)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(129, 22)
        TextBoxPrice.TabIndex = 31
        ' 
        ' ComboBoxPaymentMethod
        ' 
        ComboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(New String() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPaymentMethod.Font = New Font("Century Gothic", 9F)
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Location = New Point(15, 340)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(130, 25)
        ComboBoxPaymentMethod.TabIndex = 30
        ' 
        ' ComboBoxAddons
        ' 
        ComboBoxAddons.Font = New Font("Century Gothic", 9F)
        ComboBoxAddons.FormattingEnabled = True
        ComboBoxAddons.Location = New Point(150, 70)
        ComboBoxAddons.Name = "ComboBoxAddons"
        ComboBoxAddons.Size = New Size(126, 25)
        ComboBoxAddons.TabIndex = 29
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.Font = New Font("Century Gothic", 9F)
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 70)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(130, 25)
        ComboBoxServices.TabIndex = 28
        ' 
        ' TextBoxCustomerID
        ' 
        TextBoxCustomerID.Font = New Font("Century Gothic", 9F)
        TextBoxCustomerID.Location = New Point(150, 27)
        TextBoxCustomerID.Name = "TextBoxCustomerID"
        TextBoxCustomerID.ReadOnly = True
        TextBoxCustomerID.Size = New Size(127, 22)
        TextBoxCustomerID.TabIndex = 27
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Font = New Font("Century Gothic", 9F)
        TextBoxCustomerName.Location = New Point(16, 27)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(130, 22)
        TextBoxCustomerName.TabIndex = 26
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 9F)
        Label6.Location = New Point(150, 52)
        Label6.Name = "Label6"
        Label6.Size = New Size(53, 17)
        Label6.TabIndex = 23
        Label6.Text = "Addons"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 9F)
        Label5.Location = New Point(16, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(104, 17)
        Label5.TabIndex = 18
        Label5.Text = "Customer Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(149, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(80, 17)
        Label1.TabIndex = 4
        Label1.Text = "Customer ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.Location = New Point(15, 322)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 17)
        Label4.TabIndex = 15
        Label4.Text = "Payment Method"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(16, 52)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 17)
        Label2.TabIndex = 5
        Label2.Text = "Service"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(15, 411)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 17)
        Label3.TabIndex = 6
        Label3.Text = "Subtotal"
        ' 
        ' PickUp
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 758)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "PickUp"
        Text = "PickUp"
        CType(DataGridViewPickup, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        PanelServiceInfo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents DataGridViewPickup As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ComboBoxDiscount As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxCheque As TextBox
    Friend WithEvents PanelServiceInfo As Panel
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents FullScreenServiceBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents LabelPickupID As Label
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents AddBtn As Button
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddons As ComboBox
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBoxSearchBar As TextBox
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBoxDetailer As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPickupStatus As ComboBox
    Friend WithEvents TextBoxNotes As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents UpdatePickupBtn As Button
    Friend WithEvents ClearFieldsBtn As Button
    Friend WithEvents TextBoxPickupAddress As TextBox
    Friend WithEvents Label15 As Label
End Class
