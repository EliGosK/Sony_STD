Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class SendTicketType
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnBackToSendRevenueClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToSendRevenue.Click
            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId), Int32)
            Dim movieName As String = GetRequest(ParamList.MovieName)
            Dim sendForm As PageName = CType(GetRequest(ParamList.SendFrom), PageName)
            'Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
            'Dim param As String = GetParamString(PageName.SendRevenue, movieName, movieId, movieTypeId, revenueId, Nothing)

            Dim param As String = GetParamString(sendForm, movieName, movieId, movieTypeId, Nothing, Nothing)
            Redirect(PageName.SendRevenue, param)
        End Sub
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnUpdateDetailClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdateDetail.Click
            Dim quantity As Int32 = txtQuantity.GetInt32()
            If quantity > 0 Then
                Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
                Dim ticketTypeId As Int32 = CInt(ddlTicketTypeByMovie.SelectedItem.Value)
                Dim userId As String = GetUserId()

                TicketTypeRevenueDetail.UpdateInsert(revenueId, ticketTypeId, quantity, userId)

                SumDetail(revenueId)
                UpdateCount(revenueId)

                RedirectCurrentPage(PageName.SendTicketType, True)
            Else
                lblError0.Visible = True
            End If
        End Sub
        Protected Sub GrdTicketTypeRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdTicketType.RowCommand
            If e.CommandName = "Del" Then
                Dim keyId As Int32 = CType(e.CommandArgument, Int32)
                TicketTypeRevenueDetail.Delete(keyId)

                Dim revenueId As Int32 = CType(GetRequest(ParamList.RevenueId), Int32)
                SumDetail(revenueId)
                UpdateCount(revenueId)

                RedirectCurrentPage(PageName.SendTicketType, True)
            End If
        End Sub
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If IsPostBack Then
                Return
            End If
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

            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim dtbTicketTypeByMovie As DataTable = TicketTypeByMovie.SelectData(movieId, Nothing, GetTheaterId(), Nothing, True)
            pnlRevenue.Visible = False
            lblNotFoundAnyTicketByMovie.Visible = False
            If Not IsNothing(dtbTicketTypeByMovie) AndAlso dtbTicketTypeByMovie.Rows.Count > 0 Then
                pnlRevenue.Visible = True
            Else
                lblNotFoundAnyTicketByMovie.Visible = True
            End If
            ddlTicketTypeByMovie.DataSource = dtbTicketTypeByMovie
            ddlTicketTypeByMovie.DataTextField = "ticket_type_name"
            ddlTicketTypeByMovie.DataValueField = "ticket_type_id"
            ddlTicketTypeByMovie.DataBind()

            SumDetail(revenueId)
        End Sub
#End Region

#Region "Methods"
        Private Sub SumDetail(ByVal revenueId As Int32)
            Dim actualViewer As Int32 = 0
            Dim dtbOwner As DataTable = RevenueOwner.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                Dim dr As DataRow = dtbOwner.Rows(0)
                lblRevenueDate.Text = String.Format("{0:dd/MM/yyyy}", dr("revenue_date")).Replace("-", "/")
                actualViewer = CType(dr("revenue_adms"), Int32)
            End If
            grdOwner.DataSource = dtbOwner
            grdOwner.DataBind()

            Dim dtbTicketTypeRevenueDetail As DataTable = TicketTypeRevenueDetail.SelectData(revenueId)
            grdTicketType.DataSource = dtbTicketTypeRevenueDetail
            grdTicketType.DataBind()

            Dim countTicketType As Int32 = 0
            lblErrorCountRevernue.Visible = False
            If Not IsNothing(dtbTicketTypeRevenueDetail) AndAlso dtbTicketTypeRevenueDetail.Rows.Count > 0 Then
                For Each dr As DataRow In dtbTicketTypeRevenueDetail.Rows
                    countTicketType += CInt(dr("quantity"))
                Next
            End If
            'If (countTicketType = 0 AndAlso actualViewer <> 0) OrElse countTicketType > actualViewer Then
            '    lblErrorCountRevernue.Visible = True
            'End If
            lblCountTicketType.Text = countTicketType.ToString()
        End Sub
        Private Sub UpdateCount(ByVal revenueId As Int32)
            Dim userId As String = GetUserId()
            Dim count As Int32 = lblCountTicketType.GetInt32()
            TicketTypeRevenueHeader.UpdateInsert(revenueId, count, userId)
        End Sub
#End Region

    End Class
End Namespace