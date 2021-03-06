<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Menu_Trailer.aspx.vb"
    Inherits=".frmCTBV_Menu_Trailer" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>SDT Management Information System - Trailer Main Menu</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <script language="JavaScript" type="text/JavaScript">
<!--
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }

        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
//-->
    </script>

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
        .style4
        {
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            font-weight: bold;
        }
        .style7
        {
            font-size: 12px;
            color: #FF0000;
            font-weight: bold;
            font-family: "Tahoma";
        }
        #Form1
        {
            font-weight: 700;
        }
        .style8
        {
            color: #f0cd8c;
        }
        .style9
        {
            height: 117px;
        }
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0" onload="MM_preloadImages('../images/booking.jpg','../images/exit.jpg')"
    ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" id="Table1">
        <tr>
            <td colspan="2" valign="top" style="height: 20px">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" bordercolor="#d3d3d3"
                    bgcolor="#cccccc" id="Table2">
                    <tr>
                        <td width="53%" align="left" bgcolor="#ffffff" style="height: 23px">
                            <uc1:ctbvCtlTop ID="ctbvCtlTop1" runat="server" />
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
                                    <td class="style7">
                                        Log Out
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr background="../images/BG7.jpg">
                        <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg"
                            class="style16">
                            &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; </b><strong>
                        Trailer Menu</tr>
                    <tr>
                        <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                            <font size="2"><font color="#000000"><font face="Tahoma" size="1"><strong></strong></font>
                            </font></font>
                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" bgcolor="#f0cd8c"
                                style="height: 226px">
                                <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                                    <td background="../images/BG8.jpg">
                                        <div align="center" class="style4">
                                            Trailer Menu</div>
                                    </td>
                                </tr>
                                <tr bordercolor="#999999" bgcolor="#FFFFFF">
                                    <td align="center" bgcolor="White" class="style9">
                                        <table border="0" cellpadding="0" cellspacing="10">
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imbtnTrialer" runat="server" ImageUrl="~/images/MenuTrailer1.jpg"
                                                        BorderColor="#FF9900" BorderStyle="Dotted" BorderWidth="1px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/MenuTrailer2.jpg"
                                                        BorderColor="#FF9900" BorderStyle="Dotted" BorderWidth="1px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/MenuTrailer3.jpg"
                                                        BorderColor="#FF9900" BorderStyle="Dotted" BorderWidth="1px" />
                                                </td>
                                            </tr>
                                        </table>
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
    <ucCopyRights:Copyrights ID="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

