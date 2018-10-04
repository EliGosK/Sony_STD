Imports System.Web.Profile
Imports System.Web.UI
Imports Web.Data

Partial Public Class Trailer_Header_SetupPopup
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
            txtYear.Text = Convert.ToString(DateTime.Today.Year)
            ddlMonth.SelectedValue = DateTime.Today.Month.ToString("00")
        End If
        ShowData()

        'Dim str As String = Me.Page.ClientScript.GetCallbackEventReference(Me, "args", (Me.ClientID & "ChangeResponse"), "null")
        'Dim script As String = String.Concat(New String() {"function ", Me.ClientID, "Callback(args,context){", str, ";}"})
        'Me.Page.ClientScript.RegisterClientScriptBlock(MyBase.GetType, (Me.ClientID & "Callback"), script, True)
        'Me.txtCode.Attributes.Item("onBlur") = (Me.ClientID & "CodeChange();")

    End Sub

    Public Sub RaiseCallbackEvent(ByVal eventArgument As String)
    End Sub

    Protected Sub ShowData()
        'sqlMovies.SelectCommand = cDatabase.QueryMovieTrailer("")
        'GridView1.DataBind()

        Dim strCommand As String = "select *,substring(setup_no,7,2)+'-'+substring(setup_no,5,2)+'-'+substring(setup_no,1,4) setup_no1 from [tblTrailer_Setup_Hdr]"
        strCommand += " WHERE 1=1"
        'If (txtSetup_No.Text.Trim() <> "") Then
        '    strCommand += " AND setup_no='" + txtSetup_No.Text.Trim() + "'"
        'End If
        If (txtYear.Text.Trim() <> "") Then
            strCommand += " AND substring(setup_no,1,4)='" + txtYear.Text.Trim() + "'"
        End If
        If (ddlMonth.Text.Trim() <> "") Then
            strCommand += " AND substring(setup_no,5,2)='" + ddlMonth.SelectedValue.Trim() + "'"
        End If

        strCommand += " Order by [setup_no] DESC"

        sqlMovies.SelectCommand = strCommand
        GridView1.DataBind()
        lblResult.Text = GridView1.Rows.Count.ToString()
    End Sub


    ' Properties
    Protected ReadOnly Property ApplicationInstance() As HttpApplication
        Get
            Return Me.Context.ApplicationInstance
        End Get
    End Property

    Private _Setup_No As String
    Public Property SetupNo() As String
        Get
            Return txtCode1.Value.Trim()
        End Get
        Set(ByVal value As String)
            _Setup_No = value
            txtCode.Text = value
            txtCode1.Value = txtCode.Text.Replace("-", "")
            txtName.Text = ""
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

    Private _StartDate As DateTime
    Public Property StartDate() As DateTime
        Get
            If (txtStartDate.Value.Trim() = "") Then
                Return New DateTime()
            Else
                Return Convert.ToDateTime(txtStartDate.Value)
            End If
        End Get
        Set(ByVal value As DateTime)
            _StartDate = value
            txtStartDate.Value = value.ToString("dd/MM/yyyy")
        End Set
    End Property

    Private _EndDate As DateTime
    Public Property EndDate() As DateTime
        Get
            If (txtEndDate.Value.Trim() = "") Then
                Return New DateTime()
            Else
                Return Convert.ToDateTime(txtEndDate.Value)
            End If
        End Get
        Set(ByVal value As DateTime)
            _EndDate = value
            txtEndDate.Value = value.ToString("dd/MM/yyyy")
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

            Dim setup_no As String = Convert.ToString(e.CommandArgument)
            txtCode1.Value = Convert.ToString(e.CommandArgument)

            txtCode.Text = txtCode1.Value.Substring(6, 2) _
                                        + "-" + txtCode1.Value.Substring(4, 2) _
                                        + "-" + txtCode1.Value.Substring(0, 4)

            Dim dataReader As IDataReader = pManage.getTrailerHeaderRead(setup_no)
            If dataReader.Read = True Then
                txtName.Text = Convert.ToDateTime(dataReader("setup_start_date")).ToString("dd/MM/yyyy") _
                + " - " + Convert.ToDateTime(dataReader("setup_end_date")).ToString("dd/MM/yyyy")
                txtCode1.Value = dataReader("setup_no")
                txtCode.Text = txtCode1.Value.Substring(6, 2) _
                                        + "-" + txtCode1.Value.Substring(4, 2) _
                                        + "-" + txtCode1.Value.Substring(0, 4)
                txtStartDate.Value = Convert.ToDateTime(dataReader("setup_start_date")).ToString("dd/MM/yyyy")
                txtEndDate.Value = Convert.ToDateTime(dataReader("setup_end_date")).ToString("dd/MM/yyyy")
                Session("SetupNoPopup") = txtCode1.Value
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
        Dim pManage As New cDatabase()

        'If (txtCode.Text.Trim() = "") Then
        '    txtCode.Text = ""
        '    txtName.Text = ""
        '    Return
        'End If

        'Try
        '    Dim xxx As Double = Convert.ToInt64(txtCode.Text)
        'Catch ex As Exception
        '    txtCode.Text = ""
        '    txtName.Text = ""
        '    lblDataNotFound.Visible = True
        '    Return
        'End Try

        Dim setup_no As String = Convert.ToString(txtCode.Text.Trim())

        Dim arySetup_No As String() = setup_no.Split("-")
        If (arySetup_No.Length < 3) Then
            txtName.Text = ""
            txtCode.Text = ""
            txtCode1.Value = ""
            txtStartDate.Value = ""
            txtEndDate.Value = ""
            lblDataNotFound.Visible = True
            Return
        End If

        _Setup_No = arySetup_No(2) + arySetup_No(1) + arySetup_No(0)
        txtCode1.Value = _Setup_No
        txtCode.Text = setup_no

        Dim dataReader As IDataReader = pManage.getTrailerHeaderRead(_Setup_No)
        If dataReader.Read = True Then
            txtName.Text = Convert.ToDateTime(dataReader("setup_start_date")).ToString("dd/MM/yyyy") _
                            + " - " + Convert.ToDateTime(dataReader("setup_end_date")).ToString("dd/MM/yyyy")
            txtCode1.Value = dataReader("setup_no")
            txtCode.Text = txtCode1.Value.Substring(6, 2) _
                                        + "-" + txtCode1.Value.Substring(4, 2) _
                                        + "-" + txtCode1.Value.Substring(0, 4)
            txtStartDate.Value = Convert.ToDateTime(dataReader("setup_start_date")).ToString("dd/MM/yyyy")
            txtEndDate.Value = Convert.ToDateTime(dataReader("setup_end_date")).ToString("dd/MM/yyyy")
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

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFind.Click
        ShowData()
    End Sub
End Class