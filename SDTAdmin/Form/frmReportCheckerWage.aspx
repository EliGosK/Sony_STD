<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmReportCheckerWage.aspx.vb"
    EnableEventValidation="false" Inherits="Form.frmReportCheckerWage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <%--    <script type="text/javascript">
        function fixform() {
            if (opener.document.getElementById("aspnetForm") == null || opener.document.getElementById("aspnetForm").target != "_blank") return;
            opener.document.getElementById("aspnetForm").target = "";
            opener.document.getElementById("aspnetForm").action = opener.location.href;
        }
    </script>--%>
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
<%--<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" onload="fixform()">--%>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <br />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel Format" />
    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="60px" />
    <br />
    <br />
    <asp:Panel ID="pnlResult" HorizontalAlign="Right" runat="server">
    </asp:Panel>
    </form>
</body>
</html>
