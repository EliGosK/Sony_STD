Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient


Public Class SqlDatabase
    Inherits Database

#Region "Constructor"

    Public Sub New(ByVal p_ConnectionString As String)
        MyBase.m_ConnectionString = p_ConnectionString
        MyBase.m_DatabaseProvider = DatabaseProvider.SqlServer
        MyBase.m_DbConnection = New SqlConnection(p_ConnectionString)
        MyBase.m_DbTransaction = Nothing
    End Sub

#End Region

#Region "Override"

    Public Overrides Sub OpenConnection()
        If MyBase.m_DbConnection Is Nothing Then
            MyBase.m_DbConnection = New SqlConnection(m_ConnectionString)
        End If

        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If
    End Sub

    Public Overrides Sub CloseConnection()
        If MyBase.m_HasTransaction Then
            MyBase.m_DbTransaction.Rollback()
            MyBase.m_DbTransaction.Dispose()
        End If

        If m_DbConnection IsNot Nothing Then
            If MyBase.m_DbConnection.State <> ConnectionState.Closed Then
                MyBase.m_DbConnection.Close()
            End If
        End If
    End Sub

    Public Overrides Sub BeginTransaction()
        If MyBase.m_HasTransaction Then
            Throw New Exception("The current transaction has not been successfully ""Commit"" or ""Rollback""")
        End If

        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        MyBase.m_DbTransaction = MyBase.m_DbConnection.BeginTransaction()
        MyBase.m_HasTransaction = True
    End Sub

    Public Overrides Sub CommitTransaction()
        If Not MyBase.m_HasTransaction Then
            Throw New Exception("There is no opened transaction.")
        End If

        MyBase.m_DbTransaction.Commit()
        MyBase.m_HasTransaction = False
    End Sub

    Public Overrides Sub RollbackTransaction()
        If Not MyBase.m_HasTransaction Then
            Throw New Exception("There is no opened transaction.")
        End If

        MyBase.m_DbTransaction.Rollback()
        MyBase.m_HasTransaction = False
    End Sub

    Public Overrides Function ExecuteNonQuery(ByVal p_DbCommand As DbCommand) As Integer
        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        Dim command As SqlCommand = DirectCast(p_DbCommand, SqlCommand)
        Dim result As Integer = command.ExecuteNonQuery()

        Return result
    End Function

    Public Overrides Function ExecuteReader(ByVal p_DbCommand As DbCommand) As DbDataReader
        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        Dim command As SqlCommand = DirectCast(p_DbCommand, SqlCommand)
        Dim result As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

        Return result
    End Function

    Public Overrides Function ExecuteScalar(ByVal p_DbCommand As DbCommand) As Object
        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        Dim command As SqlCommand = DirectCast(p_DbCommand, SqlCommand)
        Dim result As Object = command.ExecuteScalar()

        Return result
    End Function

    Public Overrides Function ExecuteDataSet(ByVal p_DbCommand As DbCommand, ByRef p_DataSet As DataSet) As Integer
        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        Dim command As SqlCommand = DirectCast(p_DbCommand, SqlCommand)
        Dim adapter As New SqlDataAdapter(command)
        Dim result As Integer = adapter.Fill(p_DataSet)

        Return result
    End Function

    Public Overrides Function ExecuteDataTable(ByVal p_DbCommand As DbCommand, ByRef p_DataTable As DataTable) As Integer
        If MyBase.m_DbConnection.State = ConnectionState.Closed Then
            MyBase.m_DbConnection.Open()
        End If

        Dim command As SqlCommand = DirectCast(p_DbCommand, SqlCommand)
        Dim adapter As New SqlDataAdapter(command)
        Dim result As Integer = adapter.Fill(p_DataTable)

        Return result
    End Function

    Public Overrides Function CreateCommand() As DbCommand
        ''Dim command As SqlCommand = New SqlCommand()
        Dim command As SqlCommand = DirectCast(MyBase.m_DbConnection.CreateCommand(), SqlCommand)

        If MyBase.m_DbTransaction IsNot Nothing Then
            command.Transaction = DirectCast(MyBase.m_DbTransaction, SqlTransaction)
        End If
        command.Connection = DirectCast(MyBase.m_DbConnection, SqlConnection)

        MyBase.m_DbCommand = command

        Return command
    End Function

    Public Overrides Function CreateParameter(ByVal p_ParameterName As String, ByVal p_Value As Object) As DbParameter
        Dim param As SqlParameter = DirectCast(MyBase.m_DbCommand.CreateParameter(), SqlParameter)
        ''Dim param As SqlParameter = New SqlParameter()

        param.ParameterName = p_ParameterName
        param.Value = Database.NullIs(p_Value, DBNull.Value)

        MyBase.m_DbParameter = param

        Return param
    End Function

    Public Overrides Function CreateParameter(ByVal p_ParameterName As String, ByVal p_DbType As DbType, ByVal p_Value As Object) As DbParameter
        ''Dim param As SqlParameter = DirectCast(MyBase.m_DbCommand.CreateParameter(), SqlParameter)
        Dim param As SqlParameter = New SqlParameter()

        param.ParameterName = p_ParameterName
        param.SqlDbType = CType(p_DbType, SqlDbType)
        param.Value = Database.NullIs(p_Value, DBNull.Value)

        MyBase.m_DbParameter = param

        Return param
    End Function

    Public Overrides Function CreateParameter(ByVal p_ParameterName As String, ByVal p_Direction As ParameterDirection, ByVal p_Value As Object) As DbParameter
        ''Dim param As SqlParameter = DirectCast(MyBase.m_DbCommand.CreateParameter(), SqlParameter)
        Dim param As SqlParameter = New SqlParameter()

        param.ParameterName = p_ParameterName
        param.Direction = p_Direction
        param.Value = Database.NullIs(p_Value, DBNull.Value)

        MyBase.m_DbParameter = param

        Return param
    End Function

    Public Overrides Function CreateParameter(ByVal p_ParameterName As String, ByVal p_DbType As DbType, ByVal p_Direction As ParameterDirection, ByVal p_Value As Object) As DbParameter
        ''Dim param As SqlParameter = DirectCast(MyBase.m_DbCommand.CreateParameter(), SqlParameter)
        Dim param As SqlParameter = New SqlParameter()

        param.ParameterName = p_ParameterName
        param.SqlDbType = CType(p_DbType, SqlDbType)
        param.Direction = p_Direction
        param.Value = Database.NullIs(p_Value, DBNull.Value)

        MyBase.m_DbParameter = param

        Return param
    End Function

#End Region

End Class
