<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_MonitorStatus.aspx.vb"
    Inherits=".frmCTBV_AT_MonitorStatus" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Information System - Monitor Status</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:visited
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:hover
        {
            color: #cccccc;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:active
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
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
        .style29
        {
            text-align: left;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_AT_Main.aspx">
                    &nbsp;Admin Tools</a> &gt; </b><strong>Data Submission Update</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="">
                            <div align="center" class="style1">
                                <strong>Data Submission Update</strong></div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td valign="top">
                                        <table style="font-family: Tahoma; font-size: 10pt; font-weight: bold; margin-left: 0px;
                                            height: 44px;" border="0" cellspacing="0" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr valign="top">
                                    <td align="right" valign="top">
                                        Title :
                                    </td>
                                    <td bordercolor="#DADADA" class="style29">
                                        <asp:DropDownList ID="ddlMovies" runat="server" Style="margin-left: 0px" AppendDataBoundItems="True"
                                            DataSourceID="sqlMovies" DataTextField="movieName" DataValueField="movie_id">
                                            <asp:ListItem Value="0">---------All---------</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" valign="top">
                                        Theatre :
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="ddlTheater" runat="server" DataSourceID="sqlTheater" DataTextField="theater_name"
                                            DataValueField="theater_id" AppendDataBoundItems="True">
                                            <asp:ListItem Value="0">---------All---------</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" valign="top">
                                        Checker :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;">
                            CTBV&#39;s Title (s)
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f0cd8c">
                            <div align="center" class="style1">
                                <asp:GridView ID="grdBoxOffice" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    DataSourceID="sqlBoxOffice" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333"
                                    GridLines="None" Width="100%" AllowSorting="True" ShowFooter="True">
                                    <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Bold="False" />
                                    <Columns>
                                        <asp:HyperLinkField DataTextField="revenue_date" DataTextFormatString="{0:dd-MMM-yyyy}"
                                            HeaderText="Date" SortExpression="revenue_date" />
                                        <asp:HyperLinkField DataTextField="moviesName" HeaderText="Title" SortExpression="moviesName">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField DataTextField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:HyperLinkField>
                                        <asp:BoundField DataField="TheaterSub_id" HeaderText="Screen" SortExpression="Screen">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="revenue_Time" HeaderText="Session" SortExpression="revenue_Time">
                                            <HeaderStyle HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                                            <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                        </asp:BoundField>
                                        <asp:HyperLinkField DataTextField="user_name" HeaderText="Checker" SortExpression="user_name">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField DataTextField="revenue_LastUpdate" DataTextFormatString="{0:dd-MMM-yyyy HH:mm}"
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
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f0cd8c" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;">
                            Competitor&#39;s Title (s)
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#f0cd8c">
                            <asp:GridView ID="grdBoxOffice0" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                DataSourceID="sqlBoxCompetitor" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333"
                                GridLines="None" Width="100%" AllowSorting="True" ShowFooter="True">
                                <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#333333" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Bold="False" />
                                <Columns>
                                    <asp:HyperLinkField DataTextField="comprevenue_date" DataTextFormatString="{0:dd-MMM-yyyy}"
                                        HeaderText="Date" SortExpression="comprevenue_date" />
                                    <asp:HyperLinkField DataTextField="MovieName" HeaderText="Title" SortExpression="MovieName">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField DataTextField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                    </asp:HyperLinkField>
                                    <asp:BoundField DataField="comprevenue_screensum" HeaderText="Screen" SortExpression="comprevenue_screensum">
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comprevenue_timesum" HeaderText="Session" SortExpression="comprevenue_timesum">
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status">
                                        <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" />
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataTextField="user_name" HeaderText="Checker" SortExpression="user_name">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:HyperLinkField>
                                    <asp:HyperLinkField DataTextField="comprevenue_lastupdate" DataTextFormatString="{0:dd-MMM-yyyy HH:mm}"
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
                <br />
    </table>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT tblRevStatus.status, tblMovie.movie_nameen  AS moviesName, tblTheater.theater_name, tblTheater.theater_code, tblRevenue.revenue_amount, tblRevenue.revenue_date, tblRevenue.revenue_Time, tblRevenue.revenue_LastUpdate, tblUser.user_name, tblRevenue.revenue_adms, tblRevenue.TheaterSub_id FROM tblRevenue LEFT OUTER JOIN tblUser ON tblRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblRevStatus ON tblRevenue.status_id = tblRevStatus.status_id LEFT OUTER JOIN tblMovie ON tblRevenue.movies_id = tblMovie.movie_id LEFT OUTER JOIN tblTheater ON tblRevenue.theater_id = tblTheater.theater_id WHERE (tblRevenue.status_id = 3) AND (tblRevenue.movies_id &lt;&gt; ''and tblRevenue.revenue_date &lt; CONVERT (DATETIME, @sysDatex,101))">
        <SelectParameters>
            <asp:SessionParameter Name="sysDatex" SessionField="revDatex" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT ' - '+ movie_nameth + '/' + movie_nameen AS movieName, movie_code, movie_id FROM tblMovie WHERE (movie_status = '1')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlTheater" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT ' - ' + theater_name as theater_name, theater_id FROM tblTheater">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlBoxCompetitor" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT tblCompRevenue.comprevenue_amountsum, tblCompRevenue.comprevenue_admssum, tblCompRevenue.comprevenue_timesum, tblCompRevenue.comprevenue_screensum, tblCompRevenue.comprevenue_date, tblCompRevenue.comprevenue_lastupdate, tblMovie.movie_nameen  AS MovieName, tblTheater.theater_name, tblUser.user_name, tblRevStatus.status FROM tblCompRevenue LEFT OUTER JOIN tblRevStatus ON tblCompRevenue.status_id = tblRevStatus.status_id LEFT OUTER JOIN tblUser ON tblCompRevenue.user_id = tblUser.user_id LEFT OUTER JOIN tblTheater ON tblCompRevenue.theater_id = tblTheater.theater_id LEFT OUTER JOIN tblMovie ON tblCompRevenue.movies_id = tblMovie.movie_id WHERE (tblCompRevenue.status_id = '3') AND (tblCompRevenue.comprevenue_date &lt; CONVERT (DATETIME, @sysDatex, 101))">
        <SelectParameters>
            <asp:SessionParameter Name="sysDatex" SessionField="revDatex" />
        </SelectParameters>
    </asp:SqlDataSource>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

