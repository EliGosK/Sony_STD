Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class Theater
        Public Shared Function SelectData(ByVal theaterId As Int32?, ByVal circuitId As Int32?, ByVal activeFlag As Boolean?) As DataTable
            Dim sql As String = My.Resources.Theater.SelectData
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND t.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(circuitId) Then
                paramString &= vbNewLine
                paramString &= "AND t.circuit_id = @circuit_id"

                paramList.Add(New SqlParameter("@circuit_id", circuitId))
            End If
            If Not IsNothing(activeFlag) Then
                paramString &= vbNewLine
                If activeFlag.Value Then
                    paramString &= "AND t.theater_status = 'Enabled'"
                Else
                    paramString &= "AND t.theater_status <> 'Enabled'"
                End If
            End If
            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "c.circuit_id"
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

        Public Shared Function SelectByUser(ByVal userId As Int32?, ByVal theaterId As Int32?, ByVal activeFlag As Boolean?) As DataTable
            Dim sql As String = My.Resources.Theater.SelectByUser
            Dim paramList As New List(Of SqlParameter)
            Dim paramString As String = String.Empty
            If Not IsNothing(userId) Then
                paramString &= vbNewLine
                paramString &= "AND ut.user_id = @user_id"

                paramList.Add(New SqlParameter("@user_id", userId))
            End If
            If Not IsNothing(theaterId) Then
                paramString &= vbNewLine
                paramString &= "AND ut.theater_id = @theater_id"

                paramList.Add(New SqlParameter("@theater_id", theaterId))
            End If
            If Not IsNothing(activeFlag) Then
                paramString &= vbNewLine
                If activeFlag.Value Then
                    paramString &= "AND t.theater_status = 'Enabled'"
                Else
                    paramString &= "AND t.theater_status <> 'Enabled'"
                End If
            End If
            If Not String.IsNullOrEmpty(paramString) Then
                sql &= vbNewLine & "WHERE" & vbNewLine & paramString.Substring(5)
            End If

            sql &= vbNewLine & "ORDER BY"
            sql &= vbNewLine & "c.circuit_id"
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
    End Class

End Namespace