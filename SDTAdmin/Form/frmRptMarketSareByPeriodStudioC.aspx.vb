Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodStudioC
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        Try
            ShowTable1()
            ShowTable2()
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
        

    End Sub

    Private Sub ShowTable1()
        Dim StartDate As String = Session("msRptStrDate").ToString
        Dim EndDate As String = Session("msRptEndDate").ToString
        'Dim wkType As String = Session("msRptType").ToString
        Dim strRptSubGroup As String = Session("msRptSubGroup").ToString '1=Theatre, 2=Circuit

        Dim wkSQL As String

        'If wkType = "1" Then 'CTBV
        tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY STUDIO"
        tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

        If (Convert.ToString(Session("msRptDateType")) = "1") Then

            wkSQL = vbNewLine + " select ms.studio_id, ms.studio_name, ms.BOGross, ms.ADMS, ms.TitleMovie,"
            wkSQL += vbNewLine + " case when isnull(ms.ADMS, 0) > 0 then"
            wkSQL += vbNewLine + " 		 isnull(ms.BOGross, 0) / ms.ADMS"
            wkSQL += vbNewLine + " 	 else"
            wkSQL += vbNewLine + " 		0"
            wkSQL += vbNewLine + " end ATP, "
            wkSQL += vbNewLine + " case when isnull(ms.totalBoGross, 0) > 0 then"
            wkSQL += vbNewLine + " 		isnull(ms.BOGross, 0) * 100/ms.totalBoGross"
            wkSQL += vbNewLine + " 	 else"
            wkSQL += vbNewLine + " 		0"
            wkSQL += vbNewLine + " end PercentCTBV"
            wkSQL += vbNewLine + " from"
            wkSQL += vbNewLine + " ("
            wkSQL += vbNewLine + " 	select tblStudio_1.studio_id, tblStudio_1.studio_name, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
            wkSQL += vbNewLine + " 	count(distinct tblMovie_1.movie_id) AS TitleMovie,"
            wkSQL += vbNewLine + " 	(select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblMovie "
            wkSQL += vbNewLine + " 	left join tblStudio on tblMovie.studio_id = tblStudio.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
            wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + " 	and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + " 	) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblStudio tblStudio_1"
            wkSQL += vbNewLine + " 	left join tblMovie tblMovie_1 on tblStudio_1.studio_id = tblMovie_1.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
            wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  ((convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + " 	and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)))"
            wkSQL += vbNewLine + "  and tblStudio_1.studio_id in (1,2,3,4,5,6,7)"
            wkSQL += vbNewLine + " 	group by tblStudio_1.studio_id, tblStudio_1.studio_name"
            wkSQL += vbNewLine + " ) ms"
            wkSQL += vbNewLine + " order by ms.studio_name"
        Else

            wkSQL = " select ms.studio_id, ms.studio_name, ms.BOGross, ms.ADMS, ms.TitleMovie,"
            wkSQL += vbNewLine + " case when isnull(ms.ADMS, 0) > 0 then"
            wkSQL += vbNewLine + " 	 isnull(ms.BOGross, 0) / ms.ADMS"
            wkSQL += vbNewLine + "  else"
            wkSQL += vbNewLine + " 	0"
            wkSQL += vbNewLine + " end ATP, "
            wkSQL += vbNewLine + " case when isnull(ms.totalBoGross, 0) > 0 then"
            wkSQL += vbNewLine + " 	isnull(ms.BOGross, 0) * 100/ms.totalBoGross"
            wkSQL += vbNewLine + "  else"
            wkSQL += vbNewLine + " 	0"
            wkSQL += vbNewLine + " end PercentCTBV"
            wkSQL += vbNewLine + " from"
            wkSQL += vbNewLine + " ("
            wkSQL += vbNewLine + " 	select tblStudio_1.studio_id, tblStudio_1.studio_name, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
            wkSQL += vbNewLine + " 	count(distinct tblMovie_1.movie_id) AS TitleMovie,"
            wkSQL += vbNewLine + " 	(select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblMovie "
            wkSQL += vbNewLine + " 	left join tblStudio on tblMovie.studio_id = tblStudio.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
            wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + "  or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + " 	) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblStudio tblStudio_1"
            wkSQL += vbNewLine + " 	left join tblMovie tblMovie_1 on tblStudio_1.studio_id = tblMovie_1.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
            wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  ((convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + "  or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)))"
            wkSQL += vbNewLine + " 	and tblStudio_1.studio_id in (1,2,3,4,5,6,7)"
            wkSQL += vbNewLine + " 	group by tblStudio_1.studio_id, tblStudio_1.studio_name"
            wkSQL += vbNewLine + " ) ms"
            wkSQL += vbNewLine + " order by ms.studio_name"
        End If

        sqlDataSource1.SelectCommand = wkSQL
        GridView1.DataSourceID = "sqlDataSource1"
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
        While (dataReader.Read())
            sumBOGross = sumBOGross + Format(dataReader("BOGross"), "#,##0")
            sumADMS = sumADMS + Format(dataReader("ADMS"), "#,##0")
            sumTitle = sumTitle + Format(dataReader("TitleMovie"), "#,##0")
            sumPerceent = sumPerceent + Format(dataReader("PercentCTBV"), "#,##0.00")
            'sumATP = sumATP + Format(dataReader("ATP"), "#,##0.00")
            If (sumADMS <> 0) Then
                sumATP = sumBOGross / sumADMS
            End If
        End While
        dataReader.Close()
        tblFoot.Rows(0).Cells(0).Text = "TOTAL "
        tblFoot.Rows(0).Cells(1).Text = sumBOGross.ToString("#,##0") + " "
        tblFoot.Rows(0).Cells(2).Text = sumADMS.ToString("#,##0") + " "
        tblFoot.Rows(0).Cells(3).Text = sumTitle.ToString("#,##0") + " "
        tblFoot.Rows(0).Cells(4).Text = sumPerceent.ToString("#,##0.00") + " %"
        tblFoot.Rows(0).Cells(5).Text = sumATP.ToString("#,##0.00") + " "
        tblFoot.Visible = GridView1.Rows.Count > 0
    End Sub

    Private Sub ShowTable2()
        Dim StartDate As String = Session("msRptStrDate").ToString
        Dim EndDate As String = Session("msRptEndDate").ToString
        'Dim wkType As String = Session("msRptType").ToString
        Dim strRptSubGroup As String = Session("msRptSubGroup").ToString '1=Theatre, 2=Circuit

        Dim wkSQL As String

        'If wkType = "1" Then 'CTBV
        tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY STUDIO"
        tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

        If (Convert.ToString(Session("msRptDateType")) = "1") Then
            wkSQL = vbNewLine + " select ms.studio_id, ms.studio_name, ms.BOGross, ms.ADMS, ms.TitleMovie,"
            wkSQL += vbNewLine + " case when isnull(ms.ADMS, 0) > 0 then"
            wkSQL += vbNewLine + " 		 isnull(ms.BOGross, 0) / ms.ADMS"
            wkSQL += vbNewLine + " 	 else"
            wkSQL += vbNewLine + " 		0"
            wkSQL += vbNewLine + " end ATP, "
            wkSQL += vbNewLine + " case when isnull(ms.totalBoGross, 0) > 0 then"
            wkSQL += vbNewLine + " 		isnull(ms.BOGross, 0) * 100/ms.totalBoGross"
            wkSQL += vbNewLine + " 	 else"
            wkSQL += vbNewLine + " 		0"
            wkSQL += vbNewLine + " end PercentCTBV"
            wkSQL += vbNewLine + " from"
            wkSQL += vbNewLine + " ("
            wkSQL += vbNewLine + " 	select tblStudio_1.studio_id, tblStudio_1.studio_name, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
            wkSQL += vbNewLine + " 	count(distinct tblMovie_1.movie_id) AS TitleMovie,"
            wkSQL += vbNewLine + " 	(select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblMovie "
            wkSQL += vbNewLine + " 	left join tblStudio on tblMovie.studio_id = tblStudio.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
            wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + " 	and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + " 	) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblStudio tblStudio_1"
            wkSQL += vbNewLine + " 	left join tblMovie tblMovie_1 on tblStudio_1.studio_id = tblMovie_1.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
            wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  ((convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + " 	and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)))"
            wkSQL += vbNewLine + "  and tblStudio_1.studio_id not in (1,2,3,4,5,6,7)"
            wkSQL += vbNewLine + " 	group by tblStudio_1.studio_id, tblStudio_1.studio_name"
            wkSQL += vbNewLine + " ) ms"
            wkSQL += vbNewLine + " order by ms.studio_name"
        Else

            wkSQL = " select ms.studio_id, ms.studio_name, ms.BOGross, ms.ADMS, ms.TitleMovie,"
            wkSQL += vbNewLine + " case when isnull(ms.ADMS, 0) > 0 then"
            wkSQL += vbNewLine + " 	 isnull(ms.BOGross, 0) / ms.ADMS"
            wkSQL += vbNewLine + "  else"
            wkSQL += vbNewLine + " 	0"
            wkSQL += vbNewLine + " end ATP, "
            wkSQL += vbNewLine + " case when isnull(ms.totalBoGross, 0) > 0 then"
            wkSQL += vbNewLine + " 	isnull(ms.BOGross, 0) * 100/ms.totalBoGross"
            wkSQL += vbNewLine + "  else"
            wkSQL += vbNewLine + " 	0"
            wkSQL += vbNewLine + " end PercentCTBV"
            wkSQL += vbNewLine + " from"
            wkSQL += vbNewLine + " ("
            wkSQL += vbNewLine + " 	select tblStudio_1.studio_id, tblStudio_1.studio_name, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross, "
            wkSQL += vbNewLine + " 	(sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS, "
            wkSQL += vbNewLine + " 	count(distinct tblMovie_1.movie_id) AS TitleMovie,"
            wkSQL += vbNewLine + " 	(select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblMovie "
            wkSQL += vbNewLine + " 	left join tblStudio on tblMovie.studio_id = tblStudio.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id"
            wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + "  or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + " 	) as totalBoGross"
            wkSQL += vbNewLine + " 	from tblStudio tblStudio_1"
            wkSQL += vbNewLine + " 	left join tblMovie tblMovie_1 on tblStudio_1.studio_id = tblMovie_1.studio_id "
            wkSQL += vbNewLine + " 	left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
            wkSQL += vbNewLine + " 	left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
            wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
            wkSQL += vbNewLine + " and  ((convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
            wkSQL += vbNewLine + "  or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
            wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)))"
            wkSQL += vbNewLine + " 	and tblStudio_1.studio_id not in (1,2,3,4,5,6,7)"
            wkSQL += vbNewLine + " 	group by tblStudio_1.studio_id, tblStudio_1.studio_name"
            wkSQL += vbNewLine + " ) ms"
            wkSQL += vbNewLine + " order by ms.studio_name"
        End If


        SqlDataSource2.SelectCommand = wkSQL
        GridView2.DataSourceID = "SqlDataSource2"
        GridView2.DataBind()

        Dim sumBOGross, sumADMS, sumTitle As Double
        Dim sumPerceent, sumATP As Decimal
        sumBOGross = 0
        sumADMS = 0
        sumTitle = 0
        sumPerceent = 0
        sumATP = 0
        Dim cDB As New cDatabase
        Dim dataReader As IDataReader = cDB.GetDataAll(wkSQL)
        While (dataReader.Read())
            sumBOGross = sumBOGross + Format(dataReader("BOGross"), "#,##0")
            sumADMS = sumADMS + Format(dataReader("ADMS"), "#,##0")
            sumTitle = sumTitle + Format(dataReader("TitleMovie"), "#,##0")
            sumPerceent = sumPerceent + Format(dataReader("PercentCTBV"), "#,##0.00")
            'sumATP = sumATP + Format(dataReader("ATP"), "#,##0.00")
            If (sumADMS <> 0) Then
                sumATP = sumBOGross / sumADMS
            End If
        End While
        dataReader.Close()
        tblFoot0.Rows(0).Cells(0).Text = "TOTAL "
        tblFoot0.Rows(0).Cells(1).Text = sumBOGross.ToString("#,##0") + " "
        tblFoot0.Rows(0).Cells(2).Text = sumADMS.ToString("#,##0") + " "
        tblFoot0.Rows(0).Cells(3).Text = sumTitle.ToString("#,##0") + " "
        tblFoot0.Rows(0).Cells(4).Text = sumPerceent.ToString("#,##0.00") + " %"
        tblFoot0.Rows(0).Cells(5).Text = sumATP.ToString("#,##0.00") + " "
        tblFoot0.Visible = GridView2.Rows.Count > 0
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptMarketSareByPeriodParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            If GridView1.Rows.Count.ToString + 1 < 65536 Then
                GridView1.AllowPaging = False
                GridView1.AllowSorting = False
                GridView1.Width = 800
                GridView1.DataBind()
                Dim tw As New IO.StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()
                frm.Attributes("runat") = "server"
                frm.Controls.Add(panel1)
                frm.Controls.Add(tbl)
                frm.Controls.Add(GridView1)
                frm.Controls.Add(tblFoot)
                Response.AddHeader("content-disposition", "attachment;filename=Market_Share_By_Studio.xls")
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
            End If
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
       
    End Sub

End Class