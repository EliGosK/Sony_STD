<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptSoundFormat_sft.aspx.vb" Inherits=".frmRptSoundFormat_sft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <font face="Tahoma" color="rosybrown" size="1">
        <br />
        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
        &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
        <br />
        <br />
        <asp:Table ID="tableReport" runat="server" Width="480px" GridLines="Both" CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">
            <asp:TableHeaderRow ID="TableHeaderRow1" runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" ColumnSpan="5" ForeColor="Black" BackColor="#C2D8FE">{0} Box Office By Theatre & Sound Format
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow ID="TableHeaderRow2" runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" ColumnSpan="5">From Date : {0} To {1}</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow ID="TableHeaderRow3" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell ID="TableHeaderCell3" runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">Theatre</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell4" runat="server" Width="280px" ColumnSpan="4" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow ID="TableHeaderRow4" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell ID="TableHeaderCell5" runat="server" Width="100px" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell6" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell7" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
                <asp:TableHeaderCell ID="TableHeaderCell8" runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">%</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableFooterRow ID="TableFooterRow1" runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell4" runat="server" BackColor="Silver">Total</asp:TableCell>
                <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
                <asp:TableCell ID="TableCell6" runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
                <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </form>
</body>
</html>
