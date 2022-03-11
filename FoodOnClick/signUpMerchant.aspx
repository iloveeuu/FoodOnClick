<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="signUpMerchant.aspx.vb" Inherits="FoodOnClick.signUpMerchant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <h1>Food On Click</h1>
    <h3>Sign Up</h3>
    <br />
    <hr />
    <br />
        <table id="tableStyle">
            <tr>
                <td>Upload Restaurant Photo/Logo:
                </td>
                <td>
                    <asp:FileUpload ID="fuPhotoRestaurant" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Upload Restaurant Prove of Business:
                </td>
                <td>
                    <asp:FileUpload ID="fuProveBusiness" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSignUpMerchant" runat="server" Text="Sign Up" />
                </td>
                <td></td>
            </tr>
        </table>
</asp:Content>
