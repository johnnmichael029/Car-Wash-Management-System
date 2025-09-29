<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerInformation))
        Panel1 = New Panel()
        Panel2 = New Panel()
        customerIDLabel = New Label()
        Label1 = New Label()
        UpdateBtn = New Button()
        Label2 = New Label()
        DeleteBtn = New Button()
        TextBoxPlateNumber = New TextBox()
        ViewBtn = New Button()
        Label3 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        Label67 = New Label()
        Label4 = New Label()
        TextBoxNumber = New TextBox()
        AddBtn = New Button()
        Label5 = New Label()
        TextBoxName = New TextBox()
        DataGridViewCustomerInformation = New DataGridView()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridViewCustomerInformation, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(DataGridViewCustomerInformation)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(customerIDLabel)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(UpdateBtn)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(DeleteBtn)
        Panel2.Controls.Add(TextBoxPlateNumber)
        Panel2.Controls.Add(ViewBtn)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(TextBoxAddress)
        Panel2.Controls.Add(TextBoxEmail)
        Panel2.Controls.Add(Label67)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(TextBoxNumber)
        Panel2.Controls.Add(AddBtn)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(TextBoxName)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(606, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(305, 758)
        Panel2.TabIndex = 1
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 46
        Label1.Text = "Name"
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(16, 436)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(260, 46)
        UpdateBtn.TabIndex = 43
        UpdateBtn.Text = "Update Customer"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 15)
        Label2.TabIndex = 52
        Label2.Text = "Phone Number"
        ' 
        ' DeleteBtn
        ' 
        DeleteBtn.Anchor = AnchorStyles.Top
        DeleteBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        DeleteBtn.FlatAppearance.BorderSize = 0
        DeleteBtn.FlatStyle = FlatStyle.Flat
        DeleteBtn.Font = New Font("Century Gothic", 11.25F)
        DeleteBtn.ForeColor = Color.White
        DeleteBtn.Location = New Point(16, 488)
        DeleteBtn.Name = "DeleteBtn"
        DeleteBtn.Size = New Size(260, 46)
        DeleteBtn.TabIndex = 44
        DeleteBtn.Text = "Delete Customer"
        DeleteBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        DeleteBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(16, 285)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
        TextBoxPlateNumber.TabIndex = 51
        ' 
        ' ViewBtn
        ' 
        ViewBtn.Anchor = AnchorStyles.Top
        ViewBtn.BackColor = Color.FromArgb(CByte(223), CByte(100), CByte(84))
        ViewBtn.FlatAppearance.BorderSize = 0
        ViewBtn.FlatStyle = FlatStyle.Flat
        ViewBtn.Font = New Font("Century Gothic", 11.25F)
        ViewBtn.ForeColor = Color.White
        ViewBtn.Image = CType(resources.GetObject("ViewBtn.Image"), Image)
        ViewBtn.Location = New Point(16, 384)
        ViewBtn.Name = "ViewBtn"
        ViewBtn.Size = New Size(260, 46)
        ViewBtn.TabIndex = 45
        ViewBtn.Text = "Clear Fields"
        ViewBtn.TextAlign = ContentAlignment.MiddleRight
        ViewBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ViewBtn.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 53
        Label3.Text = "Email"
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
        Label67.Location = New Point(16, 314)
        Label67.Name = "Label67"
        Label67.Size = New Size(73, 15)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 153)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 54
        Label4.Text = "Address"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(16, 71)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
        TextBoxNumber.TabIndex = 48
        ' 
        ' AddBtn
        ' 
        AddBtn.Anchor = AnchorStyles.Top
        AddBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddBtn.FlatAppearance.BorderSize = 0
        AddBtn.FlatStyle = FlatStyle.Flat
        AddBtn.Font = New Font("Century Gothic", 11.25F)
        AddBtn.ForeColor = Color.White
        AddBtn.Image = CType(resources.GetObject("AddBtn.Image"), Image)
        AddBtn.Location = New Point(16, 332)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(260, 46)
        AddBtn.TabIndex = 42
        AddBtn.Text = "Add Customer"
        AddBtn.TextAlign = ContentAlignment.MiddleRight
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(16, 267)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 15)
        Label5.TabIndex = 55
        Label5.Text = "Plate Number"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(16, 27)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
        TextBoxName.TabIndex = 47
        ' 
        ' DataGridViewCustomerInformation
        ' 
        DataGridViewCustomerInformation.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewCustomerInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCustomerInformation.BackgroundColor = SystemColors.ControlLight
        DataGridViewCustomerInformation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCustomerInformation.Location = New Point(0, 0)
        DataGridViewCustomerInformation.Name = "DataGridViewCustomerInformation"
        DataGridViewCustomerInformation.ReadOnly = True
        DataGridViewCustomerInformation.Size = New Size(606, 758)
        DataGridViewCustomerInformation.TabIndex = 0
        ' 
        ' CustomerInformation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 758)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CustomerInformation"
        Text = "CustomerInformation"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridViewCustomerInformation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewCustomerInformation As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents ViewBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents AddBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxName As TextBox
End Class
