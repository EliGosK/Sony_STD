﻿Imports Web.Data

Partial Public Class frmRptSoundFormat_sd
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    '--- Commented by Wittawat W. (CSI) on 2012/11/13 : Add filmtype and sound
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If
    '    Dim wkMvID, Sd, Ed As String
    '    wkMvID = Session("msRptMovieID")
    '    Sd = Format(Session("msRptStrDate"), "yyyyMMdd")
    '    Ed = Format(Session("msRptEndDate"), "yyyyMMdd")
    '    'Dim dtb.Rows(i) As IDataReader = cDB.GetRptSoundFormat(wkMvID, Sd, Ed, "Date_Sound")

    '    Dim dtb As DataTable
    '    dtb = cDatabase.GetDataTable("EXEC spGetRptSoundFormat " + wkMvID + ",'" + Sd + "','" + Ed + "','Date_Sound'")


    '    tbl.Rows(0).Cells(0).Text = Session("msRptMovieName") & " Box Office By Date & Sound"
    '    tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

    '    Dim sessionCount, SUMgbo_amount, SUMgbo_adms, SUMsoundtrack_amt, SUMsoundtrack_adms, SUMthai_dub_amt, SUMthai_dub_adms, rowCount As Double
    '    Dim lastTheater As String
    '    Dim movieSys As String
    '    Dim movieSound As String
    '    Dim SUMsoundtrack_cntScreen, SUMthai_dub_cntScreen, SUMgbo_cntScreen As Double
    '    lastTheater = ""
    '    sessionCount = 0
    '    movieSys = ""
    '    movieSound = ""
    '    SUMgbo_amount = 0
    '    SUMgbo_adms = 0
    '    SUMsoundtrack_amt = 0
    '    SUMsoundtrack_adms = 0
    '    SUMthai_dub_amt = 0
    '    SUMthai_dub_adms = 0
    '    rowCount = 0

    '    SUMsoundtrack_cntScreen = 0
    '    SUMthai_dub_cntScreen = 0
    '    SUMgbo_cntScreen = 0

    '    For i As Integer = 0 To dtb.Rows.Count - 1


    '        Dim detailsRow As New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Center
    '        rowCount = rowCount + 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '        detailsRow.Cells(0).Text = Format(dtb.Rows(i)("showing_date"), "dd-MMM-yyyy")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(1).Text = Format(dtb.Rows(i)("soundtrack_amt"), "#,##0")
    '        SUMsoundtrack_amt = SUMsoundtrack_amt + CDbl(dtb.Rows(i)("soundtrack_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(2).Text = Format(dtb.Rows(i)("soundtrack_adms"), "#,##0")
    '        SUMsoundtrack_adms = SUMsoundtrack_adms + CDbl(dtb.Rows(i)("soundtrack_adms"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(3).Text = Format(dtb.Rows(i)("soundtrack_cntScreen"), "#,##0")
    '        SUMsoundtrack_cntScreen = SUMsoundtrack_cntScreen + CDbl(dtb.Rows(i)("soundtrack_cntScreen"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(4).Text = Format(dtb.Rows(i)("thai_dub_amt"), "#,##0")
    '        SUMthai_dub_amt = SUMthai_dub_amt + CDbl(dtb.Rows(i)("thai_dub_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(5).Text = Format(dtb.Rows(i)("thai_dub_adms"), "#,##0")
    '        SUMthai_dub_adms = SUMthai_dub_adms + CDbl(dtb.Rows(i)("thai_dub_adms"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(6).Text = Format(dtb.Rows(i)("thai_dub_cntScreen"), "#,##0")
    '        SUMthai_dub_cntScreen = SUMthai_dub_cntScreen + CDbl(dtb.Rows(i)("thai_dub_cntScreen"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(7).Text = Format(dtb.Rows(i)("gbo_amount"), "#,##0")
    '        SUMgbo_amount = SUMgbo_amount + CDbl(dtb.Rows(i)("gbo_amount"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(8).Text = Format(dtb.Rows(i)("gbo_adms"), "#,##0")
    '        SUMgbo_adms = SUMgbo_adms + CDbl(dtb.Rows(i)("gbo_adms"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(9).Text = Format(CDbl(dtb.Rows(i)("soundtrack_cntScreen")) + CDbl(dtb.Rows(i)("thai_dub_cntScreen")), "#,##0")
    '        SUMgbo_cntScreen = SUMgbo_cntScreen + CDbl(dtb.Rows(i)("soundtrack_cntScreen")) + CDbl(dtb.Rows(i)("thai_dub_cntScreen"))

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
    '    'tbl.Rows(rowCount + 3).Cells(3).Text = Format(SUMsoundtrack_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(4).Text = Format(SUMsoundtrack_adms, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(5).Text = Format(SUMthai_dub_amt, "#,##0.##")
    '    'tbl.Rows(rowCount + 3).Cells(6).Text = Format(SUMthai_dub_adms, "#,##0.##")
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
    '    totalRow.Cells(1).Text = Format(SUMsoundtrack_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(2).BackColor = Color.LightGray
    '    totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(2).Text = Format(SUMsoundtrack_adms, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(3).BackColor = Color.LightGray
    '    totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(3).Text = "" 'Format(SUMsoundtrack_cntScreen, "#,##0.##")


    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(4).BackColor = Color.LightGray
    '    totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(4).Text = Format(SUMthai_dub_amt, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(5).BackColor = Color.LightGray
    '    totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(5).Text = Format(SUMthai_dub_adms, "#,##0.##")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(6).BackColor = Color.LightGray
    '    totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(6).Text = "" 'Format(SUMthai_dub_cntScreen, "#,##0.##")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(7).Text = Format(SUMgbo_amount, "#,##0.##")
    '    totalRow.Cells(7).BackColor = Color.LightGray
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(8).Text = Format(SUMgbo_adms, "#,##0.##")
    '    totalRow.Cells(8).BackColor = Color.LightGray
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(9).Text = "" 'Format(SUMgbo_cntScreen, "#,##0.##")
    '    totalRow.Cells(9).BackColor = Color.LightGray
    '    tbl.Rows.Add(totalRow)

    'End Sub

    '--- Added by Wittawat W. on 2012/11/13 : Add filmtype and sound
    Private Const COLUMN_START_HEADER_0 As Integer = 1
    Private Const COLUMN_START_HEADER_1 As Integer = 0
    Private Const COLUMN_START_DETAIL_0 As Integer = 2
    Private Const COLUMN_START_FOOTER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_1 As Integer = 3
    Private Const PIVOT_NUM_DETAIL_0 As Integer = 3
    Private Const PIVOT_NUM_FOOTER_0 As Integer = 3
    Private Const PIVOT_WIDTH_HEADER_0 As Integer = 200

    '--- Added by Wittawat W. (CSI) on 2012/11/13 : Add filmtype and sound
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
                                                                                       + ", 'Date_Sound'")
        Dim dtPivot As DataTable = cDatabase.GetDataTable("select distinct sound_header_group " _
                                                                                & "from tblFilmTypeSound " _
                                                                                & "where sound_header_group is not null")

        Dim widthReport As Integer = 200 + PIVOT_WIDTH_HEADER_0 * dtPivot.Rows.Count + PIVOT_WIDTH_HEADER_0
        Dim colspanReport As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_HEADER_1 * dtPivot.Rows.Count + PIVOT_NUM_HEADER_1

        Me.tbReport.Width = New Unit(widthReport)
        Me.tbReport.Rows(0).Cells(0).Text = String.Format(Me.tbReport.Rows(0).Cells(0).Text, Session("msRptMovieName"))
        Me.tbReport.Rows(0).Cells(0).ColumnSpan = colspanReport
        Me.tbReport.Rows(1).Cells(0).Text = String.Format(Me.tbReport.Rows(1).Cells(0).Text, Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy"), Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy"))
        Me.tbReport.Rows(1).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader0(PIVOT_NUM_HEADER_0 - 1) As TableHeaderCell
            For jj As Integer = tdHeader0.Length - 1 To 0 Step -1
                Dim x As Integer = 2
                Dim y As Integer = COLUMN_START_HEADER_0
                tdHeader0(jj) = New TableHeaderCell
                tdHeader0(jj).Width = Me.tbReport.Rows(x).Cells(y).Width
                tdHeader0(jj).ColumnSpan = Me.tbReport.Rows(x).Cells(y).ColumnSpan
                tdHeader0(jj).HorizontalAlign = Me.tbReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader0(jj).BackColor = Me.tbReport.Rows(x).Cells(y).BackColor
                tdHeader0(jj).ForeColor = Me.tbReport.Rows(x).Cells(y).ForeColor
                tdHeader0(jj).Text = dtPivot.Rows(j)("sound_header_group")
                Me.tbReport.Rows(x).Cells.AddAt(COLUMN_START_HEADER_0, tdHeader0(jj))
            Next

            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim xx As Integer = 3
                Dim yy As Integer = COLUMN_START_HEADER_1 + (PIVOT_NUM_HEADER_1 - 1)
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).ColumnSpan = Me.tbReport.Rows(xx).Cells(yy).ColumnSpan
                tdHeader1(jj).Width = Me.tbReport.Rows(xx).Cells(yy).Width
                tdHeader1(jj).HorizontalAlign = Me.tbReport.Rows(xx).Cells(yy).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tbReport.Rows(xx).Cells(yy).BackColor
                tdHeader1(jj).ForeColor = Me.tbReport.Rows(xx).Cells(yy).ForeColor
                tdHeader1(jj).Text = Me.tbReport.Rows(xx).Cells(yy).Text
                Me.tbReport.Rows(xx).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdFooter0(PIVOT_NUM_HEADER_1 - 1) As TableCell
            For jj As Integer = tdFooter0.Length - 1 To 0 Step -1
                Dim xxx As Integer = Me.tbReport.Rows.Count - 1
                Dim yyy As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter0(jj) = New TableCell
                tdFooter0(jj).ColumnSpan = Me.tbReport.Rows(xxx).Cells(yyy).ColumnSpan
                tdFooter0(jj).HorizontalAlign = Me.tbReport.Rows(xxx).Cells(yyy).HorizontalAlign
                tdFooter0(jj).BackColor = Me.tbReport.Rows(xxx).Cells(yyy).BackColor
                tdFooter0(jj).ForeColor = Me.tbReport.Rows(xxx).Cells(yyy).ForeColor
                tdFooter0(jj).Text = Me.tbReport.Rows(xxx).Cells(yyy).Text
                Me.tbReport.Rows(xxx).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter0(jj))
            Next
        Next

        '--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail0 As New TableRow()

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(0).Width = 80
            trDetail0.Cells(0).Text = String.Format("{0:dd-MMM-yyyy}", dtDetail.Rows(i)("revenue_date"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(1).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(1).Width = 120
            trDetail0.Cells(1).Text = String.Format("<font color=red><i>{0}<i></font>", dtDetail.Rows(i)("holiday_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("sound_header_group") + " Amount"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("sound_header_group") + " Adms"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("sound_header_group") + " Screen"))
                Else
                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Screen"))
                End If
            Next

            Me.tbReport.Rows.AddAt(Me.tbReport.Rows.Count - 1, trDetail0)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tbReport.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tbReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("sound_header_group") & " Amount])", ""))
                Me.tbReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("sound_header_group") & " Adms])", ""))
                Me.tbReport.Rows(x).Cells(y + 2).Text = "" 'String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("sound_header_group") & " Screen])", ""))
            Else
                Me.tbReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tbReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
                Me.tbReport.Rows(x).Cells(y + 2).Text = "" 'String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Screen])", ""))
            End If
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptSoundFormat.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=DateAndSound.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        Me.tbReport.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class