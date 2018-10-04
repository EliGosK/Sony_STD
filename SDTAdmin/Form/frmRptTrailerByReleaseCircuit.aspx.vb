Imports Web.Data

Partial Public Class frmRptTrailerByReleaseCircuit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        Try
            createRpt()
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try

       
    End Sub

    Sub createRpt()
        Dim cDB As New cDatabase
        Dim RealMovieID As String = Session("rptRealMovie").ToString
        Dim SetupNo As String = Session("rptSetupNo").ToString
        Dim RealName As String = ""
        Dim intTheatre_Cnt As Integer = 0

        Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
        If drReal.Read Then
            RealName = drReal("movie_nameen").ToString
        End If
        drReal.Close()
        tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
        tbl.Rows(2).Cells(0).Text = RealName
        tbl.Rows(3).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString

        Dim dtbCircuit As DataTable = cDatabase.GetDataTable("Select circuit_name from tblcircuit where circuit_id=" + Request.QueryString("circuitid"))
        If (dtbCircuit.Rows.Count > 0) Then
            tbl.Rows(4).Cells(0).Text = "Circuit : " + Convert.ToString(dtbCircuit.Rows(0)("circuit_name"))
        End If

        Dim dtbTrailer As DataTable = cDatabase.GetDataTable("Select movie_nameen from tblmovie where movie_id=" + Request.QueryString("movieid"))
        If (dtbTrailer.Rows.Count > 0) Then
            tbl.Rows(5).Cells(0).Text = "Trailer : " + Convert.ToString(dtbTrailer.Rows(0)("movie_nameen"))
        End If

        Dim wkSQL As String

        'wkSQL = vbNewLine + " select *,"
        'wkSQL += vbNewLine + " CASE WHEN real_movie_amt > 0 THEN "
        'wkSQL += vbNewLine + " 		(isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt) * 100) / Convert(decimal(10,3),real_movie_amt)))/100"
        'wkSQL += vbNewLine + " ELSE "
        'wkSQL += vbNewLine + "		0 "
        'wkSQL += vbNewLine + " END CompRevenue_Adms,"
        'wkSQL += vbNewLine + " CASE WHEN real_movie_amt > 0 THEN ((Convert(decimal(10,3),trailer_amt) * 100) / Convert(decimal(10,3),real_movie_amt)) ELSE 0 END AS movie_percent"
        'wkSQL += vbNewLine + " from                                                                 "
        'wkSQL += vbNewLine + " (                                                          "
        'wkSQL += vbNewLine + " SELECT  distinct tm.circuit_id, dbo.tblCircuit.circuit_name, tm.theater_id,tt.theater_Name"
        'wkSQL += vbNewLine + " , cd.ref_setup_no,tm.real_movie_id,mv.movie_nameen real_movie_name"
        'wkSQL += vbNewLine + " , cd.movie_id"
        'wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
        'wkSQL += vbNewLine + " , ("
        'wkSQL += vbNewLine + " select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " where 1=1"
        'wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "'"
        'wkSQL += vbNewLine + " and tm3.circuit_id= tm.circuit_id"
        'wkSQL += vbNewLine + " and tm3.theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
        'wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
        'wkSQL += vbNewLine + " ) AS real_movie_amt"
        'wkSQL += vbNewLine + " , (select count (ttm.collection_no)"
        'wkSQL += vbNewLine + " FROM         dbo.tblTrailer_Master AS ttm INNER JOIN dbo.tblTrailer_Collection_Dtl AS d ON ttm.collection_no = d.collection_no "
        'wkSQL += vbNewLine + " inner join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
        'wkSQL += vbNewLine + " INNER JOIN dbo.tblCircuit ON ttm.circuit_id = dbo.tblCircuit.circuit_id"
        'wkSQL += vbNewLine + " WHERE     (ttm.confirm_flag = 'Y') "
        'wkSQL += vbNewLine + " AND (ttm.real_movie_id = tm.real_movie_id) "
        'wkSQL += vbNewLine + " AND (d.ref_setup_no = '" + SetupNo + "')"
        'wkSQL += vbNewLine + " and ttm.circuit_id = tm.circuit_id"
        'wkSQL += vbNewLine + " and d.movie_id = cd.movie_id"
        'wkSQL += vbNewLine + " and ch.theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " ) trailer_amt"
        'wkSQL += vbNewLine + " ,(select isnull(sum(isnull(revenue_adms,0)),0) Revenue_Adms"
        'wkSQL += vbNewLine + " FROM tblRevenue"
        'wkSQL += vbNewLine + " where convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and tblRevenue.movies_id = tm.real_movie_id  "
        'wkSQL += vbNewLine + " and theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " and theatersub_id in"
        'wkSQL += vbNewLine + " 	("
        'wkSQL += vbNewLine + " 	select tm3.theatersub_id"
        'wkSQL += vbNewLine + " 	from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " 	left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " 	left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " 	where cd3.ref_setup_no = '" + SetupNo + "'"
        'wkSQL += vbNewLine + " 	and cd3.movie_id=cd.movie_id"
        'wkSQL += vbNewLine + " 	and tm3.circuit_id= tm.circuit_id"
        'wkSQL += vbNewLine + " 	and tm3.theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " 	and tm3.real_movie_id=tm.real_movie_id"
        'wkSQL += vbNewLine + " 	and tm3.confirm_flag='Y'"
        'wkSQL += vbNewLine + " 	)"
        'wkSQL += vbNewLine + " ) Revenue_Adms"
        'wkSQL += vbNewLine + " ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
        'wkSQL += vbNewLine + " FROM tblCompRevenue"
        'wkSQL += vbNewLine + " where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and tblCompRevenue.movies_id = tm.real_movie_id  "
        'wkSQL += vbNewLine + " and theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " ) Total_CompRevenue_Adms"
        'wkSQL += vbNewLine + " FROM	dbo.tblTrailer_Master tm "
        'wkSQL += vbNewLine + " INNER JOIN dbo.tblTrailer_Collection_Dtl cd ON tm.collection_no = cd.collection_no "
        'wkSQL += vbNewLine + " INNER JOIN dbo.tblCircuit ON tm.circuit_id = dbo.tblCircuit.circuit_id"
        'wkSQL += vbNewLine + " INNER JOIN dbo.tblTheater tt on tt.theater_id = tm.theater_id"
        'wkSQL += vbNewLine + " inner join dbo.tblMovie mv on mv.movie_id = tm.real_movie_id"
        'wkSQL += vbNewLine + " WHERE     (tm.confirm_flag = 'Y') "
        'wkSQL += vbNewLine + " AND (tm.real_movie_id = " + RealMovieID + ") "
        'wkSQL += vbNewLine + " AND (cd.ref_setup_no = '" + SetupNo + "')"
        'wkSQL += vbNewLine + " and cd.movie_id = " + Convert.ToString(Request.QueryString("movieid"))
        'wkSQL += vbNewLine + " ) as mas"
        'wkSQL += vbNewLine + " where circuit_id = " + Convert.ToString(Request.QueryString("circuitid"))
        'wkSQL += vbNewLine + " ORDER BY movie_percent DESC, Revenue_Adms DESC, CompRevenue_Adms DESC, trailer_amt DESC, Trailer_name ASC"

        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQL = vbNewLine + " select *,"
        wkSQL += vbNewLine + " CASE WHEN real_movie_amt > 0 THEN "
        wkSQL += vbNewLine + " (isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt) * 100) / Convert(decimal(10,3),real_movie_amt)))/100"
        wkSQL += vbNewLine + " ELSE "
        wkSQL += vbNewLine + " 0 "
        wkSQL += vbNewLine + " END CompRevenue_Adms,"
        wkSQL += vbNewLine + " CASE WHEN real_movie_amt > 0 THEN ((Convert(decimal(10,3),trailer_amt) * 100) / Convert(decimal(10,3),real_movie_amt)) ELSE 0 END AS movie_percent"
        wkSQL += vbNewLine + " from                                                                 "
        wkSQL += vbNewLine + " (                                                          "
        wkSQL += vbNewLine + " 	SELECT  distinct tta.circuit_id, cca.circuit_name, tm.theater_id, tta.theater_Name"
        wkSQL += vbNewLine + " 	, cd.ref_setup_no,tm.real_movie_id,mv.movie_nameen real_movie_name"
        wkSQL += vbNewLine + " 	, cd.movie_id"
        wkSQL += vbNewLine + " 	, (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
        wkSQL += vbNewLine + " 	, ("
        wkSQL += vbNewLine + " 	select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        wkSQL += vbNewLine + " 	from tbltrailer_master tm3 "
        wkSQL += vbNewLine + " 	left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQL += vbNewLine + " 	left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQL += vbNewLine + " 	left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 	left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 	where 1=1"
        wkSQL += vbNewLine + " 	and cd3.ref_setup_no = '" + SetupNo + "'"
        wkSQL += vbNewLine + " 	and t.circuit_id= tta.circuit_id"
        wkSQL += vbNewLine + " 	and tm3.theater_id = tm.theater_id"
        wkSQL += vbNewLine + " 	and tm3.real_movie_id=tm.real_movie_id"
        wkSQL += vbNewLine + " 	and tm3.confirm_flag='Y'"
        wkSQL += vbNewLine + " 	) AS real_movie_amt"
        wkSQL += vbNewLine + " 	, (select count (ttm.collection_no)"
        wkSQL += vbNewLine + " 	FROM dbo.tblTrailer_Master AS ttm "
        wkSQL += vbNewLine + " 	left join dbo.tblTrailer_Collection_Dtl AS d ON ttm.collection_no = d.collection_no "
        wkSQL += vbNewLine + " 	left join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
        wkSQL += vbNewLine + " 	left join tblTheater t on ttm.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 	left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 	WHERE (ttm.confirm_flag = 'Y') "
        wkSQL += vbNewLine + " 	AND (ttm.real_movie_id = tm.real_movie_id) "
        wkSQL += vbNewLine + " 	AND (d.ref_setup_no = '" + SetupNo + "')"
        wkSQL += vbNewLine + " 	and t.circuit_id = tta.circuit_id"
        wkSQL += vbNewLine + " 	and d.movie_id = cd.movie_id"
        wkSQL += vbNewLine + " 	and ch.theater_id = tm.theater_id"
        wkSQL += vbNewLine + " 	) trailer_amt"
        wkSQL += vbNewLine + " 	,(select isnull(sum(isnull(revenue_adms,0)),0) Revenue_Adms"
        wkSQL += vbNewLine + " 	FROM tblRevenue"
        wkSQL += vbNewLine + " 	where convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        wkSQL += vbNewLine + " 	and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        wkSQL += vbNewLine + " 	and tblRevenue.movies_id = tm.real_movie_id  "
        wkSQL += vbNewLine + " 	and theater_id = tm.theater_id"
        wkSQL += vbNewLine + " 	and theatersub_id in"
        wkSQL += vbNewLine + " 		("
        wkSQL += vbNewLine + " 		select tm3.theatersub_id"
        wkSQL += vbNewLine + " 		from tbltrailer_master tm3 "
        wkSQL += vbNewLine + " 		left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        wkSQL += vbNewLine + " 		left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        wkSQL += vbNewLine + "		left join tblTheater t on tm3.theater_id = t.theater_id"
        wkSQL += vbNewLine + "	    left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 		where cd3.ref_setup_no = '" + SetupNo + "'"
        wkSQL += vbNewLine + " 		and cd3.movie_id=cd.movie_id"
        wkSQL += vbNewLine + " 		and t.circuit_id= tta.circuit_id"
        wkSQL += vbNewLine + " 		and tm3.theater_id = tm.theater_id"
        wkSQL += vbNewLine + " 		and tm3.real_movie_id=tm.real_movie_id"
        wkSQL += vbNewLine + " 		and tm3.confirm_flag='Y'"
        wkSQL += vbNewLine + " 		)"
        wkSQL += vbNewLine + " 	) Revenue_Adms"
        wkSQL += vbNewLine + " 	,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
        wkSQL += vbNewLine + " 	FROM tblCompRevenue"
        wkSQL += vbNewLine + " 	where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        wkSQL += vbNewLine + " 	and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        wkSQL += vbNewLine + " 	and tblCompRevenue.movies_id = tm.real_movie_id  "
        wkSQL += vbNewLine + " 	and theater_id = tm.theater_id"
        wkSQL += vbNewLine + " 	) Total_CompRevenue_Adms"
        wkSQL += vbNewLine + " 	FROM	dbo.tblTrailer_Master tm "
        wkSQL += vbNewLine + " 	left join dbo.tblTrailer_Collection_Dtl cd ON tm.collection_no = cd.collection_no "
        wkSQL += vbNewLine + " 	left join dbo.tblMovie mv on mv.movie_id = tm.real_movie_id"
        wkSQL += vbNewLine + " 	left join tblTheater tta on tm.theater_id = tta.theater_id"
        wkSQL += vbNewLine + " 	left join tblCircuit cca on tta.circuit_id = cca.circuit_id "
        wkSQL += vbNewLine + " 	WHERE (tm.confirm_flag = 'Y') "
        wkSQL += vbNewLine + " 	AND (tm.real_movie_id = " + RealMovieID + ") "
        wkSQL += vbNewLine + " 	AND (cd.ref_setup_no = '" + SetupNo + "')"
        wkSQL += vbNewLine + " 	and cd.movie_id = " + Convert.ToString(Request.QueryString("movieid"))
        wkSQL += vbNewLine + " ) as mas"
        wkSQL += vbNewLine + " where circuit_id = " + Convert.ToString(Request.QueryString("circuitid"))
        wkSQL += vbNewLine + " ORDER BY movie_percent DESC, Revenue_Adms DESC, CompRevenue_Adms DESC, trailer_amt DESC, Trailer_name ASC	"
        '--- End by Muay 2010-06-09 --------------------------------------------

        ' ''--- Edit by Nick 2010-07-12 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        'wkSQL = " select mas.circuit_id, mas.circuit_name, mas.ref_setup_no, mas.real_movie_id, mas.theater_id, mas.theater_name,"
        'wkSQL += vbNewLine + " mas.real_movie_name, mas.movie_id, mas.Total_Adms, mas.Total_Comp_Adms, "
        'wkSQL += vbNewLine + " mas.Trailer_name, mas.IsCTBV, mas.real_movie_amt, mas.trailer_amt,"
        'wkSQL += vbNewLine + " dbo.funGetRevenue (mas.ref_setup_no, mas.circuit_id, mas.real_movie_id, mas.movie_id) Revenue_Adms,"
        'wkSQL += vbNewLine + " mas.CompRevenue_Adms,"
        'wkSQL += vbNewLine + " CASE WHEN mas.real_movie_amt > 0 THEN"
        'wkSQL += vbNewLine + " ((Convert(decimal(10,3), mas.trailer_amt) * 100) / Convert(decimal(10,3), mas.real_movie_amt)) "
        'wkSQL += vbNewLine + " ELSE "
        'wkSQL += vbNewLine + " 0 "
        'wkSQL += vbNewLine + " END AS movie_percent"
        'wkSQL += vbNewLine + " from"
        'wkSQL += vbNewLine + " ("
        'wkSQL += vbNewLine + " SELECT  distinct  ct.circuit_id, cir.circuit_name, cd.ref_setup_no,  tm.real_movie_id, ct.theater_id, ct.theater_name"
        'wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = tm.real_movie_id) as real_movie_name"
        'wkSQL += vbNewLine + " , cd.movie_id"
        'wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
        'wkSQL += vbNewLine + " , (select top 1 movietype_id from tblmovie where tblmovie.movie_id = cd.movie_id) as IsCTBV"
        'wkSQL += vbNewLine + " ,(select isnull(sum(isnull(revenue_adms,0)),0) Total_Adms"
        'wkSQL += vbNewLine + " FROM tblRevenue"
        'wkSQL += vbNewLine + " where 	convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and tblRevenue.movies_id = tm.real_movie_id"
        'wkSQL += vbNewLine + " ) Total_Adms,"
        'wkSQL += vbNewLine + " (select isnull(sum(isnull(comprevenue_admssum,0)),0) Total_Comp_Adms"
        'wkSQL += vbNewLine + " FROM tblCompRevenue"
        'wkSQL += vbNewLine + " where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
        'wkSQL += vbNewLine + " and tblCompRevenue.movies_id = tm.real_movie_id"
        'wkSQL += vbNewLine + " ) Total_Comp_Adms"
        'wkSQL += vbNewLine + " ,("
        'wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " left join tblTheater t on tm3.theater_id = t.theater_id"
        'wkSQL += vbNewLine + " left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        'wkSQL += vbNewLine + " where cd3.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " and t.circuit_id= ct.circuit_id"
        'wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
        'wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
        'wkSQL += vbNewLine + " ) AS real_movie_amt,"
        'wkSQL += vbNewLine + " ("
        'wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " left join tblTheater t on tm3.theater_id = t.theater_id"
        'wkSQL += vbNewLine + " left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        'wkSQL += vbNewLine + " where 1=1"
        'wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " and cd3.movie_id=cd.movie_id"
        'wkSQL += vbNewLine + " and t.circuit_id= cir.circuit_id"
        'wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
        'wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
        'wkSQL += vbNewLine + " ) AS trailer_amt, "
        'wkSQL += vbNewLine + " (select sum(isnull(a.CompRevenue_Adms, 0)) as CompRevenue_Adms"
        'wkSQL += vbNewLine + " from"
        'wkSQL += vbNewLine + " ("
        'wkSQL += vbNewLine + " 	select mas.circuit_id, mas.real_movie_id, mas.real_movie_amt, mas.movie_id, mas.trailer_amt, mas.Total_CompRevenue_Adms,"
        'wkSQL += vbNewLine + " 	CASE WHEN real_movie_amt > 0 THEN "
        'wkSQL += vbNewLine + " 		round((isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt)) / Convert(decimal(10,3),real_movie_amt))), 0)"
        'wkSQL += vbNewLine + " 	ELSE "
        'wkSQL += vbNewLine + " 		0 "
        'wkSQL += vbNewLine + " 	END CompRevenue_Adms"
        'wkSQL += vbNewLine + " 	from                                                                 "
        'wkSQL += vbNewLine + " 	(                                                          "
        'wkSQL += vbNewLine + " 		 SELECT  distinct tm1.circuit_id, tm1.real_movie_id, cd1.movie_id,"
        'wkSQL += vbNewLine + " 		 ("
        'wkSQL += vbNewLine + " 		 select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
        'wkSQL += vbNewLine + " 		 from tbltrailer_master tm3 "
        'wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
        'wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
        'wkSQL += vbNewLine + " 		 left join tblTheater t on tm3.theater_id = t.theater_id"
        'wkSQL += vbNewLine + " 		 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        'wkSQL += vbNewLine + " 		 where 1=1"
        'wkSQL += vbNewLine + " 		 and cd3.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " 		 and t.circuit_id= cir.circuit_id"
        'wkSQL += vbNewLine + " 		 and tm3.theater_id = tm1.theater_id"
        'wkSQL += vbNewLine + " 		 and tm3.real_movie_id=tm1.real_movie_id"
        'wkSQL += vbNewLine + " 		 and tm3.confirm_flag='Y'"
        'wkSQL += vbNewLine + " 		 ) AS real_movie_amt"
        'wkSQL += vbNewLine + " 		 ,(select count (ttm1.collection_no)"
        'wkSQL += vbNewLine + " 		 FROM dbo.tblTrailer_Master AS ttm1 "
        'wkSQL += vbNewLine + " 		 left join dbo.tblTrailer_Collection_Dtl AS d ON ttm1.collection_no = d.collection_no "
        'wkSQL += vbNewLine + " 		 left join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
        'wkSQL += vbNewLine + " 		 left join dbo.tblTheater tt on ttm1.theater_id = tt.theater_id"
        'wkSQL += vbNewLine + " 		 left join dbo.tblCircuit c ON tt.circuit_id = c.circuit_id"
        'wkSQL += vbNewLine + " 		 where ttm1.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 		 and ttm1.real_movie_id = tm1.real_movie_id"
        'wkSQL += vbNewLine + " 		 and d.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " 		 and tt.circuit_id = cir.circuit_id"
        'wkSQL += vbNewLine + " 		 and d.movie_id = cd1.movie_id"
        'wkSQL += vbNewLine + " 		 and ch.theater_id = tm1.theater_id"
        'wkSQL += vbNewLine + " 		 ) trailer_amt"
        'wkSQL += vbNewLine + " 		 ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
        'wkSQL += vbNewLine + " 		 FROM tblCompRevenue"
        'wkSQL += vbNewLine + " 		 where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
        'wkSQL += vbNewLine + " 		 and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
        'wkSQL += vbNewLine + " 		 and tblCompRevenue.movies_id = tm1.real_movie_id  "
        'wkSQL += vbNewLine + " 		 and theater_id = tm1.theater_id"
        'wkSQL += vbNewLine + " 		 ) Total_CompRevenue_Adms"
        'wkSQL += vbNewLine + " 		 FROM dbo.tblTrailer_Master tm1"
        'wkSQL += vbNewLine + " 		 left join dbo.tblTrailer_Collection_Dtl cd1 ON tm1.collection_no = cd1.collection_no "
        'wkSQL += vbNewLine + " 		 left join dbo.tblMovie mv on mv.movie_id = tm1.real_movie_id"
        'wkSQL += vbNewLine + " 		 left join dbo.tblTheater tt1 on tm1.theater_id = tt1.theater_id"
        'wkSQL += vbNewLine + " 		 left join dbo.tblCircuit c1 ON tt1.circuit_id = c1.circuit_id"
        'wkSQL += vbNewLine + " 		 where tm1.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " 		 and tm1.real_movie_id = tm.real_movie_id"
        'wkSQL += vbNewLine + " 		 and cd1.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " 		 and cd1.movie_id = cd.movie_id"
        'wkSQL += vbNewLine + " 		 and c1.circuit_id =  cir.circuit_id"
        'wkSQL += vbNewLine + " 		) as mas"
        'wkSQL += vbNewLine + " ) a "
        'wkSQL += vbNewLine + " ) CompRevenue_Adms"
        'wkSQL += vbNewLine + " FROM dbo.tblTrailer_Master AS tm "
        'wkSQL += vbNewLine + " left join dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
        'wkSQL += vbNewLine + " left join tblTheater ct on tm.theater_id = ct.theater_id"
        'wkSQL += vbNewLine + " left join tblCircuit cir on ct.circuit_id = cir.circuit_id "
        'wkSQL += vbNewLine + " where tm.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " and tm.real_movie_id = " + RealMovieID
        'wkSQL += vbNewLine + " and cd.ref_setup_no = '" + SetupNo + "' "
        'wkSQL += vbNewLine + " and cd.movie_id = " + Convert.ToString(Request.QueryString("movieid"))
        'wkSQL += vbNewLine + " where circuit_id = " + Convert.ToString(Request.QueryString("circuitid"))
        'wkSQL += vbNewLine + " ) as mas"
        'wkSQL += vbNewLine + " ORDER BY circuit_name ASC, movie_percent DESC, Revenue_Adms DESC, CompRevenue_Adms DESC, trailer_amt DESC, Trailer_name ASC"
        ' ''--- End by Nick 2010-07-12 --------------------------------------------


        Dim dr As IDataReader = cDB.GetDataAll(wkSQL)
        Dim checkRow As Integer = 1

        Dim sumReal As Integer = 0
        Dim sumTrailer As Integer = 0
        Dim SumPercent As Decimal = 0

        Dim strCircuit As String = ""
        Dim detailsRow As New TableRow()


        Dim decSumAmount As Decimal = 0
        Dim decSumPercent As Decimal = 0
        Dim decSumAdms As Decimal = 0

        While (dr.Read())
            intTheatre_Cnt = intTheatre_Cnt + 1

            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(0).Text = "<a target='_self' href='frmRptTrailerByReleaseTheatre.aspx?circuitid=" + Convert.ToString(Request.QueryString("circuitid")) + "&theaterid=" + Convert.ToString(dr("theater_id")) + "&movieid=" + Convert.ToString(dr("movie_id")) + "'>" + Convert.ToString(dr("Theater_name")) + "</a>"
            detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(0).Font.Bold = False
            detailsRow.Cells(0).Height = 20
            detailsRow.Cells(0).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).Text = Convert.ToDecimal(dr("trailer_amt")).ToString("#,##0")
            detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(1).Font.Bold = False
            detailsRow.Cells(1).Height = 20
            detailsRow.Cells(1).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).Text = Convert.ToDecimal(dr("movie_percent")).ToString("#,##0.0")
            detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(2).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(2).Font.Bold = False
            detailsRow.Cells(2).Height = 20
            detailsRow.Cells(2).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).Text = Convert.ToDecimal(Convert.ToDecimal(dr("Revenue_Adms")) + Convert.ToDecimal(dr("CompRevenue_Adms"))).ToString("#,##0")
            detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(3).Font.Bold = False
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(3).Height = 20
            detailsRow.Cells(3).ColumnSpan = 1

            tbl.Rows.Add(detailsRow)

            decSumAmount += Convert.ToDecimal(dr("trailer_amt"))
            decSumPercent += Convert.ToDecimal(dr("movie_percent"))
            decSumAdms += Convert.ToDecimal(detailsRow.Cells(3).Text)

            checkRow += 1
        End While

        decSumPercent = decSumPercent / intTheatre_Cnt

        dr.Close()


        If (checkRow > 0) Then
            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(0).Text = "Total"
            detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(0).ForeColor = Color.Red
            detailsRow.Cells(0).Font.Bold = True
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(0).Height = 20
            detailsRow.Cells(0).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).Text = decSumAmount.ToString("#,##0")
            detailsRow.Cells(1).ForeColor = Color.Red
            detailsRow.Cells(1).Font.Bold = True
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(1).Height = 20
            detailsRow.Cells(1).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).Text = decSumPercent.ToString("#,##0.0")
            detailsRow.Cells(2).ForeColor = Color.Red
            detailsRow.Cells(2).Font.Bold = True
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(2).Height = 20
            detailsRow.Cells(2).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).Text = decSumAdms.ToString("#,##0")
            detailsRow.Cells(3).ForeColor = Color.Red
            detailsRow.Cells(3).Font.Bold = True
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(3).Height = 20
            detailsRow.Cells(3).ColumnSpan = 1

            tbl.Rows.Add(detailsRow)

        End If

    End Sub


    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByReleaseParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=TrailerByReleaseCircuit.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"
            Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
            Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
            tbl.RenderControl(htmlWrite)
            createRpt()
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
            Response.End()
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
     
    End Sub

End Class