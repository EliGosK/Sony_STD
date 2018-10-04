
'
' * DuoWeb.cs
' *
' * Copyright (c) 2011 Duo Security
' * All rights reserved, all wrongs reversed.
' 


Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Text
Imports System.Collections
Imports System.Collections.Generic
Imports System.Security.Cryptography

Namespace Duo
    Public NotInheritable Class Web

        Private Sub New()
        End Sub

        Const DUO_PREFIX As String = "TX"
        Const APP_PREFIX As String = "APP"
        Const AUTH_PREFIX As String = "AUTH"

        Const DUO_EXPIRE As Integer = 300
        Const APP_EXPIRE As Integer = 3600

        Const IKEY_LEN As Integer = 20
        Const SKEY_LEN As Integer = 40
        Const AKEY_LEN As Integer = 40

        Public Shared ERR_USER As String = "ERR|The username passed to sign_request() is invalid."
        Public Shared ERR_IKEY As String = "ERR|The Duo integration key passed to sign_request() is invalid."
        Public Shared ERR_SKEY As String = "ERR|The Duo secret key passed to sign_request() is invalid."
        Public Shared ERR_AKEY As String = "ERR|The application secret key passed to sign_request() must be at least 40 characters."
        Public Shared ERR_UNKNOWN As String = "ERR|An unknown error has occurred."

        ' throw on invalid bytes
        Private Shared _encoding As Encoding = New UTF8Encoding(False, True)

        ''' <summary>
        ''' Generate a signed request for Duo authentication.
        ''' The returned value should be passed into the Duo.init() call
        ''' in the rendered web page used for Duo authentication.
        ''' </summary>
        ''' <param name="ikey">Duo integration key</param>
        ''' <param name="skey">Duo secret key</param>
        ''' <param name="akey">Application secret key</param>
        ''' <param name="username">Primary-authenticated username</param>
        ''' <param name="current_time">(optional) The current UTC time</param>
        ''' <returns>signed request</returns>
        Public Shared Function SignRequest(ByVal ikey As String, ByVal skey As String, ByVal akey As String, ByVal username As String, Optional ByVal current_time As DateTime = Nothing) As String
            Dim duo_sig As String
            Dim app_sig As String

            Dim current_time_value As DateTime = DateTime.UtcNow

            If current_time <> Nothing Then
                current_time_value = current_time
            End If

            If username = "" Then
                Return ERR_USER
            End If
            If ikey.Length <> IKEY_LEN Then
                Return ERR_IKEY
            End If
            If skey.Length <> SKEY_LEN Then
                Return ERR_SKEY
            End If
            If akey.Length < AKEY_LEN Then
                Return ERR_AKEY
            End If

            Try
                duo_sig = SignVals(skey, username, ikey, DUO_PREFIX, DUO_EXPIRE, current_time_value)
                app_sig = SignVals(akey, username, ikey, APP_PREFIX, APP_EXPIRE, current_time_value)
            Catch
                Return ERR_UNKNOWN
            End Try

            Return Convert.ToString(duo_sig & Convert.ToString(":")) & app_sig
        End Function

        ''' <summary>
        ''' Validate the signed response returned from Duo.
        ''' Returns the username of the authenticated user, or null.
        ''' </summary>
        ''' <param name="ikey">Duo integration key</param>
        ''' <param name="skey">Duo secret key</param>
        ''' <param name="akey">Application secret key</param>
        ''' <param name="sig_response">The signed response POST'ed to the server</param>
        ''' <param name="current_time">(optional) The current UTC time</param>
        ''' <returns>authenticated username, or null</returns>
        Public Shared Function VerifyResponse(ByVal ikey As String, ByVal skey As String, ByVal akey As String, ByVal sig_response As String, Optional ByVal current_time As DateTime = Nothing) As String
            Dim auth_user As String = Nothing
            Dim app_user As String = Nothing

            Dim current_time_value As DateTime = DateTime.UtcNow

            If current_time <> Nothing Then
                current_time_value = current_time
            End If

            Try
                Dim sigs As String() = sig_response.Split(":"c)
                Dim auth_sig As String = sigs(0)
                Dim app_sig As String = sigs(1)

                auth_user = ParseVals(skey, auth_sig, AUTH_PREFIX, current_time_value)
                app_user = ParseVals(akey, app_sig, APP_PREFIX, current_time_value)
            Catch
                Return Nothing
            End Try

            If auth_user <> app_user Then
                Return Nothing
            End If

            Return auth_user
        End Function

        Private Shared Function SignVals(ByVal key As String, ByVal username As String, ByVal ikey As String, ByVal prefix As String, ByVal expire As Int64, ByVal current_time As DateTime) As String

            Dim ts As Int64 = Convert.ToInt64((current_time - New DateTime(1970, 1, 1)).TotalSeconds)
            expire = ts + expire

            Dim val As String = (Convert.ToString(username & Convert.ToString("|")) & ikey) + "|" + expire.ToString()
            Dim cookie As String = Convert.ToString(prefix & Convert.ToString("|")) & Encode64(val)

            Dim sig As String = HmacSign(key, cookie)

            Return Convert.ToString(cookie & Convert.ToString("|")) & sig
        End Function

        Private Shared Function ParseVals(ByVal key As String, ByVal val As String, ByVal prefix As String, ByVal current_time As DateTime) As String
            Dim ts As Int64 = CInt((current_time - New DateTime(1970, 1, 1)).TotalSeconds)

            Dim parts As String() = val.Split("|"c)
            If parts.Length <> 3 Then
                Return Nothing
            End If

            Dim u_prefix As String = parts(0)
            Dim u_b64 As String = parts(1)
            Dim u_sig As String = parts(2)

            Dim sig As String = HmacSign(key, Convert.ToString(u_prefix & Convert.ToString("|")) & u_b64)
            If HmacSign(key, sig) <> HmacSign(key, u_sig) Then
                Return Nothing
            End If

            If u_prefix <> prefix Then
                Return Nothing
            End If

            Dim cookie As String = Decode64(u_b64)
            Dim cookie_parts As String() = cookie.Split("|"c)
            If cookie_parts.Length <> 3 Then
                Return Nothing
            End If

            Dim username As String = cookie_parts(0)
            Dim ikey As String = cookie_parts(1)
            Dim expire As String = cookie_parts(2)

            Dim expire_ts As Integer = Convert.ToInt32(expire)
            If ts >= expire_ts Then
                Return Nothing
            End If

            Return username
        End Function

        Private Shared Function HmacSign(ByVal skey As String, ByVal data As String) As String
            Dim key_bytes As Byte() = _encoding.GetBytes(skey)
            Dim hmac As New HMACSHA1(key_bytes)

            Dim data_bytes As Byte() = _encoding.GetBytes(data)
            hmac.ComputeHash(data_bytes)

            Dim hex As String = BitConverter.ToString(hmac.Hash)
            Return hex.Replace("-", "").ToLower()
        End Function

        Private Shared Function Encode64(ByVal plaintext As String) As String
            Dim plaintext_bytes As Byte() = _encoding.GetBytes(plaintext)
            Return System.Convert.ToBase64String(plaintext_bytes)
        End Function

        Private Shared Function Decode64(ByVal encoded As String) As String
            Dim plaintext_bytes As Byte() = System.Convert.FromBase64String(encoded)
            Return _encoding.GetString(plaintext_bytes)
        End Function

        Public Shared Function GetAKey(ByVal Session As String) As String
            Dim strDate As String = DateTime.Now.ToString("ddMMyyyyHHmmss")
            Dim aKey As String = String.Concat("ak", Session, strDate)
            Return aKey
        End Function
    End Class
End Namespace

