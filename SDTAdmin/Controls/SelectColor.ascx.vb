Public Partial Class SelectColor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not (Page.IsPostBack)) Then
            color2.Attributes("onfocus") = Me.ClientID.ToString() + "pick2.focus();"
        End If
    End Sub


    Private _ColorCode As String

    Public Property ColorCode() As String
        Get
            Return color2.Text
        End Get
        Set(ByVal value As String)
            _ColorCode = value
            color2.Text = value
        End Set
    End Property

End Class