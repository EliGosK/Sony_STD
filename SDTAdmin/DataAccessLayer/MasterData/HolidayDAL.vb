Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Data.Common

Public Class HolidayDAL
    Private m_Database As Database

    Public Sub New(ByVal database As Database)
        m_Database = database
    End Sub

    Public Function SelectData(ByVal p_holiday_id As Integer?, ByVal p_holiday_date As Date?, ByVal p_holiday_name As String) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        Dim strCommand As String = ""
        strCommand += "SELECT holiday_id "
        strCommand += "    , holiday_date "
        strCommand += "    , holiday_name "
        strCommand += "    , create_by "
        strCommand += "    , create_date "
        strCommand += "    , update_by "
        strCommand += "    , update_date "
        strCommand += "FROM tblHoliday "
        strCommand += "WHERE (holiday_id = @p_holiday_id OR @p_holiday_id IS NULL) "
        strCommand += "    AND (holiday_date = @p_holiday_date OR @p_holiday_date IS NULL) "
        strCommand += "    AND (holiday_name = @p_holiday_name OR @p_holiday_name IS NULL) "
        strCommand += "ORDER BY holiday_date "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_id", p_holiday_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_date", p_holiday_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_name", p_holiday_name))

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function InsertData(ByVal p_holiday_date As Date, ByVal p_holiday_name As String, ByVal p_create_by As String) As Integer
        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

        Dim strCommand As String = ""
        strCommand += "INSERT INTO tblHoliday (holiday_date, holiday_name, create_by, create_date, update_by, update_date) "
        strCommand += "VALUES (@p_holiday_date, @p_holiday_name, @p_create_by, @cvDate, @p_create_by, @cvDate) "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_date", p_holiday_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_name", p_holiday_name))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615
        cmd.Parameters.Add(m_Database.CreateParameter("@p_create_by", p_create_by))

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function UpdateData(ByVal p_holiday_id As Integer, ByVal p_holiday_date As Date, ByVal p_holiday_name As String, ByVal p_update_by As String) As Integer
        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()
        Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

        Dim strCommand As String = ""
        strCommand += "UPDATE tblHoliday "
        strCommand += "SET holiday_date = @p_holiday_date, holiday_name = @p_holiday_name, update_by = @p_update_by, update_date = @cvDate "
        strCommand += "WHERE holiday_id = @p_holiday_id "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_id", p_holiday_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_date", p_holiday_date))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_name", p_holiday_name))
        cmd.Parameters.Add(m_Database.CreateParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow)))   'ConvertTimeZone By Pachara S. on 20170615
        cmd.Parameters.Add(m_Database.CreateParameter("@p_update_by", p_update_by))

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function DeleteData(ByVal p_holiday_id As Integer) As Integer
        Dim result As Integer = 0
        Dim cmd As DbCommand = m_Database.CreateCommand()

        Dim strCommand As String = ""
        strCommand += "DELETE FROM tblHoliday "
        strCommand += "WHERE holiday_id = @p_holiday_id "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_id", p_holiday_id))

        result = m_Database.ExecuteNonQuery(cmd)

        Return result
    End Function

    Public Function SearchData(ByVal p_year As Integer?, ByVal p_month As Integer?) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        Dim strCommand As String = ""
        strCommand += "SELECT holiday_id "
        strCommand += "    , holiday_date "
        strCommand += "    , holiday_name "
        strCommand += "    , create_by "
        strCommand += "    , create_date "
        strCommand += "    , update_by "
        strCommand += "    , update_date "
        strCommand += "FROM tblHoliday "
        strCommand += "WHERE (YEAR(holiday_date) = @p_year OR @p_year IS NULL) "
        strCommand += "    AND (MONTH(holiday_date) = @p_month OR @p_month IS NULL) "
        strCommand += "ORDER BY holiday_date "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_year", p_year))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_month", p_month))

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function SelectDuplicateAddData(ByVal p_holiday_date As Date) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        Dim strCommand As String = ""
        strCommand += "SELECT * "
        strCommand += "FROM tblHoliday "
        strCommand += "WHERE (holiday_date = @p_holiday_date) "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_date", p_holiday_date))

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

    Public Function SelectDuplicateUpdateData(ByVal p_holiday_id As Integer, ByVal p_holiday_date As Date) As DataTable
        Dim dt As DataTable = New DataTable()
        Dim cmd As DbCommand = m_Database.CreateCommand()

        Dim strCommand As String = ""
        strCommand += "SELECT * "
        strCommand += "FROM tblHoliday "
        strCommand += "WHERE (holiday_id <> @p_holiday_id) "
        strCommand += "    AND (holiday_date = @p_holiday_date) "

        cmd.CommandType = CommandType.Text
        cmd.CommandText = strCommand
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_id", p_holiday_id))
        cmd.Parameters.Add(m_Database.CreateParameter("@p_holiday_date", p_holiday_date))

        m_Database.ExecuteDataTable(cmd, dt)

        Return dt
    End Function

End Class
