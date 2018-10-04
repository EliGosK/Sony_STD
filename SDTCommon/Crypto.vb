Imports System.Text

Public Class Crypto
    Public Shared Function Encrypt(ByVal data As String) As String
        Try
            Dim arr = data.ToCharArray()
            Array.Reverse(arr)
            Dim salt = New String(arr)
            Return Convert.ToBase64String(Encoding.Unicode.GetBytes(salt + data))
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Shared Function Decrypt(ByVal encrypted As String) As String
        Try
            Dim decryptedAndSalt = Encoding.Unicode.GetString(Convert.FromBase64String(encrypted))
            Return decryptedAndSalt.Substring(CInt(decryptedAndSalt.Length / 2))
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

End Class
