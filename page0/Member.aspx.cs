using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*

    Mathew MacMillan
    CSE 445

    Web Form - Member Page

 */

namespace Project5
{
    public partial class MemberForm : System.Web.UI.Page
    {

        //
        // Checks if valid Cookies exist, if not, redirects to Member Login Page
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            addToListButton.Visible = false;
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if(myCookies == null || (myCookies["Member"] == ""))
            {

                Response.Redirect("http://webstrar25.fulton.asu.edu/page0/LoginPage.aspx");

            }
            else
            {

                welcomeLabel.Text = "Signed In as " + myCookies["Member"];

            }

        }

        //
        // Sign out button that forces the current Cookie to expire
        //
        protected void signoutButton_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["myCookieId"] != null)
            {

                Response.Cookies["myCookieId"].Expires = DateTime.Now.AddDays(-1);

            }

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/Member.aspx");

        }

        //
        // Implementation of the WsdlAddress/WsdlDiscovery service offered within the Member Page
        // returns WSDL URLs 
        //
        protected void searchButton_Click(object sender, EventArgs e)
        {

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();

            string theSearch = searchInput.Text;

            string[] results = proxy.SearchForWsdl(theSearch);

            for (int i = 0; i < results.Length; i++)
            {

                searchResults.Text += results[i] + "<br /r>" + "<br /r>";

            }

            proxy.Close();

        }

        //
        // Implementation of the WsOperations service offered within the Member Page
        // returns WSDL operations within a URL location
        //
        protected void operationsButton_Click(object sender, EventArgs e)
        {

            addToListButton.Visible = true;
            listLabel.Text = "";
            operationResults.Text = "";
            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();

            string theUrl = operationsInput.Text;

            string[] results = proxy.WsOperations(theUrl);

            for (int i = 0; i < results.Length; i++)
            {

                operationResults.Text += "Operation " + (i + 1).ToString() + ":" + "<br /r>" + results[i] + "<br /r>" + "<br /r>";

            }

            proxy.Close();

        }

        //
        // Implementation of a helper service, AddToList, which adds details of the returned WSDL Operations
        // into an XML file to be returned later when navigating to "My List" withing the Member Page
        //
        protected void addToListButton_Click(object sender, EventArgs e)
        {

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();

            string theUrl = operationsInput.Text;

            string[] names = proxy.WsOperationNames(theUrl);
            string[] inputs = proxy.WsOperationInput(theUrl);
            string[] returnTypes = proxy.WsOperationReturn(theUrl);

            string memberList = "";

            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if (myCookies == null || (myCookies["Member"] == ""))
            {

                Response.Redirect("http://webstrar25.fulton.asu.edu/page0/LoginPage.aspx");

            }
            else
            {

                memberList = myCookies["Member"] + "List";

            }

            proxy.AddToList(memberList, theUrl, names, inputs, returnTypes);

            listLabel.Text = myCookies["Member"] + "'s List Updated!";

            proxy.Close();

        }

        //
        // Navigation button to view the user's list in a new window
        //
        protected void myListButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/MemberList.aspx");

        }
    }
}