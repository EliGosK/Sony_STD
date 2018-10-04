Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions
Imports SDTCommon.Utils

Namespace Checker
    Partial Public Class SendFreeTicketAndPerCap
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnBackToSendRevenueClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToSendRevenue.Click
            BackToRevenue()
        End Sub
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnCompleteAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCompleteAll.Click
            Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
            Dim userId As String = GetUserId()
            RevenueOwner.UpdateRevenueStatus(revenueId, 2)
            BackToRevenue()
        End Sub
        Protected Sub BtnUpdateClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
            Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
            UpdateActualSetTicketRefresh(revenueId)
        End Sub
        Protected Sub BtnUpdateDetailClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateDetail.Click
            lblError0.Visible = False
            btnCompleteAll.Enabled = True

            Dim quantity As Int32 = txtQuantity.GetInt32()
            If quantity > 0 Then
                'UpdateHeader(False)
                Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
                Dim ticketCapId As Int32 = CInt(ddlFreeTicketByMovie.SelectedItem.Value)
                Dim price As Int32 = CInt(hdfPrice.Value)

                Dim userId As String = GetUserId()

                FreeTicketAndPerCapRevenueDetail.UpdateInsert(revenueId, ticketCapId, price, quantity, userId)
                SumDetail(revenueId)
                UpdateActualSetTicketRefresh(revenueId)
            Else
                lblError0.Visible = True
                btnCompleteAll.Enabled = False
            End If
        End Sub
        Protected Sub BtnUpdateHeaderClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateHeader.Click
            UpdateHeader(True)
            'RedirectCurrentPage(PageName.SendFreeTicketAndPerCap, True)
        End Sub
        Protected Sub GrdFreeTicketRevenueRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdFreeTicketRevenue.RowCommand
            If e.CommandName = "Del" Then
                Dim keyId As Int32 = CType(e.CommandArgument, Int32)
                FreeTicketAndPerCapRevenueDetail.Delete(keyId)

                Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
                SumDetail(revenueId)
                UpdateActualSetTicketRefresh(revenueId)
            End If
        End Sub
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            GetFreeTicketAndPerCapByMovie()

            If IsPostBack Then
                Return
            End If
            ddlFreeTicketByMovie.Attributes.Add("onchange", "changeHeader();")
            txtFreeTicketNormCount.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtFreeTicketSpecialCount.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtFreeMore5Count.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtFreeMore5Sum.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtQuantity.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            Dim revenueIdStr As String = GetRequest(ParamList.RevenueId)
            If String.IsNullOrEmpty(revenueIdStr) Then
                Return
            End If
            Dim revenueId As Int32 = CType(revenueIdStr, Int32)

            Dim dtbFreeTicketAndPerCapByMovie As DataTable = GetFreeTicketAndPerCapByMovie()
            ddlFreeTicketByMovie.DataSource = dtbFreeTicketAndPerCapByMovie
            ddlFreeTicketByMovie.DataTextField = "ticket_cap_name"
            ddlFreeTicketByMovie.DataValueField = "ticket_cap_id"
            ddlFreeTicketByMovie.DataBind()

            Dim dtbHeader As DataTable = FreeTicketAndPerCapRevenueHeader.SelectData(revenueId)
            If Not IsNothing(dtbHeader) AndAlso dtbHeader.Rows.Count > 0 Then
                Dim dr As DataRow = dtbHeader.Rows(0)
                txtFreeTicketNormCount.Text = If0ThenEmpty(CType(dr("free_ticket_norm_count"), Int32).ToString())
                txtFreeTicketSpecialCount.Text = If0ThenEmpty(CType(dr("free_ticket_special_count"), Int32).ToString())
                txtFreeMore5Count.Text = If0ThenEmpty(CType(dr("free_more_5_count"), Int32).ToString())
                txtFreeMore5Sum.Text = If0ThenEmpty(CType(dr("free_more_5_sum"), Double).ToString())
            End If

            SumDetail(revenueId)
        End Sub
#End Region

#Region "Methods"
        Private Function GetFreeTicketAndPerCapByMovie() As DataTable
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim dtbFreeTicketAndPerCapByMovie As DataTable = FreeTicketAndPerCapByMovie.SelectData(movieId, Nothing, GetTheaterId(), Nothing, True)
            pnlRevenue.Visible = False
            lblNotFoundAnyTicketByMovie.Visible = False
            If Not IsNothing(dtbFreeTicketAndPerCapByMovie) AndAlso dtbFreeTicketAndPerCapByMovie.Rows.Count > 0 Then
                pnlRevenue.Visible = True
                SetHidenData(dtbFreeTicketAndPerCapByMovie.ToDataString("ticket_cap_id", "ticket_cap_name", "list_price", "default_price"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LoadedScript", "changeHeader()", True)
            Else
                lblNotFoundAnyTicketByMovie.Visible = True
            End If
            Return dtbFreeTicketAndPerCapByMovie
        End Function

        Private Sub BackToRevenue()
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId), Int32)
            Dim movieName As String = GetRequest(ParamList.MovieName)
            Dim sendForm As PageName = CType(GetRequest(ParamList.SendFrom), PageName)
            'Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
            'Dim param As String = GetParamString(PageName.SendRevenue, movieName, movieId, movieTypeId, revenueId, Nothing)

            Dim param As String = GetParamString(sendForm, movieName, movieId, movieTypeId, Nothing, Nothing)
            Redirect(PageName.SendRevenue, param)
        End Sub
        Private Sub SumDetail(ByVal revenueId As Int32)
            lblErrorCount.Visible = False
            btnCompleteAll.Enabled = True

            Dim revenueAmountNoCap As Double = 0
            Dim viewerWithFreeTicket As Int32 = 0
            Dim dtbOwner As DataTable = RevenueOwner.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            Dim completeRevenue As Boolean = False
            If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                Dim dr As DataRow = dtbOwner.Rows(0)
                lblRevenueDate.Text = String.Format("{0:dd/MM/yyyy}", dr("revenue_date")).Replace("-", "/")
                revenueAmountNoCap = CType(dr("revenue_amount_no_cap"), Double)
                viewerWithFreeTicket = CType(dr("revenue_adms_with_free_ticket"), Int32)
                completeRevenue = CType(dr("status_id"), Int32) < 3
            End If
            If completeRevenue Then
                btnUpdateHeader.Text = "ส่งยอดจริงไปแล้ว"
                btnUpdateHeader.Enabled = False

                btnUpdateDetail.Text = "x"
                btnUpdateDetail.Enabled = False

                'btnUpdate.Enabled = False
                btnCompleteAll.Enabled = False

                grdFreeTicketRevenue.Enabled = False
            End If
            grdOwner.DataSource = dtbOwner
            grdOwner.DataBind()

            Dim dtbFreeTicketAndPerCapByRevenueDetail As DataTable = FreeTicketAndPerCapRevenueDetail.SelectData(revenueId)
            grdFreeTicketRevenue.DataSource = dtbFreeTicketAndPerCapByRevenueDetail
            grdFreeTicketRevenue.DataBind()

            Dim dtbCheckingFreeTicketAndCap As DataTable = FreeTicketAndPerCapRevenueHeader.SelectCheckRevenue(revenueId)
            If Not IsNothing(dtbCheckingFreeTicketAndCap) AndAlso dtbCheckingFreeTicketAndCap.Rows.Count > 0 Then
                Dim dr As DataRow = dtbCheckingFreeTicketAndCap.Rows(0)
                lblSumFreeTicketRevenue.Text = CType(dr("sum_revenue_free"), String)
                lblSumCapRevenue.Text = CType(dr("sum_revenue_cap"), String)

                revenueAmountNoCap = CType(dr("revenue_amount_no_cap"), Double)
                Dim sumRevenueFreeCap As Double = CType(dr("sum_revenue_free_cap"), Double)
                lblFreeTicketAndCapSumRevenue.Text = CType(sumRevenueFreeCap, String)
                lblSumRevenue.Text = (revenueAmountNoCap + sumRevenueFreeCap).ToString()
                lblRemainViewer.Text = CType(dr("actual_viewer"), String)
                If CInt(dr("sum_complete")) = 0 Then
                    pnlErrorRevenue.Visible = True
                End If
                'If CInt(dr("count_complete")) = 0 Then
                '    lblErrorCount.Visible = True
                '    btnCompleteAll.Enabled = False
                'End If
            Else 'ไม่มีโอกาสเข้า Else
                lblSumFreeTicketRevenue.Text = 0.ToString()
                lblSumCapRevenue.Text = 0.ToString()
                lblFreeTicketAndCapSumRevenue.Text = 0.ToString()
                lblSumRevenue.Text = revenueAmountNoCap.ToString()
                lblRemainViewer.Text = viewerWithFreeTicket.ToString()
            End If
        End Sub
        Private Sub UpdateHeader(ByVal updateWhenFound As Boolean)
            Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
            Dim freeTicketNormCount As Int32 = txtFreeTicketNormCount.GetInt32()
            Dim freeTicketSpecialCount As Int32 = txtFreeTicketSpecialCount.GetInt32()
            Dim freeMore5Count As Int32 = txtFreeMore5Count.GetInt32()
            Dim freeMore5Sum As Double = txtFreeMore5Sum.GetDouble()
            Dim userId As String = GetUserId()

            Dim dtbFreeHeader As DataTable = FreeTicketAndPerCapRevenueHeader.SelectData(revenueId)
            If IsNothing(dtbFreeHeader) OrElse dtbFreeHeader.Rows.Count = 0 Then
                FreeTicketAndPerCapRevenueHeader.Insert(revenueId, freeTicketNormCount, freeTicketSpecialCount, freeMore5Count, freeMore5Sum, userId)
            Else
                If updateWhenFound Then
                    FreeTicketAndPerCapRevenueHeader.Update(revenueId, freeTicketNormCount, freeTicketSpecialCount, freeMore5Count, freeMore5Sum, userId)
                End If
            End If
            SumDetail(revenueId)
            UpdateActualSetTicketRefresh(revenueId)
        End Sub
        Private Sub UpdateActualSetTicketRefresh(ByVal revenueId As Int32)
            Dim userId As String = GetUserId()
            RevenueOwner.UpdateActualSetTicket(revenueId, lblSumRevenue.GetDouble(), lblRemainViewer.GetInt32(), userId)

            RedirectCurrentPage(PageName.SendFreeTicketAndPerCap, True)
        End Sub
#End Region

    End Class
End Namespace