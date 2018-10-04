Imports System.Web.Security
Partial Class frmCTBV_Menu_Ticket
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
        CheckPermission(AdminPage.Menu_Ticket, True)
        If Not CheckPermission(AdminPage.Ticket_FreeTicketAndPerCap, False) Then
            ibnTicket1.Enabled = False
            ibnTicket1.ImageUrl = "../images/MenuTicket1_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Ticket_FreeTicketAndPerCapByMovie, False) Then
            ibnTicket2.Enabled = False
            ibnTicket2.ImageUrl = "../images/MenuTicket2_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Ticket_TicketType, False) Then
            ibnTicket3.Enabled = False
            ibnTicket3.ImageUrl = "../images/MenuTicket3_disable.jpg"
        End If
        If Not CheckPermission(AdminPage.Ticket_TicketTypeByMovie, False) Then
            ibnTicket4.Enabled = False
            ibnTicket4.ImageUrl = "../images/MenuTicket4_disable.jpg"
        End If
    End Sub

    Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class
