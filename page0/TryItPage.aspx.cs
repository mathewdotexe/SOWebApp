using Project5Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*

    Mathew MacMillan
    CSE 445

    Web Form - Try It Page

 */

namespace Project5
{
    public partial class TryItForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //
        // Try It Implementation of the WsdlAddress/WsdlDiscovery service offered within the Member Page
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
        // Try It Implementation of the WsOperations service offered within the Member Page
        // returns WSDL operations within a URL location
        //
        protected void operationsButton_Click(object sender, EventArgs e)
        {

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
        // Try It Implementation of how my defined library works, hashing a string of
        // text using the SHA256 algorithm
        //
        protected void hashButton_Click(object sender, EventArgs e)
        {

            HashPassword myHash = new HashPassword();

            string hashPass = myHash.GetHashString(hashPassInput.Text);

            hashedPass.Text = hashPass;

        }
    }
}