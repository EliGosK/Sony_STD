<%@ Page Title="เลือกภาพยนตร์" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerBase.Master"
    CodeBehind="MovieList.aspx.vb" Inherits="SDT.Checker.MovieList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="tdTitle" style="width: 50px">
                ภาพยนตร์
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtSearch" runat="server" Width="95%"></asp:TextBox>
            </td>
            <td style="width: 50px">
                <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" CssClass="ButtonDefualt" Width="95%" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="False" CellPadding="3"
        Font-Bold="False" Font-Names="Tahoma" Font-Size="Small" Width="100%" BackColor="White"
        GridLines="None" BorderStyle="None" BorderWidth="0px">
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" HorizontalAlign="Left" ForeColor="Black" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="hplStatus" runat="server" NavigateUrl='<%# Bind("LinkTo") %>'>
                        <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# Bind("LinkToIcon") %>' ImageAlign="Middle" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    รายชื่อภาพยนตร์
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="hplName" runat="server" NavigateUrl='<%# Bind("LinkTo") %>' Text='<%# Bind("MovieName") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                <HeaderTemplate>
                    แจ้งยอด
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="hplRevenue" runat="server" NavigateUrl='<%# Bind("LinkTo") %>'
                        Text='<%# Bind("Revenue") %>'>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="hplTerminate" runat="server" NavigateUrl='<%# Bind("LinkTerminate") %>'>
                        <asp:Image ID="imgTerminate" runat="server" ImageUrl="../images/icon_terminate.gif"
                            ImageAlign="Middle" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnRemain" runat="server" Text="รายการค้าง" CssClass="ButtonDefualt" />
                &nbsp;<asp:Button ID="btnMainMenu" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
</asp:Content>
