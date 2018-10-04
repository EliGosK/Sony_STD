Imports Web.Data

Partial Public Class frmRptCompSoundFormat_st
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    '--- Commented by Wittawat W. (CSI) on 2012/12/03 : Add filmtype and sound
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If
    '    Dim wkMvID, Sd, Ed As String
    '    wkMvID = Session("msRptMovieID")
    '    Sd = Format(Session("msRptStrDate"), "yyyyMMdd")
    '    Ed = Format(Session("msRptEndDate"), "yyyyMMdd")
    '    'Dim IDataReader1 As IDataReader = cDB.GetRptSoundFormat(wkMvID, Sd, Ed, "Theatre_Sound")

    '    'Dim strSQL As String = ""

    '    'strSQL = " 	SELECT tblRelease.movies_id, tblRelease.theater_id, tblTheater.theater_code, tblTheater.theater_name,"
    '    'strSQL += vbNewLine + " isnull(sum(tblRevenue.revenue_amount), 0) as gbo_amount, "
    '    'strSQL += vbNewLine + " isnull(sum(tblRevenue.revenue_adms), 0) as gbo_adms, "
    '    'strSQL += vbNewLine + " isnull(max(sub_soundtrack_amt.soundtrack_amt), 0) as soundtrack_amt, "
    '    'strSQL += vbNewLine + " isnull(max(sub_soundtrack_adms.soundtrack_adms), 0) as soundtrack_adms,"
    '    'strSQL += vbNewLine + " isnull(max(sub_thai_dub_amt.thai_dub_amt), 0) as thai_dub_amt,"
    '    'strSQL += vbNewLine + " isnull(max(sub_thai_dub_adms.thai_dub_adms), 0) as thai_dub_adms,"
    '    'strSQL += vbNewLine + " COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen, "
    '    'strSQL += vbNewLine + " COUNT(tblRevenue.revenueid) AS mSession, "
    '    'strSQL += vbNewLine + " MIN(tblRevStatus.status) AS Expr1"
    '    'strSQL += vbNewLine + " FROM            "
    '    'strSQL += vbNewLine + " ("
    '    'strSQL += vbNewLine + " SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id"
    '    'strSQL += vbNewLine + " FROM tblRelease AS tblRelease_1"
    '    'strSQL += vbNewLine + " WHERE (onrelease_status <> '3') "
    '    'strSQL += vbNewLine + " AND (movies_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and (onrelease_startdate >= convert(datetime, '" + Sd + "',101) "
    '    'strSQL += vbNewLine + "  and onrelease_enddate <= convert(datetime,'" + Ed + "',101) or onrelease_enddate is null)"
    '    'strSQL += vbNewLine + " ) AS tblRelease"
    '    'strSQL += vbNewLine + " INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id "

    '    'strSQL += vbNewLine + " ----------------------------------------------"
    '    'strSQL += vbNewLine + " LEFT OUTER JOIN"
    '    'strSQL += vbNewLine + " ("
    '    'strSQL += vbNewLine + "  SELECT (isnull(r.revenue_adms, 0) + isnull(cr.comprevenue_admssum, 0))as revenue_adms, "
    '    'strSQL += vbNewLine + "  (isnull(r.revenue_amount, 0) + isnull(cr.comprevenue_amountsum, 0)) as revenue_amount,"
    '    'strSQL += vbNewLine + "  (isnull(r.revenue_date, 0) + isnull(cr.comprevenue_date, 0)) as revenue_date"
    '    'strSQL += vbNewLine + "  ,m.movie_id, isnull(r.theater_id,0)+isnull(cr.theater_id,0) as theater_id"
    '    'strSQL += vbNewLine + " , r.status_id, theatersub_id,r.revenueid"
    '    'strSQL += vbNewLine + "  from tblMovie m"
    '    'strSQL += vbNewLine + "  left join tblRevenue r on m.movie_id = r.movies_id"
    '    'strSQL += vbNewLine + "  left join tblCompRevenue cr on m.movie_id = cr.movies_id"
    '    'strSQL += vbNewLine + "  WHERE (m.movie_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and ((r.revenue_date >= convert(datetime, '" + Sd + "',101) and r.revenue_date <= convert(datetime,'" + Ed + "',101))"
    '    'strSQL += vbNewLine + "  or (cr.comprevenue_date >= convert(datetime, '" + Sd + "',101) and cr.comprevenue_date <= convert(datetime,'" + Ed + "',101)))"
    '    'strSQL += vbNewLine + "  ) AS tblRevenue ON tblRelease.theater_id = tblRevenue.theater_id"
    '    'strSQL += vbNewLine + " ----------------------------------------------"
    '    'strSQL += vbNewLine + " LEFT JOIN"
    '    'strSQL += vbNewLine + " (SELECT isnull(r.theater_id,0)+isnull(cr.theater_id,0) as theater_id, m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + " , (sum(ISNULL(r.revenue_amount, 0))+sum(ISNULL(cr.comprevenue_amountsum, 0))) as soundtrack_amt"
    '    'strSQL += vbNewLine + " from tblMovie m"
    '    'strSQL += vbNewLine + " left join tblRevenue r on m.movie_id = r.movies_id"
    '    'strSQL += vbNewLine + " left join tblCompRevenue cr on m.movie_id = cr.movies_id"
    '    'strSQL += vbNewLine + "  WHERE (m.movie_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and ((r.revenue_date >= convert(datetime, '" + Sd + "',101) and r.revenue_date <= convert(datetime,'" + Ed + "',101))"
    '    'strSQL += vbNewLine + "  or (cr.comprevenue_date >= convert(datetime, '" + Sd + "',101) and cr.comprevenue_date <= convert(datetime,'" + Ed + "',101)))"
    '    'strSQL += vbNewLine + "  and (r.sound_type = 'ต้นฉบับ'  or cr.comprevenue_screenor is not null)"
    '    'strSQL += vbNewLine + "  group by isnull(r.theater_id,0)+isnull(cr.theater_id,0), m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + "  ) AS sub_soundtrack_amt ON tblRelease.theater_id = sub_soundtrack_amt.theater_id"
    '    'strSQL += vbNewLine + " and tblRelease.movies_id = sub_soundtrack_amt.movie_id"
    '    'strSQL += vbNewLine + " LEFT JOIN"
    '    'strSQL += vbNewLine + " (SELECT isnull(r.theater_id,0)+isnull(cr.theater_id,0) as theater_id, m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + " , (sum(ISNULL(r.revenue_adms, 0))+sum(ISNULL(cr.comprevenue_admssum, 0))) as soundtrack_adms"
    '    'strSQL += vbNewLine + " from tblMovie m"
    '    'strSQL += vbNewLine + " left join tblRevenue r on m.movie_id = r.movies_id"
    '    'strSQL += vbNewLine + " left join tblCompRevenue cr on m.movie_id = cr.movies_id"
    '    'strSQL += vbNewLine + "  WHERE (m.movie_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and ((r.revenue_date >= convert(datetime, '" + Sd + "',101) and r.revenue_date <= convert(datetime,'" + Ed + "',101))"
    '    'strSQL += vbNewLine + "  or (cr.comprevenue_date >= convert(datetime, '" + Sd + "',101) and cr.comprevenue_date <= convert(datetime,'" + Ed + "',101)))"
    '    'strSQL += vbNewLine + "  and (r.sound_type = 'ต้นฉบับ'  or cr.comprevenue_screenor is not null)"
    '    'strSQL += vbNewLine + "  group by isnull(r.theater_id,0)+isnull(cr.theater_id,0), m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + "  ) AS sub_soundtrack_adms ON tblRelease.theater_id = sub_soundtrack_amt.theater_id"
    '    'strSQL += vbNewLine + " and tblRelease.movies_id = sub_soundtrack_amt.movie_id"
    '    'strSQL += vbNewLine + " LEFT JOIN"
    '    'strSQL += vbNewLine + " (SELECT isnull(r.theater_id,0)+isnull(cr.theater_id,0) as theater_id, m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + " , (sum(ISNULL(r.revenue_amount, 0))+sum(ISNULL(cr.comprevenue_amountsum, 0))) as thai_dub_amt"
    '    'strSQL += vbNewLine + " from tblMovie m"
    '    'strSQL += vbNewLine + " left join tblRevenue r on m.movie_id = r.movies_id"
    '    'strSQL += vbNewLine + " left join tblCompRevenue cr on m.movie_id = cr.movies_id"
    '    'strSQL += vbNewLine + "  WHERE (m.movie_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and ((r.revenue_date >= convert(datetime, '" + Sd + "',101) and r.revenue_date <= convert(datetime,'" + Ed + "',101))"
    '    'strSQL += vbNewLine + "  or (cr.comprevenue_date >= convert(datetime, '" + Sd + "',101) and cr.comprevenue_date <= convert(datetime,'" + Ed + "',101)))"
    '    'strSQL += vbNewLine + "  and (r.sound_type = 'พากย์ไทย'  or cr.comprevenue_screenor is not null)"
    '    'strSQL += vbNewLine + "  group by isnull(r.theater_id,0)+isnull(cr.theater_id,0), m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + "  ) AS sub_thai_dub_amt ON tblRelease.theater_id = sub_soundtrack_amt.theater_id"
    '    'strSQL += vbNewLine + " and tblRelease.movies_id = sub_soundtrack_amt.movie_id"
    '    'strSQL += vbNewLine + " LEFT JOIN"
    '    'strSQL += vbNewLine + " (SELECT isnull(r.theater_id,0)+isnull(cr.theater_id,0) as theater_id, m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + " , (sum(ISNULL(r.revenue_adms, 0))+sum(ISNULL(cr.comprevenue_admssum, 0))) as thai_dub_adms"
    '    'strSQL += vbNewLine + " from tblMovie m"
    '    'strSQL += vbNewLine + " left join tblRevenue r on m.movie_id = r.movies_id"
    '    'strSQL += vbNewLine + " left join tblCompRevenue cr on m.movie_id = cr.movies_id"
    '    'strSQL += vbNewLine + "  WHERE (m.movie_id = " + wkMvID + ")"
    '    'strSQL += vbNewLine + "  and ((r.revenue_date >= convert(datetime, '" + Sd + "',101) and r.revenue_date <= convert(datetime,'" + Ed + "',101))"
    '    'strSQL += vbNewLine + "  or (cr.comprevenue_date >= convert(datetime, '" + Sd + "',101) and cr.comprevenue_date <= convert(datetime,'" + Ed + "',101)))"
    '    'strSQL += vbNewLine + "  and (r.sound_type = 'พากย์ไทย'  or cr.comprevenue_screenor is not null)"
    '    'strSQL += vbNewLine + "  group by isnull(r.theater_id,0)+isnull(cr.theater_id,0), m.movie_id, r.sound_type"
    '    'strSQL += vbNewLine + "  ) AS sub_thai_dub_adms ON tblRelease.theater_id = sub_soundtrack_amt.theater_id"
    '    'strSQL += vbNewLine + " and tblRelease.movies_id = sub_soundtrack_amt.movie_id"
    '    'strSQL += vbNewLine + " LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id"
    '    'strSQL += vbNewLine + " GROUP BY tblRelease.movies_id, tblRelease.theater_id, tblTheater.theater_code, tblTheater.theater_name"
    '    'strSQL += vbNewLine + " ORDER BY tblTheater.theater_name"

    '    Dim dtb As DataTable = cDatabase.GetDataTable("EXEC spGetRptCompSoundFormat " + wkMvID + ",'" + Sd + "','" + Ed + "','Theatre_Sound'")

    '    tbl.Rows(0).Cells(0).Text = Session("msRptMovieName") & " Box Office By Theatre & Sound"
    '    tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

    '    Dim sessionCount, SUMgbo_amount, SUMgbo_adms, SUMsoundtrack_amt, SUMsoundtrack_adms, SUMthai_dub_amt, SUMthai_dub_adms, rowCount, Sum3DAdms, Sum3DAmount As Double
    '    Dim lastTheater As String
    '    Dim movieSys As String
    '    Dim movieSound As String
    '    lastTheater = ""
    '    sessionCount = 0
    '    movieSys = ""
    '    movieSound = ""
    '    SUMgbo_amount = 0
    '    SUMgbo_adms = 0
    '    SUMsoundtrack_amt = 0
    '    SUMsoundtrack_adms = 0
    '    SUMthai_dub_amt = 0
    '    SUMthai_dub_adms = 0
    '    Sum3DAdms = 0
    '    Sum3DAmount = 0
    '    rowCount = 0
    '    For i As Integer = 0 To dtb.Rows.Count - 1
    '        If CDbl(dtb.Rows(i)("gbo_amount")) > 0 Then
    '            Dim detailsRow As New TableRow()
    '            detailsRow.HorizontalAlign = HorizontalAlign.Center
    '            rowCount = rowCount + 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    '            detailsRow.Cells(0).Text = dtb.Rows(i)("theater_name")

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(1).Text = "<a href=frmRptSoundFormatComp.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=soundtrack>" + Format(dtb.Rows(i)("soundtrack_amt"), "#,##0") + "</a>"
    '            SUMsoundtrack_amt = SUMsoundtrack_amt + CDbl(dtb.Rows(i)("soundtrack_amt"))
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(2).Text = Format(dtb.Rows(i)("soundtrack_adms"), "#,##0")
    '            SUMsoundtrack_adms = SUMsoundtrack_adms + CDbl(dtb.Rows(i)("soundtrack_adms"))

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(3).Text = "<a href=frmRptSoundFormatComp.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=thaidub>" + Format(dtb.Rows(i)("thai_dub_amt"), "#,##0") + "</a>"
    '            SUMthai_dub_amt = SUMthai_dub_amt + CDbl(dtb.Rows(i)("thai_dub_amt"))

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(4).Text = Format(dtb.Rows(i)("thai_dub_adms"), "#,##0")
    '            SUMthai_dub_adms = SUMthai_dub_adms + CDbl(dtb.Rows(i)("thai_dub_adms"))

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(5).Text = "<a href=frmRptSoundFormatComp.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=dim>" + Format(dtb.Rows(i)("comprevenue_amounttd"), "#,##0") + "</a>" '3d
    '            Sum3DAmount = Sum3DAmount + CDbl(dtb.Rows(i)("comprevenue_amounttd"))
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(6).Text = Format(dtb.Rows(i)("comprevenue_admstd"), "#,##0") '3d
    '            Sum3DAdms = Sum3DAdms + CDbl(dtb.Rows(i)("comprevenue_admstd"))

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(7).Text = Format(dtb.Rows(i)("gbo_amount"), "#,##0")
    '            SUMgbo_amount = SUMgbo_amount + CDbl(dtb.Rows(i)("gbo_amount"))
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(8).Text = Format(dtb.Rows(i)("gbo_adms"), "#,##0")
    '            SUMgbo_adms = SUMgbo_adms + CDbl(dtb.Rows(i)("gbo_adms"))

    '            tbl.Rows.Add(detailsRow)
    '        End If
    '    Next

    '    'Dim i As Integer
    '    Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
    '    sumPerBox = 0
    '    sumPerAdms = 0
    '    sumPerBoxAll = 0
    '    sumPerAdmsAll = 0

    '    'For i = 1 To rowCount
    '    'tbl.Rows(rowCount + 3).Cells(1).Text = Format(SUMgbo_amount, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(2).Text = Format(SUMgbo_adms, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(3).Text = Format(SUMsoundtrack_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(4).Text = Format(SUMsoundtrack_adms, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(5).Text = Format(SUMthai_dub_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(6).Text = Format(SUMthai_dub_adms, "#,##0.##")
    '    'Next
    '    Dim totalRow As New TableRow()
    '    totalRow.HorizontalAlign = HorizontalAlign.Center
    '    totalRow.Font.Bold = True
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(0).Text = "TOTAL"
    '    totalRow.Cells(0).BackColor = Color.LightGray

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(1).BackColor = Color.LightGray
    '    totalRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(1).Text = Format(SUMsoundtrack_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(2).BackColor = Color.LightGray
    '    totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(2).Text = Format(SUMsoundtrack_adms, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(3).BackColor = Color.LightGray
    '    totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(3).Text = Format(SUMthai_dub_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(4).BackColor = Color.LightGray
    '    totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(4).Text = Format(SUMthai_dub_adms, "#,##0.##")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(5).Text = Format(Sum3DAmount, "#,##0.##")
    '    totalRow.Cells(5).BackColor = Color.LightGray
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(6).Text = Format(Sum3DAdms, "#,##0.##")
    '    totalRow.Cells(6).BackColor = Color.LightGray

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(7).Text = Format(SUMgbo_amount, "#,##0.##")
    '    totalRow.Cells(7).BackColor = Color.LightGray
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(8).Text = Format(SUMgbo_adms, "#,##0.##")
    '    totalRow.Cells(8).BackColor = Color.LightGray
    '    tbl.Rows.Add(totalRow)

    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/12/03 : Add filmtype and sound
    Private Const COLUMN_START_HEADER_0 As Integer = 1
    Private Const COLUMN_START_HEADER_1 As Integer = 0
    Private Const COLUMN_START_DETAIL_0 As Integer = 1
    Private Const COLUMN_START_FOOTER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_1 As Integer = 3
    Private Const PIVOT_NUM_DETAIL_0 As Integer = 3
    Private Const PIVOT_NUM_FOOTER_0 As Integer = 3
    Private Const PIVOT_WIDTH_HEADER_0 As Integer = 200

    '--- Added by Wittawat W. (CSI) on 2012/12/03 : Add filmtype and sound
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        Dim movieId As String = Session("msRptMovieID")
        Dim startDate As String = Format(Session("msRptStrDate"), "yyyyMMdd")
        Dim endDate As String = Format(Session("msRptEndDate"), "yyyyMMdd")

        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptCompSoundFormat " _
                                                           + movieId _
                                                           + ", '" + startDate + "'" _
                                                           + ", '" + endDate + "'" _
                                                           + ", 'Theatre_Sound'")

        Dim dtPivot As DataTable = cDatabase.GetDataTable("select film_type_sound_header_group " _
                                                          + "from tblFilmTypeSound " _
                                                          + "where film_type_sound_header_group is not null " _
                                                          + "group by film_type_sound_header_group " _
                                                          + "order by max(film_type_sound_id) ")

        Dim widthReport As Integer = 200 + PIVOT_WIDTH_HEADER_0 * dtPivot.Rows.Count + PIVOT_WIDTH_HEADER_0
        Dim colspanReport As Integer = COLUMN_START_HEADER_0 + PIVOT_NUM_HEADER_1 * dtPivot.Rows.Count + PIVOT_NUM_HEADER_1

        Me.tableReport.Width = New Unit(widthReport)
        Me.tableReport.Rows(0).Cells(0).Text = String.Format(Me.tableReport.Rows(0).Cells(0).Text, Session("msRptMovieName"))
        Me.tableReport.Rows(0).Cells(0).ColumnSpan = colspanReport
        Me.tableReport.Rows(1).Cells(0).Text = String.Format(Me.tableReport.Rows(1).Cells(0).Text, Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy"), Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy"))
        Me.tableReport.Rows(1).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader0(PIVOT_NUM_HEADER_0 - 1) As TableHeaderCell
            For jj As Integer = tdHeader0.Length - 1 To 0 Step -1
                Dim x As Integer = 2
                Dim y As Integer = COLUMN_START_HEADER_0
                tdHeader0(jj) = New TableHeaderCell
                tdHeader0(jj).Width = Me.tableReport.Rows(x).Cells(y).Width
                tdHeader0(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdHeader0(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader0(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdHeader0(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdHeader0(jj).Text = dtPivot.Rows(j)("film_type_sound_header_group")
                Me.tableReport.Rows(x).Cells.AddAt(COLUMN_START_HEADER_0, tdHeader0(jj))
            Next

            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim xx As Integer = 3
                Dim yy As Integer = COLUMN_START_HEADER_1 + (PIVOT_NUM_HEADER_1 - 1)
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).ColumnSpan = Me.tableReport.Rows(xx).Cells(yy).ColumnSpan
                tdHeader1(jj).Width = Me.tableReport.Rows(xx).Cells(yy).Width
                tdHeader1(jj).HorizontalAlign = Me.tableReport.Rows(xx).Cells(yy).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tableReport.Rows(xx).Cells(yy).BackColor
                tdHeader1(jj).ForeColor = Me.tableReport.Rows(xx).Cells(yy).ForeColor
                tdHeader1(jj).Text = Me.tableReport.Rows(xx).Cells(yy).Text
                Me.tableReport.Rows(xx).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdFooter0(PIVOT_NUM_HEADER_1 - 1) As TableCell
            For jj As Integer = tdFooter0.Length - 1 To 0 Step -1
                Dim xxx As Integer = Me.tableReport.Rows.Count - 1
                Dim yyy As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter0(jj) = New TableCell
                tdFooter0(jj).ColumnSpan = Me.tableReport.Rows(xxx).Cells(yyy).ColumnSpan
                tdFooter0(jj).HorizontalAlign = Me.tableReport.Rows(xxx).Cells(yyy).HorizontalAlign
                tdFooter0(jj).BackColor = Me.tableReport.Rows(xxx).Cells(yyy).BackColor
                tdFooter0(jj).ForeColor = Me.tableReport.Rows(xxx).Cells(yyy).ForeColor
                tdFooter0(jj).Text = Me.tableReport.Rows(xxx).Cells(yyy).Text
                Me.tableReport.Rows(xxx).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter0(jj))
            Next
        Next

        '--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail0 As New TableRow()

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(0).Text = String.Format("{0}", dtDetail.Rows(i)("theater_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))
                    trDetail0.Cells(y + 0).Text = String.Format("<a href=""frmRptSoundFormatComp.aspx?theaterid={0}&theatername={1}&headergroup={2}&typeid={3}"">{4}</a>" _
                                                                , dtDetail.Rows(i)("theater_id") _
                                                                , dtDetail.Rows(i)("theater_name") _
                                                                , dtPivot.Rows(j)("film_type_sound_header_group") _
                                                                , "Theatre_Sound" _
                                                                , String.Format("{0:#,##0}", dtDetail.Rows(i)(String.Format("{0}", dtPivot.Rows(j)("film_type_sound_header_group")) + " Amount")))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Screen"))
                Else
                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Screen"))
                End If
            Next

            Me.tableReport.Rows.AddAt(Me.tableReport.Rows.Count - 1, trDetail0)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tableReport.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
                Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Screen])", ""))
            Else
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
                Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Screen])", ""))
            End If
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptCompSoundFormat.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TheatreAndSound.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        '--- Modified by Wittawat W. (CSI) on 2012/12/03 : Add filmtype and sound
        'tbl.RenderControl(htmlWrite)
        Me.tableReport.RenderControl(htmlWrite)
        '--- End modified by Wittawat W. (CSI) on 2012/12/03 : Add filmtype and sound
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class