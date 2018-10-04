Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common

Public Class FilmTypeSoundDAL

    Private m_Database As Database

    Public Sub New(ByVal database As Database)
        m_Database = database
    End Sub

    Public Function Load() As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_Load]"

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function Load(ByVal p_film_type_sound_id As Integer?) As DataTable
        Dim result As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_Load]"
        cmd.Parameters.Add(Me.m_Database.CreateParameter("@p_film_type_sound_id", p_film_type_sound_id))

        m_Database.ExecuteDataTable(cmd, result)

        Return result
    End Function

    Public Function LoadInfomation() As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_LoadInfomation]"

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function Add(ByVal p_film_type_id As Integer _
        , ByVal p_film_type_sound_name_th As String _
        , ByVal p_film_type_sound_header_group As String _
        , ByVal p_sound_header_group As String _
        , ByVal p_spirit_world_export_id As Integer? _
        , ByVal p_status_flag As Boolean _
        , ByVal p_create_by As String) As Integer

        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_Add]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_id", p_film_type_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_name_th", p_film_type_sound_name_th))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_header_group", p_film_type_sound_header_group))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_sound_header_group", p_sound_header_group))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_spirit_world_export_id", p_spirit_world_export_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_status_flag", p_status_flag))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
        cmd.Parameters.Add(m_Database.CreateParameter("@p_create_by", p_create_by))

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function Edit(ByVal p_film_type_sound_id As Integer _
        , ByVal p_film_type_id As Integer _
        , ByVal p_film_type_sound_name_th As String _
        , ByVal p_film_type_sound_header_group As String _
        , ByVal p_sound_header_group As String _
        , ByVal p_spirit_world_export_id As Integer? _
        , ByVal p_status_flag As Boolean _
        , ByVal p_update_by As String) As Integer

        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
        Dim result As Integer
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_Edit]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_id", p_film_type_sound_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_id", p_film_type_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_name_th", p_film_type_sound_name_th))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_header_group", p_film_type_sound_header_group))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_sound_header_group", p_sound_header_group))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_spirit_world_export_id", p_spirit_world_export_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_status_flag", p_status_flag))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
        cmd.Parameters.Add(m_Database.CreateParameter("@p_update_by", p_update_by))

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function LoadDuplicateNameAdd(ByVal p_film_type_sound_name_th As String) As DataTable
        Dim result As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_LoadDuplicateNameAdd]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_name_th", p_film_type_sound_name_th))

        m_Database.ExecuteDataTable(cmd, result)

        Return result
    End Function

    Public Function LoadDuplicateNameEdit(ByVal p_film_type_sound_id As Integer, ByVal p_film_type_sound_name_th As String) As DataTable
        Dim result As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_LoadDuplicateNameEdit]"
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_id", p_film_type_sound_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_film_type_sound_name_th", p_film_type_sound_name_th))

        m_Database.ExecuteDataTable(cmd, result)

        Return result
    End Function

    Public Function LoadFilmTypeComboBoxAdd() As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_LoadFilmTypeComboBoxAdd]"

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function LoadFilmTypeComboBoxEdit(ByVal p_film_type_id As Integer) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "[dbo].[sp_FilmTypeSound_LoadFilmTypeComboBoxEdit]"
        cmd.Parameters.Add(Me.m_Database.CreateParameter("@p_film_type_id", p_film_type_id))

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

End Class
