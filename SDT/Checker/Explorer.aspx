<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Explorer.aspx.cs" Inherits="ServerExplorer.Explorer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmMain" runat="server">
    <div>
        <table style="width: 100%;">
            <tr valign="top">
                <td style="width: 120px">
                    Path
                </td>
                <td>
                    <asp:TextBox ID="txtPath" runat="server" Width="100%" Wrap="False"></asp:TextBox>
                </td>
                <td style="width: 50px">
                    <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="BtnGoClick" />
                </td>
            </tr>
        </table>
        <br>
        <br>
        <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="False" OnRowCommand="GrdResultRowCommand"
            OnRowDeleting="GrdResultRowDeleting" OnRowDataBound="GrdResultRowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="True" HeaderText="Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" CommandArgument='<%# Bind("FullName") %>'
                            CommandName="View" Text='<%# Bind("Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="True" HeaderText="Size">
                    <ItemStyle HorizontalAlign="Right" />
                    <ItemTemplate>
                        <asp:Label ID="lblSize" runat="server" Text='<%# Bind("Size") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CreationTime" HeaderText="Creation Time" />
                <asp:BoundField DataField="LastWriteTime" HeaderText="Last Write Time" />
                <asp:TemplateField ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Bind("FullName") %>'
                            CommandName="Delete" Text="Delete" OnClientClick="return confirm('Confirm to delete ?')" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Button ID="btnDownload" runat="server" CommandArgument='<%# Bind("FullName") %>'
                            CommandName="Download" Text="Download" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                    <ItemTemplate>
                        <asp:Button ID="btnCreateZip" runat="server" CommandArgument='<%# Bind("FullName") %>'
                            CommandName="CreateZip" Text="Create GZip" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnBack" runat="server" Text="Back" />
    </div>
    </form>
</body>
</html>
