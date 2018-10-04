Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Public Module CommonAdmin
    Private Const MaxLength = 58

    Public Enum AdminPage As Byte
        Menu_BoxOffice = 1
        Menu_Trailer = 7
        Menu_Ticket = 8
        Menu_Master = 9
        Menu_Admin = 10
        Menu_Report = 11

        Report_MovieMarketShare = 20
        Report_GeneralIndustryMarketShare = 22

        Master_Movie = 26
        Master_Theater = 27
        Master_Distributor = 28
        Master_Studio = 37
        Master_FilmType = 45
        Master_FilmTypeAndSound = 46
        Master_Holiday = 57

        Ticket_FreeTicketAndPerCap = 47
        Ticket_FreeTicketAndPerCapByMovie = 48
        Ticket_TicketType = 49
        Ticket_TicketTypeByMovie = 50

        Report_FreeTicketAndPerCapAndTicketTypeSummary = 51

        Menu_Vpf = 52
        Menu_Vpf_ProblemRecord = 53
        Menu_Vpf_MovieDefaultSet = 54
        Menu_Vpf_ManageMovieSet = 55
        Menu_Vpf_Summary = 56

        Admin_SystemPolicies = 58
    End Enum

    <Extension()> Public Function CheckPermission(ByVal value As Page, ByVal p As AdminPage, ByVal goErrorPage As Boolean) As Boolean
        Dim permission As String = value.Session("permission")
        Dim no As Int32 = CInt(p)
        Dim pass As Boolean = False
        Try
            pass = permission.Substring(no - 1, 1)
        Catch ex As Exception
        End Try
        If Not pass AndAlso goErrorPage Then
            value.Response.Redirect("InfoPage.aspx")
        End If
        Return pass
    End Function

    <Extension()> Public Sub UpdatePermissionString(ByRef value As String, ByVal p As AdminPage, ByVal useFlag As Boolean)
        If value.Length < MaxLength Then
            value = value.PadRight(MaxLength, "0")
        End If
        Dim no As Int32 = CInt(p)
        value = value.Substring(0, no - 1) & IIf(useFlag, "1", "0") & value.Substring(no)
    End Sub

    <Extension()> Public Function CheckPermission(ByRef value As String, ByVal p As AdminPage)
        Dim permission As String = value
        Dim no As Int32 = CInt(p)
        Dim pass As Boolean = False
        Try
            pass = permission.Substring(no - 1, 1)
        Catch ex As Exception
        End Try
        Return pass
    End Function

    '--- Modified by Pachara S. (CSI) on 2017/05/19
    <Extension()> Public Function ValidateQueryString(ByVal query As String, ByVal type As Type, ByRef out As Object)
        Dim txt As String = query

        Dim regex As Regex = New Regex("<[^>]+>")
        If Not String.IsNullOrEmpty(txt) Then
            Dim match As System.Text.RegularExpressions.Match = regex.Match(txt)
            If (match.Success) Then
                Return False
                'txt = txt.Substring(0, match.Index)
            End If

            If type Is GetType(Integer) Then
                Dim num As Integer
                If (Integer.TryParse(txt, num)) Then
                    out = num
                    Return True
                End If

                Return False
            Else
                out = txt
                Return True
            End If
        End If

        Return False

    End Function

    <Extension()> Public Function ConvertTimeToLocaltime(ByVal sqlDateTime As DateTime) As Date

        Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")
        Return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(sqlDateTime, TimeZoneInfo.Local.Id, cstZone.Id)

    End Function

End Module
