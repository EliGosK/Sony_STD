Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRptBoxOfficeAndLateShowParam2
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

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
        If (dtpEndDate.SelectedDate < dtpStartDate.SelectedDate) Then
            lblError.Visible = True
            Return
        End If

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

        Response.Redirect("frmRptBoxOfficeAndLateShow2.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmCTBV_RC_Menu.aspx")
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
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

End Class