<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RoleInsert.aspx.cs" Inherits="AirportAuthoritiesUI.RoleInsert" %>
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
                  <h3 class="box-title">Insert Role</h3>
                </div>

                  <div class="box-body" >
                    <div class="form-group">
                   <label for="exampleInputEmail1">Role Name</label>
                    <asp:TextBox CssClass="form-control" ID="txtrole"  runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ValidationGroup="mm" ID="RequiredFieldValidator1" ControlToValidate="txtrole" runat="server" ErrorMessage="Enter Role Name !"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                       <div class="form-group">
                   <label for="exampleInputEmail1">Role Level</label>
                    <asp:TextBox CssClass="form-control" ID="txtrolelevel"  runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ValidationGroup="mm" ID="RequiredFieldValidator2" ControlToValidate="txtrolelevel" runat="server" ErrorMessage="Enter Role Level !"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
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

                <div class="col-md-15" style="width:45%;margin-left:10%;overflow-x:scroll;overflow-y:scroll;height:92%;">
      <div class="box box-primary">
<div class="box-header with-border">
                  <h3 class="box-title">All Role</h3>
                   <%--<a class="btn btn-success" href="role.aspx" style="float:right;"><i class="glyphicon glyphicon-shopping-cart"></i> Add Role</a>--%>
                </div>
                 <div class="box-body">
                 <div class="col-sm-12">
                     <table id="example1" class="table table-bordered table-striped dataTable" role="grid" aria-describedby="example1_info">
                    <thead>
                      <tr role="row"><th class="sorting_asc" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending" style="width: 180px;"  >ID</th><th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending" style="width: 223px;">Permission name</th><th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 155px;">Page Level</th>
                          <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 155px;">Edit</th>
                          </tr>
                    </thead>
                    <tbody> 
                        <asp:Repeater ID="Repeater1" runat="server" 
                            onitemcommand="Repeater1_ItemCommand1" >
                        <ItemTemplate>
                       
                    <tr role="row" class="odd">
                        <td  class="sorting_1"><asp:Label ID="lblroleid" runat="server" Text='<%# Eval("RoleID") %>'></asp:Label></td>
                        <td><asp:Label ID="lblname" runat="server" Text='<%# Eval("RoleName") %>'></asp:Label></td>
                        <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("RoleLevel") %>'></asp:Label></td>
                        <td><asp:LinkButton ID="btnedit" CommandName="Edit" CommandArgument='<%# Eval("RoleID") %>' runat="server"><i class="glyphicon glyphicon-edit icon-white"></i></asp:LinkButton></td>
                        <%--<td><asp:LinkButton ID="LinkButton3" CommandName="Delete" CommandArgument='<%# Eval("RoleID") %>' runat="server" OnClientClick="return confirm('Are you sure you want to delete this role?');"><i class="glyphicon glyphicon-trash icon-white"></i></asp:LinkButton></td>--%>
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
