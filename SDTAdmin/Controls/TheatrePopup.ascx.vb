Imports System.Web.Profile
Imports System.Web.UI
Imports Web.Data

Partial Public Class TheatrePopup
    Inherits System.Web.UI.UserControl

    Implements ICallbackEventHandler
    ' Events
    Public Event Changed As EventHandler

    ' Methods
    'Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnFind.Click
    '    'If txtMovies.Text.Trim() = "" Then
    '    '    GridView1.DataSourceID = "sqlMovies"
    '    'Else
    '    '    GridView1.DataSourceID = "SqlSearchByText"
    '    'End If

    '    ShowData()
    'End Sub

    Public Function GetCallbackResult() As String
        Return Me.DataResult
    End Function

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As GridViewCancelEditEventArgs)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        lblDataNotFound.Visible = False
        If Not MyBase.IsPostBack Then
            'txtCode.Attributes("onblur") = "setTimeout('document.getElementById(""" + onBlurCode.ClientID.ToString() + """).click()',10)"
            'txtYear.Text = Convert.ToString(DateTime.Today.Year)
            'ddlMonth.SelectedValue = DateTime.Today.Month.ToString("00")
        End If
        ShowData()

        'Dim str As String = Me.Page.ClientScript.GetCallbackEventReference(Me, "args", (Me.ClientID & "ChangeResponse"), "null")
        'Dim script As String = String.Concat(New String() {"function ", Me.ClientID, "Callback(args,context){", str, ";}"})
        'Me.Page.ClientScript.RegisterClientScriptBlock(MyBase.GetType, (Me.ClientID & "Callback"), script, True)
        'Me.txtCode.Attributes.Item("onBlur") = (Me.ClientID & "CodeChange();")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
        If Not MyBase.IsPostBack Then
            txtCode.Attributes("onblur") = "setTimeout('document.getElementById(""" + onBlurCode.ClientID.ToString() + """).click()',10)"
        End If
    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String)
    End Sub

    Protected Sub ShowData()
        'sqlMovies.SelectCommand = cDatabase.QueryMovieTrailer("")
        'GridView1.DataBind()

        '' ''Dim strCommand As String = "select *,substring(theater_id,7,2)+'-'+substring(theater_id,5,2)+'-'+substring(theater_id,1,4) theater_id1 from [tblTrailer_Setup_Hdr]"
        '' ''strCommand += " WHERE 1=1"
        ' '' ''If (txttheater_id.Text.Trim() <> "") Then
        ' '' ''    strCommand += " AND theater_id='" + txttheater_id.Text.Trim() + "'"
        ' '' ''End If
        '' ''If (txtYear.Text.Trim() <> "") Then
        '' ''    strCommand += " AND substring(theater_id,1,4)='" + txtYear.Text.Trim() + "'"
        '' ''End If
        '' ''If (ddlMonth.Text.Trim() <> "") Then
        '' ''    strCommand += " AND substring(theater_id,5,2)='" + ddlMonth.SelectedValue.Trim() + "'"
        '' ''End If

        '' ''strCommand += " Order by [theater_id] DESC"

        Dim strCommand As String = "select theater_id,theater_code,theater_name"
        strCommand += " from tblTheater "
        strCommand += " where theater_status = 'Enabled'"
        strCommand += " Order By theater_id ASC"

        sqlMovies.SelectCommand = strCommand
        GridView1.DataBind()
        ' lblResult.Text = GridView1.Rows.Count.ToString()
    End Sub


    ' Properties
    Protected ReadOnly Property ApplicationInstance() As HttpApplication
        Get
            Return Me.Context.ApplicationInstance
        End Get
    End Property

    Private _theater_id As String
    Public Property TheatreNo() As String
        Get
            Return txtCode1.Value.Trim()
        End Get
        Set(ByVal value As String)
            _theater_id = value
            txtCode.Text = value
            txtCode1.Value = txtCode.Text.Replace("-", "")
            'If (value.Length > 7) Then
            '    txtCode1.Value = value.Substring(6, 2) _
            '                            + "-" + value.Substring(4, 2) _
            '                            + "-" + value.Substring(0, 4)
            'End If

        End Set
    End Property

    Private _PeriodDate As String
    Public Property PeriodDate() As String
        Get
            If (txtName.Text.Trim() = "") Then
                Return ""
            Else
                Return txtName.Text.Trim()
            End If
        End Get
        Set(ByVal value As String)
            _PeriodDate = value
            txtName.Text = value
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

            Dim theater_id As String = Convert.ToString(e.CommandArgument)
            txtCode1.Value = Convert.ToString(e.CommandArgument)

            txtCode.Text = txtCode1.Value
            '.Substring(6, 2) _
            '    + "-" + txtCode1.Value.Substring(4, 2) _
            '    + "-" + txtCode1.Value.Substring(0, 4)
            Dim strCommand As String = "select theater_id,theater_code,theater_name"
            strCommand += " from tblTheater "
            strCommand += " where theater_status = 'Enabled' AND theater_id=" + txtCode1.Value
            Dim dataReader As IDataReader = pManage.GetDataAll(strCommand) 'pManage.getTrailerHeaderRead(theater_id)
            If dataReader.Read = True Then
                txtName.Text = dataReader("theater_name")
                '.ToString("dd/MM/yyyy") _
                '                + " - " + Convert.ToDateTime(dataReader("theater_name")).ToString("dd/MM/yyyy")
                txtCode1.Value = dataReader("theater_id")
                txtCode.Text = dataReader("theater_id")
                'txtCode1.Value.Substring(6, 2) _
                '                                        + "-" + txtCode1.Value.Substring(4, 2) _
                '                                        + "-" + txtCode1.Value.Substring(0, 4)
                'txtStartDate.Value = Convert.ToDateTime(dataReader("theater_code")).ToString("dd/MM/yyyy")
                'txtEndDate.Value = Convert.ToDateTime(dataReader("theater_name")).ToString("dd/MM/yyyy")
                Session("TheatrePopup") = txtCode1.Value
            Else
                txtName.Text = ""
                txtCode.Text = ""
                txtCode1.Value = ""
                txtStartDate.Value = ""
                txtEndDate.Value = ""
                lblDataNotFound.Visible = True
            End If
            dataReader.Close()

            txtDisplay.Text = ""

            'If (Not Me.Changed Is Nothing) Then
            RaiseEvent Changed(sender, New EventArgs())
            'End If
        End If
        ShowData()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim table As DataTable = DirectCast(Me.ViewState.Item((Me.ClientID & ".DataTable")), DataTable)
        Me.GridView1.PageIndex = e.NewPageIndex
        Me.GridView1.DataSource = table
        Me.GridView1.DataBind()
    End Sub

    Protected Sub onBlurCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles onBlurCode.Click
        Try

            If (txtCode.Text.Trim() = "") Then
                txtCode.Text = ""
                txtName.Text = ""
                txtDisplay.Text = ""
                Return
            End If
        
            Dim pManage As New cDatabase()
            If Convert.ToString(txtCode.Text.Trim()) <> "" Then
                Dim theater_id As String = Convert.ToString(txtCode.Text.Trim())
                _theater_id = Convert.ToString(txtCode.Text.Trim())

                'Dim arytheater_id As String() = theater_id.Split("-")
                'If (arytheater_id.Length < 3) Then
                '    txtName.Text = ""
                '    txtCode.Text = ""
                '    txtCode1.Value = ""
                '    txtStartDate.Value = ""
                '    txtEndDate.Value = ""
                '    lblDataNotFound.Visible = True
                '    Return
                'End If

                '_theater_id = arytheater_id(2) + arytheater_id(1) + arytheater_id(0)
                txtCode1.Value = _theater_id
                txtCode.Text = theater_id

                Dim strCommand As String = "select theater_id,theater_code,theater_name"
                strCommand += " from tblTheater "
                strCommand += " where theater_status = 'Enabled' AND theater_id=" + txtCode1.Value
                Dim dataReader As IDataReader = pManage.GetDataAll(strCommand)
                If dataReader.Read = True Then
                    txtName.Text = dataReader("theater_name").ToString()
                    txtCode1.Value = dataReader("theater_id").ToString()
                    txtCode.Text = dataReader("theater_id").ToString()
                    lblDataNotFound.Visible = False
                Else
                    txtName.Text = ""
                    txtCode.Text = ""
                    txtCode1.Value = ""
                    txtStartDate.Value = ""
                    txtEndDate.Value = ""
                    lblDataNotFound.Visible = True
                    'Response.Write("<script>alert('ไม่พบข้อมูล');</script>")
                End If
                dataReader.Close()

                txtDisplay.Text = ""

                ShowData()
            End If
        Catch ex As Exception
            lblDataNotFound.Visible = True
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    Dim strBgCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_background_color")).Trim()
        '    Dim strFontCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_font_color")).Trim()

        '    Dim i As Integer = 0
        '    If (strBgCode <> "") Then
        '        'For i = 0 To e.Row.Cells.Count - 1
        '        e.Row.Cells(2).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
        '        ' Next
        '    Else
        '        'For i = 0 To e.Row.Cells.Count - 1
        '        e.Row.Cells(2).BackColor = System.Drawing.Color.White
        '        'Next
        '    End If

        '    If (strFontCode <> "") Then
        '        'For i = 0 To e.Row.Cells.Count - 1
        '        e.Row.Cells(2).ForeColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_font_color"))
        '        'Next
        '    Else
        '        'For i = 0 To e.Row.Cells.Count - 1
        '        e.Row.Cells(2).ForeColor = System.Drawing.Color.Black
        '        'Next
        '    End If

        '    'e.Row.Cells(2).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
        'End If
    End Sub

End Class