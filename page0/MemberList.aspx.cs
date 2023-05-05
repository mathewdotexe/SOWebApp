using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*

    Mathew MacMillan
    CSE 445

    Web Form - Member List

 */

namespace Project5
{
    public partial class ListForm : System.Web.UI.Page
    {

        //
        // Checks if valid Cookies exist, if not, redirects to Member Login Page
        // if Cookie is valid, call the service LoadMyList, which reads the Member's
        // XML and returns the Operation details they saved within the Member Page
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            string memberList = "";
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if (myCookies == null || (myCookies["Member"] == ""))
            {

                Response.Redirect("http://webstrar25.fulton.asu.edu/page0/LoginPage.aspx");

            }
            else
            {

                listLabel.Text = myCookies["Member"] + "'s List";
                memberList = myCookies["Member"] + "List";

            }

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();

            string[] theResults = null;

            theResults = proxy.LoadMyList(memberList);

            myListResults.DataSource = theResults;
            myListResults.DataBind();

            string fileName = myCookies["Member"] + "List.xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");

            listFileLabel.Text = fileName;
            myListLabel.Text = " loaded at ";
            appDataPath.Text = fLocation;

            proxy.Close();

        }

        //
        // Back button navigating to the Member Page
        //
        protected void backButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/Member.aspx");

        }
    }
}