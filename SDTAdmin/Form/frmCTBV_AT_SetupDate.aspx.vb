Imports System.Web.Security
Imports Web.Data
Imports System.Drawing


Partial Class frmCTBV_AT_SetupDate
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Try
            'Put user code to initialize the page here
            If Mid(Session("permission"), 43, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If

            If (Not (Page.IsPostBack)) Then
                grdMovieSetup.DataBind()

                txtYear.Text = Convert.ToString(Date.Today.Year)
                ddlMonth.SelectedValue = Date.Today.Month.ToString("00")
                ShowData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ShowData()
        Dim strCommand As String = "select *,substring(movie_setup_no,7,2)+'-'+substring(movie_setup_no,5,2)+'-'+substring(movie_setup_no,1,4) movie_setup_no1 from [tblChecker_Movie_Setup_Hdr]"
        strCommand += " WHERE 1=1"

        If (txtYear.Text.Trim() <> "") Then
            strCommand += " AND substring(movie_setup_no,1,4)='" + txtYear.Text.Trim() + "'"
        End If
        If (ddlMonth.Text.Trim() <> "") Then
            strCommand += " AND substring(movie_setup_no,5,2)='" + ddlMonth.SelectedValue.Trim() + "'"
        End If

        strCommand += " Order by [movie_setup_no] DESC"

        sqlMovieSetup.SelectCommand = strCommand
        grdMovieSetup.DataBind()
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub


    Private Sub grdChecker_Movie_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdMovieSetup.RowDataBound
    End Sub

    Protected Sub grdChecker_Movie_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdMovieSetup.PageIndexChanging
        Me.grdMovieSetup.PageIndex = e.NewPageIndex
        Me.grdMovieSetup.DataBind()
    End Sub

    Protected Sub grdChecker_Movie_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdMovieSetup.RowCommand
        If e.CommandName = "Del" Then
            Dim movie_setup_no As Integer = Convert.ToString(e.CommandArgument)
            Dim pManage As New cDatabase()
            pManage.deleteChecker_Movie_Head(movie_setup_no)
            Me.grdMovieSetup.DataBind()
        End If

    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        ShowData()
    End Sub
End Class
