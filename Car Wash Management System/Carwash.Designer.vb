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
        Panel5 = New Panel()
        logoutBtn = New Button()
        dashboardBtn = New Button()
        LabelWelcome = New Label()
        Button4 = New Button()
        Btn3 = New Button()
        Btn2 = New Button()
        Panel2 = New Panel()
        LabelCarwash = New Label()
        Button5 = New Button()
        Panel3 = New Panel()
        Panel6 = New Panel()
        Panel7 = New Panel()
        Panel4 = New Panel()
        MenuStrip1 = New MenuStrip()
        FIleToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        ServiceTrackingToolStripMenuItem = New ToolStripMenuItem()
        ServiceCatalogToolStripMenuItem = New ToolStripMenuItem()
        CustomerInformationToolStripMenuItem = New ToolStripMenuItem()
        SaleHistoryToolStripMenuItem = New ToolStripMenuItem()
        BillingAndToolStripMenuItem = New ToolStripMenuItem()
        BookingToolStripMenuItem = New ToolStripMenuItem()
        AppointmentScheduleToolStripMenuItem1 = New ToolStripMenuItem()
        ListToolStripMenuItem = New ToolStripMenuItem()
        OnTheDayScheduleToolStripMenuItem = New ToolStripMenuItem()
        Panel1.SuspendLayout()
        Panel5.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.WhiteSmoke
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(dashboardBtn)
        Panel1.Controls.Add(LabelWelcome)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Btn3)
        Panel1.Controls.Add(Btn2)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 24)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(177, 725)
        Panel1.TabIndex = 2
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(logoutBtn)
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 572)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(177, 153)
        Panel5.TabIndex = 7
        ' 
        ' logoutBtn
        ' 
        logoutBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        logoutBtn.FlatAppearance.BorderSize = 0
        logoutBtn.FlatStyle = FlatStyle.Flat
        logoutBtn.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        logoutBtn.Image = My.Resources.Resources.logout
        logoutBtn.Location = New Point(0, 49)
        logoutBtn.Name = "logoutBtn"
        logoutBtn.Size = New Size(177, 54)
        logoutBtn.TabIndex = 6
        logoutBtn.Text = "Logout"
        logoutBtn.TextAlign = ContentAlignment.MiddleRight
        logoutBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        logoutBtn.UseVisualStyleBackColor = True
        ' 
        ' dashboardBtn
        ' 
        dashboardBtn.BackColor = Color.WhiteSmoke
        dashboardBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        dashboardBtn.FlatAppearance.BorderSize = 0
        dashboardBtn.FlatStyle = FlatStyle.Flat
        dashboardBtn.Font = New Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dashboardBtn.Image = CType(resources.GetObject("dashboardBtn.Image"), Image)
        dashboardBtn.ImageAlign = ContentAlignment.MiddleLeft
        dashboardBtn.Location = New Point(0, 151)
        dashboardBtn.Name = "dashboardBtn"
        dashboardBtn.Size = New Size(174, 56)
        dashboardBtn.TabIndex = 5
        dashboardBtn.Text = "Dashboard"
        dashboardBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        dashboardBtn.UseVisualStyleBackColor = False
        ' 
        ' LabelWelcome
        ' 
        LabelWelcome.AutoSize = True
        LabelWelcome.Font = New Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelWelcome.Location = New Point(3, 23)
        LabelWelcome.Name = "LabelWelcome"
        LabelWelcome.Size = New Size(127, 37)
        LabelWelcome.TabIndex = 4
        LabelWelcome.Text = "Welcome"
        ' 
        ' Button4
        ' 
        Button4.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.Location = New Point(0, 337)
        Button4.Name = "Button4"
        Button4.Size = New Size(174, 56)
        Button4.TabIndex = 3
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Btn3
        ' 
        Btn3.BackColor = Color.WhiteSmoke
        Btn3.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        Btn3.FlatAppearance.BorderSize = 0
        Btn3.FlatStyle = FlatStyle.Flat
        Btn3.Font = New Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn3.ImageAlign = ContentAlignment.MiddleLeft
        Btn3.Location = New Point(0, 275)
        Btn3.Name = "Btn3"
        Btn3.Size = New Size(174, 56)
        Btn3.TabIndex = 2
        Btn3.Text = "Button3"
        Btn3.TextImageRelation = TextImageRelation.ImageBeforeText
        Btn3.UseVisualStyleBackColor = False
        ' 
        ' Btn2
        ' 
        Btn2.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        Btn2.FlatAppearance.BorderSize = 0
        Btn2.FlatStyle = FlatStyle.Flat
        Btn2.Font = New Font("Palatino Linotype", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Btn2.ImageAlign = ContentAlignment.MiddleLeft
        Btn2.Location = New Point(0, 213)
        Btn2.Name = "Btn2"
        Btn2.Size = New Size(177, 56)
        Btn2.TabIndex = 1
        Btn2.Text = "Button2"
        Btn2.TextImageRelation = TextImageRelation.ImageBeforeText
        Btn2.UseVisualStyleBackColor = True
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(242), CByte(242), CByte(242))
        Panel2.Controls.Add(LabelCarwash)
        Panel2.Controls.Add(Button5)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1192, 114)
        Panel2.TabIndex = 4
        ' 
        ' LabelCarwash
        ' 
        LabelCarwash.AutoSize = True
        LabelCarwash.Font = New Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCarwash.Location = New Point(403, 23)
        LabelCarwash.Name = "LabelCarwash"
        LabelCarwash.RightToLeft = RightToLeft.No
        LabelCarwash.Size = New Size(486, 47)
        LabelCarwash.TabIndex = 0
        LabelCarwash.Text = "Carwash Management System"
        LabelCarwash.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.Location = New Point(1088, 12)
        Button5.Name = "Button5"
        Button5.Size = New Size(79, 32)
        Button5.TabIndex = 5
        Button5.Text = "Exit"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(217), CByte(217), CByte(217))
        Panel3.Controls.Add(Panel6)
        Panel3.Controls.Add(Panel1)
        Panel3.Controls.Add(MenuStrip1)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1369, 749)
        Panel3.TabIndex = 6
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Panel7)
        Panel6.Controls.Add(Panel2)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(177, 24)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1192, 725)
        Panel6.TabIndex = 3
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(Panel4)
        Panel7.Dock = DockStyle.Fill
        Panel7.Location = New Point(0, 114)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(1192, 611)
        Panel7.TabIndex = 5
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel4.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel4.Location = New Point(6, 6)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1192, 611)
        Panel4.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FIleToolStripMenuItem, ServiceTrackingToolStripMenuItem, BookingToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1369, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FIleToolStripMenuItem
        ' 
        FIleToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExitToolStripMenuItem})
        FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        FIleToolStripMenuItem.Size = New Size(37, 20)
        FIleToolStripMenuItem.Text = "FIle"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(92, 22)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' ServiceTrackingToolStripMenuItem
        ' 
        ServiceTrackingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ServiceCatalogToolStripMenuItem, CustomerInformationToolStripMenuItem, SaleHistoryToolStripMenuItem, BillingAndToolStripMenuItem})
        ServiceTrackingToolStripMenuItem.Name = "ServiceTrackingToolStripMenuItem"
        ServiceTrackingToolStripMenuItem.Size = New Size(61, 20)
        ServiceTrackingToolStripMenuItem.Text = "Services"
        ' 
        ' ServiceCatalogToolStripMenuItem
        ' 
        ServiceCatalogToolStripMenuItem.Name = "ServiceCatalogToolStripMenuItem"
        ServiceCatalogToolStripMenuItem.Size = New Size(192, 22)
        ServiceCatalogToolStripMenuItem.Text = "Service Catalog"
        ' 
        ' CustomerInformationToolStripMenuItem
        ' 
        CustomerInformationToolStripMenuItem.Name = "CustomerInformationToolStripMenuItem"
        CustomerInformationToolStripMenuItem.Size = New Size(192, 22)
        CustomerInformationToolStripMenuItem.Text = "Customer Information"
        ' 
        ' SaleHistoryToolStripMenuItem
        ' 
        SaleHistoryToolStripMenuItem.Name = "SaleHistoryToolStripMenuItem"
        SaleHistoryToolStripMenuItem.Size = New Size(192, 22)
        SaleHistoryToolStripMenuItem.Text = "Sales History"
        ' 
        ' BillingAndToolStripMenuItem
        ' 
        BillingAndToolStripMenuItem.Name = "BillingAndToolStripMenuItem"
        BillingAndToolStripMenuItem.Size = New Size(192, 22)
        BillingAndToolStripMenuItem.Text = "Billing Contracts"
        ' 
        ' BookingToolStripMenuItem
        ' 
        BookingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AppointmentScheduleToolStripMenuItem1, ListToolStripMenuItem, OnTheDayScheduleToolStripMenuItem})
        BookingToolStripMenuItem.Name = "BookingToolStripMenuItem"
        BookingToolStripMenuItem.Size = New Size(68, 20)
        BookingToolStripMenuItem.Text = "Bookings"
        ' 
        ' AppointmentScheduleToolStripMenuItem1
        ' 
        AppointmentScheduleToolStripMenuItem1.Name = "AppointmentScheduleToolStripMenuItem1"
        AppointmentScheduleToolStripMenuItem1.Size = New Size(196, 22)
        AppointmentScheduleToolStripMenuItem1.Text = "Appointment Schedule"
        ' 
        ' ListToolStripMenuItem
        ' 
        ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        ListToolStripMenuItem.Size = New Size(196, 22)
        ListToolStripMenuItem.Text = "List of Reserved"
        ' 
        ' OnTheDayScheduleToolStripMenuItem
        ' 
        OnTheDayScheduleToolStripMenuItem.Name = "OnTheDayScheduleToolStripMenuItem"
        OnTheDayScheduleToolStripMenuItem.Size = New Size(196, 22)
        OnTheDayScheduleToolStripMenuItem.Text = "On-The-Day Schedule"
        ' 
        ' Carwash
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        ClientSize = New Size(1369, 749)
        Controls.Add(Panel3)
        MainMenuStrip = MenuStrip1
        MinimizeBox = False
        MinimumSize = New Size(1385, 788)
        Name = "Carwash"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Carwash Management"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Btn3 As Button
    Friend WithEvents Btn2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelWelcome As Label
    Friend WithEvents dashboardBtn As Button
    Friend WithEvents LabelCarwash As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents logoutBtn As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents FIleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceTrackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceCatalogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaleHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BillingAndToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BookingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppointmentScheduleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnTheDayScheduleToolStripMenuItem As ToolStripMenuItem
End Class
