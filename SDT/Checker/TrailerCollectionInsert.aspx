<%@ Page Title="กำหนดชุดหนังตัวอย่าง" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="TrailerCollectionInsert.aspx.vb" Inherits="SDT.Checker.TrailerCollectionInsert" %>

<%@ Register TagPrefix="uc1" TagName="TrailerFinder" Src="~/UserControls/TrailerFinder.ascx" %>
<%@ Register TagPrefix="uc2" TagName="TrailerCollectionFinder" Src="~/UserControls/TrailerCollectionFinder.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplayPrimaryData">
        <tr>
            <td class="tdTitle" style="width: 70px">
                ชื่อชุด
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtCollectionName" runat="server" MaxLength="100" Font-Names="Tahoma"
                    Width="90px" Font-Size="8pt" Font-Bold="True"></asp:TextBox>
                <asp:Label ID="lblRequire" runat="server" Style="font-size: 8pt; color: #FF0000"
                    Text="*"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 70px">
                คัดลอกจาก
            </td>
            <td class="tdInput">
                <uc2:TrailerCollectionFinder ID="TrailerCollectionFinder1" runat="server" />
            </td>
        </tr>
    </table>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Label ID="lblErrorCompleteTextBox" runat="server" CssClass="labelError" Visible="False">กรุณาระบุข้อมูลให้ครบถ้วน(*)</asp:Label>
                <asp:Label ID="lblErrorDataExist" runat="server" CssClass="labelError" Visible="False">ชื่อชุดนี้มีอยู่แล้วในระบบ</asp:Label>
                <br />
                <asp:Button ID="btnSave" runat="server" Text="บันทึก" 
                    CssClass="ButtonDefualt" />
                &nbsp;
                <asp:Button ID="btnInsertMore" runat="server" Text="เพิ่มชุด ต.ย." 
                    CssClass="ButtonDefualt" />
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnBackToTrailerCollection" runat="server" Text="ย้อนกลับ" 
                    CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
    <table class="tableDisplayPrimaryData">
        <tr>
            <td class="tdTitle" style="width: 70px">
                หนังตัวอย่าง
            </td>
            <td class="tdInput">
                <uc1:TrailerFinder ID="TrailerFinder1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 70px">
                ลำดับที่
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtSeqNo" runat="server" MaxLength="100" Font-Names="Tahoma" Font-Bold="True"
                    Font-Size="8pt"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Label ID="lblErrorNotFoundMovie" runat="server" CssClass="labelError" Visible="False">กรุณาระบุภาพยนตร์</asp:Label>
                <asp:Label ID="lblErrorMovieExist" runat="server" CssClass="labelError" Visible="False">ภาพยนตร์เรื่องนี้มีอยู่แล้วในระบบ</asp:Label>
                <asp:Label ID="lblErrorInvalidSeq" runat="server" CssClass="labelError" Visible="False">ระบุลำดับที่ไม่ถูกต้อง</asp:Label>
                <asp:Label ID="lblErrorSeqExist" runat="server" CssClass="labelError" Visible="False">ลำดับที่ดังกล่าวมีอยู่แล้วในระบบ</asp:Label>
                <asp:Label ID="lblErrorInvalidSeqNo" runat="server" CssClass="labelError" Visible="False">กรุณาระบุลำดับที่</asp:Label>
                <asp:Label ID="lblErrorAll" runat="server" CssClass="labelError" Visible="False">ข้อมูลไม่ถูกต้อง กรุณาเลือกใหม่</asp:Label>
                <br />
                <asp:Button ID="btnSaveDetail" runat="server" Text="บันทึก" CssClass="ButtonDefualt" />
                &nbsp;
                <asp:Button ID="btnCancelSave" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="seq_no" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#333333"
        GridLines="None" PageSize="25" Width="100%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="seq_no" HeaderText="ลำดับ" SortExpression="seq_no" ItemStyle-Width="25px"
                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left" Width="25px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField ShowHeader="False" HeaderText="ชื่อหนังตัวอย่าง" SortExpression="MovieName"
                HeaderStyle-HorizontalAlign="Left">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                <ItemStyle HorizontalAlign="Left" Font-Size="7pt" />
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument='<%# Bind("seq_no") %>'
                        CommandName="Select" Text='<%# Bind("MovieName") %>'></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle HorizontalAlign="Left" Width="20px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("seq_no") %>'
                        CommandName="Del" ForeColor="#FF6600" Text="ลบ" OnClientClick="return confirm('ยืนยันการลบข้อมูล?')"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:HiddenField ID="hdfCollectionNo" runat="server" />
    <asp:HiddenField ID="hdfAction" runat="server" />
    <asp:HiddenField ID="hdfSelectedSeqNo" runat="server" />
    <asp:HiddenField ID="hdfSelectedMovieId" runat="server" />
    <div id="DivInsertMovie" runat="server" style="position: absolute; border: 2px solid #FFB3B3;
        background-color: #FFF0F0; top: 200px; left: 10px; width: 220px; height: 90px;">
        <br />
        <table class="tableDisplay">
            <tr>
                <td class="tdOneCenter">
                    <asp:Label ID="lblConfirmRetreat" runat="server" Text="ต้องการร่นลำดับที่ต่อๆไปหรือไม่ ?"
                        CssClass="labelError"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="tdOneCenter">
                    <asp:Button ID="btnInsert" runat="server" Text="ยืนยัน" CssClass="ButtonDefualt" />
                    &nbsp;<asp:Button ID="btnCancelInsert" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
