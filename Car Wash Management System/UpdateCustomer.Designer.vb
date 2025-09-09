<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateCustomer
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
        updateBtn = New Button()
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
        Label6 = New Label()
        customerIDLabel = New Label()
        SuspendLayout()
        ' 
        ' updateBtn
        ' 
        updateBtn.Location = New Point(42, 423)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(261, 43)
        updateBtn.TabIndex = 21
        updateBtn.Text = "Update"
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(42, 323)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 15)
        Label5.TabIndex = 20
        Label5.Text = "Plate Number"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(42, 196)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 19
        Label4.Text = "Address"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(42, 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 18
        Label3.Text = "Email"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(42, 85)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 15)
        Label2.TabIndex = 17
        Label2.Text = "Phone Number"
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(42, 341)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
        TextBoxPlateNumber.TabIndex = 16
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Location = New Point(42, 214)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 15
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(42, 158)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 23)
        TextBoxEmail.TabIndex = 14
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(42, 103)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
        TextBoxNumber.TabIndex = 13
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(42, 45)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
        TextBoxName.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(42, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 11
        Label1.Text = "Name"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(42, 405)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 15)
        Label6.TabIndex = 22
        Label6.Text = "Customer ID"
        ' 
        ' customerIDLabel
        ' 
        customerIDLabel.AutoSize = True
        customerIDLabel.Location = New Point(121, 405)
        customerIDLabel.Name = "customerIDLabel"
        customerIDLabel.Size = New Size(0, 15)
        customerIDLabel.TabIndex = 23
        ' 
        ' UpdateCustomer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        ClientSize = New Size(357, 540)
        Controls.Add(customerIDLabel)
        Controls.Add(Label6)
        Controls.Add(updateBtn)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(TextBoxPlateNumber)
        Controls.Add(TextBoxAddress)
        Controls.Add(TextBoxEmail)
        Controls.Add(TextBoxNumber)
        Controls.Add(TextBoxName)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        MaximumSize = New Size(357, 540)
        Name = "UpdateCustomer"
        Text = "UpdateCustomers"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents updateBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents customerIDLabel As Label
End Class
