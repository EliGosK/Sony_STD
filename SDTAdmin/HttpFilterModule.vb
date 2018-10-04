Imports System.Security.Cryptography

Public Class HttpFilterModule
    Implements IHttpModule
    Shared KeySault As String = "8A80BCC9-4E92-4D31-B255-4732F6CB465B"
    Shared QParamName As String = "SQP"
    Shared AesSaultSize As Integer = 2
    Shared AES As RijndaelManaged
    Shared AesKey() As Byte = {130, 33, 2, 4, 73, 35, 212, 59, 85, 220 _
                                , 193, 43, 190, 233, 131, 53, 61, 190, 177, 197 _
                                , 196, 26, 111, 236, 214, 123, 113, 87, 5, 160 _
                                , 103, 103}
    Shared AesIv() As Byte = {161, 232, 246, 28, 1, 129, 193, 127, 63, 0 _
                                , 149, 2, 54, 141, 28, 18}

    Public Sub Dispose() Implements IHttpModule.Dispose
    End Sub

    Public Shared Sub SetupEncryption()
        If AES Is Nothing Then
            AES = New RijndaelManaged()
        End If
        'AES.GenerateKey()
        'AES.GenerateIV()

        AES.Key = AesKey
        AES.IV = AesIv
    End Sub

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        If context Is Nothing Then
            Exit Sub
        End If

        AddHandler context.PreRequestHandlerExecute, AddressOf Me.OnPreRequestHandlerExecute
        AddHandler context.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub
    Private Sub OnPreRequestHandlerExecute(ByVal sender As Object, ByVal e As EventArgs)
        Dim app As HttpApplication
        If TypeOf sender Is HttpApplication Then
            app = CType(sender, HttpApplication)
        Else
            Exit Sub
        End If

        Dim page As Page
        If TypeOf app.Context.Handler Is Page Then
            page = CType(app.Context.Handler, Page)
        Else
            Exit Sub
        End If

        AddHandler page.Init, AddressOf Me.Page_Init
    End Sub
    Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim page As Page = CType(sender, Page)
        page.ViewStateUserKey = KeySault + page.Session.SessionID
    End Sub
    Private Sub OnBeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim context As HttpContext = HttpContext.Current
        Dim query As String = context.Request.RawUrl
        If context.Request.Url.OriginalString.ToLower().Contains(".aspx") And _
            query.Contains("?") Then
            Dim param As String() = query.Split(New Char() {"?"c}, 2)
            If param.Length = 2 Then
                If query.Contains(QParamName) Then
                    Dim encrypted As String = param(1).Split(New Char() {"="}, 2)(1)
                    If False = String.IsNullOrEmpty(encrypted) Then
                        context.RewritePath(param(0), String.Empty, Decrypt(encrypted))
                    End If
                ElseIf 0 = String.Compare(context.Request.HttpMethod, "GET", True) Then
                    Dim newUrl As String = String.Format("{0}?{1}={2}", param(0), QParamName, Encrypt(param(1)))
                    context.Response.Redirect(newUrl)
                End If
            End If
        End If
    End Sub
    Private Function Encrypt(ByVal text As String) As String
        Dim rand As Random = New Random()
        Dim saultBytes As Byte() = New Byte() {0, 0}
        rand.NextBytes(saultBytes)

        Dim bytes = System.Text.Encoding.Unicode.GetBytes(text)
        bytes = saultBytes.Concat(bytes).ToArray()

        Using crypt = AES.CreateEncryptor()
            bytes = crypt.TransformFinalBlock(bytes, 0, bytes.Length)
            Dim b64 = System.Convert.ToBase64String(bytes)
            Return b64
        End Using
    End Function
    Private Function Decrypt(ByVal text As String) As String
        Try
            Dim bytes = System.Convert.FromBase64String(text)
            Using crypt = AES.CreateDecryptor()
                bytes = crypt.TransformFinalBlock(bytes, 0, bytes.Length)
            End Using
            Return System.Text.Encoding.Unicode.GetString(bytes, AesSaultSize, bytes.Length - AesSaultSize)
        Catch ex As FormatException
            Return String.Empty

        Catch ex As CryptographicException
            Return String.Empty
        End Try
    End Function
End Class
