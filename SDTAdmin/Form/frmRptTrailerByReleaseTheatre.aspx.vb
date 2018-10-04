Imports Web.Data

Partial Public Class frmRptTrailerByReleaseTheatre
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        Dim cDB As New cDatabase
        Dim RealMovieID As String = Session("rptRealMovie").ToString
        Dim SetupNo As String = Session("rptSetupNo").ToString
        Dim RealName As String = ""

        'Dim drTrailer As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + TrailerMovieID)
        'If drTrailer.Read Then
        '    SetupNo = drTrailer("movie_nameen").ToString
        'End If
        'drTrailer.Close()

        Dim drReal As IDataReader = cDB.GetDataString("[movie_nameen]", "[tblMovie]", " [movie_id] = " + RealMovieID)
        If drReal.Read Then
            RealName = drReal("movie_nameen").ToString
        End If
        drReal.Close()
        tbl.Rows(0).Cells(0).Text = "โคลัมเบีย"
        tbl.Rows(2).Cells(0).Text = RealName
        tbl.Rows(3).Cells(0).Text = "PERIOD : " & Session("rptDate").ToString

        Dim dtbCircuit As DataTable = cDatabase.GetDataTable("Select circuit_name from tblcircuit where circuit_id=" + Request.QueryString("circuitid"))
        If (dtbCircuit.Rows.Count > 0) Then
            tbl.Rows(4).Cells(0).Text = "Circuit : " + Convert.ToString(dtbCircuit.Rows(0)("circuit_name"))
        End If
        Dim dtbTheater As DataTable = cDatabase.GetDataTable("Select theater_name from tbltheater where theater_id=" + Request.QueryString("theaterid"))
        If (dtbTheater.Rows.Count > 0) Then
            tbl.Rows(5).Cells(0).Text = "Theatre : " + Convert.ToString(dtbTheater.Rows(0)("theater_name"))
        End If

        Dim dtbTrailer As DataTable = cDatabase.GetDataTable("Select movie_nameen from tblmovie where movie_id=" + Request.QueryString("movieid"))
        If (dtbTrailer.Rows.Count > 0) Then
            tbl.Rows(6).Cells(0).Text = "Trailer : " + Convert.ToString(dtbTrailer.Rows(0)("movie_nameen"))
        End If

        Dim wkSQL As String

        'wkSQL = vbNewLine + " SELECT tm.trailer_no, "
        'wkSQL += vbNewLine + " tm.circuit_id, tm.theater_id, tm.TheaterSub_id, "
        'wkSQL += vbNewLine + " tm.real_movie_id, tm.collection_no, cd.ref_setup_no, tm.confirm_flag, "
        'wkSQL += vbNewLine + " tm.active_flag, tm.create_dtm, tm.create_by, "
        'wkSQL += vbNewLine + " tm.last_update_dtm, tm.last_update_by,mv.movietype_id, "
        'wkSQL += vbNewLine + " dbo.funGetConcatMovieByColNo(tm.collection_no,0,7) AS Movie_Collection, "
        'wkSQL += vbNewLine + " mv.movie_nameen + ' / ' + mv.movie_nameth AS real_movie_name "
        'wkSQL += vbNewLine + " FROM tblTrailer_Master tm"
        'wkSQL += vbNewLine + " LEFT OUTER JOIN tblMovie mv ON tm.real_movie_id = mv.movie_id "
        'wkSQL += vbNewLine + " LEFT OUTER JOIN tblTrailer_Collection_Dtl cd on tm.collection_no =cd.collection_no"
        'wkSQL += vbNewLine + " WHERE tm.confirm_flag = 'Y'"
        'wkSQL += vbNewLine + " AND tm.circuit_id = " + Convert.ToString(Request.QueryString("circuitid"))
        'wkSQL += vbNewLine + " AND tm.theater_id = " + Convert.ToString(Request.QueryString("theaterid"))
        'wkSQL += vbNewLine + " and tm.real_movie_id = " + RealMovieID
        'wkSQL += vbNewLine + " and cd.movie_id = " + Convert.ToString(Request.QueryString("movieid"))
        'wkSQL += vbNewLine + " and cd.ref_setup_no = '" + SetupNo + "'"
        'wkSQL += vbNewLine + " order by tm.TheaterSub_id, tm.collection_no"

        '--- Edit by Muay 2010-06-09 ดึงเครือจาก tblTheater แทนการดึงจาก tblTrailer_Master เนื่องจากโรงที่เปลี่ยนเครือไปแล้วต้องขึ้นตามเครือที่เปลี่ยนไม่ใช่เครือเดิมตาม tblTrailer_Master และดึงเฉพาะโรงที่ยังไม่ปิด
        wkSQL = vbNewLine + " SELECT tm.trailer_no, "
        wkSQL += vbNewLine + " t.circuit_id, tm.theater_id, t.theater_name, tm.TheaterSub_id, "
        wkSQL += vbNewLine + " tm.real_movie_id, tm.collection_no, cd.ref_setup_no, tm.confirm_flag, "
        wkSQL += vbNewLine + " tm.active_flag, tm.create_dtm, tm.create_by, "
        wkSQL += vbNewLine + " tm.last_update_dtm, tm.last_update_by,mv.movietype_id, "
        wkSQL += vbNewLine + " dbo.funGetConcatMovieByColNo(tm.collection_no,0,7) AS Movie_Collection, "
        wkSQL += vbNewLine + " mv.movie_nameen + ' / ' + mv.movie_nameth AS real_movie_name "
        wkSQL += vbNewLine + " FROM tblTrailer_Master tm"
        wkSQL += vbNewLine + " left join tblMovie mv ON tm.real_movie_id = mv.movie_id "
        wkSQL += vbNewLine + " left join tblTrailer_Collection_Dtl cd on tm.collection_no =cd.collection_no"
        wkSQL += vbNewLine + " left join tblTheater t on tm.theater_id = t.theater_id"
        wkSQL += vbNewLine + " left join tblCircuit cc on t.circuit_id = cc.circuit_id "
        wkSQL += vbNewLine + " WHERE tm.confirm_flag = 'Y'"
        wkSQL += vbNewLine + " AND t.circuit_id = " + Convert.ToString(Request.QueryString("circuitid"))
        wkSQL += vbNewLine + " AND tm.theater_id = " + Convert.ToString(Request.QueryString("theaterid"))
        wkSQL += vbNewLine + " and tm.real_movie_id = " + RealMovieID
        wkSQL += vbNewLine + " and cd.movie_id = " + Convert.ToString(Request.QueryString("movieid"))
        wkSQL += vbNewLine + " and cd.ref_setup_no = '" + SetupNo + "'"
        wkSQL += vbNewLine + " order by tm.TheaterSub_id, tm.collection_no"
        '--- End by Muay 2010-06-09 --------------------------------------------

        Dim dr As IDataReader = cDB.GetDataAll(wkSQL)
        Dim checkRow As Integer = 1

        Dim sumReal As Integer = 0
        Dim sumTrailer As Integer = 0
        Dim SumPercent As Decimal = 0

        Dim strCircuit As String = ""
        Dim detailsRow As New TableRow()

        While (dr.Read())

            detailsRow = New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            detailsRow.Font.Name = "Tahoma"
            detailsRow.Font.Size = 11

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(0).Text = Convert.ToString(dr("TheaterSub_id"))
            detailsRow.Cells(0).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(0).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(0).Font.Bold = False
            detailsRow.Cells(0).Height = 20
            detailsRow.Cells(0).Width = 100
            detailsRow.Cells(0).ColumnSpan = 1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(1).Text = Convert.ToString(dr("Movie_Collection"))
            detailsRow.Cells(1).BackColor = Color.FromName("#ffffff")
            detailsRow.Cells(1).ForeColor = Color.FromName("#000000")
            detailsRow.Cells(1).Font.Bold = False
            detailsRow.Cells(1).Height = 20
            detailsRow.Cells(1).ColumnSpan = 1


            If (checkRow Mod 2) = 0 Then
                detailsRow.Cells(0).BackColor = Color.FromName("#F7F6F3")
                detailsRow.Cells(1).BackColor = Color.FromName("#F7F6F3")
            End If

            tbl.Rows.Add(detailsRow)

            checkRow += 1
        End While
        dr.Close()

    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTrailerByReleaseParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TrailerByReleaseTheatre.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        tbl.RenderControl(htmlWrite)
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

End Class