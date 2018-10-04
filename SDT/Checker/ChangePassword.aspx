<%@ Page Title="เปลี่ยนรหัสผ่าน" Language="vb" AutoEventWireup="false" CodeBehind="ChangePassword.aspx.vb" MasterPageFile="~/Checker/Master/CheckerBase.Master" Inherits="SDT.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr>
            <td class="tdTitle" style="width: 110px">
                รหัสผ่านปัจจุบัน
            </td>
            <td align="left" class="tdInput">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="16" Width="100%"></asp:TextBox>
            </td>
            <td style="width: 80px"></td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 110px">
                รหัสผ่านใหม่
            </td>
            <td align="left" class="tdInput">
                <asp:TextBox ID="txtPassword_new" runat="server" TextMode="Password" Width="100%"
                    MaxLength="16" ></asp:TextBox>
            </td>
            <td align="left" style="width: 100px">
                &nbsp&nbsp&nbsp<asp:Label ID="lblHint" runat="server" Text="" Visible="False" CssClass="labelError" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 110px">
                ยืนยันรหัสผ่านใหม่
            </td>
            <td align="left" class="tdInput">
                <asp:TextBox ID="txtPassword_confirm" runat="server" TextMode="Password" Width="100%"
                    MaxLength="16"></asp:TextBox>
            </td>
            <td style="width: 80px"></td>
        </tr>

    </table>
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnOk" runat="server" Text="บันทึก" CssClass="ButtonDefualt" />
                &nbsp;
                <asp:Button ID="btnBack" runat="server" Text="กลับหน้าหลัก" CssClass="ButtonDefualt" />
                <br />
                <br />
                <asp:Label ID="lblwarning" runat="server" Text="รหัสผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง ท่านไม่สามารถเข้าระบบได้ !" Visible="false" CssClass="labelError"></asp:Label>
            </td>
        </tr>
                
    </table>
</asp:Content>