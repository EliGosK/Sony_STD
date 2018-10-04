Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class MovieAndTrailer

#Region "Movie"
        Public Shared Function GetMovieDetail(ByVal movieId As Int32?, ByVal title As String, ByVal status As Int32?, ByVal appearStatus As Int32?, ByVal distibutor As Int32?, ByVal studio As Int32?, ByVal movieType As Int32?, ByVal order As String) As DataTable
            Dim sql As String = "SELECT"
            sql += " m.movie_id"
            sql += " , m.movie_code"
            sql += " , m.movie_nameth"
            sql += " , m.movie_nameen"
            sql += " , m.movie_strdate"
            sql += " , m.movie_enddate"
            sql += " , m.movie_lastupdate"
            sql += " , m.movie_status"
            sql += " , m.movietype_id"
            sql += " , m.user_id"
            sql += " , m.studio_id"
            sql += " , m.distributor_id"
            sql += " , m.movie_gern"
            sql += " , m.movie_gernsub"
            sql += " , m.movie_pattern"
            sql += " , m.movie_national"
            sql += " , m.movie_director"
            sql += " , m.movie_cast1"
            sql += " , m.movie_cast2"
            sql += " , m.appear_status_id"
            sql += " , m.revenue_estimete"
            sql += " , m.flat_sale_rental"
            sql += " , m.remark"
            sql += " , m.batch_appear_flag"
            sql += " , m.ad_pub_amt"
            sql += " , m.print_cost_amt"
            sql += " , m.print_qty"
            sql += " , m.show_in_report_flag"

            sql += " , m.movie_nameen + '/' + m.movie_nameth as MovieName"

            'sql += " --, s.studio_id"
            sql += " , s.studio_code"
            sql += " , s.studio_name"
            'sql += " --, s.active_flag"
            sql += " , s.create_dtm"
            sql += " , s.create_by"
            sql += " , s.last_update_dtm"
            sql += " , s.last_update_by"

            'sql += " --, d.distributor_id("")"
            sql += " , d.distributor_name"
            sql += " , d.distributor_code"
            'sql += " --, d.active_flag"

            sql += " , mt.id"
            'sql += " --, mt.MovieType_ID"
            sql += " , mt.MovieType_Des"

            'sql += " --, ms.movie_statusId"
            sql += " , ms.movie_statusTitle"
            sql += " , ms.movie_statusCode"

            sql += " FROM tblMovie as m"
            sql += " LEFT JOIN tblStudio as s"
            sql += " ON s.studio_id = m.studio_id"
            sql += " LEFT JOIN tblDistributor as d"
            sql += " ON d.distributor_id = m.distributor_id"
            sql += " LEFT JOIN tblMovieType as mt"
            sql += " ON mt.MovieType_ID = m.movietype_id"
            sql += " LEFT JOIN tblMovieStatus as ms"
            sql += " ON ms.movie_statusId = m.movie_status"
            sql += " WHERE 1 = 1"

            If Not IsNothing(movieId) Then
                sql += " AND m.movie_id = " + movieId.Value.ToString()
            End If
            If Not String.IsNullOrEmpty(title) Then
                sql += String.Format(" AND ((m.movie_nameen LIKE '%{0}%') OR (m.movie_nameth LIKE '%{0}%')) ", title)
            End If
            If Not IsNothing(status) Then
                sql += " AND m.movie_status = " + status.Value.ToString()
            End If
            If Not IsNothing(appearStatus) Then
                sql += " AND m.appear_status_id = " + appearStatus.Value.ToString()
            End If
            If Not IsNothing(distibutor) Then
                sql += " AND m.distributor_id = " + distibutor.Value.ToString()
            End If
            If Not IsNothing(studio) Then
                sql += " AND m.studio_id = " + studio.Value.ToString()
            End If
            If Not IsNothing(movieType) Then
                sql += " AND m.movietype_id = " + movieType.Value.ToString()
            End If

            sql += " ORDER BY "
            If String.IsNullOrEmpty(order) Then
                sql += "m.movie_strdate DESC"
            Else
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function GetMovieDetail(ByVal movieId As Int32) As DataTable
            Return GetMovieDetail(movieId, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        End Function
        'Public Shared Function GetMovieDetail(ByVal movieId As Int32) As DataTable
        '    Dim sqlParam = New SqlParameter("@movie_id", movieId)
        '    Dim ds As Dataset = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.StoredProcedure, "spTblMovieRead", sqlParam)
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function

        Public Shared Sub UpdateMovieStatus(ByVal movieId As Int32, ByVal movieStatus As Int32)
            Dim sql As String = "UPDATE tblMovie"
            sql += " SET"
            'sql += " movie_code = @movie_code"
            'sql += " , movie_nameth = @movie_nameth"
            'sql += " , movie_nameen = @movie_nameen"
            'sql += " , movie_strdate = @movie_strdate"
            'sql += " , movie_enddate = @movie_enddate"
            'sql += " , movie_lastupdate = @movie_lastupdate"
            'sql += " , movie_status = @movie_status"

            sql += " movie_status = @movie_status"

            'sql += " , movietype_id = @movietype_id"
            'sql += " , user_id = @user_id"
            'sql += " , studio_id = @studio_id"
            'sql += " , distributor_id = @distributor_id"
            'sql += " , movie_gern = @movie_gern"
            'sql += " , movie_gernsub = @movie_gernsub"
            'sql += " , movie_pattern = @movie_pattern"
            'sql += " , movie_national = @movie_national"
            'sql += " , movie_director = @movie_director"
            'sql += " , movie_cast1 = @movie_cast1"
            'sql += " , movie_cast2 = @movie_cast2"
            'sql += " , appear_status_id = @appear_status_id"
            'sql += " , revenue_estimete = @revenue_estimete"
            'sql += " , flat_sale_rental = @flat_sale_rental"
            'sql += " , remark = @remark"
            'sql += " , batch_appear_flag = @batch_appear_flag"
            'sql += " , ad_pub_amt = @ad_pub_amt"
            'sql += " , print_cost_amt = print_cost_amt"
            'sql += " , print_qty = @print_qty"
            'sql += " , show_in_report_flag = @show_in_report_flag"
            sql += " WHERE movie_id = @movie_id;"
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@movie_status", movieStatus))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
#End Region

#Region "Movie Theater"
        Public Shared Sub InsertMovieTheater(ByVal movieId As Int32, ByVal theaterId As Int32, ByVal printQty As Int32, ByVal createBy As String)
            Dim sql As String = "INSERT INTO tblMovie_Theater"
            sql += " ("
            sql += " movie_id"
            sql += " , theater_id"
            sql += " , print_qty"
            sql += " , create_dtm"
            sql += " , create_by"
            sql += " , last_update_dtm"
            sql += " , last_update_by"
            sql += " )"
            sql += " VALUES"
            sql += " ("
            sql += " @movie_id"
            sql += " , @theater_id"
            sql += " , @print_qty"
            sql += " , @cvDate"
            sql += " , @create_by"
            sql += " , @cvDate"
            sql += " , @create_by"
            sql += " );"
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@print_qty", printQty))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@create_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
#End Region

#Region "Movie Release"
        'Public Shared Function IsMovieRelease(ByVal theaterId As Int32, ByVal movieId As Int32) As Boolean
        '    Dim sql As String = "SELECT COUNT(movies_id) FROM tblRelease WHERE movies_id = " & movieId.ToString() & " AND theater_id = " & theaterId.ToString()
        '    Dim ds As Dataset = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
        '    If IsNothing(ds) Then
        '        Return False
        '    End If
        '    Return ReturnBoolean(ConvertToInt32(ds.Tables(0)(0)(0)) > 0)
        'End Function

        Public Shared Function IsMovieExist(ByVal movieId As Int32) As Boolean
            Dim sql As String = "SELECT"
            sql += " CASE WHEN ISNULL(COUNT(*), 0) > 0 THEN 1 ELSE 0 END"
            sql += " FROM tblTheater t"
            sql += " LEFT JOIN tblRelease r"
            sql += " ON r.theater_id = t.theater_id"
            sql += " AND r.movies_id = " + movieId.ToString()
            sql += " WHERE t.theater_status = 'Enabled'"
            'sql += " AND (r.theater_id IS NULL OR r.onrelease_status = 1 OR r.onrelease_status = 3)"
            sql += " AND r.onrelease_status = 1"
            sql += " ;"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return False
            End If
            Return CInt(ConvertToInt32(ds.Tables(0)(0)(0))) > 0
        End Function
        Public Shared Function GetMovieRelease(ByVal movieId As Int32?, ByVal titleLike As String, ByVal theaterId As Int32?, ByVal onReleaseStatus As Int32?, ByVal movieTypeId As Int32?, ByVal order As String) As DataTable
            Dim sql As String = "SELECT"
            sql += " m.movie_id"
            sql += " , m.movie_code"
            sql += " , m.movie_nameth"
            sql += " , m.movie_nameen"
            sql += " , m.movie_strdate"
            sql += " , m.movie_enddate"
            sql += " , m.movie_lastupdate"
            sql += " , m.movie_status"
            sql += " , m.movietype_id"
            sql += " , m.user_id"
            sql += " , m.studio_id"
            sql += " , m.distributor_id"
            sql += " , m.movie_gern"
            sql += " , m.movie_gernsub"
            sql += " , m.movie_pattern"
            sql += " , m.movie_national"
            sql += " , m.movie_director"
            sql += " , m.movie_cast1"
            sql += " , m.movie_cast2"
            sql += " , m.appear_status_id"
            sql += " , m.revenue_estimete"
            sql += " , m.flat_sale_rental"
            sql += " , m.remark"
            sql += " , m.batch_appear_flag"
            sql += " , m.ad_pub_amt"
            sql += " , m.print_cost_amt"
            sql += " , m.print_qty"
            sql += " , m.show_in_report_flag"

            sql += " , m.movie_nameen + '/' + m.movie_nameth as MovieName"

            sql += " , CONVERT(varchar(15), m.movietype_id) + CONVERT (varchar(15), m.movie_id) as dm"

            sql += " , r.onrelease_id"
            sql += " , r.onrelease_status"
            sql += " , r.onrelease_startdate"
            sql += " , r.onrelease_enddate"
            sql += " , r.movies_id"
            sql += " , r.theater_id"

            sql += " , ISNULL(r.onrelease_status, 1) as releaseStatus"

            sql += " FROM tblMovie as m"
            sql += " LEFT JOIN tblRelease as r"
            sql += " ON r.movies_id = m.movie_id"
            If Not IsNothing(theaterId) Then
                sql += " AND r.theater_id = " + theaterId.Value.ToString()
            End If
            sql += " WHERE m.movie_status = 1"
            sql += " AND m.appear_status_id = 1"
            sql += " AND ISNULL(r.onrelease_status, 1) = 1"

            If Not IsNothing(movieId) Then
                sql += " AND m.movie_id = " + movieId.Value.ToString()
            End If
            If Not String.IsNullOrEmpty(titleLike) Then
                sql += String.Format(" AND ((m.movie_nameen LIKE '%{0}%') OR (m.movie_nameth LIKE '%{0}%')) ", titleLike)
            End If
            If Not IsNothing(onReleaseStatus) Then
                sql += " AND r.onrelease_status = " + onReleaseStatus.Value.ToString()
            End If
            If Not IsNothing(movieTypeId) Then
                sql += " AND m.movietype_id = " + movieTypeId.Value.ToString()
            End If

            sql += " ORDER BY "
            If String.IsNullOrEmpty(order) Then
                sql += "r.onrelease_status, m.movie_strdate DESC, m.movietype_id ASC"
            Else
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function


        Public Shared Sub InsertMovieReleaseStatus(ByVal movieId As Int32, ByVal theaterId As Int32, ByVal releaseStatus As Int32, ByVal releaseDate As String) 'AddRelease
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spCheckOnRelease", releaseStatus, releaseDate, movieId, theaterId)
        End Sub
        Public Shared Sub UpdateInsertMovieTerminate(ByVal movieId As Int32, ByVal theaterId As Int32, ByVal releaseEndDate As Date)
            Dim sql As String = "UPDATE tblRelease"
            sql += " SET"
            sql += " onrelease_status = @onrelease_status"
            sql += " , onrelease_enddate = @onrelease_enddate"
            sql += " WHERE movies_id = @movies_id"
            sql += " AND theater_id = @theater_id"

            sql += " IF @@ROWCOUNT <> 0 RETURN;"

            sql += " declare @startDate as datetime;"
            sql += " SELECT @startDate = movie_strdate FROM tblMovie WHERE movie_id = @movies_id;"

            sql += " INSERT INTO tblRelease"
            sql += " ("
            sql += " onrelease_status"
            sql += " , onrelease_startdate"
            sql += " , onrelease_enddate"
            sql += " , movies_id"
            sql += " , theater_id"
            sql += " )"
            sql += " VALUES"
            sql += " ("
            sql += " @onrelease_status"
            sql += " , @startDate"
            sql += " , @onrelease_enddate"
            sql += " , @movies_id"
            sql += " , @theater_id"
            sql += " );"

            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movies_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@onrelease_status", 2))
            paramList.Add(New SqlParameter("@onrelease_enddate", releaseEndDate))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
#End Region

#Region "TrailerMaster"
        Public Shared Function GetMaxTrailerNo(ByVal circuitId As Int32, ByVal theaterId As Int32, ByVal theatersubId As Int32) As Int32? 'getMaxTrailer_TrailerNo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, "spGetMaxTrailer_TrailerNo", circuitId.ToString("00"), theaterId.ToString("000"), theatersubId.ToString("00"))
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ConvertToInt32(ds.Tables(0)(0)(0))
        End Function
        Public Shared Function GetMovieDetailTrailerSetup(ByVal movieId As Int32?, ByVal order As String) As DataTable 'QueryMovieTrailer
            Dim sql As String = "SELECT"
            sql += " m.movie_id"
            sql += " , m.movie_code"
            sql += " , m.movie_nameth"
            sql += " , m.movie_nameen"
            sql += " , m.movie_strdate"
            sql += " , m.movie_enddate"
            sql += " , m.movie_lastupdate"
            sql += " , m.movie_status"
            sql += " , m.movietype_id"
            sql += " , m.user_id"
            sql += " , m.studio_id"
            sql += " , m.distributor_id"
            sql += " , m.movie_gern"
            sql += " , m.movie_gernsub"
            sql += " , m.movie_pattern"
            sql += " , m.movie_national"
            sql += " , m.movie_director"
            sql += " , m.movie_cast1"
            sql += " , m.movie_cast2"
            sql += " , m.appear_status_id"
            sql += " , m.revenue_estimete"
            sql += " , m.flat_sale_rental"
            sql += " , m.remark"
            sql += " , m.batch_appear_flag"
            sql += " , m.ad_pub_amt"
            sql += " , m.print_cost_amt"
            sql += " , m.print_qty"
            sql += " , m.show_in_report_flag"

            sql += " , m.movie_nameen + '/' + m.movie_nameth as MovieName"

            ''sql += " --, s.studio_id"
            'sql += " , s.studio_code"
            'sql += " , s.studio_name"
            ''sql += " --, s.active_flag"
            'sql += " , s.create_dtm"
            'sql += " , s.create_by"
            'sql += " , s.last_update_dtm"
            'sql += " , s.last_update_by"

            ''sql += " --, d.distributor_id"
            'sql += " , d.distributor_name"
            'sql += " , d.distributor_code"
            ''sql += " --, d.active_flag"

            'sql += " , mt.id"
            ''sql += " --, mt.MovieType_ID"
            'sql += " , mt.MovieType_Des"

            ''sql += " --, ms.movie_statusId"
            'sql += " , ms.movie_statusTitle"
            'sql += " , ms.movie_statusCode"

            sql += " , dt.setup_no"
            'sql += " --, dt.movie_id"
            sql += " , dt.movie_background_color"
            sql += " , dt.movie_font_color"
            'sql += " --, dt.create_dtm"
            'sql += " --, dt.create_by"
            'sql += " --, dt.last_update_dtm"
            'sql += " --, dt.last_update_by"

            'sql += " --, hd.setup_no"
            sql += " , hd.setup_start_date"
            sql += " , hd.setup_end_date"
            'sql += " --, hd.create_dtm"
            'sql += " --, hd.create_by"
            'sql += " --, hd.last_update_dtm"
            'sql += " --, hd.last_update_by"

            sql += " FROM tblMovie as m"
            'sql += " LEFT JOIN tblStudio as s"
            'sql += " ON s.studio_id = m.studio_id"
            'sql += " LEFT JOIN tblDistributor as d"
            'sql += " ON d.distributor_id = m.distributor_id"
            'sql += " LEFT JOIN tblMovieType as mt"
            'sql += " ON mt.MovieType_ID = m.movietype_id"
            'sql += " LEFT JOIN tblMovieStatus as ms"
            'sql += " ON ms.movie_statusId = m.movie_status"


            sql += " INNER JOIN tblTrailer_Setup_Dtl as dt"
            sql += " ON dt.movie_id = m.movie_id"
            sql += " INNER JOIN dbo.tblTrailer_Setup_Hdr as hd"
            sql += " ON hd.setup_no = dt.setup_no"

            sql += " WHERE 1 = 1"

            If Not IsNothing(movieId) Then
                sql += " AND m.movie_id = " + movieId.Value.ToString()
            End If

            sql += " AND hd.setup_start_date <= '" + Date.Now.ToString("yyyy-MM-dd") + "'"
            sql += " AND hd.setup_end_date >= '" + Date.Now.ToString("yyyy-MM-dd") + "'"

            sql += " ORDER BY "
            If String.IsNullOrEmpty(order) Then
                sql += "m.movie_strdate DESC"
            Else
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function GetTrailerMaster(ByVal trailerNo As String, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal screenId As Int32?, ByVal realMovieId As Int32?, ByVal collectionNo As String, ByVal order As String) As DataTable 'QueryTrailer_Master
            Dim sql As String = "SELECT"
            sql += " tm.trailer_no"
            sql += " , tm.circuit_id"
            sql += " , tm.theater_id"
            sql += " , tm.theatersub_id"
            sql += " , tm.real_movie_id"
            sql += " , tm.collection_no"
            sql += " , tm.confirm_flag"
            sql += " , tm.active_flag"
            sql += " , tm.create_dtm"
            sql += " , tm.create_by"
            sql += " , tm.last_update_dtm"
            sql += " , tm.last_update_by"

            sql += " , dbo.funGetConcatMovieByColNo(tm.collection_no, 0, 5) as MovieCollection"

            'sql += " --, h.collection_no"
            sql += " , h.collection_name"
            'sql += " --, h.circuit_id"
            'sql += " --, h.theater_id"
            'sql += " --, h.active_flag"
            'sql += " --, h.create_dtm"
            'sql += " --, h.create_by"
            'sql += " --, h.last_update_dtm"
            'sql += " --, h.last_update_by"

            sql += " , m.movie_id"
            sql += " , m.movie_code"
            sql += " , m.movie_nameth"
            sql += " , m.movie_nameen"
            sql += " , m.movie_strdate"
            sql += " , m.movie_enddate"
            sql += " , m.movie_lastupdate"
            sql += " , m.movie_status"
            sql += " , m.movietype_id"
            sql += " , m.user_id"
            sql += " , m.studio_id"
            sql += " , m.distributor_id"
            sql += " , m.movie_gern"
            sql += " , m.movie_gernsub"
            sql += " , m.movie_pattern"
            sql += " , m.movie_national"
            sql += " , m.movie_director"
            sql += " , m.movie_cast1"
            sql += " , m.movie_cast2"
            sql += " , m.appear_status_id"
            sql += " , m.revenue_estimete"
            sql += " , m.flat_sale_rental"
            sql += " , m.remark"
            sql += " , m.batch_appear_flag"
            sql += " , m.ad_pub_amt"
            sql += " , m.print_cost_amt"
            sql += " , m.print_qty"
            sql += " , m.show_in_report_flag"

            sql += " , m.movie_nameen + '/' + m.movie_nameth as MovieName"

            sql += " FROM tblTrailer_Master as tm "
            sql += " LEFT JOIN tblTrailer_Collection_Hdr as h "
            sql += " ON h.collection_no = tm.collection_no"
            sql += " LEFT JOIN tblMovie as m "
            sql += " ON m.movie_id  = tm.real_movie_id"
            sql += " WHERE tm.active_flag = 'Y'"

            If Not String.IsNullOrEmpty(trailerNo) Then
                sql += " AND tm.trailer_no = '" + trailerNo + "'"
            End If
            If Not IsNothing(circuitId) Then
                sql += " AND tm.circuit_id = " + circuitId.Value.ToString()
            End If
            If Not IsNothing(theaterId) Then
                sql += " AND tm.theater_id = " + theaterId.Value.ToString()
            End If
            If Not IsNothing(screenId) Then
                sql += " AND tm.theatersub_id = " + screenId.Value.ToString()
            End If
            If Not IsNothing(realMovieId) Then
                sql += " AND tm.real_movie_id = " + realMovieId.Value.ToString()
            End If
            If Not String.IsNullOrEmpty(collectionNo) Then
                sql += " AND tm.collection_no = '" + collectionNo + "'"
            End If

            If Not String.IsNullOrEmpty(order) Then
                sql += " ORDER BY "
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        'Public Shared Function getTrailer_MasterDetail(ByVal circuit_id As Int32, ByVal theater_id As Int32, ByVal theatersub_id As Int32, ByVal real_movie_id As Int32) As IDataReader 'getTrailer_MasterDetail
        '    Return CType(SqlHelper.ExecuteReader(MainConnectionString, "spTblTrailer_MasterRead_ByScreen", circuit_id, theater_id, theatersub_id, real_movie_id), IDataReader)
        'End Function


        Public Shared Sub DeleteTrailerMaster(ByVal trailerNo As String)
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_MasterDelete", trailerNo)
        End Sub
        Public Shared Sub InsertTrailerMaster(ByVal trailerNo As String, ByVal circuitId As Int32, ByVal theaterId As Int32, ByVal screenId As Int32, ByVal realMovieId As Int32, ByVal collectionNo As String, ByVal confirmFlag As String, ByVal activeFlag As String, ByVal createBy As String) 'addTrailer_Master
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_MasterInsert", trailerNo, circuitId, theaterId, screenId, realMovieId, collectionNo, confirmFlag, activeFlag, DateTime.Now, createBy, ConvertTimeToLocaltime(saveDatetimeNow), createBy)
        End Sub
        Public Shared Sub UpdateTrailerMaster(ByVal trailerNo As String, ByVal circuitId As Int32, ByVal theaterId As Int32, ByVal screenId As Int32, ByVal realMovieId As Int32, ByVal collectionNo As String, ByVal activeFlag As String, ByVal lastUpdateBy As String) 'updateTrailer_Master
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_MasterUpdate", trailerNo, circuitId, theaterId, screenId, realMovieId, collectionNo, activeFlag, ConvertTimeToLocaltime(saveDatetimeNow), lastUpdateBy)
        End Sub
        Public Shared Sub UpdateConfirmFlagTrailerMaster(ByVal trailerNo As String, ByVal status As String, ByVal lastUpdateBy As String)
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_MasterUpdateConfirmFlag", trailerNo, status, DateTime.Now, lastUpdateBy)
        End Sub
#End Region

#Region "TrailerCollection"
        Public Shared Function GetCountTrailerCollectionDetail(ByVal collectionNo As String) As Int32
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, "SELECT COUNT(*) FROM tblTrailer_Collection_Dtl WHERE collection_no = '" + collectionNo + "'")
            If IsNothing(ds) Then
                Return 0
            End If
            Return CInt(ds.Tables(0)(0)(0))
        End Function
        Public Shared Function GetMaxTrailerCollectionNo(ByVal circuitId As Int32, ByVal theaterId As Int32) As Int32? 'getMaxTrailer_CollectionNo
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, "spGetMaxTrailer_CollectionNo", circuitId.ToString("00"), theaterId.ToString("000"))
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ConvertToInt32(ds.Tables(0)(0)(0))
        End Function
        Public Shared Function GetMaxSequenceNoOfTrailerCollectionDetail(ByVal collectionNo As String) As Int32?
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, "SELECT MAX(seq_no) FROM tblTrailer_Collection_Dtl WHERE collection_no = '" + collectionNo + "'")
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ConvertToInt32(ds.Tables(0)(0)(0))
        End Function
        Public Shared Function GetTrailerCollectionHeader(ByVal collectionNo As String, ByVal collectionName As String, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal activeFlag As Boolean?, ByVal order As String) As DataTable 'QueryTrailer_Collection_Head
            Dim sql As String = "SELECT"
            sql += " tch.*"
            sql += " , dbo.funGetConcatMovieByColNo(collection_no, 0, 5) as MovieCollection"
            sql += " FROM tblTrailer_Collection_Hdr as tch"
            sql += " WHERE 1 = 1"

            If Not String.IsNullOrEmpty(collectionNo) Then
                sql += " AND tch.collection_no = '" + collectionNo + "'"
            End If
            If Not String.IsNullOrEmpty(collectionName) Then
                sql += " AND tch.collection_name = '" + collectionName + "'"
            End If
            If Not IsNothing(circuitId) Then
                sql += " AND tch.circuit_id = " + circuitId.Value.ToString()
            End If
            If Not IsNothing(theaterId) Then
                sql += " AND tch.theater_id = " + theaterId.Value.ToString()
            End If
            If Not IsNothing(activeFlag) Then
                If activeFlag.Value Then
                    sql += " AND tch.active_flag = 'Y'"
                Else
                    sql += " AND tch.active_flag <> 'Y'"
                End If
            End If

            sql += " ORDER BY "
            If String.IsNullOrEmpty(order) Then
                sql += "tch.collection_name DESC"
            Else
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function GetTrailerHeaderByPeriodDate(ByVal startDate As Date, ByVal endDate As Date, ByVal notInSetupNo As String) As DataTable 'getTrailerHeaderByPeriodDateRead
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, "spTblTrailer_Setup_Hdr_ByPeriodDateRead", startDate, endDate, notInSetupNo)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        '        Public Shared Function getTrailer_Collection_DetailByMovieId(ByVal collection_no As String, ByVal movie_id As int32) As IDataReader
        '            Return CType(SqlHelper.ExecuteReader(MainConnectionString, "spTblTrailer_Collection_DtlRead_ByMovieId", collection_no, movie_id), IDataReader)
        '        End Function



        '        'Public Shared Function QueryTrailer_Collection_Detail( _
        '        '                          ByVal Collection_No As String _
        '        '                         , ByVal OderBy_ASC_DESC As String _
        '        '                         ) As String
        '        '    Dim strCommand = "SELECT distinct tblTrailer_Collection_Dtl.collection_no,tblTrailer_Collection_Dtl.seq_no"
        '        '    strCommand += " , tblMovie.movie_id, tblMovie.movie_nameen + '/' + tblMovie.movie_nameth AS MovieName"
        '        '    strCommand += " , tblMovie.movie_strdate, tblMovie.movie_status, tblMovieType.MovieType_Des, tblMovie.studio_id"
        '        '    strCommand += " , tblMovie.movie_code, tblDistributor.distributor_name, tblStudio.studio_name, tblMovieStatus.movie_statusCode"
        '        '    strCommand += " , tblMovieStatus.movie_statusTitle"
        '        '    strCommand += " FROM tblMovie INNER JOIN tblTrailer_Collection_Dtl ON tblMovie.movie_id = tblTrailer_Collection_Dtl.movie_id "
        '        '    strCommand += " LEFT OUTER JOIN tblStudio ON tblMovie.studio_id = tblStudio.studio_id "
        '        '    strCommand += " LEFT OUTER JOIN tblDistributor ON tblMovie.distributor_id = tblDistributor.distributor_id "
        '        '    strCommand += " LEFT OUTER JOIN tblMovieType ON tblMovie.movietype_id = tblMovieType.MovieType_ID "
        '        '    strCommand += " LEFT OUTER JOIN tblMovieStatus ON tblMovie.movie_status = tblMovieStatus.movie_statusId "
        '        '    strCommand += " WHERE 1=1 "
        '        '    If ((Not (Collection_No Is Nothing))) Then
        '        '        If (Collection_No.Trim() <> "" And Collection_No.Trim() <> "0") Then
        '        '            strCommand += " AND tblTrailer_Collection_Dtl.collection_no = '" + Collection_No.Trim() + "'"
        '        '        End If
        '        '    End If

        '        '    If (OderBy_ASC_DESC.Trim() <> "") Then
        '        '        strCommand += " ORDER BY " + OderBy_ASC_DESC.Trim()
        '        '    Else
        '        '        strCommand += " ORDER BY tblTrailer_Collection_Dtl.seq_no ASC"
        '        '    End If

        '        '    Return strCommand
        '        'End Function


        'Public Shared Function GetTrailerCollectionHeader(ByVal collectionNo As String) As DataTable
        '    Dim sqlParam = New SqlParameter("@collection_no", collectionNo)
        '    Dim ds As Dataset = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.StoredProcedure, "spTblTrailer_Collection_HdrReadPopup", sqlParam)
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function
        'Public Shared Function GetTrailerCollectionHeader(ByVal collectionName As String, ByVal circuitId As Int32, ByVal theaterId As Int32) As DataTable
        '    Dim sqlParam As SqlParameter() = {New SqlParameter("@collection_name", collectionName), New SqlParameter("@Circuit", circuitId), New SqlParameter("@Theater", theaterId)}
        '    Dim ds As Dataset = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.StoredProcedure, "sptblTrailer_Collection_HdrByNameRead", sqlParam)
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function

        Public Shared Sub DeleteTrailerCollectionHeader(ByVal collectionNo As String) 'deleteTrailer_Collection_Head
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_HdrDelete", collectionNo)
        End Sub
        Public Shared Sub InsertTrailerCollectionHeader(ByVal collectionNo As String, ByVal collectionName As String, ByVal circuitId As Int32, ByVal theaterId As Int32, ByVal createBy As String) 'addTrailer_Collection_Hdr
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_HdrInsert", collectionNo, collectionName, circuitId, theaterId, DateTime.Now, createBy, ConvertTimeToLocaltime(saveDatetimeNow), createBy)
        End Sub
        Public Shared Sub UpdateTrailerCollectionHeader(ByVal collectionNo As String, ByVal collectionName As String, ByVal circuitId As Int32, ByVal theaterId As Int32, ByVal lastUpdateBy As String) 'updateTrailer_Collection_Hdr
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_HdrUpdate", collectionNo, collectionName, circuitId, theaterId, ConvertTimeToLocaltime(saveDatetimeNow), lastUpdateBy)
        End Sub

        'Public Shared Sub DeleteTrailerCollectionDetail(ByVal collectionNo As String, ByVal seqNo As Int32) 'deleteTrailer_Collection_Detail
        '    SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_DtlDelete", collectionNo, seqNo)
        'End Sub
        Public Shared Sub DeleteTrailerCollectionDetailMovieId(ByVal collectionNo As String, ByVal movieId As Int32)
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, "DELETE FROM tblTrailer_Collection_Dtl WHERE collection_no = '" + collectionNo + "' AND movie_id = " + movieId.ToString())
        End Sub
        'Public Shared Sub InsertTrailerCollectionDetail(ByVal collectionNo As String, ByVal seqNo As Int32, ByVal movieId As Int32, ByVal setupNo As String, ByVal createBy As String) 'AddTrailer_Collection_Detail
        '    SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_DtlInsert", collectionNo, seqNo, movieId, setupNo, DateTime.Now, createBy, DateTime.Now, createBy)
        'End Sub
        'Public Shared Sub InsertTrailerCollectionDetail(ByVal collectionNo As String, ByVal seqNo As Int32, ByVal movieId As Int32, ByVal setupNo As String, ByVal createDate As Date, ByVal createBy As String, ByVal updateBy As String) 'AddTrailer_Collection_Detail
        '    SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_DtlInsert", collectionNo, seqNo, movieId, setupNo, createDate, createBy, DateTime.Now, updateBy)
        'End Sub
        Public Shared Sub UpdateTrailerCollectionDetail(ByVal collectionNo As String, ByVal seqNo As Int32, ByVal movieId As Int32, ByVal movieIdOld As Int32, ByVal setupNo As String, ByVal lastUpdateBy As String) 'updateTrailer_Collection_Detail
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblTrailer_Collection_DtlUpdate", collectionNo, seqNo, movieId, movieIdOld, setupNo, ConvertTimeToLocaltime(saveDatetimeNow), lastUpdateBy)
        End Sub
#End Region

    End Class
End Namespace