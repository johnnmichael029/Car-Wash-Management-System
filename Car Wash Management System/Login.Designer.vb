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
        Label1 = New Label()
        TextBoxUsername = New TextBox()
        Label2 = New Label()
        TextBoxPassword = New TextBox()
        loginBtn = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(341, 181)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 4
        Label1.Text = "Username"
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.Location = New Point(341, 199)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(219, 23)
        TextBoxUsername.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(341, 235)
        Label2.Name = "Label2"
        Label2.Size = New Size(57, 15)
        Label2.TabIndex = 5
        Label2.Text = "Password"
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.Location = New Point(341, 253)
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "*"c
        TextBoxPassword.Size = New Size(219, 23)
        TextBoxPassword.TabIndex = 2
        ' 
        ' loginBtn
        ' 
        loginBtn.Location = New Point(341, 298)
        loginBtn.Name = "loginBtn"
        loginBtn.Size = New Size(219, 23)
        loginBtn.TabIndex = 1
        loginBtn.Text = "Login"
        loginBtn.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(914, 512)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBoxUsername)
        Controls.Add(TextBoxPassword)
        Controls.Add(loginBtn)
        Name = "Login"
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents loginBtn As Button

End Class
