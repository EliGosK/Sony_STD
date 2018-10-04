Imports Web.Data
Imports System.Web.Security
Partial Public Class frmCTBV_AT_LateShow
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        Try
            'Put user code to initialize the page here
            If Mid(Session("permission"), 32, 1) = "0" Then
                Response.Redirect("InfoPage.aspx")
            End If

            If Not IsPostBack Then
                ViewState("StatusSave") = "START"
                ManageData()
                ViewState("StatusSave") = "INSERT"
                
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

        'If ViewState("StatusSave") = "UPDATE" Then
        imbDelete.OnClientClick = "return confirm('Do you want to delete this data?')"
        'End If


    End Sub

    Protected Sub imbSaveClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSaveClose.Click
        Try
            Dim wkTimeFrom As String = ""
            Dim wkTimeTo As String = ""
            Dim wkExpense As String = ""
            If txtTimeFrom.Text.Trim = "" Then
                wkTimeFrom = ""
            Else
                wkTimeFrom = "1"
            End If

            If txtTimeTo.Text.Trim = "" Then
                wkTimeTo = ""
            Else
                wkTimeTo = "1"
            End If

            If txtExpense.Text.Trim = "" Or txtExpense.Text.Trim = "0.00" Then
                wkExpense = ""
            Else
                wkExpense = "1"
            End If

            If wkTimeFrom = "" Or wkTimeTo = "" Or wkExpense = "" Then
                lblError.Text = "Please check require flield (*)"
            Else
                lblError.Text = ""
                ManageData()
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try

    End Sub

    Sub ManageData()
        Dim wkSQL As String = ""
      
        Select Case ViewState("StatusSave").ToString

            Case "INSERT"
                Dim wkTimeFrom As String = txtTimeFrom.Text.Substring(0, 2)
                wkTimeFrom += txtTimeFrom.Text.Substring(3, 2)


                Dim wkTimeTo As String = txtTimeTo.Text.Substring(0, 2)
                wkTimeTo += txtTimeTo.Text.Substring(3, 2)


                Dim TimeFrom As Integer = Convert.ToInt32(wkTimeFrom)
                Dim TimeTo As Integer = Convert.ToInt32(wkTimeTo)

                If TimeFrom > 2359 Or TimeTo > 2359 Then
                    lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Not correct!"
                Else

                    If TimeFrom <= 559 Then
                        TimeFrom = TimeFrom + 2400
                    End If

                    If TimeTo <= 559 Then
                        TimeTo = TimeTo + 2400
                    End If

                    If TimeTo <= TimeFrom Then
                        lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Not correct!"
                    ElseIf CheckTime(TimeFrom, TimeTo) Then

                        Dim maxID As Integer
                        Dim drMaxID As IDataReader = cDB.GetDataAll("SELECT MAX(show_seq_no) as MAXshow_seq_no FROM tblMovie_Late_Show")
                        If drMaxID.Read Then
                            maxID = Format(cDB.CheckIsNullInteger(drMaxID(0)), "###0")
                            If Not maxID > 0 Then
                                maxID = 0
                            End If
                        Else
                            maxID = 0
                        End If
                        maxID = maxID + 1
                        cDB.MovieLateShowInsert(maxID, wkTimeFrom, wkTimeTo, Format(Convert.ToDecimal(txtExpense.Text.Trim()), "###0.00"), Now, Session("UserID").ToString, Now, Session("UserID").ToString)
                        ViewState("StatusSave") = "START"
                        ManageData()
                    Else
                        lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Exist in database!"
                    End If
                End If


               

            Case "UPDATE"
                Dim wkTimeFrom As String = txtTimeFrom.Text.Substring(0, 2)
                wkTimeFrom += txtTimeFrom.Text.Substring(3, 2)


                Dim wkTimeTo As String = txtTimeTo.Text.Substring(0, 2)
                wkTimeTo += txtTimeTo.Text.Substring(3, 2)


                Dim TimeFrom As Integer = Convert.ToInt32(wkTimeFrom)
                Dim TimeTo As Integer = Convert.ToInt32(wkTimeTo)

                If TimeFrom > 2359 Or TimeTo > 2359 Then
                    lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Not correct!"
                Else
                    If TimeFrom <= 559 Then
                        TimeFrom = TimeFrom + 2400
                    End If

                    If TimeTo <= 559 Then
                        TimeTo = TimeTo + 2400
                    End If

                    If TimeTo <= TimeFrom Then
                        lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Not correct!"
                    ElseIf CheckTime(TimeFrom, TimeTo) Then
                        cDB.MovieLateShowUpdate(ViewState("SeqNo"), wkTimeFrom, wkTimeTo, Format(Convert.ToDecimal(txtExpense.Text.Trim()), "###0.00"), Now, Session("UserID").ToString)
                        ViewState("StatusSave") = "START"
                        ManageData()
                    Else
                        lblError.Text = txtTimeFrom.Text & " to " & txtTimeTo.Text & " Exist in database!"
                    End If
                End If

            Case "DELETE"
                wkSQL = "DELETE FROM [tblMovie_Late_Show] WHERE [show_seq_no] = " & ViewState("SeqNo")
                cDB.GetDataAll(wkSQL)
                ViewState("StatusSave") = "START"
                ManageData()
            Case Else
                'txtTimeFrom.Text = ""
                'txtTimeTo.Text = ""
                'txtExpense.Text = ""
                txtTimeFrom.Text = "00:00"
                txtTimeTo.Text = "00:00"
                txtExpense.Text = "0.00"
                GridView1.DataBind()
                ViewState("StatusSave") = "INSERT"
                imbDelete.Visible = False
                lblError.Text = ""
        End Select
    End Sub
    Function CheckTime(ByVal paTimeFrom As Integer, ByVal paTimeTo As Integer) As Boolean
        Dim wkRe As Boolean = True
        Dim wkSeqNo As Integer
        Dim wkTimeFrom, wkTimeTo As Integer

        Dim drTime As IDataReader
        If ViewState("StatusSave") = "INSERT" Then
            drTime = cDB.GetDataAll("SELECT [show_seq_no], [show_time_from], [show_time_to] FROM [tblMovie_Late_Show]")
        ElseIf ViewState("StatusSave") = "UPDATE" Then
            Dim SQLCheckUpdate As String = "SELECT [show_seq_no], [show_time_from], [show_time_to] FROM [tblMovie_Late_Show] WHERE [show_seq_no] <> " + ViewState("SeqNo").ToString
            drTime = cDB.GetDataAll(SQLCheckUpdate)
        Else
            drTime = cDB.GetDataAll("SELECT [show_seq_no], [show_time_from], [show_time_to] FROM [tblMovie_Late_Show]")
        End If

        While drTime.Read()
            wkSeqNo = drTime("show_seq_no")
            wkTimeFrom = Convert.ToInt32(drTime("show_time_from"))
            wkTimeTo = Convert.ToInt32(drTime("show_time_to"))

            If wkTimeFrom <= 559 Then
                wkTimeFrom = wkTimeFrom + 2400
            End If

            If wkTimeTo <= 559 Then
                wkTimeTo = wkTimeTo + 2400
            End If

            If paTimeFrom = wkTimeFrom Then
                wkRe = False
            ElseIf paTimeFrom = wkTimeTo Then
                wkRe = False
            ElseIf paTimeTo = wkTimeFrom Then
                wkRe = False
            ElseIf paTimeTo = wkTimeTo Then
                wkRe = False
            ElseIf paTimeFrom > wkTimeFrom And paTimeFrom < wkTimeTo Then
                wkRe = False
            ElseIf paTimeTo > wkTimeFrom And paTimeTo < wkTimeTo Then
                wkRe = False
            ElseIf wkTimeFrom > paTimeFrom And wkTimeFrom < paTimeTo Then
                wkRe = False
            ElseIf wkTimeTo > paTimeFrom And wkTimeTo < paTimeTo Then
                wkRe = False
            Else
                'Return True
            End If

        End While
        'If drTime.Read = False Then
        '    Return True
        'End If
        drTime.Close()

        Return wkRe

    End Function

    Protected Sub imbCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCancel.Click
        Try
            ViewState("StatusSave") = "START"
            ManageData()
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow

        ViewState("SeqNo") = GridView1.SelectedValue
        txtTimeFrom.Text = row.Cells(2).Text
        txtTimeTo.Text = row.Cells(3).Text
        txtExpense.Text = row.Cells(4).Text
        ViewState("StatusSave") = "UPDATE"
        imbDelete.Visible = True
      
    End Sub

    Protected Sub imbDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbDelete.Click
        ViewState("StatusSave") = "DELETE"
        ManageData()
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub
End Class