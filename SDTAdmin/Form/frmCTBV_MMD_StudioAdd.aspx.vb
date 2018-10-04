Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_MMD_StudioAdd
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 9, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                lblError.Visible = False
                Dim StudioId As Integer

                If (Not ValidateQueryString(Request.QueryString("StudioId"), GetType(Integer), StudioId)) Then
                    Response.Redirect("frmCTBV_MMD_Studio.aspx")
                End If

                If StudioId = 0 Then
                    ViewState("checkMode") = "ADD"
                    trStudioID.Visible = False
                    chkStatus.Checked = True
                Else
                    ViewState("checkMode") = "EDIT"
                    ViewState("StudioID") = StudioId
                    trStudioID.Visible = True
                    txtMovieID.Text = StudioId.ToString()
                    Dim strSQL As String
                    strSQL = "SELECT Studio_name, active_flag "
                    strSQL += " FROM tblStudio WHERE Studio_id = " + StudioId.ToString()

                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
                    If dataReader.Read = True Then
                        txtName.Text = cDB.CheckIsNullString(dataReader("Studio_name"))
                        Dim strActive As String = cDB.CheckIsNullString(dataReader("active_flag"))
                        If strActive = "Y" Then
                            chkStatus.Checked = True
                        Else
                            chkStatus.Checked = False
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
                Dim strStatus As String
                If chkStatus.Checked Then
                    strStatus = "Y"
                Else
                    strStatus = "N"
                End If

                If ViewState("checkMode") = "ADD" Then
                    Dim strSQLCheck As String
                    strSQLCheck = "SELECT Studio_id, active_flag "
                    strSQLCheck += " FROM tblStudio WHERE Studio_name = '" + strName + "'"
                    Dim drCheck As IDataReader = cDB.GetDataAll(strSQLCheck)
                    If drCheck.Read = True Then
                        lblError.Text = "Studio Name has exist!"
                        lblError.Visible = True
                    Else
                        Dim intMaxID As Integer
                        Dim strSQLAdd As String
                        Dim drMaxID As IDataReader = cDB.GetDataAll("SELECT max(Studio_id) as MaxId from tblStudio")
                        If drMaxID.Read Then
                            intMaxID = drMaxID("MaxId")
                            intMaxID = intMaxID + 1
                        Else
                            intMaxID = 1
                        End If
                        drMaxID.Close()
                        strSQLAdd = "INSERT INTO tblStudio (Studio_id, Studio_name, Studio_code, active_flag) "
                        strSQLAdd += "VALUES (" + intMaxID.ToString() + ", '" + strName + "', '', '" + strStatus + "')"
                        cDB.GetDataAll(strSQLAdd)
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_Studio.aspx")
                    End If
                    drCheck.Close()
                Else 'Update
                    If ViewState("StudioID") <> 0 Then
                        Dim strSQLEdit As String
                        strSQLEdit = "UPDATE tblStudio SET Studio_name =  '" + strName + "', active_flag = '" + strStatus + "' "
                        strSQLEdit += "WHERE Studio_id =" + ViewState("StudioID").ToString()
                        cDB.GetDataAll(strSQLEdit)
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_Studio.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_Studio.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class