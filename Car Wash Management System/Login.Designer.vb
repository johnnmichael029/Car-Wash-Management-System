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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Panel1 = New Panel()
        Panel4 = New Panel()
        PictureBox1 = New PictureBox()
        LabelHolderPassword = New Label()
        Panel5 = New Panel()
        TextBoxPassword = New TextBox()
        Panel2 = New Panel()
        LabelHolderUsername = New Label()
        Panel3 = New Panel()
        TextBoxUsername = New TextBox()
        LoginBtn = New Button()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        TimerAnimator = New Timer(components)
        TimerAnimator1 = New Timer(components)
        Panel1.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Panel4)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(LoginBtn)
        Panel1.Dock = DockStyle.Fill
        Panel1.Font = New Font("Century Gothic", 9F)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1369, 749)
        Panel1.TabIndex = 11
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(PictureBox1)
        Panel4.Controls.Add(LabelHolderPassword)
        Panel4.Controls.Add(Panel5)
        Panel4.Controls.Add(TextBoxPassword)
        Panel4.Location = New Point(563, 352)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(260, 49)
        Panel4.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(235, 19)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(24, 28)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' LabelHolderPassword
        ' 
        LabelHolderPassword.Anchor = AnchorStyles.None
        LabelHolderPassword.AutoSize = True
        LabelHolderPassword.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelHolderPassword.ForeColor = Color.FromArgb(CByte(115), CByte(120), CByte(128))
        LabelHolderPassword.Location = New Point(3, 21)
        LabelHolderPassword.Name = "LabelHolderPassword"
        LabelHolderPassword.Size = New Size(78, 16)
        LabelHolderPassword.TabIndex = 2
        LabelHolderPassword.Text = "PASSWORD"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 47)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(260, 2)
        Panel5.TabIndex = 7
        ' 
        ' TextBoxPassword
        ' 
        TextBoxPassword.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        TextBoxPassword.BorderStyle = BorderStyle.None
        TextBoxPassword.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxPassword.Location = New Point(0, 18)
        TextBoxPassword.Multiline = True
        TextBoxPassword.Name = "TextBoxPassword"
        TextBoxPassword.PasswordChar = "●"c
        TextBoxPassword.Size = New Size(260, 28)
        TextBoxPassword.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(LabelHolderUsername)
        Panel2.Controls.Add(Panel3)
        Panel2.Controls.Add(TextBoxUsername)
        Panel2.Location = New Point(563, 285)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(260, 49)
        Panel2.TabIndex = 5
        ' 
        ' LabelHolderUsername
        ' 
        LabelHolderUsername.AutoSize = True
        LabelHolderUsername.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelHolderUsername.ForeColor = Color.FromArgb(CByte(115), CByte(120), CByte(128))
        LabelHolderUsername.Location = New Point(0, 19)
        LabelHolderUsername.Name = "LabelHolderUsername"
        LabelHolderUsername.Size = New Size(76, 16)
        LabelHolderUsername.TabIndex = 0
        LabelHolderUsername.Text = "USERNAME"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        Panel3.Dock = DockStyle.Bottom
        Panel3.Location = New Point(0, 47)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(260, 2)
        Panel3.TabIndex = 6
        ' 
        ' TextBoxUsername
        ' 
        TextBoxUsername.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        TextBoxUsername.BorderStyle = BorderStyle.None
        TextBoxUsername.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxUsername.Location = New Point(0, 18)
        TextBoxUsername.Multiline = True
        TextBoxUsername.Name = "TextBoxUsername"
        TextBoxUsername.Size = New Size(260, 28)
        TextBoxUsername.TabIndex = 1
        ' 
        ' LoginBtn
        ' 
        LoginBtn.Anchor = AnchorStyles.None
        LoginBtn.BackColor = Color.FromArgb(CByte(103), CByte(103), CByte(231))
        LoginBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        LoginBtn.FlatAppearance.BorderSize = 0
        LoginBtn.FlatStyle = FlatStyle.Flat
        LoginBtn.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LoginBtn.ForeColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        LoginBtn.Location = New Point(563, 422)
        LoginBtn.Name = "LoginBtn"
        LoginBtn.Size = New Size(260, 46)
        LoginBtn.TabIndex = 4
        LoginBtn.Text = "Login"
        LoginBtn.UseVisualStyleBackColor = False
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' TimerAnimator
        ' 
        TimerAnimator.Interval = 15
        ' 
        ' TimerAnimator1
        ' 
        TimerAnimator1.Interval = 15
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1369, 749)
        Controls.Add(Panel1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Login"
        Text = "Sandigan Carwash"
        Panel1.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LoginBtn As Button
    Friend WithEvents TextBoxPassword As TextBox
    Friend WithEvents LabelHolderPassword As Label
    Friend WithEvents TextBoxUsername As TextBox
    Friend WithEvents LabelHolderUsername As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TimerAnimator As Timer
    Friend WithEvents TimerAnimator1 As Timer


End Class
