using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*

    Mathew MacMillan
    CSE 445

    Web Form - Staff Page

 */

namespace Project5
{
    public partial class StaffForm : System.Web.UI.Page
    {

        //
        // Checks if valid Cookies exist, if not, redirects to Staff Login Page
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie myCookies = Request.Cookies["myCookieId2"];
            if (myCookies == null || (myCookies["Staff"] == ""))
            {

                Response.Redirect("http://webstrar25.fulton.asu.edu/page0/StaffLoginPage.aspx");

            }
            else
            {

                welcomeLabel.Text = "Signed In as " + myCookies["Staff"];

            }

        }

        //
        // Sign out button that forces the current Cookie to expire
        //
        protected void signoutButton_Click(object sender, EventArgs e)
        {

            if (Request.Cookies["myCookieId2"] != null)
            {

                Response.Cookies["myCookieId2"].Expires = DateTime.Now.AddDays(-1);

            }

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/Staff.aspx");

        }

        //
        // Navigation button to view the list of Staff in a new window
        //
        protected void staffButton_Click(object sender, EventArgs e)
        {

            Response.Redirect("http://webstrar25.fulton.asu.edu/page0/StaffList.aspx");

        }
    }
}