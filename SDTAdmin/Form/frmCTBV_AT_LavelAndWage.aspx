<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_LavelAndWage.aspx.vb"
    Inherits=".frmCTBV_AT_LavelAndWage" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SDT Management Information System - Admin Tools Menu</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <style type="text/css">
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:visited
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:hover
        {
            color: #cccccc;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        A:active
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        #Table2
        {
            height: 216px;
        }
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                <font color="#000099" face="Tahoma" size="2"><strong>
                    <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                </strong></font>
            </td>
            <td width="47%" align="right" bgcolor="#ffffff" style="height: 23px">
                <table width="58" border="0">
                    <tr>
                        <td width="52">
                            <asp:ImageButton ID="imbOut" runat="server" ImageUrl="~/images/Exit.png" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style10">
                            Log Out
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr background="../images/BG7.jpg">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg">
                <span class="style2">&nbsp;<a href="frmCTBV_Menu.aspx">Main Menu </a>&gt;&nbsp;<a
                    href="frmCTBV_AT_Main.aspx">Admin Tools </a>&gt; Checker Level and Wage</span>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                Checker Level and Wage</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center">
                            <table border="0" cellspacing="6" style="width: 180px">
                                <tr>
                                    <td bordercolor="#f0cd8c">
                                        <asp:ImageButton ID="imgbtnLevel" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Checker Level" 
                                            ImageUrl="~/images/MenuWage1.jpg" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imbtnMTC0" runat="server" ImageUrl="~/images/MenuWage2.jpg"
                                            BorderColor="#FF9900" BorderStyle="Dotted" BorderWidth="1px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="imgbtmFormer" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Former Wage" 
                                            ImageUrl="~/images/MenuWage3.jpg" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgbtnPresent" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Present Wage" 
                                            ImageUrl="~/images/MenuWage4.jpg" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="imgbtnConfig" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Collect Report Config" 
                                            ImageUrl="~/images/MenuWage5.jpg" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgbtnSession" runat="server" BorderColor="#FF9900" BorderStyle="Dotted"
                                            BorderWidth="1px" AlternateText="Wage by Session Config" 
                                            ImageUrl="~/images/MenuWage6.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

