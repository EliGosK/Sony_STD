Namespace Controls
    Partial Public Class DatePicker
        Inherits UserControl

#Region "Property"

        Public ReadOnly Property DateFormat() As String
            Get
                Return "dd/MM/yyyy"
            End Get
        End Property

        Public ReadOnly Property Text() As String
            Get
                If Not IsPostBack Then
                    Return txtDate.Text
                Else
                    txtDate.Text = Request.Form(txtDate.UniqueID)
                    Return txtDate.Text
                End If
            End Get
        End Property

        Public Property SelectedDate() As Date?
            Get
                Try
                    If Not IsPostBack Then
                        Return ConvertDate(txtDate.Text, DateFormat)
                    Else
                        txtDate.Text = Request.Form(txtDate.UniqueID)
                        Return ConvertDate(Request.Form(txtDate.UniqueID), DateFormat)
                    End If
                Catch ex As Exception
                    txtDate.Text = String.Empty
                    Return Nothing
                End Try
            End Get
            Set(ByVal value As Date?)
                txtDate.Text = String.Format("{0:" & DateFormat & "}", value)
                If DateFormat = "dd/MM/yyyy" Then
                    txtDate.Text = txtDate.Text.Replace("-", "/")
                End If
            End Set
        End Property

        Public Property TxtDateShowPopup() As Boolean
            Get
                If txtDate.Attributes("class") Is Nothing Then
                    Return False
                End If
                Return True
            End Get
            Set(ByVal value As Boolean)
                If value = True Then
                    txtDate.Attributes.Add("class", "tcal")
                Else
                    txtDate.Attributes.Remove("class")
                End If
            End Set
        End Property

        Public Property TxtDateEnable() As Boolean
            Get
                Return txtDate.Enabled
            End Get
            Set(ByVal value As Boolean)
                txtDate.Enabled = value
            End Set
        End Property

        Public Property TxtDateReadOnly() As Boolean
            Get
                Return txtDate.ReadOnly
            End Get
            Set(ByVal value As Boolean)
                txtDate.ReadOnly = value
            End Set
        End Property

        Public ReadOnly Property TxtDateClientID() As String
            Get
                Return txtDate.ClientID
            End Get
        End Property

        Public Property OnClientDateSelectionChanged() As String
            Get
                Return txtDate.Attributes("onblur")
            End Get
            Set(ByVal value As String)
                txtDate.Attributes.Add("onblur", value)
            End Set
        End Property

#End Region

#Region "Event Handlers"
        ''Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        ''    SelectedDate = Date.Now
        ''    txtDate.Text = txtDate.Text.Replace("-", "/")
        ''End Sub
#End Region

#Region "Method"

        Public Shared Function ConvertDate(ByVal dateString As String, ByVal format As String) As Date
            Try
                'Return DateTime.ParseExact(dateString, format, Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                Return DateTime.ParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture)
            Catch ex As Exception
                Throw New FormatException("Invalid date format")
            End Try
        End Function

#End Region

    End Class
End Namespace