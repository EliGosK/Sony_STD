<%@ Page Title="รายการค้าง" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="RemainMovieList.aspx.vb" Inherits="SDT.Checker.RemainMovieList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="labelError">
                <asp:Label ID="lblOwnerRevenue" runat="server">
                ภาพยนตร์ SDT
                <br />
                ที่ยังค้างการแจ้งยอด
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdOwnerRevenue" runat="server" AutoGenerateColumns="False" CellPadding="0"
        Font-Names="Tahoma" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
        Width="100%" BorderStyle="None" Font-Bold="False">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    วันที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_date","{0:dd-MMM-yy}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    เรื่อง
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "ShortName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    จอที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "theatersub_id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    รอบที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_Time") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="X-Small" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="labelError">
                <asp:Label ID="lblOwnerFreeTicket" runat="server" Visible="False">
                ภาพยนตร์ SDT<br />
                ที่ยังค้างการแจ้งบัตรฟรี/ปัดยอด
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdOwnerFreeTicket" runat="server" AutoGenerateColumns="False"
        CellPadding="0" Font-Names="Tahoma" Font-Size="X-Small" 
        ForeColor="#333333" GridLines="None"
        Width="100%" BorderStyle="None" Font-Bold="False" Visible="False">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    วันที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_date","{0:dd-MMM-yy}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    เรื่อง
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "ShortName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    จอที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "theatersub_id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    รอบที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_Time") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="X-Small" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="labelError">
                <asp:Label ID="lblOwnerTicketType" runat="server" Visible="False">
                ภาพยนตร์ SDT<br />
                ที่ยังค้างการแจ้งชนิดบัตร
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdOwnerTicketType" runat="server" AutoGenerateColumns="False"
        CellPadding="0" Font-Names="Tahoma" Font-Size="X-Small" 
        ForeColor="#333333" GridLines="None"
        Width="100%" BorderStyle="None" Font-Bold="False" Visible="False">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    วันที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_date","{0:dd-MMM-yy}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    เรื่อง
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "ShortName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    จอที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "theatersub_id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    รอบที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_Time") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="X-Small" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="labelError">
                <asp:Label ID="lblCompetitor" runat="server">
                    ภาพยนตร์คู่แข่ง<br />
                ที่ยังค้างการแจ้งยอด
                </asp:Label>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdCompetitor" runat="server" AutoGenerateColumns="False" CellPadding="0"
        Font-Names="Tahoma" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
        Width="100%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    วันที่
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "revenue_date","{0:dd-MMM-yy}") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    เรื่อง
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'
                        Text='<%# DataBinder.Eval(Container.DataItem, "ShortName") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnBackToMovieList" runat="server" Text="กลับไปหน้าเลือกภาพยนตร์"
                    CssClass="ButtonDefualt" Width="160px" />
            </td>
        </tr>
    </table>
</asp:Content>
