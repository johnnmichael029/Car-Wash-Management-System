<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin
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
        TextBoxUsername = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        TextBoxNewPassword = New TextBox()
        Label3 = New Label()
        Panel1 = New Panel()
        ChangePasswordBtn = New Button()
        AddUserBtn = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.Anchor = AnchorStyles.None
        TextBoxUsername.Location = New Point(102, 130)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(219, 23)
        TextBoxUsername.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(102, 112)
        Label1.Name = "Label1"
        Label1.Size = New Size(67, 17)
        Label1.TabIndex = 2
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(102, 41)
        Label2.Name = "Label2"
        Label2.Size = New Size(187, 37)
        Label2.TabIndex = 3
        Label2.Text = "Administator"
        ' 
        ' TextBoxNewPassword
        ' 
        TextBoxNewPassword.Anchor = AnchorStyles.None
        TextBoxNewPassword.Location = New Point(102, 187)
        TextBoxNewPassword.Name = "TextBoxNewPassword"
        TextBoxNewPassword.Size = New Size(219, 23)
        TextBoxNewPassword.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(102, 169)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 17)
        Label3.TabIndex = 6
        Label3.Text = "Password"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.Controls.Add(ChangePasswordBtn)
        Panel1.Controls.Add(AddUserBtn)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(TextBoxNewPassword)
        Panel1.Controls.Add(TextBoxUsername)
        Panel1.Controls.Add(Label1)
        Panel1.Location = New Point(525, 216)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(414, 401)
        Panel1.TabIndex = 7
        ' 
        ' ChangePasswordBtn
        ' 
        ChangePasswordBtn.Anchor = AnchorStyles.None
        ChangePasswordBtn.BackColor = Color.FromArgb(CByte(198), CByte(47), CByte(48))
        ChangePasswordBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ChangePasswordBtn.FlatAppearance.BorderSize = 0
        ChangePasswordBtn.FlatStyle = FlatStyle.Flat
        ChangePasswordBtn.Font = New Font("Century Gothic", 9F)
        ChangePasswordBtn.ForeColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ChangePasswordBtn.Location = New Point(102, 297)
        ChangePasswordBtn.Name = "ChangePasswordBtn"
        ChangePasswordBtn.Size = New Size(219, 46)
        ChangePasswordBtn.TabIndex = 9
        ChangePasswordBtn.Text = "Change Password"
        ChangePasswordBtn.UseVisualStyleBackColor = False
        ' 
        ' AddUserBtn
        ' 
        AddUserBtn.Anchor = AnchorStyles.None
        AddUserBtn.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        AddUserBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        AddUserBtn.FlatAppearance.BorderSize = 0
        AddUserBtn.FlatStyle = FlatStyle.Flat
        AddUserBtn.Font = New Font("Century Gothic", 9F)
        AddUserBtn.ForeColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        AddUserBtn.Location = New Point(102, 235)
        AddUserBtn.Name = "AddUserBtn"
        AddUserBtn.Size = New Size(219, 46)
        AddUserBtn.TabIndex = 8
        AddUserBtn.Text = "Register"
        AddUserBtn.UseVisualStyleBackColor = False
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(1369, 749)
        Controls.Add(Panel1)
        Name = "Admin"
        Text = "Admin"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxNewPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents AddUserBtn As Button
    Friend WithEvents ChangePasswordBtn As Button
End Class
