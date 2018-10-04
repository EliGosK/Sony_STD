Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common

Public Class TheaterDAL
    Private m_Database As Database

    Public Sub New(ByVal database As Database)
        m_Database = database
    End Sub

    Public Function Load() As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_Load]"

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function Load(ByVal p_theater_id As Integer?) As DataTable
        Dim result As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_Load]"
        cmd.Parameters.Add(Me.m_Database.CreateParameter("@p_theater_id", p_theater_id))

        m_Database.ExecuteDataTable(cmd, result)

        Return result
    End Function

    Public Function Add(ByVal p_theater_code As String, _
        ByVal p_theater_name As String, _
        ByVal p_theater_des As String, _
        ByVal p_theater_status As String, _
        ByVal p_user_id As String, _
        ByVal p_circuit_id As String, _
        ByVal p_remark As String, _
        ByVal p_open_date As Date?, _
        ByVal p_close_date As Date?, _
        ByVal p_group_type As String, _
        ByRef p_theater_id As Integer) As Integer

        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_Add]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_code", p_theater_code))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_name", p_theater_name))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_des", p_theater_des))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_status", p_theater_status))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_user_id", p_user_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_circuit_id", p_circuit_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_remark", p_remark))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_open_date", p_open_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_close_date", p_close_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_group_type", p_group_type))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_id", ParameterDirection.Output, p_theater_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

        result = m_Database.ExecuteNonQuery(cmd)

        p_theater_id = cmd.Parameters("@p_theater_id").Value

        Return result
    End Function

    Public Function Edit(ByVal p_theater_id As Integer, _
        ByVal p_theater_code As String, _
        ByVal p_theater_name As String, _
        ByVal p_theater_des As String, _
        ByVal p_theater_status As String, _
        ByVal p_user_id As String, _
        ByVal p_circuit_id As String, _
        ByVal p_remark As String, _
        ByVal p_open_date As Date?, _
        ByVal p_close_date As Date?, _
        ByVal p_group_type As String) As Integer

        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_Edit]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_id", p_theater_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_code", p_theater_code))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_name", p_theater_name))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_des", p_theater_des))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_status", p_theater_status))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_user_id", p_user_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_circuit_id", p_circuit_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_remark", p_remark))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_open_date", p_open_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_close_date", p_close_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_group_type", p_group_type))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function LoadTheaterFilmType(ByVal p_theater_id As Integer?) As DataTable
        Dim result As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_LoadTheaterFilmType]"
        cmd.Parameters.Add(Me.m_Database.CreateParameter("@p_theater_id", p_theater_id))

        m_Database.ExecuteDataTable(cmd, result)

        Return result
    End Function

    Public Function EditTheaterFilmType(ByVal p_theater_id As Integer, ByVal p_film_type_id As Integer, ByVal p_status_flag As Boolean, ByVal p_update_by As String) As Integer
        Dim result As Integer
        Dim cmd As DbCommand = m_Database.CreateCommand()
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_Theater_EditTheaterFilmType]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_theater_id", p_theater_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_id", p_film_type_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_status_flag", p_status_flag))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_update_by", p_update_by))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

End Class
