Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_AT_LevelAdd
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 38, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                lblError.Visible = False

                Dim levelId As Integer
                If (Not ValidateQueryString(Request.QueryString("levelid"), GetType(Integer), levelId)) Then
                    Response.Redirect("frmCTBV_AT_Level.aspx")
                End If
                'levelId = Request.QueryString("levelid")

                If levelId = 0 Then
                    ViewState("checkMode") = "ADD"
                    trLevelID.Visible = False
                    chkPresent.Checked = True
                    chkFormat.Checked = True
                Else
                    ViewState("checkMode") = "EDIT"
                    ViewState("LevelID") = levelId
                    trLevelID.Visible = True
                    txtLevelID.Text = levelId.ToString()
                    Dim strSQL As String
                    strSQL = "SELECT checker_level_name, present_level_flag, former_level_flag "
                    strSQL += " FROM tblChecker_Level WHERE checker_level_id = " + levelId.ToString()

                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
                    If dataReader.Read = True Then
                        txtName.Text = cDB.CheckIsNullString(dataReader("checker_level_name"))
                        Dim strpresent_level_flag As String = cDB.CheckIsNullString(dataReader("present_level_flag"))
                        If strpresent_level_flag = "Y" Then
                            chkPresent.Checked = True
                        Else
                            chkPresent.Checked = False
                        End If

                        Dim strformer_level_flag As String = cDB.CheckIsNullString(dataReader("former_level_flag"))
                        If strformer_level_flag = "Y" Then
                            chkFormat.Checked = True
                        Else
                            chkFormat.Checked = False
                        End If
                    End If
                    dataReader.Close()
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try

    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If txtName.Text.Trim() = "" Then
                lblError.Text = "Please check require flield (*)"
                lblError.Visible = True
            Else
                Dim strName As String = txtName.Text.Trim()
                Dim strPresent As String
                If chkPresent.Checked Then
                    strPresent = "Y"
                Else
                    strPresent = "N"
                End If

                Dim strFomat As String
                If chkFormat.Checked Then
                    strFomat = "Y"
                Else
                    strFomat = "N"
                End If

                If ViewState("checkMode") = "ADD" Then
                    Dim strSQLCheck As String
                    strSQLCheck = "SELECT checker_level_id, present_level_flag, former_level_flag "
                    strSQLCheck += " FROM tblChecker_Level WHERE checker_level_name = '" + strName + "'"
                    Dim drCheck As IDataReader = cDB.GetDataAll(strSQLCheck)

                    Dim idSave As Integer
                    If txtLevelID.Text.Trim() = "" Then
                        idSave = 0
                    Else
                        idSave = Convert.ToInt32(txtLevelID.Text.Trim())
                    End If

                    If drCheck.Read = True Then
                        lblError.Text = "Level Name has exist!"
                        lblError.Visible = True
                    Else
                        cDB.addCheckerLevel("INSERT", idSave, strName, strPresent, strFomat, _
                                                                    Date.Now, Session("UserID"), Date.Now, Session("UserID"))
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_AT_Level.aspx")
                    End If
                    drCheck.Close()
                Else 'Update
                    If ViewState("LevelID") <> 0 Then
                        cDB.addCheckerLevel("UPDATE", ViewState("LevelID"), strName, strPresent, strFomat, _
                                            Date.Now, Session("UserID"), Date.Now, Session("UserID"))
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_AT_Level.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_AT_Level.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class