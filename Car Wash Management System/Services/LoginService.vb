Imports System.Security.Cryptography
Imports System.Text

Public Class LoginService
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
End Class
