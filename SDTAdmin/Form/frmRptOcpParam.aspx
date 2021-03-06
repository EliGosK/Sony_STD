<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRptOcpParam.aspx.vb"
    Inherits=".frmRptOcpParam" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register Src="../Controls/TheatrePopup.ascx" TagName="TheatrePopup" TagPrefix="uc2" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>
<%@ Register Src="../Controls/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        .style2
        {
            font-weight: bold;
            font-size: 14px;
            color: #999999;
            font-family: "Tahoma";
        }
        A:link
        {
            color: #003399;
            font-family: "Tahoma";
            font-size: 13px;
            text-decoration: none;
        }
        .style12
        {
            font-weight: bold;
            font-size: 14px;
            color: #666666;
            font-family: "Tahoma";
        }
        .style1
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
        }
        .style15
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 11px;
            width: 42%;
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
            width: 42%;
        }
        .style17
        {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            font-weight: bold;
            height: 25px;
            width: 42%;
        }
        .style18
        {
            width: 380px;
            height: 25px;
        }
    </style>
    
    <script language="javascript" type="text/javascript">
        function AddDays(p_day) {
            var year, month, day;

            if (!p_day || p_day == '' || isNaN(p_day)) { return; }

            var dtpStartDate = document.getElementById('<%= dtpStartDate.TxtDateClientID %>');
            year = parseInt(dtpStartDate.value.substring(6), 10); // Year
            month = parseInt(dtpStartDate.value.substring(3, 5), 10) - 1; // Month (0-11)
            day = parseInt(dtpStartDate.value.substring(0, 2), 10); // Day
            if (isNaN(year) || isNaN(month) || isNaN(day)) { return; }

            var dtm = new Date(year, month, day);
            dtm.setDate(dtm.getDate() + parseInt(p_day));

            var dtpEndDate = document.getElementById('<%= dtpEndDate.TxtDateClientID %>');
            year = dtm.getFullYear() + "";
            month = (dtm.getMonth() + 1) + "";
            day = dtm.getDate() + "";
            dtpEndDate.value = lpad(day, "0", 2) + "/" + lpad(month, "0", 2) + "/" + lpad(year, "0", 2);
        }

        function lpad(p_str, p_pad, p_length) {
            while (p_str.length < p_length) { p_str = p_pad + p_str; }
            return p_str;
        }

        function rpad(p_str, p_pad, p_length) {
            while (p_str.length < p_length) { p_str = p_str + p_pad; }
            return p_str;
        }
    </script>
</head>
<body bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
    <form id="Form2" defaultbutton="btnSubmit" method="post" runat="server">
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
                <span class="style2">&nbsp;<a href="frmCTBV_Menu.aspx">Main Menu </a></span><span
                    class="style12">&gt; <a href="frmCTBV_RC_Menu.aspx">Reports Center </a>&gt; PDA
                    Occupancy</span>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#f0cd8c"
                    style="height: 154px">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                Occupancy Report</div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#CCCCCC">
                            <table border="0" cellspacing="0" width="100%" cellpadding="0">
                                <tr>
                                    <td class="style15">
                                    </td>
                                    <td style="text-align: left" class="style16">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" valign="middle">
                                        Title I.D. :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc3:Movie1Popup ID="Movie1Popup1" runat="server" InStatus="1,2,3" 
                                            AppearOnStatus="1,2,3" VisibleMovieType="False" MovieType="1"  />
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Font-Size="9pt" Font-Names="tahoma"
                                            Text="*"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" valign="middle">
                                        Start Date :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True" OnClientDateSelectionChanged="AddDays(6);"></uc1:DatePicker>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11" valign="middle">
                                        End Date :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc1:DatePicker ID="dtpEnddate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"></uc1:DatePicker>
                                    </td>
                                </tr>
                                <tr id="trTFrom" runat="server" visible="false"  >
                                    <td class="style11" valign="middle">
                                        Theatre From :
                                    </td>
                                    <td align="left">
                                        <uc2:TheatrePopup ID="TheatrePopup1" runat="server" />
                                    </td>
                                </tr>
                                <tr id="trTTo" runat="server" visible="false" >
                                    <td class="style11" valign="middle">
                                        Theatre To :
                                    </td>
                                    <td align="left" class="style14">
                                        <uc2:TheatrePopup ID="TheatrePopup2" runat="server" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="style17">
                                    </td>
                                    <td class="style18" style="text-align: left">
                                        <asp:Label ID="lblerror" runat="server" Font-Names="Tahoma" Font-Overline="False"
                                            Font-Size="8pt" Font-Bold="true" ForeColor="Red" Text="Please check require flield (*)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style11">
                                        &nbsp;
                                    </td>
                                    <td class="style14" style="text-align: left">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                                        &nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td align="center" bgcolor="#f0cd8c">
                            <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                            <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
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