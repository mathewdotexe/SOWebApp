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

    Web Form - Staff List Page

 */

namespace Project5
{
    public partial class StaffListForm : System.Web.UI.Page
    {

        //
        // Checks if valid Cookies exist, if not, redirects to Staff Login Page
        // if Cookie is valid, call the service LoadStaff, which reads the Staff.XML
        // file and returns the Staff usernames an admin has saved from within the Staff Page
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            string staffList = "";
            HttpCookie myCookies = Request.Cookies["myCookieId2"];
            if (myCookies == null || (myCookies["Staff"] == ""))
            {

                Response.Redirect("http://webstrar25.fulton.asu.edu/page0/StaffLoginPage.aspx");

            }
            else
            {

                staffList = "Staff";

            }

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();

            string[] theResults = null;

            theResults = proxy.LoadStaff(staffList);

            myListResults.DataSource = theResults;
            myListResults.DataBind();

            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");

            listFileLabel.Text = "Staff.xml";
            myListLabel.Text = " loaded at ";
            appDataPath.Text = fLocation;

            proxy.Close();

        }

        //
        // Back button navigating to the Staff Page
        //
        protected void backButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/Staff.aspx");

        }
    }
}