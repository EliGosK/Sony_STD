Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class RemainMovieList
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnBackToMovieListClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToMovieList.Click
            Redirect(PageName.MovieList)
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
            Dim theaterId = GetTheaterId()
            Dim beforeDate As Date = GetWorkingDate()

            Dim dtbOwnerRevenue As DataTable = RevenueOwner.SelectData(Nothing, Nothing, Nothing, theaterId, Nothing, Nothing, 3, beforeDate)
            UpdateLinkColumnAndBindGrid(dtbOwnerRevenue, grdOwnerRevenue, lblOwnerRevenue)

            'Dim dtbOwnerFreeTicket As DataTable = FreeTicketAndPerCapRevenueHeader.SelectAllIncomplete(theaterId, beforeDate)
            'UpdateLinkColumnAndBindGrid(dtbOwnerFreeTicket, grdOwnerFreeTicket, lblOwnerFreeTicket)

            'Dim dtbOwnerTicketType As DataTable = TicketTypeRevenueHeader.SelectAllIncomplete(theaterId, beforeDate)
            'UpdateLinkColumnAndBindGrid(dtbOwnerTicketType, grdOwnerTicketType, lblOwnerTicketType)

            Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, Nothing, Nothing, theaterId, 3, beforeDate)
            grdCompetitor.Visible = False
            lblCompetitor.Visible = False
            If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                dtbCompHeader.Columns.Add("LinkTo", GetType(String))

                For i As Integer = 0 To dtbCompHeader.Rows.Count - 1
                    Dim dr As DataRow = dtbCompHeader.Rows(i)

                    Dim movieId As Int32 = CInt(dr("movie_id"))
                    Dim movieName As String = dr("MovieName").ToString()
                    Dim revenueCompHeaderId As Int32 = CInt(dr("revenue_comp_header_id"))

                    Dim param As String = GetParamString(PageName.RemainMovieList, movieName, movieId, 2, Nothing, revenueCompHeaderId)

                    dr("LinkTo") = GetRedirectUrl(PageName.SendRevenue, param)
                Next
                grdCompetitor.Visible = True
                lblCompetitor.Visible = True
            End If
            grdCompetitor.DataSource = dtbCompHeader
            grdCompetitor.DataBind()
        End Sub
        Private Sub UpdateLinkColumnAndBindGrid(ByVal dtb As DataTable, ByVal dgv As GridView, ByVal lblTitle As Label)
            dgv.Visible = False
            lblTitle.Visible = False
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("LinkTo", GetType(String))

                For i As Integer = 0 To dtb.Rows.Count - 1
                    Dim dr As DataRow = dtb.Rows(i)

                    Dim movieId As Int32 = CInt(dr("movie_id"))
                    Dim movieName As String = dr("MovieName").ToString()
                    Dim revenueId As Int32 = CInt(dr("revenueid"))

                    Dim param As String = GetParamString(PageName.RemainMovieList, movieName, movieId, 1, revenueId, Nothing)

                    dr("LinkTo") = GetRedirectUrl(PageName.SendRevenue, param)
                Next
                dgv.Visible = True
                lblTitle.Visible = True
            End If
            dgv.DataSource = dtb
            dgv.DataBind()
        End Sub
#End Region

    End Class
End Namespace