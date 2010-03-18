using System;
using Chimera.Default.Utilities;
using Chimera.Framework.Listeners;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Listeners
{
    public class ListenerRegistrar : ConventionRegistrar<Type>
    {
        public ListenerRegistrar(IListenerFactoryProcessor processor, IListenerFactory factory)
            : base(processor, factory as IRegisterRoutes<Type>)
        {
        }
    }
}