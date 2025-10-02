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
        Panel2 = New Panel()
        LabelWelcome = New Label()
        PictureBox1 = New PictureBox()
        Panel7 = New Panel()
        LabelTotalSalesToday = New Label()
        Label2 = New Label()
        PictureBoxSales = New PictureBox()
        Panel1 = New Panel()
        Panel8 = New Panel()
        NotificationLabel = New Label()
        NotificationBtn = New Button()
        MenuBtn = New Button()
        Panel11 = New Panel()
        LabelNewCustomer = New Label()
        PictureBoxCustomer = New PictureBox()
        Label4 = New Label()
        Panel9 = New Panel()
        LabelTotalNewScheduleToday = New Label()
        PictureBoxSchedule = New PictureBox()
        Label8 = New Label()
        Panel10 = New Panel()
        PictureBoxContracts = New PictureBox()
        LabelTotalNewContractToday = New Label()
        Label6 = New Label()
        Label3 = New Label()
        Panel6 = New Panel()
        PanelMenuBar = New Panel()
        Panel5 = New Panel()
        LogoutBtn = New Button()
        DashboardBtn = New Button()
        Button4 = New Button()
        Btn3 = New Button()
        ActivityLogBtn = New Button()
        Panel3 = New Panel()
        Panel4 = New Panel()
        MenuStrip1 = New MenuStrip()
        FIleToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        SettingsToolStripMenuItem = New ToolStripMenuItem()
        ChangePasswordToolStripMenuItem = New ToolStripMenuItem()
        AdminToolStripMenuItem = New ToolStripMenuItem()
        ServiceTrackingToolStripMenuItem = New ToolStripMenuItem()
        ServiceCatalogToolStripMenuItem = New ToolStripMenuItem()
        CustomerInformationToolStripMenuItem = New ToolStripMenuItem()
        SaleHistoryToolStripMenuItem = New ToolStripMenuItem()
        ContractsToolStripMenuItem = New ToolStripMenuItem()
        PickUpToolStripMenuItem = New ToolStripMenuItem()
        BookingToolStripMenuItem = New ToolStripMenuItem()
        AppointmentScheduleToolStripMenuItem1 = New ToolStripMenuItem()
        ListToolStripMenuItem = New ToolStripMenuItem()
        OnTheDayScheduleToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem1 = New ToolStripMenuItem()
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        NotificationTimer = New Timer(components)
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel7.SuspendLayout()
        CType(PictureBoxSales, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel8.SuspendLayout()
        Panel11.SuspendLayout()
        CType(PictureBoxCustomer, ComponentModel.ISupportInitialize).BeginInit()
        Panel9.SuspendLayout()
        CType(PictureBoxSchedule, ComponentModel.ISupportInitialize).BeginInit()
        Panel10.SuspendLayout()
        CType(PictureBoxContracts, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        PanelMenuBar.SuspendLayout()
        Panel5.SuspendLayout()
        Panel3.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(LabelWelcome)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Controls.Add(Panel7)
        Panel2.Controls.Add(Panel1)
        Panel2.Controls.Add(MenuBtn)
        Panel2.Controls.Add(Panel11)
        Panel2.Controls.Add(Panel9)
        Panel2.Controls.Add(Panel10)
        Panel2.Controls.Add(Label3)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1385, 45)
        Panel2.TabIndex = 4
        ' 
        ' LabelWelcome
        ' 
        LabelWelcome.AutoSize = True
        LabelWelcome.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelWelcome.Location = New Point(131, 0)
        LabelWelcome.Name = "LabelWelcome"
        LabelWelcome.RightToLeft = RightToLeft.No
        LabelWelcome.Size = New Size(0, 20)
        LabelWelcome.TabIndex = 1
        LabelWelcome.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(53, 19)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(132, 20)
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' Panel7
        ' 
        Panel7.Anchor = AnchorStyles.Top
        Panel7.BackColor = Color.White
        Panel7.Controls.Add(LabelTotalSalesToday)
        Panel7.Controls.Add(Label2)
        Panel7.Controls.Add(PictureBoxSales)
        Panel7.Location = New Point(271, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(173, 44)
        Panel7.TabIndex = 10
        ' 
        ' LabelTotalSalesToday
        ' 
        LabelTotalSalesToday.Anchor = AnchorStyles.None
        LabelTotalSalesToday.AutoSize = True
        LabelTotalSalesToday.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotalSalesToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalSalesToday.Location = New Point(36, 19)
        LabelTotalSalesToday.Name = "LabelTotalSalesToday"
        LabelTotalSalesToday.Size = New Size(0, 24)
        LabelTotalSalesToday.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label2.Location = New Point(38, 4)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 16)
        Label2.TabIndex = 1
        Label2.Text = "Sales Today"
        ' 
        ' PictureBoxSales
        ' 
        PictureBoxSales.Anchor = AnchorStyles.None
        PictureBoxSales.BackgroundImage = CType(resources.GetObject("PictureBoxSales.BackgroundImage"), Image)
        PictureBoxSales.Location = New Point(3, 6)
        PictureBoxSales.Name = "PictureBoxSales"
        PictureBoxSales.Size = New Size(32, 34)
        PictureBoxSales.TabIndex = 1
        PictureBoxSales.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel8)
        Panel1.Controls.Add(NotificationBtn)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(1185, 0)
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
        NotificationLabel.Font = New Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        NotificationLabel.ForeColor = SystemColors.ControlText
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
        ' MenuBtn
        ' 
        MenuBtn.FlatAppearance.BorderSize = 0
        MenuBtn.FlatStyle = FlatStyle.Flat
        MenuBtn.ForeColor = SystemColors.ActiveCaption
        MenuBtn.Image = My.Resources.Resources.menu
        MenuBtn.Location = New Point(3, 0)
        MenuBtn.Name = "MenuBtn"
        MenuBtn.Size = New Size(47, 46)
        MenuBtn.TabIndex = 8
        MenuBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel11
        ' 
        Panel11.Anchor = AnchorStyles.Top
        Panel11.BackColor = Color.White
        Panel11.Controls.Add(LabelNewCustomer)
        Panel11.Controls.Add(PictureBoxCustomer)
        Panel11.Controls.Add(Label4)
        Panel11.Location = New Point(479, 0)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(173, 44)
        Panel11.TabIndex = 5
        ' 
        ' LabelNewCustomer
        ' 
        LabelNewCustomer.Anchor = AnchorStyles.None
        LabelNewCustomer.AutoSize = True
        LabelNewCustomer.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold)
        LabelNewCustomer.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelNewCustomer.Location = New Point(36, 19)
        LabelNewCustomer.Name = "LabelNewCustomer"
        LabelNewCustomer.Size = New Size(0, 24)
        LabelNewCustomer.TabIndex = 3
        ' 
        ' PictureBoxCustomer
        ' 
        PictureBoxCustomer.Anchor = AnchorStyles.None
        PictureBoxCustomer.BackgroundImage = CType(resources.GetObject("PictureBoxCustomer.BackgroundImage"), Image)
        PictureBoxCustomer.Location = New Point(3, 6)
        PictureBoxCustomer.Name = "PictureBoxCustomer"
        PictureBoxCustomer.Size = New Size(32, 34)
        PictureBoxCustomer.TabIndex = 1
        PictureBoxCustomer.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label4.Location = New Point(38, 4)
        Label4.Name = "Label4"
        Label4.Size = New Size(114, 16)
        Label4.TabIndex = 1
        Label4.Text = "New Customers"
        ' 
        ' Panel9
        ' 
        Panel9.Anchor = AnchorStyles.Top
        Panel9.BackColor = Color.White
        Panel9.Controls.Add(LabelTotalNewScheduleToday)
        Panel9.Controls.Add(PictureBoxSchedule)
        Panel9.Controls.Add(Label8)
        Panel9.Location = New Point(904, 0)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(173, 44)
        Panel9.TabIndex = 7
        ' 
        ' LabelTotalNewScheduleToday
        ' 
        LabelTotalNewScheduleToday.Anchor = AnchorStyles.None
        LabelTotalNewScheduleToday.AutoSize = True
        LabelTotalNewScheduleToday.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold)
        LabelTotalNewScheduleToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalNewScheduleToday.Location = New Point(36, 19)
        LabelTotalNewScheduleToday.Name = "LabelTotalNewScheduleToday"
        LabelTotalNewScheduleToday.Size = New Size(0, 24)
        LabelTotalNewScheduleToday.TabIndex = 2
        ' 
        ' PictureBoxSchedule
        ' 
        PictureBoxSchedule.Anchor = AnchorStyles.None
        PictureBoxSchedule.BackgroundImage = CType(resources.GetObject("PictureBoxSchedule.BackgroundImage"), Image)
        PictureBoxSchedule.Location = New Point(3, 6)
        PictureBoxSchedule.Name = "PictureBoxSchedule"
        PictureBoxSchedule.Size = New Size(31, 33)
        PictureBoxSchedule.TabIndex = 1
        PictureBoxSchedule.TabStop = False
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold)
        Label8.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label8.Location = New Point(38, 4)
        Label8.Name = "Label8"
        Label8.Size = New Size(106, 16)
        Label8.TabIndex = 1
        Label8.Text = "New Schedule"
        ' 
        ' Panel10
        ' 
        Panel10.Anchor = AnchorStyles.Top
        Panel10.BackColor = Color.White
        Panel10.Controls.Add(PictureBoxContracts)
        Panel10.Controls.Add(LabelTotalNewContractToday)
        Panel10.Controls.Add(Label6)
        Panel10.Location = New Point(691, 0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(173, 44)
        Panel10.TabIndex = 6
        ' 
        ' PictureBoxContracts
        ' 
        PictureBoxContracts.Anchor = AnchorStyles.None
        PictureBoxContracts.BackgroundImage = CType(resources.GetObject("PictureBoxContracts.BackgroundImage"), Image)
        PictureBoxContracts.Location = New Point(3, 6)
        PictureBoxContracts.Name = "PictureBoxContracts"
        PictureBoxContracts.Size = New Size(32, 32)
        PictureBoxContracts.TabIndex = 1
        PictureBoxContracts.TabStop = False
        ' 
        ' LabelTotalNewContractToday
        ' 
        LabelTotalNewContractToday.Anchor = AnchorStyles.None
        LabelTotalNewContractToday.AutoSize = True
        LabelTotalNewContractToday.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold)
        LabelTotalNewContractToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalNewContractToday.Location = New Point(36, 19)
        LabelTotalNewContractToday.Name = "LabelTotalNewContractToday"
        LabelTotalNewContractToday.Size = New Size(0, 24)
        LabelTotalNewContractToday.TabIndex = 2
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Font = New Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold)
        Label6.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label6.Location = New Point(38, 4)
        Label6.Name = "Label6"
        Label6.Size = New Size(106, 16)
        Label6.TabIndex = 1
        Label6.Text = "New Contracts"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(49, 1)
        Label3.Name = "Label3"
        Label3.RightToLeft = RightToLeft.No
        Label3.Size = New Size(87, 20)
        Label3.TabIndex = 0
        Label3.Text = "Welcome,"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(PanelMenuBar)
        Panel6.Controls.Add(Panel3)
        Panel6.Controls.Add(Panel2)
        Panel6.Dock = DockStyle.Fill
        Panel6.Location = New Point(0, 32)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1385, 756)
        Panel6.TabIndex = 3
        ' 
        ' PanelMenuBar
        ' 
        PanelMenuBar.BackColor = Color.White
        PanelMenuBar.Controls.Add(Panel5)
        PanelMenuBar.Controls.Add(DashboardBtn)
        PanelMenuBar.Controls.Add(Button4)
        PanelMenuBar.Controls.Add(Btn3)
        PanelMenuBar.Controls.Add(ActivityLogBtn)
        PanelMenuBar.Dock = DockStyle.Left
        PanelMenuBar.Location = New Point(0, 45)
        PanelMenuBar.Name = "PanelMenuBar"
        PanelMenuBar.Size = New Size(177, 711)
        PanelMenuBar.TabIndex = 2
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        Panel5.Controls.Add(LogoutBtn)
        Panel5.Location = New Point(0, 558)
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
        DashboardBtn.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
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
        ' ActivityLogBtn
        ' 
        ActivityLogBtn.FlatAppearance.BorderColor = Color.FromArgb(CByte(238), CByte(238), CByte(238))
        ActivityLogBtn.FlatAppearance.BorderSize = 0
        ActivityLogBtn.FlatStyle = FlatStyle.Flat
        ActivityLogBtn.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ActivityLogBtn.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        ActivityLogBtn.Image = My.Resources.Resources.restore
        ActivityLogBtn.ImageAlign = ContentAlignment.MiddleLeft
        ActivityLogBtn.Location = New Point(0, 213)
        ActivityLogBtn.Name = "ActivityLogBtn"
        ActivityLogBtn.Padding = New Padding(5, 0, 5, 0)
        ActivityLogBtn.Size = New Size(177, 56)
        ActivityLogBtn.TabIndex = 1
        ActivityLogBtn.Text = "Activity Log"
        ActivityLogBtn.TextAlign = ContentAlignment.MiddleRight
        ActivityLogBtn.UseVisualStyleBackColor = True
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(183, 51)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1202, 705)
        Panel3.TabIndex = 6
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1202, 705)
        Panel4.TabIndex = 0
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
        MenuStrip1.Items.AddRange(New ToolStripItem() {FIleToolStripMenuItem, ServiceTrackingToolStripMenuItem, BookingToolStripMenuItem, ExitToolStripMenuItem1})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1385, 32)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FIleToolStripMenuItem
        ' 
        FIleToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ExitToolStripMenuItem, SettingsToolStripMenuItem, AdminToolStripMenuItem})
        FIleToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FIleToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        FIleToolStripMenuItem.Size = New Size(36, 28)
        FIleToolStripMenuItem.Text = "&FIle"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(180, 22)
        ExitToolStripMenuItem.Text = "E&xit"
        ' 
        ' SettingsToolStripMenuItem
        ' 
        SettingsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ChangePasswordToolStripMenuItem})
        SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        SettingsToolStripMenuItem.Size = New Size(180, 22)
        SettingsToolStripMenuItem.Text = "Settings"
        ' 
        ' ChangePasswordToolStripMenuItem
        ' 
        ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        ChangePasswordToolStripMenuItem.Size = New Size(160, 22)
        ChangePasswordToolStripMenuItem.Text = "Change Password"
        ' 
        ' AdminToolStripMenuItem
        ' 
        AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        AdminToolStripMenuItem.Size = New Size(180, 22)
        AdminToolStripMenuItem.Text = "Admin"
        ' 
        ' ServiceTrackingToolStripMenuItem
        ' 
        ServiceTrackingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ServiceCatalogToolStripMenuItem, CustomerInformationToolStripMenuItem, SaleHistoryToolStripMenuItem, ContractsToolStripMenuItem, PickUpToolStripMenuItem})
        ServiceTrackingToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ServiceTrackingToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        ServiceTrackingToolStripMenuItem.Name = "ServiceTrackingToolStripMenuItem"
        ServiceTrackingToolStripMenuItem.Size = New Size(60, 28)
        ServiceTrackingToolStripMenuItem.Text = "&Services"
        ' 
        ' ServiceCatalogToolStripMenuItem
        ' 
        ServiceCatalogToolStripMenuItem.Name = "ServiceCatalogToolStripMenuItem"
        ServiceCatalogToolStripMenuItem.Size = New Size(180, 22)
        ServiceCatalogToolStripMenuItem.Text = "&Service Catalog"
        ' 
        ' CustomerInformationToolStripMenuItem
        ' 
        CustomerInformationToolStripMenuItem.Name = "CustomerInformationToolStripMenuItem"
        CustomerInformationToolStripMenuItem.Size = New Size(180, 22)
        CustomerInformationToolStripMenuItem.Text = "Customer &Information"
        ' 
        ' SaleHistoryToolStripMenuItem
        ' 
        SaleHistoryToolStripMenuItem.Name = "SaleHistoryToolStripMenuItem"
        SaleHistoryToolStripMenuItem.Size = New Size(180, 22)
        SaleHistoryToolStripMenuItem.Text = "Sales &History"
        ' 
        ' ContractsToolStripMenuItem
        ' 
        ContractsToolStripMenuItem.Name = "ContractsToolStripMenuItem"
        ContractsToolStripMenuItem.Size = New Size(180, 22)
        ContractsToolStripMenuItem.Text = "&Contracts"
        ' 
        ' PickUpToolStripMenuItem
        ' 
        PickUpToolStripMenuItem.Name = "PickUpToolStripMenuItem"
        PickUpToolStripMenuItem.Size = New Size(180, 22)
        PickUpToolStripMenuItem.Text = "Pick Up"
        ' 
        ' BookingToolStripMenuItem
        ' 
        BookingToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AppointmentScheduleToolStripMenuItem1, ListToolStripMenuItem, OnTheDayScheduleToolStripMenuItem})
        BookingToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        BookingToolStripMenuItem.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        BookingToolStripMenuItem.Name = "BookingToolStripMenuItem"
        BookingToolStripMenuItem.Size = New Size(63, 28)
        BookingToolStripMenuItem.Text = "&Bookings"
        ' 
        ' AppointmentScheduleToolStripMenuItem1
        ' 
        AppointmentScheduleToolStripMenuItem1.Name = "AppointmentScheduleToolStripMenuItem1"
        AppointmentScheduleToolStripMenuItem1.Size = New Size(181, 22)
        AppointmentScheduleToolStripMenuItem1.Text = "&Appointment Schedule"
        ' 
        ' ListToolStripMenuItem
        ' 
        ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        ListToolStripMenuItem.Size = New Size(181, 22)
        ListToolStripMenuItem.Text = "&List of Reserved"
        ' 
        ' OnTheDayScheduleToolStripMenuItem
        ' 
        OnTheDayScheduleToolStripMenuItem.Name = "OnTheDayScheduleToolStripMenuItem"
        OnTheDayScheduleToolStripMenuItem.Size = New Size(181, 22)
        OnTheDayScheduleToolStripMenuItem.Text = "&On-The-Day Schedule"
        ' 
        ' ExitToolStripMenuItem1
        ' 
        ExitToolStripMenuItem1.Alignment = ToolStripItemAlignment.Right
        ExitToolStripMenuItem1.Image = CType(resources.GetObject("ExitToolStripMenuItem1.Image"), Image)
        ExitToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None
        ExitToolStripMenuItem1.Margin = New Padding(0, 0, 9, 0)
        ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        ExitToolStripMenuItem1.Size = New Size(36, 28)
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
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(1385, 788)
        Controls.Add(Panel6)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        MinimizeBox = False
        MinimumSize = New Size(1385, 788)
        Name = "Carwash"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Carwash Management"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        CType(PictureBoxSales, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel8.ResumeLayout(False)
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        CType(PictureBoxCustomer, ComponentModel.ISupportInitialize).EndInit()
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        CType(PictureBoxSchedule, ComponentModel.ISupportInitialize).EndInit()
        Panel10.ResumeLayout(False)
        Panel10.PerformLayout()
        CType(PictureBoxContracts, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        PanelMenuBar.ResumeLayout(False)
        Panel5.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Panel6 As Panel
    Friend WithEvents FIleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceTrackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ServiceCatalogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerInformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaleHistoryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContractsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BookingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AppointmentScheduleToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OnTheDayScheduleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents NotificationLabel As Label
    Friend WithEvents NotificationBtn As Button
    Friend WithEvents NotificationTimer As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents PanelMenuBar As Panel
    Friend WithEvents MenuBtn As Button
    Friend WithEvents Panel5 As Panel
    Friend WithEvents LogoutBtn As Button
    Friend WithEvents DashboardBtn As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Btn3 As Button
    Friend WithEvents ActivityLogBtn As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ExitToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LabelTotalSalesToday As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBoxSales As PictureBox
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents LabelTotalNewScheduleToday As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBoxSchedule As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LabelTotalNewContractToday As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBoxContracts As PictureBox
    Friend WithEvents PictureBoxCustomer As PictureBox
    Friend WithEvents LabelNewCustomer As Label
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PickUpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelWelcome As Label
End Class
