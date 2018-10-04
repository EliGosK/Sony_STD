Imports Web.Data

Partial Public Class frmRptCompMarketSareByCircuit
    Inherits System.Web.UI.Page

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim cDB As New cDatabase
    '    Dim DrData As IDataReader = cDB.getBoxOfficeSharingByCirComp(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "BKK")
    '    Dim DrTotal As IDataReader = cDB.getBoxOfficeSharingByCirComp(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "Total")
    '    Dim grandTotalBox, grandTotalAdms, grandSTamt, grandSTadms, grandTdamt, grandTdadms, grand3Damt, grand3Dadms As Double
    '    If DrTotal.Read() Then
    '        grandTotalBox = DrTotal("sumAmount")
    '        grandTotalAdms = DrTotal("sumAdms")
    '        grandSTamt = DrTotal("soundtrack_amt")
    '        grandSTadms = DrTotal("soundtrack_adms")
    '        grandTdamt = DrTotal("thai_dub_amt")
    '        grandTdadms = DrTotal("thai_dub_adms")
    '        grand3Damt = DrTotal("td_amt")
    '        grand3Dadms = DrTotal("td_adms")
    '    End If
    '    DrTotal.Close()
    '    tbl.Rows(1).Cells(0).Text = "From Date : " & Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy") & " To " & Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy")
    '    tbl.Rows(2).Cells(0).Text = "" & Session("msRptMovieName")

    '    Dim sessionCount, SumAdms, SumSoundtrack_adms, SumThai_dub_adms, rowCount As Double
    '    Dim sumSoundtrack_amt, SumThai_dub_amt, SumBox, SumTd_amt, SumTd_Adms As Decimal
    '    Dim lastTheater As String
    '    Dim movieSys As String
    '    Dim movieSound As String
    '    lastTheater = ""
    '    sessionCount = 0
    '    movieSys = ""
    '    movieSound = ""
    '    SumBox = 0
    '    SumAdms = 0
    '    rowCount = 0
    '    sumSoundtrack_amt = 0
    '    SumSoundtrack_adms = 0
    '    SumThai_dub_amt = 0
    '    SumThai_dub_adms = 0
    '    SumTd_amt = 0
    '    SumTd_Adms = 0
    '    While (DrData.Read())
    '        Dim detailsRow As New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Center
    '        rowCount = rowCount + 1
    '        'Dim i As Integer
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).Text = rowCount
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
    '        detailsRow.Cells(1).Text = DrData("circuit_name")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(2).Text = Format(DrData("soundtrack_amt"), "#,##0")
    '        sumSoundtrack_amt = sumSoundtrack_amt + Convert.ToDouble(DrData("soundtrack_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(3).Text = Format(DrData("soundtrack_adms"), "#,##0")
    '        SumSoundtrack_adms = SumSoundtrack_adms + Convert.ToDouble(DrData("soundtrack_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(4).Text = Format(DrData("thai_dub_amt"), "#,##0")
    '        SumThai_dub_amt = SumThai_dub_amt + Convert.ToDouble(DrData("thai_dub_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(5).Text = Format(DrData("thai_dub_adms"), "#,##0")
    '        SumThai_dub_adms = SumThai_dub_adms + Convert.ToDouble(DrData("thai_dub_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(6).Text = Format(DrData("td_amt"), "#,##0")
    '        SumTd_amt += Convert.ToDouble(DrData("td_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(7).Text = Format(DrData("td_adms"), "#,##0")
    '        SumTd_Adms += Convert.ToDouble(DrData("td_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(8).Text = Format(DrData("sumAmount"), "#,##0")
    '        SumBox = SumBox + Convert.ToDouble(DrData("sumAmount"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(9).Text = Format(DrData("sumAdms"), "#,##0")
    '        SumAdms = SumAdms + Convert.ToDouble(DrData("sumAdms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(10).Text = Format(Convert.ToDouble(DrData("sumAmount")) / Convert.ToDouble(DrData("sumAdms")), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        'detailsRow.Cells(11).BackColor = Color.GreenYellow
    '        detailsRow.Cells(11).Text = "0"
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(12).Text = "0"
    '        detailsRow.Cells(12).Visible = False
    '        detailsRow.Cells.Add(New TableCell)
    '        'detailsRow.Cells(13).BackColor = Color.GreenYellow
    '        detailsRow.Cells(13).Text = "0"
    '        detailsRow.Cells.Add(New TableCell)

    '        detailsRow.Cells(14).Text = "0"
    '        detailsRow.Cells(14).Visible = False
    '        tbl.Rows.Add(detailsRow)
    '    End While
    '    DrData.Close()

    '    Dim i As Double
    '    Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
    '    sumPerBox = 0
    '    sumPerAdms = 0
    '    sumPerBoxAll = 0
    '    sumPerAdmsAll = 0

    '    For i = 1 To rowCount
    '        tbl.Rows(i + 5).Cells(11).Text = Format(Convert.ToDouble(tbl.Rows(i + 5).Cells(8).Text) * 100 / SumBox, "#,##0.00") & "%"
    '        tbl.Rows(i + 5).Cells(13).Text = Format(Convert.ToDouble(tbl.Rows(i + 5).Cells(9).Text) * 100 / SumAdms, "#,##0.00") & "%"
    '        tbl.Rows(i + 5).Cells(12).Text = Format(Convert.ToDouble(tbl.Rows(i + 5).Cells(8).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
    '        tbl.Rows(i + 5).Cells(12).Visible = False
    '        tbl.Rows(i + 5).Cells(14).Text = Format(Convert.ToDouble(tbl.Rows(i + 5).Cells(9).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
    '        tbl.Rows(i + 5).Cells(14).Visible = False
    '        sumPerBox = sumPerBox + Convert.ToDouble(tbl.Rows(i + 5).Cells(8).Text) * 100 / SumBox
    '        sumPerAdms = sumPerAdms + Convert.ToDouble(tbl.Rows(i + 5).Cells(9).Text) * 100 / SumAdms
    '        sumPerBoxAll = sumPerBoxAll + Convert.ToDouble(tbl.Rows(i + 5).Cells(8).Text) * 100 / grandTotalBox
    '        sumPerAdmsAll = sumPerAdmsAll + Convert.ToDouble(tbl.Rows(i + 5).Cells(9).Text) * 100 / grandTotalAdms

    '    Next
    '    Dim totalRow As New TableRow()
    '    'totalRow.BackColor = Color.FromName("#CADCEF")
    '    totalRow.HorizontalAlign = HorizontalAlign.Center
    '    totalRow.Font.Bold = True
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(0).Text = ""
    '    totalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(1).Text = "TOTAL FOR BANGKOK"
    '    totalRow.Cells(1).BackColor = Color.FromName("#CADCEF")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(2).Text = Format(sumSoundtrack_amt, "#,##0")
    '    totalRow.Cells(2).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(3).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(3).Text = Format(SumSoundtrack_adms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(4).Text = Format(SumThai_dub_amt, "#,##0")
    '    totalRow.Cells(4).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(5).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(5).Text = Format(SumThai_dub_adms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(6).Text = Format(SumTd_amt, "#,##0")
    '    totalRow.Cells(6).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(7).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(7).Text = Format(SumTd_Adms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(8).Text = Format(SumBox, "#,##0")
    '    totalRow.Cells(8).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(9).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(9).Text = Format(SumAdms, "#,##0")

    '    Dim wkATP As Decimal = 0
    '    If SumAdms <> 0 Then
    '        wkATP = SumBox / SumAdms
    '    Else
    '        wkATP = 0
    '    End If

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(10).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(10).Text = Format(wkATP, "#,##0")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(11).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(11).Text = Format(sumPerBox, "#,##0.00") & "%"
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(12).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(12).Text = Format(sumPerBoxAll, "#,##0.00") & "%"
    '    totalRow.Cells(12).Visible = False
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(13).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(13).Text = Format(sumPerAdms, "#,##0.00") & "%"
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(14).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(14).Text = Format(sumPerAdmsAll, "#,##0.00") & "%"
    '    totalRow.Cells(14).Visible = False
    '    tbl.Rows.Add(totalRow)

    '    'End Bkk--------------------




    '    Dim cmHeaderCity As New TableRow()
    '    cmHeaderCity.Cells.Add(New TableCell)
    '    cmHeaderCity.Cells(0).BackColor = Color.FromName("#C3CAD6")
    '    cmHeaderCity.Cells(0).ColumnSpan = 13
    '    cmHeaderCity.Cells(0).Font.Size = 10
    '    cmHeaderCity.Cells(0).Font.Bold = True

    '    cmHeaderCity.Cells(0).Text = "CHIENG MAI"
    '    cmHeaderCity.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '    tbl.Rows.Add(cmHeaderCity)
    '    '---------------------


    '    Dim cmHeaderRow As New TableRow()
    '    'cmHeaderRow.BackColor = Color.FromName("#CADCEF")
    '    cmHeaderRow.HorizontalAlign = HorizontalAlign.Center
    '    cmHeaderRow.Font.Bold = True
    '    cmHeaderRow.Font.Size = 8
    '    cmHeaderRow.ForeColor = Color.White

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(0).RowSpan = 2
    '    cmHeaderRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(0).Text = "RANKING"
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(1).RowSpan = 2
    '    cmHeaderRow.Cells(1).Text = "CIRCUIT"
    '    cmHeaderRow.Cells(1).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(2).ColumnSpan = 2
    '    cmHeaderRow.Cells(2).Text = "SOUNDTRACK"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(3).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(3).ColumnSpan = 2
    '    cmHeaderRow.Cells(3).Text = "THAI DUB"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(4).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(4).ColumnSpan = 2
    '    cmHeaderRow.Cells(4).Text = "3D"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(5).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(5).ColumnSpan = 2
    '    cmHeaderRow.Cells(5).Text = "TOTAL"



    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(6).RowSpan = 2
    '    cmHeaderRow.Cells(6).Text = "ATP"
    '    cmHeaderRow.Cells(6).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(7).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(7).ColumnSpan = 1
    '    cmHeaderRow.Cells(7).Text = "B.O. GROSS"
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(8).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(8).ColumnSpan = 1
    '    cmHeaderRow.Cells(8).Text = "ADMISSION"
    '    tbl.Rows.Add(cmHeaderRow)
    '    Dim cmHeaderRowPer As New TableRow()
    '    'cmHeaderRowPer.BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.HorizontalAlign = HorizontalAlign.Center
    '    cmHeaderRowPer.Font.Bold = True
    '    cmHeaderRowPer.Font.Size = 8
    '    cmHeaderRowPer.ForeColor = Color.White

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(0).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(0).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(1).Text = "ADMS"
    '    cmHeaderRowPer.Cells(1).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(2).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(2).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(3).Text = "ADMS"
    '    cmHeaderRowPer.Cells(3).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(4).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(4).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(5).Text = "ADMS"
    '    cmHeaderRowPer.Cells(5).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(6).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(6).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(7).Text = "ADMS"
    '    cmHeaderRowPer.Cells(7).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(8).Text = "BY CM"
    '    cmHeaderRowPer.Cells(8).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(9).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(9).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells(9).Visible = False
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(10).Text = "BY CM"
    '    cmHeaderRowPer.Cells(10).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(11).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(11).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells(11).Visible = False
    '    tbl.Rows.Add(cmHeaderRowPer)

    '    'Begin CM
    '    Dim cDBCM As New cDatabase
    '    Dim DrDataCM As IDataReader = cDBCM.getBoxOfficeSharingByCirComp(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "CM")
    '    Dim SumAdmsCm As Double
    '    Dim SumBoxCm As Decimal
    '    SumAdmsCm = 0
    '    SumBoxCm = 0

    '    Dim cmsessionCount, cmSumAdms, cmSumSoundtrack_adms, cmSumThai_dub_adms, cmrowCount As Double
    '    Dim cmsumSoundtrack_amt, cmSumThai_dub_amt, cmSumBox, cmSumTd_amt, cmSumTd_adms As Decimal
    '    Dim cmlastTheater As String
    '    Dim cmmovieSys As String
    '    Dim cmmovieSound As String
    '    cmlastTheater = ""
    '    cmsessionCount = 0
    '    cmmovieSys = ""
    '    cmmovieSound = ""
    '    cmSumBox = 0
    '    cmSumAdms = 0
    '    cmrowCount = 0
    '    cmsumSoundtrack_amt = 0
    '    cmSumSoundtrack_adms = 0
    '    cmSumThai_dub_amt = 0
    '    cmSumThai_dub_adms = 0
    '    While (DrDataCM.Read())
    '        Dim cmdetailsRow As New TableRow()
    '        cmdetailsRow.HorizontalAlign = HorizontalAlign.Center
    '        cmrowCount = cmrowCount + 1
    '        'Dim i As Integer
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(0).Text = cmrowCount
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
    '        cmdetailsRow.Cells(1).Text = DrDataCM("circuit_name")

    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(2).Text = Format(DrDataCM("soundtrack_amt"), "#,##0")
    '        cmsumSoundtrack_amt = cmsumSoundtrack_amt + Convert.ToDouble(DrDataCM("soundtrack_amt"))
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(3).Text = Format(DrDataCM("soundtrack_adms"), "#,##0")
    '        cmSumSoundtrack_adms = cmSumSoundtrack_adms + Convert.ToDouble(DrDataCM("soundtrack_adms"))

    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(4).Text = Format(DrDataCM("thai_dub_amt"), "#,##0")
    '        cmSumThai_dub_amt = cmSumThai_dub_amt + Convert.ToDouble(DrDataCM("thai_dub_amt"))
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(5).Text = Format(DrDataCM("thai_dub_adms"), "#,##0")
    '        cmSumThai_dub_adms = cmSumThai_dub_adms + Convert.ToDouble(DrDataCM("thai_dub_adms"))

    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(6).Text = Format(DrDataCM("td_amt"), "#,##0")
    '        cmSumTd_amt += Convert.ToDouble(DrDataCM("td_amt"))
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(7).Text = Format(DrDataCM("td_adms"), "#,##0")
    '        cmSumTd_adms += Convert.ToDouble(DrDataCM("td_adms"))

    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(8).Text = Format(DrDataCM("sumAmount"), "#,##0")
    '        cmSumBox = cmSumBox + Convert.ToDouble(DrDataCM("sumAmount"))
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        cmdetailsRow.Cells(9).Text = Format(DrDataCM("sumAdms"), "#,##0")
    '        cmSumAdms = cmSumAdms + Convert.ToDouble(DrDataCM("sumAdms"))

    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(10).Text = Format(Convert.ToDouble(DrDataCM("sumAmount")) / Convert.ToDouble(DrDataCM("sumAdms")), "#,##0")
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        'cmdetailsRow.Cells(11).BackColor = Color.GreenYellow
    '        cmdetailsRow.Cells(11).Text = "0"
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        cmdetailsRow.Cells(12).Text = "0"
    '        cmdetailsRow.Cells(12).Visible = False
    '        cmdetailsRow.Cells.Add(New TableCell)
    '        'cmdetailsRow.Cells(13).BackColor = Color.GreenYellow
    '        cmdetailsRow.Cells(13).Text = "0"
    '        cmdetailsRow.Cells.Add(New TableCell)

    '        cmdetailsRow.Cells(14).Text = "0"
    '        cmdetailsRow.Cells(14).Visible = False
    '        tbl.Rows.Add(cmdetailsRow)
    '    End While
    '    DrDataCM.Close()

    '    Dim sumPerBoxCm, sumPerAdmsCm, sumPerAdmsCmAll, sumPerBoxCmAll As Double
    '    sumPerBoxCm = 0
    '    sumPerAdmsCm = 0
    '    sumPerAdmsCmAll = 0
    '    sumPerBoxCmAll = 0
    '    Dim iCm As Double
    '    For iCm = 1 To cmrowCount
    '        tbl.Rows(iCm + rowCount + 9).Cells(11).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(8).Text) * 100 / cmSumBox, "#,##0.00") & "%"
    '        tbl.Rows(iCm + rowCount + 9).Cells(13).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(9).Text) * 100 / cmSumAdms, "#,##0.00") & "%"
    '        tbl.Rows(iCm + rowCount + 9).Cells(12).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(8).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
    '        tbl.Rows(iCm + rowCount + 9).Cells(12).Visible = False
    '        tbl.Rows(iCm + rowCount + 9).Cells(14).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(9).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
    '        tbl.Rows(iCm + rowCount + 9).Cells(14).Visible = False

    '        'tbl.Rows(iCm + rowCount + 12).Cells(8).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(6).Text) * 100 / SumBoxCm, "#,##0.00") & "%"
    '        'tbl.Rows(iCm + rowCount + 12).Cells(10).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(7).Text) * 100 / SumAdmsCm, "#,##0.00") & "%"
    '        'tbl.Rows(iCm + rowCount + 12).Cells(9).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(6).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
    '        'tbl.Rows(iCm + rowCount + 12).Cells(11).Text = Format(Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(7).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
    '        'sumPerBoxCm = sumPerBoxCm + Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(6).Text) * 100 / SumBoxCm
    '        'sumPerAdmsCm = sumPerAdmsCm + Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(7).Text) * 100 / SumAdmsCm
    '        'sumPerBoxCmAll = sumPerBoxCmAll + Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(6).Text) * 100 / grandTotalBox
    '        'sumPerAdmsCmAll = sumPerAdmsCmAll + Convert.ToDouble(tbl.Rows(iCm + rowCount + 12).Cells(7).Text) * 100 / grandTotalAdms

    '        sumPerBoxCm += Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(8).Text) * 100 / cmSumBox
    '        sumPerAdmsCm += Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(9).Text) * 100 / cmSumAdms
    '        sumPerBoxCmAll += Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(8).Text) * 100 / grandTotalBox
    '        sumPerAdmsCmAll += Convert.ToDouble(tbl.Rows(iCm + rowCount + 9).Cells(9).Text) * 100 / grandTotalAdms
    '    Next

    '    Dim cmtotalRow As New TableRow()
    '    'cmtotalRow.BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.HorizontalAlign = HorizontalAlign.Center
    '    cmtotalRow.Font.Bold = True
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(0).Text = ""
    '    cmtotalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(1).Text = "TOTAL FOR CHIENG MAI"
    '    cmtotalRow.Cells(1).BackColor = Color.FromName("#CADCEF")

    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(2).Text = Format(cmsumSoundtrack_amt, "#,##0")
    '    cmtotalRow.Cells(2).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(3).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(3).Text = Format(cmSumSoundtrack_adms, "#,##0")

    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(4).Text = Format(cmSumThai_dub_amt, "#,##0")
    '    cmtotalRow.Cells(4).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(5).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(5).Text = Format(cmSumThai_dub_adms, "#,##0")

    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(6).Text = Format(cmSumTd_amt, "#,##0")
    '    cmtotalRow.Cells(6).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(7).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(7).Text = Format(cmSumTd_adms, "#,##0")

    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(8).Text = Format(cmSumBox, "#,##0")
    '    cmtotalRow.Cells(8).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(9).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '    cmtotalRow.Cells(9).Text = Format(cmSumAdms, "#,##0")

    '    Dim wkATP1 As Decimal = 0
    '    If cmSumAdms <> 0 Then
    '        wkATP1 = cmSumBox / cmSumAdms
    '    Else
    '        wkATP1 = 0
    '    End If

    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(10).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(10).Text = Format(wkATP1, "#,##0")
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(11).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(11).Text = Format(sumPerBoxCm, "#,##0.00") & "%"
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(12).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(12).Text = Format(sumPerBoxCmAll, "#,##0.00") & "%"
    '    cmtotalRow.Cells(12).Visible = False
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(13).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(13).Text = Format(sumPerAdmsCm, "#,##0.00") & "%"
    '    cmtotalRow.Cells.Add(New TableCell)
    '    cmtotalRow.Cells(14).BackColor = Color.FromName("#CADCEF")
    '    cmtotalRow.Cells(14).Text = Format(sumPerAdmsCmAll, "#,##0.00") & "%"
    '    cmtotalRow.Cells(14).Visible = False
    '    tbl.Rows.Add(cmtotalRow)



    '    '''''' grandSTamt, grandSTadms, grandTdamt, grandTdadms
    '    'Dim GrandotalRow As New TableRow()
    '    ''GrandotalRow.BackColor = Color.DarkGray
    '    'GrandotalRow.HorizontalAlign = HorizontalAlign.Center
    '    'GrandotalRow.Font.Bold = True

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(0).Text = ""
    '    'GrandotalRow.Cells(0).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(1).Text = "TOTAL"
    '    'GrandotalRow.Cells(1).BackColor = Color.DarkGray

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(2).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(2).Text = Format(grandSTamt, "#,##0")
    '    'GrandotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(3).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(3).Text = Format(grandSTadms, "#,##0")
    '    'GrandotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(4).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(4).Text = Format(grandTdamt, "#,##0")
    '    'GrandotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(5).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(5).Text = Format(grandTdadms, "#,##0")
    '    'GrandotalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(6).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(6).Text = Format(grand3Damt, "#,##0")
    '    'GrandotalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(7).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(7).Text = Format(grand3Dadms, "#,##0")
    '    'GrandotalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(8).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(8).Text = Format(grandTotalBox, "#,##0")
    '    'GrandotalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(9).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(9).Text = Format(grandTotalAdms, "#,##0")
    '    'GrandotalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(10).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(10).Text = Format(grandTotalBox / grandTotalAdms, "#,##0")
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(11).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(11).Text = ""
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(12).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(12).Text = "100%"
    '    'GrandotalRow.Cells(12).Visible = False
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(13).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(13).Text = ""
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(14).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(14).Text = "100%"
    '    'GrandotalRow.Cells(14).Visible = False
    '    'tbl.Rows.Add(GrandotalRow)







    '    '----------------Key City -------------------------------
    '    'cmHeaderCity = New TableRow()
    '    'cmHeaderCity.Cells.Add(New TableCell)
    '    'cmHeaderCity.Cells(0).BackColor = Color.DarkGray
    '    'cmHeaderCity.Cells(0).ColumnSpan = 7
    '    'cmHeaderCity.Cells(0).Font.Size = 12
    '    'cmHeaderCity.Cells(0).Font.Bold = True
    '    'cmHeaderCity.Cells(0).Text = "KEY CITY"
    '    'cmHeaderCity.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '    'tbl.Rows.Add(cmHeaderCity)

    '    Dim getBoxOfficeData As New cDatabase
    '    DrData = cDB.getBoxOfficeSharingByCirComp(Session("msRptMovieID"), Format(Session("msRptStrDate"), "yyyyMMdd"), Format(Session("msRptEndDate"), "yyyyMMdd"), "CITY")

    '    'Dim sessionCount, SumBox, SumAdms, rowCount As Double
    '    'Dim lastTheater As String
    '    'Dim movieSys As String
    '    'Dim movieSound As String
    '    lastTheater = ""
    '    sessionCount = 0
    '    movieSys = ""
    '    movieSound = ""
    '    SumBox = 0
    '    SumAdms = 0
    '    Dim rowCountCity As Integer = 0



    '    cmHeaderCity = New TableRow()
    '    cmHeaderCity.Cells.Add(New TableCell)
    '    cmHeaderCity.Cells(0).BackColor = Color.FromName("#C3CAD6")
    '    cmHeaderCity.Cells(0).ColumnSpan = 13
    '    cmHeaderCity.Cells(0).Font.Size = 10
    '    cmHeaderCity.Cells(0).Font.Bold = True

    '    cmHeaderCity.Cells(0).Text = "KEY CITY"
    '    cmHeaderCity.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '    tbl.Rows.Add(cmHeaderCity)
    '    '---------------------
    '    cmHeaderRow = New TableRow()
    '    'cmHeaderRow.BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.HorizontalAlign = HorizontalAlign.Center
    '    cmHeaderRow.Font.Size = 8
    '    cmHeaderRow.Font.Bold = True
    '    cmHeaderRow.ForeColor = Color.White

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(0).RowSpan = 2
    '    cmHeaderRow.Cells(0).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(0).Text = "RANKING"
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(1).RowSpan = 2
    '    cmHeaderRow.Cells(1).Text = "CIRCUIT"
    '    cmHeaderRow.Cells(1).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(2).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(2).ColumnSpan = 2
    '    cmHeaderRow.Cells(2).Text = "SOUNDTRACK"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(3).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(3).ColumnSpan = 2
    '    cmHeaderRow.Cells(3).Text = "THAI DUB"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(4).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(4).ColumnSpan = 2
    '    cmHeaderRow.Cells(4).Text = "3D"

    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(5).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(5).ColumnSpan = 2
    '    cmHeaderRow.Cells(5).Text = "TOTAL"



    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(6).RowSpan = 2
    '    cmHeaderRow.Cells(6).Text = "ATP"
    '    cmHeaderRow.Cells(6).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(7).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(7).ColumnSpan = 1
    '    cmHeaderRow.Cells(7).Text = "B.O. GROSS"
    '    cmHeaderRow.Cells.Add(New TableCell)
    '    cmHeaderRow.Cells(8).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRow.Cells(8).ColumnSpan = 1
    '    cmHeaderRow.Cells(8).Text = "ADMISSION"
    '    tbl.Rows.Add(cmHeaderRow)


    '    cmHeaderRowPer = New TableRow()
    '    'cmHeaderRowPer.BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.HorizontalAlign = HorizontalAlign.Center
    '    cmHeaderRowPer.Font.Size = 8
    '    cmHeaderRowPer.Font.Bold = True
    '    cmHeaderRowPer.ForeColor = Color.White

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(0).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(0).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(1).Text = "ADMS"
    '    cmHeaderRowPer.Cells(1).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(2).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(2).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(3).Text = "ADMS"
    '    cmHeaderRowPer.Cells(3).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(4).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(4).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(5).Text = "ADMS"
    '    cmHeaderRowPer.Cells(5).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(6).Text = "BOX OFFICE"
    '    cmHeaderRowPer.Cells(6).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(7).Text = "ADMS"
    '    cmHeaderRowPer.Cells(7).BackColor = Color.FromName("#5D7B9D")

    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(8).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(8).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(9).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(9).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells(9).Visible = False
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(10).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(10).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells.Add(New TableCell)
    '    cmHeaderRowPer.Cells(11).Text = "BY KEY CITY"
    '    cmHeaderRowPer.Cells(11).BackColor = Color.FromName("#5D7B9D")
    '    cmHeaderRowPer.Cells(11).Visible = False
    '    tbl.Rows.Add(cmHeaderRowPer)



    '    While (DrData.Read())
    '        Dim detailsRow As New TableRow()
    '        detailsRow.HorizontalAlign = HorizontalAlign.Center
    '        rowCountCity = rowCountCity + 1
    '        'Dim i As Integer
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(0).Text = rowCountCity
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Left
    '        detailsRow.Cells(1).Text = DrData("circuit_name")

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(2).Text = Format(DrData("soundtrack_amt"), "#,##0")
    '        sumSoundtrack_amt = sumSoundtrack_amt + Convert.ToDouble(DrData("soundtrack_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(3).Text = Format(DrData("soundtrack_adms"), "#,##0")
    '        SumSoundtrack_adms = SumSoundtrack_adms + Convert.ToDouble(DrData("soundtrack_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(4).Text = Format(DrData("thai_dub_amt"), "#,##0")
    '        SumThai_dub_amt = SumThai_dub_amt + Convert.ToDouble(DrData("thai_dub_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(5).Text = Format(DrData("thai_dub_adms"), "#,##0")
    '        SumThai_dub_adms = SumThai_dub_adms + Convert.ToDouble(DrData("thai_dub_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(6).Text = Format(DrData("td_amt"), "#,##0")
    '        SumTd_amt += Convert.ToDouble(DrData("td_amt"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(7).Text = Format(DrData("td_adms"), "#,##0")
    '        SumTd_Adms += Convert.ToDouble(DrData("td_adms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(8).Text = Format(DrData("sumAmount"), "#,##0")
    '        SumBox = SumBox + Convert.ToDouble(DrData("sumAmount"))
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '        detailsRow.Cells(9).Text = Format(DrData("sumAdms"), "#,##0")
    '        SumAdms = SumAdms + Convert.ToDouble(DrData("sumAdms"))

    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(10).Text = Format(Convert.ToDouble(DrData("sumAmount")) / Convert.ToDouble(DrData("sumAdms")), "#,##0")
    '        detailsRow.Cells.Add(New TableCell)
    '        'detailsRow.Cells(11).BackColor = Color.GreenYellow
    '        detailsRow.Cells(11).Text = "0"
    '        detailsRow.Cells.Add(New TableCell)
    '        detailsRow.Cells(12).Text = "0"
    '        detailsRow.Cells(12).Visible = False
    '        detailsRow.Cells.Add(New TableCell)
    '        'detailsRow.Cells(13).BackColor = Color.GreenYellow
    '        detailsRow.Cells(13).Text = "0"
    '        detailsRow.Cells.Add(New TableCell)

    '        detailsRow.Cells(14).Text = "0"
    '        detailsRow.Cells(14).Visible = False
    '        tbl.Rows.Add(detailsRow)
    '    End While
    '    DrData.Close()

    '    'Dim i As Integer
    '    'Dim sumPerBox, sumPerAdms, sumPerBoxAll, sumPerAdmsAll As Double
    '    i = 0
    '    sumPerBox = 0
    '    sumPerAdms = 0
    '    sumPerBoxAll = 0
    '    sumPerAdmsAll = 0

    '    For i = 0 To rowCountCity - 1
    '        'Dim rows As Integer = iCm + rowCount + i + 13
    '        'tbl.Rows(rows).Cells(5).Text = Format(CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / SumBox, "#,##0.00") & "%"
    '        'tbl.Rows(rows).Cells(7).Text = Format(CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / SumAdms, "#,##0.00") & "%"

    '        'tbl.Rows(rows).Cells(6).Text = Format(CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
    '        'tbl.Rows(rows).Cells(6).Visible = False
    '        'tbl.Rows(rows).Cells(8).Text = Format(CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
    '        'tbl.Rows(rows).Cells(8).Visible = False
    '        'sumPerBox = sumPerBox + CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / SumBox
    '        'sumPerAdms = sumPerAdms + CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / SumAdms
    '        'sumPerBoxAll = sumPerBoxAll + CDbl(tbl.Rows(rows).Cells(2).Text) * 100 / grandTotalBox
    '        'sumPerAdmsAll = sumPerAdmsAll + CDbl(tbl.Rows(rows).Cells(3).Text) * 100 / grandTotalAdms


    '        Dim rows As Integer = cmrowCount + rowCount + i + 14
    '        tbl.Rows(rows).Cells(11).Text = Format(Convert.ToDouble(tbl.Rows(rows).Cells(8).Text) * 100 / SumBox, "#,##0.00") & "%"
    '        tbl.Rows(rows).Cells(13).Text = Format(Convert.ToDouble(tbl.Rows(rows).Cells(9).Text) * 100 / SumAdms, "#,##0.00") & "%"
    '        tbl.Rows(rows).Cells(12).Text = Format(Convert.ToDouble(tbl.Rows(rows).Cells(8).Text) * 100 / grandTotalBox, "#,##0.00") & "%"
    '        tbl.Rows(rows).Cells(12).Visible = False
    '        tbl.Rows(rows).Cells(14).Text = Format(Convert.ToDouble(tbl.Rows(rows).Cells(9).Text) * 100 / grandTotalAdms, "#,##0.00") & "%"
    '        tbl.Rows(rows).Cells(14).Visible = False
    '        sumPerBox = sumPerBox + Convert.ToDouble(tbl.Rows(rows).Cells(8).Text) * 100 / SumBox
    '        sumPerAdms = sumPerAdms + Convert.ToDouble(tbl.Rows(rows).Cells(9).Text) * 100 / SumAdms
    '        sumPerBoxAll = sumPerBoxAll + Convert.ToDouble(tbl.Rows(rows).Cells(8).Text) * 100 / grandTotalBox
    '        sumPerAdmsAll = sumPerAdmsAll + Convert.ToDouble(tbl.Rows(rows).Cells(9).Text) * 100 / grandTotalAdms

    '    Next



    '    '''''' grandSTamt, grandSTadms, grandTdamt, grandTdadms
    '    'Dim GrandotalRow As New TableRow()
    '    ''GrandotalRow.BackColor = Color.DarkGray
    '    'GrandotalRow.HorizontalAlign = HorizontalAlign.Center
    '    'GrandotalRow.Font.Bold = True

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(0).Text = ""
    '    'GrandotalRow.Cells(0).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(1).Text = "TOTAL"
    '    'GrandotalRow.Cells(1).BackColor = Color.DarkGray

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(2).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(2).Text = Format(grandSTamt, "#,##0")
    '    'GrandotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(3).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(3).Text = Format(grandSTadms, "#,##0")
    '    'GrandotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(4).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(4).Text = Format(grandTdamt, "#,##0")
    '    'GrandotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(5).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(5).Text = Format(grandTdadms, "#,##0")
    '    'GrandotalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(6).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(6).Text = Format(grand3Damt, "#,##0")
    '    'GrandotalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(7).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(7).Text = Format(grand3Dadms, "#,##0")
    '    'GrandotalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(8).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(8).Text = Format(grandTotalBox, "#,##0")
    '    'GrandotalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(9).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(9).Text = Format(grandTotalAdms, "#,##0")
    '    'GrandotalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right

    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(10).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(10).Text = Format(grandTotalBox / grandTotalAdms, "#,##0")
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(11).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(11).Text = ""
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(12).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(12).Text = "100%"
    '    'GrandotalRow.Cells(12).Visible = False
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(13).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(13).Text = ""
    '    'GrandotalRow.Cells.Add(New TableCell)
    '    'GrandotalRow.Cells(14).BackColor = Color.DarkGray
    '    'GrandotalRow.Cells(14).Text = "100%"
    '    'GrandotalRow.Cells(14).Visible = False
    '    'tbl.Rows.Add(GrandotalRow)



    '    totalRow = New TableRow()
    '    'totalRow.BackColor = Color.FromName("#CADCEF")
    '    totalRow.HorizontalAlign = HorizontalAlign.Center
    '    totalRow.Font.Bold = True
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(0).Text = ""
    '    totalRow.Cells(0).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(1).Text = "TOTAL FOR KEY CITY"
    '    totalRow.Cells(1).BackColor = Color.FromName("#CADCEF")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(2).Text = Format(grandSTamt, "#,##0")
    '    totalRow.Cells(2).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(3).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(3).Text = Format(grandSTadms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(4).Text = Format(grandTdamt, "#,##0")
    '    totalRow.Cells(4).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(5).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(5).Text = Format(grandTdadms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(6).Text = Format(grand3Damt, "#,##0")
    '    totalRow.Cells(6).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(7).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(7).Text = Format(grand3Dadms, "#,##0")

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(8).Text = Format(grandTotalBox, "#,##0")
    '    totalRow.Cells(8).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(9).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
    '    totalRow.Cells(9).Text = Format(grandTotalAdms, "#,##0")

    '    wkATP = 0
    '    If SumAdms <> 0 Then
    '        wkATP = SumBox / SumAdms
    '    Else
    '        wkATP = 0
    '    End If

    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(10).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(10).Text = Format(wkATP, "#,##0")
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(11).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(11).Text = "100.00%"
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(12).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(12).Text = "100.00%"
    '    totalRow.Cells(12).Visible = False
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(13).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(13).Text = "100.00%"
    '    totalRow.Cells.Add(New TableCell)
    '    totalRow.Cells(14).BackColor = Color.FromName("#CADCEF")
    '    totalRow.Cells(14).Text = "100.00%"
    '    totalRow.Cells(14).Visible = False
    '    tbl.Rows.Add(totalRow)

    '    'End CITY--------------------


    'End Sub

    Private Const COLUMN_START_HEADER_1 As Integer = 2
    Private Const COLUMN_START_HEADER_2 As Integer = 0
    Private Const COLUMN_START_DETAIL_0 As Integer = 2
    Private Const COLUMN_START_FOOTER_0 As Integer = 2
    Private Const PIVOT_NUM_HEADER_1 As Integer = 1
    Private Const PIVOT_NUM_HEADER_2 As Integer = 2
    Private Const PIVOT_NUM_DETAIL_0 As Integer = 2
    Private Const PIVOT_NUM_FOOTER_0 As Integer = 2
    Private Const PIVOT_WIDTH_HEADER_1 As Integer = 140

    '--- Added by Wittawat W. on 2012/12/12 : Add filmtype and sound
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim movieId As String = Session("msRptMovieId")
        Dim movieName As String = Session("msRptMovieName")
        Dim startDate As String = Format(Session("msRptStrDate"), "yyyyMMdd")
        Dim endDate As String = Format(Session("msRptEndDate"), "yyyyMMdd")

        Dim dtDetailBKK As DataTable = cDatabase.GetDataTable("exec spGetRptCompMarketShareByCir " + movieId _
                                                           + ", '" + startDate + "'" _
                                                           + ", '" + endDate + "'" _
                                                           + ", 'BKK'")
        Dim dtDetailCM As DataTable = cDatabase.GetDataTable("exec spGetRptCompMarketShareByCir " + movieId _
                                                           + ", '" + startDate + "'" _
                                                           + ", '" + endDate + "'" _
                                                           + ", 'CM'")
        Dim dtDetailCITY As DataTable = cDatabase.GetDataTable("exec spGetRptCompMarketShareByCir " + movieId _
                                                           + ", '" + startDate + "'" _
                                                           + ", '" + endDate + "'" _
                                                           + ", 'CITY'")

        Dim dtPivot As DataTable = cDatabase.GetDataTable("select film_type_sound_header_group " _
                                                          + "from tblFilmTypeSound " _
                                                          + "where film_type_sound_header_group is not null " _
                                                          + "group by film_type_sound_header_group " _
                                                          + "order by max(film_type_sound_id) ")

        Dim widthReport As Integer = 60 + 200 + PIVOT_WIDTH_HEADER_1 * dtPivot.Rows.Count + PIVOT_WIDTH_HEADER_1 + 40 + 60 + 60
        Dim colspanReport As Integer = COLUMN_START_HEADER_1 + PIVOT_NUM_HEADER_2 * dtPivot.Rows.Count + PIVOT_NUM_HEADER_2 + 1 + 1 + 1

        GenerateReportHD(widthReport, colspanReport)
        GenerateReportBKK(dtDetailBKK, dtPivot, widthReport, colspanReport)
        GenerateReportCM(dtDetailCM, dtPivot, widthReport, colspanReport)
        GenerateReportCITY(dtDetailCITY, dtPivot, widthReport, colspanReport)
    End Sub

    '--- Added by Wittawat W. on 2012/12/12 : Add filmtype and sound
    Private Sub GenerateReportHD(ByVal widthReport As Integer, ByVal colspanReport As Integer)
        Me.tbHD.Width = New Unit(widthReport)

        Me.tbHD.Rows(0).Cells(0).ColumnSpan = colspanReport

        Me.tbHD.Rows(1).Cells(0).Text = String.Format(Me.tbHD.Rows(1).Cells(0).Text, Format(Session("msRptStrDate"), "ddd dd-MMM-yyyy"), Format(Session("msRptEndDate"), "ddd dd-MMM-yyyy"))
        Me.tbHD.Rows(1).Cells(0).ColumnSpan = colspanReport

        Me.tbHD.Rows(2).Cells(0).Text = "" & Session("msRptMovieName")
        Me.tbHD.Rows(2).Cells(0).ColumnSpan = colspanReport
    End Sub

    '--- Added by Wittawat W. on 2012/12/12 : Add filmtype and sound
    Private Sub GenerateReportBKK(ByVal dtDetail As DataTable, ByVal dtPivot As DataTable, ByVal widthReport As Integer, ByVal colspanReport As Integer)
        Me.tbBKK.Width = New Unit(widthReport)
        Me.tbBKK.Rows(0).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim x As Integer = 1
                Dim y As Integer = COLUMN_START_HEADER_1
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).Width = Me.tbBKK.Rows(x).Cells(y).Width
                tdHeader1(jj).ColumnSpan = Me.tbBKK.Rows(x).Cells(y).ColumnSpan
                tdHeader1(jj).HorizontalAlign = Me.tbBKK.Rows(x).Cells(y).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tbBKK.Rows(x).Cells(y).BackColor
                tdHeader1(jj).ForeColor = Me.tbBKK.Rows(x).Cells(y).ForeColor
                tdHeader1(jj).Text = dtPivot.Rows(j)("film_type_sound_header_group")
                Me.tbBKK.Rows(x).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdHeader2(PIVOT_NUM_HEADER_2 - 1) As TableHeaderCell
            For jj As Integer = tdHeader2.Length - 1 To 0 Step -1
                Dim xx As Integer = 2
                Dim yy As Integer = COLUMN_START_HEADER_2 + (PIVOT_NUM_HEADER_2 - 1)
                tdHeader2(jj) = New TableHeaderCell
                tdHeader2(jj).ColumnSpan = Me.tbBKK.Rows(xx).Cells(yy).ColumnSpan
                tdHeader2(jj).Width = Me.tbBKK.Rows(xx).Cells(yy).Width
                tdHeader2(jj).HorizontalAlign = Me.tbBKK.Rows(xx).Cells(yy).HorizontalAlign
                tdHeader2(jj).BackColor = Me.tbBKK.Rows(xx).Cells(yy).BackColor
                tdHeader2(jj).ForeColor = Me.tbBKK.Rows(xx).Cells(yy).ForeColor
                tdHeader2(jj).Text = Me.tbBKK.Rows(xx).Cells(yy).Text
                Me.tbBKK.Rows(xx).Cells.AddAt(COLUMN_START_HEADER_2, tdHeader2(jj))
            Next

            Dim tdFooter1(PIVOT_NUM_HEADER_2 - 1) As TableCell
            For jj As Integer = tdFooter1.Length - 1 To 0 Step -1
                Dim xxx As Integer = Me.tbBKK.Rows.Count - 1
                Dim yyy As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter1(jj) = New TableCell
                tdFooter1(jj).ColumnSpan = Me.tbBKK.Rows(xxx).Cells(yyy).ColumnSpan
                tdFooter1(jj).HorizontalAlign = Me.tbBKK.Rows(xxx).Cells(yyy).HorizontalAlign
                tdFooter1(jj).BackColor = Me.tbBKK.Rows(xxx).Cells(yyy).BackColor
                tdFooter1(jj).ForeColor = Me.tbBKK.Rows(xxx).Cells(yyy).ForeColor
                tdFooter1(jj).Text = Me.tbBKK.Rows(xxx).Cells(yyy).Text
                Me.tbBKK.Rows(xxx).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter1(jj))
            Next
        Next

        ''--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail As New TableRow()

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(0).HorizontalAlign = HorizontalAlign.Center
            trDetail.Cells(0).Text = String.Format("{0:#,##0}", i + 1)

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(1).HorizontalAlign = HorizontalAlign.Left
            trDetail.Cells(1).Text = String.Format("{0}", dtDetail.Rows(i)("circuit_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))
                Else
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))
                End If
            Next

            Dim z As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 0).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("atp"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 1).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("amount_gross_total"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 2).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("adms_gross_total"))

            Me.tbBKK.Rows.AddAt(Me.tbBKK.Rows.Count - 1, trDetail)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tbBKK.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tbBKK.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                Me.tbBKK.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
            Else
                Me.tbBKK.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tbBKK.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
            End If
        Next

        Dim xxxxxxxx As Integer = Me.tbBKK.Rows.Count - 1
        Dim zzzzzzzz As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

        Me.tbBKK.Rows(xxxxxxxx).Cells(zzzzzzzz + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])/sum([Total Adms])", ""))
        Me.tbBKK.Rows(xxxxxxxx).Cells(zzzzzzzz + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Amount])/max(amount_total)", ""))
        Me.tbBKK.Rows(xxxxxxxx).Cells(zzzzzzzz + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Adms])/max(adms_total)", ""))
    End Sub

    '--- Added by Wittawat W. on 2012/12/12 : Add filmtype and sound
    Private Sub GenerateReportCM(ByVal dtDetail As DataTable, ByVal dtPivot As DataTable, ByVal widthReport As Integer, ByVal colspanReport As Integer)
        Me.tbCM.Width = New Unit(widthReport)
        Me.tbCM.Rows(0).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim x As Integer = 1
                Dim y As Integer = COLUMN_START_HEADER_1
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).Width = Me.tbCM.Rows(x).Cells(y).Width
                tdHeader1(jj).ColumnSpan = Me.tbCM.Rows(x).Cells(y).ColumnSpan
                tdHeader1(jj).HorizontalAlign = Me.tbCM.Rows(x).Cells(y).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tbCM.Rows(x).Cells(y).BackColor
                tdHeader1(jj).ForeColor = Me.tbCM.Rows(x).Cells(y).ForeColor
                tdHeader1(jj).Text = dtPivot.Rows(j)("film_type_sound_header_group")
                Me.tbCM.Rows(x).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdHeader2(PIVOT_NUM_HEADER_2 - 1) As TableHeaderCell
            For jj As Integer = tdHeader2.Length - 1 To 0 Step -1
                Dim xx As Integer = 2
                Dim yy As Integer = COLUMN_START_HEADER_2 + (PIVOT_NUM_HEADER_2 - 1)
                tdHeader2(jj) = New TableHeaderCell
                tdHeader2(jj).ColumnSpan = Me.tbCM.Rows(xx).Cells(yy).ColumnSpan
                tdHeader2(jj).Width = Me.tbCM.Rows(xx).Cells(yy).Width
                tdHeader2(jj).HorizontalAlign = Me.tbCM.Rows(xx).Cells(yy).HorizontalAlign
                tdHeader2(jj).BackColor = Me.tbCM.Rows(xx).Cells(yy).BackColor
                tdHeader2(jj).ForeColor = Me.tbCM.Rows(xx).Cells(yy).ForeColor
                tdHeader2(jj).Text = Me.tbCM.Rows(xx).Cells(yy).Text
                Me.tbCM.Rows(xx).Cells.AddAt(COLUMN_START_HEADER_2, tdHeader2(jj))
            Next

            Dim tdFooter1(PIVOT_NUM_HEADER_2 - 1) As TableCell
            For jj As Integer = tdFooter1.Length - 1 To 0 Step -1
                Dim xxx As Integer = Me.tbCM.Rows.Count - 1
                Dim yyy As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter1(jj) = New TableCell
                tdFooter1(jj).ColumnSpan = Me.tbCM.Rows(xxx).Cells(yyy).ColumnSpan
                tdFooter1(jj).HorizontalAlign = Me.tbCM.Rows(xxx).Cells(yyy).HorizontalAlign
                tdFooter1(jj).BackColor = Me.tbCM.Rows(xxx).Cells(yyy).BackColor
                tdFooter1(jj).ForeColor = Me.tbCM.Rows(xxx).Cells(yyy).ForeColor
                tdFooter1(jj).Text = Me.tbCM.Rows(xxx).Cells(yyy).Text
                Me.tbCM.Rows(xxx).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter1(jj))
            Next
        Next

        ''--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail As New TableRow()

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(0).HorizontalAlign = HorizontalAlign.Center
            trDetail.Cells(0).Text = String.Format("{0:#,##0}", i + 1)

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(1).HorizontalAlign = HorizontalAlign.Left
            trDetail.Cells(1).Text = String.Format("{0}", dtDetail.Rows(i)("circuit_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))
                Else
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))
                End If
            Next

            Dim z As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 0).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("atp"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 1).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("amount_gross_total"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 2).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("adms_gross_total"))

            Me.tbCM.Rows.AddAt(Me.tbCM.Rows.Count - 1, trDetail)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tbCM.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tbCM.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                Me.tbCM.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
            Else
                Me.tbCM.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tbCM.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
            End If
        Next

        Dim xxxxxxxx As Integer = Me.tbCM.Rows.Count - 1
        Dim zzzzzzzz As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

        Me.tbCM.Rows(xxxxxxxx).Cells(zzzzzzzz + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])/sum([Total Adms])", ""))
        Me.tbCM.Rows(xxxxxxxx).Cells(zzzzzzzz + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Amount])/max(amount_total)", ""))
        Me.tbCM.Rows(xxxxxxxx).Cells(zzzzzzzz + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Adms])/max(adms_total)", ""))
    End Sub

    '--- Added by Wittawat W. on 2012/12/12 : Add filmtype and sound
    Private Sub GenerateReportCITY(ByVal dtDetail As DataTable, ByVal dtPivot As DataTable, ByVal widthReport As Integer, ByVal colspanReport As Integer)
        Me.tbCITY.Width = New Unit(widthReport)
        Me.tbCITY.Rows(0).Cells(0).ColumnSpan = colspanReport

        '--- print header
        For j As Integer = dtPivot.Rows.Count - 1 To 0 Step -1
            Dim tdHeader1(PIVOT_NUM_HEADER_1 - 1) As TableHeaderCell
            For jj As Integer = tdHeader1.Length - 1 To 0 Step -1
                Dim x As Integer = 1
                Dim y As Integer = COLUMN_START_HEADER_1
                tdHeader1(jj) = New TableHeaderCell
                tdHeader1(jj).Width = Me.tbCITY.Rows(x).Cells(y).Width
                tdHeader1(jj).ColumnSpan = Me.tbCITY.Rows(x).Cells(y).ColumnSpan
                tdHeader1(jj).HorizontalAlign = Me.tbCITY.Rows(x).Cells(y).HorizontalAlign
                tdHeader1(jj).BackColor = Me.tbCITY.Rows(x).Cells(y).BackColor
                tdHeader1(jj).ForeColor = Me.tbCITY.Rows(x).Cells(y).ForeColor
                tdHeader1(jj).Text = dtPivot.Rows(j)("film_type_sound_header_group")
                Me.tbCITY.Rows(x).Cells.AddAt(COLUMN_START_HEADER_1, tdHeader1(jj))
            Next

            Dim tdHeader2(PIVOT_NUM_HEADER_2 - 1) As TableHeaderCell
            For jj As Integer = tdHeader2.Length - 1 To 0 Step -1
                Dim xx As Integer = 2
                Dim yy As Integer = COLUMN_START_HEADER_2 + (PIVOT_NUM_HEADER_2 - 1)
                tdHeader2(jj) = New TableHeaderCell
                tdHeader2(jj).ColumnSpan = Me.tbCITY.Rows(xx).Cells(yy).ColumnSpan
                tdHeader2(jj).Width = Me.tbCITY.Rows(xx).Cells(yy).Width
                tdHeader2(jj).HorizontalAlign = Me.tbCITY.Rows(xx).Cells(yy).HorizontalAlign
                tdHeader2(jj).BackColor = Me.tbCITY.Rows(xx).Cells(yy).BackColor
                tdHeader2(jj).ForeColor = Me.tbCITY.Rows(xx).Cells(yy).ForeColor
                tdHeader2(jj).Text = Me.tbCITY.Rows(xx).Cells(yy).Text
                Me.tbCITY.Rows(xx).Cells.AddAt(COLUMN_START_HEADER_2, tdHeader2(jj))
            Next

            Dim tdFooter1(PIVOT_NUM_HEADER_2 - 1) As TableCell
            For jj As Integer = tdFooter1.Length - 1 To 0 Step -1
                Dim xxx As Integer = Me.tbCITY.Rows.Count - 1
                Dim yyy As Integer = COLUMN_START_FOOTER_0 + (PIVOT_NUM_FOOTER_0 - 1)
                tdFooter1(jj) = New TableCell
                tdFooter1(jj).ColumnSpan = Me.tbCITY.Rows(xxx).Cells(yyy).ColumnSpan
                tdFooter1(jj).HorizontalAlign = Me.tbCITY.Rows(xxx).Cells(yyy).HorizontalAlign
                tdFooter1(jj).BackColor = Me.tbCITY.Rows(xxx).Cells(yyy).BackColor
                tdFooter1(jj).ForeColor = Me.tbCITY.Rows(xxx).Cells(yyy).ForeColor
                tdFooter1(jj).Text = Me.tbCITY.Rows(xxx).Cells(yyy).Text
                Me.tbCITY.Rows(xxx).Cells.AddAt(COLUMN_START_FOOTER_0, tdFooter1(jj))
            Next
        Next

        ''--- print detail
        For i As Integer = 0 To dtDetail.Rows.Count - 1
            Dim trDetail As New TableRow()

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(0).HorizontalAlign = HorizontalAlign.Center
            trDetail.Cells(0).Text = String.Format("{0:#,##0}", i + 1)

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(1).HorizontalAlign = HorizontalAlign.Left
            trDetail.Cells(1).Text = String.Format("{0}", dtDetail.Rows(i)("circuit_name"))

            For j As Integer = 0 To dtPivot.Rows.Count
                Dim y As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * j

                If j <> dtPivot.Rows.Count Then
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)(dtPivot.Rows(j)("film_type_sound_header_group") + " Adms"))
                Else
                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 0).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Amount"))

                    trDetail.Cells.Add(New TableCell)
                    trDetail.Cells(y + 1).HorizontalAlign = HorizontalAlign.Right
                    trDetail.Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("Total Adms"))
                End If
            Next

            Dim z As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 0).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 0).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("atp"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 1).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("amount_gross_total"))

            trDetail.Cells.Add(New TableCell)
            trDetail.Cells(z + 2).HorizontalAlign = HorizontalAlign.Right
            trDetail.Cells(z + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Rows(i)("adms_gross_total"))

            Me.tbCITY.Rows.AddAt(Me.tbCITY.Rows.Count - 1, trDetail)
        Next

        '--- print footer
        For j As Integer = 0 To dtPivot.Rows.Count
            Dim x As Integer = Me.tbCITY.Rows.Count - 1
            Dim y As Integer = COLUMN_START_FOOTER_0 + PIVOT_NUM_FOOTER_0 * j

            If j <> dtPivot.Rows.Count Then
                Me.tbCITY.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Amount])", ""))
                Me.tbCITY.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([" & dtPivot.Rows(j)("film_type_sound_header_group") & " Adms])", ""))
            Else
                Me.tbCITY.Rows(x).Cells(y + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])", ""))
                Me.tbCITY.Rows(x).Cells(y + 1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Adms])", ""))
            End If
        Next

        Dim xxxxxxxx As Integer = Me.tbCITY.Rows.Count - 1
        Dim zzzzzzzz As Integer = COLUMN_START_DETAIL_0 + PIVOT_NUM_DETAIL_0 * dtPivot.Rows.Count + PIVOT_NUM_DETAIL_0

        Me.tbCITY.Rows(xxxxxxxx).Cells(zzzzzzzz + 0).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum([Total Amount])/sum([Total Adms])", ""))
        Me.tbCITY.Rows(xxxxxxxx).Cells(zzzzzzzz + 1).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Amount])/max(amount_total)", ""))
        Me.tbCITY.Rows(xxxxxxxx).Cells(zzzzzzzz + 2).Text = String.Format("{0:#,##0.00%}", dtDetail.Compute("sum([Total Adms])/max(adms_total)", ""))
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptCompMarketShareParam.aspx")
    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()

        Response.AddHeader("content-disposition", "attachment;filename=Comp_MarketShare_ByCircuit.xls")
        Response.Charset = "utf-8"
        Response.ContentType = "application/vnd.xls"
        Response.ContentEncoding = System.Text.Encoding.UTF8
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        '--- Modified by Wittawat W. on 2012/12/12 : Add filmtype and sound
        'tbl.RenderControl(htmlWrite)
        Dim frm As HtmlForm = New HtmlForm()
        Me.Controls.Add(frm)
        frm.Controls.Add(tbHD)
        frm.Controls.Add(tbBKK)
        frm.Controls.Add(tbCM)
        frm.Controls.Add(tbCITY)
        frm.Attributes("runat") = "server"
        frm.RenderControl(htmlWrite)
        '--- End modified by Wittawat W. on 2012/12/12 : Add filmtype and sound

        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

End Class