<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTheatreInformationCircuit.aspx.vb"
    Inherits=".frmRptTheatreInformationCircuit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Table ID="tblMain" runat="server" GridLines="Both" CellPadding="0" 
        CellSpacing="0" BorderWidth="1" BorderColor="Black" ForeColor="Black">
        <asp:TableRow ID="TableRow15" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="12pt" HorizontalAlign="Center" >
            <asp:TableCell  Height="25px" BackColor="#C2D8FE" runat="server" ColumnSpan="7">THEATRE & SEAT TYPE
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell2" Height="25px" runat="server" ColumnSpan="7">From Date :</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="9pt" HorizontalAlign="Center" >
            <asp:TableCell RowSpan="2" ForeColor="White" BackColor="#5D7B9D" Width="100px" runat="server">Theatre
            </asp:TableCell>
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="100px" runat="server">Digital
            </asp:TableCell>
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="100px" RowSpan="2" runat="server">Type of Seat
            </asp:TableCell>
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="100px" RowSpan="2" runat="server">No. of Seat
            </asp:TableCell>
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="200px" ID="TableCell3" ColumnSpan="2" runat="server">Price structure
            </asp:TableCell>
            <asp:TableCell ForeColor="White" BackColor="#5D7B9D" Width="300px" ID="TableCell4" RowSpan="2" runat="server">Comment
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="9pt" HorizontalAlign="Center" >
            <asp:TableCell BackColor="#5D7B9D" ForeColor="White" Width="100px"  ID="TableCell5" runat="server">format
            </asp:TableCell>
            <asp:TableCell BackColor="#5D7B9D" ForeColor="White" Width="100px" ID="TableCell6" runat="server">Weekend
            </asp:TableCell>
            <asp:TableCell BackColor="#5D7B9D" ForeColor="White" Width="100px" ID="TableCell7" runat="server">Weekday
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    </form>
</body>
</html>