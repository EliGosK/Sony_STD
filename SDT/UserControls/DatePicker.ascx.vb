Imports SDTCommon.Utils

Namespace UserControls
    Partial Public Class DatePicker
        Inherits UserControl

#Region "Property"

        Public ReadOnly Property Text() As String
            Get
                Return Request.Form(txtDate.UniqueID)
            End Get
        End Property

        Public ReadOnly Property DateFormat() As String
            Get
                Return "dd/MM/yyyy"
            End Get
        End Property

        Public Property SelectedDate() As Date?
            Get
                Try
                    Return ConvertDate(Request.Form(txtDate.UniqueID), DateFormat)
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

#End Region

        '#Region "Event Handlers"
        '        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        '            SelectedDate = Date.Now
        '            txtDate.Text = txtDate.Text.Replace("-", "/")
        '        End Sub
        '#End Region

    End Class
End Namespace