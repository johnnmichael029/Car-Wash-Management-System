<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPickupInfo
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
        Button1 = New Button()
        UpdateBtn = New Button()
        Label13 = New Label()
        TextBoxPickupAddress = New TextBox()
        LabelPickupID = New Label()
        Label9 = New Label()
        ViewFullAddressPanel = New Panel()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.reject1
        Button1.Location = New Point(754, 11)
        Button1.Name = "Button1"
        Button1.Size = New Size(34, 23)
        Button1.TabIndex = 114
        Button1.UseVisualStyleBackColor = True
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.Top
        UpdateBtn.BackColor = Color.Green
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(665, 406)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(123, 40)
        UpdateBtn.TabIndex = 116
        UpdateBtn.Text = "Save"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Century Gothic", 9F)
        Label13.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label13.Location = New Point(15, 426)
        Label13.Name = "Label13"
        Label13.Size = New Size(77, 17)
        Label13.TabIndex = 118
        Label13.Text = "Full Address"
        ' 
        ' TextBoxPickupAddress
        ' 
        TextBoxPickupAddress.Font = New Font("Century Gothic", 11.25F)
        TextBoxPickupAddress.Location = New Point(12, 406)
        TextBoxPickupAddress.Multiline = True
        TextBoxPickupAddress.Name = "TextBoxPickupAddress"
        TextBoxPickupAddress.Size = New Size(261, 40)
        TextBoxPickupAddress.TabIndex = 117
        ' 
        ' LabelPickupID
        ' 
        LabelPickupID.AutoSize = True
        LabelPickupID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelPickupID.ForeColor = Color.Red
        LabelPickupID.Location = New Point(411, 3)
        LabelPickupID.Name = "LabelPickupID"
        LabelPickupID.Size = New Size(0, 15)
        LabelPickupID.TabIndex = 120
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(358, 3)
        Label9.Name = "Label9"
        Label9.Size = New Size(62, 17)
        Label9.TabIndex = 119
        Label9.Text = "Pickup ID"
        ' 
        ' ViewFullAddressPanel
        ' 
        ViewFullAddressPanel.Location = New Point(12, 25)
        ViewFullAddressPanel.Name = "ViewFullAddressPanel"
        ViewFullAddressPanel.Size = New Size(776, 375)
        ViewFullAddressPanel.TabIndex = 121
        ' 
        ' ViewPickupInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        Controls.Add(ViewFullAddressPanel)
        Controls.Add(LabelPickupID)
        Controls.Add(Label9)
        Controls.Add(Label13)
        Controls.Add(TextBoxPickupAddress)
        Controls.Add(UpdateBtn)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.None
        Name = "ViewPickupInfo"
        Text = "ViewPickupInfo"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents TextBoxPickupAddress As TextBox
    Friend WithEvents LabelPickupID As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ViewFullAddressPanel As Panel
End Class
