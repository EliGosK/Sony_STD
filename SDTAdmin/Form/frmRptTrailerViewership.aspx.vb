Imports Web.Data

Partial Public Class frmRptTrailerViewership
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Mid(Session("permission"), 7, 1) = "0" Then
            '    Response.Redirect("InfoPage.aspx")
            'End If
            createRpt()
         
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
    End Sub

    '--- Commented by Wittawat W. (CSI) on 2012/12/12 : Fix bug
    'Sub createRpt()
    '    Dim cDB As New cDatabase
    '    Dim RealMovieID As String = Convert.ToString(Session("rptRealMovie"))
    '    Dim strStartDate As String = Convert.ToString(Session("msRptStrDate"))
    '    Dim strEndDate As String = Convert.ToString(Session("msRptEndDate"))
    '    Dim RealName As String = ""

    '    If ((RealMovieID.Trim() = "") Or (RealMovieID.Trim() = "null") Or (RealMovieID.Trim() = "0")) Then
    '        tbl.Rows(2).Visible = False
    '    End If

    '    'Dim drTrailer As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + TrailerMovieID)
    '    'If drTrailer.Read Then
    '    '    SetupNo = drTrailer("movie_nameen").ToString
    '    'End If
    '    'drTrailer.Close()

    '    Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
    '    If drReal.Read Then
    '        RealName = drReal("movie_nameen").ToString
    '    End If
    '    drReal.Close()

    '    tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
    '    tbl.Rows(2).Cells(0).Text = RealName
    '    If (strStartDate.Trim() <> "") Then
    '        tbl.Rows(3).Cells(0).Text = "Release Date : " + strStartDate.Substring(8, 2) + "/" + strStartDate.Substring(5, 2) + "/" + strStartDate.Substring(0, 4) + " - " + strEndDate.Substring(8, 2) + "/" + strEndDate.Substring(5, 2) + "/" + strEndDate.Substring(0, 4)
    '    Else
    '        tbl.Rows(3).Cells(0).Text = "Release Date : -"
    '    End If
    '    'Dim wkSQL As String

    '    'wkSQL = vbNewLine + " select sh.setup_no, sh.setup_start_date, sh.setup_end_date, cd.movie_id, min(mv.movie_nameen) as movie_nameen,"
    '    'wkSQL += vbNewLine + " min(mv.movie_nameth) as movie_nameth, min(mv.movie_strdate) as movie_strdate,"
    '    'wkSQL += vbNewLine + " isnull("
    '    'wkSQL += vbNewLine + " (select count(col.movie_id)"
    '    'wkSQL += vbNewLine + " from "
    '    'wkSQL += vbNewLine + " (select distinct tch.circuit_id, tch.theater_id, tcd.collection_no, ttm.theatersub_id, tcd.movie_id "
    '    'wkSQL += vbNewLine + " from tblTrailer_Master ttm"
    '    'wkSQL += vbNewLine + " left join tblTrailer_Collection_Dtl tcd on ttm.collection_no = tcd.collection_no"
    '    'wkSQL += vbNewLine + " left join tblTrailer_Collection_Hdr tch on tcd.collection_no = tch.collection_no"
    '    'wkSQL += vbNewLine + " left join tblMovie tm on tcd.movie_id = tm.movie_id"
    '    'wkSQL += vbNewLine + " where(tcd.ref_setup_no = sh.setup_no)"
    '    'wkSQL += vbNewLine + " and tcd.movie_id = cd.movie_id"
    '    'wkSQL += vbNewLine + " ) col"
    '    'wkSQL += vbNewLine + " where(col.movie_id = cd.movie_id)"
    '    'wkSQL += vbNewLine + " ), 0) as trailer_qty,"
    '    'wkSQL += vbNewLine + " ("
    '    'wkSQL += vbNewLine + " select isnull(sum(tr.revenue_adms), 0) + isnull(sum(cr.comprevenue_admssum), 0) as viewership_qty"
    '    'wkSQL += vbNewLine + " from tblMovie tm"
    '    'wkSQL += vbNewLine + " left join tblComprevenue cr on tm.movie_id = cr.movies_id"
    '    'wkSQL += vbNewLine + " left join tblRevenue tr on tm.movie_id = tr.movies_id"
    '    'wkSQL += vbNewLine + " where (convert(varchar(19), tr.revenue_date, 111) >= convert(varchar(19), sh.setup_start_date, 111)"
    '    'wkSQL += vbNewLine + " and convert(varchar(19), tr.revenue_date, 111) <= convert(varchar(19), sh.setup_end_date, 111))"
    '    'wkSQL += vbNewLine + " or (convert(varchar(19), cr.comprevenue_date, 111) >= convert(varchar(19), sh.setup_start_date, 111)"
    '    'wkSQL += vbNewLine + " and convert(varchar(19), cr.comprevenue_date, 111) <= convert(varchar(19), sh.setup_end_date, 111))"
    '    'wkSQL += vbNewLine + " and tm.movie_id = cd.movie_id"
    '    'wkSQL += vbNewLine + " ) viewership_qty,"

    '    'If (strStartDate.Trim() <> "") Then
    '    '    wkSQL += vbNewLine + " dbo.funGetConcatTrailerViewer(sh.setup_start_date,sh.setup_end_date,'" + strStartDate + "','" + strEndDate + "',cd.movie_id) MostMovie"
    '    'Else
    '    '    wkSQL += vbNewLine + " dbo.funGetConcatTrailerViewer(sh.setup_start_date,sh.setup_end_date,null,null,cd.movie_id) MostMovie"
    '    'End If
    '    'wkSQL += vbNewLine + " from tblTrailer_Master tm"
    '    'wkSQL += vbNewLine + " inner join tblTrailer_Collection_Dtl cd on tm.collection_no = cd.collection_no"
    '    'wkSQL += vbNewLine + " inner join tblTrailer_Collection_Hdr ch on cd.collection_no = ch.collection_no"
    '    'wkSQL += vbNewLine + " inner join tblTrailer_Setup_Hdr sh on cd.ref_setup_no = sh.setup_no"
    '    'wkSQL += vbNewLine + " left join tblMovie mv on cd.movie_id = mv.movie_id"

    '    'If (RealMovieID <> "" And RealMovieID <> "null" And RealMovieID <> "0") Then
    '    '    wkSQL += vbNewLine + " where cd.movie_id = " + RealMovieID
    '    'Else
    '    '    wkSQL += vbNewLine + " where convert(varchar(19), mv.movie_strdate, 111) >= convert(varchar(19), '" + strStartDate + "', 111)"
    '    '    wkSQL += vbNewLine + " and convert(varchar(19), mv.movie_strdate, 111) <= convert(varchar(19), '" + strEndDate + "', 111)"
    '    'End If

    '    'wkSQL += vbNewLine + " group by sh.setup_no, sh.setup_start_date, sh.setup_end_date, cd.movie_id                         "
    '    'wkSQL += vbNewLine + " order by movie_strdate, cd.movie_id"


    '    Dim dtb As New DataTable()
    '    'dtb = cDatabase.GetDataTable(wkSQL)
    '    dtb = cDB.getRptTrailerViewership(RealMovieID, strStartDate, strEndDate)

    '    Dim intWeekNo As Integer = 1

    '    Dim sumReal As Integer = 0
    '    Dim sumTrailer As Integer = 0
    '    Dim SumPercent As Decimal = 0

    '    Dim strCheckMovie As String = ""
    '    Dim detailsRow As New TableRow()

    '    Dim decSumAmount1 As Decimal = 0
    '    Dim decSumAmount2 As Decimal = 0
    '    Dim decSumAmount3 As Decimal = 0

    '    For i As Integer = 0 To dtb.Rows.Count - 1
    '        'Circuit ใหม่
    '        If (strCheckMovie <> Convert.ToString(dtb.Rows(i)("movie_id"))) Then
    '            'Write Sum
    '            If strCheckMovie.Trim() <> "" Then
    '                detailsRow = New TableRow()
    '                detailsRow.HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Font.Name = "Tahoma"
    '                detailsRow.Font.Size = 10

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Cells(0).Text = ""
    '                detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
    '                detailsRow.Cells(0).Font.Bold = True
    '                detailsRow.Cells(0).Height = 20
    '                detailsRow.Cells(0).ColumnSpan = 2

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '                detailsRow.Cells(1).Text = "Total"
    '                detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(1).ForeColor = Color.Red
    '                detailsRow.Cells(1).Font.Bold = True
    '                detailsRow.Cells(1).Height = 20
    '                detailsRow.Cells(1).ColumnSpan = 1

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                detailsRow.Cells(2).Text = decSumAmount1.ToString("#,##0")
    '                detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(2).ForeColor = Color.Red
    '                detailsRow.Cells(2).Font.Bold = True
    '                detailsRow.Cells(2).Height = 20
    '                detailsRow.Cells(2).ColumnSpan = 1
    '                detailsRow.Cells(2).CssClass = "underline11"

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Cells(3).Text = ""
    '                detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
    '                detailsRow.Cells(3).Font.Bold = True
    '                detailsRow.Cells(3).Height = 20
    '                detailsRow.Cells(3).ColumnSpan = 1

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '                detailsRow.Cells(4).Text = decSumAmount2.ToString("#,##0")
    '                detailsRow.Cells(4).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(4).ForeColor = Color.Red
    '                detailsRow.Cells(4).Font.Bold = True
    '                detailsRow.Cells(4).Height = 20
    '                detailsRow.Cells(4).ColumnSpan = 1
    '                detailsRow.Cells(4).CssClass = "underline11"

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Cells(5).Text = ""
    '                detailsRow.Cells(5).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(5).ForeColor = Color.FromName("#000000")
    '                detailsRow.Cells(5).Font.Bold = True
    '                detailsRow.Cells(5).Height = 20
    '                detailsRow.Cells(5).ColumnSpan = 1

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '                detailsRow.Cells(6).Text = decSumAmount1.ToString("#,##0")
    '                detailsRow.Cells(6).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(6).ForeColor = Color.Red
    '                detailsRow.Cells(6).Font.Bold = True
    '                detailsRow.Cells(6).Height = 20
    '                detailsRow.Cells(6).ColumnSpan = 1
    '                detailsRow.Cells(6).CssClass = "underline11"
    '                tbl.Rows.Add(detailsRow)


    '                detailsRow = New TableRow()
    '                detailsRow.HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Font.Name = "Tahoma"
    '                detailsRow.Font.Size = 10

    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                detailsRow.Cells(0).Text = ""
    '                detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
    '                detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
    '                detailsRow.Cells(0).Font.Bold = True
    '                detailsRow.Cells(0).Height = 20
    '                detailsRow.Cells(0).ColumnSpan = 8
    '                tbl.Rows.Add(detailsRow)






    '            End If

    '            detailsRow = New TableRow()
    '            detailsRow.HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Font.Name = "Tahoma"
    '            detailsRow.Font.Size = 10

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left

    '            detailsRow.Cells(0).Text = Convert.ToString(dtb.Rows(i)("movie_nameen")) + "/" + Convert.ToString(dtb.Rows(i)("movie_nameth"))
    '            detailsRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
    '            detailsRow.Cells(0).ForeColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(0).Font.Bold = True
    '            detailsRow.Cells(0).Height = 25
    '            detailsRow.Cells(0).ColumnSpan = 8
    '            detailsRow.Cells(0).Width = 500
    '            tbl.Rows.Add(detailsRow)


    '            'ย้าย week no
    '            detailsRow = New TableRow()
    '            detailsRow.HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Font.Name = "Tahoma"
    '            detailsRow.Font.Size = 10

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(0).Text = "Week No."
    '            detailsRow.Cells(0).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(0).ForeColor = Color.Black
    '            detailsRow.Cells(0).Font.Bold = True
    '            detailsRow.Cells(0).Height = 20
    '            detailsRow.Cells(0).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(1).Text = "Launched Week"
    '            detailsRow.Cells(1).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(1).ForeColor = Color.Black
    '            detailsRow.Cells(1).Font.Bold = True
    '            detailsRow.Cells(1).Height = 20
    '            detailsRow.Cells(1).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(2).Text = "Trailer Amount"
    '            detailsRow.Cells(2).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(2).ForeColor = Color.Black
    '            detailsRow.Cells(2).Font.Bold = True
    '            detailsRow.Cells(2).Height = 20
    '            detailsRow.Cells(2).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(3).Text = "Viewership"
    '            detailsRow.Cells(3).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(3).ForeColor = Color.Black
    '            detailsRow.Cells(3).Font.Bold = True
    '            detailsRow.Cells(3).Height = 20
    '            detailsRow.Cells(3).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(4).Text = "Most Viewed Movie"
    '            detailsRow.Cells(4).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(4).ForeColor = Color.Black
    '            detailsRow.Cells(4).Font.Bold = True
    '            detailsRow.Cells(4).Height = 20
    '            detailsRow.Cells(4).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(5).Text = "Est Adms"
    '            detailsRow.Cells(5).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(5).ForeColor = Color.Black
    '            detailsRow.Cells(5).Font.Bold = True
    '            detailsRow.Cells(5).Height = 20
    '            detailsRow.Cells(5).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(6).Text = "Second Viewed Movie"
    '            detailsRow.Cells(6).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(6).ForeColor = Color.Black
    '            detailsRow.Cells(6).Font.Bold = True
    '            detailsRow.Cells(6).Height = 20
    '            detailsRow.Cells(6).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(7).Text = "Est Adms"
    '            detailsRow.Cells(7).BackColor = Color.FromName("#DBEEF3")
    '            detailsRow.Cells(7).ForeColor = Color.Black
    '            detailsRow.Cells(7).Font.Bold = True
    '            detailsRow.Cells(7).Height = 20
    '            detailsRow.Cells(7).ColumnSpan = 1

    '            tbl.Rows.Add(detailsRow)

    '            strCheckMovie = Convert.ToString(dtb.Rows(i)("movie_id"))
    '            decSumAmount1 = 0
    '            decSumAmount2 = 0
    '            decSumAmount3 = 0
    '            intWeekNo = 1
    '        End If

    '        detailsRow = New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Center
    '        detailsRow.Font.Name = "Tahoma"
    '        detailsRow.Font.Size = 10

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '        detailsRow.Cells(0).Text = intWeekNo.ToString()
    '        detailsRow.Cells(0).BackColor = Color.FromName("#DBEEF3")
    '        detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(0).Font.Bold = False
    '        detailsRow.Cells(0).Height = 20
    '        detailsRow.Cells(0).ColumnSpan = 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
    '        detailsRow.Cells(1).Text = Convert.ToDateTime(dtb.Rows(i)("setup_start_date")).ToString("dd/MM/yyyy")
    '        detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
    '        detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '        detailsRow.Cells(1).Font.Bold = False
    '        detailsRow.Cells(1).Height = 20
    '        detailsRow.Cells(1).ColumnSpan = 1

    '        'Session("rptSetupNo") = Conver
    '        'Session("rptDate") = SetupPopup1.PeriodDate
    '        'Session("rptCircuitID") = ddlCircuitID.SelectedValue
    '        'If (MoviePopupSN1.MovieId = 0) Then
    '        '    Session("rptMovieID") = "null"
    '        'Else
    '        '    Session("rptMovieID") = MoviePopupSN1.MovieId
    '        'End If
    '        'Response.Redirect("frmRptTrailerByTotal.aspx")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        ' detailsRow.Cells(2).Text = Convert.ToDecimal(dtb.Rows(i)("movie_id")).ToString("#,##0")
    '        detailsRow.Cells(2).Text = "<a target='_self' href='frmRptTrailerByTotal.aspx?isviewer=true&rptSetupNo=" + Convert.ToString(dtb.Rows(i)("setup_no")) + "&rptDate=" + Convert.ToDateTime(dtb.Rows(i)("setup_start_date")).ToString("dd/MM/yyyy") + "-" + Convert.ToDateTime(dtb.Rows(i)("setup_end_date")).ToString("dd/MM/yyyy") + "&rptCircuitID=null&rptMovieID=" + Convert.ToString(dtb.Rows(i)("movie_id")) + "'>" + Convert.ToDecimal(dtb.Rows(i)("trailer_qty")).ToString("#,##0") + "</a>"
    '        detailsRow.Cells(2).BackColor = Color.FromName("#D8D8D8")
    '        detailsRow.Cells(2).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(2).Font.Bold = False
    '        detailsRow.Cells(2).Height = 20
    '        detailsRow.Cells(2).ColumnSpan = 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(3).Text = Convert.ToDecimal(dtb.Rows(i)("viewership_qty")).ToString("#,##0")
    '        detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
    '        detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(3).Font.Bold = False
    '        detailsRow.Cells(3).Height = 20
    '        detailsRow.Cells(3).ColumnSpan = 1

    '        Dim aryMostAmount() As String = Convert.ToString(dtb.Rows(i)("MostMovie")).Split("$"c)

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
    '        detailsRow.Cells(4).Text = aryMostAmount(0)
    '        detailsRow.Cells(4).BackColor = Color.FromName("#FCD5B4")
    '        detailsRow.Cells(4).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(4).Font.Bold = False
    '        detailsRow.Cells(4).Height = 20
    '        detailsRow.Cells(4).ColumnSpan = 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(5).Text = Convert.ToDecimal(aryMostAmount(1)).ToString("#,##0")
    '        detailsRow.Cells(5).BackColor = Color.FromName("#ffffff")
    '        detailsRow.Cells(5).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(5).Font.Bold = False
    '        detailsRow.Cells(5).Height = 20
    '        detailsRow.Cells(5).ColumnSpan = 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Center
    '        If (aryMostAmount.Length > 2) Then
    '            detailsRow.Cells(6).Text = aryMostAmount(2)
    '        End If
    '        detailsRow.Cells(6).BackColor = Color.FromName("#FCD5B4")
    '        detailsRow.Cells(6).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(6).Font.Bold = False
    '        detailsRow.Cells(6).Height = 20
    '        detailsRow.Cells(6).ColumnSpan = 1

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        If (aryMostAmount.Length > 3) Then
    '            detailsRow.Cells(7).Text = Convert.ToDecimal(aryMostAmount(3)).ToString("#,##0")
    '        End If
    '        detailsRow.Cells(7).BackColor = Color.FromName("#ffffff")
    '        detailsRow.Cells(7).ForeColor = Color.FromName("#000000")
    '        detailsRow.Cells(7).Font.Bold = False
    '        detailsRow.Cells(7).Height = 20
    '        detailsRow.Cells(7).ColumnSpan = 1

    '        decSumAmount1 += Convert.ToDecimal(IIf(detailsRow.Cells(3).Text.Trim() = "", 0, detailsRow.Cells(3).Text))
    '        decSumAmount2 += Convert.ToDecimal(IIf(detailsRow.Cells(5).Text.Trim() = "", 0, detailsRow.Cells(5).Text))
    '        decSumAmount3 += Convert.ToDecimal(IIf(detailsRow.Cells(7).Text.Trim() = "", 0, detailsRow.Cells(7).Text))

    '        tbl.Rows.Add(detailsRow)
    '        intWeekNo += 1
    '    Next


    '    If (intWeekNo > 0) Then
    '        If strCheckMovie.Trim() <> "" Then
    '            detailsRow = New TableRow()
    '            detailsRow.HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Font.Name = "Tahoma"
    '            detailsRow.Font.Size = 10

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(0).Text = ""
    '            detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
    '            detailsRow.Cells(0).Font.Bold = True
    '            detailsRow.Cells(0).Height = 20
    '            detailsRow.Cells(0).ColumnSpan = 2

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(1).Text = "Total"
    '            detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(1).ForeColor = Color.Red
    '            detailsRow.Cells(1).Font.Bold = True
    '            detailsRow.Cells(1).Height = 20
    '            detailsRow.Cells(1).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(2).Text = decSumAmount1.ToString("#,##0")
    '            detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(2).ForeColor = Color.Red
    '            detailsRow.Cells(2).Font.Bold = True
    '            detailsRow.Cells(2).Height = 20
    '            detailsRow.Cells(2).ColumnSpan = 1
    '            detailsRow.Cells(2).CssClass = "underline11"

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(3).Text = ""
    '            detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
    '            detailsRow.Cells(3).Font.Bold = True
    '            detailsRow.Cells(3).Height = 20
    '            detailsRow.Cells(3).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(4).Text = decSumAmount2.ToString("#,##0")
    '            detailsRow.Cells(4).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(4).ForeColor = Color.Red
    '            detailsRow.Cells(4).Font.Bold = True
    '            detailsRow.Cells(4).Height = 20
    '            detailsRow.Cells(4).ColumnSpan = 1
    '            detailsRow.Cells(4).CssClass = "underline11"

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(5).Text = ""
    '            detailsRow.Cells(5).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(5).ForeColor = Color.FromName("#000000")
    '            detailsRow.Cells(5).Font.Bold = True
    '            detailsRow.Cells(5).Height = 20
    '            detailsRow.Cells(5).ColumnSpan = 1

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(6).Text = decSumAmount1.ToString("#,##0")
    '            detailsRow.Cells(6).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(6).ForeColor = Color.Red
    '            detailsRow.Cells(6).Font.Bold = True
    '            detailsRow.Cells(6).Height = 20
    '            detailsRow.Cells(6).ColumnSpan = 1
    '            detailsRow.Cells(6).CssClass = "underline11"
    '            tbl.Rows.Add(detailsRow)


    '            detailsRow = New TableRow()
    '            detailsRow.HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Font.Name = "Tahoma"
    '            detailsRow.Font.Size = 10
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(0).Text = ""
    '            detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
    '            detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
    '            detailsRow.Cells(0).Font.Bold = True
    '            detailsRow.Cells(0).Height = 20
    '            detailsRow.Cells(0).ColumnSpan = 8
    '            tbl.Rows.Add(detailsRow)
    '        End If
    '    End If
    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/12/12 : Fix bug
    Sub createRpt()
        Dim cDB As New cDatabase
        Dim RealMovieID As String = Convert.ToString(Session("rptRealMovie"))
        Dim strStartDate As String = Convert.ToString(Session("msRptStrDate"))
        Dim strEndDate As String = Convert.ToString(Session("msRptEndDate"))
        Dim RealName As String = ""

        If ((RealMovieID.Trim() = "") Or (RealMovieID.Trim() = "null") Or (RealMovieID.Trim() = "0")) Then
            tbl.Rows(2).Visible = False
        End If

        Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
        If drReal.Read Then
            RealName = drReal("movie_nameen").ToString
        End If
        drReal.Close()

        tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
        tbl.Rows(2).Cells(0).Text = RealName
        If (strStartDate.Trim() <> "") Then
            tbl.Rows(3).Cells(0).Text = "Release Date : " + strStartDate.Substring(8, 2) + "/" + strStartDate.Substring(5, 2) + "/" + strStartDate.Substring(0, 4) + " - " + strEndDate.Substring(8, 2) + "/" + strEndDate.Substring(5, 2) + "/" + strEndDate.Substring(0, 4)
        Else
            tbl.Rows(3).Cells(0).Text = "Release Date : -"
        End If

        Dim dtb As DataTable = cDB.getRptTrailerViewership(RealMovieID, strStartDate, strEndDate)

        Dim sumReal As Integer = 0
        Dim sumTrailer As Integer = 0
        Dim SumPercent As Decimal = 0

        Dim decSumAmount1 As Decimal = 0
        Dim decSumAmount2 As Decimal = 0
        Dim decSumAmount3 As Decimal = 0

        Dim intGroupRunning As Integer = 0
        Dim intDetailRunning As Integer = 0

        Dim detailsRow As New TableRow()

        For i As Integer = 0 To dtb.Rows.Count - 1

            If intDetailRunning = 0 Then
                detailsRow = New TableRow()
                detailsRow.HorizontalAlign = HorizontalAlign.Center
                detailsRow.Font.Name = "Tahoma"
                detailsRow.Font.Size = 10

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Left
                detailsRow.Cells(0).Text = String.Format("{0}/{1}", dtb.Rows(i)("movie_nameen"), dtb.Rows(i)("movie_nameth"))
                detailsRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
                detailsRow.Cells(0).ForeColor = Color.FromName("#ffffff")
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(0).Height = 25
                detailsRow.Cells(0).ColumnSpan = 8
                detailsRow.Cells(0).Width = 1000

                tbl.Rows.Add(detailsRow)

                detailsRow = New TableRow()
                detailsRow.HorizontalAlign = HorizontalAlign.Center
                detailsRow.Font.Name = "Tahoma"
                detailsRow.Font.Size = 10

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(0).Text = "Week <br /> No."
                detailsRow.Cells(0).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(0).ForeColor = Color.Black
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(0).Height = 20
                detailsRow.Cells(0).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(1).Text = "Launched <br /> Week"
                detailsRow.Cells(1).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(1).ForeColor = Color.Black
                detailsRow.Cells(1).Font.Bold = True
                detailsRow.Cells(1).Height = 20
                detailsRow.Cells(1).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(2).Text = "Trailer <br /> Amount"
                detailsRow.Cells(2).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(2).ForeColor = Color.Black
                detailsRow.Cells(2).Font.Bold = True
                detailsRow.Cells(2).Height = 20
                detailsRow.Cells(2).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(3).VerticalAlign = VerticalAlign.Middle
                detailsRow.Cells(3).Text = "Viewership"
                detailsRow.Cells(3).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(3).ForeColor = Color.Black
                detailsRow.Cells(3).Font.Bold = True
                detailsRow.Cells(3).Height = 20
                detailsRow.Cells(3).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(4).VerticalAlign = VerticalAlign.Middle
                detailsRow.Cells(4).Text = "Most Viewed Movie"
                detailsRow.Cells(4).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(4).ForeColor = Color.Black
                detailsRow.Cells(4).Font.Bold = True
                detailsRow.Cells(4).Height = 20
                detailsRow.Cells(4).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(5).VerticalAlign = VerticalAlign.Middle
                detailsRow.Cells(5).Text = "Est Adms"
                detailsRow.Cells(5).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(5).ForeColor = Color.Black
                detailsRow.Cells(5).Font.Bold = True
                detailsRow.Cells(5).Height = 20
                detailsRow.Cells(5).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(6).VerticalAlign = VerticalAlign.Middle
                detailsRow.Cells(6).Text = "Second Viewed Movie"
                detailsRow.Cells(6).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(6).ForeColor = Color.Black
                detailsRow.Cells(6).Font.Bold = True
                detailsRow.Cells(6).Height = 20
                detailsRow.Cells(6).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(7).VerticalAlign = VerticalAlign.Middle
                detailsRow.Cells(7).Text = "Est Adms"
                detailsRow.Cells(7).BackColor = Color.FromName("#DBEEF3")
                detailsRow.Cells(7).ForeColor = Color.Black
                detailsRow.Cells(7).Font.Bold = True
                detailsRow.Cells(7).Height = 20
                detailsRow.Cells(7).ColumnSpan = 1

                tbl.Rows.Add(detailsRow)
            End If

            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 10

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(0).Text = String.Format("{0:#,##0}", intDetailRunning + 1)
            detailsRow.Cells(0).BackColor = Color.FromName("#DBEEF3")
            detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(0).Font.Bold = False
            detailsRow.Cells(0).Height = 20
            detailsRow.Cells(0).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(1).Text = String.Format("{0:dd/MM/yyyy}", dtb.Rows(i)("setup_start_date"))
            detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(1).Font.Bold = False
            detailsRow.Cells(1).Height = 20
            detailsRow.Cells(1).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(2).Text = "<a target='_self' href='frmRptTrailerByTotal.aspx?isviewer=true&rptSetupNo=" + Convert.ToString(dtb.Rows(i)("setup_no")) + "&rptDate=" + Convert.ToDateTime(dtb.Rows(i)("setup_start_date")).ToString("dd/MM/yyyy") + "-" + Convert.ToDateTime(dtb.Rows(i)("setup_end_date")).ToString("dd/MM/yyyy") + "&rptCircuitID=null&rptMovieID=" + Convert.ToString(dtb.Rows(i)("movie_id")) + "'>" + Convert.ToDecimal(dtb.Rows(i)("trailer_qty")).ToString("#,##0") + "</a>"
            detailsRow.Cells(2).BackColor = Color.FromName("#D8D8D8")
            detailsRow.Cells(2).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(2).Font.Bold = False
            detailsRow.Cells(2).Height = 20
            detailsRow.Cells(2).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(3).Text = String.Format("{0:#,##0}", dtb.Rows(i)("viewership_qty"))
            detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(3).Font.Bold = False
            detailsRow.Cells(3).Height = 20
            detailsRow.Cells(3).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(4).Text = String.Format("{0}", dtb.Rows(i)("real_movie_nameen_rank_1"))
            detailsRow.Cells(4).BackColor = Color.FromName("#FCD5B4")
            detailsRow.Cells(4).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(4).Font.Bold = False
            detailsRow.Cells(4).Height = 20
            detailsRow.Cells(4).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(5).Text = String.Format("{0:#,##0}", dtb.Rows(i)("viewership_qty_rank_1"))
            detailsRow.Cells(5).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(5).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(5).Font.Bold = False
            detailsRow.Cells(5).Height = 20
            detailsRow.Cells(5).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(6).Text = String.Format("{0}", dtb.Rows(i)("real_movie_nameen_rank_2"))
            detailsRow.Cells(6).BackColor = Color.FromName("#FCD5B4")
            detailsRow.Cells(6).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(6).Font.Bold = False
            detailsRow.Cells(6).Height = 20
            detailsRow.Cells(6).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(7).Text = String.Format("{0:#,##0}", dtb.Rows(i)("viewership_qty_rank_2"))
            detailsRow.Cells(7).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(7).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(7).Font.Bold = False
            detailsRow.Cells(7).Height = 20
            detailsRow.Cells(7).ColumnSpan = 1

            tbl.Rows.Add(detailsRow)

            decSumAmount1 += Convert.ToDecimal(IIf(detailsRow.Cells(3).Text.Trim() = "", 0, detailsRow.Cells(3).Text))
            decSumAmount2 += Convert.ToDecimal(IIf(detailsRow.Cells(5).Text.Trim() = "", 0, detailsRow.Cells(5).Text))
            decSumAmount3 += Convert.ToDecimal(IIf(detailsRow.Cells(7).Text.Trim() = "", 0, detailsRow.Cells(7).Text))
            intDetailRunning += 1

            If (i = dtb.Rows.Count - 1) OrElse _
            ((i <= dtb.Rows.Count - 2) AndAlso (dtb.Rows(i)("movie_id") <> dtb.Rows(i + 1)("movie_id"))) _
            Then
                detailsRow = New TableRow()
                detailsRow.HorizontalAlign = HorizontalAlign.Center
                detailsRow.Font.Name = "Tahoma"
                detailsRow.Font.Size = 10

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(0).Text = ""
                detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
                detailsRow.Cells(0).Font.Bold = True
                detailsRow.Cells(0).Height = 20
                detailsRow.Cells(0).ColumnSpan = 2

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(1).Text = "Total"
                detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(1).ForeColor = Color.Red
                detailsRow.Cells(1).Font.Bold = True
                detailsRow.Cells(1).Height = 20
                detailsRow.Cells(1).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(2).Text = String.Format("{0:#,##0}", decSumAmount1)
                detailsRow.Cells(2).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(2).ForeColor = Color.Red
                detailsRow.Cells(2).Font.Bold = True
                detailsRow.Cells(2).Height = 20
                detailsRow.Cells(2).ColumnSpan = 1
                detailsRow.Cells(2).CssClass = "underline11"

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(3).Text = ""
                detailsRow.Cells(3).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(3).ForeColor = Color.FromName("#000000")
                detailsRow.Cells(3).Font.Bold = True
                detailsRow.Cells(3).Height = 20
                detailsRow.Cells(3).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(4).Text = String.Format("{0:#,##0}", decSumAmount2)
                detailsRow.Cells(4).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(4).ForeColor = Color.Red
                detailsRow.Cells(4).Font.Bold = True
                detailsRow.Cells(4).Height = 20
                detailsRow.Cells(4).ColumnSpan = 1
                detailsRow.Cells(4).CssClass = "underline11"

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(5).Text = ""
                detailsRow.Cells(5).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(5).ForeColor = Color.FromName("#000000")
                detailsRow.Cells(5).Font.Bold = True
                detailsRow.Cells(5).Height = 20
                detailsRow.Cells(5).ColumnSpan = 1

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(6).Text = String.Format("{0:#,##0}", decSumAmount3)
                detailsRow.Cells(6).BackColor = Color.FromName("#ffffff")
                detailsRow.Cells(6).ForeColor = Color.Red
                detailsRow.Cells(6).Font.Bold = True
                detailsRow.Cells(6).Height = 20
                detailsRow.Cells(6).ColumnSpan = 1
                detailsRow.Cells(6).CssClass = "underline11"

                tbl.Rows.Add(detailsRow)

                'detailsRow = New TableRow()
                'detailsRow.HorizontalAlign = HorizontalAlign.Center
                'detailsRow.Font.Name = "Tahoma"
                'detailsRow.Font.Size = 10

                'detailsRow.Cells.Add(New TableCell)
                'detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                'detailsRow.Cells(0).Text = ""
                'detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
                'detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
                'detailsRow.Cells(0).Font.Bold = True
                'detailsRow.Cells(0).Height = 20
                'detailsRow.Cells(0).ColumnSpan = 8

                'tbl.Rows.Add(detailsRow)

                decSumAmount1 = 0
                decSumAmount2 = 0
                decSumAmount3 = 0
                intDetailRunning = 0
                intGroupRunning += 1
            End If
        Next
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerViewershipParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Try
            Response.Clear()
            Response.AddHeader("content-disposition", "attachment;filename=Trailer_ViewerShip.xls")
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/vnd.xls"
            Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
            Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
            tbl.RenderControl(htmlWrite)
            'createRpt()
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
            Response.End()
        Catch ex As Exception
            tbl.Rows(0).Cells(0).Text = ex.Message
        End Try
    End Sub

End Class