Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class RevenueCompHeader
        Public Shared Function SelectData(ByVal revenueCompHeaderId As Int32?, ByVal movieId As Int32?, ByVal revenueDate As Date?, ByVal theaterId As Int32?, ByVal statusId As Int32?, ByVal beforeDate As Date?) As DataTable
            Dim sql As String = My.Resources.RevenueCompHeader.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(revenueCompHeaderId) Then
                paramString &= vbNewLine
                paramString &= "AND rch.revenue_comp_header_id = @revenue_comp_header_id"

                paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
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
            If Not IsNothing(beforeDate) Then
                paramString &= vbNewLine
                paramString += "AND rch.revenue_date < @before_date"

                paramList.Add(New SqlParameter("@before_date", beforeDate))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND rch.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(statusId) Then
                paramString &= vbNewLine
                paramString &= "AND rch.status_id = @status_id"

                paramList.Add(New SqlParameter("@status_id", statusId))
            End If

            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "rch.revenue_date DESC"
            sql &= vbNewLine & ", rch.theater_id"

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

        Public Shared Sub DeleteAll(ByVal movieId As Int32, ByVal revenueDate As Date, ByVal theaterId As Int32)
            '@revenue_date
            ', @movie_id
            ', @theater_id
            Dim sql As String = My.Resources.RevenueCompHeader.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub DeleteAll(ByVal revenueCompHeaderId As Int32)
            '@revenue_comp_header_id
            Dim sql As String = My.Resources.RevenueCompHeader.DeleteAll
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Insert(ByVal movieId As Int32, ByVal revenueDate As Date, ByVal theaterId As Int32, ByVal allScreen As Int32, ByVal allSessionTime As Int32, ByVal allAdms As Int32, ByVal allAmount As Double, ByVal statusId As Int32, ByVal updateBy As String)
            '@revenue_date
            ', @movie_id
            ', @theater_id
            ', @all_screen
            ', @all_session
            ', @all_adms
            ', @all_amount
            ', @status_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompHeader.Insert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@all_screen", allScreen))
            paramList.Add(New SqlParameter("@all_session", allSessionTime))
            paramList.Add(New SqlParameter("@all_adms", allAdms))
            paramList.Add(New SqlParameter("@all_amount", allAmount))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If Not IsNothing(ds) Then
                InsertUpdateOldTable(CInt(ds.Tables(0)(0)(0)))
            End If
        End Sub
        Public Shared Sub InsertUpdateOldTable(ByVal revenueCompHeaderId As Int32)
            '@revenue_comp_header_id
            Dim sql As String = My.Resources.RevenueCompHeader.InsertUpdateOldTable
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Update(ByVal revenueCompHeaderId As Int32, ByVal revenueDate As Date, ByVal movieId As Int32, ByVal theaterId As Int32, ByVal allScreen As Int32, ByVal allSessionTime As Int32, ByVal allAdms As Int32, ByVal allAmount As Double, ByVal statusId As Int32, ByVal updateBy As String)
            '@revenue_comp_header_id
            ', @revenue_date
            ', @movie_id
            ', @theater_id
            ', @all_screen
            ', @all_session
            ', @all_adms
            ', @all_amount
            ', @status_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompHeader.Update
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@all_screen", allScreen))
            paramList.Add(New SqlParameter("@all_session", allSessionTime))
            paramList.Add(New SqlParameter("@all_adms", allAdms))
            paramList.Add(New SqlParameter("@all_amount", allAmount))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            InsertUpdateOldTable(revenueCompHeaderId)
        End Sub
        Public Shared Sub UpdateStatus(ByVal revenueCompHeaderId As Int32, ByVal statusId As Int32)
            '@revenue_comp_header_id
            ', @status_id
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompHeader.UpdateStatus
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            InsertUpdateOldTable(revenueCompHeaderId)
        End Sub
        Public Shared Sub RefreshHeaderAfterEditDetail(ByVal revenueCompHeaderId As Int32, ByVal updateBy As String)
            '@revenue_comp_header_id
            '@update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueCompHeader.RefreshHeaderAfterEditDetail
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_comp_header_id", revenueCompHeaderId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace