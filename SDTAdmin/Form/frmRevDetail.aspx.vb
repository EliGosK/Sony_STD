Imports Web.Data
Imports System.Data.SqlClient
Imports System.Web.Security

Partial Public Class frmRevDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim revenueId As Int32 = CInt(Request.QueryString("revID"))
        Response.Redirect("SendRevenue.aspx?MovieTypeId=1&RevenueId=" & revenueId)
        Return

        If Mid(Session("permission"), 6, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        '--------Get Movies Detail--------------------------------------------
        lblDate.Text = Right(Session("revDate"), 2) & "-" & Mid(Session("revDate"), 5, 2) & "-" & Left(Session("revDate"), 4)
        lblDate.NavigateUrl = "frmRevByDate.aspx?revDate=" & Session("revDate")
        lblMovieId.NavigateUrl = "frmRevByMovie.aspx?movieId=" & Session("movieId")
        'Session("revScreen") = Request.QueryString("revScreen")
        lblScreen.Text = "Screen No.: " & Session("revScreen")
        lblScreen.NavigateUrl = "frmRevByscrn.aspx?revScreen=" & Session("revScreen")
        TheaterName.NavigateUrl = "frmRevBytheater.aspx?theaterId=" & Session("theaterId")
        Dim getMovieDetail As New cDatabase
        Dim dataReader As IDataReader = getMovieDetail.getMovieDetail(Session("movieId"))
        If dataReader.Read = True Then
            txtTitle.Text = dataReader("movie_nameen") & "/" & dataReader("movie_nameth")
            lblMovieId.Text = dataReader("movie_nameen")
            txtDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
            txtGenre.Text = dataReader("movie_gern") & "/" & dataReader("movie_gernsub")
            txtDis.Text = dataReader("distributor_name")
        End If
        dataReader.Close()
        '-----------------End Get-----------------------------------------------
        '---Get Theater Detail--------------------------------------------------
        Dim dataReadTheater As IDataReader = getMovieDetail.getTheaterDetail(Session("theaterId"))
        If dataReadTheater.Read = True Then
            TheaterName.Text = dataReadTheater("theater_name")
        End If
        dataReadTheater.Close()
        '----------End get------------------------------------------------------

        'Dim readstatus As New cDatabase
        If Session("TheaterId") = 47 Then
            ddlSystem.Items.Item(1).Text = "70 มม. 2 มิติ"
            ddlSystem.Items.Item(1).Value = "70 มม. 2 มิติ"
            ddlSystem.Items.Item(2).Text = "70 มม. 3 มิติ"
            ddlSystem.Items.Item(2).Value = "70 มม. 3 มิติ"
        End If
        If IsPostBack Then
            ddlStatus.Items(0).Attributes.Add("style", "background: orange;")
            ddlStatus.Items(1).Attributes.Add("style", "background: green;")
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
            'Dim revenueId As Integer
            Dim revDetail As New cDatabase
            ' Dim dataReader As IDataReader
            Dim datas As New cDatabase
            Dim dattbl As DataTable
            revenueId = CInt(Request.QueryString("revID"))
            dattbl = datas.GetRevenuDataset(revenueId, CInt(Session("theaterId")), CInt(Session("movieId"))).Tables(0)
            'dattbl.Tables("test").Rows(0).Item("")
            '---------Get Revenue Detail------------------------------------------------
            lblSession.Text = "Session Id:" & revenueId
            Session("revID") = revenueId
            dataReader = revDetail.GetRevenuDetail(revenueId, Session("theaterId"), Session("movieId"))
            If dataReader.Read = True Then
                txtAmount.Text = FormatNumber(dataReader("revenue_amount"), 0, , , TriState.True)
                txtAdms.Text = FormatNumber(dataReader("revenue_adms"), 0, , , TriState.True)
                ddlScreen.SelectedValue = CInt(dattbl.Rows(0).Item("TheaterSub_id"))
                'CInt(dataReader("TheaterSub_id"))
                'ddlSound.SelectedValue = CStr(dataReader("sound_type"))
                ddlStatus.SelectedValue = CInt(dataReader("status_id"))
                'ddlSystem.SelectedValue = CStr((dattbl.Rows(0).Item("movie_system")))
                ddlHours.SelectedValue = CInt(dataReader("timehour_id"))
                ddlMin.SelectedValue = CInt(dataReader("timemin_id"))
                ddlType.SelectedValue = CStr(dataReader("revenue_type"))
                Session("checkerID") = IIf(IsDBNull(dataReader("user_id")), Session("UserID"), dataReader("user_id"))
                If dataReader("status_id") = 1 Then
                    ddlSound.Enabled = False
                    txtAmount.Enabled = False
                    txtAdms.Enabled = False
                    ddlStatus.Enabled = False
                    ddlSystem.Enabled = False
                    ddlHours.Enabled = False
                    ddlMin.Enabled = False
                    ddlType.Enabled = False
                    ddlScreen.Enabled = False
                    btnSave.Enabled = False
                    btndelete.Enabled = False
                    ddlStatus.SelectedItem.Text = "[x]ปิด"
                End If
                dataReader.Close()

            End If
            '------------End Get-------------------------------------
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Dim revDetail As New cDatabase
            'Dim dataReader As IDataReader = revDetail.checkRevenue(ddlScreen.SelectedValue, Session("TheaterId"), ddlHours.SelectedItem.Text & ":" & ddlMin.SelectedItem.Text, Session("SysDate"))
            lblErrorExist.Visible = False
            lblError.Visible = False
            lblErrorTime.Visible = False
            txtAdms.Text = IIf(IsNumeric(txtAdms.Text) = True, txtAdms.Text, "0")
            txtAmount.Text = IIf(IsNumeric(txtAmount.Text) = True, txtAmount.Text, "0")
            'If CInt(txtAmount.Text) / CInt(txtAdms.Text) > 49 And CInt(txtAmount.Text) / CInt(txtAdms.Text) < 601 Or (CInt(txtAmount.Text) = 0) Then
            If CInt(txtAmount.Text) / CInt(txtAdms.Text) > 20 And CInt(txtAmount.Text) / CInt(txtAdms.Text) < 801 Or (CInt(txtAmount.Text) = 0) Then
                Dim updateRev As New cDatabase
                updateRev.updateRevenue(CInt(txtAdms.Text), CInt(txtAmount.Text), Session("revDate"), ddlHours.SelectedItem.Text & ":" & ddlMin.SelectedItem.Text, ddlHours.SelectedValue, ddlMin.SelectedValue, _
                              ddlType.SelectedItem.Text, ddlScreen.SelectedValue, ddlSystem.SelectedItem.Text, Session("checkerID"), Session("movieId"), CInt(ddlStatus.SelectedValue), _
                              Session("theaterId"), ddlSound.SelectedItem.Text, Session("revID"))
                lblErrorExist.Visible = False
                Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen"))
            Else
                lblError.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen"))
    End Sub

    Protected Sub btndelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btndelete.Click
        If MsgBoxResult.Ok Then
            Dim comprevId As Integer = CInt(Request.QueryString("revenueid"))
            'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim sqlcon As New SqlConnection(strconn)
            sqlcon.Open()
            Dim sql As String
            sql = "delete from tblRevenue where revenueid=" & Session("revID")
            Dim com As New SqlCommand(sql, sqlcon)
            com.ExecuteNonQuery()
            sqlcon.Close()
            Response.Redirect("frmRevByscrn.aspx?revScreen=" & Session("revScreen"))
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub txtTitle_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTitle.TextChanged

    End Sub
End Class