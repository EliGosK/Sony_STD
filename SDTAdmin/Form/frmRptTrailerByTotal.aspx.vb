Imports Web.Data
Imports System.IO

Partial Public Class frmRptTrailerByTotal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        While (tbl.Rows.Count > 4)
            tbl.Rows.RemoveAt(4)
        End While

        Dim rptDate As String = ""
        If (Not ValidateQueryString(Request.QueryString("rptDate"), GetType(String), rptDate)) Then
            Response.Redirect("frmRptTrailerByTotalParam.aspx")
        End If

        Dim cDB As New cDatabase
        'tbl.Rows(0).Cells(0).Text = "คลมบย"
        'tbl.Rows(2).Cells(0).Text = "PERIOD : " & Convert.ToString(Request.QueryString("rptDate"))
        tbl.Rows(2).Cells(0).Text = "PERIOD : " & rptDate
        Dim wkSetupNo As String = Convert.ToString(Request.QueryString("rptSetupNo"))

        Dim wkSQL As String

        ''eed
        'wkSQL = " select trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
        'wkSQL += vbNewLine + " trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name "
        'wkSQL += vbNewLine + " , trailer.movietypeId as movietypeId"
        'wkSQL += vbNewLine + " , isnull((select count(col.movie_id)"
        'wkSQL += vbNewLine + " from"
        'wkSQL += vbNewLine + " (select distinct ch.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
        'wkSQL += vbNewLine + " from tblTrailer_Master tm"
        'wkSQL += vbNewLine + " left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
        'wkSQL += vbNewLine + " left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
        'wkSQL += vbNewLine + " left join tblMovie m on cd.movie_id = m.movie_id"
        'wkSQL += vbNewLine + " where cd.ref_setup_no = '" + wkSetupNo + "'"
        'wkSQL += vbNewLine + " AND (ch.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
        ''wkSQL += vbNewLine + " AND (cd.movie_id = " + Convert.ToString(Session("rptMovieID")) + " OR " + Convert.ToString(Session("rptMovieID")) + " is null)"
        'wkSQL += vbNewLine + " ) col"
        'wkSQL += vbNewLine + " where(col.movie_id = trailer.setup_movie_id)"
        'wkSQL += vbNewLine + " and col.circuit_id = c.circuit_id"
        'wkSQL += vbNewLine + " ), 0) as CountMovie"
        'wkSQL += vbNewLine + " from tblCircuit c,"
        'wkSQL += vbNewLine + " ("
        'wkSQL += vbNewLine + " select sd.setup_no, sd.movie_id as setup_movie_id,"
        'wkSQL += vbNewLine + " min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate"
        'wkSQL += vbNewLine + " ,min(m.movietype_id) as movietypeId"
        'wkSQL += vbNewLine + " from tblTrailer_Setup_Dtl sd"
        'wkSQL += vbNewLine + " left join tblMovie m on sd.movie_id = m.movie_id"
        'wkSQL += vbNewLine + " where sd.setup_no = '" + wkSetupNo + "'"
        'wkSQL += vbNewLine + " group by sd.setup_no, sd.movie_id,  m.movie_strdate"
        'wkSQL += vbNewLine + " ) trailer"
        'wkSQL += vbNewLine + " where 1=1"
        'wkSQL += vbNewLine + " and (c.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
        'wkSQL += vbNewLine + " and (trailer.setup_movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " OR " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
        'wkSQL += vbNewLine + " order by trailer.setup_movie_strdate, trailer.setup_movie_id, c.circuit_name "


        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQL = " select trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
        wkSQL += vbNewLine + " trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name, trailer.movietypeId as movietypeId, "
        wkSQL += vbNewLine + " isnull("
        wkSQL += vbNewLine + " ("
        wkSQL += vbNewLine + " 	select count(col.movie_id)"
        wkSQL += vbNewLine + " 	from"
        wkSQL += vbNewLine + " 	(	select distinct t.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
        wkSQL += vbNewLine + " 		from tblTrailer_Master tm"
        wkSQL += vbNewLine + " 		left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
        wkSQL += vbNewLine + " 		left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
        wkSQL += vbNewLine + " 		left join tblMovie m on cd.movie_id = m.movie_id"
        wkSQL += vbNewLine + " 		left join tblTheater t on tm.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 		left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 		where cd.ref_setup_no = '" + wkSetupNo + "'"
        wkSQL += vbNewLine + " 		and (t.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " or " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
        'wkSQL += vbNewLine + " 		and t.theater_status = 'Enabled'"
        wkSQL += vbNewLine + " 	) col"
        wkSQL += vbNewLine + " 	where(col.movie_id = trailer.setup_movie_id)"
        wkSQL += vbNewLine + " 	and col.circuit_id = c.circuit_id"
        wkSQL += vbNewLine + " ), 0) as CountMovie"
        wkSQL += vbNewLine + " from tblCircuit c,"
        wkSQL += vbNewLine + " ("
        wkSQL += vbNewLine + " select sd.setup_no, sd.movie_id as setup_movie_id,"
        wkSQL += vbNewLine + " min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate, min(m.movietype_id) as movietypeId"
        wkSQL += vbNewLine + " from tblTrailer_Setup_Dtl sd"
        wkSQL += vbNewLine + " left join tblMovie m on sd.movie_id = m.movie_id"
        wkSQL += vbNewLine + " where sd.setup_no = '" + wkSetupNo + "'"
        wkSQL += vbNewLine + " group by sd.setup_no, sd.movie_id,  m.movie_strdate"
        wkSQL += vbNewLine + " ) trailer"
        wkSQL += vbNewLine + " where 1=1"
        wkSQL += vbNewLine + " and (c.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " or " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
        wkSQL += vbNewLine + " and (trailer.setup_movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " or " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
        wkSQL += vbNewLine + " order by trailer.setup_movie_strdate, trailer.setup_movie_id, c.circuit_name "
        '--- End by Muay 2010-06-09 --------------------------------------------


        Dim dr As IDataReader = cDB.GetDataAll(wkSQL)

        ViewState("MovieID") = Nothing
        Dim checkRow As Integer = 0
        Dim rowCount As Integer = 0
        Dim wkCircuitID As String = ""
        While (dr.Read())
            Dim detailsRow As New TableRow()
            If (rowCount Mod 2) = 1 Then
                detailsRow.BackColor = Color.FromName("#F7F6F3")
            End If
            ''''rowCount = rowCount + 1
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11
            Dim HeadCircuitRow As New TableRow()
            HeadCircuitRow.HorizontalAlign = HorizontalAlign.Left
            HeadCircuitRow.Font.Name = "Tahoma"
            HeadCircuitRow.Font.Size = 11
            HeadCircuitRow.Height = 23
            'HeadCircuitRow.Width = 600
            If checkRow = 0 Then
                checkRow = checkRow + 1
                ViewState("MovieID") = dr("movie_id")
                wkCircuitID = dr("MovieName") & " : " & Format(dr("movie_strdate"), "dd/MM/yyyy") + "    "
                rowCount = 0

                HeadCircuitRow.Cells.Add(New TableCell)
                HeadCircuitRow.Cells(0).ColumnSpan = 3
                HeadCircuitRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                HeadCircuitRow.Cells(0).Font.Bold = True
                HeadCircuitRow.Cells(0).Text = "- " & wkCircuitID
                If cDB.CheckIsNullString(dr("movietypeId")) = "1" Then
                    HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#b8f4ff") '"#000000")
                    HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D") '"#C2D8FE")
                Else
                    HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                    HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                End If
                HeadCircuitRow.Cells(0).Height = 25

                tbl.Rows.Add(HeadCircuitRow)

                rowCount = rowCount + 1
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(0).Text = rowCount.ToString
                detailsRow.Cells(0).Width = 50

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
                detailsRow.Cells(1).Font.Bold = True
                detailsRow.Cells(1).Text = dr("circuit_name").ToString

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(2).Width = 150
                detailsRow.Cells(2).Text = dr("CountMovie").ToString

                tbl.Rows.Add(detailsRow)

            Else
                If wkCircuitID = dr("MovieName") & " : " & Format(dr("movie_strdate"), "dd/MM/yyyy") + "    " Then
                    rowCount = rowCount + 1
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(0).Text = rowCount.ToString
                    detailsRow.Cells(0).Width = 50

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
                    detailsRow.Cells(1).Font.Bold = True
                    detailsRow.Cells(1).Width = 380
                    detailsRow.Cells(1).Text = dr("circuit_name").ToString

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = dr("CountMovie").ToString
                    detailsRow.Cells(2).Width = 150

                    tbl.Rows.Add(detailsRow)
                Else
                    Dim wkSQLsum As String

                    'wkSQLsum = " select mas.movie_id, mas.MovieName, sum(mas.CountMovie) as total_movie"
                    'wkSQLsum += vbNewLine + " from"
                    'wkSQLsum += vbNewLine + " ("
                    'wkSQLsum += vbNewLine + " 	select  trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
                    'wkSQLsum += vbNewLine + " 	trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name,"
                    'wkSQLsum += vbNewLine + " 	isnull((select count(col.movie_id)"
                    'wkSQLsum += vbNewLine + " 			from"
                    'wkSQLsum += vbNewLine + " 			(select distinct ch.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
                    'wkSQLsum += vbNewLine + " 			from tblTrailer_Master tm"
                    'wkSQLsum += vbNewLine + " 			left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
                    'wkSQLsum += vbNewLine + " 			left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
                    'wkSQLsum += vbNewLine + " 			left join tblMovie m on cd.movie_id = m.movie_id"
                    'wkSQLsum += vbNewLine + " 			where cd.ref_setup_no = '" + wkSetupNo + "'"
                    'wkSQLsum += vbNewLine + " and (ch.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
                    'wkSQLsum += vbNewLine + " AND (cd.movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " OR " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
                    'wkSQLsum += vbNewLine + " 			) col"
                    'wkSQLsum += vbNewLine + " 			where col.movie_id = trailer.setup_movie_id"
                    'wkSQLsum += vbNewLine + " 			and col.circuit_id = c.circuit_id"
                    'wkSQLsum += vbNewLine + " 			), 0) as CountMovie"
                    'wkSQLsum += vbNewLine + " 	from tblCircuit c,"
                    'wkSQLsum += vbNewLine + " 	("
                    'wkSQLsum += vbNewLine + " 	select sd.setup_no, sd.movie_id as setup_movie_id,"
                    'wkSQLsum += vbNewLine + " 	min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate"
                    'wkSQLsum += vbNewLine + " 	from tblTrailer_Setup_Dtl sd"
                    'wkSQLsum += vbNewLine + " 	left join tblMovie m on sd.movie_id = m.movie_id"
                    'wkSQLsum += vbNewLine + " 	where sd.setup_no = '" + wkSetupNo + "'"
                    'wkSQLsum += vbNewLine + " 	group by sd.setup_no, sd.movie_id,  m.movie_strdate"
                    'wkSQLsum += vbNewLine + " 	) trailer"
                    'wkSQLsum += vbNewLine + " ) mas"
                    'wkSQLsum += vbNewLine + " where mas.movie_id = " + ViewState("MovieID").ToString
                    ''wkSQLsum += vbNewLine + " and (c.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
                    ''wkSQLsum += vbNewLine + " and (mas.movie_id = " + Convert.ToString(Session("rptMovieID")) + " OR " + Convert.ToString(Session("rptMovieID")) + " is null)"
                    'wkSQLsum += vbNewLine + " group by mas.movie_id, mas.MovieName"

                    '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
                    wkSQLsum = " select mas.movie_id, mas.MovieName, sum(mas.CountMovie) as total_movie"
                    wkSQLsum += vbNewLine + "from"
                    wkSQLsum += vbNewLine + "("
                    wkSQLsum += vbNewLine + "select  trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
                    wkSQLsum += vbNewLine + "trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name,"
                    wkSQLsum += vbNewLine + "isnull((select count(col.movie_id)"
                    wkSQLsum += vbNewLine + "		from"
                    wkSQLsum += vbNewLine + "		(select distinct t.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
                    wkSQLsum += vbNewLine + "		from tblTrailer_Master tm"
                    wkSQLsum += vbNewLine + "		left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
                    wkSQLsum += vbNewLine + "		left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
                    wkSQLsum += vbNewLine + "		left join tblMovie m on cd.movie_id = m.movie_id"
                    wkSQLsum += vbNewLine + "		left join tblTheater t on tm.theater_id = t.theater_id"
                    wkSQLsum += vbNewLine + "		left join tblCircuit cc on t.circuit_id = cc.circuit_id "
                    wkSQLsum += vbNewLine + "		where cd.ref_setup_no = '" + wkSetupNo + "'"
                    wkSQLsum += vbNewLine + "		and (t.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
                    wkSQLsum += vbNewLine + "		and (cd.movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " OR " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
                    'wkSQLsum += vbNewLine + "		and t.theater_status = 'Enabled'"
                    wkSQLsum += vbNewLine + "		) col"
                    wkSQLsum += vbNewLine + "		where col.movie_id = trailer.setup_movie_id"
                    wkSQLsum += vbNewLine + "		and col.circuit_id = c.circuit_id"
                    wkSQLsum += vbNewLine + "		), 0) as CountMovie"
                    wkSQLsum += vbNewLine + "from tblCircuit c,"
                    wkSQLsum += vbNewLine + "("
                    wkSQLsum += vbNewLine + "select sd.setup_no, sd.movie_id as setup_movie_id,"
                    wkSQLsum += vbNewLine + "min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate"
                    wkSQLsum += vbNewLine + "from tblTrailer_Setup_Dtl sd"
                    wkSQLsum += vbNewLine + "left join tblMovie m on sd.movie_id = m.movie_id"
                    wkSQLsum += vbNewLine + "where sd.setup_no = '" + wkSetupNo + "'"
                    wkSQLsum += vbNewLine + "group by sd.setup_no, sd.movie_id,  m.movie_strdate"
                    wkSQLsum += vbNewLine + ") trailer"
                    wkSQLsum += vbNewLine + ") mas"
                    wkSQLsum += vbNewLine + "where mas.movie_id = " + ViewState("MovieID").ToString
                    wkSQLsum += vbNewLine + "group by mas.movie_id, mas.MovieName"
                    '--- End by Muay 2010-06-09 --------------------------------------------

                    Dim drSum As IDataReader = cDB.GetDataAll(wkSQLsum)
                    If drSum.Read Then
                        Dim totalRow As New TableRow
                        totalRow.Font.Name = "Tahoma"
                        totalRow.Font.Size = 11
                        totalRow.Font.Bold = True

                        totalRow.Cells.Add(New TableCell)
                        totalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
                        totalRow.Cells(0).ColumnSpan = 2
                        totalRow.Cells(0).ForeColor = Color.Red
                        totalRow.Cells(0).Text = "Total"

                        totalRow.Cells.Add(New TableCell)
                        totalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
                        totalRow.Cells(1).Text = drSum("total_movie").ToString
                        totalRow.Cells(1).ForeColor = Color.Red

                        tbl.Rows.Add(totalRow)
                    End If
                    drSum.Close()

                    wkCircuitID = dr("MovieName") & " : " & Format(dr("movie_strdate"), "dd/MM/yyyy") + "    "
                    ViewState("MovieID") = dr("movie_id")
                    rowCount = 0
                    HeadCircuitRow.Cells.Add(New TableCell)
                    HeadCircuitRow.Cells(0).ColumnSpan = 3
                    HeadCircuitRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                    HeadCircuitRow.Cells(0).Font.Bold = True
                    HeadCircuitRow.Cells(0).Text = "- " & wkCircuitID
                    If cDB.CheckIsNullString(dr("movietypeId")) = "1" Then
                        HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#b8f4ff") '"#000000")
                        HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D") '"#C2D8FE")
                    Else
                        HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                        HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                    End If
                    HeadCircuitRow.Cells(0).Height = 20
                    tbl.Rows.Add(HeadCircuitRow)

                    rowCount = 1

                    detailsRow.Cells.Add(New TableCell)

                    detailsRow.BackColor = Color.FromName("#FFFFFF")

                    detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(0).Text = rowCount.ToString
                    detailsRow.Cells(0).Width = 50

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
                    detailsRow.Cells(1).Font.Bold = True
                    detailsRow.Cells(1).Text = dr("circuit_name").ToString
                    detailsRow.Cells(1).Width = 380

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = dr("CountMovie").ToString
                    detailsRow.Cells(2).Width = 150

                    tbl.Rows.Add(detailsRow)
                End If
            End If
        End While
        dr.Close()

        If ViewState("MovieID") <> Nothing Then
            Dim wkSQLsumEnd As String

            'wkSQLsumEnd = " select mas.movie_id, mas.MovieName, sum(mas.CountMovie) as total_movie"
            'wkSQLsumEnd += vbNewLine + " from"
            'wkSQLsumEnd += vbNewLine + " ("
            'wkSQLsumEnd += vbNewLine + " 	select  trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
            'wkSQLsumEnd += vbNewLine + " 	trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name,"
            'wkSQLsumEnd += vbNewLine + " 	isnull((select count(col.movie_id)"
            'wkSQLsumEnd += vbNewLine + " 			from"
            'wkSQLsumEnd += vbNewLine + " 			(select distinct ch.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
            'wkSQLsumEnd += vbNewLine + " 			from tblTrailer_Master tm"
            'wkSQLsumEnd += vbNewLine + " 			left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
            'wkSQLsumEnd += vbNewLine + " 			left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
            'wkSQLsumEnd += vbNewLine + " 			left join tblMovie m on cd.movie_id = m.movie_id"
            'wkSQLsumEnd += vbNewLine + " 			where cd.ref_setup_no = '" + wkSetupNo + "'"
            'wkSQLsumEnd += vbNewLine + " and (tm.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
            'wkSQLsumEnd += vbNewLine + " AND (cd.movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " OR " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
            'wkSQLsumEnd += vbNewLine + " 			) col"
            'wkSQLsumEnd += vbNewLine + " 			where col.movie_id = trailer.setup_movie_id"
            'wkSQLsumEnd += vbNewLine + " 			and col.circuit_id = c.circuit_id"
            'wkSQLsumEnd += vbNewLine + " 			), 0) as CountMovie"
            'wkSQLsumEnd += vbNewLine + " 	from tblCircuit c,"
            'wkSQLsumEnd += vbNewLine + " 	("
            'wkSQLsumEnd += vbNewLine + " 	select sd.setup_no, sd.movie_id as setup_movie_id,"
            'wkSQLsumEnd += vbNewLine + " 	min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate"
            'wkSQLsumEnd += vbNewLine + " 	from tblTrailer_Setup_Dtl sd"
            'wkSQLsumEnd += vbNewLine + " 	left join tblMovie m on sd.movie_id = m.movie_id"
            'wkSQLsumEnd += vbNewLine + " 	where sd.setup_no = '" + wkSetupNo + "'"
            'wkSQLsumEnd += vbNewLine + " 	group by sd.setup_no, sd.movie_id,  m.movie_strdate"
            'wkSQLsumEnd += vbNewLine + " 	) trailer"
            'wkSQLsumEnd += vbNewLine + " ) mas"
            'wkSQLsumEnd += vbNewLine + " where mas.movie_id = " + ViewState("MovieID").ToString
            ''wkSQLsumEnd += vbNewLine + " and (c.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
            ''wkSQLsumEnd += vbNewLine + " and (mas.movie_id = " + Convert.ToString(Session("rptMovieID")) + " OR " + Convert.ToString(Session("rptMovieID")) + " is null)"
            'wkSQLsumEnd += vbNewLine + " group by mas.movie_id, mas.MovieName"

            '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
            wkSQLsumEnd = " select mas.movie_id, mas.MovieName, sum(mas.CountMovie) as total_movie"
            wkSQLsumEnd += vbNewLine + " from"
            wkSQLsumEnd += vbNewLine + " ("
            wkSQLsumEnd += vbNewLine + " select  trailer.setup_no, trailer.setup_movie_id as movie_id, setup_movie_title as MovieName, "
            wkSQLsumEnd += vbNewLine + " trailer.setup_movie_strdate as movie_strdate, c.circuit_id, c.circuit_name,"
            wkSQLsumEnd += vbNewLine + " isnull((select count(col.movie_id)"
            wkSQLsumEnd += vbNewLine + " 		from"
            wkSQLsumEnd += vbNewLine + " 		(select distinct t.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id "
            wkSQLsumEnd += vbNewLine + " 		from tblTrailer_Master tm"
            wkSQLsumEnd += vbNewLine + " 		left join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
            wkSQLsumEnd += vbNewLine + " 		left join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
            wkSQLsumEnd += vbNewLine + " 		left join tblMovie m on cd.movie_id = m.movie_id"
            wkSQLsumEnd += vbNewLine + " 		left join tblTheater t on tm.theater_id = t.theater_id"
            wkSQLsumEnd += vbNewLine + " 		left join tblCircuit cc on t.circuit_id = cc.circuit_id "
            wkSQLsumEnd += vbNewLine + " 		where cd.ref_setup_no = '" + wkSetupNo + "'"
            wkSQLsumEnd += vbNewLine + " 		and (t.circuit_id = " + Convert.ToString(Request.QueryString("rptCircuitID")) + " OR " + Convert.ToString(Request.QueryString("rptCircuitID")) + " is null)"
            wkSQLsumEnd += vbNewLine + " 		and (cd.movie_id = " + Convert.ToString(Request.QueryString("rptMovieID")) + " OR " + Convert.ToString(Request.QueryString("rptMovieID")) + " is null)"
            'wkSQLsumEnd += vbNewLine + " 		and t.theater_status = 'Enabled'"
            wkSQLsumEnd += vbNewLine + " 		) col"
            wkSQLsumEnd += vbNewLine + " 		where col.movie_id = trailer.setup_movie_id"
            wkSQLsumEnd += vbNewLine + " 		and col.circuit_id = c.circuit_id"
            wkSQLsumEnd += vbNewLine + " 		), 0) as CountMovie"
            wkSQLsumEnd += vbNewLine + " from tblCircuit c,"
            wkSQLsumEnd += vbNewLine + " ("
            wkSQLsumEnd += vbNewLine + " select sd.setup_no, sd.movie_id as setup_movie_id,"
            wkSQLsumEnd += vbNewLine + " min(m.movie_nameen) as setup_movie_title, m.movie_strdate as setup_movie_strdate"
            wkSQLsumEnd += vbNewLine + " from tblTrailer_Setup_Dtl sd"
            wkSQLsumEnd += vbNewLine + " left join tblMovie m on sd.movie_id = m.movie_id"
            wkSQLsumEnd += vbNewLine + " where sd.setup_no = '" + wkSetupNo + "'"
            wkSQLsumEnd += vbNewLine + " group by sd.setup_no, sd.movie_id,  m.movie_strdate"
            wkSQLsumEnd += vbNewLine + " ) trailer"
            wkSQLsumEnd += vbNewLine + " ) mas"
            wkSQLsumEnd += vbNewLine + " where mas.movie_id = " + ViewState("MovieID").ToString
            wkSQLsumEnd += vbNewLine + " group by mas.movie_id, mas.MovieName"
            '--- End by Muay 2010-06-09 --------------------------------------------

            Dim drSumEnd As IDataReader = cDB.GetDataAll(wkSQLsumEnd)
            If drSumEnd.Read Then
                Dim totalRowEnd As New TableRow
                totalRowEnd.Font.Name = "Tahoma"
                totalRowEnd.Font.Size = 11
                totalRowEnd.Font.Bold = True

                totalRowEnd.Cells.Add(New TableCell)
                totalRowEnd.Cells(0).HorizontalAlign = HorizontalAlign.Right
                totalRowEnd.Cells(0).ColumnSpan = 2
                totalRowEnd.Cells(0).Text = "Total"
                totalRowEnd.Cells(0).ForeColor = Color.Red

                totalRowEnd.Cells.Add(New TableCell)
                totalRowEnd.Cells(1).HorizontalAlign = HorizontalAlign.Center
                totalRowEnd.Cells(1).Text = drSumEnd("total_movie").ToString()
                totalRowEnd.Cells(1).ForeColor = Color.Red
                totalRowEnd.Cells(1).Width = 150
                totalRowEnd.Cells(1).ColumnSpan = 1

                tbl.Rows.Add(totalRowEnd)
            End If
            drSumEnd.Close()

        End If
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        If (Request.QueryString("isviewer") Is Nothing) Then
            Response.Redirect("frmRptTrailerByTotalParam.aspx")
        Else
            Response.Redirect("frmRptTrailerViewership.aspx")
        End If
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TrailerByCircuit.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        divExport.RenderControl(htmlWrite)
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class