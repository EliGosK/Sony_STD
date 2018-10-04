Imports System.Diagnostics
Imports System.Web.Security

Partial Class frmCTBV_MMD_Theater_Add
    Inherits Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As Object

    Private Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    '--- Added by Wittawat W. on 2012/11/13 : Add Film Type
    Dim m_Database As Database
    Dim m_TheaterDAL As TheaterDAL
    '--- End added by Wittawat W. on 2012/11/13 : Add Film Type

    Private Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        '--- Added by Wittawat W. on 2012/11/13 : Add Film Type
        If Not IsPostBack Then
            m_Database = MainApp.Database
            m_TheaterDAL = New TheaterDAL(m_Database)

            Me.dtpStartDate.SelectedDate = Today

            Dim dtFilmType As DataTable = m_TheaterDAL.LoadTheaterFilmType(Nothing)
            Me.gvFilmType.DataSource = dtFilmType
            Me.gvFilmType.DataBind()
        End If
        '--- End added by Wittawat W. on 2012/11/13 : Add Film Type
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbSaveClose.Click
        '--- Commented by Wittawat W. on 2012/11/13 : Add Film Type
        'Try
        '    If Me.txtTheater.Text = "" Then
        '        Me.lblError.Visible = True
        '        Me.lblError.Text = "Please check require flield (*)"
        '    Else
        '        Me.lblError.Visible = False


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

        '        Dim strRemark As String = Me.txtRemark.Text.Trim()

        '        Dim addTheater As New cDatabase
        '        addTheater.AddTheater(txtTheaterCode.Text, txtTheater.Text, txtTheaterDes.Text, ddlStatus.SelectedValue, Session("UserID"), ddlCircuit.SelectedValue, strRemark, dtOpen, dtClose, ddlImaxFlag.SelectedValue)

        '        Dim intGetMax As String = "0"
        '        intGetMax = addTheater.GetMaxID("theater_id", "tblTheater", "") '" WHERE theater_name = " + txtTheater.Text.Trim()

        '        Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" + intGetMax)
        '    End If
        'Catch ex As Exception
        '    Me.lblError.Visible = True
        '    Me.lblError.Text = ex.Message
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

            Me.lblError.Visible = False

            Try
                m_Database = MainApp.Database
                m_TheaterDAL = New TheaterDAL(m_Database)

                m_Database.BeginTransaction()

                Dim intTheaterID As Integer

                m_TheaterDAL.Add(Me.txtTheaterCode.Text.Trim(), Me.txtTheater.Text.Trim(), Me.txtTheaterDes.Text.Trim(), Me.ddlStatus.SelectedValue, Session("UserID"), Me.ddlCircuit.SelectedValue, Me.txtRemark.Text.Trim(), Me.dtpStartDate.SelectedDate, Me.dtEndDate.SelectedDate, Me.txtGroupType.Text.Trim(), intTheaterID)

                For Each row As GridViewRow In gvFilmType.Rows
                    Dim chkStatusFlagGridView As CheckBox = CType(row.FindControl("chkStatusFlag"), CheckBox)
                    Dim lblFilmTypeIDGridView As Label = CType(row.FindControl("lblFilmTypeID"), Label)
                    m_TheaterDAL.EditTheaterFilmType(intTheaterID, lblFilmTypeIDGridView.Text, chkStatusFlagGridView.Checked, Session("UserID"))
                Next

                Response.Redirect("frmCTBV_MMD_Theater_Edit.aspx?theaterId=" & intTheaterID, False)

                m_Database.CommitTransaction()
            Catch ex As Exception
                m_Database.RollbackTransaction()
                Throw ex
            End Try
        Catch ex As Exception
            Me.lblError.Visible = True
            Me.lblError.Text = ex.Message
        End Try
        '--- End added by Wittawat W. on 2012/11/13 : Add Film Type
    End Sub


    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_MMD_theater.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
