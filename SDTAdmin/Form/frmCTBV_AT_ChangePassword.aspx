<%@ Page title="Change Password" Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_ChangePassword.aspx.vb" Inherits=".frmCTBV_AT_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../Checker.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    <table >
        <tr>
            <td></td>
            <td align=center>
                <asp:Label ID="Label1" runat="server" Text="Change Password" CssClass=labelTitle></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px" >
                <font size="2">Current Password</font>
            </td>
            <td align="left" class="tdInput" style="width: 300px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="16" 
                    Width="100%" Font-Size="Small"></asp:TextBox>
            </td>
            <td style="width: 80px"></td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px">
                <font size="2">New Password</font>
            </td>
            <td align="left" class="tdInput" style="width: 300px">
                <asp:TextBox ID="txtPassword_new" runat="server" TextMode="Password" Width="100%"
                    MaxLength="16" Font-Size="Small" ></asp:TextBox>
            </td>
            <td align="left" style="width: 200px">
                &nbsp&nbsp&nbsp<asp:Label ID="lblHint" runat="server" Visible="False" 
                    CssClass="labelError" Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdTitle" style="width: 150px">
                <font size="2">Confirm New Password</font>
            </td>
            <td align="left" class="tdInput" style="width: 300px">
                <asp:TextBox ID="txtPassword_confirm" runat="server" TextMode="Password" Width="100%"
                    MaxLength="16" Font-Size="Small"></asp:TextBox>
            </td>
            <td style="width: 80px"></td>
        </tr>
        <tr>
            <td></td>
            <td align=center>
                <asp:Button ID="btnOk" runat="server" Text="Save" CssClass="ButtonDefualt" 
                    Width="80" Font-Size="X-Small" />&nbsp;<asp:Button ID="btnBack" runat="server" Text="Main Menu" 
                    CssClass="ButtonDefualt" Width="80" Font-Size="X-Small" />
                
            <td style="width: 80px"></td>
        </tr>
        <tr>
            <td colspan=3 align=center>
            <br />
                <asp:Label ID="lblwarning" runat="server" 
                    Text="รหัสผู้ใช้ หรือ รหัสผ่าน ไม่ถูกต้อง ท่านไม่สามารถเข้าระบบได้ !" 
                    Visible="False" CssClass="labelError" Font-Size="X-Small"></asp:Label>
            </td>
        </tr>
</table>
    
<br />

           
           
                
    
    
    </div>
    </form>
</body>
</html>
