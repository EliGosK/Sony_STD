Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class RevenueCompDetail
        Public Shared Function SelectData(ByVal revenueId As Int32?, ByVal revenueCompHeaderId As Int32?, ByVal filmTypeSoundId As Int32?, ByVal movieId As Int32?, ByVal revenueDate As Date?, ByVal theaterId As Int32?) As DataTable
            Dim sql As String = My.Resources.RevenueCompDetail.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(revenueId) Then
                paramString &= vbNewLine
                paramString &= "AND rcd.revenue_id = @revenue_id"

                paramList.Add(New SqlParameter("@revenue_id", revenueId))
            End If
            If Not IsNothing(revenueCompHeaderId) Then
                paramString &= vbNewLine
                paramString &= "AND rcd.revenue_comp_header_id = @revenue_comp_header_id"

                paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            End If
            If Not IsNothing(filmTypeSoundId) Then
                paramString &= vbNewLine
                paramString &= "AND rcd.film_type_sound_id = @film_type_sound_id"

                paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            End If
            If Not IsNothing(movieId) Then
                paramString &= vbNewLine
                paramString &= "AND rch.movie_id = @movie_id"

                paramList.Add(New SqlParameter("@movie_id", movieId))
            End If
            If Not IsNothing(revenueDate) Then
                paramString &= vbNewLine
                paramString &= "AND rch.revenue_date = @revenue_date"

                paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND rch.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If

            Dim ds As DataSet
            If String.IsNullOrEmpty(paramString) Then
                ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            Else
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
                ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            End If
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub Delete(ByVal revenueId As Int32, ByVal updateBy As String)
            '@revenue_id
            Dim sql As String = My.Resources.RevenueCompDetail.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@update_by", updateBy))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If Not IsNothing(ds) Then
                Dim revenueCompHeaderId As Int32 = CInt(ds.Tables(0)(0)(0))
                RevenueCompHeader.RefreshHeaderAfterEditDetail(revenueCompHeaderId, updateBy)
                RevenueCompHeader.InsertUpdateOldTable(revenueCompHeaderId)
            End If
        End Sub
        Public Shared Sub Insert(ByVal revenueCompHeaderId As Int32, ByVal filmTypeSoundId As Int32, ByVal countScreen As Int32, ByVal countSession As Int32, ByVal countViewer As Int32, ByVal revenue As Double, ByVal statusId As Int32, ByVal updateBy As String)
            '@revenue_comp_header_id
            ', @film_type_sound_id
            ', @count_screen
            ', @count_session
            ', @adms
            ', @amount
            ', @status_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompDetail.Insert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@count_screen", countScreen))
            paramList.Add(New SqlParameter("@count_session", countSession))
            paramList.Add(New SqlParameter("@adms", countViewer))
            paramList.Add(New SqlParameter("@amount", revenue))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            RevenueCompHeader.RefreshHeaderAfterEditDetail(revenueCompHeaderId, updateBy)
            RevenueCompHeader.InsertUpdateOldTable(revenueCompHeaderId)
        End Sub
        Public Shared Sub Update(ByVal revenueId As Int32, ByVal filmTypeSoundId As Int32, ByVal countScreen As Int32, ByVal countSession As Int32, ByVal countViewer As Int32, ByVal revenue As Double, ByVal statusId As Int32, ByVal updateBy As String)
            '@revenue_id
            ', @film_type_sound_id
            ', @count_screen
            ', @count_session
            ', @adms
            ', @amount
            ', @status_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompDetail.Update
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@count_screen", countScreen))
            paramList.Add(New SqlParameter("@count_session", countSession))
            paramList.Add(New SqlParameter("@adms", countViewer))
            paramList.Add(New SqlParameter("@amount", revenue))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If Not IsNothing(ds) Then
                Dim revenueCompHeaderId As Int32 = CInt(ds.Tables(0)(0)(0))
                RevenueCompHeader.RefreshHeaderAfterEditDetail(revenueCompHeaderId, updateBy)
                RevenueCompHeader.InsertUpdateOldTable(revenueCompHeaderId)
            End If
        End Sub
        Public Shared Sub UpdateStatus(ByVal revenueCompHeaderId As Int32, ByVal statusId As Int32)
            '@revenue_comp_header_id
            ', @status_id
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompDetail.UpdateStatus
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace