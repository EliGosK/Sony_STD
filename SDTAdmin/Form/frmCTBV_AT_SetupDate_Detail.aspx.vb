Imports System.Web.Security
Imports Web.Data
Imports System.Drawing


Partial Public Class frmCTBV_AT_SetupDate_Detail
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Try
            'Put user code to initialize the page here
            If Mid(Session("permission"), 43, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If

            lblErrorHead.Visible = False
            lblErrorRe1.Visible = False
            lblErrorRe2.Visible = False
            lblErrorDup3.Visible = False
            lblErrorInvalidDate.Visible = False

            If (Not (Page.IsPostBack)) Then
                
                ddlClnYearFrom.Items.Clear()
                cDB.BindYear(ddlClnYearFrom, 5, 5)
                ddlClnYearTo.Items.Clear()
                cDB.BindYear(ddlClnYearTo, 5, 5)

                ShowData()
                ShowDataDetail()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ShowData()
        If (Not (Request.QueryString("movie_setup_no") Is Nothing)) Then
            btnSaveHead.OnClientClick = "return confirm('Date range was changed, Are you sure to confirm this period?')"

            BindData(Convert.ToString(Request.QueryString("movie_setup_no")))
        ElseIf (Not (txtHeadId.Value.Trim() = "")) Then
            BindData(txtHeadId.Value.Trim())
        Else
            ClearData()
            ClearDataDetail()
            EnableData(True)
        End If
    End Sub

    Sub EnableData(ByVal paStatus As Boolean)
        ''''btnCalendar.Enabled = paStatus
        ''''btnCalendar0.Enabled = paStatus
        ''''btnSaveHead.Enabled = paStatus

        'If paStatus = False Then
        '    btnCalendar.ImageUrl = "~/images/calendar_02.jpg"
        '    btnCalendar0.ImageUrl = "~/images/calendar_02.jpg"
        'Else
        btnCalendar.ImageUrl = "~/images/calendar_01.jpg"
        btnCalendar0.ImageUrl = "~/images/calendar_01.jpg"
        'End If
    End Sub

    Private Sub BindData(ByVal movie_setup_no As String)
        Dim cDB As New cDatabase
        If (Not (movie_setup_no.Trim() = "")) Then
            Dim dataReader As IDataReader = cDB.getChecker_MovieHeaderRead(movie_setup_no.Trim())
            If dataReader.Read = True Then
                txtStartDate.Text = Convert.ToDateTime(dataReader("setup_start_date")).ToString("ddd dd-MMM-yyyy")
                txtEndDate.Text = Convert.ToDateTime(dataReader("setup_end_date")).ToString("ddd dd-MMM-yyyy")
                clnDateFrom.SelectedDate = Convert.ToDateTime(dataReader("setup_start_date"))
                clnDateTo.SelectedDate = Convert.ToDateTime(dataReader("setup_end_date"))

                If Date.Now.AddDays(-1) > Convert.ToDateTime(dataReader("setup_end_date")) Then
                    EnableData(False)
                Else
                    EnableData(True)
                End If

                txtHeadId.Value = dataReader("movie_setup_no")
                txtmovie_setup_no.Text = Convert.ToString(dataReader("movie_setup_no")).Substring(6, 2) _
                                    + "-" + Convert.ToString(dataReader("movie_setup_no")).Substring(4, 2) _
                                    + "-" + Convert.ToString(dataReader("movie_setup_no")).Substring(0, 4)

                ShowDataDetail()
            End If
            dataReader.Close()
        Else
            ClearData()
            ClearDataDetail()
            'GridView1.DataSource = Nothing
            'GridView1.DataBind()
        End If
    End Sub

    Protected Sub ShowDataDetail()
        If (txtHeadId.Value.Trim() <> "") Then
            'sqlMovies.SelectCommand = cDatabase.Query_Checker_Movie_Detail(txtHeadId.Value.Trim(), "") 'Convert.ToString(Session("Circuit_Id")), Convert.ToString(Session("TheaterId")),
            'GridView1.DataSourceID = "sqlMovies"
            If (Convert.ToString(Request.QueryString("movie_setup_no")) <> "") Then
                GridView1.DataSource = cDatabase.GetDataTable(cDatabase.Query_Checker_Movie_Detail(Convert.ToString(Request.QueryString("movie_setup_no")), ""))
                GridView1.DataBind()
            Else
                GridView1.DataSource = cDatabase.GetDataTable(cDatabase.Query_Checker_Movie_Detail(txtHeadId.Value.Trim(), ""))
                ' GridView1.DataSource = cDatabase.Query_Checker_Movie_Detail(txtHeadId.Value.Trim(), "") 'Convert.ToString(Session("Circuit_Id")), Convert.ToString(Session("TheaterId")),
                GridView1.DataBind()
            End If


        End If
    End Sub

    Protected Sub ClearData()
        txtmovie_setup_no.Text = ""
        txtHeadId.Value = ""
        txtStartDate.Text = ""
        txtEndDate.Text = ""

        clnDateFrom.SelectedDate = New DateTime()
        clnDateTo.SelectedDate = New DateTime()
    End Sub

    Protected Sub ClearDataDetail()
        '' ''Movie1Popup1.MovieId = 0
        '' ''SelectColor1.ColorCode = ""
        '' ''SelectColor2.ColorCode = ""
        txtId.Value = ""

        '' ''Movie1Popup1.Enabled = True
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub


    'Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click

    '    If Movie1Popup1.MovieId = 0 Then
    '        lblError.Visible = True
    '        lblErrorDup2.Visible = True
    '        Return

    '    Else
    '        lblError.Visible = False
    '        Dim cDB As New cDatabase

    '        If (txtId.Value.Trim() = "") Then
    '            Dim getMovieDetail As New cDatabase
    '            Dim dataReader As IDataReader = getMovieDetail.getTrailerDetailRead(txtHeadId.Value.Trim(), Movie1Popup1.MovieId)
    '            If dataReader.Read = True Then
    '                lblErrorDup.Visible = True
    '                Return
    '            Else
    '                lblErrorDup.Visible = False
    '            End If
    '            dataReader.Close()

    '            cDB.AddChecker_Movie_Detail(txtHeadId.Value.Trim() _
    '                    , Movie1Popup1.MovieId _
    '                    , 0 _
    '                    , SelectColor1.ColorCode _
    '                    , SelectColor2.ColorCode _
    '                    , DateTime.Now _
    '                    , Convert.ToString(Session("UserID")) _
    '                    , DateTime.Now _
    '                    , Convert.ToString(Session("UserID")))
    '        Else
    '            cDB.UpdateChecker_Movie_Detail(txtHeadId.Value.Trim() _
    '                    , Movie1Popup1.MovieId _
    '                    , 0 _
    '                    , SelectColor1.ColorCode _
    '                    , SelectColor2.ColorCode _
    '                    , DateTime.Now _
    '                    , Convert.ToString(Session("UserID")))
    '        End If

    '        ShowData()
    '        ClearDataDetail()
    '    End If
    'End Sub


    'Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
    '    ClearDataDetail()
    'End Sub

    Protected Sub btnSaveHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveHead.Click
        Try
            If txtStartDate.Text.Trim() = "" Or txtEndDate.Text.Trim() = "" Then
                lblErrorHead.Visible = True
                lblErrorRe1.Visible = True
                lblErrorRe2.Visible = True
                Return
            Else
                If clnDateTo.SelectedDate < clnDateFrom.SelectedDate Then
                    lblErrorInvalidDate.Visible = True
                    Return
                End If

                Dim cDB As New cDatabase
                'เช็คซ้ำ
                Dim dataReader As IDataReader = cDB.getChecker_MovieHeaderByPeriodDateRead(clnDateFrom.SelectedDate, clnDateTo.SelectedDate, txtHeadId.Value.Trim())
                If dataReader.Read = True Then
                    'If (clnDateFrom.SelectedDate < Convert.ToDateTime(dataReader("setup_end_date"))) _
                    '    Or (clnDateFrom.SelectedDate = Convert.ToDateTime(dataReader("setup_end_date"))) _
                    'Then
                    lblErrorDup3.Visible = True
                    Return
                    'End If
                End If
                dataReader.Close()

                If (txtHeadId.Value.Trim() = "") Then
                    Dim dataReader1 As IDataReader = cDB.getMaxChecker_Movie_SetupNo(clnDateFrom.SelectedDate)

                    Dim intGenMax As Integer = 0
                    If dataReader1.Read = True Then
                        intGenMax = Convert.ToInt32(dataReader1("Max_SetupNo"))
                    End If
                    dataReader1.Close()

                    'Dim strSeup_No As String = Convert.ToString(DateTime.Now.Year) _
                    '                + DateTime.Now.Month.ToString("00") _
                    '                + (intGenMax + 1).ToString("00")

                    Dim strSeup_No As String = clnDateFrom.SelectedDate.Year.ToString("0000") _
                                                    + clnDateTo.SelectedDate.Month.ToString("00") _
                                                    + (intGenMax + 1).ToString("00")
                    Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

                    '06/03/2010'

                    cDB.AddChecker_Movie_Head(strSeup_No _
                            , clnDateFrom.SelectedDate _
                            , clnDateTo.SelectedDate _
                            , ConvertTimeToLocaltime(saveDatetimeNow) _
                            , Convert.ToString(Session("UserID")) _
                            , ConvertTimeToLocaltime(saveDatetimeNow) _
                            , Convert.ToString(Session("UserID")))


                    ''cDB.AddChecker_Movie_Head(strSeup_No _
                    ''        , clnDateFrom.SelectedDate _
                    ''        , clnDateTo.SelectedDate _
                    ''        , DateTime.Now _
                    ''        , Convert.ToString(Session("UserID")) _
                    ''        , DateTime.Now _
                    ''        , Convert.ToString(Session("UserID")))

                    txtHeadId.Value = strSeup_No
                    'txtmovie_setup_no.Text = strSeup_No

                    txtmovie_setup_no.Text = strSeup_No.Substring(6, 2) _
                                        + strSeup_No.Substring(4, 2) _
                                        + strSeup_No.Substring(0, 4)

                    Response.Redirect("frmCTBV_AT_SetupDate_Detail.aspx?movie_setup_no=" + strSeup_No.ToString())

                Else
                    Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

                    cDB.UpdateChecker_Movie_Head(txtHeadId.Value.Trim() _
                        , clnDateFrom.SelectedDate _
                       , clnDateTo.SelectedDate _
                       , ConvertTimeToLocaltime(saveDatetimeNow) _
                       , Convert.ToString(Session("UserID")))

                End If

                ShowData()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnDeleteHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDeleteHead.Click
        Try
            Response.Redirect("frmCTBV_AT_SetupDate.aspx")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateFrom.SelectionChanged
        Try
            txtStartDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
            clnDateTo.SelectedDate = clnDateFrom.SelectedDate.AddDays(+6)
            txtEndDate.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
            clnDateFrom.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub clnDate0_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateTo.SelectionChanged
        Try
            txtEndDate.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
            clnDateTo.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
        clnDateFrom.Visible = True
    End Sub

    Protected Sub btnCalendar0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar0.Click
        clnDateTo.Visible = True
    End Sub

    '-----------------Gridview
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        '' ''If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

        '' ''    If (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_id")).Trim() = "" _
        '' ''        Or Convert.ToString(DataBinder.Eval(e.Row.DataItem, "theater_id")).Trim() = "") Then
        '' ''        e.Row.Cells(8).Enabled = False
        '' ''    End If

        '' ''    Dim dr As Data.DataRowView = e.Row.DataItem
        '' ''    If IsDBNull(dr(3)) = False Then

        '' ''        If dr(3) = "1" Then

        '' ''            ' e.Row.BackColor = Color.LightGoldenrodYellow
        '' ''            'e.Row.Font.Bold = False
        '' ''            e.Row.ForeColor = Color.Green
        '' ''            e.Row.Font.Bold = True
        '' ''        ElseIf dr(3) = "2" Then

        '' ''            ' e.Row.BackColor = Color.DarkSeaGreen
        '' ''            'e.Row.Font.Bold = True
        '' ''            e.Row.ForeColor = Color.DarkGray
        '' ''            e.Row.Font.Bold = False
        '' ''        Else
        '' ''            ' e.Row.BackColor = Color.LightSteelBlue
        '' ''            'e.Row.Font.Bold = True
        '' ''            e.Row.ForeColor = Color.LightGray
        '' ''            e.Row.Font.Bold = False
        '' ''        End If
        '' ''    Else
        '' ''        ' e.Row.BackColor = Color.LightSteelBlue
        '' ''        'e.Row.Font.Bold = True
        '' ''        e.Row.ForeColor = Color.Red
        '' ''        e.Row.Font.Bold = False
        '' ''        e.Row.Cells(4).Text = " No Response"
        '' ''    End If
        '' ''End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        Try
            GridView1.DataSource = cDatabase.Query_Checker_Movie_Detail(Convert.ToString(Request.QueryString("movie_setup_no")), "")
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Try

            GridView1.EditIndex = e.NewEditIndex
            ShowDataDetail()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Try
            Dim strSQL As String = ""

            Dim txtLevel As TextBox
            Dim txtMovie_id As TextBox
            txtLevel = GridView1.Rows(e.RowIndex).FindControl("editLevel") 'movie_level_id
            txtMovie_id = GridView1.Rows(e.RowIndex).FindControl("txtLevel") 'movie_id

            '------------------
            If txtLevel.Text.Trim() <> "" Then
                Dim strSQLlevel As String
                strSQLlevel = "SELECT movie_setup_no  "
                strSQLlevel += " FROM tblChecker_Movie_Setup_Dtl "
                strSQLlevel += " WHERE movie_setup_no ='" + Request.QueryString("movie_setup_no") + "'"
                strSQLlevel += " AND movie_level_id = " + txtLevel.Text.Trim()
                strSQLlevel += " AND movie_id <> " + txtMovie_id.Text.Trim()

                Dim dataReader As IDataReader = cDB.GetDataAll(strSQLlevel)
                If dataReader.Read = True Then
                    lblErrorLevel.Text = "Seq. No. has exist."
                    lblErrorLevel.Visible = True
                    dataReader.Close()
                    Exit Sub
                End If
                dataReader.Close()
            End If

            lblErrorLevel.Visible = False
            Dim rdoPresent As RadioButton
            Dim presentSave As String
            rdoPresent = GridView1.Rows(e.RowIndex).FindControl("rdoPresentY")
            If rdoPresent.Checked = True Then
                presentSave = "Y"
            Else
                presentSave = "N"
            End If

            Dim chkCollect As CheckBox
            Dim CollectSave As String
            chkCollect = GridView1.Rows(e.RowIndex).FindControl("chkCollect")
            If chkCollect.Checked = True Then
                CollectSave = "Y"
            Else
                CollectSave = "N"
            End If

            Dim MoviesIdSave As Integer = Convert.ToInt32(txtMovie_id.Text)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
           
            If txtLevel.Text.Trim() = "" Then
                cDB.UpdateChecker_MovieDetail(Request.QueryString("movie_setup_no"), _
                             MoviesIdSave, _
                             0, _
                             presentSave, _
                             CollectSave, _
                             ConvertTimeToLocaltime(saveDatetimeNow), _
                             Session("UserID").ToString())

            Else 
                cDB.UpdateChecker_MovieDetail(Request.QueryString("movie_setup_no"), _
                            MoviesIdSave, _
                            Convert.ToInt32(txtLevel.Text), _
                            presentSave, _
                            CollectSave, _
                            ConvertTimeToLocaltime(saveDatetimeNow), _
                            Session("UserID").ToString())
            End If


            
            GridView1.EditIndex = -1

            ShowDataDetail()

            '----------------------

        Catch ex As Exception
            lblErrorLevel.Text = ex.Message

        End Try


    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        'e.SortExpression + " " + ConvertSortDirectionToSql(e.SortExpression, e.SortDirection))
        Try
            ShowData()
        Catch ex As Exception

        End Try
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
        Try
            GridView1.EditIndex = -1
            ShowDataDetail()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub ddlClnYearFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearFrom.SelectedIndexChanged
        Try
            If ddlClnYearFrom.SelectedIndex = 0 Then
                clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
            Else
                Dim intYear As String = CInt(ddlClnYearFrom.SelectedItem.Text)
                clnDateFrom.TodaysDate = Convert.ToDateTime(Format(clnDateFrom.SelectedDate, "MM") + "/" + Format(clnDateFrom.SelectedDate, "dd") + "/" + intYear)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlClnYearTo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlClnYearTo.SelectedIndexChanged
        Try
            If ddlClnYearTo.SelectedIndex = 0 Then
                clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + DateTime.Now.Year.ToString("0000"))
            Else
                Dim intYear As String = CInt(ddlClnYearTo.SelectedItem.Text)
                clnDateTo.TodaysDate = Convert.ToDateTime(Format(clnDateTo.SelectedDate, "MM") + "/" + Format(clnDateTo.SelectedDate, "dd") + "/" + intYear)
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class
