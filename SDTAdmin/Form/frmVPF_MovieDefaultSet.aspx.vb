Option Strict On

Imports System.Collections.Generic
Imports SDTCommon.Extensions
Imports Web.Data
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmVpfMovieDefaultSet
        Inherits Page

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
            Response.Redirect("frmVPF_MovieDefaultSet.aspx")
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnGridSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnGridSelectNone.Click
            CheckBoxAllGrid(False)
        End Sub

        Protected Sub BtnGridSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnGridSelectAll.Click
            CheckBoxAllGrid(True)
        End Sub

        Protected Sub BtnInsertUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnInsertUpdate.Click
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

        'Protected Sub BtnSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
        '    CheckBoxAllChecker(True)
        'End Sub

        'Protected Sub BtnSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectNone.Click
        '    CheckBoxAllChecker(False)
        'End Sub

        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCircuit.SelectedIndexChanged
            ShowData()
        End Sub

        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            Dim keyString As String = e.CommandArgument.ToString()
            If e.CommandName = "Delete" Then
                DeleteKey(keyString)
                ShowData()
            ElseIf e.CommandName = "Edit" Then
                Dim strArr() As String = keyString.Split(","(0))
                Dim dtb As DataTable = VpfMovieDefaultSet.SelectData(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)))
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr As DataRow = dtb.Rows(0)

                    Dim typeId As String = dr("film_type_sound_id").ToString()
                    For Each item As RepeaterItem In rptList.Items
                        Dim hdf As HiddenField = CType(item.FindControl("hdfId"), HiddenField)
                        Dim chk As CheckBox = CType(item.FindControl("chkName"), CheckBox)
                        chk.Checked = (hdf.Value = typeId)
                    Next

                    dtpStartDate.SelectedDate = CType(dr("vpf_start_date"), Date?)
                    txtAmountOfSet.Text = dr("sets_amount").ToString()
                    txtSetDays.Text = dr("set_days").ToString()
                    txtSetSessions.Text = dr("set_sessions").ToString()
                    txtSetPrice.Text = dr("set_price").ToString()
                End If
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
            End If

            Dim circuitId As Int32? = CInt(ddlCircuit.SelectedItem.Value)
            If circuitId <> -1 Then
                If DataBinder.Eval(e.Row.DataItem, "circuit_id").ToString() = "-1" Then
                    ctl = e.Row.Cells(1).FindControl("btnEdit")
                    If Not IsNothing(ctl) Then
                        Dim btn As LinkButton = CType(ctl, LinkButton)
                        btn.Visible = False
                    End If
                    ctl = e.Row.Cells(1).FindControl("btnDelete")
                    If Not IsNothing(ctl) Then
                        Dim btn As LinkButton = CType(ctl, LinkButton)
                        btn.Visible = False
                    End If
                End If
            End If

        End Sub

        Protected Sub GrdResultRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles grdResult.RowDeleting
            'Do nothing
        End Sub

        Protected Sub GrdResultRowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs) Handles grdResult.RowEditing
            'Do nothing
        End Sub

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If IsPostBack Then
                Return
            End If
            txtAmountOfSet.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtSetSessions.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtSetPrice.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtSetDays.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Menu_Vpf_MovieDefaultSet, True)

            btnActionDelete.OnClientClick = "return ManipulateGrid()"

            moviePopup.MovieType = "1"
            moviePopup.VisibleMovieType = False
            moviePopup.BindData()

            Dim dtbCircuit As DataTable = Circuit.SelectData(Nothing)
            Dim dr As DataRow = dtbCircuit.NewRow()
            dr("circuit_name") = "All"
            dr("circuit_id") = "-1"
            dtbCircuit.Rows.InsertAt(dr, 0)

            ddlCircuit.DataSource = dtbCircuit
            ddlCircuit.DataTextField = "circuit_name"
            ddlCircuit.DataValueField = "circuit_id"
            ddlCircuit.DataBind()

            Dim dtb As DataTable = FilmTypeSound.SelectData()
            For i As Int32 = dtb.Rows.Count - 1 To 0 Step -1
                Dim name As String = dtb.Rows(i)("film_type_sound_header_group").ToString().ToUpper()
                If Not name.Contains("2D") AndAlso Not name.Contains("3D") AndAlso Not name.Contains("4D") Then
                    dtb.Rows.RemoveAt(i)
                End If
            Next

            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("sep", GetType(String))
                For i As Integer = 0 To dtb.Rows.Count - 1
                    dtb.Rows(i)("sep") = IIf((i + 1) Mod 2 = 0, "</tr><tr>", String.Empty)
                Next
            End If

            rptList.DataSource = dtb
            rptList.DataBind()
        End Sub

        Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If moviePopup.MovieId <> 0 Then
                Dim cDb As New cDatabase
                Dim dataReader As IDataReader = cDb.getMovieDetail(moviePopup.MovieId)
                If dataReader.Read Then
                    Dim startDate As Date? = CType(dataReader("movie_strdate"), Date?)
                    If Not IsNothing(startDate) Then
                        dtpStartDate.SelectedDate = startDate
                    End If
                End If
                dataReader.Close()
            End If
        End Sub

#End Region

#Region "Methods"

        Private Sub CheckBoxAllChecker(ByVal checkAll As Boolean)
            For i As Integer = 0 To rptList.Items.Count - 1
                CType(rptList.Items(i).FindControl("chkName"), CheckBox).Checked = checkAll
            Next
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

            CheckBoxAllChecker(False)
            dtpStartDate.SelectedDate = Nothing
            txtAmountOfSet.Text = "1"
            txtSetDays.Text = String.Empty
            txtSetSessions.Text = String.Empty
            txtSetPrice.Text = String.Empty
        End Sub

        Private Shared Sub DeleteKey(ByVal keyString As String)
            Dim strArr() As String = keyString.Split(","(0))
            VpfMovieDefaultSet.Delete(CInt(strArr(0)), CInt(strArr(1)), CInt(strArr(2)))
        End Sub

        Private Sub InsertUpdate()
            Dim countError As Int32 = 0

            lblError.Visible = True
            lblError.Text = String.Empty

            Dim startDate As Date? = dtpStartDate.SelectedDate
            Dim amountOfSet As Int32 = txtAmountOfSet.GetInt32()
            Dim setDays As Int32 = txtSetDays.GetInt32()
            Dim setSessions As Int32 = txtSetSessions.GetInt32()
            Dim setPrice As Int32 = txtSetPrice.GetInt32()

            If startDate Is Nothing Then
                lblError.Text += vbNewLine + "Start date must not empty !"
                countError += 1
            End If

            If Not amountOfSet > 0 Then
                lblError.Text += vbNewLine + "Amount must more than 0 !"
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

            Dim selectedList As New List(Of Integer)
            For Each item As RepeaterItem In rptList.Items
                Dim chk As CheckBox = CType(item.FindControl("chkName"), CheckBox)
                If chk.Checked Then
                    selectedList.Add(CType(CType(item.FindControl("hdfId"), HiddenField).Value, Integer))
                End If
            Next

            If selectedList.Count() = 0 Then
                lblError.Text += vbNewLine + "Please select any film type !"
                countError += 1
            End If

            If countError > 0 Then
                Return
            End If

            lblError.Visible = False

            Dim userId As String = CStr(Session("UserID"))
            Dim circuitId As Int32? = CInt(ddlCircuit.SelectedItem.Value)
            amountOfSet = 1 'Fix
            For Each seledtedId As Int32 In selectedList
                VpfMovieDefaultSet.UpdateInsert(moviePopup.MovieId, circuitId.Value, seledtedId, startDate.Value, amountOfSet, setDays, setSessions, setPrice, userId)
            Next

            ShowData()
            ClearForm()
        End Sub

        Private Sub ShowData()
            If Not pnlDataPanel.Visible Then
                Return
            End If
            Dim circuitId As Int32? = CInt(ddlCircuit.SelectedItem.Value)
            'If circuitId = -1 Then
            '    circuitId = Nothing
            'End If

            Dim dtb As DataTable = VpfMovieDefaultSet.SelectData(moviePopup.MovieId, circuitId, Nothing)
            lblNotFound.Visible = (IsNothing(dtb) OrElse dtb.Rows.Count = 0)
            pnlToolBar.Visible = Not lblNotFound.Visible
            pnlActionAll.Visible = Not lblNotFound.Visible

            If pnlToolBar.Visible Then
                dtb.Columns.Add("key_string", GetType(String))
                For Each dr As DataRow In dtb.Rows
                    dr("key_string") = dr("movie_id").ToString() + "," + dr("circuit_id").ToString() + "," + dr("film_type_sound_id").ToString()
                Next
            End If

            grdResult.DataSource = dtb
            grdResult.DataBind()
        End Sub

#End Region
    End Class
End Namespace