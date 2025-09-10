<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesHistory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesHistory))
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        deleteBtn = New Button()
        readBtn = New Button()
        updateBtn = New Button()
        ComboBoxService = New ComboBox()
        TextBoxSales = New TextBox()
        ComboBoxVehicle = New ComboBox()
        createBtn = New Button()
        TextBoxPrice = New TextBox()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(606, 551)
        DataGridView1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(47, 15)
        Label1.TabIndex = 4
        Label1.Text = "Sales ID"
        ' 
        ' deleteBtn
        ' 
        deleteBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        deleteBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteBtn.Image = My.Resources.Resources.trash
        deleteBtn.Location = New Point(16, 367)
        deleteBtn.Name = "deleteBtn"
        deleteBtn.Size = New Size(261, 39)
        deleteBtn.TabIndex = 13
        deleteBtn.Text = "Delete"
        deleteBtn.TextAlign = ContentAlignment.MiddleRight
        deleteBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        deleteBtn.UseVisualStyleBackColor = True
        ' 
        ' readBtn
        ' 
        readBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        readBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        readBtn.Image = My.Resources.Resources.book1
        readBtn.Location = New Point(16, 277)
        readBtn.Name = "readBtn"
        readBtn.Size = New Size(261, 39)
        readBtn.TabIndex = 14
        readBtn.Text = "Read"
        readBtn.TextAlign = ContentAlignment.MiddleRight
        readBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        readBtn.UseVisualStyleBackColor = True
        ' 
        ' updateBtn
        ' 
        updateBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        updateBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateBtn.Image = My.Resources.Resources.refresh
        updateBtn.Location = New Point(16, 322)
        updateBtn.Name = "updateBtn"
        updateBtn.Size = New Size(261, 39)
        updateBtn.TabIndex = 12
        updateBtn.Text = "Update"
        updateBtn.TextAlign = ContentAlignment.MiddleRight
        updateBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        updateBtn.UseVisualStyleBackColor = True
        ' 
        ' ComboBoxService
        ' 
        ComboBoxService.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxService.AutoCompleteCustomSource.AddRange(New String() {"HatchBack", "Sedan", "Compact", "SUV", "Utility", "Ebike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxService.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxService.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxService.FormattingEnabled = True
        ComboBoxService.Items.AddRange(New Object() {"Armor", "Wax", "Engine Wash"})
        ComboBoxService.Location = New Point(16, 130)
        ComboBoxService.Name = "ComboBoxService"
        ComboBoxService.Size = New Size(261, 23)
        ComboBoxService.TabIndex = 17
        ' 
        ' TextBoxSales
        ' 
        TextBoxSales.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBoxSales.Enabled = False
        TextBoxSales.Location = New Point(16, 27)
        TextBoxSales.Name = "TextBoxSales"
        TextBoxSales.ReadOnly = True
        TextBoxSales.Size = New Size(261, 23)
        TextBoxSales.TabIndex = 1
        ' 
        ' ComboBoxVehicle
        ' 
        ComboBoxVehicle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ComboBoxVehicle.AutoCompleteCustomSource.AddRange(New String() {"HatchBack", "Sedan", "Compact", "Montero", "Fortuner", "Innova", "Adventure", "Crosswind", "Everest", "Ertiga", "Veloz", "Changan", "Pick Up", "Van", "L300", "Travis", "Jeep", "Big bike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxVehicle.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxVehicle.FormattingEnabled = True
        ComboBoxVehicle.Items.AddRange(New Object() {"HatchBack", "Sedan", "Compact", "Montero", "Fortuner", "Innova", "Adventure", "Crosswind", "Everest", "Ertiga", "Veloz", "Changan", "Pick Up", "Van", "L300", "Travis", "Jeep", "Big bike", "150CC", "120CC", "100CC", "Tricycle"})
        ComboBoxVehicle.Location = New Point(16, 71)
        ComboBoxVehicle.Name = "ComboBoxVehicle"
        ComboBoxVehicle.Size = New Size(261, 23)
        ComboBoxVehicle.TabIndex = 16
        ' 
        ' createBtn
        ' 
        createBtn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        createBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        createBtn.Image = CType(resources.GetObject("createBtn.Image"), Image)
        createBtn.Location = New Point(16, 232)
        createBtn.Name = "createBtn"
        createBtn.Size = New Size(261, 39)
        createBtn.TabIndex = 7
        createBtn.Text = "Create"
        createBtn.TextAlign = ContentAlignment.MiddleRight
        createBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        createBtn.UseVisualStyleBackColor = True
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TextBoxPrice.Location = New Point(16, 185)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.ReadOnly = True
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 112)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 15)
        Label4.TabIndex = 15
        Label4.Text = "Service"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 15)
        Label2.TabIndex = 5
        Label2.Text = "Vehicle"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 167)
        Label3.Name = "Label3"
        Label3.Size = New Size(33, 15)
        Label3.TabIndex = 6
        Label3.Text = "Price"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(deleteBtn)
        Panel1.Controls.Add(readBtn)
        Panel1.Controls.Add(updateBtn)
        Panel1.Controls.Add(ComboBoxService)
        Panel1.Controls.Add(TextBoxSales)
        Panel1.Controls.Add(ComboBoxVehicle)
        Panel1.Controls.Add(createBtn)
        Panel1.Controls.Add(TextBoxPrice)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label3)
        Panel1.Dock = DockStyle.Right
        Panel1.Location = New Point(606, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(305, 551)
        Panel1.TabIndex = 18
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Panel3)
        Panel2.Controls.Add(Panel1)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(911, 551)
        Panel2.TabIndex = 20
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(DataGridView1)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(606, 551)
        Panel3.TabIndex = 19
        ' 
        ' SalesHistory
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 551)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.None
        Name = "SalesHistory"
        Text = "SalesHistory"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents deleteBtn As Button
    Friend WithEvents readBtn As Button
    Friend WithEvents updateBtn As Button
    Friend WithEvents ComboBoxService As ComboBox
    Friend WithEvents TextBoxSales As TextBox
    Friend WithEvents ComboBoxVehicle As ComboBox
    Friend WithEvents createBtn As Button
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
