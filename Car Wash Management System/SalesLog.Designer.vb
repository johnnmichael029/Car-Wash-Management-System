<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesLog
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
        DataGridView1 = New DataGridView()
        TextBoxSales = New TextBox()
        TextBoxPrice = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        createBtn = New Button()
        Button2 = New Button()
        backBtn = New Button()
        updateBtn = New Button()
        deleteBtn = New Button()
        readBtn = New Button()
        Label4 = New Label()
        ComboBoxVehicle = New ComboBox()
        ComboBoxService = New ComboBox()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(51, 48)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(660, 286)
        DataGridView1.TabIndex = 0
        ' 
        ' TextBoxSales
        ' 
        TextBoxSales.Enabled = False
        TextBoxSales.Location = New Point(51, 376)
        TextBoxSales.Name = "TextBoxSales"
        TextBoxSales.Size = New Size(145, 23)
        TextBoxSales.TabIndex = 1
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(456, 376)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(123, 23)
        TextBoxPrice.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(51, 358)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 4
        Label1.Text = "Sales ID"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(202, 358)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 15)
        Label2.TabIndex = 5
        Label2.Text = "Vehicle"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(456, 358)
        Label3.Name = "Label3"
        Label3.Size = New Size(33, 15)
        Label3.TabIndex = 6
        Label3.Text = "Price"
        ' 
        ' createBtn
        ' 
        createBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        createBtn.Location = New Point(728, 48)
        createBtn.Name = "createBtn"
        createBtn.Size = New Size(150, 53)
        createBtn.TabIndex = 7
        createBtn.Text = "Create"
        createBtn.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(993, 12)
        Button2.Name = "Button2"
        Button2.Size = New Size(99, 38)
        Button2.TabIndex = 8
        Button2.Text = "Exit"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' backBtn
        ' 
        backBtn.Location = New Point(993, 433)
        backBtn.Name = "backBtn"
        backBtn.Size = New Size(99, 36)
        backBtn.TabIndex = 11
        backBtn.Text = "Back"
        backBtn.UseVisualStyleBackColor = True
        ' 
        ' updateBtn
        ' 
        updateBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateBtn.Location = New Point(728, 200)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(150, 53)
        updateBtn.TabIndex = 12
        updateBtn.Text = "Update"
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' deleteBtn
        ' 
        deleteBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteBtn.Location = New Point(728, 281)
        deleteBtn.Name = "deleteBtn"
        deleteBtn.Size = New Size(150, 53)
        deleteBtn.TabIndex = 13
        deleteBtn.Text = "Delete"
        deleteBtn.UseVisualStyleBackColor = True
        ' 
        ' readBtn
        ' 
        readBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        readBtn.Location = New Point(728, 122)
        readBtn.Name = "readBtn"
        readBtn.Size = New Size(150, 53)
        readBtn.TabIndex = 14
        readBtn.Text = "Read"
        readBtn.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(324, 358)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 15
        Label4.Text = "Service"
        ' 
        ' ComboBoxVehicle
        ' 
        ComboBoxVehicle.AutoCompleteCustomSource.AddRange(New String() {"HatchBack", "Sedan", "Compact", "Montero", "Fortuner", "Innova", "Adventure", "Crosswind", "Everest", "Ertiga", "Veloz", "Changan", "Pick Up", "Van", "L300", "Travis", "Jeep", "Big bike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxVehicle.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxVehicle.FormattingEnabled = True
        ComboBoxVehicle.Items.AddRange(New Object() {"HatchBack", "Sedan", "Compact", "Montero", "Fortuner", "Innova", "Adventure", "Crosswind", "Everest", "Ertiga", "Veloz", "Changan", "Pick Up", "Van", "L300", "Travis", "Jeep", "Big bike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxVehicle.Location = New Point(202, 376)
        ComboBoxVehicle.Name = "ComboBoxVehicle"
        ComboBoxVehicle.Size = New Size(121, 23)
        ComboBoxVehicle.TabIndex = 16
        ' 
        ' ComboBoxService
        ' 
        ComboBoxService.AutoCompleteCustomSource.AddRange(New String() {"HatchBack", "Sedan", "Compact", "SUV", "Utility", "Ebike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxService.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxService.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxService.FormattingEnabled = True
        ComboBoxService.Items.AddRange(New Object() {"Armor", "Wax", "Engine Wash"})
        ComboBoxService.Location = New Point(329, 376)
        ComboBoxService.Name = "ComboBoxService"
        ComboBoxService.Size = New Size(121, 23)
        ComboBoxService.TabIndex = 17
        ' 
        ' SalesLog
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1104, 501)
        Controls.Add(ComboBoxService)
        Controls.Add(ComboBoxVehicle)
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
        Controls.Add(TextBoxPrice)
        Controls.Add(TextBoxSales)
        Controls.Add(DataGridView1)
        Name = "SalesLog"
        Text = "Sales log"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBoxSales As TextBox
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents createBtn As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents backBtn As Button
    Friend WithEvents updateBtn As Button
    Friend WithEvents deleteBtn As Button
    Friend WithEvents readBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxVehicle As ComboBox
    Friend WithEvents ComboBoxService As ComboBox
End Class
