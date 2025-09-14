<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appointment
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
        LabelSales = New Label()
        LabelAppointmentID = New Label()
        TextBoxNotes = New TextBox()
        Label3 = New Label()
        Label11 = New Label()
        ComboBoxPaymentMethod = New ComboBox()
        ComboBoxAddon = New ComboBox()
        Label10 = New Label()
        ComboBoxServices = New ComboBox()
        Label9 = New Label()
        Label8 = New Label()
        ComboBoxAppointmentStatus = New ComboBox()
        TextBoxPrice = New TextBox()
        DateTimePickerStartDate = New DateTimePicker()
        Label6 = New Label()
        Label5 = New Label()
        LabelServiceID = New Label()
        Label4 = New Label()
        UpdateServiceBtn = New Button()
        ViewServiceBtn = New Button()
        AddServiceBtn = New Button()
        TextBoxCustomerID = New TextBox()
        Label2 = New Label()
        TextBoxCustomerName = New TextBox()
        Label1 = New Label()
        Label7 = New Label()
        DeleteServiceBtn = New Button()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(Panel3)
        Panel1.Location = New Point(0, 53)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(911, 635)
        Panel1.TabIndex = 3
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
        DataGridView1.Size = New Size(606, 635)
        DataGridView1.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.White
        Panel3.Controls.Add(LabelSales)
        Panel3.Controls.Add(LabelAppointmentID)
        Panel3.Controls.Add(TextBoxNotes)
        Panel3.Controls.Add(Label3)
        Panel3.Controls.Add(Label11)
        Panel3.Controls.Add(ComboBoxPaymentMethod)
        Panel3.Controls.Add(ComboBoxAddon)
        Panel3.Controls.Add(Label10)
        Panel3.Controls.Add(ComboBoxServices)
        Panel3.Controls.Add(Label9)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(ComboBoxAppointmentStatus)
        Panel3.Controls.Add(TextBoxPrice)
        Panel3.Controls.Add(DateTimePickerStartDate)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(LabelServiceID)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(DeleteServiceBtn)
        Panel3.Controls.Add(UpdateServiceBtn)
        Panel3.Controls.Add(ViewServiceBtn)
        Panel3.Controls.Add(AddServiceBtn)
        Panel3.Controls.Add(TextBoxCustomerID)
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(TextBoxCustomerName)
        Panel3.Controls.Add(Label1)
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(606, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(305, 635)
        Panel3.TabIndex = 2
        ' 
        ' LabelSales
        ' 
        LabelSales.AutoSize = True
        LabelSales.ForeColor = Color.Red
        LabelSales.Location = New Point(204, 457)
        LabelSales.Name = "LabelSales"
        LabelSales.Size = New Size(0, 15)
        LabelSales.TabIndex = 32
        ' 
        ' LabelAppointmentID
        ' 
        LabelAppointmentID.AutoSize = True
        LabelAppointmentID.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        LabelAppointmentID.ForeColor = Color.Red
        LabelAppointmentID.Location = New Point(104, 457)
        LabelAppointmentID.Name = "LabelAppointmentID"
        LabelAppointmentID.Size = New Size(0, 15)
        LabelAppointmentID.TabIndex = 31
        ' 
        ' TextBoxNotes
        ' 
        TextBoxNotes.Location = New Point(16, 382)
        TextBoxNotes.Multiline = True
        TextBoxNotes.Name = "TextBoxNotes"
        TextBoxNotes.Size = New Size(260, 72)
        TextBoxNotes.TabIndex = 30
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 9F)
        Label3.Location = New Point(15, 364)
        Label3.Name = "Label3"
        Label3.Size = New Size(43, 17)
        Label3.TabIndex = 29
        Label3.Text = "Notes"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Century Gothic", 9F)
        Label11.Location = New Point(15, 232)
        Label11.Name = "Label11"
        Label11.Size = New Size(110, 17)
        Label11.TabIndex = 28
        Label11.Text = "Payment Method"
        ' 
        ' ComboBoxPaymentMethod
        ' 
        ComboBoxPaymentMethod.AutoCompleteCustomSource.AddRange(New String() {"Gcash", "Cheque", "Cash"})
        ComboBoxPaymentMethod.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxPaymentMethod.AutoCompleteSource = AutoCompleteSource.ListItems
        ComboBoxPaymentMethod.FormattingEnabled = True
        ComboBoxPaymentMethod.Items.AddRange(New Object() {"Cash", "Gcash", "Cheque"})
        ComboBoxPaymentMethod.Location = New Point(16, 250)
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
        Label10.Font = New Font("Century Gothic", 9F)
        Label10.Location = New Point(15, 141)
        Label10.Name = "Label10"
        Label10.Size = New Size(48, 17)
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
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 9F)
        Label9.Location = New Point(15, 457)
        Label9.Name = "Label9"
        Label9.Size = New Size(102, 17)
        Label9.TabIndex = 22
        Label9.Text = "Appointment ID"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 9F)
        Label8.Location = New Point(16, 320)
        Label8.Name = "Label8"
        Label8.Size = New Size(127, 17)
        Label8.TabIndex = 21
        Label8.Text = "Appointment Status"
        ' 
        ' ComboBoxAppointmentStatus
        ' 
        ComboBoxAppointmentStatus.AutoCompleteCustomSource.AddRange(New String() {"Pending", "Confirmed", "Cancelled", "No-Show", "Completed"})
        ComboBoxAppointmentStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComboBoxAppointmentStatus.AutoCompleteSource = AutoCompleteSource.CustomSource
        ComboBoxAppointmentStatus.FormattingEnabled = True
        ComboBoxAppointmentStatus.Items.AddRange(New Object() {"Pending", "Confirmed", "Cancelled", "No-Show", "Completed"})
        ComboBoxAppointmentStatus.Location = New Point(16, 338)
        ComboBoxAppointmentStatus.Name = "ComboBoxAppointmentStatus"
        ComboBoxAppointmentStatus.Size = New Size(261, 23)
        ComboBoxAppointmentStatus.TabIndex = 20
        ' 
        ' TextBoxPrice
        ' 
        TextBoxPrice.Location = New Point(16, 294)
        TextBoxPrice.Name = "TextBoxPrice"
        TextBoxPrice.Size = New Size(261, 23)
        TextBoxPrice.TabIndex = 19
        ' 
        ' DateTimePickerStartDate
        ' 
        DateTimePickerStartDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        DateTimePickerStartDate.Format = DateTimePickerFormat.Custom
        DateTimePickerStartDate.ImeMode = ImeMode.NoControl
        DateTimePickerStartDate.Location = New Point(16, 206)
        DateTimePickerStartDate.Name = "DateTimePickerStartDate"
        DateTimePickerStartDate.Size = New Size(261, 23)
        DateTimePickerStartDate.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 9F)
        Label6.Location = New Point(16, 188)
        Label6.Name = "Label6"
        Label6.Size = New Size(120, 17)
        Label6.TabIndex = 14
        Label6.Text = "Appointment Date"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 9F)
        Label5.Location = New Point(16, 97)
        Label5.Name = "Label5"
        Label5.Size = New Size(59, 17)
        Label5.TabIndex = 12
        Label5.Text = "Services"
        ' 
        ' LabelServiceID
        ' 
        LabelServiceID.AutoSize = True
        LabelServiceID.Location = New Point(72, 313)
        LabelServiceID.Name = "LabelServiceID"
        LabelServiceID.Size = New Size(0, 15)
        LabelServiceID.TabIndex = 11
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 9F)
        Label4.Location = New Point(16, 276)
        Label4.Name = "Label4"
        Label4.Size = New Size(38, 17)
        Label4.TabIndex = 10
        Label4.Text = "Price"
        ' 
        ' UpdateServiceBtn
        ' 
        UpdateServiceBtn.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        UpdateServiceBtn.Location = New Point(16, 541)
        UpdateServiceBtn.Name = "UpdateServiceBtn"
        UpdateServiceBtn.Size = New Size(260, 30)
        UpdateServiceBtn.TabIndex = 8
        UpdateServiceBtn.Text = "Update Service"
        UpdateServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' ViewServiceBtn
        ' 
        ViewServiceBtn.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        ViewServiceBtn.Location = New Point(16, 508)
        ViewServiceBtn.Name = "ViewServiceBtn"
        ViewServiceBtn.Size = New Size(260, 30)
        ViewServiceBtn.TabIndex = 7
        ViewServiceBtn.Text = "View Service"
        ViewServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' AddServiceBtn
        ' 
        AddServiceBtn.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        AddServiceBtn.Location = New Point(16, 475)
        AddServiceBtn.Name = "AddServiceBtn"
        AddServiceBtn.Size = New Size(260, 30)
        AddServiceBtn.TabIndex = 6
        AddServiceBtn.Text = "Add Service"
        AddServiceBtn.UseVisualStyleBackColor = True
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
        Label2.Font = New Font("Century Gothic", 9F)
        Label2.Location = New Point(16, 53)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 17)
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
        Label1.Font = New Font("Century Gothic", 9F)
        Label1.Location = New Point(16, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(104, 17)
        Label1.TabIndex = 0
        Label1.Text = "Customer Name"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 26.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(0, 3)
        Label7.Name = "Label7"
        Label7.Size = New Size(337, 41)
        Label7.TabIndex = 4
        Label7.Text = "List of Appointment"
        ' 
        ' DeleteServiceBtn
        ' 
        DeleteServiceBtn.Font = New Font("Century Gothic", 12F, FontStyle.Bold)
        DeleteServiceBtn.Location = New Point(16, 574)
        DeleteServiceBtn.Name = "DeleteServiceBtn"
        DeleteServiceBtn.Size = New Size(260, 30)
        DeleteServiceBtn.TabIndex = 9
        DeleteServiceBtn.Text = "Delete Service"
        DeleteServiceBtn.UseVisualStyleBackColor = True
        ' 
        ' Appointment
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(241), CByte(244), CByte(254))
        ClientSize = New Size(911, 687)
        Controls.Add(Label7)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Appointment"
        Text = "Appointment"
        Panel1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBoxPaymentMethod As ComboBox
    Friend WithEvents ComboBoxAddon As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBoxServices As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBoxAppointmentStatus As ComboBox
    Friend WithEvents TextBoxPrice As TextBox
    Friend WithEvents DateTimePickerStartDate As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelServiceID As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents UpdateServiceBtn As Button
    Friend WithEvents ViewServiceBtn As Button
    Friend WithEvents AddServiceBtn As Button
    Friend WithEvents TextBoxCustomerID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxNotes As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LabelAppointmentID As Label
    Friend WithEvents LabelSales As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DeleteServiceBtn As Button
End Class
