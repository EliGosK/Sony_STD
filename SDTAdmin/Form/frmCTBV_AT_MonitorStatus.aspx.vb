Imports System.Web.Security
Partial Public Class frmCTBV_AT_MonitorStatus
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Mid(Session("permission"), 31, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            If Hour(Now) < 6 Then
                'clnDate.SelectedDate = Now().AddDays(-1)
                Session("revDatex") = Format(Now().AddDays(-1), "yyyyMMdd")
            Else
                Session("revDatex") = Format(Now(), "yyyyMMdd")
            End If
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class