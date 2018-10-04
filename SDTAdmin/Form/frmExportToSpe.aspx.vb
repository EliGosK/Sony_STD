Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports Web.Data

Partial Public Class frmExportToSpe
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblDate.Text = "From : " & Format(Session("ExtStrDate"), "ddd dd-MMM-yyyy") & " To :" & Format(Session("ExtEndDate"), "ddd dd-MMM-yyyy")
        Dim getBoxOfficeData As New cDatabase
        Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeForExport(Session("ExtMovieID"), Format(Session("ExtStrDate"), "yyyyMMdd"), Format(Session("ExtEndDate"), "yyyyMMdd"))
        Dim sessionCount, SumBox, SumAdms, rowCount As Double
        Dim lastTheater As String
        Dim movieSys As String
        Dim movieSound As String
        Dim flimType As String
        lastTheater = ""
        sessionCount = 0
        movieSys = ""
        movieSound = ""
        SumBox = 0
        SumAdms = 0
        rowCount = 0 ' + 1
        flimType = 0
        While (readBoxOfficeData.Read())
            '--- Modified by Wittawat W. (CSI) on 20121113 : Add film type and sound
            'If readBoxOfficeData("movie_system").ToString() = "35 มม." And readBoxOfficeData("sound_type").ToString() = "ต้นฉบับ" Then
            '    flimType = 1
            'ElseIf readBoxOfficeData("movie_system").ToString() = "35 มม." And readBoxOfficeData("sound_type").ToString() = "พากย์ไทย" Then
            '    flimType = 2
            'ElseIf readBoxOfficeData("movie_system").ToString() = "ดิจิตอล" Then
            '    flimType = 3
            'ElseIf readBoxOfficeData("movie_system").ToString() = "3 มิติ" Then
            '    flimType = 3
            'End If
            flimType = String.Format("{0}", readBoxOfficeData("spirit_world_export_id"))
            '--- End modified by Wittawat W. (CSI) on 20121113 : Add film type and sound

            If String.Format("{0}", readBoxOfficeData("TName")) & flimType <> lastTheater Then
                sessionCount = 0
                Dim detailsRow As New TableRow()
                rowCount = rowCount + 1
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).Text = String.Format("{0}", readBoxOfficeData("TheaterSub_code"))
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).Text = String.Format("{0}", readBoxOfficeData("TName"))
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).Text = String.Format("{0}", readBoxOfficeData("movie_code"))
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(3).Text = String.Format("{0}", readBoxOfficeData("MName"))
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(4).Text = flimType
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(5).Text = String.Format("{0:ddMMyyyy}", Session("ExtStrDate"))
                Dim j As Integer
                For j = 6 To 19
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(j).Text() = "0"
                Next

                Dim k As Double
                k = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("ExtStrDate")), CDate(readBoxOfficeData("revenue_date"))))
                detailsRow.Cells(k + 6).Text = readBoxOfficeData("SumAmount")
                detailsRow.Cells(k + 7).Text = readBoxOfficeData("SumAdms")

                tblRpt.Rows.Add(detailsRow)

                lastTheater = String.Format("{0}", readBoxOfficeData("TName")) & flimType
                sessionCount = 0
            Else
                'sessionCount = sessionCount + 2
                Dim m As Double
                m = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("ExtStrDate")), CDate(readBoxOfficeData("revenue_date"))))
                tblRpt.Rows(rowCount).Cells(m + 6).Text = readBoxOfficeData("SumAmount")
                tblRpt.Rows(rowCount).Cells(m + 7).Text = readBoxOfficeData("SumAdms")
                lastTheater = String.Format("{0}", readBoxOfficeData("TName")) & flimType
            End If
        End While
        readBoxOfficeData.Close()

        Dim c As Double
        Dim SumBoxDay1, SumBoxDay2, SumBoxDay3, SumBoxDay4, SumBoxDay5, SumBoxDay6, SumBoxDay7, _
        SumAmdsDay1, SumAmdsDay2, SumAmdsDay3, SumAmdsDay4, SumAmdsDay5, SumAmdsDay6, SumAmdsDay7 As Double

        For c = 2 To rowCount
            SumBoxDay1 = SumBoxDay1 + CDbl(IIf(tblRpt.Rows(c).Cells(6).Text = "", 0, tblRpt.Rows(c).Cells(6).Text))
            SumAmdsDay1 = SumAmdsDay1 + CDbl(IIf(tblRpt.Rows(c).Cells(7).Text = "", 0, tblRpt.Rows(c).Cells(7).Text))
            SumBoxDay2 = SumBoxDay2 + CDbl(IIf(tblRpt.Rows(c).Cells(8).Text = "", 0, tblRpt.Rows(c).Cells(8).Text))
            SumAmdsDay2 = SumAmdsDay2 + CDbl(IIf(tblRpt.Rows(c).Cells(9).Text = "", 0, tblRpt.Rows(c).Cells(9).Text))
            SumBoxDay3 = SumBoxDay3 + CDbl(IIf(tblRpt.Rows(c).Cells(10).Text = "", 0, tblRpt.Rows(c).Cells(10).Text))
            SumAmdsDay3 = SumAmdsDay3 + CDbl(IIf(tblRpt.Rows(c).Cells(11).Text = "", 0, tblRpt.Rows(c).Cells(11).Text))
            SumBoxDay4 = SumBoxDay4 + CDbl(IIf(tblRpt.Rows(c).Cells(12).Text = "", 0, tblRpt.Rows(c).Cells(12).Text))
            SumAmdsDay4 = SumAmdsDay4 + CDbl(IIf(tblRpt.Rows(c).Cells(13).Text = "", 0, tblRpt.Rows(c).Cells(13).Text))
            SumBoxDay5 = SumBoxDay5 + CDbl(IIf(tblRpt.Rows(c).Cells(14).Text = "", 0, tblRpt.Rows(c).Cells(14).Text))
            SumAmdsDay5 = SumAmdsDay5 + CDbl(IIf(tblRpt.Rows(c).Cells(15).Text = "", 0, tblRpt.Rows(c).Cells(15).Text))
            SumBoxDay6 = SumBoxDay6 + CDbl(IIf(tblRpt.Rows(c).Cells(16).Text = "", 0, tblRpt.Rows(c).Cells(16).Text))
            SumAmdsDay6 = SumAmdsDay6 + CDbl(IIf(tblRpt.Rows(c).Cells(17).Text = "", 0, tblRpt.Rows(c).Cells(17).Text))
            SumBoxDay7 = SumBoxDay7 + CDbl(IIf(tblRpt.Rows(c).Cells(18).Text = "", 0, tblRpt.Rows(c).Cells(18).Text))
            SumAmdsDay7 = SumAmdsDay7 + CDbl(IIf(tblRpt.Rows(c).Cells(19).Text = "", 0, tblRpt.Rows(c).Cells(19).Text))

        Next
        Dim TotalRow As New TableRow()
        TotalRow.Font.Bold = True
        TotalRow.BackColor = Color.LightGray
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(0).ColumnSpan = 6
        TotalRow.Cells(0).Text = "Grand Total :"
        TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(1).Text = Format(SumBoxDay1, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(2).Text = Format(SumAmdsDay1, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(3).Text = Format(SumBoxDay2, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(4).Text = Format(SumAmdsDay2, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(5).Text = Format(SumBoxDay3, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(6).Text = Format(SumAmdsDay3, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(7).Text = Format(SumBoxDay4, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(8).Text = Format(SumAmdsDay4, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(9).Text = Format(SumBoxDay5, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(10).Text = Format(SumAmdsDay5, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(11).Text = Format(SumBoxDay6, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(12).Text = Format(SumAmdsDay6, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(13).Text = Format(SumBoxDay7, "#,##0")
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(14).Text = Format(SumAmdsDay7, "#,##0")
        tblRpt.Rows.Add(TotalRow)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmExportParam.aspx")
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Dim str As New StringBuilder()

        Dim i As Integer
        Dim j As Integer
        For i = 0 To tblRpt.Rows.Count - 2
            For j = 0 To tblRpt.Rows(i).Cells.Count - 1
                If j = tblRpt.Rows(i).Cells.Count - 1 Then
                    str.Append(Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34))
                Else
                    str.Append(Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34) & ",")
                End If
            Next
            str.AppendLine()
        Next
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=Thai_MoviesTitle.csv")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.csv"
        Dim stringWrite As New System.IO.StringWriter()
        Dim htmlWrite As New HtmlTextWriter(stringWrite)
        Response.Write(str.ToString())
        'Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + str.ToString())
        Response.End()

    End Sub

End Class