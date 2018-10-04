Imports System.Web.Security
Partial Class frmCTBV_Menu_MMD
    Inherits Page

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load, Me.Load
        CheckPermission(AdminPage.Menu_Master, True)

        If Not CheckPermission(AdminPage.Master_Movie, False) Then
            btnLink1.Enabled = False
            btnLink1.ImageUrl = "../images/MenuMaster1_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_Theater, False) Then
            btnLink2.Enabled = False
            btnLink2.ImageUrl = "../images/MenuMaster3_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_Distributor, False) Then
            btnLink3.Enabled = False
            btnLink3.ImageUrl = "../images/MenuMaster5_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_Studio, False) Then
            btnLink4.Enabled = False
            btnLink4.ImageUrl = "../images/MenuMaster2_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_FilmType, False) Then
            btnLink5.Enabled = False
            btnLink5.ImageUrl = "../images/MenuMaster4_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_FilmTypeAndSound, False) Then
            btnLink6.Enabled = False
            btnLink6.ImageUrl = "../images/MenuMaster6_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Master_Holiday, False) Then
            btnLink7.Enabled = False
            btnLink7.ImageUrl = "../images/MenuMaster7_disable.jpg"
        End If
    End Sub

    Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
        'FormsAuthentication.SignOut()
        'Session("UserID") = ""
        'Session("Pwd") = ""
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub BtnLink1Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink1.Click
        Response.Redirect("frmCTBV_MMD_Movie.aspx")
    End Sub

    Protected Sub BtnLink2Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink2.Click
        Response.Redirect("frmCTBV_MMD_Theater.aspx")
    End Sub

    Protected Sub BtnLink3Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink3.Click
        Response.Redirect("frmCTBV_MMD_Disdistributor.aspx")
    End Sub

    Protected Sub BtnLink4Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink4.Click
        Response.Redirect("frmCTBV_MMD_Studio.aspx")
    End Sub

    Protected Sub BtnLink5Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink5.Click
        Response.Redirect("frmCTBV_MMD_FilmType.aspx")
    End Sub

    Protected Sub BtnLink6Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnLink6.Click
        Response.Redirect("frmCTBV_MMD_FilmTypeSound.aspx")
    End Sub

    Protected Sub btnLink7_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLink7.Click
        Response.Redirect("frmCTBV_MMD_Holiday.aspx")
    End Sub

End Class
