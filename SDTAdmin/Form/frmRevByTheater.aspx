<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByTheater.aspx.vb" Inherits=".frmRevByTheater" %>

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
    <form id="form1" runat="server">
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
                        <asp:HyperLink ID="lblDate" runat="server">HyperLink</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:HyperLink ID="TheaterName" runat="server"><b>Theatre</b></asp:HyperLink>
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
                                                            <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Right" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <asp:HyperLinkField DataNavigateUrlFields="TheaterSub_id" DataNavigateUrlFormatString="frmRevByScrn.aspx?revScreen={0}"
                                                                    DataTextField="TheaterSub_code" HeaderText="Screen Code" SortExpression="TheaterSub_id">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataNavigateUrlFields="TheaterSub_id" DataNavigateUrlFormatString="frmRevByScrn.aspx?revScreen={0}"
                                                                    DataTextField="TheaterSub_name" HeaderText="Screen" SortExpression="TheaterSub_id">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="rev_amount" DataTextFormatString="{0:#,##0}" HeaderText="GBO"
                                                                    SortExpression="rev_amount">
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                                                    <ItemStyle Font-Bold="True" HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted"
                                                                        BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="rev_adms" DataTextFormatString="{0:#,##0}" HeaderText="Adms"
                                                                    SortExpression="rev_adms">
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                
                                                               
                                                                
                                                                <asp:BoundField DataField="mSession" HeaderText="Session" SortExpression="mSession">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                
                                                                 <asp:HyperLinkField DataTextField="opc_real" DataTextFormatString="{0:#,##0.00}" HeaderText="OPC (%)"
                                                                    SortExpression="opc_real">
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                
                                                                <asp:BoundField DataField="user_name" HeaderText="Checker" SortExpression="user_name">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="minStatus" HeaderText="Status" SortExpression="minStatus">
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
                                <br />
                                <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                                <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        
        
        
        SelectCommand="select a.rev_adms, a.rev_amount, a.revenue_date, a.theatersub_id, a.movies_id, 
a.theater_id, a.mSession, a.theatersub_code, a.TheaterSub_name, a.user_name, a.minStatus,
a.LastUpdate, a.opc, ((convert(decimal(20,2), a.rev_adms) / (a.opc * a.mSession)) * 100) as opc_real
from
(
SELECT SUM(isnull(tblRevenue.revenue_adms,0)) AS rev_adms
, SUM(isnull(tblRevenue.revenue_amount,0)) AS rev_amount, tblRevenue.revenue_date, tblRevenue.theatersub_id
, tblRevenue.movies_id, tblRevenue.theater_id, COUNT(tblRevenue.revenueid) AS mSession
, tblTheaterSub.theatersub_code, tblTheater.theater_name + ' : ' + tblTheaterSub.theatersub_name AS TheaterSub_name
, tblUser.user_name, MIN(tblRevStatus.status) AS minStatus, MAX(tblRevenue.revenue_LastUpdate) AS LastUpdate
, tblTheaterSub.theatersub_normalseat as opc
FROM tblRevenue LEFT OUTER JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id 
LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id 
LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id 
LEFT OUTER JOIN tblTheaterSub ON tblRevenue.theatersub_id = tblTheaterSub.theatersub_id 
AND tblRevenue.theater_id = tblTheaterSub.theater_id 
WHERE (tblRevenue.movies_id = @movieId) 
AND (tblRevenue.theater_id = @theaterId) 
AND (convert(varchar(19),tblRevenue.revenue_date,111) = convert(varchar(19), @revDate1,111)) 
GROUP BY tblRevenue.movies_id, tblRevenue.revenue_date, tblRevenue.theater_id, tblRevenue.theatersub_id
, tblTheaterSub.theatersub_code, tblTheaterSub.theatersub_name, tblUser.user_name, tblTheater.theater_name
, tblTheaterSub.theatersub_normalseat
) a
order by a.theatersub_id">
        <SelectParameters>
            <asp:SessionParameter Name="movieId" SessionField="movieId" />
            <asp:SessionParameter Name="theaterId" SessionField="theaterId" />
            <asp:SessionParameter Name="revDate1" SessionField="revDate1" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>