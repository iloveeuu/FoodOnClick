<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Masterpage.Master" CodeBehind="restaurantUploadDocuments.aspx.vb" Inherits="FoodOnClick.restaurantUploadDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <div class="signUpMerchant-page" runat="server">
        <h3>Upload Restaurant Documents</h3>
        <br />
        <hr />
        <br />
        <table id="tableStyle">
            <tr>
                <td>Restaurant Name:
                </td>
                <td>
                    <asp:TextBox ID="txtResName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Description:
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>

                <td>Upload Restaurant Logo:
                </td>
                <td>

                    <input type="file" id="File1" runat="server" />

                    <%--<asp:FileUpload ID="fuPhotoRestaurant" runat="server" />--%>
                </td>
            </tr>
            <tr>
                <td>Upload Business License:
                </td>
                <td>
                    <input type="file" id="File2" runat="server" />
                </td>
            </tr>

            <tr>
                <td>Upload Halal License:
                </td>
                <td>
                    <input type="file" id="File3" runat="server" />
                </td>
            </tr>
       <%--     <tr>

                <td>
                    <br />
                    <asp:Button ID="btnUploadDocuments" CssClass="Btn" runat="server" Text="Submit" />
                    <asp:Button ID="Button1" CssClass="Btn" runat="server" Text="Cancel" />

                </td>

            </tr>--%>

             <tr>
                <td colspan=" 2">
                    <br />
                    <asp:Button ID="btnUploadDocuments"  runat="server" Text="Submit" Style ="width: 100%" />
                </td>
            </tr>
<%--            <tr>
                <td colspan="2">
                    <asp:Button ID="cancelBtn"  runat="server" Text="Cancel" Style ="width: 100%" />
                </td>
                <td></td>
            </tr>--%>
        
            <%--<tr>

                <td>
                    <INPUT type=file id=File5 name=File5 runat="server" />

                    <br />
                    <input type="submit" id="Submit1" value="Upload" runat="server" />
                </td>

            </tr>--%>
        </table>
    </div>
</asp:Content>
