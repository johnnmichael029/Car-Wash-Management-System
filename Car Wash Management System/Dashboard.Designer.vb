﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        RemoveServiceBtn = New Button()
        AddServiceBtn = New Button()
        ListViewServices = New ListView()
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
        RemoveVehicleBtn = New Button()
        AddVehicleBtn = New Button()
        ListViewVehicles = New ListView()
        TextBoxVehicle = New TextBox()
        Label15 = New Label()
        customerIDLabel = New Label()
        Label8 = New Label()
        Label11 = New Label()
        TextBoxPlateNumber = New TextBox()
        ClearFieldsBtn = New Button()
        Label12 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        Label67 = New Label()
        Label13 = New Label()
        TextBoxNumber = New TextBox()
        AddCustomerBtn = New Button()
        Label14 = New Label()
        TextBoxName = New TextBox()
        Panel4 = New Panel()
        PrintDocumentBill = New Printing.PrintDocument()
        Panel9.SuspendLayout()
        PanelMontlySales1.SuspendLayout()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        CType(DataGridViewLatestTransaction, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
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
        Panel2.Controls.Add(RemoveServiceBtn)
        Panel2.Controls.Add(AddServiceBtn)
        Panel2.Controls.Add(ListViewServices)
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
        ' ListViewServices
        ' 
        ListViewServices.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewServices.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewServices.FullRowSelect = True
        ListViewServices.GridLines = True
        ListViewServices.Location = New Point(16, 175)
        ListViewServices.Name = "ListViewServices"
        ListViewServices.Size = New Size(260, 102)
        ListViewServices.TabIndex = 92
        ListViewServices.UseCompatibleStateImageBehavior = False
        ' 
        ' TextBoxReferenceID
        ' 
        TextBoxReferenceID.Font = New Font("Century Gothic", 9F)
        TextBoxReferenceID.Location = New Point(16, 344)
        TextBoxReferenceID.Name = "TextBoxReferenceID"
        TextBoxReferenceID.ReadOnly = True
        TextBoxReferenceID.Size = New Size(261, 22)
        TextBoxReferenceID.TabIndex = 91
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Century Gothic", 9F)
        Label17.Location = New Point(16, 326)
        Label17.Name = "Label17"
        Label17.Size = New Size(85, 17)
        Label17.TabIndex = 90
        Label17.Text = "Reference ID"
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
        LabelSalesID.Location = New Point(69, 449)
        LabelSalesID.Name = "LabelSalesID"
        LabelSalesID.Size = New Size(0, 15)
        LabelSalesID.TabIndex = 33
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(16, 449)
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
        AddSalesBtn.Location = New Point(16, 469)
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
        ComboBoxPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxPaymentMethod.Font = New Font("Century Gothic", 9F)
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 298)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(261, 25)
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
        ClearBtn.Location = New Point(16, 521)
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
        Panel1.Controls.Add(RemoveVehicleBtn)
        Panel1.Controls.Add(AddVehicleBtn)
        Panel1.Controls.Add(ListViewVehicles)
        Panel1.Controls.Add(TextBoxVehicle)
        Panel1.Controls.Add(Label15)
        Panel1.Controls.Add(customerIDLabel)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(TextBoxPlateNumber)
        Panel1.Controls.Add(ClearFieldsBtn)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(TextBoxAddress)
        Panel1.Controls.Add(TextBoxEmail)
        Panel1.Controls.Add(Label67)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(TextBoxNumber)
        Panel1.Controls.Add(AddCustomerBtn)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(TextBoxName)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(292, 680)
        Panel1.TabIndex = 2
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
        ' ListViewVehicles
        ' 
        ListViewVehicles.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewVehicles.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewVehicles.FullRowSelect = True
        ListViewVehicles.GridLines = True
        ListViewVehicles.Location = New Point(16, 343)
        ListViewVehicles.Name = "ListViewVehicles"
        ListViewVehicles.Size = New Size(260, 102)
        ListViewVehicles.TabIndex = 83
        ListViewVehicles.UseCompatibleStateImageBehavior = False
        ' 
        ' TextBoxVehicle
        ' 
        TextBoxVehicle.Font = New Font("Century Gothic", 9F)
        TextBoxVehicle.Location = New Point(148, 285)
        TextBoxVehicle.Name = "TextBoxVehicle"
        TextBoxVehicle.Size = New Size(129, 22)
        TextBoxVehicle.TabIndex = 58
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.Location = New Point(147, 267)
        Label15.Name = "Label15"
        Label15.Size = New Size(84, 17)
        Label15.TabIndex = 59
        Label15.Text = "Vehicle Type"
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(85, 449)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 57
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(16, 9)
        Label8.Name = "Label8"
        Label8.Size = New Size(44, 17)
        Label8.TabIndex = 46
        Label8.Text = "Name"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(16, 53)
        Label11.Name = "Label11"
        Label11.Size = New Size(95, 17)
        Label11.TabIndex = 52
        Label11.Text = "Phone Number"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Font = New Font("Century Gothic", 9F)
        TextBoxPlateNumber.Location = New Point(16, 285)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(129, 22)
        TextBoxPlateNumber.TabIndex = 51
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
        ClearFieldsBtn.Location = New Point(16, 521)
        ClearFieldsBtn.Name = "ClearFieldsBtn"
        ClearFieldsBtn.Size = New Size(260, 46)
        ClearFieldsBtn.TabIndex = 45
        ClearFieldsBtn.Text = "Clear Fields"
        ClearFieldsBtn.TextAlign = ContentAlignment.MiddleRight
        ClearFieldsBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearFieldsBtn.UseVisualStyleBackColor = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.Location = New Point(16, 97)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 17)
        Label12.TabIndex = 53
        Label12.Text = "Email"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Font = New Font("Century Gothic", 9F)
        TextBoxAddress.Location = New Point(16, 171)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 50
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Font = New Font("Century Gothic", 9F)
        TextBoxEmail.Location = New Point(16, 115)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 22)
        TextBoxEmail.TabIndex = 49
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Century Gothic", 9F)
        Label67.Location = New Point(16, 449)
        Label67.Name = "Label67"
        Label67.Size = New Size(80, 17)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.Location = New Point(16, 153)
        Label13.Name = "Label13"
        Label13.Size = New Size(55, 17)
        Label13.TabIndex = 54
        Label13.Text = "Address"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Font = New Font("Century Gothic", 9F)
        TextBoxNumber.Location = New Point(16, 71)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 22)
        TextBoxNumber.TabIndex = 48
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
        AddCustomerBtn.Location = New Point(16, 469)
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
        Label14.Location = New Point(16, 267)
        Label14.Name = "Label14"
        Label14.Size = New Size(89, 17)
        Label14.TabIndex = 55
        Label14.Text = "Plate Number"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Font = New Font("Century Gothic", 9F)
        TextBoxName.Location = New Point(16, 27)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 22)
        TextBoxName.TabIndex = 47
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
        Panel3.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents ClearFieldsBtn As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents AddCustomerBtn As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents PrintDocumentBill As Printing.PrintDocument
    Friend WithEvents ComboBoxFilter As ComboBox
    Friend WithEvents TextBoxVehicle As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents RemoveVehicleBtn As Button
    Friend WithEvents AddVehicleBtn As Button
    Friend WithEvents ListViewVehicles As ListView
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBoxTotalPrice As TextBox
    Friend WithEvents TextBoxReferenceID As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents RemoveServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents ListViewServices As ListView
End Class
