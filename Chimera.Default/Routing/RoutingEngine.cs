using System;
using System.Collections.Generic;
using System.Linq;
using Chimera.Framework.Extensions;
using Chimera.Framework.Routing;
using Chimera.Framework.Routing.Extensions;
using Chimera.Framework.Utilities;

namespace Chimera.Default.Routing
{
    public class RoutingEngine : IRoutingEngine
    {
        public RoutingEngine()
        {
            _processors = new List<IRouteProcessor>();
        }

        readonly List<IRouteProcessor> _processors;
        Action<Exception> _exceptionAction = e => { };

        public void AddProcessor(IRouteProcessor processor)
        {
            _processors.Add(processor);

            Observable
                .FromEvent<EventArgs<IRoute>>(this, "RouteEvent")
                .Select(args => args.EventArgs.Value)
                .Where(processor.CanProcess)
                .Subscribe(s => OnNext(s, processor), _exceptionAction);
        }

        public void Process(IRoute route)
        {            
            RouteEvent(this, new EventArgs<IRoute>(route));
        }

        void OnNext(IRoute route, IRouteProcessor processor)
        {
            if (route.IsEnd())
                return;

            route.Start = DateTime.Now.Ticks;
            var result = processor.Process(route);
            route.End = DateTime.Now.Ticks;

            Process(result);
        }

        public void OnExceptions(Action<Exception> exceptionAction)
        {
            _exceptionAction = exceptionAction;
        }

        public event EventHandler<EventArgs<IRoute>> RouteEvent = delegate { };
    }
}