<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByMovie.aspx.vb" Inherits=".frmRevByMovie" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT: Box Office</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
    A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .style21
        {
            width: 122px;
            font-size: small;
        }
    </style>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form2" runat="server">
    <div>
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
            bgcolor="#cccccc" id="Table2">
            <tr>
                <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                    <font color="#000099" face="Tahoma" size="2"><strong>
                        <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                    </strong></font>
                </td>
                <td width="47%" align="right" bgcolor="#ffffff" style="height: 23px">
                    <table width="58" border="0">
                        <tr>
                            <td width="52">
                                <a href="frmCTBV_Login.aspx">
                                    <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                Log Out
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr background="../images/BG7.jpg">
                <td height="29" colspan="2" bordercolor="honeydew" background="" class="style16">
                    &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt;<a href="frmRevenueMonitor.aspx">
                        Box Office </a>&nbsp;&gt;
                        <asp:Label ID="lblMoveId" runat="server" Text="lblMovie"></asp:Label>
                    </b>
                </td>
            </tr>
            <tr>
                <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                    <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                        bgcolor="#f0cd8c">
                        <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                            <td height="27" background="">
                                <div align="left" class="style1">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td align="right" class="style21">
                                                Title :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Distributor :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDis" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Genre :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGenre" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Release Date :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr bordercolor="#999999" bgcolor="#ffffff">
                            <td height="78" align="center" bgcolor="#E2E2E2">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr width="100%">
                                                    <td width="100%">
                                                        <asp:GridView ID="grdBoxOffice" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataSourceID="sqlBoxOffice" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333"
                                                            GridLines="None" Width="100%" AllowSorting="True" ShowFooter="True">
                                                            <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#003366" BorderColor="#336699"
                                                                BorderStyle="Solid" BorderWidth="2px" HorizontalAlign="Right" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <%--<asp:HyperLinkField DataNavigateUrlFields="revDate" DataTextField="revDate" HeaderText="Showing Date"
                                                                    DataNavigateUrlFormatString="frmRevByDate.aspx?revDate={0:yyyyMMdd}" DataTextFormatString="{0:dd-MMM-yyyy (ddd)}"  
                                                                    SortExpression="revDate">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>--%>
                                                                <asp:TemplateField HeaderText="Showing Date">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# String.Format("frmRevByDate.aspx?revDate={0:yyyyMMdd}", Eval("revDate")) %>'
                                                                            Text='<%# String.Format("{0:dd-MMM-yyyy (ddd)}", Eval("revDate")) %>'></asp:HyperLink>
                                                                        <asp:Label ID="Label1" runat="server" Font-Italic="True" ForeColor="Red" Text='<%# Eval("holiday_name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:TemplateField>
                                                                <asp:HyperLinkField HeaderText="Release Type">
                                                                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="rev_amount" DataTextFormatString="{0:#,##0}" HeaderText="GBO"
                                                                    SortExpression="rev_amount">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle Font-Bold="True" HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted"
                                                                        BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="rev_adms" DataTextFormatString="{0:#,##0}" HeaderText="Adms"
                                                                    SortExpression="rev_adms">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:BoundField DataField="cntScreen" HeaderText="Screen" SortExpression="cntScreen">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="cntSession" DataTextFormatString="{0:#,##0}" HeaderText="Session"
                                                                    SortExpression="cntSession">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:BoundField DataField="revStatus" HeaderText="Status" SortExpression="revStatus">
                                                                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="LastUpdate" DataTextFormatString="{0:dd-MMM-yyyy HH:mm}" 
                                                                    HeaderText="Latest Update" SortExpression="LastUpdate">
                                                                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White"
                                                                HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                                <%--<center><font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font></center>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <%--<asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT        tblMovie.movie_id,datediff(day,tblMovie.movie_strdate, ISNULL(tblRevenue.revenue_date, 0) + ISNULL(tblCompRevenue.comprevenue_date, 0))as diffDate , ISNULL(SUM(tblCompRevenue.comprevenue_admssum), 0) + ISNULL(SUM(tblRevenue.revenue_adms), 0) AS rev_adms, 
                         ISNULL(SUM(tblRevenue.revenue_amount), 0) + ISNULL(SUM(tblCompRevenue.comprevenue_amountsum), 0) AS rev_amount, 
                         ISNULL(SUM(tblCompRevenue.comprevenue_timesum), 0) + COUNT(tblRevenue.revenueid) AS cntSession, 
                         ISNULL(SUM(tblCompRevenue.comprevenue_screensum), 0) + COUNT(DISTINCT CONVERT(varchar, tblRevenue.TheaterSub_id) + 'A' + CONVERT(varchar, 
                         tblRevenue.theater_id)) AS cntScreen, ISNULL(tblRevenue.revenue_date, 0) + ISNULL(tblCompRevenue.comprevenue_date, 0) AS revDate, 
                         ISNULL(MIN(tblRevStatus.status), '') + ISNULL(MIN(tblRevStatus_1.status), '') AS revStatus,
ISNULL(max(comprevenue_LastUpdate), '') + ISNULL(max(revenue_LastUpdate), '') AS LastUpdate
FROM            tblMovie FULL OUTER JOIN
                         tblRevStatus RIGHT OUTER JOIN
                         tblCompRevenue ON tblRevStatus.status_id = tblCompRevenue.status_id ON tblMovie.movie_id = tblCompRevenue.movies_id FULL OUTER JOIN
                         tblRevenue LEFT OUTER JOIN
                         tblRevStatus AS tblRevStatus_1 ON tblRevenue.status_id = tblRevStatus_1.status_id ON tblMovie.movie_id = tblRevenue.movies_id
WHERE        (tblMovie.movie_id = @movie_id) 
GROUP BY tblMovie.movie_id,datediff(day,tblMovie.movie_strdate, ISNULL(tblRevenue.revenue_date, 0) + ISNULL(tblCompRevenue.comprevenue_date, 0)), ISNULL(tblRevenue.revenue_date, 0) + ISNULL(tblCompRevenue.comprevenue_date, 0)
ORDER BY revDate
">
        <SelectParameters>
            <asp:QueryStringParameter Name="movie_id" QueryStringField="movieId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
<%--    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="select M.movie_id
    , datediff(day, M.movie_strdate, isnull(R.revenue_date, 0) + isnull(RCH.revenue_date, 0)) as diffDate
    , isnull(sum(RCH.all_adms), 0) + isnull(sum(R.revenue_adms), 0) AS rev_adms
    , isnull(sum(RCH.all_amount), 0) + isnull(sum(R.revenue_amount), 0) AS rev_amount
    , isnull(sum(RCH.all_session), 0) + count(R.revenueid) AS cntSession
    , isnull(sum(RCH.all_screen), 0) + count(distinct convert(varchar, R.theatersub_id) + 'A' + convert(varchar, R.theater_id)) AS cntScreen
    , isnull(R.revenue_date, 0) + isnull(RCH.revenue_date, 0) AS revDate
    , isnull(min(RS.status), '') + isnull(min(RS1.status), '') AS revStatus
    , isnull(max(RCH.update_date), '') + isnull(max(R.revenue_LastUpdate), '') AS LastUpdate
    , isnull(max(HLD.holiday_name), '') as holiday_name
from tblMovie M
    full outer join tblRevStatus RS
    right outer join tblRevenueCompHeader RCH
    on RS.status_id = RCH.status_id 
    on M.movie_id = RCH.movie_id 
    full outer join tblRevenue R
    left outer join tblRevStatus RS1
    on R.status_id = RS1.status_id 
    on M.movie_id = R.movies_id
    left join tblHoliday HLD
    on HLD.holiday_date = (isnull(R.revenue_date, 0) + isnull(RCH.revenue_date, 0))
where (M.movie_id = @movie_id) 
group by M.movie_id
    , datediff(day, M.movie_strdate, isnull(R.revenue_date, 0) + isnull(RCH.revenue_date, 0))
    , isnull(R.revenue_date, 0) + isnull(RCH.revenue_date, 0)
order by revDate">--%>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT m.movie_id
	, DATEDIFF(DAY, m.movie_strdate, rv.revDate) AS diffDate
	, rv.rev_adms
	, rv.rev_amount
	, rv.cntSession
	, rv.cntScreen
	, rv.revDate
	, rs.STATUS AS revStatus
	, rv.LastUpdate
	, ISNULL(h.holiday_name, '') AS holiday_name
FROM tblMovie AS m
INNER JOIN (
	SELECT rv.movies_id AS movie_id
		, rv.revenue_date AS revDate
		, SUM(rv.revenue_adms) AS rev_adms
		, SUM(rv.revenue_amount) AS rev_amount
		, COUNT(*) AS cntSession
		, COUNT(DISTINCT CONVERT(VARCHAR, rv.theater_id) + '_' + CONVERT(VARCHAR, rv.theatersub_id)) AS cntScreen
		, MAX(rv.status_id) AS max_status
		, MAX(rv.revenue_LastUpdate) AS LastUpdate
	FROM tblRevenue AS rv
	WHERE rv.movies_id = @movie_id
		OR @movie_id IS NULL
	GROUP BY rv.movies_id
		, rv.revenue_date
	
	UNION
	
	SELECT rvc.movie_id
		, rvc.revenue_date AS revDate
		, SUM(rvc.all_adms) AS rev_adms
		, SUM(rvc.all_amount) AS rev_amount
		, SUM(ISNULL(rvc.all_session, 0)) AS cntSession
		, SUM(ISNULL(rvc.all_screen, 0)) AS cntScreen
		, MAX(rvc.status_id) AS max_status
		, MAX(rvc.update_date) AS LastUpdate
	FROM tblRevenueCompHeader AS rvc
	WHERE rvc.movie_id = @movie_id
		OR @movie_id IS NULL
	GROUP BY rvc.movie_id
		, rvc.revenue_date
	) AS rv
	ON rv.movie_id = m.movie_id
INNER JOIN (
	SELECT rl.movies_id AS movie_id
		, MIN(onrelease_status) AS min_onrelease_status
	FROM tblRelease AS rl
	WHERE rl.movies_id = @movie_id
		OR @movie_id IS NULL
	GROUP BY rl.movies_id
	) AS rl
	ON rl.movie_id = m.movie_id
INNER JOIN tblRevStatus AS rs
	ON rs.status_id = CASE 
			WHEN rv.max_status = 1
				AND rl.min_onrelease_status = 1
				THEN 2
			ELSE rv.max_status
			END
LEFT JOIN tblHoliday AS h
	ON h.holiday_date = rv.revDate
ORDER BY rv.revDate;">
        <SelectParameters>
            <asp:QueryStringParameter Name="movie_id" QueryStringField="movieId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>