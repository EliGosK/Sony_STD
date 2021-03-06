<%@ Page Title="รายละเอียดบัตร" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="SendTicketType.aspx.vb" Inherits="SDT.Checker.SendTicketType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    แจ้งรายได้ของวันที่
    <asp:Label ID="lblRevenueDate" runat="server" CssClass="labelError"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblNotFoundAnyTicketByMovie" runat="server" CssClass="labelError"
        Text="ไม่พบชนิดบัตร ที่สามารถใส่ค่าได้&lt;BR&gt;กรุณาแจ้ง Admin" Visible="False"></asp:Label>
    <br />
    <asp:GridView ID="grdOwner" runat="server" AutoGenerateColumns="False" CellPadding="0"
        Font-Names="Tahoma" ForeColor="#333333" GridLines="Vertical" Width="100%" Font-Size="XX-Small">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="theatersub_id" HeaderText="จอ" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="revenue_time" HeaderText="รอบ" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="film_type_sound_header_group" HeaderText="ฟิล์ม" ItemStyle-HorizontalAlign="Center"
                ItemStyle-VerticalAlign="Middle">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="revenue_amount_no_cap" DataFormatString="{0:#,##0}" HeaderText="รายได้"
                ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="revenue_adms_with_free_ticket" DataFormatString="{0:#,##0}"
                HeaderText="ผู้ชม" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
            </asp:BoundField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <br />
    <asp:Panel ID="pnlRevenue" runat="server">
        <table class="tableDisplay">
            <tr>
                <td class="labelError">
                    รายการบัตร
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdTicketType" runat="server" AutoGenerateColumns="False" CellPadding="0"
            Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="#333333" GridLines="Vertical"
            Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="ticket_type_name" HeaderText="รายการ" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="quantity" DataFormatString="{0:#,##0}" HeaderText="จำนวน"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("key_id") %>'
                            CommandName="Del" OnClientClick="return confirm('ยืนยันการลบข้อมูล?')" ImageUrl="../images/icon_remove.gif">
                        </asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <br />
        <table class="tableDisplay">
            <tr>
                <td class="tdOneLeft">
                    รวม&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblCountTicketType" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;ใบ
                </td>
            </tr>
        </table>
        <br />
        <asp:Label ID="lblErrorCountRevernue" runat="server" CssClass="labelError" Text="จำนวนบัตรไม่ถูกต้อง<br />กรุณาตรวจสอบ !"
            Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblAction" runat="server" Text="เพิ่มรายการ" CssClass="labelFocus"></asp:Label>
        <br />
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle">
                    รายการ
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlTicketTypeByMovie" runat="server" CssClass="normalFont"
                        Width="100%">
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle">
                    ที่นั่ง
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtQuantity" runat="server" MaxLength="3" Width="100px"></asp:TextBox>
                    <asp:Button ID="btnUpdateDetail" runat="server" CssClass="ButtonDefualt" Text="ส่ง"
                        Width="30px" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblError0" runat="server" CssClass="labelError" Text="กรุณาใส่ค่าที่มากกว่า 0 !"
            Visible="False"></asp:Label>
        <br />
    </asp:Panel>
    <br />
    <asp:Button ID="btnBackToSendRevenue" runat="server" Text="ไปหน้าแจ้งรายได้" CssClass="ButtonDefualt"
        Width="120px" />
    <br />
    <asp:Button ID="btnCancel" runat="server" Text="ไปหน้าเลือกภาพยนตร์" CssClass="ButtonDefualt"
        Width="120px" />
    <asp:HiddenField ID="hdfPrice" runat="server" />
</asp:Content>
