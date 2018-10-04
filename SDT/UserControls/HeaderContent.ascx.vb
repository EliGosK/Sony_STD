Imports SDTCommon.Extensions

Namespace UserControls

    Partial Public Class HeaderContent
        Inherits UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            lblCircuit.Text = GetCircuitName()
            lblTheater.Text = GetTheaterName()
            lblDate.Text = GetDisplayDate()
        End Sub

    End Class
End Namespace