Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class FreeTicketAndPerCapRevenueHeader
        'Public Shared Function SelectAllIncomplete(ByVal theaterId As Int32, ByVal beforeDate As Date) As DataTable
        '    '@theater_id
        '    ', @before_date
        '    Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.SelectAllIncomplete
        '    Dim paramList As New List(Of SqlParameter)
        '    paramList.Add(New SqlParameter("@theater_id", theaterId))
        '    paramList.Add(New SqlParameter("@before_date", beforeDate))
        '    Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function
        Public Shared Function SelectCheckRevenue(ByVal revenueId As Int32) As DataTable
            '@revenue_id
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.SelectCheckRevenue
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function SelectData(ByVal revenueId As Int32) As DataTable
            '@revenue_id
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.SelectData
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        'Public Shared Function SelectIncompleteMovie(ByVal theaterId As Int32, ByVal revenueDate As Date) As DataTable
        '    Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.SelectIncompleteMovie
        '    Dim paramList As New List(Of SqlParameter)
        '    paramList.Add(New SqlParameter("@theater_id", theaterId))
        '    paramList.Add(New SqlParameter("@revenue_date", revenueDate))

        '    Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function

        Public Shared Sub Insert(ByVal revenueId As Int32, ByVal freeTicketNormCount As Int32, ByVal freeTicketSpecialCount As Int32, ByVal freeMore5Count As Int32, ByVal freeMore5Sum As Double, ByVal createBy As String)
            '@revenue_id
            ', @free_ticket_norm_count
            ', @free_ticket_special_count
            ', @free_more_5_count
            ', @free_more_5_sum
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.Insert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@free_ticket_norm_count", freeTicketNormCount))
            paramList.Add(New SqlParameter("@free_ticket_special_count", freeTicketSpecialCount))
            paramList.Add(New SqlParameter("@free_more_5_count", freeMore5Count))
            paramList.Add(New SqlParameter("@free_more_5_sum", freeMore5Sum))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Update(ByVal revenueId As Int32, ByVal freeTicketNormCount As Int32, ByVal freeTicketSpecialCount As Int32, ByVal freeMore5Count As Int32, ByVal freeMore5Sum As Double, ByVal createBy As String)
            '@revenue_id
            ', @free_ticket_norm_count
            ', @free_ticket_special_count
            ', @free_more_5_count
            ', @free_more_5_sum
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueHeader.Update
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@free_ticket_norm_count", freeTicketNormCount))
            paramList.Add(New SqlParameter("@free_ticket_special_count", freeTicketSpecialCount))
            paramList.Add(New SqlParameter("@free_more_5_count", freeMore5Count))
            paramList.Add(New SqlParameter("@free_more_5_sum", freeMore5Sum))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace