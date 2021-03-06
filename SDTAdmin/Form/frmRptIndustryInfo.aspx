<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptIndustryInfo.aspx.vb"
    Inherits=".frmRptIndustryInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        .style1
        {
            font-family: "tahoma";
            font-size: 11px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport0" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel0" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Table ID="tbl" runat="server" GridLines="Both" CellPadding="0" CellSpacing="0"
        Font-Size="9pt" ForeColor="Black" Font-Names="tahoma" 
        BorderColor="#F4F4F4">
       
        <asp:TableRow ID="TableRow1" Height="0" BorderWidth="0" runat="server" ForeColor="#C2D8FE"
            BorderColor="#C2D8FE" Font-Names="tahoma" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell5" runat="server" BorderColor="#F4F4F4" BackColor="#C2D8FE"
                Font-Size="1px" ColumnSpan="12">โค
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID="TableRow2" runat="server" Font-Bold="True" Height="25" BorderColor="#F4F4F4"
            BackColor="#C2D8FE" Font-Names="tahoma" HorizontalAlign="Center">
            <asp:TableCell ID="TableCell1" runat="server" Font-Size="13pt" ColumnSpan="12">INDUSTRY INFORMATION BY TITLE
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID="TableRow3" runat="server" Font-Bold="True" Font-Names="tahoma"
            HorizontalAlign="Center">
            <asp:TableCell ID="TableCell4" runat="server" Font-Size="13pt" ColumnSpan="12"><font size="1" color="white">โค</font>Release Date :
            </asp:TableCell>
        </asp:TableRow>
        
        
        <asp:TableRow ID="TableRow4" runat="server" Font-Bold="True" Height="25" Font-Names="Tahoma"
            HorizontalAlign="Center" ForeColor="White"  >
            <asp:TableCell ID="TableCell2" RowSpan="2"  BackColor="#5D7B9D" Width="250px" runat="server" Font-Size="9pt"
                ColumnSpan="1">Title
            </asp:TableCell>
            <asp:TableCell ID="TableCell3" RowSpan="2"  BackColor="#5D7B9D" Width="70px" runat="server" Font-Size="9pt"
                ColumnSpan="1">Type
            </asp:TableCell>
            <asp:TableCell ID="TableCell6" RowSpan="2"  BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
                ColumnSpan="1">Distributor
            </asp:TableCell>
            <asp:TableCell ID="TableCell7" RowSpan="2"  BackColor="#5D7B9D" Width="120px" runat="server" Font-Size="9pt"
                ColumnSpan="1">Release Date
            </asp:TableCell>
            <asp:TableCell ID="TableCell8" RowSpan="2"  BackColor="#5D7B9D" Width="70px" runat="server" Font-Size="9pt"
                ColumnSpan="1">Screens
            </asp:TableCell>
            <asp:TableCell ID="TableCell9"  BackColor="#5D7B9D"  Width="400px"  runat="server" Font-Size="9pt"
                ColumnSpan="4">Box Office
            </asp:TableCell>
            <asp:TableCell ID="TableCell10"   BackColor="#5D7B9D"  Width="200px"  runat="server" Font-Size="9pt"
                ColumnSpan="2">Lifetime Gross
            </asp:TableCell>
            <asp:TableCell ID="TableCell11"  RowSpan="2" Width="100px"   BackColor="#5D7B9D" runat="server" Font-Size="9pt"
                ColumnSpan="1">ATP
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow ID="TableRow5" runat="server" Font-Bold="True" Height="25" Font-Names="Tahoma"
            HorizontalAlign="Center" ForeColor="White" >
            <asp:TableCell ID="TableCell12"    BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
               >OP Weekend
            </asp:TableCell>
            <asp:TableCell ID="TableCell13"    BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
                >Week 1
            </asp:TableCell>
            <asp:TableCell ID="TableCell14"    BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
               >Week 2
            </asp:TableCell>
            <asp:TableCell ID="TableCell15"    BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
               >Week 3
            </asp:TableCell>
            <asp:TableCell ID="TableCell16"   BackColor="#5D7B9D" Width="100px" runat="server" Font-Size="9pt"
                >Key Cities Only
            </asp:TableCell>
            <asp:TableCell ID="TableCell17"   BackColor="#5D7B9D" Width="50px" runat="server" Font-Size="9pt"
               >ADMS
            </asp:TableCell>
            
        </asp:TableRow>

    </asp:Table>
    </form>
</body>
</html>