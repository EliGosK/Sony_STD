Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_AT_Session
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 42, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                lblError.Visible = False
                ViewState("checkMode") = "ADD"
                txtQty.Text = ""
                txtAmt.Text = ""
                txtQty.Enabled = True
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "Select" Then
                Dim index As String = e.CommandArgument 'checker_level_id
                Dim strQty As String = index.Substring(0, index.IndexOf("A"))
                Dim strAmt As String = index.Substring(index.IndexOf("A") + 1)
                txtQty.Text = strQty
                txtAmt.Text = strAmt
                ViewState("checkMode") = "EDIT"
                txtQty.Enabled = False
            ElseIf e.CommandName = "Del" Then
                Dim index As String = e.CommandArgument 'checker_level_id
                Dim strQty As String = index.Substring(0, index.IndexOf("A"))
                Dim strAmt As String = index.Substring(index.IndexOf("A") + 1)

                Dim strSQL As String = "DELETE FROM tblChecker_Session WHERE session_qty = " + strQty
                Dim cDB As New cDatabase
                cDB.GetDataAll(strSQL)

                GridView1.DataBind()
                txtAmt.Text = ""
                txtQty.Text = ""
                ViewState("checkMode") = "ADD"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If txtAmt.Text.Trim() = "" Or txtQty.Text.Trim() = "" Then
                lblError.Text = "Please check require flield (*)"
                lblError.Visible = True
            Else
                Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
                If ViewState("checkMode") = "ADD" Then
                    Dim strSQL As String
                    strSQL = "Select session_amt from tblChecker_Session WHERE session_qty = " + txtQty.Text.Trim()

                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
                    If dataReader.Read = True Then
                        lblError.Text = "Session Qty. has exist!"
                        lblError.Visible = True
                    Else
                        cDB.addcollectReportConfigSession(0, Convert.ToDouble(txtQty.Text.Trim()), Convert.ToDouble(txtAmt.Text.Trim()), _
                                                          ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"), ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"))
                        txtQty.Enabled = True
                        txtQty.Text = ""
                        txtAmt.Text = ""
                        lblError.Visible = False
                        GridView1.DataBind()
                        ViewState("checkMode") = "ADD"
                    End If
                    dataReader.Close()

                Else 'Update
                    cDB.addcollectReportConfigSession(0, Convert.ToDouble(txtQty.Text.Trim()), Convert.ToDouble(txtAmt.Text.Trim()), _
                                                      ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"), ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"))
                    txtQty.Enabled = True
                    txtQty.Text = ""
                    txtAmt.Text = ""
                    lblError.Visible = False
                    GridView1.DataBind()
                    ViewState("checkMode") = "ADD"
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Try
            'GridView1.DataBind()
            'txtAmt.Text = ""
            'txtQty.Text = ""
            'txtQty.Enabled = True
            'ViewState("checkMode") = "ADD"
            Response.Redirect("frmCTBV_AT_Main.aspx")
        Catch ex As Exception

        End Try
    End Sub

End Class