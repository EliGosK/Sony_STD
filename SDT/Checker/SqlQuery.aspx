<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SqlQuery.aspx.cs" Inherits="ServerExplorer.SqlQuery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
    <div>
        <asp:Button ID="btnBack" runat="server" Text="Back" />
        <table style="width: 100%;">
            <tr valign="top">
                <td style="width: 120px">
                    Connection String
                </td>
                <td>
                    <asp:TextBox ID="txtConnectionString" runat="server" Width="100%" Wrap="False">Provider=SQLOLEDB.1;Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=SDT;Data Source=.</asp:TextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                    SQL
                </td>
                <td>
                    <asp:TextBox ID="txtSql" runat="server" Height="200px" Width="100%" Wrap="False"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr valign="top">
                <td>
                </td>
                <td>
                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="BtnGoClick" />
        <asp:Button ID="btnExportExcel" runat="server" OnClick="BtnExportExcelClick" 
                        Text="Export" />
                </td>
            </tr>
        </table>
        <br>
        <asp:GridView ID="grdResult" runat="server">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
