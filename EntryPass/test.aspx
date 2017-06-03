<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" EnableEventValidation="true" Inherits="EntryPass.test" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .asd {
         font-family:IDAutomationHC39M;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" src="captures/15-11-16 04-13-58.png"/>
        <div id="barcode1">
            <div id="barcode_text" runat ="server"></div>
            
            
        </div>
        <asp:TextBox ID="txt" runat="server" Font-Names="Segoe UI"></asp:TextBox>
        <asp:Label ID="Label1" CssClass="asd" runat="server" type="barcode"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/>
    </div>

          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"> 
                      <Columns>
        
        <asp:BoundField DataField="passno" HeaderText="Name" />
        
        <asp:CommandField ShowEditButton="true" />
                      </Columns>
                  </asp:GridView>

        <div style="float: left; padding-left: 35px;" id="profile_pic_wrapper">

      <asp:Image ID="img" Width="120" Height="120" runat="server" Style="float: left;" />

      <asp:LinkButton ID="Linkbutton1" runat="server" OnClick="Linkbutton1_Click">Change  Photo</asp:LinkButton>

        </div>

    </form>
</body>
</html>
