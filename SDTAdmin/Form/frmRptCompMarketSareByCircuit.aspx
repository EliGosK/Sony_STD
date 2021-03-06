<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptCompMarketSareByCircuit.aspx.vb" Inherits=".frmRptCompMarketSareByCircuit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <%--<br />
    <br />
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" CellSpacing="0"
        Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Width="965px">
        <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="13pt"
            HorizontalAlign="Center">
            <asp:TableCell runat="server" ColumnSpan="13" BackColor="#C2D8FE">COMPETITOR MARKET SHARE % RANKED BY MULTIPLEX
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell2" runat="server" ColumnSpan="13">Date :</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="11pt"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell3" runat="server" BackColor="#c3cad6" ColumnSpan="13">Title</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" Font-Bold="True" Font-Size="10pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell4" runat="server" BackColor="#c3cad6" ColumnSpan="13">BANGKOK
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell5" runat="server" ForeColor="White" RowSpan="2" BackColor="#5D7B9D">RANKING</asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server" ForeColor="White" RowSpan="2" BackColor="#5D7B9D"
                HorizontalAlign="Center">THEATRE</asp:TableCell>
            <asp:TableCell ID="TableCell7" runat="server" ForeColor="White" ColumnSpan="2" BackColor="#5D7B9D">SOUNDTRACK</asp:TableCell>
            <asp:TableCell ID="TableCell8" ForeColor="White" runat="server" ColumnSpan="2" BackColor="#5D7B9D">THAI DUB</asp:TableCell>
            <asp:TableCell ID="TableCell9" runat="server" ForeColor="White" ColumnSpan="2" BackColor="#5D7B9D">3D</asp:TableCell>
            <asp:TableCell ID="TableCell10" runat="server" ForeColor="White" ColumnSpan="2" BackColor="#5D7B9D">TOTAL</asp:TableCell>
            <asp:TableCell ID="TableCell11" runat="server" ForeColor="White" RowSpan="2" BackColor="#5D7B9D">ATP</asp:TableCell>
            <asp:TableCell ID="TableCell12" runat="server" ForeColor="White" ColumnSpan="1" BackColor="#5D7B9D">B.O. GROSS</asp:TableCell>
            <asp:TableCell ID="TableCell13" runat="server" ForeColor="White" ColumnSpan="1" BackColor="#5D7B9D">ADMISSION</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell14" ForeColor="White" runat="server" BackColor="#5D7B9D">BOX OFFICE</asp:TableCell>
            <asp:TableCell ID="TableCell15" ForeColor="White" runat="server" BackColor="#5D7B9D">ADMS</asp:TableCell>
            <asp:TableCell ID="TableCell16" ForeColor="White" runat="server" BackColor="#5D7B9D">BOX OFFICE</asp:TableCell>
            <asp:TableCell ID="TableCell17" ForeColor="White" runat="server" BackColor="#5D7B9D">ADMS</asp:TableCell>
            <asp:TableCell ID="TableCell18" runat="server" ForeColor="White" BackColor="#5D7B9D">BOX OFFICE</asp:TableCell>
            <asp:TableCell ID="TableCell19" runat="server" ForeColor="White" BackColor="#5D7B9D">ADMS</asp:TableCell>
            <asp:TableCell ID="TableCell20" runat="server" ForeColor="White" BackColor="#5D7B9D">BOX OFFICE</asp:TableCell>
            <asp:TableCell ID="TableCell21" runat="server" ForeColor="White" BackColor="#5D7B9D">ADMS</asp:TableCell>
            <asp:TableCell ID="TableCell22" runat="server" ForeColor="White" BackColor="#5D7B9D">BY BKK</asp:TableCell>
            <asp:TableCell ID="TableCell23" runat="server" ForeColor="White" BackColor="#5D7B9D"
                Visible="false">BY KEY CITY</asp:TableCell>
            <asp:TableCell ID="TableCell24" runat="server" ForeColor="White" BackColor="#5D7B9D">BY BKK</asp:TableCell>
            <asp:TableCell ID="TableCell25" runat="server" ForeColor="White" BackColor="#5D7B9D"
                Visible="false">BY KEY CITY</asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>
    <br />
    <br />
    <asp:Table ID="tbHD" runat="server" Width="600px" GridLines="Both" 
        CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" 
        ForeColor="Black">
        <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" ColumnSpan="7" ForeColor="Black" BackColor="#C2D8FE">COMPETITOR MARKET SHARE % RANKED BY MULTIPLEX
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow2" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" ColumnSpan="7" ForeColor="Black" BackColor="White">From Date : {0} To {1}
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow3" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" ColumnSpan="7" ForeColor="Black" BackColor="White">Title : 
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    
    <asp:Table ID="tbBKK" runat="server" Width="600px" GridLines="Both" 
        CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" 
        ForeColor="Black">
        <asp:TableHeaderRow ID="TableHeaderRow13" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell29" runat="server" ColumnSpan="7" ForeColor="Black"  BackColor="#c3cad6">BANGKOK
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow14" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell30" runat="server" Width="60px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">RANKING</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell31" runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">CIRCUIT</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell43" runat="server" Width="140px" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">TOTAL</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell44" runat="server" Width="40px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">ATP</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell45" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">B.O. GROSS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell46" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">ADMISSION</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow15" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell47" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">BOX OFFICE</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell48" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell49" runat="server" BackColor="#5D7B9D" ForeColor="White">BY BKK</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell50" runat="server" BackColor="#5D7B9D" ForeColor="White">BY BKK</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableFooterRow ID="TableFooterRow4" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Left">
            <asp:TableCell ID="TableCell27" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White"></asp:TableCell>
            <asp:TableCell ID="TableCell28" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White">TOTAL FOR BANGKOK</asp:TableCell>
            <asp:TableCell ID="TableCell29" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell30" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell31" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell32" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
            <asp:TableCell ID="TableCell33" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
    
    <asp:Table ID="tbCM" runat="server" Width="600px" GridLines="Both" 
        CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" 
        ForeColor="Black">
        <asp:TableHeaderRow ID="TableHeaderRow16" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell32" runat="server" ColumnSpan="7" ForeColor="Black"  BackColor="#c3cad6">CHIENG MAI
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow17" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell33" runat="server" Width="60px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">RANKING</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell34" runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">CIRCUIT</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell35" runat="server" Width="140px" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">TOTAL</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell36" runat="server" Width="40px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">ATP</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell37" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">B.O. GROSS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell38" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">ADMISSION</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow18" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell39" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">BOX OFFICE</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell40" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell41" runat="server" BackColor="#5D7B9D" ForeColor="White">BY CM</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell42" runat="server" BackColor="#5D7B9D" ForeColor="White">BY CM</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableFooterRow ID="TableFooterRow3" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Left">
            <asp:TableCell ID="TableCell39" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White"></asp:TableCell>
            <asp:TableCell ID="TableCell40" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White">TOTAL FOR CHIENG MAI</asp:TableCell>
            <asp:TableCell ID="TableCell41" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell42" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell43" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell44" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
            <asp:TableCell ID="TableCell45" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
    
    <asp:Table ID="tbCITY" runat="server" Width="600px" GridLines="Both" 
        CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" 
        ForeColor="Black">
        <asp:TableHeaderRow ID="TableHeaderRow10" runat="server" Font-Bold="True" Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell18" runat="server" ColumnSpan="7" ForeColor="Black"  BackColor="#c3cad6">KEY CITY
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow11" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell19" runat="server" Width="60px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">RANKING</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell20" runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">CIRCUIT</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell21" runat="server" Width="140px" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">TOTAL</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell22" runat="server" Width="40px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">ATP</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell23" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">B.O. GROSS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell24" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">ADMISSION</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableHeaderRow ID="TableHeaderRow12" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
            <asp:TableHeaderCell ID="TableHeaderCell25" runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">BOX OFFICE</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell26" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell27" runat="server" BackColor="#5D7B9D" ForeColor="White">BY KEY CITY</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="TableHeaderCell28" runat="server" BackColor="#5D7B9D" ForeColor="White">BY KEY CITY</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableFooterRow ID="TableFooterRow2" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Left">
            <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White"></asp:TableCell>
            <asp:TableCell ID="TableCell26" runat="server" HorizontalAlign="Center" BackColor="#303D50" ForeColor="White">TOTAL FOR KEY CITY</asp:TableCell>
            <asp:TableCell ID="TableCell34" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell35" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell36" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0</asp:TableCell>
            <asp:TableCell ID="TableCell37" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
            <asp:TableCell ID="TableCell38" runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White">0.00%</asp:TableCell>
        </asp:TableFooterRow>
    </asp:Table>
    
    </form>
</body>
</html>
