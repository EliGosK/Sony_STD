Imports Microsoft.ApplicationBlocks.Data

Namespace DBInterface
    Public Class FilmType
        Public Shared Function SelectData() As DataTable
            Dim sql As String = My.Resources.FilmType.SelectData
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
    End Class
End Namespace