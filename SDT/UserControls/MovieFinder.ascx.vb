Imports System.Drawing
Imports SDTCommon
Imports SDTCommon.DBInterface

Namespace UserControls

    Partial Public Class MovieFinder
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

        Private _appearOnStatus As Int32?
        Private _distibutor As Int32?
        Private _inStatus As Int32?
        Private _movieType As Int32?
        Private _studio As Int32?

        Public Property AppearOnStatus() As Int32?
            Get
                Return _appearOnStatus
            End Get
            Set(ByVal value As Int32?)
                _appearOnStatus = value
            End Set
        End Property
        Public Property Distibutor() As Int32?
            Get
                Return _distibutor
            End Get
            Set(ByVal value As Int32?)
                _distibutor = value
            End Set
        End Property
        Public Property InStatus() As Int32?
            Get
                Return _inStatus
            End Get
            Set(ByVal value As Int32?)
                _inStatus = value
            End Set
        End Property
        Public Property MovieId() As Int32?
            Get
                If String.IsNullOrEmpty(txtCode.Text.Trim()) Then
                    Return Nothing
                Else
                    Return CType(txtCode.Text.Trim(), Int32)
                End If
            End Get
            Set(ByVal value As Int32?)
                txtCode.Text = String.Empty
                txtName.Text = String.Empty
                txtDisplay.Text = String.Empty
                If IsNothing(value) OrElse value = 0 Then
                    Return
                End If

                txtCode.Text = value.ToString()

                Dim dtb As DataTable = MovieAndTrailer.GetMovieDetail(value, Nothing, _inStatus, _appearOnStatus, _distibutor, _studio, _movieType, Nothing)
                If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                    'เหลือเพิ่ม spear on
                    Dim dr = dtb.Rows(0)
                    txtName.Text = dr("MovieName").ToString()
                End If
            End Set
        End Property
        Public Property MovieType() As Int32?
            Get
                Return _movieType
            End Get
            Set(ByVal value As Int32?)
                _movieType = value
            End Set
        End Property
        Public Property Studio() As Int32?
            Get
                Return _studio
            End Get
            Set(ByVal value As Int32?)
                _studio = value
            End Set
        End Property

#End Region

#Region "Event Handlers"
        Protected Sub BtnOnBlurCodeClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOnBlurCode.Click
            If IsNothing(MovieId) OrElse IsNothing(InStatus) OrElse AppearOnStatus Is Nothing Then
                txtCode.Text = String.Empty
                txtName.Text = String.Empty
                txtDisplay.Text = String.Empty
                Return
            End If

            MovieId = MovieId.Value
        End Sub
        Protected Sub GrdResultPageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles grdResult.PageIndexChanging
            grdResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub
        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles grdResult.RowCommand
            If (e.CommandName = "Select") Then
                txtDisplay.Text = String.Empty
                MovieId = Convert.ToInt32(e.CommandArgument)

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
            Dim dtb As DataTable = MovieAndTrailer.GetMovieDetail(Nothing, Nothing, _inStatus, _appearOnStatus, _distibutor, _studio, _movieType, Nothing)
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
            'Dim dtb As DataTable = DirectCast(ViewState.Item((ClientID & ".DataTable")), DataTable)
            Dim dtb As DataTable = MovieAndTrailer.GetMovieDetail(Nothing, Nothing, _inStatus, _appearOnStatus, _distibutor, _studio, _movieType, Nothing)
            grdResult.DataSource = dtb
            grdResult.DataBind()
            lblDataNotFound.Visible = (grdResult.Rows.Count = 0)
            Return Not lblDataNotFound.Visible
        End Function
#End Region

    End Class
End Namespace