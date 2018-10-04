Imports System.Diagnostics
Imports System.Web.Security

Partial Class frmCTBV_MMD_Theater
    Inherits Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As Object

    Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 27, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub grdTheater_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdTheater.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            If (ViewState("ChangeCircuit") Is Nothing) Then
                ViewState("ChangeCircuit") = (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())
            Else
                If (Convert.ToString(ViewState("ChangeCircuit")).Trim() <> (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())) Then
                    e.Row.Cells(0).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(1).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(2).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(3).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(4).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(5).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(6).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    e.Row.Cells(7).Style(0) = "border-width: 1px; border-color: #16255d; border-top-style: solid;pading-top:10px"
                    ViewState("ChangeCircuit") = (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())
                End If
            End If
        End If
    End Sub
End Class
