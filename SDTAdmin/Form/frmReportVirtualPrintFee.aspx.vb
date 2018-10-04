Option Strict On

Imports System.Text
Imports System.IO
Imports System.Collections.Generic
Imports SDTCommon.DBInterface
Imports GridViewUtils
Imports SDTCommon

Namespace Form
    Partial Public Class FrmReportVirtualPrintFee
        Inherits Page

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmVPF_Summary.aspx")
        End Sub

        Protected Sub BtnExportClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
            Const exportFile As String = "vpf_report.xls"
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

            'Response.Write(DecompressBase64(hdfExcel.Value))

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

        Private Function CreateGridView(ByVal isSummary As Boolean) As GridView
            Dim dgv As New GridView
            With dgv
                .Attributes("runat") = "server"
                .AllowSorting = False
                .AutoGenerateColumns = False

                .BorderColor = Color.Black
                .BorderStyle = BorderStyle.Solid
                .BorderWidth = 1
                .CellPadding = 4
                .EnableSortingAndPagingCallbacks = True
                .Font.Name = "Tahoma"

                .GridLines = GridLines.Both

                If isSummary Then
                    .ShowHeader = False
                    .BackColor = Color.Blue
                    .Font.Size = 10
                    .Font.Bold = True
                    .ForeColor = Color.White
                    .Height = 30
                    .HorizontalAlign = HorizontalAlign.Left
                Else
                    .ShowHeader = True
                    .BackColor = Color.White
                    .Font.Size = 7
                    .ForeColor = Color.Black

                    With .RowStyle
                        .BackColor = ColorTranslator.FromHtml("#F7F6F3")
                        .ForeColor = ColorTranslator.FromHtml("#333333")
                    End With
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
                    With .AlternatingRowStyle
                        .BackColor = Color.White
                        .ForeColor = ColorTranslator.FromHtml("#284775")
                    End With
                    With .FooterStyle
                        .BackColor = ColorTranslator.FromHtml("#5D7B9D")
                        .Font.Bold = True
                        .ForeColor = Color.White
                    End With
                    AddHandler dgv.RowCreated, AddressOf GridRowCreated
                End If
            End With

            Return dgv
        End Function

        Private Sub GridRowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.SetRenderMethodDelegate(AddressOf RenderHeader)
            End If
        End Sub

        Private Sub RenderHeader(ByVal writer As HtmlTextWriter, ByVal ctl As Control)
            Dim index As Int32 = hdfCaption.Value.IndexOf(",", StringComparison.Ordinal)
            Dim currentTheaterName As String = hdfCaption.Value.Substring(0, index)
            hdfCaption.Value = hdfCaption.Value.Substring(index + 1)
            Dim stringHeader As String = String.Empty
            Dim gr As GridViewRow = CType(ctl, GridViewRow)
            Dim grd As GridView = CType(gr.NamingContainer, GridView)
            For Each tc As TableCell In grd.HeaderRow.Cells
                Dim str() As String = tc.Text.Split("-"(0))
                'If str.Length < 2 Then
                '    stringHeader += "," + tc.Text
                'Else
                '    stringHeader += "," + str(0) + "-" + str(1) + "|" + str(2)
                'End If
                If str.Length < 2 Then
                    stringHeader += "," + currentTheaterName + "|" + tc.Text
                Else
                    stringHeader += "," + currentTheaterName + "|" + str(0) + "-" + str(1) + "|" + str(2)
                End If
            Next
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

            Dim bkColors As Color() = {Color.White, Color.FromArgb(194, 216, 254), Color.White}
            Dim frColors As Color() = {Color.Black, Color.Black, Color.Black}
            Dim fntSizes As Int32() = {9, 8, 7}
            Dim fntAlign As HorizontalAlign() = {HorizontalAlign.Left, HorizontalAlign.Center, HorizontalAlign.Center}

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

        Private Sub CreateResult(ByVal pnl As Control)
            Dim movieId As Int32 = CType(Request.QueryString("MovieId"), Int32)
            Dim theaterId As Int32? = Utils.ConvertToInt32(Request.QueryString("TheaterId"))
            Dim circuitId As Int32? = Utils.ConvertToInt32(Request.QueryString("CircuitId"))
            Dim type As Int32? = Utils.ConvertToInt32(Request.QueryString("Type"))
            If theaterId = - 1 Then
                theaterId = Nothing
            End If
            If circuitId = - 1 Then
                circuitId = Nothing
            End If
            If type = - 1 Then
                type = Nothing
            End If

            Dim movieName As String = MovieAndTrailer.GetMovieDetail(movieId).Rows(0)("MovieName").ToString()
            Dim circuitName As String = Circuit.SelectData(circuitId.Value).Rows(0)("circuit_name").ToString()

            Dim dtb As DataTable = VpfManageMovieSet.SelectSummary(circuitId, theaterId, movieId, type, Nothing)

            'Dim movieName As String = "XXXXX"
            'Dim circuitName As String = "YYYYY"
            'Dim dtb As DataTable = VpfManageMovieSet.SelectSummary(1, Nothing, 958, Nothing, Nothing)
            If dtb Is Nothing OrElse dtb.Rows.Count = 0 Then
                Return
            End If
            Dim lblReportHeader As New Label
            lblReportHeader.Font.Bold = True
            lblReportHeader.Font.Size = 20
            lblReportHeader.ForeColor = ColorTranslator.FromHtml("#000066")
            lblReportHeader.Text = String.Format("VPF Report of ""{0}""", movieName)
            pnl.Controls.Add(lblReportHeader)
            Dim newline As New Label()
            newline.Text = "<br />"
            pnl.Controls.Add(newline)
            Dim lblReportCircuit As New Label
            lblReportCircuit.Font.Bold = True
            lblReportCircuit.Font.Size = 16
            lblReportCircuit.ForeColor = ColorTranslator.FromHtml("#000066")
            lblReportCircuit.Text = String.Format("Circuit : {0}", circuitName)
            pnl.Controls.Add(lblReportCircuit)

            Dim dict As New Dictionary(Of String, DataTable)
            Dim sumPrice As Decimal = 0
            Dim sumActual As Decimal = 0
            For Each dr As DataRow In dtb.Rows
                Dim result As Decimal
                Decimal.TryParse(dr("set_price").ToString(), result)
                sumPrice += result
                Decimal.TryParse(dr("actual_price").ToString(), result)
                sumActual += result

                Dim refDtb As DataTable
                Dim key As String = CStr(dr("theater_name"))
                If dict.ContainsKey(key) Then
                    refDtb = dict(key)
                Else
                    hdfCaption.Value += key + ","
                    refDtb = dtb.Clone()
                    dict(key) = refDtb
                End If
                refDtb.Rows.Add(dr.ItemArray)
            Next

            For Each keyValuePair As KeyValuePair(Of String, DataTable) In dict
                CreateResultTheater(pnl, keyValuePair.Value, Nothing)
            Next

            Dim grdData As GridView = CreateGridView(True)
            grdData.Columns.Add(CreateBoundField("film_type_sound_header_group", "Format", String.Empty, HorizontalAlign.Left, 50))
            grdData.Columns.Add(CreateBoundField("set_no", "Set No", String.Empty, HorizontalAlign.Center, 30))
            For Each c As DataColumn In dtb.Columns
                If c.ColumnName.Contains("-") Then
                    grdData.Columns.Add(CreateBoundField(c.ColumnName, c.ColumnName, String.Empty, HorizontalAlign.Center, 44))
                End If
            Next
            grdData.Columns.Add(CreateBoundField("set_price", "Accrual", "{0:#,##0}", HorizontalAlign.Right, 50))
            grdData.Columns.Add(CreateBoundField("actual_price", "Actual", "{0:#,##0}", HorizontalAlign.Right, 50))
            grdData.Columns.Add(CreateBoundField("user_remark", "Remark", String.Empty, HorizontalAlign.Left, 300))

            Dim sum As DataTable = dtb.Clone()
            Dim drSum As DataRow = sum.NewRow()
            drSum("set_price") = sumPrice
            drSum("actual_price") = sumActual
            sum.Rows.Add(drSum)
            grdData.DataSource = sum
            grdData.DataBind()

            grdData.Rows(0).Cells(grdData.Columns.Count - 4).Text = "Total"
            pnl.Controls.Add(grdData)
        End Sub

        Private Sub CreateResultTheater(ByVal pnl As Control, ByVal dtb As DataTable, ByVal selectSetNo As Int32?)
            Dim grdData As GridView = CreateGridView(False)
            If IsNothing(selectSetNo) Then
                grdData.ShowFooter = True
            Else
                dtb.Columns.Add("select").SetOrdinal(0)
                grdData.Columns.Add(CreateBoundField("select", String.Empty, String.Empty, HorizontalAlign.Left, 10))
            End If
            grdData.Columns.Add(CreateBoundField("film_type_sound_header_group", "Format", String.Empty, HorizontalAlign.Left, 50))
            grdData.Columns.Add(CreateBoundField("set_no", "Set No", String.Empty, HorizontalAlign.Center, 30))
            For Each c As DataColumn In dtb.Columns
                If c.ColumnName.Contains("-") Then
                    grdData.Columns.Add(CreateBoundField(c.ColumnName, c.ColumnName, String.Empty, HorizontalAlign.Center, 44))
                End If
            Next
            If IsNothing(selectSetNo) Then
                grdData.Columns.Add(CreateBoundField("set_price", "Accrual", "{0:#,##0}", HorizontalAlign.Right, 50))
                grdData.Columns.Add(CreateBoundField("actual_price", "Actual", "{0:#,##0}", HorizontalAlign.Right, 50))
                grdData.Columns.Add(CreateBoundField("user_remark", "Remark", String.Empty, HorizontalAlign.Left, 300))
            End If

            grdData.DataSource = dtb
            grdData.DataBind()

            If grdData.Rows.Count > 0 Then
                If IsNothing(selectSetNo) Then
                    Const startReColorIndex As Integer = 2
                    Dim endReColorIndex As Int32 = grdData.Columns.Count - 4

                    Dim priceColIndex As Int32 = grdData.Columns.Count - 3
                    Dim actualColIndex As Int32 = grdData.Columns.Count - 2

                    Dim sumPrice As Decimal = 0
                    Dim sumActual As Decimal = 0
                    For Each tr As TableRow In grdData.Rows
                        Dim result As Decimal
                        Decimal.TryParse(tr.Cells(priceColIndex).Text, result)
                        sumPrice = sumPrice + result
                        Decimal.TryParse(tr.Cells(actualColIndex).Text, result)
                        sumActual = sumActual + result

                        For i As Int32 = startReColorIndex To endReColorIndex
                            Dim tc As TableCell = tr.Cells(i)
                            tc.Text = tc.Text.Replace(" ", Environment.NewLine)
                            If tc.Text.Contains("/") Then
                                'If complete.Values(i) Then
                                '    tc.BackColor = Color.Green
                                'Else
                                '    tc.BackColor = Color.Red
                                'End If
                                If tc.Text.Contains("=") Then
                                    tc.BackColor = Color.Green
                                Else
                                    tc.BackColor = Color.Red
                                End If
                                tc.ForeColor = Color.White
                            Else
                                tc.BackColor = Color.White
                                tc.ForeColor = Color.Black
                            End If
                        Next
                    Next
                    grdData.FooterRow.Cells(priceColIndex).Text = String.Format("{0:#,##0}", sumPrice)
                    grdData.FooterRow.Cells(actualColIndex).Text = String.Format("{0:#,##0}", sumActual)
                Else
                    Const startReColorIndex As Integer = 3
                    Dim endReColorIndex As Int32 = grdData.Columns.Count - 1

                    For Each tr As TableRow In grdData.Rows
                        If tr.Cells(2).Text = selectSetNo.Value.ToString() Then
                            tr.Cells(0).Text = "->"
                        End If

                        For i As Int32 = startReColorIndex To endReColorIndex
                            Dim tc As TableCell = tr.Cells(i)
                            tc.Text = tc.Text.Replace(" ", "<br />")
                            If tc.Text.Contains("/") Then
                                'If complete.Values(i) Then
                                '    tc.BackColor = Color.Green
                                'Else
                                '    tc.BackColor = Color.Red
                                'End If
                                If tc.Text.Contains("=") Then
                                    tc.BackColor = Color.Green
                                Else
                                    tc.BackColor = Color.Red
                                End If
                                tc.ForeColor = Color.White
                            Else
                                tc.BackColor = Color.White
                                tc.ForeColor = Color.Black
                            End If
                        Next
                    Next
                End If
            End If

            pnl.Controls.Add(grdData)
        End Sub

#End Region
    End Class
End Namespace