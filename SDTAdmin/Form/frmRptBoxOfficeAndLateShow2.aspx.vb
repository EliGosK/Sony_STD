Imports Web.Data

Partial Public Class frmRptBoxOfficeAndLateShow2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CreateTable()
        End If
    End Sub

    Private Sub CreateTable()
        Dim p_RevenueDateFrom As String = Session("strDateComp") ' "10/28/2010"
        Dim p_RevenueDateTo As String = Session("strDateEndComp") ' "11/03/2010"
        Dim p_TheaterIdFrom As String = Session("startTheaterId") ' 1
        Dim p_TheaterIdTo As String = Session("EndTheaterId") ' 100

        Dim cmd As String = ""

        Dim tb_Header As Table

        Dim tb_Theater As Table

        Dim tb_CheckerWage As Table
        Dim tr_CheckerWage_RevenueDate As TableRow
        Dim tr_CheckerWage_TheaterSub As TableRow
        Dim tr_CheckerWage_TheaterSubTotal As TableRow

        Dim tb_LateShow As Table
        Dim tr_LateShow_RevenueDate As TableRow
        Dim tr_LateShow_MovieTotal As TableRow
        Dim tr_LateShow_Total As TableRow

        Dim tb_Summary As Table
        Dim tb_Summary_MovieTotal As TableRow
        Dim tr_Summary_Total As TableRow
        Dim tr_Summary_GrandTotal As TableRow
        Dim tr_Summary_FormerWage As TableRow
        Dim tr_Summary_PresentWage As TableRow
        Dim tr_Summary_User As TableRow



        tb_Header = Create_Header_Table()
        tb_Header.Rows(0).Cells(0).Text = String.Format("Title : CTBV Checker wage and Late Show by Theatre, Date : {0:ddd dd-MMM-yyyy} To {1:ddd dd-MMM-yyyy}", Convert.ToDateTime(p_RevenueDateFrom), Convert.ToDateTime(p_RevenueDateTo))

        Me.divExport.Controls.Add(tb_Header)
        Me.divExport.Controls.Add(New LiteralControl("<br />"))



        cmd = ""
        cmd = cmd + "EXEC [dbo].[spGetRptBoxOfficeAndLateShow2] @p_RevernueDateFrom = '" + p_RevenueDateFrom + "'"
        cmd = cmd + ", @p_RevernueDateTo = '" + p_RevenueDateTo + "'"
        cmd = cmd + ", @p_TheaterIdFrom = " + p_TheaterIdFrom + ""
        cmd = cmd + ", @p_TheaterIdTo = " + p_TheaterIdTo + ""
        cmd = cmd + ", @p_TheaterId = null"
        cmd = cmd + ", @p_UserId = null"
        cmd = cmd + ", @p_ReportSection = 'Report_Main_Theater'"

        Dim dtTheater As DataTable = cDatabase.GetDataTable(cmd)

        For i As Integer = 0 To dtTheater.Rows.Count - 1
            tb_Theater = Create_Theater_Table()
            tb_Theater.Rows(0).Cells(0).Text = String.Format("{0}", dtTheater.Rows(i)("theater_name"))

            Me.divExport.Controls.Add(tb_Theater)
            Me.divExport.Controls.Add(New LiteralControl("<br />"))

            cmd = ""
            cmd = cmd + "EXEC [dbo].[spGetRptBoxOfficeAndLateShow2] @p_RevernueDateFrom = '" + p_RevenueDateFrom + "'"
            cmd = cmd + ", @p_RevernueDateTo = '" + p_RevenueDateTo + "'"
            cmd = cmd + ", @p_TheaterIdFrom = " + p_TheaterIdFrom + ""
            cmd = cmd + ", @p_TheaterIdTo = " + p_TheaterIdTo + ""
            cmd = cmd + ", @p_TheaterId = " + CStr(CInt(dtTheater.Rows(i)("theater_id"))) + ""
            cmd = cmd + ", @p_UserId = '" + CStr(dtTheater.Rows(i)("user_id")) + "'"
            cmd = cmd + ", @p_ReportSection = 'Report_Sub_CheckerWage'"

            Dim dsCheckerWage As DataSet = cDatabase.GetDataSet(cmd)
            Dim dtCheckerWage As DataTable = dsCheckerWage.Tables(0)
            Dim dtCheckerWageMovieTotal As DataTable = dsCheckerWage.Tables(1)
            Dim dtCheckerWageTotal As DataTable = dsCheckerWage.Tables(2)
            Dim dtCheckerWageFormerWage As DataTable = dsCheckerWage.Tables(3)
            Dim dtCheckerWagePresentWage As DataTable = dsCheckerWage.Tables(4)

            '--- สร้างตารางข้อมูลได้ Checker
            tb_CheckerWage = Create_CheckerWage_Table()

            Dim intTheaterRevenueTotal As Decimal = 0
            Dim intTheaterAdmsTotal As Integer = 0

            For j As Integer = 0 To dtCheckerWage.Rows.Count - 1
                '--- สร้างแถว Revenue Date
                If (j = 0) _
                OrElse ((j >= 1) AndAlso (dtCheckerWage.Rows(j)("revenue_date") <> dtCheckerWage.Rows(j - 1)("revenue_date"))) _
                Then
                    tr_CheckerWage_RevenueDate = Create_CheckerWage_RevenueDate_TableRow()
                    tr_CheckerWage_RevenueDate.Cells(0).Text = String.Format("{0:dd-MMM-yyyy}", dtCheckerWage.Rows(j)("revenue_date"))
                    tb_CheckerWage.Rows.Add(tr_CheckerWage_RevenueDate)
                End If

                '--- สร้างแถว Theatre & Screen, Title, Sound, ,.... Session, Wage, Total, Checker
                tr_CheckerWage_TheaterSub = Create_CheckerWage_TheaterSub_TableRow()
                tr_CheckerWage_TheaterSub.Cells(0).Text = String.Format("{0}", dtCheckerWage.Rows(j)("theatersub_name"))
                tr_CheckerWage_TheaterSub.Cells(1).Text = String.Format("{0}", dtCheckerWage.Rows(j)("movie_nameen"))
                tr_CheckerWage_TheaterSub.Cells(2).Text = String.Format("{0}", dtCheckerWage.Rows(j)("film_type_sound_header_group"))
                tr_CheckerWage_TheaterSub.Cells(3).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_1"))
                tr_CheckerWage_TheaterSub.Cells(4).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_1"))
                tr_CheckerWage_TheaterSub.Cells(5).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_2"))
                tr_CheckerWage_TheaterSub.Cells(6).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_2"))
                tr_CheckerWage_TheaterSub.Cells(7).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_3"))
                tr_CheckerWage_TheaterSub.Cells(8).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_3"))
                tr_CheckerWage_TheaterSub.Cells(9).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_4"))
                tr_CheckerWage_TheaterSub.Cells(10).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_4"))
                tr_CheckerWage_TheaterSub.Cells(11).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_5"))
                tr_CheckerWage_TheaterSub.Cells(12).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_5"))
                tr_CheckerWage_TheaterSub.Cells(13).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_6"))
                tr_CheckerWage_TheaterSub.Cells(14).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_6"))
                tr_CheckerWage_TheaterSub.Cells(15).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_7"))
                tr_CheckerWage_TheaterSub.Cells(16).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_7"))
                tr_CheckerWage_TheaterSub.Cells(17).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount_8"))
                tr_CheckerWage_TheaterSub.Cells(18).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms_8"))
                tr_CheckerWage_TheaterSub.Cells(19).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_session"))
                tr_CheckerWage_TheaterSub.Cells(20).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("wage_amt"))
                tr_CheckerWage_TheaterSub.Cells(21).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_amount"))
                tr_CheckerWage_TheaterSub.Cells(22).Text = String.Format("{0:#,##0}", dtCheckerWage.Rows(j)("revenue_adms"))
                tr_CheckerWage_TheaterSub.Cells(23).Text = String.Format("{0}", dtCheckerWage.Rows(j)("user_name"))
                tr_CheckerWage_TheaterSub.Cells(24).Text = String.Format("{0}{1}", dtCheckerWage.Rows(j)("zzzz_checker_type"), dtCheckerWage.Rows(j)("screen_id"))
                tb_CheckerWage.Rows.Add(tr_CheckerWage_TheaterSub)

                intTheaterRevenueTotal = intTheaterRevenueTotal + CDec(dtCheckerWage.Rows(j)("revenue_amount"))
                intTheaterAdmsTotal = intTheaterAdmsTotal + CInt(dtCheckerWage.Rows(j)("revenue_adms"))

                '--- สร้างแถว Total โดย Revenue Date
                If (j = dtCheckerWage.Rows.Count - 1) _
                OrElse ((j <= dtCheckerWage.Rows.Count - 2) AndAlso (dtCheckerWage.Rows(j)("revenue_date") <> dtCheckerWage.Rows(j + 1)("revenue_date"))) _
                Then
                    tr_CheckerWage_TheaterSubTotal = Create_CheckerWage_TheaterSubTotal_TableRow()
                    tr_CheckerWage_TheaterSubTotal.Cells(1).Text = String.Format("{0:#,##0}", intTheaterRevenueTotal)
                    tr_CheckerWage_TheaterSubTotal.Cells(2).Text = String.Format("{0:#,##0}", intTheaterAdmsTotal)
                    tb_CheckerWage.Rows.Add(tr_CheckerWage_TheaterSubTotal)

                    intTheaterRevenueTotal = 0
                    intTheaterAdmsTotal = 0
                End If

            Next

            Me.divExport.Controls.Add(tb_CheckerWage)
            Me.divExport.Controls.Add(New LiteralControl("<br />"))



            cmd = ""
            cmd = cmd + "EXEC [dbo].[spGetRptBoxOfficeAndLateShow2] @p_RevernueDateFrom = '" + p_RevenueDateFrom + "'"
            cmd = cmd + ", @p_RevernueDateTo = '" + p_RevenueDateTo + "'"
            cmd = cmd + ", @p_TheaterIdFrom = " + p_TheaterIdFrom + ""
            cmd = cmd + ", @p_TheaterIdTo = " + p_TheaterIdTo + ""
            cmd = cmd + ", @p_TheaterId = " + CStr(CInt(dtTheater.Rows(i)("theater_id"))) + ""
            cmd = cmd + ", @p_UserId = '" + CStr(dtTheater.Rows(i)("user_id")) + "'"
            cmd = cmd + ", @p_ReportSection = 'Report_Sub_LateShow'"

            Dim dsLateShow As DataSet = cDatabase.GetDataSet(cmd)
            Dim dtLateShow As DataTable = dsLateShow.Tables(0)
            Dim dtLateShowMovieTotal As DataTable = dsLateShow.Tables(1)
            Dim dtLateShowTotal As DataTable = dsLateShow.Tables(2)

            '--- สร้างตารางสรุป LateShow ทั้งหมด
            tb_LateShow = Create_LateShow_Table()

            '--- สร้างแถว Date, Late Show, Title, Expense
            For j As Integer = 0 To dtLateShow.Rows.Count - 1
                tr_LateShow_RevenueDate = Create_LateShow_RevenueDate_TableRow()
                tr_LateShow_RevenueDate.Cells(0).Text = String.Format("{0:dd-MMM-yyyy}", dtLateShow.Rows(j)("revenue_date"))
                tr_LateShow_RevenueDate.Cells(1).Text = String.Format("{0}", dtLateShow.Rows(j)("revenue_time"))
                tr_LateShow_RevenueDate.Cells(2).Text = String.Format("{0}", dtLateShow.Rows(j)("movie_nameen"))
                tr_LateShow_RevenueDate.Cells(3).Text = String.Format("{0:#,##0}", dtLateShow.Rows(j)("expense_amt"))
                tb_LateShow.Rows.Add(tr_LateShow_RevenueDate)
            Next

            '--- สร้างแถว Title, Expense
            For j As Integer = 0 To dtLateShowMovieTotal.Rows.Count - 1
                tr_LateShow_MovieTotal = Create_LateShow_MovieTotal_TableRow()
                tr_LateShow_MovieTotal.Cells(1).Text = String.Format("{0}", dtLateShowMovieTotal.Rows(j)("movie_nameen"))
                tr_LateShow_MovieTotal.Cells(2).Text = String.Format("{0:#,##0}", dtLateShowMovieTotal.Rows(j)("expense_amt"))
                tb_LateShow.Rows.Add(tr_LateShow_MovieTotal)
            Next

            '--- สร้างแถว Total
            Dim intLateShowTotal As Decimal = 0
            tr_LateShow_Total = Create_LateShow_Total_TableRow()
            If Not dtLateShowTotal Is Nothing AndAlso dtLateShowTotal.Rows.Count > 0 Then
                tr_LateShow_Total.Cells(1).Text = String.Format("{0:#,##0}", dtLateShowTotal.Rows(0)("expense_amt"))
                intLateShowTotal = CDec(dtLateShowTotal.Rows(0)("expense_amt"))
            Else
                tr_LateShow_Total.Cells(1).Text = String.Format("{0:#,##0}", 0)
                intLateShowTotal = 0
            End If
            tb_LateShow.Rows.Add(tr_LateShow_Total)

            Me.divExport.Controls.Add(tb_LateShow)
            Me.divExport.Controls.Add(New LiteralControl("<br />"))



            '--- สร้างตารางสรุปรายได้ Checker ทั้งหมด
            tb_Summary = Create_Summary_Table()

            '--- สร้างแถว Title, Amount (Baht)
            For j As Integer = 0 To dtCheckerWageMovieTotal.Rows.Count - 1
                tb_Summary_MovieTotal = Create_Summary_MovieTotal_TableRow()
                tb_Summary_MovieTotal.Cells(0).Text = String.Format("{0}", dtCheckerWageMovieTotal.Rows(j)("movie_nameen"))
                tb_Summary_MovieTotal.Cells(1).Text = String.Format("{0:#,##0}", dtCheckerWageMovieTotal.Rows(j)("wage_amt"))
                tb_Summary.Rows.Add(tb_Summary_MovieTotal)
            Next

            '--- สร้างแถว Total (Baht)
            Dim intCheckerWageTotal As Decimal = 0
            tr_Summary_Total = Create_Summary_Total_TableRow()
            If Not dtCheckerWageTotal Is Nothing AndAlso dtCheckerWageTotal.Rows.Count > 0 Then
                tr_Summary_Total.Cells(1).Text = String.Format("{0:#,##0}", dtCheckerWageTotal.Rows(0)("wage_amt"))
                intCheckerWageTotal = CDec(dtCheckerWageTotal.Rows(0)("wage_amt"))
            Else
                tr_Summary_Total.Cells(1).Text = String.Format("{0:#,##0}", 0)
                intCheckerWageTotal = 0
            End If
            tb_Summary.Rows.Add(tr_Summary_Total)

            '--- สร้างแถว Grand Total (Wage + Late Show)
            Dim intGrandTotal As Decimal = intCheckerWageTotal + intLateShowTotal
            tr_Summary_GrandTotal = Create_Summary_GrandTotal_TableRow()
            tr_Summary_GrandTotal.Cells(1).Text = String.Format("{0:#,##0}", intGrandTotal)
            tb_Summary.Rows.Add(tr_Summary_GrandTotal)

            '--- สร้างแถว Former Wage
            tr_Summary_FormerWage = Create_Summary_FormerWage_TableRow()
            If Not dtCheckerWageFormerWage Is Nothing AndAlso dtCheckerWageFormerWage.Rows.Count > 0 Then
                tr_Summary_FormerWage.Cells(1).Text = String.Format("{0}", dtCheckerWageFormerWage.Rows(0)("wage_amt_text"))
            Else
                tr_Summary_FormerWage.Cells(1).Text = String.Format("{0}", "")
            End If
            tb_Summary.Rows.Add(tr_Summary_FormerWage)

            '--- สร้างแถว Present Wage
            tr_Summary_PresentWage = Create_Summary_PresentWage_TableRow()
            If Not dtCheckerWagePresentWage Is Nothing AndAlso dtCheckerWagePresentWage.Rows.Count > 0 Then
                tr_Summary_PresentWage.Cells(1).Text = String.Format("{0}", dtCheckerWagePresentWage.Rows(0)("wage_amt_text"))
            Else
                tr_Summary_PresentWage.Cells(1).Text = String.Format("{0}", "")
            End If
            tb_Summary.Rows.Add(tr_Summary_PresentWage)

            '--- สร้างแถว Checker
            tr_Summary_User = Create_Summary_User_TableRow()
            tr_Summary_User.Cells(0).Text = String.Format("____________________{0}", dtTheater.Rows(i)("user_name"))
            tb_Summary.Rows.Add(tr_Summary_User)

            Me.divExport.Controls.Add(tb_Summary)
            Me.divExport.Controls.Add(New LiteralControl("<br />"))
        Next

        Me.form1.Controls.Remove(Me.divExportTemplate)

    End Sub

    Private Function Create_Header_Table()
        Dim tb As Table
        Dim tbTmp As Table = Me.tbHeaderTemplate

        tb = New Table
        tb.Width = tbTmp.Width
        tb.CellPadding = tbTmp.CellPadding
        tb.CellSpacing = tbTmp.CellSpacing
        tb.BorderStyle = tbTmp.BorderStyle
        tb.BorderWidth = tbTmp.BorderWidth
        tb.BorderColor = tbTmp.BorderColor
        tb.GridLines = tbTmp.GridLines
        tb.Font.Name = tbTmp.Font.Name

        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(0).Cells.Count - 1
            tb.Rows(0).Cells.Add(New TableCell)
            tb.Rows(0).Cells(i).Width = tbTmp.Rows(0).Cells(i).Width
            tb.Rows(0).Cells(i).Height = tbTmp.Rows(0).Cells(i).Height
            tb.Rows(0).Cells(i).RowSpan = tbTmp.Rows(0).Cells(i).RowSpan
            tb.Rows(0).Cells(i).ColumnSpan = tbTmp.Rows(0).Cells(i).ColumnSpan
            tb.Rows(0).Cells(i).HorizontalAlign = tbTmp.Rows(0).Cells(i).HorizontalAlign
            tb.Rows(0).Cells(i).VerticalAlign = tbTmp.Rows(0).Cells(i).VerticalAlign
            tb.Rows(0).Cells(i).BackColor = tbTmp.Rows(0).Cells(i).BackColor
            tb.Rows(0).Cells(i).ForeColor = tbTmp.Rows(0).Cells(i).ForeColor
            tb.Rows(0).Cells(i).Font.Size = tbTmp.Rows(0).Cells(i).Font.Size
            tb.Rows(0).Cells(i).Font.Bold = tbTmp.Rows(0).Cells(i).Font.Bold
            tb.Rows(0).Cells(i).Text = tbTmp.Rows(0).Cells(i).Text
        Next

        Return tb
    End Function

    Private Function Create_Theater_Table() As Table
        Dim tb As Table
        Dim tbTmp As Table = Me.tbTheaterTemplate

        tb = New Table
        tb.Width = tbTmp.Width
        tb.CellPadding = tbTmp.CellPadding
        tb.CellSpacing = tbTmp.CellSpacing
        tb.BorderStyle = tbTmp.BorderStyle
        tb.BorderWidth = tbTmp.BorderWidth
        tb.BorderColor = tbTmp.BorderColor
        tb.GridLines = tbTmp.GridLines
        tb.Font.Name = tbTmp.Font.Name

        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(0).Cells.Count - 1
            tb.Rows(0).Cells.Add(New TableCell)
            tb.Rows(0).Cells(i).Width = tbTmp.Rows(0).Cells(i).Width
            tb.Rows(0).Cells(i).Height = tbTmp.Rows(0).Cells(i).Height
            tb.Rows(0).Cells(i).RowSpan = tbTmp.Rows(0).Cells(i).RowSpan
            tb.Rows(0).Cells(i).ColumnSpan = tbTmp.Rows(0).Cells(i).ColumnSpan
            tb.Rows(0).Cells(i).HorizontalAlign = tbTmp.Rows(0).Cells(i).HorizontalAlign
            tb.Rows(0).Cells(i).VerticalAlign = tbTmp.Rows(0).Cells(i).VerticalAlign
            tb.Rows(0).Cells(i).BackColor = tbTmp.Rows(0).Cells(i).BackColor
            tb.Rows(0).Cells(i).ForeColor = tbTmp.Rows(0).Cells(i).ForeColor
            tb.Rows(0).Cells(i).Font.Size = tbTmp.Rows(0).Cells(i).Font.Size
            tb.Rows(0).Cells(i).Font.Bold = tbTmp.Rows(0).Cells(i).Font.Bold
            tb.Rows(0).Cells(i).Text = tbTmp.Rows(0).Cells(i).Text
        Next

        Return tb
    End Function

    Private Function Create_CheckerWage_Table()
        Dim tb As Table
        Dim tbTmp As Table = Me.tbCheckerWageTemplate

        tb = New Table
        tb.Width = tbTmp.Width
        tb.CellPadding = tbTmp.CellPadding
        tb.CellSpacing = tbTmp.CellSpacing
        tb.BorderStyle = tbTmp.BorderStyle
        tb.BorderWidth = tbTmp.BorderWidth
        tb.BorderColor = tbTmp.BorderColor
        tb.GridLines = tbTmp.GridLines
        tb.Font.Name = tbTmp.Font.Name

        '--- print header 1
        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(0).Cells.Count - 1
            tb.Rows(0).Cells.Add(New TableCell)
            tb.Rows(0).Cells(i).Width = tbTmp.Rows(0).Cells(i).Width
            tb.Rows(0).Cells(i).Height = tbTmp.Rows(0).Cells(i).Height
            tb.Rows(0).Cells(i).RowSpan = tbTmp.Rows(0).Cells(i).RowSpan
            tb.Rows(0).Cells(i).ColumnSpan = tbTmp.Rows(0).Cells(i).ColumnSpan
            tb.Rows(0).Cells(i).HorizontalAlign = tbTmp.Rows(0).Cells(i).HorizontalAlign
            tb.Rows(0).Cells(i).VerticalAlign = tbTmp.Rows(0).Cells(i).VerticalAlign
            tb.Rows(0).Cells(i).BackColor = tbTmp.Rows(0).Cells(i).BackColor
            tb.Rows(0).Cells(i).ForeColor = tbTmp.Rows(0).Cells(i).ForeColor
            tb.Rows(0).Cells(i).Font.Size = tbTmp.Rows(0).Cells(i).Font.Size
            tb.Rows(0).Cells(i).Font.Bold = tbTmp.Rows(0).Cells(i).Font.Bold
            tb.Rows(0).Cells(i).Text = tbTmp.Rows(0).Cells(i).Text
        Next

        '--- print header 2
        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(1).Cells.Count - 1
            tb.Rows(1).Cells.Add(New TableCell)
            tb.Rows(1).Cells(i).Width = tbTmp.Rows(1).Cells(i).Width
            tb.Rows(1).Cells(i).Height = tbTmp.Rows(1).Cells(i).Height
            tb.Rows(1).Cells(i).RowSpan = tbTmp.Rows(1).Cells(i).RowSpan
            tb.Rows(1).Cells(i).ColumnSpan = tbTmp.Rows(1).Cells(i).ColumnSpan
            tb.Rows(1).Cells(i).HorizontalAlign = tbTmp.Rows(1).Cells(i).HorizontalAlign
            tb.Rows(1).Cells(i).VerticalAlign = tbTmp.Rows(1).Cells(i).VerticalAlign
            tb.Rows(1).Cells(i).BackColor = tbTmp.Rows(1).Cells(i).BackColor
            tb.Rows(1).Cells(i).ForeColor = tbTmp.Rows(1).Cells(i).ForeColor
            tb.Rows(1).Cells(i).Font.Size = tbTmp.Rows(1).Cells(i).Font.Size
            tb.Rows(1).Cells(i).Font.Bold = tbTmp.Rows(1).Cells(i).Font.Bold
            tb.Rows(1).Cells(i).Text = tbTmp.Rows(1).Cells(i).Text
        Next

        Return tb
    End Function

    Private Function Create_CheckerWage_RevenueDate_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbCheckerWageTemplate.Rows(2)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_CheckerWage_TheaterSub_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbCheckerWageTemplate.Rows(3)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_CheckerWage_TheaterSubTotal_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbCheckerWageTemplate.Rows(4)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_LateShow_Table()
        Dim tb As Table
        Dim tbTmp As Table = Me.tbLateShowTemplate

        tb = New Table
        tb.Width = tbTmp.Width
        tb.CellPadding = tbTmp.CellPadding
        tb.CellSpacing = tbTmp.CellSpacing
        tb.BorderStyle = tbTmp.BorderStyle
        tb.BorderWidth = tbTmp.BorderWidth
        tb.BorderColor = tbTmp.BorderColor
        tb.GridLines = tbTmp.GridLines
        tb.Font.Name = tbTmp.Font.Name

        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(0).Cells.Count - 1
            tb.Rows(0).Cells.Add(New TableCell)
            tb.Rows(0).Cells(i).Width = tbTmp.Rows(0).Cells(i).Width
            tb.Rows(0).Cells(i).Height = tbTmp.Rows(0).Cells(i).Height
            tb.Rows(0).Cells(i).RowSpan = tbTmp.Rows(0).Cells(i).RowSpan
            tb.Rows(0).Cells(i).ColumnSpan = tbTmp.Rows(0).Cells(i).ColumnSpan
            tb.Rows(0).Cells(i).HorizontalAlign = tbTmp.Rows(0).Cells(i).HorizontalAlign
            tb.Rows(0).Cells(i).VerticalAlign = tbTmp.Rows(0).Cells(i).VerticalAlign
            tb.Rows(0).Cells(i).BackColor = tbTmp.Rows(0).Cells(i).BackColor
            tb.Rows(0).Cells(i).ForeColor = tbTmp.Rows(0).Cells(i).ForeColor
            tb.Rows(0).Cells(i).Font.Size = tbTmp.Rows(0).Cells(i).Font.Size
            tb.Rows(0).Cells(i).Font.Bold = tbTmp.Rows(0).Cells(i).Font.Bold
            tb.Rows(0).Cells(i).Text = tbTmp.Rows(0).Cells(i).Text
        Next

        Return tb
    End Function

    Private Function Create_LateShow_RevenueDate_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbLateShowTemplate.Rows(1)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_LateShow_MovieTotal_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbLateShowTemplate.Rows(2)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_LateShow_Total_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbLateShowTemplate.Rows(3)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_Table() As Table
        Dim tb As Table
        Dim tbTmp As Table = Me.tbSummaryTemplate

        tb = New Table
        tb.Width = tbTmp.Width
        tb.CellPadding = tbTmp.CellPadding
        tb.CellSpacing = tbTmp.CellSpacing
        tb.BorderStyle = tbTmp.BorderStyle
        tb.BorderWidth = tbTmp.BorderWidth
        tb.BorderColor = tbTmp.BorderColor
        tb.GridLines = tbTmp.GridLines
        tb.Font.Name = tbTmp.Font.Name

        tb.Rows.Add(New TableRow)
        For i As Integer = 0 To tbTmp.Rows(0).Cells.Count - 1
            tb.Rows(0).Cells.Add(New TableCell)
            tb.Rows(0).Cells(i).Width = tbTmp.Rows(0).Cells(i).Width
            tb.Rows(0).Cells(i).Height = tbTmp.Rows(0).Cells(i).Height
            tb.Rows(0).Cells(i).RowSpan = tbTmp.Rows(0).Cells(i).RowSpan
            tb.Rows(0).Cells(i).ColumnSpan = tbTmp.Rows(0).Cells(i).ColumnSpan
            tb.Rows(0).Cells(i).HorizontalAlign = tbTmp.Rows(0).Cells(i).HorizontalAlign
            tb.Rows(0).Cells(i).VerticalAlign = tbTmp.Rows(0).Cells(i).VerticalAlign
            tb.Rows(0).Cells(i).BackColor = tbTmp.Rows(0).Cells(i).BackColor
            tb.Rows(0).Cells(i).ForeColor = tbTmp.Rows(0).Cells(i).ForeColor
            tb.Rows(0).Cells(i).Font.Size = tbTmp.Rows(0).Cells(i).Font.Size
            tb.Rows(0).Cells(i).Font.Bold = tbTmp.Rows(0).Cells(i).Font.Bold
            tb.Rows(0).Cells(i).Text = tbTmp.Rows(0).Cells(i).Text
        Next

        Return tb
    End Function

    Private Function Create_Summary_MovieTotal_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(1)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_Total_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(2)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_GrandTotal_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(3)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_FormerWage_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(4)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_PresentWage_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(5)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Private Function Create_Summary_User_TableRow() As TableRow
        Dim tr As TableRow
        Dim trTmp As TableRow = Me.tbSummaryTemplate.Rows(6)

        tr = New TableRow
        For i As Integer = 0 To trTmp.Cells.Count - 1
            tr.Cells.Add(New TableCell)
            tr.Cells(i).Width = trTmp.Cells(i).Width
            tr.Cells(i).Height = trTmp.Cells(i).Height
            tr.Cells(i).RowSpan = trTmp.Cells(i).RowSpan
            tr.Cells(i).ColumnSpan = trTmp.Cells(i).ColumnSpan
            tr.Cells(i).HorizontalAlign = trTmp.Cells(i).HorizontalAlign
            tr.Cells(i).VerticalAlign = trTmp.Cells(i).VerticalAlign
            tr.Cells(i).BackColor = trTmp.Cells(i).BackColor
            tr.Cells(i).ForeColor = trTmp.Cells(i).ForeColor
            tr.Cells(i).Font.Size = trTmp.Cells(i).Font.Size
            tr.Cells(i).Font.Bold = trTmp.Cells(i).Font.Bold
            tr.Cells(i).Text = trTmp.Cells(i).Text
        Next

        Return tr
    End Function

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
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

        Controls.Add(frm)
        frm.RenderControl(hw)
        'Response.Write(tw.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
        Response.End()
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptBoxOfficeAndLateShowParam2.aspx")
    End Sub
End Class