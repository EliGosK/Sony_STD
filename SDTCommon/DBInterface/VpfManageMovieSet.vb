Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Namespace DBInterface
    Public Class VpfManageMovieSet
        Public Shared Function SelectData(ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal movieId As Int32?, ByVal filmTypeSoundId As Int32?, ByVal setNo As Int32?) As DataTable
            Dim sql As String = My.Resources.VpfManageMovieSet.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(circuitId) Then
                paramString &= vbNewLine
                paramString &= "AND t.circuit_id = @circuit_id"

                paramList.Add(New SqlParameter("@circuit_id", circuitId))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND mms.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(movieId) Then
                paramString &= vbNewLine
                paramString &= "AND mms.movie_id = @movie_id"

                paramList.Add(New SqlParameter("@movie_id", movieId))
            End If
            If Not IsNothing(filmTypeSoundId) Then
                paramString &= vbNewLine
                paramString &= "AND mms.film_type_sound_id = @film_type_sound_id"

                paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            End If
            If Not IsNothing(setNo) Then
                paramString &= vbNewLine
                paramString &= "AND mms.set_no = @set_no"

                paramList.Add(New SqlParameter("@set_no", setNo))
            End If
            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            Dim ds As DataSet
            If String.IsNullOrEmpty(paramString) Then
                ds = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            Else
                ds = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            End If
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Function SelectSummary(ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal movieId As Int32, ByVal filmTypeId As Int32?, ByVal setNo As Int32?) As DataTable
            '@circuit_id
            ', @theater_id
            ', @movie_id
            ', @film_type_sound_id
            ', @set_no
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeId))
            paramList.Add(New SqlParameter("@set_no", setNo))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_VpfSummary", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub CopyRow(ByVal theaterId As Int32, ByVal movieId As Int32, ByVal filmTypeSoundId As Int32, ByVal setNo As Int32, ByVal updateBy As String)
            '@theater_id
            ', @movie_id
            ', @film_type_sound_id
            ', @set_no
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.VpfManageMovieSet.CopyRow
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@set_no", setNo))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Sub Delete(ByVal theaterId As Int32, ByVal movieId As Int32, ByVal filmTypeSoundId As Int32, ByVal setNo As Int32)
            '@theater_id
            ', @movie_id
            ', @film_type_sound_id
            ', @set_no
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.VpfManageMovieSet.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@set_no", setNo))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Sub LoadDefaultSet(ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal movieId As Int32, ByVal updateBy As String)
            '@circuit_id
            ', @theater_id
            ', @movie_id
            ', @update_by
            Dim sql As String = My.Resources.VpfManageMovieSet.LoadDefaultSet
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170816
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170816
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Sub UpdateInsert(ByVal theaterId As Int32, ByVal movieId As Int32, ByVal filmTypeSoundId As Int32, ByVal setNo As Int32, ByVal startDate As Date, ByVal setDays As Int32, ByVal setSessions As Int32, ByVal setPrice As Decimal, ByVal actualPrice As Decimal?, ByVal userRemark As String, ByVal updateBy As String)
            '@theater_id
            ', @movie_id
            ', @film_type_sound_id
            ', @set_no
            ', @vpf_start_date
            ', @set_days
            ', @set_sessions
            ', @set_price
            ', @actual_price
            ', @user_remark
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.VpfManageMovieSet.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@set_no", setNo))
            paramList.Add(New SqlParameter("@vpf_start_date", startDate))
            paramList.Add(New SqlParameter("@set_days", setDays))
            paramList.Add(New SqlParameter("@set_sessions", setSessions))
            paramList.Add(New SqlParameter("@set_price", setPrice))
            paramList.Add(New SqlParameter("@actual_price", actualPrice))
            paramList.Add(New SqlParameter("@user_remark", userRemark))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Sub UpdatePayment(ByVal theaterId As Int32, ByVal movieId As Int32, ByVal filmTypeSoundId As Int32, ByVal setNo As Int32, ByVal actualPrice As Decimal?, ByVal userRemark As String, ByVal updateBy As String)
            '@theater_id
            ', @movie_id
            ', @film_type_sound_id
            ', @set_no
            ', @actual_price
            ', @user_remark
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.VpfManageMovieSet.UpdatePayment
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@set_no", setNo))
            paramList.Add(New SqlParameter("@actual_price", actualPrice))
            paramList.Add(New SqlParameter("@user_remark", userRemark))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

    End Class
End Namespace