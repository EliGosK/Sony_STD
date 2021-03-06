<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerExeByWeek.aspx.vb"
    Inherits=".frmRptTrailerExeByWeek" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Trailer Execute By Week</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
    A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
    </style>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <div>
        &nbsp;<br />
        <asp:TextBox ID="lblDate" runat="server" BackColor="#336699" Columns="25" Font-Bold="True"
            ForeColor="White" ReadOnly="True" Width="328px"></asp:TextBox>
        <br />
        <asp:Button ID="btnExport" runat="server" Text="Export To Excel Format" />
        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
        &nbsp;</div>
    
        <br />
        <asp:Table ID="tblRpt" runat="server" BorderStyle="Solid" CellPadding="3" CellSpacing="0"
            Font-Size="8pt" GridLines="Both" Width="100%" ForeColor="Black" Font-Names="Franklin Gothic Medium"
            BorderColor="#F4F4F4">
            <%--        <asp:TableRow ID="TableRow1" runat="server" BackColor="#CCCCCC"  
            Font-Size="10pt">
            <asp:TableCell ID="TableCell1" runat="server">Title</asp:TableCell>
        </asp:TableRow>--%>
            <asp:TableRow ID="TableRow1" Height="1px" BorderWidth="0" runat="server" 
                ForeColor="#C2D8FE" BorderColor="#C2D8FE" Font-Names="Franklin Gothic Medium"
                HorizontalAlign="Center">
                <asp:TableCell ID="TableCell1" runat="server" BorderColor="#F4F4F4" BackColor="#C2D8FE"
                    Font-Size="1px" ColumnSpan="2">โคลัมเบีย
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" BorderWidth="0" Width="100%" BorderColor="#F4F4F4" BackColor="#C2D8FE"
                runat="server" Font-Bold="True" Font-Names="Franklin Gothic Medium" HorizontalAlign="Center">
                <asp:TableCell ID="TableCell2" runat="server" Font-Size="20px" ColumnSpan="2">TRAILER EXECUTION BY WEEK
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
