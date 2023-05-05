using Project5Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*

    Mathew MacMillan
    CSE 445

    User Controls - Controls for the Staff Page

 */

namespace Project5
{
    public partial class LoginController : System.Web.UI.UserControl
    {

        //
        // Sign Up redirect if user doesn't have an account
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            registerLabel.Text = "Don't have an account? <a href = 'SignUpPage.aspx'>Sign Up</a>";

        }

        //
        // Member login using a service to read the Member.xml file
        // if Member exists with correct User Name and Password, login and create a Cookie
        //
        // password is hashed using my defined library
        //
        protected void loginButton_Click(object sender, EventArgs e)
        {

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();
            HashPassword myHash = new HashPassword();

            if (userNameInput.Text == "" || passwordInput.Text == "")
            {

                responseLabel.Text = "Error, One or More Required Fields are Empty.";

            }
            else
            {

                string hashPass = myHash.GetHashString(passwordInput.Text);
                if(proxy.MemberExists(userNameInput.Text) == true)
                {

                    if(proxy.MemberExists(hashPass) == true)
                    {

                        responseLabel.Text = "Success!";

                        HttpCookie myCookies = new HttpCookie("myCookieId");
                        myCookies["Member"] = userNameInput.Text;
                        myCookies.Expires = DateTime.Now.AddMinutes(5);

                        Response.Cookies.Add(myCookies);

                        Response.Redirect("http://webstrar25.fulton.asu.edu/page0/Member.aspx");

                    }
                    else
                    {

                        responseLabel.Text = "Error, Incorrect Password.";

                    }

                }
                else
                {

                    responseLabel.Text = "Error, Member Does Not Exist.";

                }

            }

            proxy.Close();

        }
    }
}