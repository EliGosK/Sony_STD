Option Strict On

Imports Web.Data

Namespace Form
    Partial Public Class FrmReportMovieMarketShareParam
        Inherits Page

#Region "Event Handlers"

        Protected Sub BtnCancelMovieClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelMovie.Click
            Response.Redirect("frmCTBV_RC_Menu.aspx")
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnSearchClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnSearch.Click
            If IsNothing(moviePopup.MovieId) OrElse moviePopup.MovieId = 0 Then
            Else
                Response.Redirect("frmReportMovieMarketShare.aspx?movieid=" & moviePopup.MovieId & "&groupby=" & ddlGroup.SelectedValue & "&datetype=BoxOffice" & "&datefrom=" & dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&dateto=" & dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd"))
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Report_MovieMarketShare, True)

            moviePopup.MovieType = "1"
            moviePopup.VisibleMovieType = False
            moviePopup.BindData()
        End Sub

        Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If moviePopup.MovieId <> 0 Then
                Dim cDb As New cDatabase
                Dim dataReader As IDataReader = cDb.getMovieDetail(moviePopup.MovieId)
                If dataReader.Read Then
                    Dim startDate As Date? = CType(dataReader("movie_strdate"), Date?)
                    If Not IsNothing(startDate) Then
                        dtpStartDate.SelectedDate = startDate
                        dtpEndDate.SelectedDate = startDate.Value.AddDays(+6)
                    End If
                End If
                dataReader.Close()
            End If
        End Sub

#End Region
    End Class
End Namespace