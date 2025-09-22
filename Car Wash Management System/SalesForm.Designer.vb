<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesForm))
        DataGridViewSales = New DataGridView()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel1 = New Panel()
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
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridViewSales
        ' 
        DataGridViewSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewSales.BackgroundColor = SystemColors.ControlLight
        DataGridViewSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewSales.Dock = DockStyle.Fill
        DataGridViewSales.Location = New Point(0, 0)
        DataGridViewSales.Name = "DataGridViewSales"
        DataGridViewSales.ReadOnly = True
        DataGridViewSales.Size = New Size(606, 551)
        DataGridViewSales.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel3)
        Panel2.Controls.Add(Panel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(911, 551)
        Panel2.TabIndex = 20
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(DataGridViewSales)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(606, 551)
        Panel3.TabIndex = 19
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
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
        Panel1.Size = New Size(305, 551)
        Panel1.TabIndex = 18
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
        ' PrintBillBtn
        ' 
        PrintBillBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PrintBillBtn.Location = New Point(17, 447)
        PrintBillBtn.Name = "PrintBillBtn"
        PrintBillBtn.Size = New Size(75, 23)
        PrintBillBtn.TabIndex = 33
        PrintBillBtn.Text = "Prin Bill"
        PrintBillBtn.UseVisualStyleBackColor = True
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(17, 347)
        Label9.Name = "Label9"
        Label9.Size = New Size(54, 17)
        Label9.TabIndex = 32
        Label9.Text = "Sales ID"
        ' 
        ' AddBtn
        ' 
        AddBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        AddBtn.Image = My.Resources.Resources.add
        AddBtn.Location = New Point(16, 367)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(258, 34)
        AddBtn.TabIndex = 32
        AddBtn.Text = "Add"
        AddBtn.TextAlign = ContentAlignment.MiddleRight
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = True
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 64)
        Label1.Name = "Label1"
        Label1.Size = New Size(73, 15)
        Label1.TabIndex = 4
        Label1.Text = "Customer ID"
        ' 
        ' ClearBtn
        ' 
        ClearBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ClearBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        ClearBtn.Image = CType(resources.GetObject("ClearBtn.Image"), Image)
        ClearBtn.Location = New Point(16, 407)
        ClearBtn.Name = "ClearBtn"
        ClearBtn.Size = New Size(261, 34)
        ClearBtn.TabIndex = 14
        ClearBtn.Text = "Clear Fields"
        ClearBtn.TextAlign = ContentAlignment.MiddleRight
        ClearBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ClearBtn.UseVisualStyleBackColor = True
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
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 120)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 15)
        Label2.TabIndex = 5
        Label2.Text = "Service"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 289)
        Label3.Name = "Label3"
        Label3.Size = New Size(33, 15)
        Label3.TabIndex = 6
        Label3.Text = "Price"
        ' 
        ' PrintDocumentBill
        ' 
        ' 
        ' SalesForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "SalesForm"
        Text = "SalesHistory"
        CType(DataGridViewSales, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
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
End Class
