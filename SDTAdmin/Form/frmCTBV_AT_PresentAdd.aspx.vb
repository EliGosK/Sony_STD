Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_AT_PresentAdd
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 39, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                lblError.Visible = False

                Dim levelId As Integer = 0

                If (Not ValidateQueryString(Request.QueryString("levelid"), GetType(Integer), levelId)) Then
                    Response.Redirect("frmCTBV_AT_Present.aspx")
                End If

                'levelId = Request.QueryString("levelid")
                ViewState("LevelID") = levelId
                ViewState("checkMode") = "ADD"
                If levelId = 0 Then

                    tblData.Visible = True
                    txtName.Text = ""
                    ddlPresent.SelectedIndex = 0
                    ddlPresent.Enabled = True
                    ddlScreen.SelectedIndex = 0
                    tblGrid.Visible = False
                Else
                    'ViewState("checkMode") = "EDIT"
                    ViewState("LevelID") = levelId

                    Dim strSQLcheck As String
                    strSQLcheck = "SELECT checker_level_id, screen_id, wage_amt "
                    strSQLcheck += " FROM tblChecker_Present_Wage "
                    strSQLcheck += " WHERE checker_level_id =" + levelId.ToString()
                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQLcheck)
                    If dataReader.Read = True Then

                        tblGrid.Visible = True
                        tblData.Visible = True
                        Dim strSQL As String
                        strSQL = "SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, "
                        strSQL += vbNewLine + " cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,"
                        strSQL += vbNewLine + " cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id"
                        strSQL += vbNewLine + " FROM tblChecker_Present_Wage cp"
                        strSQL += vbNewLine + " Left join tblChecker_Level cl"
                        strSQL += vbNewLine + " ON cp.checker_level_id = cl.checker_level_id"
                        strSQL += vbNewLine + " WHERE cl.present_level_flag = 'Y' AND cp.checker_level_id = " + ViewState("LevelID").ToString()

                        sqlPresent.SelectCommand = strSQL
                        GridView1.DataSourceID = "sqlPresent"

                        txtName.Text = ""
                        ddlPresent.SelectedValue = levelId.ToString()
                        ddlPresent.Enabled = False
                        ddlScreen.SelectedIndex = 0

                    Else
                        tblGrid.Visible = False
                        tblData.Visible = True
                        txtName.Text = ""
                        ddlPresent.SelectedValue = levelId.ToString()
                        ddlPresent.Enabled = False
                        ddlScreen.SelectedIndex = 0
                    End If
                    dataReader.Close()
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "Select" Then
                Dim index As String = e.CommandArgument 'checker_level_id
                Dim levelID As String = index.Substring(0, index.IndexOf("A"))
                Dim ScreenID As String = index.Substring(index.IndexOf("A") + 1)

                tblData.Visible = True

                lblError.Visible = False
                If levelID = "0" Or ScreenID = "0" Then
                    ViewState("checkMode") = "ADD"
                    txtName.Text = ""
                Else
                    ViewState("checkMode") = "EDIT"
                    ViewState("LevelID") = levelID
                    ViewState("ScreenID") = ScreenID

                    Dim strSQL As String
                    strSQL = "SELECT checker_level_id, screen_id, wage_amt "
                    strSQL += " FROM tblChecker_Present_Wage "
                    strSQL += " WHERE checker_level_id =" + levelID.ToString() + " AND screen_id =" + ScreenID.ToString()

                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
                    If dataReader.Read = True Then
                        txtName.Text = cDB.CheckIsNullInteger(dataReader("wage_amt")).ToString()
                        ddlScreen.SelectedValue = cDB.CheckIsNullInteger(dataReader("screen_id"))
                        ddlPresent.SelectedValue = cDB.CheckIsNullInteger(dataReader("checker_level_id"))
                        ddlScreen.Enabled = False
                        ddlPresent.Enabled = False
                    End If
                    dataReader.Close()
                End If

                'Response.Redirect("frmCTBV_AT_PresentAdd.aspx?levelid=" + levelID + "&screenid=" + ScreenID)
            ElseIf e.CommandName = "Del" Then
                Dim index As String = e.CommandArgument 'checker_level_id
                Dim levelID As String = index.Substring(0, index.IndexOf("A"))
                Dim ScreenID As String = index.Substring(index.IndexOf("A") + 1)

                Dim strSQL As String = "DELETE FROM tblChecker_Present_Wage WHERE checker_level_id = " + levelID + " AND screen_id = " + ScreenID

                Dim cDB As New cDatabase
                cDB.GetDataAll(strSQL)
                tblGrid.Visible = True
                tblData.Visible = True
                Dim strSQLrefresh As String
                strSQLrefresh = "SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, "
                strSQLrefresh += vbNewLine + " cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,"
                strSQLrefresh += vbNewLine + " cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id"
                strSQLrefresh += vbNewLine + " FROM tblChecker_Present_Wage cp"
                strSQLrefresh += vbNewLine + " Left join tblChecker_Level cl"
                strSQLrefresh += vbNewLine + " ON cp.checker_level_id = cl.checker_level_id"
                strSQLrefresh += vbNewLine + " WHERE cl.present_level_flag = 'Y' AND cp.checker_level_id = " + ViewState("LevelID").ToString()

                sqlPresent.SelectCommand = strSQLrefresh
                GridView1.DataSourceID = "sqlPresent"

                txtName.Text = ""
                ddlPresent.SelectedValue = ViewState("LevelID").ToString()
                ddlPresent.Enabled = False
                ddlScreen.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If txtName.Text.Trim() = "" Then
                lblError.Text = "Please check require flield (*)"
                lblError.Visible = True
            Else
                If ViewState("checkMode") = "ADD" Then

                    ViewState("LevelID") = ddlPresent.SelectedValue

                    Dim strSQLCheck As String
                    strSQLCheck = "SELECT checker_level_id, screen_id, wage_amt "
                    strSQLCheck += " FROM tblChecker_Present_Wage "
                    strSQLCheck += " WHERE checker_level_id = " + ddlPresent.SelectedValue + " AND screen_id = " + ddlScreen.SelectedValue

                    Dim strName As Double
                    If txtName.Text.Trim() = "" Then
                        strName = "0"
                    Else
                        strName = Convert.ToDouble(txtName.Text.Trim())
                    End If

                    Dim drCheck As IDataReader = cDB.GetDataAll(strSQLCheck)

                    If drCheck.Read = True Then
                        lblError.Text = "Present wage has exist!"
                        lblError.Visible = True
                    Else
                        cDB.addPresentWage("INSERT", Convert.ToInt32(ddlPresent.SelectedValue), Convert.ToInt32(ddlScreen.SelectedValue), _
                                            strName, Date.Now, Session("UserID"), Date.Now, Session("UserID"))
                        lblError.Visible = False
                        tblGrid.Visible = True
                        tblData.Visible = True
                        Dim strSQL As String
                        strSQL = "SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, "
                        strSQL += vbNewLine + " cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,"
                        strSQL += vbNewLine + " cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id"
                        strSQL += vbNewLine + " FROM tblChecker_Present_Wage cp"
                        strSQL += vbNewLine + " Left join tblChecker_Level cl"
                        strSQL += vbNewLine + " ON cp.checker_level_id = cl.checker_level_id"
                        strSQL += vbNewLine + " WHERE cl.present_level_flag = 'Y' AND cp.checker_level_id = " + ViewState("LevelID").ToString()

                        sqlPresent.SelectCommand = strSQL
                        GridView1.DataSourceID = "sqlPresent"

                        txtName.Text = ""
                        ddlPresent.SelectedValue = ViewState("LevelID").ToString()
                        ddlPresent.Enabled = False
                        ddlScreen.SelectedIndex = 0
                        ddlScreen.Enabled = True
                    End If
                    drCheck.Close()
                Else 'Update
                    If ViewState("LevelID").ToString() <> "0" Then
                        Dim strName As Double
                        If txtName.Text.Trim() = "" Then
                            strName = "0"
                        Else
                            strName = Convert.ToDouble(txtName.Text.Trim())
                        End If

                        cDB.addPresentWage("UPDATE", Convert.ToInt32(ddlPresent.SelectedValue), Convert.ToInt32(ddlScreen.SelectedValue), _
                                            strName, Date.Now, Session("UserID"), Date.Now, Session("UserID"))
                        lblError.Visible = False

                        tblGrid.Visible = True
                        tblData.Visible = True
                        Dim strSQL As String
                        strSQL = "SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, "
                        strSQL += vbNewLine + " cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,"
                        strSQL += vbNewLine + " cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id"
                        strSQL += vbNewLine + " FROM tblChecker_Present_Wage cp"
                        strSQL += vbNewLine + " Left join tblChecker_Level cl"
                        strSQL += vbNewLine + " ON cp.checker_level_id = cl.checker_level_id"
                        strSQL += vbNewLine + " WHERE cl.present_level_flag = 'Y' AND cp.checker_level_id = " + ViewState("LevelID").ToString()

                        sqlPresent.SelectCommand = strSQL
                        GridView1.DataSourceID = "sqlPresent"

                        txtName.Text = ""
                        ddlPresent.SelectedValue = ViewState("LevelID").ToString()
                        ddlPresent.Enabled = False
                        ddlScreen.SelectedIndex = 0
                        ddlScreen.Enabled = True
                        ViewState("checkMode") = "ADD"
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        'tblGrid.Visible = True
        'tblData.Visible = True
        'Dim strSQL As String
        'strSQL = "SELECT cp.checker_level_id, cl.checker_level_name, cp.screen_id, cp.wage_amt, "
        'strSQL += vbNewLine + " cp.create_dtm, cp.create_by, cp.last_update_dtm, cp.last_update_by,"
        'strSQL += vbNewLine + " cl.present_level_flag, convert(varchar(20), cp.checker_level_id) + 'A' + convert(varchar(20),cp.screen_id) as Present_Wage_id"
        'strSQL += vbNewLine + " FROM tblChecker_Present_Wage cp"
        'strSQL += vbNewLine + " Left join tblChecker_Level cl"
        'strSQL += vbNewLine + " ON cp.checker_level_id = cl.checker_level_id"
        'strSQL += vbNewLine + " WHERE cl.present_level_flag = 'Y' AND cp.checker_level_id = " + ViewState("LevelID").ToString()

        'sqlPresent.SelectCommand = strSQL
        'GridView1.DataSourceID = "sqlPresent"

        'txtName.Text = ""
        'ddlPresent.SelectedValue = ViewState("LevelID").ToString()
        'ddlPresent.Enabled = False
        'ddlScreen.SelectedIndex = 0
        Response.Redirect("frmCTBV_AT_Present.aspx")
    End Sub

End Class