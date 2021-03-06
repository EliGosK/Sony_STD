<%@ Page Title="แจ้งหนังออกจากโรง" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerTransaction.Master"
    CodeBehind="ConfirmMovieTerminate.aspx.vb" Inherits="SDT.Checker.ConfirmMovieTerminate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="tableDisplay">
        <tr class="labelTitle">
            <td class="tdOneCenter">
                <asp:Label ID="lblMessage" runat="server" CssClass="labelError" 
                    Text="ยังไม่สามารถ Terminate ได้ <br /> กรุณากรอกยอดรายได้ให้เป็นยอดจริงให้หมดก่อน!"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnOk" runat="server" Text="ยืนยัน" CssClass="ButtonNewMsg" Visible="False" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="ButtonDefualt" />
            </td>
        </tr>
    </table>
</asp:Content>
