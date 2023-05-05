<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project5.LoginForm" %>
<%@ Register TagPrefix = "login" TagName = "LoginControl" src= "LoginControls.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Login</title>
    <style>
        body {
          margin: 0;
          font-family: Arial, Helvetica, sans-serif;
        }

        .topnav {
          overflow: hidden;
          background-color: #333;
        }

        .topnav a {
          float: left;
          color: #f2f2f2;
          text-align: center;
          padding: 14px 16px;
          text-decoration: none;
          font-size: 17px;
        }

        .topnav a:hover {
          background-color: #ddd;
          color: black;
        }

        .topnav a.active {
          background-color: #04AA6D;
          color: white;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div>

            <div class="topnav">
                    <a href="http://webstrar25.fulton.asu.edu/page0/Default.aspx">Home</a>
                    <a class="active" href= "http://webstrar25.fulton.asu.edu/page0/Member.aspx">Member Page</a>
                    <a href="http://webstrar25.fulton.asu.edu/page0/Staff.aspx">Staff Page</a>
            </div>
            <div>

                <h3><asp:Label ID="welcomeLabel" runat="server" Text="Please Login to Continue to Member Page"></asp:Label></h3>
                <br />
                <login:LoginControl ID = "myLogin" runat="server" />

            </div>



        </div>

    </form>
</body>
</html>
