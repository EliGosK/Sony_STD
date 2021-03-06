<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptSoundFormat_sfd.aspx.vb" Inherits=".frmRptSoundFormat_sfd" %>

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
        <br />
        <br />
        <asp:Table ID="tableReport" runat="server" Width="460px" CellPadding="0" CellSpacing="0" GridLines="Both" Font-Size="9pt" Font-Names="Tahoma" ForeColor="Black">
            <asp:TableHeaderRow Font-Bold="True" Font-Size="13pt" >
                <asp:TableHeaderCell RowSpan="1" ColumnSpan="6" HorizontalAlign="Center" BackColor="#C2D8FE" ForeColor="Black">{0} Box Office By Date & Sound Format</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Bold="True" Font-Size="13pt">
                <asp:TableHeaderCell RowSpan="1" ColumnSpan="6" HorizontalAlign="Center">From Date : {0} To {1}</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Bold="True" Font-Size="9pt">
                <asp:TableHeaderCell Width="200px" RowSpan="2" ColumnSpan="2" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Showing Date</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="260px" RowSpan="1" ColumnSpan="4" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Bold="True" Font-Size="9pt">
                <asp:TableHeaderCell Width="80px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">%</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableFooterRow Font-Bold="True" Font-Size="9pt" >
                <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" BackColor="Silver">Total</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </form>
</body>
</html>
