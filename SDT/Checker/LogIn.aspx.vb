Imports SDTCommon
Imports SDTCommon.Extensions

Namespace Checker

    Partial Public Class Login
        Inherits Page
     
        Protected WithEvents hdResponse As HiddenField

#Region "Event Handlers"
        Protected Sub BtnLoginClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
            If Request.HttpMethod <> "POST" Then
                Exit Sub
            End If

            'If Login(txtUser.Text, txtPwd.Text) Then
            '    Redirect(PageName.PreCondition)
            'End If

            'If Login(txtUser.Text, txtPwd.Text) Then    'Phasupong
            '    If CheckPWDExpire(txtUser.Text) = True Then
            '        Session("expire") = "true"
            '        Redirect(PageName.ChangePassword)
            '    Else
            '        Session("expire") = "false"
            '        Redirect(PageName.PreCondition)
            '    End If
            'End If

            'Dim userId = txtUser.Text
            'Dim password = txtPwd.Text

            'lblError.Visible = True
            'Try
            '    Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
            '    If Not dr Is Nothing Then
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
            '        SetUserId(userId)
            '        SetUserRole(dr("usergroup_id").ToString())
            '        Session("IKEY") = DIKEY
            '        Session("SKEY") = DSKEY
            '        Session("AKEY") = AKEY
            '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myscript1", fn, True)
            '    End If
            'Catch ex As Exception
            '    lblError.Text = ex.Message
            'End Try
            Dim userId = txtUser.Text
            Dim password = txtPwd.Text

            lblError.Visible = True
            Try
                If Login(userId, password) = False Then
                    Exit Sub
                End If
                Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)

                ''Disabled DUO 2016/09/16 : requested by Arada.
                ''If Not dr Is Nothing Then
                ''    Dim IKEY As String
                ''    Dim SKEY As String
                ''    Dim AKEY As String
                ''    Dim HOST As String
                ''    Dim request_sig As String
                ''    Dim fn As String
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
                ''    If CheckPWDExpire(txtUser.Text) = True Then
                ''        Session("expire") = "true"
                ''        fn = String.Format("calledFn2('{0}','{1}')", request_sig, DHost)
                ''    Else
                ''        Session("expire") = "false"
                ''        fn = String.Format("calledFn('{0}','{1}')", request_sig, DHost)
                ''    End If
                ''
                ''
                ''    lblError.Visible = False
                ''    SetUserId(userId)
                ''    SetUserRole(dr("usergroup_id").ToString())
                ''    Session("IKEY") = DIKEY
                ''    Session("SKEY") = DSKEY
                ''    Session("AKEY") = AKEY
                ''    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "myscript1", fn, True)
                ''End If

                If Not dr Is Nothing Then
                    'Added by Pachara S. on 20180226
                    Dim strHostName As String = HttpContext.Current.User.Identity.Name
                    Dim strIPAddress As String = If([String].IsNullOrEmpty(Request.ServerVariables("HTTP_X_FORWARDED_FOR")), Request.ServerVariables("REMOTE_ADDR"), Request.ServerVariables("HTTP_X_FORWARDED_FOR"))

                    If Convert.ToString(CheckPWDExpire(txtUser.Text)) = "2" Then
                        lblError.Visible = True
                        lblError.Text = "รหัสผู้ใช้งานของท่านถูกล็อคเนื่องจากรหัสผ่านหมดอายุ, โปรดติดต่อผู้ดูแลระบบของท่าน"
                        DBInterface.User.addErrLoginCount(userId)
                        DBInterface.User.addLoginLog(userId, "IN", 0, "F40", "Checker", strIPAddress)
                        Exit Sub
                    ElseIf Convert.ToString(CheckPWDExpire(txtUser.Text)) = "1" Then
                        Session("expire") = "true"
                    Else
                        Session("expire") = "false"
                    End If

                    'If CheckPWDExpire(txtUser.Text) = True Then
                    '    Session("expire") = "true"
                    'Else
                    '    Session("expire") = "false"
                    'End If

                    lblError.Visible = False
                    SetUserId(userId)
                    SetUserRole(dr("usergroup_id").ToString())

                    If CType(Session("expire"), String) = "false" Then
                        'FormsAuthentication.RedirectFromLoginPage(userId, False)
                        FormsAuthentication.SetAuthCookie(userId, False)
                        Redirect(PageName.PreCondition)
                    ElseIf CType(Session("expire"), String) = "true" Then
                        'FormsAuthentication.RedirectFromLoginPage(userId, False)
                        FormsAuthentication.SetAuthCookie(userId, False)
                        Redirect(PageName.ChangePassword)
                    End If
                End If

            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Sub
        Protected Sub BtnLogin1Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin1.Click
            Dim user As String = CStr(Session("UserID"))
            Dim response As String = hdResponse.Value

            'If response <> Nothing Then
            '    Dim IKEY As String = CStr(Session("IKEY"))
            '    Dim SKEY As String = CStr(Session("SKEY"))
            '    Dim AKEY As String = CStr(Session("AKEY"))

            '    Dim authen_usr As String = Duo.Web.VerifyResponse(IKEY, SKEY, AKEY, response)
            '    If authen_usr <> Nothing Then
            '        Session.Remove("IKEY")
            '        Session.Remove("SKEY")
            '        Session.Remove("AKEY")
            '        FormsAuthentication.RedirectFromLoginPage(user, False)
            '        Redirect(PageName.PreCondition)
            '    End If
            'End If
            If response <> Nothing Then
                Dim IKEY As String = CStr(Session("IKEY"))
                Dim SKEY As String = CStr(Session("SKEY"))
                Dim AKEY As String = CStr(Session("AKEY"))

                Dim authen_usr As String = Duo.Web.VerifyResponse(IKEY, SKEY, AKEY, response)
                If Session("expire") Is "false" Then
                    If authen_usr <> Nothing Then
                        Session.Remove("IKEY")
                        Session.Remove("SKEY")
                        Session.Remove("AKEY")
                        FormsAuthentication.RedirectFromLoginPage(user, False)
                        Redirect(PageName.PreCondition)
                    End If
                ElseIf Session("expire") Is "true" Then
                    If authen_usr <> Nothing Then
                        Session.Remove("IKEY")
                        Session.Remove("SKEY")
                        Session.Remove("AKEY")
                        FormsAuthentication.RedirectFromLoginPage(user, False)
                        Redirect(PageName.ChangePassword)
                    End If
                End If
            End If
        End Sub
        Protected Sub BtnTestClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTest.Click
            'Login("2236", "6789")
            'Redirect(PageName.PreCondition)
            Const path As String = "frmReportSummaryTicket.aspx?Type=Per Cap&MovieId=859&StartDate=20121221&EndDate=20121221"
            Response.Redirect(path)
        End Sub
#End Region

        'Private Function Login(ByVal userId As String, ByVal password As String) As Boolean
        '    lblError.Visible = True
        '    Try
        '        Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
        '        If Not dr Is Nothing Then
        '            lblError.Visible = False
        '            SetUserId(userId)
        '            SetUserRole(dr("usergroup_id").ToString())
        '            FormsAuthentication.RedirectFromLoginPage(userId, False)
        '            Return True
        '        End If
        '    Catch ex As Exception
        '        lblError.Text = ex.Message
        '    End Try
        '    Return False
        'End Function
        Private Function Login(ByVal userId As String, ByVal password As String) As Boolean
            lblError.Visible = True
            If txtUser.Text = "" Or txtPwd.Text = "" Then
                lblError.Text = "รหัสผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง ท่านไม่สามารถเข้าระบบได้ !"
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
                        lblError.Text = "รหัสผู้ใช้งานของท่านถูกล็อค ท่านยังไม่สามารถเข้าระบบได้ในขณะนี้"   'F10 login during locked account"
                        DBInterface.User.addLoginLog(userId, "IN", 0, "F10", "Checker", strIPAddress)
                        Return False
                    End If
                ElseIf dt.Rows(0).Item("found").ToString() = "0" Then
                    lblError.Text = "รหัสผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง ท่านไม่สามารถเข้าระบบได้ !"    'F00 Invalid user id
                    DBInterface.User.addLoginLog(userId, "IN", 0, "F00", "null", strIPAddress)
                    Return False
                ElseIf dt.Rows(0).Item("found").ToString() = "2" Then
                    lblError.Text = "รหัสผู้ใช้งานของท่านถูกล็อคเนื่องจากรหัสผ่านหมดอายุ, กรุณาติดต่อผู้ดูแลระบบของท่าน"    'F00 Invalid user id
                    DBInterface.User.addErrLoginCount(userId)
                    DBInterface.User.addLoginLog(userId, "IN", 0, "F40", "Checker", strIPAddress)
                    Return False
                End If
                '----------------*end rewrite version*----------------


                '-----------------*rewrite version*--------------------
                Dim dr = DBInterface.User.LoginAndUpdatePassword(userId, password)
                If Not dr Is Nothing Then
                    lblError.Visible = False
                    SetUserId(userId)
                    SetUserRole(dr("usergroup_id").ToString())
                    'FormsAuthentication.RedirectFromLoginPage(userId, False)
                    Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

                    DBInterface.User.resetThreshold(userId)
                    DBInterface.User.addLoginDate(userId, ConvertTimeToLocaltime(saveDatetimeNow)) ''ConvertTimeZone Added By Pachara S. on 20170615
                    DBInterface.User.addLoginLog(userId, "IN", 1, "null", "Checker", strIPAddress)    'login success
                    Return True
                Else
                    Dim dtchkPWD As DataTable = DBInterface.User.chkPassword(userId, strIPAddress, "Checker")     'invalid password
                    lblError.Text = dtchkPWD.Rows(0).Item("errMSG").ToString()
                    Return False
                End If
                '----------------*end rewrite version*----------------
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
            Return False
        End Function

        Private Function CheckPWDExpire(ByVal user_id As String) As String
            Dim dtPWDExpire As DataTable = DBInterface.User.chkPWDExpire(user_id)
            'If dtPWDExpire.Rows(0).Item(0).ToString() = "0" Then    'not expire
            '    Return False
            'End If
            'If dtPWDExpire.Rows(0).Item(0).ToString() = "1" Then    'expire
            '    Return True
            'End If
            Return dtPWDExpire.Rows(0).Item(0).ToString()
        End Function

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        End Sub
    End Class

End Namespace