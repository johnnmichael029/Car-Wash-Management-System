<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesHistory
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
        Label1 = New Label()
        DataGridViewSalesHIstory = New DataGridView()
        Panel1 = New Panel()
        Panel2 = New Panel()
        CType(DataGridViewSalesHIstory, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(236, 39)
        Label1.TabIndex = 1
        Label1.Text = "Sales History"
        ' 
        ' DataGridViewSalesHIstory
        ' 
        DataGridViewSalesHIstory.AllowUserToAddRows = False
        DataGridViewSalesHIstory.AllowUserToResizeColumns = False
        DataGridViewSalesHIstory.AllowUserToResizeRows = False
        DataGridViewSalesHIstory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewSalesHIstory.BackgroundColor = Color.White
        DataGridViewSalesHIstory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewSalesHIstory.Dock = DockStyle.Fill
        DataGridViewSalesHIstory.Location = New Point(0, 0)
        DataGridViewSalesHIstory.Name = "DataGridViewSalesHIstory"
        DataGridViewSalesHIstory.ReadOnly = True
        DataGridViewSalesHIstory.Size = New Size(911, 498)
        DataGridViewSalesHIstory.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 53)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(DataGridViewSalesHIstory)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 53)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(911, 498)
        Panel2.TabIndex = 2
        ' 
        ' SalesHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(911, 551)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "SalesHistory"
        Text = "SalesHistory"
        CType(DataGridViewSalesHIstory, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewSalesHIstory As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
