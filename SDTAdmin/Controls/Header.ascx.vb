Public Class Header
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents UserProfiles As System.Web.UI.WebControls.HyperLink
    Protected WithEvents MngUser As System.Web.UI.WebControls.HyperLink

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Page.IsPostBack = False Then
            If context.User.Identity.IsAuthenticated = True Then
                UserProfiles.Text = context.User.Identity.Name
                UserProfiles.NavigateUrl = "~/register.aspx?Usr=" & context.User.Identity.Name
                UserProfiles.Visible = True
                MngUser.NavigateUrl = "~/listuser.aspx"
                MngUser.Visible = True
            End If
        End If
    End Sub

End Class
