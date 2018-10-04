Imports Web.Data
Imports System.Web.Security
Partial Public Class frmCTBV_AT_MessageNew
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Private Sub Page_PreRender(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.PreRender
        Dim i As Integer = CInt(ViewState("SetCount"))
        If i = 0 Then
            i = i + 1
            ViewState("SetCount") = i.ToString
        Else

            'If (ViewState("chkAll") Is Nothing) Then
            Dim wkBool As Boolean
            wkBool = True
            For Each row As GridViewRow In GridView1.Rows
                ' Access the CheckBox 
                Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
                If cb.Checked = False Then
                    wkBool = False
                End If
            Next
            chkCheckAll.Checked = wkBool
            'Else

            'If chkCheckAll.Checked Then
            '    For Each row As GridViewRow In GridView1.Rows
            '        ' Access the CheckBox 
            '        Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
            '        If cb IsNot Nothing Then
            '            cb.Checked = True
            '        End If
            '    Next
            'Else
            '    For Each row As GridViewRow In GridView1.Rows
            '        ' Access the CheckBox 
            '        Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
            '        If cb IsNot Nothing Then
            '            cb.Checked = False
            '        End If
            '    Next
            'End If


            'End If


        End If
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        txtTime.Text = Now.ToString("ddd dd-MMM-yyyy a\t h:mm tt")

        If Not IsPostBack Then
            For Each row As GridViewRow In GridView1.Rows
                ' Access the CheckBox 
                Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
                If cb IsNot Nothing Then
                    cb.Checked = True
                End If
            Next
            chkCheckAll.Checked = True

        Else
            ViewState("SetCount") = "0"

        End If
    End Sub

    Protected Sub chkCheckAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkCheckAll.CheckedChanged

        If chkCheckAll.Checked Then
            For Each row As GridViewRow In GridView1.Rows
                ' Access the CheckBox 
                Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
                If cb IsNot Nothing Then
                    cb.Checked = True
                End If
            Next
        Else
            For Each row As GridViewRow In GridView1.Rows
                ' Access the CheckBox 
                Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
                If cb IsNot Nothing Then
                    cb.Checked = False
                End If
            Next
        End If
      

    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
        If txtQue.Text.Trim <> "" Then
            Dim wkQue As String = txtQue.Text.Replace(vbCrLf, "</br>")
            cDB.updateSQLNow("DELETE FROM [tblMessage_Answer]")
            cDB.updateSQLNow("DELETE FROM [tblMessage_Question]")
            cDB.InsertMessageQuesion(1, wkQue, Session("UserID"))
            Dim IDataReader1 As IDataReader = cDB.GetDataString(" count(*) as Sumtheater ", "[tblTheater]", " [theater_status] = 'Enabled'")
            IDataReader1.Read()
            Dim wkSum As Integer = IDataReader1("Sumtheater")
            IDataReader1.Close()

            'new
            Dim dr As GridViewRow
            Dim index As Integer = GridView1.SelectedIndex
            For Each dr In GridView1.Rows

                If index = -1 Then
                    index = 0
                End If

                Dim Batched As Label = CType(GridView1.Rows(index).FindControl("lblTheaterId"), Label)

                Dim RowCheckBox As CheckBox = CType(GridView1.Rows(index).FindControl("RowIDCheckBox"), CheckBox)
                If RowCheckBox.Checked Then
                    cDB.InsertMessageAnswer(1, Batched.Text, Session("UserID"))
                End If

                index += 1

            Next
            'Response.Redirect("Company_Main.aspx")
            'end new


            'Dim readUserChecker As IDataReader = cDB.GetDataString("[theater_id]", "[tblTheater]", " [theater_status] = 'Enabled'")
            'While (readUserChecker.Read())
            '    cDB.InsertMessageAnswer(1, readUserChecker("theater_id"), Session("UserID"))
            'End While
            'readUserChecker.Close()
        Else
            Response.Write("<script language = 'javascript'>alert('Please input message.')</script> ")
        End If
        Response.Redirect("frmCTBV_AT_Message.aspx")
    End Sub

    'Protected Sub RowIDCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim wkBool As Boolean
    '    wkBool = True
    '    For Each row As GridViewRow In GridView1.Rows
    '        ' Access the CheckBox 
    '        Dim cb As CheckBox = DirectCast(row.FindControl("RowIDCheckBox"), CheckBox)
    '        If cb.Checked = False Then
    '            wkBool = False
    '        End If
    '    Next
    '    chkCheckAll.Checked = wkBool
    'End Sub
  
   
End Class