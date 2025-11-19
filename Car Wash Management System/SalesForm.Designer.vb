<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesForm))
        DataGridViewSales = New DataGridView()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel14 = New Panel()
        TextBoxSearchBar = New TextBox()
        Panel1 = New Panel()
        ComboBoxDetailer = New ComboBox()
        Label11 = New Label()
        ComboBoxDiscount = New ComboBox()
        Label10 = New Label()
        Label13 = New Label()
        TextBoxCheque = New TextBox()
        PanelServiceInfo = New Panel()
        ListViewServices = New ListView()
        FullScreenServiceBtn = New Button()
        UpdateBtn = New Button()
        Label8 = New Label()
        TextBoxTotalPrice = New TextBox()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxReferenceID = New TextBox()
        Label7 = New Label()
        LabelSalesID = New Label()
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
        ClearBtn = New Button()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PrintDocumentBill = New Printing.PrintDocument()
        CType(DataGridViewSales, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel14.SuspendLayout()
        Panel1.SuspendLayout()
        PanelServiceInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridViewSales
        ' 
        DataGridViewSales.AllowUserToAddRows = False
        DataGridViewSales.AllowUserToResizeColumns = False
        DataGridViewSales.AllowUserToResizeRows = False
        DataGridViewSales.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewSales.BackgroundColor = Color.White
        DataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewSales.Location = New Point(0, 32)
        DataGridViewSales.Name = "DataGridViewSales"
        DataGridViewSales.ReadOnly = True
        DataGridViewSales.Size = New Size(606, 726)
        DataGridViewSales.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(911, 758)
        Panel2.TabIndex = 20
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel14)
        Panel3.Controls.Add(Panel1)
        Panel3.Controls.Add(DataGridViewSales)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(911, 758)
        Panel3.TabIndex = 19
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.White
        Panel14.Controls.Add(TextBoxSearchBar)
        Panel14.Dock = DockStyle.Top
        Panel14.Location = New Point(0, 0)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(606, 32)
        Panel14.TabIndex = 2
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(460, 6)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(140, 23)
        TextBoxSearchBar.TabIndex = 5
        TextBoxSearchBar.Text = "Search"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(ComboBoxDetailer)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(ComboBoxDiscount)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(TextBoxCheque)
        Panel1.Controls.Add(PanelServiceInfo)
        Panel1.Controls.Add(FullScreenServiceBtn)
        Panel1.Controls.Add(UpdateBtn)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(TextBoxTotalPrice)
        Panel1.Controls.Add(RemoveServiceBtn)
        Panel1.Controls.Add(AddServiceBtn)
        Panel1.Controls.Add(TextBoxReferenceID)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(LabelSalesID)
        Panel1.Controls.Add(PrintBillBtn)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(AddBtn)
        Panel1.Controls.Add(TextBoxPrice)
        Panel1.Controls.Add(ComboBoxPaymentMethod)
        Panel1.Controls.Add(ComboBoxAddons)
        Panel1.Controls.Add(ComboBoxServices)
        Panel1.Controls.Add(TextBoxCustomerID)
        Panel1.Controls.Add(TextBoxCustomerName)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(ClearBtn)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(606, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(305, 758)
        Panel1.TabIndex = 18
        ' 
        ' ComboBoxDetailer
        ' 
        ComboBoxDetailer.Font = New Font("Century Gothic", 9F)
        ComboBoxDetailer.FormattingEnabled = True
        ComboBoxDetailer.Location = New Point(17, 430)
        ComboBoxDetailer.Name = "ComboBoxDetailer"
        ComboBoxDetailer.Size = New Size(261, 25)
        ComboBoxDetailer.TabIndex = 142
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(16, 410)
        Label11.Name = "Label11"
        Label11.Size = New Size(56, 17)
        Label11.TabIndex = 141
        Label11.Text = "Detailer"
        ' 
        ' ComboBoxDiscount
        ' 
        ComboBoxDiscount.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDiscount.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDiscount.Font = New Font("Century Gothic", 9F)
        ComboBoxDiscount.FormattingEnabled = True
        ComboBoxDiscount.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.Location = New Point(150, 296)
        ComboBoxDiscount.Name = "ComboBoxDiscount"
        ComboBoxDiscount.Size = New Size(130, 25)
        ComboBoxDiscount.TabIndex = 140
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 9F)
        Label10.Location = New Point(150, 278)
        Label10.Name = "Label10"
        Label10.Size = New Size(72, 17)
        Label10.TabIndex = 139
        Label10.Text = "Discount %"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(148, 324)
        Label13.Name = "Label13"
        Label13.Size = New Size(78, 17)
        Label13.TabIndex = 138
        Label13.Text = "Cheque No."
        ' 
        ' TextBoxCheque
        ' 
        TextBoxCheque.Font = New Font("Century Gothic", 9F)
        TextBoxCheque.Location = New Point(150, 342)
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
        FullScreenServiceBtn.Location = New Point(128, 140)
        FullScreenServiceBtn.Name = "FullScreenServiceBtn"
        FullScreenServiceBtn.Size = New Size(37, 33)
        FullScreenServiceBtn.TabIndex = 131
        FullScreenServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(17, 596)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(260, 46)
        UpdateBtn.TabIndex = 88
        UpdateBtn.Text = "Update Sales"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(148, 367)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 17)
        Label8.TabIndex = 87
        Label8.Text = "Total Price"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Font = New Font("Century Gothic", 9F)
        TextBoxTotalPrice.Location = New Point(148, 385)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.ReadOnly = True
        TextBoxTotalPrice.Size = New Size(129, 22)
        TextBoxTotalPrice.TabIndex = 86
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
        AddServiceBtn.Location = New Point(16, 144)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(75, 23)
        AddServiceBtn.TabIndex = 84
        AddServiceBtn.Text = "Add"
        AddServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 342)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(130, 22)
        TextBoxReferenceID.TabIndex = 35
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(16, 324)
        Label7.Name = "Label7"
        Label7.Size = New Size(71, 17)
        Label7.TabIndex = 34
        Label7.Text = "Gcash Ref."
        ' 
        ' LabelSalesID
        ' 
        LabelSalesID.AutoSize = True
        LabelSalesID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelSalesID.ForeColor = Color.Red
        LabelSalesID.Location = New Point(69, 472)
        LabelSalesID.Name = "LabelSalesID"
        LabelSalesID.Size = New Size(0, 15)
        LabelSalesID.TabIndex = 33
        ' 
        ' PrintBillBtn
        ' 
        PrintBillBtn.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        PrintBillBtn.FlatAppearance.BorderSize = 0
        PrintBillBtn.FlatStyle = FlatStyle.Flat
        PrintBillBtn.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.ForeColor = Color.White
        PrintBillBtn.Image = CType(resources.GetObject("PrintBillBtn.Image"), Image)
        PrintBillBtn.Location = New Point(189, 459)
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
        Label9.Location = New Point(16, 472)
        Label9.Name = "Label9"
        Label9.Size = New Size(54, 17)
        Label9.TabIndex = 32
        Label9.Text = "Sales ID"
        ' 
        ' AddBtn
        ' 
        AddBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddBtn.FlatAppearance.BorderSize = 0
        AddBtn.FlatStyle = FlatStyle.Flat
        AddBtn.Font = New Font("Century Gothic", 11.25F)
        AddBtn.ForeColor = Color.White
        AddBtn.Location = New Point(16, 492)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(260, 46)
        AddBtn.TabIndex = 32
        AddBtn.Text = "Add Sales"
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Font = New Font("Century Gothic", 9F)
        TextBoxPrice.Location = New Point(17, 385)
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
        ComboBoxPaymentMethod.Location = New Point(16, 296)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(130, 25)
        ComboBoxPaymentMethod.TabIndex = 30
        ' 
        ' ComboBoxAddons
        ' 
        ComboBoxAddons.Font = New Font("Century Gothic", 9F)
        ComboBoxAddons.FormattingEnabled = True
        ComboBoxAddons.Location = New Point(150, 113)
        ComboBoxAddons.Name = "ComboBoxAddons"
        ComboBoxAddons.Size = New Size(130, 25)
        ComboBoxAddons.TabIndex = 29
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.Font = New Font("Century Gothic", 9F)
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 113)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(130, 25)
        ComboBoxServices.TabIndex = 28
        ' 
        ' TextBoxCustomerID
        ' 
        TextBoxCustomerID.Font = New Font("Century Gothic", 9F)
        TextBoxCustomerID.Location = New Point(16, 70)
        TextBoxCustomerID.Name = "TextBoxCustomerID"
        TextBoxCustomerID.ReadOnly = True
        TextBoxCustomerID.Size = New Size(261, 22)
        TextBoxCustomerID.TabIndex = 27
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Font = New Font("Century Gothic", 9F)
        TextBoxCustomerName.Location = New Point(16, 27)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(261, 22)
        TextBoxCustomerName.TabIndex = 26
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 9F)
        Label6.Location = New Point(150, 95)
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
        Label1.Location = New Point(16, 52)
        Label1.Name = "Label1"
        Label1.Size = New Size(80, 17)
        Label1.TabIndex = 4
        Label1.Text = "Customer ID"
        ' 
        ' ClearBtn
        ' 
        ClearBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ClearBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ClearBtn.FlatAppearance.BorderSize = 0
        ClearBtn.FlatStyle = FlatStyle.Flat
        ClearBtn.Font = New Font("Century Gothic", 11.25F)
        ClearBtn.ForeColor = Color.White
        ClearBtn.Image = CType(resources.GetObject("ClearBtn.Image"), Image)
        ClearBtn.Location = New Point(16, 544)
        ClearBtn.Name = "ClearBtn"
        ClearBtn.Size = New Size(260, 46)
        ClearBtn.TabIndex = 14
        ClearBtn.Text = "Clear Fields"
        ClearBtn.TextAlign = ContentAlignment.MiddleRight
        ClearBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearBtn.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.Location = New Point(16, 278)
        Label4.Name = "Label4"
        Label4.Size = New Size(105, 17)
        Label4.TabIndex = 15
        Label4.Text = "Paymen Method"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(16, 95)
        Label2.Name = "Label2"
        Label2.Size = New Size(54, 17)
        Label2.TabIndex = 5
        Label2.Text = "Service"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(16, 367)
        Label3.Name = "Label3"
        Label3.Size = New Size(59, 17)
        Label3.TabIndex = 6
        Label3.Text = "Subtotal"
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' SalesForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 758)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "SalesForm"
        Text = "SalesHistory"
        CType(DataGridViewSales, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PanelServiceInfo.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridViewSales As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents ClearBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PrintBillBtn As Button
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents LabelSalesID As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents FullScreenServiceBtn As Button
    Friend WithEvents PanelServiceInfo As Panel
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxCheque As TextBox
    Friend WithEvents ComboBoxDiscount As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxDetailer As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBoxSearchBar As TextBox
End Class
