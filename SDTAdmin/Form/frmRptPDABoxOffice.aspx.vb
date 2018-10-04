Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports Web.Data

Partial Public Class frmRptPDABoxOffice
    Inherits System.Web.UI.Page

    '--- Commented by Wittawat W. (CSI) on 2012/12/12 : Fix bug 
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 7, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If
    '    Try
    '        Dim intMoive_Id As Integer = Convert.ToInt32(Session("PDABoxOffice_Movie"))

    '        Dim pManage As New cDatabase

    '        'remove ข้อมูลใน Table
    '        For i As Integer = 5 To tblRpt.Rows.Count - 1
    '            tblRpt.Rows.RemoveAt(i)
    '        Next



    '        Dim strCommand As String = ""
    '        strCommand = " SELECT  Top 1   dbo.tblMovie.movie_id, dbo.tblMovie.movie_nameen + '/' + dbo.tblMovie.movie_nameth AS MoviesName, dbo.tblMovie.movie_strdate, "
    '        strCommand += " dbo.tblDistributor.distributor_name , dbo.tblDistributor.distributor_id, dbo.tblMovie.movietype_id"
    '        strCommand += " FROM         dbo.tblMovie INNER JOIN"
    '        strCommand += " dbo.tblDistributor ON dbo.tblMovie.distributor_id = dbo.tblDistributor.distributor_id"
    '        strCommand += " WHERE         dbo.tblMovie.movie_id=" + Convert.ToString(intMoive_Id)

    '        Dim dtbMovie As DataTable = cDatabase.GetDataTable(strCommand)
    '        If (dtbMovie.Rows.Count > 0) Then
    '            tblRpt.Rows(1).Cells(0).Text = "TITLE : " + Convert.ToString(dtbMovie.Rows(0)("MoviesName"))
    '            tblRpt.Rows(2).Cells(0).Text = "DISTRIBUTOR : " + Convert.ToString(dtbMovie.Rows(0)("distributor_name"))
    '            tblRpt.Rows(3).Cells(0).Text = "RELEASE DATE : " + Convert.ToDateTime(dtbMovie.Rows(0)("movie_strdate")).ToString("dd-MMM-yyyy")
    '        End If

    '        If Convert.ToString(dtbMovie.Rows(0)("movietype_id")).Trim() = "1" Then
    '            'CTBV
    '            strCommand = "  SELECT M.MOVIE_ID, MIN(M.MOVIE_NAMEEN + '/' + M.MOVIE_NAMETH) AS MOVIE_TITLE, "
    '            strCommand += vbNewLine + "  MIN(M.DISTRIBUTOR_ID) AS DISTRIBUTOR_ID, MIN(D.DISTRIBUTOR_NAME) AS DISTRIBUTOR_NAME, "
    '            strCommand += vbNewLine + "  MIN(CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) AS MOVIE_START_DATE,"
    '            strCommand += vbNewLine + "  CONVERT(VARCHAR(19), R.REVENUE_DATE, 111) AS REVENUE_DATE, "
    '            strCommand += vbNewLine + "  Convert(VARCHAR(19), R.REVENUE_DATE, 111) AS MOVIE_REVENUE_DATE,"
    '            strCommand += vbNewLine + "  CASE WHEN (ISNULL(CONVERT(VARCHAR(19), R.REVENUE_DATE, 111), '2199/12/31') < CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            strCommand += vbNewLine + "  'P'"
    '            strCommand += vbNewLine + "  WHEN (ISNULL(CONVERT(VARCHAR(19), R.REVENUE_DATE, 111), '2199/12/31') = CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            strCommand += vbNewLine + "  'O'"
    '            strCommand += vbNewLine + "  ELSE"
    '            strCommand += vbNewLine + "  'C'"
    '            strCommand += vbNewLine + "  END RELEASE_TYPE,"
    '            strCommand += vbNewLine + "  SUM(ISNULL(R.REVENUE_AMOUNT, 0)) AS TOTAL_GROSS_AMT,"
    '            strCommand += vbNewLine + "  SUM(ISNULL(R.REVENUE_ADMS, 0)) AS TOTAL_ADMS_QTY,"
    '            strCommand += vbNewLine + "  COUNT(DISTINCT CONVERT(VARCHAR(19), R.THEATERSUB_ID) + 'A' + CONVERT(VARCHAR(19), R.THEATER_ID)) AS TOTAL_SCREEN_QTY,"
    '            strCommand += vbNewLine + "  COUNT(DISTINCT R.THEATER_ID) AS TOTAL_LOCATION_QTY,"
    '            strCommand += vbNewLine + "  (	SELECT 	ISNULL(SUM(ISNULL(TR.REVENUE_AMOUNT, 0)), 0) AS TOTAL_CUMMU_AMT"
    '            strCommand += vbNewLine + "  FROM TBLMOVIE TM"
    '            'strCommand += vbNewLine + "  LEFT JOIN TBLCOMPREVENUE CRN ON TM.MOVIE_ID = CRN.MOVIES_ID"
    '            strCommand += vbNewLine + "  LEFT JOIN TBLREVENUE TR ON TM.MOVIE_ID = TR.MOVIES_ID"
    '            strCommand += vbNewLine + " WHERE TM.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            strCommand += vbNewLine + "  AND (CONVERT(VARCHAR(19), TR.REVENUE_DATE, 111) <= CONVERT(VARCHAR(19), R.REVENUE_DATE, 111))"
    '            strCommand += vbNewLine + " ) AS TOTAL_CUMMU_AMT, "
    '            strCommand += vbNewLine + "  MIN(ISNULL(M.AD_PUB_AMT, 0)) AS AD_PUB_AMT, MIN(ISNULL(M.FLAT_SALE_RENTAL, 0)) AS FLAT_SALE_RENTAL_AMT,"
    '            strCommand += vbNewLine + "  MIN(ISNULL(M.PRINT_COST_AMT, 0)) AS PRINT_COST_AMT, MIN(M.PRINT_QTY) AS PRINT_QTY, "
    '            strCommand += vbNewLine + "  MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) AS REVENUE_ESTIMETE_RENTAL, "
    '            strCommand += vbNewLine + "  (MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) - (MIN(ISNULL(M.AD_PUB_AMT, 0))) - MIN(ISNULL(M.PRINT_COST_AMT, 0))) AS NET_CONTRIBUTION_AMT"
    '            strCommand += vbNewLine + "  FROM TBLMOVIE M"
    '            strCommand += vbNewLine + "  LEFT JOIN TBLDISTRIBUTOR D ON M.DISTRIBUTOR_ID = D.DISTRIBUTOR_ID"
    '            strCommand += vbNewLine + "  LEFT JOIN TBLREVENUE R ON M.MOVIE_ID = R.MOVIES_ID"
    '            strCommand += vbNewLine + " WHERE M.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            strCommand += vbNewLine + "  GROUP BY M.MOVIE_ID, M.MOVIE_STRDATE, R.REVENUE_DATE"
    '            strCommand += vbNewLine + "  ORDER BY R.REVENUE_DATE"

    '            ''strCommand = " SELECT M.MOVIE_ID, MIN(M.MOVIE_NAMEEN + '/' + M.MOVIE_NAMETH) AS MOVIE_TITLE, "
    '            ''strCommand += vbNewLine + " MIN(M.DISTRIBUTOR_ID) AS DISTRIBUTOR_ID, MIN(D.DISTRIBUTOR_NAME) AS DISTRIBUTOR_NAME, "
    '            ''strCommand += vbNewLine + " MIN(CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) AS MOVIE_START_DATE,"
    '            ''strCommand += vbNewLine + " CONVERT(VARCHAR(19), R.REVENUE_DATE, 111) AS REVENUE_DATE, "
    '            ''strCommand += vbNewLine + " CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111) AS COMPREVENUE_DATE,"
    '            ''strCommand += vbNewLine + " CASE WHEN CONVERT(VARCHAR(19), R.REVENUE_DATE, 111) IS NULL THEN"
    '            ''strCommand += vbNewLine + " Convert(VARCHAR(19), CR.COMPREVENUE_DATE, 111)"
    '            ''strCommand += vbNewLine + " ELSE"
    '            ''strCommand += vbNewLine + " Convert(VARCHAR(19), R.REVENUE_DATE, 111)"
    '            ''strCommand += vbNewLine + " END MOVIE_REVENUE_DATE,"
    '            ''strCommand += vbNewLine + " CASE WHEN (ISNULL(CONVERT(VARCHAR(19), R.REVENUE_DATE, 111), '2199/12/31') < CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) OR (ISNULL(CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111), '2199/12/31') < CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            ''strCommand += vbNewLine + " 'P'"
    '            ''strCommand += vbNewLine + " WHEN (ISNULL(CONVERT(VARCHAR(19), R.REVENUE_DATE, 111), '2199/12/31') = CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) OR (ISNULL(CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111), '2199/12/31') = CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            ''strCommand += vbNewLine + " 'O'"
    '            ''strCommand += vbNewLine + " ELSE"
    '            ''strCommand += vbNewLine + " 'C'"
    '            ''strCommand += vbNewLine + " END RELEASE_TYPE,"
    '            ''strCommand += vbNewLine + " SUM(ISNULL(R.REVENUE_AMOUNT, 0)) + SUM(ISNULL(CR.COMPREVENUE_AMOUNTSUM, 0)) AS TOTAL_GROSS_AMT,"
    '            ''strCommand += vbNewLine + " SUM(ISNULL(R.REVENUE_ADMS, 0)) + SUM(ISNULL(CR.COMPREVENUE_ADMSSUM, 0)) AS TOTAL_ADMS_QTY,"
    '            ''strCommand += vbNewLine + " SUM(ISNULL(CR.COMPREVENUE_SCREENSUM, 0)) + COUNT(DISTINCT CONVERT(VARCHAR(19), R.THEATERSUB_ID) + 'A' + CONVERT(VARCHAR(19), R.THEATER_ID)) AS TOTAL_SCREEN_QTY,"
    '            ''strCommand += vbNewLine + " (COUNT(DISTINCT R.THEATER_ID) + COUNT(DISTINCT CR.THEATER_ID)) AS TOTAL_LOCATION_QTY,"
    '            ''strCommand += vbNewLine + " (	SELECT 	ISNULL(SUM(ISNULL(TR.REVENUE_AMOUNT, 0)) + SUM(ISNULL(CRN.COMPREVENUE_AMOUNTSUM, 0)), 0) AS TOTAL_CUMMU_AMT"
    '            ''strCommand += vbNewLine + " FROM TBLMOVIE TM"
    '            ''strCommand += vbNewLine + " LEFT JOIN TBLCOMPREVENUE CRN ON TM.MOVIE_ID = CRN.MOVIES_ID"
    '            ''strCommand += vbNewLine + " LEFT JOIN TBLREVENUE TR ON TM.MOVIE_ID = TR.MOVIES_ID"
    '            ''strCommand += vbNewLine + " WHERE TM.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            ''strCommand += vbNewLine + " AND (CONVERT(VARCHAR(19), TR.REVENUE_DATE, 111) <= CONVERT(VARCHAR(19), R.REVENUE_DATE, 111)"
    '            ''strCommand += vbNewLine + " OR CONVERT(VARCHAR(19), CRN.COMPREVENUE_DATE, 111) <= CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111))"
    '            ''strCommand += vbNewLine + " ) AS TOTAL_CUMMU_AMT, "
    '            ''strCommand += vbNewLine + " MIN(ISNULL(M.AD_PUB_AMT, 0)) AS AD_PUB_AMT, MIN(ISNULL(M.FLAT_SALE_RENTAL, 0)) AS FLAT_SALE_RENTAL_AMT,"
    '            ''strCommand += vbNewLine + " MIN(ISNULL(M.PRINT_COST_AMT, 0)) AS PRINT_COST_AMT, MIN(M.PRINT_QTY) AS PRINT_QTY, "
    '            ''strCommand += vbNewLine + " MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) AS REVENUE_ESTIMETE_RENTAL, "
    '            ''strCommand += vbNewLine + " (MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) - (MIN(ISNULL(M.AD_PUB_AMT, 0))) - MIN(ISNULL(M.PRINT_COST_AMT, 0))) AS NET_CONTRIBUTION_AMT"
    '            ''strCommand += vbNewLine + " FROM TBLMOVIE M"
    '            ''strCommand += vbNewLine + " LEFT JOIN TBLDISTRIBUTOR D ON M.DISTRIBUTOR_ID = D.DISTRIBUTOR_ID"
    '            ''strCommand += vbNewLine + " LEFT JOIN TBLCOMPREVENUE CR ON M.MOVIE_ID = CR.MOVIES_ID"
    '            ''strCommand += vbNewLine + " LEFT JOIN TBLREVENUE R ON M.MOVIE_ID = R.MOVIES_ID"
    '            ''strCommand += vbNewLine + " WHERE M.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            ''strCommand += vbNewLine + " GROUP BY M.MOVIE_ID, M.MOVIE_STRDATE, R.REVENUE_DATE, CR.COMPREVENUE_DATE"
    '            ''strCommand += vbNewLine + " ORDER BY R.REVENUE_DATE, CR.COMPREVENUE_DATE"

    '        Else
    '            strCommand = " SELECT M.MOVIE_ID , MIN(M.MOVIE_NAMEEN + '/' + M.MOVIE_NAMETH) AS MOVIE_TITLE, "
    '            strCommand += vbNewLine + " MIN(M.DISTRIBUTOR_ID) AS DISTRIBUTOR_ID, MIN(D.DISTRIBUTOR_NAME) AS DISTRIBUTOR_NAME, "
    '            strCommand += vbNewLine + " MIN(CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) AS MOVIE_START_DATE,"
    '            strCommand += vbNewLine + " CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111) AS COMPREVENUE_DATE,"
    '            strCommand += vbNewLine + " Convert(VARCHAR(19), CR.COMPREVENUE_DATE, 111) AS MOVIE_REVENUE_DATE,"
    '            strCommand += vbNewLine + " CASE WHEN (ISNULL(CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111), '2199/12/31') < CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            strCommand += vbNewLine + " 'P'"
    '            strCommand += vbNewLine + " WHEN (ISNULL(CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111), '2199/12/31') = CONVERT(VARCHAR(19), M.MOVIE_STRDATE, 111)) THEN"
    '            strCommand += vbNewLine + " 'O'"
    '            strCommand += vbNewLine + " ELSE"
    '            strCommand += vbNewLine + " 'C'"
    '            strCommand += vbNewLine + " END RELEASE_TYPE,"
    '            strCommand += vbNewLine + " SUM(ISNULL(CR.COMPREVENUE_AMOUNTSUM, 0)) AS TOTAL_GROSS_AMT,"
    '            strCommand += vbNewLine + " SUM(ISNULL(CR.COMPREVENUE_ADMSSUM, 0)) AS TOTAL_ADMS_QTY,"
    '            strCommand += vbNewLine + " SUM(ISNULL(CR.COMPREVENUE_SCREENSUM, 0)) AS TOTAL_SCREEN_QTY,"
    '            strCommand += vbNewLine + " COUNT(DISTINCT CR.THEATER_ID) AS TOTAL_LOCATION_QTY"
    '            strCommand += vbNewLine + " ,(	SELECT 	ISNULL(SUM(ISNULL(CRN.COMPREVENUE_AMOUNTSUM, 0)), 0) AS TOTAL_CUMMU_AMT"
    '            strCommand += vbNewLine + " FROM TBLMOVIE TM"
    '            strCommand += vbNewLine + " LEFT JOIN TBLCOMPREVENUE CRN ON TM.MOVIE_ID = CRN.MOVIES_ID"
    '            strCommand += vbNewLine + " WHERE TM.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            strCommand += vbNewLine + " AND CONVERT(VARCHAR(19), CRN.COMPREVENUE_DATE, 111) <= CONVERT(VARCHAR(19), CR.COMPREVENUE_DATE, 111)"
    '            strCommand += vbNewLine + " ) AS TOTAL_CUMMU_AMT, "
    '            strCommand += vbNewLine + " MIN(ISNULL(M.AD_PUB_AMT, 0)) AS AD_PUB_AMT, MIN(ISNULL(M.FLAT_SALE_RENTAL, 0)) AS FLAT_SALE_RENTAL_AMT,"
    '            strCommand += vbNewLine + " MIN(ISNULL(M.PRINT_COST_AMT, 0)) AS PRINT_COST_AMT, MIN(M.PRINT_QTY) AS PRINT_QTY, "
    '            strCommand += vbNewLine + " MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) AS REVENUE_ESTIMETE_RENTAL, "
    '            strCommand += vbNewLine + " (MIN(ISNULL(M.REVENUE_ESTIMETE, 0)) - (MIN(ISNULL(M.AD_PUB_AMT, 0))) - MIN(ISNULL(M.PRINT_COST_AMT, 0))) AS NET_CONTRIBUTION_AMT"
    '            strCommand += vbNewLine + " FROM TBLMOVIE M"
    '            strCommand += vbNewLine + " LEFT JOIN TBLDISTRIBUTOR D ON M.DISTRIBUTOR_ID = D.DISTRIBUTOR_ID"
    '            strCommand += vbNewLine + " LEFT JOIN TBLCOMPREVENUE CR ON M.MOVIE_ID = CR.MOVIES_ID "
    '            strCommand += vbNewLine + " WHERE M.MOVIE_ID = " + Convert.ToString(intMoive_Id)
    '            strCommand += vbNewLine + " GROUP BY M.MOVIE_ID, M.MOVIE_STRDATE, CR.COMPREVENUE_DATE "
    '            strCommand += vbNewLine + " ORDER BY CR.COMPREVENUE_DATE"
    '        End If




    '        Dim dtbDetail1 As DataTable = cDatabase.GetDataTable(strCommand) '("exec spPda_Box_Office " + Convert.ToString(intMoive_Id))

    '        If dtbDetail1.Rows(0)("movie_revenue_date") <> Nothing Then

    '            Dim strRELEASE_TYPE As String = ""
    '            Dim decSum1 As Decimal
    '            Dim decSum2 As Decimal
    '            Dim decSum3 As Decimal

    '            Dim decSunSum1 As Decimal
    '            Dim decSunSum2 As Decimal
    '            Dim decSunSum3 As Decimal

    '            Dim decTOTAL_ADMS_QTY As Decimal
    '            Dim intWeekNo As Integer = 1
    '            Dim dtRunningDateStart As DateTime
    '            Dim intIncreaseToWeek As Integer = 1

    '            Dim dayStart As String = Convert.ToDateTime(dtbDetail1.Rows(0)("movie_revenue_date")).ToString("ddd")
    '            Dim ddmmyyyyStart As DateTime = Convert.ToDateTime(dtbDetail1.Rows(0)("movie_revenue_date"))
    '            Dim ddmmyyyyNextWeekend As DateTime
    '            Dim ddmmyyyyNextWeek As DateTime

    '            'Select Case dayStart.ToLower()
    '            '    Case "mon"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(6)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(2)
    '            '    Case "tue"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(5)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(1)
    '            '    Case "wed"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(4)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(0)
    '            '    Case "thu"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(3)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '            '    Case "fri"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(2)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(5)
    '            '    Case "sat"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(1)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(4)
    '            '    Case "sun"
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(0)
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(3)
    '            '    Case Else
    '            '        ddmmyyyyNextWeekend = ddmmyyyyStart
    '            '        ddmmyyyyNextWeek = ddmmyyyyStart
    '            'End Select


    '            Dim countWeekShow As Integer = 1
    '            Dim countWeekNow As Integer = 0
    '            Dim iCurrentO_C As Integer = 0
    '            For i As Integer = 0 To dtbDetail1.Rows.Count - 1

    '                If Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("yyyyMMdd") = "20110203" Then
    '                    Dim a As String = "a"
    '                End If


    '                Dim TotalRow As New TableRow()
    '                Dim strRELEASE_TYPE_Curent As String = Convert.ToString(dtbDetail1.Rows(i)("RELEASE_TYPE")).ToUpper().Trim()

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(0).Font.Bold = False
    '                TotalRow.Cells(0).ForeColor = Color.Black
    '                TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                TotalRow.Cells(0).Text = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("dd-MMM-yyyy (ddd)")

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(1).Font.Bold = False
    '                TotalRow.Cells(1).ForeColor = Color.Black
    '                TotalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '                TotalRow.Cells(1).Text = Convert.ToString(dtbDetail1.Rows(i)("RELEASE_TYPE"))

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(2).Font.Bold = False
    '                TotalRow.Cells(2).ForeColor = Color.Black
    '                TotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                TotalRow.Cells(2).Text = Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_GROSS_AMT")).ToString("#,##0")

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(3).Font.Bold = False
    '                TotalRow.Cells(3).ForeColor = Color.Black
    '                TotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '                TotalRow.Cells(3).Text = Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_ADMS_QTY")).ToString("#,##0")

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(4).Font.Bold = False
    '                TotalRow.Cells(4).ForeColor = Color.Black
    '                TotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '                TotalRow.Cells(4).Text = Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_SCREEN_QTY")).ToString("#,##0")

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(5).Font.Bold = False
    '                TotalRow.Cells(5).ForeColor = Color.Black
    '                TotalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
    '                TotalRow.Cells(5).Text = Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_LOCATION_QTY")).ToString("#,##0")

    '                TotalRow.Cells.Add(New TableCell)
    '                TotalRow.Cells(6).Font.Bold = False
    '                TotalRow.Cells(6).ForeColor = Color.Black
    '                TotalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
    '                TotalRow.Cells(6).Text = (Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_CUMMU_AMT"))).ToString("#,##0")
    '                tblRpt.Rows.Add(TotalRow)

    '                If Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd").ToLower() = "thu" Then
    '                    decSunSum1 = 0
    '                    decSunSum2 = 0
    '                    decSunSum3 = 0
    '                End If

    '                If Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd").ToLower() = "thu" Or Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd").ToLower() = "fri" Or Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd").ToLower() = "sat" Or Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd").ToLower() = "sun" Then
    '                    decSunSum1 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_GROSS_AMT"))
    '                    decSunSum2 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_ADMS_QTY"))
    '                    decSunSum3 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_SCREEN_QTY"))
    '                End If
    '                decSum1 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_GROSS_AMT"))
    '                decSum2 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_ADMS_QTY"))
    '                decSum3 += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_SCREEN_QTY"))

    '                decTOTAL_ADMS_QTY += Convert.ToDecimal(dtbDetail1.Rows(i)("TOTAL_ADMS_QTY")).ToString("#,##0")

    '                'ไม่ใช่ rows สุดท้าย
    '                If (i < dtbDetail1.Rows.Count - 1) Then


    '                    'intIncreaseToWeek += 1
    '                    'If (strRELEASE_TYPE_Curent = "O") Then
    '                    '    dtRunningDateStart = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date"))

    '                    '    intIncreaseToWeek = 2
    '                    '    strRELEASE_TYPE = strRELEASE_TYPE_Curent = "C"
    '                    '    Continue For


    '                    intIncreaseToWeek += 1

    '                    If (strRELEASE_TYPE_Curent = "O") Then
    '                        dtRunningDateStart = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date"))

    '                        iCurrentO_C = iCurrentO_C + 1
    '                        If iCurrentO_C = 1 Then

    '                            dayStart = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date")).ToString("ddd")
    '                            ddmmyyyyStart = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date"))

    '                            Select Case dayStart.ToLower()
    '                                Case "mon"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(6)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "tue"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(5)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "wed"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(4)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "thu"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(3)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "fri"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(2)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "sat"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(1)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case "sun"
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart.AddDays(0)
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart.AddDays(6)
    '                                Case Else
    '                                    ddmmyyyyNextWeekend = ddmmyyyyStart
    '                                    ddmmyyyyNextWeek = ddmmyyyyStart
    '                            End Select

    '                            'ถ้าวัน O คือวันพุธ
    '                            'If dayStart.ToLower() = "wed"  Then
    '                            '    ddmmyyyyNextWeek = ddmmyyyyNextWeek.AddDays(7)
    '                            'ElseIf dayStart.ToLower() = "sun" Then
    '                            '    ddmmyyyyNextWeekend = ddmmyyyyNextWeekend.AddDays(7)
    '                            'End If


    '                        End If

    '                        intIncreaseToWeek = 2
    '                        strRELEASE_TYPE = strRELEASE_TYPE_Curent = "C"
    '                        Continue For

    '                        'Type ตัวต่อไปไม่เท่ากับตัวปัจจุบัน ให้เพิ่ม Rows intIncreaseToWeek
    '                    ElseIf (strRELEASE_TYPE_Curent <> Convert.ToString(dtbDetail1.Rows(i + 1)("RELEASE_TYPE")).Trim() And strRELEASE_TYPE_Curent = "P") Then
    '                        TotalRow = New TableRow()
    '                        TotalRow.Cells.Add(New TableCell)
    '                        TotalRow.Cells(0).Font.Bold = True
    '                        TotalRow.Cells(0).ForeColor = Color.Blue
    '                        TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                        TotalRow.Cells(0).Text = "Total P :"

    '                        TotalRow.Cells.Add(New TableCell)
    '                        TotalRow.Cells(1).Font.Bold = True
    '                        TotalRow.Cells(1).ForeColor = Color.Blue
    '                        TotalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '                        TotalRow.Cells(1).Text = ""

    '                        TotalRow.Cells.Add(New TableCell)
    '                        TotalRow.Cells(2).Font.Bold = True
    '                        TotalRow.Cells(2).ForeColor = Color.Blue
    '                        TotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                        TotalRow.Cells(2).Text = decSum1.ToString("#,##0")

    '                        TotalRow.Cells.Add(New TableCell)
    '                        TotalRow.Cells(3).Font.Bold = True
    '                        TotalRow.Cells(3).ForeColor = Color.Blue
    '                        TotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '                        TotalRow.Cells(3).Text = decSum2.ToString("#,##0")

    '                        tblRpt.Rows.Add(TotalRow)
    '                        TotalRow = New TableRow()
    '                        TotalRow.Cells.Add(New TableCell)
    '                        TotalRow.Cells(0).ColumnSpan = 7
    '                        TotalRow.Cells(0).Height = 15
    '                        TotalRow.Cells(0).Font.Bold = True
    '                        TotalRow.Cells(0).ForeColor = Color.Blue
    '                        TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                        TotalRow.Cells(0).Text = ""
    '                        tblRpt.Rows.Add(TotalRow)

    '                        decSum1 = 0
    '                        decSum2 = 0
    '                        decSum3 = 0

    '                        decSunSum1 = 0
    '                        decSunSum2 = 0
    '                        decSunSum3 = 0

    '                        strRELEASE_TYPE = strRELEASE_TYPE_Curent
    '                    Else
    '                        If ddmmyyyyNextWeek < Convert.ToDateTime(dtbDetail1.Rows(i + 1)("movie_revenue_date")) And (strRELEASE_TYPE_Curent = "C" Or strRELEASE_TYPE_Curent = "O") Then
    '                            'ครบ 7 วัน
    '                            'ddmmyyyyNextWeekend = ddmmyyyyNextWeek + 4
    '                            ddmmyyyyNextWeek = ddmmyyyyNextWeek.AddDays(7)

    '                            TotalRow = New TableRow()
    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(0).Font.Bold = True
    '                            TotalRow.Cells(0).ForeColor = Color.Blue
    '                            TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                            TotalRow.Cells(0).Text = "Total Week " + Convert.ToString(intWeekNo)

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(1).Font.Bold = True
    '                            TotalRow.Cells(1).ForeColor = Color.Blue
    '                            TotalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '                            TotalRow.Cells(1).Text = ""

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(2).Font.Bold = True
    '                            TotalRow.Cells(2).ForeColor = Color.Blue
    '                            TotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(2).Text = decSum1.ToString("#,##0")

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(3).Font.Bold = True
    '                            TotalRow.Cells(3).ForeColor = Color.Blue
    '                            TotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(3).Text = decSum2.ToString("#,##0")

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(4).Font.Bold = True
    '                            TotalRow.Cells(4).ForeColor = Color.Blue
    '                            TotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(4).Text = "" 'decSum3.ToString("#,##0")

    '                            tblRpt.Rows.Add(TotalRow)

    '                            TotalRow = New TableRow()
    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(0).Height = 15
    '                            TotalRow.Cells(0).ColumnSpan = 7
    '                            TotalRow.Cells(0).Font.Bold = True
    '                            TotalRow.Cells(0).ForeColor = Color.Blue
    '                            TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                            TotalRow.Cells(0).Text = ""
    '                            tblRpt.Rows.Add(TotalRow)

    '                            intWeekNo += 1
    '                            intIncreaseToWeek = 1
    '                            decSum1 = 0
    '                            decSum2 = 0
    '                            decSum3 = 0
    '                            dtRunningDateStart = Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date"))

    '                            ''''ElseIf ((Convert.ToDateTime(dtbDetail1.Rows(i)("movie_revenue_date"))).DayOfWeek = DayOfWeek.Sunday And strRELEASE_TYPE_Curent = "C") Then
    '                        ElseIf ddmmyyyyNextWeekend < Convert.ToDateTime(dtbDetail1.Rows(i + 1)("movie_revenue_date")) And (strRELEASE_TYPE_Curent = "C" Or strRELEASE_TYPE_Curent = "O") Then
    '                            ddmmyyyyNextWeekend = ddmmyyyyNextWeekend.AddDays(7)
    '                            'ddmmyyyyNextWeek = ddmmyyyyNextWeekend + 4
    '                            'ถ้าเป็นวันอาทิตย์ให้ sum ค่า
    '                            TotalRow = New TableRow()
    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(0).Font.Bold = True
    '                            TotalRow.Cells(0).ForeColor = Color.Blue
    '                            TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                            TotalRow.Cells(0).Text = "Weekend " + Convert.ToString(intWeekNo)

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(1).Font.Bold = True
    '                            TotalRow.Cells(1).ForeColor = Color.Blue
    '                            TotalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '                            TotalRow.Cells(1).Text = ""

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(2).Font.Bold = True
    '                            TotalRow.Cells(2).ForeColor = Color.Blue
    '                            TotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(2).Text = decSunSum1.ToString("#,##0")

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(3).Font.Bold = True
    '                            TotalRow.Cells(3).ForeColor = Color.Blue
    '                            TotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(3).Text = decSunSum2.ToString("#,##0")

    '                            TotalRow.Cells.Add(New TableCell)
    '                            TotalRow.Cells(4).Font.Bold = True
    '                            TotalRow.Cells(4).ForeColor = Color.Blue
    '                            TotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '                            TotalRow.Cells(4).Text = "" 'decSum3.ToString("#,##0")

    '                            tblRpt.Rows.Add(TotalRow)
    '                        End If
    '                    End If

    '                    'Rows สุดท้าย
    '                Else
    '                    TotalRow = New TableRow()
    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(0).Font.Bold = True
    '                    TotalRow.Cells(0).ForeColor = Color.Blue
    '                    TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                    TotalRow.Cells(0).Text = "Total Week " + Convert.ToString(intWeekNo)

    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(1).Font.Bold = True
    '                    TotalRow.Cells(1).ForeColor = Color.Blue
    '                    TotalRow.Cells(1).HorizontalAlign = HorizontalAlign.Center
    '                    TotalRow.Cells(1).Text = ""

    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(2).Font.Bold = True
    '                    TotalRow.Cells(2).ForeColor = Color.Blue
    '                    TotalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
    '                    TotalRow.Cells(2).Text = decSum1.ToString("#,##0")

    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(3).Font.Bold = True
    '                    TotalRow.Cells(3).ForeColor = Color.Blue
    '                    TotalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
    '                    TotalRow.Cells(3).Text = decSum2.ToString("#,##0")

    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(4).Font.Bold = True
    '                    TotalRow.Cells(4).ForeColor = Color.Blue
    '                    TotalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
    '                    TotalRow.Cells(4).Text = "" 'decSum3.ToString("#,##0")

    '                    tblRpt.Rows.Add(TotalRow)

    '                    TotalRow = New TableRow()
    '                    TotalRow.Cells.Add(New TableCell)
    '                    TotalRow.Cells(0).Height = 15
    '                    TotalRow.Cells(0).ColumnSpan = 7
    '                    TotalRow.Cells(0).Font.Bold = True
    '                    TotalRow.Cells(0).ForeColor = Color.Blue
    '                    TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '                    TotalRow.Cells(0).Text = ""
    '                    tblRpt.Rows.Add(TotalRow)

    '                    intIncreaseToWeek = 1
    '                    decSum1 = 0
    '                    decSum2 = 0
    '                    decSum3 = 0
    '                End If
    '            Next


    '            If dtbDetail1.Rows.Count > 0 Then
    '                tblRptReport.Rows(0).Cells(1).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("TOTAL_CUMMU_AMT")).ToString("#,##0")
    '                tblRptReport.Rows(0).Cells(3).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("AD_PUB_AMT")).ToString("#,##0")

    '                tblRptReport.Rows(1).Cells(1).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("FLAT_SALE_RENTAL_AMT")).ToString("#,##0")
    '                tblRptReport.Rows(1).Cells(3).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("PRINT_COST_AMT")).ToString("#,##0")

    '                tblRptReport.Rows(2).Cells(1).Text = Convert.ToDecimal(Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("TOTAL_CUMMU_AMT")) + Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("FLAT_SALE_RENTAL_AMT"))).ToString("#,##0")
    '                tblRptReport.Rows(2).Cells(3).Text = Convert.ToString(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("PRINT_QTY"))

    '                tblRptReport.Rows(3).Cells(1).Text = decTOTAL_ADMS_QTY.ToString("#,##0")
    '                tblRptReport.Rows(3).Cells(3).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("REVENUE_ESTIMETE_RENTAL")).ToString("#,##0")

    '                tblRptReport.Rows(4).Cells(3).Text = Convert.ToDecimal(dtbDetail1.Rows(dtbDetail1.Rows.Count - 1)("NET_CONTRIBUTION_AMT")).ToString("#,##0")
    '            End If

    '            tblRptReport.Rows(0).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(0).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(0).Cells.AddAt(2, New TableCell)

    '            tblRptReport.Rows(1).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(1).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(1).Cells.AddAt(2, New TableCell)

    '            tblRptReport.Rows(2).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(2).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(2).Cells.AddAt(2, New TableCell)

    '            tblRptReport.Rows(3).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(3).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(3).Cells.AddAt(2, New TableCell)

    '            tblRptReport.Rows(4).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(4).Cells.AddAt(2, New TableCell)
    '            tblRptReport.Rows(4).Cells.AddAt(2, New TableCell)

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/12/12 : Fix bug 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 7, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        Dim intMoive_Id As Integer = Convert.ToInt32(Session("PDABoxOffice_Movie"))

        'remove ข้อมูลใน Table
        For i As Integer = 5 To tbReport.Rows.Count - 1
            Me.tbReport.Rows.RemoveAt(i)
        Next

        Dim strCommand As String = ""
        strCommand += "select top 1 M.movietype_id "
        strCommand += "    , M.movie_nameen + '/' + M.movie_nameth as movie_name "
        strCommand += "    , M.movie_strdate "
        strCommand += "    , M.movietype_id "
        strCommand += "    , D.distributor_id "
        strCommand += "    , D.distributor_name "
        strCommand += "from tblMovie M "
        strCommand += "    left join tblDistributor D "
        strCommand += "    on D.distributor_id = M.distributor_id "
        strCommand += "where M.movie_id = " + Convert.ToString(intMoive_Id)

        Dim dtbMovie As DataTable = cDatabase.GetDataTable(strCommand)

        If (dtbMovie.Rows.Count > 0) Then
            Me.tbReport.Rows(1).Cells(0).Text = "TITLE : " + Convert.ToString(dtbMovie.Rows(0)("movie_name"))
            Me.tbReport.Rows(2).Cells(0).Text = "DISTRIBUTOR : " + Convert.ToString(dtbMovie.Rows(0)("distributor_name"))
            Me.tbReport.Rows(3).Cells(0).Text = "RELEASE DATE : " + Convert.ToDateTime(dtbMovie.Rows(0)("movie_strdate")).ToString("dd-MMM-yyyy")
        End If

        Dim dtDetail As DataTable = cDatabase.GetDataTable("exec spGetRptPDABoxOffice " + Convert.ToString(intMoive_Id))

        Dim intAmountAccumulate As Integer = 0

        Dim intWeekRunning As Integer = 0
        Dim intWeekDetailRunning As Integer = 0
        Dim intWeekDetailAmountSumary As Integer = 0
        Dim intWeekDetailAdmsSumary As Integer = 0

        Dim intWeekEndRunning As Integer = 0
        Dim intWeekEndDetailRunning As Integer = 0
        Dim intWeekEndDetailAmountSumary As Integer = 0
        Dim intWeekEndDetailAdmsSumary As Integer = 0

        For i As Integer = 0 To dtDetail.Rows.Count - 1

            intAmountAccumulate += dtDetail.Rows(i)("total_gross_amt")

            If String.Format("{0:ddd}", dtDetail.Rows(i)("revenue_date")) = "Thu" _
            OrElse String.Format("{0}", dtDetail.Rows(i)("release_type")) = "P" _
            Then
                intWeekEndDetailRunning = 0
                intWeekEndDetailAmountSumary = 0
                intWeekEndDetailAdmsSumary = 0
            End If

            Dim trDetail0 As New TableRow()

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(0).Font.Bold = False
            trDetail0.Cells(0).ForeColor = Color.Black
            trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(0).Text = String.Format("{0:dd-MMM-yyyy (ddd)}", dtDetail.Rows(i)("revenue_date"))
            trDetail0.Cells(0).Width = 140

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(1).Font.Bold = False
            trDetail0.Cells(1).ForeColor = Color.Black
            trDetail0.Cells(1).HorizontalAlign = HorizontalAlign.Left
            trDetail0.Cells(1).Text = String.Format("<font color=red><i>{0}<i></font>", dtDetail.Rows(i)("holiday_name"))
            trDetail0.Cells(1).Width = 120

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(2).Font.Bold = False
            trDetail0.Cells(2).ForeColor = Color.Black
            trDetail0.Cells(2).HorizontalAlign = HorizontalAlign.Center
            trDetail0.Cells(2).Text = String.Format("{0}", dtDetail.Rows(i)("release_type"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(3).Font.Bold = False
            trDetail0.Cells(3).ForeColor = Color.Black
            trDetail0.Cells(3).HorizontalAlign = HorizontalAlign.Right
            trDetail0.Cells(3).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("total_gross_amt"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(4).Font.Bold = False
            trDetail0.Cells(4).ForeColor = Color.Black
            trDetail0.Cells(4).HorizontalAlign = HorizontalAlign.Right
            trDetail0.Cells(4).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("total_adms_qty"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(5).Font.Bold = False
            trDetail0.Cells(5).ForeColor = Color.Black
            trDetail0.Cells(5).HorizontalAlign = HorizontalAlign.Right
            trDetail0.Cells(5).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("total_screen_qty"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(6).Font.Bold = False
            trDetail0.Cells(6).ForeColor = Color.Black
            trDetail0.Cells(6).HorizontalAlign = HorizontalAlign.Right
            trDetail0.Cells(6).Text = String.Format("{0:#,##0}", dtDetail.Rows(i)("total_location_qty"))

            trDetail0.Cells.Add(New TableCell)
            trDetail0.Cells(7).Font.Bold = False
            trDetail0.Cells(7).ForeColor = Color.Black
            trDetail0.Cells(7).HorizontalAlign = HorizontalAlign.Right
            trDetail0.Cells(7).Text = String.Format("{0:#,##0}", intAmountAccumulate)

            Me.tbReport.Rows.Add(trDetail0)

            intWeekEndDetailAmountSumary += dtDetail.Rows(i)("total_gross_amt")
            intWeekEndDetailAdmsSumary += dtDetail.Rows(i)("total_adms_qty")
            intWeekEndDetailRunning += 1

            intWeekDetailAmountSumary += dtDetail.Rows(i)("total_gross_amt")
            intWeekDetailAdmsSumary += dtDetail.Rows(i)("total_adms_qty")
            intWeekDetailRunning += 1



            '--- print total weekend
            If String.Format("{0:ddd}", dtDetail.Rows(i)("revenue_date")) = "Sun" Then
                trDetail0 = New TableRow()

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(0).Font.Bold = True
                trDetail0.Cells(0).ForeColor = Color.Blue
                trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Center
                trDetail0.Cells(0).Text = String.Format("Weekend {0}", dtDetail.Rows(i)("total_cummu_week"))
                trDetail0.Cells(0).ColumnSpan = 2

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(1).Font.Bold = True
                trDetail0.Cells(1).ForeColor = Color.Blue
                trDetail0.Cells(1).HorizontalAlign = HorizontalAlign.Center
                trDetail0.Cells(1).Text = ""

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(2).Font.Bold = True
                trDetail0.Cells(2).ForeColor = Color.Blue
                trDetail0.Cells(2).HorizontalAlign = HorizontalAlign.Right
                trDetail0.Cells(2).Text = String.Format("{0:#,##0}", intWeekEndDetailAmountSumary)

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(3).Font.Bold = True
                trDetail0.Cells(3).ForeColor = Color.Blue
                trDetail0.Cells(3).HorizontalAlign = HorizontalAlign.Right
                trDetail0.Cells(3).Text = String.Format("{0:#,##0}", intWeekEndDetailAdmsSumary)

                'trDetail0.Cells.Add(New TableCell)
                'trDetail0.Cells(4).Font.Bold = True
                'trDetail0.Cells(4).ForeColor = Color.Blue
                'trDetail0.Cells(4).HorizontalAlign = HorizontalAlign.Right
                'trDetail0.Cells(4).Text = ""

                Me.tbReport.Rows.Add(trDetail0)

                intWeekEndRunning += 1
                intWeekEndDetailRunning = 0
                intWeekEndDetailAmountSumary = 0
                intWeekEndDetailAdmsSumary = 0
            End If



            '--- print total week
            If (i = dtDetail.Rows.Count - 1) OrElse _
            ((i <= dtDetail.Rows.Count - 2) AndAlso (dtDetail.Rows(i)("total_cummu_week") <> dtDetail.Rows(i + 1)("total_cummu_week"))) _
            Then
                trDetail0 = New TableRow()

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(0).Font.Bold = True
                trDetail0.Cells(0).ForeColor = Color.Blue
                trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Center
                If String.Format("{0}", dtDetail.Rows(i)("release_type")) = "P" Then
                    trDetail0.Cells(0).Text = String.Format("Total P", dtDetail.Rows(i)("total_cummu_week"))
                Else
                    trDetail0.Cells(0).Text = String.Format("Total Week {0}", dtDetail.Rows(i)("total_cummu_week"))
                End If
                trDetail0.Cells(0).ColumnSpan = 2

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(1).Font.Bold = True
                trDetail0.Cells(1).ForeColor = Color.Blue
                trDetail0.Cells(1).HorizontalAlign = HorizontalAlign.Center
                trDetail0.Cells(1).Text = ""

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(2).Font.Bold = True
                trDetail0.Cells(2).ForeColor = Color.Blue
                trDetail0.Cells(2).HorizontalAlign = HorizontalAlign.Right
                trDetail0.Cells(2).Text = String.Format("{0:#,##0}", intWeekDetailAmountSumary)

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(3).Font.Bold = True
                trDetail0.Cells(3).ForeColor = Color.Blue
                trDetail0.Cells(3).HorizontalAlign = HorizontalAlign.Right
                trDetail0.Cells(3).Text = String.Format("{0:#,##0}", intWeekDetailAdmsSumary)

                'trDetail0.Cells.Add(New TableCell)
                'trDetail0.Cells(4).Font.Bold = True
                'trDetail0.Cells(4).ForeColor = Color.Blue
                'trDetail0.Cells(4).HorizontalAlign = HorizontalAlign.Right
                'trDetail0.Cells(4).Text = ""

                Me.tbReport.Rows.Add(trDetail0)

                trDetail0 = New TableRow()

                trDetail0.Cells.Add(New TableCell)
                trDetail0.Cells(0).Height = 15
                trDetail0.Cells(0).ColumnSpan = 8
                trDetail0.Cells(0).Font.Bold = True
                trDetail0.Cells(0).ForeColor = Color.Blue
                trDetail0.Cells(0).HorizontalAlign = HorizontalAlign.Center
                trDetail0.Cells(0).Text = ""

                Me.tbReport.Rows.Add(trDetail0)

                intWeekRunning += 1
                intWeekDetailRunning = 0
                intWeekDetailAmountSumary = 0
                intWeekDetailAdmsSumary = 0
            End If
        Next



        '--- print summary 
        If dtDetail.Rows.Count > 0 Then
            Me.tbReportSummary.Rows(0).Cells(1).Text = Convert.ToDecimal(intAmountAccumulate).ToString("#,##0")
            Me.tbReportSummary.Rows(0).Cells(4).Text = Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("ad_pub_amt")).ToString("#,##0")

            Me.tbReportSummary.Rows(1).Cells(1).Text = Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("flat_sale_rental_amt")).ToString("#,##0")
            Me.tbReportSummary.Rows(1).Cells(4).Text = Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("print_cost_amt")).ToString("#,##0")

            Me.tbReportSummary.Rows(2).Cells(1).Text = Convert.ToDecimal(intAmountAccumulate + Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("flat_sale_rental_amt"))).ToString("#,##0")
            Me.tbReportSummary.Rows(2).Cells(4).Text = Convert.ToString(dtDetail.Rows(dtDetail.Rows.Count - 1)("print_qty"))

            Me.tbReportSummary.Rows(3).Cells(1).Text = String.Format("{0:#,##0}", dtDetail.Compute("sum(total_adms_qty)", ""))
            Me.tbReportSummary.Rows(3).Cells(4).Text = Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("revenue_estimete_rental")).ToString("#,##0")

            Me.tbReportSummary.Rows(4).Cells(4).Text = Convert.ToDecimal(dtDetail.Rows(dtDetail.Rows.Count - 1)("net_contribution_amt")).ToString("#,##0")
        End If
    End Sub

    Private Sub GenerateReport()

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Response.Redirect("frmRptPDABoxOfficeParam.aspx")
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
        Dim tw As New IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        frm.Attributes("runat") = "server"
        frm.Controls.Add(divExport)
        frm.Controls.Add(tbReport)
        frm.Controls.Add(tbReportSummary)
        Response.AddHeader("content-disposition", "attachment;filename=PDA_BoxOffice.xls")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)

        Response.ContentType = "application/vnd.xls"
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)

        frm.RenderControl(hw)
        'Response.Write(tw.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + tw.ToString())
        Response.End()
    End Sub

End Class