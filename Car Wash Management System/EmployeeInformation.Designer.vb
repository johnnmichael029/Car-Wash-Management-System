<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeInformation
    Inherits BaseForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeInformation))
        Panel1 = New Panel()
        Panel14 = New Panel()
        TextBoxSearchBar = New TextBox()
        Panel2 = New Panel()
        TextBoxAge = New TextBox()
        ComboBoxGender = New ComboBox()
        Label4 = New Label()
        ComboBoxPosition = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        TextBoxBarangay = New TextBox()
        Label1 = New Label()
        TextBoxLastName = New TextBox()
        LabelEmployeeID = New Label()
        UpdateBtn = New Button()
        ViewBtn = New Button()
        Label67 = New Label()
        Label15 = New Label()
        AddBtn = New Button()
        Label8 = New Label()
        TextBoxName = New TextBox()
        Label11 = New Label()
        Label14 = New Label()
        TextBoxPhoneNumber = New TextBox()
        Label12 = New Label()
        Label13 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        DataGridViewEmployee = New DataGridView()
        Panel1.SuspendLayout()
        Panel14.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridViewEmployee, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel14)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(DataGridViewEmployee)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 758)
        Panel1.TabIndex = 1
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.White
        Panel14.Controls.Add(TextBoxSearchBar)
        Panel14.Dock = DockStyle.Top
        Panel14.Location = New Point(0, 0)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(606, 32)
        Panel14.TabIndex = 1
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(463, 6)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(140, 23)
        TextBoxSearchBar.TabIndex = 5
        TextBoxSearchBar.Text = "Search"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(TextBoxAge)
        Panel2.Controls.Add(ComboBoxGender)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(ComboBoxPosition)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(TextBoxBarangay)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(TextBoxLastName)
        Panel2.Controls.Add(LabelEmployeeID)
        Panel2.Controls.Add(UpdateBtn)
        Panel2.Controls.Add(ViewBtn)
        Panel2.Controls.Add(Label67)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(AddBtn)
        Panel2.Controls.Add(Label8)
        Panel2.Controls.Add(TextBoxName)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label14)
        Panel2.Controls.Add(TextBoxPhoneNumber)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(TextBoxAddress)
        Panel2.Controls.Add(TextBoxEmail)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(606, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(305, 758)
        Panel2.TabIndex = 1
        ' 
        ' TextBoxAge
        ' 
        TextBoxAge.Font = New Font("Century Gothic", 9F)
        TextBoxAge.Location = New Point(147, 86)
        TextBoxAge.Multiline = True
        TextBoxAge.Name = "TextBoxAge"
        TextBoxAge.Size = New Size(129, 22)
        TextBoxAge.TabIndex = 113
        ' 
        ' ComboBoxGender
        ' 
        ComboBoxGender.AutoCompleteCustomSource.AddRange(New String() {"Male", "Female", "LGBT"})
        ComboBoxGender.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxGender.Font = New Font("Century Gothic", 9F)
        ComboBoxGender.FormattingEnabled = True
        ComboBoxGender.Items.AddRange(New Object() {"Male", "Female", "LGBT"})
        ComboBoxGender.Location = New Point(16, 217)
        ComboBoxGender.Name = "ComboBoxGender"
        ComboBoxGender.Size = New Size(129, 25)
        ComboBoxGender.TabIndex = 112
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label4.Location = New Point(148, 68)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 17)
        Label4.TabIndex = 111
        Label4.Text = "Age"
        ' 
        ' ComboBoxPosition
        ' 
        ComboBoxPosition.AutoCompleteCustomSource.AddRange(New String() {"Detailer", "Cashier", "Manager"})
        ComboBoxPosition.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxPosition.Font = New Font("Century Gothic", 9F)
        ComboBoxPosition.FormattingEnabled = True
        ComboBoxPosition.Items.AddRange(New Object() {"Detailer", "Cashier", "Manager"})
        ComboBoxPosition.Location = New Point(148, 217)
        ComboBoxPosition.Name = "ComboBoxPosition"
        ComboBoxPosition.Size = New Size(129, 25)
        ComboBoxPosition.TabIndex = 110
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label3.Location = New Point(16, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(154, 16)
        Label3.TabIndex = 107
        Label3.Text = "PERSONAL INFORMATION"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label2.Location = New Point(147, 154)
        Label2.Name = "Label2"
        Label2.Size = New Size(64, 17)
        Label2.TabIndex = 106
        Label2.Text = "Barangay"
        ' 
        ' TextBoxBarangay
        ' 
        TextBoxBarangay.Font = New Font("Century Gothic", 9F)
        TextBoxBarangay.Location = New Point(147, 172)
        TextBoxBarangay.Multiline = True
        TextBoxBarangay.Name = "TextBoxBarangay"
        TextBoxBarangay.Size = New Size(129, 22)
        TextBoxBarangay.TabIndex = 105
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label1.Location = New Point(148, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(71, 17)
        Label1.TabIndex = 103
        Label1.Text = "Last Name"
        ' 
        ' TextBoxLastName
        ' 
        TextBoxLastName.Font = New Font("Century Gothic", 9F)
        TextBoxLastName.Location = New Point(148, 43)
        TextBoxLastName.Name = "TextBoxLastName"
        TextBoxLastName.Size = New Size(129, 22)
        TextBoxLastName.TabIndex = 104
        ' 
        ' LabelEmployeeID
        ' 
        LabelEmployeeID.AutoSize = True
        LabelEmployeeID.Font = New Font("Century Gothic", 9F, FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        LabelEmployeeID.ForeColor = Color.Red
        LabelEmployeeID.Location = New Point(91, 270)
        LabelEmployeeID.Name = "LabelEmployeeID"
        LabelEmployeeID.Size = New Size(0, 17)
        LabelEmployeeID.TabIndex = 57
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(16, 342)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(260, 46)
        UpdateBtn.TabIndex = 43
        UpdateBtn.Text = "Update"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
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
        ViewBtn.Location = New Point(16, 394)
        ViewBtn.Name = "ViewBtn"
        ViewBtn.Size = New Size(260, 46)
        ViewBtn.TabIndex = 45
        ViewBtn.Text = "Clear Fields"
        ViewBtn.TextAlign = ContentAlignment.MiddleRight
        ViewBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        ViewBtn.UseVisualStyleBackColor = False
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label67.Location = New Point(16, 270)
        Label67.Name = "Label67"
        Label67.Size = New Size(81, 17)
        Label67.TabIndex = 56
        Label67.Text = "Employee ID"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label15.Location = New Point(16, 197)
        Label15.Name = "Label15"
        Label15.Size = New Size(53, 17)
        Label15.TabIndex = 99
        Label15.Text = "Gender"
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
        AddBtn.Location = New Point(16, 290)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(260, 46)
        AddBtn.TabIndex = 42
        AddBtn.Text = "Add Employee"
        AddBtn.TextAlign = ContentAlignment.MiddleRight
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label8.Location = New Point(16, 25)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 17)
        Label8.TabIndex = 86
        Label8.Text = "First Name"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Font = New Font("Century Gothic", 9F)
        TextBoxName.Location = New Point(16, 43)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(129, 22)
        TextBoxName.TabIndex = 87
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label11.Location = New Point(16, 68)
        Label11.Name = "Label11"
        Label11.Size = New Size(72, 17)
        Label11.TabIndex = 92
        Label11.Text = "Mobile No."
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label14.Location = New Point(148, 197)
        Label14.Name = "Label14"
        Label14.Size = New Size(54, 17)
        Label14.TabIndex = 95
        Label14.Text = "Position"
        ' 
        ' TextBoxPhoneNumber
        ' 
        TextBoxPhoneNumber.Font = New Font("Century Gothic", 9F)
        TextBoxPhoneNumber.Location = New Point(16, 86)
        TextBoxPhoneNumber.Name = "TextBoxPhoneNumber"
        TextBoxPhoneNumber.Size = New Size(129, 22)
        TextBoxPhoneNumber.TabIndex = 88
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label12.Location = New Point(16, 111)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 17)
        Label12.TabIndex = 93
        Label12.Text = "Email"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label13.Location = New Point(16, 154)
        Label13.Name = "Label13"
        Label13.Size = New Size(31, 17)
        Label13.TabIndex = 94
        Label13.Text = "City"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Font = New Font("Century Gothic", 9F)
        TextBoxAddress.Location = New Point(16, 172)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(129, 22)
        TextBoxAddress.TabIndex = 90
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Font = New Font("Century Gothic", 9F)
        TextBoxEmail.Location = New Point(16, 129)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 22)
        TextBoxEmail.TabIndex = 89
        ' 
        ' DataGridViewEmployee
        ' 
        DataGridViewEmployee.AllowUserToAddRows = False
        DataGridViewEmployee.AllowUserToResizeColumns = False
        DataGridViewEmployee.AllowUserToResizeRows = False
        DataGridViewEmployee.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewEmployee.BackgroundColor = Color.White
        DataGridViewEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewEmployee.Location = New Point(0, 35)
        DataGridViewEmployee.Name = "DataGridViewEmployee"
        DataGridViewEmployee.ReadOnly = True
        DataGridViewEmployee.Size = New Size(606, 723)
        DataGridViewEmployee.TabIndex = 0
        ' 
        ' EmployeeInformation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 758)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "EmployeeInformation"
        Text = "EmployeeInformation"
        Panel1.ResumeLayout(False)
        Panel14.ResumeLayout(False)
        Panel14.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridViewEmployee, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents TextBoxSearchBar As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxBarangay As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxLastName As TextBox
    Friend WithEvents LabelEmployeeID As Label
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents ViewBtn As Button
    Friend WithEvents Label67 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents AddBtn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxPhoneNumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents DataGridViewEmployee As DataGridView
    Friend WithEvents ComboBoxPosition As ComboBox
    Friend WithEvents ComboBoxGender As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxAge As TextBox
End Class
