Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptTrailerByPercentParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = ""

        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            Session("SetupNoPopup") = Nothing
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
        Try

            If (Movie1Popup1.MovieId = 0) Then
                Label1.Visible = True
                Label1.Text = "Please check require flield (*)"
                Return
            End If

            If (MoviePopupSN1.MovieId = 0 And SetupPopup1.SetupNo = "") Then
                Label1.Visible = True
                Label1.Text = "Please select Setup No. or Trailer I.D."
                Return
            End If


            Session("rptRealMovie") = Movie1Popup1.MovieId
            Session("rptTrailerMovie") = MoviePopupSN1.MovieId
            Session("rptSetupNo") = SetupPopup1.SetupNo
            Session("rptPeriod") = SetupPopup1.PeriodDate

            Response.Redirect("frmRptTrailerByPercent.aspx")
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try

    End Sub
End Class