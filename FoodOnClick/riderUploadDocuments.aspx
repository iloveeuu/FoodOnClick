<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="riderUploadDocuments.aspx.vb" Inherits="FoodOnClick.riderUploadDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="signUpMerchant-page" runat="server">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">

        <h3>Upload Rider NRIC</h3>
        <br />
        <hr />
        <br />
        <table id="tableStyle">
  
            <tr>
                <td>Upload NRIC Image:
                </td>
                <td>
                    <input type="file" id="File1" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan=" 2">
                    <br />
                    <asp:Button ID="btnUploadDocuments" runat="server" Text="Submit" Style="width: 100%" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
