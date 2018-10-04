Imports System.Runtime.CompilerServices
Imports System.Web.UI

Namespace Extensions

    Public Module SessionExtensions
        <Extension()> Public Sub SetUserId(ByVal value As Page, ByVal inputValue As String)
            value.Session("UserID") = inputValue
        End Sub
        <Extension()> Public Function GetUserId(ByVal value As Page) As String
            Try
                Return CStr(value.Session("UserID"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetUserId(ByVal value As MasterPage) As String
            Try
                Return value.Page.GetUserId()
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Sub SetUserRole(ByVal value As Page, ByVal inputValue As String)
            value.Session("UserRole") = inputValue
        End Sub
        <Extension()> Public Function GetUserRole(ByVal value As Page) As String
            Try
                Return CStr(value.Session("UserRole"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Sub SetCircuitId(ByVal value As Page, ByVal inputValue As Int32)
            value.Session("CircuitId") = inputValue
        End Sub
        <Extension()> Public Function GetCircuitId(ByVal value As Page) As Int32
            Try
                Return Utils.ConvertToInt32(value.Session("CircuitId")).Value
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetCircuitId(ByVal value As UserControl) As Int32
            Return Utils.ConvertToInt32(value.Session("CircuitId")).Value
        End Function
        <Extension()> Public Sub SetCircuitName(ByVal value As Page, ByVal inputValue As String)
            value.Session("CircuitName") = inputValue
        End Sub
        <Extension()> Public Function GetCircuitName(ByVal value As Page) As String
            Try
                Return CStr(value.Session("CircuitName"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetCircuitName(ByVal value As UserControl) As String
            Return CStr(value.Session("CircuitName"))
        End Function
        <Extension()> Public Sub SetTheaterId(ByVal value As Page, ByVal inputValue As Int32)
            value.Session("TheaterId") = inputValue
        End Sub
        <Extension()> Public Function GetTheaterId(ByVal value As Page) As Int32
            Try
                Return Utils.ConvertToInt32(value.Session("TheaterId")).Value
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetTheaterId(ByVal value As UserControl) As Int32
            Return Utils.ConvertToInt32(value.Session("TheaterId")).Value
        End Function
        <Extension()> Public Sub SetTheaterName(ByVal value As Page, ByVal inputValue As String)
            value.Session("TheaterName") = inputValue
        End Sub
        <Extension()> Public Function GetTheaterName(ByVal value As Page) As String
            Try
                Return CStr(value.Session("TheaterName"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetTheaterName(ByVal value As UserControl) As String
            Return CStr(value.Session("TheaterName"))
        End Function
        <Extension()> Public Sub SetWorkingDate(ByVal value As Page, ByVal inputValue As Date)
            value.Session("SysDate") = inputValue.ToString("yyyyMMdd")
        End Sub
        <Extension()> Public Function GetWorkingDate_yyyyMMdd(ByVal value As Page) As String
            Try
                Return CStr(value.Session("SysDate"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetWorkingDate(ByVal value As Page) As Date
            Try
                Return CStr(value.Session("SysDate")).ToDateTime("yyyyMMdd")
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Sub SetDisplayDate(ByVal value As Page, ByVal inputValue As String)
            value.Session("UserDate") = inputValue
        End Sub
        <Extension()> Public Function GetDisplayDate(ByVal value As Page) As String
            Try
                Return CStr(value.Session("UserDate"))
            Catch ex As Exception
                value.Redirect(PageName.LogIn)
                Return Nothing
            End Try
        End Function
        <Extension()> Public Function GetDisplayDate(ByVal value As UserControl) As String
            Return CStr(value.Session("UserDate"))
        End Function

    End Module
End Namespace