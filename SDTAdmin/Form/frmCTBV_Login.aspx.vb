Imports System.Web.Security
Imports SDTCommon
Imports SDTCommon.Extensions

Namespace Form
    Public Class FrmCtbvLogin
        Inherits Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnLogin As Button
        Protected WithEvents btnLogin1 As Button
        Protected WithEvents txtPassword As TextBox
        Protected WithEvents txtUserId As TextBox
        Protected WithEvents lblError As Label
        Protected WithEvents Form1 As HtmlForm
        Protected WithEvents hdResponse As HiddenField
        Protected WithEvents checkBoxPassword As CheckBox

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load, Me.Load
            'Put user code to initialize the page here
            If Not IsPostBack Then
                ' FormsAuthentication.SignOut()
            End If

        End Sub
        Private Sub BotLoginClick(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLogin.Click
            If Request.HttpMethod <> "POST" Then
                Exit Sub
            End If

            Dim userId = txtUserId.Text
            Dim password = txtPassword.Text

            '    Dim objUserControl As New cDatabase
            '    If objUserControl.Autheticate(userId, txtPassword.Text, "Administrator") = True Then
            '        lblError.Visible = False
            '        Session("UserID") = txtUserId.Text
            '        Session("Pwd") = txtPassword.Text
            '        Session("Today") = Today.Date
            '        FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
            '        Response.Redirect("frmCTBV_Menu.aspx")
            '        'การทำงานของระบบ call
            '    Else
            '        lblError.Visible = True
            '    End If
            'End Sub

            'lblError.Visible = True
            'Try
            '    Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
            '    If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
            '        lblError.Visible = False
            '        Session("UserID") = txtUserId.Text
            '        Session("Pwd") = txtPassword.Text
            '        Session("Today") = Today.Date
            '        FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
            '        Response.Redirect("frmCTBV_Menu.aspx")
            '    End If
            'Catch ex As Exception
            '    lblError.Text = ex.Message
            'End Try

            'lblError.Visible = True
            'Try
            '    Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
            '    If Login(userId, password) Then                     'added by Phasupong
            '        If CheckPWDExpire(userId) = True Then           'added by Phasupong
            '            'MsgBox("Your password has been expired! Please change your password to follow security policies.", MsgBoxStyle.Exclamation, "Password Expired")
            '            If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
            '                lblError.Visible = False
            '                Session("UserID") = txtUserId.Text
            '                Session("Pwd") = txtPassword.Text
            '                Session("Today") = Today.Date
            '                Session("permission") = dr("user_permission")
            '                FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
            '                Session("expire") = "true"                                         'added by Phasupong
            '                Response.Redirect("frmCTBV_AT_Add.aspx?userId=" & userId, False)   'added by Phasupong
            '            End If
            '        Else       'added by Phasupong
            '            If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
            '                lblError.Visible = False
            '                Session("UserID") = txtUserId.Text
            '                Session("Pwd") = txtPassword.Text
            '                Session("Today") = Today.Date
            '                Session("permission") = dr("user_permission")
            '                FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
            '                Session("expire") = "false"                                         'added by Phasupong
            '                Response.Redirect("frmCTBV_Menu.aspx", False)
            '            End If
            '        End If      'added by Phasupong
            '    End If          'added by Phasupong
            'Catch ex As Exception
            '    lblError.Text = ex.Message
            'End Try

            'lblError.Visible = True
            'Try
            '    Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
            '    If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then

            '        Dim IKEY As String
            '        Dim SKEY As String
            '        Dim AKEY As String
            '        Dim HOST As String
            '        Dim request_sig As String
            '        Dim fn As String

            '        AKEY = Duo.Web.GetAKey(Me.Session.SessionID)

            '        Dim drKey = DBInterface.User.SelectKey()
            '        If Not drKey Is Nothing Then
            '            IKEY = drKey("integration_key").ToString()
            '            SKEY = drKey("secret_key").ToString()
            '            HOST = drKey("api_hostname").ToString()
            '        End If

            '        Dim DIKEY = Crypto.Decrypt(IKEY)
            '        Dim DSKEY = Crypto.Decrypt(SKEY)
            '        Dim DHost = Crypto.Decrypt(HOST)

            '        request_sig = Duo.Web.SignRequest(DIKEY, DSKEY, AKEY, userId)
            '        fn = String.Format("calledFn('{0}','{1}')", request_sig, DHost)

            '        lblError.Visible = False
            '        Session("UserID") = txtUserId.Text
            '        Session("Pwd") = txtPassword.Text
            '        Session("Today") = Today.Date
            '        Session("IKEY") = DIKEY
            '        Session("SKEY") = DSKEY
            '        Session("AKEY") = AKEY
            '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myscript", fn, True)
            '    End If
            'Catch ex As Exception
            '    lblError.Text = ex.Message
            'End Try

            lblError.Visible = True
            Try
                If Login(userId, password) = False Then
                    Exit Sub
                End If
                Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)

                ''Disabled DUO 2016/09/16 : requested by Arada.
                ''If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                ''
                ''    Dim IKEY As String
                ''    Dim SKEY As String
                ''    Dim AKEY As String
                ''    Dim HOST As String
                ''    Dim request_sig As String
                ''    Dim fn As String = ""
                ''
                ''    AKEY = Duo.Web.GetAKey(Me.Session.SessionID)
                ''
                ''    Dim drKey = DBInterface.User.SelectKey()
                ''    If Not drKey Is Nothing Then
                ''        IKEY = drKey("integration_key").ToString()
                ''        SKEY = drKey("secret_key").ToString()
                ''        HOST = drKey("api_hostname").ToString()
                ''    End If
                ''
                ''    Dim DIKEY = Crypto.Decrypt(IKEY)
                ''    Dim DSKEY = Crypto.Decrypt(SKEY)
                ''    Dim DHost = Crypto.Decrypt(HOST)
                ''
                ''    request_sig = Duo.Web.SignRequest(DIKEY, DSKEY, AKEY, userId)
                ''    If CheckPWDExpire(userId) = True Then           'added by Phasupong
                ''        If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                ''            Session("expire") = "true"                                         'added by Phasupong
                ''            Session("permission") = dr("user_permission")
                ''            fn = String.Format("calledFn2('{0}','{1}')", request_sig, DHost)
                ''        End If
                ''    Else       'added by Phasupong
                ''        If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                ''            Session("expire") = "false"                                         'added by Phasupong
                ''            Session("permission") = dr("user_permission")
                ''            fn = String.Format("calledFn('{0}','{1}')", request_sig, DHost)
                ''        End If
                ''    End If      'added by Phasupong
                ''
                ''
                ''    lblError.Visible = False
                ''    Session("UserID") = txtUserId.Text
                ''    Session("Pwd") = txtPassword.Text
                ''    Session("Today") = Today.Date
                ''    Session("IKEY") = DIKEY
                ''    Session("SKEY") = DSKEY
                ''    Session("AKEY") = AKEY
                ''    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myscript", fn, True)
                ''End If

                'Added by Pachara S. on 20180226
                Dim strHostName As String = HttpContext.Current.User.Identity.Name
                Dim strIPAddress As String = If([String].IsNullOrEmpty(Request.ServerVariables("HTTP_X_FORWARDED_FOR")), Request.ServerVariables("REMOTE_ADDR"), Request.ServerVariables("HTTP_X_FORWARDED_FOR"))

                If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                    If CheckPWDExpire(userId) = "2" Then
                        lblError.Visible = True
                        lblError.Text = "This user has been locked by 'Password Expiration Policy',<br />, Please contact your system administrator."
                        DBInterface.User.addErrLoginCount(userId)
                        DBInterface.User.addLoginLog(userId, "IN", 0, "F40", "Administrator", strIPAddress)
                        Exit Sub
                    ElseIf CheckPWDExpire(userId) = "1" Then
                        If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                            Session("expire") = "true"
                            Session("permission") = dr("user_permission")
                        End If
                    Else
                        If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                            Session("expire") = "false"
                            Session("permission") = dr("user_permission")
                        End If
                    End If

                    'If CheckPWDExpire(userId) = True Then
                    '    If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                    '        Session("expire") = "true"
                    '        Session("permission") = dr("user_permission")
                    '    End If
                    'Else
                    '    If Not dr Is Nothing AndAlso dr("usergroup_id").ToString() = "Administrator" Then
                    '        Session("expire") = "false"
                    '        Session("permission") = dr("user_permission")
                    '    End If
                    'End If

                    lblError.Visible = False
                    Session("UserID") = txtUserId.Text
                    Session("Pwd") = txtPassword.Text
                    Session("Today") = Today.Date

                    If Session("expire") = "false" Then
                        'FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
                        FormsAuthentication.SetAuthCookie(txtUserId.Text, False)
                        Response.Redirect("frmCTBV_Menu.aspx")
                    ElseIf Session("expire") = "true" Then
                        'FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, False)
                        FormsAuthentication.SetAuthCookie(txtUserId.Text, False)
                        Response.Redirect("frmCTBV_AT_ChangePassword.aspx")
                    End If
                End If

            Catch ex As Exception
                lblError.Text = ex.Message
            End Try

        End Sub

        Protected Sub BtnLogin1Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin1.Click
            Dim user As String = CStr(Session("UserID"))
            Dim result As String = hdResponse.Value

            'If result <> Nothing Then
            '    Dim IKEY As String = CStr(Session("IKEY"))
            '    Dim SKEY As String = CStr(Session("SKEY"))
            '    Dim AKEY As String = CStr(Session("AKEY"))

            '    Dim authen_usr As String = Duo.Web.VerifyResponse(IKEY, SKEY, AKEY, result)
            '    If authen_usr <> Nothing Then
            '        Session.Remove("IKEY")
            '        Session.Remove("SKEY")
            '        Session.Remove("AKEY")
            '        FormsAuthentication.RedirectFromLoginPage(user, False)
            '        Response.Redirect("frmCTBV_Menu.aspx")
            '    End If
            'End If

            If result <> Nothing Then
                Dim IKEY As String = CStr(Session("IKEY"))
                Dim SKEY As String = CStr(Session("SKEY"))
                Dim AKEY As String = CStr(Session("AKEY"))

                Dim authen_usr As String = Duo.Web.VerifyResponse(IKEY, SKEY, AKEY, result)
                If Session("expire") = "false" Then
                    If authen_usr <> Nothing Then
                        Session.Remove("IKEY")
                        Session.Remove("SKEY")
                        Session.Remove("AKEY")
                        FormsAuthentication.RedirectFromLoginPage(user, False)
                        Response.Redirect("frmCTBV_Menu.aspx")
                    End If
                ElseIf Session("expire") = "true" Then
                    If authen_usr <> Nothing Then
                        Session.Remove("IKEY")
                        Session.Remove("SKEY")
                        Session.Remove("AKEY")
                        FormsAuthentication.RedirectFromLoginPage(user, False)
                        Response.Redirect("frmCTBV_AT_ChangePassword.aspx")
                    End If
                End If
            End If
        End Sub

        Private Function Login(ByVal userId As String, ByVal password As String) As Boolean
            lblError.Visible = True
            If txtUserId.Text = "" Or txtPassword.Text = "" Then
                lblError.Text = "User ID or Password invalid, please login again."
                Return False
            End If
            Try
                DBInterface.User.checkLockUser(userId)  'Added on 14/07/2015 by Phasupong (P1)

                Dim strHostName As String = HttpContext.Current.User.Identity.Name
                Dim strIPAddress As String = If([String].IsNullOrEmpty(Request.ServerVariables("HTTP_X_FORWARDED_FOR")), Request.ServerVariables("REMOTE_ADDR"), Request.ServerVariables("HTTP_X_FORWARDED_FOR"))


                '-----------------*rewrite version*--------------------
                Dim dtGroup As DataTable = DBInterface.User.SelectData(userId)
                Dim dt As DataTable = DBInterface.User.chkUser_id(userId, strIPAddress, strHostName)
                If dt.Rows(0).Item("found").ToString() = "1" Then
                    If dt.Rows(0).Item("lock_flag").ToString() = "True" Then    'id has been locked
                        lblError.Text = "This user has been locked, please login again later."    'F10 login during locked account
                        DBInterface.User.addLoginLog(userId, "IN", 0, "F10", "Administrator", strIPAddress)
                        Return False
                    End If
                    If dtGroup.Rows(0).Item("usergroup_id").ToString() = "Checker" Then
                        DBInterface.User.addErrLoginCount(userId)
                        DBInterface.User.addLoginLog(userId, "IN", 0, "F20", "Administrator", strIPAddress)
                        Return False
                    End If
                ElseIf dt.Rows(0).Item("found").ToString() = "0" Then
                    lblError.Text = "User ID or Password invalid, please login again."    'F00 Invalid user id
                    DBInterface.User.addLoginLog(userId, "IN", 0, "F00", "null", strIPAddress)
                    Return False
                ElseIf dt.Rows(0).Item("found").ToString() = "2" Then
                    lblError.Text = "This user has been locked by 'Password Expiration Policy'.<br />Please contact your system administrator."    'F40 password expired & locked
                    DBInterface.User.addErrLoginCount(userId)
                    DBInterface.User.addLoginLog(userId, "IN", 0, "F40", "Administrator", strIPAddress)
                    Return False
                End If

                '----------------*end rewrite version*----------------


                '-----------------*rewrite version*--------------------
                Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
                If Not dr Is Nothing Then
                    lblError.Visible = False
                    'SetUserId(userId)
                    'SetUserRole(dr("usergroup_id").ToString())
                    'FormsAuthentication.RedirectFromLoginPage(userId, False)
                    Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
                    DBInterface.User.resetThreshold(userId)
                    DBInterface.User.addLoginDate(userId, ConvertTimeToLocaltime(saveDatetimeNow)) 'ConvertTimeZone Added By Pachara S. on 20170615
                    DBInterface.User.addLoginLog(userId, "IN", 1, "null", "Administrator", strIPAddress)    'login success
                    Return True
                Else
                    Dim dtchkPWD As DataTable = DBInterface.User.chkPassword(userId, strIPAddress, "Administrator")     'invalid password
                    lblError.Text = dtchkPWD.Rows(0).Item("errMSGEng").ToString()
                    Return False
                End If
                '----------------*end rewrite version*----------------
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
            Return False
        End Function

        Private Function CheckPWDExpire(ByVal user_id As String)
            Dim dtPWDExpire As DataTable = DBInterface.User.chkPWDExpire(user_id)
            'If dtPWDExpire.Rows(0).Item(0).ToString() = "0" Then    'not expire
            '    Return False
            'End If
            'If dtPWDExpire.Rows(0).Item(0).ToString() = "1" Then    'expire
            '    Return True
            'End If
            Return dtPWDExpire.Rows(0).Item(0).ToString()
        End Function

        Protected Sub checkBoxPassword_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxPassword.CheckedChanged
            Dim ss As String = txtPassword.Text

            If checkBoxPassword.Checked Then
                txtPassword.TextMode = TextBoxMode.SingleLine
            Else
                txtPassword.TextMode = TextBoxMode.Password
            End If

            txtPassword.Attributes.Add("value", ss)
        End Sub
    End Class

End Namespace
