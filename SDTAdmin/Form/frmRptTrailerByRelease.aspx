<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByRelease.aspx.vb"
    Inherits=".frmRptTrailerByRelease" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 15px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 15px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 15px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 15px; TEXT-DECORATION: none }
        .under1
        {
            border-bottom-color: Black;
            border-bottom-style: solid;
            border-bottom-width: 1px;
        }
        .under2
        {
            border-bottom-color: Black;
            border-bottom-style: double;
            border-bottom-width: 2px;
        }
    </style>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" Font-Overline="False"
        Font-Strikeout="False" />
    <br />
    <br />
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Font-Size="14px" ForeColor="Black" Font-Names="Franklin Gothic Medium" 
        Width="780px"  BorderColor="#F4F4F4" >
       <asp:TableRow ID="TableRow4" Height="1" BorderWidth="0"  runat="server" ForeColor="#C2D8FE" BorderColor="#C2D8FE" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
            <asp:TableCell ID="TableCell3" runat="server"  BorderColor="#F4F4F4" BackColor="#C2D8FE"  Font-Size="1px" ColumnSpan="5">
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow  runat="server" Font-Bold="True" Height="25" BorderColor="#F4F4F4" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell runat="server" Font-Size="20px" BackColor="#C2D8FE" ColumnSpan="5">TRAILER LIST BY RELEASE
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Height="25" Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" BackColor="White" runat="server" Font-Size="16px" ColumnSpan="5">Movie Name
            </asp:TableCell>
        </asp:TableRow>
        
                <asp:TableRow ID="TableRow3" runat="server" Height="25" Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell7" BackColor="#eeeeee"  runat="server" Font-Size="16px" ColumnSpan="5">Setup No.
            </asp:TableCell>
        </asp:TableRow>
        
                <asp:TableRow ID="TableRow2" runat="server" Height="25"  Font-Bold="True"  Font-Names="Tahoma"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell8" runat="server" Font-Size="11pt" Width="9" ColumnSpan="1" BackColor="#DBEEF3" HorizontalAlign="Left" ></asp:TableCell>
            <asp:TableCell ID="TableCell6" runat="server" Font-Size="11pt" Width="471" ColumnSpan="1" BackColor="#DBEEF3" HorizontalAlign="Left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Trailer</asp:TableCell>
            <asp:TableCell ID="TableCell4"  runat="server" Font-Size="11pt" Width="100" ColumnSpan="1" BackColor="#DBEEF3"  >Amount</asp:TableCell>
            <asp:TableCell ID="TableCell5"  runat="server" Font-Size="11pt" Width="100" ColumnSpan="1" BackColor="#DBEEF3">%</asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server" Font-Size="11pt" Width="100" ColumnSpan="1" BackColor="#DBEEF3" >Est Adms</asp:TableCell>
           
        </asp:TableRow>
        
    </asp:Table>
    </form>
</body>
</html>