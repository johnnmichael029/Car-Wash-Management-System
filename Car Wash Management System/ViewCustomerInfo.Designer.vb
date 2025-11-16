<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewCustomerInfo
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
        Panel8 = New Panel()
        LabelContractStatus = New Label()
        Label16 = New Label()
        LabelRevenue = New Label()
        Label10 = New Label()
        LabelTotalSaleMade = New Label()
        Label9 = New Label()
        Label15 = New Label()
        RemoveVehicleBtn = New Button()
        AddVehicleBtn = New Button()
        TextBoxVehicle = New TextBox()
        Label14 = New Label()
        TextBoxPlateNumber = New TextBox()
        UpdateBtn = New Button()
        Button1 = New Button()
        DataGridViewCustomerHistory = New DataGridView()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        TextBoxBarangay = New TextBox()
        Label13 = New Label()
        Label4 = New Label()
        TextBoxLastName = New TextBox()
        Label3 = New Label()
        ListViewVehicles = New ListView()
        customerIDLabel = New Label()
        Label8 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        Label2 = New Label()
        TextBoxNumber = New TextBox()
        TextBoxName = New TextBox()
        Panel8.SuspendLayout()
        CType(DataGridViewCustomerHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel8
        ' 
        Panel8.BorderStyle = BorderStyle.FixedSingle
        Panel8.Controls.Add(LabelContractStatus)
        Panel8.Controls.Add(Label16)
        Panel8.Controls.Add(LabelRevenue)
        Panel8.Controls.Add(Label10)
        Panel8.Controls.Add(LabelTotalSaleMade)
        Panel8.Controls.Add(Label9)
        Panel8.Controls.Add(Label15)
        Panel8.Controls.Add(RemoveVehicleBtn)
        Panel8.Controls.Add(AddVehicleBtn)
        Panel8.Controls.Add(TextBoxVehicle)
        Panel8.Controls.Add(Label14)
        Panel8.Controls.Add(TextBoxPlateNumber)
        Panel8.Controls.Add(UpdateBtn)
        Panel8.Controls.Add(Button1)
        Panel8.Controls.Add(DataGridViewCustomerHistory)
        Panel8.Controls.Add(Label7)
        Panel8.Controls.Add(Label6)
        Panel8.Controls.Add(Label5)
        Panel8.Controls.Add(TextBoxBarangay)
        Panel8.Controls.Add(Label13)
        Panel8.Controls.Add(Label4)
        Panel8.Controls.Add(TextBoxLastName)
        Panel8.Controls.Add(Label3)
        Panel8.Controls.Add(ListViewVehicles)
        Panel8.Controls.Add(customerIDLabel)
        Panel8.Controls.Add(Label8)
        Panel8.Controls.Add(Label11)
        Panel8.Controls.Add(Label12)
        Panel8.Controls.Add(TextBoxAddress)
        Panel8.Controls.Add(TextBoxEmail)
        Panel8.Controls.Add(Label2)
        Panel8.Controls.Add(TextBoxNumber)
        Panel8.Controls.Add(TextBoxName)
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(911, 788)
        Panel8.TabIndex = 73
        ' 
        ' LabelContractStatus
        ' 
        LabelContractStatus.AutoSize = True
        LabelContractStatus.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelContractStatus.ForeColor = Color.Red
        LabelContractStatus.Location = New Point(143, 753)
        LabelContractStatus.Name = "LabelContractStatus"
        LabelContractStatus.Size = New Size(36, 15)
        LabelContractStatus.TabIndex = 124
        LabelContractStatus.Text = "None"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.Location = New Point(50, 752)
        Label16.Name = "Label16"
        Label16.Size = New Size(95, 16)
        Label16.TabIndex = 123
        Label16.Text = "Contract Status:"
        ' 
        ' LabelRevenue
        ' 
        LabelRevenue.AutoSize = True
        LabelRevenue.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelRevenue.ForeColor = Color.Red
        LabelRevenue.Location = New Point(111, 737)
        LabelRevenue.Name = "LabelRevenue"
        LabelRevenue.Size = New Size(13, 15)
        LabelRevenue.TabIndex = 122
        LabelRevenue.Text = "1"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(50, 736)
        Label10.Name = "Label10"
        Label10.Size = New Size(62, 16)
        Label10.TabIndex = 121
        Label10.Text = "Revenue:"
        ' 
        ' LabelTotalSaleMade
        ' 
        LabelTotalSaleMade.AutoSize = True
        LabelTotalSaleMade.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelTotalSaleMade.ForeColor = Color.Red
        LabelTotalSaleMade.Location = New Point(162, 719)
        LabelTotalSaleMade.Name = "LabelTotalSaleMade"
        LabelTotalSaleMade.Size = New Size(13, 15)
        LabelTotalSaleMade.TabIndex = 120
        LabelTotalSaleMade.Text = "1"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(50, 719)
        Label9.Name = "Label9"
        Label9.Size = New Size(109, 16)
        Label9.TabIndex = 119
        Label9.Text = "Total Sales Made:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Century Gothic", 9F)
        Label15.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label15.Location = New Point(320, 198)
        Label15.Name = "Label15"
        Label15.Size = New Size(84, 17)
        Label15.TabIndex = 116
        Label15.Text = "Vehicle Type"
        ' 
        ' RemoveVehicleBtn
        ' 
        RemoveVehicleBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        RemoveVehicleBtn.FlatAppearance.BorderSize = 0
        RemoveVehicleBtn.FlatStyle = FlatStyle.Flat
        RemoveVehicleBtn.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RemoveVehicleBtn.ForeColor = Color.White
        RemoveVehicleBtn.Location = New Point(722, 178)
        RemoveVehicleBtn.Name = "RemoveVehicleBtn"
        RemoveVehicleBtn.Size = New Size(123, 40)
        RemoveVehicleBtn.TabIndex = 118
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
        AddVehicleBtn.Location = New Point(584, 178)
        AddVehicleBtn.Name = "AddVehicleBtn"
        AddVehicleBtn.Size = New Size(123, 40)
        AddVehicleBtn.TabIndex = 117
        AddVehicleBtn.Text = "Add"
        AddVehicleBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxVehicle
        ' 
        TextBoxVehicle.Font = New Font("Century Gothic", 11.25F)
        TextBoxVehicle.Location = New Point(317, 178)
        TextBoxVehicle.Multiline = True
        TextBoxVehicle.Name = "TextBoxVehicle"
        TextBoxVehicle.Size = New Size(261, 40)
        TextBoxVehicle.TabIndex = 115
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Century Gothic", 9F)
        Label14.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label14.Location = New Point(54, 198)
        Label14.Name = "Label14"
        Label14.Size = New Size(89, 17)
        Label14.TabIndex = 114
        Label14.Text = "Plate Number"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Font = New Font("Century Gothic", 11.25F)
        TextBoxPlateNumber.Location = New Point(50, 178)
        TextBoxPlateNumber.Multiline = True
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(261, 40)
        TextBoxPlateNumber.TabIndex = 113
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.Green
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(722, 719)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(123, 40)
        UpdateBtn.TabIndex = 112
        UpdateBtn.Text = "Save"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.reject1
        Button1.Location = New Point(865, 9)
        Button1.Name = "Button1"
        Button1.Size = New Size(34, 23)
        Button1.TabIndex = 111
        Button1.UseVisualStyleBackColor = True
        ' 
        ' DataGridViewCustomerHistory
        ' 
        DataGridViewCustomerHistory.AllowUserToAddRows = False
        DataGridViewCustomerHistory.AllowUserToResizeColumns = False
        DataGridViewCustomerHistory.AllowUserToResizeRows = False
        DataGridViewCustomerHistory.Anchor = AnchorStyles.None
        DataGridViewCustomerHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCustomerHistory.BackgroundColor = Color.White
        DataGridViewCustomerHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCustomerHistory.Location = New Point(50, 483)
        DataGridViewCustomerHistory.Name = "DataGridViewCustomerHistory"
        DataGridViewCustomerHistory.ReadOnly = True
        DataGridViewCustomerHistory.Size = New Size(795, 230)
        DataGridViewCustomerHistory.TabIndex = 110
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label7.Location = New Point(41, 461)
        Label7.Name = "Label7"
        Label7.Size = New Size(183, 19)
        Label7.TabIndex = 109
        Label7.Text = "TRANSACTION HISTORY"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label6.Location = New Point(41, 153)
        Label6.Name = "Label6"
        Label6.Size = New Size(182, 19)
        Label6.TabIndex = 108
        Label6.Text = "VEHICLE INFORMATION"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 9F)
        Label5.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label5.Location = New Point(588, 125)
        Label5.Name = "Label5"
        Label5.Size = New Size(64, 17)
        Label5.TabIndex = 107
        Label5.Text = "Barangay"
        ' 
        ' TextBoxBarangay
        ' 
        TextBoxBarangay.Font = New Font("Century Gothic", 11.25F)
        TextBoxBarangay.Location = New Point(584, 105)
        TextBoxBarangay.Multiline = True
        TextBoxBarangay.Name = "TextBoxBarangay"
        TextBoxBarangay.Size = New Size(261, 40)
        TextBoxBarangay.TabIndex = 106
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label13.Location = New Point(320, 125)
        Label13.Name = "Label13"
        Label13.Size = New Size(31, 17)
        Label13.TabIndex = 94
        Label13.Text = "City"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label4.Location = New Point(321, 69)
        Label4.Name = "Label4"
        Label4.Size = New Size(71, 17)
        Label4.TabIndex = 104
        Label4.Text = "Last Name"
        ' 
        ' TextBoxLastName
        ' 
        TextBoxLastName.Font = New Font("Century Gothic", 11.25F)
        TextBoxLastName.Location = New Point(317, 49)
        TextBoxLastName.Multiline = True
        TextBoxLastName.Name = "TextBoxLastName"
        TextBoxLastName.Size = New Size(261, 40)
        TextBoxLastName.TabIndex = 105
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label3.Location = New Point(41, 26)
        Label3.Name = "Label3"
        Label3.Size = New Size(202, 19)
        Label3.TabIndex = 103
        Label3.Text = "CUSTOMER INFORMATION"
        ' 
        ' ListViewVehicles
        ' 
        ListViewVehicles.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ListViewVehicles.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ListViewVehicles.FullRowSelect = True
        ListViewVehicles.GridLines = True
        ListViewVehicles.Location = New Point(50, 224)
        ListViewVehicles.Name = "ListViewVehicles"
        ListViewVehicles.Size = New Size(795, 230)
        ListViewVehicles.TabIndex = 100
        ListViewVehicles.UseCompatibleStateImageBehavior = False
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(492, 9)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 97
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label8.Location = New Point(54, 68)
        Label8.Name = "Label8"
        Label8.Size = New Size(70, 17)
        Label8.TabIndex = 86
        Label8.Text = "First Name"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label11.Location = New Point(587, 69)
        Label11.Name = "Label11"
        Label11.Size = New Size(95, 17)
        Label11.TabIndex = 92
        Label11.Text = "Phone Number"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Century Gothic", 9F)
        Label12.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label12.Location = New Point(53, 125)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 17)
        Label12.TabIndex = 93
        Label12.Text = "Email"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Font = New Font("Century Gothic", 11.25F)
        TextBoxAddress.Location = New Point(317, 105)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 40)
        TextBoxAddress.TabIndex = 90
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Font = New Font("Century Gothic", 11.25F)
        TextBoxEmail.Location = New Point(50, 105)
        TextBoxEmail.Multiline = True
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 40)
        TextBoxEmail.TabIndex = 89
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(417, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 17)
        Label2.TabIndex = 96
        Label2.Text = "Customer ID"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Font = New Font("Century Gothic", 11.25F)
        TextBoxNumber.Location = New Point(584, 49)
        TextBoxNumber.Multiline = True
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(261, 40)
        TextBoxNumber.TabIndex = 88
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Font = New Font("Century Gothic", 11.25F)
        TextBoxName.Location = New Point(50, 48)
        TextBoxName.Multiline = True
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 40)
        TextBoxName.TabIndex = 87
        ' 
        ' ViewCustomerInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(911, 788)
        Controls.Add(Panel8)
        FormBorderStyle = FormBorderStyle.None
        Name = "ViewCustomerInfo"
        Text = "EditProfile"
        Panel8.ResumeLayout(False)
        Panel8.PerformLayout()
        CType(DataGridViewCustomerHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel8 As Panel
    Friend WithEvents ListViewVehicles As ListView
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxLastName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxBarangay As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridViewCustomerHistory As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents RemoveVehicleBtn As Button
    Friend WithEvents AddVehicleBtn As Button
    Friend WithEvents TextBoxVehicle As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents LabelRevenue As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LabelTotalSaleMade As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LabelContractStatus As Label
    Friend WithEvents Label16 As Label
End Class
