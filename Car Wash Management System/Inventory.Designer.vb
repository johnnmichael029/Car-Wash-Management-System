<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Inventory
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
        readBtn = New Button()
        deleteBtn = New Button()
        updateBtn = New Button()
        backBtn = New Button()
        Button2 = New Button()
        createBtn = New Button()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        TextBoxName = New TextBox()
        TextBoxProduct = New TextBox()
        DataGridView1 = New DataGridView()
        Label4 = New Label()
        TextBoxPrice = New TextBox()
        stockNumeric = New NumericUpDown()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(stockNumeric, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' readBtn
        ' 
        readBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        readBtn.Location = New Point(602, 128)
        readBtn.Name = "readBtn"
        readBtn.Size = New Size(150, 53)
        readBtn.TabIndex = 28
        readBtn.Text = "Read"
        readBtn.UseVisualStyleBackColor = True
        ' 
        ' deleteBtn
        ' 
        deleteBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteBtn.Location = New Point(602, 287)
        deleteBtn.Name = "deleteBtn"
        deleteBtn.Size = New Size(150, 53)
        deleteBtn.TabIndex = 27
        deleteBtn.Text = "Delete"
        deleteBtn.UseVisualStyleBackColor = True
        ' 
        ' updateBtn
        ' 
        updateBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateBtn.Location = New Point(602, 206)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(150, 53)
        updateBtn.TabIndex = 26
        updateBtn.Text = "Update"
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' backBtn
        ' 
        backBtn.Location = New Point(798, 100)
        backBtn.Name = "backBtn"
        backBtn.Size = New Size(99, 36)
        backBtn.TabIndex = 25
        backBtn.Text = "Back"
        backBtn.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(798, 39)
        Button2.Name = "Button2"
        Button2.Size = New Size(99, 38)
        Button2.TabIndex = 23
        Button2.Text = "Exit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' createBtn
        ' 
        createBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        createBtn.Location = New Point(602, 54)
        createBtn.Name = "createBtn"
        createBtn.Size = New Size(150, 53)
        createBtn.TabIndex = 22
        createBtn.Text = "Create"
        createBtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(357, 364)
        Label3.Name = "Label3"
        Label3.Size = New Size(36, 15)
        Label3.TabIndex = 21
        Label3.Text = "Stock"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(206, 364)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 15)
        Label2.TabIndex = 20
        Label2.Text = "Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(55, 364)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 15)
        Label1.TabIndex = 19
        Label1.Text = "Product ID"
        ' 
        ' TextBoxName
        ' 
        TextBoxName.Location = New Point(206, 382)
        TextBoxName.Name = "TextBoxName"
        TextBoxName.Size = New Size(145, 23)
        TextBoxName.TabIndex = 17
        ' 
        ' TextBoxProduct
        ' 
        TextBoxProduct.Enabled = False
        TextBoxProduct.Location = New Point(55, 382)
        TextBoxProduct.Name = "TextBoxProduct"
        TextBoxProduct.Size = New Size(145, 23)
        TextBoxProduct.TabIndex = 16
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(55, 54)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(528, 286)
        DataGridView1.TabIndex = 15
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(508, 364)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 29
        Label4.Text = "Price"
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(508, 382)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.Size = New Size(75, 23)
        TextBoxPrice.TabIndex = 30
        ' 
        ' stockNumeric
        ' 
        stockNumeric.Location = New Point(357, 383)
        stockNumeric.Name = "stockNumeric"
        stockNumeric.Size = New Size(145, 23)
        stockNumeric.TabIndex = 31
        ' 
        ' Inventory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(916, 538)
        Controls.Add(stockNumeric)
        Controls.Add(TextBoxPrice)
        Controls.Add(Label4)
        Controls.Add(readBtn)
        Controls.Add(deleteBtn)
        Controls.Add(updateBtn)
        Controls.Add(backBtn)
        Controls.Add(Button2)
        Controls.Add(createBtn)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TextBoxName)
        Controls.Add(TextBoxProduct)
        Controls.Add(DataGridView1)
        Name = "Inventory"
        Text = "Inventory"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(stockNumeric, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents readBtn As Button
    Friend WithEvents deleteBtn As Button
    Friend WithEvents updateBtn As Button
    Friend WithEvents backBtn As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents createBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxName As TextBox
    Friend WithEvents TextBoxProduct As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents stockNumeric As NumericUpDown
End Class
