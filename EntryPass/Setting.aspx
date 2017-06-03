<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Setting.aspx.cs" EnableEventValidation="false" Inherits="EntryPass.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6" style=" border-radius: 15px; border: 1px solid #e5e5e5; padding: 10px;">
            <table class="table">  
                <thead>
         <tr>
      <th ><h3 align="center">Setting</h3></th>
        <th>YES</th>
        <th>NO</th>
        </tr>
             </thead>    
  <tbody>
    <tr>
      <th scope="row">Digital Signature on Pass :</th>
      <td><asp:RadioButton ID="rbsigntrue" runat="server" GroupName="a" AutoPostBack="true" ToolTip="Enable Digital Sign in EntryPass" OnCheckedChanged="rbsigntrue_CheckedChanged"/></td>
      <td><asp:RadioButton ID="rbsignfalse" runat="server" GroupName="a" AutoPostBack="true" ToolTip="Disable Digital Sign in EntryPass" OnCheckedChanged="rbsignfalse_CheckedChanged"/></td>
    </tr>
      </tbody>

            </table>
            </div>
        </div>
    </div>
</asp:Content>
