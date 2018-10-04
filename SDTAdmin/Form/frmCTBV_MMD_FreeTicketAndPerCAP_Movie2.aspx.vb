Option Strict On

Imports System.Collections.Generic
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmCtbvMmdFreeTicketAndPerCapMovie2
        Inherits Page

        Private _dict As Dictionary(Of String, GridView)
        Public Const GroupBy As String = "ticket_cap_name"

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

        Protected Sub BtnActionDeleteClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) _
            Handles btnActionDelete.Click
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim key As String = CType(grdResult.DataKeys(gridViewRow.RowIndex).Value, String)
                    DeleteKey(key)
                End If
            Next
            ShowData()
        End Sub

        Protected Sub BtnCancelMovieClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) _
            Handles btnCancelMovie.Click
            moviePopup.Enabled = True
            moviePopup.MovieId = 0
            pnlDataPanel.Visible = False
            btnSearch.Visible = True
            btnCancelMovie.Visible = False
        End Sub

        Protected Sub BtnUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnUpdate.Click
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If chk IsNot Nothing AndAlso chk.Checked Then
                    Dim key As String = CType(grdResult.DataKeys(gridViewRow.RowIndex).Value, String)
                    Dim strArr() As String = key.Split(","(0))
                    FreeTicketAndPerCapByMovie.UpdateInsert(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)), _
                                                            dpkUpdateAvailableTo.SelectedDate, CStr(Session("UserID")))
                End If
            Next
            ShowData()
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            DBInterface.User.Logout()
        End Sub

        Protected Sub BtnInsertUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) _
            Handles btnInsertUpdate.Click
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
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If Not IsNothing(chk) Then
                    chk.Checked = True
                End If
            Next
        End Sub

        Protected Sub BtnSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectNone.Click
            For Each gridViewRow As GridViewRow In grdResult.Rows
                Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                If Not IsNothing(chk) Then
                    chk.Checked = False
                End If
            Next
        End Sub

        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ddlCircuit.SelectedIndexChanged
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True))
        End Sub

        Protected Sub DdlTheaterSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ddlTheater.SelectedIndexChanged
            RefreshFreeTicketCap()
        End Sub

        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) _
            Handles grdResult.RowCommand
            If e.CommandName = "Delete" Then
                DeleteKey(e.CommandArgument.ToString())
                ShowData()
            End If
        End Sub

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) _
            Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim ctl As Object = e.Row.Cells(1).FindControl("btnDelete")
            If Not IsNothing(ctl) Then
                Dim btn As LinkButton = CType(ctl, LinkButton)

                btn.OnClientClick = "return confirm('Confirm to delete ?')"

                'Dim collectionNo As String = CStr(DataBinder.Eval(e.Row.DataItem, "collection_no"))
                'If Not IsNothing(collectionNo) AndAlso Not String.IsNullOrEmpty(collectionNo.ToString()) Then
                '    Dim dtb As DataTable = GetTrailerMaster(Nothing, Nothing, Nothing, Nothing, Nothing, collectionNo.ToString(), Nothing)
                '    If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                '        btn.OnClientClick = "alert('ไม่สามารถลบข้อมูลได้\nเนื่องจากข้อมูลมีการถูกเรียกใช้งาน');return false;"
                '    Else
                '        btn.OnClientClick = "return confirm('ยืนยันการลบข้อมูล?')"
                '    End If
                'End If
            End If
        End Sub

        Protected Sub GrdResultAllRowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultAll.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim tbl As Table = DirectCast(e.Row.Parent, Table)
            Dim tr As New GridViewRow(e.Row.RowIndex + 1, -1, DataControlRowType.EmptyDataRow, DataControlRowState.Normal)
            tr.CssClass = "hidden"
            Dim tc As New TableCell()
            tc.ColumnSpan = grdResultAll.Columns.Count
            tc.BorderStyle = BorderStyle.None
            tc.BackColor = Color.AliceBlue
            Dim gv As GridView = _dict(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "group_name")))
            tc.Controls.Add(gv)

            tr.Cells.Add(tc)
            tbl.Rows.Add(tr)

            Dim btnExpend As New WebControls.Image
            btnExpend.ID = "btnDetail"
            btnExpend.ImageUrl = "~/Images/detail.gif"
            btnExpend.Attributes.Add("onclick", "javascript: gvrowtoggle(" & e.Row.RowIndex + (e.Row.RowIndex + 2) & ")") 'Adds the javascript 
            e.Row.Cells(0).Controls.Add(btnExpend)
            gv.DataBind()
        End Sub

        Protected Sub GrdResultRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) _
            Handles grdResult.RowDeleting
            'Do nothing
        End Sub

        Protected Sub GrdResultRowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) _
            Handles grdResult.RowEditing
            'Do nothing
        End Sub

        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) _
            Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            Dim dtb As DataTable
            If theaterId = -1 Then
                dtb = FreeTicketAndPerCapByMovie.SelectData(moviePopup.MovieId, Nothing, Nothing, circuitId, Nothing)
            Else
                dtb = FreeTicketAndPerCapByMovie.SelectData(moviePopup.MovieId, Nothing, theaterId, Nothing, Nothing)
            End If
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Ticket_FreeTicketAndPerCapByMovie, True)
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

            RefreshTheater(dtbTheater)
        End Sub

#End Region

#Region "Methods"

        Private Shared Sub DeleteKey(ByVal keyString As String)
            Dim strArr() As String = keyString.Split(","(0))
            FreeTicketAndPerCapByMovie.Delete(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)))
        End Sub

        Private Sub ClearForm()
            lblError.Visible = False

            For Each item As RepeaterItem In rptList.Items
                CType(item.FindControl("chkName"), CheckBox).Checked = False
            Next
            dpkAddAvailableTo.SelectedDate = Nothing
        End Sub

        Private Sub InsertUpdate()
            Dim countError As Int32 = 0

            lblError.Text = String.Empty

            'If IsNothing(dpkAvailableTo.SelectedDate) Then
            '    lblError.Text += vbNewLine + "Please input avaliable to date !"
            '    lblError.Visible = True
            '    countError += 1
            'End If

            Dim ticketList As New List(Of Integer)
            For Each item As RepeaterItem In rptList.Items
                Dim chk As CheckBox = CType(item.FindControl("chkName"), CheckBox)
                If chk.Checked Then
                    ticketList.Add(CType(CType(item.FindControl("hdfId"), HiddenField).Value, Integer))
                End If
            Next

            If ticketList.Count() = 0 Then
                lblError.Text += vbNewLine + "Please select any free ticket/per CAP !"
                lblError.Visible = True
                countError += 1
            End If

            If countError > 0 Then
                Return
            End If

            Dim userId As String = CStr(Session("UserID"))
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            If theaterId = -1 Then
                For Each ticketId As Int32 In ticketList
                    For i As Int32 = 1 To ddlTheater.Items.Count - 1
                        Dim item As ListItem = ddlTheater.Items(i)
                        FreeTicketAndPerCapByMovie.UpdateInsert(moviePopup.MovieId, ticketId, CInt(item.Value), _
                                                                dpkAddAvailableTo.SelectedDate, userId)
                    Next
                Next
            Else
                For Each ticketId As Int32 In ticketList
                    FreeTicketAndPerCapByMovie.UpdateInsert(moviePopup.MovieId, ticketId, theaterId, _
                                                            dpkAddAvailableTo.SelectedDate, userId)
                Next
            End If

            ShowData()
        End Sub

        Private Sub ShowData()
            If Not pnlDataPanel.Visible Then
                Return
            End If
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            Dim dtb As DataTable
            If theaterId = -1 Then
                grdResultAll.Visible = True
                dtb = FreeTicketAndPerCapByMovie.SelectData(moviePopup.MovieId, Nothing, Nothing, circuitId, Nothing)
                dtb = GetDistinctName(dtb, True)
                grdResultAll.DataSource = dtb
                grdResultAll.DataBind()
            Else
                grdResultAll.Visible = False
                dtb = FreeTicketAndPerCapByMovie.SelectData(moviePopup.MovieId, Nothing, theaterId, Nothing, Nothing)
                grdResult.DataSource = dtb
                grdResult.DataBind()
            End If
            grdResult.Visible = Not grdResultAll.Visible
            pnlActionAll.Visible = Not grdResultAll.Visible AndAlso Not (IsNothing(dtb) OrElse dtb.Rows.Count = 0)
            pnlToolBar.Visible = pnlActionAll.Visible
        End Sub

        Private Sub RefreshTheater(ByVal dtb As DataTable)
            Dim firstRow As DataRow = dtb.NewRow()
            firstRow("theater_name") = "All"
            firstRow("theater_id") = -1
            dtb.Rows.InsertAt(firstRow, 0)

            ddlTheater.DataSource = dtb
            ddlTheater.DataTextField = "theater_name"
            ddlTheater.DataValueField = "theater_id"
            ddlTheater.DataBind()

            RefreshFreeTicketCap()
        End Sub

        Private Sub RefreshFreeTicketCap()
            Dim dtb As DataTable
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            If theaterId = -1 Then
                dtb = FreeTicketAndPerCap.SelectData(Nothing, Nothing, circuitId, Nothing, True, True)
            Else
                dtb = FreeTicketAndPerCap.SelectData(Nothing, Nothing, circuitId, theaterId, True, False)
            End If

            lblNotFound.Visible = False
            pnlActionAdd.Visible = False
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                pnlActionAdd.Visible = True
                dtb.Columns.Add("sep", GetType(String))
                For i As Integer = 0 To dtb.Rows.Count - 1
                    dtb.Rows(i)("sep") = IIf((i + 1) Mod 3 = 0, "</tr><tr>", String.Empty)
                Next
            Else
                lblNotFound.Visible = True
            End If

            rptList.DataSource = dtb
            rptList.DataBind()

            ShowData()
        End Sub

        Private Function GetDistinctName(ByVal dtb As DataTable, ByVal updateDetail As Boolean) As DataTable
            Dim dtnDistinctName As DataTable
            If updateDetail Then
                Dim dictDtb As New Dictionary(Of String, DataTable)()
                For i As Int32 = 0 To dtb.Rows.Count - 1
                    Dim dr As DataRow = dtb.Rows(i)
                    Dim ticketTypeName As String = CStr(dr(GroupBy))
                    Dim refDtb As DataTable
                    If dictDtb.ContainsKey(ticketTypeName) Then
                        refDtb = dictDtb(ticketTypeName)
                        refDtb.ImportRow(dr)
                    Else
                        refDtb = dtb.Clone()
                        refDtb.ImportRow(dr)
                        dictDtb.Add(ticketTypeName, refDtb)
                    End If
                Next

                _dict = New Dictionary(Of String, GridView)()
                dtnDistinctName = New DataTable
                dtnDistinctName.Columns.Add("group_name", Type.GetType("System.String"))
                For Each str As String In dictDtb.Keys
                    Dim gv As New GridView
                    gv.ID = "grdDetail_" & str
                    gv.AllowSorting = False
                    gv.AutoGenerateColumns = False
                    gv.CellPadding = 4
                    gv.DataKeyNames = New String() {"key_string"}
                    gv.DataSource = dictDtb(str)
                    gv.Font.Name = "Tahoma"
                    gv.Font.Size = 10
                    gv.ForeColor = ColorTranslator.FromHtml("#333333")
                    gv.PagerStyle.BackColor = ColorTranslator.FromHtml("#284775")
                    gv.PagerStyle.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
                    gv.PagerStyle.HorizontalAlign = HorizontalAlign.Center
                    gv.AlternatingRowStyle.BackColor = ColorTranslator.FromHtml("#FFFFFF")
                    gv.AlternatingRowStyle.ForeColor = ColorTranslator.FromHtml("#284775")

                    gv.CssClass = "subgridview"

                    'AddHandler gv.RowDataBound, AddressOf grdOverLimitDetails_RowDataBound 'Add a 

                    Dim colSelect As New TemplateField
                    colSelect.ShowHeader = False
                    colSelect.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    colSelect.ItemStyle.Width = 20
                    colSelect.ItemTemplate = New CheckBoxTemplate()
                    gv.Columns.Add(colSelect)

                    Dim colActive As New CheckBoxField
                    colActive.DataField = "active_flag"
                    colActive.HeaderText = "Active"
                    colActive.SortExpression = colActive.DataField
                    gv.Columns.Add(colActive)

                    Dim colName As New BoundField
                    colName.DataField = "theater_name"
                    colName.HeaderText = "Theater Name"
                    colName.SortExpression = colName.DataField
                    gv.Columns.Add(colName)

                    Dim colAvailableTo As New BoundField
                    colAvailableTo.DataField = "available_to"
                    colAvailableTo.DataFormatString = "{0:dd/MM/yyyy}"
                    colAvailableTo.HeaderText = "Period to apply Per Cap"
                    colAvailableTo.SortExpression = colAvailableTo.DataField
                    gv.Columns.Add(colAvailableTo)

                    Dim colUpdateDate As New BoundField
                    colUpdateDate.DataField = "update_date"
                    colUpdateDate.HeaderText = "Last Update Date"
                    colUpdateDate.SortExpression = colUpdateDate.DataField
                    gv.Columns.Add(colUpdateDate)

                    Dim colUpdateName As New BoundField
                    colUpdateName.DataField = "update_name"
                    colUpdateName.HeaderText = "Last Update By"
                    colUpdateName.SortExpression = colUpdateName.DataField
                    gv.Columns.Add(colUpdateName)

                    Dim colDelete As New TemplateField
                    colDelete.ShowHeader = False
                    colDelete.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    colDelete.ItemStyle.Width = 20
                    colDelete.ItemTemplate = New DeleteButtonTemplate()
                    gv.Columns.Add(colDelete)

                    _dict.Add(str, gv)

                    Dim dr As DataRow = dtnDistinctName.NewRow()
                    dr("group_name") = str
                    dtnDistinctName.Rows.Add(dr)
                Next
                Return dtnDistinctName
            Else
                Dim view As New DataView(dtb)
                dtnDistinctName = view.ToTable(True, GroupBy)
            End If
            Return dtnDistinctName
        End Function
#End Region

        Public Class CheckBoxTemplate
            Implements ITemplate

            Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
                Dim chk As New CheckBox
                chk.ID = "chkSelect"
                container.Controls.Add(chk)
            End Sub

        End Class

        Public Class DeleteButtonTemplate
            Implements ITemplate


            Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
                Dim link As New LinkButton
                link.CausesValidation = False
                link.CommandName = "Delete"
                link.ForeColor = ColorTranslator.FromHtml("#FF6600")
                link.Text = "Delete"
                container.Controls.Add(link)
            End Sub

        End Class

    End Class
End Namespace