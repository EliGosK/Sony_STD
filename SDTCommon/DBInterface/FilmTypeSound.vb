Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class FilmTypeSound
        Public Shared Function SelectActiveData(ByVal theaterId As Int32) As DataTable
            '@theater_id
            Dim sql As String = My.Resources.FilmTypeSound.SelectActiveData
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Function SelectData() As DataTable
            Dim sql As String = My.Resources.FilmTypeSound.SelectData
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, Nothing)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
    End Class
End Namespace