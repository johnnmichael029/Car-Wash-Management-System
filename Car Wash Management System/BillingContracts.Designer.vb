<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillingContracts
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
        Panel3 = New Panel()
        LabelSales = New Label()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddon = New ComboBox()
        Label10 = New Label()
        ComboBoxServices = New ComboBox()
        LabelContractID = New Label()
        Label9 = New Label()
        Label8 = New Label()
        ComboBoxContractStatus = New ComboBox()
        TextBoxPrice = New TextBox()
        ComboBoxBillingFrequency = New ComboBox()
        DateTimePickerEndDate = New DateTimePicker()
        Label7 = New Label()
        DateTimePickerStartDate = New DateTimePicker()
        Label6 = New Label()
        Label5 = New Label()
        LabelServiceID = New Label()
        Label4 = New Label()
        deleteServiceBtn = New Button()
        updateServiceBtn = New Button()
        viewServiceBtn = New Button()
        addServiceBtn = New Button()
        Label3 = New Label()
        TextBoxCustomerID = New TextBox()
        Label2 = New Label()
        TextBoxCustomerName = New TextBox()
        Label1 = New Label()
        Panel1 = New Panel()
        DataGridView1 = New DataGridView()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.FromArgb(CByte(254), CByte(251), CByte(251))
        Panel3.Controls.Add(LabelSales)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddon)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(ComboBoxServices)
        Panel3.Controls.Add(LabelContractID)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(ComboBoxContractStatus)
        Panel3.Controls.Add(TextBoxPrice)
        Panel3.Controls.Add(ComboBoxBillingFrequency)
        Panel3.Controls.Add(DateTimePickerEndDate)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(DateTimePickerStartDate)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(deleteServiceBtn)
        Panel3.Controls.Add(updateServiceBtn)
        Panel3.Controls.Add(viewServiceBtn)
        Panel3.Controls.Add(addServiceBtn)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(TextBoxCustomerID)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(TextBoxCustomerName)
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(606, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(305, 611)
        Panel3.TabIndex = 2
        ' 
        ' LabelSales
        ' 
        LabelSales.AutoSize = True
        LabelSales.ForeColor = Color.Red
        LabelSales.Location = New Point(209, 457)
        LabelSales.Name = "LabelSales"
        LabelSales.Size = New Size(0, 15)
        LabelSales.TabIndex = 29
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(15, 325)
        Label11.Name = "Label11"
        Label11.Size = New Size(99, 15)
        Label11.TabIndex = 28
        Label11.Text = "Payment Method"
        ' 
        ' ComboBoxPaymentMethod
        ' 
        ComboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(New String() {"Gcash", "Cheque", "Cash"})
        ComboBoxPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Location = New Point(16, 343)
        ComboBoxPaymentMethod.Name = "ComboBoxPaymentMethod"
        ComboBoxPaymentMethod.Size = New Size(262, 23)
        ComboBoxPaymentMethod.TabIndex = 27
        ' 
        ' ComboBoxAddon
        ' 
        ComboBoxAddon.FormattingEnabled = True
        ComboBoxAddon.Location = New Point(16, 159)
        ComboBoxAddon.Name = "ComboBoxAddon"
        ComboBoxAddon.Size = New Size(261, 23)
        ComboBoxAddon.TabIndex = 26
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(15, 141)
        Label10.Name = "Label10"
        Label10.Size = New Size(43, 15)
        Label10.TabIndex = 25
        Label10.Text = "Addon"
        ' 
        ' ComboBoxServices
        ' 
        ComboBoxServices.FormattingEnabled = True
        ComboBoxServices.Location = New Point(16, 115)
        ComboBoxServices.Name = "ComboBoxServices"
        ComboBoxServices.Size = New Size(261, 23)
        ComboBoxServices.TabIndex = 24
        ' 
        ' LabelContractID
        ' 
        LabelContractID.AutoSize = True
        LabelContractID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelContractID.ForeColor = Color.Red
        LabelContractID.Location = New Point(82, 457)
        LabelContractID.Name = "LabelContractID"
        LabelContractID.Size = New Size(0, 15)
        LabelContractID.TabIndex = 23
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(16, 457)
        Label9.Name = "Label9"
        Label9.Size = New Size(67, 15)
        Label9.TabIndex = 22
        Label9.Text = "Contract ID"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(16, 413)
        Label8.Name = "Label8"
        Label8.Size = New Size(88, 15)
        Label8.TabIndex = 21
        Label8.Text = "Contract Status"
        ' 
        ' ComboBoxContractStatus
        ' 
        ComboBoxContractStatus.AutoCompleteCustomSource.AddRange(New String() {"Active", "Expired", "Cancelled"})
        ComboBoxContractStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxContractStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxContractStatus.FormattingEnabled = True
        ComboBoxContractStatus.Items.AddRange(New Object() {"Active", "Expired", "Cancelled"})
        ComboBoxContractStatus.Location = New Point(16, 431)
        ComboBoxContractStatus.Name = "ComboBoxContractStatus"
        ComboBoxContractStatus.Size = New Size(261, 23)
        ComboBoxContractStatus.TabIndex = 20
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 387)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 19
        ' 
        ' ComboBoxBillingFrequency
        ' 
        ComboBoxBillingFrequency.AutoCompleteCustomSource.AddRange(New String() {"Monthly", "Quarterly ", "Yearly"})
        ComboBoxBillingFrequency.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxBillingFrequency.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxBillingFrequency.FormattingEnabled = True
        ComboBoxBillingFrequency.Items.AddRange(New Object() {"Monthly", "Quarterly ", "Yearly"})
        ComboBoxBillingFrequency.Location = New Point(16, 294)
        ComboBoxBillingFrequency.Name = "ComboBoxBillingFrequency"
        ComboBoxBillingFrequency.Size = New Size(261, 23)
        ComboBoxBillingFrequency.TabIndex = 18
        ' 
        ' DateTimePickerEndDate
        ' 
        DateTimePickerEndDate.Location = New Point(16, 250)
        DateTimePickerEndDate.Name = "DateTimePickerEndDate"
        DateTimePickerEndDate.Size = New Size(261, 23)
        DateTimePickerEndDate.TabIndex = 17
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(16, 232)
        Label7.Name = "Label7"
        Label7.Size = New Size(54, 15)
        Label7.TabIndex = 16
        Label7.Text = "End Date"
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.Location = New Point(16, 206)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(261, 23)
        DateTimePickerStartDate.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(16, 188)
        Label6.Name = "Label6"
        Label6.Size = New Size(58, 15)
        Label6.TabIndex = 14
        Label6.Text = "Start Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(16, 97)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 15)
        Label5.TabIndex = 12
        Label5.Text = "Services"
        ' 
        ' LabelServiceID
        ' 
        LabelServiceID.AutoSize = True
        LabelServiceID.Location = New Point(72, 406)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(16, 369)
        Label4.Name = "Label4"
        Label4.Size = New Size(33, 15)
        Label4.TabIndex = 10
        Label4.Text = "Price"
        ' 
        ' deleteServiceBtn
        ' 
        deleteServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        deleteServiceBtn.Location = New Point(16, 574)
        deleteServiceBtn.Name = "deleteServiceBtn"
        deleteServiceBtn.Size = New Size(260, 30)
        deleteServiceBtn.TabIndex = 9
        deleteServiceBtn.Text = "Delete Service"
        deleteServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' updateServiceBtn
        ' 
        updateServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        updateServiceBtn.Location = New Point(16, 541)
        updateServiceBtn.Name = "updateServiceBtn"
        updateServiceBtn.Size = New Size(260, 30)
        updateServiceBtn.TabIndex = 8
        updateServiceBtn.Text = "Update Service"
        updateServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' viewServiceBtn
        ' 
        viewServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        viewServiceBtn.Location = New Point(16, 508)
        viewServiceBtn.Name = "viewServiceBtn"
        viewServiceBtn.Size = New Size(260, 30)
        viewServiceBtn.TabIndex = 7
        viewServiceBtn.Text = "View Service"
        viewServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' addServiceBtn
        ' 
        addServiceBtn.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold)
        addServiceBtn.Location = New Point(16, 475)
        addServiceBtn.Name = "addServiceBtn"
        addServiceBtn.Size = New Size(260, 30)
        addServiceBtn.TabIndex = 6
        addServiceBtn.Text = "Add Service"
        addServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(16, 276)
        Label3.Name = "Label3"
        Label3.Size = New Size(98, 15)
        Label3.TabIndex = 4
        Label3.Text = "Billing Frequency"
        ' 
        ' TextBoxCustomerID
        ' 
        TextBoxCustomerID.Location = New Point(16, 71)
        TextBoxCustomerID.Name = "TextBoxCustomerID"
        TextBoxCustomerID.ReadOnly = True
        TextBoxCustomerID.Size = New Size(261, 23)
        TextBoxCustomerID.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 15)
        Label2.TabIndex = 2
        Label2.Text = "Customer ID"
        ' 
        ' TextBoxCustomerName
        ' 
        TextBoxCustomerName.Location = New Point(16, 27)
        TextBoxCustomerName.Name = "TextBoxCustomerName"
        TextBoxCustomerName.Size = New Size(261, 23)
        TextBoxCustomerName.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 15)
        Label1.TabIndex = 0
        Label1.Text = "Customer Name"
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 611)
        Panel1.TabIndex = 2
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = SystemColors.ControlLight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.Size = New Size(606, 611)
        DataGridView1.TabIndex = 0
        ' 
        ' BillingContracts
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(911, 611)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "BillingContracts"
        Text = "BillingContracts"
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents deleteServiceBtn As Button
    Friend WithEvents updateServiceBtn As Button
    Friend WithEvents viewServiceBtn As Button
    Friend WithEvents addServiceBtn As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePickerEndDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxContractStatus As ComboBox
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents ComboBoxBillingFrequency As ComboBox
    Friend WithEvents LabelContractID As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBoxAddon As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents LabelSales As Label
End Class
