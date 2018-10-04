Imports System.Web.Profile
Imports System.Web.UI
Imports Web.Data

Interface ICallbackEventHandler

End Interface

Partial Public Class Movie1Popup
    Inherits System.Web.UI.UserControl

    Implements ICallbackEventHandler
    ' Events
    Public Event Changed As EventHandler


    ' Methods
    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnFind.Click
        Try
            SetValue()
            Me.GridView1.PageIndex = 0
            ShowData("")
        Catch ex As Exception
            txtCode.Text = ex.Message
            lblDataNotFound.Visible = True
        End Try
      
    End Sub

    Public Function GetCallbackResult() As String
        Return Me.DataResult
    End Function

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
    End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    '    lblDataNotFound.Visible = False
    '    If Not MyBase.IsPostBack Then
    '        txtCode.Attributes("onblur") = "setTimeout('document.getElementById(""" + onBlurCode.ClientID.ToString() + """).click()',10)"

    '        ddlDistibutor.Items.Clear()
    '        ddlStatus.Items.Clear()

    '        Dim i As Integer
    '        Dim dtbDistributor As DataTable = cDatabase.GetDataTable("SELECT [distributor_name], [distributor_id] FROM [tblDistributor]")
    '        For i = 0 To dtbDistributor.Rows.Count - 1
    '            ddlDistibutor.Items.Add(New ListItem(dtbDistributor.Rows(i)("distributor_name"), dtbDistributor.Rows(i)("distributor_id")))
    '        Next

    '        Dim dtbStudio As DataTable = cDatabase.GetDataTable("SELECT studio_id, studio_name FROM tblStudio")
    '        For i = 0 To dtbStudio.Rows.Count - 1
    '            ddlStudio.Items.Add(New ListItem(dtbStudio.Rows(i)("studio_name"), dtbStudio.Rows(i)("studio_id")))
    '        Next

    '        ddlDistibutor.Items.Insert(0, New ListItem("---All---", "0"))
    '        ddlStudio.Items.Insert(0, New ListItem("---All---", "0"))
    '        ddlDistibutor.SelectedValue = "0"
    '        ddlStudio.SelectedValue = "0"

    '        Me.ShowData()
    '    End If

    '    'Dim str As String = Me.Page.ClientScript.GetCallbackEventReference(Me, "args", (Me.ClientID & "ChangeResponse"), "null")
    '    'Dim script As String = String.Concat(New String() {"function ", Me.ClientID, "Callback(args,context){", str, ";}"})
    '    'Me.Page.ClientScript.RegisterClientScriptBlock(MyBase.GetType, (Me.ClientID & "Callback"), script, True)
    '    'Me.txtCode.Attributes.Item("onBlur") = (Me.ClientID & "CodeChange();")

    'End Sub


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        If Not MyBase.IsPostBack Then
            txtCode.Attributes("onblur") = "setTimeout('document.getElementById(""" + onBlurCode.ClientID.ToString() + """).click()',10)"

            'onBlurCode.OnClientClick = "if (document.getElementById(""" + txtCode.ClientID.ToString() + """).value==''){return false;} else {return true;}"

            ddlDistibutor.Items.Clear()
            ddlStudio.Items.Clear()
            ddlMovieType.Items.Clear()

            Dim i As Integer
            Dim dtbDistributor As DataTable = cDatabase.GetDataTable("SELECT [distributor_name], [distributor_id] FROM [tblDistributor]")
            For i = 0 To dtbDistributor.Rows.Count - 1
                ddlDistibutor.Items.Add(New ListItem(dtbDistributor.Rows(i)("distributor_name"), dtbDistributor.Rows(i)("distributor_id")))
            Next

            Dim dtbStudio As DataTable = cDatabase.GetDataTable("SELECT studio_id, studio_name FROM tblStudio")
            For i = 0 To dtbStudio.Rows.Count - 1
                ddlStudio.Items.Add(New ListItem(dtbStudio.Rows(i)("studio_name"), dtbStudio.Rows(i)("studio_id")))
            Next

            Dim dtbMovieType As DataTable = cDatabase.GetDataTable("SELECT MovieType_ID, MovieType_Des FROM tblMovieType")
            For i = 0 To dtbMovieType.Rows.Count - 1
                ddlMovieType.Items.Add(New ListItem(dtbMovieType.Rows(i)("MovieType_Des"), dtbMovieType.Rows(i)("MovieType_ID")))
            Next

            ddlDistibutor.Items.Insert(0, New ListItem("---All---", "0"))
            ddlStudio.Items.Insert(0, New ListItem("---All---", "0"))
            ddlMovieType.Items.Insert(0, New ListItem("---All---", "0"))
            ddlDistibutor.SelectedValue = "0"
            ddlStudio.SelectedValue = "0"
            ddlMovieType.SelectedValue = "0"

            Me.GridView1.PageIndex = 0
            Me.ShowData("")
        End If

        'Dim str As String = Me.Page.ClientScript.GetCallbackEventReference(Me, "args", (Me.ClientID & "ChangeResponse"), "null")
        'Dim script As String = String.Concat(New String() {"function ", Me.ClientID, "Callback(args,context){", str, ";}"})
        'Me.Page.ClientScript.RegisterClientScriptBlock(MyBase.GetType, (Me.ClientID & "Callback"), script, True)
        'Me.txtCode.Attributes.Item("onBlur") = (Me.ClientID & "CodeChange();")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lblDataNotFound.Visible = False
    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String)
    End Sub

    Private Sub ShowData(ByVal sort As String)
        Try
            Dim strCommand As String = cDatabase.QueryMovie(txtMovies.Text.Trim() _
                                                   , _InStatus _
                                                   , _AppearOnStatus _
                                                   , _Distibutor _
                                                   , _Studio _
                                                   , _MovieType _
                                                   , "")

            ddlDistibutor.SelectedValue = _Distibutor
            ddlStudio.SelectedValue = _Studio
            ddlMovieType.SelectedValue = _MovieType
            txtInStatus.Value = _InStatus
            txtAppearOn.Value = _AppearOnStatus

            Dim dtb As New DataTable
            dtb = cDatabase.GetDataTable(strCommand)
            Dim dtv As New DataView
            dtv = dtb.DefaultView
            If (sort.Trim() <> "") Then
                dtv.Sort = sort
            End If

            GridView1.DataSource = dtv
            GridView1.DataBind()

            lblResult.Text = dtb.Rows.Count.ToString("#,##0")
        Catch ex As Exception
            txtCode.Text = ex.Message
        End Try
        

    End Sub

    Public Sub BindData()
        Try
            Dim strCommand As String = cDatabase.QueryMovie(txtMovies.Text.Trim() _
                                                   , _InStatus _
                                                   , _AppearOnStatus _
                                                   , ddlDistibutor.SelectedValue _
                                                   , ddlStudio.SelectedValue _
                                                   , ddlMovieType.SelectedValue _
                                                   , "")
            SetValue()

            Dim dtb As New DataTable
            dtb = cDatabase.GetDataTable(strCommand)
            GridView1.DataSource = dtb
            GridView1.DataBind()

            lblResult.Text = dtb.Rows.Count.ToString("#,##0")
        Catch ex As Exception
            txtCode.Text = ex.Message
        End Try
        

    End Sub


    ' Properties
    Protected ReadOnly Property ApplicationInstance() As HttpApplication
        Get
            Return Me.Context.ApplicationInstance
        End Get
    End Property

    'Public Property MovieId() As Integer
    '    Get
    '        Return Me.MovieId
    '    End Get
    '    Set(ByVal value As Integer)
    '        'Me.MovieId = value
    '    End Set
    'End Property


    Private _InStatus As String
    Public Property InStatus() As String
        Get
            Return _InStatus
        End Get
        Set(ByVal value As String)
            _InStatus = value
            txtInStatus.Value = value
        End Set
    End Property

    Private _Studio As String
    Public Property Studio() As String
        Get
            Return _Studio
        End Get
        Set(ByVal value As String)
            _Studio = value
            ddlStudio.SelectedValue = value
        End Set
    End Property

    Private _Distibutor As String
    Public Property Distibutor() As String
        Get
            Return _Distibutor
        End Get
        Set(ByVal value As String)
            _Distibutor = value
            ddlDistibutor.SelectedValue = value
        End Set
    End Property

    Private _MovieType As String
    Public Property MovieType() As String
        Get
            Return _MovieType
        End Get
        Set(ByVal value As String)
            _MovieType = value
            ddlMovieType.SelectedValue = value
        End Set
    End Property

    Private _AppearOnStatus As String
    Public Property AppearOnStatus() As String
        Get
            Return _AppearOnStatus
        End Get
        Set(ByVal value As String)
            _AppearOnStatus = value
            txtAppearOn.Value = value
        End Set
    End Property


    Private _MovieId As Integer
    Public Property MovieId() As Integer
        Get
            If txtCode.Text.Trim() = "" Then
                Return 0
            Else
                Return txtCode.Text
            End If

        End Get
        Set(ByVal value As Integer)

            If value = 0 Then
                _MovieId = value
                txtCode.Text = ""
                txtName.Text = ""
                Return
            End If

            _MovieId = value
            txtCode.Text = Convert.ToString(value)

            Dim pManage As New cDatabase()
            _MovieId = MovieId

            Dim getMovieDetail As New cDatabase
            Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(value)
            If dataReader.Read = True Then
                txtName.Text = dataReader("movie_nameen") + "/" + dataReader("movie_nameth")
            End If
            dataReader.Close()

        End Set
    End Property


    Public Property Display() As Boolean
        Get
            Return (Me.txtDisplay.Text = "display")
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.txtDisplay.Text = "display"
            Else
                Me.txtDisplay.Text = ""
            End If
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Not Me.txtCode.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            Me.txtCode.ReadOnly = Not value
            If (value) Then
                Me.txtCode.BackColor = Color.White
                Me.txtCode.ForeColor = Color.Black
            Else
                Me.txtCode.BackColor = Color.LightGray
                Me.txtCode.ForeColor = Color.FromName("#666666")
            End If
            Me.txtEnabled.Text = value.ToString

        End Set
    End Property

    Public Property EnabledMovieType() As Boolean
        Get
            Return ddlMovieType.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlMovieType.Enabled = value
        End Set
    End Property

    Public Property EnabledDistributor() As Boolean
        Get
            Return ddlDistibutor.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlDistibutor.Enabled = value
        End Set
    End Property

    Public Property EnabledStudio() As Boolean
        Get
            Return ddlStudio.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlStudio.Enabled = value
        End Set
    End Property




    Public Property VisibleMovieType() As Boolean
        Get
            Return ddlMovieType.Visible
        End Get
        Set(ByVal value As Boolean)
            ddlMovieType.Visible = value
            Label5.Visible = value
        End Set
    End Property

    Public Property VisibleDistributor() As Boolean
        Get
            Return ddlDistibutor.Visible
        End Get
        Set(ByVal value As Boolean)
            ddlDistibutor.Visible = value
            Label2.Visible = value
        End Set
    End Property

    Public Property VisibleStudio() As Boolean
        Get
            Return ddlStudio.Visible
        End Get
        Set(ByVal value As Boolean)
            ddlStudio.Visible = value
            Label3.Visible = value
        End Set
    End Property




    Protected ReadOnly Property Profile() As DefaultProfile
        Get
            Return DirectCast(Me.Context.Profile, DefaultProfile)
        End Get
    End Property


    '' Fields
    'Protected btnFind As ImageButton
    'Protected GridView1 As GridView
    'Protected Label1 As Label
    'Protected txtCode As TextBox
    'Protected txtDisplay As TextBox
    'Protected txtEnabled As TextBox
    'Protected txtFind As TextBox
    'Protected txtName As TextBox
    Private DataResult As String = ""

    ' Nested Types
    Public Delegate Function CallbackEvent(ByVal sender As Object, ByVal e As EventArgs) As String

    Protected Sub GridView1_RowCommand1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If (e.CommandName = "Select") Then

            Dim pManage As New cDatabase()

            Dim movieId As Integer = Convert.ToInt32(e.CommandArgument)
            Me.MovieId = movieId
            txtCode.Text = Convert.ToString(e.CommandArgument)

            Dim getMovieDetail As New cDatabase
            Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(movieId)
            If dataReader.Read = True Then
                txtName.Text = dataReader("movie_nameen") + "/" + dataReader("movie_nameth")
            End If
            dataReader.Close()

            txtDisplay.Text = ""

            'If (Not Me.Changed Is Nothing) Then
            RaiseEvent Changed(sender, New EventArgs())
            'End If
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim table As DataTable = DirectCast(Me.ViewState.Item((Me.ClientID & ".DataTable")), DataTable)
        Me.GridView1.PageIndex = e.NewPageIndex
        SetValue()
        ShowData("")
    End Sub


    Protected Sub onBlurCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles onBlurCode.Click
        Dim pManage As New cDatabase()

        If (txtCode.Text.Trim() = "") Then
            txtCode.Text = ""
            txtName.Text = ""
            Return
        End If

        Try
            Dim xxx As Integer = Convert.ToInt32(txtCode.Text)
        Catch ex As Exception
            txtCode.Text = ""
            txtName.Text = ""
            lblDataNotFound.Visible = True
            Return
        End Try

        Dim movieId As Integer = Convert.ToInt32(txtCode.Text)
        Me.MovieId = movieId


        Dim getMovieDetail As New cDatabase

        'cDatabase.QueryMovie("" _
        '                                                   , _InStatus _
        '                                                   , _AppearOnStatus _
        '                                                   , _Distibutor _
        '                                                   , _Studio _
        '                                                   , _MovieType _
        '                                                   , "")

        SetValue()
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(movieId)
        If dataReader.Read = True Then
            If (_InStatus <> "0" And _InStatus <> "") Then
                If (_InStatus.IndexOf(Convert.ToString(dataReader("movie_status"))) >= 0) Then
Accept_MovieStatus:
                    If (_AppearOnStatus <> "0" And _AppearOnStatus <> "") Then
                        If (_AppearOnStatus.IndexOf(Convert.ToString(dataReader("appear_status_id"))) >= 0) Then
Accept_AppearOn:
                            If (_MovieType <> "0" And _MovieType <> "") Then
                                If (_MovieType.IndexOf(Convert.ToString(dataReader("movietype_id"))) >= 0) Then
Accept_MovieType:
                                    txtName.Text = dataReader("movie_nameen") + "/" + dataReader("movie_nameth")
                                    GoTo white_Movie
                                End If
                            Else
                                GoTo Accept_MovieType
                            End If
                        End If
                    Else
                        GoTo Accept_AppearOn
                    End If
                End If
            Else
                GoTo Accept_MovieStatus
            End If
        End If

        txtCode.Text = ""
        txtName.Text = ""
        lblDataNotFound.Visible = True

white_Movie:
        dataReader.Close()

        txtDisplay.Text = ""
    End Sub


    Private Sub SetValue()
        _Distibutor = ddlDistibutor.SelectedValue
        _Studio = ddlStudio.SelectedValue
        _MovieType = ddlMovieType.SelectedValue
        _InStatus = txtInStatus.Value
        _AppearOnStatus = txtAppearOn.Value
    End Sub

    Protected Sub ddlDistibutor_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlDistibutor.SelectedIndexChanged
        SetValue()
        Me.GridView1.PageIndex = 0
        ShowData("")
    End Sub

    Protected Sub ddlStudio_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlStudio.SelectedIndexChanged
        SetValue()
        Me.GridView1.PageIndex = 0
        ShowData("")
    End Sub

    Protected Sub ddlMovieType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlMovieType.SelectedIndexChanged
        SetValue()
        Me.GridView1.PageIndex = 0
        ShowData("")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        SetValue()
        ShowData(e.SortExpression + " " + ConvertSortDirectionToSql(e.SortExpression, e.SortDirection))
    End Sub

    Private Function ConvertSortDirectionToSql(ByVal SortExpression As String, ByVal SortDirection As SortDirection) As String
        Dim newSortDirection As String

        If (ViewState("sortby")) Is Nothing Then
            newSortDirection = "ASC"
            ViewState("sort") = "ASC"
            ViewState("sortby") = SortExpression
            Return newSortDirection
        ElseIf Convert.ToString(ViewState("sortby")).Trim() <> SortExpression Then
            newSortDirection = "ASC"
            ViewState("sort") = "ASC"
            ViewState("sortby") = SortExpression
            Return newSortDirection
        End If

        If ViewState("sort") Is Nothing Then
            If (SortDirection = SortDirection.Ascending) Then
                newSortDirection = "DESC"
                ViewState("sort") = "DESC"
            Else
                newSortDirection = "ASC"
                ViewState("sort") = "ASC"
            End If
        Else
            If (Convert.ToString(ViewState("sort")) = "ASC") Then
                newSortDirection = "DESC"
                ViewState("sort") = "DESC"
            Else
                newSortDirection = "ASC"
                ViewState("sort") = "ASC"
            End If
        End If

        Return newSortDirection
    End Function

End Class