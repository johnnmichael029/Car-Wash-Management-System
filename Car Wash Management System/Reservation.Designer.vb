<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Reservation
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
        Panel1 = New Panel()
        Label1 = New Label()
        DataGridViewListOfReservation = New DataGridView()
        Panel1.SuspendLayout()
        CType(DataGridViewListOfReservation, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(DataGridViewListOfReservation)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 551)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(284, 39)
        Label1.TabIndex = 1
        Label1.Text = "List of Reserved"
        ' 
        ' DataGridViewListOfReservation
        ' 
        DataGridViewListOfReservation.AllowUserToAddRows = False
        DataGridViewListOfReservation.AllowUserToResizeColumns = False
        DataGridViewListOfReservation.AllowUserToResizeRows = False
        DataGridViewListOfReservation.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewListOfReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewListOfReservation.BackgroundColor = Color.White
        DataGridViewListOfReservation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewListOfReservation.Location = New Point(0, 53)
        DataGridViewListOfReservation.Name = "DataGridViewListOfReservation"
        DataGridViewListOfReservation.ReadOnly = True
        DataGridViewListOfReservation.Size = New Size(905, 498)
        DataGridViewListOfReservation.TabIndex = 0
        ' 
        ' Reservation
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Reservation"
        Text = "Reservation"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridViewListOfReservation, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewListOfReservation As DataGridView
End Class
