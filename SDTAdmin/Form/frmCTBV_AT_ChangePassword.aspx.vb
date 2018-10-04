﻿Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions
Imports System.Text.RegularExpressions
Imports SDTCommon.Utils
Imports Web.Data

Partial Public Class frmCTBV_AT_ChangePassword
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Dim pwMinlength As Integer
    Dim pwMaxlength As Integer
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CheckLogin()


        dt = DBInterface.User.SelectData(Session("UserID").ToString())
        Dim group As String = dt.Rows(0).Item("usergroup_id").ToString()
        Dim drPWLength As IDataReader = DBInterface.User.GetPWLength(group)
        Dim drPWHint As IDataReader = DBInterface.User.GetPWHint(group)
        If Not IsPostBack Then
            'If Session("expire") Is "true" And group = "Administrator" Then
            '    Response.Write("<script>alert('รหัสผ่านของท่านหมดอายุ กรุณาตั้งพาสเวิร์ดใหม่ตามนโยบายความปลอดภัย')</script>")
            '    Session("expire") = "false"
            'End If
            If Session("expire") Is "true" Then
                lblwarning.Visible = True
                lblwarning.Text = "Your Password has been expired!<br/>Please change your password to follow security policies."
                Session("expire") = "false"
            End If
        End If
        drPWLength.Read()
        drPWHint.Read()
        If group = "Administrator" Then
            lblHint.Visible = True
            lblHint.Text = drPWHint("PasswordHint").ToString
            txtPassword.MaxLength = CInt(drPWLength("PWDMaxLength"))
            txtPassword_new.MaxLength = CInt(drPWLength("PWDMaxLength"))
            txtPassword_confirm.MaxLength = CInt(drPWLength("PWDMaxLength"))
        ElseIf group = "Checker" Then
            lblHint.Visible = True
            lblHint.Text = drPWHint("PasswordHint2").ToString
            txtPassword.MaxLength = CInt(drPWLength("PWDMaxLength"))
            txtPassword_new.MaxLength = CInt(drPWLength("PWDMaxLength"))
            txtPassword_confirm.MaxLength = CInt(drPWLength("PWDMaxLength"))
        End If
        pwMinlength = CInt(drPWLength("PWDMinLength"))
        pwMaxlength = CInt(drPWLength("PWDMaxLength"))
        drPWLength.Close()
        drPWHint.Close()
        txtPassword.Focus()
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
        Response.Redirect("frmCTBV_Menu.aspx")
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
        If txtPassword.Text = "" Or txtPassword_new.Text = "" Or txtPassword_confirm.Text = "" Then
            lblwarning.Visible = True
            'lblwarning.Text = "กรุณากรอกข้อมูล รหัสผ่านปัจจุบัน, รหัสผ่านใหม่ และยืนยันรหัสผ่านใหม่ ให้ครบถ้วน"
            lblwarning.Text = "Please verify your current password. <br/>Enter new password and confirm new password."
            clearScreen()
            Exit Sub
        End If
        Dim group As String = dt.Rows(0).Item("usergroup_id").ToString()

        Dim encryptPW = Crypto.Encrypt(txtPassword.Text)
        Dim encryptPW_new = Crypto.Encrypt(txtPassword_new.Text)
        If encryptPW = dt.Rows(0).Item("user_password").ToString() Then

            If txtPassword_new.Text <> txtPassword_confirm.Text Then
                lblwarning.Visible = True
                lblwarning.Text = "Your new password and confirm new password do not match."
                clearScreen()
                Exit Sub
            End If

            'If group = "Administrator" Then
            If (txtPassword_new.Text.Length < pwMinlength) And (IsSpecialCharacters(txtPassword_new.Text, group) = True) Then
                lblwarning.Visible = True
                lblwarning.Text = "Password must be at least " & pwMinlength.ToString & " characters."
                clearScreen()
                Exit Sub
            ElseIf (txtPassword_new.Text.Length >= pwMinlength) And (IsSpecialCharacters(txtPassword_new.Text, group) = False) Then
                lblwarning.Visible = True
                lblwarning.Text = "Please choose a password with a mix of lower and upper case letters and numbers and symbols."
                clearScreen()
                Exit Sub
            ElseIf (txtPassword_new.Text.Length < pwMinlength) And (IsSpecialCharacters(txtPassword_new.Text, group) = False) Then
                lblwarning.Visible = True
                lblwarning.Text = "Passwords must be at least " & pwMinlength.ToString & " characters and contain all of the following: uppercase letters, lowercase letters, numbers, and symbols."
                clearScreen()
                Exit Sub
            End If
            'End If

            Dim pwHist As DataSet = DBInterface.User.CheckPWHist(Session("UserID").ToString(), encryptPW_new) 'check password unique history
            Dim Hist As String = pwHist.Tables(0).Rows(0).Item(0).ToString()
            If Hist = "True" Then
                lblwarning.Visible = True
                lblwarning.Text = "Please choose a password which doesn't exist to user password’s history."
                clearScreen()
                Exit Sub
            End If

            'Added by Pachara S. on 20180215, check password cannot be the previous password backwords and cannot substitute only a single character in the previous password.
            Dim dtPWDUniqueHistory As DataTable = DBInterface.User.getPWDHistory(Session("UserID").ToString())
            Dim isSamePWD As Boolean = False
            If Not IsNothing(dtPWDUniqueHistory) Then
                For index As Integer = 0 To (dtPWDUniqueHistory.Rows.Count() - 1)
                    Dim tmpPWDHistory As String = Crypto.Decrypt(dtPWDUniqueHistory.Rows(index).Item(0))

                    'Dim revText As String = StrReverse(tmpPWDHistory)
                    'If Not String.Compare(revText, txtPassword_new.Text) Then
                    '    lblwarning.Visible = True
                    '    lblwarning.Text = "Your password cannot be the previous password backwords."
                    '    clearScreen()
                    '    Exit Sub
                    'End If

                    Dim checkWord As Integer = 0
                    Dim minLength As Integer
                    Dim comLength As Integer

                    If tmpPWDHistory.Length < txtPassword_new.Text.Length Then
                        minLength = (tmpPWDHistory.Length - 1)
                    Else
                        minLength = (txtPassword_new.Text.Length - 1)
                    End If

                    comLength = Math.Abs(tmpPWDHistory.Length - txtPassword_new.Text.Length)
                    If comLength < 2 Then
                        For indexStr As Integer = 0 To minLength
                            If Not tmpPWDHistory.Chars(indexStr) = txtPassword_new.Text.Chars(indexStr) Then
                                checkWord += 1
                            End If
                        Next

                        If (checkWord = 1 And comLength = 0) Or checkWord = 0 Then
                            isSamePWD = True
                        End If
                    End If

                    If isSamePWD Then
                        lblwarning.Visible = True
                        lblwarning.Text = "Your password cannot substitute only a single character in the previous password."
                        clearScreen()
                        Exit Sub
                    End If
                Next
            End If

            'Added by Pachara S. on 20180223, check password cannot be the previous password backwords
            If Not IsNothing(dtPWDUniqueHistory) Then
                For index As Integer = 0 To (dtPWDUniqueHistory.Rows.Count() - 1)
                    Dim tmpChkPWDHistory As String = Crypto.Decrypt(dtPWDUniqueHistory.Rows(index).Item(0))
                    Dim revText As String = StrReverse(tmpChkPWDHistory)
                    If String.Compare(revText, txtPassword_new.Text) = 0 Then
                        lblwarning.Visible = True
                        lblwarning.Text = "Your password cannot be the previous password backwords."
                        clearScreen()
                        Exit Sub
                    End If
                Next
            End If

            'Added by Pachara S. on 20180215, check restricted password list
            Dim dtchkPWDWord As DataTable = DBInterface.User.chkPWDValidateWord(Session("UserID").ToString(), txtPassword_new.Text)
            If dtchkPWDWord.Rows(0).Item(0) Then
                lblwarning.Visible = True
                lblwarning.Text = "Please choose a password which doesn't exist to restricted password list."
                clearScreen()
                Exit Sub
            End If

            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            DBInterface.User.addPWDUniqueHistory(Session("UserID").ToString(), encryptPW_new, Session("UserID").ToString())
            DBInterface.User.UpdatePassword(Session("UserID").ToString(), encryptPW_new)
            DBInterface.User.addPWDCreateDate(Session("UserID").ToString(), ConvertTimeToLocaltime(saveDatetimeNow)) 'ConvertTimeZone Added By Pachara S. on 20170615
            DBInterface.User.resetThreshold(Session("UserID").ToString())
            Response.Redirect("frmCTBV_Menu.aspx")
        Else
            lblwarning.Visible = True
            lblwarning.Text = "Your currrent password is incorrect."
        End If
    End Sub

    Private Function IsSpecialCharacters(ByVal stringToTest As String, ByVal group As String) As Boolean
        Dim check1 As Boolean = False
        Dim check2 As Boolean = False
        Dim check3 As Boolean = False
        Dim check4 As Boolean = False
        Dim finalcheck As Boolean = False
        Dim charSet1 As String = "[a-z]"
        Dim charSet2 As String = "[A-Z]"
        Dim charSet3 As String = "[0-9]"
        Dim charSet4 As String = "[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}]"
        Dim re1 As Regex = New Regex(charSet1)
        Dim re2 As Regex = New Regex(charSet2)
        Dim re3 As Regex = New Regex(charSet3)
        Dim re4 As Regex = New Regex(charSet4)

        'If group = "Administrator" Then
        '    If re1.IsMatch(stringToTest) Then
        '        check1 = True
        '    End If
        '    If re2.IsMatch(stringToTest) Then
        '        check2 = True
        '    End If
        '    If re3.IsMatch(stringToTest) Then
        '        check3 = True
        '    End If
        '    If re4.IsMatch(stringToTest) Then
        '        check4 = True
        '    End If

        '    If (check1 And check2 And check3 And check4) Then
        '        finalcheck = True
        '    End If

        'End If

        'If group = "Checker" Then
        '    If re1.IsMatch(stringToTest) Then
        '        check1 = True
        '    End If
        '    If re2.IsMatch(stringToTest) Then
        '        check2 = True
        '    End If
        '    If re3.IsMatch(stringToTest) Then
        '        check3 = True
        '    End If
        '    If re4.IsMatch(stringToTest) Then
        '        check4 = True
        '    End If

        '    If (check1 And check2) Then
        '        finalcheck = True
        '    End If
        '    If (check1 And check3) Then
        '        finalcheck = True
        '    End If
        '    If (check1 And check4) Then
        '        finalcheck = True
        '    End If
        '    If (check2 And check3) Then
        '        finalcheck = True
        '    End If
        '    If (check2 And check4) Then
        '        finalcheck = True
        '    End If
        '    If (check3 And check4) Then
        '        finalcheck = True
        '    End If

        'End If

        'Comment & Edited by Pachara S. on 20180214
        If re1.IsMatch(stringToTest) Then
            check1 = True
        End If
        If re2.IsMatch(stringToTest) Then
            check2 = True
        End If
        If re3.IsMatch(stringToTest) Then
            check3 = True
        End If
        If re4.IsMatch(stringToTest) Then
            check4 = True
        End If

        If (check1 And check2 And check3 And check4) Then
            finalcheck = True
        End If

        Return finalcheck
    End Function

    Private Sub clearScreen()
        txtPassword.Text = ""
        txtPassword_new.Text = ""
        txtPassword_confirm.Text = ""
        txtPassword.Focus()
    End Sub
End Class