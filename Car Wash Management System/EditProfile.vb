Public Class EditProfile
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly customerInformationDatabaseHelper As CustomerInformationDatabaseHelper
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        customerInformationDatabaseHelper = New CustomerInformationDatabaseHelper(constr)
    End Sub
    Private Sub EditProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel11_Paint(sender As Object, e As PaintEventArgs) Handles Panel11.Paint

    End Sub

    Private Sub TextBoxEmail_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmail.TextChanged

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.Hide()
    End Sub

    Private Sub Panel15_Paint(sender As Object, e As PaintEventArgs) Handles Panel15.Paint

    End Sub

    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        UpdateCustomerInformation()
    End Sub
    Private Sub UpdateCustomerInformation()
        If EditProfileService.ValidateFieldsInEditProfile(TextBoxName.Text, TextBoxVehicle.Text, TextBoxPlateNumber.Text) = True Then
            Return
        End If
        customerInformationDatabaseHelper.UpdateCustomer(customerIDLabel.Text, TextBoxName.Text, TextBoxNumber.Text, TextBoxEmail.Text, TextBoxAddress.Text, TextBoxVehicle.Text, TextBoxPlateNumber.Text)
        Carwash.ShowNewCustomersFormFunction()
    End Sub

End Class