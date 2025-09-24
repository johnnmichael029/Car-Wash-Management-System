<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notification
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
        Label1 = New Label()
        Panel11 = New Panel()
        DataGridViewActivityLog = New DataGridView()
        Panel1 = New Panel()
        Label11 = New Label()
        Panel11.SuspendLayout()
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(62, 56)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 15)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' Panel11
        ' 
        Panel11.BackColor = Color.White
        Panel11.Controls.Add(DataGridViewActivityLog)
        Panel11.Controls.Add(Panel1)
        Panel11.Location = New Point(44, 56)
        Panel11.Name = "Panel11"
        Panel11.Size = New Size(279, 680)
        Panel11.TabIndex = 9
        ' 
        ' DataGridViewActivityLog
        ' 
        DataGridViewActivityLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        DataGridViewActivityLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewActivityLog.BackgroundColor = Color.White
        DataGridViewActivityLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewActivityLog.Location = New Point(0, 33)
        DataGridViewActivityLog.Name = "DataGridViewActivityLog"
        DataGridViewActivityLog.Size = New Size(279, 1227)
        DataGridViewActivityLog.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Label11)
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(245, 32)
        Panel1.TabIndex = 7
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ForeColor = Color.FromArgb(CByte(77), CByte(77), CByte(83))
        Label11.Location = New Point(0, 4)
        Label11.Name = "Label11"
        Label11.Size = New Size(97, 19)
        Label11.TabIndex = 5
        Label11.Text = "Acitivty Log"
        ' 
        ' Notification
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(394, 450)
        Controls.Add(Panel11)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Notification"
        Text = "Notification"
        Panel11.ResumeLayout(False)
        CType(DataGridViewActivityLog, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents DataGridViewActivityLog As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
End Class
