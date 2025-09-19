<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Panel6 = New Panel()
        Panel1 = New Panel()
        LabelTotalSalesToday = New Label()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        LabelTotalCustomerToday = New Label()
        Label4 = New Label()
        PictureBox2 = New PictureBox()
        Panel7 = New Panel()
        Panel3 = New Panel()
        LabelTotalNewContractToday = New Label()
        Label6 = New Label()
        PictureBox3 = New PictureBox()
        Panel4 = New Panel()
        LabelTotalNewScheduleToday = New Label()
        Label8 = New Label()
        PictureBox4 = New PictureBox()
        Panel5 = New Panel()
        Panel8 = New Panel()
        Panel9 = New Panel()
        PanelMontlySales1 = New Panel()
        ButtonToggleChart = New Button()
        PanelMontlySales = New Panel()
        Label10 = New Label()
        Panel11 = New Panel()
        DataGridViewActivityLog = New DataGridView()
        Label11 = New Label()
        Panel12 = New Panel()
        TextBoxSearchBar = New TextBox()
        Label9 = New Label()
        Panel13 = New Panel()
        DataGridViewLatestTransaction = New DataGridView()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        Panel9.SuspendLayout()
        PanelMontlySales1.SuspendLayout()
        Panel11.SuspendLayout()
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).BeginInit()
        Panel12.SuspendLayout()
        Panel13.SuspendLayout()
        CType(DataGridViewLatestTransaction, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel6
        ' 
        Panel6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel6.Location = New Point(550, 0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(92, 156)
        Panel6.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(LabelTotalSalesToday)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(230, 156)
        Panel1.TabIndex = 0
        ' 
        ' LabelTotalSalesToday
        ' 
        LabelTotalSalesToday.Anchor = AnchorStyles.None
        LabelTotalSalesToday.AutoSize = True
        LabelTotalSalesToday.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotalSalesToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalSalesToday.Location = New Point(28, 106)
        LabelTotalSalesToday.Name = "LabelTotalSalesToday"
        LabelTotalSalesToday.Size = New Size(0, 32)
        LabelTotalSalesToday.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label1.Location = New Point(28, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(100, 19)
        Label1.TabIndex = 1
        Label1.Text = "Sales Today"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.None
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.Location = New Point(28, 31)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(32, 34)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(LabelTotalCustomerToday)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Location = New Point(321, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(230, 156)
        Panel2.TabIndex = 3
        ' 
        ' LabelTotalCustomerToday
        ' 
        LabelTotalCustomerToday.Anchor = AnchorStyles.None
        LabelTotalCustomerToday.AutoSize = True
        LabelTotalCustomerToday.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotalCustomerToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalCustomerToday.Location = New Point(28, 106)
        LabelTotalCustomerToday.Name = "LabelTotalCustomerToday"
        LabelTotalCustomerToday.Size = New Size(0, 32)
        LabelTotalCustomerToday.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label4.Location = New Point(28, 87)
        Label4.Name = "Label4"
        Label4.Size = New Size(179, 19)
        Label4.TabIndex = 1
        Label4.Text = "New Customers Today"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.None
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.Location = New Point(28, 31)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(32, 32)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' Panel7
        ' 
        Panel7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel7.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel7.Location = New Point(870, 0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(92, 156)
        Panel7.TabIndex = 6
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(LabelTotalNewContractToday)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(PictureBox3)
        Panel3.Location = New Point(644, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(230, 156)
        Panel3.TabIndex = 4
        ' 
        ' LabelTotalNewContractToday
        ' 
        LabelTotalNewContractToday.Anchor = AnchorStyles.None
        LabelTotalNewContractToday.AutoSize = True
        LabelTotalNewContractToday.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotalNewContractToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalNewContractToday.Location = New Point(28, 106)
        LabelTotalNewContractToday.Name = "LabelTotalNewContractToday"
        LabelTotalNewContractToday.Size = New Size(0, 32)
        LabelTotalNewContractToday.TabIndex = 2
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label6.Location = New Point(28, 87)
        Label6.Name = "Label6"
        Label6.Size = New Size(172, 19)
        Label6.TabIndex = 1
        Label6.Text = "New Contracts Today"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.None
        PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), Image)
        PictureBox3.Location = New Point(28, 31)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(32, 32)
        PictureBox3.TabIndex = 1
        PictureBox3.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(LabelTotalNewScheduleToday)
        Panel4.Controls.Add(Label8)
        Panel4.Controls.Add(PictureBox4)
        Panel4.Location = New Point(961, 1)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(230, 156)
        Panel4.TabIndex = 4
        ' 
        ' LabelTotalNewScheduleToday
        ' 
        LabelTotalNewScheduleToday.Anchor = AnchorStyles.None
        LabelTotalNewScheduleToday.AutoSize = True
        LabelTotalNewScheduleToday.Font = New Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelTotalNewScheduleToday.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelTotalNewScheduleToday.Location = New Point(28, 106)
        LabelTotalNewScheduleToday.Name = "LabelTotalNewScheduleToday"
        LabelTotalNewScheduleToday.Size = New Size(0, 32)
        LabelTotalNewScheduleToday.TabIndex = 2
        ' 
        ' Label8
        ' 
        Label8.Anchor = AnchorStyles.None
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label8.Location = New Point(28, 87)
        Label8.Name = "Label8"
        Label8.Size = New Size(173, 19)
        Label8.TabIndex = 1
        Label8.Text = "New Schedule Today"
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.None
        PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), Image)
        PictureBox4.Location = New Point(28, 31)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(31, 33)
        PictureBox4.TabIndex = 1
        PictureBox4.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(Panel4)
        Panel5.Controls.Add(Panel3)
        Panel5.Controls.Add(Panel7)
        Panel5.Controls.Add(Panel6)
        Panel5.Controls.Add(Panel2)
        Panel5.Controls.Add(Panel1)
        Panel5.Controls.Add(Panel8)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(0, 0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1192, 156)
        Panel5.TabIndex = 5
        ' 
        ' Panel8
        ' 
        Panel8.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Panel8.Location = New Point(229, 0)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(93, 156)
        Panel8.TabIndex = 7
        ' 
        ' Panel9
        ' 
        Panel9.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel9.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel9.Controls.Add(PanelMontlySales1)
        Panel9.Controls.Add(Panel11)
        Panel9.Location = New Point(0, 184)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(1192, 351)
        Panel9.TabIndex = 6
        ' 
        ' PanelMontlySales1
        ' 
        PanelMontlySales1.Anchor = AnchorStyles.Top
        PanelMontlySales1.BackColor = Color.White
        PanelMontlySales1.Controls.Add(ButtonToggleChart)
        PanelMontlySales1.Controls.Add(PanelMontlySales)
        PanelMontlySales1.Controls.Add(Label10)
        PanelMontlySales1.Location = New Point(0, 0)
        PanelMontlySales1.Name = "PanelMontlySales1"
        PanelMontlySales1.Size = New Size(551, 351)
        PanelMontlySales1.TabIndex = 7
        ' 
        ' ButtonToggleChart
        ' 
        ButtonToggleChart.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonToggleChart.Location = New Point(408, 3)
        ButtonToggleChart.Name = "ButtonToggleChart"
        ButtonToggleChart.Size = New Size(140, 27)
        ButtonToggleChart.TabIndex = 9
        ButtonToggleChart.Text = "Monthly Sales"
        ButtonToggleChart.UseVisualStyleBackColor = True
        ' 
        ' PanelMontlySales
        ' 
        PanelMontlySales.BackColor = Color.White
        PanelMontlySales.Location = New Point(0, 32)
        PanelMontlySales.Name = "PanelMontlySales"
        PanelMontlySales.Size = New Size(551, 319)
        PanelMontlySales.TabIndex = 5
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label10.Location = New Point(28, 11)
        Label10.Name = "Label10"
        Label10.Size = New Size(122, 19)
        Label10.TabIndex = 4
        Label10.Text = "Sales Analytics"
        ' 
        ' Panel11
        ' 
        Panel11.Anchor = AnchorStyles.Top
        Panel11.BackColor = Color.White
        Panel11.Controls.Add(DataGridViewActivityLog)
        Panel11.Controls.Add(Label11)
        Panel11.Location = New Point(644, 0)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(548, 351)
        Panel11.TabIndex = 8
        ' 
        ' DataGridViewActivityLog
        ' 
        DataGridViewActivityLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewActivityLog.BackgroundColor = Color.White
        DataGridViewActivityLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewActivityLog.Location = New Point(3, 33)
        DataGridViewActivityLog.Name = "DataGridViewActivityLog"
        DataGridViewActivityLog.Size = New Size(545, 319)
        DataGridViewActivityLog.TabIndex = 6
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label11.Location = New Point(28, 11)
        Label11.Name = "Label11"
        Label11.Size = New Size(97, 19)
        Label11.TabIndex = 5
        Label11.Text = "Acitivty Log"
        ' 
        ' Panel12
        ' 
        Panel12.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Panel12.BackColor = Color.White
        Panel12.Controls.Add(TextBoxSearchBar)
        Panel12.Controls.Add(Label9)
        Panel12.Controls.Add(Panel13)
        Panel12.Location = New Point(0, 567)
        Panel12.Name = "Panel12"
        Panel12.Size = New Size(1192, 113)
        Panel12.TabIndex = 7
        ' 
        ' TextBoxSearchBar
        ' 
        TextBoxSearchBar.Font = New Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBoxSearchBar.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        TextBoxSearchBar.Location = New Point(231, 8)
        TextBoxSearchBar.Name = "TextBoxSearchBar"
        TextBoxSearchBar.Size = New Size(172, 23)
        TextBoxSearchBar.TabIndex = 4
        TextBoxSearchBar.Text = "Search"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label9.Location = New Point(28, 4)
        Label9.Name = "Label9"
        Label9.Size = New Size(197, 25)
        Label9.TabIndex = 3
        Label9.Text = "Latest  Transaction"
        ' 
        ' Panel13
        ' 
        Panel13.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel13.Controls.Add(DataGridViewLatestTransaction)
        Panel13.Location = New Point(0, 34)
        Panel13.Name = "Panel13"
        Panel13.Size = New Size(1192, 79)
        Panel13.TabIndex = 0
        ' 
        ' DataGridViewLatestTransaction
        ' 
        DataGridViewLatestTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewLatestTransaction.BackgroundColor = Color.White
        DataGridViewLatestTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewLatestTransaction.Dock = DockStyle.Fill
        DataGridViewLatestTransaction.Location = New Point(0, 0)
        DataGridViewLatestTransaction.Name = "DataGridViewLatestTransaction"
        DataGridViewLatestTransaction.Size = New Size(1192, 79)
        DataGridViewLatestTransaction.TabIndex = 0
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(1192, 680)
        Controls.Add(Panel12)
        Controls.Add(Panel9)
        Controls.Add(Panel5)
        FormBorderStyle = FormBorderStyle.None
        Name = "Dashboard"
        Text = "Dashboard"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        PanelMontlySales1.ResumeLayout(False)
        PanelMontlySales1.PerformLayout()
        Panel11.ResumeLayout(False)
        Panel11.PerformLayout()
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).EndInit()
        Panel12.ResumeLayout(False)
        Panel12.PerformLayout()
        Panel13.ResumeLayout(False)
        CType(DataGridViewLatestTransaction, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelTotalSalesToday As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelTotalCustomerToday As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelTotalNewContractToday As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelTotalNewScheduleToday As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents PanelMontlySales1 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents DataGridViewLatestTransaction As DataGridView
    Friend WithEvents TextBoxSearchBar As TextBox
    Friend WithEvents ButtonToggleChart As Button
    Friend WithEvents PanelMontlySales As Panel
    Friend WithEvents DataGridViewActivityLog As DataGridView
End Class
