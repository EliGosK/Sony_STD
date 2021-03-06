<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmRevDetail.aspx.vb"
    Inherits=".frmRevDetail" %>

<%@ Register Src="../Controls/ctbvCtlTop.ascx" TagName="ctbvCtlTop" TagPrefix="uc1" %>
<%@ Register Src="../Controls/Copyrights.ascx" TagName="Copyrights" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SDT Management Informaion System</title>

    <script language="javascript" type="text/javascript" src="../js/Common.js"></script>

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
        .style21
        {
            width: 122px;
            font-size: small;
        }
        .style8
        {
            width: 33px;
        }
        .style9
        {
            width: 156px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0" bottommargin="0">
    <form id="form1" runat="server">
    <div>
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
                <td height="29" colspan="2" bordercolor="honeydew" background="" class="style16">
                    &nbsp;<b><a href="frmCTBV_Menu.aspx">Main Menu </a>&gt;<a href="frmRevenueMonitor.aspx">
                        Box Office </a>&gt;<asp:HyperLink ID="lblMovieId" runat="server">HyperLink</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:HyperLink ID="lblDate" runat="server">HyperLink</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:HyperLink ID="TheaterName" runat="server">TheaterName</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:HyperLink ID="lblScreen" runat="server">TheaterName</asp:HyperLink>
                        &nbsp;&gt;
                        <asp:Label ID="lblSession" runat="server" Text="lblSession"></asp:Label>
                    </b>
                </td>
            </tr>
            <tr>
                <td height="29" colspan="2" bordercolor="honeydew" bgcolor="#ffffff">
                    <table width="100%" height="116" border="1" align="center" cellpadding="3" cellspacing="3"
                        bgcolor="#f0cd8c">
                        <tr bordercolor="#e6b04d" bgcolor="#f0cd8c">
                            <td height="27" background="">
                                <div align="left" class="style1">
                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                        <tr>
                                            <td align="right" class="style21">
                                                Title :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Distributor :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDis" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Genre :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtGenre" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="style21">
                                                Release Date :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" Columns="50" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr bordercolor="#999999" bgcolor="#ffffff">
                            <td height="78" align="center" bgcolor="#E2E2E2">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <table width="100%">
                                                <tr width="100%">
                                                    <td width="100%">
                                                        <asp:Label ID="Label51" runat="server" Text="บัจจุบันยังไม่สามารถแก้ไขข้อมูลได้นะครับ อยู่ในขั้นตอนการปรับปรุงอยู่ <br /> (แต่สามารถ Log in เข้าไปแก้ได้ ที่ เวปของทาง Checker ครับ)<br /> - ขออภัยในความไม่สะดวก -"
                                                            ForeColor="Red"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <table border="0" bordercolor="#ffffff" style="width: 325px">
                                                            <tr>
                                                                <td align="center" bordercolor="#ffffff">
                                                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                                                        ForeColor="#FF9900" Style="color: #800000; font-size: medium" Text="บันทึกรายได้ภาพยนตร์"></asp:Label>
                                                                    <br />
                                                                    <span class="style10">---------------------------------------</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td bordercolor="#ffffff" class="style1">
                                                                    <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <span class="style8">
                                                                                    <label>
                                                                                        <asp:Label ID="Label37" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#003366"
                                                                                            Text="Status :"></asp:Label>
                                                                                    </label>
                                                                                </span>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" Font-Bold="True"
                                                                                    Font-Names="Tahoma" Font-Size="Small">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <label>
                                                                                    <span class="style8">
                                                                                        <asp:Label ID="Label7" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                            Text="Screen :"></asp:Label>
                                                                                    </span>
                                                                                </label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlScreen" runat="server" DataSourceID="sqlScreen" DataTextField="TheaterSub_name"
                                                                                    DataValueField="TheaterSub_name" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label9" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="Session :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlHours" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small">
                                                                                    <asp:ListItem Selected="True" Value="1">10</asp:ListItem>
                                                                                    <asp:ListItem Value="2">11</asp:ListItem>
                                                                                    <asp:ListItem Value="3">12</asp:ListItem>
                                                                                    <asp:ListItem Value="4">13</asp:ListItem>
                                                                                    <asp:ListItem Value="5">14</asp:ListItem>
                                                                                    <asp:ListItem Value="6">15</asp:ListItem>
                                                                                    <asp:ListItem Value="7">16</asp:ListItem>
                                                                                    <asp:ListItem Value="8">17</asp:ListItem>
                                                                                    <asp:ListItem Value="9">18</asp:ListItem>
                                                                                    <asp:ListItem Value="10">19</asp:ListItem>
                                                                                    <asp:ListItem Value="11">20</asp:ListItem>
                                                                                    <asp:ListItem Value="12">21</asp:ListItem>
                                                                                    <asp:ListItem Value="13">22</asp:ListItem>
                                                                                    <asp:ListItem Value="14">23</asp:ListItem>
                                                                                    <asp:ListItem Value="15">00</asp:ListItem>
                                                                                    <asp:ListItem Value="16">01</asp:ListItem>
                                                                                    <asp:ListItem Value="17">02</asp:ListItem>
                                                                                    <asp:ListItem Value="18">03</asp:ListItem>
                                                                                    <asp:ListItem Value="19">04</asp:ListItem>
                                                                                    <asp:ListItem Value="120">05</asp:ListItem>
                                                                                    <asp:ListItem Value="21">06</asp:ListItem>
                                                                                    <asp:ListItem Value="22">07</asp:ListItem>
                                                                                    <asp:ListItem Value="23">08</asp:ListItem>
                                                                                    <asp:ListItem Value="24">09</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                &nbsp;:
                                                                                <asp:DropDownList ID="ddlMin" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small">
                                                                                    <asp:ListItem Value="1">00</asp:ListItem>
                                                                                    <asp:ListItem Value="2">05</asp:ListItem>
                                                                                    <asp:ListItem Value="3">10</asp:ListItem>
                                                                                    <asp:ListItem Value="4">15</asp:ListItem>
                                                                                    <asp:ListItem Value="5">20</asp:ListItem>
                                                                                    <asp:ListItem Value="6">25</asp:ListItem>
                                                                                    <asp:ListItem Value="7">30</asp:ListItem>
                                                                                    <asp:ListItem Value="8">35</asp:ListItem>
                                                                                    <asp:ListItem Value="9">40</asp:ListItem>
                                                                                    <asp:ListItem Value="10">45</asp:ListItem>
                                                                                    <asp:ListItem Value="11">50</asp:ListItem>
                                                                                    <asp:ListItem Value="12">55</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label36" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="Session Type :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlType" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small">
                                                                                    <asp:ListItem Value="ปกติ">ปกติ</asp:ListItem>
                                                                                    <asp:ListItem Value="รอบพิเศษ">รอบพิเศษ</asp:ListItem>
                                                                                    <asp:ListItem Value="รอบเหมา">รอบเหมา</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label16" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="Film System :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlSystem" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small">
                                                                                    <asp:ListItem Value="35 มม.">35 มม.</asp:ListItem>
                                                                                    <asp:ListItem Value="ดิจิตอล">ดิจิตอล</asp:ListItem>
                                                                                    <asp:ListItem Value="3 มิติ">3 มิติ</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="Sound :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:DropDownList ID="ddlSound" runat="server" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small">
                                                                                    <asp:ListItem Value="ต้นฉบับ">ต้นฉบับ</asp:ListItem>
                                                                                    <asp:ListItem Value="พากย์ไทย">พากย์ไทย</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label50" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="GBO :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtAmount" runat="server" Columns="6" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small" MaxLength="10"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right" class="style9">
                                                                                <asp:Label ID="Label12" runat="server" Font-Names="Tahoma" Font-Size="Small" ForeColor="#0000CC"
                                                                                    Text="Adms :"></asp:Label>
                                                                            </td>
                                                                            <td align="left">
                                                                                <asp:TextBox ID="txtAdms" runat="server" Columns="6" Font-Bold="True" Font-Names="Tahoma"
                                                                                    Font-Size="Small" MaxLength="10"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" bordercolor="#ffffff" class="style1">
                                                                    <asp:Label ID="lblError" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="true"
                                                                        ForeColor="#CC3300" Text="ยอดไม่ถูกต้องกรุณาตรวจสอบ !!" Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblErrorExist" runat="server" Font-Names="Tahoma" Font-Size="8pt"
                                                                        Font-Bold="true" ForeColor="#CC3300" Text="ไม่สามารถบันทึกรายการนี้ได้เนื่องจากมีการแจ้งยอดจริงแล้ว!!"
                                                                        Visible="False"></asp:Label>
                                                                    <asp:Label ID="lblErrorTime" runat="server" Font-Names="Tahoma" Font-Size="8pt" Font-Bold="true"
                                                                        ForeColor="#CC3300" Text="&quot;จอ&quot; และ &quot;รอบ/เวลา&quot; ดังกล่าวได้มีการแจ้งรายได้ ภาพยนตร์เรื่องอื่นแล้ว !!"
                                                                        Visible="False"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div align="center">
                                                                        <span class="style4"></span>&nbsp;
                                                                        <asp:Button ID="btnSave" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                                                            Text="Save" Width="25%" Enabled="False" />
                                                                        &nbsp;
                                                                        <asp:Button ID="btnCancel" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"
                                                                            Text="Cancel" Width="25%" />
                                                                        &nbsp;
                                                                        <asp:Button ID="btndelete" runat="server" Font-Bold="True" Font-Size="Small" Text="Delete"
                                                                            Width="25%" Enabled="False" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br>
                                <uc1:Copyrights ID="Copyrights1" runat="server"></uc1:Copyrights>
                                <%--<font face="Tahoma" color="rosybrown" size="1">Copyrights by&nbsp;SONY&nbsp;PICTURES&nbsp;RELEASING&nbsp;WALT&nbsp;DISNEY&nbsp;STUDIOS(THAILAND)&nbsp;LTD.</font>&nbsp;--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <label>
        <asp:SqlDataSource ID="sqlScreen" runat="server" ConnectionString="<%$ ConnectionStrings:SDTConnectionString %>"
            SelectCommand="SELECT TheaterSub_id, TheaterSub_name FROM tblTheaterSub WHERE (theater_id = @theater_id)">
            <SelectParameters>
                <asp:SessionParameter Name="theater_id" SessionField="TheaterId" />
            </SelectParameters>
        </asp:SqlDataSource>
    </label>
    <asp:SqlDataSource ID="sqlMoviesSystem" runat="server"></asp:SqlDataSource>
    </form>
</body>
</html>

<script language="javascript" type="text/javascript">
    SetOnKeyDownEnter(window.document)
</script>

