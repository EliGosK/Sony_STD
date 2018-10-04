Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common


Public MustInherit Class Database

#Region "Variable"

    Protected m_ConnectionString As String
    Protected m_DatabaseProvider As DatabaseProvider = DatabaseProvider.SqlServer

    Protected m_DbConnection As DbConnection
    Protected m_DbTransaction As DbTransaction
    Protected m_DbCommand As DbCommand
    Protected m_DbParameter As DbParameter
    Protected m_HasTransaction As Boolean

#End Region

#Region "Property"

    Public Property ConnectionString() As String
        Get
            Return Me.m_ConnectionString
        End Get
        Set(ByVal value As String)
            Me.m_ConnectionString = value.Trim()
        End Set
    End Property

    Public ReadOnly Property ServerName() As String
        Get
            Return Me.m_DbConnection.DataSource
        End Get
    End Property

    Public ReadOnly Property DatabaseName() As String
        Get
            Return Me.m_DbConnection.Database
        End Get
    End Property

    Public ReadOnly Property Provider() As DatabaseProvider
        Get
            Return Me.m_DatabaseProvider
        End Get
    End Property

#End Region

#Region "Abstract Method"

    Public MustOverride Sub OpenConnection()
    Public MustOverride Sub CloseConnection()

    Public MustOverride Sub BeginTransaction()
    Public MustOverride Sub CommitTransaction()
    Public MustOverride Sub RollbackTransaction()

    Public MustOverride Function ExecuteNonQuery(ByVal p_DbCommand As DbCommand) As Integer
    Public MustOverride Function ExecuteReader(ByVal p_DbCommand As DbCommand) As DbDataReader
    Public MustOverride Function ExecuteScalar(ByVal p_DbCommand As DbCommand) As Object
    Public MustOverride Function ExecuteDataSet(ByVal p_DbCommand As DbCommand, ByRef p_DataSet As DataSet) As Integer
    Public MustOverride Function ExecuteDataTable(ByVal p_DbCommand As DbCommand, ByRef p_DataTable As DataTable) As Integer

    Public MustOverride Function CreateCommand() As DbCommand
    Public MustOverride Function CreateParameter(ByVal p_ParameterName As String, ByVal p_Value As Object) As DbParameter
    Public MustOverride Function CreateParameter(ByVal p_ParameterName As String, ByVal p_DbType As DbType, ByVal p_Value As Object) As DbParameter
    Public MustOverride Function CreateParameter(ByVal p_ParameterName As String, ByVal p_Direction As ParameterDirection, ByVal p_Value As Object) As DbParameter
    Public MustOverride Function CreateParameter(ByVal p_ParameterName As String, ByVal p_DbType As DbType, ByVal p_Direction As ParameterDirection, ByVal p_Value As Object) As DbParameter

#End Region

#Region "Shared Method"

    Public Shared Function NullIs(ByVal p_Value As Object, ByVal p_Replace As Object) As Object
        If IsNull(p_Value) Then
            Return p_Replace
        End If
        Return p_Value
    End Function

    Public Shared Function IsNull(ByVal p_Value As Object) As Boolean
        If p_Value Is Nothing OrElse p_Value Is DBNull.Value Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function BlankIs(ByVal p_Value As Object, ByVal p_Replace As Object) As Object
        If IsBlank(p_Value) Then
            Return p_Replace
        End If
        Return p_Value
    End Function

    Public Shared Function IsBlank(ByVal p_Value As Object) As Boolean
        Try
            If p_Value Is Nothing OrElse p_Value Is DBNull.Value OrElse p_Value.ToString().Trim().Length = 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
