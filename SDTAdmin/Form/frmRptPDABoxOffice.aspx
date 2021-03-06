<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptPDABoxOffice.aspx.vb" Inherits="frmRptPDABoxOffice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PDA Box Office Report</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:visited
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:hover
        {
            color: #cccccc;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:active
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Button ID="btnExport" runat="server" Text="Export To Excel Format" />
        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
        &nbsp;<br /><br />
    </div>
    <div id="divExport" runat="server">
        <asp:Table ID="tbReport" runat="server" Width="740" CellPadding="0" CellSpacing="0" BorderWidth="1px" BorderStyle="Solid" GridLines="Both" Font-Names="tahoma" Font-Size="9pt" BorderColor="Gray" ForeColor="Black">
            <asp:TableRow Font-Size="0pt" Font-Bold="True">
                <asp:TableCell Height="0px" RowSpan="1" ColumnSpan="8" HorizontalAlign="Center" ForeColor="#ffffff">โคลัมเบีย</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="13pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="8" HorizontalAlign="Center" BackColor="#C2D8FE" ForeColor="Black">TITLE..</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="13pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="8" HorizontalAlign="Center" BackColor="#ffffff" ForeColor="Black">DISTRIBUTOR..</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="13pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="8" HorizontalAlign="Center" BackColor="#c3cad6" ForeColor="Black">RELEASE DATE..</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="8pt" Font-Bold="True">
                <asp:TableCell Width="260px" RowSpan="1" ColumnSpan="2" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">SHOWING<br />DATE</asp:TableCell>
                <asp:TableCell Width="40px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">Type</asp:TableCell>
                <asp:TableCell Width="140px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">GROSS<br />Box Office</asp:TableCell>
                <asp:TableCell Width="80px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">ADMS</asp:TableCell>
                <asp:TableCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">NO. OF<br />SCREEN</asp:TableCell>
                <asp:TableCell Width="60px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">NO. OF<br />LOCATION</asp:TableCell>
                <asp:TableCell Width="100px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="#5D7B9D" ForeColor="White">CUMMULATIVE<br />GROSS</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <br />
        <asp:Table ID="tbReportSummary" runat="server" Width="520px" CellPadding="0" CellSpacing="0" BorderWidth="1px" BorderStyle="Solid" BorderColor="Gray" GridLines="Both" Font-Names="tahoma" Font-Size="9pt" ForeColor="Black" >
            <asp:TableRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell Width="140px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">KEY CITIES GBO :</asp:TableCell>
                <asp:TableCell Width="120px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell Width="40px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="White" ForeColor="Black"></asp:TableCell>
                <asp:TableCell Width="140px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">AD/PUB :</asp:TableCell>
                <asp:TableCell Width="80px" RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">FLAT SALES :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="White" ForeColor="Black"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">PRINT COST :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">NATION WIDE GBO :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="White" ForeColor="Black"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">NO.OF PRINT :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">TOTAL ADMS :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="White" ForeColor="Black"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">RENTAL :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow Font-Size="9pt" Font-Bold="True">
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Center" BackColor="White" ForeColor="Black"></asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Left" BackColor="#5D7B9D" ForeColor="White">NET CONTRIBUTION :</asp:TableCell>
                <asp:TableCell RowSpan="1" ColumnSpan="1" HorizontalAlign="Right" BackColor="#5D7B9D" ForeColor="White"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
