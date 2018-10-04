Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Security

Partial Public Class frmCTBV_Unterminate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub btnTerminater_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTerminater.Click
        'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
        Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
        Dim sqlcon As New SqlConnection(strconn)
        sqlcon.Open()
        Dim sql, sql2, sql3, sql4, sql5 As String
        sql = "update tblcompRevenue set status_id =1 where movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql3 = "update tblRevenue set status_id =1 where movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql2 = "update tblRelease set onrelease_status =2 , onrelease_enddate =convert(datetime,'" & Today.ToString("yyyyMMdd") & "',101) where movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql5 = "Select * from tblRelease where onrelease_status=1 and movies_id=" & Session("MovieId")
        Dim com As New SqlCommand(sql, sqlcon)
        Dim com2 As New SqlCommand(sql2, sqlcon)
        Dim com3 As New SqlCommand(sql3, sqlcon)
        Dim da As New SqlDataAdapter(sql5, sqlcon)
        Dim ds As New DataSet
        da.Fill(ds, "dataFi")

        Dim cmd As New SqlCommand   'added 2/10/2015
        cmd.Connection = sqlcon
        cmd.CommandText = "sp_RevenueComp_Terminate_ByTheater"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@movie_id", Session("MovieId"))
        cmd.Parameters.AddWithValue("@theater_id", Request.QueryString("theaterId"))
        cmd.ExecuteNonQuery()

        com2.ExecuteNonQuery()
        com.ExecuteNonQuery()
        com3.ExecuteNonQuery()
        If ds.Tables("dataFi").Rows.Count = 1 Then
            sql4 = "update tblMovie set movie_status =2 where movie_id=" & Session("MovieId")
            Dim com4 As New SqlCommand(sql4, sqlcon)
            com4.ExecuteNonQuery()
        End If
        sqlcon.Close()
        Response.Redirect("frmCTBV_MMD_Movie_Add.aspx?titleId=" & Session("MovieId"))
    End Sub

    Protected Sub btnShowing_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnShowing.Click
        'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
        Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
        Dim sqlcon As New SqlConnection(strconn)
        sqlcon.Open()
        Dim sql, sql2, sql3, sql4 As String
        sql = "update tblcompRevenue set status_id =2 where status_id =1 and movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql3 = "update tblRevenue set status_id =2  where status_id =1 and movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql2 = "update tblRelease set onrelease_status =1, onrelease_enddate = null where movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        'sql3 = "Select * from tblRelease where onrelease_status=1 and movies_id=" & Session("MoviesId")
        Dim com As New SqlCommand(sql, sqlcon)
        Dim com2 As New SqlCommand(sql2, sqlcon)
        Dim com3 As New SqlCommand(sql3, sqlcon)
        'Dim da As New SqlDataAdapter(sql3, sqlcon)
        'Dim ds As New DataSet
        'da.Fill(ds, "dataFi")

        Dim cmd As New SqlCommand   'added 2/10/2015
        cmd.Connection = sqlcon
        cmd.CommandText = "sp_RevenueComp_Showing_ByTheater"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@movie_id", Session("MovieId"))
        cmd.Parameters.AddWithValue("@theater_id", Request.QueryString("theaterId"))
        cmd.ExecuteNonQuery()

        com2.ExecuteNonQuery()
        com.ExecuteNonQuery()
        com3.ExecuteNonQuery()
        'If ds.Tables("dataFi").Rows.Count = 1 Then
        sql4 = "update tblMovie set movie_status =1 where movie_id=" & Session("MovieId")
        Dim com4 As New SqlCommand(sql4, sqlcon)
        com4.ExecuteNonQuery()
        'End If
        sqlcon.Close()
        Response.Redirect("frmCTBV_MMD_Movie_Add.aspx?titleId=" & Session("MovieId"))
    End Sub

    Protected Sub btnRelease_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRelease.Click
        'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
        Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
        Dim sqlcon As New SqlConnection(strconn)
        sqlcon.Open()
        Dim sql2 As String
        'sql = "update tblcompRevenue set status_id =1 where status_id =1 and movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        'sql3 = "update tblRevenue set status_id =1 where status_id =1 and movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        sql2 = "update tblRelease set onrelease_status =3, onrelease_enddate = null where movies_id=" & Session("MovieId") & "and theater_id=" & Request.QueryString("theaterId")
        'sql3 = "Select * from tblRelease where onrelease_status=1 and movies_id=" & Session("MoviesId")
        'Dim com As New SqlCommand(sql, sqlcon)
        Dim com2 As New SqlCommand(sql2, sqlcon)
        'Dim com3 As New SqlCommand(sql3, sqlcon)
        'Dim da As New SqlDataAdapter(sql3, sqlcon)
        'Dim ds As New DataSet
        'da.Fill(ds, "dataFi")
        com2.ExecuteNonQuery()
        'com.ExecuteNonQuery()
        'com3.ExecuteNonQuery()
        'If ds.Tables("dataFi").Rows.Count = 1 Then
        'sql4 = "update tblMovie set movie_status =3 where movie_id=" & Session("MovieId")
        'Dim com4 As New SqlCommand(sql4, sqlcon)
        'com4.ExecuteNonQuery()
        sqlcon.Close()
        Response.Redirect("frmCTBV_MMD_Movie_Add.aspx?titleId=" & Session("MovieId"))
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Response.Redirect("frmCTBV_MMD_Movie_Add.aspx?titleId=" & Session("MovieId"))
    End Sub
End Class