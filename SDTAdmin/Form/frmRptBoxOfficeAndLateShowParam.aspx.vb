Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptBoxOfficeAndLateShowParam
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    ''    lblError.Visible = False
    ''    ViewState("clnDateSelect") = "None"
    ''    ViewState("clnDateEndSelect") = "None"
    ''    If Not IsPostBack Then
    ''        panelTheatre.Visible = False

    ''        ddlClnYearFrom.Items.Clear()
    ''        cDB.BindYear(ddlClnYearFrom, 15, 0)
    ''        ddlClnYearTo.Items.Clear()
    ''        cDB.BindYear(ddlClnYearTo, 15, 0)

    ''        If Hour(Now) < 6 Then
    ''            clnDateFrom.SelectedDate = Now().AddDays(-1)
    ''            lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")

    ''            clnDateTo.SelectedDate = Now().AddDays(-1).AddDays(6)
    ''            lblDateEnd.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
    ''        Else
    ''            clnDateFrom.SelectedDate = Now()
    ''            lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")

    ''            clnDateTo.SelectedDate = Now().AddDays(6)
    ''            lblDateEnd.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    ''        End If
    ''    End If
    ''    If Mid(Session("permission"), 24, 1) = "0" Then
    ''        Response.Redirect("InfoPage.aspx")
    ''    End If
    ''End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.Visible = False

        If Not IsPostBack Then
            panelTheatre.Visible = False

            If Hour(Now) < 6 Then
                dtpStartDate.SelectedDate = Today.AddDays(-1)
                dtpEndDate.SelectedDate = Today.AddDays(-1).AddDays(6)
            Else
                dtpStartDate.SelectedDate = Today
                dtpEndDate.SelectedDate = Today.AddDays(6)
            End If
        End If

        If Mid(Session("permission"), 24, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        ''If (clnDateTo.SelectedDate < clnDateFrom.SelectedDate) Then
        ''    lblError.Visible = True
        ''    Return
        ''End If
        If (dtpEndDate.SelectedDate < dtpStartDate.SelectedDate) Then
            lblError.Visible = True
            Return
        End If

        ''Session("strDateComp") = clnDateFrom.SelectedDate
        ''Session("strDateEndComp") = clnDateTo.SelectedDate
        Session("strDateComp") = dtpStartDate.SelectedDate
        Session("strDateEndComp") = dtpEndDate.SelectedDate

        Dim strMinTheater_id As String = "0"
        Dim strMaxTheater_id As String = "0"
        If TheatrePopup1.TheatreNo = "" Or TheatrePopup2.TheatreNo = "" Then
            Dim dr As IDataReader = cDB.GetDataString("min(theater_id) as minTheater_id, max(theater_id) as maxTheater_id", "tblTheater", "1=1")
            If dr.Read = True Then
                strMinTheater_id = dr("minTheater_id").ToString()
                strMaxTheater_id = dr("maxTheater_id").ToString()
            End If
            dr.Close()
        End If

        If TheatrePopup1.TheatreNo = "" Then
            Session("startTheaterId") = strMinTheater_id
        Else
            Session("startTheaterId") = TheatrePopup1.TheatreNo
        End If

        If TheatrePopup2.TheatreNo = "" Then
            Session("EndTheaterId") = strMaxTheater_id
        Else
            Session("EndTheaterId") = TheatrePopup2.TheatreNo
        End If

        Response.Redirect("frmRptBoxOfficeAndLateShow.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        ''If (clnDateTo.SelectedDate < clnDateFrom.SelectedDate) Then
        ''    lblError.Visible = True
        ''    Return
        ''End If
        If (dtpEndDate.SelectedDate < dtpStartDate.SelectedDate) Then
            lblError.Visible = True
            Return
        End If

        ''Session("strDateComp") = clnDateFrom.SelectedDate
        ''Session("strDateEndComp") = clnDateTo.SelectedDate
        Session("strDateComp") = dtpStartDate.SelectedDate
        Session("strDateEndComp") = dtpEndDate.SelectedDate

        Dim strMinTheater_id As String = "0"
        Dim strMaxTheater_id As String = "0"
        If TheatrePopup1.TheatreNo = "" Or TheatrePopup2.TheatreNo = "" Then
            Dim dr As IDataReader = cDB.GetDataString("min(theater_id) as minTheater_id, max(theater_id) as maxTheater_id", "tblTheater", "1=1")
            If dr.Read = True Then
                strMinTheater_id = dr("minTheater_id").ToString()
                strMaxTheater_id = dr("maxTheater_id").ToString()
            End If
            dr.Close()
        End If

        If TheatrePopup1.TheatreNo = "" Then
            Session("startTheaterId") = strMinTheater_id
        Else
            Session("startTheaterId") = TheatrePopup1.TheatreNo
        End If

        If TheatrePopup2.TheatreNo = "" Then
            Session("EndTheaterId") = strMaxTheater_id
        Else
            Session("EndTheaterId") = TheatrePopup2.TheatreNo
        End If

        Response.Redirect("frmRptBoxOfficeAndLateShowEx.aspx")
    End Sub

    Protected Sub btnShowTheatre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowTheatre.Click
        Try
            If panelTheatre.Visible = True Then
                panelTheatre.Visible = False
                btnShowTheatre.Text = "Show Theatre"
            Else
                panelTheatre.Visible = True
                btnShowTheatre.Text = "Hide Theatre"
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    clnDateFrom.Visible = True
    ''    ViewState("clnDateSelect") = "Select"
    ''End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateFrom.SelectionChanged
    ''    lblDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-" + clnDateFrom.SelectedDate.Year.ToString())
    ''    clnDateFrom.Visible = False
    ''    ViewState("clnDateSelect") = "Select"

    ''    lblDateEnd.Text = Format(clnDateFrom.SelectedDate.AddDays(6), "ddd dd-MMM-" + clnDateFrom.SelectedDate.Year.ToString())
    ''    clnDateTo.SelectedDate = clnDateFrom.SelectedDate.AddDays(6)
    ''    clnDateTo.Visible = False
    ''    ViewState("clnDateEndSelect") = "Select"
    ''End Sub

    ''Protected Sub clnDate0_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateTo.SelectionChanged
    ''    lblDateEnd.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-" + clnDateTo.SelectedDate.Year.ToString())
    ''    clnDateTo.Visible = False
    ''    ViewState("clnDateEndSelect") = "Select"
    ''End Sub

    ''Protected Sub btnCalendar0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar0.Click
    ''    clnDateTo.Visible = True
    ''    ViewState("clnDateEndSelect") = "Select"
    ''End Sub

    ''Protected Sub ddlClnYearFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearFrom.SelectedIndexChanged
    ''    If ddlClnYearFrom.SelectedIndex = 0 Then
    ''        clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    ''    Else
    ''        Dim intYear As String = CInt(ddlClnYearFrom.SelectedItem.Text)
    ''        clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + intYear)
    ''    End If
    ''End Sub

    ''Protected Sub ddlClnYearTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearTo.SelectedIndexChanged
    ''    If ddlClnYearTo.SelectedIndex = 0 Then
    ''        clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    ''    Else
    ''        Dim intYear As String = CInt(ddlClnYearTo.SelectedItem.Text)
    ''        clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + intYear)
    ''    End If
    ''End Sub

End Class