<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmExportForCustomerComp.aspx.vb" Inherits=".frmExportForCustomerComp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <FONT face="Tahoma" color="rosybrown" size="1">
		        <br />
        <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format"  />
&nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
                <br />
    <%--<asp:Table ID="tblRpt" runat="server" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" CellSpacing="0" Font-Size="9pt" GridLines="Both" 
        Width="100%" ForeColor="Black"
        Font-Names="Tahoma" >
        <asp:TableRow runat="server" >
            <asp:TableCell runat="server" ColumnSpan="17" Height="25px" BackColor="#C2D8FE"   Font-Bold="True"  ForeColor="Black"   Font-Size="13pt" >Title : DateTime :</asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="TableRow1" runat="server" Font-Bold="True" Font-Size="9pt" 
            HorizontalAlign="Center" Font-Names="Tahoma"  ForeColor="White" >
            <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D">Theartre</asp:TableCell>
            <asp:TableCell runat="server" ColumnSpan="4" BackColor="#5D7B9D">Original Soundtrack</asp:TableCell>
            <asp:TableCell runat="server" ColumnSpan="4" BackColor="#5D7B9D">Thai Dub</asp:TableCell>
            <asp:TableCell runat="server" ColumnSpan="4" BackColor="#5D7B9D">Digital 3D</asp:TableCell>
            <asp:TableCell runat="server" ColumnSpan="4" BackColor="#5D7B9D">Total</asp:TableCell>
        </asp:TableRow>
         <asp:TableRow ID="TableRow2" runat="server" Font-Names="Tahoma" 
            Font-Size="9pt" HorizontalAlign="Center"  Font-Bold="false" ForeColor="White" > 
            <asp:TableCell runat="server" BackColor="#5D7B9D">Screen</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Session</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Baht</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Screen</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Session</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Baht</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Screen</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Session</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Baht</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Screen</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D">Session</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Baht</asp:TableCell>
            <asp:TableCell runat="server" Width="70px" BackColor="#5D7B9D">Adms</asp:TableCell>
        </asp:TableRow>
    </asp:Table>--%>
    <asp:Table ID="tableReport" runat="server" Width="450px" GridLines="Both" CellPadding="6" CellSpacing="0" Font-Names="Tahoma" Font-Size="9pt" ForeColor="Black">
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="13pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" ColumnSpan="10" ForeColor="Black" BackColor="#C2D8FE">
                <center>Competitor Daily Box Office (Initial)</center> Title : {0},  Date : {1}
                </asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" Width="200px" RowSpan="2" BackColor="#5D7B9D" ForeColor="White">Theatre</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="250px" ColumnSpan="4" BackColor="#5D7B9D" ForeColor="White">Total GBO</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableHeaderRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableHeaderCell runat="server" Width="100px" BackColor="#5D7B9D" ForeColor="White">Baht</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="50px" BackColor="#5D7B9D" ForeColor="White">Adms</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="50px" BackColor="#5D7B9D" ForeColor="White">Screen</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server" Width="50px" BackColor="#5D7B9D" ForeColor="White">Session</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableFooterRow runat="server" Font-Bold="True" Font-Size="9pt" HorizontalAlign="Center">
                <asp:TableCell runat="server" BackColor="#303D50" ForeColor="White">Grand Total</asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White"></asp:TableCell>
                <asp:TableCell runat="server" HorizontalAlign="Right" BackColor="#303D50" ForeColor="White"></asp:TableCell>
            </asp:TableFooterRow>
        </asp:Table>
</form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>