Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class Trailer
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
        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            ClearData(True)
        End Sub
        Protected Sub BtnMainMenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMainMenu.Click
            Redirect(PageName.ActionMenu)
        End Sub
        Protected Sub BtnSaveDetailClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveDetail.Click
            lblErrorNotSelectAnyMovie.Visible = False
            lblErrorDataExist.Visible = False
            lblErrorSelectDuplicate.Visible = False
            lblErrorCollection.Visible = False

            If String.IsNullOrEmpty(TrailerCollectionFinder1.CollectionName) Then
                TrailerCollectionFinder1.CollectionNo = String.Empty
                'lblErrorCollection.Visible = True
            End If
            Try
                Dim list As New List(Of Int32)
                If Not IsNothing(MovieFinder1.MovieId) Then
                    list.Add(MovieFinder1.MovieId.Value)
                End If
                If Not IsNothing(MovieFinder2.MovieId) Then
                    list.Add(MovieFinder2.MovieId.Value)
                End If
                If Not IsNothing(MovieFinder3.MovieId) Then
                    list.Add(MovieFinder3.MovieId.Value)
                End If
                If Not IsNothing(MovieFinder4.MovieId) Then
                    list.Add(MovieFinder4.MovieId.Value)
                End If

                If list.Count = 0 Then
                    lblErrorNotSelectAnyMovie.Visible = True
                    Return
                End If

                For i As Integer = 0 To list.Count
                    For j As Integer = i + 1 To list.Count
                        If j < list.Count Then
                            If list(i) = list(j) Then
                                lblErrorSelectDuplicate.Visible = True
                                Return
                            End If
                        End If
                    Next
                Next

                If TrailerCollectionFinder1.DataNotFound Then
                    Return
                End If

                If String.IsNullOrEmpty(hdfTrailerNo.Value) Then
                    'Insert

                    For Each dtb In From i In list Select MovieAndTrailer.GetTrailerMaster(Nothing, GetCircuitId(), GetTheaterId(), CType(ddlScreen.SelectedValue, Int32), i, Nothing, Nothing)
                        If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                            lblErrorDataExist.Visible = True
                            Return
                        End If
                    Next

                    For Each movieId As Int32 In list
                        Dim newKey As Int32? = MovieAndTrailer.GetMaxTrailerNo(GetCircuitId(), GetTheaterId(), CType(ddlScreen.SelectedValue, Int32))
                        If IsNothing(newKey) Then
                            newKey = 1
                        Else
                            newKey += 1
                        End If
                        Dim newTrailerNo = Convert.ToString(Date.Now.Year).Substring(2, 2) + GetCircuitId().ToString("00") + GetTheaterId().ToString("000") + CType(ddlScreen.SelectedValue, Int32).ToString("00") + newKey.Value.ToString("0000")

                        MovieAndTrailer.InsertTrailerMaster(newTrailerNo, GetCircuitId(), GetTheaterId(), CType(ddlScreen.SelectedValue, Int32), movieId, TrailerCollectionFinder1.CollectionNo, "Y", "Y", GetUserId())
                    Next
                Else
                    'Update

                    For Each movieId As Int32 In list
                        MovieAndTrailer.UpdateTrailerMaster(hdfTrailerNo.Value, GetCircuitId(), GetTheaterId(), CType(ddlScreen.SelectedValue, Int32), movieId, TrailerCollectionFinder1.CollectionNo, "Y", GetUserId())
                    Next
                End If

                ClearData(True)
            Catch ex As Exception
                lblErrorDataExist.Visible = True
                lblErrorSelectDuplicate.Text = ex.Message
            End Try
        End Sub
        Protected Sub DdlScreenSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlScreen.SelectedIndexChanged
            If (ddlScreen.Items.Count > 0) Then
                TrailerCollectionFinder1.CollectionName = ddlScreen.SelectedValue
                EnableMovieList(Nothing)
            End If
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            Dim trailerNo = Convert.ToString(e.CommandArgument)
            If e.CommandName = "Select" Then
                Dim dtb As DataTable = MovieAndTrailer.GetTrailerMaster(trailerNo, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr = dtb.Rows(0)
                    ddlScreen.SelectedValue = dr("theatersub_id").ToString()
                    MovieFinder1.MovieId = CType(dr("real_movie_id"), Int32?)
                    TrailerCollectionFinder1.CollectionNo = dr("collection_no").ToString()
                    EnableMovieList(False)
                    hdfTrailerNo.Value = dr("trailer_no").ToString()

                    ddlScreen.Enabled = False
                End If
            ElseIf e.CommandName = "Del" Then
                MovieAndTrailer.DeleteTrailerMaster(trailerNo)
                ShowData()
            ElseIf e.CommandName = "Confirm" Then
                MovieAndTrailer.UpdateConfirmFlagTrailerMaster(trailerNo, "Y", GetUserId())
                ShowData()
            End If
        End Sub
        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If
            Dim objMovieName = DataBinder.Eval(e.Row.DataItem, "MovieName")
            If Not IsNothing(objMovieName) AndAlso Not String.IsNullOrEmpty(objMovieName.ToString()) Then
                Dim ctl = e.Row.Cells(2).FindControl("btnSelect")
                If Not IsNothing(ctl) Then
                    Dim btn = CType(ctl, LinkButton)
                    Dim name = Convert.ToString(objMovieName.ToString())
                    If name.Length > 10 Then
                        name = name.Substring(0, 10)
                    End If
                    btn.Text = name
                End If
            End If

            Dim objCollectionName = DataBinder.Eval(e.Row.DataItem, "collection_name")
            If Not IsNothing(objCollectionName) AndAlso Not String.IsNullOrEmpty(objCollectionName.ToString()) Then
                Dim ctl = e.Row.Cells(3).FindControl("lblcollection_name")
                If Not IsNothing(ctl) Then
                    Dim lbl = CType(ctl, Label)
                    Const COL_CHAR_WIDTH As Integer = 52
                    Dim name = Convert.ToString(objCollectionName.ToString()) + " (" + DataBinder.Eval(e.Row.DataItem, "MovieCollection").ToString()
                    If name.Length > COL_CHAR_WIDTH - 1 Then
                        name = name.Substring(0, COL_CHAR_WIDTH - 1) + ")"
                    Else
                        name = name + ")"
                    End If
                    lbl.Text = name
                End If
            End If
        End Sub
        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerMaster(Nothing, GetCircuitId(), GetTheaterId(), CType(ddlScreen.SelectedValue, Int32), Nothing, Nothing, "tm.theatersub_id, h.collection_name ")
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            lblErrorDataExist.Visible = False
            lblErrorNotSelectAnyMovie.Visible = False
            lblErrorSelectDuplicate.Visible = False
            lblErrorCollection.Visible = False

            ClearData(False)
            ddlScreen.Items.Clear()
            Dim dtb As DataTable = Screen.SelectActiveData(GetTheaterId())
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                ddlScreen.DataTextField = "theatersub_name"
                ddlScreen.DataValueField = "theatersub_id"
                ddlScreen.DataSource = dtb
                ddlScreen.DataBind()
                TrailerCollectionFinder1.CollectionName = ddlScreen.SelectedValue
                EnableMovieList(Nothing)
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub ClearData(ByVal nextScreen As Boolean)
            If nextScreen Then
                Try
                    If (ddlScreen.SelectedIndex < ddlScreen.Items.Count - 1) Then
                        ddlScreen.SelectedIndex = ddlScreen.SelectedIndex + 1
                    Else
                        ddlScreen.SelectedIndex = 0
                    End If
                Catch ex As Exception
                End Try
            End If

            TrailerCollectionFinder1.CollectionName = ddlScreen.SelectedValue
            EnableMovieList(Nothing)

            MovieFinder1.MovieId = Nothing
            MovieFinder2.MovieId = Nothing
            MovieFinder3.MovieId = Nothing
            MovieFinder4.MovieId = Nothing

            MovieFinder1.Enabled = True
            ddlScreen.Enabled = True

            ShowData()
        End Sub
        Private Sub EnableMovieList(ByVal fourceEnabled As Boolean?)
            hdfTrailerNo.Value = Nothing

            Dim enabledFinder As Boolean
            If IsNothing(fourceEnabled) Then
                enabledFinder = Not String.IsNullOrEmpty(TrailerCollectionFinder1.CollectionName)
            Else
                enabledFinder = fourceEnabled.Value
            End If

            MovieFinder2.Enabled = enabledFinder
            MovieFinder3.Enabled = enabledFinder
            MovieFinder4.Enabled = enabledFinder
        End Sub
        Private Sub ShowData()
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerMaster(Nothing, GetCircuitId(), GetTheaterId(), Nothing, Nothing, Nothing, "tm.theatersub_id, h.collection_name ")
            grdResult.DataSource = dtb
            grdResult.DataBind()
        End Sub
#End Region

    End Class
End Namespace