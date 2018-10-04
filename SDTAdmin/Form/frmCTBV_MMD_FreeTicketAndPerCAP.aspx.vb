Option Strict On

Imports System.Collections.Generic
Imports SDTCommon.Extensions
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace Form
    Partial Public Class FrmCtbvMmdFreeTicketAndPerCap
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
            SDTCommon.DBInterface.User.Logout()
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
            Dim dtb As DataTable = FreeTicketAndPerCap.SelectData(Nothing, Nothing, CInt(ddlCircuit.SelectedItem.Value), Nothing, Nothing, False)
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If IsPostBack Then
                Return
            End If
            txtPriceFrom.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtPriceTo.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtStep.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtDefault.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Ticket_FreeTicketAndPerCap, True)

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
            Dim priceFrom As Int32 = - 1
            Dim priceTo As Int32 = - 1
            Dim priceDefault As Int32 = 0
            Dim priceStep As Int32 = 1
            Dim priceList As New SortedList(Of Int32, Int32)
            Dim theaterList As New List(Of Int32)

            lblError.Text = String.Empty
            If String.IsNullOrEmpty(txtName.Text.Trim()) Then
                lblError.Text += vbNewLine + "Please input name !"
                lblError.Visible = True
                countError += 1
            End If
            If String.IsNullOrEmpty(txtPriceFrom.Text.Trim()) OrElse String.IsNullOrEmpty(txtPriceTo.Text.Trim()) OrElse String.IsNullOrEmpty(txtStep.Text.Trim()) Then
                lblError.Text += vbNewLine + "Please input price period !"
                lblError.Visible = True
                countError += 1
            Else
                priceFrom = txtPriceFrom.GetInt32()
                priceTo = txtPriceTo.GetInt32()
                priceStep = txtStep.GetInt32()

                If priceStep = 0 Then
                    lblError.Text += vbNewLine + "Step must not equal 0 !"
                    lblError.Visible = True
                    countError += 1
                End If

                If priceFrom > priceTo Then
                    lblError.Text += vbNewLine + "Start Price must be less than or equal end price !"
                    lblError.Visible = True
                    countError += 1
                Else
                    If priceFrom = priceTo Then
                        priceList.Add(priceFrom, priceFrom)
                    Else
                        For i As Integer = priceFrom To priceTo Step priceStep
                            priceList.Add(i, i)
                        Next
                    End If
                End If
            End If

            If String.IsNullOrEmpty(txtDefault.Text.Trim()) Then
                lblError.Text += vbNewLine + "Please input default price !"
                lblError.Visible = True
                countError += 1
            Else
                priceDefault = txtDefault.GetInt32()
                If priceFrom <> - 1 AndAlso priceTo <> - 1 AndAlso (priceDefault < priceFrom OrElse priceDefault > priceTo) Then
                    lblError.Text += vbNewLine + "Default price must between start price and end price !"
                    lblError.Visible = True
                    countError += 1
                Else
                    If Not priceList.ContainsKey(priceDefault) Then
                        priceList.Add(priceDefault, priceDefault)
                    End If
                End If
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

            Dim strListPrice As String = priceList.Keys.Aggregate(String.Empty, Function(current, price) current & ("," & price.ToString()))
            strListPrice = strListPrice.Substring(1)

            Dim strListTheater As String
            If checkAll Then
                strListTheater = Nothing
            Else
                strListTheater = theaterList.Aggregate(String.Empty, Function(current, theaterId) current & ("," & theaterId.ToString()))
                strListTheater = strListTheater.Substring(1)
            End If

            Dim userId As String = CStr(Session("UserID"))
            Dim circuitId As Int32 = CInt(ddlCircuit.SelectedItem.Value)
            If IsNothing(keyId) Then
                Dim dtb As DataTable = FreeTicketAndPerCap.SelectData(Nothing, txtName.Text.Trim(), circuitId, Nothing, Nothing, False)
                If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                    FreeTicketAndPerCap.Insert(txtName.Text.Trim(), strListPrice, priceStep, priceDefault, circuitId, strListTheater, chkCount.Checked, chkActive.Checked, userId)
                Else
                    lblError.Text = txtName.Text.Trim() & " in " & ddlCircuit.SelectedItem.Text & " already exist !"
                    lblError.Visible = True
                    Return
                End If
            Else
                FreeTicketAndPerCap.Update(keyId.Value, txtName.Text.Trim(), strListPrice, priceStep, priceDefault, circuitId, strListTheater, chkCount.Checked, chkActive.Checked, userId)
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
                txtPriceFrom.Text = "0"
                txtPriceTo.Text = "0"
                txtStep.Text = "1"
                txtDefault.Text = "0"

                chkCount.Checked = False
                chkActive.Checked = True

                btnInsertUpdate.ImageUrl = "~/images/ADDCCC.png"
            Else
                lblAction.Text = "Update data"
                Dim dtb As DataTable = FreeTicketAndPerCap.SelectData(keyId, Nothing, Nothing, Nothing, Nothing, False)
                If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                    SetForm(Nothing)
                Else
                    Dim dr As DataRow = dtb.Rows(0)

                    hdfKeyId.Value = keyId.Value.ToString()
                    txtName.Text = dr("ticket_cap_name").ToString()
                    Dim priceArr() As String = dr("list_price").ToString().Split(","(0))
                    txtPriceFrom.Text = priceArr(0)
                    txtPriceTo.Text = priceArr(priceArr.Length - 1)
                    txtStep.Text = dr("price_step").ToString()
                    txtDefault.Text = dr("default_price").ToString()

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

                    chkCount.Checked = DirectCast(dr("counting"), Boolean)
                    chkActive.Checked = DirectCast(dr("active_flag"), Boolean)

                    btnInsertUpdate.ImageUrl = "~/images/SAVECCC.png"
                End If
            End If
        End Sub

        Private Sub ShowData()
            Dim dtb As DataTable = FreeTicketAndPerCap.SelectData(Nothing, Nothing, CInt(ddlCircuit.SelectedItem.Value), Nothing, Nothing, False)
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