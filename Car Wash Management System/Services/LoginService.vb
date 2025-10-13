Imports System.Security.Cryptography
Imports System.Text

Public Class LoginService
    Shared constr As String = "Data Source=JM\SQLEXPRESS;Initial Catalog=CarwashDB;Integrated Security=True;Trust Server Certificate=True"

    Public Sub New()

    End Sub
    Public Shared Function HashPassword(password As String) As (String, String)
        Dim saltBytes(15) As Byte
#Disable Warning SYSLIB0023
        Using rng As New RNGCryptoServiceProvider()
#Enable Warning SYSLIB0023
            rng.GetBytes(saltBytes)
        End Using
        Dim salt As String = Convert.ToBase64String(saltBytes)
        Dim saltedPassword As String = password & salt
        Dim hashBytes As Byte()
        hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword))
        Dim hashedPassword As String = Convert.ToBase64String(hashBytes)
        Return (salt, hashedPassword)
    End Function
    Public Shared Function VerifyPassword(inputPassword As String, storedSalt As String, storedHash As String) As Boolean
        Dim saltedPassword As String = inputPassword & storedSalt
        Dim hashBytes As Byte()
        hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(saltedPassword))
        Dim hashedInput As String = Convert.ToBase64String(hashBytes)
        Return hashedInput = storedHash
    End Function
    Public Shared Sub DoesHaveAnyAccount(username As String, password As String, isAdmin As Boolean)
        Dim adminDatabaseHelper As New AdminDatabaseHelper(constr)
        If Not LoginDatabaseHelper.DoesAnyAccountExist() Then
            'Dim setupForm As New Admin()
            'setupForm.ShowDialog()
            AdminDatabaseHelper.AddUsers(username, password, isAdmin)
        End If
    End Sub
End Class
