<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerManagement
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
        viewBtn = New Button()
        deleteBtn = New Button()
        updateBtn = New Button()
        addBtn = New Button()
        DataGridView1 = New DataGridView()
        Panel1 = New Panel()
        customerIDLabel = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        TextBoxPlateNumber = New TextBox()
        TextBoxAddress = New TextBox()
        TextBoxEmail = New TextBox()
        TextBoxNumber = New TextBox()
        TextBoxName = New TextBox()
        Label1 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' viewBtn
        ' 
        viewBtn.Anchor = AnchorStyles.Top
        viewBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        viewBtn.Location = New Point(23, 485)
        viewBtn.Name = "viewBtn"
        viewBtn.Size = New Size(261, 46)
        viewBtn.TabIndex = 27
        viewBtn.Text = "View Customer"
        viewBtn.UseVisualStyleBackColor = True
        ' 
        ' deleteBtn
        ' 
        deleteBtn.Anchor = AnchorStyles.Top
        deleteBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteBtn.Location = New Point(23, 594)
        deleteBtn.Name = "deleteBtn"
        deleteBtn.Size = New Size(261, 49)
        deleteBtn.TabIndex = 26
        deleteBtn.Text = "Delete Customer"
        deleteBtn.UseVisualStyleBackColor = True
        ' 
        ' updateBtn
        ' 
        updateBtn.Anchor = AnchorStyles.Top
        updateBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateBtn.Location = New Point(23, 537)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(261, 50)
        updateBtn.TabIndex = 25
        updateBtn.Text = "Update Customer"
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' addBtn
        ' 
        addBtn.Anchor = AnchorStyles.Top
        addBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        addBtn.Location = New Point(23, 434)
        addBtn.Name = "addBtn"
        addBtn.Size = New Size(261, 45)
        addBtn.TabIndex = 24
        addBtn.Text = "Add Customer"
        addBtn.UseVisualStyleBackColor = True
        ' 
        ' DataGridView1
        ' 
        DataGridView1.Anchor = AnchorStyles.Top
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(48, 57)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(1133, 365)
        DataGridView1.TabIndex = 18
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(customerIDLabel)
        Panel1.Controls.Add(updateBtn)
        Panel1.Controls.Add(deleteBtn)
        Panel1.Controls.Add(viewBtn)
        Panel1.Controls.Add(TextBoxAddress)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(addBtn)
        Panel1.Controls.Add(TextBoxName)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(TextBoxNumber)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(TextBoxEmail)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(TextBoxPlateNumber)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(1187, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(305, 643)
        Panel1.TabIndex = 28
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Location = New Point(102, 416)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 41
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(23, 416)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 15)
        Label6.TabIndex = 40
        Label6.Text = "Customer ID"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(23, 334)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 15)
        Label5.TabIndex = 38
        Label5.Text = "Plate Number"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(23, 207)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 37
        Label4.Text = "Address"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(23, 151)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 36
        Label3.Text = "Email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(23, 96)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 15)
        Label2.TabIndex = 35
        Label2.Text = "Phone Number"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(23, 352)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
        TextBoxPlateNumber.TabIndex = 34
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Location = New Point(23, 225)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 33
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(23, 169)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 23)
        TextBoxEmail.TabIndex = 32
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(23, 114)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
        TextBoxNumber.TabIndex = 31
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(23, 56)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
        TextBoxName.TabIndex = 30
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 38)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 29
        Label1.Text = "Name"
        ' 
        ' CustomerManagement
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        ClientSize = New Size(1497, 647)
        Controls.Add(Panel1)
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.None
        MaximumSize = New Size(1497, 647)
        Name = "CustomerManagement"
        Text = "Customer Management"
        WindowState = FormWindowState.Maximized
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents viewBtn As Button
    Friend WithEvents deleteBtn As Button
    Friend WithEvents updateBtn As Button
    Friend WithEvents addBtn As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents customerIDLabel As Label
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents Label2 As Label
End Class
