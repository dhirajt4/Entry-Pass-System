<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="updatepermanentpass.aspx.cs" Inherits="EntryPass.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .RowStyle {
  height: 30px;
}
         .modal123
        {
            position: absolute;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .center
        {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 150px;
            background-color: White;
            border-radius: 10px;
            filter: alpha(opacity=100);
            opacity: 1;
            -moz-opacity: 1;
        }
        .center img
        {
            height: 128px;
            width: 128px;
        }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal123">
                <div class="center">
                    <img alt="" src="img/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
     <section class="content" style="width: 70%;border: 1px solid;border-radius: 8px; min-height:auto; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
            <div class="box-header with-border" style="background-color:#3c8dbc">
              <h1 class="box-title" style="font-size:x-large;">Update Permanent E P No</h1>
                
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" style="overflow:scroll; max-height:400px;">
                  
               <%--   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="id" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"> 
                      <Columns>
        
        <asp:BoundField DataField="passno" HeaderText="Name" />
        
        <asp:CommandField ShowEditButton="true" />
                      </Columns>
                  </asp:GridView>--%>

                  



                   <table id="Table2" class="table table-bordered table-hover dataTable" role="grid" aria-describedby="example2_info">
                    <thead>
                      <tr role="row">
                         
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending"  style="width: 20%;">Applicant Name</th>
                        <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 7%;">DOB</th>
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 9%;" >Period From</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 9%;">Period To</th>                        
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 14%;">AEP No.</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 11%;">Upload Vef. Doc</th> 
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 12%;">Action</th>                   
                      </tr>
                    </thead>
                    <tbody>
                  <asp:Repeater ID="rptpermanentAEPUpdate" runat="server" OnItemCommand="rptpermanentAEPUpdate_ItemCommand">
                      <ItemTemplate>
                      <tr role="row" class="odd" >
                          <asp:Label ID="lbluniqueid" runat="server" Visible="false" Text='<%# Eval("uniqueid") %>'></asp:Label>
                          <td>
                              <asp:Label ID="lblapplicantname" runat="server" Text='<%# Eval("applicantname") %>'></asp:Label>
                             
                          </td>
                          <td>
                              <asp:Label ID="lbldob" runat="server" Text='<%# Eval("dob","{0:dd/MM/yyyy}")%>'></asp:Label>
                          </td>
                          <td>
                              <asp:Label ID="lblPeriodFrom" runat="server" Text='<%# Eval("PeriodFrom","{0:dd/MM/yyyy}")  %>'></asp:Label>
                              <asp:TextBox ID="txtPeriodFrom" runat="server" Visible="false" Width="75px" Text='<%# Eval("PeriodFrom","{0:dd/MM/yyyy}")  %>' class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask ></asp:TextBox>
                          </td>
                          <td>
                              <asp:Label ID="lblPeriodTo" runat="server" Text='<%# Eval("PeriodTo","{0:dd/MM/yyyy}")  %>'></asp:Label>
                              <asp:TextBox ID="txtPeriodTo" runat="server" Visible="false" Width="75px" Text='<%# Eval("PeriodTo","{0:dd/MM/yyyy}")  %>' class="form-control" data-inputmask="'alias': 'dd/mm/yyyy'" data-mask ></asp:TextBox>
                          </td>
                          <td>
                              <asp:Label ID="lblpassno" runat="server" Text='<%# Eval("passno") %>'></asp:Label>
                              <asp:TextBox ID="txtpassno" runat="server" Visible="false" Width="80%" Text='<%# Eval("passno") %>' ></asp:TextBox>
                          </td>
                           <td>
                             <asp:FileUpload ID="fuPermanentAepDoc" runat="server" Visible="false" accept=".pdf" Width="100%"></asp:FileUpload>
                          </td>
                           <td>
                               
                         <asp:LinkButton ID="linkEdit" runat="server" CommandArgument='<%# Eval("uniqueid") %>' CommandName="Edit" ToolTip="Edit AEP No. ..!"><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                         <asp:LinkButton ID="linkUpdate" runat="server" Visible="false" CommandArgument='<%# Eval("uniqueid") %>' CommandName="Update" ToolTip="Update AEP"><span class="glyphicon glyphicon-ok"></span></asp:LinkButton>&nbsp;&nbsp;
                         <asp:LinkButton ID="linkCancel" runat="server" Visible="false"  CommandArgument='<%# Eval("uniqueid") %>'  CommandName="Cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                            </td>
                          </tr>
                     </ItemTemplate>
                  </asp:Repeater>
                        </tbody>         
                       </table>
                  </div>
                </div>
              </div>
        </section>
           
            <%--</ContentTemplate>

        </asp:UpdatePanel>--%>
</asp:Content>
