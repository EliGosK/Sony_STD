Imports Web.Data
Partial Public Class frmRptPerWeekendSunday
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        Try

        
            Dim cDB As New cDatabase
            Dim DatCount As Integer = Convert.ToInt16(Session("msRptNumDay")) - 1
            Dim dayFrom As DateTime = Convert.ToDateTime(Session("msRptStrDate")).AddDays(-DatCount)
            Dim dayTo As DateTime = Convert.ToDateTime(Session("msRptStrDate"))
            tbl.Rows(2).Cells(1).Text = "# OF DAYS IN WEEKEND : " + Session("msRptNumDay").ToString + " DAYS"
            tbl.Rows(3).Cells(0).Text = "PERIOD : " & Format(dayFrom, "dd-MMM-yyyy") & " TO " & Format(dayTo, "dd-MMM-yyyy")
            'Dim dayFrom As String = Convert.ToDateTime(Session("msRptStrDate")).AddDays(-DatCount).Day.ToString
            'Dim datTo As String = Convert.ToDateTime(Session("msRptStrDate")).Day.ToString
            'tbl.Rows(1).Cells(1).Text = "# OF DAYS IN WEEKEND : " + Session("msRptNumDay").ToString + " DAYS"
            'tbl.Rows(2).Cells(0).Text = "PERIOD : " & dayFrom & " - " & datTo & " " & Format(Session("msRptStrDate"), "dd MMM yyyy")
            'TOTAL_CUR_ADMS_QTY
            'Format(Session("msRptStrDate"), "yyyyMMdd")


            ''''Dim drMovie As IDataReader = cDB.getWeekendTradingMovies(Session("msRptStrDate"), Convert.ToInt32(Session("msRptNumDay")), "DATA")
            'exec(spWeekend_TradingGetMovies) '06/17/2012', 3, 'DATA'

            'Dim str1 As String = "exec(ctbv.spWeekend_TradingGetMovies) '" + Session("msRptStrDate").ToString() + "', " + Session("msRptNumDay").ToString() + ", 'DATA';"
            
            'Dim drMovie As DataTable = cDB.GetDataTable(strSQLMovieID)


            Dim rowCount As Integer = 0
            Dim wkWeekNo As String = ""

            '''' While (drMovie.Read())
            '''Dim intMovieID As Integer = Convert.ToInt32(drMovie("movie_id"))
            Dim dr As IDataReader = cDB.getWeekendTrading(Session("msRptStrDate"), Convert.ToInt32(Session("msRptNumDay")), "DATA") ', intMovieID
            While (dr.Read())
                Dim detailsRow As New TableRow()
                detailsRow.HorizontalAlign = HorizontalAlign.Center
                detailsRow.CssClass = "style1"
                rowCount = rowCount + 1

                wkWeekNo = dr("week_no").ToString
                If wkWeekNo = "1" Then
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(0).Text = rowCount

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
                    detailsRow.Cells(1).Text = cDB.CheckIsNullString(dr("movie_title"))
                    detailsRow.Cells(1).ForeColor = Color.Blue
                    detailsRow.Cells(1).Font.Bold = True

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = cDB.CheckIsNullString(dr("distributor_name"))

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(3).Text = cDB.CheckIsNullString(dr("week_no"))
                    detailsRow.Cells(3).ForeColor = Color.Blue
                    detailsRow.Cells(3).Font.Bold = True

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(4).Text = cDB.CheckIsNullInteger(dr("cur_screen_qty"))

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(5).Text = Format(cDB.CheckIsNullInteger(dr("cur_gross_amt")), "#,##0")
                    ' CUR_ADMS_QTY
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(6).Text = Format(cDB.CheckIsNullInteger(dr("CUR_ADMS_QTY")), "#,##0")

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(7).Text = "" 'dr("prev_screen_qty")

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(8).Text = "NEW" 'Format(dr("prev_gross_amt"), "#,##0")
                    detailsRow.Cells(8).ForeColor = Color.Blue
                    detailsRow.Cells(8).Font.Bold = True

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(9).Text = "" 'dr("change_percent_desc")


                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(10).Text = Format(cDB.CheckIsNullInteger(dr("cumu_gross_amt")), "#,##0")

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(11).HorizontalAlign = HorizontalAlign.Right
                    'detailsRow.Cells(11).Text = ""
                    detailsRow.Cells(11).Text = Format(cDB.CheckIsNullInteger(dr("EST_NATIONWIDE_AMT")), "#,##0") 'est_nationwide_amt

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(12).HorizontalAlign = HorizontalAlign.Right

                    If Not IsDBNull(dr("final_flat_sale_amt")) Then
                        If (Convert.ToString(dr("final_flat_sale_amt")) = "N/A" Or Convert.ToString(dr("final_flat_sale_amt")) = "") Then
                            detailsRow.Cells(12).Text = dr("final_flat_sale_amt")
                        Else
                            detailsRow.Cells(12).Text = Convert.ToDecimal(dr("final_flat_sale_amt")).ToString("#,##0")
                        End If
                    Else
                        detailsRow.Cells(12).Text = "0"
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(13).HorizontalAlign = HorizontalAlign.Right

                    If Not IsDBNull(dr("ESTIMATE_TOTAL_RENTAL")) Then
                        If (Convert.ToString(dr("ESTIMATE_TOTAL_RENTAL")) = "N/A" Or Convert.ToString(dr("ESTIMATE_TOTAL_RENTAL")) = "") Then
                            detailsRow.Cells(13).Text = dr("ESTIMATE_TOTAL_RENTAL")
                        Else
                            detailsRow.Cells(13).Text = Convert.ToDecimal(dr("ESTIMATE_TOTAL_RENTAL")).ToString("#,##0")
                        End If
                    Else
                        detailsRow.Cells(13).Text = "0"
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(14).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(14).Text = cDB.CheckIsNullString(dr("remark"))

                Else
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(0).Text = rowCount

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
                    detailsRow.Cells(1).Text = cDB.CheckIsNullString(dr("movie_title"))
                    detailsRow.Cells(1).ForeColor = Color.Black
                    detailsRow.Cells(1).Font.Bold = False

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = cDB.CheckIsNullString(dr("distributor_name"))

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(3).Text = cDB.CheckIsNullString(dr("week_no"))
                    detailsRow.Cells(3).ForeColor = Color.Black
                    detailsRow.Cells(3).Font.Bold = False

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(4).Text = cDB.CheckIsNullInteger(dr("cur_screen_qty"))
                    'CUR_ADMS_QTY
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(5).Text = Format(cDB.CheckIsNullInteger(dr("cur_gross_amt")), "#,##0")

                    ' CUR_ADMS_QTY
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(6).Text = Format(cDB.CheckIsNullInteger(dr("CUR_ADMS_QTY")), "#,##0")

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(7).Text = cDB.CheckIsNullInteger(dr("prev_screen_qty"))

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(8).Text = Format(cDB.CheckIsNullInteger(dr("prev_gross_amt")), "#,##0")
                    detailsRow.Cells(8).ForeColor = Color.Black
                    detailsRow.Cells(8).Font.Bold = False

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(9).Text = cDB.CheckIsNullString(dr("change_percent_desc"))

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(10).Text = Format(cDB.CheckIsNullInteger(dr("cumu_gross_amt")), "#,##0")

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(11).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(11).Text = Format(cDB.CheckIsNullInteger(dr("EST_NATIONWIDE_AMT")), "#,##0") 'est_nationwide_amt

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(12).HorizontalAlign = HorizontalAlign.Right

                    If Not IsDBNull(dr("final_flat_sale_amt")) Then
                        If (Convert.ToString(dr("final_flat_sale_amt")) = "N/A" Or Convert.ToString(dr("final_flat_sale_amt")) = "") Then
                            detailsRow.Cells(12).Text = dr("final_flat_sale_amt")
                        Else
                            detailsRow.Cells(12).Text = Convert.ToDecimal(dr("final_flat_sale_amt")).ToString("#,##0")
                        End If
                    Else
                        detailsRow.Cells(12).Text = "0"
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(13).HorizontalAlign = HorizontalAlign.Right

                    If Not IsDBNull(dr("final_flat_sale_amt")) Then
                        If (Convert.ToString(dr("ESTIMATE_TOTAL_RENTAL")) = "N/A" Or Convert.ToString(dr("ESTIMATE_TOTAL_RENTAL")) = "") Then
                            detailsRow.Cells(13).Text = dr("ESTIMATE_TOTAL_RENTAL")
                        Else
                            detailsRow.Cells(13).Text = Convert.ToDecimal(dr("ESTIMATE_TOTAL_RENTAL")).ToString("#,##0")
                        End If
                    Else
                        detailsRow.Cells(13).Text = "0"
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(14).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(14).Text = cDB.CheckIsNullString(dr("remark"))
                End If
                tbl.Rows.Add(detailsRow)
            End While
            dr.Close()
            'End While
            'drMovie.Close()


            Dim drTotal As IDataReader = cDB.getWeekendTrading(Convert.ToDateTime(Session("msRptStrDate")), CDbl(Session("msRptNumDay")), "TOTAL") ', "0"
            If drTotal.Read Then
                Dim endRow As New TableRow()
                endRow.Font.Bold = True
                endRow.Cells.Add(New TableCell)
                endRow.Cells(0).Text = "Total weekend gross :"
                endRow.Cells(0).ColumnSpan = 3
                endRow.Cells(0).Height = 15
                endRow.Cells(0).CssClass = "style1"
                endRow.Cells(0).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(1).Text = ""
                endRow.Cells(1).Height = 15
                endRow.Cells(1).CssClass = "style1"
                endRow.Cells(1).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(2).Text = ""
                endRow.Cells(2).Height = 15
                endRow.Cells(2).CssClass = "style1"
                endRow.Cells(2).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(3).Text = Format(cDB.CheckIsNullInteger(drTotal("TOTAL_CUR_GROSS_AMT")), "#,##0")
                endRow.Cells(3).Height = 15
                endRow.Cells(3).CssClass = "style1"
                endRow.Cells(3).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(4).Text = Format(cDB.CheckIsNullInteger(drTotal("TOTAL_CUR_ADMS_QTY")), "#,##0")
                endRow.Cells(4).Height = 15
                endRow.Cells(4).CssClass = "style1"
                endRow.Cells(4).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(5).Text = ""
                endRow.Cells(5).Height = 15
                endRow.Cells(5).CssClass = "style1"
                endRow.Cells(5).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(6).Text = Format(cDB.CheckIsNullInteger(drTotal("TOTAL_PREV_GROSS_AMT")), "#,##0")
                endRow.Cells(6).Height = 15
                endRow.Cells(6).CssClass = "style1"
                endRow.Cells(6).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(7).Text = cDB.CheckIsNullString(drTotal("TOTAL_CHANGE_PERCENT_DESC"))
                endRow.Cells(7).Height = 15
                endRow.Cells(7).CssClass = "style1"
                endRow.Cells(7).HorizontalAlign = HorizontalAlign.Right

                endRow.Cells.Add(New TableCell)
                endRow.Cells(8).Text = ""
                endRow.Cells(8).Height = 15
                endRow.Cells(8).CssClass = "style1"
                endRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
                endRow.Cells(8).ColumnSpan = 5
                tbl.Rows.Add(endRow)

            End If
            drTotal.Close()

            'Dim drUser As IDataReader = cDB.getUserDetail(CDbl(Session("UserID").ToString))
            'While (drUser.Read())
            Dim FootRow1 As New TableRow()
            Dim FootRow2 As New TableRow()
            Dim FootRow3 As New TableRow()
            Dim FootRow4 As New TableRow()
            Dim i As Integer
            For i = 1 To 4
                If i = 1 Then
                    FootRow1.Cells.Add(New TableCell)
                    FootRow1.Cells(0).Text = ""
                    FootRow1.Cells(0).ColumnSpan = 15
                    FootRow1.Cells(0).Height = 18
                    FootRow1.Cells(0).CssClass = "style1"
                    tbl.Rows.Add(FootRow1)
                ElseIf i = 2 Then
                    FootRow2.Cells.Add(New TableCell)
                    FootRow2.Cells(0).CssClass = "style1"
                    FootRow2.Cells(0).Text = ""
                    FootRow2.Cells(0).ColumnSpan = 12

                    FootRow2.Cells.Add(New TableCell)
                    FootRow2.Cells(1).CssClass = "style1"
                    FootRow2.Cells(1).Text = "Prepared by : "
                    FootRow2.Cells(1).HorizontalAlign = HorizontalAlign.Right

                    FootRow2.Cells.Add(New TableCell)
                    FootRow2.Cells(2).CssClass = "style1"
                    FootRow2.Cells(2).Text = "Tassama  Sasomsup"
                    FootRow2.Cells(2).ColumnSpan = 2
                    FootRow2.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    tbl.Rows.Add(FootRow2)
                ElseIf i = 3 Then
                    FootRow3.Cells.Add(New TableCell)
                    FootRow3.Cells(0).CssClass = "style1"
                    FootRow3.Cells(0).Text = ""
                    FootRow3.Cells(0).ColumnSpan = 13

                    FootRow3.Cells.Add(New TableCell)
                    FootRow3.Cells(1).CssClass = "style1"
                    FootRow3.Cells(1).Text = "Coordinator, Sales Administration"
                    FootRow3.Cells(1).ColumnSpan = 2
                    FootRow3.Cells(1).HorizontalAlign = HorizontalAlign.Center
                    tbl.Rows.Add(FootRow3)
                Else
                    FootRow4.Cells.Add(New TableCell)
                    FootRow4.Cells(0).CssClass = "style1"
                    FootRow4.Cells(0).Text = ""
                    FootRow4.Cells(0).BackColor = Color.FromName("#303D50")
                    FootRow4.Cells(0).ForeColor = Color.White

                    FootRow4.Cells.Add(New TableCell)
                    FootRow4.Cells(1).CssClass = "style1"
                    FootRow4.Cells(1).Text = "***(For CTFDI and BVI, estimate total rental include direct distribution and flat sales.  For other distributors, the information is not available.)"
                    FootRow4.Cells(1).ColumnSpan = 14
                    FootRow4.Cells(1).HorizontalAlign = HorizontalAlign.Left
                    FootRow4.Cells(1).BackColor = Color.FromName("#303D50")
                    FootRow4.Cells(1).ForeColor = Color.White
                    tbl.Rows.Add(FootRow4)
                End If
            Next

            'End While
            'drUser.Close()
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptPerWeekendParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=Weekend_Trading_Report.xls")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        tbl.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class