using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xrm.Sdk;
using CRM.Development.Businesslogic.Models.WorkOrder;
using CRM.Development.Businesslogic.Models.Account;
using Microsoft.Xrm.Sdk.Query;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public class WorkOrderDataAccessLayer : BaseDataAccessLayer, IWorkOrderDataAccessLayer
    {
        public WorkOrderDataAccessLayer(IOrganizationService organizationService) : base(organizationService)
        {

        }
        public EntityCollection GetRelatedWorkOrders(Guid parentEntityGuid, string parentEntityLookupName)
        {
            var fetchData = new
            {
                parentId = parentEntityGuid,
                statecode = WorkOrder.WorkOrderStatus.Active
            };
            var fetchXml = $@"
                                    <fetch top='50'>
                                      <entity name='msdyn_workorder'>
                                        <attribute name='msdyn_workorderid' />
                                        <attribute name='msdyn_name' />
                                        <filter type='and'>
                                          <condition attribute='{parentEntityLookupName}' operator='eq' value='{fetchData.parentId/*a16b3f4b-1be7-e611-8101-e0071b6af231*/}'/>
                                          <condition attribute='statecode' operator='eq' value='{fetchData.statecode/*0*/}'/>
                                        </filter>
                                      </entity>
                                    </fetch>";
            EntityCollection relatedRecords = RetrieveEntities(fetchXml);
            return relatedRecords;

        }

       public string GetServiceAccountAccountNumber(Guid accountID)
        {
            string accountNumber = string.Empty;
            ColumnSet cols = new ColumnSet(AccountModel.Attributes.AccountNumber);
            Entity accountEntity = RetrieveEntity(AccountModel.EntityLogicalName, accountID, cols);
            if (accountEntity != null)
                accountNumber = accountEntity.GetAttributeValue<string>(AccountModel.Attributes.AccountNumber);
            return accountNumber;

        }

       
    }

    
}
