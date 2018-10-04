Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class ProblemRecord
        Public Shared Function SelectData(ByVal revenueDate As DateTime?, ByVal theaterId As Int32?, ByVal movieId As Int32?, ByVal circuitId As Int32?, ByVal startDate As Date?, ByVal endDate As Date?) As DataTable
            Dim sql As String = My.Resources.ProblemRecord.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(revenueDate) Then
                paramString &= vbNewLine
                paramString &= "AND pr.revenue_date = @revenue_date"

                paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND pr.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(movieId) Then
                paramString &= vbNewLine
                paramString &= "AND pr.movie_id = @movie_id"

                paramList.Add(New SqlParameter("@movie_id", movieId))
            End If
            If Not IsNothing(circuitId) Then
                paramString &= vbNewLine
                paramString &= "AND c.circuit_id = @circuit_id"

                paramList.Add(New SqlParameter("@circuit_id", circuitId))
            End If
            If Not IsNothing(startDate) Then
                paramString &= vbNewLine
                paramString &= "AND pr.revenue_date >= @start_date"

                paramList.Add(New SqlParameter("@start_date", startDate))
            End If
            If Not IsNothing(endDate) Then
                paramString &= vbNewLine
                paramString &= "AND pr.revenue_date <= @end_date"

                paramList.Add(New SqlParameter("@end_date", endDate))
            End If
            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "pr.revenue_date"
            sql &= vbNewLine & ", pr.theater_id"
            sql &= vbNewLine & ", pr.movie_id"

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
        Public Shared Sub Delete(ByVal revenueDate As DateTime, ByVal theaterId As Int32, ByVal movieId As Int32)
            '@revenue_date
            ', @theater_id
            ', @movie_id
            Dim sql As String = My.Resources.ProblemRecord.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateInsert(ByVal revenueDate As DateTime?, ByVal theaterId As Int32?, ByVal movieId As Int32?, ByVal problem As String, ByVal updateBy As String)
            '@revenue_date
            ', @theater_id
            ', @movie_id
            ', @problem
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.ProblemRecord.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@problem", problem))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class

End Namespace