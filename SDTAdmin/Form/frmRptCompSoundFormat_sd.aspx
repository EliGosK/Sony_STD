<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptCompSoundFormat_sd.aspx.vb" Inherits=".frmRptCompSoundFormat_sd" %>

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
            Font-Names="tahoma" Font-Size="9pt" ForeColor="Black" Width="801px">
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" ForeColor="Black" BackColor="#C2D8FE" ColumnSpan="13">MOVIE Box Office BY SOUND AND FILM FORMAT
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" ColumnSpan="13" ForeColor="Black">Date :</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">Showing Date</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="3" BackColor="#5D7B9D" ForeColor="White">Soundtrack</asp:TableCell>
                <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="3" BackColor="#5D7B9D"
                    ForeColor="White">Thai Dub</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="3" BackColor="#5D7B9D" ForeColor="White">3D</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="3" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" Font-Bold="True" Font-Size="8pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell runat="server" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableCell>
            </asp:TableRow>
        </asp:Table>--%>
        <br />
        <br />
        <asp:Table ID="tbReport" runat="server" Width="400px" CellPadding="0" CellSpacing="0" GridLines="Both" Font-Size="9pt" Font-Names="Tahoma" ForeColor="Black">
            <asp:TableHeaderRow Font-Size="13pt" Font-Bold="True">
                <asp:TableHeaderCell RowSpan="1" ColumnSpan="5" HorizontalAlign="Center" BackColor="#C2D8FE" ForeColor="Black">{0} Box Office By Date & Sound Format</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Size="13pt" Font-Bold="True">
                <asp:TableHeaderCell RowSpan="1" ColumnSpan="5" HorizontalAlign="Center">From Date : {0} To {1}</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Bold="True" Font-Size="9pt" >
                <asp:TableHeaderCell Width="200px" RowSpan="2" ColumnSpan="2" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Showing Date</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="200px" RowSpan="1" ColumnSpan="3" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow Font-Size="9pt" Font-Bold="True">
                <asp:TableHeaderCell Width="80px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Box Office</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableHeaderCell>
                <asp:TableHeaderCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableFooterRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" BackColor="Silver">Total</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="Silver">0</asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
    </form>
</body>
</html>
