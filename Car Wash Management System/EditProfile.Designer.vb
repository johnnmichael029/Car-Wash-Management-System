<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditProfile
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
        SaveBtn = New Button()
        CancelBtn = New Button()
        Panel1 = New Panel()
        customerIDLabel = New Label()
        Label1 = New Label()
        Label2 = New Label()
        TextBoxVehicle = New TextBox()
        Label3 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        Label67 = New Label()
        Label4 = New Label()
        TextBoxNumber = New TextBox()
        Label5 = New Label()
        TextBoxName = New TextBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Panel5 = New Panel()
        Panel6 = New Panel()
        Panel7 = New Panel()
        Panel8 = New Panel()
        Panel15 = New Panel()
        Panel16 = New Panel()
        Panel20 = New Panel()
        TextBoxPlateNumber = New TextBox()
        Label6 = New Label()
        Panel18 = New Panel()
        Panel19 = New Panel()
        Panel17 = New Panel()
        Panel13 = New Panel()
        Panel14 = New Panel()
        Panel12 = New Panel()
        Panel11 = New Panel()
        Panel10 = New Panel()
        Panel9 = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        Panel6.SuspendLayout()
        Panel8.SuspendLayout()
        Panel15.SuspendLayout()
        Panel16.SuspendLayout()
        Panel18.SuspendLayout()
        Panel17.SuspendLayout()
        Panel13.SuspendLayout()
        Panel12.SuspendLayout()
        Panel11.SuspendLayout()
        Panel10.SuspendLayout()
        Panel9.SuspendLayout()
        SuspendLayout()
        ' 
        ' SaveBtn
        ' 
        SaveBtn.Anchor = AnchorStyles.Top
        SaveBtn.BackColor = Color.Green
        SaveBtn.FlatAppearance.BorderColor = Color.Green
        SaveBtn.FlatAppearance.BorderSize = 0
        SaveBtn.FlatStyle = FlatStyle.Flat
        SaveBtn.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SaveBtn.ForeColor = Color.White
        SaveBtn.Location = New Point(43, 26)
        SaveBtn.Name = "SaveBtn"
        SaveBtn.Size = New Size(126, 46)
        SaveBtn.TabIndex = 44
        SaveBtn.Text = "Save"
        SaveBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        SaveBtn.UseVisualStyleBackColor = False
        ' 
        ' CancelBtn
        ' 
        CancelBtn.Anchor = AnchorStyles.Top
        CancelBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        CancelBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        CancelBtn.FlatAppearance.BorderSize = 0
        CancelBtn.FlatStyle = FlatStyle.Flat
        CancelBtn.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CancelBtn.ForeColor = Color.White
        CancelBtn.Location = New Point(175, 26)
        CancelBtn.Name = "CancelBtn"
        CancelBtn.Size = New Size(126, 46)
        CancelBtn.TabIndex = 45
        CancelBtn.Text = "Cancel"
        CancelBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        CancelBtn.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(SaveBtn)
        Panel1.Controls.Add(CancelBtn)
        Panel1.Dock = DockStyle.Bottom
        Panel1.Location = New Point(0, 458)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(368, 100)
        Panel1.TabIndex = 46
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(202, 2)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(25, 15)
        customerIDLabel.TabIndex = 69
        customerIDLabel.Text = "asd"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label1.Location = New Point(27, 5)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 21)
        Label1.TabIndex = 58
        Label1.Text = "Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(27, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(120, 21)
        Label2.TabIndex = 64
        Label2.Text = "Phone Number"
        ' 
        ' TextBoxVehicle
        ' 
        TextBoxVehicle.BorderStyle = BorderStyle.None
        TextBoxVehicle.Dock = DockStyle.Fill
        TextBoxVehicle.Font = New Font("Segoe UI", 12F)
        TextBoxVehicle.Location = New Point(0, 0)
        TextBoxVehicle.Multiline = True
        TextBoxVehicle.Name = "TextBoxVehicle"
        TextBoxVehicle.Size = New Size(145, 30)
        TextBoxVehicle.TabIndex = 63
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label3.Location = New Point(27, 5)
        Label3.Name = "Label3"
        Label3.Size = New Size(48, 21)
        Label3.TabIndex = 65
        Label3.Text = "Email"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.BorderStyle = BorderStyle.None
        TextBoxAddress.Dock = DockStyle.Fill
        TextBoxAddress.Font = New Font("Segoe UI", 12F)
        TextBoxAddress.Location = New Point(0, 0)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(299, 95)
        TextBoxAddress.TabIndex = 62
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.BorderStyle = BorderStyle.None
        TextBoxEmail.Dock = DockStyle.Fill
        TextBoxEmail.Font = New Font("Segoe UI", 12F)
        TextBoxEmail.Location = New Point(0, 0)
        TextBoxEmail.Multiline = True
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(299, 29)
        TextBoxEmail.TabIndex = 61
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        Label67.Location = New Point(132, 2)
        Label67.Name = "Label67"
        Label67.Size = New Size(74, 15)
        Label67.TabIndex = 68
        Label67.Text = "Customer ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label4.Location = New Point(27, 5)
        Label4.Name = "Label4"
        Label4.Size = New Size(70, 21)
        Label4.TabIndex = 66
        Label4.Text = "Address"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.BorderStyle = BorderStyle.None
        TextBoxNumber.Dock = DockStyle.Fill
        TextBoxNumber.Font = New Font("Segoe UI", 12F)
        TextBoxNumber.Location = New Point(0, 0)
        TextBoxNumber.Multiline = True
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(299, 29)
        TextBoxNumber.TabIndex = 60
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label5.Location = New Point(24, 5)
        Label5.Name = "Label5"
        Label5.Size = New Size(62, 21)
        Label5.TabIndex = 67
        Label5.Text = "Vehicle"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.BorderStyle = BorderStyle.None
        TextBoxName.Dock = DockStyle.Fill
        TextBoxName.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxName.Location = New Point(0, 0)
        TextBoxName.Multiline = True
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(299, 30)
        TextBoxName.TabIndex = 59
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel3)
        Panel2.Controls.Add(TextBoxName)
        Panel2.Location = New Point(27, 29)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(299, 30)
        Panel2.TabIndex = 70
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 28)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(299, 2)
        Panel3.TabIndex = 71
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Panel5)
        Panel4.Controls.Add(TextBoxNumber)
        Panel4.Location = New Point(26, 29)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(299, 29)
        Panel4.TabIndex = 71
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 27)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(299, 2)
        Panel5.TabIndex = 71
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Panel7)
        Panel6.Controls.Add(TextBoxEmail)
        Panel6.Location = New Point(27, 29)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(299, 29)
        Panel6.TabIndex = 72
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel7.Dock = DockStyle.Bottom
        Panel7.Location = New Point(0, 27)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(299, 2)
        Panel7.TabIndex = 71
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(Panel15)
        Panel8.Controls.Add(Panel17)
        Panel8.Controls.Add(Panel12)
        Panel8.Controls.Add(Panel11)
        Panel8.Controls.Add(Panel10)
        Panel8.Controls.Add(Panel9)
        Panel8.Dock = DockStyle.Fill
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(368, 458)
        Panel8.TabIndex = 73
        ' 
        ' Panel15
        ' 
        Panel15.Controls.Add(Panel16)
        Panel15.Controls.Add(Label6)
        Panel15.Controls.Add(Panel18)
        Panel15.Controls.Add(Label5)
        Panel15.Location = New Point(0, 321)
        Panel15.Name = "Panel15"
        Panel15.Size = New Size(368, 59)
        Panel15.TabIndex = 78
        ' 
        ' Panel16
        ' 
        Panel16.Controls.Add(Panel20)
        Panel16.Controls.Add(TextBoxPlateNumber)
        Panel16.Location = New Point(181, 29)
        Panel16.Name = "Panel16"
        Panel16.Size = New Size(145, 30)
        Panel16.TabIndex = 76
        ' 
        ' Panel20
        ' 
        Panel20.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel20.Dock = DockStyle.Bottom
        Panel20.Location = New Point(0, 28)
        Panel20.Name = "Panel20"
        Panel20.Size = New Size(145, 2)
        Panel20.TabIndex = 71
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.BorderStyle = BorderStyle.None
        TextBoxPlateNumber.Dock = DockStyle.Fill
        TextBoxPlateNumber.Font = New Font("Segoe UI", 12F)
        TextBoxPlateNumber.Location = New Point(0, 0)
        TextBoxPlateNumber.Multiline = True
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(145, 30)
        TextBoxPlateNumber.TabIndex = 63
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        Label6.Location = New Point(175, 5)
        Label6.Name = "Label6"
        Label6.Size = New Size(110, 21)
        Label6.TabIndex = 75
        Label6.Text = "Plate Number"
        ' 
        ' Panel18
        ' 
        Panel18.Controls.Add(Panel19)
        Panel18.Controls.Add(TextBoxVehicle)
        Panel18.Location = New Point(27, 29)
        Panel18.Name = "Panel18"
        Panel18.Size = New Size(145, 30)
        Panel18.TabIndex = 74
        ' 
        ' Panel19
        ' 
        Panel19.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel19.Dock = DockStyle.Bottom
        Panel19.Location = New Point(0, 28)
        Panel19.Name = "Panel19"
        Panel19.Size = New Size(145, 2)
        Panel19.TabIndex = 71
        ' 
        ' Panel17
        ' 
        Panel17.Controls.Add(Panel13)
        Panel17.Controls.Add(Label4)
        Panel17.Dock = DockStyle.Top
        Panel17.Location = New Point(0, 196)
        Panel17.Name = "Panel17"
        Panel17.Size = New Size(368, 124)
        Panel17.TabIndex = 77
        ' 
        ' Panel13
        ' 
        Panel13.Controls.Add(Panel14)
        Panel13.Controls.Add(TextBoxAddress)
        Panel13.Location = New Point(29, 29)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(299, 95)
        Panel13.TabIndex = 73
        ' 
        ' Panel14
        ' 
        Panel14.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel14.Dock = DockStyle.Bottom
        Panel14.Location = New Point(0, 93)
        Panel14.Name = "Panel14"
        Panel14.Size = New Size(299, 2)
        Panel14.TabIndex = 71
        ' 
        ' Panel12
        ' 
        Panel12.Controls.Add(Panel6)
        Panel12.Controls.Add(Label3)
        Panel12.Dock = DockStyle.Top
        Panel12.Location = New Point(0, 137)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(368, 59)
        Panel12.TabIndex = 76
        ' 
        ' Panel11
        ' 
        Panel11.Controls.Add(Label2)
        Panel11.Controls.Add(Panel4)
        Panel11.Dock = DockStyle.Top
        Panel11.Location = New Point(0, 78)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(368, 59)
        Panel11.TabIndex = 75
        ' 
        ' Panel10
        ' 
        Panel10.Controls.Add(Label1)
        Panel10.Controls.Add(Panel2)
        Panel10.Dock = DockStyle.Top
        Panel10.Location = New Point(0, 19)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(368, 59)
        Panel10.TabIndex = 74
        ' 
        ' Panel9
        ' 
        Panel9.Controls.Add(Label67)
        Panel9.Controls.Add(customerIDLabel)
        Panel9.Dock = DockStyle.Top
        Panel9.Location = New Point(0, 0)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(368, 19)
        Panel9.TabIndex = 73
        ' 
        ' EditProfile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(368, 558)
        Controls.Add(Panel8)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "EditProfile"
        Text = "EditProfile"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel15.ResumeLayout(False)
        Panel15.PerformLayout()
        Panel16.ResumeLayout(False)
        Panel16.PerformLayout()
        Panel18.ResumeLayout(False)
        Panel18.PerformLayout()
        Panel17.ResumeLayout(False)
        Panel17.PerformLayout()
        Panel13.ResumeLayout(False)
        Panel13.PerformLayout()
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SaveBtn As Button
    Friend WithEvents CancelBtn As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxVehicle As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents Label6 As Label
End Class
