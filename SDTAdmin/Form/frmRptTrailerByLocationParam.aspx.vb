Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptTrailerByLocationParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                cDB.LoadDataToDropdownList(ddlCircuitID, "tblCircuit", "circuit_name", "circuit_id", "")
            End If
            If Mid(Session("permission"), 7, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_Menu_Trailer_Rpt.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Session("rptSetupNo") = SetupPopup1.SetupNo
        Session("rptDate") = SetupPopup1.PeriodDate
        Session("rptCircuitID") = ddlCircuitID.SelectedValue
        Response.Redirect("frmRptTrailerByLocation.aspx")
    End Sub

End Class