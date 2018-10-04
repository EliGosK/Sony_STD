Option Strict On

Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Form
    Partial Public Class SendRevenue
        Inherits Page

        Private Property RevenueDate() As Date
            Get
                Return Utils.ConvertDate(hdfRevenueDate.Value, "dd/MM/yyyy")
            End Get
            Set(ByVal value As Date)
                hdfRevenueDate.Value = String.Format("{0:dd/MM/yyyy}", value).Replace("-", "/")
            End Set
        End Property
        Private ReadOnly Property GetUserId() As String
            Get
                Return hdfUserId.Value
            End Get
        End Property
        Private ReadOnly Property GetTheaterId() As Int32
            Get
                Return CType(hdfTheaterId.Value, Int32)
            End Get
        End Property
        Private ReadOnly Property GetMovieId() As Int32
            Get
                Return CType(hdfMovieId.Value, Int32)
            End Get
        End Property
        Private ReadOnly Property GetMovieTypeId() As Int32
            Get
                Return CType(GetRequest(ParamList.MovieTypeId), Int32)
            End Get
        End Property
        Private ReadOnly Property GetRevenueId() As Int32
            Get
                Return CType(GetRequest(ParamList.RevenueId), Int32)
            End Get
        End Property
        Private ReadOnly Property GetRevenueCompHeaderId() As Int32
            Get
                Return CType(GetRequest(ParamList.RevenueCompHeaderId), Int32)
            End Get
        End Property

#Region "Event Handlers"
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Dim movieTypeId As Int32 = GetMovieTypeId()
            If movieTypeId = 1 Then
                Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen").ToString())
            Else
                'Response.Redirect("frmRevByTheaterComp.aspx?theaterId=" & Session("theaterId").ToString())
                Response.Redirect("frmRevByDateComp.aspx?revDate=" & Session("revDate").ToString())
            End If
        End Sub
        Protected Sub BtnRemoveClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
            Dim movieTypeId As Int32 = GetMovieTypeId()
            Dim revenueId As Int32 = GetRevenueId()
            Dim revenueCompHeaderId As Int32 = GetRevenueCompHeaderId()
            If movieTypeId = 1 Then
                RevenueOwner.Delete(revenueId)
                Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen").ToString())
            Else
                If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId > 0 Then
                    RevenueCompHeader.DeleteAll(revenueCompHeaderId)
                    Response.Redirect("frmRevByDateComp.aspx?revDate=" & Session("revDate").ToString())
                Else
                    RevenueCompDetail.Delete(revenueId, GetUserId())
                    Response.Redirect("frmRevByDateComp.aspx?revDate=" & Session("revDate").ToString())
                End If
            End If
        End Sub
        Protected Sub BtnSendClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
            Dim movieTypeId As Int32 = GetMovieTypeId()
            Dim revenueId As Int32 = GetRevenueId()
            Dim revenueCompHeaderId As Int32 = GetRevenueCompHeaderId()
            If SendRevenue(movieTypeId, revenueId, revenueCompHeaderId) Then
                If movieTypeId = 1 Then
                    Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen").ToString())
                Else
                    If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId > 0 Then
                        Response.Redirect("frmRevByDateComp.aspx?revDate=" & RevenueDate.ToString("yyyyMMdd"))
                    Else
                        Response.Redirect("frmRevByTheaterComp.aspx?theaterId=" & hdfTheaterId.Value)
                    End If
                End If
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

            Dim movieTypeId As Int32 = GetMovieTypeId()
            If movieTypeId = 1 Then
                Dim revenueId As Int32 = GetRevenueId()
                Dim dtbOwner As DataTable = RevenueOwner.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                    Dim dr As DataRow = dtbOwner.Rows(0)
                    RevenueDate = CType(dr("revenue_date"), Date)
                    hdfTheaterId.Value = CType(dr("theater_id"), String)
                    hdfMovieId.Value = CType(dr("movie_id"), String)
                    hdfUserId.Value = CType(dr("user_id"), String)

                    Dim dtbScreen As DataTable = Screen.SelectActiveData(GetTheaterId())
                    ddlScreen.DataSource = dtbScreen
                    ddlScreen.DataTextField = "theatersub_name"
                    ddlScreen.DataValueField = "theatersub_id"
                    ddlScreen.DataBind()

                    Dim dtbFilmTypeSound As DataTable = FilmTypeSound.SelectActiveData(GetTheaterId())
                    ddlFilmTypeSound.DataSource = dtbFilmTypeSound
                    ddlFilmTypeSound.DataTextField = "film_type_sound_name_th"
                    ddlFilmTypeSound.DataValueField = "film_type_sound_id"
                    ddlFilmTypeSound.DataBind()

                    ddlScreen.Text = dr("theatersub_name").ToString()
                    ddlHour.SelectedValue = CType(dr("timehour_id"), String)
                    ddlMinute.SelectedValue = CType(dr("timemin_id"), String)
                    ddlType.Text = dr("revenue_type").ToString()

                    Dim StatusID As String = dr("status_id").ToString()     'added 02/10/2015
                    If StatusID = "1" Then
                        StatusID = "2"
                    End If
                    ddlStatus.SelectedValue = StatusID
                    'ddlStatus.SelectedValue = dr("status_id").ToString()
                    ddlFilmTypeSound.SelectedValue = dr("film_type_sound_id").ToString()
                    txtRevenue.Text = dr("revenue_amount_no_cap").ToString()
                    txtViewer.Text = dr("revenue_adms_with_free_ticket").ToString()

                    pnlOwner.Visible = True
                    pnlDetail.Visible = True

                    pnlCompetitorPreData.Visible = False
                    pnlDetailCompetitor.Visible = False
                End If
            Else
                Dim revenueCompHeaderId As Int32 = GetRevenueCompHeaderId()
                If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId > 0 Then
                    Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(revenueCompHeaderId, Nothing, Nothing, Nothing, Nothing, Nothing)
                    If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                        Dim dr As DataRow = dtbCompHeader.Rows(0)
                        RevenueDate = CType(dr("revenue_date"), Date)
                        hdfTheaterId.Value = CType(dr("theater_id"), String)
                        hdfMovieId.Value = CType(dr("movie_id"), String)
                        hdfUserId.Value = CType(dr("update_by"), String)

                        pnlDetail.Visible = False
                        pnlCompetitorPreData.Visible = True

                        txtAllScreen.Text = CType(dr("all_screen"), String)
                        txtAllSession.Text = CType(dr("all_session"), String)
                        txtAllViewer.Text = CType(dr("all_adms"), String)
                        txtAllRevenue.Text = CType(dr("all_amount"), String)
                    End If
                Else
                    Dim revenueId As Int32 = GetRevenueId()
                    Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(revenueId, Nothing, Nothing, Nothing, Nothing, Nothing)
                    If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                        Dim dr As DataRow = dtbCompDetail.Rows(0)
                        RevenueDate = CType(dr("revenue_date"), Date)
                        hdfTheaterId.Value = CType(dr("theater_id"), String)
                        hdfMovieId.Value = CType(dr("movie_id"), String)
                        hdfUserId.Value = CType(dr("update_by"), String)

                        Dim dtbFilmTypeSound As DataTable = FilmTypeSound.SelectActiveData(GetTheaterId())
                        ddlFilmTypeSound.DataSource = dtbFilmTypeSound
                        ddlFilmTypeSound.DataTextField = "film_type_sound_name_th"
                        ddlFilmTypeSound.DataValueField = "film_type_sound_id"
                        ddlFilmTypeSound.DataBind()

                        pnlDetail.Visible = True
                        pnlCompetitorPreData.Visible = False

                        txtCountScreen.Text = dr("count_screen").ToString()
                        txtCountSession.Text = dr("count_session").ToString()
                        Dim StatusID As String = dr("status_id").ToString()     'added 02/10/2015
                        If StatusID = "1" Then
                            StatusID = "2"
                        End If
                        ddlStatus.SelectedValue = StatusID
                        'ddlStatus.SelectedValue = dr("status_id").ToString()
                        ddlFilmTypeSound.SelectedValue = dr("film_type_sound_id").ToString()
                        txtRevenue.Text = dr("amount").ToString()
                        txtViewer.Text = dr("adms").ToString()

                        pnlDetail.Visible = True
                        pnlCompetitorPreData.Visible = False
                    End If
                End If
            End If
        End Sub
#End Region

#Region "Methods"
        Private Shared Function CheckAmountPerViewer(ByVal revenueAmount As Double, ByVal viewer As Int32) As Boolean
            Dim ratio As Double = revenueAmount / viewer
            Return (ratio > 20 AndAlso ratio < 801) OrElse CInt(revenueAmount) = 0
        End Function
        Private Function SendRevenue(ByVal movieTypeId As Int32, ByVal revenueId As Int32, ByVal revenueCompHeaderId As Int32) As Boolean
            Dim movieId As Int32 = GetMovieId()
            Dim theaterId As Int32 = GetTheaterId()
            Dim userId As String = GetUserId()

            lblErrorDuplicate.Visible = False
            lblErrorRevenue.Visible = False

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
                Else
                    Dim dtbOwner As DataTable = RevenueOwner.SelectData(Nothing, movieId, RevenueDate, theaterId, screenId, sessionTime, Nothing, Nothing)
                    If Not IsNothing(dtbOwner) AndAlso dtbOwner.Rows.Count > 0 Then
                        If CInt(dtbOwner.Rows(0)("revenueid")) <> revenueId Then
                            lblErrorDuplicate.Visible = True
                            Return False
                        End If
                    End If
                    Dim sumRevenueFreeCap As Double = 0
                    Dim countFree As Int32 = 0
                    Dim dtbCheckingFreeTicketAndCap As DataTable = FreeTicketAndPerCapRevenueHeader.SelectCheckRevenue(revenueId)
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
                    RevenueOwner.Update(revenueId, movieId, RevenueDate, theaterId, screenId, sessionTime, statusId, filmTypeSoundId, ddlType.Text, actualViewer, actualRevenueAmount, viewerWithFreeTicket, revenueAmountNoCap, userId, hourOrder, minOrder)
                End If
            Else
                If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId > 0 Then
                    Dim countScreen As Int32 = txtAllScreen.GetInt32()
                    Dim countSession As Int32 = txtAllSession.GetInt32()
                    Dim viewer As Int32 = txtAllViewer.GetInt32()
                    Dim revenueAmount As Double = txtAllRevenue.GetDouble()
                    RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, viewer, revenueAmount, 3, userId)
                Else
                    Dim filmTypeSoundId As Int32 = CInt(ddlFilmTypeSound.SelectedItem.Value)
                    Dim countScreen As Int32 = txtCountScreen.GetInt32()
                    Dim countSession As Int32 = txtCountSession.GetInt32()
                    Dim viewer As Int32 = txtViewer.GetInt32()
                    Dim revenueAmount As Double = txtRevenue.GetDouble()
                    Dim statusId As Int32 = CInt(ddlStatus.SelectedItem.Value)

                    Dim dtbCompHeader As DataTable = RevenueCompHeader.SelectData(Nothing, movieId, RevenueDate, theaterId, Nothing, Nothing)
                    If Not IsNothing(dtbCompHeader) AndAlso dtbCompHeader.Rows.Count > 0 Then
                        revenueCompHeaderId = CInt(dtbCompHeader.Rows(0)("revenue_comp_header_id"))
                    Else
                        Return False
                    End If

                    Dim headerStatusId As Int32 = CInt(dtbCompHeader.Rows(0)("status_id"))

                    Dim dtbCompDetail As DataTable = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, filmTypeSoundId, movieId, RevenueDate, theaterId)
                    If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                        If CInt(dtbCompDetail.Rows(0)("revenue_id")) <> revenueId Then
                            lblErrorDuplicate.Visible = True
                            Return False
                        End If
                    End If

                    Dim allComplete As Boolean = True
                    If headerStatusId = 1 Then
                        If statusId = 2 Then
                            statusId = headerStatusId
                        End If
                        RevenueCompDetail.Update(revenueId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                    Else
                        RevenueCompDetail.Update(revenueId, filmTypeSoundId, countScreen, countSession, viewer, revenueAmount, statusId, userId)
                    End If

                    'dtbCompDetail = RevenueCompDetail.SelectData(Nothing, revenueCompHeaderId, Nothing, Nothing, Nothing, Nothing)
                    'If Not IsNothing(dtbCompDetail) AndAlso dtbCompDetail.Rows.Count > 0 Then
                    '    Dim countViewer As Int32 = 0
                    '    Dim sumRevenue As Double = 0
                    '    countScreen = 0
                    '    countSession = 0

                    '    For i As Integer = 0 To dtbCompDetail.Rows.Count - 1
                    '        Dim dr As DataRow = dtbCompDetail.Rows(i)
                    '        countViewer += CInt(dr("adms"))
                    '        sumRevenue += CDbl(dr("amount"))
                    '        countScreen += CInt(dr("count_screen"))
                    '        countSession += CInt(dr("count_session"))

                    '        Dim notComplete As Boolean = (CInt(dr("status_id")) = 3)
                    '        If notComplete Then
                    '            allComplete = False
                    '        End If
                    '    Next

                    '    If headerStatusId = 1 Then
                    '        RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, countViewer, sumRevenue, statusId, userId)
                    '    Else
                    '        If allComplete Then
                    '            statusId = 2
                    '        Else
                    '            statusId = 3
                    '        End If
                    '        RevenueCompHeader.Update(revenueCompHeaderId, RevenueDate, movieId, theaterId, countScreen, countSession, countViewer, sumRevenue, statusId, userId)
                    '    End If
                    'End If

                End If
            End If
            Return True
        End Function
#End Region

    End Class
End Namespace