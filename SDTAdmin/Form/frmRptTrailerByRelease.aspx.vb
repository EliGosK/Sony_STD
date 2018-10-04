Imports Web.Data

Partial Public Class frmRptTrailerByRelease
    Inherits System.Web.UI.Page

    ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''    'If Mid(Session("permission"), 7, 1) = "0" Then
    ''    '    Response.Redirect("InfoPage.aspx")
    ''    'End If

    ''    Dim cDB As New cDatabase
    ''    Dim RealMovieID As String = Session("rptRealMovie").ToString
    ''    Dim SetupNo As String = Session("rptSetupNo").ToString
    ''    Dim RealName As String = ""

    ''    If Not IsPostBack Then
    ''        ViewState("sumScreenAll") = 0
    ''    End If

    ''    'Dim drTrailer As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + TrailerMovieID)
    ''    'If drTrailer.Read Then
    ''    '    SetupNo = drTrailer("movie_nameen").ToString
    ''    'End If
    ''    'drTrailer.Close()

    ''    Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
    ''    If drReal.Read Then
    ''        RealName = drReal("movie_nameen").ToString
    ''    End If
    ''    drReal.Close()

    ''    tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
    ''    tbl.Rows(2).Cells(0).Text = RealName
    ''    tbl.Rows(3).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString
    ''    Dim wkSQL As String

    ''    'wkSQL = vbNewLine + " select mas.circuit_id, mas.circuit_name, mas.ref_setup_no, mas.real_movie_id,"
    ''    'wkSQL += vbNewLine + " mas.real_movie_name, mas.movie_id, mas.Total_Adms, mas.Total_Comp_Adms, "
    ''    'wkSQL += vbNewLine + " mas.Trailer_name, mas.IsCTBV, mas.real_movie_amt, mas.trailer_amt,"
    ''    'wkSQL += vbNewLine + " dbo.funGetRevenue (mas.ref_setup_no, mas.circuit_id, mas.real_movie_id, mas.movie_id) Revenue_Adms,"
    ''    'wkSQL += vbNewLine + " mas.CompRevenue_Adms,"
    ''    'wkSQL += vbNewLine + " CASE WHEN mas.real_movie_amt > 0 THEN"
    ''    'wkSQL += vbNewLine + " 	((Convert(decimal(10,3), mas.trailer_amt) * 100) / Convert(decimal(10,3), mas.real_movie_amt)) "
    ''    'wkSQL += vbNewLine + " ELSE "
    ''    'wkSQL += vbNewLine + " 	0 "
    ''    'wkSQL += vbNewLine + " END AS movie_percent"
    ''    'wkSQL += vbNewLine + " from"
    ''    'wkSQL += vbNewLine + " ("
    ''    'wkSQL += vbNewLine + " SELECT  distinct  tm.circuit_id,dbo.tblCircuit.circuit_name, cd.ref_setup_no,  tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = tm.real_movie_id) as real_movie_name"
    ''    'wkSQL += vbNewLine + " , cd.movie_id"
    ''    'wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
    ''    'wkSQL += vbNewLine + " , (select top 1 movietype_id from tblmovie where tblmovie.movie_id = cd.movie_id) as IsCTBV"
    ''    'wkSQL += vbNewLine + " ,(select isnull(sum(isnull(revenue_adms,0)),0) Total_Adms"
    ''    'wkSQL += vbNewLine + " FROM tblRevenue"
    ''    'wkSQL += vbNewLine + " where 	convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " and tblRevenue.movies_id = tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " ) Total_Adms,"
    ''    'wkSQL += vbNewLine + " (select isnull(sum(isnull(comprevenue_admssum,0)),0) Total_Comp_Adms"
    ''    'wkSQL += vbNewLine + " FROM tblCompRevenue"
    ''    'wkSQL += vbNewLine + " where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " and tblCompRevenue.movies_id = tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " ) Total_Comp_Adms"
    ''    'wkSQL += vbNewLine + " ,("
    ''    'wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    'wkSQL += vbNewLine + " from tbltrailer_master tm3 "
    ''    'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    'wkSQL += vbNewLine + " where 1=1"
    ''    'wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " and tm3.circuit_id= tm.circuit_id"
    ''    'wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
    ''    'wkSQL += vbNewLine + " ) AS real_movie_amt,"
    ''    'wkSQL += vbNewLine + " ("
    ''    'wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    'wkSQL += vbNewLine + " from tbltrailer_master tm3 "
    ''    'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    'wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    'wkSQL += vbNewLine + " where 1=1"
    ''    'wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " and cd3.movie_id=cd.movie_id"
    ''    'wkSQL += vbNewLine + " and tm3.circuit_id= tm.circuit_id"
    ''    'wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
    ''    'wkSQL += vbNewLine + " ) AS trailer_amt, "
    ''    'wkSQL += vbNewLine + "(select sum(isnull(a.CompRevenue_Adms, 0)) as CompRevenue_Adms"
    ''    'wkSQL += vbNewLine + " from"
    ''    'wkSQL += vbNewLine + " ("
    ''    'wkSQL += vbNewLine + "  select mas.circuit_id, mas.real_movie_id, mas.real_movie_amt, mas.movie_id, mas.trailer_amt, mas.Total_CompRevenue_Adms,"
    ''    'wkSQL += vbNewLine + "  CASE WHEN real_movie_amt > 0 THEN "
    ''    'wkSQL += vbNewLine + " 		round((isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt)) / Convert(decimal(10,3),real_movie_amt))), 0)"
    ''    'wkSQL += vbNewLine + "  ELSE "
    ''    'wkSQL += vbNewLine + " 		0 "
    ''    'wkSQL += vbNewLine + "  END CompRevenue_Adms"
    ''    'wkSQL += vbNewLine + "  from                                                                 "
    ''    'wkSQL += vbNewLine + "  (                                                          "
    ''    'wkSQL += vbNewLine + " 	 SELECT  distinct tm1.circuit_id, tm1.real_movie_id, cd1.movie_id,"
    ''    'wkSQL += vbNewLine + " 	 ("
    ''    'wkSQL += vbNewLine + " 	 select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    'wkSQL += vbNewLine + " 	 from tbltrailer_master tm3 "
    ''    'wkSQL += vbNewLine + " 	 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    'wkSQL += vbNewLine + " 	 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    'wkSQL += vbNewLine + " 	 where 1=1"
    ''    'wkSQL += vbNewLine + " 	 and cd3.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " 	 and tm3.circuit_id= tm1.circuit_id"
    ''    'wkSQL += vbNewLine + " 	 and tm3.theater_id = tm1.theater_id"
    ''    'wkSQL += vbNewLine + " 	 and tm3.real_movie_id=tm1.real_movie_id"
    ''    'wkSQL += vbNewLine + " 	 and tm3.confirm_flag='Y'"
    ''    'wkSQL += vbNewLine + " 	 ) AS real_movie_amt"
    ''    'wkSQL += vbNewLine + " 	 ,(select count (ttm1.collection_no)"
    ''    'wkSQL += vbNewLine + " 	 FROM         dbo.tblTrailer_Master AS ttm1 INNER JOIN dbo.tblTrailer_Collection_Dtl AS d ON ttm1.collection_no = d.collection_no "
    ''    'wkSQL += vbNewLine + " 	 inner join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
    ''    'wkSQL += vbNewLine + " 	 INNER JOIN dbo.tblCircuit ON ttm1.circuit_id = dbo.tblCircuit.circuit_id"
    ''    'wkSQL += vbNewLine + " 	 WHERE ttm1.confirm_flag = 'Y'"
    ''    'wkSQL += vbNewLine + " 	 AND ttm1.real_movie_id = tm1.real_movie_id"
    ''    'wkSQL += vbNewLine + " 	 AND d.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " 	 and ttm1.circuit_id = tm1.circuit_id"
    ''    'wkSQL += vbNewLine + " 	 and d.movie_id = cd1.movie_id"
    ''    'wkSQL += vbNewLine + " 	 and ch.theater_id = tm1.theater_id"
    ''    'wkSQL += vbNewLine + " 	 ) trailer_amt"
    ''    'wkSQL += vbNewLine + " 	 ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
    ''    'wkSQL += vbNewLine + " 	 FROM tblCompRevenue"
    ''    'wkSQL += vbNewLine + " 	 where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " 	 and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''    'wkSQL += vbNewLine + " 	 and tblCompRevenue.movies_id = tm1.real_movie_id  "
    ''    'wkSQL += vbNewLine + " 	 and theater_id = tm1.theater_id"
    ''    'wkSQL += vbNewLine + " 	 ) Total_CompRevenue_Adms"
    ''    'wkSQL += vbNewLine + " 	 FROM	dbo.tblTrailer_Master tm1"
    ''    'wkSQL += vbNewLine + " 	 INNER JOIN dbo.tblTrailer_Collection_Dtl cd1 ON tm1.collection_no = cd1.collection_no "
    ''    'wkSQL += vbNewLine + " 	 INNER JOIN dbo.tblCircuit ON tm1.circuit_id = dbo.tblCircuit.circuit_id"
    ''    'wkSQL += vbNewLine + " 	 INNER JOIN dbo.tblTheater tt on tt.theater_id = tm1.theater_id"
    ''    'wkSQL += vbNewLine + " 	 inner join dbo.tblMovie mv on mv.movie_id = tm1.real_movie_id"
    ''    'wkSQL += vbNewLine + " 	 WHERE     tm1.confirm_flag = 'Y'"
    ''    'wkSQL += vbNewLine + " 	 AND tm1.real_movie_id = tm.real_movie_id"
    ''    'wkSQL += vbNewLine + " 	 AND cd1.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " 	 and cd1.movie_id = cd.movie_id"
    ''    'wkSQL += vbNewLine + " 	 and tm1.circuit_id =  tm.circuit_id"
    ''    'wkSQL += vbNewLine + "   ) as mas"
    ''    'wkSQL += vbNewLine + " ) a "
    ''    'wkSQL += vbNewLine + " ) CompRevenue_Adms"
    ''    'wkSQL += vbNewLine + " FROM dbo.tblTrailer_Master AS tm "
    ''    'wkSQL += vbNewLine + " INNER JOIN dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
    ''    'wkSQL += vbNewLine + " INNER JOIN dbo.tblCircuit ON tm.circuit_id = dbo.tblCircuit.circuit_id"
    ''    'wkSQL += vbNewLine + " WHERE tm.confirm_flag = 'Y'"
    ''    'wkSQL += vbNewLine + " AND tm.real_movie_id = " + RealMovieID
    ''    'wkSQL += vbNewLine + " AND cd.ref_setup_no = '" + SetupNo + "' "
    ''    'wkSQL += vbNewLine + " ) as mas"
    ''    'wkSQL += vbNewLine + " ORDER BY circuit_name ASC, movie_percent DESC, Revenue_Adms DESC, CompRevenue_Adms DESC, trailer_amt DESC, Trailer_name ASC"

    ''    '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
    ''    wkSQL = " select mas.circuit_id, mas.circuit_name, mas.ref_setup_no, mas.real_movie_id,"
    ''    wkSQL += vbNewLine + " mas.real_movie_name, mas.movie_id, mas.Total_Adms, mas.Total_Comp_Adms, "
    ''    wkSQL += vbNewLine + " mas.Trailer_name, mas.IsCTBV, mas.real_movie_amt, mas.trailer_amt,"
    ''    wkSQL += vbNewLine + " dbo.funGetRevenue (mas.ref_setup_no, mas.circuit_id, mas.real_movie_id, mas.movie_id) Revenue_Adms,"
    ''    wkSQL += vbNewLine + " mas.CompRevenue_Adms,"
    ''    wkSQL += vbNewLine + " CASE WHEN mas.real_movie_amt > 0 THEN"
    ''    wkSQL += vbNewLine + " ((Convert(decimal(10,3), mas.trailer_amt) * 100) / Convert(decimal(10,3), mas.real_movie_amt)) "
    ''    wkSQL += vbNewLine + " ELSE "
    ''    wkSQL += vbNewLine + " 0 "
    ''    wkSQL += vbNewLine + " END AS movie_percent"
    ''    wkSQL += vbNewLine + " from"
    ''    wkSQL += vbNewLine + " ("
    ''    wkSQL += vbNewLine + " SELECT  distinct  ct.circuit_id, cir.circuit_name, cd.ref_setup_no,  tm.real_movie_id"
    ''    wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = tm.real_movie_id) as real_movie_name"
    ''    wkSQL += vbNewLine + " , cd.movie_id"
    ''    wkSQL += vbNewLine + " , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
    ''    wkSQL += vbNewLine + " , (select top 1 movietype_id from tblmovie where tblmovie.movie_id = cd.movie_id) as IsCTBV"
    ''    wkSQL += vbNewLine + " ,(select isnull(sum(isnull(revenue_adms,0)),0) Total_Adms"
    ''    wkSQL += vbNewLine + " FROM tblRevenue"
    ''    wkSQL += vbNewLine + " where 	convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    wkSQL += vbNewLine + " and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    wkSQL += vbNewLine + " and tblRevenue.movies_id = tm.real_movie_id"
    ''    wkSQL += vbNewLine + " ) Total_Adms,"
    ''    wkSQL += vbNewLine + " (select isnull(sum(isnull(comprevenue_admssum,0)),0) Total_Comp_Adms"
    ''    wkSQL += vbNewLine + " FROM tblCompRevenue"
    ''    wkSQL += vbNewLine + " where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    wkSQL += vbNewLine + " and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''    wkSQL += vbNewLine + " and tblCompRevenue.movies_id = tm.real_movie_id"
    ''    wkSQL += vbNewLine + " ) Total_Comp_Adms"
    ''    wkSQL += vbNewLine + " ,("
    ''    wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    wkSQL += vbNewLine + " from tbltrailer_master tm3 "
    ''    wkSQL += vbNewLine + " left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    wkSQL += vbNewLine + " left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    wkSQL += vbNewLine + " left join tblTheater t on tm3.theater_id = t.theater_id"
    ''    wkSQL += vbNewLine + " left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''    wkSQL += vbNewLine + " where cd3.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " and t.circuit_id= ct.circuit_id"
    ''    wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
    ''    wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
    ''    wkSQL += vbNewLine + " ) AS real_movie_amt,"
    ''    wkSQL += vbNewLine + " ("
    ''    wkSQL += vbNewLine + " select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    wkSQL += vbNewLine + " from tbltrailer_master tm3 "
    ''    wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    wkSQL += vbNewLine + " left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    wkSQL += vbNewLine + " left join tblTheater t on tm3.theater_id = t.theater_id"
    ''    wkSQL += vbNewLine + " left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''    wkSQL += vbNewLine + " where 1=1"
    ''    wkSQL += vbNewLine + " and cd3.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " and cd3.movie_id=cd.movie_id"
    ''    wkSQL += vbNewLine + " and t.circuit_id= cir.circuit_id"
    ''    wkSQL += vbNewLine + " and tm3.real_movie_id=tm.real_movie_id"
    ''    wkSQL += vbNewLine + " and tm3.confirm_flag='Y'"
    ''    wkSQL += vbNewLine + " ) AS trailer_amt, "
    ''    wkSQL += vbNewLine + " (select sum(isnull(a.CompRevenue_Adms, 0)) as CompRevenue_Adms"
    ''    wkSQL += vbNewLine + " from"
    ''    wkSQL += vbNewLine + " ("
    ''    wkSQL += vbNewLine + " 	select mas.circuit_id, mas.real_movie_id, mas.real_movie_amt, mas.movie_id, mas.trailer_amt, mas.Total_CompRevenue_Adms,"
    ''    wkSQL += vbNewLine + " 	CASE WHEN real_movie_amt > 0 THEN "
    ''    wkSQL += vbNewLine + " 		round((isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt)) / Convert(decimal(10,3),real_movie_amt))), 0)"
    ''    wkSQL += vbNewLine + " 	ELSE "
    ''    wkSQL += vbNewLine + " 		0 "
    ''    wkSQL += vbNewLine + " 	END CompRevenue_Adms"
    ''    wkSQL += vbNewLine + " 	from                                                                 "
    ''    wkSQL += vbNewLine + " 	(                                                          "
    ''    wkSQL += vbNewLine + " 		 SELECT  distinct tm1.circuit_id, tm1.real_movie_id, cd1.movie_id,"
    ''    wkSQL += vbNewLine + " 		 ("
    ''    wkSQL += vbNewLine + " 		 select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''    wkSQL += vbNewLine + " 		 from tbltrailer_master tm3 "
    ''    wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''    wkSQL += vbNewLine + " 		 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''    wkSQL += vbNewLine + " 		 left join tblTheater t on tm3.theater_id = t.theater_id"
    ''    wkSQL += vbNewLine + " 		 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''    wkSQL += vbNewLine + " 		 where 1=1"
    ''    wkSQL += vbNewLine + " 		 and cd3.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " 		 and t.circuit_id= cir.circuit_id"
    ''    wkSQL += vbNewLine + " 		 and tm3.theater_id = tm1.theater_id"
    ''    wkSQL += vbNewLine + " 		 and tm3.real_movie_id=tm1.real_movie_id"
    ''    wkSQL += vbNewLine + " 		 and tm3.confirm_flag='Y'"
    ''    wkSQL += vbNewLine + " 		 ) AS real_movie_amt"
    ''    wkSQL += vbNewLine + " 		 ,(select count (ttm1.collection_no)"
    ''    wkSQL += vbNewLine + " 		 FROM dbo.tblTrailer_Master AS ttm1 "
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblTrailer_Collection_Dtl AS d ON ttm1.collection_no = d.collection_no "
    ''    wkSQL += vbNewLine + " 		 left join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblTheater tt on ttm1.theater_id = tt.theater_id"
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblCircuit c ON tt.circuit_id = c.circuit_id"
    ''    wkSQL += vbNewLine + " 		 where ttm1.confirm_flag = 'Y'"
    ''    wkSQL += vbNewLine + " 		 and ttm1.real_movie_id = tm1.real_movie_id"
    ''    wkSQL += vbNewLine + " 		 and d.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " 		 and tt.circuit_id = cir.circuit_id"
    ''    wkSQL += vbNewLine + " 		 and d.movie_id = cd1.movie_id"
    ''    wkSQL += vbNewLine + " 		 and ch.theater_id = tm1.theater_id"
    ''    wkSQL += vbNewLine + " 		 ) trailer_amt"
    ''    wkSQL += vbNewLine + " 		 ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
    ''    wkSQL += vbNewLine + " 		 FROM tblCompRevenue"
    ''    wkSQL += vbNewLine + " 		 where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''    wkSQL += vbNewLine + " 		 and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''    wkSQL += vbNewLine + " 		 and tblCompRevenue.movies_id = tm1.real_movie_id  "
    ''    wkSQL += vbNewLine + " 		 and theater_id = tm1.theater_id"
    ''    wkSQL += vbNewLine + " 		 ) Total_CompRevenue_Adms"
    ''    wkSQL += vbNewLine + " 		 FROM dbo.tblTrailer_Master tm1"
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblTrailer_Collection_Dtl cd1 ON tm1.collection_no = cd1.collection_no "
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblMovie mv on mv.movie_id = tm1.real_movie_id"
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblTheater tt1 on tm1.theater_id = tt1.theater_id"
    ''    wkSQL += vbNewLine + " 		 left join dbo.tblCircuit c1 ON tt1.circuit_id = c1.circuit_id"
    ''    wkSQL += vbNewLine + " 		 where tm1.confirm_flag = 'Y'"
    ''    wkSQL += vbNewLine + " 		 and tm1.real_movie_id = tm.real_movie_id"
    ''    wkSQL += vbNewLine + " 		 and cd1.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " 		 and cd1.movie_id = cd.movie_id"
    ''    wkSQL += vbNewLine + " 		 and c1.circuit_id =  cir.circuit_id"
    ''    wkSQL += vbNewLine + " 		) as mas"
    ''    wkSQL += vbNewLine + " ) a "
    ''    wkSQL += vbNewLine + " ) CompRevenue_Adms"
    ''    wkSQL += vbNewLine + " FROM dbo.tblTrailer_Master AS tm "
    ''    wkSQL += vbNewLine + " left join dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
    ''    wkSQL += vbNewLine + " left join tblTheater ct on tm.theater_id = ct.theater_id"
    ''    wkSQL += vbNewLine + " left join tblCircuit cir on ct.circuit_id = cir.circuit_id "
    ''    wkSQL += vbNewLine + " where tm.confirm_flag = 'Y'"
    ''    wkSQL += vbNewLine + " and tm.real_movie_id = " + RealMovieID
    ''    wkSQL += vbNewLine + " and cd.ref_setup_no = '" + SetupNo + "' "
    ''    wkSQL += vbNewLine + " ) as mas"
    ''    wkSQL += vbNewLine + " ORDER BY circuit_name ASC, movie_percent DESC, Revenue_Adms DESC, CompRevenue_Adms DESC, trailer_amt DESC, Trailer_name ASC"
    ''    '--- End by Muay 2010-06-09 --------------------------------------------

    ''    Dim dtb As DataTable = cDatabase.GetDataTable(wkSQL)
    ''    Dim checkRow As Integer = 1

    ''    Dim intCircuitCount As Integer = 0
    ''    Dim sumReal As Integer = 0
    ''    Dim sumTrailer As Integer = 0
    ''    Dim SumPercent As Decimal = 0

    ''    Dim strCircuit As String = ""
    ''    Dim detailsRow As New TableRow()

    ''    Dim decSumAmount As Decimal = 0
    ''    Dim decSumPercent As Decimal = 0
    ''    Dim decSumAdms As Decimal = 0

    ''    Dim decSumTotalAmount As Decimal = 0
    ''    Dim decSumTotalAdms As Decimal = 0
    ''    Dim decSumTotalPercent As Decimal = 0

    ''    Dim aylSumTrailer As New ArrayList()
    ''    Dim hasSumTrailer As New Hashtable()
    ''    Dim hasSumTrailerAdms As New Hashtable()
    ''    Dim hasSumTrailerPercent As New Hashtable()
    ''    Dim hasSumTrailerPercent_Count As New Hashtable()
    ''    Dim hasIsCTBV As New Hashtable()

    ''    For i As Integer = 0 To dtb.Rows.Count - 1
    ''        'Circuit ใหม่
    ''        If (strCircuit <> Convert.ToString(dtb.Rows(i)("circuit_id"))) Then

    ''            'Write Sum
    ''            If strCircuit.Trim() <> "" Then
    ''                intCircuitCount = 0
    ''            End If

    ''            detailsRow = New TableRow()
    ''            detailsRow.HorizontalAlign = HorizontalAlign.Center
    ''            detailsRow.Font.Name = "Tahoma"
    ''            detailsRow.Font.Size = 10

    ''            ViewState("sumScreenAll") = ViewState("sumScreenAll") + dtb.Rows(i)("real_movie_amt")

    ''            detailsRow.Cells.Add(New TableCell)
    ''            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    ''            detailsRow.Cells(0).Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(dtb.Rows(i)("circuit_name")) + ": ฉาย " + Convert.ToString(dtb.Rows(i)("real_movie_amt")) + " จอ" '   จำนวนผู้ชม " + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms"))).ToString("#,##0") + " คน"
    ''            detailsRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
    ''            detailsRow.Cells(0).ForeColor = Color.FromName("#ffffff")
    ''            detailsRow.Cells(0).Font.Bold = True
    ''            detailsRow.Cells(0).Height = 25
    ''            detailsRow.Cells(0).ColumnSpan = 5
    ''            tbl.Rows.Add(detailsRow)

    ''            strCircuit = Convert.ToString(dtb.Rows(i)("circuit_id"))

    ''            decSumTotalAmount += decSumAmount
    ''            decSumTotalAdms += decSumAdms
    ''            decSumTotalPercent += decSumPercent

    ''            decSumAmount = 0
    ''            decSumPercent = 0
    ''            decSumAdms = 0
    ''        End If

    ''        detailsRow = New TableRow()
    ''        detailsRow.HorizontalAlign = HorizontalAlign.Center
    ''        detailsRow.Font.Name = "Tahoma"
    ''        detailsRow.Font.Size = 11

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(0).Width = 9
    ''        detailsRow.Cells(0).Text = ""
    ''        tbl.Rows.Add(detailsRow)

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
    ''        detailsRow.Cells(1).Text = "<a target='_self' href='frmRptTrailerByReleaseCircuit.aspx?circuitid=" + Convert.ToString(dtb.Rows(i)("circuit_id")) + "&movieid=" + Convert.ToString(dtb.Rows(i)("movie_id")) + "'>" + Convert.ToString(dtb.Rows(i)("Trailer_name")) + "</a>"
    ''        detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
    ''        detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
    ''        detailsRow.Cells(1).Font.Underline = False
    ''        detailsRow.Cells(1).Height = 20
    ''        detailsRow.Cells(1).ColumnSpan = 1

    ''        'เช็คผล sum ของหนังตัวอย่าง
    ''        If (hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) Is Nothing) Then
    ''            aylSumTrailer.Add(Convert.ToString(dtb.Rows(i)("Trailer_name")))
    ''            hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
    ''            hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")))
    ''            hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("movie_percent")))
    ''            hasSumTrailerPercent_Count(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = 1
    ''        Else
    ''            hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
    ''            hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")))
    ''            hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("movie_percent")))
    ''            hasSumTrailerPercent_Count(Convert.ToString(dtb.Rows(i)("Trailer_name"))) += 1
    ''        End If

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(2).Text = Convert.ToDecimal(dtb.Rows(i)("trailer_amt")).ToString("#,##0")
    ''        detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
    ''        detailsRow.Cells(2).ForeColor = Color.FromName("#000000")
    ''        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
    ''        detailsRow.Cells(2).Font.Bold = False
    ''        detailsRow.Cells(2).Height = 20
    ''        detailsRow.Cells(2).ColumnSpan = 1

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(3).Text = Convert.ToDecimal(dtb.Rows(i)("movie_percent")).ToString("#,##0.0")
    ''        detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
    ''        detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
    ''        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
    ''        detailsRow.Cells(3).Font.Bold = False
    ''        detailsRow.Cells(3).Height = 20
    ''        detailsRow.Cells(3).ColumnSpan = 1

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(4).Text = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms"))).ToString("#,##0")
    ''        detailsRow.Cells(4).BackColor = Color.FromName("#ffffff")
    ''        detailsRow.Cells(4).ForeColor = Color.FromName("#000000")
    ''        detailsRow.Cells(4).Font.Bold = False
    ''        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
    ''        detailsRow.Cells(4).Height = 20
    ''        detailsRow.Cells(4).ColumnSpan = 1

    ''        If (Convert.ToString(dtb.Rows(i)("IsCTBV")).Trim() = "1") Then
    ''            detailsRow.Cells(0).Font.Bold = True
    ''            detailsRow.Cells(1).Font.Bold = True
    ''            detailsRow.Cells(2).Font.Bold = True
    ''            detailsRow.Cells(3).Font.Bold = True
    ''            detailsRow.Cells(4).Font.Bold = True

    ''            hasIsCTBV(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = True
    ''        Else
    ''            detailsRow.Cells(0).Font.Bold = False
    ''            detailsRow.Cells(1).Font.Bold = False
    ''            detailsRow.Cells(2).Font.Bold = False
    ''            detailsRow.Cells(3).Font.Bold = False
    ''            detailsRow.Cells(4).Font.Bold = False
    ''        End If

    ''        tbl.Rows.Add(detailsRow)

    ''        decSumAmount += Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
    ''        decSumPercent += Convert.ToDecimal(dtb.Rows(i)("movie_percent"))
    ''        decSumAdms += Convert.ToDecimal(detailsRow.Cells(4).Text)

    ''        checkRow += 1
    ''        intCircuitCount += 1
    ''    Next

    ''    If (checkRow > 0) Then
    ''        If strCircuit.Trim() <> "" Then
    ''            decSumTotalAmount += decSumAmount
    ''            decSumTotalAdms += decSumAdms
    ''            decSumTotalPercent += decSumPercent
    ''        End If

    ''        detailsRow = New TableRow()
    ''        detailsRow.HorizontalAlign = HorizontalAlign.Center
    ''        detailsRow.Font.Name = "Tahoma"
    ''        detailsRow.Font.Size = 11

    ''        detailsRow.Cells.Add(New TableCell)
    ''        detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    ''        detailsRow.Cells(0).Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Total " + ViewState("sumScreenAll").ToString() + " จอ"
    ''        detailsRow.Cells(0).BackColor = Color.FromName("#C2D8FE")
    ''        detailsRow.Cells(0).ForeColor = Color.Black
    ''        detailsRow.Cells(0).Font.Bold = True
    ''        detailsRow.Cells(0).Height = 25
    ''        detailsRow.Cells(0).ColumnSpan = 5
    ''        tbl.Rows.Add(detailsRow)

    ''        Dim wkSQLTotal As String = ""

    ''        'wkSQLTotal = " SELECT mas.ref_setup_no, mas.real_movie_id,"
    ''        'wkSQLTotal += vbNewLine + " mas.real_movie_name, mas.movie_id, sum(Convert(decimal(10,3),mas.Total_Adms)) as Total_Adms, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.Total_Comp_Adms)) as Total_Comp_Adms, "
    ''        'wkSQLTotal += vbNewLine + " mas.Trailer_name, mas.IsCTBV, sum(Convert(decimal(10,3),mas.real_movie_amt)) as real_movie_amt, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.trailer_amt)) as trailer_amt,"
    ''        'wkSQLTotal += vbNewLine + " ((sum(Convert(decimal(10,3),mas.trailer_amt)) / " + ViewState("sumScreenAll").ToString() + ") * 100) as trailer_percent, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),Revenue_Adms)) as Revenue_Adms,"
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.CompRevenue_Adms)) as CompRevenue_Adms,"
    ''        'wkSQLTotal += vbNewLine + " CASE WHEN sum(Convert(decimal(10,3),mas.real_movie_amt)) > 0 THEN"
    ''        'wkSQLTotal += vbNewLine + " 	((sum(Convert(decimal(10,3),mas.trailer_amt)) * 100) / sum(Convert(decimal(10,3),mas.real_movie_amt))) "
    ''        'wkSQLTotal += vbNewLine + " ELSE "
    ''        'wkSQLTotal += vbNewLine + " 	0 "
    ''        'wkSQLTotal += vbNewLine + " END AS movie_percent"
    ''        'wkSQLTotal += vbNewLine + " FROM ("
    ''        'wkSQLTotal += vbNewLine + " select mas1.circuit_id, mas1.circuit_name, mas1.ref_setup_no, mas1.real_movie_id,"
    ''        'wkSQLTotal += vbNewLine + "  mas1.real_movie_name, mas1.movie_id, mas1.Total_Adms, mas1.Total_Comp_Adms, "
    ''        'wkSQLTotal += vbNewLine + "  mas1.Trailer_name, mas1.IsCTBV, mas1.real_movie_amt, mas1.trailer_amt,"
    ''        'wkSQLTotal += vbNewLine + "  dbo.funGetRevenue (mas1.ref_setup_no, mas1.circuit_id, mas1.real_movie_id, mas1.movie_id) Revenue_Adms,"
    ''        'wkSQLTotal += vbNewLine + "  mas1.CompRevenue_Adms,"
    ''        'wkSQLTotal += vbNewLine + "  CASE WHEN mas1.real_movie_amt > 0 THEN"
    ''        'wkSQLTotal += vbNewLine + " 	((Convert(decimal(10,3), mas1.trailer_amt) * 100) / Convert(decimal(10,3), mas1.real_movie_amt)) "
    ''        'wkSQLTotal += vbNewLine + "  ELSE "
    ''        'wkSQLTotal += vbNewLine + " 	0 "
    ''        'wkSQLTotal += vbNewLine + "  END AS movie_percent"
    ''        'wkSQLTotal += vbNewLine + "  from"
    ''        'wkSQLTotal += vbNewLine + "  ("
    ''        'wkSQLTotal += vbNewLine + "  SELECT  distinct  tm.circuit_id,dbo.tblCircuit.circuit_name, cd.ref_setup_no,  tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + "  , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = tm.real_movie_id) as real_movie_name"
    ''        'wkSQLTotal += vbNewLine + "  , cd.movie_id"
    ''        'wkSQLTotal += vbNewLine + "  , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
    ''        'wkSQLTotal += vbNewLine + "  , (select top 1 movietype_id from tblmovie where tblmovie.movie_id = cd.movie_id) as IsCTBV"
    ''        'wkSQLTotal += vbNewLine + "  ,(select isnull(sum(isnull(revenue_adms,0)),0) Total_Adms"
    ''        'wkSQLTotal += vbNewLine + "  FROM tblRevenue"
    ''        'wkSQLTotal += vbNewLine + "  where 	convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + "  and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + "  and tblRevenue.movies_id = tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + "  ) Total_Adms,"
    ''        'wkSQLTotal += vbNewLine + "  (select isnull(sum(isnull(comprevenue_admssum,0)),0) Total_Comp_Adms"
    ''        'wkSQLTotal += vbNewLine + "  FROM tblCompRevenue"
    ''        'wkSQLTotal += vbNewLine + "  where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + "  and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + "  and tblCompRevenue.movies_id = tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + "  ) Total_Comp_Adms"
    ''        'wkSQLTotal += vbNewLine + "  ,("
    ''        'wkSQLTotal += vbNewLine + "  select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        'wkSQLTotal += vbNewLine + "  from tbltrailer_master tm3 "
    ''        'wkSQLTotal += vbNewLine + "  left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        'wkSQLTotal += vbNewLine + "  left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        'wkSQLTotal += vbNewLine + "  where 1=1"
    ''        'wkSQLTotal += vbNewLine + "  and cd3.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + "  and tm3.circuit_id= tm.circuit_id"
    ''        'wkSQLTotal += vbNewLine + "  and tm3.real_movie_id=tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + "  and tm3.confirm_flag='Y'"
    ''        'wkSQLTotal += vbNewLine + "  ) AS real_movie_amt,"
    ''        'wkSQLTotal += vbNewLine + "  ("
    ''        'wkSQLTotal += vbNewLine + "  select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        'wkSQLTotal += vbNewLine + "  from tbltrailer_master tm3 "
    ''        'wkSQLTotal += vbNewLine + "  left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        'wkSQLTotal += vbNewLine + "  left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        'wkSQLTotal += vbNewLine + "  where 1=1"
    ''        'wkSQLTotal += vbNewLine + "  and cd3.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + "  and cd3.movie_id=cd.movie_id"
    ''        'wkSQLTotal += vbNewLine + "  and tm3.circuit_id= tm.circuit_id"
    ''        'wkSQLTotal += vbNewLine + "  and tm3.real_movie_id=tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + "  and tm3.confirm_flag='Y'"
    ''        'wkSQLTotal += vbNewLine + "  ) AS trailer_amt, "
    ''        'wkSQLTotal += vbNewLine + " (select sum(isnull(a.CompRevenue_Adms, 0)) as CompRevenue_Adms"
    ''        'wkSQLTotal += vbNewLine + "  from"
    ''        'wkSQLTotal += vbNewLine + "  ("
    ''        'wkSQLTotal += vbNewLine + "   select mas.circuit_id, mas.real_movie_id, mas.real_movie_amt, mas.movie_id, mas.trailer_amt, mas.Total_CompRevenue_Adms,"
    ''        'wkSQLTotal += vbNewLine + "   CASE WHEN real_movie_amt > 0 THEN "
    ''        'wkSQLTotal += vbNewLine + " 		round((isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt)) / Convert(decimal(10,3),real_movie_amt))), 0)"
    ''        'wkSQLTotal += vbNewLine + "   ELSE "
    ''        'wkSQLTotal += vbNewLine + " 		0 "
    ''        'wkSQLTotal += vbNewLine + "   END CompRevenue_Adms"
    ''        'wkSQLTotal += vbNewLine + "   from                                                                 "
    ''        'wkSQLTotal += vbNewLine + "   (                                                          "
    ''        'wkSQLTotal += vbNewLine + " 	 SELECT  distinct tm1.circuit_id, tm1.real_movie_id, cd1.movie_id,"
    ''        'wkSQLTotal += vbNewLine + " 	 ("
    ''        'wkSQLTotal += vbNewLine + " 	 select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        'wkSQLTotal += vbNewLine + " 	 from tbltrailer_master tm3 "
    ''        'wkSQLTotal += vbNewLine + " 	 left outer join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        'wkSQLTotal += vbNewLine + " 	 left outer join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        'wkSQLTotal += vbNewLine + " 	 where 1=1"
    ''        'wkSQLTotal += vbNewLine + " 	 and cd3.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + " 	 and tm3.circuit_id= tm1.circuit_id"
    ''        'wkSQLTotal += vbNewLine + " 	 and tm3.theater_id = tm1.theater_id"
    ''        'wkSQLTotal += vbNewLine + " 	 and tm3.real_movie_id=tm1.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 and tm3.confirm_flag='Y'"
    ''        'wkSQLTotal += vbNewLine + " 	 ) AS real_movie_amt"
    ''        'wkSQLTotal += vbNewLine + " 	 ,(select count (ttm1.collection_no)"
    ''        'wkSQLTotal += vbNewLine + " 	 FROM         dbo.tblTrailer_Master AS ttm1 INNER JOIN dbo.tblTrailer_Collection_Dtl AS d ON ttm1.collection_no = d.collection_no "
    ''        'wkSQLTotal += vbNewLine + " 	 inner join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
    ''        'wkSQLTotal += vbNewLine + " 	 INNER JOIN dbo.tblCircuit ON ttm1.circuit_id = dbo.tblCircuit.circuit_id"
    ''        'wkSQLTotal += vbNewLine + " 	 WHERE ttm1.confirm_flag = 'Y'"
    ''        'wkSQLTotal += vbNewLine + " 	 AND ttm1.real_movie_id = tm1.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 AND d.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + " 	 and ttm1.circuit_id = tm1.circuit_id"
    ''        'wkSQLTotal += vbNewLine + " 	 and d.movie_id = cd1.movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 and ch.theater_id = tm1.theater_id"
    ''        'wkSQLTotal += vbNewLine + " 	 ) trailer_amt"
    ''        'wkSQLTotal += vbNewLine + " 	 ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
    ''        'wkSQLTotal += vbNewLine + " 	 FROM tblCompRevenue"
    ''        'wkSQLTotal += vbNewLine + " 	 where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + " 	 and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''        'wkSQLTotal += vbNewLine + " 	 and tblCompRevenue.movies_id = tm1.real_movie_id  "
    ''        'wkSQLTotal += vbNewLine + " 	 and theater_id = tm1.theater_id"
    ''        'wkSQLTotal += vbNewLine + " 	 ) Total_CompRevenue_Adms"
    ''        'wkSQLTotal += vbNewLine + " 	 FROM	dbo.tblTrailer_Master tm1"
    ''        'wkSQLTotal += vbNewLine + " 	 INNER JOIN dbo.tblTrailer_Collection_Dtl cd1 ON tm1.collection_no = cd1.collection_no "
    ''        'wkSQLTotal += vbNewLine + " 	 INNER JOIN dbo.tblCircuit ON tm1.circuit_id = dbo.tblCircuit.circuit_id"
    ''        'wkSQLTotal += vbNewLine + " 	 INNER JOIN dbo.tblTheater tt on tt.theater_id = tm1.theater_id"
    ''        'wkSQLTotal += vbNewLine + " 	 inner join dbo.tblMovie mv on mv.movie_id = tm1.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 WHERE     tm1.confirm_flag = 'Y'"
    ''        'wkSQLTotal += vbNewLine + " 	 AND tm1.real_movie_id = tm.real_movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 AND cd1.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + " 	 AND cd1.movie_id = cd.movie_id"
    ''        'wkSQLTotal += vbNewLine + " 	 AND tm1.circuit_id =  tm.circuit_id"
    ''        'wkSQLTotal += vbNewLine + "    ) as mas"
    ''        'wkSQLTotal += vbNewLine + "  ) a "
    ''        'wkSQLTotal += vbNewLine + "  ) CompRevenue_Adms"
    ''        'wkSQLTotal += vbNewLine + "  FROM dbo.tblTrailer_Master AS tm "
    ''        'wkSQLTotal += vbNewLine + "  INNER JOIN dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
    ''        'wkSQLTotal += vbNewLine + "  INNER JOIN dbo.tblCircuit ON tm.circuit_id = dbo.tblCircuit.circuit_id"
    ''        'wkSQLTotal += vbNewLine + "  WHERE tm.confirm_flag = 'Y'"
    ''        'wkSQLTotal += vbNewLine + "  AND tm.real_movie_id =" + RealMovieID
    ''        'wkSQLTotal += vbNewLine + "  AND cd.ref_setup_no = '" + SetupNo + "' "
    ''        'wkSQLTotal += vbNewLine + "  ) as mas1 ) mas"
    ''        'wkSQLTotal += vbNewLine + " GROUP BY mas.ref_setup_no,  mas.real_movie_name, mas.real_movie_id, mas.movie_id,"
    ''        'wkSQLTotal += vbNewLine + "  mas.Trailer_name, mas.IsCTBV "
    ''        'wkSQLTotal += vbNewLine + " ORDER BY trailer_percent DESC, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.Revenue_Adms)) DESC, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.CompRevenue_Adms)) DESC, "
    ''        'wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.trailer_amt)) DESC, mas.Trailer_name ASC"


    ''        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
    ''        wkSQLTotal = " SELECT mas.ref_setup_no, mas.real_movie_id,"
    ''        wkSQLTotal += vbNewLine + " mas.real_movie_name, mas.movie_id, sum(Convert(decimal(10,3),mas.Total_Adms)) as Total_Adms, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.Total_Comp_Adms)) as Total_Comp_Adms, "
    ''        wkSQLTotal += vbNewLine + " mas.Trailer_name, mas.IsCTBV, sum(Convert(decimal(10,3),mas.real_movie_amt)) as real_movie_amt, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.trailer_amt)) as trailer_amt,"
    ''        wkSQLTotal += vbNewLine + " ((sum(Convert(decimal(10,3),mas.trailer_amt)) / 52) * 100) as trailer_percent, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),Revenue_Adms)) as Revenue_Adms,"
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.CompRevenue_Adms)) as CompRevenue_Adms,"
    ''        wkSQLTotal += vbNewLine + " CASE WHEN sum(Convert(decimal(10,3),mas.real_movie_amt)) > 0 THEN"
    ''        wkSQLTotal += vbNewLine + " ((sum(Convert(decimal(10,3),mas.trailer_amt)) * 100) / sum(Convert(decimal(10,3),mas.real_movie_amt))) "
    ''        wkSQLTotal += vbNewLine + " ELSE "
    ''        wkSQLTotal += vbNewLine + " 0 "
    ''        wkSQLTotal += vbNewLine + " END AS movie_percent"
    ''        wkSQLTotal += vbNewLine + " FROM ("
    ''        wkSQLTotal += vbNewLine + " select mas1.circuit_id, mas1.circuit_name, mas1.ref_setup_no, mas1.real_movie_id,"
    ''        wkSQLTotal += vbNewLine + " mas1.real_movie_name, mas1.movie_id, mas1.Total_Adms, mas1.Total_Comp_Adms, "
    ''        wkSQLTotal += vbNewLine + " mas1.Trailer_name, mas1.IsCTBV, mas1.real_movie_amt, mas1.trailer_amt,"
    ''        wkSQLTotal += vbNewLine + " dbo.funGetRevenue (mas1.ref_setup_no, mas1.circuit_id, mas1.real_movie_id, mas1.movie_id) Revenue_Adms,"
    ''        wkSQLTotal += vbNewLine + " mas1.CompRevenue_Adms,"
    ''        wkSQLTotal += vbNewLine + " CASE WHEN mas1.real_movie_amt > 0 THEN"
    ''        wkSQLTotal += vbNewLine + " ((Convert(decimal(10,3), mas1.trailer_amt) * 100) / Convert(decimal(10,3), mas1.real_movie_amt)) "
    ''        wkSQLTotal += vbNewLine + " ELSE "
    ''        wkSQLTotal += vbNewLine + " 0 "
    ''        wkSQLTotal += vbNewLine + " END AS movie_percent"
    ''        wkSQLTotal += vbNewLine + " from"
    ''        wkSQLTotal += vbNewLine + " ("
    ''        wkSQLTotal += vbNewLine + " 	  SELECT  distinct  cca.circuit_id, cca.circuit_name, cd.ref_setup_no,  tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = tm.real_movie_id) as real_movie_name"
    ''        wkSQLTotal += vbNewLine + " 	  , cd.movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  , (select top 1 movie_nameen from tblmovie where tblmovie.movie_id = cd.movie_id) as Trailer_name"
    ''        wkSQLTotal += vbNewLine + " 	  , (select top 1 movietype_id from tblmovie where tblmovie.movie_id = cd.movie_id) as IsCTBV"
    ''        wkSQLTotal += vbNewLine + " 	  ,(select isnull(sum(isnull(revenue_adms,0)),0) Total_Adms"
    ''        wkSQLTotal += vbNewLine + " 	  FROM tblRevenue"
    ''        wkSQLTotal += vbNewLine + " 	  where 	convert(varchar(20),revenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 	  and convert(varchar(20),revenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 	  and tblRevenue.movies_id = tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  ) Total_Adms,"
    ''        wkSQLTotal += vbNewLine + " 	  (select isnull(sum(isnull(comprevenue_admssum,0)),0) Total_Comp_Adms"
    ''        wkSQLTotal += vbNewLine + " 	  FROM tblCompRevenue"
    ''        wkSQLTotal += vbNewLine + " 	  where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 	  and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 	  and tblCompRevenue.movies_id = tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  ) Total_Comp_Adms"
    ''        wkSQLTotal += vbNewLine + " 	  ,("
    ''        wkSQLTotal += vbNewLine + " 	  select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        wkSQLTotal += vbNewLine + " 	  from tbltrailer_master tm3 "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTheater t on tm3.theater_id = t.theater_id"
    ''        wkSQLTotal += vbNewLine + " 	  left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 	  where 1=1"
    ''        wkSQLTotal += vbNewLine + " 	  and cd3.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 	  and t.circuit_id = cca.circuit_id"
    ''        wkSQLTotal += vbNewLine + " 	  and tm3.real_movie_id=tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  and tm3.confirm_flag='Y'"
    ''        wkSQLTotal += vbNewLine + " 	  ) AS real_movie_amt,"
    ''        wkSQLTotal += vbNewLine + " 	  ("
    ''        wkSQLTotal += vbNewLine + " 	  select count (distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        wkSQLTotal += vbNewLine + " 	  from tbltrailer_master tm3 "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTheater t on tm3.theater_id = t.theater_id"
    ''        wkSQLTotal += vbNewLine + " 	  left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 	  where 1=1"
    ''        wkSQLTotal += vbNewLine + " 	  and cd3.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 	  and cd3.movie_id=cd.movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  and t.circuit_id= cca.circuit_id"
    ''        wkSQLTotal += vbNewLine + " 	  and tm3.real_movie_id=tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 	  and tm3.confirm_flag='Y'"
    ''        wkSQLTotal += vbNewLine + " 	  ) AS trailer_amt, "
    ''        wkSQLTotal += vbNewLine + " 	 (select sum(isnull(a.CompRevenue_Adms, 0)) as CompRevenue_Adms"
    ''        wkSQLTotal += vbNewLine + " 	  from"
    ''        wkSQLTotal += vbNewLine + " 		  ("
    ''        wkSQLTotal += vbNewLine + " 			   select mas.circuit_id, mas.real_movie_id, mas.real_movie_amt, mas.movie_id, mas.trailer_amt, mas.Total_CompRevenue_Adms,"
    ''        wkSQLTotal += vbNewLine + " 			   CASE WHEN real_movie_amt > 0 THEN "
    ''        wkSQLTotal += vbNewLine + "                     round((isnull(Total_CompRevenue_Adms, 0) * ((Convert(decimal(10,3),trailer_amt)) / Convert(decimal(10,3),real_movie_amt))), 0)"
    ''        wkSQLTotal += vbNewLine + " 			   ELSE "
    ''        wkSQLTotal += vbNewLine + "                     0 "
    ''        wkSQLTotal += vbNewLine + " 			   END CompRevenue_Adms"
    ''        wkSQLTotal += vbNewLine + " 			   from                                                                 "
    ''        wkSQLTotal += vbNewLine + " 			   (                                                          "
    ''        wkSQLTotal += vbNewLine + " 				 SELECT  distinct tt1.circuit_id, tm1.real_movie_id, cd1.movie_id,"
    ''        wkSQLTotal += vbNewLine + " 				 ("
    ''        wkSQLTotal += vbNewLine + " 				 select count(distinct(convert(varchar(200),tm3.theater_id)+'_'+convert(varchar(200),tm3.theatersub_id)))"
    ''        wkSQLTotal += vbNewLine + " 				 from tbltrailer_master tm3 "
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTrailer_Collection_Dtl cd3 on tm3.collection_no = cd3.collection_no "
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTrailer_Collection_Hdr ch3 on cd3.collection_no = ch3.collection_no"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTheater t on tm3.theater_id = t.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 				 where 1=1"
    ''        wkSQLTotal += vbNewLine + " 				 and cd3.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 				 and t.circuit_id= tt1.circuit_id"
    ''        wkSQLTotal += vbNewLine + " 				 and tm3.theater_id = tm1.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 and tm3.real_movie_id=tm1.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 and tm3.confirm_flag='Y'"
    ''        wkSQLTotal += vbNewLine + " 				 ) AS real_movie_amt"
    ''        wkSQLTotal += vbNewLine + " 				 ,(select count (ttm1.collection_no)"
    ''        wkSQLTotal += vbNewLine + " 				 FROM dbo.tblTrailer_Master AS ttm1 "
    ''        wkSQLTotal += vbNewLine + " 				 left join dbo.tblTrailer_Collection_Dtl AS d ON ttm1.collection_no = d.collection_no "
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTrailer_Collection_Hdr as ch on d.collection_no = ch.collection_no"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTheater t on ttm1.theater_id = t.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblCircuit cc on t.circuit_id = cc.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 				 WHERE ttm1.confirm_flag = 'Y'"
    ''        wkSQLTotal += vbNewLine + " 				 AND ttm1.real_movie_id = tm1.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 AND d.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 				 and t.circuit_id = tt1.circuit_id"
    ''        wkSQLTotal += vbNewLine + " 				 and d.movie_id = cd1.movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 and ch.theater_id = tm1.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 ) trailer_amt"
    ''        wkSQLTotal += vbNewLine + " 				 ,(select isnull(sum(isnull(comprevenue_admssum,0)),0) as Total_CompRevenue_Adms"
    ''        wkSQLTotal += vbNewLine + " 				 FROM tblCompRevenue"
    ''        wkSQLTotal += vbNewLine + " 				 where convert(varchar(20),comprevenue_date,111)>=(select convert(varchar(19),setup_start_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 				 and convert(varchar(20),comprevenue_date,111)<=(select convert(varchar(19),setup_end_date,111) from tblTrailer_Setup_Hdr where setup_no = cd1.ref_setup_no)"
    ''        wkSQLTotal += vbNewLine + " 				 and tblCompRevenue.movies_id = tm1.real_movie_id  "
    ''        wkSQLTotal += vbNewLine + " 				 and theater_id = tm1.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 ) Total_CompRevenue_Adms"
    ''        wkSQLTotal += vbNewLine + " 				 FROM	dbo.tblTrailer_Master tm1"
    ''        wkSQLTotal += vbNewLine + " 				 left join dbo.tblTrailer_Collection_Dtl cd1 ON tm1.collection_no = cd1.collection_no "
    ''        wkSQLTotal += vbNewLine + " 				 left join dbo.tblMovie mv on mv.movie_id = tm1.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblTheater tt1 on tm1.theater_id = tt1.theater_id"
    ''        wkSQLTotal += vbNewLine + " 				 left join tblCircuit cc1 on tt1.circuit_id = cc1.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 				 WHERE  tm1.confirm_flag = 'Y'"
    ''        wkSQLTotal += vbNewLine + " 				 AND tm1.real_movie_id = tm.real_movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 AND cd1.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 				 AND cd1.movie_id = cd.movie_id"
    ''        wkSQLTotal += vbNewLine + " 				 AND tt1.circuit_id =  cca.circuit_id"
    ''        wkSQLTotal += vbNewLine + " 				) as mas"
    ''        wkSQLTotal += vbNewLine + " 		  ) a "
    ''        wkSQLTotal += vbNewLine + " 	  ) CompRevenue_Adms"
    ''        wkSQLTotal += vbNewLine + " 	  FROM  tblTrailer_Master AS tm "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
    ''        wkSQLTotal += vbNewLine + " 	  left join tblTheater tta on tm.theater_id = tta.theater_id"
    ''        wkSQLTotal += vbNewLine + " 	  left join tblCircuit cca on tta.circuit_id = cca.circuit_id "
    ''        wkSQLTotal += vbNewLine + " 	  WHERE tm.confirm_flag = 'Y'"
    ''        wkSQLTotal += vbNewLine + " 	  AND tm.real_movie_id = " + RealMovieID
    ''        wkSQLTotal += vbNewLine + " 	  AND cd.ref_setup_no = '" + SetupNo + "'"
    ''        wkSQLTotal += vbNewLine + " 	  ) as mas1 "
    ''        wkSQLTotal += vbNewLine + " ) mas"
    ''        wkSQLTotal += vbNewLine + " GROUP BY mas.ref_setup_no,  mas.real_movie_name, mas.real_movie_id, mas.movie_id,"
    ''        wkSQLTotal += vbNewLine + " mas.Trailer_name, mas.IsCTBV "
    ''        wkSQLTotal += vbNewLine + " ORDER BY trailer_percent DESC, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.Revenue_Adms)) DESC, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.CompRevenue_Adms)) DESC, "
    ''        wkSQLTotal += vbNewLine + " sum(Convert(decimal(10,3),mas.trailer_amt)) DESC, mas.Trailer_name ASC"
    ''        '--- End by Muay 2010-06-09 --------------------------------------------

    ''        Dim dtbTotal As DataTable = cDatabase.GetDataTable(wkSQLTotal)
    ''        Dim detailsRowTotal As New TableRow()

    ''        For i As Integer = 0 To dtbTotal.Rows.Count - 1
    ''            detailsRowTotal = New TableRow()
    ''            detailsRowTotal.HorizontalAlign = HorizontalAlign.Center
    ''            detailsRowTotal.Font.Name = "Tahoma"
    ''            detailsRowTotal.Font.Size = 11

    ''            detailsRowTotal.Cells.Add(New TableCell)
    ''            detailsRowTotal.Cells(0).Width = 9
    ''            detailsRowTotal.Cells(0).Text = ""
    ''            detailsRowTotal.Cells(0).BackColor = Color.FromName("#DBE5F1")
    ''            detailsRowTotal.Cells(0).ForeColor = Color.Black
    ''            tbl.Rows.Add(detailsRowTotal)

    ''            detailsRowTotal.Cells.Add(New TableCell)
    ''            detailsRowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Left
    ''            detailsRowTotal.Cells(1).Text = Convert.ToString(dtbTotal.Rows(i)("Trailer_name"))
    ''            detailsRowTotal.Cells(1).BackColor = Color.FromName("#DBE5F1")
    ''            detailsRowTotal.Cells(1).ForeColor = Color.Black
    ''            detailsRowTotal.Cells(1).Font.Underline = False
    ''            detailsRowTotal.Cells(1).Height = 20
    ''            'detailsRowTotal.Cells(1).Width = 450
    ''            detailsRowTotal.Cells(1).ColumnSpan = 1


    ''            detailsRowTotal.Cells.Add(New TableCell)
    ''            detailsRowTotal.Cells(2).Text = Convert.ToDecimal(dtbTotal.Rows(i)("trailer_amt")).ToString("#,##0")
    ''            detailsRowTotal.Cells(2).BackColor = Color.FromName("#DBE5F1")
    ''            detailsRowTotal.Cells(2).ForeColor = Color.Black
    ''            detailsRowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Center
    ''            detailsRowTotal.Cells(2).Font.Bold = False
    ''            detailsRowTotal.Cells(2).Height = 20
    ''            detailsRowTotal.Cells(2).ColumnSpan = 1

    ''            detailsRowTotal.Cells.Add(New TableCell)
    ''            'detailsRowTotal.Cells(3).Text = Convert.ToDecimal(dtbTotal.Rows(i)("trailer_percent")).ToString("#,##0.0")
    ''            detailsRowTotal.Cells(3).Text = ((Convert.ToDecimal(dtbTotal.Rows(i)("trailer_amt")) / Convert.ToDecimal(ViewState("sumScreenAll"))) * 100).ToString("#,##0.0")
    ''            detailsRowTotal.Cells(3).BackColor = Color.FromName("#DBE5F1")
    ''            detailsRowTotal.Cells(3).ForeColor = Color.Black
    ''            detailsRowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Center
    ''            detailsRowTotal.Cells(3).Font.Bold = False
    ''            detailsRowTotal.Cells(3).Height = 20
    ''            detailsRowTotal.Cells(3).ColumnSpan = 1

    ''            detailsRowTotal.Cells.Add(New TableCell)
    ''            detailsRowTotal.Cells(4).Text = Convert.ToDecimal(Convert.ToDecimal(dtbTotal.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtbTotal.Rows(i)("CompRevenue_Adms"))).ToString("#,##0")
    ''            detailsRowTotal.Cells(4).BackColor = Color.FromName("#DBE5F1")
    ''            detailsRowTotal.Cells(4).ForeColor = Color.Black
    ''            detailsRowTotal.Cells(4).Font.Bold = False
    ''            detailsRowTotal.Cells(4).HorizontalAlign = HorizontalAlign.Center
    ''            detailsRowTotal.Cells(4).Height = 20
    ''            detailsRowTotal.Cells(4).ColumnSpan = 1

    ''            If (Convert.ToString(dtbTotal.Rows(i)("IsCTBV")).Trim() = "1") Then
    ''                detailsRowTotal.Cells(0).Font.Bold = True
    ''                detailsRowTotal.Cells(1).Font.Bold = True
    ''                detailsRowTotal.Cells(2).Font.Bold = True
    ''                detailsRowTotal.Cells(3).Font.Bold = True
    ''                detailsRowTotal.Cells(4).Font.Bold = True

    ''                hasIsCTBV(Convert.ToString(dtbTotal.Rows(i)("Trailer_name"))) = True
    ''            Else
    ''                detailsRowTotal.Cells(0).Font.Bold = False
    ''                detailsRowTotal.Cells(1).Font.Bold = False
    ''                detailsRowTotal.Cells(2).Font.Bold = False
    ''                detailsRowTotal.Cells(3).Font.Bold = False
    ''                detailsRowTotal.Cells(4).Font.Bold = False
    ''            End If

    ''            tbl.Rows.Add(detailsRowTotal)
    ''        Next
    ''    End If

    ''End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        Dim cDB As New cDatabase
        Dim RealMovieID As String = Session("rptRealMovie").ToString
        Dim SetupNo As String = Session("rptSetupNo").ToString
        Dim RealName As String = ""

        'If Not IsPostBack Then
        ViewState("sumScreenAll") = 0
        'End If

        'Dim drTrailer As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + TrailerMovieID)
        'If drTrailer.Read Then
        '    SetupNo = drTrailer("movie_nameen").ToString
        'End If
        'drTrailer.Close()

        Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
        If drReal.Read Then
            RealName = drReal("movie_nameen").ToString
        End If
        drReal.Close()

        tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
        tbl.Rows(2).Cells(0).Text = RealName
        tbl.Rows(3).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString

        Dim dtb As DataTable = cDatabase.GetDataTable("exec spGetRptTrailerByRelease " _
                                                           + " " + RealMovieID + "" _
                                                           + ", '" + SetupNo + "'" _
                                                           + ", '" + "Main_Report" + "'")

        Dim checkRow As Integer = 1

        Dim intCircuitCount As Integer = 0
        Dim sumReal As Integer = 0
        Dim sumTrailer As Integer = 0
        Dim SumPercent As Decimal = 0

        Dim strCircuit As String = ""
        Dim detailsRow As New TableRow()

        Dim decSumAmount As Decimal = 0
        Dim decSumPercent As Decimal = 0
        Dim decSumAdms As Decimal = 0

        Dim decSumTotalAmount As Decimal = 0
        Dim decSumTotalAdms As Decimal = 0
        Dim decSumTotalPercent As Decimal = 0

        Dim aylSumTrailer As New ArrayList()
        Dim hasSumTrailer As New Hashtable()
        Dim hasSumTrailerAdms As New Hashtable()
        Dim hasSumTrailerPercent As New Hashtable()
        Dim hasSumTrailerPercent_Count As New Hashtable()
        Dim hasIsCTBV As New Hashtable()

        For i As Integer = 0 To dtb.Rows.Count - 1
            'Circuit ใหม่
            If (strCircuit <> Convert.ToString(dtb.Rows(i)("circuit_id"))) Then

                'Write Sum
                If strCircuit.Trim() <> "" Then
                    intCircuitCount = 0
                End If

                detailsRow = New TableRow()
                detailsRow.HorizontalAlign = HorizontalAlign.Center
                detailsRow.Font.Name = "Tahoma"
                detailsRow.Font.Size = 10

                ViewState("sumScreenAll") = ViewState("sumScreenAll") + dtb.Rows(i)("real_movie_amt")

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                detailsRow.Cells(0).Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Convert.ToString(dtb.Rows(i)("circuit_name")) + ": ฉาย " + Convert.ToString(dtb.Rows(i)("real_movie_amt")) + " จอ" '   จำนวนผู้ชม " + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms"))).ToString("#,##0") + " คน"
                detailsRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                detailsRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(0).Height = 25
                detailsRow.Cells(0).ColumnSpan = 5
                tbl.Rows.Add(detailsRow)

                strCircuit = Convert.ToString(dtb.Rows(i)("circuit_id"))

                decSumTotalAmount += decSumAmount
                decSumTotalAdms += decSumAdms
                decSumTotalPercent += decSumPercent

                decSumAmount = 0
                decSumPercent = 0
                decSumAdms = 0
            End If

            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).Width = 9
            detailsRow.Cells(0).Text = ""
            ''tbl.Rows.Add(detailsRow)

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(1).Text = "<a target='_self' href='frmRptTrailerByReleaseCircuit.aspx?circuitid=" + Convert.ToString(dtb.Rows(i)("circuit_id")) + "&movieid=" + Convert.ToString(dtb.Rows(i)("movie_id")) + "'>" + Convert.ToString(dtb.Rows(i)("Trailer_name")) + "</a>"
            detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(1).Font.Underline = False
            detailsRow.Cells(1).Height = 20
            detailsRow.Cells(1).ColumnSpan = 1

            'เช็คผล sum ของหนังตัวอย่าง
            If (hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) Is Nothing) Then
                aylSumTrailer.Add(Convert.ToString(dtb.Rows(i)("Trailer_name")))
                hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
                hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")))
                hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("movie_percent")))
                hasSumTrailerPercent_Count(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = 1
            Else
                hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailer(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
                hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailerAdms(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms")))
                hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = Convert.ToDecimal(hasSumTrailerPercent(Convert.ToString(dtb.Rows(i)("Trailer_name")))) + Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("movie_percent")))
                hasSumTrailerPercent_Count(Convert.ToString(dtb.Rows(i)("Trailer_name"))) += 1
            End If

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).Text = Convert.ToDecimal(dtb.Rows(i)("trailer_amt")).ToString("#,##0")
            detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(2).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(2).Font.Bold = False
            detailsRow.Cells(2).Height = 20
            detailsRow.Cells(2).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).Text = Convert.ToDecimal(dtb.Rows(i)("movie_percent")).ToString("#,##0.0")
            detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(3).Font.Bold = False
            detailsRow.Cells(3).Height = 20
            detailsRow.Cells(3).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(4).Text = Convert.ToDecimal(Convert.ToDecimal(dtb.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtb.Rows(i)("CompRevenue_Adms"))).ToString("#,##0")
            detailsRow.Cells(4).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(4).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(4).Font.Bold = False
            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(4).Height = 20
            detailsRow.Cells(4).ColumnSpan = 1

            If (Convert.ToString(dtb.Rows(i)("IsCTBV")).Trim() = "1") Then
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(1).Font.Bold = True
                detailsRow.Cells(2).Font.Bold = True
                detailsRow.Cells(3).Font.Bold = True
                detailsRow.Cells(4).Font.Bold = True

                hasIsCTBV(Convert.ToString(dtb.Rows(i)("Trailer_name"))) = True
            Else
                detailsRow.Cells(0).Font.Bold = False
                detailsRow.Cells(1).Font.Bold = False
                detailsRow.Cells(2).Font.Bold = False
                detailsRow.Cells(3).Font.Bold = False
                detailsRow.Cells(4).Font.Bold = False
            End If

            tbl.Rows.Add(detailsRow)

            decSumAmount += Convert.ToDecimal(dtb.Rows(i)("trailer_amt"))
            decSumPercent += Convert.ToDecimal(dtb.Rows(i)("movie_percent"))
            decSumAdms += Convert.ToDecimal(detailsRow.Cells(4).Text)

            checkRow += 1
            intCircuitCount += 1
        Next

        If (checkRow > 0) Then
            If strCircuit.Trim() <> "" Then
                decSumTotalAmount += decSumAmount
                decSumTotalAdms += decSumAdms
                decSumTotalPercent += decSumPercent
            End If

            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(0).Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "Total " + ViewState("sumScreenAll").ToString() + " จอ"
            detailsRow.Cells(0).BackColor = Color.FromName("#C2D8FE")
            detailsRow.Cells(0).ForeColor = Color.Black
            detailsRow.Cells(0).Font.Bold = True
            detailsRow.Cells(0).Height = 25
            detailsRow.Cells(0).ColumnSpan = 5
            tbl.Rows.Add(detailsRow)

            Dim dtbTotal As DataTable = cDatabase.GetDataTable("exec spGetRptTrailerByRelease " _
                                                           + " " + RealMovieID + "" _
                                                           + ", '" + SetupNo + "'" _
                                                           + ", '" + "Report_Summary" + "'")

            Dim detailsRowTotal As New TableRow()

            For i As Integer = 0 To dtbTotal.Rows.Count - 1
                detailsRowTotal = New TableRow()
                detailsRowTotal.HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Font.Name = "Tahoma"
                detailsRowTotal.Font.Size = 11

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(0).Width = 9
                detailsRowTotal.Cells(0).Text = ""
                detailsRowTotal.Cells(0).BackColor = Color.FromName("#DBE5F1")
                detailsRowTotal.Cells(0).ForeColor = Color.Black
                ''tbl.Rows.Add(detailsRowTotal)

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Left
                detailsRowTotal.Cells(1).Text = Convert.ToString(dtbTotal.Rows(i)("Trailer_name"))
                detailsRowTotal.Cells(1).BackColor = Color.FromName("#DBE5F1")
                detailsRowTotal.Cells(1).ForeColor = Color.Black
                detailsRowTotal.Cells(1).Font.Underline = False
                detailsRowTotal.Cells(1).Height = 20
                'detailsRowTotal.Cells(1).Width = 450
                detailsRowTotal.Cells(1).ColumnSpan = 1


                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(2).Text = Convert.ToDecimal(dtbTotal.Rows(i)("trailer_amt")).ToString("#,##0")
                detailsRowTotal.Cells(2).BackColor = Color.FromName("#DBE5F1")
                detailsRowTotal.Cells(2).ForeColor = Color.Black
                detailsRowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(2).Font.Bold = False
                detailsRowTotal.Cells(2).Height = 20
                detailsRowTotal.Cells(2).ColumnSpan = 1

                detailsRowTotal.Cells.Add(New TableCell)
                'detailsRowTotal.Cells(3).Text = Convert.ToDecimal(dtbTotal.Rows(i)("trailer_percent")).ToString("#,##0.0")
                detailsRowTotal.Cells(3).Text = ((Convert.ToDecimal(dtbTotal.Rows(i)("trailer_amt")) / Convert.ToDecimal(ViewState("sumScreenAll"))) * 100).ToString("#,##0.0")
                detailsRowTotal.Cells(3).BackColor = Color.FromName("#DBE5F1")
                detailsRowTotal.Cells(3).ForeColor = Color.Black
                detailsRowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(3).Font.Bold = False
                detailsRowTotal.Cells(3).Height = 20
                detailsRowTotal.Cells(3).ColumnSpan = 1

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(4).Text = Convert.ToDecimal(Convert.ToDecimal(dtbTotal.Rows(i)("Revenue_Adms")) + Convert.ToDecimal(dtbTotal.Rows(i)("CompRevenue_Adms"))).ToString("#,##0")
                detailsRowTotal.Cells(4).BackColor = Color.FromName("#DBE5F1")
                detailsRowTotal.Cells(4).ForeColor = Color.Black
                detailsRowTotal.Cells(4).Font.Bold = False
                detailsRowTotal.Cells(4).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(4).Height = 20
                detailsRowTotal.Cells(4).ColumnSpan = 1

                If (Convert.ToString(dtbTotal.Rows(i)("IsCTBV")).Trim() = "1") Then
                    detailsRowTotal.Cells(0).Font.Bold = True
                    detailsRowTotal.Cells(1).Font.Bold = True
                    detailsRowTotal.Cells(2).Font.Bold = True
                    detailsRowTotal.Cells(3).Font.Bold = True
                    detailsRowTotal.Cells(4).Font.Bold = True

                    hasIsCTBV(Convert.ToString(dtbTotal.Rows(i)("Trailer_name"))) = True
                Else
                    detailsRowTotal.Cells(0).Font.Bold = False
                    detailsRowTotal.Cells(1).Font.Bold = False
                    detailsRowTotal.Cells(2).Font.Bold = False
                    detailsRowTotal.Cells(3).Font.Bold = False
                    detailsRowTotal.Cells(4).Font.Bold = False
                End If

                tbl.Rows.Add(detailsRowTotal)
            Next
        End If

    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByReleaseParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
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
    End Sub

End Class