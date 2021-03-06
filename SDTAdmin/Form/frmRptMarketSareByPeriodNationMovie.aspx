<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSareByPeriodNationMovie.aspx.vb" Inherits=".frmRptMarketSareByPeriodNationMovie" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">


A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
    </style>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
  
		        <br />
        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format"  />
&nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
                <br />
                <br />
                <asp:Panel ID="panel1" Width="800px" HorizontalAlign="Center"  runat="server" >
                <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" Width="800px" 
        CellSpacing="0" ForeColor="Black" >
                    <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="7">INDUSTRY MARKET SHARE BY NATIONALITY
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="11pt" HorizontalAlign="Center" >
                        <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="7">From Date :</asp:TableCell>
                    </asp:TableRow>
                    </asp:Table>
                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" ShowFooter="false"
                        AutoGenerateColumns="False" BackColor="#FFFFFF" BorderColor="#999999" 
                        BorderStyle="Solid" BorderWidth="0px" CellPadding="4" CellSpacing="0" 
                        DataSourceID="sqlMsg" EnableSortingAndPagingCallbacks="True" 
                        Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"  
                        Width="800px"> 
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                             <asp:BoundField DataField="movie_strdate" HeaderStyle-HorizontalAlign="Center" 
                                HeaderText="Release Date" ItemStyle-HorizontalAlign="Center"  HtmlEncode="False"  DataFormatString="{0:dd-MMM-yyyy}"  
                                ItemStyle-Width="17%" SortExpression="movie_strdate">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <ItemStyle HorizontalAlign="Center" Width="17%" />
                            </asp:BoundField> 
                            <asp:BoundField DataField="movie_name" HeaderStyle-HorizontalAlign="Center" 
                                HeaderText="Title" ItemStyle-HorizontalAlign="Left" 
                                ItemStyle-Width="20%" SortExpression="movie_name">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BOGross" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="B.O.Gross" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="13%" 
                                SortExpression="BOGross">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="13%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADMS" DataformatString="{0:#,##0}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ADMS" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="12%" SortExpression="ADMS">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PercentNation" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="% by Nationality" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" 
                                SortExpression="PercentNation">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <ItemStyle HorizontalAlign="Right" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PercentIndustry" DataformatString="{0:#,##0.00} %" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="% by Industry" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%" 
                                SortExpression="PercentIndustry">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" /> 
                                <ItemStyle HorizontalAlign="Right" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ATP" DataformatString="{0:#,##0.00}" 
                                HeaderStyle-HorizontalAlign="Center" HeaderText="ATP" HTMLEncode="False" 
                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" SortExpression="ATP">
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Center" />
                                <ControlStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <%--<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />--%>
                                <ItemStyle HorizontalAlign="Right" Width="10%" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                    <asp:Table ID="tblFoot" runat="server" CellPadding="0" CellSpacing="0" BorderColor="#5D7B9D" 
                        Font-Names="Tahoma" Font-Size="10pt"   Height="28px"
                        Width="800px"  BackColor="#5D7B9D" Font-Bold="True" ForeColor="White">
                        <asp:TableRow ID="tblF" runat="server" HorizontalAlign="Right">
                            <asp:TableCell ID="c1" ColumnSpan="2" Width="25%" runat="server" HorizontalAlign="Center" >
                            </asp:TableCell>
                            <asp:TableCell ID="c2" Width="25%" runat="server" HorizontalAlign="Right" >
                            </asp:TableCell>
                            <asp:TableCell ID="c3" Width="10%" runat="server" HorizontalAlign="Right" >
                            </asp:TableCell>
                            <asp:TableCell ID="c4" Width="15%" runat="server" HorizontalAlign="Right" >
                            </asp:TableCell>
                            <asp:TableCell ID="c5" Width="15%" runat="server" HorizontalAlign="Right" >
                            </asp:TableCell>
                            <asp:TableCell ID="c6" Width="10%" runat="server" HorizontalAlign="Right" >
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:Panel>
			    <asp:SqlDataSource ID="sqlMsg" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>" 
                    SelectCommand="SELECT SUM(tblRevenue_1.revenue_amount) AS BOGross, SUM(tblRevenue_1.revenue_adms) AS ADMS, COUNT(tblMovie_1.movie_id) AS TitleMovie, SUM(tblRevenue_1.revenue_amount) / SUM(tblRevenue_1.revenue_adms) AS ATP, tblMovie_1.movie_national, SUM(tblRevenue_1.revenue_amount) * 100 / (SELECT SUM(tblRevenue.revenue_amount) AS totalBoGross FROM tblMovie LEFT OUTER JOIN tblRevenue ON tblMovie.movie_id = tblRevenue.movies_id) AS PercentCTBV FROM tblMovie AS tblMovie_1 RIGHT OUTER JOIN tblRevenue AS tblRevenue_1 ON tblMovie_1.movie_id = tblRevenue_1.movies_id GROUP BY tblMovie_1.movie_national">
                </asp:SqlDataSource>

    <br />
                </form>
</body>
</html>