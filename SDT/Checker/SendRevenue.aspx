<%@ Page Title="แจ้งรายได้ภาพยนตร์" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="SendRevenue.aspx.vb" Inherits="SDT.Checker.SendRevenue" %>

<%@ Import Namespace="SDTCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    แจ้งรายได้ของวันที่
    <asp:Label ID="lblRevenueDate" runat="server" CssClass="labelError"></asp:Label>
    <asp:Panel ID="pnlSummayOwner" runat="server">
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
                <asp:TemplateField>
                    <HeaderTemplate>
                        แจ้ง<br />
                        ยอด
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="hplStatus" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'>
                            <asp:Image ID="imgStatus" runat="server" ImageUrl="../images/icon_wait.gif" ImageAlign="Middle" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Cap
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="hplFreeTicket" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkToFreeTicket") %>'>
                            <asp:Image ID="imgFreeTicket" runat="server" ImageUrl="../images/icon_ticket_rev.gif"
                                ImageAlign="Middle" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        แยก<br />
                        บัตร
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="hplTicketType" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkToTicketType") %>'>
                            <asp:Image ID="imgTicketType" runat="server" ImageUrl="../images/icon_ticket_type.gif"
                                ImageAlign="Middle" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("revenueid") %>'
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
        <asp:Label ID="lblSumScreenFilm" runat="server" CssClass="labelTitle">แยกตามจอ/ฟิล์ม</asp:Label>
        <asp:GridView ID="grdOwnerScreenFilm" runat="server" AutoGenerateColumns="False"
            CellPadding="0" Font-Names="Tahoma" ForeColor="#333333" GridLines="Vertical"
            Width="100%" Font-Size="XX-Small">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="theatersub_id" HeaderText="จอ" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="film_type_sound_header_group" DataFormatString="{0:#,##0}"
                    HeaderText="ฟิล์ม" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SumRevenueReport" DataFormatString="{0:#,##0}" HeaderText="รายได้"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SumTicketRevenue" DataFormatString="{0:#,##0}" HeaderText="Cap"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ActualRevenue" DataFormatString="{0:#,##0}" HeaderText="รวม"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SumViewerReport" DataFormatString="{0:#,##0}" HeaderText="ผู้ชม"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ActualViewer" DataFormatString="{0:#,##0}" HeaderText="ผู้ชมคิดเงิน"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
        <asp:Label ID="lblSumOwnerAll" runat="server" CssClass="labelTitle">สรุปยอดทั้งหมด</asp:Label>
        <asp:GridView ID="grdOwnerAll" runat="server" AutoGenerateColumns="False" CellPadding="0"
            Font-Names="Tahoma" ForeColor="#333333" GridLines="Vertical" Width="100%" Font-Size="XX-Small">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="SumRevenueReport" DataFormatString="{0:#,##0}" HeaderText="รายได้"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SumTicketRevenue" DataFormatString="{0:#,##0}" HeaderText="Cap"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ActualRevenue" DataFormatString="{0:#,##0}" HeaderText="รวม"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SumViewerReport" DataFormatString="{0:#,##0}" HeaderText="ผู้ชม"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="ActualViewer" DataFormatString="{0:#,##0}" HeaderText="ผู้ชมคิดเงิน"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlSummayComp" runat="server">
        <asp:GridView ID="grdCompetitor" runat="server" AutoGenerateColumns="False" CellPadding="0"
            Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="#333333" GridLines="Vertical"
            Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="film_type_sound_header_group" HeaderText="ฟิล์ม" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="amount" DataFormatString="{0:#,##0}" HeaderText="รายได้"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="adms" DataFormatString="{0:#,##0}" HeaderText="ผู้ชม"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="count_screen" HeaderText="จำนวนจอ" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="count_session" HeaderText="จำนวนรอบ" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        แจ้ง<br />
                        ยอด
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="hplStatus" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "LinkTo") %>'>
                            <asp:Image ID="imgStatus" runat="server" ImageUrl="../images/icon_wait.gif" ImageAlign="Middle" />
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("revenue_id") %>'
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
        <table class="tableDisplay">
            <tr>
                <td class="tdOneRight">
                    รวมรายได้&nbsp;<asp:Label ID="lblSumCompRevenue" runat="server" CssClass="labelTitle">0</asp:Label></td>
                <td class="tdOneLeft">
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td class="tdOneRight">
                    ผู้ชมทั้งหมด&nbsp;<asp:Label ID="lblSumCompViewer" runat="server" CssClass="labelTitle">0</asp:Label></td>
                <td class="tdOneLeft">
                    &nbsp;ที่นั่ง
                </td>
            </tr>
            <tr>
                <td class="tdOneRight">
                    จำนวนจอ&nbsp;<asp:Label ID="lblSumCompScreen" runat="server" CssClass="labelTitle">0</asp:Label></td>
                <td class="tdOneLeft">
                    &nbsp;จอ
                </td>
            </tr>
            <tr>
                <td class="tdOneRight">
                    &nbsp;จำนวนรอบ&nbsp;<asp:Label ID="lblSumCompSession" runat="server" CssClass="labelTitle">0</asp:Label></td>
                <td class="tdOneLeft">
                    &nbsp;รอบ
                </td>
            </tr>
            <tr>
                <td colspan="2" class="tdOneCenter">
                    <asp:Button ID="btnDeleteHeader" runat="server" Text="ลบยอดเบื้องต้น" CssClass="ButtonDefualt"
                        Width="100px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Label ID="lblAction" runat="server" Text="เพิ่มรายการ" CssClass="labelFocus"></asp:Label>
    <asp:Panel ID="pnlOwner" runat="server">
        <table class="tableDisplay">
            <% 
                If GetRequest(ParamList.MovieTypeId) = 1 Then
            %>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    จอที่
                </td>
                <td class="labelTitle">
                    <asp:DropDownList ID="ddlScreen" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    รอบ/เวลา
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlHour" runat="server" Width="55px">
                    </asp:DropDownList>
                    :<asp:DropDownList ID="ddlMinute" runat="server" Width="55px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    ประเภทการฉาย
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlType" runat="server" Width="100%">
                        <asp:ListItem Value="ปกติ">ปกติ</asp:ListItem>
                        <asp:ListItem Value="รอบพิเศษ">รอบพิเศษ</asp:ListItem>
                        <asp:ListItem Value="รอบเหมา">รอบเหมา</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <%
            End If
            %>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlCompRevenueType" runat="server">
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle" style="width: 85px">
                    ลักษณะการแจ้ง
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlCompRevenueType" runat="server" Width="100%" AutoPostBack="True">
                        <asp:ListItem Value="3">ยอดรวมเบื้องต้น</asp:ListItem>
                        <asp:ListItem Value="2">แยกตามระบบฟิล์ม</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetail" runat="server">
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle" style="width: 85px">
                    สถานะ
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlStatus" runat="server" Width="100%">
                        <asp:ListItem Value="3">ยอดเบื้องต้น</asp:ListItem>
                        <asp:ListItem Value="2">ยอดจริง</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    ระบบฟิล์ม/เสียง
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlFilmTypeSound" runat="server" Width="100%">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlDetailCompetitor" runat="server">
            <table class="tableDisplay">
                <tr>
                    <td class="tdTitle" style="width: 85px">
                        จำนวนจอ<br />
                    </td>
                    <td class="tdInput">
                        <asp:TextBox ID="txtCountScreen" runat="server" Width="100%" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdTitle" style="width: 85px">
                        จำนวนรอบ<br />
                    </td>
                    <td class="tdInput">
                        <asp:TextBox ID="txtCountSession" runat="server" Width="100%" MaxLength="6"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle" style="width: 85px">
                    รายได้(บาท)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtRevenue" runat="server" Width="100%" MaxLength="9"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    ผู้ชม(ที่นั่ง)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtViewer" runat="server" Width="100%" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlCompetitorPreData" runat="server">
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle" style="width: 85px">
                    จำนวนจอ
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllScreen" runat="server" Width="100%" MaxLength="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    จำนวนรอบ
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllSession" runat="server" Width="100%" MaxLength="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    รายได้(บาท)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllRevenue" runat="server" Width="100%" MaxLength="9"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdTitle" style="width: 85px">
                    ผู้ชม(ที่นั่ง)
                </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtAllViewer" runat="server" Width="100%" MaxLength="4"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="btnCancelEdit" runat="server" Text="ยกเลิกการแก้ไข" CssClass="ButtonDefualt"
        Visible="False" Width="100px" />
    <br />
    <asp:Label ID="lblErrorDuplicate" runat="server" CssClass="labelError" Visible="False"
        Text="โรงและรอบ หรือ ระบบฟิล์มที่เลือก มีข้อมูลแล้ว<br />กรุณาตรวจสอบ !"></asp:Label>
    <asp:Label ID="lblErrorRevenue" runat="server" CssClass="labelError" Visible="False"
        Text="ยอดรายได้ไม่สัมพันธ์กับจำนวนคน<br />กรุณาตรวจสอบ !"></asp:Label>
    <asp:Label ID="lblErrorHaveDetail" runat="server" CssClass="labelError" Visible="False"
        Text="มีการแจ้งยอดแยกตามระบบฟิล์มไปแล้ว<br />ไม่สามารถแก้ยอดรวมเบื้องต้นได้ !"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSend" runat="server" Text="ส่ง" CssClass="ButtonDefualt" Width="50px" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="กลับไปเลือกภาพยนตร์" CssClass="ButtonDefualt"
        Width="120px" />
</asp:Content>
