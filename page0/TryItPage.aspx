<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItPage.aspx.cs" Inherits="Project5.TryItForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Try It Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1><asp:Label ID="welcomeLabel" runat="server" Text="SVC Services and DLL Try It Page"></asp:Label></h1>

            <br /><br /><br /><br /><br /><br /><br />
            <h3>Use the search bar below to find free WSDL services using the Google Search Engine API.</h3>
            <h4>Examples: "list of wsdl services", "calculator web service", "web services".</h4>
            <asp:TextBox ID="searchInput" runat="server" Width="600px" Height="20px" style="margin-top: 0px"></asp:TextBox>
            <asp:Button ID="searchButton" runat="server" Text="Search" Height="26px" Width="65px" OnClick="searchButton_Click" />
            <h3>Results:</h3>
            <asp:Label ID="searchResults" runat="server" Text=""></asp:Label>
            <br /><br />
            <h3>Copy and Paste the example URL or any WSDL service address to return their Operations.</h3>
            <h4>Example: http://webstrar25.fulton.asu.edu/Page1/Project5Services.svc?wsdl</h4>
            <asp:TextBox ID="operationsInput" runat="server" Width="600px" Height="20px"></asp:TextBox>
            <asp:Button ID="operationsButton" runat="server" Text="Go" Width="65px" Height="26px" OnClick="operationsButton_Click" />
            <h3>Results:</h3>
            <asp:Label ID="operationResults" runat="server" Text=""></asp:Label>
            <br /><br />
            <h3>Enter a password to hash using the SHA256 algorithm</h3>
            <asp:TextBox ID="hashPassInput" runat="server" Width="600px" Height="20px"></asp:TextBox>
            <asp:Button ID="hashButton" runat="server" Text="Hash" Width="65px" Height="26px" OnClick="hashButton_Click" />
            <h3>Hashed Password:</h3>
            <asp:Label ID="hashedPass" runat="server" Text=""></asp:Label>
            <br /><br /><br />
        </div>
    </form>
</body>
</html>
