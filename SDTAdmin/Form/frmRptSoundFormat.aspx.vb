﻿Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptSoundFormat
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    '--- Commented by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    ViewState("clnDateSelect") = "None"
    '    If Not IsPostBack Then
    '        ddlClnYearFrom.Items.Clear()
    '        cDB.BindYear(ddlClnYearFrom, 15, 0)
    '        ddlClnYearTo.Items.Clear()
    '        cDB.BindYear(ddlClnYearTo, 15, 0)

    '        If Hour(Now) < 6 Then
    '            clnDateFrom.SelectedDate = Now().AddDays(-1)
    '            lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
    '            clnDateTo.SelectedDate = Now().AddDays(+5)
    '            lblDate0.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")

    '        Else
    '            clnDateFrom.SelectedDate = Now()
    '            lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
    '            clnDateTo.SelectedDate = Now().AddDays(+6)
    '            lblDate0.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    '        End If

    '        'Movie1Popup1.InStatus = "1"
    '        Movie1Popup1.MovieType = "1"
    '        Movie1Popup1.VisibleMovieType = False
    '        Movie1Popup1.BindData()
    '    End If

    '    If Mid(Session("permission"), 23, 1) = "0" Then
    '        Response.Redirect("InfoPage.aspx")
    '    End If
    'End Sub

    '--- Added by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 23, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            If Date.Now.Hour < 6 Then
                Me.dtpStartDate.SelectedDate = Date.Today.AddDays(-1)
                Me.dtpEndDate.SelectedDate = Date.Today.AddDays(+5)
            Else
                Me.dtpStartDate.SelectedDate = Date.Today
                Me.dtpEndDate.SelectedDate = Date.Today.AddDays(+6)
            End If

            'Me.Movie1Popup1.InStatus = "1"
            Me.Movie1Popup1.MovieType = "1"
            Me.Movie1Popup1.VisibleMovieType = False
            Me.Movie1Popup1.BindData()
        End If
    End Sub

    '--- Commented by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
    'Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    '    If Movie1Popup1.MovieId <> 0 Then
    '        If ViewState("clnDateSelect") <> "Select" Then
    '            Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
    '            If dataReader.Read = True Then
    '                lblDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
    '                clnDateFrom.SelectedDate = dataReader("movie_strdate")

    '                lblDate0.Text = Format(dataReader("movie_strdate").AddDays(+6), "ddd dd-MMM-yyyy")
    '                clnDateTo.SelectedDate = dataReader("movie_strdate").AddDays(+6)

    '                Session("msRptMovieID") = Movie1Popup1.MovieId
    '                Session("msRptMovieName") = dataReader("movie_nameen")
    '            End If
    '            dataReader.Close()

    '            ViewState("clnDateSelect") = "None"
    '        End If

    '    End If
    'End Sub

    '--- Added by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Me.Movie1Popup1.MovieId <> 0 Then
            Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
            If dataReader.Read = True Then
                Me.dtpStartDate.SelectedDate = dataReader("movie_strdate")
                Me.dtpEndDate.SelectedDate = dataReader("movie_strdate").AddDays(+6)

                Session("msRptMovieID") = Movie1Popup1.MovieId
                Session("msRptMovieName") = dataReader("movie_nameen")
            End If
            dataReader.Close()
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            If (Movie1Popup1.MovieId = 0) Then
                lblError.Visible = True
                lblError.Text = "Please check require flield (*)"
                Return
            End If

            '--- Modified by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
            Session("msRptStrDate") = Me.dtpStartDate.SelectedDate
            Session("msRptEndDate") = Me.dtpEndDate.SelectedDate
            'Session("msRptStrDate") = clnDateFrom.SelectedDate
            'Session("msRptEndDate") = clnDateTo.SelectedDate
            '--- End modified by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
            'Session("msRptMovieID") = ddlMovies.SelectedValue
            'Session("msRptMovieName") = ddlMovies.SelectedItem.Text

            If ddlStatus1.SelectedValue = "Sound" And ddlStatus0.SelectedValue = "Date" Then
                Response.Redirect("frmRptSoundFormat_sd.aspx")
            ElseIf ddlStatus1.SelectedValue = "Sound" And ddlStatus0.SelectedValue = "Theater" Then
                Response.Redirect("frmRptSoundFormat_st.aspx")
            ElseIf ddlStatus1.SelectedValue = "Format" And ddlStatus0.SelectedValue = "Date" Then
                Response.Redirect("frmRptSoundFormat_fd.aspx")
            ElseIf ddlStatus1.SelectedValue = "Format" And ddlStatus0.SelectedValue = "Theater" Then
                Response.Redirect("frmRptSoundFormat_ft.aspx")
            ElseIf ddlStatus1.SelectedValue = "SoundFormat" And ddlStatus0.SelectedValue = "Date" Then
                Response.Redirect("frmRptSoundFormat_sfd.aspx")
            ElseIf ddlStatus1.SelectedValue = "SoundFormat" And ddlStatus0.SelectedValue = "Theater" Then
                Response.Redirect("frmRptSoundFormat_sft.aspx")
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    ''Protected Sub ddlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlStatus.SelectedIndexChanged
    ''    Movie1Popup1.MovieId = 0
    ''    Movie1Popup1.InStatus = ddlStatus.SelectedValue
    ''    Movie1Popup1.MovieType = "1"
    ''    Movie1Popup1.VisibleMovieType = False
    ''    Movie1Popup1.BindData()
    ''End Sub

    '--- Commented by Wittawat W. (CSI) on 20121128 : Modify datetimepicker
    'Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateFrom.SelectionChanged
    '    lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
    '    clnDateTo.SelectedDate = clnDateFrom.SelectedDate.AddDays(+6)
    '    lblDate0.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    '    clnDateFrom.Visible = False
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    '    clnDateFrom.Visible = True
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub btnCalendar0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar0.Click
    '    clnDateTo.Visible = True
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub clnDate0_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateTo.SelectionChanged
    '    lblDate0.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    '    clnDateTo.Visible = False
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub ddlClnYearFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearFrom.SelectedIndexChanged
    '    If ddlClnYearFrom.SelectedIndex = 0 Then
    '        clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    '    Else
    '        Dim intYear As String = CInt(ddlClnYearFrom.SelectedItem.Text)
    '        clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + intYear)
    '    End If
    'End Sub

    'Protected Sub ddlClnYearTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearTo.SelectedIndexChanged
    '    If ddlClnYearTo.SelectedIndex = 0 Then
    '        clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    '    Else
    '        Dim intYear As String = CInt(ddlClnYearTo.SelectedItem.Text)
    '        clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + intYear)
    '    End If
    'End Sub
    '--- End commented by Wittawat W. (CSI) on 20121128 : Modify datetimepicker

End Class