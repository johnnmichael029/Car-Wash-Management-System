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
        Button1 = New Button()
        TextBoxUsername = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Button2 = New Button()
        TextBoxNewPassword = New TextBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(88, 232)
        Button1.Name = "Button1"
        Button1.Size = New Size(176, 23)
        Button1.TabIndex = 0
        Button1.Text = "Change"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.Location = New Point(88, 135)
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(176, 23)
        TextBoxUsername.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(88, 117)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 15)
        Label1.TabIndex = 2
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(88, 46)
        Label2.Name = "Label2"
        Label2.Size = New Size(187, 37)
        Label2.TabIndex = 3
        Label2.Text = "Administator"
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(292, 12)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 23)
        Button2.TabIndex = 4
        Button2.Text = "Exit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' TextBoxNewPassword
        ' 
        TextBoxNewPassword.Location = New Point(88, 192)
        TextBoxNewPassword.Name = "TextBoxNewPassword"
        TextBoxNewPassword.Size = New Size(176, 23)
        TextBoxNewPassword.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(88, 174)
        Label3.Name = "Label3"
        Label3.Size = New Size(57, 15)
        Label3.TabIndex = 6
        Label3.Text = "Password"
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(379, 308)
        Controls.Add(Label3)
        Controls.Add(TextBoxNewPassword)
        Controls.Add(Button2)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBoxUsername)
        Controls.Add(Button1)
        Name = "Admin"
        Text = "Admin"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBoxNewPassword As TextBox
    Friend WithEvents Label3 As Label
End Class
