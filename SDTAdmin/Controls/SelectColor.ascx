<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SelectColor.ascx.vb" Inherits=".SelectColor" %>

    <SCRIPT LANGUAGE="JavaScript">
        var cp = new ColorPicker('window'); // Popup window
        var <%=Me.ClientID%>cp2 = new ColorPicker(); // DIV style
    </SCRIPT>

<TABLE >
<TR>
	<TD>
        <%--<INPUT TYPE="text" runat="server" id="color2" name="<%=Me.ClientID%>color2"  SIZE="20" VALUE="" />
       --%>
        <asp:TextBox ID="color2" onfocus="SelectColor1pick2.focus();" 
            style="cursor:default" name="color2" runat="server" ForeColor="#666666" 
            BackColor="LightGray" BorderStyle="Solid" ></asp:TextBox>
        
        </TD>
	<TD>
	   <A style="border:0px" HREF="#" onClick="<%=Me.ClientID%>cp2.select(document.getElementById('<%=Me.ClientID%>_color2'),'<%=Me.ClientID%>pick2');return false;" NAME="<%=Me.ClientID%>pick2" ID="<%=Me.ClientID%>pick2"><img id="selectc" style="vertical-align:middle" src="../images/select_color.gif" /></A>
	</TD>
</TR>
</TABLE>

<SCRIPT LANGUAGE="JavaScript">cp.writeDiv()</SCRIPT>

<script>
//alert(document.getElementById('<%=Me.ClientID%>_color2').name)
//document.getElementById('<%=Me.ClientID%>_color2').onfocus="<%=Me.ClientID%>pick2.focus();";
</script>



