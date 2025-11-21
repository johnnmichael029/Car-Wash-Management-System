<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Service
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
        DataGridViewService = New DataGridView()
        Panel3 = New Panel()
        LabelIsAdmin = New Label()
        CheckBoxAddon = New CheckBox()
        LabelServiceID = New Label()
        Label4 = New Label()
        DeleteServiceBtn = New Button()
        UpdateServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxPrice = New TextBox()
        Label3 = New Label()
        TextBoxDescription = New TextBox()
        Label2 = New Label()
        TextBoxServiceName = New TextBox()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(DataGridViewService, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridViewService)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 551)
        Panel1.TabIndex = 1
        ' 
        ' DataGridViewService
        ' 
        DataGridViewService.AllowUserToAddRows = False
        DataGridViewService.AllowUserToResizeColumns = False
        DataGridViewService.AllowUserToResizeRows = False
        DataGridViewService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewService.BackgroundColor = Color.White
        DataGridViewService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewService.Dock = DockStyle.Fill
        DataGridViewService.Location = New Point(0, 0)
        DataGridViewService.Name = "DataGridViewService"
        DataGridViewService.ReadOnly = True
        DataGridViewService.Size = New Size(606, 551)
        DataGridViewService.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(LabelIsAdmin)
        Panel3.Controls.Add(CheckBoxAddon)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(DeleteServiceBtn)
        Panel3.Controls.Add(UpdateServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(TextBoxPrice)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(TextBoxDescription)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(TextBoxServiceName)
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(606, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(305, 551)
        Panel3.TabIndex = 2
        ' 
        ' LabelIsAdmin
        ' 
        LabelIsAdmin.AutoSize = True
        LabelIsAdmin.BackColor = Color.White
        LabelIsAdmin.Font = New Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LabelIsAdmin.ForeColor = Color.Red
        LabelIsAdmin.Location = New Point(16, 341)
        LabelIsAdmin.Name = "LabelIsAdmin"
        LabelIsAdmin.Size = New Size(0, 16)
        LabelIsAdmin.TabIndex = 13
        ' 
        ' CheckBoxAddon
        ' 
        CheckBoxAddon.AutoSize = True
        CheckBoxAddon.Location = New Point(193, 169)
        CheckBoxAddon.Name = "CheckBoxAddon"
        CheckBoxAddon.Size = New Size(62, 19)
        CheckBoxAddon.TabIndex = 12
        CheckBoxAddon.Text = "Addon"
        CheckBoxAddon.UseVisualStyleBackColor = True
        ' 
        ' LabelServiceID
        ' 
        LabelServiceID.AutoSize = True
        LabelServiceID.Location = New Point(72, 169)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 169)
        Label4.Name = "Label4"
        Label4.Size = New Size(58, 15)
        Label4.TabIndex = 10
        Label4.Text = "Service ID"
        ' 
        ' DeleteServiceBtn
        ' 
        DeleteServiceBtn.BackColor = Color.FromArgb(CByte(228), CByte(76), CByte(76))
        DeleteServiceBtn.FlatAppearance.BorderSize = 0
        DeleteServiceBtn.FlatStyle = FlatStyle.Flat
        DeleteServiceBtn.Font = New Font("Century Gothic", 11.25F)
        DeleteServiceBtn.ForeColor = Color.White
        DeleteServiceBtn.Location = New Point(16, 299)
        DeleteServiceBtn.Name = "DeleteServiceBtn"
        DeleteServiceBtn.Size = New Size(260, 46)
        DeleteServiceBtn.TabIndex = 9
        DeleteServiceBtn.Text = "Delete Service"
        DeleteServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' UpdateServiceBtn
        ' 
        UpdateServiceBtn.BackColor = Color.FromArgb(CByte(84), CByte(98), CByte(161))
        UpdateServiceBtn.FlatAppearance.BorderSize = 0
        UpdateServiceBtn.FlatStyle = FlatStyle.Flat
        UpdateServiceBtn.Font = New Font("Century Gothic", 11.25F)
        UpdateServiceBtn.ForeColor = Color.White
        UpdateServiceBtn.Location = New Point(16, 247)
        UpdateServiceBtn.Name = "UpdateServiceBtn"
        UpdateServiceBtn.Size = New Size(260, 46)
        UpdateServiceBtn.TabIndex = 8
        UpdateServiceBtn.Text = "Update Service"
        UpdateServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' AddServiceBtn
        ' 
        AddServiceBtn.BackColor = Color.FromArgb(CByte(55), CByte(83), CByte(204))
        AddServiceBtn.FlatAppearance.BorderSize = 0
        AddServiceBtn.FlatStyle = FlatStyle.Flat
        AddServiceBtn.Font = New Font("Century Gothic", 11.25F)
        AddServiceBtn.ForeColor = Color.White
        AddServiceBtn.Location = New Point(16, 194)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(260, 46)
        AddServiceBtn.TabIndex = 6
        AddServiceBtn.Text = "Add Service"
        AddServiceBtn.UseVisualStyleBackColor = False
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 138)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 120)
        Label3.Name = "Label3"
        Label3.Size = New Size(33, 15)
        Label3.TabIndex = 4
        Label3.Text = "Price"
        ' 
        ' TextBoxDescription
        ' 
        TextBoxDescription.Location = New Point(16, 82)
        TextBoxDescription.Name = "TextBoxDescription"
        TextBoxDescription.Size = New Size(261, 23)
        TextBoxDescription.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(67, 15)
        Label2.TabIndex = 2
        Label2.Text = "Description"
        ' 
        ' TextBoxServiceName
        ' 
        TextBoxServiceName.Location = New Point(16, 27)
        TextBoxServiceName.Name = "TextBoxServiceName"
        TextBoxServiceName.Size = New Size(261, 23)
        TextBoxServiceName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 15)
        Label1.TabIndex = 0
        Label1.Text = "Service Name"
        ' 
        ' Service
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Service"
        Text = "Service"
        Panel1.ResumeLayout(False)
        CType(DataGridViewService, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxDescription As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxServiceName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents DeleteServiceBtn As Button
    Friend WithEvents UpdateServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridViewService As DataGridView
    Friend WithEvents CheckBoxAddon As CheckBox
    Friend WithEvents LabelIsAdmin As Label
End Class
