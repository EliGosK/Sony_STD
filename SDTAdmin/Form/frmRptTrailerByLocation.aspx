<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByLocation.aspx.vb"
    Inherits=".frmRptTrailerByLocation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        .style1
        {
            width: 298px;
        }
    </style>
           <%-- .underline11
        {
            border-top-color : #aaaaaa;border-top-style: solid;border-top-width: 2px;
        }
        --%>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">

    <br />

    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <div id="divExport" runat="server" >
<%--        <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
            Font-Size="14px" ForeColor="Black" Font-Names="Franklin Gothic Medium" Width="100%">

        </asp:Table>--%>
        <%--<asp:Label ID="lblThai" ForeColor="White" Font-Size="2" runat="server" Text="กกก"></asp:Label>--%>
        <asp:Table ID="tblTrailer" GridLines="Both" runat="server" CellPadding="0" CellSpacing="0"
            Font-Size="14px" ForeColor="Black" Font-Names="Franklin Gothic Medium" 
            Width="100%" BorderColor="#F4F4F4" >
            <asp:TableRow ID="TableRow4" Height="1" BorderWidth="0"  runat="server" ForeColor="#C2D8FE" BorderColor="#C2D8FE" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
                <asp:TableCell ID="TableCell3" runat="server"  BorderColor="#F4F4F4" BackColor="#C2D8FE"  Font-Size="1px" ColumnSpan="2">โคลัมเบีย
                </asp:TableCell>
            </asp:TableRow>
                        <asp:TableRow ID="TableRow1" BorderWidth="0"  BorderColor="#F4F4F4" BackColor="#C2D8FE"  runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
                <asp:TableCell ID="TableCell1" runat="server" Font-Size="20px" ColumnSpan="2">TRAILER LIST BY LOCATION
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server" BorderWidth="0"   Font-Bold="True" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
                <asp:TableCell ID="TableCell4" runat="server" Font-Size="14px" ColumnSpan="2">PERIOD :
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server" BorderWidth="0"  Font-Bold="True" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
                <asp:TableCell ID="TableCell2" runat="server" Font-Size="14px" ColumnSpan="2">Date :
                </asp:TableCell>
            </asp:TableRow>
            
        </asp:Table>
    </div>
    </form>
</body>
</html>
