Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodNationMovie
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 11, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            Dim StartDate As String = Session("msRptStrDate").ToString
            Dim EndDate As String = Session("msRptEndDate").ToString
            Dim wkNational As String = Request.QueryString("national")
            Dim wkSQL As String

            tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY NATIONALITY : " + wkNational.ToUpper()
            tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

            If (Convert.ToString(Session("msRptDateType")) = "1") Then

                wkSQL = " select  movie_strdate, tblMovie_1.movie_national, tblMovie_1.movie_id, "
                wkSQL += vbNewLine + " tblMovie_1.movie_nameen  AS movie_name," '+ '/' + tblMovie_1.movie_nameth
                wkSQL += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) "
                wkSQL += vbNewLine + " + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross,  "
                wkSQL += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + "
                wkSQL += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS,  "
                wkSQL += vbNewLine + "  case when (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) > 0 then"
                wkSQL += vbNewLine + "  			((sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/  "
                wkSQL += vbNewLine + "   (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))))"
                wkSQL += vbNewLine + "  		else"
                wkSQL += vbNewLine + "  				0"
                wkSQL += vbNewLine + "  end ATP,"
                wkSQL += vbNewLine + " (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQL += vbNewLine + " (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + "
                wkSQL += vbNewLine + " sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross "
                wkSQL += vbNewLine + " from tblMovie  left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id  "
                wkSQL += vbNewLine + " left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id "
                wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (convert(varchar(19), tblMovie.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111) "
                wkSQL += vbNewLine + " and convert(varchar(19), tblMovie.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)) "
                wkSQL += vbNewLine + " and (tblMovie.movie_national = '" + wkNational + "' )) as PercentNation  "
                wkSQL += vbNewLine + " , (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQL += vbNewLine + " (select (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + " sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross"
                wkSQL += vbNewLine + " from tblMovie tblMovie_1 "
                wkSQL += vbNewLine + " left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + " left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + " and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))) as PercentIndustry "
                wkSQL += vbNewLine + " from tblMovie tblMovie_1  "
                wkSQL += vbNewLine + " left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id  "
                wkSQL += vbNewLine + " left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and  (convert(varchar(19), tblMovie_1.movie_strdate, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111) "
                wkSQL += vbNewLine + " and convert(varchar(19), tblMovie_1.movie_strdate, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111)) "
                wkSQL += vbNewLine + " and (tblMovie_1.movie_national = '" + wkNational + "')"
                wkSQL += vbNewLine + " and  tblMovie_1.movie_status <> 4"
                wkSQL += vbNewLine + " group by tblMovie_1.movie_id, tblMovie_1.movie_nameen, tblMovie_1.movie_nameth, tblMovie_1.movie_national, movie_strdate "
                wkSQL += vbNewLine + " order by BOGross DESC,movie_strdate, tblMovie_1.movie_id"
            Else
                wkSQL = "  select  movie_strdate, tblMovie_1.movie_national, tblMovie_1.movie_id, "
                wkSQL += vbNewLine + "  tblMovie_1.movie_nameen  AS movie_name," '+ '/' + tblMovie_1.movie_nameth
                wkSQL += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) "
                wkSQL += vbNewLine + "  + sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross,  "
                wkSQL += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) + "
                wkSQL += vbNewLine + "  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) as ADMS,  "
                wkSQL += vbNewLine + "  case when (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))) > 0 then"
                wkSQL += vbNewLine + "  			((sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0))))/  "
                wkSQL += vbNewLine + "   (sum(convert(decimal,isnull(tblRevenue_1.revenue_adms,0))) +  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_admssum,0)))))"
                wkSQL += vbNewLine + "  		else"
                wkSQL += vbNewLine + "  				0"
                wkSQL += vbNewLine + "  end ATP,"
                wkSQL += vbNewLine + "  (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + "  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQL += vbNewLine + "  (select sum(convert(decimal, isnull(tblRevenue.revenue_amount, 0))) + "
                wkSQL += vbNewLine + "  sum(convert(decimal, isnull(tblCompRevenue.comprevenue_amountsum, 0))) as totalBoGross "
                wkSQL += vbNewLine + "  from tblMovie  left join tblRevenue on tblMovie.movie_id = tblRevenue.movies_id  "
                wkSQL += vbNewLine + "  left join tblCompRevenue on tblMovie.movie_id = tblComprevenue.movies_id "
                wkSQL += vbNewLine + " where (tblMovie.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (convert(varchar(19), tblRevenue.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " or (convert(varchar(19), tblCompRevenue.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + "  and (tblMovie.movie_national = '" + wkNational + "' )) as PercentNation  "
                wkSQL += vbNewLine + "  , (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + "  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) * 100 /   "
                wkSQL += vbNewLine + "  (select (sum(convert(decimal,isnull(tblRevenue_1.revenue_amount,0))) + "
                wkSQL += vbNewLine + "  sum(convert(decimal,isnull(tblCompRevenue_1.comprevenue_amountsum,0)))) as BOGross"
                wkSQL += vbNewLine + "  from tblMovie tblMovie_1 "
                wkSQL += vbNewLine + "  left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id "
                wkSQL += vbNewLine + "  left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id"
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " ) as PercentIndustry "
                wkSQL += vbNewLine + "  from tblMovie tblMovie_1  "
                wkSQL += vbNewLine + "  left join tblRevenue tblRevenue_1 on tblMovie_1.movie_id = tblRevenue_1.movies_id  "
                wkSQL += vbNewLine + "  left join tblCompRevenue tblCompRevenue_1 on tblMovie_1.movie_id = tblCompRevenue_1.movies_id "
                wkSQL += vbNewLine + " where (tblMovie_1.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " and (convert(varchar(19), tblRevenue_1.revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblRevenue_1.revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " or (convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), tblCompRevenue_1.comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + "  and (tblMovie_1.movie_national = '" + wkNational + "')"
                wkSQL += vbNewLine + " and  tblMovie_1.movie_status <> 4"

                wkSQL += vbNewLine + "  group by tblMovie_1.movie_id, tblMovie_1.movie_nameen, tblMovie_1.movie_nameth, tblMovie_1.movie_national, movie_strdate "
                wkSQL += vbNewLine + "  order by BOGross DESC,movie_strdate, tblMovie_1.movie_id"
            End If


            sqlMsg.SelectCommand = wkSQL
            GridView1.DataSourceID = "sqlMsg"
            GridView1.DataBind()

            Dim sumBOGross, sumADMS, sumNation As Double
            Dim sumIndustry, sumATP As Decimal
            sumBOGross = 0
            sumADMS = 0
            sumNation = 0
            sumIndustry = 0
            sumATP = 0
            Dim cDB As New cDatabase
            Dim dataReader As IDataReader = cDB.GetDataAll(wkSQL)
            While (dataReader.Read())
                sumBOGross = sumBOGross + Format(dataReader("BOGross"), "#,##0")
                sumADMS = sumADMS + Format(dataReader("ADMS"), "#,##0")
                sumNation = sumNation + Format(dataReader("PercentNation"), "#,##0.00")
                sumIndustry = sumIndustry + Format(dataReader("PercentIndustry"), "#,##0.00")
                'sumATP = sumATP + Format(dataReader("ATP"), "#,##0.00")
                sumATP = sumBOGross / sumADMS
            End While
            dataReader.Close()
            tblFoot.Rows(0).Cells(0).Text = "TOTAL "
            tblFoot.Rows(0).Cells(1).Text = sumBOGross.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(2).Text = sumADMS.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(3).Text = sumNation.ToString("#,##0") + " %"
            tblFoot.Rows(0).Cells(4).Text = sumIndustry.ToString("#,##0.00") + " %"
            tblFoot.Rows(0).Cells(5).Text = sumATP.ToString("#,##0.00") + " "
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
                Response.AddHeader("content-disposition", "attachment;filename=Market_Share_By_Nationality.xls")
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