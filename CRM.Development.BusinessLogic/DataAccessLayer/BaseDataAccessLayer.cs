using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
   public class BaseDataAccessLayer : IBaseDataAccessLayer
    {
        protected IOrganizationService OrganizationService;
        
       
        public BaseDataAccessLayer(IOrganizationService organizationService)
        {
            OrganizationService = organizationService;
            
        }
        public virtual void UpdateEntity(Entity entity)
        {
            OrganizationService.Update(entity);
        }

        public virtual Guid CreateEntity(Entity entity)
        {
            Guid entityId=OrganizationService.Create(entity);
            return entityId;
        }

        public EntityCollection RetrieveEntities(string fetchXML)
        {
            
                EntityCollection entityCollection = OrganizationService.RetrieveMultiple(new FetchExpression(fetchXML));
                return entityCollection;
                       
        }

        public Entity RetrieveEntity(string EntityLogicalName, Guid EntityGuid, ColumnSet columnset)
        {
            Entity entity = OrganizationService.Retrieve(EntityLogicalName, EntityGuid, columnset);
            return entity;
        }
    }
}
