using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

/*
 
    Mathew MacMillan
    CSE 445

    Project 5 Service Contract Definition

 */

namespace Project5Services
{

    [ServiceContract]
    public interface IProject5Services
    {

        [OperationContract]
        void AddMember(string username, string password);

        [OperationContract]
        void AddStaffMember(string username, string password);

        [OperationContract]
        bool MemberExists(string username);

        [OperationContract]
        bool StaffExists(string username);

        [OperationContract]
        string[] SearchForWsdl(string theSearch);

        [OperationContract]
        string[] WsOperations(string wsUrl);

        [OperationContract]
        string[] WsOperationNames(string wsUrl);

        [OperationContract]
        string[] WsOperationInput(string wsUrl);

        [OperationContract]
        string[] WsOperationReturn(string wsUrl);

        [OperationContract]
        void AddToList(string member, string url, string[] opNames, string[] opInputs, string[] opReturnTypes);

        [OperationContract]
        string[] LoadMyList(string member);

        [OperationContract]
        string[] LoadStaff(string member);

    }

}
