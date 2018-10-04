Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class TicketTypeRevenueHeader
        'Public Shared Function SelectAllIncomplete(ByVal theaterId As Int32, ByVal beforeDate As Date) As DataTable
        '    '@theater_id
        '    ', @before_date
        '    Dim sql As String = My.Resources.TicketTypeRevenueHeader.SelectAllIncomplete
        '    Dim paramList As New List(Of SqlParameter)
        '    paramList.Add(New SqlParameter("@theater_id", theaterId))
        '    paramList.Add(New SqlParameter("@before_date", beforeDate))
        '    Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function
        Public Shared Function SelectData(ByVal revenueId As Int32) As DataTable
            '@revenue_id
            Dim sql As String = My.Resources.TicketTypeRevenueHeader.SelectData
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        'Public Shared Function SelectIncompleteMovie(ByVal theaterId As Int32, ByVal revenueDate As Date) As DataTable
        '    Dim sql As String = My.Resources.TicketTypeRevenueHeader.SelectIncompleteMovie
        '    Dim paramList As New List(Of SqlParameter)
        '    paramList.Add(New SqlParameter("@theater_id", theaterId))
        '    paramList.Add(New SqlParameter("@revenue_date", revenueDate))

        '    Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function

        Public Shared Sub UpdateInsert(ByVal revenueId As Int32, ByVal ticketTypeCount As Int32, ByVal createBy As String)
            '@revenue_id
            ', @ticket_type_count
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.TicketTypeRevenueHeader.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@ticket_type_count", ticketTypeCount))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace