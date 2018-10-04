Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptTrailerByTotalParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            Session("SetupNoPopup") = Nothing
            cDB.LoadDataToDropdownList(ddlCircuitID, "tblCircuit", "circuit_name", "circuit_id", "")
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If (Session("SetupNoPopup") <> Nothing) Then
            MoviePopupSN1.SetupNo = Convert.ToString(Session("SetupNoPopup"))
            MoviePopupSN1.BindData()
        Else
            MoviePopupSN1.SetupNo = ""
            MoviePopupSN1.BindData()
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
        'Session("rptSetupNo") = SetupPopup1.SetupNo
        'Session("rptDate") = SetupPopup1.PeriodDate
        'Session("rptCircuitID") = ddlCircuitID.SelectedValue
        'If (MoviePopupSN1.MovieId = 0) Then
        '    Session("rptMovieID") = "null"
        'Else
        '    Session("rptMovieID") = MoviePopupSN1.MovieId
        'End If
        Response.Redirect("frmRptTrailerByTotal.aspx?rptMovieID=" + IIf(MoviePopupSN1.MovieId = 0, "null", MoviePopupSN1.MovieId.ToString()) + "&rptSetupNo=" + SetupPopup1.SetupNo + "&rptDate=" + SetupPopup1.PeriodDate + "&rptCircuitID=" + ddlCircuitID.SelectedValue)
    End Sub
End Class