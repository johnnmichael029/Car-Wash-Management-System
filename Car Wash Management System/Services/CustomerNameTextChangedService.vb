Public Class CustomerNameTextChangedService
    Public Shared Sub CustomerNameTextChanged(textBoxCustomerID As TextBox, TextBoxCustomerName As TextBox)
        Try
            Dim customerID As Integer = SalesDatabaseHelper.GetCustomerID(TextBoxCustomerName.Text)
            If customerID > 0 Then
                textBoxCustomerID.Text = customerID.ToString()
            Else
                textBoxCustomerID.Text = String.Empty
            End If
        Catch ex As Exception
            MessageBox.Show("An error occurred while retrieving customer ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            textBoxCustomerID.Text = String.Empty
        End Try
    End Sub
End Class
