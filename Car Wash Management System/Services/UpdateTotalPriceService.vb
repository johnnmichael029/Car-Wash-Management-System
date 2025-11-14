Public Class UpdateTotalPriceService
    Public Shared Sub CalculateTotalPriceInService(listViewServices As ListView, textBoxTotalPrice As TextBox)
        Dim totalPrice As Decimal = 0D
        If listViewServices Is Nothing OrElse listViewServices.Items.Count = 0 Then
            textBoxTotalPrice.Text = "0.00"
            Return
        End If

        For Each item As ListViewItem In listViewServices.Items
            If item.SubItems.Count > 2 Then
                Dim priceText As String = item.SubItems(3).Text

                Dim itemPrice As Decimal
                If Decimal.TryParse(priceText, itemPrice) Then
                    totalPrice += itemPrice
                Else
                    MessageBox.Show($"Invalid price format: {priceText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Next
        textBoxTotalPrice.Text = totalPrice.ToString("N2")
    End Sub
End Class
