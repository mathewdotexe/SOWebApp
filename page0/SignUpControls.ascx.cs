using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project5Library;

/*

    Mathew MacMillan
    CSE 445

    User Controls - Controls for the Sign Up Page

 */

namespace Project5
{
    public partial class SignUpController : System.Web.UI.UserControl
    {

        // holds the verification text returned from ASU's restful service, Image Verifier
        static string verifyText;

        //
        // Loads the verifyText variable with the proper verfification string
        // user's will need to match this text to continue
        //
        protected void Page_Load(object sender, EventArgs e)
        {

            loginLabel.Text = "Already have an account? <a href = 'LoginPage.aspx'>Login</a>";

            string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {

                stringChars[i] = chars[random.Next(chars.Length)];

            }

            if(verifyText == null)
            {

                verifyText = new string(stringChars);

            }

            string finalVerify = string.Concat(venusRestful, verifyText);

            verifyImage.ImageUrl = finalVerify;

        }

        //
        // If the user correctly enters the proper information, the service AddMember will add their
        // crudentials to the Member.XML file
        //
        // Uses my defined libaray for password hashing
        //
        // Has extra conditions for empty text fields and verfification testing
        // 
        protected void registerButton_Click(object sender, EventArgs e)
        {

            Project5ServicesProxy.Project5ServicesClient proxy = new Project5ServicesProxy.Project5ServicesClient();
            HashPassword myHash = new HashPassword();

            if(verifyText != verifyInput.Text)
            {

                returnLabel.Text = "Verification Failed, Try Again.";
                verifyInput.Text = "";
                string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
                var stringChars = new char[5];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {

                    stringChars[i] = chars[random.Next(chars.Length)];

                }


                verifyText = new string(stringChars);

                string finalVerify = string.Concat(venusRestful, verifyText);

                verifyImage.ImageUrl = finalVerify;

            }
            else if(userNameLabel.Text == "" || passwordInput.Text == "" || confirmPassLabel.Text == "" || verifyInput.Text == "")
            {

                returnLabel.Text = "Error, One or More Required Fields are Empty.";
                verifyInput.Text = "";
                string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
                var stringChars = new char[5];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {

                    stringChars[i] = chars[random.Next(chars.Length)];

                }


                verifyText = new string(stringChars);

                string finalVerify = string.Concat(venusRestful, verifyText);

                verifyImage.ImageUrl = finalVerify;

            }
            else if(passwordInput.Text != confirmPassInput.Text)
            {

                returnLabel.Text = "Error, Passwords Do Not Match.";
                verifyInput.Text = "";
                string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
                var stringChars = new char[5];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {

                    stringChars[i] = chars[random.Next(chars.Length)];

                }


                verifyText = new string(stringChars);

                string finalVerify = string.Concat(venusRestful, verifyText);

                verifyImage.ImageUrl = finalVerify;

            }
            else
            {

                if (proxy.MemberExists(userNameInput.Text) != true)
                {

                    string hashPass = myHash.GetHashString(passwordInput.Text);
                    proxy.AddMember(userNameInput.Text, hashPass);

                    returnLabel.Text = "Success!";

                    userNameInput.Text = "";
                    verifyInput.Text = "";
                    verifyImage.Visible = false;

                    string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
                    var stringChars = new char[5];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {

                        stringChars[i] = chars[random.Next(chars.Length)];

                    }


                    verifyText = new string(stringChars);

                    string finalVerify = string.Concat(venusRestful, verifyText);

                    verifyImage.ImageUrl = finalVerify;

                    Response.Redirect("http://webstrar25.fulton.asu.edu/page0/LoginPage.aspx");

                }
                else
                {

                    returnLabel.Text = "Error, User Name Already Exists.";
                    verifyInput.Text = "";
                    userNameInput.Text = "";
                    string venusRestful = "https://venus.sod.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/";

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$";
                    var stringChars = new char[5];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {

                        stringChars[i] = chars[random.Next(chars.Length)];

                    }


                    verifyText = new string(stringChars);

                    string finalVerify = string.Concat(venusRestful, verifyText);

                    verifyImage.ImageUrl = finalVerify;

                }

            }

            proxy.Close();

        }
    }
}