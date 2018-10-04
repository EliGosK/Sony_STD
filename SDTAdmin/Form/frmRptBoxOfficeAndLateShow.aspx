<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptBoxOfficeAndLateShow.aspx.vb"
    Inherits=".frmRptBoxOfficeAndLateShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Box Office and Late Show by Theatre</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <link type="text/css" rel="stylesheet" href="../Styles.css" />
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <div runat="server" id="divExport">
        <asp:Table ID="tblTitle" runat="server" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
            CellSpacing="0" Font-Size="11pt" GridLines="Both" BackColor="#C2D8FE" Width="100%" ForeColor="Black" 
            BorderColor="#dddddd" Font-Names="Tahoma" Height="31px" HorizontalAlign="Center">
        </asp:Table>
        <asp:Table ID="tblTop" runat="server" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
            CellSpacing="0" Font-Size="10pt" GridLines="Both" Width="100%" ForeColor="Black"
            BorderColor="#dddddd" Font-Names="Tahoma">
           
<%--            <asp:Table ID="tblRpt" runat="server" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                CellSpacing="0" Font-Size="10pt" GridLines="Both" Width="100%" ForeColor="Black"
                BorderColor="Black" Font-Names="Tahoma">
            </asp:Table>
            <br />
            <asp:Table ID="tblRptSum" runat="server" BorderStyle="Solid" BorderWidth="1px" CellPadding="3"
                CellSpacing="0" Font-Size="10pt" GridLines="Both" Width="500px" ForeColor="Black"
                BorderColor="Black" Font-Names="Tahoma">
            </asp:Table>--%>
            
            
        </asp:Table>
    </div>
    </form>
</body>
</html>