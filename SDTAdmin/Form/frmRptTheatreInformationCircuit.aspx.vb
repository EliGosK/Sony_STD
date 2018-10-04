Imports Web.Data

Partial Public Class frmRptTheatreInformationCircuit
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        lblError.Visible = False
        
        Try
            If Not IsPostBack Then
                ShowDatatblMain()
            End If
        Catch ex As Exception
            lblError.Visible = True
            lblError.Text = ex.Message
            Return
        End Try


    End Sub

    Sub ShowDatatblMain()
        Dim strCircuitid As String = Request.QueryString("circuitid")
        If strCircuitid = "0" Then
            lblError.Visible = True
            lblError.Text = "Invalid CircuitId"
            Return
        End If

        tblMain.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
        Dim strSQL As String = ""
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        strSQL = " select Theater.remark, Theater.theater_name + ' ' + convert(nvarchar, seat.theatersub_id) as TheatreName, "
        strSQL += vbNewLine + " Theater.theater_name, Theater.theater_status, seat.theater_id"
        strSQL += vbNewLine + " , seat.theatersub_id, seat.seat_type_id "
        strSQL += vbNewLine + " , seat.seat_type_name, seat.seat_qty, seat.weekend_price_amt "
        strSQL += vbNewLine + " , seat.weekday_price_amt, max(sub.digital_flag) as digital_flag"
        strSQL += vbNewLine + " , max(sub.dimention_flag) as dimention_flag"
        strSQL += vbNewLine + " , max(sub.mm_flag) as mm_flag"
        strSQL += vbNewLine + " from tblTheaterSub_Seat seat"
        strSQL += vbNewLine + " left join tblTheater Theater"
        strSQL += vbNewLine + " on Seat.theater_id = Theater.theater_id"
        strSQL += vbNewLine + " left join tblTheaterSub sub"
        strSQL += vbNewLine + " on Seat.theatersub_id = sub.theatersub_id"
        strSQL += vbNewLine + " and Seat.theater_id = sub.theater_id"
        strSQL += vbNewLine + " WHERE Theater.circuit_id = " + strCircuitid

        strSQL += vbNewLine + " and ((convert(varchar(19), Theater.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), Theater.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), Theater.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and ((convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))  "


        strSQL += vbNewLine + " group by seat.theatersub_id, seat.theater_id, Theater.theater_name"
        strSQL += vbNewLine + " , seat.seat_type_id , seat.seat_type_name, Theater.theater_status"
        strSQL += vbNewLine + " , seat.seat_qty, seat.weekend_price_amt, seat.weekday_price_amt, Theater.remark"
        strSQL += vbNewLine + " order by  seat.theater_id, seat.theatersub_id"

        Dim dtb As New DataTable
        dtb = cDatabase.GetDataTable(strSQL)


        Dim strCheckRowComment As String = ""
        Dim decSumByTheaterName As Decimal
        Dim hasTheater_Comment_Count As New Hashtable
        Dim hasCheckDupTheatreName As New Hashtable
        Dim aylData As New ArrayList
        decSumByTheaterName = 0

        For i As Integer = 0 To dtb.Rows.Count - 1
            'เก็บจำนวน Colspan ของ Comment
            If (hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("Theater_Name")).Trim()) Is Nothing) Then
                hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("Theater_Name")).Trim()) = 1
            Else
                hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("Theater_Name")).Trim()) = hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("Theater_Name")).Trim()) + 1

                If (i <> dtb.Rows.Count - 1) Then
                    If strCheckRowComment <> "" And _
                    strCheckRowComment.Trim() <> Convert.ToString(dtb.Rows(i + 1)("TheatreName")).Trim() Then
                        hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("TheatreName")).Trim()) = hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("TheatreName")).Trim()) + 1
                    End If
                End If
            End If
        Next


        Dim strTheatreNameCompare As String = ""
        Dim strTheatreComment As String = ""
        Dim strDiginalBgColor As String = "ffffff"
        Dim decSum1, decSum2 As Decimal
        decSum1 = 0
        decSum2 = 0
        For i As Integer = 0 To dtb.Rows.Count - 1

            decSum1 += Convert.ToDecimal(dtb.Rows(i)("seat_qty"))
            decSum2 += Convert.ToDecimal(dtb.Rows(i)("seat_qty"))

            Dim tblMainNewRow As New TableRow()
            tblMainNewRow.Font.Name = "Tahoma"
            tblMain.Font.Size = 8

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(0).HorizontalAlign = HorizontalAlign.Left

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
            tblMainNewRow.Cells(1).Font.Bold = True
            'Diginal Format
            If cDB.CheckIsNullString(dtb.Rows(i)("dimention_flag")) = "Y" Then
                tblMainNewRow.Cells(1).Text = "3D"
                tblMainNewRow.Cells(1).ForeColor = Color.FromName("#ffffff")
                tblMainNewRow.Cells(1).BackColor = Color.FromName("#000000")
            ElseIf cDB.CheckIsNullString(dtb.Rows(i)("digital_flag")) = "Y" Then
                tblMainNewRow.Cells(1).Text = "Digital"
                tblMainNewRow.Cells(1).ForeColor = Color.FromName("#ffffff")
                tblMainNewRow.Cells(1).BackColor = Color.FromName("#000000")
            Else
                tblMainNewRow.Cells(1).Text = ""
                tblMainNewRow.Cells(1).ForeColor = Color.FromName("#000000")
                tblMainNewRow.Cells(1).BackColor = Color.FromName("#ffffff")
            End If

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(2).HorizontalAlign = HorizontalAlign.Left
            tblMainNewRow.Cells(2).Text = dtb.Rows(i)("seat_type_name")
            'If (i <> dtb.Rows.Count - 1) Then
            '    If strTheatreNameCompare <> "" And _
            '    strTheatreNameCompare.Trim() <> Convert.ToString(dtb.Rows(i + 1)("TheatreName")).Trim() Then
            '        tblMainNewRow.Cells(2).Text += "<BR/><B>Total</B>"
            '    End If
            'End If

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            tblMainNewRow.Cells(3).Text = Convert.ToDecimal(dtb.Rows(i)("seat_qty")).ToString("#,##0")

            'Sum Seat
            'If (i <> dtb.Rows.Count - 1) Then
            '    If strTheatreNameCompare <> "" And _
            '    strTheatreNameCompare.Trim() <> Convert.ToString(dtb.Rows(i + 1)("TheatreName")).Trim() Then
            '        tblMainNewRow.Cells(3).Text += "<BR/><B>" + decSum1.ToString("#,##0") + "</B>"
            '        decSum1 = 0
            '    End If
            'End If

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
            tblMainNewRow.Cells(4).Text = Convert.ToDecimal(dtb.Rows(i)("weekend_price_amt")).ToString("#,##0")

            tblMainNewRow.Cells.Add(New TableCell)
            tblMainNewRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            tblMainNewRow.Cells(5).Text = Convert.ToDecimal(dtb.Rows(i)("weekday_price_amt")).ToString("#,##0")


            'ถ้าเป็น TheatreName เป็นตัวเดิม -ไม่ต้องใส่ชื่ออีก -ไม่ต้อง Write ลงไปใหม่
            If strTheatreNameCompare.Trim() <> Convert.ToString(dtb.Rows(i)("TheatreName")).Trim() Then
                tblMainNewRow.Cells(0).Text = Convert.ToString(dtb.Rows(i)("TheatreName")).Trim()
            Else
                tblMainNewRow.Cells(1).Text = ""
            End If

            If strTheatreComment.Trim() <> Convert.ToString(dtb.Rows(i)("theater_Name")).Trim() Then
                tblMainNewRow.Cells.Add(New TableCell)
                tblMainNewRow.Cells(6).RowSpan = hasTheater_Comment_Count(Convert.ToString(dtb.Rows(i)("Theater_Name")).Trim())
                tblMainNewRow.Cells(6).BorderWidth = 0
                tblMainNewRow.Cells(6).HorizontalAlign = HorizontalAlign.Left
                tblMainNewRow.Cells(6).VerticalAlign = VerticalAlign.Top
                tblMainNewRow.Cells(6).Text = Convert.ToString(dtb.Rows(i)("remark"))
            End If

            'set color
            If i Mod 2 = 0 Then
                tblMainNewRow.Cells(0).BackColor = Color.FromName("#F7F6F3")
                'ใส่สีให้ Digital และ 3D
                'tblMainNewRow.Cells(1).BackColor = Color.FromName("F7F6F3")
                tblMainNewRow.Cells(2).BackColor = Color.FromName("#F7F6F3")
                tblMainNewRow.Cells(3).BackColor = Color.FromName("#F7F6F3")
                tblMainNewRow.Cells(4).BackColor = Color.FromName("#F7F6F3")
                tblMainNewRow.Cells(5).BackColor = Color.FromName("#F7F6F3")
            End If

            tblMain.Rows.Add(tblMainNewRow)




            '''''''''Write ค่า Sum
            'ไม่ใช่ row สุดท้าย แต่เป็น row สุดท้ายของ จอและโรงนั้น
            If (i <> dtb.Rows.Count - 1) Then
                If Convert.ToString(dtb.Rows(i)("TheatreName")).Trim() <> "" And _
                    Convert.ToString(dtb.Rows(i)("TheatreName")).Trim() <> Convert.ToString(dtb.Rows(i + 1)("TheatreName")).Trim() Then
                    tblMainNewRow = New TableRow()
                    tblMainNewRow.Font.Name = "Tahoma"
                    For j As Integer = 0 To 5
                        tblMainNewRow.Cells.Add(New TableCell)
                        tblMainNewRow.Cells(j).Font.Bold = True
                        tblMainNewRow.Cells(j).BackColor = Color.FromName("#ffffff")
                        tblMainNewRow.Cells(j).ForeColor = Color.FromName("#000000")
                        tblMainNewRow.Cells(j).HorizontalAlign = HorizontalAlign.Right
                        If (j = 2) Then
                            tblMainNewRow.Cells(j).Text = "Total"
                        ElseIf (j = 3) Then
                            tblMainNewRow.Cells(j).Text = decSum1.ToString("#,##0")
                        End If
                    Next
                    tblMain.Rows.Add(tblMainNewRow)
                    decSum1 = 0
                End If

                If Convert.ToString(dtb.Rows(i)("theater_Name")).Trim() <> "" And _
                                    Convert.ToString(dtb.Rows(i)("theater_Name")).Trim() <> Convert.ToString(dtb.Rows(i + 1)("theater_Name")).Trim() Then
                    tblMainNewRow = New TableRow()
                    tblMainNewRow.Font.Name = "Tahoma"
                    For j As Integer = 0 To 6
                        tblMainNewRow.Cells.Add(New TableCell)
                        tblMainNewRow.Cells(j).Font.Bold = True
                        tblMainNewRow.Cells(j).BackColor = Color.FromName("#666666")
                        tblMainNewRow.Cells(j).ForeColor = Color.FromName("#ffffff")
                        tblMainNewRow.Cells(j).HorizontalAlign = HorizontalAlign.Right
                        If (j = 2) Then
                            tblMainNewRow.Cells(j).Text = "Total Seat"
                        ElseIf (j = 3) Then
                            tblMainNewRow.Cells(j).Text = decSum2.ToString("#,##0")
                        End If
                    Next
                    tblMain.Rows.Add(tblMainNewRow)
                    decSum2 = 0
                End If
            Else 'row สุดท้าย
                tblMainNewRow = New TableRow()
                tblMainNewRow.Font.Name = "Tahoma"
                For j As Integer = 0 To 6
                    tblMainNewRow.Cells.Add(New TableCell)
                    tblMainNewRow.Cells(j).Font.Bold = True
                    tblMainNewRow.Cells(j).BackColor = Color.FromName("#666666")
                    tblMainNewRow.Cells(j).ForeColor = Color.FromName("#ffffff")
                    tblMainNewRow.Cells(j).HorizontalAlign = HorizontalAlign.Right
                    If (j = 2) Then
                        tblMainNewRow.Cells(j).Text = "Total Seat"
                    ElseIf (j = 3) Then
                        tblMainNewRow.Cells(j).Text = decSum2.ToString("#,##0")
                    End If
                Next
                tblMain.Rows.Add(tblMainNewRow)
                decSum2 = 0
            End If

            strTheatreNameCompare = Convert.ToString(dtb.Rows(i)("TheatreName")).Trim()
            strTheatreComment = Convert.ToString(dtb.Rows(i)("theater_Name")).Trim()
        Next

    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptTheatreInformationParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=TheatreInformation.xls")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        ShowDatatblMain()
        tblMain.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()

    End Sub
End Class







'  For i As Integer = 0 To dtb.Rows.Count
'            If (hasData(dtb.Rows(i)("TheatreName")) Is Nothing) Then
'                aylData.Add(dtb.Rows(i)("TheatreName"))
'                aylData.Add(dtb.Rows(i)("theater_status"))
'                aylData.Add(dtb.Rows(i)("theater_id"))
'                aylData.Add(dtb.Rows(i)("theater_name"))
'                aylData.Add(dtb.Rows(i)("theatersub_id"))
'                aylData.Add(dtb.Rows(i)("seat_type_id"))
'                aylData.Add(dtb.Rows(i)("seat_type_name"))
'                aylData.Add(dtb.Rows(i)("seat_qty"))

'                aylData.Add(dtb.Rows(i)("weekend_price_amt"))
'                aylData.Add(dtb.Rows(i)("weekday_price_amt"))

'                aylData.Add(dtb.Rows(i)("digital_flag"))
'                aylData.Add(dtb.Rows(i)("dimention_flag"))
'                aylData.Add(dtb.Rows(i)("mm_flag"))
'                aylData.Add(dtb.Rows(i)("remark"))

'                hasData(dtb.Rows(i)("TheatreName")) = aylData
'            Else
'                aylData = hasData(dtb.Rows(i)("TheatreName"))
'                aylData(8) = aylData(7) + dtb.Rows(i)("seat_qty")
'                aylData(8) = aylData(8) + dtb.Rows(i)("weekend_price_amt")
'                aylData(9) = aylData(9) + dtb.Rows(i)("weekday_price_amt")
'                aylData.Add(dtb.Rows(i)("seat_qty"))
'            End If
'        Next

'Dim decSum1, decSum2, decSum3 As Decimal
'        decSum1 = 0
'        decSum2 = 0
'        decSum3 = 0
'        For i As Integer = 0 To aylData.Count

'        Next