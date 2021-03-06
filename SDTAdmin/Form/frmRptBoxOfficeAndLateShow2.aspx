<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptBoxOfficeAndLateShow2.aspx.vb" Inherits=".frmRptBoxOfficeAndLateShow2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Box Office and Late Show by Theatre</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <link type="text/css" rel="stylesheet" href="../Styles.css" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="btnExport0" runat="server" Width="200px" Text="Export To Excel Format" />
        &nbsp;<asp:Button ID="btnCancel0" runat="server"  Width="100px" Text="Cancel" />
        <br />
        <br />
        <div id="divExport" runat="server" >
        </div>
        <br />
        <div id="divExportTemplate" runat="server">
            <asp:Table ID="tbHeaderTemplate" runat="server" Width="1230px" CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="1px" BorderColor="#DDDDDD" GridLines="Both" Font-Names="Tahoma">
                <asp:TableRow>
                    <asp:TableCell Width="100%" Height="30px" RowSpan="1" ColumnSpan="24" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C2D8FE" ForeColor="Black" Font-Size="13pt" Font-Bold="True">Title : CTBV Checker wage and Late Show by Theatre, Date : Thu 28-Oct-2010 To Wed 03-Nov-2010</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbTheaterTemplate" runat="server" Width="1230px" CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" GridLines="Both" Font-Names="Tahoma">
                <asp:TableRow>
                    <asp:TableCell Width="100%" Height="20px" RowSpan="1" ColumnSpan="24" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#5D7B9D" ForeColor="White" Font-Size="11pt" Font-Bold="True">Esplanade Ratchada</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbCheckerWageTemplate" Width="1230px" runat="server" CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" GridLines="Both" Font-Names="Tahoma">
                <asp:TableRow>
                    <asp:TableCell Width="140px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Theatre & Screen</asp:TableCell>
                    <asp:TableCell Width="140px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Title</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Sound</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 1</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 2</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 3</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 4</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 5</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 6</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 7</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session 8</asp:TableCell> 
                    <asp:TableCell Width="40px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Session</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Wage</asp:TableCell>
                    <asp:TableCell Width="90px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Total</asp:TableCell>
                    <asp:TableCell Width="100px" Height="100%" RowSpan="2" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Checker</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                    <asp:TableCell Width="50px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Baht</asp:TableCell>
                    <asp:TableCell Width="40px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#CADCEF" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Adms</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Width="100%" Height="100%" RowSpan="1" ColumnSpan="24" HorizontalAlign="Left" VerticalAlign="Top" BackColor="LightYellow" ForeColor="Red" Font-Size="8pt" Font-Bold="True">28-Oct-10</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Esplanade Ratchada 1</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Eat Pray Love</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">35/E</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">0</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">0</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">1,200</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">3</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">2,400</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">6</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">1,600</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">4</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">4</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">150</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">5,200</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">13</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Blue" Font-Size="8pt" Font-Bold="True">ทศพล ปันนะ</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">[P1]</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell RowSpan="1" ColumnSpan="21" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Red" Font-Size="8pt" Font-Bold="True"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Red" Font-Size="8pt" Font-Bold="True">5,200</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Red" Font-Size="8pt" Font-Bold="True">13</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Red" Font-Size="8pt" Font-Bold="True"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbLateShowTemplate" runat="server" Width="560px" CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" GridLines="Both" Font-Names="Tahoma">
                <asp:TableRow>
                    <asp:TableCell Width="140px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Date</asp:TableCell>
                    <asp:TableCell Width="140px" Height="100%" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Late Show</asp:TableCell>
                    <asp:TableCell Width="200px" Height="100%" RowSpan="1" ColumnSpan="5" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Title</asp:TableCell>
                    <asp:TableCell Width="80px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Expense</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">28-Oct-2010</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">23:30</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="5" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="False">Eat Pray Love</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">200</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top" BackColor="#CADCEF" ForeColor="Red" Font-Size="8pt" Font-Bold="True"></asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="5" HorizontalAlign="Left" VerticalAlign="Top" BackColor="#CADCEF" ForeColor="Red" Font-Size="8pt" Font-Bold="True">Eat Pray Love</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Right" VerticalAlign="Top" BackColor="#CADCEF" ForeColor="Red" Font-Size="8pt" Font-Bold="True">200</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top" BackColor="#ACCCED" ForeColor="Red" Font-Size="8pt" Font-Bold="True">Total</asp:TableCell>
                    <asp:TableCell RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="#ACCCED" ForeColor="Red" Font-Size="8pt" Font-Bold="True">200</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Table ID="tbSummaryTemplate" runat="server" Width="560px" CellPadding="0" CellSpacing="0" BorderStyle="Solid" BorderWidth="1px" BorderColor="Gray" GridLines="Both" Font-Names="Tahoma">
                <asp:TableRow>
                    <asp:TableCell Width="280px" Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Title</asp:TableCell>
                    <asp:TableCell Width="280px" Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Center" VerticalAlign="NotSet" BackColor="#C3CAD6" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Amount (Baht)</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Left" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Eat Pray Love</asp:TableCell>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">150</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top" BackColor="#CADCEF" ForeColor="Red" Font-Size="8pt" Font-Bold="True">Total (Baht)</asp:TableCell>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="#CADCEF" ForeColor="Red" Font-Size="8pt" Font-Bold="True">150</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" VerticalAlign="Top" BackColor="#ACCCED" ForeColor="Red" Font-Size="8pt" Font-Bold="True">Grand Total (Wage + Late Show)</asp:TableCell>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="#ACCCED" ForeColor="Red" Font-Size="8pt" Font-Bold="True">350</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Former Wage</asp:TableCell>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">270/180/130/50/50</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="2" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">Present Wage</asp:TableCell>
                    <asp:TableCell Height="100%" RowSpan="1" ColumnSpan="7" HorizontalAlign="Right" VerticalAlign="Top" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">320/200/150/50/50</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell Height="30px" RowSpan="1" ColumnSpan="9" HorizontalAlign="Right" VerticalAlign="Bottom" BackColor="White" ForeColor="Black" Font-Size="8pt" Font-Bold="True">____________________ทศพล ปันนะ</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>        
    </div>
    </form>
</body>
</html>
