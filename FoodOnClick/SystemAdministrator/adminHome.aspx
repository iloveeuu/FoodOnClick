<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="" Inherits="FoodOnClick.signUp" %>

<!DOCTYPE html>
<html lang="en" dir="ltr">
<head runat="server">
    <meta charset="utf-8">
    <title>Food On Click</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Sharp"
        rel="stylesheet">
    <link href="./stylecss.css" rel="stylesheet" />

</head>
<body>
    <div class="container">
        <aside>
            <div class="top">
                <div class="logo">
                    <img src="test.jpg" />
                    <h2>Food On <span class="danger">Click</span></h2>
                </div>
                <div class="close" id="close-btn">
                    <span class="material-icons-sharp">close</span>
                </div>
            </div>

            <div class="sidebar">
                <a href="adminHome.aspx" class="active">
                    <span class="material-icons-sharp">home</span>
                    <h3>Dashboard</h3>
                </a>
                <a href="adminManageApproval.aspx">
                    <span class="material-icons-sharp">person_add_alt</span>
                    <h3>Manage Approvals</h3>
                    <span class="message-count">3</span>

                </a>
                <a href="adminManageOrders.aspx">
                    <span class="material-icons-sharp">receipt_long</span>
                    <h3>Manage Orders</h3>
                </a>
                <a href="adminManageFeedbacks.aspx">
                    <span class="material-icons-sharp">reviews</span>
                    <h3>Manage Feedbacks</h3>
                </a>
                <a href="adminManageSupportIssues.aspx">
                    <span class="material-icons-sharp">live_help</span>
                    <h3>Support Issues</h3>
                    <span class="message-count">24</span>
                </a>
                <a href="#">
                    <span class="material-icons-sharp">insights</span>
                    <h3>Generate Reports</h3>
                </a>
                <a href="#">
                    <span class="material-icons-sharp">logout</span>
                    <h3>Logout</h3>
                </a>
            </div>
        </aside>
        <!----------------END OF ASIDE BAR --------------------->
        <div class="right">
            <div class="top">
                <button id="menu-btn">
                    <span class="material-icons-sharp">menu </span>
                </button>
                <div class="profile">
                    <div class="info">
                        <p><b>Username</b></p>
                        <small class="text-muted">Administrator</small>
                        <p><small>Logout</small></p>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src ="./admin.js"> </script> 
</body>
</html>