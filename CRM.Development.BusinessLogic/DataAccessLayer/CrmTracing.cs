using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Development.Businesslogic.DataAccessLayer
{
    public class CrmTracing :ICustomTracingService
    {
        private ITracingService _tracingSerivce;

        public CrmTracing(ITracingService tracingSerivce)
        {
            _tracingSerivce = tracingSerivce;
        }

        public void Trace(string message, params object[] args)
        {
            _tracingSerivce.Trace(message, args);
        }
    }
}
