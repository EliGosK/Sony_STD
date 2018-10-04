Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptTheatreInformationParam
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
    ''    If lblDate.Text.Trim() = "" Then 'Or lblDate0.Text.Trim() = "" 

    ''        lblerror.Visible = True
    ''        lblerror.Text = "Please check require flield (*)"
    ''        Return
    ''    Else
    ''        Try
    ''            Dim wkStrDateChk As String = lblDate.Text.Substring(6, 4)
    ''            wkStrDateChk &= lblDate.Text.Substring(3, 2)
    ''            wkStrDateChk &= lblDate.Text.Substring(0, 2)
    ''            Dim DateChkStr As Double = Convert.ToDouble(wkStrDateChk)
    ''            If DateChkStr < 20080101 Then
    ''                lblerror.Visible = True
    ''                lblerror.Text = "Please input date not less than 01/01/2008."
    ''            Else

    ''                Dim wkStrDate As String = lblDate.Text.Substring(3, 2)
    ''                wkStrDate &= "/"
    ''                wkStrDate &= lblDate.Text.Substring(0, 2)
    ''                wkStrDate &= "/"
    ''                wkStrDate &= lblDate.Text.Substring(6, 4)
    ''                Dim DateStr As DateTime = Convert.ToDateTime(wkStrDate)

    ''                Session("msRptStrDate") = DateStr
    ''                Session("msRptEndDate") = DateStr

    ''                Response.Redirect("frmRptTheatreInformation.aspx")

    ''            End If
    ''        Catch ex As Exception
    ''            lblerror.Visible = True
    ''            Return
    ''        End Try
    ''    End If
    ''End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If dtpStartDate.Text.Trim() = "" Then 'Or dtpEndDate.Text.Trim() = "" 
            lblerror.Visible = True
            lblerror.Text = "Please check require flield (*)"
            Return
        Else
            Try
                If dtpStartDate.SelectedDate < New Date(2008, 1, 1) Then
                    lblerror.Visible = True
                    lblerror.Text = "Please input date not less than 01/01/2008."
                Else
                    Session("msRptStrDate") = dtpStartDate.SelectedDate
                    Session("msRptEndDate") = dtpStartDate.SelectedDate

                    Response.Redirect("frmRptTheatreInformation.aspx")
                End If
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