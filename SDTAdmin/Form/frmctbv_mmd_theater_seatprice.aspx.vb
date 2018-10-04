Imports Web.Data
Imports System.Data.SqlClient

Partial Public Class frmctbv_mmd_theater_seatprice
    Inherits System.Web.UI.Page
    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblNotMatch.Visible = False
        Dim theaterSubId As Integer = Request.QueryString("screen")
        If Mid(Session("permission"), 9, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If
        Session("theaterSubId") = theaterSubId

        If IsPostBack = False Then
            ViewState("ModeSave") = "insert"
            Dim theaterRead As IDataReader = cDB.getTheaterDetail(Session("theaterId").ToString())
            If theaterRead.Read Then
                lblTheatre.Text = theaterRead("theater_name") & ""
            End If
            theaterRead.Close()

            Dim drRead As IDataReader = cDB.getTheaterSubDetail(Session("theaterId").ToString(), theaterSubId)
            If drRead.Read Then
                lblScreenNo.Text = theaterSubId
                lblCapacity.Text = cDB.CheckIsNullInteger(drRead("theatersub_normalseat")).ToString() & ""
            End If
            drRead.Close()
        End If

        CheckSumSeat()
    End Sub

    Private Sub CheckSumSeat()
        Dim decSumSeat As Decimal = 0
        For i As Integer = 0 To GridView1.Rows.Count - 1
            decSumSeat += Convert.ToDecimal(GridView1.Rows(i).Cells(2).Text)
        Next

        If GridView1.Rows.Count = 0 Then
            lblNotMatch.Visible = False
            Return
        End If

        If ((Convert.ToDecimal(lblCapacity.Text.Trim()) <> decSumSeat)) Then
            lblNotMatch.Visible = True
        Else
            lblNotMatch.Visible = False
        End If


    End Sub

    Protected Sub btnAddThatre_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddThatre.Click
        Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" + Session("theaterId").ToString())
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBack.Click
        'ViewState("ModeSave") = "insert"
        'GridView1.DataBind()
        ''cDB.ClearControlValues(Panel1)
        'txtName.Text = ""
        'txtNo.Text = ""
        'txtWeekend.Text = ""
        'txtWeekday.Text = ""
        'lblError.Visible = False
        Response.Redirect("frmctbv_mmd_theater_edit.aspx?theaterId=" + Convert.ToString(Session("theaterId")))
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Try
            If txtName.Text.Trim() = "" Then
                lblError.Visible = True
                lblError.Text = "Please check require flield (*)"
            ElseIf txtNo.Text.Trim() = "" Or txtNo.Text.Trim() = "0" Then
                lblError.Visible = True
                lblError.Text = "Please check require flield (*)"

            Else
                lblError.Visible = False

                Dim strSeatTypeName As String = txtName.Text.Trim()
                Dim decSeatQty As Decimal = Convert.ToDecimal(txtNo.Text.Trim())
                Dim decWeekend As Decimal = 0
                Dim decWeekday As Decimal = 0
                If txtWeekend.Text.Trim() <> "" Then
                    decWeekend = Convert.ToDecimal(txtWeekend.Text.Trim())
                End If
                If txtWeekday.Text.Trim() <> "" Then
                    decWeekday = Convert.ToDecimal(txtWeekday.Text.Trim())
                End If
                Dim intIDsave As Integer = 0
                Dim saveDatetimeNow As DateTime = DateTime.Now  'ConvertTimeZone By Pachara S. on 20170615
                Dim cvDateTimeNow As DateTime = ConvertTimeToLocaltime(saveDatetimeNow) 'ConvertTimeZone By Pachara S. on 20170615

                If ViewState("ModeSave") = "insert" Then

                    Dim drReadName As IDataReader = cDB.GetDataAll("SELECT * FROM tblTheaterSub_Seat WHERE theater_id = " + Session("theaterId").ToString() + " AND theatersub_id = " + Session("theaterSubId").ToString() + " AND seat_type_name = '" + txtName.Text.Trim() + "'")
                    If drReadName.Read Then
                        lblError.Visible = True
                        lblError.Text = "Please check require flield (*)"
                        drReadName.Close()
                        Return
                    End If
                    drReadName.Close()

                    Dim intGetMax As String = "0"
                    intGetMax = cDB.GetMaxID("seat_type_id", "tblTheaterSub_Seat", " WHERE theater_id = " + Session("theaterId").ToString() + " AND theatersub_id = " + Session("theaterSubId").ToString())
                    intIDsave = Convert.ToInt32(intGetMax) + 1

                    'cDB.AddTheaterSubSeat(Session("theaterId"), Session("theaterSubId"), intIDsave, strSeatTypeName, decSeatQty, decWeekend, decWeekday, Date.Now, Session("UserID"), Date.Now, Session("UserID"))
                    cDB.AddTheaterSubSeat(Session("theaterId"), Session("theaterSubId"), intIDsave, strSeatTypeName, decSeatQty, decWeekend, decWeekday, cvDateTimeNow, Session("UserID"), cvDateTimeNow, Session("UserID"))
                    ViewState("ModeSave") = "insert"
                Else
                    intIDsave = ViewState("seat_type_id")
                    'cDB.updateTheaterSubSeat(Session("theaterId"), Session("theaterSubId"), intIDsave, strSeatTypeName, decSeatQty, decWeekend, decWeekday, Date.Now, Session("UserID"))
                    cDB.updateTheaterSubSeat(Session("theaterId"), Session("theaterSubId"), intIDsave, strSeatTypeName, decSeatQty, decWeekend, decWeekday, cvDateTimeNow, Session("UserID"))
                    ViewState("ModeSave") = "insert"
                End If

                GridView1.DataBind()
                cDB.ClearControlValues(Panel1)
            End If

            CheckSumSeat()
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

        If e.CommandName = "Select" Then
            Dim intId As Integer = Convert.ToInt32(e.CommandArgument)
            ViewState("seat_type_id") = intId
            ViewState("ModeSave") = "update"
            SelectDataSeat()
        ElseIf e.CommandName = "Del" Then
            Dim intId As Integer = Convert.ToInt32(e.CommandArgument)
            cDB.GetDataAll("DELETE FROM tblTheaterSub_Seat WHERE theater_id = " + Session("theaterId").ToString() + " AND theatersub_id = " + Session("theaterSubId").ToString() + " AND seat_type_id = " + intId.ToString())
            GridView1.DataBind()
        End If
        CheckSumSeat()
    End Sub

    Sub SelectDataSeat()
        Dim drRead As IDataReader = cDB.GetDataAll("SELECT * FROM tblTheaterSub_Seat WHERE theater_id = " + Session("theaterId").ToString() + " AND theatersub_id = " + Session("theaterSubId").ToString() + " AND seat_type_id = " + ViewState("seat_type_id").ToString())
        If drRead.Read Then
            txtName.Text = cDB.CheckIsNullString(drRead("seat_type_name")) & ""
            txtNo.Text = cDB.CheckIsNullInteger(drRead("seat_qty")).ToString() & ""
            txtWeekend.Text = cDB.CheckIsNullInteger(drRead("weekend_price_amt")).ToString() & ""
            txtWeekday.Text = cDB.CheckIsNullInteger(drRead("weekday_price_amt")).ToString() & ""
        End If
        drRead.Close()
    End Sub

    Protected Sub imbOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbOut.Click
        System.Web.Security.FormsAuthentication.SignOut()
        System.Web.Security.FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class