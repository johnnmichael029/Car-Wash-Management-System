<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomerInformation))
        Panel1 = New Panel()
        Panel2 = New Panel()
        customerIDLabel = New Label()
        Label1 = New Label()
        updateBtn = New Button()
        Label2 = New Label()
        deleteBtn = New Button()
        TextBoxPlateNumber = New TextBox()
        viewBtn = New Button()
        Label3 = New Label()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        Label67 = New Label()
        Label4 = New Label()
        TextBoxNumber = New TextBox()
        addBtn = New Button()
        Label5 = New Label()
        TextBoxName = New TextBox()
        DataGridView1 = New DataGridView()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(DataGridView1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 551)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(customerIDLabel)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(updateBtn)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(deleteBtn)
        Panel2.Controls.Add(TextBoxPlateNumber)
        Panel2.Controls.Add(viewBtn)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(TextBoxAddress)
        Panel2.Controls.Add(TextBoxEmail)
        Panel2.Controls.Add(Label67)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(TextBoxNumber)
        Panel2.Controls.Add(addBtn)
        Panel2.Controls.Add(Label5)
        Panel2.Controls.Add(TextBoxName)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(606, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(305, 551)
        Panel2.TabIndex = 1
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        customerIDLabel.ForeColor = Color.Red
        customerIDLabel.Location = New Point(89, 314)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 57
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 46
        Label1.Text = "Name"
        ' 
        ' updateBtn
        ' 
        updateBtn.Anchor = AnchorStyles.Top
        updateBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateBtn.Image = My.Resources.Resources.refresh
        updateBtn.Location = New Point(16, 435)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(261, 50)
        updateBtn.TabIndex = 43
        updateBtn.Text = "Update Customer"
        updateBtn.TextAlign = ContentAlignment.MiddleRight
        updateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 15)
        Label2.TabIndex = 52
        Label2.Text = "Phone Number"
        ' 
        ' deleteBtn
        ' 
        deleteBtn.Anchor = AnchorStyles.Top
        deleteBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteBtn.Image = My.Resources.Resources.delete_user
        deleteBtn.Location = New Point(16, 492)
        deleteBtn.Name = "deleteBtn"
        deleteBtn.Size = New Size(261, 49)
        deleteBtn.TabIndex = 44
        deleteBtn.Text = "Delete Customer"
        deleteBtn.TextAlign = ContentAlignment.MiddleRight
        deleteBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        deleteBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(16, 285)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
        TextBoxPlateNumber.TabIndex = 51
        ' 
        ' viewBtn
        ' 
        viewBtn.Anchor = AnchorStyles.Top
        viewBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        viewBtn.Image = My.Resources.Resources.view_user
        viewBtn.Location = New Point(16, 383)
        viewBtn.Name = "viewBtn"
        viewBtn.Size = New Size(261, 46)
        viewBtn.TabIndex = 45
        viewBtn.Text = "View Customer"
        viewBtn.TextAlign = ContentAlignment.MiddleRight
        viewBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        viewBtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 97)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 53
        Label3.Text = "Email"
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Location = New Point(16, 171)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 50
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(16, 115)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 23)
        TextBoxEmail.TabIndex = 49
        ' 
        ' Label67
        ' 
        Label67.AutoSize = True
        Label67.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        Label67.Location = New Point(16, 314)
        Label67.Name = "Label67"
        Label67.Size = New Size(73, 15)
        Label67.TabIndex = 56
        Label67.Text = "Customer ID"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 153)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 54
        Label4.Text = "Address"
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(16, 71)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
        TextBoxNumber.TabIndex = 48
        ' 
        ' addBtn
        ' 
        addBtn.Anchor = AnchorStyles.Top
        addBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        addBtn.Image = CType(resources.GetObject("addBtn.Image"), Image)
        addBtn.Location = New Point(16, 332)
        addBtn.Name = "addBtn"
        addBtn.Size = New Size(261, 45)
        addBtn.TabIndex = 42
        addBtn.Text = "Add Customer"
        addBtn.TextAlign = ContentAlignment.MiddleRight
        addBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        addBtn.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(16, 267)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 15)
        Label5.TabIndex = 55
        Label5.Text = "Plate Number"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(16, 27)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
        TextBoxName.TabIndex = 47
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.Size = New Size(606, 551)
        DataGridView1.TabIndex = 0
        ' 
        ' CustomerInformation
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "CustomerInformation"
        Text = "CustomerInformation"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents updateBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents deleteBtn As Button
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents viewBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label67 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents addBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxName As TextBox
End Class
