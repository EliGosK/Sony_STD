Imports Web.Data

Partial Public Class frmRptTheatreInformation
    Inherits System.Web.UI.Page

    Dim cDB As New cDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If
        If Not IsPostBack Then
            ShowDataTbl1()
            ShowDataTbl2()
            ShowDataTbl3()
            ShowDataTbl4()
            ShowDataTbl5()
        End If
        
    End Sub

    Sub ShowDataTbl1()
        tblHead.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        'Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        'strSQL = " SELECT thr.theater_id, thr.theater_name, thr.circuit_id,"
        'strSQL += vbNewLine + " (SELECT COUNT(sub.theatersub_id)"
        'strSQL += vbNewLine + " FROM tblTheaterSub sub"
        'strSQL += vbNewLine + " WHERE (sub.status_flag = 'Y') and (sub.theater_id = thr.theater_id)"
        'strSQL += vbNewLine + " AND ((CONVERT(VARCHAR(19), sub.open_date, 111) >= CONVERT(VARCHAR(19), '" + strOpenDate + "', 111))"
        'strSQL += vbNewLine + "  or (CONVERT(VARCHAR(19), sub.open_date, 111) is null))"
        'strSQL += vbNewLine + " AND ((CONVERT(VARCHAR(19), sub.close_date, 111) <= CONVERT(VARCHAR(19), '" + strCloseDate + "', 111))"
        'strSQL += vbNewLine + " or (CONVERT(VARCHAR(19), sub.close_date, 111) is null))"
        'strSQL += vbNewLine + " GROUP BY sub.theater_id) as sumScreen,"
        'strSQL += vbNewLine + " isnull((SELECT SUM(Seat.theatersub_normalseat) AS sumSeat_qty"
        'strSQL += vbNewLine + " FROM tblTheaterSub Seat"
        'strSQL += vbNewLine + " WHERE (Seat.theater_id = thr.theater_id)"
        'strSQL += vbNewLine + " AND ((CONVERT(VARCHAR(19), Seat.open_date, 111) >= CONVERT(VARCHAR(19), '" + strOpenDate + "', 111))"
        'strSQL += vbNewLine + " or (CONVERT(VARCHAR(19), Seat.open_date, 111) is null))"
        'strSQL += vbNewLine + " AND ((CONVERT(VARCHAR(19), Seat.close_date, 111) <= CONVERT(VARCHAR(19), '" + strCloseDate + "', 111))"
        'strSQL += vbNewLine + " or (CONVERT(VARCHAR(19), Seat.close_date, 111) is null))"
        'strSQL += vbNewLine + " GROUP BY Seat.theater_id),0) as sumSeat_qty"
        'strSQL += vbNewLine + " FROM tblTheater thr"
        'strSQL += vbNewLine + " order by thr.circuit_id, theater_id"

        strSQL = "select th.circuit_id, th.theater_id, th.theater_name,"
        strSQL += vbNewLine + " isnull((select count(sub.theatersub_id)"
        strSQL += vbNewLine + " from tblTheaterSub sub"

        strSQL += vbNewLine + " where (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"

        strSQL += vbNewLine + " and (sub.theater_id = th.theater_id)" ' and (sub.status_flag = 'Y')"
        strSQL += vbNewLine + " group by sub.theater_id"
        strSQL += vbNewLine + " ),0) sumScreen,"

        strSQL += vbNewLine + " isnull((select sum(isnull(seat.theatersub_normalseat, 0))"
        strSQL += vbNewLine + " from tblTheaterSub seat "
        strSQL += vbNewLine + " left join  tblTheater thseat on seat.theater_id=thseat.theater_id "
        strSQL += vbNewLine + " where (thseat.theater_id = th.theater_id) and (seat.theater_id = th.theater_id) "
        strSQL += vbNewLine + " and (convert(varchar(19), seat.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), seat.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), seat.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"
        strSQL += vbNewLine + " group by seat.theater_id"
        strSQL += vbNewLine + " ),0) sumseat_qty"
         
        strSQL += vbNewLine + " from tblTheater th"
        'th.theater_status='Enabled' and
        strSQL += vbNewLine + " where (convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"
        strSQL += vbNewLine + " order by th.circuit_id, th.theater_name"

        Dim drTbl1 As IDataReader = cDB.GetDataAll(strSQL)

        Dim strTheatreName As String = ""
        Dim dbCircuitID, dbNo As Double ', dbScreen, dbSeat
        Dim i As Integer = 0
        Dim countRow As Integer = 0
        dbCircuitID = 1
        While (drTbl1.Read())
            countRow = countRow + 1

            Dim tblSumRowIn As New TableRow()
            If (ViewState("StartLineTbl1") Is Nothing) Then
                ViewState("StartLineTbl1") = cDB.CheckIsNullString(drTbl1("circuit_id")).Trim()
            Else
                If Convert.ToString(ViewState("StartLineTbl1")).Trim() <> cDB.CheckIsNullString(drTbl1("circuit_id")).Trim() Then
                    If cDB.CheckIsNullString(drTbl1("circuit_id")).Trim() <> "1" Then
                        tblSumRowIn.Cells.Add(New TableCell)
                        tblSumRowIn.Cells(0).HorizontalAlign = HorizontalAlign.Center
                        tblSumRowIn.Cells(0).Height = 10
                        tblSumRowIn.Font.Name = "tahoma"
                        tblSumRowIn.Font.Size = 8
                        tblSumRowIn.Cells(0).ColumnSpan = 4
                        tblSumRowIn.Cells(0).BackColor = Color.FromName("#000000")
                        tbl1.Rows.Add(tblSumRowIn)
                    End If
                    ViewState("StartLineTbl1") = cDB.CheckIsNullString(drTbl1("circuit_id")).Trim()
                End If
            End If


            If dbCircuitID = drTbl1("circuit_id") Then
                i = i + 1
            Else
                i = 1
                dbCircuitID = drTbl1("circuit_id")
            End If
            dbNo = i
            'strTheatreName = cDB.CheckIsNullString(drTbl1("theater_name"))
            'dbScreen = Format(cDB.CheckIsNullInteger(drTbl1("sumScreen")), "#,##0")
            'dbSeat = Format(cDB.CheckIsNullInteger(drTbl1("sumSeat_qty")), "#,##0")

            Dim tbl1Row As New TableRow()
            tbl1Row.HorizontalAlign = HorizontalAlign.Center
            tbl1Row.Font.Name = "tahoma"
            tbl1Row.Font.Size = 8
            tbl1Row.Font.Bold = False
            tbl1Row.VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(0).Text = dbNo.ToString()

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
            tbl1Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            'tbl1Row.Cells(1).Text = "<a href=frmRptTheatreInformationCircuit.aspx?circuitid=" + dbCircuitID.ToString() + ">" + cDB.CheckIsNullString(drTbl1("theater_name")) + "</a>"
            tbl1Row.Cells(1).Text = cDB.CheckIsNullString(drTbl1("theater_name"))
            tbl1Row.Cells(1).Font.Size = 8
            tbl1Row.Cells(1).ForeColor = Color.Black
            tbl1Row.Cells(1).Font.Underline = False

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
            tbl1Row.Cells(2).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(2).Text = Format(cDB.CheckIsNullInteger(drTbl1("sumScreen")), "#,##0")

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            tbl1Row.Cells(3).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(3).Text = Format(cDB.CheckIsNullInteger(drTbl1("sumSeat_qty")), "#,##0")

            tbl1.Rows.Add(tbl1Row)

        End While
        drTbl1.Close()
        countRow = countRow
        Dim tblSumRow As New TableRow()
        tblSumRow.Cells.Add(New TableCell)
        tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
        'tblSumRow.Cells(0).Height = 2
        tblSumRow.Font.Name = "tahoma"
        tblSumRow.Font.Size = 8
        tblSumRow.Cells(0).ColumnSpan = 4
        tblSumRow.Cells(0).BackColor = Color.FromName("#000000")
        tbl1.Rows.Add(tblSumRow)

    End Sub

    Sub ShowDataTbl2()
        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        ' '' ''start by nick
        strSQL = " select cir.circuit_id, cir.circuit_name, cir.LocationNo, sumLocationNo,"
        strSQL += vbNewLine + " ((convert(decimal, cir.LocationNo)*100) / convert(decimal, cir.sumLocationNo)) as PerLocationNo,"
        strSQL += vbNewLine + " cir.screenNo, cir.sumScreenNo, ((convert(decimal, cir.screenNo)*100) / convert(decimal, cir.sumScreenNo)) as PerScreenNo,"
        strSQL += vbNewLine + " cir.NormalSeat, cir.sumNormalSeat, ((convert(decimal, cir.normalSeat)*100) / convert(decimal,cir.sumNormalSeat)) as PerNormalSeat"
        strSQL += vbNewLine + " from"
        strSQL += vbNewLine + " ("
        strSQL += vbNewLine + " select c.circuit_id, c.circuit_name,"
        strSQL += vbNewLine + " (select count(th.theater_id)"
        strSQL += vbNewLine + " from tblTheater th"
        ' th.theater_status='Enabled'
        strSQL += vbNewLine + " where ((convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"
        strSQL += vbNewLine + " and (th.circuit_id = c.circuit_id)"
        strSQL += vbNewLine + " group by th.circuit_id"
        strSQL += vbNewLine + " ) LocationNo,"
        strSQL += vbNewLine + " (select count(th.theater_id)"
        strSQL += vbNewLine + " from tblTheater th"
        'th.theater_status='Enabled' and
        strSQL += vbNewLine + " where  (convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"
        strSQL += vbNewLine + " ) sumLocationNo,"
        strSQL += vbNewLine + " (select count(sub.theatersub_id)"
        strSQL += vbNewLine + " from tblTheaterSub sub"
        strSQL += vbNewLine + " left join tblTheater th on sub.theater_id = th.theater_id"
        strSQL += vbNewLine + " where " ' th.theater_status='Enabled' and sub.status_flag = 'Y' and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"
        strSQL += vbNewLine + " and th.circuit_id = c.circuit_id"

        strSQL += vbNewLine + " and (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"


        strSQL += vbNewLine + " group by th.circuit_id"
        strSQL += vbNewLine + " ) screenNo,"
        strSQL += vbNewLine + " (select count(sub.theatersub_id)"
        strSQL += vbNewLine + " from tblTheaterSub sub"
        strSQL += vbNewLine + " left join tblTheater th on sub.theater_id = th.theater_id"
        strSQL += vbNewLine + " where " 'th.theater_status='Enabled' and sub.status_flag = 'Y' and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"


        strSQL += vbNewLine + " ) sumScreenNo,"
        strSQL += vbNewLine + " (select sum(sub.theatersub_normalseat)"
        strSQL += vbNewLine + " from tblTheaterSub sub"
        strSQL += vbNewLine + " left join tblTheater th on sub.theater_id = th.theater_id"
        strSQL += vbNewLine + " where " 'th.theater_status='Enabled' and sub.status_flag = 'Y' and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"
        strSQL += vbNewLine + " and th.circuit_id = c.circuit_id"

        strSQL += vbNewLine + " and (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"


        strSQL += vbNewLine + " group by th.circuit_id"
        strSQL += vbNewLine + " ) normalSeat,"
        strSQL += vbNewLine + " (select sum(sub.theatersub_normalseat)"
        strSQL += vbNewLine + " from tblTheaterSub sub"
        strSQL += vbNewLine + " left join tblTheater th on sub.theater_id = th.theater_id"
        strSQL += vbNewLine + " where " 'th.theater_status='Enabled' and sub.status_flag = 'Y' and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"


        strSQL += vbNewLine + " ) sumNormalSeat"
        strSQL += vbNewLine + " from tblCircuit c"
        strSQL += vbNewLine + " ) cir"
        strSQL += vbNewLine + " order by cir.circuit_id"
        'end by nick


        Dim drTbl2 As IDataReader = cDB.GetDataAll(strSQL)

        'Dim strCircuitName As String = ""
        'Dim dbLoc, dbScreen, dbSeat  As Double
        Dim dbSumLoc, dbSumScreen, dbSumSeat As Double
        'Dim decPerLoc, decPerScreen, decPerSeat As Decimal

        While (drTbl2.Read())
            Dim Tbl2Row As New TableRow()
            'strCircuitName = drTbl2("circuit_name")
            'dbLoc = Format(cDB.CheckIsNullInteger(drTbl2("LocationNo")), "#,##0")
            'decPerLoc = Format(cDB.CheckIsNullInteger(drTbl2("PerLocationNo")), "#,##0.00")

            'dbScreen = Format(cDB.CheckIsNullInteger(drTbl2("screenNo")), "#,##0")
            'decPerScreen = Format(cDB.CheckIsNullInteger(drTbl2("PerScreenNo")), "#,##0.00")

            'dbSeat = Format(cDB.CheckIsNullInteger(drTbl2("normalSeat")), "#,##0")
            'decPerSeat = Format(cDB.CheckIsNullInteger(drTbl2("PerNormalSeat")), "#,##0.00")

            dbSumLoc = Format(cDB.CheckIsNullInteger(drTbl2("sumLocationNo")), "#,##0")
            dbSumScreen = Format(cDB.CheckIsNullInteger(drTbl2("sumScreenNo")), "#,##0")
            dbSumSeat = Format(cDB.CheckIsNullInteger(drTbl2("sumNormalSeat")), "#,##0")

            Tbl2Row.HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Font.Name = "tahoma"
            Tbl2Row.Font.Size = 8
            Tbl2Row.Font.Bold = False
            Tbl2Row.VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(0).ColumnSpan = 2
            Tbl2Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            Tbl2Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            'Tbl2Row.Cells(0).Text = drTbl2("circuit_name")
            Tbl2Row.Cells(0).Text = "<a href=frmRptTheatreInformationCircuit.aspx?circuitid=" + Convert.ToString(drTbl2("circuit_id")) + ">" + drTbl2("circuit_name") + "</a>"

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(1).Text = Format(cDB.CheckIsNullInteger(drTbl2("LocationNo")), "#,##0")

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(2).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(2).Text = Format(cDB.CheckIsNullInteger(drTbl2("PerLocationNo")), "#,##0.00") + "%"

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(3).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(3).Text = Format(cDB.CheckIsNullInteger(drTbl2("screenNo")), "#,##0")

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(4).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(4).Text = Format(cDB.CheckIsNullInteger(drTbl2("PerScreenNo")), "#,##0.00") + "%"

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(5).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(5).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(5).Text = Format(cDB.CheckIsNullInteger(drTbl2("normalSeat")), "#,##0")

            Tbl2Row.Cells.Add(New TableCell)
            Tbl2Row.Cells(6).VerticalAlign = VerticalAlign.Bottom
            Tbl2Row.Cells(6).HorizontalAlign = HorizontalAlign.Right
            Tbl2Row.Cells(6).Text = Format(cDB.CheckIsNullInteger(drTbl2("PerNormalSeat")), "#,##0.00") + "%"

            tbl2.Rows.Add(Tbl2Row)

        End While
        Dim Tbl2RowTotal As New TableRow()
        Tbl2RowTotal.HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Font.Name = "tahoma"
        Tbl2RowTotal.VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Font.Size = 8
        Tbl2RowTotal.Font.Bold = True
        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(0).ColumnSpan = 2
        Tbl2RowTotal.Cells(0).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(0).Text = "Total"

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(1).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(1).Text = Format(dbSumLoc, "#,##0")

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(2).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(2).Text = "100%"

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(3).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(3).Text = Format(dbSumScreen, "#,##0")

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(4).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(4).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(4).Text = "100%"

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(5).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(5).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(5).Text = Format(dbSumSeat, "#,##0")

        Tbl2RowTotal.Cells.Add(New TableCell)
        Tbl2RowTotal.Cells(6).HorizontalAlign = HorizontalAlign.Right
        Tbl2RowTotal.Cells(6).VerticalAlign = VerticalAlign.Bottom
        Tbl2RowTotal.Cells(6).Text = "100%"

        tbl2.Rows.Add(Tbl2RowTotal)

        drTbl2.Close()

    End Sub

    Sub ShowDataTbl3()
        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        strSQL = " select c.circuit_id, c.circuit_name"
        strSQL += vbNewLine + " , isnull(sub1.mm_flag,0) as Cmm_flag"
        strSQL += vbNewLine + " , isnull(sub2.digital_flag,0) as Cdigital_flag"
        strSQL += vbNewLine + " , isnull(sub3.dimention_flag,0) as Cdimention_flag"
        strSQL += vbNewLine + " from tblCircuit c left join tblTheater t"
        strSQL += vbNewLine + " on c.circuit_id = t.circuit_id"
        strSQL += vbNewLine + " left join"
        strSQL += vbNewLine + " (select t1.circuit_id, COUNT(s1.mm_flag) as mm_flag"
        strSQL += vbNewLine + " from tblTheater t1 left join tblTheaterSub s1"
        strSQL += vbNewLine + " on t1.theater_id = s1.theater_id"
        strSQL += vbNewLine + " where s1.mm_flag='Y' and" ' s1.status_flag = 'Y' and t1.theater_status='Enabled' and "
        strSQL += vbNewLine + " ((convert(varchar(19), s1.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + "  ((convert(varchar(19), s1.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), s1.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and ((convert(varchar(19), t1.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), t1.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), t1.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " group by t1.circuit_id) sub1"
        strSQL += vbNewLine + " on c.circuit_id = sub1.circuit_id"
        strSQL += vbNewLine + " left join (select t2.circuit_id, COUNT(s2.digital_flag) as digital_flag"
        strSQL += vbNewLine + " from tblTheater t2 left join tblTheaterSub s2"
        strSQL += vbNewLine + " on t2.theater_id = s2.theater_id"
        strSQL += vbNewLine + " where s2.digital_flag='Y' and" ' s2.status_flag = 'Y' and t2.theater_status='Enabled' and "
        strSQL += vbNewLine + " ((convert(varchar(19), s2.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), s2.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), s2.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and ((convert(varchar(19), t2.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), t2.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), t2.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"


        strSQL += vbNewLine + " group by t2.circuit_id) sub2"
        strSQL += vbNewLine + " on c.circuit_id = sub2.circuit_id"
        strSQL += vbNewLine + " left join (select t3.circuit_id, COUNT(s3.dimention_flag) as dimention_flag"
        strSQL += vbNewLine + " from tblTheater t3 left join tblTheaterSub s3"
        strSQL += vbNewLine + " on t3.theater_id = s3.theater_id"
        strSQL += vbNewLine + " where s3.dimention_flag='Y' and" ' s3.status_flag = 'Y' and t3.theater_status='Enabled' and "
        strSQL += vbNewLine + " ((convert(varchar(19), s3.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), s3.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), s3.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"

        strSQL += vbNewLine + " and ((convert(varchar(19), t3.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), t3.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), t3.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))))"


        strSQL += vbNewLine + " group by t3.circuit_id) sub3"
        strSQL += vbNewLine + " on c.circuit_id = sub3.circuit_id"
        strSQL += vbNewLine + " group by c.circuit_id, c.circuit_name, sub1.mm_flag, sub2.digital_flag, sub3.dimention_flag"

        Dim drTbl3 As IDataReader = cDB.GetDataAll(strSQL)
        Dim dbSumMM, dbSum3D, dbSumDigital As Double
        dbSumMM = 0
        dbSum3D = 0
        dbSumDigital = 0
        While (drTbl3.Read())
            Dim Tbl3Row As New TableRow()

            dbSumMM = dbSumMM + cDB.CheckIsNullInteger(drTbl3("Cmm_flag"))
            dbSum3D = dbSum3D + cDB.CheckIsNullInteger(drTbl3("Cdigital_flag"))
            dbSumDigital = dbSumDigital + cDB.CheckIsNullInteger(drTbl3("Cdimention_flag"))

            Tbl3Row.HorizontalAlign = HorizontalAlign.Right
            Tbl3Row.Font.Name = "tahoma"
            Tbl3Row.Font.Size = 8
            Tbl3Row.Font.Bold = False
            Tbl3Row.VerticalAlign = VerticalAlign.Bottom
            Tbl3Row.Cells.Add(New TableCell)
            Tbl3Row.Cells(0).ColumnSpan = 2
            Tbl3Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            Tbl3Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            'Tbl3Row.Cells(0).Text = drTbl3("circuit_name")
            Tbl3Row.Cells(0).Text = "<a href=frmRptTheatreInformationCircuit.aspx?circuitid=" + Convert.ToString(drTbl3("circuit_id")) + ">" + drTbl3("circuit_name") + "</a>"

            Tbl3Row.Cells.Add(New TableCell)
            Tbl3Row.Cells(1).ColumnSpan = 2
            Tbl3Row.Cells(1).HorizontalAlign = HorizontalAlign.Right
            Tbl3Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            Tbl3Row.Cells(1).Text = Format(cDB.CheckIsNullInteger(drTbl3("Cmm_flag")), "#,##0")

            Tbl3Row.Cells.Add(New TableCell)
            Tbl3Row.Cells(2).ColumnSpan = 2
            Tbl3Row.Cells(2).HorizontalAlign = HorizontalAlign.Right
            Tbl3Row.Cells(2).VerticalAlign = VerticalAlign.Bottom
            Tbl3Row.Cells(2).Text = Format(cDB.CheckIsNullInteger(drTbl3("Cdigital_flag")), "#,##0")

            Tbl3Row.Cells.Add(New TableCell)
            Tbl3Row.Cells(3).ColumnSpan = 2
            Tbl3Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            Tbl3Row.Cells(3).VerticalAlign = VerticalAlign.Bottom
            Tbl3Row.Cells(3).Text = Format(cDB.CheckIsNullInteger(drTbl3("Cdimention_flag")), "#,##0")

            tbl3.Rows.Add(Tbl3Row)

        End While
        Dim Tbl3RowTotal As New TableRow()
        Tbl3RowTotal.HorizontalAlign = HorizontalAlign.Right
        Tbl3RowTotal.Font.Name = "tahoma"
        Tbl3RowTotal.VerticalAlign = VerticalAlign.Bottom
        Tbl3RowTotal.Font.Size = 8
        Tbl3RowTotal.Font.Bold = True
        Tbl3RowTotal.Cells.Add(New TableCell)
        Tbl3RowTotal.Cells(0).ColumnSpan = 2
        Tbl3RowTotal.Cells(0).VerticalAlign = VerticalAlign.Bottom
        Tbl3RowTotal.Cells(0).Text = "Total"

        Tbl3RowTotal.Cells.Add(New TableCell)
        Tbl3RowTotal.Cells(1).ColumnSpan = 2
        Tbl3RowTotal.Cells(1).HorizontalAlign = HorizontalAlign.Right
        Tbl3RowTotal.Cells(1).VerticalAlign = VerticalAlign.Bottom
        Tbl3RowTotal.Cells(1).Text = Format(dbSumMM, "#,##0")

        Tbl3RowTotal.Cells.Add(New TableCell)
        Tbl3RowTotal.Cells(2).ColumnSpan = 2
        Tbl3RowTotal.Cells(2).HorizontalAlign = HorizontalAlign.Right
        Tbl3RowTotal.Cells(2).VerticalAlign = VerticalAlign.Bottom
        Tbl3RowTotal.Cells(2).Text = Format(dbSum3D, "#,##0")

        Tbl3RowTotal.Cells.Add(New TableCell)
        Tbl3RowTotal.Cells(3).ColumnSpan = 2
        Tbl3RowTotal.Cells(3).HorizontalAlign = HorizontalAlign.Right
        Tbl3RowTotal.Cells(3).VerticalAlign = VerticalAlign.Bottom
        Tbl3RowTotal.Cells(3).Text = Format(dbSumDigital, "#,##0")

        tbl3.Rows.Add(Tbl3RowTotal)

        drTbl3.Close()

    End Sub

    Sub ShowDataTbl4()
        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        ' '' ''start by nick
        '' ''strSQL = " select c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name"
        '' ''strSQL += vbNewLine + " , s1.theatersub_name, s1.open_date, s1.close_date,  t1.theater_name +' '+ s1.theatersub_name as theatreScreen"
        '' ''strSQL += vbNewLine + " from tblTheaterSub s1  left join tblTheater t1"
        '' ''strSQL += vbNewLine + " on t1.theater_id = s1.theater_id"
        '' ''strSQL += vbNewLine + " left join tblCircuit c"
        '' ''strSQL += vbNewLine + " on c.circuit_id = t1.circuit_id"
        '' ''strSQL += vbNewLine + " where t1.theater_status = 'Enabled' and s1.status_flag = 'Y'"
        '' ''strSQL += vbNewLine + " and t1.circuit_id = c.circuit_id"
        '' ''strSQL += vbNewLine + " AND CONVERT(VARCHAR(19), s1.open_date, 111) >= CONVERT(VARCHAR(19), '" + strOpenDate + "', 111)"
        '' ''strSQL += vbNewLine + " AND (CONVERT(VARCHAR(19), s1.close_date, 111) <= CONVERT(VARCHAR(19), '" + strCloseDate + "', 111)"
        '' ''strSQL += vbNewLine + " or (s1.close_date is null))"
        '' ''strSQL += vbNewLine + " group by c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name ,s1.theatersub_name"
        '' ''strSQL += vbNewLine + " , s1.open_date,s1.close_date"
        '' ''strSQL += vbNewLine + " order by  c.circuit_id, t1.theater_name, s1.theatersub_name, s1.open_date"
        ' '' ''end by nick

        'start by muay
        strSQL = " select c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name, "
        strSQL += vbNewLine + " s1.theatersub_name, s1.open_date, s1.close_date,  (t1.theater_name +' '+ s1.theatersub_name) as theatreScreen"
        strSQL += vbNewLine + " from tblTheaterSub s1  "
        strSQL += vbNewLine + " left join tblTheater t1 on t1.theater_id = s1.theater_id"
        strSQL += vbNewLine + " left join tblCircuit c on c.circuit_id = t1.circuit_id"
        ' s1.status_flag = 'Y' and t1.theater_status='Enabled' and
        strSQL += vbNewLine + " where (convert(varchar(19), s1.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), s1.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), s1.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"
        strSQL += vbNewLine + " group by c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name ,s1.theatersub_name, s1.open_date,s1.close_date"
        strSQL += vbNewLine + " order by  c.circuit_id, t1.theater_name, s1.theatersub_name, s1.open_date"
        'end by muay


        Dim drTbl4 As IDataReader = cDB.GetDataAll(strSQL)

        While (drTbl4.Read())
            Dim Tbl4Row As New TableRow()
            Tbl4Row.HorizontalAlign = HorizontalAlign.Right
            Tbl4Row.Font.Name = "tahoma"
            Tbl4Row.Font.Size = 8
            Tbl4Row.Font.Bold = False
            Tbl4Row.VerticalAlign = VerticalAlign.Bottom
            Tbl4Row.Cells.Add(New TableCell)
            Tbl4Row.Cells(0).ColumnSpan = 4
            Tbl4Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            Tbl4Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            Tbl4Row.Cells(0).Text = cDB.CheckIsNullString(drTbl4("theatreScreen"))
            Tbl4Row.Cells.Add(New TableCell)
            Tbl4Row.Cells(1).ColumnSpan = 4
            Tbl4Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
            Tbl4Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            Tbl4Row.Cells(1).Text = "Open on " + Format(cDB.CheckIsNullDateTime(drTbl4("open_date")), "MMM dd yyyy")
            tbl4.Rows.Add(Tbl4Row)
        End While

        drTbl4.Close()

    End Sub

    Sub ShowDataTbl5()
        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        'start by Muay
        strSQL = "select c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name, "
        strSQL += vbNewLine + " s1.theatersub_name, s1.open_date, s1.close_date,  (t1.theater_name +' '+ s1.theatersub_name) as theatreScreen"
        strSQL += vbNewLine + " from tblTheaterSub s1  "
        strSQL += vbNewLine + " left join tblTheater t1 on t1.theater_id = s1.theater_id"
        strSQL += vbNewLine + " left join tblCircuit c on c.circuit_id = t1.circuit_id"
        ' s1.status_flag = 'Y' and t1.theater_status='Enabled' and 
        'strSQL += vbNewLine + " where (convert(varchar(19), s1.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111))"


        strSQL += vbNewLine + " where (convert(varchar(19), s1.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), s1.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), s1.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"



        strSQL += vbNewLine + " group by c.circuit_id, c.circuit_name, t1.theater_id, t1.theater_name ,s1.theatersub_name, s1.open_date,s1.close_date"
        strSQL += vbNewLine + " order by  c.circuit_id, t1.theater_name, s1.theatersub_name, s1.open_date"
        'end by Muay

        Dim drTbl5 As IDataReader = cDB.GetDataAll(strSQL)

        While (drTbl5.Read())
            Dim Tbl5Row As New TableRow()
            Tbl5Row.HorizontalAlign = HorizontalAlign.Right
            Tbl5Row.Font.Name = "tahoma"
            Tbl5Row.Font.Size = 8
            Tbl5Row.Font.Bold = False
            Tbl5Row.VerticalAlign = VerticalAlign.Bottom
            Tbl5Row.Cells.Add(New TableCell)
            Tbl5Row.Cells(0).ColumnSpan = 4
            Tbl5Row.Cells(0).HorizontalAlign = HorizontalAlign.Left
            Tbl5Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            Tbl5Row.Cells(0).Text = cDB.CheckIsNullString(drTbl5("theatreScreen"))
            Tbl5Row.Cells.Add(New TableCell)
            Tbl5Row.Cells(1).ColumnSpan = 4
            Tbl5Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
            Tbl5Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            Tbl5Row.Cells(1).Text = "Close on " + Format(cDB.CheckIsNullDateTime(drTbl5("close_date")), "MMM dd yyyy")
            tbl5.Rows.Add(Tbl5Row)
        End While

        drTbl5.Close()

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

        ShowDataTbl1Print()
        ShowDataTbl2()
        ShowDataTbl3()
        ShowDataTbl4()
        ShowDataTbl5()

        tblMain.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

    Sub ShowDataTbl1Print()
        tblHead.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")

        Dim strSQL As String
        Dim strOpenDate As String = Format(Session("msRptStrDate"), "yyyy/MM/dd")
        Dim strCloseDate As String = Format(Session("msRptEndDate"), "yyyy/MM/dd")

        'strSQL = "select th.circuit_id, th.theater_id, th.theater_name,"
        'strSQL += vbNewLine + " (select count(sub.theatersub_id)"
        'strSQL += vbNewLine + " from tblTheaterSub sub"
        'strSQL += vbNewLine + " where (sub.status_flag = 'Y') and (sub.theater_id = th.theater_id)"
        'strSQL += vbNewLine + " group by sub.theater_id"
        'strSQL += vbNewLine + " ) sumScreen,"
        'strSQL += vbNewLine + " isnull((select sum(isnull(seat.theatersub_normalseat, 0))"
        'strSQL += vbNewLine + " from tblTheaterSub seat"
        'strSQL += vbNewLine + " where (seat.theater_id = th.theater_id)"
        'strSQL += vbNewLine + " group by seat.theater_id"
        'strSQL += vbNewLine + " ),0) sumseat_qty"
        'strSQL += vbNewLine + " from tblTheater th"
        'strSQL += vbNewLine + " where ((convert(varchar(19), th.open_date, 111) >= convert(varchar(19), '" + strOpenDate + "', 111)) "
        'strSQL += vbNewLine + " or (convert(varchar(19), th.open_date, 111) is null))"
        'strSQL += vbNewLine + " and ((convert(varchar(19), th.close_date, 111) <= convert(varchar(19), '" + strCloseDate + "', 111))"
        'strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) is null))"
        'strSQL += vbNewLine + " order by th.circuit_id, th.theater_id"

        strSQL = "select th.circuit_id, th.theater_id, th.theater_name,"
        strSQL += vbNewLine + " isnull((select count(sub.theatersub_id)"
        strSQL += vbNewLine + " from tblTheaterSub sub"

        strSQL += vbNewLine + " where (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"

        strSQL += vbNewLine + " and (sub.theater_id = th.theater_id)" ' and (sub.status_flag = 'Y')"
        strSQL += vbNewLine + " group by sub.theater_id"
        strSQL += vbNewLine + " ),0) sumScreen,"
        strSQL += vbNewLine + " isnull((select sum(isnull(seat.theatersub_normalseat, 0))"
        strSQL += vbNewLine + " from tblTheaterSub seat left join  tblTheaterSub sub on seat.theatersub_id=sub.theatersub_id"
        strSQL += vbNewLine + " where (convert(varchar(19), sub.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), sub.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), sub.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"

        strSQL += vbNewLine + " and (seat.theater_id = th.theater_id)"
        strSQL += vbNewLine + " group by seat.theater_id"
        strSQL += vbNewLine + " ),0) sumseat_qty"
        strSQL += vbNewLine + " from tblTheater th"
        'th.theater_status='Enabled' and
        strSQL += vbNewLine + " where (convert(varchar(19), th.open_date, 111) <= convert(varchar(19), '" + strOpenDate + "', 111)) "
        strSQL += vbNewLine + " and "
        strSQL += vbNewLine + " ((convert(varchar(19), th.close_date, 111) is null)"
        strSQL += vbNewLine + " or (convert(varchar(19), th.close_date, 111) > convert(varchar(19), '" + strOpenDate + "', 111)))"
        strSQL += vbNewLine + " order by th.circuit_id, th.theater_name"

        Dim drTbl1 As IDataReader = cDB.GetDataAll(strSQL)

        Dim strTheatreName As String = ""
        Dim dbCircuitID, dbNo As Double ', dbScreen, dbSeat
        Dim i As Integer = 0
        dbCircuitID = 1
        While (drTbl1.Read())


            Dim tblSumRowIn As New TableRow()
            If (ViewState("StartLineTbl1") Is Nothing) Then
                ViewState("StartLineTbl1") = cDB.CheckIsNullString(drTbl1("circuit_id")).Trim()
            Else
                If Convert.ToString(ViewState("StartLineTbl1")).Trim() <> cDB.CheckIsNullString(drTbl1("circuit_id")).Trim() Then
                    If cDB.CheckIsNullString(drTbl1("circuit_id")).Trim() <> "1" Then
                        tblSumRowIn.Cells.Add(New TableCell)
                        tblSumRowIn.Cells(0).HorizontalAlign = HorizontalAlign.Center
                        'tblSumRowIn.Cells(0).Height = 2
                        tblSumRowIn.Font.Name = "tahoma"
                        tblSumRowIn.Font.Size = 8
                        tblSumRowIn.Cells(0).ColumnSpan = 4
                        tblSumRowIn.Cells(0).BackColor = Color.FromName("#000000")
                        tbl1.Rows.Add(tblSumRowIn)
                    End If
                    ViewState("StartLineTbl1") = cDB.CheckIsNullString(drTbl1("circuit_id")).Trim()
                End If
            End If


            If dbCircuitID = drTbl1("circuit_id") Then
                i = i + 1
            Else
                i = 1
                dbCircuitID = drTbl1("circuit_id")
            End If
            dbNo = i
            'strTheatreName = cDB.CheckIsNullString(drTbl1("theater_name"))
            'dbScreen = Format(cDB.CheckIsNullInteger(drTbl1("sumScreen")), "#,##0")
            'dbSeat = Format(cDB.CheckIsNullInteger(drTbl1("sumSeat_qty")), "#,##0")

            Dim tbl1Row As New TableRow()
            tbl1Row.HorizontalAlign = HorizontalAlign.Center
            tbl1Row.Font.Name = "tahoma"
            tbl1Row.Font.Size = 8
            tbl1Row.Font.Bold = False
            tbl1Row.VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(0).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(0).Text = dbNo.ToString()

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
            tbl1Row.Cells(1).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(1).Text = cDB.CheckIsNullString(drTbl1("theater_name"))

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
            tbl1Row.Cells(2).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(2).Text = Format(cDB.CheckIsNullInteger(drTbl1("sumScreen")), "#,##0")

            tbl1Row.Cells.Add(New TableCell)
            tbl1Row.Cells(3).HorizontalAlign = HorizontalAlign.Right
            tbl1Row.Cells(3).VerticalAlign = VerticalAlign.Bottom
            tbl1Row.Cells(3).Text = Format(cDB.CheckIsNullInteger(drTbl1("sumSeat_qty")), "#,##0")

            tbl1.Rows.Add(tbl1Row)

        End While
        drTbl1.Close()

        Dim tblSumRow As New TableRow()
        tblSumRow.Cells.Add(New TableCell)
        tblSumRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
        'tblSumRow.Cells(0).Height = 2
        tblSumRow.Font.Name = "tahoma"
        tblSumRow.Font.Size = 8
        tblSumRow.Cells(0).ColumnSpan = 4
        tblSumRow.Cells(0).BackColor = Color.FromName("#000000")
        tbl1.Rows.Add(tblSumRow)

    End Sub

End Class