<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptTrailerByReleaseParam.aspx.vb" Inherits=".frmRptTrailerByReleaseParam" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register src="../Controls/Trailer_Header_SetupPopup.ascx" tagname="Trailer_Header_SetupPopup" tagprefix="uc2" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>SDT Management Informaion System</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
    <style type="text/css">
A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
  
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
        .style15
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 11px;
        }
        .style16
        {
            width: 380px;
            height: 11px;
        }
        .style11
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
        }
        .style14
        {
            width: 380px;
        }
        .style17
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 22px;
        }
        .style18
        {
            width: 380px;
            height: 22px;
        }
    </style>
</head>
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0" >
    <form id="Form2" method="post" runat="server">
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
        <tr background="../images/BG7.jpg" style="color: Gray; font-family: Tahoma; font-size: 13px;">
            <td height="29" colspan="2" bordercolor="honeydew" background="../images/BG7.jpg">
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>
                        </b>&nbsp;&gt; 
                        <b><a href="frmCTBV_Menu_Trailer.aspx">Trailer Menu </a>
                        </b>&nbsp;&gt; 
                        <b><a href="frmCTBV_Menu_Trailer_Rpt.aspx">Trailer Reports </a> 
                        </b>&nbsp;&gt;<strong> Trailer List by Release</strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" style="font-family: Tahoma; font-size: 11pt; font-weight: bold;
                                color: Gray;">
                                Trailer List by Release</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#CCCCCC">
                            <table border="0" cellspacing="0" width="100%" cellpadding="0">
                                <tr>
                                    <td width="40%" class="style15">
                                    </td>
                                    <td style="text-align: left" class="style16">
                                    </td>
                                </tr>
                                <tr>
                                    <td width="40%" class="style11">
                                                                                Title I.D. :
                                    </td>
                                    <td align="left">
                                        <uc3:Movie1Popup ID="Movie1Popup1" runat="server" AppearOnStatus="1" />
                                        <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                            ForeColor="Red">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="40%" class="style11">
                                        Setup No. :
                                    </td>
                                    <td align="left">
                                        <uc2:Trailer_Header_SetupPopup ID="Trailer_Header_SetupPopup1" runat="server" />
                                        <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="8pt" 
                                            ForeColor="Red">*</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style17" width="40%">
                                    </td>
                                    <td class="style18" style="text-align: left">
                                        <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Red">Please check require flield (*)</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" width="40%">
                                    </td>
                                    <td class="style14" style="text-align: left">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                        &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#f0cd8c">
                            <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                            <%--<center><font color="rosybrown" face="Tahoma" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font></center>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>