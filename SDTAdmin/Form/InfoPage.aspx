<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InfoPage.aspx.vb" Inherits=".InfoPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT MAnagement System - Permission Error</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
        .style1
        {
            color: #CC3300;
            font-weight: bold;
        }
    </style>
</head>
<body leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="form1" runat="server">
    <div>
    
        <span class="style1">
        <br />
        <br />
&nbsp;/!\ คุณไม่สามารถเข้าใช้งานโมดูลนี้ได้ กรุณาติดต่อเจ้าหน้าที่ดูแลระบบ.</span><br />
        <br />
        <asp:Button ID="btnOk" runat="server" Text="ตกลง" />
    
    </div>
    </form>
</body>
</html>