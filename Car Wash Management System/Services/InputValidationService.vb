Imports System.Text.RegularExpressions

Public Class InputValidationService
    Public Shared Function IsMobileNumberValid(mobileNumber As String, errorHandler As Action(Of String)) As Boolean
        ' Remove any leading/trailing whitespace
        Dim cleanNumber As String = mobileNumber.Trim()

        If String.IsNullOrEmpty(cleanNumber) Then
            errorHandler("Mobile number cannot be empty.")
            Return False
        End If

        ' Regex explanation:
        ' ^           - Start of the string
        ' \d{12}      - Exactly 12 digits (0-9)
        ' $           - End of the string
        Dim regex As New Regex("^\d{11}$")

        If regex.IsMatch(cleanNumber) Then
            Return True
        Else
            errorHandler("Mobile number must be exactly 12 digits.")
            Return False
        End If

    End Function

    ' Function to check if the email address is valid AND ends with @gmail.com
    Public Shared Function IsEmailValid(emailAddress As String, errorHandler As Action(Of String)) As Boolean
        Dim cleanEmail As String = emailAddress.Trim()

        If String.IsNullOrEmpty(cleanEmail) Then
            errorHandler("Email address cannot be empty.")
            Return False
        End If

        ' Regex to check for: 
        ' 1. Start of string (^)
        ' 2. One or more characters that are not @ or whitespace ([\w\.-]+)
        ' 3. Must end with @gmail.com ($)
        Dim gmailRegex As New Regex("^[\w\.-]+@gmail\.com$", RegexOptions.IgnoreCase)

        If gmailRegex.IsMatch(cleanEmail) Then

            Return True
        Else
            errorHandler("Email address must be a valid Gmail address ending with @gmail.com.")
            Return False
        End If
    End Function

End Class
