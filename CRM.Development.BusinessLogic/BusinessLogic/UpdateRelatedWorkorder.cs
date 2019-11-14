using CRM.Development.Businesslogic.DataAccessLayer;
using CRM.Development.Businesslogic.Models.WorkOrder;
using System;

namespace CRM.Development.Businesslogic.BusinessLogic
{
    public class UpdateRelatedWorkOrder
    {
        private IWorkOrderDataAccessLayer _workOrderDataAccessLayer;
        private ICustomTracingService _tracingService;
        public UpdateRelatedWorkOrder(IWorkOrderDataAccessLayer workOrderDataAccessLayer, ICustomTracingService tracingService)
        {
            _workOrderDataAccessLayer = workOrderDataAccessLayer;
            _tracingService = tracingService;
        }

        public void UpdateAccountWorkOrders(Guid accountID)
        {
            var WorkOrders = _workOrderDataAccessLayer.GetRelatedWorkOrders(accountID, WorkOrder.Attributes.ServiceAccount);
            string accountNumber = _workOrderDataAccessLayer.GetServiceAccountAccountNumber(accountID);
            if (WorkOrders != null && WorkOrders.Entities.Count > 0 && accountNumber != string.Empty)
            {
                _tracingService.Trace("Related WorkOrders for Service Account : {0} is {1}", accountID, WorkOrders.Entities.Count);
                foreach (var WorkOrderEntity in WorkOrders.Entities)
                {
                   
                    Guid WorkOrderID = (Guid)WorkOrderEntity[WorkOrder.Attributes.WorkOrderId];
                    WorkOrderEntity.Attributes[WorkOrder.Attributes.AccountNumber] = accountNumber;
                    WorkOrderEntity.Id = WorkOrderID;
                    _workOrderDataAccessLayer.UpdateEntity(WorkOrderEntity);
                    _tracingService.Trace(" WorkOrder {0} updated with Account Number {1}", WorkOrderID.ToString(), accountNumber);

                }


            }

        }
    }
}
