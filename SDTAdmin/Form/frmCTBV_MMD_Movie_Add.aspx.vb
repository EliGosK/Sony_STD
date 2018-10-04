Imports Web.Data
Imports System.Web.Security
Imports System.Text.RegularExpressions

Partial Public Class frmCTBV_MMD_Movie_Add
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        
    End Sub

    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If Not IsPostBack Then
            '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
            ''ddlClnYear.Items.Clear()
            ''cDB.BindYear(ddlClnYear, 5, 5)
            '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection

            lblError.Text = "Please check require flield (*)"
            lblError.Visible = False

            Dim movieId As Integer
            If Not (ValidateQueryString(Request.QueryString("titleId"), GetType(Integer), movieId)) Then
                Response.Redirect("frmCTBV_MMD_Movie.aspx")
            End If

            If movieId = 0 Then
                trMovieID.Visible = False
            Else
                trMovieID.Visible = True
                txtMovieID.Text = movieId
            End If
            Session("MovieId") = movieId
            If movieId = 0 Then
                '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                ''txtReleaseDate.Text = Today().ToString("ddd dd-MMM-yyyy")
                ''clnDate.SelectedDate = Today
                dtpReleaseDate.SelectedDate = Today
                '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                imbDelete.Visible = False
                chkShowInRpt.Checked = True
            Else
                imbDelete.Visible = True

                Dim dtbDist As DataTable = cDatabase.GetDataTable("SELECT distributor_name, distributor_id FROM tblDistributor WHERE (active_flag = 'Y')")
                Dim hasDist As New Hashtable()
                For i As Integer = 0 To dtbDist.Rows.Count - 1
                    hasDist(Convert.ToString(dtbDist.Rows(i)("distributor_id"))) = "true"
                Next

                Dim dtbStudio As DataTable = cDatabase.GetDataTable("SELECT studio_id, studio_name FROM tblStudio WHERE (active_flag = 'Y')")
                Dim hasStudio As New Hashtable()
                For i As Integer = 0 To dtbStudio.Rows.Count - 1
                    hasStudio(Convert.ToString(dtbStudio.Rows(i)("studio_id"))) = "true"
                Next

                Dim dataReader As IDataReader = cDB.getMovieDetail(movieId)
                If dataReader.Read = True Then
                    txtName1.Text = dataReader("movie_nameen")
                    txtName2.Text = dataReader("movie_nameth")
                    txtCode.Text = dataReader("movie_code") & ""
                    ddlType.SelectedValue = dataReader("movietype_id")
                    '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                    ''txtReleaseDate.Text = Format(dataReader("movie_strdate"), "ddd dd-MMM-yyyy")
                    ''clnDate.SelectedDate = dataReader("movie_strdate")
                    dtpReleaseDate.SelectedDate = dataReader("movie_strdate")
                    '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection

                    If (Not (hasDist(Convert.ToString(dataReader("distributor_id"))) Is Nothing)) Then
                        ddlDistibutor.SelectedValue = dataReader("distributor_id")
                    End If

                    If (Not (hasStudio(Convert.ToString(dataReader("studio_id"))) Is Nothing)) Then
                        ddlStudio.SelectedValue = dataReader("studio_id")
                    End If
                    ddlGenr.SelectedValue = dataReader("movie_gern") & ""
                    ddlGenr0.SelectedValue = dataReader("movie_gernsub") & ""
                    ddlPattern.SelectedValue = dataReader("movie_pattern") & ""
                    ddlNationality.SelectedValue = dataReader("movie_national") & ""
                    txtCast1.Text = dataReader("movie_cast1") & ""
                    txtCast2.Text = dataReader("movie_cast2") & ""
                    txtDirector.Text = dataReader("movie_director") & ""
                    ViewState("Movie_Status") = Convert.ToString(dataReader("movie_status"))

                    txtRevenueEstimate.Text = Format(cDB.CheckIsNullInteger(dataReader("revenue_estimete")), "#,##0.00")
                    If txtRevenueEstimate.Text = "" Then
                        txtRevenueEstimate.Text = "0.00"
                    End If
                    txtFlatSaleRental.Text = Format(cDB.CheckIsNullInteger(dataReader("flat_sale_rental")), "#,##0.00")
                    If txtFlatSaleRental.Text = "" Then
                        txtFlatSaleRental.Text = "0.00"
                    End If
                    txtComment.Text = dataReader("remark").ToString

                    txtAdpub.Text = Format(cDB.CheckIsNullInteger(dataReader("ad_pub_amt")), "#,##0.00")
                    If txtAdpub.Text = "" Then
                        txtAdpub.Text = "0.00"
                    End If

                    txtPrintcost.Text = Format(cDB.CheckIsNullInteger(dataReader("print_cost_amt")), "#,##0.00")
                    If txtPrintcost.Text = "" Then
                        txtPrintcost.Text = "0.00"
                    End If

                    txtNoOfPoint.Text = cDB.CheckIsNullString(dataReader("print_qty"))
                    'If txtNoOfPoint.Text = "" Then
                    '    txtNoOfPoint.Text = "0"
                    'End If

                    Dim wkSid As String = dataReader("appear_status_id").ToString
                    ddlAppear.SelectedValue = wkSid
                    hidAppear.Value = wkSid
                    ' ddlPattern.SelectedValue = dataReader("studio_id")
                    Dim wkShow_in_report_flag As String = dataReader("show_in_report_flag").ToString
                    If wkShow_in_report_flag = "Y" Then
                        chkShowInRpt.Checked = True
                    Else
                        chkShowInRpt.Checked = False
                    End If
                Else
                    txtRevenueEstimate.Text = "0.00"
                    txtFlatSaleRental.Text = "0.00"
                    txtAdpub.Text = "0.00"
                    txtPrintcost.Text = "0.00"
                    txtNoOfPoint.Text = "0"
                End If
                dataReader.Close()
            End If

            hidDEL_tblCompRevenue.Value = "-"
            hidDEL_tblRelease.Value = "-"
            hidDEL_tblRevenue.Value = "-"

            If movieId <> 0 Then
                ShowData("")
            End If

        End If
            CheckMovieID()
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_Movie.aspx")
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            Dim f1 As String = txtRevenueEstimate.Text.Trim
            Dim f2 As String = txtFlatSaleRental.Text.Trim
            If f1 = "" Then
                f1 = "0"
            End If
            If f2 = "" Then
                f2 = "0"
            End If

            Dim AddMovies As New cDatabase
            Dim movieId As Integer

            If (Not ValidateQueryString(Request.QueryString("titleId"), GetType(Integer), movieId)) Then
                Response.Redirect("frmCTBV_MMD_Movie.aspx")
            End If

            'movieId = CInt(Request.QueryString("titleId"))

            Dim adpubamt, printcostamt As Decimal
            Dim printqty As String = ""
            If txtAdpub.Text.Trim() = "" Then
                adpubamt = 0
            Else
                adpubamt = Convert.ToDecimal(txtAdpub.Text)
            End If
            If txtPrintcost.Text.Trim() = "" Then
                printcostamt = 0
            Else
                printcostamt = Convert.ToDecimal(txtPrintcost.Text)
            End If

            'If txtNoOfPoint.Text.Trim() = "" Then
            '    printqty = 0
            'Else
            '    printqty = Convert.ToDecimal(txtNoOfPoint.Text)
            'End If

            printqty = txtNoOfPoint.Text.Trim()

            Dim strShow_in_report_flag As String
            If chkShowInRpt.Checked Then
                strShow_in_report_flag = "Y"
            Else
                strShow_in_report_flag = "N"
            End If
            If movieId = 0 Then 'ADD
                Dim strSQLcheckName As String = "Select * From [tblMovie] WHERE [movie_nameth] = '" + txtName1.Text.Replace("'", "''") + "' OR [movie_nameen] = '" + txtName1.Text.Replace("'", "''") + "'"
                Dim dataReader1 As IDataReader = cDB.GetDataAll(strSQLcheckName)
                If dataReader1.Read = True Then
                    Response.Write("<script language = 'javascript'>alert('Please check data again! Duplicate Title.')</script> ")
                Else 'ถ้าชื่อหนังไม่ซ้ำ
                    If txtName1.Text = "" Or txtName2.Text = "" Or ddlGenr.SelectedValue = "0" Or ddlDistibutor.SelectedValue = "0" Or ddlGenr0.SelectedValue = "0" Or ddlNationality.SelectedValue = "0" Or ddlStudio.SelectedValue = "0" Then
                        lblError.Visible = True
                        lblError.Text = "Please check require flield (*)"
                    Else
                        lblError.Visible = False

                        '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                        ''AddMovies.addMovies(movieId, txtCode.Text, txtName2.Text, txtName1.Text, clnDate.SelectedDate.ToString("yyyyMMdd"), Today().ToString("yyyyMMdd"), 1, ddlType.SelectedValue, Session("UserID"), ddlStudio.SelectedValue, ddlDistibutor.SelectedValue, ddlGenr.SelectedItem.Text, ddlGenr0.SelectedItem.Text, ddlPattern.SelectedItem.Text, ddlNationality.SelectedItem.Text, txtDirector.Text, txtCast1.Text, txtCast2.Text, CInt(ddlAppear.SelectedValue), Convert.ToDecimal(f1), Convert.ToDecimal(f2), txtComment.Text.Trim, adpubamt, printcostamt, printqty, strShow_in_report_flag)
                        AddMovies.addMovies(movieId, txtCode.Text, txtName2.Text, txtName1.Text, String.Format("{0:yyyyMMdd}", dtpReleaseDate.SelectedDate), Today().ToString("yyyyMMdd"), 1, ddlType.SelectedValue, Session("UserID"), ddlStudio.SelectedValue, ddlDistibutor.SelectedValue, ddlGenr.SelectedItem.Text, ddlGenr0.SelectedItem.Text, ddlPattern.SelectedItem.Text, ddlNationality.SelectedItem.Text, txtDirector.Text, txtCast1.Text, txtCast2.Text, CInt(ddlAppear.SelectedValue), Convert.ToDecimal(f1), Convert.ToDecimal(f2), txtComment.Text.Trim, adpubamt, printcostamt, printqty, strShow_in_report_flag)
                        '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                        Response.Redirect("frmCTBV_MMD_Movie.aspx")
                    End If
                End If
                dataReader1.Close()
            Else 'UPDATE
                If txtName1.Text = "" Or txtName2.Text = "" Or ddlGenr.SelectedValue = "0" Or ddlDistibutor.SelectedValue = "0" Or ddlGenr0.SelectedValue = "0" Or ddlNationality.SelectedValue = "0" Or ddlStudio.SelectedValue = "0" Then
                    lblError.Visible = True
                    lblError.Text = "Please check require flield (*)"
                Else
                    lblError.Visible = False

                    Dim strMovie_Status As String = ""
                    If ddlAppear.SelectedValue.Trim() = "3" Then
                        strMovie_Status = "4"
                    ElseIf ddlAppear.SelectedValue.Trim() = "2" Then
                        strMovie_Status = "1"
                    ElseIf ddlAppear.SelectedValue.Trim() = "1" Then
                        strMovie_Status = "1"
                    Else
                        strMovie_Status = "1"
                        'Else
                        '    If (Convert.ToString(ViewState("Movie_Status")) <> "") Then
                        '        strMovie_Status = Convert.ToString(ViewState("Movie_Status"))
                        '    Else
                        '        strMovie_Status = "1"
                        '    End If
                    End If

                    '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                    ''AddMovies.addMovies(movieId, txtCode.Text, txtName2.Text, txtName1.Text, clnDate.SelectedDate.ToString("yyyyMMdd"), Today().ToString("yyyyMMdd"), strMovie_Status, ddlType.SelectedValue, Session("UserID"), ddlStudio.SelectedValue, ddlDistibutor.SelectedValue, ddlGenr.SelectedItem.Text, ddlGenr0.SelectedItem.Text, ddlPattern.SelectedItem.Text, ddlNationality.SelectedItem.Text, txtDirector.Text, txtCast1.Text, txtCast2.Text, CInt(ddlAppear.SelectedValue), Convert.ToDecimal(f1), Convert.ToDecimal(f2), txtComment.Text.Trim, adpubamt, printcostamt, printqty, strShow_in_report_flag)
                    AddMovies.addMovies(movieId, txtCode.Text, txtName2.Text, txtName1.Text, String.Format("{0:yyyyMMdd}", dtpReleaseDate.SelectedDate), Today().ToString("yyyyMMdd"), strMovie_Status, ddlType.SelectedValue, Session("UserID"), ddlStudio.SelectedValue, ddlDistibutor.SelectedValue, ddlGenr.SelectedItem.Text, ddlGenr0.SelectedItem.Text, ddlPattern.SelectedItem.Text, ddlNationality.SelectedItem.Text, txtDirector.Text, txtCast1.Text, txtCast2.Text, CInt(ddlAppear.SelectedValue), Convert.ToDecimal(f1), Convert.ToDecimal(f2), txtComment.Text.Trim, adpubamt, printcostamt, printqty, strShow_in_report_flag)
                    '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
                    'ลบ tailer
                    If hidAppear.Value <> "3" And ddlAppear.SelectedValue = "3" Then
                        Dim dataReader1 As IDataReader = cDB.GetDataString("*", "tblTrailer_Collection_Dtl", " [movie_id] = " + Session("MovieId").ToString)
                        If dataReader1.Read = False Then
                            Dim wkSQLap As String = "DELETE FROM [tblTrailer_Setup] WHERE [movie_id] = " + Session("MovieId").ToString
                            cDB.updateSQLNow(wkSQLap)
                        End If
                        dataReader1.Close()
                    End If

                    Response.Redirect("frmCTBV_MMD_Movie.aspx")
                End If
            End If

        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            If (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movies_id")).Trim() = "" _
                Or Convert.ToString(DataBinder.Eval(e.Row.DataItem, "theater_id")).Trim() = "") Then
                e.Row.Cells(8).Enabled = False
            End If

            Dim dr As Data.DataRowView = e.Row.DataItem
            If IsDBNull(dr(3)) = False Then

                If dr(3) = "1" Then

                    ' e.Row.BackColor = Color.LightGoldenrodYellow
                    'e.Row.Font.Bold = False
                    e.Row.ForeColor = Color.Green
                    e.Row.Font.Bold = True
                ElseIf dr(3) = "2" Then

                    ' e.Row.BackColor = Color.DarkSeaGreen
                    'e.Row.Font.Bold = True
                    e.Row.ForeColor = Color.DarkGray
                    e.Row.Font.Bold = False
                Else
                    ' e.Row.BackColor = Color.LightSteelBlue
                    'e.Row.Font.Bold = True
                    e.Row.ForeColor = Color.LightGray
                    e.Row.Font.Bold = False
                End If
            Else
                ' e.Row.BackColor = Color.LightSteelBlue
                'e.Row.Font.Bold = True
                e.Row.ForeColor = Color.Red
                e.Row.Font.Bold = False
                e.Row.Cells(4).Text = " No Response"
            End If
        End If

    End Sub

    Protected Sub imbDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDelete.Click
        Dim wkSQL As String
        'If hidDEL_tblCompRevenue.Value = 1 Then
        '    wkSQL = "DELETE FROM [tblCompRevenue] WHERE [movies_id] = " + Session("MovieId").ToString
        '    cDB.updateSQLNow(wkSQL)
        'End If
        'If hidDEL_tblRelease.Value = 1 Then
        '    wkSQL = "DELETE FROM [tblRelease] WHERE [movies_id] = " + Session("MovieId").ToString
        '    cDB.updateSQLNow(wkSQL)
        'End If
        'If hidDEL_tblRevenue.Value = 1 Then
        '    wkSQL = "DELETE FROM [tblRevenue] WHERE [movies_id] = " + Session("MovieId").ToString
        '    cDB.updateSQLNow(wkSQL)
        'End If
        Dim wkSQLap As String = "DELETE FROM [tblTrailer_Setup_Dtl] WHERE [movie_id] = " + Session("MovieId").ToString
        cDB.updateSQLNow(wkSQLap)
        wkSQL = "DELETE FROM [tblMovie] WHERE [movie_id] = " + Session("MovieId").ToString
        cDB.updateSQLNow(wkSQL)

        Response.Redirect("frmCTBV_MMD_Movie.aspx")
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        GridView1.DataBind()
    End Sub

    Sub CheckMovieID()
        If Not IsPostBack Then
            Dim dataReader1 As IDataReader = cDB.GetDataString("*", "tblRevenue", " [movies_id] = " + Session("MovieId").ToString)
            If dataReader1.Read = True Then
                hidDEL_tblRevenue.Value = "1"
            Else
                hidDEL_tblRevenue.Value = "0"
            End If
            dataReader1.Close()

            Dim dataReader2 As IDataReader = cDB.GetDataString("*", "tblCompRevenue", " [movies_id] = " + Session("MovieId").ToString)
            If dataReader2.Read = True Then
                hidDEL_tblCompRevenue.Value = "1"
            Else
                hidDEL_tblCompRevenue.Value = "0"
            End If
            dataReader2.Close()

            Dim dataReader3 As IDataReader = cDB.GetDataString("*", "tblRelease", " [movies_id] = " + Session("MovieId").ToString)
            If dataReader3.Read = True Then
                hidDEL_tblRelease.Value = "1"
            Else
                hidDEL_tblRelease.Value = "0"
            End If
            dataReader3.Close()

            Dim dataReader4 As IDataReader = cDB.GetDataString("*", "tblTrailer_Collection_Dtl", " [movie_id] = " + Session("MovieId").ToString)
            If dataReader4.Read = True Then
                hidTrailerColDtl.Value = "1"
            Else
                hidTrailerColDtl.Value = "0"
            End If
            dataReader4.Close()

            If hidDEL_tblRevenue.Value = "1" Or hidDEL_tblCompRevenue.Value = "1" Or hidDEL_tblRelease.Value = "1" Or hidTrailerColDtl.Value = "1" Then
                imbDelete.OnClientClick = "alert('Can not delete. The movie was referenced by another program.'); return false;"
            ElseIf hidDEL_tblRevenue.Value = "0" And hidDEL_tblCompRevenue.Value = "0" And hidDEL_tblRelease.Value = "0" And hidTrailerColDtl.Value = "0" Then
                imbDelete.OnClientClick = "return confirm('Do you want to delete this movie?')"
            Else
                imbDelete.OnClientClick = ""
            End If


        End If

    End Sub


    Private Sub ShowData(ByVal sort As String)
        Try
            Dim strCommand As String = ""
            strCommand = " SELECT tblTheater.theater_name, tblTheater.theater_code, temprelease.onrelease_id, temprelease.onrelease_status"
            strCommand += " , temprelease.onrelease_startdate, tblMovieStatus.movie_statusTitle, tblMovieStatus.movie_statusCode"
            strCommand += " , temprelease.onrelease_enddate, temprelease.movies_id, tblTheater.theater_id, temprelease.print_qty"
            strCommand += " FROM tblMovieStatus "
            strCommand += " RIGHT OUTER JOIN "
            strCommand += " (SELECT r.onrelease_id, r.onrelease_status, r.onrelease_startdate, r.onrelease_enddate, "
            strCommand += " r.movies_id, r.theater_id, isnull(mt.print_qty, 0) as print_qty"
            strCommand += " FROM tblRelease r"
            strCommand += " left join tblMovie_Theater mt on r.movies_id = mt.movie_id"
            strCommand += " and r.theater_id = mt.theater_id"
            strCommand += " WHERE (movies_id = " + Request.QueryString("titleId") + ")"
            strCommand += " ) AS temprelease ON tblMovieStatus.movie_statusId = temprelease.onrelease_status "
            strCommand += " RIGHT OUTER JOIN "
            strCommand += " (SELECT theater_id, theater_code, theater_name, theater_des, theater_status, theater_lastupdate, user_id, circuit_id "
            strCommand += " FROM tblTheater AS tblTheater_1 "
            strCommand += " WHERE (theater_status = 'Enabled')"
            strCommand += " ) "
            strCommand += " AS tblTheater ON temprelease.theater_id = tblTheater.theater_id "
            strCommand += " ORDER BY temprelease.onrelease_status, tblTheater.theater_name"


            Dim dtb As New DataTable
            dtb = cDatabase.GetDataTable(strCommand)
            Dim dtv As New DataView
            dtv = dtb.DefaultView
            If (sort.Trim() <> "") Then
                dtv.Sort = sort
            End If

            GridView1.DataSource = dtv
            GridView1.DataBind()

        Catch ex As Exception
            txtCode.Text = ex.Message
        End Try
    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        GridView1.EditIndex = e.NewEditIndex
        ShowData("")
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim strSQL As String = ""


        Dim txt As TextBox
        Dim txttheater_id1 As TextBox
        txt = GridView1.Rows(e.RowIndex).FindControl("editprint_qty")
        txttheater_id1 = GridView1.Rows(e.RowIndex).FindControl("txttheater_id")
        If txt.Text.Trim = "" Then
            txt.Text = 0
        End If
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
        strSQL = "EXEC spTblMovie_Theater_Insert " + Request.QueryString("titleId") + _
                    "," + txttheater_id1.Text + _
                    "," + txt.Text + _
                    "," + Session("UserID") + _
                    "," + Session("UserID") + _
                    "," + ConvertTimeToLocaltime(saveDatetimeNow)
        'strSQL = "EXEC spTblMovie_Theater_Insert 1,@theater_id,@print_qty,@create_by,@last_update_by"

        'If (Session("UserID") <> Nothing) Then
        cDB.updateSQLNow(strSQL)
        'End If

        GridView1.EditIndex = -1

        ShowData("")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        ShowData(e.SortExpression + " " + ConvertSortDirectionToSql(e.SortExpression, e.SortDirection))
    End Sub

    Private Function ConvertSortDirectionToSql(ByVal SortExpression As String, ByVal SortDirection As SortDirection) As String
        Dim newSortDirection As String

        If (ViewState("sortby")) Is Nothing Then
            newSortDirection = "ASC"
            ViewState("sort") = "ASC"
            ViewState("sortby") = SortExpression
            Return newSortDirection
        ElseIf Convert.ToString(ViewState("sortby")).Trim() <> SortExpression Then
            newSortDirection = "ASC"
            ViewState("sort") = "ASC"
            ViewState("sortby") = SortExpression
            Return newSortDirection
        End If

        If ViewState("sort") Is Nothing Then
            If (SortDirection = SortDirection.Ascending) Then
                newSortDirection = "DESC"
                ViewState("sort") = "DESC"
            Else
                newSortDirection = "ASC"
                ViewState("sort") = "ASC"
            End If
        Else
            If (Convert.ToString(ViewState("sort")) = "ASC") Then
                newSortDirection = "DESC"
                ViewState("sort") = "DESC"
            Else
                newSortDirection = "ASC"
                ViewState("sort") = "ASC"
            End If
        End If

        Return newSortDirection
    End Function

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        ShowData("")
    End Sub

    '--- Modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection
    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    clnDate.Visible = True
    ''End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    ''    txtReleaseDate.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''    clnDate.Visible = False
    ''End Sub

    ''Protected Sub ddlClnYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYear.SelectedIndexChanged
    ''    If ddlClnYear.SelectedIndex = 0 Then
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
    ''    Else
    ''        Dim intYear As String = CInt(ddlClnYear.SelectedItem.Text)
    ''        clnDate.TodaysDate = Convert.ToDateTime(Format(clnDate.SelectedDate, "MM") + "/" + Format(clnDate.SelectedDate, "dd") + "/" + intYear)
    ''    End If
    ''End Sub
    '--- End modified by Wittawat W. (CSI) on 2012/12/25 : Modify date selection

End Class


