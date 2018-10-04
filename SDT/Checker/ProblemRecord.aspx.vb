Imports System.Drawing
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions
Imports SDTCommon

Namespace Checker
    Partial Public Class ProblemRecord
        Inherits Page

#Region "Event Handlers"

        Protected Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
            Redirect(PageName.ActionMenu)
        End Sub

        Protected Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
            lblMessage.Visible = False
            Dim isError As Boolean
            If String.IsNullOrEmpty(txtProblem.Text.TrimEnd()) Then
                isError = True
            Else
                isError = True
                Dim revenueDate As Date = GetWorkingDate()
                Dim theaterId As Int32 = GetTheaterId()
                Dim updateBy As String = GetUserId()
                Dim problem As String = txtProblem.Text
                For Each gridViewRow As GridViewRow In grdResult.Rows
                    Dim chk As CheckBox = CType(gridViewRow.FindControl("chkSelect"), CheckBox)
                    If chk IsNot Nothing AndAlso chk.Checked Then
                        isError = False
                        DBInterface.ProblemRecord.UpdateInsert(revenueDate, theaterId, _
                                                               CType(grdResult.DataKeys(gridViewRow.RowIndex).Value, _
                                                                     Int32?), problem, updateBy)
                    End If
                Next
            End If
            If isError Then
                lblMessage.Visible = True
            Else
                ShowData()
            End If
        End Sub

        Protected Sub GrdResultRowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) _
            Handles grdResult.RowCommand
            If e.CommandName = "Delete" Then
                Dim revenueDate As Date = GetWorkingDate()
                Dim theaterId As Int32 = GetTheaterId()
                DBInterface.ProblemRecord.Delete(revenueDate, theaterId, CType(e.CommandArgument.ToString(), Int32))
                ShowData()
            End If
        End Sub

        Protected Sub GrdResultRowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) _
            Handles grdResult.RowDeleting
            'Do nothing
        End Sub

        Protected Sub GrdResultRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) _
            Handles grdResult.RowDataBound
            If e.Row.RowType <> DataControlRowType.DataRow Then
                Return
            End If

            Dim objName = e.Row.Cells(1).FindControl("hplName")
            If IsNothing(objName) Then
                Return
            End If
            Dim lblName As Label = CType(objName, Label)

            Dim movieTypeId As Int32 = CType(DataBinder.Eval(e.Row.DataItem, "movietype_id"), Int32)

            Dim release = DataBinder.Eval(e.Row.DataItem, "onrelease_id")
            If IsNothing(release) OrElse String.IsNullOrEmpty(release.ToString()) Then
                lblName.ForeColor = Color.Red
            Else
                If movieTypeId.ToString() = "1" Then
                    lblName.ForeColor = Color.DarkBlue
                Else
                    lblName.ForeColor = Color.Firebrick
                End If
            End If
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If
            lblMessage.Visible = False
            ShowData()
        End Sub

#End Region

#Region "Methods"

        Private Sub ShowData()
            Dim theaterId As Int32 = GetTheaterId()
            Dim dtb As DataTable = MovieAndTrailer.GetMovieRelease(Nothing, Nothing, theaterId, Nothing, 1, Nothing)
            If Not IsNothing(dtb) AndAlso dtb.Rows.Count > 0 Then
                dtb.Columns.Add("Problem", GetType(String))
                Dim dtbProblem As DataTable = DBInterface.ProblemRecord.SelectData(GetWorkingDate(), theaterId, Nothing, Nothing, Nothing, Nothing)
                If Not IsNothing(dtbProblem) AndAlso dtbProblem.Rows.Count > 0 Then
                    For Each dr As DataRow In dtb.Rows
                        For Each drProblem As DataRow In dtbProblem.Rows
                            If dr("movie_id").ToString() = drProblem("movie_id").ToString() Then
                                dr("Problem") = drProblem("problem")
                                dtbProblem.Rows.Remove(drProblem)
                                Exit For
                            End If
                        Next
                    Next
                End If
                grdResult.DataSource = dtb
                grdResult.DataBind()
            End If
        End Sub

#End Region
    End Class
End Namespace