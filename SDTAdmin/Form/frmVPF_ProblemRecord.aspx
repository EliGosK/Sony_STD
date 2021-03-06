<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmVPF_ProblemRecord.aspx.vb"
    Inherits="Form.frmVPFProblemRecord" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<%@ Register Src="~/Controls/Movie1Popup.ascx" TagName="Movie1Popup" TagPrefix="ucMovie1Popup" %>
<%@ Register TagPrefix="uc1" TagName="DatePicker" Src="~/Controls/DatePicker.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>SDT&nbsp;Management&nbsp;Information&nbsp;System&nbsp;-&nbsp;Problem&nbsp;Record
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
                    &nbsp;Virtual Print Fee</a> &gt; </b><strong>Problem Record</strong>
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
                                    <span class="titleText">Problem Record</span>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div style="text-align: center;">
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
                                    <asp:DropDownList ID="ddlTheater" runat="server" ForeColor="#FF9900" Width="300px">
                                        <asp:ListItem> </asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
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
                                <td align="right" width="100px">
                                    Start Date :&nbsp;&nbsp;
                                </td>
                                <td>
                                    <uc1:DatePicker ID="dtpStartDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True"
                                        OnClientDateSelectionChanged="AddDays(6);"></uc1:DatePicker>
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF6666"
                                        Text="* Format dd/mm/yyyy  Ex. 31/12/2008"></asp:Label>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td align="right" width="100px">
                                    End Date :&nbsp;&nbsp;
                                </td>
                                <td>
                                    <uc1:DatePicker ID="dtpEndDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True">
                                    </uc1:DatePicker>
                                    &nbsp;
                                    <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#FF6666"
                                        Text="* Format dd/mm/yyyy  Ex. 31/12/2008"></asp:Label>
                                </td>
                            </tr>
                            <tr class="valueSet">
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/SearchCCC.png"
                                        AlternateText="SEARCH" />
                                    <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/CancelCCC.png"
                                        AlternateText="CANCEL" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="pnlDataPanel" runat="server">
                            <table class="normalTable">
                            </table>
                            <br />
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
                                CellPadding="4" DataKeyNames="DataKey" Font-Names="Tahoma" Font-Size="X-Small"
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
                                    <asp:BoundField DataField="theater_name" HeaderText="Theater" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Top" />
                                    <asp:BoundField DataField="MovieName" HeaderText="Movie Title" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Top" />
                                    <asp:BoundField DataField="revenue_date" HeaderText="Date" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Top" DataFormatString="{0:dd-MMM-yyyy}" />
                                    <asp:BoundField DataField="problem" HeaderText="Proplem" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Top" />
                                    <asp:BoundField DataField="user_name" HeaderText="Issue By" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-VerticalAlign="Top" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("DataKey") %>'
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
                    </div>
                    <br />
                    <div style="text-align: center;">
                        <asp:Label ID="lblNotFound" runat="server" CssClass="importantText" Text="Not found any data !"
                            Visible="False"></asp:Label>
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
