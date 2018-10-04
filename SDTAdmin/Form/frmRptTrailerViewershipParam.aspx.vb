Imports Web.Data
Imports System.Web.Security
Partial Public Class frmRptTrailerViewershipParam
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Visible = False
        If Not IsPostBack Then
            Label1.Text = ""
            'lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy")
            'lblDate0.Text = DateTime.Today.ToString("dd/MM/yyyy")
        End If
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_Menu_Trailer_Rpt.aspx")

    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    'Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
    '    Try
    '        'If (Movie1Popup1.MovieId = 0 And lblDate.Text.Trim() = "") Then
    '        '    Label1.Text = "Please Input Data"
    '        '    Label1.Visible = True
    '        '    Return
    '        'End If

    '        If (lblDate.Text.Trim() = "" And lblDate0.Text.Trim() = "" And Movie1Popup1.MovieId = 0) Then
    '            Label1.Text = "Please select one of the Title I.D. or Release Date."
    '            Label1.Visible = True
    '            Return
    '        End If

    '        If (lblDate.Text.Trim() <> "" And Movie1Popup1.MovieId <> 0) Then
    '            Label1.Text = "Please select one of the Title I.D. or Release Date."
    '            Label1.Visible = True
    '            Return
    '        End If

    '        Dim StartDate As String = ""
    '        Dim EndDate As String = ""
    '        If (lblDate.Text.Trim() <> "") Then
    '            StartDate = lblDate.Text.Substring(6, 4)
    '            StartDate &= "/"
    '            StartDate &= lblDate.Text.Substring(3, 2)
    '            StartDate &= "/"
    '            StartDate &= lblDate.Text.Substring(0, 2)
    '        End If

    '        If (lblDate0.Text.Trim() <> "") Then
    '            EndDate = lblDate0.Text.Substring(6, 4)
    '            EndDate &= "/"
    '            EndDate &= lblDate0.Text.Substring(3, 2)
    '            EndDate &= "/"
    '            EndDate &= lblDate0.Text.Substring(0, 2)
    '        End If

    '        Session("msRptStrDate") = StartDate
    '        Session("msRptEndDate") = EndDate
    '        If (Movie1Popup1.MovieId = 0) Then
    '            Session("rptRealMovie") = "null"
    '        Else
    '            Session("rptRealMovie") = Movie1Popup1.MovieId
    '        End If

    '        Response.Redirect("frmRptTrailerViewership.aspx")
    '    Catch ex As Exception
    '        Label1.Text = ex.Message
    '    End Try
    'End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        Try
            'If (Movie1Popup1.MovieId = 0 And lblDate.Text.Trim() = "") Then
            '    Label1.Text = "Please Input Data"
            '    Label1.Visible = True
            '    Return
            'End If

            If (Me.dtpStartDate.Text.Trim() = "" And Me.dtpStartDate.Text.Trim() = "" And Movie1Popup1.MovieId = 0) Then
                Label1.Text = "Please select one of the Title I.D. or Release Date."
                Label1.Visible = True
                Return
            End If

            If (Me.dtpStartDate.Text.Trim() <> "" And Movie1Popup1.MovieId <> 0) Then
                Label1.Text = "Please select one of the Title I.D. or Release Date."
                Label1.Visible = True
                Return
            End If

            ''Dim StartDate As String = ""
            ''Dim EndDate As String = ""
            ''If (lblDate.Text.Trim() <> "") Then
            ''    StartDate = lblDate.Text.Substring(6, 4)
            ''    StartDate &= "/"
            ''    StartDate &= lblDate.Text.Substring(3, 2)
            ''    StartDate &= "/"
            ''    StartDate &= lblDate.Text.Substring(0, 2)
            ''End If

            ''If (lblDate0.Text.Trim() <> "") Then
            ''    EndDate = lblDate0.Text.Substring(6, 4)
            ''    EndDate &= "/"
            ''    EndDate &= lblDate0.Text.Substring(3, 2)
            ''    EndDate &= "/"
            ''    EndDate &= lblDate0.Text.Substring(0, 2)
            ''End If

            Session("msRptStrDate") = String.Format("{0:yyyy/MM/dd}", Me.dtpStartDate.SelectedDate)
            Session("msRptEndDate") = String.Format("{0:yyyy/MM/dd}", Me.dtpEndDate.SelectedDate)
            If (Movie1Popup1.MovieId = 0) Then
                Session("rptRealMovie") = "null"
            Else
                Session("rptRealMovie") = Movie1Popup1.MovieId
            End If

            Response.Redirect("frmRptTrailerViewership.aspx")
        Catch ex As Exception
            Label1.Text = ex.Message
        End Try
    End Sub

End Class