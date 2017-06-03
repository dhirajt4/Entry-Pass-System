<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="approved.aspx.cs" Inherits="EntryPass.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            var popup;
            function SelectName(button) {
                popup = window.open("printpass.aspx?id=" + button, "Popup", "width=1000,height=650");
                popup.focus();
                return false
            }
            function openInNewTab(url) {
                var win = window.open(url, '_blank');
                win.focus();
            }
</script>
    <style type="text/css">
        .RowStyle {
  height: 30px;
}

#mask {
    position: absolute;
    left: 0px;
    top: 0px;
    width: 100%;
    height: 100%;
    z-index: 1000000;
    background-color:black;
    opacity: 0.9;
    filter: alpha(opacity=70);
    position:absolute;
    overflow: auto;
    
}  
     .modal123
        {
            position: absolute;
            z-index: 999999999;
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
            z-index: 1000000000;
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
        
 
     <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true" >
        <ProgressTemplate>
            <div class="modal123">
                <div class="center">
                    <img alt="" src="img/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
     <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
         <%--<Triggers>
               <asp:AsyncPostBackTrigger EventName="linkd />             
         </Triggers>--%>
                           <%-- <ContentTemplate>--%>
     <asp:Panel ID="mask" Visible="false" runat="server">

        <div style="background-color:antiquewhite;width:50%;z-index:1000; min-height:200px;margin-left:14%; margin-top:10%;border-style:solid;border-width:thick;border-color:black; position:absolute;">
         <table style=" margin-left: auto; margin-right: auto;">
             <tr>
                 <td>Transaction Password :</td><br />
                 <td><asp:TextBox ID="txttranspwd" TextMode="Password" style="margin-top:10%;margin-left:15%;width:70%;" runat="server"></asp:TextBox></td>
                 <td>
                     
                     <%--<asp:Label ID="lblpwderror" runat="server" Text=""></asp:Label>--%><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txttranspwd" ValidationGroup="1" ErrorMessage="Please Enter password !!"></asp:RequiredFieldValidator></td>
             </tr>
             <asp:Panel ID="pnlrejectremark" runat="server">
             <tr>
                 <td>Remarks :</td><br />
                 <td><asp:TextBox ID="txtrejectRemark"  style="margin-top:10%;margin-left:15%;width:70%;" runat="server"></asp:TextBox></td>
                 <td>
                     
                     <%--<asp:Label ID="lblpwderror" runat="server" Text=""></asp:Label>--%><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtrejectRemark" ValidationGroup="1" ErrorMessage="Please Enter Remark !!"></asp:RequiredFieldValidator></td>
             </tr>
                 </asp:Panel>
             <tr>
                 <td></td>
                 <td></td>
                 <td></td>
             </tr>
         </table>
        <div style="margin-left:30%;margin-top:5%;">
            <table style="margin-left: 13%;">
                <tr>
                    <td>
                        <asp:Button ID="btnapprovePass" style="width:95%;" ValidationGroup="1" CssClass="btn btn-block btn-primary btn-flat" OnClick="btnapprovePass_Click" runat="server" Text="Submit"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btncloseapprovepop" style="width:100%;" CssClass="btn btn-block btn-primary btn-flat" OnClick="btncloseapprovepop_Click" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
        </div>
        </div>
    </asp:Panel>
   
    <asp:Panel ID="Panel1"  runat="server">
    <div id="Div1" class="dataTables_wrapper form-inline dt-bootstrap">
        <div class="row">
            
            <div class="col-sm-6"></div><div class="col-sm-6"></div></div><div class="row"><div class="col-sm-12">
                
                    <div class="box" style=" background-color: antiquewhite; border:1px solid; margin-left:auto; margin-right:auto; width: 85%; padding:10px; ">
                     <table style="margin-left:auto; margin-right:auto;">
                 <tr>
                     <td>
                    &nbsp;&nbsp;  <asp:RadioButton ID="rbAllpass" runat="server" ToolTip="List Of All A E P For Approval" GroupName="a" OnCheckedChanged="rbAllpass_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                    </td>
                    <td>
                    &nbsp; All A E P
                    </td>
                    <td>
                    &nbsp;&nbsp;  <asp:RadioButton ID="rbYearlyPass" runat="server" GroupName="a" ToolTip="List Of Permanent A E P For Approval" OnCheckedChanged="rbYearlyPass_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                    </td>
                    <td>
                    &nbsp; Permanent A E P
                    </td>
                      <td>
                    &nbsp;&nbsp;  <asp:RadioButton ID="rbissuedpass" runat="server" GroupName="a" ToolTip="List Of Issue A E P Update" OnCheckedChanged="rbissuedpass_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                    </td>
                    <td>
                    &nbsp; Issue A E P 
                    </td>
                 </tr>
             </table>
                        </div>
                <div class="box" style="max-height:280px; overflow-y:auto; width:85%;  margin-left:auto; margin-right:auto; border:1px solid; padding:10px; ">
                      <table id="Table1" class="table table-bordered table-hover dataTable" role="grid" aria-describedby="example2_info" style=" margin-left:auto; margin-right:auto;">
                    <thead>              
                      <tr role="row">
                          <th class="sorting_asc" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Rendering engine: activate to sort column descending" aria-sort="ascending" style="width: 1%;"><asp:CheckBox ID="cbAllPassno" runat="server" OnCheckedChanged="cbAllPassno_CheckedChanged" AutoPostBack="True"></asp:CheckBox></th>
                         <%--<th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending"> Unique No.</th>--%>
                         
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 23%;">Applicant Name</th>
                         <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 25%;" > Pass Peroid</th>
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 14%;">Access Area</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 11%;">Access Building</th> 
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 4%;">Fee</th> 
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 4%;">Fee Exemption</th>                         
                           <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 11%;">Remark</th>                         
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 4%;"></th>  
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">Doc</th>
                          <th class="sorting" tabindex="0" aria-controls="example2" rowspan="1" colspan="1" aria-label="Platform(s): activate to sort column ascending" style="width: 6%;">ELTE Doc</th>                      
                      </tr>                      
                    </thead>
                    <tbody>
                      
                       

                        <asp:Repeater ID="rptpassDetails" runat="server" OnItemCommand="rptpassDetails_ItemCommand" OnItemDataBound="rptpassDetails_ItemDataBound">
         <ItemTemplate>
           <asp:Label ID="lblApprove_id" runat="server" Visible="false" Text='<%# Eval("uniqueid") %>' ></asp:Label>
                    <tr role="row" class="odd">
                        
                       <td> <asp:CheckBox ID="cbSelectPartName" runat="server"></asp:CheckBox></td>
                        <%--<td><%#(((RepeaterItem)Container).ItemIndex+1).ToString()%></td>--%>
                         <%-- <td>
                            <asp:Label ID="lblpassno" runat="server" Text='<%# Eval("uniqueid") %>'></asp:Label>
                            </td> --%>                  
                       
                        <td>
                            <asp:Label ID="lblapplicantname" runat="server" Text='<%# Eval("applicantname") %>'></asp:Label>
                            </td>  
                         <td> <asp:Label ID="lblpassfrom" runat="server" Text='<%# Eval("PeriodFrom","{0:dd/MM/yyyy}") %>' ></asp:Label> - <asp:Label ID="lblpassto" runat="server" Text='<%# Eval("PeriodTo","{0:dd/MM/yyyy}") %>' ></asp:Label></td>                    
                   <td><asp:Label ID="lblterminalt" runat="server" Text='<%# Eval("terminalname") %>'></asp:Label></td> 
                      
                            <td><asp:Label ID="lblairport" runat="server" Text='<%# Eval("airportname") %>'></asp:Label></td> 
                         <td><asp:Label ID="lblpassfee" runat="server" Text='<%# Eval("passfee") %>'></asp:Label></td> 
                        <td>
                            <asp:CheckBox ID="cbFeeExemption" runat="server" Checked='<%# Eval("remark") %>' AutoPostBack="true" OnCheckedChanged="cbFeeExemption_CheckedChanged"/>
                        </td>
                         <td>
                             <asp:TextBox ID="txtremark" runat="server" Text='<%# Eval("remark_detail") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("uniqueid") %>' CommandName="View" Visible="false" ToolTip="View Pass..!"><span class="glyphicon glyphicon-eye-open"></span></asp:LinkButton>
                            <asp:LinkButton ID="linkissuepass" runat="server" CommandArgument='<%# Eval("uniqueid") %>' CommandName="issuepass" Visible="false" ToolTip="Click to Issue Pass..!"><span class="glyphicon glyphicon-forward"></span></asp:LinkButton>
                        </td>
                           </td> 
                         <td style="align-items:center;">
                             <a target="_blank" href="Physical/doc<%# Eval("uniqueid") %>.pdf"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></a>
                            <%--<asp:LinkButton ID="linkdoc" CommandArgument='<%# Eval("uniqueid") %>' CommandName="doc" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton></td>--%>
                        <td style="align-items:center;">
                            <a target="_blank" href="Physical/bcas<%# Eval("uniqueid") %>.pdf"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></a>
                            <%--<asp:LinkButton ID="linkbcas" CommandArgument='<%# Eval("uniqueid") %>' CommandName="bcas" runat="server"><img src="img/adobe-pdf-logo.png" width="25px" style="align-content:center;"/></asp:LinkButton></td>--%>

                        
                    </tr>
        </ItemTemplate>
       </asp:Repeater>      
                    </tbody>
                  </table>
       
                    </div>
        
        <table style="width:50%; margin-left:auto; margin-right:auto;">
            
            <caption>
                
                <tr>
                    <td>
                        <asp:Button ID="btnapproveBill" runat="server" ToolTip="Approved A E P" class="btn btn-primary btn-block btn-flat" OnClick="btnapproveBill_Click" OnClientClick="javascript:return registervalidation();" style="float:right;" Text="Approved" Width="140px" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelBill" runat="server" ToolTip="Cancel A E P" class="btn btn-primary btn-block btn-flat" OnClick="btnCancelBill_Click" OnClientClick="javascript:return registervalidation();" style="margin-left: 15px;" Text="Reject" Width="140px" />
                    </td>
                </tr>
            </caption>
           
        </table>
        
                                                                                                                                                                                                         
                </div>
              </div>

            </div>
         <div style="margin-left:10%; width:80%; height:280px; overflow-y:auto"><br />
            <asp:GridView ID="dgvPassDetails" runat="server" AlternatingRowStyle-Wrap="false" HeaderStyle-Height="30px"  AutoGenerateColumns="false" OnRowDataBound ="GDVPassDetails_RowDataBound" OnSelectedIndexChanged ="GDVPassDetails_SelectedIndexChanged" Width="100%">
         <rowstyle cssclass="RowStyle" />
                  <Columns >
            <asp:BoundField DataField="uniqueid" ItemStyle-Height="20px" HeaderText="Unique No" ItemStyle-Width="30%" />
                <asp:BoundField DataField="periodfrom" HeaderText="Period From" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy}"/>
               <asp:BoundField DataField="periodto" HeaderText="Period To" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy}"/> 
               <asp:BoundField DataField="applicantname" HeaderText="Aplicant Name" ItemStyle-Width="30%" />
               <asp:BoundField DataField="terminalname" HeaderText="Access Area" ItemStyle-Width="10%" />
               <asp:BoundField DataField="airportname" HeaderText="Access Building" ItemStyle-Width="10%" />
                      <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-Width="10%" />
           </Columns>
            </asp:GridView>
        </div>
        </asp:Panel>
                                <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
</asp:Content>
