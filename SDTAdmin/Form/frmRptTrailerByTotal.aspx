<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByTotal.aspx.vb"
    Inherits=".frmRptTrailerByTotal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <div id="divExport" runat="server" >
    
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Font-Size="8px" ForeColor="Black" Font-Names="Franklin Gothic Medium" Width="580px"
        BorderColor="#F4F4F4">
        <asp:TableRow ID="TableRow4" Height="1" BorderWidth="0" runat="server" ForeColor="#C2D8FE"
            BorderColor="#C2D8FE" Font-Names="Franklin Gothic Medium" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell5" runat="server" BorderColor="#F4F4F4" BackColor="#C2D8FE"
                Font-Size="1px" ColumnSpan="3">
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Height="25" BorderColor="#F4F4F4"
            BackColor="#C2D8FE" Font-Names="Franklin Gothic Medium" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" runat="server" Font-Size="20px" ColumnSpan="3">TRAILER LIST BY TITLE
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Height="25" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell4" runat="server" Font-Size="14px" ColumnSpan="3">PERIOD :
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Height="25" Font-Names="Tahoma"
            HorizontalAlign="Center">
<%--            <asp:TableCell ID="TableCell6" BackColor="Silver" runat="server" Font-Size="11pt"
                ColumnSpan="1">
            </asp:TableCell>--%>
            <asp:TableCell ID="TableCell2" BackColor="Silver" Width="430px" runat="server" Font-Size="11pt"
                ColumnSpan="2">Trailers
            </asp:TableCell>
            <asp:TableCell ID="TableCell3" BackColor="Silver" HorizontalAlign="Center" runat="server"
                Font-Size="11pt" ColumnSpan="1" Width="150px">Amount
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    </div>
    </form>
</body>
</html>