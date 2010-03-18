using System.Reflection;
using Chimera.Fluent;
using Chimera.Framework.Errors;
using Chimera.Framework.InversionOfControl;
using Chimera.Framework.Routing;
using Chimera.Interaction.Tests.Utilities;
using Chimera.StructureMap;

namespace Chimera.Interaction.Tests.Tests
{
    public class SetupDefaultConfig
    {
        protected IRoutingEngine _routingEngine;
        protected TestRouteLog RouteLog { get; private set; }
        protected TestErrorsLog ErrorsLog { get; private set; }

        public void Configure()
        {
            var assembly = Assembly.GetAssembly(typeof (SetupDefaultConfig));

            ErrorsLog = new TestErrorsLog();

            Configuration.Default(new StructureMapContainer())
                .Register(assembly)
                .SetErrorPresenter<TestErrorsLog>()
                .DefaultShowAs("window");

            _routingEngine = IoC.Get<IRoutingEngine>();

            RouteLog = new TestRouteLog();
            _routingEngine.AddProcessor(RouteLog);

            ErrorsLog = IoC.Get<IErrorPresenter>() as TestErrorsLog;            
        }
    }
}