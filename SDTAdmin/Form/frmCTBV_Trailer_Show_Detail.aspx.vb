Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_Trailer_Show_Detail
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 7, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        Dim wkTheaterId As String = Request.QueryString("theater_id")
        Dim wkCircuitId As String = ""
        Dim dataReader1 As IDataReader = cDB.GetDataString("tblTheater.theater_name, tblCircuit.circuit_name, tblCircuit.circuit_ID", "tblTheater LEFT OUTER JOIN tblCircuit ON tblTheater.circuit_id = tblCircuit.circuit_id", " tblTheater.theater_id = " + wkTheaterId)
        If dataReader1.Read Then
            wkCircuitId = dataReader1("circuit_ID").ToString
            lblTheater.Text = "Theatre : <b>" + dataReader1("theater_name").ToString + "</b>"
            lblTheater.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Circuit : <b>" + dataReader1("circuit_name").ToString + "</b>"

            Dim wkSQL As String
            wkSQL = "SELECT tblTrailer_Master.trailer_no, "
            wkSQL += " tblTrailer_Master.circuit_id, tblTrailer_Master.theater_id, tblTrailer_Master.TheaterSub_id, "
            wkSQL += " tblTrailer_Master.real_movie_id, tblTrailer_Master.collection_no, tblTrailer_Master.confirm_flag, "
            wkSQL += " tblTrailer_Master.active_flag, tblTrailer_Master.create_dtm, tblTrailer_Master.create_by, "
            wkSQL += " tblTrailer_Master.last_update_dtm, tblTrailer_Master.last_update_by,tblMovie.movietype_id, "
            wkSQL += " dbo.funGetConcatMovieByColNo(tblTrailer_Master.collection_no,0,7) AS Movie_Collection, "
            wkSQL += " tblMovie.movie_nameen + ' / ' + tblMovie.movie_nameth AS real_movie_name "
            wkSQL += " FROM [tblTrailer_Master]"
            wkSQL += " LEFT OUTER JOIN tblMovie "
            wkSQL += " ON tblTrailer_Master.real_movie_id = tblMovie.movie_id "
            wkSQL += " WHERE tblTrailer_Master.confirm_flag = 'Y'"
            wkSQL += " AND tblTrailer_Master.active_flag = 'Y'"
            wkSQL += " AND tblTrailer_Master.circuit_id = " + wkCircuitId
            wkSQL += " AND tblTrailer_Master.theater_id = " + wkTheaterId
            wkSQL += " order by tblTrailer_Master.TheaterSub_id, tblTrailer_Master.real_movie_id "
            sqlTailer.SelectCommand = wkSQL
            GridView1.DataSourceID = "sqlTailer"
            GridView1.DataBind()
            dataReader1.Close()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then
            Dim dr As Data.DataRowView = e.Row.DataItem

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

            If Convert.ToString(dr("movietype_id")).Trim() = "1" Then 'vSumRevenue.movietype_id = 1 คือ CTBV
                'e.Row.BackColor = Color.Lavender
                e.Row.Cells(2).Font.Bold = True
                e.Row.Cells(2).ForeColor = Color.FromName("#3A8000")
                '''e.Row.Cells(2).ForeColor = Color.FromName("#284775")
            Else
                'e.Row.BackColor = Color.WhiteSmoke
                e.Row.Cells(2).Font.Bold = True
                e.Row.Cells(2).ForeColor = Color.FromName("#003399")
                '''e.Row.Cells(2).ForeColor = Color.FromName("#333333")
            End If

            'If IsDBNull(dr("movietype_id")) = False Then 'vRevToday1.DateStatus
            '    If dr("movietype_id") = "3" Then
            '        e.Row.Cells(2).ForeColor = Color.Orange
            '    ElseIf dr("movietype_id") = "2" Then
            '        e.Row.Cells(4).ForeColor = Color.Green
            '    Else
            '        e.Row.Cells(4).ForeColor = Color.Gray
            '        e.Row.Cells(5).ForeColor = Color.Gray
            '        e.Row.Cells(6).ForeColor = Color.Gray
            '        e.Row.Cells(7).ForeColor = Color.Gray
            '        e.Row.Cells(8).ForeColor = Color.Gray
            '    End If

            'End If


            'If dr(11) = "[-]เบื้องต้น" Then
            '    ' e.Row.BackColor = Color.LightGoldenrodYellow
            '    'e.Row.Font.Bold = False
            '    e.Row.ForeColor = Color.Orange
            'ElseIf dr(11) = "[฿]ยอดจริง" Then
            '    ' e.Row.BackColor = Color.DarkSeaGreen
            '    'e.Row.Font.Bold = True
            '    e.Row.ForeColor = Color.Green
            'Else
            '    ' e.Row.BackColor = Color.LightSteelBlue
            '    'e.Row.Font.Bold = True
            '    e.Row.ForeColor = Color.DarkGray
            'End If

        End If
    End Sub
End Class