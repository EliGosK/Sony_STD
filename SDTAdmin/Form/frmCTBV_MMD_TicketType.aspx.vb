Option Strict On

Imports System.Data
Imports System.Collections.Generic
Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Utils

Namespace Form

    Partial Public Class FrmCtbvMmdTicketType
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
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancel.Click
            SetForm(Nothing)
        End Sub
        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            DBInterface.User.Logout()
        End Sub
        Protected Sub BtnInsertUpdateClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnInsertUpdate.Click
            If String.IsNullOrEmpty(hdfKeyId.Value) Then
                InsertUpdate(Nothing)
            Else
                InsertUpdate(CInt(hdfKeyId.Value))
            End If
        End Sub
        Protected Sub BtnSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectAll.Click
            CheckTheater(True)
        End Sub
        Protected Sub BtnSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSelectNone.Click
            CheckTheater(False)
        End Sub
        Protected Sub DdlCircuitSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCircuit.SelectedIndexChanged
            ShowData()
            RefreshTheater(Theater.SelectData(Nothing, CInt(ddlCircuit.SelectedItem.Value), True))
            SetForm(Nothing)
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            If e.CommandName = "Edit" Then
                SetForm(CInt(e.CommandArgument))
            End If
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
            Dim dtb As DataTable = TicketType.SelectData(Nothing, Nothing, CInt(ddlCircuit.SelectedItem.Value), Nothing, Nothing, False)
            SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Ticket_TicketType, True)

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

            SetForm(Nothing)
            ShowData()
        End Sub
#End Region

#Region "Methods"
        Private Sub CheckTheater(ByVal checkAll As Boolean)
            For i As Integer = 0 To rptList.Items.Count - 1
                CType(rptList.Items(i).FindControl("chkTherter"), CheckBox).Checked = checkAll
            Next
        End Sub
        Private Sub InsertUpdate(ByVal keyId As Int32?)
            Dim countError As Int32 = 0
            Dim theaterList As New List(Of Int32)

            lblError.Text = String.Empty
            If String.IsNullOrEmpty(txtName.Text.Trim()) Then
                lblError.Text += vbNewLine + "Please input name !"
                lblError.Visible = True
                countError += 1
            End If

            Dim checkAll As Boolean = True
            For i As Integer = 0 To rptList.Items.Count - 1
                Dim item As RepeaterItem = rptList.Items(i)
                Dim chk As CheckBox = CType(item.FindControl("chkTherter"), CheckBox)
                If chk.Checked Then
                    'Response.Write(chk.Text)
                    theaterList.Add(CType(CType(item.FindControl("hdfTheaterId"), HiddenField).Value, Integer))
                Else
                    checkAll = False
                End If
            Next

            If theaterList.Count() = 0 Then
                lblError.Text += vbNewLine + "Please select any theater !"
                lblError.Visible = True
                countError += 1
            End If

            If countError > 0 Then
                Return
            End If

            Dim strListTheater As String
            If checkAll Then
                strListTheater = Nothing
            Else
                strListTheater = theaterList.Aggregate(String.Empty, Function(current, theaterId) current & ("," & theaterId.ToString()))
                strListTheater = strListTheater.Substring(1)
            End If

            If IsNothing(keyId) Then
                Dim dtb As DataTable = TicketType.SelectData(Nothing, txtName.Text.Trim(), CInt(ddlCircuit.SelectedItem.Value), Nothing, Nothing, False)
                If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                    TicketType.Insert(txtName.Text.Trim(), CInt(ddlCircuit.SelectedItem.Value), strListTheater, chkActive.Checked, CStr(Session("UserID")))
                Else
                    lblError.Text = txtName.Text.Trim() & " in " & ddlCircuit.SelectedItem.Text & " already exist !"
                    lblError.Visible = True
                    Return
                End If
            Else
                TicketType.Update(keyId.Value, txtName.Text.Trim(), CInt(ddlCircuit.SelectedItem.Value), strListTheater, chkActive.Checked, CStr(Session("UserID")))
            End If
            SetForm(Nothing)
            ShowData()
        End Sub
        Private Sub SetForm(ByVal keyId As Int32?)
            lblError.Visible = False

            If IsNothing(keyId) Then
                CheckTheater(True)

                lblAction.Text = "Add new data"

                hdfKeyId.Value = Nothing
                txtName.Text = String.Empty

                chkActive.Checked = True

                btnInsertUpdate.ImageUrl = "~/images/ADDCCC.png"
            Else
                lblAction.Text = "Update data"
                Dim dtb As DataTable = TicketType.SelectData(keyId, Nothing, Nothing, Nothing, Nothing, False)
                If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                    SetForm(Nothing)
                Else
                    Dim dr As DataRow = dtb.Rows(0)

                    hdfKeyId.Value = keyId.Value.ToString()
                    txtName.Text = dr("ticket_type_name").ToString()

                    Dim theater As Object = dr("list_theater_id")
                    If Not IsDBNull(theater) AndAlso Not String.IsNullOrEmpty(CStr(theater)) Then
                        CheckTheater(False)

                        Dim theaterList As String = "," + theater.ToString() & ","
                        For i As Integer = 0 To rptList.Items.Count - 1
                            If theaterList.Contains("," + CType(rptList.Items(i).FindControl("hdfTheaterId"), HiddenField).Value.ToString() + ",") Then
                                CType(rptList.Items(i).FindControl("chkTherter"), CheckBox).Checked = True
                            End If
                        Next
                    Else
                        CheckTheater(True)
                    End If

                    chkActive.Checked = DirectCast(dr("active_flag"), Boolean)

                    btnInsertUpdate.ImageUrl = "~/images/SAVECCC.png"
                End If
            End If
        End Sub
        Private Sub ShowData()
            Dim dtb As DataTable = TicketType.SelectData(Nothing, Nothing, CInt(ddlCircuit.SelectedItem.Value), Nothing, Nothing, False)
            grdResult.DataSource = dtb
            grdResult.DataBind()
        End Sub
        Private Sub RefreshTheater(ByVal dtb As DataTable)
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("sep", GetType(String))
                For i As Integer = 0 To dtb.Rows.Count - 1
                    dtb.Rows(i)("sep") = IIf((i + 1) Mod 3 = 0, "</tr><tr>", String.Empty)
                Next
            End If

            rptList.DataSource = dtb
            rptList.DataBind()
        End Sub
#End Region

    End Class
End Namespace