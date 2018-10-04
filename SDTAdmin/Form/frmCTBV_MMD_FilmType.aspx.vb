Partial Public Class frmCTBV_MMD_FilmType
    Inherits System.Web.UI.Page

    Dim m_Database As Database
    Dim m_FilmTypeDAL As FilmTypeDAL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckPermission(AdminPage.Master_FilmType, True)

        If Not IsPostBack Then
            ''m_Database = MainApp.Database
            ''m_FilmTypeDAL = New FilmTypeDAL(m_Database)
            ''Dim dt As DataTable = m_FilmTypeDAL.LoadInfomation()
            ''Me.gvFilmType.DataSource = dt
            ''Me.gvFilmType.DataBind()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class