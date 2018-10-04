Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptMarketSareByPeriodParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblerror.Visible = False
            trType1.Visible = False
            ddlSubGroup.Enabled = False
            If Not IsPostBack Then
                If ddlGroupBy.SelectedValue = "All" Or ddlGroupBy.SelectedValue = "3" Then
                    ddlSubGroup.Enabled = True
                Else
                    ddlSubGroup.Enabled = False
                End If
            End If
            'If Hour(Now) < 6 Then
            '    '' ''clnDate.SelectedDate = Now().AddDays(-1)
            '    '' ''lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
            '    '' ''clnDate0.SelectedDate = Now() '.AddDays(+5)
            '    '' ''lblDate0.Text = Format(clnDate0.SelectedDate, "ddd dd-MMM-yyyy")

            'Else
            '    '' ''clnDate.SelectedDate = Now()
            '    '' ''lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
            '    '' ''clnDate0.SelectedDate = Now() '.AddDays(+6)
            '    '' ''lblDate0.Text = Format(clnDate0.SelectedDate, "ddd dd-MMM-yyyy")
            'End If
        End If
        If Mid(Session("permission"), 22, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

 
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        If dtpStartDate.Text.Trim() = "" Or dtpEndDate.Text.Trim() = "" Then
            lblerror.Visible = True
        Else
            ''Dim wkStrDate As String = lblDate.Text.Substring(3, 2)
            ''wkStrDate &= "/"
            ''wkStrDate &= lblDate.Text.Substring(0, 2)
            ''wkStrDate &= "/"
            ''wkStrDate &= lblDate.Text.Substring(6, 4)
            ''Dim DateStr As DateTime = Convert.ToDateTime(wkStrDate)

            ''Dim wkEndDate As String = lblDate0.Text.Substring(3, 2)
            ''wkEndDate &= "/"
            ''wkEndDate &= lblDate0.Text.Substring(0, 2)
            ''wkEndDate &= "/"
            ''wkEndDate &= lblDate0.Text.Substring(6, 4)
            ''Dim DateEnd As DateTime = Convert.ToDateTime(wkEndDate)

            Session("msRptStrDate") = dtpStartDate.SelectedDate
            Session("msRptEndDate") = dtpEndDate.SelectedDate
            Session("msRptType") = ddlType.SelectedValue
            Session("msRptSubGroup") = ddlSubGroup.SelectedValue ' 1=Theater, 2=Circuit
            Session("msRptDateType") = rdlDateType.SelectedValue ' 1=Release Date, 2=Box Office in Date

            If ddlGroupBy.SelectedValue = "1" Then 'Nationality
                Response.Redirect("frmRptMarketSareByPeriodNation.aspx")
            ElseIf ddlGroupBy.SelectedValue = "2" Then 'Distributor
                Response.Redirect("frmRptMarketSareByPeriodDist.aspx")
                'Else 'Studio '0=All, 1=Circuit, 2=Theatre
                '    If ddlSubGroup.SelectedValue = 0 Then
                '        Response.Redirect("frmRptMarketSareByPeriodStudio.aspx")
                '    ElseIf ddlSubGroup.SelectedValue = 1 Then
                '        Response.Redirect("frmRptMarketSareByPeriodStudioOnlyCircuitTheatre.aspx")
                '    Else
                '        Response.Redirect("frmRptMarketSareByPeriodStudioOnlyCircuit.aspx")
                '    End If
            ElseIf ddlGroupBy.SelectedValue = "3" Then 'Studio 1=Theatre, 2=Circuit
                If ddlSubGroup.SelectedValue = 1 Then
                    Response.Redirect("frmRptMarketSareByPeriodStudioC.aspx")
                ElseIf ddlSubGroup.SelectedValue = 2 Then
                    Response.Redirect("frmRptMarketSareByPeriodStudio.aspx")
                End If
            Else 'All 1=Theatre, 2=Circuit
                If ddlSubGroup.SelectedValue = 1 Then
                    Response.Redirect("frmRptMarketSareByPeriodAllTheatre.aspx")
                ElseIf ddlSubGroup.SelectedValue = 2 Then
                    Response.Redirect("frmRptMarketSareByPeriodAllCircuit.aspx")
                End If
            End If
        End If
    End Sub

    '' ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    '' ''    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    '' ''    'clnDate0.SelectedDate = clnDate.SelectedDate '.AddDays(+6)
    '' ''    'lblDate0.Text = Format(clnDate0.SelectedDate, "ddd dd-MMM-yyyy")
    '' ''    clnDate.Visible = False

    '' ''End Sub

    '' ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    '' ''    clnDate.Visible = True

    '' ''End Sub

    '' ''Protected Sub btnCalendar0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar0.Click
    '' ''    clnDate0.Visible = True

    '' ''End Sub

    '' ''Protected Sub clnDate0_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate0.SelectionChanged
    '' ''    lblDate0.Text = Format(clnDate0.SelectedDate, "ddd dd-MMM-yyyy")
    '' ''    clnDate0.Visible = False
    '' ''End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")

    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub ddlGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlGroupBy.SelectedIndexChanged
        If ddlGroupBy.SelectedValue = "All" Or ddlGroupBy.SelectedValue = "3" Then
            ddlSubGroup.Enabled = True
        Else
            ddlSubGroup.Enabled = False
        End If
    End Sub

End Class