Imports System.Runtime.CompilerServices
Imports System.Web.UI
Imports System.Web
Imports SDTCommon.Extensions
Imports System.Text.RegularExpressions

Public Module CommonChecker

    Public Enum PageName As Byte
        LogIn = 0
        PreCondition = 1
        ActionMenu = 2
        SystemMessage = 3
        MovieList = 4
        RemainMovieList = 5

        ConfirmMovieRelease = 6
        ConfirmMovieTerminate = 7

        Trailer = 8
        TrailerCollection = 9
        TrailerCollectionInsert = 10

        SendRevenue = 11
        SendFreeTicketAndPerCap = 12
        SendTicketType = 13

        ProblemRecord = 14
        '--- Added on 09/07/2015 P1 ---'
        ChangePassword = 15
        '--- Ended on 09/07/2015 ---'
    End Enum
    Public Enum ParamList As Byte
        SendFrom
        MovieId
        MovieTypeId
        MovieName
        RevenueId
        RevenueCompHeaderId
    End Enum

#Region "Methods"
    Public Function GetParamName(ByVal paramName As ParamList) As String
        Dim arr() As String = paramName.ToString().Split("."(0))
        Return arr(arr.Length - 1)
    End Function
    <Extension()> Public Function GetParamString(ByVal value As Page, ByVal sendFrom As PageName, ByVal movieName As String, ByVal movieId As Int32?, ByVal movieTypeId As Int32?, ByVal revenueId As Int32?, ByVal revenueCompHeaderId As Int32?) As String
        Dim str As String = "?" & GetParamName(ParamList.SendFrom) & "=" & CInt(sendFrom)
        If Not String.IsNullOrEmpty(movieName) Then
            str &= "&" & GetParamName(ParamList.MovieName) & "=" & HttpUtility.UrlEncode(movieName)
        End If
        If Not IsNothing(movieId) AndAlso movieId <> 0 Then
            str &= "&" & GetParamName(ParamList.MovieId) & "=" & movieId.ToString()
        End If
        If Not IsNothing(movieTypeId) AndAlso movieTypeId <> 0 Then
            str &= "&" & GetParamName(ParamList.MovieTypeId) & "=" & movieTypeId.ToString()
        End If
        If Not IsNothing(revenueId) AndAlso revenueId <> 0 Then
            str &= "&" & GetParamName(ParamList.RevenueId) & "=" & revenueId.ToString()
        End If
        If Not IsNothing(revenueCompHeaderId) AndAlso revenueCompHeaderId <> 0 Then
            str &= "&" & GetParamName(ParamList.RevenueCompHeaderId) & "=" & revenueCompHeaderId.ToString()
        End If
        Return str
    End Function
    <Extension()> Public Function GetRedirectUrl(ByVal value As Page, ByVal page As PageName, ByVal param As String) As String
        Dim retVal As String = "NothingResult.htm"

        Select Case page
            Case PageName.LogIn
                retVal = "LogIn.aspx"
            Case PageName.PreCondition
                retVal = "PreCondition.aspx"
            Case PageName.ActionMenu
                retVal = "ActionMenu.aspx"
            Case PageName.SystemMessage
                retVal = "SystemMessage.aspx"
            Case PageName.MovieList
                retVal = "MovieList.aspx"
            Case PageName.RemainMovieList
                retVal = "RemainMovieList.aspx"

            Case PageName.ConfirmMovieRelease
                retVal = "ConfirmMovieRelease.aspx"
            Case PageName.ConfirmMovieTerminate
                retVal = "ConfirmMovieTerminate.aspx"

            Case PageName.Trailer
                retVal = "Trailer.aspx"
            Case PageName.TrailerCollection
                retVal = "TrailerCollection.aspx"
            Case PageName.TrailerCollectionInsert
                retVal = "TrailerCollectionInsert.aspx"

            Case PageName.SendRevenue
                retVal = "SendRevenue.aspx"
            Case PageName.SendFreeTicketAndPerCap
                retVal = "SendFreeTicketAndPerCap.aspx"
            Case PageName.SendTicketType
                retVal = "SendTicketType.aspx"

            Case PageName.ProblemRecord
                retVal = "ProblemRecord.aspx"

                '--- Added on 09/07/2015 P1 ---'
            Case PageName.ChangePassword
                retVal = "ChangePassword.aspx"
                '--- Ended on 09/07/2015 ---'
        End Select

        Return retVal & param
    End Function
    <Extension()> Public Function GetRedirectUrl(ByVal value As MasterPage, ByVal page As PageName) As String
        Return value.Page.GetRedirectUrl(page, String.Empty)
    End Function
    <Extension()> Public Function GetRedirectUrl(ByVal value As Page, ByVal page As PageName) As String
        Return value.GetRedirectUrl(page, String.Empty)
    End Function
    'add 25/11/2016
    Private Function GetMovieIDFromRequest(ByVal MovieID As String) As String
        Dim dtMovieID As DataTable = DBInterface.User.CheckMovieID(MovieID)
        If dtMovieID.Rows.Count = 0 Then
            Return ""
        Else
            Return MovieID
        End If
    End Function
    'Private Function GetMovieNameFromRequest(ByVal MovieName As String) As String
    '    Dim dtMovieName As DataTable = DBInterface.User.CheckMovieName(MovieName)
    '    If dtMovieName.Rows.Count = 0 Then
    '        Return ""
    '    Else
    '        Return MovieName
    '    End If
    'End Function
    Private Function GetMovieTypeIDFromRequest(ByVal MovieTypeID As String) As String
        Dim dtMovieTypeID As DataTable = DBInterface.User.CheckMovieTypeID(MovieTypeID)
        If dtMovieTypeID.Rows.Count = 0 Then
            Return ""
        Else
            Return MovieTypeID
        End If
    End Function
    'edit 25/11/2016
    '<Extension()> Public Function GetRequest(ByVal value As Page, ByVal paramName As ParamList, ByVal ifErrorGoto As String) As String
    '    Dim strValue As String = value.Request.QueryString(GetParamName(paramName))
    '    If String.IsNullOrEmpty(strValue) Then
    '        If Not String.IsNullOrEmpty(ifErrorGoto) Then
    '            value.Response.Redirect(ifErrorGoto)
    '        End If
    '    End If
    '    Return strValue
    'End Function
    <Extension()> Public Function GetRequest(ByVal value As Page, ByVal paramName As ParamList, ByVal ifErrorGoto As String) As String
        Dim strValue As String = ""
        If paramName = ParamList.MovieId Then
            strValue = GetMovieIDFromRequest(value.Request.QueryString(GetParamName(paramName)))
        ElseIf paramName = ParamList.MovieName Then
            'strValue = GetMovieNameFromRequest(value.Request.QueryString(GetParamName(paramName)))
            strValue = value.Request.QueryString(GetParamName(paramName))
        ElseIf paramName = ParamList.MovieTypeId Then
            strValue = GetMovieTypeIDFromRequest(value.Request.QueryString(GetParamName(paramName)))
        ElseIf paramName = ParamList.RevenueCompHeaderId Then
            strValue = value.Request.QueryString(GetParamName(paramName))
        ElseIf paramName = ParamList.RevenueId Then
            strValue = value.Request.QueryString(GetParamName(paramName))
        ElseIf paramName = ParamList.SendFrom Then
            strValue = value.Request.QueryString(GetParamName(paramName))
        End If

        'If String.IsNullOrEmpty(strValue) Then
        '    If Not String.IsNullOrEmpty(ifErrorGoto) Then
        '        value.Response.Redirect(ifErrorGoto)
        '    End If
        'End If

        If Not String.IsNullOrEmpty(strValue) Then
            If (Not ValidateQueryString(strValue, GetType(String))) Then
                If Not String.IsNullOrEmpty(ifErrorGoto) Then
                    value.Response.Redirect(ifErrorGoto)
                End If
            End If
        End If

        Return strValue
    End Function
    <Extension()> Public Function GetRequest(ByVal value As MasterPage, ByVal paramName As ParamList) As String
        Return value.Page.GetRequest(paramName, Nothing)
    End Function
    <Extension()> Public Function GetRequest(ByVal value As MasterPage, ByVal paramName As ParamList, ByVal ifErrorGoto As String) As String
        Return value.Page.GetRequest(paramName, ifErrorGoto)
    End Function
    <Extension()> Public Function GetRequest(ByVal value As Page, ByVal paramName As ParamList) As String
        Return value.GetRequest(paramName, Nothing)
    End Function
    <Extension()> Public Sub CheckLogin(ByVal value As Page)
        Dim user = value.GetUserId()
        If IsNothing(user) OrElse String.IsNullOrEmpty(user) Then
            value.Redirect(PageName.LogIn)
        End If
    End Sub
    <Extension()> Public Sub CheckLogin(ByVal value As MasterPage)
        If Not value.Page.AppRelativeVirtualPath.EndsWith(value.GetRedirectUrl(PageName.LogIn)) Then
            value.Page.CheckLogin()
        End If
    End Sub
    <Extension()> Public Sub Redirect(ByVal value As Page, ByVal page As PageName, ByVal param As String)
        value.Response.Redirect(value.GetRedirectUrl(page, param))
    End Sub
    <Extension()> Public Sub Redirect(ByVal value As MasterPage, ByVal page As PageName)
        value.Page.Redirect(page, String.Empty)
    End Sub
    <Extension()> Public Sub Redirect(ByVal value As Page, ByVal page As PageName)
        value.Redirect(page, String.Empty)
    End Sub
    <Extension()> Public Sub RedirectPrevious(ByVal value As Page, ByVal currentPage As PageName)
        Dim fromPage As PageName = CType(value.GetRequest(ParamList.SendFrom), PageName)

        Dim movieId As Int32 = CType(value.GetRequest(ParamList.MovieId), Int32)
        Dim movieTypeId As Int32 = CType(value.GetRequest(ParamList.MovieTypeId), Int32)
        Dim movieName As String = value.GetRequest(ParamList.MovieName)

        Dim param As String = value.GetParamString(currentPage, movieName, movieId, movieTypeId, Nothing, Nothing)

        value.Redirect(fromPage, param)
    End Sub
    <Extension()> Public Sub RedirectCurrentPage(ByVal value As Page, ByVal currentPage As PageName, ByVal sendRevenue As Boolean)
        Dim fromPage As PageName = CType(value.GetRequest(ParamList.SendFrom), PageName)

        Dim movieId As Int32 = CType(value.GetRequest(ParamList.MovieId), Int32)
        Dim movieTypeId As Int32 = CType(value.GetRequest(ParamList.MovieTypeId), Int32)
        Dim movieName As String = value.GetRequest(ParamList.MovieName)
        Dim revenueId As Int32 = CType(value.GetRequest(ParamList.RevenueId), Int32)
        Dim revenueCompHeaderId As Int32 = CType(value.GetRequest(ParamList.RevenueCompHeaderId), Int32)

        Dim param As String = value.GetParamString(fromPage, movieName, movieId, movieTypeId, CType(IIf(sendRevenue, revenueId, Nothing), Int32?), revenueCompHeaderId)

        value.Redirect(currentPage, param)
    End Sub

    '--- Modified by Pachara S. (CSI) on 2017/05/23
    <Extension()> Public Function ValidateQueryString(ByVal query As String, ByVal type As Type) As Boolean
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
                    Return True
                End If

                Return False
            Else
                Return True
            End If
        End If

        Return False

    End Function

    <Extension()> Public Function ConvertTimeToLocaltime(ByVal sqlDateTime As DateTime) As Date
        Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time")
        Return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(sqlDateTime, TimeZoneInfo.Local.Id, cstZone.Id)

    End Function

#End Region

End Module
