Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_AT_Config
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 41, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then 
                Dim strSQLcheck As String
                strSQLcheck = "SELECT TOP 1 collect_report_min_amt, collect_report_max_amt, collect_report_level_qty, collect_report_session_qty FROM tblConfig"
                Dim dataReader As IDataReader = cDB.GetDataAll(strSQLcheck)
                If dataReader.Read = True Then
                    txtMin.Text = cDB.CheckIsNullInteger(dataReader("collect_report_min_amt")).ToString()
                    txtMax.Text = cDB.CheckIsNullInteger(dataReader("collect_report_max_amt")).ToString()
                    txtLevel.Text = cDB.CheckIsNullInteger(dataReader("collect_report_level_qty")).ToString()
                    txtSesion.Text = cDB.CheckIsNullInteger(dataReader("collect_report_session_qty")).ToString()
                Else
                    txtMin.Text = ""
                    txtMax.Text = ""
                    txtLevel.Text = ""
                    txtSesion.Text = ""
                    lblError.Visible = False
                End If
                dataReader.Close()
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

  

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If txtMin.Text.Trim() = "" Or txtMax.Text.Trim() = "" Or txtLevel.Text.Trim() = "" Or txtSesion.Text.Trim() = "" Or txtLevel.Text.Trim() = "0" Or txtSesion.Text.Trim() = "0" Then
                lblError.Text = "Please check require flield (*)"
                lblError.Visible = True
            Else
                Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
                cDB.addcollectReportConfig(Convert.ToDouble(txtMin.Text.Trim()), Convert.ToDouble(txtMax.Text.Trim()), _
                                           Convert.ToDouble(txtLevel.Text.Trim()), Convert.ToDouble(txtSesion.Text.Trim()), _
                                           ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"), ConvertTimeToLocaltime(saveDatetimeNow), Session("UserID"))
                lblError.Visible = False
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        'txtMin.Text = ""
        'txtMax.Text = ""
        'lblError.Visible = False
        Response.Redirect("frmCTBV_AT_Main.aspx")
    End Sub

End Class