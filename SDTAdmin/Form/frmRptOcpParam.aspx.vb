Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptOcpParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 34, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            lblerror.Visible = False

            '--- Added by Wittawat W. on 2012/11/28 : Add date period
            If Date.Now.Hour < 6 Then
                Me.dtpStartDate.SelectedDate = Date.Today.AddDays(-1)
                Me.dtpEnddate.SelectedDate = Date.Today.AddDays(+5)
            Else
                Me.dtpStartDate.SelectedDate = Date.Today
                Me.dtpEnddate.SelectedDate = Date.Today.AddDays(+6)
            End If
            '--- End added by Wittawat W. on 2012/11/28 : Add date period

            Movie1Popup1.MovieId = 0
            Movie1Popup1.MovieType = "1"
            Movie1Popup1.VisibleMovieType = False
            Movie1Popup1.BindData()
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Me.Movie1Popup1.MovieId <> 0 Then
            Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
            If dataReader.Read = True Then
                Me.dtpStartDate.SelectedDate = dataReader("movie_strdate")
                Me.dtpEndDate.SelectedDate = dataReader("movie_strdate").AddDays(+6)

                Session("opcMovieID") = Movie1Popup1.MovieId
                Session("opcMovieName") = dataReader("movie_nameen")
            End If
            dataReader.Close()
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If Movie1Popup1.MovieId = 0 Then
            lblerror.Visible = True
        Else
            Session("opcMovieID") = Movie1Popup1.MovieId
            Session("opcStartTheatre") = TheatrePopup1.TheatreNo
            Session("opcEndTheatre") = TheatrePopup2.TheatreNo
            '--- Added by Wittawat W. on 2012/11/28 : Add date period
            Session("opcStartDate") = Me.dtpStartDate.SelectedDate
            Session("opcEndDate") = Me.dtpEnddate.SelectedDate
            '--- End added by Wittawat W. on 2012/11/28 : Add date period
            Response.Redirect("frmRptOcp.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub


End Class