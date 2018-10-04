Imports Web.Data
Imports System.Web.Security

Partial Public Class frmRevByMovie
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Mid(Session("permission"), 2, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        Dim movieId As Integer
        If (Not ValidateQueryString(Request.QueryString("movieId"), GetType(Integer), movieId)) Then
            Response.Redirect("frmRevenueMonitor.aspx")
        End If

        'Dim test As DateTime = "12-04-2017 14:02:00"
        'ConvertTimeToLocaltime(test)

        Session("movieId") = movieId
        Dim getMovieDetail As New cDatabase
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(movieId)
        If dataReader.Read = True Then
            txtTitle.Text = dataReader("movie_nameen") & "/" & dataReader("movie_nameth")
            lblMoveId.Text = dataReader("movie_nameen")
            txtDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReader("movie_gern") & "/" & dataReader("movie_gernsub")
            txtDis.Text = dataReader("distributor_name")
            Session("movieType") = dataReader("movietype_id")
            Session("Distributor") = dataReader("distributor_id")
            dataReader.Close()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBoxOffice.DataBound
        If grdBoxOffice.Rows.Count > 0 Then
            grdBoxOffice.FooterRow.Cells(1).Text = "Total :"
            grdBoxOffice.FooterRow.Cells(2).Text = Format(Session("sumAmount"), "#,##0")
            grdBoxOffice.FooterRow.Cells(3).Text = Format(Session("sumADMS"), "#,##0")
            grdBoxOffice.FooterRow.Cells(4).Text = Format(Session("sumScreen"), "#,##0")
            grdBoxOffice.FooterRow.Cells(5).Text = Format(Session("sumSession"), "#,##0")
            Session("sumAmount") = "0"
            Session("sumADMS") = "0"
            Session("sumScreen") = "0"
            Session("sumSession") = "0"
        End If
    End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        'Dim sumAmount, sumADMS, sumScreen, sumSession As Integer

        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            Dim dr As Data.DataRowView = e.Row.DataItem
            If Mid(Session("permission"), 3, 1) = "0" Then
                e.Row.Cells(0).Enabled = False
            End If
            If dr(7) = "[-]เบื้องต้น" Then

                ' e.Row.BackColor = Color.LightGoldenrodYellow
                'e.Row.Font.Bold = False
                e.Row.ForeColor = Color.Orange
            ElseIf dr(7) = "[฿]ยอดจริง" Then

                ' e.Row.BackColor = Color.DarkSeaGreen
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Green
            Else
                ' e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.DarkGray
            End If
            If dr(1) < 0 Then
                e.Row.Cells(1).Text = "P"
            ElseIf dr(1) > 0 Then
                e.Row.Cells(1).Text = "C"
            Else
                e.Row.Cells(1).Text = "O"
            End If
            'grdBoxOffice.FooterRow.Cells(1).Text = "Total :"
            Session("sumAmount") = Session("sumAmount") + dr(3)
            Session("sumADMS") = Session("sumADMS") + dr(2)
            If Session("sumScreen") < dr(5) Then
                Session("sumScreen") = dr(5)
            End If
            If Session("sumSession") < dr(4) Then
                Session("sumSession") = dr(4)
            End If
            'Session("sumSession") = Session("sumSession") + dr(4)

            'ConvertTime By Pachara S. (C.S.I. Groups) on 20170525
            e.Row.Cells(7).Text = ConvertTimeToLocaltime(dr(8))

            e.Row.Cells(6).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell
            e.Row.Cells(7).HorizontalAlign = HorizontalAlign.Center 'Fixed Center Cell

        End If
    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged

    End Sub

    Private Sub grdBoxOffice_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles grdBoxOffice.SelectedIndexChanging

    End Sub

End Class