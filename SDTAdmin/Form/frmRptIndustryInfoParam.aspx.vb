Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptIndustryInfoParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblerror.Visible = False
            ' ''lblerror.Visible = False
            ' ''trType1.Visible = False
            ' ''ddlSubGroup.Enabled = False
            ' ''If Not IsPostBack Then
            ' ''    If ddlGroupBy.SelectedValue = "All" Or ddlGroupBy.SelectedValue = "3" Then
            ' ''        ddlSubGroup.Enabled = True
            ' ''    Else
            ' ''        ddlSubGroup.Enabled = False
            ' ''    End If
            ' ''End If
        End If
        If Mid(Session("permission"), 33, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    ''Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    ''    If lblDate.Text.Trim() = "" Or lblDate0.Text.Trim() = "" Then
    ''        lblerror.Visible = True
    ''        Return
    ''    Else
    ''        Dim wkStrDate As String = lblDate.Text.Substring(3, 2)
    ''        Try
    ''            wkStrDate &= "/"
    ''            wkStrDate &= lblDate.Text.Substring(0, 2)
    ''            wkStrDate &= "/"
    ''            wkStrDate &= lblDate.Text.Substring(6, 4)
    ''            Dim DateStr As DateTime = Convert.ToDateTime(wkStrDate)

    ''            Dim wkEndDate As String = lblDate0.Text.Substring(3, 2)
    ''            wkEndDate &= "/"
    ''            wkEndDate &= lblDate0.Text.Substring(0, 2)
    ''            wkEndDate &= "/"
    ''            wkEndDate &= lblDate0.Text.Substring(6, 4)
    ''            Dim DateEnd As DateTime = Convert.ToDateTime(wkEndDate)

    ''            Session("RptStartDate") = DateStr
    ''            Session("RptEndDate") = DateEnd

    ''            Response.Redirect("frmRptIndustryInfo.aspx")
    ''        Catch ex As Exception
    ''            lblerror.Visible = True
    ''            Return
    ''        End Try
    ''    End If
    ''End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If dtpStartDate.Text.Trim() = "" OrElse dtpStartDate.Text.Trim() = "" Then
            lblerror.Visible = True
            Return
        Else
            Try
                Session("RptStartDate") = dtpStartDate.SelectedDate
                Session("RptEndDate") = dtpEndDate.SelectedDate

                Response.Redirect("frmRptIndustryInfo.aspx")
            Catch ex As Exception
                lblerror.Visible = True
                Return
            End Try
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub


End Class