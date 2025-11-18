Public Class PaymentMethodSelectedService
    Public Shared Sub PaymentMethodChange(comboBoxPaymentMethod As ComboBox, textBoxReferenceID As TextBox, textBoxCheque As TextBox)
        If comboBoxPaymentMethod.SelectedItem = "Gcash" Then
            textBoxReferenceID.ReadOnly = False
            textBoxCheque.ReadOnly = True
            textBoxCheque.Clear()
        ElseIf comboBoxPaymentMethod.SelectedItem = "Cheque" Then
            textBoxCheque.ReadOnly = False
            textBoxReferenceID.ReadOnly = True
            textBoxReferenceID.Clear()
        Else
            textBoxReferenceID.ReadOnly = True
            textBoxCheque.ReadOnly = True
            textBoxReferenceID.Clear()
            textBoxCheque.Clear()
        End If
    End Sub
End Class
