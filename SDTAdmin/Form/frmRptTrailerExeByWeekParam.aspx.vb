Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptTrailerExeByWeekParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''    ViewState("clnDateSelect") = "None"
    ''    If Not IsPostBack Then
    ''        ddlClnYear.Items.Clear()
    ''        cDB.BindYear(ddlClnYear, 15, 0)

    ''        If Hour(Now) < 6 Then
    ''            clnDate.SelectedDate = Now().AddDays(-1)
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Else
    ''            clnDate.SelectedDate = Now()
    ''            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''        End If
    ''    End If
    ''    If Mid(Session("permission"), 7, 1) = "0" Then
    ''        Response.Redirect("InfoPage.aspx")
    ''    End If
    ''End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            If Hour(Now) < 6 Then
                Me.dtpStartDate.SelectedDate = Today.AddDays(-1)
            Else
                Me.dtpStartDate.SelectedDate = Today
            End If
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'If Movie1Popup1.MovieId <> 0 Then
        '    If ViewState("clnDateSelect") <> "Select" Then
        '        Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
        '        If dataReader.Read = True Then
        '            lblDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
        '            clnDate.SelectedDate = dataReader("movie_strdate")
        '            Session("RptMovieName") = dataReader("movie_nameen")
        '            Session("RptMovieID") = Movie1Popup1.MovieId
        '        End If
        '        dataReader.Close()

        '        ViewState("clnDateSelect") = "None"
        '    End If
        'End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ''Dim dtStartDate As DateTime = clnDate.SelectedDate
        Dim dtStartDate As DateTime = Me.dtpStartDate.SelectedDate
        While (dtStartDate.DayOfWeek <> DayOfWeek.Thursday)
            dtStartDate = dtStartDate.AddDays(-1)
        End While
        Session("RptstrDate") = dtStartDate
        Session("PeriodWeek") = ddlSelectPeriod.SelectedValue
        Response.Redirect("frmRptTrailerExeByWeek.aspx")

        'Response.Redirect("frmRptTrailerExeByWeek.aspx?date=" + clnDate.SelectedDate.ToString("dd/MM/yyyy") + "&periodweek=" + ddlSelectPeriod.SelectedValue)
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_Menu_Trailer_Rpt.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    ''    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''    clnDate.Visible = False
    ''    ViewState("clnDateSelect") = "Select"
    ''End Sub

    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    clnDate.Visible = True
    ''    ViewState("clnDateSelect") = "Select"
    ''End Sub

    ''Protected Sub ddlClnYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYear.SelectedIndexChanged
    ''    If ddlClnYear.SelectedIndex = 0 Then
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    ''    Else
    ''        Dim intYear As String = CInt(ddlClnYear.SelectedItem.Text)
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + intYear)
    ''    End If
    ''End Sub

End Class