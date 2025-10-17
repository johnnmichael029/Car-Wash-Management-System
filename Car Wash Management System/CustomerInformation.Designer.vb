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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerInformation))
        Panel1 = New Panel()
        Panel2 = New Panel()
        RemoveVehicleBtn = New Button()
        AddVehicleBtn = New Button()
        ListViewVehicles = New ListView()
        Panel15 = New Panel()
        Panel13 = New Panel()
        Label5 = New Label()
        TextBoxVehicle = New TextBox()
        Panel9 = New Panel()
        Panel8 = New Panel()
        TextBoxPlateNumber = New TextBox()
        Label3 = New Label()
        Panel6 = New Panel()
        Panel17 = New Panel()
        Label4 = New Label()
        Panel7 = New Panel()
        TextBoxAddress = New TextBox()
        Panel12 = New Panel()
        Panel3 = New Panel()
        Label2 = New Label()
        TextBoxEmail = New TextBox()
        Panel11 = New Panel()
        LabelHolderPhone = New Label()
        Panel5 = New Panel()
        TextBoxNumber = New TextBox()
        Panel10 = New Panel()
        LabelHolderName = New Label()
        Panel4 = New Panel()
        TextBoxName = New TextBox()
        customerIDLabel = New Label()
        UpdateBtn = New Button()
        ViewBtn = New Button()
        Label67 = New Label()
        AddBtn = New Button()
        DataGridViewCustomerInformation = New DataGridView()
        SqlConnection1 = New Microsoft.Data.SqlClient.SqlConnection()
        NameTimer = New Timer(components)
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel15.SuspendLayout()
        Panel13.SuspendLayout()
        Panel8.SuspendLayout()
        Panel17.SuspendLayout()
        Panel12.SuspendLayout()
        Panel11.SuspendLayout()
        Panel10.SuspendLayout()
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
        Panel2.Controls.Add(RemoveVehicleBtn)
        Panel2.Controls.Add(AddVehicleBtn)
        Panel2.Controls.Add(ListViewVehicles)
        Panel2.Controls.Add(Panel15)
        Panel2.Controls.Add(Panel17)
        Panel2.Controls.Add(Panel12)
        Panel2.Controls.Add(Panel11)
        Panel2.Controls.Add(Panel10)
        Panel2.Controls.Add(customerIDLabel)
        Panel2.Controls.Add(UpdateBtn)
        Panel2.Controls.Add(ViewBtn)
        Panel2.Controls.Add(Label67)
        Panel2.Controls.Add(AddBtn)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(606, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(305, 758)
        Panel2.TabIndex = 1
        ' 
        ' RemoveVehicleBtn
        ' 
        RemoveVehicleBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveVehicleBtn.FlatAppearance.BorderSize = 0
        RemoveVehicleBtn.FlatStyle = FlatStyle.Flat
        RemoveVehicleBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveVehicleBtn.ForeColor = Color.White
        RemoveVehicleBtn.Location = New Point(201, 371)
        RemoveVehicleBtn.Name = "RemoveVehicleBtn"
        RemoveVehicleBtn.Size = New Size(75, 23)
        RemoveVehicleBtn.TabIndex = 82
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
        AddVehicleBtn.Location = New Point(16, 371)
        AddVehicleBtn.Name = "AddVehicleBtn"
        AddVehicleBtn.Size = New Size(75, 23)
        AddVehicleBtn.TabIndex = 81
        AddVehicleBtn.Text = "Add"
        AddVehicleBtn.UseVisualStyleBackColor = False
        ' 
        ' ListViewVehicles
        ' 
        ListViewVehicles.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewVehicles.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewVehicles.FullRowSelect = True
        ListViewVehicles.GridLines = True
        ListViewVehicles.Location = New Point(16, 400)
        ListViewVehicles.Name = "ListViewVehicles"
        ListViewVehicles.Size = New Size(260, 102)
        ListViewVehicles.TabIndex = 80
        ListViewVehicles.UseCompatibleStateImageBehavior = False
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(Panel13)
        Panel15.Controls.Add(Panel8)
        Panel15.Location = New Point(16, 306)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(261, 59)
        Panel15.TabIndex = 79
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(Label5)
        Panel13.Controls.Add(TextBoxVehicle)
        Panel13.Controls.Add(Panel9)
        Panel13.Dock = DockStyle.Right
        Panel13.Location = New Point(136, 0)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(125, 59)
        Panel13.TabIndex = 82
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Dock = DockStyle.Top
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label5.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        Label5.Location = New Point(0, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(101, 21)
        Label5.TabIndex = 67
        Label5.Text = "Vehicle Type"
        ' 
        ' TextBoxVehicle
        ' 
        TextBoxVehicle.BorderStyle = BorderStyle.None
        TextBoxVehicle.Font = New Font("Century Gothic", 11.25F)
        TextBoxVehicle.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxVehicle.Location = New Point(0, 24)
        TextBoxVehicle.Multiline = True
        TextBoxVehicle.Name = "TextBoxVehicle"
        TextBoxVehicle.Size = New Size(125, 31)
        TextBoxVehicle.TabIndex = 51
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel9.Dock = DockStyle.Bottom
        Panel9.Location = New Point(0, 57)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(125, 2)
        Panel9.TabIndex = 81
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(TextBoxPlateNumber)
        Panel8.Controls.Add(Label3)
        Panel8.Controls.Add(Panel6)
        Panel8.Dock = DockStyle.Left
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(125, 59)
        Panel8.TabIndex = 80
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.BorderStyle = BorderStyle.None
        TextBoxPlateNumber.Font = New Font("Century Gothic", 11.25F)
        TextBoxPlateNumber.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxPlateNumber.Location = New Point(0, 24)
        TextBoxPlateNumber.Multiline = True
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(125, 31)
        TextBoxPlateNumber.TabIndex = 82
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Dock = DockStyle.Top
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label3.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        Label3.Location = New Point(0, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(110, 21)
        Label3.TabIndex = 75
        Label3.Text = "Plate Number"
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel6.Dock = DockStyle.Bottom
        Panel6.Location = New Point(0, 57)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(125, 2)
        Panel6.TabIndex = 72
        ' 
        ' Panel17
        ' 
        Panel17.Controls.Add(Label4)
        Panel17.Controls.Add(Panel7)
        Panel17.Controls.Add(TextBoxAddress)
        Panel17.Location = New Point(16, 183)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(261, 117)
        Panel17.TabIndex = 78
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Dock = DockStyle.Top
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label4.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        Label4.Location = New Point(0, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 21)
        Label4.TabIndex = 66
        Label4.Text = "Address"
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel7.Dock = DockStyle.Bottom
        Panel7.Location = New Point(0, 115)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(261, 2)
        Panel7.TabIndex = 71
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.BorderStyle = BorderStyle.None
        TextBoxAddress.Font = New Font("Century Gothic", 11.25F)
        TextBoxAddress.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxAddress.Location = New Point(0, 24)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 50
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Panel3)
        Panel12.Controls.Add(Label2)
        Panel12.Controls.Add(TextBoxEmail)
        Panel12.Location = New Point(16, 122)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(261, 55)
        Panel12.TabIndex = 77
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 53)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(261, 2)
        Panel3.TabIndex = 72
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Dock = DockStyle.Top
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label2.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        Label2.Location = New Point(0, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(48, 21)
        Label2.TabIndex = 65
        Label2.Text = "Email"
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.BorderStyle = BorderStyle.None
        TextBoxEmail.Font = New Font("Century Gothic", 11.25F)
        TextBoxEmail.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxEmail.Location = New Point(0, 24)
        TextBoxEmail.Multiline = True
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 31)
        TextBoxEmail.TabIndex = 49
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(LabelHolderPhone)
        Panel11.Controls.Add(Panel5)
        Panel11.Controls.Add(TextBoxNumber)
        Panel11.Location = New Point(16, 61)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(261, 55)
        Panel11.TabIndex = 76
        ' 
        ' LabelHolderPhone
        ' 
        LabelHolderPhone.AutoSize = True
        LabelHolderPhone.Dock = DockStyle.Top
        LabelHolderPhone.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelHolderPhone.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        LabelHolderPhone.Location = New Point(0, 0)
        LabelHolderPhone.Name = "LabelHolderPhone"
        LabelHolderPhone.Size = New Size(120, 21)
        LabelHolderPhone.TabIndex = 64
        LabelHolderPhone.Text = "Phone Number"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 53)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(261, 2)
        Panel5.TabIndex = 71
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.BorderStyle = BorderStyle.None
        TextBoxNumber.Font = New Font("Century Gothic", 11.25F)
        TextBoxNumber.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxNumber.Location = New Point(0, 24)
        TextBoxNumber.Multiline = True
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(261, 31)
        TextBoxNumber.TabIndex = 48
        ' 
        ' Panel10
        ' 
        Panel10.Controls.Add(LabelHolderName)
        Panel10.Controls.Add(Panel4)
        Panel10.Controls.Add(TextBoxName)
        Panel10.Location = New Point(16, 0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(261, 55)
        Panel10.TabIndex = 75
        ' 
        ' LabelHolderName
        ' 
        LabelHolderName.AutoSize = True
        LabelHolderName.Dock = DockStyle.Top
        LabelHolderName.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        LabelHolderName.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        LabelHolderName.Location = New Point(0, 0)
        LabelHolderName.Name = "LabelHolderName"
        LabelHolderName.Size = New Size(53, 21)
        LabelHolderName.TabIndex = 58
        LabelHolderName.Text = "Name"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel4.Dock = DockStyle.Bottom
        Panel4.Location = New Point(0, 53)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(261, 2)
        Panel4.TabIndex = 71
        ' 
        ' TextBoxName
        ' 
        TextBoxName.BorderStyle = BorderStyle.None
        TextBoxName.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxName.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        TextBoxName.Location = New Point(0, 24)
        TextBoxName.Multiline = True
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 31)
        TextBoxName.TabIndex = 47
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Century Gothic", 9F, FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(91, 505)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 17)
        customerIDLabel.TabIndex = 57
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(16, 627)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(260, 46)
        UpdateBtn.TabIndex = 43
        UpdateBtn.Text = "Update Customer"
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
        ViewBtn.Location = New Point(16, 575)
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
        Label67.Location = New Point(16, 505)
        Label67.Name = "Label67"
        Label67.Size = New Size(80, 17)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
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
        AddBtn.Location = New Point(16, 523)
        AddBtn.Name = "AddBtn"
        AddBtn.Size = New Size(260, 46)
        AddBtn.TabIndex = 42
        AddBtn.Text = "Add Customer"
        AddBtn.TextAlign = ContentAlignment.MiddleRight
        AddBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        AddBtn.UseVisualStyleBackColor = False
        ' 
        ' DataGridViewCustomerInformation
        ' 
        DataGridViewCustomerInformation.AllowUserToAddRows = False
        DataGridViewCustomerInformation.AllowUserToResizeColumns = False
        DataGridViewCustomerInformation.AllowUserToResizeRows = False
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
        ' SqlConnection1
        ' 
        SqlConnection1.AccessTokenCallback = Nothing
        SqlConnection1.FireInfoMessageEventOnUserErrors = False
        ' 
        ' NameTimer
        ' 
        NameTimer.Interval = 15
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
        Panel15.ResumeLayout(False)
        Panel13.ResumeLayout(False)
        Panel13.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        Panel17.ResumeLayout(False)
        Panel17.PerformLayout()
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        CType(DataGridViewCustomerInformation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewCustomerInformation As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents TextBoxVehicle As TextBox
    Friend WithEvents ViewBtn As Button
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents AddBtn As Button
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LabelHolderName As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LabelHolderPhone As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents SqlConnection1 As Microsoft.Data.SqlClient.SqlConnection
    Friend WithEvents ListViewVehicles As ListView
    Friend WithEvents AddVehicleBtn As Button
    Friend WithEvents RemoveVehicleBtn As Button
    Friend WithEvents NameTimer As Timer
End Class
