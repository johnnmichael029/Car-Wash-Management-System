<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ActivityLog
    Inherits BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Panel1 = New Panel()
        DataGridViewActivityLog = New DataGridView()
        Panel1.SuspendLayout()
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(208, 39)
        Label1.TabIndex = 1
        Label1.Text = "Activity Log"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.Controls.Add(DataGridViewActivityLog)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 511)
        Panel1.TabIndex = 1
        ' 
        ' DataGridViewActivityLog
        ' 
        DataGridViewActivityLog.AllowUserToAddRows = False
        DataGridViewActivityLog.AllowUserToResizeColumns = False
        DataGridViewActivityLog.AllowUserToResizeRows = False
        DataGridViewActivityLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewActivityLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewActivityLog.BackgroundColor = SystemColors.ControlLight
        DataGridViewActivityLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewActivityLog.Location = New Point(0, 53)
        DataGridViewActivityLog.Name = "DataGridViewActivityLog"
        DataGridViewActivityLog.ReadOnly = True
        DataGridViewActivityLog.Size = New Size(905, 458)
        DataGridViewActivityLog.TabIndex = 2
        ' 
        ' ActivityLog
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 511)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "ActivityLog"
        Text = "ActivtyLog"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridViewActivityLog As DataGridView
End Class
