Option Strict On

Imports Web.Data
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class CheckerTransaction
        Inherits MasterPage

#Region "Event Handlers"
        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            User.Logout()
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            If Mid(CStr(Session("permission")), 6, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If

            Dim revDate As String = Session("revDate").ToString()
            hplRevenueDate.Text = Right(revDate, 2) & "-" & Mid(revDate, 5, 2) & "-" & Left(revDate, 4)
            Dim dbConnecter As New cDatabase
            Dim dataReaderMovie As IDataReader = dbConnecter.getMovieDetail(CInt(Session("movieId")))
            If dataReaderMovie.Read Then
                txtTitle.Text = dataReaderMovie("movie_nameen").ToString() & "/" & dataReaderMovie("movie_nameth").ToString()
                hplMovieName.Text = dataReaderMovie("movie_nameen").ToString()
                txtReleaseDate.Text = Format(dataReaderMovie("movie_strdate"), "ddd dd-MMM-yyyy")
                txtGenre.Text = dataReaderMovie("movie_gern").ToString() & "/" & dataReaderMovie("movie_gernsub").ToString()
                txtDis.Text = dataReaderMovie("distributor_name").ToString()
            End If
            dataReaderMovie.Close()

            Dim dataReadTheater As IDataReader = dbConnecter.getTheaterDetail(CInt(Session("theaterId")))
            If dataReadTheater.Read Then
                hplTheaterName.Text = dataReadTheater("theater_name").ToString()
            End If
            dataReadTheater.Close()

            hplMovieName.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId").ToString()

            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId, GetRedirectUrl(PageName.MovieList)), Int32)
            If movieTypeId = 1 Then
                Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
                Dim dtbOwner As DataTable = RevenueOwner.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                    lblSession.Text = CStr(dtbOwner.Rows(0)("revenue_Time"))
                End If

                hplRevenueDate.NavigateUrl = "frmRevByDate.aspx?revDate=" & Session("revDate").ToString()
                hplTheaterName.NavigateUrl = "frmRevBytheater.aspx?theaterId=" & Session("theaterId").ToString()
                hplScreen.NavigateUrl = "frmRevByscrn.aspx?revScreen=" & Session("revScreen").ToString()
                hplScreen.Text = "Screen No.: " & Session("revScreen").ToString()
            Else
                hplScreen.Visible = False
                lblBeforeSession.Visible = False

                hplRevenueDate.NavigateUrl = "frmRevByDateComp.aspx?revDate=" & Session("revDate").ToString()
                Dim revenueCompHeaderId As Int32 = CType(GetRequest(ParamList.RevenueCompHeaderId), Int32)
                If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId > 0 Then
                    lblBeforeScreen.Visible = False
                    hplTheaterName.Visible = False
                    lblSession.Text = hplTheaterName.Text
                Else
                    hplTheaterName.NavigateUrl = "frmRevByTheaterComp.aspx?theaterId=" & Session("theaterId").ToString()
                    lblSession.Text = "Revenue"
                End If
            End If
        End Sub
#End Region

    End Class
End Namespace