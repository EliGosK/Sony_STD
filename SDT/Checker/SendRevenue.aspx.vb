Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class SendRevenue
        Inherits Page

        Private Property RevenueDate() As Date
            Get
                Return Utils.ConvertDate(lblRevenueDate.Text, "dd/MM/yyyy")
            End Get
            Set(ByVal value As Date)
                lblRevenueDate.Text = String.Format("{0:dd/MM/yyyy}", value).Replace("-", "/")
            End Set
        End Property

#Region "Event Handlers"
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnCancelEditClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelEdit.Click
            RedirectCurrentPage(PageName.SendRevenue, False)
        End Sub
        Protected Sub BtnDeleteHeaderClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeleteHeader.Click
            Dim movieId As Int32 = CInt(GetRequest(ParamList.MovieId))
            Dim theaterId As Int32 = GetTheaterId()
            RevenueCompHeader.DeleteAll(movieId, RevenueDate, theaterId)
            Redirect(PageName.MovieList)
        End Sub
        Protected Sub BtnSendClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
            If SendRevenue() Then
                Dim sendForm As PageName = CType(GetRequest(ParamList.SendFrom), PageName)
                RedirectCurrentPage(sendForm, False)
                'If sendForm = CInt(PageName.RemainMovieList) Then

                'Else
                '    RedirectCurrentPage(PageName.SendRevenue, False)
                'End If
            End If
        End Sub
        Protected Sub DdlCompRevenueTypeSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCompRevenueType.SelectedIndexChanged
            Dim preData As Boolean = (CInt(ddlCompRevenueType.SelectedItem.Value) = 3)
            pnlCompetitorPreData.Visible = preData
            pnlDetail.Visible = Not preData
            If preData Then
                lblAction.Text = "แก้ไขยอดรวมเบื้องต้น"
                btnCancelEdit.Visible = False 'ไม่แสดง ถ้าเป็น Comp เบื้องต้น

                ShowData()
            Else
                lblAction.Text = "เพิ่มรายการ"
                btnCancelEdit.Visible = False
                ddlStatus.SelectedIndex = 0
                ddlFilmTypeSound.SelectedIndex = 0
                txtRevenue.Text = String.Empty
                txtViewer.Text = String.Empty
                txtCountScreen.Text = String.Empty
                txtCountSession.Text = String.Empty
            End If
        End Sub
        '<asp:TemplateField>
        '   <HeaderTemplate>
        '       สถานะ
        '   </HeaderTemplate>
        '   <ItemTemplate>
        '       <asp:HyperLink runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "statusColor") %>'
        '           NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'></asp:HyperLink>
        '   </ItemTemplate>
        '</asp:TemplateField>
        Protected Sub GrdCompetitorRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdCompetitor.RowCommand
            If e.CommandName = "Del" Then
                Dim revenueId As Int32 = CType(e.CommandArgument, Int32)
                RevenueCompDetail.Delete(revenueId, GetUserId())
                RedirectCurrentPage(PageName.SendRevenue, False)
            End If
        End Sub
        Protected Sub GrdCompetitorRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdCompetitor.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim objStatusId As Object = DataBinder.Eval(e.Row.DataItem, "status_id")

            Dim notChecker As Boolean = (GetUserRole() <> "Checker")
            Dim notComplete As Boolean = (objStatusId.ToString() = "3")
            Dim canEditDelete As Boolean = notChecker OrElse notComplete

            Dim ctl = e.Row.Cells(5).FindControl("imgStatus")
            If Not IsNothing(ctl) Then
                Dim imgRevenue As Image = CType(ctl, Image)
                If Not IsNothing(objStatusId) AndAlso Not String.IsNullOrEmpty(objStatusId.ToString()) AndAlso objStatusId.ToString() = "2" Then
                    imgRevenue.ImageUrl = "../images/icon_accept.gif"
                Else
                    imgRevenue.ImageUrl = "../images/icon_wait.gif"
                End If
            End If

            ctl = e.Row.Cells(5).FindControl("hplStatus")
            If Not IsNothing(ctl) Then
                Dim hplStatus As HyperLink = CType(ctl, HyperLink)
                If Not canEditDelete Then
                    hplStatus.NavigateUrl = String.Empty
                End If
            End If

            ctl = e.Row.Cells(6).FindControl("btnDelete")
            If Not IsNothing(ctl) Then
                Dim btnDelete As ImageButton = CType(ctl, ImageButton)
                btnDelete.Visible = canEditDelete
            End If
        End Sub
        Protected Sub GrdOwnerRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdOwner.RowCommand
            If e.CommandName = "Del" Then
                Dim revenueId As Int32 = CType(e.CommandArgument, Int32)
                RevenueOwner.Delete(revenueId)
                RedirectCurrentPage(PageName.SendRevenue, False)
            End If
        End Sub
        Protected Sub GrdOwnerRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdOwner.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim objStatusId As Object = DataBinder.Eval(e.Row.DataItem, "status_id")

            Dim notChecker As Boolean = (GetUserRole() <> "Checker")
            Dim notComplete As Boolean = (objStatusId.ToString() = "3")
            Dim canEditDelete As Boolean = notChecker OrElse notComplete

            Dim ctl = e.Row.Cells(5).FindControl("imgStatus")
            If Not IsNothing(ctl) Then
                Dim imgRevenue As Image = CType(ctl, Image)
                If Not IsNothing(objStatusId) AndAlso Not String.IsNullOrEmpty(objStatusId.ToString()) AndAlso objStatusId.ToString() = "2" Then
                    imgRevenue.ImageUrl = "../images/icon_accept.gif"
                Else
                    imgRevenue.ImageUrl = "../images/icon_wait.gif"
                End If
            End If
            ctl = e.Row.Cells(5).FindControl("hplStatus")
            If Not IsNothing(ctl) Then
                Dim hplStatus As HyperLink = CType(ctl, HyperLink)
                If Not canEditDelete Then
                    hplStatus.NavigateUrl = String.Empty
                End If
            End If

            ctl = e.Row.Cells(6).FindControl("hplFreeTicket")
            If Not IsNothing(ctl) Then
                Dim hplFreeTicket As HyperLink = CType(ctl, HyperLink)
                ctl = e.Row.Cells(6).FindControl("imgFreeTicket")
                If Not IsNothing(ctl) Then
                    Dim imgFreeTicket As Image = CType(ctl, Image)

                    Dim errorFreeTicketAndCap As String = DataBinder.Eval(e.Row.DataItem, "ErrorFreeTicketAndCap").ToString()
                    Dim objSumRevenueFreeTicketAndCap As Object = DataBinder.Eval(e.Row.DataItem, "SumRevenueFreeTicketAndCap")
                    If Not errorFreeTicketAndCap = "Y" AndAlso Not IsNothing(objSumRevenueFreeTicketAndCap) AndAlso Not (objSumRevenueFreeTicketAndCap Is DBNull.Value) Then
                        imgFreeTicket.Visible = False
                        hplFreeTicket.Text = CInt(objSumRevenueFreeTicketAndCap).ToString("#,##0")
                    End If
                End If
            End If

            ctl = e.Row.Cells(7).FindControl("hplTicketType")
            If Not IsNothing(ctl) Then
                Dim hplTicketType As HyperLink = CType(ctl, HyperLink)
                ctl = e.Row.Cells(7).FindControl("imgTicketType")
                If Not IsNothing(ctl) Then
                    Dim imgTicketType As Image = CType(ctl, Image)

                    Dim errorTicketType As String = DataBinder.Eval(e.Row.DataItem, "ErrorTicketType").ToString()
                    Dim objCountTicketType As Object = DataBinder.Eval(e.Row.DataItem, "CountTicketType")
                    If Not errorTicketType = "Y" AndAlso Not IsNothing(objCountTicketType) AndAlso Not (objCountTicketType Is DBNull.Value) Then
                        imgTicketType.Visible = False
                        hplTicketType.Text = CInt(objCountTicketType).ToString("#,##0")
                    End If
                End If
            End If

            ctl = e.Row.Cells(8).FindControl("btnDelete")
            If Not IsNothing(ctl) Then
                Dim btnDelete As ImageButton = CType(ctl, ImageButton)
                btnDelete.Visible = canEditDelete
            End If
        End Sub
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If ddlStatus.Items.Count > 0 Then
                ddlStatus.Items(0).Attributes.Add("style", "background: orange;")
                ddlStatus.Items(1).Attributes.Add("style", "background: green;")
            End If

            If IsPostBack Then
                Return
            End If
            txtRevenue.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtViewer.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")

            txtCountScreen.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtCountSession.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")

            txtAllScreen.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtAllSession.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtAllViewer.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
            txtAllRevenue.Attributes.Add("onkeypress", "javascript:return allownumbers(event);")
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            If ddlStatus.Items.Count > 0 Then
                ddlStatus.Items(0).Attributes.Add("style", "background: orange;")
                ddlStatus.Items(1).Attributes.Add("style", "background: green;")
            End If

            RevenueDate = GetWorkingDate()
            'Check Param
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId, GetRedirectUrl(PageName.MovieList)), Int32)
            'Dim movieName As String = GetRequest(ParamList.MovieName, GetRedirectUrl(PageName.MovieList))

            'Dim param As String = GetParamString(PageName.MovieList, movieName, movieId, movieTypeId, Nothing)

            Dim dtbFilmTypeSound As DataTable = FilmTypeSound.SelectActiveData(GetTheaterId())
            ddlFilmTypeSound.DataSource = dtbFilmTypeSound
            ddlFilmTypeSound.DataTextField = "film_type_sound_name_th"
            ddlFilmTypeSound.DataValueField = "film_type_sound_id"
            ddlFilmTypeSound.DataBind()

            If movieTypeId = 1 Then
                Dim dtbHour As DataTable = RevenueTime.SelectHour()
                ddlHour.DataSource = dtbHour
                ddlHour.DataTextField = "ctbvtime_hn"
                ddlHour.DataValueField = "ctbvtime_id"
                ddlHour.DataBind()

                Dim dtbMin As DataTable = RevenueTime.SelectMinute()
                ddlMinute.DataSource = dtbMin
                ddlMinute.DataTextField = "timemin_value"
                ddlMinute.DataValueField = "timemin_id"
                ddlMinute.DataBind()

                Dim dtbScreen As DataTable = Screen.SelectActiveData(GetTheaterId())
                ddlScreen.DataSource = dtbScreen
                ddlScreen.DataTextField = "theatersub_name"
                ddlScreen.DataValueField = "theatersub_id"
                ddlScreen.DataBind()

                lblAction.Text = "เพิ่มรายการ"
                btnCancelEdit.Visible = False
                pnlCompRevenueType.Visible = False
                pnlOwner.Visible = True
                pnlDetail.Visible = True
                pnlSummayOwner.Visible = True
                pnlSummayComp.Visible = False
                pnlCompetitorPreData.Visible = False
                pnlDetailCompetitor.Visible = False
            Else
                pnlCompRevenueType.Visible = True
                pnlOwner.Visible = False
                pnlSummayOwner.Visible = False
                pnlSummayComp.Visible = True
                Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId, GetRedirectUrl(PageName.MovieList)), Int32)
                Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(Nothing, Nothing, Nothing, movieId, RevenueDate, GetTheaterId())
                If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                    ddlCompRevenueType.SelectedValue = 2.ToString()

                    lblAction.Text = "เพิ่มรายการ"
                    btnCancelEdit.Visible = False
                    pnlDetail.Visible = True
                    pnlCompetitorPreData.Visible = False
                Else
                    lblAction.Text = "แก้ไขยอดรวม"
                    btnCancelEdit.Visible = False 'ไม่แสดง ถ้าเป็น Comp เบื้องต้น
                    pnlDetail.Visible = False
                    pnlCompetitorPreData.Visible = True
                End If
            End If

            Dim revenueIdStr As String = GetRequest(ParamList.RevenueId)
            Dim revenueCompHeaderIdStr As String = GetRequest(ParamList.RevenueCompHeaderId)
            If String.IsNullOrEmpty(revenueIdStr) AndAlso String.IsNullOrEmpty(revenueCompHeaderIdStr) Then
                ShowData()
                Return
            End If

            If Not String.IsNullOrEmpty(revenueCompHeaderIdStr) Then
                Dim revenueCompHeaderId As Int32 = CType(revenueCompHeaderIdStr, Int32)
                Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(revenueCompHeaderId, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                    Dim dr As DataRow = dtbCompHeader.Rows(0)
                    RevenueDate = CDate(dr("revenue_date"))
                End If
                ShowData()
                Return
            End If

            Dim revenueId As Int32 = CType(revenueIdStr, Int32)

            lblAction.Text = "แก้ไขรายการ"
            btnCancelEdit.Visible = True
            If movieTypeId = 1 Then
                Dim dtbOwner As DataTable = RevenueOwner.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                    Dim dr As DataRow = dtbOwner.Rows(0)
                    RevenueDate = CDate(dr("revenue_date"))

                    ddlScreen.Text = dr("theatersub_name").ToString()
                    ddlHour.SelectedValue = CType(dr("timehour_id"), String)
                    ddlMinute.SelectedValue = CType(dr("timemin_id"), String)
                    ddlType.Text = dr("revenue_type").ToString()

                    ddlStatus.SelectedValue = dr("status_id").ToString()
                    ddlFilmTypeSound.SelectedValue = dr("film_type_sound_id").ToString()
                    txtRevenue.Text = dr("revenue_amount_no_cap").ToString()
                    txtViewer.Text = dr("revenue_adms_with_free_ticket").ToString()
                End If
            Else
                Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                    Dim dr As DataRow = dtbCompDetail.Rows(0)
                    RevenueDate = CDate(dr("revenue_date"))

                    ddlCompRevenueType.SelectedValue = 2.ToString()
                    pnlDetail.Visible = True
                    pnlCompetitorPreData.Visible = False
                    txtCountScreen.Text = dr("count_screen").ToString()
                    txtCountSession.Text = dr("count_session").ToString()

                    ddlStatus.SelectedValue = dr("status_id").ToString()
                    ddlFilmTypeSound.SelectedValue = dr("film_type_sound_id").ToString()
                    txtRevenue.Text = dr("amount").ToString()
                    txtViewer.Text = dr("adms").ToString()
                End If
            End If

            ShowData()
        End Sub
#End Region

#Region "Methods"
        Private Shared Function CheckAmountPerViewer(ByVal revenueAmount As Double, ByVal viewer As Int32) As Boolean
            If viewer <= 0 Then
                Return True
            End If
            Dim ratio As Double = revenueAmount / viewer
            Return (ratio > 20 AndAlso ratio < 801) OrElse (CInt(revenueAmount) = 0 AndAlso CInt(viewer) = 0)
        End Function
        Private Shared Function SummaryDatatable(ByVal dtb As DataTable, ByVal groupBy() As String, ByVal aggregate() As String, ByVal summaryName() As String) As DataTable
            Dim retVal As New DataTable
            If IsNothing(groupBy) Then
                Dim minCol As Int32 = Math.Min(aggregate.Length, summaryName.Length)
                For i As Int32 = 0 To minCol - 1
                    retVal.Columns.Add(summaryName(i), dtb.Columns(aggregate(i)).DataType)
                Next
                Dim sum(minCol) As Double
                For Each dr As DataRow In dtb.Rows
                    For i As Int32 = 0 To minCol - 1
                        sum(i) = sum(i) + CDbl(dr(aggregate(i)))
                    Next
                Next
                Dim drSum As DataRow = retVal.NewRow()
                For i As Int32 = 0 To minCol - 1
                    drSum(summaryName(i)) = sum(i)
                Next
                retVal.Rows.Add(drSum)
            Else
                For Each s As String In groupBy
                    retVal.Columns.Add(s, dtb.Columns(s).DataType)
                Next
                Dim minCol As Int32 = Math.Min(aggregate.Length, summaryName.Length)
                For i As Int32 = 0 To minCol - 1
                    retVal.Columns.Add(summaryName(i), dtb.Columns(aggregate(i)).DataType)
                Next
                For Each dr As DataRow In dtb.Rows
                    Dim update As Boolean = False
                    For Each drSum As DataRow In retVal.Rows
                        Dim sameKey As Boolean = True
                        For Each s As String In groupBy
                            If dr(s).ToString() <> drSum(s).ToString() Then
                                sameKey = False
                                Exit For
                            End If
                        Next
                        If sameKey Then
                            update = True
                            For i As Int32 = 0 To minCol - 1
                                drSum(summaryName(i)) = CDbl(drSum(summaryName(i))) + CDbl(dr(aggregate(i)))
                            Next
                            Exit For
                        End If
                    Next
                    If Not update Then
                        Dim drSum As DataRow = retVal.NewRow()
                        For Each s As String In groupBy
                            drSum(s) = dr(s)
                        Next
                        For i As Int32 = 0 To minCol - 1
                            drSum(summaryName(i)) = CDbl(dr(aggregate(i)))
                        Next
                        retVal.Rows.Add(drSum)
                    End If
                Next
            End If
            Return retVal
        End Function
        Private Function SendRevenue() As Boolean
            Dim revenueId As Int32?
            Try
                revenueId = CInt(GetRequest(ParamList.RevenueId))
            Catch ex As Exception
                revenueId = Nothing
            End Try

            Dim movieId As Int32 = CInt(GetRequest(ParamList.MovieId))
            Dim movieTypeId As Int32 = CInt(GetRequest(ParamList.MovieTypeId))

            Dim theaterId As Int32 = GetTheaterId()
            Dim userId As String = GetUserId()

            lblErrorDuplicate.Visible = False
            lblErrorRevenue.Visible = False
            lblErrorHaveDetail.Visible = False

            If movieTypeId = 1 Then
                Dim statusId As Int32 = CInt(ddlStatus.SelectedItem.Value)
                Dim filmTypeSoundId As Int32 = CInt(ddlFilmTypeSound.SelectedItem.Value)
                Dim screenId As Int32 = CInt(ddlScreen.SelectedItem.Value)
                Dim sessionTime As String = ddlHour.SelectedItem.Text & ":" & ddlMinute.SelectedItem.Text
                Dim viewerWithFreeTicket As Int32 = txtViewer.GetInt32()
                Dim revenueAmountNoCap As Double = txtRevenue.GetDouble()

                Dim hourOrder As Int32 = CInt(ddlHour.SelectedItem.Value)
                Dim minOrder As Int32 = CInt(ddlMinute.SelectedItem.Value)

                If IsNothing(revenueId) OrElse revenueId = 0 Then
                    Dim dtbOwner As DataTable = RevenueOwner.SelectData(Nothing, movieId, RevenueDate, theaterId, screenId, sessionTime, Nothing, Nothing)
                    If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                        lblErrorDuplicate.Visible = True
                        Return False
                        'revenueId = CInt(dtbRevenueOwner.Rows(0)("revenueid"))
                        'Dim dtbFreeTicketAndPerCapHeader As DataTable = FreeTicketAndPerCapRevenueHeader.SelectData(revenueId.Value)
                        'If Not IsNothing(revenueId) AndAlso dtbFreeTicketAndPerCapHeader.Rows.Count > 0 Then
                        '    revenueAmountNoCap = CType(dtbFreeTicketAndPerCapHeader.Rows(0)("free_ticket_revenue_sum"), Double)
                        'End If
                        'If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                        '    lblErrorRevenue.Visible = True
                        '    Return False
                        'End If
                        'RevenueOwner.Update(revenueId.Value, movieId, RevenueDate, theaterId, screenId, sessionTime, statusId, filmTypeSoundId, ddlType.Text, viewer, revenueAmount, revenueAmountNoCap, userId)
                    Else
                        If Not CheckAmountPerViewer(revenueAmountNoCap, viewerWithFreeTicket) Then
                            lblErrorRevenue.Visible = True
                            Return False
                        End If
                        RevenueOwner.Insert(movieId, RevenueDate, theaterId, screenId, sessionTime, statusId, filmTypeSoundId, ddlType.Text, viewerWithFreeTicket, revenueAmountNoCap, userId, hourOrder, minOrder)
                    End If
                Else
                    Dim dtbOwner As DataTable = RevenueOwner.SelectData(Nothing, movieId, RevenueDate, theaterId, screenId, sessionTime, Nothing, Nothing)
                    If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                        If CInt(dtbOwner.Rows(0)("revenueid")) <> revenueId.Value Then
                            lblErrorDuplicate.Visible = True
                            Return False
                        End If
                    End If
                    Dim sumRevenueFreeCap As Double = 0
                    Dim countFree As Int32 = 0
                    Dim dtbCheckingFreeTicketAndCap As DataTable = FreeTicketAndPerCapRevenueHeader.SelectCheckRevenue(revenueId.Value)
                    If Not IsNothing(dtbCheckingFreeTicketAndCap) AndAlso dtbCheckingFreeTicketAndCap.Rows.Count > 0 Then
                        Dim drDetail As DataRow = dtbCheckingFreeTicketAndCap.Rows(0)
                        sumRevenueFreeCap = CType(drDetail("sum_revenue_free_cap"), Double)
                        countFree = CType(drDetail("free_ticket_norm_count"), Int32) + CType(drDetail("free_ticket_special_count"), Int32)
                    End If
                    Dim actualRevenueAmount As Double = revenueAmountNoCap + sumRevenueFreeCap
                    Dim actualViewer As Int32 = viewerWithFreeTicket - countFree

                    If Not CheckAmountPerViewer(actualRevenueAmount, actualViewer) Then
                        lblErrorRevenue.Visible = True
                        Return False
                    End If
                    RevenueOwner.Update(revenueId.Value, movieId, RevenueDate, theaterId, screenId, sessionTime, statusId, filmTypeSoundId, ddlType.Text, actualViewer, actualRevenueAmount, viewerWithFreeTicket, revenueAmountNoCap, userId, hourOrder, minOrder)
                End If
            Else
                Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, movieId, RevenueDate, theaterId, Nothing, Nothing)
                If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                    Dim revenueCompHeaderId As Int32 = CInt(dtbCompHeader.Rows(0)("revenue_comp_header_id"))
                    Dim headerStatusId As Int32 = CInt(dtbCompHeader.Rows(0)("status_id"))

                    If Not IsNothing(revenueId) AndAlso revenueId <> 0 Then
                        If Not UpdateExist(dtbCompHeader, revenueId.Value) Then
                            Return False
                        End If
                    Else
                        Dim preData As Boolean = (CInt(ddlCompRevenueType.SelectedItem.Value) = 3)
                        If preData Then
                            'แก้ให้ดูที่ Detail ก่อน ถ้ามีจะแสดง Error
                            Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, Nothing, Nothing, Nothing, Nothing)
                            If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                                lblErrorHaveDetail.Visible = True
                                Return False
                            Else
                                Dim countScreen As Int32 = txtAllScreen.GetInt32()
                                Dim countSession As Int32 = txtAllSession.GetInt32()
                                Dim viewer As Int32 = txtAllViewer.GetInt32()
                                Dim revenueAmount As Double = txtAllRevenue.GetDouble()

                                'SumCompDetail(dtbCompHeader, False)
                                RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, viewer, revenueAmount, headerStatusId, userId)
                            End If
                        Else
                            Dim countScreen As Int32 = txtCountScreen.GetInt32()
                            Dim countSession As Int32 = txtCountSession.GetInt32()
                            Dim viewer As Int32 = txtViewer.GetInt32()
                            Dim revenueAmount As Double = txtRevenue.GetDouble()
                            Dim statusId As Int32 = CInt(ddlStatus.SelectedItem.Value)
                            Dim filmTypeSoundId As Int32 = CInt(ddlFilmTypeSound.SelectedItem.Value)

                            Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, filmTypeSoundId, Nothing, Nothing, Nothing)
                            If IsNothing(dtbCompDetail) OrElse dtbCompDetail.Rows.Count = 0 Then
                                If headerStatusId = 1 Then
                                    'If statusId = 2 Then
                                    '    statusId = 1
                                    'End If
                                    If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                                        lblErrorRevenue.Visible = True
                                        Return False
                                    End If
                                    RevenueCompDetail.Insert(revenueCompHeaderId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, 1, userId)
                                    SumCompDetail(dtbCompHeader)
                                Else
                                    If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                                        lblErrorRevenue.Visible = True
                                        Return False
                                    End If
                                    RevenueCompDetail.Insert(revenueCompHeaderId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                                    SumCompDetail(dtbCompHeader)
                                    'Dim allComplete As Boolean = CType(retObj(1), Boolean)
                                    'If allComplete Then
                                    '    statusId = 2
                                    'Else
                                    '    statusId = 3
                                    'End If
                                End If
                                'countScreen = lblSumCompScreen.GetInt32()
                                'countSession = lblSumCompSession.GetInt32()
                                'viewer = lblSumCompViewer.GetInt32()
                                'revenueAmount = lblSumCompRevenue.GetDouble()
                                'RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                            Else
                                lblErrorDuplicate.Visible = True
                                Return False
                                'revenueId = CInt(dtbCompDetail.Rows(0)("revenue_id"))
                                'If Not UpdateExist(dtbCompHeader, revenueId.Value) Then
                                '    Return False
                                'End If
                            End If
                        End If
                    End If
                Else
                    Dim preData As Boolean = (CInt(ddlCompRevenueType.SelectedItem.Value) = 3)
                    If preData Then
                        Dim countScreen As Int32 = txtAllScreen.GetInt32()
                        Dim countSession As Int32 = txtAllSession.GetInt32()
                        Dim viewer As Int32 = txtAllViewer.GetInt32()
                        Dim revenueAmount As Double = txtAllRevenue.GetDouble()
                        If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                            lblErrorRevenue.Visible = True
                            Return False
                        End If
                        RevenueCompHeader.Insert(movieId, RevenueDate, theaterId, countScreen, countSession, viewer, revenueAmount, 3, userId)
                    Else
                        Dim countScreen As Int32 = txtCountScreen.GetInt32()
                        Dim countSession As Int32 = txtCountSession.GetInt32()
                        Dim viewer As Int32 = txtViewer.GetInt32()
                        Dim revenueAmount As Double = txtRevenue.GetDouble()
                        Dim statusId As Int32 = CInt(ddlStatus.SelectedItem.Value)
                        If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                            lblErrorRevenue.Visible = True
                            Return False
                        End If
                        RevenueCompHeader.Insert(movieId, RevenueDate, theaterId, countScreen, countSession, viewer, revenueAmount, statusId, userId)

                        dtbCompHeader = RevenueCompHeader.SelectData(Nothing, movieId, RevenueDate, theaterId, Nothing, Nothing)
                        Dim revenueCompHeaderId As Int32 = CInt(dtbCompHeader.Rows(0)("revenue_comp_header_id"))
                        Dim filmTypeSoundId As Int32 = CInt(ddlFilmTypeSound.SelectedItem.Value)

                        RevenueCompDetail.Insert(revenueCompHeaderId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                    End If
                End If
            End If
            Return True
        End Function
        Private Function SumCompDetail(ByVal dtbCompHeader As DataTable) As Object()
            Dim dtbCompDetail As DataTable = Nothing
            Dim allComplete As Boolean = False
            'btnDeleteHeader.Visible = True
            If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                pnlSummayComp.Visible = True
                Dim dr As DataRow = dtbCompHeader.Rows(0)
                lblSumCompScreen.Text = String.Format("{0:#,##0}", dr("all_screen"))
                lblSumCompSession.Text = String.Format("{0:#,##0}", dr("all_session"))
                lblSumCompViewer.Text = String.Format("{0:#,##0}", dr("all_adms"))
                lblSumCompRevenue.Text = String.Format("{0:#,##0}", dr("all_amount"))

                Dim revenueCompHeaderId As Int32 = CInt(dtbCompHeader.Rows(0)("revenue_comp_header_id"))
                dtbCompDetail = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                    'btnDeleteHeader.Visible = False
                    Dim fromPage As PageName
                    Try
                        fromPage = CType(GetRequest(ParamList.SendFrom), PageName)
                    Catch ex As Exception
                        fromPage = PageName.MovieList
                    End Try

                    Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
                    Dim movieName As String = GetRequest(ParamList.MovieName)
                    Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId), Int32)

                    Dim countViewer As Int32 = 0
                    Dim sumRevenue As Double = 0
                    Dim countScreen As Int32 = 0
                    Dim countSession As Int32 = 0

                    dtbCompDetail.Columns.Add("LinkTo", GetType(String))
                    allComplete = True
                    For i As Integer = 0 To dtbCompDetail.Rows.Count - 1
                        dr = dtbCompDetail.Rows(i)
                        Dim revenueId As Int32 = CInt(dr("revenue_id"))

                        Dim param As String = GetParamString(fromPage, movieName, movieId, movieTypeId, revenueId, Nothing)

                        dr("LinkTo") = GetRedirectUrl(PageName.SendRevenue, param)

                        countViewer += CInt(dr("adms"))
                        sumRevenue += CDbl(dr("amount"))
                        countScreen += CInt(dr("count_screen"))
                        countSession += CInt(dr("count_session"))

                        Dim notComplete As Boolean = (CInt(dr("status_id")) = 3)
                        If notComplete Then
                            allComplete = False
                        End If
                    Next
                    'If setMax Then
                    '    countViewer = Math.Max(countViewer, CType(lblSumCompViewer.Text, Int32))
                    '    sumRevenue = Math.Max(sumRevenue, CType(lblSumCompRevenue.Text, Double))
                    '    countScreen = Math.Max(countScreen, CType(lblSumCompScreen.Text, Int32))
                    '    countSession = Math.Max(countSession, CType(lblSumCompSession.Text, Int32))
                    'End If

                    lblSumCompScreen.Text = String.Format("{0:#,##0}", countScreen)
                    lblSumCompSession.Text = String.Format("{0:#,##0}", countSession)
                    lblSumCompViewer.Text = String.Format("{0:#,##0}", countViewer)
                    lblSumCompRevenue.Text = String.Format("{0:#,##0}", sumRevenue)
                End If
            End If
            Return New Object() {dtbCompDetail, allComplete}
        End Function
        Private Function UpdateExist(ByVal dtbCompHeader As DataTable, ByVal revenueId As Int32) As Boolean
            Dim revenueCompHeaderId As Int32 = CInt(dtbCompHeader.Rows(0)("revenue_comp_header_id"))
            Dim headerStatusId As Int32 = CInt(dtbCompHeader.Rows(0)("status_id"))

            Dim movieId As Int32 = CInt(GetRequest(ParamList.MovieId))
            Dim theaterId As Int32 = GetTheaterId()
            Dim userId As String = GetUserId()

            Dim countScreen As Int32 = txtCountScreen.GetInt32()
            Dim countSession As Int32 = txtCountSession.GetInt32()
            Dim viewer As Int32 = txtViewer.GetInt32()
            Dim revenueAmount As Double = txtRevenue.GetDouble()
            Dim statusId As Int32 = CInt(ddlStatus.SelectedItem.Value)
            Dim filmTypeSoundId As Int32 = CInt(ddlFilmTypeSound.SelectedItem.Value)

            Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, filmTypeSoundId, movieId, RevenueDate, theaterId)
            If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                If CInt(dtbCompDetail.Rows(0)("revenue_id")) <> revenueId Then
                    lblErrorDuplicate.Visible = True
                    Return False
                End If
            End If

            If Not CheckAmountPerViewer(revenueAmount, viewer) Then
                lblErrorRevenue.Visible = True
                Return False
            End If

            'Start Update
            If headerStatusId = 1 Then
                If statusId = 2 Then
                    statusId = headerStatusId
                End If
                RevenueCompDetail.Update(revenueId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                SumCompDetail(dtbCompHeader)
            Else
                RevenueCompDetail.Update(revenueId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                SumCompDetail(dtbCompHeader)
                'Dim allComplete As Boolean = CType(retObj(1), Boolean)
                'If allComplete Then
                '    statusId = 2
                'Else
                '    statusId = 3
                'End If
            End If

            'countScreen = lblSumCompScreen.GetInt32()
            'countSession = lblSumCompSession.GetInt32()
            'viewer = lblSumCompViewer.GetInt32()
            'revenueAmount = lblSumCompRevenue.GetDouble()
            'RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
            'End update

            Return True
        End Function

        Private Sub ShowData()
            Dim fromPage As PageName
            Try
                fromPage = CType(GetRequest(ParamList.SendFrom), PageName)
            Catch ex As Exception
                fromPage = PageName.MovieList
            End Try

            Dim movieId As Int32 = CType(GetRequest(ParamList.MovieId), Int32)
            Dim movieName As String = GetRequest(ParamList.MovieName)
            Dim movieTypeId As Int32 = CType(GetRequest(ParamList.MovieTypeId), Int32)

            Dim theaterId As Int32 = GetTheaterId()

            'Dim sumViewer As Int32 = 0
            'Dim sumRevenue As Double = 0
            If movieTypeId = 1 Then
                lblSumScreenFilm.Visible = False
                lblSumOwnerAll.Visible = False
                Dim dtbOwner As DataTable = RevenueOwner.SelectData(Nothing, movieId, RevenueDate, theaterId, Nothing, Nothing, Nothing, Nothing)
                pnlSummayOwner.Visible = False
                Dim dtbOwnerScreenFilm As DataTable = Nothing
                Dim dtbOwnerOverAll As DataTable = Nothing

                If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                    lblSumScreenFilm.Visible = True
                    lblSumOwnerAll.Visible = True

                    pnlSummayOwner.Visible = True
                    dtbOwner.Columns.Add("LinkTo", GetType(String))
                    dtbOwner.Columns.Add("LinkToFreeTicket", GetType(String))
                    dtbOwner.Columns.Add("LinkToTicketType", GetType(String))
                    dtbOwner.Columns.Add("SumRevenueFreeTicketAndCap", GetType(Double))
                    dtbOwner.Columns.Add("CountTicketType", GetType(String))
                    dtbOwner.Columns.Add("ErrorFreeTicketAndCap", GetType(String))
                    dtbOwner.Columns.Add("ErrorTicketType", GetType(String))
                    dtbOwner.Columns.Add("ActualViewer", GetType(Int32))
                    For i As Integer = 0 To dtbOwner.Rows.Count - 1
                        Dim dr As DataRow = dtbOwner.Rows(i)
                        Dim revenueId As Int32 = CInt(dr("revenueid"))

                        Dim param As String = GetParamString(fromPage, movieName, movieId, movieTypeId, revenueId, Nothing)

                        dr("LinkTo") = GetRedirectUrl(PageName.SendRevenue, param)
                        dr("LinkToFreeTicket") = GetRedirectUrl(PageName.SendFreeTicketAndPerCap, param)
                        dr("LinkToTicketType") = GetRedirectUrl(PageName.SendTicketType, param)

                        'sumViewer += CInt(dr("revenue_adms_with_free_ticket"))
                        'sumRevenue += CDbl(dr("revenue_amount_no_cap"))

                        dr("ErrorFreeTicketAndCap") = "N"
                        Dim dtbCheckingFreeTicketAndCap As DataTable = FreeTicketAndPerCapRevenueHeader.SelectCheckRevenue(revenueId)
                        If Not IsNothing(dtbCheckingFreeTicketAndCap) AndAlso dtbCheckingFreeTicketAndCap.Rows.Count > 0 Then
                            Dim drDetail As DataRow = dtbCheckingFreeTicketAndCap.Rows(0)
                            Dim sumRevenueFreeCap As Double = CDbl(drDetail("sum_revenue_free_cap"))
                            'If CInt(drDetail("sum_complete")) = 1 AndAlso CInt(drDetail("count_complete")) = 1 Then
                            If CInt(drDetail("sum_complete")) = 1 Then
                            Else
                                dr("ErrorFreeTicketAndCap") = "Y"
                            End If
                            dr("SumRevenueFreeTicketAndCap") = sumRevenueFreeCap
                        End If

                        dr("ErrorTicketType") = "N"
                        Dim dtbTicketTypeHeader As DataTable = TicketTypeRevenueHeader.SelectData(revenueId)
                        If Not IsNothing(dtbTicketTypeHeader) AndAlso dtbTicketTypeHeader.Rows.Count > 0 Then
                            Dim drHeader As DataRow = dtbTicketTypeHeader.Rows(0)
                            'If CInt(drHeader("incomplete")) = 1 Then
                            '    dr("ErrorTicketType") = "Y"
                            'End If
                            dr("CountTicketType") = drHeader("ticket_type_count")
                        Else
                            dr("CountTicketType") = 0
                        End If
                    Next
                    dtbOwnerScreenFilm = SummaryDatatable(dtbOwner, New String() {"theatersub_id", "film_type_sound_header_group"}, New String() {"revenue_amount_no_cap", "SumRevenueFreeTicketAndCap", "revenue_amount", "revenue_adms_with_free_ticket", "revenue_adms"}, New String() {"SumRevenueReport", "SumTicketRevenue", "ActualRevenue", "SumViewerReport", "ActualViewer"})
                    dtbOwnerOverAll = SummaryDatatable(dtbOwnerScreenFilm, Nothing, New String() {"SumRevenueReport", "SumTicketRevenue", "ActualRevenue", "SumViewerReport", "ActualViewer"}, New String() {"SumRevenueReport", "SumTicketRevenue", "ActualRevenue", "SumViewerReport", "ActualViewer"})
                End If
                grdOwner.DataSource = dtbOwner
                grdOwner.DataBind()
                grdOwnerScreenFilm.DataSource = dtbOwnerScreenFilm
                grdOwnerScreenFilm.DataBind()
                grdOwnerAll.DataSource = dtbOwnerOverAll
                grdOwnerAll.DataBind()
            Else
                pnlSummayComp.Visible = False
                Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, movieId, RevenueDate, theaterId, Nothing, Nothing)
                Dim retObj() As Object = SumCompDetail(dtbCompHeader)
                Dim dtbDetail As DataTable = CType(retObj(0), DataTable)
                btnDeleteHeader.Visible = True
                If Not IsNothing(dtbDetail) AndAlso dtbDetail.Rows.Count > 0 Then
                    btnDeleteHeader.Visible = False
                End If

                If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                    Dim allComplete As Boolean = CType(retObj(1), Boolean)
                    If Not allComplete Then
                    End If
                End If

                grdCompetitor.DataSource = dtbDetail
                grdCompetitor.DataBind()

                'Dim preData As Boolean = (CInt(ddlCompRevenueType.SelectedItem.Value) = 3)
                'If preData Then
                '    txtAllScreen.Text = If0ThenEmpty(lblSumCompScreen.Text)
                '    txtAllSession.Text = If0ThenEmpty(lblSumCompSession.Text)
                '    txtAllViewer.Text = If0ThenEmpty(lblSumCompViewer.Text)
                '    txtAllRevenue.Text = If0ThenEmpty(lblSumCompRevenue.Text)
                'End If
            End If
            Return
        End Sub
#End Region

    End Class
End Namespace