Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Web.Security

Namespace DBInterface
    Public Class User
        Public Shared Function SelectActiveChecker() As DataTable
            Dim sql As String = My.Resources.User.SelectActiveChecker
            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Function SelectCheckerWage(ByVal userId As Int32, ByVal dateFrom As Date, ByVal dateTo As Date) As DataSet
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@userId", userId))
            paramList.Add(New SqlParameter("@dateFrom", dateFrom))
            paramList.Add(New SqlParameter("@dateTo", dateTo))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_CalculateCheckerWage", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds
        End Function

        Public Shared Function SelectData(ByVal userId As String) As DataTable
            Dim sql As String = My.Resources.User.SelectUser
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@user_id", userId))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub UpdatePassword(ByVal userId As String, ByVal encrypted As String)
            '@user_id
            ', @user_password
            Dim sql As String = My.Resources.User.UpdatePassword
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@user_id", userId))
            paramList.Add(New SqlParameter("@user_password", encrypted))
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.Text, sql, paramList.ToArray())
        End Sub

        Public Shared Function LoginAndUpdatePassword(ByVal userId As String, ByVal password As String) As DataRow
            Try
                'If password.Length > 7 Then
                '    password = password.Substring(0, 7)
                'End If
                'Dim dtb As DataTable = SelectData(userId)
                'If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                '    Return Nothing
                'Else
                '    Dim dr As DataRow = dtb.Rows(0)
                '    If dr("user_status").ToString() = "Enabled" Then
                '        Dim passwordFromDb = dr("user_password").ToString()
                '        Dim encrypt = Crypto.Encrypt(password)
                '        Dim oldCase = passwordFromDb = password
                '        If encrypt = passwordFromDb OrElse oldCase Then
                '            If oldCase Then
                '                UpdatePassword(userId, encrypt)
                '            End If
                '            Return dr
                '        End If
                '    End If
                'End If
                Dim dtb As DataTable = SelectData(userId)

                If IsNothing(dtb) OrElse dtb.Rows.Count = 0 Then
                    Return Nothing
                Else
                    Dim dr As DataRow = dtb.Rows(0)
                    If dr("user_status").ToString() = "Enabled" Then
                        Dim passwordFromDb = dr("user_password").ToString()
                        Dim encrypt = Crypto.Encrypt(password)
                        Dim oldCase = passwordFromDb = password
                        If encrypt = passwordFromDb OrElse oldCase Then
                            If oldCase Then
                                UpdatePassword(userId, encrypt)
                            End If
                            Return dr
                        Else
                            'threshold+1
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
            Return Nothing
        End Function

        Public Shared Sub Logout()
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectToLoginPage()
        End Sub

        Public Shared Function SelectUserTheater(ByVal userId As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@p_user_id", userId))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_User_SelectUserTheater", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Sub UpdateUserTheater(ByVal userId As String, ByVal theaterId As Integer, ByVal statusFlag As Boolean, ByVal createBy As String)
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@p_user_id", userId))
            paramList.Add(New SqlParameter("@p_theater_id", theaterId))
            paramList.Add(New SqlParameter("@p_status_flag", statusFlag))
            paramList.Add(New SqlParameter("@p_create_by", createBy))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_User_UpdateUserTheater", paramList.ToArray())
        End Sub

        Public Shared Function SelectKey() As DataRow
            Dim sql As String = My.Resources.User.SelectKey

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0).Rows(0)
        End Function

        '------------Added on 13/07/2015 P1 (get PWDHistory)
        Public Shared Function CheckPWHist(ByVal user_id As String, ByVal password As String) As DataSet
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@password", password))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "spChkPWDUniqueHistory", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds
        End Function
        '------------Added on 13/07/2015 (insert to PWDHistory)
        Public Shared Sub addPWDUniqueHistory _
    ( _
            ByVal user_id As String, _
            ByVal user_password As String, _
            ByVal create_by As String _
     )
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_insertPWDUniqueHistory", user_id, user_password, create_by)
        End Sub
        '------------Added on 14/07/2015 (insert user_errlogincount)
        Public Shared Sub checkLockUser(ByVal user_id As String)
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            paramList.Add(New SqlParameter("@userID", user_id))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.StoredProcedure, "spChkLockUser", paramList.ToArray())
        End Sub
        '------------Added on 14/07/2015 (insert user_logindate)
        Public Shared Sub addLoginDate(ByVal user_id As String, ByVal cvDate As DateTime)
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_addLoginDate", user_id, cvDate)
        End Sub
        '------------Added on 14/07/2015 (insert user_logoutdate)
        Public Shared Sub addLogoutDate(ByVal user_id As String)
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_addLogoutDate", user_id)
        End Sub
        '------------Added on 14/07/2015 (get password length)
        Public Shared Function GetPWLength(ByVal userType As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(Utils.MainConnectionString, "spGetPasswordLength", userType), IDataReader)
        End Function
        '------------Added on 14/07/2015 (get password hint)
        Public Shared Function GetPWHint(ByVal userType As String) As IDataReader
            Return CType(SqlHelper.ExecuteReader(Utils.MainConnectionString, "spGetPasswordHint", userType), IDataReader)
        End Function
        '------------Added on 14/07/2015 (insert log into tblLoginLogs)
        Public Shared Sub addLoginLog(ByVal user_id As String, ByVal login_type As String, ByVal result As Integer, ByVal reason_type As String, ByVal client_type As String, ByVal client_ip As String)
            If reason_type <> "null" And client_type <> "null" Then
                SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "spInsertLoginLog", user_id, login_type, result, reason_type, client_type, client_ip)
            End If
            If reason_type <> "null" And client_type = "null" Then
                SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "spInsertLoginLog", user_id, login_type, result, reason_type, DBNull.Value, client_ip)
            End If
            If reason_type = "null" And client_type <> "null" Then
                SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "spInsertLoginLog", user_id, login_type, result, DBNull.Value, client_type, client_ip)
            End If
            If reason_type = "null" And client_type = "null" Then
                SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "spInsertLoginLog", user_id, login_type, result, DBNull.Value, DBNull.Value, client_ip)
            End If
        End Sub
        '------------Added on 15/07/2015 (reset threshold after login success)
        Public Shared Sub resetThreshold(ByVal user_id As String)
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_resetThreshold", paramList.ToArray())

        End Sub
        '------------Added on 15/07/2015 (add error login count when password is incorrect)
        Public Shared Sub addErrLoginCount(ByVal user_id As String)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            Dim cvDate As DateTime = ConvertTimeToLocaltime(saveDatetimeNow)
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_addErrLoginCount", user_id, cvDate) 'ConvertTimeZone By Pachara S. on 20170615
        End Sub
        '------------Added on 15/07/2015 (add password_createdate)
        Public Shared Sub addPWDCreateDate(ByVal user_id As String, ByVal cvDate As DateTime)
            SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_addPWDCreateDate", user_id, cvDate)
        End Sub
        '------------Added on 15/07/2015 (Logout and add log)
        'Public Shared Sub LogoutandLog(ByVal user_id As String, ByVal strIPAddress As String, ByVal strHostName As String)
        '    SqlHelper.ExecuteNonQuery(Utils.MainConnectionString, "sp_addLogoutDate", user_id)
        '    addLoginLog(user_id, "OUT", 1, "null", strIPAddress, strHostName)
        '    FormsAuthentication.SignOut()
        '    FormsAuthentication.RedirectToLoginPage()
        'End Sub
        '------------Added on 15/07/2015 (check if error login count = threshold)
        Public Shared Function chkErrLoginCount(ByVal user_id As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_chkErrLoginCount", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        '------------Added on 15/07/2015 (check expire password)
        Public Shared Function chkPWDExpire(ByVal user_id As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_chkPWDExpire", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        '------------Added on 16/07/2015 (rewrite check user_id version)
        Public Shared Function chkUser_id(ByVal user_id As String, ByVal strIPAddress As String, ByVal strHostName As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@IPAdress", strIPAddress))
            paramList.Add(New SqlParameter("@Hostname", strHostName))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_chkUser_id", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        '------------Added on 16/07/2015 (rewrite check password version)
        Public Shared Function chkPassword(ByVal user_id As String, ByVal strIPAddress As String, ByVal type As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@IPAdress", strIPAddress))
            paramList.Add(New SqlParameter("@client_type", type))
            paramList.Add(New SqlParameter("@cvDate", ConvertTimeToLocaltime(saveDatetimeNow))) 'ConvertTimeZone By Pachara S. on 20170615

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_chkPassword", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Function chkPWDValidateWord(ByVal user_id As String, ByVal password As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@user_id", user_id))
            paramList.Add(New SqlParameter("@password", password))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_chkPWDValidateWord", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Function getPWDHistory(ByVal user_id As String) As DataTable
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@user_id", user_id))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.StoredProcedure, "sp_getPWDHistory", paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        Public Shared Function getWarningMSG(ByVal ConfType As String, ByVal ConfName As String) As DataTable
            Dim sql As String = "select ConfType, ConfName, ConfValue1 from tblPWDConf where ConfType='" + ConfType + "' and ConfName='" + ConfName + "'"

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        'add 25/11/2016
        Public Shared Function CheckMovieID(ByVal MovieID As String) As DataTable
            Dim sql As String = "SELECT movie_id FROM tblMovie WHERE movie_id=" + MovieID

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            ElseIf ds.Tables(0).Rows.Count < 1 Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        'Public Shared Function CheckMovieName(ByVal MovieName As String) As DataTable
        '    If MovieName.Contains("'") Then
        '        MovieName = Replace(MovieName, "'", "''")
        '    End If
        '    Dim strMovieName As String() = MovieName.Split(New Char() {"/"c})
        '    Dim sql As String = "SELECT movie_id FROM tblMovie WHERE movie_nameth='" + strMovieName(0) + "' or movie_nameen='" + strMovieName(0) + "'"

        '    Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
        '    If IsNothing(ds) Then
        '        Return Nothing
        '    ElseIf ds.Tables(0).Rows.Count < 1 Then
        '        Return Nothing
        '    End If
        '    Return ds.Tables(0)
        'End Function
        Public Shared Function CheckMovieTypeID(ByVal MovieTypeID As String) As DataTable
            Dim sql As String = "SELECT movie_id FROM tblMovie WHERE movietype_id=" + MovieTypeID

            Dim ds As DataSet = SqlHelper.ExecuteDataset(Utils.MainConnectionString, CommandType.Text, sql)
            If IsNothing(ds) Then
                Return Nothing
            ElseIf ds.Tables(0).Rows.Count < 1 Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function
        'end add
    End Class
End Namespace