<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Project5.StaffForm" %>
<%@ Register TagPrefix = "staffSignup" TagName = "AdminControl" src= "AdminControls.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Page</title>
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
                <a href= "http://webstrar25.fulton.asu.edu/page0/Member.aspx">Member Page</a>
                <a class="active" href="http://webstrar25.fulton.asu.edu/page0/Staff.aspx">Staff Page</a>
            </div>

            <br />
            <h1><asp:Label ID="welcomeLabel" runat="server" Text=""></asp:Label></h1>
            <asp:Button ID="signoutButton" runat="server" Text="Sign Out" Width="80px" Height="26px" OnClick="signoutButton_Click" />
            <asp:Button ID="staffButton" runat="server" Text="View Staff" style="margin-left: 20px" Width="80px" Height="26px" OnClick="staffButton_Click" />
            <br /><br /><br /><br /><br /><br /><br />
            <h3><asp:Label ID="adminLabel" runat="server" ForeColor="Red" Text="You are Signed In as Administrator"></asp:Label></h3>
            <h4><asp:Label ID="fillOutLabel" runat="server" Text="Fill Out the Form to Add Crudentials"></asp:Label></h4>
            <staffSignup:AdminControl ID = "mySignUp" runat="server" />

        </div>
    </form>
</body>
</html>
