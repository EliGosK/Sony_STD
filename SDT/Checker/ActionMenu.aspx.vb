Imports SDTCommon.Extensions
Imports SDTCommon

Namespace Checker
    Partial Public Class ActionMenu
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnProblemClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnProblem.Click
            Redirect(PageName.ProblemRecord)
        End Sub
        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExit.Click
            DBInterface.User.Logout()
        End Sub
        Protected Sub BtnMessageClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMessage.Click
            Redirect(PageName.SystemMessage)
        End Sub
        Protected Sub BtnReportClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnReport.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnTrailerCollectionClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrailerCollection.Click
            Redirect(PageName.TrailerCollection)
        End Sub
        Protected Sub BtnMovieTrailerClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMovieTrailer.Click
            Redirect(PageName.Trailer)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            Dim btnMsgEnabled As Boolean = False
            Dim btnMsgText As String = "ข้อความ"
            Dim btnMsgClass As String = "ButtonDefualt"
            Dim dtb As DataTable = DBInterface.Message.SelectFirstQuestionByTheater(GetTheaterId())
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                If dtb.Rows(0)("read_flag").ToString() = "N" Then
                    btnMsgText = "*คุณมีข้อความใหม่!"
                    btnMsgClass = "ButtonNewMsg"
                End If
                btnMsgEnabled = True
            End If

            btnMessage.Enabled = btnMsgEnabled
            btnMessage.Text = btnMsgText
            btnMessage.CssClass = btnMsgClass
        End Sub
#End Region

    End Class
End Namespace