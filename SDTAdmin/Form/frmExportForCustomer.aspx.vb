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
Partial Public Class frmExportForCustomer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tblRpt.Rows(0).Cells(0).Text = "<center>SDT Daily Box Office(Initial)</center>" + "Title : " & Session("RptMovieName") & ",  Date : " & Format(Session("RptstrDate"), "ddd dd-MMM-yyyy")
        Dim cDB As New cDatabase
        Dim dr As IDataReader
        'dr = cDB.getBoxOfficeData(Session("RptMovieID"), Format(Session("RptstrDate"), "yyyyMMdd"))
        Dim strDate As String = Format(Session("RptstrDate"), "yyyyMMdd")

        '--- Modified by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound
        'Dim wkSQLNew As String
        'wkSQLNew = "SELECT tblTheaterSub.theatersub_code, tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name AS TName, tblMovie.movie_code, "
        'wkSQLNew += vbNewLine + " tblMovie.movie_nameen AS MName, tblMovie.movie_strdate, tblRevenue.revenue_adms AS SumAdms, tblRevenue.revenue_amount AS SumAmount, "
        'wkSQLNew += vbNewLine + " tblRevenue.revenue_date, tblRevenue.movie_system, tblRevenue.sound_type, tblRevenue.revenue_Time, tblUser.user_name"
        'wkSQLNew += vbNewLine + " FROM tblTheater RIGHT OUTER JOIN"
        'wkSQLNew += vbNewLine + " tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id RIGHT OUTER JOIN"
        'wkSQLNew += vbNewLine + " tblMovie RIGHT OUTER JOIN"
        'wkSQLNew += vbNewLine + " tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id AND "
        'wkSQLNew += vbNewLine + " tblTheaterSub.theater_id = tblRevenue.theater_id LEFT OUTER JOIN"
        'wkSQLNew += vbNewLine + " tblUser ON tblRevenue.user_id = tblUser.user_id"
        'wkSQLNew += vbNewLine + " WHERE (tblRevenue.movies_id = " + Session("RptMovieID").ToString + ") AND (tblRevenue.revenue_date ='" + strDate + "')"
        ''wkSQLNew += " AND (tblTheaterSub.theatersub_code = 'T0475')"
        'wkSQLNew += vbNewLine + " ORDER BY tblTheater.theater_name, tblTheaterSub.theatersub_id, MName, tblRevenue.revenue_date, tblRevenue.timehour_id, tblRevenue.timemin_id"

        'dr = cDB.GetDataAll(wkSQLNew)

        dr = cDB.getBoxOfficeForCustomer(Session("RptMovieID").ToString, strDate)
        '--- End modified by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound

        'Dim i As Integer
        Dim sessionCount, SumBox, SumAdms, rowCount As Double
        Dim lastTheater As String
        Dim movieSys As String
        Dim movieSound As String
        Dim movieSoundcheck1, movieSoundcheck2 As String
        lastTheater = ""
        sessionCount = 0
        movieSys = ""
        movieSoundcheck1 = ""
        movieSoundcheck2 = ""
        movieSound = ""
        SumBox = 0
        SumAdms = 0
        rowCount = 0
        While (dr.Read())
            If String.Format("{0}{1}", dr("TName"), dr("film_type_sound_header_group")) <> lastTheater Then
                sessionCount = 0
                movieSys = dr("movie_system").ToString()
                movieSoundcheck2 = ""
                movieSoundcheck1 = ""
                movieSound = dr("sound_type").ToString().ToString.Trim
                Dim detailsRow As New TableRow()
                detailsRow.Font.Size = 9
                detailsRow.Font.Name = "Tahoma"
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).Text = dr("TName").ToString()
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center

                '--- Modified by Wittawat W. (CSI) on 20121113 : Add film type and sound
                'If dr("movie_system") = "35 มม." And dr("sound_type") = "ต้นฉบับ" Then
                '    movieSoundcheck1 = "E"
                'ElseIf dr("movie_system") = "35 มม." And dr("sound_type") = "พากย์ไทย" Then
                '    movieSoundcheck1 = "T"
                'ElseIf dr("movie_system") = "ดิจิตอล" Then
                '    movieSoundcheck1 = "D"
                'ElseIf dr("movie_system") = "3 มิติ" Then
                '    movieSoundcheck1 = "3D"
                'End If
                movieSoundcheck1 = dr("film_type_sound_header_group")
                '--- End modified by Wittawat W. (CSI) on 20121113 : Add film type and sound

                detailsRow.Cells(1).Text = movieSoundcheck1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).Text = Format(dr("SumAmount"), "#,##0")
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(3).Text = Format(dr("SumAdms"), "#,##0")
                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right

                Dim i As Integer
                For i = 0 To 13
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(i + 4).Text() = ""
                    detailsRow.Cells(i + 4).HorizontalAlign = HorizontalAlign.Right

                Next
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(18).Text = Format(dr("SumAmount"), "#,##0")
                detailsRow.Cells(18).HorizontalAlign = HorizontalAlign.Right

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(19).Text = Format(dr("SumAdms"), "#,##0")
                detailsRow.Cells(19).HorizontalAlign = HorizontalAlign.Right

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(20).Text = dr("user_name").ToString()

                tblRpt.Rows.Add(detailsRow)
                lastTheater = String.Format("{0}{1}", dr("TName"), dr("film_type_sound_header_group"))
                SumBox = dr("SumAmount").ToString()
                SumAdms = dr("SumAdms").ToString()
                rowCount = rowCount + 1
                sessionCount = 0
            Else
                'movieSound = dr("sound_type").ToString.Trim

                sessionCount = sessionCount + 2
                SumBox = SumBox + CDbl(dr("SumAmount"))
                SumAdms = SumAdms + CDbl(dr("SumAdms"))

                tblRpt.Rows(rowCount + 2).Cells(sessionCount + 2).Text = Format(dr("SumAmount"), "#,##0")
                tblRpt.Rows(rowCount + 2).Cells(sessionCount + 2).HorizontalAlign = HorizontalAlign.Right
                tblRpt.Rows(rowCount + 2).Cells(sessionCount + 3).Text = Format(dr("SumAdms"), "#,##0")
                tblRpt.Rows(rowCount + 2).Cells(sessionCount + 3).HorizontalAlign = HorizontalAlign.Right

                tblRpt.Rows(rowCount + 2).Cells(18).Text = Format(SumBox, "#,##0")
                tblRpt.Rows(rowCount + 2).Cells(18).HorizontalAlign = HorizontalAlign.Right
                tblRpt.Rows(rowCount + 2).Cells(19).Text = Format(SumAdms, "#,##0")
                tblRpt.Rows(rowCount + 2).Cells(19).HorizontalAlign = HorizontalAlign.Right


                '--- Modified by Wittawat W. (CSI) on 20121113 : Add film type and sound
                'If movieSoundcheck1 <> "E/T" Then
                '    If movieSound = dr("sound_type").ToString.Trim Then
                '        If dr("movie_system") = "35 มม." And dr("sound_type") = "ต้นฉบับ" Then
                '            movieSoundcheck1 = "E"
                '        ElseIf dr("movie_system") = "35 มม." And dr("sound_type") = "พากย์ไทย" Then
                '            movieSoundcheck1 = "T"
                '        ElseIf dr("movie_system") = "ดิจิตอล" Then
                '            movieSoundcheck1 = "D"
                '        ElseIf dr("movie_system") = "3 มิติ" Then
                '            movieSoundcheck1 = "3D"
                '        End If
                '    Else
                '        movieSoundcheck1 = "E/T"
                '    End If
                'End If

                If movieSoundcheck1 <> "E/T" Then
                    If movieSoundcheck1 = dr("film_type_sound_header_group") Then
                        movieSoundcheck1 = dr("film_type_sound_header_group")
                    Else
                        movieSoundcheck1 = "E/T"
                    End If
                End If
                '--- End modified by Wittawat W. (CSI) on 20121113 : Add film type and sound

                tblRpt.Rows(rowCount + 2).Cells(1).Text = movieSoundcheck1

                movieSys = dr("movie_system").ToString()
                movieSound = dr("sound_type").ToString()
                lastTheater = String.Format("{0}{1}", dr("TName"), dr("film_type_sound_header_group"))
            End If
        End While
        Dim c As Integer
        Dim totalSumBox As Double
        Dim totalSumAdms As Double
        totalSumBox = 0
        totalSumAdms = 0
        For c = 1 To rowCount
            totalSumBox = totalSumBox + CDbl(tblRpt.Rows(c + 2).Cells(18).Text)
            totalSumAdms = totalSumAdms + CDbl(tblRpt.Rows(c + 2).Cells(19).Text)
        Next
        dr.Close()
        Dim totalRow As New TableRow()

        totalRow.Font.Size = 9
        totalRow.Font.Name = "Tahoma"
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(0).ColumnSpan = 18
        totalRow.Cells(0).BackColor = Color.FromName("#303D50")
        totalRow.Cells(0).ForeColor = Color.White
        totalRow.Font.Bold = True
        totalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(0).Text = " TOTAL : "
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(1).Text = Format(totalSumBox, "#,##0")
        totalRow.Cells(1).BackColor = Color.FromName("#303D50")
        totalRow.Cells(1).ForeColor = Color.White
        totalRow.Cells(1).HorizontalAlign = HorizontalAlign.Right

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(2).Text = Format(totalSumAdms, "#,##0")
        totalRow.Cells(2).BackColor = Color.FromName("#303D50")
        totalRow.Cells(2).ForeColor = Color.White
        totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(3).Text = rowCount
        totalRow.Cells(3).BackColor = Color.FromName("#303D50")
        totalRow.Cells(3).ForeColor = Color.White
        totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Center

        tblRpt.Rows.Add(totalRow)

    End Sub

    'Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
    '    Dim str As New StringBuilder()
    '    'Dim LinStr As String
    '    'str.Append("<table><tr></tr></table>")
    '    str.Append("Title : " & Session("RptMovieName") & ",Date : " & Format(Session("RptstrDate"), "ddd dd-MMM-yyyy"))
    '    str.AppendLine()
    '    str.Append(Chr(34) & "TheatreName" & Chr(34) & "," & Chr(34) & "Sound" & Chr(34) & "," _
    '       & Chr(34) & " Session 1" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) _
    '       & "Session 2" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) & "Session 3" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) _
    '       & "Session 4" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) & "Session 5" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) _
    '       & "Session 6" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) & "Session 7" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) & "Session 8" & Chr(34) & "," & Chr(34) & "" & Chr(34) _
    '       & "," & Chr(34) & "Total" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," & Chr(34) & "Checker" & Chr(34))
    '    str.AppendLine()
    '    str.Append(Chr(34) & "" & Chr(34) & "," & Chr(34) & "" & Chr(34) & "," _
    '               & Chr(34) & " Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) _
    '               & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) _
    '               & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) _
    '               & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) _
    '               & "," & Chr(34) & "Bath" & Chr(34) & "," & Chr(34) & "Adms" & Chr(34) & "," & Chr(34) & "" & Chr(34))
    '    str.AppendLine()
    '    Dim myStr1, myStr2, myStr3 As String
    '    myStr1 = ""
    '    myStr2 = ""
    '    myStr3 = ""
    '    'Dim getBoxOfficeData As New cDatabase
    '    'Dim readBoxOfficeData As IDataReader = cDB.getBoxOfficeData(Session("ExtMovieID"), Format(Session("ExtStrDate"), "yyyyMMdd"), Format(Session("ExtEndDate"), "yyyyMMdd"))
    '    Dim i As Integer
    '    'dr.Read()
    '    Dim cSession, boxTotal, admsTotal As Integer
    '    cSession = 0
    '    boxTotal = 0
    '    admsTotal = 0
    '    For i = 0 To grdBoxOffice.Rows.Count - 1
    '        If i = 0 Then
    '            'Dim mSound As String
    '            cSession = cSession + 2
    '            boxTotal = boxTotal + CDbl(grdBoxOffice.Rows(i).Cells(6).Text)
    '            admsTotal = admsTotal + CDbl(grdBoxOffice.Rows(i).Cells(7).Text)
    '            myStr1 = Chr(34) & grdBoxOffice.Rows(i).Cells(1).Text.ToString & Chr(34) & ","
    '            myStr2 = Chr(34) & grdBoxOffice.Rows(i).Cells(6).Text.ToString & Chr(34) & "," & Chr(34) & grdBoxOffice.Rows(i).Cells(7).Text.ToString & Chr(34) & ","
    '            'str.Append(Chr(34) & grdBoxOffice.Rows(i).Cells(1).Text.ToString & Chr(34) & "," & Chr(34) & mSound & Chr(34) & "," _
    '            '& Chr(34) & grdBoxOffice.Rows(i).Cells(6).Text.ToString & Chr(34) & "," & Chr(34) & grdBoxOffice.Rows(i).Cells(7).Text.ToString & Chr(34) & ",")
    '        Else
    '            If grdBoxOffice.Rows(i).Cells(1).Text = grdBoxOffice.Rows(i - 1).Cells(1).Text Then
    '                cSession = cSession + 2
    '                boxTotal = boxTotal + CDbl(grdBoxOffice.Rows(i).Cells(6).Text)
    '                admsTotal = admsTotal + CDbl(grdBoxOffice.Rows(i).Cells(7).Text)
    '                myStr2 = myStr2 & Chr(34) & grdBoxOffice.Rows(i).Cells(6).Text.ToString & Chr(34) & "," & Chr(34) & grdBoxOffice.Rows(i).Cells(7).Text.ToString & Chr(34) & ","
    '                'str.Append(Chr(34) & grdBoxOffice.Rows(i).Cells(6).Text.ToString & Chr(34) & "," & Chr(34) & grdBoxOffice.Rows(i).Cells(7).Text.ToString & Chr(34) & ",")

    '                If grdBoxOffice.Rows(i).Cells(4).Text.ToString = grdBoxOffice.Rows(i - 1).Cells(4).Text.ToString Then
    '                    If grdBoxOffice.Rows(i).Cells(4).Text.ToString = "พากย์ไทย" Then
    '                        myStr3 = "T,"
    '                    Else
    '                        myStr3 = "E,"
    '                    End If

    '                Else
    '                    myStr3 = "E/T,"
    '                End If

    '                If i = grdBoxOffice.Rows.Count Then
    '                    Dim j As Integer
    '                    If cSession < 16 Then
    '                        For j = 1 To 16 - cSession
    '                            myStr2 = myStr2 & ","
    '                            'str.Append(",")
    '                        Next
    '                    End If
    '                    myStr2 = myStr2 & Chr(34) & boxTotal & Chr(34) & "," & Chr(34) & admsTotal & Chr(34) & "," & grdBoxOffice.Rows(i).Cells(8).Text.ToString & ","
    '                    'str.Append(Chr(34) & boxTotal & Chr(34) & "," & Chr(34) & admsTotal & Chr(34) & "," & grdBoxOffice.Rows(i).Cells(8).Text.ToString & ",")
    '                    boxTotal = 0
    '                    admsTotal = 0
    '                    cSession = 0
    '                    'myStr2 = ""
    '                    'myStr1 = ""
    '                    'myStr3 = ""
    '                End If

    '            Else
    '                Dim n As Integer
    '                If cSession < 16 Then
    '                    For n = 1 To 16 - cSession
    '                        myStr2 = myStr2 & ","
    '                        'str.Append(",")
    '                    Next
    '                End If
    '                myStr2 = myStr2 & Chr(34) & boxTotal & Chr(34) & "," & Chr(34) & admsTotal & Chr(34) & "," & grdBoxOffice.Rows(i).Cells(8).Text.ToString & ","
    '                str.Append(myStr1 & myStr3 & myStr2)
    '                str.AppendLine()
    '                boxTotal = 0
    '                admsTotal = 0
    '                cSession = 0
    '                myStr1 = ""
    '                myStr2 = ""
    '                myStr3 = ""

    '                cSession = cSession + 2
    '                boxTotal = boxTotal + CDbl(grdBoxOffice.Rows(i).Cells(6).Text)
    '                admsTotal = admsTotal + CDbl(grdBoxOffice.Rows(i).Cells(7).Text)
    '                If grdBoxOffice.Rows(i).Cells(4).Text.ToString = "พากย์ไทย" Then
    '                    myStr3 = "T,"
    '                Else
    '                    myStr3 = "E,"
    '                End If
    '                myStr1 = Chr(34) & grdBoxOffice.Rows(i).Cells(1).Text.ToString & Chr(34) & ","
    '                myStr2 = Chr(34) & grdBoxOffice.Rows(i).Cells(6).Text.ToString & Chr(34) & "," & Chr(34) & grdBoxOffice.Rows(i).Cells(7).Text.ToString & Chr(34) & ","
    '            End If
    '        End If
    '    Next i

    '    Response.Clear()
    '    Response.AddHeader("content-disposition", "attachment;filename=MoviesTitle.csv")
    '    Response.Charset = ""
    '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '    Response.ContentType = "application/vnd.csv"
    '    Dim stringWrite As New System.IO.StringWriter()
    '    Dim htmlWrite As New HtmlTextWriter(stringWrite)
    '    Response.Write(str.ToString())
    '    Response.End()
    'End Sub



    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=CTBV_Daily_Box_Office.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        tblRpt.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()

    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptParam.aspx")
    End Sub
End Class