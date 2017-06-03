<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="AirportAuthoritiesUI.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function registervalidation() {


            if (document.getElementById('<%=txtfullname.ClientID %>').value == "") {
                alert('Name Can Not Black');
                document.getElementById('<%=txtfullname.ClientID %>').style.borderColor = '#b94a48';
                document.getElementById('<%=txtfullname.ClientID %>').focus();
                return false;
            }
                if (document.getElementById('<%=txtemail.ClientID %>').value == "") {
                    alert('Email ID Can Not Black');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
             <div class="register-logo">
        <a href="#" align="center"><b>Create</b>User</a>
      </div>
       
     <div class="col-md-3"> 
      <div class="register-box" style="margin:0PX;">
     

      <div class="register-box-body" style="width:80%;">
       <%-- <p class="login-box-msg">Register a new membership</p>--%>
        <div  >
             <a style="color:black;font-size:small;">Full Name</a>
          <div class="form-group has-feedback">
             
        <asp:TextBox ID="txtfullname" class="form-control"  placeholder="Full name"  runat="server"></asp:TextBox>
          <%--  <input type="text" class="form-control" placeholder="Full name" />--%>
         <%--   <span class="glyphicon glyphicon-user form-control-feedback"></span>--%>
          </div>
            <a style="color:black;font-size:small;">E-Mail ID</a>
          <div class="form-group has-feedback">
               <asp:TextBox ID="txtemail" class="form-control" placeholder="Email"  runat="server"></asp:TextBox>
        <%--    <input type="email" class="form-control" placeholder="Email" />--%>
            <%--<span class="glyphicon glyphicon-envelope form-control-feedback"></span>--%>
          </div>
            <a style="color:black;font-size:small;">Select Sub Party Type</a>
          <div class="form-group has-feedback">
               <asp:DropDownList ID="ddlrole" class="form-control"  runat="server" AutoPostBack="False"></asp:DropDownList>
<%--            <input type="password" class="form-control" placeholder="Retype password" />--%>
            <%--<span class="glyphicon glyphicon-log-in form-control-feedback"></span>--%>
          </div><br />
        <asp:Panel ID="usermode" runat="server">
             <div class="form-group has-feedback">
              <asp:RadioButton ID="online" runat="server" GroupName="a"/> Online&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="offline" runat="server" GroupName="a"/>Offline                
           
<%--            <input type="password" class="form-control" placeholder="Retype password" />--%>
            <%--<span class="glyphicon glyphicon-log-in form-control-feedback"></span>--%>
          </div><br />
            </asp:Panel>
          <div class="row">
            <div class="col-xs-6">
              <div class="checkbox icheck">
                <label>
                  <%--<input type="checkbox"> I agree to the <a href="#">terms</a>--%>
                </label>
              </div>
            </div><!-- /.col -->
            <asp:Panel ID="pnlRegister" runat="server">
                <div class="col-xs-6">
            <asp:Button ID="btnregister" class="btn btn-primary btn-block btn-flat" runat="server" Text="Register" OnClick="btnregister_Click" OnClientClick="javascript:return registervalidation();"/>
              <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>--%>
            </div>
            </asp:Panel>
                          <asp:Panel ID="pnlUpdate" runat="server" Visible="false">
                              <div class="col-xs-6">
            <asp:Button ID="btnUpdate" class="btn btn-primary btn-block btn-flat" runat="server" Text="Update" OnClick="btnUpdate_Click" OnClientClick="javascript:return registervalidation();"/>
              <%--<button type="submit" class="btn btn-primary btn-block btn-flat">Register</button>--%>
            </div>
                          </asp:Panel>
            <!-- /.col -->
          </div>
        </div>
      </div><!-- /.form-box -->
    </div>
         </div>
    <div class="col-md-9">
    <asp:Panel ID="pnlAllUsers" runat="server" Visible="false">
    
          <div class="row">
            <div class="col-xs-12">
              <div class="box">
                <div class="box-header">
                  <h3 class="box-title">Available Users</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <div id="Div1" style="overflow-y:scroll;overflow-x:hidden; height:340px;" class="dataTables_wrapper form-inline dt-bootstrap"><div class="row"><div class="col-sm-6"></div><div class="col-sm-6"></div></div><div class="row"><div class="col-sm-12">
                      
                      <table id="Table1" class="table table-bordered table-hover dataTable" role="grid" aria-describedby="example2_info">
                    <thead>
                      <tr role="row">
                          <th class="sorting_asc" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Rendering engine: activate to sort column descending" aria-sort="ascending">S. No.</th>
<%--                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Browser: activate to sort column ascending">Registration No</th>--%>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending"> Name</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Engine version: activate to sort column ascending">User ID</th>
                         
                          <%--<th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Sub Party Type</th>--%>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Status</th>
<%--                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Departure Date</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Arrival From</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Departure To</th>--%>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Edit</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="CSS grade: activate to sort column ascending">Change Status</th>
                      </tr>
                    </thead>
                    <tbody>
                      

         <asp:Repeater ID="rptShowUser" runat="server" OnItemCommand="rptShowUser_ItemCommand">
         <ItemTemplate>           
                    <tr role="row" class="odd">
                        <td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>
                        <td><%# Eval("EmpName")%></td>
                        <td><%# Eval("UserID")%></td>
                        <td><%# Eval("Active")%></td>
                        <td><asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("ID") %>' CommandName="Edit" runat="server"><span class="fa fa-edit"></span></asp:LinkButton></td>
                         <td><asp:LinkButton ID="LinkButton2" CommandArgument='<%# Eval("ID") %>' CommandName="Delete" OnClientClick="return confirm('Are you sure you want delete');" runat="server"><span class="fa fa-trash"></span></asp:LinkButton></td>	
                      </tr>
                         </ItemTemplate>
       </asp:Repeater>

                    </tbody>
                  </table>
                                                                                                                                                                                                 
                </div><!-- /.box-body -->
              </div><!-- /.box -->

             <!-- /.box -->
            </div><!-- /.col -->
          </div><!-- /.row -->
                  </div>
                </div>
              </div>
        
       
        </asp:Panel>
         </div>
             </div>
    </div>
</asp:Content>
