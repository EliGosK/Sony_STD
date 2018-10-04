Imports System.Web.Security
Imports Web.Data
Imports System.Drawing

Partial Public Class frmCTBV_Trailer_Show
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 13, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub


    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then

            If (ViewState("ChangeCircuit") Is Nothing) Then
                ViewState("ChangeCircuit") = (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())
            Else
                If (Convert.ToString(ViewState("ChangeCircuit")).Trim() <> (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())) Then
                    e.Row.Cells(0).Style(0) = "border-width: 1px; border-color: #cccccc; border-top-style: solid"
                    e.Row.Cells(1).Style(0) = "border-width: 1px; border-color: #cccccc; border-top-style: solid"
                    e.Row.Cells(2).Style(0) = "border-width: 1px; border-color: #cccccc; border-top-style: solid"
                    e.Row.Cells(3).Style(0) = "border-width: 1px; border-color: #cccccc; border-top-style: solid"
                    ViewState("ChangeCircuit") = (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "circuit_id")).Trim())
                End If
            End If
        End If
    End Sub
End Class