<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AirportAuthoritiesUI.Login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | Panel</title>
    <script type="text/javascript">

        function ValidateLogin() {


            if (document.getElementById('<%=txtemail.ClientID %>').value == "") {

              document.getElementById('<%=txtemail.ClientID %>').style.borderColor = '#b94a48';
              document.getElementById('<%=txtemail.ClientID %>').focus();
              return false;

          }
          var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

          if (!filter.test(document.getElementById('<%=txtemail.ClientID %>').value)) {
              alert('Please provide a valid email address');
              document.getElementById('<%=txtemail.ClientID %>').focus();
              return false;
          }
          if (document.getElementById('<%=txtpassword.ClientID %>').value == "") {
             
              document.getElementById('<%=txtpassword.ClientID %>').style.borderColor = '#b94a48';
              document.getElementById('<%=txtpassword.ClientID %>').focus();
              return false;

          }
      };

</script>
      <link rel="stylesheet" href="css/style.css"/>
    <style type="text/css">
        #btnlogin {
  -webkit-appearance: none;
     -moz-appearance: none;
          appearance: none;
  outline: 0;
  background-color: white;
  border: 0;
  padding: 10px 15px;
  color: #53e3a6;
  border-radius: 3px;
  width: 250px;
  cursor: pointer;
  font-size: 18px;
  -webkit-transition-duration: 0.25s;
          transition-duration: 0.25s;
}
            #btnlogin:hover {
                background-color: #f5f7f9;
            }
    </style>
</head>
<body>
  <%--  <form id="form1" runat="server">--%>
    <div>
     <div class="wrapper">
	<div class="container">
		<h1>Welcome</h1>
		
		<form class="form" id="form1" runat="server">
         <asp:Panel ID="pnllogin" runat="server">
             <asp:TextBox ID="txtemail" runat="server" placeholder="EMAIL ID"></asp:TextBox>
            <asp:TextBox ID="txtpassword" runat="server" placeholder="PASSWORD" TextMode="Password"></asp:TextBox>
		<%--	<input type="text" placeholder="Username">
			<input type="password" placeholder="Password">--%>
         <asp:Button ID="btnlogin" runat="server" Text="Login" OnClick="btnlogin_Click" OnClientClick="javascript:return ValidateLogin();"/>
             <br />
             <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login/ForgotLogin.aspx" Font-Underline="False">Forgot Password ?</asp:LinkButton>
			<%--<button type="submit" id="login-button">Login</button>--%>
		</asp:Panel>
            <%--<asp:Panel ID="pnlaltermessage" Visible="false" runat="server">
             <table style="margin-left:auto; margin-right:auto;">
                 <tr>
                     <td>
                         <a>
                             <h5>
                                 You were logged already. If you confirm this login, old session will be invalidated.</h5>
                         </a>
                     </td><td>
                          <a>
                             <h5>,
                             </h5>
                         </a>
                          </td>
                 </tr>
                 <tr>
                     <td ><br />
                         <asp:Button ID="btnyes" class="btn btn-primary btn-block btn-flat" runat="server" style="margin-left: 80px; border-radius: 6px; padding: 0px;" Width="100px" Height="40px" Text="Continue" OnClick="btnyes_Click"/>
                       </td><td><br /> 
                         <asp:Button ID="btnno" class="btn btn-primary btn-block btn-flat" runat="server" style="margin-right: 80px; border-radius: 6px; padding: 0px;" Width="100px" Height="40px" Text="Cancel" OnClick="btnno_Click"/>
                    </td>
                    
                 </tr>
             </table>

             </asp:Panel>--%>
            <asp:Panel ID="pnlaltermessage" Visible="false" runat="server">
             <table style="margin-left:auto; margin-right:auto;">
                 <tr>
                     <td>
                         
                             <h5 style="font-size: 20px;">
                                You were logged in already. If you confirm this login, old session will be invalidate.</h5>
                         
                     </td><td>
                       
                          </td>
                 </tr>
                 <tr>
                     <td ><br />
                         <table style="width: 70%;margin-left: auto;margin-right: auto;">
                             <tr>
                                 <td>
<asp:Button ID="btnyes" class="btn btn-primary btn-block btn-flat" runat="server" style="margin-left: 80px; border-radius: 6px; padding: 0px;" Width="100px" Height="40px" Text="Continue" OnClick="btnyes_Click"/>
                                 </td>
                                 <td>
<asp:Button ID="btnno" class="btn btn-primary btn-block btn-flat" runat="server" style="margin-right: 80px; border-radius: 6px; padding: 0px;" Width="100px" Height="40px" Text="Cancel" OnClick="btnno_Click"/>
                                 </td>
                             </tr>
                         </table>
                     
                         
                    </td>
                    
                 </tr>
             </table>

             </asp:Panel>
             </form>
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>
    
  <script src="js/js_library.js"></script>
        <script src="js/inde.js"></script>
    </div>
  <%--  </form>--%>
</body>
</html>
