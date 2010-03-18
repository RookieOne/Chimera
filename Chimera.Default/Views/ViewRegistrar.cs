using System;
using Chimera.Default.Utilities;
using Chimera.Framework.Utilities;
using Chimera.Framework.Views;

namespace Chimera.Default.Views
{
    public class ViewRegistrar : ConventionRegistrar<Type>
    {
        public ViewRegistrar(IViewProcessor processor, IViewEngine engine)
            : base(processor, engine as IRegisterRoutes<Type>)
        {
        }
    }
}