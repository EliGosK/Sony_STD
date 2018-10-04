<%@ Control Language="c#" AutoEventWireup="false" CodeBehind="MovieFinder.ascx.vb"
    Inherits="SDT.UserControls.MovieFinder" %>
<asp:TextBox ID="txtCode" runat="server" Width="25px" Font-Size="7pt"></asp:TextBox>
<img id="btnFind<%=ClientID%>" src="../images/search1.png"
    width="10px" style="cursor: hand; vertical-align: middle" onclick="btnFind<%=ClientID%>Click()" /><asp:TextBox
        ID="txtName" runat="server" ReadOnly="True" Width="70px" BackColor="LightGray"
        ForeColor="#666666" Font-Size="7pt"></asp:TextBox><%--display:none;--%>
<asp:Label ID="lblDataNotFound" runat="server" Text="<br />ไม่พบข้อมูล" ForeColor="Red"
    Style="font-size: 8pt"></asp:Label>
<div id="div<%=ClientID%>" style="display: none; width: 210px; position: absolute;
    border: solid 1px black; background-color: white; filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=4, OffY=4, Color='gray', Positive='true');">
    <div style="background-color: royalblue; text-align: center;">
        <table width="100%">
            <tr>
                <td align="center" style="color: White; font-family: Arial; font-size: 8pt;">
                    เลือกภาพยนตร์
                </td>
                <td align="right" width="15" onclick="Hide<%=ClientID%>();">
                    <span style="color: red; cursor: hand; font-weight: bold; font-family: Arial; font-size: 10px;
                        filter: progid:DXImageTransform.Microsoft.dropshadow(OffX=1, OffY=1, Color='black', Positive='true');">
                        &nbsp;X&nbsp;</span>
                </td>
            </tr>
        </table>
    </div>
    <div style="background-color: azure;">
        <table width="210">
            <tr>
                <td align="center">
                    <font face="Tahoma" color="rosybrown" size="1">
                        <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CellPadding="4" DataKeyNames="movie_id" Font-Names="Tahoma" Font-Size="7pt" ForeColor="#333333"
                            GridLines="None" Width="210" AllowPaging="True">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="False" ForeColor="White" Font-Names="Tahoma"
                                Font-Size="7pt" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemStyle ForeColor="Blue" HorizontalAlign="Center" Font-Size="7pt" Width="10px" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select"
                                            Text="เลือก" CommandArgument='<%# Bind("movie_id") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Movie_Id" HeaderText="รหัส" ItemStyle-Width="15px" SortExpression="Movie_Id"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="15px"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="MovieName" HeaderText="เรื่อง" SortExpression="MovieName"
                                    ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Size="11"
                                Font-Bold="true" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <EditRowStyle BackColor="#999999" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </font>
                </td>
            </tr>
        </table>
        <asp:Button runat="server" ID="btnOnBlurCode" Style="display: none"></asp:Button>
    </div>
</div>
<asp:TextBox ID="txtDisplay" runat="server" Style="display: none" Text=""></asp:TextBox>
<asp:TextBox ID="txtEnabled" runat="server" Style="display: none"></asp:TextBox>

<script language="javascript" type="text/javascript">
function btnFind<%=ClientID%>Click() {
    if( document.getElementById("<%=ClientID%>_txtEnabled").value != "False" )
    {
        var btnOffset = new ElementOffset(document.all["btnFind<%=ClientID%>"])
        div<%=ClientID%>.style.left = btnOffset.left;
        div<%=ClientID%>.style.top = btnOffset.bottom+5;
        div<%=ClientID%>.style.display = "";
        
        var divOffset = new ElementOffset(div<%=ClientID%>)
        
        div<%=ClientID%>.style.left = btnOffset.left - (divOffset.left - btnOffset.left);
        div<%=ClientID%>.style.top = (btnOffset.bottom+5) - (divOffset.top - btnOffset.bottom);
        
        divOffset = new ElementOffset(div<%=ClientID%>)
        
        //div_offset.HideIntersecTag("SELECT","<%=ClientID%>");
    
        document.getElementById("<%=ClientID%>_txtDisplay").value = "display";
    }
}
function Hide<%=ClientID%>() {
    div<%=ClientID%>.style.display = "none";
    var divOffset = new ElementOffset(div<%=ClientID%>)
    //divOffset.ShowIntersecTag("<%=ClientID%>");
    document.getElementById("<%=ClientID%>_txtDisplay").value = "";
}
function <%=ClientID%>CodeChange() {
    var txt = document.getElementById("<%=ClientID%>_txtCode");
    <%=ClientID%>Callback( txt.value, null);
}
function <%=ClientID%>ChangeResponse(args,context) {
    var txt = document.getElementById("<%=ClientID%>_txtName");
    txt.value = args
    if( args == "" )
    {
        document.getElementById("<%=ClientID%>_txtCode").value = "";
    }
}
function <%=ClientID%>Restore() {
    if( document.getElementById("<%=ClientID%>_txtDisplay").value != "" ) 
    {
        if( document.readyState == "complete" )
           btnFind<%=ClientID%>Click();
        else
            setTimeout("<%=ClientID%>Restore();",1);
    }
}

<%=ClientID%>Restore();



function ElementOffset( srcObj ) {
    IsPointInBox = function ( cx, cy ) {
        return( cx >= left && cx <= right &&  cy >= top && cy <= bottom )
    }
    
    IsIntersec = function ( obj ) {
        if( IsPointInBox(obj.left,obj.top) ) return true
        if( IsPointInBox(obj.left,obj.bottom) ) return true
        if( IsPointInBox(obj.right,obj.top) ) return true
        if( IsPointInBox(obj.right,obj.bottom) ) return true
        
        if( obj.IsPointInBox(left,top) ) return true
        if( obj.IsPointInBox(left,bottom) ) return true
        if( obj.IsPointInBox(right,top) ) return true
        if( obj.IsPointInBox(right,bottom) ) return true
        
        return false
    }
    
    HideIntersecTag = function ( tag, SignalCode ) {
		for( var i = 0; i < document.all.length ; i++ ) {
		    var refObj = document.all(i)
		    if( refObj.tagName == tag ) {
		        var refOffset = new ElementOffset( refObj )
//		        alert( refObj.id + "--" + refOffset.ToString() + "==" + ToString() )
		        if( IsIntersec(refOffset) ) {
		            refObj.style.display = "none"
		            refObj.ElementOffsetSignalCode = SignalCode;
		        }
		    }
		}
    }

    ShowIntersecTag = function ( SignalCode ) {
	    for( var i = 0; i < document.all.length ; i++ ) {
             var refObj = document.all(i)
	        if(  refObj.ElementOffsetSignalCode == SignalCode  ) {
	            refObj.style.display = ""
	            refObj.ElementOffsetSignalCode = null;
	        }
	    }
    }
    
    ToString = function(){
        return "(" + left + "," + top + "," + right + "," + bottom + ")";
    }

	x = 0
	y = 0
	var refObj = srcObj
	width = refObj.offsetWidth
	height = refObj.offsetHeight
	while( refObj ) {
        x += refObj.offsetLeft
        y += refObj.offsetTop
        refObj = refObj.offsetParent
	}
	
	left = 10//x
	right = 10 + width
	top = y
	bottom = y + height
	
}
</script>

