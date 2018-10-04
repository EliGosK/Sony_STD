Imports Web.Data
Partial Public Class frmRptSoundFormat_ft
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    '--- Commented by Wittawat W. (CSI) on 2012/11/21 : Add filmtype and sound
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If
    '    Dim wkMvID, Sd, Ed As String
    '    wkMvID = Session("msRptMovieID")
    '    Sd = Format(Session("msRptStrDate"), "yyyyMMdd")
    '    Ed = Format(Session("msRptEndDate"), "yyyyMMdd")
    '    'Dim dtb.Rows(i) As IDataReader = cDB.GetRptSoundFormat(wkMvID, Sd, Ed, "Theatre_Format")
    '    Dim dtb As DataTable
    '    dtb = cDatabase.GetDataTable("EXEC spGetRptSoundFormat " + wkMvID + ",'" + Sd + "','" + Ed + "','Theatre_Format'")

    '    tbl.Rows(0).Cells(0).Text = Session("msRptMovieName") & " Box Office By Theatre & Film Format"
    '    tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

    '    Dim sessionCount, SUMgbo_amount, SUMgbo_adms, SUMmm_amt, SUMmm_adms, SUMdigital_amt, SUMdigital_adms, SUMdim_amt, SUMdim_adms, SUMseventydim_amt, SUMseventydim_adms, rowCount As Double
    '    Dim lastTheater As String
    '    Dim movieSys As String
    '    Dim movieSound As String
    '    lastTheater = ""
    '    sessionCount = 0
    '    movieSys = ""
    '    movieSound = ""
    '    SUMgbo_amount = 0
    '    SUMgbo_adms = 0
    '    SUMmm_amt = 0
    '    SUMmm_adms = 0
    '    SUMdigital_amt = 0
    '    SUMdigital_adms = 0
    '    SUMseventydim_amt = 0
    '    SUMseventydim_adms = 0
    '    rowCount = 0
    '    For i As Integer = 0 To dtb.Rows.Count - 1


    '        Dim detailsRow As New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Center
    '        rowCount = rowCount + 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    '        detailsRow.Cells(0).Text = dtb.Rows(i)("theater_name")


    '        detailsRow.Cells.Add(New TableCell)

    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(1).Text = "<a href=frmRptSoundFormatBoxoffice.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=mm>" + Format(dtb.Rows(i)("mm_amt"), "#,##0") + "</a>"
    '        SUMmm_amt = SUMmm_amt + CDbl(dtb.Rows(i)("mm_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(2).Text = Format(dtb.Rows(i)("mm_adms"), "#,##0")
    '        SUMmm_adms = SUMmm_adms + CDbl(dtb.Rows(i)("mm_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(3).Text = "<a href=frmRptSoundFormatBoxoffice.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=digital>" + Format(dtb.Rows(i)("digital_amt"), "#,##0") + "</a>"
    '        SUMdigital_amt = SUMdigital_amt + CDbl(dtb.Rows(i)("digital_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(4).Text = Format(dtb.Rows(i)("digital_adms"), "#,##0")
    '        SUMdigital_adms = SUMdigital_adms + CDbl(dtb.Rows(i)("digital_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(5).Text = "<a href=frmRptSoundFormatBoxoffice.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=dim>" + Format(dtb.Rows(i)("dim_amt"), "#,##0") + "</a>"
    '        SUMdim_amt = SUMdim_amt + CDbl(dtb.Rows(i)("dim_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(6).Text = Format(dtb.Rows(i)("dim_adms"), "#,##0")
    '        SUMdim_adms = SUMdim_adms + CDbl(dtb.Rows(i)("dim_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(7).Text = "<a href=frmRptSoundFormatBoxoffice.aspx?theaterid=" + dtb.Rows(i)("theater_id").ToString() + "&typeid=seventydim>" + Format(dtb.Rows(i)("seventydim_amt"), "#,##0") + "</a>"
    '        SUMseventydim_amt = SUMseventydim_amt + CDbl(dtb.Rows(i)("seventydim_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(8).Text = Format(dtb.Rows(i)("seventydim_adms"), "#,##0")
    '        SUMseventydim_adms = SUMseventydim_adms + CDbl(dtb.Rows(i)("seventydim_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(9).Text = Format(dtb.Rows(i)("gbo_amount"), "#,##0")
    '        SUMgbo_amount = SUMgbo_amount + CDbl(dtb.Rows(i)("gbo_amount"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(10).Text = Format(dtb.Rows(i)("gbo_adms"), "#,##0")
    '        SUMgbo_adms = SUMgbo_adms + CDbl(dtb.Rows(i)("gbo_adms"))
    '        tbl.Rows.Add(detailsRow)

    '    Next


    '    'Dim i As Integer
    '    Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
    '    sumPerBox = 0
    '    sumPerAdms = 0
    '    sumPerBoxAll = 0
    '    sumPerAdmsAll = 0

    '    'For i = 1 To rowCount
    '    'tbl.Rows(rowCount + 3).Cells(1).Text = Format(SUMgbo_amount, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(2).Text = Format(SUMgbo_adms, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(3).Text = Format(SUMmm_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(4).Text = Format(SUMmm_adms, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(5).Text = Format(SUMdigital_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(6).Text = Format(SUMdigital_adms, "#,##0.##")
    '    'Next
    '    Dim totalRow As New TableRow()
    '    totalRow.HorizontalAlign = HorizontalAlign.Center
    '    totalRow.Font.Bold = True
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(0).Text = "TOTAL"
    '    totalRow.Cells(0).BackColor = Color.LightGray

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(1).BackColor = Color.LightGray
    '    totalRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(1).Text = Format(SUMmm_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(2).BackColor = Color.LightGray
    '    totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(2).Text = Format(SUMmm_adms, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(3).BackColor = Color.LightGray
    '    totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(3).Text = Format(SUMdigital_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(4).BackColor = Color.LightGray
    '    totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(4).Text = Format(SUMdigital_adms, "#,##0.##")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(5).BackColor = Color.LightGray
    '    totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(5).Text = Format(SUMdim_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(6).BackColor = Color.LightGray
    '    totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(6).Text = Format(SUMdim_adms, "#,##0.##")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(7).BackColor = Color.LightGray
    '    totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(7).Text = Format(SUMseventydim_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(8).BackColor = Color.LightGray
    '    totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(8).Text = Format(SUMseventydim_adms, "#,##0.##")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(9).Text = Format(SUMgbo_amount, "#,##0.##")
    '    totalRow.Cells(9).BackColor = Color.LightGray

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(10).Text = Format(SUMgbo_adms, "#,##0.##")
    '    totalRow.Cells(10).BackColor = Color.LightGray
    '    tbl.Rows.Add(totalRow)
    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/11/21 : Add filmtype and sound
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        Dim movieId As String = Session("msRptMovieID")
        Dim startDate As String = Format(Session("msRptStrDate"), "yyyyMMdd")
        Dim endDate As String = Format(Session("msRptEndDate"), "yyyyMMdd")

        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptSoundFormat " _
            + movieId _
            + ", '" + startDate + "'" _
            + ", '" + endDate + "'" _
            + ", 'Theatre_Format'")
        Dim dtPivot As DataTable = cDatabase.GetDataTable("select distinct film_type_header_group from tblFilmType where film_type_header_group is not null")

        Const startColumn As Integer = 1
        Const numPivotSub As Integer = 3
        Const widthPrivot As Integer = 200

        Me.tableReport.Width = New Unit(200 + widthPrivot * dtPivot.Rows.Count + widthPrivot)
        Me.tableReport.Rows(0).Cells(0).Text = Session("msRptMovieName") & " Box Office By Theatre & Film Format"
        Me.tableReport.Rows(0).Cells(0).ColumnSpan = startColumn + numPivotSub * dtPivot.Rows.Count + numPivotSub
        Me.tableReport.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
        Me.tableReport.Rows(1).Cells(0).ColumnSpan = startColumn + numPivotSub * dtPivot.Rows.Count + numPivotSub

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader2 As New TableHeaderCell
            tdHeader2.Width = Me.tableReport.Rows(2).Cells(startColumn).Width
            tdHeader2.ColumnSpan = Me.tableReport.Rows(2).Cells(startColumn).ColumnSpan
            tdHeader2.HorizontalAlign = Me.tableReport.Rows(2).Cells(startColumn).HorizontalAlign
            tdHeader2.BackColor = Me.tableReport.Rows(2).Cells(startColumn).BackColor
            tdHeader2.ForeColor = Me.tableReport.Rows(2).Cells(startColumn).ForeColor
            tdHeader2.Text = dtPivot.Rows(j)("film_type_header_group")
            Me.tableReport.Rows(2).Cells.AddAt(startColumn, tdHeader2)

            Dim tdHeader3(numPivotSub - 1) As TableHeaderCell
            For jj As Integer = tdHeader3.Length - 1 To 0 Step -1
                Dim x As Integer = 3
                Dim y As Integer = (startColumn - 1) + (tdHeader3.Length - 1)
                tdHeader3(jj) = New TableHeaderCell
                tdHeader3(jj).Width = Me.tableReport.Rows(x).Cells(y).Width
                tdHeader3(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdHeader3(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader3(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdHeader3(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdHeader3(jj).Text = Me.tableReport.Rows(x).Cells(y).Text
                Me.tableReport.Rows(x).Cells.AddAt(startColumn - 1, tdHeader3(jj))
            Next

            Dim tdFooter1(numPivotSub - 1) As TableCell
            For jj As Integer = tdFooter1.Length - 1 To 0 Step -1
                Dim x As Integer = Me.tableReport.Rows.Count - 1
                Dim y As Integer = (startColumn) + (tdHeader3.Length - 1)
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
                    'trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_header_group") + " Amount"))
                    trDetail.Cells(y + 0).Text = "<a href=""frmRptSoundFormatBoxoffice.aspx?" _
                        + "theaterid=" + String.Format("{0}", dtDetail.Rows(i)("theater_id")) _
                        + "&theatername=" + String.Format("{0}", dtDetail.Rows(i)("theater_name")) _
                        + "&headergroup=" + String.Format("{0}", dtPivot.Rows(j)("film_type_header_group")) _
                        + "&typeid=Theatre_Format" _
                        + """>" _
                        + String.Format("{0:#,##0}", dtDetail.Rows(i)(String.Format("{0}", dtPivot.Rows(j)("film_type_header_group")) + " Amount")) _
                        + "</a>"

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_header_group") + " Adms"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_header_group") + " Screen"))
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
                    Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_header_group") & " Amount])", ""))
                    Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_header_group") & " Adms])", ""))
                    'Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtb.Compute("max([" & dtPivot.Rows(j)("film_type_header_group") & " Screen])", ""))
                Else
                    Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                    Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
                    'Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtb.Compute("max([Total Screen])", ""))
                End If
            Else
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", 0)
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", 0)
                'Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", 0)
            End If
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptSoundFormat.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TheatreAndFilmFormat.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        Me.tableReport.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class