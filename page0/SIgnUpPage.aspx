<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SIgnUpPage.aspx.cs" Inherits="Project5.SignUpForm" %>
<%@ Register TagPrefix = "signup" TagName = "SignUpControl" src= "SignUpControls.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
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

                 <h3><asp:Label ID="signUpLabel" runat="server" Text="Please Fill Out the Form to Sign Up"></asp:Label></h3>
                <br />
                <signup:SignUpControl ID = "mySignUp" runat="server" />

            </div>

        </div>

    </form>
</body>
</html>
