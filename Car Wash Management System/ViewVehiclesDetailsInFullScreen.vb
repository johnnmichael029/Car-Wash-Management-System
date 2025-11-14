Public Class ViewVehiclesDetailsInFullScreen
    Private Sub ViewVehiclesDetailsInFullScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()

        Me.FormBorderStyle = FormBorderStyle.None

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class