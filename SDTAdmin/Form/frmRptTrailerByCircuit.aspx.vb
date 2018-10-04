Imports Web.Data
Partial Public Class frmRptTrailerByCircuit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        getDataRpt()


    End Sub

    Sub getDataRpt()

        While (tbl.Rows.Count > 4)
            tbl.Rows.RemoveAt(4)
        End While


        Dim cDB As New cDatabase
        tbl.Rows(0).Cells(0).Text = "คลมบย"
        tbl.Rows(2).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString
        Dim wkSetupNo As String = Session("rptSetupNo").ToString
        Dim wkSQL As String

        'wkSQL = " SELECT     TOP (100) PERCENT trailer.setup_no, c.circuit_id, c.circuit_name, trailer.setup_movie_id AS movie_id, trailer.setup_movie_title AS MovieName, "
        'wkSQL += vbNewLine + " trailer.movie_background_color, trailer.movie_font_color, trailer.setup_movie_strdate"
        'wkSQL += vbNewLine + " ,(select count(*) seat_amount"
        'wkSQL += vbNewLine + " from tblTheaterSub inner join tblTheater "
        'wkSQL += vbNewLine + " on tblTheater.theater_id = tblTheaterSub.theater_id"
        'wkSQL += vbNewLine + " where(tblTheater.circuit_id = c.circuit_id) and status_flag ='Y') as seat_amount"
        'wkSQL += vbNewLine + " , ISNULL((SELECT     COUNT(movie_id) AS Expr1"
        'wkSQL += vbNewLine + " FROM         (SELECT DISTINCT ch.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id"
        'wkSQL += vbNewLine + " FROM          dbo.tblTrailer_Master AS tm LEFT OUTER JOIN"
        'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no LEFT OUTER JOIN"
        'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Hdr AS ch ON cd.collection_no = ch.collection_no LEFT OUTER JOIN"
        'wkSQL += vbNewLine + " dbo.tblMovie AS m ON cd.movie_id = m.movie_id"
        'wkSQL += vbNewLine + "    WHERE   (cd.ref_setup_no = '" + wkSetupNo + "')) AS col"
        'wkSQL += vbNewLine + " WHERE     (movie_id = trailer.setup_movie_id) AND (circuit_id = c.circuit_id)), 0) AS CountMovie"
        'wkSQL += vbNewLine + " FROM         dbo.tblCircuit AS c CROSS JOIN"
        'wkSQL += vbNewLine + " (SELECT     sd.setup_no, sd.movie_id AS setup_movie_id, sd.movie_background_color, sd.movie_font_color, MIN(m.movie_nameen) AS setup_movie_title, "
        'wkSQL += vbNewLine + " m.movie_strdate AS setup_movie_strdate"
        'wkSQL += vbNewLine + " FROM          dbo.tblTrailer_Setup_Dtl AS sd INNER JOIN"
        'wkSQL += vbNewLine + " dbo.tblMovie AS m ON sd.movie_id = m.movie_id"
        'wkSQL += vbNewLine + " WHERE      (sd.setup_no = '" + wkSetupNo + "')"
        'wkSQL += vbNewLine + " GROUP BY sd.setup_no, sd.movie_id, m.movie_strdate, sd.movie_background_color, sd.movie_font_color) AS trailer"
        'wkSQL += vbNewLine + " WHERE (c.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
        'wkSQL += vbNewLine + " ORDER BY c.circuit_name, trailer.setup_movie_strdate, movie_id"

        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQL = " SELECT trailer.setup_no, c.circuit_id, c.circuit_name, trailer.setup_movie_id AS movie_id, trailer.setup_movie_title AS MovieName, "
        wkSQL += vbNewLine + " trailer.movie_background_color, trailer.movie_font_color, trailer.setup_movie_strdate,"
        wkSQL += vbNewLine + " (select count(*) seat_amount"
        wkSQL += vbNewLine + " from tblTheaterSub "
        wkSQL += vbNewLine + " inner join tblTheater on tblTheater.theater_id = tblTheaterSub.theater_id"
        wkSQL += vbNewLine + " where(tblTheater.circuit_id = c.circuit_id) "
        wkSQL += vbNewLine + " and tblTheaterSub.status_flag ='Y'"
        wkSQL += vbNewLine + " and tblTheater.theater_status = 'Enabled'"
        wkSQL += vbNewLine + " ) as seat_amount, "
        wkSQL += vbNewLine + " ISNULL("
        wkSQL += vbNewLine + " (	 SELECT COUNT(col.movie_id) AS Expr1"
        wkSQL += vbNewLine + "  FROM "
        wkSQL += vbNewLine + "  ("
        wkSQL += vbNewLine + " 			 SELECT DISTINCT t.circuit_id, ch.theater_id, cd.collection_no, tm.theatersub_id, cd.movie_id"
        wkSQL += vbNewLine + " 			 FROM dbo.tblTrailer_Master AS tm "
        wkSQL += vbNewLine + " 			 left join dbo.tblTrailer_Collection_Dtl AS cd ON tm.collection_no = cd.collection_no "
        wkSQL += vbNewLine + " 			 left join dbo.tblTrailer_Collection_Hdr AS ch ON cd.collection_no = ch.collection_no "
        wkSQL += vbNewLine + " 			 left join dbo.tblMovie AS m ON cd.movie_id = m.movie_id"
        wkSQL += vbNewLine + " 			 left join tblTheater t on tm.theater_id = t.theater_id"
        wkSQL += vbNewLine + " 			 left join tblCircuit cc ON t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " 			 WHERE (cd.ref_setup_no = '" + wkSetupNo + "')"
        'wkSQL += vbNewLine + "           and t.theater_status = 'Enabled'"
        wkSQL += vbNewLine + "   ) AS col"
        wkSQL += vbNewLine + "  WHERE  (col.movie_id = trailer.setup_movie_id) "
        wkSQL += vbNewLine + "  AND (col.circuit_id = c.circuit_id)"
        wkSQL += vbNewLine + " ), 0) AS CountMovie"
        wkSQL += vbNewLine + " FROM dbo.tblCircuit c,"
        wkSQL += vbNewLine + " (SELECT sd.setup_no, sd.movie_id AS setup_movie_id, sd.movie_background_color, sd.movie_font_color, "
        wkSQL += vbNewLine + " MIN(m.movie_nameen) AS setup_movie_title, m.movie_strdate AS setup_movie_strdate"
        wkSQL += vbNewLine + " FROM dbo.tblTrailer_Setup_Dtl AS sd "
        wkSQL += vbNewLine + " LEFT JOIN dbo.tblMovie m ON sd.movie_id = m.movie_id"
        wkSQL += vbNewLine + " WHERE  (sd.setup_no = '" + wkSetupNo + "')"
        wkSQL += vbNewLine + " GROUP BY sd.setup_no, sd.movie_id, m.movie_strdate, sd.movie_background_color, sd.movie_font_color"
        wkSQL += vbNewLine + " ) AS trailer"
        wkSQL += vbNewLine + " WHERE (c.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
        wkSQL += vbNewLine + " ORDER BY c.circuit_name, trailer.setup_movie_strdate, movie_id"
        '--- End by Muay 2010-06-09 --------------------------------------------


        Dim dr As IDataReader = cDB.GetDataAll(wkSQL)
        Dim checkRow As Integer = 0
        Dim rowCount As Integer = 0
        Dim wkCircuitID As String = ""
        Dim arrMovie As New ArrayList
        Dim wkChkCircuitID As String = ""
        Dim intCountRowMovie As Integer = 0
        While (dr.Read())

            If wkChkCircuitID = dr("circuit_id").ToString() Then
                intCountRowMovie = intCountRowMovie + 1
            Else
                intCountRowMovie = 1
                wkChkCircuitID = dr("circuit_id").ToString()
            End If
            'ขีดเส้นใต้เมื่อขึ้น Release Date ใหม่
            Dim tblSumRow As New TableRow()

            If (ViewState("StartDate") Is Nothing) Then
                ViewState("StartDate") = Convert.ToString(dr("setup_movie_strdate")).Trim()
            Else
                If Convert.ToString(ViewState("StartDate")).Trim() <> Convert.ToString(dr("setup_movie_strdate")).Trim() Then
                    tblSumRow.Cells.Add(New TableCell)
                    tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    tblSumRow.Cells(0).Height = 2
                    tblSumRow.Cells(0).ColumnSpan = 4
                    tblSumRow.Cells(0).BackColor = Color.FromName("#aaaaaa")
                    tbl.Rows.Add(tblSumRow)
                    ViewState("StartDate") = Convert.ToString(dr("setup_movie_strdate")).Trim()
                End If
            End If


            Dim detailsRow As New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 12
            Dim HeadCircuitRow As New TableRow()
            HeadCircuitRow.HorizontalAlign = HorizontalAlign.Left
            HeadCircuitRow.Font.Name = "Tahoma"
            HeadCircuitRow.Font.Size = 12
            HeadCircuitRow.Width = 600
            If checkRow = 0 Then
                checkRow = checkRow + 1
                wkCircuitID = dr("circuit_name")
                rowCount = 0
                HeadCircuitRow.Cells.Add(New TableCell)
                HeadCircuitRow.Cells(0).ColumnSpan = 2
                HeadCircuitRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                HeadCircuitRow.Cells(0).Font.Bold = True
                HeadCircuitRow.Cells(0).Text = "กขค"
                HeadCircuitRow.Cells(0).Text = wkCircuitID
                HeadCircuitRow.Cells(0).Height = 25
                HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                HeadCircuitRow.Cells.Add(New TableCell)
                HeadCircuitRow.Cells(1).BackColor = Color.FromName("#5D7B9D")
                HeadCircuitRow.Cells.Add(New TableCell)
                HeadCircuitRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
                tbl.Rows.Add(HeadCircuitRow)

                rowCount = rowCount + 1
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(0).Text = rowCount.ToString
                detailsRow.Cells(0).Width = 70

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(1).Text = dr("MovieName").ToString

                Dim strBgCode As String = Convert.ToString(dr("movie_background_color")).Trim()
                Dim strFontCode As String = Convert.ToString(dr("movie_font_color")).Trim()
                If (strBgCode <> "") Then
                    detailsRow.Cells(1).BackColor = System.Drawing.Color.FromName(strBgCode)
                Else
                    detailsRow.Cells(1).BackColor = System.Drawing.Color.White
                End If

                If (strFontCode <> "") Then
                    detailsRow.Cells(1).ForeColor = System.Drawing.Color.FromName(strFontCode)
                Else
                    detailsRow.Cells(1).ForeColor = System.Drawing.Color.Black
                End If

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(2).Text = dr("CountMovie").ToString()

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                Dim strPercent As String = "0"
                Try
                    strPercent = ((Convert.ToDecimal(detailsRow.Cells(2).Text) / Convert.ToDecimal(dr("seat_amount"))) * Convert.ToDecimal("100.0")).ToString("0.0")
                    detailsRow.Cells(3).Text = strPercent
                Catch ex As Exception
                    strPercent = "0"
                    detailsRow.Cells(3).Text = "0.0"
                End Try

                If strBgCode.Trim() = "" Then
                    strBgCode = "#FFFFFF"
                End If
                If strFontCode.Trim() = "" Then
                    strFontCode = "#000000"
                End If
                Dim strArr As String = dr("circuit_name").ToString() + "*" _
                + dr("MovieName").ToString() + "*" + strBgCode + "*" + strFontCode + "*" _
                + dr("CountMovie").ToString() + "*" + strPercent + "*" + Convert.ToString(dr("setup_movie_strdate")).Trim()
                arrMovie.Add(strArr)

                tbl.Rows.Add(detailsRow)
            Else
                If wkCircuitID = dr("circuit_name") Then
                    rowCount = rowCount + 1
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(0).Text = rowCount.ToString
                    detailsRow.Cells(0).Width = 70

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(1).Text = dr("MovieName").ToString

                    Dim strBgCode As String = Convert.ToString(dr("movie_background_color")).Trim()
                    Dim strFontCode As String = Convert.ToString(dr("movie_font_color")).Trim()
                    If (strBgCode <> "") Then
                        detailsRow.Cells(1).BackColor = System.Drawing.Color.FromName(strBgCode)
                    Else
                        detailsRow.Cells(1).BackColor = System.Drawing.Color.White
                    End If

                    If (strFontCode <> "") Then
                        detailsRow.Cells(1).ForeColor = System.Drawing.Color.FromName(strFontCode)
                    Else
                        detailsRow.Cells(1).ForeColor = System.Drawing.Color.Black
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = dr("CountMovie").ToString

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    Dim strPercent As String = "0"
                    Try
                        strPercent = ((Convert.ToDecimal(detailsRow.Cells(2).Text) / Convert.ToDecimal(dr("seat_amount"))) * Convert.ToDecimal("100.0")).ToString("0.0")
                        detailsRow.Cells(3).Text = strPercent
                    Catch ex As Exception
                        strPercent = "0"
                        detailsRow.Cells(3).Text = "0.00"
                    End Try

                    If strBgCode.Trim() = "" Then
                        strBgCode = "#FFFFFF"
                    End If
                    If strFontCode.Trim() = "" Then
                        strFontCode = "#000000"
                    End If
                    Dim strArr As String = dr("circuit_name").ToString() + "*" + dr("MovieName").ToString() + "*" + strBgCode + "*" + strFontCode + "*" + dr("CountMovie").ToString() + "*" + strPercent + "*" + Convert.ToString(dr("setup_movie_strdate")).Trim()
                    arrMovie.Add(strArr)

                    tbl.Rows.Add(detailsRow)
                Else
                    'เก็บค่าเพิ่มเช็ค Release Date เพื่อขีดเส้นใต้
                    ViewState("StartDate") = Convert.ToString(dr("setup_movie_strdate")).Trim()

                    wkCircuitID = dr("circuit_name")
                    rowCount = 0

                    HeadCircuitRow.Cells.Add(New TableCell)
                    HeadCircuitRow.Cells(0).ColumnSpan = 2
                    HeadCircuitRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    HeadCircuitRow.Cells(0).Font.Bold = True
                    HeadCircuitRow.Cells(0).Text = "กขค"
                    HeadCircuitRow.Cells(0).Text = wkCircuitID
                    HeadCircuitRow.Cells(0).Height = 25
                    HeadCircuitRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                    HeadCircuitRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                    HeadCircuitRow.Cells.Add(New TableCell)
                    HeadCircuitRow.Cells(1).BackColor = Color.FromName("#5D7B9D")
                    HeadCircuitRow.Cells.Add(New TableCell)
                    HeadCircuitRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
                    tbl.Rows.Add(HeadCircuitRow)

                    rowCount = rowCount + 1
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(0).Text = rowCount.ToString
                    detailsRow.Cells(0).Width = 70

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
                    detailsRow.Cells(1).Text = dr("MovieName").ToString

                    Dim strBgCode As String = Convert.ToString(dr("movie_background_color")).Trim()
                    Dim strFontCode As String = Convert.ToString(dr("movie_font_color")).Trim()
                    If (strBgCode <> "") Then
                        detailsRow.Cells(1).BackColor = System.Drawing.Color.FromName(strBgCode)
                    Else
                        detailsRow.Cells(1).BackColor = System.Drawing.Color.White
                    End If

                    If (strFontCode <> "") Then
                        detailsRow.Cells(1).ForeColor = System.Drawing.Color.FromName(strFontCode)
                    Else
                        detailsRow.Cells(1).ForeColor = System.Drawing.Color.Black
                    End If

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                    detailsRow.Cells(2).Text = dr("CountMovie").ToString

                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                    Dim strPercent As String = "0"
                    Try
                        strPercent = ((Convert.ToDecimal(detailsRow.Cells(2).Text) / Convert.ToDecimal(dr("seat_amount"))) * Convert.ToDecimal("100.0")).ToString("0.0")
                        detailsRow.Cells(3).Text = strPercent
                    Catch ex As Exception
                        strPercent = "0"
                        detailsRow.Cells(3).Text = "0.0"
                    End Try

                    If strBgCode.Trim() = "" Then
                        strBgCode = "#FFFFFF"
                    End If
                    If strFontCode.Trim() = "" Then
                        strFontCode = "#000000"
                    End If
                    Dim strArr As String = dr("circuit_name").ToString() + "*" + dr("MovieName").ToString() + "*" + strBgCode + "*" + strFontCode + "*" + dr("CountMovie").ToString() + "*" + strPercent + "*" + Convert.ToString(dr("setup_movie_strdate")).Trim()
                    arrMovie.Add(strArr)

                    tbl.Rows.Add(detailsRow)
                End If
            End If
        End While
        dr.Close()

        'arrMovie.Add(dr("circuit_name").ToString() + "*" + _
        '                dr("MovieName").ToString() + "*" + _
        '               dr("movie_background_color").ToString().Trim() + "*" + _
        '               dr("movie_font_color").ToString().Trim() + "*" + _
        '               dr("CountMovie").ToString() + "*" + strPercent)

        Dim arrTotalMovie As New ArrayList()
        Dim cntCircuitCompute As Integer = 0
        If Not arrMovie.Count() = Nothing Then
            Dim decCountNow As Decimal = 0
            Dim decPercentNow As Decimal = 0
            Dim decSumCount As Decimal = 0
            Dim decSumPercent As Decimal = 0

            For i As Integer = 0 To arrMovie.Count - 1 'intCountRowMovie '
                If i = 0 Then
                    cntCircuitCompute = 1
                Else
                    If arrMovie.Item(i - 1).ToString().Split("*")(0) <> arrMovie.Item(i).ToString().Split("*")(0) Then
                        cntCircuitCompute = cntCircuitCompute + 1
                    End If
                End If

                If i < intCountRowMovie Then
                    arrTotalMovie.Add(arrMovie.Item(i).ToString().Split("*")(1) + "*" + arrMovie.Item(i).ToString().Split("*")(2) + "*" + arrMovie.Item(i).ToString().Split("*")(3) + "*" + arrMovie.Item(i).ToString().Split("*")(4) + "*" + arrMovie.Item(i).ToString().Split("*")(5) + "*" + arrMovie.Item(i).ToString().Split("*")(6))
                Else
                    For j As Integer = 0 To arrTotalMovie.Count - 1
                        If arrTotalMovie.Item(j).ToString().Split("*")(0) = arrMovie.Item(i).ToString().Split("*")(1) Then
                            decCountNow = Convert.ToDecimal(arrMovie.Item(i).ToString().Split("*")(4))
                            decPercentNow = Convert.ToDecimal(arrMovie.Item(i).ToString().Split("*")(5))
                            decSumCount = Convert.ToDecimal(arrTotalMovie.Item(j).ToString().Split("*")(3))
                            decSumPercent = Convert.ToDecimal(arrTotalMovie.Item(j).ToString().Split("*")(4))
                            decSumCount = decSumCount + decCountNow
                            decSumPercent = decSumPercent + decPercentNow

                            arrTotalMovie.Item(j) = arrTotalMovie.Item(j).ToString().Split("*")(0) + "*" + arrTotalMovie.Item(j).ToString().Split("*")(1) + "*" + arrTotalMovie.Item(j).ToString().Split("*")(2) + "*" + decSumCount.ToString() + "*" + decSumPercent.ToString() + "*" + arrMovie.Item(j).ToString().Split("*")(6)
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        'arrTotalMovie.Add(dr("MovieName").ToString() + "*" + _
        '               dr("movie_background_color").ToString().Trim() + "*" + _
        '               dr("movie_font_color").ToString().Trim() + "*" + _
        '               dr("CountMovie").ToString() + "*" + strPercent)

        ' ''--start Total
        checkRow = 0
        ViewState("StartDate") = Nothing
        For k As Integer = 0 To arrTotalMovie.Count - 1
            'ขีดเส้นใต้เมื่อขึ้น Release Date ใหม่
            Dim tblSumRowTotal As New TableRow()

            If (ViewState("StartDate") Is Nothing) Then
                ViewState("StartDate") = arrTotalMovie.Item(k).ToString().Split("*")(5)
            Else
                If Convert.ToString(ViewState("StartDate")).Trim() <> arrTotalMovie.Item(k).ToString().Split("*")(5) Then
                    tblSumRowTotal.Cells.Add(New TableCell)
                    tblSumRowTotal.Cells(0).HorizontalAlign = HorizontalAlign.Center
                    tblSumRowTotal.Cells(0).Height = 2
                    tblSumRowTotal.Cells(0).ColumnSpan = 4
                    tblSumRowTotal.Cells(0).BackColor = Color.FromName("#aaaaaa")
                    tbl.Rows.Add(tblSumRowTotal)
                    ViewState("StartDate") = arrTotalMovie.Item(k).ToString().Split("*")(5)
                End If
            End If
 

            Dim detailsRowTotal As New TableRow()
            detailsRowTotal.HorizontalAlign = HorizontalAlign.Center
            detailsRowTotal.Font.Name = "Tahoma"
            detailsRowTotal.Font.Size = 12
            Dim HeadCircuitRowTotal As New TableRow()
            HeadCircuitRowTotal.HorizontalAlign = HorizontalAlign.Left
            HeadCircuitRowTotal.Font.Name = "Tahoma"
            HeadCircuitRowTotal.Font.Size = 12
            HeadCircuitRowTotal.Width = 600
            If checkRow = 0 Then
                checkRow = checkRow + 1
                rowCount = 0
                HeadCircuitRowTotal.Cells.Add(New TableCell)
                HeadCircuitRowTotal.Cells(0).ColumnSpan = 2
                HeadCircuitRowTotal.Cells(0).HorizontalAlign = HorizontalAlign.Center
                HeadCircuitRowTotal.Cells(0).Font.Bold = True
                HeadCircuitRowTotal.Cells(0).Text = "กขค"
                HeadCircuitRowTotal.Cells(0).Text = "TOTAL"
                HeadCircuitRowTotal.Cells(0).Height = 25
                HeadCircuitRowTotal.Cells(0).BackColor = Color.FromName("#5D7B9D")
                HeadCircuitRowTotal.Cells(0).ForeColor = Color.FromName("#ffffff")
                HeadCircuitRowTotal.Cells.Add(New TableCell)
                HeadCircuitRowTotal.Cells(1).BackColor = Color.FromName("#5D7B9D")
                HeadCircuitRowTotal.Cells.Add(New TableCell)
                HeadCircuitRowTotal.Cells(2).BackColor = Color.FromName("#5D7B9D")
                tbl.Rows.Add(HeadCircuitRowTotal)

                rowCount = rowCount + 1
                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(0).Text = rowCount.ToString
                detailsRowTotal.Cells(0).Width = 70

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Right
                detailsRowTotal.Cells(1).Text = arrTotalMovie.Item(k).ToString().Split("*")(0) 'dr("MovieName").ToString

                Dim strBgCode As String = arrTotalMovie.Item(k).ToString().Split("*")(1)
                Dim strFontCode As String = arrTotalMovie.Item(k).ToString().Split("*")(2)
                If (strBgCode <> "") Then
                    detailsRowTotal.Cells(1).BackColor = System.Drawing.Color.FromName(strBgCode)
                Else
                    detailsRowTotal.Cells(1).BackColor = System.Drawing.Color.White
                End If

                If (strFontCode <> "") Then
                    detailsRowTotal.Cells(1).ForeColor = System.Drawing.Color.FromName(strFontCode)
                Else
                    detailsRowTotal.Cells(1).ForeColor = System.Drawing.Color.Black
                End If

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(2).Text = arrTotalMovie.Item(k).ToString().Split("*")(3)

                Dim decPercentShow As Decimal = 0
                decPercentShow = arrTotalMovie.Item(k).ToString().Split("*")(4) / cntCircuitCompute


                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Center
                Try
                    detailsRowTotal.Cells(3).Text = Format(decPercentShow, "#,##0.0") ' ((Convert.ToDecimal(detailsRowTotal.Cells(2).Text) / Convert.ToDecimal(dr("seat_amount"))) * Convert.ToDecimal("100.0")).ToString("0.0")
                Catch ex As Exception
                    detailsRowTotal.Cells(3).Text = "0.0"
                End Try

                tbl.Rows.Add(detailsRowTotal)
            Else

                rowCount = rowCount + 1
                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(0).Text = rowCount.ToString
                detailsRowTotal.Cells(0).Width = 70

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Right
                detailsRowTotal.Cells(1).Text = arrTotalMovie.Item(k).ToString().Split("*")(0)

                Dim strBgCode As String = arrTotalMovie.Item(k).ToString().Split("*")(1)
                Dim strFontCode As String = arrTotalMovie.Item(k).ToString().Split("*")(2)

                If (strBgCode <> "") Then
                    detailsRowTotal.Cells(1).BackColor = System.Drawing.Color.FromName(strBgCode)
                Else
                    detailsRowTotal.Cells(1).BackColor = System.Drawing.Color.White
                End If

                If (strFontCode <> "") Then
                    detailsRowTotal.Cells(1).ForeColor = System.Drawing.Color.FromName(strFontCode)
                Else
                    detailsRowTotal.Cells(1).ForeColor = System.Drawing.Color.Black
                End If

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRowTotal.Cells(2).Text = arrTotalMovie.Item(k).ToString().Split("*")(3)

                Dim decPercentShow As Decimal = 0
                decPercentShow = arrTotalMovie.Item(k).ToString().Split("*")(4) / cntCircuitCompute

                detailsRowTotal.Cells.Add(New TableCell)
                detailsRowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Center
                Try
                    detailsRowTotal.Cells(3).Text = Format(decPercentShow, "#,##0.0") ' ((Convert.ToDecimal(detailsRowTotal.Cells(2).Text) / Convert.ToDecimal(dr("seat_amount"))) * Convert.ToDecimal("100.0")).ToString("0.0")
                Catch ex As Exception
                    detailsRowTotal.Cells(3).Text = "0.00"
                End Try

                tbl.Rows.Add(detailsRowTotal)

            End If
        Next
        
        ' ''--end Total



        ViewState("StartDate") = Nothing

    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByCircuitParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TrailerByCircuit.xls")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        getDataRpt()
        tbl.RenderControl(htmlWrite)
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class