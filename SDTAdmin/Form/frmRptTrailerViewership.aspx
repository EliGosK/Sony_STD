<%@ Page Language="vb" EnableEventValidation="false" EnableViewStateMac="false"AutoEventWireup="false" CodeBehind="frmRptTrailerViewership.aspx.vb"
    Inherits=".frmRptTrailerViewership" %>

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
        .underline11
        {
            border-bottom-color : #aaaaaa;border-bottom-style: solid;border-bottom-width: 2px;
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
        Width="1000"  BorderColor="#F4F4F4" >
       <asp:TableRow ID="TableRow4" Height="1" BorderWidth="0"  runat="server" ForeColor="#C2D8FE" BorderColor="#C2D8FE" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
            <asp:TableCell ID="TableCell3" runat="server"  BorderColor="#F4F4F4" BackColor="#C2D8FE"  Font-Size="1px" ColumnSpan="8">โคลัมเบีย
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow  runat="server" Font-Bold="True" Height="25" BorderColor="#F4F4F4" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell runat="server" Font-Size="20px"  BackColor="#C2D8FE"   ColumnSpan="8">TRAILER VIEWERSHIP BY TITLE
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Height="25"  Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" BackColor="White"  runat="server" Font-Size="14px" ColumnSpan="8">Movie Name
            </asp:TableCell>
        </asp:TableRow>
        
                <asp:TableRow ID="TableRow3" runat="server" Height="25"  Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell7" BackColor="#eeeeee"  runat="server" Font-Size="14px" ColumnSpan="8">Release Date :
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow2" runat="server" Height="0"  Font-Bold="True" Font-Names="Franklin Gothic Medium"
            HorizontalAlign="Center">
                <asp:TableCell ID="TableCell2" BackColor="#eeeeee"  runat="server" Width="60" Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell4" BackColor="#eeeeee"  runat="server" Width="100"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell5" BackColor="#eeeeee"  runat="server" Width="60"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell6" BackColor="#eeeeee"  runat="server" Width="80"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell8" BackColor="#eeeeee"  runat="server" Width="270"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell9" BackColor="#eeeeee"  runat="server" Width="80"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                <asp:TableCell ID="TableCell10" BackColor="#eeeeee"  runat="server" Width="270"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
                 <asp:TableCell ID="TableCell11" BackColor="#eeeeee"  runat="server" Width="80"  Font-Size="14px" ColumnSpan="1"></asp:TableCell>
            </asp:TableRow>
    </asp:Table>
    </form>

</body>
</html>
