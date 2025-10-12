Public Class EditProfileService
    Public Shared Function ValidateFieldsInEditProfile(name As String, vehicle As String, plateNumber As String) As Boolean
        'Validate if Name is empty
        If String.IsNullOrEmpty(name) Then
            MessageBox.Show("Please enter the customer's name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        'Validate if Vehilcle Type is empty
        If String.IsNullOrEmpty(vehicle) Then
            MessageBox.Show("Please enter the customer's vehicle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        'Validate if Plate Number is empty
        If String.IsNullOrEmpty(plateNumber) Then
            MessageBox.Show("Please enter the customer's plate number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
        Return False
    End Function
End Class
