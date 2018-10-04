Imports Web.Data

Partial Public Class frmRptIndustryInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        Try

            While (tbl.Rows.Count > 5)
                tbl.Rows.RemoveAt(5)
            End While

            Dim dtBegin As DateTime = Convert.ToDateTime(Session("RptStartDate"))
            Dim dtEnd As DateTime = Convert.ToDateTime(Session("RptEndDate"))
            Dim strBeginDate As String = Convert.ToString(dtBegin.Year) + dtBegin.ToString("/MM/dd")
            Dim strEndDate As String = Convert.ToString(dtEnd.Year) + dtEnd.ToString("/MM/dd")


            Dim cDB As New cDatabase
            tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
            tbl.Rows(2).Cells(0).Text = "<font size='1' color='White'>โค</font>Release Date : " & dtBegin.ToString("dd-MMM-yyyy") & " - " & dtEnd.ToString("dd-MMM-yyyy")
            Dim wkSQL As String

            ''wkSQL = " select rev.movie_id, rev.movie_nameen as movie_name, rev.movietype_id, rev.nationality, rev.distributor_id, rev.distributor_name, rev.movie_start_date,"
            ''wkSQL += vbNewLine + " isnull(rev.screen_qty, 0) as screen_qty, isnull(rev.screenMax, 0) as screenMax, isnull(rev.op_week_qty, 0) as op_week_qty1, isnull(rev.op_week_qty1, 0) as op_week_qty, isnull(rev.first_week_qty, 0) as first_week_qty, "
            ''wkSQL += vbNewLine + " isnull(rev.second_week_qty, 0) as second_week_qty, isnull(rev.third_week_qty, 0) as third_week_qty,"
            ''wkSQL += vbNewLine + " isnull(rev.key_city_revenue_amt, 0) as key_city_revenue_amt, rev.sumRevAll, isnull(rev.adms_amt, 0) as adms_amt, "
            ''wkSQL += vbNewLine + " case when isnull(rev.adms_amt, 0) > 0 then"
            ''wkSQL += vbNewLine + " (isnull(rev.key_city_revenue_amt, 0)/rev.adms_amt)"
            ''wkSQL += vbNewLine + " else"
            ''wkSQL += vbNewLine + " 0 "
            ''wkSQL += vbNewLine + " end atp_amt"
            ''wkSQL += vbNewLine + " , movie_start_date, CONVERT(VARCHAR(10), movie_strdate, 7) AS newDate, "
            ''wkSQL += vbNewLine + " LEFT(DATENAME(dw, movie_strdate), 3) AS movie_strdate_DDD,"
            ''wkSQL += vbNewLine + " dbo.getCountDayToSun(convert(varchar(19), movie_strdate,111)) as DaySun"
            ''wkSQL += vbNewLine + " from "
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select m.movie_id,min(m.movie_nameen) as movie_nameen, min(m.movie_nameen + '/' + m.movie_nameth) as movie_name, min(m.movietype_id) as movietype_id, min(m.movie_national) as nationality, "
            ''wkSQL += vbNewLine + " min(m.distributor_id) as distributor_id, min(d.distributor_name) as distributor_name, "
            ''wkSQL += vbNewLine + " min(convert(varchar(19), m.movie_strdate, 111)) as movie_start_date, m.movie_strdate as movie_strdate,"
            ''wkSQL += vbNewLine + " isnull(sum(cr.comprevenue_screensum), 0) + count(distinct convert(varchar, r.theater_id) + 'A' + convert(varchar, r.theatersub_id)) as screen_qty,"
            ''wkSQL += vbNewLine + " max(isnull(vRevToday1.cntScreen, 0)) as screenMax,	("
            ''wkSQL += vbNewLine + " select sum(isnull(a.revenue_amount,0)) as op_week_qty"
            ''wkSQL += vbNewLine + " from"
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select top 4 tm.movie_id, tr.revenue_date, tc.comprevenue_date,"
            ''wkSQL += vbNewLine + " convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as revenue_amount"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " group by tm.movie_id, tr.revenue_date, tc.comprevenue_date"
            ''wkSQL += vbNewLine + " order by tr.revenue_date, tc.comprevenue_date"
            ''wkSQL += vbNewLine + " ) a"
            ''wkSQL += vbNewLine + " ) as op_week_qty,"

            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as first_week_qty"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, -3, dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tr.revenue_date,111) <= dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111)) )"
            ''wkSQL += vbNewLine + " or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, -3, dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tc.comprevenue_date,111) <= dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))))"
            ''wkSQL += vbNewLine + " ) as op_week_qty1,"

            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as first_week_qty"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), m.movie_strdate,111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 6, m.movie_strdate),111))"
            ''wkSQL += vbNewLine + " or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), m.movie_strdate,111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 6, m.movie_strdate),111)))"
            ''wkSQL += vbNewLine + " ) as first_week_qty,"
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as second_week_qty"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, 7, m.movie_strdate),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 13, m.movie_strdate),111))"
            ''wkSQL += vbNewLine + " or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, 7, m.movie_strdate),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 13, m.movie_strdate),111)))"
            ''wkSQL += vbNewLine + " ) as second_week_qty,"
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as third_week_qty"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, 14, m.movie_strdate),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 20, m.movie_strdate),111))"
            ''wkSQL += vbNewLine + " or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, 14, m.movie_strdate),111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 20, m.movie_strdate),111)))"
            ''wkSQL += vbNewLine + " ) as third_week_qty,"
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as revenue_amt"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and (tr.theater_id not in ('52','6','58') or tc.theater_id not in ('52','6','58'))"
            ''wkSQL += vbNewLine + " ) as key_city_revenue_amt,"
            ''wkSQL += vbNewLine + " (select sumRev from vSumRevRpt where movie_id = m.movie_id) as sumRevAll ,"
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " select convert(decimal, (sum(isnull(tr.revenue_adms, 0)) + sum( isnull(tc.comprevenue_admssum, 0)))) as adms_amt"
            ''wkSQL += vbNewLine + " from tblMovie tm"
            ''wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            ''wkSQL += vbNewLine + " where tm.movie_id = m.movie_id"
            ''wkSQL += vbNewLine + " and (tr.theater_id not in ('52','6','58') or tc.theater_id not in ('52','6','58'))"
            ''wkSQL += vbNewLine + " ) as adms_amt"
            ''wkSQL += vbNewLine + " from tblMovie m"
            ''wkSQL += vbNewLine + " left join tblDistributor d on m.distributor_id = d.distributor_id"
            ''wkSQL += vbNewLine + " left join tblRevenue r on m.movie_id = r.movies_id"
            ''wkSQL += vbNewLine + " left join tblComprevenue cr on m.movie_id = cr.movies_id"
            ''wkSQL += vbNewLine + " left join "
            ''wkSQL += vbNewLine + " ( "
            ''wkSQL += vbNewLine + " select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
            ''wkSQL += vbNewLine + " max(cntSession) as cntSession, max(cntScreen) as cntScreen "
            ''wkSQL += vbNewLine + " from "
            ''wkSQL += vbNewLine + " ("
            ''wkSQL += vbNewLine + " SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
            ''wkSQL += vbNewLine + " max(cntSession) as cntSession, max(cntScreen) as cntScreen "
            ''wkSQL += vbNewLine + " FROM vRevToday "
            ''wkSQL += vbNewLine + " where  1=1"
            ''wkSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111) )"
            ''wkSQL += vbNewLine + " and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111) ))"
            ''wkSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111) )"
            ''wkSQL += vbNewLine + " and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111) ))"
            ''wkSQL += vbNewLine + " group by DateStatus, movie_id "
            ''wkSQL += vbNewLine + " ) as tblSum"
            ''wkSQL += vbNewLine + " group by  movie_id"
            ''wkSQL += vbNewLine + " ) AS vRevToday1 ON  m.movie_id = vRevToday1.movie_id "
            ''wkSQL += vbNewLine + " where (convert(varchar(19), m.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111)"
            ''wkSQL += vbNewLine + " and convert(varchar(19), m.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111))"
            ''wkSQL += vbNewLine + " and m.movie_status <> 4"
            ''wkSQL += vbNewLine + " group by m.movie_id, m.movie_strdate"
            ''wkSQL += vbNewLine + " ) rev"
            ''wkSQL += vbNewLine + " order by rev.movie_start_date, rev.movie_id"

            '---------
            wkSQL = "  select rev.movie_id, rev.movie_nameen as movie_name, rev.movietype_id, rev.nationality, rev.distributor_id, rev.distributor_name, rev.movie_start_date,"
            wkSQL += vbNewLine + "  isnull(rev.screen_qty, 0) as screen_qty, isnull(rev.screenMax, 0) as screenMax, isnull(rev.op_week_qty, 0) as op_week_qty1, isnull(rev.op_week_qty1, 0) as op_week_qty, isnull(rev.first_week_qty, 0) as first_week_qty, "
            wkSQL += vbNewLine + "  isnull(rev.second_week_qty, 0) as second_week_qty, isnull(rev.third_week_qty, 0) as third_week_qty,"
            wkSQL += vbNewLine + "  isnull(rev.key_city_revenue_amt, 0) as key_city_revenue_amt, rev.sumRevAll, isnull(rev.adms_amt, 0) as adms_amt, "
            wkSQL += vbNewLine + "  case when isnull(rev.adms_amt, 0) > 0 then"
            wkSQL += vbNewLine + "  (isnull(rev.key_city_revenue_amt, 0)/rev.adms_amt)"
            wkSQL += vbNewLine + "  else"
            wkSQL += vbNewLine + "  0 "
            wkSQL += vbNewLine + "  end atp_amt"
            wkSQL += vbNewLine + "  , movie_start_date, CONVERT(VARCHAR(10), movie_strdate, 7) AS newDate, "
            wkSQL += vbNewLine + "  LEFT(DATENAME(dw, movie_strdate), 3) AS movie_strdate_DDD,"
            wkSQL += vbNewLine + "  dbo.getCountDayToSun(convert(varchar(19), movie_strdate,111)) as DaySun"
            wkSQL += vbNewLine + "  from "
            wkSQL += vbNewLine + "  ("
            wkSQL += vbNewLine + " 	 select m.movie_id,min(m.movie_nameen) as movie_nameen, min(m.movie_nameen + '/' + m.movie_nameth) as movie_name, min(m.movietype_id) as movietype_id, min(m.movie_national) as nationality, "
            wkSQL += vbNewLine + " 	 min(m.distributor_id) as distributor_id, min(d.distributor_name) as distributor_name, "
            wkSQL += vbNewLine + " 	 min(convert(varchar(19), m.movie_strdate, 111)) as movie_start_date, m.movie_strdate as movie_strdate,"
            wkSQL += vbNewLine + " 	 isnull(sum(cr.comprevenue_screensum), 0) + count(distinct convert(varchar, r.theater_id) + 'A' + convert(varchar, r.theatersub_id)) as screen_qty,"
            wkSQL += vbNewLine + " 	 max(isnull(vRevToday1.cntScreen, 0)) as screenMax,	"
            wkSQL += vbNewLine + " 	("
            wkSQL += vbNewLine + " 		 select sum(isnull(a.revenue_amount,0)) as op_week_qty"
            wkSQL += vbNewLine + " 		 from"
            wkSQL += vbNewLine + " 		 ("
            wkSQL += vbNewLine + " 			 select top 4 tm.movie_id, tr.revenue_date, tc.comprevenue_date,"
            wkSQL += vbNewLine + " 			 convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as revenue_amount"
            wkSQL += vbNewLine + " 			 from tblMovie tm"
            wkSQL += vbNewLine + " 			 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 			 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 			 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 			 group by tm.movie_id, tr.revenue_date, tc.comprevenue_date"
            wkSQL += vbNewLine + " 			 order by tr.revenue_date, tc.comprevenue_date"
            wkSQL += vbNewLine + " 		 ) a"
            wkSQL += vbNewLine + " 	 ) as op_week_qty,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		 select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as first_week_qty"
            wkSQL += vbNewLine + " 		 from tblMovie tm"
            wkSQL += vbNewLine + " 		 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 		 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, -3, dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tr.revenue_date,111) <= dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111)) )"
            wkSQL += vbNewLine + " 		 or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, -3, dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tc.comprevenue_date,111) <= dbo.getCountDayToSun(convert(varchar(19), m.movie_strdate,111))))"
            wkSQL += vbNewLine + " 	 ) as op_week_qty1,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		 select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as first_week_qty"
            wkSQL += vbNewLine + " 		 from tblMovie tm"
            wkSQL += vbNewLine + " 		 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 		 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), m.movie_strdate,111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 6, m.movie_strdate),111))"
            wkSQL += vbNewLine + " 		 or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), m.movie_strdate,111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 6, m.movie_strdate),111)))"
            wkSQL += vbNewLine + " 	 ) as first_week_qty,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		 select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as second_week_qty"
            wkSQL += vbNewLine + " 		 from tblMovie tm"
            wkSQL += vbNewLine + " 		 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 		 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, 7, m.movie_strdate),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 13, m.movie_strdate),111))"
            wkSQL += vbNewLine + " 		 or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, 7, m.movie_strdate),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 13, m.movie_strdate),111)))"
            wkSQL += vbNewLine + " 	 ) as second_week_qty,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		 select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as third_week_qty"
            wkSQL += vbNewLine + " 		 from tblMovie tm"
            wkSQL += vbNewLine + " 		 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 		 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 and ((convert(varchar(19), tr.revenue_date,111) >= convert(varchar(19), dateadd(day, 14, m.movie_strdate),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tr.revenue_date,111) <= convert(varchar(19), dateadd(day, 20, m.movie_strdate),111))"
            wkSQL += vbNewLine + " 		 or (convert(varchar(19), tc.comprevenue_date,111) >= convert(varchar(19), dateadd(day, 14, m.movie_strdate),111)"
            wkSQL += vbNewLine + " 		 and convert(varchar(19), tc.comprevenue_date,111) <= convert(varchar(19), dateadd(day, 20, m.movie_strdate),111)))"
            wkSQL += vbNewLine + " 	 ) as third_week_qty,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		 select convert(decimal, (sum(isnull(tr.revenue_amount, 0)) + sum( isnull(tc.comprevenue_amountsum, 0)))) as revenue_amt"
            wkSQL += vbNewLine + " 		 from tblMovie tm"
            wkSQL += vbNewLine + " 		 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 		 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 and (tr.theater_id not in ('52','6','58') or tc.theater_id not in ('52','6','58'))"
            wkSQL += vbNewLine + " 	 ) as key_city_revenue_amt,"
            wkSQL += vbNewLine + " 	 ("
            wkSQL += vbNewLine + " 		select sumRev from vSumRevRpt where movie_id = m.movie_id) as sumRevAll ,"
            wkSQL += vbNewLine + " 		 ("
            wkSQL += vbNewLine + " 			 select convert(decimal, (sum(isnull(tr.revenue_adms, 0)) + sum( isnull(tc.comprevenue_admssum, 0)))) as adms_amt"
            wkSQL += vbNewLine + " 			 from tblMovie tm"
            wkSQL += vbNewLine + " 			 left join tblRevenue tr on tm.movie_id = tr.movies_id"
            wkSQL += vbNewLine + " 			 left join tblComprevenue tc on tm.movie_id = tc.movies_id"
            wkSQL += vbNewLine + " 			 where tm.movie_id = m.movie_id and tm.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 			 and (tr.theater_id not in ('52','6','58') or tc.theater_id not in ('52','6','58'))"
            wkSQL += vbNewLine + " 		 ) as adms_amt"
            wkSQL += vbNewLine + " 		 from tblMovie m"
            wkSQL += vbNewLine + " 		 left join tblDistributor d on m.distributor_id = d.distributor_id"
            wkSQL += vbNewLine + " 		 left join tblRevenue r on m.movie_id = r.movies_id"
            wkSQL += vbNewLine + " 		 left join tblComprevenue cr on m.movie_id = cr.movies_id"
            wkSQL += vbNewLine + " 		 left join "
            wkSQL += vbNewLine + " 		 ( "
            wkSQL += vbNewLine + " 			 select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
            wkSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
            wkSQL += vbNewLine + " 			 from "
            wkSQL += vbNewLine + " 			 ("
            wkSQL += vbNewLine + " 				 SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
            wkSQL += vbNewLine + " 				 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
            wkSQL += vbNewLine + " 				 FROM vRevToday "
            wkSQL += vbNewLine + "               where  1=1"
            wkSQL += vbNewLine + "               and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111) )"
            wkSQL += vbNewLine + "               and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111) ))"
            wkSQL += vbNewLine + "               or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111) )"
            wkSQL += vbNewLine + "               and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111) ))"
            wkSQL += vbNewLine + "               group by DateStatus, movie_id "
            wkSQL += vbNewLine + "            ) as tblSum"
            wkSQL += vbNewLine + "            group by  movie_id"
            wkSQL += vbNewLine + "       ) AS vRevToday1 ON  m.movie_id = vRevToday1.movie_id "
            wkSQL += vbNewLine + "       where (convert(varchar(19), m.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(strBeginDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "       and convert(varchar(19), m.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(strEndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + " 		 and m.movie_status <> 4"
            wkSQL += vbNewLine + " 		 and m.show_in_report_flag = 'Y'"
            wkSQL += vbNewLine + " 		 group by m.movie_id, m.movie_strdate"
            wkSQL += vbNewLine + " 	 ) rev"
            wkSQL += vbNewLine + "  order by rev.movie_start_date, rev.movie_id"

            Dim dtb As DataTable = cDatabase.GetDataTable(wkSQL)
            Dim decSumKeyCity, decSumAdms, decSumAtp As Decimal
            decSumKeyCity = 0
            decSumAdms = 0
            decSumAtp = 0
            For i As Integer = 0 To dtb.Rows.Count - 1
                Dim detailsRow As New TableRow()
                detailsRow.Font.Size = 9
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                detailsRow.Cells(0).Width = 250
                detailsRow.Cells(0).Text = dtb.Rows(i)("movie_name")
                detailsRow.Height = 20
                If (Convert.ToInt32(dtb.Rows(i)("movietype_id")) = 1) Then
                    detailsRow.Cells(0).Font.Bold = True
                End If

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center 
                detailsRow.Cells(1).Text = dtb.Rows(i)("nationality")

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(2).Text = dtb.Rows(i)("distributor_name")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(3).Width = 100
                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(3).Text = Convert.ToDateTime(dtb.Rows(i)("movie_start_date")).ToString("dd-MMM-yyyy")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(4).Width = 80
                detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(4).Text = Convert.ToDecimal(dtb.Rows(i)("screenMax")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(5).Width = 80
                detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(5).Text = Convert.ToDecimal(dtb.Rows(i)("op_week_qty")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(6).Width = 80
                detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(6).Text = Convert.ToDecimal(dtb.Rows(i)("first_week_qty")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(7).Width = 80
                detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(7).Text = Convert.ToDecimal(dtb.Rows(i)("second_week_qty")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(8).Width = 80
                detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(8).Text = Convert.ToDecimal(dtb.Rows(i)("third_week_qty")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(9).Width = 80
                detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(9).Font.Bold = True
                detailsRow.Cells(9).Text = Convert.ToDecimal(dtb.Rows(i)("sumRevAll")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(10).Width = 80
                detailsRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(10).Text = Convert.ToDecimal(dtb.Rows(i)("adms_amt")).ToString("#,##0")

                detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(11).Width = 80
                detailsRow.Cells(11).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(11).Text = Convert.ToDecimal(dtb.Rows(i)("atp_amt")).ToString("#,##0.0")

                If (i Mod 2 = 0) Then
                    For j As Integer = 0 To 11
                        detailsRow.Cells(j).BackColor = Color.FromName("#eeeeee")
                    Next
                End If
                decSumKeyCity += Convert.ToDecimal(dtb.Rows(i)("sumRevAll"))
                decSumAdms += Convert.ToDecimal(dtb.Rows(i)("adms_amt"))
                decSumAtp += Convert.ToDecimal(dtb.Rows(i)("atp_amt"))
                tbl.Rows.Add(detailsRow)
            Next

            Dim detailsRowSum As New TableRow()
            detailsRowSum.Font.Size = 9
            'detailsRowSum.Height = 18
            For i As Integer = 0 To 11
                detailsRowSum.Cells.Add(New TableCell)
                detailsRowSum.Cells(i).HorizontalAlign = HorizontalAlign.Right
                detailsRowSum.Cells(i).BackColor = Color.FromName("#dddddd")
                detailsRowSum.Cells(i).Font.Bold = True
                If i = 9 Then
                    detailsRowSum.Cells(i).Text = decSumKeyCity.ToString("#,##0")
                ElseIf i = 10 Then
                    detailsRowSum.Cells(i).Text = decSumAdms.ToString("#,##0")
                ElseIf i = 11 Then
                    detailsRowSum.Cells(i).Text = Format(decSumKeyCity.ToString("#,##0") / decSumAdms.ToString("#,##0"), "#,##0.0") 'decSumAtp.ToString("#,##0.00")
                Else
                    detailsRowSum.Cells(i).Text = ""
                End If
            Next
            tbl.Rows.Add(detailsRowSum)
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptIndustryInfoParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=IndustryInfo.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"

            Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
            Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
            tbl.RenderControl(htmlWrite)
            'Response.Write(stringWrite.ToString())
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
            Response.End()
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
        
    End Sub
End Class