<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Panel9 = New Panel()
        PanelMontlySales1 = New Panel()
        ButtonToggleChart = New Button()
        PanelMontlySales = New Panel()
        Label10 = New Label()
        Panel12 = New Panel()
        ComboBoxFilter = New ComboBox()
        TextBoxSearchBar = New TextBox()
        Label9 = New Label()
        Panel13 = New Panel()
        DataGridViewLatestTransaction = New DataGridView()
        Panel2 = New Panel()
        ComboBoxDetailer = New ComboBox()
        Label24 = New Label()
        ComboBoxDiscount = New ComboBox()
        Label23 = New Label()
        Label22 = New Label()
        TextBoxCheque = New TextBox()
        PanelServiceInfo = New Panel()
        ListViewServices = New ListView()
        FullScreenServiceBtn = New Button()
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxReferenceID = New TextBox()
        Label17 = New Label()
        Label16 = New Label()
        TextBoxTotalPrice = New TextBox()
        LabelSalesID = New Label()
        Label1 = New Label()
        AddSalesBtn = New Button()
        TextBoxPrice = New TextBox()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddons = New ComboBox()
        ComboBoxServices = New ComboBox()
        TextBoxCustomerID = New TextBox()
        TextBoxCustomerName = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Label2 = New Label()
        ClearBtn = New Button()
        Label4 = New Label()
        Label3 = New Label()
        Label7 = New Label()
        Panel3 = New Panel()
        Panel1 = New Panel()
        PanelVehicleInfo = New Panel()
        ListViewVehicles = New ListView()
        FullScreenVehicleBtn = New Button()
        Label8 = New Label()
        RemoveVehicleBtn = New Button()
        Label11 = New Label()
        Label12 = New Label()
        AddVehicleBtn = New Button()
        TextBoxBarangay = New TextBox()
        Label13 = New Label()
        customerIDLabel = New Label()
        TextBoxLastName = New TextBox()
        ClearFieldsBtn = New Button()
        TextBoxVehicle = New TextBox()
        Label67 = New Label()
        Label15 = New Label()
        AddCustomerBtn = New Button()
        Label14 = New Label()
        TextBoxEmail = New TextBox()
        TextBoxName = New TextBox()
        TextBoxAddress = New TextBox()
        Label18 = New Label()
        Label21 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        TextBoxPlateNumber = New TextBox()
        TextBoxNumber = New TextBox()
        Panel4 = New Panel()
        PrintDocumentBill = New Printing.PrintDocument()
        Panel9.SuspendLayout()
        PanelMontlySales1.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        CType(DataGridViewLatestTransaction, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        PanelServiceInfo.SuspendLayout()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        PanelVehicleInfo.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel9
        ' 
        Panel9.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Panel9.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel9.Controls.Add(PanelMontlySales1)
        Panel9.Controls.Add(Panel12)
        Panel9.Location = New Point(0, 0)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(596, 680)
        Panel9.TabIndex = 6
        ' 
        ' PanelMontlySales1
        ' 
        PanelMontlySales1.BackColor = Color.White
        PanelMontlySales1.Controls.Add(ButtonToggleChart)
        PanelMontlySales1.Controls.Add(PanelMontlySales)
        PanelMontlySales1.Controls.Add(Label10)
        PanelMontlySales1.Dock = DockStyle.Top
        PanelMontlySales1.Location = New Point(0, 0)
        PanelMontlySales1.Name = "PanelMontlySales1"
        PanelMontlySales1.Size = New Size(596, 351)
        PanelMontlySales1.TabIndex = 7
        ' 
        ' ButtonToggleChart
        ' 
        ButtonToggleChart.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        ButtonToggleChart.FlatAppearance.BorderSize = 0
        ButtonToggleChart.FlatStyle = FlatStyle.Flat
        ButtonToggleChart.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonToggleChart.ForeColor = Color.White
        ButtonToggleChart.Location = New Point(453, 3)
        ButtonToggleChart.Name = "ButtonToggleChart"
        ButtonToggleChart.Size = New Size(140, 27)
        ButtonToggleChart.TabIndex = 9
        ButtonToggleChart.Text = "Daily Sales"
        ButtonToggleChart.UseVisualStyleBackColor = False
        ' 
        ' PanelMontlySales
        ' 
        PanelMontlySales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        PanelMontlySales.BackColor = Color.White
        PanelMontlySales.Location = New Point(0, 32)
        PanelMontlySales.Name = "PanelMontlySales"
        PanelMontlySales.Size = New Size(596, 319)
        PanelMontlySales.TabIndex = 5
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label10.Location = New Point(28, 11)
        Label10.Name = "Label10"
        Label10.Size = New Size(122, 19)
        Label10.TabIndex = 4
        Label10.Text = "Sales Analytics"
        ' 
        ' Panel12
        ' 
        Panel12.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Panel12.BackColor = Color.White
        Panel12.Controls.Add(ComboBoxFilter)
        Panel12.Controls.Add(TextBoxSearchBar)
        Panel12.Controls.Add(Label9)
        Panel12.Controls.Add(Panel13)
        Panel12.Location = New Point(0, 357)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(596, 323)
        Panel12.TabIndex = 7
        ' 
        ' ComboBoxFilter
        ' 
        ComboBoxFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxFilter.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxFilter.FormattingEnabled = True
        ComboBoxFilter.Location = New Point(341, 8)
        ComboBoxFilter.Name = "ComboBoxFilter"
        ComboBoxFilter.Size = New Size(97, 23)
        ComboBoxFilter.TabIndex = 5
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(453, 8)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(140, 23)
        TextBoxSearchBar.TabIndex = 4
        TextBoxSearchBar.Text = "Search"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label9.Location = New Point(0, 4)
        Label9.Name = "Label9"
        Label9.Size = New Size(197, 25)
        Label9.TabIndex = 3
        Label9.Text = "Latest  Transaction"
        ' 
        ' Panel13
        ' 
        Panel13.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel13.Controls.Add(DataGridViewLatestTransaction)
        Panel13.Location = New Point(0, 34)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(596, 289)
        Panel13.TabIndex = 0
        ' 
        ' DataGridViewLatestTransaction
        ' 
        DataGridViewLatestTransaction.AllowUserToAddRows = False
        DataGridViewLatestTransaction.AllowUserToResizeColumns = False
        DataGridViewLatestTransaction.AllowUserToResizeRows = False
        DataGridViewLatestTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewLatestTransaction.BackgroundColor = Color.White
        DataGridViewLatestTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewLatestTransaction.Dock = DockStyle.Fill
        DataGridViewLatestTransaction.Location = New Point(0, 0)
        DataGridViewLatestTransaction.Name = "DataGridViewLatestTransaction"
        DataGridViewLatestTransaction.Size = New Size(596, 289)
        DataGridViewLatestTransaction.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(ComboBoxDetailer)
        Panel2.Controls.Add(Label24)
        Panel2.Controls.Add(ComboBoxDiscount)
        Panel2.Controls.Add(Label23)
        Panel2.Controls.Add(Label22)
        Panel2.Controls.Add(TextBoxCheque)
        Panel2.Controls.Add(PanelServiceInfo)
        Panel2.Controls.Add(FullScreenServiceBtn)
        Panel2.Controls.Add(RemoveServiceBtn)
        Panel2.Controls.Add(AddServiceBtn)
        Panel2.Controls.Add(TextBoxReferenceID)
        Panel2.Controls.Add(Label17)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(TextBoxTotalPrice)
        Panel2.Controls.Add(LabelSalesID)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(AddSalesBtn)
        Panel2.Controls.Add(TextBoxPrice)
        Panel2.Controls.Add(ComboBoxPaymentMethod)
        Panel2.Controls.Add(ComboBoxAddons)
        Panel2.Controls.Add(ComboBoxServices)
        Panel2.Controls.Add(TextBoxCustomerID)
        Panel2.Controls.Add(TextBoxCustomerName)
        Panel2.Controls.Add(Label6)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(ClearBtn)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label7)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(298, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(292, 680)
        Panel2.TabIndex = 19
        ' 
        ' ComboBoxDetailer
        ' 
        ComboBoxDetailer.Font = New Font("Century Gothic", 9F)
        ComboBoxDetailer.FormattingEnabled = True
        ComboBoxDetailer.Location = New Point(17, 435)
        ComboBoxDetailer.Name = "ComboBoxDetailer"
        ComboBoxDetailer.Size = New Size(261, 25)
        ComboBoxDetailer.TabIndex = 144
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Font = New Font("Century Gothic", 9F)
        Label24.Location = New Point(16, 415)
        Label24.Name = "Label24"
        Label24.Size = New Size(56, 17)
        Label24.TabIndex = 143
        Label24.Text = "Detailer"
        ' 
        ' ComboBoxDiscount
        ' 
        ComboBoxDiscount.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxDiscount.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxDiscount.Font = New Font("Century Gothic", 9F)
        ComboBoxDiscount.FormattingEnabled = True
        ComboBoxDiscount.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25"})
        ComboBoxDiscount.Location = New Point(147, 298)
        ComboBoxDiscount.Name = "ComboBoxDiscount"
        ComboBoxDiscount.Size = New Size(130, 25)
        ComboBoxDiscount.TabIndex = 142
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Font = New Font("Century Gothic", 9F)
        Label23.Location = New Point(147, 280)
        Label23.Name = "Label23"
        Label23.Size = New Size(72, 17)
        Label23.TabIndex = 141
        Label23.Text = "Discount %"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Font = New Font("Century Gothic", 9F)
        Label22.Location = New Point(147, 326)
        Label22.Name = "Label22"
        Label22.Size = New Size(78, 17)
        Label22.TabIndex = 140
        Label22.Text = "Cheque No."
        ' 
        ' TextBoxCheque
        ' 
        TextBoxCheque.Font = New Font("Century Gothic", 9F)
        TextBoxCheque.Location = New Point(147, 344)
        TextBoxCheque.Name = "TextBoxCheque"
        TextBoxCheque.ReadOnly = True
        TextBoxCheque.Size = New Size(129, 22)
        TextBoxCheque.TabIndex = 139
        ' 
        ' PanelServiceInfo
        ' 
        PanelServiceInfo.Controls.Add(ListViewServices)
        PanelServiceInfo.Location = New Point(16, 175)
        PanelServiceInfo.Name = "PanelServiceInfo"
        PanelServiceInfo.Size = New Size(260, 102)
        PanelServiceInfo.TabIndex = 130
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
        FullScreenServiceBtn.Location = New Point(126, 141)
        FullScreenServiceBtn.Name = "FullScreenServiceBtn"
        FullScreenServiceBtn.Size = New Size(37, 33)
        FullScreenServiceBtn.TabIndex = 130
        FullScreenServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' RemoveServiceBtn
        ' 
        RemoveServiceBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveServiceBtn.FlatAppearance.BorderSize = 0
        RemoveServiceBtn.FlatStyle = FlatStyle.Flat
        RemoveServiceBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveServiceBtn.ForeColor = Color.White
        RemoveServiceBtn.Location = New Point(202, 146)
        RemoveServiceBtn.Name = "RemoveServiceBtn"
        RemoveServiceBtn.Size = New Size(75, 23)
        RemoveServiceBtn.TabIndex = 94
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
        AddServiceBtn.Location = New Point(16, 146)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(75, 23)
        AddServiceBtn.TabIndex = 93
        AddServiceBtn.Text = "Add"
        AddServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 344)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(129, 22)
        TextBoxReferenceID.TabIndex = 91
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Century Gothic", 9F)
        Label17.Location = New Point(16, 326)
        Label17.Name = "Label17"
        Label17.Size = New Size(71, 17)
        Label17.TabIndex = 90
        Label17.Text = "Gcash Ref."
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 9F)
        Label16.Location = New Point(147, 372)
        Label16.Name = "Label16"
        Label16.Size = New Size(70, 17)
        Label16.TabIndex = 89
        Label16.Text = "Total Price"
        ' 
        ' TextBoxTotalPrice
        ' 
        TextBoxTotalPrice.Font = New Font("Century Gothic", 9F)
        TextBoxTotalPrice.Location = New Point(147, 390)
        TextBoxTotalPrice.Name = "TextBoxTotalPrice"
        TextBoxTotalPrice.ReadOnly = True
        TextBoxTotalPrice.Size = New Size(129, 22)
        TextBoxTotalPrice.TabIndex = 88
        ' 
        ' LabelSalesID
        ' 
        LabelSalesID.AutoSize = True
        LabelSalesID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelSalesID.ForeColor = Color.Red
        LabelSalesID.Location = New Point(70, 463)
        LabelSalesID.Name = "LabelSalesID"
        LabelSalesID.Size = New Size(0, 15)
        LabelSalesID.TabIndex = 33
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(17, 463)
        Label1.Name = "Label1"
        Label1.Size = New Size(54, 17)
        Label1.TabIndex = 32
        Label1.Text = "Sales ID"
        ' 
        ' AddSalesBtn
        ' 
        AddSalesBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddSalesBtn.FlatAppearance.BorderSize = 0
        AddSalesBtn.FlatStyle = FlatStyle.Flat
        AddSalesBtn.Font = New Font("Century Gothic", 11.25F)
        AddSalesBtn.ForeColor = Color.White
        AddSalesBtn.Location = New Point(17, 483)
        AddSalesBtn.Name = "AddSalesBtn"
        AddSalesBtn.Size = New Size(260, 46)
        AddSalesBtn.TabIndex = 32
        AddSalesBtn.Text = "Add Sales"
        AddSalesBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddSalesBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Font = New Font("Century Gothic", 9F)
        TextBoxPrice.Location = New Point(16, 390)
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
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 298)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(129, 25)
        ComboBoxPaymentMethod.TabIndex = 30
        ' 
        ' ComboBoxAddons
        ' 
        ComboBoxAddons.Font = New Font("Century Gothic", 9F)
        ComboBoxAddons.FormattingEnabled = True
        ComboBoxAddons.Location = New Point(147, 115)
        ComboBoxAddons.Name = "ComboBoxAddons"
        ComboBoxAddons.Size = New Size(129, 25)
        ComboBoxAddons.TabIndex = 29
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.Font = New Font("Century Gothic", 9F)
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 115)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(129, 25)
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
        Label6.Location = New Point(147, 97)
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
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(16, 52)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 17)
        Label2.TabIndex = 4
        Label2.Text = "Customer ID"
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
        ClearBtn.Location = New Point(17, 535)
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
        Label4.Location = New Point(16, 280)
        Label4.Name = "Label4"
        Label4.Size = New Size(105, 17)
        Label4.TabIndex = 15
        Label4.Text = "Paymen Method"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(16, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(54, 17)
        Label3.TabIndex = 5
        Label3.Text = "Service"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 9F)
        Label7.Location = New Point(16, 372)
        Label7.Name = "Label7"
        Label7.Size = New Size(59, 17)
        Label7.TabIndex = 6
        Label7.Text = "Subtotal"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel1)
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(290, 680)
        Panel3.TabIndex = 20
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PanelVehicleInfo)
        Panel1.Controls.Add(FullScreenVehicleBtn)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(RemoveVehicleBtn)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(AddVehicleBtn)
        Panel1.Controls.Add(TextBoxBarangay)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(customerIDLabel)
        Panel1.Controls.Add(TextBoxLastName)
        Panel1.Controls.Add(ClearFieldsBtn)
        Panel1.Controls.Add(TextBoxVehicle)
        Panel1.Controls.Add(Label67)
        Panel1.Controls.Add(Label15)
        Panel1.Controls.Add(AddCustomerBtn)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(TextBoxEmail)
        Panel1.Controls.Add(TextBoxName)
        Panel1.Controls.Add(TextBoxAddress)
        Panel1.Controls.Add(Label18)
        Panel1.Controls.Add(Label21)
        Panel1.Controls.Add(Label19)
        Panel1.Controls.Add(Label20)
        Panel1.Controls.Add(TextBoxPlateNumber)
        Panel1.Controls.Add(TextBoxNumber)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(292, 680)
        Panel1.TabIndex = 2
        ' 
        ' PanelVehicleInfo
        ' 
        PanelVehicleInfo.Controls.Add(ListViewVehicles)
        PanelVehicleInfo.Location = New Point(16, 343)
        PanelVehicleInfo.Name = "PanelVehicleInfo"
        PanelVehicleInfo.Size = New Size(260, 102)
        PanelVehicleInfo.TabIndex = 129
        ' 
        ' ListViewVehicles
        ' 
        ListViewVehicles.Dock = DockStyle.Fill
        ListViewVehicles.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewVehicles.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewVehicles.FullRowSelect = True
        ListViewVehicles.GridLines = True
        ListViewVehicles.Location = New Point(0, 0)
        ListViewVehicles.Name = "ListViewVehicles"
        ListViewVehicles.Size = New Size(260, 102)
        ListViewVehicles.TabIndex = 100
        ListViewVehicles.UseCompatibleStateImageBehavior = False
        ' 
        ' FullScreenVehicleBtn
        ' 
        FullScreenVehicleBtn.FlatAppearance.BorderSize = 0
        FullScreenVehicleBtn.FlatStyle = FlatStyle.Flat
        FullScreenVehicleBtn.Image = My.Resources.Resources.expand1
        FullScreenVehicleBtn.Location = New Point(126, 309)
        FullScreenVehicleBtn.Name = "FullScreenVehicleBtn"
        FullScreenVehicleBtn.Size = New Size(37, 33)
        FullScreenVehicleBtn.TabIndex = 128
        FullScreenVehicleBtn.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label8.Location = New Point(16, 252)
        Label8.Name = "Label8"
        Label8.Size = New Size(141, 16)
        Label8.TabIndex = 127
        Label8.Text = "VEHICLE INFORMATION"
        ' 
        ' RemoveVehicleBtn
        ' 
        RemoveVehicleBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveVehicleBtn.FlatAppearance.BorderSize = 0
        RemoveVehicleBtn.FlatStyle = FlatStyle.Flat
        RemoveVehicleBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveVehicleBtn.ForeColor = Color.White
        RemoveVehicleBtn.Location = New Point(201, 314)
        RemoveVehicleBtn.Name = "RemoveVehicleBtn"
        RemoveVehicleBtn.Size = New Size(75, 23)
        RemoveVehicleBtn.TabIndex = 85
        RemoveVehicleBtn.Text = "Remove"
        RemoveVehicleBtn.UseVisualStyleBackColor = False
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label11.Location = New Point(16, 14)
        Label11.Name = "Label11"
        Label11.Size = New Size(154, 16)
        Label11.TabIndex = 126
        Label11.Text = "PERSONAL INFORMATION"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label12.Location = New Point(147, 159)
        Label12.Name = "Label12"
        Label12.Size = New Size(64, 17)
        Label12.TabIndex = 125
        Label12.Text = "Barangay"
        ' 
        ' AddVehicleBtn
        ' 
        AddVehicleBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddVehicleBtn.FlatAppearance.BorderSize = 0
        AddVehicleBtn.FlatStyle = FlatStyle.Flat
        AddVehicleBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        AddVehicleBtn.ForeColor = Color.White
        AddVehicleBtn.Location = New Point(16, 314)
        AddVehicleBtn.Name = "AddVehicleBtn"
        AddVehicleBtn.Size = New Size(75, 23)
        AddVehicleBtn.TabIndex = 84
        AddVehicleBtn.Text = "Add"
        AddVehicleBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxBarangay
        ' 
        TextBoxBarangay.Font = New Font("Century Gothic", 9F)
        TextBoxBarangay.Location = New Point(147, 177)
        TextBoxBarangay.Multiline = True
        TextBoxBarangay.Name = "TextBoxBarangay"
        TextBoxBarangay.Size = New Size(129, 22)
        TextBoxBarangay.TabIndex = 124
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label13.Location = New Point(148, 30)
        Label13.Name = "Label13"
        Label13.Size = New Size(71, 17)
        Label13.TabIndex = 122
        Label13.Text = "Last Name"
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(86, 463)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 57
        ' 
        ' TextBoxLastName
        ' 
        TextBoxLastName.Font = New Font("Century Gothic", 9F)
        TextBoxLastName.Location = New Point(148, 48)
        TextBoxLastName.Name = "TextBoxLastName"
        TextBoxLastName.Size = New Size(129, 22)
        TextBoxLastName.TabIndex = 123
        ' 
        ' ClearFieldsBtn
        ' 
        ClearFieldsBtn.Anchor = AnchorStyles.Top
        ClearFieldsBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ClearFieldsBtn.FlatAppearance.BorderSize = 0
        ClearFieldsBtn.FlatStyle = FlatStyle.Flat
        ClearFieldsBtn.Font = New Font("Century Gothic", 11.25F)
        ClearFieldsBtn.ForeColor = Color.White
        ClearFieldsBtn.Image = CType(resources.GetObject("ClearFieldsBtn.Image"), Image)
        ClearFieldsBtn.Location = New Point(17, 535)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(260, 46)
        ClearFieldsBtn.TabIndex = 45
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxVehicle
        ' 
        TextBoxVehicle.Font = New Font("Century Gothic", 9F)
        TextBoxVehicle.Location = New Point(148, 286)
        TextBoxVehicle.Name = "TextBoxVehicle"
        TextBoxVehicle.Size = New Size(129, 22)
        TextBoxVehicle.TabIndex = 120
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Century Gothic", 9F)
        Label67.Location = New Point(17, 463)
        Label67.Name = "Label67"
        Label67.Size = New Size(80, 17)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label15.Location = New Point(147, 268)
        Label15.Name = "Label15"
        Label15.Size = New Size(84, 17)
        Label15.TabIndex = 121
        Label15.Text = "Vehicle Type"
        ' 
        ' AddCustomerBtn
        ' 
        AddCustomerBtn.Anchor = AnchorStyles.Top
        AddCustomerBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddCustomerBtn.FlatAppearance.BorderSize = 0
        AddCustomerBtn.FlatStyle = FlatStyle.Flat
        AddCustomerBtn.Font = New Font("Century Gothic", 11.25F)
        AddCustomerBtn.ForeColor = Color.White
        AddCustomerBtn.Image = CType(resources.GetObject("AddCustomerBtn.Image"), Image)
        AddCustomerBtn.Location = New Point(17, 483)
        AddCustomerBtn.Name = "AddCustomerBtn"
        AddCustomerBtn.Size = New Size(260, 46)
        AddCustomerBtn.TabIndex = 42
        AddCustomerBtn.Text = "Add Customer"
        AddCustomerBtn.TextAlign = ContentAlignment.MiddleRight
        AddCustomerBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddCustomerBtn.UseVisualStyleBackColor = False
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label14.Location = New Point(16, 30)
        Label14.Name = "Label14"
        Label14.Size = New Size(70, 17)
        Label14.TabIndex = 110
        Label14.Text = "First Name"
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Font = New Font("Century Gothic", 9F)
        TextBoxEmail.Location = New Point(16, 134)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 22)
        TextBoxEmail.TabIndex = 113
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Font = New Font("Century Gothic", 9F)
        TextBoxName.Location = New Point(16, 48)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(129, 22)
        TextBoxName.TabIndex = 111
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Font = New Font("Century Gothic", 9F)
        TextBoxAddress.Location = New Point(16, 177)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(129, 22)
        TextBoxAddress.TabIndex = 114
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Century Gothic", 9F)
        Label18.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label18.Location = New Point(16, 73)
        Label18.Name = "Label18"
        Label18.Size = New Size(72, 17)
        Label18.TabIndex = 116
        Label18.Text = "Mobile No."
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Font = New Font("Century Gothic", 9F)
        Label21.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label21.Location = New Point(16, 159)
        Label21.Name = "Label21"
        Label21.Size = New Size(31, 17)
        Label21.TabIndex = 118
        Label21.Text = "City"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Font = New Font("Century Gothic", 9F)
        Label19.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label19.Location = New Point(16, 268)
        Label19.Name = "Label19"
        Label19.Size = New Size(89, 17)
        Label19.TabIndex = 119
        Label19.Text = "Plate Number"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Font = New Font("Century Gothic", 9F)
        Label20.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label20.Location = New Point(16, 116)
        Label20.Name = "Label20"
        Label20.Size = New Size(39, 17)
        Label20.TabIndex = 117
        Label20.Text = "Email"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Font = New Font("Century Gothic", 9F)
        TextBoxPlateNumber.Location = New Point(16, 286)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(129, 22)
        TextBoxPlateNumber.TabIndex = 115
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Font = New Font("Century Gothic", 9F)
        TextBoxNumber.Location = New Point(16, 91)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 22)
        TextBoxNumber.TabIndex = 112
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Panel4.Controls.Add(Panel2)
        Panel4.Controls.Add(Panel3)
        Panel4.Location = New Point(602, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(590, 680)
        Panel4.TabIndex = 7
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(1192, 680)
        Controls.Add(Panel4)
        Controls.Add(Panel9)
        FormBorderStyle = FormBorderStyle.None
        Name = "Dashboard"
        Text = "Dashboard"
        Panel9.ResumeLayout(False)
        PanelMontlySales1.ResumeLayout(False)
        PanelMontlySales1.PerformLayout()
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel13.ResumeLayout(False)
        CType(DataGridViewLatestTransaction, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        PanelServiceInfo.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PanelVehicleInfo.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PanelMontlySales1 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents DataGridViewLatestTransaction As DataGridView
    Friend WithEvents TextBoxSearchBar As TextBox
    Friend WithEvents ButtonToggleChart As Button
    Friend WithEvents PanelMontlySales As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelSalesID As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents AddSalesBtn As Button
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddons As ComboBox
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ClearBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents ClearFieldsBtn As Button
    Friend WithEvents Label67 As Label
    Friend WithEvents AddCustomerBtn As Button
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents ComboBoxFilter As ComboBox
    Friend WithEvents RemoveVehicleBtn As Button
    Friend WithEvents AddVehicleBtn As Button
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxBarangay As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxLastName As TextBox
    Friend WithEvents TextBoxVehicle As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents FullScreenVehicleBtn As Button
    Friend WithEvents PanelVehicleInfo As Panel
    Friend WithEvents ListViewVehicles As ListView
    Friend WithEvents FullScreenServiceBtn As Button
    Friend WithEvents PanelServiceInfo As Panel
    Friend WithEvents ListViewServices As ListView
    Friend WithEvents Label22 As Label
    Friend WithEvents TextBoxCheque As TextBox
    Friend WithEvents ComboBoxDiscount As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ComboBoxDetailer As ComboBox
    Friend WithEvents Label24 As Label
End Class
