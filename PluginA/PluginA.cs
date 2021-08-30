using Microsoft.Xrm.Sdk;
using System;

namespace PluginA
{
    /* 
     * Plugin development guide: https://docs.microsoft.com/powerapps/developer/common-data-service/plug-ins
     * Best practices and guidance: https://docs.microsoft.com/powerapps/developer/common-data-service/best-practices/business-logic/
     */
    [CrmPluginRegistration(
       MessageNameEnum.Create,
       "account",
       StageEnum.PreOperation, ExecutionModeEnum.Synchronous,
       "name",
       "PluginA - PreOperation Create Account", 1, IsolationModeEnum.Sandbox)]
    public class PluginA : PluginBase
    {
        public PluginA(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(PluginA))
        {
            // TODO: Implement your custom configuration handling
            // https://docs.microsoft.com/powerapps/developer/common-data-service/register-plug-in#set-configuration-data
        }

        // Entry point for custom business logic execution
        protected override void ExecuteCdsPlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException("localPluginContext");
            }

            IPluginExecutionContext context = localPluginContext.PluginExecutionContext;

            // TODO: Implement your custom business logic

            // Check for the entity on which the plugin would be registered
            //if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            //{
            //    Entity entity = (Entity)context.InputParameters["Target"];

            //    // Check for entity name on which this plugin would be registered
            //    if (entity.LogicalName == "account")
            //    {

            //    }
            //}
        }
    }
}