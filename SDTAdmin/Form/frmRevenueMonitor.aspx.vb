Imports System.Web.Security
Imports System.IO

Partial Public Class frmRevenueMonitor
    Inherits Page

    ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    ''    lblError.Visible = False

    ''    If (Session("permission") Is Nothing) Then
    ''        Response.Redirect("frmCTBV_Login.aspx")
    ''    End If

    ''    If Mid(Session("permission"), 1, 1) = "0" Then
    ''        Response.Redirect("InfoPage.aspx")
    ''    End If

    ''    If Not IsPostBack Then
    ''        Session("revMovieName") = ""
    ''        Session("revMovieStatus") = "1"

    ''        If Hour(Now) < 6 Then
    ''            'clnDate.SelectedDate = Now().AddDays(-1)
    ''            txtDateStart.Text = Format(Now().AddDays(-1), "dd/MM/yyyy")
    ''            Session("revDate") = Format(Now().AddDays(-1), "yyyy/MM/dd")

    ''            'clnDateEnd.SelectedDate = Now().AddDays(-1)
    ''            txtDateStop.Text = Format(Now().AddDays(-1), "dd/MM/yyyy")
    ''            Session("revDateEnd") = Format(Now().AddDays(-1), "yyyy/MM/dd")
    ''        Else
    ''            'clnDate.SelectedDate = Now()
    ''            txtDateStart.Text = Format(Now(), "dd/MM/yyyy")
    ''            Session("revDate") = Format(Now(), "yyyy/MM/dd")

    ''            'clnDateEnd.SelectedDate = Now()
    ''            txtDateStop.Text = Format(Now(), "dd/MM/yyyy")
    ''            Session("revDateEnd") = Format(Now(), "yyyy/MM/dd")
    ''        End If

    ''        Dim strSQL As String
    ''        'strSQL = "  SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''        'strSQL += vbNewLine + " vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''        'strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, vRevToday1.DateStatus, vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession"
    ''        'strSQL += vbNewLine + " FROM vSumRevenue Left JOIN"
    ''        'strSQL += vbNewLine + " (SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms, "
    ''        'strSQL += vbNewLine + " sum(rev_amount) as rev_amount, sum(cntSession) as cntSession, sum(cntScreen) as cntScreen"
    ''        'strSQL += vbNewLine + " FROM vRevToday "
    ''        'strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''        'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111))"
    ''        'strSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''        'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)))"
    ''        'strSQL += vbNewLine + " group by DateStatus, movie_id"
    ''        'strSQL += vbNewLine + " ) AS vRevToday1 ON "
    ''        'strSQL += vbNewLine + " vSumRevenue.movie_id = vRevToday1.movie_id"
    ''        'strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''        'strSQL += vbNewLine + " and (vSumRevenue.movie_status = '1') "
    ''        'strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"

    ''        strSQL = "  SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''        strSQL += vbNewLine + " vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''        strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, "
    ''        strSQL += vbNewLine + "  (SELECT      ISNULL(MAX(dbo.tblCompRevenue.status_id), "
    ''        strSQL += vbNewLine + "  '') + ISNULL(MAX(dbo.tblRevenue.status_id), '') AS DateStatus"
    ''        strSQL += vbNewLine + "  FROM"
    ''        strSQL += vbNewLine + "  dbo.tblMovie"
    ''        strSQL += vbNewLine + "  left join dbo.tblRevenue  on dbo.tblMovie.movie_id = dbo.tblRevenue.movies_id"
    ''        strSQL += vbNewLine + "  left join dbo.tblCompRevenue on dbo.tblMovie.movie_id = dbo.tblCompRevenue.movies_id"
    ''        strSQL += vbNewLine + "  where dbo.tblMovie.movie_id = vSumRevenue.movie_id) DateStatus"
    ''        strSQL += vbNewLine + "  , vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession, vSumRevenue.movie_status"
    ''        strSQL += vbNewLine + "  FROM vSumRevenue "
    ''        strSQL += vbNewLine + "  Left JOIN"
    ''        strSQL += vbNewLine + "  ( "
    ''        strSQL += vbNewLine + " 		select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''        strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''        strSQL += vbNewLine + " 		from "
    ''        strSQL += vbNewLine + " 		("
    ''        strSQL += vbNewLine + " 			 SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''        strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''        strSQL += vbNewLine + " 			 FROM vRevToday "
    ''        strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111) or '" + Session("revDate").ToString + "' is null)"
    ''        strSQL += vbNewLine + " and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111) or '" + Session("revDateEnd").ToString + "' is null))"
    ''        strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111) or '" + Session("revDate").ToString + "' is null)"
    ''        strSQL += vbNewLine + " and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)  or '" + Session("revDateEnd").ToString + "' is null))"
    ''        strSQL += vbNewLine + " 			 group by DateStatus, movie_id "
    ''        strSQL += vbNewLine + " 		) as tblSum"
    ''        strSQL += vbNewLine + " 		group by  movie_id"
    ''        strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''        strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''        strSQL += vbNewLine + " and (vSumRevenue.movie_status = '1') "
    ''        strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"

    ''        ViewState("vSQL") = strSQL
    ''        sqlBoxOffice.SelectCommand = strSQL
    ''        grdBoxOffice.DataSourceID = "sqlBoxOffice"
    ''        grdBoxOffice.DataBind()

    ''        'Check Permission
    ''        'Dim getUserDetail As New cDatabase
    ''        'Dim dataReader As IDataReader = getUserDetail.getUserDetail(Session("UserID"))
    ''        'If dataReader.Read Then
    ''        'grdBoxOffice. = False
    ''        'grdBoxOffice.Rows.Item(0).BackColor = Color.Black
    ''        ' = Mid(dataReader("user_permission"), 2, 1)

    ''    End If
    ''    'dataReader.Close()
    ''    'End If
    ''End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        lblError.Visible = False

        If (Session("permission") Is Nothing) Then
            Response.Redirect("frmCTBV_Login.aspx")
        End If

        If Mid(Session("permission"), 1, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        If Not IsPostBack Then
            Session("revMovieName") = ""
            Session("revMovieStatus") = "1"

            If Hour(Now) < 6 Then
                dtpStartDate.SelectedDate = Today.AddDays(- 1)
                Session("revDate") = Format(Today.AddDays(- 1), "yyyy/MM/dd")

                dtpEnddate.SelectedDate = Today.AddDays(- 1)
                Session("revDateEnd") = Format(Today.AddDays(- 1), "yyyy/MM/dd")
            Else
                dtpStartDate.SelectedDate = Today
                Session("revDate") = Format(Today, "yyyy/MM/dd")

                dtpEnddate.SelectedDate = Today
                Session("revDateEnd") = Format(Today, "yyyy/MM/dd")
            End If

            grdBoxOffice.DataBind()
        End If
    End Sub

    'Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
    '    Dim strSQL As String

    '    Session("revDate") = txtDateStart.Text.Substring(6, 4) + "/" + txtDateStart.Text.Substring(3, 2) + "/" + txtDateStart.Text.Substring(0, 2) 'Format(clnDate.SelectedDate, "yyyy/MM/dd")
    '    Session("revDateEnd") = txtDateStop.Text.Substring(6, 4) + "/" + txtDateStop.Text.Substring(3, 2) + "/" + txtDateStop.Text.Substring(0, 2) 'Format(clnDateEnd.SelectedDate, "yyyy/MM/dd")

    '    strSQL = "  SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    '    strSQL += vbNewLine + " vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    '    strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, vRevToday1.DateStatus, vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession"
    '    strSQL += vbNewLine + " FROM vSumRevenue INNER JOIN"
    '    strSQL += vbNewLine + " (SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms, "
    '    strSQL += vbNewLine + " sum(rev_amount) as rev_amount, sum(cntSession) as cntSession, sum(cntScreen) as cntScreen"
    '    strSQL += vbNewLine + " FROM vRevToday "
    '    strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    '    strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111))"
    '    strSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    '    strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)))"
    '    strSQL += vbNewLine + " group by DateStatus, movie_id"
    '    strSQL += vbNewLine + " ) AS vRevToday1 ON "
    '    strSQL += vbNewLine + " vSumRevenue.movie_id = vRevToday1.movie_id"
    '    strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    '    strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%' or '" + txtMovies.Text + "' is null) "
    '    strSQL += vbNewLine + " AND (vSumRevenue.movie_status = " + ddlStatus.SelectedValue + " or " + ddlStatus.SelectedValue + " is null) "
    '    strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"

    '    ViewState("vSQL") = strSQL
    '    sqlBoxOffice.SelectCommand = strSQL
    '    grdBoxOffice.DataSourceID = "sqlBoxOffice"
    '    grdBoxOffice.DataBind()


    'End Sub

    ''Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
    ''    Try
    ''        If ddlStatus.SelectedIndex = 0 Then
    ''            Dim strSQL As String

    ''            If txtDateStart.Text.Trim() <> "" Then
    ''                Session("revDate") = txtDateStart.Text.Substring(6, 4) + "/" + txtDateStart.Text.Substring(3, 2) + "/" + txtDateStart.Text.Substring(0, 2)  'Format(clnDate.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDate") = "null"
    ''            End If
    ''            If txtDateStop.Text.Trim() <> "" Then
    ''                Session("revDateEnd") = txtDateStop.Text.Substring(6, 4) + "/" + txtDateStop.Text.Substring(3, 2) + "/" + txtDateStop.Text.Substring(0, 2) 'Format(clnDateEnd.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDateEnd") = "null"
    ''            End If

    ''            'strSQL = "  SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''            'strSQL += vbNewLine + " vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''            'strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, vRevToday1.DateStatus, vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession"
    ''            'strSQL += vbNewLine + " FROM vSumRevenue "
    ''            'strSQL += vbNewLine + " inner Join "
    ''            'strSQL += vbNewLine + " ( "
    ''            'strSQL += vbNewLine + " SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            'strSQL += vbNewLine + " sum(cntSession) as cntSession, sum(cntScreen) as cntScreen "
    ''            'strSQL += vbNewLine + " FROM vRevToday "
    ''            'strSQL += vbNewLine + " where (((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null))"
    ''            'strSQL += vbNewLine + " group by DateStatus, movie_id "
    ''            'strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''            'strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''            'strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%' or '" + txtMovies.Text + "' is null) "
    ''            'strSQL += vbNewLine + " AND (vSumRevenue.movie_status = " + ddlStatus.SelectedValue + " or " + ddlStatus.SelectedValue + " is null) "
    ''            'strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"


    ''            strSQL = "SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''            strSQL += vbNewLine + "  vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''            strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, "

    ''            strSQL += vbNewLine + "  (SELECT      ISNULL(MAX(dbo.tblCompRevenue.status_id), "
    ''            strSQL += vbNewLine + "  '') + ISNULL(MAX(dbo.tblRevenue.status_id), '') AS DateStatus"
    ''            strSQL += vbNewLine + "  FROM"
    ''            strSQL += vbNewLine + "  dbo.tblMovie"
    ''            strSQL += vbNewLine + "  left join dbo.tblRevenue  on dbo.tblMovie.movie_id = dbo.tblRevenue.movies_id"
    ''            strSQL += vbNewLine + "  left join dbo.tblCompRevenue on dbo.tblMovie.movie_id = dbo.tblCompRevenue.movies_id"
    ''            strSQL += vbNewLine + "  where dbo.tblMovie.movie_id = vSumRevenue.movie_id) DateStatus"

    ''            strSQL += vbNewLine + "  , vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession, vSumRevenue.movie_status"
    ''            strSQL += vbNewLine + "  FROM vSumRevenue "
    ''            strSQL += vbNewLine + "  Left JOIN"
    ''            strSQL += vbNewLine + "  ( "
    ''            strSQL += vbNewLine + " 		select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 		from "
    ''            strSQL += vbNewLine + " 		("
    ''            strSQL += vbNewLine + " 			 SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 			 FROM vRevToday "
    ''            'strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111))"
    ''            'strSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)))"

    ''            strSQL += vbNewLine + " where  1=1"
    ''            If (Session("revDate").ToString() <> "null" And Session("revDateEnd").ToString() <> "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + " and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + " and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) ))"
    ''            ElseIf (Session("revDate").ToString() <> "null" And Session("revDateEnd").ToString() = "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''            ElseIf (Session("revDate").ToString() = "null" And Session("revDateEnd").ToString() <> "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''            End If

    ''            strSQL += vbNewLine + " 			 group by DateStatus, movie_id "
    ''            strSQL += vbNewLine + " 		) as tblSum"
    ''            strSQL += vbNewLine + " 		group by  movie_id"
    ''            strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''            strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''            'strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%%' or '' is null) "
    ''            strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%'  )"
    ''            strSQL += vbNewLine + " AND (vSumRevenue.movie_status = " + ddlStatus.SelectedValue + " or " + ddlStatus.SelectedValue + " is null) "
    ''            strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"


    ''            ViewState("vSQL") = strSQL
    ''            sqlBoxOffice.SelectCommand = strSQL
    ''            grdBoxOffice.DataSourceID = "sqlBoxOffice"
    ''            grdBoxOffice.DataBind()


    ''        ElseIf ddlStatus.SelectedIndex = 1 Then
    ''            Dim strSQL As String

    ''            If txtDateStart.Text.Trim() <> "" Then
    ''                Session("revDate") = txtDateStart.Text.Substring(6, 4) + "/" + txtDateStart.Text.Substring(3, 2) + "/" + txtDateStart.Text.Substring(0, 2)  'Format(clnDate.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDate") = "null"
    ''            End If
    ''            If txtDateStop.Text.Trim() <> "" Then
    ''                Session("revDateEnd") = txtDateStop.Text.Substring(6, 4) + "/" + txtDateStop.Text.Substring(3, 2) + "/" + txtDateStop.Text.Substring(0, 2) 'Format(clnDateEnd.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDateEnd") = "null"
    ''            End If

    ''            strSQL = "SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''            strSQL += vbNewLine + "  vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''            strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, "

    ''            strSQL += vbNewLine + "  (SELECT      ISNULL(MAX(dbo.tblCompRevenue.status_id), "
    ''            strSQL += vbNewLine + "  '') + ISNULL(MAX(dbo.tblRevenue.status_id), '') AS DateStatus"
    ''            strSQL += vbNewLine + "  FROM"
    ''            strSQL += vbNewLine + "  dbo.tblMovie"
    ''            strSQL += vbNewLine + "  left join dbo.tblRevenue  on dbo.tblMovie.movie_id = dbo.tblRevenue.movies_id"
    ''            strSQL += vbNewLine + "  left join dbo.tblCompRevenue on dbo.tblMovie.movie_id = dbo.tblCompRevenue.movies_id"
    ''            strSQL += vbNewLine + "  where dbo.tblMovie.movie_id = vSumRevenue.movie_id) DateStatus"

    ''            strSQL += vbNewLine + "  , vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession, vSumRevenue.movie_status"

    ''            strSQL += vbNewLine + "  FROM vSumRevenue "
    ''            strSQL += vbNewLine + "  Left JOIN"
    ''            strSQL += vbNewLine + "  ( "
    ''            strSQL += vbNewLine + " 		select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 		from "
    ''            strSQL += vbNewLine + " 		("
    ''            strSQL += vbNewLine + " 			 SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 			 FROM vRevToday "

    ''            'strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111))"
    ''            'strSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)))"

    ''            'strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111) or '" + Session("revDate").ToString + "' is null)"
    ''            'strSQL += vbNewLine + " and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111) or '" + Session("revDateEnd").ToString + "' is null))"
    ''            'strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString + "', 111) or '" + Session("revDate").ToString + "' is null)"
    ''            'strSQL += vbNewLine + " and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString + "', 111)  or '" + Session("revDateEnd").ToString + "' is null))"

    ''            strSQL += vbNewLine + " where  1=1"
    ''            If (Session("revDate").ToString() <> "null" And Session("revDateEnd").ToString() <> "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + " and (convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + " and (convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) ))"
    ''            ElseIf (Session("revDate").ToString() <> "null" And Session("revDateEnd").ToString() = "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), '" + Session("revDate").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''            ElseIf (Session("revDate").ToString() = "null" And Session("revDateEnd").ToString() <> "null") Then
    ''                strSQL += vbNewLine + " and ((convert(varchar(19), revenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''                strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), '" + Session("revDateEnd").ToString() + "', 111) )"
    ''                strSQL += vbNewLine + "  ))"
    ''            End If

    ''            strSQL += vbNewLine + " 			 group by DateStatus, movie_id "
    ''            strSQL += vbNewLine + " 		) as tblSum"
    ''            strSQL += vbNewLine + " 		group by  movie_id"
    ''            strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''            strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''            strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%'  )"
    ''            strSQL += vbNewLine + " AND (vSumRevenue.movie_status = " + ddlStatus.SelectedValue + " or " + ddlStatus.SelectedValue + " is null) "
    ''            strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"

    ''            ViewState("vSQL") = strSQL
    ''            sqlBoxOffice.SelectCommand = strSQL
    ''            grdBoxOffice.DataSourceID = "sqlBoxOffice"
    ''            grdBoxOffice.DataBind()

    ''        Else
    ''            Dim strSQL As String
    ''            If txtDateStart.Text.Trim() <> "" Then
    ''                Session("revDate") = "'" + txtDateStart.Text.Substring(6, 4) + "/" + txtDateStart.Text.Substring(3, 2) + "/" + txtDateStart.Text.Substring(0, 2) + "'" 'Format(clnDate.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDate") = "null"
    ''            End If
    ''            If txtDateStop.Text.Trim() <> "" Then
    ''                Session("revDateEnd") = "'" + txtDateStop.Text.Substring(6, 4) + "/" + txtDateStop.Text.Substring(3, 2) + "/" + txtDateStop.Text.Substring(0, 2) + "'"  'Format(clnDateEnd.SelectedDate, "yyyy/MM/dd")
    ''            Else
    ''                Session("revDateEnd") = "null"
    ''            End If

    ''            'strSQL = "SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, "
    ''            'strSQL += vbNewLine + " vSumRevenue.movie_id, vSumRevenue.distributor_id,  vSumRevenue.SumRev, "
    ''            'strSQL += vbNewLine + " vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, "
    ''            'strSQL += vbNewLine + " vRevToday1.rev_adms,   vSumRevenue.movietype_id, vSumRevenue.TotalStatus, vRevToday1.DateStatus, "
    ''            'strSQL += vbNewLine + " vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession"
    ''            'strSQL += vbNewLine + " FROM vSumRevenue "
    ''            'strSQL += vbNewLine + " Left JOIN"
    ''            'strSQL += vbNewLine + " ( "
    ''            'strSQL += vbNewLine + " SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            'strSQL += vbNewLine + " sum(cntSession) as cntSession, sum(cntScreen) as cntScreen "
    ''            'strSQL += vbNewLine + " FROM vRevToday "
    ''            'strSQL += vbNewLine + " where (((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " or ((convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null))"
    ''            'strSQL += vbNewLine + " group by DateStatus, movie_id "
    ''            'strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''            'strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''            'strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%' or '%" + txtMovies.Text + "%' is null)  "
    ''            'strSQL += vbNewLine + " and ((convert(varchar(19), vSumRevenue.movie_strdate , 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            'strSQL += vbNewLine + " and (convert(varchar(19), vSumRevenue.movie_strdate , 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null))"
    ''            'strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"


    ''            strSQL = "SELECT vSumRevenue.movie_code, vSumRevenue.MoviesName, vSumRevenue.distributor_name, vSumRevenue.movie_id, vSumRevenue.distributor_id, "
    ''            strSQL += vbNewLine + "  vSumRevenue.SumRev, vSumRevenue.countWeek, vRevToday1.cntSession, vRevToday1.cntScreen, vRevToday1.rev_amount, vRevToday1.rev_adms, "
    ''            strSQL += vbNewLine + "  vSumRevenue.movietype_id, vSumRevenue.TotalStatus, "

    ''            strSQL += vbNewLine + "  (SELECT      ISNULL(MAX(dbo.tblCompRevenue.status_id), "
    ''            strSQL += vbNewLine + "  '') + ISNULL(MAX(dbo.tblRevenue.status_id), '') AS DateStatus"
    ''            strSQL += vbNewLine + "  FROM"
    ''            strSQL += vbNewLine + "  dbo.tblMovie"
    ''            strSQL += vbNewLine + "  left join dbo.tblRevenue  on dbo.tblMovie.movie_id = dbo.tblRevenue.movies_id"
    ''            strSQL += vbNewLine + "  left join dbo.tblCompRevenue on dbo.tblMovie.movie_id = dbo.tblCompRevenue.movies_id"
    ''            strSQL += vbNewLine + "  where dbo.tblMovie.movie_id = vSumRevenue.movie_id) DateStatus"

    ''            strSQL += vbNewLine + "  , vSumRevenue.SumAmds, vSumRevenue.SumScreen, vSumRevenue.SumSession, vSumRevenue.movie_status"
    ''            strSQL += vbNewLine + "  FROM vSumRevenue "
    ''            strSQL += vbNewLine + "  Left JOIN"
    ''            strSQL += vbNewLine + "  ( "
    ''            strSQL += vbNewLine + " 		select max(DateStatus) DateStatus,movie_id,sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 		from "
    ''            strSQL += vbNewLine + " 		("
    ''            strSQL += vbNewLine + " 			 SELECT DateStatus, movie_id, sum(rev_adms) as rev_adms,  sum(rev_amount) as rev_amount, "
    ''            strSQL += vbNewLine + " 			 max(cntSession) as cntSession, max(cntScreen) as cntScreen "
    ''            strSQL += vbNewLine + " 			 FROM vRevToday "
    ''            'strSQL += vbNewLine + " where ((convert(varchar(19), revenue_date, 111) >= convert(varchar(19), " + Session("revDate").ToString + ", 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), revenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd").ToString + ", 111))"
    ''            'strSQL += vbNewLine + " or (convert(varchar(19), comprevenue_date, 111) >= convert(varchar(19), " + Session("revDate").ToString + ", 111)"
    ''            'strSQL += vbNewLine + " and convert(varchar(19), comprevenue_date, 111) <= convert(varchar(19), " + Session("revDateEnd").ToString + ", 111)))"
    ''            strSQL += vbNewLine + " 			 group by DateStatus, movie_id "
    ''            strSQL += vbNewLine + " 		) as tblSum"
    ''            strSQL += vbNewLine + " 		group by  movie_id"
    ''            strSQL += vbNewLine + " ) AS vRevToday1 ON  vSumRevenue.movie_id = vRevToday1.movie_id "
    ''            strSQL += vbNewLine + " WHERE (vSumRevenue.appear_status_id = '1') "
    ''            strSQL += vbNewLine + " AND (vSumRevenue.MoviesName LIKE '%" + txtMovies.Text + "%'  )"
    ''            strSQL += vbNewLine + " and ((convert(varchar(19), vSumRevenue.movie_strdate , 111) >= convert(varchar(19), " + Session("revDate") + ", 111) or convert(varchar(19), " + Session("revDate") + ", 111) is null)"
    ''            strSQL += vbNewLine + " and (convert(varchar(19), vSumRevenue.movie_strdate , 111) <= convert(varchar(19), " + Session("revDateEnd") + ", 111) or convert(varchar(19), " + Session("revDateEnd") + ", 111) is null))"
    ''            strSQL += vbNewLine + " ORDER BY vSumRevenue.movie_strdate DESC, vSumRevenue.distributor_id"

    ''            ViewState("vSQL") = strSQL
    ''            sqlBoxOffice.SelectCommand = strSQL
    ''            grdBoxOffice.DataSourceID = "sqlBoxOffice"
    ''            grdBoxOffice.DataBind()
    ''        End If
    ''    Catch ex As Exception
    ''        lblError.Text = " Error : " + ex.Message
    ''        lblError.Visible = True
    ''    End Try
    ''End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        Try
            Session("revMovieName") = txtMovies.Text
            Session("revMovieStatus") = ddlStatus.SelectedValue
            Session("revDate") = String.Format("{0:yyyy/MM/dd}", dtpStartDate.SelectedDate).Replace("-", "/")
            Session("revDateEnd") = String.Format("{0:yyyy/MM/dd}", dtpEnddate.SelectedDate).Replace("-", "/")

            'If txtDateStart.Text.Trim() <> "" Then
            '    Session("revDate") = txtDateStart.Text.Substring(6, 4) + "/" + txtDateStart.Text.Substring(3, 2) + "/" + txtDateStart.Text.Substring(0, 2)  'Format(clnDate.SelectedDate, "yyyy/MM/dd")
            'Else
            '    Session("revDate") = ""
            'End If
            'If txtDateStop.Text.Trim() <> "" Then
            '    Session("revDateEnd") = txtDateStop.Text.Substring(6, 4) + "/" + txtDateStop.Text.Substring(3, 2) + "/" + txtDateStop.Text.Substring(0, 2) 'Format(clnDateEnd.SelectedDate, "yyyy/MM/dd")
            'Else
            '    Session("revDateEnd") = ""
            'End If

            sqlBoxOffice.DataBind()
        Catch ex As Exception
            lblError.Text = " Error : " + ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    ''Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
    ''    If e.Row.RowType = ListItemType.Header Then
    ''        ViewState("Sum_ADMS") = 0
    ''        ViewState("Sum_GBO") = 0
    ''    ElseIf e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
    ''        Dim dr As Data.DataRowView = e.Row.DataItem

    ''        '0 vSumRevenue.movie_code, 
    ''        '1 vSumRevenue.MoviesName, 
    ''        '2 vSumRevenue.distributor_name, 
    ''        '3 vSumRevenue.movie_id, 
    ''        '4 vSumRevenue.distributor_id,
    ''        '5 vSumRevenue.SumRev, 
    ''        '6 vSumRevenue.countWeek, 
    ''        '7 vRevToday1.cntSession, 
    ''        '8 vRevToday1.cntScreen, 
    ''        '9 vRevToday1.rev_amount, 
    ''        '10 vRevToday1.rev_adms,
    ''        '11 vSumRevenue.movietype_id, 
    ''        '12 vSumRevenue.TotalStatus, 
    ''        '13 vRevToday1.DateStatus, 
    ''        '14 vSumRevenue.SumAmds, 
    ''        '15 vSumRevenue.SumScreen, 
    ''        '16 vSumRevenue.SumSession


    ''        'Dim dc As Data.DataColum
    ''        If Mid(Session("permission"), 2, 1) = 0 Then
    ''            e.Row.Cells(1).Enabled = False
    ''            e.Row.Cells(0).Enabled = False
    ''        End If
    ''        If dr(11) = "1" Then 'vSumRevenue.movietype_id = 1 คือ CTBV
    ''            'e.Row.BackColor = Color.Lavender
    ''            e.Row.Font.Bold = True
    ''        Else
    ''            'e.Row.BackColor = Color.WhiteSmoke
    ''            e.Row.Font.Bold = False

    ''        End If
    ''        If dr(5) = 0 Then 'vSumRevenue.SumRev
    ''            e.Row.Cells(0).Enabled = False
    ''            e.Row.Cells(1).Enabled = False
    ''        Else
    ''            e.Row.Cells(0).Enabled = True
    ''            e.Row.Cells(1).Enabled = True
    ''        End If
    ''        '' ''If IsDBNull(dr(12)) = False Then 'vSumRevenue.TotalStatus
    ''        '' ''    If dr(12) = "3" Then
    ''        '' ''        e.Row.Cells(8).ForeColor = Color.Orange
    ''        '' ''    ElseIf dr(12) = "2" Then
    ''        '' ''        e.Row.Cells(8).ForeColor = Color.Green
    ''        '' ''    Else
    ''        '' ''        e.Row.Cells(8).ForeColor = Color.Gray
    ''        '' ''    End If
    ''        '' ''End If
    ''        If IsDBNull(dr(13)) = False Then 'vRevToday1.DateStatus
    ''            If dr(13) = "3" Then
    ''                e.Row.Cells(4).ForeColor = Color.Orange
    ''                e.Row.Cells(5).ForeColor = Color.Orange
    ''                e.Row.Cells(6).ForeColor = Color.Orange
    ''                e.Row.Cells(7).ForeColor = Color.Orange
    ''                e.Row.Cells(8).ForeColor = Color.Orange
    ''            ElseIf dr(13) = "2" Then
    ''                e.Row.Cells(4).ForeColor = Color.Green
    ''                e.Row.Cells(5).ForeColor = Color.Green
    ''                e.Row.Cells(6).ForeColor = Color.Green
    ''                e.Row.Cells(7).ForeColor = Color.Green
    ''                e.Row.Cells(8).ForeColor = Color.Green
    ''            Else
    ''                e.Row.Cells(4).ForeColor = Color.Gray
    ''                e.Row.Cells(5).ForeColor = Color.Gray
    ''                e.Row.Cells(6).ForeColor = Color.Gray
    ''                e.Row.Cells(7).ForeColor = Color.Gray
    ''                e.Row.Cells(8).ForeColor = Color.Gray
    ''            End If

    ''        End If
    ''        'If dr(11) = "[-]เบื้องต้น" Then
    ''        '    ' e.Row.BackColor = Color.LightGoldenrodYellow
    ''        '    'e.Row.Font.Bold = False
    ''        '    e.Row.ForeColor = Color.Orange
    ''        'ElseIf dr(11) = "[฿]ยอดจริง" Then
    ''        '    ' e.Row.BackColor = Color.DarkSeaGreen
    ''        '    'e.Row.Font.Bold = True
    ''        '    e.Row.ForeColor = Color.Green
    ''        'Else
    ''        '    ' e.Row.BackColor = Color.LightSteelBlue
    ''        '    'e.Row.Font.Bold = True
    ''        '    e.Row.ForeColor = Color.DarkGray
    ''        'End If

    ''        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "rev_amount")) Then
    ''            ViewState("Sum_GBO") += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rev_amount"))
    ''        End If

    ''        If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "rev_adms")) Then
    ''            ViewState("Sum_ADMS") += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rev_adms"))
    ''        End If
    ''    End If

    ''End Sub

    Private Sub grdBoxOffice_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles grdBoxOffice.RowDataBound
        If e.Row.RowType = ListItemType.Header Then
            ViewState("Sum_ADMS") = 0
            ViewState("Sum_GBO") = 0
        ElseIf e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
            Dim dr As DataRowView = e.Row.DataItem

            '0 vSumRevenue.movie_code, 
            '1 vSumRevenue.MoviesName, 
            '2 vSumRevenue.distributor_name, 
            '3 vSumRevenue.movie_id, 
            '4 vSumRevenue.distributor_id,
            '5 vSumRevenue.SumRev, 
            '6 vSumRevenue.countWeek, 
            '7 vRevToday1.cntSession, 
            '8 vRevToday1.cntScreen, 
            '9 vRevToday1.rev_amount, 
            '10 vRevToday1.rev_adms,
            '11 vSumRevenue.movietype_id, 
            '12 vSumRevenue.TotalStatus, 
            '13 vRevToday1.DateStatus, 
            '14 vSumRevenue.SumAmds, 
            '15 vSumRevenue.SumScreen, 
            '16 vSumRevenue.SumSession

            'Dim dc As Data.DataColum
            If Mid(Session("permission"), 2, 1) = 0 Then
                e.Row.Cells(1).Enabled = False
                e.Row.Cells(0).Enabled = False
            End If

            If dr("movietype_id") = "1" Then 'vSumRevenue.movietype_id = 1 คือ CTBV
                'e.Row.BackColor = Color.Lavender
                e.Row.Font.Bold = True
            Else
                'e.Row.BackColor = Color.WhiteSmoke
                e.Row.Font.Bold = False

            End If

            If dr("SumRev") = 0 Then 'vSumRevenue.SumRev
                e.Row.Cells(0).Enabled = False
                e.Row.Cells(1).Enabled = False
            Else
                e.Row.Cells(0).Enabled = True
                e.Row.Cells(1).Enabled = True
            End If

            ''If IsDBNull(dr(12)) = False Then 'vSumRevenue.TotalStatus
            ''    If dr(12) = "3" Then
            ''        e.Row.Cells(8).ForeColor = Color.Orange
            ''    ElseIf dr(12) = "2" Then
            ''        e.Row.Cells(8).ForeColor = Color.Green
            ''    Else
            ''        e.Row.Cells(8).ForeColor = Color.Gray
            ''    End If
            ''End If

            If IsDBNull(dr("TotalStatus")) = False Then 'vRevToday1.TotalStatus
                If dr("TotalStatus") = "3" Then
                    e.Row.Cells(4).ForeColor = Color.Orange
                    e.Row.Cells(5).ForeColor = Color.Orange
                    e.Row.Cells(6).ForeColor = Color.Orange
                    e.Row.Cells(7).ForeColor = Color.Orange
                    e.Row.Cells(8).ForeColor = Color.Orange
                ElseIf dr("TotalStatus") = "2" Then
                    e.Row.Cells(4).ForeColor = Color.Green
                    e.Row.Cells(5).ForeColor = Color.Green
                    e.Row.Cells(6).ForeColor = Color.Green
                    e.Row.Cells(7).ForeColor = Color.Green
                    e.Row.Cells(8).ForeColor = Color.Green
                Else
                    e.Row.Cells(4).ForeColor = Color.Gray
                    e.Row.Cells(5).ForeColor = Color.Gray
                    e.Row.Cells(6).ForeColor = Color.Gray
                    e.Row.Cells(7).ForeColor = Color.Gray
                    e.Row.Cells(8).ForeColor = Color.Gray
                End If

            End If

            ''If dr(11) = "[-]เบื้องต้น" Then
            ''    ' e.Row.BackColor = Color.LightGoldenrodYellow
            ''    'e.Row.Font.Bold = False
            ''    e.Row.ForeColor = Color.Orange
            ''ElseIf dr(11) = "[฿]ยอดจริง" Then
            ''    ' e.Row.BackColor = Color.DarkSeaGreen
            ''    'e.Row.Font.Bold = True
            ''    e.Row.ForeColor = Color.Green
            ''Else
            ''    ' e.Row.BackColor = Color.LightSteelBlue
            ''    'e.Row.Font.Bold = True
            ''    e.Row.ForeColor = Color.DarkGray
            ''End If

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "rev_amount")) Then
                ViewState("Sum_GBO") += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rev_amount"))
            End If

            If Not IsDBNull(DataBinder.Eval(e.Row.DataItem, "rev_adms")) Then
                ViewState("Sum_ADMS") += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "rev_adms"))
            End If
        End If
    End Sub

    Private Sub grdBoxOffice_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.DataBound
        If grdBoxOffice.Rows.Count > 0 Then
            grdBoxOffice.FooterRow.Cells(3).Text = "Total :"
            If grdBoxOffice.Rows.Count > 0 Then
                grdBoxOffice.FooterRow.Cells(4).Text = Convert.ToDecimal(ViewState("Sum_GBO")).ToString("#,##0")
                grdBoxOffice.FooterRow.Cells(5).Text = Convert.ToDecimal(ViewState("Sum_ADMS")).ToString("#,##0")
            Else
                grdBoxOffice.FooterRow.Cells(4).Text = "0.00"
                grdBoxOffice.FooterRow.Cells(5).Text = "0.00"
            End If
        End If
    End Sub

    Protected Sub grdBoxOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.SelectedIndexChanged
        ''sqlBoxOffice.SelectCommand = ViewState("vSQL")
        ''grdBoxOffice.DataSourceID = "sqlBoxOffice"
        ''grdBoxOffice.DataBind()
        sqlBoxOffice.DataBind()
    End Sub

    ''Protected Sub btnCalendar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendar.Click
    ''    'popUpcalendar1.displayCalendar("Select a Start Date", Now, "lblDate", 200, 200)
    ''    clnDate.Visible = True
    ''    'displayCalendar("Select start Calendar", Now, "txtDate", 200, 200)
    ''End Sub

    ''Protected Sub clnDate_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDate.SelectionChanged
    ''    txtDateStart.Text = Format(clnDate.SelectedDate, "ddd dd-MMM-yyyy")
    ''    'Session("revDate") = Format(clnDate.SelectedDate, "yyyyMMdd")
    ''    clnDate.Visible = False
    ''End Sub

    ''Protected Sub btnCalendarEnd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCalendarEnd.Click
    ''    clnDateEnd.Visible = True
    ''End Sub

    ''Protected Sub clnDateEnd_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles clnDateEnd.SelectionChanged
    ''    txtDateStop.Text = Format(clnDateEnd.SelectedDate, "ddd dd-MMM-yyyy")
    ''    'Session("revDateEnd") = Format(clnDateEnd.SelectedDate, "yyyyMMdd")
    ''    clnDateEnd.Visible = False
    ''End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        If grdBoxOffice.Rows.Count.ToString + 1 < 65536 Then
            grdBoxOffice.AllowPaging = False
            grdBoxOffice.AllowSorting = False
            'grdBoxOffice.Width = 800
            'grdBoxOffice.DataBind()
            Dim tw As New StringWriter()
            Dim hw As New HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            Dim tbl As New Table()
            Dim tr1 As New TableRow()

            tr1.Cells.Add(New TableCell)
            tr1.Cells(0).HorizontalAlign = HorizontalAlign.Center
            tr1.Cells(0).ForeColor = Color.Black
            tr1.Cells(0).Font.Name = "Tahoma"
            tr1.Cells(0).Font.Size = 10
            tr1.Cells(0).Font.Bold = True
            tr1.Cells(0).ColumnSpan = 9
            tr1.Cells(0).Text = "กขค"
            tr1.Cells(0).Text = "BOX OFFICE"
            tbl.Rows.Add(tr1)
            frm.Attributes("runat") = "server"
            frm.Controls.Add(tbl)
            grdBoxOffice.Font.Size = 9
            ''sqlBoxOffice.SelectCommand = ViewState("vSQL")
            ''grdBoxOffice.DataSourceID = "sqlBoxOffice"
            grdBoxOffice.DataBind()
            frm.Controls.Add(grdBoxOffice)
            Response.Charset = "windows-874"
            Response.AddHeader("content-disposition", "attachment;filename=BoxOffice.xls")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)

            Response.ContentType = "application/vnd.xls"

            EnableViewState = False
            Controls.Add(frm)

            frm.RenderControl(hw)
            'Response.Write(tw.ToString())
            Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
            Response.End()
            grdBoxOffice.AllowPaging = True
            grdBoxOffice.AllowSorting = True
            grdBoxOffice.DataBind()
        End If
    End Sub

    Protected Sub grdBoxOffice_Sorted(ByVal sender As Object, ByVal e As EventArgs) Handles grdBoxOffice.Sorted
        ''sqlBoxOffice.SelectCommand = ViewState("vSQL")
        ''grdBoxOffice.DataSourceID = "sqlBoxOffice"
        ''grdBoxOffice.DataBind()
        sqlBoxOffice.DataBind()
    End Sub
End Class