Imports System.Runtime.CompilerServices
Imports System.Web.UI.WebControls

Namespace Extensions

    Public Module CommonExtensions
        <Extension()> Public Function GetDouble(ByVal value As TextBox) As Double
            Try
                Return CDbl(value.Text)
            Catch ex As Exception
                Return 0
            End Try
        End Function
        <Extension()> Public Function GetInt32(ByVal value As TextBox) As Int32
            Try
                Return CInt(value.Text)
            Catch ex As Exception
                Return 0
            End Try
        End Function
        <Extension()> Public Function GetDouble(ByVal value As Label) As Double
            Try
                Return CDbl(value.Text)
            Catch ex As Exception
                Return 0
            End Try
        End Function
        <Extension()> Public Function GetInt32(ByVal value As Label) As Int32
            Try
                Return CInt(value.Text)
            Catch ex As Exception
                Return 0
            End Try
        End Function
        <Extension()> Public Function ToDateTime(ByVal value As String, ByVal format As String) As DateTime
            Try
                Return DateTime.ParseExact(value, format, Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function ToInt32(ByVal value As String) As Int32?
            Try
                Return CType(value, Int32)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Module

End Namespace