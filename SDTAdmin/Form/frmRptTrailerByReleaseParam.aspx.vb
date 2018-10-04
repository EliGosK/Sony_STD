Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptTrailerByReleaseParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
        If Not IsPostBack Then
            Label1.Text = ""
        End If
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_Menu_Trailer_Rpt.aspx")

    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            If (Movie1Popup1.MovieId = 0) Then
                Label1.Text = "Please check require flield (*)"
                Label1.Visible = True
                Return
            End If

            If (Trailer_Header_SetupPopup1.SetupNo.Trim() = "") Then
                Label1.Text = "Please check require flield (*)"
                Label1.Visible = True
                Return
            End If

            Session("rptRealMovie") = Movie1Popup1.MovieId
            Session("rptSetupNo") = Trailer_Header_SetupPopup1.SetupNo
            Session("rptDate") = Trailer_Header_SetupPopup1.PeriodDate
            Response.Redirect("frmRptTrailerByRelease.aspx")
        Catch ex As Exception
            Label1.Text = ex.Message
            Label1.Visible = True
        End Try
    End Sub


End Class