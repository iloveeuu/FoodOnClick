<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SendMailExample.aspx.vb" Inherits="FoodOnClick.SendMailExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="btnSendMail" Text="Send Mail" OnClick="btnSendMail_Click"/>
        </div>
    </form>
</body>
</html>
