Imports System.Web.Security
Imports Web.Data
Imports System.Drawing


Partial Public Class frmCTBV_Trailer_Setup_Detail
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 12, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If (Not (Page.IsPostBack)) Then
            grdTrailer.DataBind()

            txtYear.Text = Convert.ToString(Date.Today.Year)
            ddlMonth.SelectedValue = Date.Today.Month.ToString("00")
            ShowData()
        End If
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

        sqlTrailer.SelectCommand = strCommand
        grdTrailer.DataBind()
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub


    Private Sub grdTrailer_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTrailer.RowDataBound


        'If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
        '    'e.Row.Cells(0).Attributes("border-top") = "2"
        '    'e.Row.Cells(0).Attributes("border-bottom-color") = "#0000ff"

        '    e.Row.Cells(0).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:5px"
        '    e.Row.Cells(1).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:5px"
        '    e.Row.Cells(2).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:5px"

        '    'e.Row.Cells(0).Style("color") = "border-width: 2px; border-color: #0033CC; border-top-style: solid"
        '    'e.Row.Cells(0).Style("color") = "border-width: 2px; border-color: #0033CC; border-top-style: solid"
        '    'e.Row.Cells(0).Attributes("border-bottom-color") = "#0000ff"

        '    'e.Row.Cells(0).Text = "______________________________"
        '    'e.Row.Cells(0).BorderWidth = "#0000ff"

        '    'e.Row.BorderWidth = 2
        '    'e.Row.Cells(0).BorderStyle = BorderStyle.Solid
        '    'e.Row.Cells(0).BorderWidth = 2
        '    'e.Row.Cells(0).BorderColor = Color.Blue

        '    'Style = "border-top:2px;border-bottom-color:#0000ff"
        'End If


        'If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

        '    Dim dr As Data.DataRowView = e.Row.DataItem

        '    If dr(9) = "S" Then

        '        ' e.Row.BackColor = Color.LightGoldenrodYellow
        '        'e.Row.Font.Bold = False
        '        e.Row.ForeColor = Color.Green
        '    ElseIf dr(9) = "T" Then

        '        ' e.Row.BackColor = Color.DarkSeaGreen
        '        'e.Row.Font.Bold = True
        '        e.Row.ForeColor = Color.DarkGray
        '    Else
        '        ' e.Row.BackColor = Color.LightSteelBlue
        '        'e.Row.Font.Bold = True
        '        e.Row.ForeColor = Color.LightGray 'LightGray
        '    End If
        '    If dr(4) = "CTBV" Then
        '        'e.Row.BackColor = Color.Lavender
        '        e.Row.Font.Bold = True
        '    Else

        '        'e.Row.BackColor = Color.WhiteSmoke
        '        e.Row.Font.Bold = False

        '    End If

        'End If


        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    Dim strBgCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_background_color")).Trim()
        '    Dim strFontCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_font_color")).Trim()

        '    If (strBgCode <> "") Then
        '        e.Row.Cells(3).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
        '    Else
        '        e.Row.Cells(3).BackColor = System.Drawing.Color.White
        '    End If

        '    If (strFontCode <> "") Then
        '        e.Row.Cells(3).ForeColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_font_color"))
        '    Else
        '        e.Row.Cells(3).ForeColor = System.Drawing.Color.Black
        '    End If

        '    'e.Row.Cells(2).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
        'End If


    End Sub

    Protected Sub grdTrailer_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdTrailer.PageIndexChanging
        Me.grdTrailer.PageIndex = e.NewPageIndex
        Me.grdTrailer.DataBind()
    End Sub

    Protected Sub grdTrailer_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdTrailer.RowCommand

        'If e.CommandName = "Select" Then
        '    Dim Movie_Id As Integer = Convert.ToInt32(e.CommandArgument)

        '    Dim pManage As New cDatabase()

        '    Dim getMovieDetail As New cDatabase
        '    Dim dataReader As IDataReader = getMovieDetail.getTrailerDetail(Movie_Id)
        '    If dataReader.Read = True Then
        '        Movie1Popup1.MovieId = Convert.ToInt32(dataReader("movie_id"))
        '        SelectColor1.ColorCode = Convert.ToString(dataReader("movie_background_color"))
        '        SelectColor2.ColorCode = Convert.ToString(dataReader("movie_font_color"))
        '        'txtName.Text = dataReader("movie_nameen") + "/" + dataReader("movie_nameth")
        '    End If
        '    dataReader.Close()

        '    txtId.Value = Movie_Id.ToString()

        '    Movie1Popup1.Enabled = False
        If e.CommandName = "Del" Then
            Dim setup_no As Integer = Convert.ToString(e.CommandArgument)
            Dim pManage As New cDatabase()
            pManage.deleteTrailer_Head(setup_no)
            Me.grdTrailer.DataBind()
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ShowData()
    End Sub
End Class
