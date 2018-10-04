Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class TrailerCollectionInsert
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
        Protected Sub BtnBackToTrailerCollectionClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnBackToTrailerCollection.Click
            Redirect(PageName.TrailerCollection)
        End Sub
        Protected Sub BtnCancelInsertClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelInsert.Click
            RefreshDetail()
        End Sub
        Protected Sub BtnCancelSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancelSave.Click
            RefreshDetail()
        End Sub
        Protected Sub BtnInsertClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsert.Click
            Dim objSeqNo As Int32? = txtSeqNo.Text.ToInt32()
            Dim seqNo As Int32 = objSeqNo.Value
            If hdfAction.Value = "UPDATE" Then
                Dim selectedSeq As Int32 = CInt(hdfSelectedSeqNo.Value)
                TrailerCollectionDetail.DeleteAndPromoteAfter(hdfCollectionNo.Value, selectedSeq)
            End If
            'Insertion
            Dim setupNo As String = String.Empty
            Dim dtbPeriod As DataTable = MovieAndTrailer.GetTrailerHeaderByPeriodDate(Date.Today, Date.Today, "")
            If Not IsNothing(dtbPeriod) AndAlso dtbPeriod.Rows.Count > 0 Then
                setupNo = dtbPeriod.Rows(0)("Setup_No").ToString()
            End If
            TrailerCollectionDetail.InsertAndDemoteAfter(hdfCollectionNo.Value, seqNo, TrailerFinder1.MovieId.Value, setupNo, GetUserId())
            RefreshDetail()
        End Sub
        Protected Sub BtnInsertMoreClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsertMore.Click
            Redirect(PageName.TrailerCollectionInsert)
        End Sub
        Protected Sub BtnSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            lblErrorDataExist.Visible = False
            lblErrorCompleteTextBox.Visible = False
            If TrailerCollectionFinder1.DataNotFound Then
                Return
            End If

            'If MoviePopup1.MovieId = 0 Then
            '    lblError2.Visible = True
            '    Return
            'End If

            If txtCollectionName.Text.Trim() = String.Empty Then
                lblErrorCompleteTextBox.Visible = True
                Return
            Else
                Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, txtCollectionName.Text.Trim(), GetCircuitId(), GetTheaterId(), True, Nothing)
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    If hdfCollectionNo.Value <> dtb.Rows(0)("collection_no").ToString() Then
                        lblErrorDataExist.Visible = True
                        Return
                    End If
                End If

                If String.IsNullOrEmpty(hdfCollectionNo.Value) Then
                    'Insert

                    Dim newKey As Int32? = MovieAndTrailer.GetMaxTrailerCollectionNo(GetCircuitId(), GetTheaterId())
                    If IsNothing(newKey) Then
                        newKey = 1
                    Else
                        newKey += 1
                    End If

                    Dim newCollectionNo As String = Convert.ToString(Date.Now.Year).Substring(2, 2) + Convert.ToInt32(GetCircuitId()).ToString("00") + Convert.ToInt32(GetTheaterId()).ToString("000") + newKey.Value.ToString("0000")

                    MovieAndTrailer.InsertTrailerCollectionHeader(newCollectionNo, txtCollectionName.Text, GetCircuitId(), GetTheaterId(), GetUserId())

                    CopyCollection(newCollectionNo, TrailerCollectionFinder1.CollectionNo)

                    Response.Redirect("TrailerCollectionInsert.aspx?collection_no=" + newCollectionNo)

                    'hdfCollectionNo.Value = newCollectionNo
                    'BindData(newCollectionNo, Nothing)
                Else
                    MovieAndTrailer.UpdateTrailerCollectionHeader(hdfCollectionNo.Value, txtCollectionName.Text, GetCircuitId(), GetTheaterId(), GetUserId())
                    ShowData(Nothing)
                End If
            End If
        End Sub
        Protected Sub BtnSaveDetailClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveDetail.Click
            lblErrorInvalidSeqNo.Visible = False
            lblErrorNotFoundMovie.Visible = False
            lblErrorMovieExist.Visible = False
            DivInsertMovie.Visible = False

            Dim objSeqNo As Int32? = txtSeqNo.Text.ToInt32()
            If IsNothing(objSeqNo) Then
                lblErrorInvalidSeqNo.Visible = True
                Return
            End If
            If IsNothing(TrailerFinder1.MovieId) Then
                lblErrorNotFoundMovie.Visible = True
                Return
            End If

            Dim objMaxSeqNo As Int32? = MovieAndTrailer.GetMaxSequenceNoOfTrailerCollectionDetail(hdfCollectionNo.Value)
            Dim maxSeqNo As Int32 = 1
            If Not IsNothing(objMaxSeqNo) Then
                maxSeqNo += CInt(objMaxSeqNo)
            End If
            Dim seqNo As Int32 = Math.Min(objSeqNo.Value, maxSeqNo)
            txtSeqNo.Text = CStr(seqNo)
            Try
                If hdfAction.Value = "UPDATE" Then
                    Dim selectedMovieId As Int32 = CInt(hdfSelectedMovieId.Value)
                    If selectedMovieId <> TrailerFinder1.MovieId.Value Then
                        Dim dtb As DataTable = TrailerCollectionDetail.SelectData(hdfCollectionNo.Value, Nothing, TrailerFinder1.MovieId, Nothing)
                        If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                            lblErrorMovieExist.Visible = True
                            Return
                        End If
                        Dim selectedSeq As Int32 = CInt(hdfSelectedSeqNo.Value)
                        TrailerCollectionDetail.DeleteAndPromoteAfter(hdfCollectionNo.Value, selectedSeq)
                    Else
                        DivInsertMovie.Visible = True
                        Return
                    End If
                Else 'INSERT
                    Dim dtb As DataTable = TrailerCollectionDetail.SelectData(hdfCollectionNo.Value, Nothing, TrailerFinder1.MovieId, Nothing)
                    If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                        lblErrorMovieExist.Visible = True
                        Return
                    End If

                    dtb = TrailerCollectionDetail.SelectData(hdfCollectionNo.Value, seqNo, Nothing, Nothing)
                    If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                        DivInsertMovie.Visible = True
                        Return
                    End If
                End If

                'Insertion
                Dim setupNo As String = String.Empty
                Dim dtbPeriod As DataTable = MovieAndTrailer.GetTrailerHeaderByPeriodDate(Date.Today, Date.Today, "")
                If Not IsNothing(dtbPeriod) AndAlso dtbPeriod.Rows.Count > 0 Then
                    setupNo = dtbPeriod.Rows(0)("Setup_No").ToString()
                End If
                TrailerCollectionDetail.InsertAndDemoteAfter(hdfCollectionNo.Value, seqNo, TrailerFinder1.MovieId.Value, setupNo, GetUserId())
                RefreshDetail()
            Catch ex As Exception
                lblErrorAll.Visible = True
            End Try
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            Dim seqNo As Integer = Convert.ToInt32(e.CommandArgument)
            If e.CommandName = "Select" Then
                Dim dtb As DataTable = TrailerCollectionDetail.SelectData(hdfCollectionNo.Value, seqNo, Nothing, Nothing)
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr As DataRow = dtb.Rows(0)
                    Dim movieId As Int32 = CInt(dr("movie_id"))
                    TrailerFinder1.MovieId = movieId
                    txtSeqNo.Text = seqNo.ToString()
                    hdfAction.Value = "UPDATE"
                    hdfSelectedSeqNo.Value = CStr(seqNo)
                    hdfSelectedMovieId.Value = CStr(movieId)
                End If
            ElseIf e.CommandName = "Del" Then
                TrailerCollectionDetail.DeleteAndPromoteAfter(hdfCollectionNo.Value, seqNo)
                RefreshDetail()
            End If
        End Sub
        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            ShowData(e.SortExpression)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            lblErrorCompleteTextBox.Visible = False
            lblErrorNotFoundMovie.Visible = False
            lblErrorDataExist.Visible = False
            lblErrorMovieExist.Visible = False
            lblErrorInvalidSeqNo.Visible = False
            lblErrorAll.Visible = False
            DivInsertMovie.Visible = False

            lblErrorInvalidSeq.Visible = False
            lblErrorSeqExist.Visible = False

            ShowData(Nothing)
            TrailerFinder1.MovieId = 0
            If String.IsNullOrEmpty(hdfCollectionNo.Value) Then
                txtSeqNo.Text = 1.ToString()
            Else
                Dim seqNo As Int32? = MovieAndTrailer.GetMaxSequenceNoOfTrailerCollectionDetail(hdfCollectionNo.Value)
                If IsNothing(seqNo) Then
                    txtSeqNo.Text = 1.ToString()
                Else
                    txtSeqNo.Text = (seqNo.Value + 1).ToString()
                End If
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub BindData(ByVal collectionNo As String, ByVal sortExpression As String)
            If String.IsNullOrEmpty(collectionNo) OrElse String.IsNullOrEmpty(collectionNo.Trim()) Then
                btnSaveDetail.Enabled = False
                ClearData()
            Else
                collectionNo = collectionNo.Trim()

                Dim dtbHd As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(collectionNo, Nothing, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbHd) AndAlso dtbHd.Rows.Count > 0 Then
                    txtCollectionName.Text = dtbHd.Rows(0)("collection_name").ToString()
                    hdfCollectionNo.Value = collectionNo

                    Dim dtb As DataTable = TrailerCollectionDetail.SelectData(collectionNo, Nothing, Nothing, Nothing)
                    If String.IsNullOrEmpty(sortExpression) Then
                        txtSeqNo.Text = (dtb.Rows.Count + 1).ToString
                        grdResult.DataSource = dtb
                        grdResult.DataBind()
                    Else
                        Utils.SortGridView(grdResult, dtb, sortExpression, GridViewSortDirection)
                    End If

                    btnSave.Enabled = False
                    txtCollectionName.Enabled = False
                    TrailerCollectionFinder1.Enabled = False
                End If
                btnSaveDetail.Enabled = True
            End If
        End Sub
        Private Sub ClearData()
            txtCollectionName.Text = String.Empty
            TrailerFinder1.Enabled = True
            TrailerFinder1.MovieId = 0
            txtSeqNo.Text = String.Empty
            hdfAction.Value = "INSERT"
            hdfSelectedSeqNo.Value = String.Empty
            hdfSelectedMovieId.Value = String.Empty
        End Sub
        Private Sub CopyCollection(ByVal newCollectionNo As String, ByVal fromCollectionNo As String)
            If String.IsNullOrEmpty(fromCollectionNo) Then
                Return
            End If
            Dim dtb As DataTable = TrailerCollectionDetail.SelectData(fromCollectionNo, Nothing, Nothing, Nothing)
            If IsNothing(dtb) Then
                Return
            End If
            For Each dr As DataRow In dtb.Rows
                TrailerCollectionDetail.InsertAndDemoteAfter(newCollectionNo, CInt(dr("seq_no")), CInt(dr("movie_id")), dr("ref_setup_no").ToString(), GetUserId())
            Next
        End Sub
        Private Sub RefreshDetail()
            Response.Redirect("TrailerCollectionInsert.aspx?collection_no=" + Request.QueryString("collection_no"))
        End Sub
        Private Sub ShowData(ByVal sortExpression As String)
            Dim collecionNo = Request.QueryString("collection_no")
            If String.IsNullOrEmpty(collecionNo) Then
                collecionNo = hdfCollectionNo.Value.Trim()
            End If
            If String.IsNullOrEmpty(collecionNo) Then
                btnSaveDetail.Enabled = False
                TrailerCollectionFinder1.Enabled = True
                ClearData()
            Else
                BindData(collecionNo, sortExpression)
                TrailerCollectionFinder1.Enabled = False
            End If
        End Sub
#End Region

    End Class
End Namespace