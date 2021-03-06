<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_Config.aspx.vb"
    Inherits=".frmCTBV_AT_Config" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Manage Master Distributor</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
        .txtRight
        {
            text-align: right;
        }
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
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
        .style32
        {
            color: #FF0000;
        }
        .style42
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
        }
        .style42
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 26px;
        }
        .style46
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
            font-weight: bold;
        }
        .style50
        {
            width: 59px;
        }
        .style51
        {
            height: 17px;
        }
        .style52
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
            height: 17px;
        }
    </style>

    <script language="JavaScript" type="text/JavaScript">
<!--



function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>
<body ms_positioning="GridLayout" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_AT_Main.aspx">
                    &nbsp;Admin Tools</a>&nbsp;&gt;<a href="frmCTBV_AT_LavelAndWage.aspx"> &nbsp;Checker
                        Level and Wage</a> &gt;&nbsp;Collect Report Config</b>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                <span class="style2">Collect Report Config</span>
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <table id="tblData" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style21">
                                                    </td>
                                                </tr>
                                                <tr visible="false" bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Min Rate :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtMin" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"
                                                            onblur="ValidNum()" CssClass="txtRight" Width="120px"></asp:TextBox>
                                                        &nbsp;Baht<span class="style32"> *</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Collect Report Wage :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtMax" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"
                                                            onblur="ValidNum()" Width="120px" CssClass="txtRight"></asp:TextBox>
                                                        &nbsp;Baht<span class="style32"> *</span> &nbsp;&nbsp;<span align="left" style="color: Gray;
                                                            font-family: Tahoma; font-size: 8pt;">Wage per 1 movie.</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Seq. No. :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtLevel" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"
                                                            onblur="ValidInt0()" CssClass="txtRight" Width="120px"></asp:TextBox>
                                                        &nbsp;<span class="style32">*</span> &nbsp;&nbsp;<span align="left" style="color: Gray;
                                                            font-family: Tahoma; font-size: 8pt;">Sequence of screen will select wage from level.</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Session Qty :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtSesion" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"
                                                            onblur="ValidInt0()" Width="120px" CssClass="txtRight"></asp:TextBox>
                                                        &nbsp;<span class="style32">*</span> &nbsp;&nbsp;<span align="left" style="color: Gray;
                                                            font-family: Tahoma; font-size: 8pt;">Maximum session per day.</span>
                                                    </td>
                                                </tr>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0" class="style42">
                                    <td width="47%" align="right" class="style51">
                                    </td>
                                    <td width="53%" class="style52">
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="47%" align="right" class="style20">
                                        &nbsp;
                                    </td>
                                    <td width="53%" class="style20">
                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                            Visible="False">Please check require flield (*)</asp:Label>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td colspan="2">
                                        <table border="0" align="center" cellpadding="0" cellspacing="0" style="height: 31px;
                                            width: 120px">
                                            <tr>
                                                <td class="style50">
                                                    <div align="center">
                                                        <asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                            AlternateText="SAVE" />
                                                    </div>
                                                </td>
                                                <td width="66" align="right">
                                                    <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/backCCC.png" AlternateText="BACK" />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
    </table>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

