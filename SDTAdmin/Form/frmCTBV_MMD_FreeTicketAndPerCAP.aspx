<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_FreeTicketAndPerCAP.aspx.vb"
    Inherits="Form.FrmCtbvMmdFreeTicketAndPerCap" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Free&nbsp;Ticket&nbsp;and&nbsp;CAP&nbsp;Master
    </title>
    <link href="../Admin.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <script language="javascript" type="text/javascript" src="../js/Utils.js"></script>

    <script language="javascript" type="text/javascript">
        SetOnKeyDownEnter(window.document)
    </script>

</head>
<body class="masterBody">
    <form id="form1" runat="server">
    <table class="headerTable">
        <tr>
            <td style="height: 23px">
                <ucctbvCtlTop:ctbvCtlTop ID="CtbvCtlTop1" runat="server" />
            </td>
            <td align="right">
                <table>
                    <tr>
                        <td align="center">
                            <a href="frmCTBV_Login.aspx">
                                <asp:ImageButton ID="btnExit" runat="server" ImageUrl="~/images/Exit.png" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td class="logout">
                            Log Out
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table class="menuLevel">
        <tr>
            <td>
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_Ticket.aspx">
                    &nbsp;Ticket / Cap Master</a> &gt; </b><strong>Free Ticket and Cap Master</strong>
            </td>
        </tr>
    </table>
    <div class="mainDiv">
        <table class="mainTable" height="29" bordercolor="#e6b04d" border="1" align="center"
            cellpadding="3" cellspacing="3">
            <tr>
                <td>
                    <div align="center" class="titleDiv">
                        <span class="titleText">Free Ticket and Cap Master</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align: center;">
                        Circuit:&nbsp;<asp:DropDownList ID="ddlCircuit" runat="server" ForeColor="#FF9900"
                            AutoPostBack="True">
                            <asp:ListItem> </asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="ticket_cap_id" Font-Names="Tahoma" Font-Size="X-Small"
                            ForeColor="#333333" Width="90%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="ticket_cap_name" HeaderText="Ticket/CAP Name" SortExpression="ticket_cap_name" />
                                <asp:CheckBoxField DataField="counting" HeaderText="Count People" SortExpression="counting" />
                                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                                <asp:BoundField DataField="default_price" HeaderText="Default Price" SortExpression="default_price" />
                                <asp:BoundField DataField="theater_name_list" HeaderText="Use at" SortExpression="theater_name_list" />
                                <asp:CheckBoxField DataField="active_flag" HeaderText="Active" SortExpression="active_flag" />
                                <asp:BoundField DataField="update_date" HeaderText="Last Update Date" SortExpression="update_date" />
                                <asp:BoundField DataField="update_name" HeaderText="Last Update By" SortExpression="update_name" />
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument='<%# Bind("ticket_cap_id") %>'
                                            CommandName="Edit" ForeColor="#FF6600" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                        <br />
                        <table class="updateTable">
                            <tr class="valueSet">
                                <td colspan="2">
                                    <div style="text-align: center;">
                                        <asp:Label ID="lblAction" runat="server" Text="Add data" CssClass="importantText"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td class="valueSetTitle">
                                    For Circuit :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="focusText">
                                    <%=ddlCircuit.SelectedItem.Text%>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td class="valueSetTitle">
                                    Ticket/CAP Name :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="focusText">
                                    <asp:TextBox ID="txtName" runat="server" Width="100%" MaxLength="250"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td>
                                </td>
                                <td class="focusText">
                                    <asp:CheckBox ID="chkCount" runat="server" Text="Count People" />
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td class="valueSetTitle">
                                    Price From :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="focusText">
                                    <asp:TextBox ID="txtPriceFrom" runat="server" MaxLength="4"></asp:TextBox>
                                    &nbsp;To
                                    <asp:TextBox ID="txtPriceTo" runat="server" MaxLength="4"></asp:TextBox>
                                    &nbsp;Step
                                    <asp:TextBox ID="txtStep" runat="server" MaxLength="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td class="valueSetTitle">
                                    Default :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="focusText">
                                    <asp:TextBox ID="txtDefault" runat="server" MaxLength="4"></asp:TextBox>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td class="valueSetTitle">
                                    Use at Theater(s) :&nbsp;&nbsp;&nbsp;
                                </td>
                                <td class="focusText">
                                    <asp:Button ID="btnSelectAll" runat="server" Font-Size="XX-Small" Text="Select All"
                                        Width="70px" />
                                    &nbsp;<asp:Button ID="btnSelectNone" runat="server" Font-Size="XX-Small" Text="Select None"
                                        Width="70px" />
                                    &nbsp;
                                    <asp:Repeater ID="rptList" runat="server">
                                        <HeaderTemplate>
                                            <table class="dynamicCheckbox">
                                                <tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <td>
                                                <asp:CheckBox ID="chkTherter" runat="server" Text="<%# Bind('theater_name') %>" />
                                                <asp:HiddenField ID="hdfTheaterId" runat="server" Value="<%# Bind('theater_id') %>" />
                                            </td>
                                            <%#Eval("sep")%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tr> </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td>
                                </td>
                                <td class="focusText">
                                    <asp:CheckBox ID="chkActive" runat="server" Text="Active" />
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td colspan="2">
                                    <div style="text-align: center;">
                                        <asp:HiddenField ID="hdfKeyId" runat="server" />
                                        <asp:Label ID="lblError" runat="server" Text="Please input name !" Visible="False"
                                            CssClass="importantText"></asp:Label>
                                        <br />
                                        <asp:ImageButton ID="btnInsertUpdate" runat="server" ImageUrl="~/images/ADDCCC.png"
                                            AlternateText="ADD" />
                                        <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/CancelCCC.png"
                                            AlternateText="CANCEL" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <ucCopyRights:Copyrights ID="copyRights" runat="server" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
</html>
