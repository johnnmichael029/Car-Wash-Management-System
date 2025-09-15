Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient
Public Class Login

    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Dim dashboardManagement As New DashboardManagement(constr)

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    ' Hashes a password with a randomly generated salt.
    Public Shared Function HashPassword(password As String) As (String, String)
        ' Generate a random salt
        Dim saltBytes(15) As Byte
#Disable Warning SYSLIB0023 ' Type or member is obsolete
        Using rng As New RNGCryptoServiceProvider()
#Enable Warning SYSLIB0023 ' Type or member is obsolete
            rng.GetBytes(saltBytes)
        End Using
        Dim salt As String = Convert.ToBase64String(saltBytes)

        ' Combine password and salt
        Dim saltedPassword As String = password & salt

        ' Hash the salted password
        Dim hashBytes As Byte()
        hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword))
        Dim hashedPassword As String = Convert.ToBase64String(hashBytes)

        ' Return the salt and hashed password
        Return (salt, hashedPassword)
    End Function

    ' Verifies an input password against a stored salt and hash.
    Public Shared Function VerifyPassword(inputPassword As String, storedSalt As String, storedHash As String) As Boolean
        ' Combine input password with stored salt
        Dim saltedPassword As String = inputPassword & storedSalt

        ' Hash the salted password
        Dim hashBytes As Byte()
        hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword))
        Dim hashedInput As String = Convert.ToBase64String(hashBytes)

        ' Compare the hashes
        Return hashedInput = storedHash
    End Function

    Private Sub LoginValidation()
        Dim username As String = TextBoxUsername.Text
        Dim password As String = TextBoxPassword.Text
        ' Check for empty fields first to prevent unnecessary database calls
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                ' Use a parameterized query to prevent SQL injection.
                ' Use CASE to handle potential NULL values in the is_admin column.
                Dim selectQuery = "SELECT password, salt, CASE WHEN is_admin IS NULL THEN 0 ELSE is_admin END AS is_admin FROM userTable WHERE username = @username"
                Using cmd As New SqlCommand(selectQuery, con)
                    cmd.Parameters.AddWithValue("@username", username)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Get the stored hash, salt, and admin status from the database
                            Dim storedHash As String = reader("password").ToString()
                            Dim storedSalt As String = reader("salt").ToString()
                            ' Safely read the is_admin column, which is now guaranteed to be 0 or 1.
                            Dim isAdmin As Boolean = reader("is_admin")

                            ' Verify the entered password against the stored hash and salt
                            If VerifyPassword(password, storedSalt, storedHash) Then

                                ' Check if the user is an admin and show the appropriate form
                                If isAdmin Then
                                    ' Admin Form should be shown
                                    ' Replace AdminForm with the name of your new form
                                    Admin.Show()
                                    Me.Hide()
                                Else
                                    ' Regular user form should be shown
                                    Carwash.Show()
                                    Me.Hide()
                                End If

                            Else
                                ' Passwords do not match
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            ' No rows found, so the username doesn't exist.
                            MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using ' Close the reader
                End Using ' Dispose the command
            Catch ex As Exception

                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Ensure these actions always happen, regardless of success or failure
                TextBoxPassword.Clear()
                con.Close()
            End Try
        End Using ' Close and dispose the connection
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        LoginValidation()
        Dim username As String = TextBoxUsername.Text
        dashboardManagement.UserLogin(username)

    End Sub

End Class
