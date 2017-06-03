<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetLoginPassword.aspx.cs" Inherits="AirportAuthoritiesUI.Login.ResetLoginPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <link href="~/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="~/dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript">
     function passwordvalidation() {


         if (document.getElementById('<%=txtnewpassword.ClientID %>').value == "") {

             document.getElementById('<%=txtnewpassword.ClientID %>').style.borderColor = '#b94a48';
             document.getElementById('<%=txtnewpassword.ClientID %>').focus();
             return false;
         }
         if (document.getElementById('<%=txtrepassword.ClientID %>').value == "") {

             document.getElementById('<%=txtrepassword.ClientID %>').style.borderColor = '#b94a48';
                document.getElementById('<%=txtrepassword.ClientID %>').focus();
                return false;

            }

            if (document.getElementById('<%=txtnewpassword.ClientID %>').value != document.getElementById('<%=txtrepassword.ClientID %>').value) {
             alert('Both Password Can Not be Same');
             document.getElementById('<%=txtrepassword.ClientID %>').style.borderColor = '#b94a48';
             document.getElementById('<%=txtrepassword.ClientID %>').focus();
             return false;

         }

     };

        </script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="register-box">
      <div class="register-logo">
        <a ><b>Hi </b><asp:Label ID="lblusername" runat="server" ></asp:Label></a>
      </div>

      <div class="register-box-body">
        <p class="login-box-msg" style="font-size: 18px;">Enter New Password</p>
        <div  ><br />
          <div class="form-group has-feedback">
        <asp:TextBox ID="txtnewpassword" class="form-control"  placeholder="New Password" Style="height: 36px;" runat="server" TextMode="Password"></asp:TextBox>
          <%--  <input type="text" class="form-control" placeholder="Full name" />--%>
          <%--  <span class="glyphicon glyphicon-user form-control-feedback"></span>--%>
          </div><br />
          <div class="form-group has-feedback">
               <asp:TextBox ID="txtrepassword" class="form-control" placeholder="Re Enter Password" Style="height: 36px;" runat="server" TextMode="Password"></asp:TextBox>
        <%--    <input type="email" class="form-control" placeholder="Email" />--%>
            <%--<span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
          </div><br />
          <div class="row">
            <div class="col-xs-8">
              <div class="checkbox icheck">
                <label>
                  <%--<input type="checkbox"> I agree to the <a href="#">terms</a>--%>
                </label>
              </div>
            </div><!-- /.col -->
            <asp:Panel ID="pnlRegister" runat="server">
                <div class="col-xs-4">
            <asp:Button ID="btnSave" class="btn btn-primary btn-block btn-flat" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:return passwordvalidation();"/>
              <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>--%>
            </div>
            </asp:Panel>
                          <asp:Panel ID="pnlUpdate" runat="server" Visible="false">
                              <div class="col-xs-4">
            <asp:Button ID="btnUpdate" class="btn btn-primary btn-block btn-flat" runat="server" Text="Update"/>
              <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>--%>
            </div>
                          </asp:Panel>
            <!-- /.col -->
          </div>
        </div>

       <%-- <div class="social-auth-links text-center">
          <p>- OR -</p>
          <a href="#" class="btn btn-block btn-social btn-facebook btn-flat"><i class="fa fa-facebook"></i> Sign up using Facebook</a>
          <a href="#" class="btn btn-block btn-social btn-google-plus btn-flat"><i class="fa fa-google-plus"></i> Sign up using Google+</a>
        </div>

        <a href="login.html" class="text-center">I already have a membership</a>--%>
      </div><!-- /.form-box -->
    </div>
    </form>
</body>
</html>
