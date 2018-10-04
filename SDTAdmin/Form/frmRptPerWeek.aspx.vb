Imports Web.Data

Partial Public Class frmRptPerWeek
    Inherits System.Web.UI.Page

    '--- Commented by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If

    '    'If Not IsPostBack Then
    '    tblRpt.Rows(1).Cells(0).Text = "<center>SDT Weekly Box Office (for Finance)</center>" + "Title : " & Session("wRptMovieName")

    '    ' Create Date Header
    '    Dim strDate As DateTime
    '    Dim i As Integer
    '    strDate = CDate(Session("wRptStrDate"))
    '    For i = 0 To 6
    '        tblRpt.Rows(2).Cells(i + 2).Text = Format(strDate.AddDays(i), "dd-MMM-yy")
    '        'Session("wRptStrDate")
    '        'Session("wRptEndDate")
    '        'Session("wRptMovieID")
    '    Next
    '    'End Create Date Header

    '    'Add Row and Column
    '    Dim getBoxOfficeData As New cDatabase
    '    Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeByWeek(Session("wRptMovieID"), Format(Session("wRptStrDate"), "yyyyMMdd"), Format(Session("wRptEndDate"), "yyyyMMdd"))
    '    Dim sessionCount, SumBox, SumAdms, rowCount As Double
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
    '    While (readBoxOfficeData.Read())
    '        If readBoxOfficeData("TName").ToString() <> lastTheater Then
    '            sessionCount = 0
    '            Dim detailsRow As New TableRow()
    '            rowCount = rowCount + 1
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(0).Text = rowCount
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(1).Text = readBoxOfficeData("TName").ToString()
    '            Dim j As Integer
    '            For j = 0 To 13
    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(j + 2).Text() = ""
    '            Next
    '            Dim k As Integer
    '            k = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
    '            detailsRow.Cells(k + 2).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            detailsRow.Cells(k + 2).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells(k + 3).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
    '            detailsRow.Cells(k + 3).HorizontalAlign = HorizontalAlign.Right

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(16).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            detailsRow.Cells(16).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(17).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
    '            detailsRow.Cells(17).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(18).Text = Format(CDbl(readBoxOfficeData("SumAmount")) - CDbl(readBoxOfficeData("SumAmount")) * 7 / 100, "#,##0")
    '            detailsRow.Cells(18).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(19).Text = "50%"
    '            detailsRow.Cells(19).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(20).Text = "=sum(S" & rowCount + 5 & "*T" & rowCount + 5 & ")"
    '            detailsRow.Cells(20).HorizontalAlign = HorizontalAlign.Right
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(21).Text = "=sum(Q" & rowCount + 5 & "*T" & rowCount + 5 & ")"
    '            detailsRow.Cells(21).HorizontalAlign = HorizontalAlign.Right

    '            tblRpt.Rows.Add(detailsRow)

    '            lastTheater = readBoxOfficeData("TName").ToString()
    '            SumBox = readBoxOfficeData("SumAmount").ToString()
    '            SumAdms = readBoxOfficeData("SumAdms").ToString()

    '            sessionCount = 0
    '        Else
    '            'sessionCount = sessionCount + 2
    '            Dim m As Integer
    '            m = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
    '            SumBox = SumBox + CDbl(readBoxOfficeData("SumAmount"))
    '            SumAdms = SumAdms + CDbl(readBoxOfficeData("SumAdms"))

    '            tblRpt.Rows(rowCount + 3).Cells(m + 2).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(m + 2).HorizontalAlign = HorizontalAlign.Right
    '            tblRpt.Rows(rowCount + 3).Cells(m + 3).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(m + 3).HorizontalAlign = HorizontalAlign.Right
    '            tblRpt.Rows(rowCount + 3).Cells(16).Text = Format(SumBox, "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(16).HorizontalAlign = HorizontalAlign.Right
    '            tblRpt.Rows(rowCount + 3).Cells(17).Text = Format(SumAdms, "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(17).HorizontalAlign = HorizontalAlign.Right
    '            tblRpt.Rows(rowCount + 3).Cells(18).Text = Format(SumBox * 100 / 107, "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(18).HorizontalAlign = HorizontalAlign.Right

    '            lastTheater = readBoxOfficeData("TName").ToString()
    '        End If
    '    End While
    '    readBoxOfficeData.Close()

    '    Dim TotalRow As New TableRow()
    '    TotalRow.Font.Bold = True
    '    'TotalRow.BackColor = Color.LightGray
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(0).ColumnSpan = 2
    '    TotalRow.Cells(0).Text = "Grand Total :"
    '    TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
    '    TotalRow.Cells(0).BackColor = Color.FromName("#303D50")
    '    TotalRow.Cells(0).ForeColor = Color.White
    '    Dim tcol, trow As Integer
    '    For tcol = 1 To 17
    '        TotalRow.Cells.Add(New TableCell)
    '        TotalRow.Cells(tcol).Text = 0
    '        TotalRow.Cells(tcol).BackColor = Color.FromName("#303D50")
    '        TotalRow.Cells(tcol).ForeColor = Color.White
    '        TotalRow.Cells(tcol).HorizontalAlign = HorizontalAlign.Right
    '        For trow = 0 To tblRpt.Rows.Count - 5
    '            TotalRow.Cells(tcol).Text = Format(CDbl(TotalRow.Cells(tcol).Text) + CDbl(IIf(tblRpt.Rows(trow + 4).Cells(tcol + 1).Text = "", 0, tblRpt.Rows(trow + 4).Cells(tcol + 1).Text)), "#,##0")
    '        Next
    '    Next
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(18).Text = ""
    '    TotalRow.Cells(18).BackColor = Color.FromName("#303D50")
    '    TotalRow.Cells(18).ForeColor = Color.White
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(19).Text = "=sum(U6:U" & rowCount + 5 & ")"
    '    TotalRow.Cells(19).BackColor = Color.FromName("#303D50")
    '    TotalRow.Cells(19).ForeColor = Color.White
    '    TotalRow.Cells(19).HorizontalAlign = HorizontalAlign.Right
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(20).Text = "=sum(V6:V" & rowCount + 5 & ")"
    '    TotalRow.Cells(20).BackColor = Color.FromName("#303D50")
    '    TotalRow.Cells(20).ForeColor = Color.White
    '    TotalRow.Cells(20).HorizontalAlign = HorizontalAlign.Right

    '    tblRpt.Rows.Add(TotalRow)
    '    'end Add

    '    'End If

    'End Sub
    '--- End commented by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'If Mid(Session("permission"), 11, 1) = "0" Then
    '    '    Response.Redirect("InfoPage.aspx")
    '    'End If

    '    'If Not IsPostBack Then
    '    tblRpt.Rows(1).Cells(0).Text = "<center>SDT Weekly Box Office (for Amount)</center>" + "Title : " & Session("wRptMovieName")

    '    ' Create Date Header
    '    Dim strDate As DateTime
    '    Dim i As Integer
    '    strDate = CDate(Session("wRptStrDate"))
    '    For i = 0 To 6
    '        tblRpt.Rows(2).Cells(i + 2).Text = Format(strDate.AddDays(i), "dd-MMM-yy")
    '        'Session("wRptStrDate")
    '        'Session("wRptEndDate")
    '        'Session("wRptMovieID")
    '    Next
    '    'End Create Date Header

    '    'Add Row and Column
    '    Dim getBoxOfficeData As New cDatabase
    '    Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeByWeek(Session("wRptMovieID"), Format(Session("wRptStrDate"), "yyyyMMdd"), Format(Session("wRptEndDate"), "yyyyMMdd"))
    '    Dim sessionCount, SumBox, SumAdms, rowCount As Double
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
    '    While (readBoxOfficeData.Read())
    '        If readBoxOfficeData("TName").ToString() <> lastTheater Then
    '            sessionCount = 0
    '            Dim detailsRow As New TableRow()
    '            rowCount = rowCount + 1
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
    '            detailsRow.Cells(0).Text = rowCount
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(1).Text = readBoxOfficeData("TName").ToString()
    '            Dim j As Integer
    '            For j = 0 To 13
    '                detailsRow.Cells.Add(New TableCell)
    '                detailsRow.Cells(j + 2).Text() = ""
    '            Next
    '            Dim k As Integer
    '            k = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
    '            detailsRow.Cells(k + 2).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            detailsRow.Cells(k + 3).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")

    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(16).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(17).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(18).Text = Format(CDbl(readBoxOfficeData("SumAmount")) - CDbl(readBoxOfficeData("SumAmount")) * 7 / 100, "#,##0")
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(19).Text = "50%"
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(20).Text = "=sum(S" & rowCount + 3 & "*T" & rowCount + 3 & ")"
    '            detailsRow.Cells.Add(New TableCell)
    '            detailsRow.Cells(21).Text = "=sum(Q" & rowCount + 3 & "*T" & rowCount + 3 & ")"

    '            tblRpt.Rows.Add(detailsRow)

    '            lastTheater = readBoxOfficeData("TName").ToString()
    '            SumBox = readBoxOfficeData("SumAmount").ToString()
    '            SumAdms = readBoxOfficeData("SumAdms").ToString()

    '            sessionCount = 0
    '        Else
    '            'sessionCount = sessionCount + 2
    '            Dim m As Integer
    '            m = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
    '            SumBox = SumBox + CDbl(readBoxOfficeData("SumAmount"))
    '            SumAdms = SumAdms + CDbl(readBoxOfficeData("SumAdms"))
    '            tblRpt.Rows(rowCount + 3).Cells(m + 2).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(m + 3).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(16).Text = Format(SumBox, "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(17).Text = Format(SumAdms, "#,##0")
    '            tblRpt.Rows(rowCount + 3).Cells(18).Text = Format(SumBox * 100 / 107, "#,##0")

    '            lastTheater = readBoxOfficeData("TName").ToString()
    '        End If
    '    End While
    '    readBoxOfficeData.Close()

    '    Dim TotalRow As New TableRow()
    '    TotalRow.Font.Bold = True
    '    TotalRow.BackColor = Color.LightGray
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(0).ColumnSpan = 2
    '    TotalRow.Cells(0).Text = "Grand Total :"
    '    TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
    '    Dim tcol, trow As Integer
    '    For tcol = 1 To 17
    '        TotalRow.Cells.Add(New TableCell)
    '        TotalRow.Cells(tcol).Text = 0
    '        For trow = 0 To tblRpt.Rows.Count - 5
    '            TotalRow.Cells(tcol).Text = Format(CDbl(TotalRow.Cells(tcol).Text) + CDbl(IIf(tblRpt.Rows(trow + 4).Cells(tcol + 1).Text = "", 0, tblRpt.Rows(trow + 4).Cells(tcol + 1).Text)), "#,##0")
    '        Next
    '    Next
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(18).Text = ""
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(19).Text = "=sum(U5:U" & rowCount + 4 & ")"
    '    TotalRow.Cells.Add(New TableCell)
    '    TotalRow.Cells(20).Text = "=sum(V5:V" & rowCount + 4 & ")"

    '    tblRpt.Rows.Add(TotalRow)
    '    'end Add

    '    'End If

    'End Sub

    '--- Added by Wittawat W. (CSI) on 2012/11/13 : Add film type and sound
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Mid(Session("permission"), 11, 1) = "0" Then
        '    Response.Redirect("InfoPage.aspx")
        'End If

        'If Not IsPostBack Then
        tblRpt.Rows(1).Cells(0).Text = "<center>SDT Weekly Box Office (for Finance)</center>" + "Title : " & Session("wRptMovieName")

        ' Create Date Header
        Dim strDate As DateTime
        Dim i As Integer
        strDate = CDate(Session("wRptStrDate"))
        For i = 0 To 6
            tblRpt.Rows(2).Cells(i + 3).Text = Format(strDate.AddDays(i), "dd-MMM-yy")
            'Session("wRptStrDate")
            'Session("wRptEndDate")
            'Session("wRptMovieID")
        Next
        'End Create Date Header

        'Add Row and Column
        Dim getBoxOfficeData As New cDatabase
        Dim readBoxOfficeData As IDataReader = getBoxOfficeData.getBoxOfficeByWeek(Session("wRptMovieID"), Format(Session("wRptStrDate"), "yyyyMMdd"), Format(Session("wRptEndDate"), "yyyyMMdd"))
        Dim sessionCount, SumBox, SumAdms, rowCount As Double
        Dim lastTheater As String
        Dim movieSys As String
        Dim movieSound As String
        Dim movieSoundcheck1 As String
        lastTheater = ""
        sessionCount = 0
        movieSys = ""
        movieSound = ""
        movieSoundcheck1 = ""
        SumBox = 0
        SumAdms = 0
        rowCount = 0
        While (readBoxOfficeData.Read())
            If String.Format("{0}{1}", readBoxOfficeData("TName"), readBoxOfficeData("film_type_sound_header_group")) <> lastTheater Then
                sessionCount = 0
                movieSoundcheck1 = ""
                Dim detailsRow As New TableRow()
                rowCount = rowCount + 1
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
                detailsRow.Cells(0).Text = rowCount
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(1).Text = readBoxOfficeData("TName").ToString()
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Center

                movieSoundcheck1 = readBoxOfficeData("film_type_sound_header_group")
                detailsRow.Cells(2).Text = movieSoundcheck1

                Dim j As Integer
                For j = 0 To 13
                    detailsRow.Cells.Add(New TableCell)
                    detailsRow.Cells(j + 3).Text() = ""
                Next

                Dim k As Integer
                k = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
                detailsRow.Cells(k + 3).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
                detailsRow.Cells(k + 3).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells(k + 4).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
                detailsRow.Cells(k + 4).HorizontalAlign = HorizontalAlign.Right

                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(17).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
                detailsRow.Cells(17).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(18).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
                detailsRow.Cells(18).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(19).Text = Format(CDbl(readBoxOfficeData("SumAmount")) - CDbl(readBoxOfficeData("SumAmount")) * 7 / 100, "#,##0")
                detailsRow.Cells(19).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(20).Text = "50%"
                detailsRow.Cells(20).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(21).Text = "=sum(T" & rowCount + 5 & "*U" & rowCount + 5 & ")"
                detailsRow.Cells(21).HorizontalAlign = HorizontalAlign.Right
                detailsRow.Cells.Add(New TableCell)
                detailsRow.Cells(22).Text = "=sum(R" & rowCount + 5 & "*U" & rowCount + 5 & ")"
                detailsRow.Cells(22).HorizontalAlign = HorizontalAlign.Right

                tblRpt.Rows.Add(detailsRow)

                lastTheater = String.Format("{0}{1}", readBoxOfficeData("TName"), readBoxOfficeData("film_type_sound_header_group"))
                SumBox = readBoxOfficeData("SumAmount").ToString()
                SumAdms = readBoxOfficeData("SumAdms").ToString()

                sessionCount = 0
            Else
                'sessionCount = sessionCount + 2
                Dim m As Integer
                m = 2 * CDbl(DateDiff(DateInterval.Day, CDate(Session("wRptStrDate")), CDate(readBoxOfficeData("revenue_date"))))
                SumBox = SumBox + CDbl(readBoxOfficeData("SumAmount"))
                SumAdms = SumAdms + CDbl(readBoxOfficeData("SumAdms"))

                tblRpt.Rows(rowCount + 3).Cells(m + 3).Text = Format(readBoxOfficeData("SumAmount"), "#,##0")
                tblRpt.Rows(rowCount + 3).Cells(m + 3).HorizontalAlign = HorizontalAlign.Right
                tblRpt.Rows(rowCount + 3).Cells(m + 4).Text = Format(readBoxOfficeData("SumAdms"), "#,##0")
                tblRpt.Rows(rowCount + 3).Cells(m + 4).HorizontalAlign = HorizontalAlign.Right

                tblRpt.Rows(rowCount + 3).Cells(17).Text = Format(SumBox, "#,##0")
                tblRpt.Rows(rowCount + 3).Cells(17).HorizontalAlign = HorizontalAlign.Right
                tblRpt.Rows(rowCount + 3).Cells(18).Text = Format(SumAdms, "#,##0")
                tblRpt.Rows(rowCount + 3).Cells(18).HorizontalAlign = HorizontalAlign.Right
                tblRpt.Rows(rowCount + 3).Cells(19).Text = Format(SumBox * 100 / 107, "#,##0")
                tblRpt.Rows(rowCount + 3).Cells(19).HorizontalAlign = HorizontalAlign.Right

                If movieSoundcheck1 <> "E/T" Then
                    If movieSoundcheck1 = readBoxOfficeData("film_type_sound_header_group") Then
                        movieSoundcheck1 = readBoxOfficeData("film_type_sound_header_group")
                    Else
                        movieSoundcheck1 = "E/T"
                    End If
                End If
                tblRpt.Rows(rowCount + 3).Cells(2).Text = movieSoundcheck1

                lastTheater = String.Format("{0}{1}", readBoxOfficeData("TName"), readBoxOfficeData("film_type_sound_header_group"))
            End If
        End While
        readBoxOfficeData.Close()

        Dim TotalRow As New TableRow()
        TotalRow.Font.Bold = True
        'TotalRow.BackColor = Color.LightGray
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(0).ColumnSpan = 3
        TotalRow.Cells(0).Text = "Grand Total :"
        TotalRow.Cells(0).HorizontalAlign = HorizontalAlign.Right
        TotalRow.Cells(0).BackColor = Color.FromName("#303D50")
        TotalRow.Cells(0).ForeColor = Color.White
        Dim tcol, trow As Integer
        For tcol = 1 To 17
            TotalRow.Cells.Add(New TableCell)
            TotalRow.Cells(tcol).Text = 0
            TotalRow.Cells(tcol).BackColor = Color.FromName("#303D50")
            TotalRow.Cells(tcol).ForeColor = Color.White
            TotalRow.Cells(tcol).HorizontalAlign = HorizontalAlign.Right
            For trow = 0 To tblRpt.Rows.Count - 5
                TotalRow.Cells(tcol).Text = Format(CDbl(TotalRow.Cells(tcol).Text) + CDbl(IIf(tblRpt.Rows(trow + 4).Cells(tcol + 2).Text = "", 0, tblRpt.Rows(trow + 4).Cells(tcol + 2).Text)), "#,##0")
            Next
        Next
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(18).Text = ""
        TotalRow.Cells(18).BackColor = Color.FromName("#303D50")
        TotalRow.Cells(18).ForeColor = Color.White
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(19).Text = "=sum(V6:V" & rowCount + 5 & ")"
        TotalRow.Cells(19).BackColor = Color.FromName("#303D50")
        TotalRow.Cells(19).ForeColor = Color.White
        TotalRow.Cells(19).HorizontalAlign = HorizontalAlign.Right
        TotalRow.Cells.Add(New TableCell)
        TotalRow.Cells(20).Text = "=sum(W6:W" & rowCount + 5 & ")"
        TotalRow.Cells(20).BackColor = Color.FromName("#303D50")
        TotalRow.Cells(20).ForeColor = Color.White
        TotalRow.Cells(20).HorizontalAlign = HorizontalAlign.Right

        tblRpt.Rows.Add(TotalRow)
        'end Add

        'End If

    End Sub

    Protected Sub btnExport0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport0.Click
        Response.Clear()
        'Response.AddHeader("content-disposition", "attachment;filename=" & Session("wRptMovieName") & "_ByWeek.xls")
        Response.AddHeader("content-disposition", "attachment;filename=CTBV_Weekly_Box_Office_ByWeek.xls")
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.xls"
        Dim stringWrite As IO.StringWriter = New System.IO.StringWriter()
        Dim htmlWrite As HtmlTextWriter = New HtmlTextWriter(stringWrite)
        tblRpt.RenderControl(htmlWrite)
        'Response.Write(stringWrite.ToString())
        Response.Write("<head><meta http-equiv='Content-Type' content='text/html; charset=utf-8' /></head>" + stringWrite.ToString())
        Response.End()
    End Sub

    Protected Sub btnCancel0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel0.Click
        Response.Redirect("frmRptPerWeekParam.aspx")
    End Sub
End Class