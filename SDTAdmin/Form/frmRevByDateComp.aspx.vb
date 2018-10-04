Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByDateComp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 3, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        'If Not IsPostBack Then
        '    ViewState("SubSeat") = 0
        'End If
        Session("revDate") = Request.QueryString("revDate")
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")

        Dim getMovieDetail As New cDatabase
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(Session("movieId"))
        If dataReader.Read = True Then
            txtTitle.Text = dataReader("movie_nameen") & "/" & dataReader("movie_nameth")
            lblMovieId.Text = dataReader("movie_nameen")
            txtDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReader("movie_gern") & "/" & dataReader("movie_gernsub")
            txtDis.Text = dataReader("distributor_name")
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
            grdBoxOffice.FooterRow.Cells(4).Text = Format(Session("sumScreen"), "#,##0")
            grdBoxOffice.FooterRow.Cells(5).Text = Format(Session("sumSession"), "#,##0")

            Session("sumAmount") = "0"
            Session("sumADMS") = "0"
            Session("sumScreen") = "0"
            Session("sumSession") = "0"
        End If

    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged

    End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
            Dim dr As Data.DataRowView = e.Row.DataItem
            If Mid(Session("permission"), 6, 1) = "0" Then
                e.Row.Cells(0).Enabled = False
                e.Row.Cells(1).Enabled = False
            End If
            If IsDBNull(dr("status")) = False Then

                If dr("status") = "[-]เบื้องต้น" Then

                    ' e.Row.BackColor = Color.LightGoldenrodYellow
                    'e.Row.Font.Bold = False
                    e.Row.ForeColor = Color.Orange
                ElseIf dr("status") = "[฿]ยอดจริง" Then

                    ' e.Row.BackColor = Color.DarkSeaGreen
                    'e.Row.Font.Bold = True
                    e.Row.ForeColor = Color.Green
                Else
                    ' e.Row.BackColor = Color.LightSteelBlue
                    'e.Row.Font.Bold = True
                    e.Row.ForeColor = Color.DarkGray
                End If

                If dr("count_revenue_id") <= 0 Then
                    CType(e.Row.FindControl("lnkTheaterName"), HyperLink).NavigateUrl = String.Format("SendRevenue.aspx?MovieTypeId=2&RevenueCompHeaderId={0}", dr("revenue_comp_header_id"))
                Else
                    CType(e.Row.FindControl("lnkTheaterName"), HyperLink).NavigateUrl = String.Format("frmRevByTheaterComp.aspx?theaterId={0}", dr("theater_id"))
                End If

                Session("sumAmount") = Session("sumAmount") + dr("comprevenue_amountsum")
                Session("sumADMS") = Session("sumADMS") + dr("comprevenue_admssum")
                Session("sumScreen") = Session("sumScreen") + dr("comprevenue_screensum")
                Session("sumSession") = Session("sumSession") + dr("comprevenue_timesum")


                ''OPC
                'Dim strSQLdrAll As String = ""
                ''strSQLdrAll = "SELECT SUM(tblRevenue.revenue_adms) AS rev_adms, SUM(tblRevenue.revenue_amount) AS rev_amount, tblRevenue.revenue_date, tblRevenue.theatersub_id, tblRevenue.movies_id,"
                ''strSQLdrAll += vbNewLine + " tblRevenue.theater_id, COUNT(tblRevenue.revenueid) AS mSession, tblTheaterSub.theatersub_code, tblTheater.theater_name + ' : ' + tblTheaterSub.theatersub_name AS TheaterSub_name,"
                ''strSQLdrAll += vbNewLine + "  tblUser.user_name, MIN(tblRevStatus.status) AS minStatus, MAX(tblRevenue.revenue_LastUpdate) AS LastUpdate, tblTheaterSub.theatersub_normalseat as opc FROM tblRevenue"
                ''strSQLdrAll += vbNewLine + " LEFT OUTER JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id LEFT OUTER JOIN tblUser "
                ''strSQLdrAll += vbNewLine + " ON tblRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblTheaterSub ON tblRevenue.theatersub_id = tblTheaterSub.theatersub_id AND tblRevenue.theater_id = tblTheaterSub.theater_id "
                ''strSQLdrAll += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblRevenue.theater_id = " + dr("theater_id").ToString() + ") AND (tblRevenue.revenue_date = '" + Session("revDate").ToString() + "') GROUP BY tblRevenue.movies_id, tblRevenue.revenue_date, tblRevenue.theater_id,"
                ''strSQLdrAll += vbNewLine + "  tblRevenue.theatersub_id, tblTheaterSub.theatersub_code, tblTheaterSub.theatersub_name, tblUser.user_name, tblTheater.theater_name, tblTheaterSub.theatersub_normalseat"


                'strSQLdrAll = "SELECT tblCompRevenue.comprevenue_amountsum, tblCompRevenue.comprevenue_admssum, "
                'strSQLdrAll += vbNewLine + " tblCompRevenue.comprevenue_timesum, tblCompRevenue.comprevenue_screensum,"
                'strSQLdrAll += vbNewLine + " tblRevStatus.statusColor, tblRevStatus.status, tblCompRevenue.comprevenue_lastupdate,"
                'strSQLdrAll += vbNewLine + "  tblRelease.theater_id, tblUser.user_name, tblTheater.theater_name, tblTheater.theater_code"
                'strSQLdrAll += vbNewLine + " ,tblTheaterSub.theatersub_id, tblTheaterSub.theatersub_normalseat"
                'strSQLdrAll += vbNewLine + "  FROM (SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id"
                'strSQLdrAll += vbNewLine + "  FROM tblRelease AS tblRelease_1 WHERE (onrelease_status <> '3') AND (movies_id = " + Session("movieId").ToString() + " )"
                'strSQLdrAll += vbNewLine + "  AND (theater_id = " + dr("theater_id").ToString() + ")"
                'strSQLdrAll += vbNewLine + "  AND (onrelease_enddate >= '" + Session("revDate").ToString() + "' OR onrelease_enddate IS NULL)) AS tblRelease"
                'strSQLdrAll += vbNewLine + " LEFT OUTER JOIN dbo.tblTheaterSub ON tblRelease.theater_id = dbo.tblTheaterSub.theater_id LEFT OUTER JOIN (SELECT comprevenue_id, comprevenue_amountsum, comprevenue_amountth,"
                'strSQLdrAll += vbNewLine + "  comprevenue_amountor, comprevenue_admssum, comprevenue_admsth, comprevenue_admsor, "
                'strSQLdrAll += vbNewLine + " comprevenue_timesum, comprevenue_timeor, comprevenue_timeth, comprevenue_screensum, comprevenue_screenth,"
                'strSQLdrAll += vbNewLine + "  comprevenue_screenor, comprevenue_date, comprevenue_lastupdate, theater_id, movies_id, status_id, user_id "
                'strSQLdrAll += vbNewLine + " FROM tblCompRevenue AS tblCompRevenue_1 WHERE (comprevenue_date = '" + Session("revDate").ToString() + "')) AS tblCompRevenue "
                'strSQLdrAll += vbNewLine + " ON tblRelease.theater_id = tblCompRevenue.theater_id AND tblRelease.movies_id = tblCompRevenue.movies_id "
                'strSQLdrAll += vbNewLine + " LEFT OUTER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id "
                'strSQLdrAll += vbNewLine + " LEFT OUTER JOIN tblUser "
                'strSQLdrAll += vbNewLine + " ON tblCompRevenue.user_id = tblUser.user_id "
                'strSQLdrAll += vbNewLine + " LEFT OUTER JOIN tblRevStatus ON tblCompRevenue.status_id = tblRevStatus.status_id "
                'strSQLdrAll += vbNewLine + " ORDER BY tblRevStatus.status, tblTheater.theater_name"


                'Dim cDB As New cDatabase
                'Dim drAll As IDataReader
                'drAll = cDB.GetDataAll(strSQLdrAll)
                'Dim i As Integer = 1
                'While drAll.Read()

                '    Dim strSQL As String
                '    strSQL = "select count(*) as countRow from (SELECT tblcompRevenue.comprevenue_id, tblcompRevenue.comprevenue_admssum, tblcompRevenue.comprevenue_amountsum, tblcompRevenue.compRevenue_date, "
                '    strSQL += vbNewLine + " tblcompRevenue.comprevenue_timesum, tblcompRevenue.compRevenue_LastUpdate, " 'tblcompRevenue.compRevenue_type, "
                '    strSQL += vbNewLine + " tblcompRevenue.user_id, tblcompRevenue.movies_id, "
                '    strSQL += vbNewLine + " tblcompRevenue.theater_id, tblcompRevenue.status_id, "
                '    strSQL += vbNewLine + " tblUser.user_name, tblRevStatus.status, tblRevStatus.statusColor, "
                '    strSQL += vbNewLine + "  (convert(decimal(15,2), tblcompRevenue.comprevenue_admssum) / convert(decimal(15,2), mSeat.theatersub_normalseat))*100 AS opc, mSeat.theatersub_normalseat  "
                '    strSQL += vbNewLine + " FROM tblcompRevenue LEFT OUTER JOIN tblUser ON tblcompRevenue.user_id = tblUser.user_id "
                '    strSQL += vbNewLine + " LEFT JOIN tblRevStatus ON tblcompRevenue.status_id = tblRevStatus.id LEFT JOIN "
                '    strSQL += vbNewLine + " (SELECT theatersub_normalseat,theater_id,theatersub_id FROM tblTheaterSub "
                '    strSQL += vbNewLine + " WHERE (theater_id = " + drAll("theater_id").ToString() + ") ) mSeat " 'AND (theatersub_id = " + drAll("theatersub_id").ToString() + ")
                '    strSQL += vbNewLine + " ON tblcompRevenue.theater_id = mSeat.theater_id " 'AND tblcompRevenue.theatersub_id = mSeat.theatersub_id "
                '    strSQL += vbNewLine + " WHERE (tblcompRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblcompRevenue.theater_id = " + drAll("theater_id").ToString() + ") "
                '    strSQL += vbNewLine + " AND (tblcompRevenue.compRevenue_date = '" + Session("revDate").ToString() + "') " 'AND (tblcompRevenue.theatersub_id = " + drAll("theatersub_id").ToString() + ") "
                '    strSQL += vbNewLine + " ) tblNew"


                '    Dim drGetCount As IDataReader
                '    drGetCount = cDB.GetDataAll(strSQL)
                '    Dim intContRow As Integer = 0
                '    If (drGetCount.Read()) Then
                '        intContRow = cDB.CheckIsNullInteger(drGetCount("countRow"))
                '    End If
                '    drGetCount.Close()
                '    Dim decSeat As Decimal = 0
                '    If intContRow <> 0 And cDB.CheckIsNullInteger(drAll(12)) <> 0 Then
                '        decSeat = (cDB.CheckIsNullInteger(drAll(1)) / ((cDB.CheckIsNullInteger(drAll(12)) * intContRow))) * 100
                '    End If

                '    If i = 1 Then
                '        ViewState("SubSeat") = 0
                '    End If
                '    ViewState("SubSeat") = ViewState("SubSeat") + Format(decSeat, "#,##0.00")

                '    i = i + 1

                'End While
                'drAll.Close()

                ''เปิดตรงนี้ถ้าจะโชว์OPC  e.Row.Cells(6).Text = Format(ViewState("SubSeat"), "#,##0.00")

            Else
                e.Row.ForeColor = Color.Red
                e.Row.Cells(0).Enabled = False
                e.Row.Cells(1).Enabled = False
                e.Row.Cells(6).Text = "Not Update!!"
            End If
        End If
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        If grdBoxOffice.Rows.Count.ToString + 1 < 65536 Then
            grdBoxOffice.AllowPaging = False
            grdBoxOffice.AllowSorting = False
            grdBoxOffice.DataBind()
            Dim tw As New IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            Dim tbl As New Table()
            Dim tr1 As New TableRow()
            tr1.Cells.Add(New TableCell)
            tr1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            tr1.Cells(0).ForeColor = Color.Black
            tr1.Cells(0).Font.Name = "Tahoma"
            tr1.Cells(0).Font.Size = 10
            tr1.Cells(0).Font.Bold = True
            tr1.Cells(0).ColumnSpan = 8
            tr1.Cells(0).Text = "กขค"
            tr1.Cells(0).Text = txtTitle.Text.Trim() + " : " + lblDate.Text.Trim()
            tbl.Rows.Add(tr1)
            frm.Attributes("runat") = "server"
            frm.Controls.Add(tbl)
            frm.Controls.Add(grdBoxOffice)
            Response.Charset = "windows-874"
            Response.AddHeader("content-disposition", "attachment;filename=BoxOffice_by_Theatre.xls")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)

            Response.ContentType = "application/vnd.xls"

            EnableViewState = False
            Controls.Add(frm)

            frm.RenderControl(hw)
            'Response.Write(tw.ToString())
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
            Response.End()
            grdBoxOffice.AllowPaging = True
            grdBoxOffice.AllowSorting = True
            grdBoxOffice.DataBind()

        End If
    End Sub

End Class