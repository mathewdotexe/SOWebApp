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
    public partial class AdminController : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //
        // Admin registration using a service to read and write to the Staff.xml file
        // password is hashed using my defined library
        //
        protected void registerButton_Click(object sender, EventArgs e)
        {

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();
            HashPassword myHash = new HashPassword();

            if (userNameLabel.Text == "" || passwordInput.Text == "" || confirmPassLabel.Text == "")
            {

                returnLabel.Text = "Error, One or More Required Fields are Empty.";

            }
            else if (passwordInput.Text != confirmPassInput.Text)
            {

                returnLabel.Text = "Error, Passwords Do Not Match.";

            }
            else
            {

                if (proxy.StaffExists(userNameInput.Text) != true)
                {

                    string hashPass = myHash.GetHashString(passwordInput.Text);
                    proxy.AddStaffMember(userNameInput.Text, hashPass);

                    returnLabel.Text = "Staff Member Added!";

                    userNameInput.Text = "";

                }
                else
                {

                    returnLabel.Text = "Error, User Name Already Exists.";
                    userNameInput.Text = "";

                }

            }

            proxy.Close();

        }
    }
}