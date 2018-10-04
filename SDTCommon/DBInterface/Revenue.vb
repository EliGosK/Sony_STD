Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports SDTCommon.Utils

Namespace DBInterface
    Public Class Revenue
        Public Shared Function ReportSummaryFreeTicket(ByVal movieId As Int32, ByVal startDate As Date, ByVal endDate As Date, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal screenId As Int32?) As DataSet
            '@movie_id
            ', @start_date
            ', @end_date
            ', @screen_id
            ', @theater_id
            ', @circuit_id
            Dim sql As String = My.Resources.Revenue.SelectReportFreeTicket
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@start_date", startDate))
            paramList.Add(New SqlParameter("@end_date", endDate))
            paramList.Add(New SqlParameter("@screen_id", screenId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If

            Dim dtbRet As New DataTable
            If Not IsNothing(screenId) Then
                dtbRet.Columns.Add("Revenue Date", GetType(String))
            ElseIf Not IsNothing(theaterId) Then
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Screen", GetType(String))
            Else
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Name", GetType(String))
            End If

            dtbRet.Columns.Add("Report|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Report|ADMS", GetType(Int32))
            dtbRet.Columns.Add("Actual|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Actual|ADMS", GetType(Int32))

            dtbRet.Columns.Add("บัตรฟรีคิดเงิน|จำนวนเงิน", GetType(Int32))
            dtbRet.Columns.Add("บัตรฟรีคิดเงิน|ที่นั่ง", GetType(Int32))
            dtbRet.Columns.Add("บัตรฟรีคิดเงิน|%", GetType(Double))

            dtbRet.Columns.Add("บัตรฟรีทั่วไป|ที่นั่ง", GetType(Int32))
            dtbRet.Columns.Add("บัตรฟรีทั่วไป|%", GetType(Double))
            dtbRet.Columns.Add("บัตรฟรีพิเศษ|ที่นั่ง", GetType(Int32))
            dtbRet.Columns.Add("บัตรฟรีพิเศษ|%", GetType(Double))

            dtbRet.Columns.Add("ส่วนเกินของบัตรฟรีเกิน 5 ที่|จำนวนเงิน", GetType(Int32))
            dtbRet.Columns.Add("ส่วนเกินของบัตรฟรีเกิน 5 ที่|ที่นั่ง", GetType(Int32))
            dtbRet.Columns.Add("ส่วนเกินของบัตรฟรีเกิน 5 ที่|%", GetType(Double))

            dtbRet.Columns.Add("Total|ที่นั่ง", GetType(Int32))
            dtbRet.Columns.Add("Total|%", GetType(Double))

            Dim dtbRevenue As DataTable = ds.Tables(0)

            For Each drRevenue As DataRow In dtbRevenue.Rows
                Dim drNewItem As DataRow = dtbRet.NewRow()

                Dim revenueReport As Double = CType(drRevenue("revenue_report"), Int32)
                Dim viewerReport As Int32 = CType(drRevenue("viewer_report"), Int32)
                Dim revenueActual As Double = CType(drRevenue("revenue_actual"), Int32)
                Dim viewerActual As Int32 = CType(drRevenue("viewer_actual"), Int32)

                Dim freeTicketPrice As Double = CType(drRevenue("free_ticket_price"), Double)
                Dim freeTicketQuantity As Int32 = CType(drRevenue("free_ticket_quantity"), Int32)
                Dim freeTicketPercent As Double = CType(IIf(viewerReport = 0, 0, freeTicketQuantity / viewerReport), Double) * 100

                Dim freeTicketNormCount As Double = CType(drRevenue("free_ticket_norm_count"), Double)
                Dim freeTicketNormPercent As Double = CType(IIf(viewerReport = 0, 0, freeTicketNormCount / viewerReport), Double) * 100
                Dim freeTicketSpecCount As Double = CType(drRevenue("free_ticket_special_count"), Double)
                Dim freeTicketSpecPercent As Double = CType(IIf(viewerReport = 0, 0, freeTicketSpecCount / viewerReport), Double) * 100

                Dim freeMore5Price As Double = CType(drRevenue("free_more_5_sum"), Double)
                Dim freeMore5Count As Int32 = CType(drRevenue("free_more_5_count"), Int32)
                Dim freeMore5Percent As Double = CType(IIf(viewerReport = 0, 0, freeMore5Count / viewerReport), Double) * 100

                Dim totalViewer As Double = freeTicketQuantity + freeTicketNormCount + freeTicketSpecCount
                Dim totalViewerPercent As Double = CType(IIf(viewerReport = 0, 0, totalViewer / viewerReport), Double) * 100

                If Not IsNothing(screenId) Then
                    drNewItem("Revenue Date") = CDate(drRevenue("revenue_date")).ToString("dd/MM/yyyy")
                ElseIf Not IsNothing(theaterId) Then
                    drNewItem("Id") = drRevenue("theatersub_id")
                    drNewItem("Screen") = drRevenue("theatersub_name")
                ElseIf Not IsNothing(circuitId) Then
                    drNewItem("Id") = drRevenue("theater_id")
                    drNewItem("Name") = drRevenue("theater_name")
                Else
                    drNewItem("Id") = drRevenue("circuit_id")
                    drNewItem("Name") = drRevenue("circuit_name")
                End If
                drNewItem("Report|B.O.") = revenueReport
                drNewItem("Report|ADMS") = viewerReport
                drNewItem("Actual|B.O.") = revenueActual
                drNewItem("Actual|ADMS") = viewerActual

                drNewItem("บัตรฟรีคิดเงิน|จำนวนเงิน") = freeTicketPrice
                drNewItem("บัตรฟรีคิดเงิน|ที่นั่ง") = freeTicketQuantity
                drNewItem("บัตรฟรีคิดเงิน|%") = freeTicketPercent

                drNewItem("บัตรฟรีทั่วไป|ที่นั่ง") = freeTicketNormCount
                drNewItem("บัตรฟรีทั่วไป|%") = freeTicketNormPercent
                drNewItem("บัตรฟรีพิเศษ|ที่นั่ง") = freeTicketSpecCount
                drNewItem("บัตรฟรีพิเศษ|%") = freeTicketSpecPercent

                drNewItem("ส่วนเกินของบัตรฟรีเกิน 5 ที่|จำนวนเงิน") = freeMore5Price
                drNewItem("ส่วนเกินของบัตรฟรีเกิน 5 ที่|ที่นั่ง") = freeMore5Count
                drNewItem("ส่วนเกินของบัตรฟรีเกิน 5 ที่|%") = freeMore5Percent

                drNewItem("Total|ที่นั่ง") = totalViewer
                drNewItem("Total|%") = totalViewerPercent

                dtbRet.Rows.Add(drNewItem)
            Next

            Dim sum As Dictionary(Of Int32, Double) = GetSummaryColumn(dtbRet)

            Dim footerDtb As DataTable = dtbRet.Clone
            Dim footerDr As DataRow = footerDtb.NewRow()
            For Each key As Int32 In sum.Keys
                footerDr(key) = sum(key)
            Next
            For Each c As DataColumn In footerDtb.Columns
                If c.DataType Is GetType(Double) Then
                    footerDr(c.ColumnName) = (CDbl(footerDr(c.ColumnName)) / dtbRet.Rows.Count)
                End If
            Next
            footerDtb.Rows.Add(footerDr)
            footerDtb.TableName = "Footer"

            Dim retDs As New DataSet
            retDs.Tables.Add(FormatTable(dtbRet))
            retDs.Tables.Add(FormatTable(footerDtb))
            Return retDs
        End Function
        Public Shared Function ReportSummaryFreeTicketAndPerCap(ByVal movieId As Int32, ByVal startDate As Date, ByVal endDate As Date, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal screenId As Int32?) As DataSet
            '@movie_id
            ', @start_date
            ', @end_date
            ', @screen_id
            ', @theater_id
            ', @circuit_id
            Dim sql As String = My.Resources.Revenue.SelectRevenueMovie
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@start_date", startDate))
            paramList.Add(New SqlParameter("@end_date", endDate))
            paramList.Add(New SqlParameter("@screen_id", screenId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Dim dtbRet As New DataTable
            If Not IsNothing(screenId) Then
                dtbRet.Columns.Add("Revenue Date", GetType(String))
            ElseIf Not IsNothing(theaterId) Then
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Screen", GetType(String))
            Else
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Name", GetType(String))
            End If
            dtbRet.Columns.Add("Report|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Report|ADMS", GetType(Int32))
            dtbRet.Columns.Add("Actual|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Actual|ADMS", GetType(Int32))

            Dim dtbRevenue As DataTable = ds.Tables(0)

            sql = My.Resources.Revenue.SelectFreeTicketCapMovieViewer
            sql = sql.Replace("@movie_id", CType(movieId, String))
            sql = sql.Replace("@start_date", "'" & startDate.ToString("yyyy-MM-dd") & "'")
            sql = sql.Replace("@end_date", "'" & endDate.ToString("yyyy-MM-dd") & "'")
            sql = sql.Replace("@screen_id", CType(IIf(IsNothing(screenId), "NULL", screenId), String))
            sql = sql.Replace("@theater_id", CType(IIf(IsNothing(theaterId), "NULL", theaterId), String))
            sql = sql.Replace("@circuit_id", CType(IIf(IsNothing(circuitId), "NULL", circuitId), String))

            Dim dsType As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If Not IsNothing(dsType) AndAlso dsType.Tables.Count <> 0 Then
                Dim dtbType As DataTable = dsType.Tables(0)

                sql = My.Resources.Revenue.SelectFreeTicketCapMoviePrice
                sql = sql.Replace("@movie_id", CType(movieId, String))
                sql = sql.Replace("@start_date", "'" & startDate.ToString("yyyy-MM-dd") & "'")
                sql = sql.Replace("@end_date", "'" & endDate.ToString("yyyy-MM-dd") & "'")
                sql = sql.Replace("@screen_id", CType(IIf(IsNothing(screenId), "NULL", screenId), String))
                sql = sql.Replace("@theater_id", CType(IIf(IsNothing(theaterId), "NULL", theaterId), String))
                sql = sql.Replace("@circuit_id", CType(IIf(IsNothing(circuitId), "NULL", circuitId), String))

                Dim dsPrice As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
                Dim dtbPrice As DataTable = dsPrice.Tables(0)

                Dim key As String
                If Not IsNothing(screenId) Then
                    key = "revenue_date"
                ElseIf Not IsNothing(theaterId) Then
                    key = "theatersub_id"
                ElseIf Not IsNothing(circuitId) Then
                    key = "theater_id"
                Else
                    key = "circuit_id"
                End If
                Dim list As New SortedList
                For i As Int32 = 1 To dtbType.Columns.Count - 1
                    Dim dc As DataColumn = dtbType.Columns(i)
                    list.Add(dc.ColumnName, dc.ColumnName)
                Next
                If list.Contains("บัตรฟรีคิดเงิน") Then
                    'เอาขึ้นก่อน
                    list.Remove("บัตรฟรีคิดเงิน")
                    dtbRet.Columns.Add("บัตรฟรีคิดเงิน|" & "Amount", GetType(Int32))
                    dtbRet.Columns.Add("บัตรฟรีคิดเงิน|" & "ADMS", GetType(Int32))
                    dtbRet.Columns.Add("บัตรฟรีคิดเงิน|" & "%", GetType(Double))
                End If
                Dim thaiIndex As Int32 = -1
                For i As Int32 = 0 To list.Values.Count - 1
                    If list.Values(i).ToString().Chars(0) > "z" Then
                        thaiIndex = i
                        Exit For
                    End If
                Next
                If thaiIndex > -1 Then
                    For i As Int32 = thaiIndex To list.Values.Count - 1
                        Dim value = list.Values(i).ToString()
                        dtbRet.Columns.Add(value & "|" & "Amount", GetType(Int32))
                        dtbRet.Columns.Add(value & "|" & "ADMS", GetType(Int32))
                        dtbRet.Columns.Add(value & "|" & "%", GetType(Double))
                    Next
                    For i As Int32 = list.Values.Count - 1 To thaiIndex Step -1
                        list.RemoveAt(i)
                    Next
                End If
                For Each value As String In list.Values
                    dtbRet.Columns.Add(value & "|" & "Amount", GetType(Int32))
                    dtbRet.Columns.Add(value & "|" & "ADMS", GetType(Int32))
                    dtbRet.Columns.Add(value & "|" & "%", GetType(Double))
                Next
                If Not (IsNothing(circuitId) AndAlso IsNothing(theaterId) AndAlso IsNothing(screenId)) Then
                    dtbType.Columns.Add("Total", GetType(Int32))
                    For Each dr As DataRow In dtbType.Rows
                        Dim total As Int32 = 0
                        For i As Int32 = 1 To dtbType.Columns.Count - 1
                            total += CInt(IIf(dr(i) Is DBNull.Value, 0, dr(i)))
                        Next
                        dr("Total") = total
                    Next
                    dtbPrice.Columns.Add("Total", GetType(Int32))
                    For Each dr As DataRow In dtbPrice.Rows
                        Dim total As Int32 = 0
                        For i As Int32 = 1 To dtbPrice.Columns.Count - 1
                            total += CInt(IIf(dr(i) Is DBNull.Value, 0, dr(i)))
                        Next
                        dr("Total") = total
                    Next

                    dtbRet.Columns.Add("Total|" & "Amount", GetType(Int32))
                    dtbRet.Columns.Add("Total|" & "ADMS", GetType(Int32))
                    dtbRet.Columns.Add("Total|" & "%", GetType(Double))
                End If
                For Each drRevenue As DataRow In dtbRevenue.Rows
                    Dim drNewItem As DataRow = dtbRet.NewRow()
                    Dim actualRevenue As Int32 = CType(drRevenue("revenue_actual"), Int32)

                    If Not IsNothing(screenId) Then
                        drNewItem("Revenue Date") = CDate(drRevenue("revenue_date")).ToString("dd/MM/yyyy")
                    ElseIf Not IsNothing(theaterId) Then
                        drNewItem("Id") = drRevenue("theatersub_id")
                        drNewItem("Screen") = drRevenue("theatersub_name")
                    ElseIf Not IsNothing(circuitId) Then
                        drNewItem("Id") = drRevenue("theater_id")
                        drNewItem("Name") = drRevenue("theater_name")
                    Else
                        drNewItem("Id") = drRevenue("circuit_id")
                        drNewItem("Name") = drRevenue("circuit_name")
                    End If
                    drNewItem("Report|B.O.") = drRevenue("revenue_report")
                    drNewItem("Report|ADMS") = drRevenue("viewer_report")
                    drNewItem("Actual|B.O.") = drRevenue("revenue_actual")
                    drNewItem("Actual|ADMS") = drRevenue("viewer_actual")

                    For i As Int32 = 1 To dtbType.Columns.Count - 1
                        Dim dc As DataColumn = dtbType.Columns(i)
                        drNewItem(dc.ColumnName & "|" & "Amount") = 0
                        drNewItem(dc.ColumnName & "|" & "ADMS") = 0
                        drNewItem(dc.ColumnName & "|" & "%") = 0
                    Next
                    For Each drType As DataRow In dtbType.Rows
                        If drRevenue(key).ToString() = drType(key).ToString() Then
                            For i As Int32 = 1 To dtbType.Columns.Count - 1
                                Dim dc As DataColumn = dtbType.Columns(i)
                                drNewItem(dc.ColumnName & "|" & "ADMS") = CInt(IIf(drType(dc.ColumnName) Is DBNull.Value, 0, drType(dc.ColumnName)))
                            Next
                            dtbType.Rows.Remove(drType)
                            Exit For
                        End If
                    Next
                    For Each drPrice As DataRow In dtbPrice.Rows
                        If drRevenue(key).ToString() = drPrice(key).ToString() Then
                            For i As Int32 = 1 To dtbPrice.Columns.Count - 1
                                Dim dc As DataColumn = dtbPrice.Columns(i)
                                Dim price As Int32 = CInt(IIf(drPrice(dc.ColumnName) Is DBNull.Value, 0, drPrice(dc.ColumnName)))
                                drNewItem(dc.ColumnName & "|" & "Amount") = price
                                drNewItem(dc.ColumnName & "|" & "%") = CDbl(IIf(actualRevenue = 0, 0, CDbl(price) / actualRevenue)) * 100
                            Next
                            dtbPrice.Rows.Remove(drPrice)
                            Exit For
                        End If
                    Next

                    dtbRet.Rows.Add(drNewItem)
                Next
            End If
            Dim sum As Dictionary(Of Int32, Double) = GetSummaryColumn(dtbRet)

            Dim footerDtb As DataTable = dtbRet.Clone
            Dim footerDr As DataRow = footerDtb.NewRow()
            For Each key As Int32 In sum.Keys
                footerDr(key) = sum(key)
            Next
            For Each c As DataColumn In footerDtb.Columns
                If c.DataType Is GetType(Double) Then
                    footerDr(c.ColumnName) = (CDbl(footerDr(c.ColumnName)) / dtbRet.Rows.Count)
                End If
            Next
            footerDtb.Rows.Add(footerDr)
            footerDtb.TableName = "Footer"

            Dim retDs As New DataSet
            retDs.Tables.Add(FormatTable(dtbRet))
            retDs.Tables.Add(FormatTable(footerDtb))
            Return retDs
        End Function
        Public Shared Function ReportSummaryTicketType(ByVal movieId As Int32, ByVal startDate As Date, ByVal endDate As Date, ByVal circuitId As Int32?, ByVal theaterId As Int32?, ByVal screenId As Int32?) As DataSet
            '@movie_id
            ', @start_date
            ', @end_date
            ', @screen_id
            ', @theater_id
            ', @circuit_id
            Dim sql As String = My.Resources.Revenue.SelectRevenueMovie
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@movie_id", movieId))
            paramList.Add(New SqlParameter("@start_date", startDate))
            paramList.Add(New SqlParameter("@end_date", endDate))
            paramList.Add(New SqlParameter("@screen_id", screenId))
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@circuit_id", circuitId))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Dim dtbRet As New DataTable
            If Not IsNothing(screenId) Then
                dtbRet.Columns.Add("Revenue Date", GetType(String))
            ElseIf Not IsNothing(theaterId) Then
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Screen", GetType(String))
            Else
                dtbRet.Columns.Add("Id", GetType(String))
                dtbRet.Columns.Add("Name", GetType(String))
            End If
            dtbRet.Columns.Add("Report|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Report|ADMS", GetType(Int32))
            dtbRet.Columns.Add("Actual|B.O.", GetType(Int32))
            dtbRet.Columns.Add("Actual|ADMS", GetType(Int32))

            Dim dtbRevenue As DataTable = ds.Tables(0)

            sql = My.Resources.Revenue.SelectTicketTypeMovie
            sql = sql.Replace("@movie_id", CType(movieId, String))
            sql = sql.Replace("@start_date", "'" & startDate.ToString("yyyy-MM-dd") & "'")
            sql = sql.Replace("@end_date", "'" & endDate.ToString("yyyy-MM-dd") & "'")
            sql = sql.Replace("@screen_id", CType(IIf(IsNothing(screenId), "NULL", screenId), String))
            sql = sql.Replace("@theater_id", CType(IIf(IsNothing(theaterId), "NULL", theaterId), String))
            sql = sql.Replace("@circuit_id", CType(IIf(IsNothing(circuitId), "NULL", circuitId), String))

            Dim dsType As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql)
            If Not IsNothing(dsType) AndAlso dsType.Tables.Count <> 0 Then
                Dim dtbType As DataTable = dsType.Tables(0)
                Dim key As String
                If Not IsNothing(screenId) Then
                    key = "revenue_date"
                ElseIf Not IsNothing(theaterId) Then
                    key = "theatersub_id"
                ElseIf Not IsNothing(circuitId) Then
                    key = "theater_id"
                Else
                    key = "circuit_id"
                End If
                Dim list As New SortedList
                For i As Int32 = 1 To dtbType.Columns.Count - 1
                    Dim dc As DataColumn = dtbType.Columns(i)
                    list.Add(dc.ColumnName, dc.ColumnName)
                Next
                Dim thaiIndex As Int32 = -1
                For i As Int32 = 0 To list.Values.Count - 1
                    If list.Values(i).ToString().Chars(0) > "z" Then
                        thaiIndex = i
                        Exit For
                    End If
                Next
                If thaiIndex > -1 Then
                    For i As Int32 = thaiIndex To list.Values.Count - 1
                        Dim value = list.Values(i).ToString()
                        dtbRet.Columns.Add(value & "|" & "ADMS", GetType(Int32))
                        dtbRet.Columns.Add(value & "|" & "%", GetType(Double))
                    Next
                    For i As Int32 = list.Values.Count - 1 To thaiIndex Step -1
                        list.RemoveAt(i)
                    Next
                End If
                For Each value As String In list.Values
                    dtbRet.Columns.Add(value & "|" & "ADMS", GetType(Int32))
                    dtbRet.Columns.Add(value & "|" & "%", GetType(Double))
                Next
                If Not (IsNothing(circuitId) AndAlso IsNothing(theaterId) AndAlso IsNothing(screenId)) Then
                    dtbType.Columns.Add("Total", GetType(Int32))
                    For Each dr As DataRow In dtbType.Rows
                        Dim total As Int32 = 0
                        For i As Int32 = 1 To dtbType.Columns.Count - 1
                            total += CInt(IIf(dr(i) Is DBNull.Value, 0, dr(i)))
                        Next
                        dr("Total") = total
                    Next
                    dtbRet.Columns.Add("Total|" & "ADMS", GetType(Int32))
                    dtbRet.Columns.Add("Total|" & "%", GetType(Double))
                End If
                For Each drRevenue As DataRow In dtbRevenue.Rows
                    Dim drNewItem As DataRow = dtbRet.NewRow()
                    Dim actualViewer As Int32 = CType(drRevenue("viewer_actual"), Int32)

                    If Not IsNothing(screenId) Then
                        drNewItem("Revenue Date") = CDate(drRevenue("revenue_date")).ToString("dd/MM/yyyy")
                    ElseIf Not IsNothing(theaterId) Then
                        drNewItem("Id") = drRevenue("theatersub_id")
                        drNewItem("Screen") = drRevenue("theatersub_name")
                    ElseIf Not IsNothing(circuitId) Then
                        drNewItem("Id") = drRevenue("theater_id")
                        drNewItem("Name") = drRevenue("theater_name")
                    Else
                        drNewItem("Id") = drRevenue("circuit_id")
                        drNewItem("Name") = drRevenue("circuit_name")
                    End If
                    drNewItem("Report|B.O.") = drRevenue("revenue_report")
                    drNewItem("Report|ADMS") = drRevenue("viewer_report")
                    drNewItem("Actual|B.O.") = drRevenue("revenue_actual")
                    drNewItem("Actual|ADMS") = drRevenue("viewer_actual")

                    For i As Int32 = 1 To dtbType.Columns.Count - 1
                        Dim dc As DataColumn = dtbType.Columns(i)
                        drNewItem(dc.ColumnName & "|" & "ADMS") = 0
                        drNewItem(dc.ColumnName & "|" & "%") = 0
                    Next
                    For Each drType As DataRow In dtbType.Rows
                        If drRevenue(key).ToString() = drType(key).ToString() Then
                            For i As Int32 = 1 To dtbType.Columns.Count - 1
                                Dim dc As DataColumn = dtbType.Columns(i)
                                Dim adms As Int32 = CInt(IIf(drType(dc.ColumnName) Is DBNull.Value, 0, drType(dc.ColumnName)))
                                drNewItem(dc.ColumnName & "|" & "ADMS") = adms
                                drNewItem(dc.ColumnName & "|" & "%") = CDbl(IIf(actualViewer = 0, 0, CDbl(adms) / actualViewer)) * 100
                            Next
                            dtbType.Rows.Remove(drType)
                            Exit For
                        End If
                    Next

                    dtbRet.Rows.Add(drNewItem)
                Next
            End If
            Dim sum As Dictionary(Of Int32, Double) = GetSummaryColumn(dtbRet)

            Dim footerDtb As DataTable = dtbRet.Clone
            Dim footerDr As DataRow = footerDtb.NewRow()
            For Each key As Int32 In sum.Keys
                footerDr(key) = sum(key)
            Next
            For Each c As DataColumn In footerDtb.Columns
                If c.DataType Is GetType(Double) Then
                    footerDr(c.ColumnName) = (CDbl(footerDr(c.ColumnName)) / dtbRet.Rows.Count)
                End If
            Next
            footerDtb.Rows.Add(footerDr)
            footerDtb.TableName = "Footer"

            Dim retDs As New DataSet
            retDs.Tables.Add(FormatTable(dtbRet))
            retDs.Tables.Add(FormatTable(footerDtb))
            Return retDs
        End Function
        Public Shared Function SelectDailyRevenue(ByVal theaterId As Int32, ByVal revenueDate As Date) As DataTable
            Dim sql As String = My.Resources.Revenue.SelectDailyRevenue
            Dim paramList As New List(Of SqlParameter)
            paramList.Add(New SqlParameter("@theater_id", theaterId))
            paramList.Add(New SqlParameter("@revenue_date", revenueDate))

            Dim ds As DataSet = SqlHelper.ExecuteDataset(MainConnectionString, CommandType.Text, sql, paramList.ToArray())
            If IsNothing(ds) Then
                Return Nothing
            End If
            Return ds.Tables(0)
        End Function

        'Public Shared Function IsRevenue(ByVal workingDate As String, ByVal theaterId As Int32, ByVal movieId As Int32) As Boolean
        '    Return ReturnBoolean(SqlHelper.ExecuteScalar(MainConnectionString, "spChkRevenue", workingDate, theaterId, movieId))
        'End Function

        Private Shared Function GetSummaryColumn(ByVal dtb As DataTable) As Dictionary(Of Int32, Double)
            Dim retVal As New Dictionary(Of Int32, Double)
            For i As Int32 = 0 To dtb.Columns.Count - 1
                Dim c As DataColumn = dtb.Columns(i)
                If c.DataType Is GetType(Int32) OrElse c.DataType Is GetType(Double) OrElse c.DataType Is GetType(Single) Then
                    retVal.Add(i, 0)
                End If
            Next
            Dim keys() As Int32 = retVal.Keys.ToArray
            For Each dr As DataRow In dtb.Rows
                For Each key As Int32 In keys
                    Dim newVal As Double = CDbl(dr(key)) + retVal(key)
                    retVal(key) = newVal
                Next
            Next
            Return retVal
        End Function
        Private Shared Function FormatTable(ByVal dtb As DataTable) As DataTable
            Dim retVal As New DataTable
            For Each c As DataColumn In dtb.Columns
                retVal.Columns.Add(c.ColumnName, GetType(String))
            Next
            For Each dr As DataRow In dtb.Rows
                Dim newDr As DataRow = retVal.NewRow()
                For Each c As DataColumn In dtb.Columns
                    If c.DataType Is GetType(Int32) Then
                        newDr(c.ColumnName) = ReturnNumberWithFormat(dr(c.ColumnName), True)
                    ElseIf c.DataType Is GetType(Single) OrElse c.DataType Is GetType(Double) Then
                        newDr(c.ColumnName) = ReturnNumberWithFormat(dr(c.ColumnName), False)
                    Else
                        newDr(c.ColumnName) = dr(c.ColumnName).ToString()
                    End If
                Next
                retVal.Rows.Add(newDr)
            Next
            Return retVal
        End Function
    End Class
End Namespace