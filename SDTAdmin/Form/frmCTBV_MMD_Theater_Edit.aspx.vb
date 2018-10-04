Imports System.Web.Security
Imports Web.Data

Partial Public Class frmCTBV_MMD_Theater_Edit
    Inherits Page

    '--- Added by Wittawat W. on 2012/11/13 : Add Film Type
    Dim m_Database As Database
    Dim m_TheaterDAL As TheaterDAL
    '--- End added by Wittawat W. on 2012/11/13 : Add Film Type

#Region "Event"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'Dim theaterId As Integer = Request.QueryString("theaterId")
        Dim theaterId As Integer
        If (Not ValidateQueryString(Request.QueryString("theaterId"), GetType(Integer), theaterId)) Then
            Response.Redirect("frmCTBV_MMD_Theater.aspx")
        End If

        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        Session("theaterId") = theaterId

        '--- Commented by Wittawat W. on 2012/11/13 : Add Film Type
        'If IsPostBack = False Then
        '    Me.tblTSub.Visible = False
        '    Dim getTheater As New cDatabase
        '    Dim theaterRead As IDataReader = getTheater.getTheaterDetail(theaterId)
        '    If theaterRead.Read Then
        '        txtTheater.Text = theaterRead("theater_name") & ""
        '        txtTheaterCode.Text = theaterRead("theater_code") & ""
        '        txtTheaterDes.Text = theaterRead("theater_des") & ""
        '        ddlCircuit.SelectedValue = theaterRead("circuit_id")
        '        ddlStatus.SelectedValue = theaterRead("theater_status")
        '        '--- Commented by Wittawat W. on 2012/11/13 : Add Film Type
        '        ''ddlImaxFlag.SelectedValue = theaterRead("imax_flag")
        '        '--- End commented by Wittawat W. on 2012/11/13 : Add Film Type
        '        If getTheater.CheckIsNullDateTime(theaterRead("open_date")) = New DateTime Then
        '            txtOpenDate.Text = ""

        '        Else
        '            txtOpenDate.Text = Format(Convert.ToDateTime(theaterRead("open_date")), "dd/MM/yyyy") & ""
        '        End If

        '        If getTheater.CheckIsNullDateTime(theaterRead("Close_date")) = New DateTime Then
        '            txtCloseDate.Text = ""
        '        Else
        '            txtCloseDate.Text = Format(Convert.ToDateTime(theaterRead("Close_date")), "dd/MM/yyyy") & ""
        '        End If
        '        'txtCloseDate.Text = Format(Convert.ToDateTime(getTheater.CheckIsNullDateTime(theaterRead("close_date"))), "dd/MM/yyyy") & ""
        '        txtRemark.Text = getTheater.CheckIsNullString(theaterRead("remark")) & ""
        '        ClearData()
        '    Else
        '        ClearData()
        '    End If
        '    theaterRead.Close()
        '    txtOpenSubDate.Text = txtOpenDate.Text
        'End If
        '--- End commented by Wittawat W. on 2012/11/13 : Add Film Type

        '--- Added by Wittawat W. on 2012/11/13 : Add Film Type
        Try
            If IsPostBack = False Then
                Me.tblTSub.Visible = False

                m_Database = MainApp.Database
                m_TheaterDAL = New TheaterDAL(m_Database)

                Dim dtTheater As DataTable = m_TheaterDAL.Load(theaterId)

                If dtTheater.Rows.Count > 0 Then
                    Me.txtTheater.Text = Database.NullIs(dtTheater.Rows(0)("theater_name"), "")
                    Me.txtTheaterCode.Text = Database.NullIs(dtTheater.Rows(0)("theater_code"), "")
                    Me.txtTheaterDes.Text = Database.NullIs(dtTheater.Rows(0)("theater_des"), "")
                    Me.ddlCircuit.SelectedValue = Database.NullIs(dtTheater.Rows(0)("circuit_id"), "")
                    Me.ddlStatus.SelectedValue = Database.NullIs(dtTheater.Rows(0)("theater_status"), "")
                    Me.dtpStartDate.SelectedDate = Database.NullIs(dtTheater.Rows(0)("open_date"), Nothing)
                    Me.dtpEndDate.SelectedDate = Database.NullIs(dtTheater.Rows(0)("close_date"), Nothing)
                    Me.txtRemark.Text = Database.NullIs(dtTheater.Rows(0)("remark"), "")
                    Me.txtGroupType.Text = Database.NullIs(dtTheater.Rows(0)("group_type"), "")

                    Dim dtFilmType As DataTable = m_TheaterDAL.LoadTheaterFilmType(theaterId)
                    Me.gvFilmType.DataSource = dtFilmType
                    Me.gvFilmType.DataBind()

                    ClearData()
                Else
                    ClearData()
                End If

                Me.txtOpenSubDate.Text = Me.dtpStartDate.Text
            End If
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.lblError.Visible = True
        End Try
        '--- End added by Wittawat W. on 2012/11/13 : Add Film Type
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbSaveClose.Click
        '--- Commented by Wittawat W. on 2012/11/13 : Add Film Type
        'Try
        '    If ddlStatus.SelectedValue = "Disenabled" Then
        '        If txtCloseDate.Text.Trim() = "" Then
        '            lblError.Visible = True
        '            lblError.Text = "Please input end date."
        '            Exit Sub
        '        End If
        '    End If
        '    If txtTheater.Text = "" Or txtOpenDate.Text = "" Then
        '        lblError.Visible = True
        '        lblError.Text = "Please check require flield (*)"
        '        Exit Sub
        '    Else
        '        lblError.Visible = False

        '        Dim dtOpen As DateTime
        '        Dim strOpen As String
        '        If txtOpenDate.Text.Trim() <> "" Then
        '            strOpen = txtOpenDate.Text.Substring(3, 2) + "/" + txtOpenDate.Text.Substring(0, 2) + "/" + txtOpenDate.Text.Substring(6, 4)
        '            dtOpen = Convert.ToDateTime(strOpen)
        '        Else
        '            strOpen = ""
        '            dtOpen = New DateTime   'Convert.ToDateTime(strOpen)
        '        End If

        '        Dim dtClose As DateTime
        '        Dim strClose As String
        '        If txtCloseDate.Text.Trim() <> "" Then
        '            strClose = txtCloseDate.Text.Substring(3, 2) + "/" + txtCloseDate.Text.Substring(0, 2) + "/" + txtCloseDate.Text.Substring(6, 4)
        '            dtClose = Convert.ToDateTime(strClose)
        '        Else
        '            strClose = ""
        '            dtClose = New DateTime 'Convert.ToDateTime(strClose)
        '        End If

        '        Dim strRemark As String = txtRemark.Text.Trim()

        '        Dim addTheater As New cDatabase
        '        addTheater.upDateTheater(Session("theaterId"), txtTheaterCode.Text, txtTheater.Text, txtTheaterDes.Text, ddlStatus.SelectedValue, Session("UserID"), ddlCircuit.SelectedValue, strRemark, dtOpen, dtClose, ddlImaxFlag.SelectedValue)

        '        Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" & Session("theaterId").ToString())
        '        'Response.Redirect("frmCTBV_MMD_Theater.aspx")
        '    End If
        'Catch ex As Exception
        '    lblError.Text = ex.Message
        '    lblError.Visible = True
        'End Try
        '--- End commented by Wittawat W. on 2012/11/13 : Add Film Type

        '--- Added by Wittawat W. on 2012/11/13 : Add Film Type
        Try
            If Me.txtTheater.Text = "" Then
                Me.lblError.Visible = True
                Me.lblError.Text = "Please check require flield (*)"
                Exit Sub
            End If
            If Me.dtpStartDate.Text = "" Then
                Me.lblError.Visible = True
                Me.lblError.Text = "Please check require flield (*)"
                Exit Sub
            End If
            If Me.ddlStatus.SelectedValue = "Disenabled" AndAlso Me.dtpEndDate.Text.Trim() = "" Then
                Me.lblError.Visible = True
                Me.lblError.Text = "Please input end date."
                Exit Sub
            End If

            Me.lblError.Visible = False

            Try
                m_Database = MainApp.Database
                m_TheaterDAL = New TheaterDAL(m_Database)

                m_Database.BeginTransaction()

                m_TheaterDAL.Edit(Session("theaterId"), Me.txtTheaterCode.Text.Trim(), Me.txtTheater.Text.Trim(), Me.txtTheaterDes.Text.Trim(), Me.ddlStatus.SelectedValue, Session("UserID"), Me.ddlCircuit.SelectedValue, Me.txtRemark.Text.Trim(), Me.dtpStartDate.SelectedDate, Me.dtpEndDate.SelectedDate, txtGroupType.Text.Trim())

                For Each row As GridViewRow In gvFilmType.Rows
                    Dim chkStatusFlagGridView As CheckBox = CType(row.FindControl("chkStatusFlag"), CheckBox)
                    Dim lblFilmTypeIDGridView As Label = CType(row.FindControl("lblFilmTypeID"), Label)
                    m_TheaterDAL.EditTheaterFilmType(Session("theaterId"), lblFilmTypeIDGridView.Text, chkStatusFlagGridView.Checked, Session("UserID"))
                Next

                Response.Redirect("frmCTBV_MMD_Theater_Edit.aspx?theaterId=" & Session("theaterId").ToString(), False)

                m_Database.CommitTransaction()
            Catch ex As Exception
                m_Database.RollbackTransaction()
                Throw ex
            End Try
        Catch ex As Exception
            Me.lblError.Text = ex.Message
            Me.lblError.Visible = True
        End Try
        '--- End added by Wittawat W. on 2012/11/13 : Add Film Type
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_theater.aspx")
    End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    Try
    '        If e.CommandName = "Select" Then
    '            Dim intTheaterId As Integer = Session("theaterId")
    '            Dim intTheaterSubId As Integer = Convert.ToInt32(e.CommandArgument)

    '            Dim strSqlSelect As String = "SELECT status_flag FROM tblTheaterSub WHERE theater_id = " + intTheaterId.ToString() + " AND theatersub_id = " + intTheaterSubId.ToString()
    '            Dim strStatusNow, strStatusSave As String ' = GridView1.Rows(intTheaterId).Cells(3).Text
    '            Dim cDB As New cDatabase
    '            Dim dataReader As IDataReader = cDB.GetDataAll(strSqlSelect)
    '            If dataReader.Read = True Then
    '                strStatusNow = Convert.ToString(dataReader("status_flag"))
    '                If strStatusNow = "Y" Then
    '                    strStatusSave = "'N'"
    '                Else
    '                    strStatusSave = "'Y'"
    '                End If
    '            Else
    '                strStatusSave = "Y"
    '            End If
    '            dataReader.Close()

    '            Dim strSqlUpdate As String = "UPDATE tblTheaterSub SET status_flag = " + strStatusSave + " WHERE theater_id = " + intTheaterId.ToString() + " AND theatersub_id = " + intTheaterSubId.ToString()
    '            cDB.GetDataAll(strSqlUpdate)
    '            GridView1.DataBind()
    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Protected Sub btnSaveSub_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnSaveSub.Click
        Try
            '--- Modified by Wittawat W. on 2012/11/13 : Add Film Type
            'If txtSeat0.Text = "" Or txtOpenDate.Text = "" Then
            '    lblErrorSub.Visible = True
            '    lblErrorSub.Text = "Please check require flield (*)"
            '    Return
            'End If
            If Me.txtSeat0.Text = "" Or Me.dtpStartDate.Text = "" Then
                lblErrorSub.Visible = True
                lblErrorSub.Text = "Please check require flield (*)"
                Return
            End If
            '--- End modified by Wittawat W. on 2012/11/13 : Add Film Type

            If chkActive.Checked = False Then
                If txtCloseSubDate.Text.Trim() = "" Then
                    lblErrorSub.Visible = True
                    lblErrorSub.Text = "Please input end date."
                    Exit Sub
                End If

            End If

            Dim seat As Integer = IIf(IsNumeric(txtSeat0.Text), txtSeat0.Text, "0")

            'Dim theaterId As Integer = Request.QueryString("theaterId")
            Dim theaterId As Integer
            If (Not ValidateQueryString(Request.QueryString("theaterId"), GetType(Integer), theaterId)) Then
                Response.Redirect("frmCTBV_MMD_theater.aspx")
            End If

            'If IsNumeric(txtScreenId0.Text) Then
            Dim dtOpenSub As DateTime
            Dim strOpenSub As String
            If txtOpenSubDate.Text.Trim() <> "" Then
                strOpenSub = txtOpenSubDate.Text.Substring(3, 2) + "/" + txtOpenSubDate.Text.Substring(0, 2) + "/" + txtOpenSubDate.Text.Substring(6, 4)
                dtOpenSub = Convert.ToDateTime(strOpenSub)
            Else
                strOpenSub = ""
                dtOpenSub = New DateTime
                'Convert.ToDateTime(strOpenSub)
            End If

            Dim dtCloseSub As DateTime
            Dim strCloseSub As String
            If txtCloseSubDate.Text.Trim() <> "" Then
                strCloseSub = txtCloseSubDate.Text.Substring(3, 2) + "/" + txtCloseSubDate.Text.Substring(0, 2) + "/" + txtCloseSubDate.Text.Substring(6, 4)
                dtCloseSub = Convert.ToDateTime(strCloseSub)
            Else
                strCloseSub = ""
                dtCloseSub = New DateTime
                'Convert.ToDateTime(strCloseSub)
            End If

            Dim strMM, strDigital, strDimention As String
            If chkMM.Checked = True Then
                strMM = "Y"
            Else
                strMM = "N"
            End If
            If chkDigital.Checked = True Then
                strDigital = "Y"
            Else
                strDigital = "N"
            End If
            If chkDimention.Checked = True Then
                strDimention = "Y"
            Else
                strDimention = "N"
            End If

            Dim strStatus As String
            If chkActive.Checked = True Then
                strStatus = "Y"
            Else
                strStatus = "N"
            End If

            Dim cDB As New cDatabase
            Dim intIDsave As Integer = 0

            dtOpenSub = ConvertTimeToLocaltime(dtOpenSub)   'ConvertTimeZone By Pachara S. on 20170615
            dtCloseSub = ConvertTimeToLocaltime(dtCloseSub) 'ConvertTimeZone By Pachara S. on 20170615

            If txtScreenId0.Text = "" Then 'Insert

                Dim intGetMax As String = "0"
                intGetMax = cDB.GetMaxID("theatersub_id", "tblTheaterSub", " WHERE theater_id = " + Session("theaterId").ToString())
                intIDsave = Convert.ToInt32(intGetMax) + 1

                cDB.AddTheaterSub(intIDsave, txtScreenCode0.Text, intIDsave, seat, theaterId, strMM, strDigital, strDimention, dtOpenSub, dtCloseSub)
                lblErrorSub.Visible = False
                'Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" & theaterId)
            Else 'Update
                intIDsave = CInt(txtScreenId0.Text)
                cDB.UpdateTheaterSub(intIDsave, txtScreenCode0.Text, intIDsave, seat, theaterId, strMM, strDigital, strDimention, dtOpenSub, dtCloseSub, strStatus)
                lblErrorSub.Visible = False
                'Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" & theaterId)
            End If
            'Else
            'lblErrorSub.Visible = True
            'lblErrorSub.Text = "Please fill Screens is number!! "
            'End If
            GridView1.DataBind()
            ClearData()
            GridView1.Focus()
            tblTSub.Visible = False
        Catch ex As Exception
            lblErrorSub.Visible = True
            lblErrorSub.Text = ex.Message
            GridView1.Focus()
        End Try
    End Sub

    Protected Sub btnCancelSub_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnCancelSub.Click
        Try
            ClearData()
            GridView1.Focus()
            tblTSub.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Sub ClearData()
        txtScreenId0.Text = ""
        txtScreenCode0.Text = ""
        txtSeat0.Text = ""
        chkMM.Checked = True
        chkDigital.Checked = False
        chkDimention.Checked = False
        txtOpenSubDate.Text = ""
        txtCloseSubDate.Text = ""
        chkActive.Checked = True
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        Try
            tblTSub.Visible = True
            Dim strSubID As String = GridView1.SelectedValue()

            Dim cDB As New cDatabase
            Dim drTheaterSub As IDataReader = cDB.getTheaterSubDetail(Session("theaterId"), strSubID)
            If drTheaterSub.Read Then
                txtScreenId0.Text = strSubID
                txtScreenCode0.Text = cDB.CheckIsNullString(drTheaterSub("theatersub_code")) & ""
                txtSeat0.Text = cDB.CheckIsNullInteger(drTheaterSub("theatersub_normalseat")) & ""

                If cDB.CheckIsNullString(drTheaterSub("mm_flag")) = "Y" Then
                    chkMM.Checked = True
                Else
                    chkMM.Checked = False
                End If

                If cDB.CheckIsNullString(drTheaterSub("digital_flag")) = "Y" Then
                    chkDigital.Checked = True
                Else
                    chkDigital.Checked = False
                End If

                If cDB.CheckIsNullString(drTheaterSub("dimention_flag")) = "Y" Then
                    chkDimention.Checked = True
                Else
                    chkDimention.Checked = False
                End If

                If cDB.CheckIsNullString(drTheaterSub("status_flag")) = "Y" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If

                If cDB.CheckIsNullDateTime(drTheaterSub("Open_date")) = New DateTime Then
                    txtOpenSubDate.Text = ""
                Else
                    txtOpenSubDate.Text = Format(Convert.ToDateTime(drTheaterSub("Open_date")), "dd/MM/yyyy") & ""
                End If

                If cDB.CheckIsNullDateTime(drTheaterSub("Close_date")) = New DateTime Then
                    txtCloseSubDate.Text = ""
                Else
                    txtCloseSubDate.Text = Format(Convert.ToDateTime(drTheaterSub("Close_date")), "dd/MM/yyyy") & ""
                End If

            End If
            drTheaterSub.Close()
            lblErrorSub.Visible = False
            GridView1.Focus()
        Catch ex As Exception
            lblErrorSub.Visible = True
            lblErrorSub.Text = ex.Message
        End Try
    End Sub

    Protected Sub chkDimention_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkDimention.CheckedChanged
        If chkDimention.Checked = False Then
            chkDigital.Checked = False
        Else
            chkDigital.Checked = True
        End If
        GridView1.Focus()
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub


    Protected Sub btnNewTSub_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnNewTSub.Click
        Try
            tblTSub.Visible = True
            ClearData()
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Function"

#End Region
End Class