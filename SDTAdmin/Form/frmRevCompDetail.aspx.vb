Imports Web.Data
Imports System.Data.SqlClient
Imports System.Web.Security

Partial Public Class frmRevCompDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '------------Get theater Id ------------------------
        If Mid(Session("permission"), 6, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        Session("theaterId") = Request.QueryString("theaterId")
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblDate.NavigateUrl = "frmRevByDate.aspx?revDate=" & Session("revDate")
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")
        Dim getMovieDetail As New cDatabase
        Dim dataReadMovies As IDataReader = getMovieDetail.getMovieDetail(Session("movieId"))
        Dim dataReadTheater As IDataReader = getMovieDetail.getTheaterDetail(Session("theaterId"))
        If dataReadTheater.Read = True Then
            lblTheater.Text = dataReadTheater("theater_name")
        End If
        If dataReadMovies.Read = True Then
            txtTitle.Text = dataReadMovies("movie_nameen") & "/" & dataReadMovies("movie_nameth")
            lblMovieId.Text = dataReadMovies("movie_nameen")
            txtDate.Text = Format(dataReadMovies("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReadMovies("movie_gern") & "/" & dataReadMovies("movie_gernsub")
            txtDis.Text = dataReadMovies("distributor_name")
        End If
        dataReadMovies.Close()
        dataReadTheater.Close()
        Dim comprevId2 As Integer = CInt(Request.QueryString("movies_id"))

        If IsPostBack Then
            ddlStatus.Items(0).Attributes.Add("style", "background: orange;")
            ddlStatus.Items(1).Attributes.Add("style", "background: green;")
            'ddlStatus.Items(2).Attributes.Add("style", "background: red;")
        End If
        If Not IsPostBack Then
            Dim l As ListItem
            ddlStatus.Items.Clear()
            l = New ListItem("ยอดเบื้องต้น", "3")
            l.Attributes.Add("style", "background: orange;")
            ddlStatus.Items.Add(l)

            l = New ListItem("ยอดจริง", "2")
            l.Attributes.Add("style", "background: Green;")
            ddlStatus.Items.Add(l)

            'l = New ListItem("ปิด", "1")
            'l.Attributes.Add("style", "background: red;")
            'ddlStatus.Items.Add(l)

            Dim revCompDetail As New cDatabase
            Dim dataReader As IDataReader = revCompDetail.GetCompRevenuDetail(Session("movieId"), Session("theaterId"), Session("revDate"))
            'Dim dataReader As IDataReader = revCompDetail.GetCompRevenuDetail(4, 1, Session("SysDate"))
            Try
                If dataReader.Read() = True Then

                    txtScreenOr.Text = dataReader("comprevenue_screenor")
                    txtScreenTh.Text = dataReader("comprevenue_screenth")
                    txtScreenTD.Text = dataReader("comprevenue_screentd")
                    txtScreenSum.Text = Format(dataReader("comprevenue_screensum"), "#,##0")
                    txtRevOr.Text = Format(dataReader("comprevenue_amountor"), "#,##0")
                    txtRevTh.Text = Format(dataReader("comprevenue_amountth"), "#,##0")
                    txtRevTD.Text = Format(dataReader("comprevenue_amounttd"), "#,##0")
                    txtRevSum.Text = Format(dataReader("comprevenue_amountsum"), "#,##0")
                    txtTimeOr.Text = Format(dataReader("comprevenue_timeor"), "#,##0")
                    txtTimeTh.Text = dataReader("comprevenue_timeth")
                    txtTimeTD.Text = dataReader("comprevenue_timetd")
                    txtTimeSum.Text = Format(dataReader("comprevenue_timesum"), "#,##0")
                    txtAdmsOr.Text = dataReader("comprevenue_admsor")
                    txtAdmsTh.Text = Format(dataReader("comprevenue_admsth"), "#,##0")
                    txtAdmsTD.Text = Format(dataReader("comprevenue_admstd"), "#,##0")
                    txtAdmsSum.Text = Format(dataReader("comprevenue_admssum"), "#,##0")
                    ddlStatus.SelectedValue = dataReader("status_id")
                    Session("checkerID") = dataReader("user_id")
                    If dataReader("status_id") = 1 Then
                        ddlStatus.Enabled = False
                        ddlStatus.SelectedItem.Text = "[x]ปิด"
                        txtAdmsOr.Enabled = False
                        txtAdmsOr.BackColor = Drawing.Color.Silver
                        txtAdmsTh.Enabled = False
                        txtAdmsTh.BackColor = Drawing.Color.Silver
                        txtAdmsTD.Enabled = False
                        txtAdmsTD.BackColor = Drawing.Color.Silver
                        txtRevOr.Enabled = False
                        txtRevOr.BackColor = Drawing.Color.Silver
                        txtRevTh.Enabled = False
                        txtRevTh.BackColor = Drawing.Color.Silver
                        txtRevTD.Enabled = False
                        txtRevTD.BackColor = Drawing.Color.Silver
                        txtScreenOr.Enabled = False
                        txtScreenOr.BackColor = Drawing.Color.Silver
                        txtScreenTh.Enabled = False
                        txtScreenTh.BackColor = Drawing.Color.Silver
                        txtScreenTD.Enabled = False
                        txtScreenTD.BackColor = Drawing.Color.Silver
                        txtTimeOr.Enabled = False
                        txtTimeOr.BackColor = Drawing.Color.Silver
                        txtTimeTh.Enabled = False
                        txtTimeTh.BackColor = Drawing.Color.Silver
                        txtTimeTD.Enabled = False
                        txtTimeTD.BackColor = Drawing.Color.Silver
                        txtAdmsSum.Enabled = False
                        txtAdmsSum.BackColor = Drawing.Color.Silver
                        txtRevSum.Enabled = False
                        txtRevSum.BackColor = Drawing.Color.Silver
                        txtScreenSum.Enabled = False
                        txtScreenSum.BackColor = Drawing.Color.Silver
                        txtTimeSum.Enabled = False
                        txtTimeSum.BackColor = Drawing.Color.Silver

                        btndelete.Enabled = False
                        btnSend.Enabled = False

                    End If
                End If
                dataReader.Close()
            Catch ex As Exception
                ex.Message().ToString()
            End Try
        End If
        LockText()
    End Sub
    Protected Sub LockText()
        If ddlStatus.SelectedValue = 2 Then
            txtAdmsOr.Enabled = True
            txtAdmsOr.BackColor = Drawing.Color.White
            txtAdmsTh.Enabled = True
            txtAdmsTh.BackColor = Drawing.Color.White
            txtAdmsTD.Enabled = True
            txtAdmsTD.BackColor = Drawing.Color.White
            txtRevOr.Enabled = True
            txtRevOr.BackColor = Drawing.Color.White
            txtRevTh.Enabled = True
            txtRevTh.BackColor = Drawing.Color.White
            txtRevTD.Enabled = True
            txtRevTD.BackColor = Drawing.Color.White
            txtScreenOr.Enabled = True
            txtScreenOr.BackColor = Drawing.Color.White
            txtScreenTh.Enabled = True
            txtScreenTh.BackColor = Drawing.Color.White
            txtScreenTD.Enabled = True
            txtScreenTD.BackColor = Drawing.Color.White
            txtTimeOr.Enabled = True
            txtTimeOr.BackColor = Drawing.Color.White
            txtTimeTh.Enabled = True
            txtTimeTh.BackColor = Drawing.Color.White
            txtTimeTD.Enabled = True
            txtTimeTD.BackColor = Drawing.Color.White
            txtAdmsSum.Enabled = False
            'txtAdmsOr.Text = txtAdmsSum.Text
            txtAdmsSum.BackColor = Drawing.Color.Silver
            txtRevSum.Enabled = False
            'txtRevOr.Text = txtRevSum.Text
            txtRevSum.BackColor = Drawing.Color.Silver
            txtScreenSum.Enabled = False
            ' txtScreenOr.Text = txtScreenSum.Text
            txtScreenSum.BackColor = Drawing.Color.Silver
            txtTimeSum.Enabled = False
            ' txtTimeOr.Text = txtTimeSum.Text
            txtTimeSum.BackColor = Drawing.Color.Silver
        ElseIf ddlStatus.SelectedValue = 3 Then
            txtAdmsOr.Enabled = False
            txtAdmsOr.BackColor = Drawing.Color.Silver
            txtAdmsTh.Enabled = False
            txtAdmsTh.BackColor = Drawing.Color.Silver
            txtAdmsTD.Enabled = False
            txtAdmsTD.BackColor = Drawing.Color.Silver
            txtRevOr.Enabled = False
            txtRevOr.BackColor = Drawing.Color.Silver
            txtRevTh.Enabled = False
            txtRevTh.BackColor = Drawing.Color.Silver
            txtRevTD.Enabled = False
            txtRevTD.BackColor = Drawing.Color.Silver
            txtScreenOr.Enabled = False
            txtScreenOr.BackColor = Drawing.Color.Silver
            txtScreenTh.Enabled = False
            txtScreenTh.BackColor = Drawing.Color.Silver
            txtScreenTD.Enabled = False
            txtScreenTD.BackColor = Drawing.Color.Silver
            txtTimeOr.Enabled = False
            txtTimeOr.BackColor = Drawing.Color.Silver
            txtTimeTh.Enabled = False
            txtTimeTh.BackColor = Drawing.Color.Silver
            txtTimeTD.Enabled = False
            txtTimeTD.BackColor = Drawing.Color.Silver
            txtAdmsSum.Enabled = True
            txtAdmsSum.BackColor = Drawing.Color.White
            txtRevSum.Enabled = True
            txtRevSum.BackColor = Drawing.Color.White
            txtScreenSum.Enabled = True
            txtScreenSum.BackColor = Drawing.Color.White
            txtTimeSum.Enabled = True
            txtTimeSum.BackColor = Drawing.Color.White
        Else

        End If
    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlStatus.SelectedIndexChanged
        LockText()
    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
        Dim admsOr As Integer = IIf(IsNumeric(txtAdmsOr.Text) = True, txtAdmsOr.Text, "0")
        Dim admsTh As Integer = IIf(IsNumeric(txtAdmsTh.Text) = True, txtAdmsTh.Text, "0")
        Dim admsTd As Integer = IIf(IsNumeric(txtAdmsTD.Text) = True, txtAdmsTD.Text, "0")
        Dim admsSum As Integer = IIf(IsNumeric(txtAdmsSum.Text) = True, txtAdmsSum.Text, "0")

        Dim revOr As Integer = IIf(IsNumeric(txtRevOr.Text) = True, txtRevOr.Text, "0")
        Dim revTh As Integer = IIf(IsNumeric(txtRevTh.Text) = True, txtRevTh.Text, "0")
        Dim revTd As Integer = IIf(IsNumeric(txtRevTD.Text) = True, txtRevTD.Text, "0")
        Dim revSum As Integer = IIf(IsNumeric(txtRevSum.Text) = True, txtRevSum.Text, "0")

        Dim scrOr As Integer = IIf(IsNumeric(txtScreenOr.Text) = True, txtScreenOr.Text, "0")
        Dim scrTh As Integer = IIf(IsNumeric(txtScreenTh.Text) = True, txtScreenTh.Text, "0")
        Dim scrTd As Integer = IIf(IsNumeric(txtScreenTD.Text) = True, txtScreenTD.Text, "0")
        Dim scrSum As Integer = IIf(IsNumeric(txtScreenSum.Text) = True, txtScreenSum.Text, "0")

        Dim timeOr As Integer = IIf(IsNumeric(txtTimeOr.Text) = True, txtTimeOr.Text, "0")
        Dim timeTh As Integer = IIf(IsNumeric(txtTimeTh.Text) = True, txtTimeTh.Text, "0")
        Dim timeTd As Integer = IIf(IsNumeric(txtTimeTD.Text) = True, txtTimeTD.Text, "0")
        Dim timeSum As Integer = IIf(IsNumeric(txtTimeSum.Text) = True, txtTimeSum.Text, "0")
        admsSum = IIf(ddlStatus.SelectedValue = 2, admsOr + admsTh + admsTd, admsSum)
        revSum = IIf(ddlStatus.SelectedValue = 2, revOr + revTh + revTd, revSum)
        scrSum = IIf(ddlStatus.SelectedValue = 2, scrOr + scrTh + scrTd, scrSum)
        timeSum = IIf(ddlStatus.SelectedValue = 2, timeOr + timeTh + timeTd, timeSum)

        Dim revCompDetail As New cDatabase
        Dim dataReader As IDataReader = revCompDetail.GetCompRevenuDetail(Session("movieId"), Session("theaterId"), Session("revDate"))
        'If revSum / admsSum > 59 And revSum / admsSum < 601 Or (revSum = 0) Then
        If revSum / admsSum > 20 And revSum / admsSum < 801 Or (revSum = 0) Then
            If dataReader.Read = True Then
                Dim updateCompRevenue As New cDatabase
                updateCompRevenue.updateCompRevenue(revSum, revTh, revTd, revOr, _
                                              admsSum, admsTh, admsTd, admsOr, _
                                              timeSum, timeOr, timeTh, timeTd, _
                                              scrSum, scrTh, scrTd, scrOr, _
                                             Session("revDate"), Session("theaterId"), Session("movieId"), _
                                              CInt(ddlStatus.SelectedValue), Session("checkerID"), Now)
                dataReader.Close()
            End If
            lblError.Visible = False
            dataReader.Close()
            Response.Redirect("frmRevByTheaterComp.aspx?revDate=" & Session("revDate"))
        Else
            lblError.Visible = True
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmRevByTheaterComp.aspx?revDate=" & Session("revDate"))
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btndelete.Click
        If MsgBoxResult.Ok Then
            Dim comprevId As Integer = CInt(Request.QueryString("revenueid"))
            'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim sqlcon As New SqlConnection(strconn)
            sqlcon.Open()
            Dim sql As String
            sql = "delete from tblCompRevenue where movies_id=" & Session("movieId") & "and theater_id=" & Session("theaterId") & "and comprevenue_date= convert(datetime,'" & Session("revDate") & "',101)"
            Dim com As New SqlCommand(sql, sqlcon)
            com.ExecuteNonQuery()
            sqlcon.Close()
            Response.Redirect("frmRevByTheaterComp.aspx?revDate=" & Session("revDate"))
        End If

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub
End Class