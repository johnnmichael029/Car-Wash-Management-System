Public Class EditProfileService
    Public Shared Function ValidateFieldsInEditProfile(customerID As String) As Boolean
        'Validate if Name is empty
        If String.IsNullOrEmpty(customerID) Then
            MessageBox.Show("Please click the edit info button to edit customer info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        Return False
    End Function
End Class
