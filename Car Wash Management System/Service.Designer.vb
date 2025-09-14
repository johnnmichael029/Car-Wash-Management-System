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
        deleteServiceBtn = New Button()
        updateServiceBtn = New Button()
        viewServiceBtn = New Button()
        addServiceBtn = New Button()
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
        Panel3.Controls.Add(deleteServiceBtn)
        Panel3.Controls.Add(updateServiceBtn)
        Panel3.Controls.Add(viewServiceBtn)
        Panel3.Controls.Add(addServiceBtn)
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
        ' deleteServiceBtn
        ' 
        deleteServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteServiceBtn.Location = New Point(16, 329)
        deleteServiceBtn.Name = "deleteServiceBtn"
        deleteServiceBtn.Size = New Size(261, 39)
        deleteServiceBtn.TabIndex = 9
        deleteServiceBtn.Text = "Delete Service"
        deleteServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' updateServiceBtn
        ' 
        updateServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateServiceBtn.Location = New Point(16, 284)
        updateServiceBtn.Name = "updateServiceBtn"
        updateServiceBtn.Size = New Size(261, 39)
        updateServiceBtn.TabIndex = 8
        updateServiceBtn.Text = "Update Service"
        updateServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' viewServiceBtn
        ' 
        viewServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        viewServiceBtn.Location = New Point(16, 239)
        viewServiceBtn.Name = "viewServiceBtn"
        viewServiceBtn.Size = New Size(261, 39)
        viewServiceBtn.TabIndex = 7
        viewServiceBtn.Text = "View Service"
        viewServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' addServiceBtn
        ' 
        addServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        addServiceBtn.Location = New Point(16, 194)
        addServiceBtn.Name = "addServiceBtn"
        addServiceBtn.Size = New Size(261, 39)
        addServiceBtn.TabIndex = 6
        addServiceBtn.Text = "Add Service"
        addServiceBtn.UseVisualStyleBackColor = True
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
    Friend WithEvents deleteServiceBtn As Button
    Friend WithEvents updateServiceBtn As Button
    Friend WithEvents viewServiceBtn As Button
    Friend WithEvents addServiceBtn As Button
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents CheckBoxAddon As CheckBox
End Class
