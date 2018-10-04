Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptBoxOfficeAndLateShowParam3
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.Visible = False

        If Not IsPostBack Then
            If Hour(Now) < 6 Then
                dtpStartDate.SelectedDate = Today.AddDays(-1)
                dtpEndDate.SelectedDate = Today.AddDays(-1).AddDays(6)
            Else
                dtpStartDate.SelectedDate = Today
                dtpEndDate.SelectedDate = Today.AddDays(6)
            End If
        End If

        If Mid(Session("permission"), 24, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If (dtpEndDate.SelectedDate < dtpStartDate.SelectedDate) Then
            lblError.Visible = True
            Return
        End If

        Session("strDateComp") = dtpStartDate.SelectedDate
        Session("strDateEndComp") = dtpEndDate.SelectedDate

        Response.Redirect("frmRptBoxOfficeAndLateShow3.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class