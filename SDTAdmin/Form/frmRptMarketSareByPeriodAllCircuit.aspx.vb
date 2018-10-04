Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodAllCircuit
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Mid(Session("permission"), 11, 1) = "0" Then
            '    Response.Redirect("InfoPage.aspx")
            'End If
            Dim wkStudioId As String = Request.QueryString("StudioId")
            Session("msRptStudioId") = wkStudioId
            Dim StartDate As String = Session("msRptStrDate").ToString
            Dim EndDate As String = Session("msRptEndDate").ToString
            'Dim wkType As String = Session("msRptType").ToString
            Dim wkSQL As String = ""
            Dim wkSQLCM As String = ""
            Dim wkSQLKeyCity As String = ""

            '' ''If wkType = "1" Then 'CTBV

            tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

            If (Convert.ToString(Session("msRptDateType")) = "1") Then
                wkSQL = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag, "
                wkSQL += vbNewLine + " sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS,"
                wkSQL += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQL += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQL += vbNewLine + " else"
                wkSQL += vbNewLine + " 		0"
                wkSQL += vbNewLine + " end PercentByBkk,"
                wkSQL += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQL += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQL += vbNewLine + " else"
                wkSQL += vbNewLine + " 		0"
                wkSQL += vbNewLine + " end PercentByKeyCity,"
                wkSQL += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie "
                wkSQL += vbNewLine + " from "
                wkSQL += vbNewLine + " ("
                wkSQL += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS, "
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQL += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByBkk, "
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQL += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQL += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQL += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQL += vbNewLine + " GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id" ',tblMovie_1.movie_strdate

                wkSQL += vbNewLine + " UNION "

                wkSQL += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS, "
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQL += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCompRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByBkk, "
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQL += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQL += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQL += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCompRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQL += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQL += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQL += vbNewLine + " GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id " ',tblMovie_1.movie_strdate
                wkSQL += vbNewLine + " ) cir"
                wkSQL += vbNewLine + " group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag" ', cir.studio_id, cir.studio_name" ',cir.movie_strdate
                wkSQL += vbNewLine + " order by cir.circuit_name"

                wkSQLCM = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag, "
                wkSQLCM += vbNewLine + "  sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS, "
                wkSQLCM += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQLCM += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQLCM += vbNewLine + " else"
                wkSQLCM += vbNewLine + " 		0"
                wkSQLCM += vbNewLine + " end PercentByBkk,"
                wkSQLCM += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQLCM += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQLCM += vbNewLine + " else"
                wkSQLCM += vbNewLine + " 		0"
                wkSQLCM += vbNewLine + " end PercentByKeyCity,"
                wkSQLCM += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie"
                wkSQLCM += vbNewLine + " from ("
                wkSQLCM += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS,  "
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + " left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLCM += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByBkk,  "
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLCM += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND  (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQLCM += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLCM += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND  (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQLCM += vbNewLine + " GROUP BY  tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id" ',tblMovie_1.movie_strdate
                wkSQLCM += vbNewLine + " UNION "
                wkSQLCM += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS,  "
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + " left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLCM += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByBkk,  "
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLCM += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND  (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQLCM += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLCM += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND  (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLCM += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQLCM += vbNewLine + " GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id " ',tblMovie_1.movie_strdate
                wkSQLCM += vbNewLine + " ) cir"
                wkSQLCM += vbNewLine + " group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag" ', cir.studio_id, cir.studio_name" ',cir.movie_strdate
                wkSQLCM += vbNewLine + " order by cir.circuit_name"



                wkSQLKeyCity = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag, "
                wkSQLKeyCity += vbNewLine + "  sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS, "
                wkSQLKeyCity += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQLKeyCity += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQLKeyCity += vbNewLine + " else"
                wkSQLKeyCity += vbNewLine + " 		0"
                wkSQLKeyCity += vbNewLine + " end PercentByBkk,"
                wkSQLKeyCity += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQLKeyCity += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQLKeyCity += vbNewLine + " else"
                wkSQLKeyCity += vbNewLine + " 		0"
                wkSQLKeyCity += vbNewLine + " end PercentByKeyCity,"
                wkSQLKeyCity += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie"
                wkSQLKeyCity += vbNewLine + " from ("
                wkSQLKeyCity += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQLKeyCity += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQLKeyCity += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS,  "
                wkSQLKeyCity += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + " left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND (tblRevenue_1.theater_id in ('6', '52', '58'))"
                'wkSQLKeyCity += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLKeyCity += vbNewLine + " ) AS PercentByBkk,  "
                wkSQLKeyCity += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND  (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLKeyCity += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQLKeyCity += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLKeyCity += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND  (tblRevenue_1.theater_id in ('6', '52', '58'))"
                'wkSQLKeyCity += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQLKeyCity += vbNewLine + " GROUP BY  tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id" ',tblMovie_1.movie_strdate
                wkSQLKeyCity += vbNewLine + " UNION "
                wkSQLKeyCity += vbNewLine + " SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, " ',tblMovie_1.movie_strdate
                wkSQLKeyCity += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQLKeyCity += vbNewLine + " SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS,  "
                wkSQLKeyCity += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + " left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                'wkSQLKeyCity += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLKeyCity += vbNewLine + " ) AS PercentByBkk,  "
                wkSQLKeyCity += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + " left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE(convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND  (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLKeyCity += vbNewLine + " ) AS PercentByKeyCity, "
                wkSQLKeyCity += vbNewLine + " COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLKeyCity += vbNewLine + " FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + " left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLKeyCity += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + " left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLKeyCity += vbNewLine + " left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLKeyCity += vbNewLine + " WHERE (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + " AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + " AND  (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                'wkSQLKeyCity += vbNewLine + " AND (tblStudio_1.studio_id = " + wkStudioId + ") "
                wkSQLKeyCity += vbNewLine + " GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag" ',tblStudio_1.studio_name, tblStudio_1.studio_id " ',tblMovie_1.movie_strdate
                wkSQLKeyCity += vbNewLine + " ) cir"
                wkSQLKeyCity += vbNewLine + " group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag" ', cir.studio_id, cir.studio_name" ',cir.movie_strdate
                wkSQLKeyCity += vbNewLine + " order by cir.circuit_name"

            Else
                wkSQL = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag,"
                wkSQL += vbNewLine + " sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS,"
                wkSQL += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQL += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQL += vbNewLine + " else"
                wkSQL += vbNewLine + " 		0"
                wkSQL += vbNewLine + " end PercentByBkk,"
                wkSQL += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQL += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQL += vbNewLine + " else"
                wkSQL += vbNewLine + " 		0"
                wkSQL += vbNewLine + " end PercentByKeyCity,"
                wkSQL += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie"
                wkSQL += vbNewLine + "  from "
                wkSQL += vbNewLine + "  ("
                wkSQL += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag,"
                wkSQL += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQL += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS, "
                wkSQL += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQL += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + "  AND (tblCircuit.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  ) AS PercentByBkk, "
                wkSQL += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQL += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQL += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQL += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQL += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQL += vbNewLine + "  UNION "
                wkSQL += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, "
                wkSQL += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQL += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS, "
                wkSQL += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQL += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + "  AND (tblCompRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblcompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  ) AS PercentByBkk, "
                wkSQL += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQL += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblcompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQL += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQL += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQL += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQL += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQL += vbNewLine + "  AND (tblCompRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQL += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblcompRevenue_1.movies_id "
                wkSQL += vbNewLine + "  GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQL += vbNewLine + "  ) cir"
                wkSQL += vbNewLine + "  group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag"
                wkSQL += vbNewLine + "  order by cir.circuit_name"


                wkSQLCM = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag, "
                wkSQLCM += vbNewLine + "  sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS, "
                wkSQLCM += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQLCM += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQLCM += vbNewLine + " else"
                wkSQLCM += vbNewLine + " 		0"
                wkSQLCM += vbNewLine + " end PercentByBkk,"
                wkSQLCM += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQLCM += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQLCM += vbNewLine + " else"
                wkSQLCM += vbNewLine + " 		0"
                wkSQLCM += vbNewLine + " end PercentByKeyCity,"
                wkSQLCM += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie"
                wkSQLCM += vbNewLine + "  from ("
                wkSQLCM += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, "
                wkSQLCM += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQLCM += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS,  "
                wkSQLCM += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLCM += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  ) AS PercentByBkk,  "
                wkSQLCM += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLCM += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQLCM += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLCM += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLCM += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND  (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  GROUP BY  tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQLCM += vbNewLine + "  UNION "
                wkSQLCM += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, "
                wkSQLCM += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQLCM += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS,  "
                wkSQLCM += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLCM += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + "  AND (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  ) AS PercentByBkk,  "
                wkSQLCM += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLCM += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQLCM += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLCM += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLCM += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLCM += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLCM += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLCM += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + "  AND  (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLCM += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLCM += vbNewLine + "  GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQLCM += vbNewLine + "  ) cir"
                wkSQLCM += vbNewLine + "  group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag"
                wkSQLCM += vbNewLine + "  order by cir.circuit_name"


                wkSQLKeyCity = " select cir.circuit_id, cir.circuit_name, cir.show_in_report_flag, "
                wkSQLKeyCity += vbNewLine + "  sum(cir.BoxOffice) as BoxOffice, sum(cir.ADMS) as ADMS, "
                wkSQLKeyCity += vbNewLine + " case when sum(PercentByBkk) > 0 then"
                wkSQLKeyCity += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByBkk)"
                wkSQLKeyCity += vbNewLine + " else"
                wkSQLKeyCity += vbNewLine + " 		0"
                wkSQLKeyCity += vbNewLine + " end PercentByBkk,"
                wkSQLKeyCity += vbNewLine + " case when sum(PercentByKeyCity) > 0 then"
                wkSQLKeyCity += vbNewLine + " 		sum(cir.BoxOffice) * 100 / sum(PercentByKeyCity)"
                wkSQLKeyCity += vbNewLine + " else"
                wkSQLKeyCity += vbNewLine + " 		0"
                wkSQLKeyCity += vbNewLine + " end PercentByKeyCity,"
                wkSQLKeyCity += vbNewLine + " sum(cir.NoOfMovie) as NoOfMovie"
                wkSQLKeyCity += vbNewLine + "  from ("
                wkSQLKeyCity += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag,"
                wkSQLKeyCity += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS BoxOffice, "
                wkSQLKeyCity += vbNewLine + "  SUM(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) AS ADMS,  "
                wkSQLKeyCity += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  left join tblTheater ON tblRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + "  AND (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLKeyCity += vbNewLine + "  ) AS PercentByBkk,  "
                wkSQLKeyCity += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQLKeyCity += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLKeyCity += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblRevenue_1.revenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblRevenue_1.revenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + "  AND  (tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLKeyCity += vbNewLine + "  GROUP BY  tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQLKeyCity += vbNewLine + "  UNION "
                wkSQLKeyCity += vbNewLine + "  SELECT DISTINCT tblCircuit_1.circuit_id, tblCircuit_1.circuit_name, tblMovie_1.show_in_report_flag, "
                wkSQLKeyCity += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS BoxOffice, "
                wkSQLKeyCity += vbNewLine + "  SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0))) AS ADMS,  "
                wkSQLKeyCity += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  left join tblTheater ON tblCompRevenue_1.theater_id = tblTheater.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + "  AND (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLKeyCity += vbNewLine + "  ) AS PercentByBkk,  "
                wkSQLKeyCity += vbNewLine + "  (SELECT SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice "
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio AS tblStudio_2 ON tblMovie_1.studio_id = tblStudio_2.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  left join tblTheater AS tblTheater_2 ON tblCompRevenue_1.theater_id = tblTheater_2.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit AS tblCircuit_2 ON tblTheater_2.circuit_id = tblCircuit_2.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_2.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  ) AS PercentByKeyCity, "
                wkSQLKeyCity += vbNewLine + "  COUNT(distinct tblMovie_1.movie_id) AS NoOfMovie"
                wkSQLKeyCity += vbNewLine + "  FROM tblMovie AS tblMovie_1 "
                wkSQLKeyCity += vbNewLine + "  left join tblStudio AS tblStudio_1 ON tblMovie_1.studio_id = tblStudio_1.studio_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQLKeyCity += vbNewLine + "  left join tblTheater AS tblTheater_1 ON tblCompRevenue_1.theater_id = tblTheater_1.theater_id "
                wkSQLKeyCity += vbNewLine + "  left join tblCircuit AS tblCircuit_1 ON tblTheater_1.circuit_id = tblCircuit_1.circuit_id"
                wkSQLKeyCity += vbNewLine + "  WHERE (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "') "
                wkSQLKeyCity += vbNewLine + "  AND (convert(varchar(19), tblcompRevenue_1.comprevenue_date,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLKeyCity += vbNewLine + " AND (tblCircuit_1.circuit_id Is Not null)"
                wkSQLKeyCity += vbNewLine + "  AND (tblMovie_1.show_in_report_flag = 'Y') AND tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                'wkSQLKeyCity += vbNewLine + "  AND  (tblCompRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLKeyCity += vbNewLine + "  GROUP BY tblCircuit_1.circuit_name, tblCircuit_1.circuit_id, tblMovie_1.show_in_report_flag"
                wkSQLKeyCity += vbNewLine + "  ) cir"
                wkSQLKeyCity += vbNewLine + "  group by cir.circuit_id, cir.circuit_name, cir.show_in_report_flag"
                wkSQLKeyCity += vbNewLine + "  order by cir.circuit_name"

            End If




            sqlMsg.SelectCommand = wkSQL
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
            Dim dataReader As IDataReader = cDB.GetDataAll(wkSQL)
            Dim i As Integer = 0
            While (dataReader.Read())
                If i = 0 Then
                    tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY CIRCUIT"
                End If

                sumBOGross = sumBOGross + Format(dataReader("BoxOffice"), "#,##0")
                sumADMS = sumADMS + Format(dataReader("ADMS"), "#,##0")
                sumTitle = sumTitle + Format(dataReader("NoOfMovie"), "#,##0")
                sumPerceent = sumPerceent + Format(dataReader("PercentByBkk"), "#,##0.00")
                sumATP = sumATP + Format(dataReader("PercentByKeyCity"), "#,##0.00")
                i = i + 1
            End While
            dataReader.Close()
            tblFoot.Rows(0).Cells(0).Text = "TOTAL FOR BANGKOK "
            tblFoot.Rows(0).Cells(1).Text = sumBOGross.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(2).Text = sumADMS.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(3).Text = "" 'sumTitle.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(4).Text = "100.00%" 'sumPerceent.ToString("#,##0.00") + " %"
            tblFoot.Rows(0).Cells(5).Text = "100.00%" 'sumATP.ToString("#,##0.00") + " %"
            tblFoot.Rows(0).Cells(5).Visible = False
            tblFoot.Rows(0).Cells(1).HorizontalAlign = HorizontalAlign.Right
            tblFoot.Rows(0).Cells(2).HorizontalAlign = HorizontalAlign.Right
            tblFoot.Rows(0).Cells(3).HorizontalAlign = HorizontalAlign.Right
            tblFoot.Rows(0).Cells(4).HorizontalAlign = HorizontalAlign.Right
            tblFoot.Rows(0).Cells(5).HorizontalAlign = HorizontalAlign.Right

            'CM
            sqlMsgCM.SelectCommand = wkSQLCM
            GridView2.DataSourceID = "sqlMsgCM"
            GridView2.DataBind()

            Dim sumBOGrossCM, sumADMSCM, sumTitleCM As Double
            Dim sumPerceentCM, sumATPCM As Decimal
            sumBOGrossCM = 0
            sumADMSCM = 0
            sumTitleCM = 0
            sumPerceentCM = 0
            sumATPCM = 0
            Dim dataReaderCM As IDataReader = cDB.GetDataAll(wkSQLCM)
            Dim icm As Integer = 0
            While (dataReaderCM.Read())
                If icm = 0 Then
                    tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY CIRCUIT"
                End If
                sumBOGrossCM = sumBOGrossCM + Format(dataReaderCM("BoxOffice"), "#,##0")
                sumADMSCM = sumADMSCM + Format(dataReaderCM("ADMS"), "#,##0")
                sumTitleCM = sumTitleCM + Format(dataReaderCM("NoOfMovie"), "#,##0")
                sumPerceentCM = sumPerceentCM + Format(dataReaderCM("PercentByBkk"), "#,##0.00")
                sumATPCM = sumATPCM + Format(dataReaderCM("PercentByKeyCity"), "#,##0.00")
                icm = icm + 1
            End While
            dataReaderCM.Close()
            tblFootCM.Rows(0).Cells(0).Text = "TOTAL FOR CHIENG MAI "
            tblFootCM.Rows(0).Cells(1).Text = sumBOGrossCM.ToString("#,##0") + " "
            tblFootCM.Rows(0).Cells(2).Text = sumADMSCM.ToString("#,##0") + " "
            tblFootCM.Rows(0).Cells(3).Text = "" 'sumTitleCM.ToString("#,##0") + " "
            tblFootCM.Rows(0).Cells(4).Text = "100.00%" 'sumPerceentCM.ToString("#,##0.00") + " %"
            tblFootCM.Rows(0).Cells(5).Text = "100.00%" 'sumATPCM.ToString("#,##0.00") + " %"
            tblFootCM.Rows(0).Cells(5).Visible = False


            SqlMsgKeyCity.SelectCommand = wkSQLKeyCity
            GridView3.DataSourceID = "SqlMsgKeyCity"
            GridView3.DataBind()

            Dim sumBOGrossKeyCity, sumADMSKeyCity, sumTitleKeyCity As Double
            Dim sumPerceentKeyCity, sumATPKeyCity As Decimal
            sumBOGrossKeyCity = 0
            sumADMSKeyCity = 0
            sumTitleKeyCity = 0
            sumPerceentKeyCity = 0
            sumATPKeyCity = 0
            Dim dataReaderKeyCity As IDataReader = cDB.GetDataAll(wkSQLKeyCity)
            Dim iKeyCity As Integer = 0
            While (dataReaderKeyCity.Read())
                If iKeyCity = 0 Then
                    tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY CIRCUIT"
                End If
                sumBOGrossKeyCity = sumBOGrossKeyCity + Format(dataReaderKeyCity("BoxOffice"), "#,##0")
                sumADMSKeyCity = sumADMSKeyCity + Format(dataReaderKeyCity("ADMS"), "#,##0")
                sumTitleKeyCity = sumTitleKeyCity + Format(dataReaderKeyCity("NoOfMovie"), "#,##0")
                sumPerceentKeyCity = sumPerceentKeyCity + Format(dataReaderKeyCity("PercentByBkk"), "#,##0.00")
                sumATPKeyCity = sumATPKeyCity + Format(dataReaderKeyCity("PercentByKeyCity"), "#,##0.00")
                iKeyCity = iKeyCity + 1
            End While
            dataReaderKeyCity.Close()

            tblFootKeyCity.Rows(0).Cells(0).Text = "TOTAL FOR KEY CITY "
            tblFootKeyCity.Rows(0).Cells(1).Text = (sumBOGross + sumBOGrossCM).ToString("#,##0") + " "
            tblFootKeyCity.Rows(0).Cells(2).Text = (sumADMS + sumADMSCM).ToString("#,##0") + " "
            tblFootKeyCity.Rows(0).Cells(3).Text = "" '(sumTitle + sumTitleCM).ToString("#,##0") + " "
            tblFootKeyCity.Rows(0).Cells(4).Text = "100.00%" 'sumPerceentCM.ToString("#,##0.00") + " %"
            tblFootKeyCity.Rows(0).Cells(5).Text = "100.00%" 'sumATPCM.ToString("#,##0.00") + " %"
            tblFootKeyCity.Rows(0).Cells(5).Visible = False

            'TOTAL
            'tblFootKeyCity.Rows(1).Cells(0).Text = "TOTAL"
            'tblFootKeyCity.Rows(1).Cells(1).Text = (sumBOGross + sumBOGrossKeyCity).ToString("#,##0") + " "
            'tblFootKeyCity.Rows(1).Cells(2).Text = (sumADMS + sumADMSKeyCity).ToString("#,##0") + " "
            'tblFootKeyCity.Rows(1).Cells(3).Text = (sumTitle + sumTitleKeyCity).ToString("#,##0") + " "
            'tblFootKeyCity.Rows(1).Cells(4).Text = "100.00%" '(sumPerceent + sumPerceentKeyCity).ToString("#,##0.00") + " %"
            'tblFootKeyCity.Rows(1).Cells(5).Text = "100.00%" '(sumATP + sumATPKeyCity).ToString("#,##0.00") + " %"
            'tblFootKeyCity.Rows(1).Cells(5).Visible = False

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
                    If GridView3.Rows.Count.ToString + 1 < 65536 Then
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
                        frm.Controls.Add(tblCM)
                        frm.Controls.Add(GridView2)
                        frm.Controls.Add(tblFootCM)
                        Response.AddHeader("content-disposition", "attachment;filename=Market_Share_By_Circuit.xls")
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
                        GridView3.AllowPaging = True
                        GridView3.AllowSorting = True
                        GridView3.DataBind()
                    End If
                End If
            End If
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
       
    End Sub


End Class