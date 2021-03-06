<%@ Page Title="บัตรฟรีและปัดยอด" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="SendFreeTicketAndPerCap.aspx.vb" Inherits="SDT.Checker.SendFreeTicketAndPerCap"
    EnableEventValidation="false" %>

<%@ Import Namespace="SDTCommon.Extensions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function changeHeader() {
            //alert("Changed");
            //var data = 'ticket_cap_id,ticket_cap_name,list_price,default_price;1,บัตรฟรีคิดเงิน,70%2C80%2C90%2C100%2C110%2C120%2C130%2C140%2C150%2C160%2C170%2C180%2C190%2C200%2C210%2C220%2C230%2C240%2C250%2C260%2C270%2C280%2C290%2C300,100;';

            var ddlDetail = document.getElementById('<%= ddlPriceList.ClientID %>');
            for (var i = ddlDetail.options.length - 1; i >= 0; i--) {
                ddlDetail.remove(i);
            }

            var ddlHeader = document.getElementById('<%= ddlFreeTicketByMovie.ClientID %>');

            var data = '<%= GetHidenData() %>';
            var lines = data.split(/[;]/);
            for (var j = 0; j < lines.length; j++) {
                var fields = lines[j].split(/[,]/);
                if (fields[0] == ddlHeader.options[ddlHeader.selectedIndex].value) {

                    var priceList = fields[2].replace(/%2C/gi, ",");
                    var priceLines = priceList.split(/[,]/);
                    for (var k = 0; k < priceLines.length; k++) {
                        var newItem = document.createElement('OPTION');
                        newItem.value = priceLines[k];
                        newItem.text = priceLines[k];
                        ddlDetail.add(newItem);
                    }
                    ddlDetail.value = fields[3];
                    break;
                }
            }
            getDropDownValue();
        }
        function getDropDownValue() {
            var theater = document.getElementById('<%= ddlPriceList.ClientID %>');
            var hiddenElementRef = document.getElementById('<%= hdfPrice.ClientID %>');
            hiddenElementRef.value = theater.options[theater.selectedIndex].value;
            //<%= ClientScript.GetPostBackEventReference(ddlPriceList, string.Empty) %>;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    แจ้งรายได้ของวันที่
    <asp:Label ID="lblRevenueDate" runat="server" CssClass="labelError"></asp:Label>
    <br />
    <asp:Panel ID="pnlErrorRevenue" runat="server" Visible="False">
        <br />
        <asp:Label ID="lblErrorSumRevenue" runat="server" CssClass="labelError" Text="ยอดรายได้ไม่ตรง เนื่องจากมีการเปลี่ยนวันที่ไม่คิดเงินของบัตร<br />กรุณากด Update !"></asp:Label>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="ButtonNewMsg" Width="120px" />
        <br />
    </asp:Panel>
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
    <table class="tableDisplay">
        <tr>
            <td class="labelFocus">
                รายการไม่คิดเงิน
            </td>
        </tr>
    </table>
    <table class="tableDisplay">
        <tr>
            <td class="tdTitle" style="width: 150px">
                บัตรฟรีทั่วไป
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtFreeTicketNormCount" runat="server" MaxLength="3" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px">
                บัตรฟรีพิเศษ
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtFreeTicketSpecialCount" runat="server" MaxLength="3" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px">
                บัตรฟรีพิเศษเกิน 5 ที่
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtFreeMore5Count" runat="server" MaxLength="3" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px">
                เกิน 5 ที่รวมเป็นเงิน
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtFreeMore5Sum" runat="server" MaxLength="5" Width="100%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnUpdateHeader" runat="server" Text="แจ้งรายการไม่คิดเงิน" CssClass="ButtonDefualt"
        Width="120px" />
    <br />
    <br />
    <asp:Label ID="lblNotFoundAnyTicketByMovie" runat="server" CssClass="labelError"
        Text="ไม่พบรายการบัตร/ปัดยอด&lt;BR&gt;ที่สามารถใส่ค่าได้&lt;BR&gt;กรุณาแจ้ง Admin"
        Visible="False"></asp:Label>
    <br />
    <asp:Panel ID="pnlRevenue" runat="server">
        <table class="tableDisplay">
            <tr>
                <td class="labelError">
                    รายการคิดเงิน
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdFreeTicketRevenue" runat="server" AutoGenerateColumns="False"
            CellPadding="0" Font-Names="Tahoma" Font-Size="XX-Small" ForeColor="#333333"
            GridLines="Vertical" Width="100%">
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="ticket_cap_name" HeaderText="รายการ" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="available_to" HeaderText="คิดเงินถึงวันที่" ItemStyle-HorizontalAlign="Center"
                    ItemStyle-VerticalAlign="Middle" DataFormatString="{0:dd/MM/yyyy}">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="price" DataFormatString="{0:#,##0}" HeaderText="ราคา"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="quantity" DataFormatString="{0:#,##0}" HeaderText="จำนวน"
                    ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="summary" DataFormatString="{0:#,##0}" HeaderText="รวม"
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
                    เงินบัตรฟรี&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblSumFreeTicketRevenue" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td class="tdOneLeft">
                    เงินปัดยอด&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblSumCapRevenue" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td class="tdOneLeft">
                    รวมคิดเงิน&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblFreeTicketAndCapSumRevenue" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td class="tdOneLeft">
                    ยอดรายได้รวม&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblSumRevenue" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;บาท
                </td>
            </tr>
            <tr>
                <td class="tdOneLeft">
                    ที่นั่งคงเหลือ&nbsp;
                </td>
                <td class="tdOneRight">
                    <asp:Label ID="lblRemainViewer" runat="server" CssClass="labelTitle">0</asp:Label>
                </td>
                <td class="tdOneLeft">
                    &nbsp;ที่นั่ง
                </td>
            </tr>
        </table>
        <asp:Label ID="lblErrorCount" runat="server" CssClass="labelError" Text="กรอกบัตรเกินจำนวนคน !"
            Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAction" runat="server" Text="เพิ่มรายการ" CssClass="labelFocus"></asp:Label>
        <br />
        <table class="tableDisplay">
            <tr>
                <td class="tdTitle">
                    รายการ
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlFreeTicketByMovie" runat="server" CssClass="normalFont"
                        Width="100%">
                        <asp:ListItem> </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdTitle">
                    ราคา
                </td>
                <td class="tdInput">
                    <asp:DropDownList ID="ddlPriceList" runat="server" CssClass="normalFont" Width="100%"
                        OnChange="getDropDownValue()">
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
    <asp:Button ID="btnCompleteAll" runat="server" Text="ปิดยอด Cap" CssClass="ButtonNewMsg"
        Width="120px" />
    <br />
    <br />
    <asp:Button ID="btnBackToSendRevenue" runat="server" Text="ไปหน้าแจ้งรายได้" CssClass="ButtonDefualt"
        Width="120px" />
    <br />
    <asp:Button ID="btnCancel" runat="server" Text="ไปหน้าเลือกภาพยนตร์" CssClass="ButtonDefualt"
        Width="120px" />
    <asp:HiddenField ID="hdfPrice" runat="server" />
</asp:Content>
