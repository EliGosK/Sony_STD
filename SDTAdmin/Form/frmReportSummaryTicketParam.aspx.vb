Option Strict On

Imports SDTCommon.DBInterface
Imports Web.Data
Imports SDTCommon

Namespace Form

    Partial Public Class FrmReportSummaryTicketParam
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnCancelMovieClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelMovie.Click
            Response.Redirect("frmCTBV_RC_Menu.aspx")
        End Sub
        Protected Sub BtnExitClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
            DBInterface.User.Logout()
        End Sub
        Protected Sub BtnSearchClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnSearch.Click
            Dim redirectUrl As String = "frmReportSummaryTicket.aspx?Type=" & ddlType.Text & "&MovieId=" & moviePopup.MovieId & "&StartDate=" & dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&EndDate=" & dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd")
            If lblPrefix.Visible Then
                If ddlGroupBy.Text = "Theater" Then
                    redirectUrl &= "&CircuitId=" & ddlCircuit.SelectedItem.Value
                Else
                    redirectUrl &= "&TheaterId=" & ddlTheater.SelectedItem.Value
                End If
            End If
            Response.Redirect(redirectUrl)
        End Sub
        Protected Sub DdlGroupBySelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlGroupBy.SelectedIndexChanged
            ddlCircuit.Visible = False
            ddlTheater.Visible = False
            lblPrefix.Visible = Not (ddlGroupBy.Text = "Circuit")
            If lblPrefix.Visible Then
                If ddlGroupBy.Text = "Theater" Then
                    ddlCircuit.Visible = True
                Else
                    ddlTheater.Visible = True
                End If
            End If
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If

            moviePopup.MovieType = "1"
            moviePopup.VisibleMovieType = False
            moviePopup.BindData()

            Dim dtbCircuit As DataTable = Circuit.SelectData(Nothing)
            ddlCircuit.DataSource = dtbCircuit
            ddlCircuit.DataTextField = "circuit_name"
            ddlCircuit.DataValueField = "circuit_id"
            ddlCircuit.DataBind()
            ddlCircuit.Visible = False

            Dim dtbTheater As DataTable = Theater.SelectData(Nothing, Nothing, Nothing)
            ddlTheater.DataSource = dtbTheater
            ddlTheater.DataTextField = "theater_name"
            ddlTheater.DataValueField = "theater_id"
            ddlTheater.DataBind()
            ddlTheater.Visible = False

            lblPrefix.Visible = False
        End Sub
        Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
            If moviePopup.MovieId <> 0 Then
                Dim cDb As New cDatabase
                Dim dataReader As IDataReader = cDb.getMovieDetail(moviePopup.MovieId)
                If dataReader.Read Then
                    Dim startDate As Date? = CType(dataReader("movie_strdate"), Date?)
                    If Not IsNothing(startDate) Then
                        dtpStartDate.SelectedDate = startDate
                        dtpEndDate.SelectedDate = startDate.Value.AddDays(+6)
                    End If
                End If
                dataReader.Close()
            End If
        End Sub
#End Region

    End Class
End Namespace