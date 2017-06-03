<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="sendforverification.aspx.cs" Inherits="EntryPass.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <section class="content" style="width: 70%;border: 1px solid;border-radius: 8px; min-height:auto; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
            <div class="box-header with-border" style="background-color:#3c8dbc">
              <h1 class="box-title" style="font-size:x-large;">Verification Details</h1>
                
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" >
                  <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">

                      <table style="width:90%; height:auto; margin-left:auto; margin-right:auto;">
                          <tr>
                              <td>
                                Reg No. : 
                              </td>
                              <td>
                                 <asp:TextBox ID="txtreg" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                              </td>
                             </tr>
                             <tr>
                              <td>
                                Applicant Name :
                              </td>
                              <td>
                                 <asp:TextBox ID="txtapplicant" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                              </td>
                             
                          </tr>  
                      </table>
                      </div>
                      </div>
                  <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group"><br />

                      <table style="width:70%; height:auto; margin-left:auto; margin-right:auto;">
                           <tr>
                              <td>
                                Reg No. : 
                              </td>
                              <td>
                                 <asp:TextBox ID="TextBox1" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                              </td>
                             </tr>
                             <tr>
                              <td>
                                Applicant Name :
                              </td>
                              <td>
                                 <asp:TextBox ID="TextBox2" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                              </td>
                             
                          </tr>  
                           <tr>
                                <td>
                                    <asp:Button ID="btnsearch" style="width:70%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnsearch_Click" runat="server" Text="Search"></asp:Button>
                              </td>
                              <td>
                                   <asp:Button ID="btnclear" style="width:70%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnclear_Click" runat="server" Text="Clear"></asp:Button>
                              </td>
                           </tr>
                      </table>
                      </div>
                      </div>
                  </div>
                </div>
              </div>
        </section><br />
     <section class="content" style="width: 70%;border: 1px solid;border-radius: 8px; min-height:auto; padding: 1%;">
          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">                 
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" >
                  <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">

                     <asp:GridView ID="dgvsearchpass" runat="server">
                         <Columns>

                         </Columns>
                     </asp:GridView>
                      </div>
                      </div>
                  </div>
                </div>
         </section>

</asp:Content>
