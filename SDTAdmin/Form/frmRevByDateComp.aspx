<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevByDateComp.aspx.vb" Inherits=".frmRevByDateComp" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT: Box Office </title>
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
                    <b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt;<a href="frmRevenueMonitor.aspx"> Box Office
                    </a>&gt; <asp:HyperLink ID="lblMovieId" runat="server" >HyperLink</asp:HyperLink>
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
                                                        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" Width="165px" />
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
                                                                <asp:BoundField DataField="theater_code" HeaderText="Theatre Code" SortExpression="theater_code">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="Theatre" SortExpression="theater_name">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="lnkTheaterName" runat="server"><%#Eval("theater_name")%></asp:HyperLink>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:TemplateField>
                                                                <%--<asp:HyperLinkField DataNavigateUrlFields="theater_Id" DataNavigateUrlFormatString="frmRevByTheaterComp.aspx?theaterId={0}"
                                                                    DataTextField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>--%>
                                                                <asp:HyperLinkField DataTextField="comprevenue_amountsum" DataTextFormatString="{0:#,##0}"
                                                                    HeaderText="GBO" SortExpression="comprevenue_amountsum">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle Font-Bold="True" HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted"
                                                                        BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:HyperLinkField DataTextField="comprevenue_admssum" DataTextFormatString="{0:#,##0}"
                                                                    HeaderText="Adms" SortExpression="comprevenue_admssum">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                                <asp:BoundField DataField="comprevenue_screensum" HeaderText="Screen" SortExpression="comprevenue_screensum">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="comprevenue_timesum" DataTextFormatString="{0:#,##0}"
                                                                    HeaderText="Session" SortExpression="comprevenue_timesum">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>
                                                               <%--<asp:HyperLinkField DataTextField="opc" DataTextFormatString="{0:#,##0}" HeaderText="OPC (%)"
                                                                    SortExpression="opc">
                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:HyperLinkField>--%>
                                                                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                                                                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="user_name" HeaderText="Checker" SortExpression="user_name">
                                                                    <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                                                </asp:BoundField>
                                                                <asp:HyperLinkField DataTextField="comprevenue_lastupdate" DataTextFormatString="{0:dd-MMM-yyyy HH:mm}" 
                                                                    HeaderText="Latest Update" SortExpression="comprevenue_lastupdate">
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
                                <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <%--<asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        
        SelectCommand="SELECT tblCompRevenue.comprevenue_amountsum, tblCompRevenue.comprevenue_admssum, tblCompRevenue.comprevenue_timesum, tblCompRevenue.comprevenue_screensum, tblRevStatus.statusColor, tblRevStatus.status, tblCompRevenue.comprevenue_lastupdate, tblRelease.theater_id, tblUser.user_name, tblTheater.theater_name, tblTheater.theater_code, tblRelease.movies_id AS opc FROM (SELECT onrelease_id, onrelease_status, onrelease_startdate, onrelease_enddate, movies_id, theater_id FROM tblRelease AS tblRelease_1 WHERE (movies_id = @movId) AND (onrelease_enddate &gt;= @revDate OR onrelease_enddate IS NULL)) AS tblRelease LEFT OUTER JOIN (SELECT comprevenue_id, comprevenue_amountsum, comprevenue_amountth, comprevenue_amountor, comprevenue_admssum, comprevenue_admsth, comprevenue_admsor, comprevenue_timesum, comprevenue_timeor, comprevenue_timeth, comprevenue_screensum, comprevenue_screenth, comprevenue_screenor, comprevenue_date, comprevenue_lastupdate, theater_id, movies_id, status_id, user_id FROM tblCompRevenue AS tblCompRevenue_1 WHERE (comprevenue_date = @revDate)) AS tblCompRevenue ON tblRelease.theater_id = tblCompRevenue.theater_id AND tblRelease.movies_id = tblCompRevenue.movies_id LEFT OUTER JOIN tblTheater ON tblRelease.theater_id = tblTheater.theater_id LEFT OUTER JOIN tblUser ON tblCompRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblRevStatus ON tblCompRevenue.status_id = tblRevStatus.status_id ORDER BY tblRevStatus.status, tblTheater.theater_name">
        <SelectParameters>
            <asp:SessionParameter Name="movId" SessionField="movieId" />
            <asp:SessionParameter Name="revDate" SessionField="revDate" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="select RL.movies_id as movie_id
    , RCH.revenue_date
    , RL.theater_id
    , T.theater_code
    , T.theater_name
    , RCH.revenue_comp_header_id
    , RCH.count_revenue_id
    , RCH.all_amount as comprevenue_amountsum
    , RCH.all_adms as comprevenue_admssum
    , RCH.all_screen as comprevenue_screensum
    , RCH.all_session as comprevenue_timesum
    , RCH.update_date as comprevenue_lastupdate
    , RS.statusColor
    , RS.status
    , U.user_name
    , 0 as opc
from (
    select onrelease_id
        , onrelease_status
        , onrelease_startdate
        , onrelease_enddate
        , movies_id
        , theater_id 
    from tblRelease 
    where (movies_id = @movId) 
    and (onrelease_status &lt;&gt; '3')
    and (onrelease_enddate &gt;= @revDate or onrelease_enddate is null)
    ) AS RL
    left outer join (
    select RCH.revenue_comp_header_id
        , RCH.movie_id
        , RCH.revenue_date
        , RCH.theater_id
        , RCH.all_amount
        , RCH.all_adms
        , RCH.all_screen
        , RCH.all_session
        , RCH.status_id
        , RCH.update_by
        , RCH.update_date
        , count(RCD.revenue_comp_header_id) as count_revenue_id
        , sum(RCD.amount) as count_amount
        , sum(RCD.adms) as count_adms
        , sum(RCD.count_screen) as count_screen
        , sum(RCD.count_session) as count_session
    from tblRevenueCompHeader RCH
        left join tblRevenueCompDetail RCD
        on RCD.revenue_comp_header_id = RCH.revenue_comp_header_id
    where (RCH.movie_id = @movId)
        and (RCH.revenue_date = @revDate)
    group by RCH.revenue_comp_header_id
        , RCH.revenue_date
        , RCH.movie_id
        , RCH.theater_id
        , RCH.all_amount
        , RCH.all_adms
        , RCH.all_screen
        , RCH.all_session
        , RCH.status_id
        , RCH.update_by
        , RCH.update_date
    ) as RCH 
    on RL.theater_id = RCH.theater_id 
    and RL.movies_id = RCH.movie_id 
    left outer join tblTheater T
    on RL.theater_id = T.theater_id 
    left outer join tblUser U
    on RCH.update_by = U.user_id 
    left outer join tblRevStatus RS
    --on RCH.status_id = RS.status_id 
    ON CASE WHEN RL.onrelease_status = 1 AND RCH.status_id = 1 THEN 2 ELSE RCH.status_id END = RS.status_id
order by RS.status
    , T.theater_name">
        <SelectParameters>
            <asp:SessionParameter Name="movId" SessionField="movieId" />
            <asp:SessionParameter Name="revDate" SessionField="revDate" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>
