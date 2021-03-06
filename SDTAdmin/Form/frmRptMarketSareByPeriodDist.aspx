<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSareByPeriodDist.aspx.vb" Inherits=".frmRptMarketSareByPeriodDist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">

A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
    </style>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
  
		        <br />
        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format"  />
&nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
                <br />
                <br />
                <asp:Panel ID="panel1" Width="800px" HorizontalAlign="Center"  runat="server" >
                <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" Width="800px" 
        CellSpacing="0" ForeColor="Black" >
                    <asp:TableRow  runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell  runat="server" ColumnSpan="6">INDUSTRY MARKET SHARE BY DISTRIBUTOR
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow  runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="11pt" HorizontalAlign="Center" >
                        <asp:TableCell  runat="server" ColumnSpan="6">From Date :</asp:TableCell>
                    </asp:TableRow>
                    </asp:Table>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowFooter="false"
                        AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="0px" CellPadding="4" CellSpacing="0" 
                        DataSourceID="sqlMsg" EnableSortingAndPagingCallbacks="True" 
                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"  
                        Width="800px">
                        <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%> 
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                          <%--  <asp:BoundField DataField="distributor_name" HeaderStyle-HorizontalAlign="Center" 
                                HeaderText="DISTRIBUTOR" ItemStyle-HorizontalAlign="Right" 
                                ItemStyle-Width="21%" SortExpression="distributor_name">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>--%>
                            
                             <asp:HyperLinkField DataTextField="distributor_name" DataNavigateUrlFields="distributor_id" HeaderStyle-BackColor="#5D7B9D" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#ffffff" 
                                HeaderText="DISTRIBUTOR" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="21%" SortExpression="distributor_name"
                                 DataNavigateUrlFormatString="frmRptMarketSareByPeriodDistMovie.aspx?distid={0}" 
                                 />
                            
                            <asp:BoundField DataField="BOGross" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="B.O.Gross" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20%" 
                                SortExpression="BOGross">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADMS" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ADMS" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20%" SortExpression="ADMS">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TitleMovie" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="# Title" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" 
                                SortExpression="TitleMovie">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PercentCTBV" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="%" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="14%" 
                                SortExpression="PercentCTBV">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="14%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ATP" DataformatString="{0:#,##0.00}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ATP" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="14%" SortExpression="ATP">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="14%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:Table ID="tblFoot" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#5D7B9D" 
                        Font-Names="Tahoma" Font-Size="10pt"   Height="28px"
                        Width="800px"  BackColor="#CADCEF" Font-Bold="True" ForeColor="#003366">
                        <asp:TableRow  runat="server" HorizontalAlign="Right">
                            <asp:TableCell ID="c1" Width="21%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c2" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c3" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c4" Width="12%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c5" Width="14%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c6" Width="14%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:GridView ID="GridView2" runat="server" AllowSorting="True" ShowFooter="false"
                        AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="0px" CellPadding="4" CellSpacing="0" 
                        DataSourceID="sqlMsg2" EnableSortingAndPagingCallbacks="True" 
                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"  
                        Width="800px">
                        <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%> 
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <%--<asp:BoundField DataField="distributor_name" HeaderStyle-HorizontalAlign="Center" 
                                HeaderText="DISTRIBUTOR" ItemStyle-HorizontalAlign="Right" 
                                ItemStyle-Width="21%" SortExpression="distributor_name">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>--%>
                            
                            <asp:HyperLinkField DataTextField="distributor_name" DataNavigateUrlFields="distributor_id" HeaderStyle-BackColor="#5D7B9D" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="#ffffff" 
                                HeaderText="DISTRIBUTOR" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-Width="21%" SortExpression="distributor_name"
                                 DataNavigateUrlFormatString="frmRptMarketSareByPeriodDistMovie.aspx?distid={0}" 
                                 />
                            
                            <asp:BoundField DataField="BOGross" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="B.O.Gross" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20%" 
                                SortExpression="BOGross">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADMS" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ADMS" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="20%" SortExpression="ADMS">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TitleMovie" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="# Title" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" 
                                SortExpression="TitleMovie">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PercentCTBV" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="%" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="14%" 
                                SortExpression="PercentCTBV">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="14%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ATP" DataformatString="{0:#,##0.00}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ATP" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="14%" SortExpression="ATP">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="14%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:Table ID="Table1" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#5D7B9D" 
                        Font-Names="Tahoma" Font-Size="10pt"   Height="28px"
                        Width="800px"  BackColor="#CADCEF" Font-Bold="True" ForeColor="#003366">
                        <asp:TableRow ID="TableRow1"  runat="server" HorizontalAlign="Right">
                            <asp:TableCell ID="TableCell1" Width="21%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell2" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell3" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell4" Width="12%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell5" Width="14%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell6" Width="14%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table ID="Table2" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#5D7B9D" 
                        Font-Names="Tahoma" Font-Size="10pt"   Height="28px"
                        Width="800px"  BackColor="#303D50" Font-Bold="True" ForeColor="White">
                        <asp:TableRow ID="TableRow2"  runat="server" HorizontalAlign="Right">
                            <asp:TableCell ID="TableCell7" Width="21%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell8" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell9" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell10" Width="12%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell11" Width="14%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell12" Width="14%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    
                </asp:Panel>
			    <asp:SqlDataSource ID="sqlMsg" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="sqlMsg2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
                </asp:SqlDataSource>
    <br />
                </form>
</body>
</html>