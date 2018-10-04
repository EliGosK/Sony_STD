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

Partial Public Class frmRptTrailerExeByWeek
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Mid(Session("permission"), 7, 1) = "0" Then
            '    Response.Redirect("InfoPage.aspx")
            'End If

            Dim intPerionWeek As Integer = Convert.ToInt32(Session("PeriodWeek"))
            Dim dtStartDate As DateTime = Convert.ToDateTime(Session("RptstrDate"))
            Dim dtEndDate As DateTime = dtStartDate.AddDays(intPerionWeek * 7)
            Dim dtRunningDate As DateTime = Convert.ToDateTime(Session("RptstrDate"))

            lblDate.Text = "From : " & Format(dtStartDate, "ddd dd-MMM-yyyy") & " To :" & Format(dtEndDate, "ddd dd-MMM-yyyy")
            Dim pManage As New cDatabase

            Dim i As Integer
            'remove ข้อมูลใน Table
            If (tblRpt.Rows.Count > 2) Then
                For i = 2 To tblRpt.Rows.Count - 1
                    If i > 2 Then
                        tblRpt.Rows.RemoveAt(i)
                    End If
                Next
            End If

            Dim TotalRow As New TableRow()
            TotalRow.Font.Bold = False
            TotalRow.BackColor = Color.White
            TotalRow.Cells.Add(New TableCell)
            TotalRow.Cells(0).Text = ""
            For i = 1 To intPerionWeek
                Dim DReaderBoxOffice As IDataReader = pManage.getBoxOfficeByPeriod(dtRunningDate, dtRunningDate.AddDays(6))
                If (DReaderBoxOffice.Read()) Then
                    TotalRow.Cells.Add(New TableCell)
                    TotalRow.Cells(i).Text = DReaderBoxOffice("TopBoxOffice")
                    TotalRow.Cells(i).Attributes("style") = "writing-mode: tb-rl"
                    TotalRow.Cells(i).HorizontalAlign = HorizontalAlign.Center
                    TotalRow.Cells(i).ForeColor = Color.Green
                    If (TotalRow.Cells(i).Text.Trim() <> "") Then
                        TotalRow.Cells(0).Height = 100
                    Else
                        TotalRow.Cells(0).Height = 0
                    End If
                    TotalRow.Font.Size = 8
                Else
                    TotalRow.Cells.Add(New TableCell)
                    TotalRow.Cells(i).Text = ""
                End If
                DReaderBoxOffice.Close()
                dtRunningDate = dtRunningDate.AddDays(7)
            Next
            tblRpt.Rows.Add(TotalRow)

            dtRunningDate = dtStartDate
            TotalRow = New TableRow()
            TotalRow.Font.Bold = True
            TotalRow.BackColor = Color.LightGray
            TotalRow.Cells.Add(New TableCell)
            TotalRow.Cells(0).Text = "Trailers"
            TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            For i = 1 To intPerionWeek
                TotalRow.Font.Bold = True
                TotalRow.BackColor = Color.LightGray
                TotalRow.Cells.Add(New TableCell)
                TotalRow.Cells(i).Text = dtRunningDate.ToString("d-MMM")
                TotalRow.Cells(i).HorizontalAlign = HorizontalAlign.Center
                dtRunningDate = dtRunningDate.AddDays(7)
            Next
            tblRpt.Rows.Add(TotalRow)


            tblRpt.Rows(0).Cells(0).ColumnSpan = intPerionWeek + 1
            tblRpt.Rows(1).Cells(0).ColumnSpan = intPerionWeek + 1


            dtRunningDate = dtStartDate
            'ViewState("StartDate") = Nothing
            Dim DReader As IDataReader = pManage.getReportGetAllTrailer_ByPeriod(dtStartDate, dtEndDate)
            While (DReader.Read())

                'ขีดเส้นใต้เมื่อขึ้น Release Date ใหม่
                'Dim tblSumRow As New TableRow()
                'If (ViewState("StartDate") Is Nothing) Then
                '    ViewState("StartDate") = Convert.ToString(DReader("movie_strdate")).Trim()
                'Else
                '    If Convert.ToString(ViewState("StartDate")).Trim() <> Convert.ToString(DReader("movie_strdate")).Trim() Then
                '        tblSumRow.Cells.Add(New TableCell)
                '        tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                '        tblSumRow.Cells(0).Height = 2
                '        tblSumRow.Cells(0).ColumnSpan = 1
                '        tblSumRow.Cells(0).BackColor = Color.FromName("#16255d")
                '        tblRpt.Rows.Add(tblSumRow)
                '        ViewState("StartDate") = Convert.ToString(DReader("movie_strdate")).Trim()
                '    End If
                'End If


                'Reset Datetime ให้เป็นวันแรก
                dtRunningDate = dtStartDate

                Dim TotalRow1 As New TableRow()
                TotalRow1.BackColor = Color.FromName("#eeeeee")


                Dim strmovietype_id As Integer = pManage.CheckIsNullInteger(DReader("movietype_id"))
                If strmovietype_id = 1 Then
                    TotalRow1.Font.Bold = True
                    TotalRow1.ForeColor = Color.Blue
                Else
                    TotalRow1.Font.Bold = False
                    TotalRow1.ForeColor = Color.Black
                End If


                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(0).Text = Convert.ToString(DReader("MoviesName"))

                For i = 1 To intPerionWeek
                    'เช็คว่าหนังตัวอย่างเข้าหรือยัง
                    Dim DReaderDetail0 As IDataReader = pManage.getTrailerExecuteByWeekByMovie(dtRunningDate, dtRunningDate.AddDays(6), Convert.ToInt32(DReader("movie_Id")))
                    If (DReaderDetail0.Read()) Then
                        If (Convert.ToDateTime(DReaderDetail0("setup_start_date")) > dtRunningDate) Then
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.Cells(i).BackColor = Color.Black
                            DReaderDetail0.Close()
                            dtRunningDate = dtRunningDate.AddDays(7)
                            Continue For
                        End If
                    End If
                    DReaderDetail0.Close()

                    'เช็คว่าหากฉายไปแล้วจะไม่มีหนังตัวอย่างเรื่องนั้น
                    If (Convert.ToDateTime(DReader("movie_strdate")) <= dtRunningDate) Then
                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(i).BackColor = Color.Black
                        DReaderDetail0.Close()
                        dtRunningDate = dtRunningDate.AddDays(7)
                        Continue For
                    End If

                    'เช็คจำนวนที่เข้าฉาย
                    Dim DReaderDetail As IDataReader = pManage.getReportGetSumTrailer_ByPeriod(dtRunningDate, dtRunningDate.AddDays(6), Convert.ToInt32(DReader("movie_Id")))
                    If (DReaderDetail.Read()) Then
                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(i).Text = Convert.ToInt64(DReaderDetail("SumAmount"))
                        TotalRow1.Cells(i).HorizontalAlign = HorizontalAlign.Center
                    Else
                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(i).Text = "0"
                        TotalRow1.Cells(i).HorizontalAlign = HorizontalAlign.Center
                    End If
                    DReaderDetail.Close()
                    dtRunningDate = dtRunningDate.AddDays(7)
                Next

                tblRpt.Rows.Add(TotalRow1)
            End While
            DReader.Close()
            'ViewState("StartDate") = Nothing
        Catch ex As Exception
            tblRpt.Rows(0).Cells(0).Text = ex.Message
        End Try

    End Sub




    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmRptTrailerExeByWeekParam.aspx")
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Try
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=TrailerExecute_ByWeek.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"
            Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
            Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
            tblRpt.RenderControl(htmlWrite)
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
            Response.End()
        Catch ex As Exception
            tblRpt.Rows(0).Cells(0).Text = ex.Message
        End Try

       


        ''Dim str As New StringBuilder()
        'Dim strWrite As String = ""

        'Dim i As Integer
        'Dim j As Integer
        'For i = 0 To tblRpt.Rows.Count - 1
        '    For j = 0 To tblRpt.Rows(i).Cells.Count - 1
        '        If j = tblRpt.Rows(i).Cells.Count - 1 Then
        '            'str.Append(Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34))
        '            strWrite += Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34)
        '        Else
        '            'Str.Append(Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34) & ",")
        '            strWrite += Chr(34) & tblRpt.Rows(i).Cells(j).Text & Chr(34) & ","
        '        End If
        '    Next
        '    'str.AppendLine()
        '    strWrite += vbNewLine
        'Next
        'Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=TrailerExecute_ByWeek.csv")
        ''Response.Charset = "windows-874"
        ''Response.Charset = "utf4"
        ''Response.ContentType = ""
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = "application/vnd.csv"
        'Dim stringWrite As New System.IO.StringWriter()
        'Dim htmlWrite As New HtmlTextWriter(stringWrite)

        'Dim getContent(strWrite.Length) As Byte
        'Dim encoding As System.Text.Encoding
        'encoding = encoding.Default
        'getContent = encoding.GetBytes(strWrite)

        'Response.BinaryWrite(getContent)
        'Response.End()


    End Sub

End Class