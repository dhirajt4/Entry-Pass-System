<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="passstatus.aspx.cs" Inherits="EntryPass.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .RowStyle {
            height:30px;
            width:auto;
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
<%--     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
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
        <ContentTemplate>
    <section class="content" style="width: 70%;border: 1px solid;border-radius: 8px; min-height:auto; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
            <div class="box-header with-border" style="background-color:#3c8dbc">
              <h1 class="box-title" style="font-size:x-large;">Search Pass Status</h1>
                
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

                      <table style="width:70%; height:auto; margin-left:auto; margin-right:auto; float: left;">
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
    <asp:Panel ID="pnlpassstatus" Visible="false" runat="server">
     <section class="content" style="width: 70%;border: 1px solid;border-radius: 8px; min-height:auto; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
                 
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" style="overflow:auto; max-height:400px; ">                  
                      <table style="margin-left:auto; margin-right:auto; width:100%;">
                          <tr>
                              <td>
                     <asp:GridView ID="dgvsearchpass" runat="server" AutoGenerateColumns="False" Width="100%" AlternatingRowStyle-Wrap="False" OnRowDataBound="dgvsearchpass_RowDataBound" OnSelectedIndexChanging="dgvsearchpass_SelectedIndexChanging" EnableModelValidation="True">
                            <AlternatingRowStyle Wrap="False" />
                             <rowstyle cssclass="RowStyle" />
                            <Columns>   
                            <asp:BoundField DataField="uniqueid" HeaderText="Reg no" ItemStyle-Width="25%"/>
                            <asp:BoundField DataField="applicantname" HeaderText="Applicant Name" ItemStyle-Width="25%"/>
                            <asp:BoundField DataField="active" HeaderText="Status" ItemStyle-Width="30%"/>
                                <asp:BoundField DataField="reject_remark" HeaderText="Remark" ItemStyle-Width="20%"/>
                            </Columns>
                     </asp:GridView>
                                    </td>
                          </tr>
                      </table>
 
                  </div>
                </div>
         </section>
        </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
