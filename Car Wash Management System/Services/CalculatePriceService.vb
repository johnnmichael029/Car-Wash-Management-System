Public Class CalculatePriceService
    Public Shared Function GetCurrentDiscount(comboBoxDiscount As ComboBox) As Double
        Dim discount As Double = comboBoxDiscount.SelectedItem
        Return discount
    End Function
    Public Shared Sub CalculateTotalPrice(comboBoxServices As ComboBox, comboBoxAddons As ComboBox, comboBoxDiscount As ComboBox, textBoxPrice As TextBox)
        Dim totalPrice As Decimal = 0.0D
        Dim discountInPercent = GetCurrentDiscount(comboBoxDiscount) / 100

        If comboBoxServices.SelectedIndex <> -1 Then
            Dim baseServiceDetails As SalesService = SalesDatabaseHelper.GetServiceID(comboBoxServices.Text)
            totalPrice += baseServiceDetails.Price.ToString("N2")
        End If

        If comboBoxAddons.SelectedIndex <> -1 Then
            Dim addonServiceDetails As SalesService = SalesDatabaseHelper.GetServiceID(comboBoxAddons.Text)
            totalPrice += addonServiceDetails.Price.ToString("N2")
        End If

        ' Format to 2 decimal places
        Dim discountToDeduc = (totalPrice * discountInPercent)
        totalPrice -= Decimal.Parse(discountToDeduc)
        textBoxPrice.Text = totalPrice.ToString("N2")

        'update the text box price if combo box discount is selected

    End Sub

End Class
