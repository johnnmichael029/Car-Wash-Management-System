<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Button5 = New Button()
        expenseBtn = New Button()
        inventoryBtn = New Button()
        salesLogBtn = New Button()
        dashboardBtn = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(740, 12)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 23)
        Button5.TabIndex = 11
        Button5.Text = "Exit"
        Button5.UseVisualStyleBackColor = True
        ' 
        ' expenseBtn
        ' 
        expenseBtn.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold)
        expenseBtn.Location = New Point(29, 341)
        expenseBtn.Name = "expenseBtn"
        expenseBtn.Size = New Size(151, 64)
        expenseBtn.TabIndex = 10
        expenseBtn.Text = "Expense"
        expenseBtn.UseVisualStyleBackColor = True
        ' 
        ' inventoryBtn
        ' 
        inventoryBtn.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold)
        inventoryBtn.Location = New Point(29, 271)
        inventoryBtn.Name = "inventoryBtn"
        inventoryBtn.Size = New Size(151, 64)
        inventoryBtn.TabIndex = 9
        inventoryBtn.Text = "Inventory"
        inventoryBtn.UseVisualStyleBackColor = True
        ' 
        ' salesLogBtn
        ' 
        salesLogBtn.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold)
        salesLogBtn.Location = New Point(29, 201)
        salesLogBtn.Name = "salesLogBtn"
        salesLogBtn.Size = New Size(151, 64)
        salesLogBtn.TabIndex = 8
        salesLogBtn.Text = "Sales Log"
        salesLogBtn.UseVisualStyleBackColor = True
        ' 
        ' dashboardBtn
        ' 
        dashboardBtn.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold)
        dashboardBtn.Location = New Point(29, 131)
        dashboardBtn.Name = "dashboardBtn"
        dashboardBtn.Size = New Size(151, 64)
        dashboardBtn.TabIndex = 7
        dashboardBtn.Text = "Dashboard"
        dashboardBtn.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 36F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(29, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(766, 65)
        Label1.TabIndex = 6
        Label1.Text = "Car Wash Management System"
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(843, 463)
        Controls.Add(Button5)
        Controls.Add(expenseBtn)
        Controls.Add(inventoryBtn)
        Controls.Add(salesLogBtn)
        Controls.Add(dashboardBtn)
        Controls.Add(Label1)
        Name = "Dashboard"
        Text = "Dashboard"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button5 As Button
    Friend WithEvents expenseBtn As Button
    Friend WithEvents inventoryBtn As Button
    Friend WithEvents salesLogBtn As Button
    Friend WithEvents dashboardBtn As Button
    Friend WithEvents Label1 As Label
End Class
