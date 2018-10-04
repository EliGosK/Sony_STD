Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Configuration

Public Class MainApp

    Public Shared ReadOnly Property Database() As Database
        Get
            Dim strConnectionString As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
            Return New SqlDatabase(strConnectionString)
        End Get
    End Property

End Class
