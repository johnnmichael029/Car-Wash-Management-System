<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        TextBoxSearchBar = New TextBox()
        Label9 = New Label()
        Panel13 = New Panel()
        DataGridViewLatestTransaction = New DataGridView()
        Panel2 = New Panel()
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
        ButtonToggleChart.Text = "Monthly Sales"
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
        Panel12.Controls.Add(TextBoxSearchBar)
        Panel12.Controls.Add(Label9)
        Panel12.Controls.Add(Panel13)
        Panel12.Location = New Point(0, 357)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(596, 323)
        Panel12.TabIndex = 7
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
        ' LabelSalesID
        ' 
        LabelSalesID.AutoSize = True
        LabelSalesID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelSalesID.ForeColor = Color.Red
        LabelSalesID.Location = New Point(69, 347)
        LabelSalesID.Name = "LabelSalesID"
        LabelSalesID.Size = New Size(0, 15)
        LabelSalesID.TabIndex = 33
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(17, 347)
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
        AddSalesBtn.Location = New Point(16, 367)
        AddSalesBtn.Name = "AddSalesBtn"
        AddSalesBtn.Size = New Size(260, 46)
        AddSalesBtn.TabIndex = 32
        AddSalesBtn.Text = "Add Sales"
        AddSalesBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddSalesBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(17, 307)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 31
        ' 
        ' ComboBoxPaymentMethod
        ' 
        ComboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(New String() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 254)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(261, 23)
        ComboBoxPaymentMethod.TabIndex = 30
        ' 
        ' ComboBoxAddons
        ' 
        ComboBoxAddons.FormattingEnabled = True
        ComboBoxAddons.Location = New Point(16, 197)
        ComboBoxAddons.Name = "ComboBoxAddons"
        ComboBoxAddons.Size = New Size(261, 23)
        ComboBoxAddons.TabIndex = 29
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 138)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(261, 23)
        ComboBoxServices.TabIndex = 28
        ' 
        ' TextBoxCustomerID
        ' 
        TextBoxCustomerID.Location = New Point(16, 82)
        TextBoxCustomerID.Name = "TextBoxCustomerID"
        TextBoxCustomerID.ReadOnly = True
        TextBoxCustomerID.Size = New Size(261, 23)
        TextBoxCustomerID.TabIndex = 27
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Location = New Point(16, 27)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(261, 23)
        TextBoxCustomerName.TabIndex = 26
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(16, 179)
        Label6.Name = "Label6"
        Label6.Size = New Size(48, 15)
        Label6.TabIndex = 23
        Label6.Text = "Addons"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(16, 9)
        Label5.Name = "Label5"
        Label5.Size = New Size(94, 15)
        Label5.TabIndex = 18
        Label5.Text = "Customer Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 15)
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
        ClearBtn.Location = New Point(16, 419)
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
        Label4.Location = New Point(16, 236)
        Label4.Name = "Label4"
        Label4.Size = New Size(95, 15)
        Label4.TabIndex = 15
        Label4.Text = "Paymen Method"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 120)
        Label3.Name = "Label3"
        Label3.Size = New Size(44, 15)
        Label3.TabIndex = 5
        Label3.Text = "Service"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(16, 289)
        Label7.Name = "Label7"
        Label7.Size = New Size(33, 15)
        Label7.TabIndex = 6
        Label7.Text = "Price"
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
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(89, 314)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 57
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(16, 9)
        Label8.Name = "Label8"
        Label8.Size = New Size(39, 15)
        Label8.TabIndex = 46
        Label8.Text = "Name"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(16, 53)
        Label11.Name = "Label11"
        Label11.Size = New Size(88, 15)
        Label11.TabIndex = 52
        Label11.Text = "Phone Number"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(16, 285)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
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
        ClearFieldsBtn.Location = New Point(15, 419)
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
        Label12.Location = New Point(16, 97)
        Label12.Name = "Label12"
        Label12.Size = New Size(36, 15)
        Label12.TabIndex = 53
        Label12.Text = "Email"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Location = New Point(16, 171)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 50
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(16, 115)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 23)
        TextBoxEmail.TabIndex = 49
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Segoe UI", 9F)
        Label67.Location = New Point(15, 347)
        Label67.Name = "Label67"
        Label67.Size = New Size(73, 15)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(16, 153)
        Label13.Name = "Label13"
        Label13.Size = New Size(49, 15)
        Label13.TabIndex = 54
        Label13.Text = "Address"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(16, 71)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
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
        AddCustomerBtn.Location = New Point(16, 367)
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
        Label14.Location = New Point(16, 267)
        Label14.Name = "Label14"
        Label14.Size = New Size(80, 15)
        Label14.TabIndex = 55
        Label14.Text = "Plate Number"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(16, 27)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
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
End Class
