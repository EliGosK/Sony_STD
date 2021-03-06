<%@ Page Title="รายละเอียดชุดหนังตัวอย่าง" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Checker/Master/CheckerTransaction.Master" CodeBehind="TrailerCollection.aspx.vb"
    Inherits="SDT.Checker.TrailerCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAdd" runat="server" Text="เพิ่มชุดหนังตัวอย่าง" CssClass="ButtonDefualt"
        Width="120px" />
    <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="False" CellPadding="0"
        Font-Names="Tahoma" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
        Width="100%" BorderStyle="None" EmptyDataText="ไม่มีข้อมูล" Font-Bold="True"
        AllowSorting="True">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:HyperLinkField DataTextField="collection_name" HeaderText="ชื่อชุด" SortExpression="MovieCollection"
                DataNavigateUrlFields="collection_no" ItemStyle-Width="40px" ItemStyle-VerticalAlign="Middle"
                ItemStyle-HorizontalAlign="Left" DataNavigateUrlFormatString="TrailerCollectionInsert.aspx?collection_no={0}">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40px"></ItemStyle>
            </asp:HyperLinkField>
            <asp:BoundField DataField="MovieCollection" HeaderText="ชื่อหนังตัวอย่าง" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Middle" SortExpression="MovieCollection">
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" Width="20px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("collection_no") %>'
                        CommandName="Del" ForeColor="#FF0000" OnClientClick="return confirm('ยืนยันการลบข้อมูล?')"
                        Text="ลบ"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Size="X-Small" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnMainMenu" runat="server" Text="กลับเมนูหลัก" CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
</asp:Content>
