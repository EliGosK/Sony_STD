Option Strict On

Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports GridViewUtils
Imports SDTCommon.DBInterface
Imports SDTCommon

Namespace Form
    Partial Public Class FrmReportSummaryTicket
        Inherits Page

        Private _dtbFooter As DataTable

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmReportSummaryTicketParam.aspx")
        End Sub

        Protected Sub BtnExportExportExcelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportExportExcel.Click
            Dim exportFile As String = "Export Excel-" & hdfTitle.Value & ".xls"
            Response.Clear()
            'Response.ContentType = "application/vnd.ms-excel"
            'Response.AddHeader("content-disposition", "attachment;filename=" & exportFile)
            'Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Response.BufferOutput = True
            'Response.ContentEncoding = Encoding.UTF8
            'Response.Charset = "UTF-8"
            'EnableViewState = False

            'Fix for thai language
            Response.AddHeader("content-disposition", "attachment;filename=" & exportFile)
            Response.ContentType = "application/ms-excel"
            Response.ContentEncoding = System.Text.Encoding.Unicode
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())

            Dim myStringWriter As New StringWriter()
            Dim myHtmlWriter As New HtmlTextWriter(myStringWriter)

            '-----------------------------------------------------
            'Dim tmpDataGrid As New DataGrid
            'tmpDataGrid.DataSource = TicketType.SelectData(Nothing, Nothing, 1, Nothing)
            'tmpDataGrid.DataBind()
            'tmpDataGrid.RenderControl(myHtmlWriter)

            'Dim frm As New HtmlForm()
            'Controls.Add(frm)
            'frm.Controls.Add(tbHeader)
            'frm.Attributes("runat") = "server"
            'frm.RenderControl(myHtmlWriter)

            grdData.RenderControl(myHtmlWriter)

            Response.Write(myStringWriter.ToString())

            Response.End()

            Response.Redirect(exportFile)
        End Sub

        Protected Sub GrdTicketTypeRowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdData.RowCreated
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.SetRenderMethodDelegate(AddressOf RenderHeader)
            End If
        End Sub

        Protected Sub GrdTicketTypeRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdData.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim screenId As Int32? = Utils.ConvertToInt32(Request.QueryString("ScreenId"))
                If IsNothing(screenId) Then
                    Dim paramName As String
                    Dim theaterId As Int32? = Utils.ConvertToInt32(Request.QueryString("TheaterId"))
                    Dim circuitId As Int32? = Utils.ConvertToInt32(Request.QueryString("CircuitId"))
                    If Not IsNothing(theaterId) Then
                        paramName = "&TheaterId=" & theaterId & "&ScreenId="
                    ElseIf Not IsNothing(circuitId) Then
                        paramName = "&TheaterId="
                    Else
                        paramName = "&CircuitId="
                    End If
                    e.Row.Cells(1).Text = "<a href='" & hdfParam.Value + paramName & DataBinder.Eval(e.Row.DataItem, "Id").ToString() & "'>" & e.Row.Cells(1).Text & "</a>"

                    For i As Int32 = 2 To e.Row.Cells.Count - 1
                        Dim c As TableCell = e.Row.Cells(i)
                        c.Text = String.Format("<div style='text-align: right'>{0}</div>", c.Text)
                    Next
                Else
                    For i As Int32 = 1 To e.Row.Cells.Count - 1
                        Dim c As TableCell = e.Row.Cells(i)
                        c.Text = String.Format("<div style='text-align: right'>{0}</div>", c.Text)
                    Next
                End If
            ElseIf e.Row.RowType = DataControlRowType.Footer Then
                If Not IsNothing(_dtbFooter) AndAlso _dtbFooter.Rows.Count > 0 Then
                    Dim dr As DataRow = _dtbFooter.Rows(0)
                    For i As Int32 = 0 To _dtbFooter.Columns.Count - 1
                        Dim c As TableCell = e.Row.Cells(i)
                        c.BackColor = Color.FromArgb(93, 123, 157)
                        c.Text = String.Format("<div style='text-align: right'>{0}</div>", dr(i))
                    Next
                End If
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If

            Dim type As String = Request.QueryString("Type")
            Dim movieId As Int32 = CType(Request.QueryString("MovieId"), Int32)
            Dim strStartDate As String = Request.QueryString("StartDate")
            Dim strEndDate As String = Request.QueryString("EndDate")
            Dim startDate As Date = Utils.ConvertDate(strStartDate, "yyyyMMdd")
            Dim endDate As Date = Utils.ConvertDate(strEndDate, "yyyyMMdd")

            Dim screenId As Int32? = Utils.ConvertToInt32(Request.QueryString("ScreenId"))
            Dim theaterId As Int32? = Utils.ConvertToInt32(Request.QueryString("TheaterId"))
            Dim circuitId As Int32? = Utils.ConvertToInt32(Request.QueryString("CircuitId"))

            hdfParam.Value = String.Format("frmReportSummaryTicket.aspx?Type={0}&MovieId={1}&StartDate={2}&EndDate={3}", type, movieId, strStartDate, strEndDate)

            Dim byTitle As String
            If Not IsNothing(screenId) Then
                byTitle = "Revenue Date"
            ElseIf Not IsNothing(theaterId) Then
                byTitle = "Screen"
            ElseIf Not IsNothing(circuitId) Then
                byTitle = "Theater"
            Else
                byTitle = "Circuit"
            End If

            Dim reportTitle As String = (type & " Summary Report by " & byTitle).ToUpper()
            Dim movieName As String = "Name : " & MovieAndTrailer.GetMovieDetail(movieId).Rows(0)("MovieName").ToString()
            Dim datePeriod As String = String.Format("From Date : {0} to {1}", startDate.ToString("ddd d-MMM-yyyy"), endDate.ToString("ddd d-MMM-yyyy"))
            Dim circuitTheater As String = CType(IIf(IsNothing(circuitId), String.Empty, "|Circuit : " & Circuit.SelectData(circuitId).Rows(0)("circuit_name").ToString()), String) & CType(IIf(IsNothing(theaterId), String.Empty, "|Theater : " & Theater.SelectData(theaterId, Nothing, Nothing).Rows(0)("theater_name").ToString()), String)
            Dim screen As String = CType(IIf(IsNothing(screenId), String.Empty, "|Screen : " & screenId.ToString()), String)

            hdfTitle.Value = reportTitle
            Dim topper As String = String.Format("{0}|{1}|{2}{3}{4}|", reportTitle, movieName, datePeriod, circuitTheater, screen)
            Dim ds As DataSet
            Dim freeTicket As Boolean = type = "Free Ticket"
            If freeTicket Then
                ds = Revenue.ReportSummaryFreeTicket(movieId, startDate, endDate, circuitId, theaterId, screenId)
            ElseIf type = "Per Cap" Then
                ds = Revenue.ReportSummaryFreeTicketAndPerCap(movieId, startDate, endDate, circuitId, theaterId, screenId)
            Else
                ds = Revenue.ReportSummaryTicketType(movieId, startDate, endDate, circuitId, theaterId, screenId)
            End If
            If Not IsNothing(ds) AndAlso ds.Tables.Count <> 0 Then
                _dtbFooter = ds.Tables(1)

                Dim dtb As DataTable = ds.Tables(0)

                '2013-05-09
                ' Change all 0 to empty
                For Each dr As DataRow In dtb.Rows
                    For i As Int32 = 0 To dtb.Columns.Count - 1
                        If dr(i).ToString() = "0" OrElse dr(i).ToString() = "0.00" Then
                            dr(i) = DBNull.Value
                        End If
                    Next
                Next

                hdfHeader.Value = String.Empty
                For Each c As DataColumn In dtb.Columns
                    hdfHeader.Value &= c.ColumnName & ","
                Next
                If hdfHeader.Value.Length > 0 Then
                    hdfHeader.Value = hdfHeader.Value.Substring(0, hdfHeader.Value.Length - 1)
                End If

                hdfHeader.Value = topper & hdfHeader.Value.Replace(",", "," & topper)

                grdData.DataSource = dtb
                grdData.DataBind()

            End If
        End Sub

#End Region

#Region "Methods"

        Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        End Sub

        Private Sub RenderHeader(ByVal writer As HtmlTextWriter, ByVal ctl As Control)
            If String.IsNullOrEmpty(hdfHeader.Value) Then
                Return
            End If

            Dim dynHead As New DynamicHeaders(hdfHeader.Value)
            Dim headers As List(Of List(Of DynamicHeaderCell)) = dynHead.HeaderList()
            Dim firstHeaderRow As List(Of DynamicHeaderCell) = headers(0)
            Dim colSpan As Int32 = firstHeaderRow(0).ColSpan
            For i As Int32 = 1 To headers.Count - 3
                Dim otherHeaderRow As List(Of DynamicHeaderCell) = headers(i)
                otherHeaderRow(0).ColSpan = colSpan
                For j As Int32 = otherHeaderRow.Count - 1 To 1 Step -1
                    otherHeaderRow.RemoveAt(j)
                Next
            Next

            Dim bkColors As Color() = {Color.FromArgb(194, 216, 254), Color.White, Color.White, Color.White, Color.White, Color.FromArgb(48, 61, 80), Color.FromArgb(93, 123, 157)}
            Dim frColors As Color() = {Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black, Color.Black}
            Dim fntSizes As Int32() = {14, 12, 12, 12, 12, 10, 8}
            Dim fntAlign As HorizontalAlign() = {HorizontalAlign.Center, HorizontalAlign.Left, HorizontalAlign.Left, HorizontalAlign.Left, HorizontalAlign.Left, HorizontalAlign.Center, HorizontalAlign.Center}

            frColors(headers.Count - 2) = Color.White
            bkColors(headers.Count - 2) = Color.FromArgb(48, 61, 80)
            bkColors(headers.Count - 1) = Color.FromArgb(93, 123, 157)
            fntSizes(headers.Count - 2) = 10
            fntSizes(headers.Count - 1) = 8
            fntAlign(headers.Count - 2) = HorizontalAlign.Center
            fntAlign(headers.Count - 1) = HorizontalAlign.Center

            For i As Integer = 0 To headers.Count - 1
                Dim headerRow As List(Of DynamicHeaderCell) = headers(i)
                For Each t As DynamicHeaderCell In headerRow
                    Dim item As New TableCell
                    item.Text = t.Header
                    item.ColumnSpan = t.ColSpan
                    item.RowSpan = t.RowSpan
                    item.HorizontalAlign = fntAlign(i)
                    item.VerticalAlign = VerticalAlign.Middle
                    item.Font.Bold = True
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

#End Region
    End Class
End Namespace