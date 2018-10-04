Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptPDABoxOfficeParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblError.Text = ""
        End If
        If Mid(Session("permission"), 25, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")

    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try

            If (Movie1Popup1.MovieId = 0) Then
                lblError.Visible = True
                lblError.Text = "Please check require flield (*)"
                Return
            End If

            Session("PDABoxOffice_Movie") = Movie1Popup1.MovieId
            Response.Redirect("frmRptPDABoxOffice.aspx")

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub
End Class