<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCustomer
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
        TextBoxName = New TextBox()
        TextBoxNumber = New TextBox()
        TextBoxEmail = New TextBox()
        TextBoxAddress = New TextBox()
        TextBoxPlateNumber = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        addBtn = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(42, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 15)
        Label1.TabIndex = 0
        Label1.Text = "Name"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(42, 45)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(261, 23)
        TextBoxName.TabIndex = 1
        ' 
        ' TextBoxNumber
        ' 
        TextBoxNumber.Location = New Point(42, 103)
        TextBoxNumber.Name = "TextBoxNumber"
        TextBoxNumber.Size = New Size(120, 23)
        TextBoxNumber.TabIndex = 2
        ' 
        ' TextBoxEmail
        ' 
        TextBoxEmail.Location = New Point(42, 158)
        TextBoxEmail.Name = "TextBoxEmail"
        TextBoxEmail.Size = New Size(261, 23)
        TextBoxEmail.TabIndex = 3
        ' 
        ' TextBoxAddress
        ' 
        TextBoxAddress.Location = New Point(42, 214)
        TextBoxAddress.Multiline = True
        TextBoxAddress.Name = "TextBoxAddress"
        TextBoxAddress.Size = New Size(261, 93)
        TextBoxAddress.TabIndex = 4
        ' 
        ' TextBoxPlateNumber
        ' 
        TextBoxPlateNumber.Location = New Point(42, 341)
        TextBoxPlateNumber.Name = "TextBoxPlateNumber"
        TextBoxPlateNumber.Size = New Size(120, 23)
        TextBoxPlateNumber.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(42, 85)
        Label2.Name = "Label2"
        Label2.Size = New Size(88, 15)
        Label2.TabIndex = 6
        Label2.Text = "Phone Number"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(42, 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 7
        Label3.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(42, 196)
        Label4.Name = "Label4"
        Label4.Size = New Size(49, 15)
        Label4.TabIndex = 8
        Label4.Text = "Address"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(42, 323)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 15)
        Label5.TabIndex = 9
        Label5.Text = "Plate Number"
        ' 
        ' addBtn
        ' 
        addBtn.Location = New Point(42, 423)
        addBtn.Name = "addBtn"
        addBtn.Size = New Size(261, 43)
        addBtn.TabIndex = 10
        addBtn.Text = "Add"
        addBtn.UseVisualStyleBackColor = True
        ' 
        ' AddCustomer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        ClientSize = New Size(357, 540)
        Controls.Add(addBtn)
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
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.None
        MaximumSize = New Size(357, 540)
        Name = "AddCustomer"
        StartPosition = FormStartPosition.CenterScreen
        Text = "AddCustomer"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents TextBoxNumber As TextBox
    Friend WithEvents TextBoxEmail As TextBox
    Friend WithEvents TextBoxAddress As TextBox
    Friend WithEvents TextBoxPlateNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents addBtn As Button
End Class
