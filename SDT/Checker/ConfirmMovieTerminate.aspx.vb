Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class ConfirmMovieTerminate
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId), Int32)
            Dim theaterId As Int32 = GetTheaterId()
            'Dim userId As String = GetUserId()

            Select Case movieTypeId
                Case 1
                    RevenueOwner.UpdateStatus(movieId, theaterId, 1)
                Case 2
                    Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, movieId, Nothing, theaterId, Nothing, Nothing)
                    If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                        For Each dr As DataRow In dtbCompHeader.Rows
                            Dim revenueCompHeaderId As Int32 = CInt(dr("revenue_comp_header_id"))
                            RevenueCompDetail.UpdateStatus(revenueCompHeaderId, 1)
                            RevenueCompHeader.UpdateStatus(revenueCompHeaderId, 1)
                        Next
                    End If
            End Select

            MovieAndTrailer.UpdateInsertMovieTerminate(movieId, theaterId, GetWorkingDate())

            Dim isExist As Boolean = MovieAndTrailer.IsMovieExist(movieId)
            If Not isExist Then
                MovieAndTrailer.UpdateMovieStatus(movieId, 2)
            End If

            Redirect(PageName.MovieList)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            'Check Param
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId, GetRedirectUrl(PageName.MovieList)), Integer)
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId, GetRedirectUrl(PageName.MovieList)), Integer)
            Dim theaterId As Int32 = GetTheaterId()

            Select Case movieTypeId
                Case 1
                    Dim dtbOwner As DataTable = RevenueOwner.SelectData(Nothing, movieId, Nothing, theaterId, Nothing, Nothing, 3, Nothing)
                    If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                        Return
                    End If
                Case 2
                    Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, movieId, Nothing, theaterId, 3, Nothing)
                    If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                        Return
                    End If
            End Select
            lblMessage.Text = "แจ้งหนังออกจากโรง !" & vbNewLine & "(Terminate)"
            btnOk.Visible = True
        End Sub
#End Region

    End Class
End Namespace