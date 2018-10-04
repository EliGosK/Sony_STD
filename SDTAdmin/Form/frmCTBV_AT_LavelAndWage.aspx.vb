Imports System.Web.Security
Partial Public Class frmCTBV_AT_LavelAndWage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 44, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Mid(Session("permission"), 32, 1) = "0" Then
            imbtnMTC0.Enabled = False
            imbtnMTC0.ImageUrl = "~/images/MenuWage2_disable.jpg"
        End If
        If Mid(Session("permission"), 38, 1) = "0" Then
            imgbtnLevel.Enabled = False
            imgbtnLevel.ImageUrl = "~/images/MenuWage1_disable.jpg"
        End If
        If Mid(Session("permission"), 39, 1) = "0" Then
            imgbtnPresent.Enabled = False
            imgbtnPresent.ImageUrl = "~/imagesMenuWage4_disable.jpg"
        End If
        If Mid(Session("permission"), 40, 1) = "0" Then
            imgbtmFormer.Enabled = False
            imgbtmFormer.ImageUrl = "~/images/MenuWage3_disable.jpg"
        End If
        If Mid(Session("permission"), 41, 1) = "0" Then
            imgbtnConfig.Enabled = False
            imgbtnConfig.ImageUrl = "~/images/MenuWage5_disable.jpg"
        End If
        If Mid(Session("permission"), 42, 1) = "0" Then
            imgbtnSession.Enabled = False
            imgbtnSession.ImageUrl = "~/images/MenuWage6_disable.jpg"
        End If
        
    End Sub


    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub imbtnMTC0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnMTC0.Click
        Response.Redirect("frmCTBV_AT_LateShow.aspx")
    End Sub

    Protected Sub imgbtnLevel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnLevel.Click
        Response.Redirect("frmCTBV_AT_Level.aspx")
    End Sub

    Protected Sub imgbtnPresent_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnPresent.Click
        Response.Redirect("frmCTBV_AT_Present.aspx")
    End Sub

    Protected Sub imgbtmFormer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtmFormer.Click
        Response.Redirect("frmCTBV_AT_Former.aspx")
    End Sub

    Protected Sub imgbtnConfig_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnConfig.Click
        Response.Redirect("frmCTBV_AT_Config.aspx")
    End Sub

    Protected Sub imgbtnSession_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSession.Click
        Response.Redirect("frmCTBV_AT_Session.aspx")
    End Sub

  
End Class