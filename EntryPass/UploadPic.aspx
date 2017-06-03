<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UploadPic.aspx.cs" Inherits="AirportAuthoritiesUI.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validation() {

            if (document.getElementById('<%=fuProfilePic.ClientID %>').value == "") {
                alert("Please Upload Profile Image Only .jpg File");
                document.getElementById('<%=fuProfilePic.ClientID %>').style.borderColor = '#b94a48';
                document.getElementById('<%=fuProfilePic.ClientID %>').focus();
                return false;
            }
        };
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:50px;"></div>
     <table style="width:30%; margin-left:auto; margin-right:auto;">
            <tr>
                <td>
                    <a style="color:black;">
                        <h1>
                            Upload Profile Pic
                        </h1>
                    </a>
                </td>
            </tr>
        </table>
    <table style="width: 50%; margin-left:auto; margin-right:auto;">
        <%--<tr>
            <td><br />
               <a style="color: black; font-size: 15px;  margin-top: 5px;">Upload Image View :</a>
            </td>
            <td><br />
                <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" />
            </td>
        </tr>--%>
        <tr>
            <td><br />
                 <a style="color: black; font-size: 15px;  margin-top: 5px;">Select Profile Image :</a>
            </td>
            <td><br />
                <asp:FileUpload ID="fuProfilePic" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                            
            </td>
            <td><br />
                 <asp:Button ID="btnUploadProfilePic" class="btn btn-primary btn-block btn-flat" runat="server" Text="Upload Image" style="float:left" Width="150px" OnClick="btnUploadProfilePic_Click"  OnClientClick="javascript:return validation();"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
