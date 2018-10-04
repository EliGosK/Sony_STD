<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByDate.aspx.vb" Inherits=".frmRevByDate" %>

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
                        Box Office </a>&gt;<asp:HyperLink ID="lblMovieId" runat="server">HyperLink</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:Label ID="lblDate" runat="server" Text="lblDate"></asp:Label>
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
                                                <tr width="100%" align="right">
                                                    <td>
                                                        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" 
                                                            Width="165px" />
                                                    </td>
                                                </tr>
                                                <tr width="100%">
                                                    <td width="100%">
                                                        <asp:GridView ID="grdBoxOffice" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataSourceID="sqlBoxOffice" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333"
                                                            GridLines="None" Width="100%" AllowSorting="True" ShowFooter="True">
                                                            <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Right" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <asp:HyperLinkField DataNavigateUrlFields="theater_id,opc_real"  DataNavigateUrlFormatString="frmRevByTheater.aspx?theaterId={0}&sumopc={1}"
                                                                    DataTextField="theater_code" HeaderText="Theatre Code" SortExpression="theater_code">
                                                                    
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                 
                                                                <asp:HyperLinkField  DataNavigateUrlFields="theater_id,opc_real"  DataNavigateUrlFormatString="frmRevByTheater.aspx?theaterId={0}&sumopc={1}"
                                                                    DataTextField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
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
                                                                <asp:BoundField DataField="Screen" HeaderText="Screen" SortExpression="Screen">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="mSession" HeaderText="Session" SortExpression="mSession">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                
                                                                 <asp:HyperLinkField DataTextField="opc_real" DataTextFormatString="{0:#,##0.00}" HeaderText="OPC (%)"
                                                                    SortExpression="opc_real">
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                
                                                                <asp:BoundField DataField="Expr1" HeaderText="Status" SortExpression="Expr1">
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
                                                          <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                                          SelectCommand="SELECT tblTheater.theater_code, tblTheater.theater_name, 
SUM(isnull(tblRevenue.revenue_adms,0)) AS rev_adms, SUM(isnull(tblRevenue.revenue_amount,0)) AS rev_amount
, tblRevenue.revenue_date, COUNT(DISTINCT tblRevenue.theatersub_id) AS Screen
, COUNT(tblRevenue.revenueid) AS mSession, MIN(tblRevStatus.status) AS Expr1
, MAX(tblRevenue.revenue_LastUpdate) AS LastUpdate
, tblRevenue.theater_id
, tblRevenue.movies_id
, tblTheater.circuit_id AS opc
,((sum(convert(decimal(20,2), isnull(tblRevenue.revenue_adms,1))) / 
(select sum(isnull(opc,1) * isnull(mSession,1))
from
(
	select a.rev_adms, a.mSession, a.movies_id, 
	a.opc,
case when a.rev_adms > 0 and a.opc > 0 and a.mSession > 0 then
 ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100)
else 0 end
 as opc_real
	from
	(
		SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms
		,case when SUM(isnull(r.revenue_adms,0)) > 0 
then COUNT(r.revenueid) else 1 end AS mSession
, r.movies_id
		,case when ts.theatersub_normalseat > 0 then ts.theatersub_normalseat else 1 end as opc
		FROM tblRevenue  r
		LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id 
		LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id 
		AND r.theater_id = ts.theater_id 
		WHERE (r.movies_id = tblRevenue.movies_id) 
		AND (r.theater_id = tblRevenue.theater_id) 
		AND ( r.revenue_date = @revDate) 
		GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat
	) a
)b
group by b.movies_id)
) * 100) as opc_real




,isnull( (select sum(isnull(opc,1) * isnull(mSession,1))
from
(
	select a.rev_adms, a.mSession, a.movies_id, 
	a.opc,
case when a.rev_adms > 0 and a.opc > 0 and a.mSession > 0 then
 ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100)
else 0 end
 as opc_real
	from
	(
		SELECT SUM(isnull(r.revenue_adms,0)) AS rev_adms
		,case when SUM(isnull(r.revenue_adms,0)) > 0 
then COUNT(r.revenueid) else 1 end AS mSession
, r.movies_id
		,case when ts.theatersub_normalseat > 0 then ts.theatersub_normalseat else 1 end as opc
		FROM tblRevenue  r
		LEFT OUTER JOIN tblTheater t ON r.theater_id = t.theater_id 
		LEFT OUTER JOIN tblTheaterSub ts ON r.theatersub_id = ts.theatersub_id 
		AND r.theater_id = ts.theater_id 
		WHERE (r.movies_id = tblRevenue.movies_id) 
		AND (r.theater_id = tblRevenue.theater_id) 
		AND ( r.revenue_date = @revDate) 
		GROUP BY r.movies_id, r.revenue_date, r.theater_id, r.theatersub_id, ts.theatersub_normalseat
	) a
)b
group by b.movies_id),0) as seatAll
FROM 
(
	SELECT revenueid, revenue_adms, revenue_amount, revenue_date, revenue_Time, revenue_LastUpdate
	, revenue_type, theatersub_id, user_id, movie_system, movies_id, theater_id, status_id, sound_type
	, timehour_id, timemin_id 
	FROM tblRevenue AS tblRevenue_1 
	WHERE   (tblRevenue_1.movies_id = @movieId) AND (tblRevenue_1.revenue_date= @revDate) 
) AS tblRevenue 
left join 
(SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id 
FROM tblRelease AS tblRelease_1
WHERE (onrelease_status = '3') AND 
(movies_id = @movieId) 
AND (convert(varchar(19),onrelease_enddate,111) = convert(varchar(19),@revDate,111) OR onrelease_enddate IS NULL)
) AS tblRelease ON tblRelease.theater_id = tblRevenue.theater_id 
Left JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id 
LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id 
 GROUP BY tblRevenue.revenue_date, tblRevenue.theater_id, tblRevenue.movies_id, tblTheater.theater_code
, tblTheater.theater_name, tblTheater.theater_des, tblTheater.circuit_id 
ORDER BY Expr1, tblTheater.theater_name">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="movieId" SessionField="movieId" DefaultValue="1" />
                                                            <asp:SessionParameter Name="revDate" SessionField="revDate1" DefaultValue="20080101" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                                <%--<center><font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font></center>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
  
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>