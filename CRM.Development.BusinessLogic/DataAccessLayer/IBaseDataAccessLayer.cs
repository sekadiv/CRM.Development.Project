using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public interface IBaseDataAccessLayer
    {
        void UpdateEntity(Entity entity);
        Guid CreateEntity(Entity entity);
        EntityCollection RetrieveEntities(string fetchXML);

        Entity RetrieveEntity(string EntityLogicalName, Guid EntityGuid, ColumnSet columnset);

        


    }
}
