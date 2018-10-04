Imports SDTCommon

Namespace Checker
    Partial Public Class [Default]
        Inherits Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Redirect(PageName.LogIn)
        End Sub

    End Class
End Namespace
