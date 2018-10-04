Imports System.Web.Security
Partial Public Class frmCTBV_AT_Main
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 10, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Mid(Session("permission"), 29, 1) = "0" Then
            imbtnUserSetting.Enabled = False
            imbtnUserSetting.ImageUrl = "~/images/MenuAdmin1_disable.jpg"
        End If
        If Mid(Session("permission"), 30, 1) = "0" Then
            imbtnMTC.Enabled = False
            imbtnMTC.ImageUrl = "~/images/MenuAdmin2_disable.jpg"
        End If
        If Mid(Session("permission"), 31, 1) = "0" Then
            imbtnBoxOfficeStatus.Enabled = False
            imbtnBoxOfficeStatus.ImageUrl = "~/images/MenuAdmin3_disable.jpg"
        End If

        If Mid(Session("permission"), 44, 1) = "0" Then
            imbtncheckerLevelAndWage.Enabled = False
            imbtncheckerLevelAndWage.ImageUrl = "~/images/MenuAdmin4_disable.jpg"
        End If
        If Mid(Session("permission"), 43, 1) = "0" Then
            imbtnWeeklyMovieSetup.Enabled = False
            imbtnWeeklyMovieSetup.ImageUrl = "~/images/MenuAdmin5_disable.jpg"
        End If
        If Mid(Session("permission"), 58, 1) = "0" Then
            imbtnSystemPolicies.Enabled = False
            imbtnSystemPolicies.ImageUrl = "~/images/MenuAdmin7_disable.jpg"
        End If
    End Sub

    Protected Sub imbtnUserSetting_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnUserSetting.Click
        Response.Redirect("frmCTBV_AT.aspx")
    End Sub

    Protected Sub imbtnBoxOfficeStatus_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnBoxOfficeStatus.Click
        Response.Redirect("frmCTBV_AT_monitorStatus.aspx")
    End Sub

    Protected Sub imbtnMTC_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnMTC.Click
        Response.Redirect("frmCTBV_AT_Message.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub imbtncheckerLevelAndWage_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtncheckerLevelAndWage.Click
        Response.Redirect("frmCTBV_AT_LavelAndWage.aspx")
    End Sub

    Protected Sub imbtnWeeklyMovieSetup_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnWeeklyMovieSetup.Click
        Response.Redirect("frmCTBV_AT_SetupDate.aspx")
    End Sub

    Protected Sub imbtnSystemPolicies_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnSystemPolicies.Click
        Response.Redirect("frmCTBV_AT_SystemPolicies.aspx")
    End Sub
End Class