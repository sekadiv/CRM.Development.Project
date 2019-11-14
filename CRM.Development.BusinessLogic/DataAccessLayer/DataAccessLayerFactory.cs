using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public class DataAccessLayerFactory 
    {
        private IOrganizationService _organisationService;
        private IWorkOrderDataAccessLayer _workOrderDataAccessLayer;
        private ICustomTracingService _customTracingService;
        private ITracingService _tracingService;

        public DataAccessLayerFactory(IOrganizationService organisationService, ITracingService tracingService)
        {
            _organisationService = organisationService;
            _tracingService = tracingService;
        }

       

        public ICustomTracingService GetTracingService()
        {
            if (_customTracingService == null)
                _customTracingService = new CrmTracing(_tracingService);
            return _customTracingService;
        }

        public IWorkOrderDataAccessLayer GetWorkOrderDataLayer()
        {
            if (_workOrderDataAccessLayer == null)
                _workOrderDataAccessLayer = new WorkOrderDataAccessLayer(_organisationService);
            return _workOrderDataAccessLayer;
        }
       

    }
}
