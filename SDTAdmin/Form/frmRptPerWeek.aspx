<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptPerWeek.aspx.vb" Inherits=".frmRptPerWeek" %>

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
    <asp:Table ID="tblRpt" runat="server" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" CellSpacing="0" Font-Size="8pt" GridLines="Both" 
        Width="100%" ForeColor="Black" Font-Names="Tahoma">
        
        <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="23"  ForeColor="#ffffff" Height="0px"  BorderColor="#ffffff" BorderWidth="0px"  Font-Size="1px" style="display:none" >ค</asp:TableCell>
        </asp:TableRow>  
        
        <asp:TableRow runat="server" Font-Bold="True" Font-Size="Small">
            <asp:TableCell runat="server" ColumnSpan="23"  Font-Bold="True"  ForeColor="Black" BackColor="#C2D8FE"  Font-Size="13pt" >Title..</asp:TableCell>
        </asp:TableRow>     
        <asp:TableRow runat="server" Font-Size="9pt" 
            HorizontalAlign="Center" Font-Bold="True" ForeColor="White" 
            Font-Names="Tahoma" >
    		    <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >No.</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >Theatre</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >Format</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 1</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 2</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 3</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 4</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 5</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 6</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Session: 7</asp:TableCell>
                <asp:TableCell runat="server" ColumnSpan="2" BackColor="#5D7B9D" >Total</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >Net Vat</asp:TableCell>
                <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >Sharing</asp:TableCell>
    	        <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >Revenue</asp:TableCell>
    	        <asp:TableCell runat="server" RowSpan="2" BackColor="#5D7B9D" >A/R</asp:TableCell>
               </asp:TableRow>
        <asp:TableRow runat="server" ForeColor="White" HorizontalAlign="Center" Font-Size="9pt"  >
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" BackColor="#5D7B9D" >Adms</asp:TableCell>
            <asp:TableCell runat="server" Font-Bold="True" BackColor="#5D7B9D" >Baht</asp:TableCell>
            <asp:TableCell runat="server" Font-Bold="True" BackColor="#5D7B9D" >Adms</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>