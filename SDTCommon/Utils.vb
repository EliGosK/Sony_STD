Imports System.Configuration
Imports System.Globalization
Imports System.Web.UI.WebControls

Public Class Utils

#Region "Properties"
    Public Shared ReadOnly Property MainConnectionString() As String
        Get
            Dim conn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ToString()
            If conn.Length <= 0 Then
                Throw New ApplicationException("Find Not Found Connection")
            Else
                Return conn
            End If
        End Get
    End Property
#End Region

#Region "Methods"
    Public Shared Function ConvertDate(ByVal dateString As String, ByVal format As String) As Date
        Try
            'Return DateTime.ParseExact(dateString, format, Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
            Return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture)
        Catch ex As Exception
            Throw New FormatException("Invalid date format")
        End Try
    End Function
    Public Shared Function ConvertToInt32(ByVal value As Object) As Int32?
        If IsNothing(value) Then
            Return Nothing
        End If
        Try
            Return CType(value, Int32)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function If0ThenEmpty(ByVal str As String) As String
        Return CType(IIf(str = "0", String.Empty, str), String)
    End Function
    Public Shared Function ReturnNumberWithFormat(ByVal obj As Object, ByVal isInt As Boolean) As String
        If isInt Then
            Try
                Return CInt(obj).ToString("#,##0")
            Catch ex As Exception
                Return "0"
            End Try
        Else
            Try
                Return CDbl(obj).ToString("#,##0.00")
            Catch ex As Exception
                Return "0.00"
            End Try
        End If
    End Function
    Public Shared Sub SortGridView(ByVal grd As GridView, ByVal dtb As DataTable, ByVal sortExpression As String, ByVal direction As SortDirection)
        Dim dv As New DataView(dtb)
        If direction = SortDirection.Ascending Then
            dv.Sort = sortExpression + " ASC"
        Else
            dv.Sort = sortExpression + " DESC"
        End If
        grd.DataSource = dv
        grd.DataBind()
    End Sub
#End Region

End Class