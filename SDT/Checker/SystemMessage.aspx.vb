Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker

    Partial Public Class SystemMessage
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnMainMenuClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnMainMenu.Click
            Redirect(PageName.ActionMenu)
        End Sub
        Protected Sub BtnSaveClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
            If RadioButton1.Checked Then
                AnswerMessage(1, "")
            ElseIf RadioButton2.Checked Then
                AnswerMessage(2, "")
            ElseIf RadioButton3.Checked Then
                AnswerMessage(3, "")
            ElseIf RadioButton4.Checked Then
                AnswerMessage(4, "")
            ElseIf RadioButton5.Checked Then
                AnswerMessage(5, txtAnswer.Text.Trim.Replace(vbCrLf, "</br>"))
            End If
            Redirect(PageName.ActionMenu)
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            CheckLogin()

            If IsPostBack Then
                Return
            End If
            RadioButton1.Checked = False
            RadioButton2.Checked = False
            RadioButton3.Checked = False
            RadioButton4.Checked = False
            RadioButton5.Checked = False

            btnSave.Focus()
            txtAnswer.Enabled = False
            txtAnswer.Text = ""

            Dim dtb As DataTable = Message.SelectFirstQuestionByTheater(GetTheaterId())
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                Dim dr = dtb.Rows(0)
                lblTime.Text = Format(dr("QuestionCreate_dtm"), "ddd dd MMM yyyy เวลา HH.mm น.").ToString
                lblMessage.Text = dr("question_desc").ToString() '.Replace("</br>", vbCrLf)
                Dim wkAnsNo As Int32
                Dim ans = Utils.ConvertToInt32(dr("answer_no"))
                If IsNothing(ans) Then
                    wkAnsNo = 0
                Else
                    wkAnsNo = ans.Value
                End If
                If dr("read_flag").ToString() = "Y" AndAlso wkAnsNo <> 0 Then
                    btnSave.Visible = False
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False
                    RadioButton3.Enabled = False
                    RadioButton4.Enabled = False
                    RadioButton5.Enabled = False

                    If wkAnsNo = 1 Then
                        RadioButton1.Checked = True
                    ElseIf wkAnsNo = 2 Then
                        RadioButton2.Checked = True
                    ElseIf wkAnsNo = 3 Then
                        RadioButton3.Checked = True
                    ElseIf wkAnsNo = 4 Then
                        RadioButton4.Checked = True
                    ElseIf wkAnsNo = 5 Then
                        RadioButton5.Checked = True
                        txtAnswer.Text = dr("answer_desc").ToString()
                    End If
                Else
                    btnSave.Visible = True
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True
                    RadioButton3.Enabled = True
                    RadioButton4.Enabled = True
                    RadioButton5.Enabled = True
                    txtAnswer.Enabled = True

                    AnswerMessage(0, "")
                End If
            End If
        End Sub
        Protected Sub RadioButton1CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.CheckedChanged
            SelectAnswer(1)
        End Sub
        Protected Sub RadioButton2CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.CheckedChanged
            SelectAnswer(2)
        End Sub
        Protected Sub RadioButton3CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton3.CheckedChanged
            SelectAnswer(3)
        End Sub
        Protected Sub RadioButton4CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton4.CheckedChanged
            SelectAnswer(4)
        End Sub
        Protected Sub RadioButton5CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton5.CheckedChanged
            SelectAnswer(5)
        End Sub
#End Region

#Region "Methods"
        Private Sub AnswerMessage(ByVal answerNo As Integer, ByVal answerDetail As String)
            Try
                Message.UpdateAnswer(GetTheaterId(), answerNo, answerDetail, GetUserId())
            Catch ex As Exception
                lblMessage.Text = ex.Message
            End Try
        End Sub
        Private Sub SelectAnswer(ByVal answerCode As Integer)
            txtAnswer.Enabled = False
            btnSave.Focus()
            Select Case answerCode
                Case 1
                    RadioButton1.Checked = True
                Case 2
                    RadioButton2.Checked = True
                Case 3
                    RadioButton3.Checked = True
                Case 4
                    RadioButton4.Checked = True
                Case 5
                    RadioButton5.Checked = True

                    txtAnswer.Enabled = True
                    txtAnswer.Focus()
            End Select
        End Sub
#End Region

    End Class
End Namespace