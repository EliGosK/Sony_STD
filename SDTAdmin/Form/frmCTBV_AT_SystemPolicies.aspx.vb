Imports Microsoft.ApplicationBlocks.Data
Imports Web.Data
Imports SDTCommon
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Partial Public Class frnCTBV_AT_SystemPolicies
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckPermission(AdminPage.Admin_SystemPolicies, True)
        'If Mid(Session("permission"), 58, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If




        If Not IsPostBack Then
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_getSystemPolicies")
            Dim AccThreshold As String = ds.Tables(0).Rows(0).Item("AccThreshold").ToString()
            Dim ResetAcc As String = ds.Tables(0).Rows(0).Item("ResetAcc").ToString()
            Dim LockoutDuration As String = ds.Tables(0).Rows(0).Item("LockoutDuration").ToString()
            txtSpinThreshold.Text = AccThreshold
            txtSpinReset.Text = ResetAcc
            txtSpinDuration.Text = LockoutDuration
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If txtSpinThreshold.Text = "" Then
                lblError.Visible = True
                lblError.Text = "'Account Lockout Threshold' cannot be empty."
                Exit Sub
            End If

            If chkNum() = False Then
                lblError.Visible = True
                lblError.Text = "Please insert only number."
                Exit Sub
            End If

            If CInt(txtSpinThreshold.Text) < 0 Or CInt(txtSpinThreshold.Text) > 999 Then
                lblError.Visible = True
                lblError.Text = "'Account Lockout Threshold' value have to be in range from 0 to 999"
                Exit Sub
            End If
            If CInt(txtSpinDuration.Text) < 0 Or CInt(txtSpinDuration.Text) > 99999 Then
                lblError.Visible = True
                lblError.Text = "'Account Lockout Duration' value have to be in range from 0 to 99,999"
                Exit Sub
            End If
            If CInt(txtSpinReset.Text) < 0 Or CInt(txtSpinReset.Text) > 99999 Then
                lblError.Visible = True
                lblError.Text = "'Reset Account Lockout Threshold Count After' value have to be in range from 0 to 99,999"
                Exit Sub
            End If


            Dim DurationTime As Integer
            Dim ResetTime As Integer
            Dim Threshold As Integer
            Integer.TryParse(txtSpinThreshold.Text, Threshold)
            Integer.TryParse(txtSpinReset.Text, ResetTime)
            Integer.TryParse(txtSpinDuration.Text, DurationTime)
            If Threshold <> 0 Then
                If txtSpinReset.Text = "" Or txtSpinDuration.Text = "" Then
                    lblError.Visible = True
                    lblError.Text = "'Reset Account Lockout Threshold Count After' and 'Account Lockout Duration' cannot be empty."
                    Exit Sub
                End If
                If ResetTime <= DurationTime Then
                    SaveData(Threshold, ResetTime, DurationTime)
                Else
                    lblError.Visible = True
                    lblError.Text = "'Reset Account Logout Threshold Count After' have to less than or equal to 'Account Lockout Duration'"
                    Exit Sub
                End If
            Else
                SaveData(Threshold, ResetTime, DurationTime)
            End If
            Response.Redirect("frmCTBV_AT_Main.aspx")
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_AT_Main.aspx")
    End Sub

    Private Sub SaveData(ByVal Threshold As Integer, ByVal Reset As Integer, ByVal Duration As Integer)
        Try
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@AccThreshold", Threshold))
            paramList.Add(New SqlParameter("@ResetAcc", Reset))
            paramList.Add(New SqlParameter("@LockoutDuration", Duration))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_SystemPolicies_Update", paramList.ToArray())
            If txtSpinThreshold.Text = 0 Then
                SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_resetAlllockflag")
            End If
            'MsgBox("Save complete", MsgBoxStyle.Information)
            lblError.Visible = False
            txtSpinThreshold.Text = ""
            txtSpinDuration.Text = ""
            txtSpinReset.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Function chkNum() As Boolean
        Dim check As Boolean = False
        Dim charSet As String = "[0-9]"
        Dim re As Regex = New Regex(charSet)
        Dim SpinReset As String = txtSpinReset.Text
        Dim SpinDuration As String = txtSpinDuration.Text
        If SpinReset = "" Then
            SpinReset = "0"
            txtSpinReset.Text = "0"
        End If
        If SpinDuration = "" Then
            SpinDuration = "0"
            txtSpinDuration.Text = "0"
        End If
        If re.IsMatch(txtSpinThreshold.Text) And re.IsMatch(SpinReset) And re.IsMatch(SpinDuration) Then
            check = True
        End If
        Return check
    End Function

End Class