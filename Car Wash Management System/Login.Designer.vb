<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        Label1 = New Label()
        loginBtn = New Button()
        TextBoxUsername = New TextBox()
        Label2 = New Label()
        TextBoxPassword = New TextBox()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(loginBtn)
        Panel1.Controls.Add(TextBoxUsername)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(TextBoxPassword)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1369, 749)
        Panel1.TabIndex = 11
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Location = New Point(574, 301)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 0
        Label1.Text = "Username"
        ' 
        ' loginBtn
        ' 
        loginBtn.Anchor = AnchorStyles.None
        loginBtn.Location = New Point(574, 414)
        loginBtn.Name = "loginBtn"
        loginBtn.Size = New Size(219, 46)
        loginBtn.TabIndex = 4
        loginBtn.Text = "Login"
        loginBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.Anchor = AnchorStyles.None
        TextBoxUsername.Location = New Point(574, 319)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(219, 23)
        TextBoxUsername.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Location = New Point(574, 356)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 2
        Label2.Text = "Password"
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.Anchor = AnchorStyles.None
        TextBoxPassword.Location = New Point(574, 374)
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "*"c
        TextBoxPassword.Size = New Size(219, 23)
        TextBoxPassword.TabIndex = 3
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1369, 749)
        Controls.Add(Panel1)
        Name = "Login"
        Text = "Login"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents loginBtn As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents Label1 As Label


End Class
