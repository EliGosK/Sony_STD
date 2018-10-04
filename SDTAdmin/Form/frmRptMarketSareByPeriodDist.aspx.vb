Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodDist
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Mid(Session("permission"), 11, 1) = "0" Then
            '    Response.Redirect("InfoPage.aspx")
            'End If
            Dim StartDate As String = Session("msRptStrDate").ToString
            Dim EndDate As String = Session("msRptEndDate").ToString
            'Dim wkType As String = Session("msRptType").ToString

            Dim wkSubGroup As String = Session("msRptSubGroup").ToString ' 0=ไม่เลือก, 1=Theater, 2=Circuit

            Dim wkSQL1, wkSQL2, wkSQLall As String

            'If wkType = "1" Then 'CTBV
            tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY DISTRIBUTOR"
            tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

            If (Convert.ToString(Session("msRptDateType")) = "1") Then

                wkSQLall = "SELECT tblDistributor.distributor_id, tblDistributor.distributor_name, " 'tblMovie_1.movie_strdate,
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) AS BOGross, "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) AS ADMS, "
                wkSQLall += vbNewLine + " count(distinct tblMovie_1.movie_id) AS TitleMovie, "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/ "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) AS ATP, "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /  "
                wkSQLall += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
                wkSQLall += vbNewLine + " FROM tblMovie "
                wkSQLall += vbNewLine + " left join tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id "
                wkSQLall += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
                wkSQLall += vbNewLine + " where (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + " and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQLall += vbNewLine + " AND (tblMovie.show_in_report_flag = 'Y')"
                'wkSQLall += vbNewLine + " where (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQLall += vbNewLine + " and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111))"
                'wkSQLall += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQLall += vbNewLine + " and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111))"
                wkSQLall += vbNewLine + " ) AS PercentCTBV "
                wkSQLall += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLall += vbNewLine + " RIGHT OUTER JOIN tblDistributor ON tblMovie_1.distributor_id = tblDistributor.distributor_id "
                wkSQLall += vbNewLine + " LEFT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLall += vbNewLine + " left join tblCompRevenue as tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQLall += vbNewLine + " where (convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + " and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                'wkSQLall += vbNewLine + " where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQLall += vbNewLine + " and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111))"
                'wkSQLall += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQLall += vbNewLine + " and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111))"
                wkSQLall += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQLall += vbNewLine + " and (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQLall += vbNewLine + " GROUP BY tblDistributor.distributor_id, tblDistributor.distributor_name " ',tblMovie_1.movie_strdate
                wkSQLall += vbNewLine + " ORDER BY BOGross DESC,tblDistributor.distributor_name"

                ''''''Grid1
                wkSQL1 = " select tblMovie_1.distributor_id, tblDistributor_1.distributor_name, " 'tblMovie_1.movie_strdate,
                wkSQL1 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
                wkSQL1 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
                wkSQL1 += vbNewLine + " count(distinct tblMovie_1.movie_id) AS TitleMovie, "
                wkSQL1 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/ "
                wkSQL1 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ATP, "
                wkSQL1 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /  "
                wkSQL1 += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
                wkSQL1 += vbNewLine + " from tblMovie "
                wkSQL1 += vbNewLine + " left join tblDistributor on tblMovie.distributor_id = tblDistributor.distributor_id "
                wkSQL1 += vbNewLine + " left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
                wkSQL1 += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
                wkSQL1 += vbNewLine + " where (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + " and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL1 += vbNewLine + " AND (tblMovie.show_in_report_flag = 'Y')"
                'wkSQL1 += vbNewLine + " where (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL1 += vbNewLine + " and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)"
                'wkSQL1 += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL1 += vbNewLine + " and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)))"
                wkSQL1 += vbNewLine + " and tblMovie.distributor_id in (1, 2, 3)"
                wkSQL1 += vbNewLine + " ) as PercentCTBV "
                wkSQL1 += vbNewLine + " from tblDistributor tblDistributor_1"
                wkSQL1 += vbNewLine + " left join tblMovie tblMovie_1 on tblDistributor_1.distributor_id = tblMovie_1.distributor_id "
                wkSQL1 += vbNewLine + " left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL1 += vbNewLine + " left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL1 += vbNewLine + " where (convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + " and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                'wkSQL1 += vbNewLine + " where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL1 += vbNewLine + " and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)"
                'wkSQL1 += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL1 += vbNewLine + " and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)))"
                wkSQL1 += vbNewLine + " and tblMovie_1.distributor_id in (1, 2, 3)"
                wkSQL1 += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQL1 += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y')"

                wkSQL1 += vbNewLine + " group by tblMovie_1.distributor_id, tblDistributor_1.distributor_name " ',tblMovie_1.movie_strdate
                wkSQL1 += vbNewLine + " order by BOGross DESC,tblDistributor_1.distributor_name"
            Else

                wkSQLall = " SELECT tblDistributor.distributor_id, tblDistributor.distributor_name,  "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) AS BOGross,  "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) AS ADMS,  "
                wkSQLall += vbNewLine + " count(distinct tblMovie_1.movie_id) AS TitleMovie,  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQLall += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/  "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) AS ATP,  "
                wkSQLall += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQLall += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + "
                wkSQLall += vbNewLine + " sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross "
                wkSQLall += vbNewLine + " FROM tblMovie  "
                wkSQLall += vbNewLine + " left join tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id  "
                wkSQLall += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id "
                wkSQLall += vbNewLine + "  where "
                wkSQLall += vbNewLine + " (tblMovie.show_in_report_flag = 'Y')"
                wkSQLall += vbNewLine + " AND (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQLall += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQLall += vbNewLine + " ) AS PercentCTBV  "
                wkSQLall += vbNewLine + " FROM tblMovie AS tblMovie_1  "
                wkSQLall += vbNewLine + " RIGHT OUTER JOIN tblDistributor ON tblMovie_1.distributor_id = tblDistributor.distributor_id  "
                wkSQLall += vbNewLine + " LEFT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id  "
                wkSQLall += vbNewLine + " left join tblCompRevenue as tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLall += vbNewLine + "  where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQLall += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQLall += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQLall += vbNewLine + " and tblMovie_1.movie_status <> 4"
                wkSQLall += vbNewLine + " and (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQLall += vbNewLine + " GROUP BY tblDistributor.distributor_id, tblDistributor.distributor_name  "

                wkSQLall += vbNewLine + " ORDER BY BOGross DESC,tblDistributor.distributor_name"

                'xxxxxxxxxxxxxxxxxxxxx
                ''''''Grid1
                wkSQL1 = " select tblMovie_1.distributor_id, tblDistributor_1.distributor_name, "
                wkSQL1 += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
                wkSQL1 += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
                wkSQL1 += vbNewLine + "  count(distinct tblMovie_1.movie_id) AS TitleMovie, "
                wkSQL1 += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/ "
                wkSQL1 += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ATP, "
                wkSQL1 += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /  "
                wkSQL1 += vbNewLine + "  (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
                wkSQL1 += vbNewLine + "  from tblMovie "
                wkSQL1 += vbNewLine + "  left join tblDistributor on tblMovie.distributor_id = tblDistributor.distributor_id "
                wkSQL1 += vbNewLine + "  left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
                wkSQL1 += vbNewLine + "  left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
                wkSQL1 += vbNewLine + "  where (tblMovie.show_in_report_flag = 'Y') and (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL1 += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL1 += vbNewLine + "  and tblMovie.distributor_id not in (1, 2, 3)"
                wkSQL1 += vbNewLine + "  ) as PercentCTBV "
                wkSQL1 += vbNewLine + "  from tblDistributor tblDistributor_1"
                wkSQL1 += vbNewLine + "  left join tblMovie tblMovie_1 on tblDistributor_1.distributor_id = tblMovie_1.distributor_id "
                wkSQL1 += vbNewLine + "  left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL1 += vbNewLine + "  left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL1 += vbNewLine + "  where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL1 += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL1 += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL1 += vbNewLine + "  and tblMovie_1.distributor_id not in (1, 2, 3)"
                wkSQL1 += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQL1 += vbNewLine + " and (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL1 += vbNewLine + "  group by tblMovie_1.distributor_id, tblDistributor_1.distributor_name "
                wkSQL1 += vbNewLine + "  order by BOGross DESC,tblDistributor_1.distributor_name"

            End If



            sqlMsg.SelectCommand = wkSQL1
            GridView1.DataSourceID = "sqlMsg"
            GridView1.DataBind()

            Dim sumBOGross, sumADMS, sumTitle As Double
            Dim sumPerceent, sumATP As Decimal
            sumBOGross = 0
            sumADMS = 0
            sumTitle = 0
            sumPerceent = 0
            sumATP = 0
            Dim cDB As New cDatabase
            Dim dataReader As IDataReader = cDB.GetDataAll(wkSQL1)
            While (dataReader.Read())
                sumBOGross = sumBOGross + Format(dataReader("BOGross"), "#,##0")
                sumADMS = sumADMS + Format(dataReader("ADMS"), "#,##0")
                sumTitle = sumTitle + Format(dataReader("TitleMovie"), "#,##0")
                sumPerceent = sumPerceent + Format(dataReader("PercentCTBV"), "#,##0.00")
                'sumATP = sumATP + Format(dataReader("ATP"), "#,##0.00")
                sumATP = sumBOGross / sumADMS
            End While
            dataReader.Close()
            tblFoot.Rows(0).Cells(0).Text = "TOTAL "
            tblFoot.Rows(0).Cells(1).Text = sumBOGross.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(2).Text = sumADMS.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(3).Text = sumTitle.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(4).Text = sumPerceent.ToString("#,##0.00") + " %"
            tblFoot.Rows(0).Cells(5).Text = sumATP.ToString("#,##0.00") + " "

            ''''''Grid2
            If (Convert.ToString(Session("msRptDateType")) = "1") Then

                wkSQL2 = "select tblMovie_1.distributor_id, tblDistributor_1.distributor_name, " ',tblMovie_1.movie_strdate
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
                wkSQL2 += vbNewLine + " count(distinct tblMovie_1.movie_id) AS TitleMovie, "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/ "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ATP, "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /  "
                wkSQL2 += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
                wkSQL2 += vbNewLine + " from tblMovie "
                wkSQL2 += vbNewLine + " left join tblDistributor on tblMovie.distributor_id = tblDistributor.distributor_id "
                wkSQL2 += vbNewLine + " left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
                wkSQL2 += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"

                wkSQL2 += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y') and (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + " and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                'wkSQL2 += vbNewLine + " where (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL2 += vbNewLine + " and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)"
                'wkSQL2 += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL2 += vbNewLine + " and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)))"
                wkSQL2 += vbNewLine + " and tblMovie.distributor_id not in (1, 2, 3)"
                wkSQL2 += vbNewLine + " ) as PercentCTBV "
                wkSQL2 += vbNewLine + " from tblDistributor tblDistributor_1"
                wkSQL2 += vbNewLine + " left join tblMovie tblMovie_1 on tblDistributor_1.distributor_id = tblMovie_1.distributor_id "
                wkSQL2 += vbNewLine + " left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL2 += vbNewLine + " left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"

                wkSQL2 += vbNewLine + " where (convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + " and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                'wkSQL2 += vbNewLine + " where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL2 += vbNewLine + " and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)"
                'wkSQL2 += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + StartDate + "', 111)"
                'wkSQL2 += vbNewLine + " and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + EndDate + "', 111)))"
                wkSQL2 += vbNewLine + " and tblMovie_1.distributor_id not in (1, 2, 3)"
                wkSQL2 += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQL2 += vbNewLine + " and (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL2 += vbNewLine + " group by tblMovie_1.distributor_id, tblDistributor_1.distributor_name " ',tblMovie_1.movie_strdate
                wkSQL2 += vbNewLine + " order by BOGross DESC,tblDistributor_1.distributor_name"
            Else
                wkSQL2 = " select tblMovie_1.distributor_id, tblDistributor_1.distributor_name,  "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross,  "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS,  "
                wkSQL2 += vbNewLine + " count(distinct tblMovie_1.movie_id) AS TitleMovie,  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL2 += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/  "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + "
                wkSQL2 += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ATP,  "
                wkSQL2 += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQL2 += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + "
                wkSQL2 += vbNewLine + " sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross "
                wkSQL2 += vbNewLine + " from tblMovie  left join tblDistributor on tblMovie.distributor_id = tblDistributor.distributor_id  "
                wkSQL2 += vbNewLine + " left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id  "
                wkSQL2 += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id "
                wkSQL2 += vbNewLine + "  where (tblMovie_1.show_in_report_flag = 'Y') and (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL2 += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL2 += vbNewLine + " and tblMovie.distributor_id not in (1, 2, 3) ) as PercentCTBV  "
                wkSQL2 += vbNewLine + " from tblDistributor tblDistributor_1 "
                wkSQL2 += vbNewLine + " left join tblMovie tblMovie_1 on tblDistributor_1.distributor_id = tblMovie_1.distributor_id  "
                wkSQL2 += vbNewLine + " left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id  "
                wkSQL2 += vbNewLine + " left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL2 += vbNewLine + "  where (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL2 += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL2 += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL2 += vbNewLine + " and tblMovie_1.distributor_id not in (1, 2, 3) "
                wkSQL2 += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQL2 += vbNewLine + " and (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL2 += vbNewLine + " group by tblMovie_1.distributor_id, tblDistributor_1.distributor_name"
                wkSQL2 += vbNewLine + " order by BOGross DESC"
            End If

            sqlMsg2.SelectCommand = wkSQL2
            GridView2.DataSourceID = "sqlMsg2"
            GridView2.DataBind()

            Dim sumBOGross2, sumADMS2, sumTitle2 As Double
            Dim sumPerceent2, sumATP2 As Decimal
            sumBOGross2 = 0
            sumADMS2 = 0
            sumTitle2 = 0
            sumPerceent2 = 0
            sumATP2 = 0
            Dim dataReader2 As IDataReader = cDB.GetDataAll(wkSQL2)
            While (dataReader2.Read())
                sumBOGross2 = sumBOGross2 + Format(dataReader2("BOGross"), "#,##0")
                sumADMS2 = sumADMS2 + Format(dataReader2("ADMS"), "#,##0")
                sumTitle2 = sumTitle2 + Format(dataReader2("TitleMovie"), "#,##0")
                sumPerceent2 = sumPerceent2 + Format(dataReader2("PercentCTBV"), "#,##0.00")
                'sumATP2 = sumATP2 + Format(dataReader2("ATP"), "#,##0.00")
                sumATP2 = sumBOGross2 / sumADMS2
            End While
            dataReader2.Close()
            Table1.Rows(0).Cells(0).Text = "TOTAL "
            Table1.Rows(0).Cells(1).Text = sumBOGross2.ToString("#,##0") + " "
            Table1.Rows(0).Cells(2).Text = sumADMS2.ToString("#,##0") + " "
            Table1.Rows(0).Cells(3).Text = sumTitle2.ToString("#,##0") + " "
            Table1.Rows(0).Cells(4).Text = sumPerceent2.ToString("#,##0.00") + " %"
            Table1.Rows(0).Cells(5).Text = sumATP2.ToString("#,##0.00") + " "


            ''''''Total
            Dim sumBOGross3, sumADMS3, sumTitle3 As Double
            Dim sumPerceent3, sumATP3 As Decimal
            sumBOGross3 = 0
            sumADMS3 = 0
            sumTitle3 = 0
            sumPerceent3 = 0
            sumATP3 = 0
            Dim dataReader3 As IDataReader = cDB.GetDataAll(wkSQLall)
            While (dataReader3.Read())
                sumBOGross3 = sumBOGross3 + Format(dataReader3("BOGross"), "#,##0")
                sumADMS3 = sumADMS3 + Format(dataReader3("ADMS"), "#,##0")
                sumTitle3 = sumTitle3 + Format(dataReader3("TitleMovie"), "#,##0")
                sumPerceent3 = sumPerceent3 + Format(dataReader3("PercentCTBV"), "#,##0.00")
                'sumATP3 = sumATP3 + Format(dataReader3("ATP"), "#,##0.00")
                sumATP3 = sumBOGross3 / sumADMS3
            End While
            dataReader3.Close()
            Table2.Rows(0).Cells(0).Text = "TOTAL MPAA"
            Table2.Rows(0).Cells(1).Text = sumBOGross3.ToString("#,##0") + " "
            Table2.Rows(0).Cells(2).Text = sumADMS3.ToString("#,##0") + " "
            Table2.Rows(0).Cells(3).Text = sumTitle3.ToString("#,##0") + " "
            Table2.Rows(0).Cells(4).Text = sumPerceent3.ToString("#,##0.00") + " %"
            Table2.Rows(0).Cells(5).Text = sumATP3.ToString("#,##0.00") + " "

        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
      
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptMarketSareByPeriodParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            If GridView1.Rows.Count.ToString + 1 < 65536 Then
                If GridView2.Rows.Count.ToString + 1 < 65536 Then
                    GridView1.AllowPaging = False
                    GridView1.AllowSorting = False
                    GridView1.Width = 800
                    GridView1.DataBind()
                    GridView2.AllowPaging = False
                    GridView2.AllowSorting = False
                    GridView2.Width = 800
                    GridView2.DataBind()
                    Dim tw As New IO.StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    frm.Attributes("runat") = "server"
                    frm.Controls.Add(panel1)
                    frm.Controls.Add(tbl)
                    frm.Controls.Add(GridView1)
                    frm.Controls.Add(tblFoot)
                    frm.Controls.Add(GridView2)
                    frm.Controls.Add(Table1)
                    frm.Controls.Add(Table2)
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
                    GridView1.AllowPaging = True
                    GridView1.AllowSorting = True
                    GridView1.DataBind()
                    GridView2.AllowPaging = True
                    GridView2.AllowSorting = True
                    GridView2.DataBind()
                End If
            End If
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
      
    End Sub


End Class