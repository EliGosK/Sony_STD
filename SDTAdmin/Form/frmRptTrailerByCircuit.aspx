<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByCircuit.aspx.vb"
    Inherits=".frmRptTrailerByCircuit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-874" />

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    </head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">

        <br />

    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
        &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
        <br />
        <br />
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Font-Size="14px" ForeColor="#000000" Font-Names="Franklin Gothic Medium" Width="655px"
        BorderColor="#F4F4F4">
        <asp:TableRow ID="TableRow4" runat="server" BorderColor="#F4F4F4"  Height="1px"  BackColor="#C2D8FE"   HorizontalAlign="Center">
            <asp:TableCell ID="TableCell5" runat="server" ForeColor="#C2D8FE" Font-Size="1" ColumnSpan="4">โคลัมเบีย
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" BorderColor="#F4F4F4" BackColor="#C2D8FE" Height="30px" Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" runat="server" Font-Size="20px" ForeColor="Black"  ColumnSpan="4">TRAILER 
            LIST BY CIRCUIT
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" BorderColor="#F4F4F4"  Height="25px"   Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell4" runat="server" Font-Size="14px" ColumnSpan="4">PERIOD 
            :
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" BorderColor="#F4F4F4"  Height="25px"   Font-Bold="True" Font-Names="Tahoma"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell2" BackColor="#C3CAD6" runat="server" Font-Size="11pt"
                ColumnSpan="2">Trailers
            </asp:TableCell>
            <asp:TableCell ID="TableCell3" BackColor="#C3CAD6" Width="120px" runat="server" Font-Size="11pt">Amount
            </asp:TableCell>
            <asp:TableCell ID="TableCell6" BackColor="#C3CAD6" Width="120px" runat="server" Font-Size="11pt">%
            </asp:TableCell>
        </asp:TableRow>
        
                
    </asp:Table>

    </form>
</body>
</html>