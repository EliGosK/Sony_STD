<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="HeaderContent.ascx.vb"
    Inherits="SDT.UserControls.HeaderContent" %>
<table style="width: 100%; border: 1px solid #888888; font-size: 8pt; color: #003366;
    vert-align: middle" bgcolor="#DDDDDD">
    <tr>
        <td align="right" width="65px">
            เครือ:
        </td>
        <td align="center" style="text-align: left">
            <asp:Label ID="lblCircuit" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            โรงภาพยนตร์:
        </td>
        <td align="center" style="text-align: left">
            <asp:Label ID="lblTheater" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            วันที่:
        </td>
        <td align="center" style="text-align: left">
            <asp:Label ID="lblDate" runat="server"></asp:Label>
        </td>
    </tr>
</table>
