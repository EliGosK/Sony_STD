Imports Web.Data
Imports System.Web.Security
Partial Public Class frmCTBV_AT_Former
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 40, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                GridView1.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
    '    Try

    '        Dim row As GridViewRow = GridView1.SelectedRow

    '        Dim levelID As String = GridView1.SelectedValue 'checker_level_id
    '        Dim ScreenID As String = row.Cells(2).Text
    '        Dim strSQL As String = "DELETE FROM tblChecker_Former_Wage WHERE checker_level_id = " + levelID + " AND screen_id = " + ScreenID

    '        Dim cDB As New cDatabase
    '        cDB.GetDataAll(strSQL)
    '        GridView1.DataBind()
    '    Catch ex As Exception
    '        Dim strError As String = ex.Message
    '    End Try
    'End Sub

    'Sub btnDelete_OnClick()
    '    Try

    '        Dim row As GridViewRow = GridView1.SelectedRow

    '        Dim levelID As String = GridView1.SelectedValue 'checker_level_id
    '        Dim ScreenID As String = row.Cells(2).Text
    '        Dim strSQL As String = "DELETE FROM tblChecker_Former_Wage WHERE checker_level_id = " + levelID + " AND screen_id = " + ScreenID

    '        Dim cDB As New cDatabase
    '        cDB.GetDataAll(strSQL)
    '        GridView1.DataBind()
    '    Catch ex As Exception
    '        Dim strError As String = ex.Message
    '    End Try
    'End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    Try
    '        If e.CommandName = "Select" Then
    '            Dim index As String = e.CommandArgument 'checker_level_id
    '            Dim levelID As String = index.Substring(0, index.IndexOf("A"))
    '            Dim ScreenID As String = index.Substring(index.IndexOf("A") + 1)

    '            tblData.Visible = True

    '            lblError.Visible = False
    '            If levelID = "0" Or ScreenID = "0" Then
    '                ViewState("checkMode") = "ADD"
    '                txtName.Text = ""
    '            Else
    '                ViewState("checkMode") = "EDIT"
    '                ViewState("LevelID") = levelID
    '                ViewState("ScreenID") = ScreenID

    '                Dim strSQL As String
    '                strSQL = "SELECT checker_level_id, screen_id, wage_amt "
    '                strSQL += " FROM tblChecker_Former_Wage "
    '                strSQL += " WHERE checker_level_id =" + levelID.ToString() + " AND screen_id =" + ScreenID.ToString()

    '                Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
    '                If dataReader.Read = True Then
    '                    txtName.Text = cDB.CheckIsNullInteger(dataReader("wage_amt")).ToString()
    '                    ddlScreen.SelectedValue = cDB.CheckIsNullInteger(dataReader("screen_id"))
    '                    ddlFormer.SelectedValue = cDB.CheckIsNullInteger(dataReader("checker_level_id"))
    '                End If
    '                dataReader.Close()
    '            End If


    '            'Response.Redirect("frmCTBV_AT_FormerAdd.aspx?levelid=" + levelID + "&screenid=" + ScreenID)
    '        ElseIf e.CommandName = "Del" Then
    '            Dim index As String = e.CommandArgument 'checker_level_id
    '            Dim levelID As String = index.Substring(0, index.IndexOf("A"))
    '            Dim ScreenID As String = index.Substring(index.IndexOf("A") + 1)

    '            Dim strSQL As String = "DELETE FROM tblChecker_Former_Wage WHERE checker_level_id = " + levelID + " AND screen_id = " + ScreenID

    '            Dim cDB As New cDatabase
    '            cDB.GetDataAll(strSQL)
    '            GridView1.DataBind()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
    '    Try
    '        If txtName.Text.Trim() = "" Then
    '            lblError.Text = "Please check require flield (*)"
    '            lblError.Visible = True
    '        Else

    '            If ViewState("checkMode") = "ADD" Then
    '                Dim strSQLCheck As String
    '                strSQLCheck = "SELECT checker_level_id, screen_id, wage_amt "
    '                strSQLCheck += " FROM tblChecker_Former_Wage "
    '                strSQLCheck += " WHERE checker_level_id = " + ddlFormer.SelectedValue + " AND screen_id = " + ddlScreen.SelectedValue

    '                Dim strName As Double
    '                If txtName.Text.Trim() = "" Then
    '                    strName = "0"
    '                Else
    '                    strName = Convert.ToDouble(txtName.Text.Trim())
    '                End If

    '                Dim drCheck As IDataReader = cDB.GetDataAll(strSQLCheck)

    '                If drCheck.Read = True Then
    '                    lblError.Text = "Former wage has exist!"
    '                    lblError.Visible = True
    '                Else
    '                    cDB.addFormerWage("INSERT", Convert.ToInt32(ddlFormer.SelectedValue), Convert.ToInt32(ddlScreen.SelectedValue), _
    '                                        strName, Date.Now, Session("UserID"), Date.Now, Session("UserID"))
    '                    lblError.Visible = False
    '                    tblData.Visible = False
    '                    GridView1.DataBind()
    '                End If
    '                drCheck.Close()
    '            Else 'Update
    '                If ViewState("LevelID") <> 0 Then
    '                    Dim strName As Double
    '                    If txtName.Text.Trim() = "" Then
    '                        strName = "0"
    '                    Else
    '                        strName = Convert.ToDouble(txtName.Text.Trim())
    '                    End If

    '                    cDB.addFormerWage("UPDATE", Convert.ToInt32(ddlFormer.SelectedValue), Convert.ToInt32(ddlScreen.SelectedValue), _
    '                                        strName, Date.Now, Session("UserID"), Date.Now, Session("UserID"))
    '                    lblError.Visible = False

    '                    tblData.Visible = False
    '                    GridView1.DataBind()
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        lblError.Visible = True
    '        lblError.Text = ex.Message
    '    End Try
    'End Sub

    'Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
    '    tblData.Visible = False
    'End Sub

    'Protected Sub imbNew_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNew.Click
    '    Try
    '        tblData.Visible = True
    '        txtName.Text = ""
    '        ddlFormer.SelectedIndex = 0
    '        ddlScreen.SelectedIndex = 0
    '    Catch ex As Exception

    '    End Try

    'End Sub
End Class