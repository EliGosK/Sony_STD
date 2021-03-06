<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Theater_Add.aspx.vb"
    Inherits="frmCTBV_MMD_Theater_Add" %>

<%@ Register TagPrefix="uc1" TagName="ctbvCtlTop" Src="../Controls/ctbvCtlTop.ascx" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT Management Information System -Theatre</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
        .style28
        {
            font-size: 14;
        }
        .style31
        {
            font-size: 10px;
        }
        .style40
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 27px;
        }
        .style33
        {
            font-family: "Tahoma";
        }
        .style24
        {
            font-size: 14px;
        }
        .style41
        {
            font-size: 14px;
            font-family: "Tahoma";
            height: 27px;
        }
        .style32
        {
            color: #FF0000;
        }
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
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
        .style44
        {
            height: 27px;
            color: #FF0000;
        }
        .style64
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 27px;
            width: 30%;
        }
        .style65
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 20px;
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

    <meta http-equiv="Content-Type" content="text/html; charset=windows-874">
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
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
                    &nbsp;Manage Master Data</a> &gt; <a href="frmCTBV_MMD_Theater.aspx">MMD : Theatre
                    </a>&gt; </b><strong>Theatre </strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                <font size="2"><font color="#000000"><font face="Tahoma" size="1"><strong></strong></font>
                </font></font>
                <table width="100%" border="1" align="center" cellpadding="3" cellspacing="3" bgcolor="#f0cd8c">
                    <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                        <td height="27" background="../images/BG8.jpg">
                            <div align="center" class="style1">
                                <span class="style2">Theatre </span>
                            </div>
                        </td>
                    </tr>
                    <tr bordercolor="#999999" bgcolor="#ffffff">
                        <td height="341" align="center" bgcolor="#E2E2E2" valign="top">
                            <table border="0" cellspacing="1" width="99%">
                                <tr>
                                    <td bgcolor="#f0cd8c">
                                        <div align="center" class="style15">
                                            <table width="100%" border="0" cellspacing="0">
                                                <tr bgcolor="#F0DFD0">
                                                    <td width="43%" class="style40">
                                                        <div align="right" class="style24 style33">
                                                            Theatre Name :</div>
                                                    </td>
                                                    <!- Select circuit_Id from tblCiruit -! >
                                                    <td width="57%" class="style41">
                                                        <span class="style32">
                                                            <asp:TextBox ID="txtTheater" runat="server" Width="194px"></asp:TextBox>
                                                            *</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style42">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Theatre Code :</div>
                                                        </div>
                                                    </td>
                                                    <td class="style43">
                                                        <span class="style28"><span class="style31"><span class="style32">
                                                            <asp:TextBox ID="txtTheaterCode" runat="server" Width="192px"></asp:TextBox>
                                                        </span></span></span>
                                                    </td>
                                                </tr>
                                                   <tr bgcolor="#F0DFD0">
                                                    <td class="style42">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Group Type :</div>
                                                        </div>
                                                    </td>
                                                    <td class="style43" align="left">
                                                        <span class="style28"><span class="style31"><span class="style32">
                                                            <asp:TextBox ID="txtGroupType" runat="server" Width="192px" MaxLength="50"></asp:TextBox>
                                                        </span></span></span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style1">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Circuit :&nbsp;
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style31">
                                                            <asp:DropDownList ID="ddlCircuit" runat="server" DataSourceID="sqlCircuit" DataTextField="circuit_name"
                                                                DataValueField="circuit_id">
                                                                <asp:ListItem Value="1">Checker</asp:ListItem>
                                                                <asp:ListItem Value="2">Administrator</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style1">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                &nbsp;Status :</div>
                                                    </td>
                                                    <td class="style20">
                                                        <span class="style31">
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                                <asp:ListItem Value="Enabled">Enabled</asp:ListItem>
                                                                <asp:ListItem Value="Disenabled">Disenabled</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style64">
                                                        <div align="right" class="style20">
                                                            Comment :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:TextBox ID="txtTheaterDes" runat="server" Width="273px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style64">
                                                        <div align="right" class="style20">
                                                            Start Date :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left" valign="middle">
                                                        <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"></uc1:DatePicker>
                                                        <%--<asp:TextBox ID="txtOpenDate" onblur="ValidDate()" runat="server" 
                                                            Width="130px"></asp:TextBox>--%>
                                                        <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF3300"
                                                            Text="* Format dd/mm/yyyy  Ex. 31/12/2008" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style64">
                                                        <div align="right" class="style20">
                                                            End Date :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left" valign="middle">
                                                        <uc1:DatePicker ID="dtEndDate" runat="server" TxtDateReadOnly="False" TxtDateShowPopup="True"></uc1:DatePicker>
                                                        <%--<asp:TextBox ID="txtCloseDate" onblur="ValidDate()" runat="server" 
                                                            Width="130px"></asp:TextBox>--%>
                                                        <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF3300"
                                                            Text="Format dd/mm/yyyy  Ex. 31/12/2008" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--<tr bgcolor="#F0DFD0">
                                                <td class="style1"><div align="right" class="style20">
                                                  <div align="right">Film System Type : </div>
                                                </div></td>
                                                <td class="style20"><span class="style31">
                                                    <asp:DropDownList ID="ddlImaxFlag" runat="server" Width="81px" >
                                                        <asp:ListItem Value="n">Normal</asp:ListItem>
                                                        <asp:ListItem Value="y">IMAX</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span></td>
                                              </tr>--%>
                                                <tr bgcolor="#F0DFD0">
                                                    <td valign="top" class="style64">
                                                        <div align="right" class="style20">
                                                            Price/Promotion Comment :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="504px" Height="251px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td valign="top" class="style64">
                                                        <div align="right" class="style20">
                                                            Film Type :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:GridView ID="gvFilmType" runat="server" AutoGenerateColumns="False" Font-Size="X-Small"
                                                            CellPadding="4" ForeColor="#333333" GridLines="None">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkStatusFlag" runat="server" Checked='<%# Bind("status_flag") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFilmTypeID" runat="server" Text='<%# Bind("film_type_id") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Left" Width="40px" />
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="film_type_name" HeaderText="Name">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="120px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="open_date" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="140px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="close_date" HeaderText="Close Date" DataFormatString="{0:dd/MM/yyyy}">
                                                                    <HeaderStyle HorizontalAlign="Left" Width="120px"></HeaderStyle>
                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                </asp:BoundField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style65" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style40" align="center" colspan="2">
                                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                                            Visible="False">Please check require flield (*)</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td colspan="2" class="style16">
                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 120px;">
                                                            <tr>
                                                                <td align="left">
                                                                    <asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                                        AlternateText="SAVE" OnClick="imbSaveClose_Click" />
                                                                </td>
                                                                <td align="right">
                                                                    &nbsp;<asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/BackCCC.png"
                                                                        AlternateText="BACK" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                </table>
    </table>
    <asp:SqlDataSource ID="sqlCircuit" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT [circuit_name], [circuit_id] FROM [tblCircuit]"></asp:SqlDataSource>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

