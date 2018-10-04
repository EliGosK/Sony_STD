Imports Web.Data

Partial Public Class frmRptTrailerByPercent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        'If Not IsPostBack Then
        strReport()
        'End If


    End Sub

    Sub strReport()
        Dim strShow As String = ""
        While (tbl.Rows.Count > 4)
            tbl.Rows.RemoveAt(4)
        End While

        Dim cDB As New cDatabase
        Dim RealMovieID As String = Session("rptRealMovie").ToString
        Dim TrailerMovieID As String = Session("rptTrailerMovie").ToString
        Dim SetupNo As String = Session("rptSetupNo").ToString
        Dim TrailerName As String = ""
        Dim RealName As String = ""

        Dim drTrailer As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + TrailerMovieID)
        If drTrailer.Read Then
            TrailerName = drTrailer("movie_nameen").ToString
        End If
        drTrailer.Close()

        Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
        If drReal.Read Then
            RealName = drReal("movie_nameen").ToString
        End If
        drReal.Close()
        tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
        If (Convert.ToString(Session("rptPeriod")).Trim() = "") Then
            tbl.Rows(2).Cells(0).Text = "PERIOD : -"
        Else
            tbl.Rows(2).Cells(0).Text = "PERIOD : " + Convert.ToString(Session("rptPeriod"))
        End If
        tbl.Rows(3).Cells(0).Text = RealName
        Dim wkSQL As String

        'wkSQL = vbNewLine + " select a.circuit_id, a.circuit_name, a.real_movie_id, a.real_movie_name, "
        'wkSQL += vbNewLine + " a.trailer_movie_id, a.trailer_movie_name, a.real_movie_amt, a.trailer_amt, a.movie_percent, a.setup_no, "
        'wkSQL += vbNewLine + " a.setup_start_date, a.setup_end_date, a.all_theater_release, a.all_theater_terminate, "
        'wkSQL += vbNewLine + " a.real_movie_strdate, a.trailer_movie_strdate, a.end_date"
        'wkSQL += vbNewLine + " from"
        'wkSQL += vbNewLine + " ("
        'wkSQL += vbNewLine + " 	select tr.circuit_id, tr.circuit_name, tr.real_movie_id, tr.real_movie_name, "
        'wkSQL += vbNewLine + " 	tr.trailer_movie_id, tr.trailer_movie_name, tr.real_movie_amt, tr.trailer_amt, tr.movie_percent, tr.setup_no, "
        'wkSQL += vbNewLine + " 	convert(varchar(19), sh.setup_start_date, 111) as setup_start_date, "
        'wkSQL += vbNewLine + " 	convert(varchar(19), sh.setup_end_date, 111) as setup_end_date,"
        'wkSQL += vbNewLine + " 	tr.all_theater_release, tr.all_theater_terminate, "
        'wkSQL += vbNewLine + " 	tr.real_movie_strdate, tr.trailer_movie_strdate, "
        'wkSQL += vbNewLine + " 	case when (tr.all_theater_release = tr.all_theater_terminate) and (tr.real_movie_end_date <  tr.trailer_movie_strdate) then"
        'wkSQL += vbNewLine + " 			  tr.real_movie_end_date"
        'wkSQL += vbNewLine + " 	else"
        'wkSQL += vbNewLine + " 			  tr.trailer_movie_strdate"
        'wkSQL += vbNewLine + " 	end end_date"
        'wkSQL += vbNewLine + " 	from"
        'wkSQL += vbNewLine + " 	("
        'wkSQL += vbNewLine + " 		select trailer.circuit_id, trailer.circuit_name, trailer.real_movie_id, trailer.real_movie_name, trailer.real_movie_strdate,"
        'wkSQL += vbNewLine + " 		trailer.setup_no, trailer.trailer_movie_id, trailer.trailer_movie_name, trailer.trailer_movie_strdate, "
        'wkSQL += vbNewLine + " 		trailer.real_movie_amt, trailer.trailer_amt, "
        'wkSQL += vbNewLine + " 		case when trailer.real_movie_amt > 0 then"
        'wkSQL += vbNewLine + " 			((trailer.trailer_amt * 100.0) / trailer.real_movie_amt) "
        'wkSQL += vbNewLine + " 		else"
        'wkSQL += vbNewLine + " 			0"
        'wkSQL += vbNewLine + " 		end movie_percent,"
        'wkSQL += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_theater"
        'wkSQL += vbNewLine + " 		from tblRelease as r"
        'wkSQL += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQL += vbNewLine + " 		and r.onrelease_status <> 3"
        'wkSQL += vbNewLine + " 		 ) as all_theater_release,"
        'wkSQL += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_terminate"
        'wkSQL += vbNewLine + " 		from tblRelease as r"
        'wkSQL += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQL += vbNewLine + " 		and r.onrelease_status = 2"
        'wkSQL += vbNewLine + " 		) as all_theater_terminate,"
        'wkSQL += vbNewLine + " 		(select max(convert(varchar(19), r.onrelease_enddate, 111)) as end_date"
        'wkSQL += vbNewLine + " 		from tblrelease as r"
        'wkSQL += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQL += vbNewLine + " 		and r.onrelease_status = 2"
        'wkSQL += vbNewLine + " 		) as real_movie_end_date"
        'wkSQL += vbNewLine + " 		from"
        'wkSQL += vbNewLine + " 		("
        'wkSQL += vbNewLine + " 			select cir.circuit_id, cir.circuit_name, mas.real_movie_id, mas.real_movie_name, mas.real_movie_strdate,"
        'wkSQL += vbNewLine + " 			tsd.setup_no, tsd.trailer_movie_id, tsd.trailer_movie_name, tsd.trailer_movie_strdate, "
        'wkSQL += vbNewLine + " 			("
        'wkSQL += vbNewLine + " 			 select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " 			 from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " 			 where(1 = 1)"
        'If (SetupNo.Trim() <> "") Then
        '    wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQL += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        'End If
        'wkSQL += vbNewLine + " 			 and tm3.circuit_id = cir.circuit_id"
        'wkSQL += vbNewLine + "			 and tm3.real_movie_id = " + RealMovieID
        'wkSQL += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 			 ) as real_movie_amt,"
        'wkSQL += vbNewLine + " 			 ("
        'wkSQL += vbNewLine + " 			 select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " 			 from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " 			 where(1 = 1)"
        'If (SetupNo.Trim() <> "") Then
        '    wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQL += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        'End If
        'wkSQL += vbNewLine + " 			 and cd3.movie_id = tsd.trailer_movie_id"
        'wkSQL += vbNewLine + " 			 and tm3.circuit_id= cir.circuit_id"
        'wkSQL += vbNewLine + "			 and tm3.real_movie_id = " + RealMovieID
        'wkSQL += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 			) as trailer_amt"
        'wkSQL += vbNewLine + " 			from tblCircuit cir, "
        'wkSQL += vbNewLine + " 			("
        'wkSQL += vbNewLine + " 			select distinct tm.real_movie_id, m.movie_nameen as real_movie_name, "
        'wkSQL += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as real_movie_strdate"
        'wkSQL += vbNewLine + " 			from tblTrailer_Master tm"
        'wkSQL += vbNewLine + " 			left join tblMovie m on tm.real_movie_id = m.movie_id"
        'wkSQL += vbNewLine + " 			left join tblCircuit c on tm.circuit_id = c.circuit_id"
        'wkSQL += vbNewLine + " 			where tm.real_movie_id = " + RealMovieID
        'wkSQL += vbNewLine + " 			and tm.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 			) mas,"
        'wkSQL += vbNewLine + " 			("
        'wkSQL += vbNewLine + " 			select sd.movie_id as trailer_movie_id, (m.movie_nameen ) as trailer_movie_name, "
        'wkSQL += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as trailer_movie_strdate, sd.setup_no"
        'wkSQL += vbNewLine + " 			from tblTrailer_Setup_Dtl sd "
        'wkSQL += vbNewLine + " 			left join tblMovie m on sd.movie_id = m.movie_id"
        'wkSQL += vbNewLine + " 			) tsd"
        'wkSQL += vbNewLine + " 		) trailer"
        'wkSQL += vbNewLine + " 	) tr"
        'wkSQL += vbNewLine + " 	left join tblTrailer_Setup_Hdr sh on tr.setup_no = sh.setup_no "
        'wkSQL += vbNewLine + " 	where 1=1"
        'If (TrailerMovieID.Trim() <> "0" And SetupNo.Trim() = "") Then
        '    wkSQL += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        'ElseIf SetupNo.Trim() <> "" And TrailerMovieID.Trim() = "0" Then
        '    wkSQL += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQL += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        '    wkSQL += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        'End If
        'wkSQL += vbNewLine + " ) a"
        'wkSQL += vbNewLine + " where (a.setup_start_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        'wkSQL += vbNewLine + " or (a.setup_end_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        'wkSQL += vbNewLine + " order by a.circuit_name, a.setup_no, a.real_movie_id, a.trailer_movie_strdate, a.trailer_movie_id"

        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQL = vbNewLine + " select a.circuit_id, a.circuit_name, a.real_movie_id, a.real_movie_name, "
        wkSQL += vbNewLine + " a.trailer_movie_id, a.trailer_movie_name, a.real_movie_amt, a.trailer_amt, a.movie_percent, a.setup_no, "
        wkSQL += vbNewLine + " a.setup_start_date, a.setup_end_date, a.all_theater_release, a.all_theater_terminate, "
        wkSQL += vbNewLine + " a.real_movie_strdate, a.trailer_movie_strdate, a.end_date"
        wkSQL += vbNewLine + " from"
        wkSQL += vbNewLine + " ("
        wkSQL += vbNewLine + " select tr.circuit_id, tr.circuit_name, tr.real_movie_id, tr.real_movie_name, "
        wkSQL += vbNewLine + " tr.trailer_movie_id, tr.trailer_movie_name, tr.real_movie_amt, tr.trailer_amt, tr.movie_percent, tr.setup_no, "
        wkSQL += vbNewLine + " convert(varchar(19), sh.setup_start_date, 111) as setup_start_date, "
        wkSQL += vbNewLine + " convert(varchar(19), sh.setup_end_date, 111) as setup_end_date,"
        wkSQL += vbNewLine + " tr.all_theater_release, tr.all_theater_terminate, "
        wkSQL += vbNewLine + " tr.real_movie_strdate, tr.trailer_movie_strdate, "
        wkSQL += vbNewLine + " case when (tr.all_theater_release = tr.all_theater_terminate) and (tr.real_movie_end_date <  tr.trailer_movie_strdate) then"
        wkSQL += vbNewLine + " 		  tr.real_movie_end_date"
        wkSQL += vbNewLine + " else"
        wkSQL += vbNewLine + " 		  tr.trailer_movie_strdate"
        wkSQL += vbNewLine + " end end_date"
        wkSQL += vbNewLine + " from"
        wkSQL += vbNewLine + " ("
        wkSQL += vbNewLine + " 	select trailer.circuit_id, trailer.circuit_name, trailer.real_movie_id, trailer.real_movie_name, trailer.real_movie_strdate,"
        wkSQL += vbNewLine + " 	trailer.setup_no, trailer.trailer_movie_id, trailer.trailer_movie_name, trailer.trailer_movie_strdate, "
        wkSQL += vbNewLine + " 	trailer.real_movie_amt, trailer.trailer_amt, "
        wkSQL += vbNewLine + " 	case when trailer.real_movie_amt > 0 then"
        wkSQL += vbNewLine + " 		((trailer.trailer_amt * 100.0) / trailer.real_movie_amt) "
        wkSQL += vbNewLine + " 	else"
        wkSQL += vbNewLine + " 		0"
        wkSQL += vbNewLine + " 	end movie_percent,"
        wkSQL += vbNewLine + " 	(select count(distinct r.theater_id) as cnt_all_theater"
        wkSQL += vbNewLine + " 	from tblRelease as r"
        wkSQL += vbNewLine + " 	where r.movies_id = trailer.real_movie_id"
        wkSQL += vbNewLine + " 	and r.onrelease_status <> 3"
        wkSQL += vbNewLine + " 	 ) as all_theater_release,"
        wkSQL += vbNewLine + " 	(select count(distinct r.theater_id) as cnt_all_terminate"
        wkSQL += vbNewLine + " 	from tblRelease as r"
        wkSQL += vbNewLine + " 	where r.movies_id = trailer.real_movie_id"
        wkSQL += vbNewLine + " 	and r.onrelease_status = 2"
        wkSQL += vbNewLine + " 	) as all_theater_terminate,"
        wkSQL += vbNewLine + " 	(select max(convert(varchar(19), r.onrelease_enddate, 111)) as end_date"
        wkSQL += vbNewLine + " 	from tblrelease as r"
        wkSQL += vbNewLine + " 	where r.movies_id = trailer.real_movie_id"
        wkSQL += vbNewLine + " 	and r.onrelease_status = 2"
        wkSQL += vbNewLine + " 	) as real_movie_end_date"
        wkSQL += vbNewLine + " 	from"
        wkSQL += vbNewLine + " 	("
        wkSQL += vbNewLine + " 		select cir.circuit_id, cir.circuit_name, mas.real_movie_id, mas.real_movie_name, mas.real_movie_strdate,"
        wkSQL += vbNewLine + " 		tsd.setup_no, tsd.trailer_movie_id, tsd.trailer_movie_name, tsd.trailer_movie_strdate, "
        wkSQL += vbNewLine + " 		("
        wkSQL += vbNewLine + " 		 select count (distinct(convert(varchar(200), tm3.theater_id)+'_'+convert(varchar(200), tm3.theatersub_id)))"
        wkSQL += vbNewLine + " 		 from tblTrailer_Master tm3 "
        wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQL += vbNewLine + " 		 left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 		 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 		 where 1=1 "
        'wkSQL += vbNewLine + " 		 and t.theater_status = 'Enabled'"

        If (SetupNo.Trim() <> "") Then
            wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        Else
            wkSQL += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        End If

        wkSQL += vbNewLine + " 		 and t.circuit_id = cir.circuit_id"
        wkSQL += vbNewLine + " 		 and tm3.real_movie_id = " + RealMovieID
        wkSQL += vbNewLine + " 		 and tm3.confirm_flag = 'Y'"
        wkSQL += vbNewLine + " 		 ) as real_movie_amt,"
        wkSQL += vbNewLine + " 		 ("
        wkSQL += vbNewLine + " 		 select count (distinct(convert(varchar(200), tm3.theater_id)+'_'+convert(varchar(200), tm3.theatersub_id)))"
        wkSQL += vbNewLine + " 		 from tblTrailer_Master tm3 "
        wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQL += vbNewLine + " 		 left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 		 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 		 where 1=1 "
        'wkSQL += vbNewLine + " 		 and t.theater_status = 'Enabled'"

        If (SetupNo.Trim() <> "") Then
            wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        Else
            wkSQL += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        End If

        wkSQL += vbNewLine + " 		 and cd3.movie_id = tsd.trailer_movie_id"
        wkSQL += vbNewLine + " 		 and t.circuit_id= cir.circuit_id"
        wkSQL += vbNewLine + " 		 and tm3.real_movie_id = " + RealMovieID
        wkSQL += vbNewLine + " 		 and tm3.confirm_flag = 'Y'"
        wkSQL += vbNewLine + " 		) as trailer_amt"
        wkSQL += vbNewLine + " 		from tblCircuit cir, "
        wkSQL += vbNewLine + " 		("
        wkSQL += vbNewLine + " 		select distinct tm.real_movie_id, m.movie_nameen as real_movie_name, "
        wkSQL += vbNewLine + " 		convert(varchar(19), m.movie_strdate, 111) as real_movie_strdate"
        wkSQL += vbNewLine + " 		from tblTrailer_Master tm"
        wkSQL += vbNewLine + " 		left join tblMovie m on tm.real_movie_id = m.movie_id"
        wkSQL += vbNewLine + " 		left join tblTheater t on tm.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 		left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 		where tm.real_movie_id = " + RealMovieID
        wkSQL += vbNewLine + " 		and tm.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 		and t.theater_status = 'Enabled'"
        wkSQL += vbNewLine + " 		) mas,"
        wkSQL += vbNewLine + " 		("
        wkSQL += vbNewLine + " 		select sd.movie_id as trailer_movie_id, (m.movie_nameen ) as trailer_movie_name, "
        wkSQL += vbNewLine + " 		convert(varchar(19), m.movie_strdate, 111) as trailer_movie_strdate, sd.setup_no"
        wkSQL += vbNewLine + " 		from tblTrailer_Setup_Dtl sd "
        wkSQL += vbNewLine + " 		left join tblMovie m on sd.movie_id = m.movie_id"
        wkSQL += vbNewLine + " 		) tsd"
        wkSQL += vbNewLine + " 	) trailer"
        wkSQL += vbNewLine + " ) tr"
        wkSQL += vbNewLine + " left join tblTrailer_Setup_Hdr sh on tr.setup_no = sh.setup_no "
        wkSQL += vbNewLine + " where 1=1"

        If (TrailerMovieID.Trim() <> "0" And SetupNo.Trim() = "") Then
            wkSQL += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        ElseIf SetupNo.Trim() <> "" And TrailerMovieID.Trim() = "0" Then
            wkSQL += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        Else
            wkSQL += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
            wkSQL += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        End If

        wkSQL += vbNewLine + " ) a"
        wkSQL += vbNewLine + " where (a.setup_start_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        wkSQL += vbNewLine + " or (a.setup_end_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        wkSQL += vbNewLine + " order by a.circuit_name, a.setup_no, a.real_movie_id, a.trailer_movie_strdate, a.trailer_movie_id"
        '--- End by Muay 2010-06-09 --------------------------------------------


        Dim dr As IDataReader = cDB.GetDataAll(wkSQL)
        Dim checkRow As Integer = 1
        Dim wkCircuitID As String = ""

        Dim sumReal As Decimal = 0
        Dim sumTrailer As Decimal = 0
        Dim SumPercent As Decimal = 0

        Dim strCircuit As String = ""

        Dim aylSumTrailer As New ArrayList()
        Dim hasSumTrailer As New Hashtable()

        While (dr.Read())

            Dim detailsRow As New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 12

            If (strCircuit = "" Or strCircuit <> dr("circuit_name").ToString()) Then
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                detailsRow.Cells(0).Text = dr("circuit_name").ToString()
                detailsRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                detailsRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(0).Height = 25
                detailsRow.Cells(0).ColumnSpan = 3
                tbl.Rows.Add(detailsRow)

                strCircuit = dr("circuit_name").ToString()
                sumReal = sumReal + Convert.ToDecimal(dr("real_movie_amt"))
            End If

            detailsRow = New TableRow()
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).Font.Bold = True
            detailsRow.Cells(0).ColumnSpan = 1
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Size = 10
            detailsRow.Height = 25
            If (SetupNo.Trim() <> "") Then
                detailsRow.Visible = False
            Else
                detailsRow.Cells(1).Text = "<b>" + Convert.ToDateTime(dr("setup_start_date")).ToString("dd/MM/yyyy") + " - " + Convert.ToDateTime(dr("setup_end_date")).ToString("dd/MM/yyyy") + "</b>"
                detailsRow.Visible = True
            End If
            detailsRow.Cells(1).ColumnSpan = 1
            detailsRow.Cells(1).Width = 200
            tbl.Rows.Add(detailsRow)
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).Font.Bold = True
            detailsRow.Cells(2).ColumnSpan = 1
            detailsRow.Cells(2).Width = 160

            detailsRow.Cells(0).BackColor = Color.FromName("#D8ECF4")
            detailsRow.Cells(1).BackColor = Color.FromName("#D8ECF4")
            detailsRow.Cells(2).BackColor = Color.FromName("#D8ECF4")

            tbl.Rows.Add(detailsRow)

            Dim detailsRow2 As New TableRow()
            detailsRow2.HorizontalAlign = HorizontalAlign.Center
            detailsRow2.Font.Name = "Tahoma"
            detailsRow2.Font.Size = 11

            detailsRow2.Cells.Add(New TableCell)
            detailsRow2.Cells(0).HorizontalAlign = HorizontalAlign.Right
            detailsRow2.Cells(0).Text = RealName & " ฉาย"
            detailsRow2.Cells(0).ForeColor = Color.FromName("#111CB2")

            detailsRow2.Cells.Add(New TableCell)
            detailsRow2.Cells(1).Width = 200
            detailsRow2.Cells(1).HorizontalAlign = HorizontalAlign.Center
            detailsRow2.Cells(1).Text = CDbl(dr("real_movie_amt")).ToString("#,##0")
            'sumReal = sumReal + Convert.ToDecimal(dr("real_movie_amt"))

            detailsRow2.Cells.Add(New TableCell)
            detailsRow2.Cells(2).Width = 160
            detailsRow2.Cells(2).HorizontalAlign = HorizontalAlign.Left
            detailsRow2.Cells(2).Text = "จอ"
            tbl.Rows.Add(detailsRow2)



            Dim detailsRow3 As New TableRow()
            detailsRow3.HorizontalAlign = HorizontalAlign.Center
            detailsRow3.Font.Name = "Tahoma"
            detailsRow3.Font.Size = 11

            detailsRow3.Cells.Add(New TableCell)
            detailsRow3.Cells(0).HorizontalAlign = HorizontalAlign.Right

            detailsRow3.Cells(0).Text = "มี ต.ย. " & CStr(dr("trailer_movie_name"))

            'เช็คผล sum ของหนังตัวอย่าง
            If (hasSumTrailer(CStr(dr("trailer_movie_name"))) Is Nothing) Then
                aylSumTrailer.Add(CStr(dr("trailer_movie_name")))
                hasSumTrailer(CStr(dr("trailer_movie_name"))) = CDbl(dr("trailer_amt"))
            Else
                hasSumTrailer(CStr(dr("trailer_movie_name"))) = Convert.ToDecimal(hasSumTrailer(CStr(dr("trailer_movie_name")))) + CDbl(dr("trailer_amt"))
            End If

            detailsRow3.Cells.Add(New TableCell)
            detailsRow3.Cells(1).Width = 200
            detailsRow3.Cells(1).HorizontalAlign = HorizontalAlign.Center
            strShow = CDbl(dr("trailer_amt")).ToString("#,##0")
            detailsRow3.Cells(1).Text = strShow
            detailsRow3.Cells(1).CssClass = "under1"
            sumTrailer = sumTrailer + CDbl(dr("trailer_amt"))

            detailsRow3.Cells.Add(New TableCell)
            detailsRow3.Cells(2).Width = 160
            detailsRow3.Cells(2).HorizontalAlign = HorizontalAlign.Left
            detailsRow3.Cells(2).Text = "จอ"
            tbl.Rows.Add(detailsRow3)


            Dim detailsRow4 As New TableRow()
            detailsRow4.HorizontalAlign = HorizontalAlign.Center
            detailsRow4.Font.Name = "Tahoma"
            detailsRow4.Font.Size = 11

            detailsRow4.Cells.Add(New TableCell)
            detailsRow4.Cells(0).HorizontalAlign = HorizontalAlign.Right
            detailsRow4.Cells(0).Text = "คิดเป็น"

            detailsRow4.Cells.Add(New TableCell)
            detailsRow4.Cells(1).Width = 200
            detailsRow4.Cells(1).HorizontalAlign = HorizontalAlign.Center
            strShow = Convert.ToDecimal(dr("movie_percent")).ToString("#,##0.0") & " %"
            detailsRow4.Cells(1).Text = strShow
            detailsRow4.Cells(1).CssClass = "under2"
            detailsRow4.Cells(1).Font.Bold = True
            detailsRow4.Cells(1).ForeColor = Color.Red
            SumPercent = SumPercent + Convert.ToDecimal(dr("movie_percent"))

            detailsRow4.Cells.Add(New TableCell)
            detailsRow4.Cells(2).Width = 160
            detailsRow4.Cells(2).HorizontalAlign = HorizontalAlign.Center
            detailsRow4.Cells(2).Text = ""
            tbl.Rows.Add(detailsRow4)


            Dim detailsRow5 As New TableRow()
            detailsRow5.HorizontalAlign = HorizontalAlign.Center
            detailsRow5.Font.Name = "Tahoma"
            detailsRow5.Font.Size = 11
            detailsRow5.Cells.Add(New TableCell)
            detailsRow5.Cells(0).HorizontalAlign = HorizontalAlign.Left
            detailsRow5.Cells(0).Text = ""
            detailsRow5.Cells(0).Height = 13
            detailsRow5.Cells(0).ColumnSpan = 3
            tbl.Rows.Add(detailsRow5)


        End While
        dr.Close()


        ''''total

        Dim TotaldetailsRow As New TableRow()
        TotaldetailsRow.HorizontalAlign = HorizontalAlign.Center
        TotaldetailsRow.Font.Name = "Tahoma"
        TotaldetailsRow.Font.Size = 11
        TotaldetailsRow.Font.Bold = True
        TotaldetailsRow.Cells.Add(New TableCell)
        TotaldetailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
        TotaldetailsRow.Cells(0).Text = "TOTAL"
        TotaldetailsRow.Cells(0).ColumnSpan = 3
        TotaldetailsRow.Cells(0).Height = 25
        TotaldetailsRow.Cells(0).BackColor = Color.FromName("#C2D8FE")
        TotaldetailsRow.Cells(0).ForeColor = Color.FromName("#000000")
        tbl.Rows.Add(TotaldetailsRow)

        Dim wkSQLcount As String

        'wkSQLcount = "select count(distinct setup_no) as countSetupNo from ( "
        'wkSQLcount += vbNewLine + " select a.circuit_id, a.circuit_name, a.real_movie_id, a.real_movie_name, "
        'wkSQLcount += vbNewLine + " a.trailer_movie_id, a.trailer_movie_name, a.real_movie_amt, a.trailer_amt, a.movie_percent, a.setup_no, "
        'wkSQLcount += vbNewLine + " a.setup_start_date, a.setup_end_date, a.all_theater_release, a.all_theater_terminate, "
        'wkSQLcount += vbNewLine + " a.real_movie_strdate, a.trailer_movie_strdate, a.end_date"
        'wkSQLcount += vbNewLine + " from"
        'wkSQLcount += vbNewLine + " ("
        'wkSQLcount += vbNewLine + " 	select tr.circuit_id, tr.circuit_name, tr.real_movie_id, tr.real_movie_name, "
        'wkSQLcount += vbNewLine + " 	tr.trailer_movie_id, tr.trailer_movie_name, tr.real_movie_amt, tr.trailer_amt, tr.movie_percent, tr.setup_no, "
        'wkSQLcount += vbNewLine + " 	convert(varchar(19), sh.setup_start_date, 111) as setup_start_date, "
        'wkSQLcount += vbNewLine + " 	convert(varchar(19), sh.setup_end_date, 111) as setup_end_date,"
        'wkSQLcount += vbNewLine + " 	tr.all_theater_release, tr.all_theater_terminate, "
        'wkSQLcount += vbNewLine + " 	tr.real_movie_strdate, tr.trailer_movie_strdate, "
        'wkSQLcount += vbNewLine + " 	case when (tr.all_theater_release = tr.all_theater_terminate) and (tr.real_movie_end_date <  tr.trailer_movie_strdate) then"
        'wkSQLcount += vbNewLine + " 			  tr.real_movie_end_date"
        'wkSQLcount += vbNewLine + " 	else"
        'wkSQLcount += vbNewLine + " 			  tr.trailer_movie_strdate"
        'wkSQLcount += vbNewLine + " 	end end_date"
        'wkSQLcount += vbNewLine + " 	from"
        'wkSQLcount += vbNewLine + " 	("
        'wkSQLcount += vbNewLine + " 		select trailer.circuit_id, trailer.circuit_name, trailer.real_movie_id, trailer.real_movie_name, trailer.real_movie_strdate,"
        'wkSQLcount += vbNewLine + " 		trailer.setup_no, trailer.trailer_movie_id, trailer.trailer_movie_name, trailer.trailer_movie_strdate, "
        'wkSQLcount += vbNewLine + " 		trailer.real_movie_amt, trailer.trailer_amt, "
        'wkSQLcount += vbNewLine + " 		case when trailer.real_movie_amt > 0 then"
        'wkSQLcount += vbNewLine + " 			((trailer.trailer_amt * 100.0) / trailer.real_movie_amt) "
        'wkSQLcount += vbNewLine + " 		else"
        'wkSQLcount += vbNewLine + " 			0"
        'wkSQLcount += vbNewLine + " 		end movie_percent,"
        'wkSQLcount += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_theater"
        'wkSQLcount += vbNewLine + " 		from tblRelease as r"
        'wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQLcount += vbNewLine + " 		and r.onrelease_status <> 3"
        'wkSQLcount += vbNewLine + " 		 ) as all_theater_release,"
        'wkSQLcount += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_terminate"
        'wkSQLcount += vbNewLine + " 		from tblRelease as r"
        'wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQLcount += vbNewLine + " 		and r.onrelease_status = 2"
        'wkSQLcount += vbNewLine + " 		) as all_theater_terminate,"
        'wkSQLcount += vbNewLine + " 		(select max(convert(varchar(19), r.onrelease_enddate, 111)) as end_date"
        'wkSQLcount += vbNewLine + " 		from tblrelease as r"
        'wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        'wkSQLcount += vbNewLine + " 		and r.onrelease_status = 2"
        'wkSQLcount += vbNewLine + " 		) as real_movie_end_date"
        'wkSQLcount += vbNewLine + " 		from"
        'wkSQLcount += vbNewLine + " 		("
        'wkSQLcount += vbNewLine + " 			select cir.circuit_id, cir.circuit_name, mas.real_movie_id, mas.real_movie_name, mas.real_movie_strdate,"
        'wkSQLcount += vbNewLine + " 			tsd.setup_no, tsd.trailer_movie_id, tsd.trailer_movie_name, tsd.trailer_movie_strdate, "
        'wkSQLcount += vbNewLine + " 			("
        'wkSQLcount += vbNewLine + " 			 select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQLcount += vbNewLine + " 			 from tbltrailer_master tm3 "
        'wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQLcount += vbNewLine + " 			 where(1 = 1)"
        'If (SetupNo.Trim() <> "") Then
        '    wkSQLcount += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQLcount += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        'End If
        'wkSQLcount += vbNewLine + " 			 and tm3.circuit_id = cir.circuit_id"
        'wkSQLcount += vbNewLine + "			 and tm3.real_movie_id = " + RealMovieID
        'wkSQLcount += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        'wkSQLcount += vbNewLine + " 			 ) as real_movie_amt,"
        'wkSQLcount += vbNewLine + " 			 ("
        'wkSQLcount += vbNewLine + " 			 select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQLcount += vbNewLine + " 			 from tbltrailer_master tm3 "
        'wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQLcount += vbNewLine + " 			 where(1 = 1)"
        'If (SetupNo.Trim() <> "") Then
        '    wkSQLcount += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQLcount += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        'End If
        'wkSQLcount += vbNewLine + " 			 and cd3.movie_id = tsd.trailer_movie_id"
        'wkSQLcount += vbNewLine + " 			 and tm3.circuit_id= cir.circuit_id"
        'wkSQLcount += vbNewLine + "			 and tm3.real_movie_id = " + RealMovieID
        'wkSQLcount += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        'wkSQLcount += vbNewLine + " 			) as trailer_amt"
        'wkSQLcount += vbNewLine + " 			from tblCircuit cir, "
        'wkSQLcount += vbNewLine + " 			("
        'wkSQLcount += vbNewLine + " 			select distinct tm.real_movie_id, m.movie_nameen as real_movie_name, "
        'wkSQLcount += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as real_movie_strdate"
        'wkSQLcount += vbNewLine + " 			from tblTrailer_Master tm"
        'wkSQLcount += vbNewLine + " 			left join tblMovie m on tm.real_movie_id = m.movie_id"
        'wkSQLcount += vbNewLine + " 			left join tblCircuit c on tm.circuit_id = c.circuit_id"
        'wkSQLcount += vbNewLine + " 			where tm.real_movie_id = " + RealMovieID
        'wkSQLcount += vbNewLine + " 			and tm.confirm_flag = 'Y'"
        'wkSQLcount += vbNewLine + " 			) mas,"
        'wkSQLcount += vbNewLine + " 			("
        'wkSQLcount += vbNewLine + " 			select sd.movie_id as trailer_movie_id, (m.movie_nameen ) as trailer_movie_name, "
        'wkSQLcount += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as trailer_movie_strdate, sd.setup_no"
        'wkSQLcount += vbNewLine + " 			from tblTrailer_Setup_Dtl sd "
        'wkSQLcount += vbNewLine + " 			left join tblMovie m on sd.movie_id = m.movie_id"
        'wkSQLcount += vbNewLine + " 			) tsd"
        'wkSQLcount += vbNewLine + " 		) trailer"
        'wkSQLcount += vbNewLine + " 	) tr"
        'wkSQLcount += vbNewLine + " 	left join tblTrailer_Setup_Hdr sh on tr.setup_no = sh.setup_no "
        'wkSQLcount += vbNewLine + " 	where 1=1"
        'If (TrailerMovieID.Trim() <> "0" And SetupNo.Trim() = "") Then
        '    wkSQLcount += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        'ElseIf SetupNo.Trim() <> "" And TrailerMovieID.Trim() = "0" Then
        '    wkSQLcount += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        'Else
        '    wkSQLcount += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        '    wkSQLcount += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        'End If
        'wkSQLcount += vbNewLine + " ) a"
        'wkSQLcount += vbNewLine + " where (a.setup_start_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        'wkSQLcount += vbNewLine + " or (a.setup_end_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        ''wkSQLcount += vbNewLine + " order by a.circuit_name, a.setup_no, a.real_movie_id, a.trailer_movie_strdate, a.trailer_movie_id"
        'wkSQLcount += vbNewLine + " ) as tblCountSetupNo"


        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQLcount = " select count(distinct setup_no) as countSetupNo "
        wkSQLcount += vbNewLine + " from "
        wkSQLcount += vbNewLine + " ( "
        wkSQLcount += vbNewLine + " 	select a.circuit_id, a.circuit_name, a.real_movie_id, a.real_movie_name, "
        wkSQLcount += vbNewLine + " 	a.trailer_movie_id, a.trailer_movie_name, a.real_movie_amt, a.trailer_amt, a.movie_percent, a.setup_no, "
        wkSQLcount += vbNewLine + " 	a.setup_start_date, a.setup_end_date, a.all_theater_release, a.all_theater_terminate, "
        wkSQLcount += vbNewLine + " 	a.real_movie_strdate, a.trailer_movie_strdate, a.end_date"
        wkSQLcount += vbNewLine + " 	from"
        wkSQLcount += vbNewLine + " 	("
        wkSQLcount += vbNewLine + " 	select tr.circuit_id, tr.circuit_name, tr.real_movie_id, tr.real_movie_name, "
        wkSQLcount += vbNewLine + " 	tr.trailer_movie_id, tr.trailer_movie_name, tr.real_movie_amt, tr.trailer_amt, tr.movie_percent, tr.setup_no, "
        wkSQLcount += vbNewLine + " 	convert(varchar(19), sh.setup_start_date, 111) as setup_start_date, "
        wkSQLcount += vbNewLine + " 	convert(varchar(19), sh.setup_end_date, 111) as setup_end_date,"
        wkSQLcount += vbNewLine + " 	tr.all_theater_release, tr.all_theater_terminate, "
        wkSQLcount += vbNewLine + " 	tr.real_movie_strdate, tr.trailer_movie_strdate, "
        wkSQLcount += vbNewLine + " 	case when (tr.all_theater_release = tr.all_theater_terminate) and (tr.real_movie_end_date <  tr.trailer_movie_strdate) then"
        wkSQLcount += vbNewLine + " 			  tr.real_movie_end_date"
        wkSQLcount += vbNewLine + " 	else"
        wkSQLcount += vbNewLine + " 			  tr.trailer_movie_strdate"
        wkSQLcount += vbNewLine + " 	end end_date"
        wkSQLcount += vbNewLine + " 	from"
        wkSQLcount += vbNewLine + " 	("
        wkSQLcount += vbNewLine + " 		select trailer.circuit_id, trailer.circuit_name, trailer.real_movie_id, trailer.real_movie_name, trailer.real_movie_strdate,"
        wkSQLcount += vbNewLine + " 		trailer.setup_no, trailer.trailer_movie_id, trailer.trailer_movie_name, trailer.trailer_movie_strdate, "
        wkSQLcount += vbNewLine + " 		trailer.real_movie_amt, trailer.trailer_amt, "
        wkSQLcount += vbNewLine + " 		case when trailer.real_movie_amt > 0 then"
        wkSQLcount += vbNewLine + " 			((trailer.trailer_amt * 100.0) / trailer.real_movie_amt) "
        wkSQLcount += vbNewLine + " 		else"
        wkSQLcount += vbNewLine + " 			0"
        wkSQLcount += vbNewLine + " 		end movie_percent,"
        wkSQLcount += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_theater"
        wkSQLcount += vbNewLine + " 		from tblRelease as r"
        wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        wkSQLcount += vbNewLine + " 		and r.onrelease_status <> 3"
        wkSQLcount += vbNewLine + " 		 ) as all_theater_release,"
        wkSQLcount += vbNewLine + " 		(select count(distinct r.theater_id) as cnt_all_terminate"
        wkSQLcount += vbNewLine + " 		from tblRelease as r"
        wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        wkSQLcount += vbNewLine + " 		and r.onrelease_status = 2"
        wkSQLcount += vbNewLine + " 		) as all_theater_terminate,"
        wkSQLcount += vbNewLine + " 		(select max(convert(varchar(19), r.onrelease_enddate, 111)) as end_date"
        wkSQLcount += vbNewLine + " 		from tblrelease as r"
        wkSQLcount += vbNewLine + " 		where r.movies_id = trailer.real_movie_id"
        wkSQLcount += vbNewLine + " 		and r.onrelease_status = 2"
        wkSQLcount += vbNewLine + " 		) as real_movie_end_date"
        wkSQLcount += vbNewLine + " 		from"
        wkSQLcount += vbNewLine + " 		("
        wkSQLcount += vbNewLine + " 			select cir.circuit_id, cir.circuit_name, mas.real_movie_id, mas.real_movie_name, mas.real_movie_strdate,"
        wkSQLcount += vbNewLine + " 			tsd.setup_no, tsd.trailer_movie_id, tsd.trailer_movie_name, tsd.trailer_movie_strdate, "
        wkSQLcount += vbNewLine + " 			("
        wkSQLcount += vbNewLine + " 			 select count (distinct(convert(varchar(200), tm3.theater_id)+'_'+convert(varchar(200), tm3.theatersub_id)))"
        wkSQLcount += vbNewLine + " 			 from tblTrailer_Master tm3 "
        wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQLcount += vbNewLine + " 			 left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQLcount += vbNewLine + " 			 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQLcount += vbNewLine + " 			 where 1=1"
        'wkSQLcount += vbNewLine + " 			 and t.theater_status = 'Enabled'"

        If (SetupNo.Trim() <> "") Then
            wkSQLcount += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        Else
            wkSQLcount += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        End If

        wkSQLcount += vbNewLine + " 			 and t.circuit_id = cir.circuit_id"
        wkSQLcount += vbNewLine + " 			 and tm3.real_movie_id = " + RealMovieID
        wkSQLcount += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        wkSQLcount += vbNewLine + " 			 ) as real_movie_amt,"
        wkSQLcount += vbNewLine + " 			 ("
        wkSQLcount += vbNewLine + " 			 select count (distinct(convert(varchar(200), tm3.theater_id)+'_'+convert(varchar(200), tm3.theatersub_id)))"
        wkSQLcount += vbNewLine + " 			 from tblTrailer_Master tm3 "
        wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQLcount += vbNewLine + " 			 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQLcount += vbNewLine + " 			 left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQLcount += vbNewLine + " 			 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQLcount += vbNewLine + " 			 where 1=1 "
        'wkSQLcount += vbNewLine + " 			 where t.theater_status = 'Enabled'"

        If (SetupNo.Trim() <> "") Then
            wkSQLcount += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        Else
            wkSQLcount += vbNewLine + " and cd3.ref_setup_no = tsd.setup_no"
        End If

        wkSQLcount += vbNewLine + " 			 and cd3.movie_id = tsd.trailer_movie_id"
        wkSQLcount += vbNewLine + " 			 and t.circuit_id= cir.circuit_id"
        wkSQLcount += vbNewLine + " 			 and tm3.real_movie_id = " + RealMovieID
        wkSQLcount += vbNewLine + " 			 and tm3.confirm_flag = 'Y'"
        wkSQLcount += vbNewLine + " 			) as trailer_amt"
        wkSQLcount += vbNewLine + " 			from tblCircuit cir, "
        wkSQLcount += vbNewLine + " 			("
        wkSQLcount += vbNewLine + " 			select distinct tm.real_movie_id, m.movie_nameen as real_movie_name, "
        wkSQLcount += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as real_movie_strdate"
        wkSQLcount += vbNewLine + " 			from tblTrailer_Master tm"
        wkSQLcount += vbNewLine + " 			left join tblMovie m on tm.real_movie_id = m.movie_id"
        wkSQLcount += vbNewLine + " 			left join tblTheater t on tm.theater_id = t.theater_id"
        wkSQLcount += vbNewLine + " 			left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQLcount += vbNewLine + " 			where tm.real_movie_id = " + RealMovieID
        wkSQLcount += vbNewLine + " 			and tm.confirm_flag = 'Y'"
        'wkSQLcount += vbNewLine + " 			and t.theater_status = 'Enabled'"
        wkSQLcount += vbNewLine + " 			) mas,"
        wkSQLcount += vbNewLine + " 			("
        wkSQLcount += vbNewLine + " 			select sd.movie_id as trailer_movie_id, (m.movie_nameen ) as trailer_movie_name, "
        wkSQLcount += vbNewLine + " 			convert(varchar(19), m.movie_strdate, 111) as trailer_movie_strdate, sd.setup_no"
        wkSQLcount += vbNewLine + " 			from tblTrailer_Setup_Dtl sd "
        wkSQLcount += vbNewLine + " 			left join tblMovie m on sd.movie_id = m.movie_id"
        wkSQLcount += vbNewLine + " 			) tsd"
        wkSQLcount += vbNewLine + " 		) trailer"
        wkSQLcount += vbNewLine + " 	) tr"
        wkSQLcount += vbNewLine + " 	left join tblTrailer_Setup_Hdr sh on tr.setup_no = sh.setup_no "
        wkSQLcount += vbNewLine + " 	where 1=1"

        If (TrailerMovieID.Trim() <> "0" And SetupNo.Trim() = "") Then
            wkSQLcount += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        ElseIf SetupNo.Trim() <> "" And TrailerMovieID.Trim() = "0" Then
            wkSQLcount += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
        Else
            wkSQLcount += vbNewLine + " and tr.setup_no = '" + SetupNo + "'"
            wkSQLcount += vbNewLine + " and tr.trailer_movie_id = " + TrailerMovieID
        End If

        wkSQLcount += vbNewLine + " 	) a"
        wkSQLcount += vbNewLine + " 	where (a.setup_start_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        wkSQLcount += vbNewLine + " 	or (a.setup_end_date >= a.real_movie_strdate and a.setup_start_date <= a.end_date)"
        wkSQLcount += vbNewLine + " ) as tblCountSetupNo"
        '--- End by Muay 2010-06-09 --------------------------------------------


        Dim drCount As IDataReader = cDB.GetDataAll(wkSQLcount)
        If drCount.Read() Then
            Dim TotaldetailsRow1 As New TableRow()
            TotaldetailsRow1.HorizontalAlign = HorizontalAlign.Center
            TotaldetailsRow1.Font.Name = "Tahoma"
            TotaldetailsRow1.Font.Size = 11

            TotaldetailsRow1.Cells.Add(New TableCell)
            TotaldetailsRow1.Cells(0).HorizontalAlign = HorizontalAlign.Right
            TotaldetailsRow1.Cells(0).Text = "จากจำนวนการฉายทั้งสิ้น"
            TotaldetailsRow1.Cells(0).ForeColor = Color.Black
            TotaldetailsRow1.Cells(0).BackColor = Color.FromName("#DBE5FF")
            TotaldetailsRow1.Cells(0).Font.Bold = True

            TotaldetailsRow1.Cells.Add(New TableCell)
            TotaldetailsRow1.Cells(1).Width = 200
            TotaldetailsRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
            TotaldetailsRow1.Cells(1).Text = drCount("countSetupNo")
            TotaldetailsRow1.Cells(1).BackColor = Color.FromName("#DBE5FF")
            TotaldetailsRow1.Cells(1).ForeColor = Color.Black
            TotaldetailsRow1.Cells(1).Font.Bold = True

            TotaldetailsRow1.Cells.Add(New TableCell)
            TotaldetailsRow1.Cells(2).Width = 160
            TotaldetailsRow1.Cells(2).HorizontalAlign = HorizontalAlign.Left
            TotaldetailsRow1.Cells(2).Text = "สัปดาห์ "
            TotaldetailsRow1.Cells(2).BackColor = Color.FromName("#DBE5FF")
            TotaldetailsRow1.Cells(2).ForeColor = Color.Black
            TotaldetailsRow1.Cells(2).Font.Bold = True
            tbl.Rows.Add(TotaldetailsRow1)
            dr.Close()
        End If

        Dim TotaldetailsRow2 As New TableRow()
        TotaldetailsRow2.HorizontalAlign = HorizontalAlign.Center
        TotaldetailsRow2.Font.Name = "Tahoma"
        TotaldetailsRow2.Font.Size = 11

        TotaldetailsRow2.Cells.Add(New TableCell)
        TotaldetailsRow2.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotaldetailsRow2.Cells(0).Text = RealName & " ฉาย"
        TotaldetailsRow2.Cells(0).ForeColor = Color.Blue
        TotaldetailsRow2.Cells(0).BackColor = Color.FromName("#DBE5F1")

        TotaldetailsRow2.Cells.Add(New TableCell)
        TotaldetailsRow2.Cells(1).Width = 200
        TotaldetailsRow2.Cells(1).HorizontalAlign = HorizontalAlign.Center
        TotaldetailsRow2.Cells(1).Text = sumReal.ToString("#,##0")
        TotaldetailsRow2.Cells(1).BackColor = Color.FromName("#DBE5FF")
        TotaldetailsRow2.Cells(1).ForeColor = Color.Black
        TotaldetailsRow2.Cells(1).Font.Bold = True


        TotaldetailsRow2.Cells.Add(New TableCell)
        TotaldetailsRow2.Cells(2).Width = 160
        TotaldetailsRow2.Cells(2).HorizontalAlign = HorizontalAlign.Left
        TotaldetailsRow2.Cells(2).Text = "จอ"
        TotaldetailsRow2.Cells(2).BackColor = Color.FromName("#DBE5F1")
        TotaldetailsRow2.Cells(2).ForeColor = Color.FromName("#000000")
        tbl.Rows.Add(TotaldetailsRow2)

        For i As Integer = 0 To aylSumTrailer.Count - 1

            Dim TotaldetailsRow3 As New TableRow()
            TotaldetailsRow3.HorizontalAlign = HorizontalAlign.Center
            TotaldetailsRow3.Font.Name = "Tahoma"
            TotaldetailsRow3.Font.Size = 11

            TotaldetailsRow3.Cells.Add(New TableCell)
            TotaldetailsRow3.Cells(0).HorizontalAlign = HorizontalAlign.Right
            TotaldetailsRow3.Cells(0).Text = "มี ต.ย. " & aylSumTrailer(i)
            TotaldetailsRow3.Cells(0).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow3.Cells(0).ForeColor = Color.FromName("#000000")

            TotaldetailsRow3.Cells.Add(New TableCell)
            TotaldetailsRow3.Cells(1).Width = 200
            TotaldetailsRow3.Cells(1).HorizontalAlign = HorizontalAlign.Center
            strShow = Convert.ToDecimal(hasSumTrailer(aylSumTrailer(i))).ToString("#,##0")
            TotaldetailsRow3.Cells(1).Text = strShow
            TotaldetailsRow3.Cells(1).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow3.Cells(1).ForeColor = Color.FromName("#000000")

            TotaldetailsRow3.Cells.Add(New TableCell)
            TotaldetailsRow3.Cells(2).Width = 160
            TotaldetailsRow3.Cells(2).HorizontalAlign = HorizontalAlign.Left
            TotaldetailsRow3.Cells(2).Text = "จอ"
            TotaldetailsRow3.Cells(2).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow3.Cells(2).ForeColor = Color.FromName("#000000")
            tbl.Rows.Add(TotaldetailsRow3)

            Dim TotaldetailsRow4 As New TableRow()
            TotaldetailsRow4.HorizontalAlign = HorizontalAlign.Center
            TotaldetailsRow4.Font.Name = "Tahoma"
            TotaldetailsRow4.Font.Size = 11

            TotaldetailsRow4.Cells.Add(New TableCell)
            TotaldetailsRow4.Cells(0).HorizontalAlign = HorizontalAlign.Right
            TotaldetailsRow4.Cells(0).Text = "คิดเป็น"
            TotaldetailsRow4.Cells(0).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow4.Cells(0).ForeColor = Color.FromName("#000000")
            Dim TotalPercent As Decimal
            If sumReal = 0 Then
                TotalPercent = 0
            Else
                TotalPercent = (Convert.ToDecimal(hasSumTrailer(aylSumTrailer(i))) * Convert.ToDecimal("100.0")) / Convert.ToDecimal(sumReal)
            End If


            TotaldetailsRow4.Cells.Add(New TableCell)
            TotaldetailsRow4.Cells(1).Width = 200
            TotaldetailsRow4.Cells(1).HorizontalAlign = HorizontalAlign.Center
            strShow = TotalPercent.ToString("#,##0.0") + " %"
            TotaldetailsRow4.Cells(1).Text = strShow
            TotaldetailsRow4.Cells(1).CssClass = "under2"
            TotaldetailsRow4.Cells(1).Font.Bold = True
            TotaldetailsRow4.Cells(1).ForeColor = Color.Red
            TotaldetailsRow4.Cells(1).BackColor = Color.FromName("#DBE5F1")

            TotaldetailsRow4.Cells.Add(New TableCell)
            TotaldetailsRow4.Cells(2).Width = 160
            TotaldetailsRow4.Cells(2).HorizontalAlign = HorizontalAlign.Center
            TotaldetailsRow4.Cells(2).Text = ""
            TotaldetailsRow4.Cells(2).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow4.Cells(2).ForeColor = Color.FromName("#ffffff")
            tbl.Rows.Add(TotaldetailsRow4)

            Dim TotaldetailsRow5 As New TableRow()
            TotaldetailsRow5.Cells.Add(New TableCell)
            TotaldetailsRow5.Cells(0).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow5.Cells(0).Height = 18
            TotaldetailsRow5.Cells.Add(New TableCell)
            TotaldetailsRow5.Cells(1).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow5.Cells(1).Height = 18
            TotaldetailsRow5.Cells.Add(New TableCell)
            TotaldetailsRow5.Cells(2).BackColor = Color.FromName("#DBE5F1")
            TotaldetailsRow5.Cells(2).Height = 18
            tbl.Rows.Add(TotaldetailsRow5)
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByPercentParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=TrailerByRelease.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"
            Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
            Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
            tbl.RenderControl(htmlWrite)
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
            Response.End()
        Catch ex As Exception
            Dim exMsg As String = ex.Message
        End Try
        
    End Sub

End Class