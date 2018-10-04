Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class FreeTicketAndPerCapRevenueDetail
        Public Shared Function SelectData(ByVal revenueId As Int32) As DataTable
            '@revenue_id
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueDetail.SelectData
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub Delete(ByVal keyId As Int32)
            '@key_id
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueDetail.Delete
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@key_id", keyId))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub UpdateInsert(ByVal revenueId As Int32, ByVal ticketCapId As Int32, ByVal price As Double, ByVal quantity As Int32, ByVal createBy As String)
            '@revenue_id
            ', @ticket_cap_id
            ', @price
            ', @quantity
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.FreeTicketAndPerCapRevenueDetail.UpdateInsert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@revenue_id", revenueId))
            paramList.Add(New SqlParameter("@ticket_cap_id", ticketCapId))
            paramList.Add(New SqlParameter("@price", price))
            paramList.Add(New SqlParameter("@quantity", quantity))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace