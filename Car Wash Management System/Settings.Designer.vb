<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        ExitBtn = New Button()
        Panel1 = New Panel()
        CancelBtn = New Button()
        SaveBtn = New Button()
        BodyPanel = New Panel()
        Panel3 = New Panel()
        ComboBoxSelectForm = New ComboBox()
        Label3 = New Label()
        Label4 = New Label()
        LabelTotalPrice = New Label()
        CheckBoxTotalPrice = New CheckBox()
        Panel2 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        LabelIsAdmin = New Label()
        CheckBoxEnableDiscount = New CheckBox()
        CheckBoxFixDiscount = New CheckBox()
        NumericUpDownDiscount = New NumericUpDown()
        SidePanel = New Panel()
        DashboardBtn = New Button()
        Panel1.SuspendLayout()
        BodyPanel.SuspendLayout()
        Panel3.SuspendLayout()
        Panel2.SuspendLayout()
        CType(NumericUpDownDiscount, ComponentModel.ISupportInitialize).BeginInit()
        SidePanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' ExitBtn
        ' 
        ExitBtn.FlatAppearance.BorderSize = 0
        ExitBtn.FlatStyle = FlatStyle.Flat
        ExitBtn.Image = CType(resources.GetObject("ExitBtn.Image"), Image)
        ExitBtn.Location = New Point(849, 12)
        ExitBtn.Name = "ExitBtn"
        ExitBtn.Size = New Size(34, 23)
        ExitBtn.TabIndex = 112
        ExitBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.Controls.Add(CancelBtn)
        Panel1.Controls.Add(SaveBtn)
        Panel1.Controls.Add(BodyPanel)
        Panel1.Controls.Add(SidePanel)
        Panel1.Controls.Add(ExitBtn)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(895, 749)
        Panel1.TabIndex = 113
        ' 
        ' CancelBtn
        ' 
        CancelBtn.Anchor = AnchorStyles.None
        CancelBtn.BackColor = Color.FromArgb(CByte(197), CByte(199), CByte(208))
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Century Gothic", 11.25F)
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(631, 706)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(123, 40)
        CancelBtn.TabIndex = 146
        CancelBtn.Text = "Cancel"
        CancelBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' SaveBtn
        ' 
        SaveBtn.Anchor = AnchorStyles.None
        SaveBtn.BackColor = Color.Green
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Century Gothic", 11.25F)
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(760, 706)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(123, 40)
        SaveBtn.TabIndex = 145
        SaveBtn.Text = "Save"
        SaveBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' BodyPanel
        ' 
        BodyPanel.BackColor = Color.White
        BodyPanel.Controls.Add(Panel3)
        BodyPanel.Controls.Add(Panel2)
        BodyPanel.Location = New Point(218, 42)
        BodyPanel.Name = "BodyPanel"
        BodyPanel.Size = New Size(665, 661)
        BodyPanel.TabIndex = 114
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        Panel3.Controls.Add(ComboBoxSelectForm)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(LabelTotalPrice)
        Panel3.Controls.Add(CheckBoxTotalPrice)
        Panel3.Location = New Point(31, 163)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(601, 130)
        Panel3.TabIndex = 148
        ' 
        ' ComboBoxSelectForm
        ' 
        ComboBoxSelectForm.AutoCompleteCustomSource.AddRange(New String() {"Regular", "Contract", "Appointment", "Pickup", "Select-All"})
        ComboBoxSelectForm.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxSelectForm.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxSelectForm.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBoxSelectForm.FormattingEnabled = True
        ComboBoxSelectForm.Items.AddRange(New Object() {"Regular", "Contract", "Appointment", "Pickup", "Dashboard", "Select-All"})
        ComboBoxSelectForm.Location = New Point(135, 54)
        ComboBoxSelectForm.Name = "ComboBoxSelectForm"
        ComboBoxSelectForm.Size = New Size(455, 25)
        ComboBoxSelectForm.TabIndex = 147
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(3, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(177, 18)
        Label3.TabIndex = 146
        Label3.Text = "Enable Total Price Field"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(51, 53)
        Label4.Name = "Label4"
        Label4.Size = New Size(83, 20)
        Label4.TabIndex = 0
        Label4.Text = "Total Price"
        ' 
        ' LabelTotalPrice
        ' 
        LabelTotalPrice.AutoSize = True
        LabelTotalPrice.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        LabelTotalPrice.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelTotalPrice.ForeColor = SystemColors.ControlText
        LabelTotalPrice.Location = New Point(135, 102)
        LabelTotalPrice.Name = "LabelTotalPrice"
        LabelTotalPrice.Size = New Size(366, 16)
        LabelTotalPrice.TabIndex = 145
        LabelTotalPrice.Text = "IF this enable, Total Price Field can now be edited for specific price "
        ' 
        ' CheckBoxTotalPrice
        ' 
        CheckBoxTotalPrice.AutoSize = True
        CheckBoxTotalPrice.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBoxTotalPrice.Location = New Point(135, 25)
        CheckBoxTotalPrice.Name = "CheckBoxTotalPrice"
        CheckBoxTotalPrice.Size = New Size(67, 21)
        CheckBoxTotalPrice.TabIndex = 142
        CheckBoxTotalPrice.Text = "Enable"
        CheckBoxTotalPrice.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(LabelIsAdmin)
        Panel2.Controls.Add(CheckBoxEnableDiscount)
        Panel2.Controls.Add(CheckBoxFixDiscount)
        Panel2.Controls.Add(NumericUpDownDiscount)
        Panel2.Location = New Point(31, 16)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(601, 130)
        Panel2.TabIndex = 147
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(3, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(185, 18)
        Label2.TabIndex = 146
        Label2.Text = "Enable Discount Feature"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(51, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(72, 20)
        Label1.TabIndex = 0
        Label1.Text = "Discount"
        ' 
        ' LabelIsAdmin
        ' 
        LabelIsAdmin.AutoSize = True
        LabelIsAdmin.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        LabelIsAdmin.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelIsAdmin.ForeColor = Color.Red
        LabelIsAdmin.Location = New Point(135, 102)
        LabelIsAdmin.Name = "LabelIsAdmin"
        LabelIsAdmin.Size = New Size(41, 16)
        LabelIsAdmin.TabIndex = 145
        LabelIsAdmin.Text = "Admin"
        ' 
        ' CheckBoxEnableDiscount
        ' 
        CheckBoxEnableDiscount.AutoSize = True
        CheckBoxEnableDiscount.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBoxEnableDiscount.Location = New Point(135, 25)
        CheckBoxEnableDiscount.Name = "CheckBoxEnableDiscount"
        CheckBoxEnableDiscount.Size = New Size(67, 21)
        CheckBoxEnableDiscount.TabIndex = 142
        CheckBoxEnableDiscount.Text = "Enable"
        CheckBoxEnableDiscount.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxFixDiscount
        ' 
        CheckBoxFixDiscount.AutoSize = True
        CheckBoxFixDiscount.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBoxFixDiscount.Location = New Point(135, 78)
        CheckBoxFixDiscount.Name = "CheckBoxFixDiscount"
        CheckBoxFixDiscount.Size = New Size(97, 21)
        CheckBoxFixDiscount.TabIndex = 144
        CheckBoxFixDiscount.Text = "Fix Discount"
        CheckBoxFixDiscount.UseVisualStyleBackColor = True
        ' 
        ' NumericUpDownDiscount
        ' 
        NumericUpDownDiscount.BackColor = SystemColors.Window
        NumericUpDownDiscount.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NumericUpDownDiscount.Location = New Point(135, 50)
        NumericUpDownDiscount.Name = "NumericUpDownDiscount"
        NumericUpDownDiscount.Size = New Size(455, 22)
        NumericUpDownDiscount.TabIndex = 143
        NumericUpDownDiscount.Value = New Decimal(New Integer() {10, 0, 0, 0})
        ' 
        ' SidePanel
        ' 
        SidePanel.BackColor = Color.White
        SidePanel.Controls.Add(DashboardBtn)
        SidePanel.Location = New Point(12, 42)
        SidePanel.Name = "SidePanel"
        SidePanel.Size = New Size(200, 661)
        SidePanel.TabIndex = 113
        ' 
        ' DashboardBtn
        ' 
        DashboardBtn.BackColor = Color.FromArgb(CByte(247), CByte(247), CByte(247))
        DashboardBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        DashboardBtn.FlatAppearance.BorderSize = 0
        DashboardBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(239), CByte(238), CByte(238))
        DashboardBtn.FlatStyle = FlatStyle.Flat
        DashboardBtn.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DashboardBtn.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        DashboardBtn.Image = CType(resources.GetObject("DashboardBtn.Image"), Image)
        DashboardBtn.ImageAlign = ContentAlignment.MiddleLeft
        DashboardBtn.Location = New Point(13, 16)
        DashboardBtn.Name = "DashboardBtn"
        DashboardBtn.Padding = New Padding(5, 0, 5, 0)
        DashboardBtn.Size = New Size(170, 46)
        DashboardBtn.TabIndex = 6
        DashboardBtn.Text = "General"
        DashboardBtn.TextAlign = ContentAlignment.MiddleLeft
        DashboardBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        DashboardBtn.UseVisualStyleBackColor = False
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(895, 749)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Settings"
        Text = "Settings"
        Panel1.ResumeLayout(False)
        BodyPanel.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(NumericUpDownDiscount, ComponentModel.ISupportInitialize).EndInit()
        SidePanel.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ExitBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BodyPanel As Panel
    Friend WithEvents SidePanel As Panel
    Friend WithEvents DashboardBtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxFixDiscount As CheckBox
    Friend WithEvents NumericUpDownDiscount As NumericUpDown
    Friend WithEvents CheckBoxEnableDiscount As CheckBox
    Friend WithEvents SaveBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents LabelIsAdmin As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LabelTotalPrice As Label
    Friend WithEvents CheckBoxTotalPrice As CheckBox
    Friend WithEvents ComboBoxSelectForm As ComboBox
End Class
