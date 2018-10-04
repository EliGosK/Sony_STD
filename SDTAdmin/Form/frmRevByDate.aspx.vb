Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByDate
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 3, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Session("movieType") = "2" Then
                ''Response.Redirect("frmRevByTheaterComp.aspx?revDate=" & Request.QueryString("revDate"))
                Response.Redirect("frmRevByDateComp.aspx?revDate=" & Request.QueryString("revDate"))
            End If


            Dim revDate As String = ""
            If (Not ValidateQueryString(Request.QueryString("revDate"), GetType(String), revDate)) Then
                Response.Redirect("frmrevbyMovie.aspx")
            End If

            'Session("revDate") = Request.QueryString("revDate")
            'Session("revDate1") = Convert.ToString(Request.QueryString("revDate")).Substring(0, 4) + "/" + Convert.ToString(Request.QueryString("revDate")).Substring(4, 2) + "/" + Convert.ToString(Request.QueryString("revDate")).Substring(6, 2)
            Session("revDate") = revDate
            Session("revDate1") = revDate.Substring(0, 4) + "/" + revDate.Substring(4, 2) + "/" + revDate.Substring(6, 2)
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
                dataReader.Close()
            End If
        Catch ex As Exception

        End Try
       
    End Sub

    'Sub SQLgrd()
    '    Dim strSQL As String = ""
    '    strSQL = " SUM(isnull(tblRevenue.revenue_adms,0)) AS rev_adms, SUM(isnull(tblRevenue.revenue_amount,0)) AS rev_amount"
    '    strSQL += vbNewLine + " , tblRevenue.revenue_date, COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen"
    '    strSQL += vbNewLine + " , COUNT(tblRevenue.revenueid) AS mSession, MIN(tblRevStatus.status) AS Expr1"
    '    strSQL += vbNewLine + " , MAX(tblRevenue.revenue_LastUpdate) AS LastUpdate"
    '    strSQL += vbNewLine + " , tblRevenue.theater_id"
    '    strSQL += vbNewLine + " , tblRevenue.movies_id"
    '    strSQL += vbNewLine + " , tblTheater.circuit_id AS opc"
    '    strSQL += vbNewLine + " , ((sum(convert(decimal(20,2), isnull(tblRevenue.revenue_adms,0))) / "
    '    strSQL += vbNewLine + " (select sum(isnull(opc ,1) * isnull(mSession ,0))"
    '    strSQL += vbNewLine + " from"
    '    strSQL += vbNewLine + " ("
    '    strSQL += vbNewLine + " 	select a.rev_adms, a.mSession, a.movies_id, "
    '    strSQL += vbNewLine + " 	a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSQL += vbNewLine + " 	from"
    '    strSQL += vbNewLine + " 	("
    '    strSQL += vbNewLine + " 		SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSQL += vbNewLine + " 		, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSQL += vbNewLine + " 		, ts.theatersub_normalseat as opcX"
    '    strSQL += vbNewLine + " 		, case when isnull(ts.theatersub_normalseat,1) = 0 then 1 end as opc"
    '    strSQL += vbNewLine + " 		FROM tblRevenue  r"
    '    strSQL += vbNewLine + " 		LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSQL += vbNewLine + " 		LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSQL += vbNewLine + " 		AND r.theater_id = ts.theater_id "
    '    strSQL += vbNewLine + " 		WHERE (r.movies_id = tblRevenue.movies_id) "
    '    strSQL += vbNewLine + " 		AND (r.theater_id = tblRevenue.theater_id) "
    '    strSQL += vbNewLine + " 		AND (r.revenue_date = @revDate) "
    '    strSQL += vbNewLine + " 		GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSQL += vbNewLine + " 	) a"
    '    strSQL += vbNewLine + " )b"
    '    strSQL += vbNewLine + " group by b.movies_id)"
    '    strSQL += vbNewLine + " ) * 100) as opc_real"
    '    strSQL += vbNewLine + " ,isnull( (select sum( isnull(opc,1) * isnull(mSession,0))"
    '    strSQL += vbNewLine + " from"
    '    strSQL += vbNewLine + " ("
    '    strSQL += vbNewLine + " 	select a.rev_adms, a.mSession, a.movies_id, "
    '    strSQL += vbNewLine + " 	a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSQL += vbNewLine + " 	from"
    '    strSQL += vbNewLine + " 	("
    '    strSQL += vbNewLine + " 		SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSQL += vbNewLine + " 		, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSQL += vbNewLine + " 		, ts.theatersub_normalseat as opcX"
    '    strSQL += vbNewLine + " 		, case when isnull(ts.theatersub_normalseat,1) = 0 then 1 end as opc"
    '    strSQL += vbNewLine + " 		FROM tblRevenue  r"
    '    strSQL += vbNewLine + " 		LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSQL += vbNewLine + " 		LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSQL += vbNewLine + " 		AND r.theater_id = ts.theater_id "
    '    strSQL += vbNewLine + " 		WHERE (r.movies_id = tblRevenue.movies_id) "
    '    strSQL += vbNewLine + " 		AND (r.theater_id = tblRevenue.theater_id) "
    '    strSQL += vbNewLine + " 		AND (r.revenue_date = @revDate) "
    '    strSQL += vbNewLine + " 		GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSQL += vbNewLine + " 	) a"
    '    strSQL += vbNewLine + " )b"
    '    strSQL += vbNewLine + " group by b.movies_id),0) as seatAll"
    '    strSQL += vbNewLine + " FROM "
    '    strSQL += vbNewLine + " ("
    '    strSQL += vbNewLine + " 	SELECT revenueid, revenue_adms, revenue_amount, revenue_date, revenue_Time, revenue_LastUpdate"
    '    strSQL += vbNewLine + " 	, revenue_type, theatersub_id, user_id, movie_system, movies_id, theater_id, status_id, sound_type"
    '    strSQL += vbNewLine + " 	, timehour_id, timemin_id "
    '    strSQL += vbNewLine + " 	FROM tblRevenue AS tblRevenue_1 "
    '    strSQL += vbNewLine + " 	WHERE  (revenue_date= @revDate) AND (movies_id = @movieId)"
    '    strSQL += vbNewLine + " ) AS tblRevenue "
    '    strSQL += vbNewLine + " left join "
    '    strSQL += vbNewLine + " (SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id "
    '    strSQL += vbNewLine + " FROM tblRelease AS tblRelease_1"
    '    strSQL += vbNewLine + " WHERE (onrelease_status = '3') AND "
    '    strSQL += vbNewLine + " (movies_id = @movieId) "
    '    strSQL += vbNewLine + " AND (onrelease_enddate = @revDate OR onrelease_enddate IS NULL)"
    '    strSQL += vbNewLine + " ) AS tblRelease ON tblRelease.theater_id = tblRevenue.theater_id "
    '    strSQL += vbNewLine + " Left JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id "
    '    strSQL += vbNewLine + " LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id "
    '    strSQL += vbNewLine + " GROUP BY tblRevenue.revenue_date, tblRevenue.theater_id, tblRevenue.movies_id, tblTheater.theater_code"
    '    strSQL += vbNewLine + " , tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id "
    '    strSQL += vbNewLine + " ORDER BY Expr1, tblTheater.theater_name"
    'End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBoxOffice.DataBound
        
        ' grdBoxOffice.FooterRow.Cells(0).Text = "Number of Row :" & Session("sumRow") & "/" & Session("sumRowAll")
        Try
            grdBoxOffice.FooterRow.Cells(1).Text = "Total :"
            grdBoxOffice.FooterRow.Cells(2).Text = Format(Session("sumAmount"), "#,##0")
            grdBoxOffice.FooterRow.Cells(3).Text = Format(Session("sumADMS"), "#,##0")
            grdBoxOffice.FooterRow.Cells(4).Text = Format(Session("sumScreen"), "#,##0")
            grdBoxOffice.FooterRow.Cells(5).Text = Format(Session("sumSession"), "#,##0")
            grdBoxOffice.FooterRow.Cells(6).Text = Format(((Session("sumADMS") / Session("sumOpc")) * 100), "#,##0.00") 'Format(Session("sumOpc"), "#,##0.00")
        Catch ex As Exception

        End Try

        Session("sumAmount") = "0"
        Session("sumADMS") = "0"
        Session("sumScreen") = "0"
        Session("sumSession") = "0"
        Session("sumOpc") = "0"
        'Session("sumRow") = "0"
        'Session("sumRowAll") = "0"
    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged

    End Sub
    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        Try
            If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

                Dim dr As Data.DataRowView = e.Row.DataItem
                If Mid(Session("permission"), 4, 1) = "0" Then
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(1).Enabled = False

                End If
                If IsDBNull(dr(7)) = False Then

                    If dr(7) = "[-]เบื้องต้น" Then

                        ' e.Row.BackColor = Color.LightGoldenrodYellow
                        'e.Row.Font.Bold = False
                        e.Row.ForeColor = Color.Orange
                    ElseIf dr(7) = "[฿]ยอดจริง" Then

                        ' e.Row.BackColor = Color.DarkSeaGreen
                        'e.Row.Font.Bold = True
                        e.Row.ForeColor = Color.Green
                    Else
                        ' e.Row.BackColor = Color.LightSteelBlue
                        'e.Row.Font.Bold = True
                        e.Row.ForeColor = Color.DarkGray
                    End If

                    Try
                        Session("sumAmount") = Session("sumAmount") + dr(3)
                    Catch ex As Exception

                    End Try
                    Try
                        Session("sumADMS") = Session("sumADMS") + dr(2)
                    Catch ex As Exception

                    End Try
                    Try
                        Session("sumScreen") = Session("sumScreen") + dr(5)
                    Catch ex As Exception

                    End Try
                    Session("sumSession") = Session("sumSession") + dr(6)
                    Try
                        Session("sumOpc") = Session("sumOpc") + dr("seatAll")
                    Catch ex As Exception

                    End Try
                    'Session("sumRow") = Session("sumRow") + 1
                Else
                    e.Row.ForeColor = Color.Red
                    e.Row.Cells(0).Enabled = False
                    e.Row.Cells(1).Enabled = False
                    e.Row.Cells(7).Text = "Not Update!!"
                End If

                'ConvertTime By Pachara S. (C.S.I. Groups) on 20170525
                e.Row.Cells(8).Text = ConvertTimeToLocaltime(dr(8))

                e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell
                e.Row.Cells(8).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell

                'Session("sumRowAll") = Session("sumRowAll") + 1


                'Dim strSQLdrAll As String = "SELECT SUM(tblRevenue.revenue_adms) AS rev_adms, SUM(tblRevenue.revenue_amount) AS rev_amount, tblRevenue.revenue_date, tblRevenue.theatersub_id, tblRevenue.movies_id,"
                'strSQLdrAll += vbNewLine + " tblRevenue.theater_id, COUNT(tblRevenue.revenueid) AS mSession, tblTheaterSub.theatersub_code, tblTheater.theater_name + ' : ' + tblTheaterSub.theatersub_name AS TheaterSub_name,"
                'strSQLdrAll += vbNewLine + "  tblUser.user_name, MIN(tblRevStatus.status) AS minStatus, MAX(tblRevenue.revenue_LastUpdate) AS LastUpdate, tblTheaterSub.theatersub_normalseat as opc FROM tblRevenue"
                'strSQLdrAll += vbNewLine + " LEFT OUTER JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id LEFT OUTER JOIN tblUser "
                'strSQLdrAll += vbNewLine + " ON tblRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblTheaterSub ON tblRevenue.theatersub_id = tblTheaterSub.theatersub_id AND tblRevenue.theater_id = tblTheaterSub.theater_id "
                'strSQLdrAll += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblRevenue.theater_id = " + dr("theater_id").ToString() + ") AND (tblRevenue.revenue_date = '" + Session("revDate").ToString() + "') GROUP BY tblRevenue.movies_id, tblRevenue.revenue_date, tblRevenue.theater_id,"
                'strSQLdrAll += vbNewLine + "  tblRevenue.theatersub_id, tblTheaterSub.theatersub_code, tblTheaterSub.theatersub_name, tblUser.user_name, tblTheater.theater_name, tblTheaterSub.theatersub_normalseat"
                'Dim cDB As New cDatabase
                'Dim drAll As IDataReader
                'drAll = cDB.GetDataAll(strSQLdrAll)
                'Dim i As Integer = 1
                'While drAll.Read()

                '    Dim strSQL As String
                '    strSQL = "select count(*) as countRow from (SELECT tblRevenue.revenueid, tblRevenue.revenue_adms, tblRevenue.revenue_amount, tblRevenue.revenue_date, "
                '    strSQL += vbNewLine + " tblRevenue.revenue_Time, tblRevenue.revenue_LastUpdate, tblRevenue.revenue_type, "
                '    strSQL += vbNewLine + " tblRevenue.theatersub_id, tblRevenue.user_id, tblRevenue.movie_system, tblRevenue.movies_id, "
                '    strSQL += vbNewLine + " tblRevenue.theater_id, tblRevenue.status_id, tblRevenue.sound_type, tblRevenue.timehour_id, "
                '    strSQL += vbNewLine + " tblRevenue.timemin_id, tblUser.user_name, tblRevStatus.status, tblRevStatus.statusColor, "
                '    strSQL += vbNewLine + "  (convert(decimal(15,2), tblRevenue.revenue_adms) / convert(decimal(15,2), mSeat.theatersub_normalseat))*100 AS opc, mSeat.theatersub_normalseat  "
                '    strSQL += vbNewLine + " FROM tblRevenue LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id "
                '    strSQL += vbNewLine + " LEFT JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.id LEFT JOIN "
                '    strSQL += vbNewLine + " (SELECT theatersub_normalseat,theater_id,theatersub_id FROM tblTheaterSub "
                '    strSQL += vbNewLine + " WHERE (theater_id = " + drAll("theater_id").ToString() + ") AND (theatersub_id = " + drAll("theatersub_id").ToString() + ")) mSeat "
                '    strSQL += vbNewLine + " ON tblRevenue.theater_id = mSeat.theater_id AND tblRevenue.theatersub_id = mSeat.theatersub_id "
                '    strSQL += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("movieId").ToString() + ") AND (tblRevenue.theater_id = " + drAll("theater_id").ToString() + ") "
                '    strSQL += vbNewLine + " AND (tblRevenue.revenue_date = '" + Session("revDate").ToString() + "') AND (tblRevenue.theatersub_id = " + drAll("theatersub_id").ToString() + ") "
                '    strSQL += vbNewLine + " ) tblNew"


                '    Dim drGetCount As IDataReader
                '    drGetCount = cDB.GetDataAll(strSQL)
                '    Dim intContRow As Integer = 0
                '    If (drGetCount.Read()) Then
                '        intContRow = cDB.CheckIsNullInteger(drGetCount("countRow"))
                '    End If
                '    drGetCount.Close()
                '    Dim decSeat As Double = cDB.CheckIsNullInteger(drAll(12)) * intContRow
                '    If i = 1 Then
                '        ViewState("SubSeat") = 0
                '    End If
                '    ViewState("SubSeat") = ViewState("SubSeat") + decSeat

                '    i = i + 1

                'End While
                'drAll.Close()



                'If cDB.CheckIsNullInteger(dr(2)) = 0 Or cDB.CheckIsNullInteger(ViewState("SubSeat")) = 0 Then
                '    e.Row.Cells(6).Text = "0.00"
                'Else
                '    e.Row.Cells(6).Text = Format((cDB.CheckIsNullInteger(dr(2)) / ViewState("SubSeat")) * 100, "#,##0.00")
                'End If


            End If
        Catch ex As Exception

        End Try
       
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        If grdBoxOffice.Rows.Count.ToString + 1 < 65536 Then
            grdBoxOffice.AllowPaging = False
            grdBoxOffice.AllowSorting = False
            'grdBoxOffice.Width = 800
            grdBoxOffice.DataBind()
            Dim tw As New IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            Dim tbl As New Table()
            Dim tr1 As New TableRow()
            'tr1.Cells.Add(New TableCell)
            'tr1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            'tr1.Cells(0).ForeColor = Color.White
            'tr1.Cells(0).Font.Name = "Tahoma"
            'tr1.Cells(0).Font.Size = 2
            'tr1.Cells(0).Font.Bold = False
            'tr1.Cells(0).ColumnSpan = 8
            'tr1.Cells(0).Text = "กขค"
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