<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSareByPeriodAllCircuit.aspx.vb"
    Inherits=".frmRptMarketSareByPeriodAllCircuit" %>

<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <asp:Panel ID="panel1" Width="800px" HorizontalAlign="Center" runat="server">
        &nbsp;<asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" Width="800px"
            CellSpacing="0" ForeColor="Black">
            <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="11pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="6">INDUSTRY MARKET SHARE BY CIRCUIT
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="11pt" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="6">From Date :</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
                Font-Size="10pt" HorizontalAlign="Left" BackColor="#c3cad6" Height="18px">
                <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="6" Height="18px">BANGKOK</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowFooter="false"
            AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataSourceID="sqlMsg" EnableSortingAndPagingCallbacks="True"
            Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Width="800px">
            <Columns>
                <asp:BoundField DataField="circuit_name" HeaderStyle-HorizontalAlign="Center" HeaderText="CIRCUIT"
                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="circuit_name">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="BoxOffice" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BOX OFFICE" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="BoxOffice">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="ADMS" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="ADMS" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="ADMS">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfMovie" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="NO. OF TITLES" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="NoOfMovie">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByBkk" DataFormatString="{0:#,##0.00} %" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BY BKK" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="PercentByBkk">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByKeyCity" DataFormatString="{0:#,##0.00} %" Visible="false"
                    HeaderStyle-HorizontalAlign="Center" HeaderText="BY KEY CITY" HtmlEncode="False"
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="PercentByKeyCity">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
           
            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Table ID="tblFoot" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#CADCEF"
            Font-Names="Tahoma" Font-Size="10pt" Height="28px" Width="800px" BackColor="#CADCEF"
            Font-Bold="True" ForeColor="#003366">
            <asp:TableRow ID="tblF" runat="server" HorizontalAlign="Right">
                <asp:TableCell ID="c1" Width="20%" Font-Size="8pt" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c2" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c3" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c4" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c5" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="c6" Width="20%" runat="server">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <%--CM --%>
        
        <asp:Table ID="tblCM" runat="server" CellPadding="6" Width="800px" CellSpacing="0"
            ForeColor="Black">
            <asp:TableRow runat="server" ID="tblcm111" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
                HorizontalAlign="Left" BackColor="#c3cad6" Height="18px">
                <asp:TableCell runat="server" ColumnSpan="6" Height="18px">CHIENG MAI</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" ShowFooter="false"
            AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataSourceID="sqlMsgCM" EnableSortingAndPagingCallbacks="True"
            Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Width="800px">
            <Columns>
                <asp:BoundField DataField="circuit_name" HeaderStyle-HorizontalAlign="Center" HeaderText="CIRCUIT"
                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="circuit_name">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="BoxOffice" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BOX OFFICE" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="BoxOffice">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="ADMS" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="ADMS" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="ADMS">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfMovie" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="NO. OF TITLES" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="NoOfMovie">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByBkk" DataFormatString="{0:#,##0.00} %" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BY BKK" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="PercentByBkk">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByKeyCity" DataFormatString="{0:#,##0.00} %" Visible="false"
                    HeaderStyle-HorizontalAlign="Center" HeaderText="BY KEY CITY" HtmlEncode="False"
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="PercentByKeyCity">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Table ID="tblFootCM" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#CADCEF"
            Font-Names="Tahoma" Font-Size="10pt" Width="800px" Font-Bold="True">
            <asp:TableRow ID="TableRow5" BackColor="#CADCEF" ForeColor="#003366" runat="server" HorizontalAlign="Right">
                <asp:TableCell ID="TableCell7" Width="20%" runat="server" Height="28px" Font-Size="8pt">
                </asp:TableCell>
                <asp:TableCell ID="TableCell8" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell9" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell10" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell11" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell12" Width="20%" runat="server">
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
                
        <asp:Table ID="tblKeyCity" runat="server" CellPadding="6" Width="800px" CellSpacing="0"
            ForeColor="Black">
            <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"
                HorizontalAlign="Left" BackColor="#c3cad6" Height="18px">
                <asp:TableCell ID="TableCell16" runat="server" ColumnSpan="6" Height="18px">BY KEY CITY</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:GridView ID="GridView3" runat="server" AllowSorting="True" ShowFooter="false"
            AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" BorderStyle="Solid"
            BorderWidth="0px" CellPadding="4" CellSpacing="0" DataSourceID="SqlMsgKeyCity" EnableSortingAndPagingCallbacks="True"
            Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Width="800px">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="circuit_name" HeaderStyle-HorizontalAlign="Center" HeaderText="CIRCUIT"
                    HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="circuit_name">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="BoxOffice" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BOX OFFICE" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="BoxOffice">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="ADMS" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="ADMS" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="ADMS">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="NoOfMovie" DataFormatString="{0:#,##0}" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="NO. OF TITLES" HtmlEncode="False" ItemStyle-HorizontalAlign="Right"
                    ItemStyle-Width="16%" SortExpression="NoOfMovie">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByBkk" DataFormatString="{0:#,##0.00} %" HeaderStyle-HorizontalAlign="Center"
                    HeaderText="BY BKK" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%"
                    SortExpression="PercentByBkk">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
                <asp:BoundField DataField="PercentByKeyCity" DataFormatString="{0:#,##0.00} %" Visible="false"
                    HeaderStyle-HorizontalAlign="Center" HeaderText="BY KEY CITY" HtmlEncode="False"
                    ItemStyle-HorizontalAlign="Right" ItemStyle-Width="16%" SortExpression="PercentByKeyCity">
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                    <ItemStyle HorizontalAlign="Right" Width="16%" />
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Table ID="tblFootKeyCity" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#CADCEF"
            Font-Names="Tahoma" Font-Size="10pt" Width="800px" Font-Bold="True">
            <asp:TableRow ID="TableRow7" BackColor="#CADCEF" ForeColor="#003366" runat="server" HorizontalAlign="Right">
                <asp:TableCell ID="TableCell17" Width="20%" runat="server" Height="28px" Font-Size="8pt">
                </asp:TableCell>
                <asp:TableCell ID="TableCell18" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell19" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell20" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell21" Width="20%" runat="server">
                </asp:TableCell>
                <asp:TableCell ID="TableCell22" Width="20%" runat="server" Visible=false >
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        
        
    </asp:Panel>
    <asp:SqlDataSource ID="sqlMsg" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlMsgCM" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlMsgKeyCity" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
    </asp:SqlDataSource>
    </form>
</body>
</html>
