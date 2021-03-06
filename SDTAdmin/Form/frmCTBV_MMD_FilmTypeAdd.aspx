<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_FilmTypeAdd.aspx.vb"
    Inherits=".frmCTBV_MMD_FilmTypeAdd" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Informaion System - Add Film Type</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=windows-874" />
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
            font-weight: 700;
        }
        .lbl
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
            text-align: right;
        }
        .style21
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
            text-align: right;
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
            height: 31px;
        }
        .style52
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
            height: 31px;
        }
    </style>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <script language="javascript" type="text/javascript">
<!--
        function MM_preloadImages() { //v3.0
            var d = document;
            if (d.images) {
                if (!d.MM_p) {
                    d.MM_p = new Array();
                }
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments;
                for (i = 0; i < a.length; i++) {
                    if (a[i].indexOf("#") != 0) {
                        d.MM_p[j] = new Image;
                        d.MM_p[j++].src = a[i];
                    }
                }
            }
        }
//-->
    </script>

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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_MMD.aspx">
                    &nbsp;Manage Master Data</a> &gt; <a href="frmCTBV_MMD_FilmType.aspx">MMD : Film 
                Type
                    </a>&gt; </b><strong>Film Type</strong>
            </td>
        </tr>
        <tr>
            <td height="277" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <font size="2"><font color="#000000"><font face="Tahoma" size="1"><strong></strong></font>
                </font></font>
                <table width="100%" height="277" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg" bgcolor="#f0cd8c">
                            <div align="center" class="style1">
                                <span class="style2">Film Type</span></div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="239" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td height="210" bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td class="style21">
                                                    </td>
                                                </tr>
                                                <tr id="trFilmTypeID" runat="server" bgcolor="#DDDDDD">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Film Type ID :</diFilm Type ID :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style28">
                                                            <asp:TextBox ID="txtFilmTypeID" runat="server" Columns="4" Width="100px" ReadOnly="True"
                                                                Font-Bold="True" Font-Names="Tahoma" ForeColor="Black" BackColor="Silver"></asp:TextBox>
                                                            &nbsp;</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Film Type :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtFilmTypeName" runat="server" Width="200px" Font-Bold="True" Font-Names="Tahoma"
                                                            ForeColor="#FF9900"></asp:TextBox>
                                                        &nbsp;<span class="style32">*</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Film Type (TH) :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtFilmTypeNameTH" runat="server" Width="200px" Font-Bold="True"
                                                            Font-Names="Tahoma" ForeColor="#FF9900"></asp:TextBox>
                                                        &nbsp;<span class="style32">* </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Film Type on Report :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <asp:TextBox ID="txtFilmTypeHeaderGroup" runat="server" Width="200px" Font-Bold="True"
                                                            Font-Names="Tahoma" ForeColor="#FF9900"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0" class="style42">
                                                    <td width="43%" align="right" class="style51">
                                                        <div align="right">
                                                            <b>Status :
                                                        </div>
                                                    </td>
                                                    <td width="57%" class="style52">
                                                        <asp:CheckBox ID="chkStatus" runat="server" Text="Active" />
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td width="43%" align="right" class="style20">
                                                        &nbsp;
                                                    </td>
                                                    <td width="57%" class="style20">
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
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--<asp:SqlDataSource ID="sqlFilmType" runat="server" 
        ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>">
    </asp:SqlDataSource>--%>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

