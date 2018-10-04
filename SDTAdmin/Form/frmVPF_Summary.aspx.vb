Option Strict On

Imports System.Collections.Generic
Imports GridViewUtils
Imports SDTCommon.Extensions
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmVpfSummary
        Inherits Page

#Region "Properties"

        Public Property GridViewSortDirection() As SortDirection
            Get
                If IsNothing(ViewState(ClientID + "sortDirection")) Then
                    ViewState(ClientID + "sortDirection") = SortDirection.Ascending
                End If
                Return CType(ViewState(ClientID + "sortDirection"), SortDirection)
            End Get
            Set(ByVal value As SortDirection)
                ViewState(ClientID + "sortDirection") = value
            End Set
        End Property

#End Region

#Region "Event Handlers"

        Protected Sub BtnActionDeleteClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnActionDelete.Click
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim key As String = CType(grdResult.DataKeys(gridViewRow.RowIndex).Value, String)
                    DeleteKey(key)
                End If
            Next
            ShowData()
        End Sub

        Protected Sub BtnCancelAddClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelAdd.Click
            pnlActionAdd.Visible = False
        End Sub

        Protected Sub BtnCancelMovieClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelMovie.Click
            moviePopup.Enabled = True
            moviePopup.MovieId = 0
            pnlDataPanel.Visible = False
            btnSearch.Visible = True
            btnCancelMovie.Visible = False
        End Sub

        Protected Sub BtnClearClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnClear.Click
            Dim userId As String = CStr(Session("UserID"))
            VpfManageMovieSet.UpdatePayment(CInt(hdfTheaterId.Value), moviePopup.MovieId, CInt(hdfFilmTypeSoundId.Value), CInt(lblSetNo.Text), Nothing, Nothing, userId)

            pnlActionAdd.Visible = False
            ShowData()
            ClearForm()
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnExportExcelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnExportExcel.Click
            Response.Redirect(String.Format("frmReportVirtualPrintFee.aspx?MovieId={0}&CircuitId={1}&TheaterId={2}&Type={3}", moviePopup.MovieId, CInt(ddlCircuit.SelectedItem.Value), CInt(ddlTheater.SelectedItem.Value), CInt(ddlType.SelectedItem.Value)))
        End Sub

        Protected Sub BtnUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnUpdate.Click
            InsertUpdate()
        End Sub

        Protected Sub BtnSearchClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnSearch.Click
            pnlDataPanel.Visible = (Not IsNothing(moviePopup.MovieId) AndAlso Not moviePopup.MovieId = 0)
            moviePopup.Enabled = Not pnlDataPanel.Visible
            btnSearch.Visible = Not pnlDataPanel.Visible
            btnCancelMovie.Visible = pnlDataPanel.Visible
            If pnlDataPanel.Visible Then
                ShowData()
            End If
            ClearForm()
        End Sub

        Protected Sub BtnSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
            CheckBoxAllGrid(True)
        End Sub

        Protected Sub BtnSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectNone.Click
            CheckBoxAllGrid(False)
        End Sub

        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCircuit.SelectedIndexChanged
            pnlActionAdd.Visible = False
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True), True)
        End Sub

        Protected Sub DdlTheaterSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTheater.SelectedIndexChanged
            pnlActionAdd.Visible = False
            RefreshAfterChangeTheater()
        End Sub

        Protected Sub DdlTypeSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlType.SelectedIndexChanged
            pnlActionAdd.Visible = False
            ShowData()
        End Sub

        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            Dim keyString As String = e.CommandArgument.ToString()
            If e.CommandName = "Delete" Then
                DeleteKey(keyString)
                ShowData()
            ElseIf e.CommandName = "Edit" Then
                Dim strArr() As String = keyString.Split(","(0))
                Dim circuitId As Int32 = CInt(strArr(0))
                Dim theaterId As Int32 = CInt(strArr(1))
                Dim movieId As Int32 = CInt(strArr(2))
                Dim filmTypeSoundId As Int32 = CInt(strArr(3))
                Dim setNo As Int32 = CInt(strArr(4))
                Dim dtb As DataTable = VpfManageMovieSet.SelectSummary(circuitId, theaterId, movieId, filmTypeSoundId, setNo)
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr As DataRow = dtb.Rows(0)

                    hdfTheaterId.Value = dr("theater_id").ToString()
                    hdfFilmTypeSoundId.Value = dr("film_type_sound_id").ToString()

                    lblTheaterName.Text = dr("theater_name").ToString()
                    lblFormat.Text = dr("film_type_sound_header_group").ToString()
                    lblSetNo.Text = dr("set_no").ToString()
                    Dim startDate As Date = CType(dr("vpf_start_date"), Date)
                    Dim endDate As Date = startDate.AddDays(CInt(dr("set_days")) - 1)
                    lblSetPeriod.Text = startDate.ToShortDateString() + " To " + endDate.ToShortDateString()
                    lblSetSessions.Text = dr("set_sessions").ToString()
                    lblSetPrice.Text = String.Format("{0:#,###}", dr("set_price"))

                    hdfCaption.Value = lblTheaterName.Text + ","
                    Dim dtbSum As DataTable = VpfManageMovieSet.SelectSummary(circuitId, theaterId, movieId, filmTypeSoundId, Nothing)
                    CreateResultTheater(pnlCalendar, dtbSum, setNo)

                    Dim dtbProblem As DataTable = ProblemRecord.SelectData(Nothing, theaterId, movieId, circuitId, startDate, endDate)
                    grdProblem.DataSource = dtbProblem
                    grdProblem.DataBind()

                    txtUserPrice.Text = dr("actual_price").ToString()
                    txtRemark.Text = dr("user_remark").ToString()

                    btnClear.Visible = Not CBool(dr("complete"))
                    pnlActionAdd.Visible = True
                End If
            End If
        End Sub

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim complete As Boolean = CType(DataBinder.Eval(e.Row.DataItem, "complete"), Boolean)

            Dim price As Object
            If complete Then
                price = DataBinder.Eval(e.Row.DataItem, "set_price")
            Else
                price = DataBinder.Eval(e.Row.DataItem, "actual_price")
            End If
            Dim ctl As Object = e.Row.Cells(1).FindControl("btnPaid")

            If Not IsNothing(ctl) AndAlso Not String.IsNullOrEmpty(price.ToString()) Then
                Dim btn As LinkButton = CType(ctl, LinkButton)
                btn.Text = String.Format("{0:#,##0}", price)
                btn.Font.Bold = True
                btn.ForeColor = Color.Green
            End If
        End Sub

        Protected Sub GrdResultRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles grdResult.RowDeleting
            'Do nothing
        End Sub

        Protected Sub GrdResultRowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles grdResult.RowEditing
            'Do nothing
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Menu_Vpf_Summary, True)

            btnActionDelete.OnClientClick = "return ManipulateGrid()"

            moviePopup.MovieType = "1"
            moviePopup.VisibleMovieType = False
            moviePopup.BindData()

            Dim dtbCircuitTheater As DataTable = Theater.SelectData(Nothing, Nothing, True)

            Dim viewCircuit As New DataView(dtbCircuitTheater)
            Dim dtbCircuit As DataTable = viewCircuit.ToTable(True, "circuit_id", "circuit_name")
            ddlCircuit.DataSource = dtbCircuit
            ddlCircuit.DataTextField = "circuit_name"
            ddlCircuit.DataValueField = "circuit_id"
            ddlCircuit.DataBind()

            Dim dtbTheater As DataTable = dtbCircuitTheater.Clone
            Dim drArray() As DataRow = dtbCircuitTheater.Select("circuit_id = " & CInt(dtbCircuit.Rows(0)("circuit_id")))
            For Each dr As DataRow In drArray
                dtbTheater.ImportRow(dr)
            Next

            RefreshTheater(dtbTheater, True)
        End Sub

#End Region

#Region "Methods"

        Private Shared Sub DeleteKey(ByVal keyString As String)
            Dim strArr() As String = keyString.Split(","(0))
            'VpfManageMovieSet.Delete(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)), CInt(strArr(3)))
        End Sub

        Private Sub CheckBoxAllGrid(ByVal checkAll As Boolean)
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If Not IsNothing(chk) Then
                    chk.Checked = checkAll
                End If
            Next
        End Sub

        Private Sub ClearForm()
            lblError.Visible = False
            txtRemark.Text = String.Empty
            txtUserPrice.Text = String.Empty
        End Sub

        Private Sub InsertUpdate()
            lblError.Text = String.Empty

            Dim userPrice As Int32 = txtUserPrice.GetInt32()

            Dim userId As String = CStr(Session("UserID"))
            VpfManageMovieSet.UpdatePayment(CInt(hdfTheaterId.Value), moviePopup.MovieId, CInt(hdfFilmTypeSoundId.Value), CInt(lblSetNo.Text), userPrice, txtRemark.Text, userId)

            pnlActionAdd.Visible = False
            ShowData()
            ClearForm()
        End Sub

        Private Sub ShowData()
            If Not pnlDataPanel.Visible Then
                Return
            End If
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)

            Dim theaterId As Int32? = Nothing
            If Not ddlTheater.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(ddlTheater.SelectedItem.ToString()) Then
                theaterId = CInt(ddlTheater.SelectedItem.Value)
                If theaterId = -1 Then
                    theaterId = Nothing
                End If
            End If

            Dim typeId As Int32? = Nothing
            If Not ddlType.SelectedItem Is Nothing AndAlso Not String.IsNullOrEmpty(ddlType.SelectedItem.ToString()) Then
                typeId = CInt(ddlType.SelectedItem.Value)
                If typeId = -1 Then
                    typeId = Nothing
                End If
            End If

            'Dim dtb As DataTable = VpfManageMovieSet.SelectData(circuitId, theaterId, moviePopup.MovieId, typeId, Nothing)

            'If typeId Is Nothing Then
            '    Dim viewType As New DataView(dtb)
            '    Dim dtbType As DataTable = viewType.ToTable(True, "film_type_sound_id", "film_type_sound_header_group")
            '    ddlType.DataSource = dtbType
            '    ddlType.DataTextField = "film_type_sound_header_group"
            '    ddlType.DataValueField = "film_type_sound_id"

            '    Dim firstRow As DataRow = dtbType.NewRow()
            '    firstRow("film_type_sound_header_group") = "All"
            '    firstRow("film_type_sound_id") = - 1
            '    dtbType.Rows.InsertAt(firstRow, 0)
            '    ddlType.DataBind()
            'End If

            'Dim dtbSum As DataTable = VpfManageMovieSet.SelectSummary(circuitId, theaterId, moviePopup.MovieId, typeId, Nothing)

            'lblNotFound.Visible = (IsNothing(dtb) OrElse dtb.Rows.Count = 0)

            'Dim sumPrice As Decimal = 0
            'Dim sumActual As Decimal = 0
            'If Not lblNotFound.Visible Then
            '    dtb.Columns.Add("complete", GetType(Boolean))
            '    If Not IsNothing(dtbSum) AndAlso dtbSum.Rows.Count > 0 Then
            '        For Each dr As DataRow In dtbSum.Rows
            '            For Each dr2 As DataRow In dtb.Rows
            '                If dr("theater_id").ToString() = dr2("theater_id").ToString() AndAlso dr("film_type_sound_id").ToString() = dr2("film_type_sound_id").ToString() AndAlso dr("set_no").ToString() = dr2("set_no").ToString() Then
            '                    dr2("complete") = dr("complete")
            '                End If
            '            Next
            '        Next
            '    End If
            '    dtb.Columns.Add("key_string", GetType(String))
            '    For Each dr As DataRow In dtb.Rows
            '        dr("key_string") = circuitId.ToString() + "," + dr("theater_id").ToString() + "," + moviePopup.MovieId.ToString() + "," + dr("film_type_sound_id").ToString() + "," + dr("set_no").ToString()
            '        Dim result As Decimal
            '        Decimal.TryParse(dr("set_price").ToString(), result)
            '        sumPrice = sumPrice + result
            '        If CBool(dr("complete")) Then
            '            Decimal.TryParse(dr("set_price").ToString(), result)
            '        Else
            '            Decimal.TryParse(dr("actual_price").ToString(), result)
            '        End If
            '        sumActual = sumActual + result
            '    Next
            'End If

            Dim dtb As DataTable = VpfManageMovieSet.SelectSummary(circuitId, theaterId, moviePopup.MovieId, typeId, Nothing)
            If typeId Is Nothing Then
                Dim viewType As New DataView(dtb)
                Dim dtbType As DataTable = viewType.ToTable(True, "film_type_sound_id", "film_type_sound_header_group")
                ddlType.DataSource = dtbType
                ddlType.DataTextField = "film_type_sound_header_group"
                ddlType.DataValueField = "film_type_sound_id"

                Dim firstRow As DataRow = dtbType.NewRow()
                firstRow("film_type_sound_header_group") = "All"
                firstRow("film_type_sound_id") = -1
                dtbType.Rows.InsertAt(firstRow, 0)
                ddlType.DataBind()
            End If

            lblNotFound.Visible = (IsNothing(dtb) OrElse dtb.Rows.Count = 0)
            btnExportExcel.Visible = Not lblNotFound.Visible

            Dim sumPrice As Decimal = 0
            Dim sumActual As Decimal = 0
            If Not lblNotFound.Visible Then
                dtb.Columns.Add("key_string", GetType(String))
                For Each dr As DataRow In dtb.Rows
                    dr("key_string") = circuitId.ToString() + "," + dr("theater_id").ToString() + "," + moviePopup.MovieId.ToString() + "," + dr("film_type_sound_id").ToString() + "," + dr("set_no").ToString()
                    Dim result As Decimal
                    Decimal.TryParse(dr("set_price").ToString(), result)
                    sumPrice = sumPrice + result
                    Decimal.TryParse(dr("actual_price").ToString(), result)
                    sumActual = sumActual + result
                Next
            End If

            'Fill Summary
            grdResult.DataSource = dtb
            grdResult.DataBind()
            If (Not dtb Is Nothing AndAlso dtb.Rows.Count > 0) Then
                grdResult.FooterRow.Cells(7).Text = String.Format("{0:#,##0}", sumPrice)
                grdResult.FooterRow.Cells(8).Text = String.Format("{0:#,##0}", sumActual)
            End If
        End Sub

        Private Sub RefreshTheater(ByVal dtb As DataTable, ByVal fillGrid As Boolean)
            Dim firstRow As DataRow = dtb.NewRow()
            firstRow("theater_name") = "All"
            firstRow("theater_id") = -1
            dtb.Rows.InsertAt(firstRow, 0)

            ddlTheater.DataSource = dtb
            ddlTheater.DataTextField = "theater_name"
            ddlTheater.DataValueField = "theater_id"
            ddlTheater.DataBind()

            If fillGrid Then
                RefreshAfterChangeTheater()
            End If
        End Sub

        Private Sub RefreshAfterChangeTheater()
            ddlType.Items.Clear()
            ShowData()
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
                For j As Int32 = otherHeaderRow.Count - 1 To 1 Step -1
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
                Dim headerRow As List(Of DynamicHeaderCell) = CType(headers(i), List(Of DynamicHeaderCell))
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