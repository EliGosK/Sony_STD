<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSareByPeriodStudioCircuitTheatre.aspx.vb" Inherits=".frmRptMarketSareByPeriodStudioCircuitTheatre" %>
<%@ Import Namespace="System.IO" %>

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
                    <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell  runat="server" ColumnSpan="6">INDUSTRY MARKET SHARE BY STUDIO & CIRCUIT
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="11pt" HorizontalAlign="Center" >
                        <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="6">From Date :</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow  runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="10pt" HorizontalAlign="Left" BackColor="#c3cad6" Height="18px" >
                        <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="6" Height="18px" >BANGKOK</asp:TableCell>
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
                                <asp:BoundField DataField="theater_name" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="THEATRE" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="25%" 
                                SortExpression="theater_name">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BoxOffice" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Right" HeaderText="BOX OFFICE" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="21%" 
                                SortExpression="BoxOffice">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Right" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADMS" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Right" HeaderText="ADMS" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="21%" SortExpression="ADMS">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Right" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NoOfMovie" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Right" HeaderText="NO. OF TITLES" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="21%" 
                                SortExpression="NoOfMovie">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Right" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="PercentByBkk" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="BY BKK" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="21%" 
                                SortExpression="PercentByBkk">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="PercentByKeyCity" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Right" HeaderText="BY KEY CITY" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="21%" 
                                SortExpression="PercentByKeyCity">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Right" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="21%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <%--<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                      HorizontalAlign="Left" />--%>
                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:Table ID="tblFoot" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#CADCEF" 
                        Font-Names="Tahoma" Font-Size="10pt"   Height="28px"
                        Width="800px" Font-Bold="True" BackColor="#303d50" ForeColor="White">
                        <asp:TableRow ID="tblF" runat="server" HorizontalAlign="Right">
                            <asp:TableCell ID="c1" Width="25%" Font-Size="8pt" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c2" Width="20%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c3" Width="21%" runat="server" >
                            </asp:TableCell>
                            <asp:TableCell ID="c4" Width="21%" runat="server" >
                            </asp:TableCell>
                           <%-- <asp:TableCell ID="c5" Width="21%" runat="server" >
                            </asp:TableCell>--%>
                            <asp:TableCell ID="c6" Width="22%" runat="server" >
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    
                    
                    <%--CM --%>
                                        
                </asp:Panel>
			    <asp:SqlDataSource ID="sqlMsg" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                                            
                                            
                                            
        
                                            
                    
                    SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
                </asp:SqlDataSource>

			    <asp:SqlDataSource ID="sqlMsgCM" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                                            
                                            
                                            
        
                                            
                    
                    
                    SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
                </asp:SqlDataSource>

    <br />
                </form>
</body>
</html>