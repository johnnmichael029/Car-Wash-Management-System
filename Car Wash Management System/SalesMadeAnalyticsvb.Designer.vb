<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesMadeAnalyticsvb
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
        Panel10 = New Panel()
        Panel2 = New Panel()
        PictureBoxUpService = New PictureBox()
        LabelServicePeriod = New Label()
        LabelPercentageService = New Label()
        LabelOrders = New Label()
        LabelServiceValue = New Label()
        Label2 = New Label()
        PictureBoxDownService = New PictureBox()
        PanelChartCustomers = New Panel()
        Panel3 = New Panel()
        PictureBoxUpCustomers = New PictureBox()
        PictureBoxDownCustomers = New PictureBox()
        LabelPercentageCustomers = New Label()
        LabelCustomersValue = New Label()
        LabelCustomersPeriod = New Label()
        LabelCustomers = New Label()
        Label6 = New Label()
        Panel4 = New Panel()
        LabelPercentage = New Label()
        PictureBoxUpArrow = New PictureBox()
        LabelEarningsValue = New Label()
        LabelEarningsPeriod = New Label()
        Label9 = New Label()
        LabelEarnings = New Label()
        PictureBoxDownArrow = New PictureBox()
        Panel1 = New Panel()
        ButtonToggleChart = New Button()
        Label1 = New Label()
        PanelSales = New Panel()
        Panel10.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBoxUpService, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxDownService, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBoxUpCustomers, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxDownCustomers, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBoxUpArrow, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBoxDownArrow, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel10
        ' 
        Panel10.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        Panel10.Controls.Add(Panel2)
        Panel10.Controls.Add(PanelChartCustomers)
        Panel10.Controls.Add(Panel3)
        Panel10.Controls.Add(Panel4)
        Panel10.Controls.Add(Panel1)
        Panel10.Controls.Add(PanelSales)
        Panel10.Location = New Point(0, 0)
        Panel10.Name = "Panel10"
        Panel10.Size = New Size(1192, 680)
        Panel10.TabIndex = 8
        ' 
        ' Panel2
        ' 
        Panel2.Anchor = AnchorStyles.Top
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(PictureBoxUpService)
        Panel2.Controls.Add(LabelServicePeriod)
        Panel2.Controls.Add(LabelPercentageService)
        Panel2.Controls.Add(LabelOrders)
        Panel2.Controls.Add(LabelServiceValue)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(PictureBoxDownService)
        Panel2.Location = New Point(1445, 128)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(221, 167)
        Panel2.TabIndex = 1
        ' 
        ' PictureBoxUpService
        ' 
        PictureBoxUpService.Image = My.Resources.Resources.triangle1
        PictureBoxUpService.Location = New Point(20, 99)
        PictureBoxUpService.Name = "PictureBoxUpService"
        PictureBoxUpService.Size = New Size(21, 19)
        PictureBoxUpService.TabIndex = 20
        PictureBoxUpService.TabStop = False
        ' 
        ' LabelServicePeriod
        ' 
        LabelServicePeriod.AutoSize = True
        LabelServicePeriod.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelServicePeriod.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        LabelServicePeriod.Location = New Point(18, 122)
        LabelServicePeriod.Name = "LabelServicePeriod"
        LabelServicePeriod.Size = New Size(75, 16)
        LabelServicePeriod.TabIndex = 5
        LabelServicePeriod.Text = "This Month"
        ' 
        ' LabelPercentageService
        ' 
        LabelPercentageService.AutoSize = True
        LabelPercentageService.Location = New Point(38, 100)
        LabelPercentageService.Name = "LabelPercentageService"
        LabelPercentageService.Size = New Size(47, 15)
        LabelPercentageService.TabIndex = 22
        LabelPercentageService.Text = "percent"
        ' 
        ' LabelOrders
        ' 
        LabelOrders.Anchor = AnchorStyles.None
        LabelOrders.AutoSize = True
        LabelOrders.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelOrders.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelOrders.Location = New Point(28, 84)
        LabelOrders.Name = "LabelOrders"
        LabelOrders.Size = New Size(83, 29)
        LabelOrders.TabIndex = 4
        LabelOrders.Text = "13213"
        ' 
        ' LabelServiceValue
        ' 
        LabelServiceValue.AutoSize = True
        LabelServiceValue.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelServiceValue.ForeColor = Color.Green
        LabelServiceValue.Location = New Point(18, 80)
        LabelServiceValue.Name = "LabelServiceValue"
        LabelServiceValue.Size = New Size(37, 20)
        LabelServiceValue.TabIndex = 21
        LabelServiceValue.Text = "50%"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(18, 15)
        Label2.Name = "Label2"
        Label2.Size = New Size(65, 19)
        Label2.TabIndex = 0
        Label2.Text = "Service"
        ' 
        ' PictureBoxDownService
        ' 
        PictureBoxDownService.Image = My.Resources.Resources.down
        PictureBoxDownService.Location = New Point(20, 99)
        PictureBoxDownService.Name = "PictureBoxDownService"
        PictureBoxDownService.Size = New Size(21, 19)
        PictureBoxDownService.TabIndex = 23
        PictureBoxDownService.TabStop = False
        ' 
        ' PanelChartCustomers
        ' 
        PanelChartCustomers.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom
        PanelChartCustomers.BackColor = Color.White
        PanelChartCustomers.Location = New Point(1209, 407)
        PanelChartCustomers.Name = "PanelChartCustomers"
        PanelChartCustomers.Size = New Size(219, 828)
        PanelChartCustomers.TabIndex = 6
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.Top
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(PictureBoxUpCustomers)
        Panel3.Controls.Add(PictureBoxDownCustomers)
        Panel3.Controls.Add(LabelPercentageCustomers)
        Panel3.Controls.Add(LabelCustomersValue)
        Panel3.Controls.Add(LabelCustomersPeriod)
        Panel3.Controls.Add(LabelCustomers)
        Panel3.Controls.Add(Label6)
        Panel3.Location = New Point(1445, 314)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(221, 167)
        Panel3.TabIndex = 2
        ' 
        ' PictureBoxUpCustomers
        ' 
        PictureBoxUpCustomers.Image = My.Resources.Resources.triangle1
        PictureBoxUpCustomers.Location = New Point(18, 99)
        PictureBoxUpCustomers.Name = "PictureBoxUpCustomers"
        PictureBoxUpCustomers.Size = New Size(21, 19)
        PictureBoxUpCustomers.TabIndex = 17
        PictureBoxUpCustomers.TabStop = False
        ' 
        ' PictureBoxDownCustomers
        ' 
        PictureBoxDownCustomers.Image = My.Resources.Resources.down
        PictureBoxDownCustomers.Location = New Point(18, 99)
        PictureBoxDownCustomers.Name = "PictureBoxDownCustomers"
        PictureBoxDownCustomers.Size = New Size(21, 19)
        PictureBoxDownCustomers.TabIndex = 19
        PictureBoxDownCustomers.TabStop = False
        ' 
        ' LabelPercentageCustomers
        ' 
        LabelPercentageCustomers.AutoSize = True
        LabelPercentageCustomers.Location = New Point(36, 100)
        LabelPercentageCustomers.Name = "LabelPercentageCustomers"
        LabelPercentageCustomers.Size = New Size(47, 15)
        LabelPercentageCustomers.TabIndex = 18
        LabelPercentageCustomers.Text = "percent"
        ' 
        ' LabelCustomersValue
        ' 
        LabelCustomersValue.AutoSize = True
        LabelCustomersValue.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelCustomersValue.ForeColor = Color.Green
        LabelCustomersValue.Location = New Point(16, 80)
        LabelCustomersValue.Name = "LabelCustomersValue"
        LabelCustomersValue.Size = New Size(37, 20)
        LabelCustomersValue.TabIndex = 17
        LabelCustomersValue.Text = "50%"
        ' 
        ' LabelCustomersPeriod
        ' 
        LabelCustomersPeriod.AutoSize = True
        LabelCustomersPeriod.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelCustomersPeriod.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        LabelCustomersPeriod.Location = New Point(18, 122)
        LabelCustomersPeriod.Name = "LabelCustomersPeriod"
        LabelCustomersPeriod.Size = New Size(75, 16)
        LabelCustomersPeriod.TabIndex = 8
        LabelCustomersPeriod.Text = "This Month"
        ' 
        ' LabelCustomers
        ' 
        LabelCustomers.Anchor = AnchorStyles.None
        LabelCustomers.AutoSize = True
        LabelCustomers.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelCustomers.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelCustomers.Location = New Point(28, 84)
        LabelCustomers.Name = "LabelCustomers"
        LabelCustomers.Size = New Size(83, 29)
        LabelCustomers.TabIndex = 7
        LabelCustomers.Text = "13213"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(18, 15)
        Label6.Name = "Label6"
        Label6.Size = New Size(88, 19)
        Label6.TabIndex = 6
        Label6.Text = "Customers"
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top
        Panel4.BackColor = Color.White
        Panel4.Controls.Add(LabelPercentage)
        Panel4.Controls.Add(PictureBoxUpArrow)
        Panel4.Controls.Add(LabelEarningsValue)
        Panel4.Controls.Add(LabelEarningsPeriod)
        Panel4.Controls.Add(Label9)
        Panel4.Controls.Add(LabelEarnings)
        Panel4.Controls.Add(PictureBoxDownArrow)
        Panel4.Location = New Point(1443, 501)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(221, 167)
        Panel4.TabIndex = 2
        ' 
        ' LabelPercentage
        ' 
        LabelPercentage.AutoSize = True
        LabelPercentage.Location = New Point(38, 97)
        LabelPercentage.Name = "LabelPercentage"
        LabelPercentage.Size = New Size(47, 15)
        LabelPercentage.TabIndex = 15
        LabelPercentage.Text = "percent"
        ' 
        ' PictureBoxUpArrow
        ' 
        PictureBoxUpArrow.Image = My.Resources.Resources.triangle1
        PictureBoxUpArrow.Location = New Point(20, 96)
        PictureBoxUpArrow.Name = "PictureBoxUpArrow"
        PictureBoxUpArrow.Size = New Size(21, 19)
        PictureBoxUpArrow.TabIndex = 13
        PictureBoxUpArrow.TabStop = False
        ' 
        ' LabelEarningsValue
        ' 
        LabelEarningsValue.AutoSize = True
        LabelEarningsValue.Font = New Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelEarningsValue.ForeColor = Color.Green
        LabelEarningsValue.Location = New Point(20, 77)
        LabelEarningsValue.Name = "LabelEarningsValue"
        LabelEarningsValue.Size = New Size(37, 20)
        LabelEarningsValue.TabIndex = 12
        LabelEarningsValue.Text = "50%"
        ' 
        ' LabelEarningsPeriod
        ' 
        LabelEarningsPeriod.AutoSize = True
        LabelEarningsPeriod.Font = New Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelEarningsPeriod.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        LabelEarningsPeriod.Location = New Point(18, 122)
        LabelEarningsPeriod.Name = "LabelEarningsPeriod"
        LabelEarningsPeriod.Size = New Size(75, 16)
        LabelEarningsPeriod.TabIndex = 11
        LabelEarningsPeriod.Text = "This Month"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(18, 15)
        Label9.Name = "Label9"
        Label9.Size = New Size(74, 19)
        Label9.TabIndex = 9
        Label9.Text = "Earnings"
        ' 
        ' LabelEarnings
        ' 
        LabelEarnings.Anchor = AnchorStyles.None
        LabelEarnings.AutoSize = True
        LabelEarnings.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelEarnings.ForeColor = Color.FromArgb(CByte(0), CByte(0), CByte(6))
        LabelEarnings.Location = New Point(28, 84)
        LabelEarnings.Name = "LabelEarnings"
        LabelEarnings.Size = New Size(83, 29)
        LabelEarnings.TabIndex = 10
        LabelEarnings.Text = "13213"
        ' 
        ' PictureBoxDownArrow
        ' 
        PictureBoxDownArrow.Image = My.Resources.Resources.down
        PictureBoxDownArrow.Location = New Point(20, 96)
        PictureBoxDownArrow.Name = "PictureBoxDownArrow"
        PictureBoxDownArrow.Size = New Size(21, 19)
        PictureBoxDownArrow.TabIndex = 16
        PictureBoxDownArrow.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(ButtonToggleChart)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1192, 111)
        Panel1.TabIndex = 0
        ' 
        ' ButtonToggleChart
        ' 
        ButtonToggleChart.BackColor = Color.FromArgb(CByte(92), CByte(81), CByte(224))
        ButtonToggleChart.FlatAppearance.BorderSize = 0
        ButtonToggleChart.FlatStyle = FlatStyle.Flat
        ButtonToggleChart.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ButtonToggleChart.ForeColor = Color.White
        ButtonToggleChart.Location = New Point(1014, 12)
        ButtonToggleChart.Name = "ButtonToggleChart"
        ButtonToggleChart.Size = New Size(140, 27)
        ButtonToggleChart.TabIndex = 10
        ButtonToggleChart.Text = "Daily"
        ButtonToggleChart.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(22, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(367, 41)
        Label1.TabIndex = 7
        Label1.Text = "Analytics Dashboard"
        ' 
        ' PanelSales
        ' 
        PanelSales.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PanelSales.BackColor = Color.White
        PanelSales.Location = New Point(0, 128)
        PanelSales.Name = "PanelSales"
        PanelSales.Size = New Size(1192, 552)
        PanelSales.TabIndex = 4
        ' 
        ' SalesMadeAnalyticsvb
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(1192, 680)
        Controls.Add(Panel10)
        FormBorderStyle = FormBorderStyle.None
        Name = "SalesMadeAnalyticsvb"
        Text = "SalesMadeAnalyticsvb"
        Panel10.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBoxUpService, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxDownService, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBoxUpCustomers, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxDownCustomers, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBoxUpArrow, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBoxDownArrow, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBoxUpService As PictureBox
    Friend WithEvents LabelServicePeriod As Label
    Friend WithEvents LabelPercentageService As Label
    Friend WithEvents LabelOrders As Label
    Friend WithEvents LabelServiceValue As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBoxDownService As PictureBox
    Friend WithEvents PanelChartCustomers As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBoxUpCustomers As PictureBox
    Friend WithEvents PictureBoxDownCustomers As PictureBox
    Friend WithEvents LabelPercentageCustomers As Label
    Friend WithEvents LabelCustomersValue As Label
    Friend WithEvents LabelCustomersPeriod As Label
    Friend WithEvents LabelCustomers As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LabelPercentage As Label
    Friend WithEvents PictureBoxUpArrow As PictureBox
    Friend WithEvents LabelEarningsValue As Label
    Friend WithEvents LabelEarningsPeriod As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LabelEarnings As Label
    Friend WithEvents PictureBoxDownArrow As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonToggleChart As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelSales As Panel
End Class
