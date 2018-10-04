Imports Web.Data

Partial Public Class frmRptSoundFormat_sft
    Inherits System.Web.UI.Page

    Private Const COLUMN_START_HEADER_0 As Integer = 1
    Private Const COLUMN_START_HEADER_1 As Integer = 0
    Private Const COLUMN_START_DETAIL_0 As Integer = 1
    Private Const COLUMN_START_FOOTER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_0 As Integer = 1
    Private Const PIVOT_NUM_HEADER_1 As Integer = 4
    Private Const PIVOT_NUM_DETAIL_0 As Integer = 4
    Private Const PIVOT_NUM_FOOTER_0 As Integer = 4
    Private Const PIVOT_WIDTH_HEADER_0 As Integer = 280

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim movieId As String = Session("msRptMovieID")
        Dim startDate As String = Format(Session("msRptStrDate"), "yyyyMMdd")
        Dim endDate As String = Format(Session("msRptEndDate"), "yyyyMMdd")

        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptSoundFormat " _
                                                           + movieId _
                                                           + ", '" + startDate + "'" _
                                                           + ", '" + endDate + "'" _
                                                           + ", 'Theatre_SoundFormat'")

        Dim dtPivot As DataTable = cDatabase.GetDataTable("select film_type_sound_header_group " _
                                                          + "from tblFilmTypeSound " _
                                                          + "where film_type_sound_header_group is not null " _
                                                          + "group by film_type_sound_header_group " _
                                                          + "order by max(film_type_sound_id) ")

        Dim widthReport As Integer = 200 + PIVOT_WIDTH_HEADER_0 * dtPivot.Rows.Count + PIVOT_WIDTH_HEADER_0
        Dim colspanReport As Integer = COLUMN_START_HEADER_0 + PIVOT_NUM_HEADER_1 * dtPivot.Rows.Count + PIVOT_NUM_HEADER_1

        Me.tableReport.Width = New Unit(widthReport)
        Me.tableReport.Rows(0).Cells(0).Text = String.Format(Me.tableReport.Rows(0).Cells(0).Text, Session("msRptMovieName"))
        Me.tableReport.Rows(0).Cells(0).ColumnSpan = colspanReport
        Me.tableReport.Rows(1).Cells(0).Text = String.Format(Me.tableReport.Rows(1).Cells(0).Text, Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy"), Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy"))
        Me.tableReport.Rows(1).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader0(PIVOT_NUM_HEADER_0 - 1) As TableHeaderCell
            For jj As Integer = tdHeader0.Length - 1 To 0 Step -1
                Dim x As Integer = 2
                Dim y As Integer = COLUMN_START_HEADER_0
                tdHeader0(jj) = New TableHeaderCell
                tdHeader0(jj).Width = Me.tableReport.Rows(x).Cells(y).Width
                tdHeader0(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdHeader0(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader0(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdHeader0(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdHeader0(jj).Text = dtPivot.Rows(j)("film_type_sound_header_group")
                Me.tableReport.Rows(x).Cells.AddAt(COLUMN_START_HEADER_0, tdHeader0(jj))
            Next

            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim x As Integer = 3
                Dim y As Integer = COLUMN_START_HEADER_1 + (PIVOT_NUM_HEADER_1 - 1)
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdHeader1(jj).Width = Me.tableReport.Rows(x).Cells(y).Width
                tdHeader1(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdHeader1(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdHeader1(jj).Text = Me.tableReport.Rows(x).Cells(y).Text
                Me.tableReport.Rows(x).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdFooter0(PIVOT_NUM_HEADER_1 - 1) As TableCell
            For jj As Integer = tdFooter0.Length - 1 To 0 Step -1
                Dim x As Integer = Me.tableReport.Rows.Count - 1
                Dim y As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter0(jj) = New TableCell
                tdFooter0(jj).ColumnSpan = Me.tableReport.Rows(x).Cells(y).ColumnSpan
                tdFooter0(jj).HorizontalAlign = Me.tableReport.Rows(x).Cells(y).HorizontalAlign
                tdFooter0(jj).BackColor = Me.tableReport.Rows(x).Cells(y).BackColor
                tdFooter0(jj).ForeColor = Me.tableReport.Rows(x).Cells(y).ForeColor
                tdFooter0(jj).Text = Me.tableReport.Rows(x).Cells(y).Text
                Me.tableReport.Rows(x).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter0(jj))
            Next
        Next

        '--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail0 As New TableRow()

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(0).Text = String.Format("{0}", dtDetail.Rows(i)("theater_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))
                    trDetail0.Cells(y + 0).Text = String.Format("<a href=""frmRptSoundFormatBoxoffice.aspx?theaterid={0}&theatername={1}&headergroup={2}&typeid={3}"">{4}</a>" _
                                            , dtDetail.Rows(i)("theater_id") _
                                            , dtDetail.Rows(i)("theater_name") _
                                            , dtPivot.Rows(j)("film_type_sound_header_group") _
                                            , "Theatre_SoundFormat" _
                                            , String.Format("{0:#,##0}", dtDetail.Rows(i)(String.Format("{0}", dtPivot.Rows(j)("film_type_sound_header_group")) + " Amount")))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 2).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Screen"))

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 3).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 3).Text = String.Format("{0:#,##0.00%}", IIf(dtDetail.Rows(i)("Total Amount") > 0, dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount") / dtDetail.Rows(i)("Total Amount"), 0))
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

                    trDetail0.Cells.Add(New TableCell)
                    trDetail0.Cells(y + 3).HorizontalAlign = HorizontalAlign.Right
                    trDetail0.Cells(y + 3).Text = String.Format("{0:#,##0.00%}", IIf(dtDetail.Rows(i)("Total Amount") > 0, dtDetail.Rows(i)("Total Amount") / dtDetail.Rows(i)("Total Amount"), 0))
                End If
            Next

            Me.tableReport.Rows.AddAt(Me.tableReport.Rows.Count - 1, trDetail0)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tableReport.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
                'Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Screen])", ""))
                Me.tableReport.Rows(x).Cells(y + 3).Text = String.Format("{0:#,##0.00%}", IIf(dtDetail.Compute("sum([Total Amount])", "") > 0, dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", "") / dtDetail.Compute("sum([Total Amount])", ""), 0))
            Else
                Me.tableReport.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tableReport.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
                'Me.tableReport.Rows(x).Cells(y + 2).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Screen])", ""))
                Me.tableReport.Rows(x).Cells(y + 3).Text = String.Format("{0:#,##0.00%}", IIf(dtDetail.Compute("sum([Total Amount])", "") > 0, dtDetail.Compute("sum([Total Amount])", "") / dtDetail.Compute("sum([Total Amount])", ""), 0))
            End If
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptSoundFormat.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TheatreAndSoundFormat.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        Me.tableReport.RenderControl(htmlWrite)
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class