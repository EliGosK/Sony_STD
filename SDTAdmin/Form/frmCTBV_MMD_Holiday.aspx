<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCTBV_MMD_Holiday.aspx.vb" Inherits=".frmCTBV_MMD_Holiday" %>

<%@ Register Src="~/Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="ucctbvCtlTop" %>
<%@ Register Src="~/Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="ucCopyRights" %>
<%@ Register Src="~/Controls/DatePicker.ascx" TagName="DatePicker" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SDT Management Information System - Holiday Master</title>
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
                &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt; <a href="frmCTBV_Menu_MMD.aspx">
                    &nbsp;Manage Master Data</a> &gt; </b><strong>MMD : Holiday</strong>
            </td>
        </tr>
    </table>
    <div class="mainDiv">
        <table class="mainTable" height="29" bordercolor="#e6b04d" border="1" align="center"
            cellpadding="3" cellspacing="3">
            <tr>
                <td>
                    <div align="center" class="titleDiv">
                        <span class="titleText">Holiday</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" width="600px">
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblMonth" runat="server" Text="Month: "></asp:Label>
                            </td>
                            <td width="60px" align="left">
                                <asp:DropDownList ID="ddlMonth" runat="server" Width="60px">
                                    <asp:ListItem Value="" Selected="True"> </asp:ListItem>
                                    <asp:ListItem Value="01">01</asp:ListItem>
                                    <asp:ListItem Value="02">02</asp:ListItem>
                                    <asp:ListItem Value="03">03</asp:ListItem>
                                    <asp:ListItem Value="04">04</asp:ListItem>
                                    <asp:ListItem Value="05">05</asp:ListItem>
                                    <asp:ListItem Value="06">06</asp:ListItem>
                                    <asp:ListItem Value="07">07</asp:ListItem>
                                    <asp:ListItem Value="08">08</asp:ListItem>
                                    <asp:ListItem Value="09">09</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="11">11</asp:ListItem>
                                    <asp:ListItem Value="12">12</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="40px" align="right">
                                <asp:Label ID="lblYear" runat="server" Text="Year: "></asp:Label>
                            </td>
                            <td width="60px" align="left">
                                <asp:TextBox ID="txtYear" runat="server" MaxLength="4" Width="60px"></asp:TextBox>
                            </td>
                             <td width="60px" align="right">
                                <asp:Button ID="btnSearch" runat="server" Text="Search" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table align="center" width="600px" bgcolor="#CCCCCC" style="font-family: Tahoma; font-size: small;">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblAction" runat="server" Font-Bold="True" ForeColor="Red" Text="Add Data"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="120px">
                                <asp:Label ID="lblHolidayDate" runat="server" Font-Bold="True" Text="Holiday Date : "></asp:Label>
                            </td>
                            <td align="left">
                                <uc1:DatePicker ID="dtpHolidayDate" runat="server" TxtDateReadOnly="True" TxtDateShowPopup="True">
                                </uc1:DatePicker> <span style="color: #FF0000">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblHolidayName" runat="server" Font-Bold="True" Text="Holiday Name : "></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtHolidayName" runat="server" Width="400px" MaxLength="500"></asp:TextBox><span style="color: #FF0000">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="8pt" ForeColor="Red"
                                    Visible="False">Please check require flield (*)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:ImageButton ID="btnInsertUpdate" runat="server" ImageUrl="~/images/ADDCCC.png"
                                    AlternateText="Add" />
                                <asp:ImageButton ID="btnCancel" runat="server" ImageUrl="~/images/CancelCCC.png"
                                    AlternateText="Cancel" />
                                <asp:HiddenField ID="hdfHolidayId" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table align="center" width="600px">
                        <tr>
                            <td>
                                <asp:GridView ID="grdHoliday" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="False"
                                    CellPadding="4" DataKeyNames="holiday_id" Font-Names="Tahoma" Font-Size="Small" ForeColor="#333333" GridLines="None"
                                    Width="600px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Holiday Id" SortExpression="holiday_id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHolidayId" runat="server" Text='<%# Eval("holiday_id") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="0px" HorizontalAlign="Left" />
                                            <ItemStyle Width="0px" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Holiday Date" SortExpression="holiday_date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHolidayDate" runat="server" Text='<%# Eval("holiday_date", "{0:dd-MMM-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="120px" HorizontalAlign="Left" />
                                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Holiday Name" SortExpression="holiday_name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHolidayName" runat="server" Text='<%# Eval("holiday_name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle Width="380px" HorizontalAlign="Left" />
                                            <ItemStyle Width="380px" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("holiday_id") %>'>Edit</asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" HorizontalAlign="Left" />
                                            <ItemStyle Width="50px" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("holiday_id") %>' OnClientClick="return confirm('Are you sure you want to delete?');">Delete</asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="50px" HorizontalAlign="Left" />
                                            <ItemStyle Width="50px" HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <ucCopyRights:Copyrights ID="copyRights" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
