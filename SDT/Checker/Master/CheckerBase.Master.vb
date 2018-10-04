Imports SDTCommon

Namespace Checker.Master
    Partial Public Class CheckerBase
        Inherits MasterPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            CheckLogin()

            lblTitle.Text = Page.Title
        End Sub

    End Class
End Namespace