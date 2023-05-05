<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Project5.MemberForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Page</title>
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
             <h1><asp:Label ID="welcomeLabel" runat="server" Text=""></asp:Label></h1>
             <asp:Button ID="signoutButton" runat="server" Text="Sign Out" OnClick="signoutButton_Click" Width="80px" Height="26px" />
             <asp:Button ID="myListButton" runat="server" Text="My List" style="margin-left: 20px" Width="80px" Height="26px" OnClick="myListButton_Click" />
             <br /><br /><br /><br /><br /><br /><br />
             <h3>Use the search bar below to find free WSDL services using the Google Search Engine API.</h3>
             <h4>Examples: "list of wsdl services", "calculator web service", "web services".</h4>
             <asp:TextBox ID="searchInput" runat="server" Width="600px" Height="20px" style="margin-top: 0px"></asp:TextBox>
             <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" Height="26px" Width="65px" />
             <h3>Results:</h3>
             <asp:Label ID="searchResults" runat="server" Text=""></asp:Label>

             <br /><br />
             <h3>Copy and Paste a URL from the list above to return their Operations. If you are satisfied with the results, use the "Add to List" button to update the results in your "My List" page.</h3>
             <h4>Example: http://webstrar25.fulton.asu.edu/Page1/Project5Services.svc?wsdl</h4>
             <asp:TextBox ID="operationsInput" runat="server" Width="600px" Height="20px"></asp:TextBox>
             <asp:Button ID="operationsButton" runat="server" Text="Go" Width="65px" OnClick="operationsButton_Click" Height="26px" />
             <h3>Results:</h3>
             <asp:Label ID="operationResults" runat="server" Text=""></asp:Label>
             <br />
             <h3><asp:Button ID="addToListButton" runat="server" Text="Add to List" OnClick="addToListButton_Click" Width="125px" /> <asp:Label ID="listLabel" runat="server" Text=""></asp:Label></h3>
            <br /><br /><br />
        </div>
    </form>
</body>
</html>
