Imports System.Security.Cryptography
Imports System.Text
Imports Microsoft.Data.SqlClient
Public Class Login
   
    Dim constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarWashManagementDB;Integrated Security=True;Trust Server Certificate=True"
    Private ReadOnly listOfActivityLog As New ListOfActivityLog(constr)
    Private ReadOnly loginManagement As LoginManagement
    Private ReadOnly accountManagement As AccountManagement
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        loginManagement = New LoginManagement(constr)
        accountManagement = New AccountManagement(constr)
    End Sub

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CenterToScreen()
        DoesHaveAnyAccount()

    End Sub
    Private Sub DoesHaveAnyAccount()
        If Not accountManagement.DoesAnyAccountExist() Then
            Dim setupForm As New Admin()
            setupForm.ShowDialog()
        End If
    End Sub
    Private Sub LoginBtn_Click(sender As Object, e As EventArgs) Handles LoginBtn.Click
        LoginValidation()
        LoginActivityLog()
        LabelWelcomeUsers(TextBoxUsername.Text)
    End Sub

    Public Function LabelWelcomeUsers(welcomeUsers As String)
        welcomeUsers = TextBoxUsername.Text
        Carwash.LabelWelcome.Text = welcomeUsers
        CheckIfUserHaveRights(welcomeUsers)
        Return welcomeUsers
    End Function
    Private Sub CheckIfUserHaveRights(welcomeUsers As String)
        If welcomeUsers <> "admin" Then
            Carwash.AdminToolStripMenuItem.Enabled = False
        Else
            Carwash.AdminToolStripMenuItem.Enabled = True
        End If
    End Sub
    Public Sub LoginValidation()
        loginManagement.LoginValidation(TextBoxUsername.Text, TextBoxPassword.Text)
    End Sub
    Public Sub ClearFields()
        TextBoxPassword.Clear()
    End Sub
    Public Sub LoginActivityLog()
        Dim username As String = TextBoxUsername.Text
        listOfActivityLog.UserLogin(username)
    End Sub
End Class
Public Class LoginManagement
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
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
    Public Sub LoginValidation(username As String, password As String)
        ' Check for empty fields first to prevent unnecessary database calls
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using con As New SqlConnection(constr)
            Try
                con.Open()
                Dim selectQuery = "SELECT 
                                        password, 
                                        salt, 
                                        CASE 
                                            WHEN is_admin IS NULL THEN 0 
                                            ELSE is_admin 
                                        END AS is_admin 
                                    FROM 
                                        userTable 
                                    WHERE 
                                        username = @username"
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
                                Carwash.Show()
                                Login.Hide()
                            Else
                                MessageBox.Show("Invalid Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                        Login.ClearFields()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End Using
    End Sub
End Class
Public Class AccountManagement
    Private ReadOnly constr As String
    Public Sub New(connectionString As String)
        constr = connectionString
    End Sub
    Public Function DoesAnyAccountExist() As Boolean
        Dim count As Integer = 5
        Using con As New SqlConnection(constr)
            Dim query As String = "SELECT COUNT(*) FROM UserTable"
            Using cmd As New SqlCommand(query, con)
                Try
                    con.Open()
                    Dim result As Object = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        count = Convert.ToInt32(result)
                        Console.WriteLine()
                    End If
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        End Using

        Return count >= 2
    End Function
End Class
