Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByTheaterComp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 5, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        Session("theaterId") = Request.QueryString("theaterId")
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblDate.NavigateUrl = "frmRevByDateComp.aspx?revDate=" & Session("revDate")
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")
        TheaterName.NavigateUrl = "frmRevBytheaterComp.aspx?theaterId=" & Session("theaterId")
        Dim getMovieDetail As New cDatabase
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(Session("movieId"))
        If dataReader.Read = True Then
            txtTitle.Text = dataReader("movie_nameen") & "/" & dataReader("movie_nameth")
            lblMovieId.Text = dataReader("movie_nameen")
            txtDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReader("movie_gern") & "/" & dataReader("movie_gernsub")
            txtDis.Text = dataReader("distributor_name")
        End If
        Dim dataReadTheater As IDataReader = getMovieDetail.getTheaterDetail(Session("theaterId"))
        If dataReadTheater.Read = True Then
            TheaterName.Text = dataReadTheater("theater_name")
        End If
        dataReader.Close()
        'gvDatabind()
    End Sub

    Protected Sub txtTitle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTitle.TextChanged

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBoxOffice.DataBound
        If grdBoxOffice.Rows.Count > 0 Then
            grdBoxOffice.FooterRow.Cells(0).Text = "Total :"
            grdBoxOffice.FooterRow.Cells(1).Text = Format(Session("sumAmount"), "#,##0")
            grdBoxOffice.FooterRow.Cells(2).Text = Format(Session("sumADMS"), "#,##0")
            grdBoxOffice.FooterRow.Cells(3).Text = Format(Session("sumScreen"), "#,##0")
            grdBoxOffice.FooterRow.Cells(4).Text = Format(Session("sumSession"), "#,##0")

            Session("sumAmount") = "0"
            Session("sumADMS") = "0"
            Session("sumScreen") = "0"
            Session("sumSession") = "0"
        End If
    End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            Dim dr As Data.DataRowView = e.Row.DataItem
            If Mid(Session("permission"), 6, 1) = "0" Then
                e.Row.Cells(0).Enabled = False
            End If
            If (dr("status") Is DBNull.Value) Then
                e.Row.ForeColor = Color.Orange
            ElseIf dr("status") = "[-]เบื้องต้น" Then

                ' e.Row.BackColor = Color.LightGoldenrodYellow
                'e.Row.Font.Bold = False
                e.Row.ForeColor = Color.Orange
            ElseIf dr("status") = "[฿]ยอดจริง" Then

                ' e.Row.BackColor = Color.DarkSeaGreen
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Green
            Else
                ' e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.DarkGray
            End If
            Session("sumAmount") = Session("sumAmount") + dr("revenue_amount")
            Session("sumADMS") = Session("sumADMS") + dr("revenue_adms")
            Session("sumScreen") = Session("sumScreen") + dr("revenue_screen")
            Session("sumSession") = Session("sumSession") + dr("revenue_session")
        End If
    End Sub
End Class