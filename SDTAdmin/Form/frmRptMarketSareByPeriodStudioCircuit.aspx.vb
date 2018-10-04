Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodStudioCircuit
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

            '' ''If wkType = "1" Then 'CTBV

            tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")


            If (Convert.ToString(Session("msRptDateType")) = "1") Then '1=Release Date, 2=Box Office in Date

                wkSQL = " SELECT DISTINCT max(circuit_id) as circuit_id, max(circuit_name) as circuit_name, "
                wkSQL += vbNewLine + " max(studio_name) as studio_name, max(studio_id) as studio_id,"
                wkSQL += vbNewLine + " sum(BoxOffice) as BoxOffice, sum(ADMS) as ADMS,"
                wkSQL += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByBkk1)) as PercentByBkk,"
                wkSQL += vbNewLine + " max(PercentByBkk1) as PercentByBkk1, "
                wkSQL += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByKeyCity1)) as PercentByKeyCity,"
                wkSQL += vbNewLine + " max(PercentByKeyCity1) as PercentByKeyCity1, "
                wkSQL += vbNewLine + " sum(NoOfMovie) as NoOfMovie"
                wkSQL += vbNewLine + " from ("
                wkSQL += vbNewLine + " SELECT DISTINCT (isnull(tblCircuit_11.circuit_id,'') + isnull(tblCircuit_21.circuit_id,'')) as circuit_id, "
                wkSQL += vbNewLine + " (isnull(tblCircuit_11.circuit_name,'') + isnull(tblCircuit_21.circuit_name,'')) as circuit_name, "
                wkSQL += vbNewLine + " tblStudio_11.studio_name, "
                wkSQL += vbNewLine + " tblStudio_11.studio_id, "
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_amount,0)))"
                wkSQL += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_amountsum,0))) AS BoxOffice,"
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_adms,0))) "
                wkSQL += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_admssum,0))) AS ADMS,"
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1"
                wkSQL += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND ((tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " or (tblCompRevenue_1.theater_id not in ('6', '52', '58')))"
                wkSQL += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByBkk1,"
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_2.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_2.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_2"
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_2.studio_id = tblStudio_2.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_2 ON tblMovie_2.movie_id = tblRevenue_2.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_2 ON tblMovie_2.movie_id = tblCompRevenue_2.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_2.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie_2.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_2.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " )PercentByKeyCity1,"
                wkSQL += vbNewLine + " COUNT(distinct tblMovie_11.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_11"
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_11 ON tblMovie_11.studio_id = tblStudio_11.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_11 ON tblMovie_11.movie_id = tblRevenue_11.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_11 ON tblMovie_11.movie_id = tblCompRevenue_11.movies_id"
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_11 ON tblRevenue_11.theater_id = tblTheater_11.theater_id"
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_21 ON tblCompRevenue_11.theater_id = tblTheater_21.theater_id"
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_11 ON tblTheater_11.circuit_id = tblCircuit_11.circuit_id"
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_21 ON tblTheater_21.circuit_id = tblCircuit_21.circuit_id"
                wkSQL += vbNewLine + " where (tblMovie_11.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie_11.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblMovie_11.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND ((tblRevenue_11.theater_id not in ('6', '52', '58')) or (tblCompRevenue_11.theater_id not in ('6', '52', '58')))"
                wkSQL += vbNewLine + " AND (tblStudio_11.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " GROUP BY tblCircuit_11.circuit_name,tblCircuit_21.circuit_name, "
                wkSQL += vbNewLine + " tblCircuit_11.circuit_id, tblCircuit_21.circuit_id,"
                wkSQL += vbNewLine + " tblStudio_11.studio_name, tblStudio_11.studio_id"
                wkSQL += vbNewLine + " ) aa"
                wkSQL += vbNewLine + " group by circuit_id, circuit_name, studio_name, studio_id,"
                wkSQL += vbNewLine + " PercentByBkk1, PercentByKeyCity1"




                wkSQLCM = " SELECT DISTINCT max(circuit_id) as circuit_id, max(circuit_name) as circuit_name, "
                wkSQLCM += vbNewLine + " max(studio_name) as studio_name, max(studio_id) as studio_id,"
                wkSQLCM += vbNewLine + " sum(BoxOffice) as BoxOffice, sum(ADMS) as ADMS,"
                wkSQLCM += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByBkk1)) as PercentByBkk,"
                wkSQLCM += vbNewLine + " max(PercentByBkk1) as PercentByBkk1, "
                wkSQLCM += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByKeyCity1)) as PercentByKeyCity,"
                wkSQLCM += vbNewLine + " max(PercentByKeyCity1) as PercentByKeyCity1, "
                wkSQLCM += vbNewLine + " sum(NoOfMovie) as NoOfMovie"
                wkSQLCM += vbNewLine + " from ("
                wkSQLCM += vbNewLine + " SELECT DISTINCT (isnull(tblCircuit_11.circuit_id,'') + isnull(tblCircuit_21.circuit_id,'')) as circuit_id, "
                wkSQLCM += vbNewLine + " (isnull(tblCircuit_11.circuit_name,'') + isnull(tblCircuit_21.circuit_name,'')) as circuit_name, "
                wkSQLCM += vbNewLine + " tblStudio_11.studio_name, "
                wkSQLCM += vbNewLine + " tblStudio_11.studio_id, "
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_amount,0)))"
                wkSQLCM += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_amountsum,0))) AS BoxOffice,"
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_adms,0))) "
                wkSQLCM += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_admssum,0))) AS ADMS,"
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1"
                wkSQLCM += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQLCM += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and  (convert(varchar(19), tblMovie_1.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_1.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND ((tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " or (tblCompRevenue_1.theater_id in ('6', '52', '58')))"
                wkSQLCM += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByBkk1,"
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_2.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_2.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_2"
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_2.studio_id = tblStudio_2.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_2 ON tblMovie_2.movie_id = tblRevenue_2.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_2 ON tblMovie_2.movie_id = tblCompRevenue_2.movies_id"
                wkSQLCM += vbNewLine + " where (tblMovie_2.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and  (convert(varchar(19), tblMovie_2.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_2.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " )PercentByKeyCity1,"
                wkSQLCM += vbNewLine + " COUNT(distinct tblMovie_11.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_11"
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_11 ON tblMovie_11.studio_id = tblStudio_11.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_11 ON tblMovie_11.movie_id = tblRevenue_11.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_11 ON tblMovie_11.movie_id = tblCompRevenue_11.movies_id"
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_11 ON tblRevenue_11.theater_id = tblTheater_11.theater_id"
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_21 ON tblCompRevenue_11.theater_id = tblTheater_21.theater_id"
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_11 ON tblTheater_11.circuit_id = tblCircuit_11.circuit_id"
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_21 ON tblTheater_21.circuit_id = tblCircuit_21.circuit_id"
                wkSQLCM += vbNewLine + " where (tblMovie_11.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and (convert(varchar(19), tblMovie_11.movie_strdate,111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblMovie_11.movie_strdate,111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND ((tblRevenue_11.theater_id in ('6', '52', '58')) or (tblCompRevenue_11.theater_id in ('6', '52', '58')))"
                wkSQLCM += vbNewLine + " AND (tblStudio_11.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " GROUP BY tblCircuit_11.circuit_name,tblCircuit_21.circuit_name, "
                wkSQLCM += vbNewLine + " tblCircuit_11.circuit_id, tblCircuit_21.circuit_id,"
                wkSQLCM += vbNewLine + " tblStudio_11.studio_name, tblStudio_11.studio_id"
                wkSQLCM += vbNewLine + " ) aa"
                wkSQLCM += vbNewLine + " group by circuit_id, circuit_name, studio_name, studio_id,"
                wkSQLCM += vbNewLine + " PercentByBkk1, PercentByKeyCity1"

            Else
                wkSQL = " SELECT DISTINCT max(circuit_id) as circuit_id, max(circuit_name) as circuit_name, "
                wkSQL += vbNewLine + " max(studio_name) as studio_name, max(studio_id) as studio_id,"
                wkSQL += vbNewLine + " sum(BoxOffice) as BoxOffice, sum(ADMS) as ADMS,"
                wkSQL += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByBkk1)) as PercentByBkk,"
                wkSQL += vbNewLine + " max(PercentByBkk1) as PercentByBkk1, "
                wkSQL += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByKeyCity1)) as PercentByKeyCity,"
                wkSQL += vbNewLine + " max(PercentByKeyCity1) as PercentByKeyCity1, "
                wkSQL += vbNewLine + " sum(NoOfMovie) as NoOfMovie"
                wkSQL += vbNewLine + " from ("
                wkSQL += vbNewLine + " SELECT DISTINCT (isnull(tblCircuit_11.circuit_id,'') + isnull(tblCircuit_21.circuit_id,'')) as circuit_id, "
                wkSQL += vbNewLine + " (isnull(tblCircuit_11.circuit_name,'') + isnull(tblCircuit_21.circuit_name,'')) as circuit_name, "
                wkSQL += vbNewLine + " tblStudio_11.studio_name, "
                wkSQL += vbNewLine + " tblStudio_11.studio_id, "
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_amount,0)))"
                wkSQL += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_amountsum,0))) AS BoxOffice,"
                wkSQL += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_adms,0))) "
                wkSQL += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_admssum,0))) AS ADMS,"
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_1"
                wkSQL += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (((convert(varchar(19), tblRevenue_1.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblRevenue_1.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQL += vbNewLine + " OR"
                wkSQL += vbNewLine + " ((convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQL += vbNewLine + " AND ((tblRevenue_1.theater_id not in ('6', '52', '58'))"
                wkSQL += vbNewLine + " or (tblCompRevenue_1.theater_id not in ('6', '52', '58')))"
                wkSQL += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " ) AS PercentByBkk1,"
                wkSQL += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_2.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_2.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_2"
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_2.studio_id = tblStudio_2.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_2 ON tblMovie_2.movie_id = tblRevenue_2.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_2 ON tblMovie_2.movie_id = tblCompRevenue_2.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_2.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (((convert(varchar(19), tblRevenue_2.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblRevenue_2.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQL += vbNewLine + " OR"
                wkSQL += vbNewLine + " ((convert(varchar(19), tblCompRevenue_2.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_2.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQL += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " )PercentByKeyCity1,"
                wkSQL += vbNewLine + " COUNT(distinct tblMovie_11.movie_id) AS NoOfMovie"
                wkSQL += vbNewLine + " FROM tblMovie AS tblMovie_11"
                wkSQL += vbNewLine + " left join tblStudio AS tblStudio_11 ON tblMovie_11.studio_id = tblStudio_11.studio_id"
                wkSQL += vbNewLine + " left join tblRevenue AS tblRevenue_11 ON tblMovie_11.movie_id = tblRevenue_11.movies_id"
                wkSQL += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_11 ON tblMovie_11.movie_id = tblCompRevenue_11.movies_id"
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_11 ON tblRevenue_11.theater_id = tblTheater_11.theater_id"
                wkSQL += vbNewLine + " left join tblTheater AS tblTheater_21 ON tblCompRevenue_11.theater_id = tblTheater_21.theater_id"
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_11 ON tblTheater_11.circuit_id = tblCircuit_11.circuit_id"
                wkSQL += vbNewLine + " left join tblCircuit AS tblCircuit_21 ON tblTheater_21.circuit_id = tblCircuit_21.circuit_id"
                wkSQL += vbNewLine + " where (tblMovie_11.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (((convert(varchar(19), tblRevenue_11.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblRevenue_11.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQL += vbNewLine + " OR"
                wkSQL += vbNewLine + " ((convert(varchar(19), tblCompRevenue_11.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQL += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_11.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQL += vbNewLine + " AND ((tblRevenue_11.theater_id not in ('6', '52', '58')) or (tblCompRevenue_11.theater_id not in ('6', '52', '58')))"
                wkSQL += vbNewLine + " AND (tblStudio_11.studio_id = " + wkStudioId + ")"
                wkSQL += vbNewLine + " GROUP BY tblCircuit_11.circuit_name,tblCircuit_21.circuit_name, "
                wkSQL += vbNewLine + " tblCircuit_11.circuit_id, tblCircuit_21.circuit_id,"
                wkSQL += vbNewLine + " tblStudio_11.studio_name, tblStudio_11.studio_id"
                wkSQL += vbNewLine + " ) aa"
                wkSQL += vbNewLine + " group by circuit_id, circuit_name, studio_name, studio_id,"
                wkSQL += vbNewLine + " PercentByBkk1, PercentByKeyCity1"

                'xxxxxxxxxxxxxxxxxxxxxxx
                wkSQLCM = " SELECT DISTINCT max(circuit_id) as circuit_id, max(circuit_name) as circuit_name, "
                wkSQLCM += vbNewLine + " max(studio_name) as studio_name, max(studio_id) as studio_id,"
                wkSQLCM += vbNewLine + " sum(BoxOffice) as BoxOffice, sum(ADMS) as ADMS,"
                wkSQLCM += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByBkk1)) as PercentByBkk,"
                wkSQLCM += vbNewLine + " max(PercentByBkk1) as PercentByBkk1, "
                wkSQLCM += vbNewLine + " ((sum(BoxOffice) * 100 ) / max(PercentByKeyCity1)) as PercentByKeyCity,"
                wkSQLCM += vbNewLine + " max(PercentByKeyCity1) as PercentByKeyCity1, "
                wkSQLCM += vbNewLine + " sum(NoOfMovie) as NoOfMovie"
                wkSQLCM += vbNewLine + " from ("
                wkSQLCM += vbNewLine + " SELECT DISTINCT (isnull(tblCircuit_11.circuit_id,'') + isnull(tblCircuit_21.circuit_id,'')) as circuit_id, "
                wkSQLCM += vbNewLine + " (isnull(tblCircuit_11.circuit_name,'') + isnull(tblCircuit_21.circuit_name,'')) as circuit_name, "
                wkSQLCM += vbNewLine + " tblStudio_11.studio_name, "
                wkSQLCM += vbNewLine + " tblStudio_11.studio_id, "
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_amount,0)))"
                wkSQLCM += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_amountsum,0))) AS BoxOffice,"
                wkSQLCM += vbNewLine + " SUM(convert(decimal,isnull(tblRevenue_11.revenue_adms,0))) "
                wkSQLCM += vbNewLine + " + SUM(convert(decimal,isnull(tblCompRevenue_11.comprevenue_admssum,0))) AS ADMS,"
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_1"
                wkSQLCM += vbNewLine + " left join tblStudio ON tblMovie_1.studio_id = tblStudio.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_1 ON tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQLCM += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and (((convert(varchar(19), tblRevenue_1.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblRevenue_1.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQLCM += vbNewLine + " OR"
                wkSQLCM += vbNewLine + " ((convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQLCM += vbNewLine + " AND ((tblRevenue_1.theater_id in ('6', '52', '58'))"
                wkSQLCM += vbNewLine + " or (tblCompRevenue_1.theater_id in ('6', '52', '58')))"
                wkSQLCM += vbNewLine + " AND (tblStudio.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " ) AS PercentByBkk1,"
                wkSQLCM += vbNewLine + " (SELECT SUM(convert(decimal,isnull(tblRevenue_2.revenue_amount,0))) + SUM(convert(decimal,isnull(tblCompRevenue_2.comprevenue_amountsum,0))) AS totalBoxOffice"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_2"
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_2 ON tblMovie_2.studio_id = tblStudio_2.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_2 ON tblMovie_2.movie_id = tblRevenue_2.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_2 ON tblMovie_2.movie_id = tblCompRevenue_2.movies_id"
                wkSQLCM += vbNewLine + " where (tblMovie_2.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and  (((convert(varchar(19), tblRevenue_2.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblRevenue_2.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQLCM += vbNewLine + " OR"
                wkSQLCM += vbNewLine + " ((convert(varchar(19), tblCompRevenue_2.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_2.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQLCM += vbNewLine + " AND (tblStudio_2.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " )PercentByKeyCity1,"
                wkSQLCM += vbNewLine + " COUNT(distinct tblMovie_11.movie_id) AS NoOfMovie"
                wkSQLCM += vbNewLine + " FROM tblMovie AS tblMovie_11"
                wkSQLCM += vbNewLine + " left join tblStudio AS tblStudio_11 ON tblMovie_11.studio_id = tblStudio_11.studio_id"
                wkSQLCM += vbNewLine + " left join tblRevenue AS tblRevenue_11 ON tblMovie_11.movie_id = tblRevenue_11.movies_id"
                wkSQLCM += vbNewLine + " left join tblCompRevenue AS tblCompRevenue_11 ON tblMovie_11.movie_id = tblCompRevenue_11.movies_id"
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_11 ON tblRevenue_11.theater_id = tblTheater_11.theater_id"
                wkSQLCM += vbNewLine + " left join tblTheater AS tblTheater_21 ON tblCompRevenue_11.theater_id = tblTheater_21.theater_id"
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_11 ON tblTheater_11.circuit_id = tblCircuit_11.circuit_id"
                wkSQLCM += vbNewLine + " left join tblCircuit AS tblCircuit_21 ON tblTheater_21.circuit_id = tblCircuit_21.circuit_id"
                wkSQLCM += vbNewLine + " where (tblMovie_11.show_in_report_flag = 'Y')"
                wkSQLCM += vbNewLine + " and (((convert(varchar(19), tblRevenue_11.revenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblRevenue_11.revenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "'))"
                wkSQLCM += vbNewLine + " OR"
                wkSQLCM += vbNewLine + " ((convert(varchar(19), tblCompRevenue_11.comprevenue_date, 111) >= '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "')"
                wkSQLCM += vbNewLine + " AND (convert(varchar(19), tblCompRevenue_11.comprevenue_date, 111) <= '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "')))"
                wkSQLCM += vbNewLine + " AND ((tblRevenue_11.theater_id in ('6', '52', '58')) or (tblCompRevenue_11.theater_id in ('6', '52', '58')))"
                wkSQLCM += vbNewLine + " AND (tblStudio_11.studio_id = " + wkStudioId + ")"
                wkSQLCM += vbNewLine + " GROUP BY tblCircuit_11.circuit_name,tblCircuit_21.circuit_name, "
                wkSQLCM += vbNewLine + " tblCircuit_11.circuit_id, tblCircuit_21.circuit_id,"
                wkSQLCM += vbNewLine + " tblStudio_11.studio_name, tblStudio_11.studio_id"
                wkSQLCM += vbNewLine + " ) aa"
                wkSQLCM += vbNewLine + " group by circuit_id, circuit_name, studio_name, studio_id,"
                wkSQLCM += vbNewLine + " PercentByBkk1, PercentByKeyCity1"

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
                    tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY STUDIO : " + dataReader("studio_name")
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
            tblFoot.Rows(0).Cells(4).Text = sumPerceent.ToString("#,##0.00") + " %"
            tblFoot.Rows(0).Cells(5).Text = sumATP.ToString("#,##0.00") + " %"

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
                    tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY STUDIO : " + dataReaderCM("studio_name")
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
            tblFootCM.Rows(0).Cells(3).Text = "" ' sumTitleCM.ToString("#,##0") + " "
            tblFootCM.Rows(0).Cells(4).Text = sumPerceentCM.ToString("#,##0.00") + " %"
            tblFootCM.Rows(0).Cells(5).Text = sumATPCM.ToString("#,##0.00") + " %"

            'TOTAL
            tblFootCM.Rows(1).Cells(0).Text = "TOTAL"
            tblFootCM.Rows(1).Cells(1).Text = (sumBOGross + sumBOGrossCM).ToString("#,##0") + " "
            tblFootCM.Rows(1).Cells(2).Text = (sumADMS + sumADMSCM).ToString("#,##0") + " "
            tblFootCM.Rows(1).Cells(3).Text = "" '(sumTitle + sumTitleCM).ToString("#,##0") + " "
            tblFootCM.Rows(1).Cells(4).Text = "100%" '(sumPerceent + sumPerceentCM).ToString("#,##0.00") + " %"
            tblFootCM.Rows(1).Cells(5).Text = (sumATP + sumATPCM).ToString("#,##0.00") + " %"
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
                End If
            End If
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
    End Sub


End Class