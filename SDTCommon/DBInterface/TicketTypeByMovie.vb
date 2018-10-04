Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class TicketTypeByMovie
        Public Shared Function SelectData(ByVal movieId As Int32?, ByVal ticketTypeId As Int32?, ByVal theaterId As Int32?, ByVal circuitId As Int32?, ByVal isActive As Boolean?) As DataTable
            Dim sql As String = My.Resources.TicketTypeByMovie.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(movieId) Then
                paramString &= vbNewLine
                paramString &= "AND ttm.movie_id = @movie_id"

                paramList.Add(New SqlParameter("@movie_id", movieId))
            End If
            If Not IsNothing(ticketTypeId) Then
                paramString &= vbNewLine
                paramString &= "AND ttm.ticket_type_id = @ticket_type_id"

                paramList.Add(New SqlParameter("@ticket_type_id", ticketTypeId))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND ttm.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(circuitId) Then
                paramString &= vbNewLine
                paramString &= "AND tt.circuit_id = @circuit_id"

                paramList.Add(New SqlParameter("@circuit_id", circuitId))
            End If
            If Not IsNothing(isActive) Then
                paramString &= vbNewLine
                If isActive Then
                    paramString &= "AND tt.active_flag = 1"
                Else
                    paramString &= "AND tt.active_flag = 0"
                End If
            End If

            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "tt.ticket_type_name"
            sql &= vbNewLine & ", t.theater_name"

            Dim ds As DataSet
            If String.IsNullOrEmpty(paramString) Then
                ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            Else
                ds = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            End If
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub Delete(ByVal movieId As Int32, ByVal ticketTypeId As Int32, ByVal theaterId As Int32)
            '@movie_id
            ', @ticket_type_id
            ', @theater_id
            Dim sql As String = My.Resources.TicketTypeByMovie.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@ticket_type_id", ticketTypeId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateInsert(ByVal movieId As Int32, ByVal ticketTypeId As Int32, ByVal theaterId As Int32, ByVal updateBy As String)
            '@movie_id
            ', @ticket_cap_id
            ', @theater_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.TicketTypeByMovie.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@ticket_type_id", ticketTypeId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace