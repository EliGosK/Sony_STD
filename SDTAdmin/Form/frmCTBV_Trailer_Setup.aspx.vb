Imports System.Web.Security
Imports Web.Data
Imports System.Drawing

Partial Class frmCTBV_Trailer_Setup
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        lblError.Visible = False
        lblErrorDup2.Visible = False
        lblErrorHead.Visible = False
        lblErrorRe1.Visible = False
        lblErrorRe2.Visible = False
        lblErrorDup3.Visible = False
        lblErrorInvalidDate.Visible = False

        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        If (Not (Page.IsPostBack)) Then
            ''ddlClnYearFrom.Items.Clear()
            ''cDB.BindYear(ddlClnYearFrom, 5, 5)
            ''ddlClnYearTo.Items.Clear()
            ''cDB.BindYear(ddlClnYearTo, 5, 5)

            ShowData()
        ElseIf txtHeadId.Value.Trim() <> "" Then
            ShowDataDetail()
        End If
    End Sub

    Protected Sub ShowData()
        If (Not (Request.QueryString("setup_no") Is Nothing)) Then
            BindData(Convert.ToString(Request.QueryString("setup_no")))
        ElseIf (Not (txtHeadId.Value.Trim() = "")) Then
            BindData(txtHeadId.Value.Trim())
        Else
            ClearData()
            ClearDataDetail()
            EnableData(True)
        End If
    End Sub

    Sub EnableData(ByVal paStatus As Boolean)
        ''btnCalendar.Enabled = paStatus
        ''btnCalendar0.Enabled = paStatus
        ''btnSaveHead.Visible = paStatus
        ''Panel1.Enabled = paStatus
        ''If paStatus = False Then
        ''    btnCalendar.ImageUrl = "~/images/calendar_02.jpg"
        ''    btnCalendar0.ImageUrl = "~/images/calendar_02.jpg"
        ''Else
        ''    btnCalendar.ImageUrl = "~/images/calendar_01.jpg"
        ''    btnCalendar0.ImageUrl = "~/images/calendar_01.jpg"
        ''End If
        dtpStartDate.TxtDateEnable = paStatus
        dtpEndDate.TxtDateEnable = paStatus
        btnSaveHead.Visible = paStatus
        Panel1.Enabled = paStatus
    End Sub

    Private Sub BindData(ByVal setup_no As String)
        Dim pManage As New cDatabase
        If (Not (setup_no.Trim() = "")) Then
            Dim dataReader As IDataReader = pManage.getTrailerHeaderRead(setup_no.Trim())
            If dataReader.Read = True Then
                ''txtStartDate.Text = Convert.ToDateTime(dataReader("setup_start_date")).ToString("ddd dd-MMM-yyyy")
                ''txtEndDate.Text = Convert.ToDateTime(dataReader("setup_end_date")).ToString("ddd dd-MMM-yyyy")
                ''clnDateFrom.SelectedDate = Convert.ToDateTime(dataReader("setup_start_date"))
                ''clnDateTo.SelectedDate = Convert.ToDateTime(dataReader("setup_end_date"))
                dtpStartDate.SelectedDate = dataReader("setup_start_date")
                dtpEndDate.SelectedDate = dataReader("setup_end_date")

                If Date.Now.AddDays(-1) > Convert.ToDateTime(dataReader("setup_end_date")) Then
                    EnableData(False)
                Else
                    EnableData(True)
                End If

                txtHeadId.Value = dataReader("setup_no")
                txtSetup_No.Text = Convert.ToString(dataReader("setup_no")).Substring(6, 2) _
                                    + "-" + Convert.ToString(dataReader("setup_no")).Substring(4, 2) _
                                    + "-" + Convert.ToString(dataReader("setup_no")).Substring(0, 4)

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
            sqlMovies.SelectCommand = cDatabase.Query_Trailer_Detail(txtHeadId.Value.Trim(), "") 'Convert.ToString(Session("Circuit_Id")), Convert.ToString(Session("TheaterId")),
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub ClearData()
        txtSetup_No.Text = ""
        txtHeadId.Value = ""
        ''txtStartDate.Text = ""
        ''txtEndDate.Text = ""
        ''clnDateFrom.SelectedDate = New DateTime()
        ''clnDateTo.SelectedDate = New DateTime()
        dtpStartDate.SelectedDate = Nothing
        dtpEndDate.SelectedDate = Nothing
    End Sub

    Protected Sub ClearDataDetail()
        Movie1Popup1.MovieId = 0
        SelectColor1.ColorCode = ""
        SelectColor2.ColorCode = ""
        txtId.Value = ""

        Movie1Popup1.Enabled = True
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim strBgCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_background_color")).Trim()
            Dim strFontCode As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "movie_font_color")).Trim()

            If (strBgCode <> "") Then
                e.Row.Cells(2).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
            Else
                e.Row.Cells(2).BackColor = System.Drawing.Color.White
            End If

            If (strFontCode <> "") Then
                e.Row.Cells(2).ForeColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_font_color"))
            Else
                e.Row.Cells(2).ForeColor = System.Drawing.Color.Black
            End If

            'e.Row.Cells(2).BackColor = System.Drawing.Color.FromName(DataBinder.Eval(e.Row.DataItem, "movie_background_color"))
        End If

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim id As String = DataBinder.Eval(e.Row.DataItem, "movie_id")
            Dim pManage As New cDatabase
            Dim dataReader As IDataReader = pManage.GetDataString("ref_setup_no", "tblTrailer_Collection_Dtl", "movie_id='" + id + "'" + " AND ref_setup_no='" + DataBinder.Eval(e.Row.DataItem, "setup_no") + "'")
            Dim btnDeletcol As LinkButton = e.Row.Cells(1).FindControl("btnDelete")
            If dataReader.Read = True Then
                btnDeletcol.OnClientClick = "alert('Can not delete. The movie was referenced by another program.'); return false;"
            Else
                btnDeletcol.OnClientClick = "return confirm('Do you want to delete this movie?')"
            End If
            dataReader.Close()
        End If
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        If Movie1Popup1.MovieId = 0 Then
            lblError.Visible = True
            lblErrorDup2.Visible = True
            Return
        Else
            lblError.Visible = False
            Dim pManage As New cDatabase
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            If (txtId.Value.Trim() = "") Then
                Dim getMovieDetail As New cDatabase
                Dim dataReader As IDataReader = getMovieDetail.getTrailerDetailRead(txtHeadId.Value.Trim(), Movie1Popup1.MovieId)
                If dataReader.Read = True Then
                    lblErrorDup.Visible = True
                    Return
                Else
                    lblErrorDup.Visible = False
                End If
                dataReader.Close()

                pManage.AddTrailer_Detail(txtHeadId.Value.Trim() _
                        , Movie1Popup1.MovieId _
                        , SelectColor1.ColorCode _
                        , SelectColor2.ColorCode _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")) _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")))
            Else
                pManage.UpdateTrailer_Detail(txtHeadId.Value.Trim() _
                        , Movie1Popup1.MovieId _
                        , SelectColor1.ColorCode _
                        , SelectColor2.ColorCode _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")))
            End If

            ShowData()
            ClearDataDetail()
        End If
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        ClearDataDetail()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Me.GridView1.PageIndex = e.NewPageIndex
        ShowData()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "Select" Then
            Dim Movie_Id As Integer = Convert.ToInt32(e.CommandArgument)

            Dim pManage As New cDatabase()

            Dim getMovieDetail As New cDatabase
            Dim dataReader As IDataReader = getMovieDetail.getTrailerDetailRead(txtHeadId.Value, Movie_Id)
            If dataReader.Read = True Then
                Movie1Popup1.MovieId = Convert.ToInt32(dataReader("movie_id"))
                SelectColor1.ColorCode = Convert.ToString(dataReader("movie_background_color"))
                SelectColor2.ColorCode = Convert.ToString(dataReader("movie_font_color"))
                'txtName.Text = dataReader("movie_nameen") + "/" + dataReader("movie_nameth")
            End If
            dataReader.Close()

            txtId.Value = Movie_Id.ToString()

            Movie1Popup1.Enabled = False
        ElseIf e.CommandName = "Del" Then
            Dim Movie_Id As Integer = Convert.ToInt32(e.CommandArgument)
            Dim pManage As New cDatabase()
            pManage.deleteTrailer_Detail(txtHeadId.Value.Trim(), Movie_Id)
            ShowData()
        End If

    End Sub

    Protected Sub btnSaveHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSaveHead.Click
        ''If txtStartDate.Text.Trim() = "" Or txtEndDate.Text.Trim() = "" Then
        ''    lblErrorHead.Visible = True
        ''    lblErrorRe1.Visible = True
        ''    lblErrorRe2.Visible = True
        ''    Return
        ''Else
        ''    If Convert.ToDateTime(txtEndDate.Text.Trim()) < Convert.ToDateTime(txtStartDate.Text.Trim()) Then
        ''        lblErrorInvalidDate.Visible = True
        ''        Return
        ''    End If

        ''    Dim pManage As New cDatabase
        ''    'àªç¤«éÓ
        ''    Dim dataReader As IDataReader = pManage.getTrailerHeaderByPeriodDateRead(Convert.ToDateTime(txtStartDate.Text.Trim()), Convert.ToDateTime(txtEndDate.Text.Trim()), txtHeadId.Value.Trim())
        ''    If dataReader.Read = True Then
        ''        'If (Convert.ToDateTime(txtStartDate.Text.Trim()) < Convert.ToDateTime(dataReader("setup_end_date"))) _
        ''        '    Or (Convert.ToDateTime(txtStartDate.Text.Trim()) = Convert.ToDateTime(dataReader("setup_end_date"))) _
        ''        'Then
        ''        lblErrorDup3.Visible = True
        ''        Return
        ''        'End If
        ''    End If
        ''    dataReader.Close()

        ''    If (txtHeadId.Value.Trim() = "") Then
        ''        Dim dataReader1 As IDataReader = pManage.getMaxTrailer_SetupNo()

        ''        Dim intGenMax As Integer = 0
        ''        If dataReader1.Read = True Then
        ''            intGenMax = Convert.ToInt32(dataReader1("Max_SetupNo"))
        ''        End If
        ''        dataReader1.Close()

        ''        Dim strSeup_No As String = Convert.ToString(DateTime.Now.Year) _
        ''                        + DateTime.Now.Month.ToString("00") _
        ''                        + (intGenMax + 1).ToString("00")

        ''        pManage.AddTrailer_Head(strSeup_No _
        ''                , Convert.ToDateTime(txtStartDate.Text.Trim()) _
        ''                , Convert.ToDateTime(txtEndDate.Text.Trim()) _
        ''                , DateTime.Now _
        ''                , Convert.ToString(Session("UserID")) _
        ''                , DateTime.Now _
        ''                , Convert.ToString(Session("UserID")))

        ''        If SetupPopup1.SetupNo <> "" Then
        ''            CopySetupDetail(strSeup_No, SetupPopup1.SetupNo)
        ''            SetupPopup1.SetupNo = ""
        ''        End If



        ''        txtHeadId.Value = strSeup_No
        ''        'txtSetup_No.Text = strSeup_No

        ''        txtSetup_No.Text = strSeup_No.Substring(6, 2) _
        ''                            + strSeup_No.Substring(4, 2) _
        ''                            + strSeup_No.Substring(0, 4)

        ''    Else
        ''        If SetupPopup1.SetupNo <> "" Then
        ''            CopySetupDetail(txtHeadId.Value.Trim(), SetupPopup1.SetupNo)
        ''            SetupPopup1.SetupNo = ""
        ''        End If

        ''        pManage.UpdateTrailer_Head(txtHeadId.Value.Trim() _
        ''                , Convert.ToDateTime(txtStartDate.Text.Trim()) _
        ''                , Convert.ToDateTime(txtEndDate.Text.Trim()) _
        ''                , DateTime.Now _
        ''                , Convert.ToString(Session("UserID")))
        ''    End If

        ''    ShowData()

        ''End If

        If dtpStartDate.Text.Trim() = "" Or dtpEndDate.Text.Trim() = "" Then
            lblErrorHead.Visible = True
            lblErrorRe1.Visible = True
            lblErrorRe2.Visible = True
            Return
        Else
            If dtpEndDate.SelectedDate < dtpStartDate.SelectedDate Then
                lblErrorInvalidDate.Visible = True
                Return
            End If

            Dim pManage As New cDatabase
            'àªç¤«éÓ
            Dim dataReader As IDataReader = pManage.getTrailerHeaderByPeriodDateRead(dtpStartDate.SelectedDate, dtpEndDate.SelectedDate, txtHeadId.Value.Trim())
            If dataReader.Read = True Then
                'If (Convert.ToDateTime(txtStartDate.Text.Trim()) < Convert.ToDateTime(dataReader("setup_end_date"))) _
                '    Or (Convert.ToDateTime(txtStartDate.Text.Trim()) = Convert.ToDateTime(dataReader("setup_end_date"))) _
                'Then
                lblErrorDup3.Visible = True
                Return
                'End If
            End If
            dataReader.Close()

            If (txtHeadId.Value.Trim() = "") Then
                Dim dataReader1 As IDataReader = pManage.getMaxTrailer_SetupNo()

                Dim intGenMax As Integer = 0
                If dataReader1.Read = True Then
                    intGenMax = Convert.ToInt32(dataReader1("Max_SetupNo"))
                End If
                dataReader1.Close()

                Dim strSeup_No As String = Convert.ToString(DateTime.Now.Year) _
                                + DateTime.Now.Month.ToString("00") _
                                + (intGenMax + 1).ToString("00")

                Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

                pManage.AddTrailer_Head(strSeup_No _
                        , dtpStartDate.SelectedDate _
                        , dtpEndDate.SelectedDate _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")) _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")))

                If SetupPopup1.SetupNo <> "" Then
                    CopySetupDetail(strSeup_No, SetupPopup1.SetupNo)
                    SetupPopup1.SetupNo = ""
                End If



                txtHeadId.Value = strSeup_No
                'txtSetup_No.Text = strSeup_No

                txtSetup_No.Text = strSeup_No.Substring(6, 2) _
                                    + strSeup_No.Substring(4, 2) _
                                    + strSeup_No.Substring(0, 4)

            Else
                If SetupPopup1.SetupNo <> "" Then
                    CopySetupDetail(txtHeadId.Value.Trim(), SetupPopup1.SetupNo)
                    SetupPopup1.SetupNo = ""
                End If
                Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

                pManage.UpdateTrailer_Head(txtHeadId.Value.Trim() _
                        , dtpStartDate.SelectedDate _
                        , dtpEndDate.SelectedDate _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")))
            End If

            ShowData()

        End If
    End Sub

    Sub CopySetupDetail(ByVal paSetupNoNew As String, ByVal paSetupNoCopy As String)
        Dim cDB As New cDatabase()
        Dim sqlSelect As String
        sqlSelect = "SELECT setup_no, movie_id, movie_background_color, movie_font_color, create_dtm, create_by, last_update_dtm, last_update_by"
        sqlSelect += " FROM [tblTrailer_Setup_Dtl] "
        sqlSelect += " WHERE setup_no = '" + paSetupNoCopy + "' and movie_id not in ( select sd.movie_id from tblTrailer_Setup_Dtl sd where sd.setup_no = '" + paSetupNoNew + "') "
        Dim dr As IDataReader = cDB.GetDataAll(sqlSelect)
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
        Dim i As Integer = 1
        While dr.Read()
            cDB.AddTrailer_Detail(paSetupNoNew _
                        , Convert.ToInt32(dr(1)) _
                        , Convert.ToString(dr(2)) _
                        , Convert.ToString(dr(3)) _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")) _
                        , ConvertTimeToLocaltime(saveDatetimeNow) _
                        , Convert.ToString(Session("UserID")))
        End While
        dr.Close()
    End Sub

    Protected Sub btnDeleteHead_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDeleteHead.Click
        Response.Redirect("frmCTBV_Trailer_Setup_Detail.aspx")
    End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateFrom.SelectionChanged
    ''    txtStartDate.Text = Format(clnDateFrom.SelectedDate, "ddd dd-MMM-yyyy")
    ''    clnDateTo.SelectedDate = clnDateFrom.SelectedDate.AddDays(+6)
    ''    txtEndDate.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    ''    clnDateFrom.Visible = False
    ''End Sub

    ''Protected Sub clnDate0_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateTo.SelectionChanged
    ''    txtEndDate.Text = Format(clnDateTo.SelectedDate, "ddd dd-MMM-yyyy")
    ''    clnDateTo.Visible = False
    ''End Sub

    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    clnDateFrom.Visible = True
    ''End Sub

    ''Protected Sub btnCalendar0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar0.Click
    ''    clnDateTo.Visible = True
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
