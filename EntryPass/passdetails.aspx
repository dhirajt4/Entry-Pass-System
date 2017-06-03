<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="passdetails.aspx.cs" Inherits="EntryPass.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content" style="width:85%">
          <div class="row">
            <div class="col-xs-12">
                 <div class="box" style="border:1px solid; width:100%; margin-left:auto; background-color: antiquewhite; margin-right:auto; padding:10px;">
                     <table style="margin-left:auto; margin-right:auto; width:70%;">
                         <tr>
                             <td>
                                 Organization Name : 
                             </td>
                             <td>
                            &nbsp;&nbsp;<asp:DropDownList ID="ddlAgencyName" CssClass="form-control select2" runat="server" Width="150px" AutoPostBack="true" OnTextChanged="ddlAgencyName_TextChanged"></asp:DropDownList>
                             </td>
                             <td>
                                &nbsp;&nbsp;  Applicant Name : 
                             </td>
                             <td>
                                 &nbsp;&nbsp;<asp:DropDownList ID="ddlapplicantname" CssClass="form-control select2" runat="server" Width="150px" AutoPostBack="true" OnTextChanged="ddlapplicantname_TextChanged"></asp:DropDownList>
                             </td>
                             <td>
                                  &nbsp;<asp:Button ID="btnexport" style="width:100%;margin-top: -18px;" CssClass="btn btn-block btn-primary" OnClick="btnexport_Click" runat="server" Text="Excel"></asp:Button>
                             </td>
                         </tr>
                     </table>
                     </div>
                      <div class="box" style="border:1px solid; width:100%; margin-left:auto; background-color: antiquewhite; margin-right:auto; max-height:400px;">
                <!-- /.box-header -->
                     <asp:Panel ID="pnlunapprovedbill"  runat="server">
                <div class="box-body" >
                  <div id="Div2" class="dataTables_wrapper form-inline dt-bootstrap"><div class="row"><div class="col-sm-6"></div><div class="col-sm-6"></div></div><div class="row"><div class="col-sm-12">
                      <div style="width:100%; max-height:400px; overflow-y:auto"">
                 <table id="Table2" class="table table-bordered table-hover dataTable" role="grid" aria-describedby="example2_info">
                    <thead>
                      <tr role="row">
                      
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 23%;">Applicant Name</th>
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 23%;" > Pass Peroid</th>            
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 8%;">Building</th>
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 14%;">Access Area</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 10%;" >Area Zones</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 10%;" >Organization</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Fee</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Doc</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">ELTE Doc</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Status</th>
                       
                      </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptpassdetails" runat="server" OnItemCommand="rptpassdetails_ItemCommand">
         <ItemTemplate>
         
                    <tr role="row" class="odd" >
                        <asp:Label ID="lblactive" runat="server" Visible="false" Text='<%# Eval("active") %>'></asp:Label>
                      
                            <td>
                            <asp:Label ID="lblapplicantname" runat="server" Text='<%# Eval("applicantname") %>'></asp:Label>
                            </td>                 
                        <td> <asp:Label ID="lblpassfrom" runat="server" Text='<%# Eval("PeriodFrom","{0:dd/MM/yyyy}") %>' ></asp:Label> To <asp:Label ID="lblpassto" runat="server" Text='<%# Eval("PeriodTo","{0:dd/MM/yyyy}") %>' ></asp:Label></td>   
                                        
                   <td>
                       <asp:Label ID="lblairport" runat="server" Text='<%# Eval("airportname") %>'></asp:Label>
                       </td> 
                            <td>
                                <asp:Label ID="lblterminalt" runat="server" Text='<%# Eval("terminalname") %>'></asp:Label>
                            </td>
                        <td>
                                <asp:Label ID="lblareazones" runat="server" Text='<%# Eval("areazones") %>'></asp:Label>
                            </td>
                          <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("agency1") %>'></asp:Label>
                            
                            </td> 
                        <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("passfee") %>'></asp:Label>
                            
                            </td> 
                       <td style="align-items:center;">
                            <asp:LinkButton ID="linkdoc" CommandArgument='<%# Eval("uniqueid") %>' CommandName="doc" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton>

                       </td>
                        <td style="align-items:center;">
                            <asp:LinkButton ID="linkbcas" CommandArgument='<%# Eval("uniqueid") %>' CommandName="bcas" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton>

                        </td>   
                        <td>
                                <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("status") %>'></asp:Label>
                            
                            </td>                                          
                    </tr>
                         </ItemTemplate>
                         </asp:Repeater>                       
                    </tbody>
                  </table>
                         
                 </div>                                                                                                                                                              
                </div>
               </div>

            </div>
                    </div>
                         </asp:Panel>
                     
                  </div>
              
                </div>
              </div>
        
        
        </section>
</asp:Content>
