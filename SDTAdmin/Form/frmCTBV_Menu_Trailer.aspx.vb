Imports Web.Data
Imports System.Web.Security
Partial Public Class frmCTBV_Menu_Trailer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Mid(Session("permission"), 12, 1) = "0" Then
            imbtnTrialer.Enabled = False
            imbtnTrialer.ImageUrl = "~/images/MenuTrailer1.jpg"
        End If
        If Mid(Session("permission"), 13, 1) = "0" Then
            ImageButton2.Enabled = False
            ImageButton2.ImageUrl = "~/images/MenuTrailer2.jpg"
        End If
        If Mid(Session("permission"), 14, 1) = "0" Then
            ImageButton1.Enabled = False
            ImageButton1.ImageUrl = "~/images/MenuTrailer3.jpg"
        End If
    End Sub

    Protected Sub imbtnTrialer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnTrialer.Click
        Response.Redirect("frmCTBV_Trailer_Setup_Detail.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("frmCTBV_Trailer_Show.aspx")
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("frmCTBV_Menu_Trailer_Rpt.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class