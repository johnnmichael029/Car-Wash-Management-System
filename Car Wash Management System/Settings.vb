Public Class Settings

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()

        ' Load settings into controls
        Me.CheckBoxEnableDiscount.Checked = My.Settings.DiscountEnabled
        Me.CheckBoxFixDiscount.Checked = My.Settings.FixDiscount
        Me.NumericUpDownDiscount.Value = My.Settings.DiscountValue
        Me.CheckBoxTotalPrice.Checked = My.Settings.PriceFieldEnabled

        ' Load selected item from settings
        If Not String.IsNullOrEmpty(My.Settings.SelectedFormItem) Then
            Me.ComboBoxSelectForm.SelectedItem = My.Settings.SelectedFormItem
        End If


        DiscountButtonSave()
        ComboBoxSelectedForm()
        FixDiscountButtonSave()
        EnabledTotalPriceFieldSave()
        SettingsService.DiscountButtonForm(CheckBoxEnableDiscount)
        SettingsService.CheckIfAdmin(CheckBoxEnableDiscount, CheckBoxFixDiscount, NumericUpDownDiscount)
        SettingsService.EnabledTotalPriceFieldState(CheckBoxTotalPrice, ComboBoxSelectForm)

        SaveBtn.Enabled = False
        SaveBtn.Text = "Save"
        SaveBtn.BackColor = Color.LightGreen
        SaveBtn.ForeColor = Color.White
    End Sub

    Private Sub ExitBtn_Click(sender As Object, e As EventArgs) Handles ExitBtn.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxEnableDiscount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEnableDiscount.CheckedChanged
        SaveBtn.Enabled = True
        SaveBtn.Text = "Save"
        SaveBtn.BackColor = Color.Green
        SaveBtn.ForeColor = Color.White

        SettingsService.ApplyDiscountState(CheckBoxEnableDiscount, NumericUpDownDiscount, CheckBoxFixDiscount)
    End Sub

    Private Sub CheckBoxFixDiscount_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFixDiscount.CheckedChanged
        SaveBtn.Enabled = True
        SaveBtn.Text = "Save"
        SaveBtn.BackColor = Color.Green
        SaveBtn.ForeColor = Color.White

    End Sub

    Private Sub DiscountButtonSave()
        My.Settings.FixDiscount = Me.CheckBoxFixDiscount.Checked

        ' Saves the setting immediately on change
        SettingsService.DiscountButtonForm(CheckBoxEnableDiscount)
        My.Settings.Save()
        SettingsService.ApplyDiscountState(Me.CheckBoxEnableDiscount, Me.NumericUpDownDiscount, Me.CheckBoxFixDiscount)
    End Sub

    Private Sub FixDiscountButtonSave()
        My.Settings.DiscountEnabled = Me.CheckBoxEnableDiscount.Checked
        My.Settings.Save()
    End Sub

    Private Sub DiscountValueSave()
        My.Settings.DiscountValue = Me.NumericUpDownDiscount.Value
        ' Saves the setting immediately on change
        My.Settings.Save()
    End Sub

    Private Sub EnabledTotalPriceFieldSave()
        My.Settings.PriceFieldEnabled = Me.CheckBoxTotalPrice.Checked
        My.Settings.Save()
    End Sub

    Public Sub ComboBoxSelectedForm()
        ' Save the selected item's string value
        If Not IsNothing(Me.ComboBoxSelectForm.SelectedItem) Then
            My.Settings.SelectedFormItem = Me.ComboBoxSelectForm.SelectedItem.ToString()
            My.Settings.Save()
        End If
    End Sub

    Private Sub NumericUpDownDiscount_OnClick(sender As Object, e As EventArgs) Handles NumericUpDownDiscount.Click
        SettingsService.CheckIfNumericChanged(NumericUpDownDiscount, SaveBtn)
    End Sub

    Private Sub NumericUpDownDiscount_KeyUp(sender As Object, e As KeyEventArgs) Handles NumericUpDownDiscount.KeyUp
        SettingsService.CheckIfNumericChanged(NumericUpDownDiscount, SaveBtn)
    End Sub

    Private Sub NumericUpDownDiscount_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownDiscount.ValueChanged
        SettingsService.CheckIfNumericChanged(NumericUpDownDiscount, SaveBtn)

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        EnabledTotalPriceFieldSave()
        FixDiscountButtonSave()
        DiscountButtonSave()
        DiscountValueSave()
        ComboBoxSelectedForm()

        SaveBtn.Enabled = False
        SaveBtn.Text = "Saved"
        SaveBtn.BackColor = Color.LightGreen
        SaveBtn.ForeColor = Color.Black
        SettingsService.CheckIfAdmin(CheckBoxEnableDiscount, CheckBoxFixDiscount, NumericUpDownDiscount)
        SettingsService.RefreshAllDiscountControls()
    End Sub

    ' The Cancel button reloads the settings from disk (discarding unsaved changes) and closes the form.
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        My.Settings.Reload()

        Me.Close()
    End Sub

    Private Sub CheckBoxTotalPrice_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTotalPrice.CheckedChanged
        SaveBtn.Enabled = True
        SaveBtn.Text = "Save"
        SaveBtn.BackColor = Color.Green
        SaveBtn.ForeColor = Color.White
        SettingsService.EnabledTotalPriceFieldState(CheckBoxTotalPrice, ComboBoxSelectForm)
    End Sub

    Private Sub ComboBoxSelectForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSelectForm.SelectedIndexChanged
        SaveBtn.Enabled = True
        SaveBtn.Text = "Save"
        SaveBtn.BackColor = Color.Green
        SaveBtn.ForeColor = Color.White
    End Sub
End Class