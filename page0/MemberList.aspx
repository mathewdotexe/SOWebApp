<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Project5.ListForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My List</title>
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

            <br />
            <h1><asp:Label ID="listLabel" runat="server" Text=""></asp:Label></h1>
            <asp:Button ID="backButton" runat="server" Text="Back" Width="80px" Height="26px" OnClick="backButton_Click" />            
            <br /><br /><br />
            <h3>Operation Details:</h3>
            <asp:ListBox ID="myListResults" runat="server" Height="502px" Width="635px"></asp:ListBox>
            <br /><br />
            <h3><asp:Label ID="listFileLabel" runat="server" ForeColor="Lime"></asp:Label> <asp:Label ID="myListLabel" runat="server" Text=""></asp:Label> <asp:Label ID="appDataPath" runat="server" ForeColor="Lime"></asp:Label></h3>

        </div>
    </form>
</body>
</html>
