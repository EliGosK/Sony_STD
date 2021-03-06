<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevenueMonitor.aspx.vb"
    Inherits=".frmRevenueMonitor" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/popUpCal.ascx" TagName="popUpCal" TagPrefix="uc2" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>
<%@ Register Src="../Controls/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <title>SDT MIS : Box Office</title>
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
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
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
                    &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; Box Office</b>
                </td>
            </tr>
            <tr>
                <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                    <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                        bgcolor="#f0cd8c">
                        <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                            <td height="27" background="">
                                <div align="center" class="style1">
                                    Box Office</div>
                            </td>
                        </tr>
                        <tr bordercolor="#999999" bgcolor="#ffffff">
                            <td height="78" align="center" bgcolor="#E2E2E2">
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr width="100%">
                                                    <td width="100%" align="left">
                                                        <table style="font-family: Tahoma; font-size: 10pt; font-weight: bold;">
                                                            <tr>
                                                                <td align="right" valign="middle">
                                                                    Start Date :
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <uc1:DatePicker ID="dtpStartDate" runat="server"></uc1:DatePicker>
                                                                    <%--<asp:TextBox ID="txtDateStart" onblur="ValidDate2()" runat="server" Columns="25"
                                                                        Font-Bold="True" ForeColor="Black" Width="125px"></asp:TextBox>--%>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    End Date :
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <uc1:DatePicker ID="dtpEnddate" runat="server"></uc1:DatePicker>
                                                                    <%--<asp:TextBox ID="txtDateStop" onblur="ValidDate2()" runat="server" Columns="25" Font-Bold="True"
                                                                        ForeColor="Black" Width="125px"></asp:TextBox>--%>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    Title :
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:TextBox ID="txtMovies" runat="server" Columns="20" Font-Bold="True" Width="119px"></asp:TextBox>
                                                                </td>
                                                                <td align="right" valign="middle">
                                                                    Status :
                                                                </td>
                                                                <td valign="middle" align="left">
                                                                    <asp:DropDownList ID="ddlStatus" runat="server">
                                                                        <asp:ListItem Value="1">-Showing-</asp:ListItem>
                                                                        <asp:ListItem Value="2">-Terminated-</asp:ListItem>
                                                                        <%--<asp:ListItem Value="null">- All-</asp:ListItem>--%>
                                                                        <asp:ListItem Value="0">- All-</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <td valign="middle" align="left">
                                                                        <td>
                                                                            <asp:Button ID="btnSearch" runat="server" Text="Search" Height="22px" />
                                                                        </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%" id="tblExport" runat="server">
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Label ID="lblError" runat="server" Font-Size="8pt" Font-Bold="True" ForeColor="Red"
                                                                        Visible="False"></asp:Label>
                                                                    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" Width="165px" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView ID="grdBoxOffice" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CellPadding="4" DataSourceID="sqlBoxOffice" Font-Names="Tahoma" Font-Size="Small"
                                                                        ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="true">
                                                                        <FooterStyle BackColor="#CCCCCC" Font-Bold="True" ForeColor="#003366" BorderColor="#336699"
                                                                            BorderStyle="Solid" BorderWidth="2px" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                        <Columns>
                                                                            <asp:HyperLinkField Visible="false" DataNavigateUrlFields="movie_id" DataNavigateUrlFormatString="frmrevbyMovie.aspx?movieId={0}"
                                                                                DataTextField="movie_code" HeaderText="Title Code" SortExpression="movie_code">
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataNavigateUrlFields="movie_id" DataNavigateUrlFormatString="frmrevbyMovie.aspx?movieId={0}"
                                                                                DataTextField="MoviesName" HeaderText="Title" SortExpression="MoviesName">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:BoundField DataField="distributor_name" HeaderText="Distr" SortExpression="distributor_name">
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="countWeek" HeaderText="No. Weeks" SortExpression="countWeek"
                                                                                HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:HyperLinkField DataTextField="rev_amount" DataTextFormatString="{0:#,##0}" HeaderText="GBO"
                                                                                SortExpression="rev_amount" HeaderStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="rev_adms" DataTextFormatString="{0:#,##0}" HeaderText="Adms"
                                                                                SortExpression="rev_adms" HeaderStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:BoundField DataField="cntScreen" HeaderText="Screen" SortExpression="cntScreen">
                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:BoundField>
                                                                            <asp:HyperLinkField DataTextField="cntSession" DataTextFormatString="{0:#,##0}" HeaderText="Session"
                                                                                SortExpression="cntSession">
                                                                                <HeaderStyle HorizontalAlign="Right" />
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:HyperLinkField>
                                                                            <asp:HyperLinkField DataTextField="SumRev" DataTextFormatString="{0:#,##0}" HeaderText="Cume GBO"
                                                                                SortExpression="SumRev" HeaderStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                                                                <ItemStyle Font-Bold="True" Font-Italic="False" HorizontalAlign="Right" />
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
    </div>
    <%--<asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>">
        <SelectParameters>
            <asp:SessionParameter Name="revDateEnd" SessionField="revDateEnd" />
            <asp:SessionParameter Name="revDate" SessionField="revDate" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <%--    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="[dbo].[sp_BoxOffice_LoadInfomation]" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="p_movie_name" SessionField="revMovieName" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_movie_status" SessionField="revMovieStatus" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_start_date" SessionField="revDate" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_end_date" SessionField="revDateEnd" ConvertEmptyStringToNull="False" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:SqlDataSource ID="sqlBoxOffice" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="[dbo].[sp_BoxOfficeOfMovie]" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:SessionParameter Name="p_movie_name" SessionField="revMovieName" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_movie_status" SessionField="revMovieStatus" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_start_date" SessionField="revDate" ConvertEmptyStringToNull="False" />
            <asp:SessionParameter Name="p_end_date" SessionField="revDateEnd" ConvertEmptyStringToNull="False" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

