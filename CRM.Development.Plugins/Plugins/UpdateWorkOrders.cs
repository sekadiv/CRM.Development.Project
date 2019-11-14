using CRM.Development.Businesslogic.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Development.Businesslogic.DataAccessLayer;
using CRM.Development.Businesslogic.BusinessLogic;

namespace CRM.Development.Plugins.Plugin
{
    public class UpdateWorkOrders : BasePlugin
    {
        public override string ExpectedEntityLogicalName { get { return AccountModel.EntityLogicalName; } }

        public override void PostExecute(IServiceProvider serviceProvider)
        {
            var UpdateRelatedWorkOrders = new UpdateRelatedWorkOrder(DataAccessLayerFactory.GetWorkOrderDataLayer(), CustomTracingService);
            UpdateRelatedWorkOrders.UpdateAccountWorkOrders(Entity.Id);
            
        }
    }
}
