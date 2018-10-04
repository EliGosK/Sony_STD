Option Strict On

Imports System.Collections.Generic
Imports System.Web.Security

Namespace Form
    Partial Public Class FrmReportCheckerWageParam
        Inherits Page

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Response.Redirect("frmCTBV_RC_Menu.aspx")
        End Sub

        Protected Sub BtnOpenSeparateCheckerClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpenSeparateChecker.Click
            If dtpStartDate.Text.Trim() = String.Empty OrElse dtpEndDate.Text.Trim() = String.Empty Then
                lblerror.Visible = True
            Else
                Dim list As New List(Of String)
                For i As Integer = 0 To rptList.Items.Count - 1
                    If CType(rptList.Items(i).FindControl("chkName"), CheckBox).Checked Then
                        list.Add("frmReportCheckerWage.aspx?userid=" & CType(rptList.Items(i).FindControl("hdfId"), HiddenField).Value & "&datefrom=" & dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&dateto=" & dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd"))
                    End If
                Next
                If list.Count > 0 Then
                    For i As Integer = 0 To list.Count - 1
                        Response.Write("<script>window.open('" & list(i) & "','_blank')</script>")
                    Next
                End If
            End If
        End Sub

        Protected Sub BtnSubmitClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
            If dtpStartDate.Text.Trim() = String.Empty OrElse dtpEndDate.Text.Trim() = String.Empty Then
                lblerror.Visible = True
            Else
                Dim userList As String = String.Empty
                For i As Integer = 0 To rptList.Items.Count - 1
                    If CType(rptList.Items(i).FindControl("chkName"), CheckBox).Checked Then
                        userList += "," + CType(rptList.Items(i).FindControl("hdfId"), HiddenField).Value
                    End If
                Next
                If Not String.IsNullOrEmpty(userList) Then
                    userList = userList.Substring(1)
                    Response.Redirect("frmReportCheckerWage.aspx?userid=" & userList & "&datefrom=" & dtpStartDate.SelectedDate.Value.ToString("yyyyMMdd") & "&dateto=" & dtpEndDate.SelectedDate.Value.ToString("yyyyMMdd"))
                End If
            End If
        End Sub

        Protected Sub BtnTypeSelectAllClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypeSelectAll.Click
            CheckType(True)
        End Sub

        Protected Sub BtnTypeSelectNoneClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTypeSelectNone.Click
            CheckType(False)
        End Sub

        Protected Sub ImbOutClick(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles imbOut.Click
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectToLoginPage()
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            'CheckPermission(AdminPage.Report_FreeTicketAndPerCapAndTicketTypeSummary, True)
            lblerror.Visible = False
            Dim dtb As DataTable = SDTCommon.DBInterface.User.SelectActiveChecker()
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("sep", GetType(String))
                For i As Integer = 0 To dtb.Rows.Count - 1
                    dtb.Rows(i)("sep") = IIf((i + 1) Mod 4 = 0, "</tr><tr>", String.Empty)
                Next
            End If

            rptList.DataSource = dtb
            rptList.DataBind()
        End Sub

#End Region

#Region "Methods"

        Private Sub CheckType(ByVal checkAll As Boolean)
            For i As Integer = 0 To rptList.Items.Count - 1
                CType(rptList.Items(i).FindControl("chkName"), CheckBox).Checked = checkAll
            Next
        End Sub

#End Region

    End Class
End Namespace