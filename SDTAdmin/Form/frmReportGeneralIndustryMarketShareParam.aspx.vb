Option Strict On

Imports System.Web.Security

Namespace Form
    Partial Public Class FrmReportGeneralIndustryMarketShareParam
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            CheckPermission(AdminPage.Report_GeneralIndustryMarketShare, True)
            lblerror.Visible = False
            'dtpStartDate.SelectedDate = New Date(2012, 10, 1)
            'dtpEndDate.SelectedDate = New Date(2013, 1, 31)
        End Sub

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmCTBV_RC_Menu.aspx")
        End Sub

        Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectToLoginPage()
        End Sub

        Protected Sub DdlGroupBySelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) _
            Handles ddlReportOf.SelectedIndexChanged
            ddlGroup.Visible = ddlReportOf.SelectedValue = "All" OrElse ddlReportOf.SelectedValue = "Studio"
        End Sub

        Protected Sub BtnSubmitClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
            If dtpStartDate.Text.Trim() = String.Empty OrElse dtpEndDate.Text.Trim() = String.Empty Then
                lblerror.Visible = True
            Else
                If ddlReportOf.SelectedValue = "Studio" Then
                    Response.Redirect( _
                        "frmReportGeneralIndustryMarketShare.aspx?groupby=" & ddlReportOf.SelectedValue & _
                        "&subgroup=" & ddlGroup.SelectedValue & _
                        "&datetype=" & rdoDateType.SelectedValue & "&datefrom=" & _
                        dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&dateto=" & _
                        dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd"))
                Else
                    Response.Redirect( _
                        "frmReportGeneralIndustryMarketShare.aspx?groupby=" & _
                        DirectCast(IIf(ddlGroup.Visible, ddlGroup.SelectedValue, ddlReportOf.SelectedValue), String) & _
                        "&datetype=" & rdoDateType.SelectedValue & "&datefrom=" & _
                        dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&dateto=" & _
                        dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd"))
                End If
            End If
        End Sub
    End Class
End Namespace