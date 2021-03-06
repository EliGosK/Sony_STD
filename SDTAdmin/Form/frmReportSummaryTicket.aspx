<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReportSummaryTicket.aspx.vb"
    Inherits="Form.FrmReportSummaryTicket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Free&nbsp;Ticket&nbsp;Summary/&nbsp;Per&nbsp;CAP&nbsp;Summary&nbsp;/&nbsp;Detail&nbsp;of&nbsp;Ticket&nbsp;Type&nbsp;Report
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExportExportExcel" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
    <asp:HiddenField ID="hdfHeader" runat="server" Visible="False" />
    <asp:HiddenField ID="hdfParam" runat="server" Visible="False" />
    <asp:HiddenField ID="hdfTitle" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="grdData" runat="server" Font-Names="Tahoma" Font-Size="X-Small"
        ForeColor="#333333" Width="100%" ShowFooter="True">
        <FooterStyle Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </form>
</body>
</html>
