Imports System.Web.Security
Partial Class frmCTBV_MMD_Movie
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 26, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        'If IsPostBack Then
        '    GridView1.DataSourceID = "sqlMovies"
        '    GridView1.DataBind()
        'End If
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click

        If txtMovies.Text = "" And ddlStatus.SelectedValue <> 99 Then
            GridView1.DataSourceID = "SqlSearchByStatus"
        ElseIf txtMovies.Text = "" And ddlStatus.SelectedValue = 99 Then
            GridView1.DataSourceID = "sqlMoviesAll"
        ElseIf txtMovies.Text <> "" And ddlStatus.SelectedValue = 99 Then
            GridView1.DataSourceID = "SqlSearchByText"
        ElseIf txtMovies.Text <> "" And ddlStatus.SelectedValue <> 99 Then
            GridView1.DataSourceID = "SqlSearchByTextStatus"
        End If

        GridView1.DataBind()
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            Dim dr As Data.DataRowView = e.Row.DataItem
            Dim wkT As String = dr("appear_status_id").ToString
            If wkT = "2" Then
                e.Row.ForeColor = Color.Orange
            ElseIf wkT = "3" Then
                e.Row.ForeColor = Color.Red
            ElseIf dr(9) = "R" Then
                'e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.LightGray
            ElseIf dr(9) = "S" Then
                'e.Row.BackColor = Color.LightGoldenrodYellow
                'e.Row.Font.Bold = False
                e.Row.ForeColor = Color.Green
            ElseIf dr(9) = "T" Then
                'e.Row.BackColor = Color.DarkSeaGreen
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.DarkGray
            Else
                'e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Red
            End If


            'e.Row.BackColor = Color.LightGoldenrodYellow
            'e.Row.Font.Bold = False




            If dr(4) = "CTBV" Then
                'e.Row.BackColor = Color.Lavender
                e.Row.Font.Bold = True
            Else

                'e.Row.BackColor = Color.WhiteSmoke
                e.Row.Font.Bold = False

            End If

        End If
    End Sub



End Class
