<%@ Page Title="ยืนยันการเข้าฉาย" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="ConfirmMovieRelease.aspx.vb" Inherits="SDT.Checker.ConfirmMovieRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnRelease" runat="server" Text="เข้าฉาย" CssClass="ButtonDefualt"
                    Width="60px" />
                &nbsp;<asp:Button ID="btnNotRelease" runat="server" Text="ไม่เข้าฉาย" CssClass="ButtonDefualt"
                    Width="60px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt"
                    Width="60px" />
            </td>
        </tr>
    </table>
</asp:Content>
