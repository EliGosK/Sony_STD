Imports SDTCommon

Namespace Checker.Master
    Partial Public Class CheckerTransaction
        Inherits MasterPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            CheckLogin()

            If Not (Request.UrlReferrer) Is Nothing Then
                GetRequest(ParamList.MovieName, Request.UrlReferrer.AbsolutePath)
            Else
                GetRequest(ParamList.MovieName, "ActionMenu.aspx")
            End If

            lblTitle.Text = Page.Title
        End Sub

    End Class
End Namespace