<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project5.DefaultForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
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

        table, th, td {
             border:1px solid black;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="topnav">
                <a class="active" href="http://webstrar25.fulton.asu.edu/page0/Default.aspx">Home</a>
                <a href="http://webstrar25.fulton.asu.edu/page0/Member.aspx">Member Page</a>
                <a href="http://webstrar25.fulton.asu.edu/page0/Staff.aspx">Staff Page</a>
            </div>

            <br />
            <h1>Welcome!</h1>

            <br /><br /><br /><br />
            <h3><asp:Label ID="appLabel" ForeColor="Blue" runat="server" Text="Application Details:"></asp:Label></h3>
            <h3>Once Signed Up and Signed In via the Member Page, this application lets users search for available WSDL services online using the Google Search API.</h3>
            <h3>The search results populate on the page as WSDL address URLs, the user can then Copy/Paste the URLs into a textbox to return the Operation Names, Input Parameter Types, and Return Types of the service located at that address.</h3>
            <h3>The Operation results populate on the page as well, then users can choose to add the results to an XML file represented in a separate page named "My List". Users can navigate to this page via button at the top of the Member Page.</h3>
            <h3><asp:Label ID="infoLabel" ForeColor="Blue" runat="server" Text="Additional Info:"></asp:Label></h3>
            <h3>Once Signed In as a Member or Staff, a Cookie is generated and expires in 5 minutes. You can also clear the Cookie by using the "Sign Out" button.</h3>
            <h3 ><asp:Label ID="testingLabel" ForeColor="Blue" runat="server" Text="Testing:"></asp:Label></h3>
            <h3>TA's can test the application by clicking the Member tab at the top of this page, where it will ask them to Login. For testing purposes, TA's will need to click the "Sign Up" link below the Sign In field to add their crudentials to the Member.xml file. After this process, the TA will be able to Login as a Member.</h3>
            <h3>TA's can test the Staff functionallity by clicking the Staff tab at the top of this page, then Signing In with the crudentials mentioned in the Project Document.</h3>
            <h4><asp:Label ID="userLabel" ForeColor="Blue" runat="server" Text="User Name: TA"></asp:Label></h4>
            <h4><asp:Label ID="passLabel" ForeColor="Blue" runat="server" Text="Password: Cse44598!"></asp:Label></h4>
            <table style="width:100%">
              <tr>
                <th>Application and Components Summary Table</th>
              </tr>
              <tr>
                <th>The Application is Deployed at: <a href="http://webstrar25.fulton.asu.edu/page0/Default.aspx">http://webstrar25.fulton.asu.edu/page0/Default.aspx</a></th>
              </tr>
              <tr>
                <th>Team 25: Mathew MacMillan 100%</th>
              </tr>
            </table>
            <table style="width:100%">
              <tr>
                <th>Provider Name</th>
                <th>Page and Component Type, e.g., aspx, DLL, SVC, etc.</th>
                <th>TryIt Link</th>
                <th>Component description: What does the component do? What are input/parameter and output/return value?</th>   
                <th>Actual resources and methods used to implement the component and where this component is used.</th>    
              </tr>
             <tr>
                <th>Mathew MacMillan</th>
                <th>Aspx Page and Server Control</th>
                <th><a href="http://webstrar25.fulton.asu.edu/page0/Default.aspx" target="_blank">TryIt</a> by navigating through the pages linked to Default.aspx</th>
                <th>The public Default page that call and link all other pages.</th> 
                <th>GUI design and C# code behind GUI.</th>    
              </tr>
             <tr>
                <th>Mathew MacMillan</th>
                <th>User Control</th>
                <th>Member: <a href="http://webstrar25.fulton.asu.edu/page0/Member.aspx" target="_blank">TryIt</a> by using the Member Login Page.<br/><br/>Staff: <a href="http://webstrar25.fulton.asu.edu/page0/Staff.aspx" target="_blank">TryIt</a> by using the Staff Login Page.<br/><br/>Sign Up: <a href="http://webstrar25.fulton.asu.edu/page0/SignUpPage.aspx" target="_blank">TryIt</a> by using the Sign Up Page<br/><br/>Admin Controls are used while signed in as a Staff member to store new User Names and Passwords.</th>
                <th>Login Page Controls, Sign Up Controls, Admin Controls, Staff Login Controls.</th>   
                <th>C# Code behind GUI. Linked to their respective pages.</th>    
              </tr>
             <tr>
                <th>Mathew MacMillan</th>
                <th>XML Files</th>
                <th>Member Login: Member.xml: <a href="http://webstrar25.fulton.asu.edu/page0/Member.aspx" target="_blank">TryIt</a> reads the xml file and logs you in if your crudentials are valid.<br/><br/>Sing Up: Member.xml: <a href="http://webstrar25.fulton.asu.edu/page0/SignUpPage.aspx" target="_blank">TryIt</a> writes to the xml file, adding your crudentials then redirecting you to the Login Page.<br/><br/>Staff Login: Staff.xml: <a href="http://webstrar25.fulton.asu.edu/page0/Staff.aspx" target="_blank">TryIt</a> reads the xml file and logs you in if your crudentials are valid.<br/><br/>[Member]List.xml is used by logging in as a Member and navigating to "My List".</th>
                <th>Member.xml stores Member User Name and their hashed Password.<br/><br/>Staff.xml stores Staff User Name and their hashed Password.<br/><br/>[Member]List.xml is used within the Service located in the Member.aspx page that stores data for "My List", acts like a "My Cart" module.</th>
                <th>Linked to the Member and Staff Login Pages and the hashing function.</th>    
              </tr>
             <tr>
                <th>Mathew MacMillan</th>
                <th>DLL</th>
                <th><a href="http://webstrar25.fulton.asu.edu/page0/TryItPage.aspx" target="_blank">TryIt</a></th>
                <th>Hashing function:<br/>Input: String<br/>Output: String</th>   
                <th>Use library class and local component to implement this library function. It is used in the saving data into XML file.</th>    
              </tr>
              <tr>
                <th>Mathew MacMillan</th>
                <th>Cookies</th>
                <th><a href="http://webstrar25.fulton.asu.edu/page0/Member.aspx" target="_blank">TryIt</a> by logging in as a Member, closing the page, then navigating back to the Member Page.<br/><br/>Functionallity is the same for the Staff Page.</th>
                <th>Stores "Member" and "Staff" to 2 different Cookies, can be cleared via "Log Out" or expires in 5 minutes.</th>   
                <th>GUI design and C# code behind GUI using HTTP cookies library. They are linked to the Member Login Page and Staff Login Page.</th>  
              </tr>
              <tr>
                <th>Mathew MacMillan</th>
                <th>SVC Service</th>
                <th><a href="http://webstrar25.fulton.asu.edu/page0/TryItPage.aspx" target="_blank">TryIt</a></th>
                <th>WsOperations<br/>Input: string<br/>Output: string[]</th>   
                <th>Utilizes Xml and Description system libraries to scan for operation names, input messages, and output messages to return to the user.</th>  
              </tr>
              <tr>
                <th>Mathew MacMillan</th>
                <th>SVC Service</th>
                <th><a href="http://webstrar25.fulton.asu.edu/page0/TryItPage.aspx" target="_blank">TryIt</a></th>
                <th>WsdlAddress/WsdlDiscovery<br/>Input: string<br/>Output: string[]</th>   
                <th>Utilizes Google Custom Search API to return URLs containing keywords. Then further sorts the URLs using HtmlAgilityPack libraries that return href values from Html pages that contain certain WSDL address keywords.</th>  
              </tr>
            </table>
            <br /><br /><br />
        </div>
    </form>
</body>
</html>

