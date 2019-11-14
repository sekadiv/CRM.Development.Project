using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Development.Businesslogic.Models.WorkOrder
{
    public static class WorkOrder
    {
        public const string EntityLogicalName = "msdyn_workorder";
        public static class Attributes
        {
            public static string ServiceAccount = "msdyn_serviceaccount";
            public static string WorkOrderId = "msdyn_workorderid";
            public static string WorkorderStatus = "statecode";
            public static string PostCode = "msdyn_postalcode";
            public static string AccountNumber = "new_accountnumber";
        }

        public enum WorkOrderStatus
        {
            Active=0,
            InActive=1
        };

        public enum WorkOrderSystemStatus
        {
            OpenUnScheduled = 690970000,
            OpenScheduled= 690970001,
            OpenInprogress= 690970002,
            OpenCompleted= 690970003,
            ClosedPosted= 690970004,
            ClosedCanceled= 690970005
        };
    }
}
