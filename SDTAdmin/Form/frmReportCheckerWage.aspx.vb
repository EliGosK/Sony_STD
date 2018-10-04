Option Strict On

Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports SDTCommon.Extensions
Imports GridViewUtils

Namespace Form
    Partial Public Class FrmReportCheckerWage
        Inherits Page

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmReportCheckerWageParam.aspx")
        End Sub

        Protected Sub BtnExportClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
            Dim userIdStr As String = Request.QueryString("Userid")
            Dim exportFile As String
            If userIdStr.Contains(",") Then
                exportFile = "CheckerWage.xls"
            Else
                Dim userId As Int32 = CType(Request.QueryString("Userid"), Integer)
                exportFile = String.Format("CheckerWage_{0}.xls", userId)
            End If

            Response.Clear()
            'Response.ContentType = "application/vnd.ms-excel"
            'Response.AddHeader("Content-Disposition", "attachment; filename=" & exportFile)
            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Response.BufferOutput = True
            'Response.ContentEncoding = Encoding.UTF8
            'Response.Charset = "UTF-8"
            'EnableViewState = False

            'Fix for thai language
            Response.AddHeader("content-disposition", "attachment;filename=" & exportFile)
            Response.ContentType = "application/ms-excel"
            Response.ContentEncoding = Encoding.Unicode
            Response.BinaryWrite(Encoding.Unicode.GetPreamble())

            Dim myStringWriter As New StringWriter()
            Dim myHtmlWriter As New HtmlTextWriter(myStringWriter)
            Dim frm As New HtmlForm()
            frm.Attributes("runat") = "server"
            CreateResult(frm)
            Controls.Add(frm)
            frm.RenderControl(myHtmlWriter)
            Response.Write(myStringWriter.ToString())

            Response.End()
            Response.Redirect(exportFile)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If

            CreateResult(pnlResult)
        End Sub

#End Region

#Region "Methods"

        Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        End Sub

        Private Shared Function CreateBoundField(ByVal dataField As String, ByVal headerText As String, ByVal dataFormatString As String, ByVal hAlign As HorizontalAlign, ByVal percentWidth As Unit) As BoundField
            Dim f As New BoundField
            With f
                .DataField = dataField
                .HeaderText = headerText
                .DataFormatString = dataFormatString
                .SortExpression = dataField
                .HtmlEncode = False
                With .HeaderStyle
                    .BackColor = ColorTranslator.FromHtml("#5D7B9D")
                    .Font.Bold = True
                    .ForeColor = Color.White
                    .HorizontalAlign = HorizontalAlign.Center
                End With
                With .ControlStyle
                    .BackColor = ColorTranslator.FromHtml("#E2DED6")
                    .Font.Bold = True
                    .ForeColor = ColorTranslator.FromHtml("#333333")
                End With
                With .ItemStyle
                    If Not percentWidth = 0 Then
                        .Width = percentWidth
                    End If
                    .HorizontalAlign = hAlign
                    .Font.Underline = False
                End With
            End With
            Return f
        End Function

        Private Shared Function CreateGridView(ByVal alternatingRowStyle As Boolean) As GridView
            Dim dgv As New GridView
            With dgv
                .Attributes("runat") = "server"
                .AllowSorting = False
                .AutoGenerateColumns = False

                .BorderColor = Color.Black
                .BorderStyle = BorderStyle.Solid
                .BorderWidth = 1
                .CellPadding = 2
                .EnableSortingAndPagingCallbacks = True
                .Font.Name = "Tahoma"

                .GridLines = GridLines.Both
                .ShowHeader = True
                .BackColor = Color.White
                .Font.Size = 8
                .ForeColor = Color.Black

                .Height = 20
                If alternatingRowStyle Then
                    With .RowStyle
                        .BackColor = Color.White
                        .ForeColor = ColorTranslator.FromHtml("#284775")
                    End With
                    With .AlternatingRowStyle
                        .BackColor = ColorTranslator.FromHtml("#F7F6F3")
                        .ForeColor = ColorTranslator.FromHtml("#333333")
                    End With
                End If

                With .PagerStyle
                    .BackColor = ColorTranslator.FromHtml("#284775")
                    .ForeColor = Color.White
                    .HorizontalAlign = HorizontalAlign.Center
                End With
                With .SelectedRowStyle
                    .BackColor = ColorTranslator.FromHtml("#E2DED6")
                    .Font.Bold = True
                    .ForeColor = ColorTranslator.FromHtml("#333333")
                End With
                With .EditRowStyle
                    .BackColor = ColorTranslator.FromHtml("#999999")
                    .HorizontalAlign = HorizontalAlign.Center
                End With
                With .FooterStyle
                    .BackColor = ColorTranslator.FromHtml("#5D7B9D")
                    .Font.Bold = True
                    .ForeColor = Color.White
                End With
            End With

            Return dgv
        End Function

        Private Shared Sub GridRowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.SetRenderMethodDelegate(AddressOf RenderHeader)
            End If
        End Sub

        Private Shared Sub GridRowRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim grid As GridView = CType(sender, GridView)
            Dim userName As Object = DataBinder.Eval(e.Row.DataItem, "user_name")
            If IsNothing(userName) OrElse userName Is DBNull.Value Then
                Dim colSpan As Int32 = grid.Columns.Count
                For i As Integer = 1 To colSpan - 1
                    e.Row.Cells(i).Visible = False
                    e.Row.Cells(i).Controls.Clear()
                Next
                With e.Row.Cells(0)
                    .Attributes("ColSpan") = colSpan.ToString()
                    .BackColor = ColorTranslator.FromHtml("#FFFFE0")
                    .ForeColor = Color.Red
                    .Font.Bold = True
                    .Font.Size = 10
                End With
            Else
                Dim section As String = userName.ToString()
                If section = "dayFooter" OrElse section = "totalFooter" OrElse section = "grandTotalFooter" Then
                    Const colSpan As Integer = 23
                    For i As Integer = 1 To colSpan - 1
                        e.Row.Cells(i).Visible = False
                        e.Row.Cells(i).Controls.Clear()
                    Next
                    e.Row.Cells(0).Attributes("ColSpan") = colSpan.ToString()
                    e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right

                    Select Case userName.ToString()
                    Case "dayFooter"
                        For i As Integer = 0 To grid.Columns.Count - 1
                            With e.Row.Cells(i)
                                .ForeColor = Color.Blue
                                .Font.Bold = True
                                .Font.Size = 10
                            End With
                        Next
                        For i As Integer = 1 To grid.Columns.Count - 1
                            With e.Row.Cells(i)
                                .BackColor = ColorTranslator.FromHtml("#F7F6F3")
                            End With
                        Next
                    Case "totalFooter"
                        For i As Integer = 0 To grid.Columns.Count - 1
                            With e.Row.Cells(i)
                                .ForeColor = Color.Green
                                .Font.Bold = True
                                .Font.Size = 11
                            End With
                        Next
                        For i As Integer = 1 To grid.Columns.Count - 1
                            With e.Row.Cells(i)
                                .BackColor = ColorTranslator.FromHtml("#CADCEF")
                            End With
                        Next
                    Case "grandTotalFooter"
                        For i As Integer = colSpan + 1 To grid.Columns.Count - 1
                            e.Row.Cells(i).Visible = False
                            e.Row.Cells(i).Controls.Clear()
                        Next
                        e.Row.Cells(colSpan).Attributes("ColSpan") = (grid.Columns.Count - colSpan).ToString()
                        e.Row.Cells(colSpan).HorizontalAlign = HorizontalAlign.Center
                        Dim d As Decimal = 0
                        Decimal.TryParse(e.Row.Cells(colSpan).Text, d)
                        e.Row.Cells(colSpan).Text = d.ToString("#,###")
                        For i As Integer = 0 To grid.Columns.Count - 1
                            With e.Row.Cells(i)
                                .BackColor = Color.Green
                                .ForeColor = Color.White
                                .Font.Bold = True
                                .Font.Size = 12
                            End With
                        Next
                    End Select
                End If
            End If
        End Sub

        Private Shared Sub GridRowRowDataBoundMovie(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim grid As GridView = CType(sender, GridView)
            Dim recordType As Object = DataBinder.Eval(e.Row.DataItem, "record_type")
            If IsNothing(recordType) OrElse recordType Is DBNull.Value Then
            Else
                Dim section As String = recordType.ToString()
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
                If section = "total" Then
                    For i As Integer = 0 To grid.Columns.Count - 1
                        With e.Row.Cells(i)
                            .ForeColor = Color.Green
                            .Font.Bold = True
                            .Font.Size = 9
                        End With
                    Next
                    For i As Integer = 1 To grid.Columns.Count - 1
                        With e.Row.Cells(i)
                            .BackColor = ColorTranslator.FromHtml("#CADCEF")
                        End With
                    Next
                ElseIf section = "grandTotal" Then
                    For i As Integer = 2 To grid.Columns.Count - 1
                        e.Row.Cells(i).Visible = False
                        e.Row.Cells(i).Controls.Clear()
                    Next
                    e.Row.Cells(1).Attributes("ColSpan") = (3).ToString()
                    e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Center
                    Dim d As Decimal = 0
                    Decimal.TryParse(e.Row.Cells(1).Text, d)
                    e.Row.Cells(1).Text = d.ToString("#,###")
                    For i As Integer = 0 To grid.Columns.Count - 1
                        With e.Row.Cells(i)
                            .BackColor = Color.Green
                            .ForeColor = Color.White
                            .Font.Bold = True
                            .Font.Size = 10
                        End With
                    Next
                ElseIf section = "info" Then
                    For i As Integer = 2 To grid.Columns.Count - 1
                        e.Row.Cells(i).Visible = False
                        e.Row.Cells(i).Controls.Clear()
                    Next
                    e.Row.Cells(1).Attributes("ColSpan") = (3).ToString()
                    e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Center
                    For i As Integer = 0 To grid.Columns.Count - 1
                        With e.Row.Cells(i)
                            .ForeColor = Color.Black
                            .Font.Bold = True
                            .Font.Size = 9
                        End With
                    Next
                ElseIf section = "empty" Then
                    For i As Integer = 1 To grid.Columns.Count - 1
                        e.Row.Cells(i).Visible = False
                        e.Row.Cells(i).Controls.Clear()
                    Next
                    e.Row.Cells(0).Attributes("ColSpan") = (grid.Columns.Count).ToString()
                    e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Right
                End If
            End If
        End Sub

        Private Shared Sub RenderHeader(ByVal writer As HtmlTextWriter, ByVal ctl As Control)
            Dim gr As GridViewRow = CType(ctl, GridViewRow)
            Dim grd As GridView = CType(gr.NamingContainer, GridView)

            Dim stringHeader As String = grd.Columns.Cast (Of DataControlField)().Aggregate(String.Empty, Function(current, c) current + ("," + c.HeaderText))
            stringHeader = stringHeader.Substring(1)

            Dim dynHead As New DynamicHeaders(stringHeader)
            Dim headers As List(Of List(Of DynamicHeaderCell)) = dynHead.HeaderList()
            Dim firstHeaderRow As List(Of DynamicHeaderCell) = headers(0)
            Dim colSpan As Int32 = firstHeaderRow(0).ColSpan
            For i As Int32 = 1 To headers.Count - 3
                Dim otherHeaderRow As List(Of DynamicHeaderCell) = headers(i)
                otherHeaderRow(0).ColSpan = colSpan
                For j As Int32 = otherHeaderRow.Count - 1 To 1 Step - 1
                    otherHeaderRow.RemoveAt(j)
                Next
            Next

            Dim bkColors As Color() = {ColorTranslator.FromHtml("#5D7B9D"), ColorTranslator.FromHtml("#C3CAD6"), ColorTranslator.FromHtml("#CADCEF")}
            Dim frColors As Color() = {Color.White, Color.Black, Color.Black}
            Dim fntSizes As Int32() = {14, 8, 7}
            Dim fntAlign As HorizontalAlign() = {HorizontalAlign.Center, HorizontalAlign.Center, HorizontalAlign.Center}

            For i As Integer = 0 To headers.Count - 1
                Dim headerRow As List(Of DynamicHeaderCell) = headers(i)
                For Each t As DynamicHeaderCell In headerRow
                    Dim item As New TableCell
                    item.Text = t.Header
                    item.ColumnSpan = t.ColSpan
                    item.RowSpan = t.RowSpan
                    item.HorizontalAlign = fntAlign(i)
                    item.VerticalAlign = VerticalAlign.Middle
                    item.Font.Bold = False
                    'item.Font.Name = "arial, helvetica,sans-serif"
                    item.Font.Size = fntSizes(i)
                    item.ForeColor = frColors(i)
                    item.BackColor = bkColors(i)
                    item.RenderControl(writer)
                Next
                writer.WriteEndTag("TR")
                If i < headers.Count - 1 Then
                    writer.RenderBeginTag("TR")
                End If
            Next
        End Sub

        Private Shared Sub CreateUserData(ByVal pnl As Control, ByVal userId As Int32, ByVal dateFrom As Date, ByVal dateTo As Date)
            Dim ds As DataSet = SDTCommon.DBInterface.User.SelectCheckerWage(userId, dateFrom, dateTo)
            If ds Is Nothing OrElse ds.Tables.Count < 2 Then
                Return
            End If

            Dim dtb As DataTable = ds.Tables(0)
            If dtb Is Nothing OrElse dtb.Rows.Count = 0 Then
                Return
            End If

            Dim isPresentWage As Boolean
            Boolean.TryParse(CType(dtb.Rows(0)("use_present_Wage"), String), isPresentWage)

            Dim sumCollectReportAmt As Decimal = 0
            Dim sumWage As Decimal = 0
            Dim sumLastLateAmt As Decimal = 0
            Dim userName As String = CType(dtb.Rows(0)("user_name"), String)
            Dim checkDay As String = String.Empty
            Dim mergeFooter As DataRow = Nothing
            Dim dictMovie As New Dictionary(Of String, List(Of Decimal))
            For i As Int32 = dtb.Rows.Count - 1 To 0 Step - 1
                Dim day As String = CType(dtb.Rows(i)("revenue_date"), Date).ToString("dd-MMM-yy")
                Dim collectReportAmt As Decimal
                Decimal.TryParse(dtb.Rows(i)("collect_report_display").ToString(), collectReportAmt)
                Dim calWage As Decimal = CType(dtb.Rows(i)("cal_wage"), Decimal)
                Dim lastLateAmt As Decimal
                Decimal.TryParse(dtb.Rows(i)("last_late_display").ToString(), lastLateAmt)
                If checkDay = day Then
                    mergeFooter("collect_report_display") = CType(mergeFooter("collect_report_display"), Decimal) + collectReportAmt
                    mergeFooter("cal_wage") = CType(mergeFooter("cal_wage"), Decimal) + calWage
                    mergeFooter("last_late_display") = CType(mergeFooter("last_late_display"), Decimal) + lastLateAmt
                Else
                    mergeFooter = dtb.NewRow()
                    mergeFooter("user_name") = "dayFooter"
                    mergeFooter("collect_report_display") = collectReportAmt
                    mergeFooter("cal_wage") = calWage
                    mergeFooter("last_late_display") = lastLateAmt
                    dtb.Rows.InsertAt(mergeFooter, i + 1)

                    Dim mergeHeader As DataRow = dtb.NewRow()
                    mergeHeader("screen_name") = checkDay
                    dtb.Rows.InsertAt(mergeHeader, i + 2)

                    checkDay = day
                End If
                sumCollectReportAmt += collectReportAmt
                sumWage += calWage
                sumLastLateAmt += lastLateAmt

                Dim movieName As String = dtb.Rows(i)("movie_nameen").ToString()
                Dim l As List(Of Decimal)
                If dictMovie.ContainsKey(movieName) Then
                    l = dictMovie(movieName)
                    l(0) = l(0) + collectReportAmt
                    l(1) = l(1) + calWage
                    l(2) = l(2) + lastLateAmt
                Else
                    l = New List(Of Decimal)()
                    l.Add(collectReportAmt)
                    l.Add(calWage)
                    l.Add(lastLateAmt)
                    dictMovie.Add(movieName, l)
                End If
            Next

            dtb.Rows.RemoveAt(dtb.Rows.Count - 1)

            Dim firstHeader As DataRow = dtb.NewRow()
            firstHeader("screen_name") = CType(dtb.Rows(0)("revenue_date"), Date).ToString("dd-MMM-yy")
            dtb.Rows.InsertAt(firstHeader, 0)

            mergeFooter = dtb.NewRow()
            mergeFooter("user_name") = "totalFooter"
            mergeFooter("screen_name") = "Total"
            mergeFooter("collect_report_display") = sumCollectReportAmt
            mergeFooter("cal_wage") = sumWage
            mergeFooter("last_late_display") = sumLastLateAmt
            dtb.Rows.Add(mergeFooter)

            mergeFooter = dtb.NewRow()
            mergeFooter("user_name") = "grandTotalFooter"
            mergeFooter("screen_name") = "Grand Total (Collect Report + Wage + Late Show)"
            mergeFooter("collect_report_display") = sumCollectReportAmt + sumWage + sumLastLateAmt
            dtb.Rows.Add(mergeFooter)

            Dim grdData As GridView = CreateGridView(False)
            AddHandler grdData.RowCreated, AddressOf GridRowCreated
            AddHandler grdData.RowDataBound, AddressOf GridRowRowDataBound
            'grdData.Columns.Add(CreateBoundField("user_name", "Checker", String.Empty, HorizontalAlign.Left, 150))
            'grdData.Columns.Add(CreateBoundField("revenue_date", "Date", "{0:dd-MMM-yy}", HorizontalAlign.Left, 50))
            'grdData.Columns.Add(CreateBoundField("circuit_name", "Circuit", String.Empty, HorizontalAlign.Left, 50))
            grdData.Columns.Add(CreateBoundField("screen_name", "Theater Screen", String.Empty, HorizontalAlign.Left, 120))
            grdData.Columns.Add(CreateBoundField("movie_nameen", "Title", String.Empty, HorizontalAlign.Left, 150))
            grdData.Columns.Add(CreateBoundField("movie_seq", "Seq No.", String.Empty, HorizontalAlign.Left, 20))
            grdData.Columns.Add(CreateBoundField("film_type_sound_header_group", "Format", String.Empty, HorizontalAlign.Center, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_1", "Session 1|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_1", "Session 1|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_2", "Session 2|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_2", "Session 2|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_3", "Session 3|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_3", "Session 3|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_4", "Session 4|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_4", "Session 4|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_5", "Session 5|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_5", "Session 5|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_6", "Session 6|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_6", "Session 6|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_7", "Session 7|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_7", "Session 7|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("session_amount_8", "Session 8|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("session_adms_8", "Session 8|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            'grdData.Columns.Add(CreateBoundField("session_amount_9", "Session 9|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            'grdData.Columns.Add(CreateBoundField("session_adms_9", "Session 9|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))

            grdData.Columns.Add(CreateBoundField("sum_revenue_amount", "Total|Baht", "{0:#,##0}", HorizontalAlign.Right, 36))
            grdData.Columns.Add(CreateBoundField("sum_revenue_adms", "Total|ADMS", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("screen_session_count", "Total|Session", "{0:#,##0}", HorizontalAlign.Center, 20))
            grdData.Columns.Add(CreateBoundField("collect_report_display", "Collect Report", "{0:#,##0}", HorizontalAlign.Center, 20))
            grdData.Columns.Add(CreateBoundField("cal_wage", CType(IIf(isPresentWage, "Present", "Former"), String) + " Wage", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("order_complete_screen", "Screen Level", "{0:#,##0}", HorizontalAlign.Right, 20))
            grdData.Columns.Add(CreateBoundField("max_revenue_time", "Last Show", String.Empty, HorizontalAlign.Center, 36))
            grdData.Columns.Add(CreateBoundField("last_late_display", "Expense", "{0:#,##0}", HorizontalAlign.Center, 20))

            For Each c As DataControlField In grdData.Columns
                c.HeaderText = userName & " (" & dateFrom.ToString("dd-MMM-yy") & " to " & dateTo.ToString("dd-MMM-yy") & ")|" & c.HeaderText
            Next

            grdData.DataSource = dtb
            grdData.DataBind()

            Dim newPnl As New Panel
            newPnl.Controls.Add(grdData)
            pnl.Controls.Add(newPnl)

            Dim sep1 As New Label()
            sep1.Text = "<br />"
            pnl.Controls.Add(sep1)

            Dim dtbMovie As New DataTable
            dtbMovie.Columns.Add("record_type", GetType(String))
            dtbMovie.Columns.Add("movie_name", GetType(String))
            dtbMovie.Columns.Add("collect_report_display", GetType(String))
            dtbMovie.Columns.Add("cal_wage", GetType(Decimal))
            dtbMovie.Columns.Add("last_late_display", GetType(Decimal))

            Dim dr As DataRow
            For Each item As KeyValuePair(Of String, List(Of Decimal)) In dictMovie
                dr = dtbMovie.NewRow()
                dr("movie_name") = item.Key
                Dim l As List(Of Decimal) = item.Value
                dr("collect_report_display") = l(0)
                dr("cal_wage") = l(1)
                dr("last_late_display") = l(2)
                dtbMovie.Rows.Add(dr)
            Next
            dr = dtbMovie.NewRow()
            dr("record_type") = "total"
            dr("movie_name") = "Total"
            dr("collect_report_display") = sumCollectReportAmt
            dr("cal_wage") = sumWage
            dr("last_late_display") = sumLastLateAmt
            dtbMovie.Rows.Add(dr)

            dr = dtbMovie.NewRow()
            dr("record_type") = "grandTotal"
            dr("movie_name") = "Grand Total"
            dr("collect_report_display") = sumCollectReportAmt + sumWage + sumLastLateAmt
            dtbMovie.Rows.Add(dr)

            Dim drWage As DataRow = ds.Tables(1).Rows(0)

            dr = dtbMovie.NewRow()
            dr("record_type") = "info"
            dr("movie_name") = "Former Wage"
            dr("collect_report_display") = drWage("former_wage")
            dtbMovie.Rows.Add(dr)

            dr = dtbMovie.NewRow()
            dr("record_type") = "info"
            dr("movie_name") = "Present Wage"
            dr("collect_report_display") = drWage("present_wage")
            dtbMovie.Rows.Add(dr)

            dr = dtbMovie.NewRow()
            dr("record_type") = "empty"
            dr("movie_name") = " <br /><br />(" + userName + ")"
            dtbMovie.Rows.Add(dr)

            Dim grdMovie As GridView = CreateGridView(False)
            AddHandler grdMovie.RowDataBound, AddressOf GridRowRowDataBoundMovie
            grdMovie.Columns.Add(CreateBoundField("movie_name", "Title", String.Empty, HorizontalAlign.Left, 350))
            grdMovie.Columns.Add(CreateBoundField("collect_report_display", "Collect Report", "{0:#,##0}", HorizontalAlign.Right, 50))
            grdMovie.Columns.Add(CreateBoundField("cal_wage", "Wage", "{0:#,##0}", HorizontalAlign.Right, 50))
            grdMovie.Columns.Add(CreateBoundField("last_late_display", "Late Show", "{0:#,##0}", HorizontalAlign.Right, 50))

            grdMovie.DataSource = dtbMovie
            grdMovie.DataBind()
            pnl.Controls.Add(grdMovie)

            Dim sep2 As New Label()
            sep2.Text = "<br /><br />"
            pnl.Controls.Add(sep2)
        End Sub

        Private Sub CreateResult(ByVal pnl As Control)
            Dim userIdStr As String = Request.QueryString("Userid")
            Dim dateFromStr As String = Page.Request.QueryString("datefrom")
            Dim dateToStr As String = Page.Request.QueryString("dateto")
            Dim dateFrom As Date = dateFromStr.ToDateTime("yyyyMMdd")
            Dim dateTo As Date = dateToStr.ToDateTime("yyyyMMdd")

            If userIdStr.Contains(",") Then
                Dim arr() As String = userIdStr.Split(","(0))
                For Each userId As Integer In From s In arr Select CType(s, Integer)
                    CreateUserData(pnl, userId, dateFrom, dateTo)
                Next
            Else
                Dim userId As Int32 = CType(Request.QueryString("Userid"), Integer)
                CreateUserData(pnl, userId, dateFrom, dateTo)
            End If
        End Sub

#End Region
    End Class
End Namespace