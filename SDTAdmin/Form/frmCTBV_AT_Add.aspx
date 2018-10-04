<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_Add.aspx.vb"
    Inherits="frmCTBV_AT_Add" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Add User</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <script language="javascript" type="text/javascript" src="../js/jquery-1.9.1.js" ></script>
    <script language="javascript" type="text/javascript" src="../js/jquery-ui-1.10.3.custom.js" ></script>
    <link rel="stylesheet" href="../js/jquery-ui-1.10.4.css" />
 
    

    <script type="text/javascript">
        $(document).ready(function() {
            var typeUser = document.getElementById("ddlTypeUser").value;
            if (typeUser == 'Checker') {
                $("#txtSpin").spinner({
                    min: <%=minspin%>, max: <%=maxspin%>, step: 1
                });
            }
            if (typeUser == 'Administrator') {
                $("#txtSpin").spinner({
                    min: <%=minspin%>, max: <%=maxspin%>, step: 1
                });
            }
            var mode = "<%=new_flag%>";
            if(mode == 'new'){
                $("#txtSpin").focus();
            }
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
        .style41
        {
            font-size: 14px;
            font-family: "Tahoma";
            height: 27px;
        }
        .style42
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 26px;
        }
        .style43
        {
            font-size: 14px;
            font-family: "Tahoma";
            height: 26px;
        }
        .style45
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: bold;
        }
        .style50
        {
            width: 59px;
        }
        .style52
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 24px;
        }
        .style53
        {
            font-size: 14px;
            font-family: "Tahoma";
            height: 24px;
        }
        .style54
        {
            font-weight: bold;
            font-size: 14px;
            color: #666666;
            height: 27px;
            text-align: right;
        }
        .style55
        {
            width: 14px;
        }
    </style>

    <script language="JavaScript" type="text/JavaScript">
<!--



        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }
//-->
    </script>

    <script type="text/javascript">
        function setVisibility(id, visibility) {
            document.getElementById(id).style.display = visibility;
        }
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>

<body ms_positioning="GridLayout" leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
        bgcolor="#cccccc" id="Table2">
        <tr>
            <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                <font face="Tahoma"><font size="2"><font color="#000099"><strong>
                    <uc1:ctbvCtlTop ID="CtbvCtlTop1" runat="server"></uc1:ctbvCtlTop>
                </strong></font></font></font>
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a></b>&gt;<b><a href="frmCTBV_AT.aspx">
                    Admin Tools </a>&gt; User</b>
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
                                <span class="style2">&nbsp;User</span></div>
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
                                                        <td width="20%" class="style40">
                                                            <div align="right" class="style20">
                                                                <asp:Label ID="lblUserId" runat="server" Text="User I.D. :"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td class="style28">
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtUserId" runat="server" BackColor="#DFDFDF" MaxLength="4" ReadOnly="True"></asp:TextBox>
                                                            </span></span>
                                                        </td>
                                                        <td width="20%" class="style40">
                                                            <div align="right" class="style20">
                                                                <asp:Label ID="Label1" runat="server" Text="Password Age (day) :"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td class="style28">
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtSpin" runat="server" MaxLength="2"></asp:TextBox>
                                                            </span>
                                                            <span style="color:red"><asp:Label ID="lblAge" runat="server"></asp:Label></span>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40">
                                                            <div align="right" class="style24 style33">
                                                                User Type :</div>
                                                        </td>
                                                        <td class="style28">
                                                            <span class="style41">
                                                                <asp:DropDownList ID="ddlTypeUser" runat="server" AutoPostBack="True" Height="18px"
                                                                    Width="127px">
                                                                    <asp:ListItem Value="Checker">Checker</asp:ListItem>
                                                                    <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                        <td class="style28"></td>
                                                        <td class="style28"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table width="100%" border="0" cellspacing="0">
                                                    <tr bgcolor="#F0DFD0">
                                                        <td width="20%" class="style40">
                                                            <div align="right" class="style24 style33">
                                                                Name :</div>
                                                        </td>
                                                        <td class="style41">
                                                            <span class="style28">
                                                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                                                &nbsp;<span class="style32">*</span> </span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style42">
                                                            <div align="right" class="style20">
                                                                <div align="right">
                                                                    Tel :</div>
                                                            </div>
                                                        </td>
                                                        <td class="style43">
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                                            </span></span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style52">
                                                            <div align="right" class="style20">
                                                                <div align="right">
                                                                    E-Mail :
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td class="style53">
                                                            <span class="style31"><span class="style28">
                                                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                            </span></span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style1">
                                                            <div align="right" class="style20">
                                                                Password:</div>
                                                        </td>
                                                        <td>
                                                            <span class="style28"><span class="style31">
                                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" 
                                                                MaxLength="16"></asp:TextBox>
                                                                <span class="style28"><span class="style32">*</span></span></span> 
                                                                <asp:Label ID="lblHint" runat="server"></asp:Label> &nbsp
                                                                <asp:Label ID="lblErrorMSG" runat="server" ForeColor="Red"></asp:Label>
                                                            
                                                            
                                                            
                                                            </span>&nbsp;<div id="101" style="position: inherit; display: none">
                                                                <span class="style32">
                                                                    <asp:Label ID="lblCheckPassword" runat="server" Text="Please empty the textbox, if you don't want to change password."></asp:Label></span>
                                                            </div>
                                                            <span class="style28">
                                                                <asp:TextBox ID="txtPasswordEncrypt" runat="server" MaxLength="0" ReadOnly="True"
                                                                    Visible="False"></asp:TextBox>
                                                                <asp:Label ID="lblPWLength" runat="server" Visible="False"></asp:Label>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#f0dfd0">
                                                        <td class="style1">
                                                            <div align="right" class="style20"></div>
                                                        </td>
												        <td>
												            <asp:CheckBox id="checkBoxPassword" runat="server" Height="16px" Font-Size="Smaller" 
                                                                ForeColor="#000000" Font-Names="Tahoma" text="Show Characters" AutoPostBack="true" /> 
												        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40">
                                                            <div align="right" class="style45">
                                                                Status :</div>
                                                        </td>
                                                        <td>
                                                            <span class="style31">
                                                                <asp:DropDownList ID="ddlStatus" runat="server">
                                                                    <asp:ListItem Value="Enabled" Selected="True">Enabled</asp:ListItem>
                                                                    <asp:ListItem Value="Disenabled">Disenabled</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40">
                                                            <div align="right" class="style45">
                                                                Present Level :</div>
                                                        </td>
                                                        <td>
                                                            <span class="style31">
                                                                <asp:DropDownList ID="ddlPresent" runat="server" DataTextField="checker_level_name"
                                                                    DataValueField="checker_level_id">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40">
                                                            <div align="right" class="style45">
                                                                Former Level :</div>
                                                        </td>
                                                        <td>
                                                            <span class="style31">
                                                                <asp:DropDownList ID="ddlFormer" runat="server" DataTextField="checker_level_name"
                                                                    DataValueField="checker_level_id">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <% If ddlTypeUser.SelectedValue = "Checker" Then %>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40" valign="top">
                                                            <div align="right" class="style45">
                                                                <asp:Label ID="lblTheater" runat="server" Text="Theatre :"></asp:Label></div>
                                                        </td>
                                                        <td>
                                                            <span class="style31">
                                                                <asp:Repeater ID="rptTheater" runat="server">
                                                                    <HeaderTemplate>
                                                                        <table width="100%" style="font-family: Tahoma; font-size: XX-Small;">
                                                                            <tr>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <td>
                                                                            <asp:CheckBox ID="chkTherterName" runat="server" Checked="<%# Bind('status_flag') %>"
                                                                                Text="<%# Bind('theater_name') %>" />
                                                                            <asp:HiddenField ID="hdfTheaterId" runat="server" Value="<%# Bind('theater_id') %>" />
                                                                        </td>
                                                                        <%#Eval("sep")%>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </tr> </table>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <% End If %>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style54" valign="top">
                                                            Access Allowed :
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm01" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                            Text="Box Office" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm02" runat="server" Font-Size="X-Small" Text="Daily Box Office"
                                                                                        Enabled="False" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm03" runat="server" Font-Size="X-Small" Text="Display Box Office by Theatre"
                                                                                        Enabled="False" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm04" runat="server" Font-Size="X-Small" Text="Display Box Office by Screen"
                                                                                        Enabled="False" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm05" runat="server" Font-Size="X-Small" Text="Display Box Office by Session "
                                                                                        Enabled="False" EnableTheming="True" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm06" runat="server" Font-Size="X-Small" Text="Edit/Delete Box Office by Session "
                                                                                        Enabled="False" EnableTheming="True" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm07" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                            Text="Trailer Management" AutoPostBack="true" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm12" runat="server" Enabled="False" Font-Size="X-Small" Text="Trailer Setup" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm13" runat="server" Enabled="False" Font-Size="X-Small" Text="Input From Checkers" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm14" runat="server" Enabled="False" Font-Size="X-Small" Text="Trailer Reports" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm08" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                            Text="Ticket And Per Cap" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm47" runat="server" Enabled="False" Font-Size="X-Small" Text="Free Ticket and Per Cap" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm48" runat="server" Enabled="False" Font-Size="X-Small" Text="Free Ticket and Per Cap by Movie" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm49" runat="server" Enabled="False" Font-Size="X-Small" Text="Ticket Type" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm50" runat="server" Enabled="False" Font-Size="X-Small" Text="Ticket Type by Movie" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm09" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                            Text="Master Data Management" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm26" runat="server" Enabled="False" Font-Size="X-Small" Text="Movie" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm27" runat="server" Enabled="False" Font-Size="X-Small" Text="Theatre" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm28" runat="server" Enabled="False" Font-Size="X-Small" Text="Distributor" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm37" runat="server" Enabled="False" Font-Size="X-Small" Text="Studio" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm45" runat="server" Enabled="False" Font-Size="X-Small" Text="Film Type" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm46" runat="server" Enabled="False" Font-Size="X-Small" Text="Film Type and Sound" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm57" runat="server" Enabled="False" Font-Size="X-Small" Text="Holiday" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm10" runat="server" Font-Bold="True" Font-Size="X-Small"
                                                                            Text="Admin. Tools" AutoPostBack="True" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm29" runat="server" Enabled="False" Font-Size="X-Small" Text="User Setting" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm30" runat="server" Enabled="False" Font-Size="X-Small" Text="Message to Checker" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm31" runat="server" Enabled="False" Font-Size="X-Small" Text="Box Office Status" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm43" runat="server" Enabled="False" Font-Size="X-Small" Text="Weekly Movie Setup for Checker Wage" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm44" runat="server" AutoPostBack="True" Font-Bold="True"
                                                                                        Font-Size="X-Small" Text="Checker Level and Wage" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm32" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Late Show Config." />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm38" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Checker Level" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm39" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Present Wage" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm40" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Former Wage" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm41" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Collect Report Config" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    &nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkPerm42" runat="server" Enabled="False" Font-Size="X-Small"
                                                                                        Text="Wage by Session Config" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm58" runat="server" Enabled="False" Font-Size="X-Small" Text="System Policies" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm52" runat="server" AutoPostBack="True" Font-Bold="True"
                                                                            Font-Size="X-Small" Text="Virtual Print Fee" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm53" runat="server" Enabled="False" Font-Size="X-Small" Text="Problem Record" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm54" runat="server" Enabled="False" Font-Size="X-Small" Text="Movie Default Set" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm55" runat="server" Enabled="False" Font-Size="X-Small" Text="Manage Movie Set" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm56" runat="server" Enabled="False" Font-Size="X-Small" Text="VPF Summary" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:CheckBox ID="chkPerm11" runat="server" AutoPostBack="True" Font-Bold="True"
                                                                            Font-Size="X-Small" Text="Report Center" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%;">
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm15" runat="server" Enabled="False" Font-Size="X-Small" Text="Export Box Office Data to SPIRITworld" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm16" runat="server" Enabled="False" Font-Size="X-Small" Text="SDT Daily Box Office (Initial)" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm17" runat="server" Enabled="False" Font-Size="X-Small" Text="Competitor Daily Box Office (Initial)" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm18" runat="server" Enabled="False" Font-Size="X-Small" Text="SDT Weekly Box Office (for Finance)" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm19" runat="server" Enabled="False" Font-Size="X-Small" Text="Weekend Trading Report " />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm20" runat="server" Enabled="False" Font-Size="X-Small" Text="SDT Market Share " />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm21" runat="server" Enabled="False" Font-Size="X-Small" Text="Competitor Market Share" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm22" runat="server" Enabled="False" Font-Size="X-Small" Text="General Industry Market Share" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm23" runat="server" Enabled="False" Font-Size="X-Small" Text="SDT Box Office by Sound and Film Format" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm36" runat="server" Font-Size="X-Small" Text="Competitor Box Office by Sound and Film Format"
                                                                                        Enabled="False" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm24" runat="server" Enabled="False" Font-Size="X-Small" Text="SDT Checker wage and Late Show by Theatre" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm25" runat="server" Enabled="False" Font-Size="X-Small" Text="Box Office by Title" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm33" runat="server" Enabled="False" Font-Size="X-Small" Text="Theatre Information" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm34" runat="server" Enabled="False" Font-Size="X-Small" Text="Occupancy Report " />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm35" runat="server" Enabled="False" Font-Size="X-Small" Text="Industry Information by Title" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="style55">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
                                                                                    <asp:CheckBox ID="chkPerm51" runat="server" Enabled="False" Font-Size="X-Small" Text="Free Ticket / Per CAP / Detail of Ticket Type Summary" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style40">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                                                Visible="False">Please check require flield (*)</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td colspan="2" class="style16">
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
                                                                        <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/BackCCC.png" AlternateText="BACK" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
                <ucCopyRights:Copyrights ID="copyRights" runat="server" />
                <br />
                <br />
                <asp:HiddenField ID="hidMode" runat="server" />
                <asp:SqlDataSource ID="sqlPresent" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                    SelectCommand="SELECT checker_level_id, checker_level_name from tblChecker_Level
where present_level_flag = 'Y'"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlFormer" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                    SelectCommand="SELECT checker_level_id, checker_level_name from tblChecker_Level
where former_level_flag = 'Y'"></asp:SqlDataSource>
    </table>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>