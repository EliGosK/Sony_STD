<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmVPF_MovieDefaultSet.aspx.vb"
    Inherits="Form.FrmVpfMovieDefaultSet" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<%@ Register Src="~/Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="ucMovie1Popup" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Movie&nbsp;Default&nbsp;Set
    </title>
    <link href="../Admin.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

    <script language="javascript" type="text/javascript" src="../js/Utils.js"></script>

    <script language="javascript" type="text/javascript">
        function ManipulateGrid() {
            var gvDrv = document.getElementById("<%= grdResult.ClientID %>");
            var noCheck = true;
            for (var i = 1; i < gvDrv.rows.length; i++) {
                var cell = gvDrv.rows[i].cells;
                var html = cell[0].innerHTML;
                if (html.indexOf("chkSelect") != -1 && (html.indexOf("CHECKED") != -1 || html.indexOf("checked") != -1)) {
                    // Do you work here
                    //alert(cell[1].innerHTML + ' ---- ' + cell[3].innerHTML);
                    noCheck = false;
                    break;
                }
                var chk = cell[0].childNodes[1];
                if (chk.type == "checkbox" && chk.checked) {
                    noCheck = false;
                    break;
                }
            }
            if (noCheck) {
                alert("Please select any checkbox !");
                return false;
            } else {
                return confirm('Confirm to delete ?');
            }
        }
    </script>

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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_VPF.aspx">
                    &nbsp;Virtual Print Fee</a> &gt; </b><strong>Movie Default Set Master</strong>
            </td>
        </tr>
        <tr>
            <td>
                <div class="mainDiv">
                    <table class="mainTable" height="29" bordercolor="#e6b04d" border="1" align="center"
                        cellpadding="3" cellspacing="3">
                        <tr>
                            <td>
                                <div align="center" class="titleDiv">
                                    <span class="titleText">Movie Default Set Master</span>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: center;">
                        <table class="normalTable">
                            <tr class="valueSet">
                                <td align="right" valign="top">
                                    Movie :&nbsp;&nbsp;
                                </td>
                                <td>
                                    <ucMovie1Popup:Movie1Popup ID="moviePopup" runat="server" InStatus="1,2,3" AppearOnStatus="1,2,3"
                                        VisibleMovieType="False" />
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/SearchCCC.png"
                                        AlternateText="SEARCH" />
                                    <asp:ImageButton ID="btnCancelMovie" runat="server" ImageUrl="~/images/CancelCCC.png"
                                        AlternateText="CANCEL" Visible="False" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <asp:Panel ID="pnlDataPanel" runat="server" Visible="False">
                            <table class="normalTable">
                                <tr class="valueSet">
                                    <td align="right" width="100px">
                                        Circuit :&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCircuit" runat="server" ForeColor="#FF9900" AutoPostBack="True"
                                            Width="300px">
                                            <asp:ListItem> </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlToolBar" runat="server">
                                <table class="updateTable">
                                    <tr>
                                        <td align="left" class="valueSet">
                                            <asp:Button ID="btnGridSelectAll" runat="server" Font-Size="XX-Small" Text="Select All"
                                                Width="70px" />
                                            &nbsp;<asp:Button ID="btnGridSelectNone" runat="server" Font-Size="XX-Small" Text="Select None"
                                                Width="70px" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                CellPadding="4" DataKeyNames="key_string" Font-Names="Tahoma" Font-Size="X-Small"
                                ForeColor="#333333" Width="90%">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="circuit_name" HeaderText="Circuit Name" SortExpression="circuit_name" />
                                    <asp:BoundField DataField="film_type_sound_header_group" HeaderText="Format" SortExpression="film_type_sound_header_group" />
                                    <asp:BoundField DataField="vpf_start_date" HeaderText="VPF Start Date" SortExpression="vpf_start_date" />
                                    <%--<asp:BoundField DataField="sets_amount" HeaderText="Set Amount" SortExpression="sets_amount" />--%>
                                    <asp:BoundField DataField="set_days" HeaderText="Day(s)" SortExpression="set_days" />
                                    <asp:BoundField DataField="set_sessions" HeaderText="Session(s)/Days" SortExpression="set_sessions" />
                                    <asp:BoundField DataField="set_price" HeaderText="Baht(s)" SortExpression="set_price" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandArgument='<%# Bind("key_string") %>'
                                                CommandName="Edit" ForeColor="#FF6600" Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("key_string") %>'
                                                CommandName="Delete" ForeColor="#FF6600" Text="Delete"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            </asp:GridView>
                            <asp:Panel ID="pnlActionAll" runat="server">
                                <table class="updateTable">
                                    <tr>
                                        <td align="left">
                                            <asp:ImageButton ID="btnActionDelete" runat="server" AlternateText="DELETE" ImageUrl="~/images/DeleteCCC.png" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Label ID="lblNotFound" runat="server" CssClass="importantText" Text="Not found any data !"
                                Visible="False"></asp:Label>
                            <br />
                            <table class="updateTable">
                                <tr class="valueSet">
                                    <td colspan="2">
                                        <div style="text-align: center;">
                                            <asp:Label ID="lblAddAction" runat="server" Text="Add/Update data" CssClass="importantText"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td align="right" valign="top">
                                        Format(s) :&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:Repeater ID="rptList" runat="server">
                                            <HeaderTemplate>
                                                <table class="dynamicCheckbox">
                                                    <tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td>
                                                    <asp:CheckBox ID="chkName" runat="server" Text="<%# Bind('film_type_sound_header_group') %>" />
                                                    <asp:HiddenField ID="hdfId" runat="server" Value="<%# Bind('film_type_sound_id') %>" />
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
                                    <td align="right" valign="top">
                                        Start Date :&nbsp;&nbsp;
                                    </td>
                                    <td valign="top">
                                        <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True">
                                        </uc1:DatePicker>
                                        &nbsp;
                                        <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF6666"
                                            Text="* Format dd/mm/yyyy  Ex. 31/12/2008"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td align="right">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td align="right" valign="top">
                                        Set Detail :&nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td bgcolor="Gray">
                                        <asp:TextBox ID="txtAmountOfSet" runat="server" Width="106px" Visible="False">1</asp:TextBox>
                                        <br />
                                        1 set =
                                        <asp:TextBox ID="txtSetDays" runat="server" Width="106px"></asp:TextBox>
                                        &nbsp;day(s).
                                        <br />
                                        1 set =
                                        <asp:TextBox ID="txtSetSessions" runat="server" Width="106px"></asp:TextBox>
                                        &nbsp;session(s) per day.<br />
                                        1 set =
                                        <asp:TextBox ID="txtSetPrice" runat="server" Width="106px"></asp:TextBox>
                                        &nbsp;baht(s).<br />
                                        <br />
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td align="right">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td colspan="2">
                                        <div style="text-align: center;">
                                            <asp:Label ID="lblError" runat="server" Text="Please select any movie film format !"
                                                Visible="False" CssClass="importantText"></asp:Label>
                                            <br />
                                            <asp:ImageButton ID="btnInsertUpdate" runat="server" ImageUrl="~/images/AddCCC.png"
                                                AlternateText="ADD" />
                                            <br />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                    </div>
                    <br />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <ucCopyRights:Copyrights ID="copyRights" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
