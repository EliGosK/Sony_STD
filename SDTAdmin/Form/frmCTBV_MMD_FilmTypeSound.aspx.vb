Partial Public Class frmCTBV_MMD_FilmTypeSound
    Inherits System.Web.UI.Page

    Dim m_Database As Database
    Dim m_FilmTypeSoundDAL As FilmTypeSoundDAL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CheckPermission(AdminPage.Master_FilmTypeAndSound, True)

        If Not IsPostBack Then
            ''m_Database = MainApp.Database
            ''m_FilmTypeSoundDAL = New FilmTypeSoundDAL(m_Database)
            ''Dim dtLoad As DataTable = m_FilmTypeSoundDAL.LoadInfomation()
            ''Me.gvFilmTypeSound.DataSource = dtLoad
            ''Me.gvFilmTypeSound.DataBind()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class