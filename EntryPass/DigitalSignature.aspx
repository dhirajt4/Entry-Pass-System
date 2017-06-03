<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DigitalSignature.aspx.cs" Inherits="AirportAuthoritiesUI.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

         function Validate() {

             if (document.getElementById('<%=fuDigitalSign.ClientID %>').value == "") {
                 alert("Please Select Your Digital Sign");
                 document.getElementById('<%=fuDigitalSign.ClientID %>').style.borderColor = '#b94a48';
              document.getElementById('<%=fuDigitalSign.ClientID %>').focus();
                  return false;

              }
             if (document.getElementById('<%=txtPassword.ClientID %>').value == "") {
                 alert("Please Enter Your Transaction Password");
                document.getElementById('<%=txtPassword.ClientID %>').style.borderColor = '#b94a48';
                document.getElementById('<%=txtPassword.ClientID %>').focus();
                return false;

            }
          
         
      };

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlInsertSign" Visible="false"  runat="server">
        <a style="color:black; ">
            <h1 style="margin-left:35%;">
            Add Your Digital Sign
           </h1>
                    </a>
        <div style="height:30px;"></div>
        <table style="width:100%; margin-left:auto; margin-right:auto;">
            <tr style="">
                <td style="float: right; width: 50%;">
                    <a style="float: right; font-size:15px; color:black; ">Upload Digital Sign :</a>
                    </td>
                <td style="width: 50%;">
                    <asp:FileUpload ID="fuDigitalSign" runat="server" />
                     <div style="height:10px;"></div>
                    </td>
                
                 </tr>
            <tr style="margin-top:15px; ">
              <td>
                <a style="float: right; font-size:15px; color:black; ">   Create Transaction Password :</a>
              </td>
                  <td>
                      <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <div style="height:10px;"></div>
                  </td>
              
            </tr>
            <tr style="margin-top:15px;">
                <td></td>
                 <td>
                      <asp:Button ID="btnDigitalSign" runat="server" class="btn btn-primary btn-block btn-flat" Width="150px" Text="Upload Sign"  OnClientClick="javascript:return Validate();" OnClick="btnDigitalSign_Click" />
                 </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlSignDetail" Visible="false" runat="server">
             <a style="color:black; ">
            <h1 style="margin-left:35%;">
            
           </h1>
                    </a>
        <div style="height:30px;"></div>
        <table style="width:100%; margin-left:auto; margin-right:auto;">
          
            <tr>
                <td>
                     <a style="float: right; font-size:23px; color:black; "> Your Digital Sign :</a>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server"  Width="400px" Height="100px"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
