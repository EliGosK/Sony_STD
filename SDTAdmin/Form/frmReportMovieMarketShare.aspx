<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReportMovieMarketShare.aspx.vb" EnableEventValidation="false"
    Inherits="Form.frmReportMovieMarketShare" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:visited
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:hover
        {
            color: #cccccc;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:active
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Table ID="tblHeader" runat="server" GridLines="Both" CellPadding="6" Width="920px"
        CellSpacing="0" ForeColor="Black">
        <asp:TableRow ID="tblHeaderTr1" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="12pt" HorizontalAlign="Center" BackColor="#C2D8FE">
            <asp:TableCell ID="tcHeader1" runat="server" ColumnSpan="6">TITLE ?
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow ID="tblHeaderTr2" runat="server" Font-Bold="True" Font-Names="Tahoma"
            Font-Size="11pt" HorizontalAlign="Center">
            <asp:TableCell ID="tcHeader2" runat="server" ColumnSpan="6">Date ?</asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:Panel ID="pnlResult" Width="920px" HorizontalAlign="Center" runat="server">
    </asp:Panel>
    <br />
    </form>
</body>
</html>
