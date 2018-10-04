Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text

Namespace Extensions

    Public Module CheckerExtensions
        <Extension()> Public Function GetHidenData(ByVal value As Page) As String
            Dim obj As Control = value.Master.FindControl("hdfTempData")
            If Not IsNothing(obj) Then
                Dim hdf As HiddenField = CType(obj, HiddenField)
                Return hdf.Value
            End If
            Return String.Empty
        End Function
        <Extension()> Public Function ToDataString(ByVal value As DataTable) As String
            Dim result As New StringBuilder()
            Dim list As New List(Of String)
            For i As Integer = 0 To value.Columns.Count - 1
                list.Add(value.Columns(i).ColumnName)
            Next
            result.Append(ListToDataRecord(list))
            For Each dr As DataRow In value.Rows
                list = New List(Of String)
                For i As Integer = 0 To value.Columns.Count - 1
                    list.Add(dr(i).ToString())
                Next
                result.Append(ListToDataRecord(list))
            Next
            Return result.ToString()
        End Function
        <Extension()> Public Function ToDataString(ByVal value As DataTable, ByVal ParamArray columnNames() As String) As String
            Dim result As New StringBuilder()
            Dim colNo As New List(Of Int32)
            'Order By columnNames
            For Each str As String In columnNames
                For i As Integer = 0 To value.Columns.Count - 1
                    If str = value.Columns(i).ColumnName Then
                        colNo.Add(i)
                        Exit For
                    End If
                Next
            Next

            Dim list As New List(Of String)
            'Order By columnNames
            For Each i As Int32 In colNo
                list.Add(value.Columns(i).ColumnName)
            Next
            result.Append(ListToDataRecord(list))

            For Each dr As DataRow In value.Rows
                list = New List(Of String)
                'Order By columnNames
                For Each i As Int32 In colNo
                    list.Add(dr(i).ToString())
                Next
                result.Append(ListToDataRecord(list))
            Next
            Return result.ToString()
        End Function

        <Extension()> Public Sub SetHidenData(ByVal value As Page, ByVal data As String)
            Dim obj As Control = value.Master.FindControl("hdfTempData")
            If Not IsNothing(obj) Then
                Dim hdf As HiddenField = CType(obj, HiddenField)
                hdf.Value = data
            End If
        End Sub

#Region "Private Methods"
        Private Function ListToDataRecord(ByVal strList As IEnumerable(Of String)) As String
            Dim result As New StringBuilder()
            For Each s As Object In strList
                result.Append("," & s.ToString().Replace("'", """").Replace(",", "%2C").Replace(";", "%3B"))
            Next
            result.Append(Uri.EscapeUriString((";")))
            Return result.ToString().Substring(1)
        End Function
#End Region

    End Module
End Namespace