Imports System.Web.Security

Namespace Form
    Partial Class FrmCtbvMenuVpf
        Inherits Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load, Me.Load
            CheckPermission(AdminPage.Menu_Vpf, True)
            If Not CheckPermission(AdminPage.Menu_Vpf_ProblemRecord, False) Then
                ibnProblemRecord.Enabled = False
                ibnProblemRecord.ImageUrl = "../images/MenuVPFProblem_disable.jpg"
            End If
            If Not CheckPermission(AdminPage.Menu_Vpf_MovieDefaultSet, False) Then
                ibnMovieDefaultSet.Enabled = False
                ibnMovieDefaultSet.ImageUrl = "../images/MenuVPFDefaultSet_disable.jpg"
            End If
            If Not CheckPermission(AdminPage.Menu_Vpf_ManageMovieSet, False) Then
                ibnManageSet.Enabled = False
                ibnManageSet.ImageUrl = "../images/MenuVPFManage_disable.jpg"
            End If
            If Not CheckPermission(AdminPage.Menu_Vpf_Summary, False) Then
                ibnVPFSummary.Enabled = False
                ibnVPFSummary.ImageUrl = "../images/MenuVPFSummary_disable.jpg"
            End If
        End Sub

        Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectToLoginPage()
        End Sub

    End Class
End Namespace