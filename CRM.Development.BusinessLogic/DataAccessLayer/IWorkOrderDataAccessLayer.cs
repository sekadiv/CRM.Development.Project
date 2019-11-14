using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using CRM.Development.Businesslogic.Models.WorkOrder;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public interface IWorkOrderDataAccessLayer : IBaseDataAccessLayer
    {
        EntityCollection GetRelatedWorkOrders(Guid parentEntityGuid, string parentEntityLookupName);
        string GetServiceAccountAccountNumber(Guid accountID);
    }
}
