<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotLogin.aspx.cs" Inherits="AirportAuthoritiesUI.Login.ForgotLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">

        function ValidateLogin() {


            if (document.getElementById('<%=txtemail.ClientID %>').value == "") {
                alert('Please Enter Email ID');
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
      };

</script>
    <title>Forgot Login Password</title>
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
    
    <div>
     <div class="wrapper">
	<div class="container">
		<h1>Forgot Login Password</h1>
		
	<form id="form1" runat="server">
         
             <asp:TextBox ID="txtemail" runat="server" placeholder="EMAIL ID"></asp:TextBox>
            
		
         <asp:Button ID="btnlogin" runat="server" Text="Submit" OnClick="btnforgot_Click" OnClientClick="javascript:return ValidateLogin();"/>
			<%--<button type="submit" id="login-button">Login</button>--%>
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
   
</body>
</html>
