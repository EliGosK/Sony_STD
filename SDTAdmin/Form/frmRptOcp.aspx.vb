Imports Web.Data

Partial Public Class frmRptOcp
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        Try
            If Not IsPostBack Then
                ShowDatatblMain()
            End If
        Catch ex As Exception
            tblMain.Rows(0).Cells(0).Text = ex.Message
        End Try
    End Sub

    '--- Commened by Wittawat W. on 2012/11/28 : Fix bug
    'Sub ShowDatatblMain()

    '    Dim strMovieID As String = Session("opcMovieID")
    '    Dim strStartTheatre As String
    '    Dim strEndTheatre As String
    '    If Session("opcStartTheatre") = "" Or Session("opcStartTheatre") = Nothing Then
    '        strStartTheatre = " null "
    '    Else
    '        strStartTheatre = "'" + Session("opcStartTheatre") + "'"
    '    End If

    '    If Session("opcEndTheatre") = "" Or Session("opcEndTheatre") = Nothing Then
    '        strEndTheatre = " null "
    '    Else
    '        strEndTheatre = "'" + Session("opcEndTheatre") + "'"
    '    End If

    '    Dim strSQL As String = ""
    '    ''strSQL = vbNewLine + " SELECT tblTheater.theater_code, tblTheater.theater_name,"
    '    ''strSQL += vbNewLine + "  SUM(isnull(tblRevenue.revenue_adms,0)) AS Adms, SUM(isnull(tblRevenue.revenue_amount,0)) AS GBO,"
    '    ''strSQL += vbNewLine + "  COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen, "
    '    ''strSQL += vbNewLine + "  tblRelease.theater_id, tblRelease.movies_id, "
    '    ''strSQL += vbNewLine + "  round(((sum(convert(decimal(20,2), isnull(tblRevenue.revenue_adms, 0))) / "
    '    ''strSQL += vbNewLine + "  	(   select sum(opc * mSession)"
    '    ''strSQL += vbNewLine + "  		from"
    '    ''strSQL += vbNewLine + "  		("
    '    ''strSQL += vbNewLine + "  			select a.rev_adms, a.mSession, a.movies_id, "
    '    ''strSQL += vbNewLine + "  			a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    ''strSQL += vbNewLine + "  			from"
    '    ''strSQL += vbNewLine + "  			("
    '    ''strSQL += vbNewLine + "  				SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    ''strSQL += vbNewLine + "  				, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    ''strSQL += vbNewLine + "  				, ts.theatersub_normalseat as opc"
    '    ''strSQL += vbNewLine + "  				FROM tblRevenue  r"
    '    ''strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    ''strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    ''strSQL += vbNewLine + "  				AND r.theater_id = ts.theater_id "
    '    ''strSQL += vbNewLine + "  				WHERE (r.movies_id = tblRelease.movies_id) "
    '    ''strSQL += vbNewLine + "  				AND (r.theater_id = tblRelease.theater_id) "
    '    ''strSQL += vbNewLine + "  				GROUP BY r.movies_id, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    ''strSQL += vbNewLine + "  			) a"
    '    ''strSQL += vbNewLine + "  		) b"
    '    ''strSQL += vbNewLine + "  		group by b.movies_id"
    '    ''strSQL += vbNewLine + "  	)"
    '    ''strSQL += vbNewLine + "  ) * 100),2) as opc"
    '    ''strSQL += vbNewLine + "   , isnull(tblRevenue.movie_nameen,'') as movie_nameen, isnull(tblRevenue.movie_nameth,'') as movie_nameth, isnull(mot.print_qty,0) as print_qty"
    '    ''strSQL += vbNewLine + "   , isnull(SUM(tblRevenue.revenue_amount)/COUNT(DISTINCT tblRevenue.theatersub_id),0) as AvgScreen"
    '    ''strSQL += vbNewLine + "  , (case when isnull(mot.print_qty,0) = 0 "
    '    ''strSQL += vbNewLine + "  then 0"
    '    ''strSQL += vbNewLine + "  else SUM(tblRevenue.revenue_amount)/convert(decimal(10,0), isnull(mot.print_qty,0)) end) as AvgPrint"
    '    ''strSQL += vbNewLine + "  FROM ("
    '    ''strSQL += vbNewLine + " 		 SELECT onrelease_id, onrelease_status, onrelease_startdate,"
    '    ''strSQL += vbNewLine + " 		 onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 "
    '    ''strSQL += vbNewLine + " 		 WHERE (onrelease_status <> '3')"
    '    ''strSQL += vbNewLine + " 		 AND (movies_id = '" + strMovieID + "')"
    '    ''strSQL += vbNewLine + " 	 ) AS tblRelease "
    '    ''strSQL += vbNewLine + " 	 INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id "
    '    ''strSQL += vbNewLine + " 	 LEFT OUTER JOIN ("
    '    ''strSQL += vbNewLine + " 		 SELECT isnull(convert(decimal(30,2), r.revenue_adms),0) + isnull(convert(decimal(30,2),c.comprevenue_admssum),0) as revenue_adms,"
    '    ''strSQL += vbNewLine + " 		 isnull(convert(decimal(30,2), r.revenue_amount),0) + isnull(convert(decimal(30,2),c.comprevenue_amountsum),0) as revenue_amount, "
    '    ''strSQL += vbNewLine + " 		 isnull(convert(decimal(30,2), r.theatersub_id),0) + isnull(convert(decimal(30,2),c.comprevenue_screensum),0) as theatersub_id, "
    '    ''strSQL += vbNewLine + " 		 isnull(convert(decimal(30,2), r.theater_id),0) + isnull(convert(decimal(30,2),c.theater_id),0) as theater_id, "
    '    ''strSQL += vbNewLine + " 		 m.movie_id, m.movie_nameen, m.movie_nameth, m.movietype_id "
    '    ''strSQL += vbNewLine + " 		 from tblmovie m"
    '    ''strSQL += vbNewLine + " 		 left join tblcomprevenue c on m.movie_id = c.movies_id"
    '    ''strSQL += vbNewLine + " 		 left join tblrevenue r  on m.movie_id = r.movies_id"
    '    ''strSQL += vbNewLine + " 		 WHERE (m.movie_id = '" + strMovieID + "')"
    '    ''strSQL += vbNewLine + " 	 ) AS tblRevenue ON tblRelease.theater_id = tblRevenue.theater_id "
    '    ''strSQL += vbNewLine + " 	"
    '    ''strSQL += vbNewLine + " 	left join tblMovie_Theater mot on tblRevenue.theater_id = mot.theater_id "
    '    ''strSQL += vbNewLine + " 	and  tblRevenue.movie_id = mot.movie_id "
    '    ''strSQL += vbNewLine + "  where ((tblRelease.theater_id >= " + strStartTheatre + ")"
    '    ''strSQL += vbNewLine + "  or (" + strStartTheatre + " is null))"
    '    ''strSQL += vbNewLine + "  and ((tblRelease.theater_id <=  " + strEndTheatre + ")"
    '    ''strSQL += vbNewLine + "  or (" + strEndTheatre + " is null))"
    '    ''strSQL += vbNewLine + "  GROUP BY tblRelease.theater_id, tblRelease.movies_id,"
    '    ''strSQL += vbNewLine + "  tblTheater.theater_code, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id "
    '    ''strSQL += vbNewLine + "  ,tblRevenue.movie_nameen, tblRevenue.movie_nameth, mot.print_qty"
    '    ''strSQL += vbNewLine + "  ORDER BY tblTheater.theater_name"


    '    strSQL += vbNewLine + "SELECT tblTheater.theater_code, tblTheater.theater_name,"
    '    strSQL += vbNewLine + "    SUM(isnull(tblRevenue.revenue_adms,0)) AS Adms, SUM(isnull(tblRevenue.revenue_amount,0)) AS GBO,"
    '    strSQL += vbNewLine + "    COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen, "

    '    strSQL += vbNewLine + "  (SELECT MAX(TMax.Screen) as maxScreen"
    '    strSQL += vbNewLine + "  FROM ("
    '    strSQL += vbNewLine + "  	SELECT tTh.theater_code, tTh.theater_name, "
    '    strSQL += vbNewLine + "  	SUM(isnull(trn.revenue_adms,0)) AS rev_adms, SUM(isnull(trn.revenue_amount,0)) AS rev_amount"
    '    strSQL += vbNewLine + "  	, trn.revenue_date, COUNT(DISTINCT trn.theatersub_id) AS Screen"
    '    strSQL += vbNewLine + "  	, COUNT(trn.revenueid) AS mSession, MIN(tRvs.status) AS Expr1"
    '    strSQL += vbNewLine + "  	, MAX(trn.revenue_LastUpdate) AS LastUpdate"
    '    strSQL += vbNewLine + "  	, trn.theater_id"
    '    strSQL += vbNewLine + "  	, trn.movies_id"
    '    strSQL += vbNewLine + "  	, tTh.circuit_id AS opc,"
    '    strSQL += vbNewLine + "  	((sum(convert(decimal(20,2), trn.revenue_adms)) / "
    '    strSQL += vbNewLine + "  	(select sum(opc * mSession)"
    '    strSQL += vbNewLine + "  	from"
    '    strSQL += vbNewLine + "  	("
    '    strSQL += vbNewLine + "  		select a.rev_adms, a.mSession, a.movies_id, "
    '    strSQL += vbNewLine + "  		a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSQL += vbNewLine + "  		from"
    '    strSQL += vbNewLine + "  		("
    '    strSQL += vbNewLine + "  			SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSQL += vbNewLine + "  			, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSQL += vbNewLine + "  			, ts.theatersub_normalseat as opc"
    '    strSQL += vbNewLine + "  			FROM tblRevenue  r"
    '    strSQL += vbNewLine + "  			LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSQL += vbNewLine + "  			LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSQL += vbNewLine + "  			AND r.theater_id = ts.theater_id "
    '    strSQL += vbNewLine + "  			WHERE (r.movies_id = trn.movies_id) "
    '    strSQL += vbNewLine + "  			AND (r.theater_id = trn.theater_id)  "
    '    strSQL += vbNewLine + "  			GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSQL += vbNewLine + "  		) a"
    '    strSQL += vbNewLine + "  	)b"
    '    strSQL += vbNewLine + "  	group by b.movies_id)"
    '    strSQL += vbNewLine + "  	) * 100) as opc_real"
    '    strSQL += vbNewLine + "  	FROM "
    '    strSQL += vbNewLine + "  	("
    '    strSQL += vbNewLine + "  		SELECT revenueid, revenue_adms, revenue_amount, revenue_date, revenue_Time, revenue_LastUpdate"
    '    strSQL += vbNewLine + "  		, revenue_type, theatersub_id, user_id, movie_system, movies_id, theater_id, status_id, sound_type"
    '    strSQL += vbNewLine + "  		, timehour_id, timemin_id "
    '    strSQL += vbNewLine + "  		FROM tblRevenue AS trn_1 "
    '    strSQL += vbNewLine + "  		WHERE (movies_id = '" + strMovieID + "')"
    '    strSQL += vbNewLine + "  	) AS trn "
    '    strSQL += vbNewLine + "  	left join "
    '    strSQL += vbNewLine + "  	(SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id "
    '    strSQL += vbNewLine + "  	FROM tblRelease AS trs_1"
    '    strSQL += vbNewLine + "  	WHERE (onrelease_status = '3') "
    '    strSQL += vbNewLine + "  	AND (movies_id = '" + strMovieID + "')  "
    '    strSQL += vbNewLine + "  	) AS trs ON trs.theater_id = trn.theater_id "
    '    strSQL += vbNewLine + "  	Left JOIN tblTheater tTh ON trn.theater_id = tTh.theater_id "
    '    strSQL += vbNewLine + "  	LEFT OUTER JOIN tblRevStatus tRvs ON trn.status_id = tRvs.status_id "
    '    strSQL += vbNewLine + "  	WHERE tTh.theater_id = tblRelease.theater_id"
    '    strSQL += vbNewLine + "  	GROUP BY trn.revenue_date, trn.theater_id, trn.movies_id, tTh.theater_code"
    '    strSQL += vbNewLine + "  	, tTh.theater_name, tTh.theater_des, tTh.circuit_id  "
    '    strSQL += vbNewLine + "  ) TMax) as MaxScreen,"

    '    strSQL += vbNewLine + "    tblRelease.theater_id, tblRelease.movies_id "
    '    strSQL += vbNewLine + "  , (select sum(opc * mSession)"
    '    strSQL += vbNewLine + "  		from"
    '    strSQL += vbNewLine + "  		("
    '    strSQL += vbNewLine + "  			select a.rev_adms, a.mSession, a.movies_id, "
    '    strSQL += vbNewLine + "  			a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSQL += vbNewLine + "  			from"
    '    strSQL += vbNewLine + "  			("
    '    strSQL += vbNewLine + "  				SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSQL += vbNewLine + "  				, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSQL += vbNewLine + "  				, ts.theatersub_normalseat as opc"
    '    strSQL += vbNewLine + "  				FROM tblRevenue  r"
    '    strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSQL += vbNewLine + "  				AND r.theater_id = ts.theater_id "
    '    strSQL += vbNewLine + "  				WHERE (r.movies_id = tblRelease.movies_id) "
    '    strSQL += vbNewLine + "  				AND (r.theater_id = tblRelease.theater_id) "
    '    strSQL += vbNewLine + "  				GROUP BY r.movies_id, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSQL += vbNewLine + "  			) a"
    '    strSQL += vbNewLine + "  		) b"
    '    strSQL += vbNewLine + "  		group by b.movies_id"
    '    strSQL += vbNewLine + "  	) as ss"
    '    strSQL += vbNewLine + "    , round(((sum(convert(decimal(20,2), isnull(tblRevenue.revenue_adms, 0))) / "
    '    strSQL += vbNewLine + "  	(   select sum(opc * mSession)"
    '    strSQL += vbNewLine + "  		from"
    '    strSQL += vbNewLine + "  		("
    '    strSQL += vbNewLine + "  			select a.rev_adms, a.mSession, a.movies_id, "
    '    strSQL += vbNewLine + "  			a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSQL += vbNewLine + "  			from"
    '    strSQL += vbNewLine + "  			("
    '    strSQL += vbNewLine + "  				SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSQL += vbNewLine + "  				, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSQL += vbNewLine + "  				, ts.theatersub_normalseat as opc"
    '    strSQL += vbNewLine + "  				FROM tblRevenue  r"
    '    strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSQL += vbNewLine + "  				LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSQL += vbNewLine + "  				AND r.theater_id = ts.theater_id "
    '    strSQL += vbNewLine + "  				WHERE (r.movies_id = tblRelease.movies_id) "
    '    strSQL += vbNewLine + "  				AND (r.theater_id = tblRelease.theater_id) "
    '    strSQL += vbNewLine + "  				GROUP BY r.movies_id, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSQL += vbNewLine + "  			) a"
    '    strSQL += vbNewLine + "  		) b"
    '    strSQL += vbNewLine + "  		group by b.movies_id"
    '    strSQL += vbNewLine + "  	)"
    '    strSQL += vbNewLine + "    ) * 100),2) as opc"
    '    strSQL += vbNewLine + "     , isnull(tblRevenue.movie_nameen,'') as movie_nameen, isnull(tblRevenue.movie_nameth,'') as movie_nameth, isnull(mot.print_qty,0) as print_qty"
    '    strSQL += vbNewLine + "     , isnull(SUM(tblRevenue.revenue_amount)/COUNT(DISTINCT tblRevenue.theatersub_id),0) as AvgScreen"
    '    strSQL += vbNewLine + "    , (case when isnull(mot.print_qty,0) = 0 "
    '    strSQL += vbNewLine + "    then 0"
    '    strSQL += vbNewLine + "    else SUM(tblRevenue.revenue_amount)/convert(decimal(10,0), isnull(mot.print_qty,0)) end) as AvgPrint"
    '    strSQL += vbNewLine + "    FROM ("
    '    strSQL += vbNewLine + "  		 SELECT onrelease_id, onrelease_status, onrelease_startdate,"
    '    strSQL += vbNewLine + "  		 onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 "
    '    strSQL += vbNewLine + "  		 WHERE (onrelease_status <> '3')"
    '    strSQL += vbNewLine + "  		 AND (movies_id = '" + strMovieID + "')"
    '    strSQL += vbNewLine + "  	 ) AS tblRelease "
    '    strSQL += vbNewLine + "  	 INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id "
    '    strSQL += vbNewLine + "  	 LEFT OUTER JOIN ("
    '    strSQL += vbNewLine + "  		 SELECT isnull(convert(decimal(30,2), r.revenue_adms),0) + isnull(convert(decimal(30,2),c.comprevenue_admssum),0) as revenue_adms,"
    '    strSQL += vbNewLine + "  		 isnull(convert(decimal(30,2), r.revenue_amount),0) + isnull(convert(decimal(30,2),c.comprevenue_amountsum),0) as revenue_amount, "
    '    strSQL += vbNewLine + "  		 isnull(convert(decimal(30,2), r.theatersub_id),0) + isnull(convert(decimal(30,2),c.comprevenue_screensum),0) as theatersub_id, "
    '    strSQL += vbNewLine + "  		 isnull(convert(decimal(30,2), r.theater_id),0) + isnull(convert(decimal(30,2),c.theater_id),0) as theater_id, "
    '    strSQL += vbNewLine + "  		 m.movie_id, m.movie_nameen, m.movie_nameth, m.movietype_id "
    '    strSQL += vbNewLine + "  		 from tblmovie m"
    '    strSQL += vbNewLine + "  		 left join tblcomprevenue c on m.movie_id = c.movies_id"
    '    strSQL += vbNewLine + "  		 left join tblrevenue r  on m.movie_id = r.movies_id"
    '    strSQL += vbNewLine + "  		 WHERE (m.movie_id = '" + strMovieID + "')"
    '    strSQL += vbNewLine + "  	 ) AS tblRevenue ON tblRelease.theater_id = tblRevenue.theater_id "
    '    strSQL += vbNewLine + "   	"
    '    strSQL += vbNewLine + "  	left join tblMovie_Theater mot on tblRevenue.theater_id = mot.theater_id "
    '    strSQL += vbNewLine + "  	and  tblRevenue.movie_id = mot.movie_id "
    '    strSQL += vbNewLine + "  where ((tblRelease.theater_id >= " + strStartTheatre + ")"
    '    strSQL += vbNewLine + "  or (" + strStartTheatre + " is null))"
    '    strSQL += vbNewLine + "  and ((tblRelease.theater_id <=  " + strEndTheatre + ")"
    '    strSQL += vbNewLine + "  or (" + strEndTheatre + " is null))"
    '    strSQL += vbNewLine + "    GROUP BY tblRelease.theater_id, tblRelease.movies_id,"
    '    strSQL += vbNewLine + "    tblTheater.theater_code, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id "
    '    strSQL += vbNewLine + "    ,tblRevenue.movie_nameen, tblRevenue.movie_nameth, mot.print_qty"
    '    strSQL += vbNewLine + "  ORDER BY tblTheater.theater_name"

    '    Dim drtblMain As IDataReader = cDB.GetDataAll(strSQL)
    '    Dim intRow As Integer = 4
    '    Dim intRowSpan As Integer = 0
    '    Dim intCheckRow As Integer = 1
    '    Dim intCountTheatreRow As Integer = 0
    '    Dim intCountScreenRow As Integer = 0
    '    Dim strCheckTheatre As String = ""
    '    Dim strCheckScreen As String = ""
    '    Dim sumNoOfSeate As Double = 0
    '    Dim sumNoOfSeateTheatre As Double = 0
    '    ViewState("theatreID") = 0
    '    ViewState("screenID") = 0
    '    ViewState("ColorNo") = "#F7F6F3"
    '    ViewState("Color3D") = "#000000"

    '    If (drtblMain.Read()) Then
    '        tblMain.Rows(2).Cells(0).Text = "Occupancy : " & drtblMain("movie_nameen")
    '        'tblSum.Visible = True
    '    Else
    '        'tblSum.Visible = False
    '    End If
    '    drtblMain.Close()

    '    sqlMovies.SelectCommand = strSQL
    '    GridView1.DataSourceID = "sqlMovies"
    '    GridView1.DataBind()

    '    'Dim decSumOpc As Decimal = 0
    '    'Dim decSumAvgScreen As Decimal = 0
    '    'Dim decSumAvgPrint As Decimal = 0
    '    'Dim decSumScreen As Decimal = 0
    '    'Dim decSumprint_qty As Decimal = 0
    '    'For i As Integer = 0 To GridView1.Rows.Count - 1
    '    '    If (GridView1.Rows(i).Cells(1).Text.Trim() <> "") Then
    '    '        decSumOpc += Convert.ToDecimal(GridView1.Rows(i).Cells(1).Text)
    '    '    End If
    '    '    If (GridView1.Rows(i).Cells(2).Text.Trim() <> "") Then
    '    '        decSumAvgScreen += Convert.ToDecimal(GridView1.Rows(i).Cells(2).Text)
    '    '    End If
    '    '    If (GridView1.Rows(i).Cells(3).Text.Trim() <> "") Then
    '    '        decSumAvgPrint += Convert.ToDecimal(GridView1.Rows(i).Cells(3).Text)
    '    '    End If
    '    '    If (GridView1.Rows(i).Cells(4).Text.Trim() <> "") Then
    '    '        decSumScreen += Convert.ToDecimal(GridView1.Rows(i).Cells(4).Text)
    '    '    End If
    '    '    If (GridView1.Rows(i).Cells(5).Text.Trim() <> "") Then
    '    '        decSumprint_qty += Convert.ToDecimal(GridView1.Rows(i).Cells(5).Text)
    '    '    End If
    '    'Next

    '    Dim strSqlSum As String = ""
    '    strSqlSum = " SELECT sum(tAll.Adms) AS sumAdms, sum(tAll.GBO) as sumRevAmount"
    '    strSqlSum += vbNewLine + " , sum(tAll.maxScreen) as sumScreen, sum(tAll.print_qty) as print_qty"
    '    strSqlSum += vbNewLine + " , (sum(tAll.GBO) / sum(tAll.Screen)) as avgScreen"
    '    strSqlSum += vbNewLine + " , (sum(tAll.GBO) / sum(tAll.print_qty)) as avgPrint_qty"
    '    strSqlSum += vbNewLine + " , sum(tAll.ss) as ss"
    '    strSqlSum += vbNewLine + " , ((sum(tAll.Adms) / sum(tAll.ss)) * 100) as opc"
    '    strSqlSum += vbNewLine + " from ("
    '    strSqlSum += vbNewLine + "  SELECT tblTheater.theater_code, tblTheater.theater_name,"
    '    strSqlSum += vbNewLine + "    SUM(isnull(tblRevenue.revenue_adms,0)) AS Adms, SUM(isnull(tblRevenue.revenue_amount,0)) AS GBO,"
    '    strSqlSum += vbNewLine + "    COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen, "

    '    strSqlSum += vbNewLine + "  (SELECT MAX(TMax.Screen) as maxScreen"
    '    strSqlSum += vbNewLine + "  FROM ("
    '    strSqlSum += vbNewLine + " 	SELECT tTh.theater_code, tTh.theater_name, "
    '    strSqlSum += vbNewLine + " 	SUM(isnull(trn.revenue_adms,0)) AS rev_adms, SUM(isnull(trn.revenue_amount,0)) AS rev_amount"
    '    strSqlSum += vbNewLine + " 	, trn.revenue_date, COUNT(DISTINCT trn.theatersub_id) AS Screen"
    '    strSqlSum += vbNewLine + " 	, COUNT(trn.revenueid) AS mSession, MIN(tRvs.status) AS Expr1"
    '    strSqlSum += vbNewLine + " 	, MAX(trn.revenue_LastUpdate) AS LastUpdate"
    '    strSqlSum += vbNewLine + " 	, trn.theater_id"
    '    strSqlSum += vbNewLine + " 	, trn.movies_id"
    '    strSqlSum += vbNewLine + " 	, tTh.circuit_id AS opc,"
    '    strSqlSum += vbNewLine + " 	((sum(convert(decimal(20,2), trn.revenue_adms)) / "
    '    strSqlSum += vbNewLine + " 	(select sum(opc * mSession)"
    '    strSqlSum += vbNewLine + " 	from"
    '    strSqlSum += vbNewLine + " 	("
    '    strSqlSum += vbNewLine + " 		select a.rev_adms, a.mSession, a.movies_id, "
    '    strSqlSum += vbNewLine + " 		a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSqlSum += vbNewLine + " 		from"
    '    strSqlSum += vbNewLine + " 		("
    '    strSqlSum += vbNewLine + " 			SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSqlSum += vbNewLine + " 			, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSqlSum += vbNewLine + " 			, ts.theatersub_normalseat as opc"
    '    strSqlSum += vbNewLine + " 			FROM tblRevenue  r"
    '    strSqlSum += vbNewLine + " 			LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSqlSum += vbNewLine + " 			LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSqlSum += vbNewLine + " 			AND r.theater_id = ts.theater_id "
    '    strSqlSum += vbNewLine + " 			WHERE (r.movies_id = trn.movies_id) "
    '    strSqlSum += vbNewLine + " 			AND (r.theater_id = trn.theater_id)  "
    '    strSqlSum += vbNewLine + " 			GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSqlSum += vbNewLine + " 		) a"
    '    strSqlSum += vbNewLine + " 	)b"
    '    strSqlSum += vbNewLine + " 	group by b.movies_id)"
    '    strSqlSum += vbNewLine + " 	) * 100) as opc_real"
    '    strSqlSum += vbNewLine + " 	FROM "
    '    strSqlSum += vbNewLine + " 	("
    '    strSqlSum += vbNewLine + " 		SELECT revenueid, revenue_adms, revenue_amount, revenue_date, revenue_Time, revenue_LastUpdate"
    '    strSqlSum += vbNewLine + " 		, revenue_type, theatersub_id, user_id, movie_system, movies_id, theater_id, status_id, sound_type"
    '    strSqlSum += vbNewLine + " 		, timehour_id, timemin_id "
    '    strSqlSum += vbNewLine + " 		FROM tblRevenue AS trn_1 "
    '    strSqlSum += vbNewLine + " 		WHERE (movies_id = '" + strMovieID + "')"
    '    strSqlSum += vbNewLine + " 	) AS trn "
    '    strSqlSum += vbNewLine + " 	left join "
    '    strSqlSum += vbNewLine + " 	(SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id "
    '    strSqlSum += vbNewLine + " 	FROM tblRelease AS trs_1"
    '    strSqlSum += vbNewLine + " 	WHERE (onrelease_status = '3') "
    '    strSqlSum += vbNewLine + " 	AND (movies_id = '" + strMovieID + "')  "
    '    strSqlSum += vbNewLine + " 	) AS trs ON trs.theater_id = trn.theater_id "
    '    strSqlSum += vbNewLine + " 	Left JOIN tblTheater tTh ON trn.theater_id = tTh.theater_id "
    '    strSqlSum += vbNewLine + " 	LEFT OUTER JOIN tblRevStatus tRvs ON trn.status_id = tRvs.status_id "
    '    strSqlSum += vbNewLine + " 	WHERE tTh.theater_id = tblRelease.theater_id"
    '    strSqlSum += vbNewLine + " 	GROUP BY trn.revenue_date, trn.theater_id, trn.movies_id, tTh.theater_code"
    '    strSqlSum += vbNewLine + " 	, tTh.theater_name, tTh.theater_des, tTh.circuit_id  "
    '    strSqlSum += vbNewLine + "  ) TMax) as MaxScreen,"

    '    strSqlSum += vbNewLine + "    tblRelease.theater_id, tblRelease.movies_id "
    '    strSqlSum += vbNewLine + "  , (select sum(opc * mSession)"
    '    strSqlSum += vbNewLine + " 		from"
    '    strSqlSum += vbNewLine + " 		("
    '    strSqlSum += vbNewLine + " 			select a.rev_adms, a.mSession, a.movies_id, "
    '    strSqlSum += vbNewLine + " 			a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSqlSum += vbNewLine + " 			from"
    '    strSqlSum += vbNewLine + " 			("
    '    strSqlSum += vbNewLine + " 				SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSqlSum += vbNewLine + " 				, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSqlSum += vbNewLine + " 				, ts.theatersub_normalseat as opc"
    '    strSqlSum += vbNewLine + " 				FROM tblRevenue  r"
    '    strSqlSum += vbNewLine + " 				LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSqlSum += vbNewLine + " 				LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSqlSum += vbNewLine + " 				AND r.theater_id = ts.theater_id "
    '    strSqlSum += vbNewLine + " 				WHERE (r.movies_id = tblRelease.movies_id) "
    '    strSqlSum += vbNewLine + " 				AND (r.theater_id = tblRelease.theater_id) "
    '    strSqlSum += vbNewLine + " 				GROUP BY r.movies_id, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSqlSum += vbNewLine + " 			) a"
    '    strSqlSum += vbNewLine + " 		) b"
    '    strSqlSum += vbNewLine + " 		group by b.movies_id"
    '    strSqlSum += vbNewLine + " 	) as ss"
    '    strSqlSum += vbNewLine + "    , round(((sum(convert(decimal(20,2), isnull(tblRevenue.revenue_adms, 0))) / "
    '    strSqlSum += vbNewLine + " 	(   select sum(opc * mSession)"
    '    strSqlSum += vbNewLine + " 		from"
    '    strSqlSum += vbNewLine + " 		("
    '    strSqlSum += vbNewLine + " 			select a.rev_adms, a.mSession, a.movies_id, "
    '    strSqlSum += vbNewLine + " 			a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real"
    '    strSqlSum += vbNewLine + " 			from"
    '    strSqlSum += vbNewLine + " 			("
    '    strSqlSum += vbNewLine + " 				SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms"
    '    strSqlSum += vbNewLine + " 				, COUNT(r.revenueid) AS mSession, r.movies_id"
    '    strSqlSum += vbNewLine + " 				, ts.theatersub_normalseat as opc"
    '    strSqlSum += vbNewLine + " 				FROM tblRevenue  r"
    '    strSqlSum += vbNewLine + " 				LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id "
    '    strSqlSum += vbNewLine + " 				LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id "
    '    strSqlSum += vbNewLine + " 				AND r.theater_id = ts.theater_id "
    '    strSqlSum += vbNewLine + " 				WHERE (r.movies_id = tblRelease.movies_id) "
    '    strSqlSum += vbNewLine + " 				AND (r.theater_id = tblRelease.theater_id) "
    '    strSqlSum += vbNewLine + " 				GROUP BY r.movies_id, r.theater_id, r.theatersub_id, ts.theatersub_normalseat"
    '    strSqlSum += vbNewLine + " 			) a"
    '    strSqlSum += vbNewLine + " 		) b"
    '    strSqlSum += vbNewLine + " 		group by b.movies_id"
    '    strSqlSum += vbNewLine + " 	)"
    '    strSqlSum += vbNewLine + "    ) * 100),2) as opc"
    '    strSqlSum += vbNewLine + " 	, isnull(tblRevenue.movie_nameen,'') as movie_nameen, isnull(tblRevenue.movie_nameth,'') as movie_nameth, isnull(mot.print_qty,0) as print_qty"
    '    strSqlSum += vbNewLine + " 	, isnull(SUM(tblRevenue.revenue_amount)/COUNT(DISTINCT tblRevenue.theatersub_id),0) as AvgScreen"
    '    strSqlSum += vbNewLine + "    , (case when isnull(mot.print_qty,0) = 0 "
    '    strSqlSum += vbNewLine + "    then 0"
    '    strSqlSum += vbNewLine + "    else SUM(tblRevenue.revenue_amount)/convert(decimal(10,0), isnull(mot.print_qty,0)) end) as AvgPrint"
    '    strSqlSum += vbNewLine + "    FROM ("
    '    strSqlSum += vbNewLine + " 		 SELECT onrelease_id, onrelease_status, onrelease_startdate,"
    '    strSqlSum += vbNewLine + " 		 onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 "
    '    strSqlSum += vbNewLine + " 		 WHERE (onrelease_status <> '3')"
    '    strSqlSum += vbNewLine + " 		 AND (movies_id = '" + strMovieID + "')"
    '    strSqlSum += vbNewLine + " 	 ) AS tblRelease "
    '    strSqlSum += vbNewLine + " 	 INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id "
    '    strSqlSum += vbNewLine + " 	 LEFT OUTER JOIN ("
    '    strSqlSum += vbNewLine + " 		 SELECT isnull(convert(decimal(30,2), r.revenue_adms),0) + isnull(convert(decimal(30,2),c.comprevenue_admssum),0) as revenue_adms,"
    '    strSqlSum += vbNewLine + " 		 isnull(convert(decimal(30,2), r.revenue_amount),0) + isnull(convert(decimal(30,2),c.comprevenue_amountsum),0) as revenue_amount, "
    '    strSqlSum += vbNewLine + " 		 isnull(convert(decimal(30,2), r.theatersub_id),0) + isnull(convert(decimal(30,2),c.comprevenue_screensum),0) as theatersub_id, "
    '    strSqlSum += vbNewLine + " 		 isnull(convert(decimal(30,2), r.theater_id),0) + isnull(convert(decimal(30,2),c.theater_id),0) as theater_id, "
    '    strSqlSum += vbNewLine + " 		 m.movie_id, m.movie_nameen, m.movie_nameth, m.movietype_id "
    '    strSqlSum += vbNewLine + " 		 from tblmovie m"
    '    strSqlSum += vbNewLine + " 		 left join tblcomprevenue c on m.movie_id = c.movies_id"
    '    strSqlSum += vbNewLine + " 		 left join tblrevenue r  on m.movie_id = r.movies_id"
    '    strSqlSum += vbNewLine + " 		 WHERE (m.movie_id = '" + strMovieID + "')"
    '    strSqlSum += vbNewLine + " 	 ) AS tblRevenue ON tblRelease.theater_id = tblRevenue.theater_id "
    '    strSqlSum += vbNewLine + "   	"
    '    strSqlSum += vbNewLine + " 	left join tblMovie_Theater mot on tblRevenue.theater_id = mot.theater_id "
    '    strSqlSum += vbNewLine + " 	and  tblRevenue.movie_id = mot.movie_id "
    '    strSqlSum += vbNewLine + "  where ((tblRelease.theater_id >= " + strStartTheatre + ")"
    '    strSqlSum += vbNewLine + "  or (" + strStartTheatre + " is null))"
    '    strSqlSum += vbNewLine + "  and ((tblRelease.theater_id <=  " + strEndTheatre + ")"
    '    strSqlSum += vbNewLine + "  or (" + strEndTheatre + " is null))"
    '    strSqlSum += vbNewLine + "    GROUP BY tblRelease.theater_id, tblRelease.movies_id,"
    '    strSqlSum += vbNewLine + "    tblTheater.theater_code, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id "
    '    strSqlSum += vbNewLine + "    ,tblRevenue.movie_nameen, tblRevenue.movie_nameth, mot.print_qty "
    '    strSqlSum += vbNewLine + " ) tAll"
    '    Dim drtblsum As IDataReader = cDB.GetDataAll(strSqlSum)

    '    If (drtblsum.Read()) Then
    '        tblSum.Rows(0).Cells(1).Text = Format(drtblsum("opc"), "#,##0.00")
    '        tblSum.Rows(0).Cells(2).Text = Format(drtblsum("avgScreen"), "#,##0.00")
    '        tblSum.Rows(0).Cells(3).Text = Format(drtblsum("avgPrint_qty"), "#,##0.00")
    '        tblSum.Rows(0).Cells(4).Text = Format(drtblsum("sumScreen"), "#,##0")
    '        tblSum.Rows(0).Cells(5).Text = Format(drtblsum("print_qty"), "#,##0")
    '    End If
    '    drtblsum.Close()
    '    'tblSum.Visible = False
    'End Sub

    '--- Added by Wittawat W. on 2012/11/28 : Add date period
    Private Sub ShowDatatblMain()
        Me.tblMain.Rows(2).Cells(0).Text = "Occupancy : " & Session("opcMovieName")
        Me.tblMain.Rows(3).Cells(0).Text = "From Date : " & Format(Session("opcStartDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("opcEndDate"), "ddd dd-MMM-yyyy")

        Me.sqlMovies.SelectCommand = "dbo.spGetRptOccupancy"
        Me.sqlMovies.SelectCommandType = SqlDataSourceCommandType.StoredProcedure
        Me.sqlMovies.SelectParameters.Clear()
        Me.sqlMovies.SelectParameters.Add("p_movie_id", Session("opcMovieID"))
        Me.sqlMovies.SelectParameters.Add("p_start_date", Session("opcStartDate"))
        Me.sqlMovies.SelectParameters.Add("p_end_date", Session("opcEndDate"))
        Me.gvOccupancy.DataSourceID = "sqlMovies"
        Me.gvOccupancy.DataBind()
    End Sub

    '--- Added by Wittawat W. on 2012/11/28 : Add date period
    Protected m_intAmountTotal As Integer = 0
    Protected m_intAdmsTotal As Integer = 0
    Protected m_intSeatTotal As Integer = 0
    Protected m_intScreenTotal As Integer = 0
    Protected m_intPrintTotal As Integer = 0

    '--- Added by Wittawat W. on 2012/11/28 : Add date period
    Protected Sub gvOccupancy_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOccupancy.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            m_intAmountTotal += CInt(DataBinder.Eval(e.Row.DataItem, "revenue_amount_sum"))
            m_intAdmsTotal += CInt(DataBinder.Eval(e.Row.DataItem, "revenue_adms_sum"))
            m_intSeatTotal += CInt(DataBinder.Eval(e.Row.DataItem, "theatersub_normalseat_sum"))
            m_intScreenTotal += CInt(DataBinder.Eval(e.Row.DataItem, "revenue_screen_count"))
            m_intPrintTotal += CInt(DataBinder.Eval(e.Row.DataItem, "print_qty"))
        End If
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptOcpParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        'Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=TheatreInformation.xls")
        'Response.Charset = "windows-874"
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = "application/vnd.xls"
        'Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        'Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        'ShowDatatblMain()
        'tblMain.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        'Response.End()

        If gvOccupancy.Rows.Count.ToString + 1 < 65536 Then

            gvOccupancy.AllowPaging = False
            gvOccupancy.AllowSorting = False
            gvOccupancy.Width = 800
            gvOccupancy.DataBind()
            Dim tw As New IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            frm.Attributes("runat") = "server"
            ShowDatatblMain()
            frm.Controls.Add(tblMain)
            frm.Controls.Add(gvOccupancy)
            'frm.Controls.Add(tblSum) '--- Commented by Wittawat W. on 2012/11/28 : Add date period
            Response.AddHeader("content-disposition", "attachment;filename=Market_Share_By_Distributor.xls")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)

            Response.ContentType = "application/vnd.xls"
            Response.Charset = ""
            EnableViewState = False
            Controls.Add(frm)

            frm.RenderControl(hw)
            'Response.Write(tw.ToString())
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
            Response.End()
            gvOccupancy.AllowPaging = True
            gvOccupancy.AllowSorting = True
            gvOccupancy.DataBind()

        End If
    End Sub


    '    SELECT tblTheater.theater_code, tblTheater.theater_name,
    ' SUM(tblCompRevenue.CompRevenue_admssum) AS Adms, SUM(tblCompRevenue.comprevenue_amountsum) AS GBO, 
    'COUNT(DISTINCT tblCompRevenue.theatersub_id) AS Screen, 
    'COUNT(tblCompRevenue.comprevenue_id) AS mSession, MIN(tblRevStatus.status) AS RevStatus,
    ' tblRelease.theater_id, tblRelease.movies_id, 
    'tblTheater.circuit_id AS opc 
    ', tblCompRevenue.movie_nameen, tblCompRevenue.movie_nameth, tblCompRevenue.print_qty
    ', SUM(tblCompRevenue.comprevenue_amountsum)/COUNT(DISTINCT tblCompRevenue.theatersub_id) as AvgScreen
    ', (case when isnull(tblCompRevenue.print_qty,0) = 0 
    'then 0
    'else SUM(tblCompRevenue.comprevenue_amountsum)/convert(decimal(10,0), isnull(tblCompRevenue.print_qty,0)) end) as AvgPrint
    'FROM (
    'SELECT onrelease_id, onrelease_status, onrelease_startdate,
    'onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 
    'WHERE (onrelease_status <> '3')
    ' AND (movies_id = '181') 
    ') AS tblRelease 
    'INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id 
    'LEFT OUTER JOIN (
    'SELECT r.comprevenue_id, r.CompRevenue_admssum, r.comprevenue_amountsum, r.CompRevenue_date, 
    'r.CompRevenue_type, r.user_id, r.movie_system, r.movies_id, r.theater_id, 
    'r.status_id, r.sound_type, r.timehour_id, r.timemin_id 
    ', m.movie_nameen, m.movie_nameth, isnull(m.print_qty,0) as print_qty
    'FROM tblCompRevenue r left join
    'tblMovie m 
    'on r.movies_id = m.movie_id
    'WHERE (r.movies_id = '181')
    ') AS tblCompRevenue
    ' ON tblRelease.theater_id = tblCompRevenue.theater_id LEFT OUTER JOIN tblRevStatus 
    'ON tblCompRevenue.status_id = tblRevStatus.status_id 

    'GROUP BY tblRelease.theater_id, tblRelease.movies_id,
    ' tblTheater.theater_code, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id 
    ',tblCompRevenue.movie_nameen, tblCompRevenue.movie_nameth, tblCompRevenue.print_qty
    'ORDER BY tblTheater.theater_name, RevStatus


    '    SELECT tblTheater.theater_code, tblTheater.theater_name,
    'SUM(tblRevenue.revenue_adms) AS Adms, SUM(tblRevenue.revenue_amount) AS GBO, 
    'COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen, 
    'COUNT(tblRevenue.revenueid) AS mSession, MIN(tblRevStatus.status) AS RevStatus,
    ' tblRelease.theater_id, tblRelease.movies_id, 
    'tblTheater.circuit_id AS opc 
    ', tblRevenue.movie_nameen, tblRevenue.movie_nameth, tblRevenue.print_qty
    ', SUM(tblRevenue.revenue_amount)/COUNT(DISTINCT tblRevenue.theatersub_id) as AvgScreen
    ', (case when isnull(tblRevenue.print_qty,0) = 0 
    'then 0
    'else SUM(tblRevenue.revenue_amount)/convert(decimal(10,0), isnull(tblRevenue.print_qty,0)) end) as AvgPrint
    'FROM (
    'SELECT onrelease_id, onrelease_status, onrelease_startdate,
    'onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 
    'WHERE (onrelease_status <> '3')
    ' AND (movies_id = '181') 
    ') AS tblRelease 
    'INNER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id 
    'LEFT OUTER JOIN (
    'SELECT r.revenueid, r.revenue_adms, r.revenue_amount, r.revenue_date, 
    'r.revenue_type, r.theatersub_id, r.user_id, r.movie_system, r.movies_id, r.theater_id, 
    'r.status_id, r.sound_type, r.timehour_id, r.timemin_id 
    ', m.movie_nameen, m.movie_nameth, isnull(m.print_qty,0) as print_qty
    'FROM tblRevenue r left join
    'tblMovie m 
    'on r.movies_id = m.movie_id
    'WHERE (r.movies_id = '181')
    ') AS tblRevenue
    ' ON tblRelease.theater_id = tblRevenue.theater_id LEFT OUTER JOIN tblRevStatus 
    'ON tblRevenue.status_id = tblRevStatus.status_id 

    'GROUP BY tblRelease.theater_id, tblRelease.movies_id,
    ' tblTheater.theater_code, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id 
    ',tblRevenue.movie_nameen, tblRevenue.movie_nameth, tblRevenue.print_qty
    'ORDER BY tblTheater.theater_name, RevStatus

End Class