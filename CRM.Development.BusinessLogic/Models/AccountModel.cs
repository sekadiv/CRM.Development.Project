using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using Microsoft.Xrm.Sdk.Client;

namespace CRM.Development.Businesslogic.Models.Account
{
    public static class AccountModel
    {
        public static class Attributes
        {
            public static string AccountName = "name";
            public static string AccountNumber = "accountnumber";
            public static string PostCode = "address1_postalcode";
            public static string AccountId = "accountid";

        }

        public const string EntityLogicalName = "account";


    }
}
