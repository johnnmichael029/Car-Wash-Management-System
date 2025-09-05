Public Class Dashboard
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles salesLogBtn.Click
        SalesLog.Show()
        Me.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles dashboardBtn.Click

    End Sub
    Private Sub inventory_Click(sender As Object, e As EventArgs) Handles inventoryBtn.Click
        Inventory.Show()
        Me.Hide()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Application.Exit()
    End Sub
End Class
