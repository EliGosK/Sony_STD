Option Strict On

Imports System.Collections.Generic
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmCtbvMmdTicketTypeMovie
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

        Protected Sub BtnCancelMovieClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelMovie.Click
            moviePopup.Enabled = True
            moviePopup.MovieId = 0
            pnlDataPanel.Visible = False
            btnSearch.Visible = True
            btnCancelMovie.Visible = False
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnInsertUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnInsertUpdate.Click
            InsertUpdate()
            ClearForm()
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

        Protected Sub BtnTypeSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypeSelectAll.Click
            CheckType(True)
        End Sub

        Protected Sub BtnTypeSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypeSelectNone.Click
            CheckType(False)
        End Sub

        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCircuit.SelectedIndexChanged
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True))
        End Sub

        Protected Sub DdlTheaterSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTheater.SelectedIndexChanged
            RefreshTicketType()
        End Sub

        Protected Sub DdlTypeSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlType.SelectedIndexChanged
            ShowData()
        End Sub

        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            If e.CommandName = "Delete" Then
                DeleteKey(e.CommandArgument.ToString())
                ShowData()
            End If
        End Sub

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
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

        Protected Sub GrdResultRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles grdResult.RowDeleting
            'Do nothing
        End Sub

        Protected Sub GrdResultRowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles grdResult.RowEditing
            'Do nothing
        End Sub

        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            Dim dtb As DataTable
            If theaterId = -1 Then
                dtb = TicketTypeByMovie.SelectData(moviePopup.MovieId, Nothing, Nothing, circuitId, Nothing)
            Else
                dtb = TicketTypeByMovie.SelectData(moviePopup.MovieId, Nothing, theaterId, Nothing, Nothing)
            End If
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Ticket_TicketTypeByMovie, True)

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
            TicketTypeByMovie.Delete(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)))
        End Sub

        Private Sub CheckType(ByVal checkAll As Boolean)
            For i As Integer = 0 To rptList.Items.Count - 1
                CType(rptList.Items(i).FindControl("chkName"), CheckBox).Checked = checkAll
            Next
        End Sub

        Private Sub ClearForm()
            lblError.Visible = False

            CheckType(False)
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
                lblError.Text += vbNewLine + "Please select any ticket type !"
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
                        TicketTypeByMovie.UpdateInsert(moviePopup.MovieId, ticketId, CInt(item.Value), userId)
                    Next
                Next
            Else
                For Each ticketId As Int32 In ticketList
                    TicketTypeByMovie.UpdateInsert(moviePopup.MovieId, ticketId, theaterId, userId)
                Next
            End If

            ShowData()
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

            Dim dtb As DataTable = TicketTypeByMovie.SelectData(moviePopup.MovieId, typeId, theaterId, circuitId, Nothing)

            If typeId Is Nothing Then
                Dim viewType As New DataView(dtb)
                Dim dtbType As DataTable = viewType.ToTable(True, "ticket_type_id", "ticket_type_name")
                ddlType.DataSource = dtbType
                ddlType.DataTextField = "ticket_type_name"
                ddlType.DataValueField = "ticket_type_id"

                Dim firstRow As DataRow = dtbType.NewRow()
                firstRow("ticket_type_name") = "All"
                firstRow("ticket_type_id") = -1
                dtbType.Rows.InsertAt(firstRow, 0)
                ddlType.DataBind()
            End If

            'Dim dtb As DataTable
            'If theaterId = -1 Then
            '    dtb = TicketTypeByMovie.SelectData(moviePopup.MovieId, Nothing, Nothing, circuitId, Nothing)
            'Else
            '    dtb = TicketTypeByMovie.SelectData(moviePopup.MovieId, Nothing, theaterId, Nothing, Nothing)
            'End If
            pnlActionAll.Visible = Not (IsNothing(dtb) OrElse dtb.Rows.Count = 0)
            pnlToolBar.Visible = pnlActionAll.Visible

            grdResult.DataSource = dtb
            grdResult.DataBind()
            ClearForm()
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

            RefreshTicketType()
        End Sub

        Private Sub RefreshTicketType()
            ddlType.Items.Clear()

            Dim dtb As DataTable
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32 = CInt(ddlTheater.SelectedItem.Value)
            If theaterId = -1 Then
                dtb = TicketType.SelectData(Nothing, Nothing, circuitId, Nothing, True, True)
            Else
                dtb = TicketType.SelectData(Nothing, Nothing, circuitId, theaterId, True, False)
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

#End Region
    End Class
End Namespace