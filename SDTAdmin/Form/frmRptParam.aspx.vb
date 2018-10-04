Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    ViewState("clnDateSelect") = "None"
    '    If Not IsPostBack Then
    '        ddlClnYear.Items.Clear()
    '        cDB.BindYear(ddlClnYear, 15, 0)

    '        If Hour(Now) < 6 Then
    '            clnDate.SelectedDate = Now().AddDays(-1)
    '            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")

    '        Else
    '            clnDate.SelectedDate = Now()
    '            lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    '        End If

    '        'Movie1Popup1.InStatus = "1"
    '        Movie1Popup1.MovieType = "1"
    '        Movie1Popup1.VisibleMovieType = False
    '        Movie1Popup1.BindData()
    '    End If
    '    If Mid(Session("permission"), 16, 1) = "0" Then
    '        Response.Redirect("InfoPage.aspx")
    '    End If
    'End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 16, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            If Date.Now.Hour < 6 Then
                Me.dtpStartDate.SelectedDate = Date.Today.AddDays(-1)
            Else
                Me.dtpStartDate.SelectedDate = Date.Today
            End If

            'Me.Movie1Popup1.InStatus = "1"
            Me.Movie1Popup1.MovieType = "1"
            Me.Movie1Popup1.VisibleMovieType = False
            Me.Movie1Popup1.BindData()
        End If
    End Sub

    'Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
    '    If Movie1Popup1.MovieId <> 0 Then
    '        If ViewState("clnDateSelect") <> "Select" Then
    '            Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
    '            If dataReader.Read = True Then
    '                lblDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
    '                clnDate.SelectedDate = dataReader("movie_strdate")
    '                Session("RptMovieName") = dataReader("movie_nameen")
    '                Session("RptMovieID") = Movie1Popup1.MovieId
    '            End If
    '            dataReader.Close()

    '            ViewState("clnDateSelect") = "None"
    '        End If

    '    End If
    'End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Me.Movie1Popup1.MovieId <> 0 Then
            Dim dataReader As IDataReader = cDB.getMovieDetail(Movie1Popup1.MovieId)
            If dataReader.Read = True Then
                Me.dtpStartDate.SelectedDate = dataReader("movie_strdate")
                
                Session("RptMovieName") = dataReader("movie_nameen")
                Session("RptMovieID") = Movie1Popup1.MovieId
            End If
            dataReader.Close()
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Session("RptstrDate") = Me.dtpStartDate.SelectedDate
        'Session("RptstrDate") = clnDate.SelectedDate
        'Session("RptMovieID") = ddlMovies.SelectedValue
        'Session("RptMovieName") = ddlMovies.SelectedItem.Text
        Response.Redirect("frmExportForCustomer.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    'Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    '    lblDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    '    clnDate.Visible = False
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    '    clnDate.Visible = True
    '    ViewState("clnDateSelect") = "Select"
    'End Sub

    'Protected Sub ddlClnYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYear.SelectedIndexChanged
    '    If ddlClnYear.SelectedIndex = 0 Then
    '        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    '    Else
    '        Dim intYear As String = CInt(ddlClnYear.SelectedItem.Text)
    '        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + intYear)
    '    End If
    'End Sub

End Class