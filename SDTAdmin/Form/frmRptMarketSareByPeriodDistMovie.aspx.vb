Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodDistMovie
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 11, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            Dim StartDate As String = Session("msRptStrDate").ToString
            Dim EndDate As String = Session("msRptEndDate").ToString
            Dim wkDistId As String = Request.QueryString("distid")
            Dim wkSQL As String

            tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY DISTRIBUTOR : " + wkDistId.ToUpper()
            tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

            If (Convert.ToString(Session("msRptDateType")) = "1") Then

                wkSQL = "  SELECT vSumRevRpt.movie_strdate, vSumRevRpt.movie_id, vSumRevRpt.movie_code,"
                wkSQL += vbNewLine + "  vSumRevRpt.movie_nameen as movie_nameen, vSumRevRpt.distributor_name,"
                wkSQL += vbNewLine + "  vSumRevRpt.distributor_id, "
                wkSQL += vbNewLine + "  isnull(vSumRevRpt.SumRev,0) as SumRev, isnull(vSumRevRpt.countWeek,0) as countWeek, "
                wkSQL += vbNewLine + "  isnull(vRevToday1.cntSession,0) as cntSession, isnull(vRevToday1.cntScreen,0) as cntScreen, "
                wkSQL += vbNewLine + "  isnull(vRevToday1.rev_amount,0) as rev_amount, isnull(vRevToday1.rev_adms,0) as rev_adms, "
                wkSQL += vbNewLine + "  vSumRevRpt.movietype_id, vSumRevRpt.SumScreen, vSumRevRpt.SumSession"
                wkSQL += vbNewLine + "  FROM vSumRevRpt "
                wkSQL += vbNewLine + "  Left JOIN"
                wkSQL += vbNewLine + "  ( "
                wkSQL += vbNewLine + "  select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms, sum(rev_amount) as rev_amount, "
                wkSQL += vbNewLine + "  sum(cntSession) as cntSession, max(cntScreen) as cntScreen "
                wkSQL += vbNewLine + "  from "
                wkSQL += vbNewLine + "  ( "
                wkSQL += vbNewLine + "  SELECT vRevToday.DateStatus, vRevToday.movie_id, sum(vRevToday.rev_adms) as rev_adms,  sum(vRevToday.rev_amount) as rev_amount, "
                wkSQL += vbNewLine + "  sum(vRevToday.cntSession) as cntSession, max(vRevToday.cntScreen) as cntScreen , vRevToday.distributor_id"
                wkSQL += vbNewLine + "  FROM vRevToday "
                wkSQL += vbNewLine + "  left join tblMovie m on vRevToday.movie_id = m.movie_id"
                wkSQL += vbNewLine + "  where (m.show_in_report_flag = 'Y') and ((convert(varchar(19), m.movie_strdate , 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "',111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), m.movie_strdate , 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + "  and (vRevToday.distributor_id = " + wkDistId + "))"
                wkSQL += vbNewLine + "  group by vRevToday.movie_id, vRevToday.DateStatus, vRevToday.distributor_id"
                wkSQL += vbNewLine + "  ) as tblSum"
                wkSQL += vbNewLine + "  group by  movie_id"
                wkSQL += vbNewLine + "  ) AS vRevToday1 ON  vSumRevRpt.movie_id = vRevToday1.movie_id "
                wkSQL += vbNewLine + "  WHERE (vSumRevRpt.distributor_id = " + wkDistId + ")"
                wkSQL += vbNewLine + "  and (vSumRevRpt.appear_status_id = 1)"
                wkSQL += vbNewLine + " and (vSumRevRpt.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + "  and (convert(varchar(19), vSumRevRpt.movie_strdate , 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "',111)"
                wkSQL += vbNewLine + "  and convert(varchar(19), vSumRevRpt.movie_strdate , 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"

                wkSQL += vbNewLine + "  ORDER BY rev_amount DESC,vSumRevRpt.movie_strdate DESC, vSumRevRpt.distributor_id"
            Else
                wkSQL = " SELECT vSumRevRpt.movie_strdate, vSumRevRpt.movie_id, vSumRevRpt.movie_code,"
                wkSQL += vbNewLine + " vSumRevRpt.movie_nameen as movie_nameen, vSumRevRpt.distributor_name,"
                wkSQL += vbNewLine + " vSumRevRpt.distributor_id, "
                wkSQL += vbNewLine + " isnull(vSumRevRpt.SumRev,0) as SumRev, isnull(vSumRevRpt.countWeek,0) as countWeek, "
                wkSQL += vbNewLine + " isnull(vRevToday1.cntSession,0) as cntSession, isnull(vRevToday1.cntScreen,0) as cntScreen, "
                wkSQL += vbNewLine + " isnull(vRevToday1.rev_amount,0) as rev_amount, isnull(vRevToday1.rev_adms,0) as rev_adms, "
                wkSQL += vbNewLine + " vSumRevRpt.movietype_id, vSumRevRpt.SumScreen, vSumRevRpt.SumSession"
                wkSQL += vbNewLine + " FROM vSumRevRpt "
                wkSQL += vbNewLine + " Left JOIN"
                wkSQL += vbNewLine + " ( "
                wkSQL += vbNewLine + " select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms, sum(rev_amount) as rev_amount, "
                wkSQL += vbNewLine + " sum(cntSession) as cntSession, max(cntScreen) as cntScreen "
                wkSQL += vbNewLine + " from "
                wkSQL += vbNewLine + " ( "
                wkSQL += vbNewLine + " SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
                wkSQL += vbNewLine + " sum(cntSession) as cntSession, max(cntScreen) as cntScreen ,distributor_id"
                wkSQL += vbNewLine + " FROM vRevToday "
                wkSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd") + "', 111)"
                wkSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Convert.ToDateTime(EndDate).ToString("yyyy/MM/dd") + "', 111))"
                wkSQL += vbNewLine + " and (distributor_id = " + wkDistId + "))"
                wkSQL += vbNewLine + " group by movie_id, DateStatus,distributor_id"
                wkSQL += vbNewLine + " ) as tblSum"
                wkSQL += vbNewLine + " group by  movie_id"
                wkSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevRpt.movie_id = vRevToday1.movie_id "
                wkSQL += vbNewLine + " WHERE (vSumRevRpt.distributor_id = " + wkDistId + ")"
                wkSQL += vbNewLine + " and (vSumRevRpt.appear_status_id = 1)"
                wkSQL += vbNewLine + " and (vSumRevRpt.show_in_report_flag = 'Y')"
                wkSQL += vbNewLine + " ORDER BY rev_amount DESC,vSumRevRpt.movie_strdate DESC, vSumRevRpt.distributor_id"
            End If



            sqlMsg.SelectCommand = wkSQL
            GridView1.DataSourceID = "sqlMsg"
            GridView1.DataBind()

            Dim sumScreen, sumWeek, sumGBO, sumADMS As Double
            'Dim sumIndustry, sumATP As Decimal
            sumScreen = 0
            sumWeek = 0
            sumGBO = 0
            sumADMS = 0
            Dim cDB As New cDatabase
            Dim dataReader As IDataReader = cDB.GetDataAll(wkSQL)
            While (dataReader.Read())
                tbl.Rows(0).Cells(0).Text = "INDUSTRY MARKET SHARE BY DISTRIBUTOR : " + dataReader("distributor_name").ToString().ToUpper()
                sumScreen = sumScreen + Format(dataReader("cntScreen"), "#,##0")
                sumWeek = sumWeek + Format(dataReader("countWeek"), "#,##0")
                sumGBO = sumGBO + Format(dataReader("rev_amount"), "#,##0.00")
                sumADMS = sumADMS + Format(dataReader("rev_adms"), "#,##0.00")
            End While
            dataReader.Close()

            tblFoot.Rows(0).Cells(0).Text = "TOTAL "
            tblFoot.Rows(0).Cells(1).Text = "" 'sumScreen.ToString("#,##0") + " "
            'tblFoot.Rows(0).Cells(1).Visible = False
            tblFoot.Rows(0).Cells(2).Text = "" 'sumWeek.ToString("#,##0") + " "
            'tblFoot.Rows(0).Cells(2).Visible = False
            tblFoot.Rows(0).Cells(3).Text = sumGBO.ToString("#,##0") + " "
            tblFoot.Rows(0).Cells(4).Text = sumADMS.ToString("#,##0") + " "

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