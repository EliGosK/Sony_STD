<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptPerWeekendSunday.aspx.vb"
    Inherits=".frmRptPerWeekendSunday" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        .style1
        {
            font-family: "Tahoma";
            font-size: 11px;
        }
    </style>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Font-Size="11px" ForeColor="Black" Font-Names="Tahoma" Width="1000px">
        <asp:TableRow runat="server" Font-Size="1px" ForeColor="White" HorizontalAlign="Center">
            <asp:TableCell  runat="server" ColumnSpan="15" >โคลัมเบีย
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="20px" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="15" Height="25px"   Font-Bold="True"  ForeColor="Black" BackColor="#C2D8FE"  Font-Size="15pt">WEEKEND TRADING REPORT
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="11px" HorizontalAlign="Right">
            <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="2">TERRITORY : THAILAND</asp:TableCell>
            <asp:TableCell ID="TableCell3" runat="server" ColumnSpan="13"># OF DAYS IN WEEKEND : </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="11px" HorizontalAlign="Right">
            <asp:TableCell ID="TableCell4" runat="server" ColumnSpan="15" BackColor="#C3CAD6"  Font-Bold="True" ForeColor="Black" >PERIOD</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="11px" HorizontalAlign="Right">
            <asp:TableCell ID="TableCell5" runat="server" ColumnSpan="15"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow5" runat="server" HorizontalAlign="Center" Font-Bold="True"
            Font-Size="11px">
            <asp:TableCell ID="TableCell6" runat="server" ColumnSpan="2"></asp:TableCell>
            <asp:TableCell ID="TableCell7" runat="server" ColumnSpan="9" 
BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" >Direct Distribution at Key Cities
            </asp:TableCell>
            <asp:TableCell ID="TableCell8" runat="server" ColumnSpan="4"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow6" runat="server" HorizontalAlign="Center" Font-Size="11px" >
            <asp:TableCell ID="TableCell9" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" >Rank</asp:TableCell>
            <asp:TableCell ID="TableCell10" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="200px">Title</asp:TableCell>
            <asp:TableCell ID="TableCell11" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" >Distributor</asp:TableCell>
            <asp:TableCell ID="TableCell12" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" >Week NO.</asp:TableCell>
            <asp:TableCell ID="TableCell13" runat="server" ColumnSpan="3" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" 
                Width="105px">This Weekend</asp:TableCell>
            <asp:TableCell ID="TableCell14" runat="server" ColumnSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" 
                Width="105px">Previous Weekend</asp:TableCell>
            <asp:TableCell ID="TableCell15" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="30px">% change</asp:TableCell>
            <asp:TableCell ID="TableCell16" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="60px">Cumulative GBO</asp:TableCell>
            <asp:TableCell ID="TableCell17" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="110px">Estimated Direct sales Rental</asp:TableCell>
            <asp:TableCell ID="TableCell18" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="100px">Final Flat sales Rental</asp:TableCell>
            <asp:TableCell ID="TableCell19" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White"  Width="130px">Estimated Total Rental Nationwide***</asp:TableCell>
            <asp:TableCell ID="TableCell20" runat="server" RowSpan="2" BackColor="#5D7B9D"  Font-Bold="True" ForeColor="White" >Comment</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow7" runat="server" HorizontalAlign="Center" Font-Size="11px">
            <asp:TableCell ID="TableCell21" runat="server" BackColor="#5D7B9D"  ForeColor="White" >Scrns</asp:TableCell>
            <asp:TableCell ID="TableCell22" runat="server" BackColor="#5D7B9D"   ForeColor="White" >GBO</asp:TableCell>
            <asp:TableCell ID="TableCell25" runat="server" BackColor="#5D7B9D"  ForeColor="White" >Adms</asp:TableCell>
            <asp:TableCell ID="TableCell23" runat="server" BackColor="#5D7B9D"  ForeColor="White" >Scrns</asp:TableCell>
            <asp:TableCell ID="TableCell24" runat="server" BackColor="#5D7B9D"   ForeColor="White" >GBO</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
