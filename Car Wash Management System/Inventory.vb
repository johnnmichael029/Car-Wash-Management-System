Imports Microsoft.Data.SqlClient
Public Class Inventory
    Dim sql As String
    Dim constr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\OOP Project and Test\Car Wash Management System\Database\CarWashDB.mdf;Integrated Security=True;Connect Timeout=30"
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim adapter As New SqlDataAdapter
    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        Login.Show()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()

    End Sub
    Private Sub Inventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToParent()
        displayTable()

    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        TextBoxProduct.Text = DataGridView1.CurrentRow.Cells("product_id").Value
        TextBoxName.Text = DataGridView1.CurrentRow.Cells("name").Value
        stockNumeric = DataGridView1.CurrentRow.Cells("stock").Value
        TextBoxPrice.Text = DataGridView1.CurrentRow.Cells("price").Value

    End Sub
    Sub displayTable()
        Try
            Using con As New SqlConnection(constr)
                con.Open()
                sql = "SELECT * FROM inventoryTable"
                cmd = New SqlCommand(sql, con)
                Dim dt As New DataTable()
                Dim SDAdapter As New SqlDataAdapter(cmd)
                SDAdapter.Fill(dt)

                DataGridView1.DataSource = dt
                DataGridView1.Refresh()
                con.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class