Public Partial Class frmCTBV_MMD_FilmTypeSoundAdd
    Inherits System.Web.UI.Page

    Private m_Database As Database
    Private m_FilmTypeSoundDAL As FilmTypeSoundDAL

    Private Class FilmTypeSoundColumn
        Public Const film_type_sound_id As String = "film_type_sound_id"
        Public Const film_type_id As String = "film_type_id"
        Public Const film_type_sound_name_th As String = "film_type_sound_name_th"
        Public Const film_type_sound_header_group As String = "film_type_sound_header_group"
        Public Const sound_header_group As String = "sound_header_group"
        Public Const spirit_world_export_id As String = "spirit_world_export_id"
        Public Const status_flag As String = "status_flag"
    End Class

#Region "Event"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ''If Mid(Session("permission"), 47, 1) = "0" Then
            ''    Response.Redirect("InfoPage.aspx")
            ''End If

            If Not IsPostBack Then
                m_Database = MainApp.Database
                m_FilmTypeSoundDAL = New FilmTypeSoundDAL(m_Database)

                'Dim intFilmTypeSoundId As Integer = Request.QueryString("FilmTypeSoundId")
                Dim intFilmTypeSoundId As Integer
                If (Not ValidateQueryString(Request.QueryString("FilmTypeSoundId"), GetType(Integer), intFilmTypeSoundId)) Then
                    Response.Redirect("frmCTBV_MMD_FilmTypeSound.aspx")
                End If

                If intFilmTypeSoundId = 0 Then
                    ViewState("ScreenMode") = "ADD"
                    Me.trSoundID.Visible = False
                    Me.chkStatus.Checked = True
                    LoadComboBoxADD()
                Else
                    ViewState("ScreenMode") = "EDIT"
                    ViewState("FilmTypeSoundId") = intFilmTypeSoundId
                    Me.trSoundID.Visible = False

                    Dim dtLoad As DataTable = m_FilmTypeSoundDAL.Load(intFilmTypeSoundId)
                    If dtLoad.Rows.Count > 0 Then
                        Dim intFilmTypeId As Integer = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.film_type_id), "")
                        LoadComboBoxEDIT(intFilmTypeId)
                        Me.txtFilmTypeSoundID.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.film_type_sound_id), "")
                        Me.txtFilmTypeSoundNameTH.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.film_type_sound_name_th), "")
                        Me.txtFilmTypeSoundHeaderGroup.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.film_type_sound_header_group), "")
                        Me.txtSoundHeaderGroup.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.sound_header_group), "")
                        Me.txtSpiritWorldExportID.Text = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.spirit_world_export_id), "")
                        Me.chkStatus.Checked = Database.NullIs(dtLoad.Rows(0)(FilmTypeSoundColumn.status_flag), False)

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
            If Me.txtFilmTypeSoundNameTH.Text.Trim() = "" OrElse Me.ddlFilmType.SelectedValue.Trim() = "0" Then
                Me.lblError.Text = "Please check require flield (*)"
                Me.lblError.Visible = True
            Else
                m_Database = MainApp.Database
                m_FilmTypeSoundDAL = New FilmTypeSoundDAL(m_Database)

                Dim strFilmTypeSoundID As Integer = Database.BlankIs(ViewState("FilmTypeSoundId"), 0)
                Dim strFilmtypeID As String = Database.BlankIs(Me.ddlFilmType.SelectedValue.Trim(), Nothing)
                Dim strFilmTypeSoundNameTH As String = Database.BlankIs(Me.txtFilmTypeSoundNameTH.Text.Trim(), Nothing)
                Dim strFilmTypeSoundHeaderGroup As String = Database.BlankIs(Me.txtFilmTypeSoundHeaderGroup.Text.Trim(), Nothing)
                Dim strSoundHeaderGroup As String = Database.BlankIs(Me.txtSoundHeaderGroup.Text.Trim(), Nothing)
                Dim strSpiritWorldExportID As Integer?
                If Not Database.IsBlank(Me.txtSpiritWorldExportID.Text) Then
                    strSpiritWorldExportID = CInt(Me.txtSpiritWorldExportID.Text.Trim())
                Else
                    strSpiritWorldExportID = Nothing
                End If
                Dim strStatusFlag As Boolean = Me.chkStatus.Checked
                Dim strUserId As String = Database.BlankIs(Session("UserID"), Nothing)

                If ViewState("ScreenMode") = "ADD" Then
                    Dim dtLoadDupNameAdd As DataTable = m_FilmTypeSoundDAL.LoadDuplicateNameAdd(strFilmTypeSoundNameTH)

                    If dtLoadDupNameAdd.Rows.Count > 0 Then
                        Me.lblError.Text = "Sound Name has exist!"
                        Me.lblError.Visible = True
                    Else
                        m_FilmTypeSoundDAL.Add(strFilmtypeID _
                            , strFilmTypeSoundNameTH _
                            , strFilmTypeSoundHeaderGroup _
                            , strSoundHeaderGroup _
                            , strSpiritWorldExportID _
                            , strStatusFlag _
                            , strUserId)
                        Me.lblError.Visible = False
                        Response.Redirect("frmCTBV_MMD_FilmTypeSound.aspx")
                    End If
                Else 'EDIT
                    If ViewState("FilmTypeSoundId") <> 0 Then
                        Dim dtLoadDupNameEdit As DataTable = m_FilmTypeSoundDAL.LoadDuplicateNameEdit(strFilmTypeSoundID, strFilmTypeSoundNameTH)

                        If dtLoadDupNameEdit.Rows.Count > 0 Then
                            Me.lblError.Text = "Sound Name has exist!"
                            Me.lblError.Visible = True
                        Else
                            m_FilmTypeSoundDAL.Edit(strFilmTypeSoundID _
                                , strFilmtypeID _
                                , strFilmTypeSoundNameTH _
                                , strFilmTypeSoundHeaderGroup _
                                , strSoundHeaderGroup _
                                , strSpiritWorldExportID _
                                , strStatusFlag _
                                , strUserId)
                            Me.lblError.Visible = False
                            Response.Redirect("frmCTBV_MMD_FilmTypeSound.aspx")
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
        Response.Redirect("frmCTBV_MMD_FilmTypeSound.aspx")
    End Sub

#End Region

#Region "Function"

    Private Sub LoadComboBoxADD()
        Dim dtLoadFilmType As DataTable = m_FilmTypeSoundDAL.LoadFilmTypeComboBoxAdd()
        Me.ddlFilmType.AppendDataBoundItems = True
        Me.ddlFilmType.DataSource = dtLoadFilmType
        Me.ddlFilmType.DataBind()
    End Sub

    Private Sub LoadComboBoxEDIT(ByVal p_film_type_id As Integer)
        Dim dtLoadFilmType As DataTable = m_FilmTypeSoundDAL.LoadFilmTypeComboBoxEdit(p_film_type_id)
        Me.ddlFilmType.AppendDataBoundItems = False
        Me.ddlFilmType.DataSource = dtLoadFilmType
        Me.ddlFilmType.DataBind()
        Me.ddlFilmType.SelectedValue = p_film_type_id
    End Sub

#End Region

End Class