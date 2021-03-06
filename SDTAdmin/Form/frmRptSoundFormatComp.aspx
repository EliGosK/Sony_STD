<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptSoundFormatComp.aspx.vb" Inherits=".frmRptSoundFormatComp" %>

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
    <%--<br />
    <br />
    <asp:Panel ID="panel1" Width="800px" HorizontalAlign="Center" runat="server">
        <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" Width="800px"
            CellSpacing="0" ForeColor="Black" Font-Bold="true">
            <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="3">MOVIE Box Office BY SOUND AND FILM FORMAT
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="11pt" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="3">xxx</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="11pt" HorizontalAlign="Center" BackColor="#DBEEF3">
                <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="3">film type</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="grdBoxOffice" runat="server" AllowSorting="True" AutoGenerateColumns="False"
            CellPadding="4" DataSourceID="sqlBoxOffice" Font-Names="Tahoma" Font-Size="9"
            ForeColor="#333333" GridLines="None" Width="100%" ShowFooter="false">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="revDate" DataTextField="revDate" DataTextFormatString="{0:dd-MMM-yyyy (ddd)}"
                    HeaderText="Showing Date" SortExpression="revDate">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle BorderColor="White" Width="40%" BorderStyle="Dotted" BorderWidth="0px"
                        HorizontalAlign="Center" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField="rev_amount" DataTextFormatString="{0:#,##0}" HeaderText="Box Office"
                    SortExpression="rev_amount">
                    <HeaderStyle HorizontalAlign="Right" Width="30%" />
                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" Font-Bold="True"
                        HorizontalAlign="Right" Width="30%" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataTextField="rev_adms" DataTextFormatString="{0:#,##0}" HeaderText="ADMS"
                    SortExpression="rev_adms">
                    <HeaderStyle HorizontalAlign="Right" Width="30%" />
                    <ItemStyle BorderColor="White" BorderStyle="Dotted" BorderWidth="0px" HorizontalAlign="Right"
                        Width="30%" />
                </asp:HyperLinkField>
            </Columns>
            <PagerStyle BackColor="#284775" Font-Names="Tahoma" Font-Size="X-Small" ForeColor="White"
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Table ID="tblSum" runat="server" GridLines="Both" CellPadding="5" Width="100%"
            CellSpacing="0" BorderWidth="0" ForeColor="White">
            <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Font-Names="tahoma"
                Font-Size="10pt" HorizontalAlign="Center" BackColor="#5D7B9D">
                <asp:TableCell ID="TableCell4" Width="40%" HorizontalAlign="Right" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell5" Width="30%" HorizontalAlign="Right" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell6" Width="30%" HorizontalAlign="Right" runat="server">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <asp:SqlDataSource ID="sqlSoundFormat" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>--%>
    <br />
    <br />
    <asp:Table ID="tableReport" runat="server" Width="800px" GridLines="Both" CellPadding="6" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">
        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" ColumnSpan="4" ForeColor="Black" BackColor="#C2D8FE">{0}
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow2" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" ColumnSpan="4">{0} ({1})</asp:TableHeaderCell>
        </asp:TableHeaderRow>
         <asp:TableRow ID="TableRow5" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell7" runat="server" ColumnSpan="4" ForeColor="Black" BackColor="#DBEEF3">From Date : {0} To {1}</asp:TableCell>
            </asp:TableRow>
        <asp:TableHeaderRow ID="TableHeaderRow3" runat="server" Font-Bold="True" Font-Size="9pt"
            HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Width="320px" BackColor="#5D7B9D" ForeColor="White">Showing Date</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Width="160px" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell5" runat="server" Width="160px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell6" runat="server" Width="160px" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableFooterRow ID="TableFooterRow1" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell8" runat="server" BackColor="#5D7B9D" ForeColor="White">Total</asp:TableCell>
            <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell10" runat="server" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell11" runat="server" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White">0</asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
    <br />
    </form>
</body>
</html>
