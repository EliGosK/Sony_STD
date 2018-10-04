Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByTheater
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 3, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            ViewState("sumSeat") = 0
        End If
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblDate.NavigateUrl = "frmRevByDate.aspx?revDate=" & Session("revDate")
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")

        Dim theaterId As Integer
        If (Not ValidateQueryString(Request.QueryString("theaterId"), GetType(Integer), theaterId)) Then
            Response.Redirect("frmRevByDate.aspx")
        End If

        'Session("theaterId") = Request.QueryString("theaterId")
        Session("theaterId") = theaterId
        'TheaterName.Text = Session("theaterId")

        Dim getMovieDetail As New cDatabase
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(Session("movieId"))
        If dataReader.Read = True Then
            txtTitle.Text = dataReader("movie_nameen") & "/" & dataReader("movie_nameth")
            lblMovieId.Text = dataReader("movie_nameen")
            txtDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReader("movie_gern") & "/" & dataReader("movie_gernsub")
            txtDis.Text = dataReader("distributor_name")
        End If

        Dim dataReadTheater As IDataReader = getMovieDetail.getTheaterDetail(Session("theaterId"))
        If dataReadTheater.Read = True Then
            TheaterName.Text = dataReadTheater("theater_name")
        End If
        dataReader.Close()

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBoxOffice.DataBound
        If grdBoxOffice.Rows.Count > 0 Then
            grdBoxOffice.FooterRow.Cells(1).Text = "Total :"
            grdBoxOffice.FooterRow.Cells(2).Text = Format(Session("sumAmount"), "#,##0")
            grdBoxOffice.FooterRow.Cells(3).Text = Format(Session("sumADMS"), "#,##0")
            grdBoxOffice.FooterRow.Cells(4).Text = Format(Session("sumSession"), "#,##0")
            grdBoxOffice.FooterRow.Cells(5).Text = Convert.ToDecimal(Request.QueryString("sumopc")).ToString("#,##0.00") 'Format((Convert.ToDouble(Session("sumADMS")) / ViewState("sumSeat")) * 100, "#,##0.00")

            Session("sumAmount") = "0"
            Session("sumADMS") = "0"
            'Session("sumScreen") = "0"
            Session("sumSession") = "0"
            'Session("sumOpc") = "0"
        End If
    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged

    End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
            Dim dr As Data.DataRowView = e.Row.DataItem
            If Mid(Session("permission"), 5, 1) = "0" Then
                e.Row.Cells(0).Enabled = False
                e.Row.Cells(1).Enabled = False
            End If
            If dr(10) = "[-]เบื้องต้น" Then

                ' e.Row.BackColor = Color.LightGoldenrodYellow
                'e.Row.Font.Bold = False
                e.Row.ForeColor = Color.Orange
            ElseIf dr(10) = "[฿]ยอดจริง" Then
                ' e.Row.BackColor = Color.DarkSeaGreen
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Green
            Else
                ' e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.DarkGray
            End If
            Session("sumAmount") = Session("sumAmount") + dr(1)
            Session("sumADMS") = Session("sumADMS") + dr(0)
            'Session("sumScreen") = Session("sumScreen") + dr(5)
            Session("sumSession") = Session("sumSession") + dr(6)
            Session("sumOpc") = Convert.ToDecimal(Request.QueryString("sumopc")).ToString("#,##0.00") 'Session("sumOpc") + dr(13)

            'ConvertTime By Pachara S. (C.S.I. Groups) on 20170525
            e.Row.Cells(8).Text = ConvertTimeToLocaltime(dr(11))

            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell
            e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell

            'Dim strSQL As String
            'strSQL = "select count(*) as countRow from (SELECT tblRevenue.revenueid, tblRevenue.revenue_adms, tblRevenue.revenue_amount, tblRevenue.revenue_date, "
            'strSQL += vbNewLine + " tblRevenue.revenue_Time, tblRevenue.revenue_LastUpdate, tblRevenue.revenue_type, "
            'strSQL += vbNewLine + " tblRevenue.theatersub_id, tblRevenue.user_id, tblRevenue.movie_system, tblRevenue.movies_id, "
            'strSQL += vbNewLine + " tblRevenue.theater_id, tblRevenue.status_id, tblRevenue.sound_type, tblRevenue.timehour_id, "
            'strSQL += vbNewLine + " tblRevenue.timemin_id, tblUser.user_name, tblRevStatus.status, tblRevStatus.statusColor, "
            'strSQL += vbNewLine + "  (convert(decimal(15,2), tblRevenue.revenue_adms) / convert(decimal(15,2), mSeat.theatersub_normalseat))*100 AS opc, mSeat.theatersub_normalseat  "
            'strSQL += vbNewLine + " FROM tblRevenue LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id "
            'strSQL += vbNewLine + " LEFT JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.id LEFT JOIN "
            'strSQL += vbNewLine + " (SELECT theatersub_normalseat,theater_id,theatersub_id FROM tblTheaterSub "
            'strSQL += vbNewLine + " WHERE (theater_id = " + dr("theater_id").ToString() + ") AND (theatersub_id = " + dr("theatersub_id").ToString() + ")) mSeat "
            'strSQL += vbNewLine + " ON tblRevenue.theater_id = mSeat.theater_id AND tblRevenue.theatersub_id = mSeat.theatersub_id "
            'strSQL += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblRevenue.theater_id = " + dr("theater_id").ToString() + ") "
            'strSQL += vbNewLine + " AND (tblRevenue.revenue_date = '" + Session("revDate").ToString() + "') AND (tblRevenue.theatersub_id = " + dr("theatersub_id").ToString() + ") "
            'strSQL += vbNewLine + " ) tblNew"

            'Dim cDB As New cDatabase
            'Dim drGetCount As IDataReader
            'drGetCount = cDB.GetDataAll(strSQL)
            'Dim intContRow As Integer = 0
            'If (drGetCount.Read()) Then
            '    intContRow = cDB.CheckIsNullInteger(drGetCount("countRow"))


            'End If
            'drGetCount.Close()

            'Session("countSeat") = intContRow

            'Dim decSeat As Decimal = (cDB.CheckIsNullInteger(dr(0)) / ((cDB.CheckIsNullInteger(dr(12)) * intContRow))) * 100
            'e.Row.Cells(5).Text = Format(decSeat, "#,##0.00")
            'ViewState("sumSeat") = ViewState("sumSeat") + (cDB.CheckIsNullInteger(dr(12)) * intContRow)

        End If
    End Sub
End Class