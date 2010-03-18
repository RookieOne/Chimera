using System;
using Chimera.Default.Utilities;
using Chimera.Framework.Controllers;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Controllers
{
    public class ControllerRegistrar : ConventionRegistrar<Type>
    {
        public ControllerRegistrar(IControllerFactoryProcessor processor, IControllerFactory factory)
            : base(processor, factory as IRegisterRoutes<Type>)
        {
        }
    }
}