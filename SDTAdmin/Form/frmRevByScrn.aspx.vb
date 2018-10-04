Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByScrn
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 5, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            ViewState("sumSeat") = 0
        End If
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblDate.NavigateUrl = "frmRevByDate.aspx?revDate=" & Session("revDate")
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")

        Dim revScreen As Integer
        If (Not ValidateQueryString(Request.QueryString("revScreen"), GetType(Integer), revScreen)) Then
            Response.Redirect("frmRevByTheater.aspx")
        End If

        Session("revScreen") = revScreen
        lblScreen.Text = "Screen No.: " & revScreen
        'TheaterName.Text = Session("theaterId")
        TheaterName.NavigateUrl = "frmRevBytheater.aspx?theaterId=" & Session("theaterId")
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
        'gvDatabind()
    End Sub

    Protected Sub txtTitle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTitle.TextChanged

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBoxOffice.DataBound
        If grdBoxOffice.Rows.Count > 0 Then
            grdBoxOffice.FooterRow.Cells(0).Text = "Total :"
            grdBoxOffice.FooterRow.Cells(1).Text = Format(Session("sumAmount"), "#,##0")
            grdBoxOffice.FooterRow.Cells(2).Text = Format(Session("sumADMS"), "#,##0")
            grdBoxOffice.FooterRow.Cells(3).Text = Format(Format(Session("sumADMS"), "#,##0") / (ViewState("sumSeat") * grdBoxOffice.Rows.Count) * 100, "#,##0.00")
            Session("sumAmount") = "0"
            Session("sumADMS") = "0"
        End If
    End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            Dim dr As Data.DataRowView = e.Row.DataItem
            If Mid(Session("permission"), 6, 1) = "0" Then
                e.Row.Cells(0).Enabled = False
            End If
            If dr(17) = "[-]เบื้องต้น" Then

                ' e.Row.BackColor = Color.LightGoldenrodYellow
                'e.Row.Font.Bold = False
                e.Row.ForeColor = Color.Orange
            ElseIf dr(17) = "[฿]ยอดจริง" Then

                ' e.Row.BackColor = Color.DarkSeaGreen
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Green
            Else
                ' e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.DarkGray
            End If
            Session("sumAmount") = Session("sumAmount") + dr("revenue_amount")
            Session("sumADMS") = Session("sumADMS") + dr("revenue_adms")
            ViewState("sumSeat") = dr("theatersub_normalseat")
            Session("countSeat") = Session("countSeat") + 1
            'Session("sumScreen") = Session("sumScreen") + dr(5)
            'Session("sumSession") = Session("sumSession") + dr(6

            'ConvertTime By Pachara S. (C.S.I. Groups) on 20170525
            e.Row.Cells(7).Text = ConvertTimeToLocaltime(dr(5))
            e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell
            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell

        End If
    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged

    End Sub

    '--- Commented by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound
    'Sub gvDatabind()
    '    Dim strSQL As String
    '    strSQL = "SELECT tblRevenue.revenueid, tblRevenue.revenue_adms, tblRevenue.revenue_amount, tblRevenue.revenue_date, "
    '    strSQL += vbNewLine + " tblRevenue.revenue_Time, tblRevenue.revenue_LastUpdate, tblRevenue.revenue_type, "
    '    strSQL += vbNewLine + " tblRevenue.theatersub_id, tblRevenue.user_id, tblRevenue.movie_system, tblRevenue.movies_id, "
    '    strSQL += vbNewLine + " tblRevenue.theater_id, tblRevenue.status_id, tblRevenue.sound_type, tblRevenue.timehour_id, "
    '    strSQL += vbNewLine + " tblRevenue.timemin_id, tblUser.user_name, tblRevStatus.status, tblRevStatus.statusColor, "
    '    strSQL += vbNewLine + "  (convert(decimal(15,2), tblRevenue.revenue_adms) / convert(decimal(15,2), mSeat.theatersub_normalseat))*100 AS opc, mSeat.theatersub_normalseat  "
    '    strSQL += vbNewLine + " FROM tblRevenue LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id "
    '    strSQL += vbNewLine + " LEFT JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.id LEFT JOIN "
    '    strSQL += vbNewLine + " (SELECT theatersub_normalseat,theater_id,theatersub_id FROM tblTheaterSub "
    '    strSQL += vbNewLine + " WHERE (theater_id = " + Session("theaterId").ToString() + ") AND (theatersub_id = " + Session("revScreen").ToString() + ")) mSeat "
    '    strSQL += vbNewLine + " ON tblRevenue.theater_id = mSeat.theater_id AND tblRevenue.theatersub_id = mSeat.theatersub_id "
    '    strSQL += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblRevenue.theater_id = " + Session("theaterId").ToString() + ") "
    '    strSQL += vbNewLine + " AND (tblRevenue.revenue_date = '" + Session("revDate").ToString() + "') AND (tblRevenue.theatersub_id = " + Session("revScreen").ToString() + ") "
    '    strSQL += vbNewLine + " ORDER BY tblRevenue.timehour_id, tblRevenue.timemin_id"

    '    sqlBoxOffice.SelectCommand = strSQL
    '    grdBoxOffice.DataSourceID = "sqlBoxOffice"
    '    grdBoxOffice.DataBind()
    'End Sub

End Class