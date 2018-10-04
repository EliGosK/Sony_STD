Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class VpfMovieDefaultSet
        Public Shared Function SelectData(ByVal movieId As Int32?, ByVal circuitId As Int32?, ByVal filmTypeSoundId As Int32?) As DataTable
            Dim sql As String = My.Resources.VpfMovieDefaultSet.SelectData
            Dim paramList As New List(Of SqlParameter)
            'Dim paramString As String = String.Empty
            'If Not IsNothing(movieId) Then
            '    paramString &= vbNewLine
            '    paramString &= "AND vmd.movie_id = @movie_id"

            '    paramList.Add(New SqlParameter("@movie_id", movieId))
            'End If
            'If Not IsNothing(circuitId) Then
            '    paramString &= vbNewLine
            '    If circuitId = -1 Then
            '        paramString &= "AND vmd.circuit_id = @circuit_id"
            '    Else
            '        paramString &= "AND (vmd.circuit_id = @circuit_id OR vmd.circuit_id = -1)"
            '    End If

            '    paramList.Add(New SqlParameter("@circuit_id", circuitId))
            'End If
            'If Not IsNothing(filmTypeSoundId) Then
            '    paramString &= vbNewLine
            '    paramString &= "AND vmd.film_type_sound_id = @film_type_sound_id"

            '    paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            'End If

            'If Not String.IsNullOrEmpty(paramString) Then
            '    sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            'End If

            'sql &= vbNewLine & "ORDER BY"
            'sql &= vbNewLine & "vmd.movie_id"
            'sql &= vbNewLine & ", vmd.film_type_sound_id"
            'sql &= vbNewLine & ", vmd.circuit_id"

            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))

            Dim ds As DataSet
            'If String.IsNullOrEmpty(paramString) Then
            '    ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            'Else
            ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            'End If
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub Delete(ByVal movieId As Int32, ByVal circuitId As Int32, ByVal filmTypeSoundId As Int32)
            '@movie_id
            ', @circuit_id
            ', @film_type_sound_id
            Dim sql As String = My.Resources.VpfMovieDefaultSet.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateInsert(ByVal movieId As Int32, ByVal circuitId As Int32, ByVal filmTypeSoundId As Int32, ByVal startDate As Date, ByVal amount As Int32, ByVal setDays As Int32, ByVal setSessions As Int32, ByVal setPrice As Decimal, ByVal updateBy As String)
            '@movie_id
            ', @circuit_id
            ', @film_type_sound_id
            ', @vpf_start_date
            ', @sets_amount
            ', @set_days
            ', @set_sessions
            ', @set_price
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.VpfMovieDefaultSet.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@vpf_start_date", startDate))
            paramList.Add(New SqlParameter("@sets_amount", amount))
            paramList.Add(New SqlParameter("@set_days", setDays))
            paramList.Add(New SqlParameter("@set_sessions", setSessions))
            paramList.Add(New SqlParameter("@set_price", setPrice))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace