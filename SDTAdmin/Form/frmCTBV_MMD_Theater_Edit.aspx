<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Theater_Edit.aspx.vb"
    Inherits=".frmCTBV_MMD_Theater_Edit" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <title>SDT Management Information System - </title>
    <style type="text/css">
        .style32
        {
            color: #FF0000;
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
        .style15
        {
            font-weight: bold;
            font-size: 16px;
            font-family: "Tahoma";
            color: #666666;
        }
        .style40
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 27px;
        }
        .style24
        {
            font-size: 14px;
        }
        .style33
        {
            font-family: "Tahoma";
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
            width: 30%;
        }
        .style20
        {
            font-size: 14px;
            font-family: "Tahoma";
        }
        .style43
        {
            font-size: 14px;
            font-family: "Tahoma";
            height: 26px;
        }
        .style28
        {
            font-size: 14;
        }
        .style31
        {
            font-size: 10px;
        }
        .style53
        {
            font-weight: bold;
            font-size: 14px;
            color: #FFFFFF;
            font-family: "Tahoma";
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
            width: 30%;
        }
        .style66
        {
            font-weight: bold;
            font-size: 16px;
            color: #666666;
            font-family: Tahoma;
            height: 33px;
        }
        .style67
        {
            height: 13px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
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
                            &nbsp;<asp:ImageButton ID="imbOut" runat="server" ImageUrl="~/images/Exit.png" />
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
                    &nbsp;Manage Master Data</a> &gt; <a href="frmCTBV_MMD_Theater.aspx">MMD : Theatre</a>
                    &gt; </b><strong>Theatre </strong>
            </td>
        </tr>
        <tr>
            <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
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
                                                    <td class="style64">
                                                        <div align="right" class="style24 style33">
                                                            Theatre Name :</div>
                                                    </td>
                                                    <!- Select circuit_Id from tblCiruit -! >
                                                    <td width="57%" class="style41" align="left">
                                                        <asp:TextBox ID="txtTheater" runat="server" Width="194px"></asp:TextBox>
                                                        <span class="style32">*</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style42">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Theatre Code :</div>
                                                        </div>
                                                    </td>
                                                    <td class="style43" align="left">
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
                                                    <td class="style65">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Circuit :
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="style20" align="left">
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
                                                    <td class="style20" align="left">
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
                                                            Width="130px"></asp:TextBox><span class="style32">*</span>--%>
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
                                                        <uc1:DatePicker ID="dtpEndDate" runat="server" TxtDateReadOnly="False" TxtDateShowPopup="True"></uc1:DatePicker>
                                                        <%--<asp:TextBox ID="txtCloseDate" onblur="ValidDate()" runat="server" 
                                                            Width="130px"></asp:TextBox>--%>
                                                        <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF3300"
                                                            Text="Format dd/mm/yyyy  Ex. 31/12/2008" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <%--<tr bgcolor="#F0DFD0">
                                                    <td class="style65">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Film System Type :
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td class="style20" align="left">
                                                        <span class="style31">
                                                    <asp:DropDownList ID="ddlImaxFlag" runat="server" Width="81px" >
                                                        <asp:ListItem Value="n">Normal</asp:ListItem>
                                                        <asp:ListItem Value="y">IMAX</asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                                    </td>
                                                </tr>--%>
                                                <tr bgcolor="#F0DFD0">
                                                    <td valign="top" class="style64">
                                                        <div align="right" class="style20">
                                                            Price/Promotion Comment :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:TextBox ID="txtRemark" runat="server" Width="500px" Height="251px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td valign="top" class="style64">
                                                        <div align="right" class="style20">
                                                            Film Type :
                                                        </div>
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:GridView ID="gvFilmType" runat="server" AutoGenerateColumns="False" Font-Size="Small"
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
                                                    <td valign="top" class="style64">
                                                        &nbsp;
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                                            Visible="False">Please check require flield (*)</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td valign="top" class="style64">
                                                        &nbsp;
                                                    </td>
                                                    <td class="style44" align="left">
                                                        <asp:ImageButton ID="imbSaveClose" runat="server" ImageUrl="~/images/SaveCCC.png"
                                                            AlternateText="SAVE" OnClick="imbSaveClose_Click" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="imbCancel" runat="server" ImageUrl="~/images/BackCCC.png" AlternateText="BACK" />
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td class="style66" align="center" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F0DFD0">
                                                    <td colspan="2" class="style53" align="center" bgcolor="#879CC2">
                                                        <a id="#SubDetail" name="SubDetail"></a>--------------------------------------------------------------------<br />
                                                        Screen Management
                                                        <br />
                                                        ---------------------------------------------------------------------
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td class="style67" align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td align="left" class="style67">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tblTSub" runat="server" width="100%" border="0" cellspacing="0">
                                                <tr id="trMovieID" runat="server" bgcolor="#DDDDDD">
                                                    <td width="30%">
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Screen No. :</div>
                                                        </div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtScreenId0" BackColor="Silver" runat="server" Width="114px" ReadOnly="True"></asp:TextBox>
                                                        &nbsp;</span>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Screen Code :</div>
                                                        </div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtScreenCode0" runat="server" Width="114px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Capacity :</div>
                                                        </div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtSeat0" runat="server" Width="114px"></asp:TextBox>
                                                        <asp:Label ID="label101" runat="server" Font-Bold="True" Font-Size="10pt" ForeColor="Red">*</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        <div align="right" class="style20">
                                                            Film Type :</div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:CheckBox ID="chkMM" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="35 mm." />
                                                        &nbsp;&nbsp;
                                                        <asp:CheckBox ID="chkDigital" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                                                            Text="Digital" />
                                                        &nbsp;&nbsp;
                                                        <asp:CheckBox ID="chkDimention" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                                                            Text="3D" AutoPostBack="True" />
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                Start Date :</div>
                                                        </div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtOpenSubDate" onblur="ValidDate()" runat="server" Width="114px"></asp:TextBox><span
                                                            class="style32">*</span> &nbsp;<asp:Label ID="Label4" runat="server" Font-Names="Tahoma"
                                                                Font-Size="9pt" ForeColor="#FF3300" Text="Format dd/mm/yyyy  Ex. 31/12/2008"
                                                                Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        <div align="right" class="style20">
                                                            <div align="right">
                                                                End Date :</div>
                                                        </div>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtCloseSubDate" onblur="ValidDate()" runat="server" Width="114px"
                                                            Height="22px"></asp:TextBox>
                                                        &nbsp;<asp:Label ID="Label5" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF3300"
                                                            Text="Format dd/mm/yyyy  Ex. 31/12/2008" Font-Bold="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                    </td>
                                                    <td align="left">
                                                        <asp:CheckBox ID="chkActive" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                                                            Text="Active" />
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="lblErrorSub" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                                            Visible="False">Please check require flield (*)</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="left">
                                                        <asp:ImageButton ID="btnSaveSub" runat="server" ImageUrl="~/images/SaveCCC.png" />
                                                        &nbsp;<asp:ImageButton ID="btnCancelSub" runat="server" ImageUrl="~/images/CancelCCC.png" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0">
                                                <tr bgcolor="#F7FAFE">
                                                    <td style="width: 20%;" align="right">
                                                        <asp:ImageButton ID="btnNewTSub" runat="server" ImageUrl="~/images/NewCCC.png" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td colspan="2">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            DataSourceID="SqltblTheaterSub" ForeColor="#333333" GridLines="None" Font-Names="Tahoma"
                                                            Font-Size="Small" Width="800px" DataKeyNames="TheaterSub_id">
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                            <Columns>
                                                                <asp:CommandField ShowSelectButton="True" />
                                                                <asp:BoundField DataField="TheaterSub_id" HeaderText="Screen No." SortExpression="TheaterSub_id" />
                                                                <asp:BoundField DataField="TheaterSub_code" HeaderText="Screen Code" SortExpression="TheaterSub_code" />
                                                                <%-- <asp:BoundField DataField="TheaterSub_name" HeaderText="Screen ID" SortExpression="TheaterSub_name" />--%>
                                                                <asp:BoundField DataField="TheaterSub_normalseat" HeaderText="Capacity" SortExpression="TheaterSub_normalseat" />
                                                                <asp:BoundField DataField="type_flage" HeaderText="Film Type" SortExpression="type_flage"
                                                                    ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="openDate" HeaderText="Start Date" SortExpression="openDate" />
                                                                <asp:BoundField DataField="closeDate" HeaderText="End Date" SortExpression="closeDate" />
                                                                <asp:BoundField DataField="statusShow" HeaderText="Status" SortExpression="statusShow"
                                                                    Visible="false" />
                                                                <asp:HyperLinkField DataNavigateUrlFields="theatersub_id" DataNavigateUrlFormatString="frmctbv_mmd_theater_seatprice.aspx?screen={0}"
                                                                    HeaderText="" Text="Add Seat Type">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:HyperLinkField>
                                                                <%--<asp:TemplateField HeaderText="Status" SortExpression="statusShow" HeaderStyle-HorizontalAlign="center">
                                                                    <ItemStyle HorizontalAlign="center" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" CommandArgument='<%# Bind("TheaterSub_id") %>'
                                                                            CommandName="Select" Text='<%# Bind("statusShow") %>'></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>--%>
                                                            </Columns>
                                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#999999" />
                                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr bgcolor="#F7FAFE">
                                                    <td class="style40" align="center" colspan="2" bgcolor="#F7FAFE">
                                                        &nbsp;
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
    <asp:SqlDataSource ID="SqltblTheaterSub" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
        SelectCommand="SELECT theatersub_id, theatersub_code, theatersub_name, theatersub_description, theatersub_normalseat, theatersub_vipseat, theatersub_priceavg, theater_id, CASE status_flag WHEN 'Y' THEN 'Active' ELSE 'Inactive' END AS StatusShow, status_flag, CASE ISNULL(mm_flag , '') WHEN 'Y' THEN '35 mm.' ELSE '' END + CASE ISNULL(digital_flag , '') + mm_flag WHEN 'YY' THEN ', ' ELSE '' END + '' + CASE ISNULL(digital_flag , '') WHEN 'Y' THEN 'Digital' ELSE '' END + CASE ISNULL(mm_flag , 'N') + ISNULL(digital_flag , 'N') + ISNULL(dimention_flag , 'N') WHEN 'YYN' THEN '' WHEN 'YNN' THEN '' WHEN 'NYN' THEN '' WHEN 'NNN' THEN '' WHEN 'NNY' THEN '' ELSE ', ' END + '' + CASE ISNULL(dimention_flag , '') WHEN 'Y' THEN '3D' ELSE '' END AS type_flage, ISNULL(CONVERT (varchar(10), open_date, 103), '') AS openDate, ISNULL(CONVERT (varchar(10), close_date, 103), '') AS closeDate FROM tblTheaterSub WHERE (theater_id = @theaterId) ORDER BY theatersub_id">
        <SelectParameters>
            <asp:QueryStringParameter Name="theaterId" QueryStringField="theaterId"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

