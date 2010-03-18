using System;
using Chimera.Default.Utilities;
using Chimera.Framework.Utilities;
using Chimera.Framework.ViewModels;

namespace Chimera.Default.ViewModels
{
    public class ViewModelRegistrar : ConventionRegistrar<Type>
    {
        public ViewModelRegistrar(IViewModelProcessor processor, IViewModelEngine engine)
            : base(processor, engine as IRegisterRoutes<Type>)
        {
        }
    }
}