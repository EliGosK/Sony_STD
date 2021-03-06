<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmctbv_mmd_theater_seatprice.aspx.vb"
    Inherits=".frmctbv_mmd_theater_seatprice" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <title>SDT Management Information System - </title>
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
        .lbl
        {
            font-size: 10pt;
            font-family: "Tahoma";
            color: Navy;
        }
        .txtRight
        {
            text-align: right;
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
        .style32
        {
            color: #FF0000;
        }
        .style64
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
        .style65
        {
            width: 368px;
            height: 25px;
        }
        .style66
        {
            height: 7px;
        }
        .style67
        {
            height: 25px;
        }
        .style44
        {
            height: 27px;
            color: #FF0000;
        }
        .style68
        {
            height: 31px;
        }
        .style69
        {
            height: 23px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
    <asp:Panel ID="Panel1" runat="server">
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
                                &nbsp;
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
                        &gt;
                        <asp:LinkButton ID="btnAddThatre" runat="server">Theatre</asp:LinkButton>
                        &nbsp;&gt; </b><strong>Seat Type</strong>
                </td>
            </tr>
            <tr>
                <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                    <table width="100%" border="1" align="center" cellpadding="3" cellspacing="3" bgcolor="#f0cd8c">
                        <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                            <td height="27" background="../images/BG8.jpg">
                                <div align="center" class="style1">
                                    <span class="style2">Seat Type</span>
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
                                                    <tr bgcolor="#DADADA">
                                                        <td>
                                                            <div align="right" class="lbl">
                                                                Theatre :</div>
                                                        </td>
                                                        <td width="55%" align="left">
                                                            <asp:Label ID="lblTheatre" runat="server" CssClass="lbl" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#DADADA">
                                                        <td class="style69">
                                                            <div align="right" class="lbl">
                                                                Screen No. :</div>
                                                        </td>
                                                        <td width="55%" align="left" class="style69">
                                                            <asp:Label ID="lblScreenNo" runat="server" CssClass="lbl" Font-Bold="True"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" align="right" class="lbl"
                                                                Text="Capacity : "></asp:Label>
                                                            <asp:Label ID="lblCapacity" runat="server" CssClass="lbl" Font-Bold="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td colspan="2" class="style66">
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style64">
                                                            <div align="right" class="style24 style33">
                                                                Type of Seat :</div>
                                                        </td>
                                                        <td width="55%" class="style41" align="left">
                                                            <span class="style32">
                                                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                                                *</span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style64">
                                                            <div align="right" class="style24 style33">
                                                                No. of Seat :</div>
                                                        </td>
                                                        <td width="55%" class="style41" align="left">
                                                            <span class="style32">
                                                                <asp:TextBox ID="txtNo" onblur="ValidInt()" CssClass="txtRight" runat="server"></asp:TextBox>
                                                                *</span>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style64">
                                                            <div align="right" class="style24 style33">
                                                                Weekend Price :</div>
                                                        </td>
                                                        <td width="55%" class="style41" align="left">
                                                            <asp:TextBox ID="txtWeekend" onblur="ValidNum()" CssClass="txtRight" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style64">
                                                            <div align="right" class="style24 style33">
                                                                Weekday Price :</div>
                                                        </td>
                                                        <td width="55%" class="style41" align="left">
                                                            <asp:TextBox ID="txtWeekday" onblur="ValidNum()" CssClass="txtRight" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style65">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style67" align="left">
                                                            <asp:Label ID="lblError" runat="server" Font-Size="8pt" ForeColor="Red" Font-Bold="true"
                                                                Visible="False">Please check require flield (*)</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/images/SaveCCC.png" />
                                                            <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/images/BackCCC.png" />
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td class="style68" colspan="2">
                                                            &nbsp;
                                                            <asp:Label ID="lblNotMatch" runat="server" BackColor="#FF5E5E" Font-Bold="True" ForeColor="White"
                                                                Text="Number of seat not match !." Width="600px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td valign="top" colspan="2">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                DataSourceID="SqltblTheaterSubSeat" ForeColor="#333333" GridLines="None" Font-Names="Tahoma"
                                                                Font-Size="Small" Width="600px" DataKeyNames="seat_type_id">
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                <Columns>
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnSelect" runat="server" CausesValidation="False" CommandName="Select"
                                                                                Text="Select" CommandArgument='<%# Bind("seat_type_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="seat_type_name" HeaderText="Type of Seat" SortExpression="seat_type_name" />
                                                                    <asp:BoundField DataField="seat_qty" HeaderText="No. of Seat" SortExpression="seat_qty" />
                                                                    <asp:BoundField DataField="weekend_price_amt" HeaderText="Weekend Price" SortExpression="weekend_price_amt" />
                                                                    <asp:BoundField DataField="weekday_price_amt" HeaderText="Weekday Price" SortExpression="weekday_price_amt" />
                                                                    <asp:TemplateField ShowHeader="False">
                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Del"
                                                                                Text="Delete" OnClientClick="return confirm('Do you want to delete this Seat Type?')"
                                                                                CommandArgument='<%# Bind("seat_type_id") %>' ForeColor="#FF6600"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
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
                                                        <td valign="top">
                                                            &nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr bgcolor="#F0DFD0">
                                                        <td valign="top" class="style64">
                                                            &nbsp;
                                                        </td>
                                                        <td class="style44" align="left">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                    </table>
                    <asp:SqlDataSource ID="SqltblTheaterSubSeat" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
                        SelectCommand="SELECT seat_type_name, seat_qty, weekend_price_amt, weekday_price_amt, create_dtm, create_by, last_update_dtm, last_update_by, seat_type_id FROM tblTheaterSub_Seat WHERE (theater_id = @theater_id) AND (theatersub_id = @theatersub_id) ORDER BY seat_type_id">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="theater_id" SessionField="theaterId" />
                            <asp:SessionParameter DefaultValue="0" Name="theatersub_id" SessionField="theaterSubId" />
                        </SelectParameters>
                    </asp:SqlDataSource>
    </asp:Panel>
    <%@ register src="~/Controls/Copyrights.ascx" tagname="Copyrights" tagprefix="ucCopyRights" %>
    <ucCopyRights:Copyrights id="copyRights" runat="server" />
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
SetOnKeyDownEnter(window.document)
</script>

