Imports System.Web.Security
Imports Web.Data

Partial Class frmCTBV_Menu
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
        'Check Permission
        Dim getUserDetail As New cDatabase
        Dim dataReader As IDataReader = getUserDetail.getUserDetail(Session("UserID"))
        If dataReader.Read Then
            Session("permission") = dataReader("user_permission")

            imbtnBoxOffice.Enabled = CheckPermission(AdminPage.Menu_BoxOffice, False)
            imbtnBoxOffice.BorderColor = IIf(imbtnBoxOffice.Enabled, Color.Orange, Color.LightGray)
            imbtnBoxOffice.ImageUrl = IIf(imbtnBoxOffice.Enabled, "~/images/MenuMain1.jpg", "~/images/MenuMain1_disable.jpg")

            imbtnTrialer.Enabled = CheckPermission(AdminPage.Menu_Trailer, False)
            imbtnTrialer.BorderColor = IIf(imbtnTrialer.Enabled, Color.Orange, Color.LightGray)
            imbtnTrialer.ImageUrl = IIf(imbtnTrialer.Enabled, "~/images/MenuMain3.jpg", "~/images/MenuMain3_disable.jpg")

            imbtnMasterData.Enabled = CheckPermission(AdminPage.Menu_Master, False)
            imbtnMasterData.BorderColor = IIf(imbtnMasterData.Enabled, Color.Orange, Color.LightGray)
            imbtnMasterData.ImageUrl = IIf(imbtnMasterData.Enabled, "~/images/MenuMain2.jpg", "~/images/MenuMain2_disable.jpg")

            imbtnAdmintool.Enabled = CheckPermission(AdminPage.Menu_Admin, False)
            imbtnAdmintool.BorderColor = IIf(imbtnAdmintool.Enabled, Color.Orange, Color.LightGray)
            imbtnAdmintool.ImageUrl = IIf(imbtnAdmintool.Enabled, "~/images/MenuMain4.jpg", "~/images/MenuMain4_disable.jpg")

            imbtnTicket.Enabled = CheckPermission(AdminPage.Menu_Ticket, False)
            imbtnTicket.BorderColor = IIf(imbtnTicket.Enabled, Color.Orange, Color.LightGray)
            imbtnTicket.ImageUrl = IIf(imbtnTicket.Enabled, "~/images/MenuMain5.jpg", "~/images/MenuMain5_disable.jpg")

            imbtnReportCenter.Enabled = CheckPermission(AdminPage.Menu_Report, False)
            imbtnReportCenter.BorderColor = IIf(imbtnReportCenter.Enabled, Color.Orange, Color.LightGray)
            imbtnReportCenter.ImageUrl = IIf(imbtnReportCenter.Enabled, "~/images/MenuMain6.jpg", "~/images/MenuMain6_disable.jpg")

            imbtnVpf.Enabled = CheckPermission(AdminPage.Menu_Vpf, False)
            imbtnVpf.BorderColor = IIf(imbtnVpf.Enabled, Color.Orange, Color.LightGray)
            imbtnVpf.ImageUrl = IIf(imbtnVpf.Enabled, "~/images/MenuVPF.jpg", "~/images/MenuVPF_disable.jpg")
        End If
        dataReader.Close()
    End Sub

    'Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
    '    FormsAuthentication.RedirectToLoginPage()
    'End Sub

    Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub ImbtnBoxOfficeClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnBoxOffice.Click
        Response.Redirect("frmRevenueMonitor.aspx")
    End Sub
    Protected Sub ImbtnMasterDataClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnMasterData.Click
        Response.Redirect("frmCTBV_Menu_MMD.aspx")
    End Sub

    Protected Sub ImbtnAdmintoolClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnAdmintool.Click
        Response.Redirect("frmCTBV_AT_Main.aspx")
    End Sub

    Protected Sub ImbtnReportCenterClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnReportCenter.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub ImbtnTrialerClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnTrialer.Click
        Response.Redirect("frmCTBV_Menu_Trailer.aspx")
    End Sub

    Protected Sub ImbtnInventoryClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnTicket.Click
        Response.Redirect("frmCTBV_Menu_Ticket.aspx")
    End Sub

    Protected Sub ImbtnVpfClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbtnVpf.Click
        Response.Redirect("frmCTBV_Menu_VPF.aspx")
    End Sub
End Class
