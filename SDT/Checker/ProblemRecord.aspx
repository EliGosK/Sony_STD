<%@ Page Title="แจ้งปัญหา" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="ProblemRecord.aspx.vb" Inherits="SDT.Checker.ProblemRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        CellPadding="4" DataKeyNames="movie_id" Font-Names="Tahoma" Font-Size="X-Small"
        ForeColor="#333333" Width="100%">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" Width="20px" />
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    เลือกภาพยนตร์
                </HeaderTemplate>
                <ItemStyle HorizontalAlign="Left" Width="50px" />
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Bind("MovieName") %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="problem" HeaderText="ปัญหาที่พบ" ItemStyle-HorizontalAlign="Left"
                ItemStyle-VerticalAlign="Top"></asp:BoundField>
            <asp:TemplateField ShowHeader="False">
                <ItemStyle HorizontalAlign="Center" Width="20px" />
                <ItemTemplate>
                    <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("movie_id") %>'
                        CommandName="Delete" ForeColor="#FF6600" Text="Clear"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:Label ID="lblProblem" runat="server" CssClass="labelTitle">ปัญหาที่พบ</asp:Label>
    <asp:TextBox ID="txtProblem" runat="server" Width="100%" MaxLength="500" TextMode="MultiLine"
        Height="80px"></asp:TextBox>
    <table class="tableDisplay">
        <tr class="labelTitle">
            <td class="tdOneCenter">
                <asp:Label ID="lblMessage" runat="server" CssClass="labelError" Text="กรุณาเลือกภาพยนต์ และกรอกปัญหาที่พบ !"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnOk" runat="server" Text="แจ้งปัญหา" CssClass="ButtonNewMsg" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="กลับหน้าเมนู" CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
</asp:Content>
