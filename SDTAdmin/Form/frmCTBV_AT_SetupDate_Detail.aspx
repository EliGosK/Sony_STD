<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_AT_SetupDate_Detail.aspx.vb"
    Inherits=".frmCTBV_AT_SetupDate_Detail" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register Src="../Controls/SelectColor.ascx" TagName="SelectColor" TagPrefix="uc2" %>
<%@ Register Src="../Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="uc3" %>
<%@ Register Src="../Controls/popUpCal.ascx" TagName="popUpCal" TagPrefix="uc4" %>
<%@ Register Src="../Controls/Trailer_Header_SetupPopup.ascx" TagName="Trailer_Header_SetupPopup"
    TagPrefix="uc5" %>
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
            width: 40%;
        }
        .style57
        {
            height: 41px;
        }
        .style58
        {
            height: 41px;
            width: 35%;
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

</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
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
                    &nbsp;Admin Tools</a> &gt; <a href="frmCTBV_AT_SetupDate.aspx">Weekly Movie Setup for
                        Checker Wage Details</a> &gt;&nbsp; </b><strong>Weekly Movie Setup for Checker Wage</strong>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                    bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style2">
                                Weekly Movie Setup for Checker Wage</div>
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
                                                    <table id="tblData" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0"
                                                        bgcolor="#FFFFE8">
                                                        <tr bgcolor="#DDDDDD">
                                                            <td style="text-align: right" class="style55">
                                                                <asp:Label ID="Label4" runat="server" CssClass="style46" Font-Bold="True" Text="Setup No. :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtmovie_setup_no" runat="server" BackColor="Silver" ReadOnly="true"
                                                                    ForeColor="#666666" Width="140px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right" class="style55" valign="top">
                                                                <asp:Label ID="Label6" runat="server" CssClass="style46" Font-Bold="True" Text="Start Date :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <span class="style20"><span class="style28">
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
                                                                    </span></span><span></span></label> </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: right" class="style55" valign="top">
                                                                <asp:Label ID="Label7" runat="server" CssClass="style46" Font-Bold="True" Text="End Date :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <span class="style20"><span class="style28">
                                                                    <asp:TextBox ID="txtEndDate" runat="server" ReadOnly="True" BackColor="Silver" Columns="20"
                                                                        Font-Bold="True" Font-Names="Tahoma" ForeColor="#666666"></asp:TextBox><asp:Label
                                                                            ID="lblErrorRe2" runat="server" Font-Bold="True" Font-Size="Smaller" ForeColor="Red"
                                                                            Visible="False">*</asp:Label>
                                                                    &nbsp;</span></span><span class="style28"><span class="style32"><span class="style31"><label><span
                                                                        class="style8"><asp:ImageButton ID="btnCalendar0" runat="server" ImageAlign="AbsMiddle"
                                                                            ImageUrl="~/images/calendar_01.jpg" Style="height: 20px; width: 33px" />
                                                                        <asp:DropDownList ID="ddlClnYearTo" runat="server" AutoPostBack="True">
                                                                        </asp:DropDownList>
                                                                        <br />
                                                                        <asp:Calendar ID="clnDateTo" runat="server" BackColor="White" BorderColor="White"
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
                                                                        &nbsp; &nbsp;</span></label></span></span><label><span class="style8"> </span>
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
                                                            <td class="style58" style="text-align: right">
                                                                <asp:HiddenField ID="txtId" runat="server" />
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
                                            <tr bgcolor="#F9F2EC">
                                                <td bgcolor="#F9F2EC">
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <table width="100%" border="0" cellspacing="0" bgcolor="#DADADA">
                                                            <tr bgcolor="#CCCCCC">
                                                                <td bordercolor="#DADADA" bgcolor="#DADADA">
                                                                    <table bgcolor="#F9F2EC" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: right">
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None"
                                                                        Width="900px">
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="9pt" ForeColor="White" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="movie_id" HeaderText="Title I.D." SortExpression="movie_id"
                                                                                ItemStyle-HorizontalAlign="center" ReadOnly="true" />
                                                                            <asp:BoundField DataField="movie_nameen" HeaderText="Title" ReadOnly="true" SortExpression="movie_nameen" />
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Seq. No." ItemStyle-HorizontalAlign="Center"
                                                                                SortExpression="movie_id">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtLevel" runat="server" Text='<%# Bind("movie_id") %>' Visible="false"></asp:TextBox>
                                                                                    <asp:TextBox ID="editLevel" runat="server" onblur="ValidIntNull()" Style="text-align: right"
                                                                                        Width="50" Text='<%# Bind("movie_level_id") %>'></asp:TextBox>
                                                                                    <%--<asp:Button ID="Button1" runat="server" Text="btnFocus" />--%>
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblLevel" runat="server" Text='<%# Bind("movie_level_id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Present / Former Wage"
                                                                                ItemStyle-HorizontalAlign="Center" SortExpression="movie_id">
                                                                                <EditItemTemplate>
                                                                                    <asp:RadioButton ID="rdoPresentY" runat="server" Checked='<%# Bind("PresentY")%>'
                                                                                        GroupName="Present" Text="Present Wage" />
                                                                                    <asp:RadioButton ID="rdoPresentN" runat="server" Checked='<%# Bind("PresentN")%>'
                                                                                        GroupName="Present" Text="Former Wage" />
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPresent" runat="server" Text='<%# Bind("present_Show") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Collect Report"
                                                                                ItemStyle-HorizontalAlign="Center" SortExpression="movie_id">
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="txtCollect" runat="server" Text='<%# Bind("movie_id") %>' Visible="false"></asp:TextBox>
                                                                                    <asp:CheckBox ID="chkCollect" runat="server" Checked='<%# Bind("collect_report_Y") %>' />
                                                                                </EditItemTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCollect" runat="server" Text='<%# Bind("collect_report_Show") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="movie_id" HeaderText="movie_id" SortExpression="movie_id"
                                                                                Visible="false" />
                                                                            <asp:BoundField DataField="movie_id" HeaderText="movie_id" SortExpression="movie_id"
                                                                                Visible="false" />
                                                                            <asp:CommandField ShowEditButton="true" ControlStyle-ForeColor="#5D7B9D" ButtonType="Image"
                                                                                UpdateImageUrl="~/images/SaveCCC.png" CancelImageUrl="~/images/CancelCCC.png"
                                                                                EditImageUrl="~/images/EditS.png" />
                                                                        </Columns>
                                                                        <PagerStyle BackColor="#284775" Font-Size="9pt" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFF1" />
                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="10" ForeColor="White"
                                                                            HorizontalAlign="Left" />
                                                                        <EditRowStyle BackColor="#999999" />
                                                                        <AlternatingRowStyle BackColor="White" Font-Size="9pt" ForeColor="#284775" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style57" style="text-align: center;" colspan="2">
                                                                    <asp:Label ID="lblErrorLevel" Font-Names="tahoma" ForeColor="Red" Font-Size="8pt"
                                                                        runat="server" Text=""></asp:Label>
                                                                    &nbsp; &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
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

