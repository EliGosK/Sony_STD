Imports System.Drawing
Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class MovieList
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnMainMenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMainMenu.Click
            Redirect(PageName.ActionMenu)
        End Sub
        Protected Sub BtnSearchClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
            ShowData()
        End Sub
        Protected Sub BtnRemainClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemain.Click
            Redirect(PageName.RemainMovieList)
        End Sub

        '<Columns>
        '    <asp:TemplateField>
        '        <ItemTemplate>
        '            <asp:HyperLink ID="hplLinkTo" runat="server" Text='<%# Bind("MovieName") %>' HeaderText="รายชื่อภาพยนตร์" />
        '        </ItemTemplate>
        '    </asp:TemplateField>
        '</Columns>

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim objName = e.Row.Cells(1).FindControl("hplName")
            If IsNothing(objName) Then
                Return
            End If
            Dim hplName As HyperLink = CType(objName, HyperLink)
            Dim imgStatus As WebControls.Image = CType(e.Row.Cells(0).FindControl("imgStatus"), WebControls.Image)

            'Dim movieId As Int32 = CType(DataBinder.Eval(e.Row.DataItem, "movie_id"), Int32)
            Dim movieTypeId As Int32 = CType(DataBinder.Eval(e.Row.DataItem, "movietype_id"), Int32)
            'Dim movieName As String = DataBinder.Eval(e.Row.DataItem, "MovieName").ToString()
            'Dim param As String = GetParamString(PageName.MovieList, movieName, movieId, movieTypeId, Nothing, Nothing)

            Dim release = DataBinder.Eval(e.Row.DataItem, "onrelease_id")
            If IsNothing(release) OrElse String.IsNullOrEmpty(release.ToString()) Then
                hplName.ForeColor = Color.Red
            Else
                If movieTypeId.ToString() = "1" Then
                    hplName.ForeColor = Color.DarkBlue
                Else
                    hplName.ForeColor = Color.Firebrick
                End If
            End If

            If DataBinder.Eval(e.Row.DataItem, "LinkToIcon").ToString() = "../images/icon_accept.gif" Then
                imgStatus.Visible = False
            End If

            Dim objRevenue = e.Row.Cells(0).FindControl("hplRevenue")
            If IsNothing(objRevenue) Then
                Return
            End If
            Dim hplRevenue As HyperLink = CType(objRevenue, HyperLink)
            Dim currentComplete As Boolean = CType(DataBinder.Eval(e.Row.DataItem, "CurrentComplete"), Boolean)
            If currentComplete Then
                hplRevenue.ForeColor = Color.Green
            Else
                hplRevenue.ForeColor = Color.Orange
            End If
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            ShowData()
        End Sub
#End Region

#Region "Methods"
        Private Sub ShowData()
            Dim movietitle As String = Nothing
            If Not String.IsNullOrEmpty(txtSearch.Text.Trim()) Then
                movietitle = txtSearch.Text.Trim()
            End If
            Dim theaterId As Int32 = GetTheaterId()
            Dim dtb As DataTable = MovieAndTrailer.GetMovieRelease(Nothing, movietitle, theaterId, Nothing, Nothing, Nothing)
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("LinkTo", GetType(String))
                dtb.Columns.Add("LinkToIcon", GetType(String))
                dtb.Columns.Add("LinkTerminate", GetType(String))
                dtb.Columns.Add("Revenue", GetType(String))
                dtb.Columns.Add("CurrentComplete", GetType(Boolean))

                Dim revenueDate As Date = GetWorkingDate()
                Dim dtbDailyRevenue As DataTable = Revenue.SelectDailyRevenue(theaterId, revenueDate)
                'Dim dtbIncompleteMovieFreeTicketAndPerCap As DataTable = FreeTicketAndPerCapRevenueHeader.SelectIncompleteMovie(theaterId, revenueDate)
                'Dim dtbIncompleteMovieTicketType As DataTable = TicketTypeRevenueHeader.SelectIncompleteMovie(theaterId, revenueDate)

                For Each dr As DataRow In dtb.Rows
                    Dim movieName As String = dr("MovieName").ToString()
                    Dim movieId As Int32 = CInt(dr("movie_id"))
                    Dim movieTypeId As Int32 = CInt(dr("movietype_id"))

                    Dim param As String = GetParamString(PageName.SendRevenue, movieName, movieId, movieTypeId, Nothing, Nothing)
                    dr("LinkTerminate") = GetRedirectUrl(PageName.ConfirmMovieTerminate, param)
                    dr("Revenue") = String.Empty
                    dr("CurrentComplete") = False

                    Dim release = dr("onrelease_id")
                    If IsNothing(release) OrElse String.IsNullOrEmpty(release.ToString()) Then
                        dr("LinkToIcon") = "../images/icon_new.gif"
                        dr("LinkTo") = GetRedirectUrl(PageName.ConfirmMovieRelease, param)
                    Else
                        dr("LinkToIcon") = "../images/icon_wait.gif"
                        For Each drc As DataRow In dtbDailyRevenue.Rows
                            Dim movieIdStr As String = dr("movie_id").ToString()
                            If movieIdStr = drc("movie_id").ToString() Then
                                dr("Revenue") = String.Format("{0:#,##0}", drc("sum_revenue"))
                                If drc("is_complete").ToString() = "1" Then
                                    dr("CurrentComplete") = True
                                    'If dtbIncompleteMovieFreeTicketAndPerCap.Rows.Cast(Of DataRow)().Any(Function(drf) movieIdStr = drf("movie_id").ToString()) Then
                                    '    dr("LinkToIcon") = "../images/icon_ticket_rev.gif"
                                    'ElseIf dtbIncompleteMovieTicketType.Rows.Cast(Of DataRow)().Any(Function(drt) movieIdStr = drt("movie_id").ToString()) Then
                                    '    dr("LinkToIcon") = "../images/icon_ticket_type.gif"
                                    'Else
                                    dr("LinkToIcon") = "../images/icon_accept.gif"
                                    'End If
                                End If
                                dtbDailyRevenue.Rows.Remove(drc)
                                Exit For
                            End If
                        Next
                        dr("LinkTo") = GetRedirectUrl(PageName.SendRevenue, param)
                    End If
                Next
            End If
            grdResult.DataSource = dtb
            grdResult.DataBind()
        End Sub
#End Region

    End Class
End Namespace