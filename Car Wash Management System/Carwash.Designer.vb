<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Carwash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Carwash))
        Panel1 = New Panel()
        LabelWelcome = New Label()
        Button4 = New Button()
        customerBtn = New Button()
        saleBtn = New Button()
        dashboardBtn = New Button()
        Panel2 = New Panel()
        LabelCarwash = New Label()
        Button5 = New Button()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoSize = True
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(LabelWelcome)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(customerBtn)
        Panel1.Controls.Add(saleBtn)
        Panel1.Controls.Add(dashboardBtn)
        Panel1.Location = New Point(0, 1)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(255, 1039)
        Panel1.TabIndex = 2
        ' 
        ' LabelWelcome
        ' 
        LabelWelcome.AutoSize = True
        LabelWelcome.Font = New Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelWelcome.Location = New Point(0, 40)
        LabelWelcome.Name = "LabelWelcome"
        LabelWelcome.Size = New Size(174, 50)
        LabelWelcome.TabIndex = 4
        LabelWelcome.Text = "Welcome"
        ' 
        ' Button4
        ' 
        Button4.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Palatino Linotype", 20.25F)
        Button4.Location = New Point(0, 337)
        Button4.Name = "Button4"
        Button4.Size = New Size(249, 56)
        Button4.TabIndex = 3
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' customerBtn
        ' 
        customerBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        customerBtn.FlatAppearance.BorderSize = 0
        customerBtn.FlatStyle = FlatStyle.Flat
        customerBtn.Font = New Font("Palatino Linotype", 20.25F)
        customerBtn.Image = My.Resources.Resources.customer
        customerBtn.ImageAlign = ContentAlignment.MiddleLeft
        customerBtn.Location = New Point(0, 275)
        customerBtn.Name = "customerBtn"
        customerBtn.Size = New Size(249, 56)
        customerBtn.TabIndex = 2
        customerBtn.Text = "Customer"
        customerBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        customerBtn.UseVisualStyleBackColor = True
        ' 
        ' saleBtn
        ' 
        saleBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        saleBtn.FlatAppearance.BorderSize = 0
        saleBtn.FlatStyle = FlatStyle.Flat
        saleBtn.Font = New Font("Palatino Linotype", 20.25F)
        saleBtn.Image = My.Resources.Resources.book
        saleBtn.ImageAlign = ContentAlignment.MiddleLeft
        saleBtn.Location = New Point(0, 213)
        saleBtn.Name = "saleBtn"
        saleBtn.Size = New Size(249, 56)
        saleBtn.TabIndex = 1
        saleBtn.Text = "Sales Log"
        saleBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        saleBtn.UseVisualStyleBackColor = True
        ' 
        ' dashboardBtn
        ' 
        dashboardBtn.BackColor = Color.WhiteSmoke
        dashboardBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        dashboardBtn.FlatAppearance.BorderSize = 0
        dashboardBtn.FlatStyle = FlatStyle.Flat
        dashboardBtn.Font = New Font("Palatino Linotype", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dashboardBtn.Image = CType(resources.GetObject("dashboardBtn.Image"), Image)
        dashboardBtn.ImageAlign = ContentAlignment.MiddleLeft
        dashboardBtn.Location = New Point(0, 151)
        dashboardBtn.Name = "dashboardBtn"
        dashboardBtn.RightToLeft = RightToLeft.No
        dashboardBtn.Size = New Size(249, 56)
        dashboardBtn.TabIndex = 0
        dashboardBtn.Text = "Dashboard"
        dashboardBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        dashboardBtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        Panel2.Controls.Add(LabelCarwash)
        Panel2.Location = New Point(307, 78)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1565, 146)
        Panel2.TabIndex = 4
        ' 
        ' LabelCarwash
        ' 
        LabelCarwash.AutoSize = True
        LabelCarwash.Font = New Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCarwash.Location = New Point(77, 0)
        LabelCarwash.Name = "LabelCarwash"
        LabelCarwash.Size = New Size(886, 86)
        LabelCarwash.TabIndex = 0
        LabelCarwash.Text = "Carwash Management System"
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(1554, 27)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 5
        Button5.Text = "Exit"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(307, 281)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1565, 718)
        Panel3.TabIndex = 6
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel4.Location = New Point(33, 33)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1497, 647)
        Panel4.TabIndex = 0
        ' 
        ' Carwash
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        ClientSize = New Size(1904, 1041)
        Controls.Add(Panel3)
        Controls.Add(Button5)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        MinimizeBox = False
        Name = "Carwash"
        Text = "Carwash Management"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents customerBtn As Button
    Friend WithEvents saleBtn As Button
    Friend WithEvents dashboardBtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents LabelCarwash As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelWelcome As Label
End Class
