Imports SDTCommon.Extensions
Imports SDTCommon

Namespace Checker
    Partial Public Class ConfirmMovieRelease
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnNotReleaseClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnNotRelease.Click
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim theaterId As Int32 = GetTheaterId()

            DBInterface.MovieAndTrailer.InsertMovieReleaseStatus(movieId, theaterId, 3, GetWorkingDate_yyyyMMdd())

            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnReleaseClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnRelease.Click
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim theaterId As Int32 = GetTheaterId()

            DBInterface.MovieAndTrailer.UpdateMovieStatus(movieId, 1)
            DBInterface.MovieAndTrailer.InsertMovieReleaseStatus(movieId, theaterId, 1, GetWorkingDate_yyyyMMdd())
            DBInterface.MovieAndTrailer.InsertMovieTheater(movieId, theaterId, 1, GetUserId())

            Redirect(PageName.MovieList)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            'Check Param

            GetRequest(ParamList.MovieId, GetRedirectUrl(PageName.MovieList))
            GetRequest(ParamList.MovieTypeId, GetRedirectUrl(PageName.MovieList))
        End Sub
#End Region

    End Class
End Namespace