﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reservation
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
        Panel1 = New Panel()
        Label1 = New Label()
        DataGridViewListOfReserved = New DataGridView()
        Panel1.SuspendLayout()
        CType(DataGridViewListOfReserved, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(DataGridViewListOfReserved)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 551)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(3, 3)
        Label1.Name = "Label1"
        Label1.Size = New Size(273, 41)
        Label1.TabIndex = 1
        Label1.Text = "List of Reserved"
        ' 
        ' DataGridViewListOfReserved
        ' 
        DataGridViewListOfReserved.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridViewListOfReserved.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewListOfReserved.BackgroundColor = SystemColors.ControlLight
        DataGridViewListOfReserved.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewListOfReserved.Location = New Point(0, 53)
        DataGridViewListOfReserved.Name = "DataGridViewListOfReserved"
        DataGridViewListOfReserved.ReadOnly = True
        DataGridViewListOfReserved.Size = New Size(905, 498)
        DataGridViewListOfReserved.TabIndex = 0
        ' 
        ' Reservation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Reservation"
        Text = "Reservation"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridViewListOfReserved, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridViewListOfReserved As DataGridView
End Class
