Imports System.Data.SqlClient
Partial Public Class frmCTBV_MMD_TheaterSub_Del
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tblTheaterSubDel As Integer = CInt(Request.QueryString("tblTheaterSubId"))
        'Dim strconn As String = ConfigurationSettings.AppSettings("CnnString")
        Dim strconn As String = ConfigurationManager.ConnectionStrings("SDTConnectionString").ConnectionString
        Dim sqlcon As New SqlConnection(strconn)
        sqlcon.Open()
        Dim sql As String
        sql = "delete from tblTheaterSub where TheaterSub_id = " & tblTheaterSubDel & " and theater_Id = " & Session("theaterId")
        Dim com As New SqlCommand(sql, sqlcon)
        com.ExecuteNonQuery()
        sqlcon.Close()
        Response.Redirect("frmCTBV_MMD_Theater_Edit.aspx?theaterId=" & Session("theaterId"))
    End Sub

End Class