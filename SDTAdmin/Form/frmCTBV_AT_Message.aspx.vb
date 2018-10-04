Imports Web.Data
Imports System.Web.Security

Partial Class frmCTBV_AT_Message
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim cDB As New cDatabase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        'Put user code to initialize the page here
        If Mid(Session("permission"), 30, 1) = "0" Then
            Response.Redirect("InfoPage.aspx")
        Else
            GetMessage()
        End If
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExit.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()

    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = ListItemType.Item Or e.Row.RowType = ListItemType.AlternatingItem Then

            Dim dr As Data.DataRowView = e.Row.DataItem
            If IsDBNull(dr("read_flag")) = False Then

                If dr("read_flag") = "Y" Then
                    e.Row.ForeColor = Color.Green
                    e.Row.Font.Bold = True
                Else
                    e.Row.ForeColor = Color.LightGray
                    e.Row.Font.Bold = False
                End If
            Else
                e.Row.ForeColor = Color.Red
                e.Row.Font.Bold = False
                e.Row.Cells(4).Text = " No Response"
            End If
        End If

    End Sub

    'Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.SelectedIndexChanged
    '    GridView1.DataSourceID = "sqlMsg"
    '    GridView1.DataBind()
    'End Sub

    ' TextBox1.Text = Label1.Text.Replace("</br>", vbCrLf)
    'Label1.Text = TextBox1.Text.Replace(vbCrLf, "</br>")

    Sub GetMessage()

        Dim wkQue, wkTime As String
        Dim dataReader1 As IDataReader = cDB.GetDataString("*", "[vMessage]", " [question_no] = 1")
        If dataReader1.Read = True Then
            wkTime = Format(dataReader1("QuestionCreate_dtm"), "ddd dd-MMM-yyyy a\t h:mm tt").ToString
            wkQue = dataReader1("question_desc")
            txtTime.Text = wkTime
            txtQue.Text = wkQue.Replace("</br>", vbCrLf)
            GridView1.DataSourceID = "sqlMsg"
            GridView1.DataBind()
            GetTbl()
        End If
        dataReader1.Close()
        
    End Sub

    Sub GetTbl()
        tbl.Rows.Clear()
        Dim wkAll, wkAll1, wkAll2, wkAll3, wkAll4, wkAll5 As String
        wkAll = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", "")
        wkAll1 = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", " WHERE [answer_no] = 1").ToString
        wkAll2 = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", " WHERE [answer_no] = 2").ToString
        wkAll3 = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", " WHERE [answer_no] = 3").ToString
        wkAll4 = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", " WHERE [answer_no] = 4").ToString
        wkAll5 = cDB.CountRecord(" [tblMessage_Answer] ", " [answer_no] ", " WHERE [answer_no] = 5").ToString

        Dim wkCirAns1, wkCirAns2, wkCirAns3, wkCirAns4, wkCirAns5 As String

        Dim SUM11, SUM12, SUM21, SUM22, SUM31, SUM32, SUM41, SUM42, SUM51, SUM52, SUMRow1, SUMRow2, rowCount As Decimal
        Dim wk1, wk2, wk3, wk4, wk5, SUMRowColumn1, SUMRowColumn2 As Decimal

        SUM11 = 0
        SUM12 = 0
        SUM21 = 0
        SUM22 = 0
        SUM31 = 0
        SUM32 = 0
        SUM41 = 0
        SUM42 = 0
        SUM51 = 0
        SUM52 = 0
        SUMRow1 = 0
        SUMRow2 = 0
        SUMRowColumn1 = 0
        SUMRowColumn2 = 0
        rowCount = 0

        Dim Row1 As New TableRow()
        Row1.BackColor = Color.Snow

        Row1.Cells.Add(New TableCell)
        Row1.Cells(0).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(0).RowSpan = "2"
        Row1.Cells(0).Text = "Circuit"

        Row1.Cells.Add(New TableCell)
        Row1.Cells(1).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(1).ColumnSpan = "2"
        Row1.Cells(1).Text = "Answer 1"

        Row1.Cells.Add(New TableCell)
        Row1.Cells(2).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(2).ColumnSpan = "2"
        Row1.Cells(2).Text = "Answer 2"

        Row1.Cells.Add(New TableCell)
        Row1.Cells(3).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(3).ColumnSpan = "2"
        Row1.Cells(3).Text = "Answer 3"

        Row1.Cells.Add(New TableCell)
        Row1.Cells(4).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(4).ColumnSpan = "2"
        Row1.Cells(4).Text = "Answer 4"
        Row1.Cells.Add(New TableCell)
        Row1.Cells(5).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(5).ColumnSpan = "2"
        Row1.Cells(5).Text = "Answer 5"

        Row1.Cells.Add(New TableCell)
        Row1.Cells(6).HorizontalAlign = HorizontalAlign.Center
        Row1.Cells(6).ColumnSpan = "2"
        Row1.Cells(6).Text = "TOTAL"

        tbl.Rows.Add(Row1)

        Dim Row2 As New TableRow()
        Row2.BackColor = Color.Snow

        Row2.Cells.Add(New TableCell)
        Row2.Cells(0).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(0).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(1).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(1).Text = "(%)"

        Row2.Cells.Add(New TableCell)
        Row2.Cells(2).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(2).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(3).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(3).Text = "(%)"

        Row2.Cells.Add(New TableCell)
        Row2.Cells(4).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(4).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(5).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(5).Text = "(%)"

        Row2.Cells.Add(New TableCell)
        Row2.Cells(6).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(6).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(7).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(7).Text = "(%)"

        Row2.Cells.Add(New TableCell)
        Row2.Cells(8).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(8).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(9).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(9).Text = "(%)"

        Row2.Cells.Add(New TableCell)
        Row2.Cells(10).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(10).Text = "Total"
        Row2.Cells.Add(New TableCell)
        Row2.Cells(11).HorizontalAlign = HorizontalAlign.Center
        Row2.Cells(11).Text = "(%)"

        tbl.Rows.Add(Row2)

        Dim dataReader2 As IDataReader = cDB.GetDataString(" distinct [circuit_id], [circuit_name], count(*) as countTheaterInCir, CASE [circuit_id] WHEN 2 THEN 1 WHEN 1 THEN 2 WHEN 3 THEN 3 WHEN 4 THEN 4 ELSE 5 END AS sortCiecuit ", "[vMessage]", " [question_no] = 1 group by circuit_id, circuit_name order by sortCiecuit")

        While (dataReader2.Read())
            rowCount = rowCount + 1

            Dim detailsRow As New TableRow()
            detailsRow.HorizontalAlign = HorizontalAlign.Center
            wkCirAns1 = cDB.CountRecord(" [vMessage] ", " [answer_no] ", " WHERE [answer_no] = 1 AND [circuit_id] = " + dataReader2("circuit_id").ToString).ToString
            wkCirAns2 = cDB.CountRecord(" [vMessage] ", " [answer_no] ", " WHERE [answer_no] = 2 AND [circuit_id] = " + dataReader2("circuit_id").ToString).ToString
            wkCirAns3 = cDB.CountRecord(" [vMessage] ", " [answer_no] ", " WHERE [answer_no] = 3 AND [circuit_id] = " + dataReader2("circuit_id").ToString).ToString
            wkCirAns4 = cDB.CountRecord(" [vMessage] ", " [answer_no] ", " WHERE [answer_no] = 4 AND [circuit_id] = " + dataReader2("circuit_id").ToString).ToString
            wkCirAns5 = cDB.CountRecord(" [vMessage] ", " [answer_no] ", " WHERE [answer_no] = 5 AND [circuit_id] = " + dataReader2("circuit_id").ToString).ToString



            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(0).HorizontalAlign = HorizontalAlign.Center
            detailsRow.Cells(0).Text = dataReader2("circuit_name").ToString()
            SUMRow1 = 0
            SUMRow2 = 0

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(1).Text = wkCirAns1
            SUM11 = SUM11 + wkCirAns1
            SUMRow1 = SUMRow1 + wkCirAns1

            detailsRow.Cells.Add(New TableCell)
            ' wk1 = ((wkCirAns1 / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)) * 100)
            wk1 = (wkCirAns1 * 100) / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)
            detailsRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(2).Text = wk1.ToString("#,##0.00")
            SUM12 = SUM12 + wk1
            SUMRow2 = SUMRow2 + wk1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(3).Text = wkCirAns2
            SUM21 = SUM21 + wkCirAns2
            SUMRow1 = SUMRow1 + wkCirAns2

            detailsRow.Cells.Add(New TableCell)
            wk2 = (wkCirAns2 * 100) / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)
            detailsRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(4).Text = wk2.ToString("#,##0.00")
            SUM22 = SUM22 + wk2
            SUMRow2 = SUMRow2 + wk2

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(5).Text = wkCirAns3
            SUM31 = SUM31 + wkCirAns3
            SUMRow1 = SUMRow1 + wkCirAns3

            detailsRow.Cells.Add(New TableCell)
            wk3 = (wkCirAns3 * 100) / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)
            detailsRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(6).Text = wk3.ToString("#,##0.00")
            SUM32 = SUM32 + wk3
            SUMRow2 = SUMRow2 + wk3

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(7).Text = wkCirAns4
            SUM41 = SUM41 + wkCirAns4
            SUMRow1 = SUMRow1 + wkCirAns4

            detailsRow.Cells.Add(New TableCell)
            wk4 = (wkCirAns4 * 100) / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)
            detailsRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(8).Text = wk4.ToString("#,##0.00")
            SUM42 = SUM42 + wk4
            SUMRow2 = SUMRow2 + wk4

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(9).Text = wkCirAns5
            SUM51 = SUM51 + wkCirAns5
            SUMRow1 = SUMRow1 + wkCirAns5

            detailsRow.Cells.Add(New TableCell)
            wk5 = (wkCirAns5 * 100) / Convert.ToDecimal(dataReader2("countTheaterInCir").ToString)
            detailsRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(10).Text = wk5.ToString("#,##0.00")
            SUM52 = SUM52 + wk5
            SUMRow2 = SUMRow2 + wk5

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(11).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(11).Text = SUMRow1
            SUMRowColumn1 = SUMRowColumn1 + SUMRow1

            detailsRow.Cells.Add(New TableCell)
            detailsRow.Cells(12).HorizontalAlign = HorizontalAlign.Right
            detailsRow.Cells(12).Text = SUMRow2.ToString("#,##0.00")
            SUMRowColumn2 = SUMRowColumn2 + SUMRow2

            tbl.Rows.Add(detailsRow)

        End While
        dataReader2.Close()

        Dim totalRow As New TableRow()
        totalRow.HorizontalAlign = HorizontalAlign.Center
        totalRow.Font.Bold = True
        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(0).Text = "TOTAL"
        totalRow.Cells(0).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(1).BackColor = Color.AliceBlue
        totalRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(1).Text = SUM11

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(2).BackColor = Color.AliceBlue
        totalRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(2).Text = ((SUM11 * 100) / wkAll).ToString("#,##0.00")

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(3).BackColor = Color.AliceBlue
        totalRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(3).Text = SUM21

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(4).BackColor = Color.AliceBlue
        totalRow.Cells(4).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(4).Text = ((SUM21 * 100) / wkAll).ToString("#,##0.00")

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(5).BackColor = Color.AliceBlue
        totalRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(5).Text = SUM31

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(6).BackColor = Color.AliceBlue
        totalRow.Cells(6).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(6).Text = ((SUM31 * 100) / wkAll).ToString("#,##0.00")

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(7).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(7).Text = SUM41
        totalRow.Cells(7).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(8).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(8).Text = ((SUM41 * 100) / wkAll).ToString("#,##0.00")
        totalRow.Cells(8).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(9).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(9).Text = SUM51
        totalRow.Cells(9).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(10).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(10).Text = ((SUM51 * 100) / wkAll).ToString("#,##0.00")
        totalRow.Cells(10).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(11).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(11).Text = SUMRowColumn1
        totalRow.Cells(11).BackColor = Color.AliceBlue

        totalRow.Cells.Add(New TableCell)
        totalRow.Cells(12).HorizontalAlign = HorizontalAlign.Right
        totalRow.Cells(12).Text = ((SUMRowColumn1 * 100) / wkAll).ToString("#,##0.00")
        totalRow.Cells(12).BackColor = Color.AliceBlue

        tbl.Rows.Add(totalRow)

    End Sub


    Protected Sub btnNewMsg_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNewMsg.Click
        Response.Redirect("frmCTBV_AT_MessageNew.aspx")
    End Sub


End Class
