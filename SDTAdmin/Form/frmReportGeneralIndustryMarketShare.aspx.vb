Option Strict On

Imports System.Text
Imports System.IO
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Form
    Partial Public Class FrmReportGeneralIndustryMarketShare
        Inherits Page

        Private ReadOnly _tableWidth As Unit = 888

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmReportGeneralIndustryMarketShareParam.aspx")
        End Sub

        Protected Sub BtnExportClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
            Dim groupBy As String = Page.Request.QueryString("groupby").ToLower()
            Dim exportFile As String = "market_share_by_" & groupBy & ".xls"
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
            frm.Controls.Add(tblHeader)
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
            CheckPermission(AdminPage.Menu_Report, True)
            CheckPermission(AdminPage.Report_GeneralIndustryMarketShare, True)

            CreateResult(pnlResult)
        End Sub

#End Region

#Region "Methods"

        Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        End Sub

        Private Shared Function CreateBoundField(ByVal dataField As String, ByVal headerText As String, ByVal dataFormatString As String, ByVal percentWidth As Unit, ByVal hAlign As HorizontalAlign) As BoundField
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
                    .Width = percentWidth
                    .HorizontalAlign = hAlign
                    .Font.Underline = False
                End With
            End With
            Return f
        End Function

        Private Shared Function CreateHyperLinkField(ByVal dataTextField As String, ByVal headerText As String, ByVal percentWidth As Unit, ByVal hAlign As HorizontalAlign, ByVal dataNavigateUrlFormatString As String, ByVal dataNavigateUrlFields As String()) As HyperLinkField
            Dim f As New HyperLinkField
            With f
                .DataNavigateUrlFields = dataNavigateUrlFields
                .DataNavigateUrlFormatString = dataNavigateUrlFormatString
                .DataTextField = dataTextField
                .HeaderText = headerText
                .SortExpression = dataTextField
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
                    .Width = percentWidth
                    .HorizontalAlign = hAlign
                    .Font.Underline = False
                    .ForeColor = Color.Blue
                    .Font.Bold = True
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
                .Width = _tableWidth
                If isSummary Then
                    .ShowHeader = False
                    .BackColor = ColorTranslator.FromHtml("#303D50")
                    .Font.Size = 10
                    .Font.Bold = True
                    .ForeColor = Color.White
                    .Height = 28
                    .HorizontalAlign = HorizontalAlign.Right
                Else
                    .ShowHeader = True
                    .BackColor = Color.White
                    .Font.Size = 10
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
                End If
            End With
            Return dgv
        End Function

        Private Function CreateTableCaption(ByVal grd As GridView, ByVal caption As String) As Table
            Dim t As New Table
            With t
                .CellPadding = 6
                .CellSpacing = 0
                .Height = 22
                .Width = _tableWidth
                .ForeColor = Color.Black

                .Font.Name = "Tahoma"
                .Font.Size = 10
                .Font.Bold = True

                .BackColor = ColorTranslator.FromHtml("#c3cad6")
            End With
            Dim tr As New TableRow
            Dim tc As New TableCell
            tc.ColumnSpan = grd.Columns.Count
            tr.Cells.Add(tc)

            tr.Cells(0).Text = caption
            tr.Cells(0).HorizontalAlign = HorizontalAlign.Left

            t.Rows.Add(tr)
            Return t
        End Function

        Private Function CreateTableEmptyRow(ByVal grd As GridView) As Table
            Dim t As New Table
            With t
                .CellPadding = 4
                .Height = 28
                .Width = _tableWidth
            End With
            Dim trDummy As New TableRow()
            Dim tcDummy As New TableCell
            tcDummy.ColumnSpan = grd.Columns.Count
            trDummy.Cells.Add(tcDummy)
            t.Rows.Add(trDummy)
            Return t
        End Function

        Private Function CreateTableFooter(ByVal grd As GridView, ByVal startCalColIndex As Int32, ByVal boxOfficeColIndex As Int32, ByVal admsColIndex As Int32, ByVal atpColIndex As Int32) As Table
            Dim t As New Table
            With t
                .BorderColor = Color.Black
                .BorderStyle = BorderStyle.Solid
                .BorderWidth = 1
                .CellPadding = 4
                .Font.Name = "Tahoma"
                .Font.Size = 10
                .Font.Bold = True
                .ForeColor = ColorTranslator.FromHtml("#003366")
                .GridLines = GridLines.Both
                .Height = 28
                .Width = _tableWidth
            End With
            If grd.Columns.Count > 1 Then
                Dim tr As New TableRow
                Dim arr(grd.Columns.Count - 1) As Decimal
                For i As Integer = 0 To grd.Rows.Count - 1
                    For j As Integer = startCalColIndex To grd.Columns.Count - 1
                        arr(j) = arr(j) + Decimal.Parse(grd.Rows(i).Cells(j).Text.Replace("%", String.Empty))
                    Next
                Next
                If arr(admsColIndex) = 0 Then
                    arr(atpColIndex) = 0
                Else
                    arr(atpColIndex) = arr(boxOfficeColIndex)/arr(admsColIndex)
                End If
                For i As Integer = 0 To grd.Columns.Count - 1
                    Dim tc As New TableCell
                    If i >= startCalColIndex Then
                        Dim bf As BoundField = CType(grd.Columns.Item(i), BoundField)
                        tc.Text = String.Format(bf.DataFormatString, arr(i))
                    End If

                    tc.Width = grd.Columns.Item(i).ItemStyle.Width
                    tc.HorizontalAlign = HorizontalAlign.Right
                    tr.Cells.Add(tc)
                Next
                tr.BackColor = ColorTranslator.FromHtml("#CADCEF")
                tr.Cells(startCalColIndex - 1).Text = "TOTAL"
                t.Rows.Add(tr)
            End If
            Return t
        End Function

        Private Sub CreateResult(ByVal pnl As Control)
            Dim groupBy As String = Page.Request.QueryString("groupby").ToLower()
            Dim dateType As String = Page.Request.QueryString("datetype").ToLower()
            Dim dateFromStr As String = Page.Request.QueryString("datefrom")
            Dim dateToStr As String = Page.Request.QueryString("dateto")

            'Response.Write(String.Format("{0}:{1}:{2}:{3}:{4}", dateType, dateFromStr, dateToStr, group, subGroup))

            Dim byMovieReleaseDate As Boolean = (dateType = "ReleaseDate".ToLower())
            Dim dateFrom As Date = dateFromStr.ToDateTime("yyyyMMdd")
            Dim dateTo As Date = dateToStr.ToDateTime("yyyyMMdd")
            Dim grdData As GridView = CreateGridView(False)
            Dim ds As DataSet
            Dim reportTitle As String = String.Empty

            Select Case groupBy
            Case "circuit"
                reportTitle = "INDUSTRY MARKET SHARE BY CIRCUIT"
                ds = ReportGeneralIndustryInfo.ReportGeneralIndustryInfoByCircuitTheater(dateFrom, dateTo, byMovieReleaseDate, True)

                grdData.Columns.Add(CreateBoundField("DisplayName", "CIRCUIT", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("PercentGroup", "% BANGKOK", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                Dim grdDataChiangMai As GridView = CreateGridView(False)
                grdDataChiangMai.Columns.Add(CreateBoundField("DisplayName", "CIRCUIT", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdDataChiangMai.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("PercentGroup", "% CHIANG MAI", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                Dim grdDataKeyCity As GridView = CreateGridView(False)
                grdDataKeyCity.Columns.Add(CreateBoundField("DisplayName", "CIRCUIT", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdDataKeyCity.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("13%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("13%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("13%"), HorizontalAlign.Right))

                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()
                grdDataChiangMai.DataSource = ds.Tables(1)
                grdDataChiangMai.DataBind()
                grdDataKeyCity.DataSource = ds.Tables(2)
                grdDataKeyCity.DataBind()

                pnl.Controls.Add(CreateTableCaption(grdData, "BANGKOK"))
                pnl.Controls.Add(grdData)
                pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                pnl.Controls.Add(CreateTableEmptyRow(grdData))

                pnl.Controls.Add(CreateTableCaption(grdDataChiangMai, "CHIANG MAI"))
                pnl.Controls.Add(grdDataChiangMai)
                pnl.Controls.Add(CreateTableFooter(grdDataChiangMai, 1, 1, 2, 4))
                pnl.Controls.Add(CreateTableEmptyRow(grdDataChiangMai))

                pnl.Controls.Add(CreateTableCaption(grdDataKeyCity, "KEY CITY"))
                pnl.Controls.Add(grdDataKeyCity)
                pnl.Controls.Add(CreateTableFooter(grdDataKeyCity, 1, 1, 2, 4))
            Case "theater"
                reportTitle = "INDUSTRY MARKET SHARE BY THEATER"
                ds = ReportGeneralIndustryInfo.ReportGeneralIndustryInfoByCircuitTheater(dateFrom, dateTo, byMovieReleaseDate, False)

                grdData.Columns.Add(CreateBoundField("DisplayName", "THEATER", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("PercentGroup", "% BANGKOK", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                Dim grdDataChiangMai As GridView = CreateGridView(False)
                grdDataChiangMai.Columns.Add(CreateBoundField("DisplayName", "THEATER", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdDataChiangMai.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("PercentGroup", "% CHIANG MAI", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                grdDataChiangMai.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                Dim grdDataKeyCity As GridView = CreateGridView(False)
                grdDataKeyCity.Columns.Add(CreateBoundField("DisplayName", "THEATER", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                grdDataKeyCity.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("13%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("13%"), HorizontalAlign.Right))
                grdDataKeyCity.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("13%"), HorizontalAlign.Right))

                grdData.DataSource = ds.Tables(0)
                grdData.DataBind()
                grdDataChiangMai.DataSource = ds.Tables(1)
                grdDataChiangMai.DataBind()
                grdDataKeyCity.DataSource = ds.Tables(2)
                grdDataKeyCity.DataBind()

                pnl.Controls.Add(CreateTableCaption(grdData, "BANGKOK"))
                pnl.Controls.Add(grdData)
                pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                pnl.Controls.Add(CreateTableEmptyRow(grdData))

                pnl.Controls.Add(CreateTableCaption(grdDataChiangMai, "CHIANG MAI"))
                pnl.Controls.Add(grdDataChiangMai)
                pnl.Controls.Add(CreateTableFooter(grdDataChiangMai, 1, 1, 2, 4))
                pnl.Controls.Add(CreateTableEmptyRow(grdDataChiangMai))

                pnl.Controls.Add(CreateTableCaption(grdDataKeyCity, "KEY CITY"))
                pnl.Controls.Add(grdDataKeyCity)
                pnl.Controls.Add(CreateTableFooter(grdDataKeyCity, 1, 1, 2, 4))
            Case "nationality"
                reportTitle = "INDUSTRY MARKET SHARE BY NATIONALITY"

                Dim nationality As String = Page.Request.QueryString("nationality")

                ds = ReportGeneralIndustryInfo.ReportGeneralIndustryInfoByNationalityDetail(dateFrom, dateTo, byMovieReleaseDate, nationality)

                If String.IsNullOrEmpty(nationality) Then
                    grdData.Columns.Add(CreateHyperLinkField("Nationality", "NATIONALITY", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&nationality={0}", New String() {"Nationality"}))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("13%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("13%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("13%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                Else
                    reportTitle &= " : " & nationality.ToUpper()

                    grdData.Columns.Add(CreateBoundField("ReleaseDate", "RELEASE DATE", "{0:dd-MMM-yyyy}", New Unit("10%"), HorizontalAlign.Left))
                    grdData.Columns.Add(CreateBoundField("Title", "TITLE", String.Empty, New Unit("30%"), HorizontalAlign.Left))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentNationality", "% NATIONALITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentIndustry", "% INDUSTRY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 2, 2, 3, 4))
                End If
            Case "distributor"
                reportTitle = "INDUSTRY MARKET SHARE BY DISTRIBUTOR"

                Dim distributor As String = Page.Request.QueryString("distributor")

                ds = ReportGeneralIndustryInfo.ReportGeneralIndustryInfoByDistributor(dateFrom, dateTo, byMovieReleaseDate, distributor)

                If String.IsNullOrEmpty(distributor) Then
                    grdData.Columns.Add(CreateHyperLinkField("DisplayName", "DISTRIBUTOR", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&distributor={0}", New String() {"DisplayName"}))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOthers As GridView = CreateGridView(False)
                    grdDataOthers.Columns.Add(CreateHyperLinkField("DisplayName", "DISTRIBUTOR", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&distributor={0}", New String() {"DisplayName"}))
                    grdDataOthers.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOverAll As GridView = CreateGridView(True)
                    grdDataOverAll.Columns.Add(CreateBoundField("DisplayName", String.Empty, String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdDataOverAll.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    grdDataOthers.DataSource = ds.Tables(1)
                    grdDataOthers.DataBind()

                    grdDataOverAll.DataSource = ds.Tables(2)
                    grdDataOverAll.DataBind()

                    pnl.Controls.Add(CreateTableCaption(grdData, "INTERNATIONAL"))
                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                    pnl.Controls.Add(CreateTableCaption(grdDataOthers, "THAI"))
                    pnl.Controls.Add(grdDataOthers)
                    pnl.Controls.Add(CreateTableFooter(grdDataOthers, 1, 1, 2, 4))
                    pnl.Controls.Add(grdDataOverAll)
                Else
                    reportTitle &= " : " & distributor.ToUpper()

                    grdData.Columns.Add(CreateBoundField("ReleaseDate", "RELEASE DATE", "{0:dd-MMM-yyyy}", New Unit("10%"), HorizontalAlign.Left))
                    grdData.Columns.Add(CreateBoundField("Title", "TITLE", String.Empty, New Unit("30%"), HorizontalAlign.Left))
                    grdData.Columns.Add(CreateBoundField("MaxScreen", "MAX SCREEN", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountWeek", "No. OF WEEKS", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 4, 4, 5, 6))
                End If
            Case "studio"
                reportTitle = "INDUSTRY MARKET SHARE BY STUDIO"

                Dim subGroup As String = Page.Request.QueryString("subGroup").ToLower()
                Dim studioName As String = Page.Request.QueryString("studioName")
                Dim circuitName As String = Page.Request.QueryString("circuitName")
                Dim isCircuit As Boolean = subGroup = "circuit"

                ds = ReportGeneralIndustryInfo.ReportGeneralIndustryInfoByStudioCircuitTheater(dateFrom, dateTo, byMovieReleaseDate, studioName, isCircuit, circuitName)

                If String.IsNullOrEmpty(studioName) Then
                    grdData.Columns.Add(CreateHyperLinkField("DisplayName", "STUDIO", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&subgroup=" & subGroup & "&studioName={0}", New String() {"DisplayName"}))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOthers As GridView = CreateGridView(False)
                    grdDataOthers.Columns.Add(CreateHyperLinkField("DisplayName", "STUDIO", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&subgroup=" & subGroup & "&studioName={0}", New String() {"DisplayName"}))
                    grdDataOthers.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOverAll As GridView = CreateGridView(True)
                    grdDataOverAll.Columns.Add(CreateBoundField("DisplayName", String.Empty, String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdDataOverAll.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    grdDataOthers.DataSource = ds.Tables(1)
                    grdDataOthers.DataBind()

                    grdDataOverAll.DataSource = ds.Tables(2)
                    grdDataOverAll.DataBind()

                    pnl.Controls.Add(CreateTableCaption(grdData, "INTERNATIONAL"))
                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                    pnl.Controls.Add(CreateTableCaption(grdDataOthers, "THAI"))
                    pnl.Controls.Add(grdDataOthers)
                    pnl.Controls.Add(CreateTableFooter(grdDataOthers, 1, 1, 2, 4))
                    pnl.Controls.Add(grdDataOverAll)
                ElseIf isCircuit Then
                    reportTitle &= " : " & studioName.ToUpper()

                    grdData.Columns.Add(CreateHyperLinkField("DisplayName", "CIRCUIT", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&subgroup=theater" & "&studioName=" & studioName & "&circuitName={0}", New String() {"DisplayName"}))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOthers As GridView = CreateGridView(False)
                    grdDataOthers.Columns.Add(CreateHyperLinkField("DisplayName", "CIRCUIT", New Unit("25%"), HorizontalAlign.Left, "frmReportGeneralIndustryMarketShare.aspx?groupby=" & groupBy & "&datetype=" & dateType & "&datefrom=" & dateFromStr & "&dateto=" & dateToStr & "&subgroup=theater" & "&studioName=" & studioName & "&circuitName={0}", New String() {"DisplayName"}))
                    grdDataOthers.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOverAll As GridView = CreateGridView(True)
                    grdDataOverAll.Columns.Add(CreateBoundField("DisplayName", String.Empty, String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdDataOverAll.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    grdDataOthers.DataSource = ds.Tables(1)
                    grdDataOthers.DataBind()

                    grdDataOverAll.DataSource = ds.Tables(2)
                    grdDataOverAll.DataBind()

                    pnl.Controls.Add(CreateTableCaption(grdData, "BANGKOK"))
                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                    pnl.Controls.Add(CreateTableCaption(grdDataOthers, "CHIANG MAI"))
                    pnl.Controls.Add(grdDataOthers)
                    pnl.Controls.Add(CreateTableFooter(grdDataOthers, 1, 1, 2, 4))
                    pnl.Controls.Add(grdDataOverAll)
                Else
                    reportTitle &= " : " & studioName.ToUpper() & DirectCast(IIf(String.IsNullOrEmpty(circuitName), String.Empty, String.Format(" ({0})", circuitName)), String)

                    grdData.Columns.Add(CreateBoundField("DisplayName", "THEATER", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdData.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdData.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOthers As GridView = CreateGridView(False)
                    grdDataOthers.Columns.Add(CreateBoundField("DisplayName", "THEATER", String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdDataOthers.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOthers.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    Dim grdDataOverAll As GridView = CreateGridView(True)
                    grdDataOverAll.Columns.Add(CreateBoundField("DisplayName", String.Empty, String.Empty, New Unit("25%"), HorizontalAlign.Left))
                    grdDataOverAll.Columns.Add(CreateBoundField("BoxOffice", "BOX OFFICE", "{0:#,##0}", New Unit("20%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ADMS", "ADMS", "{0:#,##0}", New Unit("15%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("CountMovie", "NO. OF TITLES", "{0:#,##0}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("ATP", "ATP", "{0:#,##0.00}", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentGroup", "% GROUP", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))
                    grdDataOverAll.Columns.Add(CreateBoundField("PercentKeyCity", "% KEY CITY", "{0:#,##0.00} %", New Unit("10%"), HorizontalAlign.Right))

                    grdData.DataSource = ds.Tables(0)
                    grdData.DataBind()

                    grdDataOthers.DataSource = ds.Tables(1)
                    grdDataOthers.DataBind()

                    grdDataOverAll.DataSource = ds.Tables(2)
                    grdDataOverAll.DataBind()

                    pnl.Controls.Add(CreateTableCaption(grdData, "BANGKOK"))
                    pnl.Controls.Add(grdData)
                    pnl.Controls.Add(CreateTableFooter(grdData, 1, 1, 2, 4))
                    pnl.Controls.Add(CreateTableCaption(grdDataOthers, "CHIANG MAI"))
                    pnl.Controls.Add(grdDataOthers)
                    pnl.Controls.Add(CreateTableFooter(grdDataOthers, 1, 1, 2, 4))
                    pnl.Controls.Add(grdDataOverAll)
                End If
            End Select
            tcHeader1.ColumnSpan = grdData.Columns.Count
            tcHeader2.ColumnSpan = grdData.Columns.Count
            tcHeader1.Text = reportTitle
            tcHeader2.Text = String.Format("{0} From : {1} To {2}", IIf(byMovieReleaseDate, "Movie Release Date", "Box Office in Date"), Format(dateFrom, "ddd dd-MMM-yyyy"), Format(dateTo, "ddd dd-MMM-yyyy"))
        End Sub

#End Region
    End Class
End Namespace