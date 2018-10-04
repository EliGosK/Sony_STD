Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class TrailerCollectionDetail
        Public Shared Function SelectData(ByVal collectionNo As String, ByVal seqNo As Int32?, ByVal movieId As Int32?, ByVal order As String) As DataTable 'QueryTrailer_Collection_Detail
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

            sql += " , dt.Collection_No"
            'sql += " --, dt.movie_id"
            sql += " , dt.seq_no"
            sql += " , dt.ref_setup_no"
            sql += " , dt.create_dtm"
            sql += " , dt.create_by"
            sql += " , dt.last_update_dtm"
            sql += " , dt.last_update_by"

            sql += " FROM tblTrailer_Collection_Dtl as dt"
            sql += " LEFT JOIN tblMovie as m"
            sql += " ON m.movie_id = dt.movie_id"

            'sql += " FROM tblMovie as m"
            'sql += " LEFT JOIN tblStudio as s"
            'sql += " ON s.studio_id = m.studio_id"
            'sql += " LEFT JOIN tblDistributor as d"
            'sql += " ON d.distributor_id = m.distributor_id"
            'sql += " LEFT JOIN tblMovieType as mt"
            'sql += " ON mt.MovieType_ID = m.movietype_id"
            'sql += " LEFT JOIN tblMovieStatus as ms"
            'sql += " ON ms.movie_statusId = m.movie_status"

            sql += " WHERE 1 = 1"

            If Not String.IsNullOrEmpty(collectionNo) Then
                sql += " AND dt.collection_no = '" + collectionNo + "'"
            End If
            If Not IsNothing(seqNo) Then
                sql += " AND dt.seq_no = " + seqNo.Value.ToString()
            End If

            If Not IsNothing(movieId) Then
                sql += " AND dt.movie_id = " + movieId.Value.ToString()
            End If

            sql += " ORDER BY "
            If String.IsNullOrEmpty(order) Then
                sql += "dt.seq_no ASC"
            Else
                sql += order.Trim()
            End If

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Sub DeleteAndPromoteAfter(ByVal collectionNo As String, ByVal seqNo As Int32)
            ' @collection_no
            ',@seq_no
            Dim sql As String = My.Resources.TrailerCollectionDetail.DeleteAndPromoteAfter

            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@collection_no", collectionNo))
            paramList.Add(New SqlParameter("@seq_no", seqNo))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Sub InsertAndDemoteAfter(ByVal collectionNo As String, ByVal seqNo As Int32, ByVal movieId As Int32, ByVal refSetupNo As String, ByVal createBy As String)
            ' @collection_no
            ',@seq_no
            ',@movie_id
            ',@ref_setup_no
            ',@create_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.TrailerCollectionDetail.InsertAndDemoteAfter

            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@collection_no", collectionNo))
            paramList.Add(New SqlParameter("@seq_no", seqNo))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@ref_setup_no", refSetupNo))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@create_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace