Imports Web.Data

Partial Public Class frmCTBV_MMD_FilmTypeAdd
    Inherits System.Web.UI.Page

    Dim m_Database As Database
    Dim m_FilmTypeDAL As FilmTypeDAL

    Private Class FilmTypeColumn
        Public Const film_type_id As String = "film_type_id"
        Public Const film_type_name As String = "film_type_name"
        Public Const film_type_name_th As String = "film_type_name_th"
        Public Const film_type_header_group As String = "film_type_header_group"
        Public Const status_flag As String = "status_flag"
    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ''If Mid(Session("permission"), 45, 1) = "0" Then
            ''    Response.Redirect("InfoPage.aspx")
            ''End If

            If Not IsPostBack Then
                m_Database = MainApp.Database
                m_FilmTypeDAL = New FilmTypeDAL(m_Database)

                Me.lblError.Visible = False

                Dim intFilmTypeId As Integer
                If (Not ValidateQueryString(Request.QueryString("FilmTypeId"), GetType(Integer), intFilmTypeId)) Then
                    Response.Redirect("frmCTBV_MMD_FilmType.aspx")
                End If

                'intFilmTypeId = Request.QueryString("FilmTypeId")
                If intFilmTypeId = 0 Then
                    ViewState("ScreenMode") = "ADD"
                    Me.trFilmTypeID.Visible = False
                    Me.chkStatus.Checked = True
                Else
                    ViewState("ScreenMode") = "EDIT"
                    ViewState("FilmTypeId") = intFilmTypeId
                    Me.trFilmTypeID.Visible = False

                    Dim dtLoad As DataTable = m_FilmTypeDAL.Load(intFilmTypeId)

                    If dtLoad.Rows.Count > 0 Then
                        Me.txtFilmTypeID.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeColumn.film_type_id), "")
                        Me.txtFilmTypeName.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeColumn.film_type_name), "")
                        Me.txtFilmTypeNameTH.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeColumn.film_type_name_th), "")
                        Me.txtFilmTypeHeaderGroup.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeColumn.film_type_header_group), "")
                        Me.chkStatus.Checked = Database.NullIs(dtLoad.Rows(0)(FilmTypeColumn.status_flag), "")
                    End If
                End If
            End If
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            If Me.txtFilmTypeName.Text.Trim() = "" OrElse Me.txtFilmTypeNameTH.Text.Trim() = "" Then
                Me.lblError.Text = "Please check require flield (*)"
                Me.lblError.Visible = True
            Else
                m_Database = MainApp.Database
                m_FilmTypeDAL = New FilmTypeDAL(m_Database)

                Dim strFilmTypeID As Integer = Database.BlankIs(ViewState("FilmTypeId"), 0)
                Dim strFilmTypeName As String = Database.BlankIs(Me.txtFilmTypeName.Text.Trim(), Nothing)
                Dim strFilmTypeNameTH As String = Database.BlankIs(Me.txtFilmTypeNameTH.Text.Trim(), Nothing)
                Dim strFilmTypeHeaderGroup As String = Database.BlankIs(Me.txtFilmTypeHeaderGroup.Text.Trim(), Nothing)
                Dim strStatusFlag As Boolean = Me.chkStatus.Checked
                Dim strUserId As String = Database.BlankIs(Session("UserID"), Nothing)

                If ViewState("ScreenMode") = "ADD" Then
                    Dim dtLoadDupNameAdd As DataTable = m_FilmTypeDAL.LoadDuplicateNameAdd(strFilmTypeName, strFilmTypeNameTH)

                    If dtLoadDupNameAdd.Rows.Count > 0 Then
                        Me.lblError.Text = "Film Type Name has exist!"
                        Me.lblError.Visible = True
                    Else
                        m_FilmTypeDAL.Add(strFilmTypeName, strFilmTypeNameTH, strFilmTypeHeaderGroup, strStatusFlag, strUserId)
                        Me.lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_FilmType.aspx")
                    End If
                Else 'Update
                    If ViewState("FilmTypeId") <> 0 Then
                        Dim dtLoadDupNameEdit As DataTable = m_FilmTypeDAL.LoadDuplicateNameEdit(strFilmTypeID, strFilmTypeName, strFilmTypeNameTH)

                        If dtLoadDupNameEdit.Rows.Count > 0 Then
                            Me.lblError.Text = "Film Type Name has exist!"
                            Me.lblError.Visible = True
                        Else
                            m_FilmTypeDAL.Edit(strFilmTypeID, strFilmTypeName, strFilmTypeNameTH, strFilmTypeHeaderGroup, strStatusFlag, strUserId)
                            Me.lblError.Visible = False
                            Response.Redirect("frmCTBV_MMD_FilmType.aspx")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_FilmType.aspx")
    End Sub
End Class