Imports Web.Data

Partial Public Class frmExportForCustomerComp
    Inherits System.Web.UI.Page

    '--- Commented by Wittawat W. (CSI) on 2012/12/12 : Add filmtype and sound
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    tblRpt.Rows(0).Cells(0).Text = "<center>Competitor Daily Box Office (Initial)</center>" + "Title : " & Session("movieNameComp") & ",  Date : " & Format(Session("strDateComp"), "ddd dd-MMM-yyyy")

    '    'tblRpt.Rows(0).Cells(0).Text = "<center>Competitor Daily Box Office (Initial)</center>" + "Title : " & Session("movieNameComp")
    '    'tblRpt.Rows(1).Cells(0).Text = "Date : " & Format(Session("strDateComp"), "ddd dd-MMM-yyyy")
    '    Dim getBoxOfficeData As New cDatabase
    '    Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeDataComp(Session("movieIDComp"), Format(Session("strDateComp"), "yyyyMMdd"))
    '    'Dim i As Integer
    '    While (readBoxOfficeData.Read())
    '        Dim detailsRow As New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    '        detailsRow.Cells(0).Text = readBoxOfficeData("theater_name")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(1).Text = Format(readBoxOfficeData("comprevenue_screenor"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).Text = Format(readBoxOfficeData("comprevenue_timeor"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).Text = Format(readBoxOfficeData("comprevenue_amountor"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).Text = Format(readBoxOfficeData("comprevenue_admsor"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).Text = Format(readBoxOfficeData("comprevenue_screenth"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).Text = Format(readBoxOfficeData("comprevenue_timeth"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).Text = Format(readBoxOfficeData("comprevenue_amountth"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(8).Text = Format(readBoxOfficeData("comprevenue_admsth"), "#,##0")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(9).Text = Format(readBoxOfficeData("comprevenue_screentd"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(10).Text = Format(readBoxOfficeData("comprevenue_timetd"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(11).Text = Format(readBoxOfficeData("comprevenue_amounttd"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(12).Text = Format(readBoxOfficeData("comprevenue_admstd"), "#,##0")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(13).Text = Format(readBoxOfficeData("comprevenue_screensum"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(14).Text = Format(readBoxOfficeData("comprevenue_timesum"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(15).Text = Format(readBoxOfficeData("comprevenue_amountsum"), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(16).Text = Format(readBoxOfficeData("comprevenue_admssum"), "#,##0")
    '        tblRpt.Rows.Add(detailsRow)
    '    End While

    '    Dim totalRow As New TableRow()
    '    Dim i As Integer
    '    Dim j As Integer
    '    'Dim 
    '    totalRow.Font.Bold = True
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(0).Text = " Grand Total : "

    '    totalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(0).BackColor = Color.FromName("#303D50")
    '    totalRow.Cells(0).ForeColor = Color.White
    '    For j = 1 To 16
    '        totalRow.Cells.Add(New TableCell)
    '        totalRow.Cells(j).Text = 0
    '        totalRow.Cells(j).HorizontalAlign = HorizontalAlign.Right
    '        For i = 0 To tblRpt.Rows.Count - 5
    '            totalRow.Cells(j).Text = Format(CDbl(totalRow.Cells(j).Text) + CDbl(tblRpt.Rows(i + 4).Cells(j).Text), "#,##0")
    '        Next

    '        totalRow.Cells(j).BackColor = Color.FromName("#303D50")
    '        totalRow.Cells(j).ForeColor = Color.White
    '        totalRow.Cells(j).HorizontalAlign = HorizontalAlign.Right
    '    Next
    '    tblRpt.Rows.Add(totalRow)

    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/12/12 : Add filmtype and sound
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim movieId As String = Session("movieIDComp")
        Dim movieName As String = Session("movieNameComp")
        Dim startDate As String = Format(Session("strDateComp"), "yyyyMMdd")

        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRevenueForCusComp " _
                                                           + movieId + ", '" _
                                                           + startDate + "'")

        Dim dtPivot As DataTable = cDatabase.GetDataTable("select film_type_sound_header_group " _
                                                          + "from tblFilmTypeSound " _
                                                          + "where film_type_sound_header_group is not null " _
                                                          + "group by film_type_sound_header_group " _
                                                          + "order by max(film_type_sound_id) ")

        Const startColumn As Integer = 1
        Const numPivotSub As Integer = 4
        Const widthPrivot As Integer = 250

        Me.tableReport.Width = New Unit(200 + widthPrivot * dtPivot.Rows.Count + widthPrivot)
        Me.tableReport.Rows(0).Cells(0).Text = String.Format(Me.tableReport.Rows(0).Cells(0).Text, Session("movieNameComp"), Format(Session("strDateComp"), "ddd dd-MMM-yyyy"))
        Me.tableReport.Rows(0).Cells(0).ColumnSpan = startColumn + numPivotSub * dtPivot.Rows.Count + numPivotSub

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader1 As New TableHeaderCell
            tdHeader1.Width = Me.tableReport.Rows(1).Cells(startColumn).Width
            tdHeader1.ColumnSpan = Me.tableReport.Rows(1).Cells(startColumn).ColumnSpan
            tdHeader1.HorizontalAlign = Me.tableReport.Rows(1).Cells(startColumn).HorizontalAlign
            tdHeader1.BackColor = Me.tableReport.Rows(1).Cells(startColumn).BackColor
            tdHeader1.ForeColor = Me.tableReport.Rows(1).Cells(startColumn).ForeColor
            tdHeader1.Text = dtPivot.Rows(j)("film_type_sound_header_group")
            Me.tableReport.Rows(1).Cells.AddAt(startColumn, tdHeader1)

            Dim tdHeader2(numPivotSub - 1) As TableHeaderCell
            For jj As Integer = tdHeader2.Length - 1 To 0 Step -1
                Dim x As Integer = 2
                Dim y As Integer = (startColumn - 1) + (tdHeader2.Length - 1)
                tdHeader2(jj) = New TableHeaderCell
                tdHeader2(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdHeader2(jj).Width = Me.tableReport.Rows(x).Cells(y).Width
                tdHeader2(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader2(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdHeader2(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdHeader2(jj).Text = Me.tableReport.Rows(x).Cells(y).Text
                Me.tableReport.Rows(x).Cells.AddAt(startColumn - 1, tdHeader2(jj))
            Next

            Dim tdFooter1(numPivotSub - 1) As TableCell
            For jj As Integer = tdFooter1.Length - 1 To 0 Step -1
                Dim x As Integer = Me.tableReport.Rows.Count - 1
                Dim y As Integer = (startColumn) + (tdHeader2.Length - 1)
                tdFooter1(jj) = New TableCell
                tdFooter1(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdFooter1(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdFooter1(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdFooter1(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdFooter1(jj).Text = Me.tableReport.Rows(x).Cells(y).Text
                Me.tableReport.Rows(x).Cells.AddAt(startColumn, tdFooter1(jj))
            Next
        Next

        '--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail As New TableRow()

            trDetail.HorizontalAlign = HorizontalAlign.Center

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(0).HorizontalAlign = HorizontalAlign.Center
            trDetail.Cells(0).Text = String.Format("{0:dd-MMM-yyyy}", dtDetail.Rows(i)("theater_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = startColumn + numPivotSub * j

                If j <> dtPivot.Rows.Count Then
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Screen"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 3).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 3).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Session"))
                Else
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Screen"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 3).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 3).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Session"))
                End If
            Next

            Me.tableReport.Rows.AddAt(tableReport.Rows.Count - 1, trDetail)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tableReport.Rows.Count - 1
            Dim y As Integer = startColumn + numPivotSub * j

            If dtDetail.Rows.Count > 0 Then
                If j <> dtPivot.Rows.Count Then
                    Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                    Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
                    Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Screen])", ""))
                    Me.tableReport.Rows(x).Cells(y + 3).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Session])", ""))
                Else
                    Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                    Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
                    Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Session])", ""))
                    Me.tableReport.Rows(x).Cells(y + 3).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Screen])", ""))
                End If
            Else
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(x).Cells(y + 3).Text = String.Format("{0:#,##0}", 0)
            End If
        Next
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=Comp_Daily_Box_Office.xls")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        'tblRpt.RenderControl(htmlWrite)
        tableReport.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmExportForCustomerCompParam.aspx")
    End Sub

End Class