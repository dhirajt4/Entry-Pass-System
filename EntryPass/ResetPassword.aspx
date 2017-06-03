<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="AirportAuthoritiesUI.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function validation() {
                debugger
                if (document.getElementById('<%=ddlBillPeriod.ClientID %>').value == 0) {
                    alert("Select Your Password Type");
                    document.getElementById('<%=ddlBillPeriod.ClientID %>').style.borderColor = '#b94a48';
             document.getElementById('<%=ddlBillPeriod.ClientID %>').focus();
                      return false;
                  }
                if (document.getElementById('<%=ddlBillPeriod.ClientID %>').value == 1) {
                    if (document.getElementById('<%=txtCurrendPassword.ClientID %>').value == "") {
                        alert("Current Password Not Black");
                        document.getElementById('<%=txtCurrendPassword.ClientID %>').style.borderColor = '#b94a48';
            document.getElementById('<%=txtCurrendPassword.ClientID %>').focus();
                         return false;
                     }
                     if (document.getElementById('<%=txtNewPassword.ClientID %>').value == "") {
                        alert("New Password Not Black");
                        document.getElementById('<%=txtNewPassword.ClientID %>').style.borderColor = '#b94a48';
                        document.getElementById('<%=txtNewPassword.ClientID %>').focus();
                    return false;
                }

                if (document.getElementById('<%=txtConfirmPassword.ClientID %>').value == "") {
                        alert("Confirm Password Not Black");
                        document.getElementById('<%=txtConfirmPassword.ClientID %>').style.borderColor = '#b94a48';
                document.getElementById('<%=txtConfirmPassword.ClientID %>').focus();
                return false;
            }
            if (document.getElementById('<%=txtNewPassword.ClientID %>').value != document.getElementById('<%=txtConfirmPassword.ClientID %>').value) {
                        alert("New & Confirm Password Do not Match");
                        document.getElementById('<%=txtNewPassword.ClientID %>').style.borderColor = '#b94a48';
                    document.getElementById('<%=txtNewPassword.ClientID %>').focus();
                    return false;
                }
                }
                if (document.getElementById('<%=ddlBillPeriod.ClientID %>').value == 2) {
                    if (document.getElementById('<%=txtNewPassword.ClientID %>').value == "") {
                        alert("New Password Not Black");
                        document.getElementById('<%=txtNewPassword.ClientID %>').style.borderColor = '#b94a48';
                        document.getElementById('<%=txtNewPassword.ClientID %>').focus();
                        return false;
                    }

                    if (document.getElementById('<%=txtConfirmPassword.ClientID %>').value == "") {
                        alert("Confirm Password Not Black");
                        document.getElementById('<%=txtConfirmPassword.ClientID %>').style.borderColor = '#b94a48';
                        document.getElementById('<%=txtConfirmPassword.ClientID %>').focus();
                        return false;
                    }
                    if (document.getElementById('<%=txtNewPassword.ClientID %>').value != document.getElementById('<%=txtConfirmPassword.ClientID %>').value) {
                        alert("New & Confirm Password Do not Match");
                        document.getElementById('<%=txtNewPassword.ClientID %>').style.borderColor = '#b94a48';
                        document.getElementById('<%=txtNewPassword.ClientID %>').focus();
                        return false;
                    }

                }
         };                

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:60px;"></div>
        <table style="width:30%; margin-left:auto; margin-right:auto;">
            <tr>
                <td>
                    <a style="color:black;">
                        <h1>
                            Change Password
                        </h1>
                    </a>
                </td>
            </tr>
        </table>
    
    <table style="width:50%; margin-left:auto; margin-right:auto;"><br />
        <tr>
            <td class="text-right"><br />
              <a style="color: black; font-size: 15px;  margin-top: 5px;">Password Type :</a>
            </td>
            <td><br />
                  <asp:DropDownList ID="ddlBillPeriod" class="form-control" runat="server"  Width="70%" AutoPostBack="true" OnTextChanged="ddlBillPeriod_TextChanged">
                      <asp:ListItem Value="0">Please Select </asp:ListItem>
                       <asp:ListItem Value="1">Login Password</asp:ListItem>
                       <asp:ListItem Value="2">Transaction Password</asp:ListItem>
                  </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="text-right"><br />
              <a style="color: black; font-size: 15px; margin-top: 5px;">
                  <asp:Label ID="lblcurrentpassword" runat="server" Text="Current Password :"></asp:Label>
              </a>
            </td>
         <td><br />
              <asp:TextBox ID="txtCurrendPassword" class="form-control" placeholder=" Current Password" Width="70%"  runat="server" TextMode="Password"></asp:TextBox>
         </td>
        </tr>
         <tr>
            <td class="text-right"><br />
              <a style="color: black; font-size: 15px;  margin-top: 5px;">New Password :</a>
            </td>
         <td><br />
                           <asp:TextBox ID="txtNewPassword" class="form-control" placeholder=" New Password"  Width="70%" TextMode="Password" runat="server"></asp:TextBox>
         </td>
        </tr>
        <tr>
            <td class="text-right"><br />
              <a style="color: black; font-size: 15px;  margin-top: 5px;">Confirm Password :</a>
            </td>
         <td><br />
               <asp:TextBox ID="txtConfirmPassword" class="form-control" placeholder=" Confirm Password"  Width="70%" TextMode="Password"  runat="server"></asp:TextBox>
         </td>
        </tr>
        <tr>
            <td>

            </td>
            <td><br />
                 <asp:Button ID="btnChangePassword" class="btn btn-primary btn-block btn-flat" runat="server" Text="Change Password" style="float:left" Width="150px" OnClick="btnChangePassword_Click"  OnClientClick="javascript:return validation();"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
