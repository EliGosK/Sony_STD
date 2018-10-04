Imports Web.Data
Imports System.Web.UI.Control

Partial Public Class frmRptTrailerByLocation
    Inherits System.Web.UI.Page

    'Session("rptSetupNo") = SetupPopup1.SetupNo
    'Session("rptDate") = SetupPopup1.PeriodDate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        getDataRpt()
    End Sub

    ''Sub getDataRpt()

    ''    While (tblTrailer.Rows.Count > 4)
    ''        tblTrailer.Rows.RemoveAt(4)
    ''    End While

    ''    Dim cDB As New cDatabase
    ''    tblTrailer.Rows(0).Cells(0).Text = "โคลัมเบีย"
    ''    tblTrailer.Rows(1).Cells(0).Text = "TRAILER LIST BY LOCATION"
    ''    tblTrailer.Rows(2).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString()
    ''    tblTrailer.Rows(3).Cells(0).Text = DateTime.Today.ToString("dd dddd MMMM yyyy")


    ''    'Head
    ''    Dim wkSQL As String = ""
    ''    'wkSQL = " Select DISTINCT"
    ''    'wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl.setup_no, dbo.tblTrailer_Master.circuit_id, dbo.tblTrailer_Master.theater_id, dbo.tblCircuit.circuit_name, "
    ''    'wkSQL += vbNewLine + " dbo.tblTheater.theater_name"
    ''    'wkSQL += vbNewLine + " FROM dbo.tblTrailer_Master INNER JOIN"
    ''    'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Dtl ON dbo.tblTrailer_Master.collection_no = dbo.tblTrailer_Collection_Dtl.collection_no INNER JOIN"
    ''    'wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl ON dbo.tblTrailer_Collection_Dtl.movie_id = dbo.tblTrailer_Setup_Dtl.movie_id INNER JOIN"
    ''    'wkSQL += vbNewLine + " dbo.tblCircuit ON dbo.tblTrailer_Master.circuit_id = dbo.tblCircuit.circuit_id INNER JOIN"
    ''    'wkSQL += vbNewLine + " dbo.tblTheater ON dbo.tblTrailer_Master.theater_id = dbo.tblTheater.theater_id"
    ''    'wkSQL += vbNewLine + " WHERE     (dbo.tblTrailer_Setup_Dtl.setup_no = '" + Convert.ToString(Session("rptSetupNo")) + "')"
    ''    'wkSQL += vbNewLine + " AND     (dbo.tblTrailer_Master.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
    ''    'wkSQL += vbNewLine + " ORDER BY dbo.tblCircuit.circuit_name, dbo.tblTheater.theater_name"


    ''    '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
    ''    wkSQL = " Select DISTINCT"
    ''    wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl.setup_no, dbo.tblTheater.circuit_id, dbo.tblTrailer_Master.theater_id, dbo.tblCircuit.circuit_name, "
    ''    wkSQL += vbNewLine + " dbo.tblTheater.theater_name"
    ''    wkSQL += vbNewLine + " FROM dbo.tblTrailer_Master "
    ''    wkSQL += vbNewLine + " LEFT JOIN dbo.tblTrailer_Collection_Dtl ON dbo.tblTrailer_Master.collection_no = dbo.tblTrailer_Collection_Dtl.collection_no "
    ''    wkSQL += vbNewLine + " LEFT JOIN dbo.tblTrailer_Setup_Dtl ON dbo.tblTrailer_Collection_Dtl.movie_id = dbo.tblTrailer_Setup_Dtl.movie_id "
    ''    wkSQL += vbNewLine + " LEFT JOIN dbo.tblTheater ON dbo.tblTrailer_Master.theater_id = dbo.tblTheater.theater_id"
    ''    wkSQL += vbNewLine + " LEFT JOIN dbo.tblCircuit ON dbo.tblTheater.circuit_id = dbo.tblCircuit.circuit_id "
    ''    wkSQL += vbNewLine + " WHERE dbo.tblTrailer_Setup_Dtl.setup_no = '" + Convert.ToString(Session("rptSetupNo")) + "'"
    ''    wkSQL += vbNewLine + " AND (dbo.tblTheater.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
    ''    wkSQL += vbNewLine + " AND tblTheater.theater_status = 'Enabled'"
    ''    wkSQL += vbNewLine + " ORDER BY dbo.tblCircuit.circuit_name, dbo.tblTheater.theater_name"
    ''    '--- End by Muay 2010-06-09 --------------------------------------------


    ''    ''''''''''''''''''''Query By Circuit,Theater'''''''''''''''''''''''
    ''    Dim dr1 As IDataReader = cDB.GetDataAll(wkSQL)
    ''    Dim htbCircuit As New Hashtable()

    ''    'เก็บค่า sum where circuit theater moive
    ''    Dim htbSumMovie As New Hashtable()

    ''    While (dr1.Read())
    ''        'Head
    ''        Dim TotalRow1 As New TableRow()
    ''        TotalRow1.HorizontalAlign = HorizontalAlign.Left

    ''        If (htbCircuit(Convert.ToString(dr1("circuit_name"))) Is Nothing) Then
    ''            TotalRow1.BackColor = Color.DarkGray
    ''            TotalRow1.Cells.Add(New TableCell)
    ''            TotalRow1.Cells(0).Font.Bold = True
    ''            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
    ''            TotalRow1.Cells(0).ColumnSpan = 2
    ''            TotalRow1.Cells(0).Font.Size = 12
    ''            TotalRow1.Cells(0).Text = "Circuit : " + Convert.ToString(dr1("circuit_name"))
    ''            tblTrailer.Rows.Add(TotalRow1)
    ''            htbCircuit(Convert.ToString(dr1("circuit_name"))) = "check"
    ''            TotalRow1 = New TableRow()
    ''        End If

    ''        TotalRow1.Cells.Add(New TableCell)
    ''        TotalRow1.BackColor = Color.FromName("#DBEEF3")
    ''        TotalRow1.Cells(0).Font.Bold = True
    ''        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
    ''        TotalRow1.Cells(0).ColumnSpan = 2
    ''        TotalRow1.Cells(0).Font.Size = 10
    ''        TotalRow1.Cells(0).Text = Convert.ToString(dr1("theater_name"))
    ''        tblTrailer.Rows.Add(TotalRow1)

    ''        '''create by nick
    ''        Dim tblT As New Table
    ''        Dim trT As New TableRow()
    ''        trT.Cells.Add(New TableCell)
    ''        trT.BackColor = Color.LightSlateGray
    ''        trT.ForeColor = Color.White
    ''        trT.Cells(0).Font.Bold = True
    ''        trT.Cells(0).HorizontalAlign = HorizontalAlign.Center
    ''        trT.Cells(0).Width = 200
    ''        trT.Cells(0).Text = "Trailers"
    ''        trT.Cells.Add(New TableCell)
    ''        trT.Cells(1).Font.Bold = True
    ''        trT.Cells(1).Width = 50
    ''        trT.Cells(1).HorizontalAlign = HorizontalAlign.Center
    ''        trT.Cells(1).Text = "Amount"
    ''        tblT.Rows.Add(trT)

    ''        TotalRow1 = New TableRow()

    ''        TotalRow1.Cells.Add(New TableCell)
    ''        TotalRow1.BackColor = Color.LightSlateGray
    ''        TotalRow1.Cells(0).Font.Bold = True
    ''        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
    ''        TotalRow1.Cells(0).ColumnSpan = 1
    ''        TotalRow1.Cells(0).Font.Size = 10
    ''        TotalRow1.Cells(0).Controls.Add(tblT)

    ''        TotalRow1.Cells.Add(New TableCell)
    ''        TotalRow1.BackColor = Color.LightSlateGray
    ''        TotalRow1.Cells(1).Font.Bold = True
    ''        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
    ''        TotalRow1.Cells(1).ColumnSpan = 1
    ''        TotalRow1.Cells(1).Font.Size = 10
    ''        TotalRow1.Cells(1).Text = "Screen"
    ''        TotalRow1.Cells(1).ForeColor = Color.White
    ''        tblTrailer.Rows.Add(TotalRow1)
    ''        ''' end by nick


    ''        'wkSQL = " select mas.circuit_id, mas.theater_id, ts.theatersub_id, mas.real_movie_id, mas.real_movie_name, "
    ''        'wkSQL += vbNewLine + " mas.collection_no, mas.seq_no, mas.movie_id, mas.MoviesName, mas.movie_nameen, "
    ''        'wkSQL += vbNewLine + " mas.movie_background_color, mas.movie_font_color"
    ''        'wkSQL += vbNewLine + " from tblTheaterSub ts"
    ''        'wkSQL += vbNewLine + " Left Join"
    ''        'wkSQL += vbNewLine + " ("
    ''        'wkSQL += vbNewLine + " SELECT     dbo.tblTrailer_Master.circuit_id, dbo.tblTrailer_Master.theater_id, dbo.tblTrailer_Master.theatersub_id, "
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Master.real_movie_id,"
    ''        'wkSQL += vbNewLine + " (SELECT     TOP 1 movie_nameen"
    ''        'wkSQL += vbNewLine + " FROM dbo.tblMovie"
    ''        'wkSQL += vbNewLine + " WHERE      (dbo.tblTrailer_Master.real_movie_id = movie_id)) AS real_movie_name, dbo.tblTrailer_Collection_Dtl.collection_no, "
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Dtl.seq_no, tblMovie_1.movie_id, tblMovie_1.movie_nameen + ' / ' + tblMovie_1.movie_nameth AS MoviesName, "
    ''        'wkSQL += vbNewLine + " tblMovie_1.movie_nameen, dbo.tblTrailer_Setup_Dtl.movie_background_color, dbo.tblTrailer_Setup_Dtl.movie_font_color"
    ''        'wkSQL += vbNewLine + " FROM"
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl INNER JOIN"
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Dtl ON dbo.tblTrailer_Setup_Dtl.setup_no = dbo.tblTrailer_Collection_Dtl.ref_setup_no AND "
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl.movie_id = dbo.tblTrailer_Collection_Dtl.movie_id INNER JOIN"
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Collection_Hdr ON dbo.tblTrailer_Collection_Dtl.collection_no = dbo.tblTrailer_Collection_Hdr.collection_no INNER JOIN"
    ''        'wkSQL += vbNewLine + " dbo.tblTrailer_Master ON dbo.tblTrailer_Collection_Hdr.collection_no = dbo.tblTrailer_Master.collection_no INNER JOIN"
    ''        'wkSQL += vbNewLine + " dbo.tblMovie AS tblMovie_1 ON dbo.tblTrailer_Collection_Dtl.movie_id = tblMovie_1.movie_id"
    ''        'wkSQL += vbNewLine + " WHERE     (dbo.tblTrailer_Collection_Dtl.ref_setup_no = '" + Convert.ToString(Session("rptSetupNo")) + "') "
    ''        ''wkSQL += vbNewLine + " AND     (dbo.tblTrailer_Master.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
    ''        'wkSQL += vbNewLine + " AND (dbo.tblTrailer_Master.theater_id =  " + Convert.ToString(dr1("theater_id")) + ") "
    ''        'wkSQL += vbNewLine + " AND (dbo.tblTrailer_Master.confirm_flag = 'Y')"
    ''        'wkSQL += vbNewLine + " ) mas on ts.theatersub_id = mas.theatersub_id"
    ''        'wkSQL += vbNewLine + " where(ts.theater_id =  " + Convert.ToString(dr1("theater_id")) + ")"
    ''        'wkSQL += vbNewLine + " and (mas.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
    ''        'wkSQL += vbNewLine + " and (ts.status_flag = 'Y')"
    ''        'wkSQL += vbNewLine + " ORDER BY ts.theatersub_id, mas.real_movie_name, mas.collection_no, mas.seq_no"

    ''        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
    ''        wkSQL = " select mas.circuit_id, mas.theater_id, ts.theatersub_id, mas.real_movie_id, mas.real_movie_name, "
    ''        wkSQL += vbNewLine + " mas.collection_no, mas.seq_no, mas.movie_id, mas.MoviesName, mas.movie_nameen, "
    ''        wkSQL += vbNewLine + " mas.movie_background_color, mas.movie_font_color"
    ''        wkSQL += vbNewLine + " from tblTheaterSub ts"
    ''        wkSQL += vbNewLine + " Left Join"
    ''        wkSQL += vbNewLine + " ("
    ''        wkSQL += vbNewLine + " 	 SELECT t.circuit_id, dbo.tblTrailer_Master.theater_id, dbo.tblTrailer_Master.theatersub_id, "
    ''        wkSQL += vbNewLine + " 	 dbo.tblTrailer_Master.real_movie_id,"
    ''        wkSQL += vbNewLine + " 	 (SELECT TOP 1 movie_nameen"
    ''        wkSQL += vbNewLine + " 	 FROM dbo.tblMovie"
    ''        wkSQL += vbNewLine + " 	 WHERE dbo.tblTrailer_Master.real_movie_id = movie_id"
    ''        wkSQL += vbNewLine + " 	 ) AS real_movie_name, "
    ''        wkSQL += vbNewLine + " 	 dbo.tblTrailer_Collection_Dtl.collection_no,  dbo.tblTrailer_Collection_Dtl.seq_no, tblMovie_1.movie_id, tblMovie_1.movie_nameen + ' / ' + tblMovie_1.movie_nameth AS MoviesName, "
    ''        wkSQL += vbNewLine + " 	 tblMovie_1.movie_nameen, dbo.tblTrailer_Setup_Dtl.movie_background_color, dbo.tblTrailer_Setup_Dtl.movie_font_color"
    ''        wkSQL += vbNewLine + " 	 FROM dbo.tblTrailer_Setup_Dtl "
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN dbo.tblTrailer_Collection_Dtl ON dbo.tblTrailer_Setup_Dtl.setup_no = dbo.tblTrailer_Collection_Dtl.ref_setup_no "
    ''        wkSQL += vbNewLine + " 	 AND dbo.tblTrailer_Setup_Dtl.movie_id = dbo.tblTrailer_Collection_Dtl.movie_id "
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN dbo.tblTrailer_Collection_Hdr ON dbo.tblTrailer_Collection_Dtl.collection_no = dbo.tblTrailer_Collection_Hdr.collection_no "
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN dbo.tblTrailer_Master ON dbo.tblTrailer_Collection_Hdr.collection_no = dbo.tblTrailer_Master.collection_no "
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN dbo.tblMovie AS tblMovie_1 ON dbo.tblTrailer_Collection_Dtl.movie_id = tblMovie_1.movie_id"
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN dbo.tblTheater t on dbo.tblTrailer_Master.theater_id = t.theater_id"
    ''        wkSQL += vbNewLine + " 	 LEFT JOIN tblCircuit c ON t.circuit_id = c.circuit_id "
    ''        wkSQL += vbNewLine + " 	 WHERE (dbo.tblTrailer_Collection_Dtl.ref_setup_no = '" + Convert.ToString(Session("rptSetupNo")) + "') "
    ''        wkSQL += vbNewLine + " 	 AND (dbo.tblTrailer_Master.theater_id = " + Convert.ToString(dr1("theater_id")) + ") "
    ''        wkSQL += vbNewLine + " 	 AND (dbo.tblTrailer_Master.confirm_flag = 'Y')"
    ''        wkSQL += vbNewLine + " ) mas on ts.theatersub_id = mas.theatersub_id"
    ''        wkSQL += vbNewLine + " where(ts.theater_id = " + Convert.ToString(dr1("theater_id")) + ")"
    ''        wkSQL += vbNewLine + " and (mas.circuit_id = " + Convert.ToString(Session("rptCircuitID")) + " OR " + Convert.ToString(Session("rptCircuitID")) + " is null)"
    ''        wkSQL += vbNewLine + " and (ts.status_flag = 'Y')"
    ''        wkSQL += vbNewLine + " ORDER BY ts.theatersub_id, mas.real_movie_name, mas.collection_no, mas.seq_no"
    ''        '--- End by Muay 2010-06-09 --------------------------------------------


    ''        Dim tblDetail As New Table
    ''        'tblDetail.Width = 500
    ''        Dim drDetail As IDataReader = cDB.GetDataAll(wkSQL)
    ''        Dim i As Integer
    ''        Dim RowCollection As Integer
    ''        i = 1
    ''        RowCollection = 1
    ''        Dim htb As New Hashtable()
    ''        Dim htbGetRowUpdate_RealMovie As New Hashtable()
    ''        Dim RowDetail As New TableRow()
    ''        RowDetail.HorizontalAlign = HorizontalAlign.Left
    ''        While (drDetail.Read())



    ''            If (htb(Convert.ToString(drDetail("theatersub_id")) + "_" + Convert.ToString(drDetail("real_movie_id"))) Is Nothing) Then

    ''                Dim strDup As String = Convert.ToString(drDetail("theatersub_id")) + "_" + Convert.ToString(drDetail("collection_no"))
    ''                If (Not ((htbGetRowUpdate_RealMovie(strDup) Is Nothing))) Then
    ''                    'เมื่อ row นั้นมีการใช้ collection_no ซ้ำให้ต่อไปกับหนังที่มีอยู่เดิม
    ''                    If (tblDetail.Rows(Convert.ToInt32(htbGetRowUpdate_RealMovie(strDup)) - 1).Cells(1).Text.IndexOf(Convert.ToString(drDetail("real_movie_name")).Substring(0, IIf(Convert.ToString(drDetail("real_movie_name")).Length > 10, 10, Convert.ToString(drDetail("real_movie_name")).Length))) < 0) Then
    ''                        tblDetail.Rows(Convert.ToInt32(htbGetRowUpdate_RealMovie(strDup)) - 1).Cells(1).Text += "/" + Convert.ToString(drDetail("real_movie_name")).Substring(0, IIf(Convert.ToString(drDetail("real_movie_name")).Length > 10, 10, Convert.ToString(drDetail("real_movie_name")).Length))
    ''                    End If
    ''                    Continue While
    ''                End If

    ''                RowDetail = New TableRow()
    ''                RowDetail.Cells.Add(New TableCell)
    ''                RowDetail.Cells(0).Width = 80
    ''                RowDetail.Cells(0).Text = "Screen#" + Convert.ToString(drDetail("theatersub_id"))
    ''                RowDetail.Cells(0).Font.Bold = True
    ''                RowDetail.Cells(0).BackColor = Color.FromName("#bbbbbb")

    ''                wkSQL = " SELECT theater_id, theatersub_id, theatersub_normalseat"
    ''                wkSQL += " FROM tblTheaterSub "
    ''                wkSQL += " WHERE(theater_id = " + Convert.ToString(dr1("theater_id")) + ") and (theatersub_id=" + Convert.ToString(drDetail("theatersub_id")) + ")"

    ''                Dim drCurentSeat As IDataReader = cDB.GetDataAll(wkSQL)
    ''                Dim intCurentSeat As Integer = 0
    ''                If (drCurentSeat.Read()) Then
    ''                    If Convert.ToString(drCurentSeat("theatersub_normalseat")) <> "" Then
    ''                        intCurentSeat = Convert.ToInt32(drCurentSeat("theatersub_normalseat"))
    ''                    End If
    ''                End If
    ''                drCurentSeat.Close()

    ''                'เช็คจำนวนที่นั่งว่าเป็นที่ 1 และ 2หรือไม่
    ''                'wkSQL = " select theater_id,theatersub_id,RowNumber"
    ''                'wkSQL += " from("
    ''                'wkSQL += " SELECT     theater_id, theatersub_id, theatersub_normalseat, theatersub_vipseat"
    ''                'wkSQL += " ,ROW_NUMBER() OVER (ORDER BY theatersub_normalseat DESC) RowNumber"
    ''                'wkSQL += " FROM tblTheaterSub"
    ''                'wkSQL += " WHERE(theater_id = " + Convert.ToString(dr1("theater_id")) + ")"
    ''                'wkSQL += " ) AS Temp"
    ''                'wkSQL += " WHERE(theatersub_id = " + Convert.ToString(drDetail("theatersub_id")) + ")"

    ''                If (intCurentSeat <> 0) Then
    ''                    wkSQL = " Select isnull(max_seat_max,0) max_seat_max"
    ''                    wkSQL += vbNewLine + " from"
    ''                    wkSQL += vbNewLine + " ("
    ''                    wkSQL += vbNewLine + " SELECT isnull(max(theatersub_normalseat),0) max_seat_max"
    ''                    wkSQL += vbNewLine + " FROM tblTheaterSub "
    ''                    wkSQL += vbNewLine + " WHERE(theater_id = " + Convert.ToString(dr1("theater_id")) + ")"
    ''                    wkSQL += vbNewLine + " union"
    ''                    wkSQL += vbNewLine + " SELECT isnull(max(theatersub_normalseat),0) max_seat_max"
    ''                    wkSQL += vbNewLine + " FROM tblTheaterSub "
    ''                    wkSQL += vbNewLine + " WHERE(theater_id = " + Convert.ToString(dr1("theater_id")) + ")"
    ''                    wkSQL += vbNewLine + " and theatersub_normalseat not in"
    ''                    wkSQL += vbNewLine + " ( "
    ''                    wkSQL += vbNewLine + " SELECT isnull(max(theatersub_normalseat),0) max_seat_max"
    ''                    wkSQL += vbNewLine + " FROM tblTheaterSub "
    ''                    wkSQL += vbNewLine + " WHERE(theater_id = " + Convert.ToString(dr1("theater_id")) + ")"
    ''                    wkSQL += vbNewLine + " )"
    ''                    wkSQL += vbNewLine + " ) as temp"
    ''                    wkSQL += vbNewLine + " order by max_seat_max DESC"

    ''                    Dim drSeat As IDataReader = cDB.GetDataAll(wkSQL)
    ''                    Dim intRow As Integer = 0
    ''                    While (drSeat.Read())
    ''                        If (Convert.ToString(drSeat("max_seat_max")).Trim() <> "") Then
    ''                            If (intRow = 0) Then
    ''                                If (Convert.ToInt32(drSeat("max_seat_max")) = intCurentSeat) Then
    ''                                    RowDetail.Cells(0).ForeColor = Color.Red
    ''                                    Exit While
    ''                                End If
    ''                            ElseIf (intRow = 1 And intCurentSeat <> 0) Then
    ''                                If (Convert.ToInt32(drSeat("max_seat_max")) = intCurentSeat) Then
    ''                                    RowDetail.Cells(0).ForeColor = Color.Blue
    ''                                    Exit While
    ''                                End If
    ''                            End If
    ''                            intRow += 1
    ''                        End If
    ''                    End While
    ''                    drSeat.Close()

    ''                End If

    ''                RowDetail.Cells.Add(New TableCell)
    ''                RowDetail.Cells(1).Width = 170
    ''                RowDetail.Cells(1).Text = Convert.ToString(drDetail("real_movie_name")).Substring(0, IIf(Convert.ToString(drDetail("real_movie_name")).Length > 10, 10, Convert.ToString(drDetail("real_movie_name")).Length))
    ''                RowDetail.Cells(1).Font.Bold = True
    ''                RowDetail.Cells(1).BackColor = Color.FromName("#dddddd")

    ''                i = 2
    ''                htb(Convert.ToString(drDetail("theatersub_id")) + "_" + Convert.ToString(drDetail("real_movie_id"))) = "check"
    ''                htbGetRowUpdate_RealMovie(Convert.ToString(drDetail("theatersub_id")) + "_" + Convert.ToString(drDetail("collection_no"))) = RowCollection
    ''                RowCollection += 1
    ''            Else

    ''            End If
    ''            RowDetail.Cells.Add(New TableCell)
    ''            RowDetail.Cells(i).Width = 100
    ''            RowDetail.Cells(i).Text = Convert.ToString(drDetail("movie_nameen")).Substring(0, IIf(Convert.ToString(drDetail("movie_nameen")).Length > 10, 10, Convert.ToString(drDetail("movie_nameen")).Length))

    ''            If (Not (drDetail("movie_background_color") Is Nothing)) Then
    ''                If (Convert.ToString(drDetail("movie_background_color")).Trim() <> "") Then
    ''                    RowDetail.Cells(i).BackColor = System.Drawing.Color.FromName(Convert.ToString(drDetail("movie_background_color")))
    ''                    'RowDetail.Cells(i).ForeColor = System.Drawing.Color.FromName(Convert.ToString(drDetail("movie_font_color")))
    ''                Else
    ''                    RowDetail.Cells(i).BackColor = Color.White
    ''                    'RowDetail.Cells(i).ForeColor = Color.Black
    ''                End If
    ''            Else
    ''                RowDetail.Cells(i).BackColor = Color.White
    ''                'RowDetail.Cells(i).ForeColor = Color.Black
    ''            End If

    ''            If (Not (drDetail("movie_font_color") Is Nothing)) Then
    ''                If (Convert.ToString(drDetail("movie_font_color")).Trim() <> "") Then
    ''                    RowDetail.Cells(i).ForeColor = System.Drawing.Color.FromName(Convert.ToString(drDetail("movie_font_color")))
    ''                Else
    ''                    RowDetail.Cells(i).ForeColor = Color.Black
    ''                End If
    ''            Else
    ''                RowDetail.Cells(i).ForeColor = Color.Black
    ''            End If



    ''            Dim strKeySumMovie As String = Convert.ToString(Session("rptSetupNo")) + _
    ''                "_" + Convert.ToString(dr1("circuit_id")) + _
    ''                "_" + Convert.ToString(dr1("theater_id")) + _
    ''                "_" + Convert.ToString(drDetail("movie_id"))

    ''            If (htbSumMovie(strKeySumMovie) Is Nothing) Then
    ''                htbSumMovie(strKeySumMovie) = 1
    ''            Else
    ''                htbSumMovie(strKeySumMovie) = Convert.ToInt32(htbSumMovie(strKeySumMovie)) + 1
    ''            End If

    ''            tblDetail.Rows.Add(RowDetail)
    ''            i += 1
    ''        End While
    ''        drDetail.Close()


    ''        'Detail11111
    ''        TotalRow1 = New TableRow()
    ''        TotalRow1.Cells.Add(New TableCell)

    ''        'หา Trailer ทั้งหมด
    ''        wkSQL = " SELECT dbo.tblTrailer_Setup_Hdr.setup_no, dbo.tblMovie.movie_nameen AS MoviesName, dbo.tblMovie.movie_strdate, "
    ''        wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl.movie_id,dbo.tblTrailer_Setup_Dtl.movie_background_color, dbo.tblTrailer_Setup_Dtl.movie_font_color, COUNT(*) AS SumAmount"
    ''        wkSQL += vbNewLine + " FROM dbo.tblTrailer_Setup_Dtl INNER JOIN"
    ''        wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Hdr ON dbo.tblTrailer_Setup_Dtl.setup_no = dbo.tblTrailer_Setup_Hdr.setup_no LEFT OUTER JOIN"
    ''        wkSQL += vbNewLine + " dbo.tblMovie ON dbo.tblTrailer_Setup_Dtl.movie_id = dbo.tblMovie.movie_id"
    ''        wkSQL += vbNewLine + " WHERE     (dbo.tblTrailer_Setup_Hdr.setup_no = '" + Convert.ToString(Session("rptSetupNo")) + "')"
    ''        wkSQL += vbNewLine + " GROUP BY dbo.tblTrailer_Setup_Hdr.setup_no, dbo.tblMovie.movie_nameen, dbo.tblMovie.movie_strdate, dbo.tblTrailer_Setup_Dtl.movie_background_color,dbo.tblTrailer_Setup_Dtl.movie_id, "
    ''        wkSQL += vbNewLine + " dbo.tblTrailer_Setup_Dtl.movie_font_color"
    ''        wkSQL += vbNewLine + " ORDER BY dbo.tblMovie.movie_strdate,dbo.tblTrailer_Setup_Dtl.movie_id ASC"

    ''        Dim x As String = Request.UserHostAddress
    ''        Dim tblSum As New Table
    ''        tblSum.BorderWidth = 0
    ''        tblSum.BorderWidth = 0
    ''        tblSum.Width = 250
    ''        Dim drSum As IDataReader = cDB.GetDataAll(wkSQL)
    ''        While (drSum.Read())

    ''            'get ชื่อหนังและ ใส่สี
    ''            Dim tblSumRow As New TableRow()
    ''            tblSumRow.Cells.Add(New TableCell)
    ''            tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
    ''            tblSumRow.Cells(0).Font.Bold = False
    ''            tblSumRow.Cells(0).Width = 200
    ''            tblSumRow.Cells(0).ColumnSpan = 1
    ''            tblSumRow.Cells(0).Text = Convert.ToString(drSum("MoviesName")) '.Substring(0, IIf(Convert.ToString(drSum("MoviesName")).Length > 10, 10, Convert.ToString(drSum("MoviesName")).Length))

    ''            If (Not (drSum("movie_background_color") Is Nothing)) Then
    ''                If (Convert.ToString(drSum("movie_background_color")).Trim() <> "") Then
    ''                    tblSumRow.Cells(0).BackColor = System.Drawing.Color.FromName(Convert.ToString(drSum("movie_background_color")))
    ''                    'tblSumRow.Cells(0).ForeColor = System.Drawing.Color.FromName(Convert.ToString(drSum("movie_font_color")))
    ''                Else
    ''                    tblSumRow.Cells(0).BackColor = Color.White
    ''                    'tblSumRow.Cells(0).ForeColor = Color.Black
    ''                End If
    ''            Else
    ''                tblSumRow.Cells(0).BackColor = Color.White
    ''                'tblSumRow.Cells(0).ForeColor = Color.Black
    ''            End If

    ''            If (Not (drSum("movie_font_color") Is Nothing)) Then
    ''                If (Convert.ToString(drSum("movie_font_color")).Trim() <> "") Then
    ''                    tblSumRow.Cells(0).ForeColor = System.Drawing.Color.FromName(Convert.ToString(drSum("movie_font_color")))
    ''                Else
    ''                    tblSumRow.Cells(0).ForeColor = Color.Black
    ''                End If
    ''            Else
    ''                tblSumRow.Cells(0).ForeColor = Color.Black
    ''            End If


    ''            tblSumRow.Cells.Add(New TableCell)
    ''            tblSumRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    ''            tblSumRow.Cells(1).Font.Bold = False
    ''            tblSumRow.Cells(1).Width = 50
    ''            tblSumRow.Cells(1).ColumnSpan = 1

    ''            Dim strKeySumMovie As String = Convert.ToString(Session("rptSetupNo")) + _
    ''                "_" + Convert.ToString(dr1("circuit_id")) + _
    ''                "_" + Convert.ToString(dr1("theater_id")) + _
    ''                "_" + Convert.ToString(drSum("movie_id"))

    ''            If (htbSumMovie(strKeySumMovie) Is Nothing) Then
    ''                tblSumRow.Cells(1).Text = "0"
    ''            Else
    ''                tblSumRow.Cells(1).Text = Convert.ToInt32(htbSumMovie(strKeySumMovie)).ToString("#,##0")
    ''            End If


    ''            'ขีดเส้นใต้เมื่อขึ้น Release Date ใหม่
    ''            If (ViewState("StartDate") Is Nothing) Then
    ''                ViewState("StartDate") = Convert.ToString(drSum("movie_strdate")).Trim()
    ''            Else
    ''                If Convert.ToString(ViewState("StartDate")).Trim() <> Convert.ToString(drSum("movie_strdate")).Trim() Then
    ''                    tblSumRow.Cells(1).Style(0) = tblSumRow.Cells(1).Style(0) + ";border-top-color : #aaaaaa;border-top-style: solid;border-top-width: 2px;"

    ''                    'tblSum.Rows.Add(tblSumRow)
    ''                    ViewState("StartDate") = Convert.ToString(drSum("movie_strdate")).Trim()
    ''                End If
    ''            End If
    ''            'tblSumRow.Cells(1).Font.Bold = True
    ''            tblSumRow.Cells(0).Font.Bold = False
    ''            tblSum.Rows.Add(tblSumRow)
    ''        End While
    ''        drSum.Close()
    ''        ViewState("StartDate") = Nothing

    ''        TotalRow1.Cells(0).Controls.Add(tblSum)
    ''        TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Top
    ''        TotalRow1.Cells.Add(New TableCell)
    ''        '' ''TotalRow1.Cells(1).Controls.Add(tblDetail)
    ''        TotalRow1.Cells(1).VerticalAlign = VerticalAlign.Top
    ''        tblTrailer.Rows.Add(TotalRow1)

    ''    End While
    ''    dr1.Close()
    ''End Sub

    Private Sub getDataRpt()

        While (tblTrailer.Rows.Count > 4)
            tblTrailer.Rows.RemoveAt(4)
        End While

        Dim cDB As New cDatabase
        tblTrailer.Rows(0).Cells(0).Text = "โคลัมเบีย"
        tblTrailer.Rows(1).Cells(0).Text = "TRAILER LIST BY LOCATION"
        tblTrailer.Rows(2).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString()
        tblTrailer.Rows(3).Cells(0).Text = DateTime.Today.ToString("dd dddd MMMM yyyy")


        Dim dtbMain As DataTable = cDatabase.GetDataTable("exec spGetRptTrailerByLocation " _
                                                           + " '" + Convert.ToString(Session("rptSetupNo")) + "'" _
                                                           + ", " + Convert.ToString(Session("rptCircuitID")) + "" _
                                                           + ", '" + "Main_Report" + "'" _
                                                           + ", " + "null" + "")

        Dim intGroupRunning As Integer = 0
        Dim intDetailRunning As Integer = 0

        For i As Integer = 0 To dtbMain.Rows.Count - 1
            'Head
            Dim TotalRow1 As New TableRow()
            TotalRow1.HorizontalAlign = HorizontalAlign.Left

            If intDetailRunning = 0 Then
                TotalRow1.BackColor = Color.DarkGray
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(0).Font.Bold = True
                TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(0).ColumnSpan = 2
                TotalRow1.Cells(0).Font.Size = 12
                TotalRow1.Cells(0).Text = String.Format("Circuit : {0}", dtbMain.Rows(i)("circuit_name"))
                tblTrailer.Rows.Add(TotalRow1)
            End If

            TotalRow1 = New TableRow()
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.BackColor = Color.FromName("#DBEEF3")
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(0).ColumnSpan = 2
            TotalRow1.Cells(0).Font.Size = 10
            TotalRow1.Cells(0).Text = String.Format("{0}", dtbMain.Rows(i)("theater_name"))
            tblTrailer.Rows.Add(TotalRow1)

            ''create by nick
            Dim tblT As New Table
            Dim trT As New TableRow()
            trT.Cells.Add(New TableCell)
            trT.BackColor = Color.LightSlateGray
            trT.ForeColor = Color.White
            trT.Cells(0).Font.Bold = True
            trT.Cells(0).HorizontalAlign = HorizontalAlign.Center
            trT.Cells(0).Width = 200
            trT.Cells(0).Text = "Trailers"
            trT.Cells.Add(New TableCell)
            trT.Cells(1).Font.Bold = True
            trT.Cells(1).Width = 50
            trT.Cells(1).HorizontalAlign = HorizontalAlign.Center
            trT.Cells(1).Text = "Amount"
            tblT.Rows.Add(trT)

            TotalRow1 = New TableRow()
            TotalRow1.HorizontalAlign = HorizontalAlign.Left

            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.BackColor = Color.LightSlateGray
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(0).ColumnSpan = 1
            TotalRow1.Cells(0).Font.Size = 10
            TotalRow1.Cells(0).Controls.Add(tblT)

            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.BackColor = Color.LightSlateGray
            TotalRow1.Cells(1).Font.Bold = True
            TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(1).ColumnSpan = 1
            TotalRow1.Cells(1).Font.Size = 10
            TotalRow1.Cells(1).Text = "Screen"
            TotalRow1.Cells(1).ForeColor = Color.White
            tblTrailer.Rows.Add(TotalRow1)
            ''end by nick

            Dim tblDetail As Table = getDataRpt_Detail(dtbMain.Rows(i)("theater_id"))
            Dim tblSum As Table = getDataRpt_Summary(dtbMain.Rows(i)("theater_id"))

            'Detail11111
            TotalRow1 = New TableRow()
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(0).Controls.Add(tblSum)
            TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Top
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(1).Controls.Add(tblDetail)
            TotalRow1.Cells(1).VerticalAlign = VerticalAlign.Top
            tblTrailer.Rows.Add(TotalRow1)

            intDetailRunning += 1

            If (i = dtbMain.Rows.Count - 1) OrElse _
            ((i <= dtbMain.Rows.Count - 2) AndAlso (dtbMain.Rows(i)("circuit_id") <> dtbMain.Rows(i + 1)("circuit_id"))) _
            Then
                intDetailRunning = 0
                intGroupRunning += 1
            End If
        Next
    End Sub

    Private Function getDataRpt_Detail(ByVal p_theater_id As Integer) As Table
        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptTrailerByLocation " _
                                                           + " '" + Convert.ToString(Session("rptSetupNo")) + "'" _
                                                           + ", " + Convert.ToString(Session("rptCircuitID")) + "" _
                                                           + ", '" + "Sub_Report_Detail" + "'" _
                                                           + ", " + String.Format("{0}", p_theater_id) + "")

        ''Dim tblDetail As New Table
        ' ''tblDetail.Width = 500
        ''Dim RowDetail As New TableRow()
        ''RowDetail.HorizontalAlign = HorizontalAlign.Left

        ''Dim intThaeterSubIdGroupRunning As Integer = 0
        ''Dim intTheaterSubIdDetailRunning As Integer = 0

        ''Dim intSeqNoGroupRunning As Integer = 0
        ''Dim intSeqNoDetailRunning As Integer = 0

        ''For ii As Integer = 0 To dtDetail.Rows.Count - 1

        ''    If intTheaterSubIdDetailRunning = 0 Then
        ''        RowDetail = New TableRow()
        ''        RowDetail.Cells.Add(New TableCell)
        ''        RowDetail.Cells(0).Width = 80
        ''        RowDetail.Cells(0).Text = String.Format("Screen#{0}", dtDetail.Rows(ii)("theatersub_id"))
        ''        RowDetail.Cells(0).Font.Bold = True
        ''        RowDetail.Cells(0).BackColor = Color.FromName("#bbbbbb")

        ''        If (Convert.ToInt32(dtDetail.Rows(ii)("theatersub_normalseat_rank")) = 1) Then
        ''            RowDetail.Cells(0).ForeColor = Color.Red
        ''        ElseIf (Convert.ToInt32(dtDetail.Rows(ii)("theatersub_normalseat_rank")) = 2) Then
        ''            RowDetail.Cells(0).ForeColor = Color.Blue
        ''        Else
        ''            RowDetail.Cells(0).ForeColor = Color.Black
        ''        End If

        ''        RowDetail.Cells.Add(New TableCell)
        ''        RowDetail.Cells(1).Width = 170
        ''        RowDetail.Cells(1).Font.Bold = True
        ''        RowDetail.Cells(1).BackColor = Color.FromName("#dddddd")
        ''    End If

        ''    If intSeqNoDetailRunning = 0 Then
        ''        RowDetail.Cells(1).Text = Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Substring(0, IIf(Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Length > 10, 10, Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Length))
        ''    Else
        ''        RowDetail.Cells(1).Text &= "/" & Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Substring(0, IIf(Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Length > 10, 10, Convert.ToString(dtDetail.Rows(ii)("real_movie_nameen")).Length))
        ''    End If

        ''    If intSeqNoDetailRunning = 0 Then
        ''        RowDetail.Cells.Add(New TableCell)
        ''        RowDetail.Cells(intSeqNoGroupRunning + 2).Width = 100
        ''        RowDetail.Cells(intSeqNoGroupRunning + 2).Text = Convert.ToString(dtDetail.Rows(ii)("movie_nameen")).Substring(0, IIf(Convert.ToString(dtDetail.Rows(ii)("movie_nameen")).Length > 10, 10, Convert.ToString(dtDetail.Rows(ii)("movie_nameen")).Length))
        ''        If (Not (dtDetail.Rows(ii)("movie_background_color") Is Nothing)) Then
        ''            If (Convert.ToString(dtDetail.Rows(ii)("movie_background_color")).Trim() <> "") Then
        ''                RowDetail.Cells(intSeqNoGroupRunning + 2).BackColor = System.Drawing.Color.FromName(Convert.ToString(dtDetail.Rows(ii)("movie_background_color")))
        ''                'RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = System.Drawing.Color.FromName(Convert.ToString(dtDetail.Rows(ii)("movie_font_color")))
        ''            Else
        ''                RowDetail.Cells(intSeqNoGroupRunning + 2).BackColor = Color.White
        ''                'RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = Color.Black
        ''            End If
        ''        Else
        ''            RowDetail.Cells(intSeqNoGroupRunning + 2).BackColor = Color.White
        ''            'RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = Color.Black
        ''        End If
        ''        If (Not (dtDetail.Rows(ii)("movie_font_color") Is Nothing)) Then
        ''            If (Convert.ToString(dtDetail.Rows(ii)("movie_font_color")).Trim() <> "") Then
        ''                RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = System.Drawing.Color.FromName(Convert.ToString(dtDetail.Rows(ii)("movie_font_color")))
        ''            Else
        ''                RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = Color.Black
        ''            End If
        ''        Else
        ''            RowDetail.Cells(intSeqNoGroupRunning + 2).ForeColor = Color.Black
        ''        End If
        ''    End If

        ''    intSeqNoDetailRunning += 1

        ''    If (ii = dtDetail.Rows.Count - 1) OrElse _
        ''    ((ii <= dtDetail.Rows.Count - 2) AndAlso _
        ''        (dtDetail.Rows(ii)("circuit_id") <> dtDetail.Rows(ii + 1)("circuit_id") OrElse _
        ''         dtDetail.Rows(ii)("theater_id") <> dtDetail.Rows(ii + 1)("theater_id") OrElse _
        ''         dtDetail.Rows(ii)("theatersub_id") <> dtDetail.Rows(ii + 1)("theatersub_id") OrElse _
        ''         dtDetail.Rows(ii)("seq_no") <> dtDetail.Rows(ii + 1)("seq_no"))) _
        ''    Then
        ''        intSeqNoDetailRunning = 0
        ''        intSeqNoGroupRunning += 1
        ''    End If

        ''    intTheaterSubIdDetailRunning += 1

        ''    If (ii = dtDetail.Rows.Count - 1) OrElse _
        ''    ((ii <= dtDetail.Rows.Count - 2) AndAlso _
        ''        (dtDetail.Rows(ii)("circuit_id") <> dtDetail.Rows(ii + 1)("circuit_id") OrElse _
        ''         dtDetail.Rows(ii)("theater_id") <> dtDetail.Rows(ii + 1)("theater_id") OrElse _
        ''         dtDetail.Rows(ii)("theatersub_id") <> dtDetail.Rows(ii + 1)("theatersub_id"))) _
        ''    Then
        ''        tblDetail.Rows.Add(RowDetail)

        ''        intSeqNoDetailRunning = 0
        ''        intSeqNoGroupRunning = 0

        ''        intTheaterSubIdDetailRunning = 0
        ''        intThaeterSubIdGroupRunning += 1
        ''    End If
        ''Next

        ''Return tblDetail

        Dim tblDetail As New Table
        'tblDetail.Width = 500
        Dim RowDetail As New TableRow()
        RowDetail.HorizontalAlign = HorizontalAlign.Left

        For ii As Integer = 0 To dtDetail.Rows.Count - 1
            RowDetail = New TableRow()
            RowDetail.Cells.Add(New TableCell)
            RowDetail.Cells(0).Width = 80
            RowDetail.Cells(0).Text = String.Format("{0}", dtDetail.Rows(ii)("screen"))
            RowDetail.Cells(0).Font.Bold = True
            RowDetail.Cells(0).BackColor = Color.FromName("#bbbbbb")

            If (Convert.ToInt32(dtDetail.Rows(ii)("theatersub_normalseat_rank")) = 1) Then
                RowDetail.Cells(0).ForeColor = Color.Red
            ElseIf (Convert.ToInt32(dtDetail.Rows(ii)("theatersub_normalseat_rank")) = 2) Then
                RowDetail.Cells(0).ForeColor = Color.Blue
            Else
                RowDetail.Cells(0).ForeColor = Color.Black
            End If

            RowDetail.Cells.Add(New TableCell)
            RowDetail.Cells(1).Width = 170
            RowDetail.Cells(1).Font.Bold = True
            RowDetail.Cells(1).BackColor = Color.FromName("#dddddd")
            RowDetail.Cells(1).Text = String.Format("{0}", dtDetail.Rows(ii)("real_movie_nameen"))

            For j As Integer = 1 To 9
                Dim strTrailer As String = String.Format("{0}", dtDetail.Rows(ii)("trailer" & j))
                If strTrailer = "" Then
                    Exit For
                End If
                Dim arrTrailer As String() = strTrailer.Split("|")
                RowDetail.Cells.Add(New TableCell)
                RowDetail.Cells(1 + j).Width = 100
                RowDetail.Cells(1 + j).Text = (arrTrailer(0) & "          ").Substring(0, 10).Trim()

                If arrTrailer(1) <> "" Then
                    RowDetail.Cells(1 + j).BackColor = System.Drawing.Color.FromName(arrTrailer(1))
                Else
                    RowDetail.Cells(1 + j).BackColor = Color.White
                End If
                If arrTrailer(2) <> "" Then
                    RowDetail.Cells(1 + j).ForeColor = System.Drawing.Color.FromName(arrTrailer(2))
                Else
                    RowDetail.Cells(1 + j).ForeColor = Color.Black
                End If
            Next

            tblDetail.Rows.Add(RowDetail)
        Next

        Return tblDetail
    End Function

    Private Function getDataRpt_Summary(ByVal p_theater_id As Integer) As Table
        Dim dtSummary As DataTable = cDatabase.GetDataTable("exec spGetRptTrailerByLocation " _
                                                           + " '" + Convert.ToString(Session("rptSetupNo")) + "'" _
                                                           + ", " + Convert.ToString(Session("rptCircuitID")) + "" _
                                                           + ", '" + "Sub_Report_Summary" + "'" _
                                                           + ", " + String.Format("{0}", p_theater_id) + "")

        Dim tblSum As New Table
        tblSum.BorderWidth = 0
        tblSum.BorderWidth = 0
        tblSum.Width = 250

        For iii As Integer = 0 To dtSummary.Rows.Count - 1
            'get ชื่อหนังและ ใส่สี
            Dim tblSumRow As New TableRow()

            tblSumRow.Cells.Add(New TableCell)
            tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
            tblSumRow.Cells(0).Font.Bold = False
            tblSumRow.Cells(0).Width = 200
            tblSumRow.Cells(0).ColumnSpan = 1
            tblSumRow.Cells(0).Text = String.Format("{0}", dtSummary.Rows(iii)("movie_nameen"))

            If (Not (dtSummary.Rows(iii)("movie_background_color") Is Nothing)) Then
                If (Convert.ToString(dtSummary.Rows(iii)("movie_background_color")).Trim() <> "") Then
                    tblSumRow.Cells(0).BackColor = System.Drawing.Color.FromName(Convert.ToString(dtSummary.Rows(iii)("movie_background_color")))
                    'tblSumRow.Cells(0).ForeColor = System.Drawing.Color.FromName(Convert.ToString(drSum("movie_font_color")))
                Else
                    tblSumRow.Cells(0).BackColor = Color.White
                    'tblSumRow.Cells(0).ForeColor = Color.Black
                End If
            Else
                tblSumRow.Cells(0).BackColor = Color.White
                'tblSumRow.Cells(0).ForeColor = Color.Black
            End If

            If (Not (dtSummary.Rows(iii)("movie_font_color") Is Nothing)) Then
                If (Convert.ToString(dtSummary.Rows(iii)("movie_font_color")).Trim() <> "") Then
                    tblSumRow.Cells(0).ForeColor = System.Drawing.Color.FromName(Convert.ToString(dtSummary.Rows(iii)("movie_font_color")))
                Else
                    tblSumRow.Cells(0).ForeColor = Color.Black
                End If
            Else
                tblSumRow.Cells(0).ForeColor = Color.Black
            End If

            tblSumRow.Cells.Add(New TableCell)
            tblSumRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            tblSumRow.Cells(1).Font.Bold = False
            tblSumRow.Cells(1).Width = 50
            tblSumRow.Cells(1).ColumnSpan = 1

            tblSumRow.Cells(1).Text = String.Format("{0:#,##0}", dtSummary.Rows(iii)("trailer_qty"))

            'ขีดเส้นใต้เมื่อขึ้น Release Date ใหม่
            If (ViewState("StartDate") Is Nothing) Then
                ViewState("StartDate") = Convert.ToString(dtSummary.Rows(iii)("movie_strdate")).Trim()
            Else
                If Convert.ToString(ViewState("StartDate")).Trim() <> Convert.ToString(dtSummary.Rows(iii)("movie_strdate")).Trim() Then
                    tblSumRow.Cells(1).Style(0) = tblSumRow.Cells(1).Style(0) + ";border-top-color : #aaaaaa;border-top-style: solid;border-top-width: 2px;"

                    'tblSum.Rows.Add(tblSumRow)
                    ViewState("StartDate") = Convert.ToString(dtSummary.Rows(iii)("movie_strdate")).Trim()
                End If
            End If
            'tblSumRow.Cells(1).Font.Bold = True
            tblSumRow.Cells(0).Font.Bold = False
            tblSum.Rows.Add(tblSumRow)
        Next

        ViewState("StartDate") = Nothing

        Return tblSum
    End Function

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByLocationParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TrailerByLocation.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        getDataRpt()
        divExport.RenderControl(htmlWrite)
        'tblTrailer.RenderControl(htmlWrite)
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class
