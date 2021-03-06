<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptOcp.aspx.vb" Inherits=".frmRptOcp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <asp:Table ID="tblMain" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Width="800" BorderColor="#C2D8FE" ForeColor="#C2D8FE">
        <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="1px" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" Height="1px" BackColor="#C2D8FE" runat="server" ColumnSpan="6"> โคลัมเบีย
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow15" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="13pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell33" Height="25px" ForeColor="Black" BackColor="#C2D8FE" runat="server" ColumnSpan="6">Occupancy Report
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" ForeColor="Black" Font-Names="Tahoma"
            Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell2" Height="25px" runat="server" ColumnSpan="6">Occupancy :</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="6" ForeColor="Black" BackColor="#DBEEF3">Date :</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <%--<asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="theater_id" DataSourceID="sqlMovies" Font-Names="Tahoma"
        Font-Size="9pt" ForeColor="#333333" Width="800px" BorderWidth="1">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="theater_name" HeaderText="Theatre" SortExpression="theater_name">
                <ItemStyle HorizontalAlign="Left" Width="230px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="opc" HeaderText="Occupancy (%)" SortExpression="opc" ItemStyle-HorizontalAlign="Right"
                DataFormatString="{0:#,##0.00}" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Right" Width="130px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="AvgScreen" HeaderText="Per Screen<br/>Average" SortExpression="AvgScreen"
                ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Right" Width="130px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="AvgPrint" HeaderText="Per Print<br/>Average" SortExpression="AvgPrint"
                ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Right" Width="130px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="maxScreen" HeaderText="No. of Screen" SortExpression="maxScreen"
                ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="print_qty" HeaderText="No. of Print" SortExpression="print_qty"
                ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" HtmlEncode="false">
                <ItemStyle HorizontalAlign="Right" Width="100px"></ItemStyle>
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>--%>
    <asp:GridView ID="gvOccupancy" runat="server" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="theater_id" DataSourceID="sqlMovies" Font-Names="Tahoma"
        Font-Size="9pt" ForeColor="#333333" Width="800px" BorderWidth="1" 
        ShowFooter="True">
        <Columns>        
            <asp:TemplateField HeaderText="Theatre" SortExpression="theater_name">
                <ItemTemplate>
                    <asp:Label ID="lblTheater" runat="server" Text='<%# Eval("theater_name") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTheaterTotal" runat="server" Text="Total" />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="280px" />
                <ItemStyle HorizontalAlign="Left" />
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Occupancy (%)" SortExpression="opc">
                <ItemTemplate>
                    <asp:Label ID="lblOpc" runat="server" Text='<%# Eval("opc", "{0:#0.00%}") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblOpcTotal" runat="server" Text='<%# String.Format("{0:#0.00%}", IIf(m_intSeatTotal = 0, 0, m_intAdmsTotal / m_intSeatTotal))  %>' />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Per Screen<br/>Average" SortExpression="revenue_screen_avg">
                <ItemTemplate>
                    <asp:Label ID="lblScreenAvg" runat="server" Text='<%# Eval("revenue_screen_avg", "{0:#,##0.00}") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblScreenAvgTotal" runat="server" Text='<%# String.Format("{0:#,##0.00}", IIf(m_intScreenTotal = 0, 0, m_intAmountTotal / m_intScreenTotal)) %>' />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Per Print<br/>Average" SortExpression="revenue_print_avg">
                <ItemTemplate>
                    <asp:Label ID="lblPrintAvg" runat="server" Text='<%# Eval("revenue_print_avg", "{0:#,##0.00}") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblPrintAvgTotal" runat="server" Text='<%# String.Format("{0:#,##0.00}", IIf(m_intPrintTotal = 0, 0, m_intAmountTotal / m_intPrintTotal)) %>' />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No. of Screen" SortExpression="revenue_screen_count">
                <ItemTemplate>
                    <asp:Label ID="lblScreen" runat="server" Text='<%# Eval("revenue_screen_count", "{0:#,##0}") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblScreenTotal" runat="server" Text='<%# String.Format("{0:#,##0}", m_intScreenTotal) %>' />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="No. of Print" SortExpression="print_qty">
                <ItemTemplate>
                    <asp:Label ID="lblPrint" runat="server" Text='<%# Eval("print_qty", "{0:#,##0}") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblPrintTotal" runat="server" Text='<%# String.Format("{0:#,##0}", m_intPrintTotal) %>' />
                </FooterTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
                <FooterStyle HorizontalAlign="Right"/>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <%--<asp:Table ID="tblSum" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        BorderWidth="0" Width="800" BorderColor="Black" ForeColor="Black">
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="216px" runat="server"> 
            TOTAL</asp:TableCell>
            <asp:TableCell ForeColor="White" HorizontalAlign="Right" BackColor="#5D7B9D" Width="128px"
                runat="server">0.00
            </asp:TableCell>
            <asp:TableCell ForeColor="White" HorizontalAlign="Right" BackColor="#5D7B9D" Width="127px"
                runat="server">0.00
            </asp:TableCell>
            <asp:TableCell ForeColor="White" HorizontalAlign="Right" BackColor="#5D7B9D" Width="127px"
                runat="server">0.00
            </asp:TableCell>
            <asp:TableCell ForeColor="White" HorizontalAlign="Right" BackColor="#5D7B9D" Width="98px"
                runat="server">0
            </asp:TableCell>
            <asp:TableCell ForeColor="White" HorizontalAlign="Right" BackColor="#5D7B9D" runat="server">0
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>
    <font face="Tahoma" color="rosybrown" size="1"></font>
    <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>">
    </asp:SqlDataSource>
    </form>
</body>
</html>
