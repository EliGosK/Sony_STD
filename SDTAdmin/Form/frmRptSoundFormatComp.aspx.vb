Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptSoundFormatComp
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If

    '    Dim wkMvID, Sd, Ed As String
    '    wkMvID = Session("msRptMovieID")
    '    Sd = Format(Session("msRptStrDate"), "yyyyMMdd")
    '    Ed = Format(Session("msRptEndDate"), "yyyyMMdd")

    '    Dim strTheatreId As String = Request.QueryString("theaterid")
    '    Dim strTypeId As String = Request.QueryString("typeid")
    '    Dim wkSQL As String = ""

    ' If strTypeId = "dim" Then
    '        tbl.Rows(0).Cells(0).Text = Session("msRptMovieName")
    '        tbl.Rows(2).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
    '        tbl.Rows(1).Cells(0).Text = " Digital 3D"

    '        wkSQL = " SELECT tblMovie.movie_id,"
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0))as diffDate, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_admstd), 0) AS rev_adms, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_amounttd), 0) AS rev_amount, "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) AS revDate "
    '        wkSQL += vbNewLine + " ,tblCompRevenue.theater_id"
    '        wkSQL += vbNewLine + " FROM tblCompRevenue left JOIN"
    '        wkSQL += vbNewLine + " tblMovie ON tblMovie.movie_id = tblCompRevenue.movies_id"
    '        wkSQL += vbNewLine + " WHERE  (tblMovie.movie_id = " + wkMvID + ") and (tblCompRevenue.theater_id = " + strTheatreId + ")"
    '        wkSQL += vbNewLine + " and ((tblCompRevenue.comprevenue_date >= '" + Sd + "'"
    '        wkSQL += vbNewLine + " and tblCompRevenue.comprevenue_date <= '" + Ed + "'))" 
    '        wkSQL += vbNewLine + " GROUP BY tblCompRevenue.theater_id, tblMovie.movie_id, "
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0)), "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) "
    '        wkSQL += vbNewLine + " order by revDate"

    '    ElseIf strTypeId = "soundtrack" Then
    '        tbl.Rows(0).Cells(0).Text = Session("msRptMovieName")
    '        tbl.Rows(2).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
    '        tbl.Rows(1).Cells(0).Text = " Soundtrack"

    '        wkSQL = " SELECT tblMovie.movie_id,"
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0))as diffDate, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_admsor), 0) AS rev_adms, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_amountor), 0) AS rev_amount, "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) AS revDate, " 
    '        wkSQL += vbNewLine + " tblCompRevenue.theater_id"
    '        wkSQL += vbNewLine + " FROM tblCompRevenue left JOIN"
    '        wkSQL += vbNewLine + " tblMovie ON tblMovie.movie_id = tblCompRevenue.movies_id"
    '        wkSQL += vbNewLine + " WHERE  (tblMovie.movie_id = " + wkMvID + ") and (tblCompRevenue.theater_id = " + strTheatreId + ")"
    '        wkSQL += vbNewLine + " and ((tblCompRevenue.comprevenue_date >= '" + Sd + "'"
    '        wkSQL += vbNewLine + " and tblCompRevenue.comprevenue_date <= '" + Ed + "'))" 
    '        wkSQL += vbNewLine + " GROUP BY tblCompRevenue.theater_id, tblMovie.movie_id, "
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0)), "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) "
    '        wkSQL += vbNewLine + " order by revDate"

    '    ElseIf strTypeId = "thaidub" Then
    '        tbl.Rows(0).Cells(0).Text = Session("msRptMovieName")
    '        tbl.Rows(2).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
    '        tbl.Rows(1).Cells(0).Text = " Thai Dub"

    '        wkSQL = " SELECT tblMovie.movie_id,"
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0))as diffDate, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_admsth), 0) AS rev_adms, "
    '        wkSQL += vbNewLine + " ISNULL(SUM(tblCompRevenue.comprevenue_amountth), 0) AS rev_amount, "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) AS revDate, "
    '        wkSQL += vbNewLine + " tblCompRevenue.theater_id"
    '        wkSQL += vbNewLine + " FROM tblCompRevenue left JOIN"
    '        wkSQL += vbNewLine + " tblMovie ON tblMovie.movie_id = tblCompRevenue.movies_id"
    '        wkSQL += vbNewLine + " WHERE  (tblMovie.movie_id = " + wkMvID + ") and (tblCompRevenue.theater_id = " + strTheatreId + ")"
    '        wkSQL += vbNewLine + " and ((tblCompRevenue.comprevenue_date >= '" + Sd + "'"
    '        wkSQL += vbNewLine + " and tblCompRevenue.comprevenue_date <= '" + Ed + "'))" 
    '        wkSQL += vbNewLine + " GROUP BY tblCompRevenue.theater_id, tblMovie.movie_id, "
    '        wkSQL += vbNewLine + " datediff(day,tblMovie.movie_strdate, ISNULL(tblCompRevenue.comprevenue_date, 0)), "
    '        wkSQL += vbNewLine + " ISNULL(tblCompRevenue.comprevenue_date, 0) "
    '        wkSQL += vbNewLine + " order by revDate"
    '    End If

    '    sqlSoundFormat.SelectCommand = wkSQL
    '    grdBoxOffice.DataSourceID = "sqlSoundFormat"
    '    grdBoxOffice.DataBind()

    '    Dim drSum As IDataReader = cDB.GetDataAll(wkSQL)
    '    Dim dmBoxoffice As Double = 0
    '    Dim dmAdms As Double = 0
    '    While (drSum.Read())
    '        dmBoxoffice = dmBoxoffice + drSum("rev_amount")
    '        dmAdms = dmAdms + drSum("rev_adms")
    '    End While
    '    drSum.Close()
    '    tblSum.Rows(0).Cells(0).Text = "Total"
    '    tblSum.Rows(0).Cells(1).Text = Format(dmBoxoffice, "#,##0")
    '    tblSum.Rows(0).Cells(2).Text = Format(dmAdms, "#,##0")

    '    Dim wkSQLTheater As String = "select theater_name from tblTheater where theater_id = " + strTheatreId
    '    Dim dr As IDataReader = cDB.GetDataAll(wkSQLTheater)
    '    If dr.Read() Then
    '        tbl.Rows(1).Cells(0).Text = "Box Office By " + dr("theater_name") + " & " + tbl.Rows(1).Cells(0).Text
    '    End If
    '    dr.Close()
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        If Not IsPostBack Then
            Me.btnCancel0.Attributes.Add("onclick", "javascript:history.back(); return false;")

            Dim movieId As String = Session("msRptMovieID")
            Dim startDate As String = Format(Session("msRptStrDate"), "yyyyMMdd")
            Dim endDate As String = Format(Session("msRptEndDate"), "yyyyMMdd")
            Dim strTheatreId As String = Request.QueryString("theaterid")
            Dim strTheatreName As String = Request.QueryString("theatername")
            Dim strHeaderGroup As String = Request.QueryString("headergroup")
            Dim strTypeId As String = Request.QueryString("typeid")

            Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptSoundFormatComp " _
                                                                + movieId _
                                                                + ", " + strTheatreId _
                                                                + ", '" + startDate + "'" _
                                                                + ", '" + endDate + "'" _
                                                                + ", '" + strHeaderGroup + "'" _
                                                                + ", '" + strTypeId + "'")

            Me.tableReport.Rows(0).Cells(0).Text = String.Format(Me.tableReport.Rows(0).Cells(0).Text, Session("msRptMovieName"))
            Me.tableReport.Rows(2).Cells(0).Text = String.Format(Me.tableReport.Rows(2).Cells(0).Text, Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy"), Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy"))
            Me.tableReport.Rows(1).Cells(0).Text = String.Format(Me.tableReport.Rows(1).Cells(0).Text, strTheatreName, strHeaderGroup)

            '--- print detail
            For i As Integer = 0 To dtDetail.Rows.Count - 1
                Dim trDetail As New TableRow()

                trDetail.HorizontalAlign = HorizontalAlign.Center

                trDetail.Cells.Add(New TableCell)
                trDetail.Cells(0).HorizontalAlign = HorizontalAlign.Center
                trDetail.Cells(0).Text = String.Format("{0:dd-MMM-yyyy}", dtDetail.Rows(i)("revenue_date"))

                trDetail.Cells.Add(New TableCell)
                trDetail.Cells(1).HorizontalAlign = HorizontalAlign.Right
                trDetail.Cells(1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("revenue_amount"))

                trDetail.Cells.Add(New TableCell)
                trDetail.Cells(2).HorizontalAlign = HorizontalAlign.Right
                trDetail.Cells(2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("revenue_adms"))

                trDetail.Cells.Add(New TableCell)
                trDetail.Cells(3).HorizontalAlign = HorizontalAlign.Right
                trDetail.Cells(3).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("revenue_screen"))

                Me.tableReport.Rows.AddAt(tableReport.Rows.Count - 1, trDetail)
            Next

            '--- print footer
            If dtDetail.Rows.Count > 0 Then
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([revenue_amount])", ""))
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([revenue_adms])", ""))
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(3).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([revenue_screen])", ""))
            Else
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(1).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(2).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(Me.tableReport.Rows.Count - 1).Cells(3).Text = String.Format("{0:#,##0}", 0)
            End If
        End If
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        'Response.Redirect("frmRptMarketSareByPeriodParam.aspx")
    End Sub

    'Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
    '    If grdBoxOffice.Rows.Count.ToString + 1 < 65536 Then
    '        grdBoxOffice.AllowPaging = False
    '        grdBoxOffice.AllowSorting = False
    '        grdBoxOffice.Width = 800
    '        grdBoxOffice.DataBind()
    '        Dim tw As New IO.StringWriter()
    '        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
    '        Dim frm As HtmlForm = New HtmlForm()
    '        frm.Attributes("runat") = "server"
    '        frm.Controls.Add(panel1)
    '        frm.Controls.Add(tbl)
    '        frm.Controls.Add(grdBoxOffice)
    '        frm.Controls.Add(tblSum)
    '        Response.AddHeader("content-disposition", "attachment;filename=Market_Share_By_Nationality.xls")
    '        Response.Cache.SetCacheability(HttpCacheability.NoCache)

    '        Response.ContentType = "application/vnd.xls"
    '        Response.Charset = ""
    '        EnableViewState = False
    '        Controls.Add(frm)

    '        frm.RenderControl(hw)
    '        'Response.Write(tw.ToString())
    '        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
    '        Response.End()
    '        grdBoxOffice.AllowPaging = True
    '        grdBoxOffice.AllowSorting = True
    '        grdBoxOffice.DataBind()
    '    End If
    'End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=DateAndSound.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        Me.tableReport.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

End Class