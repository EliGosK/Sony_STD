<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptMarketSare.aspx.vb" Inherits=".frmRptMarketSare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
  
		        <br />
        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format"  />
&nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
                <br />
    <br />
                <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="6" 
        CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black" Width="801px" >
                    <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="13pt" HorizontalAlign="Center" >
                        <asp:TableCell runat="server" ColumnSpan="7" BackColor="#C2D8FE">SDT MARKET SHARE % RANKED BY THEATRE
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server"  Font-Bold="True" 
                        Font-Size="11pt" HorizontalAlign="Center">
                        <asp:TableCell runat="server" ColumnSpan="7">Date :</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Font-Bold="True" Font-Names="Tahoma" 
                        Font-Size="11pt" HorizontalAlign="Center" >
                        <asp:TableCell runat="server" BackColor="#c3cad6"  ColumnSpan="7" >Title</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server"  Font-Bold="True" 
                        Font-Size="10pt"  HorizontalAlign="Center" >
                        <asp:TableCell runat="server" BackColor="#c3cad6" ColumnSpan="7" >BANGKOK
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                        <asp:TableCell runat="server" RowSpan="2" ForeColor="White"  BackColor="#5D7B9D">RANKING</asp:TableCell>
                        <asp:TableCell runat="server" RowSpan="2" ForeColor="White"  BackColor="#5D7B9D" 
                            HorizontalAlign="Center">THEATRE</asp:TableCell>
                        <asp:TableCell runat="server" RowSpan="2" ForeColor="White"  BackColor="#5D7B9D">BOX OFFICE</asp:TableCell>
                        <asp:TableCell runat="server" RowSpan="2" ForeColor="White"  BackColor="#5D7B9D">ADMS</asp:TableCell>
                        <asp:TableCell runat="server" RowSpan="2" ForeColor="White"  BackColor="#5D7B9D">ATP</asp:TableCell>
                        <asp:TableCell runat="server" ColumnSpan="1" ForeColor="White"  BackColor="#5D7B9D">B.O. GROSS</asp:TableCell>
                        <asp:TableCell runat="server" ColumnSpan="1" ForeColor="White"  BackColor="#5D7B9D">ADMISSION</asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server" Font-Bold="True" 
                        Font-Size="9pt" HorizontalAlign="Center">
                        <asp:TableCell runat="server" ForeColor="White"  BackColor="#5D7B9D">BY BKK</asp:TableCell>
                        <%--<asp:TableCell runat="server" BackColor="#DDDDDD">By Key City</asp:TableCell>--%>
                        <asp:TableCell runat="server" ForeColor="White"  BackColor="#5D7B9D">BY BKK</asp:TableCell>
                        <%--<asp:TableCell runat="server" BackColor="#DDDDDD">By Key City</asp:TableCell>--%>
                    </asp:TableRow>
    </asp:Table>
                </form>
</body>
</html>