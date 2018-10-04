Imports Web.Data
Imports System.Web.Security

Partial Public Class frmCTBV_MMD_DistributorAdd
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Mid(Session("permission"), 9, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If
            If Not IsPostBack Then
                lblError.Visible = False

                Dim distId As Integer
                If (Not ValidateQueryString(Request.QueryString("distId"), GetType(Integer), distId)) Then
                    Response.Redirect("frmCTBV_MMD_Disdistributor.aspx")
                End If

                If distId = 0 Then
                    ViewState("checkMode") = "ADD"
                    trDistID.Visible = False
                    chkStatus.Checked = True
                Else
                    ViewState("checkMode") = "EDIT"
                    ViewState("DistID") = distId
                    trDistID.Visible = True
                    txtMovieID.Text = distId.ToString()
                    Dim strSQL As String
                    strSQL = "SELECT distributor_name, active_flag "
                    strSQL += " FROM tblDistributor WHERE distributor_id = " + distId.ToString()

                    Dim dataReader As IDataReader = cDB.GetDataAll(strSQL)
                    If dataReader.Read = True Then
                        txtName.Text = cDB.CheckIsNullString(dataReader("distributor_name"))
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
                    strSQLCheck = "SELECT distributor_id, active_flag "
                    strSQLCheck += " FROM tblDistributor WHERE distributor_name = '" + strName + "'"
                    Dim drCheck As IDataReader = cDB.GetDataAll(strSQLCheck)
                    If drCheck.Read = True Then
                        lblError.Text = "Distributor Name has exist!"
                        lblError.Visible = True
                    Else
                        Dim intMaxID As Integer
                        Dim strSQLAdd As String
                        Dim drMaxID As IDataReader = cDB.GetDataAll("SELECT max(distributor_id) as MaxId from tblDistributor")
                        If drMaxID.Read Then
                            intMaxID = drMaxID("MaxId")
                            intMaxID = intMaxID + 1
                        Else
                            intMaxID = 1
                        End If
                        drMaxID.Close()
                        strSQLAdd = "INSERT INTO tblDistributor (distributor_id, distributor_name, distributor_code, active_flag) "
                        strSQLAdd += "VALUES (" + intMaxID.ToString() + ", '" + strName + "', '', '" + strStatus + "')"
                        cDB.GetDataAll(strSQLAdd)
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_Disdistributor.aspx")
                    End If
                    drCheck.Close()
                Else 'Update
                    If ViewState("DistID") <> 0 Then
                        Dim strSQLEdit As String
                        strSQLEdit = "UPDATE tblDistributor SET distributor_name =  '" + strName + "', active_flag = '" + strStatus + "' "
                        strSQLEdit += "WHERE distributor_id =" + ViewState("DistID").ToString()
                        cDB.GetDataAll(strSQLEdit)
                        lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_Disdistributor.aspx")
                    End If
                End If
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_Disdistributor.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class