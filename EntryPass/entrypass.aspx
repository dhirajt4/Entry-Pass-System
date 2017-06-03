<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="entrypass.aspx.cs" Inherits="AirportAuthoritiesUI.WebForm11" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <script src="js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var popup;
        function webcam(button) {
            popup = window.open("cs.aspx?id=" + button, "Popup", "width=1000,height=650");
            popup.focus();
            return false
        }
</script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
</script>
     
   <script type="text/javascript">
       $(function () {
           $("#ctl00_ContentPlaceHolder1_cbselfesct").click(function () {
               if ($(this).is(":checked")) {
                   $("#selfesct").hide();
               } else {
                   $("#selfesct").show();
               }
           });
       });
</script>

    <style type="text/css">
               .RowStyle {
  height: 25px;
}

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
        #pnlpopup {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 1000;
            background-color: black;
            opacity: 0.9;
            filter: alpha(opacity=70);
            position: absolute;
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
  
     <script type="text/javascript">
         function foo(input) {            
           
             $("[id*=pic]").attr("src", input)   
                        .width(90)
                        .height(90);
             document.getElementById('<%=fuPhotoPath.ClientID%>').attributes = input.value;                                  
         }

         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=pic.ClientID%>').prop('src', e.target.result)
                        .width(90)
                        .height(90);
                };
                reader.readAsDataURL(input.files[0]);
                }
         }

         function ShowImagePreview1(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=sign.ClientID%>').prop('src', e.target.result)
                        .width(150)
                        .height(80);
                 };
                 reader.readAsDataURL(input.files[0]);
                 }
             }
</script>  
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
     <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <div class="modal123">
                <div class="center">
                    <img alt="" src="img/loader.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlpopup" Visible="false" runat="server" >
        <div style="background-color:antiquewhite;width:40%;z-index:100;min-height:300px; border: 2px solid red;border-radius: 8px;margin-left:20%; margin-top:5%; position:absolute; overflow-style:scrollbar; ">
         <div style="float:right;">
             <asp:ImageButton ID="ImageButton1" runat="server" width="11%" ImageUrl="~/img/close.png" OnClick="ImageButton1_Click" ImageAlign="Right"/>
         </div>        
        <table id="Table3" style="margin-left:auto; margin-right:auto; width: 75%;" >
                        <tbody>
                          <tr>
                              <td>
                                  Old Pass No.
                              </td>
                              <td>
 <asp:TextBox ID="txtOldPassNo"  class="form-control" placeholder=" Pass Number" runat="server"></asp:TextBox>  
                              </td>                          
                          </tr> 
                            <tr>
                                <td></td>
                                <td>Or</td>
                            </tr>
                            <tr>
                                <td>
Applicant Name :
                                </td>
                                <td>
 <asp:TextBox ID="txtsearchname" placeholder=" Applicant Name" class="form-control" runat="server"></asp:TextBox>  
                                </td>
                                 <td>
<asp:Button ID="btnSearch"  runat="server" Height="23px" Text="Search"  OnClick="btnSearch_Click" style="background-color:#367fa9; margin-left: 8px; color:white;" BorderStyle="None"  OnClientClick="javascript:return registervalidation();"></asp:Button>
                                  &nbsp;&nbsp;
<asp:Button ID="btnclose"  runat="server" Height="23px" Text="close"  OnClick="btnclose_Click" style="background-color:#367fa9; color:white;" BorderStyle="None"  OnClientClick="javascript:return registervalidation();"></asp:Button>
                                    </td>
                            </tr>
                             <tr>
                                 <td></td>
                                <td>Or</td>
                            </tr>
                            <tr>
                                <td>
Applicant DOB :
                                </td>
                                <td>
 <asp:TextBox ID="txtsearchdob"  class="form-control" runat="server"  placeholder=" DD-MM-YYYY"  data-inputmask="'alias': 'dd/mm/yyyy'" data-mask=""></asp:TextBox> 
                                </td>
                            </tr>
                            <tr>
                                 <td></td>
                                <td>Or</td>
                            </tr>
                             <tr>
                                <td>
Mobile No :
                                </td>
                                <td>
 <asp:TextBox ID="txtmobile" placeholder=" Applicant Mobile" class="form-control" onkeypress="return isNumberKey(event)" MaxLength="10" runat="server"></asp:TextBox>  
                                </td>
                                 </tr>
                            <tr>
                                <td>

                                </td>
                                <td>
                                    <asp:Label ID="lblmessage" runat="server" ></asp:Label>
                                </td>
                            </tr>                                                       
                    </tbody>
                  </table><br />
            <table style="margin-left:auto; margin-right:auto; Width:85%">
                <tr>
                    <td>
                       <div style="overflow:auto; max-height:300px;">
                        <asp:GridView ID="DGVOldPassDetails"  runat="server" AutoGenerateColumns="False" AlternatingRowStyle-Wrap="False" OnRowDataBound="DGVOldPassDetails_RowDataBound" OnSelectedIndexChanging="DGVOldPassDetails_SelectedIndexChanging" EnableModelValidation="True">
                            <AlternatingRowStyle Wrap="False" />
                             <rowstyle cssclass="RowStyle" />
                            <Columns>
                                <asp:BoundField DataField="applicantname" HeaderText="Applicant Name" ItemStyle-Width="50%">
                                <ItemStyle Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="uniqueid" HeaderText="Unique No" ItemStyle-Width="35%">
                                <ItemStyle Width="35%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="dob" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Date Of Birth" ItemStyle-Width="10%">
                                <ItemStyle Width="10%" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                           </div>
                    </td>
                </tr>
            </table><br />

        </div>
        </asp:Panel>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
    <asp:Panel ID="pnlesct" Visible="false" runat="server" >
      
        <div style="width:70%;z-index:100; top:50%; margin-left:10%; border: 2px solid red;border-radius: 8px;  position:absolute; overflow:auto;">
         <div style="float:right; z-index:500; position:relative;">
             <asp:ImageButton ID="ImageButton2" runat="server" width="11%" ImageUrl="~/img/close.png" OnClick="ImageButton1_Click" ImageAlign="Right"/>
         </div>        
        <section class="content" style="width: 100%;border: 1px solid; border-radius: 8px; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
            <div class="box-header with-border" style="background-color:#3c8dbc">
              <h1 class="box-title" style="font-size:x-large;">Add Esct Pass</h1>
                
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" >
                  <fieldset style="border:1px solid; border-radius:5px; padding:5px;margin-left: 11px;margin-right: 11px;">
                       <legend >Esct Person Detail</legend>
                <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">

                      <table style="width:100%">
                        <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 10px; float:right;">Pass No :</a> 
</td>
                            <td>
                                <asp:TextBox ID="txtesctPassno" runat="server"  style="margin-top: 5px;" class="form-control" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td >
   <a style="color: #000; font-size: 10px; float:right;">DOB :</a> 
</td>
                            <td style="width: 47%;">
                                <table>
                                    <tr>
                                        <td>
                               <asp:TextBox ID="txtesctdob" class="form-control" style="margin-top:5px;" runat="server" ></asp:TextBox>
                                 </td>
                                        <td>
                                            &nbsp;  <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton3" TargetControlID="txtesctdob" Format="dd/MM/yyyy"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                         <tr>
<td style="width: 47%;">
   <a style="color: #000; font-size: 11px; float:right;">Organization :</a> 
</td>
                            <td>
                                <asp:DropDownList ID="ddlesctagency" runat="server" CssClass="form-control select2" style="margin-top:5px;"></asp:DropDownList>
                                <%--<asp:TextBox ID="txtesctAgency" runat="server"  style="margin-top: 5px;" class="form-control" ></asp:TextBox>--%>
                            </td>
                        </tr>
                        
                    </table>
                      </div>
                    </div>
                       <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">

                      <table style="width:100%">
                        <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 10px; float:right;">Applicant Name :</a> 
</td>
                            <td>
<asp:TextBox ID="txtesctapplicantname" runat="server"  style="margin-top: 5px;" class="form-control" ></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td >
   <a style="color: #000; font-size: 10px; float:right;">Valid From :</a> 
</td>
                            <td style="width: 47%;">
                               <table>
                                    <tr>
                                         <td>
  <asp:TextBox ID="txtEsctpassFromdate" class="form-control" style="margin-top:5px;" runat="server" ></asp:TextBox>
                                              <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="ImageButton5" TargetControlID="txtEsctpassFromdate"
        Format="dd/MM/yyyy"/>
                                        </td>
                                        <td>
   <a style="color: #000; font-size: 11px; margin:5px;">To</a> 
                                        </td>
                                        <td>
 <asp:TextBox ID="txtEsctpassTodate" class="form-control" style="margin-top:5px;" runat="server" ></asp:TextBox>
                                             <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton6" TargetControlID="txtEsctpassTodate"
        Format="dd/MM/yyyy"/>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                         <tr>
<td style="width: 47%;">
   
</td>
                             <td style="margin-top:5px;">
<asp:Button ID="btninsertEsctby"  runat="server" Height="23px" Text="Save & Send For Approval"  OnClick="btninsertEsctby_Click" style="margin-top:5px; background-color:#367fa9; color:white;" BorderStyle="None"  ></asp:Button>
                                  &nbsp;&nbsp;&nbsp;
<asp:Button ID="btnClearEsctby"  runat="server" Height="23px" Text="close"  OnClick="btnclose_Click" style="margin-top:5px; background-color:#367fa9; color:white;" BorderStyle="None" ></asp:Button>
                                    </td>
                        </tr>
                       
                    </table>
                      </div><br /><br />
                    </div>
                      
                      </fieldset>
                  </div>
                </div>
              </div>
            </section>

        </div>
        </asp:Panel>
                </ContentTemplate>
        </asp:UpdatePanel>







    <asp:Panel ID="pnlMain" runat="server">
<section class="content" style="width: 85%;border: 1px solid;border-radius: 8px; padding: 1%;">

          <!-- SELECT2 EXAMPLE -->
          <div class="box box-default">
            <div class="box-header with-border" style="background-color:#3c8dbc">
              <h1 class="box-title" style="font-size:x-large;">Entry Pass Form</h1>
                
            </div><!-- /.box-header -->
            <div class="box-body">
              <div class="row" >
                  <fieldset style="border:1px solid; border-radius:5px; padding:5px;margin-left: 11px;margin-right: 11px;">
                       <legend >Official Use</legend>
                <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">
                       
                       
                    <table style="width:100%">
                        <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 10px; float:right;">Pass :</a> 
</td>
                            <td>
<asp:DropDownList ID="ddlPass" class="form-control" runat="server" AutoPostBack="true" OnTextChanged="ddlPass_TextChanged"></asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
<td >
   <a style="color: #000; font-size: 10px; float:right;">Pass Type :</a> 
</td>
                            <td style="width: 47%;">
                               <asp:DropDownList ID="ddlPassType" runat="server" style="margin-top:5px;" class="form-control" AutoPostBack="true" OnTextChanged="ddlPassType_TextChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <asp:Panel ID="pnloldpass" Visible="false" runat="server">
                        <tr>
<td style="width: 47%;">
   <a style="color: #000; font-size: 10px; float:right;">Pass No :</a> 
</td>
                            <td>
<asp:TextBox ID="txtpassno" runat="server" ReadOnly="true" style="margin-top: 5px;" class="form-control" ></asp:TextBox>
                            </td>
                        </tr>
                            </asp:Panel>
                         <tr>
<td style="width: 47%;">
   <a style="color: #000; font-size: 11px; float:right;">Organization Type :</a> 
</td>
                            <td>
                                 <asp:DropDownList ID="ddlagency" runat="server" style="margin-top:5px;" OnTextChanged="ddlagency_TextChanged" AutoPostBack="true" class="form-control"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
<td style="width: 47%;">
   <a style="color: #000; font-size: 11px; float:right;">Name Of Organization :</a> <a href="#" data-toggle="modal" data-target="#addangencymodal" title="Add New Organization"><span class="glyphicon glyphicon-plus"></span></a> 
</td>
                            <td>
                                <asp:DropDownList ID="ddlagencylist" runat="server" CssClass="form-control select2" style="margin-top:5px;"></asp:DropDownList>
                                
                            </td>
                        </tr>
                    </table>
                          
                      </div><!-- /.form-group -->
                  
                </div>
                   <div class="row9026" style="width: 48%;margin:5px;">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:100%">
                        <tr>
                            <td style="width: 47%;">
                               <a style="color: #000; font-size: 11px; float:right;">Pass Fee :</a> 
                            </td>
                            <td>
                                &nbsp;&nbsp; <asp:Label ID="lblamount" runat="server" ></asp:Label>
                             </td>
                        </tr>
                         <tr>
                             
                             <td>
                                 <a style="color: #000; font-size: 11px; float:right;">Fee Exemption :</a>
                             </td>
                             <td>
                                &nbsp; <asp:CheckBox ID="cbRemark" runat="server" OnCheckedChanged="cbRemark_CheckedChanged" AutoPostBack="true"></asp:CheckBox>
                                 </td>
                         </tr>
                         <tr>
                            <td style="width: 47%;">
                               <a style="color: #000; font-size: 11px; float:right;">Remark :</a> 
                            </td>
                            <td style="width: 43%;">
                             <asp:TextBox ID="txtRemark" style="margin-top:5px;" class="form-control" runat="server"></asp:TextBox>
                             </td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                  
                </div><!-- /.col -->
                <!-- /.col -->
                      </fieldset>
              </div><!-- /.row -->
                <div class="row" style="margin-left:11px; margin-right:11px;">
                     <fieldset style="border:1px solid; border-radius:5px; padding:5px;">
                        <legend >Personal Info</legend>
                <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:97%">
                       
                         <tr >
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Applicant Name :</a> 
</td>
                            <td>
                                <asp:TextBox ID="txtApplicantName" style="margin-top:5px;" class="form-control" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Designation :</a> 
</td>
                            <td>
                                <asp:TextBox ID="txtDesignation" style="margin-top:5px;" class="form-control" runat="server"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txtDesignation"
                                    CompletionInterval="100" EnableCaching="true" CompletionSetCount="10"
                                   ServiceMethod="AutoCompleteAjaxRequest" ServicePath="suggestion.asmx" MinimumPrefixLength="1" ></ajaxToolkit:AutoCompleteExtender>
                            </td>
                        </tr>
                        <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Address :</a> 
</td>
                            <td style="margin-top:5px;">
                               <asp:TextBox ID="txtAddress" class="form-control" runat="server" style="margin-top:5px;" TextMode="MultiLine"  Height="80px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                  
                </div>
                   <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:100%">
                      
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Mother's Name :</a> 
</td>
                            <td>
                                <asp:TextBox ID="txtSon" style="margin-top:5px;" class="form-control" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Birth Date :</a> 
</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBirthdate" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;  <asp:ImageButton ID="imgpopup" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgpopup" TargetControlID="txtBirthdate"
        Format="dd/MM/yyyy"/>
                                        </td>
                                    </tr>
                                </table>
                                
                                
                            </td>
                        </tr>
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Current Addresss : <asp:CheckBox ID="cbSameaddress" runat="server" AutoPostBack="true" OnCheckedChanged="cbSameaddress_CheckedChanged"></asp:CheckBox> &nbsp;</a></td>
                            <td>
                               <asp:TextBox ID="txtPresentAddress" class="form-control" runat="server" style="margin-top:5px;" TextMode="MultiLine" Height="80px"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Mobile No :</a> 
</td>
                    <td>
                        <asp:TextBox ID="txtapplicantmobile" style="margin-top:5px;" MaxLength="10" class="form-control" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                    </td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                  
                </div><!-- /.col -->
                <!-- /.col -->
                         <div class="row">
                <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:97%; height:90px;">
                       
                       <tr>
                            <td></td>
<td style="float:right; margin-top:5px; margin-right:24%;">
    <asp:Image ID="pic" runat="server"  Width="90px" Height="90px" style="border-width:0px;"></asp:Image>
    <%-- <img id="pic"  Width="90px" Height="90px" src="applicant/photo.png" style="border-width:0px;"/>--%>
    <a onclick="webcam();" href="#">Webcam</a>
    <%--<asp:LinkButton ID="lnkbutton" runat="server" OnClientClick="webcam();" >Webcam</asp:LinkButton>--%>

</td>
                        </tr>
                        <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Photo Path :</a> 
</td>
                            <td>
                                <input type="file" id="myFile" visible="false" name="myFile" runat="server"/>
                             <asp:FileUpload ID="fuPhotoPath" class="form-control" style="margin-top:5px;" runat="server" onchange="ShowImagePreview(this);" accept=".jpg"></asp:FileUpload>
                            </td>
                        </tr>

                    </table>
                       
                      </div><!-- /.form-group -->
                  
                </div>
                   <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:100%;float:right;">
                        
                        
                        <tr>
                             <td></td>
<td style="float:right; margin-top:5px; margin-right:1%;">
    <asp:Image ID="sign" runat="server"  Width="180px" Height="50px" style="border-width:0px;"></asp:Image>
   <%-- <img id="sign"  Width="180px" Height="50px" src="applicant/signature.jpg" style="border-width:0px;"/>--%>
</td>
                        </tr>
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Sign Path :</a> 
</td>
                            <td>
                             <asp:FileUpload ID="fuSign" class="form-control" style="margin-top:5px;" runat="server" onchange="ShowImagePreview1(this);" accept=".jpg"></asp:FileUpload>
                            </td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                  
                </div><!-- /.col -->
                <!-- /.col -->
              </div>
                         </fieldset>
              </div>
                
                <div class="row">
                     <fieldset style="border:1px solid; border-radius:5px; padding:5px; margin: 11px;">
                        <legend >Visit Detail</legend>
                <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:97%">
                         <tr>
                           <td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Purpose Of Visit :</a> 
</td>
                            <td>
                                <asp:TextBox ID="txtPurpaseOfvisit" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Access Building :</a> 
</td>
                            <td>
                                <asp:DropDownList ID="ddlAirport" class="form-control" style="margin-top:5px;" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                                             
                    </table>
                      </div><!-- /.form-group -->
                </div>
                   <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:100%">
                        <tr>
                            <td>
                                <table style="float: right;">
                                    <tr>
                                        <td>
<a style="color: #000; font-size: 11px; float:right;">Valid From :</a> 
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>                               

                                <table>
                                    <tr>
                                         <td>
                                             <table>
                                                 <tr>
                                                     <td>

                                                     
  <asp:TextBox ID="txtValidFromDateTime" class="form-control" style="margin-top:5px;" MaxLength="10" Width="72px" runat="server" ></asp:TextBox></td><td>
                                             <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton4" TargetControlID="txtValidFromDateTime"
        Format="dd/MM/yyyy"/></td>
                                                 </tr>
                                             </table>

                                        </td>
                                        <td>
   <a style="color: #000; font-size: 11px; margin:5px;">To</a> 
                                        </td>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td>
 <asp:TextBox ID="txtValidToDateTime" class="form-control" style="margin-top:5px;" runat="server" Width="72px" ></asp:TextBox></td>
                                                    <td>
                                               <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton7" TargetControlID="txtValidToDateTime"
        Format="dd/MM/yyyy"/></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Access Area :</a> 
</td>   
                            <td>
                              
                               <asp:DropDownList ID="ddlTerminals" class="form-control" style="margin-top:5px;" runat="server" ></asp:DropDownList>
                            </td>
   
                        </tr>
                        
                    </table>
                      </div><!-- /.form-group -->
                  
                </div><!-- /.col -->
                    <div style="width:94%; height:300px; margin-top:65px; margin-left:auto; margin-right:auto;" >
                        <asp:GridView ID="DGVareazone" runat="server" Visible="true" AlternatingRowStyle-Wrap="true" AutoGenerateColumns="false">
                             <Columns>
                                <asp:TemplateField>
                                 <ItemTemplate>
                <asp:CheckBox ID="chkRow" runat="server" TextAlign="Right"/>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:BoundField DataField="shortcut" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="7%"/> 
                <asp:BoundField DataField="Name" HeaderText="Area/Zones" ItemStyle-Width="90%" />
                
                            </Columns>
                        </asp:GridView>
                        
                    </div>
                       </fieldset>
                <!-- /.col -->
              </div>
                <asp:Panel ID="pnlverification" runat="server">
                <div class="row" style="margin-top:20px;">
                     <fieldset style="border:1px solid; border-radius:5px; padding:5px; margin: 11px;">
                        <legend >Verification</legend>

                <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                              <ContentTemplate> 
                    <table style="width:100%">
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Verification Type :</a> 
</td>
                            <td>
                                  

                                
                               <asp:DropDownList ID="ddlPoliceVerificationType" class="form-control" style="margin-top:5px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPoliceVerificationType_SelectedIndexChanged"></asp:DropDownList>
                          
                                       </td>
                        </tr>
                        
                         <tr>
<td style="width: 47%;">
   <a style="color: #000; font-size: 11px; float:right;">Name As Per Verification :</a> 
</td>
                            <td>
                               <asp:TextBox ID="txtNameAsPerPoliceVerification" class="form-control" style="margin-top:5px;" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Identity Type :</a> 
</td>
                            <td>
                                 <asp:TextBox ID="txtidentityname" class="form-control" style="margin-top:5px;" runat="server" ></asp:TextBox>
                              
                            </td>
                        </tr>
                    </table>
                       </ContentTemplate>
                             </asp:UpdatePanel>
                      </div><!-- /.form-group -->
                  
                </div>
                    <div class="col-md-6" >
                           <div class="form-group">
                    <table style="width:100%">
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Verfication Date :</a> 
</td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                 <asp:TextBox ID="txtPoliceVerificationdate" class="form-control" style="margin-top:5px;" runat="server"  ></asp:TextBox></td>
                                        <td>
<asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/img/calendar.png" />
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton8" TargetControlID="txtPoliceVerificationdate"
        Format="dd/MM/yyyy"/>
                                        </td>
                               </tr>
                                </table>
                            </td>
                        </tr>
                        
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Verification Document :</a> 
</td>
                            <td>
                                <asp:FileUpload ID="fuDocument" class="form-control" style="margin-top:5px;" runat="server" accept=".pdf"></asp:FileUpload>
                            </td>
                        </tr>
                        <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Identity No. :</a> 
</td>
                            <td>
                                 <asp:TextBox ID="txtidentityno" class="form-control" style="margin-top:5px;" runat="server" ></asp:TextBox>
                              
                            </td>
                        </tr>
                        </table>
                               </div>
                        </div>
                   <!-- /.col -->
                <!-- /.col -->
                         </fieldset>
              </div>
                </asp:Panel>

                <asp:Panel ID="pnl" Visible="false" runat="server">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>
                <div class="row">
                    <table style="margin-left:auto; margin-right:auto;">
                        <tr>
                            <td>
                                Self Esct <asp:CheckBox ID="cbselfesct" runat="server"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>
                    
                    <div id="selfesct"> 
                     <fieldset style="border:1px solid; border-radius:5px; padding:5px; margin: 11px;">
                        <legend >Esct Person</legend>

                <div class="col-md-6" >
                     <!-- /.form-group -->
                  <div class="form-group">
                    <table style="width:100%">
                                   
                         <tr>
<td style="width: 53%;">
   <a style="color: #000; font-size: 11px; float:right;">Valid Pass No. :</a> 
</td>
                            <td>
                         

                                
                                <asp:TextBox ID="txt" class="form-control" style="margin-top:5px;"  runat="server"></asp:TextBox> 
                                       </td>
                        </tr>                   
                         <tr>
        <td style="width: 47%;">
   <%--<a style="color: #000; font-size: 11px; float:right;">Name As Per Verification :</a> --%>
</td>
                            <td>
                                <br />
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                 <asp:Button ID="btncheck" style="width:56%;"  CssClass="btn btn-block btn-primary btn-flat" runat="server" OnClick="btncheck_Click" Text="Check"></asp:Button>
                                        </td>
                                        <td>
                                             <asp:Button ID="btnedit" style="width:80%;"  CssClass="btn btn-block btn-primary btn-flat" runat="server" OnClick="btnedit_Click" Text="Edit"></asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                </div>
                    <div class="col-md-6" >
                           <div class="form-group">
                    <table style="width:100%">
                         <tr>
<td>
   <a style="color: #000; font-size: 11px; float:right;">Name Of Pass Holder :</a> 
</td>
                            <td>
                                <asp:TextBox ID="TextBox1" class="form-control" style="margin-top:5px;" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                             <td>

                             </td>
<td style="width: 53%;"><br />
   
    <asp:Button ID="btnaddesct" style="width:50%;"  CssClass="btn btn-block btn-primary btn-flat" runat="server" OnClick="btnaddesct_Click" Text="Add Esct By"></asp:Button>

<%--   <a style="color: #000; font-size: 11px; float:right;">Verification Document :</a> --%>
</td>
                            <td>
                            </td>
                        </tr>
                        </table>
                               </div>
                        </div>
                   <!-- /.col -->
                <!-- /.col -->
                         </fieldset>
                        </div>
              </div>
          </ContentTemplate>
  </asp:UpdatePanel>
                </asp:Panel>
                <div class="row">
                <div class="col-md-6">
                     <!-- /.form-group -->
                  <div class="form-group">
                      </div><!-- /.form-group -->
                  
                </div>
                   <div class="col-md-6" style="width: 70%; float: right;">
                     <!-- /.form-group -->
                  <div class="form-group"><br />
                    <table style="width:100%">
                        <tr>
                            <%--<td style="width: 115px;">
                                BCAS Approval : 
                            </td>--%>
                            <td>
                                <asp:CheckBox ID="ckbcas" Visible="false" runat="server"></asp:CheckBox>
                            </td>
<td>
   <asp:Button ID="btninsertPass" style="width:70%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btninsertPass_Click" runat="server" Text="Save" OnClientClick="check();"></asp:Button>
</td>
                            <td>
   <asp:Button ID="btnforapprove" style="width:80%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnforapprove_Click" runat="server" Text="Save & Send For approval" Visible="false" OnClientClick="return :javascript check()"></asp:Button>
</td>
   <td>
   <asp:Button ID="btnclear" style="width:70%;"  CssClass="btn btn-block btn-primary btn-flat" OnClick="btnclear_Click" runat="server" Text="Clear"></asp:Button>
</td>
                        </tr>
                    </table>
                      </div><!-- /.form-group -->
                  
                </div><!-- /.col -->
                <!-- /.col -->
              </div>
                
            </div><!-- /.box-body -->
          </div><!-- /.box -->

          <!-- /.row -->

            
              </section>
        </asp:Panel> 
   
</asp:Content>
