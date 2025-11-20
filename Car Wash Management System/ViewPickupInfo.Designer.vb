<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewPickupInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewPickupInfo))
        Button1 = New Button()
        UpdateBtn = New Button()
        TextBoxPickupAddress = New TextBox()
        LabelPickupID = New Label()
        Label9 = New Label()
        ViewWebBrowserMapPanel = New Panel()
        HelpProvider1 = New HelpProvider()
        TextBoxCarwashAddress = New TextBox()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.reject1
        Button1.Location = New Point(754, 10)
        Button1.Name = "Button1"
        Button1.Size = New Size(34, 23)
        Button1.TabIndex = 114
        Button1.UseVisualStyleBackColor = True
        ' 
        ' UpdateBtn
        ' 
        UpdateBtn.Anchor = AnchorStyles.None
        UpdateBtn.BackColor = Color.Green
        UpdateBtn.FlatAppearance.BorderSize = 0
        UpdateBtn.FlatStyle = FlatStyle.Flat
        UpdateBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateBtn.ForeColor = Color.White
        UpdateBtn.Location = New Point(677, 3)
        UpdateBtn.Name = "UpdateBtn"
        UpdateBtn.Size = New Size(123, 40)
        UpdateBtn.TabIndex = 116
        UpdateBtn.Text = "Save"
        UpdateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        UpdateBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPickupAddress
        ' 
        TextBoxPickupAddress.Anchor = AnchorStyles.None
        TextBoxPickupAddress.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxPickupAddress.Location = New Point(411, 3)
        TextBoxPickupAddress.Multiline = True
        TextBoxPickupAddress.Name = "TextBoxPickupAddress"
        TextBoxPickupAddress.Size = New Size(261, 40)
        TextBoxPickupAddress.TabIndex = 117
        ' 
        ' LabelPickupID
        ' 
        LabelPickupID.Anchor = AnchorStyles.None
        LabelPickupID.AutoSize = True
        LabelPickupID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelPickupID.ForeColor = Color.Red
        LabelPickupID.Location = New Point(414, 9)
        LabelPickupID.Name = "LabelPickupID"
        LabelPickupID.Size = New Size(0, 15)
        LabelPickupID.TabIndex = 120
        ' 
        ' Label9
        ' 
        Label9.Anchor = AnchorStyles.None
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(353, 9)
        Label9.Name = "Label9"
        Label9.Size = New Size(62, 17)
        Label9.TabIndex = 119
        Label9.Text = "Pickup ID"
        ' 
        ' ViewWebBrowserMapPanel
        ' 
        ViewWebBrowserMapPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ViewWebBrowserMapPanel.Location = New Point(0, 40)
        ViewWebBrowserMapPanel.Name = "ViewWebBrowserMapPanel"
        ViewWebBrowserMapPanel.Size = New Size(803, 360)
        ViewWebBrowserMapPanel.TabIndex = 121
        ' 
        ' TextBoxCarwashAddress
        ' 
        TextBoxCarwashAddress.Anchor = AnchorStyles.None
        TextBoxCarwashAddress.BackColor = Color.White
        TextBoxCarwashAddress.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxCarwashAddress.Location = New Point(25, 3)
        TextBoxCarwashAddress.Multiline = True
        TextBoxCarwashAddress.Name = "TextBoxCarwashAddress"
        TextBoxCarwashAddress.ReadOnly = True
        TextBoxCarwashAddress.Size = New Size(261, 40)
        TextBoxCarwashAddress.TabIndex = 122
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.None
        PictureBox1.Image = My.Resources.Resources.location
        PictureBox1.Location = New Point(382, 16)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(23, 19)
        PictureBox1.TabIndex = 124
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.None
        PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Image)
        PictureBox2.Location = New Point(292, 16)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(23, 19)
        PictureBox2.TabIndex = 125
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.None
        PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Image)
        PictureBox3.Location = New Point(338, 16)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(23, 19)
        PictureBox3.TabIndex = 126
        PictureBox3.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(LabelPickupID)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(800, 34)
        Panel1.TabIndex = 127
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(TextBoxCarwashAddress)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Controls.Add(UpdateBtn)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Controls.Add(TextBoxPickupAddress)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 406)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(800, 44)
        Panel2.TabIndex = 0
        ' 
        ' ViewPickupInfo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(ViewWebBrowserMapPanel)
        Name = "ViewPickupInfo"
        Text = "ViewPickupInfo"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents UpdateBtn As Button
    Friend WithEvents TextBoxPickupAddress As TextBox
    Friend WithEvents LabelPickupID As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ViewWebBrowserMapPanel As Panel
    Friend WithEvents HelpProvider1 As HelpProvider
    Friend WithEvents TextBoxCarwashAddress As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
