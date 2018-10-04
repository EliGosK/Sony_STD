Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class Message
        Public Shared Function SelectFirstQuestionByTheater(ByVal theaterId As Int32) As DataTable
            '@theater_id
            Dim sql As String = My.Resources.Message.SelectFirstQuestion
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        Public Shared Sub UpdateAnswer(ByVal theaterId As Int32, ByVal answerNo As Int32, ByVal answerDesc As String, ByVal userId As String)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            SqlHelper.ExecuteNonQuery(MainConnectionString, "spTblMessageAnswerUpdate", 1, theaterId, answerNo, answerDesc, "Y", ConvertTimeToLocaltime(saveDatetimeNow), userId)
        End Sub
    End Class
End Namespace