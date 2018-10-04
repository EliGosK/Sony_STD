Imports SDTCommon
Imports SDTCommon.DBInterface
Imports SDTCommon.Extensions

Namespace Checker
    Partial Public Class PreCondition
        Inherits Page

#Region "Event Handlers"
        Protected Sub BtnLogoutClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogout.Click
            DBInterface.User.Logout()
        End Sub
        Protected Sub BtnOkClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
            SetPreCondition(dpkDate.SelectedDate.Value)
        End Sub
        Protected Sub BtnTestClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTest.Click
            Dim revenueDate As New Date(2012, 11, 26)
            SetPreCondition(revenueDate)
        End Sub
        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init
            If IsPostBack Then
                Return
            End If
            ddlCircuit.Attributes.Add("onchange", "changeHeader();")
        End Sub
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            If IsPostBack Then
                Return
            End If

            'ddlCircuit.DataSource = Select(Nothing)

            Dim dtbCircuitTheater As DataTable = Theater.SelectByUser(CType(GetUserId(), Int32?), Nothing, True)
            If dtbCircuitTheater Is Nothing OrElse dtbCircuitTheater.Rows.Count = 0 Then
                dtbCircuitTheater = Theater.SelectData(Nothing, Nothing, True)
            End If

            If Not IsNothing(dtbCircuitTheater) AndAlso dtbCircuitTheater.Rows.Count > 0 Then
                SetHidenData(dtbCircuitTheater.ToDataString("circuit_id", "theater_id", "theater_name"))
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "LoadedScript", "changeHeader()", True)
            End If

            Dim viewCircuit As New DataView(dtbCircuitTheater)
            Dim dtbCircuit As DataTable = viewCircuit.ToTable(True, "circuit_id", "circuit_name")
            ddlCircuit.DataSource = dtbCircuit
            ddlCircuit.DataTextField = "circuit_name"
            ddlCircuit.DataValueField = "circuit_id"
            ddlCircuit.DataBind()

            If Hour(Now) < 6 Then
                dpkDate.SelectedDate = Now.AddDays(-1)
                'Session("SysDate") = Format(Now().AddDays(-1), "yyyyMMdd")
            Else
                dpkDate.SelectedDate = Now
            End If
        End Sub
#End Region

#Region "Methods"
        Private Sub SetPreCondition(ByVal revenueDate As Date)
            Dim theaterData As DataTable = Theater.SelectData(CInt(hdfTheaterId.Value), Nothing, True)
            ddlTheater.DataSource = theaterData
            ddlTheater.DataTextField = "theater_name"
            ddlTheater.DataValueField = "theater_id"
            ddlTheater.DataBind()

            SetCircuitName(ddlCircuit.SelectedItem.Text)
            SetTheaterName(ddlTheater.SelectedItem.Text)

            SetCircuitId(CInt(ddlCircuit.SelectedValue))
            SetTheaterId(CInt(ddlTheater.SelectedValue))

            SetWorkingDate(revenueDate)
            SetDisplayDate(revenueDate.ToLongDateString())
            Redirect(PageName.ActionMenu)
        End Sub
#End Region

    End Class
End Namespace