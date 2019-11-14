using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using CRM.Development.Businesslogic.DataAccessLayer;

namespace CRM.Development.Plugins.Plugin
{
    public abstract class BasePlugin : IPlugin
    {
        protected IOrganizationService OrganizationService;
        protected IPluginExecutionContext PluginContext;
        protected ICustomTracingService CustomTracingService;
        protected Entity Entity;
        protected DataAccessLayerFactory DataAccessLayerFactory;
        public abstract void PostExecute(IServiceProvider serviceProvider);
        public abstract string ExpectedEntityLogicalName { get; }
        public void Execute(IServiceProvider serviceProvider)
        {
            var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            PluginContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (!PluginContext.InputParameters.Contains("Target") || !(PluginContext.InputParameters["Target"] is Entity))
                return;

            Entity = (Entity)PluginContext.InputParameters["Target"];
            if (Entity.LogicalName != ExpectedEntityLogicalName)
                return;
            IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            OrganizationService = serviceFactory.CreateOrganizationService(PluginContext.UserId);
            DataAccessLayerFactory = new DataAccessLayerFactory(OrganizationService, tracingService);
                CustomTracingService = DataAccessLayerFactory.GetTracingService();
                try
                {
                    PostExecute(serviceProvider);
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in this plug-in.", ex);
                }
                catch (Exception ex)
                {
                    CustomTracingService.Trace("Plugin Exception: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }

