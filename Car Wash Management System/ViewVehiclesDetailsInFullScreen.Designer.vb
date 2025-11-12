<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewVehiclesDetailsInFullScreen
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
        Button1 = New Button()
        VehicleInfoDockPanel = New Panel()
        Panel2 = New Panel()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.reject1
        Button1.Location = New Point(754, 9)
        Button1.Name = "Button1"
        Button1.Size = New Size(34, 23)
        Button1.TabIndex = 112
        Button1.UseVisualStyleBackColor = True
        ' 
        ' VehicleInfoDockPanel
        ' 
        VehicleInfoDockPanel.Location = New Point(12, 38)
        VehicleInfoDockPanel.Name = "VehicleInfoDockPanel"
        VehicleInfoDockPanel.Size = New Size(776, 400)
        VehicleInfoDockPanel.TabIndex = 113
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(VehicleInfoDockPanel)
        Panel2.Controls.Add(Button1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(800, 450)
        Panel2.TabIndex = 114
        ' 
        ' ViewVehiclesDetailsInFullScreen
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "ViewVehiclesDetailsInFullScreen"
        Text = "ViewVehiclesDetailsInFullScreen"
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents VehicleInfoDockPanel As Panel
    Friend WithEvents Panel2 As Panel
End Class
