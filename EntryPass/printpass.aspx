<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printpass.aspx.cs" Inherits="EntryPass.printpass" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlrdlc" runat="server">
      <div style="margin: auto">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <rsweb:ReportViewer ID="ReportViewer1" runat="server" BorderColor="Silver" BorderStyle="Double" Height="600px" Width="900px"></rsweb:ReportViewer>
             </div>
            </asp:Panel>
        <asp:Panel ID="pnlerror" runat="server">
            <table style="margin-left:auto; margin-right:auto; margin-top:10%;">
                <tbody>
                    <tr>
                        <td>
                             <div>
                <h1>
                    Error 404 ..Page Not Found
                </h1>
            </div>
            <h7>
                <p>
                    Close This Windows And Try Agian...!!!
                </p>
            </h7>
                        </td>
                    </tr>
                </tbody>
            </table>

        </asp:Panel>
    </form>
</body>
</html>
