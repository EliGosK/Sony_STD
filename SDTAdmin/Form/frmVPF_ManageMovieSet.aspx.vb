Option Strict On

Imports SDTCommon.Extensions
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmVpfManageMovieSet
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

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnInsertUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnInsertUpdate.Click
            InsertUpdate()
        End Sub

        Protected Sub BtnLoadDefaultSetClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadDefaultSet.Click
            Dim userId As String = CStr(Session("UserID"))
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32? = CInt(ddlTheater.SelectedItem.Value)
            If theaterId = -1 Then
                theaterId = Nothing
            End If
            VpfManageMovieSet.LoadDefaultSet(circuitId, theaterId, moviePopup.MovieId, userId)
            ShowData()
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
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True))
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
            Select Case e.CommandName
                Case "AddMoreSet"
                    Dim strArr() As String = keyString.Split(","(0))
                    Dim userId As String = CStr(Session("UserID"))
                    VpfManageMovieSet.CopyRow(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)), CInt(strArr(3)), userId)
                    ShowData()
                Case "Edit"
                    Dim strArr() As String = keyString.Split(","(0))
                    Dim dtb As DataTable = VpfManageMovieSet.SelectData(Nothing, CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)), CInt(strArr(3)))
                    If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                        Dim dr As DataRow = dtb.Rows(0)

                        hdfTheaterId.Value = dr("theater_id").ToString()
                        hdfFilmTypeSoundId.Value = dr("film_type_sound_id").ToString()

                        lblTheaterName.Text = dr("theater_name").ToString()
                        lblFormat.Text = dr("film_type_sound_header_group").ToString()
                        lblSetNo.Text = dr("set_no").ToString()

                        dtpStartDate.SelectedDate = CType(dr("vpf_start_date"), Date?)
                        txtSetDays.Text = dr("set_days").ToString()
                        txtSetSessions.Text = dr("set_sessions").ToString()
                        txtSetPrice.Text = dr("set_price").ToString()

                        pnlActionAdd.Visible = True
                    End If
                Case "Delete"
                    DeleteKey(keyString)
                    ShowData()
                    pnlActionAdd.Visible = False
            End Select
        End Sub

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim userPrice As Object = DataBinder.Eval(e.Row.DataItem, "actual_price")
            Dim ctl As Object = e.Row.Cells(1).FindControl("btnEdit")
            If Not IsNothing(ctl) Then
                Dim btn As LinkButton = CType(ctl, LinkButton)
                If Not String.IsNullOrEmpty(userPrice.ToString()) Then
                    btn.Visible = False
                Else
                    btn.Visible = True
                End If
            End If
            ctl = e.Row.Cells(1).FindControl("btnDelete")
            If Not IsNothing(ctl) Then
                Dim btn As LinkButton = CType(ctl, LinkButton)
                If Not String.IsNullOrEmpty(userPrice.ToString()) Then
                    btn.Visible = False
                Else
                    btn.Visible = True
                    btn.OnClientClick = "return confirm('Confirm to delete ?')"
                End If
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
                dtb = VpfManageMovieSet.SelectData(circuitId, Nothing, moviePopup.MovieId, Nothing, Nothing)
            Else
                dtb = VpfManageMovieSet.SelectData(circuitId, theaterId, moviePopup.MovieId, Nothing, Nothing)
            End If
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Menu_Vpf_ManageMovieSet, True)

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
            VpfManageMovieSet.Delete(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)), CInt(strArr(3)))
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
        End Sub

        Private Sub InsertUpdate()
            Dim countError As Int32 = 0

            lblError.Visible = True
            lblError.Text = String.Empty

            Dim startDate As Date? = dtpStartDate.SelectedDate
            Dim setDays As Int32 = txtSetDays.GetInt32()
            Dim setSessions As Int32 = txtSetSessions.GetInt32()
            Dim setPrice As Int32 = txtSetPrice.GetInt32()

            If startDate Is Nothing Then
                lblError.Text += vbNewLine + "Start date must not empty !"
                countError += 1
            End If

            If Not setDays > 0 Then
                lblError.Text += vbNewLine + "Day must more than 0 !"
                countError += 1
            End If

            If Not setSessions > 0 Then
                lblError.Text += vbNewLine + "Session must more than 0 !"
                countError += 1
            End If

            If Not setPrice > 0 Then
                lblError.Text += vbNewLine + "Price must more than 0 !"
                countError += 1
            End If

            If countError > 0 Then
                Return
            End If

            lblError.Visible = False

            Dim userId As String = CStr(Session("UserID"))
            VpfManageMovieSet.UpdateInsert(CInt(hdfTheaterId.Value), moviePopup.MovieId, CInt(hdfFilmTypeSoundId.Value), CInt(lblSetNo.Text), startDate.Value, setDays, setSessions, setPrice, Nothing, Nothing, userId)

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

            Dim dtb As DataTable = VpfManageMovieSet.SelectData(circuitId, theaterId, moviePopup.MovieId, typeId, Nothing)

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
            pnlActionAll.Visible = Not lblNotFound.Visible
            pnlToolBar.Visible = Not lblNotFound.Visible
            btnLoadDefaultSet.Visible = lblNotFound.Visible

            Dim sumPrice As Decimal = 0
            Dim sumActual As Decimal = 0
            If Not lblNotFound.Visible Then
                dtb.Columns.Add("key_string", GetType(String))
                For Each dr As DataRow In dtb.Rows
                    dr("key_string") = dr("theater_id").ToString() + "," + dr("movie_id").ToString() + "," + dr("film_type_sound_id").ToString() + "," + dr("set_no").ToString()
                    Dim result As Decimal
                    Decimal.TryParse(dr("set_price").ToString(), result)
                    sumPrice = sumPrice + result
                    Decimal.TryParse(dr("actual_price").ToString(), result)
                    sumActual = sumActual + result
                Next
            End If

            grdResult.DataSource = dtb
            grdResult.DataBind()
            If (Not dtb Is Nothing AndAlso dtb.Rows.Count > 0) Then
                grdResult.FooterRow.Cells(7).Text = String.Format("{0:#,##0}", sumPrice)
                'grdResult.FooterRow.Cells(8).Text = String.Format("{0:#,##0}", sumPay)
            End If
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

            RefreshAfterChangeTheater()
        End Sub

        Private Sub RefreshAfterChangeTheater()
            ddlType.Items.Clear()
            ShowData()
        End Sub

#End Region
    End Class
End Namespace