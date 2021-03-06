<%@ Page Title="แจ้งหนังตัวอย่าง" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="Trailer.aspx.vb" Inherits="SDT.Checker.Trailer" %>

<%@ Register TagPrefix="uc1" TagName="MovieFinder" Src="~/UserControls/MovieFinder.ascx" %>
<%@ Register TagPrefix="uc2" TagName="TrailerCollectionFinder" Src="~/UserControls/TrailerCollectionFinder.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplayPrimaryData">
        <tr>
            <td class="tdTitle" style="width: 55px">
                จอ
            </td>
            <td class="tdInput">
                <asp:DropDownList ID="ddlScreen" runat="server" Font-Names="Tahoma" Font-Size="Small"
                    Font-Bold="False" Style="font-size: x-small" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 55px">
                ภาพยนตร์
            </td>
            <td class="tdInput">
                <uc1:MovieFinder ID="MovieFinder1" runat="server" AppearOnStatus="1" InStatus="1" />
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 55px">
                ภาพยนตร์
            </td>
            <td class="tdInput">
                <uc1:MovieFinder ID="MovieFinder2" runat="server" AppearOnStatus="1" InStatus="1" />
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 55px">
                ภาพยนตร์
            </td>
            <td class="tdInput">
                <uc1:MovieFinder ID="MovieFinder3" runat="server" AppearOnStatus="1" InStatus="1" />
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 55px">
                ภาพยนตร์
            </td>
            <td class="tdInput">
                <uc1:MovieFinder ID="MovieFinder4" runat="server" AppearOnStatus="1" InStatus="1" />
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 55px">
                ชุดหนังตัวอย่าง
            </td>
            <td class="tdInput">
                <uc2:TrailerCollectionFinder ID="TrailerCollectionFinder1" runat="server" />
            </td>
        </tr>
    </table>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Label ID="lblErrorDataExist" runat="server" CssClass="labelError" Visible="False">ข้อมูลดังกล่าว 
                    มีอยู่แล้วในระบบ</asp:Label>
                <asp:Label ID="lblErrorNotSelectAnyMovie" runat="server" CssClass="labelError" Visible="False">กรุณาระบุภาพยนตร์</asp:Label>
                <asp:Label ID="lblErrorSelectDuplicate" runat="server" CssClass="labelError" Visible="False">ข้อมูลที่เลือกเป็นข้อมูลซ้ำ กรุณาตรวจสอบ</asp:Label>
                <asp:Label ID="lblErrorCollection" runat="server" CssClass="labelError" Visible="False">กรุณาเลือกชุดตัวอย่าง</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnSaveDetail" runat="server" Text="บันทึก" CssClass="ButtonDefualt"
                    Width="50px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt"
                    Width="50px" />
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnMainMenu" runat="server" Text="กลับหน้าหลัก" CssClass="ButtonDefualt"
                    Width="90px" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="trailer_no" Font-Names="Tahoma" Font-Size="7pt"
        ForeColor="#333333" GridLines="None" PageSize="25" Width="100%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField ShowHeader="False" Visible="false">
                <ItemStyle />
                <ItemTemplate>
                    <asp:LinkButton ID="btnConfirm" runat="server" CausesValidation="False" CommandArgument='<%# Bind("trailer_no") %>'
                        CommandName="Confirm" ForeColor="#FF6600" OnClientClick="return confirm('ยืนยันการทำรายการ?')"
                        Text="ยืนยัน"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="theatersub_id" HeaderText="จอ" SortExpression="theatersub_id"
                ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="8px">
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center" Width="8px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False" SortExpression="MovieName" HeaderText="ภาพยนตร์">
                <ItemStyle HorizontalAlign="Left" Width="26px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnSelect" runat="server" CausesValidation="False" CommandArgument='<% #Bind("trailer_no") %>'
                        CommandName="Select" Text='<%#Bind("MovieName") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="collection_name" HeaderText="ชุดหนังตัวอย่าง">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="lblcollection_name" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" Width="10px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("trailer_no") %>'
                        CommandName="Del" ForeColor="#FF6600" OnClientClick="return confirm('ยืนยันการลบข้อมูล?')"
                        Text="ลบ"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:HiddenField ID="hdfTrailerNo" runat="server" />
</asp:Content>
