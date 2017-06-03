<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreatePermission.aspx.cs" Inherits="AirportAuthoritiesUI.CreatePermission" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="content">
          <div class="row" >
            <div class="col-xs-12">

    <table style="width:100%;">
        <tr>
            <td>
        

    <div class="box box-primary" >
<div class="box-header with-border">
                  <h3 class="box-title">Create Permission</h3>
                </div>
                    <div class="box-body">

                    <div class="form-group">
                   <label for="exampleInputEmail1">Permission Name</label>
                       <asp:TextBox CssClass="form-control" ID="txtpermission" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="k" ControlToValidate="txtpermission" runat="server" ForeColor="red" ErrorMessage="Enter Permission Name !"></asp:RequiredFieldValidator>
                    </div>

                    <div class="form-group">
                   <label for="exampleInputEmail1">Permission Page</label>
                       <asp:TextBox CssClass="form-control" ID="txtpage" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="k" ControlToValidate="txtpage" runat="server" ForeColor="red" ErrorMessage="Enter Permission Page Name !"></asp:RequiredFieldValidator>
                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                    </div>

                        <div class="form-group">
                   <label for="exampleInputEmail1">Permission Page Level</label>
                       <asp:TextBox CssClass="form-control" ID="txtpermissionlevel" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="k" ControlToValidate="txtpermissionlevel" runat="server" ForeColor="red" ErrorMessage="Enter Permission Page Level !"></asp:RequiredFieldValidator>
                             <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

                    </div>

                    </div>

                      <div class="box-footer">
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" 
                          CssClass="btn btn-primary btn-sm" 
                          onclick="btn_submit_Click" ValidationGroup="k"  />
                          &nbsp;&nbsp;
                          <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                          CssClass="btn btn-primary btn-sm" onclick="btnCancel_Click" 
                      />
                  </div>
      </div>

                </td>

            <td>


     <div class="col-md-15" style="width:60%;margin-left:10%;overflow-x:scroll;overflow-y:scroll;height:260px;">
      <div class="box box-primary">
<div class="box-header with-border">
                  <h3 class="box-title">All Permission</h3>
                  <%--<a class="btn btn-success" href="CreatePermission.aspx" style="float:right;"><i class="glyphicon glyphicon-shopping-cart"></i> Add Permission</a>--%>
                </div>
                     <div class="box-body">


                     <div class="col-sm-12">
                     <table id="example1" class="table table-bordered table-striped dataTable" role="grid" aria-describedby="example1_info">
                    <thead>
                      <tr role="row"><th class="sorting_asc" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending" style="width: 180px;" hidden="hidden" >ID</th><th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending" style="width: 223px;">Permission name</th><th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 197px;">Permission page</th><th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 155px;">Permission level</th>
                          <th class="sorting" tabindex="0" aria-controls="example1" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending" style="width: 155px;">Edit</th>
                          </tr>
                    </thead>
                    <tbody> 
                        <asp:Repeater ID="Repeater1" runat="server" 
                            onitemcommand="Repeater1_ItemCommand">
                        <ItemTemplate>
                       
                    <tr role="row" class="odd">
                        <td hidden="hidden" class="sorting_1"><asp:Label ID="lblPermissionID" runat="server" Text='<%# Eval("PermissionID") %>'></asp:Label></td>
                        <td><asp:Label ID="lblpermissionname" runat="server" Text='<%# Eval("PermissionName") %>'></asp:Label></td>
                        <td><asp:Label ID="lblpermissionpage" runat="server" Text='<%# Eval("PermissionPage") %>'></asp:Label></td>
                         <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("PermissionLevel") %>'></asp:Label></td>
                        <td><asp:LinkButton ID="btnedit" CommandName="Edit" CommandArgument='<%# Eval("PermissionID") %>' runat="server"><i class="glyphicon glyphicon-edit icon-white"></i></asp:LinkButton></td>
                        <%--<td><asp:LinkButton ID="LinkButton3" CommandName="Delete" CommandArgument='<%# Eval("PermissionID") %>' runat="server" OnClientClick="return confirm('Are you sure you want to delete this role?');"><i class="glyphicon glyphicon-trash icon-white"></i></asp:LinkButton></td>--%>
                      </tr>
                      </ItemTemplate>
                      </asp:Repeater>
                      
                      
                      </tbody>
                   
                  </table>
                  </div>

                  
                     </div>
                     </div>
         </div>

                </td>
            </tr>
    </table>

                </div>
              </div>
        </section>
</asp:Content>
