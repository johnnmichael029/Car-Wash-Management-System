<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Service
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
        DataGridView1 = New DataGridView()
        Panel3 = New Panel()
        CheckBoxAddon = New CheckBox()
        LabelServiceID = New Label()
        Label4 = New Label()
        DeleteServiceBtn = New Button()
        UpdateServiceBtn = New Button()
        ViewServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxPrice = New TextBox()
        Label3 = New Label()
        TextBoxDescription = New TextBox()
        Label2 = New Label()
        TextBoxServiceName = New TextBox()
        Label1 = New Label()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 551)
        Panel1.TabIndex = 1
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(606, 551)
        DataGridView1.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel3.Controls.Add(CheckBoxAddon)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(DeleteServiceBtn)
        Panel3.Controls.Add(UpdateServiceBtn)
        Panel3.Controls.Add(ViewServiceBtn)
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
        DeleteServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        DeleteServiceBtn.Location = New Point(16, 329)
        DeleteServiceBtn.Name = "DeleteServiceBtn"
        DeleteServiceBtn.Size = New Size(261, 39)
        DeleteServiceBtn.TabIndex = 9
        DeleteServiceBtn.Text = "Delete Service"
        DeleteServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' UpdateServiceBtn
        ' 
        UpdateServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        UpdateServiceBtn.Location = New Point(16, 284)
        UpdateServiceBtn.Name = "UpdateServiceBtn"
        UpdateServiceBtn.Size = New Size(261, 39)
        UpdateServiceBtn.TabIndex = 8
        UpdateServiceBtn.Text = "Update Service"
        UpdateServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' ViewServiceBtn
        ' 
        ViewServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        ViewServiceBtn.Location = New Point(16, 239)
        ViewServiceBtn.Name = "ViewServiceBtn"
        ViewServiceBtn.Size = New Size(261, 39)
        ViewServiceBtn.TabIndex = 7
        ViewServiceBtn.Text = "View Service"
        ViewServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' AddServiceBtn
        ' 
        AddServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        AddServiceBtn.Location = New Point(16, 194)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(261, 39)
        AddServiceBtn.TabIndex = 6
        AddServiceBtn.Text = "Add Service"
        AddServiceBtn.UseVisualStyleBackColor = True
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
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ViewServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBoxAddon As CheckBox
End Class
