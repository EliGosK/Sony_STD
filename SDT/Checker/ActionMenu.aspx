<%@ Page Title="เมนูหลัก" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerBase.Master"
    CodeBehind="ActionMenu.aspx.vb" Inherits="SDT.Checker.ActionMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td>
                <asp:Button ID="btnMessage" runat="server" CssClass="ButtonDefualt" Text="ข้อความ"
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnReport" runat="server" CssClass="ButtonDefualt" Text="แจ้งรายได้/บัตร"
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnProblem" runat="server" CssClass="ButtonDefualt" Text="แจ้งปัญหา"
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnTrailerCollection" runat="server" CssClass="ButtonDefualt" Text="กำหนดชุดหนังตัวอย่าง"
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnMovieTrailer" runat="server" CssClass="ButtonDefualt" Text="แจ้งหนังตัวอย่าง"
                    Width="145px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnExit" runat="server" CssClass="ButtonDefualt" Text="ออกจากระบบ"
                    Width="145px" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
