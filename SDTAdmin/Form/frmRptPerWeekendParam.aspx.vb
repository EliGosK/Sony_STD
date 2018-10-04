Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptPerWeekendParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''    If Mid(Session("permission"), 19, 1) = "0" Then
    ''        Response.Redirect("InfoPage.aspx")
    ''    End If
    ''    If Not IsPostBack Then
    ''        '---1
    ''        ddlClnYear.Items.Clear()
    ''        cDB.BindYear(ddlClnYear, 15, 0)
    ''        '---
    ''        Dim wkDayToday As String
    ''        If Hour(Now) < 6 Then
    ''            clnDate.SelectedDate = Now().AddDays(-1)
    ''            wkDayToday = Format(clnDate.SelectedDate, "ddd")
    ''            Select Case wkDayToday
    ''                Case "Sun"
    ''                    clnDate.SelectedDate = Now().AddDays(-1)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Mon"
    ''                    clnDate.SelectedDate = Now().AddDays(-2)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Tue"
    ''                    clnDate.SelectedDate = Now().AddDays(-3)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Wed"
    ''                    clnDate.SelectedDate = Now().AddDays(-4)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Thu"
    ''                    clnDate.SelectedDate = Now().AddDays(-5)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Fri"
    ''                    clnDate.SelectedDate = Now().AddDays(-6)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Sat"
    ''                    clnDate.SelectedDate = Now().AddDays(-7)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case Else
    ''                    clnDate.SelectedDate = Now()
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''            End Select
    ''        Else
    ''            clnDate.SelectedDate = Now()
    ''            wkDayToday = Format(clnDate.SelectedDate, "ddd")
    ''            Select Case wkDayToday
    ''                Case "Sun"
    ''                    clnDate.SelectedDate = Now()
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Mon"
    ''                    clnDate.SelectedDate = Now().AddDays(-1)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Tue"
    ''                    clnDate.SelectedDate = Now().AddDays(-2)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Wed"
    ''                    clnDate.SelectedDate = Now().AddDays(-3)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Thu"
    ''                    clnDate.SelectedDate = Now().AddDays(-4)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Fri"
    ''                    clnDate.SelectedDate = Now().AddDays(-5)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case "Sat"
    ''                    clnDate.SelectedDate = Now().AddDays(-6)
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''                Case Else
    ''                    clnDate.SelectedDate = Now()
    ''                    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''            End Select
    ''        End If
    ''    End If
    ''End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 19, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            Dim wkDayToday As String

            If Hour(Now) < 6 Then
                dtpStartDate.SelectedDate = Today.AddDays(-1)
                wkDayToday = String.Format("{0:ddd}", dtpStartDate.SelectedDate)
                Select Case wkDayToday
                    Case "Sun"
                        dtpStartDate.SelectedDate = Today.AddDays(-1)
                    Case "Mon"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-1)
                    Case "Tue"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-2)
                    Case "Wed"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-3)
                    Case "Thu"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-4)
                    Case "Fri"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-5)
                    Case "Sat"
                        dtpStartDate.SelectedDate = Today.AddDays(-1).AddDays(-6)
                    Case Else
                        dtpStartDate.SelectedDate = Today.AddDays(-1)
                End Select
            Else
                dtpStartDate.SelectedDate = Today
                wkDayToday = String.Format("{0:ddd}", dtpStartDate.SelectedDate)
                Select Case wkDayToday
                    Case "Sun"
                        dtpStartDate.SelectedDate = Today
                    Case "Mon"
                        dtpStartDate.SelectedDate = Today.AddDays(-1)
                    Case "Tue"
                        dtpStartDate.SelectedDate = Today.AddDays(-2)
                    Case "Wed"
                        dtpStartDate.SelectedDate = Today.AddDays(-3)
                    Case "Thu"
                        dtpStartDate.SelectedDate = Today.AddDays(-4)
                    Case "Fri"
                        dtpStartDate.SelectedDate = Today.AddDays(-5)
                    Case "Sat"
                        dtpStartDate.SelectedDate = Today.AddDays(-6)
                    Case Else
                        dtpStartDate.SelectedDate = Today
                End Select
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    ''Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    ''    Session("msRptStrDate") = clnDate.SelectedDate.ToString("MM/dd/yyyy")
    ''    'Session("msRptStrDate") = clnDate.SelectedDate
    ''    Session("msRptNumDay") = ddlStatus0.SelectedValue
    ''    'Session("msRptMovieID") = ddlMovies.SelectedValue
    ''    'Session("msRptMovieName") = ddlMovies.SelectedItem.Text
    ''    Response.Redirect("frmRptPerWeekendSunday.aspx")
    ''End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Session("msRptStrDate") = String.Format("{0:MM/dd/yyyy}", dtpStartDate.SelectedDate)
        Session("msRptNumDay") = ddlStatus0.SelectedValue
        Response.Redirect("frmRptPerWeekendSunday.aspx")
    End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    ''    Dim wkDayToday As String
    ''    wkDayToday = Format(clnDate.SelectedDate, "ddd")
    ''    Select Case wkDayToday
    ''        Case "Sun"
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Mon"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-1)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Tue"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-2)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Wed"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-3)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Thu"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-4)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Fri"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-5)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case "Sat"
    ''            clnDate.SelectedDate = clnDate.SelectedDate.AddDays(-6)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Case Else
    ''            clnDate.SelectedDate = clnDate.SelectedDate
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''    End Select
    ''    clnDate.Visible = False
    ''End Sub

    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    clnDate.Visible = True
    ''End Sub

    ' ''---2
    ''Protected Sub ddlClnYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYear.SelectedIndexChanged
    ''    If ddlClnYear.SelectedIndex = 0 Then
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    ''    Else
    ''        Dim intYear As String = CInt(ddlClnYear.SelectedItem.Text)
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + intYear)
    ''    End If
    ''End Sub
    ' ''---
End Class