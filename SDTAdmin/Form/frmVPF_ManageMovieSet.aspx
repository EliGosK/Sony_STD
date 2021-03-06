<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmVPF_ManageMovieSet.aspx.vb"
    Inherits="Form.FrmVpfManageMovieSet" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<%@ Register Src="~/Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="ucMovie1Popup" %>
<%@ Register Src="../Controls/DatePicker.ascx" TagName="datepicker" TagPrefix="uc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Manage&nbsp;Movie&nbsp;Set
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
                    &nbsp;Virtual Print Fee</a> &gt; </b><strong>Manage Movie Set</strong>
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
                                    <span class="titleText">Manage Movie Set</span>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: center;">
                        <table class="normalTable">
                            <tr class="valueSet">
                                <td align="right">
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
                                <tr class="valueSet">
                                    <td align="right" width="100px">
                                        Theater :&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTheater" runat="server" ForeColor="#FF9900" AutoPostBack="True"
                                            Width="300px">
                                            <asp:ListItem> </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="valueSet">
                                    <td align="right" width="100px">
                                        Format :&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server" ForeColor="#FF9900" AutoPostBack="True"
                                            Width="300px">
                                            <asp:ListItem> </asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:Panel ID="pnlResult" runat="server">
                                <asp:Panel ID="pnlToolBar" runat="server">
                                    <table class="updateTable">
                                        <tr>
                                            <td align="left" class="valueSet">
                                                <asp:Button ID="btnSelectAll" runat="server" Font-Size="XX-Small" Text="Select All"
                                                    Width="70px" />
                                                &nbsp;<asp:Button ID="btnSelectNone" runat="server" Font-Size="XX-Small" Text="Select None"
                                                    Width="70px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="key_string" Font-Names="Tahoma" Font-Size="X-Small"
                                    ForeColor="#333333" Width="90%" ShowFooter="True">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="theater_name" HeaderText="Theater Name" SortExpression="theater_name" />
                                        <asp:BoundField DataField="film_type_sound_header_group" HeaderText="Format" SortExpression="film_type_sound_header_group" />
                                        <asp:BoundField DataField="set_no" HeaderText="Set No" SortExpression="set_no" />
                                        <asp:BoundField DataField="vpf_start_date" HeaderText="Start Date" SortExpression="vpf_start_date"
                                            DataFormatString="{0:dd-MMM-yyyy}" />
                                        <asp:BoundField DataField="set_days" HeaderText="Days" SortExpression="set_days" />
                                        <asp:BoundField DataField="set_sessions" HeaderText="Sessions" SortExpression="set_sessions" />
                                        <asp:BoundField DataField="set_price" HeaderText="Accrual (Baht)" SortExpression="set_price"
                                            DataFormatString="{0:#,##0}" />
                                        <%--<asp:BoundField DataField="actual_price" HeaderText="Actual (Baht)" SortExpression="actual_price"
                                            DataFormatString="{0:#,##0}" />--%>
                                        <%--<asp:BoundField DataField="user_remark" HeaderText="Remark" SortExpression="user_remark" />--%>
                                        <asp:BoundField DataField="update_date" HeaderText="Last Update Date" SortExpression="update_date"
                                            DataFormatString="{0:dd-MMM-yyyy HH:mm}" />
                                        <asp:BoundField DataField="user_name" HeaderText="Last Update By" SortExpression="user_name" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnAddMoreSet" runat="server" CausesValidation="False" CommandArgument='<%# Bind("key_string") %>'
                                                    CommandName="AddMoreSet" ForeColor="#FF6600" Text="Add more set"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
                            </asp:Panel>
                            <asp:Label ID="lblNotFound" runat="server" CssClass="importantText" Text="Not found any data !"
                                Visible="False"></asp:Label>
                            <br />
                            <asp:Button ID="btnLoadDefaultSet" runat="server" Text="Load default set" Visible="False" />
                            <br />
                            <asp:Panel ID="pnlActionAdd" runat="server" Visible="False">
                                <table class="updateTable">
                                    <tr class="valueSet">
                                        <td colspan="2">
                                            <div style="text-align: center;">
                                                <asp:Label ID="lblAddAction" runat="server" Text="Update data" CssClass="importantText"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="valueSet">
                                        <td align="right" valign="top">
                                            Theater Name :&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTheaterName" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdfTheaterId" runat="server" />
                                        </td>
                                    </tr>
                                    <tr class="valueSet">
                                        <td align="right" valign="top">
                                            Format :&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFormat" runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdfFilmTypeSoundId" runat="server" />
                                        </td>
                                    </tr>
                                    <tr class="valueSet">
                                        <td align="right" valign="top">
                                            Set No. :&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSetNo" runat="server"></asp:Label>
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
                                            Start Date :&nbsp;&nbsp;
                                        </td>
                                        <td valign="top">
                                            <uc1:datepicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True">
                                            </uc1:datepicker>
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
                                            1 set =
                                            <asp:TextBox ID="txtSetDays" runat="server" Width="106px">7</asp:TextBox>
                                            &nbsp;day(s).
                                            <br />
                                            1 set =
                                            <asp:TextBox ID="txtSetSessions" runat="server" Width="106px">14</asp:TextBox>
                                            &nbsp;session(s).<br />
                                            1 set =
                                            <asp:TextBox ID="txtSetPrice" runat="server" Width="106px">15000</asp:TextBox>
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
                                                <asp:Label ID="lblError" runat="server" Text="Error !" Visible="False" CssClass="importantText"></asp:Label>
                                                <br />
                                                <asp:ImageButton ID="btnInsertUpdate" runat="server" ImageUrl="~/images/UpdateCCC.png"
                                                    AlternateText="ADD" />
                                                <asp:ImageButton ID="btnCancelAdd" runat="server" AlternateText="CANCEL" ImageUrl="~/images/CancelCCC.png"
                                                    Visible="False" />
                                                <br />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:Panel>
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
