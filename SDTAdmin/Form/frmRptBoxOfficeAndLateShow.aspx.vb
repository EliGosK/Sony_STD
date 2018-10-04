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

Imports System.Web.UI.Control

Partial Public Class frmRptBoxOfficeAndLateShow
    Inherits System.Web.UI.Page
    Dim decSessionCountRow As Decimal = 0
    Dim decSumDayWageQty As Decimal = 0
    Dim decNextWageQty As Decimal = 1
    'Dim decSumFormerWageQty As Decimal = 0
    'Dim decSumPresentWageQty As Decimal = 0
    Dim decWageQty As Decimal = 0
    Dim strTheaterSubIdCheck As String = ""

    Dim strWageSession As String = ""

    Dim cDB As New cDatabase
    Dim arrMovieAndWage As New ArrayList()
    Dim arrWageSelectAll As New ArrayList()
    Dim arrTsubAndSession As New ArrayList()


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                CreateTable()
            End If
        Catch ex As Exception
            Dim rowError As New TableRow()
            rowError.Cells.Add(New TableCell)
            rowError.Cells(0).BackColor = System.Drawing.Color.FromName("#5D7B9D")
            rowError.Cells(0).ForeColor = Color.White
            rowError.Cells(0).Font.Bold = True
            rowError.Cells(0).HorizontalAlign = HorizontalAlign.Center
            rowError.Cells(0).Font.Size = 9
            rowError.Cells(0).Text = "กกก"
            rowError.Cells(0).Text = ex.Message
            tblTitle.Rows.Add(rowError)
        End Try
    End Sub

    Private Sub CreateTable()
        ''Session("strDateComp") = Convert.ToDateTime("06/17/2010")
        ''Session("strDateEndComp") = Convert.ToDateTime("06/23/2010")
        Dim CountSound As Integer = 0
        Dim movieSound As String = ""
        Dim movieSoundcheck1 As String = ""
        Dim intMaxSesion As Integer = 0


        Dim tblDetail As New System.Web.UI.WebControls.Table
        Dim TotalRow1 As New TableRow()
        Dim wkSQL0 As String = ""
        Dim trTop1HasRow As Integer = 0
        tblDetail.Font.Name = "Tahoma"
        tblDetail.BorderWidth = 1
        tblDetail.BorderColor = Color.Gray
        Dim CountWage As Integer = 0
        Dim dtbSession As DataTable = cDatabase.GetDataTable("select top 1 isnull(collect_report_session_qty,0) as session_qty, isnull(collect_report_level_qty,0) as level_qty, isnull(collect_report_max_amt,0) as collect_report_wage from tblConfig")
        ViewState("session_qty") = dtbSession.Rows(0)("session_qty").ToString()
        ViewState("level_qty") = dtbSession.Rows(0)("level_qty").ToString()
        ViewState("collect_report_wage") = dtbSession.Rows(0)("collect_report_wage").ToString()

        wkSQL0 = " select r.theater_id, t.theater_name as TName, c.circuit_name, isnull(sum(r.revenue_amount), 0) as total_revenue_amount ,isnull(r.user_id,'') as user_id "
        wkSQL0 += vbNewLine + " from tblRevenue r"
        wkSQL0 += vbNewLine + " left join tblTheater t on r.theater_id = t.theater_id"
        wkSQL0 += vbNewLine + " left join tblCircuit c on t.circuit_id = c.circuit_id"

        wkSQL0 += vbNewLine + " left join ("
        wkSQL0 += vbNewLine + " select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
        wkSQL0 += vbNewLine + " from tblChecker_Movie_Setup_Dtl dtl"
        wkSQL0 += vbNewLine + " left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no "
        wkSQL0 += vbNewLine + " where convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
        wkSQL0 += vbNewLine + " or convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
        wkSQL0 += vbNewLine + " ) msetup on msetup.movie_id = r.movies_id"

        wkSQL0 += vbNewLine + " where r.revenue_date >= convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101) "
        wkSQL0 += vbNewLine + " and r.revenue_date <= convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101)"

        wkSQL0 += vbNewLine + " and r.theater_id between " + Session("startTheaterId").ToString() + " and " + Session("EndTheaterId").ToString() ''aa อย่าลืมลบ
        wkSQL0 += vbNewLine + " and t.theater_status = 'Enabled'"

        wkSQL0 += vbNewLine + " and msetup.movie_id = r.movies_id"
        wkSQL0 += vbNewLine + " and (NOT (r.user_id IS NULL))"

        wkSQL0 += vbNewLine + " group by r.theater_id, t.theater_name, c.circuit_name ,r.user_id "
        wkSQL0 += vbNewLine + " having(isnull(sum(r.revenue_amount), 0) > 0)"
        wkSQL0 += vbNewLine + " order by c.circuit_name, r.theater_id"


        Dim drTop As IDataReader = cDB.GetDataAll(wkSQL0)
        While (drTop.Read())
            'If (drTop("user_id").ToString() = "0047") Then
            '    Dim strD As String = ""
            'End If
            'Add Head Theatre
            TotalRow1 = New TableRow()
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(0).BackColor = System.Drawing.Color.FromName("#5D7B9D")
            TotalRow1.Cells(0).ForeColor = Color.White
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            'TotalRow1.Cells(0).ColumnSpan = 1
            'TotalRow1.Cells(0).RowSpan = 1
            TotalRow1.Cells(0).Font.Size = 9
            TotalRow1.Cells(0).Text = "กกก"
            TotalRow1.Cells(0).Text = Convert.ToString(drTop("TName"))
            tblTop.Rows.Add(TotalRow1)

            tblDetail = New System.Web.UI.WebControls.Table
            tblDetail.Font.Name = "Tahoma"
            tblDetail.BorderStyle = BorderStyle.Solid
            tblDetail.BorderWidth = 1
            tblDetail.BorderColor = Color.Gray
            tblDetail.CellPadding = 3
            tblDetail.CellSpacing = 0
            tblDetail.Font.Size = 9
            tblDetail.GridLines = GridLines.Both
            tblDetail.Attributes("width") = "100%"
            tblDetail.ForeColor = Color.Black
            ''''''''''''''''''''''''''''''''''''''''

            If drTop("total_revenue_amount") > 0 Then
                trTop1HasRow = 0

                Dim wkSQL As String
                TotalRow1 = New TableRow()
                wkSQL = " select isnull(max(SessionCount),0) SessionMax from"
                wkSQL += vbNewLine + " ("
                wkSQL += vbNewLine + " SELECT tblRevenue.revenue_date,tblRevenue.movies_id,tblTheaterSub.theatersub_code"
                wkSQL += vbNewLine + " , tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name AS TName"
                wkSQL += vbNewLine + " ,count(*) SessionCount"
                wkSQL += vbNewLine + " FROM tblTheater RIGHT OUTER JOIN"
                wkSQL += vbNewLine + " tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id RIGHT OUTER JOIN"
                wkSQL += vbNewLine + " tblMovie RIGHT OUTER JOIN"
                wkSQL += vbNewLine + " tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id AND "
                wkSQL += vbNewLine + " tblTheaterSub.theater_id = tblRevenue.theater_id LEFT OUTER JOIN"
                wkSQL += vbNewLine + " tblUser ON tblRevenue.user_id = tblUser.user_id"

                wkSQL += vbNewLine + " left join ("
                wkSQL += vbNewLine + " select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                wkSQL += vbNewLine + " from tblChecker_Movie_Setup_Dtl dtl"
                wkSQL += vbNewLine + " left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no "
                wkSQL += vbNewLine + " where convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQL += vbNewLine + " or convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQL += vbNewLine + " ) msetup on msetup.movie_id = tblRevenue.movies_id"

                wkSQL += vbNewLine + " WHERE tblRevenue.revenue_date >= convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101)"
                wkSQL += vbNewLine + " AND tblRevenue.revenue_date <= convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101)"
                wkSQL += vbNewLine + " and msetup.movie_id = tblRevenue.movies_id"

                wkSQL += vbNewLine + " and tblRevenue.theater_id = " + Convert.ToString(drTop("theater_id"))
                wkSQL += vbNewLine + " and tblRevenue.user_id = " + Convert.ToString(drTop("user_id"))
                wkSQL += vbNewLine + " group by tblRevenue.revenue_date,tblRevenue.movies_id"
                wkSQL += vbNewLine + " ,tblTheaterSub.theatersub_code"
                wkSQL += vbNewLine + " , tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name"
                wkSQL += vbNewLine + " ) as temp"

                intMaxSesion = 0
                Dim dr As IDataReader = cDB.GetDataAll(wkSQL)
                If dr.Read = True Then
                    intMaxSesion = Convert.ToInt32(dr("SessionMax"))
                    If intMaxSesion <= 8 Then
                        intMaxSesion = 8
                    End If
                End If

                'Dim strChkTheaterSubIdDub As String = ""
                'Dim strChkTNameDub As String = ""

                dr.Close()

                '---start movieId
                Dim wkSQLmovieId As String
                wkSQLmovieId = "select isnull(temp.movies_id,0) as movies_id, tblMovie.movie_nameen"
                wkSQLmovieId += vbNewLine + " from"
                wkSQLmovieId += vbNewLine + " ("
                wkSQLmovieId += vbNewLine + " SELECT tblRevenue.revenue_date,tblRevenue.movies_id,tblTheaterSub.theatersub_code"
                wkSQLmovieId += vbNewLine + " , tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name AS TName"
                wkSQLmovieId += vbNewLine + " ,count(*) SessionCount"
                wkSQLmovieId += vbNewLine + " FROM tblTheater RIGHT OUTER JOIN"
                wkSQLmovieId += vbNewLine + " tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id RIGHT OUTER JOIN"
                wkSQLmovieId += vbNewLine + " tblMovie RIGHT OUTER JOIN"
                wkSQLmovieId += vbNewLine + " tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id AND "
                wkSQLmovieId += vbNewLine + " tblTheaterSub.theater_id = tblRevenue.theater_id LEFT OUTER JOIN"
                wkSQLmovieId += vbNewLine + " tblUser ON tblRevenue.user_id = tblUser.user_id"

                wkSQLmovieId += vbNewLine + " left join ("
                wkSQLmovieId += vbNewLine + " select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                wkSQLmovieId += vbNewLine + " from tblChecker_Movie_Setup_Dtl dtl"
                wkSQLmovieId += vbNewLine + " left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no "
                wkSQLmovieId += vbNewLine + " where convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQLmovieId += vbNewLine + " or convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQLmovieId += vbNewLine + " ) msetup on msetup.movie_id = tblRevenue.movies_id"

                wkSQLmovieId += vbNewLine + " WHERE tblRevenue.revenue_date >= convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101)"
                wkSQLmovieId += vbNewLine + " AND tblRevenue.revenue_date <= convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101)"
                wkSQLmovieId += vbNewLine + " and msetup.movie_id = tblRevenue.movies_id"

                wkSQLmovieId += vbNewLine + " and tblRevenue.theater_id = " + Convert.ToString(drTop("theater_id"))
                wkSQLmovieId += vbNewLine + " and tblRevenue.user_id = " + Convert.ToString(drTop("user_id"))
                wkSQLmovieId += vbNewLine + " group by tblRevenue.revenue_date,tblRevenue.movies_id"
                wkSQLmovieId += vbNewLine + " ,tblTheaterSub.theatersub_code"
                wkSQLmovieId += vbNewLine + " , tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name"
                wkSQLmovieId += vbNewLine + " ) as temp"
                wkSQLmovieId += vbNewLine + " left join tblMovie"
                wkSQLmovieId += vbNewLine + " on temp.movies_id = tblMovie.movie_id"
                wkSQLmovieId += vbNewLine + " group by temp.movies_id, tblMovie.movie_nameen"


                'For iMW As Integer = 0 To arrMovieAndWage.Count() - 1
                '    arrMovieAndWage.Clear()
                'Next



                If Not arrMovieAndWage.Count() = Nothing Then
                    arrMovieAndWage.Clear()
                    arrMovieAndWage = New ArrayList()
                End If
                'arrMovieAndWage = New ArrayList
                Dim iMovieWage As Integer = 0
                Dim drMovieId As IDataReader = cDB.GetDataAll(wkSQLmovieId)
                While (drMovieId.Read())
                    arrMovieAndWage.Add(drMovieId("movies_id").ToString() + "_" + drMovieId("movie_nameen").ToString() + "_0")
                    iMovieWage = iMovieWage + 1
                End While
                drMovieId.Close()

                '---end movieId

                Dim strOldDay As String = "1"

                'Head Create Session
                Dim intRuningCells As Integer = 0
                TotalRow1 = New TableRow()
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Theatre & Screen"

                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Title"

                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Sound"




                For i As Integer = 0 To intMaxSesion - 1
                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                    TotalRow1.Cells(intRuningCells).Font.Bold = True
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = "Session " + (i + 1).ToString()
                Next

                '--session
                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Session"
                '--wage
                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Wage"


                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                TotalRow1.Cells(intRuningCells).RowSpan = 1
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Total"

                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                TotalRow1.Cells(intRuningCells).RowSpan = 2
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Checker"
                tblDetail.Rows.Add(TotalRow1)



                'Add(Detail)
                intRuningCells = -1
                TotalRow1 = New TableRow()
                For i As Integer = 0 To intMaxSesion * 2 - 1
                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#CADCEF")
                    TotalRow1.Cells(intRuningCells).Font.Bold = False
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    If (i Mod 2 = 1) Then
                        TotalRow1.Cells(intRuningCells).Text = "Adms"
                    Else
                        TotalRow1.Cells(intRuningCells).Text = "Baht"
                    End If
                Next

                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                TotalRow1.Cells(intRuningCells).RowSpan = 1
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Baht"

                intRuningCells += 1
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(intRuningCells).BackColor = System.Drawing.Color.FromName("#c3cad6")
                TotalRow1.Cells(intRuningCells).Font.Bold = True
                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                TotalRow1.Cells(intRuningCells).RowSpan = 1
                TotalRow1.Cells(intRuningCells).Font.Size = 9
                TotalRow1.Cells(intRuningCells).Text = "Adms"

                tblDetail.Rows.Add(TotalRow1)

                'insert detail
                Dim wkSQL1 As String

                wkSQL1 = "SELECT tblTheater.theater_id, tblTheater.theater_name, tblTheater.circuit_id, tblCircuit.circuit_name, "
                wkSQL1 += vbNewLine + "  tblTheaterSub.theatersub_id, tblTheaterSub.theatersub_code, "
                wkSQL1 += vbNewLine + "  tblTheater.theater_name + ' ' + tblTheaterSub.theatersub_name AS TName, "
                wkSQL1 += vbNewLine + "  tblMovie.movie_id, tblMovie.movie_code, tblMovie.movie_nameen AS MName, "
                wkSQL1 += vbNewLine + "  tblMovie.movie_strdate, tblRevenue.revenue_adms AS SumAdms, "
                wkSQL1 += vbNewLine + "  tblRevenue.revenue_amount AS SumAmount, tblRevenue.revenue_date, tblRevenue.movie_system, "
                wkSQL1 += vbNewLine + "  tblRevenue.sound_type, tblRevenue.revenue_Time, tblUser.user_name, tblUser.user_id"
                wkSQL1 += vbNewLine + "  , "
                wkSQL1 += vbNewLine + " ("
                wkSQL1 += vbNewLine + " select count(tblRevenue1.movies_id)"
                wkSQL1 += vbNewLine + " FROM tblRevenue tblRevenue1"
                wkSQL1 += vbNewLine + " WHERE  tblRevenue1.revenue_date = tblRevenue.revenue_date "
                wkSQL1 += vbNewLine + " and tblRevenue1.theater_id = tblRevenue.theater_id"
                wkSQL1 += vbNewLine + "  and tblRevenue1.theatersub_id = tblRevenue.theatersub_id"
                wkSQL1 += vbNewLine + "  and tblRevenue1.user_id = tblRevenue.user_id"
                wkSQL1 += vbNewLine + "  group by tblRevenue1.revenue_date, tblRevenue1.theater_id, tblRevenue1.theatersub_id, tblRevenue1.user_id"
                wkSQL1 += vbNewLine + " ) countSession,"
                wkSQL1 += vbNewLine + " ("
                wkSQL1 += vbNewLine + " select count(tblRevenue1.movies_id)"
                wkSQL1 += vbNewLine + " FROM tblRevenue tblRevenue1"
                wkSQL1 += vbNewLine + " WHERE  tblRevenue1.revenue_date = tblRevenue.revenue_date "
                wkSQL1 += vbNewLine + " and tblRevenue1.theater_id = tblRevenue.theater_id"
                wkSQL1 += vbNewLine + " and tblRevenue1.user_id = tblRevenue.user_id"
                wkSQL1 += vbNewLine + " group by tblRevenue1.revenue_date, tblRevenue1.theater_id,tblRevenue1.user_id"
                wkSQL1 += vbNewLine + " ) countSessionAll"
                wkSQL1 += vbNewLine + "  FROM tblTheater"
                wkSQL1 += vbNewLine + "  left join tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id "
                wkSQL1 += vbNewLine + "  left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id "
                wkSQL1 += vbNewLine + "  left join tblRevenue ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id "
                wkSQL1 += vbNewLine + "  and tblTheaterSub.theater_id = tblRevenue.theater_id "
                wkSQL1 += vbNewLine + "  left join tblMovie ON tblRevenue.movies_id = tblMovie.movie_id"
                wkSQL1 += vbNewLine + "  left join tblUser ON tblRevenue.user_id = tblUser.user_id "

                wkSQL1 += vbNewLine + " left join ("
                wkSQL1 += vbNewLine + " select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                wkSQL1 += vbNewLine + " from tblChecker_Movie_Setup_Dtl dtl"
                wkSQL1 += vbNewLine + " left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no "
                wkSQL1 += vbNewLine + " where convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQL1 += vbNewLine + " or convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date"
                wkSQL1 += vbNewLine + " ) msetup on msetup.movie_id = tblRevenue.movies_id"

                wkSQL1 += vbNewLine + "  WHERE tblRevenue.revenue_date >= convert(datetime,'" + Convert.ToDateTime(Session("strDateComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateComp")).Year.ToString()) + "',101)"
                wkSQL1 += vbNewLine + "  and tblRevenue.revenue_date <= convert(datetime,'" + Convert.ToDateTime(Session("strDateEndComp")).ToString("MM/dd/" + Convert.ToDateTime(Session("strDateEndComp")).Year.ToString()) + "',101)"
                wkSQL1 += vbNewLine + " and tblRevenue.theater_id = " + Convert.ToString(drTop("theater_id"))
                wkSQL1 += vbNewLine + " and tblRevenue.user_id = " + Convert.ToString(drTop("user_id"))
                wkSQL1 += vbNewLine + " and msetup.movie_id = tblRevenue.movies_id"

                wkSQL1 += vbNewLine + " ORDER BY tblRevenue.revenue_date,tblTheaterSub.theatersub_id, countSession DESC, tblCircuit.circuit_name, "
                wkSQL1 += vbNewLine + " tblTheater.theater_name, tblUser.user_name, tblMovie.movie_id,  tblRevenue.timehour_id, tblRevenue.timemin_id"

                Dim htb As New Hashtable()
                Dim htbSubID As New Hashtable()
                Dim htbDate As New Hashtable()
                Dim decSumBaht, decSumBahtByDate As Decimal
                Dim intSessionCount As Integer = 0 '''---new
                Dim sumIntSessionCount As Integer = 0 '''---new
                Dim intAdms, intAdmsByDate As Decimal
                decSumBaht = 0
                decSumBahtByDate = 0
                intAdms = 0
                intAdmsByDate = 0
                decSessionCountRow = 0

                decSumDayWageQty = 0
                decNextWageQty = 1
                'decSumFormerWageQty = 0
                'decSumPresentWageQty = 0


                TotalRow1 = New TableRow()
                Dim strChecker As String = ""
                Dim dr1 As IDataReader = cDB.GetDataAll(wkSQL1)


                While (dr1.Read())

                    If (htb(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy") + "_" + Convert.ToString(dr1("TName")) + "_" + Convert.ToString(dr1("MName")) + "_" + Convert.ToString(dr1("user_name"))) Is Nothing) Then '+ "_" + Convert.ToString(dr1("movie_id"))
                        htb(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy") + "_" + Convert.ToString(dr1("TName")) + "_" + Convert.ToString(dr1("MName")) + "_" + Convert.ToString(dr1("user_name"))) = "Check"
                        CountWage = 0

                        If (htb(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")) Is Nothing) Then
                            htb(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")) = "Check"

                            Dim cntSessionPerDay As Integer = 0
                            Dim maxSessionPerDay As Integer = 0
                            Dim chkTheaterSubDub As String = ""
                            Dim arrTheaterSubDub As New ArrayList()
                            Dim strSQLwage As String
                            strSQLwage = " SELECT tblTheater.theater_id, tblTheaterSub.theatersub_id, tblRevenue.movies_id, "
                            strSQLwage += vbNewLine + "	isnull(msetup.movie_level_id,999) as movie_level_id, "
                            strSQLwage += vbNewLine + "	isnull(msetup.present_flag,'Y') as present_flag, "
                            strSQLwage += vbNewLine + "	isnull(msetup.collect_report_flag, 'N') as collect_report_flag, "
                            strSQLwage += vbNewLine + "	("
                            strSQLwage += vbNewLine + "	   select count(tblRevenue1.theater_id)"
                            strSQLwage += vbNewLine + "	   FROM tblRevenue tblRevenue1"
                            strSQLwage += vbNewLine + "	   WHERE  tblRevenue1.revenue_date = tblRevenue.revenue_date "
                            strSQLwage += vbNewLine + "	   and tblRevenue1.theater_id = tblRevenue.theater_id"
                            strSQLwage += vbNewLine + "	   and tblRevenue1.theatersub_id = tblRevenue.theatersub_id"
                            strSQLwage += vbNewLine + "	   and tblRevenue1.user_id = tblRevenue.user_id and tblRevenue1.movies_id = tblRevenue.movies_id "
                            strSQLwage += vbNewLine + "	   group by tblRevenue1.revenue_date, tblRevenue1.theater_id, tblRevenue1.theatersub_id, tblRevenue1.user_id"
                            strSQLwage += vbNewLine + "	) countSession,"
                            strSQLwage += vbNewLine + "	sum(isnull(tblRevenue.revenue_adms, 0)) AS SumAdms, "
                            strSQLwage += vbNewLine + "	sum(isnull(tblRevenue.revenue_amount, 0)) AS SumAmount, "
                            strSQLwage += vbNewLine + "	tblUser.user_id, tblUser.user_name, tblUser.present_checker_level_id,"
                            strSQLwage += vbNewLine + "	tblUser.former_checker_level_id, tblRevenue.revenue_date"
                            strSQLwage += vbNewLine + "	FROM tblTheater"
                            strSQLwage += vbNewLine + "	left join tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id "
                            strSQLwage += vbNewLine + "	left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id "
                            strSQLwage += vbNewLine + "	left join tblRevenue ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id "
                            strSQLwage += vbNewLine + "	and tblTheaterSub.theater_id = tblRevenue.theater_id "
                            strSQLwage += vbNewLine + "	left join tblUser ON tblRevenue.user_id = tblUser.user_id "
                            strSQLwage += vbNewLine + "	left join ("
                            strSQLwage += vbNewLine + "		select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                            strSQLwage += vbNewLine + "		from tblChecker_Movie_Setup_Dtl dtl"
                            strSQLwage += vbNewLine + "		left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no"
                            strSQLwage += vbNewLine + "		where convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date  "
                            strSQLwage += vbNewLine + "	) msetup on msetup.movie_id = tblRevenue.movies_id "
                            strSQLwage += vbNewLine + "	WHERE tblRevenue.revenue_date = convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) "
                            strSQLwage += vbNewLine + "		and tblRevenue.theater_id =" + Convert.ToString(dr1("theater_id"))
                            strSQLwage += vbNewLine + "		and tblRevenue.user_id =" + Convert.ToString(dr1("user_id"))
                            strSQLwage += vbNewLine + "		and tblRevenue.movies_id = msetup.movie_id"
                            strSQLwage += vbNewLine + "	group by tblRevenue.theater_id,tblTheater.theater_id, tblRevenue.revenue_date, "
                            strSQLwage += vbNewLine + "	tblRevenue.theatersub_id, tblTheaterSub.theatersub_id, tblRevenue.movies_id,  "
                            strSQLwage += vbNewLine + "	msetup.movie_level_id, msetup.present_flag, msetup.collect_report_flag,"
                            strSQLwage += vbNewLine + "	tblRevenue.user_id, tblUser.user_id, tblUser.user_name, "
                            strSQLwage += vbNewLine + "	tblUser.present_checker_level_id, tblUser.former_checker_level_id"
                            strSQLwage += vbNewLine + "	order by collect_report_flag, movie_level_id, "
                            strSQLwage += vbNewLine + "	countSession DESC, SumAmount DESC, present_flag DESC"

                            If Not arrWageSelectAll.Count() = Nothing Then
                                arrWageSelectAll.Clear()
                                arrWageSelectAll = New ArrayList()
                            End If

                            Dim strSelectSqlWage As String = ""
                            Dim strSelectSqlTsub As String = ""
                            Dim strTheaterSubOld As String = ""

                            Dim strSQLMinMaxTSub As String
                            ''strSQLMinMaxTSub = "	SELECT isnull(max(present_flag),'Y') as present_flag,"
                            ''strSQLMinMaxTSub += vbNewLine + "	isnull(max(sumAmount),0) as MaxAmount,"
                            ''strSQLMinMaxTSub += vbNewLine + "	isnull(min(theatersub_id) ,0) as MinTheatersub_id, "
                            ''strSQLMinMaxTSub += vbNewLine + "	isnull(max(theatersub_id) ,0) as MaxTheatersub_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	from "
                            ''strSQLMinMaxTSub += vbNewLine + "	("
                            ''strSQLMinMaxTSub += vbNewLine + "	SELECT isnull(msetup.present_flag,'Y') as present_flag,"
                            ''strSQLMinMaxTSub += vbNewLine + "	sum(isnull(tblRevenue.revenue_amount, 0)) as sumAmount,"
                            ''strSQLMinMaxTSub += vbNewLine + "	tblTheaterSub.theatersub_id as Theatersub_id"

                            ''strSQLMinMaxTSub += vbNewLine + "	FROM tblTheater"
                            ''strSQLMinMaxTSub += vbNewLine + "	left join tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	left join tblRevenue ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	and tblTheaterSub.theater_id = tblRevenue.theater_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	left join tblUser ON tblRevenue.user_id = tblUser.user_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	left join ("
                            ''strSQLMinMaxTSub += vbNewLine + "		select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                            ''strSQLMinMaxTSub += vbNewLine + "		from tblChecker_Movie_Setup_Dtl dtl"
                            ''strSQLMinMaxTSub += vbNewLine + "		left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no"
                            ''strSQLMinMaxTSub += vbNewLine + "		where (convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date) and dtl.collect_report_flag = 'N' "
                            ''strSQLMinMaxTSub += vbNewLine + "	) msetup on msetup.movie_id = tblRevenue.movies_id "
                            ''strSQLMinMaxTSub += vbNewLine + "	WHERE tblRevenue.revenue_date = convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) "
                            ''strSQLMinMaxTSub += vbNewLine + "		and tblRevenue.theater_id =" + Convert.ToString(dr1("theater_id"))
                            ''strSQLMinMaxTSub += vbNewLine + "		and tblRevenue.user_id =" + Convert.ToString(dr1("user_id"))
                            ''strSQLMinMaxTSub += vbNewLine + "		and tblRevenue.movies_id = msetup.movie_id and msetup.collect_report_flag = 'N'"
                            ''strSQLMinMaxTSub += vbNewLine + "	group by msetup.present_flag, tblTheaterSub.theatersub_id"
                            ''strSQLMinMaxTSub += vbNewLine + "	) a"

                            strSQLMinMaxTSub = "SELECT isnull(max(present_flag),'Y') as present_flag,"
                            strSQLMinMaxTSub += vbNewLine + "isnull(max(sumAmount),0) as MaxAmount,"
                            strSQLMinMaxTSub += vbNewLine + "isnull(min(theatersub_id) ,0) as MinTheatersub_id, "
                            strSQLMinMaxTSub += vbNewLine + "isnull(max(theatersub_id) ,0) as MaxTheatersub_id,"
                            strSQLMinMaxTSub += vbNewLine + "(SELECT isnull(count(b.movies_id) ,0) as cntCollectRpt"
                            strSQLMinMaxTSub += vbNewLine + "from "
                            strSQLMinMaxTSub += vbNewLine + "( "
                            strSQLMinMaxTSub += vbNewLine + "SELECT tblRv.movies_id"
                            strSQLMinMaxTSub += vbNewLine + "FROM tblTheater tblTt"
                            strSQLMinMaxTSub += vbNewLine + "left join tblTheaterSub tblTS ON tblTt.theater_id = tblTS.theater_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblCircuit tblC ON tblTt.circuit_id = tblC.circuit_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblRevenue tblRv ON tblTS.theatersub_id = tblRv.theatersub_id "
                            strSQLMinMaxTSub += vbNewLine + "and tblTS.theater_id = tblRv.theater_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblUser tblU ON tblRv.user_id = tblU.user_id "
                            strSQLMinMaxTSub += vbNewLine + "left join ("
                            strSQLMinMaxTSub += vbNewLine + "	select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                            strSQLMinMaxTSub += vbNewLine + "	from tblChecker_Movie_Setup_Dtl dtl"
                            strSQLMinMaxTSub += vbNewLine + "	left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no"
                            strSQLMinMaxTSub += vbNewLine + "	where (convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date) "
                            strSQLMinMaxTSub += vbNewLine + "and dtl.collect_report_flag = 'Y' "
                            strSQLMinMaxTSub += vbNewLine + ") msetup_1 on msetup_1.movie_id = tblRv.movies_id "
                            strSQLMinMaxTSub += vbNewLine + "WHERE tblRv.revenue_date = convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) "
                            strSQLMinMaxTSub += vbNewLine + "	and tblRv.theater_id =" + Convert.ToString(dr1("theater_id"))
                            strSQLMinMaxTSub += vbNewLine + "	and tblRv.user_id =" + Convert.ToString(dr1("user_id"))
                            strSQLMinMaxTSub += vbNewLine + "	and tblRv.movies_id = msetup_1.movie_id and msetup_1.collect_report_flag = 'Y'"
                            strSQLMinMaxTSub += vbNewLine + "group by tblRv.movies_id"
                            strSQLMinMaxTSub += vbNewLine + ") b) as cntCollectRpt"
                            strSQLMinMaxTSub += vbNewLine + "from "
                            strSQLMinMaxTSub += vbNewLine + "("
                            strSQLMinMaxTSub += vbNewLine + "SELECT isnull(msetup.present_flag,'Y') as present_flag,"
                            strSQLMinMaxTSub += vbNewLine + "sum(isnull(tblRevenue.revenue_amount, 0)) as sumAmount,"
                            strSQLMinMaxTSub += vbNewLine + "tblTheaterSub.theatersub_id as Theatersub_id"
                            strSQLMinMaxTSub += vbNewLine + "FROM tblTheater"
                            strSQLMinMaxTSub += vbNewLine + "left join tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblRevenue ON tblTheaterSub.theatersub_id = tblRevenue.theatersub_id "
                            strSQLMinMaxTSub += vbNewLine + "and tblTheaterSub.theater_id = tblRevenue.theater_id "
                            strSQLMinMaxTSub += vbNewLine + "left join tblUser ON tblRevenue.user_id = tblUser.user_id "
                            strSQLMinMaxTSub += vbNewLine + "left join ("
                            strSQLMinMaxTSub += vbNewLine + "	select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
                            strSQLMinMaxTSub += vbNewLine + "	from tblChecker_Movie_Setup_Dtl dtl"
                            strSQLMinMaxTSub += vbNewLine + "	left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no"
                            strSQLMinMaxTSub += vbNewLine + "	where (convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) between hdr.setup_start_date and hdr.setup_end_date) and dtl.collect_report_flag = 'N' "
                            strSQLMinMaxTSub += vbNewLine + ") msetup on msetup.movie_id = tblRevenue.movies_id "
                            strSQLMinMaxTSub += vbNewLine + "WHERE tblRevenue.revenue_date = convert(datetime,'" + Convert.ToDateTime(dr1("revenue_date")).ToString("MM/dd/" + Convert.ToDateTime(dr1("revenue_date")).Year.ToString()) + "',101) "
                            strSQLMinMaxTSub += vbNewLine + "	and tblRevenue.theater_id =" + Convert.ToString(dr1("theater_id"))
                            strSQLMinMaxTSub += vbNewLine + "	and tblRevenue.user_id =" + Convert.ToString(dr1("user_id"))
                            strSQLMinMaxTSub += vbNewLine + "	and tblRevenue.movies_id = msetup.movie_id and msetup.collect_report_flag = 'N'"
                            strSQLMinMaxTSub += vbNewLine + "group by msetup.present_flag, tblTheaterSub.theatersub_id"
                            strSQLMinMaxTSub += vbNewLine + ") a"

                            Dim drMaxMinTSub As IDataReader = cDB.GetDataAll(strSQLMinMaxTSub)
                            'Dim intMinTSub As Integer = 0
                            'Dim intMaxTSub As Integer = 0
                            Dim strPresentFlagAllDay As String = "Y"
                            Dim decMaxAmountPerDay As Decimal = 0
                            Dim intCntCollectRpt As Integer = 0
                            If drMaxMinTSub.Read() Then
                                'intMinTSub = Convert.ToInt32(drMaxMinTSub("MinTheatersub_id"))
                                'intMaxTSub = Convert.ToInt32(drMaxMinTSub("MaxTheatersub_id"))
                                decMaxAmountPerDay = Convert.ToDecimal(drMaxMinTSub("MaxAmount"))
                                strPresentFlagAllDay = drMaxMinTSub("present_flag").ToString()
                                intCntCollectRpt = Convert.ToDecimal(drMaxMinTSub("cntCollectRpt"))
                            End If
                            drMaxMinTSub.Close()

                            If Not arrTsubAndSession.Count() = Nothing Then
                                arrTsubAndSession.Clear()
                                arrTsubAndSession = New ArrayList()
                            End If

                            Dim decColRpt As Decimal = Convert.ToDecimal(ViewState("collect_report_wage")) * intCntCollectRpt
                            Dim LastMovieNameColRpt As String = ""

                            Dim chkFirstRowMoreSessionQtyFlag As String = ""
                            Dim decWage As Decimal = 0
                            Dim drWage As IDataReader = cDB.GetDataAll(strSQLwage)
                            While drWage.Read()


                                ViewState("presentLevel") = drWage("present_checker_level_id")
                                ViewState("formerLevel") = drWage("former_checker_level_id")

                                If drWage("collect_report_flag").ToString().Trim() = "N" Then
                                    If chkFirstRowMoreSessionQtyFlag = "" Then
                                        If Convert.ToInt32(drWage("countSession")) >= ViewState("session_qty") Then
                                            chkFirstRowMoreSessionQtyFlag = "Y"
                                        Else
                                            chkFirstRowMoreSessionQtyFlag = "N"
                                        End If
                                    End If

                                    cntSessionPerDay = cntSessionPerDay + Convert.ToInt32(drWage("countSession"))


                                    'If arrTsubAndSession.Count() = Nothing Then
                                    'arrTsubAndSession.Clear()
                                    'arrTsubAndSession = New ArrayList()
                                    'End If
                                    'Dim ck As Integer = 0
                                    Dim chkInsertTsubAndSession As String = "Y"
                                    If arrTsubAndSession.Count() > 0 Then
                                        For i As Integer = 0 To arrTsubAndSession.Count() - 1
                                            If drWage("theatersub_id").ToString().Trim() = arrTsubAndSession.Item(i).ToString().Split("*")(0) Then

                                                chkTheaterSubDub = "Y"
                                                'If Not arrTheaterSubDub.Count() = Nothing Then
                                                '    arrTheaterSubDub.Clear()
                                                '    arrTheaterSubDub = New ArrayList()
                                                'End If
                                                arrTheaterSubDub.Add(drWage("theatersub_id").ToString())

                                                'For i As Integer = 0 To arrTsubAndSession.Count() - 1

                                                If drWage("theatersub_id").ToString().Trim() = arrTsubAndSession.Item(i).ToString().Split("*")(0) Then
                                                    Dim oldSession As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5))
                                                    Dim newSession As Integer = oldSession + Convert.ToInt32(drWage("countSession"))
                                                    Dim oldPresent_flag As String = arrTsubAndSession.Item(i).ToString().Split("*")(2)
                                                    Dim newPresent_flag As String = ""
                                                    If oldPresent_flag = "Y" Then
                                                        newPresent_flag = "Y"
                                                    Else
                                                        newPresent_flag = drWage("present_flag").ToString().Trim()
                                                    End If
                                                    Dim oldLevel As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                                    Dim newLevel As Integer = 0
                                                    Dim newMovieId As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(7))
                                                    Dim decNewAmt As Decimal = Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6))
                                                    If oldLevel < Convert.ToInt32(drWage("movie_level_id")) Then
                                                        newLevel = oldLevel
                                                        newMovieId = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(7))

                                                    ElseIf oldLevel = Convert.ToInt32(drWage("movie_level_id")) Then
                                                        If Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6)) < Convert.ToDecimal(drWage("SumAmount")) Then
                                                            decNewAmt = Convert.ToDecimal(drWage("SumAmount"))
                                                            newLevel = Convert.ToInt32(drWage("movie_level_id"))
                                                            newMovieId = Convert.ToInt32(drWage("movies_id"))
                                                        End If
                                                    Else
                                                        newLevel = Convert.ToInt32(drWage("movie_level_id"))
                                                        newMovieId = Convert.ToInt32(drWage("movies_id"))
                                                    End If

                                                    'arrTsubAndSession
                                                    '0theatersub_id*1movie_level_id*2present_flag*
                                                    '3present_checker_level_id*4former_checker_level_id*
                                                    '5countSession*6SumAmount
                                                    strSelectSqlTsub = arrTsubAndSession.Item(i).ToString().Split("*")(0) + "*" + _
                                                    newLevel.ToString() + "*" + _
                                                    newPresent_flag + "*" + _
                                                    arrTsubAndSession.Item(i).ToString().Split("*")(3) + "*" + _
                                                    arrTsubAndSession.Item(i).ToString().Split("*")(4) + "*" + _
                                                    newSession.ToString() + "*" + _
                                                    decNewAmt.ToString() + "*" + _
                                                    newMovieId.ToString()
                                                    arrTsubAndSession.Item(i) = strSelectSqlTsub

                                                    chkInsertTsubAndSession = "N"
                                                    If maxSessionPerDay < newSession Then
                                                        maxSessionPerDay = Convert.ToInt32(drWage("countSession"))
                                                    End If

                                                    Exit For
                                                End If

                                                'Next

                                                'Exit For
                                            End If

                                        Next
                                    End If


                                    'If strTheaterSubOld = drWage("theatersub_id").ToString() Then
                                    ''chkTheaterSubDub = "Y"
                                    ''If Not arrTheaterSubDub.Count() = Nothing Then
                                    ''    arrTheaterSubDub.Clear()
                                    ''    arrTheaterSubDub = New ArrayList()
                                    ''End If
                                    ''arrTheaterSubDub.Add(drWage("theatersub_id").ToString())

                                    ''For i As Integer = 0 To arrTsubAndSession.Count() - 1

                                    ''    If drWage("theatersub_id").ToString().Trim() = arrTsubAndSession.Item(i).ToString().Split("*")(0) Then
                                    ''        Dim oldSession As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5))
                                    ''        Dim newSession As Integer = oldSession + Convert.ToInt32(drWage("countSession"))
                                    ''        Dim oldPresent_flag As String = arrTsubAndSession.Item(i).ToString().Split("*")(2)
                                    ''        Dim newPresent_flag As String = ""
                                    ''        If oldPresent_flag = "Y" Then
                                    ''            newPresent_flag = "Y"
                                    ''        Else
                                    ''            newPresent_flag = drWage("present_flag").ToString().Trim()
                                    ''        End If
                                    ''        Dim oldLevel As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                    ''        Dim newLevel As Integer = 0
                                    ''        Dim newMovieId As Integer = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(7))
                                    ''        Dim decNewAmt As Decimal = Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6))
                                    ''        If oldLevel < Convert.ToInt32(drWage("movie_level_id")) Then
                                    ''            newLevel = oldLevel
                                    ''            newMovieId = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(7))

                                    ''        ElseIf oldLevel = Convert.ToInt32(drWage("movie_level_id")) Then
                                    ''            If Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6)) < Convert.ToDecimal(drWage("SumAmount")) Then
                                    ''                decNewAmt = Convert.ToDecimal(drWage("SumAmount"))
                                    ''                newLevel = Convert.ToInt32(drWage("movie_level_id"))
                                    ''                newMovieId = Convert.ToInt32(drWage("movies_id"))
                                    ''            End If
                                    ''        Else
                                    ''            newLevel = Convert.ToInt32(drWage("movie_level_id"))
                                    ''            newMovieId = Convert.ToInt32(drWage("movies_id"))
                                    ''        End If

                                    ''        'arrTsubAndSession
                                    ''        '0theatersub_id*1movie_level_id*2present_flag*
                                    ''        '3present_checker_level_id*4former_checker_level_id*
                                    ''        '5countSession*6SumAmount
                                    ''        strSelectSqlTsub = arrTsubAndSession.Item(i).ToString().Split("*")(0) + "*" + _
                                    ''        newLevel.ToString() + "*" + _
                                    ''        newPresent_flag + "*" + _
                                    ''        arrTsubAndSession.Item(i).ToString().Split("*")(3) + "*" + _
                                    ''        arrTsubAndSession.Item(i).ToString().Split("*")(4) + "*" + _
                                    ''        newSession.ToString() + "*" + _
                                    ''        decNewAmt.ToString() + "*" + _
                                    ''        newMovieId.ToString()
                                    ''        arrTsubAndSession.Item(i) = strSelectSqlTsub

                                    ''        If maxSessionPerDay < newSession Then
                                    ''            maxSessionPerDay = Convert.ToInt32(drWage("countSession"))
                                    ''        End If

                                    ''        '--Exit For
                                    ''    End If

                                    ''Next

                                    'Else
                                    If chkInsertTsubAndSession = "Y" Then

                                        If maxSessionPerDay < Convert.ToInt32(drWage("countSession")) Then
                                            maxSessionPerDay = Convert.ToInt32(drWage("countSession"))
                                        End If

                                        strTheaterSubOld = drWage("theatersub_id").ToString()

                                        'arrTsubAndSession
                                        '0theatersub_id*1movie_level_id*2present_flag*
                                        '3present_checker_level_id*4former_checker_level_id*
                                        '5countSession*6SumAmount*7movies_id
                                        strSelectSqlTsub = drWage("theatersub_id").ToString().Trim() + "*" + _
                                        drWage("movie_level_id").ToString().Trim() + "*" + _
                                        drWage("present_flag").ToString().Trim() + "*" + _
                                        drWage("present_checker_level_id").ToString().Trim() + "*" + _
                                        drWage("former_checker_level_id").ToString().Trim() + "*" + _
                                        drWage("countSession").ToString().Trim() + "*" + _
                                        drWage("SumAmount").ToString().Trim() + "*" + _
                                        drWage("movies_id").ToString()
                                        arrTsubAndSession.Add(strSelectSqlTsub)

                                    End If
                                    decWage = 0
                                Else
                                    If LastMovieNameColRpt <> drWage("movies_id").ToString() Then
                                        If decColRpt > 0 Then
                                            decWage = Convert.ToDecimal(ViewState("collect_report_wage"))
                                            decColRpt = decColRpt - Convert.ToDecimal(ViewState("collect_report_wage"))
                                            LastMovieNameColRpt = drWage("movies_id").ToString()
                                        Else
                                            decWage = 0
                                            decColRpt = 0
                                            LastMovieNameColRpt = drWage("movies_id").ToString()
                                        End If

                                    Else
                                        decWage = 0
                                    End If

                                End If

                                'arrWageSelectAll
                                '0theatersub_id*1movie_id*2collect_report_flag*
                                '3movie_level_id*4present_flag*5present_checker_level_id*
                                '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                strSelectSqlWage = drWage("theatersub_id").ToString() + "*" + _
                                    drWage("movies_id").ToString() + "*" + _
                                    drWage("collect_report_flag").ToString() + "*" + _
                                    drWage("movie_level_id").ToString() + "*" + _
                                    drWage("present_flag").ToString() + "*" + _
                                    drWage("present_checker_level_id").ToString() + "*" + _
                                    drWage("former_checker_level_id").ToString() + "*" + _
                                    drWage("countSession").ToString() + "*" + _
                                    drWage("SumAmount").ToString() + "*" + _
                                    decWage.ToString()
                                arrWageSelectAll.Add(strSelectSqlWage)

                            End While
                            drWage.Close()

                            '---------------
                            ''start check amt when TSub dub
                            ''Dim chkTSubDubOld As Integer = 0
                            ''Dim amtTSubDubOld As Decimal = 0
                            ''Dim AllTSubDubOld As String = ""
                            ''Dim AllTSubDubNew As String = ""
                            ''Dim bOld As Integer = 0
                            ''For b As Integer = 0 To arrWageSelectAll.Count() - 1
                            ''    'arrWageSelectAll
                            ''    '0theatersub_id*1movie_id*2collect_report_flag*
                            ''    '3movie_level_id*4present_flag*5present_checker_level_id*
                            ''    '6former_checker_level_id*7countSession*8SumAmount*9Wage
                            ''    If chkTSubDubOld = 0 Then
                            ''        bOld = b
                            ''        chkTSubDubOld = Convert.ToInt32(arrWageSelectAll.Item(b).ToString().Split("*")(0))
                            ''        amtTSubDubOld = Convert.ToDecimal(arrWageSelectAll.Item(b).ToString().Split("*")(8))
                            ''        AllTSubDubOld = arrWageSelectAll.Item(b).ToString()
                            ''    Else
                            ''        If chkTSubDubOld = Convert.ToInt32(arrWageSelectAll.Item(b).ToString().Split("*")(0)) Then
                            ''            If amtTSubDubOld < Convert.ToDecimal(arrWageSelectAll.Item(b).ToString().Split("*")(8)) Then
                            ''                AllTSubDubNew = arrWageSelectAll.Item(b).ToString()
                            ''                arrWageSelectAll.Item(bOld) = AllTSubDubOld
                            ''                arrWageSelectAll.Item(b) = AllTSubDubNew

                            ''                bOld = b
                            ''                chkTSubDubOld = Convert.ToInt32(arrWageSelectAll.Item(b).ToString().Split("*")(0))
                            ''                amtTSubDubOld = Convert.ToDecimal(arrWageSelectAll.Item(b).ToString().Split("*")(8))
                            ''                AllTSubDubOld = arrWageSelectAll.Item(b).ToString()
                            ''            End If

                            ''        End If
                            ''    End If

                            ''    chkTSubDubOld = Convert.ToInt32(arrWageSelectAll.Item(b).ToString().Split("*")(0))
                            ''Next

                            ''end check amt when TSub dub
                            '----------------

                            'start sort by CountSession And MovieLevel

                            'arrTsubAndSession
                            '0theatersub_id*1movie_level_id*2present_flag*
                            '3present_checker_level_id*4former_checker_level_id*
                            '5countSession*6SumAmount*7movies_id
                            Dim oldTxt As String = ""
                            For k As Integer = 0 To arrTsubAndSession.Count() - 1
                                For i As Integer = 0 To arrTsubAndSession.Count() - 1
                                    'arrTsubAndSession.Item(i).ToString().Split("*")(1) <> "999" _

                                    If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) < ViewState("session_qty") Then

                                        If i <> arrTsubAndSession.Count() - 1 Then
                                            Dim j As Integer = i + 1
                                            'For j As Integer = (i + 1) To arrTsubAndSession.Count() - 1
                                            If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) < Convert.ToInt32(arrTsubAndSession.Item(j).ToString().Split("*")(5)) _
                                                And Convert.ToInt32(arrTsubAndSession.Item(j).ToString().Split("*")(5)) >= ViewState("session_qty") Then
                                                'And Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) < ViewState("session_qty") Then
                                                oldTxt = arrTsubAndSession.Item(i).ToString()
                                                arrTsubAndSession.Item(i) = arrTsubAndSession.Item(j)
                                                ''Dim NewTxt As String = oldTxt.IndexOf("*", 0)
                                                ''NewTxt = oldTxt.ToString().Split("*")(0) + "*" + _
                                                ''                   "999*" + _
                                                ''                   oldTxt.ToString().Split("*")(2) + "*" + _
                                                ''                   oldTxt.ToString().Split("*")(3) + "*" + _
                                                ''                   oldTxt.ToString().Split("*")(4) + "*" + _
                                                ''                   oldTxt.ToString().Split("*")(5) + "*" + _
                                                ''                   oldTxt.ToString().Split("*")(6) + "*" + _
                                                ''                   oldTxt.ToString().Split("*")(7)

                                                arrTsubAndSession.Item(j) = oldTxt
                                            End If
                                            'Next
                                        End If

                                    End If

                                Next
                            Next
                           
                            'end sort by CountSession And MovieLevel

                            '----------------
                            'start Compute wage

                            Dim iScreen As Integer = 0

                            decWage = 0
                            If cntSessionPerDay > 0 Then
                                's_if6
                                If cntSessionPerDay < ViewState("session_qty") Then '--ทั้งวันมีsessionน้อยกว่า4รอบ
                                    's_if5
                                    For m As Integer = 0 To arrWageSelectAll.Count() - 1

                                        For n As Integer = m To (arrWageSelectAll.Count - 1) '- m)
                                            If arrWageSelectAll.Item(n).ToString().Split("*")(2) = "Y" Then
                                                m = m + 1
                                            Else
                                                m = m + 1
                                                Exit For
                                            End If
                                        Next
                                        m = m - 1
                                        If arrWageSelectAll.Item(m).ToString().Split("*")(2) = "N" Then
                                            iScreen = iScreen + 1
                                            If strPresentFlagAllDay = "Y" Then
                                                decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = 1 AND checker_level_id = " + arrWageSelectAll.Item(m).ToString().Split("*")(5))
                                            Else
                                                decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = 1 AND checker_level_id = " + arrWageSelectAll.Item(m).ToString().Split("*")(6))
                                            End If
                                        Else
                                            decWage = 0
                                        End If



                                        'arrWageSelectAll
                                        '0theatersub_id*1movie_id*2collect_report_flag*
                                        '3movie_level_id*4present_flag*5present_checker_level_id*
                                        '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                        If decMaxAmountPerDay = Convert.ToDecimal(arrWageSelectAll.Item(m).ToString().Split("*")(8)) Then
                                            strSelectSqlWage = arrWageSelectAll.Item(m).ToString().Split("*")(0) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(1) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(2) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(3) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(4) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(5) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(6) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(7) + "*" + _
                                            arrWageSelectAll.Item(m).ToString().Split("*")(8) + "*" + _
                                            decWage.ToString()
                                            arrWageSelectAll.Item(m) = strSelectSqlWage
                                        End If
                                    Next
                                Else '--ถ้าทั้งวันมี Session >= 4 

                                    'start check SumAmount
                                    Dim decAmountOld As Decimal = 0
                                    Dim strDataMostAmtNew As String = ""
                                    Dim strDataMostAmtOld As String = ""
                                    'Dim arrMoreSessionQtyOrderByAmt As New ArrayList()
                                    Dim iOld As Integer = 0
                                    Dim levelOld As Integer = 0
                                    For k As Integer = 0 To arrTsubAndSession.Count() - 1
                                        decAmountOld = 0
                                        strDataMostAmtNew = ""
                                        strDataMostAmtOld = ""
                                        iOld = 0
                                        levelOld = 0
                                        For i As Integer = 0 To arrTsubAndSession.Count() - 1
                                            'arrTsubAndSession
                                            '0theatersub_id*1movie_level_id*2present_flag*
                                            '3present_checker_level_id*4former_checker_level_id*
                                            '5countSession*6SumAmount*7movies_id
                                            'arrTsubAndSession.Item(i).ToString().Split("*")(0)

                                            If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) >= ViewState("session_qty") Then
                                                If levelOld = 0 Then
                                                    levelOld = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                                End If

                                                If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1)) = levelOld Then
                                                    If decAmountOld = 0 Then
                                                        'iOld = i
                                                        'decAmountOld = Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6))
                                                        'strDataMostAmtOld = arrTsubAndSession.Item(i).ToString()
                                                        'levelOld = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                                    Else
                                                        If decAmountOld < Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6)) Then
                                                            strDataMostAmtNew = arrTsubAndSession.Item(i).ToString()
                                                            'For j As Integer = 0 To arrTsubAndSession.Count() - 1
                                                            '    If strDataMostAmtOld = arrTsubAndSession.Item(j).ToString() Then
                                                            '        arrTsubAndSession.Item(j) = strDataMostAmtNew
                                                            '    End If
                                                            'Next
                                                            arrTsubAndSession.Item(iOld) = strDataMostAmtNew
                                                            arrTsubAndSession.Item(i) = strDataMostAmtOld

                                                            'iOld = i
                                                            'decAmountOld = Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6))
                                                            'strDataMostAmtOld = arrTsubAndSession.Item(i).ToString()
                                                            'levelOld = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                                        End If
                                                    End If

                                                End If

                                                iOld = i
                                                decAmountOld = Convert.ToDecimal(arrTsubAndSession.Item(i).ToString().Split("*")(6))
                                                strDataMostAmtOld = arrTsubAndSession.Item(i).ToString()
                                                levelOld = Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(1))
                                            End If

                                        Next
                                    Next

                                    'end check SumAmount

                                    Dim iBack As Integer = arrTsubAndSession.Count()
                                    Dim cntToSession_qty As Integer = 0
                                    Dim cntToSession_qtyFlag As String = "Y"
                                    For i As Integer = 0 To arrTsubAndSession.Count() - 1
                                        If i < iBack Then
                                            's_if iBack

                                            If chkFirstRowMoreSessionQtyFlag = "N" Then
                                                '--ถ้าจอแรกน้อยกว่า4session
                                                's_if4


                                                If cntToSession_qty < ViewState("session_qty") Then
                                                    's_if3   'ถ้าบวกกันแล้วยังน้อยกว่า 4

                                                    cntToSession_qty = cntToSession_qty + Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5))

                                                    If cntToSession_qtyFlag = "Y" Then 'ให้ใส่ค่าwageตามscreenที่1
                                                        's_if2
                                                        For j As Integer = 0 To arrWageSelectAll.Count() - 1
                                                            'arrTsubAndSession
                                                            '0theatersub_id*1movie_level_id*2present_flag*
                                                            '3present_checker_level_id*4former_checker_level_id*
                                                            '5countSession*6SumAmount
                                                            'arrTsubAndSession.Item(i).ToString().Split("*")(0)

                                                            'arrWageSelectAll
                                                            '0theatersub_id*1movie_id*2collect_report_flag*
                                                            '3movie_level_id*4present_flag*5present_checker_level_id*
                                                            '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                                            'arrWageSelectAll.Item(j).ToString().Split("*")(0)
                                                            If arrWageSelectAll.Item(j).ToString().Split("*")(0) = arrTsubAndSession.Item(i).ToString().Split("*")(0) _
                                                            And arrWageSelectAll.Item(j).ToString().Split("*")(1) = arrTsubAndSession.Item(i).ToString().Split("*")(7) Then
                                                                's_if1
                                                                iScreen = iScreen + 1
                                                                If strPresentFlagAllDay = "Y" Then
                                                                    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = 1 AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                                Else
                                                                    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = 1 AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                                End If

                                                                strSelectSqlWage = arrWageSelectAll.Item(j).ToString().Split("*")(0) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(1) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(2) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(3) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(4) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(5) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(6) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(7) + "*" + _
                                                                   arrWageSelectAll.Item(j).ToString().Split("*")(8) + "*" + _
                                                                   decWage.ToString()
                                                                arrWageSelectAll.Item(j) = strSelectSqlWage

                                                                cntToSession_qtyFlag = "N"

                                                                '--Exit For
                                                            End If
                                                            'e_if1
                                                        Next


                                                        For a As Integer = (iBack - 1) To i Step -1
                                                            If cntToSession_qty < ViewState("session_qty") Then
                                                                cntToSession_qty = cntToSession_qty + Convert.ToInt32(arrTsubAndSession.Item(a).ToString().Split("*")(5))
                                                                iBack = iBack - 1
                                                            End If
                                                        Next


                                                    End If
                                                    's_if2
                                                Else
                                                    's_if3
                                                    'ถ้าบวกกันแล้วมากกว่า4แล้ว ให้ดึงค่าจาก Late ตรงๆ 20100701 
                                                    '**20100714เปลี่ยนใหม่ เป็น ถ้ายังไม่ถึง LevelQty ให้ดูจำนวนฉาย แล้วดูว่าจะดึงSessionหรือLevel


                                                    For j As Integer = 0 To arrWageSelectAll.Count() - 1
                                                        'arrTsubAndSession
                                                        '0theatersub_id*1movie_level_id*2present_flag*
                                                        '3present_checker_level_id*4former_checker_level_id*
                                                        '5countSession*6SumAmount
                                                        'arrTsubAndSession.Item(i).ToString().Split("*")(0)

                                                        'arrWageSelectAll
                                                        '0theatersub_id*1movie_id*2collect_report_flag*
                                                        '3movie_level_id*4present_flag*5present_checker_level_id*
                                                        '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                                        'arrWageSelectAll.Item(j).ToString().Split("*")(0)
                                                        If arrWageSelectAll.Item(j).ToString().Split("*")(0) = arrTsubAndSession.Item(i).ToString().Split("*")(0) _
                                                        And arrWageSelectAll.Item(j).ToString().Split("*")(1) = arrTsubAndSession.Item(i).ToString().Split("*")(7) Then


                                                            If (i + 1) < ViewState("level_qty") Then
                                                                iScreen = iScreen + 1
                                                                If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) < ViewState("session_qty") Then
                                                                    decWage = cDB.GetDataDecimal("session_amt", "tblChecker_Session", "WHERE session_qty = " + arrTsubAndSession.Item(i).ToString().Split("*")(5))
                                                                Else
                                                                    If arrTsubAndSession.Item(i).ToString().Split("*")(2) = "Y" Then
                                                                        decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                                    Else
                                                                        decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                                    End If
                                                                End If
                                                            Else
                                                                iScreen = iScreen + 1
                                                                If strPresentFlagAllDay = "Y" Then
                                                                    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                                Else
                                                                    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                                End If
                                                            End If

                                                            ''If strPresentFlagAllDay = "Y" Then
                                                            ''    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                            ''Else
                                                            ''    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                            ''End If

                                                            strSelectSqlWage = arrWageSelectAll.Item(j).ToString().Split("*")(0) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(1) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(2) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(3) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(4) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(5) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(6) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(7) + "*" + _
                                                               arrWageSelectAll.Item(j).ToString().Split("*")(8) + "*" + _
                                                               decWage.ToString()
                                                            arrWageSelectAll.Item(j) = strSelectSqlWage

                                                            cntToSession_qtyFlag = "N"

                                                            '--Exit For
                                                        End If
                                                    Next

                                                End If
                                                'e_if3
                                            Else '--ถ้าจอแรก >=4 session
                                                's_if4
                                                If (i + 1) < ViewState("level_qty") Then
                                                    'arrTsubAndSession
                                                    '0theatersub_id*1movie_level_id*2present_flag*
                                                    '3present_checker_level_id*4former_checker_level_id*
                                                    '5countSession*6SumAmount
                                                    'arrTsubAndSession.Item(i).ToString().Split("*")(0)

                                                    'arrWageSelectAll
                                                    '0theatersub_id*1movie_id*2collect_report_flag*
                                                    '3movie_level_id*4present_flag*5present_checker_level_id*
                                                    '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                                    'arrWageSelectAll.Item(j).ToString().Split("*")(0)
                                                    iScreen = iScreen + 1
                                                    If Convert.ToInt32(arrTsubAndSession.Item(i).ToString().Split("*")(5)) < ViewState("session_qty") Then
                                                        decWage = cDB.GetDataDecimal("session_amt", "tblChecker_Session", "WHERE session_qty = " + arrTsubAndSession.Item(i).ToString().Split("*")(5))
                                                    Else
                                                        If arrTsubAndSession.Item(i).ToString().Split("*")(2) = "Y" Then
                                                            decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                        Else
                                                            decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                        End If
                                                    End If
                                                Else
                                                    iScreen = iScreen + 1
                                                    If strPresentFlagAllDay = "Y" Then 'arrTsubAndSession.Item(i).ToString().Split("*")(2) = "Y" Then
                                                        decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                    Else
                                                        decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (iScreen).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                    End If
                                                End If

                                                For j As Integer = 0 To arrWageSelectAll.Count() - 1
                                                    'arrWageSelectAll
                                                    '0theatersub_id*1movie_id*2collect_report_flag*
                                                    '3movie_level_id*4present_flag*5present_checker_level_id*
                                                    '6former_checker_level_id*7countSession*8SumAmount*9Wage
                                                    'arrWageSelectAll.Item(j).ToString().Split("*")(0)
                                                    If arrWageSelectAll.Item(j).ToString().Split("*")(0) = arrTsubAndSession.Item(i).ToString().Split("*")(0) _
                                                    And arrWageSelectAll.Item(j).ToString().Split("*")(1) = arrTsubAndSession.Item(i).ToString().Split("*")(7) Then
                                                        '' ''If strPresentFlagAllDay = "Y" Then
                                                        '' ''    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + (i + 1).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(3))
                                                        '' ''Else
                                                        '' ''    decWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + (i + 1).ToString() + " AND checker_level_id = " + arrTsubAndSession.Item(i).ToString().Split("*")(4))
                                                        '' ''End If

                                                        strSelectSqlWage = arrWageSelectAll.Item(j).ToString().Split("*")(0) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(1) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(2) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(3) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(4) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(5) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(6) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(7) + "*" + _
                                                           arrWageSelectAll.Item(j).ToString().Split("*")(8) + "*" + _
                                                           decWage.ToString()
                                                        arrWageSelectAll.Item(j) = strSelectSqlWage
                                                        '--Exit For
                                                    End If
                                                Next

                                            End If
                                            's_if4
                                        End If
                                        's_if iBack

                                        ''For m As Integer = i To (arrWageSelectAll.Count - i)
                                        ''    If arrWageSelectAll.Item(i).ToString().Split("*")(0) = arrWageSelectAll.Item(i + 1).ToString().Split("*")(0) _
                                        ''    And arrWageSelectAll.Item(i).ToString().Split("*")(2) = "N" Then
                                        ''        i = i + 1
                                        ''    End If
                                        ''Next

                                    Next


                                End If
                                'e_if5


                            End If
                            'e_if6
                            'end Compute wage


                        End If
                        'end selectWage













                        If (TotalRow1.Cells.Count > 0) Then
                            'ต่อท้าย
                            '''''tblDetail.Rows.Add(TotalRow1)



                            For i As Integer = intRuningCells To (intMaxSesion * 2) + 1
                                intRuningCells += 1
                                TotalRow1.Cells.Add(New TableCell)
                                TotalRow1.BackColor = System.Drawing.Color.White
                                TotalRow1.Cells(intRuningCells).Font.Bold = False
                                TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                                TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                                TotalRow1.Cells(intRuningCells).RowSpan = 1
                                TotalRow1.Cells(intRuningCells).Font.Size = 9
                                TotalRow1.Cells(intRuningCells).Text = ""

                            Next

                            intRuningCells += 1
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.BackColor = Color.White
                            TotalRow1.Cells(intRuningCells).Font.Bold = True
                            TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                            TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                            TotalRow1.Cells(intRuningCells).RowSpan = 1
                            TotalRow1.Cells(intRuningCells).Font.Size = 9
                            TotalRow1.Cells(intRuningCells).Text = Format(intSessionCount, "#,##0")
                            'Format(decSessionCountRow, "#,##0") '--session
                            sumIntSessionCount = sumIntSessionCount + intSessionCount
                            intSessionCount = 0

                            intRuningCells += 1
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.BackColor = Color.White
                            TotalRow1.Cells(intRuningCells).Font.Bold = True
                            TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                            TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                            TotalRow1.Cells(intRuningCells).RowSpan = 1
                            TotalRow1.Cells(intRuningCells).Font.Size = 9
                            TotalRow1.Cells(intRuningCells).Text = Format(decWageQty, "#,##0")
                            '"" '--wage

                            Dim strMId As String = arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(0)
                            Dim strMName As String = arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(1)
                            Dim intWageOld As Integer = Convert.ToInt32(arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(2))
                            Dim intWageNew As Integer = intWageOld + decWageQty
                            arrMovieAndWage.Item(ViewState("iMovieAndWage")) = strMId + "_" + strMName + "_" + intWageNew.ToString()

                            intRuningCells += 1
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.BackColor = Color.White
                            TotalRow1.Cells(intRuningCells).Font.Bold = False
                            TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                            TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                            TotalRow1.Cells(intRuningCells).RowSpan = 1
                            TotalRow1.Cells(intRuningCells).Font.Size = 9
                            TotalRow1.Cells(intRuningCells).Text = decSumBaht.ToString("#,##0")

                            intRuningCells += 1
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.BackColor = Color.White
                            TotalRow1.Cells(intRuningCells).Font.Bold = False
                            TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                            TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                            TotalRow1.Cells(intRuningCells).RowSpan = 1
                            TotalRow1.Cells(intRuningCells).Font.Size = 9
                            TotalRow1.Cells(intRuningCells).Text = intAdms.ToString("#,##0")

                            intRuningCells += 1
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.Cells(intRuningCells).BackColor = Color.White
                            TotalRow1.Cells(intRuningCells).ForeColor = Color.Blue
                            TotalRow1.Cells(intRuningCells).Font.Bold = True
                            TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Left
                            TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                            TotalRow1.Cells(intRuningCells).RowSpan = 1
                            TotalRow1.Cells(intRuningCells).Font.Size = 9
                            TotalRow1.Cells(intRuningCells).Text = strChecker
                            tblDetail.Rows.Add(TotalRow1)

                            ViewState("CheckerName") = strChecker
                        End If

                        'ใส่ Date
                        If (htbDate(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")) Is Nothing) Then
                            htbDate(Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")) = "check"
                            sumIntSessionCount = 0
                            strTheaterSubIdCheck = ""
                            decNextWageQty = 1 '---

                            'new sum by date

                            If strOldDay = "1" Then
                                strOldDay = Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")
                            End If

                            'If (decSumBahtByDate > 0) Then
                            If Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy") <> strOldDay Then
                                strOldDay = Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")

                                TotalRow1 = New TableRow()

                                TotalRow1.Cells.Add(New TableCell)
                                TotalRow1.Cells(0).BackColor = Color.White
                                TotalRow1.Cells(0).ColumnSpan = (intMaxSesion * 2) + 6 + 2
                                TotalRow1.Cells(0).Text = ""

                                TotalRow1.Cells.Add(New TableCell)
                                TotalRow1.Cells(1).BackColor = System.Drawing.Color.FromName("#CADCEF")
                                TotalRow1.Cells(1).ForeColor = Color.Red
                                TotalRow1.Cells(1).Font.Bold = True
                                TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
                                TotalRow1.Cells(1).ColumnSpan = 1
                                TotalRow1.Cells(1).RowSpan = 1
                                TotalRow1.Cells(1).Font.Size = 9
                                TotalRow1.Cells(1).Text = decSumBahtByDate.ToString("#,##0")

                                TotalRow1.Cells.Add(New TableCell)
                                TotalRow1.Cells(2).BackColor = System.Drawing.Color.FromName("#CADCEF")
                                TotalRow1.Cells(2).ForeColor = Color.Red
                                TotalRow1.Cells(2).Font.Bold = True
                                TotalRow1.Cells(2).HorizontalAlign = HorizontalAlign.Right
                                TotalRow1.Cells(2).ColumnSpan = 1
                                TotalRow1.Cells(2).RowSpan = 1
                                TotalRow1.Cells(2).Font.Size = 9
                                TotalRow1.Cells(2).Text = intAdmsByDate.ToString("#,##0")
                                tblDetail.Rows.Add(TotalRow1)

                                decSumBahtByDate = 0
                                intAdmsByDate = 0
                                intRuningCells = 0
                                ''''''''''''''''''''
                            End If
                            ''''01-Apr-09
                            TotalRow1 = New TableRow()
                            TotalRow1.Cells.Add(New TableCell)
                            TotalRow1.Cells(0).BackColor = Color.LightYellow
                            TotalRow1.Cells(0).ForeColor = Color.Red
                            TotalRow1.Cells(0).Font.Bold = True
                            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Left
                            TotalRow1.Cells(0).ColumnSpan = 10 + (intMaxSesion * 2) + 2
                            TotalRow1.Cells(0).RowSpan = 1
                            TotalRow1.Cells(0).Height = 20
                            TotalRow1.Cells(0).Font.Size = 9
                            TotalRow1.Cells(0).Text = Convert.ToDateTime(dr1("revenue_date")).ToString("dd-MMM-yy")
                            tblDetail.Rows.Add(TotalRow1)


                            decSumBahtByDate = 0
                            intAdmsByDate = 0

                        End If


                        'ส่วนหัว
                        TotalRow1 = New TableRow()
                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.BackColor = Color.White
                        TotalRow1.Cells(0).Font.Bold = False
                        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Left
                        TotalRow1.Cells(0).ColumnSpan = 2
                        TotalRow1.Cells(0).RowSpan = 1
                        TotalRow1.Cells(0).Font.Size = 9
                        TotalRow1.Cells(0).Text = Convert.ToString(dr1("TName"))

                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.BackColor = Color.White
                        TotalRow1.Cells(1).Font.Bold = False
                        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Left
                        TotalRow1.Cells(1).ColumnSpan = 2
                        TotalRow1.Cells(1).RowSpan = 1
                        TotalRow1.Cells(1).Font.Size = 9
                        TotalRow1.Cells(1).Text = Convert.ToString(dr1("MName"))

                        '--arr 

                        For iMName As Integer = 0 To arrMovieAndWage.Count() - 1
                            If arrMovieAndWage.Item(iMName).ToString().Split("_")(1) = Convert.ToString(dr1("MName")) Then
                                ViewState("iMovieAndWage") = iMName
                                '--Exit For
                            End If

                        Next











                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.BackColor = Color.White
                        TotalRow1.Cells(2).Font.Bold = False
                        TotalRow1.Cells(2).HorizontalAlign = HorizontalAlign.Center
                        TotalRow1.Cells(2).ColumnSpan = 2
                        TotalRow1.Cells(2).RowSpan = 1
                        TotalRow1.Cells(2).Font.Size = 9

                        strChecker = Convert.ToString(dr1("user_name"))

                        intRuningCells = 2
                        decSumBaht = 0

                        intAdms = 0
                        decSessionCountRow = 0

                        CountSound = 1
                        movieSoundcheck1 = ""
                        movieSound = ""

                        tblDetail.Rows.Add(TotalRow1)
                    End If ''''''
                    'รอบหนังตัวอย่าง

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = False
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = Convert.ToDecimal(dr1("SumAmount")).ToString("#,##0")

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = False
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = Convert.ToInt32(dr1("SumAdms")).ToString("#,##0")

                    decSumBaht += Convert.ToDecimal(dr1("SumAmount"))
                    intAdms += Convert.ToInt32(dr1("SumAdms"))
                    decSessionCountRow = cDB.CheckIsNullInteger(dr1("countSession"))
                    intSessionCount += 1 '''---New

                    decSumBahtByDate += Convert.ToDecimal(dr1("SumAmount")) 'decSumBahtByDate + decSumBaht
                    intAdmsByDate += Convert.ToInt32(dr1("SumAdms")) 'intAdmsByDate + intAdms


                    If CountSound = 1 Then
                        movieSound = dr1("sound_type").ToString.Trim
                        movieSoundcheck1 = ""
                    End If

                    If movieSoundcheck1 <> "E/T" Then
                        If movieSound = dr1("sound_type").ToString.Trim Then
                            If dr1("movie_system") = "35 มม." And dr1("sound_type") = "ต้นฉบับ" Then
                                movieSoundcheck1 = "E"
                            ElseIf dr1("movie_system") = "35 มม." And dr1("sound_type") = "พากย์ไทย" Then
                                movieSoundcheck1 = "T"
                            ElseIf dr1("movie_system") = "ดิจิตอล" Then
                                movieSoundcheck1 = "D"
                            ElseIf dr1("movie_system") = "3 มิติ" Then
                                movieSoundcheck1 = "3D"
                            End If
                        Else
                            movieSoundcheck1 = "E/T"
                        End If
                    End If


                    TotalRow1.Cells(2).Text = movieSoundcheck1


                    movieSound = dr1("sound_type").ToString.Trim
                    CountSound += 1



                    '----คิด wage เคยอยู่ตรงนี้
                    For j As Integer = 0 To arrWageSelectAll.Count() - 1
                        'arrWageSelectAll
                        '0theatersub_id*1movie_id*2collect_report_flag*
                        '3movie_level_id*4present_flag*5present_checker_level_id*
                        '6former_checker_level_id*7countSession*8SumAmount*9Wage
                        'arrWageSelectAll.Item(j).ToString().Split("*")(0)
                        If arrWageSelectAll.Item(j).ToString().Split("*")(0) = Convert.ToString(dr1("theatersub_id")) _
                        And arrWageSelectAll.Item(j).ToString().Split("*")(1) = Convert.ToString(dr1("movie_id")) Then
                            decWageQty = Convert.ToDecimal(arrWageSelectAll.Item(j).ToString().Split("*")(9))

                            '--Exit For
                        End If
                    Next


                    ' '' ''end wage



                End While
                dr1.Close()




                If (TotalRow1.Cells.Count > 0) Then

                    For i As Integer = intRuningCells To intMaxSesion * 2 + 1
                        intRuningCells += 1
                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.BackColor = System.Drawing.Color.White
                        TotalRow1.Cells(intRuningCells).Font.Bold = False
                        TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Center
                        TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                        TotalRow1.Cells(intRuningCells).RowSpan = 1
                        TotalRow1.Cells(intRuningCells).Font.Size = 9
                        TotalRow1.Cells(intRuningCells).Text = ""
                    Next

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = True
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = Format(intSessionCount, "#,##0") 'Format(decSessionCountRow, "#,##0") 'cDB.CheckIsNullInteger(dr1("countSession")).ToString("#,##0") '"" '--session

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = True
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = Format(decWageQty, "#,##0")
                    '"" '--wage

                    Dim strMId As String = arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(0)
                    Dim strMName As String = arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(1)
                    Dim intWageOld As Integer = Convert.ToInt32(arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(2))
                    Dim intWageNew As Integer = intWageOld + decWageQty
                    arrMovieAndWage.Item(ViewState("iMovieAndWage")) = strMId + "_" + strMName + "_" + intWageNew.ToString()


                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = False
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = decSumBaht.ToString("#,##0")

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).Font.Bold = False
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 1
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = intAdms.ToString("#,##0")

                    intRuningCells += 1
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.Cells(intRuningCells).BackColor = Color.White
                    TotalRow1.Cells(intRuningCells).ForeColor = Color.Blue
                    TotalRow1.Cells(intRuningCells).Font.Bold = True
                    TotalRow1.Cells(intRuningCells).HorizontalAlign = HorizontalAlign.Left
                    TotalRow1.Cells(intRuningCells).ColumnSpan = 2
                    TotalRow1.Cells(intRuningCells).RowSpan = 1
                    TotalRow1.Cells(intRuningCells).Font.Size = 9
                    TotalRow1.Cells(intRuningCells).Text = strChecker
                    tblDetail.Rows.Add(TotalRow1)
                    ViewState("CheckerName") = strChecker

                    'new sum by date
                    If (decSumBahtByDate > 0) Then
                        TotalRow1 = New TableRow()

                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(0).BackColor = Color.White
                        TotalRow1.Cells(0).ColumnSpan = (intMaxSesion * 2) + 6 + 2
                        TotalRow1.Cells(0).Text = ""

                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(1).BackColor = System.Drawing.Color.FromName("#CADCEF")
                        TotalRow1.Cells(1).ForeColor = Color.Red
                        TotalRow1.Cells(1).Font.Bold = True
                        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
                        TotalRow1.Cells(1).ColumnSpan = 1
                        TotalRow1.Cells(1).RowSpan = 1
                        TotalRow1.Cells(1).Font.Size = 9
                        TotalRow1.Cells(1).Text = decSumBahtByDate.ToString("#,##0")

                        TotalRow1.Cells.Add(New TableCell)
                        TotalRow1.Cells(2).BackColor = System.Drawing.Color.FromName("#CADCEF")
                        TotalRow1.Cells(2).ForeColor = Color.Red
                        TotalRow1.Cells(2).Font.Bold = True
                        TotalRow1.Cells(2).HorizontalAlign = HorizontalAlign.Right
                        TotalRow1.Cells(2).ColumnSpan = 1
                        TotalRow1.Cells(2).RowSpan = 1
                        TotalRow1.Cells(2).Font.Size = 9
                        TotalRow1.Cells(2).Text = intAdmsByDate.ToString("#,##0")
                        tblDetail.Rows.Add(TotalRow1)

                        decSumBahtByDate = 0
                        intAdmsByDate = 0
                        intRuningCells = 0
                        ''''''''''''''''''''
                    End If
                End If

                'เพิ่มตาราง sum
                Dim tblSum As New System.Web.UI.WebControls.Table
                tblSum.Font.Name = "Tahoma"
                ShowReportSum(tblSum, Convert.ToInt32(drTop("Theater_Id")))

                Dim tbl1Row As New System.Web.UI.WebControls.Table
                tbl1Row.CssClass = "txtUnderline"
                Dim Rowtbl1Row As New System.Web.UI.WebControls.TableRow()
                Rowtbl1Row.Cells.Add(New TableCell)
                Rowtbl1Row.Cells(0).BackColor = Color.White
                Rowtbl1Row.Cells(0).ColumnSpan = 5 
                Rowtbl1Row.Cells(0).Font.Size = 7
                Rowtbl1Row.Cells(0).Text = ""
                Rowtbl1Row.Cells(0).Height = 10
                Rowtbl1Row.Cells(0).CssClass = "txtUnderline"
                tbl1Row.Rows.Add(Rowtbl1Row)

                Dim tbl2Row As New System.Web.UI.WebControls.Table
                tbl2Row.CssClass = "txtUnderline"
                Dim Rowtbl2Row As New System.Web.UI.WebControls.TableRow()
                Rowtbl2Row.Cells.Add(New TableCell)
                Rowtbl2Row.Cells(0).BackColor = Color.White
                Rowtbl2Row.Cells(0).ColumnSpan = 5
                Rowtbl2Row.Cells(0).Font.Size = 7
                Rowtbl2Row.Cells(0).Text = ""
                Rowtbl2Row.Cells(0).Height = 10
                Rowtbl2Row.Cells(0).CssClass = "txtUnderline"
                tbl2Row.Rows.Add(Rowtbl2Row)

                Dim tbl3Row As New System.Web.UI.WebControls.Table
                tbl3Row.CssClass = "txtUnderline"
                Dim Rowtbl3Row As New System.Web.UI.WebControls.TableRow()
                Rowtbl3Row.Cells.Add(New TableCell)
                Rowtbl3Row.Cells(0).BackColor = Color.White
                Rowtbl3Row.Cells(0).ColumnSpan = 5
                Rowtbl3Row.Cells(0).Font.Size = 7
                Rowtbl3Row.Cells(0).Text = ""
                Rowtbl3Row.Cells(0).Height = 10
                Rowtbl3Row.Cells(0).CssClass = "txtUnderline"
                tbl3Row.Rows.Add(Rowtbl3Row)

                'check movie
                Dim tblCheck As New System.Web.UI.WebControls.Table
                tblCheck.Font.Name = "Tahoma"
                AddTableCheck(tblCheck)


                'Add Table
                Dim trTop As New TableRow()
                trTop = New TableRow()
                trTop.Cells.Add(New TableCell)
                trTop.Cells(0).Controls.Add(tblDetail)
                trTop.Cells(0).Controls.Add(tbl1Row)
                trTop.Cells(0).Controls.Add(tblSum)
                trTop.Cells(0).Controls.Add(tbl2Row)
                trTop.Cells(0).Controls.Add(tblCheck)
                trTop.Cells(0).Controls.Add(tbl3Row)
                trTop.Cells(0).VerticalAlign = VerticalAlign.Top
                tblTop.Rows.Add(trTop)

                'trTop = New TableRow()
                'trTop.Cells.Add(New TableCell)

                'trTop.Cells(0).VerticalAlign = VerticalAlign.Top
                'tblTop.Rows.Add(trTop)

                'trTop = New TableRow()
                'trTop.Cells.Add(New TableCell)
                'trTop.Cells(0).Controls.Add(tbl1Row)
                'trTop.Cells(0).VerticalAlign = VerticalAlign.Top
                'tblTop.Rows.Add(trTop)

                'trTop = New TableRow()
                'trTop.Cells.Add(New TableCell)
                'trTop.Cells(0).Controls.Add(tblCheck)
                'trTop.Cells(0).VerticalAlign = VerticalAlign.Top
                'tblTop.Rows.Add(trTop)

                'trTop = New TableRow()
                'trTop.Cells.Add(New TableCell)
                'trTop.Cells(0).Text = ""
                'trTop.Cells(0).VerticalAlign = VerticalAlign.Top
                'tblTop.Rows.Add(trTop)

            Else
                TotalRow1 = New TableRow()
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(0).BackColor = Color.White
                TotalRow1.Cells(0).Font.Bold = False
                TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
                'TotalRow1.Cells(0).ColumnSpan = 1
                'TotalRow1.Cells(0).RowSpan = 1
                TotalRow1.Cells(0).Font.Size = 9
                TotalRow1.Cells(0).Text = "Data not found."
                tblTop.Rows.Add(TotalRow1)
            End If

        End While
        drTop.Close()

        Dim trTop1 As New TableRow()
        trTop1.Cells.Add(New TableCell)
        trTop1.Cells(0).ColumnSpan = 10 + (intMaxSesion * 2) + 2
        trTop1.Cells(0).VerticalAlign = VerticalAlign.Middle
        trTop1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        trTop1.Cells(0).Font.Bold = True
        trTop1.Cells(0).Font.Size = 13
        trTop1.Cells(0).BackColor = System.Drawing.Color.FromName("#C2D8FE")
        trTop1.Cells(0).ForeColor = Color.Black
        trTop1.Cells(0).Text = "กกก"
        trTop1.Cells(0).Text = "Title : SDT Checker wage and Late Show by Theatre" + _
         ",  Date : " + _
        Convert.ToDateTime(Session("strDateComp")).ToString("ddd dd-MMM-yyyy") _
        + " To " + Convert.ToDateTime(Session("strDateEndComp")).ToString("ddd dd-MMM-yyyy")
        tblTitle.Rows.Add(trTop1)
    End Sub

    Private Sub ShowReportSum(ByVal tblSum As System.Web.UI.WebControls.Table, ByVal Theater_id As Integer)
        'Dim tblSum As New System.Web.UI.WebControls.Table()
        tblSum.ForeColor = Color.Black
        tblSum.BackColor = System.Drawing.Color.FromName("#c3cad6")
        tblSum.Font.Bold = True
        tblSum.Font.Size = 9
        tblSum.BorderWidth = 1
        tblSum.BorderColor = Color.Gray
        tblSum.CellPadding = 3
        tblSum.CellSpacing = 0
        tblSum.GridLines = GridLines.Both
        tblSum.Width = 500

        Dim TotalRow1 As New TableRow()
        For i As Integer = 0 To 3
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(i).BackColor = System.Drawing.Color.FromName("#c3cad6")
            TotalRow1.Cells(i).Font.Bold = True
            TotalRow1.Cells(i).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(i).Font.Size = 9
        Next
        TotalRow1.Cells(0).Text = "Date"
        TotalRow1.Cells(1).Text = "Late Show"
        TotalRow1.Cells(2).Text = "Title"
        TotalRow1.Cells(2).ColumnSpan = 2
        TotalRow1.Cells(3).Text = "Expense"
        tblSum.Rows.Add(TotalRow1)

        Dim cDB As New cDatabase()
        Dim wkSQL As String = ""

        Dim dtStart As DateTime = Convert.ToDateTime(Session("strDateComp"))
        Dim dtEnd As DateTime = Convert.ToDateTime(Session("strDateEndComp"))

        Dim ayl As New ArrayList()
        Dim htb As New Hashtable()
        While (dtStart <= dtEnd)
            TotalRow1 = New TableRow()

            ''wkSQL = " SELECT     top 1 dbo.tblRevenue.revenue_date"
            ''wkSQL += " , dbo.tblMovie.movie_nameen"
            ''wkSQL += " , dbo.tblRevenue.movies_id"
            ''wkSQL += " , dbo.tblRevenue.revenue_Time"
            ''wkSQL += " , replace(dbo.tblRevenue.revenue_Time,':','') IntTime	"
            ''wkSQL += " , SUM(dbo.tblRevenue.revenue_amount) AS sum_revenue_amount"
            ''wkSQL += " ,isnull("
            ''wkSQL += " (select expense_amt "
            ''wkSQL += " from tblMovie_Late_Show"
            ''wkSQL += " where replace(replace(replace(replace(replace(replace(dbo.tblRevenue.revenue_Time,'00:','24:'),'01:','25:'),'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:')"
            ''wkSQL += " 	>=replace(replace(replace(replace(replace(replace(substring(show_time_from,1,2)+':'+substring(show_time_from,3,2),'00:','24:'),'01:','25:'),'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:')"
            ''wkSQL += " and replace(replace(replace(replace(replace(replace(dbo.tblRevenue.revenue_Time,'00:','24:'),'01:','25:'),'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:')"
            ''wkSQL += " <=replace(replace(replace(replace(replace(replace(substring(show_time_to,1,2)+':'+substring(show_time_to,3,2),'00:','24:'),'01:','25:'),'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:')) ,0) as expense "
            ''wkSQL += " FROM         dbo.tblMovie RIGHT OUTER JOIN"
            ''wkSQL += " dbo.tblTheater INNER JOIN"
            ''wkSQL += " dbo.tblRevenue ON dbo.tblTheater.theater_id = dbo.tblRevenue.theater_id ON dbo.tblMovie.movie_id = dbo.tblRevenue.movies_id"
            ''wkSQL += " WHERE     (dbo.tblRevenue.revenue_date = CONVERT(datetime, '" + dtStart.ToString("MM/dd/" + dtStart.Year.ToString()) + "', 101))"
            ''wkSQL += " and tblRevenue.theater_id = " + Convert.ToString(Theater_id)
            ''wkSQL += " GROUP BY dbo.tblRevenue.revenue_date"
            ''wkSQL += " , dbo.tblMovie.movie_nameen"
            ''wkSQL += " , dbo.tblRevenue.movies_id"
            ''wkSQL += " , dbo.tblRevenue.revenue_Time"
            ''wkSQL += " , replace(dbo.tblRevenue.revenue_Time,':','')"
            ''wkSQL += " ORDER BY replace(replace(replace(replace(replace(replace(revenue_Time,'00:','24:'),'01:','25:'),'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:') DESC,SUM(dbo.tblRevenue.revenue_amount)  DESC"

            wkSQL = "SELECT top 1 dbo.tblRevenue.revenue_date , dbo.tblMovie.movie_nameen ,"
            wkSQL += vbNewLine + " dbo.tblRevenue.movies_id , dbo.tblRevenue.revenue_Time ,"
            wkSQL += vbNewLine + " replace(dbo.tblRevenue.revenue_Time,':','') IntTime ,"
            wkSQL += vbNewLine + " SUM(dbo.tblRevenue.revenue_amount) AS sum_revenue_amount ,"
            wkSQL += vbNewLine + " isnull( (select expense_amt  "
            wkSQL += vbNewLine + " from tblMovie_Late_Show "
            wkSQL += vbNewLine + "where replace(replace(replace(replace(replace(replace(dbo.tblRevenue.revenue_Time"
            wkSQL += vbNewLine + ",'00:','24:')"
            wkSQL += vbNewLine + ",'01:','25:')"
            wkSQL += vbNewLine + ",'02:','26:')"
            wkSQL += vbNewLine + ",'03:','27:')"
            wkSQL += vbNewLine + ",'04:','28:')"
            wkSQL += vbNewLine + ",'05:','29:')"
            wkSQL += vbNewLine + ">=replace(replace(replace(replace(replace(replace(substring(show_time_from,1,2)+':'"
            wkSQL += vbNewLine + "+substring(show_time_from,3,2)"
            wkSQL += vbNewLine + ",'00:','24:')"
            wkSQL += vbNewLine + ",'01:','25:')"
            wkSQL += vbNewLine + ",'02:','26:')"
            wkSQL += vbNewLine + ",'03:','27:')"
            wkSQL += vbNewLine + ",'04:','28:')"
            wkSQL += vbNewLine + ",'05:','29:') "
            wkSQL += vbNewLine + "and replace(replace(replace(replace(replace(replace(dbo.tblRevenue.revenue_Time"
            wkSQL += vbNewLine + ",'00:','24:')"
            wkSQL += vbNewLine + ",'01:','25:')"
            wkSQL += vbNewLine + ",'02:','26:')"
            wkSQL += vbNewLine + ",'03:','27:')"
            wkSQL += vbNewLine + ",'04:','28:')"
            wkSQL += vbNewLine + ",'05:','29:') "
            wkSQL += vbNewLine + "<=replace(replace(replace(replace(replace(replace(substring(show_time_to,1,2)+':'"
            wkSQL += vbNewLine + "+substring(show_time_to,3,2)"
            wkSQL += vbNewLine + ",'00:','24:')"
            wkSQL += vbNewLine + ",'01:','25:')"
            wkSQL += vbNewLine + ",'02:','26:')"
            wkSQL += vbNewLine + ",'03:','27:')"
            wkSQL += vbNewLine + ",'04:','28:')"
            wkSQL += vbNewLine + ",'05:','29:')) ,0) as expense  "
            wkSQL += vbNewLine + "FROM tblMovie "
            wkSQL += vbNewLine + "RIGHT OUTER JOIN tblTheater "
            wkSQL += vbNewLine + "INNER JOIN tblRevenue "
            wkSQL += vbNewLine + "ON tblTheater.theater_id = tblRevenue.theater_id "
            wkSQL += vbNewLine + "ON tblMovie.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + "left join ("
            wkSQL += vbNewLine + "	select dtl.movie_id, dtl.movie_level_id, dtl.present_flag, dtl.collect_report_flag, hdr.*"
            wkSQL += vbNewLine + "	from tblChecker_Movie_Setup_Dtl dtl"
            wkSQL += vbNewLine + "	left join tblChecker_Movie_Setup_Hdr hdr on dtl.movie_setup_no = hdr.movie_setup_no"
            wkSQL += vbNewLine + "	where (CONVERT(datetime, '" + dtStart.ToString("MM/dd/" + dtStart.Year.ToString()) + "', 101) between hdr.setup_start_date and hdr.setup_end_date) "
            wkSQL += vbNewLine + "and dtl.collect_report_flag = 'N' "
            wkSQL += vbNewLine + ") msetup_1 on msetup_1.movie_id = tblRevenue.movies_id "
            wkSQL += vbNewLine + "WHERE (dbo.tblRevenue.revenue_date = CONVERT(datetime, '" + dtStart.ToString("MM/dd/" + dtStart.Year.ToString()) + "', 101)) "
            wkSQL += vbNewLine + "and tblRevenue.theater_id = " + Convert.ToString(Theater_id) + " and msetup_1.collect_report_flag = 'N'"
            wkSQL += vbNewLine + "GROUP BY dbo.tblRevenue.revenue_date , dbo.tblMovie.movie_nameen "
            wkSQL += vbNewLine + ", dbo.tblRevenue.movies_id , dbo.tblRevenue.revenue_Time "
            wkSQL += vbNewLine + ", replace(dbo.tblRevenue.revenue_Time,':','') "
            wkSQL += vbNewLine + "ORDER BY replace(replace(replace(replace(replace(replace(revenue_Time,'00:','24:'),'01:','25:')"
            wkSQL += vbNewLine + ",'02:','26:'),'03:','27:'),'04:','28:'),'05:','29:') DESC"
            wkSQL += vbNewLine + ",SUM(dbo.tblRevenue.revenue_amount) DESC"

            Dim dr1 As IDataReader = cDB.GetDataAll(wkSQL)
            If dr1.Read = True Then
                TotalRow1 = New TableRow()
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.BackColor = System.Drawing.Color.White
                TotalRow1.Cells(0).Font.Bold = False
                TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(0).Font.Size = 9
                TotalRow1.Cells(0).Text = dtStart.ToString("dd-MMM-yyyy")

                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.BackColor = System.Drawing.Color.White
                TotalRow1.Cells(1).Font.Bold = False
                TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(1).Font.Size = 9
                TotalRow1.Cells(1).Text = Convert.ToString(dr1("revenue_Time"))

                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(2).ForeColor = System.Drawing.Color.Black
                TotalRow1.Cells(2).BackColor = System.Drawing.Color.White
                TotalRow1.Cells(2).Font.Bold = False
                TotalRow1.Cells(2).HorizontalAlign = HorizontalAlign.Left
                TotalRow1.Cells(2).Font.Size = 9
                TotalRow1.Cells(2).ColumnSpan = 2
                TotalRow1.Cells(2).Text = Convert.ToString(dr1("movie_nameen"))

                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(3).BackColor = System.Drawing.Color.White
                TotalRow1.Cells(3).ForeColor = System.Drawing.Color.Black
                TotalRow1.Cells(3).Font.Bold = True
                TotalRow1.Cells(3).HorizontalAlign = HorizontalAlign.Right
                TotalRow1.Cells(3).Font.Size = 9
                TotalRow1.Cells(3).Text = Convert.ToDecimal(dr1("expense")).ToString("#,##0.00")

                tblSum.Rows.Add(TotalRow1)

                If (htb(Convert.ToString(dr1("movie_nameen"))) Is Nothing) Then
                    If (Convert.ToDecimal(dr1("expense")) <> 0) Then
                        htb(Convert.ToString(dr1("movie_nameen"))) = Convert.ToDecimal(dr1("expense"))
                        ayl.Add(Convert.ToString(dr1("movie_nameen")))
                    End If
                Else
                    htb(Convert.ToString(dr1("movie_nameen"))) = Convert.ToDecimal(htb(Convert.ToString(dr1("movie_nameen")))) _
                                                                + Convert.ToDecimal(dr1("expense"))
                End If
            End If
            dr1.Close()
            dtStart = dtStart.AddDays(1)
        End While

        If (ayl.Count > 0) Then
            'TotalRow1 = New TableRow()
            'TotalRow1.Cells.Add(New TableCell)
            'TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
            'TotalRow1.Cells(0).ForeColor = System.Drawing.Color.Red
            'TotalRow1.Cells(0).ColumnSpan = 5
            'TotalRow1.Cells(0).RowSpan = 1
            'TotalRow1.Cells(0).Font.Bold = True
            'TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            'TotalRow1.Cells(0).Font.Size = 9
            'TotalRow1.Cells(0).Text = ""
            'TotalRow1.Cells(0).Height = 10
            'tblSum.Rows.Add(TotalRow1)

            TotalRow1 = New TableRow()
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
            TotalRow1.Cells(0).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(0).ColumnSpan = 2
            TotalRow1.Cells(0).RowSpan = ayl.Count + 2
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Top
            TotalRow1.Cells(0).Font.Size = 9
            TotalRow1.Cells(0).Text = "Total"
            tblSum.Rows.Add(TotalRow1)

            Dim decSumTotal As Decimal = 0
            For i As Integer = 0 To ayl.Count - 1
                TotalRow1 = New TableRow()
                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
                TotalRow1.Cells(0).ForeColor = System.Drawing.Color.Red
                TotalRow1.Cells(0).ColumnSpan = 2
                TotalRow1.Cells(0).Font.Bold = True
                TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
                TotalRow1.Cells(0).Font.Size = 9
                TotalRow1.Cells(0).Text = Convert.ToString(ayl.Item(i))

                TotalRow1.Cells.Add(New TableCell)
                TotalRow1.Cells(1).BackColor = System.Drawing.Color.White
                TotalRow1.Cells(1).ForeColor = System.Drawing.Color.Red
                TotalRow1.Cells(1).ColumnSpan = 1
                TotalRow1.Cells(1).Font.Bold = True
                TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
                TotalRow1.Cells(1).Font.Size = 9
                TotalRow1.Cells(1).Text = Convert.ToDecimal(htb(Convert.ToString(ayl.Item(i)))).ToString("#,##0.00")
                tblSum.Rows.Add(TotalRow1)

                decSumTotal += Convert.ToDecimal(htb(Convert.ToString(ayl.Item(i))))

            Next

            If (ayl.Count > 0) Then
                TotalRow1 = New TableRow()
            End If
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
            TotalRow1.Cells(0).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(0).ColumnSpan = 2
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(0).Font.Size = 9
            TotalRow1.Cells(0).Text = ""

            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(1).BackColor = System.Drawing.Color.LightGray
            TotalRow1.Cells(1).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(1).ColumnSpan = 1
            TotalRow1.Cells(1).Font.Bold = True
            TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
            TotalRow1.Cells(1).Font.Size = 9
            TotalRow1.Cells(1).Text = decSumTotal.ToString("#,##0.00")
            ViewState("decSumTotal") = decSumTotal
            tblSum.Rows.Add(TotalRow1)

        Else

            TotalRow1 = New TableRow()
            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
            TotalRow1.Cells(0).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(0).ColumnSpan = 2
            TotalRow1.Cells(0).Font.Bold = True
            TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(0).Font.Size = 9
            TotalRow1.Cells(0).Text = "Total"

            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(1).BackColor = System.Drawing.Color.White
            TotalRow1.Cells(1).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(1).ColumnSpan = 2
            TotalRow1.Cells(1).Font.Bold = True
            TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
            TotalRow1.Cells(1).Font.Size = 9
            TotalRow1.Cells(1).Text = "-"

            TotalRow1.Cells.Add(New TableCell)
            TotalRow1.Cells(2).BackColor = System.Drawing.Color.White
            TotalRow1.Cells(2).ForeColor = System.Drawing.Color.Red
            TotalRow1.Cells(2).ColumnSpan = 1
            TotalRow1.Cells(2).Font.Bold = True
            TotalRow1.Cells(2).HorizontalAlign = HorizontalAlign.Right
            TotalRow1.Cells(2).Font.Size = 9
            TotalRow1.Cells(2).Text = "0.00"
            ViewState("decSumTotal") = 0
            tblSum.Rows.Add(TotalRow1)
 
        End If

        'TotalRow1 = New TableRow()
        'TotalRow1.Cells.Add(New TableCell)
        'TotalRow1.Cells(0).BackColor = System.Drawing.Color.White  
        'TotalRow1.Cells(0).Font.Bold = True
        'TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        'TotalRow1.Cells(0).Font.Size = 9
        'TotalRow1.Cells(0).Text = ""
        'TotalRow1.Cells(0).Height = 15
        'TotalRow1.Cells(0).ColumnSpan = 5
        'TotalRow1.Cells(0).CssClass = "txtUnderline"
        'tblSum.Rows.Add(TotalRow1)
    End Sub

    Private Sub AddTableCheck(ByVal tblCheck As System.Web.UI.WebControls.Table)
        'ViewState("presentLevel")
        'ViewState("formerLevel")
        Dim str5Former As String = ""
        Dim strSQLWageFormer As String = ""
        strSQLWageFormer += vbNewLine + " select top 5 isnull(wage_amt,0) as wage_amt"
        strSQLWageFormer += vbNewLine + " from tblChecker_Former_Wage"
        strSQLWageFormer += vbNewLine + " where checker_level_id = " + ViewState("formerLevel").ToString()
        strSQLWageFormer += vbNewLine + " order by screen_id"
        Dim drWageFormer As IDataReader = cDB.GetDataAll(strSQLWageFormer)
        While (drWageFormer.Read())
            If str5Former <> "" Then
                str5Former += "/"
            End If
            str5Former += Format(drWageFormer("wage_amt"), "#,##0")
        End While
        drWageFormer.Close()

        Dim str5Present As String = ""
        Dim strSQLWagePresent As String = ""
        strSQLWagePresent += vbNewLine + " select top 5 isnull(wage_amt,0) as wage_amt"
        strSQLWagePresent += vbNewLine + " from tblChecker_Present_Wage"
        strSQLWagePresent += vbNewLine + " where checker_level_id = " + ViewState("presentLevel").ToString()
        strSQLWagePresent += vbNewLine + " order by screen_id"
        Dim drWagePresent As IDataReader = cDB.GetDataAll(strSQLWagePresent)
        While (drWagePresent.Read())
            If str5Present <> "" Then
                str5Present += "/"
            End If
            str5Present += Format(drWagePresent("wage_amt"), "#,##0")
        End While
        drWagePresent.Close()


        tblCheck.ForeColor = Color.Black
        tblCheck.BackColor = System.Drawing.Color.FromName("#c3cad6")
        tblCheck.Font.Bold = True
        tblCheck.Font.Size = 9
        tblCheck.BorderWidth = 1
        tblCheck.BorderColor = Color.Gray
        tblCheck.CellPadding = 1
        tblCheck.CellSpacing = 0
        tblCheck.GridLines = GridLines.Both
        tblCheck.Width = 500

        Dim TotalRow1 As New TableRow()

        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.FromName("#c3cad6")
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).Text = "Title"
        TotalRow1.Cells(0).ColumnSpan = 3
        TotalRow1.Cells(0).Width = 250

        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(1).BackColor = System.Drawing.Color.FromName("#c3cad6")
        TotalRow1.Cells(1).Font.Bold = True
        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Center
        TotalRow1.Cells(1).Font.Size = 9
        TotalRow1.Cells(1).Text = "Amount (Baht)"
        TotalRow1.Cells(1).ColumnSpan = 2
        TotalRow1.Cells(1).Width = 250
        tblCheck.Rows.Add(TotalRow1)

        Dim douTotal As Double = 0
        'arrMovieAndWage.Item(ViewState("iMovieAndWage")).ToString().Split("_")(0)
        For j As Integer = 0 To arrMovieAndWage.Count() - 1
            TotalRow1 = New TableRow()
            For i As Integer = 0 To 1
                If i = 0 Then
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.Cells(i).BackColor = System.Drawing.Color.White
                    TotalRow1.Cells(i).Font.Bold = True
                    TotalRow1.Cells(i).HorizontalAlign = HorizontalAlign.Left
                    TotalRow1.Cells(i).Font.Size = 9
                    TotalRow1.Cells(i).Height = 20
                    TotalRow1.Cells(i).ColumnSpan = 3
                    TotalRow1.Cells(i).Text = arrMovieAndWage.Item(j).ToString().Split("_")(1)
                Else
                    TotalRow1.Cells.Add(New TableCell)
                    TotalRow1.Cells(i).BackColor = System.Drawing.Color.White
                    TotalRow1.Cells(i).Font.Bold = True
                    TotalRow1.Cells(i).HorizontalAlign = HorizontalAlign.Right
                    TotalRow1.Cells(i).Font.Size = 9
                    TotalRow1.Cells(i).Height = 20
                    TotalRow1.Cells(i).ColumnSpan = 2
                    TotalRow1.Cells(i).Text = Format(Convert.ToInt32(arrMovieAndWage.Item(j).ToString().Split("_")(2)), "#,##0")
                    douTotal = douTotal + Convert.ToInt32(arrMovieAndWage.Item(j).ToString().Split("_")(2))
                End If

            Next
            tblCheck.Rows.Add(TotalRow1)
        Next

        TotalRow1 = New TableRow()
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.FromName("#CADCEF")
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).ForeColor = Color.Red
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).ColumnSpan = 3
        TotalRow1.Cells(0).Text = "Total (Baht)"

        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(1).BackColor = System.Drawing.Color.FromName("#CADCEF")
        TotalRow1.Cells(1).Font.Bold = True
        TotalRow1.Cells(1).ForeColor = Color.Red
        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(1).Font.Size = 9
        TotalRow1.Cells(1).Text = Format(douTotal, "#,##0")
        TotalRow1.Cells(1).ColumnSpan = 2
        tblCheck.Rows.Add(TotalRow1)

        TotalRow1 = New TableRow()
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.FromName("#ACCCED")
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).ForeColor = Color.Red
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).ColumnSpan = 3
        TotalRow1.Cells(0).Text = "Grand Total (Wage + Late Show)"

        Dim douGrandTotal As Double = ViewState("decSumTotal") + douTotal


        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(1).BackColor = System.Drawing.Color.FromName("#ACCCED")
        TotalRow1.Cells(1).Font.Bold = True
        TotalRow1.Cells(1).ForeColor = Color.Red
        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(1).Font.Size = 9
        TotalRow1.Cells(1).Text = Format(douGrandTotal, "#,##0")
        TotalRow1.Cells(1).ColumnSpan = 2
        tblCheck.Rows.Add(TotalRow1)

        TotalRow1 = New TableRow()
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).ForeColor = Color.Black
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Bottom
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).Text = "Former Wage"
        TotalRow1.Cells(0).ColumnSpan = 3
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(1).BackColor = System.Drawing.Color.White
        TotalRow1.Cells(1).Font.Bold = True
        TotalRow1.Cells(1).ForeColor = Color.Black
        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(1).VerticalAlign = VerticalAlign.Bottom
        TotalRow1.Cells(1).Font.Size = 9
        TotalRow1.Cells(1).Height = 23
        TotalRow1.Cells(1).ColumnSpan = 2
        TotalRow1.Cells(1).Text = str5Former ' Format(decSumFormerWageQty, "#,##0")  '" ______________________________"
        tblCheck.Rows.Add(TotalRow1)

        TotalRow1 = New TableRow()
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).ForeColor = Color.Black
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Bottom
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).ColumnSpan = 3
        TotalRow1.Cells(0).Text = "Present Wage"
        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(1).BackColor = System.Drawing.Color.White
        TotalRow1.Cells(1).Font.Bold = True
        TotalRow1.Cells(1).ForeColor = Color.Black
        TotalRow1.Cells(1).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(1).VerticalAlign = VerticalAlign.Bottom
        TotalRow1.Cells(1).Font.Size = 9
        TotalRow1.Cells(1).Height = 23
        TotalRow1.Cells(1).ColumnSpan = 2
        TotalRow1.Cells(1).Text = str5Present ' Format(decSumPresentWageQty, "#,##0") '" ______________________________"
        tblCheck.Rows.Add(TotalRow1)

        TotalRow1 = New TableRow()

        TotalRow1.Cells.Add(New TableCell)
        TotalRow1.Cells(0).BackColor = System.Drawing.Color.White
        TotalRow1.Cells(0).Font.Bold = True
        TotalRow1.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotalRow1.Cells(0).VerticalAlign = VerticalAlign.Bottom
        TotalRow1.Cells(0).ColumnSpan = 2
        TotalRow1.Cells(0).Font.Size = 9
        TotalRow1.Cells(0).Height = 23
        TotalRow1.Cells(0).ColumnSpan = 5
        TotalRow1.Cells(0).Text = " _____________________" + ViewState("CheckerName").ToString() '--ลงชื่อ
        tblCheck.Rows.Add(TotalRow1)
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            EnableViewState = False
            Dim tw As New IO.StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            frm.Attributes("runat") = "server"
            'frm.Controls.Add(divExport)
            Response.Charset = "windows-874"
            Response.AddHeader("content-disposition", "attachment;filename=Checker_Wage_Late_Show.xls")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"

            CreateTable()
            frm.Controls.Add(divExport)
            frm.Controls.Add(tblTitle)
            frm.Controls.Add(tblTop)

            Controls.Add(frm)
            frm.RenderControl(hw)
            'Response.Write(tw.ToString())
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
            Response.End()

            ''Dim tw As New IO.StringWriter()
            ''Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            ''Dim frm As HtmlForm = New HtmlForm()
            ''frm.Attributes("runat") = "server"
            ''CreateTable()
            ''frm.Controls.Add(divExport)
            ''frm.Controls.Add(tblTitle)
            ''frm.Controls.Add(tblTop)
            ''Response.AddHeader("content-disposition", "attachment;filename=PDA_BoxOffice.xls")
            ''Response.Cache.SetCacheability(HttpCacheability.NoCache)

            ''Response.ContentType = "application/vnd.xls"
            ''Response.Charset = ""
            ''EnableViewState = False
            ''Controls.Add(frm)

            ''frm.RenderControl(hw)
            ' ''Response.Write(tw.ToString())
            ''Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
            ''Response.End()


        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptBoxOfficeAndLateShowParam.aspx")
    End Sub


    Private Function SelectWage(ByVal pstrPresentFlag As String, ByVal pintLevel As Integer, ByVal pintScreenId As Integer) As Decimal
        If pstrPresentFlag <> "" And pintLevel > 0 And pintScreenId > 0 Then
            If pstrPresentFlag = "N" Then
                SelectWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Former_Wage", "WHERE screen_id = " + pintScreenId.ToString() + " AND checker_level_id = " + pintLevel.ToString())
            Else
                SelectWage = cDB.GetDataDecimal("wage_amt", "tblChecker_Present_Wage", "WHERE screen_id = " + pintScreenId.ToString() + " AND checker_level_id = " + pintLevel.ToString())
            End If
        Else
            SelectWage = 0
        End If
    End Function

  

End Class