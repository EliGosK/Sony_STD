Imports Web.Data
Partial Public Class frmRptMarketSareByCircuit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Mid(Session("permission"), 19, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        End If

        Dim getBoxOfficeData As New cDatabase
        Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeSharingByCir(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "BKK")
        Dim readBoxOfficeTotal As IDataReader = getBoxOfficeData.getBoxOfficeSharingByCir(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "Total")
        Dim grandTotalBox, grandTotalAdms As Double
        If readBoxOfficeTotal.Read() Then
            grandTotalBox = readBoxOfficeTotal("sumAmount")
            grandTotalAdms = readBoxOfficeTotal("sumAdms")
        End If
        readBoxOfficeTotal.Close()
        tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
        tbl.Rows(2).Cells(0).Text = "" & Session("msRptMovieName")

        Dim sessionCount, SumBox, SumAdms, rowCount As Double
        Dim lastTheater As String
        Dim movieSys As String
        Dim movieSound As String
        lastTheater = ""
        sessionCount = 0
        movieSys = ""
        movieSound = ""
        SumBox = 0
        SumAdms = 0
        rowCount = 0
        While (readBoxOfficeData.Read())
            Dim detailsRow As New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            rowCount = rowCount + 1
            'Dim i As Double
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).Text = rowCount
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(1).Text = readBoxOfficeData("circuit_name")
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(2).Text = Format(readBoxOfficeData("sumAmount"), "#,##0")
            SumBox = SumBox + CDbl(readBoxOfficeData("sumAmount"))
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(3).Text = Format(readBoxOfficeData("sumAdms"), "#,##0")
            SumAdms = SumAdms + CDbl(readBoxOfficeData("sumAdms"))
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(4).Text = Format(CDbl(readBoxOfficeData("sumAmount")) / CDbl(readBoxOfficeData("sumAdms")), "#,##0")
            detailsRow.Cells.Add(New TableCell)
            'detailsRow.Cells(5).BackColor = Color.GreenYellow
            detailsRow.Cells(5).Text = "0"
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(6).Text = "0"
            detailsRow.Cells(6).Visible = False
            detailsRow.Cells.Add(New TableCell)
            'detailsRow.Cells(7).BackColor = Color.GreenYellow
            detailsRow.Cells(7).Text = "0"
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(8).Text = "0"
            detailsRow.Cells(8).Visible = False
            tbl.Rows.Add(detailsRow)
        End While
        readBoxOfficeData.Close()

        Dim i As Integer
        Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
        sumPerBox = 0
        sumPerAdms = 0
        sumPerBoxAll = 0
        sumPerAdmsAll = 0

        For i = 1 To rowCount
            tbl.Rows(i + 5).Cells(5).Text = Format(CDbl(tbl.Rows(i + 5).Cells(2).Text) * 100 / SumBox, "#,##0.00") & "%"
            tbl.Rows(i + 5).Cells(7).Text = Format(CDbl(tbl.Rows(i + 5).Cells(3).Text) * 100 / SumAdms, "#,##0.00") & "%"

            tbl.Rows(i + 5).Cells(6).Text = Format(CDbl(tbl.Rows(i + 5).Cells(2).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
            tbl.Rows(i + 5).Cells(6).Visible = False
            tbl.Rows(i + 5).Cells(8).Text = Format(CDbl(tbl.Rows(i + 5).Cells(3).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
            tbl.Rows(i + 5).Cells(8).Visible = False
            sumPerBox = sumPerBox + CDbl(tbl.Rows(i + 5).Cells(2).Text) * 100 / SumBox
            sumPerAdms = sumPerAdms + CDbl(tbl.Rows(i + 5).Cells(3).Text) * 100 / SumAdms
            sumPerBoxAll = sumPerBoxAll + CDbl(tbl.Rows(i + 5).Cells(2).Text) * 100 / grandTotalBox
            sumPerAdmsAll = sumPerAdmsAll + CDbl(tbl.Rows(i + 5).Cells(3).Text) * 100 / grandTotalAdms

        Next
        Dim totalRow As New TableRow()
        'totalRow.BackColor = Color.FromName("#CADCEF")
        totalRow.HorizontalAlign = HorizontalAlign.Center
        totalRow.Font.Bold = True
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(0).Text = ""
        totalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(1).Text = "TOTAL FOR BANGKOK"
        totalRow.Cells(1).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(2).Text = Format(SumBox, "#,##0")
        totalRow.Cells(2).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(3).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(3).Text = Format(SumAdms, "#,##0")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(4).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(4).Text = Format(SumBox / SumAdms, "#,##0")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(5).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(5).Text = Format(sumPerBox, "#,##0.00") & "%"
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(6).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(6).Text = Format(sumPerBoxAll, "#,##0.00") & "%"
        totalRow.Cells(6).Visible = False
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(7).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(7).Text = Format(sumPerAdms, "#,##0.00") & "%"
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(8).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(8).Text = Format(sumPerAdmsAll, "#,##0.00") & "%"
        totalRow.Cells(8).Visible = False
        tbl.Rows.Add(totalRow)
        'End Bkk--------------------



        '----------Start Chiangmai--------------------
        Dim cmHeaderCity As New TableRow()
        cmHeaderCity.Cells.Add(New TableCell)
        cmHeaderCity.Cells(0).BackColor = Color.FromName("#c3cad6")
        cmHeaderCity.Cells(0).ColumnSpan = 7
        cmHeaderCity.Cells(0).Font.Size = 10
        cmHeaderCity.Cells(0).Font.Bold = True

        cmHeaderCity.Cells(0).Text = "CHIENG MAI"
        cmHeaderCity.Cells(0).HorizontalAlign = HorizontalAlign.Center

        tbl.Rows.Add(cmHeaderCity)

        Dim cmHeaderRow As New TableRow()
        'cmHeaderRow.BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.HorizontalAlign = HorizontalAlign.Center
        cmHeaderRow.Font.Bold = True
        cmHeaderRow.ForeColor = Color.White

        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(0).RowSpan = 2
        cmHeaderRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(0).Text = "RANKING"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(1).RowSpan = 2
        cmHeaderRow.Cells(1).Text = "CIRCUIT"
        cmHeaderRow.Cells(1).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(2).RowSpan = 2
        cmHeaderRow.Cells(2).Text = "BOX OFFICE"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(3).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(3).RowSpan = 2
        cmHeaderRow.Cells(3).Text = "ADMS"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(4).RowSpan = 2
        cmHeaderRow.Cells(4).Text = "ATP"
        cmHeaderRow.Cells(4).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(5).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(5).ColumnSpan = 1
        cmHeaderRow.Cells(5).Text = "B.O. GROSS"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(6).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(6).ColumnSpan = 1
        cmHeaderRow.Cells(6).Text = "ADMISSION"
        tbl.Rows.Add(cmHeaderRow)
        Dim cmHeaderRowPer As New TableRow()
        'cmHeaderRowPer.BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.HorizontalAlign = HorizontalAlign.Center
        cmHeaderRowPer.Font.Bold = True
        cmHeaderRowPer.ForeColor = Color.White

        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(0).Text = "BY CM"
        cmHeaderRowPer.Cells(0).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(0).ForeColor = Color.FromName("#FFFFFF")
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(1).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(1).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(1).ForeColor = Color.FromName("#FFFFFF")
        cmHeaderRowPer.Cells(1).Visible = False
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(2).Text = "BY CM"
        cmHeaderRowPer.Cells(2).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(2).ForeColor = Color.FromName("#FFFFFF")
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(3).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(3).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(3).ForeColor = Color.FromName("#FFFFFF")
        cmHeaderRowPer.Cells(3).Visible = False

        tbl.Rows.Add(cmHeaderRowPer)
        Dim getBoxOfficeDataCM As New cDatabase
        Dim readBoxOfficeDataCM As IDataReader = getBoxOfficeDataCM.getBoxOfficeSharingByCir(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "CM")
        Dim rowcountCm, SumBoxCm, SumAdmsCm As Double
        rowcountCm = 0
        SumAdmsCm = 0
        SumBoxCm = 0
        While (readBoxOfficeDataCM.Read())
            rowcountCm = rowcountCm + 1
            Dim detailRowCm As New TableRow()
            detailRowCm.HorizontalAlign = HorizontalAlign.Center

            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(0).Text = rowcountCm
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(1).Text = readBoxOfficeDataCM("circuit_name")
            detailRowCm.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(2).Text = Format(readBoxOfficeDataCM("sumAmount"), "#,##0")
            detailRowCm.Cells(2).HorizontalAlign = HorizontalAlign.Right

            SumBoxCm = SumBoxCm + CDbl(readBoxOfficeDataCM("sumAmount"))
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(3).HorizontalAlign = HorizontalAlign.Right
            detailRowCm.Cells(3).Text = Format(readBoxOfficeDataCM("sumAdms"), "#,##0")
            SumAdmsCm = SumAdmsCm + CDbl(readBoxOfficeDataCM("sumAdms"))
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(4).Text = Format(CDbl(readBoxOfficeDataCM("sumAmount")) / CDbl(readBoxOfficeDataCM("sumAdms")), "#,##0")
            detailRowCm.Cells.Add(New TableCell)
            'detailRowCm.Cells(5).BackColor = Color.GreenYellow
            detailRowCm.Cells(5).Text = "0"
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(6).Text = "0"
            detailRowCm.Cells(6).Visible = False
            detailRowCm.Cells.Add(New TableCell)
            'detailRowCm.Cells(7).BackColor = Color.GreenYellow
            detailRowCm.Cells(7).Text = "0"
            detailRowCm.Cells.Add(New TableCell)
            detailRowCm.Cells(8).Text = "0"
            detailRowCm.Cells(8).Visible = False
            tbl.Rows.Add(detailRowCm)
        End While
        readBoxOfficeDataCM.Close()

        Dim sumPerBoxCm, sumPerAdmsCm, sumPerAdmsCmAll, sumPerBoxCmAll As Double
        sumPerBoxCm = 0
        sumPerAdmsCm = 0
        sumPerAdmsCmAll = 0
        sumPerBoxCmAll = 0
        Dim iCm As Double
        For iCm = 1 To rowcountCm
            tbl.Rows(iCm + rowCount + 9).Cells(5).Text = Format(CDbl(tbl.Rows(iCm + rowCount + 9).Cells(2).Text) * 100 / SumBoxCm, "#,##0.00") & "%"
            tbl.Rows(iCm + rowCount + 9).Cells(7).Text = Format(CDbl(tbl.Rows(iCm + rowCount + 9).Cells(3).Text) * 100 / SumAdmsCm, "#,##0.00") & "%"
            tbl.Rows(iCm + rowCount + 9).Cells(6).Text = Format(CDbl(tbl.Rows(iCm + rowCount + 9).Cells(2).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
            tbl.Rows(iCm + rowCount + 9).Cells(6).Visible = False
            tbl.Rows(iCm + rowCount + 9).Cells(8).Text = Format(CDbl(tbl.Rows(iCm + rowCount + 9).Cells(3).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
            tbl.Rows(iCm + rowCount + 9).Cells(8).Visible = False
            sumPerBoxCm = sumPerBoxCm + CDbl(tbl.Rows(iCm + rowCount + 9).Cells(2).Text) * 100 / SumBoxCm
            sumPerAdmsCm = sumPerAdmsCm + CDbl(tbl.Rows(iCm + rowCount + 9).Cells(3).Text) * 100 / SumAdmsCm
            sumPerBoxCmAll = sumPerBoxCmAll + CDbl(tbl.Rows(iCm + rowCount + 9).Cells(2).Text) * 100 / grandTotalBox
            sumPerAdmsCmAll = sumPerAdmsCmAll + CDbl(tbl.Rows(iCm + rowCount + 9).Cells(3).Text) * 100 / grandTotalAdms
        Next
        Dim totalRowCm As New TableRow()
        'totalRowCm.BackColor = Color.FromName("#CADCEF")
        totalRowCm.HorizontalAlign = HorizontalAlign.Center
        totalRowCm.Font.Bold = True

        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(0).Text = ""
        totalRowCm.Cells(0).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(1).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(1).Text = "TOTAL FOR CHIENG MAI"
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(2).Text = Format(SumBoxCm, "#,##0")
        totalRowCm.Cells(2).HorizontalAlign = HorizontalAlign.Right
        totalRowCm.Cells(2).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(3).Text = Format(SumAdmsCm, "#,##0")
        totalRowCm.Cells(3).HorizontalAlign = HorizontalAlign.Right
        totalRowCm.Cells(3).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(4).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(4).Text = Format(SumBoxCm / SumAdmsCm, "#,##0")
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(5).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(5).Text = Format(sumPerBoxCm, "#,##0.00") & "%"
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(6).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(6).Text = Format(sumPerBoxCmAll, "#,##0.00") & "%"
        totalRowCm.Cells(6).Visible = False
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(7).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(7).Text = Format(sumPerAdmsCm, "#,##0.00") & "%"
        totalRowCm.Cells.Add(New TableCell)
        totalRowCm.Cells(8).BackColor = Color.FromName("#CADCEF")
        totalRowCm.Cells(8).Text = Format(sumPerAdmsCmAll, "#,##0.00") & "%"
        totalRowCm.Cells(8).Visible = False
        tbl.Rows.Add(totalRowCm)
        '------------End Cheang Mai


        'Dim GrandotalRow As New TableRow()
        ''GrandotalRow.BackColor = Color.FromName("#CADCEF")
        'GrandotalRow.HorizontalAlign = HorizontalAlign.Center
        'GrandotalRow.Font.Bold = True

        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(0).Text = ""
        'GrandotalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(1).Text = "TOTAL"
        'GrandotalRow.Cells(1).BackColor = Color.DarkGray
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(2).BackColor = Color.DarkGray
        'GrandotalRow.Cells(2).Text = Format(grandTotalBox, "#,##0")
        'GrandotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(3).BackColor = Color.DarkGray
        'GrandotalRow.Cells(3).Text = Format(grandTotalAdms, "#,##0")
        'GrandotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(4).BackColor = Color.DarkGray
        'GrandotalRow.Cells(4).Text = Format(grandTotalBox / grandTotalAdms, "#,##0.00")
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(5).BackColor = Color.DarkGray
        'GrandotalRow.Cells(5).Text = ""
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(6).BackColor = Color.DarkGray
        'GrandotalRow.Cells(6).Text = "100%"
        'GrandotalRow.Cells(6).Visible = False
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(7).BackColor = Color.DarkGray
        'GrandotalRow.Cells(7).Text = ""
        'GrandotalRow.Cells.Add(New TableCell)
        'GrandotalRow.Cells(8).BackColor = Color.DarkGray
        'GrandotalRow.Cells(8).Text = "100%"
        'GrandotalRow.Cells(8).Visible = False
        'tbl.Rows.Add(GrandotalRow)









        '----------------Key City -------------------------------
        cmHeaderCity = New TableRow()
        cmHeaderCity.Cells.Add(New TableCell)
        cmHeaderCity.Cells(0).BackColor = Color.FromName("#c3cad6")
        cmHeaderCity.Cells(0).ColumnSpan = 7
        cmHeaderCity.Cells(0).Font.Size = 10
        cmHeaderCity.Cells(0).Font.Bold = True
        cmHeaderCity.Cells(0).Text = "KEY CITY"
        cmHeaderCity.Cells(0).HorizontalAlign = HorizontalAlign.Center
        tbl.Rows.Add(cmHeaderCity)

        getBoxOfficeData = New cDatabase
        readBoxOfficeData = getBoxOfficeData.getBoxOfficeSharingByCir(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "CITY")

        'Dim sessionCount, SumBox, SumAdms, rowCount As Double
        'Dim lastTheater As String
        'Dim movieSys As String
        'Dim movieSound As String
        lastTheater = ""
        sessionCount = 0
        movieSys = ""
        movieSound = ""
        SumBox = 0
        SumAdms = 0
        rowCount = 0


        cmHeaderRow = New TableRow()
        'cmHeaderRow.BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.HorizontalAlign = HorizontalAlign.Center
        cmHeaderRow.Font.Bold = True
        cmHeaderRow.ForeColor = Color.White

        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(0).RowSpan = 2
        cmHeaderRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(0).Text = "RANKING"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(1).RowSpan = 2
        cmHeaderRow.Cells(1).Text = "CIRCUIT"
        cmHeaderRow.Cells(1).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(2).RowSpan = 2
        cmHeaderRow.Cells(2).Text = "BOX OFFICE"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(3).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(3).RowSpan = 2
        cmHeaderRow.Cells(3).Text = "ADMS"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(4).RowSpan = 2
        cmHeaderRow.Cells(4).Text = "ATP"
        cmHeaderRow.Cells(4).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(5).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(5).ColumnSpan = 1
        cmHeaderRow.Cells(5).Text = "B.O. GROSS"
        cmHeaderRow.Cells.Add(New TableCell)
        cmHeaderRow.Cells(6).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRow.Cells(6).ColumnSpan = 1
        cmHeaderRow.Cells(6).Text = "ADMISSION"
        tbl.Rows.Add(cmHeaderRow)

        cmHeaderRowPer = New TableRow()
        'cmHeaderRowPer.BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.HorizontalAlign = HorizontalAlign.Center
        cmHeaderRowPer.Font.Bold = True
        cmHeaderRowPer.ForeColor = Color.White

        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(0).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(0).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(1).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(1).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(1).Visible = False
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(2).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(2).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells.Add(New TableCell)
        cmHeaderRowPer.Cells(3).Text = "BY KEY CITY"
        cmHeaderRowPer.Cells(3).BackColor = Color.FromName("#5D7B9D")
        cmHeaderRowPer.Cells(3).Visible = False

        tbl.Rows.Add(cmHeaderRowPer)


        While (readBoxOfficeData.Read())
            Dim detailsRow As New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            rowCount = rowCount + 1
            'Dim i As Double
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).Text = rowCount
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
            detailsRow.Cells(1).Text = readBoxOfficeData("circuit_name")
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(2).Text = Format(readBoxOfficeData("sumAmount"), "#,##0")
            SumBox = SumBox + CDbl(readBoxOfficeData("sumAmount"))
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(3).Text = Format(readBoxOfficeData("sumAdms"), "#,##0")
            SumAdms = SumAdms + CDbl(readBoxOfficeData("sumAdms"))
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(4).Text = Format(CDbl(readBoxOfficeData("sumAmount")) / CDbl(readBoxOfficeData("sumAdms")), "#,##0")
            detailsRow.Cells.Add(New TableCell)
            'detailsRow.Cells(5).BackColor = Color.GreenYellow
            detailsRow.Cells(5).Text = "0"
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(6).Text = "0"
            detailsRow.Cells(6).Visible = False
            detailsRow.Cells.Add(New TableCell)
            'detailsRow.Cells(7).BackColor = Color.GreenYellow
            detailsRow.Cells(7).Text = "0"
            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(8).Text = "0"
            detailsRow.Cells(8).Visible = False
            tbl.Rows.Add(detailsRow)
        End While
        readBoxOfficeData.Close()

        'Dim i As Integer
        'Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
        i = 0
        sumPerBox = 0
        sumPerAdms = 0
        sumPerBoxAll = 0
        sumPerAdmsAll = 0

        For i = 0 To rowCount - 1
            Dim rows As Integer = iCm + rowCount + i + 13
            tbl.Rows(rows).Cells(5).Text = Format(CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / SumBox, "#,##0.00") & "%"
            tbl.Rows(rows).Cells(7).Text = Format(CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / SumAdms, "#,##0.00") & "%"

            tbl.Rows(rows).Cells(6).Text = Format(CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
            tbl.Rows(rows).Cells(6).Visible = False
            tbl.Rows(rows).Cells(8).Text = Format(CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
            tbl.Rows(rows).Cells(8).Visible = False
            sumPerBox = sumPerBox + CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / SumBox
            sumPerAdms = sumPerAdms + CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / SumAdms
            sumPerBoxAll = sumPerBoxAll + CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / grandTotalBox
            sumPerAdmsAll = sumPerAdmsAll + CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / grandTotalAdms

        Next
        totalRow = New TableRow()
        'totalRow.BackColor = Color.FromName("#CADCEF")
        totalRow.HorizontalAlign = HorizontalAlign.Center
        totalRow.Font.Bold = True
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(0).Text = ""
        totalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(1).Text = "TOTAL FOR KEY CITY"
        totalRow.Cells(1).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(2).Text = Format(grandTotalBox, "#,##0")
        totalRow.Cells(2).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(3).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(3).Text = Format(grandTotalAdms, "#,##0")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(4).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(4).Text = Format(grandTotalBox / grandTotalAdms, "#,##0")
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(5).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(5).Text = Format(sumPerBox, "#,##0.00") & "%"
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(6).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(6).Text = Format(sumPerBoxAll, "#,##0.00") & "%"
        totalRow.Cells(6).Visible = False
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(7).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(7).Text = Format(sumPerAdms, "#,##0.00") & "%"
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(8).BackColor = Color.FromName("#CADCEF")
        totalRow.Cells(8).Text = Format(sumPerAdmsAll, "#,##0.00") & "%"
        totalRow.Cells(8).Visible = False
        tbl.Rows.Add(totalRow)
        'End CITY--------------------





    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptMarketShareParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & "Market_Share_By_Circuit.xls")
        Response.Charset = "windows-874"
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        tbl.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub
End Class