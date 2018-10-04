Imports SDTCommon
Imports Web.Data
Imports System.Web.Security
Imports System.Text.RegularExpressions

Partial Class frmCTBV_AT_Add
    Inherits Page

    '''''' Permission Code : 14 permission
    '''''' 1:Allow Access,0:Access Denied
    '''''' example --> 01000001100000001000001000000000
    '1 Box Office
    '2 Display Box Office for each day
    '3 Display Box Office for each theater
    '4 Display Box Office for each screen
    '5 Display Box Office for each session
    '6 Edit/Delete Box Office for each session


    '7 Trailer Management*****frmCTBV_Menu_Trailer.aspx
    '12 Trailer Setup*****frmCTBV_Trailer_Setup_Detail.aspx
    '13 From Checker****frmCTBV_Trailer_Show.aspx
    '14 Trailer Report*****frmCTBV_Menu_Trailer_Rpt.aspx

    '8 Inventory Management

    '9 MasterData Management*****frmCTBV_Menu_MMD.aspx
    '26 Movie*****frmCTBV_MMD_Movie.aspx
    '27 Theaters*****frmCTBV_MMD_Theater.aspx
    '28 Distributor*****frmCTBV_MMD_Disdistributor.aspx
    '37 Studio*****

    '10 Admin Tool *****frmCTBV_AT_Main.aspx
    '29 User Setting*****frmCTBV_AT.aspx
    '30 Checker*****frmCTBV_AT_Message.aspx
    '31 Box Office Status*****frmCTBV_AT_monitorStatus.aspx
    '43 Weekly Movie Setup for Checker Wage*****frmCTBV_AT_SetupDate.aspx

    '44 Checker Level and Wage*****frmCTBV_AT_LavelAndWage.aspx
    '32 Late Show Config*****frmCTBV_AT_LateShow.aspx
    '38 Checker Level*****frmCTBV_AT_Level.aspx
    '39 Present Wage*****frmCTBV_AT_Present.aspx
    '40 Former Wage*****frmCTBV_AT_Former.aspx
    '41 Collect Report Config*****frmCTBV_AT_Config.aspx
    '42 Wage by Session Config*****frmCTBV_AT_Session.aspx

    '11 Report Center*****
    '15 Export Box Office Data*****
    '16 Movies SDT Box Office by day*****
    '17 Movies Competitor Box Office by day*****
    '18 Movies Box Office per week*****
    '19 Weekend Trading Report*****
    '20 SDT Market Share*****
    '21 Competitor Market Share*****
    '22 Market Share by Period*****
    '23 Movie Box Office by Sound and Film Format*****
    '36 Competitor Box Office by Sound and Film Format*****
    '24 SDT Box office and Late Show by Theatre*****
    '25 PDA Box office*****
    '33 Theatre Information*****
    '34 Occupancy Report*****
    '35 Industry Information by Title*****

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim cDB As New cDatabase
    Public maxspin As String
    Public minspin As String
    Public new_flag As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here

        CheckPermission(AdminPage.Menu_Admin, True)

        txtPassword.Attributes.Add("onFocus", "setVisibility('101','inline')")
        txtPassword.Attributes.Add("onBlur", "setVisibility('101','none')")

        Dim userId As String = ""
        If (Not ValidateQueryString(Request.QueryString("userId"), GetType(String), userId)) Then
            Response.Redirect("frmCTBV_AT.aspx")
        End If

        'userId = Request.QueryString("userId")
        If Not IsPostBack Then
            If Session("expire") Is "true" Then     'added by Phasupong (show msg when password expired)
                Response.Write("<script>alert('Your password has been expired!\n Please change your password to follow security policies.')</script>")
                Session("expire") = "false"
                userId = Session("UserID")
                txtPassword.Focus()
            End If

            Dim cDB As New cDatabase
            Dim dataReader As IDataReader = cDB.getUserDetail(userId)

            cDB.LoadDataToDropdownList(ddlPresent, "tblChecker_Level", "checker_level_name", "checker_level_id", "present_level_flag = 'Y'")
            cDB.LoadDataToDropdownList(ddlFormer, "tblChecker_Level", "checker_level_name", "checker_level_id", "former_level_flag = 'Y'")

            If dataReader.Read = True Then
                hidMode.Value = "EDIT"
                txtName.Text = dataReader("user_name") & ""
                txtEmail.Text = dataReader("user_email") & ""
                '--- Added on 09/07/2015 by Phasupong ---'
                txtSpin.Text = dataReader("password_age") & ""
                '--- Ended on 09/07/2015 ---'

                'txtPassword.Text = dataReader("user_password") & ""
                Dim encryptPassword As String = dataReader("user_password").ToString()
                If encryptPassword.Length < 5 Then
                    encryptPassword = Crypto.Encrypt(encryptPassword)
                End If
                txtPasswordEncrypt.Text = encryptPassword


                txtTel.Text = dataReader("user_tel") & ""
                txtUserId.Text = dataReader("user_id") & ""
                ddlTypeUser.SelectedValue = dataReader("usergroup_id")
                ddlStatus.SelectedValue = dataReader("user_status")


                If dataReader("present_checker_level_id") <> 0 Then
                    ddlPresent.SelectedValue = dataReader("present_checker_level_id")
                End If

                If dataReader("former_checker_level_id") <> 0 Then
                    ddlFormer.SelectedValue = dataReader("former_checker_level_id")
                End If

                If dataReader("usergroup_id") = "Administrator" Then
                    ddlPresent.Enabled = False
                    ddlFormer.Enabled = False
                Else
                    ddlPresent.Enabled = True
                    ddlFormer.Enabled = True
                End If

                'Dim i As Integer = 1
                'Dim prm As String
                'For i = 1 To Len(dataReader("user_permission"))
                'If i = 1 Then
                Dim permission As String = dataReader("user_permission")
                If permission.CheckPermission(AdminPage.Menu_BoxOffice) Then
                    chkPerm02.Enabled = True
                    chkPerm03.Enabled = True
                    chkPerm04.Enabled = True
                    chkPerm05.Enabled = True
                    chkPerm06.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Trailer) Then
                    chkPerm12.Enabled = True
                    chkPerm13.Enabled = True
                    chkPerm14.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Master) Then
                    chkPerm26.Enabled = True
                    chkPerm27.Enabled = True
                    chkPerm28.Enabled = True
                    chkPerm37.Enabled = True
                    chkPerm45.Enabled = True
                    chkPerm46.Enabled = True
                    chkPerm57.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Ticket) Then
                    chkPerm47.Enabled = True
                    chkPerm48.Enabled = True
                    chkPerm49.Enabled = True
                    chkPerm50.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Vpf) Then
                    chkPerm53.Enabled = True
                    chkPerm54.Enabled = True
                    chkPerm55.Enabled = True
                    chkPerm56.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Report) Then
                    chkPerm15.Enabled = True
                    chkPerm16.Enabled = True
                    chkPerm17.Enabled = True
                    chkPerm18.Enabled = True
                    chkPerm19.Enabled = True
                    chkPerm20.Enabled = True
                    chkPerm21.Enabled = True
                    chkPerm22.Enabled = True
                    chkPerm23.Enabled = True
                    chkPerm36.Enabled = True
                    chkPerm24.Enabled = True
                    chkPerm25.Enabled = True
                    chkPerm33.Enabled = True
                    chkPerm34.Enabled = True
                    chkPerm35.Enabled = True
                    chkPerm51.Enabled = True
                End If
                If permission.CheckPermission(AdminPage.Menu_Admin) Then
                    chkPerm29.Enabled = True
                    chkPerm30.Enabled = True
                    chkPerm31.Enabled = True
                    chkPerm42.Enabled = True
                    chkPerm43.Enabled = True
                    chkPerm58.Enabled = True    'Added on 10/07/2015 by Phasupong

                    If Mid(dataReader("user_permission"), 44, 1) = 1 Then
                        chkPerm44.Enabled = True
                        chkPerm32.Enabled = True
                        chkPerm38.Enabled = True
                        chkPerm39.Enabled = True
                        chkPerm40.Enabled = True
                        chkPerm41.Enabled = True
                    End If
                Else
                    chkPerm44.Enabled = False
                End If

                If ddlTypeUser.SelectedValue = "Checker" Then 'Or txtUserId.Text = "1001"
                    chkPerm01.Enabled = False
                    chkPerm02.Enabled = False
                    chkPerm03.Enabled = False
                    chkPerm04.Enabled = False
                    chkPerm05.Enabled = False
                    chkPerm06.Enabled = False
                    chkPerm07.Enabled = False
                    chkPerm08.Enabled = False
                    chkPerm09.Enabled = False
                    chkPerm10.Enabled = False
                    chkPerm11.Enabled = False
                    chkPerm12.Enabled = False
                    chkPerm13.Enabled = False
                    chkPerm14.Enabled = False
                    chkPerm15.Enabled = False
                    chkPerm16.Enabled = False
                    chkPerm17.Enabled = False
                    chkPerm18.Enabled = False
                    chkPerm19.Enabled = False
                    chkPerm20.Enabled = False
                    chkPerm21.Enabled = False
                    chkPerm22.Enabled = False
                    chkPerm23.Enabled = False
                    chkPerm36.Enabled = False
                    chkPerm24.Enabled = False
                    chkPerm25.Enabled = False
                    chkPerm26.Enabled = False
                    chkPerm27.Enabled = False
                    chkPerm28.Enabled = False
                    chkPerm37.Enabled = False
                    chkPerm29.Enabled = False
                    chkPerm30.Enabled = False
                    chkPerm31.Enabled = False

                    chkPerm33.Enabled = False
                    chkPerm34.Enabled = False
                    chkPerm35.Enabled = False
                    chkPerm43.Enabled = False

                    chkPerm32.Enabled = False
                    chkPerm38.Enabled = False
                    chkPerm39.Enabled = False
                    chkPerm40.Enabled = False
                    chkPerm41.Enabled = False
                    chkPerm42.Enabled = False

                    chkPerm44.Enabled = False
                    chkPerm52.Enabled = False

                    chkPerm58.Enabled = False   'Added 10/07/2015 by Phasupong
                End If

                chkPerm01.Checked = Mid(dataReader("user_permission"), 1, 1)
                chkPerm02.Checked = Mid(dataReader("user_permission"), 2, 1)
                chkPerm03.Checked = Mid(dataReader("user_permission"), 3, 1)
                chkPerm04.Checked = Mid(dataReader("user_permission"), 4, 1)
                chkPerm05.Checked = Mid(dataReader("user_permission"), 5, 1)
                chkPerm06.Checked = Mid(dataReader("user_permission"), 6, 1)
                chkPerm07.Checked = Mid(dataReader("user_permission"), 7, 1)
                chkPerm08.Checked = Mid(dataReader("user_permission"), 8, 1)
                chkPerm09.Checked = Mid(dataReader("user_permission"), 9, 1)
                chkPerm10.Checked = Mid(dataReader("user_permission"), 10, 1)
                chkPerm11.Checked = Mid(dataReader("user_permission"), 11, 1)
                chkPerm12.Checked = Mid(dataReader("user_permission"), 12, 1)
                chkPerm13.Checked = Mid(dataReader("user_permission"), 13, 1)
                chkPerm14.Checked = Mid(dataReader("user_permission"), 14, 1)
                chkPerm15.Checked = Mid(dataReader("user_permission"), 15, 1)
                chkPerm16.Checked = Mid(dataReader("user_permission"), 16, 1)
                chkPerm17.Checked = Mid(dataReader("user_permission"), 17, 1)
                chkPerm18.Checked = Mid(dataReader("user_permission"), 18, 1)
                chkPerm19.Checked = Mid(dataReader("user_permission"), 19, 1)
                chkPerm20.Checked = Mid(dataReader("user_permission"), 20, 1)
                chkPerm21.Checked = Mid(dataReader("user_permission"), 21, 1)
                chkPerm22.Checked = Mid(dataReader("user_permission"), 22, 1)
                chkPerm23.Checked = Mid(dataReader("user_permission"), 23, 1)
                chkPerm36.Checked = Mid(dataReader("user_permission"), 36, 1)
                chkPerm24.Checked = Mid(dataReader("user_permission"), 24, 1)
                chkPerm25.Checked = Mid(dataReader("user_permission"), 25, 1)
                chkPerm26.Checked = Mid(dataReader("user_permission"), 26, 1)
                chkPerm27.Checked = Mid(dataReader("user_permission"), 27, 1)
                chkPerm28.Checked = Mid(dataReader("user_permission"), 28, 1)
                chkPerm37.Checked = Mid(dataReader("user_permission"), 37, 1)
                chkPerm29.Checked = Mid(dataReader("user_permission"), 29, 1)
                chkPerm30.Checked = Mid(dataReader("user_permission"), 30, 1)
                chkPerm31.Checked = Mid(dataReader("user_permission"), 31, 1)

                chkPerm33.Checked = Mid(dataReader("user_permission"), 33, 1)
                chkPerm34.Checked = Mid(dataReader("user_permission"), 34, 1)
                chkPerm35.Checked = Mid(dataReader("user_permission"), 35, 1)
                chkPerm43.Checked = Mid(dataReader("user_permission"), 43, 1)

                chkPerm32.Checked = Mid(dataReader("user_permission"), 32, 1)
                chkPerm38.Checked = Mid(dataReader("user_permission"), 38, 1)
                chkPerm39.Checked = Mid(dataReader("user_permission"), 39, 1)
                chkPerm40.Checked = Mid(dataReader("user_permission"), 40, 1)
                chkPerm41.Checked = Mid(dataReader("user_permission"), 41, 1)
                chkPerm42.Checked = Mid(dataReader("user_permission"), 42, 1)
                chkPerm44.Checked = Mid(dataReader("user_permission"), 44, 1)

                '38 Checker Level*****frmCTBV_AT_Level.aspx
                '39 Present Wage*****frmCTBV_AT_Present.aspx
                '40 Former Wage*****frmCTBV_AT_Former.aspx
                '41 Collect Report Config*****frmCTBV_AT_Config.aspx
                '42 Wage by Session Config*****frmCTBV_AT_Session.aspx
                '43 Weekly Movie Setup for Checker Wage*****frmCTBV_AT_SetupDate.aspx

                chkPerm08.Checked = permission.CheckPermission(AdminPage.Menu_Ticket)
                chkPerm45.Checked = permission.CheckPermission(AdminPage.Master_FilmType)
                chkPerm46.Checked = permission.CheckPermission(AdminPage.Master_FilmTypeAndSound)
                chkPerm57.Checked = permission.CheckPermission(AdminPage.Master_Holiday)
                chkPerm47.Checked = permission.CheckPermission(AdminPage.Ticket_FreeTicketAndPerCap)
                chkPerm48.Checked = permission.CheckPermission(AdminPage.Ticket_FreeTicketAndPerCapByMovie)
                chkPerm49.Checked = permission.CheckPermission(AdminPage.Ticket_TicketType)
                chkPerm50.Checked = permission.CheckPermission(AdminPage.Ticket_TicketTypeByMovie)
                chkPerm51.Checked = permission.CheckPermission(AdminPage.Report_FreeTicketAndPerCapAndTicketTypeSummary)
                chkPerm52.Checked = permission.CheckPermission(AdminPage.Menu_Vpf)
                chkPerm53.Checked = permission.CheckPermission(AdminPage.Menu_Vpf_ProblemRecord)
                chkPerm54.Checked = permission.CheckPermission(AdminPage.Menu_Vpf_MovieDefaultSet)
                chkPerm55.Checked = permission.CheckPermission(AdminPage.Menu_Vpf_ManageMovieSet)
                chkPerm56.Checked = permission.CheckPermission(AdminPage.Menu_Vpf_Summary)
                'chkPerm02.Checked = Mid(dataReader("user_permission"), 1, 1)
                chkPerm58.Checked = permission.CheckPermission(AdminPage.Admin_SystemPolicies)   'Added 10/07/2015 by Phasupong (This function is to handle old system)

                'End If
                ' Next
                'Panel1.Enabled = False
                'Panel2.Enabled = True
                txtUserId.Visible = True
                lblUserId.Visible = True
                ddlTypeUser.Enabled = False
            Else
                new_flag = "new"

                lblCheckPassword.Text = String.Empty

                hidMode.Value = "ADD"
                'Panel1.Enabled = True
                'Panel2.Enabled = False
                ddlTypeUser.Enabled = True
                txtUserId.Text = getMaxID("Checker")
                chkPerm01.Enabled = False
                chkPerm02.Enabled = False
                chkPerm03.Enabled = False
                chkPerm04.Enabled = False
                chkPerm05.Enabled = False
                chkPerm06.Enabled = False
                chkPerm07.Enabled = False
                chkPerm08.Enabled = False
                chkPerm09.Enabled = False
                chkPerm10.Enabled = False
                chkPerm11.Enabled = False
                chkPerm12.Enabled = False
                chkPerm13.Enabled = False
                chkPerm14.Enabled = False
                chkPerm15.Enabled = False
                chkPerm16.Enabled = False
                chkPerm17.Enabled = False
                chkPerm18.Enabled = False
                chkPerm19.Enabled = False
                chkPerm20.Enabled = False
                chkPerm21.Enabled = False
                chkPerm22.Enabled = False
                chkPerm23.Enabled = False
                chkPerm36.Enabled = False
                chkPerm24.Enabled = False
                chkPerm25.Enabled = False
                chkPerm26.Enabled = False
                chkPerm27.Enabled = False
                chkPerm28.Enabled = False
                chkPerm37.Enabled = False
                chkPerm29.Enabled = False
                chkPerm30.Enabled = False
                chkPerm31.Enabled = False
                chkPerm32.Enabled = False
                chkPerm33.Enabled = False
                chkPerm34.Enabled = False
                chkPerm35.Enabled = False
                chkPerm38.Enabled = False
                chkPerm39.Enabled = False
                chkPerm40.Enabled = False
                chkPerm41.Enabled = False
                chkPerm42.Enabled = False
                chkPerm43.Enabled = False
                chkPerm44.Enabled = False


                chkPerm01.Checked = False
                chkPerm02.Checked = False
                chkPerm03.Checked = False
                chkPerm04.Checked = False
                chkPerm05.Checked = False
                chkPerm06.Checked = False
                chkPerm07.Checked = False
                chkPerm08.Checked = False
                chkPerm09.Checked = False
                chkPerm10.Checked = False
                chkPerm11.Checked = False
                chkPerm12.Checked = False
                chkPerm13.Checked = False
                chkPerm14.Checked = False
                chkPerm15.Checked = False
                chkPerm16.Checked = False
                chkPerm17.Checked = False
                chkPerm18.Checked = False
                chkPerm19.Checked = False
                chkPerm20.Checked = False
                chkPerm21.Checked = False
                chkPerm22.Checked = False
                chkPerm23.Checked = False
                chkPerm36.Checked = False
                chkPerm24.Checked = False
                chkPerm25.Checked = False
                chkPerm26.Checked = False
                chkPerm27.Checked = False
                chkPerm28.Checked = False
                chkPerm37.Checked = False
                chkPerm29.Checked = False
                chkPerm30.Checked = False
                chkPerm31.Checked = False
                chkPerm32.Checked = False
                chkPerm33.Checked = False
                chkPerm34.Checked = False
                chkPerm35.Checked = False
                chkPerm38.Checked = False
                chkPerm39.Checked = False
                chkPerm40.Checked = False
                chkPerm41.Checked = False
                chkPerm42.Checked = False
                chkPerm43.Checked = False
                chkPerm44.Checked = False

                chkPerm08.Enabled = False
                chkPerm45.Enabled = False
                chkPerm46.Enabled = False
                chkPerm47.Enabled = False
                chkPerm48.Enabled = False
                chkPerm49.Enabled = False
                chkPerm50.Enabled = False
                chkPerm51.Enabled = False
                chkPerm52.Enabled = False
                chkPerm53.Enabled = False
                chkPerm54.Enabled = False
                chkPerm55.Enabled = False
                chkPerm56.Enabled = False
                chkPerm58.Enabled = False   'Added on 10/07/2015 by Phasupong

                chkPerm08.Checked = False
                chkPerm45.Checked = False
                chkPerm46.Checked = False
                chkPerm47.Checked = False
                chkPerm48.Checked = False
                chkPerm49.Checked = False
                chkPerm50.Checked = False
                chkPerm51.Checked = False
                chkPerm52.Checked = False
                chkPerm53.Checked = False
                chkPerm54.Checked = False
                chkPerm55.Checked = False
                chkPerm56.Checked = False
                chkPerm58.Checked = False   'Added on 10/07/2015 by Phasupong


                txtUserId.Visible = False
                lblUserId.Visible = False

            End If
            dataReader.Close()

            '--- Added by Wittawat W. on 2013/04/30 : User mapping with location
            If ddlTypeUser.SelectedValue = "Checker" Then
                Me.lblTheater.Visible = True
                Me.rptTheater.Visible = True
                RefreshTheater(DBInterface.User.SelectUserTheater(userId))
            Else
                Me.lblTheater.Visible = False
                Me.rptTheater.Visible = False
            End If
            '--- End added by Wittawat W. on 2013/04/30 : User mapping with location

            '--- Added on 09/07/2015 by Phasupong (password hint, length)---'
            Dim drPWHint As IDataReader = cDB.GetPWHint(ddlTypeUser.SelectedValue.ToString())
            Dim drPWLength As IDataReader = cDB.GetPWLength(ddlTypeUser.SelectedValue.ToString())
            drPWHint.Read()
            drPWLength.Read()
            lblHint.Text = drPWHint("PasswordHint")
            txtPassword.MaxLength = drPWLength("PWDMaxLength")
            lblPWLength.Text = drPWLength("PWDMinLength")
            drPWHint.Close()
            drPWLength.Close()
            '--- Ended on 09/07/2015 ---'

        End If
        Dim drPWDAge As IDataReader = cDB.GetMinMaxPWDAge(ddlTypeUser.SelectedValue) 'added by Phasupong
        drPWDAge.Read()
        maxspin = drPWDAge("AgeMax")
        minspin = drPWDAge("AgeMin")
        drPWDAge.Close()
    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbSaveClose.Click
        'Dim Permission As String
        Dim userPermission As String
        userPermission = IIf(chkPerm01.Checked = True, "1", "0") & _
                         IIf(chkPerm02.Checked = True, "1", "0") & _
                         IIf(chkPerm03.Checked = True, "1", "0") & _
                         IIf(chkPerm04.Checked = True, "1", "0") & _
                         IIf(chkPerm05.Checked = True, "1", "0") & _
                         IIf(chkPerm06.Checked = True, "1", "0") & _
                         IIf(chkPerm07.Checked = True, "1", "0") & _
                         IIf(chkPerm08.Checked = True, "1", "0") & _
                         IIf(chkPerm09.Checked = True, "1", "0") & _
                         IIf(chkPerm10.Checked = True, "1", "0") & _
                         IIf(chkPerm11.Checked = True, "1", "0") & _
                         IIf(chkPerm12.Checked = True, "1", "0") & _
                         IIf(chkPerm13.Checked = True, "1", "0") & _
                         IIf(chkPerm14.Checked = True, "1", "0") & _
                         IIf(chkPerm15.Checked = True, "1", "0") & _
                         IIf(chkPerm16.Checked = True, "1", "0") & _
                         IIf(chkPerm17.Checked = True, "1", "0") & _
                         IIf(chkPerm18.Checked = True, "1", "0") & _
                         IIf(chkPerm19.Checked = True, "1", "0") & _
                         IIf(chkPerm20.Checked = True, "1", "0") & _
                         IIf(chkPerm21.Checked = True, "1", "0") & _
                         IIf(chkPerm22.Checked = True, "1", "0") & _
                         IIf(chkPerm23.Checked = True, "1", "0") & _
                         IIf(chkPerm24.Checked = True, "1", "0") & _
                         IIf(chkPerm25.Checked = True, "1", "0") & _
                         IIf(chkPerm26.Checked = True, "1", "0") & _
                         IIf(chkPerm27.Checked = True, "1", "0") & _
                         IIf(chkPerm28.Checked = True, "1", "0") & _
                         IIf(chkPerm29.Checked = True, "1", "0") & _
                         IIf(chkPerm30.Checked = True, "1", "0") & _
                         IIf(chkPerm31.Checked = True, "1", "0") & _
                         IIf(chkPerm32.Checked = True, "1", "0") & _
                         IIf(chkPerm33.Checked = True, "1", "0") & _
                         IIf(chkPerm34.Checked = True, "1", "0") & _
                         IIf(chkPerm35.Checked = True, "1", "0") & _
                         IIf(chkPerm36.Checked = True, "1", "0") & _
                         IIf(chkPerm37.Checked = True, "1", "0") & _
                         IIf(chkPerm38.Checked = True, "1", "0") & _
                         IIf(chkPerm39.Checked = True, "1", "0") & _
                         IIf(chkPerm40.Checked = True, "1", "0") & _
                         IIf(chkPerm41.Checked = True, "1", "0") & _
                         IIf(chkPerm42.Checked = True, "1", "0") & _
                         IIf(chkPerm43.Checked = True, "1", "0") & _
                         IIf(chkPerm44.Checked = True, "1", "0") & _
                         IIf(chkPerm58.Checked = True, "1", "0")

        userPermission.UpdatePermissionString(AdminPage.Master_FilmType, chkPerm45.Checked)
        userPermission.UpdatePermissionString(AdminPage.Master_FilmTypeAndSound, chkPerm46.Checked)
        userPermission.UpdatePermissionString(AdminPage.Master_Holiday, chkPerm57.Checked)
        userPermission.UpdatePermissionString(AdminPage.Ticket_FreeTicketAndPerCap, chkPerm47.Checked)
        userPermission.UpdatePermissionString(AdminPage.Ticket_FreeTicketAndPerCapByMovie, chkPerm48.Checked)
        userPermission.UpdatePermissionString(AdminPage.Ticket_TicketType, chkPerm49.Checked)
        userPermission.UpdatePermissionString(AdminPage.Ticket_TicketTypeByMovie, chkPerm50.Checked)
        userPermission.UpdatePermissionString(AdminPage.Report_FreeTicketAndPerCapAndTicketTypeSummary, chkPerm51.Checked)

        userPermission.UpdatePermissionString(AdminPage.Menu_Vpf, chkPerm52.Checked)
        userPermission.UpdatePermissionString(AdminPage.Menu_Vpf_ProblemRecord, chkPerm53.Checked)
        userPermission.UpdatePermissionString(AdminPage.Menu_Vpf_MovieDefaultSet, chkPerm54.Checked)
        userPermission.UpdatePermissionString(AdminPage.Menu_Vpf_ManageMovieSet, chkPerm55.Checked)
        userPermission.UpdatePermissionString(AdminPage.Menu_Vpf_Summary, chkPerm56.Checked)
        userPermission.UpdatePermissionString(AdminPage.Admin_SystemPolicies, chkPerm58.Checked)    'Added 10/07/2015 by Phasupong (This function is to handle old system)

        '--- Added on 09/07/2015 by Phasupong (check Spinner)---'
        lblAge.Text = ""
        lblErrorMSG.Text = ""
        If ddlTypeUser.SelectedValue = "Checker" Then
            If txtSpin.Text <> "" Then
                If CInt(txtSpin.Text) > CInt(maxspin) Or CInt(txtSpin.Text) < CInt(minspin) Then
                    lblAge.Text = "Password Age have to be in range from " & minspin & " to " & maxspin & "."
                    Exit Sub
                End If
            Else
                lblAge.Text = "Password Age have to be in range from " & minspin & " to " & maxspin & "."
                Exit Sub
            End If
        End If
        If ddlTypeUser.SelectedValue = "Administrator" Then
            If txtSpin.Text <> "" Then
                If CInt(txtSpin.Text) > CInt(maxspin) Or CInt(txtSpin.Text) < CInt(minspin) Then
                    lblAge.Text = "Password Age have to be in range from " & minspin & " to " & maxspin & "."
                    Exit Sub
                End If
            Else
                lblAge.Text = "Password Age have to be in range from " & minspin & " to " & maxspin & "."
                Exit Sub
            End If
        End If
        '--- Ended on 09/07/2015 ---'

        Dim intPresent As Integer = 0
        Dim intFormer As Integer = 0

        If ddlTypeUser.SelectedValue = "Checker" Then
            If ddlPresent.SelectedValue <> "Null" Then
                intPresent = ddlPresent.SelectedValue
            End If

            If ddlFormer.SelectedValue <> "Null" Then
                intFormer = ddlFormer.SelectedValue
            End If
        End If
        If hidMode.Value = "ADD" Then
            'If txtPassword.Text = "" And ddlTypeUser.SelectedValue = "Administrator" Then     'check password length
            '    lblErrorMSG.Text = "Passwords must be " & lblPWLength.Text & " characters and contain all of the following: uppercase letters, lowercase letters, numbers, and symbols."
            '    txtPassword.Focus()
            '    Exit Sub
            'ElseIf txtPassword.Text = "" And ddlTypeUser.SelectedValue = "Checker" Then     'check password length
            '    lblErrorMSG.Text = "Passwords must be " & lblPWLength.Text & " characters and contain at least two of the following: uppercase letters, lowercase letters, numbers, and symbols."
            '    txtPassword.Focus()
            '    Exit Sub
            'End If
            If txtPassword.Text = "" Then     'check password length
                lblErrorMSG.Text = "Passwords must be at least " & lblPWLength.Text & " characters and contain all of the following: uppercase letters, lowercase letters, numbers, and symbols."
                txtPassword.Focus()
            End If
        End If

        '  If IsNumeric(txtUserId.Text) AndAlso Not String.IsNullOrEmpty(txtPasswordEncrypt.Text) Then
        If IsNumeric(txtUserId.Text) Then
            Dim addUser As New cDatabase
            lblError.Visible = False

            ''addUser.addUser(txtUserId.Text, txtName.Text, txtPassword.Text, txtEmail.Text, txtTel.Text, ddlTypeUser.SelectedItem.Text, ddlStatus.SelectedItem.Text, userPermission, intPresent, intFormer)
            'Dim encryptPassword As String = txtPasswordEncrypt.Text
            'If Not String.IsNullOrEmpty(txtPassword.Text) Then
            '    encryptPassword = Crypto.Encrypt(txtPassword.Text)
            '    txtPasswordEncrypt.Text = encryptPassword
            '    txtPassword.Text = String.Empty
            'End If
            'addUser.addUser(txtUserId.Text, txtName.Text, encryptPassword, txtEmail.Text, txtTel.Text, ddlTypeUser.SelectedItem.Text, ddlStatus.SelectedItem.Text, userPermission, intPresent, intFormer)

            '-----------------Added on 09/07/2015 by Phasupong (new addUser, addPWDUniqueHistory)
            Dim pw_createdate As String = "old"
            Dim encryptPassword As String = txtPasswordEncrypt.Text
            If Not String.IsNullOrEmpty(txtPassword.Text) Then
                encryptPassword = Crypto.Encrypt(txtPassword.Text)
                Dim pwHist As IDataReader = cDB.GetPWUniqueHist(txtUserId.Text, encryptPassword) 'check password unique history
                pwHist.Read()
                If pwHist(0) <> 0 Then
                    lblErrorMSG.Text = "Please choose a password which doesn't exist to user password’s history."
                    lblCheckPassword.Text = ""
                    txtPassword.Text = String.Empty
                    txtPassword.Focus()
                    Exit Sub
                End If
                pwHist.Close()

                'If ddlTypeUser.SelectedValue = "Administrator" Then
                If (txtPassword.Text.Length < lblPWLength.Text) And (IsSpecialCharacters(txtPassword.Text) = True) Then     'check password length
                    lblErrorMSG.Text = "Passwords must be at least " & lblPWLength.Text & " characters."
                    lblCheckPassword.Text = ""
                    txtPassword.Focus()
                    Exit Sub
                ElseIf (txtPassword.Text.Length >= lblPWLength.Text) And (IsSpecialCharacters(txtPassword.Text) = False) Then
                    lblErrorMSG.Text = "Please choose a password with a mix of lower and upper case letters and numbers and symbols."
                    lblCheckPassword.Text = ""
                    txtPassword.Focus()
                    Exit Sub
                ElseIf txtPassword.Text.Length < lblPWLength.Text And (IsSpecialCharacters(txtPassword.Text) = False) Then
                    lblErrorMSG.Text = "Passwords must be at least " & lblPWLength.Text & " characters and contain all of the following: uppercase letters, lowercase letters, numbers, and symbols"
                    lblCheckPassword.Text = ""
                    txtPassword.Focus()
                    Exit Sub
                End If
                'End If
                'If ddlTypeUser.SelectedValue = "Checker" Then
                '    If (txtPassword.Text.Length <> lblPWLength.Text) And (IsSpecialCharacters(txtPassword.Text) = True) Then     'check password length
                '        lblErrorMSG.Text = "Passwords must be " & lblPWLength.Text & " characters."
                '        lblCheckPassword.Text = ""
                '        txtPassword.Focus()
                '        Exit Sub
                '    ElseIf (txtPassword.Text.Length = lblPWLength.Text) And (IsSpecialCharacters(txtPassword.Text) = False) Then
                '        lblErrorMSG.Text = "Please choose a password with a mix at least 2 of the following: lower case letters, upper case letters, numbers and symbols."
                '        lblCheckPassword.Text = ""
                '        txtPassword.Focus()
                '        Exit Sub
                '    ElseIf txtPassword.Text.Length <> lblPWLength.Text And (IsSpecialCharacters(txtPassword.Text) = False) Then
                '        lblErrorMSG.Text = "Passwords must be " & lblPWLength.Text & " characters and contain at least two of the following: uppercase letters, lowercase letters, numbers, and symbols."
                '        lblCheckPassword.Text = ""
                '        txtPassword.Focus()
                '        Exit Sub
                '    End If
                'End If

                'Added by Pachara S. on 20180215, check password cannot be the previous password backwords and cannot substitute only a single character in the previous password.
                Dim dtPWDUniqueHistory As DataTable = DBInterface.User.getPWDHistory(txtUserId.Text)
                Dim isSamePWD As Boolean = False
                If Not IsNothing(dtPWDUniqueHistory) Then
                    For index As Integer = 0 To (dtPWDUniqueHistory.Rows.Count() - 1)
                        Dim tmpPWDHistory As String = Crypto.Decrypt(dtPWDUniqueHistory.Rows(index).Item(0))

                        Dim checkWord As Integer = 0
                        Dim minLength As Integer
                        Dim comLength As Integer

                        If tmpPWDHistory.Length < txtPassword.Text.Length Then
                            minLength = (tmpPWDHistory.Length - 1)
                        Else
                            minLength = (txtPassword.Text.Length - 1)
                        End If

                        comLength = Math.Abs(tmpPWDHistory.Length - txtPassword.Text.Length)
                        If comLength < 2 Then
                            For indexStr As Integer = 0 To minLength
                                If Not tmpPWDHistory.Chars(indexStr) = txtPassword.Text.Chars(indexStr) Then
                                    checkWord += 1
                                End If
                            Next

                            If (checkWord = 1 And comLength = 0) Or checkWord = 0 Then
                                isSamePWD = True
                            End If
                        End If

                        If isSamePWD Then
                            lblErrorMSG.Text = "Your password cannot substitute only a single character in the previous password."
                            lblCheckPassword.Text = ""
                            txtPassword.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                'Added by Pachara S. on 20180223, check password cannot be the previous password backwords
                If Not IsNothing(dtPWDUniqueHistory) Then
                    For index As Integer = 0 To (dtPWDUniqueHistory.Rows.Count() - 1)
                        Dim tmpChkPWDHistory As String = Crypto.Decrypt(dtPWDUniqueHistory.Rows(index).Item(0))
                        Dim revText As String = StrReverse(tmpChkPWDHistory)
                        If String.Compare(revText, txtPassword.Text) = 0 Then
                            lblErrorMSG.Text = "Your password cannot be the previous password backwords."
                            lblCheckPassword.Text = ""
                            txtPassword.Focus()
                            Exit Sub
                        End If
                    Next
                End If

                'Added by Pachara S. on 20180215, check restricted password list
                Dim dtchkPWDWord As DataTable = DBInterface.User.chkPWDValidateWord(txtUserId.Text, txtPassword.Text)
                If dtchkPWDWord.Rows(0).Item(0) Then
                    lblErrorMSG.Text = "Please choose a password which doesn't exist to restricted password list."
                    lblCheckPassword.Text = ""
                    txtPassword.Focus()
                    Exit Sub
                End If

                txtPasswordEncrypt.Text = encryptPassword
                txtPassword.Text = String.Empty
                pw_createdate = "new"

                Dim saveCvDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
                addUser.addPWDUniqueHistory(txtUserId.Text, encryptPassword, Session("UserID"))
                DBInterface.User.addPWDCreateDate(txtUserId.Text, ConvertTimeToLocaltime(saveCvDatetimeNow)) 'ConvertTimeZone Added By Pachara S. on 20170615
                DBInterface.User.resetThreshold(txtUserId.Text)
            End If
            Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615

            addUser.addUser(txtUserId.Text, txtName.Text, encryptPassword, txtEmail.Text, txtTel.Text, ddlTypeUser.SelectedItem.Text, ddlStatus.SelectedItem.Text, userPermission, intPresent, intFormer, pw_createdate, CInt(txtSpin.Text), ConvertTimeToLocaltime(saveDatetimeNow))
            '-----------------Ended on 09/07/2015

            'If Session("UserID") = txtUserId.Text Then
            '    Dim dataReader As IDataReader = addUser.getUserDetail(Session("UserID"))
            '    If dataReader.Read Then
            '        Session("permission") = dataReader("user_permission")
            '    End If
            'End If

            '--- Added by Wittawat W. on 2013/04/30 : User mapping with location
            If ddlTypeUser.SelectedValue = "Checker" Then
                For i As Integer = 0 To Me.rptTheater.Items.Count - 1
                    Dim p_user_id As String = Me.txtUserId.Text
                    Dim p_theater_id As Integer = CInt(CType(Me.rptTheater.Items(i).FindControl("hdfTheaterId"), HiddenField).Value)
                    Dim p_status_flag As Boolean = CType(Me.rptTheater.Items(i).FindControl("chkTherterName"), CheckBox).Checked
                    Dim p_create_by As String = CStr(Session("UserID"))
                    DBInterface.User.UpdateUserTheater(p_user_id, p_theater_id, p_status_flag, p_create_by)
                Next
            End If
            '--- End added by Wittawat W. on 2013/04/30 : User mapping with location

            Response.Redirect("frmCTBV_AT.aspx")
        Else
            lblError.Visible = True
        End If
    End Sub

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Response.Redirect("frmCTBV_AT.aspx")
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub chkPerm01_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm01.CheckedChanged
        If chkPerm01.Checked = False Then
            chkPerm02.Checked = False
            chkPerm02.Enabled = False
            chkPerm03.Checked = False
            chkPerm03.Enabled = False
            chkPerm04.Checked = False
            chkPerm04.Enabled = False
            chkPerm05.Checked = False
            chkPerm05.Enabled = False
            chkPerm06.Checked = False
            chkPerm06.Enabled = False
        Else
            chkPerm02.Checked = True
            chkPerm02.Enabled = True
            chkPerm03.Checked = True
            chkPerm03.Enabled = True
            chkPerm04.Checked = True
            chkPerm04.Enabled = True
            chkPerm05.Checked = True
            chkPerm05.Enabled = True
            chkPerm06.Checked = True
            chkPerm06.Enabled = True
        End If
    End Sub

    Function getMaxID(ByVal UserGroupID As String) As String
        Dim wkMaxID As String
        'Dim dataReader1 As IDataReader = cDB.GetDataString("max([user_id]) as [maxUser_id]", "[tblUser]", " [usergroup_id] = '" + UserGroupID + "'")
        Dim dataReader1 As IDataReader = cDB.GetMaxUserID(" [usergroup_id] = '" + UserGroupID + "'")    'Edited 03/08/2015
        If dataReader1.Read = True Then
            wkMaxID = dataReader1("maxUser_id")
            If wkMaxID.Trim = "" Then
                wkMaxID = "0"
            End If
            wkMaxID = (CInt(wkMaxID) + 1).ToString("0000")
        Else
            If UserGroupID.Trim = "Checker" Then
                wkMaxID = "0001"
            Else
                wkMaxID = "1001"
            End If
        End If
        dataReader1.Close()
        Return wkMaxID
    End Function

    Protected Sub ddlTypeUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTypeUser.SelectedIndexChanged
        Dim wkNewID As String = ""
        If ddlTypeUser.SelectedValue = "Checker" Then

            ddlPresent.Enabled = True
            ddlFormer.Enabled = True

            chkPerm01.Enabled = False
            chkPerm02.Enabled = False
            chkPerm03.Enabled = False
            chkPerm04.Enabled = False
            chkPerm05.Enabled = False
            chkPerm06.Enabled = False
            chkPerm07.Enabled = False
            chkPerm08.Enabled = False
            chkPerm09.Enabled = False
            chkPerm10.Enabled = False
            chkPerm11.Enabled = False
            chkPerm12.Enabled = False
            chkPerm13.Enabled = False
            chkPerm14.Enabled = False
            chkPerm15.Enabled = False
            chkPerm16.Enabled = False
            chkPerm17.Enabled = False
            chkPerm18.Enabled = False
            chkPerm19.Enabled = False
            chkPerm20.Enabled = False
            chkPerm21.Enabled = False
            chkPerm22.Enabled = False
            chkPerm23.Enabled = False
            chkPerm36.Enabled = False
            chkPerm24.Enabled = False
            chkPerm25.Enabled = False
            chkPerm26.Enabled = False
            chkPerm27.Enabled = False
            chkPerm28.Enabled = False
            chkPerm37.Enabled = False
            chkPerm29.Enabled = False
            chkPerm30.Enabled = False
            chkPerm31.Enabled = False
            chkPerm32.Enabled = False
            chkPerm33.Enabled = False
            chkPerm34.Enabled = False
            chkPerm35.Enabled = False
            chkPerm38.Enabled = False
            chkPerm39.Enabled = False
            chkPerm40.Enabled = False
            chkPerm41.Enabled = False
            chkPerm42.Enabled = False
            chkPerm43.Enabled = False
            chkPerm44.Enabled = False

            chkPerm01.Checked = False
            chkPerm02.Checked = False
            chkPerm03.Checked = False
            chkPerm04.Checked = False
            chkPerm05.Checked = False
            chkPerm06.Checked = False
            chkPerm07.Checked = False
            chkPerm08.Checked = False
            chkPerm09.Checked = False
            chkPerm10.Checked = False
            chkPerm11.Checked = False
            chkPerm12.Checked = False
            chkPerm13.Checked = False
            chkPerm14.Checked = False
            chkPerm15.Checked = False
            chkPerm16.Checked = False
            chkPerm17.Checked = False
            chkPerm18.Checked = False
            chkPerm19.Checked = False
            chkPerm20.Checked = False
            chkPerm21.Checked = False
            chkPerm22.Checked = False
            chkPerm23.Checked = False
            chkPerm36.Checked = False
            chkPerm24.Checked = False
            chkPerm25.Checked = False
            chkPerm26.Checked = False
            chkPerm27.Checked = False
            chkPerm28.Checked = False
            chkPerm37.Checked = False
            chkPerm29.Checked = False
            chkPerm30.Checked = False
            chkPerm31.Checked = False
            chkPerm32.Checked = False
            chkPerm33.Checked = False
            chkPerm34.Checked = False
            chkPerm35.Checked = False
            chkPerm38.Checked = False
            chkPerm39.Checked = False
            chkPerm40.Checked = False
            chkPerm41.Checked = False
            chkPerm42.Checked = False
            chkPerm43.Checked = False
            chkPerm44.Checked = False

            chkPerm08.Enabled = False
            chkPerm45.Enabled = False
            chkPerm46.Enabled = False
            chkPerm47.Enabled = False
            chkPerm48.Enabled = False
            chkPerm49.Enabled = False
            chkPerm50.Enabled = False
            chkPerm51.Enabled = False
            chkPerm52.Enabled = False
            chkPerm53.Enabled = False
            chkPerm54.Enabled = False
            chkPerm55.Enabled = False
            chkPerm56.Enabled = False
            chkPerm57.Enabled = False
            chkPerm58.Enabled = False   'Added 10/07/2015 System Policies

            chkPerm08.Checked = False
            chkPerm45.Checked = False
            chkPerm46.Checked = False
            chkPerm47.Checked = False
            chkPerm48.Checked = False
            chkPerm49.Checked = False
            chkPerm50.Checked = False
            chkPerm51.Checked = False
            chkPerm52.Checked = False
            chkPerm53.Checked = False
            chkPerm54.Checked = False
            chkPerm55.Checked = False
            chkPerm56.Checked = False
            chkPerm57.Checked = False
            chkPerm58.Checked = False   'Added 10/07/2015 System Policies

            wkNewID = getMaxID("Checker")
            'Panel1.Enabled = False
            'Panel2.Enabled = True
        Else
            'chkPerm01.Enabled = True
            'chkPerm07.Enabled = True
            'chkPerm08.Enabled = True
            'chkPerm09.Enabled = True
            'chkPerm10.Enabled = True
            'chkPerm11.Enabled = True

            'EED

            ddlPresent.Enabled = False
            ddlFormer.Enabled = False


            chkPerm01.Enabled = True
            chkPerm02.Enabled = True
            chkPerm03.Enabled = True
            chkPerm04.Enabled = True
            chkPerm05.Enabled = True
            chkPerm06.Enabled = True
            chkPerm07.Enabled = True
            chkPerm08.Enabled = True
            chkPerm09.Enabled = True
            chkPerm10.Enabled = True
            chkPerm11.Enabled = True
            chkPerm12.Enabled = True
            chkPerm13.Enabled = True
            chkPerm14.Enabled = True
            chkPerm15.Enabled = True
            chkPerm16.Enabled = True
            chkPerm17.Enabled = True
            chkPerm18.Enabled = True
            chkPerm19.Enabled = True
            chkPerm20.Enabled = True
            chkPerm21.Enabled = True
            chkPerm22.Enabled = True
            chkPerm23.Enabled = True
            chkPerm36.Enabled = True
            chkPerm24.Enabled = True
            chkPerm25.Enabled = True
            chkPerm26.Enabled = True
            chkPerm27.Enabled = True
            chkPerm28.Enabled = True
            chkPerm37.Enabled = True
            chkPerm29.Enabled = True
            chkPerm30.Enabled = True
            chkPerm31.Enabled = True
            chkPerm32.Enabled = True
            chkPerm33.Enabled = True
            chkPerm34.Enabled = True
            chkPerm35.Enabled = True
            chkPerm38.Enabled = True
            chkPerm39.Enabled = True
            chkPerm40.Enabled = True
            chkPerm41.Enabled = True
            chkPerm42.Enabled = True
            chkPerm43.Enabled = True
            chkPerm44.Enabled = True

            chkPerm01.Checked = True
            chkPerm02.Checked = True
            chkPerm03.Checked = True
            chkPerm04.Checked = True
            chkPerm05.Checked = True
            chkPerm06.Checked = True
            chkPerm07.Checked = True
            chkPerm08.Checked = True
            chkPerm09.Checked = True
            chkPerm10.Checked = True
            chkPerm11.Checked = True
            chkPerm12.Checked = True
            chkPerm13.Checked = True
            chkPerm14.Checked = True
            chkPerm15.Checked = True
            chkPerm16.Checked = True
            chkPerm17.Checked = True
            chkPerm18.Checked = True
            chkPerm19.Checked = True
            chkPerm20.Checked = True
            chkPerm21.Checked = True
            chkPerm22.Checked = True
            chkPerm23.Checked = True
            chkPerm36.Checked = True
            chkPerm24.Checked = True
            chkPerm25.Checked = True
            chkPerm26.Checked = True
            chkPerm27.Checked = True
            chkPerm28.Checked = True
            chkPerm37.Checked = True
            chkPerm29.Checked = True
            chkPerm30.Checked = True
            chkPerm31.Checked = True
            chkPerm32.Checked = True
            chkPerm33.Checked = True
            chkPerm34.Checked = True
            chkPerm35.Checked = True
            chkPerm38.Checked = True
            chkPerm39.Checked = True
            chkPerm40.Checked = True
            chkPerm41.Checked = True
            chkPerm42.Checked = True
            chkPerm43.Checked = True
            chkPerm44.Checked = True

            chkPerm08.Enabled = True
            chkPerm45.Enabled = True
            chkPerm46.Enabled = True
            chkPerm47.Enabled = True
            chkPerm48.Enabled = True
            chkPerm49.Enabled = True
            chkPerm50.Enabled = True
            chkPerm51.Enabled = True
            chkPerm52.Enabled = True
            chkPerm53.Enabled = True
            chkPerm54.Enabled = True
            chkPerm55.Enabled = True
            chkPerm56.Enabled = True
            chkPerm57.Enabled = True
            chkPerm58.Enabled = True   'Added 10/07/2015 System Policies

            chkPerm08.Checked = True
            chkPerm45.Checked = True
            chkPerm46.Checked = True
            chkPerm47.Checked = True
            chkPerm48.Checked = True
            chkPerm49.Checked = True
            chkPerm50.Checked = True
            chkPerm51.Checked = True
            chkPerm52.Checked = True
            chkPerm53.Checked = True
            chkPerm54.Checked = True
            chkPerm55.Checked = True
            chkPerm56.Checked = True
            chkPerm57.Checked = True
            chkPerm58.Checked = True   'Added 10/07/2015 System Policies

            wkNewID = getMaxID("Administrator")
            'Panel1.Enabled = False
            'Panel2.Enabled = True
        End If
        txtUserId.Text = wkNewID

        '--- Added on 09/07/2015 by Phasupong---'
        Dim drPWHint As IDataReader = cDB.GetPWHint(ddlTypeUser.SelectedValue.ToString())
        Dim drPWLength As IDataReader = cDB.GetPWLength(ddlTypeUser.SelectedValue.ToString())
        drPWHint.Read()
        drPWLength.Read()
        If ddlTypeUser.SelectedValue = "Checker" Then
            lblHint.Text = drPWHint("PasswordHint")
            txtPassword.MaxLength = drPWLength("PWDMaxLength")
            lblPWLength.Text = drPWLength("PWDMinLength")
            lblErrorMSG.Text = ""
            lblAge.Text = ""
        End If
        If ddlTypeUser.SelectedValue = "Administrator" Then
            lblHint.Text = drPWHint("PasswordHint")
            txtPassword.MaxLength = drPWLength("PWDMaxLength")
            lblPWLength.Text = drPWLength("PWDMinLength")
            lblErrorMSG.Text = ""
            lblAge.Text = ""
        End If
        drPWHint.Close()
        drPWLength.Close()
        Dim drPWDAge As IDataReader = cDB.GetMinMaxPWDAge(ddlTypeUser.SelectedValue) 'added by Phasupong
        drPWDAge.Read()
        maxspin = drPWDAge("AgeMax")
        minspin = drPWDAge("AgeMin")
        drPWDAge.Close()
        '--- Ended on 09/07/2015 ---'
    End Sub

    Protected Sub chkPerm07_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm07.CheckedChanged

        chkPerm12.Checked = False
        chkPerm13.Checked = False
        chkPerm14.Checked = False

        chkPerm12.Enabled = False
        chkPerm13.Enabled = False
        chkPerm14.Enabled = False

        If chkPerm07.Checked Then
            chkPerm12.Checked = True
            chkPerm13.Checked = True
            chkPerm14.Checked = True

            chkPerm12.Enabled = True
            chkPerm13.Enabled = True
            chkPerm14.Enabled = True
        End If
    End Sub

    Protected Sub chkPerm11_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm11.CheckedChanged
        chkPerm15.Checked = False
        chkPerm16.Checked = False
        chkPerm17.Checked = False
        chkPerm18.Checked = False
        chkPerm19.Checked = False
        chkPerm20.Checked = False
        chkPerm21.Checked = False
        chkPerm22.Checked = False
        chkPerm23.Checked = False
        chkPerm36.Checked = False
        chkPerm24.Checked = False
        chkPerm25.Checked = False
        chkPerm33.Checked = False
        chkPerm34.Checked = False
        chkPerm35.Checked = False
        chkPerm51.Checked = False

        chkPerm15.Enabled = False
        chkPerm16.Enabled = False
        chkPerm17.Enabled = False
        chkPerm18.Enabled = False
        chkPerm19.Enabled = False
        chkPerm20.Enabled = False
        chkPerm21.Enabled = False
        chkPerm22.Enabled = False
        chkPerm23.Enabled = False
        chkPerm36.Enabled = False
        chkPerm24.Enabled = False
        chkPerm25.Enabled = False
        chkPerm33.Enabled = False
        chkPerm34.Enabled = False
        chkPerm35.Enabled = False
        chkPerm51.Enabled = False

        If chkPerm11.Checked Then
            chkPerm15.Checked = True
            chkPerm16.Checked = True
            chkPerm17.Checked = True
            chkPerm18.Checked = True
            chkPerm19.Checked = True
            chkPerm20.Checked = True
            chkPerm21.Checked = True
            chkPerm22.Checked = True
            chkPerm23.Checked = True
            chkPerm36.Checked = True
            chkPerm24.Checked = True
            chkPerm25.Checked = True
            chkPerm33.Checked = True
            chkPerm34.Checked = True
            chkPerm35.Checked = True
            chkPerm51.Checked = True

            chkPerm15.Enabled = True
            chkPerm16.Enabled = True
            chkPerm17.Enabled = True
            chkPerm18.Enabled = True
            chkPerm19.Enabled = True
            chkPerm20.Enabled = True
            chkPerm21.Enabled = True
            chkPerm22.Enabled = True
            chkPerm23.Enabled = True
            chkPerm36.Enabled = True
            chkPerm24.Enabled = True
            chkPerm25.Enabled = True
            chkPerm33.Enabled = True
            chkPerm34.Enabled = True
            chkPerm35.Enabled = True
            chkPerm51.Enabled = True
        End If
    End Sub

    Protected Sub chkPerm09_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm09.CheckedChanged
        chkPerm26.Checked = False
        chkPerm27.Checked = False
        chkPerm28.Checked = False
        chkPerm37.Checked = False
        chkPerm45.Checked = False
        chkPerm46.Checked = False
        chkPerm57.Checked = False

        chkPerm26.Enabled = False
        chkPerm27.Enabled = False
        chkPerm28.Enabled = False
        chkPerm37.Enabled = False
        chkPerm45.Enabled = False
        chkPerm46.Enabled = False
        chkPerm57.Enabled = False

        If chkPerm09.Checked Then
            chkPerm26.Checked = True
            chkPerm27.Checked = True
            chkPerm28.Checked = True
            chkPerm37.Checked = True
            chkPerm45.Checked = True
            chkPerm46.Checked = True
            chkPerm57.Checked = True

            chkPerm26.Enabled = True
            chkPerm27.Enabled = True
            chkPerm28.Enabled = True
            chkPerm37.Enabled = True
            chkPerm45.Enabled = True
            chkPerm46.Enabled = True
            chkPerm57.Enabled = True
        End If
    End Sub

    Protected Sub chkPerm10_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm10.CheckedChanged
        chkPerm29.Checked = False
        chkPerm30.Checked = False
        chkPerm31.Checked = False
        chkPerm32.Checked = False
        chkPerm38.Checked = False
        chkPerm39.Checked = False
        chkPerm40.Checked = False
        chkPerm41.Checked = False
        chkPerm42.Checked = False
        chkPerm43.Checked = False
        chkPerm44.Checked = False
        chkPerm58.Checked = False   'Added 10/07/2015 System Policies

        chkPerm29.Enabled = False
        chkPerm30.Enabled = False
        chkPerm31.Enabled = False
        chkPerm32.Enabled = False
        chkPerm38.Enabled = False
        chkPerm39.Enabled = False
        chkPerm40.Enabled = False
        chkPerm41.Enabled = False
        chkPerm42.Enabled = False
        chkPerm43.Enabled = False
        chkPerm44.Enabled = False
        chkPerm58.Enabled = False   'Added 10/07/2015 System Policies

        If chkPerm10.Checked Then
            chkPerm29.Checked = True
            chkPerm30.Checked = True
            chkPerm31.Checked = True
            chkPerm32.Checked = True
            chkPerm38.Checked = True
            chkPerm39.Checked = True
            chkPerm40.Checked = True
            chkPerm41.Checked = True
            chkPerm42.Checked = True
            chkPerm43.Checked = True
            chkPerm44.Checked = True
            chkPerm58.Checked = True   'Added 10/07/2015 System Policies

            chkPerm29.Enabled = True
            chkPerm30.Enabled = True
            chkPerm31.Enabled = True
            chkPerm32.Enabled = True
            chkPerm38.Enabled = True
            chkPerm39.Enabled = True
            chkPerm40.Enabled = True
            chkPerm41.Enabled = True
            chkPerm42.Enabled = True
            chkPerm43.Enabled = True
            chkPerm44.Enabled = True
            chkPerm58.Enabled = True   'Added 10/07/2015 System Policies
        End If
    End Sub

    Protected Sub chkPerm44_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm44.CheckedChanged
        chkPerm32.Checked = False
        chkPerm38.Checked = False
        chkPerm39.Checked = False
        chkPerm40.Checked = False
        chkPerm41.Checked = False
        chkPerm42.Checked = False

        chkPerm32.Enabled = False
        chkPerm38.Enabled = False
        chkPerm39.Enabled = False
        chkPerm40.Enabled = False
        chkPerm41.Enabled = False
        chkPerm42.Enabled = False

        If chkPerm44.Checked Then
            chkPerm32.Checked = True
            chkPerm38.Checked = True
            chkPerm39.Checked = True
            chkPerm40.Checked = True
            chkPerm41.Checked = True
            chkPerm42.Checked = True

            chkPerm32.Enabled = True
            chkPerm38.Enabled = True
            chkPerm39.Enabled = True
            chkPerm40.Enabled = True
            chkPerm41.Enabled = True
            chkPerm42.Enabled = True
        End If
    End Sub

    Protected Sub chkPerm08_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm08.CheckedChanged
        chkPerm47.Enabled = chkPerm08.Checked
        chkPerm48.Enabled = chkPerm08.Checked
        chkPerm49.Enabled = chkPerm08.Checked
        chkPerm50.Enabled = chkPerm08.Checked

        chkPerm47.Checked = chkPerm08.Checked
        chkPerm48.Checked = chkPerm08.Checked
        chkPerm49.Checked = chkPerm08.Checked
        chkPerm50.Checked = chkPerm08.Checked
    End Sub

    Protected Sub chkPerm52_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkPerm52.CheckedChanged
        chkPerm53.Checked = False
        chkPerm53.Enabled = False
        chkPerm54.Checked = False
        chkPerm54.Enabled = False
        chkPerm55.Checked = False
        chkPerm55.Enabled = False
        chkPerm56.Checked = False
        chkPerm56.Enabled = False
        If chkPerm52.Checked Then
            chkPerm53.Checked = True
            chkPerm53.Enabled = True
            chkPerm54.Checked = True
            chkPerm54.Enabled = True
            chkPerm55.Checked = True
            chkPerm55.Enabled = True
            chkPerm56.Checked = True
            chkPerm56.Enabled = True
        End If
    End Sub

    Private Sub RefreshTheater(ByVal dtb As DataTable)
        If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
            dtb.Columns.Add("sep", GetType(String))
            For i As Integer = 0 To dtb.Rows.Count - 1
                dtb.Rows(i)("sep") = IIf((i + 1) Mod 5 = 0, "</tr><tr>", String.Empty)
            Next
        End If

        Me.rptTheater.DataSource = dtb
        Me.rptTheater.DataBind()
    End Sub

    Private Function IsSpecialCharacters(ByVal stringToTest As String) As Boolean
        Dim check1 As Boolean = False
        Dim check2 As Boolean = False
        Dim check3 As Boolean = False
        Dim check4 As Boolean = False
        Dim finalcheck As Boolean = False
        Dim charSet1 As String = "[a-z]"
        Dim charSet2 As String = "[A-Z]"
        Dim charSet3 As String = "[0-9]"
        Dim charSet4 As String = "[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}\p{Pc}]"
        Dim re1 As Regex = New Regex(charSet1)
        Dim re2 As Regex = New Regex(charSet2)
        Dim re3 As Regex = New Regex(charSet3)
        Dim re4 As Regex = New Regex(charSet4)


        'If ddlTypeUser.SelectedValue = "Administrator" Then
        '    If re1.IsMatch(stringToTest) Then
        '        check1 = True
        '    End If
        '    If re2.IsMatch(stringToTest) Then
        '        check2 = True
        '    End If
        '    If re3.IsMatch(stringToTest) Then
        '        check3 = True
        '    End If
        '    If re4.IsMatch(stringToTest) Then
        '        check4 = True
        '    End If

        '    If (check1 And check2 And check3 And check4) Then
        '        finalcheck = True
        '    End If
        'End If

        'If ddlTypeUser.SelectedValue = "Checker" Then
        '    If re1.IsMatch(stringToTest) Then
        '        check1 = True
        '    End If
        '    If re2.IsMatch(stringToTest) Then
        '        check2 = True
        '    End If
        '    If re3.IsMatch(stringToTest) Then
        '        check3 = True
        '    End If
        '    If re4.IsMatch(stringToTest) Then
        '        check4 = True
        '    End If

        '    If (check1 And check2) Then
        '        finalcheck = True
        '    End If
        '    If (check1 And check3) Then
        '        finalcheck = True
        '    End If
        '    If (check1 And check4) Then
        '        finalcheck = True
        '    End If
        '    If (check2 And check3) Then
        '        finalcheck = True
        '    End If
        '    If (check2 And check4) Then
        '        finalcheck = True
        '    End If
        '    If (check3 And check4) Then
        '        finalcheck = True
        '    End If
        'End If

        'Comment & Edited by Pachara S. on 20180214
        If re1.IsMatch(stringToTest) Then
            check1 = True
        End If
        If re2.IsMatch(stringToTest) Then
            check2 = True
        End If
        If re3.IsMatch(stringToTest) Then
            check3 = True
        End If
        If re4.IsMatch(stringToTest) Then
            check4 = True
        End If

        If (check1 And check2 And check3 And check4) Then
            finalcheck = True
        End If

        Return finalcheck
    End Function

    Protected Sub checkBoxPassword_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkBoxPassword.CheckedChanged
        Dim ss As String = txtPassword.Text

        If checkBoxPassword.Checked Then
            txtPassword.TextMode = TextBoxMode.SingleLine
        Else
            txtPassword.TextMode = TextBoxMode.Password
        End If

        txtPassword.Attributes.Add("value", ss)
    End Sub
End Class
