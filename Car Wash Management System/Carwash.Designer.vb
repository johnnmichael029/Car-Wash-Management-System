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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Carwash))
        PanelMenuBar = New Panel()
        MenuBtn = New Button()
        Panel5 = New Panel()
        LogoutBtn = New Button()
        DashboardBtn = New Button()
        Button4 = New Button()
        Btn3 = New Button()
        Btn2 = New Button()
        Panel2 = New Panel()
        Panel1 = New Panel()
        Panel8 = New Panel()
        NotificationLabel = New Label()
        NotificationBtn = New Button()
        Label1 = New Label()
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
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        NotificationTimer = New Timer(components)
        PanelMenuBar.SuspendLayout()
        Panel5.SuspendLayout()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        Panel8.SuspendLayout()
        Panel3.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PanelMenuBar
        ' 
        PanelMenuBar.BackColor = Color.White
        PanelMenuBar.Controls.Add(MenuBtn)
        PanelMenuBar.Controls.Add(Panel5)
        PanelMenuBar.Controls.Add(DashboardBtn)
        PanelMenuBar.Controls.Add(Button4)
        PanelMenuBar.Controls.Add(Btn3)
        PanelMenuBar.Controls.Add(Btn2)
        PanelMenuBar.Dock = DockStyle.Left
        PanelMenuBar.Location = New Point(0, 24)
        PanelMenuBar.Name = "PanelMenuBar"
        PanelMenuBar.Size = New Size(177, 725)
        PanelMenuBar.TabIndex = 2
        ' 
        ' MenuBtn
        ' 
        MenuBtn.FlatAppearance.BorderSize = 0
        MenuBtn.FlatStyle = FlatStyle.Flat
        MenuBtn.ForeColor = SystemColors.ActiveCaption
        MenuBtn.Image = My.Resources.Resources.menu
        MenuBtn.Location = New Point(3, 3)
        MenuBtn.Name = "MenuBtn"
        MenuBtn.Size = New Size(47, 46)
        MenuBtn.TabIndex = 8
        MenuBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(LogoutBtn)
        Panel5.Dock = DockStyle.Bottom
        Panel5.Location = New Point(0, 572)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(177, 153)
        Panel5.TabIndex = 7
        ' 
        ' LogoutBtn
        ' 
        LogoutBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        LogoutBtn.FlatAppearance.BorderSize = 0
        LogoutBtn.FlatStyle = FlatStyle.Flat
        LogoutBtn.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LogoutBtn.Image = My.Resources.Resources.logout
        LogoutBtn.ImageAlign = ContentAlignment.MiddleLeft
        LogoutBtn.Location = New Point(0, 49)
        LogoutBtn.Name = "LogoutBtn"
        LogoutBtn.Padding = New Padding(10, 0, 0, 0)
        LogoutBtn.Size = New Size(177, 54)
        LogoutBtn.TabIndex = 6
        LogoutBtn.Text = "Logout"
        LogoutBtn.UseVisualStyleBackColor = True
        ' 
        ' DashboardBtn
        ' 
        DashboardBtn.BackColor = Color.White
        DashboardBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        DashboardBtn.FlatAppearance.BorderSize = 0
        DashboardBtn.FlatStyle = FlatStyle.Flat
        DashboardBtn.Font = New Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DashboardBtn.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        DashboardBtn.Image = CType(resources.GetObject("DashboardBtn.Image"), Image)
        DashboardBtn.ImageAlign = ContentAlignment.MiddleLeft
        DashboardBtn.Location = New Point(0, 151)
        DashboardBtn.Name = "DashboardBtn"
        DashboardBtn.Padding = New Padding(5, 0, 5, 0)
        DashboardBtn.Size = New Size(174, 56)
        DashboardBtn.TabIndex = 5
        DashboardBtn.Text = "Dashboard"
        DashboardBtn.TextAlign = ContentAlignment.MiddleRight
        DashboardBtn.UseVisualStyleBackColor = False
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
        Btn3.BackColor = Color.White
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
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(Panel1)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(LabelCarwash)
        Panel2.Controls.Add(Button5)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1192, 45)
        Panel2.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel8)
        Panel1.Controls.Add(NotificationBtn)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(992, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 45)
        Panel1.TabIndex = 9
        ' 
        ' Panel8
        ' 
        Panel8.Controls.Add(NotificationLabel)
        Panel8.Dock = DockStyle.Fill
        Panel8.Location = New Point(0, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(149, 45)
        Panel8.TabIndex = 10
        ' 
        ' NotificationLabel
        ' 
        NotificationLabel.Dock = DockStyle.Right
        NotificationLabel.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NotificationLabel.Location = New Point(0, 0)
        NotificationLabel.Name = "NotificationLabel"
        NotificationLabel.Size = New Size(149, 45)
        NotificationLabel.TabIndex = 7
        NotificationLabel.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' NotificationBtn
        ' 
        NotificationBtn.Dock = DockStyle.Right
        NotificationBtn.FlatAppearance.BorderSize = 0
        NotificationBtn.FlatStyle = FlatStyle.Flat
        NotificationBtn.Image = My.Resources.Resources.bell1
        NotificationBtn.Location = New Point(149, 0)
        NotificationBtn.Name = "NotificationBtn"
        NotificationBtn.Size = New Size(51, 45)
        NotificationBtn.TabIndex = 8
        NotificationBtn.Text = CStr(ChrW(127))
        NotificationBtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Gray
        Label1.Location = New Point(3, -2)
        Label1.Name = "Label1"
        Label1.Size = New Size(26, 20)
        Label1.TabIndex = 6
        Label1.Text = "Hi!"
        ' 
        ' LabelCarwash
        ' 
        LabelCarwash.AutoSize = True
        LabelCarwash.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelCarwash.Location = New Point(0, 16)
        LabelCarwash.Name = "LabelCarwash"
        LabelCarwash.RightToLeft = RightToLeft.No
        LabelCarwash.Size = New Size(237, 25)
        LabelCarwash.TabIndex = 0
        LabelCarwash.Text = "Welcome to Sandigan"
        LabelCarwash.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button5.Location = New Point(662, 5)
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
        Panel3.Controls.Add(PanelMenuBar)
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
        Panel7.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel7.Controls.Add(Panel4)
        Panel7.Dock = DockStyle.Fill
        Panel7.Location = New Point(0, 45)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(1192, 680)
        Panel7.TabIndex = 5
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel4.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel4.Location = New Point(8, 6)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1174, 674)
        Panel4.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
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
        FIleToolStripMenuItem.Font = New Font("Century Gothic", 8.25F, FontStyle.Bold)
        FIleToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        FIleToolStripMenuItem.Size = New Size(37, 20)
        FIleToolStripMenuItem.Text = "&FIle"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(92, 22)
        ExitToolStripMenuItem.Text = "E&xit"
        ' 
        ' ServiceTrackingToolStripMenuItem
        ' 
        ServiceTrackingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ServiceCatalogToolStripMenuItem, CustomerInformationToolStripMenuItem, SaleHistoryToolStripMenuItem, BillingAndToolStripMenuItem})
        ServiceTrackingToolStripMenuItem.Font = New Font("Century Gothic", 8.25F, FontStyle.Bold)
        ServiceTrackingToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        ServiceTrackingToolStripMenuItem.Name = "ServiceTrackingToolStripMenuItem"
        ServiceTrackingToolStripMenuItem.Size = New Size(64, 20)
        ServiceTrackingToolStripMenuItem.Text = "&Services"
        ' 
        ' ServiceCatalogToolStripMenuItem
        ' 
        ServiceCatalogToolStripMenuItem.Name = "ServiceCatalogToolStripMenuItem"
        ServiceCatalogToolStripMenuItem.Size = New Size(186, 22)
        ServiceCatalogToolStripMenuItem.Text = "&Service Catalog"
        ' 
        ' CustomerInformationToolStripMenuItem
        ' 
        CustomerInformationToolStripMenuItem.Name = "CustomerInformationToolStripMenuItem"
        CustomerInformationToolStripMenuItem.Size = New Size(186, 22)
        CustomerInformationToolStripMenuItem.Text = "&Customer Information"
        ' 
        ' SaleHistoryToolStripMenuItem
        ' 
        SaleHistoryToolStripMenuItem.Name = "SaleHistoryToolStripMenuItem"
        SaleHistoryToolStripMenuItem.Size = New Size(186, 22)
        SaleHistoryToolStripMenuItem.Text = "Sales &History"
        ' 
        ' BillingAndToolStripMenuItem
        ' 
        BillingAndToolStripMenuItem.Name = "BillingAndToolStripMenuItem"
        BillingAndToolStripMenuItem.Size = New Size(186, 22)
        BillingAndToolStripMenuItem.Text = "&Billing Contracts"
        ' 
        ' BookingToolStripMenuItem
        ' 
        BookingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AppointmentScheduleToolStripMenuItem1, ListToolStripMenuItem, OnTheDayScheduleToolStripMenuItem})
        BookingToolStripMenuItem.Font = New Font("Century Gothic", 8.25F, FontStyle.Bold)
        BookingToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        BookingToolStripMenuItem.Name = "BookingToolStripMenuItem"
        BookingToolStripMenuItem.Size = New Size(68, 20)
        BookingToolStripMenuItem.Text = "&Bookings"
        ' 
        ' AppointmentScheduleToolStripMenuItem1
        ' 
        AppointmentScheduleToolStripMenuItem1.Name = "AppointmentScheduleToolStripMenuItem1"
        AppointmentScheduleToolStripMenuItem1.Size = New Size(196, 22)
        AppointmentScheduleToolStripMenuItem1.Text = "&Appointment Schedule"
        ' 
        ' ListToolStripMenuItem
        ' 
        ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        ListToolStripMenuItem.Size = New Size(196, 22)
        ListToolStripMenuItem.Text = "&List of Reserved"
        ' 
        ' OnTheDayScheduleToolStripMenuItem
        ' 
        OnTheDayScheduleToolStripMenuItem.Name = "OnTheDayScheduleToolStripMenuItem"
        OnTheDayScheduleToolStripMenuItem.Size = New Size(196, 22)
        OnTheDayScheduleToolStripMenuItem.Text = "&On-The-Day Schedule"
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 1
        ' 
        ' Timer2
        ' 
        Timer2.Interval = 1
        ' 
        ' NotificationTimer
        ' 
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
        PanelMenuBar.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents PanelMenuBar As Panel
    Friend WithEvents Button4 As Button
    Friend WithEvents Btn3 As Button
    Friend WithEvents Btn2 As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents DashboardBtn As Button
    Friend WithEvents LabelCarwash As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LogoutBtn As Button
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents MenuBtn As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents NotificationLabel As Label
    Friend WithEvents NotificationBtn As Button
    Friend WithEvents NotificationTimer As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel8 As Panel
End Class
