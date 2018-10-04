Option Strict On

Imports SDTCommon.Extensions
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmVpfProblemRecord
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

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancel.Click
            Response.Redirect("frmVPF_ProblemRecord.aspx")
        End Sub

        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            SDTCommon.DBInterface.User.Logout()
        End Sub

        Protected Sub BtnSearchClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnSearch.Click
            ShowData()
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

        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCircuit.SelectedIndexChanged
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True))
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

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Menu_Vpf_ProblemRecord, True)

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

            pnlDataPanel.Visible = False
        End Sub

#End Region

#Region "Methods"

        Private Shared Sub DeleteKey(ByVal keyString As String)
            Dim strArr() As String = keyString.Split(","(0))
            ProblemRecord.Delete(strArr(0).ToDateTime("yyyyMMdd"), CInt(strArr(1)), CInt(strArr(2)))
        End Sub

        Private Sub ShowData()
            Dim circuitId As Int32? = CInt(ddlCircuit.SelectedItem.Value)
            Dim theaterId As Int32? = CInt(ddlTheater.SelectedItem.Value)
            If theaterId = -1 Then
                theaterId = Nothing
            End If
            Dim movieId As Int32? = moviePopup.MovieId
            If IsNothing(movieId) OrElse movieId = 0 Then
                movieId = Nothing
            End If

            Dim dtb As DataTable = ProblemRecord.SelectData(Nothing, theaterId, movieId, circuitId, dtpStartDate.SelectedDate, dtpEndDate.SelectedDate)
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("DataKey", GetType(String))
                For Each dr As DataRow In dtb.Rows
                    dr("DataKey") = CDate(dr("revenue_date")).ToString("yyyyMMdd") + "," + dr("theater_id").ToString() + "," + dr("movie_id").ToString()
                Next
                grdResult.DataSource = dtb
                grdResult.DataBind()
            End If

            pnlDataPanel.Visible = Not (IsNothing(dtb) OrElse dtb.Rows.Count = 0)
            lblNotFound.Visible = Not pnlDataPanel.Visible
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
        End Sub

#End Region
    End Class
End Namespace