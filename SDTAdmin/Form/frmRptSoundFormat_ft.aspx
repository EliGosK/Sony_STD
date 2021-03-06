<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptSoundFormat_ft.aspx.vb" Inherits=".frmRptSoundFormat_ft" %>

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
        <%--<asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Width="801px">
            <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell1" runat="server" ForeColor="Black" BackColor="#C2D8FE" ColumnSpan="11">MOVIE Box Office BY SOUND AND FILM FORMAT
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" ColumnSpan="11">Date :</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">Theatre</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">Film 35 mm.</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">Digital</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">Digital 3D</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">Film 70 mm.</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
            </asp:TableRow>
        </asp:Table>--%>
        <asp:Table ID="tableReport" runat="server" Width="400px" GridLines="Both" CellPadding="0" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" ColumnSpan="10" ForeColor="Black" BackColor="#C2D8FE">MOVIE Box Office BY SOUND AND FILM FORMAT
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" ColumnSpan="10">Date :</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">Theatre</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="200px" ColumnSpan="3" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" Width="80px" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="60px" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableFooterRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" BackColor="Silver">Total</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="Silver"></asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </form>
</body>
</html>
