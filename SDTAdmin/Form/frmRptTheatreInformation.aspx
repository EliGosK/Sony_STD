<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTheatreInformation.aspx.vb"
    Inherits=".frmRptTheatreInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
       A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 8pt; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 8pt; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 8pt; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 8pt; TEXT-DECORATION: none }
 </style> 
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Table ID="tblMain" runat="server" GridLines="Both" CellPadding="0" Width="800px"
        CellSpacing="0" BorderWidth="0" ForeColor="Black">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Center" ColumnSpan="13">
                <asp:Table ID="tblHead" runat="server" GridLines="Both" CellPadding="6" Width="795px"
                    CellSpacing="0" ForeColor="Black">
                    <asp:TableRow ID="TableRow15" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell33" Height="25px" runat="server" ColumnSpan="13">THEATRE INFORMATION
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="11pt" HorizontalAlign="Center">
                        <asp:TableCell ID="TableCell2" Height="25px" runat="server" ColumnSpan="13">From Date :</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" >
         <asp:TableCell ID="TableCell34" Height="25px" runat="server" ColumnSpan="13"></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="12pt" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell3" VerticalAlign="Top" runat="server">
                <asp:Table ID="tbl1" runat="server" GridLines="Both" CellPadding="6" Width="390px"
                    CellSpacing="0" ForeColor="Black">
                    <asp:TableRow ID="TableRow10" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell26" ColumnSpan="4" runat="server">Theatre Information
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="White" HorizontalAlign="Center"
                        VerticalAlign="Bottom" BackColor="#5D7B9D">
                        <asp:TableCell ID="TableCell5" runat="server">No.
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell6" runat="server">Theatre
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell7" runat="server">Screen
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell8" runat="server">No. Seats
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell ID="tc" Width="10px" runat="server">&nbsp;</asp:TableCell>
            <asp:TableCell ID="TableCell4" VerticalAlign="Top" runat="server">
                <asp:Table ID="tbl2" runat="server" GridLines="Both" CellPadding="6" Width="390px"
                    CellSpacing="0" ForeColor="Black">
                    <asp:TableRow ID="TableRow9" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell25" ColumnSpan="8" runat="server">Screen & Seats by Circuit
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow5" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Bottom"  BackColor="#5D7B9D">
                        <asp:TableCell ID="TableCell9" ColumnSpan="2" Width="180" runat="server">Circuit
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell10" ColumnSpan="2" Width="100" runat="server">Location &nbsp;&nbsp;%
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell11" ColumnSpan="2" Width="100" runat="server">Screen &nbsp;&nbsp;&nbsp;%
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell12" ColumnSpan="2" Width="120" runat="server">No. Seats &nbsp;&nbsp;%
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table ID="tbl3" runat="server" GridLines="Both" CellPadding="6" Width="390px"
                    CellSpacing="0" ForeColor="Black">
                    <asp:TableRow ID="TableRow8" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell24" ColumnSpan="8" runat="server">Film Type by Circuit
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow7" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="White" HorizontalAlign="Center"
                        VerticalAlign="Bottom" BackColor="#5D7B9D">
                        <asp:TableCell ID="TableCell20" ColumnSpan="2" runat="server" Width="150">Circuit
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell21" ColumnSpan="2" runat="server" Width="80">35 mm.
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell22" ColumnSpan="2" runat="server" Width="80">3D
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell23" ColumnSpan="2" runat="server" Width="80">Digital
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table ID="tbl4" runat="server" GridLines="Both" CellPadding="6" Width="390px"
                    CellSpacing="0" ForeColor="Black" Visible=false>
                    <asp:TableRow ID="TableRow11" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell27" ColumnSpan="8" runat="server">Add Location & Screen
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow12" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="White" HorizontalAlign="Center" 
                        VerticalAlign="Bottom" BackColor="#5D7B9D">
                        <asp:TableCell ID="TableCell28" ColumnSpan="4" runat="server">Circuit & Screen
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell29" ColumnSpan="4" runat="server">Open Date
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Table ID="tbl5" runat="server" GridLines="Both" CellPadding="6" Width="390px"
                    CellSpacing="0" ForeColor="Black" Visible=false >
                    <asp:TableRow ID="TableRow13" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="Black" HorizontalAlign="Center" BackColor="#C2D8FE">
                        <asp:TableCell ID="TableCell30" ColumnSpan="8" runat="server">Close Location & Screen
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="TableRow14" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" ForeColor="White" HorizontalAlign="Center" 
                        VerticalAlign="Bottom" BackColor="#5D7B9D">
                        <asp:TableCell ID="TableCell31" ColumnSpan="4" runat="server">Circuit & Screen
                        </asp:TableCell>
                        <asp:TableCell ID="TableCell32" ColumnSpan="4" runat="server">Close Date
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>