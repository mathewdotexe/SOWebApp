using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Net;
using System.Web.Services.Description;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using HtmlAgilityPack;

/*

    Mathew MacMillan
    CSE 445

    Project 5 Service Contract Implementation

 */

namespace Project5Services
{

    public class Project5Services : IProject5Services
    {

        //
        // Modifies or Creates the Member.Xml file used for storing Member crudentials
        //
        // saves or creates file within the App_Data folder
        //
        public void AddMember(string username, string password)
        {

            string fileName = "Member.xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);
            FileStream fState = null;
            XmlTextWriter writer = null;

            if (!File.Exists(fLocation))
            {

                try
                {

                    //
                    // adding elements if file is not found
                    //
                    fState = new FileStream(fLocation, FileMode.CreateNew);
                    writer = new XmlTextWriter(fState, System.Text.Encoding.Unicode);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Members");
                    writer.WriteStartElement("Member");
                    writer.WriteElementString("UserName", username);
                    writer.WriteElementString("Password", password);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                finally
                {

                    if (writer != null)
                    {

                        writer.Flush();
                        writer.Close();

                    }

                }

            }
            else
            {

                //
                // injecting elements into existing file
                //
                XDocument xDoc = XDocument.Load(fLocation);
                XElement root = xDoc.Element("Members");
                IEnumerable<XElement> rows = root.Descendants("Member");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(

                    new XElement("Member",
                    new XElement("UserName", username),
                    new XElement("Password", password)));

                xDoc.Save(fLocation);

            }

        }

        //
        // Modifies the Staff.Xml file used for storing Staff crudentials
        //
        // saves the file within the App_Data folder
        //
        public void AddStaffMember(string username, string password)
        {

            string fileName = "Staff.xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);
            FileStream fState = null;
            XmlTextWriter writer = null;

            if (!File.Exists(fLocation))
            {

                try
                {

                    //
                    // adding elements if file is not found
                    //
                    fState = new FileStream(fLocation, FileMode.CreateNew);
                    writer = new XmlTextWriter(fState, System.Text.Encoding.Unicode);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Staff");
                    writer.WriteStartElement("StaffMember");
                    writer.WriteElementString("UserName", username);
                    writer.WriteElementString("Password", password);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                finally
                {

                    if (writer != null)
                    {

                        writer.Flush();
                        writer.Close();

                    }

                }

            }
            else
            {

                //
                // injecting elements into existing file
                //
                XDocument xDoc = XDocument.Load(fLocation);
                XElement root = xDoc.Element("Staff");
                IEnumerable<XElement> rows = root.Descendants("StaffMember");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(

                    new XElement("StaffMember",
                    new XElement("UserName", username),
                    new XElement("Password", password)));

                xDoc.Save(fLocation);

            }

        }

        //
        // Reads the Member.Xml file and checks if a User Name already exists
        // returns the appropriate boolean value
        //
        public bool MemberExists(string username)
        {

            bool exists = false;
            string fileName = "Member.xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);

            if (!File.Exists(fLocation))
            {

                return false;

            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fLocation);

            traverse(xmlDoc.DocumentElement);

            void traverse(XmlNode node)
            {

                if (node is XmlElement)
                {

                    if (node.Name == "Members")
                    {


                    }
                    else if (node.Name == "Member")
                    {

                        

                    }
                    else
                    {

  

                    }
                    if (node.HasChildNodes)
                    {

                        traverse(node.FirstChild);

                    }
                    if (node.NextSibling != null)
                    {

                        traverse(node.NextSibling);

                    }

                }

                else if (node is XmlText)
                {

                    string text = ((XmlText)node).Value;
                    if(text == username)
                    {

                        exists = true;

                    } 

                }

            }

            return exists;

        }

        //
        // Reads the Staff.Xml file and checks if a User Name already exists
        // returns the appropriate boolean value
        //
        public bool StaffExists(string username)
        {

            bool exists = false;
            string fileName = "Staff.xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);

            if (!File.Exists(fLocation))
            {

                return false;

            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fLocation);

            traverse(xmlDoc.DocumentElement);

            void traverse(XmlNode node)
            {

                if (node is XmlElement)
                {

                    if (node.Name == "Staff")
                    {


                    }
                    else if (node.Name == "StaffMember")
                    {



                    }
                    else
                    {



                    }
                    if (node.HasChildNodes)
                    {

                        traverse(node.FirstChild);

                    }
                    if (node.NextSibling != null)
                    {

                        traverse(node.NextSibling);

                    }

                }

                else if (node is XmlText)
                {

                    string text = ((XmlText)node).Value;
                    if (text == username)
                    {

                        exists = true;

                    }

                }

            }

            return exists;

        }

        //
        // Calls Google Engine API using WSDL address keywords, then analyzes and
        // returns all WSDL addresses inside the searched webpages
        //
        public string[] SearchForWsdl(string theSearch)
        {

            string searchQuery = theSearch;
            string cx = "965ef8549bb0a4f3e";
            string cr = "countryUS";
            string apiKey = "AIzaSyCl6Y7L97L9eLaWIsbDBcsZwA-j-4qtacY";

            var customSearchService = new CustomsearchService(new BaseClientService.Initializer
            {

                ApiKey = apiKey

            });

            var listRequest = customSearchService.Cse.List();
            listRequest.Cx = cx;
            listRequest.Q = searchQuery;
            listRequest.Cr = cr;

            List<string> searchData = new List<string>();
            List<string> htmlData = new List<string>();
            List<string> filteredHtml = new List<string>();
            List<string> firstFilter = new List<string>();
            List<string> secondFilter = new List<string>();

            var count = 0;
            var count2 = 0;

            while (searchData != null)
            {

                listRequest.Start = count;
                listRequest.Execute().Items?.ToList().ForEach(x => searchData.Add(x.Link));

                count++;
                if (count >= 20)
                {

                    break;

                }

            }

            firstFilter = searchData.Distinct().ToList();

            WebClient webClient = new WebClient();

            //
            // Filters out everything within the HTML Document but the href tags
            //
            foreach (string url in firstFilter)
            {
                try
                {

                    byte[] theUrlData = webClient.DownloadData(url);

                    string download = Encoding.ASCII.GetString(theUrlData);

                    var doc = new HtmlDocument();
                    doc.LoadHtml(download);
                    HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//a[@href]");

                    if (nodes != null)
                    {

                        foreach (var n in nodes)
                        {

                            string href = n.Attributes["href"].Value;
                            htmlData.Add(GetAbsoluteUrlString(url, href));
                            count2++;

                        }

                    }

                }
                catch (Exception e)
                { }


                if (count2 >= 400)
                {

                    break;

                }

            }

            secondFilter = htmlData.Distinct().ToList();

            //
            // Filtering out everything but the proper WSDL addresses from the href filter
            //
            foreach (string url in secondFilter)
            {

                if (url.Contains(".asmx?WSDL") || url.Contains(".asmx?wsdl") || url.Contains("?wsdl") || url.Contains("?WSDL") || url.Contains(".svc?wsdl") || url.Contains(".svc?WSDL") || url.Contains(".php?wsdl") || url.Contains(".php?WSDL"))
                {

                    filteredHtml.Add(url);

                }


            }

            //
            // Removing duplicates
            //
            List<string> lastFilter = filteredHtml.Distinct().ToList();

            string[] theData = lastFilter.ToArray();

            return theData;

        }

        //
        // returns the full URL path
        //
        static string GetAbsoluteUrlString(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseUrl), uri);
            return uri.ToString();
        }

        //
        // Analyzes a WSDL file in XML format and returns operation names and their
        // corresponding input parameters and return types
        //
        // used for displaying results inside the Member Page
        //
        public string[] WsOperations(string wsUrl)
        {

            List<string> wholeList = new List<string>();
            List<string> nameList = new List<string>();
            List<string> returnTypeList = new List<string>();
            List<string> inputList = new List<string>();

            string[] myArray = new string[0];
            string[] myArray2 = new string[0];

            string theUrl = "";

            //
            // beginning of error handling for types of URLs entered.
            //
            if (wsUrl.Contains("asu") && wsUrl.Contains("?singleWsdl"))
            {

                theUrl = wsUrl;

            }

            else if (wsUrl.Contains("asu") && wsUrl.Contains("?singelwsdl") == false && wsUrl.Contains("?"))
            {

                int index = wsUrl.Length;

                string newString = wsUrl.Remove(index - 5, 5);
                theUrl = newString + "?singlewsdl";

            }
            else if (wsUrl.Contains("asu") == false && wsUrl.Contains("?"))
            {

                theUrl = wsUrl;

            }
            else if (wsUrl.Contains("asu") && wsUrl.Contains("?") == false)
            {

                theUrl = wsUrl + "?singlewsdl";

            }
            else
            {

                theUrl = wsUrl + "?wsdl";

            }
            //
            // end of error handling for types of URLs entered.
            //

            //
            // returns array of operation name, input values, and return types
            //
            XmlTextReader reader = new XmlTextReader(theUrl);

            ServiceDescription wsdl = ServiceDescription.Read(reader);

            foreach (PortType port in wsdl.PortTypes)
            {

                foreach (Operation op in port.Operations)
                {

                    //
                    // operation names and names of variables for input values and return types
                    //
                    string operationName = op.Name;
                    string inputMessageName = op.Messages.Input.Message.Name;
                    string outputMessageName = op.Messages.Output.Message.Name;

                    nameList.Add(operationName);


                    string inputMessagePartName =
                        wsdl.Messages[inputMessageName].Parts[0].Element.Name;
                    string outputMessagePartName =
                        wsdl.Messages[outputMessageName].Parts[0].Element.Name;

                    //
                    // storing input and output message parts in lists
                    // these lists hold the input values and return types of the operations
                    //
                    List<string> newList = GetParameters(wsdl, inputMessagePartName);
                    List<string> newList2 = GetParameters(wsdl, outputMessagePartName);

                    List<string> upDatedlist = new List<string>();
                    List<string> upDatedList2 = new List<string>();

                    if (newList.Count() == 0)
                    {

                        inputList.Add("void");

                    }
                    else if (newList.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList.Count(); i++)
                        {

                            if (i == newList.Count() - 1)
                            {

                                stringList += newList[i];

                            }
                            else
                            {

                                stringList += newList[i] + ",";

                            }

                        }

                        upDatedlist.Add(stringList);
                        inputList.AddRange(upDatedlist);

                    }
                    else { inputList.AddRange(newList); }

                    if (newList2.Count() == 0)
                    {

                        returnTypeList.Add("void");

                    }
                    else if (newList2.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList2.Count(); i++)
                        {

                            if (i == newList2.Count() - 1)
                            {

                                stringList += newList2[i];

                            }
                            else
                            {

                                stringList += newList2[i] + ",";

                            }

                        }

                        upDatedList2.Add(stringList);
                        returnTypeList.AddRange(upDatedList2);

                    }
                    else { returnTypeList.AddRange(newList2); }


                }

            }

            //
            // building array to be displayed to the Member Page
            //
            for (int i = 0; i < nameList.Count; i++)
            {

                wholeList.Add("Name: " + "\"" + nameList[i] + "\" | " + "Input Type(s): (" + inputList[i] + ") | " + "Return Type: " + returnTypeList[i]);

            }

            myArray = wholeList.ToArray();
            return myArray;

        }

        //
        // Duplicate helper service to be used with AddToList service
        // returns solely the names of the operations
        //
        public string[] WsOperationNames(string wsUrl)
        {

            List<string> wholeList = new List<string>();
            List<string> nameList = new List<string>();
            List<string> returnTypeList = new List<string>();
            List<string> inputList = new List<string>();

            string[] myArray = new string[0];
            string[] myArray2 = new string[0];

            string theUrl = "";

            //
            // beginning of error handling for types of URLs entered.
            //
            if (wsUrl.Contains("asu") && wsUrl.Contains("?singleWsdl"))
            {

                theUrl = wsUrl;

            }

            else if (wsUrl.Contains("asu") && wsUrl.Contains("?singelwsdl") == false && wsUrl.Contains("?"))
            {

                int index = wsUrl.Length;

                string newString = wsUrl.Remove(index - 5, 5);
                theUrl = newString + "?singlewsdl";

            }
            else if (wsUrl.Contains("asu") == false && wsUrl.Contains("?"))
            {

                theUrl = wsUrl;

            }
            else if (wsUrl.Contains("asu") && wsUrl.Contains("?") == false)
            {

                theUrl = wsUrl + "?singlewsdl";

            }
            else
            {

                theUrl = wsUrl + "?wsdl";

            }
            //
            // end of error handling for types of URLs entered.
            //

            //
            // returns array of operation name, input values, and return types
            //
            XmlTextReader reader = new XmlTextReader(theUrl);

            ServiceDescription wsdl = ServiceDescription.Read(reader);

            foreach (PortType port in wsdl.PortTypes)
            {

                foreach (Operation op in port.Operations)
                {

                    //
                    // operation names and names of variables for input values and return types
                    //
                    string operationName = op.Name;
                    string inputMessageName = op.Messages.Input.Message.Name;
                    string outputMessageName = op.Messages.Output.Message.Name;

                    nameList.Add(operationName);


                    string inputMessagePartName =
                        wsdl.Messages[inputMessageName].Parts[0].Element.Name;
                    string outputMessagePartName =
                        wsdl.Messages[outputMessageName].Parts[0].Element.Name;

                    //
                    // storing input and output message parts in lists
                    // these lists hold the input values and return types of the operations
                    //
                    List<string> newList = GetParameters(wsdl, inputMessagePartName);
                    List<string> newList2 = GetParameters(wsdl, outputMessagePartName);

                    List<string> upDatedlist = new List<string>();
                    List<string> upDatedList2 = new List<string>();

                    if (newList.Count() == 0)
                    {

                        inputList.Add("void");

                    }
                    else if (newList.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList.Count(); i++)
                        {

                            if (i == newList.Count() - 1)
                            {

                                stringList += newList[i];

                            }
                            else
                            {

                                stringList += newList[i] + ",";

                            }

                        }

                        upDatedlist.Add(stringList);
                        inputList.AddRange(upDatedlist);

                    }
                    else { inputList.AddRange(newList); }

                    if (newList2.Count() == 0)
                    {

                        returnTypeList.Add("void");

                    }
                    else if (newList2.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList2.Count(); i++)
                        {

                            if (i == newList2.Count() - 1)
                            {

                                stringList += newList2[i];

                            }
                            else
                            {

                                stringList += newList2[i] + ",";

                            }

                        }

                        upDatedList2.Add(stringList);
                        returnTypeList.AddRange(upDatedList2);

                    }
                    else { returnTypeList.AddRange(newList2); }


                }

            }

            //
            // Building array to be returned to the Member List Page
            //
            for (int i = 0; i < nameList.Count; i++)
            {

                wholeList.Add(nameList[i]);

            }

            myArray = wholeList.ToArray();
            return myArray;

        }

        //
        // Duplicate helper service to be used with AddToList service
        // returns solely the input values of the operations
        //
        public string[] WsOperationInput(string wsUrl)
        {

            List<string> wholeList = new List<string>();
            List<string> nameList = new List<string>();
            List<string> returnTypeList = new List<string>();
            List<string> inputList = new List<string>();

            string[] myArray = new string[0];
            string[] myArray2 = new string[0];

            string theUrl = "";

            //
            // beginning of error handling for types of URLs entered.
            //
            if (wsUrl.Contains("asu") && wsUrl.Contains("?singleWsdl"))
            {

                theUrl = wsUrl;

            }

            else if (wsUrl.Contains("asu") && wsUrl.Contains("?singelwsdl") == false && wsUrl.Contains("?"))
            {

                int index = wsUrl.Length;

                string newString = wsUrl.Remove(index - 5, 5);
                theUrl = newString + "?singlewsdl";

            }
            else if (wsUrl.Contains("asu") == false && wsUrl.Contains("?"))
            {

                theUrl = wsUrl;

            }
            else if (wsUrl.Contains("asu") && wsUrl.Contains("?") == false)
            {

                theUrl = wsUrl + "?singlewsdl";

            }
            else
            {

                theUrl = wsUrl + "?wsdl";

            }
            //
            // end of error handling for types of URLs entered.
            //

            //
            // returns array of operation name, input values, and return types
            //
            XmlTextReader reader = new XmlTextReader(theUrl);

            ServiceDescription wsdl = ServiceDescription.Read(reader);

            foreach (PortType port in wsdl.PortTypes)
            {

                foreach (Operation op in port.Operations)
                {

                    //
                    // operation names and names of variables for input values and return types
                    //
                    string operationName = op.Name;
                    string inputMessageName = op.Messages.Input.Message.Name;
                    string outputMessageName = op.Messages.Output.Message.Name;

                    nameList.Add(operationName);


                    string inputMessagePartName =
                        wsdl.Messages[inputMessageName].Parts[0].Element.Name;
                    string outputMessagePartName =
                        wsdl.Messages[outputMessageName].Parts[0].Element.Name;

                    //
                    // storing input and output message parts in lists
                    // these lists hold the input values and return types of the operations
                    //
                    List<string> newList = GetParameters(wsdl, inputMessagePartName);
                    List<string> newList2 = GetParameters(wsdl, outputMessagePartName);

                    List<string> upDatedlist = new List<string>();
                    List<string> upDatedList2 = new List<string>();

                    if (newList.Count() == 0)
                    {

                        inputList.Add("void");

                    }
                    else if (newList.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList.Count(); i++)
                        {

                            if (i == newList.Count() - 1)
                            {

                                stringList += newList[i];

                            }
                            else
                            {

                                stringList += newList[i] + ",";

                            }

                        }

                        upDatedlist.Add(stringList);
                        inputList.AddRange(upDatedlist);

                    }
                    else { inputList.AddRange(newList); }

                    if (newList2.Count() == 0)
                    {

                        returnTypeList.Add("void");

                    }
                    else if (newList2.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList2.Count(); i++)
                        {

                            if (i == newList2.Count() - 1)
                            {

                                stringList += newList2[i];

                            }
                            else
                            {

                                stringList += newList2[i] + ",";

                            }

                        }

                        upDatedList2.Add(stringList);
                        returnTypeList.AddRange(upDatedList2);

                    }
                    else { returnTypeList.AddRange(newList2); }


                }

            }

            //
            // Building array to be returned to the Member List Page
            //
            for (int i = 0; i < nameList.Count; i++)
            {

                wholeList.Add(inputList[i]);

            }

            myArray = wholeList.ToArray();
            return myArray;

        }

        //
        // Duplicate helper service to be used with AddToList service
        // returns solely the return values of the operations
        //
        public string[] WsOperationReturn(string wsUrl)
        {

            List<string> wholeList = new List<string>();
            List<string> nameList = new List<string>();
            List<string> returnTypeList = new List<string>();
            List<string> inputList = new List<string>();

            string[] myArray = new string[0];
            string[] myArray2 = new string[0];

            //
            // beginning of error handling for types of URLs entered.
            //
            string theUrl = "";

            if (wsUrl.Contains("asu") && wsUrl.Contains("?singleWsdl"))
            {

                theUrl = wsUrl;

            }

            else if (wsUrl.Contains("asu") && wsUrl.Contains("?singelwsdl") == false && wsUrl.Contains("?"))
            {

                int index = wsUrl.Length;

                string newString = wsUrl.Remove(index - 5, 5);
                theUrl = newString + "?singlewsdl";

            }
            else if (wsUrl.Contains("asu") == false && wsUrl.Contains("?"))
            {

                theUrl = wsUrl;

            }
            else if (wsUrl.Contains("asu") && wsUrl.Contains("?") == false)
            {

                theUrl = wsUrl + "?singlewsdl";

            }
            else
            {

                theUrl = wsUrl + "?wsdl";

            }
            //
            // end of error handling for types of URLs entered.
            //

            //
            // returns array of operation name, input values, and return types
            //
            XmlTextReader reader = new XmlTextReader(theUrl);

            ServiceDescription wsdl = ServiceDescription.Read(reader);

            foreach (PortType port in wsdl.PortTypes)
            {

                foreach (Operation op in port.Operations)
                {

                    //
                    // operation names and names of variables for input values and return types
                    //
                    string operationName = op.Name;
                    string inputMessageName = op.Messages.Input.Message.Name;
                    string outputMessageName = op.Messages.Output.Message.Name;

                    nameList.Add(operationName);


                    string inputMessagePartName =
                        wsdl.Messages[inputMessageName].Parts[0].Element.Name;
                    string outputMessagePartName =
                        wsdl.Messages[outputMessageName].Parts[0].Element.Name;

                    //
                    // storing input and output message parts in lists
                    // these lists hold the input values and return types of the operations
                    //
                    List<string> newList = GetParameters(wsdl, inputMessagePartName);
                    List<string> newList2 = GetParameters(wsdl, outputMessagePartName);

                    List<string> upDatedlist = new List<string>();
                    List<string> upDatedList2 = new List<string>();

                    if (newList.Count() == 0)
                    {

                        inputList.Add("void");

                    }
                    else if (newList.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList.Count(); i++)
                        {

                            if (i == newList.Count() - 1)
                            {

                                stringList += newList[i];

                            }
                            else
                            {

                                stringList += newList[i] + ",";

                            }

                        }

                        upDatedlist.Add(stringList);
                        inputList.AddRange(upDatedlist);

                    }
                    else { inputList.AddRange(newList); }

                    if (newList2.Count() == 0)
                    {

                        returnTypeList.Add("void");

                    }
                    else if (newList2.Count() > 1)
                    {

                        string stringList = "";
                        for (int i = 0; i < newList2.Count(); i++)
                        {

                            if (i == newList2.Count() - 1)
                            {

                                stringList += newList2[i];

                            }
                            else
                            {

                                stringList += newList2[i] + ",";

                            }

                        }

                        upDatedList2.Add(stringList);
                        returnTypeList.AddRange(upDatedList2);

                    }
                    else { returnTypeList.AddRange(newList2); }


                }

            }

            //
            // Building array to be returned to the Member List Page
            //
            for (int i = 0; i < nameList.Count; i++)
            {

                wholeList.Add(returnTypeList[i]);

            }

            myArray = wholeList.ToArray();
            return myArray;

        }

        //
        // Returns a list of parameter types derived from the complex type elements
        //
        private static List<string> GetParameters(ServiceDescription serviceDescription, string messagePartName)
        {

            List<string> theList = new List<string>();

            Types types = serviceDescription.Types;
            System.Xml.Schema.XmlSchema xmlSchema = types.Schemas[0];

            foreach (object item in xmlSchema.Items)
            {

                System.Xml.Schema.XmlSchemaElement schemaElement = item as System.Xml.Schema.XmlSchemaElement;
                if (schemaElement != null)
                {

                    if (schemaElement.Name == messagePartName)
                    {
                        System.Xml.Schema.XmlSchemaType schemaType = schemaElement.SchemaType;
                        System.Xml.Schema.XmlSchemaComplexType complexType = schemaType as System.Xml.Schema.XmlSchemaComplexType;

                        if (complexType != null)
                        {
                            System.Xml.Schema.XmlSchemaParticle particle = complexType.Particle;
                            System.Xml.Schema.XmlSchemaSequence sequence = particle as System.Xml.Schema.XmlSchemaSequence;

                            if (sequence != null)
                            {

                                foreach (System.Xml.Schema.XmlSchemaElement childElement in sequence.Items)
                                {

                                    string parameterName = childElement.Name;
                                    string parameterType = childElement.SchemaTypeName.Name;

                                    theList.Add(parameterType);


                                }

                            }

                        }

                    }

                }

            }

            return theList;

        }

        //
        // Modifies or Creates the [Member]List.Xml file used for storing the Member's List
        //
        // saves or creates file within the App_Data folder
        //
        public void AddToList(string member, string url, string[] opNames, string[] opInputs, string[] opReturnTypes)
        {

            string fileName = member + ".xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);
            FileStream fState = null;
            XmlTextWriter writer = null;

            if (!File.Exists(fLocation))
            {

                try
                {

                    //
                    // adding elements if file is not found
                    //
                    fState = new FileStream(fLocation, FileMode.CreateNew);
                    writer = new XmlTextWriter(fState, System.Text.Encoding.Unicode);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Operations");
                    writer.WriteStartElement("URL");

                    for (int i = 0; i < opNames.Length; i++)
                    {

                        writer.WriteStartElement("Operation");
                        writer.WriteElementString("Location", url);
                        writer.WriteElementString("Name", opNames[i]);
                        writer.WriteElementString("Input", opInputs[i]);
                        writer.WriteElementString("ReturnType", opReturnTypes[i]);
                        writer.WriteEndElement();

                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                finally
                {

                    if (writer != null)
                    {

                        writer.Flush();
                        writer.Close();

                    }

                }

            }
            else
            {

                //
                // injecting elements into existing file
                //
                XDocument xDoc = XDocument.Load(fLocation);
                XElement root = xDoc.Element("Operations");
                IEnumerable<XElement> rows = root.Descendants("Operation");
                XElement firstRow = rows.First();

                for (int i = 0; i < opNames.Length; i++)
                {

                    firstRow.AddBeforeSelf(

                        new XElement("Operation",
                        new XElement("Location", url),
                        new XElement("Name", opNames[i]),
                        new XElement("Input", opInputs[i]),
                        new XElement("ReturnType", opReturnTypes[i])));

                }

                xDoc.Save(fLocation);

            }

        }

        //
        // Reads the [Member]List.Xml file and returns a structured array to be
        // displayed within the Member List Page
        //
        public string[] LoadMyList(string member)
        {

            int count = 0;
            string[] info = null;
            List<string> infoList = new List<string>();
            string fileName = member + ".xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);

            if (!File.Exists(fLocation))
            {

                info = infoList.ToArray();
                return info;

            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fLocation);

            traverse(xmlDoc.DocumentElement);

            void traverse(XmlNode node)
            {

                if (node is XmlElement)
                {


                    if (node.Name == "Location")
                    {


                    }
                    else if (node.Name == "Name")
                    {


                    }
                    else if (node.Name == "Input")
                    {


                    }
                    else if (node.Name == "ReturnType")
                    {

                        

                    }
                    else
                    {


                    }
                    if (node.HasChildNodes)
                    {

                        traverse(node.FirstChild);

                    }
                    if (node.NextSibling != null)
                    {

                        traverse(node.NextSibling);

                    }

                }

                else if (node is XmlText)
                {

                    if (count == 0)
                    {

                        infoList.Add("--------------------------------------------------------------------------------");
                        string text = "Location: " + ((XmlText)node).Value;
                        infoList.Add(text);
                        count++;

                    }
                    else if (count == 1)
                    {

                        infoList.Add("--------------------------------------------------------------------------------");
                        string text = "Operation Name: " + ((XmlText)node).Value;
                        infoList.Add(text);
                        count++;

                    }
                    else if (count == 2)
                    {

                        string text = "Input Type(s): " + ((XmlText)node).Value;
                        infoList.Add(text);
                        count++;

                    }
                    else if (count == 3)
                    {

                        string text = "Return Type(s): " + ((XmlText)node).Value;
                        infoList.Add(text);
                        count = 0;

                    }
                   
                }

            }

            info = infoList.ToArray();

            return info;

        }

        //
        // Reads the Staff.Xml file and returns a structured array to be
        // displayed within the Staff Page
        //
        public string[] LoadStaff(string member)
        {

            int count = 0;
            string[] info = null;
            List<string> infoList = new List<string>();
            string fileName = member + ".xml";
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            fLocation = Path.Combine(fLocation, fileName);

            if (!File.Exists(fLocation))
            {

                info = infoList.ToArray();
                return info;

            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fLocation);

            traverse(xmlDoc.DocumentElement);

            void traverse(XmlNode node)
            {

                if (node is XmlElement)
                {


                    if (node.Name == "Username")
                    {


                    }
                    else if (node.Name == "Password")
                    {


                    }
                    else
                    {


                    }
                    if (node.HasChildNodes)
                    {

                        traverse(node.FirstChild);

                    }
                    if (node.NextSibling != null)
                    {

                        traverse(node.NextSibling);

                    }

                }

                else if (node is XmlText)
                {

                    if (count == 0)
                    {

                        infoList.Add("--------------------------------------------------------------------------------");
                        string text = "Staff Member: " + ((XmlText)node).Value;
                        infoList.Add(text);
                        count++;

                    }
                    else if (count == 1)
                    {

                        count = 0;

                    }

                }

            }

            info = infoList.ToArray();

            return info;

        }

    }

}
