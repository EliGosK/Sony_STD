Imports Microsoft.ApplicationBlocks.Data
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class RevenueTime
        Public Shared Function SelectHour() As DataTable
            Dim sql As String = My.Resources.RevenueTime.RevenueHour
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function SelectMinute() As DataTable
            Dim sql As String = My.Resources.RevenueTime.RevenueMinute
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
    End Class

End Namespace