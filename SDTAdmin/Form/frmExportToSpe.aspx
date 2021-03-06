<%@ Page Language="vb" EnableEventValidation = "false" AutoEventWireup="false" CodeBehind="frmExportToSpe.aspx.vb" Inherits=".frmExportToSpe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">

A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
    </style>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <div>
    
    &nbsp;<asp:TextBox ID="lblDate" runat="server" BackColor="#336699" Columns="25" 
                                                                                    
            Font-Bold="True" ForeColor="White" ReadOnly="True" Width="328px"></asp:TextBox>
                                                                                <br />
        <asp:Button ID="btnExport" runat="server" Text="Export To CSV Format" />
&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
&nbsp;</div>
                                <FONT face="Tahoma" color="rosybrown" size="1">
                <br />
    <asp:Table ID="tblRpt" runat="server" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" CellSpacing="0" Font-Size="8.5pt" GridLines="Both" 
        Width="100%" ForeColor="Black" Font-Names="Tahoma">
        
        <%--<asp:TableRow ID="TableRow1" runat="server" Font-Names="Trebuchet MS"  Visible="false" 
                        >
        <asp:TableCell ID="TableCell1" runat="server" 
        ColumnSpan="20"  Height="25px"   Font-Bold="True" ForeColor="Black" BackColor="#C2D8FE"  Font-Size="13pt" HorizontalAlign="Center" >Export Box Office Data to SPIRITworld </asp:TableCell>
        </asp:TableRow>--%>
        
        <asp:TableRow runat="server" BackColor="#5D7B9D"   ForeColor="White" >
            <asp:TableCell runat="server">TID</asp:TableCell>
            <asp:TableCell runat="server">TheatreName</asp:TableCell>
            <asp:TableCell runat="server">MID</asp:TableCell>
            <asp:TableCell runat="server">Title</asp:TableCell>
            <asp:TableCell runat="server">FlimsType</asp:TableCell>
            <asp:TableCell runat="server">ShowingDate</asp:TableCell>
            <asp:TableCell runat="server">Gross1</asp:TableCell>
            <asp:TableCell runat="server">Admission1</asp:TableCell>
            <asp:TableCell runat="server">Gross2</asp:TableCell>
            <asp:TableCell runat="server">Admission2</asp:TableCell>
            <asp:TableCell runat="server">Gross3</asp:TableCell>
            <asp:TableCell runat="server">Admission3</asp:TableCell>
            <asp:TableCell runat="server">Gross4</asp:TableCell>
            <asp:TableCell runat="server">Admission4</asp:TableCell>
            <asp:TableCell runat="server">Gross5</asp:TableCell>
            <asp:TableCell runat="server">Admission5</asp:TableCell>
            <asp:TableCell runat="server">Gross6</asp:TableCell>
            <asp:TableCell runat="server">Admission6</asp:TableCell>
            <asp:TableCell runat="server">Gross7</asp:TableCell>
            <asp:TableCell runat="server">Admission7</asp:TableCell>

        </asp:TableRow>
    </asp:Table> 
                </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>