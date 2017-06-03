﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateMenu.aspx.cs" Inherits="AirportAuthoritiesUI.CreateMenu"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


       <section class="content">
          <div class="row" >
            <div class="col-xs-12">
                <table style="width:100%;">
                    <tr>
                        <td>
                       
                    

           <div class="box box-primary">
      <div class="box-header with-border">
                  <h3 class="box-title">Insert Menu</h3>
                </div>

                  <div class="box-body" >
                    <div class="form-group">
                   <label for="exampleInputEmail1">Menu Name</label>
                    <asp:TextBox CssClass="form-control" ID="txtmenu"  runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ValidationGroup="mm" ID="RequiredFieldValidator1" ControlToValidate="txtmenu" runat="server" ErrorMessage="Enter Role Name !"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                       

                    </div>
                       <div class="box-footer">
                    <asp:Button ID="btn_submit" ValidationGroup="mm" runat="server" Text="Submit" 
                          CssClass="btn btn-primary btn-sm" 
                          onclick="btn_submit_Click"  />
                          &nbsp;&nbsp;
                          <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                          CssClass="btn btn-primary btn-sm" onclick="btnCancel_Click" 
                      />
                  </div>

      </div> </td>
                        <td>

                <div class="col-md-15" style="width:45%;margin-left:10%;overflow-y:scroll;height:200px;">
      <div class="box box-primary">
<div class="box-header with-border">
                  <h3 class="box-title">All Menu</h3>
                   <%--<a class="btn btn-success" href="role.aspx" style="float:right;"><i class="glyphicon glyphicon-shopping-cart"></i> Add Role</a>--%>
                </div>
                 <div class="box-body">
                 <div class="col-sm-12">
                     <table id="example1" class="table table-bordered table-striped dataTable" role="grid" aria-describedby="example1_info">
                    <thead>
                      <tr role="row"><th class="sorting_asc" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending" style="width: 180px;"  >#</th>
                          <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending" style="width: 223px;">Menu name</th>
                          <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 155px;">Edit</th>
                         <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 55px;">Status</th>
                           </tr>
                    </thead>
                    <tbody> 
                        <asp:Repeater ID="Repeater1" runat="server" 
                            onitemcommand="Repeater1_ItemCommand1" >
                        <ItemTemplate>
                       
                    <tr role="row" class="odd">
                        <td  class="sorting_1"><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></>
                        <td><asp:Label ID="lblname" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                        <td><asp:LinkButton ID="btnedit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' runat="server"><i class="glyphicon glyphicon-edit icon-white"></i></asp:LinkButton></td>
                        <%--<td><asp:LinkButton ID="LinkButton3" CommandName="Delete" CommandArgument='<%# Eval("RoleID") %>' runat="server" OnClientClick="return confirm('Are you sure you want to delete this role?');"><i class="glyphicon glyphicon-trash icon-white"></i></asp:LinkButton></td>--%>
                      <td><asp:LinkButton ID="linkdelete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' runat="server" OnClientClick="return confirm('Are you sure you want to Change Status this Menu?');"><%# Eval("active") %></asp:LinkButton></td>
                             </tr>
                      </ItemTemplate>
                      </asp:Repeater>
                      
                      
                      </tbody>
                   
                  </table>
                  </div>

                  




                 </div>

      </div>
         </div></td>


                        </tr>
                </table>
                </div>
              </div>
        
        </section>


</asp:Content>
