using Chimera.Framework.Controllers;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Controllers
{
    public class ControllerProcessor : IControllerProcessor
    {
        public bool CanProcess(IRoute route)
        {
            return route.Contains(KnownParameters.Controller)
                   && !route.Contains(KnownParameters.ProcessedByController);
        }

        public IRouteResult Process(IRoute route)
        {
            var controller = route[KnownParameters.Controller] as IController;

            var result = controller.Execute(route)
                .CopyParameterFrom(route, KnownParameters.ParentShowAs)
                .CopyParameterFrom(route, KnownParameters.ParentView)
                .AddParameter(KnownParameters.ProcessedByController, true)
                .AddParameter(KnownParameters.ParentController, controller);

            return result as IRouteResult;
        }
    }
}