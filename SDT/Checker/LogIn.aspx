<%@ Page Title="เข้าสู่ระบบ SDT Checker" Language="vb" AutoEventWireup="false" MasterPageFile="~/Checker/Master/CheckerBase.Master"
    CodeBehind="LogIn.aspx.vb" Inherits="SDT.Checker.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:HiddenField ID="hdResponse" runat="server" />
    <script language="Javascript" src="../js/Duo-Web-v1.bundled.js" type="text/javascript"></script>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <script>
        function calledFn(request, host) {
            Duo.init({
                'host': host,
                'sig_request': request,
                'post_action': 'PreCondition.aspx'
            });
        }
        function calledFn2(request, host) {
            Duo.init({
                'host': host,
                'sig_request': request,
                'post_action': 'ChangePassword.aspx'
            });
        }
    </script>	  
    <table class="tableDisplay">
        <tr>
            <td class="tdTitle" style="width: 60px">
                ผู้ใช้
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtUser" runat="server" MaxLength="6" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 60px">
                รหัสผ่าน
            </td>
            <td class="tdInput">
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="90%"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div id="duo_div" style="display: none">
        <iframe id="duo_iframe" width="620" height="330" frameborder="0"></iframe>		
    </div>  
    <br />
    <table class="tableDisplay">
        <tr>
            <td class="tdOneCenter">
                <asp:Button ID="btnLogin" runat="server" Text="เข้าสู่ระบบ" CssClass="ButtonDefualt" />
                <br />
                <asp:Button ID="btnTest" runat="server" Text="Test" CssClass="ButtonNewMsg" 
                    Visible="False" />
                <br />
                <div Style="display:none">
                    <asp:Button ID="btnLogin1" runat="server" Text="เข้าสู่ระบบ"  />
                </div>
                <asp:Label ID="lblError" runat="server" CssClass="labelError" Text="รหัสผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง ท่านไม่สามารถเข้าระบบได้ !"
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
