Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class TrailerCollection
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
        Protected Sub BtnAddClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
            Redirect(PageName.TrailerCollectionInsert)
        End Sub
        Protected Sub BtnMainMenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMainMenu.Click
            Redirect(PageName.ActionMenu)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            ShowData()
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            If e.CommandName = "Del" Then
                Dim collectionNo = Convert.ToString(e.CommandArgument)
                MovieAndTrailer.DeleteTrailerCollectionHeader(collectionNo)
                ShowData()
            End If
        End Sub
        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If
            Dim ctl = e.Row.Cells(2).FindControl("btnDelete")
            If Not IsNothing(ctl) Then
                Dim btn As LinkButton = CType(ctl, LinkButton)

                Dim collectionNo = DataBinder.Eval(e.Row.DataItem, "collection_no")
                If Not IsNothing(collectionNo) AndAlso Not String.IsNullOrEmpty(collectionNo.ToString()) Then
                    Dim dtb As DataTable = MovieAndTrailer.GetTrailerMaster(Nothing, Nothing, Nothing, Nothing, Nothing, collectionNo.ToString(), Nothing)
                    If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                        btn.OnClientClick = "alert('ไม่สามารถลบข้อมูลได้\nเนื่องจากข้อมูลมีการถูกเรียกใช้งาน');return false;"
                    Else
                        btn.OnClientClick = "return confirm('ยืนยันการลบข้อมูล?')"
                    End If
                End If
            End If
        End Sub
        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, Nothing, GetCircuitId(), GetTheaterId(), True, Nothing)
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub
#End Region

#Region "Methods"
        Private Sub ShowData()
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, Nothing, GetCircuitId(), GetTheaterId(), True, " collection_name ASC")
            grdResult.DataSource = dtb
            grdResult.DataBind()
        End Sub
#End Region

    End Class
End Namespace