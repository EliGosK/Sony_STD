<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_Trailer_Setup.aspx.vb"
    Inherits="frmCTBV_Trailer_Setup" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register Src="../Controls/SelectColor.ascx" TagName="SelectColor" TagPrefix="uc2" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register Src="../Controls/popUpCal.ascx" TagName="popUpCal" TagPrefix="uc4" %>
<%@ Register Src="../Controls/Trailer_Header_SetupPopup.ascx" TagName="Trailer_Header_SetupPopup"TagPrefix="uc5" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System - Manage Master Data Movie</title>
    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>
<%--    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">--%>
    <style type="text/css">
A:link { COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:visited {  COLOR:#003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
A:hover {  COLOR: #cccccc; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none  }
A:active {  COLOR: #003399; FONT-FAMILY: "Tahoma";  FONT-SIZE: 13px; TEXT-DECORATION: none }
 
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
        .style16
        {
            color: #999999;
            font-family: "Tahoma";
            font-size: 14px;
        }
        .style46
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
            font-weight: 700;
        }
        .style48
        {
            height: 3px;
        }
        .style28
        {
            font-size: 14;
        }
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
            font-weight: 700;
        }
        .style32
        {
            color: #FF0000;
        }
        .style31
        {
            font-size: 10px;
        }
        .style55
        {
            width: 40%;
        }
        .style56
        {
            height: 3px;
            width: 380px;
        }
        .style57
        {
            height: 41px;
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

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874" />

    <script language="Javascript" src="../js/ColorPicker2.js" type="text/javascript"></script>
    
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
<body  leftMargin="0" topMargin="0" rightmargin="0" bottommargin="0"  >
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&nbsp;&gt; <a href="frmCTBV_Menu_Trailer.aspx">
                    Trailer Menu </a>&nbsp;&gt; <a href="frmCTBV_Trailer_Setup_Detail.aspx">Trailer 
                Setup Details </a>&nbsp;&gt; </b><strong>
                Trailer Setup</tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Trailer Setup</div>
                        </td>
                    </tr>
                    
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="78" align="center" bgcolor="#E2E2E2">
                            <table width="100%" border="0" cellspacing="1">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellspacing="0" bgcolor="#DADADA">
                                            <tr bgcolor="#CCCCCC">
                                                <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFE8">
                                                        <tr bgcolor="#DDDDDD">
                                                            <td style="text-align: right" class="style55">
                                                                <asp:Label ID="Label4" runat="server" CssClass="style46" Font-Bold="True" 
                                                                    Text="Setup No. :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtSetup_No" runat="server" BackColor="Silver" ReadOnly="true" ForeColor="#666666"
                                                                    Width="140px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="style55" valign="top">
                                                    <asp:Label ID="Label6" runat="server" CssClass="style46" Font-Bold="True" Text="Start Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True" OnClientDateSelectionChanged="AddDays(6);"></uc1:DatePicker>
                                                    <asp:Label ID="lblErrorRe1" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red" Visible="False">*</asp:Label>
                                                    <%--<span class="style20"><span class="style28">
                                                        <asp:TextBox ID="txtStartDate" runat="server" ReadOnly="True" BackColor="Silver"
                                                            Columns="20" Font-Bold="True" Font-Names="Tahoma" ForeColor="#666666"></asp:TextBox><asp:Label
                                                                ID="lblErrorRe1" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"
                                                                Visible="False">*</asp:Label>
                                                        &nbsp;</span></span><span class="style28"><span class="style32"><span class="style31"><label><span
                                                            class="style8"><asp:ImageButton ID="btnCalendar" runat="server" ImageAlign="AbsMiddle"
                                                                ImageUrl="~/images/calendar_01.jpg" Style="height: 20px; width: 33px" />
                                                            <asp:DropDownList ID="ddlClnYearFrom" runat="server" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <br />
                                                            <asp:Calendar ID="clnDateFrom" runat="server" BackColor="White" BorderColor="White"
                                                                BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="155px"
                                                                NextPrevFormat="ShortMonth" Visible="False" Width="216px">
                                                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                                <TodayDayStyle BackColor="#CCCCCC" />
                                                                <OtherMonthDayStyle ForeColor="#999999" />
                                                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                                                    Font-Size="12pt" ForeColor="#333399" />
                                                            </asp:Calendar>
                                                        </span>
                                                        </label>
                                                        </span></span><span class="style8"></span></span>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="style55" valign="top">
                                                    <asp:Label ID="Label7" runat="server" CssClass="style46" Font-Bold="True" Text="End Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <uc1:DatePicker ID="dtpEndDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"></uc1:DatePicker>
                                                    <asp:Label ID="lblErrorRe2" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red" Visible="False">*</asp:Label>
                                                    <%--<span class="style20"><span class="style28">
                                                        <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="True" BackColor="Silver" Columns="20"
                                                            Font-Bold="True" Font-Names="Tahoma" ForeColor="#666666"></asp:TextBox><asp:Label ID="lblErrorRe2" runat="server" Font-Bold="True" Font-Size="Smaller"
                                                                ForeColor="Red" Visible="False">*</asp:Label>
                                                        &nbsp;</span></span><span class="style28"><span class="style32"><span class="style31"><label><span
                                                            class="style8"><asp:ImageButton ID="btnCalendar0" runat="server" ImageAlign="AbsMiddle"
                                                                ImageUrl="~/images/calendar_01.jpg" Style="height: 20px; width: 33px" />
                                                                
                                                                    <asp:DropDownList ID="ddlClnYearTo" runat="server" AutoPostBack="True">
                                                                      </asp:DropDownList> <br/> 
  <asp:Calendar ID="clnDateTo" runat="server" BackColor="White" BorderColor="White"
                                                                    BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" 
                                                        ForeColor="Black" Height="155px"
                                                                    NextPrevFormat="ShortMonth" Visible="False" Width="216px">
                                                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                                    <TodayDayStyle BackColor="#CCCCCC" />
                                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
                                                                        Font-Size="12pt" ForeColor="#333399" />
                                                                </asp:Calendar>
                                                            </span></label></span></span><label><span class="style8">
                                                              
                                                            </span>
                                                            </label>
                                                        </span>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="style55" valign="top">
                                                    <asp:Label ID="Label5" runat="server" CssClass="style46" Font-Bold="True" Text="Copy from : "></asp:Label>
                                                    &nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <span class="style28"><label><span class="style8">
                                                    <uc5:Trailer_Header_SetupPopup ID="SetupPopup1" runat="server" />
                                                            </span>
                                                            </label>
                                                        </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style56" style="text-align: right">
                                                </td>
                                                <td class="style48">
                                                    <asp:Label ID="lblErrorHead" runat="server" Font-Bold="True" Font-Size="Smaller"
                                                        ForeColor="Red" Visible="False">Please check require flield (*)</asp:Label>
                                                    <asp:Label ID="lblErrorDup3" runat="server" Font-Bold="True" Font-Size="Smaller"
                                                        ForeColor="Red" Visible="False">Already exist in Date.</asp:Label>
                                                    <asp:Label ID="lblErrorInvalidDate" runat="server" Font-Bold="True" Font-Size="Smaller"
                                                        ForeColor="Red" Visible="False">Invalid Date.</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style57" style="text-align: right">
                                                    <asp:HiddenField ID="txtHeadId" runat="server" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                    <asp:ImageButton ID="btnSaveHead" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                        AlternateText="SAVE" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="btnDeleteHead" runat="server" ImageUrl="~/images/BackCCC.png"
                                                        AlternateText="BACK" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <asp:Panel ID="Panel1" runat="server">
                                            <table border="0" cellspacing="0" bgcolor="#DADADA">
                                                <tr bgcolor="#CCCCCC">
                                                    <td width="8%" bordercolor="#DADADA" bgcolor="#DADADA">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#F9F2EC">
                                                            <tr>
                                                                <td style="text-align: right" class="style55" valign="top">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="style46" Font-Bold="True" Text="Title I.D. :"></asp:Label>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <uc3:Movie1Popup ID="Movie1Popup1" runat="server" InStatus="1,3" AppearOnStatus="2" />
                                                                    <%--InStatus="1" AppearOnStatus="1" Studio="6"  --%><asp:Label ID="lblErrorDup2"
                                                                        runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red" Visible="False">*</asp:Label>
                                                                </td>
                                                            </tr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="style55">
                                                        <asp:Label ID="Label3" runat="server" CssClass="style46" Font-Bold="True" Text="Background Color :"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <uc2:SelectColor ID="SelectColor1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right" class="style55">
                                                        <asp:Label ID="Label2" runat="server" CssClass="style46" Font-Bold="True" Text="Font Color :"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <uc2:SelectColor ID="SelectColor2" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style56" style="text-align: right">
                                                    </td>
                                                    <td class="style48">
                                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"
                                                            Visible="False">Please check require flield (*)</asp:Label>
                                                        <asp:Label ID="lblErrorDup" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"
                                                            Visible="False">Already exist in Title I.D.</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <asp:HiddenField ID="txtId" runat="server" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                            AlternateText="SAVE" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                                        <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/CancelCCC.png"
                                                            AlternateText="CANCEL" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            CellPadding="4" DataKeyNames="movie_id" DataSourceID="sqlMovies" Font-Names="Tahoma"
                                                            Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="500px" PageSize="25">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandName="Select"
                                                                            Text="Select" CommandArgument='<%# Bind("movie_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Movie_Id" HeaderText="Title I.D." HeaderStyle-HorizontalAlign="Center"
                                                                    SortExpression="Movie_Id" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <%--<asp:HyperLinkField DataNavigateUrlFields="movie_id" 
                                                          DataNavigateUrlFormatString="frmctbv_mmd_movie_add.aspx?titleId={0}" 
                                                          DataTextField="MoviesName" HeaderText="Title" 
                                                          SortExpression="MoviesName" />--%>
                                                                <asp:BoundField DataField="MoviesName" HeaderText="Title" SortExpression="MoviesName" />
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Del"
                                                                            Text="Delete" OnClientClick="return confirm('Do you want to delete this movie?')"
                                                                            CommandArgument='<%# Bind("movie_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style57" style="text-align: right">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    
                </table>
                <br />
                <%@ register src="../Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="uc1" %>
                <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.
                </font>--%>
            </td>
        </tr>
    </table>
    </form>
    <asp:SqlDataSource ID="sqlMovies" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>">
    </asp:SqlDataSource>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>