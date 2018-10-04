Imports Web.Data

Partial Public Class frmCTBV_MMD_Holiday
    Inherits System.Web.UI.Page

    Private m_Database As Database
    Private m_HolidayDAL As HolidayDAL

#Region "Event"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.txtYear.Text = Convert.ToString(Date.Today.Year)
            Me.ddlMonth.SelectedValue = ""
            SetFormMode(Nothing)
            SearchData()
        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
        SearchData()
    End Sub

    Protected Sub grdHoliday_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdHoliday.Sorting
        m_Database = MainApp.Database
        m_HolidayDAL = New HolidayDAL(m_Database)

        Dim p_year As Integer? = Nothing
        Dim p_month As Integer? = Nothing

        If Me.txtYear.Text.Trim() <> "" AndAlso IsNumeric(Me.txtYear.Text.Trim()) Then
            p_year = CInt(Me.txtYear.Text.Trim())
        End If
        If Me.ddlMonth.Text.Trim() <> "" AndAlso IsNumeric(Me.ddlMonth.Text.Trim()) Then
            p_month = CInt(Me.ddlMonth.Text.Trim())
        End If

        Dim dt As DataTable = m_HolidayDAL.SearchData(p_year, p_month)

        Dim dv As DataView = New DataView(dt)
        If e.SortDirection = SortDirection.Ascending Then
            dv.Sort = e.SortExpression + " ASC"
        Else
            dv.Sort = e.SortExpression + " DESC"
        End If

        Me.grdHoliday.DataSource = dv
        Me.grdHoliday.DataBind()
    End Sub

    Protected Sub btnInsertUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInsertUpdate.Click
        If String.IsNullOrEmpty(Me.hdfHolidayId.Value) Then
            InsertUpdateData(Nothing)
        Else
            InsertUpdateData(CInt(Me.hdfHolidayId.Value))
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        SetFormMode(Nothing)
    End Sub

    Protected Sub grdHoliday_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdHoliday.RowCommand
        If e.CommandName = "Add" Then
            SetFormMode(Nothing)
        ElseIf e.CommandName = "Edit" Then
            SetFormMode(CInt(e.CommandArgument))
        ElseIf e.CommandName = "Delete" Then
            SetFormMode(CInt(e.CommandArgument))
        End If
        SearchData()
    End Sub

    Protected Sub grdHoliday_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdHoliday.RowEditing
        'Do nothing
    End Sub

    Protected Sub grdHoliday_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdHoliday.RowDeleting
        DeleteData()
    End Sub

#End Region

#Region "Function/Sub"

    Private Sub SetFormMode(ByVal p_KeyId As Integer?)
        lblError.Visible = False

        If p_KeyId Is Nothing Then
            Me.lblAction.Text = "Add Data"

            Me.hdfHolidayId.Value = Nothing
            Me.dtpHolidayDate.SelectedDate = Nothing
            Me.txtHolidayName.Text = ""

            Me.btnInsertUpdate.ImageUrl = "~/images/ADDCCC.png"
        Else
            lblAction.Text = "Update data"
            Me.txtHolidayName.Focus()

            Me.m_Database = MainApp.Database
            Me.m_HolidayDAL = New HolidayDAL(m_Database)

            Dim dt As DataTable = m_HolidayDAL.SelectData(p_KeyId, Nothing, Nothing)

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                SetFormMode(Nothing)
            Else
                Dim dr As DataRow = dt.Rows(0)

                Me.hdfHolidayId.Value = dr("holiday_id")
                If dr("holiday_date") Is DBNull.Value Then
                    Me.dtpHolidayDate.SelectedDate = Nothing
                Else
                    Me.dtpHolidayDate.SelectedDate = dr("holiday_date")
                End If
                If dr("holiday_name") Is DBNull.Value Then
                    Me.txtHolidayName.Text = ""
                Else
                    Me.txtHolidayName.Text = dr("holiday_name")
                End If

                Me.btnInsertUpdate.ImageUrl = "~/images/SAVECCC.png"
            End If
        End If
    End Sub

    Private Sub SearchData()
        m_Database = MainApp.Database
        m_HolidayDAL = New HolidayDAL(m_Database)

        Dim p_year As Integer? = Nothing
        Dim p_month As Integer? = Nothing
        If Me.txtYear.Text.Trim() <> "" AndAlso IsNumeric(Me.txtYear.Text.Trim()) Then
            p_year = CInt(Me.txtYear.Text.Trim())
        End If
        If Me.ddlMonth.Text.Trim() <> "" AndAlso IsNumeric(Me.ddlMonth.Text.Trim()) Then
            p_month = CInt(Me.ddlMonth.Text.Trim())
        End If

        Dim dt As DataTable = m_HolidayDAL.SearchData(p_year, p_month)

        Me.grdHoliday.DataSource = dt
        Me.grdHoliday.DataBind()
    End Sub

    Private Sub InsertUpdateData(ByVal p_KeyId As Integer?)
        Me.lblError.Text = String.Empty

        If String.IsNullOrEmpty(Me.dtpHolidayDate.Text.Trim()) Then
            Me.lblError.Text = "Please check require flield (*)"
            Me.lblError.Visible = True
            Me.txtHolidayName.Focus()
            Return
        End If
        If String.IsNullOrEmpty(Me.txtHolidayName.Text.Trim()) Then
            Me.lblError.Text = "Please check require flield (*)"
            Me.lblError.Visible = True
            Me.txtHolidayName.Focus()
            Return
        End If

        Me.m_Database = MainApp.Database
        Me.m_HolidayDAL = New HolidayDAL(m_Database)

        If p_KeyId Is Nothing Then
            Dim p_holiday_date As Date = Me.dtpHolidayDate.SelectedDate
            Dim p_holiday_name As String = Me.txtHolidayName.Text.Trim()
            Dim p_create_by As String = CStr(Session("UserID"))

            Dim dtDup As DataTable = m_HolidayDAL.SelectDuplicateAddData(p_holiday_date)

            If dtDup.Rows.Count > 0 Then
                Me.lblError.Text = "Holiday Date has exist!"
                Me.lblError.Visible = True
                Me.txtHolidayName.Focus()
                Return
            End If

            m_HolidayDAL.InsertData(p_holiday_date, p_holiday_name, p_create_by)
            Me.lblError.Visible = False

            Me.ddlMonth.SelectedValue = String.Format("{0:00}", p_holiday_date.Month)
            Me.txtYear.Text = String.Format("{0}", p_holiday_date.Year)
        Else
            Dim p_holiday_id As Integer = CInt(Me.hdfHolidayId.Value)
            Dim p_holiday_date As Date = Me.dtpHolidayDate.SelectedDate
            Dim p_holiday_name As String = Me.txtHolidayName.Text.Trim()
            Dim p_update_by As String = CStr(Session("UserID"))

            Dim dtDup As DataTable = m_HolidayDAL.SelectDuplicateUpdateData(p_holiday_id, p_holiday_date)

            If dtDup.Rows.Count > 0 Then
                Me.lblError.Text = "Holiday Date has exist!"
                Me.lblError.Visible = True
                Me.txtHolidayName.Focus()
                Return
            End If

            m_HolidayDAL.UpdateData(p_holiday_id, p_holiday_date, p_holiday_name, p_update_by)
            Me.lblError.Visible = False
        End If

        SetFormMode(Nothing)
        SearchData()
    End Sub

    Private Sub DeleteData()
        Me.lblError.Text = String.Empty

        Me.m_Database = MainApp.Database
        Me.m_HolidayDAL = New HolidayDAL(m_Database)

        Dim p_holiday_id As Integer = CInt(Me.hdfHolidayId.Value)
        m_HolidayDAL.DeleteData(p_holiday_id)

        Me.lblError.Visible = False

        SetFormMode(Nothing)
        SearchData()
    End Sub

#End Region
    
End Class