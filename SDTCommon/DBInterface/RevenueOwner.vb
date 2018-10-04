Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class RevenueOwner
        Public Shared Function SelectData(ByVal revenueId As Int32?, ByVal movieId As Int32?, ByVal revenueDate As Date?, ByVal theaterId As Int32?, ByVal screenId As Int32?, ByVal revenueTime As String, ByVal statusId As Int32?, ByVal beforeDate As Date?) As DataTable
            Dim sql As String = My.Resources.RevenueOwner.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(revenueId) Then
                paramString &= vbNewLine
                paramString &= "AND rv.revenueid = @revenueid"

                paramList.Add(New SqlParameter("@revenueid", revenueId))
            End If
            If Not IsNothing(movieId) Then
                paramString &= vbNewLine
                paramString &= "AND rv.movies_id = @movies_id"

                paramList.Add(New SqlParameter("@movies_id", movieId))
            End If
            If Not IsNothing(revenueDate) Then
                paramString &= vbNewLine
                paramString &= "AND rv.revenue_date = @revenue_date"

                paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            End If
            If Not IsNothing(beforeDate) Then
                paramString &= vbNewLine
                paramString += "AND rv.revenue_date < @before_date"

                paramList.Add(New SqlParameter("@before_date", beforeDate))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND rv.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(screenId) Then
                paramString &= vbNewLine
                paramString &= "AND rv.theatersub_id = @theatersub_id"

                paramList.Add(New SqlParameter("@theatersub_id", screenId))
            End If
            If Not IsNothing(revenueTime) Then
                paramString &= vbNewLine
                paramString &= "AND rv.revenue_time = @revenue_time"

                paramList.Add(New SqlParameter("@revenue_time", revenueTime))
            End If
            If Not IsNothing(statusId) Then
                paramString &= vbNewLine
                paramString &= "AND rv.status_id = @status_id"

                paramList.Add(New SqlParameter("@status_id", statusId))
            End If

            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "rv.revenue_date DESC"
            sql &= vbNewLine & ", rv.theater_id"
            sql &= vbNewLine & ", rv.theatersub_id"
            sql &= vbNewLine & ", rv.revenue_time"

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

        Public Shared Sub Delete(ByVal revenueId As Int32)
            '@revenue_id
            Dim sql As String = My.Resources.RevenueOwner.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenueid", revenueId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())

            paramList = New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))

            sql = My.Resources.FreeTicketAndPerCapRevenueDetail.DeleteRevenue
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            sql = My.Resources.FreeTicketAndPerCapRevenueHeader.DeleteRevenue
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())

            sql = My.Resources.TicketTypeRevenueDetail.DeleteRevenue
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            sql = My.Resources.TicketTypeRevenueHeader.DeleteRevenue
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Insert(ByVal movieId As Int32, ByVal revenueDate As Date, ByVal theaterId As Int32, ByVal screenId As Int32, ByVal sessionTime As String, ByVal statusId As Int32, ByVal filmTypeSoundId As Int32, ByVal revenueType As String, ByVal viewerWithFreeTicket As Int32, ByVal revenueAmountNoCap As Double, ByVal userId As String, ByVal revenueTimeHourOrder As Int32, ByVal revenueTimeMinOrder As Int32)
            '@revenue_adms_with_free_ticket
            ', @revenue_amount_no_cap
            ', @revenue_date
            ', @revenue_time
            ', @revenue_type
            ', @theatersub_id
            ', @user_id
            ', @movies_id
            ', @theater_id
            ', @status_id
            ', @film_type_sound_id

            ', @revenue_time_hour_order
            ', @revenue_time_min_order
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueOwner.Insert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_adms_with_free_ticket", viewerWithFreeTicket))
            paramList.Add(New SqlParameter("@revenue_amount_no_cap", revenueAmountNoCap))
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@revenue_time", sessionTime))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@revenue_type", revenueType))
            paramList.Add(New SqlParameter("@theatersub_id", screenId))
            paramList.Add(New SqlParameter("@user_id", userId))
            paramList.Add(New SqlParameter("@movies_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))

            paramList.Add(New SqlParameter("@revenue_time_hour_order", revenueTimeHourOrder))
            paramList.Add(New SqlParameter("@revenue_time_min_order", revenueTimeMinOrder))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Update(ByVal revenueId As Int32, ByVal movieId As Int32, ByVal revenueDate As Date, ByVal theaterId As Int32, ByVal screenId As Int32, ByVal sessionTime As String, ByVal statusId As Int32, ByVal filmTypeSoundId As Int32, ByVal revenueType As String, ByVal actualViewer As Int32, ByVal actualRevenueAmount As Double, ByVal viewerWithFreeTicket As Int32, ByVal revenueAmountNoFreeAndCap As Double, ByVal userId As String, ByVal revenueTimeHourOrder As Int32, ByVal revenueTimeMinOrder As Int32)
            '@revenueid
            ', @revenue_adms
            ', @revenue_amount
            ', @revenue_date
            ', @revenue_time
            ', @revenue_type
            ', @theatersub_id
            ', @user_id
            ', @movies_id
            ', @theater_id
            ', @status_id
            ', @film_type_sound_id
            ', @revenue_adms_with_free_ticket
            ', @revenue_amount_no_cap

            ', @revenue_time_hour_order
            ', @revenue_time_min_order
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueOwner.Update
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenueid", revenueId))

            paramList.Add(New SqlParameter("@revenue_adms", actualViewer))
            paramList.Add(New SqlParameter("@revenue_amount", actualRevenueAmount))
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))
            paramList.Add(New SqlParameter("@revenue_time", sessionTime))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@revenue_type", revenueType))
            paramList.Add(New SqlParameter("@theatersub_id", screenId))
            paramList.Add(New SqlParameter("@user_id", userId))
            paramList.Add(New SqlParameter("@movies_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@status_id", statusId))
            paramList.Add(New SqlParameter("@film_type_sound_id", filmTypeSoundId))
            paramList.Add(New SqlParameter("@revenue_adms_with_free_ticket", viewerWithFreeTicket))
            paramList.Add(New SqlParameter("@revenue_amount_no_cap", revenueAmountNoFreeAndCap))

            paramList.Add(New SqlParameter("@revenue_time_hour_order", revenueTimeHourOrder))
            paramList.Add(New SqlParameter("@revenue_time_min_order", revenueTimeMinOrder))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateActualSetTicket(ByVal revenueId As Int32, ByVal actualRevenueAmount As Double, ByVal actualViewer As Int32, ByVal userId As String)
            '@revenueid

            ', @actual_revenue_amount
            ', @actual_viewer
            ', @user_id
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueOwner.UpdateActualSetTicket
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenueid", revenueId))

            paramList.Add(New SqlParameter("@actual_revenue_amount", actualRevenueAmount))
            paramList.Add(New SqlParameter("@actual_viewer", actualViewer))
            paramList.Add(New SqlParameter("@user_id", userId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateRevenueStatus(ByVal revenueId As Int32, ByVal statusId As Int32)
            '@revenueid
            ', @status_id
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueOwner.UpdateRevenueStatus
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenueid", revenueId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@status_id", statusId))
            'paramList.Add(New SqlParameter("@user_id", userId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateStatus(ByVal movieId As Int32, ByVal theaterId As Int32, ByVal statusId As Int32)
            '@movies_id
            ', @theater_id
            ', @status_id
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.RevenueOwner.UpdateStatus
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movies_id", movieId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@status_id", statusId))
            'paramList.Add(New SqlParameter("@user_id", userId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

    End Class
End Namespace