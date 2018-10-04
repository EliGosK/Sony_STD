Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Web.Data
    Public Class cDatabase
        'Public DBCnn As SqlClient.SqlConnection
        'Public DBDap As SqlClient.SqlDataAdapter
        'Private _ConnectionString As String

        Private ReadOnly Property CnnString() As String
            Get
                'Dim Conn As String = ConfigurationSettings.AppSettings("CnnString")
                Dim Conn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
                If Conn.Length <= 0 Then
                    Throw New ApplicationException("Find Not Found Connection")
                Else
                    Return Conn
                End If
            End Get
        End Property

        'Public Function CnnString() As String
        '   Return ConfigurationSettings.AppSettings("CnnString")
        'End Function
        Public Function ReportCnnString() As String
            Return ConfigurationSettings.AppSettings("ReportCnnString")
        End Function


        Public Shared Function GetDataTable(ByVal strcommand As String) As DataTable
            'Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("CnnString"))
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim conn As New SqlConnection(strconn)
            Dim cmd As New SqlCommand(strcommand, conn)
            cmd.CommandTimeout = 600
            Dim adp As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            adp.Fill(ds)
            Return ds.Tables(0)
        End Function

        Public Shared Function GetDataSet(ByVal strcommand As String) As DataSet
            'Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("CnnString"))
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim conn As New SqlConnection(strconn)
            Dim cmd As New SqlCommand(strcommand, conn)
            cmd.CommandTimeout = 600
            Dim adp As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            adp.Fill(ds)
            Return ds
        End Function

        Public Sub LoadDataToDropdownList(ByVal ctrlDropDown As DropDownList, ByVal tableName As String, ByVal fieldDisplay As String, ByVal fieldValue As String, ByVal criteria As String)
            Dim conn As SqlConnection = Nothing
            'Dim setting As New SqlConnection(ConfigurationSettings.AppSettings("CnnString"))
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim setting As New SqlConnection(strconn)
            'Dim setting As ConnectionStringSettings
            'setting = ConfigurationManager.ConnectionStrings("CnnString")
            Dim ds As New DataSet()
            Dim strSQL As String
            Try
                If setting Is Nothing Then
                    Exit Sub
                End If

                strSQL = "SELECT distinct " & fieldValue & " AS fieldValue, "
                strSQL += fieldDisplay & " AS fieldDisplay "
                strSQL += " FROM " & tableName
                If criteria <> "" Then
                    strSQL += " WHERE " & criteria
                End If
                strSQL += " ORDER BY " & fieldDisplay

                'conn = New SqlConnection(setting.ConnectionString)
                conn = New SqlConnection(strconn)
                conn.Open()
                ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, strSQL.ToString())
                If ds Is Nothing Then
                    Exit Sub
                End If

                ctrlDropDown.Items.Clear()

                ctrlDropDown.DataValueField = "fieldValue"
                ctrlDropDown.DataTextField = "fieldDisplay"
                ctrlDropDown.DataSource = ds
                ctrlDropDown.DataBind()
                ctrlDropDown.Items.Insert(0, "---ALL---")
                ctrlDropDown.Items(0).Value = "Null"
            Catch
            Finally
                ds.Dispose()
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Dispose()
            End Try
        End Sub

        Public Sub upDateTheater _
( _
    ByVal theater_Id As Integer, _
    ByVal theater_code As String, _
    ByVal theater_name As String, _
    ByVal theater_des As String, _
    ByVal theater_status As String, _
    ByVal user_id As String, _
    ByVal circuit_id As String, _
    ByVal remark As String, _
    ByVal open_date As DateTime, _
    ByVal close_date As DateTime, _
    ByVal imax_flag As String _
)
            If (open_date = New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
                    (CnnString, "spTblTheaterUpdate", theater_Id, theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, DBNull.Value, DBNull.Value, imax_flag)
            ElseIf (open_date <> New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
                    (CnnString, "spTblTheaterUpdate", theater_Id, theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, open_date, DBNull.Value, imax_flag)

            ElseIf (open_date = New DateTime) And (close_date <> New DateTime) Then
                SqlHelper.ExecuteNonQuery _
                    (CnnString, "spTblTheaterUpdate", theater_Id, theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, DBNull.Value, close_date, imax_flag)
            Else
                SqlHelper.ExecuteNonQuery _
                    (CnnString, "spTblTheaterUpdate", theater_Id, theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, open_date, close_date, imax_flag)
            End If
        End Sub

        Public Sub AddTheater _
        ( _
            ByVal theater_code As String, _
            ByVal theater_name As String, _
            ByVal theater_des As String, _
            ByVal theater_status As String, _
            ByVal user_id As String, _
            ByVal circuit_id As String, _
            ByVal remark As String, _
            ByVal open_date As DateTime, _
            ByVal close_date As DateTime, _
            ByVal imax_flag As String _
        )

            If (open_date = New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblTheaterInsert", theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, DBNull.Value, DBNull.Value, imax_flag)
            ElseIf (open_date <> New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblTheaterInsert", theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, open_date, DBNull.Value, imax_flag)
            ElseIf (open_date = New DateTime) And (close_date <> New DateTime) Then
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblTheaterInsert", theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, DBNull.Value, close_date, imax_flag)
            Else
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblTheaterInsert", theater_code, theater_name, theater_des, theater_status, Now, user_id, circuit_id, remark, open_date, close_date, imax_flag)
            End If

        End Sub

        Public Sub AddTheaterSub _
( _
    ByVal theatersub_id As Integer, _
    ByVal theatersub_code As String, _
    ByVal theatersub_name As String, _
    ByVal theatersub_normalseat As Integer, _
    ByVal theater_id As Integer, _
    ByVal mm_flag As String, _ 
    ByVal digital_flag  As String, _ 
    ByVal dimention_flag As String, _ 
    ByVal open_date  As datetime, _ 
    ByVal close_date As datetime)
            If (open_date = New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
              (CnnString, "spTblTheatersubInsert", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, DBNull.Value, DBNull.Value)
            ElseIf (open_date <> New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
              (CnnString, "spTblTheatersubInsert", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, open_date, DBNull.Value)
            ElseIf (open_date = New DateTime) And (close_date <> New DateTime) Then
                SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTheatersubInsert", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, DBNull.Value, close_date)
            Else
                SqlHelper.ExecuteNonQuery _
               (CnnString, "spTblTheatersubInsert", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, open_date, close_date)
            End If
        End Sub


        Public Sub UpdateTheaterSub _
( _
    ByVal theatersub_id As Integer, _
    ByVal theatersub_code As String, _
    ByVal theatersub_name As String, _
    ByVal theatersub_normalseat As Integer, _
    ByVal theater_id As Integer, _
    ByVal mm_flag As String, _
    ByVal digital_flag As String, _
    ByVal dimention_flag As String, _
    ByVal open_date As DateTime, _
    ByVal close_date As DateTime, _
ByVal status_flag As String)
            If (open_date = New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
              (CnnString, "spTblTheaterSubUpdate", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, DBNull.Value, DBNull.Value, status_flag)
            ElseIf (open_date <> New DateTime) And (close_date = New DateTime) Then
                SqlHelper.ExecuteNonQuery _
              (CnnString, "spTblTheaterSubUpdate", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, open_date, DBNull.Value, status_flag)
            ElseIf (open_date = New DateTime) And (close_date <> New DateTime) Then
                SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTheaterSubUpdate", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, DBNull.Value, close_date, status_flag)
            Else
                SqlHelper.ExecuteNonQuery _
               (CnnString, "spTblTheaterSubUpdate", theatersub_id, theatersub_code, theatersub_name, theatersub_normalseat, theater_id, mm_flag, digital_flag, dimention_flag, open_date, close_date, status_flag)
            End If
        End Sub

        Public Sub AddTheaterSubSeat _
( _
ByVal theater_id As Integer, _
ByVal theatersub_id As Integer, _
ByVal seat_type_id As Integer, _
ByVal seat_type_name As String, _
ByVal seat_qty As Decimal, _
ByVal weekend_price_amt As Decimal, _
ByVal weekday_price_amt As Decimal, _
ByVal create_dtm As DateTime, _
ByVal create_by As String, _
ByVal last_update_dtm As DateTime, _
ByVal last_update_by As String)

            SqlHelper.ExecuteNonQuery _
                       (CnnString, "spTblTheatersubSeatInsert", theater_id, theatersub_id, seat_type_id, seat_type_name, seat_qty, weekend_price_amt, weekday_price_amt, create_dtm, create_by, last_update_dtm, last_update_by)

        End Sub


        Public Sub updateTheaterSubSeat _
( _
ByVal theater_id As Integer, _
ByVal theatersub_id As Integer, _
ByVal seat_type_id As Integer, _
ByVal seat_type_name As String, _
ByVal seat_qty As Decimal, _
ByVal weekend_price_amt As Decimal, _
ByVal weekday_price_amt As Decimal, _
ByVal last_update_dtm As DateTime, _
ByVal last_update_by As String)

            SqlHelper.ExecuteNonQuery _
                       (CnnString, "spTblTheatersubSeatUpdate", theater_id, theatersub_id, seat_type_id, seat_type_name, seat_qty, weekend_price_amt, weekday_price_amt, last_update_dtm, last_update_by)

        End Sub

        Public Sub addCompRevenue _
( _
        ByVal comprevenue_amountsum As Integer, _
        ByVal comprevenue_amountth As Integer, _
        ByVal comprevenue_amountor As Integer, _
        ByVal comprevenue_admssum As Integer, _
        ByVal comprevenue_admsth As Integer, _
        ByVal comprevenue_admsor As Integer, _
        ByVal comprevenue_timesum As Integer, _
        ByVal comprevenue_timeor As Integer, _
        ByVal comprevenue_timeth As Integer, _
        ByVal comprevenue_screensum As Integer, _
        ByVal comprevenue_screenth As Integer, _
        ByVal comprevenue_screenor As Integer, _
        ByVal comprevenue_date As String, _
        ByVal theater_id As Integer, _
        ByVal movies_id As Integer, _
        ByVal status_id As Integer, _
        ByVal user_id As String, _
        ByVal lastupdate As DateTime _
)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblCompRevenueInsert", comprevenue_amountsum, comprevenue_amountth, _
            comprevenue_amountor, comprevenue_admssum, comprevenue_admsth, comprevenue_admsor, _
            comprevenue_timesum, comprevenue_timeor, comprevenue_timeth, _
            comprevenue_screensum, comprevenue_screenth, comprevenue_screenor, _
            comprevenue_date, theater_id, movies_id, status_id, user_id, lastupdate)
        End Sub

        Public Sub updateCompRevenue _
( _
    ByVal comprevenue_amountsum As Integer, _
    ByVal comprevenue_amountth As Integer, _
    ByVal comprevenue_amounttd As Integer, _
    ByVal comprevenue_amountor As Integer, _
    ByVal comprevenue_admssum As Integer, _
    ByVal comprevenue_admsth As Integer, _
    ByVal comprevenue_admstd As Integer, _
    ByVal comprevenue_admsor As Integer, _
    ByVal comprevenue_timesum As Integer, _
    ByVal comprevenue_timeor As Integer, _
    ByVal comprevenue_timeth As Integer, _
    ByVal comprevenue_timetd As Integer, _
    ByVal comprevenue_screensum As Integer, _
    ByVal comprevenue_screenth As Integer, _
    ByVal comprevenue_screentd As Integer, _
    ByVal comprevenue_screenor As Integer, _
    ByVal comprevenue_date As String, _
    ByVal theater_id As Integer, _
    ByVal movies_id As Integer, _
    ByVal status_id As Integer, _
    ByVal user_id As String, _
    ByVal lastUpdate As DateTime _
)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblCompRevenueUpdate", comprevenue_amountsum, comprevenue_amountth, comprevenue_amounttd, _
            comprevenue_amountor, comprevenue_admssum, comprevenue_admsth, comprevenue_admstd, comprevenue_admsor, _
            comprevenue_timesum, comprevenue_timeor, comprevenue_timeth, comprevenue_timetd, _
            comprevenue_screensum, comprevenue_screenth, comprevenue_screentd, comprevenue_screenor, _
            comprevenue_date, theater_id, movies_id, status_id, user_id, lastUpdate)
        End Sub

        '    Public Sub addUser _
        '( _
        '        ByVal user_id As String, _
        '        ByVal user_name As String, _
        '        ByVal user_password As String, _
        '        ByVal user_email As String, _
        '        ByVal user_tel As String, _
        '        ByVal usergroup_id As String, _
        '        ByVal user_status As String, _
        '        ByVal user_Permission As String, _
        '        ByVal present_checker_level_id As Integer, _
        '        ByVal former_checker_level_id As Integer _
        ' )
        '        SqlHelper.ExecuteNonQuery _
        '        (CnnString, "sptblUserInsert", user_id, user_name, user_password, user_email, user_tel, usergroup_id, user_status, user_Permission, present_checker_level_id, former_checker_level_id)
        '    End Sub
        Public Sub addUser _
    ( _
            ByVal user_id As String, _
            ByVal user_name As String, _
            ByVal user_password As String, _
            ByVal user_email As String, _
            ByVal user_tel As String, _
            ByVal usergroup_id As String, _
            ByVal user_status As String, _
            ByVal user_Permission As String, _
            ByVal present_checker_level_id As Integer, _
            ByVal former_checker_level_id As Integer, _
            ByVal pw_createdate As String, _
            ByVal password_age As Integer, _
            ByVal cvDate As DateTime _
     )
            SqlHelper.ExecuteNonQuery(CnnString, "sptblUserInsert", user_id, user_name, user_password, user_email, user_tel, usergroup_id, user_status, user_Permission, present_checker_level_id, former_checker_level_id, pw_createdate, password_age, cvDate)
        End Sub
        '------------------ Editted on 09/07/2015 by Phasupong (insert PWDUniqueHistory)---------------
        Public Sub addPWDUniqueHistory _
    ( _
            ByVal user_id As String, _
            ByVal user_password As String, _
            ByVal create_by As String _
     )
            SqlHelper.ExecuteNonQuery(CnnString, "sp_insertPWDUniqueHistory", user_id, user_password, create_by)
        End Sub

        Public Function getUserDetail(ByVal userId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblUserRead", userId), IDataReader)
        End Function

        Public Sub updateRevenue _
            ( _
            ByVal revenue_adms As Integer, _
            ByVal revenue_amount As Integer, _
            ByVal revenue_date As String, _
            ByVal revenue_Time As String, _
            ByVal timehour_id As Integer, _
            ByVal timemin_id As Integer, _
            ByVal revenue_type As String, _
            ByVal theatersub_id As Integer, _
            ByVal movie_system As String, _
            ByVal user_Id As String, _
            ByVal movies_id As Integer, _
            ByVal status_id As Integer, _
            ByVal theater_id As Integer, _
            ByVal sound_type As String, _
            ByVal revenueid As Integer _
            )
            Dim strUserId As String = "NOTUSER"
            SqlHelper.ExecuteNonQuery _
            (CnnString, "sptblRevenueUpdate", revenue_adms, revenue_amount, revenue_date, revenue_Time, timehour_id, timemin_id, revenue_type, _
            theatersub_id, movie_system, strUserId, movies_id, status_id, theater_id, sound_type, revenueid, Now)
        End Sub

        Public Sub addMovies _
            ( _
            ByVal movie_id As Integer, _
            ByVal movie_code As String, _
            ByVal movie_nameth As String, _
            ByVal movie_nameen As String, _
            ByVal movie_strdate As String, _
            ByVal movie_lastupdate As String, _
            ByVal movie_status As Integer, _
            ByVal movietype_id As String, _
            ByVal user_id As String, _
            ByVal studio_id As Integer, _
            ByVal distributor_id As Integer, _
            ByVal movie_gern As String, _
            ByVal movie_gernsub As String, _
            ByVal movie_pattern As String, _
            ByVal movie_national As String, _
            ByVal movie_director As String, _
            ByVal movie_cast1 As String, _
            ByVal movie_cast2 As String, _
            ByVal appear_status_id As Integer, _
            ByVal revenue_estimete As Decimal, _
            ByVal flat_sale_rental As Decimal, _
            ByVal remark As String, _
            ByVal ad_pub_amt As Decimal, _
            ByVal print_cost_amt As Decimal, _
            ByVal print_qty As String, _
            ByVal Show_in_report_flag As String)

            SqlHelper.ExecuteNonQuery _
            (CnnString, "sptblMovieInsert", movie_id, movie_code, movie_nameth, movie_nameen, movie_strdate, movie_lastupdate, movie_status, movietype_id, _
            user_id, studio_id, distributor_id, movie_gern, movie_gernsub, movie_pattern, movie_national, movie_director, movie_cast1, movie_cast2, appear_status_id, revenue_estimete, flat_sale_rental, remark, ad_pub_amt, print_cost_amt, print_qty, Show_in_report_flag)
        End Sub

        Public Function getBoxOfficeSharingByCir(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String, ByVal city As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptMarketShareByCir", movieId, strDate, endDate, city), IDataReader)
        End Function

        Public Function getBoxOfficeSharing(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String, ByVal city As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptMarketShare", movieId, strDate, endDate, city), IDataReader)
        End Function

        Public Function getBoxOfficeDataComp(ByVal movieId As Integer, ByVal strDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRevenueForCusComp", movieId, strDate), IDataReader)
        End Function

        Public Function getBoxOfficeForExport(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetBoxOffForExport", movieId, strDate, endDate), IDataReader)
        End Function

        '--- Added by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound
        Public Function getBoxOfficeForCustomer(ByVal movieId As Integer, ByVal revDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetBoxOffForCustomer", movieId, revDate), IDataReader)
        End Function

        Public Function getBoxOfficeByWeek(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetBoxOffByWeek", movieId, strDate, endDate), IDataReader)
        End Function

        Public Function getBoxOfficeData(ByVal movieId As Integer, ByVal strDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRevenueForCus", movieId, strDate), IDataReader)
        End Function

        Public Function getMovieDetail(ByVal movieId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblMovieRead", movieId), IDataReader)
        End Function

        Public Function getTheaterDetail(ByVal theaterId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblTheaterRead", theaterId), IDataReader)
        End Function

        Public Function getTheaterSubDetail(ByVal theaterId As Integer, ByVal theaterSubId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTbltheaterSubRead", theaterId, theaterSubId), IDataReader)
        End Function

        Public Function getTheaterSubSeatDetail(ByVal theaterId As Integer, ByVal theaterSubId As Integer, ByVal theaterSubSeatId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTbltheaterSubSeatRead", theaterId, theaterSubId, theaterSubSeatId), IDataReader)
        End Function

        Public Function Autheticate(ByVal UserID As String, ByVal Password As String, ByVal userType As String) As Boolean
            Return SqlHelper.ExecuteScalar(CnnString, "spChkLogin", UserID, Password, userType) = 1
        End Function

        Public Function GetRevenuDetail(ByVal revId As Integer, ByVal theaterId As Integer, ByVal moviesId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblRevenueDetial", revId, theaterId, moviesId), IDataReader)
        End Function

        Public Function checkRevenue(ByVal theaterSubId As Integer, ByVal theaterId As Integer, ByVal revenueTime As String, ByVal revenueDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblCheckRevenue", theaterSubId, theaterId, revenueTime, revenueDate), IDataReader)
        End Function

        Public Function GetRevenuDataset(ByVal revId As Integer, ByVal theaterId As Integer, ByVal moviesId As Integer) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "spTblRevenueDetial", revId, theaterId, moviesId), DataSet)
        End Function

        Public Function GetCompRevenuDetail(ByVal moviesId As Integer, ByVal theaterId As Integer, ByVal revDate As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblCompRevenueDetial", moviesId, theaterId, revDate), IDataReader)
        End Function

        Public Function checkRevenue(ByVal sysDate As String, ByVal theaterId As Integer, ByVal moviesId As Integer) As Boolean
            Return SqlHelper.ExecuteScalar(CnnString, "spChkRevenue", sysDate, theaterId, moviesId) = 1
        End Function

        'Public Sub OpenConnection(ByVal aCnnString As String)
        '    DBCnn = New SqlClient.SqlConnection(aCnnString)
        '    DBCnn.Open()
        'End Sub

        'Public Sub OpenConnection()
        '    Dim cnnstr As String = ConfigurationSettings.AppSettings("CnnString")
        '    DBCnn = New SqlClient.SqlConnection(cnnstr)
        '    DBCnn.Open()
        'End Sub

        'Public Sub CloseConnection()
        '    DBCnn.Close()
        '    DBCnn = Nothing
        'End Sub

        Public Function readstatus(ByVal revenueid As Integer) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "rstatus_Read", revenueid), DataSet)
        End Function

        Public Function readmainadmin() As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "tblRevenue_admin"), DataSet)
        End Function

        Public Function readmainsum(ByVal movieid As Integer, ByVal datetimesum As String, ByVal revetime As String) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "tblRevenue_sumrevenue", movieid, datetimesum, revetime), DataSet)
        End Function

        Public Function revenuedatebetween(ByVal movieid As Integer, ByVal startdatetime As String, ByVal lastrevetime As String) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "readrevenuebybetweenrevnuedate", movieid, startdatetime, lastrevetime), DataSet)
        End Function

        Public Function readtheatername(ByVal revenuedate As String) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "theaterid_Read", revenuedate), DataSet)
        End Function

        Public Function readtheatersub_id(ByVal th_subid As Integer) As DataSet
            Return CType(SqlHelper.ExecuteDataset(CnnString, "theatersub_id_Read", th_subid), DataSet)
        End Function
        'Created by Phasupong
        Public Function GetPWHint(ByVal userType As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetPasswordHint", userType), IDataReader)
        End Function
        'Created by Phasupong
        Public Function GetPWLength(ByVal userType As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetPasswordLength", userType), IDataReader)
        End Function
        'Created by Phasupong
        Public Function GetPWUniqueHist(ByVal user_id As String, ByVal password As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spChkPWDUniqueHistory", user_id, password), IDataReader)
        End Function
        'Created by Phasupong
        Public Function GetMaxUserID(ByVal paWhere As String) As IDataReader
            Dim strsql As String
            strsql = "SELECT TOP 1 (user_id) as [maxUser_id] FROM tbluser WHERE " & paWhere & " ORDER BY CAST(user_id as numeric) DESC "
            Return CType(SqlHelper.ExecuteReader(CnnString, CommandType.Text, strsql), IDataReader)
        End Function
        'Created by Phasupong
        Public Function GetMinMaxPWDAge(ByVal type As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "sp_getMinMaxPWDAge", type), IDataReader)
        End Function

        'Create by Nick 

        Public Function updateSQLNow(ByVal paSQL As String) As Boolean
            Return SqlHelper.ExecuteNonQuery(CnnString, CommandType.Text, paSQL)
        End Function

        Public Function GetDataAll(ByVal wkSQL As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, CommandType.Text, wkSQL), IDataReader)
        End Function

        Public Function GetDataString(ByVal paFeildName As String, ByVal paTableName As String, ByVal paWhere As String) As IDataReader
            Dim wkSQL As String
            wkSQL = "SELECT " & paFeildName & " FROM " & paTableName & " WHERE " & paWhere

            Return CType(SqlHelper.ExecuteReader(CnnString, CommandType.Text, wkSQL), IDataReader)
        End Function

        Public Function GetDataDecimal(ByVal paFeildName As String, ByVal paTableName As String, ByVal paWhere As String) As Decimal
            Dim wkSQL As String = "SELECT " & paFeildName & " FROM " & paTableName & " " & paWhere
            Try
                Dim decResult As Decimal = 0
                Dim connectionString As String = CnnString

                If connectionString Is Nothing Then
                    Return 0
                End If

                Dim dr As SqlDataReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, wkSQL)
                dr.Read()
                decResult = dr.GetDecimal(0)
                dr.Close()
                dr.Dispose()
                Return decResult
            Catch
                Return 0
            End Try
        End Function

        Public Sub InsertMessageQuesion(ByVal question_no As Integer, ByVal question_desc As String, ByVal User_ID As String)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(CnnString, "spTblMessageQuestionInsert", question_no, question_desc, ConvertTimeToLocaltime(saveDatetimeNow), User_ID, ConvertTimeToLocaltime(saveDatetimeNow), User_ID)
        End Sub

        Public Sub InsertMessageAnswer(ByVal question_no As Integer, ByVal theater_id As Integer, ByVal User_ID As String)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(CnnString, "spTblMessageAnswerInsert", question_no, theater_id, 0, "", "N", ConvertTimeToLocaltime(saveDatetimeNow), User_ID, ConvertTimeToLocaltime(saveDatetimeNow), 0)
        End Sub
        'end message

        'begin report
        Public Function GetRptSoundFormat(ByVal moviesId As Integer, ByVal startDate As String, ByVal endDate As String, ByVal reportType As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptSoundFormat", moviesId, startDate, endDate, reportType), IDataReader)
        End Function

        'Public Function GetRptCompSoundFormat(ByVal moviesId As Integer, ByVal startDate As String, ByVal endDate As String, ByVal reportType As String) As IDataReader
        '    Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptCompSoundFormat", moviesId, startDate, endDate, reportType), IDataReader)
        'End Function

        Public Function CountRecord(ByVal paTable As String, ByVal paFieldCount As String, ByVal paWhere As String) As Integer
            Try
                Dim RecordCount As Integer = 0
                Dim connectionString As String = CnnString
                Dim wkSQL As String = (("Select count(" & paFieldCount & ") as CountRec from ") + paTable & " ") + paWhere
                If connectionString Is Nothing Then
                    Return 0
                End If

                Dim dr As SqlDataReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, wkSQL)
                dr.Read()
                RecordCount = dr.GetValue(0)
                dr.Close()
                dr.Dispose()
                Return RecordCount
            Catch
                Return 0
            End Try
        End Function

        'marketShare Comp
        Public Function getBoxOfficeSharingByCirComp(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String, ByVal city As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptCompMarketShareByCir", movieId, strDate, endDate, city), IDataReader)
        End Function

        Public Function getBoxOfficeSharingComp(ByVal movieId As Integer, ByVal strDate As String, ByVal endDate As String, ByVal city As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptCompMarketShare", movieId, strDate, endDate, city), IDataReader)
        End Function


        Public Shared Function QueryMovie(ByVal Title As String _
                                  , ByVal Status As String _
                                  , ByVal Appear_Status As String _
                                  , ByVal Distibutor As Integer _
                                  , ByVal Studio As Integer _
                                  , ByVal MovieType As Integer _
                                  , ByVal OderBy_ASC_DESC As String _
                                  ) As String
            Dim strCommand As String = "SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName"
            strCommand += " , tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des"
            strCommand += " , tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name,"
            strCommand += "         tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle"
            strCommand += " FROM tblMovie LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id "
            strCommand += " LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id "
            strCommand += " LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID "
            strCommand += " LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId "
            strCommand += " WHERE 1=1 "
            If ((Not (Status Is Nothing))) Then
                If (Status.Trim() <> "" And Status.Trim() <> "0") Then
                    strCommand += " AND tblMovie.movie_status in (" + Status + ") "
                End If
            End If
            If ((Not (Appear_Status Is Nothing))) Then
                If (Appear_Status.Trim() <> "" And Appear_Status.Trim() <> "0") Then
                    strCommand += " AND tblMovie.appear_status_id in (" + Appear_Status + ") "
                End If
            End If

            If (Title.Trim() <> "") Then
                strCommand += " AND ((tblMovie.movie_nameen LIKE '%" + Title.Trim() + "%') "
                strCommand += " OR (tblMovie.movie_nameth LIKE '%" + Title.Trim() + "%')) "
            End If

            If (Distibutor.ToString() <> "0" And Distibutor.ToString() <> "") Then
                strCommand += " AND (tblMovie.distributor_id = " + Distibutor.ToString() + ") "
            End If
            If (Studio.ToString() <> "0" And Studio.ToString() <> "") Then
                strCommand += " AND (tblMovie.studio_id = " + Studio.ToString() + ") "
            End If
            If (MovieType.ToString() <> "0" And MovieType.ToString() <> "") Then
                strCommand += " AND (tblMovie.movietype_id = " + MovieType.ToString() + ") "
            End If

            If (OderBy_ASC_DESC.Trim() <> "") Then
                strCommand += " ORDER BY " + OderBy_ASC_DESC.Trim()
            Else
                strCommand += " ORDER BY  tblMovie.movie_id DESC"
            End If

            Return strCommand
        End Function

        Public Shared Function QueryMovie(ByVal Title As String _
                                       , ByVal Status As String _
                                       , ByVal Appear_Status As String _
                                       , ByVal Distibutor As Integer _
                                       , ByVal Studio As Integer _
                                       , ByVal MovieType As Integer _
                                       , ByVal SetupNo As String _
                                       , ByVal OderBy_ASC_DESC As String _
                                       ) As String
            Dim strCommand As String = "SELECT tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MoviesName"
            strCommand += " , tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des"
            strCommand += " , tblMovie.studio_id, tblMovie.movie_code, tblDistributor.distributor_name,"
            strCommand += "         tblStudio.studio_name, tblMovieStatus.movie_statusCode, tblMovieStatus.movie_statusTitle"
            strCommand += " FROM tblMovie LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id "
            strCommand += " LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id "
            strCommand += " LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID "
            strCommand += " LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId "
            strCommand += " WHERE 1=1 "
            If ((Not (Status Is Nothing))) Then
                If (Status.Trim() <> "" And Status.Trim() <> "0") Then
                    strCommand += " AND tblMovie.movie_status in (" + Status + ") "
                End If
            End If
            If ((Not (Appear_Status Is Nothing))) Then
                If (Appear_Status.Trim() <> "" And Appear_Status.Trim() <> "0") Then
                    strCommand += " AND tblMovie.appear_status_id in (" + Appear_Status + ") "
                End If
            End If

            If (Title.Trim() <> "") Then
                strCommand += " AND ((tblMovie.movie_nameen LIKE '%" + Title.Trim() + "%') "
                strCommand += " OR (tblMovie.movie_nameth LIKE '%" + Title.Trim() + "%')) "
            End If

            If (Distibutor.ToString() <> "0" And Distibutor.ToString() <> "") Then
                strCommand += " AND (tblMovie.distributor_id = " + Distibutor.ToString() + ") "
            End If
            If (Studio.ToString() <> "0" And Studio.ToString() <> "") Then
                strCommand += " AND (tblMovie.studio_id = " + Studio.ToString() + ") "
            End If
            If (MovieType.ToString() <> "0" And MovieType.ToString() <> "") Then
                strCommand += " AND (tblMovie.movietype_id = " + MovieType.ToString() + ") "
            End If

            If (SetupNo <> Nothing) Then
                If (SetupNo.ToString() <> "0" And SetupNo.ToString() <> "") Then
                    strCommand += " AND tblMovie.movie_id in (select movie_id from tblTrailer_Setup_Dtl where setup_no = '" + SetupNo.Trim() + "') "
                End If
            End If

            If (OderBy_ASC_DESC.Trim() <> "") Then
                strCommand += " ORDER BY " + OderBy_ASC_DESC.Trim()
            Else
                strCommand += " ORDER BY  tblMovie.movie_id DESC"
            End If

            Return strCommand
        End Function


        Public Shared Function Query_Trailer_Detail( _
                                ByVal setup_no As String _
                               , ByVal OderBy_ASC_DESC As String _
                               ) As String
            Dim strCommand As String = ""
            strCommand += " SELECT dbo.tblMovie.movie_id, dbo.tblMovie.movie_nameen + '/' + dbo.tblMovie.movie_nameth AS MoviesName, dbo.tblMovie.movie_strdate, "
            strCommand += " dbo.tblMovie.movie_status, dbo.tblMovie.studio_id, dbo.tblMovie.movie_code, dbo.tblTrailer_Setup_Dtl.movie_background_color, "
            strCommand += " dbo.tblTrailer_Setup_Dtl.movie_font_color, dbo.tblTrailer_Setup_Dtl.setup_no"
            strCommand += " FROM dbo.tblMovie INNER JOIN"
            strCommand += " dbo.tblTrailer_Setup_Dtl ON dbo.tblMovie.movie_id = dbo.tblTrailer_Setup_Dtl.movie_id"


            strCommand += " WHERE 1=1 "

            If ((Not (setup_no Is Nothing))) Then
                If (setup_no.Trim() <> "" And setup_no.Trim() <> "0") Then
                    strCommand += " AND dbo.tblTrailer_Setup_Dtl.setup_no in ('" + setup_no + "') "
                End If
            End If

            If (OderBy_ASC_DESC.Trim() <> "") Then
                strCommand += " ORDER BY " + OderBy_ASC_DESC.Trim()
            Else
                strCommand += " ORDER BY dbo.tblMovie.movie_strdate" ' dbo.tblMovie.movie_id"
            End If

            Return strCommand
        End Function

        Public Sub AddTrailer_Detail _
                ( _
                  ByVal setup_no As String, _
                  ByVal movie_id As Integer, _
                  ByVal movie_background_color As String, _
                  ByVal movie_font_color As String, _
                  ByVal create_dtm As DateTime, _
                  ByVal create_by As String, _
                  ByVal last_update_dtm As DateTime, _
                  ByVal last_update_by As String _
                )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_DtlInsert", _
             setup_no, _
             movie_id, _
             movie_background_color, _
             movie_font_color, _
             create_dtm, _
             create_by, _
             last_update_dtm, _
             last_update_by)
        End Sub


        Public Sub UpdateTrailer_Detail _
            ( _
                ByVal setup_no As String, _
                ByVal movie_id As Integer, _
                ByVal movie_background_color As String, _
                ByVal movie_font_color As String, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
            )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_DtlUpdate", _
             setup_no, _
             movie_id, _
             movie_background_color, _
             movie_font_color, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Function getTrailerDetailRead(ByVal SetupNo As String, ByVal movieId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblTrailer_Setup_DtlRead", SetupNo, movieId), IDataReader)
        End Function

        Public Sub deleteTrailer_Detail(ByVal SetupNo As String, ByVal MovieId As Integer)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_DtlDelete", SetupNo, MovieId)
        End Sub

        Public Sub deleteTrailer_Detail(ByVal SetupNo As String)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_DtlDeleteBySetupNo", SetupNo)
        End Sub


        Public Sub AddTrailer_Head _
                ( _
                  ByVal setup_no As String, _
                  ByVal setup_start_date As DateTime, _
                  ByVal setup_end_date As DateTime, _
                  ByVal create_dtm As DateTime, _
                  ByVal create_by As String, _
                  ByVal last_update_dtm As DateTime, _
                  ByVal last_update_by As String _
                )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_HdrInsert", _
             setup_no, _
             setup_start_date, _
             setup_end_date, _
             create_dtm, _
             create_by, _
             last_update_dtm, _
             last_update_by)
        End Sub


        Public Sub UpdateTrailer_Head _
            ( _
                  ByVal setup_no As String, _
                  ByVal setup_start_date As DateTime, _
                  ByVal setup_end_date As DateTime, _
                  ByVal last_update_dtm As DateTime, _
                  ByVal last_update_by As String _
            )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_HdrUpdate", _
             setup_no, _
             setup_start_date, _
             setup_end_date, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Function getTrailerHeaderRead(ByVal SetupNo As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblTrailer_Setup_HdrRead", SetupNo), IDataReader)
        End Function

        Public Function getTrailerHeaderMaxRead() As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblTrailer_Setup_Hdr_MaxRead"), IDataReader)
        End Function

        Public Function getTrailerHeaderByPeriodDateRead(ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal NotIn_SetupNo As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblTrailer_Setup_Hdr_ByPeriodDateRead", Start_Date, End_Date, NotIn_SetupNo), IDataReader)
        End Function

        Public Sub deleteTrailer_Head(ByVal SetupNo As String)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblTrailer_Setup_HdrDelete", SetupNo)
        End Sub

        Public Function getMaxTrailer_SetupNo() As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetMaxTrailer_SetupNo"), IDataReader)
        End Function

        'weekend trading
        Public Function getWeekendTrading(ByVal SelectDateSun As String, ByVal NumDay As Integer, ByVal QueryType As String) As IDataReader ', ByVal Movie_id As Integer
            Dim V_MOVIE_DAYS As Integer = (NumDay - 1) ' * (-1)
            Dim V_PERIOD_START_DATE As String = Convert.ToDateTime(SelectDateSun).AddDays(NumDay).ToString("yyyy/MM/dd")
            Dim V_DATA_CUR_START_DATE As String = Convert.ToDateTime(SelectDateSun).AddDays(-6).ToString("yyyy/MM/dd")
            Dim V_DATA_PREV_START_DATE As String = Convert.ToDateTime(SelectDateSun).AddDays(-7).ToString("yyyy/MM/dd")
            Dim V_DATA_PREV_END_DATE As String = Convert.ToDateTime(SelectDateSun).AddDays(NumDay).ToString("yyyy/MM/dd")
            Dim V_PERIOD_PRIV_START_DATE As String = Convert.ToDateTime(SelectDateSun).AddDays(-6).ToString("yyyy/MM/dd")

            'SET @V_MOVIE_DAYS = (@MOVIE_DAYS - 1) * (-1)

            'SELECT @V_DATA_CUR_START_DATE = CONVERT(VARCHAR(19), DATEADD(DAY, @V_MOVIE_DAYS, CONVERT(VARCHAR(19), @END_DATE, 111)), 111)
            'FROM SYSOBJECTS

            'SELECT @V_PERIOD_START_DATE = CONVERT(VARCHAR(19), DATEADD(DAY, -6, CONVERT(VARCHAR(19), @END_DATE, 111)), 111)
            'FROM SYSOBJECTS

            'SELECT @V_DATA_PREV_END_DATE = CONVERT(VARCHAR(19), DATEADD(DAY, -7, CONVERT(VARCHAR(19), @END_DATE, 111)), 111)
            'FROM SYSOBJECTS

            'SELECT @V_DATA_PREV_START_DATE = CONVERT(VARCHAR(19), DATEADD(DAY, @V_MOVIE_DAYS, CONVERT(VARCHAR(19), @V_DATA_PREV_END_DATE, 111)), 111)
            'FROM SYSOBJECTS

            'SELECT @V_PERIOD_PRIV_START_DATE = CONVERT(VARCHAR(19), DATEADD(DAY, -6, CONVERT(VARCHAR(19), @V_DATA_PREV_END_DATE, 111)), 111)
            'FROM SYSOBJECTS

            Return CType(SqlHelper.ExecuteReader(CnnString, "spWeekend_Trading", SelectDateSun, NumDay, QueryType), IDataReader) ', Movie_id
        End Function

        Public Function getWeekendTradingMovies(ByVal SelectDateSun As String, ByVal NumDay As Integer, ByVal QueryType As String) As IDataReader

            Return CType(SqlHelper.ExecuteReader(CnnString, "spWeekend_TradingGetMovies", SelectDateSun, NumDay, QueryType), IDataReader)
        End Function

        'Public Shared Function GetDataTable(ByVal strcommand As String) As DataTable
        '    Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("CnnString"))
        '    Dim cmd As New SqlCommand(strcommand, conn)
        '    cmd.CommandTimeout = 600
        '    Dim adp As New SqlDataAdapter(cmd)
        '    Dim ds As New DataSet()
        '    adp.Fill(ds)
        '    Return ds.Tables(0)
        'End Function

        Public Function getTrailerExecuteByWeek(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetTrailerExecuteByWeek", StartDate, EndDate), IDataReader)
        End Function

        Public Function getTrailerExecuteByWeekByMovie(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal Movie_Id As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetTrailerExecuteByWeekByMovie", StartDate, EndDate, Movie_Id), IDataReader)
        End Function

        Public Function getReportGetAllTrailer_ByPeriod(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spReportGetAllTrailer_ByPeriod", StartDate, EndDate), IDataReader)
        End Function

        Public Function getReportGetSumTrailer_ByPeriod(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal Movie_Id As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spReportGetSumTrailer_ByPeriod", StartDate, EndDate, Movie_Id), IDataReader)
        End Function

        ''''''''''''''''Trailer_Collection''''''''''''''''''''''''
        Public Shared Function QueryTrailer_Collection_Head( _
                                    ByVal CircuitId As String _
                                    , ByVal theaterId As String _
                                    , ByVal OderBy_ASC_DESC As String _
                                   ) As String
            Dim strCommand As String = "SELECT collection_no, collection_name, circuit_id, theater_id"
            strCommand += ", create_dtm, create_by, last_update_dtm, last_update_by "
            strCommand += " ,dbo.funGetConcatMovieByColNo(collection_no,0,7) Movie_Collection "
            strCommand += " FROM tblTrailer_Collection_Hdr"
            strCommand += " WHERE 1=1 "
            If ((Not (CircuitId Is Nothing))) Then
                If (CircuitId.Trim() <> "" And CircuitId.Trim() <> "0") Then
                    strCommand += " AND circuit_id in (" + CircuitId + ") "
                End If
            End If

            If ((Not (theaterId Is Nothing))) Then
                If (theaterId.Trim() <> "" And theaterId.Trim() <> "0") Then
                    strCommand += " AND theater_id in (" + theaterId + ") "
                End If
            End If

            If (OderBy_ASC_DESC.Trim() <> "") Then
                strCommand += " ORDER BY " + OderBy_ASC_DESC.Trim()
            Else
                strCommand += " ORDER BY collection_name ASC"
            End If

            Return strCommand
        End Function

        Public Function gettblTrailer_Collection_HdrDetail(ByVal collection_no As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "sptblTrailer_Collection_HdrRead", collection_no), IDataReader)
        End Function

        Public Function gettblTrailer_Collection_HdrDetailByName(ByVal collection_name As String, ByVal CircuitId As Integer, ByVal TheaterId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "sptblTrailer_Collection_HdrByNameRead", collection_name, CircuitId, TheaterId), IDataReader)
        End Function

        Public Function getBoxOfficeByPeriod(ByVal strDate As DateTime, ByVal endDate As DateTime) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetConcatBoxOffByPeriod", strDate, endDate), IDataReader)
        End Function

        Public Function CheckIsNullString(ByVal DataString As Object) As String
            Dim strRE As String = ""
            If DataString Is Nothing Then 'IsDBNull(DataString) 
                strRE = ""
                Return strRE
            Else
                Return DataString.ToString
            End If
        End Function

        Public Function CheckIsNullDateTime(ByVal DataDatetime As Object) As DateTime
            Dim strRE As DateTime
            If IsDBNull(DataDatetime) Then 'IsDBNull(DataString) 
                strRE = New DateTime
                Return strRE
            Else
                Return DataDatetime
            End If
        End Function

        Public Function CheckIsNullInteger(ByVal DataInt As Object) As Decimal
            Dim strRE As Decimal = 0
            If IsDBNull(DataInt) Then
                strRE = 0
                Return strRE
            Else
                Return Convert.ToDecimal(DataInt)
            End If
        End Function

        Public Function getBoxOfficeData_ByPeriod(ByVal strDate As DateTime, ByVal strEndDate As DateTime) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRevenueForCus_ByPeriod", strDate, strEndDate), IDataReader)
        End Function

        Public Sub MovieLateShowInsert _
           ( _
                ByVal show_seq_no As Integer, _
                ByVal show_time_from As String, _
                ByVal show_time_to As String, _
                 ByVal expense_amt As Decimal, _
                ByVal create_dtm As DateTime, _
                ByVal create_by As String, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
            )
            last_update_dtm = ConvertTimeToLocaltime(last_update_dtm) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblMovieLateShowInsert", show_seq_no, show_time_from, show_time_to, expense_amt, create_dtm, create_by, last_update_dtm, last_update_by)
        End Sub

        Public Sub MovieLateShowUpdate _
           ( _
                ByVal show_seq_no As Integer, _
                ByVal show_time_from As String, _
                ByVal show_time_to As String, _
                ByVal expense_amt As Decimal, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
            )
            last_update_dtm = ConvertTimeToLocaltime(last_update_dtm) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblMovieLateShowUpdate", show_seq_no, show_time_from, show_time_to, expense_amt, last_update_dtm, last_update_by)
        End Sub

        Public Function GetMaxID(ByVal paField As String, ByVal paTable As String, ByVal paWhere As String) As String
            Try
                Dim refFieldStr As String = ""
                Dim strSQL As String = "Select Max(" & paField & ") From " + paTable + " " + paWhere
                Dim connectionString As String = CnnString()
                If connectionString Is Nothing Then
                    Return "0"
                End If

                Dim dr As SqlDataReader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, strSQL)
                dr.Read()
                refFieldStr = dr.GetInt32(0).ToString().Trim()
                dr.Close()
                dr.Dispose()
                Return refFieldStr
            Catch
                Return "0"
            End Try
        End Function

        Public Sub ClearControlValues(ByVal Container As WebControl)
            Try
                For Each ctrl As Control In Container.Controls
                    If ctrl.[GetType]() Is GetType(TextBox) Then
                        DirectCast(ctrl, TextBox).Text = ""
                    End If
                    If ctrl.[GetType]() Is GetType(DropDownList) Then
                        DirectCast(ctrl, DropDownList).SelectedIndex = -1
                    End If
                    If ctrl.[GetType]() Is GetType(CheckBox) Then
                        DirectCast(ctrl, CheckBox).Checked = False
                    End If
                    If ctrl.[GetType]() Is GetType(RadioButton) Then
                        DirectCast(ctrl, RadioButton).Checked = False
                    End If
                Next
            Catch
            End Try
        End Sub

        Public Function getRptTrailerViewership(ByVal Real_MovieId As String, ByVal strDate As String, ByVal endDate As String) As DataTable
            'Dim conn As New SqlConnection(ConfigurationSettings.AppSettings("CnnString"))
            Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Dim conn As New SqlConnection(strconn)
            Dim cmd As New SqlCommand("exec spGetRptTrailerViewership " + Real_MovieId + ",'" + strDate + "','" + endDate + "'", conn)
            cmd.CommandTimeout = 600
            Dim adp As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            adp.Fill(ds)
            Return ds.Tables(0)

            'Return CType(SqlHelper.ExecuteReader(CnnString, "spGetRptTrailerViewership", Real_MovieId, strDate, endDate), IDataReader)
        End Function


        Public Sub addCheckerLevel _
            (ByVal saveType As String, _
                ByVal checker_level_id As Integer, _
                ByVal checker_level_name As String, _
                ByVal present_level_flag As String, _
                ByVal former_level_flag As String, _
                ByVal create_dtm As DateTime, _
                ByVal create_by As String, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
            )
            If saveType = "INSERT" Then
                SqlHelper.ExecuteNonQuery _
                (CnnString, "spTblchecker_levelInsert", checker_level_id, checker_level_name, _
                present_level_flag, former_level_flag, Now, create_by, Now, last_update_by)
            Else
                SqlHelper.ExecuteNonQuery _
                (CnnString, "spTblchecker_levelInsert", checker_level_id, checker_level_name, _
                present_level_flag, former_level_flag, Now, create_by, Now, last_update_by)
            End If
        End Sub

        Public Sub addPresentWage _
          (ByVal saveType As String, _
              ByVal checker_level_id As Integer, _
              ByVal screen_id As Integer, _
              ByVal wage_amt As Double, _
              ByVal create_dtm As DateTime, _
              ByVal create_by As String, _
              ByVal last_update_dtm As DateTime, _
              ByVal last_update_by As String _
          )
            If saveType = "INSERT" Then
                SqlHelper.ExecuteNonQuery _
                (CnnString, "sptblChecker_Present_WageInsert", checker_level_id, screen_id, _
                wage_amt, Now, create_by, Now, last_update_by)
            Else
                SqlHelper.ExecuteNonQuery _
                (CnnString, "sptblChecker_Present_WageInsert", checker_level_id, screen_id, _
                wage_amt, Now, create_by, Now, last_update_by)
            End If
        End Sub

        Public Sub addFormerWage _
         (ByVal saveType As String, _
             ByVal checker_level_id As Integer, _
             ByVal screen_id As Integer, _
             ByVal wage_amt As Double, _
             ByVal create_dtm As DateTime, _
             ByVal create_by As String, _
             ByVal last_update_dtm As DateTime, _
             ByVal last_update_by As String _
         )
            If saveType = "INSERT" Then
                SqlHelper.ExecuteNonQuery _
                (CnnString, "sptblChecker_Former_WageInsert", checker_level_id, screen_id, _
                wage_amt, Now, create_by, Now, last_update_by)
            Else
                SqlHelper.ExecuteNonQuery _
                (CnnString, "sptblChecker_Former_WageInsert", checker_level_id, screen_id, _
                wage_amt, Now, create_by, Now, last_update_by)
            End If
        End Sub

        Public Sub addcollectReportConfig _
        (ByVal collect_report_min_amt As Double, _
            ByVal collect_report_max_amt As Double, _
            ByVal collect_report_level_qty As Double, _
            ByVal collect_report_session_qty As Double, _
            ByVal create_dtm As DateTime, _
            ByVal create_by As String, _
            ByVal last_update_dtm As DateTime, _
            ByVal last_update_by As String _
        )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "sptblConfigInsert", collect_report_min_amt, collect_report_max_amt, _
             collect_report_level_qty, collect_report_session_qty, Now, create_by, Now, last_update_by)
        End Sub


        Public Sub addcollectReportConfigSession _
       (ByVal session_id As Integer, _
           ByVal session_qty As Double, _
           ByVal session_amt As Double, _
           ByVal create_dtm As DateTime, _
           ByVal create_by As String, _
           ByVal last_update_dtm As DateTime, _
           ByVal last_update_by As String _
       )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_SessionInsert", 0, session_qty, session_amt, _
             Now, create_by, Now, last_update_by)
        End Sub

        Public Sub deleteChecker_Movie_Head(ByVal SetupNo As String)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_HdrDelete", SetupNo)
        End Sub

        Public Function getChecker_MovieHeaderRead(ByVal SetupNo As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblChecker_Movie_Setup_HdrRead", SetupNo), IDataReader)
        End Function

        Public Shared Function Query_Checker_Movie_Detail( _
                               ByVal setup_no As String _
                              , ByVal OderBy_ASC_DESC As String _
                              ) As String
            Dim strCommand As String = ""
            strCommand += " SELECT dtl.movie_setup_no, dtl.movie_id, mv.movie_nameen, dtl.movie_level_id,"
            strCommand += vbNewLine + " dtl.present_flag, dtl.collect_report_flag"
            strCommand += vbNewLine + " , case dtl.present_flag when 'Y' then 'True' else 'False' end as PresentY"
            strCommand += vbNewLine + " , case dtl.present_flag when 'N' then 'True' else 'False' end as PresentN"
            strCommand += vbNewLine + " , case dtl.present_flag when 'Y' then 'Present Wage' else 'Former Wage' end as present_Show"
            strCommand += vbNewLine + " , case dtl.collect_report_flag when 'Y' then 'True' else 'False' end as collect_report_Y"
            strCommand += vbNewLine + " , case dtl.collect_report_flag when 'Y' then 'Yes' else 'No' end as collect_report_Show"
            strCommand += vbNewLine + " FROM dbo.tblChecker_Movie_Setup_Dtl dtl left join dbo.tblMovie mv"
            strCommand += vbNewLine + " on dtl.movie_id = mv.movie_id"

            strCommand += vbNewLine + " WHERE 1=1 "

            If ((Not (setup_no Is Nothing))) Then
                If (setup_no.Trim() <> "" And setup_no.Trim() <> "0") Then
                    strCommand += " AND dtl.movie_setup_no ='" + setup_no + "'"
                End If
            End If

            If (OderBy_ASC_DESC.Trim() <> "") Then
                strCommand += vbNewLine + " ORDER BY " + OderBy_ASC_DESC.Trim()
            Else
                strCommand += vbNewLine + " ORDER BY mv.movie_nameen " ' dbo.tblMovie.movie_id"
            End If

            Return strCommand
        End Function

        Public Sub AddChecker_Movie_Detail _
               ( _
                 ByVal setup_no As String, _
                 ByVal movie_id As Integer, _
                 ByVal movie_level_id As Integer, _
                 ByVal present_flag As String, _
                 ByVal collect_report_flag As String, _
                 ByVal create_dtm As DateTime, _
                 ByVal create_by As String, _
                 ByVal last_update_dtm As DateTime, _
                 ByVal last_update_by As String _
               )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_DtlInsert", _
             setup_no, _
             movie_id, _
             movie_level_id, _
             present_flag, _
             collect_report_flag, _
             create_dtm, _
             create_by, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Sub UpdateChecker_Movie_Detail _
            ( _
                ByVal setup_no As String, _
                ByVal movie_id As Integer, _
                ByVal movie_level_id As Integer, _
                ByVal present_flag As String, _
                ByVal collect_report_flag As String, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
            )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_DtlUpdate", _
             setup_no, _
             movie_id, _
             movie_level_id, _
             present_flag, _
             collect_report_flag, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Function getChecker_MovieHeaderByPeriodDateRead(ByVal Start_Date As DateTime, ByVal End_Date As DateTime, ByVal NotIn_SetupNo As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblChecker_Movie_Setup_Hdr_ByPeriodDateRead", Start_Date, End_Date, NotIn_SetupNo), IDataReader)
        End Function

        Public Function getMaxChecker_Movie_SetupNo(ByVal setup_start_date As DateTime) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spGetMaxChecker_Movie_SetupNo", setup_start_date), IDataReader)
        End Function

        Public Sub AddChecker_Movie_Head _
               ( _
                 ByVal setup_no As String, _
                 ByVal setup_start_date As DateTime, _
                 ByVal setup_end_date As DateTime, _
                 ByVal create_dtm As DateTime, _
                 ByVal create_by As String, _
                 ByVal last_update_dtm As DateTime, _
                 ByVal last_update_by As String _
               )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_HdrInsert", _
             setup_no, _
             setup_start_date, _
             setup_end_date, _
             create_dtm, _
             create_by, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Sub UpdateChecker_Movie_Head _
          ( _
                ByVal setup_no As String, _
                ByVal setup_start_date As DateTime, _
                ByVal setup_end_date As DateTime, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
          )
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_HdrUpdate", _
             setup_no, _
             setup_start_date, _
             setup_end_date, _
             last_update_dtm, _
             last_update_by)
        End Sub

        Public Sub deleteChecker_Movie_Detail(ByVal SetupNo As String, ByVal MovieId As Integer)
            SqlHelper.ExecuteNonQuery _
            (CnnString, "spTblChecker_Movie_Setup_DtlDelete", SetupNo, MovieId)
        End Sub

        Public Function getChecker_MovieDetailRead(ByVal SetupNo As String, ByVal movieId As Integer) As IDataReader
            Return CType(SqlHelper.ExecuteReader(CnnString, "spTblChecker_Movie_Setup_DtlRead", SetupNo, movieId), IDataReader)
        End Function

        Public Sub UpdateChecker_MovieDetail _
          ( _
                 ByVal SetupNo As String, _
                ByVal movieId As Integer, _
                ByVal movie_level_id As Integer, _
                ByVal present_flag As String, _
                ByVal collect_report_flag As String, _
                ByVal last_update_dtm As DateTime, _
                ByVal last_update_by As String _
          )
            If movie_level_id <> 0 Then
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblChecker_Movie_Setup_DtlUpdate", _
              SetupNo, _
              movieId, _
              movie_level_id, _
              present_flag, _
              collect_report_flag, _
              last_update_dtm, _
              last_update_by)
            Else
                SqlHelper.ExecuteNonQuery _
             (CnnString, "spTblChecker_Movie_Setup_DtlUpdate", _
              SetupNo, _
              movieId, _
              Nothing, _
              present_flag, _
              collect_report_flag, _
              last_update_dtm, _
              last_update_by)
            End If


        End Sub

        Public Sub BindYear(ByRef pddlControl As DropDownList, ByVal pintDecreaseYear As Integer, ByVal pintIncreaseYear As Integer)
            Dim intYearNow As Integer = 0
            intYearNow = DateTime.Today.Year

            Dim intFromYear As Integer = intYearNow - pintDecreaseYear
            Dim intToYear As Integer = intYearNow + pintIncreaseYear
            For i As Integer = intFromYear To intToYear
                pddlControl.Items.Insert(0, New ListItem(i.ToString(), i.ToString()))
            Next

            pddlControl.Items.Insert(0, New ListItem("-Select-", "0"))
            pddlControl.SelectedValue = "0"
        End Sub


    End Class
End Namespace
