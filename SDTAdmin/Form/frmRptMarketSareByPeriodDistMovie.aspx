<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSareByPeriodDistMovie.aspx.vb"
    Inherits=".frmRptMarketSareByPeriodDistMovie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
    </style>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Panel ID="panel1" Width="800px" HorizontalAlign="Center" runat="server">
        <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" Width="800px"
            CellSpacing="0" ForeColor="Black">
            <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="12pt"
                HorizontalAlign="Center" BackColor="#C2D8FE">
                <asp:TableCell runat="server" ColumnSpan="6">INDUSTRY MARKET SHARE BY DISTRIBUTOR
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
                HorizontalAlign="Center">
                <asp:TableCell runat="server" ColumnSpan="6">From Date :</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowFooter="false"
            AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataSourceID="sqlMsg" EnableSortingAndPagingCallbacks="True"
            Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Width="800px">
            <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="movie_strdate" HeaderStyle-HorizontalAlign="Center" HeaderText="Release Date"
                    ItemStyle-HorizontalAlign="Center" DataFormatString="{0:dd-MMM-yyyy}" ItemStyle-Width="20%" HtmlEncode="false" 
                    SortExpression="movie_strdate">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <ItemStyle HorizontalAlign="Center" Width="17%" />
                </asp:BoundField>
                <asp:BoundField DataField="movie_nameen" HeaderStyle-HorizontalAlign="Center" HeaderText="Title"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="29%" SortExpression="movie_nameen">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <ItemStyle HorizontalAlign="Left" Width="23%" />
                </asp:BoundField>
                <asp:BoundField DataField="cntScreen" HeaderText="Screen" SortExpression="cntScreen">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                </asp:BoundField>
                 <asp:BoundField DataField="countWeek" HeaderText="No. Weeks" SortExpression="countWeek">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                </asp:BoundField> 
                <asp:HyperLinkField DataTextField="rev_amount" DataTextFormatString="{0:#,##0}" HeaderText="GBO"
                    SortExpression="rev_amount" HeaderStyle-HorizontalAlign="Right">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField="rev_adms" DataTextFormatString="{0:#,##0}" HeaderText="ADMS"
                    SortExpression="rev_adms" HeaderStyle-HorizontalAlign="Right">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                </asp:HyperLinkField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <PagerStyle BackColor="#284775" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White"
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Table ID="tblFoot" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#5D7B9D"
            Font-Names="Tahoma" Font-Size="10pt" Height="28px" Width="800px" BackColor="#CADCEF"
            Font-Bold="True" ForeColor="#003366">
            <asp:TableRow runat="server" HorizontalAlign="Right">
                <asp:TableCell ID="c1" Width="39%" HorizontalAlign="Center" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c2" Width="15%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c3" Width="15%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c4" Width="15%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c5" Width="16%" runat="server">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:SqlDataSource ID="sqlMsg" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlMsg2" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>
    <br />
    </form>
</body>
</html>