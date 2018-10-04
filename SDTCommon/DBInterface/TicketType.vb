Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class TicketType
        Public Shared Function SelectData(ByVal ticketTypeId As Int32?, ByVal ticketTypeName As String, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal isActive As Boolean?, ByVal onlyNull As Boolean) As DataTable
            Dim sql As String = My.Resources.TicketType.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(ticketTypeId) Then
                paramString &= vbNewLine
                paramString &= "AND tt.ticket_type_id = @ticket_type_id"

                paramList.Add(New SqlParameter("@ticket_type_id", ticketTypeId))
            End If
            If Not IsNothing(ticketTypeName) Then
                paramString &= vbNewLine
                paramString &= "AND tt.ticket_type_name = @ticket_type_name"

                paramList.Add(New SqlParameter("@ticket_type_name", ticketTypeName))
            End If
            If Not IsNothing(theaterId) Then
                If IsNothing(circuitId) Then
                    Dim dtb As DataTable = Theater.SelectData(theaterId, Nothing, Nothing)
                    If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                        Return Nothing
                    End If
                    circuitId = CType(dtb.Rows(0)("circuit_id"), Integer?)
                End If

                paramString &= vbNewLine
                paramString &= "AND (',' + tt.list_theater_id + ',' LIKE '%," + theaterId.Value.ToString() + ",%' OR tt.list_theater_id IS NULL)"
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
            If onlyNull Then
                paramString &= vbNewLine
                paramString &= "AND tt.list_theater_id IS NULL"
            End If

            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "tt.ticket_type_name"

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

        Public Shared Sub Insert(ByVal ticketTypeName As String, ByVal circuitId As Int32, ByVal listTheaterId As String, ByVal activeFlag As Boolean, ByVal createBy As String)
            '@ticket_type_name
            ', @circuit_id
            ', @list_theater_id
            ', @active_flag
            ', @create_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.TicketType.Insert
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@ticket_type_name", ticketTypeName))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@list_theater_id", listTheaterId))
            paramList.Add(New SqlParameter("@active_flag", activeFlag))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@create_by", createBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
        Public Shared Sub Update(ByVal ticketTypeId As Int32, ByVal ticketTypeName As String, ByVal circuitId As Int32, ByVal listTheaterId As String, ByVal activeFlag As Boolean, ByVal updateBy As String)
            '@ticket_type_id
            ', @ticket_type_name
            ', @circuit_id
            ', @list_theater_id
            ', @active_flag
            ', @update_by
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim sql As String = My.Resources.TicketType.Update
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@ticket_type_id", ticketTypeId))

            paramList.Add(New SqlParameter("@ticket_type_name", ticketTypeName))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))
            paramList.Add(New SqlParameter("@list_theater_id", listTheaterId))
            paramList.Add(New SqlParameter("@active_flag", activeFlag))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@update_by", updateBy))
            SqlHelper.ExecuteNonQuery(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub
    End Class
End Namespace