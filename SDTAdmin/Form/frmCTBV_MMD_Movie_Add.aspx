<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Movie_Add.aspx.vb"
    Inherits="frmCTBV_MMD_Movie_Add" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register Src="../Controls/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Informaion System - Add Movie</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1" />
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
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
        .style28
        {
            font-size: 14;
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
        .style44
        {
            font-size: 10px;
            font-family: "Tahoma";
            font-weight: 700;
        }
        .style31
        {
            font-size: 10px;
        }
        .style46
        {
            font-size: 14;
            font-family: "Tahoma";
            height: 6px;
            font-weight: bold;
        }
        .style47
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
            color: #FF0000;
            font-weight: bold;
        }
        .style53
        {
            font-weight: bold;
            font-size: 14px;
            color: #FFFFFF;
            font-family: "Tahoma";
        }
    </style>

    <script language="JavaScript" type="text/JavaScript">
<!--

        function CheckboxesCheckUncheck(objChk)
        {
            //กำหนด Element หลัก ในที่นี้คือ GridView
            var ctrlParent = document.getElementById('grdTheater');
            //alert(ctrlParent);
            //กำหนด Element ลูก ในที่นี้คือ Checkbox ControlID
            var ctrlChild = "chkBxSelect";
            //Get Control ที่อยู่ใน Parent ในที่นี้คือ GridView
            var Inputs = ctrlParent.getElementsByTagName('input');
                 for(var i = 0; i < Inputs.length; ++i)
                    { // วน Loop Control โดยเช็คว่า Type คือ Checkbox และ indexOf Child ลูก
                        if(Inputs[i].type == 'checkbox' && Inputs[i].id.indexOf(ctrlChild,0) >= 0)
                           Inputs[i].checked = objChk.checked;
                    }
        }

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
//-->
    </script>

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>
<body onload="javascript:ScrollIt()" onscroll="javascript:setcoords()" ms_positioning="GridLayout"
    leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
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
                    &nbsp;Manage Master Data</a> &gt; <a href="frmCTBV_MMD_Movie.aspx">MMD : Movie </a>
                    &gt; </b><strong>Movie</strong>
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
                                <span class="style2">&nbsp;Movie</span></div>
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
                                                        <span>
                                                            <asp:ImageButton ID="imbDelete" runat="server" ImageUrl="~/images/DeleteCCC.png"
                                                                AlternateText="DELETE" />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
                                                    </td>
                                                </tr>
                                                <tr id="trMovieID" runat="server" bgcolor="#DDDDDD">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Title I.D. :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style28">
                                                            <asp:TextBox ID="txtMovieID" runat="server" Columns="40" Font-Bold="True" Font-Names="Tahoma"
                                                                ForeColor="Black" Width="95px" ReadOnly="True" BackColor="Silver"></asp:TextBox>
                                                            &nbsp;</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style46">
                                                            Title 1 :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style28">
                                                            <asp:TextBox ID="txtName1" runat="server" Columns="40" Font-Bold="True" Font-Names="Tahoma"
                                                                ForeColor="#FF9900"></asp:TextBox>
                                                            &nbsp;<span class="style32">*</span> </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style42">
                                                        <div align="right">
                                                            <span style="font-weight: 700">Title 2</span><b>&nbsp;:</b></div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style28">
                                                            <asp:TextBox ID="txtName2" runat="server" Columns="40" Font-Bold="True" Font-Names="Tahoma"
                                                                ForeColor="#FF9900"></asp:TextBox>
                                                            <span class="style32">&nbsp;*</span> </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td>
                                                        <div align="right" class="style47">
                                                            &nbsp;Title Code :</div>
                                                    </td>
                                                    <td class="style44">
                                                        <span class="style28">
                                                            <asp:TextBox ID="txtCode" runat="server" Columns="20" Font-Bold="True" Font-Names="Tahoma"
                                                                ForeColor="#FF9900"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td style="text-align: right">
                                                        <div align="right" class="style47">
                                                            Release Type :</div>
                                                    </td>
                                                    <td class="style44">
                                                        <span class="style28"><span class="style51">
                                                            <asp:DropDownList ID="ddlType" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                ForeColor="#FF9900">
                                                                <%--<asp:ListItem Value="0">--Please Select--</asp:ListItem>--%>
                                                                <asp:ListItem Value="1">CTBV</asp:ListItem>
                                                                <asp:ListItem Value="2">Competitor</asp:ListItem>
                                                            </asp:DropDownList>
                                                            *</span></span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0" valign="middle">
                                                    <td width="43%">
                                                        <div align="right">
                                                            <div align="right">
                                                                <div align="right" class="style47">
                                                                    Release Date :</div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td width="57%" class="style42">
                                                        <uc1:DatePicker ID="dtpReleaseDate" runat="server"></uc1:DatePicker>
                                                        <%--<span class="style20"><span class="style28">
                                                            <asp:TextBox ID="txtReleaseDate" runat="server" ReadOnly="True" BackColor="#CCCCFF"
                                                                Columns="20" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9933"></asp:TextBox>
                                                            &nbsp;</span></span><span class="style28"><span class="style32"><span class="style31"><label><span
                                                                class="style8"><asp:ImageButton ID="btnCalendar" runat="server" ImageAlign="AbsMiddle"
                                                                    ImageUrl="~/images/calendar_01.jpg" Style="height: 20px; width: 33px" />
                                                                <asp:DropDownList ID="ddlClnYear" runat="server" AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <br />
                                                                &nbsp;</span></label></span></span><label><span class="style8"><asp:Calendar ID="clnDate"
                                                                    runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" DayNameFormat="Shortest"
                                                                    Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="16px" NextMonthText="&lt;IMG src='../images/next1.gif' border='0'&gt;"
                                                                    PrevMonthText="&lt;IMG src='../images/back1.gif' border='0'&gt;" SelectMonthText=""
                                                                    ShowGridLines="True" Width="193px" Visible="False">
                                                                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                                                    <SelectorStyle BackColor="#FFCC66" />
                                                                    <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                                                    <OtherMonthDayStyle ForeColor="#CC9966" />
                                                                    <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                                                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                                                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Names="Tahoma" Font-Size="X-Small"
                                                                        ForeColor="#FFFFCC" />
                                                                </asp:Calendar>
                                                                </span>
                                                                </label>
                                                            </span>--%>
                                                    </td>
                                                </tr>
                                        </span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0" class="style42">
                                    <td width="43%" align="right">
                                        <div align="right">
                                            <b>Distributor : </b>
                                        </div>
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlDistibutor" runat="server" Height="18px" DataSourceID="sqlDistibutor"
                                            DataTextField="distributor_name" DataValueField="distributor_id" EnableTheming="True"
                                            AppendDataBoundItems="True" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="style28"><span class="style32">*</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Studio :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlStudio" runat="server" DataSourceID="sqlStudio" DataTextField="studio_name"
                                            DataValueField="studio_id" AppendDataBoundItems="True" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Null--</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="style28"><span class="style32">*</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Pattern :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlPattern" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                            <asp:ListItem Value="Wide">Wide</asp:ListItem>
                                            <asp:ListItem Value="Selected">Selected</asp:ListItem>
                                            <asp:ListItem Value="Limited">Limited</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="style28"><span class="style32">*</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Genre :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlGenr" runat="server" Height="18px" Width="135px" Font-Bold="True"
                                            Font-Names="Tahoma" ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                            <asp:ListItem Value="Action">Action</asp:ListItem>
                                            <asp:ListItem Value="Romantic">Romantic</asp:ListItem>
                                            <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                                            <asp:ListItem Value="Animation">Animation</asp:ListItem>
                                            <asp:ListItem Value="Drama">Drama</asp:ListItem>
                                            <asp:ListItem Value="Fantasy">Fantasy</asp:ListItem>
                                            <asp:ListItem Value="Horror">Horror</asp:ListItem>
                                            <asp:ListItem Value="Sci-Fi">Sci-Fi</asp:ListItem>
                                            <asp:ListItem Value="Thriller">Thriller</asp:ListItem>
                                        </asp:DropDownList>
                                        ,<span class="style28"><span class="style32"><asp:DropDownList ID="ddlGenr0" runat="server"
                                            Height="18px" Width="135px" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                            <asp:ListItem Value="Action">Action</asp:ListItem>
                                            <asp:ListItem Value="Romantic">Romantic</asp:ListItem>
                                            <asp:ListItem Value="Comedy">Comedy</asp:ListItem>
                                            <asp:ListItem Value="Animation">Animation</asp:ListItem>
                                            <asp:ListItem Value="Drama">Drama</asp:ListItem>
                                            <asp:ListItem Value="Fantasy">Fantasy</asp:ListItem>
                                            <asp:ListItem Value="Horror">Horror</asp:ListItem>
                                            <asp:ListItem Value="Sci-Fi">Sci-Fi</asp:ListItem>
                                            <asp:ListItem Value="Thriller">Thriller</asp:ListItem>
                                        </asp:DropDownList>
                                            *</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Nationality :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlNationality" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                            <asp:ListItem Value="Hollywood">Hollywood</asp:ListItem>
                                            <asp:ListItem Value="Thai">Thai</asp:ListItem>
                                            <asp:ListItem Value="Chinese">Chinese</asp:ListItem>
                                            <asp:ListItem Value="Japan">Japan</asp:ListItem>
                                            <asp:ListItem Value="Korean">Korean</asp:ListItem>
                                            <asp:ListItem Value="Other">Other</asp:ListItem>
                                        </asp:DropDownList>
                                        <span class="style28"><span class="style32">*</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Director :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtDirector" runat="server" Columns="20" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Cast 1,2:
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtCast1" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="#FF9900"></asp:TextBox>
                                        ,<asp:TextBox ID="txtCast2" runat="server" Columns="20" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900"></asp:TextBox>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Appear On :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:DropDownList ID="ddlAppear" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900" DataSourceID="SqlAppearOn" DataTextField="appear_status_name"
                                            DataValueField="appear_status_id" Height="20px" Width="139px">
                                        </asp:DropDownList>
                                        <span class="style28"><span class="style32">*</span></span>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Revenue Estimate :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtRevenueEstimate" runat="server" Columns="20" Font-Bold="True"
                                            Font-Names="Tahoma" ForeColor="#FF9900" CssClass="lbl" onblur="ValidNum()"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Flat Sales Rental :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtFlatSaleRental" runat="server" Columns="20" Font-Bold="True"
                                            onblur="ValidNum()" Font-Names="Tahoma" ForeColor="#FF9900" CssClass="lbl"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Ad/Pub :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtAdpub" runat="server" Columns="20" Font-Bold="True" onblur="ValidNum()"
                                            Font-Names="Tahoma" ForeColor="#FF9900" CssClass="lbl"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Print Cost :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtPrintcost" runat="server" Columns="20" Font-Bold="True" onblur="ValidNum()"
                                            Font-Names="Tahoma" ForeColor="#FF9900" CssClass="lbl"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        No. of Print :
                                    </td>
                                    <td width="57%" class="style20">
                                        <asp:TextBox ID="txtNoOfPoint" runat="server" Columns="20" Font-Bold="True" Font-Names="Tahoma"
                                            ForeColor="#FF9900" CssClass="lbl" Width="299px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20">
                                        Show in report :
                                    </td>
                                    <td width="57%">
                                        <asp:CheckBox ID="chkShowInRpt" ForeColor="#FF9900" Font-Names="Tahoma" Font-Bold="true"
                                            Font-Size="10pt" Text="Show" runat="server" />
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td width="43%" align="right" class="style20" valign="top">
                                        Comment :
                                        <td width="57%" class="style20">
                                            <asp:TextBox ID="txtComment" runat="server" Columns="20" Font-Bold="True" Font-Names="Tahoma"
                                                ForeColor="#FF9900" Height="52px" TextMode="MultiLine" Width="299px"></asp:TextBox>
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
                                        <span class="style28"><span class="style32">
                                            <asp:SqlDataSource ID="SqlAppearOn" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                                                ProviderName="<%$ ConnectionStrings:SDTConnectionString.ProviderName %>" SelectCommand="SELECT appear_status_id, appear_status_name, create_dtm, create_by, last_update_dtm, last_update_by FROM tblMovie_Appear_Status">
                                            </asp:SqlDataSource>
                                        </span></span>
                                        <br />
                                    </td>
                                </tr>
                                <tr bgcolor="#F0DFD0">
                                    <td colspan="2" class="style53" align="center" bgcolor="#879CC2">
                                        --------------------------------------------------------------------<br />
                                        List of ralease theatres
                                        <br />
                                        ---------------------------------------------------------------------
                                    </td>
                                </tr>
                                <%-- DataSourceID="SqlTheatrehow" --%>
                                <tr bgcolor="#F0DFD0">
                                    <td colspan="2" align="center" height="40">
                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None"
                                            Width="100%">
                                            <FooterStyle BackColor="#5D7B9D" Font-Size="9pt" Font-Bold="True" ForeColor="White" />
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <Columns>
                                                <asp:BoundField DataField="theater_code" ReadOnly="true" HeaderText="Theatre Code"
                                                    SortExpression="theater_code" />
                                                <asp:BoundField DataField="theater_name" ReadOnly="true" HeaderText="Theatre" SortExpression="theater_name" />
                                                <asp:HyperLinkField DataTextField="onrelease_startdate" DataTextFormatString="{0:ddd dd-MMM-yyy}"
                                                    HeaderText="Release Date" SortExpression="onrelease_startdate" />
                                                <asp:HyperLinkField DataTextField="onrelease_enddate" DataTextFormatString="{0:ddd dd-MMM-yyyy}"
                                                    HeaderText="Terminate Date" SortExpression="onrelease_enddate" />
                                                <asp:HyperLinkField DataNavigateUrlFields="theater_id" DataNavigateUrlFormatString="frmCTBV_unterminate.aspx?theaterId={0}"
                                                    DataTextField="movie_statusTitle" HeaderText="Status" SortExpression="movie_statusTitle" />
                                                <asp:TemplateField SortExpression="ProductName" ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center" HeaderText="No. of Print">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txttheater_id" Visible="false" runat="server" Text='<%# Bind("theater_id") %>'></asp:TextBox>
                                                        <asp:TextBox ID="editprint_qty" runat="server" onblur="ValidInt()" Style="text-align: right"
                                                            Text='<%# Bind("print_qty") %>'></asp:TextBox>
                                                        <%--<asp:Button ID="Button1" runat="server" Text="btnFocus" />--%>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Bind("print_qty") %>' ID="Label3"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="movies_id" HeaderText="movies_id " Visible="false" SortExpression="movies_id" />
                                                <asp:BoundField DataField="theater_id" HeaderText="theater_id " Visible="false" SortExpression="theater_id" />
                                                <asp:CommandField ShowEditButton="True" UpdateText="Save |" />
                                            </Columns>
                                            <PagerStyle BackColor="#284775" ForeColor="White" Font-Size="9pt" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="9pt" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                                                Font-Size="10" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" Font-Size="9pt" ForeColor="#284775" />
                                        </asp:GridView>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
    </table>
    <asp:SqlDataSource ID="sqlDistibutor" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT distributor_name, distributor_id FROM tblDistributor WHERE (active_flag = 'Y')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlStudio" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT studio_id, studio_name FROM tblStudio"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sqlTheater" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT tblTheater.theater_id, tblTheater.theater_code, tblTheater.theater_name, COUNT(tblTheaterSub.TheaterSub_id) AS TheaterNo, SUM(tblTheaterSub.TheaterSub_normalseat) AS nomalseat, SUM(tblTheaterSub.TheaterSub_vipseat) AS vipseat FROM tblTheater LEFT OUTER JOIN tblTheaterSub ON tblTheater.theater_id = tblTheaterSub.theater_id GROUP BY tblTheater.theater_id, tblTheater.theater_code, tblTheater.theater_name">
    </asp:SqlDataSource>
    <%-- <asp:SqlDataSource ID="SqlTheatrehow" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="
SELECT tblTheater.theater_name, tblTheater.theater_code, temprelease.onrelease_id, temprelease.onrelease_status
, temprelease.onrelease_startdate, tblMovieStatus.movie_statusTitle, tblMovieStatus.movie_statusCode
, temprelease.onrelease_enddate, temprelease.movies_id, tblTheater.theater_id, temprelease.print_qty
FROM tblMovieStatus 
RIGHT OUTER JOIN 
(SELECT r.onrelease_id, r.onrelease_status, r.onrelease_startdate, r.onrelease_enddate, 
r.movies_id, r.theater_id, isnull(mt.print_qty, 0) as print_qty
FROM tblRelease r
left join tblMovie_Theater mt on r.movies_id = mt.movie_id
and r.theater_id = mt.theater_id
WHERE (movies_id = @titleId)
) AS temprelease ON tblMovieStatus.movie_statusId = temprelease.onrelease_status 
RIGHT OUTER JOIN 
(SELECT theater_id, theater_code, theater_name, theater_des, theater_status, theater_lastupdate, user_id, circuit_id 
FROM tblTheater AS tblTheater_1 
WHERE (theater_status = 'Enabled')
) 
AS tblTheater ON temprelease.theater_id = tblTheater.theater_id 
ORDER BY temprelease.onrelease_status, tblTheater.theater_name
                                ">
        <SelectParameters>
            <asp:QueryStringParameter Name="titleId" QueryStringField="titleId" />
        </SelectParameters>
    </asp:SqlDataSource>--%>
    <asp:HiddenField ID="hidDEL_tblRevenue" runat="server" />
    <asp:HiddenField ID="hidDEL_tblCompRevenue" runat="server" />
    <asp:HiddenField ID="hidDEL_tblRelease" runat="server" />
    <asp:HiddenField ID="hidAppear" runat="server" />
    <asp:HiddenField ID="hidTrailerColDtl" runat="server" />
    <input type="hidden" id="PageX" name="PageX" value="0" runat="server" />
    <input type="hidden" id="PageY" name="PageY" value="0" runat="server" />

    <script language="javascript" type="text/javascript">
function ScrollIt(){
window.scrollTo(document.Form1.PageX.value, document.Form1.PageY.value);
}
function setcoords(){
var myPageX;
var myPageY;
if (document.all){
myPageX = document.body.scrollLeft;
myPageY = document.body.scrollTop;
}
else{
myPageX = window.pageXOffset;
myPageY = window.pageYOffset;
}
document.Form1.PageX.value = myPageX;
document.Form1.PageY.value = myPageY;
}
    </script>

    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

<%--UpdateCommand=" exec spTblMovie_Theater_Insert 1,@theater_id,@print_qty,@create_by,@last_update_by "--%><%--UpdateCommand="	UPDATE [tblMovie_Theater]
	SET 
	  [print_qty] = @print_qty
	  ,[create_dtm] = getdate()
	  ,[create_by] = @create_by
	  ,[last_update_dtm] = getdate()
	  ,[last_update_by] = @last_update_by
	WHERE [movie_id] = @movies_id
	  and [theater_id] = @theater_id"
  >--%><%--                                
                                <UpdateParameters>
                                    <asp:SessionParameter Name="create_by" SessionField="UserID" />
                                    <asp:SessionParameter Name="last_update_by" SessionField="UserID" />
                                </UpdateParameters>--%>