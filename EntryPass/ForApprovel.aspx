<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ForApprovel.aspx.cs" Inherits="EntryPass.ForApprovel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script type="text/javascript">
       var popup;
       function SelectName(button) {
           popup = window.open("printpass.aspx?id=" + button, "Popup", "width=1000,height=650");
           popup.focus();
           return false
       }
</script>
      <style type="text/css">
#pnlupdatepass {
    position: absolute;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 100000000;
    background-color:black;
    opacity: 0.9;
    filter: alpha(opacity=70);
    position:absolute;
    overflow: auto;
    
}  
</style>
        <style type="text/css">
       .legend {
            display: block;

padding: 0px;
margin-bottom: 20px;
font-size: 21px;
line-height: inherit;
color: #333;
margin-left:4%;
border-width: 0px 0px 1px;
border-style: none none solid;
-moz-border-top-colors: none;
-moz-border-right-colors: none;
-moz-border-bottom-colors: none;
-moz-border-left-colors: none;
border-image: none;
        }
        .row9026 {
    font-size: 12px;
    line-height: 1.42857;
    color: #333;
    font-family: Verdana;
    font-weight: 400;
    box-sizing: border-box;
    width: 40%;
    float: left;
    position: relative;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 15px;
        }
    </style>
    <style type="text/css">
    #mask {
    position: absolute;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 100000000;
    background-color:black;
    opacity: 0.9;
    filter: alpha(opacity=70);
    position:absolute;
    overflow: auto;
    
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnexporttoexcel" />
     </Triggers>
        <ContentTemplate>
            <asp:Panel ID="mask" Visible="false" runat="server">
             <div style="background-color:antiquewhite;width:50%;z-index:1000; min-height:200px;margin-left:14%; margin-top:10%;border-style:solid;border-width:thick;border-color:black; position:absolute;">
         <table style=" margin-left: auto; margin-right: auto;">
             <tr>
             <td>
                 <asp:RadioButton ID="rbCash" runat="server" GroupName="ab" OnCheckedChanged="rbCash_CheckedChanged" AutoPostBack="true"/> &nbsp; Cash&nbsp;&nbsp;
             </td>    
                 <td>
                    <asp:RadioButton ID="rbcheque" runat="server" GroupName="ab" OnCheckedChanged="rbcheque_CheckedChanged" AutoPostBack="true"/> &nbsp; Cheque
                 </td>
             </tr>
         </table><br />
                 <asp:Panel ID="pnlcheque" Visible="false" runat="server">
        <table style=" margin-left: auto; margin-right: auto;">
            <tr>
                <td>
                    Cheque No. :
                </td>
                <td>
<asp:TextBox ID="txtChequeno" class="form-control" style="margin-top:0px;" runat="server"  placeholder=" Cheque No"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Cheque Date :
                </td>
                <td>
 <asp:TextBox ID="txtChequeDate" class="form-control" style="margin-top:0px;" runat="server"  placeholder=" DD-MM-YYYY"  data-inputmask="'alias': 'dd/mm/yyyy'" data-mask></asp:TextBox>
                </td>
            </tr>
            </table>
                     </asp:Panel>
        <div style="margin-left:30%;margin-top:5%;">
            <table style="margin-left: 13%;">
                <tr>
                    <td>
                        <asp:Button ID="btnsumbit" style="width:95%;" ValidationGroup="1" CssClass="btn btn-block btn-primary btn-flat" OnClick="btnsumbit_Click" runat="server" Text="Submit"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnclose" style="width:100%;" CssClass="btn btn-block btn-primary btn-flat" OnClick="btnclose_Click" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
        </div>
        </div>
            </asp:Panel>


<asp:Panel ID="pnlAllUsers" runat="server" Visible="True" style="width:70%;margin-top:10px; margin-left: 7%; position: absolute;">
    <section class="content">
          <div class="row">
            <div class="col-xs-12">
                 <div class="box" style="border:1px solid; width:100%; margin-left:auto; background-color: antiquewhite; margin-right:auto; padding:10px;">
                     <table style="margin-left:auto; margin-right:auto;">
                         <tr>
                             <td>
<asp:RadioButton ID="rbUnapproved" runat="server" GroupName="a" OnCheckedChanged="rbUnapproved_CheckedChanged" Checked="true" AutoPostBack="true"></asp:RadioButton>
                             </td>
                             <td>
                                &nbsp; UnApproved A E P
                             </td>
                             <td>&nbsp;&nbsp;</td>
                             <td>
                                 <asp:RadioButton ID="rbapproved" runat="server" GroupName="a" OnCheckedChanged="rbapproved_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                             </td>
                             <td>
                                &nbsp; Approved A E P
                             </td>
                              <td>
                               &nbsp;&nbsp;  <asp:RadioButton ID="rbreject" runat="server" GroupName="a" OnCheckedChanged="rbreject_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                             </td>
                             <td>
                                &nbsp; Reject A E P
                             </td>
                              <td>
                               &nbsp;&nbsp;  <asp:RadioButton ID="rbyearlypassdetail" runat="server" GroupName="a" OnCheckedChanged="rbyearlypassdetail_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                             </td>
                             <td>
                                &nbsp; Generated A E P
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
                          <th></th>
                         <%--<th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending"> Unique No.</th>--%>
                         
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 23%;">Applicant Name</th>
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 25%;" > Pass Peroid</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 8%;">Building</th>
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 14%;">Access Area</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Fee</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Doc</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">ELTE Doc</th>
                       <th></th>
                           <th></th>
                           <th></th>
                      </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptforPassapprovel" runat="server" OnItemCommand="rptforPassapprovel_ItemCommand" OnItemDataBound="rptforPassapprovel_ItemDataBound">
         <ItemTemplate>
           <asp:Label ID="lblApprove_id" runat="server" Visible="false" Text='<%# Eval("uniqueid") %>' ></asp:Label>
             <asp:Label ID="lblapproveddate" runat="server" Visible="false" Text='<%# Eval("approvedate","{0:dd/MM/yyyy}") %>' ></asp:Label>
                    <asp:Label ID="lblReceiptNo" Visible="false" runat="server" Text='<%# Eval("receiptno") %>' ></asp:Label>
                    <tr role="row" class="odd" >
                        <asp:Label ID="lblactive" runat="server" Visible="false" Text='<%# Eval("active") %>'></asp:Label>
                        <td>
                            <asp:CheckBox ID="cbcheck" runat="server"></asp:CheckBox>
                        </td>                 
                       
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
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("passfee") %>'></asp:Label> 
                            <asp:Label ID="lblbcasapprval" runat="server" Text='<%# Eval("bcasapproval") %>' Visible="false"></asp:Label>                            
                            </td> 
                         <td style="align-items:center;">
                             <a target="_blank" href="Physical/doc<%# Eval("uniqueid") %>.pdf"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></a>
                            <%--<asp:LinkButton ID="linkdoc" CommandArgument='<%# Eval("uniqueid") %>' CommandName="doc" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton></td>--%>
                        <td style="align-items:center;">
                            <a target="_blank" href="Physical/bcas<%# Eval("uniqueid") %>.pdf"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></a>
                          <%--  <asp:LinkButton ID="linkbcas" CommandArgument='<%# Eval("uniqueid") %>' CommandName="bcas" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton></td>--%>

                        <td>
                            <asp:LinkButton ID="linkEdit" runat="server" CommandArgument='<%# Eval("uniqueid") %>' CommandName="Edit" ToolTip="Edit Pass..!"><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                         <asp:LinkButton ID="linkreceipt" runat="server" Visible="false" CommandArgument='<%# Eval("uniqueid") %>' CommandName="Receipt" ToolTip="Generate Receipt..!">Receipt</asp:LinkButton>
                         <asp:LinkButton ID="linkreceiptno" runat="server"  CommandArgument='<%# Eval("uniqueid") %>' Text='<%# Eval("receiptno") %>' ToolTip="Print Receipt..!"  CommandName="printReceiptno"></asp:LinkButton>
                            </td>
                        <td>
                              <asp:LinkButton ID="linkapprovel" runat="server" CommandArgument='<%# Eval("uniqueid") %>' CommandName="Approvel" ToolTip="Send For Approval..!"><span class="glyphicon glyphicon-forward"></span></asp:LinkButton>
                             <asp:LinkButton ID="linkprint" runat="server" Visible="false" CommandArgument='<%# Eval("uniqueid") %>' CommandName="print" ToolTip="Print Pass..!"><span class="glyphicon glyphicon-print"></span></asp:LinkButton>
                             <asp:Label ID="lblrejectremark" runat="server" Visible="false" Text='<%# Eval("reject_remark") %>'></asp:Label>
                        </td>
                        <td>
                             <asp:LinkButton ID="linkdelete" runat="server" Visible="false" CommandArgument='<%# Eval("uniqueid") %>' CommandName="delete" ToolTip="Delete Pass..!" OnClientClick="return confirm('Are you sure you want to Delete this Pass Request?');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
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
                <%--<asp:Panel ID="pnlapprovedbill" Visible="false" runat="server">
                 <div class="box" style="border:1px solid; width:80%; margin-left:auto; margin-right:auto; max-height:250px;">
<div class="box-body">
                  <div id="Div3" class="dataTables_wrapper form-inline dt-bootstrap"><div class="row"><div class="col-sm-6"></div><div class="col-sm-6"></div></div><div class="row"><div class="col-sm-12">
           <div style="width:100%; max-height:182px; overflow-y:scroll">           

  <asp:GridView ID="DGVFinalPassPrint" runat="server"  AlternatingRowStyle-Wrap="true" AutoGenerateColumns="true" OnRowDataBound ="DGVFinalPassPrint_RowDataBound" OnSelectedIndexChanged ="DGVFinalPassPrint_SelectedIndexChanged" Width="100%" EmptyDataText="No Record available...!">
           
            </asp:GridView>
               </div>                                                                                                                                                                                                          </div>
                    </div>
                  </div>
     <table style="margin-left:auto; margin-right:auto; width:15%;">
                    <tr>
                        <td>
 <asp:Button ID="btnBillPrint"  runat="server" Height="30px" Width="80%"  Text="Print" OnClick="btnBillPrint_Click" style="background-color:#367fa9; color:white;" BorderStyle="None"></asp:Button>
                        </td>
                    </tr>
                </table>
            </div><!-- /.col -->
          </div><!-- /.row -->
               </asp:Panel>--%>
                </div>
              </div>
        <asp:Panel ID="pnlgenerateReceipt" Visible="false" runat="server"><br />
     <table style="width: 35%; margin-left: auto; margin-right: auto;">
                              <tbody>
                                   <tr>
                            <td>
                                <asp:Button ID="btnReceiptno" style="width:75%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnReceiptno_Click" runat="server" Text="Generate Receipt"></asp:Button>
                            </td>
                                       <td>
                                           <asp:Button ID="btnPrint" style="width:80%;"  CssClass="btn btn-block btn-primary btn-flat" Visible="false" OnClick="btnPrint_Click" runat="server" Text="Print Pass"></asp:Button>
                                       </td>
                        </tr>
                              </tbody>
                          </table>
</asp:Panel>
        <asp:Panel ID="pnlexporttoexcel" Visible="false" runat="server"><br />
     <table style="width: 35%; margin-left: auto; margin-right: auto;">
                              <tbody>
                                   <tr>
                            <td>
                                <asp:Button ID="btnexporttoexcel" style="width:50%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnexporttoexcel_Click" runat="server" Text="Export TO Excel"></asp:Button>
                            </td>
                                      
                        </tr>
                              </tbody>
                          </table>
</asp:Panel>
        </section>
        </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
