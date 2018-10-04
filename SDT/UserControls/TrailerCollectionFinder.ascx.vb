Imports System.Drawing
Imports System.Web.UI
Imports SDTCommon
Imports SDTCommon.Extensions
Imports SDTCommon.DBInterface

Namespace UserControls

    Partial Public Class TrailerCollectionFinder
        Inherits UserControl

        'Public Delegate Function CallbackEvent(ByVal sender As Object, ByVal e As EventArgs) As String
        Public Event Changed As EventHandler

#Region "Properties"
        'Protected ReadOnly Property ApplicationInstance() As HttpApplication
        '    Get
        '        Return Context.ApplicationInstance
        '    End Get
        'End Property
        Public Property Display() As Boolean
            Get
                Return txtDisplay.Text = "display"
            End Get
            Set(ByVal value As Boolean)
                If value Then
                    txtDisplay.Text = "display"
                Else
                    txtDisplay.Text = String.Empty
                End If
            End Set
        End Property
        Public Property Enabled() As Boolean
            Get
                Return Not txtCode.ReadOnly
            End Get
            Set(ByVal value As Boolean)
                txtCode.ReadOnly = Not value
                If (value) Then
                    txtCode.BackColor = Color.White
                    txtCode.ForeColor = Color.Black
                Else
                    txtCode.BackColor = Color.LightGray
                    txtCode.ForeColor = Color.FromName("#666666")
                End If
                txtEnabled.Text = value.ToString
            End Set
        End Property
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

        'Protected ReadOnly Property Profile() As DefaultProfile
        '    Get
        '        Return DirectCast(Context.Profile, DefaultProfile)
        '    End Get
        'End Property
        Public Property DataNotFound() As Boolean
            Get
                Return lblDataNotFound.Visible
            End Get
            Set(ByVal value As Boolean)
                lblDataNotFound.Visible = value
            End Set
        End Property


        Public Property CollectionNo() As String
            Get
                If String.IsNullOrEmpty(hdfCollectionNo.Value.Trim()) Then
                    Return String.Empty
                Else
                    Return hdfCollectionNo.Value
                End If
            End Get
            Set(ByVal value As String)
                If String.IsNullOrEmpty(value) Then
                    value = String.Empty
                End If
                value = value.Trim()

                hdfCollectionNo.Value = String.Empty
                txtCode.Text = String.Empty
                txtName.Text = String.Empty
                txtDisplay.Text = String.Empty
                If String.IsNullOrEmpty(value) Then
                    Return
                End If

                hdfCollectionNo.Value = value

                Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(value, Nothing, GetCircuitId(), GetTheaterId(), True, "collection_name ASC")
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr = dtb.Rows(0)
                    hdfCollectionNo.Value = dr("collection_no").ToString()
                    txtCode.Text = dr("collection_name").ToString()
                    txtName.Text = dr("MovieCollection").ToString()
                End If
            End Set
        End Property
        Public Property CollectionName() As String
            Get
                If String.IsNullOrEmpty(txtCode.Text.Trim()) Then
                    Return String.Empty
                Else
                    Return txtCode.Text
                End If
            End Get
            Set(ByVal value As String)
                If String.IsNullOrEmpty(value) Then
                    value = String.Empty
                End If
                value = value.Trim()

                hdfCollectionNo.Value = String.Empty
                txtCode.Text = String.Empty
                txtName.Text = String.Empty
                txtDisplay.Text = String.Empty
                If String.IsNullOrEmpty(value) Then
                    Return
                End If

                txtCode.Text = value

                Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, value, GetCircuitId(), GetTheaterId(), True, "collection_name ASC")
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    Dim dr = dtb.Rows(0)
                    hdfCollectionNo.Value = dr("collection_no").ToString()
                    txtCode.Text = dr("collection_name").ToString()
                    txtName.Text = dr("MovieCollection").ToString()
                End If
            End Set
        End Property
#End Region

#Region "Event Handlers"
        Protected Sub BtnOnBlurCodeClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOnBlurCode.Click
            If String.IsNullOrEmpty(CollectionName) Then
                txtCode.Text = String.Empty
                txtName.Text = String.Empty
                txtDisplay.Text = String.Empty
                Return
            End If

            CollectionName = txtCode.Text
        End Sub
        Protected Sub GrdResultPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles grdResult.PageIndexChanging
            grdResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            If (e.CommandName = "Select") Then
                txtDisplay.Text = String.Empty
                CollectionNo = e.CommandArgument.ToString()

                'If Not IsNothing(Changed) Then
                RaiseEvent Changed(sender, New EventArgs())
                'End If
            End If
        End Sub
        Protected Sub GrdResultSorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles grdResult.Sorting
            If GridViewSortDirection = SortDirection.Ascending Then
                GridViewSortDirection = SortDirection.Descending
            Else
                GridViewSortDirection = SortDirection.Ascending
            End If
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, Nothing, GetCircuitId(), GetTheaterId(), True, "collection_name ASC")
            Utils.SortGridView(grdResult, dtb, e.SortExpression, GridViewSortDirection)
        End Sub
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If IsPostBack Then
                Return
            End If
            txtCode.Attributes("onblur") = "setTimeout('document.getElementById(""" + btnOnBlurCode.ClientID.ToString() + """).click()',10)"
            BindData()
            'Dim str As String = Me.Page.ClientScript.GetCallbackEventReference(Me, "args", (Me.ClientID & "ChangeResponse"), "null")
            'Dim script As String = String.Concat(New String() {"function ", Me.ClientID, "Callback(args,context){", str, ";}"})
            'Me.Page.ClientScript.RegisterClientScriptBlock(MyBase.GetType, (Me.ClientID & "Callback"), script, True)
            'Me.txtCode.Attributes.Item("onBlur") = (Me.ClientID & "CodeChange();")
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            lblDataNotFound.Visible = False
        End Sub
#End Region

#Region "Methods"
        Public Function BindData() As Boolean
            'Dim dtb As datatable= DirectCast(ViewState.Item((ClientID & ".DataTable")), DataTable)
            Dim dtb As DataTable = MovieAndTrailer.GetTrailerCollectionHeader(Nothing, Nothing, GetCircuitId(), GetTheaterId(), True, "collection_name ASC")
            grdResult.DataSource = dtb
            grdResult.DataBind()
            lblDataNotFound.Visible = (grdResult.Rows.Count = 0)
            Return Not lblDataNotFound.Visible
        End Function
#End Region

    End Class
End Namespace