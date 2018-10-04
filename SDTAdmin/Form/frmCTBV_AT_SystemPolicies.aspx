<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_SystemPolicies.aspx.vb" Inherits=".frnCTBV_AT_SystemPolicies" %>
<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SDT Management Information System - System Policies</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <script language="javascript" type="text/javascript" src="../js/jquery-1.9.1.js" ></script>
    <script language="javascript" type="text/javascript" src="../js/jquery-ui-1.10.3.custom.js" ></script>
    <link href="../js/jquery-ui-1.10.4.css" type="text/css" rel="stylesheet" />


</head>

<script type="text/javascript">
    $(document).ready(function() {
        $("#txtSpinThreshold").spinner({
            min: 0, max: 999, step: 1
        });
        $("#txtSpinDuration").spinner({
            min: 0, max: 99999, step: 1
        });
        $("#txtSpinReset").spinner({
            min: 0, max: 99999, step: 1
        });
        
    });
    </script>
<style type="text/css">
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
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
        .style10
        {
            font-weight: bold;
            font-size: 12px;
            color: #ff0000;
            font-family: "Tahoma";
        }
        .style15
        {
            font-weight: bold;
            font-size: 16px;
            font-family: "Tahoma";
            color: #666666;
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
        }
        .style24
        {
            font-size: 14px;
        }
        .style28
        {
            font-size: 14;
        }
        .style31
        {
            font-size: 10px;
        }
        .style32
        {
            color: #FF0000;
        }
        .style33
        {
            font-family: "Tahoma";
        }
        .style40
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 27px;
            text-align: right;
        }
        .style50
        {
            width: 59px;
        }
        .style60
    {
        height: 22px;
    }
    </style>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" class="style60">
                <font face="Tahoma"><font size="2"><font color="#000099"><strong>
                    <uc1:ctbvctltop ID="CtbvCtlTop1" runat="server"></uc1:ctbvctltop>
                </strong></font></font></font>
            </td>
            <td width="47%" align="right" bgcolor="#ffffff" class="style60">
                <table width="58" border="0">
                    <tr>
                        <td width="52">
                            <a href="frmCTBV_Login.aspx">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                            </a>
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
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg"
                class="style16">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a></b>&gt;<b><a href="frmCTBV_AT_Main.aspx">
                    Admin Tools </a>&gt; System Policies</b>
            </td>
        </tr>
        <tr>
            <td height="281" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <font size="2"><font color="#000000"><font face="Tahoma" size="1"><strong></strong></font>
                </font></font>
                <table width="100%" height="277" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                &nbsp;System Policies</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="239" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <table border="0" cellspacing="0" style="width: 100%">
                                                    <tr bgcolor="#F0DFD0">
                                                        <td width="40%" height="50">
                                                            <div align="right" class="style20" style="color:#000000">
                                                                <asp:Label ID="lblUserId" runat="server" Text="Account Lockout Threshold :"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td width="10%">
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtSpinThreshold" runat="server" MaxLength="3"
                                                                Width="90px"></asp:TextBox>
                                                            </span></span>
                                                        </td>
                                                        <td width="10%">
                                                            <div align="left"><span class="style20" >
                                                            <asp:Label ID="Label2" runat="server" Text="Time(s)"></asp:Label></span><span class="style32">*</span></div>
                                                        </td>
                                                        <td width="40%">
                                                            <div align="left" class="style31">
                                                                <asp:Label ID="Label1" runat="server" Text="You can set a value from 1 to 999 failed sign-in attemps, or 0 to never locked account."></asp:Label></div>
                                                        </td>
                                                   </tr>
                                                   <tr bgcolor="#F0DFD0">
                                                        <td width="40%" height="50">
                                                            <div align="right" class="style24 style33" style="color:#000000">
                                                                Account Logout Duration :</div>
                                                        </td>
                                                        <td width="10%>
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtSpinDuration" runat="server" MaxLength="5" Width="90px" ></asp:TextBox></span></span>
                                                        </td>
                                                        <td width="10%">
                                                            <div align="left"><span class="style20">
                                                            <asp:Label ID="Label3" runat="server" Text="Minute(s)"></asp:Label></span><%--<span class="style32">*</span>--%></div>
                                                        </td>
                                                        <td width="40%">
                                                            <div align="left" class="style31">
                                                                <asp:Label ID="Label4" runat="server" Text="You can set a value from 1 to 99,999 minutes, or 0 only an administrator can unlock the account.
                                                                If Account Lockout Threshold is not zero, then you have to specify this value."></asp:Label></div>
                                                        </td>
                                                   </tr>
                                                   <tr bgcolor="#F0DFD0">
                                                        <td class="style40" width="40%" height="50">
                                                            <div align="right" class="style24 style33" style="color:#000000">
                                                                Reset Account Logout Threshold Count After :</div>
                                                        </td>
                                                        <td width="10%" height="50">
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtSpinReset" runat="server" MaxLength="5" Width="90px"></asp:TextBox></span></span>
                                                        </td>
                                                        <td width="10%"> 
                                                            <div align="left"><span class="style20">
                                                            <asp:Label ID="Label5" runat="server" Text="Minute(s)"></asp:Label></span><%--<span class="style32">*</span>--%></div>
                                                        </td>
                                                        <td width="40%" class="style40">
                                                            <div align="left" class="style31">
                                                                <asp:Label ID="Label6" runat="server" Text="You can set a value from 1 to 99,999 minutes, or 0
                                                                or empty to not use this data. If Account Lockout Threshold is not zero, then you have to specify this 
                                                                value and its value must be less than or equal to Account Logout Duration."></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                </table></asp:Panel><asp:Panel ID="Panel2" runat="server">
                                                <table width="100%" border="0" cellspacing="0">
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style16" colspan="2">
                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" style="height: 31px;
                                                                width: 120px">
                                                                <tr>
                                                                    <td class="style50">
                                                                        <div align="center">
                                                                            <asp:ImageButton ID="imbSaveClose" runat="server" AlternateText="SAVE" 
                                                                                ImageUrl="~/images/SaveCCC.png" />
                                                                        </div>
                                                                    </td>
                                                                    <td align="right" width="66">
                                                                        <asp:ImageButton ID="imbCancel" runat="server" AlternateText="BACK" 
                                                                            ImageUrl="~/images/BackCCC.png" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        
                                                        <td class="style40">
                                                            &nbsp;
                                                        </td>
                                                        <td align="center">
                                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                                ForeColor="Red" Visible="False">"Reset Account Logout Threshold Count After" have to less than or
                                                                equal to "Account Lockout Duration".</asp:Label></td></tr></table></asp:Panel></div></td></tr></table></td></tr></table><%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                <ucCopyRights:Copyrights ID="copyRights" runat="server" />
                <br />
                <br />
                <%--<asp:HiddenField ID="hidMode" runat="server" />
                <asp:SqlDataSource ID="sqlPresent" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                    SelectCommand="SELECT checker_level_id, checker_level_name from tblChecker_Level
where present_level_flag = 'Y'"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlFormer" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                    SelectCommand="SELECT checker_level_id, checker_level_name from tblChecker_Level
where former_level_flag = 'Y'"></asp:SqlDataSource>--%>
    </table>
    </form>
</body>
</html>
